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

namespace RosyModule.Costing
{
	public partial class frmZDauKySp_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmZDauKySp_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtTk.Validating += new CancelEventHandler(txtTk_Validating);
			txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
			txtTk_Cp.Validating += new CancelEventHandler(txtTk_Cp_Validating);
			txtMa_Yt.Validating += new CancelEventHandler(txtMa_Yt_Validating);
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtTk.Text != string.Empty)
			{
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk.Text);
			}
			else
				lbtTen_Tk.Text = string.Empty;

			if (txtMa_Vt_Sp.Text != string.Empty)
			{
				lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text);
			}
			else
				lbtTen_Vt_Sp.Text = string.Empty;

			if (txtTk_Cp.Text != string.Empty)
			{
				lbtTen_Tk_Cp.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk_Cp.Text);
			}
			else
				lbtTen_Tk_Cp.Text = string.Empty;

			if (txtMa_Yt.Text != string.Empty)
			{
				lbtTen_Yt.Text = DataTool.SQLGetNameByCode("R07DmYt", "Ma_Yt", "Ten_Yt", txtMa_Yt.Text);
			}
			else
				lbtTen_Yt.Text = string.Empty;

			if (txtMa_Vt.Text != string.Empty)
			{
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text);
			}
			else
				lbtTen_Vt.Text = string.Empty;
		}

		private bool CheckFormValid()
		{
			if (this.txtTk.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			if (this.txtTk_Cp.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk_Cp") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			if (this.txtMa_Yt.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Yt") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			drEdit["Is_SoDuDau"] = true;
			drEdit["Ngay_Ct"] = Common.GetDate(RosySystem.Element.Element.sysWorkingYear, 1, 1);

			if (!this.CheckFormValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "R07ZChiPhiSp", ref drEdit))
				return false;

			return true;
		}

		#endregion

		#region Events

		void txtTk_Validating(object sender, CancelEventArgs e)
		{
			if (!txtTk.bTextChange)
				return;

			string strValue = txtTk.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk.Text = string.Empty;
				lbtTen_Tk.Text = string.Empty;
			}
			else
			{
				txtTk.Text = drLookup["Tk"].ToString();
				lbtTen_Tk.Text = drLookup["Ten_Tk"].ToString();
			}
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			if (!txtMa_Vt_Sp.bTextChange)
				return;

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
				txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt_Sp.Text = drLookup["Ten_Vt"].ToString();
			}
		}

		void txtTk_Cp_Validating(object sender, CancelEventArgs e)
		{
			if (!txtTk_Cp.bTextChange)
				return;

			string strValue = txtTk_Cp.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Cp.Text = string.Empty;
				lbtTen_Tk_Cp.Text = string.Empty;
			}
			else
			{
				txtTk_Cp.Text = drLookup["Tk"].ToString();
				lbtTen_Tk_Cp.Text = drLookup["Ten_Tk"].ToString();
			}
		}

		void txtMa_Yt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Yt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Yt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Yt.Text = string.Empty;
				lbtTen_Yt.Text = string.Empty;
				txtMa_Vt.Enabled = false;
			}
			else
			{
				txtMa_Yt.Text = drLookup["Ma_Yt"].ToString();
				lbtTen_Yt.Text = drLookup["Ten_Yt"].ToString();
				txtMa_Vt.Enabled = (bool)drLookup["Is_Nvl"];
			}
		}

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			if (!txtMa_Vt.bTextChange)
				return;

			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "");

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
			this.Close();
		}

		#endregion
	}
}
