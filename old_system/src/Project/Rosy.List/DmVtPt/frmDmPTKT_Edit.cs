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


namespace RosyList
{
    public partial class frmDmPTKT_Edit : RosySystem.Customize.frmEdit
    {
        string strLoai_VtPt = string.Empty;

        public frmDmPTKT_Edit()
        {
            InitializeComponent();

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Tb.Validating += new CancelEventHandler(txtMa_Tb_Validating);
		

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

        public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strLoai_VtPt)
        {
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;
            
            this.strLoai_VtPt = strLoai_VtPt;

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

            if (txtMa_Tb.Text.Trim() != string.Empty)
                lbtTen_Vt_Tb.Text = DataTool.SQLGetNameByCode("R06DMTB", "Ma_Tb", "Ten_Tb", txtMa_Tb.Text.Trim());
            else
                lbtTen_Vt_Tb.Text = string.Empty;

            txtMa_Tb.bUseAutoDropDown = true;
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
            
            drEdit["Loai_VtPt"] = "1";

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06VTTB", ref drEdit))
                return false;

			
            return true;
        }


        void txtMa_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Tb.Text.Trim();
            bool brequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Tb", strValue, brequire,"");

            if (brequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Tb.Text = string.Empty;
                lbtTen_Vt_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Tb.Text = (string)drLookup["Ma_Tb"];
                lbtTen_Vt_Tb.Text = (string)drLookup["Ten_Tb"];
               
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
            //Kiểm tra user sửa dữ liệu
            if (enuNew_Edit == enuEdit.Edit)
            {
                string strCreate_User = (string)drEdit["Create_Log"];

                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                    if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
                    {
                        if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                        {
                            this.btgAccept.btAccept.Enabled = false;
                            return;
                        }
                    }
                }
            }

            if (enuNew_Edit == enuEdit.Edit)
                lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
            else
                lblLog.Text = "";
        }
    }
}
