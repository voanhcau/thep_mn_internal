using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;
using RosyList;

namespace RosyModule.Asset
{
	public partial class frmGiam_Ts_Edit : RosySystem.Customize.frmEdit
	{
		#region Contructor

		public frmGiam_Ts_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Nvu_Giam.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;

			Common.ScaterMemvar(this, ref drEdit);

			this.Init();
			this.LoadDicName();
			this.BindingLanguage();

			this.ShowDialog();
		}

		#endregion

		#region Phuong thuc

		private void Init()
		{
			if (enuNew_Edit == enuEdit.Edit)
			{
				//	this.txtLoai_Ps.Enabled = false;
			}
			else
			{
				//	this.txtMa_Tte.Text = RosySystem.Element.Element.sysMa_Tte;
				//	this.numTy_Gia.Value = 1;
			}

		}

		private void LoadDicName()
		{
			//Ma_Nvu
			if (txtMa_Nvu_Giam.Text.Trim() != string.Empty)
			{
				lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu_Giam.Text.Trim());
			}
			else
				lbtTen_Nvu.Text = string.Empty;

		}

		private bool FormCheckValid()
		{
			if (dteNgay_Giam_Ts.Text.Replace(" ", "") == "//")
			{
				Common.MsgOk(Languages.GetLanguage("Ngay_Giam_Ts") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}
			if (txtMa_Nvu_Giam.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Nvu_Giam") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			if (!Common.CheckDataLocked(Library.StrToDate(dteNgay_Giam_Ts.Text)))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return false;
			}

			Common.GatherMemvar(this, ref drEdit);

			if (txtMa_Nvu_Giam.Text != "")
			{
				drEdit["Is_Giam_Ts"] = true;
			}

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R06CTTS", ref drEdit))
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

		void txtMa_Nvu_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nvu_Giam.Text.Trim();
			bool bRequire = true;
			string strFilter = "(CHARINDEX('" + (string)drEdit["Ma_Ct"] + "', Ma_Ct, 0) > 0)";

			DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, strFilter);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				lbtTen_Nvu.Text = string.Empty;
				lbtTen_Nvu.Text = string.Empty;
			}
			else
			{
				txtMa_Nvu_Giam.Text = ((string)drLookup["Ma_Nvu"]).Trim();
				lbtTen_Nvu.Text = ((string)drLookup["Ten_Nvu"]).Trim();
			}
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			//if (this.enuNew_Edit == enuEdit.Edit)
			//{
			//    if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Giam"]))
			//    {
			//        this.dteNgay_Giam.Enabled = false;
			//        this.btgAccept.btAccept.Enabled = false;

			//        return;
			//    }
			//}
		}
	}
}