using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;


namespace RosyModule.Machinery
{
    public partial class frmPhuTungBTDK_Edit : RosySystem.Customize.frmEdit
    {
        public frmPhuTungBTDK_Edit()
        {
            InitializeComponent();

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
		

        }

	

        void btCancel_Click(object sender, EventArgs e)
        {
            this.isAccept = false;
            this.Close();
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                this.isAccept = true;
                this.Close();
            }

        }

        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);
            LoadTonKho();
            BindingLanguage();
            LoadDicName();

            this.ShowDialog();
        }

        private void LoadDicName()
        {
            if (txtMa_Vt.Text.Trim() != string.Empty)
            {
                lbtTen_Vt_Tb_Kt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
              
            }
            else
                lbtTen_Vt_Tb_Kt.Text = string.Empty;

           

            //txtMa_Vt.bUseAutoDropDown = true;
            //txtMa_Vt.strLookupKeyFilter = "Ma_Tb = '"+ drEdit["Ma_Tb"].ToString() +"'";
        }

        private bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtMa_Vt.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Vt") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            return bvalid;
        }

        public bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);

            if (!FormCheckValid())
                return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06PHUTUNGBTDK", ref drEdit))
                return false;

			
            return true;
        }


        void txtMa_Vt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt.Text.Trim();
            bool brequire = false;
            string strKey = "Ma_Tb = '" + drEdit["Ma_Tb"].ToString() + "'";
            //DataRow drLookup = Lookup.ShowLookup("Ma_Vt_bttb", strValue, brequire, strKey);
            DataRow drLookup = Lookup.ShowLookup("Ma_Vt_BTTB", strValue, brequire, strKey, null);
            if (brequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt.Text = string.Empty;
                lbtTen_Vt_Tb_Kt.Text = string.Empty;
            }
            else
            {
                txtMa_Vt.Text = (string)drLookup["Ma_Vt"];
                lbtTen_Vt_Tb_Kt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text);
               
                LoadTonKho();
            }
        }

        private void LoadTonKho()
        {
            //Hashtable ht = new Hashtable();
            //ht.Add("NGAY_CT", DateTime.Now);
            //ht.Add("MA_KHO", string.Empty);
            //ht.Add("MA_VT", txtMa_Vt.Text.Trim());
            //ht.Add("STT", string.Empty);
            //ht.Add("MA_DVCS", Element.sysMa_DvCs);

            //double dbTonCuoi = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetTonCuoi(@Ngay_Ct, @Ma_Kho, @Ma_Vt, @Stt, @Ma_Dvcs)", ht, CommandType.Text));

           
        }
        protected override void OnShown(EventArgs e)
        {
            if (enuNew_Edit == enuEdit.Edit)
                lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
            else
                lblLog.Text = "";
        }
    }
}
