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

namespace RosyModule.Receivable 
{
	public partial class frmDmCkCt : RosySystem.Customize.frmView
	{
		#region Khai bao bien
        string strLoai = string.Empty;
        
        object objActive = null;

        DataSet dsObject = new DataSet();
        DataTable dtQDCK;
        DataTable dtQDCKCT;
        DataTable dtKetQua;
       

        BindingSource bdsQDCK = new BindingSource();
        BindingSource bdsQDCKCT = new BindingSource();
        BindingSource bdsKetQua = new BindingSource();

        string strSo_Qd = string.Empty;

		private DataRow drCurrent;

        string strSo_Qd_In = string.Empty;
        string strReport_File = string.Empty;
        
		#endregion

		#region Contructor

        public frmDmCkCt()
		{
		    InitializeComponent();

            dgvQDCK.Enter += new EventHandler(dgvTuyenDung_Enter);
            dgvQDCKCT.Enter+=new EventHandler(dgvDsUv_Enter);
            dgvKetQua.Enter += new EventHandler(dgvKetQua_Enter);
            bdsQDCK.PositionChanged += new EventHandler(bdsQDCK_PositionChanged);


            this.btDetailNew.Click += new EventHandler(btDetailNew_Click);
            this.btDetailEdit.Click += new EventHandler(btDetailEdit_Click);
            this.btDetailDelete.Click += new EventHandler(btDetailDelete_Click);
            this.btKetQua.Click += new EventHandler(btKetQua_Click);
            this.btSave.Click += new EventHandler(btSave_Click);

            dgvQDCK.KeyDown += new KeyEventHandler(dgvTuyenDung_KeyDown);
            dgvQDCKCT.KeyDown += new KeyEventHandler(dgvQDCKCT_KeyDown);
            
            
		}

    
        

       

     

       

        

        

		public override void Load()
		{
			this.Build();
			this.FillData(string.Empty);
			this.BindingData();
			this.BindingLanguage();

			this.Show();

         
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

            dgvQDCK.strZone = "QDCK";
            dgvQDCK.BuildGridView();

            dgvQDCKCT.strZone = "QDCKCT";
            dgvQDCKCT.BuildGridView();

            dgvKetQua.strZone = "QDCKCTKQ";
            dgvKetQua.BuildGridView();

            DataGridView_Language();

            foreach (DataGridViewColumn dc in dgvQDCK.Columns)
                dc.ReadOnly = true;
            foreach (DataGridViewColumn dc in dgvQDCKCT.Columns)
                dc.ReadOnly = true;
            foreach (DataGridViewColumn dc in dgvKetQua.Columns)
                dc.ReadOnly = true;
            
            
		}
        private void DataGridView_Language()
        {
            if (dgvKetQua.Columns.Contains("So_Luong_TH"))
                dgvKetQua.Columns["So_Luong_TH"].HeaderText = "SL thực hiện";

            if (dgvKetQua.Columns.Contains("So_Luong_CK"))
                dgvKetQua.Columns["So_Luong_CK"].HeaderText = "SL hưởng CK";

            if (dgvKetQua.Columns.Contains("So_Luong_KCK"))
                dgvKetQua.Columns["So_Luong_KCK"].HeaderText = "SL không hưởng CK";

            if (dgvKetQua.Columns.Contains("Tien_CK1"))
                dgvKetQua.Columns["Tien_CK1"].HeaderText = "Tiền hưởng CK lần 1";

            if (dgvKetQua.Columns.Contains("Tien_CK2"))
                dgvKetQua.Columns["Tien_CK2"].HeaderText = "Tiền hưởng CK lần 2";
        }
		private void FillData(string strKey)
		{
          
            dsObject = SQLExec.ExecuteReturnDs("sp_GetQDCK",  CommandType.StoredProcedure);


            dtQDCK = dsObject.Tables[0];
            bdsQDCK.DataSource = dtQDCK;
            dgvQDCK.DataSource = bdsQDCK;


            dtQDCKCT = dsObject.Tables[1];
            bdsQDCKCT.DataSource = dtQDCKCT;
            dgvQDCKCT.DataSource = bdsQDCKCT;

    
		}

