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

namespace RosyModule.HRM
{
	public partial class frmVTPTVao : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInheritVoucher;
		BindingSource bdsInheritVoucher = new BindingSource();

		DataRow drCurrent, drDmCt_Current, drInheritVoucher;
		public bool Is_Accept = false;
        public string strLoai_Ct = string.Empty;
        string strStt = string.Empty;
        string strSo_Ct = string.Empty;

        private DataTable dtDGBPCT;
        private BindingSource bdsDGBPCT = new BindingSource();
        private rsDataGridView dgvDGBPCT = new rsDataGridView();

        private DataTable dtGiaDGBPCT;
        private BindingSource bdsGiaDGBPCT = new BindingSource();
        private rsDataGridView dgvGiaDGBPCT = new rsDataGridView();

		#endregion

		#region Contructor
        string strColumnNameBeforeAddRow = string.Empty;//Lưu lại cột trước khi thêm mới một hàng
        public frmVTPTVao()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            //this.btRefresh.Click += new EventHandler(btRefresh_Click);

            this.dgvInheritVoucher.CellValidating += new DataGridViewCellValidatingEventHandler(dgvInheritVoucher_CellValidating);
            this.dgvGiaDGBPCT.CellValidated += new DataGridViewCellEventHandler(dgvGiaDGBPCT_CellValidated);
           
            this.KeyDown += new KeyEventHandler(frmInheritDnTt_KeyDown);
            btAdd.Click += new EventHandler(btAdd_Click);
            btRe.Click += new EventHandler(btRe_Click);

