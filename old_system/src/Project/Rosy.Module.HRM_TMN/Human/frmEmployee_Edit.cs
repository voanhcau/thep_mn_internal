using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using RosySystem;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Public;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Customize;


namespace RosyModule.HRM
{
	public partial class frmEmployee_Edit : RosySystem.Customize.frmEdit
	{
		//Byte[] barrImg;
		//long lImgFileLength = 0;

		DataRow drCurrent;
        DataTable dtXep_Loai;
        DataTable dtTrang_Thai_LV;
        DataTable dtTrinh_Do_DT;
        DataTable dtThanh_Phan;
        DataTable dtTen_Bac_Luong;
        string strSQL;
		#region Phuong thuc

		public frmEmployee_Edit()
		{
			InitializeComponent();

			this.txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            this.txtMa_Bp_Ct.Validating += new CancelEventHandler(txtMa_Bp_Ct_Validating);
            txtMa_Dt_CbNv_QLTT.Validating += new CancelEventHandler(txtQuan_Ly_TT_Validating);
            txtMa_Dt_CbNv_QLGT.Validating += new CancelEventHandler(txtQuan_Ly_GT_Validating);
            txtMa_Dt_CbNv_QDL.Validating += new CancelEventHandler(txtMa_Dt_CbNv_QDL_Validating);
            txtMa_VTri_NV.Validating += new CancelEventHandler(txtMa_VTri_NV_Validating);

            cboTen_Bac_Luong.SelectedIndexChanged += new EventHandler(cboTen_Bac_Luong_SelectedIndexChanged);

            btTrinh_Do_DT.Click += new EventHandler(btTrinh_Do_DT_Click);
            btTrang_Thai_LV.Click += new EventHandler(btTrang_Thai_LV_Click);
            btThanh_Phan_BT.Click += new EventHandler(btThanh_Phan_BT_Click);
            btThanh_Phan_GD.Click += new EventHandler(btThanh_Phan_GD_Click);
            btAdd_ThongTin.Click += new EventHandler(btAdd_ThongTin_Click);

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			this.picHinh.DoubleClick += new EventHandler(picHinhLoad);
		}

            	

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
			this.ActiveControl = txtMa_Dt;
            LoadComboBox();
			Common.ScaterMemvar(this, ref drEdit);

