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
	public partial class frmDmBanVe : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmKv;
		DataRow drCurrent;
		BindingSource bdsDmKv = new BindingSource();
		rsDataGridView dgvDmKv = new rsDataGridView();

		#endregion 						

		#region Contructor

		public frmDmBanVe()
		{
			InitializeComponent();

			this.dgvDmKv.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmKv_CellMouseDoubleClick);
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

		#region Build
		private void Build()
		{
			dgvDmKv.Dock = DockStyle.Fill;
			dgvDmKv.strZone = "DMCUMTB";
			dgvDmKv.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmKv);
		}

		private void FillData()
		{
			dtDmKv = DataTool.SQLGetDataTable("R81DMCUMTB", null, this.strLookupKeyFilter, null);

			bdsDmKv.DataSource = dtDmKv;
			dgvDmKv.DataSource = bdsDmKv;
			bdsDmKv.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmKv;
			ExportControl = dgvDmKv;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmKv.Rows.Count - 1; i++)
				if (((string)dtDmKv.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmKv.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmKv.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmKv.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmKv.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmKv.NewRow();

			frmDmCumTb_Edit frmEdit = new frmDmCumTb_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmKv.Position >= 0)
						dtDmKv.ImportRow(drCurrent);
					else
						dtDmKv.Rows.Add(drCurrent);

					bdsDmKv.Position = bdsDmKv.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmKv.Current).Row);

				dtDmKv.AcceptChanges();
			}
			else
				dtDmKv.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmKv.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmKv.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81DMCUMTB", drCurrent))
			{
				bdsDmKv.RemoveAt(bdsDmKv.Position);
				dtDmKv.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			//if (bdsDmKv.Count <= 0)
			//    return;

			//if (!Common.CheckPermission("MERGE_DMKV", enuPermission_Type.Allow_Access))
			//{
			//    string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Area code!" : "Bạn không đc cấp quyền Gộp Mã khu vực!";
			//    Common.MsgCancel(strMsg);
			//    return;
			//}

			//drCurrent = ((DataRowView)bdsDmKv.Current).Row;
			//string strOldValue = (string)drCurrent["Ma_Kv"];

			//frmMergeID frm = new frmMergeID();

			//frm.Load("R81DMKV", "Ma_Kv", "Ten_Kv", strOldValue, "DMKV");

			//if (frm.isAccept)
			//{
			//    string strNewValue = frm.strNewValue;
			//    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
			//    if (!Common.MsgYes_No(strMsg))
			//        return;

			//    if (DataTool.SQLMergeID("Ma_Kv", "R81DMKV", strOldValue, strNewValue))
			//    {
			//        bdsDmKv.RemoveCurrent();
			//        bdsDmKv.Position = bdsDmKv.Find("Ma_Kv", strNewValue);
			//    }
			//}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmKv == null || bdsDmKv.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmKv.Current).Row;
			DataTable dtTemp = dtDmKv.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmKv.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmKv.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmKv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			//RosySystem.Public.Public.ImportExcel("DMKV", dtDmKv);
		}

		#endregion 
	}
}