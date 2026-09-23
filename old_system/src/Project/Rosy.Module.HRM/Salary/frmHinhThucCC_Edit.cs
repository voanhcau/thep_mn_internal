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
using System.Collections;

namespace RosyModule.Salary
{
	public partial class frmHinhThucCC_Edit : RosySystem.Customize.frmEdit
	{
        string strMa_Bp = string.Empty;
        DataRow drCurrent;
        public frmHinhThucCC_Edit()
		{
			InitializeComponent();
            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Bp_Ct.Validating += new CancelEventHandler(txtMa_Bp_Ct_Validating);
            txtMuc_BDDH.Validating += new CancelEventHandler(txtMuc_BDDH_Validating);
            txtHT_CC.Validating += new CancelEventHandler(txtHT_CC_Validating);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

             

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strMa_Bp)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);
            this.strMa_Bp = strMa_Bp;
            
            if (enuNew_Edit == enuEdit.New)
                dteNgay_Ap.Text = Convert.ToString(DateTime.Now);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//load combo
            DataTable dtLoaiCC = Voucher.GetLoaiCC();
            cboLoai_CC.lstItem.BuildListView("Loai_CC:100,Ten_CC:200");
            cboLoai_CC.lstItem.DataSource = dtLoaiCC;
            cboLoai_CC.lstItem.Size = new Size(400, cboLoai_CC.lstItem.Items.Count * 20);
            cboLoai_CC.lstItem.GridLines = true;


			DataRow drDmTn = DataTool.SQLGetDataRowByID("R81DMBPCT", "Ma_Bp_Ct", txtMa_Bp_Ct.Text);

			if (drDmTn != null)
			    lbtTen_Bp_Ct.Text = (string)drDmTn["Ten_Bp_Ct"];

            if (txtHT_CC.Text.Trim() != string.Empty)
            {
                lbtGhi_Chu.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtHT_CC.Text.Trim());
            }
            else
                lbtGhi_Chu.Text = string.Empty;

            if (txtMuc_BDDH.Text.Trim() != string.Empty)
            {
                lbtTen_Muc_BDDH.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtMuc_BDDH.Text.Trim());
            }
            else
                lbtTen_Muc_BDDH.Text = string.Empty;
			
		}

		private bool CheckFormValid()
		{
			
            if (this.txtMa_Bp_Ct.Text == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Ma_Bp_Ct") + " " + Languages.GetLanguage("Not_Empty"));
                return false;
            }
            if (this.dteNgay_Ap.Text == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Ngay_Ap") + " " + Languages.GetLanguage("Not_Empty"));
                return false;
            }
            //nếu ngày áp nằm trong thời gian khóa thì không cho lưu
            bool bLock1 = Voucher.LockCongLuong("Lock_Cong", Convert.ToDateTime(dteNgay_Ap.Text).Year, Convert.ToDateTime(dteNgay_Ap.Text).Month,
                    Library.StrToDate(dteNgay_Ap.Text), Library.StrToDate(dteNgay_Ap.Text));

            if (enuNew_Edit == enuEdit.Edit && (bLock1))
            {
                Common.MsgOk("Bảng công đã khóa. Không sửa dữ liệu tại ngày: " + dteNgay_Ap.Text);
                return false;
            }
            return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			

			if (!this.CheckFormValid())
				return false;

            if (enuNew_Edit == enuEdit.Edit)
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();
               

            
            if (!DataTool.SQLUpdate(enuNew_Edit, "R10LOAICC", ref drEdit))
                return false;

            Hashtable HT = new Hashtable();
            HT.Add("NGAY", dteNgay_Ap.Text);
            SQLExec.Execute("Sp_UpdateChamCong", HT, CommandType.StoredProcedure);
            

			return true;
		}
        void txtHT_CC_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtHT_CC.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "HT_CC");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'HT_CC'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtHT_CC.Text = string.Empty;
                lbtGhi_Chu.Text = string.Empty;
            }
            else
            {
                txtHT_CC.Text = drLookup["Type_ID"].ToString();
                lbtGhi_Chu.Text = drLookup["Type_Name"].ToString();
            }
        }

        void txtMuc_BDDH_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMuc_BDDH.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "MUC_BDDH");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'MUC_BDDH'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMuc_BDDH.Text = string.Empty;
                lbtTen_Muc_BDDH.Text = string.Empty;
            }
            else
            {
                txtMuc_BDDH.Text = drLookup["Type_ID"].ToString();
                lbtTen_Muc_BDDH.Text = drLookup["Type_Name"].ToString();
            }
        }
        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = false;
            string strKey = string.Empty;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "Ma_Nh_Dt = 'NV' AND Ngay_Nghi_Lam = '19000101'");

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
        void txtMa_Bp_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp_Ct.Text.Trim();
            bool bRequire = true;
            string strKey = string.Empty;

            if (strMa_Bp != "")
                strKey = "(Ma_Bp = '" + strMa_Bp + "' AND Nh_Cuoi = 1) OR Ma_Bp_Ct IN ('TRUONGDV','PHODVI')";

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp_Ct", strValue, bRequire, strKey);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp_Ct.Text = string.Empty;
                lbtTen_Bp_Ct.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_Ct.Text = drLookup["Ma_Bp_Ct"].ToString();
                lbtTen_Bp_Ct.Text = drLookup["Ten_Bp_Ct"].ToString();

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
            bool bLock1 = Voucher.LockCongLuong("Lock_Cong", Convert.ToDateTime(dteNgay_Ap.Text).Year, Convert.ToDateTime(dteNgay_Ap.Text).Month,
                    Library.StrToDate(dteNgay_Ap.Text), Library.StrToDate(dteNgay_Ap.Text));

            if (enuNew_Edit == enuEdit.Edit && (bLock1))
                btgAccept.Enabled = false;
        }
    }
}
