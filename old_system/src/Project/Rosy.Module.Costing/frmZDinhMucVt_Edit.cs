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
	public partial class frmZDinhMucVt_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmZDinhMucVt_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
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
			if (txtMa_Vt_Sp.Text != string.Empty)
			{
				lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text);
				lbtDvt_Sp.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Dvt", txtMa_Vt_Sp.Text);
			}
			else
			{
				lbtTen_Vt_Sp.Text = string.Empty;
				lbtDvt_Sp.Text = string.Empty;
			}

			if (txtMa_Vt.Text != string.Empty)
			{
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text);
				lbtDvt.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Dvt", txtMa_Vt.Text);
			}
			else
			{
				lbtTen_Vt.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}
		}

		private bool CheckFormValid()
		{
			if (this.txtMa_Vt_Sp.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt_Sp") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			if (this.txtMa_Vt.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			if (this.txtNgay_Ap.Text.Replace(" ", "") == "//")
			{
				Common.MsgCancel(Languages.GetLanguage("Ngay_Ap") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (drEdit.Table.Columns.Contains("Ten_Vt_Sp"))
				drEdit["Ten_Vt_Sp"] = lbtTen_Vt_Sp.Text;

			if (drEdit.Table.Columns.Contains("TEN_VT"))
				drEdit["Ten_Vt"] = lbtTen_Vt.Text;

			if (drEdit.Table.Columns.Contains("Dvt"))
				drEdit["Dvt"] = lbtDvt.Text;

			//Gán định mức về 1 sản phẩm trong trường hợp không có định mức
			if (Convert.ToDouble(drEdit["So_Luong_Sp"]) == 0)
				drEdit["So_Luong_Sp"] = 1;

			if (!this.CheckFormValid())
				return false;

			if (!DataTool.SQLUpdate(enuNew_Edit, "R07ZDinhMucVt", ref drEdit))
				return false;

			return true;
		}

		#endregion

		#region Events

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
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
				lbtDvt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
				lbtDvt.Text = drLookup["Dvt"].ToString();
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
