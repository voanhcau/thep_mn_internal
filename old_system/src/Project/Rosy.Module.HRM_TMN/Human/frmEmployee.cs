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
using System.Collections;

namespace RosyModule.HRM
{
	public partial class frmEmployee : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		private rsTreeList tlDmBpCt = new rsTreeList();
		DataTable dtDmBpCt;
		BindingSource bdsDmBpCt = new BindingSource();

        private rsTreeList tlEmployee = new rsTreeList();
        DataTable dtEmployee;
        BindingSource bdsEmployee = new BindingSource();

		private DataRow drCurrent;

        DataTable dtQHGD;
        DataTable dtQLBL;
        DataTable dtHDLD;
        DataTable dtQTCT;
        DataTable dtQLKT;
        DataTable dtQLKL;
        DataTable dtQLSC;
        DataTable dtQLDT;
        DataTable dtQLTS;
        DataTable dtQLCT;
        DataTable dtQLBDDH;
        DataTable dtNghiPhep;
        
        BindingSource bdsQHGD = new BindingSource();
        BindingSource bdsQLBL = new BindingSource();
        BindingSource bdsHDLD = new BindingSource();
        BindingSource bdsQTCT = new BindingSource();
        BindingSource bdsQLKT = new BindingSource();
        BindingSource bdsQLKL = new BindingSource();
        BindingSource bdsQLSC = new BindingSource();
        BindingSource bdsQLDT = new BindingSource();
        BindingSource bdsQLTS = new BindingSource();
        BindingSource bdsQLCT = new BindingSource();
        BindingSource bdsQLBDDH = new BindingSource();
        BindingSource bdsNghiPhep = new BindingSource();
		#endregion

		#region Contructor

		public frmEmployee()
		{
			InitializeComponent();

			bdsDmBpCt.PositionChanged += new EventHandler(bdsDmBpCt_PositionChanged);
            bdsEmployee.PositionChanged += new EventHandler(bdsEmployee_PositionChanged);
			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
            btImport.Click += new EventHandler(btImport_Click);

            
            dgvEmployee.DoubleClick += new EventHandler(dgvEmployee_DoubleClick);
            cboLoc.SelectedIndexChanged+= new EventHandler(cboLoc_SelectedIndexChanged);

            btEmployeeNew.Click += new EventHandler(btEmployeeNew_Click);
            btEmployeeEdit.Click += new EventHandler(btEmployeeEdit_Click);
            btEmployeeDelete.Click += new EventHandler(btEmployeeDelete_Click);

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

            //
            cboLoc.DisplayMember = "Text";
            cboLoc.ValueMember = "Value";

            cboLoc.Items.Add(new { Text = "Đang làm việc", Value = "1" });
            cboLoc.Items.Add(new { Text = "Tất cả", Value = "2" });
            cboLoc.Items.Add(new { Text = "Đã nghỉ việc", Value = "3" });
            cboLoc.SelectedIndex = 1;
            //

            LoadDicName();
			this.Show();

			tlDmBpCt.Focus();
		}

		#endregion

		#region Build, FillData

        private void LoadDicName()
        {
            
        }
		private void Build()
		{
			tlDmBpCt.KeyFieldName = "MA_DT";
			tlDmBpCt.ParentFieldName = "MA_BP";
			tlDmBpCt.Dock = DockStyle.Fill;
			tlDmBpCt.strZone = "DMBPCT";
			tlDmBpCt.BuildTreeList(this.isLookup);

			this.pageEmployee.Controls.Add(tlDmBpCt);

            dgvEmployee.Dock = DockStyle.Fill;
            dgvEmployee.strZone = "EMPLOYEE";
            dgvEmployee.BuildGridView();

            dgvQLBL.strZone = "QLBL";
            dgvQLBL.BuildGridView();

            dgvQHGD.strZone = "QHGD";
            dgvQHGD.BuildGridView();

            dgvHDLD.strZone = "HDLD";
            dgvHDLD.BuildGridView();

            dgvQTCT.strZone = "QTCT";
            dgvQTCT.BuildGridView();

            dgvQLKT.strZone = "QTKT";
            dgvQLKT.BuildGridView();

            dgvQLKL.strZone = "QTKL";
            dgvQLKL.BuildGridView();

            dgvQLSC.strZone = "QLSC";
            dgvQLSC.BuildGridView();

            dgvQLDT.strZone = "QTDT";
            dgvQLDT.BuildGridView();

            dgvQLTS.strZone = "QLTS";
            dgvQLTS.BuildGridView();

            dgvQLCT.strZone = "QLCT";
            dgvQLCT.BuildGridView();

            dgvQLBDDH.strZone = "QLBDDH";
            dgvQLBDDH.BuildGridView();

            dgvNghiPhep.strZone = "NGHIPHEP";
            dgvNghiPhep.BuildGridView();
		}

