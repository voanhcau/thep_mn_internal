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
using RosySystem.Public;


namespace RosyModule.Machinery
{
    public partial class frmCreateBTTBDK : RosySystem.Customize.frmEdit
    {
		public string strSo_Ct = string.Empty;

        public frmCreateBTTBDK()
        {
            InitializeComponent();
          
            this.btExit.Click += new EventHandler(btExit_Click);
            this.btSave.Click += new EventHandler(btSave_Click);
            txtMa_DotBT.Validating += new CancelEventHandler(txtMa_DotBT_Validating);
        }
 
		public void Load()
        {
           
            numNam.Value = Element.sysWorkingYear;

            this.drEdit = drEdit;
            //Common.ScaterMemvar(this, ref drEdit);
            
           
            this.ShowDialog();
        }

        private bool FormCheckValid()
        {
            
            if (txtMa_DotBT.Text=="")
            {
                Common.MsgOk("Bạn phải nhập số chứng từ cho phiếu sẽ tạo!!!");
                return false;
            }

            return true;
        }


        private bool Save()
        {
            if (!FormCheckValid())
                return false;
            Hashtable ht = new Hashtable();
            ht.Add("NAM", numNam.Value);
            ht.Add("MA_DOTBT", txtMa_DotBT.Text);
            

            SQLExec.Execute("sp_UpdateKHBTDK", ht, CommandType.StoredProcedure);
            return true;
        }
        void txtMa_DotBT_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_DotBT.Text.Trim();
            bool bRequire = false;
            string strKey = string.Empty;


            DataRow drLookup = Lookup.ShowLookup("Ma_DotBT", strValue, bRequire, strKey);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_DotBT.Text = string.Empty;
                lbtTen_DotBT.Text = string.Empty;
            }
            else
            {
                txtMa_DotBT.Text = drLookup["Ma_DotBT"].ToString();
                lbtTen_DotBT.Text = drLookup["Ngay_Ct1"].ToString() + " đến " + drLookup["Ngay_Ct2"].ToString();

            }
        }
        void btSave_Click(object sender, EventArgs e)
        {
            if (this.FormCheckValid())
            {
                this.strSo_Ct = txtMa_DotBT.Text;
                this.isAccept = true;
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
