from datetime import date

from odoo.tests.common import TransactionCase

from ..controllers.portal import (
    CREDIT_DETAIL_TYPES,
    _credit_detail_total,
    _is_refresh_requested,
    _prepare_credit_detail_table,
    _prepare_dashboard,
    _select_customer_summary,
)


class TestCustomerCreditDashboard(TransactionCase):
    @staticmethod
    def _rows():
        return [
            {"partnerCode": "KH01", "sequence": 0, "content": "Nợ quá hạn", "amount": 100, "bold": True, "level": 1},
            {"partnerCode": "KH01", "sequence": 0, "content": "HD-QH", "amount": 100, "documentDate": "2026-09-01", "quantity": 25, "deliveryOrderQuantity": 24, "paymentMethod": "TC40", "deliveryOrderNumber": "LXH-QH", "bold": False, "level": 2},
            {"partnerCode": "KH01", "sequence": 1, "content": "Nợ trong hạn", "amount": 200, "bold": True, "level": 1},
            {"partnerCode": "KH01", "sequence": 1, "content": "HD-TH", "amount": 200, "documentDate": "2026-09-15", "bold": False, "level": 2},
            {"partnerCode": "KH01", "sequence": 2, "content": "Lệnh chờ duyệt", "amount": 50, "bold": True, "level": 1},
            {"partnerCode": "KH01", "sequence": 2, "content": "DH-01", "amount": 50, "warehouseCode": "04TP", "bargeNumber": "SG-01", "bold": False, "level": 2},
            {"partnerCode": "KH01", "sequence": 4, "content": "Hạn mức", "amount": 1_000, "bold": True, "level": 1},
            {"partnerCode": "KH01", "sequence": 4, "content": "Bảo lãnh", "amount": 400, "bold": False, "level": 2},
            {"partnerCode": "KH01", "sequence": 4, "content": "Tín chấp", "amount": 600, "bold": False, "level": 3},
            {"partnerCode": "KH01", "sequence": 5, "content": "Tiền mặt", "amount": -300, "bold": True, "level": 1},
            {"partnerCode": "KH01", "sequence": 5, "content": "Hóa đơn", "amount": 200, "bold": True, "level": 3},
            {"partnerCode": "KH01", "sequence": 5, "content": "HD-01", "amount": 200, "vehicleNumber": "51A-123", "bold": False, "level": 4},
            {"partnerCode": "KH01", "sequence": 5, "content": "Chờ giao", "amount": 100, "bold": True, "level": 5},
            {"partnerCode": "KH01", "sequence": 5, "content": "CG-01", "amount": 100, "bold": False, "level": 6},
            {"partnerCode": "KH01", "sequence": 5, "content": "PXK", "amount": 50, "bold": True, "level": 9},
            {"partnerCode": "KH01", "sequence": 5, "content": "PXK-01", "amount": 50, "bold": False, "level": 10},
            {"partnerCode": "KH01", "sequence": 5, "content": "Ký gửi", "amount": 25, "bold": True, "level": 11},
            {"partnerCode": "KH01", "sequence": 5, "content": "KG-01", "amount": 25, "bold": False, "level": 12},
        ]

    def test_refresh_query_parameter_is_explicit(self):
        self.assertTrue(_is_refresh_requested("1"))
        self.assertTrue(_is_refresh_requested("TRUE"))
        self.assertFalse(_is_refresh_requested(None))
        self.assertFalse(_is_refresh_requested("0"))

    def test_prepare_dashboard_uses_stt_bold_and_level_rows(self):
        dashboard = _prepare_dashboard(self._rows(), date(2026, 9, 22))

        self.assertEqual(dashboard["debt"]["total"], 300.0)
        self.assertEqual(dashboard["debt"]["overdue"], 100.0)
        self.assertEqual(dashboard["debt"]["not_due"], 200.0)
        self.assertEqual(dashboard["approval_payment"]["value"], 50.0)
        self.assertEqual(dashboard["approval_payment"]["key"], "pending-approvals")
        self.assertNotIn("pending_approvals", dashboard["debt"])
        self.assertEqual(
            [metric["key"] for metric in dashboard["debt"]["detail_metrics"]],
            ["not-due", "overdue"],
        )
        self.assertEqual(dashboard["debt"]["overdue_days_display"], 21)
        self.assertEqual(dashboard["limits"]["contractual_total"], 1_000.0)
        self.assertEqual(dashboard["limits"]["cash"], 300.0)
        self.assertEqual(dashboard["limits"]["used"], 375.0)
        self.assertEqual(dashboard["limits"]["remaining"], 925.0)
        self.assertAlmostEqual(dashboard["limits"]["used_percent"], 375 / 1300 * 100)
        self.assertEqual(dashboard["limits"]["usage_arc_start"], 0.0)
        self.assertAlmostEqual(
            dashboard["limits"]["usage_arc_end"],
            dashboard["limits"]["used_percent"] * 3.6,
        )
        consigned = next(
            segment for segment in dashboard["limits"]["segments"]
            if segment["key"] == "consigned-goods"
        )
        self.assertAlmostEqual(
            dashboard["limits"]["usage_arc_end"], consigned["end"] * 3.6
        )
        self.assertFalse(dashboard["limits"]["is_exceeded"])

    def test_cash_is_displayed_positive_but_offsets_purchasing_capacity(self):
        dashboard = _prepare_dashboard(self._rows())

        cash_source = next(item for item in dashboard["limits"]["source_segments"] if item["key"] == "cash")
        self.assertEqual(cash_source["value"], 300.0)
        self.assertEqual(dashboard["limits"]["structure_total"], 1_300.0)

    def test_summary_keeps_all_rows_for_matching_customer(self):
        rows = self._rows() + [{"partnerCode": "OTHER", "sequence": 0, "amount": 999, "bold": True}]

        selected = _select_customer_summary(rows, " KH01 ")

        self.assertEqual(len(selected), len(self._rows()))
        self.assertTrue(all(row["partnerCode"] == "KH01" for row in selected))

    def test_prepare_credit_detail_table_uses_requested_thumbnail_fields(self):
        table = _prepare_credit_detail_table(self._rows(), CREDIT_DETAIL_TYPES["invoices"])

        self.assertEqual(len(table["rows"]), 1)
        self.assertEqual(table["rows"][0]["title"], "HD-01")
        visible = {cell["key"]: cell["value"] for cell in table["rows"][0]["cells"] if cell["visible"]}
        icons = {cell["key"]: cell["icon"] for cell in table["rows"][0]["cells"]}
        self.assertEqual(visible["amount"], 200.0)
        self.assertEqual(visible["vehicleNumber"], "51A-123")
        self.assertEqual(icons["amount"], "fa-money")
        self.assertEqual(icons["quantity"], "fa-balance-scale")
        self.assertEqual(icons["vehicleNumber"], "fa-truck")

    def test_detail_hides_payment_and_duplicate_lxh_and_resolves_warehouse_name(self):
        table = _prepare_credit_detail_table(
            self._rows(),
            CREDIT_DETAIL_TYPES["pending-approvals"],
            {"04tp": "Kho thành phẩm"},
        )

        row = table["rows"][0]
        cells = {cell["key"]: cell for cell in row["cells"]}
        self.assertNotIn("paymentMethod", cells)
        self.assertNotIn("deliveryOrderNumber", cells)
        self.assertEqual(cells["warehouseCode"]["label"], "Tên kho")
        self.assertEqual(cells["warehouseCode"]["value"], "Kho thành phẩm")
        self.assertTrue(cells["bargeNumber"]["visible"])
        self.assertEqual(cells["bargeNumber"]["value"], "SG-01")

    def test_credit_detail_totals_match_dashboard_cards(self):
        rows = self._rows()

        self.assertEqual(_credit_detail_total(rows, "overdue"), 100.0)
        self.assertEqual(_credit_detail_total(rows, "not-due"), 200.0)
        self.assertEqual(_credit_detail_total(rows, "pending-approvals"), 50.0)
        self.assertEqual(_credit_detail_total(rows, "invoices"), 200.0)
        self.assertEqual(_credit_detail_total(rows, "approved-deliveries"), 100.0)
        self.assertEqual(_credit_detail_total(rows, "warehouse-issues"), 50.0)
        self.assertEqual(_credit_detail_total(rows, "consigned-goods"), 25.0)
