using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Element;
using RosyList;
using System.Data.SqlClient;

namespace RosyModule.Salary
{
	public partial class frmBangLuongKy1 : RosySystem.Customize.frmView
	{
        string strMa_Bp;
        string strLoai_PBQL;
		private DataTable dtBangLuong;
		private DataTable dtDmTn;

		private BindingSource bdsBangLuong = new BindingSource();
		private DataRow drCurrent;
		private rsDataGridView dgvBangLuong = new rsDataGridView();

        bool is_Re = false;
        string strReportFile = "rptLuongUng";
        DataTable dtDmBp;
        DataTable dtDmBpCt;
        DataSet dsBp;

        public frmBangLuongKy1()
		{
			InitializeComponent();

			cboThang.SelectedValueChanged += new EventHandler(cboThang_SelectedValueChanged);
			cboMa_Bp.TextChanged += new EventHandler(cboMa_Bp_TextChanged);
            cboMa_Bp_Ct.TextChanged += new EventHandler(cboMa_Bp_Ct_TextChanged);
			
            btCreateSalary.Click += new EventHandler(btCreateSalary_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
            btUpdate.Click += new EventHandler(btUpdate_Click);
            btXoa.Click += new EventHandler(btXoa_Click);
            dgvBangLuong.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvBangLuong_CellMouseClick);
            dgvBangLuong.CellValidated+=new DataGridViewCellEventHandler(dgvBangLuong_CellValidated);
            dgvBangLuong.CellEnter += new DataGridViewCellEventHandler(dgvBangLuong_CellEnter);

			this.KeyDown += new KeyEventHandler(frmBangLuong_KeyDown);
            dgvBangLuong.KeyDown += new KeyEventHandler(dgvBangLuong_KeyDown);
		}

        

       
      
		public override void Load()
		{

            LoadThang();
            Voucher.LoadComboBp((rsMultiComboBox)cboMa_Bp, (rsMultiComboBox)cboMa_Bp_Ct);
            cboMa_Bp.Text = "****";

            ////Gắn Ma_Bp vào ComboBox
            //dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", CommandType.StoredProcedure);
            //dtDmBp = dsBp.Tables[0];
          
            //if (!Element.sysIs_Admin & !Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) & !Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access) & !Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access))
            //{
            //    cboMa_Bp.Enabled = false;
            //    Hashtable ht = new Hashtable();
            //    ht.Add("MA_BP", strMa_Bp);
            //    dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", CommandType.StoredProcedure);
            //    dtDmBp = dsBp.Tables[0];
            //    DataRow dr = dtDmBp.Rows[0];
            //    cboMa_Bp.Text = dr["Ma_Bp"].ToString();
               
            //    if (cboMa_Bp.Text != "")
            //    {
                   
            //        dtDmBpCt = dsBp.Tables[1];
            //        cboMa_Bp_Ct.lstItem.BuildListView("Ma_Bp_Ct:100,Ten_Bp_Ct:200");
            //        cboMa_Bp_Ct.lstItem.DataSource = dtDmBpCt;
            //        cboMa_Bp_Ct.lstItem.Size = new Size(400, cboMa_Bp_Ct.lstItem.Items.Count * 20);
            //        cboMa_Bp_Ct.lstItem.GridLines = true;
            //    }
            //}

            //cboMa_Bp.lstItem.BuildListView("Ma_Bp:100,Ten_Bp:200");
            //cboMa_Bp.lstItem.DataSource = dtDmBp;
            //cboMa_Bp.lstItem.Size = new Size(400, cboMa_Bp.lstItem.Items.Count * 15);
            //cboMa_Bp.lstItem.GridLines = true;

            

			this.Build();
			this.FillData();
			this.BindingLanguage();

			

			this.Show();
		}

