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
	public partial class frmHanTtAuto : RosySystem.Customize.frmView
	{
		DataTable dtThanhToan;
		DataTable dtHanTt;

		BindingSource bdsThanhToan = new BindingSource();
		BindingSource bdsHanTt = new BindingSource();

		public frmVoucher_Edit frmEditCt;
		public string strStt = string.Empty;

		#region Contructor

        public frmHanTtAuto()
		{
			InitializeComponent();

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			this.bdsThanhToan.PositionChanged += new EventHandler(bdsThanhToan_PositionChanged);
			this.dgvThanhToan.RowValidated += new DataGridViewCellEventHandler(dgvThanhToan_RowValidated);
			this.dgvHanTt.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvHanTt0_CellMouseClick);
			this.dgvHanTt.CellBeginEdit += new DataGridViewCellCancelEventHandler(dgvHanTt0_CellBeginEdit);
			this.dgvHanTt.CellEndEdit += new DataGridViewCellEventHandler(dgvHanTt0_CellEndEdit);
			//this.dgvHanTt.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvHanTt_DataBindingComplete);

			this.dgvThanhToan.GotFocus += new EventHandler(dgvThanhToan_GotFocus);
			this.dgvHanTt.GotFocus += new EventHandler(dgvHanTt0_GotFocus);
			this.dgvThanhToan.CellDoubleClick += new DataGridViewCellEventHandler(dgvThanhToan_CellDoubleClick);

			btRefresh.Click += new EventHandler(btRefresh_Click);
			chkUpdate_Ngay_Ct.CheckedChanged += new EventHandler(chkUpdate_Ngay_Ct_CheckedChanged);

            chk02D.CheckedChanged += new EventHandler(chk02D_CheckedChanged);
            chk07D.CheckedChanged += new EventHandler(chk07D_CheckedChanged);
            chk39D.CheckedChanged += new EventHandler(chk39D_CheckedChanged);
            chkDH.CheckedChanged += new EventHandler(chkDH_CheckedChanged);
            chkQH.CheckedChanged += new EventHandler(chkQH_CheckedChanged);
            chkQDH.CheckedChanged += new EventHandler(chkQDH_CheckedChanged);

			this.btSave_Auto.Click += new EventHandler(btSave_Auto_Click);
            this.btSave.Click+=new EventHandler(btSave_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
		}

      
      

       

		new public void Load()
		{
			Build();
           

			if (this.frmEditCt != null) //Điền dữ liệu thanh toán từ EditCt
				FillThanhToanFromEditCt();
			else
				FillThanhToanFromCongNo();

			BindingLanguage();

			//Ngầm định Ma_Tte, Ty_Gia
			if (this.frmEditCt != null)
			{
				txtMa_Tte.Text = this.frmEditCt.drEditPh["Ma_Tte"].ToString();
				numTy_Gia.Value = Convert.ToDouble(this.frmEditCt.drEditPh["Ty_Gia"]);
			}
			else if (strStt != "")
			{
				DataRow drThanhToan = DataTool.SQLGetDataRowByID("vw_ThanhToan", "Stt_PT", strStt);

				if (drThanhToan != null)
				{
					txtMa_Tte.Text = drThanhToan["Ma_Tte_PT"].ToString();
					numTy_Gia.Value = Convert.ToDouble(drThanhToan["Ty_Gia_PT"]);
				}
			}

            //if (frmEditCt != null && frmEditCt.Controls.ContainsKey("dteNgay_Ct"))
            //    dteNgay_Ct.Text = frmEditCt.Controls["dteNgay_Ct"].Text;

            dteNgay_Ct.Text = Library.DateToStr(DateTime.Now);
            txtTk.Text = "131";

			txtTk.Enabled = txtMa_Dt.Enabled =  btRefresh.Enabled = (this.frmEditCt == null && strStt == "");
			

			//dgvThanhToan.Focus();

			if (this.frmEditCt == null)
				this.Show();
			else
				this.ShowDialog();
		}

		public void Load(string strStt, string strTk, string strMa_Dt)
		{
			this.strStt = strStt;
			this.txtTk.Text = strTk;
			this.txtMa_Dt.Text = strMa_Dt;

			this.Load();
		}

		public void Load(frmVoucher_Edit frmEditCt)
		{
			this.frmEditCt = frmEditCt;

			this.Load();
		}

		#endregion

		#region Method

		private void Build()
		{
			dgvThanhToan.strZone = "THANHTOAN";
			dgvThanhToan.BuildGridView();

			dgvHanTt.ReadOnly = false;
			dgvHanTt.strZone = "HANTT";
			dgvHanTt.BuildGridView();

            txtMa_Dt.bUseAutoDropDown = true;
			//foreach (DataGridViewColumn dgvc in dgvHanTt.Columns)
			//{
			//    if (dgvc.Name == "TIEN_TT1" || dgvc.Name == "TIEN_TT_NT1")
			//        dgvc.ReadOnly = false;
			//    else
			//        dgvc.ReadOnly = true;
			//}
		}

		private void FillThanhToanFromCongNo()
		{
			if ((dteNgay_Ct.IsNull || txtTk.Text == "") && this.strStt == "")
				return;

			if (this.strStt != "") //Chỉ Load 1 Stt: Load toàn bộ Phiếu, và tìm đến Ma_Dt hiện tại
			{
				Hashtable htParameter = new Hashtable();

				htParameter.Add("NGAY_CT2", Library.StrToDate(this.dteNgay_Ct.Text));
				htParameter.Add("TK", txtTk.Text);
				htParameter.Add("MA_DT", "");
			
				htParameter.Add("STT", this.strStt);
				htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

                dtThanhToan = SQLExec.ExecuteReturnDt("Sp_GetThanhToan_CtAuTo", htParameter, CommandType.StoredProcedure);

				bdsThanhToan.DataSource = dtThanhToan;
				dgvThanhToan.DataSource = bdsThanhToan;

				if (txtMa_Dt.Text != "")
				{
					bdsThanhToan.Position = bdsThanhToan.Find("Ma_Dt", txtMa_Dt.Text);
				}
			}
			else
			{
				Hashtable htParameter = new Hashtable();

				htParameter.Add("NGAY_CT2", Library.StrToDate(this.dteNgay_Ct.Text));
				htParameter.Add("TK", this.txtTk.Text);
				htParameter.Add("MA_DT", this.txtMa_Dt.Text);
				
				htParameter.Add("STT", this.strStt);
				htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

                dtThanhToan = SQLExec.ExecuteReturnDt("Sp_GetThanhToan_CtAuTo", htParameter, CommandType.StoredProcedure);

				dgvThanhToan.DataSource = bdsThanhToan;
				bdsThanhToan.DataSource = dtThanhToan;
			}
		}

		private void FillThanhToanFromEditCt()
		{
			Voucher.Update_Detail(frmEditCt);

			string strSQLExec = @"
					SELECT TOP 0 Stt_PT, Ma_Ct_PT, Ngay_Ct_PT, So_Ct_PT, Tk, Ma_Dt, Ma_Tte_PT, Ty_Gia_PT, Tien_PT, Tien_PT_Nt, Dien_Giai_PT, CAST(0 AS BIT) AS Is_UngTruoc 
					    FROM vw_ThanhToan 
						WHERE 0 = 1";

			dtThanhToan = SQLExec.ExecuteReturnDt(strSQLExec);

			//Điền dữ liệu từ frmEditCt vào HanTt0
			string strArrTk_HanTt_List = "," + (string)Parameters.GetParaValue("TK_HANTT_LIST");
			DataRow[] drArr = frmEditCt.dtEditCt.Select("Deleted = false");

			string strTk_No, strTk_Co, strMa_Dt, strMa_Dt_Co, strMa_Ct;
			double dbTien, dbTien_Nt;
			bool bIs_UngTruoc = false;

			//Lấy dữ liệu từ hạch toán gốc
			foreach (DataRow dr in drArr)
			{
				if (dr.Table.Columns.Contains("TIEN"))
				{
					strTk_No = ((string)dr["Tk_No"]).Trim();
					strTk_Co = ((string)dr["Tk_Co"]).Trim();
					strMa_Dt = ((string)dr["Ma_Dt"]).Trim();
					strMa_Ct = ((string)dr["Ma_Ct"]).Trim();
					dbTien = Convert.ToDouble(dr["Tien"]);
					dbTien_Nt = Convert.ToDouble(dr["Tien_Nt"]);

					if (dr.Table.Columns.Contains("Is_UngTruoc"))
						bIs_UngTruoc = (bool)dr["Is_UngTruoc"];

					if (dr.Table.Columns.Contains("Ma_Dt_Co") && (string)dr["Ma_Dt_Co"] != string.Empty)
						strMa_Dt_Co = (string)dr["Ma_Dt_Co"];
					else
						strMa_Dt_Co = strMa_Dt;

					if (strTk_No != string.Empty && strTk_Co != string.Empty)
					{
						//Kiểm tra Tk_No
						if (strArrTk_HanTt_List.Contains("," + strTk_No.Substring(0, 3)))
						{
							if (frmEditCt.dtEditCt.Select("Tk_No LIKE '" + strTk_No + "%' AND Han_Tt = 0").Length > 0)
								this.SaveToHanTt(strTk_No, strMa_Dt, dbTien, dbTien_Nt, "N", bIs_UngTruoc);
						}

						//Kiểm tra Tk_Co
						if (strArrTk_HanTt_List.Contains("," + strTk_Co.Substring(0, 3)))
						{
							if (strMa_Ct == "BT" && frmEditCt.dtEditCt.Columns.Contains("Han_Tt_Co"))
							{
								if (frmEditCt.dtEditCt.Select("Tk_Co LIKE '" + strTk_Co + "%' AND Han_Tt_Co = 0").Length > 0)
									this.SaveToHanTt(strTk_Co, strMa_Dt_Co, dbTien, dbTien_Nt, "C", bIs_UngTruoc);
							}
							else
							{
								if (frmEditCt.dtEditCt.Select("Tk_Co LIKE '" + strTk_Co + "%' AND Han_Tt = 0").Length > 0)
									this.SaveToHanTt(strTk_Co, strMa_Dt_Co, dbTien, dbTien_Nt, "C", bIs_UngTruoc);
							}
						}
					}
				}

				if (dr.Table.Columns.Contains("TIEN3"))
				{
					strTk_No = ((string)dr["Tk_No3"]).Trim();
					strTk_Co = ((string)dr["Tk_Co3"]).Trim();
					strMa_Dt = ((string)dr["Ma_Dt"]).Trim();
					dbTien = Convert.ToDouble(dr["Tien3"]);
					dbTien_Nt = Convert.ToDouble(dr["Tien_Nt3"]);

					if (dr.Table.Columns.Contains("Ma_Dt_Co") && (string)dr["Ma_Dt_Co"] != string.Empty)
						strMa_Dt_Co = (string)dr["Ma_Dt_Co"];
					else
						strMa_Dt_Co = strMa_Dt;

					if (strTk_No != string.Empty && strTk_Co != string.Empty)
					{
						//Kiểm tra Tk_No
						if (strArrTk_HanTt_List.Contains("," + strTk_No.Substring(0, 3)))
						{
							if (frmEditCt.dtEditCt.Select("Tk_No LIKE '" + strTk_No + "%' AND Han_Tt = 0").Length > 0)
								this.SaveToHanTt(strTk_No, strMa_Dt, dbTien, dbTien_Nt, "N", bIs_UngTruoc);
						}

						//Kiểm tra Tk_Co
						if (strArrTk_HanTt_List.Contains("," + strTk_Co.Substring(0, 3)))
						{
							if (frmEditCt.dtEditCt.Select("Tk_Co LIKE '" + strTk_Co + "%' AND Han_Tt = 0").Length > 0)
								this.SaveToHanTt(strTk_Co, strMa_Dt_Co, dbTien, dbTien_Nt, "C", bIs_UngTruoc);
						}
					}
				}
			}

			//Cập nhật lại Tỷ giá
			foreach (DataRow dr in dtThanhToan.Rows)
			{
				dbTien = Convert.ToDouble(dr["Tien_PT"]);
				dbTien_Nt = Convert.ToDouble(dr["Tien_PT_Nt"]);
				if (dbTien != dbTien_Nt && dbTien_Nt != 0)
					dr["Ty_Gia_PT"] = Math.Round(dbTien / dbTien_Nt, 0, MidpointRounding.AwayFromZero);
			}

			dgvThanhToan.DataSource = bdsThanhToan;
			bdsThanhToan.DataSource = dtThanhToan;
		}

        //private void FillHanTt()
        //{
        //    if (bdsThanhToan == null || bdsThanhToan.Position < 0)
        //        return;

        //    DataRow drThanhToan = ((DataRowView)bdsThanhToan.Current).Row;

        //    DateTime dtNgay_Ct = btRefresh.Enabled ? Library.StrToDate(dteNgay_Ct.Text) : (DateTime)drThanhToan["Ngay_Ct_PT"];

        //    string strTk = (string)drThanhToan["Tk"];
        //    string strMa_Dt = (string)drThanhToan["Ma_Dt"];
        //    string strStt_PT = (string)drThanhToan["Stt_PT"];

        //    if (frmEditCt != null && frmEditCt.dtHanTt0 != null && frmEditCt.dtHanTt0.Select("Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'").Length > 0)
        //    {
        //        dtHanTt = frmEditCt.dtHanTt0.Clone();

        //        foreach (DataRow dr in frmEditCt.dtHanTt0.Select("Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'"))
        //        {
        //            DataRow drNew = dtHanTt.NewRow();
        //            Common.CopyDataRow(dr, drNew);

        //            dtHanTt.Rows.Add(drNew);
        //        }

        //        bdsHanTt.DataSource = dtHanTt;
        //        dgvHanTt.DataSource = bdsHanTt;
        //    }
        //    else
        //    {
        //        Hashtable htParameter = new Hashtable();

        //        htParameter.Add("NGAY_CT2", dtNgay_Ct);
        //        htParameter.Add("TK", strTk);
        //        htParameter.Add("MA_DT", strMa_Dt);
        //        htParameter.Add("STT_PT", strStt_PT);
        //        htParameter.Add("MA_DVCS", Element.sysMa_DvCs);
        //        htParameter.Add("IS_02D", chk02D.Checked);
        //        htParameter.Add("IS_07D", chk07D.Checked);
        //        htParameter.Add("IS_39D", chk39D.Checked);
        //        dtHanTt = SQLExec.ExecuteReturnDt("sp_GetHanTt_CtAuTo", htParameter, CommandType.StoredProcedure);

        //        //Kiểm tra có Modify
        //        if (!dtHanTt.Columns.Contains("Modify"))
        //        {
        //            dtHanTt.Columns.Add(new DataColumn("Modify", typeof(bool)));
        //            dtHanTt.Columns["Modify"].DefaultValue = false;
        //        }

        //        bdsHanTt.DataSource = dtHanTt;
        //        dgvHanTt.DataSource = bdsHanTt;
        //    }

        //    this.Tinh_Tong();
        //}
        private void FillHanTtAuto(DateTime dtNgay_Ct, string strTk, string strMa_Dt, string strStt_PT)
        {
           
            Hashtable htParameter = new Hashtable();

            htParameter.Add("NGAY_CT2", dtNgay_Ct);
            htParameter.Add("TK", strTk);
            htParameter.Add("MA_DT", strMa_Dt);
            htParameter.Add("STT_PT", strStt_PT);
            htParameter.Add("MA_DVCS", Element.sysMa_DvCs);
            htParameter.Add("IS_02D", chk02D.Checked);
            htParameter.Add("IS_07D", chk07D.Checked);
            htParameter.Add("IS_39D", chk39D.Checked);

            htParameter.Add("IS_QH", chkQH.Checked);
            htParameter.Add("IS_DH", chkDH.Checked);
            htParameter.Add("IS_QDH", chkQDH.Checked);

            dtHanTt = SQLExec.ExecuteReturnDt("sp_GetHanTt_CtAuTo", htParameter, CommandType.StoredProcedure);

            //Kiểm tra có Modify
            if (!dtHanTt.Columns.Contains("Modify"))
            {
                dtHanTt.Columns.Add(new DataColumn("Modify", typeof(bool)));
                dtHanTt.Columns["Modify"].DefaultValue = false;
            }

            bdsHanTt.DataSource = dtHanTt;
            dgvHanTt.DataSource = bdsHanTt;
           

            this.Tinh_Tong();
        }
		private void SaveToHanTt(string strTk, string strMa_Dt, double dbTien_Tt, double dbTien_Tt_Nt, string strNo_Co, bool bIs_UngTruoc)
		{
			DataRow[] drArrHanTt = dtThanhToan.Select("Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");
			DataRow drAdd;

			if (drArrHanTt.Length == 0)
			{
				drAdd = dtThanhToan.NewRow();
				Common.SetDefaultDataRow(ref drAdd);

				dtThanhToan.Rows.Add(drAdd);
			}
			else
				drAdd = drArrHanTt[0];

			drAdd["Stt_PT"] = frmEditCt.dtEditCt.Rows[0]["Stt"];
			drAdd["Ma_Ct_PT"] = frmEditCt.dtEditCt.Rows[0]["Ma_Ct"];
			drAdd["Ngay_Ct_PT"] = frmEditCt.dtEditCt.Rows[0]["Ngay_Ct"];
			drAdd["So_Ct_PT"] = frmEditCt.dtEditCt.Rows[0]["So_Ct"];
			drAdd["Ma_Tte_PT"] = frmEditCt.dtEditCt.Rows[0]["Ma_Tte"];
			drAdd["Ty_Gia_PT"] = frmEditCt.dtEditCt.Rows[0]["Ty_Gia"];
			drAdd["Dien_Giai_PT"] = frmEditCt.dtEditCt.Rows[0]["Dien_Giai"];

			if (strNo_Co == "N" && (strTk.StartsWith("1") || strTk.StartsWith("2"))) //Lấy phần thanh toán C131
			{
				dbTien_Tt = -dbTien_Tt;
				dbTien_Tt_Nt = -dbTien_Tt_Nt;
			}
			else if (strNo_Co == "C" && (strTk.StartsWith("3") || strTk.StartsWith("4"))) //Lấy phần thanh toán N331
			{
				dbTien_Tt = -dbTien_Tt;
				dbTien_Tt_Nt = -dbTien_Tt_Nt;
			}

			if (Element.sysMa_Tte == "VND" && drAdd["Ma_Tte_PT"].ToString() == "VND")
				dbTien_Tt_Nt = 0;

			drAdd["Tk"] = strTk;
			drAdd["Ma_Dt"] = strMa_Dt;
			drAdd["Tien_PT"] = Convert.ToDouble(drAdd["Tien_PT"]) + dbTien_Tt;
			drAdd["Tien_PT_Nt"] = Convert.ToDouble(drAdd["Tien_PT_Nt"]) + dbTien_Tt_Nt;
			drAdd["Is_UngTruoc"] = bIs_UngTruoc;

			dtThanhToan.AcceptChanges();
		}
        private void Auto_Ticked_Tick()
        {
            //if (!Element.sysIs_Admin)
            //{
            //    string strUser = (string)drHanTt0["LastModify_Log"];
            //    if (strUser.Length > 0)
            //        strUser = strUser.Substring(14);

            //    if (strUser != string.Empty && strUser != Element.sysUser_Id)
            //    {
            //        Common.MsgCancel("Không được sửa dữ liệu do " + strUser + " đã thanh toán!");
            //        return;
            //    }
            //}

            //DataRow drThanhToan = ((DataRowView)bdsThanhToan.Current).Row;

            string strStt_PT = string.Empty;
            DateTime dtNgay_Ct_PT ;
            string strTk = string.Empty;
            string strMa_Dt = string.Empty;
            string strMa_Ct_Pt = string.Empty;
            double dbTien_Tt_PT = 0;
            double dbTien_Tt_PT_Nt = 0;
            double dbTy_Gia_PT = 0;
            double dbTTien_Tt = 0;
            DataTable dtCtHanTt_Save = SQLExec.ExecuteReturnDt("SELECT *, CAST(0 AS BIT) AS Thanh_Toan FROM R80CtHanTt WHERE 0 = 1");
            DataRow drNew;
            foreach (DataRow drThanhToan in dtThanhToan.Rows)
            {
                dbTTien_Tt = 0;
                strStt_PT = drThanhToan["Stt_PT"].ToString();
                dtNgay_Ct_PT = (DateTime)drThanhToan["Ngay_Ct_PT"];
                strMa_Dt = (string)drThanhToan["Ma_Dt"];
                strTk = (string)drThanhToan["Tk"];
                dbTien_Tt_PT = Convert.ToDouble(drThanhToan["Tien_PT"]);
                dbTien_Tt_PT_Nt = Convert.ToDouble(drThanhToan["Tien_PT_Nt"]);
                dbTy_Gia_PT = Math.Round(dbTien_Tt_PT / dbTien_Tt_PT_Nt, 2, MidpointRounding.AwayFromZero);
                
                
                FillHanTtAuto(dtNgay_Ct_PT, strTk, strMa_Dt, strStt_PT);

                //if (dtHanTt.Rows.Count == 0)
                //    break;

                foreach (DataRow drHanTt0 in dtHanTt.Select("(Tien_Tt1 = 0 OR Tien_No1 - Tien_Tt1 <> 0 OR Tien_No_Nt1 - Tien_Tt_Nt1 <> 0)"))
                {

                   
                    DateTime dtNgay_Ct_TT = dtNgay_Ct_PT > (DateTime)drHanTt0["Ngay_Ct_HD"] ? dtNgay_Ct_PT : (DateTime)drHanTt0["Ngay_Ct_HD"];

                    if (drHanTt0["Ngay_Ct_TT"] != DBNull.Value && (DateTime)drHanTt0["Ngay_Ct_TT"] != Element.sysNgay_Min && DateTime.Compare((DateTime)drHanTt0["Ngay_Ct_TT"], dtNgay_Ct_TT) > 0)
                        dtNgay_Ct_TT = (DateTime)drHanTt0["Ngay_Ct_TT"];

                    if (!Common.CheckDataLocked(dtNgay_Ct_TT))
                    {
                        Common.MsgCancel("Dữ liệu ngày [" + Library.DateToStr(dtNgay_Ct_TT) + "] đã khóa!");
                        return;
                    }

                    bool bThanh_Toan = true;
                    double dbTien_No1 = Convert.ToDouble(drHanTt0["Tien_No1"]);
                    double dbTien_No_Nt1 = Convert.ToDouble(drHanTt0["Tien_No_Nt1"]);
                    double dbTy_Gia_HD = Convert.ToDouble(drHanTt0["Ty_Gia_HD"]);

                    //Tổng số tiền đã thanh toán
                    double dbTTien_Tt1 = Common.SumDCValue(dtHanTt, "Tien_Tt1", "Stt_PT = '" + strStt_PT + "' AND Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");
                    double dbTTien_Tt_Nt1 = Common.SumDCValue(dtHanTt, "Tien_Tt_Nt1", "Stt_PT = '" + strStt_PT + "' AND Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");
                    dbTTien_Tt_Nt1 = Math.Round(dbTTien_Tt_Nt1, 2, MidpointRounding.AwayFromZero);
                    double dbTTien_CLTG = Common.SumDCValue(dtHanTt, "Tien_ClTg", "Stt_PT = '" + strStt_PT + "' AND Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");

                    double dbTTien_Tt_Allow;
                    double dbTTien_Tt_Nt_Allow;
                    double dbTien_Tt1;
                    double dbTien_Tt_Nt1;

                    //Tổng số tiền cho phép thanh toán
                    if (dbTien_Tt_PT >= 0)
                    {
                      
                        dbTTien_Tt_Allow = Math.Max(0, dbTien_Tt_PT - dbTTien_Tt1);
                        dbTTien_Tt_Nt_Allow = Math.Max(0, dbTien_Tt_PT_Nt - dbTTien_Tt_Nt1);

                        dbTien_Tt1 = Math.Min(dbTien_No1, dbTTien_Tt_Allow);
                        dbTien_Tt_Nt1 = Math.Min(dbTien_No_Nt1, dbTTien_Tt_Nt_Allow);
                    }
                    else
                    {
                        dbTTien_Tt_Allow = Math.Min(0, dbTien_Tt_PT - dbTTien_Tt1);
                        dbTTien_Tt_Nt_Allow = Math.Min(0, dbTien_Tt_PT_Nt - dbTTien_Tt_Nt1);

                        dbTien_Tt1 = Math.Max(dbTien_No1, dbTTien_Tt_Allow);
                        dbTien_Tt_Nt1 = Math.Max(dbTien_No_Nt1, dbTTien_Tt_Nt_Allow);
                    }

                    //Nếu thanh toán bằng Tiền_Nt => phải quy Tiền_Nt về Tien_VND theo tỷ giá trên phiếu thanh toán
                    if (dbTien_Tt_Nt1 > 0)
                    {
                        if (dbTy_Gia_PT == dbTy_Gia_HD) //Nếu Tỷ giá bằng nhau
                        {
                            //Không làm gì cả
                        }
                        else
                        {
                            if (dbTien_Tt_Nt1 == dbTTien_Tt_Nt_Allow) //Nếu trả hết tiền trên PT => trả hết tiền VND do lấy tỷ giá trên PT
                                dbTien_Tt1 = dbTTien_Tt_Allow;
                            else
                                dbTien_Tt1 = Math.Round(dbTien_Tt_Nt1 * dbTy_Gia_PT, 0, MidpointRounding.AwayFromZero);
                        }

                        //Hải kiểm tra lại tiền thanh toán cho phép: không được thanh toán vượt quá Tien_VND trên PT
                        if (dbTien_Tt_PT >= 0)
                            dbTien_Tt1 = Math.Min(dbTien_Tt1, dbTTien_Tt_Allow);
                        else
                            dbTien_Tt1 = Math.Max(dbTien_Tt1, dbTTien_Tt_Allow);
                    }

                    if (Math.Abs(dbTien_Tt1) + Math.Abs(dbTien_Tt_Nt1) != 0)
                    {
                        drHanTt0["Tien_Tt1"] = dbTien_Tt1;
                        drHanTt0["Tien_Tt_Nt1"] = dbTien_Tt_Nt1;
                        drHanTt0["Ngay_Ct_TT"] = dtNgay_Ct_TT;

                        drHanTt0["Stt_PT"] = strStt_PT;
                        drHanTt0["LastModify_Log"] = Common.GetCurrent_Log();

                        drHanTt0["Thanh_Toan"] = bThanh_Toan;
                        drHanTt0["Modify"] = true;

                        //this.btSave.Enabled = true;
                    }

                    //else //khong thanh toan
                    //{
                    //    drHanTt0["Tien_Tt1"] = 0;
                    //    drHanTt0["Tien_Tt_Nt1"] = 0;

                    //    drHanTt0["Ngay_Ct_TT"] = Element.sysNgay_Min;
                    //    //drHanTt0["Stt_PT"] = string.Empty;
                    //    drHanTt0["LastModify_Log"] = string.Empty;

                    //    drHanTt0["Thanh_Toan"] = bThanh_Toan;
                    //    drHanTt0["Modify"] = true;

                    //    this.btSave.Enabled = true;
                    //}

                 

                    //drHanTt0.AcceptChanges();
                    //dgvHanTt.EndEdit();

                    //this.Tinh_Tong();
                    //SAVE dữ liệu vào R80CTHANTT

                    drNew = dtCtHanTt_Save.NewRow();
                    Common.CopyDataRow(drHanTt0, drNew);

                    //Lưu thông tin Phiếu thu lên Phiếu Thanh toán
                    if (drNew["Ngay_Ct_TT"] == DBNull.Value && (DateTime)drNew["Ngay_Ct_TT"] == Element.sysNgay_Min)
                        drNew["Ngay_Ct_TT"] = Library.StrToDate(dteNgay_Ct.Text);

                    drNew["Stt_PT"] = drThanhToan["Stt_PT"];

                    drNew["Tk"] = drHanTt0["Tk"];
                    drNew["Ma_Dt"] = drHanTt0["Ma_Dt"];

                    drNew["Stt_HD"] = drHanTt0["Stt_HD"];
                    drNew["Tien_Tt"] = drHanTt0["Tien_Tt1"];
                    drNew["Tien_Tt_Nt"] = drHanTt0["Tien_Tt_Nt1"];
                    drNew["Tien_CLTG"] = drHanTt0["Tien_CLTG"];
                    drNew["LastModify_Log"] = drHanTt0["LastModify_Log"];
                  
                    if (Convert.ToDouble(drHanTt0["Tien_Tt1"]) != 0 && (drHanTt0["Ma_TTe_HD"].ToString() == Element.sysMa_Tte && (Convert.ToDouble(drHanTt0["Tien_No1"]) == Convert.ToDouble(drHanTt0["Tien_Tt1"]))) && (drHanTt0["Ma_TTe_HD"].ToString() != Element.sysMa_Tte && Convert.ToDouble(drHanTt0["Tien_No_Nt1"]) == Convert.ToDouble(drHanTt0["Tien_Tt_Nt1"])))
                        drNew["Is_TtHt"] = true;
                    else
                        drNew["Is_TtHt"] = false;

                    DataRow drPT = ((DataRowView)bdsThanhToan.Current).Row;
                    if (drPT["Ma_TTe_PT"].ToString() == Element.sysMa_Tte && Convert.ToDouble(drPT["Tien_PT"]) == Convert.ToDouble(drPT["Tien_Tt"]))
                        drNew["Is_TtHt_PT"] = true;
                    else if (drPT["Ma_TTe_PT"].ToString() != Element.sysMa_Tte && Convert.ToDouble(drPT["Tien_PT_Nt"]) == Convert.ToDouble(drPT["Tien_Tt_Nt"]))
                        drNew["Is_TtHt_PT"] = true;
                    else
                        drNew["Is_TtHt_PT"] = false;
                    
                    //dbTTien_Tt += Convert.ToDouble(drHanTt0["Tien_Tt1"]);
                    if (Convert.ToDouble(drNew["Tien_Tt"]) > 0)
                        dtCtHanTt_Save.Rows.Add(drNew);

                    //nếu thanh toán hết tiền BC thì lưu
                    //if (dbTien_Tt_PT == dbTTien_Tt)
                    //{
                    //    Save_Auto(drThanhToan["Ma_Ct_Pt"].ToString(), drThanhToan["Tk"].ToString(), drThanhToan["Ma_Dt"].ToString(), dtCtHanTt_Save);
                    //    dtCtHanTt_Save.Clear();
                    //    //FillHanTt();
                    //    break;
                    //}
                   
                  
                }
                if (dtCtHanTt_Save.Rows.Count > 0)
                {
                    Save_Auto(drThanhToan["Ma_Ct_Pt"].ToString(), drThanhToan["Tk"].ToString(), drThanhToan["Ma_Dt"].ToString(), dtCtHanTt_Save);
                    dtCtHanTt_Save.Clear();
                    //FillHanTt();
                }
                
            }


            Common.MsgOk("Đã thực hiện xong");

           
        }
        private void Save_Auto(string strMa_Ct_Pt, string strTk, string strMa_Dt, DataTable dtCtHanTt_Save1)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            //sqlCon.BeginTransaction("UPDATE_HANTT");

            sqlCom.CommandText = "Sp_Update_CtHanTt";
            sqlCom.CommandType = CommandType.StoredProcedure;

            //sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)RosySystem.enuEdit.Edit);
            sqlCom.Parameters.AddWithValue("@Stt", "");
            sqlCom.Parameters.AddWithValue("@Ma_Ct", strMa_Ct_Pt);
            sqlCom.Parameters.AddWithValue("@Tk", strTk);
            sqlCom.Parameters.AddWithValue("@Ma_Dt", strMa_Dt);
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_HanTt0
            SqlParameter paraHanTt0 = new SqlParameter();
            paraHanTt0.SqlDbType = SqlDbType.Structured;
            paraHanTt0.ParameterName = "@CtHanTt";
            paraHanTt0.TypeName = "TVP_CtHanTt";
            paraHanTt0.Value = Voucher.GetTVPValue("R80CtHanTt", "TVP_CtHanTt", dtCtHanTt_Save1);
            sqlCom.Parameters.Add(paraHanTt0);

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
		private void Auto_Ticked()
		{
			DataRow drHanTt0 = ((DataRowView)bdsHanTt.Current).Row;
			DataGridViewCell dgvCell = dgvHanTt.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (dgvCell.ReadOnly)
				return;

			if (Common.Inlist(strColumnName, "THANH_TOAN"))
			{
				//Không cho người này được sửa thanh toán của người khác
				if (!Element.sysIs_Admin)
				{
					string strUser = (string)drHanTt0["LastModify_Log"];
					if (strUser.Length > 0)
						strUser = strUser.Substring(14);

					if (strUser != string.Empty && strUser != Element.sysUser_Id)
					{
						Common.MsgCancel("Không được sửa dữ liệu do " + strUser + " đã thanh toán!");
						return;
					}
				}

				bool bThanh_Toan = !(bool)dgvCell.EditedFormattedValue;

				if (bThanh_Toan) //Thanh toan
				{
					DataRow drThanhToan = ((DataRowView)bdsThanhToan.Current).Row;

					string strStt_PT = drThanhToan["Stt_PT"].ToString();
					DateTime dtNgay_Ct_PT = (DateTime)drThanhToan["Ngay_Ct_PT"];
					string strTk = (string)drThanhToan["Tk"];
					string strMa_Dt = (string)drThanhToan["Ma_Dt"];
					double dbTien_Tt_PT = Convert.ToDouble(drThanhToan["Tien_PT"]);
					double dbTien_Tt_PT_Nt = Convert.ToDouble(drThanhToan["Tien_PT_Nt"]);
					double dbTy_Gia_PT = Math.Round(dbTien_Tt_PT / dbTien_Tt_PT_Nt, 2, MidpointRounding.AwayFromZero);

					DateTime dtNgay_Ct_TT = dtNgay_Ct_PT > (DateTime)drHanTt0["Ngay_Ct_HD"] ? dtNgay_Ct_PT : (DateTime)drHanTt0["Ngay_Ct_HD"];

					if (drHanTt0["Ngay_Ct_TT"] != DBNull.Value && (DateTime)drHanTt0["Ngay_Ct_TT"] != Element.sysNgay_Min && DateTime.Compare((DateTime)drHanTt0["Ngay_Ct_TT"], dtNgay_Ct_TT) > 0)
						dtNgay_Ct_TT = (DateTime)drHanTt0["Ngay_Ct_TT"];

                    if (!Common.CheckDataLocked(dtNgay_Ct_TT))
                    {
                        Common.MsgCancel("Dữ liệu ngày [" + Library.DateToStr(dtNgay_Ct_TT) + "] đã khóa!");
                        return;
                    }

					double dbTien_No1 = Convert.ToDouble(drHanTt0["Tien_No1"]);
					double dbTien_No_Nt1 = Convert.ToDouble(drHanTt0["Tien_No_Nt1"]);
					double dbTy_Gia_HD = Convert.ToDouble(drHanTt0["Ty_Gia_HD"]);

					//Tổng số tiền đã thanh toán
					double dbTTien_Tt1 = Common.SumDCValue(dtHanTt, "Tien_Tt1", "Stt_PT = '" + strStt_PT + "' AND Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");
					double dbTTien_Tt_Nt1 = Common.SumDCValue(dtHanTt, "Tien_Tt_Nt1", "Stt_PT = '" + strStt_PT + "' AND Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");
					dbTTien_Tt_Nt1 = Math.Round(dbTTien_Tt_Nt1, 2, MidpointRounding.AwayFromZero);
					double dbTTien_CLTG = Common.SumDCValue(dtHanTt, "Tien_ClTg", "Stt_PT = '" + strStt_PT + "' AND Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'");

					double dbTTien_Tt_Allow;
					double dbTTien_Tt_Nt_Allow;
					double dbTien_Tt1;
					double dbTien_Tt_Nt1;

					//Tổng số tiền cho phép thanh toán
					if (dbTien_Tt_PT >= 0)
					{
						dbTTien_Tt_Allow = Math.Max(0, dbTien_Tt_PT - dbTTien_Tt1);
						dbTTien_Tt_Nt_Allow = Math.Max(0, dbTien_Tt_PT_Nt - dbTTien_Tt_Nt1);

						dbTien_Tt1 = Math.Min(dbTien_No1, dbTTien_Tt_Allow);
						dbTien_Tt_Nt1 = Math.Min(dbTien_No_Nt1, dbTTien_Tt_Nt_Allow);
					}
					else
					{
						dbTTien_Tt_Allow = Math.Min(0, dbTien_Tt_PT - dbTTien_Tt1);
						dbTTien_Tt_Nt_Allow = Math.Min(0, dbTien_Tt_PT_Nt - dbTTien_Tt_Nt1);

						dbTien_Tt1 = Math.Max(dbTien_No1, dbTTien_Tt_Allow);
						dbTien_Tt_Nt1 = Math.Max(dbTien_No_Nt1, dbTTien_Tt_Nt_Allow);
					}

					//Nếu thanh toán bằng Tiền_Nt => phải quy Tiền_Nt về Tien_VND theo tỷ giá trên phiếu thanh toán
					if (dbTien_Tt_Nt1 > 0)
					{
						if (dbTy_Gia_PT == dbTy_Gia_HD) //Nếu Tỷ giá bằng nhau
						{
							//Không làm gì cả
						}
						else
						{
							if (dbTien_Tt_Nt1 == dbTTien_Tt_Nt_Allow) //Nếu trả hết tiền trên PT => trả hết tiền VND do lấy tỷ giá trên PT
								dbTien_Tt1 = dbTTien_Tt_Allow;
							else
								dbTien_Tt1 = Math.Round(dbTien_Tt_Nt1 * dbTy_Gia_PT, 0, MidpointRounding.AwayFromZero);
						}

						//Hải kiểm tra lại tiền thanh toán cho phép: không được thanh toán vượt quá Tien_VND trên PT
						if (dbTien_Tt_PT >= 0)
							dbTien_Tt1 = Math.Min(dbTien_Tt1, dbTTien_Tt_Allow);
						else
							dbTien_Tt1 = Math.Max(dbTien_Tt1, dbTTien_Tt_Allow);
					}

					if (Math.Abs(dbTien_Tt1) + Math.Abs(dbTien_Tt_Nt1) != 0)
					{
						drHanTt0["Tien_Tt1"] = dbTien_Tt1;
						drHanTt0["Tien_Tt_Nt1"] = dbTien_Tt_Nt1;
						drHanTt0["Ngay_Ct_TT"] = dtNgay_Ct_TT;

						drHanTt0["Stt_PT"] = strStt_PT;
						drHanTt0["LastModify_Log"] = Common.GetCurrent_Log();

						drHanTt0["Thanh_Toan"] = bThanh_Toan;
						drHanTt0["Modify"] = true;

						this.btSave_Auto.Enabled = true;
					}
				}
				else //khong thanh toan
				{
					drHanTt0["Tien_Tt1"] = 0;
					drHanTt0["Tien_Tt_Nt1"] = 0;

					drHanTt0["Ngay_Ct_TT"] = Element.sysNgay_Min;
					//drHanTt0["Stt_PT"] = string.Empty;
					drHanTt0["LastModify_Log"] = string.Empty;

					drHanTt0["Thanh_Toan"] = bThanh_Toan;
					drHanTt0["Modify"] = true;

					this.btSave_Auto.Enabled = true;
				}

				this.Calc_CLTG();

				drHanTt0.AcceptChanges();
				dgvHanTt.EndEdit();

				this.Tinh_Tong();
			}
		}

		private void Calc_CLTG()
		{
			DataRow drHanTt0 = ((DataRowView)bdsHanTt.Current).Row;

			DataGridViewCell dgvCell = dgvHanTt.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (btSave_Auto.Enabled)
			{
				double dbTien_No1 = Convert.ToDouble(drHanTt0["Tien_No1"]);
				double dbTien_No_Nt1 = Convert.ToDouble(drHanTt0["Tien_No_Nt1"]);

				double dbTien_Tt1 = Convert.ToDouble(drHanTt0["Tien_Tt1"]);
				double dbTien_Tt_Nt1 = Convert.ToDouble(drHanTt0["Tien_Tt_Nt1"]);

				double dbTy_Gia_Tt = 0;
				double dbTy_Gia_CL = 0;
				double dbTien_ClTg = 0;

				if (dbTien_Tt_Nt1 == 0 || dbTien_No_Nt1 == 0 || dbTien_Tt1 == dbTien_No1)
				{
					drHanTt0["Tien_CLTG"] = 0;
					return;
				}

				if (dbTien_Tt_Nt1 == dbTien_No_Nt1) //Thanh toán hết tiền Nt
				{
					if (((string)drHanTt0["Tk"]).StartsWith("1") || ((string)drHanTt0["Tk"]).StartsWith("2"))
						dbTien_ClTg = dbTien_Tt1 - dbTien_No1;
					else
						dbTien_ClTg = dbTien_No1 - dbTien_Tt1;
				}
				else
				{
					dbTy_Gia_Tt = Math.Round(dbTien_Tt1 / dbTien_Tt_Nt1, 2, MidpointRounding.AwayFromZero); //Convert.ToDouble(drHanTt["Ty_Gia"])

					if (((string)drHanTt0["Tk"]).StartsWith("1") || ((string)drHanTt0["Tk"]).StartsWith("2"))
						dbTy_Gia_CL = dbTy_Gia_Tt - Convert.ToDouble(drHanTt0["Ty_Gia_HD"]);
					else
						dbTy_Gia_CL = -dbTy_Gia_Tt + Convert.ToDouble(drHanTt0["Ty_Gia_HD"]);

					dbTien_ClTg = Math.Round(dbTy_Gia_CL * dbTien_Tt_Nt1, MidpointRounding.AwayFromZero);
				}

				drHanTt0["Tien_CLTG"] = dbTien_ClTg;
			}
		}

		private void Save_HanTt() //Lưu dữ liệu xuống, nhưng không làm thay đổi dữ liệu ở Form thanh toán
		{
			DataRow drThanhToan = ((DataRowView)bdsThanhToan.Current).Row;

			double dbTien_PT = Convert.ToDouble(drThanhToan["Tien_PT"]);
			double dbTien_PT_Nt = Convert.ToDouble(drThanhToan["Tien_PT_Nt"]);

			//Chỉ kiểm tra Tiền thanh toán bằng với Tổng tiền khi Không "Tạo Tiền thanh toán từ Hóa đơn"
			if (dbTien_PT != numTTien_Tt.Value)
			{
				if (!Common.MsgYes_No("Giá trị trên chứng từ thanh toán khác với tổng giá trị thanh toán. Bạn có muốn tiếp tục hay không?"))
					return;
			}
			else
			{
				if (dbTien_PT_Nt != numTTien_Tt_Nt.Value)
					if (!Common.MsgYes_No("Giá trị Nt trên chứng từ thanh toán khác với tổng giá trị Nt thanh toán. Bạn có muốn tiếp tục hay không?"))
						return;
			}

			if (this.frmEditCt != null) //Lưu xuống DataTable
			{
				string strTk = drThanhToan["Tk"].ToString();
				string strMa_Dt = drThanhToan["Ma_Dt"].ToString();

				//Xóa đi những dòng đã thanh toán cũ
				if (frmEditCt.dtHanTt0 != null)
				{
					foreach (DataRow dr in frmEditCt.dtHanTt0.Select("Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'"))
					{
						frmEditCt.dtHanTt0.Rows.Remove(dr);
					}
				}
				else
				{
					frmEditCt.dtHanTt0 = dtHanTt.Clone();
				}

				//Insert những thanh toán mới vào
				foreach (DataRow dr in dtHanTt.Select("Tk = '" + strTk + "' AND Ma_Dt = '" + strMa_Dt + "'"))
				{
					DataRow drNew = frmEditCt.dtHanTt0.NewRow();
					Common.CopyDataRow(dr, drNew);

					frmEditCt.dtHanTt0.Rows.Add(drNew);
				}

				frmEditCt.dtHanTt0.AcceptChanges();
				this.btSave_Auto.Enabled = false;
			}
			else //Lưu xuống SQL Server
			{
                DataTable dtCtHanTt_Save = SQLExec.ExecuteReturnDt("SELECT *, CAST(0 AS BIT) AS Thanh_Toan FROM R80CtHanTt WHERE 0 = 1");
				foreach (DataRow dr in dtHanTt.Select(bdsHanTt.Filter))
				{
					DataRow drNew = dtCtHanTt_Save.NewRow();
					Common.CopyDataRow(dr, drNew);

					//Lưu thông tin Phiếu thu lên Phiếu Thanh toán
					if (drNew["Ngay_Ct_TT"] == DBNull.Value && (DateTime)drNew["Ngay_Ct_TT"] == Element.sysNgay_Min)
						drNew["Ngay_Ct_TT"] = Library.StrToDate(dteNgay_Ct.Text);

					drNew["Stt_PT"] = drThanhToan["Stt_PT"];

					drNew["Tk"] = dr["Tk"];
					drNew["Ma_Dt"] = dr["Ma_Dt"];

					drNew["Stt_HD"] = dr["Stt_HD"];
					drNew["Tien_Tt"] = dr["Tien_Tt1"];
					drNew["Tien_Tt_Nt"] = dr["Tien_Tt_Nt1"];
					drNew["Tien_CLTG"] = dr["Tien_CLTG"];
					drNew["LastModify_Log"] = dr["LastModify_Log"];

                    if (Convert.ToDouble(dr["Tien_Tt1"]) != 0 && (dr["Ma_TTe_HD"].ToString() == Element.sysMa_Tte && (Convert.ToDouble(dr["Tien_No1"]) == Convert.ToDouble(dr["Tien_Tt1"]))) && (dr["Ma_TTe_HD"].ToString() != Element.sysMa_Tte && Convert.ToDouble(dr["Tien_No_Nt1"]) == Convert.ToDouble(dr["Tien_Tt_Nt1"])))
                        drNew["Is_TtHt"] = true;
                    else
                        drNew["Is_TtHt"] = false;

                    DataRow drPT = ((DataRowView)bdsThanhToan.Current).Row;
                    if (drPT["Ma_TTe_PT"].ToString() == Element.sysMa_Tte && Convert.ToDouble(drPT["Tien_PT"]) == Convert.ToDouble(drPT["Tien_Tt"]))
                        drNew["Is_TtHt_PT"] = true;
                    else if (drPT["Ma_TTe_PT"].ToString() != Element.sysMa_Tte && Convert.ToDouble(drPT["Tien_PT_Nt"]) == Convert.ToDouble(drPT["Tien_Tt_Nt"]))
                        drNew["Is_TtHt_PT"] = true;
                    else
                        drNew["Is_TtHt_PT"] = false;

					dtCtHanTt_Save.Rows.Add(drNew);
				}
				dtCtHanTt_Save.AcceptChanges();

				SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
				SqlCommand sqlCom = sqlCon.CreateCommand();

				//sqlCon.BeginTransaction("UPDATE_HANTT");

				sqlCom.CommandText = "Sp_Update_CtHanTt";
				sqlCom.CommandType = CommandType.StoredProcedure;

				//sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)RosySystem.enuEdit.Edit);
				sqlCom.Parameters.AddWithValue("@Stt", "");
				sqlCom.Parameters.AddWithValue("@Ma_Ct", drThanhToan["Ma_Ct_PT"]);
				sqlCom.Parameters.AddWithValue("@Tk", drThanhToan["Tk"]);
				sqlCom.Parameters.AddWithValue("@Ma_Dt", drThanhToan["Ma_Dt"]);
				sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

				//Tạo Table cho TVP_HanTt0
				SqlParameter paraHanTt0 = new SqlParameter();
				paraHanTt0.SqlDbType = SqlDbType.Structured;
				paraHanTt0.ParameterName = "@CtHanTt";
				paraHanTt0.TypeName = "TVP_CtHanTt";
				paraHanTt0.Value = Voucher.GetTVPValue("R80CtHanTt", "TVP_CtHanTt", dtCtHanTt_Save);
				sqlCom.Parameters.Add(paraHanTt0);

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

				this.btSave_Auto.Enabled = false;
			}
		}

		private void Tinh_Tong()
		{
			if (dtHanTt != null)
			{
				this.numTTien_Tt.Value = Common.SumDCValue(dtHanTt, "Tien_Tt1", "");
				this.numTTien_Tt_Nt.Value = Common.SumDCValue(dtHanTt, "Tien_Tt_Nt1", "");
				this.numTTien_CLTG.Value = Common.SumDCValue(dtHanTt, "Tien_CLTG", "");
			}
		}

		#endregion

		#region Event
        void UnCheckAll(CheckBox chkTest)
        {
            if (chkTest == chk02D && chkTest.Checked == true)
            {
                chk02D.Checked = true;
                chk07D.Checked = false;
                chk39D.Checked = false;
                chkQH.Checked = false;
                chkDH.Checked = false;
                chkQDH.Checked = false;
            }
            else if (chkTest == chk07D && chkTest.Checked == true)
            {
               
                chk02D.Checked = false;
                chk07D.Checked = true;
                chk39D.Checked = false;
                chkQH.Checked = false;
                chkDH.Checked = false;
                chkQDH.Checked = false;
            }
            else if (chkTest == chk39D && chkTest.Checked == true)
            {
                chk02D.Checked = false;
                chk07D.Checked = false;
                chk39D.Checked = true;
                chkQH.Checked = false;
                chkDH.Checked = false;
                chkQDH.Checked = false;
            }
            else if (chkTest == chkQH && chkTest.Checked == true)
            {
                chk02D.Checked = false;
                chk07D.Checked = false;
                chk39D.Checked = false;
                chkQH.Checked = true;
                chkDH.Checked = false;
                chkQDH.Checked = false;
            }
            else if (chkTest == chkDH && chkTest.Checked == true)
            {
                chk02D.Checked = false;
                chk07D.Checked = false;
                chk39D.Checked = false;
                chkQH.Checked = false;
                chkDH.Checked = true;
                chkQDH.Checked = false;
            }
            else if (chkTest == chkQDH && chkTest.Checked == true)
            {
                chk02D.Checked = false;
                chk07D.Checked = false;
                chk39D.Checked = false;
                chkQH.Checked = false;
                chkDH.Checked = false;
                chkQDH.Checked = true;
            }
        }
        void chk39D_CheckedChanged(object sender, EventArgs e)
        {
            
            UnCheckAll(chk39D);
            

            if (chk39D.Checked == true)
                btSave_Auto.Enabled = true;
            else
                btSave_Auto.Enabled = false;

        }

        void chk07D_CheckedChanged(object sender, EventArgs e)
        {
            
            UnCheckAll(chk07D);
            
            if (chk07D.Checked == true)
                btSave_Auto.Enabled = true;
            else
                btSave_Auto.Enabled = false;
        }

        void chk02D_CheckedChanged(object sender, EventArgs e)
        {
           
            UnCheckAll(chk02D);
          
            if (chk02D.Checked == true)
                btSave_Auto.Enabled = true;
            else
                btSave_Auto.Enabled = false;
           
        }

        void chkQDH_CheckedChanged(object sender, EventArgs e)
        {
           
            UnCheckAll(chkQDH);
           
            if (chkQDH.Checked == true)
                btSave_Auto.Enabled = true;
            else
                btSave_Auto.Enabled = false;
        }

        void chkQH_CheckedChanged(object sender, EventArgs e)
        {

            UnCheckAll(chkQH);
           

            if (chkQH.Checked == true)
                btSave_Auto.Enabled = true;
            else
                btSave_Auto.Enabled = false;
        }

        void chkDH_CheckedChanged(object sender, EventArgs e)
        {
           
            UnCheckAll(chkDH);
            
            if (chkDH.Checked == true)
                btSave_Auto.Enabled = true;
            else
                btSave_Auto.Enabled = false;
        }

		//Gắn đối tượng tìm kiếm
		void dgvThanhToan_GotFocus(object sender, EventArgs e)
		{
			this.ExportControl = dgvThanhToan;
			this.bdsSearch = bdsThanhToan;
		}

		//Điền dữ liệu Hóa đơn còn nợ khi thay đổi dòng
		void bdsThanhToan_PositionChanged(object sender, EventArgs e)
		{
            DataRow drThanhToan = ((DataRowView)bdsThanhToan.Current).Row;

            DateTime dtNgay_Ct = btRefresh.Enabled ? Library.StrToDate(dteNgay_Ct.Text) : (DateTime)drThanhToan["Ngay_Ct_PT"];

            string strTk = (string)drThanhToan["Tk"];
            string strMa_Dt = (string)drThanhToan["Ma_Dt"];
            string strStt_PT = (string)drThanhToan["Stt_PT"];

            this.FillHanTtAuto(dtNgay_Ct, strTk, strMa_Dt, strStt_PT);
		}

		//Khi thay đổi dòng, kiểm tra lưu dữ liệu nếu có thay đổi trên dòng cũ
		void dgvThanhToan_RowValidated(object sender, DataGridViewCellEventArgs e)
		{
            //if (this.btSave_Auto.Enabled == true)
            //{
            //    if (Common.MsgYes_No(Languages.GetLanguage("Do_You_Want_To_Save")))
            //        this.Save_HanTt();
            //    else
            //        this.btSave_Auto.Enabled = false;
            //}
		}

		//Gắn đối tượng tìm kiếm
		void dgvHanTt0_GotFocus(object sender, EventArgs e)
		{
			this.ExportControl = dgvHanTt;
			this.bdsSearch = bdsHanTt;
		}

		//Auto_Tick và tính CLTG khi người dùng tick thanh toán
		void dgvHanTt0_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			this.Auto_Ticked();
		}

		//Kiểm tra Chỉ cho phép người dùng tick vào phần thanh toán của chính người đó, mà không tick vào phần thanh toán của người khác đã tick
		void dgvHanTt0_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			DataGridViewCell dgvCell = dgvHanTt.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "TIEN_TT1,TIEN_TT_NT1"))
			{
				DataRow drHanTt0 = ((DataRowView)bdsHanTt.Current).Row;

				//Không cho người này được sửa thanh toán của người khác
				if (!Element.sysIs_Admin)
				{
					string strUser = (string)drHanTt0["LastModify_Log"];
					if (strUser.Length > 0)
						strUser = strUser.Substring(14);

					if (strUser != string.Empty && strUser != Element.sysUser_Id)
					{
						Common.MsgCancel("Không được sửa dữ liệu do " + strUser + " đã thanh toán!");
						this.btSave_Auto.Enabled = false;
						e.Cancel = true;

						return;
					}
				}

				this.btSave_Auto.Enabled = true;
			}
		}

		//Sau khi Tick xong, thì điền [Modify] = true
		void dgvHanTt0_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewCell dgvCell = dgvHanTt.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "TIEN_TT1,TIEN_TT_NT1"))
			{
				DataRow drHanTt0 = ((DataRowView)bdsHanTt.Current).Row;
				drHanTt0["Modify"] = true;

				this.Calc_CLTG();
				this.Tinh_Tong();
			}
		}

		//Kiểm tra Lock dữ liệu sau khi Binding Data vào Lưới
		void dgvHanTt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
		}

		void dgvThanhToan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (bdsThanhToan != null && bdsThanhToan.Position >= 0)
			{
				DataRow drCurrent = ((DataRowView)bdsThanhToan.Current).Row;

				txtTk.Text = drCurrent["Tk"].ToString();
				txtMa_Dt.Text = drCurrent["Ma_Dt"].ToString();
			}
		}

		void btRefresh_Click(object sender, EventArgs e)
		{
			if (this.frmEditCt != null) //Điền dữ liệu thanh toán từ EditCt
				FillThanhToanFromEditCt();
			else
				FillThanhToanFromCongNo();

		}

		void chkUpdate_Ngay_Ct_CheckedChanged(object sender, EventArgs e)
		{
			if (!chkUpdate_Ngay_Ct.Checked)
			{
				chkUpdate_Ngay_Ct.Checked = false;
				return;
			}

			if (dteNgay_Ct.IsNull || bdsThanhToan.Position < 0)
			{
				chkUpdate_Ngay_Ct.Checked = false;
				return;
			}

			if (!Common.CheckDataLocked(Library.StrToDate(dteNgay_Ct.Text)))
			{
				chkUpdate_Ngay_Ct.Checked = false;
				Common.MsgCancel("Dữ liệu đã khóa");
				return;
			}

			DataRow drThanhToan = ((DataRowView)bdsThanhToan.Current).Row;

			foreach (DataRow dr in dtHanTt.Select("Thanh_Toan = true"))
			{
				//Điều kiện: Ngay_Ct_Tt >= (Ngay_Ct_PT, Ngay_Ct_HD)
				if (Library.StrToDate(dteNgay_Ct.Text) >= (DateTime)dr["Ngay_Ct_HD"] && Library.StrToDate(dteNgay_Ct.Text) >= (DateTime)drThanhToan["Ngay_Ct_PT"])
				{
					dr["Ngay_Ct_TT"] = Library.StrToDate(dteNgay_Ct.Text);

					btSave_Auto.Enabled = true;
				}
			}
		}
        void btSave_Click(object sender, EventArgs e)
        {
            this.Save_HanTt();

            if (frmEditCt != null && chkUpdate_Ngay_Ct.Checked)
            {
                if (frmEditCt != null && frmEditCt.Controls.ContainsKey("dteNgay_Ct"))
                {
                    frmEditCt.Controls["dteNgay_Ct"].Text = dteNgay_Ct.Text;
                }
            }

            if (dtThanhToan.Rows.Count == 1 && frmEditCt != null)
            {
                this.Close();
            }
        }
		void btSave_Auto_Click(object sender, EventArgs e)
		{
            Auto_Ticked_Tick();
            
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = RosySystem.Public.Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lbtTen_Dt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt.Text = ((string)drLookup["Ten_Dt"]).Trim();
                
                FillThanhToanFromCongNo();
                //FillHanTt();
            }
        }

        
		#endregion

		protected override void OnShown(EventArgs e)
		{
			if (dgvHanTt.Columns.Contains("NGAY_CT_TT"))
			{
				foreach (DataGridViewRow dgvr in dgvHanTt.Rows)
				{
					if (dgvr.Cells["Ngay_Ct_Tt"].Value.GetType() == typeof(DateTime))
					{
						if (!Common.CheckDataLocked((DateTime)(dgvr.Cells["Ngay_Ct_Tt"].Value)))
						{
							dgvr.ReadOnly = true;
							dgvr.DefaultCellStyle.ForeColor = Color.Gray;
						}
					}
				}
			}

			base.OnShown(e);
		}

      
	}
}
