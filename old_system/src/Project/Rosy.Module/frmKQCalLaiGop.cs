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


namespace RosyModule
{
	public partial class frmKQCalLaiGop : RosySystem.Customize.frmView
	{
		#region Declare
        //private rsDataGridView dgvPhanHoiKHVT= new rsDataGridView();

		public DataTable dtEditCt;
	

		
		BindingSource bdsEditCt = new BindingSource();
		

       
        public bool Is_Accept = false;
		#endregion

		#region Contructor

		public frmKQCalLaiGop()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

		}

       

        #endregion

        #region Method

        public void Load(DataTable dtKQLaiGop)
		{
			this.dtEditCt = dtKQLaiGop;

			Build();
			FillData();
			BindingLanguage();
            
            this.btgAccept.Visible = false;
            

            this.LoadDicName();
			this.ShowDialog();
		}
      
        void LoadDicName()
		{
			
		}

		void Build()
		{
			dgvKQLaiGop.strZone = "NXTLAIGOP";
            dgvKQLaiGop.BuildGridView();
            dgvKQLaiGop.Columns["Ten_Dt"].Frozen = true;
            foreach (DataGridViewColumn dgvc in dgvKQLaiGop.Columns)
				dgvc.ReadOnly = true;

            string strName = ""; string strLength = "";
            string strColumn = "";//"Tien_Dt_01,Tien_Gv_01,Tien_Lai_01,Tien_Dt_02,Tien_Gv_02,Tien_Lai_02,Tien_Dt_03,Tien_Gv_03,Tien_Lai_03,Tien_Dt_04,Tien_Gv_04,Tien_Lai_04,Ngay_05,Ngay_06,Ngay_07,Ngay_08,Ngay_09,Ngay_10,Ngay_11,Ngay_12,Ngay_13,Ngay_14,Ngay_15,Ngay_16,Ngay_01,Ngay_16,Ngay_17,Ngay_18,Ngay_19,Ngay_20,Ngay_01,Ngay_21,Ngay_22,Ngay_01,Ngay_23,Ngay_01,Ngay_24,Ngay_01,Ngay_25,Ngay_01,Ngay_26,Ngay_27,Ngay_28,Ngay_29,Ngay_30,Ngay_31,";
            for (int i = 1; i <= 31; i++)
            {
                strLength = i.ToString();
                if (strLength.Length == 1)
                    strName = "_0" + strLength;
                else
                    strName = "_" + strLength;

                strColumn = "Tien_Dt" + strName;
                ((dgvAutoFilterColumnHeaderCell)dgvKQLaiGop.Columns[strColumn].HeaderCell).bFilteringEnabled = false;
                strColumn = "Tien_Gv" + strName;
                ((dgvAutoFilterColumnHeaderCell)dgvKQLaiGop.Columns[strColumn].HeaderCell).bFilteringEnabled = false;
                strColumn = "Tien_Lai" + strName;
                ((dgvAutoFilterColumnHeaderCell)dgvKQLaiGop.Columns[strColumn].HeaderCell).bFilteringEnabled = false;
            }
           
        }
        private void Data_Language()
        {
            string strName = ""; string strLength = "";
            string strColumn = "";
            
            dgvKQLaiGop.Columns["TTien_Dt"].HeaderText = "Tổng doanh thu";
            dgvKQLaiGop.Columns["TTien_Gv"].HeaderText = "Tổng giá vốn";
            dgvKQLaiGop.Columns["TTien_Lai"].HeaderText = "Tổng lãi";

            for (int i = 1; i <= 31; i++)
            {
                strLength = i.ToString();
                if (strLength.Length == 1)
                    strName = "_0" + strLength;
                else
                    strName = "_" + strLength;

                strColumn = "SL" + strName;
                dgvKQLaiGop.Columns[strColumn].HeaderText = "Sản lượng ngày " + strLength;
                strColumn = "Tien_Dt" + strName;
                dgvKQLaiGop.Columns[strColumn].HeaderText = "Doanh thu ngày "+ strLength;
                strColumn = "Tien_Gv" + strName;
                dgvKQLaiGop.Columns[strColumn].HeaderText = "Tiền vốn ngàyngày " + strLength;
                strColumn = "Tien_Lai" + strName;
                dgvKQLaiGop.Columns[strColumn].HeaderText = "Tiền lãi ngày " + strLength;
            }
            
            //dgvKQLaiGop.Columns["Tien_Dt_01"].HeaderText = "Doanh thu ngày 1";
            //dgvKQLaiGop.Columns["Tien_Gv_01"].HeaderText = "Tiền vốn ngày 1";
            //dgvKQLaiGop.Columns["Tien_Lai_01"].HeaderText = "Tiền lãi ngày 1";

            //dgvKQLaiGop.Columns["Tien_Dt_02"].HeaderText = "Doanh thu ngày 2";
            //dgvKQLaiGop.Columns["Tien_Gv_02"].HeaderText = "Tiền vốn ngày 2";
            //dgvKQLaiGop.Columns["Tien_Lai_02"].HeaderText = "Tiền lãi ngày 2";

            //dgvKQLaiGop.Columns["Tien_Dt_03"].HeaderText = "Doanh thu ngày 3";
            //dgvKQLaiGop.Columns["Tien_Gv_03"].HeaderText = "Tiền vốn ngày 3";
            //dgvKQLaiGop.Columns["Tien_Lai_03"].HeaderText = "Tiền lãi ngày 3";

            //dgvKQLaiGop.Columns["Tien_Dt_04"].HeaderText = "Doanh thu ngày 4";
            //dgvKQLaiGop.Columns["Tien_Gv_04"].HeaderText = "Tiền vốn ngày 4";
            //dgvKQLaiGop.Columns["Tien_Lai_04"].HeaderText = "Tiền lãi ngày 4";

            //dgvKQLaiGop.Columns["Tien_Dt_03"].HeaderText = "Doanh thu ngày 3";
            //dgvKQLaiGop.Columns["Tien_Gv_03"].HeaderText = "Tiền vốn ngày 3";
            //dgvKQLaiGop.Columns["Tien_Lai_03"].HeaderText = "Tiền lãi ngày 3";


            //dgvKQLaiGop.Columns["Tien_Dt_03"].HeaderText = "Doanh thu ngày 3";
            //dgvKQLaiGop.Columns["Tien_Gv_03"].HeaderText = "Tiền vốn ngày 3";
            //dgvKQLaiGop.Columns["Tien_Lai_03"].HeaderText = "Tiền lãi ngày 3";

            //dgvKQLaiGop.Columns["Tien_Dt_03"].HeaderText = "Doanh thu ngày 3";
            //dgvKQLaiGop.Columns["Tien_Gv_03"].HeaderText = "Tiền vốn ngày 3";
            //dgvKQLaiGop.Columns["Tien_Lai_03"].HeaderText = "Tiền lãi ngày 3";

            //dgvKQLaiGop.Columns["Tien_Dt_03"].HeaderText = "Doanh thu ngày 3";
            //dgvKQLaiGop.Columns["Tien_Gv_03"].HeaderText = "Tiền vốn ngày 3";
            //dgvKQLaiGop.Columns["Tien_Lai_03"].HeaderText = "Tiền lãi ngày 3";


            //dgvKQLaiGop.Columns["Tien_Dt_03"].HeaderText = "Doanh thu ngày 3";
            //dgvKQLaiGop.Columns["Tien_Gv_03"].HeaderText = "Tiền vốn ngày 3";
            //dgvKQLaiGop.Columns["Tien_Lai_03"].HeaderText = "Tiền lãi ngày 3";


            //dgvKQLaiGop.Columns["Tien_Dt_03"].HeaderText = "Doanh thu ngày 3";
            //dgvKQLaiGop.Columns["Tien_Gv_03"].HeaderText = "Tiền vốn ngày 3";
            //dgvKQLaiGop.Columns["Tien_Lai_03"].HeaderText = "Tiền lãi ngày 3";


            //dgvKQLaiGop.Columns["Tien_Dt_03"].HeaderText = "Doanh thu ngày 3";
            //dgvKQLaiGop.Columns["Tien_Gv_03"].HeaderText = "Tiền vốn ngày 3";
            //dgvKQLaiGop.Columns["Tien_Lai_03"].HeaderText = "Tiền lãi ngày 3";

        }
        void FillData()
		{
			bdsEditCt.DataSource = dtEditCt;

			dgvKQLaiGop.DataSource = bdsEditCt;

			
		}

