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


namespace RosyModule.Machinery
{
	public partial class frmKet_Qua_BTTB : RosySystem.Customize.frmView
	{
		#region Declare
        //private rsDataGridView dgvPhanHoiKHVT= new rsDataGridView();

		public DataTable dtEditCt;
		public DataTable dtEditPh;
	

		
		BindingSource bdsEditCt = new BindingSource();
		BindingSource bdsEditPh = new BindingSource();
		
		DataRow drDuyet;
        DataRow drCurrent;
		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
		
		public bool Is_Accept = false;
		#endregion

		#region Contructor

		public frmKet_Qua_BTTB()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            btUpdateKQ.Click += new EventHandler(btUpdateKQ_Click);
		}

        

		#endregion

		#region Method

		public void Load(DataRow drDuyet)
		{
			this.drDuyet = drDuyet;

			this.strMa_Ct = (string)drDuyet["Ma_Ct"];
			this.strStt = (string)drDuyet["Stt"];
            
            if (strMa_Ct == "BTKH")
                btUpdateKQ.Visible = true;
            else
                btUpdateKQ.Visible = false;
			
            Build();
			FillData();
			BindingLanguage();

			this.LoadDicName();
			this.ShowDialog();
		}

		void LoadDicName()
		{
			
		}

		void Build()
		{
            if (strMa_Ct == "BTNB")
                dgvKet_Qua.strZone = "KET_QUA_BTNB";
            else if (strMa_Ct == "BTTT")
                dgvKet_Qua.strZone = "KET_QUA_BTTT";
            else if (strMa_Ct == "BTKH")
                dgvKet_Qua.strZone = "KET_QUA_BTKH";
            
            dgvKet_Qua.BuildGridView();

            foreach (DataGridViewColumn dgvc in dgvKet_Qua.Columns)
                dgvc.ReadOnly = true;

            if (dgvKet_Qua.Columns.Contains("Gia_Tri_Tk"))
                dgvKet_Qua.Columns["Gia_Tri_Tk"].ReadOnly = false;
            if (dgvKet_Qua.Columns.Contains("Gia_Tri_Tt"))
                dgvKet_Qua.Columns["Gia_Tri_Tt"].ReadOnly = false;
            if (dgvKet_Qua.Columns.Contains("Ngay_Bd"))
                dgvKet_Qua.Columns["Ngay_Bd"].ReadOnly = false;
            if (dgvKet_Qua.Columns.Contains("Ngay_Kt"))
                dgvKet_Qua.Columns["Ngay_Kt"].ReadOnly = false;
            if (dgvKet_Qua.Columns.Contains("Tinh_Trang_Tb"))
                dgvKet_Qua.Columns["Tinh_Trang_Tb"].ReadOnly = false;
            if (dgvKet_Qua.Columns.Contains("Tinh_Trang"))
                dgvKet_Qua.Columns["Tinh_Trang"].ReadOnly = false;
            if (dgvKet_Qua.Columns.Contains("Ghi_Chu_Ket_Qua"))
                dgvKet_Qua.Columns["Ghi_Chu_Ket_Qua"].ReadOnly = false;
            if (dgvKet_Qua.Columns.Contains("Ghi_Chu_KTCD"))
                dgvKet_Qua.Columns["Ghi_Chu_KTCD"].ReadOnly = false;
            if (dgvKet_Qua.Columns.Contains("Is_LyLich"))
                dgvKet_Qua.Columns["Is_LyLich"].ReadOnly = false;
            if (dgvKet_Qua.Columns.Contains("Noi_Dung"))
            {
                dgvKet_Qua.Columns["Noi_Dung"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvKet_Qua.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
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

            DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_BTTB", htPara, CommandType.StoredProcedure);

			dtEditPh = dsVoucher.Tables[0];
			dtEditCt = dsVoucher.Tables[1];

			bdsEditPh.DataSource = dtEditPh;

			bdsEditCt.DataSource = dtEditCt;
			dgvKet_Qua.DataSource = bdsEditCt;

		}

		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		#region Event


        void btUpdateKQ_Click(object sender, EventArgs e)
        {
            if (dtEditCt.Rows.Count == 0)
                return;

            string strSQL = string.Empty;
            DataTable dtBTTT;
            DataRow drBTTT;
            foreach (DataRow dr in dtEditCt.Rows)
            {
                // Lấy dữ liệu đã cập nhật từ phiếu BTTT của các đơn vị
                strSQL = "SELECT * FROM R06CT_BTTB WHERE Ma_Ct = 'BTTT' AND Stt = '" + dr["Stt_Org"].ToString() + "' AND Stt0 = '" + dr["Stt0_Org"] + "'";
                dtBTTT = SQLExec.ExecuteReturnDt(strSQL);
                if (dtBTTT.Rows.Count > 0)
                {
                    drBTTT = dtBTTT.Rows[0];
                    dr["Tinh_Trang"] = drBTTT["Tinh_Trang"];
                    dr["Tinh_Trang_Tb"] = drBTTT["Tinh_Trang_Tb"];
                    dr["Ghi_Chu_Ket_Qua"] = drBTTT["Ghi_Chu_Ket_Qua"];
                }
            }
            dtEditCt.AcceptChanges();
        }
     
     
        #endregion

        #region Update
      			
		bool Update_Ct()
		{
            foreach(DataRow drEditPh in dtEditPh.Rows)
                drEditPh["Ket_Qua_Log"] = Common.GetCurrent_Log();

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

            sqlCom.CommandText = "Sp_Update_BTTB";

			//TVP_PH
            paraPH.TypeName = "TVP_PHBTTB";
            paraPH.Value = Voucher.GetTVPValue("R06PH_BTTB", "TVP_PHBTTB", dtEditPh);
			sqlCom.Parameters.Add(paraPH);

			//Tạo Table cho TVP_CtSO
            paraCt.TypeName = "TVP_CTBTTB";
            paraCt.Value = Voucher.GetTVPValue("R06CT_BTTB", "TVP_CTBTTB", dtEditCt);
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

    }

}