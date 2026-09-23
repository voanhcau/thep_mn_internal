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
	public partial class frmDmVtSp : RosyList.frmView
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
		public frmDmVtSp()
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
			if (!bLookupByGroup && ((string)Parameters.GetParaValue("ACCESS_DMSP")).Trim() == "1")
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
				this.Load(this.strMa_Nh_Vt);
		}

		private void LoadLookupByGroup()
		{//Lookup theo nhom

			frmDmNhVtSp frm = new frmDmNhVtSp();
			frm.bLookupByGroup = true;
			frm.isLookup = true;
			frm.strLookupKeyFilter = this.strLookupKeyFilter;
			frm.strLookupKeyValid = this.strLookupKeyValid;
			frm.bLookupRequire = this.bLookupRequire;

			frm.LoadLookup();

			this.bIsEnter = frm.bIsEnter;
			this.drLookup = frm.drLookup;
			this.Close();
		}

		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDmVtSp.Dock = DockStyle.Fill;
			dgvDmVtSp.strZone = "DMSP";
			dgvDmVtSp.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmVtSp);
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
				strKey = (strKey == "" ? "" : strKey + " AND ") + " (Ma_Nh_Vt IN (SELECT Ma_Nh_Vt FROM R81DmNhVt WHERE Loai_Nh_Vt IN ('SP')))";

			dtDmVtSp = DataTool.SQLGetDataTable("R81DmVt", null, strKey, "Ma_Vt");

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
			if (bdsDmVtSp.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmVtSp.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmVtSp.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmVtSp.NewRow();
				drCurrent["Ma_Nh_Vt"] = strMa_Nh_Vt;
			}

			frmDmVtSp_Edit frmEdit = new frmDmVtSp_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);
			
			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmVtSp.Position >= 0)
						dtDmVtSp.ImportRow(drCurrent);
					else
					{
						dtDmVtSp.Rows.Add(drCurrent);
						drCurrent["Ma_Nh_Vt"] = strMa_Nh_Vt;
					}

					bdsDmVtSp.Position = bdsDmVtSp.Find("MA_VT", drCurrent["MA_VT"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmVtSp.Current).Row);

				dtDmVtSp.AcceptChanges();
			}
			else
				dtDmVtSp.RejectChanges();
		}

		public override void Delete()
		{
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

			if (DataTool.SQLDelete("R81DmVt", drCurrent))
			{
				bdsDmVtSp.RemoveAt(bdsDmVtSp.Position);
				dtDmVtSp.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsDmVtSp.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMVT", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Item code!" : "Bạn không đc cấp quyền Gộp Mã vật tư, hàng hóa!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmVtSp.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Vt"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DmVt", "Ma_Vt", "Ten_Vt", strOldValue, "DMVT");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				//kiểm tra trước khi gop ma
				int iSo_Ps = (int)SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM vw_TheKho WHERE Ma_Vt = '" + strOldValue + "'");

				//if (iSo_Ps == 0)
				//	iSo_Ps = (int)SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM R04CTPO WHERE Ma_Ct = 'DT' AND Ma_Vt = '" + strOldValue + "'");

				if (iSo_Ps != 0)
				{
					if (Common.MsgOk("Mã vật tư " + strOldValue + " đã phát sinh thẻ kho không cho phép gộp mã"))
						return;
				}
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Vt", "R81DmVt", strOldValue, strNewValue))
				{
					bdsDmVtSp.RemoveCurrent();
					bdsDmVtSp.Position = bdsDmVtSp.Find("Ma_Vt", strNewValue);
				}
			}
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