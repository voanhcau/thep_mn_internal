from odoo import fields, models


class iwmn_r81dmbarems(models.Model):
    """Rebar weight master data from legacy MSSQL table dbo.R81DMBAREMS."""

    _inherit = "iwmn.r81dmbarems"
    _rec_name = "ma_size"
    _order = "ma_size, grade_id, id"

    ma_size = fields.Char(
        string="Mã kích thước",
        size=20,
        required=True,
        index=True,
    )
    grade_id = fields.Char(
        string="Mác thép",
        size=20,
        required=True,
        index=True,
    )
    bar_weight = fields.Float(
        string="Trọng lượng thanh",
        digits=(19, 4),
        required=True,
    )
    create_log = fields.Char(
        string="Create Log",
        size=35,
    )
    lastmodify_log = fields.Char(
        string="Last Modify Log",
        size=35,
    )
    ident00 = fields.Integer(
        string="Ident00",
        index=True,
        copy=False,
        help="ID của bản ghi tương ứng trong bảng MSSQL dbo.R81DMBAREMS.",
    )
    barem_qd_min = fields.Float(
        string="Barem QĐ min",
        digits=(19, 4),
        required=True,
    )
    barem_qd_max = fields.Float(
        string="Barem QĐ max",
        digits=(19, 4),
        required=True,
    )
    barem_qd_tb = fields.Float(
        string="Barem QĐ trung bình",
        digits=(19, 4),
        required=True,
    )
    barem_tc_min = fields.Float(
        string="Barem TC min",
        digits=(19, 4),
        required=True,
    )
    barem_tc_max = fields.Float(
        string="Barem TC max",
        digits=(19, 4),
        required=True,
    )
    barem_tc_tb = fields.Float(
        string="Barem TC trung bình",
        digits=(19, 4),
        required=True,
    )
    barem_kg = fields.Float(
        string="Barem kg",
        digits=(19, 4),
        required=True,
    )
