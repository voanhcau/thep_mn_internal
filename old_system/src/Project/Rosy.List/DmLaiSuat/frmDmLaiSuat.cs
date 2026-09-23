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
	public partial class frmDmLaiSuat : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmLaiSuat;
		DataRow drCurrent;
		BindingSource bdsDmLaiSuat = new BindingSource();
		rsDataGridView dgvDmLaiSuat = new rsDataGridView();

		#endregion

		#region Contructor

		public frmDmLaiSuat()
		{
			InitializeComponent();

			this.dgvDmLaiSuat.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmLaiSuat_CellMouseDoubleClick);
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
			dgvDmLaiSuat.Dock = DockStyle.Fill;
			dgvDmLaiSuat.strZone = "DMLAISUAT";
			dgvDmLaiSuat.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmLaiSuat);
		}

		private void FillData()
		{
			dtDmLaiSuat = DataTool.SQLGetDataTable("R81DMLAISUAT", null, this.strLookupKeyFilter, null);

			bdsDmLaiSuat.DataSource = dtDmLaiSuat;
			dgvDmLaiSuat.DataSource = bdsDmLaiSuat;
			bdsDmLaiSuat.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmLaiSuat;
			ExportControl = dgvDmLaiSuat;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmLaiSuat.Rows.Count - 1; i++)
				if (((string)dtDmLaiSuat.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmLaiSuat.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmLaiSuat.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmLaiSuat.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmLaiSuat.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmLaiSuat.NewRow();

			frmDmLaiSuat_Edit frmEdit = new frmDmLaiSuat_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmLaiSuat.Position >= 0)
						dtDmLaiSuat.ImportRow(drCurrent);
					else
						dtDmLaiSuat.Rows.Add(drCurrent);

					bdsDmLaiSuat.Position = bdsDmLaiSuat.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmLaiSuat.Current).Row);

				dtDmLaiSuat.AcceptChanges();
			}
			else
				dtDmLaiSuat.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmLaiSuat.Position < 0)
				return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmLaiSuat.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81DMLAISUAT", drCurrent))
			{
				bdsDmLaiSuat.RemoveAt(bdsDmLaiSuat.Position);
				dtDmLaiSuat.AcceptChanges();
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmLaiSuat == null || bdsDmLaiSuat.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmLaiSuat.Current).Row;
			DataTable dtTemp = dtDmLaiSuat.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmLaiSuat.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmLaiSuat.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmLaiSuat_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			//RosySystem.Public.Public.ImportExcel("DMKHO", dtDmLaiSuat);
		}

		#endregion 
	}
}