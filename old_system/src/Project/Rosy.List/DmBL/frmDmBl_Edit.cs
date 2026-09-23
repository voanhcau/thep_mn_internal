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
using RosySystem.Public;
using System.Collections;

namespace RosyList
{
	public partial class frmDmBl_Edit : RosyList.frmEdit
	{

		#region Phuong thuc
        double dbTien_Bao_Lanh;
        DateTime dtNgay_Kt_Bl;

		public frmDmBl_Edit()
		{
			InitializeComponent();

			txtSo_Bl.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
			txtMa_Dt_Bl.Validating += new CancelEventHandler(txtMa_Dt_Bl_Validating);
            txtSo_Bl.TextChanged += new EventHandler(txtSo_Bl_TextChanged);

            numTy_Gia.Validated += new EventHandler(numTy_Gia_Validated);
            numTien_Bao_Lanh_Nt.Validated += new EventHandler(numTy_Gia_Validated);
		}

     

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();
            //if ((bool)drEdit["Lock"] && enuNew_Edit == enuEdit.Edit)
            //{
            //    numTien_Bao_Lanh.Enabled = false;
            //    dteNgay_Kt_Bl.Enabled = false;
            //}
            if (enuNew_Edit == enuEdit.Edit)
            {
                dbTien_Bao_Lanh = Convert.ToDouble(drEdit["Tien_Bao_Lanh"]);
                dtNgay_Kt_Bl = (DateTime)drEdit["Ngay_Kt_Bl"];
            }
			this.ShowDialog();
		}

		private void LoadDicName()
		{
            if (txtMa_Dt_Bl.Text.Trim() != string.Empty)
            {
                lbtTen_Dt_Bl.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_Bl.Text.Trim());
            }
            else
                lbtTen_Dt_Bl.Text = string.Empty;

			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;

			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				lbtSo_Hd.Text = DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "So_HD", txtMa_Hd.Text.Trim());
			}
			else
				lbtSo_Hd.Text = string.Empty;
		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtSo_Bl.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("So_Bl") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}
            //if (dbTien_Bao_Lanh > numTien_Bao_Lanh.Value)
            //{
            //    Common.MsgOk("Dữ liệu tiền BL phải lớn hơn dữ liệu hiện tại");
            //    return false;
            //}
            // if (dtNgay_Kt_Bl > Library.StrToDate(dteNgay_Kt_Bl.Text))
            //{
            //    Common.MsgOk("Dữ liệu ngày kết thúc phải lớn hơn dữ liệu hiện tại");
            //    return false;
            //}
			return bvalid;
		}

        void numTy_Gia_Validated(object sender, EventArgs e)
        {
            if (numTien_Bao_Lanh_Nt.Value != 0 && numTy_Gia.Value != 0)
                numTien_Bao_Lanh.Value = Convert.ToDouble(numTien_Bao_Lanh_Nt.Value) * Convert.ToDouble(numTy_Gia.Value);
        }

        void txtSo_Bl_TextChanged(object sender, EventArgs e)
        {
            txtSo_BL_Goc.Text = txtSo_Bl.Text;
        }

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;
            
            //if (numTien_Bao_Lanh.Value != 0)
            //    drEdit["Lock"] = true;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            {
                
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["LastModify_Log"] = string.Empty;
            }
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMBL", ref drEdit))
				return false;
            //Cập nhật ngày kết thúc HD
            Hashtable ht = new Hashtable();
            ht.Add("MA_HD", drEdit["Ma_Hd"]);
            ht.Add("NGAY_KT_BL", drEdit["Ngay_Kt_Bl"]);
            //string strSQL = "UPDATE R81DMHD SET Ngay_Hd_Kt = DATEADD(DAY,10,@Ngay_Kt_Bl) WHERE Ma_Hd = @Ma_Hd";
            string strSQL = "UPDATE R81DMHD SET Ngay_Hd_Kt = @Ngay_Kt_Bl WHERE Ma_Hd = @Ma_Hd";
            SQLExec.Execute(strSQL,ht,CommandType.Text);
			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("SO_BL", drEdit);

			return true;
		}

		#endregion

		#region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMBL"))
				e.Cancel = true;
		}
		void txtMa_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Hd.Text.Trim();
			bool bRequire = false;
			string strKeyValid = "";

			DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "", strKeyValid);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Hd.Text = string.Empty;
			}
			else
			{
				txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();

				if (txtMa_Hd.bTextChange)
					txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();

			}
		}

		void txtMa_Dt_Bl_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_Bl.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "Ma_Nh_Dt = '120'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt_Bl.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_Bl.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_Bl.Text = drLookup["Ten_Dt"].ToString();
			
			}

			

		}
		#endregion

	}
}