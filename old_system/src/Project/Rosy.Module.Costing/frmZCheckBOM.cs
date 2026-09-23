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
	public partial class frmZCheckBOM : RosySystem.Customize.frmView
	{
		DataTable dtCheckBOM;
		BindingSource bdsCheckBOM = new BindingSource();
		rsDataGridView dgvCheckBOM = new rsDataGridView();

		DataTable dtZChiPhiYt;

		frmGiaThanh frmZ;

		public frmZCheckBOM()
		{
			InitializeComponent();
		}

		public void Load(frmGiaThanh frmGiaThanh, DataTable dtZChiPhiYt)
		{
			this.frmZ = frmGiaThanh;
			this.dtZChiPhiYt = dtZChiPhiYt;

			this.Build();
			this.FillData();

			this.Show();
		}

		void Build()
		{
			dgvCheckBOM.Dock = DockStyle.Fill;
			dgvCheckBOM.strZone = "ZCHECKBOM";
			dgvCheckBOM.BuildGridView();

			this.Controls.Add(dgvCheckBOM);
		}

		void FillData()
		{
			DataTable dtZPhanBo = SQLExec.ExecuteReturnDt("SELECT * FROM R07ZPHANBO WHERE Loai_Pb = '3' AND Kieu_Pb = '1-BOM' AND Tk = '" + frmZ.txtTk.Text + "'");
			dtCheckBOM = SQLExec.ExecuteReturnDt("SELECT Ma_Vt, Ma_Vt_Sp, So_Luong, Ngay_Ap, So_Luong AS SL_Nhap FROM R07zDinhMucVt WHERE 0 = 1");

			Hashtable htPara = new Hashtable();
			htPara.Add("Tk", frmZ.txtTk.Text);
			htPara.Add("NGAY_CT1", frmZ.dteNgay_Ct1);
			htPara.Add("NGAY_CT2", frmZ.dteNgay_Ct2);
			htPara.Add("MA_DVCS", RosySystem.Element.Element.sysMa_DvCs);

			foreach (DataRow dr in dtZPhanBo.Rows)
			{
				string strTk_Cp = dr["Tk_Cp"].ToString();

				foreach (DataRow dr1 in dtZChiPhiYt.Select("Tk_Cp = '" + strTk_Cp + "'"))
				{
					string strMa_Vt = dr1["Ma_Vt"].ToString();

					string strSQL = @"SELECT T1.Ma_Vt, T1.Ma_Vt_Sp, T1.So_Luong, T1.Ngay_Ap, T2.SL_Nhap 
										FROM R07zDinhMucVt T1 LEFT JOIN (SELECT Ma_Vt_Sp, ISNULL(SUM(SL_Nhap), 0) AS  SL_Nhap
																			FROM R07GiaThanh 
																			WHERE Tk = '" + frmZ.txtTk.Text + @"' AND Ngay_Ct BETWEEN '" + RosySystem.Library.Library.DateToStr(frmZ.dteNgay_Ct1) + "' AND '" + RosySystem.Library.Library.DateToStr(frmZ.dteNgay_Ct2) + "' AND Ma_DvCs = '" + RosySystem.Element.Element.sysMa_DvCs + @"'
																			GROUP BY Ma_Vt_Sp) T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt_Sp
										WHERE T1.Ma_Vt = '" + strMa_Vt + "'";

					DataTable dtCheckBOM1 = SQLExec.ExecuteReturnDt(strSQL);

					if (dtCheckBOM1.Rows.Count == 0)
					{
						DataRow drNew = dtCheckBOM.NewRow();
						drNew["Ma_Vt"] = strMa_Vt;
						RosySystem.Common.Common.SetDefaultDataRow(ref drNew);
						dtCheckBOM.Rows.Add(drNew);
					}
					else
						dtCheckBOM.Merge(dtCheckBOM1);
						
				}
			}

			bdsCheckBOM.DataSource = dtCheckBOM;
			dgvCheckBOM.DataSource = bdsCheckBOM;

			this.ExportControl = dgvCheckBOM;
			this.bdsSearch = bdsCheckBOM;
		}
	}
}
