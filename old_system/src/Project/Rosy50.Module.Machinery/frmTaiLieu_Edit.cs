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
    public partial class frmTaiLieu_Edit : RosySystem.Customize.frmEdit
    {
        public frmTaiLieu_Edit()
        {
            InitializeComponent();
          
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            btBrowser.Click += new EventHandler(btBrowser_Click);
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
                lbtTen_Tb.Text = DataTool.SQLGetNameByCode("R06DMTB", "Ma_Tb", "Ten_Tb", txtMa_Tb.Text.Trim());
            else
                lbtTen_Tb.Text = string.Empty;
        }

        private bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtFile_Path.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Path") + " " +
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

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06TAILIEUTB", ref drEdit))
                return false;

            return true;
        }
        void btBrowser_Click(object sender, EventArgs e)
        {
            ////Xác định đường dẫn tại server
            string strPath = Parameters.GetParaValue("PATH_QLHSCB").ToString();

            strPath = Path.Combine(strPath, txtMa_Tb.Text);

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "All files (*.*)|*.*";

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            txtFile_Path.Text = fileDialog.FileName;

      

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
