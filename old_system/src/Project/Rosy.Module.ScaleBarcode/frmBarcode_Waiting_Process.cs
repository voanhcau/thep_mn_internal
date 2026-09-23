using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Library;

namespace RosyModule.ScaleBarcode
{
	public partial class frmBarcode_Waiting_Process : RosySystem.Customize.frmEdit
	{
		public frmBarcode_Waiting_Process()
		{
			InitializeComponent();
			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;

			this.FillData();

			Common.ScaterMemvar(this, ref drEdit);

            bool bTL = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Is_TL FROM R81DMBARCODE WHERE Barcode = '" + drEdit["Barcode"].ToString() + "'"));

            if (dteDate_Process.IsNull && !bTL)
				dteDate_Process.Text = Voucher.GetDate_Server().ToShortDateString();

            if (bTL)
            {
                dteNgay_XLNTL.Text = Voucher.GetDate_Server().ToShortDateString();
                dteDate_Process.Text = drEdit["Date_Process"].ToString();
            }

			this.BindingLanguage();
			this.LoadDicName();
			this.ShowDialog();
		}

		private void FillData()
		{
			rdbIs_OutPut.Checked = (bool)drEdit["Is_OutPut"];
		}

		private void LoadDicName()
		{
			
		}

		private bool FormCheckValid()
		{
			bool bValid = true;

			if (rdbIs_OutPut.Checked)
			{
				if (txtRemark_KCS.Text == string.Empty)
				{
					Common.MsgCancel(Languages.GetLanguage("Remark_KCS") + " " + Languages.GetLanguage("Not_Null"));
					bValid = false;
				}
			}

			return bValid;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!FormCheckValid())
				return false;

			drEdit["Is_OutPut"] = rdbIs_OutPut.Checked;
			drEdit["Ma_CL"] = "2";

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMBARCODE", ref drEdit))
				return false;

			if (drEdit.Table.Columns.Contains("Ten_CL"))
				drEdit["Ten_CL"] = DataTool.SQLGetNameByCode("R81DMCL", "Ma_CL", "Ten_CL", drEdit["Ma_CL"].ToString());

			return true;
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
			this.isAccept = false;
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Voucher.CheckDataLocked_Barcode((DateTime)drEdit["Ngay_Nhap"]))
			{
				btgAccept.btAccept.Enabled = false;
			}

			if (!Element.sysIs_Admin)
			{
				if (!Common.CheckPermission("ACCESS_KCS_STATUS", enuPermission_Type.Allow_Access))
					this.btgAccept.btAccept.Enabled = false;
			}
		}
	}
}
