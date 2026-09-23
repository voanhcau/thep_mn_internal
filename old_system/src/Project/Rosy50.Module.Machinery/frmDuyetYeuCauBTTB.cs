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
	public partial class frmDuyetYeuCauBTTB : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtDuyet_Ct;
		public DataTable dtDuyet_Ph;
		public DataTable dtResource;
		public DataTable dtHistory;
        public DataTable dtCtYeuCau;

		BindingSource bdsDuyet = new BindingSource();
		BindingSource bdsDuyet_Ph = new BindingSource();
		BindingSource bdsResource = new BindingSource();
		BindingSource bdsHistory = new BindingSource();
        BindingSource bdsCtYeuCau = new BindingSource();

		DataRow drDuyet;
		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
		frmVoucher_Edit frmVoucher_Edit;
		DataRow drCurrent, drDmCt_Current;
		public bool Is_Accept = false;

		bool bDuyet_Tp = false;
		bool bDuyet_PxCd = false;
		bool bDuyet_KtCdAt = false;
		bool bDuyet_KhVt = false;
        bool bDuyet_TcHc = false;
		bool bDuyet_KtTc = false;
		bool bDuyet_Gd = false;

		bool bDuyet_Tp_Ph = false;
		bool bDuyet_PxCd_Ph = false;
		bool bDuyet_KtCdAt_Ph = false;
		bool bDuyet_KtTc_Ph = false;
		bool bDuyet_KhVt_Ph = false;
        bool bDuyet_TcHc_Ph = false;
		bool bDuyet_Gd_Ph = false;
        bool bDuyet_Huy = false;
        bool bDuyet_Dnx = false;
        string strColumnName = string.Empty;
		#endregion

		#region Contructor

		public frmDuyetYeuCauBTTB()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			
			
			
            //btOpen_Bg.Click += new EventHandler(btOpen_Bg_Click);
			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);

			txtGD_Duyet.Validating += new CancelEventHandler(txtGD_Duyet_Validating);
			dgvDuyet.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDuyet_CellValidating);
            //dgvDuyet.CellValidated += new DataGridViewCellEventHandler(dgvDuyet_CellValidated);
            bdsDuyet.PositionChanged += new EventHandler(bdsDuyet_PositionChanged);
			
		}

		#endregion

		#region Method

		public void Load(DataRow drDuyet, bool Is_Duyet, string strColumnName)
		{
			this.drDuyet = drDuyet;

			this.strMa_Ct = (string)drDuyet["Ma_Ct"];
			this.strStt = (string)drDuyet["Stt"];
            this.strColumnName = strColumnName;
            
            
            chkDuyet.Checked = Is_Duyet;
           
            drDmCt_Current = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
            Build();
			FillData();
			BindingLanguage();
            DataGridView_Language();

		
            tbCtYeuCau.Visible = false;
               
            btNew.Visible = false;
            btEdit.Visible = false;
            btDelete.Visible = false;
                
            txtGD_Duyet.Visible = false;
            lbtTen_Gd_Duyet.Visible = false;
            lblGiam_Doc_Duyet.Visible = false;

            if (Common.InlistLike(strMa_Ct, "BBHH"))
            {
                btNew.Visible = true;
                btEdit.Visible = true;
                btDelete.Visible = true;
                tbCtYeuCau.Visible = true;
            }            

               
			

            BindingTong_Tien();
			this.LoadDicName();
			this.ShowDialog();
		}
        private void BindingTong_Tien()
        {
            

            numTSo_Luong.DataBindings.Add("Value", bdsDuyet_Ph, "TSo_Luong");

        }
        void DataGridView_Language()
        {
            if (dgvDuyet.Columns.Contains("So_Luong9"))
                dgvDuyet.Columns["So_Luong9"].HeaderText = "Số lượng duyệt TGD";
         
        }
		void LoadDicName()
		{
            //txtMa_Nvu
			if (txtGD_Duyet.Text.Trim() != string.Empty)
				lbtTen_Gd_Duyet.Text = DataTool.SQLGetNameByCode("R00Member", "Member_ID", "Member_Name", txtGD_Duyet.Text.Trim());
			else
				lbtTen_Gd_Duyet.Text = string.Empty;
		}

		void Build()
		{
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);

			dgvDuyet.strZone =drDmCt["Zone_EditCt4"].ToString();

			
            dgvCtVt.strZone = "CTVT_BBHH";

			dgvDuyet.BuildGridView();
            dgvCtVt.BuildGridView();

			foreach (DataGridViewColumn dgvc in dgvDuyet.Columns)
				dgvc.ReadOnly = true;

			string strCreate_User = (string)drDuyet["Create_Log"];

			string strMa_Nh_User = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetList('" + Element.sysUser_Id + "')") + "";
			string strMa_Nh_Create = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + strCreate_User.Substring(14) + "'") + "";
           
            chkDuyet.Enabled = false;
            this.btgAccept.btAccept.Enabled = false;

            DataRow drPh = DataTool.SQLGetDataRowByID("R06PH_BTTB", "Stt", strStt);
            bDuyet_Tp_Ph = (bool)drPh["Duyet_Tp"];
            bDuyet_PxCd_Ph = (bool)drPh["Duyet_PxCd"];
            bDuyet_KtCdAt_Ph = (bool)drPh["Duyet_KtCdAt"];     
            
            bDuyet_Gd_Ph = (bool)drPh["Duyet_GiamDoc"];
            bDuyet_Huy = (bool)drPh["Duyet_Huy"];

			bDuyet_Tp = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
			bDuyet_PxCd = Common.CheckPermission("IS_TP_PXCD", enuPermission_Type.Allow_Access);
			bDuyet_KtCdAt = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
			
			bDuyet_Gd = Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access);
           
			

            if (bDuyet_Tp)
            {
                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;               

                if (dgvDuyet.Columns.Contains("Ghi_Chu_TP"))
                    dgvDuyet.Columns["Ghi_Chu_TP"].ReadOnly = false;

                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;
            }

            if (bDuyet_KtCdAt)
            {
                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;

                if (dgvDuyet.Columns.Contains("Ghi_Chu_KTCDAT"))
                    dgvDuyet.Columns["Ghi_Chu_KTCDAT"].ReadOnly = false;

                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;
            }

            if (bDuyet_PxCd)
            {
                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;

                if (dgvDuyet.Columns.Contains("Ghi_Chu_PXCD"))
                    dgvDuyet.Columns["Ghi_Chu_PXCD"].ReadOnly = false;

                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;
            }
          
			if (bDuyet_Gd)
			{
                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;

				if (dgvDuyet.Columns.Contains("So_Luong9"))
					dgvDuyet.Columns["So_Luong9"].ReadOnly = false;

				if (dgvDuyet.Columns.Contains("Ghi_Chu_GD"))
					dgvDuyet.Columns["Ghi_Chu_GD"].ReadOnly = false;

                chkDuyet.Enabled = true;
                this.btgAccept.btAccept.Enabled = true;
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

			dtDuyet_Ph = dsVoucher.Tables[0];
			dtDuyet_Ct = dsVoucher.Tables[1];
            
            if (dsVoucher.Tables.Count >= 3)
            {            
                dtCtYeuCau = dsVoucher.Tables[3];
            }
         
            
            bdsDuyet_Ph.DataSource = dtDuyet_Ph;
			bdsDuyet.DataSource = dtDuyet_Ct;
			dgvDuyet.DataSource = bdsDuyet;
		

            
            bdsCtYeuCau.DataSource = dtCtYeuCau;
            dgvCtVt.DataSource = bdsCtYeuCau;
            
			string strGd_Duyet = "SELECT Gd_Duyet FROM R06PH_BTTB WHERE Stt = '" + strStt + "'";
			txtGD_Duyet.Text = SQLExec.ExecuteReturnValue(strGd_Duyet).ToString();
		}

		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		//#region Event
		void txtGD_Duyet_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtGD_Duyet.Text.Trim();
			bool bRequire = false;
			string strKey = string.Empty;


			DataRow drLookup = Lookup.ShowLookup("Member_ID", strValue, bRequire, strKey);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtGD_Duyet.Text = string.Empty;
				lbtTen_Gd_Duyet.Text = string.Empty;
			}
			else
			{
				txtGD_Duyet.Text = drLookup["Member_ID"].ToString();
				lbtTen_Gd_Duyet.Text = drLookup["Member_Name"].ToString();

			}
		}

		void btOpen_Bg_Click(object sender, EventArgs e)
		{
            //if (bdsResource.Position < 0)
            //    return;

            //drCurrent = ((DataRowView)bdsResource.Current).Row;
            //string strFileName = (string)drCurrent["File_Name"] + '.' + drCurrent["Tag"];// +".pdf";
            //string strPath = @"\\192.168.1.18\BaoGia\";

            //if (!Directory.Exists(strPath))
            //    Directory.CreateDirectory(strPath);

            //Hashtable htPara = new Hashtable();

            //htPara.Add("STT", (string)drCurrent["Stt"]);
            //htPara.Add("FILE_NAME", drCurrent["FILE_NAME"]);


            //object objFile = SQLExec.ExecuteReturnValue("SELECT Image FROM R50THEPMN3_RESOURCE..R04CtSo_Resource WHERE File_Name = @File_Name AND Stt = @Stt ", htPara, CommandType.Text);

            //if (objFile != null && objFile != DBNull.Value && ((Byte[])objFile).Length > 0)
            //{
            //    FileStream fileStream = new FileStream(strPath + strFileName, FileMode.Create, FileAccess.ReadWrite);
            //    fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);
            //    fileStream.Close();
            //    System.Diagnostics.Process.Start(strPath + strFileName);
            //}
            //else
            //    Common.MsgOk("Không có file attach");
		}

		

		void dgvDuyet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;

			drCurrent = ((DataRowView)bdsDuyet.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
		

			
				
		}

        void bdsDuyet_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDuyet.Position < 0)
                return;
            if (Common.InlistLike(strMa_Ct, "PYC,DT"))
            {
                drCurrent = ((DataRowView)bdsDuyet.Current).Row;
                string strMa_Vt = (string)drCurrent["Ma_Vt"];
                bdsHistory.Filter = "(Ma_Vt = '" + strMa_Vt + "')";
            }
        }
       
        
        bool Save()
		{
            DataRow drDuyet_Ph = ((DataRowView)bdsDuyet_Ph.Current).Row;

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

            if (drDmCt_Current["Table_Ct"].ToString() == "R06CT_BTTB")
            {
                sqlCom.CommandText = "Sp_Update_BTTB";

                //TVP_PH
                paraPH.TypeName = "TVP_PHBTTB";
                paraPH.Value = Voucher.GetTVPValue("R06PH_BTTB", "TVP_PHBTTB", dtDuyet_Ph);
                sqlCom.Parameters.Add(paraPH);

                //Tạo Table cho TVP_CtSO
                paraCt.TypeName = "TVP_CTBTTB";
                paraCt.Value = Voucher.GetTVPValue("R06CT_BTTB", "TVP_CTBTTB", dtDuyet_Ct);
                sqlCom.Parameters.Add(paraCt);
            }
         

			try
			{
				sqlCom.ExecuteNonQuery();
				//sqlCom1.ExecuteNonQuery();
				SQLExec.Execute("UPDATE R06PH_BTTB SET Gd_Duyet = '" + txtGD_Duyet.Text + "' WHERE Stt = '" + strStt + "' ");
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
            else
            {
                this.Is_Accept = true;
                this.Close();
            }
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
                dgvDuyet.CancelEdit();
                dgvCell.Value = drLookup["Ma_Dt"].ToString();
                dgvCell.Tag = drLookup["Ten_Dt"].ToString();

            }
            return true;
        }
		
		public override void Edit(enuEdit enuNew_Edit)
		{
            DataRow drDuyet = ((DataRowView)bdsDuyet.Current).Row;

			if (bdsCtYeuCau.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
            if (bdsCtYeuCau.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsCtYeuCau.Current).Row, ref drCurrent);
			else
                drCurrent = dtCtYeuCau.NewRow();

            drCurrent["Stt"] = strStt;
            drCurrent["Stt0"] = drDuyet["Stt0"];
            drCurrent["Ma_Tb"] = drDuyet["Ma_Tb"];

            frmPTBTTB_Edit frmEdit = new frmPTBTTB_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
                    if (bdsCtYeuCau.Position >= 0)
                        dtCtYeuCau.ImportRow(drCurrent);
					else
                        dtCtYeuCau.Rows.Add(drCurrent);

                    bdsCtYeuCau.Position = bdsCtYeuCau.Find("STT", drCurrent["STT"]);
				}
				else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtYeuCau.Current).Row);

				dtCtYeuCau.AcceptChanges();
			}
		}
		public override void Delete()
		{
            if (bdsCtYeuCau.Position < 0)
				return;

            DataRow drCurrent = ((DataRowView)bdsCtYeuCau.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R06CTDMVT", drCurrent))
			{
                bdsHistory.RemoveAt(bdsCtYeuCau.Position);
				dtHistory.AcceptChanges();
			}
		}
		void btEdit_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.Edit);
		}

		void btNew_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.New);
		}
		void btDelete_Click(object sender, EventArgs e)
		{
			Delete();
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