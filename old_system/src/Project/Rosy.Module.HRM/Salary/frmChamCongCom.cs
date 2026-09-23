using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;

namespace RosyModule.Salary
{
	public partial class frmChamCongCom : RosySystem.Customize.frmView
	{
        public bool Is_Accept = false;
        private DataSet dsDGBPCT;
        private rsTreeList tlDgBpCt = new rsTreeList();
		private DataTable dtDGBPCT;
		private BindingSource bdsDGBPCT = new BindingSource();
		private rsDataGridView dgvDGBPCT = new rsDataGridView();

        private DataTable dtGiaDGBPCT;
        private BindingSource bdsGiaDGBPCT = new BindingSource();
        private rsDataGridView dgvGiaDGBPCT = new rsDataGridView();

        private DataTable dtLich;
        private BindingSource bdsLich = new BindingSource();
        private rsDataGridView dgvLich = new rsDataGridView();

        private DataRow drCurrent;
        string strMa_Bp = string.Empty;

        DataSet dsBp; DataTable dtDmBp; DataTable dtDmBpCt;
        
        private DateTime dteNgay_Ct1;
        private DateTime dteNgay_Ct2;
        public frmChamCongCom()
		{
			InitializeComponent();

            bdsDGBPCT.PositionChanged += new EventHandler(bdsDGBPCT_PositionChanged);
            cboMa_Bp.TextChanged += new EventHandler(cboMa_Bp_TextChanged);
            cboMa_Bp_Ct.TextChanged += new EventHandler(cboMa_Bp_Ct_TextChanged);
            cboLoai_CC.TextChanged += new EventHandler(cboLoai_CC_TextChanged);
            dteNgay_Cham_Cong.LostFocus += new EventHandler(dteNgay_Cham_Cong_LostFocus);


            btThoat.Click += new EventHandler(btThoat_Click);
            btAdd.Click += new EventHandler(btAdd_Click);
            btRe.Click += new EventHandler(btRe_Click);
            btSave.Click += new EventHandler(btSave_Click);
            btSua.Click += new EventHandler(btSua_Click);

            this.KeyDown += new KeyEventHandler(frmChamCongCom_KeyDown);
		}

       

       
		public override void Load()
		{
           
			this.Build();
			this.FillData();
         
            //LoadCombo();


            this.ShowDialog();
		}

