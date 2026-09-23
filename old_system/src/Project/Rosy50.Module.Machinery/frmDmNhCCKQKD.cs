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
using RosySystem.Element;
using RosySystem;
using RosySystem.Public;
using RosyList;

namespace RosyModule.Machinery
{
    public partial class frmDmNhCCKQKD : RosyList.frmView
    {
        #region Khai bao bien
        private DataTable dtDmNhDt;
		private DataRow drCurrent;
		private BindingSource bdsDmNhDt = new BindingSource();
		private rsTreeList tlDmNhDt = new rsTreeList();

		public bool bLookupByGroup = false;
		
        #endregion         

		#region Contructor
        public frmDmNhCCKQKD()
        {
			InitializeComponent();

			this.tlDmNhDt.MouseDoubleClick += new MouseEventHandler(tlDmNhDt_MouseDoubleClick);
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

		public override void LoadLookup()
		{
			this.isLookup = true;
			this.Load();
		}

		#endregion

		#region Build, FillData
		void Build()
        {
			tlDmNhDt.KeyFieldName = "MA_NH_CC";
			tlDmNhDt.ParentFieldName = "MA_NH_CC_PARENT";
			tlDmNhDt.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(tlDmNhDt);

            tlDmNhDt.strZone = "DMNHCCKQKD";
			tlDmNhDt.BuildTreeList(this.isLookup);
        }

		void FillData()
        {
			if (bLookupByGroup)
                dtDmNhDt = DataTool.SQLGetDataTable("R81DMNHCCKQKD", null, "", null);
			else
                dtDmNhDt = DataTool.SQLGetDataTable("R81DMNHCCKQKD", null, this.strLookupKeyFilter, null);

			bdsDmNhDt.DataSource = dtDmNhDt;
			tlDmNhDt.DataSource = bdsDmNhDt;

			//bdsDmNhDt.Filter = "Loai_Nh_Dt IN ('KH', 'NCC', 'CH')";

            //Uy quyen cho lop co so tim kiem
            bdsSearch = bdsDmNhDt;
			ExportControl = tlDmNhDt;

			if (bdsDmNhDt.Count >= 0)
				bdsDmNhDt.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();
			
			tlDmNhDt.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmNhDt.strZone + "'");
        }

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmNhDt.Rows.Count - 1; i++)
				if (((string)dtDmNhDt.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmNhDt.Position = i;
					break;
				}
		}
		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
        {
            if (bdsDmNhDt.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;            

            //Copy hang hien tai
			if (bdsDmNhDt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmNhDt.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmNhDt.NewRow();

            frmDmNhCCKQKD_Edit frmEdit = new frmDmNhCCKQKD_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmNhDt.Position >= 0)
						dtDmNhDt.ImportRow(drCurrent);
					else
						dtDmNhDt.Rows.Add(drCurrent);

					bdsDmNhDt.Position = bdsDmNhDt.Find("MA_NH_CC", drCurrent["MA_NH_CC"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmNhDt.Current).Row);					

				dtDmNhDt.AcceptChanges();
			}
			else
				dtDmNhDt.RejectChanges();
        }

