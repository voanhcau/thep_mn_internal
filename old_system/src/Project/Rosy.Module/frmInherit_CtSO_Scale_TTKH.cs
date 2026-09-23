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
	public partial class frmInherit_CtSO_Scale_TTKH : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInheritVoucher;
		BindingSource bdsInheritVoucher = new BindingSource();
		
		public bool is_Accept = false;
		string strMa_Ct = string.Empty;
		string strStt_Org = string.Empty;
		string strSo_Xe_TTKH = string.Empty;
		string strSo_Xa_Lan_Tau_TTKH = string.Empty;
		string strMa_Dt_TTKH = string.Empty;
		string strMa_Vt_Sp_TTKH = string.Empty;

		#endregion

		#region Contructor

		public frmInherit_CtSO_Scale_TTKH()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			this.txtStt_Search.KeyDown += new KeyEventHandler(txtStt_Search_KeyDown);
		}

		new public void Load(string strStt_Org, string strSo_Xe_TTKH, string strSo_Xa_Lan_Tau_TTKH, string strMa_Dt_TTKH, string strMa_Vt_Sp_TTKH)
		{
			this.strMa_Ct = "LXH";
			this.strStt_Org = strStt_Org;
			this.strSo_Xe_TTKH = strSo_Xe_TTKH;
			this.strSo_Xa_Lan_Tau_TTKH=strSo_Xa_Lan_Tau_TTKH;
			this.strMa_Dt_TTKH=strMa_Dt_TTKH;
			this.strMa_Vt_Sp_TTKH = strMa_Vt_Sp_TTKH;

			this.BindingLanguage();
			this.ShowDialog();
		}

		#endregion

		#region Method

		bool FormCheckValid()
		{
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

				if (this.strStt_Org != txtStt_Search.Text.Trim())
				{
					Common.MsgCancel("Kế thừa LXH sai với số LXH củ");
					txtStt.Text = txtSo_Ct.Text = txtSo_Xe.Text = txtSo_Xa_Lan_Tau.Text = txtMa_Dt.Text = lbtTen_Dt.Text = txtMa_Vt_Sp.Text = lbtTen_Vt_Sp.Text = string.Empty;
					this.txtStt_Search.Focus();
					return;
				}

                string strSQLExec = "SELECT TOP 1 * FROM R04CTSO WHERE Ma_Ct LIKE 'LXH%' AND Stt = '" + txtStt_Search.Text.Trim() + "' AND Stt_Org NOT IN (SELECT Stt FROM R80PH WHERE Duyet_Huy = 1)";

				DataTable dtInherit = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
				if (dtInherit.Rows.Count > 0)
				{
					DataRow drInherit = dtInherit.Rows[0];

					txtStt.Text = drInherit["Stt"].ToString();
					txtSo_Ct.Text = drInherit["So_Ct"].ToString();
					txtSo_Xe.Text = drInherit["So_Xe"].ToString();
					txtSo_Xa_Lan_Tau.Text = drInherit["So_Xa_Lan_Tau"].ToString();

					txtMa_Dt.Text = drInherit["Ma_Dt"].ToString();
					lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());

					if (drInherit["Ma_Vt"].ToString().StartsWith("B"))
					{
						txtMa_Vt_Sp.Text = "CP";
						lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
					}
					else
					{
						txtMa_Vt_Sp.Text = string.Empty;
						lbtTen_Vt_Sp.Text = string.Empty;
					}
				}
				else
				{
					Common.MsgCancel("Không tồn tại số phiếu { " + txtStt.Text.Trim() + "} này");
					txtStt.Text = txtSo_Ct.Text = txtSo_Xe.Text = txtSo_Xa_Lan_Tau.Text = txtMa_Dt.Text = lbtTen_Dt.Text = txtMa_Vt_Sp.Text = lbtTen_Vt_Sp.Text = string.Empty;
					this.txtStt_Search.Focus();
				}

				if (string.IsNullOrEmpty(this.txtStt_Search.Text.Trim()))
					this.txtStt_Search.Focus();

				this.txtStt_Search.Text = string.Empty;

				if ((this.strSo_Xe_TTKH == txtSo_Xe.Text)
						&& (this.strSo_Xa_Lan_Tau_TTKH == txtSo_Xa_Lan_Tau.Text)
						&& (this.strMa_Dt_TTKH == txtMa_Dt.Text)
						&& (this.strMa_Vt_Sp_TTKH == txtMa_Vt_Sp.Text))
					btgAccept.btAccept.Enabled = false;
				else
					btgAccept.btAccept.Enabled = true;
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			this.is_Accept = true;
			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.is_Accept = false;
			this.Close();
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			txtStt_Search.Focus();
		}
	}
}
