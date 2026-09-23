using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;

namespace RosyModule.Machinery
{
    public partial class frmKHBTTB_Edit : RosySystem.Customize.frmEdit
    {
        string strLoaiDuyet = string.Empty;

        public frmKHBTTB_Edit()
        {
            InitializeComponent();
            txtMa_Nh_Tb.Validating += new CancelEventHandler(txtMa_Mo_Ta_Validating);
            txtMa_Tb.Validating += new CancelEventHandler(txtMa_Tb_Validating);
            txtPt_Bt.Validating += new CancelEventHandler(txtPt_Bt_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtNoi_Dung.Validating += new CancelEventHandler(txtNoi_Dung_Validating);
            

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

       

       

       

        public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strLoaiDuyet)
        {
            this.enuNew_Edit = enuNew_Edit;
            this.drEdit = drEdit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strLoaiDuyet = strLoaiDuyet;

            Common.ScaterMemvar(this, ref drEdit);

            BindingLanguage();
            LoadDicName();

            if (enuNew_Edit == enuEdit.New)
            {
                numNam.Value = Element.sysWorkingYear;

                //lấy BP
                string strMa_Dt_CbNv = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
                txtMa_Bp.Text = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt_CbNv + "'");
            }
            if (enuNew_Edit == enuEdit.Edit && (bool)(drEdit["Duyet_Tp"]))
                this.btgAccept.Enabled = false;
            
            numNam.Focus();
            this.ShowDialog();
        }
      
        void txtNoi_Dung_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtNoi_Dung.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Noi_Dung", txtNoi_Dung.Text, bRequire, "Ma_Tb = '" + txtMa_Tb.Text + "'");

            if (drLookup == null)
            {
                txtNoi_Dung.Text = string.Empty;
                drEdit["Stt_Nd"] = 0;
            }
            else
            {
                txtNoi_Dung.Text = drLookup["Noi_Dung_Th"].ToString();
                drEdit["Stt_Nd"] = Convert.ToDouble(drLookup["Stt_Nd"].ToString());
                drEdit["Stt_Nd_KTDT"] = Convert.ToDouble(drLookup["Stt_Nd"].ToString());
                drEdit["Stt_Nd_TP"] = Convert.ToDouble(drLookup["Stt_Nd"].ToString());
            }
        }

        void txtPt_Bt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtPt_Bt.Text.Trim();
            bool bRequire = true;

