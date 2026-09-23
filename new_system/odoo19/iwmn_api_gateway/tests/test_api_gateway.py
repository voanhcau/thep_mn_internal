from odoo.exceptions import AccessError, ValidationError
from odoo.tests import tagged
from odoo.tests.common import TransactionCase, new_test_user


@tagged("post_install", "-at_install")
class TestIwmnApiGateway(TransactionCase):
    @classmethod
    def setUpClass(cls):
        super().setUpClass()
        cls.target_user = new_test_user(
            cls.env,
            login="iwmn_gateway_target",
            groups="base.group_user",
        )
        cls.service_user = new_test_user(
            cls.env,
            login="iwmn_gateway_service",
            groups="base.group_user,iwmn_api_gateway.group_api_gateway_caller",
        )
        cls.gateway = cls.env["iwmn.api.gateway"].with_user(cls.service_user)

    def test_create_returns_new_id_and_audits_target_user(self):
        result = self.gateway.call_as_user(
            model="res.partner",
            method="create",
            user_id=self.target_user.id,
            vals={"name": "Created through IWMN gateway"},
        )

        self.assertIsInstance(result["id"], int)
        self.assertEqual(result["ids"], [result["id"]])
        partner = self.env["res.partner"].browse(result["id"])
        self.assertEqual(partner.create_uid, self.target_user)

    def test_write_uses_target_user(self):
        partner = self.env["res.partner"].create({"name": "Before gateway"})

        result = self.gateway.call_as_user(
            model="res.partner",
            method="write",
            user_id=self.target_user.id,
            record_ids=[partner.id],
            vals={"name": "After gateway"},
        )

        self.assertTrue(result)
        self.assertEqual(partner.name, "After gateway")
        self.assertEqual(partner.write_uid, self.target_user)

    def test_requires_service_account_group(self):
        gateway = self.env["iwmn.api.gateway"].with_user(self.target_user)
        with self.assertRaises(AccessError):
            gateway.call_as_user(
                model="res.partner",
                method="search",
                user_id=self.target_user.id,
                kwargs={"domain": []},
            )

    def test_blocks_environment_escalation_methods(self):
        with self.assertRaises(ValidationError):
            self.gateway.call_as_user(
                model="res.partner",
                method="sudo",
                user_id=self.target_user.id,
            )
