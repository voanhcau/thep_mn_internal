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
	public partial class frmDmNangSuat : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmNangSuat;
		DataRow drCurrent;
		BindingSource bdsDmNangSuat = new BindingSource();
		rsDataGridView dgvDmNangSuat = new rsDataGridView();

		#endregion

		#region Contructor

		public frmDmNangSuat()
		{
			InitializeComponent();

			this.dgvDmNangSuat.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmNangSuat_CellMouseDoubleClick);
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
			dgvDmNangSuat.Dock = DockStyle.Fill;
			dgvDmNangSuat.strZone = "DMNANGSUAT";
			dgvDmNangSuat.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmNangSuat);
		}

		private void FillData()
		{
            //if (this.isLookup)
                //dtDmNangSuat = DataTool.SQLGetDataTable("R13NANGSUATSP", null, this.strLookupKeyFilter, null);
            //else
            dtDmNangSuat = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Grade_Name FROM R13NANGSUATSP T1 LEFT JOIN R81DMMACTHEP T2 ON T1.Grade_ID = T2.Grade_ID ");
			bdsDmNangSuat.DataSource = dtDmNangSuat;
			dgvDmNangSuat.DataSource = bdsDmNangSuat;
			bdsDmNangSuat.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmNangSuat;
			ExportControl = dgvDmNangSuat;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmNangSuat.Rows.Count - 1; i++)
				if (((string)dtDmNangSuat.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmNangSuat.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmNangSuat.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmNangSuat.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmNangSuat.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmNangSuat.NewRow();

			frmDmNangSuat_Edit frmEdit = new frmDmNangSuat_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmNangSuat.Position >= 0)
						dtDmNangSuat.ImportRow(drCurrent);
					else
						dtDmNangSuat.Rows.Add(drCurrent);

					bdsDmNangSuat.Position = bdsDmNangSuat.Find("IDENT00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmNangSuat.Current).Row);

				dtDmNangSuat.AcceptChanges();
			}
			else
				dtDmNangSuat.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmNangSuat.Position < 0)
				return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmNangSuat.Current).Row;

			
			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R13NANGSUATSP", drCurrent))
			{
				bdsDmNangSuat.RemoveAt(bdsDmNangSuat.Position);
				dtDmNangSuat.AcceptChanges();
			}
			
		}

        //public override void MergeID()
        //{
        //    if (bdsDmNangSuat.Count <= 0)
        //        return;

        //    if (!Common.CheckPermission("MERGE_DMKHO", enuPermission_Type.Allow_Access))
        //    {
        //        string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Warehouse code!" : "Bạn không đc cấp quyền Gộp Mã kho!";
        //        Common.MsgCancel(strMsg);
        //        return;
        //    }

        //    drCurrent = ((DataRowView)bdsDmNangSuat.Current).Row;
        //    string strOldValue = (string)drCurrent["Ma_Kho"];

        //    frmMergeID frm = new frmMergeID();

        //    frm.Load("R81DMKHO", "Ma_Kho", "Ten_Kho", strOldValue, "DMKHO");

        //    if (frm.isAccept)
        //    {
        //        string strNewValue = frm.strNewValue;
        //        string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
        //        if (!Common.MsgYes_No(strMsg))
        //            return;

        //        if (DataTool.SQLMergeID("Ma_Kho", "R81DMKHO", strOldValue, strNewValue))
        //        {
        //            bdsDmNangSuat.RemoveCurrent();
        //            bdsDmNangSuat.Position = bdsDmNangSuat.Find("Ma_Kho", strNewValue);
        //        }
        //    }
        //}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmNangSuat == null || bdsDmNangSuat.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmNangSuat.Current).Row;
			DataTable dtTemp = dtDmNangSuat.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmNangSuat.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmNangSuat.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmNangSuat_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

        //void btImport_Click(object sender, EventArgs e)
        //{
        //    RosySystem.Public.Public.ImportExcel("DMKHO", dtDmNangSuat);
        //}

		#endregion 
	}
}