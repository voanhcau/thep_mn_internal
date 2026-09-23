using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;

namespace RosyModule.CRM
{
	public partial class frmToDo : RosySystem.Customize.frmView
	{
		DataTable dtToDo;
		BindingSource bdsToDo = new BindingSource();
		rsTreeList tlToDo = new rsTreeList();

		DataTable dtContact;
		BindingSource bdsContact = new BindingSource();

		DataRow drCurrent;
		string strMa_Dt_CbNv = string.Empty;
		string strMa_Hd = string.Empty;

		public frmToDo()
		{
			InitializeComponent();
			
			cboMa_Dt_CbNv.SelectedValueChanged += new EventHandler(cboMa_Dt_CbNv_SelectedValueChanged);
			cboMa_Dt_CbNv_Th.SelectedValueChanged += new EventHandler(cboMa_Dt_CbNv_SelectedValueChanged);
			cboKieu_Nhom.SelectedValueChanged += new EventHandler(cboKieu_Nhom_SelectedValueChanged);

			chkProcessing_Only.CheckedChanged += new EventHandler(chkProcessing_Only_CheckedChanged);

			tlToDo.MouseClick += new MouseEventHandler(tlToDo_MouseClick);
			tlToDo.MouseDoubleClick += new MouseEventHandler(tlToDo_MouseDoubleClick);

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btFilter.Click += new EventHandler(btFilter_Click);
			btDelete.Click += new EventHandler(btDelete_Click);

			//
			btEdit_Customer.Click += new EventHandler(btEdit_Customer_Click);

			btNew_Contact.Click += new EventHandler(btNew_Contact_Click);
			btEdit_Contact.Click += new EventHandler(btEdit_Contact_Click);
			btDelete_Contact.Click += new EventHandler(btDelete_Contact_Click);
			///

			tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);

			this.KeyDown += new KeyEventHandler(frmToDo_KeyDown);
		}

