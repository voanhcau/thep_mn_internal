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

namespace RosyModule.Inventory
{
    public partial class frmKiemKe_Edit : RosySystem.Customize.frmEdit
    {
        #region Methods

        public frmKiemKe_Edit()
        {
            InitializeComponent();

            txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
            txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

        public void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.enuNew_Edit = enuNew_Edit;
            this.drEdit = drEdit;

            Common.ScaterMemvar(this, ref drEdit);

            txtMa_Kho.bUseAutoDropDown = true;
            txtMa_Vt.bUseAutoDropDown = true;

            this.ShowDialog();
        }

        public bool FormCheckValid()
        {
            if (txtMa_Kho.Text.Trim() == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Ma_Kho") + " " + Languages.GetLanguage("Cannot_Empty"));
                return false;
            }

            if (txtMa_Vt.Text.Trim() == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Ma_Vt") + " " + Languages.GetLanguage("Cannot_Empty"));
                return false;
            }

            if (dteNgay_KK.IsNull)
            {
                Common.MsgCancel(Languages.GetLanguage("Date") + " " + Languages.GetLanguage("Cannot_Empty"));
                return false;
            }

            if (numSo_Luong.Value == 0)
            {
                Common.MsgCancel(Languages.GetLanguage("So_Luong") + " " + Languages.GetLanguage("Cannot_Empty"));
                return false;
            }
            return true;
        }

        public bool Save()
        {
            //if (!Common.CheckDataLocked(Library.StrToDate(txtNgay_Ct.Text)))
            //{
            //    Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
            //    return false;
            //}

            Common.GatherMemvar(this, ref drEdit);

            if (!FormCheckValid())
                return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R05KIEMKE", ref drEdit))
                return false;

            return true;
        }

        #endregion

        #region Events

        void txtMa_Kho_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Kho.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, null, null);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Kho.Text = string.Empty;
                lbtTen_Kho.Text = string.Empty;
            }
            else
            {
                txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
                lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
            }
        }

        void txtMa_Vt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, null, null);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt.Text = string.Empty;
                lbtTen_Vt.Text = string.Empty;
            }
            else
            {
                txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
                lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
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
            this.isAccept = false;
            this.Close();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //if (this.enuNew_Edit == enuEdit.Edit)
            //{
            //    if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
            //    {
            //        this.txtNgay_Ct.Enabled = false;
            //        this.btgAccept.btAccept.Enabled = false;

            //        return;
            //    }
            //}
        }

        private void rsLabel5_Click(object sender, EventArgs e)
        {

        }

        private void frmKiemKe_Edit_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
