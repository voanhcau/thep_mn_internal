using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    public partial class frmBaoTri_Edit : RosySystem.Customize.frmEdit
    {
        public frmBaoTri_Edit()
        {
            InitializeComponent();
            txtMa_Dt_Cbnv_Bt.Validating += new CancelEventHandler(txtMa_Dt_Cbnv_Bt_Validating);
            txtMa_Vt_Tb.Validating += new CancelEventHandler(txtMa_Vt_Tb_Validating);
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

        void txtMa_Vt_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Tb.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Ts", strValue, bRequire, string.Empty);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Tb.Text = string.Empty;
                lbtTen_Vt_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Vt_Tb.Text = (string)drLookup["Ma_Vt"];
                lbtTen_Vt_Tb.Text = (string)drLookup["Ten_Vt"];
            }
        }

        void txtMa_Dt_Cbnv_Bt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_Cbnv_Bt.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_Cbnv", strValue, bRequire, string.Empty);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_Cbnv_Bt.Text = string.Empty;
                lbtTen_Dt_Cbnv_Bt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_Cbnv_Bt.Text = (string)drLookup["Ma_Dt"];
                lbtTen_Dt_Cbnv_Bt.Text = (string)drLookup["Ten_Dt"];
            }
        }

        public void Load()
        {
            this.enuNew_Edit = enuNew_Edit;
            this.drEdit = drEdit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);

            if (enuNew_Edit == enuEdit.New)
                dteNgay_Sua_Chua.Text = Library.DateToStr(DateTime.Now);

            rdbTrong_Ke_Hoach.Checked = true;

            rdbBao_Tri.Checked = true;
            
            LoadDicName();
            BindingLanguage();

            this.ShowDialog();
        }

        private void LoadDicName()
        {
            if (txtMa_Vt_Tb.Text.Trim() != string.Empty)
                lbtTen_Vt_Tb.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Tb.Text.Trim());
            else
                lbtTen_Vt_Tb.Text = string.Empty;

            if (txtMa_Dt_Cbnv_Bt.Text.Trim() != string.Empty)
                lbtTen_Dt_Cbnv_Bt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_Cbnv_Bt.Text.Trim());
            else
                lbtTen_Dt_Cbnv_Bt.Text = string.Empty;

            if (txtMa_Bp.Text.Trim() != string.Empty)
                txtMa_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            else
                txtMa_Bp.Text = string.Empty;
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

            drEdit["Trong_Ke_Hoach"] = rdbTrong_Ke_Hoach.Checked;
            drEdit["TypeOfMaintenance"] = rdbBao_Tri.Checked ? "Bảo trì" : "Thay thế";

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06BTSC", ref drEdit))
                return false;

            //this.SavePicture();

            return true;
        }

        private bool FormCheckValid()
        {
            bool bvalid = true;
            if (txtMa_Vt_Tb.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Vt_Tb") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            return bvalid;
        }

    }
}
