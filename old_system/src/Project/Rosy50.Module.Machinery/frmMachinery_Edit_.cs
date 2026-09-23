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
    public partial class frmMachinery_Edit_ : RosySystem.Customize.frmEdit
    {
        public frmMachinery_Edit_()
        {
            InitializeComponent();

            txtMa_Nh_Tb.Validating += new CancelEventHandler(txtMa_Nh_Tb_Validating);
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            this.picHinh.DoubleClick += new EventHandler(picHinhLoad);
            txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
            //txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
        }

       

        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;
            
            //cboNoi_Su_Dung.DataSource = SQLExec.ExecuteReturnDt("SELECT DISTINCT Noi_Su_Dung FROM R81DMVT");
            //cboNoi_Su_Dung.DisplayMember = "Noi_Su_Dung";
            //cboNoi_Su_Dung.ValueMember = "Noi_Su_Dung";

            //cboNuoc_Sx.DataSource = SQLExec.ExecuteReturnDt("SELECT DISTINCT Nuoc_Sx FROM R81DMVT");
            //cboNuoc_Sx.DisplayMember = "Nuoc_Sx";
            //cboNuoc_Sx.ValueMember = "Nuoc_Sx";

            Common.ScaterMemvar(this, ref drEdit);
            
            lbDvt.Text = drEdit["Dvt"].ToString();
            
            BindingLanguage();
            LoadDicName();
            BindingPicture();

            this.ShowDialog();
        }

        private void LoadDicName()
        {
            if (txtMa_Nh_Tb.Text.Trim() != string.Empty)
            {
                lbtTen_Nh_Tb.Text = DataTool.SQLGetNameByCode("R81DMNHTB", "Ma_Nh_Tb", "Ten_Nh_Tb", txtMa_Nh_Tb.Text.Trim());
            }
            else
                lbtTen_Nh_Tb.Text = string.Empty;

            txtMa_Vt.bUseAutoDropDown = true;
            //if (txtMa_Bp.Text.Trim() != string.Empty)
            //{
            //    lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            //}
            //else
            //    lbtTen_Bp.Text = string.Empty;
        }

        private void BindingPicture()
        {
            object objPic;

            if (enuNew_Edit == enuEdit.Edit)
                objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM R81DMVTTB WHERE Ma_Vt = '" + drEdit["Ident00"].ToString() + "'");
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

        public bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtMa_Vt.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Vt_Tb") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            if (txtTen_Vt_Chuan.Text.Trim() == string.Empty)
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
            if (!DataTool.SQLUpdate(enuNew_Edit, "R81DmVtTb", ref drEdit))
                return false;

            this.SavePicture();

            ////Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //    DataTool.SQLChangeID("Ma_Vt", drEdit);

            return true;
        }

        private void SavePicture()
        {
            Hashtable ht = new Hashtable();
            ht.Add("IDENT00", drEdit["Ident00"]);

            if (picHinh.Image != null)
            {
                byte[] barrImg = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(picHinh.Image).ConvertTo(picHinh.Image, typeof(byte[]));
                ht["HINH"] = barrImg;
                SQLExec.Execute("UPDATE R81DmVtTb SET Hinh = @Hinh WHERE Ident00 = '" + drEdit["Ident00"].ToString() + "'", ht, CommandType.Text);
            }
            else
            {
                ht["HINH"] = new byte[] { };
                SQLExec.Execute("UPDATE R81DmVtTb SET Hinh = Null WHERE Ident00 = '" + drEdit["Ident00"].ToString() + "'", ht, CommandType.Text);
            }
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

        void picHinhLoad(object sender, EventArgs e)
        {
            LoadPicture();
        }

        void txtMa_Vt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, string.Empty);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt.Text = string.Empty;
                txtTen_Vt_Chuan.Text = string.Empty;
            }
            else
            {
                txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
                txtTen_Vt_Chuan.Text = drLookup["Ten_Vt"].ToString();
                lbDvt.Text = drLookup["Dvt"].ToString();
                txtThong_So_Kt.Text = drLookup["Dvt"].ToString();
                lbDvt.Text = drLookup["Dvt"].ToString();
                lbDvt.Text = drLookup["Dvt"].ToString();
            }
        }
        //void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        //{
        
        //}

        protected override void OnShown(EventArgs e)
        {
            if (enuNew_Edit == enuEdit.Edit)
                lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
            else
                lblLog.Text = "";
        }

    }
}
