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
using RosyList;
using RosyModule;
using RosySystem;
using RosySystem.Library;
using RosySystem.Element;
using System.Collections;
using RosySystem.Public;
using RosySystem.Control;

namespace RosyModule.Salary
{
	public partial class frmChamCong : RosySystem.Customize.frmView
	{
        object objActive = null;

        DataSet dsChamCong;
        DataTable dtNVChamCong;
        DataTable dtNVKChamCong;
        DataTable dtBsChamCong;
        DataTable dtDCChamCong;
        DataTable dtKQChamCong;
      
        DataTable dtTHChamCong;
        DataTable dtHinhThucCC;
        DataTable dtCongNhaAn;
        DataTable dtCongTangCa;
        DataTable dtCongTangCaCt;
        

        BindingSource bdsNVChamCong = new BindingSource();
        BindingSource bdsNVKChamCong = new BindingSource();
        BindingSource bdsBsChamCong = new BindingSource();
        BindingSource bdsDCChamCong = new BindingSource();
        BindingSource bdsKQChamCong = new BindingSource();

        BindingSource bdsHinhThucCC = new BindingSource();
        BindingSource bdsCongNhaAn = new BindingSource();
        BindingSource bdsCongTangCa = new BindingSource();
        BindingSource bdsCongTangCaCt = new BindingSource();

		DataRow drCurrent;


        DataTable dtDmBp;
        DataTable dtDmBpCt;
        DataSet dsBp;

