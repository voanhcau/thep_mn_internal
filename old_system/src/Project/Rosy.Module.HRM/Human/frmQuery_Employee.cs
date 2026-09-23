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

namespace RosyModule.HRM
{
	public partial class frmQuery_Employee : RosySystem.Customize.frmView
	{
		#region Khai bao bien
        string strLoai = string.Empty;
        private rsTreeList tlDmNhLopDt = new rsTreeList();
        DataSet dsObject = new DataSet();
        DataTable dtObject;
		DataTable dtTTNV;
        DataTable dtLopDT;

        BindingSource bdsObject = new BindingSource();
        BindingSource bdsTTNV = new BindingSource();
        BindingSource bdsLopDT = new BindingSource();

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

		#endregion

		#region Contructor

        public frmQuery_Employee()
		{
			InitializeComponent();

            bdsObject.PositionChanged += new EventHandler(bdsObject_PositionChanged);
            bdsLopDT.PositionChanged += new EventHandler(bdsLopDT_PositionChanged);

            this.btDetailNew.Click += new EventHandler(btDetailNew_Click);
            this.btDetailEdit.Click += new EventHandler(btDetailEdit_Click);
            this.btDetailDelete.Click += new EventHandler(btDetailDelete_Click);
            this.btNewList.Click += new EventHandler(btNewList_Click);
            tlDmNhLopDt.KeyDown += new KeyEventHandler(dgvObject_KeyDown);
            dgvLopDT.KeyDown += new KeyEventHandler(dgvLopDT_KeyDown);
            dgvQLDT.KeyDown += new KeyEventHandler(dgvQLDT_KeyDown);

            dgvQLDT.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvQLDT_CellMouseClick);
		}

		public override void Load()
		{
			this.Build();
			this.FillData(string.Empty);
			this.BindingData();
			this.BindingLanguage();

			this.Show();

            tlDmNhLopDt.Focus();
		}
        public void Load(string strLoai)
        {
            this.strLoai = strLoai;
            this.Build();
            this.FillData(string.Empty);
            this.BindingData();
            this.BindingLanguage();

            this.ShowDialog();

            //tlDmCbNv.Focus();
        }
		#endregion

		#region Build, FillData

		private void Build()
		{

            tlDmNhLopDt.KeyFieldName = "MA_NH_LOPDT";
            tlDmNhLopDt.ParentFieldName = "MA_NH_LOPDT_PARENT";
            tlDmNhLopDt.Dock = DockStyle.Fill;

            tlDmNhLopDt.strZone = "DMNHLOPDT";
            tlDmNhLopDt.BuildTreeList(this.isLookup);
            //this.tabEmployee.Controls.Add(tlDmNhLopDt);
            this.splitContainer1.Panel1.Controls.Add(tlDmNhLopDt);
            //this.splitcContent1.Panel1.Controls.Add(tlDmNhLopDt);


            //dgvObject.strZone = "DMNHLOPDT";
            //dgvObject.BuildGridView();
            

            dgvLopDT.strZone = "DMLOPDT";
            dgvLopDT.BuildGridView();

            dgvQLDT.strZone = "QTDT";
            dgvQLDT.BuildGridView();
            //}		
		}

		private void FillData(string strKey)
		{
            //Hashtable ht = new Hashtable();
            //if (strLoai == "QLDT")
            //{
                dsObject = SQLExec.ExecuteReturnDs("sp_GetQLDaoTao",  CommandType.StoredProcedure);


                dtObject = dsObject.Tables[0];
                bdsObject.DataSource = dtObject;
                tlDmNhLopDt.DataSource = bdsObject;


                dtLopDT = dsObject.Tables[1];
                bdsLopDT.DataSource = dtLopDT;
                dgvLopDT.DataSource = bdsLopDT;

                dtQLDT = dsObject.Tables[2];
                bdsQLDT.DataSource = dtQLDT;
                dgvQLDT.DataSource = bdsQLDT;
            //}
		}

		private void BindingData()
		{
			
		}

		#endregion

