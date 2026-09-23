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
	public partial class frmDmSize : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmSize;
		DataRow drCurrent;
		BindingSource bdsDmSize = new BindingSource();
		rsDataGridView dgvDmSize = new rsDataGridView();

		#endregion 						

		#region Contructor

		public frmDmSize()
		{
			InitializeComponent();

			this.dgvDmSize.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmSize_CellMouseDoubleClick);
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
			dgvDmSize.Dock = DockStyle.Fill;
			dgvDmSize.strZone = "DMSIZE";
			dgvDmSize.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmSize);
		}

		private void FillData()
		{
			dtDmSize = DataTool.SQLGetDataTable("R81DMSIZE", null, this.strLookupKeyFilter, null);

			dgvDmSize.DataSource = bdsDmSize;
			bdsDmSize.DataSource = dtDmSize;
			bdsDmSize.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmSize;
			ExportControl = dgvDmSize;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmSize.Rows.Count - 1; i++)
				if (((string)dtDmSize.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmSize.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmSize.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmSize.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmSize.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmSize.NewRow();

			frmDmSize_Edit frmEdit = new frmDmSize_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmSize.Position >= 0)
						dtDmSize.ImportRow(drCurrent);
					else
						dtDmSize.Rows.Add(drCurrent);

					bdsDmSize.Position = bdsDmSize.Find("MA_SIZE", drCurrent["MA_SIZE"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmSize.Current).Row);

				dtDmSize.AcceptChanges();
			}
			else
				dtDmSize.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmSize.Position < 0)	
				return;

			DataRow drCurrent = ((DataRowView)bdsDmSize.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81DMSIZE", drCurrent))
			{
				bdsDmSize.RemoveAt(bdsDmSize.Position);
				dtDmSize.AcceptChanges();
			}
		}

		#endregion

		#region EnterProcess

		private bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmSize == null || bdsDmSize.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmSize.Current).Row;
			DataTable dtTemp = dtDmSize.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmSize.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmSize.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmSize_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMSIZE", dtDmSize);
		}

		#endregion 
	}
}