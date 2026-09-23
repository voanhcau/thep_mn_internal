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

namespace RosyModule.HRM
{
    public partial class frmDLRaVaoCong : RosySystem.Customize.frmView
	{
		#region Variable

		//Luu y toi bManual
        object objActive = null;

		DataSet dsVoucher = new DataSet();
		DataTable dtEditPh;
        DataTable dtEditPh_Dest;
		DataTable dtEditCt;
        DataTable dtEditCt_NhanVienCa;
        DataTable dtEditCt_NhanVienCty;
        DataTable dtEditCt_XeNbCty;
        DataTable dtEditCt_XeKhachChoHang;
        DataTable dtEditCt_XeKhachLH;
        DataTable dtEditCt_XePKD;
        DataTable dtEditCt_NhanVienSuCo;
        DataTable dtEditCt_XaLan;
        //DataTable dtEditCt_VTPT;
        //DataTable dtEditCt_VTPTCT;

        DataRow drEditPh;
		DataRow drEditCt;
        DataRow drEditCt_NhanVienCty;
        DataRow drEditCt_XeNbCty;
        //DataRow drEditCt_VTPT;
        //DataRow drEditCt_VTPTCT;
    


		BindingSource bdsEditPh = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
        BindingSource bdsEditCt_NhanVienCa = new BindingSource();
        BindingSource bdsEditCt_NhanVienCty = new BindingSource();
        BindingSource bdsEditCt_XeNbCty = new BindingSource();
        BindingSource bdsEditCt_XeKhachChoHang = new BindingSource();
        BindingSource bdsEditCt_XeKhachLH = new BindingSource();
        BindingSource bdsEditCt_XePKD = new BindingSource();
        BindingSource bdsEditCt_NhanVienSuCo = new BindingSource();
        BindingSource bdsEditCt_XaLan = new BindingSource();
        //BindingSource bdsEditCt_VTPT = new BindingSource();
        //BindingSource bdsEditCt_VTPTCT = new BindingSource();

		DataRow drCurrent;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;
        string strMa_Dt_CbNv_Bv = string.Empty;
        string strStt = string.Empty;
        string strStt_New = string.Empty;
       //VTPT
        //private rsDataGridView dgvVTPT = new rsDataGridView();
        //private rsDataGridView dgvVTPTCT = new rsDataGridView();

		#endregion

        public frmDLRaVaoCong()
		{
			InitializeComponent();

            this.KeyDown += new KeyEventHandler(KeyDownEvent);
            dgvNhanVienCa.Enter += new EventHandler(dgvNhanVienCa_Enter);
            dgvNhanVienCty.Enter += new EventHandler(dgvNhanVienCty_Enter);
            dgvXeKhachChoHang.Enter += new EventHandler(dgvXeKhach_Enter);
            dgvXeNbCty.Enter += new EventHandler(dgvXeNbCty_Enter);
            dgvXePKD.Enter += new EventHandler(dgvXePKD_Enter);
            dgvXeKhachLH.Enter += new EventHandler(dgvXeKhachLH_Enter);
            dgvNhanVienSuCo.Enter+=new EventHandler(dgvNhanVienSuCo_Enter);
            dgvXaLan.Enter += new EventHandler(dgvXaLan_Enter);

            dgvXePKD.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvXePKD_CellMouseClick);
            //dgvVTPT.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvVTPT_CellMouseClick);
            this.btRefresh.Click += new EventHandler(btRefresh_Click);           
           
           
            this.btFirst.Click += new EventHandler(btFirst_Click);
			this.btNext.Click += new EventHandler(btNext_Click);
			this.btPrevious.Click += new EventHandler(btPrevious_Click);
			this.btLast.Click += new EventHandler(btLast_Click);


            this.btTao_Ca.Click += new EventHandler(btTao_Ca_Click);
            this.btKet_Thuc_Ca.Click +=new EventHandler(btKet_Thuc_Ca_Click);
            btNew.Click += new EventHandler(btNew_Click);
            btExit.Click += new EventHandler(btExit_Click);
            btDelete.Click+=new EventHandler(btDelete_Click);
            btUpdate.Click += new EventHandler(btUpdate_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
            btXacNhanRvc.Click += new EventHandler(btCBNV_Click);
            btXeCong.Click += new EventHandler(btXeCong_Click);
            cboCong_Filter.SelectedValueChanged += new EventHandler(cboCong_Filter_SelectedValueChanged);

            //this.bdsEditCt_VTPT.PositionChanged += new EventHandler(bdsEditCt_VTPT_PositionChanged);
		}

        void btXeCong_Click(object sender, EventArgs e)
        {
            frmXeCong frm = new frmXeCong();
            frm.Load();
        }



        new public void Load()
		{
            DateTime dteNgay_Ct2 = DateTime.Now;
            DateTime dteNgay_Ct1 = dteNgay_Ct2.AddDays(-3);// dteNgay_Ct2.AddDays((-dteNgay_Ct2.Day) + 1);

            this.dteNgay_Ct1.Text = Library.DateToStr(dteNgay_Ct1);
            this.dteNgay_Ct2.Text = Library.DateToStr(dteNgay_Ct2);
           

            this.Build();
            this.FillData();
            this.Init_Ct();
            LoadDicName();

            if(Common.CheckPermission("DLRAVAOCONG",enuPermission_Type.Allow_New))
                btNew.Enabled = true;
            else
                btNew.Enabled = false;

            if (Common.CheckPermission("DLRAVAOCONG", enuPermission_Type.Allow_Delete))
                btDelete.Enabled = true;
            else
                btDelete.Enabled = false;

           
			this.Show();
		}

