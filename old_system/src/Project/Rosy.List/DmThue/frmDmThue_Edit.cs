using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmThue_Edit : RosyList.frmEdit
	{

		#region Phuong thuc

		public frmDmThue_Edit()
		{
			InitializeComponent();

			txtTk.Validating += new CancelEventHandler(txtTk_Validating);
			txtPhan_Loai_Thue.Validating += new CancelEventHandler(txtPhan_Loai_Thue_Validating);

			txtMa_Thue.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Thue.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
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
			if (txtTk.Text.Trim() != string.Empty)
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk.Text.Trim());
			else
				lbtTen_Tk.Text = string.Empty;

            if (txtPhan_Loai_Thue.Text.Trim() != string.Empty)
                lbtTen_Phan_Loai_Thue.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtPhan_Loai_Thue.Text.Trim(), "TYPE = 'PHAN_LOAI_THUE'");
            else
                lbtTen_Phan_Loai_Thue.Text = string.Empty;

		}

		public override bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Thue.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Thue") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;
			}

			if (txtTen_Thue.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Thue") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			return bvalid;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMTHUE", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_THUE", drEdit);

			return true;
		}

		#endregion

		#region Su kien

		void txtTk_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk.Text = string.Empty;
				lbtTen_Tk.Text = string.Empty;
			}
			else
			{
				txtTk.Text = ((string)drLookup["Tk"]).Trim();
				lbtTen_Tk.Text = ((string)drLookup["Ten_Tk"]).Trim();
			}
		}

		void txtPhan_Loai_Thue_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtPhan_Loai_Thue.Text.Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "PHAN_LOAI_THUE");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'PHAN_LOAI_THUE'", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtPhan_Loai_Thue.Text = string.Empty;
				lbtTen_Phan_Loai_Thue.Text = string.Empty;
			}
			else
			{
				txtPhan_Loai_Thue.Text = drLookup["Type_ID"].ToString();
				lbtTen_Phan_Loai_Thue.Text = drLookup["Type_Name"].ToString();
			}
		}

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmThue"))
				e.Cancel = true;
		}

		#endregion
	}
}