        public void Load(DateTime dteNgay_Ct1, DateTime dteNgay_Ct2, string strMa_Bp, string strMa_Bp_Ct)
        {
            this.dteNgay_Ct1 = dteNgay_Ct1;
            this.dteNgay_Ct2 = dteNgay_Ct2;
            dteNgay_Cham_Cong.Text = Library.DateToStr(Voucher.GetDate_Server());

            cboMa_Bp.Text = strMa_Bp;
            cboMa_Bp_Ct.Text = strMa_Bp_Ct;

            

            this.Build();
            this.FillData();
         
            LoadCombo();

            this.ShowDialog();
        }
		private void Build()
		{

            dteNgay_Cham_Cong.Text = Library.DateToStr(DateTime.Now);

            dgvDGBPCT.ReadOnly = true;
            dgvDGBPCT.strZone = "CHAMCONGSX1";
            dgvDGBPCT.Dock = DockStyle.Fill;
           

            dgvGiaDGBPCT.ReadOnly = true;
            dgvGiaDGBPCT.strZone = "CHAMCONGSX3";
            dgvGiaDGBPCT.Dock = DockStyle.Fill;

            //dgvLich.ReadOnly = true;
            //dgvLich.strZone = "CHAMCONGCOM";
            //dgvLich.Dock = DockStyle.Fill;
            //dgvLich.bFilter = false;

            this.panel_ADD.Controls.Add(dgvDGBPCT);
            this.panel_REC.Controls.Add(dgvGiaDGBPCT);
            //this.panel_Lich.Controls.Add(dgvLich);


            dgvDGBPCT.BuildGridView();
            dgvGiaDGBPCT.BuildGridView();
            dgvLich.BuildGridView();

            //dgvLich.ReadOnly = false;
            dgvDGBPCT.ReadOnly = false;


            foreach (DataGridViewColumn dgvc in dgvDGBPCT.Columns)
            {
                dgvc.ReadOnly = true;
                if (dgvc.Name == "NGAY_AP")
                    dgvc.Visible = false;
                //if (dgvc.Name == "LOAI_CC")
                //    dgvc.Visible = false;
            }
            if (dgvDGBPCT.Columns.Contains("CHON"))
                dgvDGBPCT.Columns["CHON"].ReadOnly = false;

            //Remover DataGridView Filter
            //string strColumnList = "Ca,Ngay_01,Ngay_02,Ngay_03,Ngay_04,Ngay_05,Ngay_06,Ngay_07,Ngay_08,Ngay_09,Ngay_10,Ngay_11,Ngay_12,Ngay_13,Ngay_14,Ngay_15,Ngay_16,Ngay_17,Ngay_18,Ngay_19,Ngay_20,Ngay_21,Ngay_22,Ngay_23,Ngay_24,Ngay_25,Ngay_26,Ngay_27,Ngay_28,Ngay_29,Ngay_30,Ngay_31";
            //foreach (string strColumn in strColumnList.Split(','))
            //{
            //    if (dgvLich.Columns.Contains(strColumn))

            //        ((dgvAutoFilterColumnHeaderCell)dgvLich.Columns[strColumn].HeaderCell).bFilteringEnabled = false;

            //}
           
		}
        private void LoadCombo()
        {
            DataTable dtLoaiCC = Voucher.GetTinhTrangCong();
            
            cboLoai_CC.lstItem.BuildListView("Ma_CC:100,Ten_CC:200");
            cboLoai_CC.lstItem.DataSource = dtLoaiCC;
            cboLoai_CC.lstItem.Size = new Size(400, cboLoai_CC.lstItem.Items.Count * 20);
            cboLoai_CC.lstItem.GridLines = true;
            //MABP

            //Gắn Ma_Bp vào ComboBox
            dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", CommandType.StoredProcedure);
            dtDmBp = dsBp.Tables[0];
            strMa_Bp = SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt = (SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE MEMBER_ID = '" + Element.sysUser_Id + "')").ToString();

            if (!Element.sysIs_Admin & !Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) & !Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access) & !Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access))
            {
                cboMa_Bp.Enabled = false;
                Hashtable ht = new Hashtable();
                ht.Add("MA_BP", strMa_Bp);
                dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong",ht, CommandType.StoredProcedure);
                dtDmBp = dsBp.Tables[0];
                DataRow dr = dtDmBp.Rows[0];
                cboMa_Bp.Text = dr["Ma_Bp"].ToString();

                if (cboMa_Bp.Text != "")
                {

                    dtDmBpCt = dsBp.Tables[1];
                    cboMa_Bp_Ct.lstItem.BuildListView("Ma_Bp_Ct:100,Ten_Bp_Ct:200");
                    cboMa_Bp_Ct.lstItem.DataSource = dtDmBpCt;
                    cboMa_Bp_Ct.lstItem.Size = new Size(500, 600);
                    cboMa_Bp_Ct.lstItem.GridLines = true;
                }
               
            }

            cboMa_Bp.lstItem.BuildListView("Ma_Bp:100,Ten_Bp:200");
            cboMa_Bp.lstItem.DataSource = dtDmBp;
            cboMa_Bp.lstItem.Size = new Size(400, cboMa_Bp.lstItem.Items.Count * 15);
            cboMa_Bp.lstItem.GridLines = true;

           

        }
		private void FillData()
		{
            string strSQLExec = string.Empty;

            Hashtable ht = new Hashtable();
            ht.Add("MA_BP", cboMa_Bp.Text);
            ht.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
            ht.Add("SX_CA", string.Empty);
            ht.Add("NGAY_CHAM_CONG", dteNgay_Cham_Cong.Text);
            ht.Add("NGAY_CT1", this.dteNgay_Ct1);
            ht.Add("NGAY_CT2", this.dteNgay_Ct2);
            ht.Add("USER_LOGIN", Element.sysUser_Id);
            dsDGBPCT = SQLExec.ExecuteReturnDs("sp_GetChamCongSXCom", ht, CommandType.StoredProcedure);

            dtDGBPCT = dsDGBPCT.Tables[0];
            bdsDGBPCT.DataSource = dtDGBPCT;
            dgvDGBPCT.DataSource = bdsDGBPCT;

            dtGiaDGBPCT = dsDGBPCT.Tables[1];
            bdsGiaDGBPCT.DataSource = dtGiaDGBPCT;
            dgvGiaDGBPCT.DataSource = bdsGiaDGBPCT;

           
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
            //return;
			
            if (bdsGiaDGBPCT.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

            if (bdsGiaDGBPCT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsGiaDGBPCT.Current).Row, ref drCurrent);
			else
				drCurrent = dtGiaDGBPCT.NewRow();

            frmDGBPCT_Edit frmEdit = new frmDGBPCT_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsGiaDGBPCT.Position >= 0)
						dtGiaDGBPCT.ImportRow(drCurrent);
					else
						dtGiaDGBPCT.Rows.Add(drCurrent);

					bdsGiaDGBPCT.Position = bdsGiaDGBPCT.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsGiaDGBPCT.Current).Row);
				}

				dtGiaDGBPCT.AcceptChanges();
			}
			else
				dtGiaDGBPCT.RejectChanges();
		}

        //public override void Delete()
        //{
        //    if (bdsGiaDGBPCT.Position < 0)
        //        return;

        //    DataRow drCurrent = ((DataRowView)bdsGiaDGBPCT.Current).Row;

        //    if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
        //        return;

        //    if (DataTool.SQLDelete("R10DGBPCT", drCurrent))
        //    {
        //        bdsGiaDGBPCT.RemoveAt(bdsGiaDGBPCT.Position);
        //        dtGiaDGBPCT.AcceptChanges();
        //    }
        //}

        void bdsDGBPCT_PositionChanged(object sender, EventArgs e)
        {
            //drCurrent = ((DataRowView)bdsDGBPCT.Current).Row;
            //bdsGiaDGBPCT.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";

        }
        void btSua_Click(object sender, EventArgs e)
        {
            frmSuaCongCom frm = new frmSuaCongCom();
            frm.Load(cboMa_Bp.Text, cboMa_Bp_Ct.Text, Convert.ToDateTime(dteNgay_Cham_Cong.Text));
        }
        void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow dr in dtGiaDGBPCT.Rows)
                {

                    DataRow drEdit = dtGiaDGBPCT.NewRow(); ;

                    DataTool.CopyDataRow(dr, drEdit);

                    drEdit["Create_Log"] = Common.GetCurrent_Log();
                   
                    if (!DataTool.SQLCheckExist("R10DSCBNVTHEOCA", new string[] { "Ma_Dt_CbNv", "Ngay_Cham_Cong" }, new object[] { dr["Ma_Dt_CbNv"], dteNgay_Cham_Cong.Text }))
                        DataTool.SQLUpdate(enuEdit.New, "R10DSCBNVTHEOCA", ref drEdit);

                   

                }
                if (!Common.MsgYes_No("Đã lưu xong bạn có muốn đăng ký tiếp không ?", "Y"))
                {
                    Is_Accept = true;
                    this.Close();
                }
                
                    
            }
            catch
            {
                Common.MsgOk("Có lỗi xảy ra. Vui lòng gọi PCNTT để được hỗ trợ!!!");
            }

        }

        void btRe_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsGiaDGBPCT.Current).Row;

            DataRow drCt = dtDGBPCT.NewRow();

            drCt["Ma_Dt_CbNv"] = drCurrent["Ma_Dt_CbNv"];
            drCt["Ten_Dt_CbNv"] = drCurrent["Ten_Dt_CbNv"];


            dtDGBPCT.Rows.Add(drCt);
            dtDGBPCT.AcceptChanges();

            dtGiaDGBPCT.Rows.Remove(drCurrent);
        }

        void btAdd_Click(object sender, EventArgs e)
        {
            if (cboLoai_CC.Text == "")
            { Common.MsgOk("Bạn chưa chọn mã chấm công !!!"); cboLoai_CC.Focus(); return; }

            foreach (DataRow dr in dtDGBPCT.Select("Chon = 1"))
            {
                DataRow drCt = dtGiaDGBPCT.NewRow();
                // kiểm tra giá trị trùng
                if (DataTool.SQLCheckExist("R10DSCBNVTHEOCA", new string[] { "Ma_Dt_CbNv", "Ngay_Cham_Cong" }, new object[] { dr["Ma_Dt_CbNv"], dteNgay_Cham_Cong.Text }))
                {
                    Common.MsgOk("Nhân viên " + dr["Ten_Dt_CbNv"] + " đã có thông tin ca ngày " + dteNgay_Cham_Cong.Text + " vui lòng không chọn trùng, phải xóa dữ liệu trước khi điều chỉnh!!!");
                    dr["Chon"] = false;
                    continue;
                }
                else
                {
                    drCt["Ma_Dt_CbNv"] = dr["Ma_Dt_CbNv"];
                    drCt["Ten_Dt_CbNv"] = dr["Ten_Dt_CbNv"];
                    drCt["Ngay_Cham_Cong"] = dteNgay_Cham_Cong.Text;
                    drCt["Loai_CC"] = cboLoai_CC.Text;
                    drCt["Ma_Bp_Ct"] = dr["Ma_Bp_Ct_Cur"];

                    
                    drCt["An_Sang"] = numAn_Sang.Text;
                    drCt["An_Trua"] = numAn_Trua.Text;
                    drCt["An_Chieu"] = numAn_Chieu.Text;
                    drCt["An_Khuya"] = numAn_Khuya.Text;
                    drCt["An_Khuya_Sau"] = numAn_Khuya_Sau.Text;
                    drCt["An_Sang_Sau"] = numAn_Sang_Sau.Text;
                    drCt["Ghi_Chu"] = txtGhi_Chu.Text;
                    dtGiaDGBPCT.Rows.Add(drCt);
                    dtGiaDGBPCT.AcceptChanges();

                    dtDGBPCT.Rows.Remove(dr);
                }
            }
        }

        void btThoat_Click(object sender, EventArgs e)
        {
            Is_Accept = true;
            this.Close();
        }

        void cboMa_Bp_Ct_TextChanged(object sender, EventArgs e)
        {
            FillData();
        }
        void cboLoai_CC_TextChanged(object sender, EventArgs e)
        {
            DataRow drDmTTCCong = DataTool.SQLGetDataRowByID("R81DmTTCCong", "Ma_CC", cboLoai_CC.Text);
            if (drDmTTCCong != null)
            {
                //numAn_Sang_Truoc.Value = Convert.ToDouble(drDmTTCCong["An_Sang_Truoc"]);
                numAn_Sang.Value = Convert.ToDouble(drDmTTCCong["An_Sang"]);
                numAn_Trua.Value = Convert.ToDouble(drDmTTCCong["An_Trua"]);
                numAn_Chieu.Value = Convert.ToDouble(drDmTTCCong["An_Chieu"]);
                numAn_Khuya.Value = Convert.ToDouble(drDmTTCCong["An_Khuya"]);
                numAn_Khuya_Sau.Value = Convert.ToDouble(drDmTTCCong["An_Khuya_Sau"]);
                numAn_Sang_Sau.Value = Convert.ToDouble(drDmTTCCong["An_Sang_Sau"]);
            }
        }
        void cboMa_Bp_TextChanged(object sender, EventArgs e)
        {
            if (cboMa_Bp.lviItem != null)
                lbtTen_Bp.Text = cboMa_Bp.lviItem.SubItems["Ten_Bp"].Text;

            if (cboMa_Bp.Text == string.Empty)
                return;
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("MA_BP", cboMa_Bp.Text);
                dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", ht, CommandType.StoredProcedure);
                dtDmBpCt = dsBp.Tables[1];
                cboMa_Bp_Ct.lstItem.BuildListView("Ma_Bp_Ct:100,Ten_Bp_Ct:200");
                cboMa_Bp_Ct.lstItem.DataSource = dtDmBpCt;
                //cboMa_Bp_Ct.lstItem.Size = new Size(500, cboMa_Bp_Ct.lstItem.Items.Count * 15);
                cboMa_Bp_Ct.lstItem.Size = new Size(500,600);
                cboMa_Bp_Ct.lstItem.GridLines = true;

            }

            FillData();
        }
        void dteNgay_Cham_Cong_LostFocus(object sender, EventArgs e)
        {
            FillData();
        }
        void frmChamCongCom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {

                for (int i = 0; i < dtDGBPCT.Rows.Count; i++)
                {
                    dtDGBPCT.Rows[i]["CHON"] = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.U)
            {

                for (int i = 0; i < dtDGBPCT.Rows.Count; i++)
                {
                    dtDGBPCT.Rows[i]["CHON"] = false;
                }
            }
        }
        //private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        //{

        //}
	}
}