		public void Load()
		{
			strMa_Dt_CbNv = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Ma_Dt_CbNv), '') FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'");
			int iIndex = 0;

			//Gắn Ma_CbNv vào ComboBox
			cboMa_Dt_CbNv.Items.Add("*");
			cboMa_Dt_CbNv_Th.Items.Add("*");
			DataTable dtDmDtCbNv = SQLExec.ExecuteReturnDt("SELECT DISTINCT Ma_Dt_CbNv FROM R81DmDt WHERE Ma_Dt_CbNv IN (SELECT Ma_Dt_CbNv FROM R00MEMBER)");
			foreach (DataRow dr in dtDmDtCbNv.Rows)
			{
				cboMa_Dt_CbNv.Items.Add(dr["Ma_Dt_CbNv"]);
				cboMa_Dt_CbNv_Th.Items.Add(dr["Ma_Dt_CbNv"]);
				iIndex++;
			}

			cboMa_Dt_CbNv.Text = "*";
			cboMa_Dt_CbNv_Th.Text = strMa_Dt_CbNv;
			cboMa_Dt_CbNv_Th.Enabled = (Common.CheckPermission("SALEADMIN", enuPermission_Type.Allow_Access) || Element.sysIs_Admin);

			//cboKieu_Nhom.SelectedIndex = 0;

			this.Build();
			this.FillData(string.Empty);

			this.Show();
		}

		public void Load(string strMa_Hd)
		{
			this.strMa_Hd = strMa_Hd;

			this.Load();
		}

		void Build()
		{
			tlToDo.strZone = "TODO";
			tlToDo.KeyFieldName = "TASK_ID";
			tlToDo.ParentFieldName = "PARENTFIELD";
			tlToDo.Dock = DockStyle.Fill;
			tlToDo.BuildTreeList();

			foreach (DevExpress.XtraTreeList.Columns.TreeListColumn col in tlToDo.Columns)
			{
				if (col.FieldName == "FINISH")
					col.OptionsColumn.ReadOnly = false;
				else
					col.OptionsColumn.ReadOnly = true;
			}

			this.pageTask.Controls.Add(tlToDo);

			//Build cho Contact
			dgvContact.strZone = "CONTACT";
			dgvContact.BuildGridView();
		}

		void FillData(string strKey)
		{
			string strKeyToDo = "(Deleted <> 1)";
			string strMa_Dt_CbNv = cboMa_Dt_CbNv.Text;//(cboMa_CbNv.SelectedIndex < 0 ? cboMa_CbNv.Text : cboMa_CbNv.SelectedText);
			string strMa_Dt_CbNv_Th = cboMa_Dt_CbNv_Th.Text;// (cboMa_CbNv_Th.SelectedIndex < 0 ? cboMa_CbNv_Th.Text : cboMa_CbNv_Th.SelectedText);

			if (strKey != string.Empty)
				strKeyToDo += " AND " + strKey;

			if (strMa_Dt_CbNv != "*")
				strKeyToDo += " AND Ma_Dt_CbNv = '" + strMa_Dt_CbNv + "'";

			if (strMa_Dt_CbNv_Th != "*")
				strKeyToDo += " AND Ma_Dt_CbNv_Th = '" + strMa_Dt_CbNv_Th + "'";

			if (strMa_Hd != string.Empty)
				strKeyToDo += " AND Ma_Dt_Kh = '" + strMa_Hd + "'";

			//Customer
			Hashtable htPara = new Hashtable();
			htPara.Add("KIEU_NHOM", cboKieu_Nhom.Text.Substring(0, 1));
            htPara.Add("MA_DT_CBNV", strMa_Dt_CbNv);
			htPara.Add("KEY", strKeyToDo);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtToDo = SQLExec.ExecuteReturnDt("sp_CRM_GetToDo", htPara, CommandType.StoredProcedure);
			DataColumn dcNew = new DataColumn("FINISH", typeof(bool));
			dcNew.Expression = "IIF(Ngay_Ht > #1/1/1900#, true, false)";
			dtToDo.Columns.Add(dcNew);

			bdsToDo.DataSource = dtToDo;
			tlToDo.DataSource = bdsToDo;

			if (chkProcessing_Only.Checked)
				bdsToDo.Filter = "Finish = false";
			else
				bdsToDo.RemoveFilter();


			//Nhắc việc
			string strTen_CbNv = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", this.cboMa_Dt_CbNv_Th.Text);

			string strSQLExec = @"
				SELECT COUNT(Task_ID) 
					FROM R08Task 
					WHERE (Ma_Dt_CbNv_Th IN (SELECT Ma_Dt_CbNv FROM R00Member WHERE Member_ID = '" + this.cboMa_Dt_CbNv_Th.Text + @"')) AND Deleted = 0
					AND Ngay_Ht <= '1/1/1900'";

			Common.ShowStatus(strTen_CbNv + " có " + SQLExec.ExecuteReturnValue(strSQLExec).ToString() + "  việc phải làm");
		}

		void FilterData()
		{
			DataTable dtFilter = new DataTable();

			dtFilter.Columns.Add(new DataColumn("Ngay_Gd1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Gd2", typeof(DateTime)));

			dtFilter.Columns.Add(new DataColumn("Contact", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Task_Name", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt_CbNv", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt_CbNv_TH", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt_KH", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_HD", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tinh_Trang_GD", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Subject", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();
			Common.SetDefaultDataRow(ref drFilter);

			//Set Default 
			drFilter["Ngay_Gd1"] = Element.sysNgay_Ct1;
			drFilter["Ngay_Gd2"] = Element.sysNgay_Ct2;
			dtFilter.Rows.Add(drFilter);

			frmToDo_Dkl frmFilter = new frmToDo_Dkl();
			frmFilter.Load(drFilter);

			if (frmFilter.isAccept)
			{
				string strNgay_Gd1 = Library.DateToStr((DateTime)drFilter["Ngay_Gd1"]);
				string strNgay_Gd2 = Library.DateToStr((DateTime)drFilter["Ngay_Gd2"]);

				string strFilterKey = "(1=1)";

				if (strNgay_Gd1.Replace(" ", "") != "//" && strNgay_Gd2.Replace(" ", "") != "//")
					strFilterKey += " AND (Ngay_Gd BETWEEN '" + strNgay_Gd1 + "' AND '" + strNgay_Gd2 + "') ";

				if ((string)drFilter["Contact"] != "")
					strFilterKey += " AND (Contact LIKE N'%" + (string)drFilter["Contact"] + "%') ";

				if ((string)drFilter["Task_Name"] != "")
					strFilterKey += " AND (Task_Name LIKE N'%" + (string)drFilter["Task_Name"] + "%') ";

				if ((string)drFilter["Ma_Dt_CbNv"] != "")
					strFilterKey += " AND (Ma_Dt_CbNv = N'" + (string)drFilter["Ma_Dt_CbNv"] + "') ";

				if ((string)drFilter["Ma_Dt_CbNv_TH"] != "")
					strFilterKey += " AND (Ma_Dt_CbNv_TH = N'" + (string)drFilter["Ma_Dt_CbNv_TH"] + "') ";

				if ((string)drFilter["Ma_Dt_KH"] != "")
					strFilterKey += " AND (Ma_Dt_KH = N'" + (string)drFilter["Ma_Dt_KH"] + "') ";

				if ((string)drFilter["Tinh_Trang_GD"] != "")
					strFilterKey += " AND (Tinh_Trang_GD = '" + (string)drFilter["Tinh_Trang_GD"] + "') ";

				if ((string)drFilter["Subject"] != "")
					strFilterKey += " AND (Subject = N'" + (string)drFilter["Subject"] + "') ";

				this.FillData(strFilterKey);
			}
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsToDo.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (strMa_Dt_CbNv == string.Empty)
			{
				Common.MsgCancel("Tài khoản đăng nhập " + Element.sysUser_Id + " chưa đăng ký với danh sách nhân viên!");
				return;
			}

			//DataRow drCustomer = ((DataRowView)bdsToDo.Current).Row;

			//Copy hang hien tai            
			if (bdsToDo.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsToDo.Current).Row, ref drCurrent);
			else
				drCurrent = dtToDo.NewRow();

			//Tính Stt Max
			if (enuNew_Edit == enuEdit.New)
			{
				CRMLib.GetNewTask_ID(drCurrent);
				//drCurrent["Parent_ID"] = ((DataRowView)bdsToDo.Current).Row["Ma_Dt"].ToString();
				drCurrent["Task_Type"] = "TODO";
				drCurrent["Ma_Dt_CbNv"] = strMa_Dt_CbNv;
				drCurrent["Ngay_Gd"] = DateTime.Now;
				drCurrent["Ngay_Dk_Ht"] = DBNull.Value;
				drCurrent["Ngay_Ht"] = DBNull.Value;
			}

			frmToDo_Edit frmEdit = new frmToDo_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// Người dùng chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsToDo.Position >= 0)
						dtToDo.ImportRow(drCurrent);
					else
						dtToDo.Rows.Add(drCurrent);

					bdsToDo.Position = bdsToDo.Find("Task_ID", drCurrent["Task_ID"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsToDo.Current).Row);

				dtToDo.AcceptChanges();
			}
			//else
			//    dtToDo.RejectChanges();	
		}

		public override void Delete()
		{
			if (bdsToDo.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsToDo.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			string strSQLExec = "UPDATE R08Task SET Deleted = 1 WHERE Task_ID = '" + (string)drCurrent["Task_ID"] + "'";
			if (SQLExec.Execute(strSQLExec))
			{
				bdsToDo.RemoveAt(bdsToDo.Position);
				dtToDo.AcceptChanges();
			}
		}

		#region Customer & Contact

		void EditCustomer(enuEdit enuNew_Edit)
		{
			DataRow drEdit = DataTool.SQLGetDataRowByID("R81DmDt", "Ma_Dt", txtMa_Dt_Kh.Text);

			if (drEdit == null)
				return;

			frmCustomer_Edit frmEdit = new frmCustomer_Edit();
			frmEdit.Load(enuNew_Edit, drEdit);

			// Người dùng chấp nhận
			if (frmEdit.isAccept)
			{
				FillData_Contact();
			}
		}

		void EditContact(enuEdit enuNew_Edit)
		{
			if (dtContact == null)
				return;

			if (bdsContact.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (strMa_Dt_CbNv == string.Empty)
			{
				Common.MsgCancel("Tài khoản đăng nhập " + Element.sysUser_Id + " chưa đăng ký với danh sách nhân viên!");
				return;
			}

			//Copy hang hien tai            
			if (bdsContact.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsContact.Current).Row, ref drCurrent);
			else
				drCurrent = dtContact.NewRow();

			//Tính Stt Max
			if (enuNew_Edit == enuEdit.New)
			{
				CRMLib.GetNewContact_ID(drCurrent);
				drCurrent["Ma_Dt_KH"] = txtMa_Dt_Kh.Text;
			}

			frmContact_Edit frmEdit = new frmContact_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// Người dùng chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsContact.Position >= 0)
						dtContact.ImportRow(drCurrent);
					else
						dtContact.Rows.Add(drCurrent);

					bdsContact.Position = bdsContact.Find("Contact_ID", drCurrent["Contact_ID"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsContact.Current).Row);

				dtContact.AcceptChanges();
			}
		}

		void DeleteContact()
		{
			if (dtContact == null)
				return;

			if (bdsContact.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsContact.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			string strSQLExec = "UPDATE R08Contact SET Deleted = 1 WHERE Contact_ID = '" + (string)drCurrent["Contact_ID"] + "'";
			if (SQLExec.Execute(strSQLExec))
			{
				bdsContact.RemoveAt(bdsContact.Position);
				dtContact.AcceptChanges();
			}
		}

		void FillData_Contact()
		{
			if (bdsToDo.Position < 0)
				return;

			DataRow drToDo = ((DataRowView)bdsToDo.Current).Row;

			txtMa_Dt_Kh.Text = drToDo["Ma_Dt_KH"].ToString();
			txtTen_Dt_Info.Text = CRMLib.GetInfo_Dt(txtMa_Dt_Kh.Text);
			txtNote.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Note", txtMa_Dt_Kh.Text);

			dtContact = DataTool.SQLGetDataTable("R08Contact", "", "Ma_Dt_KH = '" + txtMa_Dt_Kh.Text + "' AND Deleted = 0", "Contact_ID");
			bdsContact.DataSource = dtContact;
			dgvContact.DataSource = bdsContact;
		}

		#endregion

		void tlToDo_MouseClick(object sender, MouseEventArgs e)
		{
			if (bdsToDo.Position < 0)
				return;

			string strColumnName = tlToDo.FocusedColumn.FieldName;

			drCurrent = ((DataRowView)bdsToDo.Current).Row;

			if (strColumnName == "FINISH")
			{
				frmFinish frm = new frmFinish();
				frm.Load(drCurrent);
			}
		}

		void tlToDo_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (bdsToDo.Position < 0)
				return;

			tabControl1.SelectedTab = pageCustomer;
		}

		void cboMa_Dt_CbNv_SelectedValueChanged(object sender, EventArgs e)
		{
			this.FillData("");
		}

		void cboKieu_Nhom_SelectedValueChanged(object sender, EventArgs e)
		{
			this.FillData("");
		}

		void chkProcessing_Only_CheckedChanged(object sender, EventArgs e)
		{
			if (chkProcessing_Only.Checked)
				bdsToDo.Filter = "Finish = false";
			else
				bdsToDo.RemoveFilter();
		}

		protected override void OnClosed(EventArgs e)
		{
			if (Element.frmMain == Element.frmMain)
				Common.EndShowStatus();

			base.OnClosed(e);
		}

		void btNew_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.Edit);
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FilterData();
			
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			this.Delete();
		}

		void frmToDo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F9)
				this.FilterData();
		}

		void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (bdsToDo.Position == 0)
				return;

			if (tabControl1.SelectedTab == pageCustomer)
			{
				FillData_Contact();
			}
		}

		void btEdit_Customer_Click(object sender, EventArgs e)
		{
			this.EditCustomer(enuEdit.Edit);
		}

		void btNew_Contact_Click(object sender, EventArgs e)
		{
			this.EditContact(enuEdit.New);
		}

		void btEdit_Contact_Click(object sender, EventArgs e)
		{
			this.EditContact(enuEdit.Edit);
		}

		void btDelete_Contact_Click(object sender, EventArgs e)
		{
			this.DeleteContact();
		}


	}
}
