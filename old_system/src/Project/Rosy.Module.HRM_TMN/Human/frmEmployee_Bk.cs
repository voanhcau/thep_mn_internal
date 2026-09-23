using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Library;
using RosySystem.Element;
using RosyList;

namespace RosyModule.HRM
{
	public partial class frmEmployee_Bk : RosySystem.Customize.frmView
	{
		#region Khai bao bien
		private rsTreeList tlDmCbNv = new rsTreeList();

		DataTable dtEmployee;
		DataTable dtQHGD;
		DataTable dtQTCT;
		DataTable dtQTDT;
		DataTable dtHDLD;
		DataTable dtQTKTKL;
		DataTable dtNghiPhep;
		DataTable dtTsTn0; 

		BindingSource bdsEmployee = new BindingSource();
		BindingSource bdsQHGD = new BindingSource();
		BindingSource bdsQTCT = new BindingSource();
		BindingSource bdsQTDT = new BindingSource();
		BindingSource bdsHDLD = new BindingSource();
		BindingSource bdsQTKTKL = new BindingSource();
		BindingSource bdsNghiPhep = new BindingSource();
		BindingSource bdsTsTn0 = new BindingSource();

		private DataRow drCurrent;

		#endregion

		#region Contructor

		public frmEmployee_Bk()
		{
			InitializeComponent();

			bdsEmployee.PositionChanged += new EventHandler(bdsEmployee_PositionChanged);

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
            btImport.Click += new EventHandler(btImport_Click);

			btDetailNew.Click += new EventHandler(btDetailNew_Click);
			btDetailEdit.Click += new EventHandler(btDetailEdit_Click);
			btDetailDelete.Click += new EventHandler(btDetailDelete_Click);
		}

       

		public override void Load()
		{
			this.Build();
			this.FillData(string.Empty);
			this.BindingData();
			this.BindingLanguage();
            LoadDicName();
			this.Show();

			tlDmCbNv.Focus();
		}

		#endregion

		#region Build, FillData

        private void LoadDicName()
        {
            //txtMa_Bp
            if (txtMa_Bp.Text.Trim() != string.Empty)
            {
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            }
            else
                lbtTen_Bp.Text = string.Empty;
        }
		private void Build()
		{
			tlDmCbNv.KeyFieldName = "MA_DT";
			tlDmCbNv.ParentFieldName = "MA_BP";
			tlDmCbNv.Dock = DockStyle.Fill;
			tlDmCbNv.strZone = "EMPLOYEE";
			tlDmCbNv.BuildTreeList(this.isLookup);

			this.pageEmployee.Controls.Add(tlDmCbNv);

			dgvQHGD.strZone = "QHGD";
			dgvQHGD.BuildGridView();

			dgvQTCT.strZone = "QTCT";
			dgvQTCT.BuildGridView();

			dgvQTDT.strZone = "QTDT";
			dgvQTDT.BuildGridView();

			dgvHDLD.strZone = "HDLD";
			dgvHDLD.BuildGridView();

			dgvQTKTKL.strZone = "QTKTKL";
			dgvQTKTKL.BuildGridView();

			dgvNghiPhep.strZone = "NGHIPHEP";
			dgvNghiPhep.BuildGridView();

			dgvTsTn0.strZone = "TSTN0";
			dgvTsTn0.BuildGridView();
		}

