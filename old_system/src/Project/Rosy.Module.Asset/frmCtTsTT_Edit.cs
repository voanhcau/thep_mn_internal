using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Data;
using RosySystem.Library;
using RosySystem;
using RosySystem.Common;
using RosySystem.Control;
using RosySystem.Public;
using RosyList;

namespace RosyModule.Asset
{
	public partial class frmCtTsTT_Edit : RosySystem.Customize.frmEdit
	{
		#region Phuong thuc

		public frmCtTsTT_Edit()
		{
			InitializeComponent();

			chkTinh_Kh.CheckedChanged += new EventHandler(chkTinh_Kh_CheckedChanged);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtTk_No.Validating += new CancelEventHandler(txtTk_No_Validating);
			txtTk_Co.Validating += new CancelEventHandler(txtTk_Co_Validating);
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);
			txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;

			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			LoadDicName();
			BindingLanguage();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//Tk_No
			if (txtTk_No.Text.Trim() != string.Empty)
			{
				lbtTen_Tk_No.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk_No.Text.Trim());
			}
			else
				lbtTen_Tk_No.Text = string.Empty;

			//Tk_Co
			if (txtTk_Co.Text.Trim() != string.Empty)
			{
				lbtTen_Tk_Co.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk_Co.Text.Trim());
			}
			else
				lbtTen_Tk_Co.Text = string.Empty;

			//Ma_Bp
			if (txtMa_Bp.Text.Trim() != string.Empty)
			{
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			}
			else
				lbtTen_Bp.Text = string.Empty;

			//Ma_Km
			if (txtMa_Km.Text.Trim() != string.Empty)
			{
				lbtTen_Km.Text = DataTool.SQLGetNameByCode("R81DMKM", "Ma_Km", "Ten_Km", txtMa_Km.Text.Trim());
			}
			else
				lbtTen_Km.Text = string.Empty;

			//Ma_Vt_Sp
			if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
			{
				lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
			}
			else
				lbtTen_Vt_Sp.Text = string.Empty;
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;

			if (dteNgay_Ct.Text.Replace(" ", "") == "//")
			{
				Common.MsgOk(Languages.GetLanguage("Ngay_Ct") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtTk_No.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Tk_No") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtTk_Co.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Tk_Co") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Bp.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Bp") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			return bvalid;
		}

		private bool Save()
		{
			if (!Common.CheckDataLocked(Library.StrToDate(dteNgay_Ct.Text)))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return false;
			}

			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R06CTTSTT", ref drEdit))
				return false;

			return true;
		}

		#endregion

		#region Su kien

		void chkTinh_Kh_CheckedChanged(object sender, EventArgs e)
		{
			this.groupBox1.Enabled = this.chkTinh_Kh.Checked;
		}

		#region Accept
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

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Bp.Text = string.Empty;
				lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = ((string)drLookup["Ma_Bp"]).Trim();
				lbtTen_Bp.Text = ((string)drLookup["Ten_Bp"]).Trim();
			}
		}

		void txtTk_No_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_No.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_No.Text = string.Empty;
				lbtTen_Tk_No.Text = string.Empty;
			}
			else
			{
				txtTk_No.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_No.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}
		}

		void txtTk_Co_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Co.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Co.Text = string.Empty;
				lbtTen_Tk_Co.Text = string.Empty;
			}
			else
			{
				txtTk_Co.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_Co.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}
		}

		void txtMa_Km_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Km.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Km.Text = string.Empty;
				lbtTen_Km.Text = string.Empty;
			}
			else
			{
				txtMa_Km.Text = ((string)drLookup["Ma_Km"]).Trim();
				lbtTen_Km.Text = ((string)drLookup["Ten_Km"]).Trim();
			}
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = string.Empty;
				lbtTen_Vt_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = ((string)drLookup["Ma_Vt"]).Trim();
				lbtTen_Vt_Sp.Text = ((string)drLookup["Ten_Vt"]).Trim();
			}
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (this.enuNew_Edit == enuEdit.Edit)
			{
				if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
				{
					this.dteNgay_Ct.Enabled = false;
					this.btgAccept.btAccept.Enabled = false;

					return;
				}
			}
		}
	}
}