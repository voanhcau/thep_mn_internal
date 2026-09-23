using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem;

namespace RosyList
{
	public partial class frmDmStandard : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmStandard;
		DataRow drCurrent;
		BindingSource bdsDmStandard = new BindingSource();
		rsDataGridView dgvDmStandard = new rsDataGridView();

		#endregion 						

		#region Contructor

        public frmDmStandard()
		{
			InitializeComponent();

			this.dgvDmStandard.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmStandard_CellMouseDoubleClick);
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

		#region Build, FillData
		private void Build()
		{
			dgvDmStandard.Dock = DockStyle.Fill;
			dgvDmStandard.strZone = "DMSTANDARD";
			dgvDmStandard.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmStandard);
		}

		private void FillData()
		{
			dtDmStandard = DataTool.SQLGetDataTable("R81DMSTANDARD", null, this.strLookupKeyFilter, null);

			dgvDmStandard.DataSource = bdsDmStandard;
			bdsDmStandard.DataSource = dtDmStandard;
			bdsDmStandard.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmStandard;
			ExportControl = dgvDmStandard;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmStandard.Rows.Count - 1; i++)
				if (((string)dtDmStandard.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmStandard.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmStandard.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmStandard.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmStandard.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmStandard.NewRow();

			frmDmStandard_Edit frmEdit = new frmDmStandard_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmStandard.Position >= 0)
						dtDmStandard.ImportRow(drCurrent);
					else
						dtDmStandard.Rows.Add(drCurrent);

                    bdsDmStandard.Position = bdsDmStandard.Find("STANDARD_ID", drCurrent["STANDARD_ID"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmStandard.Current).Row);

				dtDmStandard.AcceptChanges();
			}
			else
				dtDmStandard.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmStandard.Position < 0)	
				return;

			DataRow drCurrent = ((DataRowView)bdsDmStandard.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMSTANDARD", drCurrent))
			{
				bdsDmStandard.RemoveAt(bdsDmStandard.Position);
				dtDmStandard.AcceptChanges();
			}
		}

		#endregion

		#region EnterProcess

		private bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmStandard == null || bdsDmStandard.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmStandard.Current).Row;
			DataTable dtTemp = dtDmStandard.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmStandard.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmStandard.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmStandard_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMSTANDARD", dtDmStandard);
		}

		#endregion 
	}
}