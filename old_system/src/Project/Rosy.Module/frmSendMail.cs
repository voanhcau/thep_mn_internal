using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Public;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;

namespace RosyModule
{
    public partial class frmSendMail : RosySystem.Customize.frmView
    {
       
        DataRow dr;
        public frmSendMail()
        {
            InitializeComponent();
            this.btSendMail.Click += new EventHandler(btSendMail_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
        }

        public void Load(DataRow drEdit)
        {
            
			dr = DataTool.SQLGetDataRowByID("R00EMAIL", "EMAIL_ID", "MAIL_DUYET_PYC");

			txtSubject.Text = (string)dr["Description"] + (string)drEdit["So_Ct"] + " ngày " + Convert.ToDateTime(drEdit["Ngay_Ct"]).ToShortDateString(); //"Những phiếu yêu cầu cần được duyệt !!!! ";

            txtToMail.Text = (string)dr["Email_To"];
            
            this.ShowDialog();

        }
        
        private  bool FormCheckValid()
        {
            if (txtToMail.Text == "")
            {
                Common.MsgOk(" ToMail is Null !!!");
                return false;
            }
            if (txtMessa.Text == "")
            {
                Common.MsgOk(" Messages is Null !!!");
                return false;
            }
            if (txtSubject.Text == "")
            {
                Common.MsgOk(" Subject is Null !!!");
                return false;
            }
            return true;
        }
        #region Sự kiện
        
		void btSendMail_Click(object sender, EventArgs e)
        {
            if (FormCheckValid() == false)
                return;

            string strFrmMail = (string)dr["Email_From"];
			string strPassWord = string.Empty;
			
			string strSQLExec = "SELECT dbo.fn_Decrypt((SELECT CheckPass FROM R00EMAIL WHERE Email_ID = @Email_ID))";
			object objPass = SQLExec.ExecuteReturnValue(strSQLExec, new string[] { "Email_ID" }, new object[] { "MAIL_DUYET_PYC" });

			if (objPass != DBNull.Value && (string)objPass != string.Empty)
				strPassWord = objPass.ToString();
			else
				strPassWord = string.Empty;

            if(Public.SendEmail(strFrmMail, strPassWord, txtToMail.Text.Trim(), "", "", txtSubject.Text, txtMessa.Text, ""))
				Common.MsgOk("Gửi Mail Thành Công !!!");

            this.Close();
        }

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}   

        #endregion
    }
}
