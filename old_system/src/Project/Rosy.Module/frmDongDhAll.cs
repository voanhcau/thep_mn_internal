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
	public partial class frmDongDhAll : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtDongDh;
		public BindingSource bdsDongDh = new BindingSource();
        string strMa_Ct;
		public bool Is_Accept = false;

		#endregion

		#region Contructor

        public frmDongDhAll()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
            txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);
		}		

		#endregion

		#region Method

        public void Load(string strMa_Ct)
		{
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            this.strMa_Ct = strMa_Ct;
	
			Build();
			FillData();
			BindingLanguage();
            
			this.ShowDialog();
		}
		

		void Build()
		{

            dgvInheritVoucher.strZone = "SO_VIEW_DUYET";
			dgvInheritVoucher.BuildGridView();

			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;

            if (dgvInheritVoucher.Columns.Contains("DUYET_HUY"))
                dgvInheritVoucher.Columns["DUYET_HUY"].ReadOnly = false;
            if (dgvInheritVoucher.Columns.Contains("GHI_CHU_HUY"))
                dgvInheritVoucher.Columns["GHI_CHU_HUY"].ReadOnly = false;

            if (dgvInheritVoucher.Columns.Contains("DUYET_HUY"))
                dgvInheritVoucher.Columns["DUYET_HUY"].HeaderText = "Đóng ĐH";
            if (dgvInheritVoucher.Columns.Contains("GHI_CHU_HUY"))
                dgvInheritVoucher.Columns["GHI_CHU_HUY"].HeaderText = "Lý do đóng ĐH";
		}

		void FillData()
		{
			    Hashtable htPara = new Hashtable();

			    
			    htPara.Add("MA_CT", strMa_Ct);
			    htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			    htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
                htPara.Add("MA_KHO", txtMa_Kho.Text);
                htPara.Add("GHI_CHU_HUY", txtGhi_Chu_Huy.Text);
			    htPara.Add("IS_XE", rdbXe.Checked);
                htPara.Add("IS_TAU", rdbTau.Checked);
                htPara.Add("IS_ALL", rdbAll.Checked);
                htPara.Add("IS_NOTGK", chkIs_NotGK.Checked);
			    htPara.Add("MA_DVCS", Element.sysMa_DvCs);

				//DataTable dtDongDh = new DataTable();

                dtDongDh = SQLExec.ExecuteReturnDt("sp_DongDh", htPara, CommandType.StoredProcedure);

			    bdsDongDh.DataSource = dtDongDh;
			    dgvInheritVoucher.DataSource = bdsDongDh;

			    bdsSearch = bdsDongDh;
			    bdsLookup = bdsDongDh;
			
		}

		bool FormCheckValid()
		{
			if (dtDongDh == null || dtDongDh.Select("Duyet_Huy = true").Length == 0)
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
			this.FillData();
		}

        void txtMa_Kho_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Kho.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, string.Empty);
            if (drLookup == null && bRequire)
                e.Cancel = true;

            if (drLookup == null)
                txtMa_Kho.Text = string.Empty;
            else
                txtMa_Kho.Text = (string)drLookup["Ma_Kho"];
        }

		void frmInheritVoucher_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{

				for (int i = 0; i < dtDongDh.Rows.Count; i++)
				{
					dtDongDh.Rows[i]["DUYET_HUY"] = true;
				}
			}
			if (e.Control && e.KeyCode == Keys.U)
			{

				for (int i = 0; i < dtDongDh.Rows.Count; i++)
				{
                    dtDongDh.Rows[i]["DUYET_HUY"] = false;
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
					foreach (DataRow dr in dtDongDh.Rows)
                        dr["DUYET_HUY"] = true;
				else if (e.KeyCode == Keys.U)
					foreach (DataRow dr in dtDongDh.Rows)
                        dr["DUYET_HUY"] = false;
			}
			else
				base.OnKeyDown(e);
		}

		#endregion

       
	}
}
