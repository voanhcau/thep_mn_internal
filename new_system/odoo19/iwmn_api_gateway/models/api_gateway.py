import base64
import datetime
import re

from odoo import _, api, fields, models
from odoo.exceptions import AccessError, ValidationError


MODEL_NAME_PATTERN = re.compile(r"^[a-z][a-z0-9_.]*[a-z0-9]$")
METHOD_NAME_PATTERN = re.compile(r"^[A-Za-z][A-Za-z0-9_]*$")
BLOCKED_METHODS = {
    "browse",
    "sudo",
    "with_company",
    "with_context",
    "with_env",
    "with_prefetch",
    "with_user",
}
MAX_RECORD_IDS = 1000


class IwmnApiGateway(models.AbstractModel):
    _name = "iwmn.api.gateway"
    _description = "IWMN authenticated API gateway"

    @api.model
    def call_as_user(
        self,
        model,
        method,
        user_id,
        record_ids=None,
        vals=None,
        args=None,
        kwargs=None,
        context=None,
    ):
        """Call a public model method using the originating Odoo user's rights."""
        if not self.env.user.has_group("iwmn_api_gateway.group_api_gateway_caller"):
            raise AccessError(_("This account cannot use the IWMN API gateway."))

        model = self._validate_model(model)
        method = self._validate_method(method)
        user = self._get_active_user(user_id)
        record_ids = self._validate_record_ids(record_ids)
        args = self._validate_args(args)
        kwargs = self._validate_mapping(kwargs, "kwargs")
        context = self._validate_mapping(context, "context")

        if vals is not None and args:
            raise ValidationError(_("vals and args cannot be supplied together."))

        target = self.env[model].with_user(user)
        if context:
            target = target.with_context(**context)
        if record_ids is not None:
            target = target.browse(record_ids)

        if not hasattr(target, method):
            raise ValidationError(
                _("Method '%(method)s' does not exist on model '%(model)s'.")
                % {"method": method, "model": model}
            )

        method_args = list(args)
        if vals is not None:
            method_args.insert(0, vals)

        result = getattr(target, method)(*method_args, **kwargs)
        return self._to_json_value(result)

    @api.model
    def _validate_model(self, model):
        if not isinstance(model, str) or not MODEL_NAME_PATTERN.fullmatch(model):
            raise ValidationError(_("Invalid Odoo model name."))
        if model not in self.env:
            raise ValidationError(_("Odoo model '%s' does not exist.") % model)
        return model

    @api.model
    def _validate_method(self, method):
        if (
            not isinstance(method, str)
            or not METHOD_NAME_PATTERN.fullmatch(method)
            or method.startswith("_")
            or method in BLOCKED_METHODS
        ):
            raise ValidationError(_("Invalid or blocked Odoo method name."))
        return method

    @api.model
    def _get_active_user(self, user_id):
        if not isinstance(user_id, int) or isinstance(user_id, bool) or user_id <= 0:
            raise ValidationError(_("user_id must be a positive integer."))
        user = self.env["res.users"].sudo().browse(user_id).exists()
        if not user or not user.active:
            raise ValidationError(_("The requested Odoo user does not exist or is inactive."))
        return user

    @api.model
    def _validate_record_ids(self, record_ids):
        if record_ids is None:
            return None
        if (
            not isinstance(record_ids, list)
            or len(record_ids) > MAX_RECORD_IDS
            or any(
                not isinstance(record_id, int)
                or isinstance(record_id, bool)
                or record_id <= 0
                for record_id in record_ids
            )
        ):
            raise ValidationError(_("record_ids must contain at most 1000 positive IDs."))
        return record_ids

    @api.model
    def _validate_args(self, args):
        if args is None:
            return []
        if not isinstance(args, list):
            raise ValidationError(_("args must be an array."))
        return args

    @api.model
    def _validate_mapping(self, value, name):
        if value is None:
            return {}
        if not isinstance(value, dict):
            raise ValidationError(_("%s must be an object.") % name)
        return value

    @api.model
    def _to_json_value(self, value):
        if isinstance(value, models.BaseModel):
            ids = value.ids
            return {"id": ids[0] if len(ids) == 1 else None, "ids": ids}
        if isinstance(value, dict):
            return {str(key): self._to_json_value(item) for key, item in value.items()}
        if isinstance(value, (list, tuple, set)):
            return [self._to_json_value(item) for item in value]
        if isinstance(value, datetime.datetime):
            return fields.Datetime.to_string(value)
        if isinstance(value, datetime.date):
            return fields.Date.to_string(value)
        if isinstance(value, bytes):
            return base64.b64encode(value).decode("ascii")
        if value is None or isinstance(value, (bool, int, float, str)):
            return value
        raise ValidationError(
            _("Method result of type '%s' cannot be returned as JSON.")
            % type(value).__name__
        )
