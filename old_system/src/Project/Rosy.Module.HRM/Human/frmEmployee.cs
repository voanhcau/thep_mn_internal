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
using System.IO;
using System.Drawing.Printing;

namespace RosyModule.HRM
{
	public partial class frmEmployee : RosySystem.Customize.frmView
	{
		#region Khai bao bien
        
        object objActive = null;

		private rsTreeList tlDmBpCt = new rsTreeList();
		DataTable dtDmBpCt;
		BindingSource bdsDmBpCt = new BindingSource();

        private rsTreeList tlEmployee = new rsTreeList();
        DataTable dtObject;
        BindingSource bdsEmployee = new BindingSource();

		private DataRow drCurrent;

        DataTable dtQHGD;
        DataTable dtQLKSK;
        DataTable dtHDLD;
        DataTable dtQTCT;
        DataTable dtQLKT;
        DataTable dtQLKL;
        DataTable dtQLSC;
        DataTable dtQLDT;
        DataTable dtQLTS;
        DataTable dtQLCT;
        DataTable dtNghiPhep;
        DataTable dtTsTn;
 
        DataTable dtQLHSCB;

        BindingSource bdsQHGD = new BindingSource();
        BindingSource bdsQLKSK = new BindingSource();
        BindingSource bdsHDLD = new BindingSource();
        BindingSource bdsQTCT = new BindingSource();
        BindingSource bdsQLKT = new BindingSource();
        BindingSource bdsQLKL = new BindingSource();
        BindingSource bdsQLSC = new BindingSource();
        BindingSource bdsQLDT = new BindingSource();
        BindingSource bdsQLTS = new BindingSource();
        BindingSource bdsQLCT = new BindingSource();
        BindingSource bdsNghiPhep = new BindingSource();
        BindingSource bdsTsTn = new BindingSource();
       
        BindingSource bdsQLHSCB = new BindingSource();

        string strReportFile = "rptThongTinCBCNV";// "rptThongTinCBNV2C";
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
            btPrint.Click += new EventHandler(btPrint_Click);
            btPrintDetail.Click += new EventHandler(btPrintDetail_Click);
            btPrint2C.Click += new EventHandler(btPrint2C_Click);
            btChuyenBpCt.Click += new EventHandler(btChuyenBpCt_Click);
            btChuyenBp.Click += new EventHandler(btChuyenBp_Click);
            
            dgvEmployee.DoubleClick += new EventHandler(dgvEmployee_DoubleClick);
            dgvEmployee.KeyDown += new KeyEventHandler(dgvEmployee_KeyDown);
            cboLoc.SelectedIndexChanged+= new EventHandler(cboLoc_SelectedIndexChanged);

            btEmployeeNew.Click += new EventHandler(btEmployeeNew_Click);
            btEmployeeEdit.Click += new EventHandler(btEmployeeEdit_Click);
            btEmployeeDelete.Click += new EventHandler(btEmployeeDelete_Click);

			btDetailNew.Click += new EventHandler(btDetailNew_Click);
			btDetailEdit.Click += new EventHandler(btDetailEdit_Click);
			btDetailDelete.Click += new EventHandler(btDetailDelete_Click);
            //btAddAnh.Click += new EventHandler(btAddAnh_Click);
            btCreateData.Click += new EventHandler(btQuery_Click);

            dgvEmployee.Enter += new EventHandler(dgvEmployee_Enter);
            dgvQHGD.Enter += new EventHandler(dgvQHGD_Enter);
            dgvQLCT.Enter += new EventHandler(dgvQLCT_Enter);
            dgvHDLD.Enter += new EventHandler(dgvHDLD_Enter);
            dgvTNLD.Enter += new EventHandler(dgvTNLD_Enter);
            dgvQLDT.Enter += new EventHandler(dgvQLDT_Enter);
            dgvQLTS.Enter += new EventHandler(dgvQLTS_Enter);
            dgvQLKL.Enter += new EventHandler(dgvQLKL_Enter);
            dgvQLKT.Enter += new EventHandler(dgvQLKT_Enter);
            dgvQTCT.Enter += new EventHandler(dgvQTCT_Enter);
            dgvTsTn.Enter += new EventHandler(dgvTsTn_Enter);
          
            dgvQLHSCB.Enter += new EventHandler(dgvQLHSCB_Enter);

