using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;
using System.Collections;
using System.Data.SqlClient;


namespace RosyModule.Inventory
{
	public partial class frmXuLyPhoi : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtEditCt;
		public DataTable dtDuyet_Ph;
		public DataTable dtEditCt_LR;

		BindingSource bdsEditCt = new BindingSource();
		BindingSource bdsEditCtLr = new BindingSource();
		DataRow drDuyet;
		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
		frmVoucher_Edit frmVoucher_Edit;
		DataRow drCurrent;
		public bool Is_Accept = false;

		#endregion

		#region Contructor

		public frmXuLyPhoi()
		{
			InitializeComponent();

			//this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			//this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btThoat.Click += new EventHandler(btThoat_Click);
			btRefresh.Click += new EventHandler(btRefresh_Click);
            btUpdate.Click += new EventHandler(btUpdate_Click);

			bdsEditCt.PositionChanged += new EventHandler(bdsEditCt_PositionChanged);
			//dgvEdit_Ct.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDuyet_CellValidating);
			//dgvEdit_Ct.CellValidated += new DataGridViewCellEventHandler(dgvEdit_Ct_CellValidated);
			
		}

        

		void btRefresh_Click(object sender, EventArgs e)
		{
			FillData();
		}

		#endregion

		#region Method

		public void Load()
		{
			dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

			Build();
			FillData();
			BindingLanguage();

			

			this.Show();
		}


		void Build()
		{
			dgvEditCt.strZone = "XULYPHOI";
			dgvEditCt.BuildGridView();

			dgvEdit_CtLr.strZone = "XULYPHOILR";
			dgvEdit_CtLr.BuildGridView();

		}

		void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
			htPara.Add("PHAN_LOAI_PHOI", "CXL");
			htPara.Add("IS_CXL", chkIs_CXL.Checked);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsEdit_Ct = SQLExec.ExecuteReturnDs("sp_GetPhoiCXL", htPara, CommandType.StoredProcedure);
			dtEditCt = dsEdit_Ct.Tables[0];
			bdsEditCt.DataSource = dtEditCt;
			dgvEditCt.DataSource = bdsEditCt;

			//Chi tiết nhập kho
			dtEditCt_LR = dsEdit_Ct.Tables[1];
			
			if (dtEditCt_LR.Rows.Count == 0)
			{
				DataRow drEditCt_LR = dtEditCt_LR.NewRow();
				Common.SetDefaultDataRow(ref drEditCt_LR);
				dtEditCt_LR.Rows.Add(drEditCt_LR);
			}

