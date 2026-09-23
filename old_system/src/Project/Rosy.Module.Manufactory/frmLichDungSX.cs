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


namespace RosyModule.Manufactory
{
	public partial class frmLichDungSX : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtLichDungSX;
		DataRow drCurrent;
		BindingSource bdsLichDungSX = new BindingSource();
		rsDataGridView dgvLichDungSX = new rsDataGridView();

		#endregion

		#region Contructor

        public frmLichDungSX()
		{
			InitializeComponent();

			this.dgvLichDungSX.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvLichDungSX_CellMouseDoubleClick);
            //this.btImport.Click +=new EventHandler(btImport_Click);
		}

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

            //if (this.isLookup)
            //    this.ShowDialog();
            //else
                this.ShowDialog();
		}

		public override void LoadLookup()
		{
			this.Load();
		}
		
		#endregion

		#region Build, FillData
		private void Build()
		{		
			dgvLichDungSX.Dock = DockStyle.Fill;
			dgvLichDungSX.strZone = "LICHDUNGSX";
			dgvLichDungSX.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvLichDungSX);
		}

		private void FillData()
		{
            //if (this.isLookup)
                //dtLichDungSX = DataTool.SQLGetDataTable("R13NANGSUATSP", null, this.strLookupKeyFilter, null);
            //else
            dtLichDungSX = DataTool.SQLGetDataTable("R13LICHDUNGSX", null, this.strLookupKeyFilter, null);
			bdsLichDungSX.DataSource = dtLichDungSX;
			dgvLichDungSX.DataSource = bdsLichDungSX;
			bdsLichDungSX.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsLichDungSX;
			ExportControl = dgvLichDungSX;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtLichDungSX.Rows.Count - 1; i++)
				if (((string)dtLichDungSX.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsLichDungSX.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsLichDungSX.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsLichDungSX.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsLichDungSX.Current).Row, ref drCurrent);
			else
				drCurrent = dtLichDungSX.NewRow();

            frmLichDungSX_Edit frmEdit = new frmLichDungSX_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsLichDungSX.Position >= 0)
						dtLichDungSX.ImportRow(drCurrent);
					else
						dtLichDungSX.Rows.Add(drCurrent);

					bdsLichDungSX.Position = bdsLichDungSX.Find("IDENT00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsLichDungSX.Current).Row);

				dtLichDungSX.AcceptChanges();
			}
			else
				dtLichDungSX.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsLichDungSX.Position < 0)
				return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsLichDungSX.Current).Row;

			
			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R13LICHDUNGSX", drCurrent))
			{
				bdsLichDungSX.RemoveAt(bdsLichDungSX.Position);
				dtLichDungSX.AcceptChanges();
			}
			
		}

      

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsLichDungSX == null || bdsLichDungSX.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsLichDungSX.Current).Row;
			DataTable dtTemp = dtLichDungSX.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsLichDungSX.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsLichDungSX.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvLichDungSX_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

        //void btImport_Click(object sender, EventArgs e)
        //{
        //    RosySystem.Public.Public.ImportExcel("DMKHO", dtLichDungSX);
        //}

		#endregion 
	}
}