		private void FillData(string strKey)
		{
            Hashtable ht1 = new Hashtable();
            ht1.Add("USER_LOGIN", Element.sysUser_Id);
            dtDmBpCt = SQLExec.ExecuteReturnDt("Sp_GetDmBpCt", ht1, CommandType.StoredProcedure);

			bdsDmBpCt.DataSource = dtDmBpCt;
			tlDmBpCt.DataSource = bdsDmBpCt;

            Hashtable ht = new Hashtable();
            ht.Add("LOAI", cboLoc.SelectedIndex);
            ht.Add("NAM", Element.sysWorkingYear);
            DataSet dsEmployee = SQLExec.ExecuteReturnDs("Sp_GetDmDtCbNv", ht, CommandType.StoredProcedure);
            
            dtEmployee = dsEmployee.Tables[0];
            bdsEmployee.DataSource = dtEmployee;
            dgvEmployee.DataSource = bdsEmployee;

            //QLBL
            dtQLBL = dsEmployee.Tables[1];
            bdsQLBL.DataSource = dtQLBL;
            dgvQLBL.DataSource = bdsQLBL;

            //QHGD
            dtQHGD = dsEmployee.Tables[2];
            bdsQHGD.DataSource = dtQHGD;
            dgvQHGD.DataSource = bdsQHGD;

            //HDLD
            dtHDLD = dsEmployee.Tables[3];
            bdsHDLD.DataSource = dtHDLD;
            dgvHDLD.DataSource = bdsHDLD;

            //QTCT
            dtQTCT = dsEmployee.Tables[4];
            bdsQTCT.DataSource = dtQTCT;
            dgvQTCT.DataSource = bdsQTCT;

            //QTKT
            dtQLKT = dsEmployee.Tables[5];
            bdsQLKT.DataSource = dtQLKT;
            dgvQLKT.DataSource = bdsQLKT;

            //QTKL
            dtQLKL = dsEmployee.Tables[6];
            bdsQLKL.DataSource = dtQLKL;
            dgvQLKL.DataSource = bdsQLKL;

            //QLSC
            dtQLSC = dsEmployee.Tables[7];
            bdsQLSC.DataSource = dtQLSC;
            dgvQLSC.DataSource = bdsQLSC;

            //QLDT
            dtQLDT = dsEmployee.Tables[8];
            bdsQLDT.DataSource = dtQLDT;
            dgvQLDT.DataSource = bdsQLDT;

            //QTTS
            dtQLTS = dsEmployee.Tables[9];
            bdsQLTS.DataSource = dtQLTS;
            dgvQLTS.DataSource = bdsQLTS;

            //QLCT
            dtQLCT = dsEmployee.Tables[10];
            bdsQLCT.DataSource = dtQLCT;
            dgvQLCT.DataSource = bdsQLCT;

            //NghiPhep
            dtNghiPhep = dsEmployee.Tables[11];
            bdsNghiPhep.DataSource = dtNghiPhep;
            dgvNghiPhep.DataSource = bdsNghiPhep;

            //QLBDDH
            dtQLBDDH = dsEmployee.Tables[12];
            bdsQLBDDH.DataSource = dtQLBDDH;
            dgvQLBDDH.DataSource = bdsQLBDDH;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsEmployee;
            ExportControl = dgvEmployee;

			tlDmBpCt.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmBpCt.strZone + "'");
            