		bool FormCheckValid()
		{
            //if (strLoai == "PKHVT")
            //{
            //    //foreach(DataRow dr in dtEditCt.Rows)
            //    //{ 
            //    //    if ((bool)dr["IsStop"] && dr["Phan_Hoi_KHVT"].ToString() == string.Empty)
            //    //    {
            //    //        Common.MsgOk("Anh (chị) cần bổ sung thông tin phản hồi nếu dừng không mua VTPT nữa!!!");
            //    //    }
            //    //    return false;
            //    //}
            //}
			return true;
		}

		#endregion

		#region Event
       
    
       
       
        
      
       
       
        #endregion

        #region Update
       

		void btAccept_Click(object sender, EventArgs e)
		{
           
   //         if (this.Save())
			//{
			//	this.Is_Accept = true;
			//	this.Close();
			//}
		}

		

		void btCancel_Click(object sender, EventArgs e)
		{
			//this.Is_Accept = false;
			//this.Close();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Data_Language();

            //if (!Element.sysIs_Admin)
            //{
            //    string strCreate_User = DataTool.SQLGetNameByCode("R80PH", "Stt", "Create_Log", strStt);

            //    if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
            //    {
            //        string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

            //        if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
            //        {
            //            if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
            //            {
            //                this.btgAccept.btAccept.Enabled = false;
            //                return;
            //            }
            //        }
            //    }
            //}
        }
        #endregion

        
    }

}