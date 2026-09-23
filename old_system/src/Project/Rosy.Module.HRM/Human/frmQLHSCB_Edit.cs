using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Public;
using System.IO;

namespace RosyModule.HRM
{
	public partial class frmQLHSCB_Edit : frmEdit
	{
        #region Phuong thuc
        
        object objFile = null;
        string strFilePathNew = string.Empty;
        public frmQLHSCB_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            this.btUpload.Click += new EventHandler(btUpload_Click);
            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Chuc_Danh.Validating += new CancelEventHandler(txtMa_Chuc_Danh_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
		}

      

       

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

            
			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Dt_CbNv.bUseAutoDropDown = true;

			//txtMa_Dt
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

            //txtMa_Dt
            if (txtMa_Chuc_Danh.Text.Trim() != string.Empty)
                lbtTen_Chuc_Danh.Text = SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'CHUC_DANH_QLHSCB' AND Type_ID = '"+ txtMa_Chuc_Danh.Text +"' ").ToString();
            else
                lbtTen_Chuc_Danh.Text = string.Empty;
           
		}
        void txtMa_Chuc_Danh_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Chuc_Danh.Text.Trim();
            bool bRequire = false;
            string strFilter = "Type = 'CHUC_DANH_QLHSCB'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Chuc_Danh", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Chuc_Danh.Text = string.Empty;
                lbtTen_Chuc_Danh.Text = string.Empty;
            }
            else
            {
                txtMa_Chuc_Danh.Text = drLookup["Type_ID"].ToString();
                lbtTen_Chuc_Danh.Text = drLookup["Type_Name"].ToString();
            }
        }
        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv.Text = string.Empty;
                lbtTen_Dt_CbNv.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
            }
        }
        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
            }
            else
            {
                txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
                lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
            }
        }
		public bool FormCheckValid()
		{
			bool bvalid = true;


            if (dteNgay_Qd.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ngay_TNLD") + " " +
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
            {
               
               
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            }
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();


            //Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R09HSQLCB", ref drEdit))
                return false;
            else
                Voucher.Attach_File_Dm("PATH_QLHSCB", txtMa_Dt_CbNv.Text, strFilePathNew, objFile);

            return true;
		}

        void EditResource()
        {
          
            if (!Element.sysIs_Admin && enuNew_Edit == enuEdit.Edit)
            {
                string strCreate_User = (string)drEdit["Create_Log"];

                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                    if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                    {
                        Common.MsgOk("Bạn không có quyền upload file vào phiếu của người không được phân quyền");
                        return;
                    }

                }
            }


            
            ////Xác định đường dẫn tại server
            string strPath = Parameters.GetParaValue("PATH_QLHSCB").ToString();
            
            strPath = Path.Combine(strPath, txtMa_Dt_CbNv.Text);
            ////Kiểm tra Path có tồn tại hay chưa, tạo thư mục chứa các file
         
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "All files (*.*)|*.*";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            this.objFile = (object)System.IO.File.ReadAllBytes(fileDialog.FileName);
            strFilePathNew = fileDialog.FileName;
            //copy file lên server
            var fileName = fileDialog.FileName;
           
            //Lưu đường dẫn file cần copy
            txtFile_Path.Text = Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName);
           

            // Kiểm tra trùng tên file va Stt

            if (DataTool.SQLCheckExist("R09HSQLCB", new string[] { "File_Path", "Ma_Dt_CbNv" }, new object[] { txtFile_Path.Text, txtMa_Dt_CbNv.Text }))
            {
                Common.MsgOk("Đường dẫn " + txtFile_Path.Text + " của nhân viên "+ txtMa_Dt_CbNv.Text +" đã tồn tại. Yêu cầu kiểm tra lại!!!");
                return;
            }
          
            


        }
		#endregion

		#region Su kien
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
        void btUpload_Click(object sender, EventArgs e)
        {
            EditResource();
        }
		#endregion
	}
}
