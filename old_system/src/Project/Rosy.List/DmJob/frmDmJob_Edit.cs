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
	public partial class frmDmJob_Edit : RosyList.frmEdit
	{

        #region Phuong thuc

		public frmDmJob_Edit()
		{
			InitializeComponent();

			txtMa_Job.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Job.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

			txtMa_Job_Parent.Validating += new CancelEventHandler(txtMa_Job_Parent_Validating);
            txtMa_Xe.Validating += TxtMa_Xe_Validating;
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
			if (txtMa_Job_Parent.Text.Trim() != string.Empty)
			{
				lbtTen_Job_Cha.Text = DataTool.SQLGetNameByCode("R81DMJOB", "Ma_Job", "Ten_Job", txtMa_Job_Parent.Text.Trim());
			}
			else
				lbtTen_Job_Cha.Text = string.Empty;

		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Job.Text.Trim() == string.Empty)
            {
				Common.MsgCancel(Languages.GetLanguage("Ma_Job") + " " +
							  Languages.GetLanguage("Not_Null"));
				
				return false;
            }			

			if (txtTen_Job.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ten_Job") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMJOB", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_JOB", drEdit);

			return true;
		}

		#endregion

		#region Su kien
		void txtMa_Job_Parent_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Job_Parent.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Job", strValue, bRequire, "Nh_Cuoi = '0'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Job_Parent.Text = string.Empty;
				lbtTen_Job_Cha.Text = string.Empty;
			}
			else
			{
				txtMa_Job_Parent.Text = ((string)drLookup["Ma_Job"]).Trim();
				lbtTen_Job_Cha.Text = ((string)drLookup["Ten_Job"]).Trim();
			}
		}
		private void TxtMa_Xe_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Xe.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Xe", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Xe.Text = string.Empty;
				lbtTen_Xe.Text = string.Empty;
			}
			else
			{
				txtMa_Xe.Text = ((string)drLookup["Ma_Xe"]).Trim();
				lbtTen_Xe.Text = ((string)drLookup["Ten_Xe"]).Trim();
			}
		}
		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmJob"))
				e.Cancel = true;
		}

        #endregion 

		private void lblMa_Bp_Parent_Click(object sender, EventArgs e)
		{

		}
	}
}