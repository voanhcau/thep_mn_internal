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

namespace RosyModule.ScaleBarcode
{
	public partial class frmInherit_LenhCan : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInherit;
		BindingSource bdsInherit = new BindingSource();

		string strMa_Ct = string.Empty;
		DataRow drCurrent;
		DataRow drDmCt_Current;
		public bool Is_Accept = false;
		private bool bSa_Lan = false;
		#endregion

		#region Contructor

        public frmInherit_LenhCan()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			
			this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);
            //this.dgvInheritVoucher.CellContentClick += new DataGridViewCellEventHandler(dgvInheritVoucher_CellContentClick);
            //this.dgvInheritVoucher.CellClick += new DataGridViewCellEventHandler(dgvInheritVoucher_CellContentClick);
			
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
		}

		#endregion

		#region Method

		public void Load(bool bSa_Lan)
		{
			this.bSa_Lan = bSa_Lan;
			if (bSa_Lan)
			{
				chkInherit_TTCH.Visible = true;
				chkInherit_TTCH.Enabled = false;
				chkInherit_TTCH.Checked = true;
			}
			else
			{
				chkInherit_TTCH.Visible = false;
				chkInherit_TTCH.Checked = false;
			}
			dteNgay_Ct1.Text = Library.DateToStr(Voucher.GetDate_Server());
			dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server());
		
			Build();
			FillData("");
			BindingLanguage();

			this.ShowDialog();
		}

		void Build()
		{
			dgvInheritVoucher.strZone = "INHERIT_LENHCAN";
			dgvInheritVoucher.BuildGridView();
			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;

			if (dgvInheritVoucher.Columns.Contains("CHON"))
				dgvInheritVoucher.Columns["CHON"].ReadOnly = false;

            dgvInheritVoucher.Font = new Font("Arial", 14);
            dgvInheritVoucher.RowTemplate.Height = 32;
		}

		void FillData(string strStt)
		{
			
			Hashtable htPara = new Hashtable();
			
			htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
            htPara.Add("MA_DT", txtMa_Dt.Text);
			htPara.Add("IS_TTCH", chkInherit_TTCH.Checked);
			dtInherit = SQLExec.ExecuteReturnDt("sp_GetLCH", htPara, CommandType.StoredProcedure);

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

            if (dtInherit.Select("Chon = true").Length > 1)
            {
                Common.MsgCancel("Không Kế thừa 2 xe!");
                return false;
            }

			return true;
		}

		#endregion

		#region Event

		

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
			
			this.FillData("");
		}

		

		void frmInheritVoucher_KeyDown(object sender, KeyEventArgs e)
		{
            //if (e.Control && e.KeyCode == Keys.A)
            //{
            //    for (int i = 0; i < dtInherit.Rows.Count; i++)
            //    {
            //        dtInherit.Rows[i]["CHON"] = true;
            //    }
            //}
            //if (e.Control && e.KeyCode == Keys.U)
            //{

            //    for (int i = 0; i < dtInherit.Rows.Count; i++)
            //    {
            //        dtInherit.Rows[i]["CHON"] = false;
            //    }
            //}
		}

        //void dgvInheritVoucher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex < 0 || e.RowIndex < 0)
        //        return;

        //    string strColumn_Name = dgvInheritVoucher.Columns[e.ColumnIndex].DataPropertyName.ToUpper();

        //    if (strColumn_Name == "CHON")
        //        ((DataRowView)bdsInherit.Current).Row[strColumn_Name] = !Convert.ToBoolean(((DataRowView)bdsInherit.Current).Row[strColumn_Name]);
        //}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5)
				this.FillData("");
			else if (e.Control)
			{
                //if (e.KeyCode == Keys.A)
                //    foreach (DataRow dr in dtInherit.Rows)
                //        dr["Chon"] = true;
                //else if (e.KeyCode == Keys.U)
                //    foreach (DataRow dr in dtInherit.Rows)
                //    {
                //        dr["Chon"] = false;
                //    }
			}
			else
				base.OnKeyDown(e);
		}

		#endregion

	}
}
