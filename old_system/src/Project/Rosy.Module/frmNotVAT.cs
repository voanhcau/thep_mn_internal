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
	public partial class frmNotVAT : RosySystem.Customize.frmView
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

        public frmNotVAT()
		{
            InitializeComponent();

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            chkIs_NotGK.CheckedChanged +=new EventHandler(chkIs_NotGK_CheckedChanged);

            dgvPhanHoiKHVT.CellValidated += new DataGridViewCellEventHandler(dgvPhanHoiKHVT_CellValidated);
            

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

		void Build()
		{
			dgvPhanHoiKHVT.strZone = "NOTVAT";
            
            

			dgvPhanHoiKHVT.BuildGridView();
			
            

			foreach (DataGridViewColumn dgvc in dgvPhanHoiKHVT.Columns)
				dgvc.ReadOnly = true;

            if (dgvPhanHoiKHVT.Columns.Contains("IsNotVAT"))
                dgvPhanHoiKHVT.Columns["IsNotVAT"].ReadOnly = false;
         
           

			string strCreate_User = (string)drDuyet["Create_Log"];

			string strMa_Nh_User = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "'") + "";
			string strMa_Nh_Create = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + strCreate_User.Substring(14) + "'") + "";
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
			dgvPhanHoiKHVT.DataSource = bdsEditCt;
		}

		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		#region Event
        void dgvPhanHoiKHVT_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (strColumnName == "ISNOTVAT")
            {
                drCurrent["IsNotVAT"] = (bool)drCurrent["IsNotVAT"];
                drCurrent["NotVAT_Log"] = Common.GetCurrent_Log();
            }
        }
        void chkIs_NotGK_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dtEditCt.Rows)
            { 
                dr["IsNotVAT"] = chkIs_NotGK.Checked;
                dr["NotVAT_Log"] = Common.GetCurrent_Log();
            }
        }
        
        private bool dgvLookupMa_Vt_Tt(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsPhanHoiKTCDAT.Current).Row;

                dgvPhanHoiKHVT.CancelEdit();
                dgvCell.Value = drLookup["Ma_Vt"].ToString();
                dgvCell.Tag = drLookup["Ten_Vt"].ToString();

                drCurrent["Ten_Vt_Tt"] = drLookup["Ten_Vt"].ToString();
            }

            return true;
        }
        private bool dgvLookupMa_Dt_CbNv_Mh(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvPhanHoiKHVT.CancelEdit();
                dgvCell.Value = drLookup["Ma_Dt"].ToString();
                dgvCell.Tag = drLookup["Ten_Dt"].ToString();

            }
            return true;
        }
        private bool dgvLookupMa_Hd(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvPhanHoiKHVT.CancelEdit();
                dgvCell.Value = drLookup["Ma_Hd"].ToString();
                dgvCell.Tag = drLookup["Ten_Hd"].ToString();

            }
            return true;
        }
        #endregion

        #region Update
      
		bool Update_Ct()
		{
            //DataRow[] Result = dtEditCt.Select("Ma_Hd <> ''");
            //dtEditCt = dtEditCt.Clone(); 
         
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

            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);

            if (drDmCt["Table_Ct"].ToString().ToUpper() == "R01CTTIEN")
            {
                sqlCom.CommandText = "sp_Update_CtTien";

                //TVP_PH
                paraPH.TypeName = "TVP_PHTien";
                paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHTien", dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtTien
                paraCt.TypeName = "TVP_CtTien";
                paraCt.Value = Voucher.GetTVPValue("R01CtTien", "TVP_CtTien", dtEditCt);
                sqlCom.Parameters.Add(paraCt);

            }
            else if (drDmCt["Table_Ct"].ToString().ToUpper() == "R02CTNM")
            {
                sqlCom.CommandText = "sp_Update_CtNM";

                //TVP_PH
                paraPH.TypeName = "TVP_PHNM";
                paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHNM", dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtNM
                paraCt.TypeName = "TVP_CtNM";
                paraCt.Value = Voucher.GetTVPValue("R02CtNM", "TVP_CtNM", dtEditCt);
                sqlCom.Parameters.Add(paraCt);

            }
            else if (drDmCt["Table_Ct"].ToString().ToUpper() == "R04CTHD")
            {
                sqlCom.CommandText = "sp_Update_CtHD";

                //TVP_PH
                paraPH.TypeName = "TVP_PHHD";
                paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHHD", dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtNM
                paraCt.TypeName = "TVP_CtHD";
                paraCt.Value = Voucher.GetTVPValue("R04CtHD", "TVP_CtHD", dtEditCt);
                sqlCom.Parameters.Add(paraCt);

            }

            else if (drDmCt["Table_Ct"].ToString().ToUpper() == "R80CTKT")
            {
                sqlCom.CommandText = "sp_Update_CtKT";

                //TVP_PH
                paraPH.TypeName = "TVP_PHKT";
                paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHKT", dtEditPh);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtKT
                paraCt.TypeName = "TVP_CtKT";
                paraCt.Value = Voucher.GetTVPValue("R80CtKT", "TVP_CtKT", dtEditCt);
                sqlCom.Parameters.Add(paraCt);
            }
            

            //sqlCom.CommandText = "sp_Update_CtPO";

            ////TVP_PH
            //paraPH.TypeName = "TVP_PHPO";
            //paraPH.Value = Voucher.Voucher.GetTVPValue("R80PH", "TVP_PHPO", dtEditPh);
            //sqlCom.Parameters.Add(paraPH);

            ////Tạo Table cho TVP_CtSO
            //paraCt.TypeName = "TVP_CtPO";
            //paraCt.Value = Voucher.GetTVPValue("R04CtPO", "TVP_CtPO", dtEditCt);
            //sqlCom.Parameters.Add(paraCt);


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