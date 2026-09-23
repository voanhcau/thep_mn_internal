using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Library;
using RosyList;
using RosySystem.Customize;
using RosySystem;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyModule.Inventory
{
	public partial class frmXuat_DinhMuc : RosySystem.Customize.frmEdit
	{
		frmCtNX_Edit frmCtNX_Edit;

		private DataTable dtDinhMucVt;
		private BindingSource bdsDinhMucVt = new BindingSource();		
		private DataRow drCurrent;

		#region Phuong thuc

		public frmXuat_DinhMuc()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);

			btRefresh.Click += new EventHandler(btRefresh_Click);
		}

		private void Build()
		{
			dgvDinhMuc.ReadOnly = true;
			dgvDinhMuc.strZone = "XUAT_DINHMUC";
			//dgvDinhMuc.Dock = DockStyle.Fill;

			this.Controls.Add(dgvDinhMuc);

			dgvDinhMuc.BuildGridView();
		}

		private void FillData()
		{
			string strQuery = @"
	            --Tạo bảng định mức vật tư mới nhất
	            WITH DinhMucVtMax AS
	            (
		            SELECT Ma_Vt_Sp, Ma_Vt, MAX(Ngay_Ap) AS Ngay_Ap_Max
			            FROM R07ZDinhMucVt
			            WHERE Ngay_Ap <= '" + Library.DateToStr((DateTime)frmCtNX_Edit.drEditPh["Ngay_Ct"]) + @"' AND (Ngay_End = '1/1/1900' OR
								Ngay_End >= '" + Library.DateToStr((DateTime)frmCtNX_Edit.drEditPh["Ngay_Ct"]) + @"') AND Ma_Vt_Sp = '" + txtMa_Vt_Sp.Text + @"'
			            GROUP BY Ma_Vt_Sp, Ma_Vt
	            )
				    SELECT T1.Ma_Vt_Sp, T1.Ma_Vt, T1.So_Luong 
		            INTO #T_DinhMucVt
		            FROM R07ZDinhMucVt T1 JOIN DinhMucVtMax T2
			            ON	T1.Ma_Vt_Sp = T2.Ma_Vt_Sp AND
				            T1.Ma_Vt = T2.Ma_Vt AND
				            T1.Ngay_Ap = T2.Ngay_Ap_Max;

                SELECT CAST(1 AS BIT) AS Chon, T1.Ma_Vt, T2.Ten_Vt, T2.Dvt, T2.Tk_Vtu, So_Luong AS So_Luong_Dm, CAST(0 AS MONEY) AS SL_Xuat 
					FROM #T_DinhMucVt T1 JOIN R81DMVT T2 
					ON T1.Ma_Vt = T2.Ma_Vt AND T1.Ma_Vt_Sp = '" + txtMa_Vt_Sp.Text + @"'

				DROP TABLE #T_DinhMucVt";

			dtDinhMucVt = SQLExec.ExecuteReturnDt(strQuery);

			foreach (DataRow drDinhMucVt in dtDinhMucVt.Rows)
				drDinhMucVt["SL_Xuat"] = Math.Round(Convert.ToDouble(drDinhMucVt["So_Luong_Dm"]) * numSo_Luong.Value, 4);

			bdsDinhMucVt.DataSource = dtDinhMucVt;
			dgvDinhMuc.DataSource = bdsDinhMucVt;
		}

		new public void Load(frmCtNX_Edit frmCtNX_Edit)
		{
			this.frmCtNX_Edit = frmCtNX_Edit;
			
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Build();
			FillData();

			BindingLanguage();

			this.ShowDialog();
		}

		void XuatDinhMuc()
		{
			int iStt0 = Convert.ToInt16(Common.MaxDCValue(frmCtNX_Edit.dtEditCt, "Stt0"));

			DataTable dtEditCt = frmCtNX_Edit.dtEditCt;
			DataRow drEditCtNew = dtEditCt.NewRow();
			Common.CopyDataRow(dtEditCt.Rows[0], drEditCtNew);

			//Xóa dòng trống đầu tiên
			if (dtDinhMucVt.Rows.Count > 0 && dtEditCt.Rows.Count == 1 && Convert.ToDouble(dtEditCt.Rows[0]["So_Luong"]) + Convert.ToDouble(dtEditCt.Rows[0]["Tien_Nt"]) + Convert.ToDouble(dtEditCt.Rows[0]["Tien"]) == 0)
				dtEditCt.Rows.Clear();

			foreach (DataRow drDinhMucVt in dtDinhMucVt.Rows)
			{
				if (!(bool)drDinhMucVt["Chon"])
					continue;
				
				DataRow drEditCt = this.frmCtNX_Edit.dtEditCt.NewRow();
				Common.CopyDataRow(drEditCtNew, drEditCt);				

				iStt0++;
				drEditCt["Stt0"] = iStt0;
				drEditCt["Ma_Vt_Sp"] = txtMa_Vt_Sp.Text;
				drEditCt["Ma_Vt"] = drDinhMucVt["Ma_Vt"];
				drEditCt["Tk_Co"] = drDinhMucVt["Tk_Vtu"];
				drEditCt["Ten_Vt"] = drDinhMucVt["Ten_Vt"];
				drEditCt["Dvt"] = drDinhMucVt["Dvt"];
				drEditCt["So_Luong9"] = drEditCt["So_Luong"] = drDinhMucVt["SL_Xuat"];
				drEditCt["He_So9"] = 1;
				
				frmCtNX_Edit.dtEditCt.Rows.Add(drEditCt);
				drEditCt.AcceptChanges();
			}
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;

			XuatDinhMuc();

			return bvalid;
		}

		#endregion

		#region Su kien

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = string.Empty;
				lbtTen_Vt_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt_Sp.Text = drLookup["Ten_Vt"].ToString();
			}
		}

		void btRefresh_Click(object sender, EventArgs e)
		{
			FillData();
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			isAccept = true;

			XuatDinhMuc();

			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		#endregion
	}
}