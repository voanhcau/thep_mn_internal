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
	public partial class frmDmXe : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmXe;
		DataRow drCurrent;
		BindingSource bdsDmXe = new BindingSource();
		rsDataGridView dgvDmXe = new rsDataGridView();

		#endregion 						

		#region Contructor

		public frmDmXe()
		{
			InitializeComponent();

			this.dgvDmXe.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmXe_CellMouseDoubleClick);
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
			dgvDmXe.Dock = DockStyle.Fill;
			dgvDmXe.strZone = "DMXE";
			dgvDmXe.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmXe);
		}

		private void FillData()
		{
			dtDmXe = DataTool.SQLGetDataTable("R81DMXE", null, this.strLookupKeyFilter, "Ma_Xe");

			bdsDmXe.DataSource = dtDmXe;
			dgvDmXe.DataSource = bdsDmXe;
			bdsDmXe.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmXe;
			ExportControl = dgvDmXe;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmXe.Rows.Count - 1; i++)
				if (((string)dtDmXe.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmXe.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmXe.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmXe.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmXe.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmXe.NewRow();

			frmDmXe_Edit frmEdit = new frmDmXe_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmXe.Position >= 0)
						dtDmXe.ImportRow(drCurrent);
					else
						dtDmXe.Rows.Add(drCurrent);

					bdsDmXe.Position = bdsDmXe.Find("Ma_Xe", drCurrent["Ma_Xe"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmXe.Current).Row);

				dtDmXe.AcceptChanges();
			}
			else
				dtDmXe.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmXe.Position < 0)
				return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmXe.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81DMXE", drCurrent))
			{
				bdsDmXe.RemoveAt(bdsDmXe.Position);
				dtDmXe.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			//if (bdsDmXe.Count <= 0)
			//    return;

			//if (!Common.CheckPermission("MERGE_DMKV", enuPermission_Type.Allow_Access))
			//{
			//    string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Area code!" : "Bạn không đc cấp quyền Gộp Mã khu vực!";
			//    Common.MsgCancel(strMsg);
			//    return;
			//}

			//drCurrent = ((DataRowView)bdsDmXe.Current).Row;
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
			//        bdsDmXe.RemoveCurrent();
			//        bdsDmXe.Position = bdsDmXe.Find("Ma_Kv", strNewValue);
			//    }
			//}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmXe == null || bdsDmXe.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmXe.Current).Row;
			DataTable dtTemp = dtDmXe.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmXe.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmXe.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmXe_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			//RosySystem.Public.Public.ImportExcel("DMKV", dtDmXe);
		}

		#endregion 
	}
}