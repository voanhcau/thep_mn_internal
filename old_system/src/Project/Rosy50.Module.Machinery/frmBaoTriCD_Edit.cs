using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;

namespace RosyModule.Machinery
{
	public partial class frmBaoTriCD_Edit : RosySystem.Customize.frmEdit
	{
		public frmBaoTriCD_Edit()
		{
			InitializeComponent();			
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Vt_Tb.Validating += new CancelEventHandler(txtMa_Vt_Tb_Validating);
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			txtMa_Bp_YC.Validating += new CancelEventHandler(txtMa_Bp_YC_Validating);
			txtMa_Dt_Cbnv_Yc.Validating += new CancelEventHandler(txtMa_Dt_Cbnv_Yc_Validating);
			txtMa_Dt_Cbnv_Bt.Validating += new CancelEventHandler(txtMa_Dt_Cbnv_Bt_Validating);
		}

		void txtMa_Vt_Tb_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Tb.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, string.Empty);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Tb.Text = string.Empty;
				lbtTen_Vt_Tb.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Tb.Text = (string)drLookup["Ma_Vt"];
				lbtTen_Vt_Tb.Text = (string)drLookup["Ten_Vt"];
			}
		}

		void txtMa_Dt_Cbnv_Bt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_Cbnv_Bt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_Cbnv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_Cbnv_Bt.Text = string.Empty;
				lbtTen_Dt_Cbnv_Bt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_Cbnv_Bt.Text = (string)drLookup["Ma_Dt"];
				lbtTen_Dt_Cbnv_Bt.Text = (string)drLookup["Ten_Dt"];
			}
		}

		void txtMa_Dt_Cbnv_Yc_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_Cbnv_Yc.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_Cbnv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_Cbnv_Yc.Text = string.Empty;
				lbtTen_Dt_Cbnv_Yc.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_Cbnv_Yc.Text = (string)drLookup["Ma_Dt"];
				lbtTen_Dt_Cbnv_Yc.Text = (string)drLookup["Ten_Dt"];
			}
		}

		void txtMa_Bp_YC_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp_YC.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Bp_YC.Text = string.Empty;
				lbtTen_Bp_YC.Text = string.Empty;
			}
			else
			{
				txtMa_Bp_YC.Text = (string)drLookup["Ma_Bp"];
				lbtTen_Bp_YC.Text = (string)drLookup["Ten_Bp"];
			}
		}

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Bp.Text = string.Empty;
				lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = (string)drLookup["Ma_Bp"];
				lbtTen_Bp.Text = (string)drLookup["Ten_Bp"];
			}
		}

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);
			
			if (this.enuNew_Edit == enuEdit.New)
			{
				dteNgay_Sua_Chua.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
				dteThoi_Gian_Hoan_Thanh.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
			}
			else
			{
				if (drEdit["Ngay_Sua_Chua"] != DBNull.Value) 
					dteNgay_Sua_Chua.Text = Convert.ToDateTime(drEdit["Ngay_Sua_Chua"]).ToString("dd/MM/yyyy HH:mm:ss");

				if (drEdit["Thoi_Gian_Hoan_Thanh"] != DBNull.Value)
					dteThoi_Gian_Hoan_Thanh.Text = Convert.ToDateTime(drEdit["Thoi_Gian_Hoan_Thanh"]).ToString("dd/MM/yyyy HH:mm:ss");
			}

			BindingLanguage();
			LoadDicName();
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{

			if (txtNoi_Dung.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Noi_Dung") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			//if (txtMa_Bp_YC.Text == string.Empty)
			//{
			//    Common.MsgCancel(Languages.GetLanguage("Ma_Bp_YC") + " " + Languages.GetLanguage("Not_Null"));
			//    return false;
			//}

			return true;
		}

		private void LoadDicName()
		{
			//Mã vật tư thiết bị
			if (txtMa_Vt_Tb.Text.Trim() != string.Empty)
			{
				lbtTen_Vt_Tb.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Tb.Text.Trim());
			}
			else
				lbtTen_Vt_Tb.Text = string.Empty;

			//Người yêu cầu
			if (txtMa_Dt_Cbnv_Yc.Text.Trim() != string.Empty)
			{
				lbtTen_Dt_Cbnv_Yc.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_Cbnv_Yc.Text.Trim());
			}
			else
				lbtTen_Dt_Cbnv_Yc.Text = string.Empty;

			//Người thực hiện
			if (txtMa_Dt_Cbnv_Bt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt_Cbnv_Bt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_Cbnv_Bt.Text.Trim());
			}
			else
				lbtTen_Dt_Cbnv_Bt.Text = string.Empty;

			//Bộ phận yêu cầu
			if (txtMa_Bp_YC.Text.Trim() != string.Empty)
			{
				lbtTen_Bp_YC.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp_YC.Text.Trim());
			}
			else
				lbtTen_Bp_YC.Text = string.Empty;

			if (txtMa_Bp.Text.Trim() != string.Empty)
			{
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			}
			else
				lbtTen_Bp.Text = string.Empty;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            drEdit["Trong_Ke_Hoach"] = rdbTrong_Ke_Hoach.Checked;

            if (drEdit.Table.Columns.Contains("Ngoai_Ke_Hoach"))
                drEdit["Ngoai_Ke_Hoach"] = rdbNgoai_Ke_Hoach.Checked;

            drEdit["TypeOfMaintenance"] = rdbBao_Tri.Checked ? "Kiểm tra" : "Thay thế";

			if (drEdit.Table.Columns.Contains("Ten_Vt_Tb"))
				drEdit["Ten_Vt_Tb"] = lbtTen_Vt_Tb.Text;

			if (!DataTool.SQLUpdate(enuNew_Edit, "R06BTSC",ref drEdit))
				return false;

			return true;
		}

		#region event

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			//Kiem tra Permission
			switch (this.enuNew_Edit)
			{
				case enuEdit.New:
					this.btgAccept.btAccept.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New);
					break;
				case enuEdit.Edit:
					this.btgAccept.btAccept.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
					break;
				default:
					break;
			}


			if (enuNew_Edit == enuEdit.Edit)
				lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
			else
				lblLog.Text = "";
		}
		#endregion

	}
}
