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
	public partial class frmDmKho : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmKho;
		DataRow drCurrent;
		BindingSource bdsDmKho = new BindingSource();
		rsDataGridView dgvDmKho = new rsDataGridView();

		#endregion

		#region Contructor

		public frmDmKho()
		{
			InitializeComponent();

			this.dgvDmKho.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmKho_CellMouseDoubleClick);
            this.dgvDmKho.CellMouseClick += DgvDmKho_CellMouseClick;
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
			dgvDmKho.Dock = DockStyle.Fill;
			dgvDmKho.strZone = "DMKHO";
			dgvDmKho.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmKho);
		}

		private void FillData()
		{
            if (this.isLookup)
                dtDmKho = DataTool.SQLGetDataTable("R81DMKHO", null, this.strLookupKeyFilter, null);
            else
                dtDmKho = SQLExec.ExecuteReturnDt("sp_GetDmKho", CommandType.StoredProcedure);
			
			bdsDmKho.DataSource = dtDmKho;
			dgvDmKho.DataSource = bdsDmKho;
			bdsDmKho.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmKho;
			ExportControl = dgvDmKho;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmKho.Rows.Count - 1; i++)
				if (((string)dtDmKho.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmKho.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmKho.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmKho.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmKho.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmKho.NewRow();


            if(enuNew_Edit == enuEdit.New)
                 drCurrent["Sl_Dm_Kg"] = 0;

			frmDmKho_Edit frmEdit = new frmDmKho_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmKho.Position >= 0)
						dtDmKho.ImportRow(drCurrent);
					else
						dtDmKho.Rows.Add(drCurrent);

					bdsDmKho.Position = bdsDmKho.Find("MA_KHO", drCurrent["MA_KHO"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmKho.Current).Row);

				dtDmKho.AcceptChanges();
			}
			else
				dtDmKho.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmKho.Position < 0)
				return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmKho.Current).Row;

			
			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMKHO", drCurrent))
			{
				bdsDmKho.RemoveAt(bdsDmKho.Position);
				dtDmKho.AcceptChanges();
			}
			
		}

		public override void MergeID()
		{
			if (bdsDmKho.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMKHO", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Warehouse code!" : "Bạn không đc cấp quyền Gộp Mã kho!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmKho.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Kho"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DMKHO", "Ma_Kho", "Ten_Kho", strOldValue, "DMKHO");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Kho", "R81DMKHO", strOldValue, strNewValue))
				{
					bdsDmKho.RemoveCurrent();
					bdsDmKho.Position = bdsDmKho.Find("Ma_Kho", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmKho == null || bdsDmKho.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmKho.Current).Row;
			DataTable dtTemp = dtDmKho.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmKho.Position < 0)
				return;
            drCurrent = ((DataRowView)bdsDmKho.Current).Row;
            if (isLookup && EnterValid())
            {
                drLookup = ((DataRowView)bdsDmKho.Current).Row;
                this.Close();
            }
            else
            { //Enter vao chi tiet kho SL ký gửi

                //frmDmKhoCT frm = new frmDmKhoCT();

                //frm.MdiParent = this.MdiParent;
                //frm.Load((string)drCurrent["Ma_Kho"], (string)drCurrent["Ma_Dt"]);
            }
		}

		#endregion

		#region Su kien
		
		void dgvDmKho_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}
		private void DgvDmKho_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			drCurrent = ((DataRowView)bdsDmKho.Current).Row;
			string strColumnName = dgvDmKho.Columns[e.ColumnIndex].Name;
			
			if (strColumnName == "EDIT_HANHD" && Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
			{
				frmDmKhoKG frm = new frmDmKhoKG();

				frm.MdiParent = this.MdiParent;
				frm.Load((string)drCurrent["Ma_Kho"]);
			}
		}
		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMKHO", dtDmKho);
		}

		#endregion 
	}
}