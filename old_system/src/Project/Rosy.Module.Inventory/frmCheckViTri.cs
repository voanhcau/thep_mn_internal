using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Customize;
using RosySystem.Public;
using RosyList;
using RosySystem;

namespace RosyModule.Inventory
{
	public partial class frmCheckViTri : RosySystem.Customize.frmView
	{
		public frmVoucher_Edit frmEdit;

		public toolStripView tsView = new toolStripView();

		DataTable dtCheckInventory0;
		DataTable dtCheckInventory;
	
		BindingSource bdsCheckInventory = new BindingSource();
		DataRow drCurrent;
		
		
		
		public frmCheckViTri()
		{
			InitializeComponent();
						
			dgvCheckInventory.KeyDown += new KeyEventHandler(dgvCheckInventory_KeyDown);
			//dgvCheckInventory.CellDoubleClick += new DataGridViewCellEventHandler(dgvCheckInventory_CellDoubleClick);
			dgvCheckInventory.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvCheckInventory_CellMouseClick);
			this.KeyDown += new KeyEventHandler(frmCheckInventory_KeyDown);
		}

		

		new public void Load(DataRow drEdit)
		{
			
			this.LoadToolStrip();
			this.Build();
			this.FillData(drEdit);

			this.BindingLanguage();
			
			this.ShowDialog();
			
		}

		public void LoadToolStrip()
		{
			this.splitContainer1.Panel1Collapsed = false;
			this.splitContainer1.Panel1.Controls.Add(tsView);
		}

		public void Build()
		{
			dgvCheckInventory.strZone = "CHECKVITRIKHO";
			dgvCheckInventory.BuildGridView();

			bdsSearch = bdsCheckInventory;
			ExportControl = dgvCheckInventory;
		}

		public void FillData(DataRow drEdit)
		{

			Hashtable htPara = new Hashtable();
			htPara.Add("MA_CT", drEdit["Ma_Ct"]);
			htPara.Add("NGAY_CT", drEdit["Ngay_Ct"]);
			htPara.Add("MA_VT", drEdit["Ma_Vt"]);
			htPara.Add("MA_KHO", drEdit["Ma_Kho"]);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtCheckInventory0 = SQLExec.ExecuteReturnDt("Sp_CheckXuatVTriKho", htPara, CommandType.StoredProcedure);

			if (dtCheckInventory0 == null)
				return;

			dtCheckInventory = dtCheckInventory0.Copy();
			
			bdsCheckInventory.DataSource = dtCheckInventory;
			dgvCheckInventory.DataSource = bdsCheckInventory;

			dgvCheckInventory.ResizeGridView();

			bdsSearch = bdsCheckInventory;
			ExportControl = dgvCheckInventory;
		}

		void dgvCheckInventory_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			drLookup = ((DataRowView)bdsCheckInventory.Current).Row;
			this.Close();
		}

		void dgvCheckInventory_KeyDown(object sender, KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}

		void frmCheckInventory_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F9)
				frmEdit.Focus();
		}

		

		protected override bool ShowWithoutActivation
		{
			get
			{
				return true;
			}
		}
	}
}
