using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;
using RosySystem;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using RosySystem.Control;
using RosyModule;
using System.Data.SqlClient;
using RosySystem.Customize;
using RosySystem.Public;

namespace RosyModule.Manufactory
{
    public partial class frmLenhSanXuat : RosySystem.Customize.frmView
    {
        #region Variable

        //Luu y toi bManual
        object objActive = null;

        DataSet dsVoucher = new DataSet();
        DataTable dtEditPh;

        DataTable dtEditCt_Can;
        DataTable dtEditCt_Luyen;

        DataRow drEditPh;
        DataRow drEditCt_Can;
        DataRow drEditCt_Luyen;


        BindingSource bdsEditPh = new BindingSource();
        BindingSource bdsEditCt_Can = new BindingSource();
        BindingSource bdsEditCt_Luyen = new BindingSource();

        DataRow drCurrent;
        public enuEdit enuNew_Edit_Voucher = enuEdit.New;
        string strStt = string.Empty;
        string strEnuNew_Edit;
        string strReport_File = string.Empty;
        #endregion

        public frmLenhSanXuat()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(frmLenhSanXuat_KeyDown);
            dgvCan.Enter += new EventHandler(dgvCan_Enter);
            dgvLuyen.Enter += new EventHandler(dgvLuyen_Enter);

            numNam.Validating += new CancelEventHandler(numNam_Validating);
            numThang.Validating += new CancelEventHandler(numThang_Validating);
            numLan_Tt.Validating += new CancelEventHandler(numLan_Tt_Validating);

            btNew.Click += new EventHandler(btNew_Click);
            btNew_Thang.Click += new EventHandler(btNew_Thang_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
        
            btExit.Click += new EventHandler(btExit_Click);
            btNang_Suat.Click += new EventHandler(btNang_Suat_Click);
            btDungSX.Click += new EventHandler(btDungSX_Click);
           
            this.btPrintLSX.Click += new EventHandler(btPrintLSX_Click);
        }

      
        
        void dgvLuyen_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvLuyen;
        }

