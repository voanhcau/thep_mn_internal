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
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;
using RosyList;

namespace RosyModule.CRM
{
	public partial class frmTask_Kh_Edit : RosySystem.Customize.frmEdit
	{
		DataRow drParent;

		public frmTask_Kh_Edit()
		{
			InitializeComponent();

			txtMa_Dt_Kh.Validating += new CancelEventHandler(txtParent_ID_Validating);

			txtNgay_Dk_Ht.Validated += new EventHandler(txtNgay_Dk_Ht_Validated);
			txtNgay_Ht.Validated += new EventHandler(txtNgay_Ht_Validated);
			numSo_Ngay_Dk_Ht.Validated += new EventHandler(numSo_Ngay_Dk_Ht_Validated);
			numSo_Ngay_Ht.Validated += new EventHandler(numSo_Ngay_Ht_Validated);
			
			btgAccept.btAccept.Click +=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(enuEdit enuNew_Edit, DataRow drEdit, DataRow drParent)
		{
			this.drParent = drParent;
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
			this.txtNgay_Gd.Text = Library.DateToStr((DateTime)drParent["Ngay_Gd"]);

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();
			Calc_So_Ngay();

			this.ShowDialog();
		}

		void LoadDicName()
		{

		}

		void Calc_So_Ngay()
		{
			if (txtNgay_Gd.Text.Replace(" ", "") != "//" && txtNgay_Dk_Ht.Text.Replace(" ", "") != "//")
			{
				DateTime dNgay_Dk_Ht = Library.StrToDate(txtNgay_Dk_Ht.Text);
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);

				numSo_Ngay_Dk_Ht.Value = dNgay_Dk_Ht.Subtract(dNgay_Gd).TotalDays + 1;
			}

			if (txtNgay_Gd.Text.Replace(" ", "") != "//" && txtNgay_Ht.Text.Replace(" ", "") != "//")
			{
				DateTime dNgay_Ht = Library.StrToDate(txtNgay_Ht.Text);
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);

				numSo_Ngay_Ht.Value = dNgay_Ht.Subtract(dNgay_Gd).TotalDays + 1;
			}
		}

		bool FormCheckValid()
		{
			if (txtTask_ID.Text == string.Empty)
			{
				Common.MsgCancel("Chưa khai báo mã giao dịch");
				return false;
			}

			if (txtMa_Dt_Kh.Text == string.Empty)
			{
				Common.MsgCancel("Chưa khai báo mã đối tượng giao dịch");
				return false;
			}

			if ((string)drParent["Task_Type"] == "CONTRACT")
			{
				if (!DataTool.SQLCheckExist("R81DmHd", "Ma_Hd", txtMa_Dt_Kh.Text))
				{
					Common.MsgCancel("Chưa khai báo mã hợp đồng chưa đúng");
					return false;
				}
			}
			//else
			//{
			//    if (!DataTool.SQLCheckExist("R81DmDt", "Ma_Dt", txtMa_Dt_Kh.Text))
			//    {
			//        Common.MsgCancel("Chưa khai báo mã đối tượng chưa đúng");
			//        return false;
			//    }
			//}

			if (txtNgay_Dk_Ht.Text.Replace(" ", "") == "//")
			{
				Common.MsgCancel("Chưa khai báo ngày dự kiến hoàn thành");
				return false;
			}

			return true;
		}

		bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (drEdit.Table.Columns.Contains("Parent_Name"))
				drEdit["Parent_Name"] = lbtTen_Dt.Text;

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R08Task_Kh", ref drEdit))
				return false;

			return true;
		}

		void txtParent_ID_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_Kh.Text.Trim();
			bool bRequire = true;
			string strFilterKey = string.Empty;

			if ((string)drParent["Task_Type"] == "CONTRACT")
			{
				strFilterKey = "Ma_Hd <> '" + (string)drParent["Ma_Dt_Kh"] + "'";

				DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, strFilterKey, "Nh_Cuoi = 1");

				if (bRequire && drLookup == null)
					e.Cancel = true;

				if (drLookup == null)
				{
					txtMa_Dt_Kh.Text = string.Empty;
					lbtTen_Dt.Text = string.Empty;
				}
				else
				{
					txtMa_Dt_Kh.Text = drLookup["Ma_Hd"].ToString();
					lbtTen_Dt.Text = drLookup["Ten_Hd"].ToString();
				}
			}
			else
			{
				strFilterKey = "Ma_Dt <> '" + (string)drParent["Ma_Dt_Kh"] + "'";

				DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, strFilterKey);

				if (bRequire && drLookup == null)
					e.Cancel = true;

				if (drLookup == null)
				{
					txtMa_Dt_Kh.Text = string.Empty;
					lbtTen_Dt.Text = string.Empty;
				}
				else
				{
					txtMa_Dt_Kh.Text = drLookup["Ma_Dt"].ToString();
					lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
				}
			}
		}

		void numSo_Ngay_Ht_Validated(object sender, EventArgs e)
		{
			if (txtNgay_Gd.Text.Trim() != "//" && numSo_Ngay_Ht.Value != 0)
			{
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);
				DateTime dNgay_Ht = dNgay_Gd.AddDays(numSo_Ngay_Ht.Value).AddDays(-1);

				txtNgay_Ht.Text = Library.DateToStr(dNgay_Ht);
			}
			else
				txtNgay_Ht.Text = string.Empty;
		}

		void numSo_Ngay_Dk_Ht_Validated(object sender, EventArgs e)
		{
			if (txtNgay_Gd.Text.Trim() != "//" && numSo_Ngay_Dk_Ht.Value != 0)
			{
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);
				DateTime dNgay_Dk_Ht = dNgay_Gd.AddDays(numSo_Ngay_Dk_Ht.Value).AddDays(-1);

				txtNgay_Dk_Ht.Text = Library.DateToStr(dNgay_Dk_Ht);
			}
			else
				txtNgay_Dk_Ht.Text = string.Empty;
		}

		void txtNgay_Dk_Ht_Validated(object sender, EventArgs e)
		{
			Calc_So_Ngay();
		}

		void txtNgay_Ht_Validated(object sender, EventArgs e)
		{
			Calc_So_Ngay();
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
