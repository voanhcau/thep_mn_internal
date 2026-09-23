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
using System.IO;

namespace RosyModule.Machinery
{
    public partial class frmDienNuocTTCT_Edit : RosySystem.Customize.frmEdit
    {
        string strLoaiCt = string.Empty;

        public frmDienNuocTTCT_Edit()
        {
            InitializeComponent();
          
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_VTri.Validating += new CancelEventHandler(txtMa_VTri_Validating);
        
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

            if (drEdit["Loai_Ct"] == "DIEN")
                strLoaiCt = "DIEN";
            else
                strLoaiCt = "NUOC";
            this.ShowDialog();
        }

      

        private void LoadDicName()
        {
            
        }

        private bool FormCheckValid()
        {
            bool bvalid = true;

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

            if (!DataTool.SQLUpdate(enuNew_Edit, "R11DIENNUOCTTCT", ref drEdit))
                return false;

            return true;
        }
     
     
   

  
        #region Update

        void txtMa_VTri_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_VTri.Text.Trim();
            string strFilter = string.Empty;

            bool bRequire = false;
            if(strLoaiCt == "DIEN")
                strFilter = "Type='VTDIEN'";
            else
                strFilter = "Type='VTNUOC'";

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            if (strLoaiCt == "DIEN")
                htField.Add("strType", "VTDIEN");
            else
                htField.Add("strType", "VTNUOC");
            
            DataRow drLookup = Lookup.ShowLookup("Ma_VTri", strValue, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                txtMa_VTri.Text = string.Empty;
                lbtTen_VTri.Text = string.Empty;
            }
            else
            {
                txtMa_VTri.Text = (string)drLookup["Type_ID"];
                lbtTen_VTri.Text = (string)drLookup["Type_Name"];

            }
        }
       
        #endregion
        protected override void OnShown(EventArgs e)
        {
            if (enuNew_Edit == enuEdit.Edit)
                lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
            else
                lblLog.Text = "";

            
            if (!Element.sysIs_Admin)
            {
                if (enuNew_Edit == enuEdit.Edit)
                {
                    string strCreate_User = (string)drEdit["Create_Log"];

                    if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                    {
                     
                        this.btgAccept.Enabled = false;
                        
                    }
                }
            }
        }
    }
}
