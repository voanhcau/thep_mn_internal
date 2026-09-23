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
	public partial class frmZCheckCapNhatGiaThanh : RosySystem.Customize.frmView
	{
		DataTable dtCapNhatGiaThanhCheck;
		BindingSource bdsCapNhatGiaThanhCheck = new BindingSource();
		rsDataGridView dgvCapNhatGiaThanhCheck = new rsDataGridView();

		frmGiaThanh frmZ;

		public frmZCheckCapNhatGiaThanh()
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
			dgvCapNhatGiaThanhCheck.Dock = DockStyle.Fill;
			dgvCapNhatGiaThanhCheck.strZone = "ZCHECKGIATHANH";
			dgvCapNhatGiaThanhCheck.BuildGridView();

			this.Controls.Add(dgvCapNhatGiaThanhCheck);
		}

		void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT1", frmZ.dteNgay_Ct1);
			htPara.Add("NGAY_CT2", frmZ.dteNgay_Ct2);
			htPara.Add("TK", frmZ.txtTk.Text);
			htPara.Add("MA_DVCS", RosySystem.Element.Element.sysMa_DvCs);

			dtCapNhatGiaThanhCheck = SQLExec.ExecuteReturnDt("Sp_ZCheckCapNhatGiaThanh", htPara, CommandType.StoredProcedure);

			bdsCapNhatGiaThanhCheck.DataSource = dtCapNhatGiaThanhCheck;
			dgvCapNhatGiaThanhCheck.DataSource = bdsCapNhatGiaThanhCheck;

			this.ExportControl = dgvCapNhatGiaThanhCheck;
			this.bdsSearch = bdsCapNhatGiaThanhCheck;
		}
	}
}
