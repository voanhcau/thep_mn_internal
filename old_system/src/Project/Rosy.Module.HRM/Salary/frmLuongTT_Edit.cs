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

namespace RosyModule.HRM
{
	public partial class frmLuongTT_Edit : RosySystem.Customize.frmEdit
	{
        string strMa_Bp = string.Empty;
        public frmLuongTT_Edit()
		{
			InitializeComponent();

			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_VTri_NV.Validating += new CancelEventHandler(txtMa_VTri_NV_Validating);
            txtMa_Bp_Ct.Validating += new CancelEventHandler(txtMa_Bp_Ct_Validating);
            //txtBang_Luong.Validating += new CancelEventHandler(txtBang_Luong_Validating);
            //txtBac_Luong.Validating += new CancelEventHandler(txtBac_Luong_Validating);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

        

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strMa_Bp)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strMa_Bp = strMa_Bp;
			Common.ScaterMemvar(this, ref drEdit);

            if (enuNew_Edit == enuEdit.New)
            {
                DataTable dtBangLuong = SQLExec.ExecuteReturnDt("SELECT MAX(Ngay_Ct) AS Ngay_Ct from R10BANGLUONG");
                DateTime dtResult = Convert.ToDateTime(dtBangLuong.Rows[0]["Ngay_Ct"]);

                dtResult = dtResult.AddDays((-dtResult.Day) + 1);
                dteNgay_Ap.Text = dtResult.ToShortDateString();// DateTime.Now.ToShortDateString();
                txtMa_Bp_Ct.Text = SQLExec.ExecuteReturnValue("SELECT Ma_Bp_Ct FROM R81DMDT WHERE Ma_Dt = '" + txtMa_Dt_CbNv.Text + "'").ToString();
              
                if(enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                drEdit["Identt_Org"] = 0;
            }
            else
            {
                if (Common.InlistLike(txtMa_VTri_NV.Text, "B1"))
                    numMuc_Luong_NQL.Visible = true;
                else
                    numMuc_Luong_NQL.Visible = false;
            }
            //else
            //    txtMa_VTri_NV.Text = SQLExec.ExecuteReturnValue("SELECT Ma_VTri_NV FROM R81DMNGACHLUONG WHERE Bang_Luong = '" + txtBang_Luong.Text + "' AND Bac_Luong = '" + txtBac_Luong.Text + "'").ToString();

            if ((bool)drEdit["Duyet_TCHC"] && enuNew_Edit == enuEdit.Edit)
                this.btgAccept.Enabled = false;
                   
			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_VTri_NV.bUseAutoDropDown = true;
            txtMa_VTri_NV.strLookupKeyFilter = "Loai_Ngach = 'TT'";

            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            
            if (strMa_Bp != "*")
                txtMa_Dt_CbNv.strLookupKeyFilter = "Ma_Bp = '"+ strMa_Bp +"'";

			if (txtMa_Dt_CbNv.Text != string.Empty)
			{
				DataRow drDmTn = DataTool.SQLGetDataRowByID("R81DmDt", "Ma_Dt", txtMa_Dt_CbNv.Text);

				if (drDmTn != null)
				{
					lbtTen_Dt_CbNv.Text = (string)drDmTn["Ten_Dt"];
					
				}
			}
			else
			{
				lbtTen_Dt_CbNv.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}

            if (txtMa_Bp_Ct.Text != string.Empty)
            {
                if (txtMa_Bp_Ct.Text.Trim() != string.Empty)
                {
                    lbtTen_Bp_Ct.Text = DataTool.SQLGetNameByCode("R81DMBPCT", "Ma_Bp_Ct", "Ten_Bp_Ct", txtMa_Bp_Ct.Text.Trim());
                }
                else
                    lbtTen_Bp_Ct.Text = string.Empty;
            }

		}

		private bool CheckFormValid()
		{
			if (this.txtMa_Dt_CbNv.Text == string.Empty)
			{
                Common.MsgCancel(Languages.GetLanguage("Ma_Dt_CbNv") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}
            if (numMuc_Luong.Value == 0)
            {
                Common.MsgCancel(Languages.GetLanguage("Tien") + " " + Languages.GetLanguage("Not_Empty"));
                return false;
            }
			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["Duyet_TCHC"] = false;
                drEdit["Duyet_TCHC_Log"] = string.Empty;
            }
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();
			

			if (!this.CheckFormValid())
				return false;

            // cập nhật BP chi tiết

            string strMa_Bp_Ct_Dt = SQLExec.ExecuteReturnValue("SELECT Ma_Bp_Ct FROM R81DMDT WHERE Ma_Dt = '"+ txtMa_Dt_CbNv.Text +"'").ToString();
            if (strMa_Bp_Ct_Dt != txtMa_Bp_Ct.Text)
            {
                if(Common.MsgYes_No("Mã bộ phận nhập liệu khác mã bộ phận trong danh mục bạn có muốn sửa lại theo dữ liệu bạn nhập không?","Y"))
                    SQLExec.Execute("UPDATE R81DMDT SET Ma_Bp_Ct = '" + txtMa_Bp_Ct.Text + "' WHERE  Ma_Dt = '" + txtMa_Dt_CbNv.Text + "'");
            }
            if (!DataTool.SQLUpdate(enuNew_Edit, "R09LUONGTT", ref drEdit))
				return false;

			return true;
		}
      
        void txtMa_VTri_NV_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_VTri_NV.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_VTri_NV", strValue, bRequire, "Loai_Ngach = 'TT'");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtBang_Luong.Text = string.Empty;


            }
            else
            {
                txtMa_VTri_NV.Text = drLookup["Ma_VTri_NV"].ToString();
                txtBang_Luong.Text = drLookup["Bang_Luong"].ToString();
                txtBac_Luong.Text = drLookup["Bac_Luong"].ToString();
                numDiem_VTri_NV.Value = Convert.ToDouble(drLookup["Diem_VTri_NV"]);
                numMuc_Luong.Value = Convert.ToDouble(drLookup["Muc_Luong"]);

            }
        }
        void txtMa_Bp_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp_Ct.Text.Trim();
            bool bRequi = true;
            //string strMa_Bp = SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt = '" + txtMa_Dt_CbNv.Text + "'").ToString();
            //DataRow drLookup = Lookup.ShowLookup("Ma_Bp_Ct", strValue, bRequi, "Ma_Bp = '" + strMa_Bp + "' AND Nh_Cuoi = 1");
            DataRow drLookup = Lookup.ShowLookup("Ma_Bp_Ct", strValue, bRequi, " Nh_Cuoi = 1");
            if (bRequi && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp_Ct.Text = string.Empty;
                lbtTen_Bp_Ct.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_Ct.Text = (string)drLookup["Ma_Bp_Ct"];
                lbtTen_Bp_Ct.Text = (string)drLookup["Ten_Bp_Ct"];
            }
        }
		void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
		{
			if (!txtMa_Dt_CbNv.bTextChange)
				return;

			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

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
                txtMa_Bp_Ct.Text = SQLExec.ExecuteReturnValue("SELECT Ma_Bp_Ct FROM R81DMDT WHERE Ma_Dt = '" + txtMa_Dt_CbNv.Text + "'").ToString();
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
	}
}
