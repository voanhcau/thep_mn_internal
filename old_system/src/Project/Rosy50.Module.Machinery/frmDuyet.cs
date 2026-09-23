using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Element;


namespace RosyModule.Machinery
{
    public partial class frmDuyet : RosySystem.Customize.frmEdit
    {
        public frmDuyet()
        {
            InitializeComponent();
            chkDuyet.CheckedChanged += new EventHandler(chkDuyet_CheckedChanged);
            this.btExit.Click += new EventHandler(btExit_Click);
            this.btSave.Click += new EventHandler(btSave_Click);
        }

        void chkDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDuyet.Checked)
                dteNgay_Duyet.Text = Library.DateToStr(DateTime.Now);
            else
                dteNgay_Duyet.Text = string.Empty;

            btSave.Enabled = true;
        }

        public void Load(DataRow drEdit)
        {
            this.drEdit = drEdit;
            Common.ScaterMemvar(this, ref drEdit);
            chkDuyet.Enabled = !chkDuyet.Checked;

            btSave.Enabled = false;
            this.ShowDialog();
        }

        private bool FormCheckValid()
        {
            if (dteNgay_Duyet.IsNull)
            {
                Common.MsgCancel(Languages.GetLanguage("Ngay_Ct,Not_Null"));
                return false;
            }

            return true;
        }


        private bool Save()
        {
            string strSQLExec = string.Empty;
            Hashtable htPara;

            //Lưu phần Checked vào R80Ph
            if (chkDuyet.Enabled)
            {
                htPara = new Hashtable();
                htPara.Add("DUYET", chkDuyet.Checked);
                htPara.Add("NGAY_DUYET", Library.StrToDate(dteNgay_Duyet.Text));
                htPara.Add("IDENT00", drEdit["Ident00"]);

                strSQLExec = "UPDATE R06BTSC SET Duyet = @Duyet, Ngay_Duyet = @Ngay_Duyet WHERE Ident00 = @Ident00";

                if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                {
                    drEdit["Duyet"] = chkDuyet.Checked;
                    if (drEdit.Table.Columns.Contains("Hoan_Thanh"))
                        drEdit["Hoan_Thanh"] = chkDuyet.Checked;
                }
            }

            return true;
        }

        void btSave_Click(object sender, EventArgs e)
        {
            if (this.FormCheckValid())
            {
                this.Save();
                this.Close();
            }
        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
