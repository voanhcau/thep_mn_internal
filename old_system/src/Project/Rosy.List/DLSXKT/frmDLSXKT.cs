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
	public partial class frmDLSXKT : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmCl;
		DataRow drCurrent;
		BindingSource bdsDmCl = new BindingSource();
		rsDataGridView dgvDmCl = new rsDataGridView();

		#endregion

		#region Contructor

        public frmDLSXKT()
		{
			InitializeComponent();

			this.dgvDmCl.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmCl_CellMouseDoubleClick);
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
			dgvDmCl.Dock = DockStyle.Fill;
			dgvDmCl.strZone = "DLSXKT";
			dgvDmCl.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmCl);
		}

		private void FillData()
		{
            //dtDmCl = DataTool.SQLGetDataTable("R11DLSXPKT", null, this.strLookupKeyFilter, null);
            dtDmCl = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Type_Name AS Ten FROM R11DLSXPKT T1 JOIN R81DMTYPE T2 ON T1.Ma_So = T2.Type_ID AND T2.TYPE = 'DLSXKT'");
			bdsDmCl.DataSource = dtDmCl;
			dgvDmCl.DataSource = bdsDmCl;
			bdsDmCl.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmCl;
			ExportControl = dgvDmCl;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmCl.Rows.Count - 1; i++)
				if (((string)dtDmCl.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmCl.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmCl.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmCl.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmCl.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmCl.NewRow();

            frmDLSXKT_Edit frmEdit = new frmDLSXKT_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmCl.Position >= 0)
						dtDmCl.ImportRow(drCurrent);
					else
						dtDmCl.Rows.Add(drCurrent);

                    bdsDmCl.Position = bdsDmCl.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmCl.Current).Row);
                drCurrent["Ten"] = DataTool.SQLGetNameByCode("r81dmtype","Type_ID","Type_Name",drCurrent["Ma_So"].ToString());
				dtDmCl.AcceptChanges();
			}
			else
				dtDmCl.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmCl.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmCl.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R11DLSXPKT", drCurrent))
			{
				bdsDmCl.RemoveAt(bdsDmCl.Position);
				dtDmCl.AcceptChanges();
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmCl == null || bdsDmCl.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmCl.Current).Row;
			DataTable dtTemp = dtDmCl.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmCl.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmCl.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmCl_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

        void btImport_Click(object sender, EventArgs e)
        {
            //RosySystem.Public.Public.ImportExcel("DMCL", dtDmCl);
        }

		#endregion 
	}
}