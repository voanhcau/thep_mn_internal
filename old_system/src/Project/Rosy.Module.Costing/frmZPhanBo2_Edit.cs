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
	public partial class frmZPhanBo2_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods
		public frmZPhanBo2_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtTk.Validating += new CancelEventHandler(txtTk_Validating);
			txtTk_Cp.Validating += new CancelEventHandler(txtTk_Cp_Validating);

			txtTk_Cp1.Validating += new CancelEventHandler(txtTk1_Validating);
			txtTk_Cp2.Validating += new CancelEventHandler(txtTk2_Validating);
			txtTk_Cp3.Validating += new CancelEventHandler(txtTk3_Validating);
			txtTk_Cp4.Validating += new CancelEventHandler(txtTk4_Validating);
			txtTk_Den.Validating += new CancelEventHandler(txtTk_Den_Validating);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			if (enuNew_Edit == enuEdit.New)
				this.numStt.Value = Common.MaxDCValue(drEdit.Table, "Stt") + 1;

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

			if (txtTk_Cp.Text != string.Empty)
			{
				lbtTen_Tk_Cp.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk_Cp.Text);
			}
			else
				lbtTen_Tk_Cp.Text = string.Empty;

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

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!this.CheckFormValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "R07ZPHANBO", ref drEdit))
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

		void txtTk1_Validating(object sender, CancelEventArgs e)
		{
			if (!txtTk_Cp1.bTextChange)
				return;

			string strValue = txtTk_Cp1.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Cp1.Text = string.Empty;
			}
			else
			{
				txtTk_Cp1.Text = drLookup["Tk"].ToString();
			}
		}

		void txtTk2_Validating(object sender, CancelEventArgs e)
		{
			if (!txtTk_Cp2.bTextChange)
				return;

			string strValue = txtTk_Cp2.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Cp2.Text = string.Empty;
			}
			else
			{
				txtTk_Cp2.Text = drLookup["Tk"].ToString();
			}
		}

		void txtTk3_Validating(object sender, CancelEventArgs e)
		{
			if (!txtTk_Cp3.bTextChange)
				return;

			string strValue = txtTk_Cp3.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Cp3.Text = string.Empty;
			}
			else
			{
				txtTk_Cp3.Text = drLookup["Tk"].ToString();
			}
		}

		void txtTk4_Validating(object sender, CancelEventArgs e)
		{
			if (!txtTk_Cp4.bTextChange)
				return;

			string strValue = txtTk_Cp4.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Cp4.Text = string.Empty;
			}
			else
			{
				txtTk_Cp4.Text = drLookup["Tk"].ToString();
			}
		}

		void txtTk_Den_Validating(object sender, CancelEventArgs e)
		{
			if (!txtTk_Den.bTextChange)
				return;

			string strValue = txtTk_Den.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Den.Text = string.Empty;
			}
			else
			{
				txtTk_Den.Text = drLookup["Tk"].ToString();
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
