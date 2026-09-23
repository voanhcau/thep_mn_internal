using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Public;
using RosyList;
using System.Collections;
using System.Globalization;

namespace RosyModule.Salary
{
	public partial class frmDCChamCong_Edit : RosySystem.Customize.frmEdit
	{
        public frmDCChamCong_Edit()
		{
			InitializeComponent();

		

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);

            dteNgay_Cham_Cong_MCC.Text = Convert.ToDateTime(drEdit["Ngay_Gio_Cong"]).ToString();//"dd/mm/yyyy"
            dteGio_Cham_Cong_MCC.Text = Convert.ToDateTime(drEdit["Ngay_Gio_Cong"]).ToString("HH:mm:ss");
            //Format kiểu 24h
            System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortTimePattern = "HH:mm:ss";



            DateTime ttGio = Convert.ToDateTime(Convert.ToDateTime(drEdit["Ngay_Gio_Cong"]).ToString("HH:mm:ss"));


            if ((txtLoai_CC.Text == "HC" || txtLoai_CC.Text == "HCS") && ttGio < Convert.ToDateTime("12:00:00"))
                lbtGhi_Chu.Text = "Giờ Ra";
            else if ((txtLoai_CC.Text == "HC" || txtLoai_CC.Text == "HCS") && ttGio >= Convert.ToDateTime("12:00:00"))
                lbtGhi_Chu.Text = "Giờ Vào";
            else if (txtLoai_CC.Text == "HCC" && ttGio < Convert.ToDateTime("16:00:00"))
                lbtGhi_Chu.Text = "Giờ Ra";
            else if (txtLoai_CC.Text == "HCC" && ttGio >= Convert.ToDateTime("16:00:00"))
                lbtGhi_Chu.Text = "Giờ Vào";
            else if ((txtLoai_CC.Text == "C1_1" || txtKip.Text == "1") && ttGio < Convert.ToDateTime("12:00:00"))
                lbtGhi_Chu.Text = "Giờ Ra";
            else if ((txtLoai_CC.Text == "C1_1" || txtKip.Text == "1") && ttGio >= Convert.ToDateTime("12:00:00"))
                lbtGhi_Chu.Text = "Giờ Vào";
            else if ((txtLoai_CC.Text == "C2_1" || txtKip.Text == "2") && ttGio < Convert.ToDateTime("23:00:00"))
                lbtGhi_Chu.Text = "Giờ Ra";
            else if ((txtLoai_CC.Text == "C2_1" || txtKip.Text == "2") && ttGio >= Convert.ToDateTime("23:00:00"))
                lbtGhi_Chu.Text = "Giờ Vào";
            else if ((txtLoai_CC.Text == "C1_2") && ttGio < Convert.ToDateTime("14:00:00"))
                lbtGhi_Chu.Text = "Giờ Ra";
            else if ((txtLoai_CC.Text == "C1_2") && ttGio >= Convert.ToDateTime("14:00:00"))
                lbtGhi_Chu.Text = "Giờ Vào";

            if (txtLoai_CC.Text == "C1*")
                dteNgay_Cham_Cong.Enabled = true;

            if (drEdit["Ngay_Gio_Cong_Bs"].ToString() != "")
            {
                dteNgay_Cham_Cong_Bs.Text = Convert.ToDateTime(drEdit["Ngay_Gio_Cong_Bs"]).ToString();//"dd/mm/yyyy"
                dteGio_Cham_Cong_Bs.Text = Convert.ToDateTime(drEdit["Ngay_Gio_Cong_Bs"]).ToString("HH:mm:ss");
            }
            else
            {
                dteNgay_Cham_Cong_Bs.Text = dteNgay_Cham_Cong.Text;
                dteGio_Cham_Cong_Bs.Text = "00:00:00";
            }

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Dt_CbNv.Text != string.Empty)
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text);
			else
                lbtTen_Dt_CbNv.Text = string.Empty;

		
		}

		private bool CheckFormValid()
		{
			if (this.txtMa_Dt_CbNv.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Tn") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}
            if (this.txtGhi_Chu.Text == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Ly_Do") + " " + Languages.GetLanguage("Not_Empty"));
                return false;
            }

            bool bLock = Voucher.LockCongLuong("Lock_Cong", Convert.ToDateTime(dteNgay_Cham_Cong_Bs.Text).Year, Convert.ToDateTime(dteNgay_Cham_Cong_Bs.Text).Month, Convert.ToDateTime(dteNgay_Cham_Cong_Bs.Text), Convert.ToDateTime(dteNgay_Cham_Cong_Bs.Text));
            if (bLock)
            {
                Common.MsgOk("Dữ liệu đã bị khóa tháng "+ Convert.ToDateTime(dteNgay_Cham_Cong_Bs.Text).Month + " liên lạc PTCHC để được mở khóa !!!!");
                return false;
            }
			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!this.CheckFormValid())
				return false;

            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CHAM_CONG", dteNgay_Cham_Cong.Text);
            ht.Add("NGAY", dteNgay_Cham_Cong_Bs.Text);
            ht.Add("GIO", dteGio_Cham_Cong_Bs.Text);
            ht.Add("IDENT00", drEdit["Ident00"]);
            ht.Add("CREATE_LOG", Common.GetCurrent_Log());
            ht.Add("GHI_CHU", txtGhi_Chu.Text);
            ht.Add("NOTCC", chkNotCC.Checked);
            string strUpDate = "UPDATE R10CHAMCONG SET Ngay_Cham_Cong = @Ngay_Cham_Cong,  Ngay_Gio_Cong_Bs = CAST(@Ngay AS DATETIME) + CAST(@Gio AS DATETIME), Create_Log = @Create_Log, Ghi_Chu = @Ghi_Chu, NotCC = @NotCC WHERE Ident00 = @Ident00";
            if (!SQLExec.Execute(strUpDate, ht, CommandType.Text))
                return false;
        
			return true;
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
