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
using RosyList;

namespace RosyModule.Machinery
{
	public partial class frmDmTb : RosyList.frmView
	{
		#region Khai bao bien

		private DataTable dtDmDt;
		private DataRow drCurrent;
		private BindingSource bdsDmDt = new BindingSource();
		private rsDataGridView dgvDmDt = new rsDataGridView();

		public string strMa_Nh_Tb = string.Empty;
		public bool bLookupByGroup = false;
		public bool bFind = false;

		#endregion 

		#region Contructor
		public frmDmTb()
		{
			InitializeComponent();

			this.dgvDmDt.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmDt_CellMouseDoubleClick);
			this.btImport.Click +=new EventHandler(btImport_Click);
		}

		public override void Load()
		{
			this.Load("");
		}

		public void Load(string strMa_Nh_Tb)
		{
			this.strMa_Nh_Tb = strMa_Nh_Tb;

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
			if (!bLookupByGroup && Parameters.GetParaValue("ACCESS_DMTB").ToString() == "1") //Truy cap theo nhom
			{
				string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

				if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
				{
					if (this.strLookupValue == "/" || this.strLookupValue == @"\")
						strWhere = strLookupKeyFilter;
					else
						strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
				}

				DataTable dtFind = DataTool.SQLGetDataTable("R06DMTB", null, strWhere, null);

				if (dtFind.Rows.Count > 0)
				{
					strLookupKeyFilter = strWhere;
					bFind = true;
					this.Load();
				}
				else
					this.LoadLookupByGroup();
			}
			else
				this.Load(this.strMa_Nh_Tb);
		}

		private void LoadLookupByGroup()
		{//Lookup danh muc doi tuong theo nhom

			frmDmNhTb frm = new frmDmNhTb();
			frm.bLookupByGroup = true;
			frm.isLookup = true;
			frm.strLookupKeyFilter = this.strLookupKeyFilter;
			frm.strLookupKeyValid = this.strLookupKeyValid;
			frm.bLookupRequire = this.bLookupRequire;

			//frm.strLookupKeyValid += (frm.strLookupKeyValid != "" ? "" : " AND ") + " (Nh_Cuoi = 1)";

			frm.LoadLookup();

			this.bIsEnter = frm.bIsEnter;
			this.drLookup = frm.drLookup;
			this.Close();
		}

		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDmDt.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvDmDt);

			dgvDmDt.strZone = "DMTB";
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
						strKey = "(Ma_Nh_Tb = '" + strMa_Nh_Tb + "')";
					else
						strKey = "(" + strKey + ") AND (Ma_Nh_Tb = '" + strMa_Nh_Tb + "')";

                    
				}
			}
			else
				strKey = (strMa_Nh_Tb == string.Empty ? string.Empty : "Ma_Nh_Tb = '" + strMa_Nh_Tb + "'");

            if (strKey != string.Empty)
                strKey += " AND Ngay_Kt_Sd = '19000101'";

			dtDmDt = DataTool.SQLGetDataTable("R06DMTB", null, strKey, "Ma_Tb");

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
				drCurrent["Ma_Nh_Tb"] = strMa_Nh_Tb;
			}


                frmMachineryCT_Edit frmEdit = new frmMachineryCT_Edit();
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

						bdsDmDt.Position = bdsDmDt.Find("MA_TB", drCurrent["MA_TB"]);
					}
					else
					{
						Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmDt.Current).Row);
					}

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

            if (DataTool.SQLDelete("R06DMTB", drCurrent))
			{
				bdsDmDt.RemoveAt(bdsDmDt.Position);
				dtDmDt.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if(bdsDmDt.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMDT", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Customer code!" : "Bạn không đc cấp quyền Gộp Mã đối tượng!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmDt.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Tb"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R06DMTB", "Ma_Tb", "Ten_Tb", strOldValue, "DMTB");			

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Are you sure to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

                if (DataTool.SQLMergeID("Ma_Tb", "R06DMTB", strOldValue, strNewValue))
				{
					bdsDmDt.RemoveCurrent();
					bdsDmDt.Position = bdsDmDt.Find("MA_TB", strNewValue);
				}
			}
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
			Public.ImportExcel("DMTB", dtDmDt);
		}

		protected override void OnClosed(EventArgs e)
		{
			if (bFind && !this.bIsEnter)
				LoadLookupByGroup();

			base.OnClosed(e);
		}
		
		#endregion 
	}
}