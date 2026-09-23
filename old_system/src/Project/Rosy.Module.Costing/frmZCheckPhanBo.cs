using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Data;

namespace RosyModule.Costing
{
	public partial class frmZCheckPhanBo : RosySystem.Customize.frmView
	{
		DataTable dtPhanBoCheck;
		BindingSource bdsPhanBoCheck = new BindingSource();
		rsDataGridView dgvPhanBoCheck = new rsDataGridView();

		frmGiaThanh frmZ;

		public frmZCheckPhanBo()
		{
			InitializeComponent();
		}

		public void Load(frmGiaThanh frmGiaThanh)
		{
			frmZ = frmGiaThanh;

			this.Build();
			this.FillData();

			this.Show();
		}

		void Build()
		{
			dgvPhanBoCheck.Dock = DockStyle.Fill;
			dgvPhanBoCheck.strZone = "ZCHECKPHANBO";
			dgvPhanBoCheck.BuildGridView();

			this.Controls.Add(dgvPhanBoCheck);
		}

		void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT1", frmZ.dteNgay_Ct1);
			htPara.Add("NGAY_CT2", frmZ.dteNgay_Ct2);
			htPara.Add("TK", frmZ.txtTk.Text);
			htPara.Add("MA_DVCS", RosySystem.Element.Element.sysMa_DvCs);

			dtPhanBoCheck = SQLExec.ExecuteReturnDt("sp_ZCheckPhanBo", htPara, CommandType.StoredProcedure);

			bdsPhanBoCheck.DataSource = dtPhanBoCheck;
			dgvPhanBoCheck.DataSource = bdsPhanBoCheck;

			this.ExportControl = dgvPhanBoCheck;
			this.bdsSearch = bdsPhanBoCheck;
		}
	}
}