            numTSo_Luong.DataBindings.Clear();
            numTSo_Luong.DataBindings.Add("Value", dtEmployee, "TSo_Luong");
		}

		private void BindingData()
		{
			foreach (Control ctrl in tpTTNV.Controls)
			{
				if (ctrl.GetType() == typeof(rsTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(rsDateTime) || ctrl.GetType() == typeof(rsComboBox) || ctrl.GetType() == typeof(ComboBox))
				{
					string strFieldName = ctrl.Name.Substring(3);

					if (((DataTable)bdsDmBpCt.DataSource).Columns.Contains(strFieldName))
						ctrl.DataBindings.Add("Text", bdsDmBpCt, strFieldName);
				}
			}

			//picHinh.DataBindings.Add("Image", bdsDmBpCt, "Hinh");
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (tabEmployee.Focused || pageEmployee.Focused || tlDmBpCt.Focused)
				this.EditEmployee(enuNew_Edit);
		
		}

		public override void Delete()
		{
			if (tabEmployee.Focused || pageEmployee.Focused || tlDmBpCt.Focused)
				this.DeleteEmployee();
		
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
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQHGD.Current).Row);
                }
                FillData("");
                dtQHGD.AcceptChanges();
            }
            else
                dtQHGD.RejectChanges();
        }

        void EditQLBL(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsQLBL.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsQLBL.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQLBL.Current).Row, ref drCurrent);
            else
                drCurrent = dtQLBL.NewRow();
            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];
            frmQLBL_Edit frmEdit = new frmQLBL_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQLBL.Position >= 0)
                        dtQLBL.ImportRow(drCurrent);
                    else
                        dtQLBL.Rows.Add(drCurrent);

                    bdsQLBL.Position = bdsQLBL.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQLBL.Current).Row);
                }
                FillData("");
                dtQLBL.AcceptChanges();
            }
            else
                dtQLBL.RejectChanges();
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
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQTCT.Current).Row);
                }
                FillData("");
                dtQTCT.AcceptChanges();
            }
            else
                dtQTCT.RejectChanges();
        }
        void EditQLKT(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsQLKT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsQLKT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQLKT.Current).Row, ref drCurrent);
            else
                drCurrent = dtQLKT.NewRow();
            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];
            frmQTKTKL_Edit frmEdit = new frmQTKTKL_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, "1");

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQLKT.Position >= 0)
                        dtQLKT.ImportRow(drCurrent);
                    else
                        dtQLKT.Rows.Add(drCurrent);

                    bdsQLKT.Position = bdsQLKT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQLKT.Current).Row);
                }
                FillData("");
                dtQLKT.AcceptChanges();
            }
            else
                dtQLKT.RejectChanges();
        }
        void EditQLKL(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsQLKL.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsQLKL.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQLKL.Current).Row, ref drCurrent);
            else
                drCurrent = dtQLKL.NewRow();

            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];

            frmQTKTKL_Edit frmEdit = new frmQTKTKL_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, "2");

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQLKL.Position >= 0)
                        dtQLKL.ImportRow(drCurrent);
                    else
                        dtQLKL.Rows.Add(drCurrent);

                    bdsQLKL.Position = bdsQLKT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQLKL.Current).Row);
                }
                FillData("");
                dtQLKL.AcceptChanges();
            }
            else
                dtQLKL.RejectChanges();
        }
        void EditQLSC(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsQLSC.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsQLSC.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQLSC.Current).Row, ref drCurrent);
            else
                drCurrent = dtQLSC.NewRow();

            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];

            frmQLSC_Edit frmEdit = new frmQLSC_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQLSC.Position >= 0)
                        dtQLSC.ImportRow(drCurrent);
                    else
                        dtQLSC.Rows.Add(drCurrent);

                    bdsQLSC.Position = bdsQLSC.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQLSC.Current).Row);
                }
                FillData("");
                dtQLSC.AcceptChanges();
            }
            else
                dtQLSC.RejectChanges();
        }
        void EditQLDT(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsQLDT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsQLDT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQLDT.Current).Row, ref drCurrent);
            else
                drCurrent = dtQLDT.NewRow();
            
            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];

            frmQTDT_Edit frmEdit = new frmQTDT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQLDT.Position >= 0)
                        dtQLDT.ImportRow(drCurrent);
                    else
                        dtQLDT.Rows.Add(drCurrent);

                    bdsQLDT.Position = bdsQLDT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQLDT.Current).Row);
                }
                FillData("");
                dtQLDT.AcceptChanges();
            }
            else
                dtQLDT.RejectChanges();
        }
        void EditQLCT(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsQLCT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsQLCT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQLCT.Current).Row, ref drCurrent);
            else
                drCurrent = dtQLCT.NewRow();

            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];

            frmQLCT_Edit frmEdit = new frmQLCT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQLCT.Position >= 0)
                        dtQLCT.ImportRow(drCurrent);
                    else
                        dtQLCT.Rows.Add(drCurrent);

                    bdsQLCT.Position = bdsQLCT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQLCT.Current).Row);
                }
                FillData("");
                dtQLCT.AcceptChanges();
            }
            else
                dtQLCT.RejectChanges();
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
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsHDLD.Current).Row);
                }
                FillData("");
                dtHDLD.AcceptChanges();
            }
            else
                dtHDLD.RejectChanges();
        }
        void EditQLTS(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsQLTS.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsQLTS.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQLTS.Current).Row, ref drCurrent);
            else
                drCurrent = dtQLTS.NewRow();

            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];

            frmQLTS_Edit frmEdit = new frmQLTS_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQLTS.Position >= 0)
                        dtQLTS.ImportRow(drCurrent);
                    else
                        dtQLTS.Rows.Add(drCurrent);

                    bdsQLTS.Position = bdsQLTS.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQLTS.Current).Row);
                }
                FillData("");
                dtQLTS.AcceptChanges();
            }
            else
                dtQLTS.RejectChanges();
        }
        void EditQLBDDH(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsQLBDDH.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsQLBDDH.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQLBDDH.Current).Row, ref drCurrent);
            else
                drCurrent = dtQLBDDH.NewRow();

            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];

            frmQLBDDH_Edit frmEdit = new frmQLBDDH_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQLBDDH.Position >= 0)
                        dtQLBDDH.ImportRow(drCurrent);
                    else
                        dtQLBDDH.Rows.Add(drCurrent);

                    bdsQLBDDH.Position = bdsQLBDDH.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQLBDDH.Current).Row);
                }
                FillData("");
                dtQLBDDH.AcceptChanges();
            }
            else
                dtQLBDDH.RejectChanges();
        }
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

            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];

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
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsNghiPhep.Current).Row);
                }
                FillData("");
                dtNghiPhep.AcceptChanges();
            }
            else
                dtNghiPhep.RejectChanges();
        }
        void EditEmployee_View()
        {
            if (bdsEmployee.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsEmployee.Current).Row;

            frmEmployee_View frmEdit = new frmEmployee_View();
            frmEdit.Load(drCurrent["Ma_Dt"].ToString());
        }
        void EditDmBpCt(enuEdit enuNew_Edit)
        {
            if (bdsDmBpCt.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsDmBpCt.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDmBpCt.Current).Row, ref drCurrent);
            else
                drCurrent = dtDmBpCt.NewRow();

            frmDmBpCt_Edit frmEdit = new frmDmBpCt_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDmBpCt.Position >= 0)
                        dtDmBpCt.ImportRow(drCurrent);
                    else
                        dtDmBpCt.Rows.Add(drCurrent);

                    bdsDmBpCt.Position = bdsDmBpCt.Find("Ma_Bp_Ct", drCurrent["Ma_Bp_Ct"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmBpCt.Current).Row);

                dtDmBpCt.AcceptChanges();
            }
        }
		
		void DeleteEmployee()
		{
			if (bdsEmployee.Position < 0)
				return;
            
            DataRow drCurrent = ((DataRowView)bdsEmployee.Current).Row;
            if (DataTool.SQLCheckExist("R00MEMBER", "Ma_Dt_CbNv", drCurrent["Ma_Dt"]))
            {
                Common.MsgOk("Đối tượng phát sinh chứng từ không được xóa!!!");
                return;
            }
			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81DmDt", drCurrent))
			{

                if (!Common.MsgYes_No("Dữ liệu của nhân viên sẽ bị xóa \n Bạn có chắc xoá không ? "))
                    return;

                string strMa_Dt_CbNv = drCurrent["Ma_Dt"].ToString().Trim();

                Hashtable ht = new Hashtable();
                ht.Add("MA_DT_CBNV", strMa_Dt_CbNv);

                SQLExec.Execute("sp_DeleteDmDtCbNv", ht, CommandType.StoredProcedure);

                bdsEmployee.RemoveAt(bdsEmployee.Position);
                dtEmployee.AcceptChanges();
			}
            FillData("");
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
        void DeleteQLBL()
        {
            if (bdsQLBL.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQLBL.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QLBL", drCurrent))
            {
                bdsQLBL.RemoveAt(bdsQLBL.Position);
                dtQLBL.AcceptChanges();
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
        void DeleteQTKT()
        {
            if (bdsQLKT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQLKT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QTKTKL", drCurrent))
            {
                bdsQLKT.RemoveAt(bdsQLKT.Position);
                dtQLKT.AcceptChanges();
            }
        }
        void DeleteQTKL()
        {
            if (bdsQLKL.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQLKL.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QTKTKL", drCurrent))
            {
                bdsQLKL.RemoveAt(bdsQLKL.Position);
                dtQLKL.AcceptChanges();
            }
        }
        void DeleteQLSC()
        {
            if (bdsQLSC.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQLSC.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QLSUCO", drCurrent))
            {
                bdsQLSC.RemoveAt(bdsQLSC.Position);
                dtQLSC.AcceptChanges();
            }
        }
        void DeleteQLDT()
        {
            if (bdsQLDT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQLDT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QTDT", drCurrent))
            {
                bdsQLDT.RemoveAt(bdsQLDT.Position);
                dtQLDT.AcceptChanges();
            }
        }
        void DeleteQLTS()
        {
            if (bdsQLTS.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQLTS.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QLTAISAN", drCurrent))
            {
                bdsQLTS.RemoveAt(bdsQLTS.Position);
                dtQLTS.AcceptChanges();
            }
        }
        void DeleteQLCT()
        {
            if (bdsQLCT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQLCT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09DICONGTAC", drCurrent))
            {
                bdsQLCT.RemoveAt(bdsQLCT.Position);
                dtQLCT.AcceptChanges();
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
        void DeleteQLBDDH()
        {
            if (bdsQLBDDH.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQLBDDH.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QLBDDH", drCurrent))
            {
                bdsQLBDDH.RemoveAt(bdsQLBDDH.Position);
                dtQLBDDH.AcceptChanges();
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
        void DeleteDmBpCt()
        {
            if (bdsDmBpCt.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsDmBpCt.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R81DMBPCT", drCurrent))
            {
                bdsDmBpCt.RemoveAt(bdsDmBpCt.Position);
                dtDmBpCt.AcceptChanges();
            }
        }

		public override void MergeID()
		{
			if (bdsDmBpCt.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsDmBpCt.Current).Row;
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
					bdsDmBpCt.RemoveCurrent();
					bdsDmBpCt.Position = bdsDmBpCt.Find("Ma_Dt", strNewValue);
				}
			}
		}

		#endregion

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmBpCt == null || bdsDmBpCt.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmBpCt.Current).Row;
			DataTable dtTemp = dtDmBpCt.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void EnterProcess()
		{
			if (bdsDmBpCt.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmBpCt.Current).Row;
				this.Close();
			}
		}

		#endregion

		#region Su kien

		void bdsDmBpCt_PositionChanged(object sender, EventArgs e)
		{
			drCurrent = ((DataRowView)bdsDmBpCt.Current).Row;

            if ((string)drCurrent["Ma_Bp"] == "")
            {
                if ((string)drCurrent["Ma_Bp_Ct"] == "***")
                {
                    bdsEmployee.Filter = "Ma_Bp_Ct LIKE '%*%' AND Bold = 0";
                    bdsQLBL.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQHGD.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsHDLD.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQTCT.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLKT.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLKL.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLSC.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLDT.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLTS.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLCT.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLBDDH.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsNghiPhep.Filter = "Ma_Bp_Ct LIKE '%*%'";
                }
                else
                {
                    bdsEmployee.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsQLBL.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsQHGD.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsHDLD.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsQTCT.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsQLKT.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsQLKL.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsQLSC.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsQLDT.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsQLTS.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsQLCT.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsQLBDDH.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                    bdsNghiPhep.Filter = "Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'";
                }
            }
            else
            {
               
                bdsEmployee.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsQLBL.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsQHGD.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsHDLD.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsQTCT.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsQLKT.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsQLKL.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsQLSC.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsQLDT.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsQLTS.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsQLCT.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsQLBDDH.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
                bdsNghiPhep.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
            }
            
		}
        void bdsEmployee_PositionChanged(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsEmployee.Current).Row;

            bdsQLBL.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
            bdsQHGD.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
            bdsHDLD.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
            bdsQTCT.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
            bdsQLKT.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
            bdsQLKL.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
            bdsQLSC.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
            bdsQLDT.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
            bdsQLTS.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
            bdsQLCT.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
            bdsQLBDDH.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
            bdsNghiPhep.Filter = "Ma_Dt_CbNv = '" + drCurrent["Ma_Dt"] + "'";
        }
        void btEmployeeNew_Click(object sender, EventArgs e)
        {
            this.EditEmployee(enuEdit.New);
        }
        void btEmployeeEdit_Click(object sender, EventArgs e)
        {
            this.EditEmployee(enuEdit.Edit);
        }
        void btEmployeeDelete_Click(object sender, EventArgs e)
        {
            this.DeleteEmployee();
        }

		void btDetailNew_Click(object sender, EventArgs e)
		{
            if (tabDetail.SelectedTab == tpQHGD)
                this.EditQHGD(enuEdit.New);
            else if (tabDetail.SelectedTab == tpQLBL)
                this.EditQLBL(enuEdit.New);
            else if (tabDetail.SelectedTab == tpQTCT)
                this.EditQTCT(enuEdit.New);
            else if (tabDetail.SelectedTab == tpQLKT)
                this.EditQLKT(enuEdit.New);
            else if (tabDetail.SelectedTab == tpQLKL)
                this.EditQLKL(enuEdit.New);
            else if (tabDetail.SelectedTab == tpQLSC)
                this.EditQLSC(enuEdit.New);
            else if (tabDetail.SelectedTab == tpQLDT)
                this.EditQLDT(enuEdit.New);
            else if (tabDetail.SelectedTab == tpQLTS)
                this.EditQLTS(enuEdit.New);
            else if (tabDetail.SelectedTab == tpQLCT)
                this.EditQLCT(enuEdit.New);
            else if (tabDetail.SelectedTab == tpHDLD)
                this.EditHDLD(enuEdit.New);
            else if (tabDetail.SelectedTab == tpQLBDDH)
                this.EditQLBDDH(enuEdit.New);
            else if (tabDetail.SelectedTab == tpNghiPhep)
                this.EditNghiPhep(enuEdit.New);
		}

		void btDetailEdit_Click(object sender, EventArgs e)
		{
            if (tabDetail.SelectedTab == tpQHGD)
                this.EditQHGD(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpQLBL)
                this.EditQLBL(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpQTCT)
                this.EditQTCT(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpQLKT)
                this.EditQLKT(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpQLKL)
                this.EditQLKL(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpQLSC)
                this.EditQLSC(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpQLDT)
                this.EditQLDT(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpQLTS)
                this.EditQLTS(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpQLCT)
                this.EditQLCT(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpHDLD)
                this.EditHDLD(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpQLBDDH)
                this.EditQLBDDH(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpNghiPhep)
                this.EditNghiPhep(enuEdit.Edit);
		}

		void btDetailDelete_Click(object sender, EventArgs e)
		{
            if (tabDetail.SelectedTab == tpQHGD)
                this.DeleteQHGD();
            else if (tabDetail.SelectedTab == tpQLBL)
                this.DeleteQLBL();
            else if (tabDetail.SelectedTab == tpQTCT)
                this.DeleteQTCT();
            else if (tabDetail.SelectedTab == tpQLKT)
                this.DeleteQTKT();
            else if (tabDetail.SelectedTab == tpQLKL)
                this.DeleteQTKL();
            else if (tabDetail.SelectedTab == tpQLSC)
                this.DeleteQLSC();
            else if (tabDetail.SelectedTab == tpQLDT)
                this.DeleteQLDT();
            else if (tabDetail.SelectedTab == tpQLTS)
                this.DeleteQLTS();
            else if (tabDetail.SelectedTab == tpQLCT)
                this.DeleteQLCT();
            else if (tabDetail.SelectedTab == tpHDLD)
                this.DeleteHDLD();
            else if (tabDetail.SelectedTab == tpQLBDDH)
                this.DeleteQLBDDH();
            else if (tabDetail.SelectedTab == tpNghiPhep)
                this.DeleteNghiPhep();
		}
        void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData("");
        }
        void dgvEmployee_DoubleClick(object sender, EventArgs e)
        {
            this.EditEmployee(enuEdit.Edit);
        }
        void btNew_Thong_Tin_Click(object sender, EventArgs e)
        {
            this.EditEmployee_View();
        }

		void btNew_Click(object sender, EventArgs e)
        {
            this.EditDmBpCt(enuEdit.New);
        }

		void btEdit_Click(object sender, EventArgs e)
		{
            this.EditDmBpCt(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
            DeleteDmBpCt();
		}
        void btImport_Click(object sender, EventArgs e)
        {

            DataTable dtDmDt = DataTool.SQLGetDataTable("R81DMDT", "*", "Ma_Nh_Dt = 'NV'", "Ma_Dt");
            Voucher.ImportExcel_DMDTCBNV("DMDT", dtDmDt);
        }

		#endregion
	}
}