            txtSo_Ct_Filter.LostFocus += new EventHandler(txtSo_Ct_Filter_LostFocus);
		}

        void txtSo_Ct_Filter_LostFocus(object sender, EventArgs e)
        {
            FillData();
        }

        

      
      

        
       

		#endregion

		#region Method

		public void Load(string strLoai_Ct, string strStt, string strSo_Ct)
		{
            dteNgay_Ct.Text = Library.DateToStr(Element.sysNgay_Ct2);
            dteNgay_Ra.Text = Library.DateToStr(Element.sysNgay_Ct2);
            this.strStt = strStt;
            this.strSo_Ct = strSo_Ct;
            this.strLoai_Ct = strLoai_Ct;
        

            if (strLoai_Ct == "V")
            {
                if (strSo_Ct == "")
                    txtSo_Ct.Text = CongSoCt(Library.StrToDate(dteNgay_Ct.Text));
                this.rsTabControl1.Controls.Remove(tabPage2);
                txtSo_Ct.Enabled = false;
              
            }
            else
                this.rsTabControl1.Controls.Remove(tabPage1);

			Build();
			FillData();
            Init_Ct();
			BindingLanguage();

			this.ShowDialog();
		}
        public void Load()
        {

            
                  

            Build();
            FillData();
            BindingLanguage();

            this.ShowDialog();
        }
		void Build()
		{
		    dgvInheritVoucher.strZone = "VTPTVAO";

			dgvInheritVoucher.BuildGridView();

			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

            dgvDGBPCT.ReadOnly = true;
            dgvDGBPCT.strZone = "VTPTRA1";
            dgvDGBPCT.Dock = DockStyle.Fill;


            dgvGiaDGBPCT.ReadOnly = true;
            dgvGiaDGBPCT.strZone = "VTPTRA2";
            dgvGiaDGBPCT.Dock = DockStyle.Fill;

            this.panel_ADD.Controls.Add(dgvDGBPCT);
            this.panel_REC.Controls.Add(dgvGiaDGBPCT);

            dgvDGBPCT.BuildGridView();
            dgvGiaDGBPCT.BuildGridView();

            dgvDGBPCT.ReadOnly = false;
            foreach (DataGridViewColumn dgvc in dgvDGBPCT.Columns)
                dgvc.ReadOnly = true;

            if (dgvDGBPCT.Columns.Contains("CHON"))
                dgvDGBPCT.Columns["CHON"].ReadOnly = false;

            dgvGiaDGBPCT.ReadOnly = false;
            foreach (DataGridViewColumn dgvc in dgvGiaDGBPCT.Columns)
                dgvc.ReadOnly = true;

            if (dgvGiaDGBPCT.Columns.Contains("SO_LUONG"))
                dgvGiaDGBPCT.Columns["SO_LUONG"].ReadOnly = false;
		}

		void FillData()
		{
            if (strLoai_Ct == "V")
            {
                if (strSo_Ct == string.Empty)
                    dtInheritVoucher = SQLExec.ExecuteReturnDt("SELECT *, CAST(0 AS BIT) AS Deleted FROM R09VTPT_RVC WHERE 0 =  1");
                else
                    dtInheritVoucher = SQLExec.ExecuteReturnDt("SELECT *, CAST(0 AS BIT) AS Deleted FROM R09VTPT_RVC WHERE Stt = '" + strStt + "' AND So_Ct = '" + strSo_Ct + "' AND Loai_RVC = '" + strLoai_Ct + "'");
                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
            else
            {

                Hashtable ht = new Hashtable();
                ht.Add("SO_CT", txtSo_Ct_Filter.Text);
                DataSet dsDGBPCT = SQLExec.ExecuteReturnDs("sp_GetVTPTRaCong", ht, CommandType.StoredProcedure);
                dtDGBPCT = dsDGBPCT.Tables[0];
                bdsDGBPCT.DataSource = dtDGBPCT;
                dgvDGBPCT.DataSource = bdsDGBPCT;

                dtGiaDGBPCT = dsDGBPCT.Tables[1];
                bdsGiaDGBPCT.DataSource = dtGiaDGBPCT;
                dgvGiaDGBPCT.DataSource = bdsGiaDGBPCT;

                bdsSearch = bdsDGBPCT;
                bdsLookup = bdsDGBPCT;
            }
		}
        private void Init_Ct()
        {
            if(strLoai_Ct== "V")
            {
                if (dtInheritVoucher.Rows.Count == 0)
                {
                    DataRow drNew = dtInheritVoucher.NewRow();
                    Common.SetDefaultDataRow(ref drNew);

                    drNew["Stt0"] = 1;
                    drNew["Stt"] = strStt;
                    //drNew["So_Ct"] = txtSo_Ct.Text;
                    //drNew["Ngay_Ct"] = dteNgay_Ct.Text;
                    //drNew["Ten_Dt"] = txtTen_Dt.Text.Trim();
                    drNew["Deleted"] = false;
                    dtInheritVoucher.Rows.Add(drNew);
                }
                else
                {
                    txtSo_Ct.Text = dtInheritVoucher.Rows[0]["So_Ct"].ToString();
                    txtTen_Dt.Text = dtInheritVoucher.Rows[0]["Ten_Dt"].ToString();
                    dteNgay_Ct.Text = (dtInheritVoucher.Rows[0]["Ngay_Ct"]).ToString();
                }
            }
        }
        private string CongSoCt(DateTime dtNgay_Ct)
        {
            string strSo_Ct = string.Empty;
            strSo_Ct = SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSo_Ct_VTPTRVC('"+Library.DateToStr(dtNgay_Ct)+"')").ToString();
            return strSo_Ct;
        }
		bool FormCheckValid()
		{
            //if (dtInheritVoucher == null || dtInheritVoucher.Select("Chon = true").Length == 0)
            //{
            //    Common.MsgCancel("Không có dữ liệu kế thừa!");
            //    return false;
            //}

			return true;
		}
        private void DeleteRow()
        {
            if (dgvInheritVoucher.Focused == false)
                return;

            drCurrent = ((DataRowView)bdsInheritVoucher.Current).Row;
            drCurrent["Deleted"] = !((bool)drCurrent["Deleted"]);

            if ((bool)drCurrent["Deleted"] == true)
            {
                Font font = new Font(dgvInheritVoucher.Font.FontFamily, dgvInheritVoucher.Font.Size, FontStyle.Strikeout);
                dgvInheritVoucher.CurrentRow.DefaultCellStyle.Font = font;
            }
            else
            {
                dgvInheritVoucher.CurrentRow.DefaultCellStyle.Font = dgvInheritVoucher.Font;
            }
        }
        private bool AddRow()
        {
            bool bNewRow;
            DataRow drCurrent = ((DataRowView)bdsInheritVoucher.Current).Row;
            double dbSo_Luong = Convert.ToDouble(drCurrent["So_Luong"]);
           
            if (dbSo_Luong == 0)
                bNewRow = false;
            else
                bNewRow = true;
            if (bNewRow)
            {
                //DataRow drDmBarcode = dtBarcode.Rows[0];
                bool bRow_First = false;

                DataRow drNewRow = null;

                if (dtInheritVoucher.Rows.Count == 0)
                {
                    drNewRow = dtInheritVoucher.NewRow();
                    Common.SetDefaultDataRow(ref drNewRow);
                    bRow_First = true;
                }

                if (!bRow_First)
                {
                    drInheritVoucher = ((DataRowView)bdsInheritVoucher.Current).Row;
                    drNewRow = dtInheritVoucher.NewRow();
                    Common.CopyDataRow(drInheritVoucher, drNewRow);
                    Common.SetDefaultDataRow(ref drNewRow);
                }

                int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtInheritVoucher, "Stt0") + 1);




                drNewRow["Stt"] = strStt;
                drNewRow["Stt0"] = iStt0;
                //drNewRow["So_Ct"] = txtSo_Ct.Text;
                //drNewRow["Ngay_Ct"] = dteNgay_Ct.Text;
                //drNewRow["Ten_Dt"] = txtTen_Dt.Text.Trim();
                drNewRow["Deleted"] = false;

                dtInheritVoucher.Rows.Add(drNewRow);
                dtInheritVoucher.AcceptChanges();
                return true;
            }
            return false;
        }
		#endregion

		#region Event
        private bool CellKeyEnter()
        {
            if (dgvInheritVoucher.CurrentCell == null)
                return false;

            DataGridViewCell dgvCell = dgvInheritVoucher.CurrentCell;
            string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();


            if (strCurrentColumn == "GHI_CHU")
            {
                if (!AddRow())
                    return false;
                else
                {
                    strColumnNameBeforeAddRow = strCurrentColumn;
                    dgvInheritVoucher.FocusNextFirstCell();
                }

                return true;
            }

            return false;
        }
        void dgvGiaDGBPCT_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            drCurrent = ((DataRowView)bdsGiaDGBPCT.Current).Row;
            if (strColumnName == "SO_LUONG")
            {
                if (Convert.ToDouble(drCurrent["So_Luong"]) > Convert.ToDouble(drCurrent["So_Luong_CL"]))
                    drCurrent["So_Luong"] = drCurrent["So_Luong_CL"];
            }
        }
        void dgvInheritVoucher_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            //Xu ly phim Enter
            if (dgvEditCt.kLastKey == Keys.Enter)
            {
                dgvEditCt.kLastKey = Keys.None;

                if (this.CellKeyEnter())
                    e.Cancel = true;
            }
         
        }

        private bool Save()
        {
            if (strLoai_Ct == "V")
            {
                foreach (DataRow dr in dtInheritVoucher.Rows)
                {
                    dr["Ngay_Ct"] = dteNgay_Ct.Text;
                    dr["So_Ct"] = txtSo_Ct.Text;
                    dr["Ten_Dt"] = txtTen_Dt.Text;
                }
            }
            else
                foreach (DataRow dr in dtGiaDGBPCT.Rows)
                    dr["Ngay_Ct"] = dteNgay_Ra.Text;

            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
          
            sqlCom.Parameters.AddWithValue("@STT", strStt);
            sqlCom.Parameters.AddWithValue("@SO_CT", txtSo_Ct.Text);
            sqlCom.Parameters.AddWithValue("@NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
            sqlCom.Parameters.AddWithValue("@LOAI_RVC", strLoai_Ct);
            


            sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@MA_DVCS", Element.sysMa_DvCs);
            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_VTPT_RVC";
            
            paraCt.TypeName = "TVP_VTPTRVC";
            if (strLoai_Ct == "V")//TVP_CT VÀO 
                paraCt.Value = Voucher.GetTVPValue("R09VTPT_RVC", "TVP_VTPTRVC", dtInheritVoucher);
            else
                paraCt.Value = Voucher.GetTVPValue("R09VTPT_RVC", "TVP_VTPTRVC", dtGiaDGBPCT);

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
        void btRe_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsGiaDGBPCT.Current).Row;

            DataRow drCt = dtDGBPCT.NewRow();

            drCt["Ten_Vt"] = drCurrent["Ten_Vt"];
            drCt["So_Ct"] = drCurrent["So_Ct"];
            drCt["Ngay_Ct"] = drCurrent["Ngay_Ct"];
            drCt["So_Luong"] = drCurrent["So_Luong"];

            dtDGBPCT.Rows.Add(drCt);
            dtDGBPCT.AcceptChanges();

            dtGiaDGBPCT.Rows.Remove(drCurrent);
        }
        void btAdd_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in dtDGBPCT.Select("Chon = 1"))
            {
                DataRow drCt = dtGiaDGBPCT.NewRow();
                drCt["Loai_RVC"] = strLoai_Ct;
                drCt["Stt"] = dr["Stt"];
                drCt["Stt0"] = dr["Stt0"];
                drCt["So_Ct"] = dr["So_Ct"];
                drCt["Ten_Dt"] = dr["Ten_Dt"];
                drCt["Ten_Vt"] = dr["Ten_Vt"];
                drCt["Dvt"] = dr["Dvt"];
                drCt["So_Luong"] = dr["So_Luong_CL"];
                drCt["So_Luong_CL"] = dr["So_Luong_CL"];
               drCt["Ngay_Ct"] =  dr["Ngay_Ct"];
              
              

                dtGiaDGBPCT.Rows.Add(drCt);
                dtGiaDGBPCT.AcceptChanges();

                dtDGBPCT.Rows.Remove(dr);
                
            }
        }


		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
                if (Save())
                {
                    this.Is_Accept = true;
                    this.Close();
                }
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

		
        void frmInheritDnTt_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    DeleteRow();
                    break;
            }
        }
		

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F5)
            //    this.FillData();
            //else
                base.OnKeyDown(e);
        }
		#endregion

        //private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        //{

        //}

      
	}
}
