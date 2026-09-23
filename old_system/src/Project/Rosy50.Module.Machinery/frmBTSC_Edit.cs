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
    public partial class frmBTSC_Edit : RosySystem.Customize.frmEdit
    {
        public frmBTSC_Edit()
        {
            InitializeComponent();
            txtMa_Vt_Tb.Validating += new CancelEventHandler(txtMa_Vt_Tb_Validating);
            txtMa_Dt_Cbnv_Bt.Validating += new CancelEventHandler(txtMa_Dt_Cbnv_Bt_Validating);
            txtMa_Dt_Cbnv_Yc.Validating += new CancelEventHandler(txtMa_Dt_Cbnv_Yc_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Bp_YC.Validating += new CancelEventHandler(txtMa_Bp_YC_Validating);

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            picHinh.DoubleClick += new EventHandler(picHinh_DoubleClick);
        }

        void txtMa_Bp_YC_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp_YC.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp_YC.Text = string.Empty;
                lbtTen_Bp_YC.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_YC.Text = (string)drLookup["Ma_Bp"];
                lbtTen_Bp_YC.Text = (string)drLookup["Ten_Bp"];
            }
        }

        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "");

            if (bRequire && drLookup == null)
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

        #region event

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
                lbtTen_Dt_Cbnv_Bt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_Cbnv_Bt.Text = (string)drLookup["Ma_Dt"];
                lbtTen_Dt_Cbnv_Bt.Text = (string)drLookup["Ten_Dt"];
            }
        }

        void txtMa_Dt_Cbnv_Yc_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_Cbnv_Yc.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_Cbnv", strValue, bRequire, string.Empty);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_Cbnv_Yc.Text = string.Empty;
				lbtMa_Dt_Cbnv_Yc.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_Cbnv_Yc.Text = (string)drLookup["Ma_Dt"];
				lbtMa_Dt_Cbnv_Yc.Text = (string)drLookup["Ten_Dt"];
            }
        }

        void txtMa_Vt_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Tb.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, string.Empty);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Tb.Text = string.Empty;
                lbtTen_Vt_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Vt_Tb.Text = (string)drLookup["Ma_Vt"];
                lbtTen_Vt_Tb.Text = (string)drLookup["Ten_Vt"];
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

        void picHinh_DoubleClick(object sender, EventArgs e)
        {
            LoadPicture();
        }

        #endregion

        public void Load(enuEdit enuNew_Edit, DataRow drEdit, bool bpageYCSC)
        {
            this.enuNew_Edit = enuNew_Edit;
            this.drEdit = drEdit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);

			if (enuNew_Edit == enuEdit.New)
				dteNgay_Lap.Text = Library.DateToStr(DateTime.Now);
			else
			{
				if (drEdit["Ngay_Sua_Chua"] != DBNull.Value)
					dteNgay_Sua_Chua.Text = Convert.ToDateTime(drEdit["Ngay_Sua_Chua"]).ToString("dd/MM/yyyy HH:mm:ss");

				if (drEdit["Thoi_Gian_Hoan_Thanh"] != DBNull.Value)
					dteThoi_Gian_Hoan_Thanh.Text = Convert.ToDateTime(drEdit["Thoi_Gian_Hoan_Thanh"]).ToString("dd/MM/yyyy HH:mm:ss");
			}

            if (drEdit["Trong_Ke_Hoach"] != DBNull.Value)
            {
                if ((bool)drEdit["Trong_Ke_Hoach"])
                    rdbTrong_Ke_Hoach.Checked = true;
                else
                    rdbNgoai_Ke_Hoach.Checked = true;
            }

            if (drEdit["TypeOfMaintenance"] != DBNull.Value)
            {
                if ((string)drEdit["TypeOfMaintenance"] == "Kiểm tra")
                    rdbBao_Tri.Checked = true;
                else
                    rdbThay_The.Checked = true;
            }
            else
                rdbThay_The.Checked = true;

            LoadDicName();
            BindingLanguage();
            BindingPicture();
            
            this.tabControl1.SelectedTab = tabPage1;

            this.ShowDialog();
        }

        private void LoadDicName()
        {
            if (txtMa_Vt_Tb.Text.Trim() != string.Empty)
                lbtTen_Vt_Tb.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Tb.Text.Trim());
            else
                lbtTen_Vt_Tb.Text = string.Empty;

            if (txtMa_Dt_Cbnv_Bt.Text.Trim() != string.Empty)
                lbtTen_Dt_Cbnv_Bt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_Cbnv_Bt.Text.Trim());
            else
                lbtTen_Dt_Cbnv_Bt.Text = string.Empty;

			if (txtMa_Dt_Cbnv_Yc.Text.Trim() != string.Empty)
			{
				lbtMa_Dt_Cbnv_Yc.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_Cbnv_Yc.Text.Trim());
			}
			else
				lbtMa_Dt_Cbnv_Yc.Text = string.Empty;


            	//Bộ phận yêu cầu
			if (txtMa_Bp_YC.Text.Trim() != string.Empty)
			{
				lbtTen_Bp_YC.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp_YC.Text.Trim());
			}
			else
				lbtTen_Bp_YC.Text = string.Empty;

            //Bộ phận thực hiện
			if (txtMa_Bp.Text.Trim() != string.Empty)
			{
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			}
			else
				lbtTen_Bp.Text = string.Empty;
		
        }

        #region method

        private bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtMa_Vt_Tb.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Vt_Tb") + " " +
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

            drEdit["Trong_Ke_Hoach"] = rdbTrong_Ke_Hoach.Checked;

            if (drEdit.Table.Columns.Contains("Ngoai_Ke_Hoach"))
			    drEdit["Ngoai_Ke_Hoach"] = rdbNgoai_Ke_Hoach.Checked;

            drEdit["TypeOfMaintenance"] = rdbBao_Tri.Checked ? "Kiểm tra" : "Thay thế";

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06BTSC", ref drEdit))
                return false;


			//string strSqlExec = "UPDATE R06BTSC SET Ngay_Sua_Chua = '" + Convert.ToDateTime(drEdit["Ngay_Sua_Chua"]).ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE Ident00 = " + drEdit["Ident00"];

			//SQLExec.Execute(strSqlExec, CommandType.Text);

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

        #endregion

        protected override void OnShown(EventArgs e)
        {
            if (enuNew_Edit == enuEdit.Edit)
                lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
            else
                lblLog.Text = "";
        }
    }
}
