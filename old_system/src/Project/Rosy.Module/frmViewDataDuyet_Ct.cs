using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Customize;
using System.Collections;

namespace RosyModule
{
	public partial class frmViewDataDuyet_Ct : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		DataTable dtDataLogDetail;
		BindingSource bdsDataLogDetail = new BindingSource();
		DataRow drCurrent;
		rsDataGridView dgvDataLogDetail = new rsDataGridView();
		string strLoai_Duyet = "";
		public string strMa_Ct_List = string.Empty;
        public string strStt = string.Empty;
		#endregion

		#region Contructor

		public frmViewDataDuyet_Ct()
		{
			InitializeComponent();

            this.KeyDown += new KeyEventHandler(KeyDownEvent);
			dgvDataLogDetail.CellContentClick += new DataGridViewCellEventHandler(dgvDataLogDetail_CellContentClick);
		}

		

		new public void Load(string strLoai_Duyet)
		{
			this.strLoai_Duyet = strLoai_Duyet;

			Build();
			FillData();
			BindingLanguage();

            if (Common.InlistLike(@strLoai_Duyet, "SOPKD,SOPKT,SO_HUY,SOCP_HUY"))
            {
                if (dgvDataLogDetail.Columns.Contains("DUYET"))
                    dgvDataLogDetail.Columns["DUYET"].HeaderText = "Duyệt PKT";
                
                if (dgvDataLogDetail.Columns.Contains("GHI_CHU_HUY"))
                    dgvDataLogDetail.Columns["GHI_CHU_HUY"].HeaderText = "Lý do đóng ĐH";
                if (dgvDataLogDetail.Columns.Contains("USER_HUY"))
                    dgvDataLogDetail.Columns["USER_HUY"].HeaderText = "User đóng ĐH";
                if (dgvDataLogDetail.Columns.Contains("SO_LUONG0"))
                    dgvDataLogDetail.Columns["SO_LUONG0"].HeaderText = "Số bộ KCS";
            }
            else
                if (dgvDataLogDetail.Columns.Contains("DUYET_HUY"))
                    dgvDataLogDetail.Columns["DUYET_HUY"].HeaderText = "Hủy đề nghị";

           
            this.Show();
		}

