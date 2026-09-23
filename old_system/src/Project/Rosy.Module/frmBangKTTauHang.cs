using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Public;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;

namespace RosyModule
{
    public partial class frmBangKTTauHang : RosySystem.Customize.frmView
    {
        DataTable dtKQKN;
        BindingSource bdsKQKN = new BindingSource();
        DataRow drCurrent;
		DataRow drEdit;
		string strEdit = "E";
		public bool Is_Accept = false;
		public double dbCharge_Weight = 0;
     //   rsDataGridView dgvKQKN = new rsDataGridView();
      
        public string strStt = "";

		public frmBangKTTauHang()
        {
            InitializeComponent();

			this.dgvKQKN.CellValidated += new DataGridViewCellEventHandler(dgvKQKN_CellValidated);
			this.dgvKQKN.CellValidating += new DataGridViewCellValidatingEventHandler(dgvKQKN_CellValidating);
			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.KeyDown += new KeyEventHandler(frmBangKTTauHang_KeyDown);

        }

		void frmBangKTTauHang_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					DeleteRow();
					break;
			}			
		}

		private void DeleteRow()
		{
			if (dgvKQKN.Focused == false)
				return;

			drCurrent = ((DataRowView)bdsKQKN.Current).Row;
			drCurrent["Deleted"] = !((bool)drCurrent["Deleted"]);

			if ((bool)drCurrent["Deleted"] == true)
			{
				Font font = new Font(dgvKQKN.Font.FontFamily, dgvKQKN.Font.Size, FontStyle.Strikeout);
				dgvKQKN.CurrentRow.DefaultCellStyle.Font = font;
			}
			else
			{
				dgvKQKN.CurrentRow.DefaultCellStyle.Font = dgvKQKN.Font;
			}

			
		}

        public void Load()
        {
            this.Build();
            this.FillData();
		
            this.Show();
			Calc_Tien_All();
        }
		public void Load(string strStt)
        {
			this.strStt = strStt;

			this.drEdit = DataTool.SQLGetDataRowByID("R02CTNM", "Stt", this.strStt);

			Common.ScaterMemvar(this, ref drEdit);

            this.Build();
            this.FillData();
			Init_Ct();
			LoadDicName();
			Calc_Tien_All();

			//if (strEdit == "E")
			//{
			//    numTong_So_Luong.Value = dtKQKN.Rows[0]["Tong_So_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(dtKQKN.Rows[0]["Tong_So_Luong"]);
			//}
            this.ShowDialog();
		
        }

        private void Build()
        {
            dgvKQKN.Dock = DockStyle.Fill;
            dgvKQKN.strZone = "BANGKEBOCHANG";
            dgvKQKN.BuildGridView();
          
           // this.splitContainer.Panel1.Controls.Add(dgvKQKN);

            dgvKQKN.ReadOnly = false;

			//foreach (DataGridViewColumn dgvc in dgvKQKN.Columns)
			//    dgvc.ReadOnly = true;
						
        }

		private void LoadDicName()
		{
			txtMa_Dt.bUseAutoDropDown = true;
			txtMa_Hd.bUseAutoDropDown = true;

			//txtMa_Dt
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;

			//txtMa_Hd
			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				lbtTen_Hd.Text = DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			}
			else
				lbtTen_Hd.Text = string.Empty;

		}
        private void FillData()
        {
			string strSQLExec = "SELECT * FROM R02KETQUATAU WHERE Stt_Org = '" + strStt + "'";
                        
            dtKQKN = SQLExec.ExecuteReturnDt(strSQLExec);

			DataColumn dc = new DataColumn("Deleted", typeof(bool));
			dc.DefaultValue = false;
			dtKQKN.Columns.Add(dc);

            bdsKQKN.DataSource = dtKQKN;
            dgvKQKN.DataSource = bdsKQKN;

            this.bdsSearch = bdsKQKN;
           // this.ExportControl = dgvKQKN;

        }


		private void Init_Ct()
		{
			if (dtKQKN.Rows.Count == 0)
			{
				DataRow dr = dtKQKN.NewRow();
				Common.SetDefaultDataRow(ref dr);
				dtKQKN.Rows.Add(dr);
				strEdit = "N";
			}
		
		}
        public override void Edit(enuEdit enuNew_Edit)
        {
           
        }

        public override void Delete()
        {
           
        }

		private void Calc_Tien_All()
		{
			string strKeyFilter = "";

			
			DataTable dtEditCt = this.dtKQKN;

			numSo_Luong.Value = Math.Round(Common.SumDCValue(dtKQKN, "So_Luong", strKeyFilter), 2, MidpointRounding.AwayFromZero);
			numHMS1.Value = Math.Round(Common.SumDCValue(dtKQKN, "KL_HMS1", strKeyFilter), 2, MidpointRounding.AwayFromZero);
			numHMS2.Value = Math.Round(Common.SumDCValue(dtKQKN, "KL_HMS2", strKeyFilter), 2, MidpointRounding.AwayFromZero);
			numHMS3.Value = Math.Round(Common.SumDCValue(dtKQKN, "KL_HMS3", strKeyFilter), 2, MidpointRounding.AwayFromZero);

		}
		#region Sự kiện

		void dgvKQKN_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			//Xu ly phim Enter
			if (dgvEditCt.kLastKey == Keys.Enter)
			{
				dgvEditCt.kLastKey = Keys.None;

				if (this.CellKeyEnter())
					e.Cancel = true;
			}
		}

		void dgvKQKN_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;

			//if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
			//    return;

			DataRow drCurrent2 = ((DataRowView)bdsKQKN.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "SO_LUONG,KL_HMS1,KL_HMS2,KL_HMS3,TAP_CHAT"))
			{
				double dbTong_So_Luong = (drCurrent2["SO_LUONG"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent2["SO_LUONG"]);
				double db_KL_HMS1 = (drCurrent2["KL_HMS1"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent2["KL_HMS1"]);
				double db_KL_HMS2 = (drCurrent2["KL_HMS2"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent2["KL_HMS2"]);
				double db_KL_HMS3 = (drCurrent2["KL_HMS3"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent2["KL_HMS3"]);
				double db_Tap_Chat = (drCurrent2["TAP_CHAT"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent2["TAP_CHAT"]);

				double dbTL_HMS1  = 0;
				double dbTL_Tap_Chat = 0;
				if (db_KL_HMS1 > 0 && dbTong_So_Luong > 0)
				{
					dbTL_HMS1 = db_KL_HMS1 / (dbTong_So_Luong - db_Tap_Chat) * 100;
					dbTL_Tap_Chat = db_Tap_Chat / dbTong_So_Luong * 100;
					dbTL_HMS1 = Math.Round(dbTL_HMS1, 2, MidpointRounding.AwayFromZero);
					dbTL_Tap_Chat = Math.Round(dbTL_Tap_Chat, 2, MidpointRounding.AwayFromZero);
				}
				drCurrent2["TL_HMS1"] = dbTL_HMS1;
				drCurrent2["TL_Tap_Chat"] = dbTL_Tap_Chat;
				drCurrent2.AcceptChanges();
				Calc_Tien_All();
			}

		}	
		
		protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
		}

		private bool CellKeyEnter()
		{
			if (dgvKQKN.CurrentCell == null)
				return false;

			DataGridViewCell dgvCell = dgvKQKN.CurrentCell;
			string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

			#region Enter tai TIEN_NT9
			if (Common.Inlist(strCurrentColumn, "TL_TAP_CHAT"))
			{
				if (dgvKQKN.bIsCurrentLastRow)
				{
					if (!AddRow())
						return false;
					else
						dgvKQKN.FocusNextFirstCell();
					return true;
				}
				return false;
			}
			#endregion

			if (Common.Inlist(strCurrentColumn, "KL_HMS1"))
			{
				drCurrent = ((DataRowView)bdsKQKN.Current).Row;

				if ((Convert.ToDouble(drCurrent["SO_LUONG"]) == 0 && Convert.ToDouble(drCurrent["TL_Tap_Chat"]) == 0))
				{
					bool bIsCurrentLastRow = dgvKQKN.bIsCurrentLastRow;

					bdsKQKN.RemoveCurrent();
					//dtEditCt.AcceptChanges();

					if (bIsCurrentLastRow)
						this.SelectNextControl(dgvKQKN, true, true, true, true);

					return true;
				}

				return false;
			}
			return false;
		}

		private bool AddRow()
		{
			DataRow drCurrent = ((DataRowView)this.bdsKQKN.Current).Row;
			DataTable dtEditCt = (DataTable)this.bdsKQKN.DataSource;

			double dbTong_So_Luong = (drCurrent["SO_LUONG"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent["SO_LUONG"]);
			double db_KL_HMS1 = (drCurrent["KL_HMS1"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent["KL_HMS1"]);
			double db_KL_HMS2 = (drCurrent["KL_HMS2"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent["KL_HMS2"]);
			double db_KL_HMS3 = (drCurrent["KL_HMS3"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent["KL_HMS3"]);
			double db_Tap_Chat = (drCurrent["TAP_CHAT"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent["TAP_CHAT"]);

			bool bNewRow;

			if (dbTong_So_Luong + db_KL_HMS1 + db_KL_HMS2 + db_KL_HMS3 == 0)
				bNewRow = false;
			else
				bNewRow = true;

			if (bNewRow)
			{
				DataRow dr = dtKQKN.NewRow();
				Common.SetDefaultDataRow(ref dr);
				dtKQKN.Rows.Add(dr);
			}

			return bNewRow;
		}

		private void Update_Detail(string strColumnList)
		{// Update du lieu tu drPh xuong dtCt theo danh sach strColumnList

			strColumnList = strColumnList.Replace(" ", "");

			foreach (DataRow dr in dtKQKN.Rows)
			{
				if (dr.RowState == DataRowState.Deleted)
					continue;

				dr["Stt_Org"] = strStt;
			//	dr["Tong_So_Luong"] = numTong_So_Luong.Value;
			}
		}
		public  bool Save()
		{
			if (dtKQKN.Rows.Count == 0)
				return false;

			// Luu Detail CostSheet
			SqlCommand sqlCom = SQLExec.GetSQLCommand();
			sqlCom.CommandType = CommandType.StoredProcedure;

			sqlCom.Parameters.Clear();
			sqlCom.CommandText = "Sp_Update_KETQUATAU";

			sqlCom.Parameters.AddWithValue("@strNew_Edit", strEdit);
			sqlCom.Parameters.AddWithValue("@STT_ORG", strStt);
			sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_Data.ToString());

			SqlParameter sqlParaCt = new SqlParameter();
			sqlParaCt.SqlDbType = SqlDbType.Structured;


			sqlParaCt.ParameterName = "@Ct";
			sqlParaCt.TypeName = "TVP_KETQUATAU";
			sqlParaCt.Value = GetTVPValue("R02KETQUATAU", "TVP_KETQUATAU", dtKQKN);
			sqlCom.Parameters.Add(sqlParaCt);


			try
			{
				sqlCom.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Common.MsgOk(ex.Message);
				return false;
			}
			return true;
		}

		private DataTable GetTVPValue(string strTableName, string strTableTypeName, DataTable dtTableSource)
		{
			//Tạo cấu trúc bảng 

			string strSQLExec = @"
					DECLARE @_ColList VARCHAR(4000)
					SELECT @_ColList =  CASE WHEN @_ColList IS NULL THEN '' ELSE @_ColList + ',' END + Name 
							FROM sys.columns 
							WHERE object_id IN (SELECT Type_Table_object_id FROM sys.table_types where name = '" + strTableTypeName + @"') 
							ORDER BY column_id
					SELECT @_ColList";

			string strColList = (string)SQLExec.ExecuteReturnValue(strSQLExec);
			DataTable dtTVPStructure = DataTool.SQLGetDataTable(strTableName, strColList, "0=1", ""); //Lấy cấu trúc bảng từ Bàng nguồn theo cấu trúc TableType

			//Copy dữ liệu vào bảng tham số
			if (dtTableSource != null)
			{
				foreach (DataRow drSource in dtTableSource.Rows)
				{
					if (drSource.RowState == DataRowState.Deleted)
						continue;

					if (drSource.Table.Columns.Contains("Deleted") && (bool)drSource["Deleted"])
						continue;

					DataRow drNew = dtTVPStructure.NewRow();
					DataTool.SetDefaultDataRow(ref drNew);

					Common.CopyDataRow(drSource, drNew);
					dtTVPStructure.Rows.Add(drNew);
				}
			}

			return dtTVPStructure;
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (Save() == false)
			{
				Common.MsgOk("Không lưu dược !!!");
				this.Is_Accept = false;
			}
			else
			{
				this.Is_Accept = true;
				//this.dbCharge_Weight = numToTal_CW.Value;
			}
			this.Close();
		}
		#endregion
	}
}
