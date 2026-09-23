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
	public partial class frmCtTsHH_Edit : RosySystem.Customize.frmEdit
	{
		#region Phuong thuc

		public frmCtTsHH_Edit()
		{
			InitializeComponent();

		

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);


			txtTrang_Thai_Ts.Validating += new CancelEventHandler(txtTrang_Thai_Ts_Validating);
			
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
			lbtTrang_Thai_Ts.Text = (txtTrang_Thai_Ts.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmType", "Type_ID", "Type_Name", txtTrang_Thai_Ts.Text.Trim(), "TYPE = 'TRANG_THAI_TS'"));

			
			//Ma_Bp
			if (txtTrang_Thai_Ts.Text.Trim() != string.Empty)
			{
				lbtTrang_Thai_Ts.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtTrang_Thai_Ts.Text.Trim());
			}
			else
				lbtTrang_Thai_Ts.Text = string.Empty;

			
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

			if (txtTrang_Thai_Ts.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Trang_Thai_Ts") + " " +
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

			//Kiem tra Valid CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R06CTTSHH", ref drEdit))
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

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTrang_Thai_Ts.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTrang_Thai_Ts.Text = string.Empty;
				lbtTrang_Thai_Ts.Text = string.Empty;
			}
			else
			{
				txtTrang_Thai_Ts.Text = ((string)drLookup["Ma_Bp"]).Trim();
				lbtTrang_Thai_Ts.Text = ((string)drLookup["Ten_Bp"]).Trim();
			}
		}

		void txtTrang_Thai_Ts_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTrang_Thai_Ts.Text.Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "TRANG_THAI_TS");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'TRANG_THAI_TS'", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTrang_Thai_Ts.Text = string.Empty;
				lbtTrang_Thai_Ts.Text = string.Empty;
			}
			else
			{
				txtTrang_Thai_Ts.Text = drLookup["Type_ID"].ToString();
				lbtTrang_Thai_Ts.Text = drLookup["Type_Name"].ToString();
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

        private void frmCtTsHH_Edit_Load(object sender, EventArgs e)
        {

        }
	}
}