        public frmChamCong()
		{
			InitializeComponent();

            this.dgvHinhThucCC.Enter += new EventHandler(dgvHinhThucCC_Enter);
            this.dgvNVChamCong.Enter += new EventHandler(dgvNVChamCong_Enter);
            this.dgvNVKChamCong.Enter += new EventHandler(dgvNVKChamCong_Enter);
            this.dgvKQChamCong.Enter += new EventHandler(dgvKQChamCong_Enter);
            this.dgvKQChamCongTH.Enter += new EventHandler(dgvKQChamCongTH_Enter);
            this.dgvCongNhaAn.Enter += new EventHandler(dgvCongNhaAn_Enter);
            this.dgvCongTangCa.Enter += new EventHandler(dgvCongTangCa_Enter);
            this.dgvBsChamCong.Enter += new EventHandler(dgvBsChamCong_Enter);
            this.dgvCongTangCaCt.Enter += new EventHandler(dgvCongTangCaCt_Enter);

            dgvHinhThucCC.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvHinhThucCC_CellMouseClick);
            dgvCongTangCa.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvCongTangCa_CellMouseClick);
            dgvDCChamCong.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvDCChamCong_CellMouseClick);
            dgvKQChamCong.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvKQChamCong_CellMouseDoubleClick);
            this.dgvKQChamCong.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvKQChamCong_CellFormatting);
            this.btNew.Click += new EventHandler(btNew_Click);
            this.btEdit.Click += new EventHandler(btEdit_Click);
            this.btDelete.Click += new EventHandler(btDelete_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
			this.btRefresh.Click += new EventHandler(btFilter_Click);
            this.btPrint.Click += new EventHandler(btPrint_Click);
            this.btSXChamCong.Click += new EventHandler(btSXChamCong_Click);
            this.btPhanQuyenCC.Click += new EventHandler(btPhanQuyenCC_Click);
            dtpNgay_Ct2.LostFocus += new EventHandler(dtpNgay_Ct2_LostFocus);
            this.btDKSuatAn.Click += new EventHandler(btDKSuatAn_Click);
            btHsABC.Click += new EventHandler(btHsABC_Click);

            this.btDuyetTangCa.Click += new EventHandler(btDuyetTangCa_Click);
            btDuyetChamCong.Click += new EventHandler(btDuyetChamCong_Click);

            cboMa_Bp.TextChanged += new EventHandler(cboMa_Bp_TextChanged);
            cboMa_Bp_Ct.TextChanged += new EventHandler(cboMa_Bp_Ct_TextChanged);
            //txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            //txtMa_Bp_Ct.Validating += new CancelEventHandler(txtMa_Bp_Ct_Validating);
		}

        void dtpNgay_Ct2_LostFocus(object sender, EventArgs e)
        {
            if (dtpNgay_Ct2.Value < dtpNgay_Ct1.Value)
                dtpNgay_Ct2.Value = dtpNgay_Ct1.Value;
        }

       

		new public void Load()
		{
            Build();
            BuildDataGridView();

            //đưa giá trị vào combo
            Voucher.LoadComboBp((rsMultiComboBox)cboMa_Bp, (rsMultiComboBox)cboMa_Bp_Ct);

            //dtpNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
            //dtpNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            dtpNgay_Ct1.CustomFormat = "dd/MM/yyyy";
            dtpNgay_Ct2.CustomFormat = "dd/MM/yyyy";

            dtpNgay_Ct1.Value = Element.sysNgay_Ct2;
            dtpNgay_Ct2.Value = Element.sysNgay_Ct2;

            // Gán giá trị cho ma bp
            string strMa_Bp = Voucher.GetBpOfUser();
            if((!Common.Inlist(strMa_Bp, "NQL,PTCHC") && !Element.sysIs_Admin))
            {
                cboMa_Bp.Text = strMa_Bp;
                cboMa_Bp.Enabled = false;
            }
            else if (Element.sysIs_Admin)
                cboMa_Bp.Text = "PCNTT";
            else if (Common.Inlist(strMa_Bp, "NQL,PTCHC"))
            {
                cboMa_Bp.Text = "PTCHC";
                cboMa_Bp.Enabled = true;
            }
            //
            btNew.Enabled = Common.CheckPermission("CHAMCONG", enuPermission_Type.Allow_New);
            btEdit.Enabled = Common.CheckPermission("CHAMCONG", enuPermission_Type.Allow_Edit);
            btDelete.Enabled = Common.CheckPermission("CHAMCONG", enuPermission_Type.Allow_Delete);

		
            //FillData();
			this.BindingLanguage();

			this.Show();
		}

		private void Build()
		{
            dgvNVChamCong.strZone = "NVCHAMCONG";
            dgvNVChamCong.BuildGridView();

            dgvNVKChamCong.strZone = "NVKCHAMCONG";
            dgvNVKChamCong.BuildGridView();

            dgvBsChamCong.strZone = "BSCHAMCONG";
            dgvBsChamCong.BuildGridView();

            dgvKQChamCong.strZone = "KQCHAMCONG";
            dgvKQChamCong.BuildGridView();
            dgvKQChamCong.bFilter = false;


            dgvKQChamCongTH.strZone = "KQCHAMCONG";
            dgvKQChamCongTH.BuildGridView();

            dgvHinhThucCC.strZone = "HINHTHUCCC";
            dgvHinhThucCC.BuildGridView();

            dgvCongNhaAn.strZone = "CONGNHAAN";
            dgvCongNhaAn.BuildGridView();

            dgvCongTangCa.strZone = "CONGTANGCA";
            dgvCongTangCa.BuildGridView();

            dgvCongTangCaCt.strZone = "CONGTANGCACT";
            dgvCongTangCaCt.BuildGridView();

            dgvDCChamCong.strZone = "DCCHAMCONG";
            dgvDCChamCong.BuildGridView();

            if (Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access) || Element.sysUser_Id == "LANHDP")
            {
                btDuyetTangCa.Enabled = true;
                btPhanQuyenCC.Enabled = false;
                btDuyetChamCong.Enabled = true;
            }
            else
            {
                btDuyetTangCa.Enabled = false;
                btPhanQuyenCC.Enabled = false;
                btDuyetChamCong.Enabled = false;
            }
            dgvKQChamCong.ReadOnly = true;

            tbChitiet.TabPages.Remove(tabPage6);

            //Remover DataGridView Filter
            string strColumnList = "Ngay_01,Ngay_02,Ngay_03,Ngay_04,Ngay_05,Ngay_06,Ngay_07,Ngay_08,Ngay_09,Ngay_10,Ngay_11,Ngay_12,Ngay_13,Ngay_14,Ngay_15,Ngay_16,Ngay_01,Ngay_16,Ngay_17,Ngay_18,Ngay_19,Ngay_20,Ngay_01,Ngay_21,Ngay_22,Ngay_01,Ngay_23,Ngay_01,Ngay_24,Ngay_01,Ngay_25,Ngay_01,Ngay_26,Ngay_27,Ngay_28,Ngay_29,Ngay_30,Ngay_31,";
            foreach (string strColumn in strColumnList.Split(','))
            {
                if (dgvKQChamCong.Columns.Contains(strColumn))
                    ((dgvAutoFilterColumnHeaderCell)dgvKQChamCong.Columns[strColumn].HeaderCell).bFilteringEnabled = false;

            }
            dgvCongTangCaCt.ReadOnly = true;

		}
        private void BuildDataGridView()
        {
            this.dgvKQChamCong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKQChamCong.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

            if (this.dgvKQChamCong.Columns.Contains("Ten_Dt_CbNv"))
                this.dgvKQChamCong.Columns["Ten_Dt_CbNv"].Frozen = true;

        }
		private void FillData()
		{
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dtpNgay_Ct1.Value.ToShortDateString());
            ht.Add("NGAY_CT2", dtpNgay_Ct2.Value.ToShortDateString());
            ht.Add("MA_BP", cboMa_Bp.Text);
            ht.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
            ht.Add("USER_LOGIN", Element.sysUser_Id);

            dsChamCong = SQLExec.ExecuteReturnDs("sp_GetChamCong", ht, CommandType.StoredProcedure);

            dtNVChamCong = dsChamCong.Tables[0];
            bdsNVChamCong.DataSource = dtNVChamCong;
            dgvNVChamCong.DataSource = bdsNVChamCong;
            
            dtNVKChamCong = dsChamCong.Tables[1];
            bdsNVKChamCong.DataSource = dtNVKChamCong;
            dgvNVKChamCong.DataSource = bdsNVKChamCong;

            dtBsChamCong = dsChamCong.Tables[2];
            bdsBsChamCong.DataSource = dtBsChamCong;
            dgvBsChamCong.DataSource = bdsBsChamCong;

            dtKQChamCong = dsChamCong.Tables[3];
            bdsKQChamCong.DataSource = dtKQChamCong;
            dgvKQChamCong.DataSource = bdsKQChamCong;

            dtHinhThucCC = dsChamCong.Tables[4];
            bdsHinhThucCC.DataSource = dtHinhThucCC;
            dgvHinhThucCC.DataSource = bdsHinhThucCC;

            dtCongNhaAn = dsChamCong.Tables[5];
            bdsCongNhaAn.DataSource = dtCongNhaAn;
            dgvCongNhaAn.DataSource = bdsCongNhaAn;

            dtTHChamCong = dsChamCong.Tables[6];          

            lbtGio_Cham_Cong_Max.Text = dtTHChamCong.Rows[0]["Gio_Cong_Max"].ToString();
            numSo_CbNv_Co_Mat.Value = Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_CbNv_Co_Mat"]);
            numSo_CbNv_HC.Value = Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_CbNv_HC"]);
            numSo_CbNv_Ca.Value = Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_CbNv_Ca"]);
            numSo_CbNv_12TN.Value = Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_CbNv_12TN"]);
            numSo_CbNv_12TD.Value = Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_CbNv_12TD"]);
            numSo_CbNv_Tre.Value = Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_CbNv_Tre"]);
            numSl_An_Sang.Value = Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_Cong_Sang"]) + Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_Cong_Hsau"]);
            numSl_An_Trua.Value = Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_Cong_Trua"]);
            numSl_An_Chieu.Value = Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_Cong_Chieu"]);
            numSl_An_Khuya.Value = Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_Cong_Khuya"]);
            numSl_An_Hsau.Value = Convert.ToDouble(dtTHChamCong.Rows[0]["Sl_Cong_Hsau"]);

            dtCongTangCa = dsChamCong.Tables[7];
            bdsCongTangCa.DataSource = dtCongTangCa;
            dgvCongTangCa.DataSource = bdsCongTangCa;


            dtDCChamCong = dsChamCong.Tables[8];
            bdsDCChamCong.DataSource = dtDCChamCong;
            dgvDCChamCong.DataSource = bdsDCChamCong;
            
         


            //Công tăng ca
            dtCongTangCaCt = dsChamCong.Tables[10];
            bdsCongTangCaCt.DataSource = dtCongTangCaCt;
            dgvCongTangCaCt.DataSource = bdsCongTangCaCt;

            this.ExportControl = dgvNVKChamCong;

		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

        void Delete_NVKChamCong()
        {
            if (bdsBsChamCong.Position < 0)
                return;
            DataRow drCurrent = ((DataRowView)bdsBsChamCong.Current).Row;
            string strCreate_User = (string)drCurrent["Create_Log"];

            if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
            {
                Common.MsgCancel("Không được xóa dữ liệu do " + strCreate_User.Substring(14) + " lập !");
                return;
                   
            }
            //KIỂM TRA KHÓA DỮ LIỆU KHÔNG CHO XÓA
            bool bLock1 = Voucher.LockCongLuong("Lock_Cong", Convert.ToDateTime(drCurrent["Tu_Ngay"]).Year, Convert.ToDateTime(drCurrent["Den_Ngay"]).Month,
                   Library.StrToDate(drCurrent["Tu_Ngay"].ToString()), Library.StrToDate(drCurrent["Den_Ngay"].ToString()));
            if (bLock1)
            {
                Common.MsgOk("Bảng công đã khóa. Không sửa dữ liệu tại ngày: " + drCurrent["Tu_Ngay"].ToString());
                return;
            }
               

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R10TTCHAMCONG", drCurrent))
            {
                bdsBsChamCong.RemoveAt(bdsBsChamCong.Position);
                dtBsChamCong.AcceptChanges();
            }
        }
        void Delete_CongTangCa()
        {
            if (bdsCongTangCaCt.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsCongTangCaCt.Current).Row;
            
            if ((bool)drCurrent["Duyet_Tp"])
                return;
            
            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R10CONGTANGCA", drCurrent))
            {
                bdsCongTangCaCt.RemoveAt(bdsCongTangCaCt.Position);
                dtCongTangCaCt.AcceptChanges();
            }
        }
        void Delete_CongNhaAn()
        {
            if (bdsCongNhaAn.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsCongNhaAn.Current).Row;

            if ((DateTime)drCurrent["Ngay_Cham_Cong"] < Voucher.GetDate_Server())
                return;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R10DSCBNVTHEOCA", drCurrent))
            {
                bdsCongNhaAn.RemoveAt(bdsCongNhaAn.Position);
                dtCongNhaAn.AcceptChanges();
            }
        }
        void btDelete_Click(object sender, EventArgs e)
        {
            if (this.tbChitiet.SelectedTab == tpLyDoKCC)
                Delete_NVKChamCong();
            else if (this.tbChitiet.SelectedTab == tpCongTangCa)
                Delete_CongTangCa();
            else if (this.tbChitiet.SelectedTab == tpCongNhaAn)
                Delete_CongNhaAn();
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            if (this.tbChitiet.SelectedTab == tpLyDoKCC)
                EditNVKChamCong(enuEdit.Edit);
              else if (this.tbChitiet.SelectedTab == tpCongTangCa)
                EditCongTangCaCt(enuEdit.Edit);
            else if (this.tbChitiet.SelectedTab == tpCongNhaAn)
                EditCongNhaAn(enuEdit.Edit);
        }
		void btNew_Click(object sender, EventArgs e)
		{
            if (this.tbChitiet.SelectedTab == tpLyDoKCC)
                EditNVKChamCong(enuEdit.New);
            //else if (this.tbChitiet.SelectedTab == tabPage5)
            //    EditCongTangCa(enuEdit.New);
            else if (this.tbChitiet.SelectedTab == tpCongTangCa)
                EditCongTangCaCt(enuEdit.New);
		}
        void btSXChamCong_Click(object sender, EventArgs e)
        {
            frmChamCongSX frm = new frmChamCongSX();
            frm.Load(Library.StrToDate(dtpNgay_Ct2.Text));

            FillData();
        }
        void btPhanQuyenCC_Click(object sender, EventArgs e)
        {
            frmPhanQuyenXepCa frm = new frmPhanQuyenXepCa();
            frm.Load();
        }
        void btDKSuatAn_Click(object sender, EventArgs e)
        {
            frmChamCongCom frm = new frmChamCongCom();
            frm.Load(Library.StrToDate(dtpNgay_Ct1.Text), Library.StrToDate(dtpNgay_Ct2.Text), cboMa_Bp.Text, cboMa_Bp_Ct.Text);
            if (frm.Is_Accept)
            {
                dtCongNhaAn.Clear();
                Hashtable ht = new Hashtable();
                ht.Add("NGAY_CT1", dtpNgay_Ct1.Value.ToShortDateString());
                ht.Add("NGAY_CT2", dtpNgay_Ct2.Value.ToShortDateString());
                ht.Add("MA_BP", cboMa_Bp.Text);
                ht.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
                ht.Add("USER_LOGIN", Element.sysUser_Id);
                dtCongNhaAn = SQLExec.ExecuteReturnDt("sp_GetDSCBNVTHEOCA",ht,CommandType.StoredProcedure);

                bdsCongNhaAn.DataSource = dtCongNhaAn;
                dgvCongNhaAn.DataSource = bdsCongNhaAn;
            }
        }
        void btHsABC_Click(object sender, EventArgs e)
        {
            frmHsABC frm = new frmHsABC();
            frm.Load(cboMa_Bp.Text, Convert.ToDateTime(dtpNgay_Ct1.Text), Convert.ToDateTime(dtpNgay_Ct2.Text));
        }
        void btPrint_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsHinhThucCC.Current).Row;
            frmIn_ChamCong frm = new frmIn_ChamCong();
            frm.Load(drCurrent);

            if (frm.isAccept)
            {
                if (frm.rdbChamCong.Checked)
                {
                    if (frm.txtMa_Dt_CbNv.Text != "")
                        PrintCC(true, frm.txtMa_Dt_CbNv.Text);
                    else
                    {
                        foreach (DataRow dr in dtKQChamCong.Rows)
                            PrintCC(false, dr["Ma_Dt_CbNv"].ToString());
                    }
                }
                else
                {
                    if (frm.txtMa_Dt_CbNv.Text != "")
                        PrintBDDH(true, frm.txtMa_Dt_CbNv.Text);
                    else
                    {
                        foreach (DataRow dr in dtHinhThucCC.Rows)
                            PrintBDDH(false, dr["Ma_Dt_CbNv"].ToString());
                    }
                }
            }       
        }

        bool PrintCC(bool bPreview, string strMa_Dt_CbNv)
        {
            if (bdsKQChamCong.Position < 0)
                return false;

            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dtpNgay_Ct1.Value.ToShortDateString());
            ht.Add("NGAY_CT2", dtpNgay_Ct2.Value.ToShortDateString());
            ht.Add("MA_BP", cboMa_Bp.Text);
            ht.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
            ht.Add("USER_ID", Element.sysUser_Id);
            ht.Add("MA_DT_CBNV", strMa_Dt_CbNv);
            ht.Add("IS_VND", 1);
            ht.Add("LANGUAGE_TYPE", "V");
            ht.Add("MA_DVCS", Element.sysMa_DvCs);

            DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintChamCong", ht, CommandType.StoredProcedure);
            DataTable dtHeader = ds.Tables[0];
            DataTable dtDetail = ds.Tables[1];

            dtHeader.Columns.Add("REPORT_FILE", typeof(string));
            dtHeader.Columns.Add("TITLE", typeof(string));

            DataRow drHeader = dtHeader.Rows[0];

            // GAN GIA TRI TRONG THANG
            DateTime dtNgay_Ct2 = Convert.ToDateTime(dtpNgay_Ct2.Text);
            DateTime dtNgay_Cuoi_Thang = Voucher.GetLastDayOfMonth(dtNgay_Ct2.Year, dtNgay_Ct2.Month);
            if (dtNgay_Cuoi_Thang.Day == 31)
                drHeader["Report_File"] = "rptChamCong31";
            else if (dtNgay_Cuoi_Thang.Day == 30)
                drHeader["Report_File"] = "rptChamCong30";
            else if (dtNgay_Cuoi_Thang.Day == 29)
                drHeader["Report_File"] = "rptChamCong29";
            else
                drHeader["Report_File"] = "rptChamCong28";

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);
        }
        bool PrintBDDH(bool bPreview, string strMa_Dt_CbNv)
        {
            if (bdsKQChamCong.Position < 0)
                return false;

            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dtpNgay_Ct1.Value.ToShortDateString());
            ht.Add("NGAY_CT2", dtpNgay_Ct2.Value.ToShortDateString());
            ht.Add("MA_BP", cboMa_Bp.Text);
            ht.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
            ht.Add("USER_ID", Element.sysUser_Id);
            ht.Add("MA_DT_CBNV", strMa_Dt_CbNv);
            ht.Add("IS_VND", 1);
            ht.Add("LANGUAGE_TYPE", "V");
            ht.Add("MA_DVCS", Element.sysMa_DvCs);

            DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintBDDH", ht, CommandType.StoredProcedure);
            DataTable dtHeader = ds.Tables[0];
            DataTable dtDetail = ds.Tables[1];

            dtHeader.Columns.Add("REPORT_FILE", typeof(string));
            dtHeader.Columns.Add("TITLE", typeof(string));

            DataRow drHeader = dtHeader.Rows[0];
            drHeader["Report_File"] = "rptBDDH";
           
           RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);
        }
        private void Design()
        {
            drCurrent = ((DataRowView)bdsKQChamCong.Current).Row;
            frmIn_ChamCong frm2 = new frmIn_ChamCong();
            frm2.Load(drCurrent);
            string strFile_Name = "rpt";
            if (frm2.isAccept)
            {
                if (frm2.rdbChamCong.Checked)
                {
                    frmIn_Cham_Cong frm1 = new frmIn_Cham_Cong();
                    frm1.Load();

                    strFile_Name += frm1.rdbNgay_28.Checked ? "ChamCong28"
                        : frm1.rdbNgay_29.Checked ? "ChamCong29"
                        : frm1.rdbNgay_30.Checked ? "ChamCong30"
                        : "ChamCong31";
                }
                else
                    strFile_Name = "rptBDDH";
            }
            RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
            frm.Load(strFile_Name);
        }
        void btDuyetChamCong_Click(object sender, EventArgs e)
        {
            if (bdsKQChamCong.Position < 0)
                return;
           //kiểm tra nếu khóa bảng công thì không được mở form
            Hashtable ht = new Hashtable();
            ht.Add("NAM", Convert.ToDateTime(dtpNgay_Ct2.Text).Year);
            ht.Add("THANG", Convert.ToDateTime(dtpNgay_Ct2.Text).Month);
            bool bLockCong = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Lock_Cong FROM R00LOCKEDLUONG WHERE Nam = @Nam AND Thang = @Thang", ht, CommandType.Text));

            //if(Convert.ToDateTime(dtpNgay_Ct1.Text) - Convert.ToDateTime(dtpNgay_Ct2.Text) > 31 ||
            //    Convert.ToDateTime(dtpNgay_Ct1.Text) - Convert.ToDateTime(dtpNgay_Ct2.Text) <0 )
            //{

            //}
            //else
            //{ 
                frmDuyetCongTangCa frm = new frmDuyetCongTangCa();
                frm.Load(cboMa_Bp.Text, Convert.ToDateTime(dtpNgay_Ct1.Text), Convert.ToDateTime(dtpNgay_Ct2.Text), true);
            //}
        }

        void btDuyetTangCa_Click(object sender, EventArgs e)
        {
            if (bdsCongTangCaCt.Position < 0)
                return;

            frmDuyetCongTangCa frm = new frmDuyetCongTangCa();
            frm.Load(cboMa_Bp.Text, Convert.ToDateTime(dtpNgay_Ct1.Text), Convert.ToDateTime(dtpNgay_Ct2.Text), false);

            if (frm.Is_Accept)
            {
                Hashtable ht = new Hashtable();
                ht.Add("NGAY", dtpNgay_Ct1.Value.ToShortDateString());
                ht.Add("NGAY_CT1", dtpNgay_Ct1.Value.ToShortDateString());
                ht.Add("NGAY_CT2", dtpNgay_Ct2.Value.ToShortDateString());
                ht.Add("MA_BP", cboMa_Bp.Text);
                ht.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
                ht.Add("MA_BP1", cboMa_Bp.Text);
                ht.Add("MA_BP_CT1", cboMa_Bp_Ct.Text);
                dtCongTangCaCt = SQLExec.ExecuteReturnDt("SELECT T1.*, Ten_Dt_CbNv, Ma_Bp, Ma_Bp_Ct FROM R10CONGTANGCA T1 " +
                                        "LEFT JOIN (SELECT Ma_Dt AS Ma_Dt_CbNv, Ten_Dt AS Ten_Dt_CbNv, Ma_Bp, Ma_Bp_Ct FROM R81DMDT WHERE Ma_Nh_Dt = 'NV') T2 ON T1.Ma_Dt_CbNv = T2.Ma_Dt_CbNv" +
                                            " WHERE (Ma_Bp = @Ma_Bp OR @Ma_Bp1 = '') " +
                                            " AND (Ma_Bp_Ct like @Ma_Bp_Ct + '%' OR @Ma_Bp_Ct1 = '') " +
                                            " AND T1.Ngay_Cham_Cong BETWEEN @Ngay_Ct1 AND @Ngay_Ct2", ht,CommandType.Text);

                bdsCongTangCaCt.DataSource = dtCongTangCaCt;
                dgvCongTangCaCt.DataSource = bdsCongTangCaCt;
            }
        }
        void EditNVKChamCong(enuEdit enuNew_Edit)
        {
            if (bdsBsChamCong.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsBsChamCong.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBsChamCong.Current).Row, ref drCurrent);
            else
                drCurrent = dtBsChamCong.NewRow();

            if(enuNew_Edit== enuEdit.New || enuNew_Edit == enuEdit.Copy)
                drCurrent["Ma_TNLD"] = string.Empty;
            
            frmNVKChamCong_Edit frmEdit = new frmNVKChamCong_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, cboMa_Bp.Text, cboMa_Bp_Ct.Text);
            
            if (frmEdit.isAccept)
            {
                DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];

                DataTable dtType = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMTYPE WHERE Type = 'TRANG_THAI_CONG' AND Type_ID = '" + drCurrent["Tinh_Trang_Cong"].ToString() + "'");
                DataRow drDmType = dtType.Rows[0];
                drCurrent["Ten_Tinh_Trang_Cong"] = drDmType["Type_Name"];


                if (enuNew_Edit == enuEdit.New)
                    if (bdsBsChamCong.Position >= 0)
                        dtBsChamCong.ImportRow(drCurrent);
                    else
                        dtBsChamCong.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsBsChamCong.Current).Row);
                }


                bdsBsChamCong.Position = bdsBsChamCong.Find("IDENT00", drCurrent["IDENT00"]);
                dtBsChamCong.AcceptChanges();
            }
            else
                dtBsChamCong.RejectChanges();
        }
        //void EditCongTangCa(enuEdit enuNew_Edit)
        //{
        //    if (bdsCongTangCa.Position < 0 && enuNew_Edit == enuEdit.Edit)
        //        return;

        //    //Copy hang hien tai            
        //    if (bdsCongTangCa.Position >= 0)
        //        Common.CopyDataRow(((DataRowView)bdsCongTangCa.Current).Row, ref drCurrent);
        //    else
        //        drCurrent = dtCongTangCa.NewRow();

        //    frmCongTangCa_Edit frmEdit = new frmCongTangCa_Edit();
        //    frmEdit.Load(enuNew_Edit, drCurrent);

        //    if (frmEdit.isAccept)
        //    {
        //        DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
        //        drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];
        //        if (enuNew_Edit == enuEdit.New)
        //            if (bdsCongTangCa.Position >= 0)
        //                dtCongTangCa.ImportRow(drCurrent);
        //            else
        //                dtCongTangCa.Rows.Add(drCurrent);
        //        else
        //        {
        //            Common.CopyDataRow(drCurrent, ((DataRowView)bdsCongTangCa.Current).Row);
        //        }


        //        bdsCongTangCa.Position = bdsCongTangCa.Find("IDENT00", drCurrent["IDENT00"]);
        //        dtCongTangCa.AcceptChanges();
        //    }
        //    else
        //        dtCongTangCa.RejectChanges();
        //}
		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
        void dgvKQChamCong_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
            {
                Common.MsgOk("Bạn không được phân quyền sửa dữ liệu chấm công!!!");
                return;
            }
            
            drCurrent = ((DataRowView)bdsKQChamCong.Current).Row;

            frmSuaDLChamCong FRM = new frmSuaDLChamCong();
            FRM.Load(drCurrent["Ma_Dt_CbNv"].ToString(), Convert.ToDateTime(dtpNgay_Ct2.Text));
        }
        void dgvCongTangCa_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsCongTangCa.Current).Row;
            DataGridViewCell dgvCell = dgvCongTangCa.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "ACCEPTTK")
            {
                EditCongTangCaCt(enuEdit.New);
            }
        }
        void EditCongTangCaCt(enuEdit enuNew_Edit)
        {
            
            if (bdsCongTangCaCt.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsCongTangCaCt.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsCongTangCaCt.Current).Row, ref drCurrent);
            else
                drCurrent = dtCongTangCaCt.NewRow();

            if (enuNew_Edit == enuEdit.New && bdsCongTangCaCt.Position >= 0)
                drCurrent = ((DataRowView)bdsCongTangCaCt.Current).Row;

            if (bdsCongTangCaCt.Position >= 0 && enuNew_Edit == enuEdit.Edit)
            {
                if((bool)drCurrent["Duyet_TP"])
                    return;
            }

            frmCongTangCa_Edit frmEdit = new frmCongTangCa_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsCongTangCaCt.Position >= 0)
                        dtCongTangCaCt.ImportRow(drCurrent);
                    else
                        dtCongTangCaCt.Rows.Add(drCurrent);

                    bdsCongTangCaCt.Position = bdsCongTangCaCt.Find("Ident00", drCurrent["Ident00"]);
                   
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCongTangCaCt.Current).Row);
                }
                DataRow drDmNV = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = (string)drDmNV["Ten_Dt"];
                //FillData("");
                dtCongTangCaCt.AcceptChanges();
            }
            else
                dtCongTangCaCt.RejectChanges();
        }
        void EditCongNhaAn(enuEdit enuNew_Edit)
        {

            if (bdsCongNhaAn.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsCongNhaAn.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsCongNhaAn.Current).Row, ref drCurrent);
            else
                drCurrent = dtCongNhaAn.NewRow();

            if (enuNew_Edit == enuEdit.New && bdsCongNhaAn.Position >= 0)
                drCurrent = ((DataRowView)bdsCongNhaAn.Current).Row;

            if (bdsCongNhaAn.Position >= 0 && enuNew_Edit == enuEdit.Edit)
            {
                if ((DateTime)drCurrent["Ngay_Cham_Cong"] < Voucher.GetDate_Server())
                    return;
            }

            frmSuaCongCom_Edit frmEdit = new frmSuaCongCom_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsCongNhaAn.Position >= 0)
                        dtCongNhaAn.ImportRow(drCurrent);
                    else
                        dtCongNhaAn.Rows.Add(drCurrent);

                    bdsCongNhaAn.Position = bdsCongNhaAn.Find("Ident00", drCurrent["Ident00"]);

                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCongNhaAn.Current).Row);
                }
                DataRow drDmNV = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = (string)drDmNV["Ten_Dt"];
                //FillData("");
                dtCongNhaAn.AcceptChanges();
            }
            else
                dtCongNhaAn.RejectChanges();
        }
        void dgvDCChamCong_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsDCChamCong.Current).Row;
            DataGridViewCell dgvCell = dgvDCChamCong.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "EDIT")
            {
                if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
                {
                    Common.MsgOk("Bạn không được phân quyền sửa dữ liệu chấm công!!!");
                    return;
                }

                string strCreate_User = (string)drCurrent["Create_Log"];

                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id && !Element.sysIs_Admin)
                {
                   
                    Common.MsgCancel("Không được sửa dữ liệu do " + strCreate_User.Substring(14) + " lập!!!");
                    return;
                    
                }
                else
                {
                    
                    
                    frmDCChamCong_Edit frm = new frmDCChamCong_Edit();
                    frm.Load(enuEdit.Edit, drCurrent);
                  
                    
                }
            }
        }
        void dgvHinhThucCC_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsHinhThucCC.Current).Row;
            DataGridViewCell dgvCell = dgvHinhThucCC.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "NEW")
            {
                frmHinhThucCC_Edit frm = new frmHinhThucCC_Edit();
                frm.Load(enuEdit.New, drCurrent, drCurrent["Ma_Bp"].ToString());
            }
            if (strColumnName == "EDIT")
            {
                string strCreate_User = (string)drCurrent["Create_Log"];

                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id && !Element.sysIs_Admin && Element.sysUser_Id != "LANHDP")
                {
                   
                    Common.MsgCancel("Không được sửa dữ liệu do " + strCreate_User.Substring(14) + " lập!!!");
                            return;
                   
                }
                    
                else
                {
                    frmHinhThucCC_Edit frm = new frmHinhThucCC_Edit();
                    frm.Load(enuEdit.Edit, drCurrent, drCurrent["Ma_Bp"].ToString());
                }
            }
        }
        void dgvHinhThucCC_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvHinhThucCC;

            bdsSearch = bdsKQChamCong;
        }
        

        void dgvNVKChamCong_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvNVKChamCong;
        }

        void dgvNVChamCong_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvNVChamCong;
        }
        void dgvCongNhaAn_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvCongNhaAn;
        }
        void dgvKQChamCong_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvKQChamCong;

            bdsSearch = bdsKQChamCong;
        }
        void dgvKQChamCongTH_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvKQChamCongTH;


        }

        void dgvCongTangCa_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvCongTangCa;
        }
        void dgvBsChamCong_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvBsChamCong;
        }
        void dgvCongTangCaCt_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvCongTangCaCt;
        }


        void cboMa_Bp_TextChanged(object sender, EventArgs e)
        {
            

            if (cboMa_Bp.Text == string.Empty)
                return;
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("MA_BP", cboMa_Bp.Text);
                ht.Add("LOGIN_ID", Element.sysUser_Id);
                dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", ht, CommandType.StoredProcedure);
                
                //dtDmBpCt = dsBp.Tables[1];
                //cboMa_Bp_Ct.lstItem.BuildListView("Ma_Bp_Ct:100,Ten_Bp_Ct:200");
                //cboMa_Bp_Ct.lstItem.DataSource = dtDmBpCt;
                //cboMa_Bp_Ct.lstItem.Size = new Size(800, cboMa_Bp_Ct.lstItem.Items.Count * 20);
                //cboMa_Bp_Ct.lstItem.GridLines = true;

                dtDmBpCt = dsBp.Tables[1];
                cboMa_Bp_Ct.lstItem.BuildListView("Ma_Bp_Ct:100,Ten_Bp_Ct:200");
                cboMa_Bp_Ct.lstItem.DataSource = dtDmBpCt;
                //cboMa_Bp_Ct.lstItem.Size = new Size(800, cboMa_Bp_Ct.lstItem.Items.Count * 20);
                cboMa_Bp_Ct.lstItem.Size = new Size(400, 300);
                cboMa_Bp_Ct.lstItem.GridLines = true;
            }
            this.FillData();
        }

        void cboMa_Bp_Ct_TextChanged(object sender, EventArgs e)
        {
            

            if (cboMa_Bp_Ct.Text == string.Empty)
                return;

            this.FillData();
        }
        void dgvKQChamCong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (bdsKQChamCong.Position < 0)
                return;

            //dgvKQChamCong.Rows[e.RowIndex].Cells["NGAY_"].Style.ForeColor = Color.Yellow;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)
                return;

            switch (e.KeyCode)
            {
                case Keys.F7:
                    if (e.Modifiers == Keys.Shift)
                        this.Design();
                    return;
            }

            base.OnKeyDown(e);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

           

        }
	}
}
