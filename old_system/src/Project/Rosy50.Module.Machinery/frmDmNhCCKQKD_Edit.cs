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
    public partial class frmDmNhCCKQKD_Edit : RosySystem.Customize.frmEdit
    {
        public frmDmNhCCKQKD_Edit()
        {
            InitializeComponent();

            txtMa_Nh_CC_Parent.Validating += new CancelEventHandler(txtMa_Nh_Tb_Validating);
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            
        }
        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            //if ((enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy) && this.drEdit != null)
            //{
            //    if (drEdit["Ma_Nh_CC"].ToString() != "")
            //    {
            //        if (this.drEdit.Table.Rows.Count > 0)
            //        {
            //            System.Collections.Hashtable htPara = new System.Collections.Hashtable();
            //            htPara["TABLENAME"] = "R81DMNHCCKQKD";
            //            htPara["COLUMNNAME"] = "MA_NH_CC";
            //            htPara["CURRENTID"] = drEdit["Ma_Nh_CC"].ToString();
            //            htPara["KEY"] = "Ma_Nh_CC LIKE '" + drEdit["Ma_Nh_CC"].ToString().Substring(0, 1) + "%'";

            //            drEdit["Ma_Nh_CC"] = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
            //        }
            //    }
            //    else
            //        drEdit["Ma_Nh_CC"] = drEdit["Ma_Nh_CC"].ToString() + "001";
            //}

            Common.ScaterMemvar(this, ref drEdit);
            
            //lbDvt.Text = drEdit["Dvt"].ToString();
            
            BindingLanguage();
            LoadDicName();
            BindingPicture();

            this.ShowDialog();
        }

        private void LoadDicName()
        {
            if (txtMa_Nh_CC_Parent.Text.Trim() != string.Empty)
            {
                lbtTen_Nh_Tb.Text = DataTool.SQLGetNameByCode("R81DMNHCCKQKD", "Ma_Nh_CC", "Ten_Nh_CC", txtMa_Nh_CC_Parent.Text.Trim());
            }
            else
                lbtTen_Nh_Tb.Text = string.Empty;

         
        }

        private void BindingPicture()
        {
            //object objPic;

            //if (enuNew_Edit == enuEdit.Edit)
            //    objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM R81DMVTTB WHERE Ma_Vt = '" + drEdit["Ident00"].ToString() + "'");
            //else
            //    objPic = null;

            //if (objPic != null && objPic != DBNull.Value)
            //{
            //    Byte[] bytePic = (Byte[])objPic;

            //    if (bytePic.Length != 0)
            //    {
            //        //picHinh.Image = Image.FromStream(new MemoryStream((Byte[])objPic));
            //        //picHinh.SizeMode = PictureBoxSizeMode.Zoom;
            //    }
            //}
        }

        private void LoadPicture()
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();

            //fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //fileDialog.Filter = fileDialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*"; ;

            //if (fileDialog.ShowDialog() != DialogResult.OK)
            //    return;

            //FileInfo fiImage = new FileInfo(fileDialog.FileName);
            //FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            ////picHinh.Image = new Bitmap(Image.FromStream(fs), picHinh.Size);
            ////picHinh.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtMa_Nh_CC.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Vt_Tb") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            if (txtTen_Nh_CC.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ten_Vt_Tb") + " " +
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
            
         

            //Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMNHCCKQKD", ref drEdit))
                return false;

            this.SavePicture();

            ////Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //    DataTool.SQLChangeID("Ma_Vt", drEdit);

            return true;
        }

        private void SavePicture()
        {
            //Hashtable ht = new Hashtable();
            //ht.Add("IDENT00", drEdit["Ident00"]);

            //if (picHinh.Image != null)
            //{
            //    byte[] barrImg = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(picHinh.Image).ConvertTo(picHinh.Image, typeof(byte[]));
            //    ht["HINH"] = barrImg;
            //    SQLExec.Execute("UPDATE R81DmVtTb SET Hinh = @Hinh WHERE Ident00 = '" + drEdit["Ident00"].ToString() + "'", ht, CommandType.Text);
            //}
            //else
            //{
            //    ht["HINH"] = new byte[] { };
            //    SQLExec.Execute("UPDATE R81DmVtTb SET Hinh = Null WHERE Ident00 = '" + drEdit["Ident00"].ToString() + "'", ht, CommandType.Text);
            //}
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
        
        void txtMa_Nh_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_CC_Parent.Text.Trim();
            bool brequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Nh_CC", strValue, brequire, null , "Nh_Cuoi = 0");

            if (brequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Nh_CC_Parent.Text = string.Empty;
                lbtTen_Nh_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Nh_CC_Parent.Text = (string)drLookup["Ma_Nh_CC"];
                lbtTen_Nh_Tb.Text = (string)drLookup["Ten_Nh_CC"];
            }
        }

        void picHinhLoad(object sender, EventArgs e)
        {
            LoadPicture();
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