            dgvHDLD.KeyDown += new KeyEventHandler(dgvHDLD_KeyDown);
            dgvQHGD.KeyDown += new KeyEventHandler(dgvQHGD_KeyDown);
            dgvQLCT.KeyDown += new KeyEventHandler(dgvQLCT_KeyDown);
            dgvQLKT.KeyDown += new KeyEventHandler(dgvQLKT_KeyDown);
            dgvQLKL.KeyDown += new KeyEventHandler(dgvQLKL_KeyDown);
            dgvTNLD.KeyDown += new KeyEventHandler(dgvTNLD_KeyDown);
            dgvQLDT.KeyDown += new KeyEventHandler(dgvQLDT_KeyDown);
            dgvQLTS.KeyDown += new KeyEventHandler(dgvQLTS_KeyDown);
            dgvQTCT.KeyDown += new KeyEventHandler(dgvQTCT_KeyDown);
            dgvTsTn.KeyDown += new KeyEventHandler(dgvTsTn_KeyDown);
         
            dgvQLHSCB.KeyDown += new KeyEventHandler(dgvQLHSCB_KeyDown);

            dgvQLHSCB.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvQLHSCB_CellMouseClick);
            dgvQLDT.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvQLDT_CellMouseClick);
            dgvQLKL.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvQLKL_CellMouseClick);
		}

       
		public override void Load()
		{
			this.Build();
			this.FillData(string.Empty);
			this.BindingData();
			this.BindingLanguage();

            //PHAN QUYEN XEM DL
            if (!Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access) && !Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) && !Common.CheckPermission("IS_ALLCBNV", enuPermission_Type.Allow_Access))
            {
               
                this.tabDetail.TabPages.Remove(tpTsTn);
            }


            cboLoc.DisplayMember = "Text";
            cboLoc.ValueMember = "Value";
      

            cboLoc.Items.Add(new { Text = "Đang làm việc", Value = "1" });
            cboLoc.Items.Add(new { Text = "Tất cả", Value = "2" });
            cboLoc.Items.Add(new { Text = "Đã nghỉ việc", Value = "3" });
            cboLoc.Items.Add(new { Text = "Điều chuyển trong VNS", Value = "4" });
            cboLoc.SelectedIndex = 1;

            cboDesign.DisplayMember = "Text";
            cboDesign.ValueMember = "Value";

            cboDesign.Items.Add(new { Text = "rptThongTinCBCNV", Value = "1" });
            cboDesign.Items.Add(new { Text = "rptThongTinCBNV2C", Value = "2" });
            
            cboDesign.SelectedIndex = 1;
            //
            if (!Element.sysIs_Admin)
                cboDesign.Visible = false;

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
			tlDmBpCt.KeyFieldName = "MA_BP_CT";
			tlDmBpCt.ParentFieldName = "MA_BP_CT_CHA";
			tlDmBpCt.Dock = DockStyle.Fill;
			tlDmBpCt.strZone = "DMBPCT";
			tlDmBpCt.BuildTreeList(this.isLookup);

			this.pageEmployee.Controls.Add(tlDmBpCt);

            dgvEmployee.Dock = DockStyle.Fill;
            dgvEmployee.strZone = "EMPLOYEE";
            dgvEmployee.BuildGridView();

            dgvQLKSK.strZone = "QLKSK";
            dgvQLKSK.BuildGridView();
            
            if (dgvQLKSK.Columns.Contains("Ket_Qua_KSK"))
            {
                dgvQLKSK.Columns["Ket_Qua_KSK"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvQLKSK.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvQLKSK.Columns.Contains("Tu_Van_KSK"))
            {
                dgvQLKSK.Columns["Tu_Van_KSK"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvQLKSK.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvQLKSK.Columns.Contains("Thong_Tin_KSK"))
            {
                dgvQLKSK.Columns["Thong_Tin_KSK"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvQLKSK.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

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

            dgvTNLD.strZone = "QLSC";
            dgvTNLD.BuildGridView();

            dgvQLDT.strZone = "QTDT";
            dgvQLDT.BuildGridView();

            dgvQLTS.strZone = "QLTS";
            dgvQLTS.BuildGridView();

            dgvQLCT.strZone = "QLCT";
            dgvQLCT.BuildGridView();

            dgvNghiPhep.strZone = "NGHIPHEP";
            dgvNghiPhep.BuildGridView();

            dgvTsTn.strZone = "TSTN0";
            dgvTsTn.BuildGridView();

          

            dgvQLHSCB.strZone = "QLHSCB";
            dgvQLHSCB.BuildGridView();

            ExportControl = dgvEmployee;
		}
        private void Language()
        {

            dgvEmployee.Columns["Ma_Dt"].HeaderText = "Mã số";
            dgvEmployee.Columns["Ten_Dt"].HeaderText = "Họ và tên";
            dgvEmployee.Columns["Cap_Ngay"].HeaderText = "Cấp ngày";
            dgvEmployee.Columns["Trinh_Do_DT"].HeaderText = "Trình độ ĐT";
            //
            dgvQHGD.Columns["Ma_Dt"].HeaderText = "Mã số";
            dgvQHGD.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvHDLD.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvQTCT.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvQLKT.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvQLKL.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvQLDT.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvTNLD.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvQLTS.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvQLCT.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvNghiPhep.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvQLKSK.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvTsTn.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
            //
            dgvQLHSCB.Columns["Ten_Dt"].HeaderText = "Họ và tên CB-CNV";
        }
		private void FillData(string strKey)
		{
            string strMa_Bp = SQLExec.ExecuteReturnValue("select Ma_Bp  FROM R81DMDT WHERE Ma_Dt in (select ma_dt_cbnv FROM R00MEMBER WHERE MEMBER_ID = '" + Element.sysUser_Id.ToString() + "')").ToString();
            Hashtable ht1 = new Hashtable();
            ht1.Add("USER_LOGIN", Element.sysUser_Id);
            dtDmBpCt = SQLExec.ExecuteReturnDt("Sp_GetDmBpCt", ht1, CommandType.StoredProcedure);

			bdsDmBpCt.DataSource = dtDmBpCt;
			tlDmBpCt.DataSource = bdsDmBpCt;

            Hashtable ht = new Hashtable();
            ht.Add("LOAI", cboLoc.SelectedIndex);         
            ht.Add("NAM", Element.sysWorkingYear);
            ht.Add("USER_LOGIN", Element.sysUser_Id);
            DataSet dsEmployee = SQLExec.ExecuteReturnDs("Sp_GetDmDtCbNv", ht, CommandType.StoredProcedure);
            
            dtObject = dsEmployee.Tables[0];
            bdsEmployee.DataSource = dtObject;
            dgvEmployee.DataSource = bdsEmployee;

            //QLKSK
            dtQLKSK = dsEmployee.Tables[1];
            bdsQLKSK.DataSource = dtQLKSK;
            dgvQLKSK.DataSource = bdsQLKSK;

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
            dgvTNLD.DataSource = bdsQLSC;

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


            //TstN
            dtTsTn = dsEmployee.Tables[12];
            bdsTsTn.DataSource = dtTsTn;
            dgvTsTn.DataSource = bdsTsTn;



            //QLHSCB
            dtQLHSCB = dsEmployee.Tables[13];
            bdsQLHSCB.DataSource = dtQLHSCB;
            dgvQLHSCB.DataSource = bdsQLHSCB;


			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsEmployee;
            

			tlDmBpCt.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmBpCt.strZone + "'");
            
            numTSo_Luong.DataBindings.Clear();
            numTSo_Luong.DataBindings.Add("Value", dtObject, "TSo_Luong");
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
                drCurrent = dtObject.NewRow();

            frmEmployee_Edit frmEdit = new frmEmployee_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, bdsEmployee);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
                    
                    if (bdsEmployee.Position >= 0)
                        dtObject.ImportRow(drCurrent);
					else
                        dtObject.Rows.Add(drCurrent);

                    bdsEmployee.Position = bdsEmployee.Find("Ma_Dt", drCurrent["Ma_Dt"]);
				}
				else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEmployee.Current).Row);

                dtObject.AcceptChanges();
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
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
                //FillData("");
                dtQHGD.AcceptChanges();
            }
            else
                dtQHGD.RejectChanges();
        }
       
        void EditQLBL(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsQLKSK.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsQLKSK.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQLKSK.Current).Row, ref drCurrent);
            else
                drCurrent = dtQLKSK.NewRow();
            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];
            frmQLKSK_Edit frmEdit = new frmQLKSK_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQLKSK.Position >= 0)
                        dtQLKSK.ImportRow(drCurrent);
                    else
                        dtQLKSK.Rows.Add(drCurrent);

                    bdsQLKSK.Position = bdsQLKSK.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQLKSK.Current).Row);
                }
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
                dtQLKSK.AcceptChanges();
            }
            else
                dtQLKSK.RejectChanges();
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
                //drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                //drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
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
            
            if(enuNew_Edit == enuEdit.New)
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
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
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

            if (enuNew_Edit == enuEdit.New)
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
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
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

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ma_Bp_Ct"] = (string)drEmployee["Ma_Bp_Ct"];
            }
            frmTNLD_Edit frmEdit = new frmTNLD_Edit();
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

                    bdsQLSC.Position = bdsQLSC.Find("Ma_TNLD", drCurrent["Ma_TNLD"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQLSC.Current).Row);
                }
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
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
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
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
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
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
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
                dtHDLD.AcceptChanges();
            }
            else
                dtHDLD.RejectChanges();
        }
        void EditTsTn(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsTsTn.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsTsTn.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsTsTn.Current).Row, ref drCurrent);
            else
                drCurrent = dtTsTn.NewRow();

            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];

            frmTsTn0_Edit frmEdit = new frmTsTn0_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsTsTn.Position >= 0)
                        dtTsTn.ImportRow(drCurrent);
                    else
                        dtTsTn.Rows.Add(drCurrent);

                    bdsTsTn.Position = bdsTsTn.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsTsTn.Current).Row);
                }
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
                dtTsTn.AcceptChanges();
            }
            else
                dtTsTn.RejectChanges();
        }
        
        void EditQLHSCB(enuEdit enuNew_Edit)
        {
            if (bdsEmployee.Position < 0)
                return;

            if (bdsQLHSCB.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsEmployee.Current).Row;

            //Copy hang hien tai            
            if (bdsQLHSCB.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQLHSCB.Current).Row, ref drCurrent);
            else
                drCurrent = dtQLHSCB.NewRow();

            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];


            frmQLHSCB_Edit frmEdit = new frmQLHSCB_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQLHSCB.Position >= 0)
                        dtQLHSCB.ImportRow(drCurrent);
                    else
                        dtQLHSCB.Rows.Add(drCurrent);

                    bdsQLHSCB.Position = bdsQLHSCB.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQLHSCB.Current).Row);
                }
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
                dtQLHSCB.AcceptChanges();
            }
            else
                dtTsTn.RejectChanges();
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
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
                dtQLTS.AcceptChanges();
            }
            else
                dtQLTS.RejectChanges();
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
                drCurrent["Ma_Dt"] = (string)drEmployee["Ma_Dt"];
                drCurrent["Ten_Dt"] = (string)drEmployee["Ten_Dt"];
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

            if (!Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access))
            {
                Common.MsgOk("Bạn không có quyền thêm/ sửa dữ liệu bộ phận chi tiết!!!");
                return;
            }
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
            if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                Common.MsgOk("Bạn không được phân quyền xóa!!!");
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
                dtObject.AcceptChanges();
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
            if (bdsQLKSK.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQLKSK.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QLBL", drCurrent))
            {
                bdsQLKSK.RemoveAt(bdsQLKSK.Position);
                dtQLKSK.AcceptChanges();
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
        void DeleteQLHSCB()
        {
            if (bdsQLHSCB.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQLHSCB.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;
            string strFile_Path = drCurrent["File_Path"].ToString();
            if (DataTool.SQLDelete("R09HSQLCB", drCurrent))
            {
                //Xóa file tại server
                Voucher.Delete_File_Dm(strFile_Path);
                bdsQLHSCB.RemoveAt(bdsQLHSCB.Position);
                dtQLHSCB.AcceptChanges();
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

            if (DataTool.SQLDelete("R09TNLD", drCurrent))
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
            
            string strFile_Path = drCurrent["File_Path"].ToString();
            
            if (DataTool.SQLDelete("R09QTDT", drCurrent))
            {
                //Xóa file tại server
                if (strFile_Path != string.Empty)
                    File.Delete(strFile_Path);

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
        void DeleteTsTn()
        {
            if (bdsTsTn.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsTsTn.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R10TSTN0", drCurrent))
            {
                bdsTsTn.RemoveAt(bdsTsTn.Position);
                dtTsTn.AcceptChanges();
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

            if(!Common.CheckPermission("IS_TP_TCHC",enuPermission_Type.Allow_Access))
            {
                Common.MsgOk("Bạn không có quyền xóa dữ liệu bộ phận chi tiết");
                return;
            }
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
            DataRow drDmBp = DataTool.SQLGetDataRowByID("R81DMBP", "Ma_Bp", drCurrent["Ma_Bp_Ct"].ToString());
            if ((string)drCurrent["Ma_Bp_Ct"] == "")
            {
                if ((string)drCurrent["Ma_Bp_Ct"] == "***")
                {
                    bdsEmployee.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLKSK.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQHGD.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsHDLD.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQTCT.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLKT.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLKL.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLSC.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLDT.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLTS.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsQLCT.Filter = "Ma_Bp_Ct LIKE '%*%'";
                  
                    bdsNghiPhep.Filter = "Ma_Bp_Ct LIKE '%*%'";
                    bdsTsTn.Filter = "Ma_Bp_Ct LIKE '%*%'";
                   
                    bdsQLHSCB.Filter = "Ma_Bp_Ct LIKE '%*%'";
                }
               
            }
            else
            {
               
                bdsEmployee.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
                bdsQLKSK.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
                bdsQHGD.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
                bdsHDLD.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
                bdsQTCT.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
                bdsQLKT.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
                bdsQLKL.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
                bdsQLSC.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
                bdsQLDT.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
                bdsQLTS.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
                bdsQLCT.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";

                bdsNghiPhep.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
                bdsTsTn.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
              
                bdsQLHSCB.Filter = "Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'";
            }

            if (drDmBp != null)
            {

                bdsEmployee.Filter = "Ma_Bp LIKE '" + drDmBp["Ma_Bp"].ToString() + "'";
                bdsQLKSK.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";
                bdsQHGD.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";
                bdsHDLD.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";
                bdsQTCT.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";
                bdsQLKT.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";
                bdsQLKL.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";
                bdsQLSC.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";
                bdsQLDT.Filter = "Ma_Bp LIKE '"+ drCurrent["Ma_Bp"] +"'";
                bdsQLTS.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";
                bdsQLCT.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";

                bdsNghiPhep.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";
                bdsTsTn.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";
               
                bdsQLHSCB.Filter = "Ma_Bp LIKE '" + drCurrent["Ma_Bp"] + "'";
            }
		}
        void bdsEmployee_PositionChanged(object sender, EventArgs e)
        {

            if (((DataRowView)bdsEmployee.Current) != null)
            {
                drCurrent = ((DataRowView)bdsEmployee.Current).Row;

                bdsQLKSK.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
                bdsQHGD.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
                bdsHDLD.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
                bdsQTCT.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
                bdsQLKT.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
                bdsQLKL.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
                bdsQLSC.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
                bdsQLDT.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
                bdsQLTS.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
                bdsQLCT.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";

                bdsNghiPhep.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
                bdsTsTn.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
              
                bdsQLHSCB.Filter = "Ma_Dt_CbNv LIKE '" + drCurrent["Ma_Dt"] + "'";
            }
            
        }
        void btEmployeeNew_Click(object sender, EventArgs e)
        {
            this.EditEmployee(enuEdit.New);
        }
        void btEmployeeEdit_Click(object sender, EventArgs e)
        {
            this.EditEmployee(enuEdit.Edit);
        }
        void btChuyenBpCt_Click(object sender, EventArgs e)
        {
            if (bdsEmployee.Position < 0)
				return;

            drCurrent = ((DataRowView)bdsEmployee.Current).Row;

            frmChuyenBPCT_Edit frm = new frmChuyenBPCT_Edit();
            frm.Load(enuEdit.Edit, drCurrent);


        }
        void btChuyenBp_Click(object sender, EventArgs e)
        {
            if (bdsEmployee.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsEmployee.Current).Row;

            frmChuyenBP_Edit frm = new frmChuyenBP_Edit();
            frm.Load(enuEdit.Edit, drCurrent);
        }
        void btEmployeeDelete_Click(object sender, EventArgs e)
        {
            this.DeleteEmployee();
        }
        void btQuery_Click(object sender, EventArgs e)
        {
            string strLoai = string.Empty;
            if (this.objActive == dgvQLTS)
                strLoai = "QLTS";
            else if (this.objActive == dgvHDLD)
                strLoai = "HDLD";
            else if (this.objActive == dgvQLDT)
                strLoai = "QLDT";
            else if (this.objActive == dgvTNLD)
                strLoai = "TNLD";
            else if (this.objActive == dgvQLKT)
                strLoai = "QLKT";
            else if (this.objActive == dgvQLKL)
                strLoai = "QLKL";
           

            frmQuery_Employee frm = new frmQuery_Employee();
            frm.Load(strLoai);
            FillData("");
        }
		void btDetailNew_Click(object sender, EventArgs e)
		{
            if (tabDetail.SelectedTab == tpQHGD)
                this.EditQHGD(enuEdit.New);
            else if (tabDetail.SelectedTab == tpQLKSK)
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
            else if (tabDetail.SelectedTab == tpTsTn)
                this.EditTsTn(enuEdit.New);
           
            else if (tabDetail.SelectedTab == tpQLHSCB)
                this.EditQLHSCB(enuEdit.New);
		}

		void btDetailEdit_Click(object sender, EventArgs e)
		{
            if (tabDetail.SelectedTab == tpQHGD)
                this.EditQHGD(enuEdit.Edit);
            else if (tabDetail.SelectedTab == tpQLKSK)
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
            else if (tabDetail.SelectedTab == tpTsTn)
                this.EditTsTn(enuEdit.Edit);
           
            else if (tabDetail.SelectedTab == tpQLHSCB)
                this.EditQLHSCB(enuEdit.Edit);
		}

		void btDetailDelete_Click(object sender, EventArgs e)
		{
            if (tabDetail.SelectedTab == tpQHGD)
                this.DeleteQHGD();
            else if (tabDetail.SelectedTab == tpQLKSK)
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
            else if (tabDetail.SelectedTab == tpTsTn)
                this.DeleteTsTn();
           
            else if (tabDetail.SelectedTab == tpQLHSCB)
                this.DeleteQLHSCB();
            //else if (tabDetail.SelectedTab == tpNghiPhep)
            //    this.DeleteNghiPhep();
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
            // Import khám sức khỏe
            frmReadExcel_ToFrom frmImport = new frmReadExcel_ToFrom();
            frmImport.Load("LYLICH");

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                string strSQL = string.Empty;
                string strMa_Dt_CbNv = string.Empty;
                string strKet_Qua_KSK = string.Empty;
                string strTu_Van_KSK = string.Empty;
                string strThong_Tin_KSK = string.Empty;
                foreach (DataRow dr in frmImport.dtImport.Rows)
                {
                    strMa_Dt_CbNv = dr["Ma_Dt_CbNv"].ToString();
                    
                    if (strMa_Dt_CbNv.Length == 4)
                    {
                        strMa_Dt_CbNv = strMa_Dt_CbNv.Replace("M", "M0");
                    }

                    if(strMa_Dt_CbNv == "" || strMa_Dt_CbNv == string.Empty)
                        continue;
                    if (DataTool.SQLCheckExist("R09QLSK", new string[] { "Ma_Dt_CbNv", "Ngay_KSK" }, new object[] { strMa_Dt_CbNv, Convert.ToDateTime(dr["Ngay_KSK"]).ToShortDateString() }))
                    {
                        string strMsg = "Mã nhân viên = {" + strMa_Dt_CbNv + "}, Ngày khám sức khỏe = {" + dr["Ngay_KSK"].ToString() + "} đã tồn tại";
                        strMsg += Element.sysLanguage == enuLanguageType.English ? " already exist, do you want to add more?" : " đã tồn tại, Bạn không tạo 2 dòng giống nhau!!!";
                        Common.MsgOk(strMsg);
                        continue;


                    }
                    else
                    {
                        strKet_Qua_KSK = dr["Ket_Qua_KSK"].ToString();
                        strTu_Van_KSK = dr["Tu_Van_KSK"].ToString();
                        strThong_Tin_KSK = dr["Thong_Tin_KSK"].ToString();
                        if (strKet_Qua_KSK.StartsWith("\n'"))
                            strKet_Qua_KSK = strKet_Qua_KSK.Replace("\n'", "\n");
                        if (strTu_Van_KSK.StartsWith("\n'"))
                            strTu_Van_KSK = strTu_Van_KSK.Replace("\n'", "\n");
                        if (strThong_Tin_KSK.StartsWith("\n'"))
                            strThong_Tin_KSK = strThong_Tin_KSK.Replace("\n'", "\n");

                        strSQL = "INSERT INTO R09QLSK (Ma_Dt_CbNv, Ngay_KSK, Chieu_Cao, Can_Nang, Thong_Tin_KSK, Ma_Data, Ket_Qua_KSK, Tu_Van_KSK, Xep_Loai_KSK, Mach, Huyet_Ap, BMI) " +
                            " SELECT '" + strMa_Dt_CbNv + "', '" + Convert.ToDateTime(dr["Ngay_KSK"]).ToShortDateString() + "',ISNULL('" + dr["Chieu_Cao"].ToString() + "',0),ISNULL('" + dr["Can_Nang"].ToString() + "',0), N'" + strThong_Tin_KSK + "', " +
                            " '" + Element.sysMa_Data + "',N'" + strKet_Qua_KSK + "',N'" + strTu_Van_KSK + "',N'" + dr["Xep_Loai_KSK"].ToString() + "',ISNULL('" + dr["Mach"].ToString() + "',0),ISNULL('" + dr["Huyet_Ap"].ToString() + "',''), ISNULL('" + dr["BMI"].ToString() + "',0)";
                        try
                        {
                            SQLExec.Execute(strSQL);
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.ToString());
                            MessageBox.Show(strSQL);
                        }
                       
                    }
                }
            }
            FillData("");
        }
       private void Delete_TT()
        {
            if (this.objActive == dgvQLTS)
                this.DeleteQLTS();
            else if (this.objActive == dgvQLDT)
                this.DeleteQLDT();
            else if (this.objActive == dgvTNLD)
                this.DeleteQLSC();
            else if (this.objActive == dgvQTCT)
                this.DeleteQTCT();
            else if (this.objActive == dgvQHGD)
                this.DeleteQHGD();

            else if (this.objActive == dgvQLKT)
                this.DeleteQTKT();
            else if (this.objActive == dgvQLKL)
                this.DeleteQTKL();
            else if (this.objActive == dgvQTCT)
                this.DeleteQTCT();
            else if (this.objActive == dgvQLHSCB)
                this.DeleteQLHSCB();
        }

       private void Edit_TT(enuEdit enuNew_Edit)
        {
            if (this.objActive == dgvQLTS)
                this.EditQLTS(enuNew_Edit);
            else if (this.objActive == dgvQLDT)
                this.EditQLDT(enuNew_Edit);
            else if (this.objActive == dgvTNLD)
                this.EditQLSC(enuNew_Edit);
            else if (this.objActive == dgvQTCT)
                this.EditQTCT(enuNew_Edit);
            else if (this.objActive == dgvQHGD)
                this.EditQHGD(enuNew_Edit);

            else if (this.objActive == dgvQLKT)
                this.EditQLKT(enuNew_Edit);
            else if (this.objActive == dgvQLKL)
                this.EditQLKL(enuNew_Edit);
            else if (this.objActive == dgvQTCT)
                this.EditQTCT(enuNew_Edit);
            else if (this.objActive == dgvQLHSCB)
                this.EditQLHSCB(enuNew_Edit);

        }
       void dgvQLHSCB_Enter(object sender, EventArgs e)
       {
           ExportControl = sender;
           objActive = dgvQLHSCB;
       }
     
       
       void dgvTsTn_Enter(object sender, EventArgs e)
       {
           ExportControl = sender;
           objActive = dgvTsTn;
       }
        void dgvQTCT_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvQTCT;
        }

        void dgvQLKT_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvQLKT;
        }

        void dgvQLKL_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvQLKL;
        }
        void dgvQLTS_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvQLTS;
        }

        void dgvQLDT_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvQLDT;
        }

        void dgvTNLD_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvTNLD;
        }

        void dgvHDLD_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvHDLD;
        }

        void dgvQLCT_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvQLCT;
        }

        void dgvQHGD_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvQHGD;
        }

        void dgvEmployee_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvEmployee;
        }
		#endregion

        void dgvEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.EditEmployee(enuEdit.New);
                    break;
                case Keys.F3:
                    this.EditEmployee(enuEdit.Edit);
                    break;
                case Keys.F8:
                    this.DeleteEmployee();
                    break;
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            this.Design();
                            break;
                    }
                    break;
               
            }
        }

        void dgvQHGD_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    Edit_TT(enuEdit.New);
                    break;
                case Keys.F3:
                    Edit_TT(enuEdit.Edit);
                    break;
                case Keys.F8:
                    Delete_TT();
                    break;
            }
        }
    
       
        void dgvTsTn_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditTsTn(enuEdit.New);
                    break;
                case Keys.F3:
                    EditTsTn(enuEdit.Edit);
                    break;
                case Keys.F8:
                    DeleteTsTn();
                    break;
            }
        }
        void dgvQLHSCB_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditQLHSCB(enuEdit.New);
                    break;
                case Keys.F3:
                    EditQLHSCB(enuEdit.Edit);
                    break;
                case Keys.F8:
                    DeleteQLHSCB();
                    break;
            }
        }
        void dgvQTCT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    Edit_TT(enuEdit.New);
                    break;
                case Keys.F3:
                    Edit_TT(enuEdit.Edit);
                    break;
                case Keys.F8:
                    Delete_TT();
                    break;
            }
        }

        void dgvQLTS_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    Edit_TT(enuEdit.New);
                    break;
                case Keys.F3:
                    Edit_TT(enuEdit.Edit);
                    break;
                case Keys.F8:
                    Delete_TT();
                    break;
            }
        }

        void dgvQLDT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    Edit_TT(enuEdit.New);
                    break;
                case Keys.F3:
                    Edit_TT(enuEdit.Edit);
                    break;
                case Keys.F8:
                    Delete_TT();
                    break;
            }
        }

        void dgvTNLD_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    Edit_TT(enuEdit.New);
                    break;
                case Keys.F3:
                    Edit_TT(enuEdit.Edit);
                    break;
                case Keys.F8:
                    Delete_TT();
                    break;
            }
        }

        void dgvQLKL_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    Edit_TT(enuEdit.New);
                    break;
                case Keys.F3:
                    Edit_TT(enuEdit.Edit);
                    break;
                case Keys.F8:
                    Delete_TT();
                    break;
            }
        }

        void dgvQLKT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    Edit_TT(enuEdit.New);
                    break;
                case Keys.F3:
                    Edit_TT(enuEdit.Edit);
                    break;
                case Keys.F8:
                    Delete_TT();
                    break;
            }
        }

        void dgvQLCT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    Edit_TT(enuEdit.New);
                    break;
                case Keys.F3:
                    Edit_TT(enuEdit.Edit);
                    break;
                case Keys.F8:
                    Delete_TT();
                    break;
            } throw new NotImplementedException();
        }

        void dgvHDLD_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    Edit_TT(enuEdit.New);
                    break;
                case Keys.F3:
                    Edit_TT(enuEdit.Edit);
                    break;
                case Keys.F8:
                    Delete_TT();
                    break;
            }
        }
        void dgvQLKL_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsQLKL.Current).Row;
            DataGridViewCell dgvCell = dgvQLKL.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "OPEN_FILE")
            {
                if (bdsQLKL.Position < 0)
                    return;

                drCurrent = ((DataRowView)bdsQLKL.Current).Row;
                Voucher.Open_File_Dm((string)drCurrent["File_Path"]);
                //object objFile = (object)drCurrent["File_Path"];
                //string strPath = (string)drCurrent["File_Path"];

                //if (objFile != null && objFile != DBNull.Value)
                //{
                //    FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);

                //    fileStream.Close();
                //    System.Diagnostics.Process.Start(strPath);
                //}
            }
        }
        void dgvQLHSCB_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsQLHSCB.Current).Row;
			DataGridViewCell dgvCell = dgvQLHSCB.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "OPEN_FILE")
            {
                if (bdsQLHSCB.Position < 0)
                    return;

                drCurrent = ((DataRowView)bdsQLHSCB.Current).Row;
                Voucher.Open_File_Dm((string)drCurrent["File_Path"]);
                //object objFile = (object)drCurrent["File_Path"];
                //string strPath = (string)drCurrent["File_Path"];

                //if (objFile != null && objFile != DBNull.Value)
                //{
                //    FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);

                //    fileStream.Close();
                //    System.Diagnostics.Process.Start(strPath);
                //}
            }
        }

        void dgvQLDT_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsQLDT.Current).Row;
            DataGridViewCell dgvCell = dgvQLDT.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "OPEN_FILE")
            {
                if (bdsQLDT.Position < 0)
                    return;

                drCurrent = ((DataRowView)bdsQLDT.Current).Row;
                object objFile = (object)drCurrent["File_Path"];
                string strPath = (string)drCurrent["File_Path"];

                if (objFile != null && objFile != DBNull.Value && strPath != string.Empty)
                {
                    FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);

                    fileStream.Close();
                    System.Diagnostics.Process.Start(strPath);
                }
            }
        }

        void btPrint2C_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsEmployee.Current).Row;
            Voucher.Print2C(drCurrent["Ma_Dt"].ToString(), true, true, strReportFile);

        }


        void btPrintDetail_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsEmployee.Current).Row;
            Print(drCurrent["Ma_Dt"].ToString(), true, true);
        }

        void btPrint_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsDmBpCt.Current).Row;
            if (drCurrent["Ma_Bp_Ct"].ToString() == "***")
            {
                foreach (DataRow dr in dtObject.Rows)
                    Print(dr["Ma_Dt"].ToString(), false, true);
            }
            else if (drCurrent["Ma_Bp_Ct"].ToString() == drCurrent["Ma_Bp"].ToString())
            {
                foreach (DataRow dr in dtObject.Select("Ma_Bp = '" + drCurrent["Ma_Bp_Ct"] + "'"))
                    Print(dr["Ma_Dt"].ToString(), false, true);
            }
            else
            {
                foreach (DataRow dr in dtObject.Select("Ma_Bp_Ct LIKE '" + drCurrent["Ma_Bp_Ct"] + "%'"))
                    Print(dr["Ma_Dt"].ToString(), false, false);
                //Print(dr["Ma_Dt"].ToString(), false, true);
            }
        }
        private void Print(string strMa_Dt_CbNv, bool bPreview, bool bShow)
        {
            Hashtable ht = new Hashtable();
            ht.Add("MA_DT_CBNV", strMa_Dt_CbNv);
            ht.Add("NAM", Element.sysWorkingYear);
            DataSet dsHSNV = SQLExec.ExecuteReturnDs("sp_PrintHsCBNV", ht, CommandType.StoredProcedure);

            DataTable dtHeader = dsHSNV.Tables[0];
            DataTable dtDetail = dsHSNV.Tables[1];


            dtHeader.Columns.Add("REPORT_FILE", typeof(string));
            dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));

            dtHeader.Rows[0]["Report_File"] = "rptThongTinCBCNV";
            dtHeader.Rows[0]["Ngay_Ct"] = DateTime.Now;

            string strPrinterName = string.Empty;

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();

            PrintDocument printDoc = new PrintDocument();

            if (printDoc.PrinterSettings.IsDefaultPrinter)
                strPrinterName = printDoc.PrinterSettings.PrinterName;

            if (strPrinterName == "")
            {
                frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShow);



            }
            else
                frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, strPrinterName);
        }

        private void Design()
        {
            strReportFile = cboDesign.Text;

            RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
            frm.Load(strReportFile);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Language();
        }
    }
}
