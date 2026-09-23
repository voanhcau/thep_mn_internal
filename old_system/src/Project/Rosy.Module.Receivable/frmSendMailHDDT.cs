using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;
using System.IO;

namespace RosyModule.Receivable
{
    public partial class frmSendMailHDDT : RosySystem.Customize.frmEdit
	{
		#region Methods

        public frmSendMailHDDT()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            btPath.Click += new EventHandler(btPath_Click);
		}


        public void Load()
        {
            string strMa_Dt_CbNv = SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_ID = '"+ Element.sysUser_Id +"'").ToString();
            DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", strMa_Dt_CbNv);
            txtAcc.Text = drDmDt["Email"].ToString();

            
          
            this.ShowDialog();
        }
		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			
		}

		public bool FormCheckValid()
		{
            return true;
			
		}

		public bool Save()
		{
			// kiểm tra mail gửi
            if (txtAcc.Text == "")
            {
                Common.MsgOk("Yêu cầu nhập thông tin người gửi");
                return false;
            }

            if (txtPath.Text == "")
            {
                Common.MsgOk("Yêu cầu chọn đường dẫn hóa đơn đã ký số");
                return false;
            }
            string[] fileList = Directory.GetFiles(txtPath.Text, "*.pdf");
            if (fileList.Length == 0)
            {
                Common.MsgOk("Yêu cầu kiểm tra lại thư mục rỗng, không có file hóa đơn!!!");
                return false;
            }
			//Luu xuong CSDL
            return true;
		}

		#endregion

		#region Events

        void btPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;

            //folderBrowserDialog.
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;


            txtPath.Text = folderBrowserDialog.SelectedPath;

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
			this.isAccept = false;
			this.Close();
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

          
		}

       
	}
}
