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
    public partial class frmTanSoVTTB_Edit : RosySystem.Customize.frmEdit
    {
        public frmTanSoVTTB_Edit()
        {
            InitializeComponent();

            txtPt_Bt.Validating += new CancelEventHandler(txtPt_Bt_Validating);
            txtTan_So.Validating += new CancelEventHandler(txtTan_So_Validating);
          
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
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
            if (txtMa_Tb.Text != string.Empty)
            {
                lbtTen_Tb.Text = DataTool.SQLGetNameByCode("R06DMNHTB", "Ma_Nh_Tb", "Ten_Nh_Tb", txtMa_Tb.Text.Trim());
            }
            else
                lbtTen_Tb.Text = string.Empty;

            if (txtTan_So.Text != string.Empty)
                lbtTen_Tan_So.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtTan_So.Text.Trim());
            else
                lbtTen_Tan_So.Text = string.Empty;
        }

        void txtTan_So_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTan_So.Text.Trim();
            bool bRequire = true;

            string strFilter = "Type='TAN_SO_BT'";
            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "TAN_SO_BT");
            DataRow drLookup = Lookup.ShowLookup("TAN_SO_BT", txtTan_So.Text, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                txtTan_So.Text = string.Empty;
                lbtTen_Tan_So.Text = string.Empty;
            }
            else
            {
                txtTan_So.Text = (string)drLookup["Type_ID"];
                lbtTen_Tan_So.Text = (string)drLookup["Type_Name"];


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

            }
            else
            {
                txtPt_Bt.Text = (string)drLookup["Type_ID"];



            }
        }
        private bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtTan_So.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Mo_Ta") + " " +
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
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06TSVTTB", ref drEdit))
                return false;

            return true;
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