		private void BindingData()
		{
			
		}

		#endregion

		#region Update


        void DeleteQDCKCT()
        {
            if (bdsQDCKCT.Position < 0)
                return;

         
            DataRow drCurrent = ((DataRowView)bdsQDCKCT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R81DMQDCT", drCurrent))
            {
                bdsQDCKCT.RemoveAt(bdsQDCKCT.Position);
                dtQDCKCT.AcceptChanges();
            }
        }
        void DeleteQDCK()
        {
            if (bdsQDCK.Position < 0)
                return;


            DataRow drCurrent = ((DataRowView)bdsQDCK.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R81DMTYPE", drCurrent))
            {
                bdsQDCK.RemoveAt(bdsQDCK.Position);
                dtQDCK.AcceptChanges();
            }
        }
     
        private void Design()
        {
            frmDmCkCt_KQ frm = new frmDmCkCt_KQ();
            frm.Load(string.Empty);

            if (frm.isAccept)
            {
                strReport_File = "rptQDCK";
                if (frm.rdbQuy.Checked == true)
                    strReport_File = strReport_File + "_Quy";
                else if (frm.rdbThang.Checked == true)
                    strReport_File = strReport_File + "_Thang";
              
            }

            RosyReport.frmReportDesign frm1 = new RosyReport.frmReportDesign();
            frm1.Load(strReport_File);
        }
        private void Print()
        {

            //frmIn_TuyenDung frm = new frmIn_TuyenDung();
            //frm.Load();
            
            //if (frm.isAccept)
            //{
            //    strReport_File = "rptQLTD";
            //    if (frm.rdbDSUV.Checked == true)
            //        strReport_File = strReport_File + "_DSUV";
            //    else if (frm.rdbDSNV.Checked == true)
            //        strReport_File = strReport_File + "_DSNV";
            //    else
            //        strReport_File = strReport_File + "_NCTD";
            //}
            
            //drCurrent = ((DataRowView)bdsQDCK.Current).Row;
           
            //Hashtable ht = new Hashtable();
            //ht.Add("MA_DOTTD", drCurrent["Ma_DotTD"]);
            //ht.Add("IN_CT", strReport_File.ToString().Substring(8,4));
           
            //DataTable dtPrint= new DataTable();
            //dtPrint = SQLExec.ExecuteReturnDt("sp_GetKQQDCKCT", ht, CommandType.StoredProcedure);
            
            //if (dtPrint.Rows.Count == 0)
            //    return;
                   
            //if (!dtPrint.Columns.Contains("REPORT_FILE"))
            //    dtPrint.Columns.Add("REPORT_FILE", typeof(string));

            //if (!dtPrint.Columns.Contains("NGAY_CT"))
            //    dtPrint.Columns.Add("NGAY_CT", typeof(DateTime));

            //if (!dtPrint.Columns.Contains("DOC_TIEN"))
            //    dtPrint.Columns.Add("DOC_TIEN", typeof(string));

            //dtPrint.Rows[0]["REPORT_FILE"] = strReport_File;
            //dtPrint.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;


            //RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            //frmPrint.Load(dtPrint.Rows[0], dtPrint, true);

        }

        void EditQDCK(enuEdit enuNew_Edit)
        {

            if (bdsQDCK.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsQDCK.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQDCK.Current).Row, ref drCurrent);
            else
                drCurrent = dtQDCK.NewRow();


            frmDmType_Edit frmEdit = new frmDmType_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQDCK.Position >= 0)
                        dtQDCK.ImportRow(drCurrent);
                    else
                        dtQDCK.Rows.Add(drCurrent);

                    bdsQDCK.Position = bdsQDCK.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQDCK.Current).Row);
                }
                //FillData("");
                dtQDCK.AcceptChanges();
            }
            else
                dtQDCK.RejectChanges();
        }
        void EditQDCKCT(enuEdit enuNew_Edit)
        {

            if (bdsQDCK.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drQDCK = ((DataRowView)bdsQDCK.Current).Row;

            //Copy hang hien tai            
            if (bdsQDCKCT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQDCKCT.Current).Row, ref drCurrent);
            else
                drCurrent = dtQDCKCT.NewRow();

            if(enuNew_Edit== enuEdit.New)
                drCurrent["So_Qd"] = drQDCK["TyPe_ID"];

            frmDmCkCt_Edit frmEdit = new frmDmCkCt_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQDCKCT.Position >= 0)
                        dtQDCKCT.ImportRow(drCurrent);
                    else
                        dtQDCKCT.Rows.Add(drCurrent);

                    bdsQDCKCT.Position = bdsQDCKCT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQDCKCT.Current).Row);
                }
                //FillData("");
                dtQDCKCT.AcceptChanges();
            }
            else
                dtQDCKCT.RejectChanges();
        }
        void btPrint_Click(object sender, EventArgs e)
        {
            Print();
        }
        void btDetailNew_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvQDCK)
                EditQDCK(enuEdit.New);
            else if (this.objActive == dgvQDCKCT)
                EditQDCKCT(enuEdit.New);
          
            
        }
        void btDetailEdit_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvQDCK)
                EditQDCK(enuEdit.Edit);
            else if (this.objActive == dgvQDCKCT)
                EditQDCKCT(enuEdit.Edit);
 
        }

        void btDetailDelete_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvQDCK)
                DeleteQDCK();
            else if (this.objActive == dgvQDCKCT)
                DeleteQDCKCT();
        }
        void btKetQua_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsQDCKCT.Current).Row;

            frmDmCkCt_KQ frm = new frmDmCkCt_KQ();
            frm.Load(drCurrent["So_Qd"].ToString());
            

            if (frm.isAccept)
            {
                Hashtable ht = new Hashtable();
                ht.Add("NGAY_CT1", frm.dtNgay_Ct1);
                ht.Add("NGAY_CT2", frm.dtNgay_Ct2);
                ht.Add("NGAY_CT", frm.dtNgay_Ct);
                ht.Add("SO_QD", frm.strSo_Qd);

                dtKetQua = SQLExec.ExecuteReturnDt("sp_GetKQQDCKCT", ht, CommandType.StoredProcedure);

                if (dtKetQua.Rows.Count == 0)
                    Common.MsgOk("Quyết định " + drCurrent["So_Qd"] + " không có kết quả!!!");
                else
                {
                    bdsKetQua.DataSource = dtKetQua;
                    dgvKetQua.DataSource = bdsKetQua;
                }
            }
        }
        void btSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void dgvTuyenDung_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvQDCK;
        }

        void dgvDsUv_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvQDCKCT;
        }
        void dgvKetQua_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvKetQua;
        }
        void bdsQDCK_PositionChanged(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsQDCK.Current).Row;
            bdsQDCKCT.Filter = "So_Qd = '" + drCurrent["Type_ID"] + "'";
           
        }
		#endregion

		#region EnterProcess

		

		#endregion

		#region Su kien

        void dgvQDCKCT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    {
                        this.EditQDCKCT(enuEdit.New);
                    }
                    break;
                case Keys.F3:
                    {
                        this.EditQDCKCT(enuEdit.Edit);
                    }
                    break;
                case Keys.F8:
                    {
                        this.DeleteQDCKCT();
                    }
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
        void dgvTuyenDung_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    {
                        this.EditQDCK(enuEdit.New);
                    }
                    break;
                case Keys.F3:
                    {
                        this.EditQDCK(enuEdit.Edit);
                    }
                    break;
                case Keys.F8:
                    {
                        this.DeleteQDCK();
                    }
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
        
		#endregion
	}
}
