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
using RosySystem.Public;
using System.Collections;

namespace RosyModule.Payable
{
	public partial class frmVTPTTD_Enter : RosyList.frmView
	{
		#region Khai bao bien

		private DataTable dtDmVtSp;
		private DataRow drCurrent;
		private BindingSource bdsDmVtSp = new BindingSource();
		private rsDataGridView dgvDmVtSp = new rsDataGridView();

		public string strMa_Nh_Vt = string.Empty;
		public bool bLookupByGroup = false;
		public bool bFind = false;

		#endregion 

		#region Contructor
        public frmVTPTTD_Enter()
		{
			InitializeComponent();

			this.dgvDmVtSp.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmSp_CellMouseDoubleClick);
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

		public void Load(string strMa_Nh_Vt)
		{
			this.strMa_Nh_Vt = strMa_Nh_Vt;

			this.Load();
		}

		public override void LoadLookup()
		{
			
		}

		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDmVtSp.Dock = DockStyle.Fill;
            dgvDmVtSp.strZone = "DMVT";
			dgvDmVtSp.BuildGridView(this.isLookup);

            //dgvDmVtSp.Columns["Ghi_Chu"].HeaderText = "Vị trí sử dụng";

			this.splitcContent.Panel1.Controls.Add(dgvDmVtSp);
		}

		private void FillData()	
		{

            Hashtable ht = new Hashtable();
            ht.Add("MA_VT_TD", strMa_Nh_Vt);
            dtDmVtSp = SQLExec.ExecuteReturnDt("sp_GetVTPTTD_Ct", ht, CommandType.StoredProcedure);

            bdsDmVtSp.DataSource = dtDmVtSp;
			dgvDmVtSp.DataSource = bdsDmVtSp;
			bdsDmVtSp.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmVtSp;
			ExportControl = dgvDmVtSp;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmVtSp.Rows.Count - 1; i++)
				if (((string)dtDmVtSp.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmVtSp.Position = i;
					break;
				}
		}
		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
            return;
			if (bdsDmVtSp.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmVtSp.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmVtSp.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmVtSp.NewRow();
				drCurrent["Ma_Vt"] = strMa_Nh_Vt;
			}

            //frmDmPTKT_Edit frmEdit = new frmDmPTKT_Edit();
            //frmEdit.Load(enuNew_Edit, drCurrent,"2");
			
            //// người dùng chọn chấp nhận
            //if (frmEdit.isAccept)
            //{
            //    if (enuNew_Edit == enuEdit.New)
            //    {
            //        if (bdsDmVtSp.Position >= 0)
            //            dtDmVtSp.ImportRow(drCurrent);
            //        else
            //        {
            //            dtDmVtSp.Rows.Add(drCurrent);
            //            drCurrent["Ma_Vt"] = strMa_Nh_Vt;
            //        }
                   
            //        bdsDmVtSp.Position = bdsDmVtSp.Find("IDENT00", drCurrent["IDENT00"]);
            //    }
            //    else
            //        Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmVtSp.Current).Row);

            //    dtDmVtSp.AcceptChanges();
            //}
            //else
            //    dtDmVtSp.RejectChanges();
		}

		public override void Delete()
		{
            return;

			if (bdsDmVtSp.Position < 0)
				return;
			
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}

			DataRow drCurrent = ((DataRowView)bdsDmVtSp.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R06VTTB", drCurrent))
			{
				bdsDmVtSp.RemoveAt(bdsDmVtSp.Position);
				dtDmVtSp.AcceptChanges();
			}
		}

		public override void MergeID()
		{
            //if (bdsDmVtSp.Count <= 0)
            //    return;

            //if (!Common.CheckPermission("MERGE_DMVT", enuPermission_Type.Allow_Access))
            //{
            //    string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Item code!" : "Bạn không đc cấp quyền Gộp Mã vật tư, hàng hóa!";
            //    Common.MsgCancel(strMsg);
            //    return;
            //}

            //drCurrent = ((DataRowView)bdsDmVtSp.Current).Row;
            //string strOldValue = (string)drCurrent["Ma_Vt"];

            //frmMergeID frm = new frmMergeID();

            //frm.Load("R06VTTB", "Ma_Vt", "Ten_Vt", strOldValue, "DMVT");

            //if (frm.isAccept)
            //{
            //    string strNewValue = frm.strNewValue;
            //    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
            //    if (!Common.MsgYes_No(strMsg))
            //        return;

            //    if (DataTool.SQLMergeID("Ma_Vt", "R81DmVt", strOldValue, strNewValue))
            //    {
            //        bdsDmVtSp.RemoveCurrent();
            //        bdsDmVtSp.Position = bdsDmVtSp.Find("Ma_Vt", strNewValue);
            //    }
            //}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmVtSp == null || bdsDmVtSp.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmVtSp.Current).Row;
			DataTable dtTemp = dtDmVtSp.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmVtSp.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmVtSp.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmSp_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMVT", dtDmVtSp);
		}

		#endregion 
	}
	
}