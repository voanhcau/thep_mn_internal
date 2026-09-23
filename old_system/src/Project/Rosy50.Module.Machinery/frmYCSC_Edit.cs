using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
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
    public partial class frmYCSC_Edit : RosySystem.Customize.frmEdit
    {
        public frmYCSC_Edit()
        {
            InitializeComponent();
            txtMa_Vt_Tb.Validating += new CancelEventHandler(txtMa_Vt_Tb_Validating);
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            picHinh.DoubleClick += new EventHandler(picHinh_DoubleClick);
            txtMa_Dt_Cbnv_Bt.Validating += new CancelEventHandler(txtMa_Dt_Cbnv_Bt_Validating);
        }

        void txtMa_Dt_Cbnv_Bt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_Cbnv_Bt.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_Cbnv", strValue, bRequire, string.Empty);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_Cbnv_Bt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_Cbnv_Bt.Text = drLookup["Ma_Dt"].ToString();
            }

        }

        void picHinh_DoubleClick(object sender, EventArgs e)
        {
            this.LoadPicture();
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

            if (enuNew_Edit == enuEdit.New)
                dteNgay_Lap.Text = Library.DateToStr(DateTime.Now);

            BindingLanguage();
            LoadDicName();
            BindingPicture();

            this.ShowDialog();
        }

        private void LoadDicName()
        {
            if (txtMa_Vt_Tb.Text.Trim() != string.Empty)
            {
                lbtTen_Vt_Tb.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Tb.Text.Trim());
            }
            else
                lbtTen_Vt_Tb.Text = string.Empty;
        }

        private void BindingPicture()
        {
            object objPic;

            if (enuNew_Edit == enuEdit.Edit)
                objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM R06BTSC WHERE Ident00 = " + drEdit["Ident00"].ToString());
            else
                objPic = null;

            if (objPic != null && objPic != DBNull.Value)
            {
                Byte[] bytePic = (Byte[])objPic;

                if (bytePic.Length != 0)
                {
                    picHinh.Image = Image.FromStream(new MemoryStream((Byte[])objPic));
                    picHinh.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private bool FormCheckValid()
        {
            bool bvalid = true;

            return bvalid;
        }

        public bool Save()
        {
            Common.GatherMemvar(this,ref drEdit);

            if (!FormCheckValid())
                return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06BTSC", ref drEdit))
                return false;

            this.SavePicture();

            return true;
        }

        private void LoadPicture()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileDialog.Filter = fileDialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*"; ;

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            FileInfo fiImage = new FileInfo(fileDialog.FileName);
            FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            picHinh.Image = new Bitmap(Image.FromStream(fs), picHinh.Size);
            picHinh.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void SavePicture()
        {
            Hashtable ht = new Hashtable();
            ht.Add("IDENT00", Convert.ToInt32(drEdit["Ident00"]));

            if (picHinh.Image != null)
            {
                byte[] barrImg = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(picHinh.Image).ConvertTo(picHinh.Image, typeof(byte[]));
                ht["HINH"] = barrImg;
                SQLExec.Execute("UPDATE R06BTSC SET Hinh = @Hinh WHERE Ident00 = " + drEdit["Ident00"].ToString(), ht, CommandType.Text);
            }
            else
            {
                ht["HINH"] = new byte[] { };
                SQLExec.Execute("UPDATE R06BTSC SET Hinh = Null WHERE Ident00 = " + drEdit["Ident00"].ToString(), ht, CommandType.Text);
            }
        }

        void txtMa_Vt_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Tb.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "Ma_Nh_Vt IN (SELECT Ma_Nh_Vt FROM R81DMNHVT WHERE Is_Machinery = 1)");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Tb.Text = string.Empty;
                lbtTen_Vt_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Vt_Tb.Text = drLookup["Ma_Vt"].ToString();
                lbtTen_Vt_Tb.Text = drLookup["Ten_Vt"].ToString();
            }
        }
    }
}
