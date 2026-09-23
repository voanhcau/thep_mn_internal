using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem;
using RosySystem.Element;

namespace RosyModule.Payable
{
	public partial class frmPbCp_View: RosySystem.Customize.frmView
	{

		#region Khai bao bien
		public DataTable dtViewPn;
		BindingSource bdsViewPn = new BindingSource();
		//rsDataGridView dgvViewPn = new rsDataGridView();

		string strMa_Ct = string.Empty;
		string strKey = string.Empty;
		double dbTien_Pb_Nt = 0;
		string strLoai_Pb = "1";
		frmVoucher_Edit frmEditCtNM;

		#endregion 						

		#region Contructor

		public frmPbCp_View()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(frmVoucher_Edit frmEditCtNM, string strMa_Ct, string strKey, double dbTien_Pb_Nt, string strLoai_Pb)
		{
			this.frmEditCtNM = frmEditCtNM;
			this.strMa_Ct = strMa_Ct;
			this.strKey = strKey;
			this.dbTien_Pb_Nt = dbTien_Pb_Nt;
			this.strLoai_Pb = strLoai_Pb;

			Build();
			FillData();
			BindingLanguage();

			//if (Element.sysLanguage == enuLanguageType.Vietnamese)
			//    this.Text = this.Text + ", F10 Phân bổ chi phí";
			//else
			//    this.Text = this.Text + ", F10 Allocate";

			ShowDialog();		  
		}	
		
		#endregion

		#region Build, FillData
		private void Build()
		{
			//dgvViewPn.Dock = DockStyle.Fill;
			dgvViewPn.strZone = "CP_VIEWPN";
			dgvViewPn.BuildGridView(this.isLookup);

			this.Controls.Add(dgvViewPn);
			dgvViewPn.ReadOnly = false;
		}

		private void FillData()
		{
			bdsViewPn = new BindingSource();

			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
			string strTable_Ct = (string)drDmCt["Table_Ct"];

			string strSelect = @"
						WITH T_PB AS
						(
							SELECT Stt, Stt0 
								FROM " + strTable_Ct + @"
								WHERE " + strKey + @"
						)
						SELECT T1.Stt, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.Dien_Giai, T1.Ma_Tte, T1.Ty_Gia, T1.Ma_Kho, T1.Ma_Vt, T3.Ten_Vt, T3.Dvt, T1.So_Luong, T1.Tk_No, T1.Tk_Co, T1.Ma_Hd, 
										T1.Tien_Nt AS Tien_Nt0, T1.Tien AS Tien0, 
										CAST(0 AS MONEY) AS Tien_Nt9, CAST(0 AS MONEY) AS Tien_Nt, CAST(0 AS MONEY) AS Tien, CAST(0 AS MONEY) AS Gia_Tri_Pb, 
										CAST(0 AS BIT) AS Chon 
									FROM " + strTable_Ct + @" T1 JOIN T_PB T2 ON T1.Stt = T2.Stt AND T1.Stt0 = T2.Stt0
																	LEFT JOIN R81DmVt T3 ON T1.Ma_Vt = T3.Ma_Vt
									ORDER BY T1.Ngay_Ct, T1.So_Ct, T1.Ma_Vt";
			
			if(strTable_Ct == "R02CTNM")
			{ 
				
				strSelect = @"
							WITH T_PB AS
							(
								SELECT Stt, Stt0 
									FROM " + strTable_Ct + @"
									WHERE " + strKey + @"
							)
							SELECT T1.Stt, T1.Ma_Ct, T1.Ngay_Ct, T1.So_Ct, T1.Dien_Giai, T1.Ma_Tte, T1.Ty_Gia, T1.Ma_Kho, T1.Ma_Vt, T3.Ten_Vt, T3.Dvt, T1.So_Luong, T1.Tk_No, T1.Tk_Co, T1.Ma_Hd, 
											T1.So_TKhai, T1.Ngay_TKhai, T1.Tien_Nt AS Tien_Nt0, T1.Tien AS Tien0, 
											CAST(0 AS MONEY) AS Tien_Nt9, CAST(0 AS MONEY) AS Tien_Nt, CAST(0 AS MONEY) AS Tien, CAST(0 AS MONEY) AS Gia_Tri_Pb, 
											CAST(0 AS BIT) AS Chon 
										FROM " + strTable_Ct + @" T1 JOIN T_PB T2 ON T1.Stt = T2.Stt AND T1.Stt0 = T2.Stt0
																		LEFT JOIN R81DmVt T3 ON T1.Ma_Vt = T3.Ma_Vt
										ORDER BY T1.Ngay_Ct, T1.So_Ct, T1.Ma_Vt";
			}
			dtViewPn = SQLExec.ExecuteReturnDt(strSelect);

			bdsViewPn.DataSource = dtViewPn;
			dgvViewPn.DataSource = bdsViewPn;

			bdsViewPn.Position = 0;

			foreach (DataGridViewColumn dgvc in dgvViewPn.Columns)
				dgvc.ReadOnly = true;

			dgvViewPn.Columns["Chon"].ReadOnly = false;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsViewPn;
		}

