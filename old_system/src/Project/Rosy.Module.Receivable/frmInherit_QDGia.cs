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

namespace RosyModule.Receivable
{
	public partial class frmInherit_QDGia : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInheritVoucher;
		BindingSource bdsInheritVoucher = new BindingSource();

        DateTime dteNgay_Qd;
		DataRow drCurrent, drDmCt_Current;
		
		public bool is_Accept = false;

		#endregion

		#region Contructor

        public frmInherit_QDGia()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);
            this.txtSo_Qd.Validating += new CancelEventHandler(txtSo_Qd_Validating);
            
		}

        

       

		new public void Load(DateTime  dteNgay_Qd)
		{
            this.dteNgay_Qd = dteNgay_Qd;

          
            txtSo_Qd.bUseAutoDropDown = true;
            txtSo_Qd.strLookupKeyFilter = "Ngay_Het_Han >= '" + Library.DateToStr(dteNgay_Qd) + "'";

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
            
        }
		void Build()
		{
			dgvInheritVoucher.strZone = "INHERIT_QDGIA";
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
          
            ht.Add("SO_QD", txtSo_Qd.Text);
            ht.Add("NGAY_QD", dteNgay_Qd);
            dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_GetInheritDMQD", ht, CommandType.StoredProcedure);

			bdsInheritVoucher.DataSource = dtInheritVoucher;
			dgvInheritVoucher.DataSource = bdsInheritVoucher;

            //bdsSearch = bdsInheritVoucher;
            //bdsLookup = bdsInheritVoucher;


			
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

        void txtSo_Qd_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_Qd.Text.Trim();
            if (strValue == string.Empty)
                return;
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("So_Qd", strValue, bRequire, "Ngay_Het_Han >= '"+ Library.DateToStr(dteNgay_Qd) +"'", "");

            if (bRequire && drLookup == null)
                e.Cancel = false;

            if (drLookup == null)
            {
                txtSo_Qd.Text = string.Empty;
            }
            else
            {
                txtSo_Qd.Text = drLookup["So_QD"].ToString();

            }

        }
       
		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			
		}
	}
}
