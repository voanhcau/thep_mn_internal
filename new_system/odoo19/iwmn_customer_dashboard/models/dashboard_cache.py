from psycopg2 import IntegrityError

from odoo import api, fields, models


class IwmnCustomerCreditDashboardCache(models.Model):
    _name = "iwmn.customer.credit.dashboard.cache"
    _description = "Cache dashboard hạn mức khách hàng"
    _order = "report_date desc, id desc"

    erp_partner_id = fields.Many2one(
        "iwmn.r81dmdt",
        string="Khách hàng ERP",
        required=True,
        index=True,
        ondelete="cascade",
    )
    partner_code = fields.Char(string="Mã khách hàng ERP", required=True, index=True)
    report_date = fields.Date(string="Ngày báo cáo", required=True, index=True)
    summary_json = fields.Json(string="Dữ liệu hạn mức", required=True)
    fetched_at = fields.Datetime(
        string="Thời điểm lấy từ IntegrationHub",
        required=True,
        default=fields.Datetime.now,
    )

    _partner_report_date_unique = models.Constraint(
        "UNIQUE(erp_partner_id, report_date)",
        "Mỗi khách hàng chỉ có một cache dashboard trong một ngày báo cáo.",
    )

    @api.model
    def get_for(self, erp_partner, report_date):
        return self.search([
            ("erp_partner_id", "=", erp_partner.id),
            ("report_date", "=", report_date),
        ], limit=1)

    @api.model
    def store_summary(self, erp_partner, report_date, summary):
        values = {
            "erp_partner_id": erp_partner.id,
            "partner_code": erp_partner.ma_dt,
            "report_date": report_date,
            "summary_json": summary,
            "fetched_at": fields.Datetime.now(),
        }
        cache = self.get_for(erp_partner, report_date)
        if cache:
            cache.write(values)
            return cache

        # Two contacts of the same ERP customer can open the dashboard at the
        # same time. Keep the unique key and recover from that harmless race.
        try:
            with self.env.cr.savepoint():
                return self.create(values)
        except IntegrityError:
            cache = self.get_for(erp_partner, report_date)
            cache.write(values)
            return cache
