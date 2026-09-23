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
	public partial class frmDmBarems : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmBarems;
		DataRow drCurrent;
		BindingSource bdsDmBarems = new BindingSource();
		rsDataGridView dgvDmBarems = new rsDataGridView();

		#endregion 						

		#region Contructor

        public frmDmBarems()
		{
			InitializeComponent();

			this.dgvDmBarems.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmBarems_CellMouseDoubleClick);
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
			dgvDmBarems.Dock = DockStyle.Fill;
			dgvDmBarems.strZone = "DMBAREMS";
			dgvDmBarems.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmBarems);
		}

		private void FillData()
		{
			if (this.strLookupKeyFilter == string.Empty)
			{
				string strSQLExec = "SELECT T1.*, T2.Ten_Size, T3.Grade_Name FROM R81DMBAREMS T1 LEFT JOIN R81DMSIZE T2 ON T1.Ma_Size = T2.Ma_Size LEFT JOIN R81DMMACTHEP T3 ON T1.Grade_ID = T3.Grade_ID";
				dtDmBarems = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
			}
			else
				dtDmBarems = DataTool.SQLGetDataTable("R81DMBAREMS", null, this.strLookupKeyFilter, null);

			dgvDmBarems.DataSource = bdsDmBarems;
			bdsDmBarems.DataSource = dtDmBarems;
			bdsDmBarems.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmBarems;
			ExportControl = dgvDmBarems;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmBarems.Rows.Count - 1; i++)
				if (((string)dtDmBarems.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmBarems.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmBarems.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmBarems.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmBarems.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmBarems.NewRow();

			frmDmBarems_Edit frmEdit = new frmDmBarems_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmBarems.Position >= 0)
						dtDmBarems.ImportRow(drCurrent);
					else
						dtDmBarems.Rows.Add(drCurrent);

					bdsDmBarems.Position = bdsDmBarems.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmBarems.Current).Row);

				dtDmBarems.AcceptChanges();
			}
			else
				dtDmBarems.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmBarems.Position < 0)	
				return;

			DataRow drCurrent = ((DataRowView)bdsDmBarems.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMBAREMS", drCurrent))
			{
				bdsDmBarems.RemoveAt(bdsDmBarems.Position);
				dtDmBarems.AcceptChanges();
			}
		}

		#endregion

		#region EnterProcess

		private bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmBarems == null || bdsDmBarems.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmBarems.Current).Row;
			DataTable dtTemp = dtDmBarems.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmBarems.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmBarems.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmBarems_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMBAREMS", dtDmBarems);
		}

		#endregion 
	}
}