        private void LoadDicName()
        {
       
        }
		private void Build()
		{
            
            dgvNhanVienCty.bSortMode = false;
            dgvNhanVienCty.strZone = "NHANVIEN_RVC";
            dgvNhanVienCty.BuildGridView();

            dgvXeNbCty.bSortMode = false;
            dgvXeNbCty.strZone = "XENB_RVC";
            dgvXeNbCty.BuildGridView();

            dgvXeKhachChoHang.bSortMode = false;
            dgvXeKhachChoHang.strZone = "XEKHACH";
            dgvXeKhachChoHang.BuildGridView();

            dgvXeKhachLH.bSortMode = false;
            dgvXeKhachLH.strZone = "XEKHACHLH";
            dgvXeKhachLH.BuildGridView();

            dgvXePKD.bSortMode = false;
            dgvXePKD.strZone = "XEPKD";
            dgvXePKD.BuildGridView();

            dgvNhanVienCa.bSortMode = false;
            dgvNhanVienCa.strZone = "NHANVIENCA";
            dgvNhanVienCa.BuildGridView();

            dgvNhanVienSuCo.bSortMode = false;
            dgvNhanVienSuCo.strZone = "NHANVIEN_RVC";
            dgvNhanVienSuCo.BuildGridView();

            dgvXaLan.bSortMode = false;
            dgvXaLan.strZone = "XALANCONG";
            dgvXaLan.BuildGridView();


            //dgvVTPT.bSortMode = false;
            //dgvVTPT.strZone = "VTPTCONG";
            //dgvVTPT.BuildGridView();



            //dgvVTPTCT.bSortMode = false;
            //dgvVTPTCT.strZone = "VTPTCONGCT";
            //dgvVTPTCT.BuildGridView();

            this.DataGridView_Language();

            foreach (DataGridViewColumn dgvc in dgvNhanVienCty.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvXeNbCty.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvXeKhachChoHang.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvXePKD.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvXeKhachLH.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvNhanVienSuCo.Columns)
                dgvc.ReadOnly = true;
           
            foreach (DataGridViewColumn dgvc in dgvXaLan.Columns)
                dgvc.ReadOnly = true;

            //foreach (DataGridViewColumn dgvc in dgvVTPT.Columns)
            //    dgvc.ReadOnly = true;

            //foreach (DataGridViewColumn dgvc in dgvVTPTCT.Columns)
            //    dgvc.ReadOnly = true;

            //this.spcVTPT.Panel1.Controls.Add(dgvVTPT);
            //this.spcVTPT.Panel2.Controls.Add(dgvVTPTCT);
            //dgvVTPT.Dock = DockStyle.Fill;
            //dgvVTPTCT.Dock = DockStyle.Fill;
		}

		private void DataGridView_Language()
		{
            if (dgvXeNbCty.Columns.Contains("Ghi_Chu"))
            {
                dgvXeNbCty.Columns["Ghi_Chu"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvXeNbCty.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvXeNbCty.Columns["Ghi_Chu"].HeaderText = "Lý do ra cổng";
            }

            if (dgvXeKhachLH.Columns.Contains("Ten_Dt_CbNv"))
                dgvXeKhachLH.Columns["Ten_Dt_CbNv"].HeaderText = "Người đại diện Công ty tiếp";

            //if (dgvVTPT.Columns.Contains("So_Luong_Vao"))
            // {
            //    dgvVTPT.Columns["So_Luong_Vao"].HeaderText = "SL mang vào";
            //    dgvVTPT.Columns["So_Luong_Ra"].HeaderText = "SL mang ra";
            // }
            //if (dgvVTPTCT.Columns.Contains("So_Luong_Vao"))
            // {
            //    dgvVTPTCT.Columns["So_Luong_Vao"].HeaderText = "SL mang vao";
            //    dgvVTPTCT.Columns["So_Luong_Ra"].HeaderText = "SL mang ra";
            // }
            
			
		}

		private void Init_Ct()
		{
            txtTinh_Hinh_Giao_Ca.Enabled = false;
            txtTinh_Hinh_Nhan_Ca.Enabled = false;

            dteNgay_Ct.Enabled = false;
            cboCong.Enabled = false;
            cboCa.Enabled = false;
		}
        private void FillData(string strStt_Current)
        {
            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt_Current);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLRAVAOCONG", ht, CommandType.StoredProcedure);

            dtEditPh = dsVoucher.Tables[0];
            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }


            LoadCombo();

        

            strStt = strStt_Current;
        }
        private void LoadCombo()
        {
            Hashtable ht1 = new Hashtable();
            ht1.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht1.Add("NGAY_CT2", dteNgay_Ct2.Text);
            DataTable dtLoadCombo;
            if (strStt_New != "" || strStt_New != string.Empty)
            {
                ht1.Add("STT_NEW", strStt_New);
                dtLoadCombo = SQLExec.ExecuteReturnDt("SELECT Stt, Cong + ' ' + Ca + ' ' + REPLACE(STR(DAY(Ngay_Ct),2), ' ', '') AS CONG FROM R09PH_RVC WHERE Ngay_Ct <= @Ngay_Ct2 AND Ngay_Ct >= @Ngay_Ct1 AND Stt = @STT_NEW  ORDER BY Ngay_Ct DESC", ht1, CommandType.Text);
            }
            else
                dtLoadCombo = SQLExec.ExecuteReturnDt("SELECT Stt, Cong + ' ' + Ca + ' ' + REPLACE(STR(DAY(Ngay_Ct),2), ' ', '') AS CONG FROM R09PH_RVC WHERE Ngay_Ct <= @Ngay_Ct2 AND Ngay_Ct >= @Ngay_Ct1  ORDER BY Ngay_Ct DESC", ht1, CommandType.Text);
            cboCong_Filter.DataSource = dtLoadCombo;
            cboCong_Filter.ValueMember = "STT";
            cboCong_Filter.DisplayMember = "CONG";
        }
	    private void FillData()
		{
            Hashtable ht = new Hashtable();
         
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            //ht.Add("CONG", this.cboCong_Filter.Text);
            //ht.Add("CA", cboCa.Text);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLRAVAOCONG", ht, CommandType.StoredProcedure);

            dtEditPh = dsVoucher.Tables[0];
            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }

            LoadCombo();


