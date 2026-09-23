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
	public partial class frmTuyenDung : RosySystem.Customize.frmView
	{
		#region Khai bao bien
        string strLoai = string.Empty;
        
        object objActive = null;

        DataSet dsObject = new DataSet();
        DataTable dtTuyenDung;
        DataTable dtDsUv;
        DataTable dtKetQuaTD;

        BindingSource bdsTuyenDung = new BindingSource();
        BindingSource bdsDsUv = new BindingSource();
        BindingSource bdsKetQuaTD = new BindingSource();

		private DataRow drCurrent;

        string strReport_File = string.Empty;
     

		#endregion

		#region Contructor

        public frmTuyenDung()
		{
		    InitializeComponent();

            dgvTuyenDung.Enter += new EventHandler(dgvTuyenDung_Enter);
            dgvDsUv.Enter+=new EventHandler(dgvDsUv_Enter);

            bdsTuyenDung.PositionChanged += new EventHandler(bdsTuyenDung_PositionChanged);


            this.btDetailNew.Click += new EventHandler(btDetailNew_Click);
            this.btDetailEdit.Click += new EventHandler(btDetailEdit_Click);
            this.btDetailDelete.Click += new EventHandler(btDetailDelete_Click);
            this.btPrint.Click += new EventHandler(btPrint_Click);

            dgvTuyenDung.KeyDown += new KeyEventHandler(dgvTuyenDung_KeyDown);
            dgvDsUv.KeyDown += new KeyEventHandler(dgvDsUv_KeyDown);
            dgvKetQua.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvKetQua_CellMouseClick);
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

            dgvTuyenDung.strZone = "TUYENDUNG";
            dgvTuyenDung.BuildGridView();

            dgvDsUv.strZone = "DSUV";
            dgvDsUv.BuildGridView();

            dgvKetQua.strZone = "KQTQUATD";
            dgvKetQua.BuildGridView();

            if (dgvTuyenDung.Columns.Contains("Noi_Dung"))
            {
                dgvTuyenDung.Columns["Noi_Dung"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvTuyenDung.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvTuyenDung.Columns.Contains("Ghi_Chu"))
            {
                dgvTuyenDung.Columns["Ghi_Chu"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvTuyenDung.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvTuyenDung.Columns.Contains("Vi_Tri_TD"))
            {
                dgvTuyenDung.Columns["Vi_Tri_TD"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvTuyenDung.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvTuyenDung.Columns.Contains("Mo_Ta_CV"))
            {
                dgvTuyenDung.Columns["Mo_Ta_CV"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvTuyenDung.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvTuyenDung.Columns.Contains("Nguoi_PV"))
            {
                dgvTuyenDung.Columns["Nguoi_PV"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvTuyenDung.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            foreach (DataGridViewColumn dc in dgvKetQua.Columns)
                dc.ReadOnly = true;

            dgvKetQua.Columns["Is_TD"].ReadOnly = false;
		}

		private void FillData(string strKey)
		{
          
            dsObject = SQLExec.ExecuteReturnDs("sp_GetTuyenDung",  CommandType.StoredProcedure);


            dtTuyenDung = dsObject.Tables[0];
            bdsTuyenDung.DataSource = dtTuyenDung;
            dgvTuyenDung.DataSource = bdsTuyenDung;


            dtDsUv = dsObject.Tables[1];
            bdsDsUv.DataSource = dtDsUv;
            dgvDsUv.DataSource = bdsDsUv;

            dtKetQuaTD = dsObject.Tables[2];
            bdsKetQuaTD.DataSource = dtKetQuaTD;
            dgvKetQua.DataSource = bdsKetQuaTD;    
		}

		private void BindingData()
		{
			
		}

		#endregion

		#region Update
       
       
        void DeleteUngVien()
        {
            if (bdsDsUv.Position < 0)
                return;

         
            DataRow drCurrent = ((DataRowView)bdsDsUv.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09DMUV", drCurrent))
            {
                bdsDsUv.RemoveAt(bdsDsUv.Position);
                dtDsUv.AcceptChanges();
            }
        }
        void DeleteTuyenDung()
        {
            if (bdsTuyenDung.Position < 0)
                return;


            DataRow drCurrent = ((DataRowView)bdsTuyenDung.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09TUYENDUNG", drCurrent))
            {
                bdsTuyenDung.RemoveAt(bdsTuyenDung.Position);
                dtTuyenDung.AcceptChanges();
            }
        }
        void EditUngVien(enuEdit enuNew_Edit, bool bTD)
        {
            if (bdsTuyenDung.Position < 0)
                return;
            
            if (bdsDsUv.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

          
            DataRow drNhLopDT = ((DataRowView)bdsTuyenDung.Current).Row;
            //Copy hang hien tai            
            if (bdsDsUv.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDsUv.Current).Row, ref drCurrent);
            else
                drCurrent = dtDsUv.NewRow();

            drCurrent["Ma_DotTD"] = drNhLopDT["Ma_DotTD"];
            
            if (enuNew_Edit != enuEdit.Edit)
                drCurrent["Is_TD"] = false;

            frmUngVien_Edit frmEdit = new frmUngVien_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, bTD);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDsUv.Position >= 0)
                        dtDsUv.ImportRow(drCurrent);
                    else
                        dtDsUv.Rows.Add(drCurrent);

                    bdsDsUv.Position = bdsDsUv.Find("Ma_Uv", drCurrent["Ma_Uv"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsDsUv.Current).Row);
                }
                //FillData("");
                dtDsUv.AcceptChanges();
            }
            else
                dtDsUv.RejectChanges();
        }
        private void Design()
        {
            frmIn_TuyenDung frm = new frmIn_TuyenDung();
            frm.Load();
          
            if (frm.isAccept)
            {
                strReport_File = "rptQLTD";
                if (frm.rdbDSUV.Checked == true)
                    strReport_File = strReport_File + "_DSUV";
                else if (frm.rdbDSNV.Checked == true)
                    strReport_File = strReport_File + "_DSNV";
                else
                    strReport_File = strReport_File + "_NCTD";
            }

            RosyReport.frmReportDesign frm1 = new RosyReport.frmReportDesign();
            frm1.Load(strReport_File);
        }
        private void Print()
        {
            frmIn_TuyenDung frm = new frmIn_TuyenDung();
            frm.Load();
            
            if (frm.isAccept)
            {
                strReport_File = "rptQLTD";
                if (frm.rdbDSUV.Checked == true)
                    strReport_File = strReport_File + "_DSUV";
                else if (frm.rdbDSNV.Checked == true)
                    strReport_File = strReport_File + "_DSNV";
                else
                    strReport_File = strReport_File + "_NCTD";
            }
            
            drCurrent = ((DataRowView)bdsTuyenDung.Current).Row;
           
            Hashtable ht = new Hashtable();
            ht.Add("MA_DOTTD", drCurrent["Ma_DotTD"]);
            ht.Add("IN_CT", strReport_File.ToString().Substring(8,4));
           
            DataTable dtPrint= new DataTable();
            dtPrint = SQLExec.ExecuteReturnDt("Sp_PrintTuyenDung", ht, CommandType.StoredProcedure);
            
            if (dtPrint.Rows.Count == 0)
                return;
                   
            if (!dtPrint.Columns.Contains("REPORT_FILE"))
                dtPrint.Columns.Add("REPORT_FILE", typeof(string));

            if (!dtPrint.Columns.Contains("NGAY_CT"))
                dtPrint.Columns.Add("NGAY_CT", typeof(DateTime));

            if (!dtPrint.Columns.Contains("DOC_TIEN"))
                dtPrint.Columns.Add("DOC_TIEN", typeof(string));

            dtPrint.Rows[0]["REPORT_FILE"] = strReport_File;
            dtPrint.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;


            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            frmPrint.Load(dtPrint.Rows[0], dtPrint, true);

        }

        void EditTuyenDung(enuEdit enuNew_Edit)
        {

            if (bdsTuyenDung.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsTuyenDung.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsTuyenDung.Current).Row, ref drCurrent);
            else
                drCurrent = dtTuyenDung.NewRow();


            frmTuyenDung_Edit frmEdit = new frmTuyenDung_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsTuyenDung.Position >= 0)
                        dtTuyenDung.ImportRow(drCurrent);
                    else
                        dtTuyenDung.Rows.Add(drCurrent);

                    bdsTuyenDung.Position = bdsTuyenDung.Find("Ma_DotTD", drCurrent["Ma_DotTD"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsTuyenDung.Current).Row);
                }
                //FillData("");
                dtTuyenDung.AcceptChanges();
            }
            else
                dtTuyenDung.RejectChanges();
        }
        void btPrint_Click(object sender, EventArgs e)
        {
            Print();
        }
        void btDetailNew_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvTuyenDung)
                EditTuyenDung(enuEdit.New);
            else if (this.objActive == dgvDsUv)
                EditUngVien(enuEdit.New, false);

            
        }
        void btDetailEdit_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvTuyenDung)
                EditTuyenDung(enuEdit.Edit);
            else if (this.objActive == dgvDsUv)
                EditUngVien(enuEdit.Edit, false);
           
        }

        void btDetailDelete_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvTuyenDung)
                DeleteTuyenDung();
            else
               DeleteUngVien();
        }

        void dgvTuyenDung_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvTuyenDung;
        }

        void dgvDsUv_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvDsUv;
        }

        void bdsTuyenDung_PositionChanged(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsTuyenDung.Current).Row;
            bdsDsUv.Filter = "Ma_DotTD = '" + drCurrent["Ma_DotTD"] + "'";
            bdsKetQuaTD.Filter = "Ma_DotTD = '" + drCurrent["Ma_DotTD"] + "'";
        }
		#endregion

		#region EnterProcess

		

		#endregion

		#region Su kien
     
        void dgvKetQua_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsKetQuaTD.Current).Row;
            string strColumn_Name = dgvKetQua.Columns[e.ColumnIndex].DataPropertyName;

            if (strColumn_Name == "IS_TD")
            {
                EditUngVien(enuEdit.Edit, true);
               
            }
        }
        void dgvTuyenDung_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    {
                        this.EditTuyenDung(enuEdit.New);
                    }
                    break;
                case Keys.F3:
                    {
                        this.EditTuyenDung(enuEdit.Edit);
                    }
                    break;
                case Keys.F8:
                    {
                        this.DeleteTuyenDung();
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
        void dgvDsUv_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    {
                        this.EditUngVien(enuEdit.New, false);
                    }
                    break;
                case Keys.F3:
                    {
                        this.EditUngVien(enuEdit.Edit, false);
                    }
                    break;
                case Keys.F8:
                    {
                        this.DeleteUngVien();
                    }
                    break;
            }
        }
		#endregion
	}
}