		#region Update
        void EditHDLD(enuEdit enuNew_Edit)
        {
            if (bdsObject.Position < 0)
                return;

            if (bdsHDLD.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsObject.Current).Row;

            //Copy hang hien tai            
            if (bdsHDLD.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsTTNV.Current).Row, ref drCurrent);
            else
                drCurrent = dtTTNV.NewRow();

            drCurrent["Ma_Dt_CbNv"] = (string)drEmployee["Ma_Dt"];

            frmHDLD_Edit frmEdit = new frmHDLD_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsTTNV.Position >= 0)
                        dtTTNV.ImportRow(drCurrent);
                    else
                        dtTTNV.Rows.Add(drCurrent);

                    bdsTTNV.Position = bdsHDLD.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsTTNV.Current).Row);
                }
                FillData("");
                dtTTNV.AcceptChanges();
            }
            else
                dtTTNV.RejectChanges();
        }
        void EditNhLopDT(enuEdit enuNew_Edit)
        {
            if (bdsObject.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //DataRow drObject = ((DataRowView)bdsObject.Current).Row;

            //Copy hang hien tai            
            if (bdsObject.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsObject.Current).Row, ref drCurrent);
            else
                drCurrent = dtObject.NewRow();

            frmNhomLopDT_Edit frmEdit = new frmNhomLopDT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsObject.Position >= 0)
                        dtObject.ImportRow(drCurrent);
                    else
                        dtObject.Rows.Add(drCurrent);

                    bdsObject.Position = bdsObject.Find("Ma_Nh_LopDT", drCurrent["Ma_Nh_LopDT"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsObject.Current).Row);
                }
                FillData("");
                dtObject.AcceptChanges();
            }
            else
                dtObject.RejectChanges();
        }
        void DeleteNhLopDT()
        {
            if (bdsObject.Position < 0)
                return;

            //if (!Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access))
            //{
            //    Common.MsgOk("Bạn không có quyền xóa dữ liệu bộ phận chi tiết");
            //    return;
            //}
            DataRow drCurrent = ((DataRowView)bdsObject.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R81DMNHLOPDT", drCurrent))
            {
                bdsObject.RemoveAt(bdsObject.Position);
                dtObject.AcceptChanges();
            }
        }
        void DeleteLopDT()
        {
            if (bdsLopDT.Position < 0)
                return;

            //if (!Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access))
            //{
            //    Common.MsgOk("Bạn không có quyền xóa dữ liệu bộ phận chi tiết");
            //    return;
            //}
            DataRow drCurrent = ((DataRowView)bdsLopDT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R81DMLOPDT", drCurrent))
            {
                bdsLopDT.RemoveAt(bdsLopDT.Position);
                dtLopDT.AcceptChanges();
            }
        }
        void EditLopDT(enuEdit enuNew_Edit)
        {
            if (bdsObject.Position < 0)
                return;
            
            if (bdsLopDT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //DataRow drLopDT = ((DataRowView)bdsLopDT.Current).Row;
            DataRow drNhLopDT = ((DataRowView)bdsObject.Current).Row;
            //Copy hang hien tai            
            if (bdsLopDT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsLopDT.Current).Row, ref drCurrent);
            else
                drCurrent = dtLopDT.NewRow();

            drCurrent["Ma_Nh_LopDT"] = drNhLopDT["Ma_Nh_LopDT"];
            frmLopDT_Edit frmEdit = new frmLopDT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsLopDT.Position >= 0)
                        dtLopDT.ImportRow(drCurrent);
                    else
                        dtLopDT.Rows.Add(drCurrent);

                    bdsLopDT.Position = bdsQLDT.Find("Ma_LopDT", drCurrent["Ma_LopDT"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsLopDT.Current).Row);
                }
                FillData("");
                dtLopDT.AcceptChanges();
            }
            else
                dtLopDT.RejectChanges();
        }
        void EditQLDT(enuEdit enuNew_Edit)
        {
            if (bdsObject.Position < 0)
                return;

            if (bdsQLDT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drLopDT = ((DataRowView)bdsLopDT.Current).Row;

            //Copy hang hien tai            
            if (bdsQLDT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQLDT.Current).Row, ref drCurrent);
            else
                drCurrent = dtQLDT.NewRow();

            drCurrent["Ma_LopDT"] = (string)drLopDT["Ma_LopDT"];

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
        void EditQLKT(enuEdit enuNew_Edit)
        {
            if (bdsObject.Position < 0)
                return;

            if (bdsQLKT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsObject.Current).Row;

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
            if (bdsObject.Position < 0)
                return;

            if (bdsQLKL.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEmployee = ((DataRowView)bdsObject.Current).Row;

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
                if(strFile_Path!= string.Empty)
                    File.Delete(strFile_Path);

                bdsQLDT.RemoveAt(bdsQLDT.Position);
                dtQLDT.AcceptChanges();
            }
        }
        void btNewList_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsLopDT.Current).Row;
            frmAddCBNV_QLDT frm = new frmAddCBNV_QLDT();
            frm.Load(drCurrent);

            if (frm.isAccept)
                FillData("");
        }
        void btDetailNew_Click(object sender, EventArgs e)
        {
            //if (this.strLoai == "HDLD")
            //    EditHDLD(enuEdit.New);
            //else if (this.strLoai == "QLDT")
                EditQLDT(enuEdit.New);
            //else if (this.strLoai == "QLKT")
            //    EditQLKT(enuEdit.New);
            //else if (this.strLoai == "QLKL")
            //    EditQLKL(enuEdit.New);
        }
        void btDetailEdit_Click(object sender, EventArgs e)
        {
            //if (this.strLoai == "HDLD")
            //    EditHDLD(enuEdit.Edit);
            //else if (this.strLoai == "QLDT")
                EditQLDT(enuEdit.Edit);
            //else if (this.strLoai == "QLKT")
            //    EditQLKT(enuEdit.Edit);
            //else if (this.strLoai == "QLKL")
            //    EditQLKL(enuEdit.Edit);
        }
        void btDetailDelete_Click(object sender, EventArgs e)
        {
            DeleteQLDT();
        }
		#endregion

		#region EnterProcess

		

		#endregion

		#region Su kien

		void bdsObject_PositionChanged(object sender, EventArgs e)
		{
            if (bdsObject.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsObject.Current).Row;
            bdsLopDT.Filter = "Ma_Nh_LopDT = '" + drCurrent["Ma_Nh_LopDT"] + "'";
            bdsQLDT.Filter = "Ma_Nh_LopDT = '" + drCurrent["Ma_Nh_LopDT"] + "'";		
		}

        void bdsLopDT_PositionChanged(object sender, EventArgs e)
        {
            if (bdsLopDT.Position < 0)
                    return;
            
            DataRow drLopDT = ((DataRowView)bdsLopDT.Current).Row;
            bdsQLDT.Filter = "Ma_LopDT = '" + drLopDT["Ma_LopDT"] + "'";
 
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

                if (objFile != null && objFile != DBNull.Value)
                {
                    FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);

                    fileStream.Close();
                    System.Diagnostics.Process.Start(strPath);
                }
            }
        }
        void dgvLopDT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    {
                        this.EditLopDT(enuEdit.New);
                    }
                    break;
                case Keys.F3:
                    {
                        this.EditLopDT(enuEdit.Edit);
                    }
                    break;
                case Keys.F8:
                    {
                        this.DeleteLopDT();
                    }
                    break;
            }
        }

        void dgvObject_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    {
                        this.EditNhLopDT(enuEdit.New);
                    }
                    break;
                case Keys.F3:
                    {
                        this.EditNhLopDT(enuEdit.Edit);
                    }
                    break;
                case Keys.F8:
                    {
                        this.DeleteNhLopDT();
                    }
                    break;
            }
        }

        void dgvQLDT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    {
                        this.EditQLDT(enuEdit.New);
                    }
                    break;
                case Keys.F3:
                    {
                        this.EditQLDT(enuEdit.Edit);
                    }
                    break;
                case Keys.F8:
                    {
                        this.DeleteQLDT();
                    }
                    break;
            }
        }
		#endregion
	}
}
