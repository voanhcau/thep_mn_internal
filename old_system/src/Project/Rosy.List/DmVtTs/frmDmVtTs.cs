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
	public partial class frmDmVtTs : RosyList.frmView
	{
		#region Khai bao bien

		private DataTable dtDmVtTs;
		private DataRow drCurrent;
		private BindingSource bdsDmVtTs = new BindingSource();
		private rsDataGridView dgvDmVtTs = new rsDataGridView();

		public string strLoai_Nh_Vt = "TS";
		public string strMa_Nh_Vt = "";
		public bool bLookupByGroup = false;
		public bool bFind = false;

		#endregion 

		#region Contructor
		public frmDmVtTs()
		{
			InitializeComponent();

			this.dgvDmVtTs.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmSp_CellMouseDoubleClick);
			this.btImport.Click +=new EventHandler(btImport_Click);
		}

		public override void Load()
		{
			this.Object_ID = "DM" + this.strLoai_Nh_Vt;

			Build();
			FillData();
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public void Load(string strLoai_Nh_Vt, string strMa_Nh_Vt)
		{
			this.strLoai_Nh_Vt = strLoai_Nh_Vt;
			this.strMa_Nh_Vt = strMa_Nh_Vt;

			this.Load();
		}

		public override void LoadLookup()
		{
			if (!bLookupByGroup && ((string)Parameters.GetParaValue("ACCESS_DmSp")).Trim() == "1")
			{
				string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

				if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
				{
					if (this.strLookupValue == "/" || this.strLookupValue == @"\")
						strWhere = strLookupKeyFilter;
					else
						strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
				}

				DataTable dtFind = DataTool.SQLGetDataTable("R81DmVt", null, strWhere, null);

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
				this.Load(this.strLoai_Nh_Vt, this.strMa_Nh_Vt);
		}

		private void LoadLookupByGroup()
		{//Lookup theo nhom

			frmDmNhVtTs frm = new frmDmNhVtTs();
			frm.bLookupByGroup = true;
			frm.isLookup = true;
			frm.strLookupKeyFilter = this.strLookupKeyFilter;
			frm.strLookupKeyValid = this.strLookupKeyValid;
			frm.bLookupRequire = this.bLookupRequire;

			frm.LoadLookup(strLoai_Nh_Vt);

			this.bIsEnter = frm.bIsEnter;
			this.drLookup = frm.drLookup;
			this.Close();
		}

		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDmVtTs.Dock = DockStyle.Fill;
			dgvDmVtTs.strZone = "DMVTTS";
			dgvDmVtTs.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmVtTs);

			
		}
		private void Language()
		{
			
			if (dgvDmVtTs.Columns.Contains("THONG_SO_KT"))
				dgvDmVtTs.Columns["THONG_SO_KT"].HeaderText = "Ghi chú";
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
						strKey = "(Ma_Nh_Vt = '" + strMa_Nh_Vt + "')";
					else
						strKey = "(" + strKey + ") AND (Ma_Nh_Vt = '" + strMa_Nh_Vt + "')";
				}
			}
			else
				strKey = (strMa_Nh_Vt == string.Empty ? string.Empty : "Ma_Nh_Vt = '" + strMa_Nh_Vt + "'");

			if (strMa_Nh_Vt == "")
				strKey = (strKey == "" ? "" : strKey + " AND ") + " (Ma_Nh_Vt IN (SELECT Ma_Nh_Vt FROM R81DmNhVt WHERE Loai_Nh_Vt IN ('" + this.strLoai_Nh_Vt + "')))";

			dtDmVtTs = DataTool.SQLGetDataTable("R81DmVt", null, strKey, "Ma_Vt");

			bdsDmVtTs.DataSource = dtDmVtTs;
			dgvDmVtTs.DataSource = bdsDmVtTs;
			bdsDmVtTs.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmVtTs;
			ExportControl = dgvDmVtTs;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmVtTs.Rows.Count - 1; i++)
				if (((string)dtDmVtTs.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmVtTs.Position = i;
					break;
				}
		}
		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmVtTs.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmVtTs.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmVtTs.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmVtTs.NewRow();
				drCurrent["Ma_Nh_Vt"] = strMa_Nh_Vt;
			}

			frmDmVtTs_Edit frmEdit = new frmDmVtTs_Edit();
			frmEdit.Object_ID = this.Object_ID;
			frmEdit.Load(enuNew_Edit, drCurrent);
			
			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmVtTs.Position >= 0)
						dtDmVtTs.ImportRow(drCurrent);
					else
					{
						dtDmVtTs.Rows.Add(drCurrent);
						drCurrent["Ma_Nh_Vt"] = strMa_Nh_Vt;
					}

					bdsDmVtTs.Position = bdsDmVtTs.Find("MA_VT", drCurrent["MA_VT"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmVtTs.Current).Row);

				dtDmVtTs.AcceptChanges();
			}
			else
				dtDmVtTs.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmVtTs.Position < 0)
				return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmVtTs.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;			

			if (DataTool.SQLDelete("R81DmVt", drCurrent))
			{
				bdsDmVtTs.RemoveAt(bdsDmVtTs.Position);
				dtDmVtTs.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsDmVtTs.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMVT", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Item code!" : "Bạn không đc cấp quyền Gộp Mã vật tư, hàng hóa!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmVtTs.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Vt"];

			RosyList.frmMergeID frm = new RosyList.frmMergeID();

			frm.Load("R81DmVt", "Ma_Vt", "Ten_Vt", strOldValue, "DMVT");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Vt", "R81DmVt", strOldValue, strNewValue))
				{
					bdsDmVtTs.RemoveCurrent();
					bdsDmVtTs.Position = bdsDmVtTs.Find("Ma_Vt", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmVtTs == null || bdsDmVtTs.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmVtTs.Current).Row;
			DataTable dtTemp = dtDmVtTs.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmVtTs.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmVtTs.Current).Row;
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
			RosySystem.Public.Public.ImportExcel("DMVT", dtDmVtTs);
		}

		#endregion
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			Language();
		}
	}
	
}