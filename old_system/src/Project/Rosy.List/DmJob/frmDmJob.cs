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
	public partial class frmDmJob : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmJob;
		DataRow drCurrent;
		BindingSource bdsDmJob = new BindingSource();
		rsDataGridView dgvDmJob = new rsDataGridView();
		rsTreeList tlDmJob = new rsTreeList();

		#endregion

		#region Contructor

		public frmDmJob()
		{
			InitializeComponent();

			this.dgvDmJob.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmJob_CellMouseDoubleClick);
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
			//dgvDmJob.Dock = DockStyle.Fill;

			//this.splitcContent.Panel1.Controls.Add(dgvDmJob);

			//dgvDmJob.strZone = "DMJOB";
			//dgvDmJob.BuildGridView(this.isLookup);

			tlDmJob.KeyFieldName = "MA_JOB";
			tlDmJob.ParentFieldName = "MA_JOB_PARENT";
			tlDmJob.Dock = DockStyle.Fill;

			tlDmJob.strZone = "DMJOB";
			tlDmJob.BuildTreeList(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(tlDmJob);
		}

		private void FillData()
		{
			dtDmJob = DataTool.SQLGetDataTable("R81DMJOB", null, this.strLookupKeyFilter, null);

			bdsDmJob.DataSource = dtDmJob;
			dgvDmJob.DataSource = bdsDmJob;

			//Uy quyen cho lop co so tim kiem
			bdsSearch = bdsDmJob;
			ExportControl = tlDmJob;

			tlDmJob.DataSource = bdsDmJob;
			bdsDmJob.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmJob.Rows.Count - 1; i++)
				if (((string)dtDmJob.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmJob.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmJob.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmJob.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmJob.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmJob.NewRow();

			frmDmJob_Edit frmEdit = new frmDmJob_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmJob.Position >= 0)
						dtDmJob.ImportRow(drCurrent);
					else
						dtDmJob.Rows.Add(drCurrent);

					bdsDmJob.Position = bdsDmJob.Find("MA_JOB", drCurrent["MA_JOB"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmJob.Current).Row);

				dtDmJob.AcceptChanges();
			}
			else
				dtDmJob.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmJob.Position < 0)
				return;

			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmJob.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMJOB", drCurrent))
			{
				bdsDmJob.RemoveAt(bdsDmJob.Position);
				dtDmJob.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsDmJob.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMJOB", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Job code!" : "Bạn không đc cấp quyền Gộp Mã công việc!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmJob.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Job"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DMJOB", "Ma_Job", "Ten_Job", strOldValue, "DMJOB");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Job", "R81DMJOB", strOldValue, strNewValue))
				{
					bdsDmJob.RemoveCurrent();
					bdsDmJob.Position = bdsDmJob.Find("Ma_Job", strNewValue);
				}
			}
		}


		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmJob == null || bdsDmJob.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmJob.Current).Row;
			DataTable dtTemp = dtDmJob.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmJob.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmJob.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmJob_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);

		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMJOB", dtDmJob);
		}

		#endregion 
	}
}