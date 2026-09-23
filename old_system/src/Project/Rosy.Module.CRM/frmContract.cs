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
	public partial class frmContract : RosySystem.Customize.frmView
	{
		DataTable dtContract;
		DataTable dtTask = new DataTable();
		DataTable dtPlan;
		DataTable dtContact;
		DataTable dtPayment;

		BindingSource bdsTask = new BindingSource();
		BindingSource bdsPlan = new BindingSource();
		BindingSource bdsContact = new BindingSource();
		BindingSource bdsContract = new BindingSource();
		BindingSource bdsPayment = new BindingSource();

		rsTreeList tlContract = new rsTreeList();

		DataRow drCurrent;
		string strMa_Dt_CbNv = string.Empty;

		public frmContract()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmCustomer_KeyDown);

			bdsContract.PositionChanged += new EventHandler(bdsContract_PositionChanged);
			//cboMa_CbNv.SelectedValueChanged += new EventHandler(cboMa_CbNv_SelectedValueChanged);
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

			////Gắn Ma_CbNv vào ComboBox
			//cboMa_CbNv.Items.Add("*");
			//DataTable dtDmCbNv = SQLExec.ExecuteReturnDt("SELECT * FROM R81DmCbNv WHERE Member_ID <> ''");
			//foreach (DataRow dr in dtDmCbNv.Rows)
			//{
			//    cboMa_CbNv.Items.Add(dr["Ma_CbNv"]);
			//}

			//cboMa_CbNv.Text = strMa_CbNv;
			//if (Common.CheckPermission("SALEADMIN", enuPermission_Type.Allow_Access) || Element.sysIs_Admin)
			//    cboMa_CbNv.Enabled = true;
			//else
			//    cboMa_CbNv.Enabled = false;

			//cboKieu_Nhom.SelectedIndex = 0;

			this.Build();
			this.FillData("");
			this.BindingData();

			this.Show();
		}

		#region Method

		void Build()
		{
			tlContract.strZone = "CONTRACT";
			tlContract.Dock = DockStyle.Fill;
			tlContract.KeyFieldName = "MA_HD";
			tlContract.ParentFieldName = "PARENTFIELD";
			tlContract.BuildTreeList();
			pageContract.Controls.Add(tlContract);

			dgvTask.strZone = "TASK";
			dgvTask.BuildGridView();

			dgvContact.strZone = "CONTACT";
			dgvContact.BuildGridView();

			dgvPlan.strZone = "TASK";
			dgvPlan.BuildGridView();

			dgvPayment.strZone = "PAYMENT";
			dgvPayment.BuildGridView();
		}

		void FillData(string strKey)
		{
			string strSQLExec;
			string strKeyContract;
			string strKieu_Nhom = cboKieu_Nhom.Text;

			strKeyContract = "(0 = 0)";

			if (strKey != string.Empty)
				strKeyContract += " AND " + strKey;

			//if (cboMa_CbNv.Text != "*")
			//    strKeyCustomer += " AND Ma_CbNv = '" + cboMa_CbNv.Text + "'";

			//Customer
			Hashtable htPara = new Hashtable();
			htPara.Add("KIEU_NHOM", cboKieu_Nhom.Text.Substring(0, 1));
			htPara.Add("KEY", strKeyContract);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtContract = SQLExec.ExecuteReturnDt("sp_CRM_GetContract", htPara, CommandType.StoredProcedure);
			bdsContract.DataSource = dtContract;
			tlContract.DataSource = bdsContract;

			foreach (DataRow dr in dtContract.Rows)
				dr["Ten_Dt"] = ((string)dr["Ten_Dt"]).Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\t", "\t").Replace("\\v", "\v");

			//Task
			strSQLExec = @"
				SELECT *, CAST('' AS VARCHAR(200)) AS Ten_Dt 
					FROM R08Task 
					WHERE Is_Plan = 0 AND Task_Type = 'CONTRACT' AND Ma_Hd IN (SELECT Ma_Hd FROM R81DmHd WHERE " + strKeyContract + @") AND Deleted = 0
					ORDER BY Ngay_Gd, Ngay_Dk_Ht";

			dtTask = SQLExec.ExecuteReturnDt(strSQLExec);
			DataColumn dcNew = new DataColumn("FINISH", typeof(bool));
			dcNew.Expression = "IIF(Ngay_Ht > #1/1/1900#, true, false)";
			dtTask.Columns.Add(dcNew);

			bdsTask.DataSource = dtTask;
			dgvTask.DataSource = bdsTask;

			//Plan
			strSQLExec = @"
				SELECT *, CAST('' AS VARCHAR(200)) AS Ten_Dt 
					FROM R08Task 
					WHERE Is_Plan = 1 AND Task_Type = 'CONTRACT' AND Ma_Hd IN (SELECT Ma_Hd FROM R81DmHd WHERE " + strKeyContract + @") AND Deleted = 0
					ORDER BY Ngay_Gd, Ngay_Dk_Ht";

			dtPlan = SQLExec.ExecuteReturnDt(strSQLExec);
			dcNew = new DataColumn("FINISH", typeof(bool));
			dcNew.Expression = "IIF(Ngay_Ht > #1/1/1900#, true, false)";
			dtPlan.Columns.Add(dcNew);

			bdsPlan.DataSource = dtPlan;
			dgvPlan.DataSource = bdsPlan;

			//Contact
			strSQLExec = @"
				SELECT *, CAST('' AS VARCHAR(200)) AS Ten_Dt 
					FROM R08Contact 
					WHERE Ma_Dt_KH IN (SELECT Ma_Dt FROM R81DmHd WHERE " + strKeyContract + @") AND Deleted = 0
					ORDER BY Contact_Name";

			dtContact = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsContact.DataSource = dtContact;
			dgvContact.DataSource = bdsContact;

			//Payment
			strSQLExec = @"
				SELECT *, CAST('' AS VARCHAR(200)) AS Ten_Dt 
					FROM R08Payment WHERE Ma_Hd IN (SELECT Ma_Hd FROM R81DmHd WHERE " + strKeyContract + @")
					ORDER BY Ngay_Thu";

			dtPayment = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsPayment.DataSource = dtPayment;
			dgvPayment.DataSource = bdsPayment;

			//bdsCustomer.Filter = "Ma_Hd LIKE 'NH__%' OR Ma_CbNv = '" + cboMa_CbNv.Text + "'";
			pageContract.Text = "Danh sách hợp đồng (" + tlContract.Nodes.Count.ToString().Trim() + "/" + bdsContract.Count.ToString().Trim() + ")";

			//Nhắc việc
			string strTen_CbNv = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", this.strMa_Dt_CbNv);

			strSQLExec =
				"SELECT COUNT(Task_ID) " +
					" FROM R08Task " +
					" WHERE (Ma_Dt_CbNv_Th IN (SELECT Ma_Dt_CbNv FROM R00Member WHERE Member_ID = '" + this.strMa_Dt_CbNv + "'))" +
					" AND Ngay_Ht <= '1/1/1900'";

			Common.ShowStatus(strTen_CbNv + " có " + SQLExec.ExecuteReturnValue(strSQLExec).ToString() + "  việc phải làm");

			//
			this.ExportControl = tlContract;
			this.bdsSearch = bdsContract;
		}

		void FilterData()
		{
			DataTable dtFilter = new DataTable();

			dtFilter.Columns.Add(new DataColumn("So_Hd", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ky", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ma_Vt_Sp", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tu_Tien_Hd", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Den_Tien_Hd", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt_CbNv_Kd", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt_CbNv_Tk", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Note", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();
			Common.SetDefaultDataRow(ref drFilter);

			//Set Default 
			dtFilter.Rows.Add(drFilter);

			frmCustomer_Dkl frmFilter = new frmCustomer_Dkl();
			frmFilter.Load(drFilter);

			if (frmFilter.isAccept)
			{
				string strFilterKey = "(1=1)";

				if ((string)drFilter["So_Hd"] != "")
					strFilterKey += " AND (So_Hd LIKE N'%" + (string)drFilter["So_Hd"] + "%') ";

				if ((string)drFilter["Ma_Vt_Sp"] != "")
					strFilterKey += " AND (Ma_Vt_Sp = '" + (string)drFilter["Ma_Vt_Sp"] + "') ";

				if (Convert.ToDouble(drFilter["Tu_Tien_Hd"]) != 0)
					strFilterKey += " AND (Tien_Hd >= " + Convert.ToDouble(drFilter["Tu_Tien_Hd"]) + ") ";

				if (Convert.ToDouble(drFilter["Den_Tien_Hd"]) != 0)
					strFilterKey += " AND (Tien_Hd <= " + Convert.ToDouble(drFilter["Den_Tien_Hd"]) + ") ";

				if ((string)drFilter["Ma_Dt_CbNv_Kd"] != "")
					strFilterKey += " AND (Ma_Dt_CbNv_Kd = '" + (string)drFilter["Ma_Dt_CbNv_Kd"] + "') ";

				if ((string)drFilter["Ma_Dt_CbNv_Tk"] != "")
					strFilterKey += " AND (Ma_Dt_CbNv_Tk = '" + (string)drFilter["Ma_Dt_CbNv_Tk"] + "') ";

				if ((string)drFilter["Note"] != "")
					strFilterKey += " AND (Note LIKE N'%" + (string)drFilter["Note"] + "%') ";

				this.FillData(strFilterKey);
			}
		}

		private void BindingData()
		{
			foreach (Control ctrl in splitContainer1.Panel2.Controls)
			{
				if (ctrl.GetType() == typeof(rsTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(rsDateTime) || ctrl.GetType() == typeof(rsComboBox) || ctrl.GetType() == typeof(ComboBox) || ctrl.GetType() == typeof(RichTextBox))
				{
					string strFieldName = ctrl.Name.Substring(3);

					if (((DataTable)bdsContract.DataSource).Columns.Contains(strFieldName))
						ctrl.DataBindings.Add("Text", bdsContract, strFieldName);
				}
			}

			//picHinh.DataBindings.Add("Image", bdsEmployee, "Hinh");
		}

		void EditContract(enuEdit enuNew_Edit)
		{
			if (bdsContract.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (strMa_Dt_CbNv == string.Empty)
			{
				Common.MsgCancel("Tài khoản đăng nhập " + Element.sysUser_Id + " chưa đăng ký với danh sách nhân viên!");
				return;
			}

			//Copy hang hien tai            
			if (bdsContract.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsContract.Current).Row, ref drCurrent);
			else
				drCurrent = dtContract.NewRow();

			//Tính Stt Max
			if (enuNew_Edit == enuEdit.New)
			{
				CRMLib.GetNewMa_Hd(drCurrent);
				drCurrent["Type"] = '3';
				drCurrent["Ma_Dt_CbNv_Kd"] = strMa_Dt_CbNv;
			}

			frmContract_Edit frmEdit = new frmContract_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// Người dùng chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsContract.Position >= 0)
						dtContract.ImportRow(drCurrent);
					else
						dtContract.Rows.Add(drCurrent);

					bdsContract.Position = bdsContract.Find("Ma_Hd", drCurrent["Ma_Hd"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsContract.Current).Row);

					//Đổi mã
					string strMa_Hd = ((string)drCurrent["Ma_Hd"]);
					string strMa_Hd_Old = ((string)drCurrent["Ma_Hd", DataRowVersion.Original]);

					if (strMa_Hd != strMa_Hd_Old && strMa_Hd != string.Empty)
					{
						DataRow[] drs = dtTask.Select("Ma_Hd = '" + strMa_Hd_Old + "'");
						foreach (DataRow dr in drs)
						{
							dr["Ma_Hd"] = strMa_Hd;
						}

						drs = dtPayment.Select("Ma_Hd = '" + strMa_Hd_Old + "'");
						foreach (DataRow dr in drs)
						{
							dr["Ma_Hd"] = strMa_Hd;
						}
					}
				}

				dtContract.AcceptChanges();
			}
			//else
			//    dtDmBp.RejectChanges();

		}

		void EditTask(enuEdit enuNew_Edit)
		{
			if (bdsContract.Position < 0)
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

			DataRow drContract = ((DataRowView)bdsContract.Current).Row;

			//Copy hang hien tai            
			if (bdsEdit.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsEdit.Current).Row, ref drCurrent);
			else
				drCurrent = dtEdit.NewRow();

			//Tính Stt Max
			if (enuNew_Edit == enuEdit.New)
			{
				CRMLib.GetNewTask_ID(drCurrent);
				drCurrent["Ma_HD"] = ((DataRowView)bdsContract.Current).Row["Ma_Hd"].ToString();
				drCurrent["Task_Type"] = "CONTRACT";
				drCurrent["Ma_Dt_CbNv"] = strMa_Dt_CbNv;
				drCurrent["Ngay_Gd"] = DateTime.Now;
				drCurrent["Ngay_Dk_Ht"] = DBNull.Value;
				drCurrent["Ngay_Ht"] = DBNull.Value;
				drCurrent["Is_Plan"] = (tabDetail.SelectedTab == pagePlan);
			}

			drCurrent["Ten_Dt"] = ((DataRowView)bdsContract.Current).Row["Ten_Dt"];

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

					drContract["So_Lan_Gd"] = Convert.ToInt32(drContract["So_Lan_Gd"]) + 1;
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
			if (bdsContract.Position < 0)
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
				drCurrent["Ma_Dt_KH"] = ((DataRowView)bdsContract.Current).Row["Ma_Dt"].ToString();
			}

			drCurrent["Ten_Dt"] = ((DataRowView)bdsContract.Current).Row["Ten_Dt"];

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

		void EditPayment(enuEdit enuNew_Edit)
		{
			if (bdsContract.Position < 0)
				return;

			if (bdsPayment.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (strMa_Dt_CbNv == string.Empty)
			{
				Common.MsgCancel("Tài khoản đăng nhập " + Element.sysUser_Id + " chưa đăng ký với danh sách nhân viên!");
				return;
			}

			//Copy hang hien tai            
			if (bdsPayment.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsPayment.Current).Row, ref drCurrent);
			else
				drCurrent = dtPayment.NewRow();

			//Tính Stt Max
			if (enuNew_Edit == enuEdit.New)
			{
				drCurrent["Ma_Hd"] = ((DataRowView)bdsContract.Current).Row["Ma_Hd"].ToString();
			}

			drCurrent["Ten_Dt"] = ((DataRowView)bdsContract.Current).Row["Ten_Dt"];

			frmPayment_Edit frmEdit = new frmPayment_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// Người dùng chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsPayment.Position >= 0)
						dtPayment.ImportRow(drCurrent);
					else
						dtPayment.Rows.Add(drCurrent);

					bdsPayment.Position = bdsPayment.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsPayment.Current).Row);

				dtContact.AcceptChanges();
			}
			//else
			//    dtContact.RejectChanges();
		}

		void DeleteContract()
		{
			if (bdsContract.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsContract.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			string strSQLExec = "UPDATE R81DmHd SET Deleted = 1 WHERE Ma_Hd = '" + (string)drCurrent["Ma_Hd"] + "'";
			if (SQLExec.Execute(strSQLExec))
			{
				bdsContract.RemoveAt(bdsContract.Position);
				dtContract.AcceptChanges();
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

		void DeletePayment()
		{
			if (bdsPayment.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsPayment.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			string strSQLExec = "DELETE FROM R08Payment WHERE Ident00 = " + Convert.ToInt32(drCurrent["Ident00"]) + "";
			if (SQLExec.Execute(strSQLExec))
			{
				bdsPayment.RemoveAt(bdsPayment.Position);
				dtPayment.AcceptChanges();
			}
		}

		void ViewToDo()
		{
			if (bdsContract.Count <= 0)
				return;

			string strMa_Hd = (string)((DataRowView)bdsContract.Current)["Ma_Hd"];

			frmToDo frm = new frmToDo();
			frm.Load(strMa_Hd);
		}

		#endregion

		#region Events

		void bdsContract_PositionChanged(object sender, EventArgs e)
		{
			if (bdsContract.Current == null)
				return;

			drCurrent = ((DataRowView)bdsContract.Current).Row;

			bdsTask.Filter = "Ma_Hd = '" + (string)drCurrent["Ma_Hd"] + "'";
			bdsPlan.Filter = "Ma_Hd = '" + (string)drCurrent["Ma_Hd"] + "'";
			bdsContact.Filter = "Ma_Dt_KH = '" + (string)drCurrent["Ma_Dt"] + "'";
			bdsPayment.Filter = "Ma_Hd = '" + (string)drCurrent["Ma_Hd"] + "'";

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
			this.EditContract(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			this.EditContract(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			if (bdsContract.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsContract.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			string strSQLExec = "UPDATE R81DmHd SET Deleted = 1 WHERE Ma_Hd = '" + (string)drCurrent["Ma_Hd"] + "'";
			if (SQLExec.Execute(strSQLExec))
			{
				bdsContract.RemoveAt(bdsContract.Position);
				dtContract.AcceptChanges();
			}
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FilterData();
		}

		void btNewDetail_Click(object sender, EventArgs e)
		{
			if (tabDetail.SelectedTab == pageTask || tabDetail.SelectedTab == pagePlan)
				this.EditTask(enuEdit.New);
			else if (tabDetail.SelectedTab == pageContact)
				this.EditContact(enuEdit.New);
			else if (tabDetail.SelectedTab == pagePayment)
				this.EditPayment(enuEdit.New);
		}

		void btEditDetail_Click(object sender, EventArgs e)
		{
			if (tabDetail.SelectedTab == pageTask || tabDetail.SelectedTab == pagePlan)
				this.EditTask(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageContact)
				this.EditContact(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pagePayment)
				this.EditPayment(enuEdit.Edit);
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
						tabContract.SelectedIndex = 0;

						if (pageContract.Focused || tlContract.Focused)
						{
							dgvTask.Focus();
						}
						else
						{
							tlContract.Focus();
						}
						return;
					case Keys.D2:
					case Keys.Oem2:
						tabDetail.SelectedIndex = 1;
						dgvContact.Focus();
						return;
					case Keys.D3:
					case Keys.Oem3:
						tabDetail.SelectedIndex = 3;
						dgvPlan.Focus();
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
					if (pageContract.Focused || tlContract.Focused)
						this.EditContract(enuEdit.New);
					else
					{
						if (pageTask.Focused || dgvTask.Focused)
							this.EditTask(enuEdit.New);
						else if (pagePlan.Focused || dgvPlan.Focused)
							this.EditTask(enuEdit.New);
						else if (pageContact.Focused || dgvContact.Focused)
							this.EditContact(enuEdit.New);
						else if (pagePayment.Focused || dgvPayment.Focused)
							this.EditPayment(enuEdit.New);
					}
					return;
				case Keys.F3:
					if (pageContract.Focused || tlContract.Focused)
						this.EditContract(enuEdit.Edit);
					else
					{
						if (pageTask.Focused || dgvTask.Focused)
							this.EditTask(enuEdit.Edit);
						else if (pagePlan.Focused || dgvPlan.Focused)
							this.EditTask(enuEdit.Edit);
						else if (pageContact.Focused || dgvContact.Focused)
							this.EditContact(enuEdit.Edit);
						else if (pagePayment.Focused || dgvPayment.Focused)
							this.EditPayment(enuEdit.Edit);

					}
					return;
				case Keys.F9:
					this.FilterData();
					return;

				case Keys.F12:
					if (pageContract.Focused || tlContract.Focused)
						ViewToDo();
					return;
				case Keys.F8:
					if (pageContract.Focused || tlContract.Focused)
						this.DeleteContact();
					else
					{
						if (pageTask.Focused || dgvTask.Focused)
							this.DeleteTask();
						else if (pagePlan.Focused || dgvPlan.Focused)
							this.DeleteTask();
						else if (pageContact.Focused || dgvContact.Focused)
							this.DeleteContact();
						else if (pagePayment.Focused || dgvPayment.Focused)
							this.DeletePayment();
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
