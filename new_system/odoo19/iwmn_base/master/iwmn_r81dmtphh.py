from odoo import fields, models


class iwmn_r81dmtphh(models.Model):
    _inherit = "iwmn.r81dmtphh"
    _rec_name = "description"
    _order = "description, id"

    ma_tphh = fields.Char(
        string="Ma_TPHH",
        required=True,
        index=True,
        size=20,
    )

    description = fields.Char(
        string="Description",
        size=200,
    )

    grade_id = fields.Char(
        string="Grade_ID",
        required=True,
        index=True,
        size=20,
    )

    fe_min = fields.Float(
        string="Fe_Min",
        required=True,
        digits=(19, 4),
    )

    fe_max = fields.Float(
        string="Fe_Max",
        required=True,
        digits=(19, 4),
    )

    c_min = fields.Float(
        string="C_Min",
        required=True,
        digits=(19, 4),
    )

    c_max = fields.Float(
        string="C_Max",
        required=True,
        digits=(19, 4),
    )

    mn_min = fields.Float(
        string="Mn_Min",
        required=True,
        digits=(19, 4),
    )

    mn_max = fields.Float(
        string="Mn_Max",
        required=True,
        digits=(19, 4),
    )

    si_min = fields.Float(
        string="Si_Min",
        required=True,
        digits=(19, 4),
    )

    si_max = fields.Float(
        string="Si_Max",
        required=True,
        digits=(19, 4),
    )

    p_min = fields.Float(
        string="P_Min",
        required=True,
        digits=(19, 4),
    )

    p_max = fields.Float(
        string="P_Max",
        required=True,
        digits=(19, 4),
    )

    s_min = fields.Float(
        string="S_Min",
        required=True,
        digits=(19, 4),
    )

    s_max = fields.Float(
        string="S_Max",
        required=True,
        digits=(19, 4),
    )

    cr_min = fields.Float(
        string="Cr_Min",
        required=True,
        digits=(19, 4),
    )

    cr_max = fields.Float(
        string="Cr_Max",
        required=True,
        digits=(19, 4),
    )

    ni_min = fields.Float(
        string="Ni_Min",
        required=True,
        digits=(19, 4),
    )

    ni_max = fields.Float(
        string="Ni_Max",
        required=True,
        digits=(19, 4),
    )

    mo_min = fields.Float(
        string="Mo_Min",
        required=True,
        digits=(19, 4),
    )

    mo_max = fields.Float(
        string="Mo_Max",
        required=True,
        digits=(19, 4),
    )

    cu_min = fields.Float(
        string="Cu_Min",
        required=True,
        digits=(19, 4),
    )

    cu_max = fields.Float(
        string="Cu_Max",
        required=True,
        digits=(19, 4),
    )

    al_min = fields.Float(
        string="Al_Min",
        required=True,
        digits=(19, 4),
    )

    al_max = fields.Float(
        string="Al_Max",
        required=True,
        digits=(19, 4),
    )

    v_min = fields.Float(
        string="V_Min",
        required=True,
        digits=(19, 4),
    )

    v_max = fields.Float(
        string="V_Max",
        required=True,
        digits=(19, 4),
    )

    w_min = fields.Float(
        string="W_Min",
        required=True,
        digits=(19, 4),
    )

    w_max = fields.Float(
        string="W_Max",
        required=True,
        digits=(19, 4),
    )

    sn_min = fields.Float(
        string="Sn_Min",
        required=True,
        digits=(19, 4),
    )

    sn_max = fields.Float(
        string="Sn_Max",
        required=True,
        digits=(19, 4),
    )

    ass_min = fields.Float(
        string="Ass_Min",
        required=True,
        digits=(19, 4),
    )

    ass_max = fields.Float(
        string="Ass_Max",
        required=True,
        digits=(19, 4),
    )

    cueq_min = fields.Float(
        string="Cueq_Min",
        required=True,
        digits=(19, 4),
    )

    cueq_max = fields.Float(
        string="Cueq_Max",
        required=True,
        digits=(19, 4),
    )

    ceq_min = fields.Float(
        string="Ceq_Min",
        required=True,
        digits=(19, 4),
    )

    ceq_max = fields.Float(
        string="Ceq_Max",
        required=True,
        digits=(19, 4),
    )

    c_mn_6_min = fields.Float(
        string="C_Mn_6_Min",
        required=True,
        digits=(19, 4),
    )

    c_mn_6_max = fields.Float(
        string="C_Mn_6_Max",
        required=True,
        digits=(19, 4),
    )

    create_log = fields.Char(
        string="Create_Log",
        size=35,
    )

    lastmodify_log = fields.Char(
        string="LastModify_Log",
        size=35,
    )

    ma_data = fields.Char(
        string="Ma_Data",
        required=True,
        index=True,
        size=3,
    )

    n_min = fields.Float(
        string="N_Min",
        required=True,
        digits=(19, 4),
    )

    n_max = fields.Float(
        string="N_Max",
        required=True,
        digits=(19, 4),
    )