            dtEditCt_XaLan = dsVoucher.Tables[8];
            bdsEditCt_XaLan.DataSource = dtEditCt_XaLan;
            dgvXaLan.DataSource = bdsEditCt_XaLan;
		}
       
        private void FillData_Voucher_Ph()
        {
            if (!string.IsNullOrEmpty(strStt))
            {
                DataRow[] arrdrEditPh_Dest = dtEditPh.Select("Stt = '" + strStt + "'");
                if (arrdrEditPh_Dest.Length > 0 && arrdrEditPh_Dest.Length == 1)
                {
                    if (this.dtEditPh_Dest != null)
                        this.dtEditPh_Dest.Rows.Clear();

                    this.dtEditPh_Dest = dtEditPh.Clone();

                    foreach (DataRow dr in arrdrEditPh_Dest)
                        this.dtEditPh_Dest.ImportRow(dr);

                    this.bdsEditPh.Position = this.bdsEditPh.Find("STT", strStt);
                    this.lbtRecorde.Text = this.bdsEditPh.Position + 1 + "/" + this.bdsEditPh.Count;

                    this.ScaterMemvar_Voucher_Edit(this.dtEditPh_Dest.Rows[0]);
                    this.FillData_Voucher_Ct();
                }
            }
            else
                this.Reset_Voucher_Edit();
        }
        private void FillData_Voucher_Ct()
        {
            
            Hashtable ht = new Hashtable();

            ht.Add("STT", this.strStt);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLRAVAOCONG", ht, CommandType.StoredProcedure);

            dtEditCt_NhanVienCa = dsVoucher.Tables[1];
            bdsEditCt_NhanVienCa.DataSource = dtEditCt_NhanVienCa;
            dgvNhanVienCa.DataSource = bdsEditCt_NhanVienCa;

            dtEditCt_NhanVienCty = dsVoucher.Tables[2];
            bdsEditCt_NhanVienCty.DataSource = dtEditCt_NhanVienCty;
            dgvNhanVienCty.DataSource = bdsEditCt_NhanVienCty;

            dtEditCt_XeNbCty = dsVoucher.Tables[3];
            bdsEditCt_XeNbCty.DataSource = dtEditCt_XeNbCty;
            dgvXeNbCty.DataSource = bdsEditCt_XeNbCty;

            dtEditCt_XeKhachChoHang = dsVoucher.Tables[4];
            bdsEditCt_XeKhachChoHang.DataSource = dtEditCt_XeKhachChoHang;
            dgvXeKhachChoHang.DataSource = bdsEditCt_XeKhachChoHang;

            dtEditCt_XePKD = dsVoucher.Tables[5];
            bdsEditCt_XePKD.DataSource = dtEditCt_XePKD;
            dgvXePKD.DataSource = bdsEditCt_XePKD;

            dtEditCt_XeKhachLH = dsVoucher.Tables[6];
            bdsEditCt_XeKhachLH.DataSource = dtEditCt_XeKhachLH;
            dgvXeKhachLH.DataSource = bdsEditCt_XeKhachLH;

            dtEditCt_NhanVienSuCo = dsVoucher.Tables[7];
            bdsEditCt_NhanVienSuCo.DataSource = dtEditCt_NhanVienSuCo;
            dgvNhanVienSuCo.DataSource = bdsEditCt_NhanVienSuCo;

            //dtEditCt_VTPT = dsVoucher.Tables[9];
            //bdsEditCt_VTPT.DataSource = dtEditCt_VTPT;
            //dgvVTPT.DataSource = bdsEditCt_VTPT;

            //dtEditCt_VTPTCT = dsVoucher.Tables[10];
            //bdsEditCt_VTPTCT.DataSource = dtEditCt_VTPTCT;
            //dgvVTPTCT.DataSource = bdsEditCt_VTPTCT;
           


        }
        private void Reset_Voucher_Edit()
        {

            cboCa.Text =  txtTinh_Hinh_Giao_Ca.Text = txtTinh_Hinh_Nhan_Ca.Text = string.Empty;

            if (dtEditCt_NhanVienCa != null)
                dtEditCt_NhanVienCa.Rows.Clear();
            if (dtEditCt_NhanVienCty != null)
                dtEditCt_NhanVienCty.Rows.Clear();
            if (dtEditCt_XeNbCty != null)
                dtEditCt_XeNbCty.Rows.Clear();
            if (dtEditCt_XeKhachChoHang != null)
                dtEditCt_XeKhachChoHang.Rows.Clear();
            if (dtEditCt_XePKD != null)
                dtEditCt_XePKD.Rows.Clear();
            if (dtEditCt_XeKhachLH != null)
                dtEditCt_XeKhachLH.Rows.Clear();
            if (dtEditCt_NhanVienSuCo != null)
                dtEditCt_NhanVienSuCo.Rows.Clear();        
            
        }
	
        private void ScaterMemvar_Voucher_Edit(DataRow drEditPh_Dest)
        {

            dteNgay_Ct.Text = Library.DateToStr(Convert.ToDateTime(drEditPh_Dest["Ngay_Ct"]));
            cboCa.Text = (string)drEditPh_Dest["Ca"];
            cboCong.Text = (string)drEditPh_Dest["Cong"];


            txtTinh_Hinh_Giao_Ca.Text = (string)drEditPh_Dest["Tinh_Hinh_Giao_Ca"];
            txtTinh_Hinh_Nhan_Ca.Text = (string)drEditPh_Dest["Tinh_Hinh_Nhan_Ca"];
            
        }

        void btTao_Ca_Click(object sender, EventArgs e)
        {
            if (btTao_Ca.Text == "Thêm ca bảo vệ")
            {
                
                Reset_Voucher_Edit();
                dteNgay_Ct.Focus();

                dteNgay_Ct.Text = Library.DateToStr(DateTime.Now);
                dteNgay_Ct.ReadOnly = false;
                cboCa.Enabled = true;
                cboCong.Enabled = true;

                txtTinh_Hinh_Nhan_Ca.Enabled = true;
                dteNgay_Ct.Enabled = true;
                cboCong.Enabled = true;
                cboCa.Enabled = true;


                strStt = Common.GetNewStt("09", true);
                strStt_New = strStt;
                btTao_Ca.Text = "Lưu";
                btKet_Thuc_Ca.Enabled = false;
                btNew.Enabled = false;

              
            }
            else if (btTao_Ca.Text == "Lưu")
            {
                enuNew_Edit_Voucher = enuEdit.New;
                // chọn nhân viên bảo vệ
                Common.MsgOk("Bạn vui lòng chọn nhân viên bảo vệ trong ca trực. Sau khi tick chọn phải nhấn phím Enter. Xin cảm ơn");
                if (!LookupNVBV())
                {
                    Save();


                    btTao_Ca.Text = "Thêm ca bảo vệ";
                    btKet_Thuc_Ca.Enabled = true;
                    btNew.Enabled = true;
                    txtTinh_Hinh_Nhan_Ca.Enabled = false;
                    dteNgay_Ct.Enabled = false;
                    cboCong.Enabled = false;
                    cboCa.Enabled = false;
                }
                else
                {
                    Common.MsgOk("Dữ liệu ca chưa được lưu. Bạn vui lòng nhấn lưu để chọn nhân viên bảo vệ trong ca trực. Sau khi tick chọn phải nhấn phím Enter. Xin cảm ơn");
                    if (!LookupNVBV())
                    {
                        Save();


                        btTao_Ca.Text = "Thêm ca bảo vệ";
                        btKet_Thuc_Ca.Enabled = true;
                        btNew.Enabled = true;
                        txtTinh_Hinh_Nhan_Ca.Enabled = false;
                        dteNgay_Ct.Enabled = false;
                        cboCong.Enabled = false;
                        cboCa.Enabled = false;
                    }
                }
            }
        }
        bool LookupNVBV()
        {
            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Dt", strMa_Dt_CbNv_Bv, true, "Ma_Bp = 'PTCHC' AND Ma_Bp_Ct LIKE '%BV%' AND Ngay_Nghi_Lam = '19000101'", "");
            if (drLookup == null)
            {
                strMa_Dt_CbNv_Bv = string.Empty;
               
            }
            else
            {
                strMa_Dt_CbNv_Bv = drLookup["MultiSelectValue"].ToString();
                return false;
            }
            return true;
        }
        void btKet_Thuc_Ca_Click(object sender, EventArgs e)
        {
            if (btKet_Thuc_Ca.Text == "Kết thúc ca bảo vệ")
            {
                txtTinh_Hinh_Giao_Ca.Focus();
                
                txtTinh_Hinh_Nhan_Ca.Enabled = true;
                txtTinh_Hinh_Giao_Ca.Enabled = true;
                
                dteNgay_Ct.Enabled = true;
                cboCong.Enabled = true;
                cboCa.Enabled = true;

                btKet_Thuc_Ca.Text = "Lưu";
                btTao_Ca.Enabled = false;
                btNew.Enabled = false;
            }
            else if (btKet_Thuc_Ca.Text == "Lưu")
            {
                enuNew_Edit_Voucher = enuEdit.Edit;
                Save();

                btKet_Thuc_Ca.Text = "Kết thúc ca bảo vệ";
                btTao_Ca.Enabled = true;
                btNew.Enabled = true;
                txtTinh_Hinh_Nhan_Ca.Enabled = false;
                txtTinh_Hinh_Giao_Ca.Enabled = false;
                dteNgay_Ct.Enabled = false;
                cboCong.Enabled = false;
                cboCa.Enabled = false;
            }
        }
        //void dgvVTPT_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    drCurrent = ((DataRowView)bdsEditCt_VTPT.Current).Row;
        //    DataGridViewCell dgvCell = dgvVTPT.CurrentCell;
        //    string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            
        //    if (strColumnName == "EDIT")
        //    {
        //      //KIEM TRA DA RA CONG CHUA
        //        DataTable dtCheck = SQLExec.ExecuteReturnDt("SELECT * FROM R09VTPT_RVC WHERE LOAI_RVC = 'R' AND Stt = '"+ strStt +"'");
        //        if (dtCheck.Rows.Count > 0)
        //        {
        //            Common.MsgOk("Phiếu đã ra cổng không cho phép sửa!!!");
        //        }
        //        else
        //        {

        //            //Copy hang hien tai            
        //            if (bdsEditCt_VTPT.Position >= 0)
        //                Common.CopyDataRow(((DataRowView)bdsEditCt_VTPT.Current).Row, ref drCurrent);
        //            else
        //            {
        //                drCurrent = dtEditCt_VTPT.NewRow();
                       
        //            }
        //            frmVTPTVao frm = new frmVTPTVao();
        //            frm.Load("V", strStt, drCurrent["So_Ct"].ToString());

        //            // người dùng chọn chấp nhận
        //            if (frm.Is_Accept)
        //            {
        //                //drCurrent["So_Ct"] = frm.dtInheritVoucher.Rows[0]["So_Ct"];
        //                //drCurrent["Ten_Dt"] = frm.dtInheritVoucher.Rows[0]["Ten_Dt"];
        //                //drCurrent["Ngay_Vao"] = frm.dtInheritVoucher.Rows[0]["Ngay_Ct"];
        //                //drCurrent["So_Luong_Vao"] = Common.SumDCValue(frm.dtInheritVoucher, "So_Luong", "");
        //                //Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_VTPT.Current).Row);

        //                //foreach (DataRow dr in dtEditCt_VTPTCT.Select("So_Ct = '" + drCurrent["So_Ct"] + "'"))
        //                //    dtEditCt_VTPTCT.Rows.Remove(dr);

        //                FillData(strStt);
                        
                        
        //                bdsEditCt_VTPT.Position = bdsEditCt_VTPT.Find("SO_CT", drCurrent["SO_CT"]);

                 
        //            }
        //            else
        //                dtEditCt_VTPT.RejectChanges();
        //        }
        //    }
        //}
        void dgvXePKD_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //string strColumnName = dgvXePKD.Columns[e.ColumnIndex].Name;
            //drCurrent = ((DataRowView)bdsEditCt_XePKD.Current).Row;
            //if (strColumnName == "KIEM_TRA")
            //{
            //    double dbSo_Luong_PX = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT SUM(So_Luong) FROM R05CTNX WHERE So_LXH IN (select LEFT(T2.So_Ct,13) from R80PH_SCALE T1 JOIN R04CTSO T2 ON T1.Stt_Org = T2.Stt where T1.Stt = '"+ drCurrent["Stt_Org"] +"') " +
            //                                                                            "AND Stt NOT IN (SELECT Stt FROM R80PH WHERE Duyet_Huy = 1)"));
            //    double dbSo_Luong_BV = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT SUM(t1.So_Luong) FROM R09CT_RVC T1 JOIN R80PH_SCALE T2 ON T1.Stt_Org = T2.Stt  " +
            //                                    " JOIN (SELECT So_Ct, Stt FROM R04CTSO GROUP BY So_Ct, Stt) T3 ON T2.Stt_Org = T3.Stt " +
            //                                    " WHERE T1.Stt_Org <> '' AND LEFT(T3.So_Ct,13) IN (select LEFT(T2.So_Ct,13) from R80PH_SCALE T1 JOIN R04CTSO T2 ON T1.Stt_Org = T2.Stt where T1.Stt = '"+ drCurrent["Stt_Org"] +"')"));
            //    string strSo_LXH = SQLExec.ExecuteReturnValue("select LEFT(T2.So_Ct,13) from R80PH_SCALE T1 JOIN R04CTSO T2 ON T1.Stt_Org = T2.Stt where T1.Stt = '" + drCurrent["Stt_Org"] +"'").ToString();
            //    double dbSo_Luong_CL = dbSo_Luong_BV - dbSo_Luong_PX;
                
            //    Common.MsgOk("Số lượng phiếu xuất của xà lan " + drCurrent["So_Xa_Lan_Tau"] + " số LXH "+ strSo_LXH +" là  " + dbSo_Luong_PX + ", số lượng ghi nhận tại cổng BV là " + dbSo_Luong_BV + ", chênh lệch " + dbSo_Luong_CL + "");
            //}
        }
        void dgvXaLan_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvXaLan;
        }
        void dgvNhanVienSuCo_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvNhanVienSuCo;
        }
        void dgvXePKD_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvXePKD;
        }
        void dgvXeKhachLH_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvXeKhachLH;
        }
        void dgvXeNbCty_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvXeNbCty;
        }

        void dgvXeKhach_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvXeKhachChoHang;
        }
        void dgvNhanVienCa_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvNhanVienCa;
        }
        void dgvNhanVienCty_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvNhanVienCty;
        }
      
		private void Save()
		{
            string strSQLEXEC = string.Empty;
            Hashtable ht = new Hashtable();

            if (enuNew_Edit_Voucher == enuEdit.New)
            {
                if (cboCong.Text == "")
                {
                    Common.MsgCancel("Bạn phải chọn cổng làm việc");
                    return;
                }
                if (cboCa.Text == "")
                {
                    Common.MsgCancel("Bạn phải chọn ca làm việc");
                    return;
                }
                if (cboCong.Text != "" && cboCa.Text != "" && (DataTool.SQLCheckExist("R09PH_RVC", new string[] { "Ngay_Ct", "Cong", "Ca" }, new object[] { dteNgay_Ct.Text, cboCong.Text, cboCa.Text})))
                {
                    Common.MsgCancel("Cổng "+cboCong.Text+ " ca " + cboCa.Text + " ngày "+dteNgay_Ct.Text+" đã được tạo. Vui lòng kiểm tra lại dữ liệu !!!");
                    return;
                }
                
                ht.Add("STT", strStt);
                ht.Add("CA", cboCa.Text);
                ht.Add("NGAY_CT", dteNgay_Ct.Text);
                ht.Add("CONG", cboCong.Text);
                ht.Add("MA_DT_CBNV_LIST", strMa_Dt_CbNv_Bv);
                ht.Add("TINH_HINH_NHAN_CA", txtTinh_Hinh_Nhan_Ca.Text);
                ht.Add("CREATE_LOG", Common.GetCurrent_Log());
                ht.Add("MA_DATA", Element.sysMa_DvCs);

                strSQLEXEC = "INSERT INTO R09PH_RVC(Stt, Ngay_Ct, Ca, Cong, Tinh_Hinh_Nhan_Ca, Ma_Dt_CbNv_List, Create_Log, Ma_Data) " +
                                "VALUES (@Stt, @Ngay_Ct, @Ca, @Cong, @Tinh_Hinh_Nhan_Ca, @Ma_Dt_CbNv_List, @Create_Log, @Ma_Data)";
            }
            else
            {
                ht.Add("STT", strStt);
                ht.Add("CA", cboCa.Text);
                ht.Add("NGAY_CT", dteNgay_Ct.Text);
                ht.Add("CONG", cboCong.Text);
                ht.Add("TINH_HINH_NHAN_CA", txtTinh_Hinh_Nhan_Ca.Text);
                ht.Add("TINH_HINH_GIAO_CA", txtTinh_Hinh_Giao_Ca.Text);
                ht.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());

                strSQLEXEC = "UPDATE R09PH_RVC SET Tinh_Hinh_Nhan_Ca = @Tinh_Hinh_Nhan_Ca, Tinh_Hinh_Giao_Ca = @Tinh_Hinh_Giao_Ca, LastModify_Log = @LastModify_Log WHERE Stt = @Stt";
            }
			try
			{
                SQLExec.Execute(strSQLEXEC, ht, CommandType.Text);
				
                this.FillData(strStt);
			}
			catch (Exception ex)
			{
		    	MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
			}

			Common.MsgOk("Cập nhật thành công!");
		}
        
       
        void dgvSuCo_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvXeNbCty;
        }
        
     
       
        public override void Edit(enuEdit enuNew_Edit)
        {
            if (this.objActive == dgvNhanVienCty)
                this.Edit_NhanVienCty(enuNew_Edit);
            else if (this.objActive == dgvNhanVienSuCo)
                this.Edit_NhanVienSuCo(enuNew_Edit);
            else if (this.objActive == dgvXeNbCty)
                this.Edit_XeNbCty(enuNew_Edit);
            else if (this.objActive == dgvXeKhachChoHang)
                this.Edit_XeKhachChoHang(enuNew_Edit);
            else if (this.objActive == dgvXeKhachLH)
                this.Edit_XeKhachLH(enuNew_Edit);
            else if (this.objActive == dgvXePKD)
                this.Edit_XePKD(enuNew_Edit);
            else if (this.objActive == dgvNhanVienCa)
                this.Edit_NhanVienCa(enuNew_Edit);
            else if (this.objActive == dgvXaLan)
                this.Edit_XaLan(enuNew_Edit);
            
          
        }
        public override void Delete()
        {
            if (this.objActive == dgvNhanVienCty)
                this.Delete_NhanVienCty();
            else if (this.objActive == dgvNhanVienSuCo)
                this.Delete_NhanVienSuCo();
            else if (this.objActive == dgvXeNbCty)
                this.Delete_XeNbCty();
            else if (this.objActive == dgvXeKhachChoHang)
                this.Delete_XeKhachChoHang();
            else if (this.objActive == dgvXeKhachLH)
                this.Delete_XeKhachLH();
            else if (this.objActive == dgvXePKD)
                this.Delete_XePKD();
            else if (this.objActive == dgvXaLan)
                this.Delete_XaLan();

        }
        private void Delete_XaLan()
        {
            if (bdsEditCt_XaLan.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_XaLan.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09XALAN", drCurrent))
            {
                bdsEditCt_XaLan.RemoveAt(bdsEditCt_XaLan.Position);
                dtEditCt_XaLan.AcceptChanges();
            }
        }
        private void Delete_XePKD()
        {
            if (bdsEditCt_XePKD.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_XePKD.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09CT_RVC", drCurrent))
            {
                bdsEditCt_XePKD.RemoveAt(bdsEditCt_XePKD.Position);
                dtEditCt_XePKD.AcceptChanges();
            }
        }
        private void Delete_XeKhachLH()
        {
            if (bdsEditCt_XeKhachLH.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_XeKhachLH.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09CT_RVC", drCurrent))
            {
                bdsEditCt_XeKhachLH.RemoveAt(bdsEditCt_XeKhachLH.Position);
                dtEditCt_XeKhachLH.AcceptChanges();
            }
        }
        private void Delete_XeKhachChoHang()
        {
            if (bdsEditCt_XeKhachChoHang.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_XeKhachChoHang.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09CT_RVC", drCurrent))
            {
                bdsEditCt_XeKhachChoHang.RemoveAt(bdsEditCt_XeKhachChoHang.Position);
                dtEditCt_XeKhachChoHang.AcceptChanges();
            }
        }
        private void Delete_NhanVienSuCo()
        {
            if (bdsEditCt_NhanVienSuCo.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_NhanVienSuCo.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09CT_RVC", drCurrent))
            {
                bdsEditCt_NhanVienSuCo.RemoveAt(bdsEditCt_NhanVienSuCo.Position);
                dtEditCt_NhanVienSuCo.AcceptChanges();
            }
        }
        private void Delete_NhanVienCty()
        {
            if (bdsEditCt_NhanVienCty.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_NhanVienCty.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09CT_RVC", drCurrent))
            {
                bdsEditCt_NhanVienCty.RemoveAt(bdsEditCt_NhanVienCty.Position);
                dtEditCt_NhanVienCty.AcceptChanges();
            }
        }
        private void Delete_XeNbCty()
        {
            if (bdsEditCt_XeNbCty.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_XeNbCty.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09CT_RVC", drCurrent))
            {
                bdsEditCt_XeNbCty.RemoveAt(bdsEditCt_XeNbCty.Position);
                dtEditCt_XeNbCty.AcceptChanges();
            }
        }
        void btNew_Click(object sender, EventArgs e)
        {
            this.enuNew_Edit_Voucher = enuEdit.New;
            Edit(enuNew_Edit_Voucher);
           
        }
        void btEdit_Click(object sender, EventArgs e)
        {
            this.enuNew_Edit_Voucher = enuEdit.Edit;
            Edit(enuNew_Edit_Voucher);
        }
        void btCBNV_Click(object sender, EventArgs e)
        {
            frmGiayRaVaoCong frm = new frmGiayRaVaoCong();
            frm.Load();
        }
        //void btVTPTRa_Click(object sender, EventArgs e)
        //{
        //    frmVTPTVao frm = new frmVTPTVao();
        //    frm.Load("R",strStt,"");
        //    if (frm.Is_Accept)
        //    {
        //        FillData(strStt);

        //        bdsEditCt_VTPT.Position = bdsEditCt_VTPT.Find("SO_CT", drCurrent["SO_CT"]);
        //    }
        //    else
        //        dtEditCt_VTPT.RejectChanges();

        //}

        //void btVTPTVao_Click(object sender, EventArgs e)
        //{
          
        //    //Copy hang hien tai            
        //    if (bdsEditCt_VTPT.Position >= 0)
        //        Common.CopyDataRow(((DataRowView)bdsEditCt_VTPT.Current).Row, ref drCurrent);
        //    else
        //    {
        //        drCurrent = dtEditCt_VTPT.NewRow();
        //        //drCT = dtEditCt_VTPTCT.NewRow();
        //    }
        //    frmVTPTVao frm = new frmVTPTVao();
        //    frm.Load("V", strStt, "");

        //    // người dùng chọn chấp nhận
        //    if (frm.Is_Accept)
        //    {
        //        //drCurrent["So_Ct"] = frm.dtInheritVoucher.Rows[0]["So_Ct"];
        //        //drCurrent["Ten_Dt"] = frm.dtInheritVoucher.Rows[0]["Ten_Dt"];
        //        //drCurrent["Ngay_Vao"] = frm.dtInheritVoucher.Rows[0]["Ngay_Ct"];
        //        //drCurrent["So_Luong_Vao"] = Common.SumDCValue(frm.dtInheritVoucher, "So_Luong", "");
        //        //if (bdsEditCt_VTPT.Position >= 0)
        //        //{
        //        //    dtEditCt_VTPT.ImportRow(drCurrent);

        //        //    foreach (DataRow dr in frm.dtInheritVoucher.Rows)
        //        //        dtEditCt_VTPTCT.ImportRow(dr);
        //        //}
        //        //else
        //        //{

        //        //    DataRow drCT = dtEditCt_VTPTCT.NewRow();
        //        //    foreach (DataRow dr in frm.dtInheritVoucher.Rows)
        //        //    {
        //        //        drCT["Stt"] = dr["Stt"];
        //        //        drCT["Stt0"] = dr["Stt0"];
        //        //        drCT["Loai_RVC"] = dr["Loai_RVC"];
        //        //        drCT["Ngay_Ct"] = dr["Ngay_Ct"];
        //        //        drCT["Ten_Vt"] = dr["Ten_Vt"];
        //        //        drCT["So_Luong"] = dr["So_Luong"];
        //        //        drCT["So_Ct"] = dr["So_Ct"];
        //        //        drCT["Ten_Dt"] = dr["Ten_Dt"];
        //        //        drCT["Ghi_Chu"] = dr["Ghi_Chu"];
        //        //        dtEditCt_VTPTCT.Rows.Add(drCT);


        //        //    }
        //        //    dtEditCt_VTPTCT.AcceptChanges();

        //        //    bdsEditCt_VTPTCT.DataSource = dtEditCt_VTPTCT;

        //        //    dtEditCt_VTPT.Rows.Add(drCurrent);

        //        //}
        //        FillData(strStt);

        //        bdsEditCt_VTPT.Position = bdsEditCt_VTPT.Find("SO_CT", drCurrent["SO_CT"]);

        //        //dtEditCt_VTPT.AcceptChanges();
                
               
        //    }
        //    else
        //        dtEditCt_VTPT.RejectChanges();
        //}
        void btDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        void btPrint_Click(object sender, EventArgs e)
        {
            if(bdsEditCt_XeKhachChoHang.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsEditCt_XeKhachChoHang.Current).Row;
            Print(drCurrent["Stt"].ToString(), Convert.ToDouble(drCurrent["Ident00"]), Convert.ToBoolean(drCurrent["Is_Can"]));
        }
        private void Print(string strStt, double iIdent00, bool bCan)
        {
            //cập nhật Stt_Can
            if (bCan)
            {
                SQLExec.Execute("UPDATE R09CT_RVC SET Stt_Can = 'LC' + REPLACE(STR( "+ iIdent00 +",10),' ','0') WHERE Ident00 = " + iIdent00 + "");
            }
            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);
            ht.Add("IDENT00", iIdent00);

            DataTable dtLenhCan = SQLExec.ExecuteReturnDt("sp_PrintLenhCan", ht, CommandType.StoredProcedure);

            dtLenhCan.Columns.Add("REPORT_FILE", typeof(string));
            dtLenhCan.Columns.Add("NGAY_CT", typeof(DateTime));

            dtLenhCan.Rows[0]["Report_File"] = "rptLenh_Can";
            dtLenhCan.Rows[0]["Ngay_Ct"] = DateTime.Now;

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            frmPrint.Load(dtLenhCan.Rows[0], dtLenhCan, true, true);
        }
        private void Design()
        {
            string strReportFile = "rptLenh_Can";
            RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
            frm.Load(strReportFile);
        }
        private void Edit_NhanVienSuCo(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_NhanVienSuCo.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_NhanVienSuCo.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_NhanVienSuCo.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_NhanVienSuCo.NewRow();

            frmNhanVienRVC_Edit frmEdit = new frmNhanVienRVC_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt, "SUCO");

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];
                if (drCurrent["Ma_Dt_CbNv_Ql"].ToString() != "")
                {
                    DataRow drDmDtCbNvQL = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv_Ql"].ToString());
                    drCurrent["Ten_Dt_CbNv_QL"] = drDmDtCbNvQL["Ten_Dt"];
                }
                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_NhanVienSuCo.Position >= 0)
                        dtEditCt_NhanVienSuCo.ImportRow(drCurrent);
                    else
                        dtEditCt_NhanVienSuCo.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_NhanVienSuCo.Current).Row);
                }


                bdsEditCt_NhanVienSuCo.Position = bdsEditCt_NhanVienSuCo.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_NhanVienSuCo.AcceptChanges();
            }
            else
                dtEditCt_NhanVienSuCo.RejectChanges();
        }

        private void Edit_NhanVienCty(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_NhanVienCty.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_NhanVienCty.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_NhanVienCty.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_NhanVienCty.NewRow();

            frmNhanVienRVC_Edit frmEdit = new frmNhanVienRVC_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt, "BINHTHUONG");

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];

                DataRow drDmDtCbNvQL = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv_Ql"].ToString());
                drCurrent["Ten_Dt_CbNv_QL"] = drDmDtCbNvQL["Ten_Dt"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_NhanVienCty.Position >= 0)
                        dtEditCt_NhanVienCty.ImportRow(drCurrent);
                    else
                        dtEditCt_NhanVienCty.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_NhanVienCty.Current).Row);
                }


                bdsEditCt_NhanVienCty.Position = bdsEditCt_NhanVienCty.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_NhanVienCty.AcceptChanges();
            }
            else
                dtEditCt_NhanVienCty.RejectChanges();
        }

        private void Edit_XeNbCty(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_XeNbCty.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_XeNbCty.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_XeNbCty.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_XeNbCty.NewRow();

            frmXeNbRVC_Edit frmEdit = new frmXeNbRVC_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];

                DataRow drDmXe = DataTool.SQLGetDataRowByID("R81DMXE", "Ma_Xe", drCurrent["Ma_Xe"].ToString());
                drCurrent["Ten_Xe"] = drDmXe["Ten_Xe"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_XeNbCty.Position >= 0)
                        dtEditCt_XeNbCty.ImportRow(drCurrent);
                    else
                        dtEditCt_XeNbCty.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_XeNbCty.Current).Row);
                }


                bdsEditCt_XeNbCty.Position = bdsEditCt_XeNbCty.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_XeNbCty.AcceptChanges();
            }
            else
                dtEditCt_XeNbCty.RejectChanges();
        }

        private void Edit_XeKhachChoHang(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_XeKhachChoHang.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_XeKhachChoHang.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_XeKhachChoHang.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_XeKhachChoHang.NewRow();

            frmXeKhach_Edit frmEdit = new frmXeKhach_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt"].ToString());
                drCurrent["Ten_Dt"] = drDmDt["Ten_Dt"];

                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", drCurrent["Ma_Vt_Sp"].ToString());
                drCurrent["Ten_Vt_Sp"] = drDmVt["Ten_Vt"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_XeKhachChoHang.Position >= 0)
                        dtEditCt_XeKhachChoHang.ImportRow(drCurrent);
                    else
                        dtEditCt_XeKhachChoHang.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_XeKhachChoHang.Current).Row);
                }


                bdsEditCt_XeKhachChoHang.Position = bdsEditCt_XeKhachChoHang.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_XeKhachChoHang.AcceptChanges();
            }
            else
                dtEditCt_XeKhachChoHang.RejectChanges();
        }
        private void Edit_XeKhachLH(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_XeKhachLH.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_XeKhachLH.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_XeKhachLH.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_XeKhachLH.NewRow();

            frmXeKhachLH_Edit frmEdit = new frmXeKhachLH_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_XeKhachLH.Position >= 0)
                        dtEditCt_XeKhachLH.ImportRow(drCurrent);
                    else
                        dtEditCt_XeKhachLH.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_XeKhachLH.Current).Row);
                }


                bdsEditCt_XeKhachLH.Position = bdsEditCt_XeKhachLH.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_XeKhachLH.AcceptChanges();
            }
            else
                dtEditCt_XeKhachLH.RejectChanges();
        }
        private void Edit_NhanVienCa(enuEdit enuNew_Edit)
        {

            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Dt", "/", true, "Ma_Bp = 'PTCHC' AND Ma_Bp_Ct LIKE '%BV%' AND Ngay_Nghi_Lam = '19000101'", "");
            if (drLookup == null)
            {
                strMa_Dt_CbNv_Bv = string.Empty;
            }
            else
            {
                strMa_Dt_CbNv_Bv = drLookup["MultiSelectValue"].ToString();
                SQLExec.Execute("UPDATE R09PH_RVC SET Ma_Dt_CbNv_List = '"+ strMa_Dt_CbNv_Bv +"' WHERE Stt = '"+ strStt +"'");
                FillData(strStt);
            }
        }
        private void Edit_XePKD(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_XePKD.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_XePKD.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_XePKD.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_XePKD.NewRow();

            frmXePKD_Edit frmEdit = new frmXePKD_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt, Convert.ToDateTime(dteNgay_Ct.Text));

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if(drCurrent["Ma_Dt_CbNv"].ToString() != "" )
                { 
                    DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                    drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];
                }
                
                DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt"].ToString());
                drCurrent["Ten_Dt"] = drDmDt["Ten_Dt"];
               
                if (drCurrent["Ma_Xe"].ToString() != "")
                {
                    DataRow drDmXe = DataTool.SQLGetDataRowByID("R81DMXE", "Ma_Xe", drCurrent["Ma_Xe"].ToString());
                    drCurrent["Ten_Xe"] = drDmXe["Ten_Xe"];
                }
               
                if (drCurrent["Loai_Sp"].ToString() == "P")
                    drCurrent["Ten_Sp"] = "Phôi thép";
                else if (drCurrent["Loai_Sp"].ToString() == "T")
                    drCurrent["Ten_Sp"] = "Thép cán";

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_XePKD.Position >= 0)
                        dtEditCt_XePKD.ImportRow(drCurrent);
                    else
                        dtEditCt_XePKD.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_XePKD.Current).Row);
                }


                bdsEditCt_XePKD.Position = bdsEditCt_XePKD.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_XePKD.AcceptChanges();
            }
            else
                dtEditCt_XePKD.RejectChanges();
        }


        private void Edit_XaLan(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_XaLan.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_XaLan.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_XaLan.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_XaLan.NewRow();
            
            drCurrent["So_Luong_PXK"] = 0;
            drCurrent["So_Luong_BVE"] = 0;
            drCurrent["Chenh_Lech"] = 0;
            
            frmXaLan_Edit frmEdit = new frmXaLan_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsEditCt_XaLan.Position >= 0)
                        dtEditCt_XaLan.ImportRow(drCurrent);
                    else
                        dtEditCt_XaLan.Rows.Add(drCurrent);

                    
                    //bdsEditCt_XaLan.Position = bdsEditCt_XaLan.Find("IDENT00", drCurrent["IDENT00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_XaLan.Current).Row);
                }
                bdsEditCt_XaLan.Sort = "Ident00 DESC";
                bdsEditCt_XaLan.Position = 0;
               
                
                dtEditCt_XaLan.AcceptChanges();
            }
            else
                dtEditCt_XaLan.RejectChanges();
        }
       
        
        
		#region Event
		
		void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

         
            bdsEditCt.EndEdit();//Cap nhat lai DataSource
		}

		void btRefresh_Click(object sender, EventArgs e)
		{
            strStt_New = string.Empty;

            Hashtable ht = new Hashtable();

            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            //ht.Add("CONG", cboCong_Filter.Text);
        
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLRAVAOCONG", ht, CommandType.StoredProcedure);

            dtEditPh = dsVoucher.Tables[0];
            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }

            dtEditCt_XaLan = dsVoucher.Tables[8];
            bdsEditCt_XaLan.DataSource = dtEditCt_XaLan;
            dgvXaLan.DataSource = bdsEditCt_XaLan;

            LoadCombo();
           // foreach (DataGridViewRow dgvr in dgvNhanVienCty.Rows)
           // {
           //     if (dgvr.Cells["Gio_Vao"].Value.ToString() != "")
           //         dgvr.Cells["Gio_Vao"].Value = dgvr.Cells["Gio_Vao"].Value.ToString().Replace("SA", "");
           // }
           //dgvNhanVienCty.Refresh();
		}

		void btPrevious_Click(object sender, EventArgs e)
		{
            if (bdsEditPh.Position < 0)
                return;

            this.bdsEditPh.MovePrevious();
            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboCong_Filter.SelectedValue != null)
                this.cboCong_Filter.SelectedValue = this.strStt;
		}

		void btLast_Click(object sender, EventArgs e)
		{
            if (bdsEditPh.Position < 0)
                return;

            this.bdsEditPh.MoveLast();
            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboCong_Filter.SelectedValue != null)
                this.cboCong_Filter.SelectedValue = this.strStt;
		}

		void btNext_Click(object sender, EventArgs e)
		{
            if (bdsEditPh.Position < 0)
                return;

            if (this.bdsEditPh.Position + 1 < this.bdsEditPh.Count)
            {
                this.bdsEditPh.MoveNext();
                this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

                if (cboCong_Filter.SelectedValue != null)
                    this.cboCong_Filter.SelectedValue = this.strStt;
            }
		}

        void btFirst_Click(object sender, EventArgs e)
        {
            if (bdsEditPh.Position < 0)
                return;

            this.bdsEditPh.MoveFirst();

            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboCong_Filter.SelectedValue != null)
                this.cboCong_Filter.SelectedValue = this.strStt;

        }

		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
            //switch (e.KeyCode)
            //{
            //    case Keys.F8:

            //        if (dgvEditCt.Focused == false)
            //            return;

            //        if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            //            return;

            //        drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            //        drCurrent["Deleted"] = !((bool)drCurrent["Deleted"]);

            //        if ((bool)drCurrent["Deleted"] == true)
            //        {
            //            Font font = new Font(dgvEditCt.Font.FontFamily, dgvEditCt.Font.Size, FontStyle.Strikeout);
            //            dgvEditCt.CurrentRow.DefaultCellStyle.Font = font;
            //        }
            //        else
            //        {
            //            dgvEditCt.CurrentRow.DefaultCellStyle.Font = dgvEditCt.Font;
            //        }
            //        break;
            //}
		}
        void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

         
        }
        void cboCong_Filter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCong_Filter.SelectedValue != null)
            {
                if (cboCong_Filter.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    this.strStt = cboCong_Filter.SelectedValue == null ? string.Empty : cboCong_Filter.SelectedValue.ToString();
                    this.FillData_Voucher_Ph();
                }
            }
        }
        //void bdsEditCt_VTPT_PositionChanged(object sender, EventArgs e)
        //{
        //    if (((DataRowView)bdsEditCt_VTPT.Current) != null)
        //    {
        //        drCurrent = ((DataRowView)bdsEditCt_VTPT.Current).Row;
        //        bdsEditCt_VTPTCT.Filter = "So_Ct = '" + drCurrent["So_Ct"] + "'";
        //    }
        //}
		#endregion

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
				return;

			switch (e.KeyCode)
			{
				case Keys.F9:
					this.btRefresh_Click(null, null);
					return;

               
				case Keys.F12:
					if (e.Modifiers == Keys.Control)
						base.OnKeyDown(e);
				
					return;

			    
			}

			base.OnKeyDown(e);
		}
        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void btUpdate_Click(object sender, EventArgs e)
        {
            frmUpdateRVC frm = new frmUpdateRVC();
            frm.Load(cboCong.Text);
            
            if (frm.is_Close)
                FillData(strStt);
        }
        void KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
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
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin)
			{
                //if (!Common.CheckPermission("ACCESS_FILTER_DT_TCB", enuPermission_Type.Allow_Access))
                //    dteNgay_Ct1.Enabled = dteNgay_Ct2.Enabled = false;

                //this.btEdit.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
			}

		}

       

       
        

	}
}
