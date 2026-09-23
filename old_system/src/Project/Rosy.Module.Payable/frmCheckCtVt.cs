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

namespace RosyModule.Payable
{
	public partial class frmCheckCtVt : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtCheckCtVt;
		BindingSource bdsCheckCtVt = new BindingSource();
		
		
		DataRow drCurrent, drDmCt_Current;
		public bool Is_Accept = false;

		#endregion

		#region Contructor

		public frmCheckCtVt()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			
			this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
			
		}

		

		#endregion

		#region Method

		public void Load()
		{
			dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

			Build();
            //FillData();
			BindingLanguage();
			
			this.Show();
		}

        public void Load(string strMa_Vt, DateTime dteNgay_Nhap)
        {
            dteNgay_Ct1.Text =  Library.DateToStr(dteNgay_Nhap);// Library.DateToStr(dteNgay_Nhap.Subtract(new TimeSpan(360, 0, 0, 0)));
            dteNgay_Ct2.Text =  Library.DateToStr(Element.sysNgay_Ct2);
            txtMa_Vt.Text = strMa_Vt;
            Build();
            FillData();
            LoadDicName();
            BindingLanguage();

            this.ShowDialog();
        }

		void Build()
		{
			dgvInheritVoucher.strZone = "CHITIETVATTU";

			dgvInheritVoucher.BuildGridView();

			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

			txtMa_Vt.bUseAutoDropDown = true;
            txtMa_Vt.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%' AND LEN(Ma_Vt) = 9";

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;
            if (dgvInheritVoucher.Columns.Contains("Ma_Vt_Tt"))
                   dgvInheritVoucher.Columns["Ma_Vt_Tt"].HeaderText = "Mã vật tư PYC";
		}

		void FillData()
		{			
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
			htPara.Add("MA_VT", txtMa_Vt.Text);

			 DataSet dsCheckCtVt = SQLExec.ExecuteReturnDs("sp_CheckCtVt", htPara, CommandType.StoredProcedure);
			
			dtCheckCtVt = dsCheckCtVt.Tables[0];
			bdsCheckCtVt.DataSource = dtCheckCtVt;
			dgvInheritVoucher.DataSource = bdsCheckCtVt;
			
			DataTable dtTon = dsCheckCtVt.Tables[1];
			DataRow drTon = dtTon.Rows[0];
			lbtNotice.Text = drTon["Ton"].ToString();

			bdsSearch = bdsCheckCtVt;
			bdsLookup = bdsCheckCtVt;		
		}
        void LoadDicName()
        {
            if (txtMa_Vt.Text != "")
            {
                DataRow drDmvt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", txtMa_Vt.Text);
                lbtTen_Vt.Text = drDmvt["Ten_Vt"].ToString();
            }
        }
		bool FormCheckValid()
		{
			return true;
		}

		#endregion

		#region Event
		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
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
			this.FillData();
		}

		

		void frmInheritVoucher_KeyDown(object sender, KeyEventArgs e)
		{
			
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5)
				this.FillData();
			else
				base.OnKeyDown(e);
		}

		#endregion

      
	}
}
