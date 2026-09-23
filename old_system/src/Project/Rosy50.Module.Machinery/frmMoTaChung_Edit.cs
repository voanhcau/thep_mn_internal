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
    public partial class frmMoTaChung_Edit : RosySystem.Customize.frmEdit
    {
        public frmMoTaChung_Edit()
        {
            InitializeComponent();
            txtMa_Mo_Ta.Validating += new CancelEventHandler(txtMa_Mo_Ta_Validating);
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

        void txtMa_Mo_Ta_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Mo_Ta.Text.Trim();
            bool bRequire = true;

            string strFilter = "Type='MO_TA_TB'";
            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "MO_TA_TB");
            DataRow drLookup = Lookup.ShowLookup("MO_TA_TB", txtMa_Mo_Ta.Text, bRequire, strFilter, "", htField);

           if (drLookup == null)
            {
                txtMa_Mo_Ta.Text = string.Empty;
                lbtTen_Mo_Ta.Text = string.Empty;
            }
            else
            {
                txtMa_Mo_Ta.Text = (string)drLookup["Type_ID"];
                lbtTen_Mo_Ta.Text = (string)drLookup["Type_Name"];
               
               
            }
        }

        private void LoadDicName()
        {
            //if (txtMa_Mo_Ta.Text != string.Empty)
            //{
            //    lbtTen_Mo_Ta.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Mo_Ta.Text.Trim());
            //}
            //else
            //    lbtTen_Mo_Ta.Text = string.Empty;

            //if (txtMa_Tb.Text != string.Empty)
            //    lbtTen_Tb.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Tb.Text.Trim());
            //else
            //    lbtTen_Tb.Text = string.Empty;
        }

        private bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtMa_Mo_Ta.Text.Trim() == string.Empty)
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

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06MOTATB", ref drEdit))
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
