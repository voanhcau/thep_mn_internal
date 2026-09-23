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
	public partial class frmDmCtAuto : RosyList.frmView
	{		

		#region Khai bao bien
		DataTable dtDmBp;
		DataRow drCurrent;
		BindingSource bdsDmCtAuto = new BindingSource();
		rsDataGridView dgvDmCtAuto = new rsDataGridView();

		#endregion 				

		#region Contructor

		public frmDmCtAuto()
		{
			InitializeComponent();

			this.dgvDmCtAuto.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmCtAuto_CellMouseDoubleClick);
			btImport.Click += new EventHandler(btImport_Click);
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
			dgvDmCtAuto.strZone = "DMCTAUTO";
			dgvDmCtAuto.Dock = DockStyle.Fill;

			dgvDmCtAuto.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmCtAuto);
		}

		private void FillData()
		{
			dtDmBp = DataTool.SQLGetDataTable("R81DMCTAUTO", null, this.strLookupKeyFilter, null);
			bdsDmCtAuto.DataSource = dtDmBp;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmCtAuto;
			ExportControl = dgvDmCtAuto;

			dgvDmCtAuto.DataSource = bdsDmCtAuto;
			bdsDmCtAuto.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();

		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmBp.Rows.Count - 1; i++)
				if (((string)dtDmBp.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmCtAuto.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmCtAuto.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmCtAuto.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmCtAuto.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmBp.NewRow();

			frmDmCtAuto_Edit frmEdit = new frmDmCtAuto_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);			

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmCtAuto.Position >= 0)
						dtDmBp.ImportRow(drCurrent);
					else
						dtDmBp.Rows.Add(drCurrent);

					bdsDmCtAuto.Position = bdsDmCtAuto.Find("MA_CT", drCurrent["MA_CT"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmCtAuto.Current).Row);
				
				dtDmBp.AcceptChanges();
			}
		}
		
		public override void Delete()
		{
			if (bdsDmCtAuto.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmCtAuto.Current).Row;
				
			if( !Common.MsgYes_No( Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81DMCTAUTO", drCurrent))
			{
				bdsDmCtAuto.RemoveAt(bdsDmCtAuto.Position);
				dtDmBp.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			Common.MsgCancel("Không hổ trợ chức năng này");
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmCtAuto == null || bdsDmCtAuto.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmCtAuto.Current).Row;
			DataTable dtTemp = dtDmBp.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsDmCtAuto.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmCtAuto.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmCtAuto_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			Common.MsgCancel("Không hổ trợ chức năng này");
		}

		#endregion 
	}
}