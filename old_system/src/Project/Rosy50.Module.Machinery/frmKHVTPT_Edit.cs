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
    public partial class frmKHVTPT_Edit : RosySystem.Customize.frmEdit
    {
        bool bDuyet_KTDT = false;
        public frmKHVTPT_Edit()
        {
            InitializeComponent();
            txtMa_Nh_Tb.Validating += new CancelEventHandler(txtMa_Mo_Ta_Validating);
            txtMa_Vt.Validating += new CancelEventHandler(txtPt_Bt_Validating);
           txtMa_Bp.Validating+=new CancelEventHandler(txtMa_Bp_Validating);

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

        public void Load(enuEdit enuNew_Edit, DataRow drEdit, bool bDuyet_KTDT)
        {
            this.enuNew_Edit = enuNew_Edit;
            this.drEdit = drEdit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.bDuyet_KTDT = bDuyet_KTDT;

            Common.ScaterMemvar(this, ref drEdit);

            txtMa_Vt.bUseAutoDropDown = true;
            txtMa_Vt.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%'";
           
            BindingLanguage();
            LoadDicName();

            this.ShowDialog();
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
        void txtPt_Bt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt.Text.Trim();
            bool bRequire = true;
            DataRow drLookup = Lookup.ShowLookup("MA_VT", txtMa_Vt.Text, bRequire, "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%'");

            if (drLookup == null)
            {
                txtMa_Vt.Text = string.Empty;
                lbtTen_Vt.Text = string.Empty;
            }
            else
            {
                txtMa_Vt.Text = (string)drLookup["Ma_Vt"];
                lbtTen_Vt.Text = (string)drLookup["Ten_Vt"];


            }
        }
        
      
        void txtMa_Mo_Ta_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_Tb.Text.Trim();
            bool bRequire = true;

      
            DataRow drLookup = Lookup.ShowLookup("MA_NH_TB", txtMa_Nh_Tb.Text, bRequire, "Nh_Cuoi = 1", "");

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
            
            if (txtMa_Nh_Tb.Text != string.Empty)
            {
                lbtTen_Nh_Tb.Text = DataTool.SQLGetNameByCode("R06DMNHTB", "Ma_Nh_Tb", "Ten_Nh_Tb", txtMa_Nh_Tb.Text.Trim());
            }
            else
                lbtTen_Nh_Tb.Text = string.Empty;

            if (txtMa_Vt.Text != string.Empty)
            {
                lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtMa_Vt.Text.Trim());
            }
            else
                lbtTen_Vt.Text = string.Empty;

            if (txtMa_Tb.Text != string.Empty)
                lbtTen_Tb.Text = DataTool.SQLGetNameByCode("R06DMTB", "Ma_Tb", "Ten_Tb", txtMa_Tb.Text.Trim());
            else
                lbtTen_Tb.Text = string.Empty;

            if (txtMa_Bp.Text != string.Empty)
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            else
                lbtTen_Bp.Text = string.Empty;
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
            if (txtMa_Vt.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Pt_Bt") + " " +
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

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else if (this.enuNew_Edit == enuEdit.Edit)
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();
           

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06KHVTPT", ref drEdit))
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
