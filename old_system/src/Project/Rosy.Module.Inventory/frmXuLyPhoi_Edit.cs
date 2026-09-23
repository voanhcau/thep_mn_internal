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
using System.Collections;

namespace RosyModule.Inventory
{
	public partial class frmXuLyPhoi_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods
		
		double numSl_Cay_Xly;
	
		public frmXuLyPhoi_Edit()
		{
			InitializeComponent();

			txtPhan_Loai_Phoi.Validating += new CancelEventHandler(txtPhan_Loai_Phoi_Validating);
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);

			numDDai_Phoi.Validated += new EventHandler(numDDai_Phoi_Validated);
			numSo_Luong_Cay.Validated += new EventHandler(numDDai_Phoi_Validated);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

	

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			numSl_Cay_Xly = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT ISNULL(SUM(So_Luong_Cay),0) FROM R05CTNXPHOI WHERE Phan_Loai_Phoi = 'CXL' AND So_Me = '" + drEdit["So_Me"] + "' AND Stt = '" + drEdit["Stt"] + "' AND Stt0 = " + drEdit["Stt0"] + " "));

			if (enuNew_Edit == enuEdit.New)
			{
				dteNgay_Ct.Text = Library.DateToStr((DateTime)drEdit["Ngay_Ct"]);
				numDDai_Phoi.Value = Convert.ToDouble(drEdit["DDai_Phoi"]);
				txtPhan_Loai_Phoi.Text = "PH";
				txtMa_Vt.Text = drEdit["Ma_Vt"].ToString();
				txtPhuong_An_Xl.Text = drEdit["Phuong_An_Xl"].ToString();
                numSo_Luong_Cay.Value = Convert.ToDouble(drEdit["So_Luong_Cay"]);
                numSo_Luong_TB_Nong.Value = drEdit["So_Luong_TB_Nong"] == DBNull.Value ? 0 : Convert.ToDouble(drEdit["So_Luong_TB_Nong"]);
                numSo_Luong_TB_Nguoi.Value = drEdit["So_Luong_TB_Nguoi"] == DBNull.Value ? 0 : Convert.ToDouble(drEdit["So_Luong_TB_Nguoi"]);
				numSo_Luong.Value = Convert.ToDouble(drEdit["So_Luong"]);
			}

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtPhan_Loai_Phoi.Text.Trim() != string.Empty)
			{
				lbtTen_Phan_Loai_Phoi.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtPhan_Loai_Phoi.Text.Trim());
			}
			else
				lbtTen_Phan_Loai_Phoi.Text = string.Empty;

			if (txtMa_Vt.Text.Trim() != string.Empty)
			{
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
			}
			else
			{
				lbtTen_Vt.Text = string.Empty;
				
			}
		}

		public bool FormCheckValid()
		{
			if (txtPhan_Loai_Phoi.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Kho") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (dteNgay_Ct.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Date") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (!Voucher.CheckDataLocked_Phoi(Library.StrToDate(dteNgay_Ct.Text)))
			{
				Common.MsgCancel(Languages.GetLanguage("DATA_LOCKED"));
				return false;
			}

			//Kiểm tra tổng số cây cần xử lý và đã xử lý

			double numSl_Cay_Xly_R = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT ISNULL(SUM(So_Luong_Cay),0) FROM R05CTNXLRPHOI WHERE So_Me = '" + drEdit["So_Me"] + "' AND Stt = '" + drEdit["Stt"] + "' AND Stt0 = " + drEdit["Stt0"] + " "));
			double numSl_Cay_Da_Xly = Convert.ToDouble(numSo_Luong_Cay.Value) + numSl_Cay_Xly_R;

			if (numSl_Cay_Xly < numSl_Cay_Da_Xly && enuNew_Edit == enuEdit.New)
			{
				Common.MsgCancel("Số lượng cây xử lý đã vượt số cây cần xử lý");
				return false;
			}
			return true;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Kiem tra cac du lieu can thiet
			drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();
			//Lưu vào kế toán khi xử lý phôi
			if (txtPhan_Loai_Phoi.Text == "PH")
				drEdit["Ma_Kho"] = "02BTP";
			//Luu xuong CSDL
			return DataTool.SQLUpdate(enuNew_Edit, "R05CTNXLRPHOI", ref drEdit);
		}

		#endregion

		#region Events

		
		void numDDai_Phoi_Validated(object sender, EventArgs e)
		{
			DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", txtMa_Vt.Text);
            double dbBarem = 0;
            Hashtable ht = new Hashtable();
            ht.Add("MA_VT", txtMa_Vt.Text);
            ht.Add("NGAY_CT", dteNgay_Ct.Text);
            ht.Add("SO_ME", drEdit["So_Me"]);
            dbBarem = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBaremPhoi(@Ma_Vt,@Ngay_Ct, @So_Me)", ht, CommandType.Text));
            
            if (numSo_Luong_TB_Nong.Value == 0 && numSo_Luong_TB_Nguoi.Value == 0)
                numSo_Luong.Value = numSo_Luong_Cay.Value * numDDai_Phoi.Value * dbBarem;
            else if (numSo_Luong_TB_Nong.Value == 0 && numSo_Luong_TB_Nguoi.Value != 0)
                numSo_Luong.Value = numSo_Luong_Cay.Value * numSo_Luong_TB_Nguoi.Value;
            else if (numSo_Luong_TB_Nong.Value != 0 && numSo_Luong_TB_Nguoi.Value == 0)
                numSo_Luong.Value = numSo_Luong_Cay.Value * numSo_Luong_TB_Nong.Value;
		}

		void txtPhan_Loai_Phoi_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtPhan_Loai_Phoi.Text.Trim();
			bool bRequire = true;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "PHAN_LOAI_PHOI");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'PHAN_LOAI_PHOI'", "Type_Id <> 'CXL'", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtPhan_Loai_Phoi.Text = string.Empty;
				lbtTen_Phan_Loai_Phoi.Text = string.Empty;
			}
			else
			{
				txtPhan_Loai_Phoi.Text = drLookup["Type_ID"].ToString();
				lbtTen_Phan_Loai_Phoi.Text = drLookup["Type_Name"].ToString();
			}
		}

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

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

		void numTon_Dau_Validating(object sender, CancelEventArgs e)
		{
			//double dbTon_Dau = numTon_Dau.Value;
			//double dbGia = numGia.Value;
			

			//double dbTronTien = Convert.ToDouble(Parameters.GetParaValue("Tron_Thanh_Tien"));

			//if (Math.Abs(dbTon_Dau * dbGia - dbDu_Dau) >= dbTronTien)
			//{
			//    dbDu_Dau = Math.Round(dbTon_Dau * dbGia, 0, MidpointRounding.AwayFromZero);
			//    numDu_Dau.Value = dbDu_Dau;
			//}

			//if (dbTon_Dau == 0)
			//    numDu_Dau.Value = 0;
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

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
            
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                drEdit["Stt_Inherit_Nhap_Tp"] = "";

            string strStt_Inherit_Nhap_Tp = (string)SQLExec.ExecuteReturnValue("SELECT Stt FROM R05CTNX WHERE Stt = '" + drEdit["Stt_Inherit_Nhap_Tp"] + "'");
            if (strStt_Inherit_Nhap_Tp != null)
            {
                //Common.MsgOk("Mẻ phôi đã được cập nhật vào kế toán. Không được phép sửa");
                this.btgAccept.btAccept.Enabled = false;
            }
			//if(!Common.CheckDataLocked(Library.StrToDate(dteNgay_Ct.Text)))
			//{
			//    Common.MsgCancel(Languages.GetLanguage("DATA_LOCKED"));
			//    this.btgAccept.btAccept.Enabled = false;
			//}
		}
	}
}
