using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Public;

namespace RosyModule.Salary
{
    public partial class frmNVKChamCong_Edit : RosySystem.Customize.frmEdit
    {
        string strMa_Bp = string.Empty;
        string strMa_Bp_Ct = string.Empty;
        bool bLock1 = false;
        bool bLock2 = false;
        public frmNVKChamCong_Edit()
        {
            InitializeComponent();

            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtTinh_Trang_Cong.Validating += new CancelEventHandler(txtTinh_Trang_Cong_Validating);
            txtMa_TNLD.Validating += new CancelEventHandler(txtMa_TNLD_Validating);

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }





        new public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strMa_Bp, string strMa_Bp_Ct)
        {
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            if (strMa_Bp.StartsWith("*"))
                this.strMa_Bp = "";
            else
                this.strMa_Bp = strMa_Bp;

            this.strMa_Bp_Ct = strMa_Bp_Ct;


            Common.ScaterMemvar(this, ref drEdit);
            if (enuNew_Edit == enuEdit.New)
            {
                dteTu_Ngay.Text = Library.DateToStr(DateTime.Now);
                dteDen_Ngay.Text = Library.DateToStr(DateTime.Now);
            }
            BindingLanguage();
            LoadDicName();

            this.ShowDialog();
        }

        private void LoadDicName()
        {
            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.strLookupKeyFilter = "Ma_Dt LIKE 'M%' AND (Ma_Bp = '" + strMa_Bp + "' OR '" + strMa_Bp + "' = '') AND (Ma_Bp_Ct = '" + strMa_Bp_Ct + "' OR '" + strMa_Bp_Ct + "' = '')";

            if (txtMa_Dt_CbNv.Text != string.Empty)
            {

                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
            }
            else
            {
                lbtTen_Dt_CbNv.Text = string.Empty;

            }
            if (txtTinh_Trang_Cong.Text != string.Empty)
            {

                lbtTinh_Trang_Cong.Text = SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE TYPE = 'TRANG_THAI_CONG' AND Type_ID = '" + txtTinh_Trang_Cong.Text + "'").ToString();
            }
            else
            {
                lbtTinh_Trang_Cong.Text = string.Empty;

            }
            if (txtMa_TNLD.Text != string.Empty)
            {

                lbtTen_TNLD.Text = DataTool.SQLGetNameByCode("R09TNLD", "Ma_TNLD", "Ten_TNLD", txtMa_TNLD.Text.Trim());
            }
            else
            {
                lbtTen_TNLD.Text = string.Empty;

            }

        }

