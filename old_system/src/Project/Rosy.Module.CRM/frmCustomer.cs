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
	public partial class frmCustomer : RosySystem.Customize.frmView
	{
		DataTable dtCustomer;
		DataTable dtTask;
		DataTable dtPlan;
		DataTable dtContact;
		DataTable dtContract;

		BindingSource bdsCustomer = new BindingSource();
		BindingSource bdsTask = new BindingSource();
		BindingSource bdsPlan = new BindingSource();
		BindingSource bdsContact = new BindingSource();
		BindingSource bdsContract = new BindingSource();

		rsTreeList tlCustomer = new rsTreeList();

		DataRow drCurrent;
		string strMa_Dt_CbNv = string.Empty;

		public frmCustomer()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmCustomer_KeyDown);

			bdsCustomer.PositionChanged += new EventHandler(bdsCustomer_PositionChanged);
			cboMa_Dt_CbNv.SelectedValueChanged += new EventHandler(cboMa_CbNv_SelectedValueChanged);
			cboKieu_Nhom.SelectedValueChanged += new EventHandler(cboKieu_Nhom_SelectedValueChanged);

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btFilter.Click += new EventHandler(btFilter_Click);

			btTaskNew.Click += new EventHandler(btNewDetail_Click);
			btTaskEdit.Click += new EventHandler(btEditDetail_Click);
			btTaskDelete.Click += new EventHandler(btDeleteDetail_Click);

			dgvTask.CellClick += new DataGridViewCellEventHandler(dgvTask_CellClick);
			dgvPlan.CellClick += new DataGridViewCellEventHandler(dgvPlan_CellClick);
		}

		public override void Load()
		{
			strMa_Dt_CbNv = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Ma_Dt_CbNv), '') FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'");
			int iIndex = 0;

			//Gắn Ma_Dt_CbNv vào ComboBox
			cboMa_Dt_CbNv.Items.Add("*");
			DataTable dtDmCbNv = SQLExec.ExecuteReturnDt("SELECT DISTINCT Ma_Dt_CbNv FROM R81DmDt WHERE Ma_Dt_CbNv IN (SELECT Ma_Dt_CbNv FROM R00Member)");
			foreach (DataRow dr in dtDmCbNv.Rows)
			{
				cboMa_Dt_CbNv.Items.Add(dr["Ma_Dt_CbNv"]);
				iIndex ++;

				if ((string)dr["Ma_Dt_CbNv"] == strMa_Dt_CbNv)
					cboMa_Dt_CbNv.SelectedIndex = iIndex;
			}

			//cboMa_CbNv.Text = strMa_CbNv;
			if (Common.CheckPermission("SALEADMIN", enuPermission_Type.Allow_Access) || Element.sysIs_Admin)
				cboMa_Dt_CbNv.Enabled = true;
			else
				cboMa_Dt_CbNv.Enabled = false;

			cboKieu_Nhom.SelectedIndex = 0;

			this.Build();
			this.FillData("");
			this.BindingData();

			this.Show();
		}

		#region Method

		void Build()
		{
			tlCustomer.strZone = "CUSTOMER";
			tlCustomer.Dock = DockStyle.Fill;
			tlCustomer.KeyFieldName = "MA_DT";
			tlCustomer.ParentFieldName = "PARENTFIELD";
			tlCustomer.BuildTreeList();
			pageCustomer.Controls.Add(tlCustomer);

			dgvTask.strZone = "TASK";
			dgvTask.BuildGridView();

			dgvContact.strZone = "CONTACT";
			dgvContact.BuildGridView();

			dgvContract.strZone = "CONTRACT";
			dgvContract.BuildGridView();

			dgvPlan.strZone = "TASK";
			dgvPlan.BuildGridView();
		}

		void FillData(string strKey)
		{
			string strSQLExec;
			string strKeyCustomer;

			strKeyCustomer = "(Deleted <> 1)";

			if (strKey != string.Empty)
				strKeyCustomer += " AND " + strKey;

			if (cboMa_Dt_CbNv.Text != "*")
				strKeyCustomer += " AND Ma_Dt_CbNv = '" + cboMa_Dt_CbNv.Text + "'";

			//Customer
			Hashtable htPara = new Hashtable();
			htPara.Add("KIEU_NHOM", cboKieu_Nhom.Text.Substring(0, 1));
			htPara.Add("KEY", strKeyCustomer);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtCustomer = SQLExec.ExecuteReturnDt("sp_CRM_GetCustomer", htPara, CommandType.StoredProcedure);
			bdsCustomer.DataSource = dtCustomer;
			tlCustomer.DataSource = bdsCustomer;

			//Task
			strSQLExec = @"
				SELECT *, CAST('' AS NVARCHAR(400)) AS Ten_Dt 
					FROM R08Task 
					WHERE Is_Plan = 0 AND Task_Type = 'CUSTOMER' AND Ma_Dt_KH IN (SELECT Ma_Dt FROM R81DmDt WHERE " + strKeyCustomer + @") AND Deleted = 0
					ORDER BY Ngay_Gd, Ngay_Dk_Ht";

			dtTask = SQLExec.ExecuteReturnDt(strSQLExec);
			DataColumn dcNew = new DataColumn("FINISH", typeof(bool));
			dcNew.Expression = "IIF(Ngay_Ht > #1/1/1900#, true, false)";
			dtTask.Columns.Add(dcNew);

			bdsTask.DataSource = dtTask;
			dgvTask.DataSource = bdsTask;

			//Plan
			strSQLExec = @"
				SELECT * 
					FROM R08Task 
					WHERE Is_Plan = 1 AND Task_Type = 'CUSTOMER' AND Ma_Dt_KH IN (SELECT Ma_Dt FROM R81DmDt WHERE " + strKeyCustomer + @") AND Deleted = 0
					ORDER BY Ngay_Gd, Ngay_Dk_Ht";

			dtPlan = SQLExec.ExecuteReturnDt(strSQLExec);
			dcNew = new DataColumn("FINISH", typeof(bool));
			dcNew.Expression = "IIF(Ngay_Ht > #1/1/1900#, true, false)";
			dtPlan.Columns.Add(dcNew);

			bdsPlan.DataSource = dtPlan;
			dgvPlan.DataSource = bdsPlan;

			//Contact
			strSQLExec = @"
				SELECT * 
					FROM R08Contact WHERE Ma_Dt_KH IN (SELECT Ma_Dt FROM R81DmDt WHERE " + strKeyCustomer + @") AND Deleted = 0
					ORDER BY Contact_Name";

			dtContact = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsContact.DataSource = dtContact;
			dgvContact.DataSource = bdsContact;

			//Contract
			strSQLExec = @"
				SELECT * 
					FROM R81DmHd WHERE Ma_Dt IN (SELECT Ma_Dt FROM R81DmDt WHERE " + strKeyCustomer + @") 
					ORDER BY Ngay_Ky";

			dtContract = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsContract.DataSource = dtContract;
			dgvContract.DataSource = bdsContract;

			//bdsCustomer.Filter = "Ma_Dt LIKE 'NH__%' OR Ma_CbNv = '" + cboMa_CbNv.Text + "'";
			pageCustomer.Text = "Danh sách khách hàng (" + tlCustomer.Nodes.Count.ToString().Trim() + "/" + bdsCustomer.Count.ToString().Trim() + ")";

            //Nhắc việc
			string strTen_Dt_CbNv = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", this.strMa_Dt_CbNv);

			strSQLExec = @"
				SELECT COUNT(Task_ID) 
					FROM R08Task 
					WHERE (Ma_Dt_CbNv_Th IN (SELECT Ma_Dt_CbNv FROM R00Member WHERE Member_ID = '" + this.strMa_Dt_CbNv + @"')) AND Deleted = 0
					AND Ngay_Ht <= '1/1/1900'";

			Common.ShowStatus(strTen_Dt_CbNv + " có " + SQLExec.ExecuteReturnValue(strSQLExec).ToString() + "  việc phải làm");

			//
			this.ExportControl = tlCustomer;
			this.bdsSearch = bdsCustomer;
		}

		private void BindingData()
		{
			foreach (Control ctrl in splitContainer1.Panel2.Controls)
			{
				if (ctrl.GetType() == typeof(rsTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(rsDateTime) || ctrl.GetType() == typeof(rsComboBox) || ctrl.GetType() == typeof(ComboBox) || ctrl.GetType() == typeof(RichTextBox))
				{
					string strFieldName = ctrl.Name.Substring(3);

					if (((DataTable)bdsCustomer.DataSource).Columns.Contains(strFieldName))
						ctrl.DataBindings.Add("Text", bdsCustomer, strFieldName);
				}
			}

			//picHinh.DataBindings.Add("Image", bdsEmployee, "Hinh");
		}

		void FilterData()
		{
			DataTable dtFilter = new DataTable();

			dtFilter.Columns.Add(new DataColumn("Ngay_Gd1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Gd2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Tinh_Trang", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ten_Dt", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Dia_Chi", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("So_Phone", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("So_Fax", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Email", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Website", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Kv", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("SP_Used", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Nam_Used", typeof(int)));
			dtFilter.Columns.Add(new DataColumn("Von_CSH", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Nganh_Nghe", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Quy_Mo", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Note", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();
			Common.SetDefaultDataRow(ref drFilter);

			//Set Default 
			drFilter["Ngay_Gd1"] = Element.sysNgay_Ct1;
			drFilter["Ngay_Gd2"] = Element.sysNgay_Ct2;
			drFilter["Tinh_Trang"] = "*";
			dtFilter.Rows.Add(drFilter);

			frmCustomer_Dkl frmFilter = new frmCustomer_Dkl();
			frmFilter.Load(drFilter);

			if (frmFilter.isAccept)
			{
				string strNgay_Gd1 = Library.DateToStr((DateTime)drFilter["Ngay_Gd1"]);
				string strNgay_Gd2 = Library.DateToStr((DateTime)drFilter["Ngay_Gd2"]);

				string strFilterKey = "(1=1)";

				if (strNgay_Gd1.Replace(" ", "") != "//" && strNgay_Gd2.Replace(" ", "") != "//")
					strFilterKey +=
						" AND (Ngay_Gd BETWEEN '" + strNgay_Gd1 + "' AND '" + strNgay_Gd2 + "' OR " +
							" Ma_Dt IN (SELECT DISTINCT Ma_Dt_KH FROM R08Task WHERE Task_Type = 'CUSTOMER' AND Ngay_Gd BETWEEN '" + strNgay_Gd1 + "' AND '" + strNgay_Gd2 + "'))";

				if ((string)drFilter["Tinh_Trang"] != "*" && (string)drFilter["Tinh_Trang"] != "")
				{
					strFilterKey += " AND (Tinh_Trang = '" + (string)drFilter["Tinh_Trang"] + "')";
				}

				if ((string)drFilter["Ten_Dt"] != "")
					strFilterKey += " AND (Ten_Dt LIKE N'%" + (string)drFilter["Ten_Dt"] + "%') ";

				if ((string)drFilter["So_Phone"] != "")
					strFilterKey += " AND (So_Phone LIKE N'%" + (string)drFilter["So_Phone"] + "%') ";

				if ((string)drFilter["So_Fax"] != "")
					strFilterKey += " AND (So_Fax LIKE N'%" + (string)drFilter["So_Fax"] + "%') ";

				if ((string)drFilter["Email"] != "")
					strFilterKey += " AND (Email LIKE N'%" + (string)drFilter["Email"] + "%') ";

				if ((string)drFilter["Website"] != "")
					strFilterKey += " AND (Website LIKE N'%" + (string)drFilter["Website"] + "%') ";

				if ((string)drFilter["Ma_Kv"] != "")
					strFilterKey += " AND (Ma_Kv = '" + (string)drFilter["Ma_Kv"] + "') ";

				if ((string)drFilter["SP_Used"] != "")
					strFilterKey += " AND (SP_Used LIKE N'%" + (string)drFilter["SP_Used"] + "%') ";

				if ((int)drFilter["Nam_Used"] != 0)
					strFilterKey += " AND (Nam_Used = " + ((int)drFilter["Nam_Used"]).ToString() + ") ";

				if ((string)drFilter["Von_CSH"] != "")
					strFilterKey += " AND (Von_CSH LIKE N'%" + (string)drFilter["Von_CSH"] + "%') ";

				if ((string)drFilter["Nganh_Nghe"] != "")
					strFilterKey += " AND (Nganh_Nghe LIKE N'%" + (string)drFilter["Nganh_Nghe"] + "%') ";

				if ((string)drFilter["Quy_Mo"] != "")
					strFilterKey += " AND (Quy_Mo LIKE N'%" + (string)drFilter["Quy_Mo"] + "%') ";

				if ((string)drFilter["Note"] != "")
					strFilterKey += " AND (Note LIKE N'%" + (string)drFilter["Note"] + "%') ";

				this.FillData(strFilterKey);
			}
		}

		void EditCustomer(enuEdit enuNew_Edit)
		{
			if (bdsCustomer.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (strMa_Dt_CbNv == string.Empty)
			{
				Common.MsgCancel("Tài khoản đăng nhập " + Element.sysUser_Id + " chưa đăng ký với danh sách nhân viên!");
				return;
			}

			//Copy hang hien tai            
			if (bdsCustomer.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCustomer.Current).Row, ref drCurrent);
			else
				drCurrent = dtCustomer.NewRow();

			//Tính Stt Max
			if (enuNew_Edit == enuEdit.New)
			{
				CRMLib.GetNewMa_Dt(drCurrent);
				drCurrent["Type"] = '3';
				drCurrent["Ma_Dt_CbNv"] = strMa_Dt_CbNv;
				drCurrent["Ngay_Gd"] = DateTime.Now;
			}

			frmCustomer_Edit frmEdit = new frmCustomer_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// Người dùng chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCustomer.Position >= 0)
						dtCustomer.ImportRow(drCurrent);
					else
						dtCustomer.Rows.Add(drCurrent);

					bdsCustomer.Position = bdsCustomer.Find("MA_DT", drCurrent["MA_DT"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCustomer.Current).Row);

				dtCustomer.AcceptChanges();
			}
			//else
			//    dtDmBp.RejectChanges();

		}

		void EditTask(enuEdit enuNew_Edit)
		{
			if (bdsCustomer.Position < 0)
				return;

			BindingSource bdsEdit;
			DataTable dtEdit;

			bdsEdit = (tabDetail.SelectedTab == pageTask) ? bdsTask : bdsPlan;
			dtEdit = (tabDetail.SelectedTab == pageTask) ? dtTask : dtPlan;

			if (bdsEdit.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (strMa_Dt_CbNv == string.Empty)
			{
				Common.MsgCancel("Tài khoản đăng nhập " + Element.sysUser_Id + " chưa đăng ký với danh sách nhân viên!");
				return;
			}

			DataRow drCustomer = ((DataRowView)bdsCustomer.Current).Row;

			//Copy hang hien tai            
			if (bdsEdit.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsEdit.Current).Row, ref drCurrent);
			else
				drCurrent = dtEdit.NewRow();

			//Tính Stt Max
			if (enuNew_Edit == enuEdit.New)
			{
				CRMLib.GetNewTask_ID(drCurrent);
				drCurrent["Ma_Dt_KH"] = ((DataRowView)bdsCustomer.Current).Row["Ma_Dt"].ToString();
				drCurrent["Task_Type"] = "CUSTOMER";
				drCurrent["Ma_Dt_CbNv"] = strMa_Dt_CbNv;
				drCurrent["Ngay_Gd"] = DateTime.Now;
				drCurrent["Ngay_Dk_Ht"] = DBNull.Value;
				drCurrent["Ngay_Ht"] = DBNull.Value;
				drCurrent["Is_Plan"] = (tabDetail.SelectedTab == pagePlan);
			}

			if (drCurrent.Table.Columns.Contains("Ten_Dt"))
				drCurrent["Ten_Dt"] = (string)drCustomer["Ten_Dt"];

			frmToDo_Edit frmEdit = new frmToDo_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// Người dùng chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsEdit.Position >= 0)
						dtEdit.ImportRow(drCurrent);
					else
						dtEdit.Rows.Add(drCurrent);

					drCustomer["So_Lan_Gd"] = Convert.ToInt32(drCustomer["So_Lan_Gd"]) + 1;
					bdsEdit.Position = bdsEdit.Find("Task_ID", drCurrent["Task_ID"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsEdit.Current).Row);

				dtEdit.AcceptChanges();
			}
			//else
			//    dtTask.RejectChanges();
		}

		void EditContact(enuEdit enuNew_Edit)
		{
			if (bdsCustomer.Position < 0)
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
				drCurrent["Ma_Dt_KH"] = ((DataRowView)bdsCustomer.Current).Row["Ma_Dt"].ToString();
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
			//else
			//    dtContact.RejectChanges();
		}

		void DeleteCustomer()
		{
			if (bdsCustomer.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCustomer.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			string strSQLExec = "UPDATE R81DmDt SET Deleted = 1 WHERE Ma_Dt = '" + (string)drCurrent["Ma_Dt"] + "'";
			if (SQLExec.Execute(strSQLExec))
			{
				bdsCustomer.RemoveAt(bdsCustomer.Position);
				dtCustomer.AcceptChanges();
			}
		}

		void DeleteTask()
		{
			BindingSource bdsEdit;
			DataTable dtEdit;

			bdsEdit = (tabDetail.SelectedTab == pageTask) ? bdsTask : bdsPlan;
			dtEdit = (tabDetail.SelectedTab == pageTask) ? dtTask : dtPlan;
			
			if (bdsEdit.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsEdit.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			string strSQLExec = "UPDATE R08Task SET Deleted = 1 WHERE Task_ID = '" + (string)drCurrent["Task_ID"] + "'";
			if (SQLExec.Execute(strSQLExec))
			{
				bdsEdit.RemoveAt(bdsEdit.Position);
				dtEdit.AcceptChanges();
			}
		}

		void DeleteContact()
		{
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

		#endregion

		#region Events

		void bdsCustomer_PositionChanged(object sender, EventArgs e)
		{
			if (bdsCustomer.Current == null)
				return;

			drCurrent = ((DataRowView)bdsCustomer.Current).Row;

			bdsTask.Filter = "Ma_Dt_KH = '" + (string)drCurrent["Ma_Dt"] + "'";
			bdsPlan.Filter = "Ma_Dt_KH = '" + (string)drCurrent["Ma_Dt"] + "'";
			bdsContact.Filter = "Ma_Dt_KH = '" + (string)drCurrent["Ma_Dt"] + "'";
			bdsContract.Filter = "Ma_Dt = '" + (string)drCurrent["Ma_Dt"] + "'";

			txtTen_Dt_Info.Text = CRMLib.GetInfo_Dt((string)drCurrent["Ma_Dt"]);

			//if (tlCustomer.CurrentRow != null)
			//    lblRecord.Text = (tlCustomer.CurrentRow.Index + 1).ToString() + "/" + tlCustomer.RowCount.ToString();
			//else
			//    lblRecord.Text = "0/" + tlCustomer.RowCount.ToString();
		}

		void cboMa_CbNv_SelectedValueChanged(object sender, EventArgs e)
		{
			//if (cboMa_CbNv.Text == "*")
			//    bdsCustomer.RemoveFilter();
			//else
			//    bdsCustomer.Filter = "Ma_CbNv = '" + cboMa_CbNv.Text + "'";
			this.FillData("");
		}

		void cboKieu_Nhom_SelectedValueChanged(object sender, EventArgs e)
		{
			this.FillData("");
		}

		void btNew_Click(object sender, EventArgs e)
		{
			this.EditCustomer(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			this.EditCustomer(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			DeleteCustomer();
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FilterData();
		}

		void btNewDetail_Click(object sender, EventArgs e)
		{
			if (tabDetail.SelectedTab == pageTask)
				this.EditTask(enuEdit.New);
			else if (tabDetail.SelectedTab == pageContact)
				this.EditContact(enuEdit.New);
			else if (tabDetail.SelectedTab == pagePlan)
				this.EditTask(enuEdit.New);
			//else
			//    this.EditContract(enuEdit.New);
		}

		void btEditDetail_Click(object sender, EventArgs e)
		{
			if (tabDetail.SelectedTab == pageTask)
				this.EditTask(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageContact)
				this.EditContact(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pagePlan)
				this.EditTask(enuEdit.Edit);
		}

		void btDeleteDetail_Click(object sender, EventArgs e)
		{
			if (tabDetail.SelectedTab == pageTask)
				this.DeleteTask();
			else if (tabDetail.SelectedTab == pageContact)
				this.DeleteContact();
			else if (tabDetail.SelectedTab == pagePlan)
				this.DeleteTask();
		}

		void frmCustomer_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.D1:
					case Keys.Oem1:
						tabDetail.SelectedIndex = 0;
						tabCustomer.SelectedIndex = 0;

						if (pageCustomer.Focused || tlCustomer.Focused)
						{
							dgvContact.Focus();
						}
						else
						{
							tlCustomer.Focus();
						}
						return;
					case Keys.D2:
					case Keys.Oem2:
						tabDetail.SelectedIndex = 1;
						dgvTask.Focus();
						return;
					case Keys.D3:
					case Keys.Oem3:
						tabDetail.SelectedIndex = 2;
						dgvPlan.Focus();
						return;
					case Keys.D4:
					case Keys.Oem4:
						tabDetail.SelectedIndex = 3;
						dgvContract.Focus();
						return;
				}

				//if (e.KeyValue == 192)
				//{
				//    if (pageCustomer.Focused || dgvCustomer.Focused)
				//    {
				//        if (pageTask.Focused || dgvTask.Focused)
				//        {
				//            tabDetail.SelectedIndex = 1;
				//            dgvContact.Focus();
				//        }
				//        else if (pageContact.Focused || dgvContact.Focused)
				//        {
				//            tabDetail.SelectedIndex = 2;
				//            dgvContract.Focus();
				//        }
				//        else
				//        {
				//            tabDetail.SelectedIndex = 0;
				//            dgvTask.Focus();
				//        }
				//    }
				//    else
				//    {
				//        pageCustomer.Focus();
				//        dgvCustomer.Focus();
				//    }
				//}

			}
		}

		void dgvTask_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0)
				return;

			string strColumnName = dgvTask.Columns[e.ColumnIndex].Name;
			drCurrent = ((DataRowView)bdsTask.Current).Row;

			if (strColumnName == "FINISH")
			{
				frmFinish frm = new frmFinish();
				frm.Load(drCurrent);
			}
		}

		void dgvPlan_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0)
				return;

			string strColumnName = dgvPlan.Columns[e.ColumnIndex].Name;
			drCurrent = ((DataRowView)bdsPlan.Current).Row;

			if (strColumnName == "FINISH")
			{
				frmFinish frm = new frmFinish();
				frm.Load(drCurrent);
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F2:
					if (pageCustomer.Focused || tlCustomer.Focused)
						this.EditCustomer(enuEdit.New);
					else
					{
						if (pageTask.Focused || dgvTask.Focused)
							this.EditTask(enuEdit.New);
						else if (pageContact.Focused || dgvContact.Focused)
							this.EditContact(enuEdit.New);
						else if (pagePlan.Focused || dgvPlan.Focused)
							this.EditTask(enuEdit.New);
						//else if (pageContract.Focused || dgvContract.Focused)
						//    this.EditContract(enuEdit.New);
					}
					return;
				case Keys.F3:
					if (pageCustomer.Focused || tlCustomer.Focused)
						this.EditCustomer(enuEdit.Edit);
					else
					{
						if (pageTask.Focused || dgvTask.Focused)
							this.EditTask(enuEdit.Edit);
						else if (pageContact.Focused || dgvContact.Focused)
							this.EditContact(enuEdit.Edit);
						else if (pagePlan.Focused || dgvPlan.Focused)
							this.EditTask(enuEdit.Edit);

						//else if (pageContract.Focused || dgvContract.Focused)
						//    this.EditContract(enuEdit.Edit);
					}
					return;
				case Keys.F9:
					this.FilterData();
					return;
				case Keys.F8:
					if (pageCustomer.Focused || tlCustomer.Focused)
						this.DeleteCustomer();
					else
					{
						if (pageTask.Focused || dgvTask.Focused)
							this.DeleteTask();
						else if (pageContact.Focused || dgvContact.Focused)
							this.DeleteContact();
						else if (pagePlan.Focused || dgvPlan.Focused)
							this.DeleteTask();
						//else if (pageContract.Focused || dgvContract.Focused)
						//    this.DeleteContract(enuEdit.Edit);
					}
					return;

			}

			base.OnKeyDown(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
		}

		#endregion
	}
}