		#region Methods
        private void LoadThang()
        {
            DataTable dtThang = SQLExec.ExecuteReturnDt("SELECT DISTINCT MONTH(Ngay_Ct) AS Thang FROM R10BangLuong WHERE YEAR(Ngay_Ct) = " + Element.sysWorkingYear.ToString()+" ORDER BY MONTH(Ngay_Ct) DESC");
            if (dtThang.Rows.Count == 0)
                dtThang = SQLExec.ExecuteReturnDt("SELECT 1 AS Thang");

            if (dtThang != null)
            {
                cboThang.ValueMember = "THANG";
                cboThang.DisplayMember = "THANG";
                cboThang.DataSource = dtThang;
                //cboThang.SelectedIndex = cboThang.Items.Count - 1;
            }
        }
		private void Build()
		{
			//Build
			dgvBangLuong.strZone = "LUONGUNG";
			dgvBangLuong.Dock = DockStyle.Fill;
			dgvBangLuong.BuildGridView();
			dgvBangLuong.Columns["Ma_Dt_CbNv"].Frozen = true;
			dgvBangLuong.Columns["Ten_Dt_CbNv"].Frozen = true;
            dgvBangLuong.Columns["Ma_Bp_Ct"].Frozen = true;
			this.panel1.Controls.Add(dgvBangLuong);

            dgvBangLuong.ReadOnly = false;

            foreach (DataGridViewColumn dc in dgvBangLuong.Columns)
                dc.ReadOnly = true;

            dgvBangLuong.Columns["Tien"].ReadOnly = false;
            dgvBangLuong.Columns["Tien"].DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;

            ExportControl = dgvBangLuong;
		}

		private void FillData()
		{
			//Lấy nội dung bảng lương
			Hashtable htPara = new Hashtable();
			htPara.Add("THANG", cboThang.SelectedValue);
			htPara.Add("NAM", Element.sysWorkingYear);
			htPara.Add("MA_BP", cboMa_Bp.Text);
            htPara.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
            htPara.Add("IS_RE", is_Re);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            dtBangLuong = SQLExec.ExecuteReturnDt("sp_HRM_GetLuongUng", htPara, CommandType.StoredProcedure);

			bdsBangLuong.DataSource = dtBangLuong;
			dgvBangLuong.DataSource = bdsBangLuong;

            this.ExportControl = dgvBangLuong;
            bdsSearch = bdsBangLuong;
		}

		

		
		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsBangLuong.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (enuNew_Edit == enuEdit.New)
				return;

			if (bdsBangLuong.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsBangLuong.Current).Row, ref drCurrent);
			else
				drCurrent = dtBangLuong.NewRow();

