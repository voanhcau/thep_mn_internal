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

namespace RosyModule
{
    public partial class frmSendMailXNCN : RosySystem.Customize.frmEdit
	{
		#region Methods

        public frmSendMailXNCN()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            btPath.Click += new EventHandler(btPath_Click);
		}


        public void Load()
        {
           
            this.Show();
        }
		public void Load(string strPath)
		{
            //this.enuNew_Edit = enuNew_Edit;
            //this.drEdit = drEdit;
            //this.Tag = (char)enuNew_Edit + "," + this.Tag;

            //Common.ScaterMemvar(this, ref drEdit);
            txtPath.Text = strPath;

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
		
            if (txtPath.Text == "")
            {
                Common.MsgOk("Yêu cầu chọn đường dẫn chứa file attach");
                return false;
            }
            string[] fileListCheck = Directory.GetFiles(txtPath.Text, "*.pdf");
            if (fileListCheck.Length == 0)
            {
                Common.MsgOk("Yêu cầu kiểm tra lại thư mục rỗng, không có file CNXX đã ký số!!!");
                return false;
            }
			//GỬI MAIL
            try
            {
                string[] fileList = Directory.GetFiles(txtPath.Text,"*.pdf");

                string strEmail = string.Empty;
                string strMa_So_Thue = string.Empty;
                string strMa_So_Thue_List = string.Empty;
                string strNgay_HD_List = string.Empty;
                string strFileName = string.Empty;
                string strNgay_HD = string.Empty;
                int iEMST; int iSMST;
                int i = 0;int j = 0;
                bool bAuto = false;
                foreach (string fileName in fileList)
                {
                    strFileName = Path.GetFileName(fileName).Trim();
                    
                    //lấy chiều dài MST khách hàng áp dụng cho CNXX
                    iEMST = strFileName.IndexOf(".pdf");
                    iSMST = strFileName.LastIndexOf("_");
                    strMa_So_Thue = strFileName.ToString().Substring(iSMST + 1, iEMST - iSMST - 1);
                    //lấy danh sách các khách hàng được gửi CNXX
                    if (!Common.Inlist(strMa_So_Thue, strMa_So_Thue_List))
                    {
                        strMa_So_Thue_List += strMa_So_Thue + ","; i++;
                    }
                    
                    //strNgay_HD = strFileName.ToString().Substring(0, 8);
                    //if (!Common.Inlist(strNgay_HD, strNgay_HD_List))
                    //{
                    //    strNgay_HD_List += strNgay_HD + ",";
                    //}
                }
                // xử lý các mã số thuế trong danh sách
                while (j < i)
                {
                    iEMST = strMa_So_Thue_List.IndexOf(",");
                    strMa_So_Thue = strMa_So_Thue_List.Substring(0, iEMST);

                    //lấy email
                    string strMa_Dt = DataTool.SQLGetNameByCode("R81DMDT", "Ma_So_Thue", "Ma_Dt", strMa_So_Thue);
                    strEmail = SQLExec.ExecuteReturnValue("SELECT Email FROM R81DMDT_XNCN WHERE Ma_Dt = '" + strMa_Dt + "' AND Ma_Dt + CAST(Ngay_Ap AS VARCHAR(11)) IN (SELECT Ma_Dt + CAST(MAX(Ngay_Ap) AS VARCHAR(11)) FROM R81DMDT_XNCN  WHERE Ma_Dt = '" + strMa_Dt + "' GROUP BY Ma_Dt)").ToString();
                    string strTen_Dt = DataTool.SQLGetNameByCode("R81DMDT", "Ma_So_Thue", "Ten_Dt", strMa_So_Thue);
                    if (strEmail == string.Empty)
                    {
                        Common.MsgOk("Địa chỉ email của khách hàng chưa được khai báo. Chức năng gửi mail tự động không được tiếp tục cho khách hàng " + strTen_Dt + "");
                        return false;
                    }
                    if(rdbAuto.Checked)
                        bAuto = true;

                    //Voucher.CreateFileZip_CNXX(txtPath.Text, strMa_So_Thue);
                    Voucher.OpenOutLook_BBXNCN(strEmail, txtSub.Text, txtContent.Text, txtPath.Text, strMa_So_Thue, bAuto);

                  

                    strMa_So_Thue_List = strMa_So_Thue_List.Replace(strMa_So_Thue + ",","");
                    j++;
                }
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
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

        private void frmSendMailCNXX_Load(object sender, EventArgs e)
        {

        }

       
	}
}
