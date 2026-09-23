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

namespace RosyList
{
    public partial class frmDmNhHd : RosyList.frmView
    {
        #region Khai bao bien
        private DataTable dtDmNhHd;
		private DataRow drCurrent;
		private BindingSource bdsDmNhHd = new BindingSource();
		private rsTreeList tlDmNhHd = new rsTreeList();

		public bool bLookupByGroup = false;

        #endregion

		#region Contructor
		public frmDmNhHd()
        {
			InitializeComponent();

			tlDmNhHd.MouseDoubleClick += new MouseEventHandler(tlDmNhHd_MouseDoubleClick);
			btImport.Click +=new EventHandler(btImport_Click);
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
			tlDmNhHd.KeyFieldName = "MA_NH_HD";
			tlDmNhHd.ParentFieldName = "MA_NH_HD_PARENT";
			tlDmNhHd.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(tlDmNhHd);

			tlDmNhHd.strZone = "DMNHHD";
			tlDmNhHd.BuildTreeList(this.isLookup);
        }

		void FillData()
		{
			if (bLookupByGroup)
				dtDmNhHd = DataTool.SQLGetDataTable("R81DmNhHd", null, "", null);
			else
				dtDmNhHd = DataTool.SQLGetDataTable("R81DmNhHd", null, this.strLookupKeyFilter, null);

			bdsDmNhHd.DataSource = dtDmNhHd;
			tlDmNhHd.DataSource = bdsDmNhHd;

            //Uy quyen cho lop co so tim kiem
            bdsSearch = bdsDmNhHd;
			ExportControl = tlDmNhHd;

			if (bdsDmNhHd.Count >= 0)
				bdsDmNhHd.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();
			
			tlDmNhHd.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmNhHd.strZone + "'");
        }

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmNhHd.Rows.Count - 1; i++)
				if (((string)dtDmNhHd.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmNhHd.Position = i;
					break;
				}
		}
		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
        {
            if (bdsDmNhHd.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;            

            //Copy hang hien tai
			if (bdsDmNhHd.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmNhHd.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmNhHd.NewRow();
            
            frmDmNhHd_Edit frmEdit = new frmDmNhHd_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmNhHd.Position >= 0)
						dtDmNhHd.ImportRow(drCurrent);
					else
						dtDmNhHd.Rows.Add(drCurrent);

					bdsDmNhHd.Position = bdsDmNhHd.Find("MA_NH_HD", drCurrent["MA_NH_HD"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmNhHd.Current).Row);					

				dtDmNhHd.AcceptChanges();
			}
			else
				dtDmNhHd.RejectChanges();
        }

        public override void Delete()
        {
            if(bdsDmNhHd.Position < 0)
                return;
            
            DataRow drCurrent = ((DataRowView)bdsDmNhHd.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLCheckExist("R81DmNhHd", "Ma_Nh_Hd_Parent", drCurrent["Ma_Nh_Hd"]))
            {
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Nhóm đối tượng: {" + drCurrent["Ten_Nh_Hd"].ToString() + "}  đang có nhóm con" :
					"Object group: {" + drCurrent["Ten_Nh_Hd"].ToString() + "}  have child object group";

				Common.MsgCancel(strMsg);
                return;
            }

			if (DataTool.SQLCheckExist("R81DmHd", "Ma_Nh_Hd", drCurrent["Ma_Nh_Hd"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Nhóm hợp đồng: {" + drCurrent["Ten_Nh_Hd"].ToString() + "}  đang có hợp đồng" :
					"Contract group : {" + drCurrent["Ten_Nh_Hd"].ToString() + "}  have contract";

				Common.MsgCancel(strMsg);
				return;
			}

			if (DataTool.SQLDelete("R81DmNhHd", drCurrent))
			{
				bdsDmNhHd.RemoveAt(bdsDmNhHd.Position);
				dtDmNhHd.AcceptChanges();
            }
		}

		public override void MergeID()
		{
			if (bdsDmNhHd.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMNHDT", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Contract group code!" : "Bạn không đc cấp quyền Gộp Mã nhóm hợp đồng!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmNhHd.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Nh_Hd"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DmNhHd", "Ma_Nh_Hd", "Ten_Nh_Hd", strOldValue, "DMNHHD");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Nh_Hd", "R81DmNhHd", strOldValue, strNewValue))
				{
					bdsDmNhHd.RemoveCurrent();
					bdsDmNhHd.Position = bdsDmNhHd.Find("Ma_Nh_Hd", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if(bdsDmNhHd == null || bdsDmNhHd.Position < 0)
				return false;

			if (bLookupByGroup)
				return true;

			drCurrent = ((DataRowView)bdsDmNhHd.Current).Row;
			DataTable dtTemp = dtDmNhHd.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}
		
		public override void EnterProcess()
		{
			if (bdsDmNhHd.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				if (bLookupByGroup) //Lookup DmDt
				{
					drCurrent = ((DataRowView)bdsDmNhHd.Current).Row;

					//Hien thi lookup danh muc doi tuong
					frmDmHd frm = new frmDmHd();
					frm.bLookupByGroup = true;
					frm.MdiParent = this.MdiParent;
					frm.strMa_Nh_Hd = ((string)(drCurrent["Ma_Nh_Hd"])).Trim();
					frm.strLookupKeyFilter = this.strLookupKeyFilter;
					frm.strLookupKeyValid = this.strLookupKeyValid;
					frm.isLookup = true;

					frm.LoadLookup();

					if (!frm.bIsEnter)
						return;

					this.drLookup = frm.drLookup;
					this.Close();
				}
				else
				{
					this.drLookup = ((DataRowView)bdsDmNhHd.Current).Row;
					this.Close();
				}
			}
			else
			{
				//Hien thi danh muc doi tuong binh thuong khi nhan Enter				   
				drCurrent = ((DataRowView)bdsDmNhHd.Current).Row;

				if ((string)(drCurrent["Nh_Cuoi"]) == "1")
				{
					frmDmHd frmEdit = new frmDmHd();

					frmEdit.MdiParent = this.MdiParent;
					frmEdit.strLookupKeyFilter = this.strLookupKeyFilter;
					frmEdit.strLookupKeyValid = this.strLookupKeyValid;
					frmEdit.Load(((string)(drCurrent["Ma_Nh_Hd"])).Trim());
					
					////Hien thi lookup danh muc doi tuong
					//frmDmHd frmEdit = new frmDmHd();
					//frmEdit.bLookupByGroup = true;
					//frmEdit.MdiParent = this.MdiParent;
					//frmEdit.strMa_Nh_Hd = ((string)(drCurrent["Ma_Nh_Hd"])).Trim();
					//frmEdit.strLookupKeyFilter = this.strLookupKeyFilter;
					//frmEdit.strLookupKeyValid = this.strLookupKeyValid;
					//frmEdit.isLookup = true;

					//frmEdit.LoadLookup();

					//if (!frmEdit.bIsEnter)
					//    return;

					////this.drLookup = frmEdit.drLookup;
					////this.Close();
				}
			}
		}

        #endregion 

        #region Su kien 
        
		void tlDmNhHd_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.EnterProcess();
		}

		void btImport_Click(object sender, EventArgs e)
		{
			Public.ImportExcel("DMNHHD", dtDmNhHd);
		}

        #endregion 		
    }
}
