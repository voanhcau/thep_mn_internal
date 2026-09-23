using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;

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
    public partial class frmMachineryCT_Edit : RosySystem.Customize.frmEdit
    {
        public frmMachineryCT_Edit()
        {
            InitializeComponent();

            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Nh_Tb.Validating += new CancelEventHandler(txtMa_Nh_Tb_Validating);
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
          
           
        }

        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            if ((enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy) && this.drEdit != null)
            {
                if (drEdit["Ma_Tb"].ToString() != "")
                {
                    if (this.drEdit.Table.Rows.Count > 0)
                    {
                        System.Collections.Hashtable htPara = new System.Collections.Hashtable();
                        htPara["TABLENAME"] = "R06DMTB";
                        htPara["COLUMNNAME"] = "MA_TB";
                        htPara["CURRENTID"] = drEdit["Ma_Tb"].ToString();
                        htPara["KEY"] = "Ma_Tb LIKE '" + drEdit["Ma_Tb"].ToString().Substring(0, 4) + "%'";

                        drEdit["Ma_Tb"] = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
                    }
                }
                else
                    drEdit["Ma_Tb"] = drEdit["Ma_Tb"].ToString() + "001";
            }

            Common.ScaterMemvar(this, ref drEdit);
            
           
            
            BindingLanguage();
            LoadDicName();
            BindingPicture();

            this.ShowDialog();
        }

        private void LoadDicName()
        {
            if (txtMa_Nh_Tb.Text.Trim() != string.Empty)
            {
                lbtTen_Nh_Tb.Text = DataTool.SQLGetNameByCode("R06DMNHTB", "Ma_Nh_Tb", "Ten_Nh_Tb", txtMa_Nh_Tb.Text.Trim());
            }
            else
                lbtTen_Nh_Tb.Text = string.Empty;

            if (txtMa_Bp.Text.Trim() != string.Empty)
            {
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            }
            else
                lbtTen_Bp.Text = string.Empty;

            txtMa_Tb.bUseAutoDropDown = true;
          
        }

        private void BindingPicture()
        {
           

          
        }


        public bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtMa_Tb.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Tb") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            if (txtTen_Tb.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ten_Tb") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            return bvalid;
        }

        public bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);

            //Kiem tra Valid tren Form
            if (!FormCheckValid())
                return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();
            
            drEdit["So_Nhan_Dang"] = drEdit["Ma_Tb"];
            drEdit["Ma_Data"] = Element.sysMa_Data;
           
            //Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R06DMTB", ref drEdit))
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
        void txtMa_Nh_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_Tb.Text.Trim();
            bool brequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Tb", strValue, brequire, null , "Nh_Cuoi = 1");

            if (brequire && drLookup == null)
                e.Cancel = true;

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
        

        protected override void OnShown(EventArgs e)
        {
            //Kiem tra Permission
            switch (this.enuNew_Edit)
            {
                case enuEdit.New:
                    this.btgAccept.btAccept.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New);
                    break;
                case enuEdit.Edit:
                    this.btgAccept.btAccept.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
                    break;
                default:
                    break;
            }

            if (enuNew_Edit == enuEdit.Edit)
                lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
            else
                lblLog.Text = "";
        }

    }
}
