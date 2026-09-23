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
	public partial class frmBangLuongSP : RosySystem.Customize.frmView
	{
        string strMa_Bp;
        string strLoai_PBQL;
		private DataTable dtBangLuong;
		private DataTable dtDmTn;

		private BindingSource bdsBangLuong = new BindingSource();
		private DataRow drCurrent;
		private rsDataGridView dgvBangLuong = new rsDataGridView();

        private DataTable dtCBNVList;
        private BindingSource bdsCBNVList = new BindingSource();
        private rsDataGridView dgvCBNVList = new rsDataGridView();

        DataTable dtDmBp;
        DataTable dtDmBpCt;
        DataSet dsBp;
        bool bIs_Re = false;

        string strNote1 = "Nhấn F6 để xem danh sách CBNV có thay đổi vị trí mã bộ phận chi tiết trong tháng";
        string strNote2 = "Nhấn F6 để xem bảng lương SP";
        public frmBangLuongSP()
		{
			InitializeComponent();

			cboThang.SelectedValueChanged += new EventHandler(cboThang_SelectedValueChanged);
			cboMa_Bp.TextChanged += new EventHandler(cboMa_Bp_TextChanged);
            cboMa_Bp_Ct.TextChanged += new EventHandler(cboMa_Bp_Ct_TextChanged);
			
          
			btCalcSalary.Click += new EventHandler(btCalcSalary_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);

            btExit.Click += new EventHandler(btExit_Click);

			this.KeyDown += new KeyEventHandler(frmBangLuong_KeyDown);
            dgvBangLuong.KeyDown += new KeyEventHandler(dgvBangLuong_KeyDown);

		}

        

       
		public override void Load()
		{

            LoadThang();
			
            //đưa giá trị vào combo
            Voucher.LoadComboBp((rsMultiComboBox)cboMa_Bp, (rsMultiComboBox)cboMa_Bp_Ct);

            // Gán giá trị cho ma bp
            string strMa_Bp = Voucher.GetBpOfUser();
            if ((!Common.Inlist(strMa_Bp, "NQL,PTCHC") && !Element.sysIs_Admin))
            {
                cboMa_Bp.Text = strMa_Bp;
                cboMa_Bp.Enabled = false;
            }
            else if (Element.sysIs_Admin)
                cboMa_Bp.Text = "PCNTT";
            else if (Common.Inlist(strMa_Bp, "NQL,PTCHC"))
            {
                cboMa_Bp.Text = "PTCHC";
                cboMa_Bp.Enabled = true;
            }

            Lock();

          
			
            this.Build();
			this.FillData();
			this.BindingLanguage();

            lblNote.Text = strNote1;
            dgvBangLuong.Visible = true;
            dgvCBNVList.Visible = false;

			this.Show();
		}

		#region Methods
        private void Lock()
        {
            bool bLock = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Lock_Luong FROM R00LOCKEDLUONG WHERE NAM = " + Element.sysWorkingYear + " AND Thang = " + cboThang.Text + ""));
            if (bLock)
                btCalcSalary.Enabled = false;
            else
                btCalcSalary.Enabled = true;
        }
        private void LoadThang()
        {
            DataTable dtThang = SQLExec.ExecuteReturnDt("SELECT DISTINCT MONTH(Ngay_Ct) AS Thang FROM R10BangLuong WHERE YEAR(Ngay_Ct) = " + Element.sysWorkingYear.ToString() + " ORDER BY MONTH(Ngay_Ct) DESC");
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
			dgvBangLuong.strZone = "LUONGSP";
			dgvBangLuong.Dock = DockStyle.Fill;
			dgvBangLuong.BuildGridView();
			dgvBangLuong.Columns["Ma_Dt_CbNv"].Frozen = true;
			dgvBangLuong.Columns["Ten_Dt_CbNv"].Frozen = true;


            dgvCBNVList.strZone = "CBNVCHANGE";
            dgvCBNVList.Dock = DockStyle.Fill;
            dgvCBNVList.BuildGridView();

			this.panel1.Controls.Add(dgvBangLuong);
            this.panel1.Controls.Add(dgvCBNVList);

           
		}

		private void FillData()
		{
            Hashtable htSl = new Hashtable();
            htSl.Add("THANG", cboThang.SelectedValue);
			htSl.Add("NAM", Element.sysWorkingYear);
            DataTable dt = SQLExec.ExecuteReturnDt("sp_GetSLBangLuong", htSl, CommandType.StoredProcedure);

            if (dt.Rows.Count > 0)
            {
                numKD.Value = Convert.ToDouble(dt.Rows[0]["So_Luong"]);
                numLKipA.Value = Convert.ToDouble(dt.Rows[1]["So_Luong"]);
                numLKipB.Value = Convert.ToDouble(dt.Rows[2]["So_Luong"]);
                numLKipC.Value = Convert.ToDouble(dt.Rows[3]["So_Luong"]);
                numCKipA.Value = Convert.ToDouble(dt.Rows[4]["So_Luong"]);
                numCKipB.Value = Convert.ToDouble(dt.Rows[5]["So_Luong"]);
                numCKipC.Value = Convert.ToDouble(dt.Rows[6]["So_Luong"]);

            }
			//Lấy cấu trúc các cột
			dtDmTn = SQLExec.ExecuteReturnDt("SELECT * FROM R10DmTn ORDER BY Stt");
            

			//Lấy nội dung bảng lương
			Hashtable htPara = new Hashtable();
			htPara.Add("THANG", cboThang.SelectedValue);
			htPara.Add("NAM", Element.sysWorkingYear);
			htPara.Add("MA_BP", cboMa_Bp.Text);
            htPara.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
            htPara.Add("IS_RE", bIs_Re);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            dtBangLuong = SQLExec.ExecuteReturnDt("sp_HRM_GetBangLuongSP", htPara, CommandType.StoredProcedure);

			bdsBangLuong.DataSource = dtBangLuong;
			dgvBangLuong.DataSource = bdsBangLuong;

            //Lấy nội dung bảng lương
            Hashtable htPara1 = new Hashtable();
            htPara1.Add("THANG", cboThang.SelectedValue);
            htPara1.Add("NAM", Element.sysWorkingYear);
            htPara1.Add("MA_BP", cboMa_Bp.Text);
            htPara1.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
            htPara1.Add("IS_RE", bIs_Re);
            htPara1.Add("MA_DVCS", Element.sysMa_DvCs);
            dtCBNVList = SQLExec.ExecuteReturnDt("sp_HRM_GetChangeBPCT", htPara1, CommandType.StoredProcedure);

            bdsCBNVList.DataSource = dtCBNVList;
            dgvCBNVList.DataSource = bdsCBNVList;


            this.ExportControl = dgvBangLuong;
            bdsSearch = bdsBangLuong;
		}

		

		private void CalSalary()
		{
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@MA_DVCS", Element.sysMa_DvCs);
            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "Sp_HRM_CalcLuongSP_TVP";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_LUONGSP";
            paraCt.Value = Voucher.GetTVPValue("R10BANGLUONGSP", "TVP_LUONGSP", dtBangLuong);
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
            bIs_Re = false;
			this.FillData();
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
        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CheckCong()
        {
            // kiểm tra xem có bảng công trong tháng chưa
            if (cboMa_Bp.Text != "" && !cboMa_Bp.Text.StartsWith("*"))
            {
                DataTable dtCong = SQLExec.ExecuteReturnDt("SELECT * FROM R10BANGCONG WHERE Thang = " + cboThang.Text + " AND Nam = " + Element.sysWorkingYear + " AND Ma_Bp = '" + cboMa_Bp.Text + "'");
                bool bCong = Convert.ToBoolean(dtCong.Rows.Count > 0 ? 1 : 0);
                if (!bCong)
                {
                    Common.MsgOk("Bảng công hiện chưa được duyệt để tính lương SP. Đề nghị trưởng đơn vị duyệt bảng công trước khi tính lương SP!!!");
                    return false;
                }
            }
            return true;
        }
		void btCalcSalary_Click(object sender, EventArgs e)
		{
            
            CheckCong();
			this.CalSalary();
		}

        void btRefresh_Click(object sender, EventArgs e)
        //{
            Lock();
            bIs_Re = true;
            CheckCong();
            FillData();
        }

        void dgvBangLuong_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
               
            }
        }
		void frmBangLuong_KeyDown(object sender, KeyEventArgs e)
		{
            //if (e.KeyCode == Keys.F6)
            //{
            //    if (lblNote.Text == strNote1)
            //    {
            //        dgvCBNVList.Visible = true;
            //        dgvBangLuong.Visible = false;
            //        lblNote.Text = strNote2;
            //    }
            //    else
            //    {
            //        dgvCBNVList.Visible = true;
            //        dgvBangLuong.Visible = false;
            //        lblNote.Text = strNote1;
            //    }
            //}
            
		}
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    if (dgvCBNVList.Visible == false)
                    {
                        dgvBangLuong.Visible = false;
                        dgvCBNVList.Visible = true;
                        lblNote.Text = strNote2;
                    }
                    else
                    {
                        dgvBangLuong.Visible = true;
                        dgvCBNVList.Visible = false;
                        lblNote.Text = strNote1;
                    }
                    break;
            }
        }
		void cboThang_SelectedValueChanged(object sender, EventArgs e)
		{
            if (this.ActiveControl == cboThang)
            {
                Lock();
                this.FillData();
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
                Hashtable ht = new Hashtable();
                ht.Add("MA_BP", cboMa_Bp.Text);
                dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", ht, CommandType.StoredProcedure);
                dtDmBpCt = dsBp.Tables[1];
                cboMa_Bp_Ct.lstItem.BuildListView("Ma_Bp_Ct:100,Ten_Bp_Ct:200");
                cboMa_Bp_Ct.lstItem.DataSource = dtDmBpCt;
                cboMa_Bp_Ct.lstItem.Size = new Size(500, cboMa_Bp_Ct.lstItem.Items.Count * 12);
                cboMa_Bp_Ct.lstItem.GridLines = true;
              
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

		

		#endregion
	}
}
