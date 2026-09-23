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
	public partial class frmDmCk : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmCk;
		DataRow drCurrent;
		BindingSource bdsDmCk = new BindingSource();
		rsDataGridView dgvDmCk = new rsDataGridView();

		#endregion

		#region Contructor

		public frmDmCk()
		{
			InitializeComponent(); 

			this.dgvDmCk.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmCk_CellMouseDoubleClick);
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
			dgvDmCk.Dock = DockStyle.Fill;
			dgvDmCk.strZone = "DMCK";
			dgvDmCk.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmCk);
		}

		private void FillData()
		{
			dtDmCk = DataTool.SQLGetDataTable("R81DMCK", null, null, null);

			bdsDmCk.DataSource = dtDmCk;
			dgvDmCk.DataSource = bdsDmCk;
			bdsDmCk.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmCk;
			ExportControl = dgvDmCk;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmCk.Rows.Count - 1; i++)
				if (((string)dtDmCk.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmCk.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmCk.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Edit"));
				return;
			}
			//Copy hang hien tai            
			if (bdsDmCk.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmCk.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmCk.NewRow();

			frmDmCk_Edit frmEdit = new frmDmCk_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmCk.Position >= 0)
						dtDmCk.ImportRow(drCurrent);
					else
						dtDmCk.Rows.Add(drCurrent);

					bdsDmCk.Position = bdsDmCk.Find("MA_KHO", drCurrent["MA_KHO"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmCk.Current).Row);

				dtDmCk.AcceptChanges();
			}
			else
				dtDmCk.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmCk.Position < 0)
				return;
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmCk.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMCK", drCurrent))
			{
				bdsDmCk.RemoveAt(bdsDmCk.Position);
				dtDmCk.AcceptChanges();
			}
		}

        //public override void MergeID()
        //{
        //    if (bdsDmCk.Count <= 0)
        //        return;

        //    if (!Common.CheckPermission("MERGE_DMCK", enuPermission_Type.Allow_Access))
        //    {
        //        string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Warehouse code!" : "Bạn không đc cấp quyền Gộp Mã kho!";
        //        Common.MsgCancel(strMsg);
        //        return;
        //    }

        //    drCurrent = ((DataRowView)bdsDmCk.Current).Row;
        //    string strOldValue = (string)drCurrent["Ma_Kho"];

        //    frmMergeID frm = new frmMergeID();

        //    frm.Load("R81DMCK", "Ma_Kho", "Ten_Kho", strOldValue, "DMCK");

        //    if (frm.isAccept)
        //    {
        //        string strNewValue = frm.strNewValue;
        //        string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
        //        if (!Common.MsgYes_No(strMsg))
        //            return;

        //        if (DataTool.SQLMergeID("Ma_Kho", "R81DMCK", strOldValue, strNewValue))
        //        {
        //            bdsDmCk.RemoveCurrent();
        //            bdsDmCk.Position = bdsDmCk.Find("Ma_Kho", strNewValue);
        //        }
        //    }
        //}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmCk == null || bdsDmCk.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmCk.Current).Row;
			DataTable dtTemp = dtDmCk.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmCk.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmCk.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmCk_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMCK", dtDmCk);
		}

		#endregion 
	}
}