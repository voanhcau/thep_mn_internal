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
    public partial class frmDmCCKQKD_Edit : RosySystem.Customize.frmEdit
    {
       
        public frmDmCCKQKD_Edit()
        {
            InitializeComponent();
          
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            btBrowser.Click += new EventHandler(btBrowser_Click);
            txtMa_Nh_CC.Validating += new CancelEventHandler(txtMa_Nhom_CC_Validating);
            txtMa_Nh_Tb.Validating += new CancelEventHandler(txtMa_Nh_Tb_Validating);
            txtMa_Tb.Validating += new CancelEventHandler(txtMa_Tb_Validating);
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

            txtMa_Nh_Tb.bUseAutoDropDown = true;
            txtMa_Tb.bUseAutoDropDown = true;
           
            if ((enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy) && this.drEdit != null)
            {

                if (this.drEdit.Table.Rows.Count > 0 && drEdit["Ma_CC"].ToString() != "")
                    {
                        System.Collections.Hashtable htPara = new System.Collections.Hashtable();
                        htPara["TABLENAME"] = "R81DMCCKQKD";
                        htPara["COLUMNNAME"] = "MA_CC";
                        htPara["CURRENTID"] = drEdit["Ma_CC"].ToString();
                        htPara["KEY"] = "Ma_CC LIKE '" + drEdit["Ma_CC"].ToString().Substring(0, 1) + "%'";

                        drEdit["Ma_CC"] = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
                    }
                    else
                        drEdit["Ma_CC"] = drEdit["Ma_Nh_CC"].ToString() + "_0001";
            }

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

            if (txtMa_Nh_Tb.Text != string.Empty)
                lbtTen_Nh_Tb.Text = DataTool.SQLGetNameByCode("R06DMNHTB", "Ma_Nh_Tb", "Ten_Nh_Tb", txtMa_Nh_Tb.Text.Trim());
            else
                lbtTen_Nh_Tb.Text = string.Empty;

            if (txtMa_Nh_CC.Text != string.Empty)
                lbtTen_Nh_CC.Text = DataTool.SQLGetNameByCode("R81DMNHCCKQKD", "Ma_Nh_CC", "Ten_Nh_CC", txtMa_Nh_CC.Text.Trim());
            else
                lbtTen_Nh_CC.Text = string.Empty;
        }

        private bool FormCheckValid()
        {
            bool bvalid = true;

            if (dteNgay_CC.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ngay_CC") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            if (txtTen_CC.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ten_CC") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            if (txtMa_Nh_Tb.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Nh_Tb") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (txtMa_Tb.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Tb") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
           
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

            if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMCCKQKD", ref drEdit))
                return false;

            return true;
        }
        void btBrowser_Click(object sender, EventArgs e)
        {
            EditResource(enuNew_Edit);

        }
        void txtMa_Nh_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_Tb.Text.Trim();
            bool bRequire = false;


            DataRow drLookup = Lookup.ShowLookup("MA_NH_TB", txtMa_Nh_Tb.Text, bRequire, "", "");

            if (drLookup == null)
            {
                txtMa_Nh_Tb.Text = string.Empty;
                lbtTen_Nh_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Nh_Tb.Text = (string)drLookup["Ma_Nh_Tb"];
                lbtTen_Nh_Tb.Text = (string)drLookup["Ten_Nh_Tb"];
                txtMa_Tb.strLookupKeyFilter = "Ma_Nh_Tb = '"+ txtMa_Nh_Tb.Text +"'";
            }
        }
        void txtMa_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Tb.Text.Trim();
            bool bRequire = false;


            DataRow drLookup = Lookup.ShowLookup("MA_TB", txtMa_Tb.Text, bRequire, "Ma_Nh_Tb = '" + txtMa_Nh_Tb.Text + "'", "");

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

        void txtMa_Nhom_CC_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_CC.Text.Trim();
            bool bRequire = true;


            DataRow drLookup = Lookup.ShowLookup("MA_NH_CC", txtMa_Nh_CC.Text, bRequire, "Nh_Cuoi = 1", "");

            if (drLookup == null)
            {
                txtMa_Nh_CC.Text = string.Empty;
                lbtTen_Nh_CC.Text = string.Empty;
            }
            else
            {
                txtMa_Nh_CC.Text = (string)drLookup["Ma_Nh_CC"];
                lbtTen_Nh_CC.Text = (string)drLookup["Ten_Nh_CC"];

            }
        }
        #region Update
        void EditResource(enuEdit enuNew_Edit)
        {


            string strMa_Hd = string.Empty;
            string strStt = string.Empty;
            string strPath = string.Empty;
            string strLoai = string.Empty;
            //Xác định đường dẫn tại server
            strPath = Parameters.GetParaValue("PATH_QLCCKQKD").ToString();
            //Xác định loại HD
            if (Common.InlistLike(txtMa_Nh_CC.Text,"CC"))
                strLoai = "QLCC";
            else
                strLoai = "QLKD";
         
            strPath = Path.Combine(strPath, strLoai);
            //Xác định năm ký HD
            strPath = Path.Combine(strPath, txtMa_Nh_CC.Text.Substring(2, 4));
            
            //Kiểm tra Path có tồn tại hay chưa, tạo thư mục chứa các file
            if (!Directory.Exists(strPath))
                System.IO.Directory.CreateDirectory(strPath);

           

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "All files (*.*)|*.*";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            //copy file lên server
            var fileName = fileDialog.FileName;
            string strPath_Old = txtFile_Path.Text;
            //nếu ko tồn tại thì ko copy
            if (enuNew_Edit == enuEdit.New)
            {
                if (!File.Exists(Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName)))
                    File.Copy(fileName, Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName));
            }
            else
            {
                // xóa file cũ 
                File.Delete(strPath_Old);
                //copy file mới
                if (!File.Exists(Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName)))
                    File.Copy(fileName, Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName));
            }

            ////Lưu đường dẫn file cần copy
            txtFile_Path.Text = Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName);
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
                        this.btBrowser.Enabled = false;
                    }
                }
            }
        }
    }
}
