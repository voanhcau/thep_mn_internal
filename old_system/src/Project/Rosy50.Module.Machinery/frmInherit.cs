using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;

namespace RosyModule.Machinery
{
	public partial class frmInherit : RosySystem.Customize.frmView
	{
		#region variable

		public DataTable dtKHBTSC;
		BindingSource bdsKHBTSC = new BindingSource();
		DataRow drCurrent;
		public bool Is_Accept = false;

		#endregion

		#region contructor

		public frmInherit()
		{
			InitializeComponent();
			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			dgvKHBTSC.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvKHBTSC_CellMouseClick);

		}

		void dgvKHBTSC_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			string strColumnName = dgvKHBTSC.CurrentCell.OwningColumn.Name.ToUpper();
			drCurrent = ((DataRowView)bdsKHBTSC.Current).Row;

			if (strColumnName == "CHON")
			{
				//drCurrent["CHON"] = !(bool)drCurrent["CHON"];
				
			}
			//dtKHBTSC.AcceptChanges();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

		private bool FormCheckValid()
		{
			return true;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			dtKHBTSC.AcceptChanges();
			if (FormCheckValid())
			{
				this.Is_Accept = true;
				this.Close();
			}
		}

		public void Load()
		{
			this.Build();
			this.Filldata();

			this.ShowDialog();
		}

		private void Build()
		{
			//dgvKHBTSC.Dock = DockStyle.Fill;
			dgvKHBTSC.strZone = "INHERIT_KHBTSC";
			dgvKHBTSC.BuildGridView(this.isLookup);

			dgvKHBTSC.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvKHBTSC.Columns)
				dgvc.ReadOnly = true;

			if (dgvKHBTSC.Columns.Contains("CHON"))
				dgvKHBTSC.Columns["CHON"].ReadOnly = false;
		}

		private void Filldata()
		{
			Hashtable ht = new Hashtable();
			ht.Add("NGAY_CT", DateTime.Now);
			ht.Add("LOAI_KE_HOACH", "Kiểm tra, Sửa chữa");
			ht.Add("MA_DVCS", Element.sysMa_DvCs);

			dtKHBTSC = SQLExec.ExecuteReturnDt("sp_GetKHBTSC", ht, CommandType.StoredProcedure);

			bdsKHBTSC.DataSource = dtKHBTSC;
			dgvKHBTSC.DataSource = bdsKHBTSC;

			this.bdsSearch = bdsKHBTSC;
			this.ExportControl = dgvKHBTSC;
		}

		#endregion

		#region event
		#endregion

		#region Method

		#endregion
	}
}