		private void FillData(string strKey)
		{
			dtEmployee = SQLExec.ExecuteReturnDt("EXEC Sp_GetDmDtCbNv");

			bdsEmployee.DataSource = dtEmployee;
			tlDmCbNv.DataSource = bdsEmployee;
			//bdsEmployee.Position = 0;

			//QHGD
			dtQHGD = DataTool.SQLGetDataTable("R09QHGD", null, strKey, "Nam_Sinh, Loai_QHGD");
			bdsQHGD.DataSource = dtQHGD;
			dgvQHGD.DataSource = bdsQHGD;

			//QTCT
			dtQTCT = DataTool.SQLGetDataTable("R09QTCT", null, strKey, "Ngay_Bd, Ngay_Kt");
			bdsQTCT.DataSource = dtQTCT;
			dgvQTCT.DataSource = bdsQTCT;

			//QTDT
			dtQTDT = DataTool.SQLGetDataTable("R09QTDT", null, strKey, "Ngay_Bd, Ngay_Kt");
			bdsQTDT.DataSource = dtQTDT;
			dgvQTDT.DataSource = bdsQTDT;

			//HDLD
			dtHDLD = DataTool.SQLGetDataTable("R09HDLD", null, strKey, "Ngay_Bd, Ngay_Kt");
			bdsHDLD.DataSource = dtHDLD;
			dgvHDLD.DataSource = bdsHDLD;

			//QTKTKL
			dtQTKTKL = DataTool.SQLGetDataTable("R09QtKTKL", null, strKey, "Ngay_QD, Ngay_HL");
			bdsQTKTKL.DataSource = dtQTKTKL;
			dgvQTKTKL.DataSource = bdsQTKTKL;

			//NGHIPHEP
			dtNghiPhep = DataTool.SQLGetDataTable("R09NghiPhep", null, strKey, "Ngay_Bd, Ngay_Kt");
			bdsNghiPhep.DataSource = dtNghiPhep;
			dgvNghiPhep.DataSource = bdsNghiPhep;

			//Tham số các khoản thu nhập
			string strSQLExec =
				"SELECT T1.*, T2.Ten_Tn, T2.Dvt FROM R10TsTn0 T1 LEFT JOIN R10DmTn T2 ON T1.Ma_Tn = T2.Ma_Tn " +
					" ORDER BY Ngay_Ap";

			dtTsTn0 = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsTsTn0.DataSource = dtTsTn0;
			dgvTsTn0.DataSource = bdsTsTn0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsEmployee;
			ExportControl = tlDmCbNv;

			tlDmCbNv.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmCbNv.strZone + "'");
		}

