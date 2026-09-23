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
	public partial class frmDmNL : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmNL;
		DataRow drCurrent;
		BindingSource bdsDmNL = new BindingSource();
		rsDataGridView dgvDmNL = new rsDataGridView();

		#endregion

		#region Contructor

		public frmDmNL()
		{
			InitializeComponent();

			this.dgvDmNL.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmNL_CellMouseDoubleClick);
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
			dgvDmNL.Dock = DockStyle.Fill;
			dgvDmNL.strZone = "DMNL";
			dgvDmNL.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmNL);
		}

		private void FillData()
		{
			dtDmNL = DataTool.SQLGetDataTable("R81DMDINHMUCNL", null, this.strLookupKeyFilter, "Ma_Nh_Vt");

			bdsDmNL.DataSource = dtDmNL;
			dgvDmNL.DataSource = bdsDmNL;
			bdsDmNL.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmNL;
			ExportControl = dgvDmNL;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmNL.Rows.Count - 1; i++)
				if (((string)dtDmNL.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmNL.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmNL.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmNL.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmNL.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmNL.NewRow();

			frmDmNL_Edit frmEdit = new frmDmNL_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmNL.Position >= 0)
						dtDmNL.ImportRow(drCurrent);
					else
						dtDmNL.Rows.Add(drCurrent);

					bdsDmNL.Position = bdsDmNL.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmNL.Current).Row);

				dtDmNL.AcceptChanges();
			}
			else
				dtDmNL.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmNL.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmNL.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMDINHMUCNL", drCurrent))
			{
				bdsDmNL.RemoveAt(bdsDmNL.Position);
				dtDmNL.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			//if (bdsDmNL.Count <= 0)
			//    return;

			//if (!Common.CheckPermission("MERGE_DMKHO", enuPermission_Type.Allow_Access))
			//{
			//    string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Warehouse code!" : "Bạn không đc cấp quyền Gộp Mã kho!";
			//    Common.MsgCancel(strMsg);
			//    return;
			//}

			//drCurrent = ((DataRowView)bdsDmNL.Current).Row;
			//string strOldValue = (string)drCurrent["Ma_Kho"];

			//frmMergeID frm = new frmMergeID();

			//frm.Load("R81DMDINHMUCNL", "Ma_Kho", "Ten_Kho", strOldValue, "DMKHO");

			//if (frm.isAccept)
			//{
			//    string strNewValue = frm.strNewValue;
			//    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
			//    if (!Common.MsgYes_No(strMsg))
			//        return;

			//    if (DataTool.SQLMergeID("Ma_Kho", "R81DMDINHMUCNL", strOldValue, strNewValue))
			//    {
			//        bdsDmNL.RemoveCurrent();
			//        bdsDmNL.Position = bdsDmNL.Find("Ma_Kho", strNewValue);
			//    }
			//}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmNL == null || bdsDmNL.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmNL.Current).Row;
			DataTable dtTemp = dtDmNL.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmNL.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmNL.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmNL_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMKHO", dtDmNL);
		}

		#endregion 
	}
}