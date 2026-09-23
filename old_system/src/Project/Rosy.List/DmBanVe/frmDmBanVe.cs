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
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmBanVe : RosyList.frmView
	{
		#region Khai bao bien
		DataTable dtDmBanVe;
		DataRow drCurrent;
		BindingSource bdsDmBanVe = new BindingSource();
		rsDataGridView dgvDmBanVe = new rsDataGridView();

		public bool bLookupByGroup = false;
		public bool bFind = false;

		#endregion 						

		#region Contructor
        public frmDmBanVe()
		{
			InitializeComponent();

			this.dgvDmBanVe.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmBanVe_CellMouseDoubleClick);
			this.btImport.Click += new EventHandler(btImport_Click);
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

		//public void Load(string strMa_Nh_Hd)
		//{
		//    this.strMa_Nh_Hd = strMa_Nh_Hd;

		//    this.Load();
		//}

		public override void LoadLookup()
		{
			//if (!bLookupByGroup && Parameters.GetParaValue("ACCESS_DMHD").ToString() == "1") //Truy cap theo nhom
			//{
			//    string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

			//    if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
			//    {
			//        if (this.strLookupValue == "/" || this.strLookupValue == @"\")
			//            strWhere = strLookupKeyFilter;
			//        else
			//            strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
			//    }

			//    DataTable dtFind = DataTool.SQLGetDataTable("R81DmHd", null, strWhere, null);

			//    if (dtFind.Rows.Count > 0)
			//    {
			//        strLookupKeyFilter = strWhere;
			//        bFind = true;
			//        this.Load();
			//    }
			//    else
			//        this.LoadLookupByGroup();
			//}
			//else
			//    this.Load(this.strMa_Nh_Hd);
		}

		

		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDmBanVe.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvDmBanVe);

			dgvDmBanVe.strZone = "DMBANVE";
			dgvDmBanVe.BuildGridView(this.isLookup);
		}

		private void FillData()
		{
			string strKey = string.Empty;
						
			dtDmBanVe = DataTool.SQLGetDataTable("R81DMBANVE", null, strKey, null);


			bdsDmBanVe.DataSource = dtDmBanVe;
			dgvDmBanVe.DataSource = bdsDmBanVe;

			bdsDmBanVe.Filter = this.strLookupKeyFilter;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmBanVe;
			bdsDmBanVe.Position = 0;
			ExportControl = dgvDmBanVe;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == String.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmBanVe.Rows.Count - 1; i++)
				if (((string)dtDmBanVe.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmBanVe.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			
			if (bdsDmBanVe.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Edit"));
				return;
			}

			//Copy hang hien tai            
			if (bdsDmBanVe.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmBanVe.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmBanVe.NewRow();
				//drCurrent["Ma_BanVe"] = strMa_Nh_Hd;
			}

			frmDmBanVe_Edit frmEdit = new frmDmBanVe_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmBanVe.Position >= 0)
						dtDmBanVe.ImportRow(drCurrent);
					else
						dtDmBanVe.Rows.Add(drCurrent);

					bdsDmBanVe.Position = bdsDmBanVe.Find("MA_BanVe", drCurrent["MA_BanVe"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmBanVe.Current).Row);

				drCurrent.AcceptChanges();
				//dtDmBanVe.AcceptChanges();
			}
			//else
			//    dtDmBanVe.RejectChanges();
		}

		public override void Delete()
		{
			
			if (bdsDmBanVe.Position < 0)
				return;

			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}

			DataRow drCurrent = ((DataRowView)bdsDmBanVe.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DmBanVe", drCurrent))
			{
				bdsDmBanVe.RemoveAt(bdsDmBanVe.Position);
				dtDmBanVe.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			//if (bdsDmBanVe.Count <= 0)
			//    return;

			//if (!Common.CheckPermission("MERGE_DMHD", enuPermission_Type.Allow_Access))
			//{
			//    string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Contract code!" : "Bạn không đc cấp quyền Gộp Mã hợp đồng!";
			//    Common.MsgCancel(strMsg);
			//    return;
			//}

			//drCurrent = ((DataRowView)bdsDmBanVe.Current).Row;
			//string strOldValue = (string)drCurrent["Ma_Hd"];

			//frmMergeID frm = new frmMergeID();

			//frm.Load("R81DmHd", "Ma_Hd", "Ten_Hd", strOldValue, "DMHD");

			//if (frm.isAccept)
			//{
			//    string strNewValue = frm.strNewValue;
			//    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
			//    if (!Common.MsgYes_No(strMsg))
			//        return;

			//    if (DataTool.SQLMergeID("Ma_Hd", "R81DmHd", strOldValue, strNewValue))
			//    {
			//        bdsDmBanVe.RemoveCurrent();
			//        bdsDmBanVe.Position = bdsDmBanVe.Find("Ma_Hd", strNewValue);
			//    }
			//}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmBanVe == null || bdsDmBanVe.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmBanVe.Current).Row;
			DataTable dHdCtmp = dtDmBanVe.Clone();
			dHdCtmp.ImportRow(drCurrent);

			if ((dHdCtmp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmBanVe.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmBanVe.Current).Row;

			if (isLookup && EnterValid())
			{
				drLookup = drCurrent;
				this.Close();
			}
			
		}

		#endregion 

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);
		}

		void dgvDmBanVe_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			//Public.ImportExcel("DMHD", dtDmBanVe);
		}
	}
}