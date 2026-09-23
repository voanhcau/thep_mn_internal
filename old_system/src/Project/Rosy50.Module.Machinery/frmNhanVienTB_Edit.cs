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
    public partial class frmNhanVienTB_Edit : RosySystem.Customize.frmEdit
    {
        public frmNhanVienTB_Edit()
        {
            InitializeComponent();
          
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            //btBrowser.Click += new EventHandler(btBrowser_Click);

            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Bp.Validating+=new CancelEventHandler(txtMa_Bp_Validating);
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

        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.enuNew_Edit = enuNew_Edit;
            this.drEdit = drEdit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);
            
            BindingLanguage();
            LoadDicName();

            this.ShowDialog();
        }

      

        private void LoadDicName()
        {
            txtMa_Dt_CbNv.bUseAutoDropDown = true;

            if (txtMa_Tb.Text != string.Empty)
                lbtTen_Tb.Text = DataTool.SQLGetNameByCode("R06DMTB", "Ma_Tb", "Ten_Tb", txtMa_Tb.Text.Trim());
            else
                lbtTen_Tb.Text = string.Empty;

            if (txtMa_Dt_CbNv.Text != string.Empty)
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
            else
                lbtTen_Dt_CbNv.Text = string.Empty;

            if (txtMa_Bp.Text.Trim() != string.Empty)
            {
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            }
            else
                lbtTen_Bp.Text = string.Empty;
        }

        private bool FormCheckValid()
        {
            bool bvalid = true;
            //if (txtFile_Path.Text.Trim() == string.Empty)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Path") + " " +
            //                  Languages.GetLanguage("Not_Null"));
            //    return false;
            //}

            return bvalid;
        }

      

        public bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);

            if (!FormCheckValid())
                return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06NHANVIENTB", ref drEdit))
                return false;

            return true;
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
                lbtTen_Dt_CbNv.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
            }
        }
        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool brequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, brequire, null, "Nh_Cuoi = 1");

            if (brequire && drLookup == null)
                e.Cancel = true;

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
        protected override void OnShown(EventArgs e)
        {
            if (enuNew_Edit == enuEdit.Edit)
                lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
            else
                lblLog.Text = "";
        }
    }
}
