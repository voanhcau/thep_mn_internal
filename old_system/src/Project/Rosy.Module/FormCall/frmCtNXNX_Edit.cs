using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.Odbc;
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

namespace RosyModule
{
    public partial class frmCtNXNX_Edit : frmVoucher_Edit
    {
        private string strTk_NoTmp = string.Empty;
        private string strTk_CoTmp = string.Empty;
        private string strModule = "05";
        private string strMsg1 = string.Empty;
        private string strMa_Vt_List;

        #region Contructor

        public frmCtNXNX_Edit()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);
            this.dteNgay_Ct.TextChanged += new EventHandler(dteNgay_Ct_TextChanged);
            this.txtSo_Ct.TextChanged += new EventHandler(txtSo_Ct_TextChanged);
            this.btImportExcel.Click += new EventHandler(btnImportExcel_Click);

            this.btHanTt.Click += new EventHandler(btHanTt_Click);
            
            this.btInherit.Click += new EventHandler(btInherit_Click);


            
            txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);
            txtMa_KhoN.Validating += new CancelEventHandler(txtMa_KhoN_Validating);
            txtMa_VtN.Validating += new CancelEventHandler(txtMa_VtN_Validating);
            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_CbNv_Validating);
          
            txtSo_QD.Validating += new CancelEventHandler(txtSo_QD_Validating);
            txtMa_CTrinh.Validating += new CancelEventHandler(txtMa_CTrinh_Validating);
            txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
            txtSo_Ct.Validating += new CancelEventHandler(txtSo_Ct_Validating);
            txtMa_Dt_Vc.Validating += new CancelEventHandler(txtMa_Dt_Vc_Validating);

            dteNgay_Ct.Validating += new CancelEventHandler(dteNgay_Ct_Validating);
            txtMa_Tte.Validating += new CancelEventHandler(txtMa_Tte_Validating);
            numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);

            dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
            dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
            dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
            dgvEditCt1.CellLeave += new DataGridViewCellEventHandler(dgvEditCt_CellLeave);
            dgvEditCt1.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);

            dgvEditCt2.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
            dgvEditCt2.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
            dgvEditCt2.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);

           
        }

       

        public void Load(enuEdit enuNew_Edit, DataRow drEdit, DataTable dtDNX, string strMa_Ct)
        {
            this.drEdit = drEdit;
            this.dsVoucher = dsVoucher;

            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            this.strMa_Ct = strMa_Ct;// "PX";
            this.drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", this.strMa_Ct);
            this.Object_ID = strMa_Ct;
            


            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            { 
                this.strStt = Common.GetNewStt(strModule, true);

            }
            else
                this.strStt = drEdit["Stt"].ToString();

            this.Build();
            this.FillData();
            //gán số seri de tinh so_ct
            

            this.Init_Ct();

            this.Ma_Tte_Valid();
            this.BindingLanguage();

            Voucher.InheritVoucher_SetData(this, dtDNX);
            //

            txtMa_Ct.Text = strMa_Ct;// "PX";
            string strTk_No = ""; string strTk_Co = "";

            if (dtDNX.Rows[0]["Ma_Kho"].ToString() == "051NT")
            {                
                if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "HD"))
                    txtMa_Nvu.Text = "PX51";
                else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "KG"))
                { txtMa_Nvu.Text = "AP51"; txtMa_KhoN.Text = dtDNX.Rows[0]["Ma_KhoN"].ToString(); }
                else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "GK"))
                    txtMa_Nvu.Text = "PXGK06";
                
            }
            else if (dtDNX.Rows[0]["Ma_Kho"].ToString() == "051DN")
                txtMa_Nvu.Text = "PX52";
            else if (dtDNX.Rows[0]["Ma_Kho"].ToString() == "051P2")
            {
                 if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "HD"))
                    txtMa_Nvu.Text = "PX55";
                 else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "GK"))
                    txtMa_Nvu.Text = "PXGK02";
            }
            else if (dtDNX.Rows[0]["Ma_Kho"].ToString() == "051CT")
            {
                if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "HD"))
                    txtMa_Nvu.Text = "PX61";
                else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "KG"))
                { txtMa_Nvu.Text = "AP61"; txtMa_KhoN.Text = dtDNX.Rows[0]["Ma_KhoN"].ToString(); }
                else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "GK"))
                    txtMa_Nvu.Text = "PXGK04";
            }
            else if (dtDNX.Rows[0]["Ma_Kho"].ToString() == "051D2")
            {
                if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "HD"))
                    txtMa_Nvu.Text = "PX53";
                else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "KG"))
                { txtMa_Nvu.Text = "AP71"; txtMa_KhoN.Text = dtDNX.Rows[0]["Ma_KhoN"].ToString(); }
                else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "GK"))
                    txtMa_Nvu.Text = "PXGK03";
            }
            
            else if (Common.InlistLike(dtDNX.Rows[0]["Ma_Kho"].ToString() ,"052TMN,058"))
            {
                if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "HD"))
                    txtMa_Nvu.Text = "PX56";
                else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "DD"))
                { txtMa_Nvu.Text = "AP22"; txtMa_KhoN.Text = dtDNX.Rows[0]["Ma_KhoN"].ToString(); strTk_No = "15512"; strTk_Co = "15512"; }
                else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "KG"))
                { txtMa_Nvu.Text = "AP22"; txtMa_KhoN.Text = dtDNX.Rows[0]["Ma_KhoN"].ToString(); strTk_No = "1571"; strTk_Co = "15512"; }
                else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "GK"))
                { txtMa_Nvu.Text = "PXGK01"; }

            }
            else if (dtDNX.Rows[0]["Ma_Kho"].ToString() == "055POM1")
            {
                if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "HD"))
                { txtMa_Nvu.Text = "PX25"; }
                else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "DD"))
                { txtMa_Nvu.Text = "AP22"; txtMa_KhoN.Text = dtDNX.Rows[0]["Ma_KhoN"].ToString(); strTk_No = "15512"; strTk_Co = "15512"; }
                else if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "KG"))
                { txtMa_Nvu.Text = "AP22"; txtMa_KhoN.Text = dtDNX.Rows[0]["Ma_KhoN"].ToString(); strTk_No = "1571"; strTk_Co = "15512"; }
                else if(Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "GK"))
                { txtMa_Nvu.Text = "PXGK05"; }


            }
            else if (Common.InlistLike(dtDNX.Rows[0]["Ma_Kho"].ToString(),"GK_551CT_NB,551CT_NB"))
                txtMa_Nvu.Text = "PXCP_CTNB";
            else if (Common.InlistLike(dtDNX.Rows[0]["Ma_Kho"].ToString(), "GK_551CT_TD,551CT_TD"))
                txtMa_Nvu.Text = "PXCP_CTTD";
          
            else if (Common.InlistLike(dtDNX.Rows[0]["Ma_Kho"].ToString(), "GK_551P2_NB,551P2_NB"))
                txtMa_Nvu.Text = "PXCP_P2NB";
            else if (Common.InlistLike(dtDNX.Rows[0]["Ma_Kho"].ToString(), "GK_551P2_TD,551P2_TD"))
                txtMa_Nvu.Text = "PXCP_P2TD";
            else if (Common.InlistLike(dtDNX.Rows[0]["Ma_Kho"].ToString(), "GK_551D2_NB,551D2_NB"))
                txtMa_Nvu.Text = "PXCP_D2NB";
            else if (Common.InlistLike(dtDNX.Rows[0]["Ma_Kho"].ToString(), "GK_551D2_TD,551D2_TD"))
                txtMa_Nvu.Text = "PXCP_D2TD";

            this.txtMa_Nvu_Validating(null, null);

            if(dtDNX.Rows[0]["Ma_Kho"].ToString()!= "" && strMa_Ct != "PXGK")
            {
                foreach(DataRow dr in dtEditCt.Rows)
                    dr["Ma_Kho"] = dtDNX.Rows[0]["Ma_Kho"].ToString();
            }
            
            txtMa_Tte.Text = "VND";
            numTy_Gia.Value = 1;
            if (Common.InlistLike(dtDNX.Rows[0]["Ht_Gn"].ToString(), "KG") && Common.InlistLike(dtDNX.Rows[0]["Ma_Kho"].ToString(), "052TMN,058"))
            {
                txtMa_Nvu.Text = "AP22";
                txtMa_KhoN.Text = dtDNX.Rows[0]["Ma_KhoN"].ToString();
                numHan_Tt.Value = Convert.ToDouble(dtDNX.Rows[0]["Han_Tt"].ToString());
                dteNgay_Ct0.Text = dteNgay_Ct.Text;
                this.txtSo_Seri0.Text = DataTool.SQLGetNameByCode("R81DMNVU", "Ma_Nvu", "So_Seri0", "AP22");

            }
            else
                this.txtSo_Seri0.Text = DataTool.SQLGetNameByCode("R81DMNVU", "Ma_Nvu", "So_Seri0", txtMa_Nvu.Text);

            if(strTk_No != "" && strTk_Co!= "")
            {
                foreach(DataRow dr in dtEditCt.Rows)
                { dr["Tk_No"] = strTk_No; dr["Tk_Co"] = strTk_Co; }
            }

            this.LoadDicName();


            Voucher.Update_Detail(this);
            Voucher.Update_TTien(this);

            if (!this.Visible)
                this.ShowDialog();
            else
            {
                this.ActiveControl = txtMa_Nvu;
                this.dgvEditCt1.ClearSelection();
            }


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

            if (!Common.Inlist(strMa_Ct, "PX,PXB,PXOX"))
            {
                this.txtMa_Hd.Enabled = false;
                this.txtMa_CTrinh.Enabled = false;
                this.txtSo_QD.Enabled = false;
            }
            
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                this.strStt = Common.GetNewStt(strModule, true);
            else
                this.strStt = drEdit["Stt"].ToString();

            this.Build();
            this.FillData();
            this.Init_Ct();

            Common.ScaterMemvar(this, ref drEditPh);

            txtMa_Tte.bTextChange = false;
            numTy_Gia.bTextChange = false;
            if ((enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy) && strMa_Ct == "PXDC")
            {
                txtSo_Ct0.Text = txtSo_Ct.Text;
                dteNgay_Ct0.Text = dteNgay_Ct.Text;
            }
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

            if (dgvEditCt2.Columns.Contains("So_Luong")) //Người dùng phải nhập vào cột So_Luong9
                dgvEditCt2.Columns["So_Luong"].ReadOnly = true;

            if (dgvEditCt1.Columns.Contains("MA_VT") && Common.Inlist(strMa_Ct, "PNCP,PXCP"))
            {
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = " Ma_Nh_Vt IN ('THEPCANDAI')";
            }
            else
            {
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = " Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%'";
            }

            if ((!Common.CheckPermission("ACCESS_PRICE_PN", enuPermission_Type.Allow_Access) && drDmCt["Nh_Ct"].ToString() == "1") ||
                  ((!Common.CheckPermission("ACCESS_PRICE_PX", enuPermission_Type.Allow_Access) && drDmCt["Nh_Ct"].ToString() == "2")))
            {
                numTTien_Nt.Visible = false;
                if (dgvEditCt1.Columns.Contains("Gia"))
                    dgvEditCt1.Columns["Gia"].Visible = false;

                if (dgvEditCt1.Columns.Contains("Gia_Nt"))
                    dgvEditCt1.Columns["Gia_Nt"].Visible = false;

                if (dgvEditCt1.Columns.Contains("Tien"))
                    dgvEditCt1.Columns["Tien"].Visible = false;

                if (dgvEditCt1.Columns.Contains("Tien_Nt"))
                    dgvEditCt1.Columns["Tien_Nt"].Visible = false;


                if (dgvEditCt1.Columns.Contains("Gia_Nt9"))
                    dgvEditCt1.Columns["Gia_Nt9"].Visible = false;

                if (dgvEditCt1.Columns.Contains("Tien_Nt9"))
                    dgvEditCt1.Columns["Tien_Nt9"].Visible = false;

                if (dgvEditCt2.Columns.Contains("Gia"))
                    dgvEditCt2.Columns["Gia"].Visible = false;

                if (dgvEditCt2.Columns.Contains("Gia_Nt"))
                    dgvEditCt2.Columns["Gia_Nt"].Visible = false;

                if (dgvEditCt2.Columns.Contains("Tien"))
                    dgvEditCt2.Columns["Tien"].Visible = false;

                if (dgvEditCt2.Columns.Contains("Tien_Nt"))
                    dgvEditCt2.Columns["Tien_Nt"].Visible = false;


                if (dgvEditCt2.Columns.Contains("Gia_Nt9"))
                    dgvEditCt2.Columns["Gia_Nt9"].Visible = false;

                if (dgvEditCt2.Columns.Contains("Tien_Nt9"))
                    dgvEditCt2.Columns["Tien_Nt9"].Visible = false;

            }

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

            DataColumn dc = new DataColumn("Deleted", typeof(bool));
            dc.DefaultValue = false;
            dtEditCt.Columns.Add(dc);

            dc = new DataColumn("So_Luong_CL", typeof(double));
            dc.DefaultValue = 0;
            dtEditCt.Columns.Add(dc);

            bdsEditCt.DataSource = dtEditCt;

            dgvEditCt1.DataSource = bdsEditCt;
            dgvEditCt1.ClearSelection();

            dgvEditCt2.DataSource = bdsEditCt;
            dgvEditCt2.ClearSelection();

            if (Voucher.Access_Price_Xuat(dtEditCt, strMa_Ct, dgvEditCt1))
            {
                numTTien.Visible = false;
                numTTien_Nt.Visible = false;
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

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            {
                
                drEditPh["HDDTDaTao"] = false;
                drEditPh["HDDTNguoiTao"] = "";
                drEditPh["HDDTChuyenDoi"] = false;
                drEditPh["HDDTNguoiCD"] = "";
                
                drEditPh["Duyet_Huy"] = false;
                drEditPh["Ghi_Chu_Huy"] = "";
                if (this.enuNew_Edit == enuEdit.New)
                {
                    //Ngầm định 1 số thông tin từ chứng từ cũ
                    if (drEdit != null)
                        Common.CopyDataRow(drEdit, drCurrent, (string)drDmCt["Carry_Header"]);

                    
                    drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;
                    drCurrent["Stt"] = strStt;
                    drCurrent["Stt0"] = 1;
                    drCurrent["Ma_Ct"] = strMa_Ct;
                    drCurrent["Ngay_Ct"] = DateTime.Now; //drEdit["Ngay_Ct"] != DBNull.Value ? drEdit["Ngay_Ct"] : DateTime.Now;

                    drCurrent["Ma_Tte"] = Element.sysMa_Tte;
                    drCurrent["Ty_Gia"] = 1;

                    if (dtEditCt.Columns.Contains("Auto_Cost") && (string)drDmCt["Nh_Ct"] == "2")
                        drCurrent["Auto_Cost"] = true;

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
                    //CT
                    foreach (DataRow drEditCt in dtEditCt.Rows)
                    {
                        if (dtEditCt.Columns.Contains("Stt_Org")) //Bỏ các dữ liệu kế thừa
                        {
                            drEditCt["Stt_Org"] = "";

                        }

                        if (dtEditCt.Columns.Contains("IsDaXuatHD"))
                            drEditCt["IsDaXuatHD"] = false;
                    }
                    //PH
                    if (drEditPh.Table.Columns.Contains("Stt_Org"))
                    {
                        drEditPh["Stt_Org"] = "";
                    }
                }

                dtEditCt.Rows[0]["So_Seri0"] = txtSo_Seri0.Text;
               
                //Tinh so chung tu
                drEditPh["So_Ct"] = drCurrent["So_Ct"] = txtSo_Ct.Text = Voucher.Cong_So_Ct(this);

                if (strMa_Ct == "PXDC")
                { txtSo_Ct0.Text = txtSo_Ct.Text; dteNgay_Ct0.Text = dteNgay_Ct.Text; }

                //Tính So_Ct_Barem
                if (this.strMa_Ct == "PXBR")
                {
                  

                    DateTime dteNgay_Ct1 = Library.StrToDate("1/1/" + ((DateTime)drEditPh["Ngay_Ct"]).Year.ToString()); //+ DateTime.Today.Month.ToString() + "/" 
                    DateTime dteNgay_Ct2 = dteNgay_Ct1.AddYears(1).AddDays(-1); //Khoảng cách trong năm

                    Hashtable htPara = new Hashtable();
                    htPara.Add("TABLENAME", drDmCt["Table_Ph"].ToString());
                    htPara.Add("COLUMNNAME", "So_Ct_Barem");
                    htPara.Add("CURRENTID", drEdit["So_Ct_Barem"].ToString());
                    htPara.Add("KEY", "Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Ma_Ct = '" + this.strMa_Ct + "' AND Ngay_Ct BETWEEN '" + Library.DateToStr(dteNgay_Ct1) + "' AND '" + Library.DateToStr(dteNgay_Ct2) + "'");
                    htPara.Add("PREFIXLEN", 0);
                    htPara.Add("SUFFIXLEN", 8);

                    drEditPh["So_Ct_Barem"] = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
                }
                
            }
           
            if (enuNew_Edit == enuEdit.Edit && (this.strMa_Ct == "PXBR" || this.strMa_Ct == "PXDC"))
            {
                foreach (DataRow drEditCt in dtEditCt.Rows)
                {
                    if (dtEditCt.Columns.Contains("Stt_Org")) //Bỏ các dữ liệu kế thừa
                    {
                        if ((string)drEditCt["Stt_Org"] != "")
                        {
                            if (!Common.CheckPermission("IS_EDIT_PX", enuPermission_Type.Allow_Access))
                            {
                                LockControl();

                                foreach (DataGridViewColumn dgvc in dgvEditCt1.Columns)
                                    dgvc.ReadOnly = true;
                                
                                break;
                            }
                        }
                    }
                }
            }

            //kiểm tra nếu ko phải user PKTTC 
            if (!Element.sysIs_Admin)
            {
                if (SQLExec.ExecuteReturnValue("SELECT Member_Group_ID from R00MEMBERGROUP where Member_ID = '" + Element.sysUser_Id + "' AND Member_Group_ID not in ('TDVHC','TDVSX')").ToString() != "PKT")
                {
                    if (dgvEditCt1.Columns.Contains("Auto_Cost") && (string)drDmCt["Nh_Ct"] == "2")
                        dgvEditCt1.Columns["Auto_Cost"].ReadOnly = true;

                    if (dgvEditCt2.Columns.Contains("Auto_Cost") && (string)drDmCt["Nh_Ct"] == "2")
                        dgvEditCt2.Columns["Auto_Cost"].ReadOnly = true;
                }
            }
            Voucher.Update_Header(this);
            Voucher.Update_Stt(this, strModule);


            if (dgvEditCt1.Columns.Contains("Dvt"))
                dgvEditCt1.Columns["Dvt"].ReadOnly = true;

            if (enuNew_Edit == enuEdit.Edit)
            {
                foreach (DataRow drEditCt in dtEditCt.Rows)
                {
                    if (dtEditCt.Columns.Contains("Stt_Org")) //Bỏ các dữ liệu kế thừa
                    {
                        if ((string)drEditCt["Stt_Org"] != "")
                        {
                            LockControlDataGridView();
                            break;
                        }
                    }
                }
            }

            txtInherit.Text = Voucher.GetInheritVoucher(this);
            //BindingTTien                      
            numTTien.DataBindings.Clear();
            numTTien_Nt.DataBindings.Clear();
            numTSo_Luong.DataBindings.Clear();
            

            numTTien.DataBindings.Add("Value", dtEditPh, "TTien");
            numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");
            numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");
           

            lblMa_KhoN.Visible = ((bool)drDmCt["Is_DC"] || (bool)drDmCt["Is_LR"]);
            txtMa_KhoN.Visible = ((bool)drDmCt["Is_DC"] || (bool)drDmCt["Is_LR"]);
            lbtTen_KhoN.Visible = ((bool)drDmCt["Is_DC"] || (bool)drDmCt["Is_LR"]);

            lblMa_VtN.Visible = (bool)drDmCt["Is_LR"];
            txtMa_VtN.Visible = (bool)drDmCt["Is_LR"];
            lbtTen_VtN.Visible = (bool)drDmCt["Is_LR"];
            lbtDvtN.Visible = (bool)drDmCt["Is_LR"];

            lblSo_LuongN.Visible = (bool)drDmCt["Is_LR"];
            numSo_LuongN.Visible = (bool)drDmCt["Is_LR"];

            //dtEdiCt_LR
            if ((bool)drDmCt["Is_LR"])
            {
                dtEditCt_LR = DataTool.SQLGetDataTable("R05CTNXLR", enuNew_Edit == enuEdit.New ? " TOP 0 * " : " TOP 1 * ", "Stt = '" + this.strStt + "'", null);

                if (dtEditCt_LR.Rows.Count == 0)
                {
                    DataRow drEditCt_LR = dtEditCt_LR.NewRow();
                    Common.SetDefaultDataRow(ref drEditCt_LR);
                    dtEditCt_LR.Rows.Add(drEditCt_LR);
                }

                txtMa_KhoN.Text = dtEditCt_LR.Rows[0]["Ma_Kho"].ToString();
                txtMa_VtN.Text = dtEditCt_LR.Rows[0]["Ma_Vt"].ToString();
                numSo_LuongN.Value = Convert.ToDouble(dtEditCt_LR.Rows[0]["So_Luong"]);
            }
        }
        private void DataGridView_Language()
        {
        }
        private void LoadDicName()
        {
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Dt_Vc.bUseAutoDropDown = true;
            txtMa_Hd.bUseAutoDropDown = true;
            txtSo_QD.bUseAutoDropDown = true;
            //txtMa_CbNv.bUseAutoDropDown = true;

            //txtMa_Nvu
            if (txtMa_Nvu.Text.Trim() != string.Empty)
            {
                lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim());
            }
            else
                lbtTen_Nvu.Text = string.Empty;

            //txtMa_Dt
            if (txtMa_Dt.Text.Trim() != string.Empty)
            {
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
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

            //txtMa_Dt_CbNv
            if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
            {
                lbtTen_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
            }
            else
                lbtTen_CbNv.Text = string.Empty;

            //txtMa_Hd
            if (txtMa_Hd.Text.Trim() != string.Empty)
            {
                lbtTen_Hd.Text = DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
            }
            else
                lbtTen_Hd.Text = string.Empty;

            //txtMa_Bp
            if (txtMa_Bp.Text.Trim() != string.Empty)
            {
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            }
            else
                lbtTen_Bp.Text = string.Empty;

            //txtMa_Km
            if (txtMa_Km.Text.Trim() != string.Empty)
            {
                lbtTen_Km.Text = DataTool.SQLGetNameByCode("R81DMKM", "Ma_Km", "Ten_Km", txtMa_Km.Text.Trim());
            }
            else
                lbtTen_Bp.Text = string.Empty;

            //txtMa_KhoN
            if (txtMa_KhoN.Text.Trim() != string.Empty)
            {
                lbtTen_KhoN.Text = DataTool.SQLGetNameByCode("R81DmKho", "Ma_Kho", "Ten_Kho", txtMa_KhoN.Text.Trim());
            }
            else
                lbtTen_KhoN.Text = string.Empty;

            //txtMa_VtN
            if (txtMa_VtN.Text.Trim() != string.Empty)
            {
                lbtTen_VtN.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_VtN.Text.Trim());
                lbtDvtN.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Dvt", txtMa_VtN.Text.Trim());
            }
            else
                lbtTen_VtN.Text = lbtDvtN.Text = string.Empty;
            
           
        }

        private bool FormCheckValid()
        {
            if (!Common.CheckDataLocked(Library.StrToDate(this.dteNgay_Ct.Text)))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Dữ liệu đã bị khóa" : "Data have been locked";
                Common.MsgCancel(strMsg);
                return false;
            }

            if (Common.GetPartitionCurrent() != 0 && this.enuNew_Edit == enuEdit.Edit && this.drEditPh["Ngay_Ct", DataRowVersion.Original] != DBNull.Value)
            {
                if (((DateTime)this.drEditPh["Ngay_Ct"]).Year != ((DateTime)this.drEditPh["Ngay_Ct", DataRowVersion.Original]).Year)
                {
                    Common.MsgCancel("Dữ liệu đã phân vùng, không cho phép sửa chứng từ từ năm này sang năm khác");
                    return false;
                }
            }

            if (txtMa_Nvu.Text == string.Empty)
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa khai báo mã nghiệp vụ" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            //Kiểm tra LXH nhiều hơn 2 lệnh không cho phép lưu
            if (txtSo_LGH_List.Text != null && txtSo_LGH_List.Text != "" && txtSo_LGH_List.Text.Length > 15)
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Phiếu xuất không được xuất 2 lệnh xuất hàng" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            //KIEM TRA NHAP MA BP
            //if(Common.Inlist(strMa_Ct, "PX") && txtMa_Bp.Text == "")
            //{
            //    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Phiếu xuất cần nhập mã bộ phận" : "Do not register transaction type";
            //    Common.MsgCancel(strMsg);
            //    return false;
            //}
            if(strMa_Ct == "LR" && numSo_LuongN.Value != numTSo_Luong.Value)
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Phiếu xuất số lượng nhập và xuất không bằng nhau" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            //Kiểm tra trùng số chứng từ
            //if(DataTool.SQLCheckExist("R80PH", new string[] {"Ma_Ct", "Ngay_Ct", "So_Ct" }, new object[] {txtMa_Ct.Text, dteNgay_Ct.Text, txtSo_Ct.Text}))
            string strTablePh = (string)drDmCt["Table_Ph"];
            string strTableCt = (string)drDmCt["Table_Ct"];
            string strSo_Ct = txtSo_Ct.Text;

            DateTime dNgay_Ct = Library.StrToDate(dteNgay_Ct.Text);

            string strSQLExec = "SELECT COUNT(Stt) FROM " + strTableCt + " WHERE Stt <> @Stt AND So_Ct = @So_Ct AND MONTH(Ngay_Ct) = MONTH(@Ngay_Ct) AND YEAR(Ngay_Ct) = @Nam AND Ma_Ct = @Ma_Ct AND Ma_DvCs = @Ma_DvCs AND So_Seri0 = @So_Seri0";

            Hashtable ht = new Hashtable();
            ht.Add("MA_CT", strMa_Ct);
            ht.Add("SO_CT", strSo_Ct);
            ht.Add("NGAY_CT", dNgay_Ct);
            ht.Add("NAM", dNgay_Ct.Year);
            ht.Add("STT", drEditPh["Stt"]);
            ht.Add("SO_SERI0", txtSo_Seri0.Text);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            //nhớ bỏ lại
            if (Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, ht, CommandType.Text)) > 0)
                drEditPh["So_Ct"] = drCurrent["So_Ct"] = txtSo_Ct.Text = Voucher.Cong_So_Ct(this);
            //Kiểm tra nghiệp vụ hợp lệ
            foreach (DataRow dr in dtEditCt.Rows)
            {
                if ((bool)dr["Deleted"])
                    continue;

                if (dr["So_Ct0"] != drEditPh["So_Ct"])
                    dr["So_Ct0"] = drEditPh["So_Ct"];
                
                //Kiểm tra PNK thu hồi mã nvu NK00 phải nhập giá
                if (txtMa_Nvu.Text == "NK00" && Convert.ToDouble(dr["Gia_Nt9"]) == 0)
                {
                    string strMsg = string.Empty;
                    if (Element.sysLanguage == enuLanguageType.Vietnamese)
                        strMsg = "Mã nghiệp vụ NK00 yêu cầu nhập giá khác 0";

                    Common.MsgCancel(strMsg);
                    return false;
                }
                if (dr["Ma_Kho"] == "BBNT")
                {
                    string strMsg = string.Empty;
                    if (Element.sysLanguage == enuLanguageType.Vietnamese)
                           strMsg = "Kho BBNT không hợp lệ";

                    Common.MsgCancel(strMsg);
                    return false;
                }
                //Kiểm tra nhập mã bộ phận
                if(strMa_Ct == "PX" && Common.InlistLike(dr["Tk_No"].ToString(),"6") && dr["Ma_Bp"].ToString() =="")
                {
                    Common.MsgOk("Nghiệp vụ cần nhập mã bộ phận mới được phép lưu");
                    return false;
                }
                if(strMa_Ct.StartsWith("PX") && dr["Ht_Gn"].ToString() == "KG")
                {
                    if(Convert.ToDouble(numHan_Tt.Value) == 0)
                    {
                        Common.MsgOk("Hạn thanh toán phải lớn hơn 0, yêu cầu kiểm tra trước khi lưu");
                        return false;
                    }
                    else
                    { 
                        Hashtable htKg = new Hashtable();
                        htKg.Add("NGAY_CT", dteNgay_Ct.Text);
                        htKg.Add("MA_KHO", txtMa_KhoN.Text);
                        htKg.Add("PT_VC", txtSo_Xa_Lan_Tau.Text != ""?"XALAN":"XE");
                        double dbHan_Tt = Convert.ToDouble(SQLExec.ExecuteReturnValue("select [dbo].[fn_HanTTKG] (@Ngay_Ct, @Ma_kho, @Pt_Vc)", htKg, CommandType.Text));
                        if (dbHan_Tt != Convert.ToDouble(numHan_Tt.Value))
                        {
                            Common.MsgOk("Hạn thanh toán phải là "+ dbHan_Tt + " ngày, yêu cầu kiểm tra trước khi lưu");
                            return false;
                        }
                    }
                }
                //Kiểm tra tồn kho
                if ((string)drDmCt["Nh_Ct"] == "2" && Common.Inlist(dr["Ma_Kho"].ToString(), "016PT,019VPP"))
                {
                    double dbSo_Luong = Convert.ToDouble(dr["So_Luong"]);
                    double dbTon_Cuoi = 0;
                    Voucher.GetTonCuoi(dr, ref dbTon_Cuoi);

                    if (dbSo_Luong > dbTon_Cuoi)
                    {
                        string strMsg = string.Empty;

                        if (Element.sysLanguage == enuLanguageType.Vietnamese)
                            strMsg = "Số lượng xuất của mã vật tư "+ dr["Ten_Vt"] +" số lượng xuất " + dbSo_Luong.ToString("N2") + " lớn hơn số lượng tồn: " + dbTon_Cuoi.ToString("N2");

                        Common.MsgCancel(strMsg);
                        return false;
                        
                    }
                }
                //Kiểm tra tồn kho
                if ((string)drDmCt["Nh_Ct"] == "2" && Common.InlistLike(dr["Ma_Kho"].ToString(), "GK_"))
                {
                    double dbSo_Luong = Convert.ToDouble(dr["So_Luong"]);
                    double dbTon_Cuoi = 0;
                    Voucher.GetTonCuoi(dr, ref dbTon_Cuoi);

                    if (dbSo_Luong > dbTon_Cuoi)
                    {
                        string strMsg = string.Empty;

                        if (Element.sysLanguage == enuLanguageType.Vietnamese)
                            strMsg = "Số lượng xuất của mã vật tư " + dr["Ten_Vt"] + " số lượng xuất " + dbSo_Luong.ToString("N2") + " lớn hơn số lượng tồn: " + dbTon_Cuoi.ToString("N2");

                        Common.MsgCancel(strMsg);
                        return false;

                    }
                }
                if (dr["Ma_Kho"] == "" || dr["Ma_Kho"] == string.Empty)
                {
                    string strMsg = string.Empty;

                   strMsg = "Vui lòng nhập đầy đủ thông tin mã kho tại dòng vật tư " + dr["Ten_Vt"];

                    Common.MsgCancel(strMsg);
                    return false;
                }
                //kiểm tra tk của HT GN
                if(dr["Tk_No"].ToString() == dr["Tk_Co"].ToString() && dr["Ht_Gn"].ToString().StartsWith("KG"))
                {
                    string strMsg = string.Empty;

                    strMsg = "Tài khoản nợ đúng là tài khoản 157 hiện tại đang sai. Vui lòng sửa lại tài khoản nợ!!!";

                    Common.MsgCancel(strMsg);
                    return false;
                }
                if (dr["Tk_No"].ToString() != dr["Tk_Co"].ToString() && dr["Ht_Gn"].ToString().StartsWith("DD"))
                {
                    string strMsg = string.Empty;

                    strMsg = "Hình thức giao nhận là hàng điều động các kho nội bộ tài khoản nợ và tài khoản có phải giống nhau. Vui lòng sửa lại tài khoản nợ bằng tài khoản có!!!";

                    Common.MsgCancel(strMsg);
                    return false;
                }
                //if (dr["Stt_Org"] == "" & Common.Inlist(strMa_Ct, "PXDC,PXBR"))
                //{
                //    string strMsg = string.Empty;

                //    strMsg = "Vui lòng thừa thông tin từ PXTH để lập phiếu xuất kho tại dòng " + dr["Ten_Vt"];

                //    Common.MsgCancel(strMsg);
                //    return false;
                //}
                //#region Kiểm tra tính hợp lệ của định nghĩa nghiệp vụ
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
                //#endregion

                DataRow drDmTkNo = DataTool.SQLGetDataRowByID("R81DmTk", "Tk", dr["Tk_No"].ToString());
                DataRow drDmTkCo = DataTool.SQLGetDataRowByID("R81DmTk", "Tk", dr["Tk_Co"].ToString());

                #region Kiểm tra hạch toán hợp lệ của Tk_No
                if (drDmTkNo != null)
                {
                    if ((bool)drDmTkNo["Tk_Dt"] && dr["Ma_Dt"].ToString() == "")
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk nợ yêu cầu Mã đối tượng" : "Debit account require Customer code";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                    if ((bool)drDmTkNo["Tk_Sp"] && dr["Ma_Vt_Sp"].ToString() == "")
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk nợ yêu cầu Mã sản phẩm" : "Debit account require Product code";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                    if ((bool)drDmTkNo["Tk_Km"] && dr["Ma_Km"].ToString() == "")
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk nợ yêu cầu Mã khoản mục" : "Debit account require Category code";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                }
                #endregion

                #region Kiểm tra hạch toán hợp lệ của Tk_Co
                if (drDmTkCo != null)
                {
                    if ((bool)drDmTkCo["Tk_Dt"] && dr["Ma_Dt"].ToString() == "")
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk có yêu cầu Mã đối tượng" : "Credit account require Customer code";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                    if ((bool)drDmTkCo["Tk_Sp"] && dr["Ma_Vt_Sp"].ToString() == "")
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk có yêu cầu Mã sản phẩm" : "Credit account require Product code";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                    if ((bool)drDmTkCo["Tk_Km"] && dr["Ma_Km"].ToString() == "")
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk có yêu cầu Mã khoản mục" : "Credit account require Category code";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                }
                #endregion

                if (dtEditCt.Columns.Contains("Tien") && Convert.ToDouble(dr["Tien"]) != 0 && Convert.ToDouble(dr["So_Luong"]) != 0 && ((string)dr["Tk_No"] == string.Empty || (string)dr["Tk_Co"] == string.Empty))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán không hợp lệ" : "Transaction invalid";
                    Common.MsgCancel(strMsg);
                    return false;
                }

                dr["Posted"] = this.drDmNvu["Posted"];
            }

            return true;
        }

        public override bool Save()
        {
            dtEditCt.AcceptChanges();

            Common.GatherMemvar(this, ref this.drEditPh);
            Voucher.Update_Detail(this);

            #region Lưu vào R05CTNLR đối với phiếu lắp ráp, R05CTXLR đối với phiếu tháo ráp
            if ((bool)drDmCt["Is_LR"])
            {
                if (dtEditCt_LR == null)
                    dtEditCt_LR = SQLExec.ExecuteReturnDt("SELECT TOP 0 FROM R05CtNXLR WHERE 0 = 1");

                DataRow drEditCt_LR;
                if (dtEditCt_LR.Rows.Count == 0)
                {
                    drEditCt_LR = dtEditCt_LR.NewRow();
                    dtEditCt_LR.Rows.Add(drEditCt_LR);
                }
                else
                    drEditCt_LR = dtEditCt_LR.Rows[0];

                Common.CopyDataRow(this.dtEditCt.Rows[0], drEditCt_LR);

                drEditCt_LR["Ma_Kho"] = txtMa_KhoN.Text;
                drEditCt_LR["Ma_Vt"] = txtMa_VtN.Text;
                drEditCt_LR["Dvt"] = lbtDvtN.Text;
                drEditCt_LR["So_Luong"] = drEditCt_LR["So_Luong9"] = numSo_LuongN.Value;
                drEditCt_LR["He_So9"] = 1;
                drEditCt_LR["Gia"] = drEditCt_LR["Gia_Nt"] = drEditCt_LR["Tien"] = drEditCt_LR["Tien_Nt"] = 0;
            }
            else
            {
                dtEditCt_LR = null;
            }
            #endregion

            if (!FormCheckValid())
                return false;

            Voucher.Update_Log(this);
            Voucher.Update_TTien(this);
            Voucher.Update_Stt(this, strModule);
            Voucher.UpdateSo_Ct(this);

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
                    Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

                drEdit = drEditPh;
            }
          
            if(strMa_Ct == "PXBR" && txtMa_Nvu.Text == "PX14")
            {
                string strStt_PNGK = Common.GetNewStt("05", true);
                Hashtable ht = new Hashtable();
                ht.Add("STT_PNGK", strStt_PNGK);
                ht.Add("STT_ORG", strStt);
                ht.Add("MA_DVCS", Element.sysMa_DvCs);

                if (Voucher.SQLUpdateCt(this))
                {
                    if (SQLExec.Execute("sp_Import_PNGK_Auto", ht, CommandType.StoredProcedure))
                        return true;
                    else
                    {
                        Common.MsgOk("Chưa tạo được chứng từ nhập gửi kho!!");
                        return false;
                    }

                }
                
            }
            return Voucher.SQLUpdateCt(this);
        }
        private void LockControl()
        {

            this.txtMa_Hd.Enabled = false;
            this.txtMa_Dt.Enabled = false;
            this.txtMa_CTrinh.Enabled = false;
            this.txtSo_QD.Enabled = false;

            this.txtSo_LGH_List.ReadOnly = true;
            this.txtSo_LXH.ReadOnly = true;
            //this.dteNgay_Ct.ReadOnly = true;

            //this.txtID_Dt_Vc.ReadOnly = true;
            //this.txtTen_Dt_Vc.ReadOnly = true;
        }
        private void Ma_Tte_Valid()
        {
            string strMa_Tte = txtMa_Tte.Text.Trim();

            if (Common.Inlist(this.strMa_Ct, (string)RosySystem.Library.Parameters.GetParaValue("CT_LOCKED_EXCHANGE")))
                numTy_Gia.Enabled = false;
            else
                numTy_Gia.Enabled = true;

            if (Element.sysMa_Tte == strMa_Tte)
            {
                numTy_Gia.Value = 1;
                numTy_Gia.Enabled = false;

                this.pnlTTien.Visible = false;
                this.pnlTTien_Nt.Left = this.pnlTTien.Right - this.pnlTTien_Nt.Width;

                if (dgvEditCt1.Columns.Contains("TIEN"))
                    dgvEditCt1.Columns["TIEN"].Visible = false;

                if (dgvEditCt2.Columns.Contains("TIEN3"))
                    dgvEditCt2.Columns["TIEN3"].Visible = false;

                if (dgvEditCt2.Columns.Contains("TIEN5"))
                    dgvEditCt2.Columns["TIEN5"].Visible = false;

                if (dgvEditCt2.Columns.Contains("TIEN6"))
                    dgvEditCt2.Columns["TIEN6"].Visible = false;
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

                if (dgvEditCt1.Columns.Contains("TIEN"))
                    dgvEditCt1.Columns["TIEN"].Visible = true;

                if (dgvEditCt2.Columns.Contains("TIEN3"))
                    dgvEditCt2.Columns["TIEN3"].Visible = true;

                if (dgvEditCt2.Columns.Contains("TIEN5"))
                    dgvEditCt2.Columns["TIEN5"].Visible = true;

                if (dgvEditCt2.Columns.Contains("TIEN6"))
                    dgvEditCt2.Columns["TIEN6"].Visible = true;
            }

            if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange || numTy_Gia.bTextChange)
            {
                Voucher.Update_Detail(this);
                Voucher.Calc_Tien_All(this);

                if (txtMa_Tte.bTextChange)
                    txtMa_Tte.bTextChange = false;
            }

            numTTien_Nt.Scale = strMa_Tte == Element.sysMa_Tte ? 0 : 2;

            Voucher.FormatTien_Nt(dgvEditCt1, strMa_Tte);
            Voucher.FormatTien_Nt(dgvEditCt2, strMa_Tte);

            
            dgvEditCt1.ResizeGridView();
            dgvEditCt2.ResizeGridView();
        }

        private bool CellKeyEnter()
        {//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc

            if (dgvEditCt1.CurrentCell == null)
                return false;

            DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
            string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

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

            #region Enter tai Tk_No, Tk_Co
            if (Common.Inlist(strCurrentColumn, "TEN_VT"))
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                if (drCurrent["Ma_Vt"] == DBNull.Value || (string)drCurrent["Ma_Vt"] == string.Empty && dgvCell.OwningRow.Index != 0)
                {
                    bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;

                    if (bdsEditCt.Count > 1)
                    {
                        bdsEditCt.RemoveCurrent();
                        //dtEditCt.AcceptChanges();
                    }

                    if (bIsCurrentLastRow)
                    {
                        this.dgvEditCt1.ClearSelection();
                        this.SelectNextControl(dgvEditCt1, true, true, true, true);
                    }

                    return true;
                }

                return false;
            }
            #endregion

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

                    //if (dgvEditCt1.bIsCurrentLastRow)
                    //{
                    //    if (!Voucher.AddRow(this))
                    //        this.SelectNextControl(dgvEditCt1, true, true, true, true);
                    //    else
                    //    {
                    //        dgvEditCt1.FocusNextFirstCell();
                    //        return true;
                    //    }
                    //}
                    //else
                    //    dgvEditCt1.FocusNextFirstCell();
                }
                return false;
            }

            #endregion

            #region Enter TIEN
            if (Common.Inlist(strCurrentColumn, "TIEN"))
            {
                // Cap nhat tien TIEN truoc khi xuong dong
                double dbTien = 0;
                if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien))
                {
                    dgvEditCt1.CancelEdit();
                    drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                    drCurrent["TIEN"] = dbTien;
                    Voucher.Calc_So_Luong(drCurrent, this);
                    Voucher.Update_TTien(this);
                }

                if (dgvEditCt1.bIsCurrentLastRow)
                {
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
        private void LockControlDataGridView()
        {
            if(dgvEditCt1.Columns.Contains("Ma_Vt"))
                dgvEditCt1.Columns["Ma_Vt"].ReadOnly = true;
            
            if (Common.Inlist(strMa_Ct, "PXBR,PXDC"))
            {
                if (dgvEditCt1.Columns.Contains("So_Luong9"))
                    dgvEditCt1.Columns["So_Luong9"].ReadOnly = true;
            
                if (dgvEditCt1.Columns.Contains("So_Luong9"))
                    dgvEditCt1.Columns["So_Luong9"].Visible = true;

                if (dgvEditCt2.Columns.Contains("So_Luong9"))
                    dgvEditCt2.Columns["So_Luong9"].ReadOnly = true;

                if (dgvEditCt1.Columns.Contains("So_Luong"))
                dgvEditCt1.Columns["So_Luong"].ReadOnly = true;

           
                if (dgvEditCt1.Columns.Contains("So_Luong_Barcode"))
                    dgvEditCt1.Columns["So_Luong_Barcode"].ReadOnly = true;

                if (dgvEditCt1.Columns.Contains("So_Luong_Can"))
                    dgvEditCt1.Columns["So_Luong_Can"].ReadOnly = true;

                if (dgvEditCt1.Columns.Contains("So_Luong_Barem"))
                    dgvEditCt1.Columns["So_Luong_Barem"].ReadOnly = true;
            }
        }
        private void InheritVoucher() //Kế thừa chứng từ từ phiếu khác
        {
            Voucher.Update_Header(this);
            Voucher.Update_Detail(this);

            if (Common.Inlist(strMa_Ct, "PNPT,PXPT,PX"))
            {
                frmInheritVoucher frm = new frmInheritVoucher();
                frm.Load(this);

                if (frm.Is_Accept)
                {
                    Voucher.InheritVoucher_SetData(frm, this);

                    Voucher.Update_Detail(this);
                    Voucher.Update_TTien(this);

                }
            }
            //else if (Common.Inlist(strMa_Ct, "TP"))
            //{
            //    frmInherit_Nhap_Barcode frm = new frmInherit_Nhap_Barcode();
            //    frm.Load(this);

            //    if (frm.Is_Accept)
            //    {
            //        Voucher.InheritVoucher_SetData_Nhap_Barcode(frm, this);

            //        Voucher.Update_Detail(this);
            //        Voucher.Update_TTien(this);
            //    }
            //}

            else if (Common.Inlist(strMa_Ct, "PXBR,PXKV,PXDC,PXCP,PXHCP,PXDCC,PNGK,PXGK,PXKG"))
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
            else if (Common.Inlist(strMa_Ct, "PXTH,PNTH"))
            {
                frmInherit_PNSB frm = new frmInherit_PNSB();
                frm.Load(this);

                if (frm.Is_Accept)
                {
                    Voucher.Inherit_Phoi_SetData(frm, this);

                    Voucher.Update_DmNvu(this);
                    Voucher.Update_Detail(this);
                    Voucher.Update_TTien(this);
                    LockControl();
                }
            }
            else
            {
                frmInheritVoucher frm = new frmInheritVoucher();
                frm.Load(this.drEditPh);

                if (frm.Is_Accept)
                {
                    if (strMa_Ct == "PXPH")
                    {
                        Voucher.InheritVoucherXuatPhoi_SetData(frm, this);
                        Voucher.Update_DmNvu(this);
                    }
                    else
                        Voucher.InheritVoucher_SetData(frm, this);

                    Voucher.Update_Detail(this);
                    Voucher.Update_TTien(this);
                }
            }
            LoadDicName();
            LockControlDataGridView();
        }

        #endregion

        #region Su kien

        #region FormEvent
        void txtSo_QD_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_QD.Text.Trim();
            if (strValue == string.Empty)
                return;
            bool bRequire = false;

            string strKeyValid = "";
            string strKeyFilter = string.Empty;
            strKeyFilter = "(CHARINDEX('" + txtMa_Dt.Text.Trim() + "',Nhom_Dt) > 0 OR Nhom_Dt LIKE '%*')";//+
            // " AND (CHARINDEX('" + txtMa_Kho.Text.Trim() + "',Ma_Kho_List) > 0 OR Ma_Kho_List LIKE '%*')" +
            // " AND Ma_CTrinh='" + txtMa_CTrinh.Text.Trim() + "' ";


            DataRow drLookup = Lookup.ShowLookup("So_Qd_Dt", strValue, bRequire, strKeyFilter, strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = false;

            if (drLookup == null)
            {
                txtSo_QD.Text = string.Empty;
                // lbtTen_Hd.Text = string.Empty;
            }
            else
            {
                txtSo_QD.Text = drLookup["So_QD"].ToString();
                txtMa_CTrinh.Text = drLookup["Ma_CTrinh"].ToString();
                //txtLoai_Gia.Text = drLookup["Loai_Gia"].ToString();
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



        void txtMa_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv.Text = string.Empty;
                lbtTen_CbNv.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_CbNv.Text = drLookup["Ten_Dt"].ToString();
            }
        }
        void txtMa_Nvu_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nvu.Text.Trim();
            bool bRequire = true;
            string strFilter = "(CHARINDEX('," + strMa_Ct + ",', ',' + Ma_Ct + ',', 0) > 0 OR Ma_Ct = '*')";
            string strValid = "Ma_Ct <> ''";

            DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, strFilter, strValid);

            if (drLookup == null) //Bắt buộc phải nhập Ma_Nvu
            {
                e.Cancel = true;
                return;
            }

            this.drDmNvu = drLookup;

            txtMa_Nvu.Text = drLookup["Ma_Nvu"].ToString();
            lbtTen_Nvu.Text = drLookup["Ten_Nvu"].ToString();

            lblPosted.Visible = !(bool)drDmNvu["Posted"];

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEditPh["Duyet"] = (bool)drDmNvu["Default_Duyet"];
            
            if(!Common.Inlist(txtMa_Nvu.Text, "PXDT04,AP22"))
                Voucher.Update_DmNvu(this); //Cập nhật chi tiết hạch toán ngầm định vào chứng từ

            if (this.strMa_Ct.StartsWith("PXBR"))
            {
                this.txtMa_Km.Text = drDmNvu["Ma_Km"].ToString();
                Voucher.Update_Detail(this, "Ma_Km");

                foreach (DataRow dr in dtEditCt.Rows)
                    dr["Ma_Kho"] = drDmNvu["Ma_Kho"].ToString();
            }
            if (this.strMa_Ct.StartsWith("PXGK"))
            {
               
                foreach (DataRow dr in dtEditCt.Rows)
                    dr["Ma_Kho"] = drDmNvu["Ma_Kho"].ToString();
            }
            //if(this.strMa_Ct.StartsWith("PXDC") && txtMa_Nvu.Text == "AP22")
            //{
            //    foreach (DataRow dr in dtEditCt.Rows)
            //        dr["Tk_No"] = dr["Tk_Co"] = "15512";
            //}

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

        void btnImportExcel_Click(object sender, EventArgs e)
        {
            Voucher.ImportExcelCtVT(this);
        }

        void btHanTt_Click(object sender, EventArgs e)
        {
            Voucher.HanTt(this);
        }

       

        void btInherit_Click(object sender, EventArgs e)
        {
            this.InheritVoucher();
            this.txtMa_Nvu_Validating(null, null);
        }

     

        void txtSo_Ct_Validating(object sender, CancelEventArgs e)
        {
            if (txtSo_Ct.Text == string.Empty)
                return;

            string strTablePh = (string)drDmCt["Table_Ph"];
            string strTableCt = (string)drDmCt["Table_Ct"];
            string strSo_Ct = txtSo_Ct.Text;

            DateTime dNgay_Ct = Library.StrToDate(dteNgay_Ct.Text);

            string strSQLExec = "SELECT COUNT(Stt) FROM " + strTableCt + " WHERE Stt <> @Stt AND So_Ct = @So_Ct AND MONTH(Ngay_Ct) = MONTH(@Ngay_Ct) AND YEAR(Ngay_Ct) = @Nam AND Ma_Ct = @Ma_Ct AND Ma_DvCs = @Ma_DvCs AND So_Seri0 = @So_Seri0";

            Hashtable ht = new Hashtable();
            ht.Add("MA_CT", strMa_Ct);
            ht.Add("SO_CT", strSo_Ct);
            ht.Add("NGAY_CT", dNgay_Ct);
            ht.Add("NAM", dNgay_Ct.Year);
            ht.Add("STT", drEditPh["Stt"]);
            ht.Add("SO_SERI0", txtSo_Seri0.Text);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);

            if (Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, ht, CommandType.Text)) > 0)
            {
                if (!Common.MsgYes_No("Chứng từ số: " + txtSo_Ct.Text + " Ngày: " + dteNgay_Ct.Text + " đã tồn tại.\n Bạn có muốn tiếp tục kô?"))
                    e.Cancel = true;
            }
        }
        void dteNgay_Ct_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == dteNgay_Ct)
                dteNgay_Ct0.Text = dteNgay_Ct.Text;
        }
        void txtSo_Ct_TextChanged(object sender, EventArgs e)
        {
            if (this.ActiveControl == txtSo_Ct)
                txtSo_Ct0.Text = txtSo_Ct.Text;
        }
        void dteNgay_Ct_Validating(object sender, CancelEventArgs e)
        {
            this.Ma_Tte_Valid();
            Common.GatherMemvar(this, ref drEditPh);
        }
        void txtMa_Tte_Validating(object sender, CancelEventArgs e)
        {
            this.Ma_Tte_Valid();
        }
        void numTy_Gia_Leave(object sender, EventArgs e)
        {
            this.Ma_Tte_Valid();
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

                if (txtMa_Dt.bTextChange)
                {
                    txtOng_Ba.Text = drLookup["Ong_Ba"].ToString();//  drLookup["Ong_Ba"].ToString() ==string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
                    txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();
                }
            }

            Voucher.Update_Detail(this, "Ma_Dt");
        }
        void txtMa_Dt_Vc_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_Vc.Text.Trim();
            bool bRequire = true;

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
        void txtMa_Hd_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Hd.Text.Trim();
            bool bRequire = false;
            string strKeyValid = "";
            string strKeyFilter = "Ma_Dt='" + txtMa_Dt.Text.ToString() + "'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, strKeyFilter, strKeyValid);

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
                lbtTen_Hd.Text = drLookup["Ten_Hd"].ToString();

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
        }

        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
            }
            else
            {
                txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
                lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
            }
        }

        void txtMa_Km_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Km.Text.Trim();
            object objReturn = null;

            bool bRequire = false;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strTk_No = (string)drCurrent["Tk_No"];
            string strTk_Co = (string)drCurrent["Tk_Co"];

            objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM R81DMTK WHERE Tk = '" + strTk_No + "'");
            if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
                bRequire = true;
            else
            {
                objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM R81DMTK WHERE Tk = '" + strTk_Co + "'");
                if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
                    bRequire = true;
            }

            DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Km.Text = string.Empty;
                lbtTen_Km.Text = string.Empty;
            }
            else
            {
                txtMa_Km.Text = drLookup["Ma_Km"].ToString();
                lbtTen_Km.Text = drLookup["Ten_Km"].ToString();
            }
        }

        void txtMa_KhoN_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_KhoN.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "");

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

        void txtMa_VtN_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_VtN.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_VtN.Text = string.Empty;
                lbtTen_VtN.Text = string.Empty;
                lbtDvtN.Text = string.Empty;
            }
            else
            {
                txtMa_VtN.Text = drLookup["Ma_Vt"].ToString();
                lbtTen_VtN.Text = drLookup["Ten_Vt"].ToString();
                lbtDvtN.Text = drLookup["Dvt"].ToString();
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

                case Keys.Up:
                    if (this.dgvEditCt1.Focused && this.dgvEditCt1.bIsCurrentFirstRow)
                        this.SelectNextControl(dgvEditCt1, false, true, true, true);
                    break;

                case Keys.F6: //Insert dòng

                    if (!e.Alt && !e.Control && !e.Shift) //F6
                        Voucher.AddRow(this);
                    else if (!e.Alt && e.Control && !e.Shift) //Ctrl+F6
                        Voucher.CopyNewRow(this);

                    break;

                case Keys.I: //Insert dòng

                    if (!e.Alt && e.Control && !e.Shift) //Ctrl+I
                        Voucher.AddRow(this);
                    else if (!e.Alt && e.Control && e.Shift) //Ctrl+Shift+I
                        Voucher.CopyNewRow(this);

                    break;

                case Keys.S:
                    if (e.Control)
                    {
                        this.Save();
                        Common.MsgOk("Đã lưu xong!");
                    }

                    break;

                case Keys.F10:
                    {
                        this.InheritVoucher();
                        this.txtMa_Nvu_Validating(null, null);
                        break;
                    }
                case Keys.F11:
                    this.btHanTt.PerformClick();
                    break;

            }

            if (!this.dgvEditCt1.Focused)
                this.dgvEditCt1.ClearSelection();
        }

        #endregion

        #region DataGridViewEvent

        //Hiển thị Notice
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

            if (strColumnName == "TK_NO")
                this.strTk_NoTmp = dgvCell.FormattedValue.ToString();

            else if (strColumnName == "TK_CO")
                this.strTk_CoTmp = dgvCell.FormattedValue.ToString();

            if (Common.Inlist(strColumnName, "MA_VT,MA_KHO"))
            {
                if ((string)drCurrent["Ma_Vt"] != string.Empty)
                    this.lbtNotice.Text = Voucher.GetTonCuoi(drCurrent);

                dicName.SetValue("TON_CUOI", this.lbtNotice.Text);
            }
            else if (Common.Inlist(strColumnName, "TEN_VT,DVT"))
            {
                this.lbtNotice.Text = dicName.GetValue("TON_CUOI");
            }
            else if (Common.Inlist(strColumnName, "TK_NO, TK_CO"))
            {
                if ((string)drCurrent[strColumnName] != string.Empty)
                    this.lbtNotice.Text = Voucher.GetDuCuoi(drCurrent, (string)drCurrent[strColumnName]);
            }
            else if (dgvCell.Tag != null)
                this.lbtNotice.Text = (string)dgvCell.Tag;

            this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
        }

        //Cai dat Lookup, Enter xuống dòng
        void dgvEditCt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            //DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
            //string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            dgvVoucher dgvEditCt = (dgvVoucher)sender;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            //dgvVoucher dgvEditCt = (dgvVoucher)sender;
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

            if (Common.Inlist(strColumnName, "SO_ME"))
            {
                string strSo_Me = dgvCell.FormattedValue.ToString().Trim();
                strSo_Me = strSo_Me.ToUpper();
                dgvEditCt.CancelEdit();
                dgvCell.Value = strSo_Me;
            }


            if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
            {
                bool bLookup = true;

                if (Common.Inlist(strColumnName, "TK_NO,TK_CO"))
                    bLookup = dgvLookupTk(ref dgvCell, strColumnName);

                else if (strColumnName == "MA_DT")
                    bLookup = dgvLookupMa_Dt(ref dgvCell);

                else if (strColumnName == "MA_BP")
                    bLookup = dgvLookupMa_Bp(ref dgvCell);

                else if (strColumnName == "MA_KM")
                    bLookup = dgvLookupMa_Km(ref dgvCell);

                else if (strColumnName == "MA_VT_SP")
                    bLookup = dgvLookupMa_Vt_Sp(ref dgvCell);

                else if (strColumnName == "MA_JOB")
                    bLookup = dgvLookupMa_Job(ref dgvCell);

                else if (strColumnName == "MA_VT")
                    bLookup = dgvLookupMa_Vt(ref dgvCell);

                else if (strColumnName == "MA_KHO")
                    bLookup = dgvLookupMa_Kho(ref dgvCell);

                else if (strColumnName == "MA_KHON")
                    bLookup = dgvLookupMa_KhoN(ref dgvCell);

                else if (strColumnName == "MA_VTN")
                    bLookup = dgvLookupMa_VtN(ref dgvCell);

                else if (strColumnName == "LOAI_DAC_DIEM")
                    bLookup = dgvLookupLoai_Dac_Diem(ref dgvCell);

                else if (strColumnName == "PHAN_LOAI_PHOI")
                    bLookup = dgvLookupPhan_Loai_Phoi(ref dgvCell);


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
            if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
                return;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN"))
            {
                Voucher.Calc_So_Luong(drCurrent, this);
                Voucher.Update_TTien(this);

                //Kiểm tra tồn kho
                if ((string)drCurrent["Ma_Vt"] != string.Empty && (string)drCurrent["Ma_Kho"] != string.Empty &&
                    (string)drDmCt["Nh_Ct"] == "2" && strColumnName == "SO_LUONG9" && strMa_Ct != "PXCP")
                {
                    double dbSo_Luong = Convert.ToDouble(drCurrent["So_Luong"]);
                    double dbTon_Cuoi = 0;
                    Voucher.GetTonCuoi(drCurrent, ref dbTon_Cuoi);

                    if (dbSo_Luong > dbTon_Cuoi)
                    {
                        string strMsg = string.Empty;

                        if (Element.sysLanguage == enuLanguageType.Vietnamese)
                            strMsg = "Số lượng xuất: " + dbSo_Luong.ToString("N2") + " > số lượng tồn: " + dbTon_Cuoi.ToString("N2");
                        else
                            strMsg = "Out quantity: " + dbSo_Luong.ToString("N2") + " > closing inventory quantity: " + dbTon_Cuoi.ToString("N2");

                        Common.MsgCancel(strMsg);

                        if (Common.Inlist(drCurrent["Ma_Kho"].ToString(), "016PT,019VPP"))
                            drCurrent["So_Luong9"] = dbTon_Cuoi;
                    }
                }

                //Tính giá vốn tức thời cho người dùng tham khảo
                if (enuNew_Edit != enuEdit.Edit && Collection.Parameters.ContainsKey("AUTO_GIA_BQTT") && Collection.Parameters["AUTO_GIA_BQTT"].ToString() == "1")
                {
                    if ((bool)drCurrent["Auto_Cost"] && drCurrent["Ma_Vt"].ToString() != "" && drCurrent["Ma_Kho"].ToString() != "" && Convert.ToDouble(drCurrent["So_Luong"]) != 0)
                    {
                        Hashtable htPara = new Hashtable();
                        htPara.Add("NGAY_CT", dteNgay_Ct.Text);
                        htPara.Add("MA_KHO", drCurrent["Ma_Kho"]);
                        htPara.Add("MA_VT", drCurrent["Ma_Vt"]);
                        htPara.Add("STT", drCurrent["Stt"]);
                        htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                        double dbTien_TT = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetTien_TT(@Ngay_Ct, @Ma_Kho, @Ma_Vt, @Stt, @Ma_DvCs)", htPara, CommandType.Text));
                        double dbSL_TT = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSL_TT(@Ngay_Ct, @Ma_Kho, @Ma_Vt, @Stt, @Ma_DvCs)", htPara, CommandType.Text));
                        double dbGia_TT = dbSL_TT != 0 ? Math.Round(dbTien_TT / dbSL_TT, 4) : 0;

                        //HĐ: Cập nhật Giá tức thời vào [Gia_Nt], PX: Cập nhật Giá tức thời vào [Gia_Nt9]
                        if (txtMa_Tte.Text == "VND")
                            drCurrent["Gia_Nt9"] = dbGia_TT;
                        else
                            drCurrent["Gia_Nt9"] = Math.Round(dbGia_TT / numTy_Gia.Value, 4);

                        Voucher.Calc_So_Luong(drCurrent, this);
                    }
                }
            }

            
           
            bdsEditCt.EndEdit();//Cap nhat lai DataSource
        }

        void dgvEditCt_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;
            if (this.ActiveControl != dgvEditCt)
                return;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
        }

        //Xử lý Dvt
        void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
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
        }

        #endregion

        #region DataGridViewLookup

        private bool dgvLookupTk(ref DataGridViewCell dgvCell, string strColumnName)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = true;

            if (strColumnName == "TK_NO5" || strColumnName == "TK_CO5")
            {
                if (drCurrent["TIEN5"] == DBNull.Value || Convert.ToDouble(drCurrent["TIEN5"]) == 0)
                    bRequire = false;
            }
            else
            {
                if (strColumnName == "TK_NO6" || strColumnName == "TK_CO6")
                    if (drCurrent["TIEN6"] == DBNull.Value || Convert.ToDouble(drCurrent["TIEN6"]) == 0)
                        bRequire = false;
            }

            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCell.Value = drLookup["Tk"].ToString();
                dgvCell.Tag = drLookup["Ten_Tk"].ToString();

                dgvCell.DataGridView.EndEdit();
            }

            return true;
        }

        private bool dgvLookupMa_Dt(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCell.Value = drLookup["Ma_Dt"].ToString();
                dgvCell.Tag = drLookup["Ten_Dt"].ToString();

                dgvCell.DataGridView.EndEdit();
            }
            return true;
        }

        private bool dgvLookupMa_Bp(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strTk_No = (string)drCurrent["Tk_No"];
            string strTk_Co = (string)drCurrent["Tk_Co"];

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCell.Value = drLookup["Ma_Bp"].ToString();
                dgvCell.Tag = drLookup["Ten_Bp"].ToString();

                dgvCell.DataGridView.EndEdit();
            }

            return true;
        }

        private bool dgvLookupMa_Km(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;
            object objReturn = null;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strTk_No = (string)drCurrent["Tk_No"];
            string strTk_Co = (string)drCurrent["Tk_Co"];

            objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM R81DMTK WHERE Tk = '" + strTk_No + "'");
            if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
                bRequire = true;
            else
            {
                objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM R81DMTK WHERE Tk = '" + strTk_Co + "'");
                if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
                    bRequire = true;
            }

            DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCell.Value = drLookup["Ma_Km"].ToString();
                dgvCell.Tag = drLookup["Ten_Km"].ToString();

                dgvCell.DataGridView.EndEdit();
            }
            return true;
        }

        private bool dgvLookupMa_Vt_Sp(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;
            object objReturn = null;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strTk_No = (string)drCurrent["Tk_No"];
            string strTk_Co = (string)drCurrent["Tk_Co"];

            objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Sp FROM R81DMTK WHERE Tk = '" + strTk_No + "'");
            if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
                bRequire = true;
            else
            {
                objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Sp FROM R81DMTK WHERE Tk = '" + strTk_Co + "'");
                if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
                    bRequire = true;
            }

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCell.Value = drLookup["Ma_Vt"].ToString();
                dgvCell.Tag = drLookup["Ten_Vt"].ToString();

                dgvCell.DataGridView.EndEdit();
            }
            return true;
        }

        private bool dgvLookupMa_Job(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Job", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCell.Value = drLookup["Ma_Job"].ToString();
                dgvCell.Tag = drLookup["Ten_Job"].ToString();

                dgvCell.DataGridView.EndEdit();
                drCurrent["Ghi_Chu"] = drLookup["Ten_Job"].ToString();
            }
            return true;
        }

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

                string strMa_Vt_Old = string.Empty;

                if (drCurrent.HasVersion(DataRowVersion.Original))
                    strMa_Vt_Old = drCurrent["Ma_Vt", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt", DataRowVersion.Original];
                else
                    strMa_Vt_Old = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];

                string strMa_Vt = (string)drLookup["Ma_Vt"];

                dgvCell.Value = drLookup["Ma_Vt"].ToString();
                dgvCell.Tag = drLookup["Ten_Vt"].ToString();

                dgvCell.DataGridView.EndEdit();

                if (strMa_Vt != strMa_Vt_Old)
                {
                    drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];
                    drCurrent["Dvt"] = drLookup["Dvt"];
                    drCurrent["He_So9"] = 1;



                    Voucher.Calc_So_Luong(drCurrent, this);

                    if ((string)drDmCt["Nh_Ct"] == "1")
                    {
                        if (drCurrent["Tk_No"] == "")
                            drCurrent["Tk_No"] = drLookup["Tk_Vtu"];
                    }
                    else
                    {
                        if (drCurrent["Tk_Co"] == "")
                            drCurrent["Tk_Co"] = drLookup["Tk_Vtu"];
                    }
                }
                //else
                //{
                //    if (drCurrent["Ten_Vt"] == DBNull.Value || (string)drCurrent["Ten_Vt"] == string.Empty)
                //        drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

                //    if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
                //        drCurrent["Dvt"] = drLookup["Dvt"];

                //    if ((string)drDmCt["Nh_Ct"] == "1")
                //    {
                //        if (drCurrent["Tk_No"] == DBNull.Value || (string)drCurrent["Tk_No"] == string.Empty)
                //            drCurrent["Tk_No"] = drLookup["Tk_Vtu"];
                //    }
                //    else
                //    {
                //        if (drCurrent["Tk_Co"] == DBNull.Value || (string)drCurrent["Tk_Co"] == string.Empty)
                //            drCurrent["Tk_Co"] = drLookup["Tk_Vtu"];
                //    }
                //}
            }
            return true;
        }
        private bool dgvLookupLoai_Dac_Diem(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "LOAI_DAC_DIEM_PHOI");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'LOAI_DAC_DIEM_PHOI'", "", htField);

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCell.Value = drLookup["Type_ID"].ToString();
                dgvCell.Tag = drLookup["Type_Name"].ToString();

                drCurrent["Ghi_Chu"] = drLookup["Type_Name"];

                dgvCell.DataGridView.EndEdit();
            }
            return true;
        }
        private bool dgvLookupPhan_Loai_Phoi(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = true;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "PHAN_LOAI_PHOI");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'PHAN_LOAI_PHOI'", "", htField);

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCell.Value = drLookup["Type_ID"].ToString();
                dgvCell.Tag = drLookup["Type_Name"].ToString();

                drCurrent["Ma_Kho"] = drLookup["Type_Name"];

                dgvCell.DataGridView.EndEdit();
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
                dgvCell.Value = drLookup["Ma_Kho"].ToString();
                dgvCell.Tag = drLookup["Ten_Kho"].ToString();

                dgvCell.DataGridView.EndEdit();
            }
            return true;
        }

        private bool dgvLookupMa_KhoN(ref DataGridViewCell dgvCell)
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
                dgvCell.Value = drLookup["Ma_Kho"].ToString();
                dgvCell.Tag = drLookup["Ten_Kho"].ToString();

                dgvCell.DataGridView.EndEdit();
            }
            return true;
        }

        private bool dgvLookupMa_VtN(ref DataGridViewCell dgvCell)
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
                dgvCell.Value = drLookup["Ma_Vt"].ToString();
                dgvCell.Tag = drLookup["Ten_Vt"].ToString();

                dgvCell.DataGridView.EndEdit();
            }
            return true;
        }
        #endregion

        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.DataGridView_Language();
            this.dgvEditCt1.ClearSelection(); //Chi co tac dung sau khi show form

            cboSaveOption.Items.Clear();
            cboSaveOption.Items.AddRange(new string[] { "1-Lưu & Nhập tiếp", "2-Lưu & Đóng lại", "3-Lưu - In & Nhập tiếp", "4-Lưu - In & Đóng lại", "5-In & Nhập tiếp", "6-In & Đóng lại" });

            if (enuNew_Edit == enuEdit.Edit)
            {
                cboSaveOption.SelectedIndex = 1;
            }
            else
            {
                //if (Common.GetBufferValue("Voucher_Save_Option") != null && Common.GetBufferValue("Voucher_Save_Option").ToString().Length > 0)
                //    cboSaveOption.SelectedIndex = int.Parse(Common.GetBufferValue("Voucher_Save_Option").Substring(0, 1)) - 1;
                //else
                    cboSaveOption.SelectedIndex = 1;
            }

            if (this.enuNew_Edit == enuEdit.Edit)
            {

                if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
                {
                    this.dteNgay_Ct.Enabled = false;
                    this.btgAccept.btAccept.Enabled = false;
                }
                if ((bool)drEditPh["HDDTDaTao"] || (bool)drEditPh["Duyet_Huy"])
                {
                    this.btgAccept.btAccept.Enabled = false;
                }
                if ((bool)drEditPh["Locked"])
                {
                    this.btgAccept.btAccept.Enabled = false;
                }
                Voucher.HanTt_LockCt(this);

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
