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
	public partial class frmDmThue : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmThue;
		DataRow drCurrent;
		BindingSource bdsDmThue = new BindingSource();
		rsDataGridView dgvDmThue = new rsDataGridView();

		#endregion

		#region Contructor

		public frmDmThue()
		{
			InitializeComponent();

			this.dgvDmThue.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmThue_CellMouseDoubleClick);
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
			dgvDmThue.Dock = DockStyle.Fill;
			dgvDmThue.strZone = "DMTHUE";
			dgvDmThue.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmThue);
		}

		private void FillData()
		{
			dtDmThue = DataTool.SQLGetDataTable("R81DMTHUE", null, this.strLookupKeyFilter, null);

			bdsDmThue.DataSource = dtDmThue;
			dgvDmThue.DataSource = bdsDmThue;
			bdsDmThue.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmThue;
			ExportControl = dgvDmThue;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmThue.Rows.Count - 1; i++)
				if (((string)dtDmThue.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmThue.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmThue.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmThue.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmThue.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmThue.NewRow();

			frmDmThue_Edit frmEdit = new frmDmThue_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmThue.Position >= 0)
						dtDmThue.ImportRow(drCurrent);
					else
						dtDmThue.Rows.Add(drCurrent);

					bdsDmThue.Position = bdsDmThue.Find("MA_THUE", drCurrent["MA_THUE"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmThue.Current).Row);

				dtDmThue.AcceptChanges();
			}
			else
				dtDmThue.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmThue.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmThue.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMTHUE", drCurrent))
			{
				bdsDmThue.RemoveAt(bdsDmThue.Position);
				dtDmThue.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsDmThue.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMTHUE", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge VAT code!" : "Bạn không đc cấp quyền Gộp Mã thuế!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmThue.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Thue"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DMTHUE", "Ma_Thue", "Ten_Thue", strOldValue, "DMTHUE");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Thue", "R81DMTHUE", strOldValue, strNewValue))
				{
					bdsDmThue.RemoveCurrent();
					bdsDmThue.Position = bdsDmThue.Find("Ma_Thue", strNewValue);
				}
			}
		}

		#endregion

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmThue == null || bdsDmThue.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmThue.Current).Row;
			DataTable dtTemp = dtDmThue.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmThue.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmThue.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmThue_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMTHUE", dtDmThue);
		}

		#endregion 
	}
}