using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Public;

namespace RosyModule.HRM
{
	public partial class frmDinhMucMonAn : RosyList.frmView
	{
		#region Khai bao bien

		private DataTable dtDmDt;
		private DataRow drCurrent;
		private BindingSource bdsDmDt = new BindingSource();
		private rsDataGridView dgvDmDt = new rsDataGridView();

		public string strMa_Nh_Dt = string.Empty;
		public bool bLookupByGroup = false;
		public bool bFind = false;

		#endregion 

		#region Contructor
        public frmDinhMucMonAn()
		{
			InitializeComponent();

			this.dgvDmDt.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmDt_CellMouseDoubleClick);
			this.btImport.Click +=new EventHandler(btImport_Click);
		}

		public override void Load()
		{
			this.Load("");
		}

		public void Load(string strMa_Nh_Dt)
		{
			this.strMa_Nh_Dt = strMa_Nh_Dt;

			Build();
			FillData();
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

        //public override void LoadLookup()
        //{
        //    if (!bLookupByGroup && Parameters.GetParaValue("ACCESS_DMDT").ToString() == "1") //Truy cap theo nhom
        //    {
        //        string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

        //        if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
        //        {
        //            if (this.strLookupValue == "/" || this.strLookupValue == @"\")
        //                strWhere = strLookupKeyFilter;
        //            else
        //                strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
        //        }

        //        DataTable dtFind = DataTool.SQLGetDataTable("R81DmDt", null, strWhere, null);

        //        if (dtFind.Rows.Count > 0)
        //        {
        //            strLookupKeyFilter = strWhere;
        //            bFind = true;
        //            this.Load();
        //        }
        //        else
        //            this.LoadLookupByGroup();
        //    }
        //    else
        //        this.Load(this.strMa_Nh_Dt);
        //}

        //private void LoadLookupByGroup()
        //{//Lookup danh muc doi tuong theo nhom

        //    frmDmNhDt frm = new frmDmNhDt();
        //    frm.bLookupByGroup = true;
        //    frm.isLookup = true;
        //    frm.strLookupKeyFilter = this.strLookupKeyFilter;
        //    frm.strLookupKeyValid = this.strLookupKeyValid;
        //    frm.bLookupRequire = this.bLookupRequire;

        //    //frm.strLookupKeyValid += (frm.strLookupKeyValid != "" ? "" : " AND ") + " (Nh_Cuoi = 1)";

        //    frm.LoadLookup();

        //    this.bIsEnter = frm.bIsEnter;
        //    this.drLookup = frm.drLookup;
        //    this.Close();
        //}

		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDmDt.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvDmDt);

			dgvDmDt.strZone = "DINHMUCMONAN";
			dgvDmDt.BuildGridView(this.isLookup);

