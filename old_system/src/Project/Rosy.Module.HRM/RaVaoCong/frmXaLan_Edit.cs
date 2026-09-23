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
	public partial class frmXaLan_Edit : frmEdit
	{
		#region Phuong thuc
       
        public frmXaLan_Edit()
		{
			InitializeComponent();

            txtMa_Dt.Validating+=new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Vt_Sp.Validating+=new CancelEventHandler(txtMa_Vt_Sp_Validating);
            btInherit.Click += new EventHandler(btInherit_Click);

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

        
    

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
           

			BindingLanguage();
			
            if (enuNew_Edit == enuEdit.New)
            {
                dteGio_Den.Text = Voucher.GetDateServer().ToString("HH:mm:ss");
                dteGio_Di.Enabled = false;

                dteNgay_Den.Text = DateTime.Now.ToShortDateString();
                dteNgay_Di.Enabled = false;
               
            }
            else if (enuNew_Edit == enuEdit.Edit)
            {
                Common.ScaterMemvar(this, ref drEdit);
                
                if(drEdit["Gio_Den"].ToString() != "")
                    dteGio_Den.Text = drEdit["Gio_Den"].ToString();
                
                dteGio_Di.Enabled = true;

              
                dteGio_Di.Text = Voucher.GetDateServer().ToString("HH:mm:ss");
                dteNgay_Di.Text = DateTime.Now.ToShortDateString();
                
            }
          
            LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Dt.strLookupKeyFilter = "Ma_Nh_Dt LIKE '100' OR Ma_Nh_Dt LIKE '110' OR Ma_Nh_Dt LIKE '300'";

          
            txtMa_Vt_Sp.bUseAutoDropDown = true;
            txtMa_Vt_Sp.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%'";

            //txtMa_Dt
            if (txtMa_Dt.Text.Trim() != string.Empty)
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            else
                lbtTen_Dt.Text = string.Empty;

            //txtMa_Vt_Sp
            if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
                lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
            else
                lbtTen_Vt.Text = string.Empty;
		}


        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;
            string strFilter = "Ma_Nh_Dt LIKE '100' OR Ma_Nh_Dt LIKE '110' OR Ma_Nh_Dt LIKE '300'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt.Text = string.Empty;
                lbtTen_Dt.Text = string.Empty;

            }
            else
            {
                txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();


            }
        }
        void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Sp.Text.Trim();
            bool bRequire = false;
            string strFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Sp.Text = string.Empty;
                lbtTen_Vt.Text = string.Empty;

            }
            else
            {
                txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
                lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();


            }
        }
		public bool FormCheckValid()
		{
			bool bvalid = true;
		
            if (txtSo_Xa_Lan_Tau.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("So_Xa_Lan_Tau") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
           
            if (dteGio_Den.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Gio_Ra") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            if(enuNew_Edit == enuEdit.Edit)
                if (dteGio_Di.Text.Trim() == string.Empty)
                {
                    Common.MsgOk(Languages.GetLanguage("Gio_Vao") + " " +
                                  Languages.GetLanguage("Not_Null"));
                    return false;
                }
			return bvalid;
		}

		public bool Save()
		{
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Gio_Den"] = dteGio_Den.Text;
                drEdit["Gio_Di"] = "00:00:00";
            }
            else
                drEdit["Gio_Di"] = dteGio_Di.Text;
			
            Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;



            if (enuNew_Edit == enuEdit.New)
            {
                
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                
            }
            else if (enuNew_Edit == enuEdit.Edit)
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R09XALAN", ref drEdit))
				return false;

			return true;
		}
        void btInherit_Click(object sender, EventArgs e)
        {
            frmInheritThongTinCan frmInherit = new frmInheritThongTinCan();
            frmInherit.Load();
            if (frmInherit.Is_Accept)
            {
                if (frmInherit.dtInheritVoucher.Select("Chon = true").Length == 0)
                    return;

                txtMa_Dt.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Dt"].ToString();
                txtMa_Vt_Sp.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Vt_Sp"].ToString();
                
                txtSo_Xa_Lan_Tau.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["So_Xa_Lan_Tau"].ToString();
               //lấy thông tin tài công
                txtTen_Lx_Khach.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ten_Lx_Xalan"].ToString();
                txtID_BL.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["ID_BL_Lx_Xalan"].ToString();
                txtID_CMND.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["ID_Lx_Xalan"].ToString();
                txtSo_Phone.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["So_Phone_Lx_Xalan"].ToString();

                numTai_Trong_Xe.Value = Convert.ToDouble(frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Tai_Trong"]);
                

                
                
                drEdit["Stt_Org"] = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Stt"].ToString();
              
                //Hiển thị số phiếu đã được kế thừa

                //string strInheritText = frmInherit.dtInheritVoucher.Rows[0]["So_Ct"].ToString();

                //if (!txtInherit.Text.Contains(strInheritText))
                //    txtInherit.Text += strInheritText + ",";


                //xử lý loai chung tu
                //nếu là xuất
                if (frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Loai_Ct"].ToString() == "X")
                {
                    dteGio_Di.Text = Voucher.GetDateServer().ToString("HH:mm:ss");// ("HH:mm:ss");
                    dteGio_Di.Enabled = true;
                    dteGio_Den.Clear();
                }
                else //nếu là nhập
                {
                    dteGio_Den.Text = Voucher.GetDateServer().ToString("HH:mm:ss");// ("HH:mm:ss");
                    dteGio_Den.Enabled = true;
                    dteGio_Di.Clear();
                }
                LoadDicName();
                //txtSo_Xe.Focus();
            }
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
