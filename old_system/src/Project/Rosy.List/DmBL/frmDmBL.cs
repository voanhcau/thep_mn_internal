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
	public partial class frmDmBl : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmBl;
		DataRow drCurrent;
		BindingSource bdsDmBl = new BindingSource();
		rsDataGridView dgvDmBl = new rsDataGridView();

		#endregion

		#region Contructor

		public frmDmBl()
		{
			InitializeComponent();
            this.dgvDmBl.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvDmBl_CellMouseClick);
			this.dgvDmBl.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmBl_CellMouseDoubleClick);
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
			dgvDmBl.Dock = DockStyle.Fill;
			dgvDmBl.strZone = "DMBL";
			dgvDmBl.BuildGridView(this.isLookup);


			this.splitcContent.Panel1.Controls.Add(dgvDmBl);
		}

		private void FillData()
		{
            

			string strSQlExec = "SELECT T1.*, T2.TEN_DT, T3.Ten_Dt AS Ten_Dt_Bl, T4.So_Hd FROM R81DMBL T1 LEFT JOIN R81DMDT T2 ON T1.MA_DT= T2.MA_DT " +
								" LEFT JOIN (SELECT MA_DT AS MA_DT_BL,TEN_DT FROM R81DMDT WHERE MA_DT IN (SELECT MA_DT_BL FROM R81DMBL)) T3 " +
                                    " ON T3.MA_DT_BL= T1.MA_DT_BL LEFT JOIN (SELECT Ma_Hd, So_Hd FROM R81DMHD) T4 ON T1.Ma_Hd = T4.Ma_Hd WHERE T1.Ngay_End = '19000101' OR YEAR(T1.Ngay_End) >= "+ Element.sysWorkingYear +"";

			//dtDmBl = DataTool.SQLGetDataTable("R81DMBL", null, this.strLookupKeyFilter, null);
			dtDmBl = SQLExec.ExecuteReturnDt(strSQlExec);

			bdsDmBl.DataSource = dtDmBl;
			dgvDmBl.DataSource = bdsDmBl;
			bdsDmBl.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmBl;
			ExportControl = dgvDmBl;

            DataColumn dc = new DataColumn("UNLOCK", typeof(bool));
            dc.DefaultValue = false;
            dtDmBl.Columns.Add(dc);
			
            if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmBl.Rows.Count - 1; i++)
				if (((string)dtDmBl.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmBl.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmBl.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmBl.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmBl.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmBl.NewRow();

			frmDmBl_Edit frmEdit = new frmDmBl_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmBl.Position >= 0)
						dtDmBl.ImportRow(drCurrent);
					else
						dtDmBl.Rows.Add(drCurrent);

					bdsDmBl.Position = bdsDmBl.Find("SO_BL", drCurrent["SO_BL"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmBl.Current).Row);

				dtDmBl.AcceptChanges();
			}
			else
				dtDmBl.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmBl.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmBl.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMBL", drCurrent))
			{
				bdsDmBl.RemoveAt(bdsDmBl.Position);
				dtDmBl.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsDmBl.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMBL", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Warehouse code!" : "Bạn không đc cấp quyền Gộp Mã kho!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmBl.Current).Row;
			string strOldValue = (string)drCurrent["SO_BL"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DMBL", "SO_BL", "", strOldValue, "DMBL");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("SO_BL", "R81DMBL", strOldValue, strNewValue))
				{
					bdsDmBl.RemoveCurrent();
					bdsDmBl.Position = bdsDmBl.Find("SO_BL", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmBl == null || bdsDmBl.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmBl.Current).Row;
			DataTable dtTemp = dtDmBl.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmBl.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmBl.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien
        void dgvDmBl_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsDmBl.Current).Row;
            string strColumnName = dgvDmBl.Columns[e.ColumnIndex].Name;
            if (strColumnName == "LOCK" && Common.CheckPermission("IS_TP_KTTC",enuPermission_Type.Allow_Access))
            {
                frmUnLock_DM frm = new frmUnLock_DM();
                frm.Load(drCurrent, "R81DMBL","");
            }
            if (strColumnName == "EDIT" && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
            {
                frmTransferHMBL frm = new frmTransferHMBL();
                frm.Load(drCurrent);
            }
        }
		void dgvDmBl_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMBL", dtDmBl);
		}

		#endregion 
	}
}