import logging
import threading
import time
from decimal import Decimal, InvalidOperation
from urllib.parse import urlparse

import requests


_logger = logging.getLogger(__name__)


class BarWeightApiError(Exception):
    """Safe message for failed legacy barem calculations."""


class BarWeightApiService:
    _token_cache = {}
    _token_lock = threading.Lock()

    def __init__(self, env):
        params = env["ir.config_parameter"].sudo()
        self.base_url = (params.get_param("iwmn_customer_dashboard.api_url") or "").rstrip("/")
        self.client_id = params.get_param("iwmn_customer_dashboard.client_id") or ""
        self.client_secret = params.get_param("iwmn_customer_dashboard.client_secret") or ""
        try:
            self.timeout = min(max(int(params.get_param("iwmn_customer_dashboard.timeout") or 15), 3), 60)
        except (TypeError, ValueError):
            self.timeout = 15

    def calculate(self, product_code, bundle_quantity, loose_bar_quantity):
        parsed = urlparse(self.base_url)
        if parsed.scheme not in ("http", "https") or not parsed.netloc or not self.client_id or not self.client_secret:
            raise BarWeightApiError("Chưa cấu hình kết nối IntegrationHub để tính kg.")
        if not product_code or not product_code.upper().startswith("BD"):
            raise BarWeightApiError("Vật tư thép cây không có mã hợp lệ để tính kg.")
        try:
            response = requests.get(
                f"{self.base_url}/api/v1/master-data/bar-weight",
                params={
                    "ma_vt": product_code,
                    "so_bo": bundle_quantity,
                    "so_cay_le": loose_bar_quantity,
                },
                headers={"Authorization": f"Bearer {self._get_access_token()}", "Accept": "application/json"},
                timeout=self.timeout,
            )
        except requests.RequestException as exception:
            _logger.warning("Barem API connection failed: %s", type(exception).__name__)
            raise BarWeightApiError("Không thể kết nối IntegrationHub để tính kg. Vui lòng thử lại.") from exception
        if not response.ok:
            _logger.warning("Barem API returned HTTP %s", response.status_code)
            raise BarWeightApiError(f"Không tính được kg theo barem SQL Server (HTTP {response.status_code}).")
        try:
            value = Decimal(str(response.json()["weightKg"]))
        except (ValueError, KeyError, TypeError, InvalidOperation) as exception:
            raise BarWeightApiError("IntegrationHub trả về kg không hợp lệ.") from exception
        if not value.is_finite() or value <= 0:
            raise BarWeightApiError("IntegrationHub trả về kg không hợp lệ.")
        return value

    def _get_access_token(self):
        cache_key = (self.base_url, self.client_id, "master.read")
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
                        "scope": "master.read",
                    },
                    timeout=self.timeout,
                )
            except requests.RequestException as exception:
                raise BarWeightApiError("Không thể xác thực IntegrationHub để tính kg.") from exception
            if not response.ok:
                _logger.warning("Barem token request returned HTTP %s", response.status_code)
                raise BarWeightApiError("IntegrationHub chưa cấp quyền master.read để tính kg.")
            try:
                payload = response.json()
                token = payload["access_token"]
                expires_in = int(payload.get("expires_in", 1800))
            except (ValueError, KeyError, TypeError) as exception:
                raise BarWeightApiError("Token IntegrationHub không hợp lệ.") from exception
            if not isinstance(token, str) or not token:
                raise BarWeightApiError("Token IntegrationHub không hợp lệ.")
            self._token_cache[cache_key] = (token, now + max(1, expires_in - 60))
            return token