			bdsEditCtLr.DataSource = dtEditCt_LR;
			dgvEdit_CtLr.DataSource = bdsEditCtLr;
		}

		bool FormCheckValid()
		{

			return true;
		}

		void btThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			Delete_XuLyPhoi();
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			Edit_XuLyPhoi(enuEdit.Edit);
		}

		void btNew_Click(object sender, EventArgs e)
		{
			Edit_XuLyPhoi(enuEdit.New);
		}

		#endregion

		#region Event
        void btUpdate_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("CREATE_LOG", Common.GetCurrent_Log());

            SQLExec.Execute("sp_Import_Phoi_Kt", ht, CommandType.StoredProcedure);
            Common.MsgOk("Đã tạo phiếu hạch toán phôi chờ xử lý trong tháng vào kế toán");
        }
		void bdsEditCt_PositionChanged(object sender, EventArgs e)
		{
			if (bdsEditCt.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;

			bdsEditCtLr.Filter = "Stt = '" + drCurrent["Stt"].ToString() + "' AND Ma_Vt = '" + drCurrent["Ma_Vt"].ToString() + "' AND So_Me = '" + drCurrent["So_Me"].ToString() + "' AND Stt0 = '" + drCurrent["Stt0"].ToString() + "' ";
		}

		private void Edit_XuLyPhoi(enuEdit enuNew_Edit)
		{
			if (bdsEditCt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;
			
			DataRow drEditCt = ((DataRowView)bdsEditCt.Current).Row;
			
			//Copy hang hien tai            
			if (bdsEditCtLr.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsEditCtLr.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtEditCt_LR.NewRow();

				drCurrent["Ma_Ct"] = drEditCt["Ma_Ct"];
				drCurrent["Stt"] = drEditCt["Stt"];
				drCurrent["Ngay_Ct"] = drEditCt["Ngay_Ct"];
				drCurrent["So_Ct"] = drEditCt["So_Ct"];
				drCurrent["He_So9"] = 1;
				drCurrent["Posted"] = 1;
				drCurrent["Stt0"] = drEditCt["Stt0"];
				drCurrent["Ma_Vt"] = drEditCt["Ma_Vt"];
				drCurrent["So_Me"] = drEditCt["So_Me"];
				drCurrent["DDai_Phoi"] = drEditCt["DDai_Phoi"];
				drCurrent["So_Luong_Cay"] = drEditCt["So_Luong_Cay"];
				drCurrent["So_Luong"] = drEditCt["So_Luong"];
			}



			frmXuLyPhoi_Edit frmEdit = new frmXuLyPhoi_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", frmEdit.drEdit["Ma_Vt"].ToString());

				drCurrent["Ten_Vt"] = drDmVt["Ten_Vt"];
				drCurrent["Mac_Thep"] = drDmVt["Mac_Thep"];

				if (enuNew_Edit == enuEdit.New)
					if (bdsEditCtLr.Position >= 0)
						dtEditCt_LR.ImportRow(drCurrent);
					else
						dtEditCt_LR.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCtLr.Current).Row);
				}

				dtEditCt_LR.AcceptChanges();

				
				//if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
				//    bdsCtTs.Position = bdsCtTs.Find("Stt", drCurrent["Stt"]);
			}
			else
				dtEditCt_LR.RejectChanges();
		}

		private void Delete_XuLyPhoi()
		{
			if (bdsEditCtLr.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsEditCtLr.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R05CTNXLRPHOI", drCurrent))
			{
				bdsEditCtLr.RemoveAt(bdsEditCtLr.Position);
				dtEditCt_LR.AcceptChanges();
			}
		}
		//void dgvEdit_Ct_CellValidated(object sender, DataGridViewCellEventArgs e)
		//{
		//    drCurrent = ((DataRowView)bdsEditCtLr.Current).Row;
		//    DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
		//    string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

		//    if (Common.Inlist(strColumnName, "DDAI_PHOI,SO_LUONG_CAY"))
		//    {

		//        if (string.IsNullOrEmpty(drCurrent["Ma_Vt"].ToString()))
		//            return;

		//        DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", (string)drCurrent["Ma_Vt"]);
		//        if (drDmVt == null)
		//            return;

		//        drCurrent["So_Luong01"] = Math.Round(Convert.ToDouble(drCurrent["So_Luong_Cay01"]) * Convert.ToDouble(drDmVt["Barem"]) * Convert.ToDouble(drCurrent["DDai_Phoi01"]), 0);
		//    }
			

		//    drCurrent.AcceptChanges();
		//}

		//void dgvDuyet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		//{
		//    drCurrent = ((DataRowView)bdsEditCt.Current).Row;
		//    DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
		//    string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

		//    bool bLookup = true;

		//    if (Common.Inlist(strColumnName, "MA_VT01"))
		//        bLookup = dgvLookupMa_Vt01(ref dgvCell);
			
		//    else if (Common.Inlist(strColumnName, "MA_VT02"))
		//        bLookup = dgvLookupMa_Vt02(ref dgvCell);
			
		//    else if (Common.Inlist(strColumnName, "MA_VT03"))
		//        bLookup = dgvLookupMa_Vt03(ref dgvCell);
			
		//    else if (strColumnName == "PHAN_LOAI_PHOI01")
		//        bLookup = dgvLookupPhan_Loai_Phoi01(ref dgvCell);
			
		//    else if (strColumnName == "PHAN_LOAI_PHOI01")
		//        bLookup = dgvLookupPhan_Loai_Phoi02(ref dgvCell);
			
		//    else if (strColumnName == "PHAN_LOAI_PHOI01")
		//        bLookup = dgvLookupPhan_Loai_Phoi03(ref dgvCell);

		//    if (bLookup == false)
		//        e.Cancel = true;
		//}

		private bool dgvLookupPhan_Loai_Phoi01(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = true;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "PHAN_LOAI_PHOI");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'PHAN_LOAI_PHOI'", "", htField);

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["Type_ID"].ToString();
				dgvCell.Tag = drLookup["Type_Name"].ToString();

				drCurrent["Ma_Kho01"] = drLookup["Type_Name"];

				dgvCell.DataGridView.EndEdit();
			}
			return true;
		}

		private bool dgvLookupPhan_Loai_Phoi02(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = true;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "PHAN_LOAI_PHOI");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'PHAN_LOAI_PHOI'", "", htField);

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["Type_ID"].ToString();
				dgvCell.Tag = drLookup["Type_Name"].ToString();

				drCurrent["Ma_Kho02"] = drLookup["Type_Name"];

				dgvCell.DataGridView.EndEdit();
			}
			return true;
		}

		private bool dgvLookupPhan_Loai_Phoi03(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = true;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "PHAN_LOAI_PHOI");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'PHAN_LOAI_PHOI'", "", htField);

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["Type_ID"].ToString();
				dgvCell.Tag = drLookup["Type_Name"].ToString();

				drCurrent["Ma_Kho03"] = drLookup["Type_Name"];

				dgvCell.DataGridView.EndEdit();
			}
			return true;
		}
		private bool dgvLookupMa_Vt01(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				string strMa_Vt_Old = string.Empty;

				if (drCurrent.HasVersion(DataRowVersion.Original))
					strMa_Vt_Old = drCurrent["Ma_Vt01", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt", DataRowVersion.Original];
				else
					strMa_Vt_Old = drCurrent["Ma_Vt01"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];

				string strMa_Vt = (string)drLookup["Ma_Vt"];

				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				dgvCell.DataGridView.EndEdit();

				//if (strMa_Vt != strMa_Vt_Old)
				//{
					drCurrent["Ten_Vt01"] = drLookup["Ten_Vt"];
				
					//Phoi
					drCurrent["Mac_Thep01"] = drLookup["Mac_Thep"];
					drCurrent["Loai_Phoi01"] = drLookup["Loai_Phoi"];
				//}
			}
			return true;
		}
		private bool dgvLookupMa_Vt02(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				string strMa_Vt_Old = string.Empty;

				if (drCurrent.HasVersion(DataRowVersion.Original))
					strMa_Vt_Old = drCurrent["Ma_Vt02", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt", DataRowVersion.Original];
				else
					strMa_Vt_Old = drCurrent["Ma_Vt02"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];

				string strMa_Vt = (string)drLookup["Ma_Vt"];

				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				dgvCell.DataGridView.EndEdit();

				//if (strMa_Vt != strMa_Vt_Old)
				//{
				drCurrent["Ten_Vt02"] = drLookup["Ten_Vt"];

				//Phoi
				drCurrent["Mac_Thep02"] = drLookup["Mac_Thep"];
				drCurrent["Loai_Phoi02"] = drLookup["Loai_Phoi"];
				//}
			}
			return true;
		}
		private bool dgvLookupMa_Vt03(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				string strMa_Vt_Old = string.Empty;

				if (drCurrent.HasVersion(DataRowVersion.Original))
					strMa_Vt_Old = drCurrent["Ma_Vt03", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt", DataRowVersion.Original];
				else
					strMa_Vt_Old = drCurrent["Ma_Vt03"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];

				string strMa_Vt = (string)drLookup["Ma_Vt"];

				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				dgvCell.DataGridView.EndEdit();

				//if (strMa_Vt != strMa_Vt_Old)
				//{
				drCurrent["Ten_Vt03"] = drLookup["Ten_Vt"];

				//Phoi
				drCurrent["Mac_Thep03"] = drLookup["Mac_Thep"];
				drCurrent["Loai_Phoi03"] = drLookup["Loai_Phoi"];
				//}
			}
			return true;
		}

        #endregion
        void btAccept_Click(object sender, EventArgs e)
		{
			
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				Edit_XuLyPhoi(enuEdit.New);
			}
			else if (e.KeyCode == Keys.F3)
			{
				Edit_XuLyPhoi(enuEdit.Edit);
			}
			else if (e.KeyCode == Keys.F8)
			{
				Delete_XuLyPhoi();
			}
			else
			base.OnKeyDown(e);


		}
			


	}

}