using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;
using RosyList;

namespace RosyModule.CRM
{
	public partial class frmToDo_Edit : RosySystem.Customize.frmEdit
	{
		DataTable dtTask_Kh;
		DataTable dtTask_CbNv;

		BindingSource bdsTask_Kh = new BindingSource();
		BindingSource bdsTask_CbNv = new BindingSource();

		DataRow drCurrent;

		public frmToDo_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			this.KeyDown += new KeyEventHandler(frmToDo_Edit_KeyDown);

			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
			txtMa_Dt_CbNv_Th.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Th_Validating);
			txtTinh_Trang_Gd.Validating += new CancelEventHandler(txtTinh_Trang_Gd_Validating);
			txtSubject.Validating += new CancelEventHandler(txtSubject_Validating);

			txtMa_Dt_Kh.Validating += new CancelEventHandler(txtMa_Dt_Kh_Validating);
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
			txtNgay_Dk_Ht.Validated += new EventHandler(txtNgay_Dk_Ht_Validated);
			txtNgay_Ht.Validated += new EventHandler(txtNgay_Ht_Validated);
			numSo_Ngay_Dk_Ht.Validated += new EventHandler(numSo_Ngay_Dk_Ht_Validated);
			numSo_Ngay_Ht.Validated += new EventHandler(numSo_Ngay_Ht_Validated);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			if (drEdit.Table.Columns.Contains("Ten_Dt"))
				txtTen_Dt.Text = CRMLib.GetInfo_Dt(drEdit["Ma_Dt_Kh"].ToString());

			BindingLanguage();
			LoadDicName();

			Calc_So_Ngay();