            if (enuNew_Edit == enuEdit.New)
            {
                txtMa_Dt.Text = "M" + (Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT MAX(Auto_Number) FROM R81DMDT WHERE Ma_Nh_Dt = 'NV'")) + 1).ToString();
                drEdit["Auto_Number"] = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT MAX(Auto_Number) FROM R81DMDT WHERE Ma_Nh_Dt = 'NV'")) + 1;
               txtMa_Cham_Cong.Text = "0" + drEdit["Auto_Number"].ToString();
            }
			BindingLanguage();
			LoadDicName();
            

			BindingPicture();

			this.ShowDialog();
		}
        private void LoadComboBox()
        {
            //Xếp loại
            dtXep_Loai = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = 'HRM_XEP_LOAI'");
            cboXep_Loai.DataSource = dtXep_Loai;
            cboXep_Loai.DisplayMember = "Tye_ID";
            cboXep_Loai.ValueMember = "Type_Name";

            //Trình độ đào tạo
            dtTrinh_Do_DT = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = 'HRM_TRINH_DO_DT'");
            cboTrinh_Do_DT.DataSource = dtTrinh_Do_DT;
            cboTrinh_Do_DT.DisplayMember = "Tye_ID";
            cboTrinh_Do_DT.ValueMember = "Type_Name";

            //Thành phần gia đình
            dtThanh_Phan = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = 'HRM_THANH_PHAN'");
            cboThanh_Phan_GD.DataSource = dtThanh_Phan;
            cboThanh_Phan_GD.DisplayMember = "Tye_ID";
            cboThanh_Phan_GD.ValueMember = "Type_Name";

            //Trình độ đào tạo
            cboThanh_Phan_BT.DataSource = dtThanh_Phan;
            cboThanh_Phan_BT.DisplayMember = "Tye_ID";
            cboThanh_Phan_BT.ValueMember = "Type_Name";

            //Trạng thái làm việc
            dtTrang_Thai_LV = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = 'HRM_TRANG_THAI'");
            cboTrang_Thai_LV.DataSource = dtTrang_Thai_LV;
            cboTrang_Thai_LV.DisplayMember = "Tye_ID";
            cboTrang_Thai_LV.ValueMember = "Type_Name";

            //Tên bậc lương
            if (drEdit["Ma_VTri_NV"] != "")
            {
                dtTen_Bac_Luong = SQLExec.ExecuteReturnDt("SELECT Ten_Bac FROM R81DMNGACHLUONG WHERE Ma_Vtri_NV = '" + drEdit["Ma_VTri_NV"] + "' ORDER BY Ten_Bac");
                cboTen_Bac_Luong.DataSource = dtTen_Bac_Luong;
                cboTen_Bac_Luong.DisplayMember = "Ten_Bac";
                cboTen_Bac_Luong.ValueMember = "Ten_Bac";
            }
            
        }
		private void LoadDicName()
		{
            txtMa_Bp.bUseAutoDropDown = true;
            txtMa_VTri_NV.bUseAutoDropDown = true;
            txtMa_Dt_CbNv_QLTT.bUseAutoDropDown = true;
            txtMa_Dt_CbNv_QLTT.strLookupKeyFilter = "Ma_Nh_Dt = 'NV' AND Ngay_Nghi_Lam = '19000101'";
            txtMa_Dt_CbNv_QLGT.bUseAutoDropDown = true;
            txtMa_Dt_CbNv_QLGT.strLookupKeyFilter = "Ma_Nh_Dt = 'NV' AND Ngay_Nghi_Lam = '19000101'";
            txtMa_Dt_CbNv_QDL.bUseAutoDropDown = true;
            txtMa_Dt_CbNv_QDL.strLookupKeyFilter = "Ma_Nh_Dt = 'NV' AND Ngay_Nghi_Lam = '19000101'";
            //txtMa_Dt
            if (txtMa_Bp.Text.Trim() != string.Empty)
            {
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            }
            else
                lbtTen_Bp.Text = string.Empty;

            //txtMa_Bp_Ct
            if (txtMa_Bp_Ct.Text.Trim() != string.Empty)
            {
                lbtTen_Bp_Ct.Text = DataTool.SQLGetNameByCode("R81DMBPCT", "Ma_Bp_Ct", "Ten_Bp_Ct", txtMa_Bp_Ct.Text.Trim());
            }
            else
                lbtTen_Bp_Ct.Text = string.Empty;
            //txtQuan_Ly_TT
            if (txtMa_Dt_CbNv_QLTT.Text.Trim() != string.Empty)
            {
                lbtTen_QL_TT.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv_QLTT.Text.Trim());
            }
            else
                lbtTen_QL_TT.Text = string.Empty;
            //txtMa_Bp_Ct
            if (txtMa_Dt_CbNv_QLGT.Text.Trim() != string.Empty)
            {
                lbtTen_QL_GT.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv_QLGT.Text.Trim());
            }
            else
                lbtTen_QL_GT.Text = string.Empty;

