import logging
import threading
import time
from urllib.parse import urlparse

import requests

from odoo import _, api, fields, models
from odoo.exceptions import UserError, ValidationError


_logger = logging.getLogger(__name__)


class IntegrationHubSyncError(Exception):
    """An integration error that is safe to show without leaking credentials."""


class IntegrationHubMasterClient:
    _token_cache = {}
    _token_lock = threading.Lock()

    def __init__(self, env):
        parameters = env["ir.config_parameter"].sudo()
        self.base_url = (parameters.get_param("iwmn_sync_system.api_url") or "").rstrip("/")
        self.client_id = parameters.get_param("iwmn_sync_system.client_id") or ""
        self.client_secret = parameters.get_param("iwmn_sync_system.client_secret") or ""
        try:
            configured_timeout = int(parameters.get_param("iwmn_sync_system.timeout") or 60)
            self.timeout = min(max(configured_timeout, 3), 300)
        except (TypeError, ValueError):
            self.timeout = 60
        self._validate_configuration()

    def get_page(self, entity, page, page_size):
        token = self._get_access_token()
        response = self._request_page(token, entity, page, page_size)
        if response.status_code == 401:
            self._invalidate_token()
            response = self._request_page(
                self._get_access_token(), entity, page, page_size
            )

        if response.status_code == 403:
            raise IntegrationHubSyncError(
                _("Client IntegrationHub chưa được cấp scope master.read.")
            )
        if not response.ok:
            _logger.warning(
                "Master sync API returned HTTP %s for entity %s page %s",
                response.status_code,
                entity,
                page,
            )
            raise IntegrationHubSyncError(
                _("IntegrationHub không thể cung cấp dữ liệu master đã chọn.")
            )

        try:
            payload = response.json()
        except ValueError as exception:
            raise IntegrationHubSyncError(
                _("IntegrationHub trả về JSON không hợp lệ.")
            ) from exception

        if not isinstance(payload, dict) or not isinstance(payload.get("data"), list):
            raise IntegrationHubSyncError(
                _("Cấu trúc response master-data không hợp lệ.")
            )
        if payload.get("entity") != entity:
            raise IntegrationHubSyncError(
                _("Entity trong response không khớp yêu cầu đồng bộ.")
            )
        key_fields = payload.get("keyFields")
        if not isinstance(key_fields, list) or not key_fields:
            raise IntegrationHubSyncError(
                _("IntegrationHub không trả về khóa chính của master.")
            )
        return payload

    def _request_page(self, token, entity, page, page_size):
        try:
            return requests.get(
                f"{self.base_url}/api/v1/master-data/sync/{entity}",
                params={"page": page, "page_size": page_size},
                headers={
                    "Accept": "application/json",
                    "Authorization": f"Bearer {token}",
                },
                timeout=self.timeout,
            )
        except requests.RequestException as exception:
            _logger.warning(
                "Cannot reach IntegrationHub master-data endpoint: %s",
                type(exception).__name__,
            )
            raise IntegrationHubSyncError(
                _("Không thể kết nối IntegrationHub để lấy master-data.")
            ) from exception

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
                        "scope": "master.read",
                    },
                    headers={"Accept": "application/json"},
                    timeout=self.timeout,
                )
            except requests.RequestException as exception:
                _logger.warning(
                    "Cannot reach IntegrationHub token endpoint: %s",
                    type(exception).__name__,
                )
                raise IntegrationHubSyncError(
                    _("Không thể xác thực với IntegrationHub.")
                ) from exception

            if not response.ok:
                _logger.warning(
                    "IntegrationHub token endpoint returned HTTP %s",
                    response.status_code,
                )
                raise IntegrationHubSyncError(
                    _("Không thể lấy access token cho đồng bộ master-data.")
                )
            try:
                token_payload = response.json()
                token = token_payload["access_token"]
                expires_in = int(token_payload.get("expires_in", 1800))
            except (ValueError, KeyError, TypeError) as exception:
                raise IntegrationHubSyncError(
                    _("Phản hồi access token không hợp lệ.")
                ) from exception
            if not isinstance(token, str) or not token:
                raise IntegrationHubSyncError(
                    _("Phản hồi access token không hợp lệ.")
                )

            refresh_margin = min(60, max(10, expires_in // 10))
            self._token_cache[cache_key] = (
                token,
                now + max(1, expires_in - refresh_margin),
            )
            return token

    def _invalidate_token(self):
        self._token_cache.pop((self.base_url, self.client_id), None)

    def _validate_configuration(self):
        parsed = urlparse(self.base_url)
        if parsed.scheme not in ("http", "https") or not parsed.netloc:
            raise IntegrationHubSyncError(
                _("Chưa cấu hình địa chỉ IntegrationHub cho đồng bộ master-data.")
            )
        if not self.client_id or not self.client_secret:
            raise IntegrationHubSyncError(
                _("Chưa cấu hình Client ID/Client secret cho đồng bộ master-data.")
            )


class IwmnSyncSystem(models.Model):
    _name = "iwmn.sync.system"
    _description = "Đồng bộ master-data MSSQL sang Odoo"
    _order = "last_sync_at desc, id desc"

    name = fields.Char(string="Tên", required=True, default="Đồng bộ master-data")
    master_entity = fields.Selection(
        selection="_selection_master_entities",
        string="Đối tượng master",
        required=True,
    )
    target_model = fields.Char(
        string="Model Odoo",
        compute="_compute_target_model",
        store=True,
    )
    page_size = fields.Integer(string="Kích thước trang", required=True, default=500)
    state = fields.Selection(
        [
            ("draft", "Chưa đồng bộ"),
            ("running", "Đang đồng bộ"),
            ("success", "Thành công"),
            ("failed", "Thất bại"),
        ],
        string="Trạng thái",
        required=True,
        default="draft",
        readonly=True,
    )
    last_sync_at = fields.Datetime(string="Lần đồng bộ cuối", readonly=True)
    last_duration_seconds = fields.Float(string="Thời gian (giây)", readonly=True)
    fetched_count = fields.Integer(string="Đã nhận", readonly=True)
    created_count = fields.Integer(string="Đã tạo", readonly=True)
    updated_count = fields.Integer(string="Đã cập nhật", readonly=True)
    skipped_count = fields.Integer(string="Đã bỏ qua", readonly=True)
    last_error = fields.Text(string="Lỗi gần nhất", readonly=True)
    active = fields.Boolean(default=True)

    @api.model
    def _selection_master_entities(self):
        model_records = self.env["ir.model"].sudo().search(
            [("model", "=like", "iwmn.r81%")], order="model"
        )
        return [
            (record.model.removeprefix("iwmn."), record.model.removeprefix("iwmn.").upper())
            for record in model_records
        ]

    @api.depends("master_entity")
    def _compute_target_model(self):
        for record in self:
            record.target_model = (
                f"iwmn.{record.master_entity}" if record.master_entity else False
            )

    @api.onchange("master_entity")
    def _onchange_master_entity(self):
        if self.master_entity:
            self.name = _("Đồng bộ %s") % self.master_entity.upper()

    @api.constrains("page_size")
    def _check_page_size(self):
        for record in self:
            if record.page_size < 1 or record.page_size > 1000:
                raise ValidationError(_("Kích thước trang phải từ 1 đến 1000."))

    def action_sync(self):
        self.ensure_one()
        self.env.cr.execute(
            "SELECT pg_try_advisory_xact_lock(%s, %s)",
            (91819, self.id),
        )
        if not self.env.cr.fetchone()[0]:
            raise UserError(_("Một tiến trình khác đang đồng bộ đối tượng này."))
        if self.state == "running":
            raise UserError(_("Tiến trình đồng bộ này đang chạy."))
        if not self.master_entity or self.target_model not in self.env:
            raise UserError(_("Model Odoo tương ứng không tồn tại."))

        started_at = time.monotonic()
        self.write(
            {
                "state": "running",
                "fetched_count": 0,
                "created_count": 0,
                "updated_count": 0,
                "skipped_count": 0,
                "last_error": False,
            }
        )

        try:
            with self.env.cr.savepoint():
                counters = self._execute_sync()
        except (IntegrationHubSyncError, UserError, ValidationError) as exception:
            self.write(
                {
                    "state": "failed",
                    "last_sync_at": fields.Datetime.now(),
                    "last_duration_seconds": time.monotonic() - started_at,
                    "last_error": str(exception),
                }
            )
            return self._failure_notification(str(exception))
        except Exception as exception:
            _logger.exception("Unexpected master-data synchronization failure")
            self.write(
                {
                    "state": "failed",
                    "last_sync_at": fields.Datetime.now(),
                    "last_duration_seconds": time.monotonic() - started_at,
                    "last_error": _("Lỗi không xác định; xem Odoo server log."),
                }
            )
            return self._failure_notification(
                _("Đồng bộ thất bại; vui lòng kiểm tra Odoo server log.")
            )

        self.write(
            {
                "state": "success",
                "last_sync_at": fields.Datetime.now(),
                "last_duration_seconds": time.monotonic() - started_at,
                "last_error": False,
                **counters,
            }
        )
        return {
            "type": "ir.actions.client",
            "tag": "display_notification",
            "params": {
                "title": _("Đồng bộ hoàn tất"),
                "message": _("Nhận %(fetched)s, tạo %(created)s, cập nhật %(updated)s, bỏ qua %(skipped)s.")
                % {
                    "fetched": counters["fetched_count"],
                    "created": counters["created_count"],
                    "updated": counters["updated_count"],
                    "skipped": counters["skipped_count"],
                },
                "type": "success",
                "sticky": False,
                "next": {"type": "ir.actions.client", "tag": "reload"},
            },
        }

    @staticmethod
    def _failure_notification(message):
        return {
            "type": "ir.actions.client",
            "tag": "display_notification",
            "params": {
                "title": _("Đồng bộ thất bại"),
                "message": message,
                "type": "danger",
                "sticky": True,
                "next": {"type": "ir.actions.client", "tag": "reload"},
            },
        }

    def _execute_sync(self):
        client = IntegrationHubMasterClient(self.env)
        target = self.env[self.target_model].sudo()
        counters = {
            "fetched_count": 0,
            "created_count": 0,
            "updated_count": 0,
            "skipped_count": 0,
        }

        page = 1
        while True:
            if page > 100000:
                raise IntegrationHubSyncError(_("Vượt quá giới hạn số trang đồng bộ."))
            payload = client.get_page(self.master_entity, page, self.page_size)
            key_fields = payload["keyFields"]
            rows = payload["data"]
            page_counters = self._upsert_page(target, key_fields, rows)
            counters["fetched_count"] += len(rows)
            for field_name in ("created_count", "updated_count", "skipped_count"):
                counters[field_name] += page_counters[field_name]

            if not payload.get("hasMore"):
                break
            page += 1
        return counters

    def _upsert_page(self, target, key_fields, rows):
        protected_fields = {
            "id",
            "create_uid",
            "create_date",
            "write_uid",
            "write_date",
            "display_name",
            "__last_update",
        }
        unsupported_field_types = {"one2many", "many2many", "many2one"}
        for key_field in key_fields:
            if key_field in protected_fields or key_field not in target._fields:
                raise IntegrationHubSyncError(
                    _("Khóa nguồn '%s' không tồn tại trên model Odoo.") % key_field
                )

        created_values = []
        updated_count = 0
        skipped_count = 0

        existing_by_key = self._load_existing_records(target, key_fields, rows)
        for row in rows:
            if not isinstance(row, dict):
                raise IntegrationHubSyncError(_("Một dòng master-data không phải JSON object."))
            key = self._row_key(target, key_fields, row)
            if key is None:
                skipped_count += 1
                continue

            values = {}
            for field_name, value in row.items():
                field = target._fields.get(field_name)
                if (
                    not field
                    or field_name in protected_fields
                    or field.type in unsupported_field_types
                    or field.compute
                    or field.related
                ):
                    continue
                values[field_name] = self._convert_value(field, value)

            if not values:
                skipped_count += 1
                continue
            existing = existing_by_key.get(key)
            if existing:
                existing.write(values)
                updated_count += 1
            else:
                created_values.append(values)

        if created_values:
            target.create(created_values)
        return {
            "created_count": len(created_values),
            "updated_count": updated_count,
            "skipped_count": skipped_count,
        }

    def _load_existing_records(self, target, key_fields, rows):
        if len(key_fields) == 1:
            key_field = key_fields[0]
            field = target._fields[key_field]
            values = [
                self._convert_value(field, row.get(key_field))
                for row in rows
                if isinstance(row, dict) and row.get(key_field) is not None
            ]
            records = target.search([(key_field, "in", list(set(values)))]) if values else target.browse()
            result = {}
            for record in records:
                key = (record[key_field],)
                if key in result:
                    raise IntegrationHubSyncError(
                        _("Odoo có nhiều bản ghi trùng khóa %(field)s=%(value)s.")
                        % {"field": key_field, "value": record[key_field]}
                    )
                result[key] = record
            return result

        result = {}
        for row in rows:
            if not isinstance(row, dict):
                continue
            key = self._row_key(target, key_fields, row)
            if key is None or key in result:
                continue
            domain = list(zip(key_fields, ["="] * len(key_fields), key))
            records = target.search(domain, limit=2)
            if len(records) > 1:
                raise IntegrationHubSyncError(
                    _("Odoo có nhiều bản ghi trùng khóa ghép của master-data.")
                )
            if records:
                result[key] = records
        return result

    def _row_key(self, target, key_fields, row):
        values = []
        for key_field in key_fields:
            value = row.get(key_field)
            if value is None:
                return None
            values.append(self._convert_value(target._fields[key_field], value))
        return tuple(values)

    @staticmethod
    def _convert_value(field, value):
        if value is None:
            return False
        if field.type == "date":
            return fields.Date.to_date(str(value)[:10])
        if field.type == "datetime":
            text = str(value).replace("T", " ")
            return fields.Datetime.to_datetime(text[:19])
        if field.type == "boolean":
            return bool(value)
        if field.type == "integer":
            return int(value)
        if field.type in ("float", "monetary"):
            return float(value)
        if field.type in ("char", "selection"):
            return str(value).rstrip()
        if field.type in ("text", "html"):
            return str(value)
        return value
