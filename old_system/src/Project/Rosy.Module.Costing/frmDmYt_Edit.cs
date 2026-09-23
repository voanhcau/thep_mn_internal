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
	public partial class frmDmYt_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods
		public frmDmYt_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);
			txtTk_Cp.Validating += new CancelEventHandler(txtTk_Cp_Validating);
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
			if (txtMa_Yt.Text != string.Empty)
			{
				lbtTen_Tk_Cp.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtMa_Yt.Text);
			}
			else
				lbtTen_Tk_Cp.Text = string.Empty;

			if (txtTk_List.Text != string.Empty)
			{
				lbtTen_Tk_Cp.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk_List.Text);
			}
			else
				lbtTen_Tk_Cp.Text = string.Empty;
		}

		private bool CheckFormValid()
		{
			if (this.txtMa_Yt.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			if (this.txtTk_List.Text == string.Empty)
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

			if (!DataTool.SQLUpdate(enuNew_Edit, "R07DMYT", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_YT", drEdit);

			return true;
		}

		#endregion

		#region Events

		void txtMa_Km_Validating(object sender, CancelEventArgs e)
		{
			if (!txtMa_Km.bTextChange)
				return;

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
				txtMa_Km.Text = drLookup["Ma_Km"].ToString();
				lbtTen_Km.Text = drLookup["Ten_Km"].ToString();
			}
		}

		void txtTk_Cp_Validating(object sender, CancelEventArgs e)
		{
			if (!txtTk_Cp.bTextChange)
				return;

			string strValue = txtTk_Cp.Text.Trim();
			bool bRequire = false;

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
