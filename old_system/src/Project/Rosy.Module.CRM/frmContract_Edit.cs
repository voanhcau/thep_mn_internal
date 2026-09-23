using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Public;
using RosyList;

namespace RosyModule.CRM
{
	public partial class frmContract_Edit : RosySystem.Customize.frmEdit
	{
		DataRow drCurrent;

		public frmContract_Edit()
		{
			InitializeComponent();

			txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Sp_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_Dt_CbNv_Kd.Validating += new CancelEventHandler(txtMa_CbNv_Kd_Validating);
			txtMa_Dt_CbNv_Tk.Validating += new CancelEventHandler(txtMa_CbNv_Tk_Validating);
			txtMa_Dt_CbNv_Lt.Validating += new CancelEventHandler(txtMa_CbNv_Lt_Validating);
			txtNganh_Nghe.Validating += new CancelEventHandler(txtNganh_Nghe_Validating);
			txtTinh_Trang_Hd.Validating += new CancelEventHandler(txtTinh_Trang_Hd_Validating);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(enuEdit enuNew_Edit, DataRow drCurrent)
		{
			this.drCurrent = drCurrent;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			//Hải xử lý: Khi Edit, lấy dữ liệu từ SQL ra (không lấy từ C# giống trước kia)
			if (enuNew_Edit == enuEdit.Edit)
				this.drEdit = DataTool.SQLGetDataRowByID("R81DmHd", "Ma_Hd", drCurrent["Ma_Hd"].ToString());
			else
			{
				this.drEdit = DataTool.SQLGetDataTable("R81DmHd", null, "0 = 1", "Ma_Hd").NewRow();
				Common.CopyDataRow(drCurrent, drEdit);
			}

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			if (enuNew_Edit == enuEdit.New)
			{
				CRMLib.GetNewMa_Hd(drEdit);
			}

			this.ShowDialog();
		}

		void FillComboBox()
		{
			//cboPM_Used.DataSource = bdsType;
			//cboPM_Used.DisplayMember = "Type_Name";
			//cboPM_Used.ValueMember
		}

		void LoadDicName()
		{
			//Ma_Sp
			if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
			{
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt_Sp", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
			}
			else
				lbtTen_Vt.Text = string.Empty;

			//Ma_Dt
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;

			//Ma_CbNv_Kd
			if (txtMa_Dt_CbNv_Kd.Text.Trim() != string.Empty)
			{
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv_Kd.Text.Trim());
			}
			else
				lbtTen_Dt_CbNv_Kd.Text = string.Empty;

			//Ma_CbNv_Tk
			if (txtMa_Dt_CbNv_Tk.Text.Trim() != string.Empty)
			{
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv_Tk.Text.Trim());
			}
			else
				lbtTen_Dt_CbNv_Tk.Text = string.Empty;

			//Ma_CbNv_Lt
			if (txtMa_Dt_CbNv_Lt.Text.Trim() != string.Empty)
			{
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv_Lt.Text.Trim());
			}
			else
				lbtTen_Dt_CbNv_Lt.Text = string.Empty;

			//Nganh_Nghe
			if (txtNganh_Nghe.Text.Trim() != string.Empty)
			{
				//lbtTen_Nganh_Nghe.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'NGANH_NGHE' AND Type_ID = '" + txtNganh_Nghe.Text + "'");
				lbtTen_Nganh_Nghe.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtNganh_Nghe.Text.Trim(), "Type = 'Nganh_Nghe'");
			}
			else
				lbtTen_Nganh_Nghe.Text = string.Empty;

			//Tinh_Trang
			if (txtTinh_Trang_Hd.Text.Trim() != string.Empty)
			{
				//lbtTen_Tinh_Trang_Hd.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'TINH_TRANG_HD' AND Type_ID = '" + txtTinh_Trang_Hd.Text + "'");
				lbtTen_Tinh_Trang_Hd.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtTinh_Trang_Hd.Text.Trim(), "Type = 'Tinh_Trang_Hd'");
			}
			else
				lbtTen_Tinh_Trang_Hd.Text = string.Empty;
		}

		bool FormCheckValid()
		{
			if (txtMa_Hd.Text == string.Empty)
			{
				Common.MsgCancel("Chưa khai báo mã hợp đồng");
				return false;
			}

			return true;
		}

		bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Tính Stt Max
			if (enuNew_Edit == enuEdit.New)
				CRMLib.GetNewMa_Hd(drEdit);

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMHD", ref drEdit))
				return false;

			Common.CopyDataRow(drEdit, drCurrent);

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
			{
				DataTool.SQLChangeID("MA_HD", drEdit);
				string strMa_Hd = ((string)drEdit["Ma_Hd"]);
				string strMa_Hd_Old = ((string)drEdit["Ma_Hd", DataRowVersion.Original]);

				if (strMa_Hd != strMa_Hd_Old && strMa_Hd != string.Empty)
				{
					string strSQLExec =
						"UPDATE R08Task SET Ma_Hd = '" + strMa_Hd + "' WHERE Task_Type = 'CONTRACT' AND Ma_Hd = '" + strMa_Hd_Old + "'";
					SQLExec.Execute(strSQLExec);
				}
			}

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

		void txtNganh_Nghe_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtNganh_Nghe.Text.Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "NGANH_NGHE");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtNganh_Nghe.Text = string.Empty;
				lbtTen_Nganh_Nghe.Text = string.Empty;
			}
			else
			{
				txtNganh_Nghe.Text = drLookup["Type_ID"].ToString();
				lbtTen_Nganh_Nghe.Text = drLookup["Type_Name"].ToString();
			}
		}

		void txtTinh_Trang_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTinh_Trang_Hd.Text.Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "TINH_TRANG_HD");

			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTinh_Trang_Hd.Text = string.Empty;
				lbtTen_Tinh_Trang_Hd.Text = string.Empty;
			}
			else
			{
				txtTinh_Trang_Hd.Text = drLookup["Type_ID"].ToString();
				lbtTen_Tinh_Trang_Hd.Text = drLookup["Type_Name"].ToString();
			}
		}

		void txtMa_CbNv_Lt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv_Lt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv_Lt.Text = string.Empty;
				lbtTen_Dt_CbNv_Lt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv_Lt.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv_Lt.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void txtMa_CbNv_Tk_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv_Tk.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv_Tk.Text = string.Empty;
				lbtTen_Dt_CbNv_Tk.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv_Tk.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv_Tk.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void txtMa_CbNv_Kd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv_Kd.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv_Kd.Text = string.Empty;
				lbtTen_Dt_CbNv_Kd.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv_Kd.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv_Kd.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void txtMa_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
			}
		}
	}
}
