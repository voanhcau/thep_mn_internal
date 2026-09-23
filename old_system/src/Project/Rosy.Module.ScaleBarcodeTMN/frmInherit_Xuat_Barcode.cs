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

namespace RosyModule.ScaleBarcodeTMN
{
	public partial class frmInherit_Xuat_Barcode : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInherit;
		BindingSource bdsInherit = new BindingSource();

		string strMa_Ct = string.Empty;
		DataRow drCurrent;
		DataRow drDmCt_Current;
		public bool Is_Accept = false;

		#endregion

		#region Contructor

		public frmInherit_Xuat_Barcode()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.btSearch.Click += new EventHandler(btSearch_Click);
			this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);
			//this.dgvInheritVoucher.CellContentClick += new DataGridViewCellEventHandler(dgvInheritVoucher_CellContentClick);
			//this.dgvInheritVoucher.CellClick += new DataGridViewCellEventHandler(dgvInheritVoucher_CellContentClick);
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
		}

		#endregion

		#region Method

		public void Load(frmVoucher_Scale_Edit frmVoucher_Edit, string strMa_Ct)
		{
			this.strMa_Ct = strMa_Ct;

			dteNgay_Ct1.Text = Library.DateToStr(Voucher.GetDate_Server());
			dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server());
			txtMa_Ct.Text = strMa_Ct;

			drDmCt_Current = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct.ToString());

			Build();
			FillData("");
			BindingLanguage();

			this.ShowDialog();
		}

		void Build()
		{
			dgvInheritVoucher.strZone = "INHERIT_CTX_BARCODE";
			dgvInheritVoucher.BuildGridView();
			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;

			if (dgvInheritVoucher.Columns.Contains("CHON"))
				dgvInheritVoucher.Columns["CHON"].ReadOnly = false;
		}

		void FillData(string strStt)
		{
			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

			if (drDmCt == null)
				return;

			string strKey = "(1=1) ";
			string strTableCt = drDmCt["Table_Ct"].ToString();

			if (strTableCt == string.Empty)
				return;

			Hashtable htPara = new Hashtable();
			htPara.Add("MA_CT", txtMa_Ct.Text);
			htPara.Add("STT", strStt);
			htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
			htPara.Add("SO_CT", txtSo_Ct.Text);
			htPara.Add("SO_XE", txtSo_Xe.Text);
			htPara.Add("MA_DT", txtMa_Dt.Text);
			htPara.Add("IS_INHERITED", chkInheritedExcept.Checked);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            dtInherit = SQLExec.ExecuteReturnDt("sp_Inherit_Xuat_Barcode_KKV", htPara, CommandType.StoredProcedure);

			bdsInherit.DataSource = dtInherit;
			dgvInheritVoucher.DataSource = bdsInherit;

			bdsSearch = bdsInherit;
			bdsLookup = bdsInherit;

		}

		bool FormCheckValid()
		{
			if (dtInherit == null || dtInherit.Select("Chon = true").Length == 0)
			{
				Common.MsgCancel("Không có dữ liệu kế thừa!");
				return false;
			}

			return true;
		}

		#endregion

		#region Event

		void txtMa_Ct_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Ct.Text.Trim();
			bool bRequire = true;
			string strKey = string.Empty;

			DataRow drLookup = Lookup.ShowLookup("Ma_Ct", strValue, bRequire, strKey);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
				txtMa_Ct.Text = string.Empty;
			else
			{
				txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();
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

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
				this.Is_Accept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

		void btRefresh_Click(object sender, EventArgs e)
		{
			if (txtMa_Ct.Text.Trim() == string.Empty)
			{
				Common.MsgCancel("Chưa nhập mã chứng từ");
				return;
			}

			this.FillData("");
		}

		void btSearch_Click(object sender, EventArgs e)
		{
			bool bRequire = true;
			string strKey = "Ma_Ct LIKE '" + txtMa_Ct.Text + "%' AND Loai_Ct = 2 AND So_Luong_Vao <> 0 AND So_Luong_Ra <> 0 AND So_Luong <> 0";

			DataRow drLookup = Lookup.ShowLookup("STT_SCALE", "", bRequire, strKey);

			if (drLookup != null)
			{
				txtMa_Ct.Text = (string)drLookup["Ma_Ct"];
				dteNgay_Ct1.Text = Library.DateToStr((DateTime)drLookup["Ngay_Ct"]);
				txtSo_Ct.Text = (string)drLookup["So_Ct"];
				txtMa_Dt.Text = (string)drLookup["Ma_Dt"];
				txtSo_Xe.Text = (string)drLookup["So_Xe"];
				txtSo_Xa_Lan_Tau.Text = (string)drLookup["So_Xa_Lan_Tau"];

				DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

				if (drDmCt == null)
					return;

				this.FillData((string)drLookup["Stt_Scale"]);
			}
		}

		void frmInheritVoucher_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				for (int i = 0; i < dtInherit.Rows.Count; i++)
				{
					dtInherit.Rows[i]["CHON"] = true;
				}
			}
			if (e.Control && e.KeyCode == Keys.U)
			{

				for (int i = 0; i < dtInherit.Rows.Count; i++)
				{
					dtInherit.Rows[i]["CHON"] = false;
				}
			}
		}

		//void dgvInheritVoucher_CellContentClick(object sender, DataGridViewCellEventArgs e)
		//{
		//	if (e.ColumnIndex < 0 || e.RowIndex < 0)
		//		return;

		//	//string strColumn_Name = dgvInheritVoucher.Columns[e.ColumnIndex].DataPropertyName.ToUpper();

		//	//if (strColumn_Name == "CHON")
		//	//	((DataRowView)bdsInherit.Current).Row[strColumn_Name] = !Convert.ToBoolean(((DataRowView)bdsInherit.Current).Row[strColumn_Name]);
		//}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5)
				this.FillData("");
			else if (e.Control)
			{
				if (e.KeyCode == Keys.A)
					foreach (DataRow dr in dtInherit.Rows)
						dr["Chon"] = true;
				else if (e.KeyCode == Keys.U)
					foreach (DataRow dr in dtInherit.Rows)
					{
						dr["Chon"] = false;
					}
			}
			else
				base.OnKeyDown(e);
		}

		#endregion

	}
}
