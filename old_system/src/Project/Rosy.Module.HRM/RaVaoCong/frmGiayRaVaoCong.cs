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

namespace RosyModule.HRM
{
	public partial class frmGiayRaVaoCong : RosySystem.Customize.frmView
	{
		#region Declare
        public DataSet dsInheritVoucher;
		public DataTable dtInheritVoucher;
        public DataTable dtInheritVoucher0;
        public DataTable dtGNTC;
        public DataTable dtGDKC;
		BindingSource bdsInheritVoucher = new BindingSource();
        BindingSource bdsInheritVoucher0 = new BindingSource();
        BindingSource bdsGNTC = new BindingSource();
        BindingSource bdsGDKC = new BindingSource();

		DataRow drCurrent, drDmCt_Current;
		public bool Is_Accept = false;
        public string strMa_Ct = string.Empty;
        bool bRa = false;
        string strMa_Ct_Ref = string.Empty;
        string strStt_Ref = string.Empty;
        #endregion

        #region Contructor

        public frmGiayRaVaoCong()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
            
            this.KeyDown += new KeyEventHandler(frmInheritDnTt_KeyDown);
            this.dgvInheritVoucher.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvInheritVoucher_CellMouseClick);
            bdsInheritVoucher.PositionChanged += new EventHandler(bdsInheritVoucher_PositionChanged);
		}

      
		#endregion

		#region Method

        //public void Load(string strMa_Ct)
        //{
        //    //dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
        //    //dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

        //    //this.strMa_Ct = strMa_Ct;
          

        //    Build();
        //    FillData();
        //    BindingLanguage();

        //    this.ShowDialog();
        //}
        public void Load()
        {

            
            //DateTime dteNgay_Ct1_ = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetDate(YEAR(Getdate()), MONTH(GETDATE()), 1)"));
            //DateTime dteNgay_Ct2_ = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT DATEADD(DAY, -1, DATEADD(MONTH,1,dbo.fn_GetDate(YEAR(Getdate()), MONTH(GETDATE()), 1)))"));
            //dteNgay_Ct1.Text = Library.DateToStr(dteNgay_Ct1_);
            //dteNgay_Ct2.Text = Library.DateToStr(dteNgay_Ct2_);
        

            Build();
            FillData();
            BindingLanguage();

            this.ShowDialog();
        }
		void Build()
		{
		    dgvInheritVoucher.strZone = "GIAYRAVAOCONG";
			dgvInheritVoucher.BuildGridView();

			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

            dgvInheritVoucher0.strZone = "GIAYRAVAOCONGCT";
            dgvInheritVoucher0.BuildGridView();
            dgvInheritVoucher0.ReadOnly = false;

            dgvGNTC.strZone = "GIAYNTC";
            dgvGNTC.BuildGridView();
            dgvGNTC.ReadOnly = false;

            dgvGDKC.strZone = "GIAYDKC";
            dgvGDKC.BuildGridView();
            dgvGDKC.ReadOnly = false;
            

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvInheritVoucher0.Columns)
                dgvc.ReadOnly = true;
           

            foreach (DataGridViewColumn dgvc in dgvGNTC.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvGDKC.Columns)
                dgvc.ReadOnly = true;

			if (dgvInheritVoucher.Columns.Contains("CHON"))
				dgvInheritVoucher.Columns["CHON"].ReadOnly = false;

            if (dgvGDKC.Columns.Contains("SO_LUONG_GIAO_TT"))
            {
                dgvGDKC.Columns["SO_LUONG_GIAO_TT"].ReadOnly = false;
                
            
            }
            if (dgvInheritVoucher0.Columns.Contains("SO_LUONG_GIAO_TT"))
                dgvInheritVoucher0.Columns["SO_LUONG_GIAO_TT"].ReadOnly = false;

            if (dgvGDKC.Columns.Contains("SO_LUONG_GIAO_TT"))
                dgvGDKC.Columns["SO_LUONG_GIAO_TT"].ReadOnly = false;

            if (dgvGNTC.Columns.Contains("CHON"))
                dgvGNTC.Columns["CHON"].ReadOnly = false;
            if (dgvGDKC.Columns.Contains("CHON"))
                dgvGDKC.Columns["CHON"].ReadOnly = false;

            if (dgvInheritVoucher.Columns.Contains("Note"))
                dgvInheritVoucher.Columns["Note"].ReadOnly = false;
            if (dgvGNTC.Columns.Contains("Note"))
                dgvGNTC.Columns["Note"].ReadOnly = false;
            if (dgvGDKC.Columns.Contains("Note"))
                dgvGDKC.Columns["Note"].ReadOnly = false;
            
           
            //dgvGNTC.Visible = false; 
            dgvInheritVoucher0.Visible = true;
            DataGridView_Language();
		}

		void FillData()
		{

            if (rdbRa.Checked == true)
                bRa = true;
            else if (rdbDTVao.Checked == true)
            {
                bRa = false;
                this.strMa_Ct = "DT";
            }
            else if (rdbVao.Checked == true)
            {
                bRa = false;
                this.strMa_Ct = "GRVC";
            }
            Hashtable htPara = new Hashtable();
            htPara.Add("RA", bRa);
            htPara.Add("SO_CT", txtSo_Ct.Text);
            htPara.Add("MA_CT", strMa_Ct);
            htPara.Add("IS_NOTBDKT", chkIs_NotBDKT.Checked);

            dsInheritVoucher = SQLExec.ExecuteReturnDs("sp_GetGiayRVCBVe", htPara, CommandType.StoredProcedure);
            
            dtInheritVoucher = dsInheritVoucher.Tables[0];
            bdsInheritVoucher.DataSource = dtInheritVoucher;
			dgvInheritVoucher.DataSource = bdsInheritVoucher;
            
            dtInheritVoucher0 = dsInheritVoucher.Tables[1];
            bdsInheritVoucher0.DataSource = dtInheritVoucher0;
            dgvInheritVoucher0.DataSource = bdsInheritVoucher0;

            dtGNTC = dsInheritVoucher.Tables[2];
            bdsGNTC.DataSource = dtGNTC;
            dgvGNTC.DataSource = bdsGNTC;

            dtGDKC = dsInheritVoucher.Tables[3];
            bdsGDKC.DataSource = dtGDKC;
            dgvGDKC.DataSource = bdsGDKC;

            strMa_Ct_Ref = dsInheritVoucher.Tables[4].Rows[0]["Ma_Ct"].ToString();
            strStt_Ref = dsInheritVoucher.Tables[4].Rows[0]["Stt"].ToString();
            DataColumn dc = new DataColumn("Note", typeof(string));
            dc.DefaultValue = "";
            dtInheritVoucher0.Columns.Add(dc);
            DataColumn dc1 = new DataColumn("Note", typeof(string));
            dc1.DefaultValue = ""; 
            dtGNTC.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("Note", typeof(string));
            dc2.DefaultValue = "";
            dtGDKC.Columns.Add(dc2);
			
            bdsSearch = bdsInheritVoucher;
			bdsLookup = bdsInheritVoucher;

            if (rdbVao.Checked == true || rdbDTVao.Checked == true)
                gbThongtin.Visible = true;
            else
                gbThongtin.Visible = false;

            //xử lý hiển thị khi nhập số ct 
            if(txtSo_Ct.Text != "")
            {
                if (strMa_Ct_Ref == "GNTC")
                { dgvInheritVoucher0.Visible = false; dgvGDKC.Visible = false; dgvGNTC.Visible = true; }
                else if (strMa_Ct_Ref == "GDKC")
                { dgvInheritVoucher0.Visible = false; dgvGDKC.Visible = true; dgvGNTC.Visible = false; }
                else
                { dgvInheritVoucher0.Visible = true; dgvGDKC.Visible = false; dgvGNTC.Visible = false; }

                bdsInheritVoucher0.Filter = "Stt = '" + strStt_Ref + "'";
                bdsGNTC.Filter = "Stt = '" + strStt_Ref + "'";
                bdsGDKC.Filter = "Stt = '" + strStt_Ref + "'";
            }
            
        }
        private void DataGridView_Language()
        {

            if (dgvGNTC.Columns.Contains("Noi_Dung"))
                dgvGNTC.Columns["Noi_Dung"].HeaderText = "Họ và tên";
            if (dgvGNTC.Columns.Contains("Ten_Vt"))
                dgvGNTC.Columns["Ten_Vt"].HeaderText = "Năm sinh";
            if (dgvGNTC.Columns.Contains("Phuong_An"))
                dgvGNTC.Columns["Phuong_An"].HeaderText = "Số CMT/CCCD";
            if (dgvGNTC.Columns.Contains("Tinh_Trang_Tb"))
                dgvGNTC.Columns["Tinh_Trang_Tb"].HeaderText = "Khu vực làm việc";
            if (dgvGNTC.Columns.Contains("Nguyen_Nhan"))
                dgvGNTC.Columns["Nguyen_Nhan"].HeaderText = "Bộ phận QL và giám sát";

            dgvInheritVoucher0.Columns["So_Luong0"].HeaderText = "Khối lượng về";
            dgvInheritVoucher0.Columns["Is_Kh"].HeaderText = "Có nhập về";

            if (dgvGDKC.Columns.Contains("Noi_Dung"))
                dgvGDKC.Columns["Noi_Dung"].HeaderText = "Tên vật tư  - phương tiện";
            if (dgvGDKC.Columns.Contains("Ten_Vt"))
                dgvGDKC.Columns["Ten_Vt"].HeaderText = "Mã số";


            dgvGDKC.Columns["So_Luong_Giao_TT_Vao"].HeaderText = "Số lượng vào cổng Bvệ đã xác nhận";
            dgvGDKC.Columns["So_Luong_Giao_TT_Ra"].HeaderText = "Số lượng ra cổng Bvệ đã xác nhận";

            if (rdbRa.Checked == true)
            {
                if (dgvGDKC.Columns.Contains("So_Luong_Giao_TT"))
                    dgvGDKC.Columns["So_Luong_Giao_TT"].HeaderText = "Số lượng xác nhận ra lần này";
                
            }
            else if (rdbVao.Checked == true)
            {
                if (dgvGDKC.Columns.Contains("So_Luong_Giao_TT"))
                    dgvGDKC.Columns["So_Luong_Giao_TT"].HeaderText = "Số lượng xác nhận vào lần này";

              
            }
            if (dgvInheritVoucher0.Columns.Contains("Ten_Vt"))
            {
                dgvInheritVoucher0.Columns["Ten_Vt"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvInheritVoucher0.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvGNTC.Columns.Contains("Ten_Vt"))
            {
                dgvGNTC.Columns["Ten_Vt"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvGNTC.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvGDKC.Columns.Contains("Ten_Vt"))
            {
                dgvGDKC.Columns["Ten_Vt"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvGDKC.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
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

		#endregion

		#region Event

		

		

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
        private bool Save()
        {
            string strSQLCt = string.Empty;
            bool bHt = false;
            if (dtInheritVoucher.Select("Chon = 1").Length == 0)
            {
                if (!Common.MsgYes_No("Bạn chưa xác nhận phiếu nào ra hoặc vào cổng, bạn có muốn tiếp tục xác nhận không?", "Y"))
                    return false;
            }
           
            else
            {
                foreach (DataRow dr in dtInheritVoucher.Select("Chon = 1"))
                {

                    string strSQL = string.Empty;
                    Hashtable ht = new Hashtable();
                    ht.Add("STT", dr["Stt"]);
                    if (bRa)
                    {
                        ht.Add("NGAY_RA", dr["Ngay_Ra"]);
                        ht.Add("USER_RA", Common.GetCurrent_Log());
                        ht.Add("IS_HT", bHt);
                        strSQL = "UPDATE R06PH_BTTB SET Ngay_Ra = @Ngay_Ra, User_Ra = @User_Ra, Is_Ht = @Is_Ht  WHERE Stt = @Stt";
                      
                        //lƯU SỐ LƯỢNG HÀNG MANG RA CỔNG Ở GDKC
                        if (Common.Inlist(dr["Ma_Ct"].ToString(), "GDKC"))
                        {
                            
                            foreach (DataRow drGDKC in dtGDKC.Select("Stt = '" + dr["Stt"].ToString() + "' AND So_Luong_Giao_TT  <> 0 "))
                            {
                                Hashtable htOut1 = new Hashtable();
                                htOut1.Add("STT", drGDKC["Stt"].ToString());
                                htOut1.Add("STT0", drGDKC["Stt0"]);
                                htOut1.Add("NGAY_RA", dr["Ngay_Ra"]);
                                htOut1.Add("USER_RA", Common.GetCurrent_Log());
                                htOut1.Add("SO_LUONG_GIAO_TT_RA", drGDKC["So_Luong_Giao_TT"]);
                                htOut1.Add("NOTE", drGDKC["Note"]);
                                strSQLCt = "INSERT INTO R06CT_GRVC( Stt, Stt0, Ngay_Ra, User_Ra, So_Luong_Giao_TT_Ra, Note) VALUES (@Stt, @Stt0, @Ngay_Ra, @User_Ra, @So_Luong_Giao_TT_Ra, @Note)";
                                SQLExec.Execute(strSQLCt, htOut1, CommandType.Text);
                            }
                            //}
                        }
                        else if (Common.Inlist(dr["Ma_Ct"].ToString(), "GRVC"))
                        {
                            foreach (DataRow drGDKC in dtInheritVoucher0.Select("Stt = '" + dr["Stt"].ToString() + "' AND So_Luong_Giao_TT  <> 0 "))
                            {
                                Hashtable htOut1 = new Hashtable();
                                htOut1.Add("STT", drGDKC["Stt"].ToString());
                                htOut1.Add("STT0", drGDKC["Stt0"]);
                                htOut1.Add("NGAY_RA", dr["Ngay_Ra"]);
                                htOut1.Add("USER_RA", Common.GetCurrent_Log());
                                htOut1.Add("SO_LUONG_GIAO_TT_RA", drGDKC["So_Luong_Giao_TT"]);
                                htOut1.Add("NOTE", drGDKC["Note"]);
                                strSQLCt = "INSERT INTO R06CT_GRVC( Stt, Stt0, Ngay_Ra, User_Ra, So_Luong_Giao_TT_Ra, Note) VALUES (@Stt, @Stt0, @Ngay_Ra, @User_Ra, @So_Luong_Giao_TT_Ra, @Note)";
                                SQLExec.Execute(strSQLCt, htOut1, CommandType.Text);
                            }
                        }
                        //lưu nhà thầu ra cổng
                       
                        if (dr["Ma_Ct"].ToString() == "GNTC")
                        {
                            if (dtGNTC.Select("Chon = 1").Length == 0)
                            {
                                Common.MsgYes_No("Bạn chưa xác nhận người nào ra hoặc vào cổng, Bạn vui lòng tick chọn người");
                                dgvGNTC.Focus();
                                return false;
                            }
                            else
                            {
                                foreach (DataRow drCt in dtGNTC.Select("Stt = '" + dr["Stt"].ToString() + "' AND Chon = 1"))
                                {


                                    Hashtable htIns = new Hashtable();

                                    htIns.Add("STT", drCt["Stt"]);
                                    htIns.Add("STT0", drCt["Stt0"]);
                                    htIns.Add("NGAY_RA", dr["Ngay_Ra"]);
                                    htIns.Add("USER_RA", Common.GetCurrent_Log());
                                    htIns.Add("NOTE", drCt["Note"]);
                                    strSQLCt = "UPDATE R06CT_GRVC SET Ngay_Ra = @Ngay_Ra, User_Ra = @User_Ra, Note = @Note, So_Luong_Giao_TT_Ra = 1 WHERE Stt = @Stt AND Stt0 = @Stt0";
                                    SQLExec.Execute(strSQLCt, htIns, CommandType.Text);

                                }
                            }
                        }

                    }

                    else
                    {
                        ht.Add("NGAY_VAO", dr["Ngay_Vao"]);
                      
                        ht.Add("USER_VAO", Common.GetCurrent_Log());
                        strSQL = "UPDATE R06PH_BTTB SET Ngay_Vao = @Ngay_Vao, User_Vao = @User_Vao  WHERE Stt = @Stt";
                        if (dr["Ma_Ct"].ToString() == "GDKC")
                        {
                            foreach (DataRow drCt in dtGDKC.Select("Stt = '" + dr["Stt"].ToString() + "' AND So_Luong_Giao_TT <> 0 "))
                            {


                                Hashtable htIns = new Hashtable();
                                htIns.Add("SO_LUONG_GIAO_TT", drCt["So_Luong_Giao_TT"]);
                                htIns.Add("STT", drCt["Stt"]);
                                htIns.Add("STT0", drCt["Stt0"]);
                                htIns.Add("NGAY_VAO", dr["Ngay_Vao"]);
                                
                                htIns.Add("NOTE", drCt["Note"]);

                                htIns.Add("USER_VAO", Common.GetCurrent_Log());
                                htIns.Add("TEN_DT_NHAN", txtTen_Dt_Nhan.Text);
                                htIns.Add("CHUC_VU_NHAN", txtChuc_Vu_Nhan.Text);
                                htIns.Add("TEN_DV_NHAN", txtTen_Dt_Nhan.Text);
                                htIns.Add("SO_XE_NHAN", txtSo_Xe_Nhan.Text);

                                strSQLCt = "INSERT INTO R06CT_GRVC(Stt, Stt0, Ngay_Vao, User_Vao,So_Luong_Giao_TT, Ten_Dt_Nhan, Chuc_Vu_Nhan, Ten_DV_Nhan, So_Xe_Nhan, Note) "+
                                    " VALUES (@Stt, @Stt0, @Ngay_Vao, @User_Vao, @So_Luong_Giao_TT, @Ten_Dt_Nhan, @Chuc_Vu_Nhan, @Ten_DV_Nhan, @So_Xe_Nhan, @Note)";
                                SQLExec.Execute(strSQLCt, htIns, CommandType.Text);

                            }
                        }
                        else if (dr["Ma_Ct"].ToString() == "GNTC")
                        {
                            foreach (DataRow drCt in dtGNTC.Select("Stt = '" + dr["Stt"].ToString() + "' AND Chon = 1"))
                            {


                                Hashtable htIns = new Hashtable();
                               
                                htIns.Add("STT", drCt["Stt"]);
                                htIns.Add("STT0", drCt["Stt0"]);
                                htIns.Add("NGAY_VAO", dr["Ngay_Vao"]);
                                htIns.Add("USER_VAO", Common.GetCurrent_Log());
                                htIns.Add("NOTE", drCt["Note"]);

                                strSQLCt = "INSERT INTO R06CT_GRVC(Stt, Stt0, Ngay_Vao, User_Vao, So_Luong_Giao_Tt, Note) VALUES (@Stt, @Stt0, @Ngay_Vao, @User_Vao,1,@Note)";
                                SQLExec.Execute(strSQLCt, htIns, CommandType.Text);

                            }
                        }
                        else
                        {
                            foreach (DataRow drCt in dtInheritVoucher0.Select("Stt = '" + dr["Stt"].ToString() + "'"))
                            {


                                Hashtable htIns = new Hashtable();
                                htIns.Add("SO_LUONG_GIAO_TT", drCt["So_Luong_Giao_TT"]);
                                htIns.Add("STT", drCt["Stt"]);
                                htIns.Add("STT0", drCt["Stt0"]);
                                htIns.Add("NGAY_VAO", dr["Ngay_Vao"]);
                                htIns.Add("NOTE", drCt["Note"]);
                                htIns.Add("USER_VAO", Common.GetCurrent_Log());
                                htIns.Add("TEN_DT_NHAN", txtTen_Dt_Nhan.Text);
                                htIns.Add("CHUC_VU_NHAN", txtChuc_Vu_Nhan.Text);
                                htIns.Add("TEN_DV_NHAN", txtTen_Dt_Nhan.Text);
                                htIns.Add("SO_XE_NHAN", txtSo_Xe_Nhan.Text);

                                strSQLCt = "INSERT INTO R06CT_GRVC(Stt, Stt0, Ngay_Vao, User_Vao,So_Luong_Giao_TT, Ten_Dt_Nhan, Chuc_Vu_Nhan, Ten_DV_Nhan, So_Xe_Nhan, Note) " +
                                    " VALUES (@Stt, @Stt0, @Ngay_Vao, @User_Vao, @So_Luong_Giao_TT, @Ten_Dt_Nhan, @Chuc_Vu_Nhan, @Ten_DV_Nhan, @So_Xe_Nhan, @Note)";
                                SQLExec.Execute(strSQLCt, htIns, CommandType.Text);

                            }
                        }
                    }
                    if (SQLExec.Execute(strSQL, ht, CommandType.Text))
                        return true;
                }
            }
            return false;
        }
		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
		}
        void dgvInheritVoucher_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            drCurrent = ((DataRowView)bdsInheritVoucher.Current).Row;
            string strColumnName = dgvInheritVoucher.Columns[e.ColumnIndex].Name;

            if (drCurrent["Ma_Ct"].ToString() == "GNTC")
            { dgvGNTC.Visible = true; dgvInheritVoucher0.Visible = false; }
            else
            { dgvGNTC.Visible = false; dgvInheritVoucher0.Visible = true; }

            if (strColumnName == "CHON")
            {
                if (bRa)
                {
                    drCurrent["Ngay_Ra"] = Convert.ToDateTime(DateTime.Now);
                    drCurrent["User_Ra"] = Common.GetCurrent_Log();
                }
                else
                {
                    drCurrent["Ngay_Vao"] = Convert.ToDateTime(DateTime.Now);
                    drCurrent["User_Vao"] = Common.GetCurrent_Log();
                }
            }

            if (dtInheritVoucher.Rows.Count == 0)
                return;

            bdsInheritVoucher0.Filter = "Stt = '" + drCurrent["Stt"] + "'";
            bdsGNTC.Filter = "Stt = '" + drCurrent["Stt"] + "'";
            DataGridView_Language();
        }
        void frmInheritDnTt_KeyDown(object sender, KeyEventArgs e)
        {
        //    if (e.Control && e.KeyCode == Keys.A)
        //    {

        //        for (int i = 0; i < dtInheritVoucher.Rows.Count; i++)
        //        {
        //            dtInheritVoucher.Rows[i]["CHON"] = true;
        //        }
        //    }
        //    if (e.Control && e.KeyCode == Keys.U)
        //    {

        //        for (int i = 0; i < dtInheritVoucher.Rows.Count; i++)
        //        {
        //            dtInheritVoucher.Rows[i]["CHON"] = false;
        //        }
        //    }
        }
        void bdsInheritVoucher_PositionChanged(object sender, EventArgs e)
        {
            if (dtInheritVoucher.Rows.Count == 0)
                return;

            drCurrent = ((DataRowView)bdsInheritVoucher.Current).Row;

            if (drCurrent["Ma_Ct"].ToString() == "GNTC")
            { dgvInheritVoucher0.Visible = false; dgvGDKC.Visible = false; dgvGNTC.Visible = true;}
            else if (drCurrent["Ma_Ct"].ToString() == "GDKC")
            { dgvInheritVoucher0.Visible = false; dgvGDKC.Visible = true; dgvGNTC.Visible = false; }
            else
            { dgvInheritVoucher0.Visible = true; dgvGDKC.Visible = false; dgvGNTC.Visible = false; }

            bdsInheritVoucher0.Filter = "Stt = '" + drCurrent["Stt"] + "'";
            bdsGNTC.Filter = "Stt = '" + drCurrent["Stt"] + "'";
            bdsGDKC.Filter = "Stt = '" + drCurrent["Stt"] + "'";
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                this.FillData();
            //else if (e.Control)
            //{
            //    if (e.KeyCode == Keys.A)
            //        foreach (DataRow dr in dtInheritVoucher.Rows)
            //            dr["Chon"] = true;
            //    else if (e.KeyCode == Keys.U)
            //        foreach (DataRow dr in dtInheritVoucher.Rows)
            //        {
            //            dr["Chon"] = false;
            //            if (dtInheritVoucher.Columns.Contains("Stt_Order"))
            //                dr["Stt_Order"] = 0;
            //        }
            //}
            else
                base.OnKeyDown(e);
        }
		#endregion

        //private void rsLabel1_Click(object sender, EventArgs e)
        //{

        //}

        //private void tabPage1_Click(object sender, EventArgs e)
        //{

        //}
	}
}
