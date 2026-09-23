from odoo import fields, models


class ResPartner(models.Model):
    _inherit = "res.partner"

    iwmn_credit_partner_id = fields.Many2one(
        "iwmn.r81dmdt",
        string="Khách hàng ERP (hạn mức)",
        help="Mã khách hàng này được dùng khi truy vấn hạn mức và dư nợ từ IntegrationHub.",
        index=True,
        ondelete="restrict",
    )

