import logging
import threading
import time
from datetime import date
from urllib.parse import urlparse

import requests


_logger = logging.getLogger(__name__)


class CreditLimitApiError(Exception):
    """A safe-to-display integration error without credentials or response bodies."""


class CreditLimitApiService:
    _token_cache = {}
    _token_lock = threading.Lock()

    def __init__(self, env):
        params = env["ir.config_parameter"].sudo()
        self.base_url = (params.get_param("iwmn_customer_dashboard.api_url") or "").rstrip("/")
        self.client_id = params.get_param("iwmn_customer_dashboard.client_id") or ""
        self.client_secret = params.get_param("iwmn_customer_dashboard.client_secret") or ""
        self.business_unit = params.get_param("iwmn_customer_dashboard.business_unit") or "A01"
        try:
            self.timeout = min(max(int(params.get_param("iwmn_customer_dashboard.timeout") or 15), 3), 60)
        except (TypeError, ValueError):
            self.timeout = 15

    def get_summary(self, partner_code, document_date=None):
        self._validate_configuration()
        partner_code = (partner_code or "").strip()
        if not partner_code:
            raise CreditLimitApiError("Tài khoản chưa được gắn mã khách hàng ERP.")

        request_params = {
            "ngay_ct": (document_date or date.today()).isoformat(),
            "ma_dt": partner_code,
            # Keep original currency units so the UI can format exact VND values.
            "is_trieu": 0,
            "is_th": 0,
            "language_id": "V",
            "ma_dvcs": self.business_unit,
        }
        token = self._get_access_token()
        response = self._request_summary(token, request_params)
        if response.status_code == 401:
            self._invalidate_token()
            response = self._request_summary(self._get_access_token(), request_params)

        if response.status_code == 403:
            raise CreditLimitApiError("Kết nối IntegrationHub chưa được cấp quyền finance.read.")
        if not response.ok:
            _logger.warning("Credit summary API returned HTTP %s", response.status_code)
            raise CreditLimitApiError("Không thể tải dữ liệu hạn mức. Vui lòng thử lại sau.")

        try:
            payload = response.json()
        except ValueError as exception:
            raise CreditLimitApiError("IntegrationHub trả về dữ liệu không hợp lệ.") from exception
        if not isinstance(payload, list):
            raise CreditLimitApiError("IntegrationHub trả về dữ liệu không đúng định dạng.")
        return payload

    def get_details(self, partner_code, level, document_date=None):
        self._validate_configuration()
        partner_code = (partner_code or "").strip()
        if not partner_code:
            raise CreditLimitApiError("Tài khoản chưa được gắn mã khách hàng ERP.")
        if level not in (4, 6, 10, 12):
            raise CreditLimitApiError("Nhóm chi tiết hạn mức không hợp lệ.")

        request_params = {
            "ngay_ct": (document_date or date.today()).isoformat(),
            "ma_dt": partner_code,
            "level": level,
            "language_id": "V",
            "ma_dvcs": self.business_unit,
        }
        token = self._get_access_token()
        response = self._request_details(token, request_params)
        if response.status_code == 401:
            self._invalidate_token()
            response = self._request_details(self._get_access_token(), request_params)

        if response.status_code == 403:
            raise CreditLimitApiError("Kết nối IntegrationHub chưa được cấp quyền finance.read.")
        if not response.ok:
            _logger.warning("Credit detail API returned HTTP %s", response.status_code)
            raise CreditLimitApiError("Không thể tải chi tiết hạn mức. Vui lòng thử lại sau.")

        try:
            payload = response.json()
        except ValueError as exception:
            raise CreditLimitApiError("IntegrationHub trả về dữ liệu chi tiết không hợp lệ.") from exception
        if (
            not isinstance(payload, dict)
            or not isinstance(payload.get("columns"), list)
            or not isinstance(payload.get("items"), list)
        ):
            raise CreditLimitApiError("IntegrationHub trả về dữ liệu chi tiết không đúng định dạng.")
        return payload

    def _request_summary(self, token, request_params):
        try:
            return requests.get(
                f"{self.base_url}/api/v1/finance/credit-limit-summaries",
                params=request_params,
                headers={"Accept": "application/json", "Authorization": f"Bearer {token}"},
                timeout=self.timeout,
            )
        except requests.RequestException as exception:
            _logger.warning("Cannot reach the credit summary API: %s", type(exception).__name__)
            raise CreditLimitApiError("Không thể kết nối IntegrationHub. Vui lòng thử lại sau.") from exception

    def _request_details(self, token, request_params):
        try:
            return requests.get(
                f"{self.base_url}/api/v1/finance/credit-limit-details",
                params=request_params,
                headers={"Accept": "application/json", "Authorization": f"Bearer {token}"},
                timeout=self.timeout,
            )
        except requests.RequestException as exception:
            _logger.warning("Cannot reach the credit detail API: %s", type(exception).__name__)
            raise CreditLimitApiError("Không thể kết nối IntegrationHub. Vui lòng thử lại sau.") from exception

    def _get_access_token(self):
        cache_key = (self.base_url, self.client_id)
        now = time.monotonic()
        cached = self._token_cache.get(cache_key)
        if cached and cached[1] > now:
            return cached[0]

        with self._token_lock:
            cached = self._token_cache.get(cache_key)
            if cached and cached[1] > now:
                return cached[0]
            try:
                response = requests.post(
                    f"{self.base_url}/connect/token",
                    data={
                        "grant_type": "client_credentials",
                        "client_id": self.client_id,
                        "client_secret": self.client_secret,
                        "scope": "finance.read",
                    },
                    headers={"Accept": "application/json"},
                    timeout=self.timeout,
                )
            except requests.RequestException as exception:
                _logger.warning("Cannot reach the IntegrationHub token endpoint: %s", type(exception).__name__)
                raise CreditLimitApiError("Không thể xác thực với IntegrationHub.") from exception

            if not response.ok:
                _logger.warning("IntegrationHub token endpoint returned HTTP %s", response.status_code)
                raise CreditLimitApiError("Không thể xác thực với IntegrationHub.")
            try:
                token_payload = response.json()
                token = token_payload["access_token"]
                expires_in = int(token_payload.get("expires_in", 1800))
            except (ValueError, KeyError, TypeError) as exception:
                raise CreditLimitApiError("Phản hồi xác thực từ IntegrationHub không hợp lệ.") from exception
            if not isinstance(token, str) or not token:
                raise CreditLimitApiError("Phản hồi xác thực từ IntegrationHub không hợp lệ.")

            # Refresh at least 60 seconds before expiry; short-lived tokens keep a 10-second margin.
            ttl = max(1, expires_in - min(60, max(10, expires_in // 10)))
            self._token_cache[cache_key] = (token, now + ttl)
            return token

    def _invalidate_token(self):
        self._token_cache.pop((self.base_url, self.client_id), None)

    def _validate_configuration(self):
        parsed = urlparse(self.base_url)
        if parsed.scheme not in ("http", "https") or not parsed.netloc:
            raise CreditLimitApiError("Dashboard chưa được cấu hình địa chỉ IntegrationHub.")
        if not self.client_id or not self.client_secret:
            raise CreditLimitApiError("Dashboard chưa được cấu hình thông tin xác thực IntegrationHub.")
