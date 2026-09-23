using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;
using System.Collections;
using System.Data.SqlClient;
using System.Net;

namespace RosyModule.HRM
{
    public partial class frmXeCong : RosySystem.Customize.frmView
	{
		#region Declare

        DataTable dtSo_Xe_LXH;
        BindingSource bdsSo_Xe_LXH = new BindingSource();

        DataTable dtSo_Xe_LayHang;
        BindingSource bdsSo_Xe_LayHang = new BindingSource();

		#endregion

		

        public frmXeCong()
		{
			InitializeComponent();


            timer1.Tick += new EventHandler(timer1_Tick);

            dgvSo_Xe_LXH.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvSo_Xe_LXH_CellFormatting);
		}

       

        void timer1_Tick(object sender, EventArgs e)
        {
           
            FillData();
            Common.ShowStatus("Quét dữ liệu lúc : " + Voucher.GetDateServer() + "");
           

            
        }

        

		#region Method

		public void Load()
		{


            Build();
            FillData();
            this.BindingLanguage();
            DataGridView_Language();
            //test
         
            //Hashtable ht = new Hashtable();
            //ht.Add("MEMBER_ID", "bangvtk");
            //DataSet dsSend = SQLExec.ExecuteReturnDs("dbo.sp_GetListDuyet", ht, CommandType.StoredProcedure);
            //Voucher.OpenOutLook_ReminderDuyet("cuongpn@thepmiennam.com.vn", "Đây là email tự động, Nhắc các chứng từ cần duyệt", "Kính gửi anh, các chứng từ đang chờ anh duyệt", dsSend.Tables[0], dsSend.Tables[1], false);

            this.Show();
		}

        

		void Build()
		{
            dgvSo_Xe_LXH.strZone = "SOXELXH";
            dgvSo_Xe_LXH.BuildGridView();

            dgvSo_Xe_LXH.ReadOnly = true;

            dgvSo_Xe_LayHang.strZone = "SOXELAYHANG";
            dgvSo_Xe_LayHang.BuildGridView();

            dgvSo_Xe_LayHang.ReadOnly = true;

            dgvSo_Xe_LXH.RowTemplate.Height = 32;
            dgvSo_Xe_LayHang.RowTemplate.Height = 32;
		}

		void FillData()
		{
            

            DataSet ds = SQLExec.ExecuteReturnDs("sp_GetSoXeLXH");

            dtSo_Xe_LXH = ds.Tables[0];
            bdsSo_Xe_LXH.DataSource = dtSo_Xe_LXH;
            dgvSo_Xe_LXH.DataSource = bdsSo_Xe_LXH;
            
            bdsSo_Xe_LXH.Position = dtSo_Xe_LXH.Rows.Count;

            dtSo_Xe_LayHang = ds.Tables[1];
            bdsSo_Xe_LayHang.DataSource = dtSo_Xe_LayHang;
            dgvSo_Xe_LayHang.DataSource = bdsSo_Xe_LayHang;
            bdsSo_Xe_LayHang.Position = dtSo_Xe_LayHang.Rows.Count;


		}
     
       
		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		#region Event
        private void DataGridView_Language()
        {


            if (dgvSo_Xe_LXH.Columns.Contains("Stt_Sx"))
                dgvSo_Xe_LXH.Columns["Stt_Sx"].HeaderText = "STT";
            if (dgvSo_Xe_LXH.Columns.Contains("TEN_DT_VC"))
                dgvSo_Xe_LXH.Columns["TEN_DT_VC"].HeaderText = "Tên lái xe / Người nhận hàng";
            if (dgvSo_Xe_LXH.Columns.Contains("Create_"))
                dgvSo_Xe_LXH.Columns["Create_"].HeaderText = "Giờ tạo LXH";

            if (dgvSo_Xe_LayHang.Columns.Contains("Ten_Lx_Khach"))
                dgvSo_Xe_LayHang.Columns["Ten_Lx_Khach"].HeaderText = "Tên lái xe / Người nhận hàng";
            if (dgvSo_Xe_LayHang.Columns.Contains("ID_CMND"))
                dgvSo_Xe_LayHang.Columns["ID_CMND"].HeaderText = "ID người nhận hàng";
            if (dgvSo_Xe_LayHang.Columns.Contains("Create_"))
                dgvSo_Xe_LayHang.Columns["Create_"].HeaderText = "Giờ vào cổng";
        }
        void dgvSo_Xe_LXH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

           
        }


		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}

		#endregion

	}
}
