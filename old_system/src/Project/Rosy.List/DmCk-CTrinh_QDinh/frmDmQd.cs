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
using System.Collections;

namespace RosyList
{
	public partial class frmDmQd : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmQd;
		DataRow drCurrent;
		BindingSource bdsDmQd = new BindingSource();
		rsDataGridView dgvDmQd = new rsDataGridView();
        public bool bLookupByGroup = false;
		public bool bFind = false;
		public string strLoai_Qd = "0"; //0-QD giá bán, 1-QD chiết khấu (chưa dùng), 2-QD giá mua
		#endregion

		#region Contructor

		public frmDmQd()
		{
			InitializeComponent(); 

			this.dgvDmQd.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmQd_CellMouseDoubleClick);
			this.btImport.Click +=new EventHandler(btImport_Click);
		}

		public override void Load()
		{
			
			Build();
			FillData("0");
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}
		public void Load(string strLoai_Qd)
		{

			this.strLoai_Qd = strLoai_Qd;

			
			Build();
			FillData(strLoai_Qd);
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
			string strZone = "DMQD";
			if(strLoai_Qd =="2")
				strZone = "DMQDMUA";

			dgvDmQd.Dock = DockStyle.Fill;
			dgvDmQd.strZone = strZone;
			dgvDmQd.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmQd);
		}
		
		private void FillData(string strLoai_Qd)
		{
			string strSQLExec = string.Empty;
            string strKey = strKey = (this.strLookupKeyFilter == null ? string.Empty : this.strLookupKeyFilter);

			
			if (this.strLookupKeyFilter == null || this.strLookupKeyFilter == string.Empty)
			{
				strKey = "Loai_Qd = '"+strLoai_Qd+"'";
				strSQLExec = "SELECT T1.*, T2.Ten_CTrinh, T3.Ten_Dt FROM R81DMQD T1 " +
					" LEFT JOIN R81DmCTrinh T2 ON T1.Ma_CTrinh = T2.Ma_CTrinh" +
						" LEFT JOIN R81DmDt T3 ON (T1.Ma_Dt = T3.Ma_Dt OR T1.Ma_Dt_Chung = T3.Ma_dt) WHERE " + strKey  +
						"ORDER BY Ngay_Qd DESC,SO_QD DESC";
			}
			else
				strSQLExec = "SELECT T1.*, T2.Ten_CTrinh, T3.Ten_Dt FROM R81DMQD T1 " +
					" LEFT JOIN R81DmCTrinh T2 ON T1.Ma_CTrinh = T2.Ma_CTrinh" +
						" LEFT JOIN R81DmDt T3 ON (T1.Ma_Dt = T3.Ma_Dt OR T1.Ma_Dt_Chung = T3.Ma_dt)" +
						" WHERE " + strKey +
						"ORDER BY Ngay_Qd DESC,SO_QD DESC";
			
			
			dtDmQd = SQLExec.ExecuteReturnDt(strSQLExec);
			//dtDmQd = DataTool.SQLGetDataTable("R81DMQD", null, null, null);

			bdsDmQd.DataSource = dtDmQd;
			dgvDmQd.DataSource = bdsDmQd;
			bdsDmQd.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmQd;
			ExportControl = dgvDmQd;

			if (this.isLookup)
				this.MoveToLookupValue();
		}
		public void Load(DataRow drCurrent)
		{
			this.drCurrent = drCurrent;

			Build();
			FillData_QD();
			BindingLanguage();
			this.ShowDialog();
		}

		private void FillData_QD()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT", Convert.ToDateTime(drCurrent["Ngay_Ct"]));
			htPara.Add("MA_KHO", drCurrent["Ma_Kho"].ToString().Trim());
			htPara.Add("MA_CTRINH", drCurrent["Ma_CTrinh"].ToString().Trim());
			htPara.Add("MA_DT", drCurrent["Ma_Dt"].ToString().Trim());
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtDmQd = SQLExec.ExecuteReturnDt("sp_Get_SO_QD", htPara, CommandType.StoredProcedure);

			bdsDmQd.DataSource = dtDmQd;
			dgvDmQd.DataSource = bdsDmQd;
			bdsDmQd.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmQd;
			ExportControl = dgvDmQd;

		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmQd.Rows.Count - 1; i++)
				if (((string)dtDmQd.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmQd.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmQd.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Edit"));
				return;
			}

			//Copy hang hien tai            
			if (bdsDmQd.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmQd.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmQd.NewRow();
			if (strLoai_Qd != "2")
			{
				frmDmQd_Edit frmEdit = new frmDmQd_Edit();
				frmEdit.Load(enuNew_Edit, drCurrent);
				// người dùng chọn chấp nhận
				if (frmEdit.isAccept)
				{
					if (enuNew_Edit == enuEdit.New)
					{
						if (bdsDmQd.Position >= 0)
							dtDmQd.ImportRow(drCurrent);
						else
							dtDmQd.Rows.Add(drCurrent);

						bdsDmQd.Position = bdsDmQd.Find("SO_QD", drCurrent["SO_QD"]);
					}
					else
						Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmQd.Current).Row);

					dtDmQd.AcceptChanges();
				}
				else
					dtDmQd.RejectChanges();
			}
			else
            {
				frmDmQdMua_Edit frmEdit1 = new frmDmQdMua_Edit();
				frmEdit1.Load(enuNew_Edit, drCurrent);
				// người dùng chọn chấp nhận
				if (frmEdit1.isAccept)
				{
					if (enuNew_Edit == enuEdit.New)
					{
						if (bdsDmQd.Position >= 0)
							dtDmQd.ImportRow(drCurrent);
						else
							dtDmQd.Rows.Add(drCurrent);

						bdsDmQd.Position = bdsDmQd.Find("SO_QD", drCurrent["SO_QD"]);
					}
					else
						Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmQd.Current).Row);

					dtDmQd.AcceptChanges();
				}
				else
					dtDmQd.RejectChanges();
			}
		
			
		}

		public override void Delete()
		{
			if (bdsDmQd.Position < 0)
				return;

			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmQd.Current).Row;

			//if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
			//    return;
		
			if (DataTool.SQLDelete("R81DMQD", drCurrent))
			{
				bdsDmQd.RemoveAt(bdsDmQd.Position);
				dtDmQd.AcceptChanges();
			}
		}

        //public override void MergeID()
        //{
        //    if (bdsDmQd.Count <= 0)
        //        return;

        //    if (!Common.CheckPermission("MERGE_DMQD", enuPermission_Type.Allow_Access))
        //    {
        //        string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Warehouse code!" : "Bạn không đc cấp quyền Gộp Mã kho!";
        //        Common.MsgCancel(strMsg);
        //        return;
        //    }

        //    drCurrent = ((DataRowView)bdsDmQd.Current).Row;
        //    string strOldValue = (string)drCurrent["SO_QD"];

        //    frmMergeID frm = new frmMergeID();

        //    frm.Load("R81DMQD", "SO_QD", "Ten_Kho", strOldValue, "DMQD");

        //    if (frm.isAccept)
        //    {
        //        string strNewValue = frm.strNewValue;
        //        string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
        //        if (!Common.MsgYes_No(strMsg))
        //            return;

        //        if (DataTool.SQLMergeID("SO_QD", "R81DMQD", strOldValue, strNewValue))
        //        {
        //            bdsDmQd.RemoveCurrent();
        //            bdsDmQd.Position = bdsDmQd.Find("SO_QD", strNewValue);
        //        }
        //    }
        //}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmQd == null || bdsDmQd.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmQd.Current).Row;
			DataTable dtTemp = dtDmQd.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void EnterProcess()
		{
			if (bdsDmQd.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmQd.Current).Row;
				this.Close();
			}
			else if (EnterValid())
			{
				//drLookup = ((DataRowView)bdsDmQd.Current).Row;
				//this.Close();
				Detail();

			}
		}
		//    public override void EnterProcess()
		//{
		//    Detail();
		//}

		private void Detail()
		{
			drCurrent = ((DataRowView)bdsDmQd.Current).Row;

			if(strLoai_Qd != "2")
			{ 
				frmCSGia  frmDetail = new frmCSGia();
				frmDetail.MdiParent = this.MdiParent;
				frmDetail.Load("B", (string)drCurrent["So_QD"]);
			}
			else
            {
				frmCSGiaMuaPL frmDetail = new frmCSGiaMuaPL();
				frmDetail.MdiParent = this.MdiParent;
				frmDetail.Load("M", (string)drCurrent["So_QD"]);
			}
			//	this.UpdateTotal(drCurrent);
		}

		#endregion 

		#region Su kien

		void dgvDmQd_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMQD", dtDmQd);
		}

		#endregion 


	}
}