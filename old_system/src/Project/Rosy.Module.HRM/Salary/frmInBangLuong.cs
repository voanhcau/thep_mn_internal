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
	public partial class frmInBangLuong : RosySystem.Customize.frmView
	{
        string strMa_Bp;
        string strLoai_PBQL;
		private DataTable dtBangLuong;
		private DataTable dtDmTn;

		private BindingSource bdsBangLuong = new BindingSource();
		private DataRow drCurrent;
		private rsDataGridView dgvBangLuong = new rsDataGridView();

        DataTable dtDmBp;
        DataTable dtDmBpCt;
        DataSet dsBp;
        bool bDD = false;

        public frmInBangLuong()
		{
			InitializeComponent();

			cboThang.SelectedValueChanged += new EventHandler(cboThang_SelectedValueChanged);
			cboMa_Bp.TextChanged += new EventHandler(cboMa_Bp_TextChanged);
            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);


            btPrint.Click += new EventHandler(btPrint_Click);
            //btImportDD.Click += new EventHandler(btImportDD_Click);
            btExit.Click += new EventHandler(btExit_Click);
			this.KeyDown += new KeyEventHandler(frmBangLuong_KeyDown);
            dgvBangLuong.KeyDown += new KeyEventHandler(dgvBangLuong_KeyDown);
		}

        

        
		public override void Load()
		{
            LoadThang();
            //đưa giá trị vào combo
            Voucher.LoadComboBp((rsMultiComboBox)cboMa_Bp, (rsMultiComboBox)cboMa_Bp_Ct);
            string strMa_Bp = Voucher.GetBpOfUser();
            cboMa_Bp.Text = strMa_Bp;
            cboMa_Bp.Enabled = false;

			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.ShowBangLuong();

			this.Show();
		}

		#region Methods
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
            ////Build
            //dgvBangLuong.strZone = "BANGCONG";
            //dgvBangLuong.Dock = DockStyle.Fill;
            //dgvBangLuong.BuildGridView();
            //dgvBangLuong.Columns["Ma_Dt_CbNv"].Frozen = true;
            //dgvBangLuong.Columns["Ten_Dt_CbNv"].Frozen = true;
            //dgvBangLuong.Columns["Ma_Bp_Ct"].Frozen = true;
            //this.panel1.Controls.Add(dgvBangLuong);
		}

		private void FillData()
		{
          

            ////Lấy nội dung bảng công
            //Hashtable htPara = new Hashtable();
            //htPara.Add("THANG", cboThang.SelectedValue);
            //htPara.Add("NAM", Element.sysWorkingYear);
            //htPara.Add("MA_BP", cboMa_Bp.Text);
            //htPara.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
            //htPara.Add("MA_DVCS", Element.sysMa_DvCs);            

            //dtBangLuong = SQLExec.ExecuteReturnDt("sp_HRM_GetBangCong", htPara, CommandType.StoredProcedure);

            //bdsBangLuong.DataSource = dtBangLuong;
            //dgvBangLuong.DataSource = bdsBangLuong;
		}

		private void ShowBangLuong()
		{
			//1-THANHTOAN
			//2-THUNHAP
			//3-TRULUONG

			dgvBangLuong.ReadOnly = false;
		}

		

		public override void Edit(enuEdit enuNew_Edit)
		{
            //if (bdsBangLuong.Position < 0 && enuNew_Edit == enuEdit.Edit)
            //    return;

            //if (enuNew_Edit == enuEdit.New)
            //    return;

            //if (bdsBangLuong.Position >= 0)
            //    Common.CopyDataRow(((DataRowView)bdsBangLuong.Current).Row, ref drCurrent);
            //else
            //    drCurrent = dtBangLuong.NewRow();

            //frmBangLuong_Edit frmEdit = new frmBangLuong_Edit();
            //frmEdit.Load(drCurrent, Convert.ToInt32(this.cboThang.SelectedValue));

            //// người dùng chọn chấp nhận
            //if (frmEdit.isAccept)
            //{
            //    if (enuNew_Edit == enuEdit.New)
            //    {
            //        if (bdsBangLuong.Position >= 0)
            //            dtBangLuong.ImportRow(drCurrent);
            //        else
            //            dtBangLuong.Rows.Add(drCurrent);

            //        bdsBangLuong.Position = bdsBangLuong.Find("Ident00", drCurrent["Ident00"]);
            //    }
            //    else
            //    {
            //        Common.CopyDataRow(drCurrent, ((DataRowView)bdsBangLuong.Current).Row);
            //    }

            //    dtBangLuong.AcceptChanges();
            //}
		}

	

		#endregion

		#region Event
        //void btImportDD_Click(object sender, EventArgs e)
        //{
        //    bDD = true;
        //    frmReadExcel_BangCong frm = new frmReadExcel_BangCong();
        //    frm.Load();
        //    if (frm.isAccept && frm.dtImport != null)
        //    {
        //        try
        //        {
        //            UpdateDLLuong(frm.dtImport, bDD);
        //            Common.MsgOk(Languages.GetLanguage("IMPORT_SUCCESS"));
        //            this.FillData();
        //        }
        //        catch (Exception ex)
        //        {
        //            Common.MsgOk(ex.Message);
        //        }


        //    }
        //}
        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //void btImport_Click(object sender, EventArgs e)
        //{
        //    bDD = false;
        //    frmReadExcel_BangCong frm = new frmReadExcel_BangCong();
        //    frm.Load();
        //    if (frm.isAccept && frm.dtImport != null)
        //    {
        //        try
        //        {
        //            UpdateDLLuong(frm.dtImport, bDD);
        //            Common.MsgOk(Languages.GetLanguage("IMPORT_SUCCESS"));
        //            this.FillData();
        //        }
        //        catch (Exception ex)
        //        {
        //            Common.MsgOk(ex.Message);
        //        }
               
                
        //    }
        //}

        //void UpdateDLLuong(DataTable dtImport, bool bDD)
        //{
        //    SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
        //    SqlCommand sqlCom = sqlCon.CreateCommand();

        //    sqlCom.CommandText = "sp_Update_Ct";
        //    sqlCom.CommandType = CommandType.StoredProcedure;

        //    sqlCom.Parameters.Clear();
        //    sqlCom.Parameters.AddWithValue("@THANG", cboThang.SelectedValue);
        //    sqlCom.Parameters.AddWithValue("@NAM", Element.sysWorkingYear);
        //    sqlCom.Parameters.AddWithValue("@MA_BP", cboMa_Bp.Text);
        //    sqlCom.Parameters.AddWithValue("@ISDD", bDD);
        //    sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());
        //    sqlCom.Parameters.AddWithValue("@MA_DVCS", Element.sysMa_DvCs);
        //    //Tạo Table cho TVP_PH
        //    SqlParameter paraCt = new SqlParameter();
        //    paraCt.SqlDbType = SqlDbType.Structured;
        //    paraCt.ParameterName = "@TVP_Import";

        //    sqlCom.CommandText = "sp_Update_DLCONG";
        //    //sp_Update_KHVTPT

        //    //TVP_CT
        //    paraCt.TypeName = "TVP_DLCONG";
        //    paraCt.Value = Voucher.GetTVPValue("R10BANGCONG", "TVP_DLCONG", dtImport);
        //    sqlCom.Parameters.Add(paraCt);

        //    try
        //    {
        //        sqlCom.ExecuteNonQuery();

        //    }
        //    catch (Exception ex)
        //    {
        //        sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
        //        sqlCom.CommandType = CommandType.Text;
        //        sqlCom.Parameters.Clear();
        //        sqlCom.ExecuteNonQuery();

        //        MessageBox.Show("Có lỗi xảy ra :" + ex.Message);

        //    }
        //}
        void dgvBangLuong_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
               
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
                //cboMa_Bp_Ct.lstItem.BuildListView("Ma_Bp_Ct:100,Ten_Bp_Ct:200");
                //cboMa_Bp_Ct.lstItem.DataSource = dtDmBpCt;
                //cboMa_Bp_Ct.lstItem.Size = new Size(500, cboMa_Bp_Ct.lstItem.Items.Count * 12);
                //cboMa_Bp_Ct.lstItem.GridLines = true;
              
            }
			this.FillData();
		}
        void cboMa_Bp_Ct_TextChanged(object sender, EventArgs e)
        {
            //if (cboMa_Bp_Ct.lviItem != null)
            //    lbtTen_Bp_Ct.Text = cboMa_Bp_Ct.lviItem.SubItems["Ten_Bp_Ct"].Text;

            //if (cboMa_Bp_Ct.Text == string.Empty)
            //    return;

            this.FillData();
        }
       
           
	

		

		#endregion

        void btPrint_Click(object sender, EventArgs e)
        {
            Voucher.PrintPhieuLuong(Convert.ToInt16(cboThang.SelectedValue), Element.sysWorkingYear, true, txtMa_Dt_CbNv.Text);
        }

        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = RosySystem.Public.Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "Ma_Bp = '" + cboMa_Bp.Text + "'", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv.Text = string.Empty;
                lbtTen_Dt_CbNv.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt_CbNv.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }
        }
	}
}
