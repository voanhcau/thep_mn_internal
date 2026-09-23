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
	public partial class frmDuyet_BTHCG : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtDuyet_Ct;
		public DataTable dtDuyet_Ph;

		BindingSource bdsDuyet = new BindingSource();
		DataRow drDuyet;
		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
		frmVoucher_Edit frmVoucher_Edit;
		DataRow drCurrent, drDmCt_Current;
		public bool Is_Accept = false;

		#endregion

		#region Contructor

		public frmDuyet_BTHCG()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			dgvDuyet.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDuyet_CellValidating);
			
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


			this.ShowDialog();
		}


		void Build()
		{
			dgvDuyet.strZone = "DUYET_THCG";
			
			dgvDuyet.BuildGridView();

			foreach (DataGridViewColumn dgvc in dgvDuyet.Columns)
				dgvc.ReadOnly = true;

			bool bDuyet_Tp = false;
			bool bDuyet_TcHc = false;
			bool bDuyet_KtCdAt = false;
			bool bDuyet_KhVt = false;
			bool bDuyet_Gd = false;
			bool bDuyet_KTTC = false;

			bool bDuyet_Tp_Ph = false;
			bool bDuyet_TcHc_Ph = false;
			bool bDuyet_KtCdAt_Ph = false;
			bool bDuyet_KhVt_Ph = false;
			bool bDuyet_Gd_Ph = false;
			

			string strCreate_User = (string)drDuyet["Create_Log"];

			string strMa_Nh_User = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "'") + "";
			string strMa_Nh_Create = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + strCreate_User.Substring(14) + "'") + "";

			if (!Element.sysIs_Admin)
			{
				bDuyet_Tp_Ph = (bool)drDuyet["Duyet_Tp"];
				bDuyet_TcHc_Ph = (bool)drDuyet["Duyet_TcHc"];
				bDuyet_KtCdAt_Ph = (bool)drDuyet["Duyet_KtCdAt"];
				bDuyet_KhVt_Ph = (bool)drDuyet["Duyet_KhVt"];
				bDuyet_Gd_Ph = (bool)drDuyet["Duyet_GiamDoc"];
				bDuyet_KTTC = (bool)drDuyet["Duyet_KTTC"];

				bDuyet_Tp = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
				bDuyet_Tp = Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access);
				bDuyet_KtCdAt = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
				bDuyet_KhVt = Common.CheckPermission("IS_TP_KHVT", enuPermission_Type.Allow_Access);
				bDuyet_Gd = Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access);
				bDuyet_KTTC = Common.CheckPermission("IS_KTTC", enuPermission_Type.Allow_Access);
			}

			if (bDuyet_Tp && strMa_Nh_User == strMa_Nh_Create && !bDuyet_KtCdAt_Ph)
			{
				dgvDuyet.Columns["So_Luong_TP"].ReadOnly = false;
				dgvDuyet.Columns["Ghi_Chu_TP"].ReadOnly = false;
			}
			if (bDuyet_KtCdAt && !bDuyet_KhVt_Ph)
			{
				dgvDuyet.Columns["So_Luong_KTCDAT"].ReadOnly = false;
				dgvDuyet.Columns["Ghi_Chu_KTCDAT"].ReadOnly = false;
			}
			if (bDuyet_KhVt && !bDuyet_Gd)
			{
				dgvDuyet.Columns["So_Luong_KHVT"].ReadOnly = false;
				dgvDuyet.Columns["Ghi_Chu_KHVT"].ReadOnly = false;
			}
			if (bDuyet_Gd)
			{
				dgvDuyet.Columns["So_Luong9"].ReadOnly = false;
				dgvDuyet.Columns["Ghi_Chu_GD"].ReadOnly = false;
			}
			if (bDuyet_KTTC)
			{
				dgvDuyet.Columns["So_Luong_KTTC"].ReadOnly = false;
				dgvDuyet.Columns["Ghi_Chu_KTTC"].ReadOnly = false;
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

			DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter", htPara, CommandType.StoredProcedure);

			dtDuyet_Ph = dsVoucher.Tables[0];
			dtDuyet_Ct = dsVoucher.Tables[1];

			bdsDuyet.DataSource = dtDuyet_Ct;
			dgvDuyet.DataSource = bdsDuyet;



		}

		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		//#region Event
		void dgvDuyet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			drCurrent = ((DataRowView)bdsDuyet.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "SO_LUONG_TP") && !dgvCell.DataGridView.Columns["SO_LUONG_TP"].ReadOnly)
			{
				drCurrent["So_Luong9"] = drCurrent["So_Luong_Tp"];
				drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong_Tp"];
				drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong_Tp"];
				drCurrent["So_Luong"] = drCurrent["So_Luong9"];

			}
			if (Common.Inlist(strColumnName, "SO_LUONG_KTCDAT") && !dgvCell.DataGridView.Columns["SO_LUONG_KTCDAT"].ReadOnly)
			{
				drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong_KtCdAt"];
				drCurrent["So_Luong_KTTC"] = drCurrent["So_Luong_KtCdAt"];
				drCurrent["So_Luong9"] = drCurrent["So_Luong_KtCdAt"];
				drCurrent["So_Luong"] = drCurrent["So_Luong9"];

			}
			if (Common.Inlist(strColumnName, "SO_LUONG_KTTC") && !dgvCell.DataGridView.Columns["So_Luong_KTTC"].ReadOnly)
			{
				drCurrent["So_Luong9"] = drCurrent["SO_LUONG_KTTC"];
				drCurrent["So_Luong"] = drCurrent["So_Luong9"];

			}
			if (Common.Inlist(strColumnName, "SO_LUONG_KHVT") && !dgvCell.DataGridView.Columns["SO_LUONG_KHVT"].ReadOnly)
			{
				drCurrent["So_Luong9"] = drCurrent["So_Luong_KhVt"];
				drCurrent["So_Luong"] = drCurrent["So_Luong9"];
			}

			drCurrent.AcceptChanges();
		}
		

		bool Save()
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
			paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHPO", dtDuyet_Ph);
			sqlCom.Parameters.Add(paraPH);

			//Tạo Table cho TVP_CtSO
			paraCt.TypeName = "TVP_CtPO";
			paraCt.Value = Voucher.GetTVPValue("R04CtPO", "TVP_CtPO", dtDuyet_Ct);
			sqlCom.Parameters.Add(paraCt);


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
			


	}

}