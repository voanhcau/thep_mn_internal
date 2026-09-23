using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.HRM
{
	public partial class frmXeKhach_Edit : frmEdit
	{
		#region Phuong thuc
        string strStt = string.Empty;
        bool bUpdateDMSoXe = false;
        bool bInherit = false;
        bool bCPTL = false;
        public frmXeKhach_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
            txtSo_Xe.Validating += new CancelEventHandler(txtSo_Xe_Validating);
            txtSo_DT.Validating += new CancelEventHandler(txtSo_DT_Validating);
            //txtID_CMND.Validating += TxtID_CMND_Validating;

            numTai_Trong_Xe.Validated += new EventHandler(numTai_Trong_Xe_Validated);
            numTy_Le_Tai.Validated += new EventHandler(numTy_Le_Tai_Validated);
            btInherit.Click += new EventHandler(btInherit_Click);
            btVTPTRa.Click += new EventHandler(btVTPTRa_Click);
		}

       

        public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strStt)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strStt = strStt;
			
			BindingLanguage();
			
            if (enuNew_Edit == enuEdit.New)
            {
                dteGio_Vao.Text = Voucher.GetDateServer().ToString("HH:mm:ss");
                dteGio_Ra.Enabled = false;
                chkIs_Can.Checked = false;
                btVTPTRa.Visible = false;
            }
            else if (enuNew_Edit == enuEdit.Edit)
            {
                DateTime dtGio_Vao =  Convert.ToDateTime(Voucher.GetDateServer()); DateTime dtGio_Ra =  Convert.ToDateTime(Voucher.GetDateServer());

                Common.ScaterMemvar(this, ref drEdit);
              
                if (drEdit["Gio_Vao"] == DBNull.Value || Convert.ToDateTime(drEdit["Gio_Vao"]).ToString("HH:mm:ss") == "00:00:00")
                {
                    dteGio_Ra.Enabled = false;
                    dtGio_Ra = drEdit["Gio_Ra"] != DBNull.Value ? Convert.ToDateTime(drEdit["Gio_Ra"]) : Convert.ToDateTime(Voucher.GetDateServer());
                }
                else
                {
                    dtGio_Vao = drEdit["Gio_Vao"] != DBNull.Value ? Convert.ToDateTime(drEdit["Gio_Vao"]) : Convert.ToDateTime(Voucher.GetDateServer());
                    dteGio_Vao.Enabled = false;
                }
                //DateTime dtGio_Vao = drEdit["Gio_Vao"] != DBNull.Value ? Convert.ToDateTime(drEdit["Gio_Vao"]) : Convert.ToDateTime(Voucher.GetDateServer());
                //DateTime dtGio_Ra = drEdit["Gio_Ra"] != DBNull.Value ? Convert.ToDateTime(drEdit["Gio_Ra"]) : Convert.ToDateTime(Voucher.GetDateServer());


                dteGio_Ra.Text = dtGio_Ra.ToString("HH:mm:ss");
                dteGio_Vao.Text = dtGio_Vao.ToString("HH:mm:ss");// ("HH:mm:ss");

               

               
                // cập nhật khối lượng cân
                if (SQLExec.ExecuteReturnDt("SELECT * FROM R80PH_SCALE where Stt_Org = 'LC' + REPLACE(STR('" + drEdit["Ident00"].ToString() + "',10),' ', '0')").Rows.Count > 0)
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("IDENT00", drEdit["Ident00"]);
                    DataTable dt= SQLExec.ExecuteReturnDt("sp_GetCanHangList",ht, CommandType.StoredProcedure);
                    numSo_Luong.Value = Convert.ToDouble(dt.Rows[0]["So_Luong"]);
                    txtGiay_To_Di_Kem.Text = dt.Rows[0]["So_Ct"].ToString();

                    if (Common.Inlist(txtMa_Vt_Sp.Text, "PL"))
                    {
                        txtTen_Lx_Khach.Enabled = false;
                        txtID_CMND.Enabled = false;
                    }

                }
                else if (Common.Inlist(txtMa_Vt_Sp.Text, "CP,BD00000000"))
                {
                    txtTen_Lx_Khach.Enabled = false;
                    txtID_CMND.Enabled = false;
                }

            }
            LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Dt.strLookupKeyFilter = "Ma_Nh_Dt LIKE '100' OR Ma_Nh_Dt LIKE '110' OR Ma_Nh_Dt LIKE '300' OR Ma_Nh_Dt LIKE 'NB'";

            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.strLookupKeyFilter = "Ma_Nh_Dt LIKE 'NV' AND Ngay_End = '19000101'";

            txtSo_Xe.bUseAutoDropDown = true;

            txtMa_Vt_Sp.bUseAutoDropDown = true;
            txtMa_Vt_Sp.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%'";

            //txtID_CMND.bUseAutoDropDown = true;

            //txtMa_Dt
            if (txtMa_Dt.Text.Trim() != string.Empty)
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			else
				lbtTen_Dt.Text = string.Empty;

            //txtMa_Vt_Sp
            if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
                lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
            else
                lbtTen_Vt.Text = string.Empty;

           
		}
        void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
        {
            if (bCPTL)
                return;

            string strValue = txtMa_Vt_Sp.Text.Trim();
            bool bRequire = false;
            string strFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Sp.Text = string.Empty;
                lbtTen_Vt.Text = string.Empty;

            }
            else
            {
                txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
                lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();

                if (Common.Inlist(txtMa_Vt_Sp.Text, "CP,BD00000000,PL"))
                {
                    txtTen_Lx_Khach.Enabled = false;
                    txtID_CMND.Enabled = false;
                }

            }
        }
        private void TxtID_CMND_Validating(object sender, CancelEventArgs e)
        {
            if (!Common.Inlist(txtMa_Vt_Sp.Text, "CP,BD00000000"))
            {
                string strValue = txtID_CMND.Text.Trim();
                bool bRequire = false;
                string strFilter = "";

                DataRow drLookup = Lookup.ShowLookup("ID_CMND", strValue, bRequire, strFilter);

                if (bRequire && drLookup == null)
                    e.Cancel = true;

                if (drLookup == null)
                {
                    txtID_CMND.Text = string.Empty;
                    txtTen_Lx_Khach.Text = string.Empty;
                    txtSo_Phone.Text = string.Empty;
                }
                else
                {
                    txtID_CMND.Text = drLookup["ID_CMND"].ToString();
                    txtTen_Lx_Khach.Text = drLookup["Ten_Lx_Khach"].ToString();
                    txtSo_Phone.Text = drLookup["So_Phone"].ToString();
                }
            }
        }
        void txtSo_DT_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_DT.Text.Trim();
            bool bRequire = false;
            string strFilter = string.Empty;

            if (strValue == "/" || strValue == "\\")
                strFilter = "Ma_Dt = '" + txtMa_Dt.Text + "' AND Ma_Ct LIKE 'DT%' AND Ma_Ct <> 'DTCP' AND Ngay_Ct > DATEADD(DAY,-900,Ngay_Ct) AND Duyet_GiamDoc = 1 AND Duyet_Huy = 0";
            else
                strFilter = "Ma_Dt = '" + txtMa_Dt.Text + "' AND Ma_Ct LIKE 'DT%' AND Ma_Ct <> 'DTCP' AND Ngay_Ct > DATEADD(DAY,-900,Ngay_Ct) AND Duyet_GiamDoc = 1 AND Duyet_Huy = 0 AND So_Ct LIKE '" + txtSo_DT.Text + "%'";
          
            DataRow drLookup = Lookup.ShowLookup("Stt", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtSo_DT.Text = string.Empty;
                drEdit["Stt_DT"] = string.Empty;

            }
            else
            {
                txtSo_DT.Text = drLookup["So_Ct"].ToString();
                drEdit["Stt_DT"] = drLookup["Stt"].ToString();
                DateTime dtNgay = Voucher.GetDate_Server();
                if (enuNew_Edit == enuEdit.New && txtSo_DT.Text != string.Empty) //
                {
                    frmCtDT frm = new frmCtDT();
                    frm.Load(drEdit["Stt_DT"].ToString(), txtSo_DT.Text, false, dtNgay);
                }
            }
            
        }
        void txtSo_Xe_Validating(object sender, CancelEventArgs e)
        {
            if (bCPTL)
                return;

            if (enuNew_Edit == enuEdit.New)
            {
                string strValue = txtSo_Xe.Text.Trim();
                bool bRequire = false;
                string strFilter = "";
                DataTable dt_LXH;
                DataRow dr_LXH;

                if (Common.Inlist(txtMa_Vt_Sp.Text, "CP,BD00000000"))
                {
                    dt_LXH = SQLExec.ExecuteReturnDt("SELECT * FROM vw_So_Xe_LXH");
                    //dt_LXH = SQLExec.ExecuteReturnDt("SELECT * FROM vw_So_Xe_LXH WHERE So_Xe = '" + txtSo_Xe.Text + "' ");
                    if (dt_LXH.Rows.Count == 0)
                    { Common.MsgOk("Chưa có xe đăng ký vào nhận hàng chính phẩm!!!"); txtSo_Xe.Text = ""; }

                    else if ((dt_LXH.Rows.Count > 0))
                    {
                        if (txtSo_Xe.Text != "" && txtSo_Xe.Text != @"\")
                            strFilter = " So_Xe LIKE '" + txtSo_Xe.Text + "%'";

                        DataRow drLookup = Lookup.ShowLookup("So_Xe_LXH", strValue, bRequire, strFilter);

                        if (bRequire && drLookup == null)
                            e.Cancel = true;

                        if (drLookup == null)
                        {
                            txtSo_Xe.Text = string.Empty;

                        }
                        else
                        {
                            txtSo_Xe.Text = drLookup["So_Xe"].ToString();
                            txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                            txtTen_Lx_Khach.Text = drLookup["Ten_Dt_VC"].ToString();
                            txtID_CMND.Text = drLookup["ID_Dt_Vc"].ToString();
                            txtID_BL.Text = drLookup["ID_BL"].ToString();
                            drEdit["Stt_Org"] = drLookup["Stt"].ToString();

                            DataRow drSo_Xe = DataTool.SQLGetDataRowByID("R81DMSOXE", "So_Xe", txtSo_Xe.Text);
                            if (drSo_Xe != null)
                            {
                                txtSo_Phone.Text = drSo_Xe["So_Phone"].ToString();
                                txtNoi_Den.Text = drSo_Xe["Noi_Den"].ToString();
                                numTai_Trong_Xe.Value = Convert.ToDouble(drSo_Xe["Tai_Trong_Xe"]);
                                numTy_Le_Tai.Value = Convert.ToDouble(drSo_Xe["Ty_Le_Tai"]);
                                numTai_Trong.Value = Convert.ToDouble(drSo_Xe["Tai_Trong"]);
                            }
                            LoadDicName();
                        }
                    }
                    else
                    {
                        dr_LXH = dt_LXH.Rows[0];

                        txtTen_Lx_Khach.Text = dr_LXH["Ten_Dt_VC"].ToString();
                        txtID_CMND.Text = dr_LXH["ID_Dt_Vc"].ToString();
                        txtID_BL.Text = dr_LXH["ID_BL"].ToString();
                        txtMa_Dt.Text = dr_LXH["Ma_Dt"].ToString();
                        drEdit["Stt_Org"] = dr_LXH["Stt"].ToString();
                    }


                }
                else
                {
                    if (!DataTool.SQLCheckExist("R81DMSOXE", "So_Xe", txtSo_Xe.Text.Trim()) && (txtSo_Xe.Text != "/"))
                        bUpdateDMSoXe = true;
                    else
                    {


                        DataRow drLookup = Lookup.ShowLookup("So_Xe", strValue, bRequire, strFilter);

                        if (bRequire && drLookup == null)
                            e.Cancel = true;

                        if (drLookup == null)
                        {
                            txtSo_Xe.Text = string.Empty;

                        }
                        else
                        {
                            if (!bInherit)
                            {
                                if (!Common.Inlist(txtMa_Vt_Sp.Text, "CP,BD00000000"))
                                {
                                    txtSo_Xe.Text = drLookup["So_Xe"].ToString();
                                    txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                                    //txtMa_Vt_Sp.Text = drLookup["Ma_Vt_Sp"].ToString();
                                }

                            }

                            if (Common.Inlist(txtMa_Vt_Sp.Text, "CP,BD00000000") && !bUpdateDMSoXe)
                            {

                            }
                            else
                            {
                                if(txtTen_Lx_Khach.Text == "" || txtID_CMND.Text == "")
                                { 
                                    txtTen_Lx_Khach.Text = drLookup["Ten_Dt_Vc"].ToString();
                                    txtID_BL.Text = drLookup["ID_BL"].ToString();
                                    txtID_CMND.Text = drLookup["ID_CMND"].ToString();
                                    txtSo_Phone.Text = drLookup["So_Phone"].ToString();
                                }
                            }
                            

                            txtNoi_Den.Text = drLookup["Noi_Den"].ToString();
                            numTai_Trong_Xe.Value = Convert.ToDouble(drLookup["Tai_Trong_Xe"]);
                            numTy_Le_Tai.Value = Convert.ToDouble(drLookup["Ty_Le_Tai"]);
                            numTai_Trong.Value = Convert.ToDouble(drLookup["Tai_Trong"]);

                            LoadDicName();
                        }
                    }
                }
            }
        }

        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            //if (!Common.Inlist(txtMa_Vt_Sp.Text, "CP,BD00000000"))
            //{
            //    string strValue = txtMa_Dt_CbNv.Text.Trim();
            //    bool bRequire = false;
            //    string strFilter = "Ma_Nh_Dt LIKE 'NV' AND Ngay_End = '19000101'";

            //    DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, strFilter);

            //    if (bRequire && drLookup == null)
            //        e.Cancel = true;

            //    if (drLookup == null)
            //    {
            //        txtMa_Dt_CbNv.Text = string.Empty;
            //        txtTen_Lx_Khach.Text = string.Empty;

            //    }
            //    else
            //    {
            //        txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
            //        txtTen_Lx_Khach.Text = drLookup["Ten_Dt"].ToString();


            //    }
            //}
        }
        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;
            string strFilter = "";// "Ma_Nh_Dt LIKE '100'  OR Ma_Nh_Dt LIKE '300' OR Ma_Nh_Dt LIKE '300' OR Ma_Nh_Dt LIKE 'NB' OR Ma_Nh_Dt LIKE 'NV'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lbtTen_Dt.Text = string.Empty;
                
            }
            else
            {
                txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
              
                
            }
        }
      
		public bool FormCheckValid()
		{
			bool bvalid = true;
            //if (txtMa_Dt.Text.Trim() == string.Empty)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Ma_Dt_CbNv") + " " +
            //                  Languages.GetLanguage("Not_Null"));
            //    return false;
            //}
            //if (txtMa_Vt_Sp.Text.Trim() == string.Empty)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Ma_Vt_Sp") + " " +
            //                  Languages.GetLanguage("Not_Null"));
            //    return false;
            //}
            if (txtTen_Lx_Khach.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ten_LX_Khach") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (!Common.Inlist(txtMa_Vt_Sp.Text, "CP,BD00000000") && txtSo_Xe.Text != "")
            {
                if ((txtTen_Lx_Khach.Text == "" || txtID_BL.Text == "" || txtID_CMND.Text == "" || txtSo_Phone.Text == ""))
                {
                    Common.MsgCancel("Thông tin tài xế chưa hợp lệ, yêu cầu nhập đầy đủ thông tin tên tài xế, CCCD, BL, Số điện thoại!!! ");
                    return false;
                }
                else  //kiểm tra chiều dài
                        if (txtID_BL.Text.Length != 12)
                {
                    Common.MsgCancel("Thông tin bằng lái phải 12 ký tự mới cho phép lưu ");
                    return false;
                }
                else  //kiểm tra chiều dài
                        if (txtID_CMND.Text.Length != 12)
                {
                    Common.MsgCancel("Thông tin CCCD phải 12 ký tự mới cho phép lưu ");
                    return false;
                }
                else  //kiểm tra chiều dài
                        if (txtSo_Phone.Text.Length != 10)
                {
                    Common.MsgCancel("Thông tin số phone phải 10 ký tự mới cho phép lưu ");
                    return false;
                }
            }
            if (dteGio_Ra.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Gio_Ra") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (enuNew_Edit == enuEdit.Edit)
            {
                if (dteGio_Vao.Text.Trim() == string.Empty)
                {
                    Common.MsgOk(Languages.GetLanguage("Gio_Vao") + " " +
                                  Languages.GetLanguage("Not_Null"));
                    return false;
                }
               
            }
			return bvalid;
		}

		public bool Save()
		{
           
            //if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            //    drEdit["Gio_Vao"] = dteGio_Vao.Text;
            //else
            //    drEdit["Gio_Ra"] = dteGio_Ra.Text;

            if (dteGio_Vao.Text != "  :  :")
                drEdit["Gio_Vao"] = dteGio_Vao.Text;

            if (dteGio_Ra.Text != "  :  :")
                drEdit["Gio_Ra"] = dteGio_Ra.Text;

            Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;



            if (enuNew_Edit == enuEdit.New)
            {
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["Loai_RVC"] = "3";
                drEdit["Stt"] = strStt;
            }
            else if (enuNew_Edit == enuEdit.Edit)
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();
            
            string strUpdateDmSoXe = string.Empty;
            
            double dbDMTai_Trong_Xe = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT Tai_Trong_Xe FROM R81DMSOXE WHERE So_Xe = '"+ txtSo_Xe.Text +"'"));
            string strID = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT ID_CMND FROM R81DMSOXE WHERE So_Xe = '" + txtSo_Xe.Text + "'"));
                //) == DBNull.Value ? "" : SQLExec.ExecuteReturnValue("SELECT ID_CMND FROM R81DMSOXE WHERE So_Xe = '" + txtSo_Xe.Text + "'").ToString();
           

            if (numTai_Trong.Value != dbDMTai_Trong_Xe || txtID_CMND.Text != strID)
                bUpdateDMSoXe = true;
            //cập nhật DMSOXE lấy tãi trọng của xe đã dc tính qua trạm cân
            if (bUpdateDMSoXe)
            {
                if (!DataTool.SQLCheckExist("R81DMSOXE", new string[] { "So_Xe" }, new object[] { txtSo_Xe.Text }))
                    strUpdateDmSoXe = "INSERT INTO R81DMSOXE(So_Xe, Ten_Dt_Vc, ID_BL, ID_CMND, Ma_Dt, Ma_Vt_Sp, Tai_Trong_Xe, Ty_Le_Tai, Tai_Trong, So_Phone, Noi_Den, Create_Log) " +
                                        "VALUES (N'" + txtSo_Xe.Text + "', N'" + txtTen_Lx_Khach.Text + "', '" + txtID_BL.Text + "', '" + txtID_CMND.Text + "', '" + txtMa_Dt.Text + "','" + txtMa_Vt_Sp.Text + "', " + numTai_Trong_Xe.Value + ", " + numTy_Le_Tai.Value + ", " + numTai_Trong.Value + ",'"+ txtSo_Phone.Text +"','"+ txtNoi_Den.Text +"', '" + Common.GetCurrent_Log() + "')";
                else
                    strUpdateDmSoXe = "UPDATE R81DMSOXE SET Ten_Dt_Vc = N'" + txtTen_Lx_Khach.Text + "', ID_BL = '" + txtID_BL.Text + "', ID_CMND = '" + txtID_CMND.Text + "', Ma_Dt = '" + txtMa_Dt.Text + "', " +
                            " Ma_Vt_Sp = '" + txtMa_Vt_Sp.Text + "', Tai_Trong_Xe = " + numTai_Trong_Xe.Value + ", Ty_Le_Tai = " + numTy_Le_Tai.Value + ", Tai_Trong = " + numTai_Trong.Value + ", LastModify_Log = '" + Common.GetCurrent_Log() + "', "+
                            " So_Phone = '"+ txtSo_Phone.Text +"', Noi_Den = N'"+ txtNoi_Den.Text +"'" +
                            " WHERE So_Xe = '" + txtSo_Xe.Text + "'";

                SQLExec.Execute(strUpdateDmSoXe);


            }
            // Cập nhật tải trọng ngược lại thông tin cân lấy tãi thực của xe
            if(chkIs_Can.Checked == true && drEdit["Stt_Org"].ToString() != string.Empty)
            {
                strUpdateDmSoXe = "UPDATE R09CANHANG SET Tai_Trong = " + numTai_Trong_Xe.Value + " WHERE So_Xe = '" + drEdit["So_Xe"].ToString() + "' AND Tai_Trong <> "+ numTai_Trong_Xe.Value +"";
                SQLExec.Execute(strUpdateDmSoXe);
            }
            //else if (drEdit["Stt_Org"].ToString() == string.Empty && DataTool.SQLCheckExist("R81DMSOXE","So_Xe",txtSo_Xe.Text))
            //{
            //    strUpdateDmSoXe = "UPDATE R81DMSOXE SET Tai_Trong = " + numTai_Trong.Value + " WHERE So_Xe = '" + drEdit["So_Xe"].ToString() + "' AND Tai_Trong <> " + numTai_Trong.Value + "";
            //    SQLExec.Execute(strUpdateDmSoXe);
            //}
			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R09CT_RVC", ref drEdit))
				return false;

            if (chkIs_Can.Checked == true)
            {
                //int iIdent00 = Convert.ToInt16(SQLExec.Execute("SELECT Ident00 FROM R09CT_RVC"));
                //SQLExec.Execute("UPDATE R09CT_RVC SET Stt_Can = 'LC' + REPLACE(STR( " + iIdent00 + ",10),' ','0') WHERE Ident00 = " + iIdent00 + "");
            }
			return true;
		}
        void btVTPTRa_Click(object sender, EventArgs e)
        {
            DateTime dtNgay = Voucher.GetDate_Server();
            frmCtDT frm = new frmCtDT();
            frm.Load(drEdit["Stt_DT"].ToString(), txtSo_DT.Text, true, dtNgay);
        }
        void btInherit_Click(object sender, EventArgs e)
        {
            frmInheritThongTinCan frmInherit = new frmInheritThongTinCan();
            frmInherit.Load(txtMa_Vt_Sp.Text);
            if (frmInherit.Is_Accept)
            {
                if (frmInherit.dtInheritVoucher.Select("Chon = true").Length == 0)
                    return;

                txtMa_Dt.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Dt"].ToString();
                txtMa_Vt_Sp.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Vt_Sp"].ToString();
                txtSo_Xe.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["So_Xe"].ToString();
                txtSo_Xa_Lan_Tau.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["So_Xa_Lan_Tau"].ToString();
                txtTen_Lx_Khach.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ten_Lx_Khach"].ToString();
                txtID_BL.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["ID_BL"].ToString();
                txtID_CMND.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["ID_CMND"].ToString();
                txtSo_Phone.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["So_Phone"].ToString();

                numTai_Trong_Xe.Value = Convert.ToDouble(frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Tai_Trong"]);
               
                if (frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Vt_Sp"].ToString() == "CP")
                    bCPTL = true;

                Calc_Tai_Trong();

                chkIs_Can.Checked = true;
                drEdit["Stt_Org"] = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Stt"].ToString();
                bInherit = true;
                //Hiển thị số phiếu đã được kế thừa
                   
                string strInheritText = frmInherit.dtInheritVoucher.Rows[0]["So_Ct"].ToString();

                if (!txtInherit.Text.Contains(strInheritText))
                    txtInherit.Text += strInheritText + ",";


                //xử lý loai chung tu
                //nếu là xuất
                if (frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Loai_Ct"].ToString() == "X")
                {
                    dteGio_Ra.Text = Voucher.GetDateServer().ToString("HH:mm:ss");// ("HH:mm:ss");
                    dteGio_Ra.Enabled = true;
                    dteGio_Vao.Clear();
                }
                else //nếu là nhập
                {
                    dteGio_Vao.Text = Voucher.GetDateServer().ToString("HH:mm:ss");// ("HH:mm:ss");
                    dteGio_Vao.Enabled = true;
                    dteGio_Ra.Clear();
                }
                LoadDicName();
                txtSo_Xe.Focus();
            }
        }
        void numTai_Trong_Xe_Validated(object sender, EventArgs e)
        {
            Calc_Tai_Trong();
        }
        void Calc_Tai_Trong()
        {
            numTai_Trong.Value = Math.Round(numTai_Trong_Xe.Value + (numTai_Trong_Xe.Value * (numTy_Le_Tai.Value/100)), MidpointRounding.AwayFromZero);
        }
        void numTy_Le_Tai_Validated(object sender, EventArgs e)
        {
            Calc_Tai_Trong();
        }

		#endregion

		#region Su kien
		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
		#endregion

        //private void numTai_Trong_TextChanged(object sender, EventArgs e)
        //{

        //}
	}
}
