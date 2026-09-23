using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Public;
using RosySystem.Common;
using RosySystem.Customize;
using RosyList;
using System.Data.SqlClient;

namespace RosyModule.Receivable
{
    public partial class frmCtSO_Edit : frmVoucher_Edit
    {
        private string strModule = "12";//"04";
        private frmCheckInventory frmCheckInventory;
        DataTable dtCheckInventory;
        private bool bMa_Vt_Changed = false;
        private bool bMa_Thue_Changed = false;
        DataTable dtDuCuoi;
        string strHt_Gn_QD;
        //string strMa_Kho ="";

        #region Contructor

        public frmCtSO_Edit()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

            this.btImportExcel.Click += new EventHandler(btnImportExcel_Click);

            txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
            txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            btInherit.Click += new EventHandler(btInherit_Click);
            txtMa_Xe.Validating += new CancelEventHandler(txtMa_Xe_Validating);
            txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
            txtSo_QD.Validating += new CancelEventHandler(txtSo_QD_Validating);
            txtMa_CTrinh.Validating += new CancelEventHandler(txtMa_CTrinh_Validating);
            txtMa_PLCTrinh.Validating += new CancelEventHandler(txtMa_PLCTrinh_Validating);
            txtHT_TT.Validating += new CancelEventHandler(txtLoai_Gia_Validating);
            txtPt_Vc.Validating += new CancelEventHandler(txtPt_Vc_Validating);
            txtMa_KhoN.Validating += new CancelEventHandler(txtMa_KhoN_Validating);
            txtMa_Tte.Leave += new EventHandler(txtMa_Tte_Leave);
            numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);
            txtHt_Gn.Validating += new CancelEventHandler(txtHt_Gn_Validating);
            txtPort_Giao.Validating += new CancelEventHandler(txtPort_Giao_Validating);
            txtMa_Thue.Validating += new CancelEventHandler(txtMa_Thue_Validating);
            txtSo_LXH_Tt.Validating += new CancelEventHandler(txtSo_LXH_Tt_Validating);
            txtMa_Dt_Vc.Validating += new CancelEventHandler(txtMa_Dt_Vc_Validating);
            txtID_Dt_Vc.Validating += new CancelEventHandler(txtID_Dt_Vc_Validating);
            
            numTTien.Validated += new EventHandler(numTTien_Validated);
            numTTien_Nt.Validated += new EventHandler(numTTien_Nt_Validated);
            numTTien3.Validated += new EventHandler(numTTien3_Validated);
            numTTien_Nt3.Validated += new EventHandler(numTTien_Nt3_Validated);

            dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
            dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
            dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
            dgvEditCt1.CellValueChanged += new DataGridViewCellEventHandler(dgvEditCt1_CellValueChanged);
            dgvEditCt1.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);

            dgvEditCt1.CellContentClick += new DataGridViewCellEventHandler(dgvEditCt1_CellContentClick);
            dgvEditCt1.CellContentDoubleClick += new DataGridViewCellEventHandler(dgvEditCt1_CellContentClick);
            dgvEditCt2.CellContentClick += new DataGridViewCellEventHandler(dgvEditCt1_CellContentClick);
            dgvEditCt2.CellContentDoubleClick += new DataGridViewCellEventHandler(dgvEditCt1_CellContentClick);
            btDuyet_Dh.Click += new EventHandler(btDuyet_Dh_Click);
        }

       

       

       

        
        public override void Load(enuEdit enuNew_Edit, DataRow drEdit, DataSet dsVoucher)
        {
            this.drEdit = drEdit;
            this.dsVoucher = dsVoucher;

            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            this.strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();
            this.drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", this.strMa_Ct);
            this.Object_ID = strMa_Ct;


            if (enuNew_Edit == enuEdit.New)
            {
                this.strStt = Common.GetNewStt(strModule, true);
                
            
            }
            else
                this.strStt = drEdit["Stt"].ToString();


            if (Common.Inlist(strMa_Ct, "SO,LXH,SOCP"))
            {
                lbtIs_KCS.Visible = false;
                lbtIs_TPH.Visible = false;
               // chkIs_KCS.Visible = false;
                chkIs_TPH.Visible = false;
                numSo_Luong_TPH.Visible = false;
                numSo_Luong0.Visible = false;
                //numSo_Luong_CNXX.Visible = false;


            }
            if (strMa_Ct != "LXH")
            {
                lblMa_Xe.Visible = false;
                txtMa_Xe.Visible = false;
            }
            this.Build();
            this.FillData();
            this.Init_Ct();

            Common.ScaterMemvar(this, ref drEditPh);
        
            //if (dtEditCt.Rows[0]["Ma_Kho"].ToString() == "")
            //    dtEditCt.Rows[0]["Ma_Kho"] = txtMa_Kho.Text;
            //if (drEdit["Ma_Ct"].ToString() == "SO") //DBNull.Value
            //    txtTG_Nhan_DH.Text  = drEditPh["TG_Nhan_DH"] == DBNull.Value ? "00:00" : Convert.ToDateTime(drEdit["TG_Nhan_DH"].ToString()).ToShortTimeString();

            this.Ma_Tte_Valid();
            this.BindingLanguage();
            this.LoadDicName();

            if (!this.Visible)
                this.ShowDialog();
            else
            {
                this.ActiveControl = txtMa_Nvu;
                this.dgvEditCt1.ClearSelection();
            }
        }

        #endregion

        #region Phuong thuc

        private void Build()
        {
            dgvEditCt1.bSortMode = false;
            dgvEditCt1.strZone = (string)drDmCt["Zone_EditCt1"];
            dgvEditCt1.BuildGridView();

            dgvEditCt2.bSortMode = false;
            dgvEditCt2.strZone = (string)drDmCt["Zone_EditCt2"];
            dgvEditCt2.BuildGridView();

            if (dgvEditCt1.Columns.Contains("MA_VT"))
            {
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = "Ma_Nh_Vt = 'THEPCANDAI'";
            }
            if (dgvEditCt1.Columns.Contains("MA_KHO"))
            {
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Kho"]).bUseAutoDropDown = true;
            }
            txtMa_Xe.bUseAutoDropDown = true;
            txtMa_Xe.strLookupKeyFilter = "Ma_Bp = 'PKD'";
           

        }

        private void FillData()
        {
            Hashtable htPara = new Hashtable();
            htPara.Add("TABLE_PH", (string)drDmCt["Table_Ph"]);
            htPara.Add("TABLE_CT", (string)drDmCt["Table_Ct"]);
            htPara.Add("STT", ((string)drEdit["Stt"]).Trim());
            htPara.Add("USER_LOGIN", Element.sysUser_Id);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter", htPara, CommandType.StoredProcedure);

            dtEditPh = dsVoucher.Tables[0];
            dtEditCt = dsVoucher.Tables[1];

            if (enuNew_Edit == enuEdit.New)
                dtEditCt.Clear();

            DataColumn dc_Del = new DataColumn("Deleted", typeof(bool));
            dc_Del.DefaultValue = false;
            dtEditCt.Columns.Add(dc_Del);

            bdsEditCt.DataSource = dtEditCt;

            dgvEditCt1.DataSource = bdsEditCt;
            dgvEditCt1.ClearSelection();

            dgvEditCt2.DataSource = bdsEditCt;
            dgvEditCt2.ClearSelection();

            if (!Voucher.Access_Price_Xuat(dtEditCt,strMa_Ct,dgvEditCt1))
            {
                numTTien0.Visible = false;
                numTTien_Nt0.Visible = false;

                numTTien3.Visible = false;
                numTTien_Nt3.Visible = false;

                numTTien.Visible = false;
                numTTien_Nt.Visible = false;
            }
        }


        private void InheritVoucher() //Kế thừa chứng từ từ phiếu khác
        {
            Voucher.Update_Header(this);
            Voucher.Update_Detail(this);
            if (Common.Inlist(strMa_Ct, "LXH"))
            {
                frmInheritVoucher frm = new frmInheritVoucher();
                frm.Load(this);

                if (frm.Is_Accept)
                {
                    Voucher.InheritVoucher_SetData(frm, this);

                    Voucher.Update_Detail(this);
                    Voucher.Update_TTien(this);
                    LockControl();
                }
            }
            else
            {
                frmInheritVoucher frm = new frmInheritVoucher();
                frm.Load(this);

                if (frm.Is_Accept)
                {
                    Voucher.InheritVoucher_SetData(frm, this);

                    Voucher.Update_Detail(this);
                    Voucher.Update_TTien(this);
                    Voucher.Update_DmNvu(this);
                    LockControl();
                }
            }
        }
        private void Init_Ct()
        {
            txtMa_Tte.InputMask = (string)RosySystem.Library.Parameters.GetParaValue("MA_TTE_LIST");

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);

                dtEditPh.Rows.Add(drNew);
            }

            if (dtEditCt.Rows.Count == 0)
            {
                DataRow drNew = dtEditCt.NewRow();
                Common.SetDefaultDataRow(ref drNew);

                dtEditCt.Rows.Add(drNew);
            }

            drEditPh = dtEditPh.Rows[0];
            drCurrent = dtEditCt.Rows[0];

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                //Xóa số QD và mã HD
                drCurrent["Ma_Hd"] = "";
                drCurrent["So_Qd"] = "";
                
                if (Common.Inlist(strMa_Ct, "SOCP"))
                    txtMa_KhoN.Text = "";
                
                if (Common.Inlist(strMa_Ct, "SO,SOCP"))
                    drCurrent["Is_CNXX"] = 0;
                
                if (this.enuNew_Edit == enuEdit.New)
                {
                    //Ngầm định 1 số thông tin từ chứng từ cũ
                    if (drEdit != null)
                        Common.CopyDataRow(drEdit, drCurrent, (string)drDmCt["Carry_Header"]);

                    drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;
                    drCurrent["Stt"] = strStt;
                    drCurrent["Ma_Ct"] = strMa_Ct;
                    drCurrent["Ngay_Ct"] = DateTime.Now;
                    drCurrent["Ma_Tte"] = Element.sysMa_Tte;
                    drCurrent["Ty_Gia"] = 1;
                    drCurrent["Stt0"] = 1;
                    drCurrent["Deleted"] = false;

                    //Clear Content in drEditPh
                    foreach (DataColumn dcEditPh in dtEditPh.Columns)
                        drEditPh[dcEditPh] = DBNull.Value;

                    drEditPh["Ma_DvCs"] = drCurrent["Ma_DvCs"];
                    drEditPh["Stt"] = drCurrent["Stt"];
                    drEditPh["Ma_Ct"] = drCurrent["Ma_Ct"];
                    drEditPh["Ngay_Ct"] = drCurrent["Ngay_Ct"];
                    drEditPh["So_Ct"] = drCurrent["So_Ct"];
                }
                else
                {
                    //CT và khai báo số Stt0 lại
                    int iStt0 = 1;

                    foreach (DataRow drEditCt in dtEditCt.Rows)
                    {

                        if (dtEditCt.Columns.Contains("Stt_Org")) //Bỏ các dữ liệu kế thừa
                        {
                            drEditCt["Stt_Org"] = "";
                            drEditCt["Gia"] = 0;
                            drEditCt["Gia_Nt"] = 0;
                            drEditCt["Gia_Nt9"] = 0;
                            drEditCt["Tien"] = 0;
                            drEditCt["Tien_Nt"] = 0;
                            drEditCt["Tien_Nt9"] = 0;
                            drEditCt["Ma_Vt"] = "";
                            drEditCt["Ten_Vt"] = "";
                            drEditCt["So_Xe"] = "";
                            drEditCt["So_Xa_Lan_Tau"] = "";
                            drEditCt["So_Luong"] = 0;
                            drEditCt["So_Luong_Bo"] = 0;
                            drEditCt["So_Luong_Cay_Le"] = 0;
                            drEditCt["So_Luong9"] = 0;
                            drEditCt["So_Luong_Cay"] = 0;
                            drEditCt["TSo_Luong_Cay"] = 0;
                        }
                        if (dtEditCt.Columns.Contains("Stt0")) //Bỏ các dữ liệu kế thừa
                        {
                            drEditCt["Stt0"] = iStt0;
                            iStt0++;
                        }
                        if (Convert.ToDouble(drEditCt["Stt0"]) != 1)
                        {
                            drEditCt.Delete();
                           
                        }
                        
                    }
                    
                    //PH
                    if (drEditPh.Table.Columns.Contains("Stt_Org"))
                    {
                        drEditPh["Stt_Org"] = "";
                    }
                    if (drEditPh.Table.Columns.Contains("Print_Count"))
                    {
                        drEditPh["Print_Count"] = 0;
                    }
                    if (Common.Inlist(strMa_Ct, "SO,SOCP"))
                    {
                        drEditPh["Duyet"] = 0;
                        drEditPh["Duyet_Log"] = "";
                        drEditPh["So_Ct_Lap"] = "";
                        drEditPh["Ngay_Ct_Lap"] = "1900/01/01";
                        drEditPh["Duyet_PKD"] = 0;
                        drEditPh["Ngay_Duyet_PKD"] = "1900/01/01";
                        drEditPh["Duyet_Log_PKD"] = "";
                        drEditPh["User_Duyet_PKD"] = "";
                        drEditPh["Ghi_Chu_PKD"] = "";
                        drEditPh["User_Huy"] = "";
                        drEditPh["Duyet_Huy"] = 0;
                        drEditPh["Ngay_Huy"] = "1900/01/01";
                        drEditPh["Ghi_Chu_Huy"] = "";
                        drCurrent["Ngay_Ct"] = DateTime.Now;
                        drEditPh["User_Print"] = "";
                        drEditPh["Is_Vt_Nhan"] = 0;
                        //drEditPh["Ngay_Ct"] = Element.sysNgay_Ct2;

                    }
                }


                //Tinh so chung tu
                if (Common.Inlist(strMa_Ct, "SO,SOCP"))
                    drEditPh["So_Ct"] = drCurrent["So_Ct"] = Voucher.Cong_So_Ct_SO(this);
            }
           
            Voucher.Update_Header(this);
            Voucher.Update_Stt(this, strModule);
            if (Common.InlistLike(strMa_Ct, "SO,LXH") && !Element.sysIs_Admin)
            {
                dteNgay_Ct.ReadOnly = true;
                txtSo_Ct.ReadOnly = true;
            }
            txtInherit.Text = Voucher.GetInheritVoucher(this);

            dgvEditCt1.Columns["Dvt"].ReadOnly = true;

            if (strMa_Ct == "SO")
            {
                chkDuyet_TP.Visible = true;
                if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                    chkDuyet_TP.Enabled = true;
            }
            //if (strMa_Ct == "LXH")
            //{
            //    lblSo_LXH_Tt.Visible = true;
            //    txtSo_LXH_Tt.Visible = true;
            //}
            // Ẩn nút duyệt DH chỉ để cho PKT duyệt
            if (enuNew_Edit == enuEdit.Edit)
            {
                bool bDuyet_SO_PKT = Common.CheckPermission("DUYET_SO_PKT", enuPermission_Type.Allow_Access);
                bool bDuyet_PKD = Common.CheckPermission("DUYET_PKD", enuPermission_Type.Allow_Access);
                DataRow drPh = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt);
                if (!(bool)drPh["Duyet_Pkd"] && bDuyet_PKD && enuNew_Edit == enuEdit.Edit)
                    btDuyet_Dh.Visible = true;
                else if ((bool)drPh["Duyet_Pkd"] && bDuyet_SO_PKT && enuNew_Edit == enuEdit.Edit)
                    btDuyet_Dh.Visible = true;
                else
                    btDuyet_Dh.Visible = false;
            }
            else 
                btDuyet_Dh.Visible = false;

            if (enuNew_Edit == enuEdit.Edit)
            {
                foreach (DataRow drEditCt in dtEditCt.Rows)
                {
                    if (dtEditCt.Columns.Contains("Stt_Org")) //Bỏ các dữ liệu kế thừa
                    {
                        if ((string)drEditCt["Stt_Org"] != "")
                        {
                            if (!Common.CheckPermission("IS_EDIT_SO", enuPermission_Type.Allow_Access))
                            {
                                LockControl();
                                break;
                            }
                        }
                    }
                }
            }

            ////Bằng bổ sung phần này để copy ko copy phần chi tiết
            //if (enuNew_Edit == enuEdit.Copy && strMa_Ct.StartsWith("SO"))
            //{
            //    DataRow drNew1 = dtEditCt.NewRow();
               
            //    Common.SetDefaultDataRow(ref drNew1);
            //    dtEditCt.Clear();
            //    dtEditCt.Rows.Add(drNew1);
                
                
            //}
            /////////////

            //BindingTTien
            numTTien0.DataBindings.Clear();
            numTTien3.DataBindings.Clear();
            numTTien.DataBindings.Clear();

            numTTien_Nt0.DataBindings.Clear();
            numTTien_Nt3.DataBindings.Clear();
            numTTien_Nt.DataBindings.Clear();
            numTSo_Luong.DataBindings.Clear();

            numTTien0.DataBindings.Add("Value", dtEditPh, "TTien0");
            numTTien3.DataBindings.Add("Value", dtEditPh, "TTien3");
            numTTien.DataBindings.Add("Value", dtEditPh, "TTien");

            numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien_Nt0");
            numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien_Nt3");
            numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");
            numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");
        }

        private void LoadDicName()
        {
            txtMa_Dt.bUseAutoDropDown = true;
            
            
            txtMa_Dt_Vc.bUseAutoDropDown = true;
            txtMa_Hd.bUseAutoDropDown = true;
            txtSo_QD.bUseAutoDropDown = true;
            txtMa_PLCTrinh.bUseAutoDropDown = true;
            txtMa_CTrinh.bUseAutoDropDown = true;


            //txtMa_Nvu
            if (txtMa_Nvu.Text.Trim() != string.Empty)
                lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim());
            else
                lbtTen_Nvu.Text = string.Empty;

            //txtMa_Dt
            if (txtMa_Dt.Text.Trim() != string.Empty)
            {
                txtMa_Hd.strLookupKeyFilter = " (Ma_Dt = '" + txtMa_Dt.Text + "')";
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            }
            else
                lbtTen_Dt.Text = string.Empty;

            //txtMa_Dt_Vc
            if (txtMa_Dt_Vc.Text.Trim() != string.Empty)
            {
                lbtTen_Dt_Vc.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_Vc.Text.Trim());
            }
            else
                lbtTen_Dt_Vc.Text = string.Empty;

            //txtMa_KhoN
            if (txtMa_KhoN.Text.Trim() != string.Empty)
            {
                lbtTen_KhoN.Text = DataTool.SQLGetNameByCode("R81DmKho", "Ma_Kho", "Ten_Kho", txtMa_KhoN.Text.Trim());
            }
            else
                lbtTen_KhoN.Text = string.Empty;
            //txtMa_Kho
            if (txtMa_Kho.Text.Trim() != string.Empty)
            {
                lbtTen_Kho.Text = DataTool.SQLGetNameByCode("R81DmKho", "Ma_Kho", "Ten_Kho", txtMa_Kho.Text.Trim());
            }
            else
                lbtTen_Kho.Text = string.Empty;
            //txtMa_Dt_CbNv
            if (txtMa_Xe.Text.Trim() != string.Empty)
            {
                lbtTen_Xe.Text = DataTool.SQLGetNameByCode("R81DmXe", "Ma_Xe", "Ten_Xe", txtMa_Xe.Text.Trim());
            }
            else
                lbtTen_Xe.Text = string.Empty;

            //txtMa_DDH
            if (txtMa_Hd.Text.Trim() != string.Empty)
            {
                lbtTen_Hd.Text = Voucher.GetTenHd(txtMa_Hd.Text);//DataTool.SQLGetNameByCode("R81DmHd", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
            }
            else
                lbtTen_Hd.Text = string.Empty;

            //txtMaCtrinh
            if (txtMa_CTrinh.Text.Trim() != string.Empty)
            {
                lbtTen_CTrinh.Text = DataTool.SQLGetNameByCode("R81DMCTRINH", "Ma_CTrinh", "Ten_CTrinh", txtMa_CTrinh.Text.Trim());
            }
            else
                lbtTen_CTrinh.Text = string.Empty;

            //txtMaCtrinh
            if (txtMa_PLCTrinh.Text.Trim() != string.Empty)
            {
                lbtTen_PLCTrinh.Text = DataTool.SQLGetNameByCode("R81DMPLCTRINH", "Ma_PLCTrinh", "Ten_PLCTrinh", txtMa_PLCTrinh.Text.Trim());
            }
            else
                lbtTen_PLCTrinh.Text = string.Empty;

            //txtHt_Gn
            if (txtHt_Gn.Text.Trim() != string.Empty)
            {
                lbtHt_Gn.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtHt_Gn.Text.Trim());
            }
            else
                lbtHt_Gn.Text = string.Empty;
            //txtHt_Gn
            if (txtPort_Giao.Text.Trim() != string.Empty)
            {
                lbtPort_Giao.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtPort_Giao.Text.Trim());
            }
            else
                lbtPort_Giao.Text = string.Empty;
         
           
            //Log
            string strCreate_Log = Common.Show_Log((string)drEditPh["Create_Log"]);
            string strLastModify_Log = Common.Show_Log((string)drEditPh["LastModify_Log"]);
            string strLog = string.Empty;
            strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
            strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";

            this.lblLog.Text = strLog;
        }

        private bool FormCheckValid()
        {
            string strMa_Vt_Check = "";
            if (DataTool.SQLCheckExist("R81DMDT", new string[] { "Ma_Dt", "Locked" }, new object[] { txtMa_Dt.Text, true }) && Common.Inlist(strMa_Ct,"SO,SOCP"))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Khách hàng đã bị khóa không bán cho khách hàng có mã "+ txtMa_Dt.Text +"" : "Data have been locked";
                Common.MsgCancel(strMsg);
                return false;
            }
            if (!Common.CheckDataLocked(Library.StrToDate(this.dteNgay_Ct.Text)))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Dữ liệu đã bị khóa" : "Data have been locked";
                Common.MsgCancel(strMsg);
                return false;
            }
            if (strMa_Ct == "LXH" && txtMa_Nvu.Text == "LXH02")
            {
                if ((txtMa_Kho.Text == "GK_04TP" && txtMa_KhoN.Text != "GK_052TMN"))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Nghiệp vụ chuyển hàng sang kho bẻ nhập sai thông tin. Yêu cầu kiểm tra lại trước khi lưu!!!" : "Data have been locked";
                    Common.MsgCancel(strMsg);
                    return false;
                }

            }
            if (txtHt_Gn.Text.Contains(","))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Yêu cầu kiểm tra hình thức giao nhận" : "Check Ht Gn";
                Common.MsgCancel(strMsg);
                return false;
            }

            if (txtMa_Nvu.Text == string.Empty)
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa khai báo mã nghiệp vụ" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }

            if (txtMa_KhoN.Text == "" && Common.InlistLike(txtHt_Gn.Text, "KG,DD,GK") && !Common.InlistLike(txtMa_Kho.Text,"GK"))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Yêu cầu nhập mã kho nhập khi chọn hình thức giao nhận là ký gửi, điều động hay gửi kho" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            else if (txtMa_KhoN.Text != "" && !Common.InlistLike(txtHt_Gn.Text, "KG,DD,GK") && strMa_Ct != "LXH")
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Yêu cầu không nhập mã kho nhập khi chọn hình thức giao nhận khác ký gửi, điều động hay gửi kho" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            if (txtMa_Tte.Text == "VND" && strMa_Ct != "LXH" && !Common.InlistLike(txtHt_Gn.Text, "DD,NB") && txtMa_Thue.Text == "")
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Yêu cầu nhập mã thuế" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            if (txtMa_Tte.Text != "VND" && strMa_Ct != "LXH" && txtMa_Thue.Text != "")
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Phiếu không cần nhập mã thuế" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            if (txtMa_Tte.Text != "VND" &&  txtPort_Giao.Text == "")
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Phiếu cần nhập phương thức giao hàng Xuất khẩu" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            if (txtSo_QD.Text != "")
            {
                strHt_Gn_QD = SQLExec.ExecuteReturnValue("SELECT Ht_Gn FROM R81DMQD WHERE So_Qd = '" + txtSo_QD.Text + "'").ToString();
                if (strHt_Gn_QD != "" && !strHt_Gn_QD.Contains(txtHt_Gn.Text))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hình thức giao nhận " + txtHt_Gn.Text + " không theo số quyết định '" + txtSo_QD.Text + "'. Bạn muốn làm tiếp không ?" : "Do not register transaction type";
                    if (!Common.MsgYes_No(strMsg, "Y"))
                        return false;
                }
                if (strMa_Ct != "LXH")
                {
                    Hashtable htQD = new Hashtable();
                    htQD.Add("SO_QD", txtSo_QD.Text);
                    htQD.Add("STT", strStt);
                    htQD.Add("SO_LUONG", Common.SumDCValue(dtEditCt, "SO_LUONG", ""));

                    double dbSL = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT [dbo].[fn_CheckSLMaxQD](@So_Qd, @Stt, @So_Luong)", htQD, CommandType.Text));
                    if (dbSL < 0)
                    {
                        Common.MsgOk("Số lượng bán hàng của QD " + txtSo_QD.Text + " cộng thêm phần chệnh lệch lớn hơn tổng SO tổng là " + Math.Abs(dbSL) + " không được lập lệnh ");
                        return false;
                    }
                }
            }
            if (txtMa_KhoN.Text != "" && txtHt_Gn.Text == "KG")
            {
                DataRow drDmKho = DataTool.SQLGetDataRowByID("R81DMKHO", "Ma_Kho", txtMa_KhoN.Text);
                if (drDmKho["Ma_Dt"].ToString() != txtMa_Dt.Text)
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Yêu cầu mã kho nhập khác đối tượng ký gửi" : "Do not register transaction type";
                    Common.MsgCancel(strMsg);
                    return false;
                }
                if (strMa_Ct == "SO" && txtMa_KhoN.Text.ToString().Contains(".08"))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Yêu cầu mã kho nhập không có mã kho .08" : "Do not register transaction type";
                    Common.MsgCancel(strMsg);
                    return false;
                }
                else if (strMa_Ct == "SOCP" && Common.InlistLike(txtMa_Kho.Text,"08,551") && !txtMa_KhoN.Text.ToString().Contains(".08"))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Yêu cầu mã kho nhập có mã kho .08" : "Do not register transaction type";
                    Common.MsgCancel(strMsg);
                    return false;
                }
                else if (strMa_Ct == "SOCP" && Common.InlistLike(txtMa_Kho.Text, "051,052,058") && txtMa_KhoN.Text.ToString().Contains(".08"))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Yêu cầu mã kho nhập có mã kho không kết thúc là .08" : "Do not register transaction type";
                    Common.MsgCancel(strMsg);
                    return false;
                }
            }
            if (txtMa_Nvu.Text == "SO01" && txtHt_Gn.Text == "GK")
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Mã nghiệp vụ và hình thức giao nhận không trùng khớp" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            if (txtHt_Gn.Text == "GK" && txtMa_KhoN.Text != "GK_" + txtMa_Kho.Text && strMa_Ct == "SOCP")
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Mã kho khác mã kho hàng gửi, yêu cầu kiểm tra mã kho và mã kho nhập của hình thức giao nhận GK" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            if (txtMa_Nvu.Text == "SO06" && !Common.InlistLike(txtHt_Gn.Text, "GK"))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Mã nghiệp vụ và hình thức giao nhận không trùng khớp" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            //
            if ((enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy) && (string)SQLExec.ExecuteReturnValue("SELECT So_Ct FROM R80PH WHERE So_Ct = '" + txtSo_Ct.Text + "' AND Ma_Ct = '" + txtMa_Ct.Text + "' AND YEAR(Ngay_Ct) = YEAR('" + dteNgay_Ct.Text + "')") == txtSo_Ct.Text)
            {
                drEditPh["So_Ct"] = txtSo_Ct.Text = Voucher.Cong_So_Ct_SO(this);

                foreach (DataRow dr in dtEditCt.Rows)
                {
                    dr["So_Ct"] = drEditPh["So_Ct"];
                }
            }
            if (Common.InlistLike(txtHt_Gn.Text, "DD,GK") && txtMa_KhoN.Text == "" && strMa_Ct == "SO")
            {
                string strMsg = "Yêu cầu nhập mã kho cho PXNDH này!!!";
                Common.MsgOk(strMsg);
                return false;
            }
           

            if (txtPt_Vc.Text == "" || txtPt_Vc.Text == string.Empty)
            {
                string strMsg = "Yêu cầu nhập phương thức vận chuyển!!!";
                Common.MsgOk(strMsg);
                    return false;
            }
            if (txtHt_Gn.Text == "" || txtHt_Gn.Text == string.Empty)
            {
                string strMsg = "Yêu cầu nhập hình thức giao nhận!!!";
                Common.MsgOk(strMsg);
                return false;
            }
            if (this.txtHt_Gn.Text == "KG" && !txtHT_TT.Text.StartsWith("TC"))
            {
                string strMsg = "Hình thức thanh toán và phương thức giao nhận không hợp lý. Cần kiểm tra lại không ?";
                if (Common.MsgYes_No(strMsg, "N"))
                    return false;

            }
            if (Common.Inlist(strMa_Ct, "SO,SOCP") && txtHt_Gn.Text.StartsWith("KG"))
            {
                Hashtable ht = new Hashtable();
                ht.Add("NGAY_CT", dteNgay_Ct.Text);
                ht.Add("MA_DT", txtMa_Dt.Text);
                ht.Add("MA_KHON", txtMa_KhoN.Text);
                ht.Add("STT", strStt);

                Hashtable ht1 = new Hashtable();
                ht1.Add("NGAY_CT", dteNgay_Ct.Text);
                ht1.Add("NGAY_CT1", dteNgay_Ct.Text);
                ht1.Add("MA_DT", txtMa_Dt.Text);
                if (SQLExec.ExecuteReturnDt("SELECT * FROM R81DMKHOCT_KG WHERE Ma_Dt = @Ma_Dt AND sl_dm_kg <> 0 AND" +
                    "   Ngay_Ap <= @Ngay_Ct AND Ngay_Kt >= @Ngay_Ct1",ht1, CommandType.Text).Rows.Count > 0)
                {
                    DataTable dtKG = SQLExec.ExecuteReturnDt("sp_rptCheck_SOKG", ht, CommandType.StoredProcedure);
                    DataRow drKG = dtKG.Rows[0];
                    if (numTSo_Luong.Value > Convert.ToDouble(drKG["SL_CL"]))
                    {
                        double dbChenh_Lech = numTSo_Luong.Value - Convert.ToDouble(drKG["SL_CL"]);
                        //if (!Common.MsgYes_No("Số lượng LXH lớn hơn hạn mức ký gửi còn lại " + dbChenh_Lech + ". Bạn có muốn lưu không?", "N"))
                        //    return false;
                        Common.MsgOk("Số lượng LXH lớn hơn hạn mức ký gửi còn lại " + dbChenh_Lech + ". không cho phép lưu.");
                        return false;

                    }
                }
                else
                {
                    Common.MsgOk("Khách hàng "+ lbtTen_Dt.Text +" chưa được khai báo định mức ký gửi. Yêu cầu kiểm tra định mức KG tại danh mục kho và số dư hàng KG!!!");
                    return false;
                }
            }
            if (Common.Inlist(strMa_Ct, "SO,SOCP") && txtMa_CTrinh.Text != "" && txtMa_PLCTrinh.Text == "")
            {
                string strMsg = "Mã phụ lục công trình chưa được nhập. Yêu cầu nhập mã PL công trình";
                if (Common.MsgOk(strMsg))
                    return false;
            }
            if (Common.Inlist(strMa_Ct, "SO,SOCP") && (txtMa_Hd.Text == "" || txtSo_QD.Text == "") && !txtMa_Dt.Text.StartsWith("M") && !Common.InlistLike(txtHt_Gn.Text,"DD,NB"))
            {
                string strMsg = "Chứng từ chưa nhập hợp đồng hay quyết định, yêu cầu kiểm tra lại dữ liệu.";
                if (Common.MsgOk(strMsg))
                    return false;
            }
            // Kiểm tra số QD có hết ngày hiệu lực chưa
            if (txtSo_QD.Text != "")
            {
                DataRow drDmQd = DataTool.SQLGetDataRowByID("vw_So_Qd", "So_Qd", txtSo_QD.Text);
                if (Convert.ToDateTime(drDmQd["Ngay_Het_Han"]) < Convert.ToDateTime(drEditPh["Ngay_Ct"]) && strMa_Ct != "LXH")
                {
                    string strMsg = "Số quyết định " + txtSo_QD.Text + " ngày hết hiệu lực là " + drDmQd["Ngay_Het_Han"] + ". Không lưu phiếu được kiểm tra lại số quyết định";
                    if (Common.MsgOk(strMsg))
                        return false;
                }
                if (Convert.ToDateTime(drDmQd["Ngay_Het_Han"]) < Convert.ToDateTime(drEditPh["Ngay_Ct"]) && strMa_Ct == "LXH" && (!Common.InlistLike(drEditPh["Ht_Gn"].ToString(), "GK") && drEdit["So_Xa_Lan_Tau"] == ""))
                {
                    string strMsg = "Số quyết định " + txtSo_QD.Text + " ngày hết hiệu lực là " + drDmQd["Ngay_Het_Han"] + ". Không lưu phiếu được kiểm tra lại số quyết định";
                    if (Common.MsgOk(strMsg))
                        return false;
                }
                
            }
            //Kiểm tra nghiệp vụ hợp lệ
            foreach (DataRow dr in dtEditCt.Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                    continue;
                if (Common.Inlist(strMa_Ct, "SOCP") && dtEditCt.Select("Ma_Vt = '" + dr["Ma_Vt"] + "' AND Deleted = false").Length > 1)
                {
                    Common.MsgCancel("Không lập phiếu có mã '" + dr["Ma_Vt"] + "' nhiều hơn 1 dòng");
                    return false;
                }
                //Kiểm tra số xe và số xa lan trống
                if (dr["So_Xe"] == string.Empty && dr["So_Xe"] == "" && dr["So_Xa_Lan_Tau"] == string.Empty && dr["So_Xa_Lan_Tau"] == "")
                {
                    Common.MsgOk("Tồn tại dòng " + dr["Stt0"] + " mã vật tư " + dr["Ma_Vt"] + " Số xe và xà lan trống. Cần nhập đầy đủ thông tin trước khi lưu !!!");
                    return false;
                }
                if (Common.Inlist(strMa_Ct, "SO,SOCP") && txtPt_Vc.Text == "XE" && (dr["So_Xe"].ToString() == "" || dr["So_Xe"].ToString() == string.Empty))
                {
                    Common.MsgOk("Tồn tại dòng " + dr["Stt0"] + " mã vật tư " + dr["Ma_Vt"] + " cần đồng nhất số xe với phương thức vận chuyển !!!");
                    return false;
                }
                if (Common.Inlist(strMa_Ct, "SO,SOCP") && txtPt_Vc.Text == "SALAN" && (dr["So_Xa_Lan_Tau"].ToString() == "" || dr["So_Xa_Lan_Tau"].ToString() == string.Empty))
                {
                    Common.MsgOk("Tồn tại dòng " + dr["Stt0"] + " mã vật tư " + dr["Ma_Vt"] + " cần đồng nhất số sà lan với phương thức vận chuyển !!!");
                    return false;
                }
                if (Common.Inlist(strMa_Ct, "SO") && dr["So_Xe"].ToString() != "" && dr["So_Xa_Lan_Tau"].ToString() != "")
                {
                    Common.MsgOk("Tồn tại dòng " + dr["Stt0"] + " mã vật tư " + dr["Ma_Vt"] + " Số xe và xà lan cùng có giá trị. Cần kiểm tra thông tin trước khi lưu !!!");
                    return false;
                }
                if (Common.Inlist(strMa_Ct, "SO,SOCP") && txtMa_Thue.Text != "" && Convert.ToDouble(dr["Thue_Gtgt"]) != 0 && Convert.ToDouble(dr["Tien3"]) + Convert.ToDouble(dr["Tien_Nt3"]) == 0)
                {
                    string strMsg = "Chứng từ có mã thuế " + dr["Ma_Thue"] + " nhưng tiền thuế = 0. Bạn vui lòng enter tại mã thuế !!!";
                    Common.MsgOk(strMsg);
                    return false;
                }
                if (Common.Inlist(strMa_Ct, "SO,SOCP") && txtMa_Thue.Text != "" && Convert.ToDouble(dr["Thue_Gtgt"]) == 0 && Convert.ToDouble(dr["Tien3"]) + Convert.ToDouble(dr["Tien_Nt3"]) == 0)
                {
                    string strMsg = "Chứng từ có mã thuế " + dr["Ma_Thue"] + " nhưng tiền thuế = 0. Bạn vui lòng enter tại mã thuế !!!";
                    Common.MsgOk(strMsg);
                    return false;
                }
                if (Common.Inlist(strMa_Ct, "SO,LXH") && Convert.ToDouble(dr["So_Luong_Cay"]) == 0 && dr["Ma_Vt"].ToString().StartsWith("BD") && dr["Ma_Vt"].ToString().Substring(6,4) != "0000")
                {
                    Common.MsgOk("Tồn tại dòng " + dr["Stt0"] + " mã vật tư " + dr["Ma_Vt"] + " thông tin tổng số cây chưa được cập nhật. Vui lòng enter lại");
                    return false;
                }


            
                #region Kiểm tra tồn kho đối với chung tu
                if (strMa_Ct == "SOCP" && Common.InlistLike(dr["Ma_Kho"].ToString(), "051,052,551"))
                {
                    double dbTon_Cuoi = 0;
                    Voucher.GetTonCuoi_KKV(dr, ref dbTon_Cuoi, ref dtCheckInventory);
                    if (Convert.ToDouble(dr["So_Luong"]) > dbTon_Cuoi)
                    {
                        if (Common.MsgYes_No("Tồn tại dòng " + dr["Stt0"] + " mã vật tư " + dr["Ma_Vt"] + " số lượng xuất " + Convert.ToDouble(dr["So_Luong"]) + " > số lượng tồn " + dbTon_Cuoi + " yêu cầu sửa lại cho phù hợp. Bạn có muốn kiểm tra chi tiết các lệnh giao hàng không?", "Y"))
                        {
                            frmCheckInventory frm = new frmCheckInventory();
                            frm.Load3(dtCheckInventory);
                        }
                        return false;
                    }
                }
                //kiểm tra kho lẻ của SO
                else if (strMa_Ct == "SO" && Common.InlistLike(dr["Ma_Kho"].ToString(), "04TP") && (bool)dr["Is_KhoLe"])
                {
                    double dbTon_Cuoi = 0;
                    Voucher.GetTonCuoi_KhoLe(dr, ref dbTon_Cuoi, ref dtCheckInventory);
                    if (Convert.ToDouble(dr["So_Luong_Cay_Le"]) > dbTon_Cuoi)
                    {
                        if (Common.MsgYes_No("Tồn tại dòng " + dr["Stt0"] + " mã vật tư " + dr["Ma_Vt"] + " số lượng xuất " + Convert.ToDouble(dr["So_Luong_Cay_Le"]) + " " +
                            "> số lượng tồn " + dbTon_Cuoi + " yêu cầu sửa lại cho phù hợp. Bạn có muốn kiểm tra chi tiết các lệnh giao hàng không?", "Y"))
                        {
                            frmCheckInventory frm = new frmCheckInventory();
                            frm.Load3(dtCheckInventory);
                        }
                        return false;
                    }
                }
                else if (strMa_Ct == "SOCP" && Common.InlistLike(dr["Ma_Kho"].ToString(), "08"))
                {
                    double dbTon_Cuoi = 0;
                    Voucher.GetTonCuoi_CP(dr, ref dbTon_Cuoi, ref dtCheckInventory);
                    if (Convert.ToDouble(dr["So_Luong"]) > dbTon_Cuoi)
                    {
                        if(Common.MsgYes_No("Tồn tại dòng " + dr["Stt0"] + " mã vật tư " + dr["Ma_Vt"] + " số lượng xuất " + Convert.ToDouble(dr["So_Luong"]) + " > số lượng tồn " + dbTon_Cuoi + " yêu cầu sửa lại cho phù hợp. Bạn có muốn kiểm tra chi tiết các lệnh giao hàng không?","Y"))
                        {
                            frmCheckInventory frm = new frmCheckInventory();
                            frm.Load3(dtCheckInventory);
                        }
                        return false;
                    }
                }
                else if ((strMa_Ct == "LXH") 
                        && Common.InlistLike(dr["Ma_Kho"].ToString(), "GK_051,GK_551,GK_055"))

                {
                    if (!strMa_Vt_Check.Contains(dr["Ma_Vt"].ToString())) //nếu không tồn tại trong chuổi đã check thì mới kiểm tra để tăng tốc độ
                    {
                        double dbTon_Cuoi = 0; double dbSo_Luong = 0;
                        Voucher.GetTonCuoi_GK_KKV(dr, ref dbTon_Cuoi, ref dtCheckInventory);
                        dbSo_Luong = Common.SumDCValue(dtEditCt, "So_Luong9", "Ma_Vt = '" + dr["Ma_Vt"].ToString() + "'");
                        if (dbSo_Luong > dbTon_Cuoi)
                        {
                            if (Common.MsgYes_No("Tồn tại dòng " + dr["Stt0"] + " mã vật tư " + dr["Ma_Vt"] + " số lượng xuất " + Convert.ToDouble(dr["So_Luong"]) + " > số lượng tồn " + dbTon_Cuoi + " yêu cầu sửa lại cho phù hợp. Bạn có muốn kiểm tra chi tiết các lệnh giao hàng không?", "Y"))
                            {
                                frmCheckInventory frm = new frmCheckInventory();
                                frm.Load3(dtCheckInventory);
                            }
                            return false;
                        }
                        strMa_Vt_Check += dr["Ma_Vt"].ToString() + ",";
                    }
                }
                #endregion
                #region kiểm tra bó có đúng số cây
                double dbNumbar = 0;
                if(dr["Ma_Vt"].ToString().StartsWith("BD") && !dr["Ma_Vt"].ToString().StartsWith("BD00"))
                {
                    dbNumbar = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Num_Bars", dr["Ma_Vt"].ToString()));
                    if (Convert.ToDouble(dr["So_Luong_Cay"]) != Convert.ToDouble(dr["So_Luong_Cay_Le"]) + (dbNumbar* Convert.ToDouble(dr["So_Luong_Bo"])))
                    {
                        Common.MsgOk("Tồn tại dòng " + dr["Stt0"] + " mã vật tư " + dr["Ma_Vt"] + " số lượng bó " + Convert.ToDouble(dr["So_Luong_bo"]) + " khác số lượng cây " + Convert.ToDouble(dr["So_Luong_Cay"]) + " yêu cầu sửa lại cho phù hợp.");
                        return false;
                    }
                }
                #endregion
                #region Kiểm tra tính hợp lệ của định nghĩa nghiệp vụ
                foreach (DataColumn dc in drDmNvu.Table.Columns)
                {
                    if (dc.ColumnName.EndsWith("_RULE") && drDmNvu.Table.Columns.Contains(dc.ColumnName.Replace("_RULE", "")))
                    {
                        string strRule_Name = dc.ColumnName;
                        string strColumnName = strRule_Name.Replace("_RULE", "");

                        if (drDmNvu[strColumnName].ToString() != "")
                        {
                            //1-Bắt buộc, 2-Cho phép sửa lại phần đuôi, 3-Cho phép thay đổi
                            if ((drDmNvu[strRule_Name].ToString() == "1") && !(drDmNvu[strColumnName].ToString().Split(',').Any(strValue => strValue == dr[strColumnName].ToString())))
                            {
                                Common.MsgCancel("Nhập liệu [" + Languages.GetLanguage(strColumnName) + "] không đúng với định nghĩa nghiệp vụ!");
                                return false;
                            }
                            else if ((drDmNvu[strRule_Name].ToString() == "2") && !(drDmNvu[strColumnName].ToString().Split(',').Any(strValue => dr[strColumnName].ToString().StartsWith(strValue))))
                            {
                                Common.MsgCancel("Nhập liệu [" + Languages.GetLanguage(strColumnName) + "] không đúng với định nghĩa nghiệp vụ!");
                                return false;
                            }
                        }
                    }
                }
                #endregion

                string strStt_Org = dtEditCt.Rows[0]["Stt_Org"].ToString();

                if (strMa_Ct == "LXH")
                {                    
                    if (!string.IsNullOrEmpty(dr["Stt_Org"].ToString()))
                    {
                        //ktra trùng mã vt, so_lxh của hàng GK
                        if (Common.Inlist(strMa_Ct, "LXH") && dtEditCt.Select("Ma_Vt = '" + dr["Ma_Vt"] + "' AND Stt_Org = '" + dr["Stt_Org"] + "' AND So_LXH = '" + dr["So_LXH"] + "' AND Deleted = false").Length > 1)
                        {
                            Common.MsgCancel("Dữ liệu kế thừa sản phẩm '" + dr["Ma_Vt"] + "' bị trùng với số lệnh '"+ dr["So_LXH"] + "' yêu cầu xóa dữ liệu bị trùng mới cho phép lưu");
                            return false;
                        }
                        //kiểm tra đối với hàng cuộn phải có số bó
                        if (Common.Inlist(strMa_Ct, "LXH") && dtEditCt.Select("Ma_Vt LIKE 'BR%' AND So_LXH <> '' AND So_Luong_Bo = 0 AND Deleted = false").Length > 0)
                        {
                            Common.MsgCancel("Dữ liệu kế thừa thép cuộn '" + dr["Ma_Vt"] + "' phải nhập số bó với số lệnh '" + dr["So_LXH"] + "' mới được phép lưu");
                            return false;
                        }
                        double dbSo_Luong_Cay = Convert.ToDouble(dr["So_Luong_Cay"]);
                        double dbSo_Luong = Convert.ToDouble(dr["So_Luong"]);
                        double dbTon_Cuoi = 0, dbTon_Cuoi_Bo = 0, dbTon_Cuoi_Cay_Le = 0, dbTon_Cuoi_Cay = 0, dbTon_Cuoi_Cay_Gk = 0, dbTon_Cuoi_Gk = 0, dbTon_Cuoi_Gk_Cuon = 0;
                        string strMa_Kho_GK = "";
                        //KIỂM TRA TỒN GỬI KHO
                        if (dr["So_LXH"].ToString() != "" && dr["Ma_Kho"].ToString().StartsWith("GK") && txtSo_Ct.Text.StartsWith("G"))
                        {
                            Voucher.GetLenhGKCL(dr, ref dbTon_Cuoi_Cay_Gk, ref dbTon_Cuoi_Gk, ref dbTon_Cuoi_Gk_Cuon, ref strMa_Kho_GK);
                            if(dr["Ma_Kho"].ToString() != strMa_Kho_GK)
                            {
                                if(!Common.MsgYes_No("Mã kho " + dr["Ma_Kho"].ToString() + " khác với kho của lệnh gửi " + strMa_Kho_GK + ", bạn muốn tiếp tục không??", "Y"))
                                     return false;
                            }
                            if(dr["Ma_Vt"].ToString().StartsWith("BD") && dbSo_Luong_Cay > dbTon_Cuoi_Cay_Gk)
                            {
                                Common.MsgCancel("Mã sản phẩm "+ dr["Ma_Vt"].ToString() + " SL xuất "+ dbSo_Luong_Cay.ToString() + " còn lại của lệnh gửi "+ dr["So_LXH"].ToString() +" kho còn "+ dbTon_Cuoi_Cay_Gk.ToString() + " cây, anh chị sửa lại số cây phải nhỏ hơn hoặc bằng số cây còn lại!!!");
                                return false;
                            }
                            else if (dr["Ma_Vt"].ToString().StartsWith("BR") && dbSo_Luong > dbTon_Cuoi_Gk)
                            {
                                Common.MsgCancel("Mã sản phẩm " + dr["Ma_Vt"].ToString() + " SL còn lại của lệnh gửi kho còn " + dbTon_Cuoi_Gk_Cuon.ToString() + " kg, các anh chị sửa số Kg nhỏ hơn hoặc bằng "+ dbTon_Cuoi_Gk.ToString() + "");
                                return false;
                            }
                        }
                        //Kiểm tra tồn kho
                        if ((string)dr["Ma_Vt"] != string.Empty && (string)dr["Ma_Kho"] != string.Empty && (string)drDmCt["Nh_Ct"] == "2")
                        {                            

                            if (dr["Ma_Kho"].ToString() == "GK_04TP")
                                Voucher.GetTonCuoi_GK04TP(dr, ref dbTon_Cuoi, ref dbTon_Cuoi_Cay, ref dtCheckInventory);
                            else if (dr["Ma_Kho"].ToString() == "04TP")
                                Voucher.GetTonCuoi_LXH(dr, ref dbTon_Cuoi, ref dbTon_Cuoi_Bo, ref dbTon_Cuoi_Cay_Le, ref dbTon_Cuoi_Cay);
                            else if (Common.InlistLike(dr["Ma_Kho"].ToString(), "GK") && dr["Ma_Kho"].ToString() != "GK_055POM1")
                                Voucher.GetTonCuoi_KKV(dr, ref dbTon_Cuoi, ref dtCheckInventory);
                            
                            if ((dr["Ma_Kho"].ToString() == "GK_04TP" && dbSo_Luong_Cay > dbTon_Cuoi_Cay))
                            {
                                string strMsg = string.Empty;
                                if (Common.MsgYes_No("Tồn tại dòng " + dr["Stt0"] + " mã vật tư " + dr["Ma_Vt"] + " số lượng xuất " + Convert.ToDouble(dr["So_Luong"]) + " > số lượng tồn " + dbTon_Cuoi + " yêu cầu sửa lại cho phù hợp. Bạn có muốn kiểm tra chi tiết các lệnh giao hàng không?", "Y"))
                                {
                                    frmCheckInventory frm = new frmCheckInventory();
                                    frm.Load3(dtCheckInventory);
                                }
                                return false;
                                
                            }
                            //20/5 cho phép bán âm kho
                            else if ((!Common.Inlist(dr["Ma_Kho"].ToString(), "GK_04TP,GK_055POM1") && dbSo_Luong > dbTon_Cuoi))
                            {
                                string strMsg = string.Empty;

                                if (Element.sysLanguage == enuLanguageType.Vietnamese)
                                    strMsg = "Dòng " + dr["Stt0"].ToString() + " số lượng xuất: " + dbSo_Luong.ToString("N2") + " > số lượng tồn: " + dbTon_Cuoi.ToString("N2");
                                else
                                    strMsg = "Row " + dr["Stt0"].ToString() + " out quantity: " + dbSo_Luong.ToString("N2") + " > closing inventory quantity: " + dbTon_Cuoi.ToString("N2");

                                Common.MsgCancel(strMsg);
                                return false;
                            }

                        }
                    else
                    {
                        Common.MsgCancel("Dòng " + dr["Stt0"].ToString() + " Mã vật tư " + dr["Ma_Vt"].ToString() + " không xác định được LXH kế thừa !");
                        return false;
                    }
                }

            }
        }
        return true;
        }

        public override bool Save()
        {
            //dtEditCt.AcceptChanges();

            Common.GatherMemvar(this, ref this.drEditPh);
            Voucher.Update_Detail(this);

            if (!FormCheckValid())
                return false;

            if (drEditPh.Table.Columns.Contains("Ten_Dt"))
                drEditPh["Ten_Dt"] = lbtTen_Dt.Text;
            if (drEditPh.Table.Columns.Contains("So_Dh_Kh"))
                drEditPh["So_Dh_Kh"] = txtSo_Dh_Kh.Text;
            if (drEditPh.Table.Columns.Contains("ID_Dt_Vc"))
                drEditPh["ID_Dt_Vc"] = txtID_Dt_Vc.Text;


            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            {
                drEditPh["Create_Log"] = Common.GetCurrent_Log();
                drEditPh["LastModify_Log"] = string.Empty;
            }
            else
            {
                drEditPh["LastModify_Log"] = Common.GetCurrent_Log();
                if ((string)drEditPh["Create_Log"] == string.Empty)
                    drEditPh["Create_Log"] = drEditPh["LastModify_Log"];
            }
            Voucher.Update_TTien(this);
            Voucher.Update_Stt(this, strModule);
            Voucher.UpdateSo_Ct(this);

            if (!(bool)drEditPh["Duyet"]) //Trường hợp chứng từ chưa duyệt
            {
                if (dtEditPh.Columns.Contains("Ngay_Ct_Lap"))
                {
                    drEditPh["Ngay_Ct_Lap"] = drEditPh["Ngay_Ct"];
                    drEditPh["So_Ct_Lap"] = drEditPh["So_Ct"];
                }
            }

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
                    Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

                drEdit = drEditPh;
            }

            return Voucher.SQLUpdateCt(this);
        }

        private void LockControl()
        {

            this.txtMa_Hd.Enabled = false;
            this.txtMa_Dt.Enabled = false;
           
            this.txtSo_QD.Enabled = false;
            this.txtMa_Kho.Enabled = false;
            this.txtHT_TT.Enabled = false;
            this.txtPt_Vc.Enabled = false;
            
            if(drEdit["Ht_Gn"].ToString() != "GK")
                this.txtMa_CTrinh.Enabled = false;
            else
                this.txtMa_CTrinh.Enabled = true;
        }

        private void Ma_Tte_Valid()
        {
            string strMa_Tte = txtMa_Tte.Text.Trim();
            string strMa_Tte_Old = (string)drEditPh["Ma_Tte"];

            if (Element.sysMa_Tte == strMa_Tte)
            {
                numTy_Gia.Value = 1;
                numTy_Gia.Enabled = false;

                this.pnlTTien.Visible = false;
                this.pnlTTien_Nt.Left = this.pnlTTien.Right - this.pnlTTien_Nt.Width;

                if (dgvEditCt1.Columns.Contains("TIEN"))
                    dgvEditCt1.Columns["TIEN"].Visible = false;
                if (dgvEditCt1.Columns.Contains("GIA_NT"))
                    dgvEditCt1.Columns["Gia_Nt"].ReadOnly = true;
                if (dgvEditCt1.Columns.Contains("GIA_NT9"))
                    dgvEditCt1.Columns["Gia_Nt9"].ReadOnly = true;
                if (dgvEditCt1.Columns.Contains("GIA"))
                    dgvEditCt1.Columns["Gia"].ReadOnly = true;
            }
            else
            {
                numTy_Gia.Enabled = true;

                if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange)
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
                    ht.Add("MA_TTE", strMa_Tte);

                    numTy_Gia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetTyGia", ht, CommandType.StoredProcedure));
                }

                this.pnlTTien.Visible = true;
                this.pnlTTien_Nt.Left = this.pnlTTien.Left - this.pnlTTien_Nt.Width;
            }

            numTTien_Nt.Scale = numTTien_Nt0.Scale = numTTien_Nt3.Scale = strMa_Tte == Element.sysMa_Tte ? 0 : 3;

            Voucher.FormatTien_Nt_SO(dgvEditCt1, strMa_Tte);
            Voucher.FormatTien_Nt_SO(dgvEditCt2, strMa_Tte);

            dgvEditCt1.ResizeGridView();
            dgvEditCt2.ResizeGridView();
        }

        private bool CellKeyEnter()
        {//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc			
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;

            if (dgvEditCt1.CurrentCell == null)
                return false;

            DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
            string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

            #region Enter tai TEN_VT
            if (Common.Inlist(strCurrentColumn, "MA_VT,TEN_VT"))
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                if ((drCurrent["Ma_Vt"] == DBNull.Value || (string)drCurrent["Ma_Vt"] == string.Empty) && bdsEditCt.Count > 1)
                {
                    bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;

                    bdsEditCt.RemoveCurrent();
                    //dtEditCt.AcceptChanges();

                    if (bIsCurrentLastRow)
                        this.SelectNextControl(dgvEditCt1, true, true, true, true);

                    return true;
                }

                return false;


            }
            #endregion

            //Xuống dòng
            string strColumnLast = (string)SQLExec.ExecuteReturnValue("SELECT TOP 1 ISNULL(Column_ID, '') FROM R00COLUMN WHERE ZONE LIKE '" + dgvEditCt1.strZone + "' AND Visible = 1 ORDER BY Stt DESC", CommandType.Text);

            if (strCurrentColumn == strColumnLast)
            {
                if (dgvEditCt1.bIsCurrentLastRow)
                {
                    if (!Voucher.AddRow(this))
                        this.SelectNextControl(dgvEditCt1, true, true, true, true);
                    else
                    {
                        dgvEditCt1.FocusNextFirstCell();
                        return true;
                    }
                }
                else
                    dgvEditCt1.FocusNextFirstCell();
            }

            #region Enter tai TIEN_NT9
            if (Common.Inlist(strCurrentColumn, "TIEN_NT9"))
            {
                if (txtMa_Tte.Text.Trim() == Element.sysMa_Tte)
                {
                    // Cap nhat tien TIEN_NT9 truoc khi xuong dong
                    double dbTien_Nt9 = 0;
                    if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien_Nt9))
                    {
                        dgvEditCt1.CancelEdit();
                        drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                        drCurrent["TIEN_NT9"] = dbTien_Nt9;
                        Voucher.Calc_So_Luong(drCurrent, this);
                        Voucher.Update_TTien(this);
                    }


                }
                return false;
            }

            #endregion

            #region Enter TIEN
            if (Common.Inlist(strCurrentColumn, "TIEN"))
            {
                if (dgvEditCt1.bIsCurrentLastRow)
                {
                    // Cap nhat Tien truoc khi xuống dòng
                    double dbTien = 0;
                    if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien))
                    {
                        dgvEditCt1.CancelEdit();
                        drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                        drCurrent["TIEN"] = dbTien;
                        Voucher.Calc_So_Luong(drCurrent, this);
                        Voucher.Update_TTien(this);
                    }

                    if (!Voucher.AddRow(this))
                        return false;
                    else
                        dgvEditCt1.FocusNextFirstCell();


                    return true;
                }

                return false;
            }
            #endregion

            return false;
        }

        private void TTien_Valid()
        {
            numTTien0.Value = numTTien_Nt0.Value * numTy_Gia.Value;

            if (numTTien3.Value == 0)
                numTTien3.Value = numTTien_Nt3.Value * numTy_Gia.Value;
            else if (numTTien_Nt3.Value == 0 && numTy_Gia.Value != 0)
                numTTien_Nt3.Value = numTTien3.Value / numTy_Gia.Value;

            this.drEditPh["TTien0"] = numTTien0.Value;
            this.drEditPh["TTien_Nt0"] = numTTien_Nt0.Value;
            this.drEditPh["TTien3"] = numTTien3.Value;
            this.drEditPh["TTien_Nt3"] = numTTien_Nt3.Value;

            this.drEditPh["TTien"] = Convert.ToDouble(this.drEditPh["TTien0"]) + Convert.ToDouble(this.drEditPh["TTien3"]);
            this.drEditPh["TTien_Nt"] = Convert.ToDouble(this.drEditPh["TTien_Nt0"]) + Convert.ToDouble(this.drEditPh["TTien_Nt3"]);

            Voucher.Adjust_TThue_Vat(this);
        }

        public void CheckInventory(DataTable dtCheckInventory)
        {
            if (bdsEditCt.Count > 0)
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                drCurrent["Ngay_Ct"] = Library.StrToDate(dteNgay_Ct.Text);

                if (drCurrent["Ma_Vt"].ToString() == "")
                    return;
                
                if (frmCheckInventory == null || frmCheckInventory.IsDisposed)
                {
                    frmCheckInventory = new frmCheckInventory();
                    
                    frmCheckInventory.frmEdit = this;
                    frmCheckInventory.Left = this.Left + 10;
                    frmCheckInventory.Top = dgvEditCt1.Bottom + 10;
                    frmCheckInventory.Width = this.Width / 100 * 70;


                    frmCheckInventory.Load(this.enuNew_Edit, drCurrent);
                    frmCheckInventory.Show(this);
                }
                else
                {
                    frmCheckInventory.Load3(dtCheckInventory);
                    frmCheckInventory.Show();
                }
            }
        }
        #endregion

        #region Su kien

        #region FormEvent

        void btnImportExcel_Click(object sender, EventArgs e)
        {
            Voucher.ImportExcelCtVT(this);
        }
        void btDuyet_Dh_Click(object sender, EventArgs e)
        {
            
            if (Common.Inlist(strMa_Ct, "SO,SOCP"))
            {
                //PKT
                bool bDuyet = Common.CheckPermission("DUYET", enuPermission_Type.Allow_Access);
                bool bDuyet_SO_PKT = Common.CheckPermission("DUYET_SO_PKT", enuPermission_Type.Allow_Access);
                //PKD
                bool bDuyet_PKD = Common.CheckPermission("DUYET_PKD", enuPermission_Type.Allow_Access);

                string strCreate_User = (string)drEditPh["Create_Log"];
                string strUser_Allow = string.Empty;
                string strUser_Duyet = (string)drEditPh["Duyet_Log"];
                string strUser_login = Element.sysUser_Id.ToString().Trim();
                
                if (bDuyet_SO_PKT)
                {
                    if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
                    {
                        strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                    }

                    bool Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET FROM R80PH WHERE Stt = '" + strStt + "'"));
                    bool Is_Duyet_PKD = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_PKD FROM R80PH WHERE Stt = '" + strStt + "'"));
                    double iPrint_Count = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT PRINT_COUNT FROM R80PH WHERE Stt = '" + strStt + "'"));

                    if (bDuyet_SO_PKT && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
                    {
                        //if (string.IsNullOrEmpty(strUser_Duyet))
                        //{
                        if (Is_Duyet_PKD && !Is_Duyet)
                        {
                            frmDuyetYeuCau frm = new frmDuyetYeuCau();
                            frm.Load(drEditPh, Is_Duyet, "DUYET");

                            if (frm.Is_Accept)
                            {
                                //cập nhật thông tin duyet
                                string strSQLExec = string.Empty;
                                Hashtable htPara = new Hashtable();

                                drEditPh["DUYET"] = frm.chkDuyet.Checked;
                                    

                                htPara.Add("DUYET", (bool)drEditPh["DUYET"]);
                                htPara.Add("IS_VT_NHAN", (bool)drEditPh["IS_VT_NHAN"]);
                                htPara.Add("GHI_CHU_PKTTC", frm.txtGhi_Chu_PKTTC.Text);
                                htPara.Add("STT", drEditPh["STT"]);
                                htPara.Add("DUYET_LOG", Common.GetCurrent_Log());
                                   

                                strSQLExec = "UPDATE R80PH SET DUYET = @DUYET, DUYET_LOG = @DUYET_LOG,  GHI_CHU_PKTTC = @GHI_CHU_PKTTC WHERE Stt = @STT";
                                SQLExec.Execute(strSQLExec, htPara, CommandType.Text);

                                //tạo LXH khi duyet phiếu SO
                                //Insert_LXH();
                            }
                        }
                        //}
                        else if (strUser_Duyet != string.Empty && Element.sysUser_Id.ToString().Trim() == strUser_Duyet.Substring(14))
                        {
                            if (iPrint_Count == 0)
                            {
                                string sqlKT = "";
                                sqlKT = "SELECT T1.Stt FROM R04CTSO T1 JOIN R80PH T2 ON T1.Stt = T2.Stt AND T2.Duyet_Huy =0 WHERE Stt_Org =  " + "'" + drCurrent["Stt"] + "'";
                                if (!String.IsNullOrEmpty((string)SQLExec.ExecuteReturnValue(sqlKT)))
                                {
                                    Common.MsgOk("CHỨNG TỪ ĐÃ ĐƯỢC KẾ THỪA");
                                    return;
                                }
                                frmDuyetYeuCau frm = new frmDuyetYeuCau();
                                frm.Load(drEditPh, Is_Duyet, "DUYET");
                                if (frm.Is_Accept)
                                {
                                    string strSQLExec = string.Empty;
                                    Hashtable htPara = new Hashtable();

                                    drEditPh["DUYET"] = frm.chkDuyet.Checked;
                                   

                                    htPara.Add("DUYET", (bool)drEditPh["DUYET"]);
                                    htPara.Add("IS_VT_NHAN", (bool)drEditPh["IS_VT_NHAN"]);
                                    htPara.Add("GHI_CHU_PKTTC", frm.txtGhi_Chu_PKTTC.Text);
                                    htPara.Add("STT", drEditPh["STT"]);
                                    htPara.Add("DUYET_LOG", Common.GetCurrent_Log());
                                   

                                    strSQLExec = "UPDATE R80PH SET DUYET = @DUYET, DUYET_LOG = @DUYET_LOG, GHI_CHU_PKTTC = @GHI_CHU_PKTTC WHERE Stt = @STT";
                                    SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                                    //tạo LXH khi duyet phiếu SO
                                    //Insert_LXH();
                                }
                            }
                            else
                            {
                                Common.MsgOk("Chứng từ đã được in, không bỏ duyệt được");
                                return;
                            }
                        }
                    }
                    else
                    {
                        Common.MsgOk("Bạn không có quyền duyệt hoặc hủy duyệt của người khác, hoặc chứng từ đã được in");
                        return;
                    }
                }
                else
                {

                    string strUser_Duyet_PKD = (string)drEditPh["User_Duyet_PKD"];

                    if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
                    {
                        strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                    }

                    if (Common.Inlist(strMa_Ct, "SO,SOCP") && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
                    {
                        frmDuyet_PKD frm = new frmDuyet_PKD();
                        if (Common.CheckPermission("DUYET_PKD", enuPermission_Type.Allow_Access))
                        {
                            if (string.IsNullOrEmpty(strUser_Duyet_PKD))
                                frm.Load(drEditPh);
                            else if (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ","))//Element.sysUser_Id.ToString().Trim() == strUser_Duyet_PKD.Trim())
                                frm.Load(drEditPh);
                        }
                        else
                            Common.MsgOk("Bạn không có quyền duyệt hoặc hủy duyệt của người khác");

                    }

                }
            }
            
        }
        //private void Insert_LXH()
        //{
        //    if (strMa_Ct == "SO" && (bool)drEditPh["Duyet_TP"])
        //    {
        //        string strCreate_User = (string)drEditPh["Create_Log"];
        //        string strStt_LXH = "A0104" + strCreate_User.Substring(0, 6) + "X" + txtSo_Ct.Text.Substring(1, 3);
        //        string strSo_Ct_LXH = txtSo_Ct.Text + "_001";

        //        drEditPh["Stt"] = strStt_LXH;
        //        drEditPh["So_Ct"] = strSo_Ct_LXH;
        //        drEditPh["Ma_Ct"] = "LXH";
        //        drEditPh["Duyet"] = false;
        //        drEditPh["Duyet_Log"] = "";
        //        drEditPh["Duyet_PKD"] = false;
        //        drEditPh["Duyet_Log_PKD"] = "";

        //        foreach (DataRow drCt in dtEditCt.Rows)
        //        {
        //            if (drCt.RowState == DataRowState.Deleted)
        //                continue;

        //            drCt["Stt"] = strStt_LXH;
        //            drCt["So_Ct"] = strSo_Ct_LXH;
        //            drCt["Ma_Ct"] = "LXH";
        //        }

        //        dtEditPh.AcceptChanges();
        //        dtEditCt.AcceptChanges();

        //        SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
        //        SqlCommand sqlCom = sqlCon.CreateCommand();


        //        sqlCom.CommandText = "sp_Update_Ct";
        //        sqlCom.CommandType = CommandType.StoredProcedure;

        //        sqlCom.Parameters.Clear();
        //        sqlCom.Parameters.AddWithValue("@strNew_Edit", "N");
        //        sqlCom.Parameters.AddWithValue("@Stt", strStt_LXH);
        //        sqlCom.Parameters.AddWithValue("@Ma_Ct", "LXH");
        //        sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

        //        //Tạo Table cho TVP_PH
        //        SqlParameter paraPH = new SqlParameter();
        //        paraPH.SqlDbType = SqlDbType.Structured;
        //        paraPH.ParameterName = "@PH";

        //        SqlParameter paraCt = new SqlParameter();
        //        paraCt.SqlDbType = SqlDbType.Structured;
        //        paraCt.ParameterName = "@Ct";

        //        sqlCom.CommandText = "sp_Update_CtSO";

        //        //TVP_PH
        //        paraPH.TypeName = "TVP_PHSO";
        //        paraPH.Value = Voucher.GetTVPValue("R80PH", "TVP_PHSO", dtEditPh);
        //        sqlCom.Parameters.Add(paraPH);

        //        //Tạo Table cho TVP_CtSO
        //        paraCt.TypeName = "TVP_CtSO";
        //        paraCt.Value = Voucher.GetTVPValue("R04CtSO", "TVP_CtSO", dtEditCt);
        //        sqlCom.Parameters.Add(paraCt);

        //        try
        //        {
        //            sqlCom.ExecuteNonQuery();
        //            //MessageBox.Show("Đã tạo xong lệnh xuất hàng" );
        //        }
        //        catch (Exception ex)
        //        {
        //            sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
        //            sqlCom.CommandType = CommandType.Text;
        //            sqlCom.Parameters.Clear();
        //            sqlCom.ExecuteNonQuery();

        //            MessageBox.Show("Có lỗi xảy ra :" + ex.Message);

        //        }
        //    }
        //}
        void btInherit_Click(object sender, EventArgs e)
        {
            this.InheritVoucher();
            this.LoadDicName();

        }

        void txtMa_Nvu_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nvu.Text.Trim();
            bool bRequire = true;
            string strFilter = "(CHARINDEX('" + strMa_Ct + "', Ma_Ct, 0) > 0 OR Ma_Ct = '*')";
            string strValid = "Ma_Ct <> ''";

            DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, strFilter, strValid);

            if (drLookup == null) //Bắt buộc phải nhập Ma_Nvu
            {
                e.Cancel = true;
                return;
            }

            drDmNvu = drLookup;

            txtMa_Nvu.Text = drLookup["Ma_Nvu"].ToString();
            lbtTen_Nvu.Text = drLookup["Ten_Nvu"].ToString();

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEditPh["Duyet"] = (bool)drDmNvu["Default_Duyet"];

            if (this.enuNew_Edit == enuEdit.New)
            {

                if (dtEditCt.Columns.Contains("Ma_Kho") && drDmNvu["Ma_Kho"].ToString() != "" && !drDmNvu["Ma_Kho"].ToString().Contains(",")) //Ma_Kho
                {
                    foreach (DataRow dr in dtEditCt.Rows)
                    {
                        dr["Ma_Kho"] = drDmNvu["Ma_Kho"].ToString();
                    }
                }
                
                foreach (DataRow dr in dtEditCt.Rows)
                {
                    dr["Ma_KhoN"] = drDmNvu["Ma_KhoN"].ToString();
                    txtMa_KhoN.Text = drDmNvu["Ma_KhoN"].ToString();
                }
                
            }

            if (txtMa_Nvu.bTextChange) //(enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy) 
            {
                #region Cập nhật trên Form
                if (drDmNvu["Tk_No"].ToString() != "" && !drDmNvu["Tk_No"].ToString().Contains(",")) //Tk_No
                {

                }
                if (drDmNvu["Tk_Co"].ToString() != "" && !drDmNvu["Tk_Co"].ToString().Contains(",")) //Tk_Co
                {

                }
                if (drDmNvu["Ma_Dt"].ToString() != "" && !drDmNvu["Ma_Dt"].ToString().Contains(",")) //Ma_Dt
                {

                }
                if (drDmNvu["Ma_Bp"].ToString() != "" && !drDmNvu["Ma_Bp"].ToString().Contains(",")) //Ma_Bp
                {

                }
                if (drDmNvu["Ma_Km"].ToString() != "" && !drDmNvu["Ma_Km"].ToString().Contains(",")) //Ma_Km
                {

                }
                if (drDmNvu["Ma_Vt_Sp"].ToString() != "" && !drDmNvu["Ma_Vt_Sp"].ToString().Contains(",")) //Ma_Vt_Sp
                {

                }
                if (drDmNvu["Ma_Hd"].ToString() != "" && !drDmNvu["Ma_Hd"].ToString().Contains(",")) //Ma_Hd
                {

                }
                if (drDmNvu["Ma_Job"].ToString() != "" && !drDmNvu["Ma_Job"].ToString().Contains(",")) //Ma_Job
                {

                }
                if (drDmNvu["Ma_Dt_CbNv"].ToString() != "" && !drDmNvu["Ma_Dt_CbNv"].ToString().Contains(",")) //Ma_Dt_CbNv
                {

                }
                if (drDmNvu["Ma_Thue"].ToString() != "" && !drDmNvu["Ma_Thue"].ToString().Contains(",")) //Ma_Thue
                {

                }
                if (drDmNvu["Ma_Kho"].ToString() != "" && !drDmNvu["Ma_Kho"].ToString().Contains(",")) //Ma_Kho
                {
                    txtMa_Kho.Text = drDmNvu["Ma_Kho"].ToString();
                }
                #endregion

                #region Cập nhật trên lưới
                foreach (DataRow dr in dtEditCt.Rows)
                {
                    if (dtEditCt.Columns.Contains("Tk_No") && drDmNvu["Tk_No"].ToString() != "" && !drDmNvu["Tk_No"].ToString().Contains(",")) //Tk_No
                    {
                        dr["Tk_No"] = drDmNvu["Tk_No"].ToString();
                    }
                    if (dtEditCt.Columns.Contains("Tk_Co") && drDmNvu["Tk_Co"].ToString() != "" && !drDmNvu["Tk_Co"].ToString().Contains(",")) //Tk_Co
                    {
                        dr["Tk_Co"] = drDmNvu["Tk_Co"].ToString();
                    }
                    if (dtEditCt.Columns.Contains("Ma_Dt") && drDmNvu["Ma_Dt"].ToString() != "" && !drDmNvu["Ma_Dt"].ToString().Contains(",")) //Ma_Dt
                    {
                        dr["Ma_Dt"] = drDmNvu["Ma_Dt"].ToString();
                    }
                    if (dtEditCt.Columns.Contains("Ma_Bp") && drDmNvu["Ma_Bp"].ToString() != "" && !drDmNvu["Ma_Bp"].ToString().Contains(",")) //Ma_Bp
                    {
                        dr["Ma_Bp"] = drDmNvu["Ma_Bp"].ToString();
                    }
                    if (dtEditCt.Columns.Contains("Ma_Km") && drDmNvu["Ma_Km"].ToString() != "" && !drDmNvu["Ma_Km"].ToString().Contains(",")) //Ma_Km
                    {
                        dr["Ma_Km"] = drDmNvu["Ma_Km"].ToString();
                    }
                    if (dtEditCt.Columns.Contains("Ma_Vt_Sp") && drDmNvu["Ma_Vt_Sp"].ToString() != "" && !drDmNvu["Ma_Vt_Sp"].ToString().Contains(",")) //Ma_Vt_Sp
                    {
                        dr["Ma_Vt_Sp"] = drDmNvu["Ma_Vt_Sp"].ToString();
                    }
                    if (dtEditCt.Columns.Contains("Ma_Hd") && drDmNvu["Ma_Hd"].ToString() != "" && !drDmNvu["Ma_Hd"].ToString().Contains(",")) //Ma_Hd
                    {
                        dr["Ma_Hd"] = drDmNvu["Ma_Hd"].ToString();
                    }
                    if (dtEditCt.Columns.Contains("Ma_Job") && drDmNvu["Ma_Job"].ToString() != "" && !drDmNvu["Ma_Job"].ToString().Contains(",")) //Ma_Job
                    {
                        dr["Ma_Job"] = drDmNvu["Ma_Job"].ToString();
                    }
                    if (dtEditCt.Columns.Contains("Ma_Dt_CbNv") && drDmNvu["Ma_Dt_CbNv"].ToString() != "" && !drDmNvu["Ma_Dt_CbNv"].ToString().Contains(",")) //Ma_Dt_CbNv
                    {
                        dr["Ma_Dt_CbNv"] = drDmNvu["Ma_Dt_CbNv"].ToString();
                    }
                    if (dtEditCt.Columns.Contains("Ma_Thue") && drDmNvu["Ma_Thue"].ToString() != "" && !drDmNvu["Ma_Thue"].ToString().Contains(",")) //Ma_Thue
                    {
                        dr["Ma_Thue"] = drDmNvu["Ma_Thue"].ToString();
                    }
                    if (dtEditCt.Columns.Contains("Ma_Kho") && drDmNvu["Ma_Kho"].ToString() != "" && !drDmNvu["Ma_Kho"].ToString().Contains(",")) //Ma_Kho
                    {
                        dr["Ma_Kho"] = drDmNvu["Ma_Kho"].ToString();
                        //strMa_Kho = drDmNvu["Ma_Kho"].ToString();
                    }
                }
                #endregion
            }
            if (txtMa_Nvu.Text == "SO06")
                txtMa_KhoN.Text = "GK_04TP";
            

            this.drDmNvu = drLookup;
        }

        public string GetDuCuoi(string strMa_Dt, string strMa_Hd, string strTk)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = dteNgay_Ct.Text;
            ht["MA_DVCS"] = Element.sysMa_DvCs.ToString();
            ht["TK"] = strTk;
            ht["MA_DT"] = strMa_Dt;
            ht["MA_HD"] = strMa_Hd;

            dtDuCuoi = new DataTable();
            dtDuCuoi = SQLExec.ExecuteReturnDt("Sp_GetDuCuoi_MAWB", ht, CommandType.StoredProcedure);

            if (dtDuCuoi != null && dtDuCuoi.Rows.Count > 0)
                return (string)dtDuCuoi.Rows[0]["Dien_Giai"];
            else
                return "";
        }

        void txtMa_Kho_Validating(object sender, CancelEventArgs e)
        {

            string strValue = txtMa_Kho.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Kho.Text = string.Empty;
                lbtTen_Kho.Text = string.Empty;
            }
            else
            {
                txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
                lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
            }
            Voucher.Update_Detail(this, "MA_KHO");

        }

        void txtSo_QD_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_QD.Text.Trim();
            if (strValue == string.Empty)
                return;
            bool bRequire = false;


            string strKeyValid = "";
            string strKeyFilter = string.Empty;
            strKeyFilter = "(CHARINDEX('" + txtMa_Dt.Text.Trim() + "',Nhom_Dt) > 0 OR Nhom_Dt LIKE '%*')" +
                                 " AND (CHARINDEX('" + txtMa_Kho.Text.Trim() + "',Ma_Kho_List) > 0 OR Ma_Kho_List LIKE '%*')" +
                                 " AND Ma_CTrinh='" + txtMa_CTrinh.Text.Trim() + "' " +
                                 " AND (Ngay_Het_Han >= '" + dteNgay_Ct.Text + "'  OR Ngay_Het_Han <='19000101')";


            DataRow drLookup = Lookup.ShowLookup("So_Qd_Dt", strValue, bRequire, strKeyFilter, strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = false;

            if (drLookup == null)
            {
                txtSo_QD.Text = string.Empty;
            }
            else
            {
                txtSo_QD.Text = drLookup["So_QD"].ToString();
                txtMa_CTrinh.Text = drLookup["Ma_CTrinh"].ToString();

                if (drLookup["Ht_Gn"] != "")
                {
                    txtHt_Gn.Text = drLookup["Ht_Gn"].ToString();
                    strHt_Gn_QD = drLookup["Ht_Gn"].ToString();
                }
            }
            drCurrent["So_Qd"] = txtSo_QD.Text.Trim();
            drCurrent["HT_TT"] = txtHT_TT.Text.Trim();
            drCurrent["PT_VC"] = txtPt_Vc.Text.Trim();

            this.Calc_CsGia();
        }
        void txtMa_PLCTrinh_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_PLCTrinh.Text.Trim();
            bool bRequire = false;
            string strKeyValid = string.Empty;
            string strKeyFilter = string.Empty;
            strKeyFilter = "Ma_CTrinh='" + txtMa_CTrinh.Text +"'  ";

            DataRow drLookup = Lookup.ShowLookup("Ma_PLCTrinh", strValue, bRequire, strKeyFilter, "");
            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_PLCTrinh.Text = string.Empty;
                lbtTen_PLCTrinh.Text = string.Empty;
            }
            else
            {
                txtMa_PLCTrinh.Text = drLookup["Ma_PLCTrinh"].ToString();
                lbtTen_PLCTrinh.Text = drLookup["Ten_PLCtrinh"].ToString();
            }
        }
        void txtMa_CTrinh_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_CTrinh.Text.Trim();
            bool bRequire = false;
            string strKeyValid = string.Empty;
            string strKeyFilter = string.Empty;
            //strKeyFilter = "Ma_Dt='" + drCurrent["Ma_Dt"].ToString()+"'  ";//+ "' AND So_QD='" + drCurrent["So_QD"].ToString() + "'

            DataRow drLookup = Lookup.ShowLookup("Ma_CTrinh", strValue, bRequire, strKeyFilter, strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_CTrinh.Text = string.Empty;
                lbtTen_CTrinh.Text = string.Empty;
            }
            else
            {
                txtMa_CTrinh.Text = drLookup["Ma_CTrinh"].ToString();
                lbtTen_CTrinh.Text = drLookup["Ten_Ctrinh"].ToString();
            }


        }

        void txtLoai_Gia_Validating(object sender, CancelEventArgs e)
        {

            bool bRequire = false;
            string strFilter = "Type='LOAI_GIA' AND Type_ID = 'TC40'";

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "LOAI_GIA");
            DataRow drLookup = Lookup.ShowLookup("LOAI_GIA", txtHT_TT.Text, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                txtHT_TT.Text = string.Empty;
            }
            else
            {
                txtHT_TT.Text = drLookup["Type_ID"].ToString();
            }

            drCurrent["So_Qd"] = txtSo_QD.Text.Trim();
            drCurrent["HT_TT"] = txtHT_TT.Text.Trim();

            this.Calc_CsGia();
        }
        void txtMa_KhoN_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_KhoN.Text.Trim();
            bool bRequire = false;
            DataRow drLookup;

            //if (Common.Inlist(txtMa_Nvu.Text, "LXH02")) //,SOGKP2,SOGKD2,SOGKCT
            //    drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "");
            //else 
            if(txtMa_Kho.Text.StartsWith("08") && Common.InlistLike(txtHt_Gn.Text,"DD"))
                drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "Ma_Dt = '" + txtMa_Dt.Text + "'");
            else if (Common.InlistLike(txtMa_Kho.Text,"08,551") && Common.InlistLike(txtHt_Gn.Text, "KG"))
                drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "Ma_Dt = '" + txtMa_Dt.Text + "' AND Ma_Kho LIKE '%.08'");
            else if (Common.InlistLike(txtMa_Kho.Text, "08,551,055,051,052,058,GK") && Common.InlistLike(txtHt_Gn.Text, "GK"))
                drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "Ma_Kho LIKE 'GK%'");
            else
                drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "Ma_Dt = '" + txtMa_Dt.Text + "' AND Ma_Kho NOT LIKE '%.08'");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_KhoN.Text = string.Empty;
            }
            else
            {
                txtMa_KhoN.Text = drLookup["Ma_Kho"].ToString();
                lbtTen_KhoN.Text = drLookup["Ten_Kho"].ToString();
            }
        }
        void txtPt_Vc_Validating(object sender, CancelEventArgs e)
        {
            bool bRequire = true;
            string strFilter = "Type='PT_VC'";

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "PT_VC");
            DataRow drLookup = Lookup.ShowLookup("PT_VC", txtPt_Vc.Text, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                txtPt_Vc.Text = string.Empty;
            }
            else
            {
                txtPt_Vc.Text = drLookup["Type_ID"].ToString();
            }

            drCurrent["So_Qd"] = txtSo_QD.Text.Trim();
            drCurrent["HT_TT"] = txtHT_TT.Text.Trim();
            drCurrent["PT_VC"] = txtPt_Vc.Text.Trim();

            this.Calc_CsGia();
        }

        private void Calc_CsGia()
        {
            foreach (DataRow dr in dtEditCt.Rows)
            {
                int dbGiaDChinh = 0;
                if (dr.RowState == DataRowState.Deleted)
                    continue;
               
              
                if (dr["GIA_DCHINH"].ToString() != string.Empty)
                    dbGiaDChinh = Convert.ToInt16(SQLExec.ExecuteReturnValue("SELECT Type_Value FROM R81DMTYPE WHERE Type_ID ='" + dr["GIA_DCHINH"].ToString().Trim() + "'"));
                Hashtable htParameter = new Hashtable();

                htParameter.Add("SO_QD", txtSo_QD.Text.Trim());
                htParameter.Add("MA_KHO", (string)dr["Ma_Kho"]);
                htParameter.Add("MA_VT", (string)dr["Ma_Vt"]);
                htParameter.Add("HT_TT", txtHT_TT.Text.Trim());
                htParameter.Add("PT_VC", txtPt_Vc.Text);
                htParameter.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
                dr["Gia_Nt9"] = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetCSGia", htParameter, CommandType.StoredProcedure)) - dbGiaDChinh;// == DBNull.Value ? 0 : Convert.ToDouble(dr["GIA_DCHINH"]));


            }

            Voucher.Calc_So_Luong_All(this);
            Voucher.Calc_Tien_All(this);
            Voucher.Update_TTien(this);
            Voucher.Adjust_TThue_Vat(this, true);
        }


        void txtMa_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Ct.Text.Trim();
            bool bRequire = true;
            string strKey = "(Table_Ct = '" + (string)drDmCt["Table_Ct"] + "')";

            DataRow drLookup = Lookup.ShowLookup("Ma_Ct", strValue, bRequire, strKey);

            if (bRequire && drLookup == null)
            {
                txtMa_Ct.Text = strMa_Ct;
                e.Cancel = true;
                return;
            }

            this.strMa_Ct = txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();
            this.drDmCt = drLookup;

            //Tính lại Số chứng từ trong truờng hợp chọn lại Ma_Ct khác
            if (this.enuNew_Edit != enuEdit.Edit && txtMa_Ct.bTextChange)
            {
                txtSo_Ct.Text = Voucher.Cong_So_Ct(this);
                Voucher.Update_Detail(this, "So_Ct");
            }
        }

        void txtMa_Tte_Leave(object sender, EventArgs e)
        {
            this.Ma_Tte_Valid();
            Voucher.Update_Detail(this);
            Voucher.Calc_Tien_All(this);
        }
        void numTy_Gia_Leave(object sender, EventArgs e)
        {
            if (this.txtMa_Tte.Text.Trim() == Element.sysMa_Tte && this.numTy_Gia.Value == 0)
                this.numTy_Gia.Value = 1;

            Voucher.Update_Detail(this);
            Voucher.Calc_Tien_All(this);
            Voucher.Calc_Tien_Von_All(this);
        }



        void txtMa_Hd_Validating(object sender, CancelEventArgs e)
        {
            string strMaHdNot = string.Empty;
            strMaHdNot = Parameters.GetParaValue("MAHDNUMLOT").ToString();
            string strValue = txtMa_Hd.Text.Trim();
            bool bRequire = false;
            string strKeyValid = "";
            string strKeyFilter = " Ma_Nh_Hd LIKE 'B%' AND Ma_Dt = '" + txtMa_Dt.Text.ToString() +"' AND Ngay_Hd_Bd <= '"+ Convert.ToDateTime(this.dteNgay_Ct.Text).ToString("dd/MM/yyyy")  +
                    "' AND (Ngay_Hd_Kt >= '" + Convert.ToDateTime(this.dteNgay_Ct.Text).ToString("dd/MM/yyyy") + "' OR Ngay_Hd_Kt = '01/01/1900') " +
                    " AND (So_Hd NOT LIKE '%_PL%' OR So_Hd IN (SELECT String FROM dbo.fn_Split('"+ strMaHdNot + "')))";

            DataRow drLookup = Lookup.ShowLookup("MA_HD", strValue, bRequire, strKeyFilter, strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Hd.Text = string.Empty;
                lbtTen_Hd.Text = string.Empty;
            }
            else
            {
                txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
                lbtTen_Hd.Text = Voucher.GetTenHd(txtMa_Hd.Text);

                if (drLookup["Ma_CTrinh"].ToString() != "")
                    txtMa_CTrinh.Text = drLookup["Ma_CTrinh"].ToString();

                if (drLookup["So_QD"].ToString() != "")
                    txtSo_QD.Text = drLookup["So_QD"].ToString();

                if (txtMa_Hd.bTextChange)
                {
                    txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                    DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", (string)drLookup["Ma_Dt"]);
                    if (drDmDt != null)
                    {
                        lbtTen_Dt.Text = (string)drDmDt["Ten_Dt"];
                        if ((string)drDmDt["Ong_Ba"] != string.Empty)
                            txtOng_Ba.Text = (string)drDmDt["Ong_Ba"];
                        else
                            txtOng_Ba.Text = (string)drDmDt["Ten_Dt"];

                        txtDia_Chi.Text = (string)drDmDt["Dia_Chi"];

                    }
                }
            }
            //lbtNotice.Text = GetDuCuoi(txtMa_Dt.Text, txtMa_Hd.Text, "131");
            this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
        }
        void txtMa_Xe_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Xe.Text.Trim();
            bool bRequire = false;

            //DataRow drLookup = Lookup.ShowLookup("Ma_Xe", strValue, bRequire, "Ma_Bp = 'PKD'");
            DataRow drLookup = Lookup.ShowLookup("So_Xe_PKD", strValue, bRequire, "");
            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Xe.Text = string.Empty;
                lbtTen_Xe.Text = string.Empty;
            }
            else
            {
                txtMa_Xe.Text = drLookup["So_Xe"].ToString();
                lbtTen_Xe.Text = drLookup["So_Xe_PKD"].ToString();
            }
        }
        void txtID_Dt_Vc_Validating(object sender, CancelEventArgs e)
        {
            txtID_Dt_Vc.Text = Voucher.GetFormatID(txtID_Dt_Vc.Text);
            Hashtable HT = new Hashtable();
            HT.Add("ID_DT_VC",txtID_Dt_Vc.Text);
            HT.Add("NGAY_CT",dteNgay_Ct.Text);
            DataTable dtID = SQLExec.ExecuteReturnDt("sp_GetTenDtVcsoxe",HT,CommandType.StoredProcedure);
            if(dtID.Rows.Count > 0)
            {
                txtTen_Dt_Vc.Text = dtID.Rows[0]["Ten_Dt_Vc"].ToString();
                if (dtEditCt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtEditCt.Rows)
                    {
                        dr["So_Xe"] = dtID.Rows[0]["So_Xe"];
                        dr["So_Xa_Lan_Tau"] = dtID.Rows[0]["So_Xa_Lan_Tau"];
                    }
                }
            }
        }
        void txtMa_Dt_Vc_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_Vc.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_Vc.Text = string.Empty;
                lbtTen_Dt_Vc.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_Vc.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt_Vc.Text = drLookup["Ten_Dt"].ToString();
            }
        }
        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

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
                //txtTen_Dt_Vc.Text = drLookup["Ten_Dt_Vc"].ToString() == string.Empty ? "" : drLookup["Ten_Dt_Vc"].ToString();
                if (txtMa_Dt.Text != (string)drEditPh["Ma_Dt"])
                {
                    txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();

                    if (drLookup["Dia_Chi"].ToString() != string.Empty)
                        txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();

                    if (drLookup["Ma_Kv"].ToString() != string.Empty)
                        txtMa_Kv.Text = drLookup["Ma_Kv"].ToString();

                    if (drLookup["Ma_Dt_CbNv"].ToString() != string.Empty)
                        txtMa_Dt_CbNv.Text = drLookup["Ma_Dt_CbNv"].ToString();
                }

            }

            txtMa_Hd.bUseAutoDropDown = true;
            txtMa_Hd.strLookupKeyFilter = "Ma_Dt = '" + txtMa_Dt.Text.ToString() + "'";

            Voucher.Update_Detail(this, "Ma_Dt");
        }
        void txtPort_Giao_Validating(object sender, CancelEventArgs e)
        {
            string strValue =  txtPort_Giao.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "PORT_GIAO");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'PORT_GIAO'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtPort_Giao.Text = string.Empty;
               lbtPort_Giao.Text = string.Empty;
            }
            else
            {
                txtPort_Giao.Text = drLookup["Type_ID"].ToString();
                lbtPort_Giao.Text = drLookup["Type_Name"].ToString();
            }
        }
        void txtHt_Gn_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtHt_Gn.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "HT_GN");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'HT_GN'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtHt_Gn.Text = string.Empty;
                lbtHt_Gn.Text = string.Empty;
            }
            else
            {
                txtHt_Gn.Text = drLookup["Type_ID"].ToString();
                lbtHt_Gn.Text = drLookup["Type_Name"].ToString();
            }
        }

       

        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv.Text = string.Empty;
                lbtTen_Xe.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Xe.Text = drLookup["Ten_Dt"].ToString();
            }
        }

        void txtMa_Kv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Kv.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Kv", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Kv.Text = string.Empty;
                lbtTen_Kv.Text = string.Empty;
            }
            else
            {
                txtMa_Kv.Text = drLookup["Ma_Kv"].ToString();
                lbtTen_Kv.Text = drLookup["Ten_Kv"].ToString();
            }
        }

        void txtMa_Thue_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Thue.Text;
            bool bRequire = false;

            string strMa_Thue_Old = drEditPh["Ma_Thue"] == DBNull.Value ? string.Empty : (string)drEditPh["Ma_Thue"];

            DataRow drLookup = Lookup.ShowLookup("Ma_Thue", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {

                numTTien_Nt3.ReadOnly = true;
                numTTien3.ReadOnly = true;

                numTTien_Nt3.TabStop = false;
                numTTien3.TabStop = false;

                txtMa_Thue.Text = string.Empty;
                this.drEditPh["Thue_Gtgt"] = 0;
            }
            else
            {
                numTTien_Nt3.ReadOnly = false;
                numTTien3.ReadOnly = false;

                numTTien_Nt3.TabStop = true;
                numTTien3.TabStop = true;

                string strMa_Thue = (string)drLookup["Ma_Thue"];
                txtMa_Thue.Text = strMa_Thue;


                //Đưa Thue_Gtgt vào drEditPh vào để cập nhật xuống Detail
                this.drEditPh["Thue_Gtgt"] = drLookup["Thue_Suat"];


                string strMa_Dt = txtMa_Dt.Text;
                DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", strMa_Dt);
            }

            Voucher.Update_Detail(this, "Ma_Thue, Thue_Gtgt");
            Voucher.Calc_Thue_Vat_All(this);
        }
        void txtSo_LXH_Tt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_LXH_Tt.Text;
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Stt", strValue, bRequire, "Ma_Ct = 'LXH'");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup != null)
            {

               txtSo_LXH_Tt.Text = (string)drLookup["So_Ct"];
            }
        }
        void frmEditCtTien_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F8:
                    Voucher.DeleteRow(this, dgvEditCt1);
                    break;

                case Keys.F4:

                    if (tabControl1.SelectedIndex == 0)
                        tabControl1.SelectedIndex = 1;
                    else
                        tabControl1.SelectedIndex = 0;
                    break;
                //case Keys.F9:
                //    if (drEditPh["Ma_Ct"].ToString() == "SO")
                //    {
                //        this.CheckInventory();
                //        if (this.frmCheckInventory != null && this.frmCheckInventory.Visible)
                //            this.frmCheckInventory.Focus();

                //    }break;

                case Keys.Up:

                    if (this.dgvEditCt1.Focused && this.dgvEditCt1.bIsCurrentFirstRow)
                        this.SelectNextControl(dgvEditCt1, false, true, true, true);
                    
                    else if (this.dgvEditCt2.Focused && this.dgvEditCt2.bIsCurrentFirstRow)
                        this.SelectNextControl(dgvEditCt2, false, true, true, true);
                    
                        break;
            }

            if (!this.dgvEditCt1.Focused)
                this.dgvEditCt1.ClearSelection();
        }

        void numTTien_Validated(object sender, EventArgs e)
        {
            TTien_Valid();
        }
        void numTTien_Nt_Validated(object sender, EventArgs e)
        {
            TTien_Valid();
        }
        void numTTien3_Validated(object sender, EventArgs e)
        {
            TTien_Valid();
        }
        void numTTien_Nt3_Validated(object sender, EventArgs e)
        {
            TTien_Valid();
        }

                                    #endregion

        #region DataGridViewEvent

        //Xu ly Notice
        void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            if (dgvEditCt.CurrentCell == null)
                return;

            if (this.ActiveControl != dgvEditCt)
                return;

            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "MA_VT,SO_LUONG9"))
            {
               
            }
           
            this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
        }

        //Cai dat Lookup
        void dgvEditCt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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


            //Xu ly Lookup
            if (this.ActiveControl == null)
                return;

            //e.Cancel = true;

            if (Common.Inlist(strColumnName, "SO_XE"))
            {

                string strSo_Xe = Voucher.GetFormatSoXe(dgvCell.FormattedValue.ToString().Trim());
                dgvEditCt.CancelEdit();
                dgvCell.Value = strSo_Xe;
            }
            else if (Common.Inlist(strColumnName, "SO_XA_LAN_TAU"))
            {
                string strSo_Xa_Lan = Voucher.GetFormatSoXaLan(dgvCell.FormattedValue.ToString().Trim());
                dgvEditCt.CancelEdit();
                dgvCell.Value = strSo_Xa_Lan;
            }

            if (Common.Inlist(strColumnName, "SO_LUONG_CAY_LE, SO_LUONG9"))
            {

                if ((string)drCurrent["Ma_Vt"] != string.Empty && (string)drCurrent["Ma_Ct"] == "SO" && (string)drCurrent["Ma_Kho"] == "04TP")
                {
                    //Hashtable ht = new Hashtable();

                    //ht["NGAY_CT"] = drCurrent["Ngay_Ct"];
                    //ht["MA_KHO"] = drCurrent["Ma_Kho"];
                    //ht["MA_VT"] = drCurrent["Ma_Vt"];

                    //if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                    //    ht["SL_SO"] = drCurrent["SO_LUONG9"];

                    //ht["MA_DVCS"] = drCurrent["Ma_DvCs"];
                    //ht["STT"] = drCurrent["Stt"];

                    //DataTable dt = SQLExec.ExecuteReturnDt("sp_CheckInventory_KD", ht, CommandType.StoredProcedure);
                   

                    //double dbTon_Cuoi_CL = Convert.ToDouble(dt.Rows[0]["Ton_Cuoi_CL"]);
                    //double dbSo_Luong_DH = Convert.ToDouble(drCurrent["So_Luong9"]);

                    //if (dbTon_Cuoi_CL < dbSo_Luong_DH && (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy))
                    //{
                    //    string strMsg = string.Empty;

                    //    if (Element.sysLanguage == enuLanguageType.Vietnamese)
                    //        strMsg = "Số lượng đặt: " + dbSo_Luong_DH.ToString("N2") + " > số lượng tồn còn lại: " + dbTon_Cuoi_CL.ToString("N2");
                    //    else
                    //        strMsg = "Out quantity: " + dbSo_Luong_DH.ToString("N2") + " > closing inventory quantity: " + dbTon_Cuoi_CL.ToString("N2");

                    //    Common.MsgCancel(strMsg);
                    //}
                    
                }
               
                //if ((string)drCurrent["Ma_Vt"] != string.Empty && (string)drCurrent["Ma_Ct"] == "SOCP" && drCurrent["Ma_Kho"].ToString().StartsWith("05"))
                //{

                //    double dbSo_Luong = Convert.ToDouble(drCurrent["So_Luong"]);
                //    double dbTon_Cuoi = 0;
                //    Voucher.GetTonCuoi_KKV(drCurrent, ref dbTon_Cuoi);

                //    if (dbSo_Luong > dbTon_Cuoi)
                //    {
                //        string strMsg = string.Empty;

                //        if (Element.sysLanguage == enuLanguageType.Vietnamese)
                //            strMsg = "Số lượng xuất: " + dbSo_Luong.ToString("N2") + " > số lượng tồn: " + dbTon_Cuoi.ToString("N2");
                //        else
                //            strMsg = "Out quantity: " + dbSo_Luong.ToString("N2") + " > closing inventory quantity: " + dbTon_Cuoi.ToString("N2");

                //        Common.MsgCancel(strMsg);

                //    }

                    //if (dbTon_Cuoi != 0)
                    //{
                    //    numTon_Cuoi.Text = dbTon_Cuoi.ToString();
                    //    numSo_Luong_SO_CL.Text = dbSo_Luong.ToString();
                    //    numTon_Cuoi_CL.Text = (dbTon_Cuoi - dbSo_Luong).ToString();
                    //}

                //}
                //else if ((string)drCurrent["Ma_Vt"] != string.Empty && (string)drCurrent["Ma_Ct"] == "SOCP" && Common.InlistLike(drCurrent["Ma_Kho"].ToString(), "551,KCP"))
                //{

                //    double dbSo_Luong = Convert.ToDouble(drCurrent["So_Luong"]);
                //    double dbTon_Cuoi = 0;
                //    Voucher.GetTonCuoi_KGCP(drCurrent, ref dbTon_Cuoi);

                //    if (dbSo_Luong > dbTon_Cuoi)
                //    {
                //        string strMsg = string.Empty;

                //        if (Element.sysLanguage == enuLanguageType.Vietnamese)
                //            strMsg = "Số lượng xuất: " + dbSo_Luong.ToString("N2") + " > số lượng tồn: " + dbTon_Cuoi.ToString("N2");
                //        else
                //            strMsg = "Out quantity: " + dbSo_Luong.ToString("N2") + " > closing inventory quantity: " + dbTon_Cuoi.ToString("N2");

                //        Common.MsgCancel(strMsg);

                //    }

                    //if (dbTon_Cuoi != 0)
                    //{
                    //    numTon_Cuoi.Text = dbTon_Cuoi.ToString();
                    //    numSo_Luong_SO_CL.Text = dbSo_Luong.ToString();
                    //    numTon_Cuoi_CL.Text = (dbTon_Cuoi - dbSo_Luong).ToString();
                    //}

                //}
                //else if ((string)drCurrent["Ma_Vt"] != string.Empty && (string)drCurrent["Ma_Ct"] == "SOCP" && drCurrent["Ma_Kho"].ToString().StartsWith("08"))
                //{
                //    double dbSo_Luong = Convert.ToDouble(drCurrent["So_Luong"]);
                //    double dbTon_Cuoi = 0;
                //    Voucher.GetTonCuoi_CP(drCurrent, ref dbTon_Cuoi);

                //    if (dbSo_Luong > dbTon_Cuoi)
                //    {
                //        string strMsg = string.Empty;

                //        if (Element.sysLanguage == enuLanguageType.Vietnamese)
                //            strMsg = "Số lượng xuất: " + dbSo_Luong.ToString("N2") + " > số lượng tồn: " + dbTon_Cuoi.ToString("N2");
                //        else
                //            strMsg = "Out quantity: " + dbSo_Luong.ToString("N2") + " > closing inventory quantity: " + dbTon_Cuoi.ToString("N2");

                //        Common.MsgCancel(strMsg);
                //    }
                    //if (dbTon_Cuoi != 0)
                    //{
                    //    drCurrent["So_Luong_Ton"] = dbTon_Cuoi;
                    //    numTon_Cuoi.Text = dbTon_Cuoi.ToString();
                    //    numSo_Luong_SO_CL.Text = dbSo_Luong.ToString();
                    //    numTon_Cuoi_CL.Text = (dbTon_Cuoi - dbSo_Luong).ToString();
                    //}
                //}
            }

            if (Common.Inlist(strColumnName, "SO_XA_LAN_TAU"))
            {
                string strSo_Xa_Lan_Tau = dgvCell.FormattedValue.ToString().Trim();
                strSo_Xa_Lan_Tau = strSo_Xa_Lan_Tau.ToUpper();
                dgvEditCt.CancelEdit();
                dgvCell.Value = strSo_Xa_Lan_Tau;
            }

            if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                //DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
                //string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

                bool bLookup = true;

                if (strColumnName == "MA_VT")
                    bLookup = dgvLookupMa_Vt(ref dgvCell);
                else if (strColumnName == "MA_KHO")
                    bLookup = dgvLookupMa_Kho(ref dgvCell);
                else if (strColumnName == "GIA_DCHINH")
                    bLookup = dgvLookupGia_DChinh(ref dgvCell);


                if (bLookup == false)
                    e.Cancel = true;
            }
            else
                dgvEditCt.CancelEdit();
        }

        //Cai dat cac ham tinh toan
        void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            dgvVoucher dgvEditCt = (dgvVoucher)sender;
            if (this.ActiveControl != dgvEditCt)
                return;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            
            if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN"))
            {

                

                //int numNum_Bars = int.Parse(DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Num_Bars", drCurrent["Ma_Vt"].ToString().Trim()));
                //double numBarWeight = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "BarWeight", drCurrent["Ma_Vt"].ToString().Trim()));
                //double numLength = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Length", drCurrent["Ma_Vt"].ToString().Trim()));
                //double numBarem = Math.Round(numBarWeight * numLength, 2);
                //if ((numBarem * numNum_Bars) != 0)
                //{
                //    int numSO_LUONG_CAY = Convert.ToInt32(Convert.ToDouble(drCurrent["SO_LUONG9"].ToString()) / numBarem);
                //    drCurrent["SO_LUONG_BO"] = numSO_LUONG_CAY / numNum_Bars;
                //    drCurrent["SO_LUONG_CAY_LE"] = numSO_LUONG_CAY % numNum_Bars;
                //}
                Voucher.Calc_So_Luong(drCurrent, this);
                Voucher.Update_TTien(this);
                Voucher.Calc_Thue_Vat_All(this);
                Voucher.Adjust_TThue_Vat(this);
            }
            else if (Common.Inlist(strColumnName, "SO_LUONG_CAY"))
            {
                int numSO_LUONG_CAY = int.Parse(drCurrent["SO_LUONG_CAY"].ToString());
                if (numSO_LUONG_CAY != 0)
                {
                    int numNum_Bars = int.Parse(DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Num_Bars", drCurrent["Ma_Vt"].ToString().Trim()));
                    if (numNum_Bars != 0)
                    {
                        drCurrent["SO_LUONG_BO"] = numSO_LUONG_CAY / numNum_Bars;
                        drCurrent["SO_LUONG_CAY_LE"] = numSO_LUONG_CAY % numNum_Bars;
                    }
                }
            }

            else if (Common.Inlist(strColumnName, "SO_LUONG_BO,SO_LUONG_CAY_LE"))
            {
                string strGrade_ID = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Grade_ID", drCurrent["Ma_Vt"].ToString().Trim());
                int numNum_Bars = int.Parse(DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Num_Bars", drCurrent["Ma_Vt"].ToString().Trim()));
                 string strGrade_ID_XK = Parameters.GetParaValue("MAC_THEP_XK_LIST").ToString();
                 if (drCurrent["Ma_Vt"].ToString().StartsWith("BD") && !Common.Inlist(strGrade_ID, strGrade_ID_XK) && drCurrent["Ma_Vt"].ToString().Substring(6, 4) != "0000")
                 {
                     Hashtable ht = new Hashtable();
                     ht.Add("MA_VT", drCurrent["Ma_Vt"]);
                     ht.Add("SO_BO", drCurrent["So_Luong_Bo"]);
                     ht.Add("SO_CAY_LE", drCurrent["So_Luong_Cay_Le"]);
                     drCurrent["So_Luong"] = drCurrent["So_Luong9"] = SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBaremBo(@Ma_Vt,@So_Bo,@So_Cay_Le)", ht, CommandType.Text);
                     drCurrent["SO_LUONG_CAY"] = (int.Parse(drCurrent["SO_LUONG_BO"].ToString()) * numNum_Bars + int.Parse(drCurrent["SO_LUONG_CAY_LE"].ToString()));
                 }
                 else
                 {
                     double numBarWeight = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "BarWeight", drCurrent["Ma_Vt"].ToString().Trim()));
                     double numLength = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Length", drCurrent["Ma_Vt"].ToString().Trim()));
                     // Bằng thêm phần barem
                     double numBarem = Math.Round((numBarWeight * numLength), 2);
                     if (numBarem * numNum_Bars != 0)
                     {
                         drCurrent["SO_LUONG9"] = Math.Round((int.Parse(drCurrent["SO_LUONG_BO"].ToString()) * numNum_Bars * numBarem + int.Parse(drCurrent["SO_LUONG_CAY_LE"].ToString()) * numBarem), 0);
                         //drCurrent["SO_LUONG9"] = SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBaremBo()");
                         drCurrent["SO_LUONG_CAY"] = (int.Parse(drCurrent["SO_LUONG_BO"].ToString()) * numNum_Bars + int.Parse(drCurrent["SO_LUONG_CAY_LE"].ToString()));
                     }
                 }
                //}
                ////kiểm tra số lượng cây
                if ((string)drCurrent["Ma_Ct"] == "LXH" && Convert.ToDouble(drCurrent["SO_LUONG9"]) > Convert.ToDouble(drCurrent["SO_LUONG_BILL"])
                        && (string)drCurrent["Stt_Org"] != string.Empty)
                {
                    Common.MsgOk("Số lượng nhập vượt quá số lượng được còn lại " + drCurrent["SO_LUONG_BILL"] + ". Vui lòng nhập lại không được vượt lệnh");
                    if (drCurrent["Ma_Vt"].ToString().StartsWith("BD"))
                    {

                        DataTable dtQuyDoi = SQLExec.ExecuteReturnDt("select * from [dbo].[fn_QuyDoiBarem]('" + drCurrent["Ma_Vt"].ToString() + "', " +
                            "" + Convert.ToDouble(drCurrent["SO_LUONG_BILL"]) + ")");
                        drCurrent["SO_LUONG_BO"] = Convert.ToDouble(dtQuyDoi.Rows[0]["SO_LUONG_BO"]);
                        drCurrent["SO_LUONG_CAY_LE"] = Convert.ToDouble(dtQuyDoi.Rows[0]["SO_LUONG_CAY_LE"]);
                        drCurrent["SO_LUONG_CAY"] = (int.Parse(drCurrent["SO_LUONG_BO"].ToString()) * numNum_Bars + int.Parse(drCurrent["SO_LUONG_CAY_LE"].ToString()));
                        drCurrent["SO_LUONG9"] = Convert.ToDouble(drCurrent["SO_LUONG_BILL"]);
                    }
                }
              

                Voucher.Calc_So_Luong(drCurrent, this);
                Voucher.Update_TTien(this);
                Voucher.Calc_Thue_Vat_All(this);
                Voucher.Adjust_TThue_Vat(this);
            }
            else if (Common.Inlist(strColumnName, "GIA_DCHINH"))
            {
                this.Calc_CsGia();
            }

            else if (Common.Inlist(strColumnName, "TIEN"))
            {
                Voucher.Calc_Tien(drCurrent, this);
                Voucher.Update_TTien(this);
            }

            bdsEditCt.EndEdit();//Cap nhat lai DataSource     


        }

        void dgvEditCt1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            if (dgvEditCt.CurrentCell == null)
                return;

            if (this.ActiveControl != dgvEditCt)
                return;

            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "MA_VT")
                this.bMa_Vt_Changed = true;



        }

        //Xử lý Dvt
        void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                if (dgvEditCt1.CurrentCell.OwningColumn.DataPropertyName == "DVT")
                {
                    drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                    string strMa_Vt = (string)drCurrent["Ma_Vt"];
                    string strDvt_Old = (string)drCurrent["Dvt"];
                    string strDvt_Chuan = string.Empty;

                    DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", strMa_Vt);
                    strDvt_Chuan = (string)drDmVt["Dvt"];

                    string inputMask = (string)drDmVt["Dvt"];

                    for (int i = 1; i <= 3; i++)
                        inputMask += (string)drDmVt["Dvt" + i] == string.Empty ? string.Empty : "," + (string)drDmVt["Dvt" + i];

                    if (inputMask != string.Empty)
                        inputMask += "," + inputMask;
                    if (inputMask == null || inputMask == string.Empty)
                        return;

                    string[] strArrInputMask = inputMask.Split(',');
                    for (int i = 0; i <= strArrInputMask.Length - 1; i++)
                        if (strArrInputMask[i] == strDvt_Old)
                        {
                            drCurrent["Dvt"] = strArrInputMask[i + 1];
                            break;
                        }

                    if ((string)drCurrent["Dvt"] == strDvt_Chuan)
                        drCurrent["He_So9"] = 1;
                    else
                        for (int i = 1; i <= 3; i++)
                            if ((string)drDmVt["Dvt" + i] == (string)drCurrent["Dvt"])
                                drCurrent["He_So9"] = drDmVt["He_So" + i];

                    Voucher.Calc_So_Luong(drCurrent, this);
                }
        }


        void dgvEditCt1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;
            if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
                return;

            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (bdsEditCt.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            //string strColumn_Name = dgvEditCt1.Columns[e.ColumnIndex].DataPropertyName;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumn_Name = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumn_Name, "PRINT_KG,PRINT_BO,PRINT_CAY"))
            {

                if (strColumn_Name == "PRINT_KG")
                {
                    drCurrent["PRINT_KG"] = true;
                    drCurrent["PRINT_BO"] = drCurrent["PRINT_CAY"] = false;
                }
                else if (strColumn_Name == "PRINT_BO")
                {
                    drCurrent["PRINT_BO"] = drCurrent["PRINT_CAY"] = true;
                    drCurrent["PRINT_KG"] = false;
                }
                else if (strColumn_Name == "PRINT_CAY")
                {
                    drCurrent["PRINT_CAY"] = drCurrent["PRINT_BO"] = true;
                    drCurrent["PRINT_KG"] = false;
                }

            }
        }
        #endregion

        #region DataGridViewLookup

        private bool dgvLookupMa_Vt(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                string strMa_Vt_Old = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];
                string strMa_Vt = (string)drLookup["Ma_Vt"];

                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Vt"].ToString();
                dgvCell.Tag = drLookup["Ten_Vt"].ToString();

                //La vat tu dich vu                
                if ((string)drLookup["Loai_Vt"] == "0")
                {
                    if ((string)drCurrent["Ten_Vt"] == string.Empty)
                        drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

                    drCurrent["Dvt"] = drLookup["Dvt"];
                }
                else
                {
                    drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

                    if (strMa_Vt != strMa_Vt_Old)
                    {
                        drCurrent["Dvt"] = drLookup["Dvt"];
                        drCurrent["He_So9"] = 1;

                    }
                    else
                    {
                        if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
                            drCurrent["Dvt"] = drLookup["Dvt"];
                    }
                }
                drCurrent["So_Qd"] = txtSo_QD.Text.Trim();
                drCurrent["HT_TT"] = txtHT_TT.Text.Trim();
                drCurrent["PT_VC"] = txtPt_Vc.Text.Trim();
                //drCurrent["Ma_Kho"] = txtMa_Kho.Text.Trim();


                if (drCurrent.HasVersion(DataRowVersion.Original))
                    strMa_Vt_Old = drCurrent["Ma_Vt", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt", DataRowVersion.Original];
                else
                    strMa_Vt_Old = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];

                if (strMa_Vt != strMa_Vt_Old)
                {
                    drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];
                    drCurrent["Dvt"] = drLookup["Dvt"];
                    drCurrent["He_So9"] = 1;

                    this.Calc_CsGia();
                }
            }
            return true;
        }

        private bool dgvLookupMa_Kho(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Kho"].ToString();
                dgvCell.Tag = drLookup["Ten_Kho"].ToString();
            }
            return true;
        }


        private bool dgvLookupGia_DChinh(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            string strFilter = "Type='GIA_DCHINH'";

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "GIA_DCHINH");
            DataRow drLookup = Lookup.ShowLookup("GIA_DCHINH", strValue, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Type_ID"].ToString();
                dgvCell.Tag = drLookup["Type_Name"].ToString();
            }
            return true;
        }
        #endregion

        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dgvEditCt1.ClearSelection(); //Chi co tac dung sau khi show form

            cboSaveOption.Items.Clear();
            cboSaveOption.Items.AddRange(new string[] { "1-Lưu & Nhập tiếp", "2-Lưu & Đóng lại", "3-Lưu - In & Nhập tiếp", "4-Lưu - In & Đóng lại", "5-In & Nhập tiếp", "6-In & Đóng lại" });

        
        

            if (enuNew_Edit == enuEdit.New)
            {
                
            }

            if (enuNew_Edit == enuEdit.Edit)
            {
                cboSaveOption.SelectedIndex = 1;


            }
            else
            {
                if (Common.GetBufferValue("Voucher_Save_Option") != null && Common.GetBufferValue("Voucher_Save_Option").ToString().Length > 0)
                    cboSaveOption.SelectedIndex = int.Parse(Common.GetBufferValue("Voucher_Save_Option").Substring(0, 1)) - 1;
                else
                    cboSaveOption.SelectedIndex = 0;
            }
            if(DataTool.SQLCheckExist("R80PH",new string[]{"Stt","Duyet_PKD"}, new object []{drEditPh["Stt"], true}))
            {
                this.btgAccept.btAccept.Enabled = false;
                return;
            }
            if (this.enuNew_Edit == enuEdit.Edit)
            {
                string strUser_Admin = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID FROM R00MEMBERGROUP WHERE Member_Group_ID = 'ADMINS' AND Member_ID = '" + Element.sysUser_Id + "'") + ",";

                if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
                {
                    this.dteNgay_Ct.Enabled = false;
                    this.btgAccept.btAccept.Enabled = false;
                }
                else if (strUser_Admin != ",")
                {
                    this.btgAccept.btAccept.Enabled = true;
                    return;
                }
                //if (strMa_Ct == "LXH" && (bool)drEditPh["Duyet_Huy"] == false)
                //{
                //    Hashtable htC = new Hashtable();
                //    htC.Add("MA_DT", txtMa_Dt.Text);
                //    htC.Add("MA_DT", drEdit["So_Xe"]);
                //    htC.Add("NGAY_CT", dteNgay_Ct.Text);
                //    if()
                //}
                if (!Element.sysIs_Admin)
                {
                    string strCreate_User = (string)drEditPh["Create_Log"];

                    if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                    {
                        string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                        if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
                        {
                            if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                            {
                                this.btgAccept.btAccept.Enabled = false;
                                return;
                            }
                        }
                    }
                }
            }
        }






    } 	
	
}
