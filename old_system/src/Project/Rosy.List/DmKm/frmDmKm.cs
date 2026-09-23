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
	public partial class frmDmKm : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmKm;
		DataRow drCurrent;
		BindingSource bdsDmKm = new BindingSource();
		rsDataGridView dgvDmKm = new rsDataGridView();
		rsTreeList tlDmKm = new rsTreeList();
		#endregion 						

		#region Contructor

		public frmDmKm()
		{
			InitializeComponent();
			tlDmKm.MouseDoubleClick += new MouseEventHandler(tlDmKm_MouseDoubleClick);
			this.dgvDmKm.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmKm_CellMouseDoubleClick);
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
			tlDmKm.KeyFieldName = "MA_KM";
			tlDmKm.ParentFieldName = "MA_KM_PARENT";
			tlDmKm.Dock = DockStyle.Fill;

			tlDmKm.strZone = "DMKM";
			tlDmKm.BuildTreeList(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(tlDmKm);

			//dgvDmKm.Dock = DockStyle.Fill;
			//dgvDmKm.strZone = "DMKM";
			//dgvDmKm.BuildGridView(this.isLookup);

			//this.splitcContent.Panel1.Controls.Add(dgvDmKm);
		}

		private void FillData()
		{
			dtDmKm = DataTool.SQLGetDataTable("R81DMKM", null, this.strLookupKeyFilter, null);

			dgvDmKm.DataSource = bdsDmKm;
			bdsDmKm.DataSource = dtDmKm;
			bdsDmKm.Position = 0;

			////Uy quyen cho lop co so tim kiem           
			//bdsSearch = bdsDmKm;
			//ExportControl = dgvDmKm;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmKm;
			ExportControl = tlDmKm;

			tlDmKm.DataSource = bdsDmKm;
			bdsDmKm.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();
            tlDmKm.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmKm.strZone + "'");
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmKm.Rows.Count - 1; i++)
				if (((string)dtDmKm.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmKm.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmKm.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmKm.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmKm.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmKm.NewRow();

			frmDmKm_Edit frmEdit = new frmDmKm_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmKm.Position >= 0)
						dtDmKm.ImportRow(drCurrent);
					else
						dtDmKm.Rows.Add(drCurrent);

					bdsDmKm.Position = bdsDmKm.Find("MA_KM", drCurrent["MA_KM"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmKm.Current).Row);

				dtDmKm.AcceptChanges();
			}
			else
				dtDmKm.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmKm.Position < 0)	
				return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmKm.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMKM", drCurrent))
			{
				bdsDmKm.RemoveAt(bdsDmKm.Position);
				dtDmKm.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsDmKm.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMKM", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Catergory code!" : "Bạn không đc cấp quyền Gộp Mã khoản mục!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmKm.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Km"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DMKM", "Ma_Km", "Ten_Km", strOldValue, "DMKM");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Km", "R81DMKM", strOldValue, strNewValue))
				{
					bdsDmKm.RemoveCurrent();
					bdsDmKm.Position = bdsDmKm.Find("Ma_Km", strNewValue);
				}
			}
		}

		#endregion

		#region EnterProcess

		void tlDmKm_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		private bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmKm == null || bdsDmKm.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmKm.Current).Row;
			DataTable dtTemp = dtDmKm.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmKm.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmKm.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmKm_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMKM", dtDmKm);
		}

		#endregion 
	}
}