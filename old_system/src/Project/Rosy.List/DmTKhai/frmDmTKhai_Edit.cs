using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmTKhai_Edit : RosyList.frmEdit
	{
        double dbTien = 0;
        DataRow drCurrent;
        #region Phuong thuc

		public frmDmTKhai_Edit()
		{
			InitializeComponent();

            txtMa_Dt_Hq.Validating += new CancelEventHandler(txtMa_Dt_Hq_Validating);
            txtMa_Dt_CK.Validating += TxtMa_Dt_CK_Validating;
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Hd.Validating += TxtMa_Hd_Validating;

            numDon_Gia_Nt.Validated += NumTien3_Validated;
            numSo_Luong.Validated += NumTien3_Validated; 
            numTy_Gia.Validated += NumTien3_Validated;
            numTien_BHiem.Validated += NumTien3_Validated;
            numThue_NK.Validated += NumTien3_Validated;
            numThue_GTGT.Validated += NumTien3_Validated;
        }

        

        public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.drCurrent = drEdit;
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);

            if (enuNew_Edit == enuEdit.Edit)
            {
                this.txtSo_TKhai.Enabled = false;
                this.drEdit = DataTool.SQLGetDataRowByID("R81DMTOKHAIHQ", "SO_TKHAI", drEdit["SO_TKHAI"].ToString());

            }
            else
            {
                object[] List_Controls = new object[] { txtLoai_TKhai, txtMa_Dt, txtMa_Dt_Hq, txtMa_Hd, txtMa_Tte };
                foreach (Control ctrl in this.Page1.Controls)
                {
                    if (ctrl is TextBox txt && !List_Controls.Contains(ctrl))
                    {
                        if (ctrl.GetType() == typeof(rsTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(rsDateTime) || ctrl.GetType() == typeof(rsComboBox) || ctrl.GetType() == typeof(ComboBox))
                        {
                            ctrl.Text = "";
                        }
                    }
                    if (ctrl is rsDateTime dte && !List_Controls.Contains(ctrl))
                    {
                        if (ctrl.GetType() == typeof(rsDateTime))
                        {
                            ctrl.Text = "";
                        }
                    }
                    if (ctrl is rsTextBoxNumber num && !List_Controls.Contains(ctrl))
                    {
                        if (ctrl.GetType() == typeof(rsTextBoxNumber))
                        {
                            ctrl.Text = "0";
                        }
                    }
                    
                }
            }
            BindingLanguage();
            LoadDicName();
            
            if(enuNew_Edit == enuEdit.Edit)
                CheckQD();
            
            this.ShowDialog();
        }

        private void CheckQD()
        {
            double dbSO = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(So_TKhai) FROM R02CTNM WHERE So_TKhai = '" + drEdit["So_TKhai"].ToString() + "'"));
            
            
            //Kiểm tra quyết định đã xuất hiện chưa
            if (dbSO > 1 )
               LockControl();
           
        }
        void LockControl()
        {
            txtSo_TKhai.Enabled = false;
            dteNgay_TKhai.Enabled = false;
           
            txtVan_Don.Enabled = false;
            txtMa_Dt_Hq.Enabled = false;
            
         
            //txtLoai_Gia.Enabled = false;
            txtPt_Vc.Enabled = false;
          
        }
		private void LoadDicName()
		{
            if (txtMa_Dt_Hq.Text.Trim() != string.Empty)
            {
                lbtTen_Dt_Hd.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_Hq.Text.Trim());
            }
            else
                lbtTen_Dt_Hd.Text = string.Empty;

            if (txtMa_Dt.Text.Trim() != string.Empty)
            {
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            }
            else
                lbtTen_Dt_Hd.Text = string.Empty;

            if (txtMa_Hd.Text.Trim() != string.Empty)
            {
                lbtTen_Hd.Text = "Số: " + DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "So_Hd", txtMa_Hd.Text.Trim());
            }
            else
                lbtTen_Hd.Text = string.Empty;

            if (txtMa_Dt_CK.Text.Trim() != string.Empty)
            {
                lbtTen_Dt_CK.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CK.Text.Trim());
            }
            else
                lbtTen_Dt_CK.Text = string.Empty;
        }

        private void NumTien3_Validated(object sender, EventArgs e)
        {
            numTien_Nt.Value = Convert.ToDouble(numSo_Luong.Value) * Convert.ToDouble(numDon_Gia_Nt.Value);
            dbTien = Convert.ToDouble(numTien_Nt.Value) * Convert.ToDouble(numTy_Gia.Value);
            

            if (numThue_NK.Value != 0)
                numTien5.Value = ((Convert.ToDouble(numTien_Nt.Value) * Convert.ToDouble(numTy_Gia.Value)) + Convert.ToDouble(numTien_BHiem.Value)) * (Convert.ToDouble(numThue_NK.Value) / 100);

            if (numThue_GTGT.Value != 0)
                numTien3.Value = ((Convert.ToDouble(numTien_Nt.Value) * Convert.ToDouble(numTy_Gia.Value)) + Convert.ToDouble(numTien_BHiem.Value) + Convert.ToDouble(numTien5.Value)) * (Convert.ToDouble(numThue_GTGT.Value) / 100);

            
        }

        public override bool FormCheckValid()
        {
            bool bvalid = true ;
           if(txtLoai_TKhai.Text == "" || txtMa_Dt_Hq.Text == "" || txtSo_TKhai.Text == "" || Library.StrToDate(dteNgay_TKhai.Text) == Library.StrToDate("19000101")
               || txtMa_Dt.Text == "" || txtMa_Hd.Text == "" || txtVan_Don.Text == "" || Library.StrToDate(dteNgay_Van_Don.Text) == Library.StrToDate("19000101")
               || txtDia_Diem_Xh.Text == "" || txtDia_Diem_Dh.Text == "" || txtDia_Diem_Dh.Text == "" || txtPt_Vc.Text == "" 
               || Library.StrToDate(dteNgay_Hang_Den.Text) == Library.StrToDate("19000101") || txtTen_Vt.Text == "" || txtMa_Tte.Text == "" || numTy_Gia.Value == 0
               || numTien_Nt.Value == 0)
            {
                Common.MsgOk("Các vị trí có dấu (**) bắt buộc nhập liệu mới cho phép lưu!!!");
                bvalid = false;

            }
           if(txtSo_TKhai.Text.Length != 12)
            {
                Common.MsgOk("Chiều dài số tờ khai phải là 12 ký tự mới cho phép lưu!!!");
                bvalid = false;

            }
           double dbTien5_ = ((Convert.ToDouble(numTien_Nt.Value) * Convert.ToDouble(numTy_Gia.Value)) + Convert.ToDouble(numTien_BHiem.Value)) * (Convert.ToDouble(numThue_NK.Value) / 100);
            if (numThue_NK.Value != 0 && dbTien5_ != numTien5.Value)
            {
                Common.MsgOk("Tiền thuế NK khác (tiền hàng + Tiền BH) * (thuế NK/100), nhấn enter tại thuế NK");
                bvalid = false;

            }
            double dbTien3_ = Math.Round(((Convert.ToDouble(numTien_Nt.Value) * Convert.ToDouble(numTy_Gia.Value)) + Convert.ToDouble(numTien_BHiem.Value) + Convert.ToDouble(numTien5.Value)) * (Convert.ToDouble(numThue_GTGT.Value) / 100), MidpointRounding.AwayFromZero);
            if (numThue_GTGT.Value != 0 && dbTien3_ != numTien3.Value)
            {
                Common.MsgOk("Tiền thuế GTGT khác (tiền hàng + Thuế NK + Tiền BH) * (thuế GTGT/100), nhấn enter tại thuế GTGT");
                bvalid = false;

            }
            //if (txtMa_Tte.Text != "VND" && numTy_Gia.Value == 0)
            //{
            //    Common.MsgOk("Chiều dài số tờ khai phải là 12 ký tự mới cho phép lưu!!!");
            //    bvalid = false;

            //}
            return bvalid;
        }

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            { 
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["LastModify_Log"] = string.Empty;
                drEdit["Ma_Data"] = Element.sysMa_DvCs;
            }
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            drEdit["Tien"] = dbTien;
            //Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMTOKHAIHQ", ref drEdit))
				return false;
			
           
            Common.CopyDataRow(drEdit, drCurrent);

            //Doi ma
            if (enuNew_Edit == enuEdit.Edit)
                DataTool.SQLChangeID("SO_TKHAI", drEdit);
            
			return true;
		}

        #endregion

        #region Su kien

        private void TxtMa_Dt_CK_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CK.Text.Trim();
            bool bRequire = false;


            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CK.Text = string.Empty;
                lbtTen_Dt_CK.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CK.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt_CK.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }
        }

        void txtMa_Dt_Hq_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_Hq.Text.Trim();
            bool bRequire = false;
           

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_Hq.Text = string.Empty;
                lbtTen_Dt_Hd.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_Hq.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt_Hd.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }
        }
        private void TxtMa_Hd_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Hd.Text.Trim();
            bool bRequire = false;
            string strKey = "Ma_Dt = '" + txtMa_Dt.Text + "'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, strKey, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Hd.Text = string.Empty;
                lbtTen_Hd.Text = string.Empty;
            }
            else
            {
                txtMa_Hd.Text = ((string)drLookup["Ma_Hd"]).Trim();
                lbtTen_Hd.Text = "Số: " + ((string)drLookup["So_Hd"]).Trim();
            }
        }
        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;


            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lbtTen_Dt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }
        }

        void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMTOKHAIHQ"))
				e.Cancel = true;
		}

        #endregion

        private void numTien3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}