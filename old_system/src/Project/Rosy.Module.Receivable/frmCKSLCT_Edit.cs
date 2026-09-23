using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Library;
using RosyList;
using RosySystem;
using RosySystem.Common;
using RosySystem.Public;
using RosySystem.Element;

namespace RosyModule.Receivable
{
	public partial class frmCKSLCT_Edit : RosySystem.Customize.frmEdit
	{
		#region Phuong thuc

		public frmCKSLCT_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Ts_Validating);
			
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
            txtMa_Vt.bUseAutoDropDown = true;
            txtMa_Vt.strLookupKeyFilter = "Ma_Nh_Vt = 'VTAPGIA'";
			//Ma_Ts
			if (txtMa_Vt.Text.Trim() != string.Empty)
			{
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
			}
			else
				lbtTen_Vt.Text = string.Empty;
		
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;

			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Vt") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

            if (numGia.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Gia") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

		

			

			return bvalid;
		}

		private bool Save()
		{
			
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;
            drEdit["Ma_Data"] = Element.sysMa_Data;
			//Kiem tra Valid CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R04CKSLCT", ref drEdit))
				return false;

			return true;
		}

		#endregion

		#region Su kien

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

		#region Ma_Ts

		void txtMa_Ts_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = ((string)drLookup["Ma_Vt"]).Trim();
				lbtTen_Vt.Text = ((string)drLookup["Ten_Vt"]).Trim();
			}
		}
		#endregion

		

		

		

		

		

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			
		}
	}
}