        void dgvCan_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvCan;
        }

        new public void Load()
        {
            this.numNam.Value = Voucher.GetDate_Server().Year;
            this.numThang.Value = Voucher.GetDate_Server().Month;

            if (DataTool.SQLCheckExist("R80PH_LSX", new string[] { "Nam", "Thang" }, new object[] { numNam.Value, numThang.Value }))
            {
                numLan_Tt.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT MAX(Lan_Tt) FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + ""));
                strStt = SQLExec.ExecuteReturnValue("SELECT Stt FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + " AND Lan_Tt = " + numLan_Tt.Value + "").ToString();
            }

            this.Build();
            this.FillData(strStt);
            this.Init_Ct();
            LoadDicName();

            this.Show();
        }

        private void LoadDicName()
        {

        }
        private void Build()
        {
            dgvCan.bSortMode = false;
            dgvCan.strZone = "LENHSXCAN";
            dgvCan.BuildGridView();

            dgvLuyen.bSortMode = false;
            dgvLuyen.strZone = "LENHSXLUYEN";
            dgvLuyen.BuildGridView();

            this.DataGridView_Language();

            foreach (DataGridViewColumn dgvc in dgvCan.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvLuyen.Columns)
                dgvc.ReadOnly = true;




        }

        private void DataGridView_Language()
        {


        }

        private void Init_Ct()
        {



        }

        private void FillData(string strStt)
        {
            if (DataTool.SQLCheckExist("R80PH_LSX", new string[] { "Nam", "Thang" }, new object[] { numNam.Value, numThang.Value }))
            {
                
                DataRow drPh = DataTool.SQLGetDataRowByID("R80PH_LSX", "Stt", strStt);
                //dteNgay_Ct.Text = drPh["Ngay_Ct"].ToString();
                //txtLy_Do.Text = drPh["Ly_Do"].ToString();
                //txtDanh_Gia.Text = drPh["Danh_Gia"].ToString();

                Common.ScaterMemvar(this, ref drPh);
                strEnuNew_Edit = "E";
            }
            else
            {
                strStt = "";
                strEnuNew_Edit = "N";
            }

            Hashtable ht = new Hashtable();

            ht.Add("NAM", numNam.Value);
            ht.Add("THANG", numThang.Value);
            ht.Add("ENUNEW_EDIT", strEnuNew_Edit);
            ht.Add("STT", strStt);

            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetLenhSanXuatCt", ht, CommandType.StoredProcedure);

            dtEditPh = dsVoucher.Tables[2];
            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }
            else
            {
                //drEditPh = dtEditPh.Select("")
                //numLan_Tt.Value = dtEditPh
            }

            dtEditCt_Can = dsVoucher.Tables[0];
            bdsEditCt_Can.DataSource = dtEditCt_Can;
            dgvCan.DataSource = bdsEditCt_Can;

            dtEditCt_Luyen = dsVoucher.Tables[1];
            bdsEditCt_Luyen.DataSource = dtEditCt_Luyen;
            dgvLuyen.DataSource = bdsEditCt_Luyen;

            numTSLLuyen.Value = Common.SumDCValue(dtEditCt_Luyen,"So_Luong","");
            numTSLCan.Value = Common.SumDCValue(dtEditCt_Can, "So_Luong", "");
        }
        void numLan_Tt_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + " AND Lan_Tt = " + numLan_Tt.Value + "")) != 0)
                strStt = SQLExec.ExecuteReturnValue("SELECT Stt FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + " AND Lan_Tt = " + numLan_Tt.Value + "").ToString();
            FillData(strStt);
        }

      

        void btDungSX_Click(object sender, EventArgs e)
        {
            frmLichDungSX frm = new frmLichDungSX();
            frm.Load();
        }

        void numNam_Validating(object sender, CancelEventArgs e)
        {
            if(Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + " AND Lan_Tt = " + numLan_Tt.Value + "")) != 0)
                strStt = SQLExec.ExecuteReturnValue("SELECT Stt FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + " AND Lan_Tt = " + numLan_Tt.Value + "").ToString();

            FillData(strStt);
        }

        void numThang_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + " AND Lan_Tt = " + numLan_Tt.Value + "")) != 0)
                strStt = SQLExec.ExecuteReturnValue("SELECT Stt FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + " AND Lan_Tt = " + numLan_Tt.Value + "").ToString();
            else
            {
                Int16 iLan_Tt = Convert.ToInt16(SQLExec.ExecuteReturnValue("SELECT MAX(Lan_Tt) FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + ""));
                strStt = SQLExec.ExecuteReturnValue("SELECT Stt FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + " AND Lan_Tt = " + iLan_Tt + "").ToString();
            }
            FillData(strStt);
        }


        void btNang_Suat_Click(object sender, EventArgs e)
        {
            frmDmNangSuat frm = new frmDmNangSuat();
            frm.Load();
        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void btPrintLSX_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        void btDelete_Click(object sender, EventArgs e)
        {
            if (Common.MsgYes_No("Bạn có chắc chắn xóa Lệnh sản xuất tháng " + numThang.Value + " năm " + numNam.Value + " lần thay đổi " + numLan_Tt.Value + " ??? ", "Y"))
            {
                if (strStt == "")
                    strStt = SQLExec.ExecuteReturnValue("SELECT Stt FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + " AND Lan_Tt = " + numLan_Tt.Value + "").ToString();

                SQLExec.Execute("DELETE FROM R13CT_LSX WHERE Stt = '" + strStt + "'");
                SQLExec.Execute("DELETE FROM R80PH_LSX WHERE Stt = '" + strStt + "'");
            }
        }
       
        void btEdit_Click(object sender, EventArgs e)
        {
            if (strStt == "")
                strStt = SQLExec.ExecuteReturnValue("SELECT Stt FROM R80PH_LSX WHERE Nam = " + numNam.Value + " AND Thang = " + numThang.Value + " AND Lan_Tt = " + numLan_Tt.Value + "").ToString();

            frmLenhSanXuat_Edit frm = new frmLenhSanXuat_Edit();
            frm.Load(enuEdit.Edit, numNam.Value, numThang.Value, numLan_Tt.Value, strStt, false);

            FillData(strStt);
        }

        void btNew_Thang_Click(object sender, EventArgs e)
        {
            this.strStt = "";
            frmLenhSanXuat_Edit frm = new frmLenhSanXuat_Edit();
            frm.Load(enuEdit.New, numNam.Value, numThang.Value, numLan_Tt.Value, strStt, true);
            FillData(frm.strStt);
        }

        void btNew_Click(object sender, EventArgs e)
        {

            frmLenhSanXuat_Edit frm = new frmLenhSanXuat_Edit();
            frm.Load(enuEdit.Copy, numNam.Value, numThang.Value, numLan_Tt.Value, strStt, true);
            FillData(strStt);
        }
     
        private void Design()
        {
            frmIn_LSX frm1 = new frmIn_LSX();
            frm1.Load();
            if (frm1.rdbChiTiet.Checked == true)
                strReport_File = "rptLenhSanXuatCt";
            else
                strReport_File = "rptLenhSanXuatTh";

            RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
            frm.Load(strReport_File);
        }
        private void Print(bool bPreview)
        {
            if (bdsEditPh.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsEditPh.Current).Row;

            frmIn_LSX frm1 = new frmIn_LSX();
            frm1.Load();
            if (frm1.rdbChiTiet.Checked == true)
                strReport_File = "rptLenhSanXuatCt";
            else
                strReport_File = "rptLenhSanXuatTh";

            bool bInVisibleNextPrint = false;

            Voucher.Print_LenhSanXuat(drCurrent["Stt"].ToString(), bPreview, true, ref bInVisibleNextPrint, strReport_File);

        }
        void frmLenhSanXuat_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            Design();
                            break;

                        //case Keys.Control:
                        //    Print(true);
                        //    break;

                        //case Keys.None:
                        //    Print(false);
                        //    break;
                    }
                    break;
            }
        }
    }
       
}
