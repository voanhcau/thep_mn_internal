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
	public partial class frmCustomer_Edit : RosySystem.Customize.frmEdit
	{
		DataRow drCurrent;

		public frmCustomer_Edit()
		{
			InitializeComponent();

			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_CbNv_Validating);
			txtMa_Kv.Validating += new CancelEventHandler(txtMa_Kv_Validating);
			txtMa_Nh_Dt.Validating += new CancelEventHandler(txtMa_Nh_Dt_Validating);

			txtSP_Used.Validating += new CancelEventHandler(txtSP_Used_Validating);
			txtVon_CSH.Validating += new CancelEventHandler(txtVon_CSH_Validating);
			txtNganh_Nghe.Validating += new CancelEventHandler(txtNganh_Nghe_Validating);
			txtQuy_Mo.Validating += new CancelEventHandler(txtQuy_Mo_Validating);

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
				this.drEdit = DataTool.SQLGetDataRowByID("R81DmDt", "Ma_Dt", drCurrent["Ma_Dt"].ToString());
			else
			{
				this.drEdit = DataTool.SQLGetDataTable("R81DmDt", null, "0 = 1", "Ma_Dt").NewRow();
				Common.CopyDataRow(drCurrent, drEdit);
			}

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		void FillComboBox()
		{
			//cboSP_Used.DataSource = bdsType;
			//cboSP_Used.DisplayMember = "Type_Name";
			//cboSP_Used.ValueMember
		}

		void LoadDicName()
		{
			//Khu vực
			if (txtMa_Kv.Text.Trim() != string.Empty)
			{
				lbtTen_Kv.Text = (string)SQLExec.ExecuteReturnValue("SELECT Ten_Kv FROM R81DmKv WHERE Ma_Kv = '" + txtMa_Kv.Text + "'");
			}
			else
				lbtTen_Kv.Text = string.Empty;

			//SP_Used
			if (txtSP_Used.Text.Trim() != string.Empty)
			{
				lbtSP_Used.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'SP_USED' AND Type_ID = '" + txtSP_Used.Text + "'");				
			}
			else
				lbtSP_Used.Text = string.Empty;

			//Von_CSH
			if (txtVon_CSH.Text.Trim() != string.Empty)
			{
				lbtVon_CSH.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'VON_CSH' AND Type_ID = '" + txtVon_CSH.Text + "'");
			}
			else
				lbtVon_CSH.Text = string.Empty;

			//Nganh_Nghe
			if (txtNganh_Nghe.Text.Trim() != string.Empty)
			{
				lbtNganh_Nghe.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'NGANH_NGHE' AND Type_ID = '" + txtNganh_Nghe.Text + "'");
			}
			else
				lbtNganh_Nghe.Text = string.Empty;

			//Quy_Mo
			if (txtQuy_Mo.Text.Trim() != string.Empty)
			{
				lbtQuy_Mo.Text = (string)SQLExec.ExecuteReturnValue("SELECT Type_Name FROM R81DMTYPE WHERE Type = 'QUY_MO' AND Type_ID = '" + txtQuy_Mo.Text + "'");
			}
			else
				lbtQuy_Mo.Text = string.Empty;
		}

		bool FormCheckValid()
		{
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
				CRMLib.GetNewMa_Dt(drEdit);

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMDT", ref drEdit))
				return false;

			Common.CopyDataRow(drEdit, drCurrent);

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_DT", drEdit);

			return true;
		}

		void txtMa_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv.Text = string.Empty;
				lbtTen_Dt_Cbnv.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_Cbnv.Text = drLookup["Ten_Dt"].ToString();
			}
		}
		void txtMa_Kv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kv.Text = string.Empty;
				lbtTen_Kv.Text = string.Empty;
			}
			else
			{
				txtMa_Kv.Text = drLookup["Ma_Kv"].ToString();
				lbtTen_Kv.Text = drLookup["Ten_Kv"].ToString();
			}
		}
		void txtMa_Nh_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Dt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Dt.Text = string.Empty;
				lbtTen_Nh_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Dt.Text = drLookup["Ma_Nh_Dt"].ToString();
				lbtTen_Nh_Dt.Text = drLookup["Ten_Nh_Dt"].ToString();
			}
		}		

		void txtSP_Used_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtSP_Used.Text.Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "SP_USED");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtSP_Used.Text = string.Empty;
				lbtSP_Used.Text = string.Empty;
			}
			else
			{
				txtSP_Used.Text = drLookup["Type_ID"].ToString();
				lbtSP_Used.Text = drLookup["Type_Name"].ToString();
			}
		}

		void txtQuy_Mo_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtQuy_Mo.Text.Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "QUY_MO");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtQuy_Mo.Text = string.Empty;
				lbtQuy_Mo.Text = string.Empty;
			}
			else
			{
				txtQuy_Mo.Text = drLookup["Type_ID"].ToString();
				lbtQuy_Mo.Text = drLookup["Type_Name"].ToString();
			}
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
				lbtNganh_Nghe.Text = string.Empty;
			}
			else
			{
				txtNganh_Nghe.Text = drLookup["Type_ID"].ToString();
				lbtNganh_Nghe.Text = drLookup["Type_Name"].ToString();
			}
		}

		void txtVon_CSH_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtVon_CSH.Text.Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "VON_CSH");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtVon_CSH.Text = string.Empty;
				lbtVon_CSH.Text = string.Empty;
			}
			else
			{
				txtVon_CSH.Text = drLookup["Type_ID"].ToString();
				lbtVon_CSH.Text = drLookup["Type_Name"].ToString();
			}
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
	}
}
