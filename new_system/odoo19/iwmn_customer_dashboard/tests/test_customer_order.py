from decimal import Decimal
from unittest.mock import Mock, patch

from odoo import fields
from odoo.exceptions import ValidationError
from odoo.tests.common import TransactionCase

from ..controllers.portal import (
    _apply_order_shape_change,
    _calculate_barem_weights,
    _contract_search_domain,
    _customer_order_domain,
    _format_identity,
    _normalize_size_term,
    _normalize_bar_entry,
    _number,
    _product_search_domain,
    _product_type_for_product,
    _project_label,
    _project_search_domain,
    _project_appendix_label,
    _project_appendix_search_domain,
    _quick_product_options,
    _quick_grade_options,
    _quick_length_options,
    _resolve_erp_partner,
    _warehouse_label,
    _warehouse_search_domain,
)
from ..services.order_sync import build_r04ctdh_rows
from ..services.bar_weight_api import BarWeightApiService


class TestCustomerPortalOrder(TransactionCase):
    def test_default_length_is_first_then_remaining_lengths_ascending(self):
        products = Mock()
        products.search.return_value = [
            Mock(length=12.0, is_default=False),
            Mock(length=6.0, is_default=False),
            Mock(length=11.7, is_default=True),
            Mock(length=9.0, is_default=False),
            Mock(length=11.7, is_default=False),
        ]
        domain = [("ma_size", "=ilike", "D10"), ("grade_id", "=ilike", "G01")]
        self.assertEqual(_quick_length_options(products, domain, ""), ["11.7", "6", "9", "12"])
        self.assertEqual(_quick_length_options(products, domain, "1"), ["11.7", "12"])
        products.search.assert_called_with(domain)

    def test_product_type_uses_size_and_bundle_count(self):
        self.assertEqual(_product_type_for_product(Mock(ma_size="R06", num_bars=0)), "coil")
        self.assertEqual(_product_type_for_product(Mock(ma_size=" r10 ", num_bars=0)), "coil")
        self.assertEqual(_product_type_for_product(Mock(ma_size="R06", num_bars=200)), "bar")
        self.assertEqual(_product_type_for_product(Mock(ma_size="D10", num_bars=0)), "bar")
        self.assertEqual(_product_type_for_product(Mock(ma_size="V253", num_bars=0)), "bar")

    def test_grade_choices_search_code_and_name_with_size_filter(self):
        products = Mock()
        products.read_group.return_value = [{"grade_id": "G01"}, {"grade_id": "G02"}]
        grades = Mock()
        grades.search.return_value = [
            Mock(grade_id="G01", grade_name="CB300-V"),
            Mock(grade_id="G02", grade_name="CB 400-V"),
        ]
        domain = [("ma_nh_vt", "=", "THEPCANDAI"), ("ma_size", "=ilike", "D10")]
        self.assertEqual(_quick_grade_options(products, grades, domain, "CB 400"), [
            {"code": "G02", "name": "CB 400-V"},
        ])
        self.assertEqual(_quick_grade_options(products, grades, domain, "g01"), [
            {"code": "G01", "name": "CB300-V"},
        ])
        products.read_group.assert_called_with(domain, ["grade_id"], ["grade_id"], lazy=False)

    def test_quick_product_options_filter_size_and_length(self):
        model = Mock()
        model.read_group.return_value = [
            {"ma_size": "D10"}, {"ma_size": "D12"}, {"ma_size": "D100"},
            {"ma_size": "R06"}, {"ma_size": "V253"},
            {"ma_size": "XX"}, {"ma_size": "X"}, {"ma_size": "LONGSIZE"},
        ]
        self.assertEqual(_quick_product_options(model, [], "ma_size", ""), ["D10", "D100", "D12", "LONGSIZE", "R06", "V253", "X", "XX"])
        self.assertEqual(_quick_product_options(model, [], "ma_size", "D"), ["D10", "D100", "D12"])
        self.assertEqual(_quick_product_options(model, [], "ma_size", "D1"), ["D10", "D100", "D12"])
        self.assertEqual(_quick_product_options(model, [], "ma_size", "LONG"), ["LONGSIZE"])
        self.assertEqual(_normalize_size_term("10d"), "D10")
        self.assertEqual(_normalize_size_term("06r"), "R06")
        self.assertEqual(_normalize_size_term("253v"), "V253")
        self.assertEqual(_quick_product_options(model, [], "ma_size", "10d"), ["D10"])
        self.assertEqual(_quick_product_options(model, [], "ma_size", "06r"), ["R06"])
        self.assertEqual(_quick_product_options(model, [], "ma_size", "253v"), ["V253"])
        model.read_group.return_value = [{"length": 0.0}, {"length": 11.7}, {"length": 12.0}]
        self.assertEqual(_quick_product_options(model, [], "length", "0"), ["0"])
        self.assertEqual(_quick_product_options(model, [], "length", "11"), ["11.7"])

    def test_quick_product_grouping_uses_erp_catalog(self):
        products = self.env["iwmn.r81dmvt"].sudo()
        domain = [("ma_nh_vt", "=", "THEPCANDAI")]
        self.assertIsInstance(_quick_product_options(products, domain, "ma_size", ""), list)
        self.assertIsInstance(_quick_product_options(products, domain, "grade_id", ""), list)
        self.assertIsInstance(_quick_product_options(products, domain, "length", ""), list)
        if products.search_count(domain + [("length", "=", 0)]):
            self.assertIn("0", _quick_product_options(products, domain, "length", "0"))
        if products.search_count(domain + [("ma_size", "=ilike", "D10")]):
            self.assertEqual(_quick_product_options(products, domain, "ma_size", "10d"), ["D10"])
            d10_domain = domain + [("ma_size", "=ilike", "D10")]
            if products.search_count(d10_domain + [("grade_id", "=ilike", "G01")]):
                choices = _quick_grade_options(
                    products, self.env["iwmn.r81dmmacthep"].sudo(), d10_domain, "CB300",
                )
                self.assertTrue(any(choice["code"] == "G01" for choice in choices))

    def test_loose_bars_are_carried_into_bundles(self):
        self.assertEqual(_normalize_bar_entry("1", "721", 350), (3, 21, 1071))
        self.assertEqual(_normalize_bar_entry("0", "350", 350), (1, 0, 350))
        self.assertEqual(_normalize_bar_entry("2", "349", 350), (2, 349, 1049))
        with self.assertRaises(ValueError):
            _normalize_bar_entry("-1", "0", 350)
        with self.assertRaises(ValueError):
            _normalize_bar_entry("0", "1.5", 350)

    def test_weight_api_passes_product_and_quantities_to_integrationhub(self):
        service = BarWeightApiService(self.env)
        service.base_url = "https://integration.example.test"
        service.client_id = "test-client"
        service.client_secret = "test-secret"
        response = Mock(ok=True)
        response.json.return_value = {"weightKg": 123.6}
        with patch.object(service, "_get_access_token", return_value="test-token"), \
                patch("odoo.addons.iwmn_customer_dashboard.services.bar_weight_api.requests.get", return_value=response) as get:
            weight = service.calculate("BD10020680", 1, 2)
        self.assertEqual(weight, Decimal("123.6"))
        self.assertEqual(get.call_args.kwargs["params"], {
            "ma_vt": "BD10020680", "so_bo": 1, "so_cay_le": 2,
        })

    def test_erp_bar_uses_api_weight_not_local_barem(self):
        product = self.env["iwmn.r81dmvt"].search([
            ("ma_nh_vt", "=", "THEPCANDAI"), ("ma_vt", "=like", "BD%"),
            ("num_bars", ">", 0),
        ], limit=1)
        if not product:
            self.skipTest("Chưa có vật tư thép cây ERP để kiểm tra API barem.")
        with patch("odoo.addons.iwmn_customer_dashboard.models.customer_order.BarWeightApiService.calculate", return_value=Decimal("123.6")) as calculate:
            order = self._create_order(line_ids=[(0, 0, {
                "product_id": product.id,
                "product_query": product.ma_vt,
                "product_type": "bar",
                "total_bar_qty": product.num_bars + 2,
                "bars_per_bundle": product.num_bars,
            })])
        self.assertEqual(order.line_ids.weight_kg, 124)
        calculate.assert_called_with(product.ma_vt, 1, 2)

    def test_warehouse_search_matches_code_or_name(self):
        self.assertEqual(
            _warehouse_search_domain("  KH001  ", "  KHO  "),
            [
                ("ma_dt", "=", "KH001"),
                "|", ("ma_kho", "ilike", "KHO"), ("ten_kho", "ilike", "KHO"),
            ],
        )
        self.assertEqual(_warehouse_search_domain("KH001", ""), [("ma_dt", "=", "KH001")])
        self.assertEqual(_warehouse_search_domain("", "KHO"), [("id", "=", 0)])

    def test_project_search_matches_code_or_name(self):
        self.assertEqual(_project_search_domain("  CT01  "), [
            "|",
            ("ma_ctrinh", "ilike", "CT01"),
            ("ten_ctrinh", "ilike", "CT01"),
        ])
        self.assertEqual(_project_search_domain(""), [])

    def test_project_appendix_search_is_limited_to_selected_project(self):
        self.assertEqual(_project_appendix_search_domain("  CT01  ", "  PL01  "), [
            ("ma_ctrinh", "=", "CT01"),
            "|",
            ("ma_plctrinh", "ilike", "PL01"),
            ("ten_plctrinh", "ilike", "PL01"),
        ])
        self.assertEqual(
            _project_appendix_search_domain("CT01", ""),
            [("ma_ctrinh", "=", "CT01")],
        )
        self.assertEqual(_project_appendix_search_domain("", "PL01"), [("id", "=", 0)])

    def test_order_stores_selected_project_appendix_and_syncs_its_code(self):
        project_appendix = self.env["iwmn.r81dmplctrinh"].search([], limit=1)
        if not project_appendix:
            self.skipTest("Không có phụ lục công trình ERP trong dữ liệu kiểm thử")
        project = self.env["iwmn.r81dmctrinh"].search([
            ("ma_ctrinh", "=", project_appendix.ma_ctrinh),
        ], limit=1)
        if not project:
            self.skipTest("Không có công trình ERP tương ứng với phụ lục trong dữ liệu kiểm thử")
        order = self._create_order(
            r81dmctrinh_id=project.id,
            r81dmplctrinh_id=project_appendix.id,
            project_code=project.ma_ctrinh,
            project_name=project.ten_ctrinh,
            subproject_code=project_appendix.ma_plctrinh,
            subproject_name=project_appendix.ten_plctrinh,
        )
        self.assertEqual(order.r81dmctrinh_id, project)
        self.assertEqual(order.r81dmplctrinh_id, project_appendix)
        self.assertIn(project.ma_ctrinh, _project_label(project))
        self.assertIn(project_appendix.ma_plctrinh, _project_appendix_label(project_appendix))
        self.assertEqual(build_r04ctdh_rows(order)[0]["maPlCtrinh"], project_appendix.ma_plctrinh)

    def test_consignment_order_stores_warehouse_code_and_reference(self):
        warehouse = self.env["iwmn.r81dmkho"].search([], limit=1)
        if not warehouse:
            self.skipTest("Không có kho ERP trong dữ liệu kiểm thử")
        order = self._create_order(
            delivery_type="KG", ma_kho=warehouse.ma_kho, r81dmkho_id=warehouse.id,
        )
        self.assertEqual(order.ma_kho, warehouse.ma_kho)
        self.assertEqual(order.r81dmkho_id, warehouse)
        self.assertIn(warehouse.ma_kho, _warehouse_label(warehouse))

    def _create_order(self, **extra):
        values = {
            "partner_id": self.env.user.partner_id.commercial_partner_id.id,
            "portal_user_id": self.env.user.id,
            "customer_reference": "PO-ORDER-001",
            "delivery_area": "phu_my",
            "transport_method": "xe",
            "vehicle_license_plate": "51C-963.87",
            "vehicle_driver_name": "Nguyễn Văn A",
            "vehicle_driver_identity": "087.096.015.286",
            "line_ids": [(0, 0, {
                "product_query": "BD10 CB300-V",
                "product_type": "bar",
                "total_bar_qty": 721,
                "bars_per_bundle": 350,
                "bar_weight_kg": 6.93,
                "bundle_weight_kg": 2426,
            })],
        }
        values.update(extra)
        return self.env["iwmn.customer.order"].create(values)

    def test_bar_quantity_is_converted_to_bundles_loose_bars_and_kg(self):
        order = self._create_order()
        line = order.line_ids

        self.assertTrue(order.name.startswith("WEB/"))
        self.assertEqual(line.bundle_qty, 2)
        self.assertEqual(line.loose_bar_qty, 21)
        self.assertEqual(line.weight_kg, 2 * 2426 + 146)

        order.action_submit()
        self.assertEqual(order.state, "waiting_confirmation")
        self.assertTrue(order.submitted_at)
        self.assertEqual(order.legacy_sync_state, "pending")

    def test_r04ctdh_payload_maps_header_line_and_shape(self):
        order = self._create_order(
            customer_reference="PO-SYNC-001", cnxx_show_project=True, so_luong_cnxx=2,
            vehicle_driver_name="Tài xế A", vehicle_driver_identity="087.096.015.286",
            transport_method="xe",
        )
        row = build_r04ctdh_rows(order)[0]
        self.assertEqual(row["idWebHeader"], order.id)
        self.assertEqual(row["idWebDetail"], order.line_ids.id)
        self.assertEqual(row["soDh"], "PO-SYNC-001")
        self.assertEqual(row["soXe"], "51C-963.87")
        self.assertEqual(row["ptVc"], "xe")
        self.assertEqual(row["htTt"], "tra_cham_40")
        self.assertEqual((row["soLuongBo"], row["soLuongCayLe"], row["soLuongCay"]), (2, 21, 721))
        self.assertEqual(row["soLuong"], 4998)
        self.assertEqual((row["boBe"], row["boThang"]), ("true", "false"))
        self.assertTrue(row["isCnxx"])
        self.assertEqual(row["soLuongCnxx"], 2)

    def test_payment_method_defaults_to_40_day_credit_and_supports_deferred(self):
        default_order = self._create_order(customer_reference="PO-PAYMENT-DEFAULT")
        self.assertEqual(default_order.payment_method, "tra_cham_40")
        self.assertEqual(default_order.payment_method_label, "Trả chậm 40 ngày")

        deferred_order = self._create_order(
            customer_reference="PO-PAYMENT-DEFERRED", payment_method="tra_cham",
        )
        self.assertEqual(deferred_order.payment_method_label, "Trả chậm")
        self.assertEqual(build_r04ctdh_rows(deferred_order)[0]["htTt"], "tra_cham")

    def test_coil_uses_requested_kg_only(self):
        order = self._create_order(
            customer_reference="PO-ORDER-002",
            line_ids=[(0, 0, {
                "product_query": "BR08 CB240-T",
                "product_type": "coil",
                "requested_weight_kg": 2400,
                "coil_cut_qty": 3,
            })],
        )
        self.assertEqual(order.total_weight_kg, 2400.0)
        self.assertEqual(order.line_ids.coil_cut_qty, 3)
        self.assertEqual(order.line_ids.bundle_qty, 0)

    def test_product_weight_is_rounded_to_whole_kg(self):
        order = self._create_order(
            line_ids=[(0, 0, {
                "product_query": "BD10 CB300-V",
                "product_type": "bar",
                "total_bar_qty": 351,
                "bars_per_bundle": 350,
                "bar_weight_kg": 6.93,
                "bundle_weight_kg": 2426.5,
            }), (0, 0, {
                "product_query": "BR08 CB240-T",
                "product_type": "coil",
                "requested_weight_kg": 10.5,
                "coil_cut_qty": 1,
            })],
        )
        self.assertEqual(order.line_ids[0].weight_kg, 2434)
        self.assertEqual(order.line_ids[1].weight_kg, 11)
        self.assertEqual(order.total_weight_kg, 2445)

    def test_sql_barem_uses_product_num_bars_and_length_branch(self):
        standard = _calculate_barem_weights(6.93, 2426, 11.7, 350)
        self.assertEqual(standard, {
            "bar_weight_kg": 6.93, "bundle_weight_kg": 2426, "bars_per_bundle": 350,
        })
        short = _calculate_barem_weights(6.93, 2426, 6.0, 350)
        self.assertEqual(short, {
            "bar_weight_kg": 3.5538, "bundle_weight_kg": 1244.0, "bars_per_bundle": 350,
        })

    def test_bar_bundle_entry_keeps_total_bars_and_sql_rounding(self):
        order = self._create_order(
            line_ids=[(0, 0, {
                "product_query": "BD10 CB300-V",
                "product_type": "bar",
                "bar_input_mode": "bundles",
                "total_bar_qty": 351,
                "bars_per_bundle": 350,
                "bar_weight_kg": 6.93,
                "bundle_weight_kg": 2426,
            })],
        )
        self.assertEqual(order.line_ids.bar_input_mode, "bundles")
        self.assertEqual((order.line_ids.bundle_qty, order.line_ids.loose_bar_qty), (1, 1))
        self.assertEqual(order.line_ids.weight_kg, 2433)

    def test_transport_requires_matching_vehicle_number_on_submit(self):
        order = self._create_order(
            customer_reference="PO-ORDER-003", transport_method="salan",
            vehicle_license_plate="51C-963.87", vehicle_barge_number=False,
        )
        with self.assertRaises(ValidationError):
            order.action_submit()

    def test_driver_information_is_single_source_and_phone_is_optional(self):
        order = self._create_order(vehicle_driver_phone=False)

        self.assertEqual(order.receiver_name, order.vehicle_driver_name)
        self.assertEqual(order.receiver_identity, order.vehicle_driver_identity)
        self.assertFalse(order.receiver_phone)
        order.action_submit()
        self.assertEqual(order.state, "waiting_confirmation")

    def test_order_contains_one_vehicle_and_lines_link_directly_to_order(self):
        order = self._create_order(
            customer_reference="PO-ORDER-VEHICLE",
            vehicle_license_plate="50H-123.45",
            vehicle_driver_phone="090 123 4567",
        )

        self.assertEqual(order.vehicle_license_plate, "50H-123.45")
        self.assertEqual(order.vehicle_driver_phone, "090 123 4567")
        self.assertEqual(order.line_ids.order_id, order)

    def test_cnxx_quantity_is_stored_on_order_and_cannot_be_negative(self):
        order = self._create_order(
            customer_reference="PO-ORDER-CNXX", so_luong_cnxx=3,
        )
        self.assertEqual(order.so_luong_cnxx, 3)
        with self.assertRaises(ValidationError):
            order.so_luong_cnxx = -1

    def test_order_shape_change_synchronizes_uniform_lines_without_confirmation(self):
        commands = [(0, 0, {"steel_shape": "straight"}), (0, 0, {"steel_shape": "straight"})]
        error = _apply_order_shape_change(commands, "bent", "straight", ["straight", "straight"])
        self.assertIsNone(error)
        self.assertEqual([values["steel_shape"] for _, _, values in commands], ["bent", "bent"])

    def test_order_shape_change_requires_confirmation_for_mixed_lines(self):
        commands = [(0, 0, {"steel_shape": "straight"}), (0, 0, {"steel_shape": "bent"})]
        error = _apply_order_shape_change(commands, "bent", "mixed", ["straight", "bent"])
        self.assertTrue(error)
        self.assertEqual([values["steel_shape"] for _, _, values in commands], ["straight", "bent"])
        self.assertIsNone(_apply_order_shape_change(commands, "bent", "mixed", ["straight", "bent"], True))
        self.assertEqual([values["steel_shape"] for _, _, values in commands], ["bent", "bent"])

    def test_mixed_order_shape_keeps_existing_line_shapes(self):
        commands = [(0, 0, {"steel_shape": "straight"}), (0, 0, {"steel_shape": "bent"})]
        self.assertIsNone(_apply_order_shape_change(commands, "mixed", "straight", ["straight", "bent"]))
        self.assertEqual([values["steel_shape"] for _, _, values in commands], ["straight", "bent"])

    def test_customer_can_cancel_until_vehicle_exits_gate(self):
        order = self._create_order(customer_reference="PO-ORDER-004")
        order.action_cancel_by_customer("Không còn nhu cầu")
        self.assertEqual(order.state, "cancelled")

        locked_order = self._create_order(customer_reference="PO-ORDER-005", gate_state="exited")
        with self.assertRaises(ValidationError):
            locked_order.action_cancel_by_customer()

    def test_internal_warehouse_allocation_must_match_delivery_area(self):
        order = self._create_order(
            customer_reference="PO-ORDER-007", assigned_warehouse_codes="04TP, 552TMN_TD"
        )
        self.assertIn("04TP", order.allowed_warehouse_codes)
        with self.assertRaises(ValidationError):
            order.assigned_warehouse_codes = "051CT"

    def test_invalid_identity_is_rejected(self):
        with self.assertRaises(ValidationError):
            self._create_order(customer_reference="PO-ORDER-006", vehicle_driver_identity="123")

    def test_portal_value_helpers(self):
        self.assertEqual(_format_identity("087096015286"), "087.096.015.286")
        self.assertEqual(_format_identity("123 456 789"), "123.456.789")
        self.assertEqual(_number("11,7"), 11.7)
        self.assertEqual(_number("not-a-number"), 0.0)

    def test_product_search_is_limited_to_long_steel_and_matches_code_or_name(self):
        self.assertEqual(
            _product_search_domain("D10"),
            [
                ("ma_nh_vt", "=", "THEPCANDAI"),
                "|", ("ma_vt", "ilike", "D10"), ("ten_vt", "ilike", "D10"),
            ],
        )

    def test_contract_search_is_limited_to_customer_and_current_validity(self):
        report_date = fields.Date.from_string("2026-08-27")
        domain = _contract_search_domain("1000001", report_date, "HD-01")

        self.assertEqual(domain[:3], [
            ("ma_dt", "=", "1000001"),
            ("ngay_hd_bd", "<=", report_date),
            ("ngay_hd_kt", ">=", report_date),
        ])
        self.assertIn(("ma_hd", "ilike", "HD-01"), domain)
        self.assertIn(("so_hd", "ilike", "HD-01"), domain)
        self.assertIn(("ten_hd", "ilike", "HD-01"), domain)

    def test_order_stores_selected_erp_contract_id(self):
        contract = self.env["iwmn.r81dmhd"].search([], limit=1)
        if not contract:
            self.skipTest("Chưa có hợp đồng ERP để kiểm tra liên kết.")
        order = self._create_order(
            customer_reference="PO-ORDER-CONTRACT",
            contract_number=contract.ma_hd,
            r81dmhd_id=contract.id,
        )
        self.assertEqual(order.r81dmhd_id, contract)

    def test_portal_order_domain_supports_user_company_tree_and_erp_customer(self):
        domain = _customer_order_domain(7, 12, 35)

        self.assertIn(("portal_user_id", "=", 7), domain)
        self.assertIn(("partner_id", "child_of", 12), domain)
        self.assertIn(("erp_partner_id", "=", 35), domain)

    def test_erp_customer_prefers_portal_contact_then_falls_back_to_company(self):
        class Partner:
            def __init__(self, erp_partner=None, commercial_partner=None):
                self.iwmn_credit_partner_id = erp_partner
                self.commercial_partner_id = commercial_partner or self

        company = Partner(erp_partner="company-erp")
        contact = Partner(erp_partner="contact-erp", commercial_partner=company)
        contact_without_mapping = Partner(commercial_partner=company)

        self.assertEqual(_resolve_erp_partner(contact), "contact-erp")
        self.assertEqual(_resolve_erp_partner(contact_without_mapping), "company-erp")

    def test_customer_controller_overrides_sale_order_routes(self):
        from ..controllers.portal import IwmnCustomerPortal

        self.assertTrue(hasattr(IwmnCustomerPortal, "portal_my_orders"))
        self.assertTrue(hasattr(IwmnCustomerPortal, "portal_order_page"))
