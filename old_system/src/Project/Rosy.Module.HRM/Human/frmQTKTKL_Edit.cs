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
using System.IO;

namespace RosyModule.HRM
{
	public partial class frmQTKTKL_Edit : frmEdit
	{
		#region Phuong thuc
        
        string strLoai_KTKL;

		public frmQTKTKL_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            this.btUpload.Click += new EventHandler(btUpload_Click);
		}

       
		public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strLoai_KTKL)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strLoai_KTKL = strLoai_KTKL;

			Common.ScaterMemvar(this, ref drEdit);

            if (enuNew_Edit == enuEdit.New)
            {
                txtFile_Path.Text = "";

            }
			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//txtMa_Dt
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				lbtTen_Dt_CbNv.Text = string.Empty;
		}

		public bool FormCheckValid()
		{
			bool bvalid = true;
			//if (txtHo_Ten.Text.Trim() == string.Empty)
			//{
			//    Common.MsgOk(Languages.GetLanguage("Ho_Ten") + " " +
			//                  Languages.GetLanguage("Not_Null"));
			//    return false;
			//}

			return bvalid;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;
            drEdit["Loai_KTKL"] = strLoai_KTKL;
			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R09QTKTKL", ref drEdit))
				return false;

			return true;
		}
		#endregion

		#region Su kien
        void btUpload_Click(object sender, EventArgs e)
        {
            EditResource();
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


            string strPath = string.Empty;
            string strLoai = string.Empty;
            //Xác định đường dẫn tại server
            strPath = Parameters.GetParaValue("PATH_QLHSCB").ToString();
            //Xác định mã nhân viên
            strLoai = txtMa_Dt_CbNv.Text;
            strPath = Path.Combine(strPath, strLoai);
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
            //nếu ko tồn tại thì ko copy
            if (!File.Exists(Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName)))
                File.Copy(fileName, Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName));


            //Lưu đường dẫn file cần copy
            txtFile_Path.Text = Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName);


            // Kiểm tra trùng tên file va Stt

            if (DataTool.SQLCheckExist("R09QTKTKL", new string[] { "File_Path", "Ma_Dt_CbNv" }, new object[] { txtFile_Path.Text, txtMa_Dt_CbNv.Text }))
            {
                Common.MsgOk("Đường dẫn " + txtFile_Path.Text + " của nhân viên " + txtMa_Dt_CbNv.Text + " đã tồn tại. Yêu cầu kiểm tra lại!!!");
                return;
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
		#endregion
	}
}
