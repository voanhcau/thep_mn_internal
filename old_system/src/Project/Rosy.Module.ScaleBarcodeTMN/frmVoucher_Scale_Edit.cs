using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Library;

namespace RosyModule.ScaleBarcodeTMN
{
	public partial class frmVoucher_Scale_Edit : RosySystem.Customize.frmEdit
	{
		public DataSet dsVoucher;
		public BindingSource bdsEditCt = new BindingSource();
		public BindingSource bdsEditCt_TR = new BindingSource();
		public BindingSource bdsEdit_TR = new BindingSource();

		public DataTable dtEditPh;
		public DataRow drEditPh;

		public DataTable dtEditCt;
		public DataRow drCurrent;

		public DataRow drDmCt;
		public DataRow drDmNvu;

		public string strStt = string.Empty;
		public string strMa_Ct = string.Empty;
		public bool bDgvEditCtFocusing = false;

		public rsDictionary dicName = new rsDictionary();
		public DataTable dtHanTt0;
		public DataTable dtEditCt_LR;

		public frmVoucher_Scale_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public virtual void Load(enuEdit enuNew_Edit, DataRow drEdit, DataSet dsVoucher)
		{

		}

		public virtual bool Save()
		{
			return true;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			//SaveOption: 

			if (cboSaveOption.Text.StartsWith("1")) //Lưu & Nhập tiếp
			{
				this.isAccept = true;

				if (this.Save())
				{
					this.Load(enuEdit.New, drEdit, dsVoucher);
				}
			}
			else if (cboSaveOption.Text.StartsWith("2")) //Lưu & Đóng lại
			{
				this.isAccept = true;

				if (this.Save())
				{
					this.Close();
				}
			}
			else if (cboSaveOption.Text.StartsWith("3")) //Lưu - In & Nhập tiếp
			{
				this.isAccept = true;
				bool bInVisibleNextPrint = false;

				if (this.Save())
				{
					Voucher.Print(this.strStt, true, true, ref bInVisibleNextPrint);

					this.Load(enuEdit.New, drEdit, dsVoucher);
				}
			}
			else if (cboSaveOption.Text.StartsWith("4")) //Lưu - In & Đóng lại
			{
				this.isAccept = true;
				bool bInVisibleNextPrint = false;

				if (this.Save())
				{
					this.Close();

					Voucher.Print(this.strStt, true, true, ref bInVisibleNextPrint);
				}
			}
			else if (cboSaveOption.Text.StartsWith("5")) //In & Nhập tiếp
			{
				this.isAccept = false;
				bool bInVisibleNextPrint = false;

				Voucher.Print(this.strStt, true, true, ref bInVisibleNextPrint);
				this.Load(enuEdit.New, drEdit, dsVoucher);
			}
			else if (cboSaveOption.Text.StartsWith("6")) //In & Đóng lại
			{
				this.isAccept = false;
				bool bInVisibleNextPrint = false;

				Voucher.Print(this.strStt, true, true, ref bInVisibleNextPrint);
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			
			//Kiem tra Permission
			if (Element.Is_Running)
			{
				switch (this.enuNew_Edit)
				{
					case enuEdit.New:
					case enuEdit.Copy:
						{
							this.btgAccept.btAccept.Enabled = Common.CheckPermission((string)drDmCt["Object_ID"], enuPermission_Type.Allow_New);
							break;
						}
					case enuEdit.Edit:
						this.btgAccept.btAccept.Enabled = Common.CheckPermission((string)drDmCt["Object_ID"], enuPermission_Type.Allow_Edit);
							break;
				
					default:
						break;
				}

				if (enuNew_Edit == enuEdit.Edit)
					lblLog.Text = "Create: " + Common.Show_Log((string)drEditPh["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEditPh["LastModify_Log"]);
				else
					lblLog.Text = "";
			}
		}

		protected override void OnClosed(EventArgs e)
		{
			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				Common.SetBufferValue("Voucher_Save_Option", cboSaveOption.Text);

			base.OnClosed(e);
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.F4)
			{
				if (this.ActiveControl.GetType().Name == "dgvVoucher")
					bDgvEditCtFocusing = true;
				else
					if (bDgvEditCtFocusing)
						bDgvEditCtFocusing = false;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
