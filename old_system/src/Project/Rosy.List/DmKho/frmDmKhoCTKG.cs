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
	public partial class frmDmKhoCTKG : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmKho;
		DataRow drCurrent;
		BindingSource bdsDmKho = new BindingSource();
		rsDataGridView dgvDmKho = new rsDataGridView();
        string strMa_Kho = string.Empty;
        string strMa_Dt = string.Empty;
		#endregion

		#region Contructor

        public frmDmKhoCTKG()
		{
			InitializeComponent();

			this.dgvDmKho.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmKho_CellMouseDoubleClick);
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
        public void Load(string strMa_Kho, string strMa_Dt)
        {
            this.strMa_Kho = strMa_Kho;
            this.strMa_Dt = strMa_Dt;

            
            this.Load();
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
			dgvDmKho.strZone = "DMKHOCTKG";
			dgvDmKho.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmKho);
		}

		private void FillData()
		{
            if (this.isLookup)
                dtDmKho = DataTool.SQLGetDataTable("R81DMKHO", null, this.strLookupKeyFilter, null);
            else
                dtDmKho = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Ten_Dt FROM R81DMKHOCT_KG T1 LEFT JOIN R81DMDT T2 ON T1.Ma_Dt = T2.Ma_Dt ORDER BY T1.Ma_Dt, Ngay_Ap");
			
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


            if (enuNew_Edit == enuEdit.New)
            {
				//drCurrent["Ma_Kho_Kv"] = strMa_Kho;
				//drCurrent["Ma_Dt"] = strMa_Dt;
				drCurrent["LastModify_Log"] = string.Empty;
				drCurrent["Sl_Dm_Kg"] = 0;
				drCurrent["Ngay_Ap"] = DateTime.Now;
				drCurrent["Ngay_Bd"] = DateTime.Now;
			}
			frmDmKhoCTKG_Edit frmEdit = new frmDmKhoCTKG_Edit();
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

                    bdsDmKho.Position = bdsDmKho.Find("Ident00", drCurrent["Ident00"]);
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
		
			if (DataTool.SQLDelete("R81DMKHOCT_KG", drCurrent))
			{
				bdsDmKho.RemoveAt(bdsDmKho.Position);
				dtDmKho.AcceptChanges();
			}
			
		}

		public override void MergeID()
		{
			if (bdsDmKho.Count <= 0)
				return;

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

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmKho.Current).Row;
				this.Close();
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

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMKHOCT_KG", dtDmKho);
		}

		#endregion 
	}
}