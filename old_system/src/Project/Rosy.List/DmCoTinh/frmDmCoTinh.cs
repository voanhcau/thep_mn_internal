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
	public partial class frmDmCoTinh : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmCoTinh;
		DataRow drCurrent;
		BindingSource bdsDmCoTinh = new BindingSource();
		rsDataGridView dgvDmCoTinh = new rsDataGridView();

		#endregion

		#region Contructor

		public frmDmCoTinh()
		{
			InitializeComponent();

			this.dgvDmCoTinh.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmCoTinh_CellMouseDoubleClick);
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
			dgvDmCoTinh.Dock = DockStyle.Fill;
			dgvDmCoTinh.strZone = "DMCOTINH";
			dgvDmCoTinh.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmCoTinh);
		}

		private void FillData()
		{
			if (!this.isLookup)
				dtDmCoTinh = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Grade_Name FROM R81DMCOTINH T1 JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID", CommandType.Text);
			else
				dtDmCoTinh = DataTool.SQLGetDataTable("R81DMCOTINH", null, this.strLookupKeyFilter, null);

			bdsDmCoTinh.DataSource = dtDmCoTinh;
			dgvDmCoTinh.DataSource = bdsDmCoTinh;
			bdsDmCoTinh.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmCoTinh;
			ExportControl = dgvDmCoTinh;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmCoTinh.Rows.Count - 1; i++)
				if (((string)dtDmCoTinh.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmCoTinh.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmCoTinh.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmCoTinh.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmCoTinh.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmCoTinh.NewRow();

			frmDmCoTinh_Edit frmEdit = new frmDmCoTinh_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmCoTinh.Position >= 0)
						dtDmCoTinh.ImportRow(drCurrent);
					else
						dtDmCoTinh.Rows.Add(drCurrent);

					bdsDmCoTinh.Position = bdsDmCoTinh.Find("MA_CO_TINH", drCurrent["MA_CO_TINH"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmCoTinh.Current).Row);

				dtDmCoTinh.AcceptChanges();
			}
			else
				dtDmCoTinh.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmCoTinh.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmCoTinh.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMCOTINH", drCurrent))
			{
				bdsDmCoTinh.RemoveAt(bdsDmCoTinh.Position);
				dtDmCoTinh.AcceptChanges();
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

			if (bdsDmCoTinh == null || bdsDmCoTinh.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmCoTinh.Current).Row;
			DataTable dtTemp = dtDmCoTinh.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmCoTinh.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmCoTinh.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmCoTinh_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMCOTINH", dtDmCoTinh);
		}

		#endregion 
	}
}