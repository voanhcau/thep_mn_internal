using System;
using System.Collections;
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
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmQd_Edit : RosyList.frmEdit
	{

        DataRow drCurrent;
        #region Phuong thuc

		public frmDmQd_Edit()
		{
			InitializeComponent();

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_CTrinh.Validating += new CancelEventHandler(txtMa_CTrinh_Validating);
          
			btMa_Kho.Click += new EventHandler(btMa_Kho_Click);
			txtMa_Dt_Chung.Validating += new CancelEventHandler(txtMa_Dt_Chung_Validating);
			btPt_Vc.Click += new EventHandler(btPt_Vc_Click);
			btHt_Tt.Click += new EventHandler(btHt_Tt_Click);
            btHt_Gn.Click += new EventHandler(btHt_Gn_Click);
           
         
			//btSo_QD_Modify.Click += new EventHandler(btSo_QD_Modify_Click);
			txtSo_Qd_Modify.Validating += new CancelEventHandler(btSo_QD_Modify_Click);
            txtSo_Qd_Ck.Validating += new CancelEventHandler(txtSo_Qd_Ck_Validating);
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
                this.txtSo_QD.Enabled = false;
                this.drEdit = DataTool.SQLGetDataRowByID("R81DMQD", "SO_QD", drEdit["SO_QD"].ToString());

            }

            BindingLanguage();
            LoadDicName();
            
            if(enuNew_Edit == enuEdit.Edit)
                CheckQD();
            
            this.ShowDialog();
        }

        private void CheckQD()
        {
            double dbSO = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(So_QD) FROM R04CTSO WHERE So_QD = '" + drEdit["So_QD"].ToString() + "'"));
            double dbHD = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(So_QD) FROM R04CTHD WHERE So_QD = '" + drEdit["So_QD"].ToString() + "'"));
            
            //Kiểm tra quyết định đã xuất hiện chưa
            if (dbSO > 1 && dbHD == 0)
               LockControl();
            else if (dbHD > 1)
            {
                LockControl();
                //numSo_Luong_Max.Enabled = false;
            }
        }
        void LockControl()
        {
            txtSo_QD.Enabled = false;
            dteNgay_QD.Enabled = false;
            dteNgay_Het_Han.Enabled = false;
            txtLoai_Qd.Enabled = false;
            txtMa_Kho_List.Enabled = false;
            txtMa_Dt.Enabled = false;
            txtMa_Dt_Chung.Enabled = false;
            txtMa_CTrinh.Enabled = false;
            txtHT_TT.Enabled = false;
            txtPt_Vc.Enabled = false;
            txtSo_Qd_Modify.Enabled = false;
            dteNgay_Thay_The.Enabled = false;
            txtDien_Giai.Enabled = false;
            chkIs_CK.Enabled = false;
            btHt_Tt.Enabled = false;
            btMa_Kho.Enabled = false;
            btPt_Vc.Enabled = false;
        }
		private void LoadDicName()
		{
            if (txtMa_Dt.Text.Trim() != string.Empty)
            {
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            }
            else
                lbtTen_Dt.Text = string.Empty;

            if (txtMa_Dt_Chung.Text.Trim() != string.Empty)
            {
                lbtTenNhomDt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_Chung.Text.Trim());
            }
            else
                lbtTenNhomDt.Text = string.Empty;

            if (txtMa_CTrinh.Text.Trim() != string.Empty)
            {
                lbtTen_CTrinh.Text = DataTool.SQLGetNameByCode("R81DMCTRINH", "Ma_Ctrinh", "Ten_CTrinh", txtMa_CTrinh.Text.Trim());
            }
            else
                lbtTen_CTrinh.Text = string.Empty;
 
 
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtSo_QD.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("So_QD") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }
			if (txtSo_Qd_Modify.Text.Trim() != string.Empty)
			{
				if (string.IsNullOrEmpty(dteNgay_Thay_The.Text))
				{
					Common.MsgOk(Languages.GetLanguage("Ngay_Thay_The") + " " +
								 Languages.GetLanguage("Not_Null"));
					return false;
				}
			}
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;

			if (txtMa_Dt_Chung.Text.Trim() != string.Empty)
			{
				lbtTenNhomDt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_Chung.Text.Trim());
			}
			else
				lbtTenNhomDt.Text = string.Empty;
            //if (txtTen_Kho.Text.Trim() == string.Empty)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Ten_Kho") + " " +
            //                  Languages.GetLanguage("Not_Null"));
            //    return false;
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
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMQD", ref drEdit))
				return false;
			//cap nhat ngay het han cho quyet dinh duoc thay the
			else
			{

				Hashtable htParameter = new Hashtable();
				if (!string.IsNullOrEmpty(txtSo_Qd_Modify.Text.Trim()))
				{
					htParameter.Add("SO_QD", txtSo_Qd_Modify.Text.Trim());
					htParameter.Add("NGAY_HET_HAN", dteNgay_Thay_The.Text);

					if (!SQLExec.Execute("sp_Update_NgayHH_QD", htParameter, CommandType.StoredProcedure) && string.IsNullOrEmpty(txtSo_Qd_Modify.Text))
						return false;
					else
						Common.MsgOk("Bạn đã cập nhật ngày hết hạn QĐ '" + txtSo_Qd_Modify.Text.Trim() + "' là '" + drEdit["Ngay_QD"].ToString() + "'");
				}
			}
            if (enuNew_Edit == enuEdit.Edit)
            {
                Hashtable ht = new Hashtable();
                
                ht.Add("SO_QD", txtSo_QD.Text);
                ht.Add("NGAY_AP", dteNgay_QD.Text);
                ht.Add("NGAY_KTHUC", dteNgay_Het_Han.Text);

                SQLExec.Execute("UPDATE R04CSGIA SET Ngay_Ap = @Ngay_Ap, Ngay_KThuc = @Ngay_KThuc WHERE So_Qd = @So_Qd", ht, CommandType.Text);
                
            }
            Common.CopyDataRow(drEdit, drCurrent);

            //Doi ma
            if (enuNew_Edit == enuEdit.Edit)
                DataTool.SQLChangeID("SO_QD", drEdit);
            
			return true;
		}

        #endregion

        #region Su kien

        void btSo_QD_Modify_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;

            DataRow drLookup = Lookup.ShowLookup("So_QD", txtSo_Qd_Modify.Text, bRequire, strFilter, "");

            if (drLookup == null)
            {
                txtSo_Qd_Modify.Text = string.Empty;
            }
            else
            {
                txtSo_Qd_Modify.Text = drLookup["So_QD"].ToString();
                dteNgay_Thay_The.Text = DateTime.Now.ToShortDateString();
            }

        }

        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;
            if (txtMa_Dt_Chung.Text.Trim() == string.Empty)
                bRequire = true;

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

        void txtMa_CTrinh_Validating(object sender, CancelEventArgs e)
        {


            string strValue = txtMa_CTrinh.Text.Trim();

            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_CTrinh", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_CTrinh.Text = string.Empty;
                lbtTen_CTrinh.Text = string.Empty;
            }
            else
            {
                //drEdit["Ma_Ctr_Dt"] = drLookup["Ma_CTr_Dt"].ToString();
                txtMa_CTrinh.Text = drLookup["Ma_CTrinh"].ToString();//((string)drLookup["Ma_CTrinh"]).Trim();
                lbtTen_CTrinh.Text = drLookup["Ten_CTrinh"].ToString();// ((string)drLookup["Ten_CTrinh"]).Trim();
            }
        }

        void btMa_Kho_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;

            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Kho", txtMa_Kho_List.Text, bRequire, strFilter, "");

            if (drLookup == null)
            {
                txtMa_Kho_List.Text = string.Empty;
            }
            else
            {
                txtMa_Kho_List.Text = drLookup["MultiSelectValue"].ToString();
            }
        }

        void txtMa_Dt_Chung_Validating(object sender, CancelEventArgs e)
        {

            string strValue = txtMa_Dt_Chung.Text.Trim();
            bool bRequire = false;
            if (txtMa_Dt.Text.Trim() == string.Empty)
                bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_Chung.Text = string.Empty;
                lbtTenNhomDt.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_Chung.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTenNhomDt.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }
        }

        void btPt_Vc_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;

            DataRow drLookup = Lookup.ShowMultiLookup("Pt_Vc", txtPt_Vc.Text, bRequire, "Type='PT_VC'", "");

            if (drLookup == null)
            {
                txtPt_Vc.Text = string.Empty;
            }
            else
            {
                txtPt_Vc.Text = drLookup["MultiSelectValue"].ToString();
            }
        }
        void txtSo_Qd_Ck_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_Qd_Ck.Text.Trim();
            bool bRequire = false;

            string strFilter = "Type='SOQD_CHIETKHAU'";
            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "SOQD_CHIETKHAU");

            DataRow drLookup = Lookup.ShowMultiLookup("SOQD_CHIETKHAU", txtSo_Qd_Ck.Text, bRequire, strFilter, "");
            if (drLookup == null)
            {
                txtSo_Qd_Ck.Text = string.Empty;

            }
            else
            {
                txtSo_Qd_Ck.Text = drLookup["MultiSelectValue"].ToString();



            }
        }
        void btHt_Gn_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;

            //System.Collections.Hashtable htField = new System.Collections.Hashtable();
            //htField.Add("strType", "HT_GN");

            DataRow drLookup = Lookup.ShowMultiLookup("Type_ID", txtHt_Gn.Text, bRequire, "TYPE = 'HT_GN'", "");

            if (drLookup == null)
            {
                txtHt_Gn.Text = string.Empty;
            }
            else
            {
               txtHt_Gn.Text = drLookup["MultiSelectValue"].ToString();
            }
        }
        void btHt_Tt_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;

            DataRow drLookup = Lookup.ShowMultiLookup("Loai_Gia", txtHT_TT.Text, bRequire, "Type='Loai_Gia'", "");

            if (drLookup == null)
            {
                txtHT_TT.Text = string.Empty;
            }
            else
            {
                txtHT_TT.Text = drLookup["MultiSelectValue"].ToString();
            }
        }

  
        void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMQD"))
				e.Cancel = true;
		}

        #endregion		

	}
}