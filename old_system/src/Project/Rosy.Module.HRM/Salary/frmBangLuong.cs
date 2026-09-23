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
	public partial class frmBangLuong : RosySystem.Customize.frmView
	{
        string strMa_Bp;
        string strLoai_PBQL;
		private DataSet dsBangLuong;
        private DataTable dtBangLuong;
        private DataTable dtDmTn;

		private BindingSource bdsBangLuong = new BindingSource();
		private DataRow drCurrent;
		private rsDataGridView dgvBangLuong = new rsDataGridView();

        DataTable dtDmBp;
        DataTable dtDmBpCt;
        DataSet dsBp;
        string strReportFile = string.Empty;
        string strLoai = string.Empty;

		public frmBangLuong()
		{
			InitializeComponent();

            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
			cboThang.SelectedValueChanged += new EventHandler(cboThang_SelectedValueChanged);
			cboMa_Bp.TextChanged += new EventHandler(cboMa_Bp_TextChanged);
            cboMa_Bp_Ct.TextChanged += new EventHandler(cboMa_Bp_Ct_TextChanged);
			
            //btUpdateSalary.Click += new EventHandler(btCreateSalary_Click);
			btCalcSalary.Click += new EventHandler(btCalcSalary_Click);
			btDeleteSalary.Click += new EventHandler(btDeleteSalary_Click);
			btPostedSalary.Click += new EventHandler(btPostedSalary_Click);
            btImport.Click += new EventHandler(btImport_Click);
            
            btPrint.Click += new EventHandler(btPrint_Click);
            btPrintPhieuLuong.Click += new EventHandler(btPrintPhieuLuong_Click);

			radioButton1.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
			radioButton2.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
			radioButton3.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);

            //dgvBangLuong.CellValidated += new DataGridViewCellEventHandler(dgvBangLuong_CellValidated);
            dgvBangLuong.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvBangLuong_CellMouseClick);

			this.KeyDown += new KeyEventHandler(frmBangLuong_KeyDown);
            dgvBangLuong.KeyDown += new KeyEventHandler(dgvBangLuong_KeyDown);
		}

       
       

        

        
		public override void Load()
		{

            LoadThang();

			//Gắn Ma_Bp vào ComboBox
            dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", CommandType.StoredProcedure);
            dtDmBp = dsBp.Tables[0];
          
            if (!Element.sysIs_Admin & !Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) & !Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access) 
                & !Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access)
                & !Common.CheckPermission("IS_ALLCBNV", enuPermission_Type.Allow_Access))
            {
                cboMa_Bp.Enabled = false;
                Hashtable ht = new Hashtable();
                ht.Add("MA_BP", strMa_Bp);
                dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", CommandType.StoredProcedure);
                dtDmBp = dsBp.Tables[0];
                DataRow dr = dtDmBp.Rows[0];
                cboMa_Bp.Text = dr["Ma_Bp"].ToString();
                strLoai_PBQL = dr["Loai_PBQL"].ToString();
                if (cboMa_Bp.Text != "")
                {
                   
                    dtDmBpCt = dsBp.Tables[1];
                    cboMa_Bp_Ct.lstItem.BuildListView("Ma_Bp_Ct:100,Ten_Bp_Ct:200");
                    cboMa_Bp_Ct.lstItem.DataSource = dtDmBpCt;
                    cboMa_Bp_Ct.lstItem.Size = new Size(400, cboMa_Bp_Ct.lstItem.Items.Count * 20);
                    cboMa_Bp_Ct.lstItem.GridLines = true;
                }
            }

			cboMa_Bp.lstItem.BuildListView("Ma_Bp:100,Ten_Bp:200");
			cboMa_Bp.lstItem.DataSource = dtDmBp;
			cboMa_Bp.lstItem.Size = new Size(400, cboMa_Bp.lstItem.Items.Count * 15);
			cboMa_Bp.lstItem.GridLines = true;

            bool bLock = Voucher.LockCongLuong("Lock_Luong", Convert.ToInt16(Element.sysWorkingYear), Convert.ToInt16(cboThang.Text), DateTime.Now, DateTime.Now);// Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Lock_Luong FROM R00LOCKEDLUONG WHERE NAM = " + Element.sysWorkingYear + " AND Thang = " + cboThang.Text + ""));
            if (bLock)
            {
                btCalcSalary.Enabled = false;
                btImport.Enabled = false;
                
            }
            else
            {
                btCalcSalary.Enabled = true;
                btImport.Enabled = true;
            }

            
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.ShowBangLuong();

			this.Show();
		}
        private void GetLuongDP()
        {
            //lấy thông tin Lương SD nguồn dự phòng
            numTTLuongDP.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT MAX(TTLuongDP) FROM R10SLTL WHERE NAM = " + Element.sysWorkingYear + " AND Thang = " + cboThang.Text + " "));
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
			//Build
			dgvBangLuong.strZone = "BANGLUONG";
			dgvBangLuong.Dock = DockStyle.Fill;
			dgvBangLuong.BuildGridView();
			dgvBangLuong.Columns["Ma_Dt_CbNv"].Frozen = true;
			dgvBangLuong.Columns["Ten_Dt_CbNv"].Frozen = true;

			this.panel1.Controls.Add(dgvBangLuong);
		}

		private void FillData()
		{
            //Hashtable htSl = new Hashtable();
            //htSl.Add("THANG", cboThang.SelectedValue);
            //htSl.Add("NAM", Element.sysWorkingYear);
            //DataTable dt = SQLExec.ExecuteReturnDt("sp_GetSLBangLuong", htSl, CommandType.StoredProcedure);

            //numLuyen.Value = Convert.ToDouble(dt.Rows[0]["So_Luong"]);
            //numCan.Value = Convert.ToDouble(dt.Rows[1]["So_Luong"]);
            //numKD.Value = Convert.ToDouble(dt.Rows[2]["So_Luong"]);
            //numHSQD.Value = Convert.ToDouble(dt.Rows[3]["So_Luong"]);
            
            //if (strLoai_PBQL == "1" || strLoai_PBQL == "2" || strLoai_PBQL == "4")
            //    numKD.Visible = false;
            //else if (strLoai_PBQL == "3")
            //{
            //    numLuyen.Visible = false;
            //    numCan.Visible = false;
            //    numHSQD.Visible = false;
            //}
			//Lấy cấu trúc các cột
			dtDmTn = SQLExec.ExecuteReturnDt("SELECT * FROM R10DmTn ORDER BY Stt");

			//Lấy nội dung bảng lương
			Hashtable htPara = new Hashtable();
			htPara.Add("THANG", cboThang.SelectedValue);
			htPara.Add("NAM", Element.sysWorkingYear);
			htPara.Add("MA_BP", cboMa_Bp.Text);
            htPara.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);            

			dsBangLuong = SQLExec.ExecuteReturnDs("sp_HRM_GetBangLuong", htPara, CommandType.StoredProcedure);
            dtBangLuong = dsBangLuong.Tables[0];

            bdsBangLuong.DataSource = dtBangLuong;
			dgvBangLuong.DataSource = bdsBangLuong;
            lblNote.Text = dsBangLuong.Tables[1].Rows[0]["Note"].ToString();

            GetLuongDP();
		}

		private void ShowBangLuong()
		{
			//1-THANHTOAN
			//2-THUNHAP
			//3-TRULUONG

			dgvBangLuong.ReadOnly = false;

			for (int i = 0; i < dgvBangLuong.Columns.Count; i++)
			{
				string strColumnName = dgvBangLuong.Columns[i].Name;
				int iCount = dtDmTn.Select("Ma_Tn = '" + strColumnName + "'").Length;

				if (iCount == 1)
				{
					DataRow dr = dtDmTn.Select("Ma_Tn = '" + strColumnName + "'")[0];

					if (radioButton1.Checked)
						dgvBangLuong.Columns[strColumnName].Visible = (bool)dr["Is_Display1"];
					else if (radioButton2.Checked)
						dgvBangLuong.Columns[strColumnName].Visible = (bool)dr["Is_Display2"];
					else
						dgvBangLuong.Columns[strColumnName].Visible = (bool)dr["Is_Display3"];

					dgvBangLuong.Columns[i].ReadOnly = !(bool)dr["Is_Input"];
					dgvBangLuong.Columns[i].DefaultCellStyle.ForeColor = (bool)dr["Is_Input"] ? System.Drawing.Color.Blue : SystemColors.WindowText;

					if ((bool)dr["Bold"])
					{
						dgvBangLuong.Columns[i].DefaultCellStyle.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
					}
				}
				else
				{
					dgvBangLuong.Columns[i].ReadOnly = true;
				}
			}
		}

		private void CalSalary()
		{
            Common.ShowStatus(Languages.GetLanguage("In_Process") + " tính lương.");
            
            Hashtable htPara = new Hashtable();

			htPara.Add("THANG", cboThang.SelectedValue);
			htPara.Add("NAM", Element.sysWorkingYear);
			htPara.Add("MA_BP", cboMa_Bp.Text);
			htPara.Add("MA_DT_CBNV", txtMa_Dt_CbNv.Text);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			SQLExec.Execute("sp_HRM_CalcBangLuong", htPara, CommandType.StoredProcedure);
            //cập nhật lương dự phòng
            Hashtable htPara1 = new Hashtable();
            htPara1.Add("THANG", cboThang.SelectedValue);
            htPara1.Add("NAM", Element.sysWorkingYear);
            SQLExec.Execute("sp_UpdateTienLuongDP", htPara1, CommandType.StoredProcedure);

			this.FillData();

            Common.EndShowStatus();
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

		public override void Delete()
		{
			if (bdsBangLuong.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsBangLuong.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			Hashtable htPara = new Hashtable();
			htPara.Add("THANG", cboThang.SelectedValue);
			htPara.Add("NAM", Element.sysWorkingYear);
			htPara.Add("MA_BP", cboMa_Bp.Text);
			
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			if (SQLExec.Execute("sp_HRM_DeleteBangLuong", htPara, CommandType.StoredProcedure))
			{
				bdsBangLuong.RemoveAt(bdsBangLuong.Position);
				dtBangLuong.AcceptChanges();
			}
		}

		#endregion

		#region Event

		void btCalcSalary_Click(object sender, EventArgs e)
		{
			this.CalSalary();
		}

	

		void btDeleteSalary_Click(object sender, EventArgs e)
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
                    Common.MsgOk("Đã tính xong!!!");
				}
			}
		}
        void btPrint_Click(object sender, EventArgs e)
        {
            print(true);
        }
        void btPrintPhieuLuong_Click(object sender, EventArgs e)
        {
            if (bdsBangLuong.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsBangLuong.Current).Row;



            Voucher.PrintPhieuLuong(Convert.ToInt16(cboThang.SelectedValue), Element.sysWorkingYear, true, drCurrent["Ma_Dt_CbNv"].ToString());
    
           
        }
       
        private bool print(bool bPreview)
        {
            if (bdsBangLuong.Position < 0)
                return false;

            frmIn_QTLuong frm = new frmIn_QTLuong();
            frm.Load();
            if (frm.isAccept)
            {
                if (frm.rdbIn_QTLuong.Checked)
                {
                    strReportFile = "rptQTLuong";
                    strLoai = "1";


                }
                else if (frm.rdbIn_DangPhi.Checked)
                {
                    strReportFile = "rptDangPhi";
                    strLoai = "2";
                }
                else if (frm.rdbDoan_Phi.Checked)
                {
                    strReportFile = "rptDoanPhi";
                    strLoai = "3";
                }
                else if (frm.rdbNgay_LuongSp.Checked)
                {
                    strReportFile = "rptNgayLuongSP";
                    strLoai = "4";
                }
                else if (frm.rdbChuyenKhoan.Checked)
                {
                    strReportFile = "rptCKLuong";
                    strLoai = "5";
                }
                else if (frm.rdbTienMat.Checked)
                {
                    strReportFile = "rptTMLuong";
                    strLoai = "6";
                }
                else if (frm.rdbIn_QTLuongTH.Checked)
                {
                    strReportFile = "rptQTLuongTH";
                    strLoai = "7";
                }
               
                
                if (strLoai == "7")
                {

                }
             
                
                if (strLoai == "1")
                {
                    if (Common.InlistLike(cboMa_Bp.Text, "*") || cboMa_Bp.Text== "")
                    {
                        DataTable dtDmBpIn = dsBp.Tables[2];
                        foreach (DataRow dr in dtDmBpIn.Rows)
                        {
                            Hashtable ht = new Hashtable();

                            ht.Add("THANG", cboThang.SelectedValue);
                            ht.Add("NAM", Element.sysWorkingYear);

                            ht.Add("MA_BP", dr["Ma_Bp"].ToString());
                            ht.Add("MA_BP_CT", "");
                            ht.Add("LOAI", strLoai);
                            DataSet ds = SQLExec.ExecuteReturnDs("Sp_HRM_PrintQTLuong", ht, CommandType.StoredProcedure);
                            DataTable dtHeader = ds.Tables[0];
                            DataTable dtDetail = ds.Tables[1];


                            if (!dtHeader.Columns.Contains("REPORT_FILE"))
                                dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                            if (!dtHeader.Columns.Contains("NGAY_CT"))
                                dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));

                            dtHeader.Rows[0]["REPORT_FILE"] = strReportFile;
                            dtHeader.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;

                            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                            frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);

                        }
                    }
                    else
                    {
                        Hashtable ht = new Hashtable();

                        ht.Add("THANG", cboThang.SelectedValue);
                        ht.Add("NAM", Element.sysWorkingYear);

                        ht.Add("MA_BP", cboMa_Bp.Text);
                        ht.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
                        ht.Add("LOAI", strLoai);
                        DataSet ds = SQLExec.ExecuteReturnDs("Sp_HRM_PrintQTLuong", ht, CommandType.StoredProcedure);
                        DataTable dtHeader = ds.Tables[0];
                        DataTable dtDetail = ds.Tables[1];


                        if (!dtHeader.Columns.Contains("REPORT_FILE"))
                            dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                        if (!dtHeader.Columns.Contains("NGAY_CT"))
                            dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));

                        dtHeader.Rows[0]["REPORT_FILE"] = strReportFile;
                        dtHeader.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;

                        RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                        frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);
                    }
                    return true;
                }
                else
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("THANG", cboThang.SelectedValue);
                    ht.Add("NAM", Element.sysWorkingYear);

                    ht.Add("MA_BP", cboMa_Bp.Text);
                    ht.Add("MA_BP_CT", cboMa_Bp_Ct.Text);
                    ht.Add("LOAI", strLoai);
                    DataSet ds = SQLExec.ExecuteReturnDs("Sp_HRM_PrintQTLuong", ht, CommandType.StoredProcedure);
                    DataTable dtHeader = ds.Tables[0];
                    DataTable dtDetail = ds.Tables[1];


                    if (!dtHeader.Columns.Contains("REPORT_FILE"))
                        dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                    if (!dtHeader.Columns.Contains("NGAY_CT"))
                        dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));

                    dtHeader.Rows[0]["REPORT_FILE"] = strReportFile;
                    dtHeader.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;

                    RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                    return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, true);
                }
            }
            return false;
        }
        private void Design()
        {           
            frmIn_QTLuong frm = new frmIn_QTLuong();
            frm.Load();
            if (frm.isAccept)
            {
                if (frm.rdbIn_QTLuong.Checked)
                {
                    strReportFile = "rptQTLuong";
                    strLoai = "1";
                }
                else if (frm.rdbIn_DangPhi.Checked)
                {
                    strReportFile = "rptDangPhi";
                    strLoai = "2";
                }
                else if (frm.rdbDoan_Phi.Checked)
                {
                    strReportFile = "rptDoanPhi";
                    strLoai = "3";
                }
                else if (frm.rdbNgay_LuongSp.Checked)
                {
                    strReportFile = "rptNgayLuongSP";
                    strLoai = "4";
                }
                else if (frm.rdbChuyenKhoan.Checked)
                {
                    strReportFile = "rptCKLuong";
                    strLoai = "5";
                }
                else if (frm.rdbTienMat.Checked)
                {
                    strReportFile = "rptTMLuong";
                    strLoai = "6";
                }
                else if (frm.rdbIn_QTLuongTH.Checked)
                {
                    strReportFile = "rptQTLuongTH";
                    strLoai = "7";
                }
                else if (frm.rdbPhieuLuong.Checked)
                    strReportFile = "rptPhieuLuong";
            
            }
            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
        }
        void btImport_Click(object sender, EventArgs e)
        {
            frmReadExcel frm = new frmReadExcel();
            frm.Load();
            if (frm.isAccept && frm.dtImport != null)
            {
                DataTable dtDLLuong = SQLExec.ExecuteReturnDt("SELECT * FROM R10BANGLUONG WHERE 0 = 1");
               
                foreach (DataRow dr in frm.dtImport.Rows)
                {
                    if (dr["Ma_Dt_CbNv"].ToString() == string.Empty)
                        continue;
                    
                    string strColumnName = string.Empty;

                    foreach (DataColumn dc in frm.dtImport.Columns)
                    {
                       
                        if (!dc.ColumnName.StartsWith("Ten_Dt") && !dc.ColumnName.StartsWith("Ma_Dt") && !dc.ColumnName.StartsWith("Ghi_Chu"))
                            strColumnName = dc.ColumnName;
                      
                     if(!dc.ColumnName.StartsWith("Ghi_Chu"))
                     { 
                        DataRow drEditCtNew = dtDLLuong.NewRow();
                        Common.CopyDataRow(dr, drEditCtNew);
                        Common.SetDefaultDataRow(ref drEditCtNew);

                        if (strColumnName != string.Empty)
                        {
                            if (dr[strColumnName] == string.Empty)
                                dr[strColumnName] = 0;

                            drEditCtNew["Ma_Dt_CbNv"] = dr["Ma_Dt_CbNv"];
                            drEditCtNew["Ma_Tn"] = strColumnName.ToUpper();
                            drEditCtNew["Tien"] = dr[strColumnName];

                            if (frm.dtImport.Columns.Contains("Ghi_Chu"))
                                drEditCtNew["Ghi_Chu"] = dr["Ghi_Chu"];

                            dtDLLuong.Rows.Add(drEditCtNew);
                            drEditCtNew.AcceptChanges();
                        }
                      }
                    }
                }
                try
				{
					UpdateDLLuong(dtDLLuong);
					Common.MsgOk(Languages.GetLanguage("IMPORT_SUCCESS"));
                    this.FillData();
				}
				catch (Exception ex)
				{
					Common.MsgOk(ex.Message);
				}
               
                
            }
        }
        void UpdateDLLuong(DataTable dtImport)
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

            sqlCom.CommandText = "sp_Update_DLLUONG";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_DLLUONG";
            paraCt.Value = Voucher.GetTVPValue("R10BANGLUONG", "TVP_DLLUONG", dtImport);
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
		void btPostedSalary_Click(object sender, EventArgs e)
		{
			frmBangLuong_Posted frmPosted = new frmBangLuong_Posted();
			frmPosted.Load(Convert.ToInt32(this.cboThang.SelectedValue));
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
        void dgvBangLuong_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsBangLuong.Current).Row;
            DataGridViewCell dgvCell = ((rsDataGridView)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if ((string)drCurrent["Ma_Dt_CbNv"] == string.Empty)
                return;

            if (Common.Inlist(strColumnName, "HS_LUONG_DC") && dtDmTn.Select("Is_Input = true AND Ma_Tn = '" + strColumnName + "'").Length == 1)
			{
                Hashtable htPara = new Hashtable();
				htPara.Add("NAM", Element.sysWorkingYear);
				htPara.Add("THANG", this.cboThang.SelectedValue);
				htPara.Add("MA_DT_CBNV", (string)drCurrent["Ma_Dt_CbNv"]);
				htPara.Add("MA_DVCS", Element.sysMa_DvCs);
				htPara.Add("MA_TN", strColumnName);
				htPara.Add("TIEN", dgvCell.Value);

                DataRow drEdit_Luong = SQLExec.ExecuteReturnDt("Sp_HRM_EditBangLuong", htPara, CommandType.StoredProcedure).Rows[0];
                frmHSLuongDC_Edit frm = new frmHSLuongDC_Edit();
                frm.Load(enuEdit.Edit, drEdit_Luong);
                
                if (frm.isAccept)
                {
                    drCurrent[strColumnName] = frm.numTien.Value;
                    drCurrent.AcceptChanges();
                } 
            }
            else if (Common.Inlist(strColumnName, "HS_LUONG_BP") && Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access) && dtDmTn.Select("Is_Input = true AND Ma_Tn = '" + strColumnName + "'").Length == 1)
            {
                //Hashtable htPara = new Hashtable();
               
                //htPara.Add("MA_DT_CBNV", (string)drCurrent["Ma_Dt_CbNv"]);
                ////htPara.Add("MA_DVCS", Element.sysMa_DvCs);


                //DataRow drEdit_Luong = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R10HSABC WHERE Ma_Dt_CbNv = @Ma_Dt_CbNv AND Hs_Bp <> '' ORDER BY Ngay_Ap DESC", htPara, CommandType.Text).Rows[0];
                //RosyModule.HRM.frmHsABC_Edit frmEdit = new RosyModule.HRM.frmHsABC_Edit(); 
                //frmEdit.Load(enuEdit.New, drEdit_Luong, "BP");

                //if (frmEdit.isAccept)
                //{
                //    double dbHs_Bp = frmEdit.numHe_So.Value;
                   
                //    drCurrent[strColumnName] = dbHs_Bp;
                //    drCurrent.AcceptChanges();
                //}
            }
            else if (Common.Inlist(strColumnName, "HS_LUONG_CTY") && Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) && dtDmTn.Select("Is_Input = true AND Ma_Tn = '" + strColumnName + "'").Length == 1)
            {
                //Hashtable htPara = new Hashtable();

                //htPara.Add("MA_DT_CBNV", (string)drCurrent["Ma_Dt_CbNv"]);
                ////htPara.Add("MA_DVCS", Element.sysMa_DvCs);


                //DataRow drEdit_Luong = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R10HSABC WHERE Ma_Dt_CbNv = @Ma_Dt_CbNv AND Hs_Cty <> '' ORDER BY Ngay_Ap DESC", htPara, CommandType.Text).Rows[0];
                //RosyModule.HRM.frmHsABC_Edit frmEdit = new RosyModule.HRM.frmHsABC_Edit();
                //frmEdit.Load(enuEdit.New, drEdit_Luong, "CTY");

                //if (frmEdit.isAccept)
                //{
                //    double dbHs_Bp = frmEdit.numHe_So.Value;
                    

                //    drCurrent[strColumnName] = dbHs_Bp;
                //    drCurrent.AcceptChanges();
                //}
            }
            //else if (Common.Inlist(strColumnName, "LUONGTT") )//&& dtDmTn.Select("Is_Input = true AND Ma_Tn = '" + strColumnName + "'").Length == 1)
            //{
            //    Hashtable htPara = new Hashtable();

            //    htPara.Add("MA_DT_CBNV", (string)drCurrent["Ma_Dt_CbNv"]);
            //    //htPara.Add("MA_DVCS", Element.sysMa_DvCs);


            //    DataRow drEdit_Luong = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R09LUONGTT WHERE Ma_Dt_CbNv = @Ma_Dt_CbNv ORDER BY Ngay_Ap DESC", htPara, CommandType.Text).Rows[0];
            //    RosyModule.HRM.frmLuongTT_Edit frmEdit = new RosyModule.HRM.frmLuongTT_Edit();
            //    frmEdit.Load(enuEdit.New, drEdit_Luong);

            //}

            //if (dtDmTn.Select("Is_Input = true AND Ma_Tn = '" + strColumnName + "'").Length == 1)
            //{
            //    Hashtable htPara = new Hashtable();
            //    htPara.Add("NAM", Element.sysWorkingYear);
            //    htPara.Add("THANG", this.cboThang.SelectedValue);
            //    htPara.Add("MA_DT_CBNV", (string)drCurrent["Ma_Dt_CbNv"]);
            //    htPara.Add("MA_DVCS", Element.sysMa_DvCs);
            //    htPara.Add("MA_TN", strColumnName);
            //    htPara.Add("TIEN", dgvCell.Value);

            //    if (SQLExec.Execute("sp_HRM_SaveBangLuong", htPara, CommandType.StoredProcedure))
            //    {
            //        drCurrent.AcceptChanges();
            //    }
            //}
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
           
            //if (Common.Inlist(strColumnName, "HS_LUONG_CTY,HS_LUONG_BP,HS_LUONG_DC"))
            //{
            //    if (dtDmTn.Select("Is_Input = true AND Ma_Tn = '" + strColumnName + "'").Length == 1)
            //    {
            //        Hashtable htPara = new Hashtable();
            //        htPara.Add("NAM", Element.sysWorkingYear);
            //        htPara.Add("THANG", this.cboThang.SelectedValue);
            //        htPara.Add("MA_DT_CBNV", (string)drCurrent["Ma_Dt_CbNv"]);
            //        htPara.Add("MA_DVCS", Element.sysMa_DvCs);
            //        htPara.Add("MA_TN", strColumnName);
            //        htPara.Add("TIEN", dgvCell.Value);

            //        if (SQLExec.Execute("sp_HRM_SaveBangLuong", htPara, CommandType.StoredProcedure))
            //        {
            //            drCurrent.AcceptChanges();
            //        }
            //    }
            //}
		}

		void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			this.ShowBangLuong();
		}

        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

		#endregion

        private void btPostedSalary_Click_1(object sender, EventArgs e)
        {

        }
	}
}
