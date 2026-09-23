from odoo import fields, models


class ResConfigSettings(models.TransientModel):
    _inherit = "res.config.settings"

    iwmn_sync_api_url = fields.Char(
        string="Địa chỉ IntegrationHub",
        config_parameter="iwmn_sync_system.api_url",
        help="Ví dụ: http://localhost:9119 hoặc https://api.company.vn.",
    )
    iwmn_sync_api_client_id = fields.Char(
        string="Client ID",
        config_parameter="iwmn_sync_system.client_id",
    )
    iwmn_sync_api_client_secret = fields.Char(
        string="Client secret",
        config_parameter="iwmn_sync_system.client_secret",
    )
    iwmn_sync_api_timeout = fields.Integer(
        string="Thời gian chờ (giây)",
        config_parameter="iwmn_sync_system.timeout",
        default=60,
    )