		private void PhanBoChiPhi()
		{
			string strKey = "Chon <> true";

			DataRow drEditPh = frmEditCtNM.dtEditCt.Rows[0];
			double dbTy_Gia = (drEditPh["Ty_Gia"] == DBNull.Value) ? 0 : Convert.ToDouble(drEditPh["Ty_Gia"]);
			string strMa_Tte = drEditPh["Ma_Tte"] == DBNull.Value ? string.Empty : (string)drEditPh["Ma_Tte"];

			DataRow[] drArrSelect = dtViewPn.Select("Chon = True AND (So_Luong <> 0 OR Tien0 <> 0 OR Tien_Nt0 <> 0)");
			DataTable dtSelect = dtViewPn.Clone();
			foreach (DataRow drSelect in drArrSelect)
				dtSelect.ImportRow(drSelect);

			if (dtSelect.Rows.Count == 0)
				return;

			double dbTTien_Nt0 = Common.SumDCValue(dtSelect, "Tien_Nt0", "");
			double dbTTien0 = Common.SumDCValue(dtSelect, "Tien0", "");
			double dbTSo_Luong = Common.SumDCValue(dtSelect, "So_Luong", "");

			foreach (DataRow drSelect in dtSelect.Rows)
			{
				double dbTien_Nt = 0;
				double dbTien = 0;

				if (strLoai_Pb == "1") //Theo gia tri
				{
					//Tien Nt
					if (strMa_Tte != Element.sysMa_Tte && dbTTien_Nt0 != 0)
					{
						double dbTien_Nt0 = (drSelect["Tien_Nt0"] == DBNull.Value) ? 0 : Convert.ToDouble(drSelect["Tien_Nt0"]);

						dbTien_Nt = (dbTien_Nt0 * dbTien_Pb_Nt) / dbTTien_Nt0;
						dbTien_Nt = Math.Round(dbTien_Nt, 2, MidpointRounding.AwayFromZero);
						dbTien = Math.Round(dbTien_Nt * dbTy_Gia, 0, MidpointRounding.AwayFromZero);

						drSelect["Gia_Tri_Pb"] = dbTien_Nt0;
					}
					//Tien VND
					else if (strMa_Tte == Element.sysMa_Tte && dbTTien0 != 0)
					{
						double dbTien0 = (drSelect["Tien0"] == DBNull.Value) ? 0 : Convert.ToDouble(drSelect["Tien0"]);

						dbTien = (dbTien0 * dbTien_Pb_Nt) / dbTTien0;
						dbTien = Math.Round(dbTien, 0, MidpointRounding.AwayFromZero);
						dbTien_Nt = dbTien;

						drSelect["Gia_Tri_Pb"] = dbTien0;
					}
				}
				else // Theo So luong
				{
					if (dbTSo_Luong != 0)
					{
						double dbSo_Luong = (drSelect["So_Luong"] == DBNull.Value) ? 0 : Convert.ToDouble(drSelect["So_Luong"]);

						dbTien_Nt = (dbSo_Luong * dbTien_Pb_Nt) / dbTSo_Luong;
						dbTien_Nt = Math.Round(dbTien_Nt, 2, MidpointRounding.AwayFromZero);
						dbTien = Math.Round(dbTien_Nt * dbTy_Gia, 0, MidpointRounding.AwayFromZero);
						if (strMa_Tte == Element.sysMa_Tte)
							dbTien_Nt = dbTien;

						drSelect["Gia_Tri_Pb"] = dbSo_Luong;
					}
				}

				drSelect["Tien_Nt"] = strMa_Tte == Element.sysMa_Tte ? dbTien : dbTien_Nt;
				drSelect["Tien"] = dbTien;
				// xử lý giá trị PB
				
			}

			//Điều chỉnh: TTien_Nt = Sum(Tien_Nt)
			double dbTien_Pb = Math.Round(dbTien_Pb_Nt * dbTy_Gia, MidpointRounding.AwayFromZero);
			double dChenh_Lenh_Nt = Math.Round(dbTien_Pb_Nt - Common.SumDCValue(dtSelect, "Tien_Nt", ""), MidpointRounding.AwayFromZero);
			double dChenh_Lenh = Math.Round(dbTien_Pb - Common.SumDCValue(dtSelect, "Tien", ""), MidpointRounding.AwayFromZero);

			if (dChenh_Lenh_Nt != 0 || dChenh_Lenh != 0)
			{
				int iMax = Common.MaxDCPosition(dtSelect, "Tien_Nt");

				if (iMax >= 0)
				{
					DataRow drMax = dtSelect.Rows[iMax];

					drMax["Tien_Nt"] = Convert.ToDouble(drMax["Tien_Nt"]) + dChenh_Lenh_Nt;
					drMax["Tien"] = Convert.ToDouble(drMax["Tien"]) + dChenh_Lenh;
				}
			}
			//UPDATE PH
			//DataTable dtEditPh = frmEditCtNM.dtEditPh;
			//DataRow drEditPh = frmEdit.drEditPh;
			//Common.CopyDataRow(dtEditPh.Rows[0], drEditPh);
			//UPDATE CT
			DataTable dtEditCt = frmEditCtNM.dtEditCt;
			DataRow drEditCt = dtEditCt.NewRow();
			Common.CopyDataRow(dtEditCt.Rows[0], drEditCt);
			
			if((string)dtEditCt.Rows[0]["Ma_Vt"] == "")
				dtEditCt.Rows.Clear();

			foreach (DataRow drSelect in dtSelect.Rows)
			{
				DataRow drEditCtNew = dtEditCt.NewRow();
				Common.CopyDataRow(drEditCt, drEditCtNew);

				drEditCtNew["Ma_Vt"] = drSelect["Ma_Vt"];
				drEditCtNew["Ten_Vt"] = drSelect["Ten_Vt"];
				drEditCtNew["Ma_Kho"] = drSelect["Ma_Kho"];
				drEditCtNew["Dvt"] = drSelect["Dvt"];
				drEditCtNew["Tk_No"] = drSelect["Tk_No"];
                drEditCtNew["Ma_Hd"] = drSelect["Ma_Hd"];
				drEditCtNew["Tien_Nt9"] = drSelect["Tien_Nt"];
				drEditCtNew["Tien_Nt"] = drSelect["Tien_Nt"];
				drEditCtNew["Tien"] = drSelect["Tien"];
				drEditCtNew["Gia_Tri_Pb"] = drSelect["Gia_Tri_Pb"];
				drEditCtNew["So_Luong9"] = 0;
				drEditCtNew["So_Luong"] = 0;
				drEditCtNew["Gia_Nt9"] = 0;
				drEditCtNew["Gia"] = 0;
				drEditCtNew["Gia_Nt"] = 0;
				drEditCtNew["Stt_Org"] = drSelect["Stt"];
				drEditCtNew["Stt0"] = Common.MaxDCValue(dtEditCt, "Stt0") + 1;

				dtEditCt.Rows.Add(drEditCtNew);
			}

			dtEditCt.AcceptChanges();
			this.Close();
		}

		#endregion		

		#region Su kien	

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Space:
					DataRow drCurrent = ((DataRowView)bdsViewPn.Current).Row;
					drCurrent["Chon"] = !(bool)drCurrent["Chon"];
					break;
			}

			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.A:
						foreach (DataRow dr in dtViewPn.Rows)
							dr["Chon"] = true;
						break;
					case Keys.U:
						foreach (DataRow dr in dtViewPn.Rows)
							dr["Chon"] = false;
						break;
				}
			}

			base.OnKeyDown(e);
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			PhanBoChiPhi();
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion 
	}
}