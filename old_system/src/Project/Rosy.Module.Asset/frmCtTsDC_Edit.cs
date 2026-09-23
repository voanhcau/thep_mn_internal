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
	public partial class frmCtTsDC_Edit : RosySystem.Customize.frmEdit
	{
		#region Contructor

		public DataRow drCtTs;

		public frmCtTsDC_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			numTien_NG_Nt.Validating += new CancelEventHandler(numTien_NG_Nt_Validating);
			numTien_HM_Nt.Validating += new CancelEventHandler(numTien_Hao_Mon_Validating);
			numTien_CLech_Nt.Validating += new CancelEventHandler(numTien_Con_Lai_Validating);

			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Giam_Validating);

			//btInherit.Click += new EventHandler(btInherit_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit, DataRow drCtTs)
		{
			this.drEdit = drEdit;
			this.drCtTs = drCtTs;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

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
			this.Ma_Tte_Show();

			this.Tinh_Tien();
		}

		private void Ma_Tte_Show()
		{
			if ((string)drCtTs["Ma_Tte"] == Element.sysMa_Tte)
			{
				this.numTien_HM.Visible = false;
				this.numTien_NG.Visible = false;
				this.numTien_CLech.Visible = false;
			}
			else
			{
				this.numTien_HM.Visible = true;
				this.numTien_NG.Visible = true;
				this.numTien_CLech.Visible = true;
			}
		}

		private void LoadDicName()
		{
			lbtTen_Nvu.Text = (txtMa_Nvu.Text == "" ? "" : DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim()));
		}

		private void Tinh_Tien()
		{
			double dbTy_Gia = Convert.ToDouble(drCtTs["Ty_Gia"]);
			if (dbTy_Gia == 0)
				dbTy_Gia = 1;

			this.numTien_CLech_Nt.Value = numTien_NG_Nt.Value - numTien_HM_Nt.Value;

			this.numTien_NG.Value = Math.Round(this.numTien_NG_Nt.Value * dbTy_Gia, 0, MidpointRounding.AwayFromZero);
			this.numTien_HM.Value = Math.Round(this.numTien_HM_Nt.Value * dbTy_Gia, 0, MidpointRounding.AwayFromZero);
			this.numTien_CLech.Value = Math.Round(this.numTien_CLech_Nt.Value * dbTy_Gia, 0, MidpointRounding.AwayFromZero);
		}

		private bool FormCheckValid()
		{
			if (dteNgay_Ct.Text.Replace(" ", "") == "//")
			{
				Common.MsgOk(Languages.GetLanguage("Ngay_Ct") + " " +
							 Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtDien_Giai.Text == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Dien_Giai") + " " + Languages.GetLanguage("Cannot_Empty"));

				return false;
			}

			return true;
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R06CTTSDC", ref drEdit))
				return false;

			return true;
		}

		#endregion

		#region Su kien

		void txtMa_Tte_TextChanged(object sender, EventArgs e)
		{
			this.Ma_Tte_Show();
		}

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

		void numTien_NG_Nt_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_Con_Lai_Validating(object sender, CancelEventArgs e)
		{
			this.Tinh_Tien();
		}

		void numTien_Hao_Mon_Validating(object sender, CancelEventArgs e)
		{
			if (!chkIs_Giam_Ts.Checked)
				numTien_CLech_Nt.Value = numTien_NG_Nt.Value - numTien_HM_Nt.Value;

			this.Tinh_Tien();
		}

		void txtMa_Giam_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nvu.Text.Trim();
			bool bRequire = true;
			string strFilter = "(CHARINDEX('" + (string)drCtTs["Ma_Ct"] + "', Ma_Ct, 0) > 0)";
			string strValid = "Ma_Ct <> ''";

			DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, strFilter, strValid);
			//DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, null);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nvu.Text = string.Empty;
				lbtTen_Nvu.Text = string.Empty;
			}
			else
			{
				txtMa_Nvu.Text = ((string)drLookup["Ma_Nvu"]).Trim();
				lbtTen_Nvu.Text = ((string)drLookup["Ten_Nvu"]).Trim();
			}
		}

		void btInherit_Click(object sender, EventArgs e)
		{
			frmInheritVoucher frm = new frmInheritVoucher();
			frm.Load(this.drEdit);

			if (frm.Is_Accept)
			{
				
			}
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (this.enuNew_Edit == enuEdit.Edit)
			{
				if (!dteNgay_Ct.IsNull && !Common.CheckDataLocked(Library.StrToDate(dteNgay_Ct.Text)))
				{
					this.dteNgay_Ct.Enabled = false;
					this.btgAccept.btAccept.Enabled = false;

					return;
				}
			}
		}		
	}
}