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
	public partial class frmUpdate_ThongTin : RosySystem.Customize.frmView
	{
		#region Declare
        //private rsDataGridView dgvPhanHoiKHVT= new rsDataGridView();

		public DataTable dtEditCt;
		public DataTable dtEditPh;
		public DataTable dtPhanHoiKTCDAT;

		BindingSource bdsPhanHoiKTCDAT = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
		BindingSource bdsEditPh = new BindingSource();
		
		DataRow drDuyet;
        DataRow drCurrent;
		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
		
		public bool Is_Accept = false;
		#endregion

		#region Contructor

        public frmUpdate_ThongTin()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);            
			
		}

      

		#endregion

		#region Method

		public void Load(DataRow drDuyet)
		{
			this.drDuyet = drDuyet;

			this.strMa_Ct = (string)drDuyet["Ma_Ct"];
			this.strStt = (string)drDuyet["Stt"];

			Build();
			FillData();
			BindingLanguage();
           
			this.LoadDicName();
			this.ShowDialog();
		}

		void LoadDicName()
		{
			
		}
        private void DataGridView_Language()
        {
            if (dgvUpdate_ThongTin.Columns.Contains("Muc_Dich") && Common.Inlist(strMa_Ct, "DTCP"))
                dgvUpdate_ThongTin.Columns["Muc_Dich"].HeaderText = "Nội dung bảo trì sửa chữa";
            if (dgvUpdate_ThongTin.Columns.Contains("Ngay_DKGH") && Common.Inlist(strMa_Ct, "DTCP"))
                dgvUpdate_ThongTin.Columns["Ngay_DKGH"].HeaderText = "Ngày giao";
            if (dgvUpdate_ThongTin.Columns.Contains("Ngay_GH") && Common.Inlist(strMa_Ct, "DTCP"))
                dgvUpdate_ThongTin.Columns["Ngay_GH"].HeaderText = "Ngày nhận";
            if (dgvUpdate_ThongTin.Columns.Contains("Ngay_Gh_Tt") && Common.Inlist(strMa_Ct, "DTCP"))
                dgvUpdate_ThongTin.Columns["Ngay_Gh_Tt"].HeaderText = "Ngày nghiệm thu";

            dgvUpdate_ThongTin.ResizeGridView();
        }
		void Build()
		{
			dgvUpdate_ThongTin.strZone = "DT_EDITCT3";
          

			dgvUpdate_ThongTin.BuildGridView();

            foreach (DataGridViewColumn dgvc in dgvUpdate_ThongTin.Columns)
                dgvc.ReadOnly = true;

            dgvUpdate_ThongTin.Columns["Ngay_DKGH"].ReadOnly = false;
            dgvUpdate_ThongTin.Columns["Ngay_GH"].ReadOnly = false;
            dgvUpdate_ThongTin.Columns["Ngay_GH_TT"].ReadOnly = false;
            
		}

		void FillData()
		{
			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
			Hashtable htPara = new Hashtable();
			htPara.Add("TABLE_PH", (string)drDmCt["Table_Ph"]);
			htPara.Add("TABLE_CT", (string)drDmCt["Table_Ct"]);
			htPara.Add("STT", strStt);
            htPara.Add("USER_LOGIN", Element.sysUser_Id);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter", htPara, CommandType.StoredProcedure);

			dtEditPh = dsVoucher.Tables[0];
			dtEditCt = dsVoucher.Tables[1];

			bdsEditPh.DataSource = dtEditPh;

			bdsEditCt.DataSource = dtEditCt;
			dgvUpdate_ThongTin.DataSource = bdsEditCt;

			dtPhanHoiKTCDAT = dtEditCt;
			bdsPhanHoiKTCDAT.DataSource = dtPhanHoiKTCDAT;
			
			
            
		}

		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		#region Event
      
       
       

       
      
       
        #endregion

        #region Update
       
		bool Update_Ct()
		{
            

			SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
			SqlCommand sqlCom = sqlCon.CreateCommand();


			//#region Update chứng từ
			sqlCom.CommandText = "sp_Update_Ct";
			sqlCom.CommandType = CommandType.StoredProcedure;

			sqlCom.Parameters.Clear();
			sqlCom.Parameters.AddWithValue("@strNew_Edit", "E");
			sqlCom.Parameters.AddWithValue("@Stt", strStt);
			sqlCom.Parameters.AddWithValue("@Ma_Ct", strMa_Ct);
			sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

			//Tạo Table cho TVP_PH
			SqlParameter paraPH = new SqlParameter();
			paraPH.SqlDbType = SqlDbType.Structured;
			paraPH.ParameterName = "@PH";

			SqlParameter paraCt = new SqlParameter();
			paraCt.SqlDbType = SqlDbType.Structured;
			paraCt.ParameterName = "@Ct";

			sqlCom.CommandText = "sp_Update_CtPO";

			//TVP_PH
			paraPH.TypeName = "TVP_PHPO";
			paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHPO", dtEditPh);
			sqlCom.Parameters.Add(paraPH);

			//Tạo Table cho TVP_CtSO
			paraCt.TypeName = "TVP_CtPO";
			paraCt.Value = Voucher.GetTVPValue("R04CtPO", "TVP_CtPO", dtEditCt);
			sqlCom.Parameters.Add(paraCt);


			//
			try
			{
				sqlCom.ExecuteNonQuery();

			}
			catch (Exception ex)
			{
				sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
				sqlCom.CommandType = CommandType.Text;
				sqlCom.Parameters.Clear();
				sqlCom.ExecuteNonQuery();

				MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
				return false;
			}
			return true;
		}

		bool Save()
		{
			Update_Ct();	

			return true;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.Is_Accept = true;
				this.Close();
			}
		}

		

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
        }

        #endregion
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.DataGridView_Language();
        }
    }

}