			frmBangLuong_Edit frmEdit = new frmBangLuong_Edit();
			frmEdit.Load(drCurrent, Convert.ToInt32(this.cboThang.SelectedValue));

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsBangLuong.Position >= 0)
						dtBangLuong.ImportRow(drCurrent);
					else
						dtBangLuong.Rows.Add(drCurrent);

					bdsBangLuong.Position = bdsBangLuong.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsBangLuong.Current).Row);
				}

				dtBangLuong.AcceptChanges();
			}
		}

		

		#endregion

		#region Event
        void btXoa_Click(object sender, EventArgs e)
        {
            string strMess = Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có chắc chắn xóa bảng lương tháng ?" : "Are you sure delete salary table month ?" + this.cboThang.SelectedValue;

            if (Common.MsgYes_No(strMess, "N"))
            {
                Hashtable htPara = new Hashtable();
                htPara.Add("THANG", cboThang.SelectedValue);
                htPara.Add("NAM", Element.sysWorkingYear);
                htPara.Add("MA_BP", cboMa_Bp.Text);
                htPara.Add("MA_CBNV", string.Empty);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                if (SQLExec.Execute("sp_HRM_DeleteBangLuong", htPara, CommandType.StoredProcedure))
                {
                    this.FillData();
                }
            }
        }

        void btUpdate_Click(object sender, EventArgs e)
        {
            UpdateLuongUng();
            is_Re = false;
            Common.MsgOk("Đã cập nhật xong!!!");
            FillData();

        }
        void btRefresh_Click(object sender, EventArgs e)
        {
            is_Re = true;
            FillData();
        }
        void btPrint_Click(object sender, EventArgs e)
        {
            if (DataTool.SQLCheckExist("R10LUONGUNG", new string[] { "Nam", "Thang", "Lock" }, new object[] { Element.sysWorkingYear, cboThang.Text, false }))
            {
                if (Common.MsgYes_No("Bạn có khóa dữ liệu lương kì 1 tháng " + cboThang.Text + " năm " + Element.sysWorkingYear, "Y"))
                {
                    SQLExec.Execute("UPDATE R10LUONGUNG SET Lock = 1 WHERE Nam = " + Element.sysWorkingYear + " AND Thang = " + cboThang.Text + "");

                    foreach (DataRow dr in dtBangLuong.Rows)
                        dr["Lock"] = true;
                }
            }
            print(true);
        }
		void btCreateSalary_Click(object sender, EventArgs e)
		{
			frmBangLuong_Create frmCreate = new frmBangLuong_Create();
			frmCreate.Load(Convert.ToInt32(this.cboThang.SelectedValue), cboMa_Bp.Text.Trim(), string.Empty);

			if (frmCreate.isAccept)
			{
                LoadThang();
				this.FillData();
			}
		}

		
      
		
        void dgvBangLuong_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Control:
                            this.print(true);
                            break;

                        case Keys.Shift:
                            this.Design();
                            break;

                        case Keys.None:
                            this.print(false);
                            break;
                    }
                    break;
            }
        }
		void frmBangLuong_KeyDown(object sender, KeyEventArgs e)
		{
			//if (e.KeyCode == Keys.F12)
			//{
				
			//}
		}

		void cboThang_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.ActiveControl == cboThang)
				this.FillData();
		}
        private bool print(bool bPreview)
        {
      
            if (bdsBangLuong.Position < 0)
                return false;


          

            Hashtable ht = new Hashtable();

            ht.Add("THANG", cboThang.SelectedValue);
            ht.Add("NAM", Element.sysWorkingYear);
            ht.Add("IS_LUUCTY", chkLuuCty.Checked);

            DataSet ds = SQLExec.ExecuteReturnDs("Sp_HRM_PrintLuongUng", ht, CommandType.StoredProcedure);
            DataTable dtHeader = ds.Tables[0];
            DataTable dtDetail = ds.Tables[1];


            if (!dtHeader.Columns.Contains("REPORT_FILE"))
                dtHeader.Columns.Add("REPORT_FILE", typeof(string));
            if (!dtHeader.Columns.Contains("NGAY_CT"))
                dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));

            if (chkLuuCty.Checked == true)
                strReportFile = "rptLuongUngCty";

            dtHeader.Rows[0]["REPORT_FILE"] = strReportFile;
            dtHeader.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;


            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);
        }
        private void Design()
        {
            if (chkLuuCty.Checked == true)
                strReportFile = "rptLuongUngCty";

            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
        }
        void UpdateLuongUng()
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@THANG", cboThang.SelectedValue);
            sqlCom.Parameters.AddWithValue("@NAM", Element.sysWorkingYear);
            sqlCom.Parameters.AddWithValue("@MA_DVCS", Element.sysMa_DvCs);
            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_LuongUng";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_LUONGUNG";
            paraCt.Value = Voucher.GetTVPValue("R10LUONGUNG", "TVP_LUONGUNG", dtBangLuong);
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

            }
        }
		void cboMa_Bp_TextChanged(object sender, EventArgs e)
		{
			if (cboMa_Bp.lviItem != null)
				lbtTen_Bp.Text = cboMa_Bp.lviItem.SubItems["Ten_Bp"].Text;

            if (cboMa_Bp.Text == string.Empty)
                return;
            else
            {
                Voucher.LoadComboBp(cboMa_Bp, cboMa_Bp_Ct);
            }
			this.FillData();
		}
        void cboMa_Bp_Ct_TextChanged(object sender, EventArgs e)
        {
            if (cboMa_Bp_Ct.lviItem != null)
                lbtTen_Bp_Ct.Text = cboMa_Bp_Ct.lviItem.SubItems["Ten_Bp_Ct"].Text;

            if (cboMa_Bp_Ct.Text == string.Empty)
                return;

            this.FillData();
        }
        void dgvBangLuong_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsBangLuong.Current).Row;
            DataGridViewCell dgvCell = ((rsDataGridView)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if ((string)drCurrent["Ma_Dt_CbNv"] == string.Empty)
                return;

        }
		void dgvBangLuong_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			drCurrent = ((DataRowView)bdsBangLuong.Current).Row;
			DataGridViewCell dgvCell = ((rsDataGridView)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (!dgvCell.IsInEditMode)
				return;

			if ((string)drCurrent["Ma_Dt_CbNv"] == string.Empty)
				return;
           
           
		}
        void dgvBangLuong_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            drCurrent = ((DataRowView)bdsBangLuong.Current).Row;
            if (bdsBangLuong.Count == 0)
                return;

            if ((bool)drCurrent["Lock"] == true)
                dgvBangLuong.Columns["Tien"].ReadOnly = true;
            else
                dgvBangLuong.Columns["Tien"].ReadOnly = false;
        }
	

		#endregion
	}
}
