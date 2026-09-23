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
    public partial class frmDmNhVtSp : RosyList.frmView
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

		public frmDmNhVtSp()
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
			tlDmNhVt.KeyFieldName = "MA_NH_VT";
			tlDmNhVt.ParentFieldName = "MA_NH_VT_PARENT";
			tlDmNhVt.Dock = DockStyle.Fill;
			tlDmNhVt.strZone = this.bIs_Vt_Sp ? "DMNHVT" : "DMNHSP";
			tlDmNhVt.BuildTreeList(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(tlDmNhVt);
        }

		private void FillData()
		{
			if (bLookupByGroup)
				dtDmNhVt = DataTool.SQLGetDataTable("R81DmNhVt", null, "", null);
			else
				dtDmNhVt = DataTool.SQLGetDataTable("R81DmNhVt", null, this.strLookupKeyFilter, null);
            
			bdsDmNhVt.DataSource = dtDmNhVt;
			bdsDmNhVt.Position = 0;

			bdsDmNhVt.Filter = "Loai_Nh_Vt IN ('SP')";

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

			frmDmNhVt_Edit frmEdit = new frmDmNhVt_Edit();
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

					bdsDmNhVt.Position = bdsDmNhVt.Find("MA_NH_VT", drCurrent["MA_NH_VT"]);
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
            
			if (DataTool.SQLCheckExist("R81DmNhVt", "Ma_Nh_Vt_Parent", drCurrent["Ma_Nh_Vt"]))
            {
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Nhóm vật tư : {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  đang có nhóm con" :
					"Item group: {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  have child group";

				Common.MsgOk(strMsg);
				return;                
            }

            if (DataTool.SQLCheckExist("R81DMVT", "Ma_Nh_Vt", drCurrent["Ma_Nh_Vt"]))
            {

				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Nhóm vật tư : {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  đang có vật tư" :
					"Item group: {" + drCurrent["Ten_Nh_Vt"].ToString() + "}  have item";

				Common.MsgOk(strMsg);
				return;                                
            }

			if (DataTool.SQLDelete("R81DmNhVt", drCurrent))
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
			string strOldValue = (string)drCurrent["Ma_Nh_Vt"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DmNhVt", "Ma_Nh_Vt", "Ten_Nh_Vt", strOldValue, "DMNHVT");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Nh_Vt", "R81DmNhVt", strOldValue, strNewValue))
				{
					bdsDmNhVt.RemoveCurrent();
					bdsDmNhVt.Position = bdsDmNhVt.Find("Ma_Nh_Vt", strNewValue);
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

		public override void  EnterProcess()
		{
			if (bdsDmNhVt.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				if (bLookupByGroup) //Lookup DmDt
				{
					//Hien thi lookup danh muc vat tu
					drCurrent = ((DataRowView)bdsDmNhVt.Current).Row;

					if (this.bIs_Vt_Sp) //Lookup DmVt
					{
						//Hien thi lookup danh muc doi tuong
						frmDmVt frm = new frmDmVt();
						frm.bLookupByGroup = true;
						frm.MdiParent = this.MdiParent;
						frm.strMa_Nh_Vt = ((string)(drCurrent["Ma_Nh_Vt"])).Trim();
						frm.strLookupKeyFilter = this.strLookupKeyFilter;
						frm.strLookupKeyValid = this.strLookupKeyValid;
						frm.isLookup = true;

						frm.LoadLookup();

						if (!frm.bIsEnter)
							return;

						this.drLookup = frm.drLookup;
					}
					else //Lookup DmSp
					{
						//Hien thi lookup danh muc doi tuong
						frmDmVtSp frm = new frmDmVtSp();
						frm.bLookupByGroup = true;
						frm.MdiParent = this.MdiParent;
						frm.strMa_Nh_Vt = ((string)(drCurrent["Ma_Nh_Vt"])).Trim();
						frm.strLookupKeyFilter = this.strLookupKeyFilter;
						frm.strLookupKeyValid = this.strLookupKeyValid;
						frm.isLookup = true;

						frm.LoadLookup();

						if (!frm.bIsEnter)
							return;

						this.drLookup = frm.drLookup;

					}

					this.Close();
				}
				else
				{
					drLookup = ((DataRowView)bdsDmNhVt.Current).Row;
					this.Close();
				}
			}
			else
			{
				//Hien thi danh muc vat tu binh thuong khi nhan Enter				   
				drCurrent = ((DataRowView)bdsDmNhVt.Current).Row;
				if ((string)(drCurrent["Nh_Cuoi"]) == "1")
				{
					if (this.bIs_Vt_Sp)
					{
						frmDmVt frm = new frmDmVt();

						frm.MdiParent = this.MdiParent;
						frm.Load(((string)(drCurrent["Ma_Nh_Vt"])).Trim());
					}
					else
					{
						frmDmVtSp frm = new frmDmVtSp();

						frm.MdiParent = this.MdiParent;
						frm.Load(((string)(drCurrent["Ma_Nh_Vt"])).Trim());
					}
				}
			}
		}		

        #endregion 

        #region Su kien 
        
		void tlDmNhVt_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.EnterProcess();
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMNHVT", dtDmNhVt);
		}

        #endregion 
    }
}