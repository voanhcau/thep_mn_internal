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
	public partial class frmTPHH : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtTPHH;
		DataRow drCurrent;
		BindingSource bdsTPHH = new BindingSource();
		rsDataGridView dgvTPHH = new rsDataGridView();

		#endregion

		#region Contructor

		public frmTPHH()
		{
			InitializeComponent();

			this.dgvTPHH.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvTPHH_CellMouseDoubleClick);
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
			dgvTPHH.Dock = DockStyle.Fill;
			dgvTPHH.strZone = "TPHH";
			dgvTPHH.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvTPHH);
		}

		private void FillData()
		{
			if (!this.isLookup)
				dtTPHH = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Grade_Name FROM R81DMTPHH T1 JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID", CommandType.Text);
			else
				dtTPHH = DataTool.SQLGetDataTable("R81TPHH", null, this.strLookupKeyFilter, null);

			bdsTPHH.DataSource = dtTPHH;
			dgvTPHH.DataSource = bdsTPHH;
			bdsTPHH.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsTPHH;
			ExportControl = dgvTPHH;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtTPHH.Rows.Count - 1; i++)
				if (((string)dtTPHH.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsTPHH.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsTPHH.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsTPHH.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsTPHH.Current).Row, ref drCurrent);
			else
				drCurrent = dtTPHH.NewRow();

			frmDmTPHH_Edit frmEdit = new frmDmTPHH_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsTPHH.Position >= 0)
						dtTPHH.ImportRow(drCurrent);
					else
						dtTPHH.Rows.Add(drCurrent);

					bdsTPHH.Position = bdsTPHH.Find("MA_TP_HH", drCurrent["MA_TP_HH"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsTPHH.Current).Row);

				dtTPHH.AcceptChanges();
			}
			else
				dtTPHH.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsTPHH.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsTPHH.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMTPHH", drCurrent))
			{
				bdsTPHH.RemoveAt(bdsTPHH.Position);
				dtTPHH.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsTPHH == null || bdsTPHH.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsTPHH.Current).Row;
			DataTable dtTemp = dtTPHH.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsTPHH.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsTPHH.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvTPHH_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("TPHH", dtTPHH);
		}

		#endregion 
	}
}