            string strFilter = "Type='PT_BT'";
            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "PT_BT");
            DataRow drLookup = Lookup.ShowLookup("PT_BT", txtPt_Bt.Text, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                txtPt_Bt.Text = string.Empty;
                lbtTen_Pt_Bt.Text = string.Empty;
            }
            else
            {
                txtPt_Bt.Text = (string)drLookup["Type_ID"];
                lbtTen_Pt_Bt.Text = (string)drLookup["Type_Name"];
                drEdit["Pt_Bt_Tp"] = (string)drLookup["Type_ID"];
                drEdit["Pt_Bt_KtDt"] = (string)drLookup["Type_ID"];
            }
        }
        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = true;


            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", txtMa_Bp.Text, bRequire, "", "");

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
            }
            else
            {
                txtMa_Bp.Text = (string)drLookup["Ma_Bp"];
                lbtTen_Bp.Text = (string)drLookup["Ten_Bp"];

            }
        }
        void txtMa_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Tb.Text.Trim();
            bool bRequire = true;


            DataRow drLookup = Lookup.ShowLookup("MA_TB", txtMa_Tb.Text, bRequire, "", "");

            if (drLookup == null)
            {
                txtMa_Tb.Text = string.Empty;
                lbtTen_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Tb.Text = (string)drLookup["Ma_Tb"];
                lbtTen_Tb.Text = (string)drLookup["Ten_Tb"];

            }
        }
       
        void txtMa_Mo_Ta_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_Tb.Text.Trim();
            bool bRequire = true;


            DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Tb", strValue, bRequire, "");

           if (drLookup == null)
            {
                txtMa_Nh_Tb.Text = string.Empty;
                lbtTen_Nh_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Nh_Tb.Text = (string)drLookup["Ma_Nh_Tb"];
                lbtTen_Nh_Tb.Text = (string)drLookup["Ten_Nh_Tb"];
                             
            }
        }

        private void LoadDicName()
        {
            txtNoi_Dung.bUseAutoDropDown = true;
            txtNoi_Dung.strLookupKeyFilter = "Ma_Tb = '" + txtMa_Tb.Text + "'";

            if (txtMa_Nh_Tb.Text != string.Empty)
            {
                lbtTen_Nh_Tb.Text = DataTool.SQLGetNameByCode("R06DMNHTB", "Ma_Nh_Tb", "Ten_Nh_Tb", txtMa_Nh_Tb.Text.Trim());
            }
            else
                lbtTen_Nh_Tb.Text = string.Empty;

            if (txtPt_Bt.Text != string.Empty)
            {
                lbtTen_Pt_Bt.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtPt_Bt.Text.Trim(),"Type='PT_BT'");
            }
            else
                lbtTen_Pt_Bt.Text = string.Empty;

            if (txtMa_Tb.Text != string.Empty)
                lbtTen_Tb.Text = DataTool.SQLGetNameByCode("R06DMTB", "Ma_Tb", "Ten_Tb", txtMa_Tb.Text.Trim());
            else
                lbtTen_Tb.Text = string.Empty;

            if (txtMa_Bp.Text != string.Empty)
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            else
                lbtTen_Bp.Text = string.Empty;

            if (drEdit["Stt_Nd"].ToString() != string.Empty)
                txtNoi_Dung.Text = SQLExec.ExecuteReturnValue("SELECT Noi_Dung_Th FROM R06CONGVIECBTDK WHERE Stt_Nd = '" + drEdit["Stt_Nd"].ToString() + "' AND Ma_Tb = '" + txtMa_Tb.Text + "'").ToString();
            else
                txtNoi_Dung.Text = string.Empty;
        }

        private bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtMa_Nh_Tb.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Tan_So") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (txtPt_Bt.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Pt_Bt") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (txtThang_List.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Thang_List") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (txtNoi_Dung.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Noi_Dung") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            return bvalid;
        }

      

        public bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);

            if (!FormCheckValid())
                return false;

            if (enuNew_Edit == enuEdit.Edit && !(bool)drEdit["Duyet_TP"])
            {
                drEdit["Thang_List_Tp"] = txtThang_List.Text;
                drEdit["Thang_List_KTDT"] = txtThang_List.Text;
            }
            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else if (this.enuNew_Edit == enuEdit.Edit && strLoaiDuyet == string.Empty)
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();
            else if (this.enuNew_Edit == enuEdit.Edit && strLoaiDuyet == "KTDT")
                drEdit["LastModify_Log_KTDT"] = Common.GetCurrent_Log();
            else if (this.enuNew_Edit == enuEdit.Edit && strLoaiDuyet == "TP")
                drEdit["LastModify_Log_TP"] = Common.GetCurrent_Log();
            else if (this.enuNew_Edit == enuEdit.Edit && strLoaiDuyet == "GIAMDOC")
                drEdit["LastModify_Log_GD"] = Common.GetCurrent_Log();

            if (DataTool.SQLUpdate(enuNew_Edit, "R06KHBTTB", ref drEdit))
            {
                string strSQLEXEC = string.Empty;
                if(strLoaiDuyet == "TP")
                {
                    strSQLEXEC = "UPDATE R06KHBTTB SET Stt_Nd_Tp = Stt_Nd, Pt_Bt_Tp = Pt_Bt, Thang_List_Tp = Thang_List, Ghi_Chu_Tp = Ghi_Chu WHERE Ident00 = " + drEdit["Ident00"] + "";
                }
                else if(strLoaiDuyet == "KTDT")
                {
                    strSQLEXEC = "UPDATE R06KHBTTB SET Stt_Nd_KTDT = Stt_Nd, Pt_Bt_KTDT = Pt_Bt, Thang_List_KTDT = Thang_List, Ghi_Chu_KTDT = Ghi_Chu WHERE Ident00 = " + drEdit["Ident00"] + "";
                }
                else if (strLoaiDuyet == "GD")
                {
                    strSQLEXEC = "UPDATE R06KHBTTB SET Stt_Nd_GD = Stt_Nd, Pt_Bt_GD = Pt_Bt, Thang_List_GD = Thang_List, Ghi_Chu_GD = Ghi_Chu WHERE Ident00 = " + drEdit["Ident00"] + "";
                }
                else
                {
                    strSQLEXEC = "UPDATE R06KHBTTB SET Stt_Nd_User = Stt_Nd, Pt_Bt_User = Pt_Bt, Thang_List_User = Thang_List, Ghi_Chu_User = Ghi_Chu WHERE Ident00 = " + drEdit["Ident00"] + "";
                }
                SQLExec.Execute(strSQLEXEC);
            }
            else
                return false;

            return true;
        }
        void btCancel_Click(object sender, EventArgs e)
        {
            this.isAccept = false;
            this.Close();
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                this.isAccept = true;
                this.Close();
            }
        }
        protected override void OnShown(EventArgs e)
        {
            if (enuNew_Edit == enuEdit.Edit)
                lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
            else
                lblLog.Text = "";
        }

       
    }
}