            //txtMa_Bp_Ct
            if (txtMa_Dt_CbNv_QDL.Text.Trim() != string.Empty)
            {
                lbtTen_Dt_CbNv_QDL.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv_QDL.Text.Trim());
            }
            else
                lbtTen_Dt_CbNv_QDL.Text = string.Empty;
		}

		public bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Dt_CbNv") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtTen_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Dt_CbNv") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DmDt", ref drEdit))
				return false;

			this.SavePicture();
            //Lưu thông tin Bp công tác
            strSQL = "SELECT TOP 0 * FROM R09QTCT";
            DataTable dtDmQTCT= SQLExec.ExecuteReturnDt(strSQL);

            DataRow drEdit_QTCT = dtDmQTCT.NewRow();
            drEdit_QTCT["Ma_Dt_CbNv"] = txtMa_Dt.Text;
            drEdit_QTCT["Ngay_Bd"] = DateTime.Now;
            drEdit_QTCT["Ma_Bp"] = txtMa_Bp.Text;
            drEdit_QTCT["Ma_Bp_Ct"] = txtMa_Bp_Ct.Text;
            drEdit_QTCT["Ident00"] = drEdit["Ident00_QTCT"];
            drEdit_QTCT["Ma_Data"] = Element.sysMa_Data;
            dtDmQTCT.Rows.Add(drEdit_QTCT);
            drEdit_QTCT.AcceptChanges();
            if (!DataTool.SQLCheckExist("R09QTCT", new string[] { "Ma_Dt_CbNv", "Ngay_Bd" }, new object[] { txtMa_Dt.Text, Convert.ToDateTime(dteNgay_Bd_QTCT.Text) }))
                DataTool.SQLUpdate(enuEdit.New, "R09QTCT", ref drEdit_QTCT);
            else
                DataTool.SQLUpdate(enuEdit.Edit, "R09QTCT", ref drEdit_QTCT);
            //Lưu thông tin sức khỏe
            if ((dteNgay_KSK.Text) != "  /  /")
            {
                strSQL = "SELECT TOP 0 * FROM R09QLSK";
                DataTable dtDmQLSK = SQLExec.ExecuteReturnDt(strSQL);

                DataRow drEdit_QLSK = dtDmQLSK.NewRow();
                drEdit_QLSK["Ma_Dt_CbNv"] = txtMa_Dt.Text;
                drEdit_QLSK["Ngay_KSK"] = dteNgay_KSK.Text;
                drEdit_QLSK["Nhom_Mau"] = txtNhom_Mau.Text;
                drEdit_QLSK["Chieu_Cao"] = numChieu_Cao.Value;
                drEdit_QLSK["Can_Nang"] = numCan_Nang.Value;
                drEdit_QLSK["Thong_Tin_KSK"] = txtThong_Tin_KSK.Text;
                drEdit_QLSK["Ghi_Chu_KSK"] = txtGhi_Chu_KSK.Text;
                drEdit_QLSK["Benh_Tat"] = txtBenh_Tat.Text;
                drEdit_QLSK["Ident00"] = drEdit["Ident00_QLSK"];
                drEdit_QLSK["Ma_Data"] = Element.sysMa_Data;
                dtDmQLSK.Rows.Add(drEdit_QLSK);
                drEdit_QLSK.AcceptChanges();
                if (!DataTool.SQLCheckExist("R09QLSK", new string[] { "Ma_Dt_CbNv", "Ngay_KSK" }, new object[] { txtMa_Dt.Text, Convert.ToDateTime(dteNgay_KSK.Text) }))
                    DataTool.SQLUpdate(enuEdit.New, "R09QLSK", ref drEdit_QLSK);
                else
                    DataTool.SQLUpdate(enuEdit.Edit, "R09QLSK", ref drEdit_QLSK);
            }
            if (dteNgay_Hl.Text != "  /  /")
            {
                //Lưu thông tin bậc lương
                strSQL = "SELECT TOP 0 * FROM R09QLBL";
                DataTable dtDmQLBL = SQLExec.ExecuteReturnDt(strSQL);

                DataRow drEdit_QLBL = dtDmQLBL.NewRow();
                drEdit_QLBL["Ma_Dt_CbNv"] = txtMa_Dt.Text;
                drEdit_QLBL["So_Qd_Luong"] = txtSo_QD_Luong.Text;
                drEdit_QLBL["Ma_Dt_CbNv_QDL"] = txtMa_Dt_CbNv_QDL.Text;
                drEdit_QLBL["Ten_Bac_Luong"] = cboTen_Bac_Luong.Text;
                drEdit_QLBL["Bang_Luong"] = txtBang_Luong.Text;
                drEdit_QLBL["Bac_Luong"] = txtBac_Luong.Text;
                drEdit_QLBL["Muc_Luong"] = numMuc_Luong.Text;
                drEdit_QLBL["Ngay_Hl"] = dteNgay_Hl.Text;
                drEdit_QLBL["Chuc_Danh"] = txtChuc_Danh.Text;
                drEdit_QLBL["Ident00"] = drEdit["Ident00_QLBL"];
                drEdit_QLBL["Ma_Data"] = Element.sysMa_Data;
                dtDmQLBL.Rows.Add(drEdit_QLBL);
                drEdit_QLBL.AcceptChanges();
                if (!DataTool.SQLCheckExist("R09QLBL", new string[] { "Ma_Dt_CbNv", "Ngay_Hl" }, new object[] { txtMa_Dt.Text, Convert.ToDateTime(dteNgay_Hl.Text) }))
                    DataTool.SQLUpdate(enuEdit.New, "R09QLBL", ref drEdit_QLBL);
                else
                    DataTool.SQLUpdate(enuEdit.Edit, "R09QLBL", ref drEdit_QLBL);
            }
           
			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
                DataTool.SQLChangeID("MA_DT", drEdit);

			return true;
		}		

		#region Picture

		private void BindingPicture()
		{
			object objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM R81DmDt WHERE Ma_Dt = '" + drEdit["Ma_Dt"].ToString() + "'");

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

		private void SavePicture()
		{
			Hashtable ht = new Hashtable();

			if (picHinh.Image != null)
			{
				byte[] barrImg = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(picHinh.Image).ConvertTo(picHinh.Image, typeof(byte[]));
				ht["HINH"] = barrImg;
			}
			else
			{
				ht["HINH"] = new byte[] { };
			}

			SQLExec.Execute("UPDATE R81DmDt SET Hinh = @Hinh WHERE Ma_Dt = '" + drEdit["Ma_Dt"].ToString() + "'", ht, CommandType.Text);
		}

		#endregion

		#endregion

		#region Su kien
        void btAdd_ThongTin_Click(object sender, EventArgs e)
        {
            txtDia_Chi.Text = txtDia_Chi_HKTT.Text;
            txtXa_Phuong_HN.Text = txtXa_Phuong_HKTT.Text;
            txtQuan_Huyen_HN.Text = txtQuan_Huyen_HKTT.Text;
            txtTinh_TP_HN.Text = txtTinh_TP_HKTT.Text;
        } 
        void btThanh_Phan_GD_Click(object sender, EventArgs e)
        {
            string strType = "HRM_THANH_PHAN";
            RosyList.frmDmType frm = new RosyList.frmDmType();
            frm.LoadCombo(strType);

            dtThanh_Phan = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = '" + strType + "'");
            cboThanh_Phan_BT.DataSource = dtThanh_Phan;
        }

        void btThanh_Phan_BT_Click(object sender, EventArgs e)
        {
            string strType = "HRM_THANH_PHAN";
            RosyList.frmDmType frm = new RosyList.frmDmType();
            frm.LoadCombo(strType);

            dtThanh_Phan = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = '" + strType + "'");
            cboThanh_Phan_BT.DataSource = dtThanh_Phan;
        }



        void btTrang_Thai_LV_Click(object sender, EventArgs e)
        {
            string strType = "HRM_TRANG_THAI";
            RosyList.frmDmType frm = new RosyList.frmDmType();
            frm.LoadCombo(strType);

            dtTrang_Thai_LV = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = '" + strType + "'");
            cboTrang_Thai_LV.DataSource = dtTrang_Thai_LV;
           
        }

        void btTrinh_Do_DT_Click(object sender, EventArgs e)
        {
            string strType = "HRM_TRINH_DO_DT";
            RosyList.frmDmType frm = new RosyList.frmDmType();
            frm.LoadCombo(strType);

            dtTrinh_Do_DT = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = '" + strType + "'");
            cboTrinh_Do_DT.DataSource = dtTrinh_Do_DT;
        }

        void txtMa_Bp_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp_Ct.Text.Trim();
            bool bRequi = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp_Ct", strValue, bRequi, "Ma_Bp = '"+ txtMa_Bp.Text +"'");

            if (bRequi && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp_Ct.Text = string.Empty;
                lbtTen_Bp_Ct.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_Ct.Text = (string)drLookup["Ma_Bp_Ct"];
                lbtTen_Bp_Ct.Text = (string)drLookup["Ten_Bp_Ct"];
            }
        }	

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequi = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequi, string.Empty);

			if (bRequi && drLookup == null)
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
        void txtMa_Dt_CbNv_QDL_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv_QDL.Text.Trim();
            bool bRequi = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequi, "Ma_Nh_Dt = 'NV' AND Ngay_Nghi_Lam = '19000101'");

            if (bRequi && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv_QLGT.Text = string.Empty;
                lbtTen_QL_GT.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv_QDL.Text = (string)drLookup["Ma_Dt"];
                lbtTen_Dt_CbNv_QDL.Text = (string)drLookup["Ten_Dt"];
            }
        }
        void txtQuan_Ly_GT_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv_QLGT.Text.Trim();
            bool bRequi = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequi, "Ma_Nh_Dt = 'NV' AND Ngay_Nghi_Lam = '19000101'");

            if (bRequi && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv_QLGT.Text = string.Empty;
                lbtTen_QL_GT.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv_QLGT.Text = (string)drLookup["Ma_Dt"];
                lbtTen_QL_GT.Text = (string)drLookup["Ten_Dt"];
            }
        }

        void cboTen_Bac_Luong_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtNgach_Luong = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMNGACHLUONG WHERE Ma_VTri_NV = '" + txtMa_VTri_NV.Text + "' AND Ten_Bac = N'" + cboTen_Bac_Luong.Text + "'");
            if (dtNgach_Luong.Rows.Count != 0)
            {
                DataRow drNgachLuong = dtNgach_Luong.Rows[0];
                txtBang_Luong.Text = drNgachLuong["Bang_Luong"].ToString();
                txtBac_Luong.Text = drNgachLuong["Bac_Luong"].ToString();
                txtChuc_Danh.Text = drNgachLuong["Chuc_Danh"].ToString();
                numMuc_Luong.Value = Convert.ToDouble(drNgachLuong["Muc_Luong"]);
            }
        }
        void txtMa_VTri_NV_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_VTri_NV.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "VTRI_CBNV");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'VTRI_CBNV'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_VTri_NV.Text = string.Empty;
                txtChuc_Vu.Text = string.Empty;
            }
            else
            {
                txtMa_VTri_NV.Text = drLookup["Type_ID"].ToString();
                txtChuc_Vu.Text = drLookup["Type_Name"].ToString();

                //Load lai combo bac luong
                dtTen_Bac_Luong = SQLExec.ExecuteReturnDt("SELECT Ten_Bac FROM R81DMNGACHLUONG WHERE Ma_Vtri_NV = '" + txtMa_VTri_NV.Text + "' ORDER BY Ten_Bac");
                cboTen_Bac_Luong.DataSource = dtTen_Bac_Luong;
                cboTen_Bac_Luong.DisplayMember = "Ten_Bac";
                cboTen_Bac_Luong.ValueMember = "Ten_Bac";
            }
        }
        void txtQuan_Ly_TT_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv_QLTT.Text.Trim();
            bool bRequi = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequi, "Ma_Nh_Dt = 'NV' AND Ngay_Nghi_Lam = '19000101'");

            if (bRequi && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv_QLTT.Text = string.Empty;
                lbtTen_QL_TT.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv_QLTT.Text = (string)drLookup["Ma_Dt"];
                lbtTen_QL_TT.Text = (string)drLookup["Ten_Dt"];
            }
        }
		void txtMa_Nh_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Cham_Cong.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Dt", strValue, bRequire, "Loai_Nh_Dt = 'NV'", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Cham_Cong.Text = string.Empty;
                //lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Cham_Cong.Text = ((string)drLookup["Ma_Nh_Dt"]).Trim();
                //lbtTen_Nh_Dt.Text = ((string)drLookup["Ten_Nh_Dt"]).Trim();
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		void picHinhLoad(object sender, EventArgs e)
		{
			LoadPicture();			
		}

		#endregion		

        
	}
}
