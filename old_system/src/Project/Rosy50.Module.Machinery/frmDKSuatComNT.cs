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

namespace RosyModule.Machinery
{
	public partial class frmDKSuatComNT : RosySystem.Customize.frmView
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
        string strStt = string.Empty;

        

        private DateTime dteNgay_Ct1;
        private DateTime dteNgay_Ct2;
        public frmDKSuatComNT()
		{
			InitializeComponent();

            bdsDGBPCT.PositionChanged += new EventHandler(bdsDGBPCT_PositionChanged);
          
            //dteNgay_Cham_Cong.LostFocus += new EventHandler(dteNgay_Cham_Cong_LostFocus);


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
         
            


            this.ShowDialog();
		}

        public void Load(DateTime dteNgay_Ct1, DateTime dteNgay_Ct2, string strStt)
        {
            this.dteNgay_Ct1 = dteNgay_Ct1;
            this.dteNgay_Ct2 = dteNgay_Ct2;
            this.strStt = strStt;
            //dteNgay_Cham_Cong.Text = Library.DateToStr(dteNgay_Ct1);

            this.Build();
            this.FillData();
         
           

            this.ShowDialog();
        }
		private void Build()
		{

            //dteNgay_Cham_Cong.Text = Library.DateToStr(DateTime.Now);

            dgvDGBPCT.ReadOnly = true;
            dgvDGBPCT.strZone = "DKSUATANNT1";
            dgvDGBPCT.Dock = DockStyle.Fill;
           

            dgvGiaDGBPCT.ReadOnly = true;
            dgvGiaDGBPCT.strZone = "DKSUATANNT2";
            dgvGiaDGBPCT.Dock = DockStyle.Fill;

          

            this.panel_ADD.Controls.Add(dgvDGBPCT);
            this.panel_REC.Controls.Add(dgvGiaDGBPCT);
          


            dgvDGBPCT.BuildGridView();
            dgvGiaDGBPCT.BuildGridView();
            dgvLich.BuildGridView();

            //dgvLich.ReadOnly = false;
            dgvDGBPCT.ReadOnly = false;


            foreach (DataGridViewColumn dgvc in dgvDGBPCT.Columns)
            {
                dgvc.ReadOnly = true;
               
            }
            if (dgvDGBPCT.Columns.Contains("CHON"))
                dgvDGBPCT.Columns["CHON"].ReadOnly = false;

		}
       
		private void FillData()
		{
            string strSQLExec = string.Empty;

            Hashtable ht = new Hashtable();
           
            ht.Add("STT", strStt);
          
            dsDGBPCT = SQLExec.ExecuteReturnDs("sp_GetDLDkSuatAnNT", ht, CommandType.StoredProcedure);

            dtDGBPCT = dsDGBPCT.Tables[0];
            bdsDGBPCT.DataSource = dtDGBPCT;
            dgvDGBPCT.DataSource = bdsDGBPCT;

            dtGiaDGBPCT = dsDGBPCT.Tables[1];
            bdsGiaDGBPCT.DataSource = dtGiaDGBPCT;
            dgvGiaDGBPCT.DataSource = bdsGiaDGBPCT;

           
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
           
		}

       

        void bdsDGBPCT_PositionChanged(object sender, EventArgs e)
        {
           

        }
        void btSua_Click(object sender, EventArgs e)
        {
            //frmSuaCongCom frm = new frmSuaCongCom();
            //frm.Load(cboMa_Bp.Text, cboMa_Bp_Ct.Text, Convert.ToDateTime(dteNgay_Cham_Cong.Text));
        }
        void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                //foreach (DataRow dr in dtGiaDGBPCT.Rows)
                //{

                //    DataRow drEdit = dtGiaDGBPCT.NewRow(); ;

                //    DataTool.CopyDataRow(dr, drEdit);

                //    drEdit["Create_Log"] = Common.GetCurrent_Log();
                    
                //}
                //LƯU BẰNG TVP
                Voucher.UpdataDKSuatAnNT(dtGiaDGBPCT, strStt);

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
            drCt["Ten_Nt"] = drCurrent["Ten_Nt"];
            drCt["Ngay_Cham_Cong"] = drCurrent["Ngay_Cham_Cong"];

            dtDGBPCT.Rows.Add(drCt);
            dtDGBPCT.AcceptChanges();

            dtGiaDGBPCT.Rows.Remove(drCurrent);
        }

        void btAdd_Click(object sender, EventArgs e)
        {
           

            foreach (DataRow dr in dtDGBPCT.Select("Chon = 1"))
            {
                DataRow drCt = dtGiaDGBPCT.NewRow();
                // kiểm tra giá trị trùng
                if (DataTool.SQLCheckExist("R10DSCBNVTHEOCA", new string[] { "Ma_Dt_CbNv", "Ngay_Cham_Cong", "Ten_Nt" }, new object[] { dr["Ma_Dt_CbNv"], dr["Ngay_Cham_Cong"], dr["Ten_Nt"] }))
                {
                    Common.MsgOk("" + dr["Ten_Nt"] + " đã có thông tin đăng ký suất ăn ngày " + dr["Ngay_Cham_Cong"] + " vui lòng không chọn trùng, phải xóa dữ liệu trước khi điều chỉnh!!!");
                    dr["Chon"] = false;
                    continue;
                }
                else
                {
                    drCt["Ten_Nt"] = dr["Ten_Nt"];
                    drCt["Ma_Dt_CbNv"] = dr["Ma_Dt_CbNv"];
                    drCt["Ngay_Cham_Cong"] = dr["Ngay_Cham_Cong"];
                 
                    drCt["An_Sang"] = numAn_Sang.Text;
                    drCt["An_Trua"] = numAn_Trua.Text;
                    drCt["An_Chieu"] = numAn_Chieu.Text;
                    drCt["An_Khuya"] = numAn_Khuya.Text;
                    
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

      
       
     
        //void dteNgay_Cham_Cong_LostFocus(object sender, EventArgs e)
        //{
        //    FillData();
        //}
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
