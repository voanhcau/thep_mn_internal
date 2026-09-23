using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections;
using System.Windows.Forms;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosyList;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmHd_Edit : RosyList.frmEdit
	{
		DataRow drCurrent;
		object objFile = null;
		string strFile_Tag = string.Empty;
        DateTime dtNgay_Hd_Kt;
        string strMa_Nh_Dt = string.Empty;
        #region Phuong thuc

		public frmDmHd_Edit()
		{
			InitializeComponent();

			txtMa_Hd.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtSo_Hd.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
       

            txtTk.Validating += new CancelEventHandler(txtTk_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Dt_CbNv.Validating += TxtMa_Dt_CbNv_Validating;
            txtMa_Bp.Validating += TxtMa_Bp_Validating;
			txtMa_Nh_Hd.Validating += new CancelEventHandler(txtMa_Nh_Hd_Validating);
            txtNuocNK_XK.Validating += TxtNuocNK_XK_Validating;
            //txtMa_Hd_Goc.Validating += new CancelEventHandler(txtMa_Hd_Goc_Validating);
            
            txtMa_CTrinh.Validating += new CancelEventHandler(txtMa_CTrinh_Validating);
            txtSo_QD.Validating += new CancelEventHandler(txtSo_Qd_Validating);
            txtPTien.Validating += TxtPTien_Validating;
            //txtMa_Dt_NhBl.Validating += new CancelEventHandler(txtMa_Dt_Nh_Bl_Validating);

			//numTien_No0.Validated += new EventHandler(numTien_No0_Validated);
			numTien_Tt0.Validated += new EventHandler(numTien_Tt0_Validated);
			//numTien_No_Nt0.Validated += new EventHandler(numTien_No_Nt0_Validated);
			numTien_Tt_Nt0.Validated += new EventHandler(numTien_Tt_Nt0_Validated);
			//numThoi_Gian_Gh.Validating += new CancelEventHandler(numThoi_Gian_Gh_Validating);
			//dteNgay_Tu.Validating += new CancelEventHandler(dteNgay_Tu_Validating);
            dteNgay_Hd_Bd.LostFocus += DteNgay_Ky_Validated;
            
			btAttack.Click += new EventHandler(btAttack_Click);
			btOpenFile.Click += new EventHandler(btOpenFile_Click);
            
		}

       

        new public void Load(enuEdit enuNew_Edit, DataRow drCurrent)
		{
			this.drCurrent = drCurrent;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				if (drCurrent.Table.Columns.Contains("Tien_Hd"))
					drCurrent["Tien_HD"] = 0;

				if (drCurrent.Table.Columns.Contains("Tien_Hd_Nt"))
					drCurrent["Tien_HD_Nt"] = 0;

				if (drCurrent.Table.Columns.Contains("Tien_No0"))
					drCurrent["Tien_No0"] = 0;

				if (drCurrent.Table.Columns.Contains("Tien_No_Nt0"))
					drCurrent["Tien_No_Nt0"] = 0;

				if (drCurrent.Table.Columns.Contains("Tien_Tt0"))
					drCurrent["Tien_Tt0"] = 0;

				if (drCurrent.Table.Columns.Contains("Tien_Tt_Nt0"))
					drCurrent["Tien_Tt_Nt0"] = 0;

				if (drCurrent.Table.Columns.Contains("Tien_No"))
					drCurrent["Tien_No"] = 0;

				if (drCurrent.Table.Columns.Contains("Tien_No_Nt"))
					drCurrent["Tien_No_Nt"] = 0;

				if (drCurrent.Table.Columns.Contains("Tien_Goc_Tt"))
					drCurrent["Tien_Goc_Tt"] = 0;

				if (drCurrent.Table.Columns.Contains("Tien_Goc_Tt_Nt"))
					drCurrent["Tien_Goc_Tt_Nt"] = 0;

            }

			//Hải xử lý: Khi Edit, lấy dữ liệu từ SQL ra (không lấy từ C# giống trước kia)
			if (enuNew_Edit == enuEdit.Edit)
			{
                //this.txtMa_Hd.Enabled = false;
				this.drEdit = DataTool.SQLGetDataRowByID("R81DmHd", "Ma_Hd", drCurrent["Ma_Hd"].ToString());
			}
			else
			{
				this.drEdit = DataTool.SQLGetDataTable("R81DmHd", null, "0 = 1", "Ma_Hd").NewRow();
				Common.CopyDataRow(drCurrent, drEdit);
                drEdit["Ngay_End"] = Library.StrToDate("19000101");
                drEdit["Ngay_Ky"] = Library.StrToDate("19000101");
                drEdit["Ngay_Hd_Bd"] = Library.StrToDate("19000101");
                drEdit["Ngay_Hd_Kt"] = Library.StrToDate("19000101");
                drEdit["Ma_Hd"] = string.Empty;
                drEdit["Ma_Dt_CbNv"] = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);
                drEdit["Ma_Bp"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ma_Bp", drEdit["Ma_Dt_CbNv"].ToString());
                
            }

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();
            
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.strLookupKeyFilter = "Ma_Nh_Dt = 'NV'";
            if (enuNew_Edit == enuEdit.Edit && txtMa_Nh_Hd.Text == "VAY")
			{
				this.txtMa_Hd.Enabled = true;
			}
            //if ((bool)SQLExec.ExecuteReturnValue("SELECT dbo.fn_CheckMemberGroup ('"+ Element.sysUser_Id +"')") == false)
            //{
            //    numTien_Tin_Chap.Visible = false;
            //    numTien_Cam_Co.Visible = false;
            //}
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Tien_Tin_Chap"] = 0;
                drEdit["Tien_Tin_Chap_Nt"] = 0;
                drEdit["Tien_Cam_Co"] = 0;
                drEdit["Tien_Cam_Co_Nt"] = 0;
                drEdit["Note_Tien"] = "";
                drEdit["Last_Tien_Log"] = "";

                drEdit["Is_Nhan"] = false;
                drEdit["Is_Hd_Nt"] = chkIs_Hd_Nt.Checked = false;
                drEdit["Is_GiaoN"] = chkIs_GiaoN.Checked = false;
                drEdit["Ngay_Gh"] = Library.StrToDate("19000101");
                dteNgay_Gh.Text = "";
                //drEdit["Ma_Nh_Hd"] = txtMa_Nh_Hd.Text = "";
                //xóa trắng hết dữ liệu
                object[] List_Controls = new object[] { txtMa_Dt, txtMa_Bp, txtMa_Dt_CbNv };
                foreach (Control ctrl in this.Page1.Controls)
                {
                    if (ctrl is TextBox txt && !List_Controls.Contains(ctrl))
                    {
                        if (ctrl.GetType() == typeof(rsTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(rsDateTime) || ctrl.GetType() == typeof(rsComboBox) || ctrl.GetType() == typeof(ComboBox))
                        {
                            ctrl.Text = "";
                        }
                    }
                    if (ctrl is rsDateTime dte && !List_Controls.Contains(ctrl))
                    {
                        if (ctrl.GetType() == typeof(rsDateTime))
                        {
                            ctrl.Text = "";
                        }
                    }
                    if (ctrl is rsTextBoxNumber num && !List_Controls.Contains(ctrl))
                    {
                        if (ctrl.GetType() == typeof(rsTextBoxNumber))
                        {
                            ctrl.Text = "0";
                        }
                    }

                }
                //groupBox2
                foreach (Control ctrl in this.groupBox2.Controls)
                {
                    if (ctrl is TextBox txt && !List_Controls.Contains(ctrl))
                    {
                        if (ctrl.GetType() == typeof(rsTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(rsDateTime) || ctrl.GetType() == typeof(rsComboBox) || ctrl.GetType() == typeof(ComboBox))
                        {
                            ctrl.Text = "";
                        }
                    }
                    if (ctrl is rsDateTime dte && !List_Controls.Contains(ctrl))
                    {
                        if (ctrl.GetType() == typeof(rsDateTime))
                        {
                            ctrl.Text = "";
                        }
                    }
                    if (ctrl is rsTextBoxNumber num && !List_Controls.Contains(ctrl))
                    {
                        if (ctrl.GetType() == typeof(rsTextBoxNumber))
                        {
                            ctrl.Text = "0";
                        }
                    }

                }
                txtMa_CTrinh.Text = "";
                txtSo_QD.Text = "";
            }
            if (enuNew_Edit == enuEdit.Edit)
            {
               
                    
                if(drEdit["Last_Tien_Log"].ToString() != "" && Common.InlistLike(drEdit["Tk"].ToString(),"131"))
                {
                    dteNgay_Hd_Bd.Enabled = false;
                    dteNgay_Hd_Kt.Enabled = false;
                    dtNgay_Hd_Kt = (DateTime)drEdit["Ngay_Hd_Kt"];
                }
            }
            this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.strLookupKeyFilter = "Ma_Dt LIKE 'M%'";
            if (txtMa_Dt.Text.Trim() != string.Empty)
			{
                string strTen_Dt_ = "";
                strMa_Nh_Dt = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ma_Nh_Dt", txtMa_Dt.Text.Trim());
                string strTen_Dt = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
                string strTen_Nh_Dt = DataTool.SQLGetNameByCode("R81DMNHDT", "Ma_Nh_Dt", "Ten_Nh_Dt", strMa_Nh_Dt);
                strTen_Dt_ += "( ";
                strTen_Dt_ += strMa_Nh_Dt + " - " ;
                strTen_Dt_ += strTen_Nh_Dt + " )";
                lbtTen_Dt.Text = strTen_Dt;
                lbtTen_Dt2.Text = strTen_Dt_;

            }
			else
            { 
				lbtTen_Dt.Text = string.Empty;
                lbtTen_Dt2.Text = string.Empty;
            }
            if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
            {
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
            }
            else
                lbtTen_Dt_CbNv.Text = string.Empty;

            if (txtMa_Nh_Hd.Text.Trim() != string.Empty)
			{
                string strTen_Nh_Dt = DataTool.SQLGetNameByCode("R81DmNhHd", "Ma_Nh_Hd", "Ma_Nh_Hd", txtMa_Nh_Hd.Text.Trim()) + " - ";
                strTen_Nh_Dt += DataTool.SQLGetNameByCode("R81DmNhHd", "Ma_Nh_Hd", "Ten_Nh_Hd", txtMa_Nh_Hd.Text.Trim());
                lbtTen_Nh_Hd.Text = strTen_Nh_Dt;

            }
			else
				lbtTen_Nh_Hd.Text = string.Empty;

            if (txtTk.Text.Trim() != string.Empty)
            {
                lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk.Text.Trim());
            }
            else
                lbtTen_Tk.Text = string.Empty;
        }

		private void Tinh_Tien()
		{
			//numTien_No.Value = numTien_No0.Value - numTien_Tt0.Value;
			//numTien_No_Nt.Value = numTien_No_Nt0.Value - numTien_Tt_Nt0.Value;
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Hd.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Hd") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (txtSo_Hd.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("So_Hd") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            if (txtTen_Hd.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Hd") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Dt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Dt") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}
            //kiểm tra xuất xứ
            if(!DataTool.SQLCheckExist("vw_QuocGia","Quoc_Gia", txtNuocNK_XK.Text) && txtNuocNK_XK.Text != "")
            {
                Common.MsgOk("Xuất xứ chưa đúng với định nghĩa dữ liệu, anh chị cần chọn lại xuất xứ");
                return false;
            }
            //if (txtTk.Text.Trim() == string.Empty)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Not_Null"));
            //    return false;
            //}
            if (txtMa_Nh_Hd.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Nh_Hd") + " " + Languages.GetLanguage("Not_Null"));
                return false;
            }
            //kiểm tra trùng số HD
            if (DataTool.SQLCheckExist("R81DMHD","So_Hd", txtSo_Hd.Text) && (enuNew_Edit != enuEdit.Edit))
            {
                string strMa_Hd_Check = DataTool.SQLGetNameByCode("R81DMHD", "So_Hd", "Ma_Hd", txtSo_Hd.Text);
                Common.MsgOk("Số hợp đồng đã tồn tại của mã hợp đồng " + strMa_Hd_Check + ". Anh chị kiểm tra lại trước khi lưu!!!");
                return false;
            }
            DateTime dNgay_Ky = Library.StrToDate(dteNgay_Ky.Text);
            DateTime dNgay_Hd_Bd = Library.StrToDate(dteNgay_Hd_Bd.Text);
            DateTime dNgay_Hd_Kt = Library.StrToDate(dteNgay_Hd_Kt.Text);
            DateTime dNgay_Gh = Library.StrToDate(dteNgay_Gh.Text);
            if (dNgay_Hd_Bd.ToShortDateString() == "01/01/1900")
            {
                Common.MsgOk(Languages.GetLanguage("Ngay_Hd_Bd") + " " + Languages.GetLanguage("Not_Null"));
                return false;
            }
            
            if (dNgay_Hd_Kt.ToShortDateString() == "01/01/1900")
            {
                Common.MsgOk(Languages.GetLanguage("Ngay_Hd_Kt") + " " + Languages.GetLanguage("Not_Null"));
                return false;
            }
            if(dNgay_Hd_Bd > dNgay_Hd_Kt)
            {
                Common.MsgOk(Languages.GetLanguage("Ngay_Hd_Kt") + " lớn hơn " + Languages.GetLanguage("Ngay_Hd_Bd"));
                return false;
            }
            if (dtNgay_Hd_Kt > Library.StrToDate(dteNgay_Hd_Kt.Text))
            {
                Common.MsgOk("Ngày hợp đồng kết thúc phải lớn hơn "+ dtNgay_Hd_Kt +"");
                return false;
            }
            if (dNgay_Hd_Bd < dNgay_Ky)
            {
                Common.MsgOk("Ngày hợp đồng bắt đầu phải lớn hơn " + dNgay_Ky.ToShortDateString().ToString() + "");
                return false;
            }
            if (dNgay_Hd_Kt < dNgay_Gh)
            {
                Common.MsgOk("Ngày hợp đồng kết thúc phải lớn hơn " + dNgay_Gh.ToShortDateString().ToString() + "");
                return false;
            }
            //kIỂM TRA HD nguyên tắc
            if(chkIs_Hd_Nt.Checked == false && strMa_Nh_Dt == "300")
            {
                if (numTien_Hd.Value != 0 || numTien_Hd_Nt.Value == 0)
                { Common.MsgOk("Hợp đồng không nguyên tắc phải có giá trị hợp đồng tiền VND phải bằng 0, tiền ngoại tệ khác 0 "); return false; }
                if (txtDieu_Kien_Tt.Text == "" || txtHTTToan.Text == "" || txtPTien.Text == "" ||
                    txtDia_Diem_Bh.Text == "" || txtDia_Diem_Gh.Text == " " || Library.StrToDate(dteNgay_Gh.Text) == Library.StrToDate("19000101"))
                { Common.MsgOk("Dữ liệu của Hợp đồng không nguyên tắc phải nhập đầy đủ thông tin: loại giá,HT thanh toán, phương tiện địa điểm giao, bốc hàng, ngày giao hàng"); return false; }

                }
            if (chkIs_Hd_Nt.Checked == false && strMa_Nh_Dt != "300")
            {
                if (numTien_Hd_Nt.Value != 0 || numTien_Hd.Value == 0)
                { Common.MsgOk("Hợp đồng không nguyên tắc phải có giá trị hợp đồng tiền ngoại tệ phải bằng 0 , tiền VND khác 0"); return false; }
                if (txtHTTToan.Text == "" || Library.StrToDate(dteNgay_Gh.Text) == Library.StrToDate("19000101"))
                { Common.MsgOk("Dữ liệu của Hợp đồng không nguyên tắc phải nhập đầy đủ thông tin: HT thanh toán, ngày giao hàng"); return false; }


            }
            return bvalid;
        }
        private void Attach_File_Hd(DataRow drDmHd, string strPath, object objFile)
        {
            string strMa_Hd = string.Empty;
            string strLoai = string.Empty;
            string strSQL = string.Empty;
            string strFileName = (string)drDmHd["File_Name"];
           
         
            //Kiểm tra Path có tồn tại hay chưa, tạo thư mục chứa các file
            if (!Directory.Exists(strPath))
                System.IO.Directory.CreateDirectory(strPath);



            //nếu ko tồn tại thì ko copy
            if (!File.Exists(Path.Combine(strPath + strFileName)))
            {
                if (objFile != null && objFile != DBNull.Value && ((Byte[])objFile).Length > 0)
                {
                    strSQL = "UPDATE R81DMHD SET File_Path = N'" + Path.Combine(strPath + strFileName) + "' WHERE Ma_Hd = '" + drDmHd["Ma_Hd"].ToString() + "'";
                    SQLExec.Execute(strSQL);

                    strPath += "\\";

                    FileStream fileStream = new FileStream(strPath + strFileName, FileMode.Create, FileAccess.ReadWrite);

                    fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);

                    fileStream.Close();

                    strSQL = "INSERT INTO R04PO_RESOURCE(Stt, Ma_Hd, File_Path, Create_Log) VALUES ('', N'" + drDmHd["Ma_Hd"].ToString() + "',N'" + Path.Combine(strPath + strFileName) + "', '" + drDmHd["Create_Log"].ToString() + "')";
                    SQLExec.Execute(strSQL);


                }
            }
            else
            {
                //xóa file đi
                File.Delete(Path.Combine(strPath + strFileName));
             
                //copy file mới
                //strPath += "\\";
                FileStream fileStream = new FileStream(strPath + strFileName, FileMode.Create, FileAccess.ReadWrite);
                fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);
                //cập nhật tên file

                strSQL = "UPDATE R81DMHD SET File_Path = N'" + strPath + "' WHERE Ma_Hd = '" + drDmHd["Ma_Hd"].ToString() + "'";
                SQLExec.Execute(strSQL);

                strSQL = "INSERT INTO R04PO_RESOURCE(Stt, Ma_Hd, File_Path, Create_Log) VALUES ('', N'" + drDmHd["Ma_Hd"].ToString() + "',N'" + Path.Combine(strPath + strFileName) + "', '" + drDmHd["Create_Log"].ToString() + "')";
                SQLExec.Execute(strSQL);
            }


        }
      
		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            { 
                drEdit["Create_Log"] = Common.GetCurrent_Log(); 
                drEdit["LastModify_Log"] = "";

                drEdit["Is_Nhan"] = 0;
                drEdit["User_Nhan"] = "";

                if (DataTool.SQLCheckExist("R81DMHD", "Ma_Hd", txtMa_Hd.Text))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("NGAY_KY", dteNgay_Hd_Bd.Text);
                    drEdit["Ma_Hd"] = txtMa_Hd.Text = SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetMa_Hd(@Ngay_Ky)", ht, CommandType.Text).ToString();
                }
            }

            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            //if (numTien_Cam_Co.Value + numTien_Tin_Chap.Value != 0)
            //    drEdit["Lock"] = true;
			
            //kiểm tra attach file
            string strMa_Hd = string.Empty;
            string strStt = string.Empty;
            string strPath = string.Empty;
            string strLoai = string.Empty;
            string strSQL = string.Empty;
            string strFileName = (string)drEdit["File_Name"];

            //Xác định đường dẫn tại server
            strPath = Parameters.GetParaValue("PATH_QLHD").ToString();
            //Xác định loại HD
            if (drEdit["Loai_Hd"].ToString() == "1")
                strLoai = "1.HDmua_kheuoc";
            else if (drEdit["Loai_Hd"].ToString() == "2")
                strLoai = "2.HDban_chovay";
            else if (drEdit["Loai_Hd"].ToString() == "3")
                strLoai = "3.HDdichvu";
            strPath = Path.Combine(strPath, strLoai);


            //Xác định năm ký HD
            strPath = Path.Combine(strPath, Convert.ToDateTime(drEdit["Ngay_Ky"]).Year.ToString());
            // tạo thư mục chứa các file của HD
            if (drEdit["Ma_Hd"].ToString().IndexOf("/") > 1)
                strPath = Path.Combine(strPath, drEdit["Ma_Hd"].ToString().Substring(0, drEdit["Ma_Hd"].ToString().IndexOf("/")));
            else if (drEdit["Ma_Hd"].ToString().LastIndexOf("/") > 1)
                strPath = Path.Combine(strPath, drEdit["Ma_Hd"].ToString().Substring(0, drEdit["Ma_Hd"].ToString().LastIndexOf("/")));
            else
                strPath = Path.Combine(strPath, drEdit["Ma_Hd"].ToString());


            if (drEdit["Ma_Hd"].ToString() != "" && drEdit["File_Path"].ToString() != "")
            {
                try
                {
                    //Kiểm tra Path có tồn tại hay chưa, tạo thư mục chứa các file
                    if (!Directory.Exists(strPath))
                        System.IO.Directory.CreateDirectory(strPath);

                    Attach_File_Hd(drEdit, strPath, objFile);
                }
                catch (Exception ex)
                {
                    if (Common.InlistLike(ex.Message, "The user name or password is incorrect."))
                    {
                        Common.MsgOk("Bạn vui lòng đăng nhập vào server theo đường dẫn \\192.168.1.18 để đính kèm file, sau đó nhấn lưu!!!");
                        System.Diagnostics.Process.Start("explorer.exe", @"\\192.168.1.18");

                        return false;
                    }
                    else if (Common.InlistLike(ex.Message, "Access to the path"))
                    {
                        Common.MsgOk("Bạn không có quyền thêm mới file nhưng danh mục HD vẫn cho phép tạo. Liên hệ PCNTT để được phân quyền copy file vào server");
                        System.Diagnostics.Process.Start("explorer.exe", @"\\192.168.1.18");
                    }
                }
                
            }
            
            //Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMHD", ref drEdit))
                return false;

			Common.CopyDataRow(drEdit, drCurrent);

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_HD", drEdit);

			return true;
		}

        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmHd"))
				e.Cancel = true;
		}
        //void txtMa_Hd_Goc_Validating(object sender, CancelEventArgs e)
        //{
        //    string strValue = txtMa_Hd_Goc.Text.Trim();
        //    bool bRequire = false;

        //    DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "");

        //    if (bRequire && drLookup == null)
        //        e.Cancel = true;

        //    if (drLookup == null)
        //    {
        //        txtMa_Hd_Goc.Text = string.Empty;
        //        //lbtTen_Dt.Text = string.Empty;
        //    }
        //    else
        //    {
        //        txtMa_Hd_Goc.Text = ((string)drLookup["Ma_Hd"]).Trim();
        //        lbtTen_Dt.Text = ((string)drLookup["Ten_Dt"]).Trim();
        //    }
        //}
        private void TxtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "Ma_Nh_Dt LIKE 'NV'");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv.Text = string.Empty;
                lbtTen_Dt_CbNv.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt_CbNv.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }
        }
        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = ((string)drLookup["Ma_Dt"]).Trim();
				lbtTen_Dt.Text = ((string)drLookup["Ten_Dt"]).Trim();
                strMa_Nh_Dt = ((string)drLookup["Ma_Nh_Dt"]).Trim();
                //
                string strTen_Dt_ = "";
                string strTen_Nh_Dt = DataTool.SQLGetNameByCode("R81DMNHDT", "Ma_Nh_Dt", "Ten_Nh_Dt", strMa_Nh_Dt);
                strTen_Dt_ += "( ";
                strTen_Dt_ += strMa_Nh_Dt + " - ";
                strTen_Dt_ += strTen_Nh_Dt + " )";
               
                lbtTen_Dt2.Text = strTen_Dt_;
                //lbtTen_Dt2.Text = ((string)drLookup["Ten_Dt"]).Trim();
                //
               

            }
		}
        private void TxtPTien_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtPTien.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("PTIENVC", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                
                txtPTien.Text = string.Empty;
            }
            else
            {
                
                txtPTien.Text = drLookup["PTienVC"].ToString();
            }
        }
        private void TxtNuocNK_XK_Validating(object sender, CancelEventArgs e)
        {

            string strValue = txtNuocNK_XK.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Quoc_Gia", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtNuocNK_XK.Text = string.Empty;


            }
            else
            {
                txtNuocNK_XK.Text = drLookup["Quoc_Gia"].ToString();


            }

        }
        private void TxtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
               
            }
            else
            {
                txtMa_Bp.Text = ((string)drLookup["Ma_Bp"]).Trim();
                
            }
        }
        void txtSo_Qd_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_QD.Text.Trim();
            if (strValue == string.Empty)
                return;
            bool bRequire = false;


            string strKeyValid = "";
            string strKeyFilter = string.Empty;
            strKeyFilter = "(CHARINDEX('" + txtMa_Dt.Text.Trim() + "',Nhom_Dt) > 0 OR Nhom_Dt LIKE '%*')" +
                //" AND (CHARINDEX('" + txtMa_Kho.Text.Trim() + "',Ma_Kho_List) > 0 OR Ma_Kho_List LIKE '%*')" +
                                 " AND Ma_CTrinh='" + txtMa_CTrinh.Text.Trim() + "' ";// +
            //" AND (Ngay_Het_Han >= '" + dteNgay_Ct.Text + "'  OR Ngay_Het_Han <='19000101')";


            DataRow drLookup = Lookup.ShowLookup("So_Qd_Dt", strValue, bRequire, strKeyFilter, strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = false;

            if (drLookup == null)
            {
                txtSo_QD.Text = string.Empty;
            }
            else
            {
                txtSo_QD.Text = drLookup["So_QD"].ToString();

            }
        }

        void txtMa_CTrinh_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_CTrinh.Text.Trim();
            bool bRequire = false;
            string strKeyValid = string.Empty;
            string strKeyFilter = string.Empty;
            //strKeyFilter = "Ma_Dt='" + drCurrent["Ma_Dt"].ToString()+"'  ";//+ "' AND So_QD='" + drCurrent["So_QD"].ToString() + "'

            DataRow drLookup = Lookup.ShowLookup("Ma_CTrinh", strValue, bRequire, strKeyFilter, strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_CTrinh.Text = string.Empty;

            }
            else
            {
                txtMa_CTrinh.Text = drLookup["Ma_CTrinh"].ToString();

            }
        }


        //void numThoi_Gian_Gh_Validating(object sender, CancelEventArgs e)
        //{
        //    DateTime dt = Convert.ToDateTime(dteNgay_Tu.Text);

        //    int So_Thang = Convert.ToInt32(numThoi_Gian_Gh.Value);
        //    try
        //    {
        //        dt = dt.AddDays(So_Thang);
        //    }
        //    catch (Exception)
        //    {

        //    }

        //    dteNgay_Gh.Text = dt.ToShortDateString();
        //}

        //void dteNgay_Tu_Validating(object sender, CancelEventArgs e)
        //{
        //    DateTime dt = Convert.ToDateTime(dteNgay_Tu.Text);

        //    int So_Thang = Convert.ToInt32(numThoi_Gian_Gh.Value);
        //    try
        //    {
        //        dt = dt.AddDays(So_Thang);
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    dteNgay_Gh.Text = dt.ToShortDateString();

        //}

        
		void txtTk_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk.Text = string.Empty;
				lbtTen_Tk.Text = string.Empty;
			}
			else
			{
				txtTk.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}
		}
		void txtMa_Nh_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Hd.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Hd", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Hd.Text = string.Empty;
				lbtTen_Nh_Hd.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Hd.Text = ((string)drLookup["Ma_Nh_Hd"]).Trim();
				lbtTen_Nh_Hd.Text = ((string)drLookup["Ten_Nh_Hd"]).Trim();
			}
		}

		void numTien_Tt_Nt0_Validated(object sender, EventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_Tt0_Validated(object sender, EventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_No_Nt0_Validated(object sender, EventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_No0_Validated(object sender, EventArgs e)
		{
			this.Tinh_Tien();
		}
        private void DteNgay_Ky_Validated(object sender, EventArgs e)
        {
            //cập nhật mã HD tự động
            if(enuNew_Edit != enuEdit.Edit)
            { 
                Hashtable ht = new Hashtable();
                ht.Add("NGAY_KY", dteNgay_Hd_Bd.Text);
                txtMa_Hd.Text = SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetMa_Hd(@Ngay_Ky)", ht, CommandType.Text).ToString();
            }
        }

        void btOpenFile_Click(object sender, EventArgs e)
		{
            
            
            if ((string)drEdit["File_Name"] == null)
            {
                Common.MsgOk("Không có file Attach");
                return;
            }
           
            string strPath = SQLExec.ExecuteReturnValue("SELECT File_Path FROM R04PO_RESOURCE where Ma_Hd = '"+ (string)drEdit["Ma_Hd"] +"'").ToString();
            object objFile = (object)strPath;
            //strPath = Path.Combine(strPath, (string)drEdit["File_Path"] + "." + (string)drEdit["Tag"]);
            if (objFile != null && objFile != DBNull.Value)// && ((Byte[])objFile).Length > 0)
            {
                FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);
                fileStream.Close();
                System.Diagnostics.Process.Start(strPath);
            }
		}

		void btAttack_Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.RestoreDirectory = true;
			fileDialog.Filter = "(*.PDF)|*.PDF|All files (*.*)|*.*";

			if (fileDialog.ShowDialog() != DialogResult.OK)
				return;

			this.objFile = (object)System.IO.File.ReadAllBytes(fileDialog.FileName);

			if (objFile != null)
			{
				drEdit["File_Tag"] = Path.GetExtension(fileDialog.FileName).ToLower();
                //drEdit["File_Content"] = (objFile == null) ? ((object)new byte[0]) : ((object)((byte[])objFile));
                drEdit["File_Name"] = Path.GetFileNameWithoutExtension(fileDialog.FileName) +  Path.GetExtension(fileDialog.FileName); ;
                txtFile_Name.Text = Path.GetFileNameWithoutExtension(fileDialog.FileName) + Path.GetExtension(fileDialog.FileName).ToLower();
                drEdit["File_Path"] = Path.GetDirectoryName(fileDialog.FileName);
			}
		}
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if ((bool)drEdit["Is_Nhan"] && this.enuNew_Edit == enuEdit.Edit)
            {
                txtMa_Dt.Enabled = false;
                txtSo_Hd.Enabled = false;
                
                if(Library.StrToDate(dteNgay_Hd_Kt.Text) < Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNow()")))
                    this.btgAccept.btAccept.Enabled = false;
            }
        }
    }
}