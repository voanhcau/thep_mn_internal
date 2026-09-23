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
        DataTable dtXep_Loai_Khac;
        DataTable dtTrang_Thai_LV;
        DataTable dtTrinh_Do_DT;
        DataTable dtTrinh_Do_DT_Khac;
        DataTable dtThanh_Phan;

        BindingSource bdsDmDtNv = new BindingSource();
        //DataTable dtTen_Bac_Luong;
        string strSQL;
		#region Phuong thuc

		public frmEmployee_Edit()
		{
			InitializeComponent();

			this.txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            this.txtMa_Bp_Ct.Validating += new CancelEventHandler(txtMa_Bp_Ct_Validating);
            txtMa_Dt_CbNv_QLTT.Validating += new CancelEventHandler(txtQuan_Ly_TT_Validating);
            txtMa_Dt_CbNv_QLGT.Validating += new CancelEventHandler(txtQuan_Ly_GT_Validating);
            
            txtMa_VTri_NV.Validating += new CancelEventHandler(txtMa_VTri_NV_Validating);

            //cboTen_Bac_Luong.SelectedIndexChanged += new EventHandler(cboTen_Bac_Luong_SelectedIndexChanged);

            btTrinh_Do_DT.Click += new EventHandler(btTrinh_Do_DT_Click);
            btTrang_Thai_LV.Click += new EventHandler(btTrang_Thai_LV_Click);
            //btThanh_Phan_BT.Click += new EventHandler(btThanh_Phan_BT_Click);
            //btThanh_Phan_GD.Click += new EventHandler(btThanh_Phan_GD_Click);
            //btAdd_ThongTin.Click += new EventHandler(btAdd_ThongTin_Click);
           
            dteNgay_Vao_Lam.TextChanged += new EventHandler(dteNgay_Vao_Lam_TextChanged);

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			this.picHinh.DoubleClick += new EventHandler(picHinhLoad);
            this.btNext.Click += new EventHandler(btNext_Click);
            this.btPrevious.Click += new EventHandler(btPrevious_Click);
            this.btSearch.Click += new EventHandler(btSearch_Click);
            this.btPrint2C.Click += new EventHandler(btPrint2C_Click);

            txtTinh_TP_HKTT.Leave += new EventHandler(txtTinh_TP_HKTT_Leave);
            txtTinh_TP_HN.Leave += new EventHandler(txtTinh_TP_HN_Leave);

		}

        void txtTinh_TP_HN_Leave(object sender, EventArgs e)
        {
            
            txtDia_Chi.Text = txtSo_Nha_HN.Text + ", " + txtXa_Phuong_HN.Text + ", " + txtQuan_Huyen_HN.Text + ", " + txtTinh_TP_HN.Text;
            if (txtDia_Chi.Text.Contains(", , "))
                txtDia_Chi.Text = txtDia_Chi.Text.Replace(", , ", ", ");
        }

        void txtTinh_TP_HKTT_Leave(object sender, EventArgs e)
        {
            txtDia_Chi_HKTT.Text = txtSo_Nha_HKTT.Text + ", " + txtXa_Phuong_HKTT.Text + ", " + txtQuan_Huyen_HKTT.Text + ", " + txtTinh_TP_HKTT.Text;
            if (txtDia_Chi_HKTT.Text.Contains(", , "))
                txtDia_Chi_HKTT.Text = txtDia_Chi_HKTT.Text.Replace(", , ", ", ");
        }

        void btPrint2C_Click(object sender, EventArgs e)
        {
            string strReportFile = "rptThongTinCBNV2C";
            Voucher.Print2C(txtMa_Dt.Text, true, true, strReportFile);
        }

        void btSearch_Click(object sender, EventArgs e)
        {
            if (bdsDmDtNv.Position < 0)
                return;

            bdsDmDtNv.Filter = "Ma_Dt = '"+ txtMa_Dt_Search.Text +"'";
            DataRow drCbNv = ((DataRowView)bdsDmDtNv.Current).Row;          
            Common.ScaterMemvar(this, ref drCbNv);
            BindingLanguage();
            LoadDicName();
            BindingPicture(drCbNv["Ma_Dt"].ToString());
        }

        void btPrevious_Click(object sender, EventArgs e)
        {
            if (bdsDmDtNv.Position < 0)
                return;
            if (this.bdsDmDtNv.Position - 1 < this.bdsDmDtNv.Count)
            {
                this.bdsDmDtNv.MovePrevious();
                DataRow drCbNv = ((DataRowView)bdsDmDtNv.Current).Row;
                enuNew_Edit = enuEdit.Edit;
                Common.ScaterMemvar(this, ref drCbNv);
                BindingLanguage();
                LoadDicName();
                BindingPicture(drCbNv["Ma_Dt"].ToString());
            }
        }

        void btNext_Click(object sender, EventArgs e)
        {
            if (bdsDmDtNv.Position < 0)
                return;

            if (this.bdsDmDtNv.Position + 1 < this.bdsDmDtNv.Count)
            {
                this.bdsDmDtNv.MoveNext();
                DataRow drCbNv = ((DataRowView)bdsDmDtNv.Current).Row;
                enuNew_Edit = enuEdit.Edit;
                Common.ScaterMemvar(this, ref drCbNv);
                BindingLanguage();
                LoadDicName();
                BindingPicture(drCbNv["Ma_Dt"].ToString());
            }
        }

             	

		public void Load(enuEdit enuNew_Edit, DataRow drEdit, BindingSource bdsDmDtNv)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
			this.ActiveControl = txtMa_Dt;

            this.bdsDmDtNv = bdsDmDtNv;

            LoadComboBox();
            
            if(enuNew_Edit == enuEdit.Edit)
			    Common.ScaterMemvar(this, ref drEdit);

            if (dteNgay_Bd_QTCT.Text == "  /  /")
                dteNgay_Bd_QTCT.Text = dteNgay_Vao_Lam.Text;

            if (enuNew_Edit == enuEdit.New)
            {
                txtMa_Dt.Text = "M" + (Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT MAX(Auto_Number) FROM R81DMDT WHERE Ma_Nh_Dt = 'NV'")) + 1).ToString();
                drEdit["Auto_Number"] = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT MAX(Auto_Number) FROM R81DMDT WHERE Ma_Nh_Dt = 'NV'")) + 1;
                txtMa_Cham_Cong.Text = "0" + drEdit["Auto_Number"].ToString();
                drEdit["Ma_Dt_CbNv"] = "";
                drEdit["So_Tk_NH"] = "";
                drEdit["Ten_NH"] = "";
               
            }
			BindingLanguage();
			LoadDicName();

            if(Common.CheckPermission("IS_ALLCBNV",enuPermission_Type.Allow_View))
                grbLuong.Visible = true;
            else
                grbLuong.Visible = false;

            if (enuNew_Edit == enuEdit.Edit)
			    BindingPicture(drEdit["Ma_Dt"].ToString());

			this.ShowDialog();
		}
        private void LoadComboBox()
        {
            

            //Trình độ đào tạo
            dtTrinh_Do_DT = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = 'HRM_TRINH_DO_DT'");
            cboTrinh_Do_DT.DataSource = dtTrinh_Do_DT;
            cboTrinh_Do_DT.DisplayMember = "Tye_ID";
            cboTrinh_Do_DT.ValueMember = "Type_Name";

            //Trình độ đào tạo KHÁC
            dtTrinh_Do_DT_Khac = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = 'HRM_TRINH_DO_DT'");
            cboTrinh_Do_DT_Khac.DataSource = dtTrinh_Do_DT_Khac;
            cboTrinh_Do_DT_Khac.DisplayMember = "Tye_ID";
            cboTrinh_Do_DT_Khac.ValueMember = "Type_Name";

        

            //Trạng thái làm việc
            dtTrang_Thai_LV = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = 'HRM_TRANG_THAI'");
            cboTrang_Thai_LV.DataSource = dtTrang_Thai_LV;
            cboTrang_Thai_LV.DisplayMember = "Tye_ID";
            cboTrang_Thai_LV.ValueMember = "Type_Name";

        
            
        }
		private void LoadDicName()
		{
            txtMa_Bp.bUseAutoDropDown = true;
            txtMa_VTri_NV.bUseAutoDropDown = true;
            txtMa_Dt_CbNv_QLTT.bUseAutoDropDown = true;
            txtMa_Dt_CbNv_QLTT.strLookupKeyFilter = "Ma_Nh_Dt = 'NV' AND Ngay_Nghi_Lam = '19000101'";
            txtMa_Dt_CbNv_QLGT.bUseAutoDropDown = true;
            txtMa_Dt_CbNv_QLGT.strLookupKeyFilter = "Ma_Nh_Dt = 'NV' AND Ngay_Nghi_Lam = '19000101'";
          
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
           
            drEdit["Ngay_End"] = drEdit["Ngay_Nghi_Lam"];
			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DmDt", ref drEdit))
				return false;

			this.SavePicture();

            //lƯU THÔNG TIN KHAC
           
            //LƯU VÀO LƯƠNG VỊ TRÍ
            Hashtable ht = new Hashtable();
            ht.Add("MA_DT_CBNV", txtMa_Dt.Text);
            ht.Add("MA_BP", txtMa_Bp.Text);
            ht.Add("MA_BP_CT", txtMa_Bp_Ct.Text);
            ht.Add("NGAY_AP", dteNgay_Ap.Text == "  /  /" ? "19000101" : dteNgay_Ap.Text);
            ht.Add("NGAY_BD_QTCT", dteNgay_Bd_QTCT.Text);
            ht.Add("CHUC_VU", txtChuc_Danh.Text);
            ht.Add("CREATE_LOG", Common.GetCurrent_Log());
            ht.Add("LOAI_CC", "");
            ht.Add("MA_VTRI_NV", txtMa_VTri_NV.Text);
            SQLExec.Execute("sp_ChuyenBpLuongVTri", ht, CommandType.StoredProcedure);

            
            //Lưu đặc điểm bản thân
            if (txtBan_Than.Text != "" || txtTham_Gia_TCNN.Text != "" || txtNhan_Than_TCNN.Text != "")
            {
                if(!DataTool.SQLCheckExist("R09DACDIEMCBNV", new string[] {"Ma_Dt_CbNv"},new object[] {txtMa_Dt.Text}))
                    SQLExec.Execute("INSERT INTO R09DACDIEMCBNV(Ma_Dt_CbNv, Ban_Than, Tham_Gia_TCNN, Nhan_Than_TCNN) VALUES('"+ txtMa_Dt.Text +"','"+ txtBan_Than.Text +"','"+ txtTham_Gia_TCNN.Text +"','"+ txtNhan_Than_TCNN.Text +"')");
                else
                    SQLExec.Execute("UPDATE R09DACDIEMCBNV SET Ban_Than = '" + txtBan_Than.Text + "', Tham_Gia_TCNN = '" + txtTham_Gia_TCNN.Text + "', Nhan_Than_TCNN = '" + txtNhan_Than_TCNN.Text + "' WHERE Ma_Dt_CbNv = '" + txtMa_Dt.Text + "'");
            }
			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
                DataTool.SQLChangeID("MA_DT", drEdit);

			return true;
		}		

		#region Picture

		private void BindingPicture(string strMa_Dt)
		{
            object objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM R81DmDt WHERE Ma_Dt = '" + strMa_Dt + "'");

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
        private void DownPicture()
        {
             SaveFileDialog saveFileDialog = new SaveFileDialog();

             saveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
             saveFileDialog.Title = "Save an Image File";
             saveFileDialog.ShowDialog();
                  

            //if (saveFileDialog.ShowDialog() != DialogResult.OK)
            //    return;
            // System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();

            string strPath = saveFileDialog.FileName;
            string strFileName =  txtMa_Dt.Text +".JEG";
            Hashtable htPara = new Hashtable();

            htPara.Add("MA_DT", txtMa_Dt.Text);
  
            object objFile = SQLExec.ExecuteReturnValue("SELECT Hinh FROM R81DMDT WHERE Ma_Dt = @Ma_Dt ", htPara, CommandType.Text);
           

            if (objFile != null && objFile != DBNull.Value && ((Byte[])objFile).Length > 0)
            {
                FileStream fileStream = new FileStream(strPath, FileMode.Create, FileAccess.ReadWrite);
                fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);
                fileStream.Close();
            
            }
        
       
			

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
         
        //void btAdd_ThongTin_Click(object sender, EventArgs e)
        //{
        //    txtDia_Chi.Text = txtDia_Chi_HKTT.Text;
        //    txtXa_Phuong_HN.Text = txtXa_Phuong_HKTT.Text;
        //    txtQuan_Huyen_HN.Text = txtQuan_Huyen_HKTT.Text;
        //    txtTinh_TP_HN.Text = txtTinh_TP_HKTT.Text;
        //} 
        //void btThanh_Phan_GD_Click(object sender, EventArgs e)
        //{
        //    string strType = "HRM_THANH_PHAN";
        //    RosyList.frmDmType frm = new RosyList.frmDmType();
        //    frm.LoadCombo(strType);

        //    dtThanh_Phan = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = '" + strType + "'");
        //    cboThanh_Phan_BT.DataSource = dtThanh_Phan;
        //}

        //void btThanh_Phan_BT_Click(object sender, EventArgs e)
        //{
        //    string strType = "HRM_THANH_PHAN";
        //    RosyList.frmDmType frm = new RosyList.frmDmType();
        //    frm.LoadCombo(strType);

        //    dtThanh_Phan = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = '" + strType + "'");
        //    cboThanh_Phan_BT.DataSource = dtThanh_Phan;
        //}



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

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp_Ct", strValue, bRequi, "(Ma_Bp = '" + txtMa_Bp.Text + "' AND Nh_Cuoi = 1) OR Ma_Bp_Ct IN ('TRUONGDV','PHODVI')");

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

        //void cboTen_Bac_Luong_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable dtNgach_Luong = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMNGACHLUONG WHERE Ma_VTri_NV = '" + txtMa_VTri_NV.Text + "' AND Ten_Bac = N'" + cboTen_Bac_Luong.Text + "'");
        //    if (dtNgach_Luong.Rows.Count != 0)
        //    {
        //        DataRow drNgachLuong = dtNgach_Luong.Rows[0];
        //        txtBang_Luong.Text = drNgachLuong["Bang_Luong"].ToString();
        //        txtBac_Luong.Text = drNgachLuong["Bac_Luong"].ToString();
        //        txtChuc_Danh.Text = drNgachLuong["Chuc_Danh"].ToString();
        //        numMuc_Luong.Value = Convert.ToDouble(drNgachLuong["Muc_Luong"]);
        //    }
        //}
        void dteNgay_Vao_Lam_TextChanged(object sender, EventArgs e)
        {

            //dteNgay_Bd_QTCT.Text = dteNgay_Vao_Lam.Text;
        }
        void txtMa_VTri_NV_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_VTri_NV.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_VTri_NV", strValue, bRequire, "Loai_Ngach = 'TT'");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_VTri_NV.Text = string.Empty;
                //txtChuc_Danh.Text = string.Empty;
            }
            else
            {
                txtMa_VTri_NV.Text = drLookup["Ma_VTri_NV"].ToString();
                //txtChuc_Danh.Text = drLookup["Chuc_Danh"].ToString();
                txtBac_Luong.Text = drLookup["Bac_Luong"].ToString();
                txtBang_Luong.Text = drLookup["Bang_Luong"].ToString();
                numMuc_Luong.Value = Convert.ToDouble(drLookup["Muc_Luong"]);
              
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
            if(Common.MsgYes_No("Bạn muốn lấy file hình không?","Y"))
                DownPicture();
            else
                LoadPicture();			
		}
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            string strMa_Bp = SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt IN (SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_ID = '"+ Element.sysUser_Id +"')").ToString();
           
            if (!Element.sysIs_Admin)
                if(strMa_Bp != "PTCHC")
                    btgAccept.btAccept.Enabled = false;
        }
		#endregion		   

        private void frmEmployee_Edit_Load(object sender, EventArgs e)
        {

        }

        //private void cboTrinh_Do_DT_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
	}
}
