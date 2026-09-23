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

namespace RosyList
{
	public partial class frmDmDt_Ncc : RosyList.frmView
	{
		#region Khai bao bien

		private DataTable dtDmVt;
		private DataRow drCurrent;
		private BindingSource bdsDmVt = new BindingSource();
		private rsDataGridView dgvDmVt = new rsDataGridView();

		public string strKey = string.Empty;


		public bool bLookupByGroup = false;
		public bool bFind = false;

		#endregion 

		#region Contructor
		public frmDmDt_Ncc()
		{
			InitializeComponent();

			this.dgvDmVt.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmVt_CellMouseDoubleClick);
			//this.btImport.Click +=new EventHandler(btImport_Click);
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

		public void Load(string strKey)
		{
			this.strKey = strKey;

			this.Load();
		}

		public override void LoadLookup()
		{
			this.Load(this.strKey);
		}

		//private void LoadLookupByGroup()
		//{//Lookup theo nhom

		//    frmDmNhVt frm = new frmDmNhVt();
		//    frm.bLookupByGroup = true;
		//    frm.isLookup = true;
		//    frm.strLookupKeyFilter = this.strLookupKeyFilter;
		//    frm.strLookupKeyValid = this.strLookupKeyValid;
		//    frm.bLookupRequire = this.bLookupRequire;

		//    frm.LoadLookup();

		//    this.bIsEnter = frm.bIsEnter;
		//    this.drLookup = frm.drLookup;
		//    this.Close();
		//}

		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDmVt.Dock = DockStyle.Fill;
			dgvDmVt.strZone = "DMDTMH";
			dgvDmVt.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmVt);
		}

		private void FillData()	
		{

			dtDmVt = DataTool.SQLGetDataTable("VW_DMDT_MH", null, this.strLookupKeyFilter, "Ma_Vt,Ngay_Ap");
			
			bdsDmVt.DataSource = dtDmVt;
			dgvDmVt.DataSource = bdsDmVt;
			bdsDmVt.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmVt;
			ExportControl = dgvDmVt;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmVt.Rows.Count - 1; i++)
				if (((string)dtDmVt.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmVt.Position = i;
					break;
				}
		}
		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			//if (bdsDmVt.Position < 0 && enuNew_Edit == enuEdit.Edit)
			//    return;

			////Copy hang hien tai            
			//if (bdsDmVt.Position >= 0)
			//    Common.CopyDataRow(((DataRowView)bdsDmVt.Current).Row, ref drCurrent);
			//else
			//{
			//    drCurrent = dtDmVt.NewRow();
			//    drCurrent["Ma_Nh_Vt"] = strMa_Nh_Vt;
			//}

			//frmDmVt_Edit frmEdit = new frmDmVt_Edit();
			//frmEdit.Load(enuNew_Edit, drCurrent);
			
			//// người dùng chọn chấp nhận
			//if (frmEdit.isAccept)
			//{
			//    if (enuNew_Edit == enuEdit.New)
			//    {
			//        if (bdsDmVt.Position >= 0)
			//            dtDmVt.ImportRow(drCurrent);
			//        else
			//            dtDmVt.Rows.Add(drCurrent);

			//        bdsDmVt.Position = bdsDmVt.Find("MA_VT", drCurrent["MA_VT"]);
			//    }
			//    else
			//        Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmVt.Current).Row);

			//    dtDmVt.AcceptChanges();
			//}
			//else
			//    dtDmVt.RejectChanges();
		}

		public override void Delete()
		{
			//if (bdsDmVt.Position < 0)
			//    return;

			//DataRow drCurrent = ((DataRowView)bdsDmVt.Current).Row;

			//if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
			//    return;

			//if (DataTool.SQLCheckExist("R04CSGIA", "Ma_Vt", drCurrent["Ma_Vt"]))
			//{
			//    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
			//        "Vật tư : {" + drCurrent["Ten_Vt"].ToString() + "}  đang sử dụng ở chính sách giá" :
			//        "Item : {" + drCurrent["Ten_Vt"].ToString() + "}  is using in item cost table";

			//    Common.MsgOk(strMsg);
			//    return;
			//}


			//if (DataTool.SQLDelete("R81DmVt", drCurrent))
			//{
			//    bdsDmVt.RemoveAt(bdsDmVt.Position);
			//    dtDmVt.AcceptChanges();
			//}
		}

		public override void MergeID()
		{
			//if (bdsDmVt.Count <= 0)
			//    return;

			//if (!Common.CheckPermission("MERGE_DMVT", enuPermission_Type.Allow_Access))
			//{
			//    string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Item code!" : "Bạn không đc cấp quyền Gộp Mã vật tư, hàng hóa!";
			//    Common.MsgCancel(strMsg);
			//    return;
			//}

			//drCurrent = ((DataRowView)bdsDmVt.Current).Row;
			//string strOldValue = (string)drCurrent["Ma_Vt"];

			//frmMergeID frm = new frmMergeID();

			//frm.Load("R81DMVT", "Ma_Vt", "Ten_Vt", strOldValue, "DMVT");

			//if (frm.isAccept)
			//{
			//    string strNewValue = frm.strNewValue;
			//    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
			//    if (!Common.MsgYes_No(strMsg))
			//        return;

			//    if (DataTool.SQLMergeID("Ma_Vt", "R81DMVT", strOldValue, strNewValue))
			//    {
			//        bdsDmVt.RemoveCurrent();
			//        bdsDmVt.Position = bdsDmVt.Find("Ma_Vt", strNewValue);
			//    }
			//}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmVt == null || bdsDmVt.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmVt.Current).Row;
			DataTable dtTemp = dtDmVt.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmVt.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmVt.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmVt_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		protected override void OnClosed(EventArgs e)
		{
			//if (bFind && !this.bIsEnter)
			//    LoadLookupByGroup();

			base.OnClosed(e);
		}


		#endregion 
	}
	
}