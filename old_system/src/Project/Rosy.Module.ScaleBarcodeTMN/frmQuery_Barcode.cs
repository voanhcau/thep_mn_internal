using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Library;
using RosySystem.Element;
using RosySystem.Common;
using System.Collections;
using RosySystem.Data;
using RosySystem.Public;
using RosySystem;

namespace RosyModule.ScaleBarcodeTMN
{
	public partial class frmQuery_Barcode : RosySystem.Customize.frmView
	{
		DataTable dtQueryBarcode;
		BindingSource bdsQueryBarcode = new BindingSource();
        string strBarCodeList = string.Empty;
        

		public frmQuery_Barcode()
		{
			InitializeComponent();

			this.btFilter.Click += new EventHandler(btFilter_Click);
			this.txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
            this.btExcel.Click += new EventHandler(btExcel_Click);
		}

        

		new public void Load()
		{
			this.Build();
			this.BindingLanguage();
			this.ReBindingLangage();
			this.Show();
		}

		private void ReBindingLangage()
		{
			if (dgvQueryBarcode.Columns.Contains("Ngay_Nhap"))
				dgvQueryBarcode.Columns["Ngay_Nhap"].HeaderText = "Ngày sản xuất";

			if (dgvQueryBarcode.Columns.Contains("So_Luong"))
				dgvQueryBarcode.Columns["So_Luong"].HeaderText = "Khối lượng";
		}

		private void Build()
		{
			dgvQueryBarcode.strZone = "QUERY_BARCODE";
			dgvQueryBarcode.BuildGridView();

			this.dteNgay_Ct1.Text = Common.GetDate(DateTime.Now.Year, 1, 1).ToShortDateString();
		}

		private void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			htPara.Add("BARCODE", txtBarcode.Text);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtQueryBarcode = SQLExec.ExecuteReturnDt("sp_Query_Barcode", htPara, CommandType.StoredProcedure);

			bdsQueryBarcode.DataSource = dtQueryBarcode;
			dgvQueryBarcode.DataSource = bdsQueryBarcode;

			bdsQueryBarcode.Position = 0;
			this.bdsSearch = bdsQueryBarcode;
			this.ExportControl = dgvQueryBarcode;
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

        void btExcel_Click(object sender, EventArgs e)
        {
            frmReadExcel frmImport = new frmReadExcel();
            frmImport.Load();
           
            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                foreach (DataRow dr in frmImport.dtImport.Rows)
                {
                    strBarCodeList = strBarCodeList + "," + (string)dr["BarCode"];
                    
                }
                Hashtable htPara = new Hashtable();
                htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
                htPara.Add("BARCODE_LIST", strBarCodeList);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                dtQueryBarcode = SQLExec.ExecuteReturnDt("sp_Query_BarcodeList", htPara, CommandType.StoredProcedure);

                bdsQueryBarcode.DataSource = dtQueryBarcode;
                dgvQueryBarcode.DataSource = bdsQueryBarcode;

                bdsQueryBarcode.Position = 0;
                this.bdsSearch = bdsQueryBarcode;
                this.ExportControl = dgvQueryBarcode;
            }
        }
		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("MA_VT", strValue, bRequire, "");

			if (drLookup == null && bRequire)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = string.Empty;
				lbtTen_Vt_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = (string)drLookup["Ma_Vt"];
				lbtTen_Vt_Sp.Text = (string)drLookup["Ten_Vt"];
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F8)
			{
				//Kiem tra Permission
				if (Common.CheckPermission("DELETE_QUERY_BARCODE", enuPermission_Type.Allow_Delete))
					this.Delete_CtX_Barcode();
				else
					Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				
				return;
			}

			base.OnKeyDown(e);
		}

		private void Delete_CtX_Barcode()
		{
			if (bdsQueryBarcode.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsQueryBarcode.Current).Row;

			if (drCurrent["Stt_Xuat"].ToString() == string.Empty && Library.StrToDate(drCurrent["Ngay_Xuat"].ToString()) == Library.StrToDate("30/04/2015"))
			{
				if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
					return;

				string strSQLExec = "DELETE FROM R05CTX_BARCODE WHERE Barcode = '" + drCurrent["Barcode"] + "' AND Stt = '' AND Ngay_Ct = '" + Convert.ToDateTime(drCurrent["Ngay_Xuat"]).ToShortDateString() + "'";
				if (SQLExec.Execute(strSQLExec, CommandType.Text))
				{
					bdsQueryBarcode.RemoveAt(bdsQueryBarcode.Position);
					dtQueryBarcode.AcceptChanges();
				}
			}
		}
	}
}