		private void Build()
		{
            if (Common.InlistLike(@strLoai_Duyet, "HDDT"))
			{
				dgvDataLogDetail.strZone = "HDDT_DUYET";
			}
            else if (Common.InlistLike(@strLoai_Duyet, "TPPT,PXCDCK,KTCDATPT,KHVTPT,KTPT,GDPT,TP_DTCP,KTCD_DTCP,KTTC_DTCP,GD_DTCP"))
			{
				dgvDataLogDetail.strZone = "RED_PTDUYET";
			}
			else if (Common.InlistLike(@strLoai_Duyet, "TPDN,KTCDATDN"))
			{
				dgvDataLogDetail.strZone = "RED_DNDUYET";
			}
			else if (Common.InlistLike(@strLoai_Duyet, "PHANHOI"))
			{
				dgvDataLogDetail.strZone = "PHANHOI";
			}
            else if (Common.InlistLike(@strLoai_Duyet, "REMIN_HDLD"))
            {
                dgvDataLogDetail.strZone = "RED_HDLD";
            }
            else if (Common.InlistLike(@strLoai_Duyet, "NVMH,DTCHAM,GHCHAM"))
            {
                dgvDataLogDetail.strZone = "NVMH_DT"; //PYC chưa lập DT
               
                if (dgvDataLogDetail.Columns.Contains("END"))
                    dgvDataLogDetail.Columns["END"].Visible = Common.CheckPermission("IS_END_PYC", enuPermission_Type.Allow_Access);
                
                if (dgvDataLogDetail.Columns.Contains("PHAN_HOI_KHVT"))
                    dgvDataLogDetail.Columns["PHAN_HOI_KHVT"].Visible = Common.CheckPermission("PHAN_HOI_KHVT", enuPermission_Type.Allow_Access);

            }
            else if (Common.InlistLike(@strLoai_Duyet, "SOPKD,SOPKT,SO_HUY,SOCP_HUY"))
            {
                dgvDataLogDetail.strZone = "SO_VIEW_DUYET";
            }
            else if (Common.InlistLike(@strLoai_Duyet, "SOPKD,SOPKT,SO_HUY,SOCP_HUY"))
            {
                dgvDataLogDetail.strZone = "SO_VIEW_DUYET";
            }
            else if (Common.InlistLike(@strLoai_Duyet, "MMBTTN,MMBTTS"))
            {
                dgvDataLogDetail.strZone = "RED_MMTB";
            }
            else if (Common.InlistLike(@strLoai_Duyet, "TRUONGDV"))
            {
                dgvDataLogDetail.strZone = "RED_MMTB_TDV";
            }
            else if (Common.InlistLike(@strLoai_Duyet, "PXCD"))
            {
                dgvDataLogDetail.strZone = "RED_MMTB_PXCD";
            }
            else if (Common.InlistLike(@strLoai_Duyet, "KTCD"))
            {
                dgvDataLogDetail.strZone = "RED_MMTB_KTCD";
            }
            else if (Common.InlistLike(@strLoai_Duyet, "GIAMDOC"))
            {
                dgvDataLogDetail.strZone = "RED_MMTB_GIAMDOC";
            }
            else if (Common.InlistLike(@strLoai_Duyet, "DNTT,DNTU"))
            {
                dgvDataLogDetail.strZone = "RED_CASH_DTTT";
            }
            else
				dgvDataLogDetail.strZone = "SO_VIEWPH";

           
			dgvDataLogDetail.Dock = DockStyle.Fill;
			dgvDataLogDetail.BuildGridView();
			this.Controls.Add(dgvDataLogDetail);
            ProcessColumn();
		}
        private void ProcessColumn()
        {
            bool bDuyet_Tp = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
            bool bDuyet_PxCd = Common.CheckPermission("IS_TP_PXCD", enuPermission_Type.Allow_Access);
            bool bDuyet_KtCdAt = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
            bool bDuyet_KhVt = Common.CheckPermission("IS_TP_KHVT", enuPermission_Type.Allow_Access);
            bool bDuyet_KtTc = Common.CheckPermission("IS_TP_KTTC", enuPermission_Type.Allow_Access);
            bool bDuyet_Gd = Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access);
            //XỬ LÝ CÁC USER
            // 1. Là TP 
            if (bDuyet_Tp && Common.Inlist(@strLoai_Duyet, "TPPT,TP_DTCP"))
            {
                dgvDataLogDetail.Columns["Duyet_PXCD"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KTCDAT"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KHVT"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KTTC"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_GIAMDOC"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_HUY"].Visible = false;
            }
            // 2. Là TP PXCD
            if (bDuyet_PxCd && @strLoai_Duyet == "PXCDCK")
            {
                dgvDataLogDetail.Columns["Duyet_TP"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KTCDAT"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KHVT"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KTTC"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_GIAMDOC"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_HUY"].Visible = false;
            }
            // 3. Là TP KTDT
            if (bDuyet_KtCdAt && Common.Inlist(@strLoai_Duyet, "KTCDATPT,KTCD_DTCP"))
            {
                dgvDataLogDetail.Columns["Duyet_TP"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_PXCD"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KHVT"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KTTC"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_GIAMDOC"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_HUY"].Visible = false;
            }
            // 4. Là TP KHVT
            if (bDuyet_KhVt && Common.Inlist(@strLoai_Duyet,"KHVTPT"))
            {
                dgvDataLogDetail.Columns["Duyet_TP"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_PXCD"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KTCDAT"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KTTC"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_GIAMDOC"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_HUY"].Visible = false;
            }
            // 5. Là KTTC
            if (bDuyet_KtTc && Common.Inlist(@strLoai_Duyet, "KTPT,KTTC_DTCP"))
            {
                dgvDataLogDetail.Columns["DUYET_TP"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_PXCD"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_KTCDAT"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_KHVT"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_GIAMDOC"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_HUY"].Visible = false;
            }
            // 6. Là GD
            if (bDuyet_Gd && Common.Inlist(@strLoai_Duyet, "GDPT,GD_DTCP"))
            {
                dgvDataLogDetail.Columns["Duyet_TP"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_PXCD"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KTCDAT"].Visible = false;
                dgvDataLogDetail.Columns["Duyet_KHVT"].Visible = false;
                dgvDataLogDetail.Columns["DUYET_KTTC"].Visible = false;
            }
        }
		private void FillData()
		{
            if (!Common.InlistLike(strLoai_Duyet, "PHANHOI,MMBTTN,MMBTTS,TRUONGDV,PXCD,GIAMDOC,KTCD_BBHH,KTCD_BTKH,KTCD_BTBN,TP_DTCP,KTCD_DTCP,KTTC_DTCP,GD_DTCP"))
			{
				Hashtable ht = new Hashtable();
				ht.Add("LOAI_DUYET", strLoai_Duyet);
				ht.Add("MEMBER_ID", Element.sysUser_Id);

				dtDataLogDetail = SQLExec.ExecuteReturnDt("sp_GetReminder_DuyetPYC", ht, CommandType.StoredProcedure);
			}
            else if (Common.InlistLike(strLoai_Duyet, "MMBTTN,MMBTTS,TRUONGDV,PXCD,GIAMDOC,KTCD_BBHH,KTCD_BTKH,KTCD_BTBN,TP_DTCP,KTCD_DTCP,KTTC_DTCP,GD_DTCP"))
            {
                Hashtable ht1 = new Hashtable();
                ht1.Add("LOAI_TB", strLoai_Duyet);
                ht1.Add("USER_LOGIN", Element.sysUser_Id);
                dtDataLogDetail = SQLExec.ExecuteReturnDt("sp_GetReminder_MMTB", ht1, CommandType.StoredProcedure);
            }
            else
            {
                string strSql = "SELECT T1.Stt, Ma_Ct, So_Ct, SUBSTRING(T2.Create_Log,15,20) AS Ma_Dt_CbNv, Ngay_Ct, DIEN_GIAI, T1.Ghi_Chu, Is_Ht, Ht_Log, T2.Create_Log FROM R04CTPO_PHANHOI T1 JOIN R80PH T2 ON  T1.Stt = T2.Stt WHERE Is_Ht = 0";
                dtDataLogDetail = SQLExec.ExecuteReturnDt(strSql);
            }

			bdsDataLogDetail.DataSource = dtDataLogDetail;
			dgvDataLogDetail.DataSource = bdsDataLogDetail;
			dgvDataLogDetail.ResizeGridView();

			this.bdsSearch = bdsDataLogDetail;
			this.ExportControl = dgvDataLogDetail;
		}
        void dgvDataLogDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool Is_Duyet = false;
            bool bDuyet = false;
            string strTable_Ph = string.Empty;
            string strColumnName = dgvDataLogDetail.Columns[e.ColumnIndex].Name;
            drCurrent = ((DataRowView)bdsDataLogDetail.Current).Row;
            
            if (dgvDataLogDetail.Columns.Contains("Ma_Ct"))
            {
                strMa_Ct_List = drCurrent["Ma_Ct"].ToString();
                strStt = drCurrent["Stt"].ToString();
                strTable_Ph = DataTool.SQLGetNameByCode("R00DMCT", "Ma_Ct", "Table_Ph", strMa_Ct_List);
            }
            drCurrent = DataTool.SQLGetDataRowByID(strTable_Ph, "Stt", strStt);
            if (!Common.InlistLike(strLoai_Duyet, "PHANHOI,MMBTTN,MMBTTS,TRUONGDV,PXCD,GIAMDOC,KTCD_BBHH,KTCD_BTKH,KTCD_BTBN"))
            {
                if (strColumnName == "DUYET_PKD")
                {
                    string strCreate_User = (string)drCurrent["Create_Log"];
                    string strUser_Allow = string.Empty;
                    string strUser_Duyet_PKD = (string)drCurrent["User_Duyet_PKD"];

                    if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
                    {
                        strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                    }

                    if (Common.Inlist(strMa_Ct_List, "SO,SOCP") && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
                    {
                        if (Common.CheckPermission("DUYET_PKD", enuPermission_Type.Allow_Access) && (Element.sysUser_Id.ToString().Trim() == strUser_Duyet_PKD.Trim() || string.IsNullOrEmpty(strUser_Duyet_PKD)))
                        {
                            frmDuyet_PKD frm = new frmDuyet_PKD();
                            frm.Load(drCurrent);
                            FillData();
                        }
                        else
                            Common.MsgOk("Bạn không có quyền duyệt hoặc hủy duyệt của người khác");
                    }
                }

                if (strColumnName == "DUYET")
                {
                    bool bDuyet_SO_PKT = Common.CheckPermission("DUYET_SO_PKT", enuPermission_Type.Allow_Access);

                    if (Common.Inlist((string)drCurrent["Ma_Ct"], "SO,SOCP"))
                    {
                        if (bDuyet_SO_PKT)
                        {
                            frmDuyetYeuCau frm = new frmDuyetYeuCau();
                            frm.Load(drCurrent, Is_Duyet, strColumnName);

                            if (frm.Is_Accept)
                            {
                                string strSQLExec = string.Empty;
                                Hashtable htPara = new Hashtable();

                                drCurrent["DUYET"] = frm.chkDuyet.Checked;


                                htPara.Add("DUYET", (bool)drCurrent["DUYET"]);
                                htPara.Add("IS_VT_NHAN", (bool)drCurrent["IS_VT_NHAN"]);
                                htPara.Add("GHI_CHU_PKTTC", frm.txtGhi_Chu_PKTTC.Text);
                                htPara.Add("STT", drCurrent["STT"]);
                                htPara.Add("DUYET_LOG", Common.GetCurrent_Log());

                                strSQLExec = "UPDATE R80PH SET DUYET = @DUYET, DUYET_LOG = @DUYET_LOG, GHI_CHU_PKTTC = @GHI_CHU_PKTTC WHERE Stt = @STT";
                                SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                                FillData();
                            }
                        }
                    }



                }


                if (strColumnName == "DUYET_TP")
                {
                    if (Common.Inlist(strMa_Ct_List, "PYCPT,PYCCK,PYCTH"))
                    {
                        bDuyet = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
                    }
                    else
                    {
                        bDuyet = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
                        if (!bDuyet)
                            bDuyet = Common.CheckPermission("IS_PTP", enuPermission_Type.Allow_Access);
                    }
                    Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_TP FROM R80PH WHERE Stt = '" + strStt + "'"));
                    if (!bDuyet)
                        return;

                    frmDuyetYeuCau frm = new frmDuyetYeuCau();
                    frm.Load(drCurrent, Is_Duyet, strColumnName);

                    if (frm.Is_Accept)
                    {
                        string strSQLExec = string.Empty;
                        Hashtable htPara = new Hashtable();

                        drCurrent["DUYET_TP"] = frm.chkDuyet.Checked;

                        htPara.Add("DUYET_TP", (bool)drCurrent["DUYET_TP"]);
                        htPara.Add("STT", drCurrent["STT"]);
                        htPara.Add("DUYET_TP_LOG", Common.GetCurrent_Log());

                        strSQLExec = "UPDATE R80PH SET DUYET_TP = @DUYET_TP, DUYET_TP_LOG = @DUYET_TP_LOG  WHERE Stt = @STT";
                        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                        FillData();
                    }
                }

                if (strColumnName == "DUYET_KTCDAT")
                {
                    bDuyet = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
                    Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_KTCDAT FROM R80PH WHERE Stt = '" + strStt + "'"));
                    if (!bDuyet)
                        return;

                    frmDuyetYeuCau frm = new frmDuyetYeuCau();
                    frm.Load(drCurrent, Is_Duyet, strColumnName);

                    if (frm.Is_Accept)
                    {
                        string strSQLExec = string.Empty;
                        Hashtable htPara = new Hashtable();

                        drCurrent["DUYET_KTCDAT"] = frm.chkDuyet.Checked;

                        htPara.Add("DUYET_KTCDAT", (bool)drCurrent["DUYET_KTCDAT"]);
                        htPara.Add("STT", drCurrent["STT"]);
                        htPara.Add("DUYET_KTCDAT_LOG", Common.GetCurrent_Log());

                        strSQLExec = "UPDATE R80PH SET DUYET_KTCDAT = @DUYET_KTCDAT, DUYET_KTCDAT_LOG = @DUYET_KTCDAT_LOG  WHERE Stt = @STT";
                        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                        FillData();
                    }
                }

                if (strColumnName == "DUYET_KHVT")
                {
                    bDuyet = Common.CheckPermission("IS_TP_KHVT", enuPermission_Type.Allow_Access);
                    Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_KHVT FROM R80PH WHERE Stt = '" + strStt + "'"));
                    if (!bDuyet)
                        return;

                    frmDuyetYeuCau frm = new frmDuyetYeuCau();
                    frm.Load(drCurrent, Is_Duyet, strColumnName);

                    if (frm.Is_Accept)
                    {
                        string strSQLExec = string.Empty;
                        Hashtable htPara = new Hashtable();

                        drCurrent["DUYET_KHVT"] = frm.chkDuyet.Checked;

                        htPara.Add("DUYET_KHVT", (bool)drCurrent["DUYET_KHVT"]);
                        htPara.Add("STT", drCurrent["STT"]);
                        htPara.Add("DUYET_KHVT_LOG", Common.GetCurrent_Log());

                        strSQLExec = "UPDATE R80PH SET DUYET_KHVT = @DUYET_KHVT, DUYET_KHVT_LOG = @DUYET_KHVT_LOG  WHERE Stt = @STT";
                        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                        FillData();
                    }
                }
                //if (strColumnName == "DUYET_TCHC")
                //{
                //    bDuyet = Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access);

                //    if (!bDuyet)
                //        return;

                //    frmDuyetYeuCau frm = new frmDuyetYeuCau();
                //    frm.Load(drCurrent, Is_Duyet);

                //    if (frm.Is_Accept)
                //    {
                //        string strSQLExec = string.Empty;
                //        Hashtable htPara = new Hashtable();

                //        drCurrent["DUYET_TCHC"] = frm.chkDuyet.Checked;

                //        htPara.Add("DUYET_TCHC", (bool)drCurrent["DUYET_TCHC"]);
                //        htPara.Add("STT", drCurrent["STT"]);
                //        htPara.Add("DUYET_TCHC_LOG", Common.GetCurrent_Log());

                //        strSQLExec = "UPDATE R80PH SET DUYET_TCHC = @DUYET_TCHC, DUYET_TCHC_LOG = @DUYET_TCHC_LOG  WHERE Stt = @STT";
                //        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                //    }
                //}

                if (strColumnName == "DUYET_KTTC")
                {
                    if (Common.Inlist(strMa_Ct_List, "DT,DTVPP"))
                    {
                        if (!(bool)(drCurrent["DUYET_KHVT"]))
                            return;

                    }

                    bDuyet = Common.CheckPermission("IS_TP_KTTC", enuPermission_Type.Allow_Access);
                    Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_KTTC FROM R80PH WHERE Stt = '" + strStt + "'"));
                    if (!bDuyet)
                        return;

                    frmDuyetYeuCau frm = new frmDuyetYeuCau();
                    frm.Load(drCurrent, Is_Duyet, strColumnName);

                    if (frm.Is_Accept)
                    {
                        string strSQLExec = string.Empty;
                        Hashtable htPara = new Hashtable();

                        drCurrent["DUYET_KTTC"] = frm.chkDuyet.Checked;

                        htPara.Add("DUYET_KTTC", (bool)drCurrent["DUYET_KTTC"]);
                        htPara.Add("STT", drCurrent["STT"]);
                        htPara.Add("DUYET_KTTC_LOG", Common.GetCurrent_Log());

                        strSQLExec = "UPDATE R80PH SET DUYET_KTTC = @DUYET_KTTC, DUYET_KTTC_LOG = @DUYET_KTTC_LOG  WHERE Stt = @STT";
                        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                        FillData();
                    }
                }
                if (strColumnName == "DUYET_PXCD")
                {
                    bDuyet = Common.CheckPermission("IS_TP_PXCD", enuPermission_Type.Allow_Access);
                    Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_PXCD FROM R80PH WHERE Stt = '" + strStt + "'"));
                    if (!bDuyet)
                        return;

                    frmDuyetYeuCau frm = new frmDuyetYeuCau();
                    frm.Load(drCurrent, Is_Duyet, strColumnName);

                    if (frm.Is_Accept)
                    {
                        string strSQLExec = string.Empty;
                        Hashtable htPara = new Hashtable();

                        drCurrent["DUYET_PXCD"] = frm.chkDuyet.Checked;

                        htPara.Add("DUYET_PXCD", (bool)drCurrent["DUYET_PXCD"]);
                        htPara.Add("STT", drCurrent["STT"]);
                        htPara.Add("DUYET_PXCD_LOG", Common.GetCurrent_Log());

                        strSQLExec = "UPDATE R80PH SET DUYET_PXCD = @DUYET_PXCD, DUYET_PXCD_LOG = @DUYET_PXCD_LOG WHERE Stt = @STT";
                        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                        FillData();
                    }
                }

                if (strColumnName == "DUYET_GIAMDOC")
                {
                    //DataRow drPhPKD = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt);
                    if (Common.InlistLike(strMa_Ct_List, "DT"))
                    {
                        
                        if (!(bool)(drCurrent["DUYET_KTTC"]))
                        {
                            Common.MsgOk("Phiếu yêu cầu đã được PKTTC gỡ duyệt, anh chị vui lòng liên hệ PKTTC để tiếp tục, hiện chứng từ không được duyệt.");
                            return;
                        }

                    }
                    if (Common.InlistLike(strMa_Ct_List, "PYC"))
                    {
                        if (!(bool)(drCurrent["DUYET_KHVT"]))
                        {
                            Common.MsgOk("Phiếu yêu cầu đã được PKHVT gỡ duyệt, anh chị vui lòng liên hệ PKHVT để tiếp tục, hiện chứng từ không được duyệt.");
                            return;
                        }
                            
                    }
                    bDuyet = Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access);
                    Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_GIAMDOC FROM R80PH WHERE Stt = '" + strStt + "'"));

                    if (!bDuyet)
                        return;

                    if (drCurrent["GD_Duyet"].ToString() != Element.sysUser_Id) //&& strDuyet_GD_Log.Substring(14) != Element.sysUser_Id
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chứng từ được trình '" + drCurrent["GD_Duyet"] + "'" : "Do not register transaction type";
                        Common.MsgCancel(strMsg);
                        return;
                    }

                    frmDuyetYeuCau frm = new frmDuyetYeuCau();
                    frm.Load(drCurrent, Is_Duyet, strColumnName);

                    if (frm.Is_Accept)
                    {
                        string strSQLExec = string.Empty;
                        Hashtable htPara = new Hashtable();

                        drCurrent["DUYET_GIAMDOC"] = frm.chkDuyet.Checked;
                        drCurrent["DUYET_HUY"] = frm.chkDuyet_Huy.Checked;

                        htPara.Add("DUYET_GIAMDOC", (bool)drCurrent["DUYET_GIAMDOC"]);
                        htPara.Add("DUYET_HUY", (bool)drCurrent["DUYET_HUY"]);
                        htPara.Add("STT", drCurrent["STT"]);
                        htPara.Add("DUYET_GD_LOG", Common.GetCurrent_Log());

                        strSQLExec = "UPDATE R80PH SET DUYET_GIAMDOC = @DUYET_GIAMDOC, DUYET_GD_LOG = @DUYET_GD_LOG, DUYET_HUY = @DUYET_HUY WHERE Stt = @STT";
                        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                        FillData();
                    }
                }
                if (strColumnName == "IS_HT")
                {
                    Hashtable htPara = new Hashtable();
                    htPara.Add("STT", drCurrent["STT"]);
                    htPara.Add("HT_LOG", Common.GetCurrent_Log());

                    string strSQL = "UPDATE R04CTPO_PHANHOI SET Is_Ht = 1, Ht_Log = @Ht_Log WHERE Stt =@STT";
                    SQLExec.Execute(strSQL, htPara, CommandType.Text);
                    FillData();
                }
                if (strColumnName == "THONGTIN")
                {
                    if (bdsDataLogDetail.Position < 0)
                        return;

                    drCurrent = ((DataRowView)bdsDataLogDetail.Current).Row;
                    bool bInVisibleNextPrint = false;

                    Voucher.Print(drCurrent["Stt"].ToString(), true, true, ref bInVisibleNextPrint);
                }
                if (strColumnName == "DUYET_HUY")
                {
                    string strCreate_User = (string)drCurrent["Create_Log"];
                    string strUser_Allow = string.Empty;
                    string strUser_Duyet_Huy = (string)drCurrent["User_Huy"];
                    string strUser_Admin = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID FROM R00MEMBERGROUP WHERE Member_Group_ID = 'ADMINS' AND Member_ID = '" + Element.sysUser_Id + "'") + ",";

                    if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
                    {
                        strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                    }
                    //Kiểm tra đã ra phiếu xuất hay HD thì không được đóng

                    if (Common.CheckPermission("DUYET_HUY", enuPermission_Type.Allow_Access) && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
                    {
                        if (Element.sysUser_Id.ToString().Trim() == strUser_Duyet_Huy.Trim() || string.IsNullOrEmpty(strUser_Duyet_Huy))
                        {
                            frmDuyet_Huy frm = new frmDuyet_Huy();
                            frm.Load(drCurrent);
                        }
                        else if (strUser_Admin != ",")
                        {
                            frmDuyet_Huy frm = new frmDuyet_Huy();
                            frm.Load(drCurrent);
                        }
                        else
                            Common.MsgOk("Bạn không có quyền duyệt hoặc hủy duyệt của người khác");
                    }

                }
                
                if (strColumnName == "END")
                {
                    if (bdsDataLogDetail.Position < 0)
                        return;

                    drCurrent = ((DataRowView)bdsDataLogDetail.Current).Row;
                    //bool bInVisibleNextPrint = false;

                    //Voucher.Print(drCurrent["Stt"].ToString(), true, true, ref bInVisibleNextPrint);
                }
                else if (strColumnName == "PHAN_HOI_KHVT")
                {
                    DataRow drPh = DataTool.SQLGetDataRowByID("R80PH", "STT", strStt);
                    frmPhan_Hoi_KHVT frm = new frmPhan_Hoi_KHVT();
                    frm.Load(drPh, drCurrent["Ma_Vt"].ToString(), "PKHVT");
                }
                
            }
            else if (Common.InlistLike(strLoai_Duyet, "MMBTTN,MMBTTS,TRUONGDV,PXCD,GIAMDOC,KTCD_BBHH,KTCD_BTKH,KTCD_BTBN"))
            {
                if (strColumnName == "DUYET_TP")
                {
                    bDuyet = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
                    Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_TP FROM R06PH_BTTB WHERE Stt = '" + strStt + "'"));
                    if (!bDuyet)
                        return;

                    frmDuyetQLMMTB frm = new frmDuyetQLMMTB();
                    frm.Load(drCurrent, Is_Duyet, strColumnName);

                    if (frm.Is_Accept)
                    {
                        string strSQLExec = string.Empty;
                        Hashtable htPara = new Hashtable();

                        drCurrent["DUYET_TP"] = frm.chkDuyet.Checked;

                        htPara.Add("DUYET_TP", (bool)drCurrent["DUYET_TP"]);
                        htPara.Add("STT", drCurrent["STT"]);
                        htPara.Add("DUYET_TP_LOG", Common.GetCurrent_Log());

                        strSQLExec = "UPDATE R06PH_BTTB SET DUYET_TP = @DUYET_TP, DUYET_TP_LOG = @DUYET_TP_LOG  WHERE Stt = @STT";
                        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                        FillData();
                    }
                }
                if (strColumnName == "DUYET_PXCD")
                {
                    bDuyet = Common.CheckPermission("IS_TP_PXCD", enuPermission_Type.Allow_Access);
                    Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_PXCD FROM R06PH_BTTB WHERE Stt = '" + strStt + "'"));


                    frmDuyetQLMMTB frm = new frmDuyetQLMMTB();
                    frm.Load(drCurrent, Is_Duyet, strColumnName);

                    if (frm.Is_Accept)
                    {
                        string strSQLExec = string.Empty;
                        Hashtable htPara = new Hashtable();

                        drCurrent["DUYET_PXCD"] = frm.chkDuyet.Checked;

                        htPara.Add("DUYET_PXCD", (bool)drCurrent["DUYET_PXCD"]);
                        htPara.Add("STT", drCurrent["STT"]);
                        htPara.Add("DUYET_PXCD_LOG", Common.GetCurrent_Log());

                        strSQLExec = "UPDATE R06PH_BTTB SET DUYET_PXCD = @DUYET_PXCD, DUYET_PXCD_LOG = @DUYET_PXCD_LOG WHERE Stt = @STT";
                        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                        FillData();
                    }
                }
                if (strColumnName == "DUYET_KTCDAT")
                {
                    bDuyet = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
                    Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_KTCDAT FROM R06PH_BTTB WHERE Stt = '" + strStt + "'"));
                    if (!bDuyet)
                        return;

                    frmDuyetQLMMTB frm = new frmDuyetQLMMTB();
                    frm.Load(drCurrent, Is_Duyet, strColumnName);

                    if (frm.Is_Accept)
                    {
                        string strSQLExec = string.Empty;
                        Hashtable htPara = new Hashtable();

                        drCurrent["DUYET_KTCDAT"] = frm.chkDuyet.Checked;

                        htPara.Add("DUYET_KTCDAT", (bool)drCurrent["DUYET_KTCDAT"]);
                        htPara.Add("STT", drCurrent["STT"]);
                        htPara.Add("DUYET_KTCDAT_LOG", Common.GetCurrent_Log());

                        strSQLExec = "UPDATE R06PH_BTTB SET DUYET_KTCDAT = @DUYET_KTCDAT, DUYET_KTCDAT_LOG = @DUYET_KTCDAT_LOG  WHERE Stt = @STT";
                        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                        FillData();
                    }
                }
                if (strColumnName == "DUYET_GIAMDOC")
                {
                    bDuyet = Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access);

                    if (drCurrent["GD_Duyet"].ToString() != Element.sysUser_Id) //&& strDuyet_GD_Log.Substring(14) != Element.sysUser_Id
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chứng từ được trình '" + drCurrent["GD_Duyet"] + "'" : "Do not register transaction type";
                        Common.MsgCancel(strMsg);
                        return;
                    }

                    frmDuyetQLMMTB frm = new frmDuyetQLMMTB();
                    frm.Load(drCurrent, Is_Duyet, strColumnName);

                    if (frm.Is_Accept)
                    {
                        string strSQLExec = string.Empty;
                        Hashtable htPara = new Hashtable();

                        drCurrent["DUYET_GIAMDOC"] = frm.chkDuyet.Checked;

                        htPara.Add("DUYET_GIAMDOC", (bool)drCurrent["DUYET_GIAMDOC"]);
                        htPara.Add("STT", drCurrent["STT"]);
                        htPara.Add("DUYET_GD_LOG", Common.GetCurrent_Log());

                        strSQLExec = "UPDATE R06PH_BTTB SET DUYET_GIAMDOC = @DUYET_GIAMDOC, DUYET_GD_LOG = @DUYET_GD_LOG WHERE Stt = @STT";
                        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                        FillData();
                    }
                }
            }
            
        }
        void KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    this.FillData();
                    break;
            }
        }
		#endregion

	}
}
