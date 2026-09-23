using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.HRM
{
	public partial class frmChuyenBP_Edit : frmEdit
	{
		#region Phuong thuc

        public frmChuyenBP_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Bp_Ct.Validating += new CancelEventHandler(txtMa_Bp_Ct_Validating);
		}

     

       

      

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

           
			Common.ScaterMemvar(this, ref drEdit);
            dteNgay_Ap.Text = Library.DateToStr(DateTime.Now);
			BindingLanguage();
			LoadDicName();
            Loadcombo();
			this.ShowDialog();
		}
        private void Loadcombo()
        {
            //load combo
            DataTable dtLoaiCC = Voucher.GetLoaiCC();
            cboLoai_CC.lstItem.BuildListView("Loai_CC:100,Ten_CC:200");
            cboLoai_CC.lstItem.DataSource = dtLoaiCC;
            cboLoai_CC.lstItem.Size = new Size(400, cboLoai_CC.lstItem.Items.Count * 20);
            cboLoai_CC.lstItem.GridLines = true;
        }
		private void LoadDicName()
		{
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Bp_Ct.bUseAutoDropDown = true;
            txtMa_Bp_Ct.strLookupKeyFilter = "Ma_Bp = '" + txtMa_Bp.Text +"'";

			//txtMa_Dt
			if (txtMa_Dt.Text.Trim() != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

            //txtMa_Bp_Ct
            if (txtMa_Bp.Text.Trim() != string.Empty)
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DmBp", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            else
                lbtTen_Bp.Text = string.Empty;


            //txtMa_Bp_Ct
            if (txtMa_Bp_Ct.Text.Trim() != string.Empty)
                lbtTen_Bp_Ct.Text = DataTool.SQLGetNameByCode("R81DmBpCt", "Ma_Bp_Ct", "Ten_Bp_Ct", txtMa_Bp_Ct.Text.Trim());
            else
                lbtTen_Bp_Ct.Text = string.Empty;
		}

        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lbtTen_Dt_CbNv.Text = string.Empty;
            }
            else
            {
                txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
            }
        }
        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = false;
            string strFilter = string.Empty;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
            }
            else
            {
                txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
                lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
            }
        }
        void txtMa_Bp_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp_Ct.Text.Trim();
            bool bRequire = false;
            string strFilter = "Ma_Bp = '" + txtMa_Bp.Text +"' AND Nh_Cuoi = 1";

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp_Ct", strValue, bRequire, strFilter);

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
		public bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtChuc_Vu.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Chuc_Vu") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}
            if (txtMa_Bp_Ct.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Ma_Bp_Ct") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
			return bvalid;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;
            
            drEdit["LastModify_Log"] = Common.GetCurrent_Log();
            //LƯU VÀO LƯƠNG VỊ TRÍ
            Hashtable ht = new Hashtable();
            ht.Add("MA_DT_CBNV", txtMa_Dt.Text);
            ht.Add("MA_BP", txtMa_Bp.Text);
            ht.Add("MA_BP_CT", txtMa_Bp_Ct.Text);
            ht.Add("NGAY_AP", dteNgay_Ap.Text);
            ht.Add("CHUC_VU", txtChuc_Vu.Text);
            ht.Add("CREATE_LOG", Common.GetCurrent_Log());
            ht.Add("LOAI_CC", cboLoai_CC.Text);
            SQLExec.Execute("sp_ChuyenBpLuongVTri", ht, CommandType.StoredProcedure);
            //LƯU VÀO HÌNH THỨC CC
			//Luu xuong CSDL DMDT
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMDT", ref drEdit))
				return false;

			return true;
		}
		#endregion

		#region Su kien
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
			isAccept = false;
			this.Close();
		}
		#endregion

        
	}
}
