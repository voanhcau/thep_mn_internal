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
	public partial class frmDmNgayLe : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmNgayLe;
		DataRow drCurrent;
		BindingSource bdsDmNgayLe = new BindingSource();
		rsDataGridView dgvDmNgayLe = new rsDataGridView();

		#endregion

		#region Contructor

        public frmDmNgayLe()
		{
			InitializeComponent(); 

			this.dgvDmNgayLe.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmNgayLe_CellMouseDoubleClick);
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
			dgvDmNgayLe.Dock = DockStyle.Fill;
			dgvDmNgayLe.strZone = "DMNGAYLE";
			dgvDmNgayLe.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmNgayLe);
		}

		private void FillData()
		{
			dtDmNgayLe = DataTool.SQLGetDataTable("R81DMNGAYLE", null, null, null);

			bdsDmNgayLe.DataSource = dtDmNgayLe;
			dgvDmNgayLe.DataSource = bdsDmNgayLe;
			bdsDmNgayLe.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmNgayLe;
			ExportControl = dgvDmNgayLe;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmNgayLe.Rows.Count - 1; i++)
				if (((string)dtDmNgayLe.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmNgayLe.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmNgayLe.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Edit"));
				return;
			}
			//Copy hang hien tai            
			if (bdsDmNgayLe.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmNgayLe.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmNgayLe.NewRow();

            frmDmNgayLe_Edit frmEdit = new frmDmNgayLe_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmNgayLe.Position >= 0)
						dtDmNgayLe.ImportRow(drCurrent);
					else
						dtDmNgayLe.Rows.Add(drCurrent);

                    bdsDmNgayLe.Position = bdsDmNgayLe.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmNgayLe.Current).Row);

				dtDmNgayLe.AcceptChanges();
			}
			else
				dtDmNgayLe.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmNgayLe.Position < 0)
				return;
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmNgayLe.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMNGAYLE", drCurrent))
			{
				bdsDmNgayLe.RemoveAt(bdsDmNgayLe.Position);
				dtDmNgayLe.AcceptChanges();
			}
		}

      

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmNgayLe == null || bdsDmNgayLe.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmNgayLe.Current).Row;
			DataTable dtTemp = dtDmNgayLe.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmNgayLe.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmNgayLe.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmNgayLe_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMNGAYLE", dtDmNgayLe);
		}

		#endregion 
	}
}