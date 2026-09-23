using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyModule.General
{
	public partial class frmChiPhiDK_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmChiPhiDK_Edit()
		{
			InitializeComponent();

			
			this.txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			this.txtTk.Validating += new CancelEventHandler(txtTk_Validating);
			
		
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			if (enuNew_Edit == enuEdit.New)
			{
				//drEdit["Tien_Kh"] = 0;
				//drEdit["Tien_Kh_Nt"] = 0;
			}

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{

			if (txtMa_Kho.Text.Trim() != string.Empty)
				lbtTen_Kho.Text = DataTool.SQLGetNameByCode("R81DmKho", "Ma_Kho", "Ten_Kho", txtMa_Kho.Text.Trim());
			else
				lbtTen_Kho.Text = string.Empty;

			if (txtTk.Text.Trim() != string.Empty)
				lbtTk.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk.Text.Trim());
			else
				lbtTk.Text = string.Empty;

			
		}

		public bool FormCheckValid()
		{
			if (txtTk.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Cannot_Empty"));
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

			
			if (!DataTool.SQLUpdate(this.enuNew_Edit, "R80CHIPHIDK", ref drEdit))
				return false;

			return true;
		}



		#endregion

		#region Events

		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho.Text = string.Empty;
				lbtTen_Kho.Text = string.Empty;
			}
			else
			{
				txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
				lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
			}
		}


		void txtTk_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk.Text = string.Empty;
				lbtTk.Text = string.Empty;
			}
			else
			{
				txtTk.Text = drLookup["Tk"].ToString();
				lbtTk.Text = drLookup["Ten_Tk"].ToString();
			}
		}

		
		private void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			//if (this.enuNew_Edit == enuEdit.Edit)
			//{
			//    if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
			//    {
			//        this.dteNgay_Ct.Enabled = false;
			//        this.btgAccept.btAccept.Enabled = false;
			//    }
			//}
		}

        private void lblOng_Ba_Click(object sender, EventArgs e)
        {

        }
    }
}
