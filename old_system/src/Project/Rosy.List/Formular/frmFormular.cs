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
	public partial class frmFormular : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtFormular;
		DataRow drCurrent;
		BindingSource bdsFormular = new BindingSource();
		rsDataGridView dgvFormular = new rsDataGridView();

		#endregion 						

		#region Contructor

		public frmFormular()
		{
			InitializeComponent();

			this.dgvFormular.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvFormular_CellMouseDoubleClick);
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
			dgvFormular.Dock = DockStyle.Fill;
			dgvFormular.strZone = "FORMULAR_SCALE";
			dgvFormular.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvFormular);
		}

		private void FillData()
		{
            dtFormular = DataTool.SQLGetDataTable("R81FORMULAR_SCALE", null, this.strLookupKeyFilter, null);

			dgvFormular.DataSource = bdsFormular;
			bdsFormular.DataSource = dtFormular;
			bdsFormular.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsFormular;
			ExportControl = dgvFormular;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtFormular.Rows.Count - 1; i++)
				if (((string)dtFormular.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsFormular.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsFormular.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsFormular.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsFormular.Current).Row, ref drCurrent);
			else
				drCurrent = dtFormular.NewRow();

			frmFormular_Edit frmEdit = new frmFormular_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsFormular.Position >= 0)
						dtFormular.ImportRow(drCurrent);
					else
						dtFormular.Rows.Add(drCurrent);

					bdsFormular.Position = bdsFormular.Find("FORMULAR_ID", drCurrent["FORMULAR_ID"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsFormular.Current).Row);

				dtFormular.AcceptChanges();
			}
			else
				dtFormular.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsFormular.Position < 0)	
				return;

			DataRow drCurrent = ((DataRowView)bdsFormular.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81FORMULAR_SCALE", drCurrent))
			{
				bdsFormular.RemoveAt(bdsFormular.Position);
				dtFormular.AcceptChanges();
			}
		}

		#endregion

		#region EnterProcess

		private bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsFormular == null || bdsFormular.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsFormular.Current).Row;
			DataTable dtTemp = dtFormular.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsFormular.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsFormular.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvFormular_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DmMacThep", dtFormular);
		}

		#endregion 
	}
}