        private bool CheckFormValid()
        {
            if (Convert.ToDateTime(dteTu_Ngay.Text) > Convert.ToDateTime(dteDen_Ngay.Text))
            {
                Common.MsgCancel("Đến ngày không nhỏ hơn từ ngày!!!");
                return false;
            }
            if (!DataTool.SQLCheckExist("R81DMDT", new string[] { "Ma_Dt", "Ngay_Nghi_Lam" }, new object[] { txtMa_Dt_CbNv.Text, "19000101" }))
            {
                if (!Common.MsgYes_No("Mã nhân viên " + txtMa_Dt_CbNv.Text + " đã nghỉ việc. Bạn có tiếp tục chấm công không ?", "N"))
                    return false;
            }
            if (enuNew_Edit == enuEdit.New && DataTool.SQLCheckExist("R10TTCHAMCONG", new string[] { "Ma_Dt_CbNv", "Tu_Ngay" }, new object[] { txtMa_Dt_CbNv.Text, dteTu_Ngay.Text }))
            {
                if (!Common.MsgOk("Mã nhân viên " + txtMa_Dt_CbNv.Text + " đã có dữ liệu nhập lý do không chấm công. Vui lòng kiểm tra lại."))
                    return false;
            }
            if (this.txtTinh_Trang_Cong.Text == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Tinh_Trang_Cong") + " " + Languages.GetLanguage("Not_Empty"));
                return false;
            }
            if (this.txtTinh_Trang_Cong.Text == "T" && txtMa_TNLD.Text == "")
            {
                Common.MsgCancel(Languages.GetLanguage("Ma_TNLD") + " " + Languages.GetLanguage("Not_Empty"));
                return false;
            }
            if (Common.Inlist(this.txtTinh_Trang_Cong.Text, (string)RosySystem.Library.Parameters.GetParaValue("DIA_DIEM_CONG")) && txtDia_Diem_Cong.Text == "")
            {
                Common.MsgCancel(Languages.GetLanguage("Dia_Diem_Cong") + " " + Languages.GetLanguage("Not_Empty"));
                return false;
            }
            //kiểm tra nhập liệu trong tháng
            DateTime dteNgayCuoiThang = Voucher.GetLastDayOfMonth(Convert.ToDateTime(dteTu_Ngay.Text));
            if (this.txtTinh_Trang_Cong.Text != "P" && Convert.ToDateTime(dteDen_Ngay.Text) > dteNgayCuoiThang)
            {
                Common.MsgCancel("Bạn chỉ được nhập đến ngày cuối tháng. Vui lòng kiểm tra lại trước khi lưu!!!");
                return false;
            }
            //KIỂM TRA ĐÃ KHÓA BẢNG CÔNG CHƯA
            bool bLock1 = Voucher.LockCongLuong("Lock_Cong", Convert.ToDateTime(dteTu_Ngay.Text).Year, Convert.ToDateTime(dteTu_Ngay.Text).Month,
                    Library.StrToDate(dteTu_Ngay.Text), Library.StrToDate(dteDen_Ngay.Text));
           // bool bLock2 = Voucher.LockCongLuong("Lock_Cong", Convert.ToDateTime(dteDen_Ngay.Text).Year, Convert.ToDateTime(dteDen_Ngay.Text).Month);
            if (bLock1)
            {
                Common.MsgOk("Dữ liệu đã bị khóa tháng " + Convert.ToDateTime(dteTu_Ngay.Text).Month + " liên lạc PTCHC để được mở khóa !!!!");
                return false;
            }
            //{
            //     Common.MsgCancel("Bảng công của bộ phận bạn đã bị khóa. Vui lòng liên hệ PTCHC để được mở khóa");
            //    return false;
            //}
            return true;
        }

        private bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);

            if (!this.CheckFormValid())
                return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            { drEdit["Create_Log"] = Common.GetCurrent_Log(); drEdit["LastModify_Log"] = ""; }
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R10TTCHAMCONG", ref drEdit))
                return false;

            return true;
        }
        void txtMa_TNLD_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_TNLD.Text.Trim();
            bool bRequire = false;
            DataRow drLookup = Lookup.ShowLookup("Ma_TNLD", strValue, bRequire, "Ma_Dt_CbNv = '" + txtMa_Dt_CbNv.Text + "'", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_TNLD.Text = string.Empty;
                lbtTen_TNLD.Text = string.Empty;
            }
            else
            {
                txtMa_TNLD.Text = drLookup["Ma_TNLD"].ToString();
                lbtTen_TNLD.Text = drLookup["Ten_TNLD"].ToString();
            }
        }
        void txtTinh_Trang_Cong_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTinh_Trang_Cong.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "TRANG_THAI_CONG");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'TRANG_THAI_CONG'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTinh_Trang_Cong.Text = string.Empty;
                lbtTinh_Trang_Cong.Text = string.Empty;
            }
            else
            {
                txtTinh_Trang_Cong.Text = drLookup["Type_ID"].ToString();
                lbtTinh_Trang_Cong.Text = drLookup["Type_Name"].ToString();
            }
        }
        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            if (!txtMa_Dt_CbNv.bTextChange)
                return;

            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "Ma_Dt LIKE 'M%' AND (Ma_Bp = '" + strMa_Bp + "' OR '" + strMa_Bp + "' = '') AND (Ma_Bp_Ct = '" + strMa_Bp_Ct + "' OR '" + strMa_Bp_Ct + "' = '')");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv.Text = string.Empty;
                lbtTen_Dt_CbNv.Text = string.Empty;

            }
            else
            {
                txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();

            }
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                this.isAccept = true;
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
            bLock1 = Voucher.LockCongLuong("Lock_Cong", Convert.ToDateTime(dteTu_Ngay.Text).Year, Convert.ToDateTime(dteTu_Ngay.Text).Month, 
                    Library.StrToDate(dteTu_Ngay.Text), Library.StrToDate(dteDen_Ngay.Text));
            
            if (enuNew_Edit == enuEdit.Edit && (bLock1 ))
                btgAccept.Enabled = false;
        }
    }
}
