from odoo import fields, models


class ResConfigSettings(models.TransientModel):
    _inherit = "res.config.settings"

    iwmn_credit_api_url = fields.Char(
        string="Địa chỉ IntegrationHub",
        config_parameter="iwmn_customer_dashboard.api_url",
        help="Ví dụ: https://api.company.vn (không bao gồm /api/v1).",
    )
    iwmn_credit_api_client_id = fields.Char(
        string="Client ID",
        config_parameter="iwmn_customer_dashboard.client_id",
    )
    iwmn_credit_api_client_secret = fields.Char(
        string="Client secret",
        config_parameter="iwmn_customer_dashboard.client_secret",
    )
    iwmn_credit_api_business_unit = fields.Char(
        string="Mã đơn vị cơ sở",
        config_parameter="iwmn_customer_dashboard.business_unit",
        default="A01",
    )
    iwmn_credit_api_timeout = fields.Integer(
        string="Thời gian chờ (giây)",
        config_parameter="iwmn_customer_dashboard.timeout",
        default=15,
    )