        public override void Delete()
        {
            if(bdsDmNhDt.Position < 0)
                return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
            DataRow drCurrent = ((DataRowView)bdsDmNhDt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLCheckExist("R81DMNHCCKQKD", "Ma_Nh_CC_Parent", drCurrent["Ma_Nh_CC"]))
            {
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Nhóm CC - KQKD: {" + drCurrent["Ten_Nh_CC"].ToString() + "}  đang có nhóm con" :
					"Object group: {" + drCurrent["Ten_Nh_CC"].ToString() + "}  have child object group";

				Common.MsgCancel(strMsg);
                return;
            }

            if (DataTool.SQLCheckExist("R81DMNHCCKQKD", "Ma_Nh_CC", drCurrent["Ma_Nh_CC"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Nhóm CC- KQKD: {" + drCurrent["Ten_Nh_CC"].ToString() + "}  đang có đối tượng" :
					"Object group : {" + drCurrent["Ten_Nh_CC"].ToString() + "}  have object";

				Common.MsgCancel(strMsg);
				return;
			}

            if (DataTool.SQLDelete("R81DMNHCCKQKD", drCurrent))
			{
				bdsDmNhDt.RemoveAt(bdsDmNhDt.Position);
				dtDmNhDt.AcceptChanges();
            }
		}

		public override void MergeID()
		{
            //if (bdsDmNhDt.Count <= 0)
            //    return;

            //if (!Common.CheckPermission("MERGE_DMNHTB", enuPermission_Type.Allow_Access))
            //{
            //    string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Customer group code!" : "Bạn không đc cấp quyền Gộp Mã nhóm đối tượng!";
            //    Common.MsgCancel(strMsg);
            //    return;
            //}

            //drCurrent = ((DataRowView)bdsDmNhDt.Current).Row;
            //string strOldValue = (string)drCurrent["Ma_Nh_Tb"];

            //frmMergeID frm = new frmMergeID();

            //frm.Load("R06DMNHTB", "Ma_Nh_Tb", "Ten_Nh_Tb", strOldValue, "DMNHTB");

            //if (frm.isAccept)
            //{
            //    string strNewValue = frm.strNewValue;
            //    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
            //    if (!Common.MsgYes_No(strMsg))
            //        return;

            //    if (DataTool.SQLMergeID("Ma_Nh_tB", "R06DMNHTB", strOldValue, strNewValue))
            //    {
            //        bdsDmNhDt.RemoveCurrent();
            //        bdsDmNhDt.Position = bdsDmNhDt.Find("Ma_Nh_tB", strNewValue);
            //    }
            //}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			drCurrent = ((DataRowView)bdsDmNhDt.Current).Row;

			if (bLookupByGroup && drCurrent["Nh_Cuoi"].ToString() == "0")
				return false;

			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if(bdsDmNhDt == null || bdsDmNhDt.Position < 0)
				return false;

			//if (bLookupByGroup)
			//    return true;

			DataTable dtTemp = dtDmNhDt.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}
		
		public override void EnterProcess()
		{
			if (bdsDmNhDt.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				if (bLookupByGroup) //Lookup DmDt
				{
					drCurrent = ((DataRowView)bdsDmNhDt.Current).Row;

					//Hien thi lookup danh muc doi tuong
					frmDmTb frm = new frmDmTb();
					frm.bLookupByGroup = true;
					frm.MdiParent = this.MdiParent;
					frm.strMa_Nh_Tb = ((string)(drCurrent["Ma_Nh_CC"])).Trim();
					frm.strLookupKeyFilter = this.strLookupKeyFilter;
					frm.strLookupKeyValid = this.strLookupKeyValid;
					frm.isLookup = true;

					frm.LoadLookup();

					if (!frm.bIsEnter)
						return;

					this.drLookup = frm.drLookup;
					this.Close();
				}
				else //Lookup DmNhDt
				{
					this.drLookup = ((DataRowView)bdsDmNhDt.Current).Row;
					this.Close();
				}
			}
			else
			{
				//Hien thi danh muc doi tuong binh thuong khi nhan Enter				   
				drCurrent = ((DataRowView)bdsDmNhDt.Current).Row;
				if ((string)(drCurrent["Nh_Cuoi"]) == "1")
				{
					frmDmTb frmEdit = new frmDmTb();

					frmEdit.MdiParent = this.MdiParent;
					frmEdit.Load(((string)(drCurrent["Ma_Nh_CC"])).Trim());
				}
			}
		}

        #endregion 

        #region Su kien 
        
		void tlDmNhDt_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.EnterProcess();
		}

		void btImport_Click(object sender, EventArgs e)
		{
            //RosySystem.Public.Public.ImportExcel("DMNHTB", dtDmNhDt);
		}

        #endregion 		
    }
}