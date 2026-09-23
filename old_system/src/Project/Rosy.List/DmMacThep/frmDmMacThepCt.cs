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
	public partial class frmDmMacThepCt : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmMacThep;
		DataRow drCurrent;
		BindingSource bdsDmMacThep = new BindingSource();
		rsDataGridView dgvDmMacThep = new rsDataGridView();
        string strMac_Thep;
		#endregion 						

		#region Contructor

        public frmDmMacThepCt()
		{
			InitializeComponent();

			this.dgvDmMacThep.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmMacThep_CellMouseDoubleClick);
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
        public void Load(string strMac_Thep)
        {
            this.strMac_Thep = strMac_Thep;
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
			dgvDmMacThep.Dock = DockStyle.Fill;
			dgvDmMacThep.strZone = "DMMACTHEPCT";
			dgvDmMacThep.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmMacThep);
		}

		private void FillData()
		{
            if (strMac_Thep != string.Empty && strMac_Thep != null)
            {
                string strSQLExec = "SELECT T1.*, T2.Standard_Name, T3.Grade_Name FROM R81DMMACTHEPCT T1 LEFT JOIN R81DMSTANDARD T2 ON T1.Standard_ID = T2.Standard_ID JOIN R81DMMACTHEP T3 ON T1.Grade_ID = T3.Grade_ID WHERE T1.Grade_ID = '" + strMac_Thep + "'";
                dtDmMacThep = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
            }
            else
            {
                string strSQLExec = "SELECT T1.*, T2.Standard_Name, T3.Grade_Name FROM R81DMMACTHEPCT T1 LEFT JOIN R81DMSTANDARD T2 ON T1.Standard_ID = T2.Standard_ID JOIN R81DMMACTHEP T3 ON T1.Grade_ID = T3.Grade_ID";
                dtDmMacThep = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
            }
                //dtDmMacThep = DataTool.SQLGetDataTable("R81DMMACTHEPCT", null, this.strLookupKeyFilter, null);

			dgvDmMacThep.DataSource = bdsDmMacThep;
			bdsDmMacThep.DataSource = dtDmMacThep;
			bdsDmMacThep.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmMacThep;
			ExportControl = dgvDmMacThep;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmMacThep.Rows.Count - 1; i++)
				if (((string)dtDmMacThep.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmMacThep.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmMacThep.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmMacThep.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmMacThep.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmMacThep.NewRow();

			frmDmMacThepCt_Edit frmEdit = new frmDmMacThepCt_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmMacThep.Position >= 0)
						dtDmMacThep.ImportRow(drCurrent);
					else
						dtDmMacThep.Rows.Add(drCurrent);

                    bdsDmMacThep.Position = bdsDmMacThep.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmMacThep.Current).Row);

				dtDmMacThep.AcceptChanges();
			}
			else
				dtDmMacThep.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmMacThep.Position < 0)	
				return;

			DataRow drCurrent = ((DataRowView)bdsDmMacThep.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMMACTHEPCT", drCurrent))
			{
				bdsDmMacThep.RemoveAt(bdsDmMacThep.Position);
				dtDmMacThep.AcceptChanges();
			}
		}

		#endregion

		#region EnterProcess

		private bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmMacThep == null || bdsDmMacThep.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmMacThep.Current).Row;
			DataTable dtTemp = dtDmMacThep.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmMacThep.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmMacThep.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmMacThep_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DmMacThep", dtDmMacThep);
		}

		#endregion 
	}
}