			if (enuNew_Edit == enuEdit.New)
			{
				string strMa_Dt_CbNv = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Ma_Dt_CbNv), '') FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'");

				txtMa_Dt_CbNv.Text = strMa_Dt_CbNv;
				txtMa_Dt_CbNv_Th.Text = strMa_Dt_CbNv;
			}
			else
			{
				txtMa_Dt_Kh.Enabled = false;
				txtMa_Hd.Enabled = false;
			}

			this.Build();
			this.FillData();

			this.ShowDialog();
		}

		void LoadDicName()
		{
			//Ma_Dt_CbNv
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
			{
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			}
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

			//Ma_CbNv_Th
			if (txtMa_Dt_CbNv_Th.Text.Trim() != string.Empty)
			{
				lbtTen_Dt_CbNv_Th.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv_Th.Text.Trim());
			}
			else
				lbtTen_Dt_CbNv_Th.Text = string.Empty;

			//Chu_De
			if (txtSubject.Text.Trim() != string.Empty)
			{
				//lbtTen_Subject.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'Subject' AND Type_ID = '" + txtSubject.Text + "'");
				lbtTen_Subject.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtSubject.Text.Trim(), "Type = 'Subject'");
			}
			else
				lbtTen_Subject.Text = string.Empty;

			//Tinh_Trang_Gd
			if (txtTinh_Trang_Gd.Text.Trim() != string.Empty)
			{
				//lbtTen_Tinh_Trang.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'Tinh_Trang_Gd' AND Type_ID = '" + txtTinh_Trang_Gd.Text + "'");
				lbtTen_Tinh_Trang.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtTinh_Trang_Gd.Text.Trim(), "Type = 'Tinh_Trang_Gd'");
			}
			else
				lbtTen_Tinh_Trang.Text = string.Empty;

		}

		void Build()
		{
			dgvTask_Kh.strZone = "TASK_PARENT";
			dgvTask_Kh.BuildGridView();
			dgvTask_Kh.ResizeGridView();

			dgvTask_CbNv.strZone = "TASK_CBNV";
			dgvTask_CbNv.BuildGridView();
			dgvTask_CbNv.ResizeGridView();
		}

		void FillData()
		{
			string strSQLExec = string.Empty;

			//Task_Parent
			if (enuTask_Type.Text == "CONTRACT")
				strSQLExec = "SELECT T1.*, T2.Ten_Hd AS Parent_Name " +
					" FROM R08Task_Kh T1 LEFT JOIN R81DmHd T2 ON T1.Ma_Dt_Kh = T2.Ma_Hd " +
					" WHERE T1.Task_ID = '" + (string)drEdit["Task_ID"] + "'" +
					" ORDER BY T1.Ma_Dt_Kh";
			else
				strSQLExec = "SELECT T1.*, T2.Ten_Dt AS Parent_Name " +
					" FROM R08Task_Kh T1 LEFT JOIN R81DmDt T2 ON T1.Ma_Dt_Kh = T2.Ma_Dt " +
					" WHERE T1.Task_ID = '" + (string)drEdit["Task_ID"] + "'" +
					" ORDER BY T1.Ma_Dt_Kh";

			dtTask_Kh = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsTask_Kh.DataSource = dtTask_Kh;
			dgvTask_Kh.DataSource = bdsTask_Kh;

			//Task_CbNv
			strSQLExec = "SELECT T1.*, T2.Ten_Dt AS Ten_CbNv " +
					" FROM R08Task_CbNv T1 LEFT JOIN R81DmDt T2 ON T1.Ma_Dt_CbNv = T2.Ma_Dt_CbNv " +
					" WHERE T1.Task_ID = '" + (string)drEdit["Task_ID"] + "'" +
					" ORDER BY T1.Ma_Dt_CbNv";

			dtTask_CbNv = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsTask_CbNv.DataSource = dtTask_CbNv;
			dgvTask_CbNv.DataSource = bdsTask_CbNv;
		}

		void Calc_So_Ngay()
		{
			if (txtNgay_Gd.Text.Replace(" ","") != "//" && txtNgay_Dk_Ht.Text.Replace(" ", "") != "//")
			{
				DateTime dNgay_Dk_Ht = Library.StrToDate(txtNgay_Dk_Ht.Text);
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);

				numSo_Ngay_Dk_Ht.Value = dNgay_Dk_Ht.Subtract(dNgay_Gd).TotalDays + 1;
			}

			if (txtNgay_Gd.Text.Replace(" ", "") != "//" && txtNgay_Ht.Text.Replace(" ", "") != "//")
			{
				DateTime dNgay_Ht = Library.StrToDate(txtNgay_Ht.Text);
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);

				numSo_Ngay_Ht.Value = dNgay_Ht.Subtract(dNgay_Gd).TotalDays + 1;
			}
		}

		void Edit_Task_Parent(enuEdit enuNew_Edit2)
		{
			if (bdsTask_Kh.Position < 0 && enuNew_Edit2 == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsTask_Kh.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsTask_Kh.Current).Row, ref drCurrent);
			else
				drCurrent = dtTask_Kh.NewRow();

			//Ngầm định Task_ID cho Parent
			if (enuNew_Edit2 == enuEdit.New)
				drCurrent["Task_ID"] = drEdit["Task_ID"];

			frmTask_Kh_Edit frmEdit = new frmTask_Kh_Edit();
			frmEdit.Load(enuNew_Edit2, drCurrent, drEdit);

			// Người dùng chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit2 == enuEdit.New)
				{
					if (bdsTask_Kh.Position >= 0)
						dtTask_Kh.ImportRow(drCurrent);
					else
						dtTask_Kh.Rows.Add(drCurrent);

					bdsTask_Kh.Position = bdsTask_Kh.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsTask_Kh.Current).Row);

				dtTask_Kh.AcceptChanges();
			}
			//else
			//    dtTask.RejectChanges();
		}

		void Edit_Task_CbNv(enuEdit enuNew_Edit2)
		{
			if (bdsTask_CbNv.Position < 0 && enuNew_Edit2 == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsTask_CbNv.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsTask_CbNv.Current).Row, ref drCurrent);
			else
				drCurrent = dtTask_CbNv.NewRow();

			//Ngầm định Task_ID cho Parent
			if (enuNew_Edit2 == enuEdit.New)
			{
				drCurrent["Task_ID"] = drEdit["Task_ID"];
			}

			frmTask_CbNv_Edit frmEdit = new frmTask_CbNv_Edit();
			frmEdit.Load(enuNew_Edit2, drCurrent);

			// Người dùng chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit2 == enuEdit.New)
				{
					if (bdsTask_CbNv.Position >= 0)
						dtTask_CbNv.ImportRow(drCurrent);
					else
						dtTask_CbNv.Rows.Add(drCurrent);

					bdsTask_CbNv.Position = bdsTask_CbNv.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsTask_CbNv.Current).Row);

				dtTask_CbNv.AcceptChanges();
			}
			//else
			//    dtTask.RejectChanges();
		}

		void Delete_Task_Parent()
		{
			if (bdsTask_Kh.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsTask_Kh.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R08Task_Kh", drCurrent))
			{
				bdsTask_Kh.RemoveAt(bdsTask_Kh.Position);
				dtTask_Kh.AcceptChanges();
			}
		}

		void Delete_Task_CbNv()
		{
			if (bdsTask_CbNv.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsTask_CbNv.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R08Task_CbNv", drCurrent))
			{
				bdsTask_CbNv.RemoveAt(bdsTask_CbNv.Position);
				dtTask_CbNv.AcceptChanges();
			}
		}

		bool FormCheckValid()
		{
			if (enuTask_Type.Text == "CONTRACT")
			{
				if (!DataTool.SQLCheckExist("R81DmHd", "Ma_Hd", txtMa_Hd.Text))
				{
					Common.MsgCancel("Chưa khai báo mã hợp đồng chưa đúng");
					return false;
				}
			}
			else
			{
				if (txtMa_Dt_Kh.Text == string.Empty)
				{
					Common.MsgCancel("Chưa khai báo mã đối tượng giao dịch");
					return false;
				}

				if (!DataTool.SQLCheckExist("R81DmDt", "Ma_Dt", txtMa_Dt_Kh.Text))
				{
					Common.MsgCancel("Chưa khai báo mã đối tượng chưa đúng");
					return false;
				}
			}

			if (txtMa_Dt_CbNv.Text == string.Empty)
			{
				Common.MsgCancel("Chưa khai báo mã cán bộ nhân viên giao dịch");
				return false;
			}

			if (txtMa_Dt_CbNv_Th.Text == string.Empty)
			{
				Common.MsgCancel("Chưa khai báo mã cán bộ nhân viên thực hiện");
				return false;
			}

			if (txtNgay_Dk_Ht.Text.Replace(" ", "") == "//")
			{
				Common.MsgCancel("Chưa khai báo ngày dự kiến hoàn thành");
				return false;
			}

			if (txtTask_Name.Text == string.Empty)
			{
				Common.MsgCancel("Chưa khai báo tóm tắt nội dung giao dịch");
				return false;
			}

			if (txtNote.Text == string.Empty)
			{
				Common.MsgCancel("Chưa khai báo nội dung giao dịch");
				return false;
			}

			if (!txtNgay_Ht.IsNull)
			{
				if ((int)SQLExec.ExecuteReturnValue("SELECT COUNT(Ident00) FROM R08Task_Kh WHERE Ngay_Ht = '1/1/1900' AND Task_ID = '" + (string)drEdit["Task_ID"] + "'") > 0)
				{
					Common.MsgCancel("Chi tiết giao dịch chưa hoàn tất, bạn phải hoàn thành giao dịch chi tiết trước!");
					return false;
				}
			}

			return true;
		}

		bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R08TASK", ref drEdit))
				return false;

			return true;
		}

		void frmToDo_Edit_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F2:
					if (rsTabControl1.SelectedTab == pageTask_Parent)
						Edit_Task_Parent(enuEdit.New);
					else if (rsTabControl1.SelectedTab == pageTask_CbNv)
						Edit_Task_CbNv(enuEdit.New);
					break;
				case Keys.F3:
					if (rsTabControl1.SelectedTab == pageTask_Parent)
						Edit_Task_Parent(enuEdit.Edit);
					else if (rsTabControl1.SelectedTab == pageTask_CbNv)
						Edit_Task_CbNv(enuEdit.Edit);
					break;
				case Keys.F4:
					if (rsTabControl1.SelectedTab == tabPage1)
						rsTabControl1.SelectedTab = pageTask_Parent;
					else if (rsTabControl1.SelectedTab == pageTask_Parent)
						rsTabControl1.SelectedTab = pageTask_CbNv;
					else
						rsTabControl1.SelectedTab = tabPage1;
					break;
				case Keys.F8:
					if (rsTabControl1.SelectedTab == pageTask_Parent)
						Delete_Task_Parent();
					else if (rsTabControl1.SelectedTab == pageTask_CbNv)
						Delete_Task_CbNv();
					break;
			}
		}

		void txtMa_Dt_Kh_Validating(object sender, CancelEventArgs e)
		{
			if (Common.Inlist(enuTask_Type.Text, "TODO,CUSTOMER"))
			{
				string strValue = txtMa_Dt_Kh.Text.Trim();
				bool bRequire = true;

				DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

				if (bRequire && drLookup == null)
					e.Cancel = true;

				if (drLookup == null)
				{
					txtMa_Dt_Kh.Text = string.Empty;
					txtTen_Dt.Text = string.Empty;
				}
				else
				{
					txtMa_Dt_Kh.Text = drLookup["Ma_Dt"].ToString();
					txtTen_Dt.Text = CRMLib.GetInfo_Dt(drLookup["Ma_Dt"].ToString());
				}
			}
		}

		void txtMa_Hd_Validating(object sender, CancelEventArgs e)
		{
			if (enuTask_Type.Text == "CONTRACT")
			{
				string strValue = txtMa_Hd.Text.Trim();
				bool bRequire = true;

				DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "");

				if (bRequire && drLookup == null)
					e.Cancel = true;

				if (drLookup == null)
				{
					txtMa_Hd.Text = string.Empty;
					lbtTen_Hd.Text = string.Empty;
				}
				else
				{
					txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
					lbtTen_Hd.Text = drLookup["Ten_Hd"].ToString();
				}
			}
		}

		void txtSubject_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtSubject.Text.Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "SUBJECT");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtSubject.Text = string.Empty;
				lbtTen_Subject.Text = string.Empty;
			}
			else
			{
				txtSubject.Text = drLookup["Type_ID"].ToString();
				lbtTen_Subject.Text = drLookup["Type_Name"].ToString();
			}
		}

		void txtTinh_Trang_Gd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTinh_Trang_Gd.Text.Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "Tinh_Trang_Gd");

			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTinh_Trang_Gd.Text = string.Empty;
				lbtTen_Tinh_Trang.Text = string.Empty;
			}
			else
			{
				txtTinh_Trang_Gd.Text = drLookup["Type_ID"].ToString();
				lbtTen_Tinh_Trang.Text = drLookup["Type_Name"].ToString();
			}
		}

		void txtMa_Dt_CbNv_Th_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv_Th.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv_Th.Text = string.Empty;
				lbtTen_Dt_CbNv_Th.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv_Th.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv_Th.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv.Text = string.Empty;
				lbtTen_Dt_CbNv.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void numSo_Ngay_Ht_Validated(object sender, EventArgs e)
		{
			if (txtNgay_Gd.Text.Trim() != "//" && numSo_Ngay_Ht.Value != 0)
			{
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);
				DateTime dNgay_Ht = dNgay_Gd.AddDays(numSo_Ngay_Ht.Value).AddDays(-1);

				txtNgay_Ht.Text = Library.DateToStr(dNgay_Ht);
			}
			else
				txtNgay_Ht.Text = string.Empty;
		}

		void numSo_Ngay_Dk_Ht_Validated(object sender, EventArgs e)
		{
			if (txtNgay_Gd.Text.Trim() != "//" && numSo_Ngay_Dk_Ht.Value != 0)
			{
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);
				DateTime dNgay_Dk_Ht = dNgay_Gd.AddDays(numSo_Ngay_Dk_Ht.Value).AddDays(-1);

				txtNgay_Dk_Ht.Text = Library.DateToStr(dNgay_Dk_Ht);
			}
			else
				txtNgay_Dk_Ht.Text = string.Empty;
		}

		void txtNgay_Dk_Ht_Validated(object sender, EventArgs e)
		{
			Calc_So_Ngay();
		}

		void txtNgay_Ht_Validated(object sender, EventArgs e)
		{
			Calc_So_Ngay();
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (enuTask_Type.Text == "CONTRACT")
			{
				txtMa_Dt_Kh.Enabled = false;
				txtMa_Dt_Kh.Text = string.Empty;
			}
			else
			{
				txtMa_Hd.Enabled = false;
				txtMa_Hd.Text = string.Empty; 
			}
		}
	}
}
