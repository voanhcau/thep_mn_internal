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
	public partial class frmInherit_LXH : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInheritVoucher;
		BindingSource bdsInheritVoucher = new BindingSource();
		
		string strMa_Vt = string.Empty;		
		DataRow drCurrent, drDmCt_Current;
		
		public bool is_Accept = false;

		#endregion

		#region Contructor

        public frmInherit_LXH()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);

			
		}

		new public void Load(string strMa_Vt)
		{
            this.strMa_Vt = strMa_Vt;
            txtMa_Vt_Sp.Text = strMa_Vt;
            dteNgay_Ct1.Text = dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
			this.Build();

			this.FillData();
            this.LoadDicName();
			this.BindingLanguage();
			this.ShowDialog();
		}
        new public void Load()
        {
            dteNgay_Ct1.Text = dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            this.Build();

            this.FillData();
            this.LoadDicName();
            this.BindingLanguage();
            this.ShowDialog();
        }
		

		#endregion

		#region Method
        void LoadDicName()
        {
            if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
            {
                lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
            }
            else
                lbtTen_Vt_Sp.Text = string.Empty;
        }
		void Build()
		{
			dgvInheritVoucher.strZone = "INHERIT_LXH_BARCODELE";
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
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("SO_CT", txtSo_Ct.Text);
            ht.Add("MA_VT", txtMa_Vt_Sp.Text);
            ht.Add("IS_INHERIT", chkInheritedExcept.Checked);
            dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_GetInheritLXHBarcodeLe", ht, CommandType.StoredProcedure);

			bdsInheritVoucher.DataSource = dtInheritVoucher;
			dgvInheritVoucher.DataSource = bdsInheritVoucher;

			bdsSearch = bdsInheritVoucher;
			bdsLookup = bdsInheritVoucher;


			
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

			
		}
	}
}