		private void BindingData()
		{
			foreach (Control ctrl in tpTTNV.Controls)
			{
				if (ctrl.GetType() == typeof(rsTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(rsDateTime) || ctrl.GetType() == typeof(rsComboBox) || ctrl.GetType() == typeof(ComboBox))
				{
					string strFieldName = ctrl.Name.Substring(3);

					if (((DataTable)bdsEmployee.DataSource).Columns.Contains(strFieldName))
						ctrl.DataBindings.Add("Text", bdsEmployee, strFieldName);
				}
			}

			//picHinh.DataBindings.Add("Image", bdsEmployee, "Hinh");
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (tabEmployee.Focused || pageEmployee.Focused || tlDmCbNv.Focused)
				this.EditEmployee(enuNew_Edit);
			else if (tabDetail.SelectedTab == pageQHGD || dgvQHGD.Focused)
				this.EditQHGD(enuNew_Edit);
			else if (tabDetail.SelectedTab == pageQTDT || dgvQTDT.Focused)
				this.EditQTDT(enuNew_Edit);
			else if (tabDetail.SelectedTab == pageQTCT || dgvQTCT.Focused)
				this.EditQTCT(enuNew_Edit);
			else if (tabDetail.SelectedTab == pageHDLD || dgvHDLD.Focused)
				this.EditHDLD(enuNew_Edit);
            //else if (tabDetail.SelectedTab == pageQTKTKL || dgvQTKTKL.Focused)
            //    this.EditQTKTKL(enuNew_Edit);
			else if (tabDetail.SelectedTab == pageHDLD || dgvHDLD.Focused)
				this.EditHDLD(enuNew_Edit);
			else if (tabDetail.SelectedTab == pageNghiPhep || dgvNghiPhep.Focused)
				this.EditNghiPhep(enuNew_Edit);
			else if (tabDetail.SelectedTab == pageTsTn0 || dgvTsTn0.Focused)
				this.EditTsTn0(enuNew_Edit);
		}

		public override void Delete()
		{
			if (tabEmployee.Focused || pageEmployee.Focused || tlDmCbNv.Focused)
				this.DeleteEmployee();
			else if (tabDetail.SelectedTab == pageQHGD || dgvQHGD.Focused)
				this.DeleteQHGD();
			else if (tabDetail.SelectedTab == pageQTDT || dgvQTDT.Focused)
				this.DeleteQTDT();
			else if (tabDetail.SelectedTab == pageQTCT || dgvQTCT.Focused)
				this.DeleteQTCT();
			else if (tabDetail.SelectedTab == pageHDLD || dgvHDLD.Focused)
				this.DeleteHDLD();
			else if (tabDetail.SelectedTab == pageQTKTKL || dgvQTKTKL.Focused)
				this.DeleteQTKTKL();
			else if (tabDetail.SelectedTab == pageHDLD || dgvHDLD.Focused)
				this.DeleteHDLD();
			else if (tabDetail.SelectedTab == pageNghiPhep || dgvNghiPhep.Focused)
				this.DeleteNghiPhep();
			else if (tabDetail.SelectedTab == pageTsTn0 || dgvTsTn0.Focused)
				this.DeleteTsTn0();
		}

		void EditEmployee(enuEdit enuNew_Edit)
		{
			if (bdsEmployee.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			if (bdsEmployee.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsEmployee.Current).Row, ref drCurrent);
			else
				drCurrent = dtEmployee.NewRow();

			frmEmployee_Edit frmEdit = new frmEmployee_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsEmployee.Position >= 0)
						dtEmployee.ImportRow(drCurrent);
					else
						dtEmployee.Rows.Add(drCurrent);

					bdsEmployee.Position = bdsEmployee.Find("Ma_Dt", drCurrent["Ma_Dt"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsEmployee.Current).Row);

				dtEmployee.AcceptChanges();
			}
		}

		void EditQHGD(enuEdit enuNew_Edit)
		{
			if (bdsEmployee.Position < 0)
				return;

			if (bdsQHGD.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

			//Copy hang hien tai            
			if (bdsQHGD.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsQHGD.Current).Row, ref drCurrent);
			else
				drCurrent = dtQHGD.NewRow();

			drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];
			frmQHGD_Edit frmEdit = new frmQHGD_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsQHGD.Position >= 0)
						dtQHGD.ImportRow(drCurrent);
					else
						dtQHGD.Rows.Add(drCurrent);

					bdsQHGD.Position = bdsQHGD.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsQHGD.Current).Row);

				dtQHGD.AcceptChanges();
			}
			else
				dtQHGD.RejectChanges();
		}

		void EditQTCT(enuEdit enuNew_Edit)
		{
			if (bdsEmployee.Position < 0)
				return;

			if (bdsQTCT.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

			//Copy hang hien tai            
			if (bdsQTCT.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsQTCT.Current).Row, ref drCurrent);
			else
				drCurrent = dtQTCT.NewRow();

			drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];
			frmQTCT_Edit frmEdit = new frmQTCT_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsQTCT.Position >= 0)
						dtQTCT.ImportRow(drCurrent);
					else
						dtQTCT.Rows.Add(drCurrent);

					bdsQTCT.Position = bdsQTCT.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsQTCT.Current).Row);

				dtQTCT.AcceptChanges();
			}
			else
				dtQTCT.RejectChanges();
		}

		void EditQTDT(enuEdit enuNew_Edit)
		{
			if (bdsEmployee.Position < 0)
				return;

			if (bdsQTDT.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

			//Copy hang hien tai            
			if (bdsQTDT.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsQTDT.Current).Row, ref drCurrent);
			else
				drCurrent = dtQTDT.NewRow();

			drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];
			frmQTDT_Edit frmEdit = new frmQTDT_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsQTDT.Position >= 0)
						dtQTDT.ImportRow(drCurrent);
					else
						dtQTDT.Rows.Add(drCurrent);

					bdsQTDT.Position = bdsQTDT.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsQTDT.Current).Row);

				dtQTDT.AcceptChanges();
			}
			else
				dtQTDT.RejectChanges();
		}

		void EditHDLD(enuEdit enuNew_Edit)
		{
			if (bdsEmployee.Position < 0)
				return;

			if (bdsHDLD.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

			//Copy hang hien tai            
			if (bdsHDLD.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsHDLD.Current).Row, ref drCurrent);
			else
				drCurrent = dtHDLD.NewRow();

			drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];
			frmHDLD_Edit frmEdit = new frmHDLD_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsHDLD.Position >= 0)
						dtHDLD.ImportRow(drCurrent);
					else
						dtHDLD.Rows.Add(drCurrent);

					bdsHDLD.Position = bdsHDLD.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsHDLD.Current).Row);

				dtHDLD.AcceptChanges();
			}
			else
				dtHDLD.RejectChanges();
		}

        //void EditQTKTKL(enuEdit enuNew_Edit)
        //{
        //    if (bdsEmployee.Position < 0)
        //        return;

        //    if (bdsQTKTKL.Position < 0 && enuNew_Edit == enuEdit.Edit)
        //        return;

        //    DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

        //    //Copy hang hien tai            
        //    if (bdsQTKTKL.Position >= 0)
        //        Common.CopyDataRow(((DataRowView)bdsQTKTKL.Current).Row, ref drCurrent);
        //    else
        //        drCurrent = dtQTKTKL.NewRow();

        //    drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];
        //    frmQTKTKL_Edit frmEdit = new frmQTKTKL_Edit();
        //    frmEdit.Load(enuNew_Edit, drCurrent);

        //    // người dùng chọn chấp nhận
        //    if (frmEdit.isAccept)
        //    {
        //        if (enuNew_Edit == enuEdit.New)
        //        {
        //            if (bdsQTKTKL.Position >= 0)
        //                dtQTKTKL.ImportRow(drCurrent);
        //            else
        //                dtQTKTKL.Rows.Add(drCurrent);

        //            bdsQTKTKL.Position = bdsQTKTKL.Find("Ident00", drCurrent["Ident00"]);
        //        }
        //        else
        //            Common.CopyDataRow(drCurrent, ((DataRowView)bdsQTKTKL.Current).Row);

        //        dtQTKTKL.AcceptChanges();
        //    }
        //    else
        //        dtQTKTKL.RejectChanges();
        //}

		void EditNghiPhep(enuEdit enuNew_Edit)
		{
			if (bdsEmployee.Position < 0)
				return;

			if (bdsNghiPhep.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

			//Copy hang hien tai            
			if (bdsNghiPhep.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsNghiPhep.Current).Row, ref drCurrent);
			else
				drCurrent = dtNghiPhep.NewRow();

			drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt_CbNv"];

			frmNghiPhep_Edit frmEdit = new frmNghiPhep_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsNghiPhep.Position >= 0)
						dtNghiPhep.ImportRow(drCurrent);
					else
						dtNghiPhep.Rows.Add(drCurrent);

					bdsNghiPhep.Position = bdsNghiPhep.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsNghiPhep.Current).Row);

				dtNghiPhep.AcceptChanges();
			}
			else
				dtNghiPhep.RejectChanges();
		}

		void EditTsTn0(enuEdit enuNew_Edit)
		{
			if (bdsEmployee.Position < 0)
				return;

			if (bdsTsTn0.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

			//Copy hang hien tai            
			if (bdsTsTn0.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsTsTn0.Current).Row, ref drCurrent);
			else
				drCurrent = dtTsTn0.NewRow();

			drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];

			frmTsTn0_Edit frmEdit = new frmTsTn0_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsTsTn0.Position >= 0)
						dtTsTn0.ImportRow(drCurrent);
					else
						dtTsTn0.Rows.Add(drCurrent);

					bdsTsTn0.Position = bdsTsTn0.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsTsTn0.Current).Row);

				dtTsTn0.AcceptChanges();
			}
			else
				dtTsTn0.RejectChanges();
		}

		void DeleteEmployee()
		{
			if (bdsEmployee.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsEmployee.Current).Row;

			if ((bool)drCurrent["Is_BoPhan"])
				return;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81DmDt", drCurrent))
			{
				bdsEmployee.RemoveAt(bdsEmployee.Position);
				dtEmployee.AcceptChanges();
			}
		}

		void DeleteQHGD()
		{
			if (bdsQHGD.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsQHGD.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R09QHGD", drCurrent))
			{
				bdsQHGD.RemoveAt(bdsQHGD.Position);
				dtQHGD.AcceptChanges();
			}
		}

		void DeleteQTCT()
		{
			if (bdsQTCT.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsQTCT.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R09QTCT", drCurrent))
			{
				bdsQTCT.RemoveAt(bdsQTCT.Position);
				dtQTCT.AcceptChanges();
			}
		}

		void DeleteQTDT()
		{
			if (bdsQTDT.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsQTDT.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R09QTDT", drCurrent))
			{
				bdsQTDT.RemoveAt(bdsQTDT.Position);
				dtQTDT.AcceptChanges();
			}
		}

		void DeleteHDLD()
		{
			if (bdsHDLD.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsHDLD.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R09HDLD", drCurrent))
			{
				bdsHDLD.RemoveAt(bdsHDLD.Position);
				dtHDLD.AcceptChanges();
			}
		}

		void DeleteQTKTKL()
		{
			if (bdsQTKTKL.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsQTKTKL.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R09QTKTKL", drCurrent))
			{
				bdsQTKTKL.RemoveAt(bdsQTKTKL.Position);
				dtQTKTKL.AcceptChanges();
			}
		}

		void DeleteNghiPhep()
		{
			if (bdsNghiPhep.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsNghiPhep.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R09NGHIPHEP", drCurrent))
			{
				bdsNghiPhep.RemoveAt(bdsNghiPhep.Position);
				dtNghiPhep.AcceptChanges();
			}
		}

		void DeleteTsTn0()
		{
			if (bdsTsTn0.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsTsTn0.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R10TsTn0", drCurrent))
			{
				bdsTsTn0.RemoveAt(bdsTsTn0.Position);
				dtTsTn0.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsEmployee.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsEmployee.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Dt_CbNv"];

			frmMergeID frm = new frmMergeID();
			frm.Load("R81DmDt", "Ma_Dt", "Ten_Dt", strOldValue, "DMDT");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Dt", "R81DmDt", strOldValue, strNewValue))
				{
					bdsEmployee.RemoveCurrent();
					bdsEmployee.Position = bdsEmployee.Find("Ma_Dt", strNewValue);
				}
			}
		}

		#endregion

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsEmployee == null || bdsEmployee.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsEmployee.Current).Row;
			DataTable dtTemp = dtEmployee.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void EnterProcess()
		{
			if (bdsEmployee.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsEmployee.Current).Row;
				this.Close();
			}
		}

		#endregion

		#region Su kien

		void bdsEmployee_PositionChanged(object sender, EventArgs e)
		{
			drCurrent = ((DataRowView)bdsEmployee.Current).Row;

			bdsHDLD.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
			bdsQHGD.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
			bdsQTCT.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
			bdsQTDT.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
			bdsQTKTKL.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
			bdsNghiPhep.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
			bdsTsTn0.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";

			object objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM R81DmDt WHERE Ma_Dt = '" + (string)drCurrent["Ma_Dt"] + "'");

			if (objPic != null && objPic != DBNull.Value)
			{
				Byte[] bytePic = (Byte[])objPic;

				if (bytePic.Length != 0)
				{
					picHinh.Image = Image.FromStream(new System.IO.MemoryStream((Byte[])objPic));
				}
			}
			else
				picHinh.Image = null;
		}

		void btDetailNew_Click(object sender, EventArgs e)
		{
			if (tabDetail.SelectedTab == pageQHGD)
				this.EditQHGD(enuEdit.New);
			else if (tabDetail.SelectedTab == pageQTDT)
				this.EditQTDT(enuEdit.New);
			else if (tabDetail.SelectedTab == pageQTCT)
				this.EditQTCT(enuEdit.New);
			else if (tabDetail.SelectedTab == pageHDLD)
				this.EditHDLD(enuEdit.New);
            //else if (tabDetail.SelectedTab == pageQTKTKL)
            //    this.EditQTKTKL(enuEdit.New);
			else if (tabDetail.SelectedTab == pageHDLD)
				this.EditHDLD(enuEdit.New);
			else if (tabDetail.SelectedTab == pageNghiPhep)
				this.EditNghiPhep(enuEdit.New);
			else if (tabDetail.SelectedTab == pageTsTn0)
				this.EditTsTn0(enuEdit.New);
		}

		void btDetailEdit_Click(object sender, EventArgs e)
		{
			if (tabDetail.SelectedTab == pageQHGD)
				this.EditQHGD(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageQTDT)
				this.EditQTDT(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageQTCT)
				this.EditQTCT(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageHDLD)
				this.EditHDLD(enuEdit.Edit);
            //else if (tabDetail.SelectedTab == pageQTKTKL)
            //    this.EditQTKTKL(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageHDLD)
				this.EditHDLD(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageNghiPhep)
				this.EditNghiPhep(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageTsTn0)
				this.EditTsTn0(enuEdit.Edit);
		}

		void btDetailDelete_Click(object sender, EventArgs e)
		{
			if (tabDetail.SelectedTab == pageQHGD)
				this.DeleteQHGD();
			else if (tabDetail.SelectedTab == pageQTDT)
				this.DeleteQTDT();
			else if (tabDetail.SelectedTab == pageQTCT)
				this.DeleteQTCT();
			else if (tabDetail.SelectedTab == pageHDLD)
				this.DeleteHDLD();
			else if (tabDetail.SelectedTab == pageQTKTKL)
				this.DeleteQTKTKL();
			else if (tabDetail.SelectedTab == pageHDLD)
				this.DeleteHDLD();
			else if (tabDetail.SelectedTab == pageNghiPhep)
				this.DeleteNghiPhep();
			else if (tabDetail.SelectedTab == pageTsTn0)
				this.DeleteTsTn0();
		}

		void btNew_Click(object sender, EventArgs e)
		{
			this.EditEmployee(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			this.EditEmployee(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			this.DeleteEmployee();
		}
        void btImport_Click(object sender, EventArgs e)
        {

            DataTable dtDmDt = DataTool.SQLGetDataTable("R81DMDT", "*", "Ma_Nh_Dt = 'NV'", "Ma_Dt");
            Voucher.ImportExcel_DMDTCBNV("DMDT", dtDmDt);
        }

		#endregion
	}
}
