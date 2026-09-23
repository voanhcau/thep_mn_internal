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
	public partial class frmDmCTrinh : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmCTrinh;
		DataRow drCurrent;
		BindingSource bdsDmCTrinh = new BindingSource();
		rsDataGridView dgvDmCTrinh = new rsDataGridView();

		#endregion 						

		#region Contructor

		public frmDmCTrinh()
		{
			InitializeComponent();

			this.dgvDmCTrinh.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmCTrinh_CellMouseDoubleClick);
			
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


			dgvDmCTrinh.Dock = DockStyle.Fill;
			dgvDmCTrinh.strZone = "DMCTRINH";
			dgvDmCTrinh.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmCTrinh);
		}

		private void FillData()
		{
			string strSQLExec = string.Empty;
			string strKey = strKey = (this.strLookupKeyFilter == null ? string.Empty : this.strLookupKeyFilter);
			if (this.strLookupKeyFilter == null || this.strLookupKeyFilter == string.Empty)
				strSQLExec = "SELECT * FROM R81DMCTRINH";
				//strSQLExec = "SELECT T1.*,  T3.Ten_Dt FROM R81DMCTrinh T1 " +
				//             " LEFT JOIN R81DmDt T3 ON T1.Ma_Dt = T3.Ma_Dt";

			dtDmCTrinh = SQLExec.ExecuteReturnDt(strSQLExec);


			//string strKeyFilter = string.Empty;

			//dtDmCTrinh = DataTool.SQLGetDataTable("R81DMCTRINH", null, this.strLookupKeyFilter, null);

			dgvDmCTrinh.DataSource = bdsDmCTrinh;
			bdsDmCTrinh.DataSource = dtDmCTrinh;
			bdsDmCTrinh.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmCTrinh;
			ExportControl = dgvDmCTrinh;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmCTrinh.Rows.Count - 1; i++)
				if (((string)dtDmCTrinh.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmCTrinh.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmCTrinh.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Edit"));
				return;
			}
			//Copy hang hien tai            
			if (bdsDmCTrinh.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmCTrinh.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmCTrinh.NewRow();

			frmDmCTrinh_Edit frmEdit = new frmDmCTrinh_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmCTrinh.Position >= 0)
						dtDmCTrinh.ImportRow(drCurrent);
					else
						dtDmCTrinh.Rows.Add(drCurrent);

					bdsDmCTrinh.Position = bdsDmCTrinh.Find("MA_CTRINH", drCurrent["MA_CTRINH"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmCTrinh.Current).Row);

				dtDmCTrinh.AcceptChanges();
			}
			else
				dtDmCTrinh.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmCTrinh.Position < 0)	
				return;
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}

			DataRow drCurrent = ((DataRowView)bdsDmCTrinh.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMCTRINH", drCurrent))
			{
				bdsDmCTrinh.RemoveAt(bdsDmCTrinh.Position);
				dtDmCTrinh.AcceptChanges();
			}
		}

        //public override void MergeID()
        //{
        //    if (bdsDmCTrinh.Count <= 0)
        //        return;

        //    if (!Common.CheckPermission("MERGE_DmCTrinh", enuPermission_Type.Allow_Access))
        //    {
        //        string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Catergory code!" : "Bạn không đc cấp quyền Gộp Mã khoản mục!";
        //        Common.MsgCancel(strMsg);
        //        return;
        //    }

        //    drCurrent = ((DataRowView)bdsDmCTrinh.Current).Row;
        //    string strOldValue = (string)drCurrent["MA_CTRINH"];

        //    frmMergeID frm = new frmMergeID();

        //    frm.Load("R81DmCTrinh", "MA_CTRINH", "Ten_Km", strOldValue, "DmCTrinh");

        //    if (frm.isAccept)
        //    {
        //        string strNewValue = frm.strNewValue;
        //        string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
        //        if (!Common.MsgYes_No(strMsg))
        //            return;

        //        if (DataTool.SQLMergeID("MA_CTRINH", "R81DmCTrinh", strOldValue, strNewValue))
        //        {
        //            bdsDmCTrinh.RemoveCurrent();
        //            bdsDmCTrinh.Position = bdsDmCTrinh.Find("MA_CTRINH", strNewValue);
        //        }
        //    }
        //}

		#endregion

		#region EnterProcess

		private bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmCTrinh == null || bdsDmCTrinh.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmCTrinh.Current).Row;
			DataTable dtTemp = dtDmCTrinh.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmCTrinh.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmCTrinh.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmCTrinh_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMCTRINH", dtDmCTrinh);
		}

		#endregion 
	}
}