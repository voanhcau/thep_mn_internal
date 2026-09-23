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
    public partial class frmVTDP_Edit : RosySystem.Customize.frmEdit
    {
        public frmVTDP_Edit()
        {
            InitializeComponent();
            txtMa_Vt_Dp.Validating += new CancelEventHandler(txtMa_Vt_Dp_Validating);
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            this.isAccept = false;
            this.Close();
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                this.isAccept = true;
                this.Close();
            }
        }

        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.enuNew_Edit = enuNew_Edit;
            this.drEdit = drEdit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);
            LoadTonKho();
            BindingLanguage();
            LoadDicName();

            this.ShowDialog();
        }

        void txtMa_Vt_Dp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Dp.Text.Trim();
            bool brequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, brequire, string.Empty);

            if (brequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Dp.Text = string.Empty;
                lbtTen_Vt_Dp.Text = string.Empty;
            }
            else
            {
                txtMa_Vt_Dp.Text = (string)drLookup["Ma_Vt"];
                lbtTen_Vt_Dp.Text = (string)drLookup["Ten_Vt"];
                lbtDvt.Text = (string)drLookup["Dvt"];
                LoadTonKho();
            }
        }

        private void LoadDicName()
        {
            if (txtMa_Vt_Dp.Text != string.Empty)
            {
                lbtTen_Vt_Dp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Dp.Text.Trim());
            }
            else
                lbtTen_Vt_Dp.Text = string.Empty;

            if (txtMa_Vt_Tb.Text != string.Empty)
                lbtTen_Vt_Tb.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Tb.Text.Trim());
            else
                lbtTen_Vt_Tb.Text = string.Empty;
        }

        private bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtMa_Vt_Dp.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Vt_Dp") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            return bvalid;
        }

        private void LoadTonKho()
        {
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT", DateTime.Now);
            ht.Add("MA_KHO", string.Empty);
            ht.Add("MA_VT", txtMa_Vt_Dp.Text.Trim());
            ht.Add("STT", string.Empty);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);

            double dbTonCuoi = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetTonCuoi(@Ngay_Ct, @Ma_Kho, @Ma_Vt, @Stt, @Ma_Dvcs)", ht, CommandType.Text));

            numTon_Kho.Value = dbTonCuoi;
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

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06VTDP", ref drEdit))
                return false;

            return true;
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
