using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem;
using RosySystem.Element;

namespace RosyList
{
	public partial class frmDmSoHDDT : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmLots;
		DataRow drCurrent;
		BindingSource bdsDmLots = new BindingSource();
		rsDataGridView dgvDmLots = new rsDataGridView();

		#endregion 						

		#region Contructor

        public frmDmSoHDDT()
		{
			InitializeComponent();

			this.dgvDmLots.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmKv_CellMouseDoubleClick);
			this.btImport.Click +=new EventHandler(btImport_Click);
		}

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public override void LoadLookup()
		{
			this.Load();
		}
		
		#endregion

		#region Build
		private void Build()
		{
			dgvDmLots.Dock = DockStyle.Fill;
            dgvDmLots.strZone = "SOHDNGAY";
			dgvDmLots.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmLots);
		}

		private void FillData()
		{
            dtDmLots = DataTool.SQLGetDataTable("R81DMSOHD", null, this.strLookupKeyFilter, null);

			bdsDmLots.DataSource = dtDmLots;
			dgvDmLots.DataSource = bdsDmLots;
			bdsDmLots.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmLots;
			ExportControl = dgvDmLots;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmLots.Rows.Count - 1; i++)
				if (((string)dtDmLots.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmLots.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmLots.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmLots.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmLots.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmLots.NewRow();

            frmDmSoHDDT_Edit frmEdit = new frmDmSoHDDT_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmLots.Position >= 0)
						dtDmLots.ImportRow(drCurrent);
					else
						dtDmLots.Rows.Add(drCurrent);

                    bdsDmLots.Position = bdsDmLots.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmLots.Current).Row);

				dtDmLots.AcceptChanges();
			}
			else
				dtDmLots.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmLots.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmLots.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R81DMSOHD", drCurrent))
			{
				bdsDmLots.RemoveAt(bdsDmLots.Position);
				dtDmLots.AcceptChanges();
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmLots == null || bdsDmLots.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmLots.Current).Row;
			DataTable dtTemp = dtDmLots.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmLots.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmLots.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmKv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMLOTS", dtDmLots);
		}

		#endregion 
	}
}