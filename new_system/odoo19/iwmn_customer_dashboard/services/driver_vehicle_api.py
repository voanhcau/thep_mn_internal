import logging
import threading
import time
from urllib.parse import urlparse

import requests


_logger = logging.getLogger(__name__)


class DriverVehicleApiError(Exception):
    """Safe message for failed driver and vehicle lookups."""


class DriverVehicleApiService:
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

    def find(self, identity_number, document_date):
        parsed = urlparse(self.base_url)
        if parsed.scheme not in ("http", "https") or not parsed.netloc or not self.client_id or not self.client_secret:
            raise DriverVehicleApiError("Chưa cấu hình kết nối IntegrationHub để tìm tài xế.")
        try:
            response = requests.get(
                f"{self.base_url}/api/v1/orders/driver-vehicle",
                params={"identity_number": identity_number, "document_date": document_date},
                headers={"Authorization": f"Bearer {self._get_access_token()}", "Accept": "application/json"},
                timeout=self.timeout,
            )
        except requests.RequestException as exception:
            _logger.warning("Driver vehicle API connection failed: %s", type(exception).__name__)
            raise DriverVehicleApiError("Không thể kết nối IntegrationHub để tìm thông tin tài xế.") from exception
        if response.status_code == 404:
            return None
        if not response.ok:
            _logger.warning("Driver vehicle API returned HTTP %s", response.status_code)
            raise DriverVehicleApiError(f"Không lấy được thông tin tài xế (HTTP {response.status_code}).")
        try:
            payload = response.json()
        except ValueError as exception:
            raise DriverVehicleApiError("IntegrationHub trả về thông tin tài xế không hợp lệ.") from exception
        if not isinstance(payload, dict):
            raise DriverVehicleApiError("IntegrationHub trả về thông tin tài xế không hợp lệ.")
        return {
            "driver_name": str(payload.get("driverName") or "").strip(),
            "vehicle_number": str(payload.get("vehicleNumber") or "").strip(),
            "barge_number": str(payload.get("bargeNumber") or "").strip(),
        }

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
                raise DriverVehicleApiError("Không thể xác thực IntegrationHub để tìm tài xế.") from exception
            if not response.ok:
                raise DriverVehicleApiError("IntegrationHub chưa cấp quyền master.read để tìm tài xế.")
            try:
                payload = response.json()
                token = payload["access_token"]
                expires_in = int(payload.get("expires_in", 1800))
            except (ValueError, KeyError, TypeError) as exception:
                raise DriverVehicleApiError("Token IntegrationHub không hợp lệ.") from exception
            if not isinstance(token, str) or not token:
                raise DriverVehicleApiError("Token IntegrationHub không hợp lệ.")
            self._token_cache[cache_key] = (token, now + max(1, expires_in - 60))
            return token
