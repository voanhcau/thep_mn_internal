using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;
using System.Collections;

namespace RosyModule
{
	public partial class frmInherit_CtSO_Scale_KKV : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInheritVoucher;
		BindingSource bdsInheritVoucher = new BindingSource();
		
		string strMa_Ct = string.Empty;

		string strStt_Org = string.Empty;
		string strMa_Vt_Not_Except = string.Empty;
		string strMa_Vt_Except = string.Empty;

		public string strSo_Xe_TTKH = string.Empty;
		public string strSo_Xa_Lan_Tau_TTKH = string.Empty;
		public string strMa_Dt_TTKH = string.Empty;
		public string strMa_Vt_Sp_TTKH = string.Empty;
		public string strTen_Dt_TTKH = string.Empty;
		public string strTen_Vt_Sp_TTKH = string.Empty;
		public bool bIsUpdateInfo = false;

		private bool bCheckInfo = false;
		DataRow drCurrent, drDmCt_Current;
		
		public bool is_Accept = false;

		#endregion

		#region Contructor

		public frmInherit_CtSO_Scale_KKV()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);

			this.txtStt_Search.KeyDown += new KeyEventHandler(txtStt_Search_KeyDown);
		}

		new public void Load()
		{
			this.strMa_Ct = "SO";
			this.Build();

			if (!string.IsNullOrEmpty(this.strStt_Org))
				this.FillData();

			this.BindingLanguage();
			this.ShowDialog();
		}

		public void Load(string strStt_Org, string strMa_Vt_Not_Except, bool bCheckInfo)
		{
			this.strStt_Org = strStt_Org;
			this.strMa_Vt_Not_Except = strMa_Vt_Not_Except;
			this.bCheckInfo = bCheckInfo;

			if (this.bCheckInfo && this.strStt_Org == string.Empty)
				this.bCheckInfo = false;

			this.Load();
		}

		#endregion

		#region Method

		void Build()
		{
            dgvInheritVoucher.strZone = "INHERIT_LXH_SCALE_KKV";
			dgvInheritVoucher.BuildGridView();

			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;

			if (dgvInheritVoucher.Columns.Contains("CHON"))
				dgvInheritVoucher.Columns["CHON"].ReadOnly = false;

			this.dgvInheritVoucher.ResizeGridView(100);
		}

		void FillData()
		{
            
			if (!string.IsNullOrEmpty(this.strStt_Org))
			{
				string strSQLExec = "SELECT * FROM R80PH WHERE Ma_Ct LIKE 'SO' AND Stt = '" + this.strStt_Org + "'";
				DataTable dtPh = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
				if (dtPh.Rows.Count > 0)
				{
					DataRow drPh = dtPh.Rows[0];
					if (drPh != null)
					{
						txtStt_Search.Enabled = false;

						txtStt.Text = drPh["Stt"].ToString();
						txtSo_Ct.Text = drPh["So_Ct"].ToString();
					}
				}
				else
				{
					Common.MsgCancel("Không tồn tại số phiếu { " + strStt_Org + "} này");
					txtStt.Text = txtSo_Ct.Text = this.txtStt_Search.Text = string.Empty;
					this.txtStt_Search.Focus();
				}
			}

			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", this.strMa_Ct);

			if (drDmCt == null)
				return;

			string strKey = "(1=1)";
			string strTableCt = drDmCt["Table_Ct"].ToString();

			if (strTableCt == string.Empty)
				return;

			DataTable dtTestData = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM " + strTableCt + " WHERE 0 = 1");

			if (!string.IsNullOrEmpty(txtStt.Text.Trim()))
				strKey += " AND (Stt = '" + txtStt.Text.Trim() + "')";

			if (!string.IsNullOrEmpty(this.strStt_Org))
			{
				strMa_Vt_Except = SQLExec.ExecuteReturnValue("SELECT Ma_Vt_Org + ',' FROM R80PH_SCALE WHERE Stt_Org = '" + strStt_Org + "' FOR XML PATH('')", CommandType.Text).ToString();

				if (strMa_Vt_Except.EndsWith(","))
					strMa_Vt_Except = strMa_Vt_Except.Substring(0, strMa_Vt_Except.Length - 1);

				string strKey_Ma_Vt_Except = string.Empty;
				foreach (string str in strMa_Vt_Except.Split(','))
				{
					if (string.IsNullOrEmpty(str))
						continue;

					if (Common.Inlist(str, strMa_Vt_Not_Except))
						continue;

					strKey_Ma_Vt_Except += "'" + str + "',";
				}

				if (strKey_Ma_Vt_Except.EndsWith(","))
					strKey_Ma_Vt_Except = strKey_Ma_Vt_Except.Substring(0, strKey_Ma_Vt_Except.Length - 1);

				if (!string.IsNullOrEmpty(strKey_Ma_Vt_Except))
					strKey += " AND (Ma_Vt NOT IN(" + strKey_Ma_Vt_Except + "))";
			}
            @strKey = @strKey + " AND So_Ct = '" + txtStt_Search.Text + "'";
			string strQuery = @"
					SELECT *, CAST(0 AS BIT) AS Chon 
						FROM " + strTableCt + @"
						WHERE " + @strKey + @"
						ORDER BY Stt,Stt0";

			dtInheritVoucher = SQLExec.ExecuteReturnDt(strQuery);

			bdsInheritVoucher.DataSource = dtInheritVoucher;
			dgvInheritVoucher.DataSource = bdsInheritVoucher;

			bdsSearch = bdsInheritVoucher;
			bdsLookup = bdsInheritVoucher;


			if (dtInheritVoucher.Rows.Count > 0)
			{
				strSo_Xe_TTKH = txtSo_Xe.Text = dtInheritVoucher.Rows[0]["So_Xe"].ToString();
				strSo_Xa_Lan_Tau_TTKH = txtSo_Xa_Lan_Tau.Text = dtInheritVoucher.Rows[0]["So_Xa_Lan_Tau"].ToString();
				strMa_Dt_TTKH = txtMa_Dt.Text = dtInheritVoucher.Rows[0]["Ma_Dt"].ToString();
				strTen_Dt_TTKH = lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());

				if (dtInheritVoucher.Rows[0]["Ma_Vt"].ToString().StartsWith("B"))
				{
					strMa_Vt_Sp_TTKH = txtMa_Vt_Sp.Text = "CP";
					strTen_Vt_Sp_TTKH = lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
				}
				else
				{
					strMa_Vt_Sp_TTKH = txtMa_Vt_Sp.Text = string.Empty;
					strTen_Vt_Sp_TTKH = lbtTen_Vt_Sp.Text = string.Empty;
				}
			}
			else
			{
				strSo_Xe_TTKH = strSo_Xa_Lan_Tau_TTKH = strMa_Dt_TTKH = strMa_Vt_Sp_TTKH = strTen_Dt_TTKH = strTen_Vt_Sp_TTKH = string.Empty;
			}
		}

		bool FormCheckValid()
		{
			if (dtInheritVoucher == null || dtInheritVoucher.Select("Chon = true").Length == 0)
			{
				Common.MsgCancel("Không có dữ liệu kế thừa!");
				return false;
			}

			return true;
		}

		#endregion

		#region Event

		void txtStt_Search_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				string strValue = txtStt_Search.Text.Trim();

				if (strValue.StartsWith("]C1"))
					strValue = strValue.Substring(3, strValue.Length - 3);

				txtStt_Search.Text = strValue;

				string strSQLExec = "SELECT * FROM R80PH WHERE Ma_Ct LIKE 'SO' AND Stt = '" + txtStt_Search.Text.Trim() + "'";
				DataTable dtPh = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
				if (dtPh.Rows.Count > 0)
				{
					DataRow drPh = dtPh.Rows[0];
					if (drPh != null)
					{
						txtStt.Text = drPh["Stt"].ToString();
						txtSo_Ct.Text = drPh["So_Ct"].ToString();

						this.FillData();
					}
				}
				else
				{
					Common.MsgCancel("Không tồn tại số phiếu { " + txtStt_Search.Text.Trim() + "} này");
					txtStt.Text = txtSo_Ct.Text = this.txtStt_Search.Text = string.Empty;
					this.txtStt_Search.Focus();
				}

				if (string.IsNullOrEmpty(this.txtStt_Search.Text.Trim()))
					this.txtStt_Search.Focus();

				this.txtStt_Search.Text = string.Empty;
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
				this.is_Accept = true;
				this.Close();
			}
			else
			{
				if (bCheckInfo)
				{
					if (Common.MsgYes_No("Bạn có muốn tiếp tục kiểm tra thông tin khách hàng thay đổi không?", "Y"))
					{
						this.bIsUpdateInfo = true;
						this.is_Accept = true;
						this.Close();
					}
				}
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.is_Accept = false;
			this.Close();
		}

		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void frmInheritVoucher_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{

				for (int i = 0; i < dtInheritVoucher.Rows.Count; i++)
				{
					dtInheritVoucher.Rows[i]["CHON"] = true;
				}
			}
			if (e.Control && e.KeyCode == Keys.U)
			{

				for (int i = 0; i < dtInheritVoucher.Rows.Count; i++)
				{
					dtInheritVoucher.Rows[i]["CHON"] = false;
				}
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5)
				this.FillData();
			else if (e.Control)
			{
				if (e.KeyCode == Keys.A)
					foreach (DataRow dr in dtInheritVoucher.Rows)
						dr["Chon"] = true;
				else if (e.KeyCode == Keys.U)
					foreach (DataRow dr in dtInheritVoucher.Rows)
						dr["Chon"] = false;
			}
			else
				base.OnKeyDown(e);
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			txtStt_Search.Focus();
		}
	}
}