			ExportControl = dgvDmDt;
		}

		private void FillData()
		{
			string strKey = string.Empty;
			if (this.isLookup)
			{
				strKey = (this.strLookupKeyFilter == null ? string.Empty : this.strLookupKeyFilter);

				if (bLookupByGroup)
				{
					if (strKey == string.Empty)
						strKey = "(T1.Ma_MAn = '" + strMa_Nh_Dt + "')";
					else
                        strKey = "(" + strKey + ") AND (T1.Ma_MAn = '" + strMa_Nh_Dt + "')";
				}
			}
			else
                strKey = (strMa_Nh_Dt == string.Empty ? string.Empty : "T1.Ma_MAn = '" + strMa_Nh_Dt + "'");

//            //Hải kiểm tra đối tượng: dùng chung danh mục với CRM
//            DataTable dtDmDtCheck = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM R81DmDt WHERE 0 = 1");
//            if (dtDmDtCheck.Columns.Contains("Deleted"))
//                strKey += (strKey == string.Empty ? string.Empty : " AND ") + "(Deleted <> 1)";

//            //Hải chỉ show những dữ liệu cần thiết có khai báo trong Zone, Column
//            string strSQLExec = @"
//				DECLARE @_ColumnList NVARCHAR(1000) 
//				SET @_ColumnList = ''
//				SELECT @_ColumnList = @_ColumnList + ',' + Column_ID FROM R00Column WHERE Zone = '" + dgvDmDt.strZone + @"'
//				SELECT CASE WHEN LEN(@_ColumnList) > 0 THEN RIGHT(@_ColumnList, LEN(@_ColumnList)-1) ELSE '' END ";
//            string strFieldList = SQLExec.ExecuteReturnValue(strSQLExec).ToString();

            //if (strFieldList != string.Empty)
            dtDmDt = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Ten_MAn, T3.Ten_Vt, T3.Dvt FROM R09DMMONAN T1 LEFT JOIN R81DMMONAN T2 ON T1.Ma_MAn = T2.Ma_MAn LEFT JOIN (SELECT Ma_Vt, Ten_Vt, Dvt FROM R81DMVT) T3 ON T1.Ma_Vt = T3.Ma_Vt WHERE " + strKey);
            //else
            //    dtDmDt = DataTool.SQLGetDataTable("R81DMDT", null, strKey, "Ma_Dt");

			bdsDmDt.DataSource = dtDmDt;
			dgvDmDt.DataSource = bdsDmDt;

			if (bdsDmDt.Count >= 0)
				bdsDmDt.Position = 0;//Vi tri mac dinh

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmDt;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == String.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmDt.Rows.Count - 1; i++)
				if (((string)dtDmDt.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmDt.Position = i;
					break;
				}
		}
		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmDt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			if (bdsDmDt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmDt.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmDt.NewRow();
				drCurrent["Ma_MAn"] = strMa_Nh_Dt;
			}

          
            frmDinhMucMonAn_Edit frmEdit = new frmDinhMucMonAn_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

                // người dùng chọn chấp nhận
                if (frmEdit.isAccept)
                {
                    if (enuNew_Edit == enuEdit.New)
                    {
                        if (bdsDmDt.Position >= 0)
                            dtDmDt.ImportRow(drCurrent);
                        else
                            dtDmDt.Rows.Add(drCurrent);

                        bdsDmDt.Position = bdsDmDt.Find("Ident00", drCurrent["Ident00"]);

                    }
                    else
                    {
                        Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmDt.Current).Row);
                    }
                    drCurrent["Ten_Vt"] = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", drCurrent["Ma_Vt"].ToString());
                    //dtDmDt.AcceptChanges();
                    drCurrent.AcceptChanges();
                }
                else
                    //dtDmDt.RejectChanges();
                    drCurrent.RejectChanges();
            
           
		}
		
		public override void Delete()
		{
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}

			if (bdsDmDt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmDt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R09DMMONAN", drCurrent))
			{
				bdsDmDt.RemoveAt(bdsDmDt.Position);
				dtDmDt.AcceptChanges();
			}
		}

		public override void MergeID()
		{
            //if(bdsDmDt.Count <= 0)
            //    return;

            //if (!Common.CheckPermission("MERGE_DMDT", enuPermission_Type.Allow_Access))
            //{
            //    string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Customer code!" : "Bạn không đc cấp quyền Gộp Mã đối tượng!";
            //    Common.MsgCancel(strMsg);
            //    return;
            //}

            //drCurrent = ((DataRowView)bdsDmDt.Current).Row;
            //string strOldValue = (string)drCurrent["Ma_Dt"];

            //frmMergeID frm = new frmMergeID();

            //frm.Load("R81DMDT", "Ma_Dt", "Ten_Dt", strOldValue, "DMDT");			

            //if (frm.isAccept)
            //{
            //    string strNewValue = frm.strNewValue;
            //    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Are you sure to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
            //    if (!Common.MsgYes_No(strMsg))
            //        return;

            //    if (DataTool.SQLMergeID("Ma_Dt", "R81DMDT", strOldValue, strNewValue))
            //    {
            //        bdsDmDt.RemoveCurrent();
            //        bdsDmDt.Position = bdsDmDt.Find("MA_DT", strNewValue);
            //    }
            //}
		}

		#endregion

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmDt == null || bdsDmDt.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmDt.Current).Row;
			DataTable dtTemp = dtDmDt.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void  EnterProcess()
		{
			if (bdsDmDt.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmDt.Current).Row;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmDt.Current).Row;
				this.Close();
			}
			
		}

		#endregion 

		#region Su kien

		void dgvDmDt_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			Public.ImportExcel("DMDT", dtDmDt);
		}

        //protected override void OnClosed(EventArgs e)
        //{
        //    if (bFind && !this.bIsEnter)
        //        LoadLookupByGroup();

        //    base.OnClosed(e);
        //}
		
		#endregion 
	}
}