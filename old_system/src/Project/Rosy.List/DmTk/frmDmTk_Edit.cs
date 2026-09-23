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
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmTk_Edit : RosyList.frmEdit
	{
		#region Phuong thuc

		public frmDmTk_Edit()
		{
			InitializeComponent();

			txtTk.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Tk.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

			txtTk.LostFocus += new EventHandler(txtTk_LostFocus);
			txtTk_Parent.Validating += new CancelEventHandler(txtTk_Parent_Validating);
		}

		void txtTk_LostFocus(object sender, EventArgs e)
		{
			VisibleBankInfo(txtTk.Text);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			this.BindingLanguage();
			this.LoadDicName();

			VisibleBankInfo((string)drEdit["Tk"]);
			txtMa_Tte_Goc.InputMask = (string)RosySystem.Library.Parameters.GetParaValue("MA_TTE_LIST");

			this.ShowDialog();
		}

		void VisibleBankInfo(string strTk)
		{
			string strTk_Nh_List = (string)Parameters.GetParaValue("TK_NH_LIST");

			if (Common.InlistLike(strTk, strTk_Nh_List))
			{
				lblSo_Tk_Nh.Visible = true;
				lblTen_Tk_Nh.Visible = true;
				lblTen_Tp_Nh.Visible = true;

				txtSo_Tk_Nh.Visible = true;
				txtTen_Tk_Nh.Visible = true;
				txtTen_Tp_Nh.Visible = true;

			}
			else
			{
				lblSo_Tk_Nh.Visible = false;
				lblTen_Tk_Nh.Visible = false;
				lblTen_Tp_Nh.Visible = false;

				txtSo_Tk_Nh.Visible = false;
				txtTen_Tk_Nh.Visible = false;
				txtTen_Tp_Nh.Visible = false;

			}
		}

		private void LoadDicName()
		{

			if (txtTk_Parent.Text.Trim() != string.Empty)
			{
				lbtTen_Tk_Parent.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk_Parent.Text.Trim());
			}
			else
				lbtTen_Tk_Parent.Text = string.Empty;
		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtTk.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Tk") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;
			}

			if (txtTen_Tk.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Tk") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtTk.Text.Trim() == txtTk_Parent.Text.Trim())
			{
				Common.MsgOk(Languages.GetLanguage("Tk_Parent") + " " +
								  Languages.GetLanguage("Invalid"));
				return false;
			}

			return bvalid;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMTK", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("TK", drEdit);

			return true;
		}

		#endregion

		#region Su kien

		void txtTk_Parent_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Parent.Text.Trim();
			bool bRequire = false;
			string strTkFillter = txtTk.Text.Trim().Length <= 3 ? txtTk.Text.Trim() : txtTk.Text.Trim().Substring(0, txtTk.Text.Trim().Length - 1);

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, " ('" + strTkFillter + "' LIKE Tk + '%' )");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Parent.Text = string.Empty;
				lbtTen_Tk_Parent.Text = string.Empty;
			}
			else
			{
				txtTk_Parent.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk_Parent.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}
		}

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmTk"))
				e.Cancel = true;
		}

		#endregion
	}
}