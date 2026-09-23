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
    public partial class frmDmNhTb : RosyList.frmView
    {
        #region Khai bao bien

        private DataTable dtDmNhVt;
		private DataRow drCurrent;
		private BindingSource bdsDmNhVt = new BindingSource();
		private rsTreeList tlDmNhVt = new rsTreeList();

		public bool bLookupByGroup = false;
		public bool bIs_Vt_Sp = false;

        #endregion         

		#region Contructor

		public frmDmNhTb()
		{
			InitializeComponent();

			this.tlDmNhVt.MouseDoubleClick += new MouseEventHandler(tlDmNhVt_MouseDoubleClick);
			this.btImport.Click +=new EventHandler(btImport_Click);
		}

		public void Load()
		{
			this.bIs_Vt_Sp = false;

			this.Build();
			this.FillData();
			this.BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public override void LoadLookup()
		{
			this.bIs_Vt_Sp = false;

			this.Load();
		}
		
		#endregion

		#region Build, FillData
		private void Build()
        {
			tlDmNhVt.KeyFieldName = "MA_NH_TB";
			tlDmNhVt.ParentFieldName = "MA_NH_TB_PARENT";
			tlDmNhVt.Dock = DockStyle.Fill;
			tlDmNhVt.strZone = "DMNHTB";
			tlDmNhVt.BuildTreeList(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(tlDmNhVt);
        }

		private void FillData()
		{
			if (bLookupByGroup)
				dtDmNhVt = DataTool.SQLGetDataTable("R06DmNhTb", null, "", null);
			else
				dtDmNhVt = DataTool.SQLGetDataTable("R06DmNhTb", null, this.strLookupKeyFilter, null);
            
			bdsDmNhVt.DataSource = dtDmNhVt;
			bdsDmNhVt.Position = 0;

			tlDmNhVt.DataSource = bdsDmNhVt;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsDmNhVt;
			ExportControl = tlDmNhVt;

			if (this.isLookup)
				this.MoveToLookupValue();

			tlDmNhVt.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmNhVt.strZone + "'");
        }

		private void MoveToLookupValue()
		{
			if (strLookupColumn == string.Empty || strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmNhVt.Rows.Count - 1; i++)
				if (((string)dtDmNhVt.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmNhVt.Position = i;
					break;
				}
		}
		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmNhVt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmNhVt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmNhVt.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmNhVt.NewRow();

			frmDmNhTb_Edit frmEdit = new frmDmNhTb_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmNhVt.Position >= 0)
						dtDmNhVt.ImportRow(drCurrent);
					else
						dtDmNhVt.Rows.Add(drCurrent);

					bdsDmNhVt.Position = bdsDmNhVt.Find("MA_NH_TB", drCurrent["MA_NH_TB"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmNhVt.Current).Row);

				dtDmNhVt.AcceptChanges();
			}
			//else
			//    dtDmNhVt.RejectChanges();
		}

        public override void Delete()
        {
            if(bdsDmNhVt.Position < 0)
                return;

			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}

            DataRow drCurrent = ((DataRowView)bdsDmNhVt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;
            
			if (DataTool.SQLCheckExist("R06DmNhTb", "MA_NH_TB_Parent", drCurrent["MA_NH_TB"]))
            {
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Nhóm vật tư : {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  đang có nhóm con" :
					"Item group: {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  have child group";

				Common.MsgOk(strMsg);
				return;                
            }

            if (DataTool.SQLCheckExist("R81DMVT", "MA_NH_TB", drCurrent["MA_NH_TB"]))
            {

				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Nhóm vật tư : {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  đang có vật tư" :
					"Item group: {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  have item";

				Common.MsgOk(strMsg);
				return;                                
            }

			if (DataTool.SQLDelete("R06DmNhTb", drCurrent))
            {
                bdsDmNhVt.RemoveAt(bdsDmNhVt.Position);
                dtDmNhVt.AcceptChanges();
            }
		}

		public override void MergeID()
		{
			if (bdsDmNhVt.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMNHVT", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Item group code!" : "Bạn không đc cấp quyền Gộp Mã nhóm vật tư, hàng hóa!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmNhVt.Current).Row;
			string strOldValue = (string)drCurrent["MA_NH_TB"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DmNhTb", "MA_NH_TB", "Ten_Nh_Vt", strOldValue, "DMNHVT");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("MA_NH_TB", "R06DmNhTb", strOldValue, strNewValue))
				{
					bdsDmNhVt.RemoveCurrent();
					bdsDmNhVt.Position = bdsDmNhVt.Find("MA_NH_TB", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			drCurrent = ((DataRowView)bdsDmNhVt.Current).Row;

			if (bLookupByGroup && drCurrent["Nh_Cuoi"].ToString() == "0")
				return false;

			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if(bdsDmNhVt == null || bdsDmNhVt.Position < 0)
				return false;

			//if (bLookupByGroup)
			//    return true;

			DataTable dtTemp = dtDmNhVt.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

        public override void EnterProcess()
        {
            if (bdsDmNhVt.Position < 0)
                return;

            //    if (isLookup && EnterValid())
            //    {
            //        if (bLookupByGroup) //Lookup DmDt
            //        {
            //            //Hien thi lookup danh muc vat tu
            //            drCurrent = ((DataRowView)bdsDmNhVt.Current).Row;


            //                //Hien thi lookup danh muc doi tuong
            //                frmDmVt frm = new frmDmVt();
            //                frm.bLookupByGroup = true;
            //                frm.MdiParent = this.MdiParent;
            //                frm.strMA_NH_TB = ((string)(drCurrent["MA_NH_TB"])).Trim();
            //                frm.strLookupKeyFilter = this.strLookupKeyFilter;
            //                frm.strLookupKeyValid = this.strLookupKeyValid;
            //                frm.isLookup = true;

            //                frm.LoadLookup();

            //                if (!frm.bIsEnter)
            //                    return;

            //                this.drLookup = frm.drLookup;
            //            }


            //            this.Close();
            //        }
            //        else
            //        {
            //            drLookup = ((DataRowView)bdsDmNhVt.Current).Row;
            //            this.Close();
            //        }
            //    }
            //    else
            //    {
            //        //Hien thi danh muc vat tu binh thuong khi nhan Enter				   
            //        drCurrent = ((DataRowView)bdsDmNhVt.Current).Row;
            //        if ((string)(drCurrent["Nh_Cuoi"]) == "1")
            //        {
            //            if (this.bIs_Vt_Sp)
            //            {
            //                frmDmVt frm = new frmDmVt();

            //                frm.MdiParent = this.MdiParent;
            //                frm.Load(((string)(drCurrent["MA_NH_TB"])).Trim());
            //            }
            //            else
            //            {
            //                frmDmVtSp frm = new frmDmVtSp();

            //                frm.MdiParent = this.MdiParent;
            //                frm.Load(((string)(drCurrent["MA_NH_TB"])).Trim());
            //            }
            //        }
            //    }
            //}		
        }
        #endregion 

        #region Su kien 
        
		void tlDmNhVt_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.EnterProcess();
		}

		void btImport_Click(object sender, EventArgs e)
		{
            //RosySystem.Public.Public.ImportExcel("DMNHVT", dtDmNhVt);
		}

        #endregion 
    }
}