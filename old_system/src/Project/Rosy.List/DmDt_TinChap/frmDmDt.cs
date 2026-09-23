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
using System.Collections;

namespace RosyList
{
	public partial class frmDmDt : RosyList.frmView
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
        public frmDmDt()
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

		public override void LoadLookup()
		{
			if (!bLookupByGroup && Parameters.GetParaValue("ACCESS_DMDT").ToString() == "1") //Truy cap theo nhom
			{
				string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

				if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
				{
					if (this.strLookupValue == "/" || this.strLookupValue == @"\")
						strWhere = strLookupKeyFilter;
					else
						strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
				}

				//DataTable dtFind = DataTool.SQLGetDataTable("R81DmDt", null, strWhere, null);
				//dùng để xem lại các đối tượng đã nghỉ của các năm trước
				DataTable dtFind = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMDT WHERE " + strWhere);
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
				this.Load(this.strMa_Nh_Dt);
		}

		private void LoadLookupByGroup()
		{//Lookup danh muc doi tuong theo nhom

			frmDmNhDt frm = new frmDmNhDt();
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

			dgvDmDt.strZone = "DMDT";
			dgvDmDt.BuildGridView(this.isLookup);

			ExportControl = dgvDmDt;
		}
		private void Language()
		{
			if (dgvDmDt.Columns.Contains("LY_DO_NGHI"))
				dgvDmDt.Columns["LY_DO_NGHI"].HeaderText = "Lý do không bán hàng";
			if (dgvDmDt.Columns.Contains("MA_DT_CBNV"))
				dgvDmDt.Columns["MA_DT_CBNV"].HeaderText = "Nhân viên phụ trách";
			if (dgvDmDt.Columns.Contains("SO_TK_NH"))
				dgvDmDt.Columns["SO_TK_NH"].HeaderText = "TK Ngân hàng";
			if (dgvDmDt.Columns.Contains("GHI_CHU_DT"))
				dgvDmDt.Columns["GHI_CHU_DT"].HeaderText = "Ghi chú";
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
						strKey = "(Ma_Nh_Dt = '" + strMa_Nh_Dt + "')";
					else
						strKey = "(" + strKey + ") AND (Ma_Nh_Dt = '" + strMa_Nh_Dt + "')";
				}
			}
			else
				strKey = (strMa_Nh_Dt == string.Empty ? string.Empty : "Ma_Nh_Dt = '" + strMa_Nh_Dt + "'");

			//Hải kiểm tra đối tượng: dùng chung danh mục với CRM
			DataTable dtDmDtCheck = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM R81DmDt WHERE 0 = 1");
			if (dtDmDtCheck.Columns.Contains("Deleted"))
				strKey += (strKey == string.Empty ? string.Empty : " AND ") + "(Deleted <> 1)";

			//Hải chỉ show những dữ liệu cần thiết có khai báo trong Zone, Column
			string strSQLExec = @"
				DECLARE @_ColumnList NVARCHAR(1000) 
				SET @_ColumnList = ''
				SELECT @_ColumnList = @_ColumnList + ',' + Column_ID FROM R00Column WHERE Zone = '" + dgvDmDt.strZone + @"'
				SELECT CASE WHEN LEN(@_ColumnList) > 0 THEN RIGHT(@_ColumnList, LEN(@_ColumnList)-1) ELSE '' END ";
			string strFieldList = SQLExec.ExecuteReturnValue(strSQLExec).ToString();
			
			
			if (strFieldList != string.Empty)
			{
				
				strFieldList = strFieldList.Replace("NGUOI_TAO,", "");
				strFieldList = strFieldList.Replace("NGAY_TAO,", "");
				if (bFind)
					dtDmDt = SQLExec.ExecuteReturnDt("SELECT " + strFieldList + ", SUBSTRING(Create_Log,15,20) AS NGUOI_TAO, CASE WHEN LEN(Create_Log) > 15 THEN DBO.fn_GetDate('20'+SUBSTRING(Create_Log,5,2) ,SUBSTRING(Create_Log,3,2),LEFT(Create_Log,2)) ELSE '19000101' END AS NGAY_TAO FROM R81DMDT WHERE " + strKey);
				else
					dtDmDt = SQLExec.ExecuteReturnDt("SELECT " + strFieldList + ", SUBSTRING(Create_Log,15,20) AS NGUOI_TAO, CASE WHEN LEN(Create_Log) > 15 THEN DBO.fn_GetDate('20'+SUBSTRING(Create_Log,5,2) ,SUBSTRING(Create_Log,3,2),LEFT(Create_Log,2)) ELSE '19000101' END AS NGAY_TAO FROM R81DMDT WHERE "+ strKey  + " ORDER BY Ma_Dt ");//dtDmDt = DataTool.SQLGetDataTable("R81DMDT", strFieldList, strKey, "Ma_Dt");
			}
			else
				dtDmDt = DataTool.SQLGetDataTable("R81DMDT", null, strKey, "Ma_Dt");

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
			{

                Common.CopyDataRow(((DataRowView)bdsDmDt.Current).Row, ref drCurrent);
                //drCurrent = dtDmDt.NewRow();
                //drCurrent["Ma_Nh_Dt"] = ((DataRowView)bdsDmDt.Current).Row["Ma_Nh_Dt"];
            }
			else
			{
				drCurrent = dtDmDt.NewRow();
				drCurrent["Ma_Nh_Dt"] = strMa_Nh_Dt;
			}

			if ((string)drCurrent["Ma_Nh_Dt"] != "NHOMQD")
			{
				frmDmDt_Edit frmEdit = new frmDmDt_Edit();
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

						bdsDmDt.Position = bdsDmDt.Find("MA_DT", drCurrent["MA_DT"]);
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
			else
			{
				frmDmDt_Chung_Edit frmEdit = new frmDmDt_Chung_Edit();
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

						bdsDmDt.Position = bdsDmDt.Find("MA_DT", drCurrent["MA_DT"]);
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
		}
		
		public override void Delete()
		{
			//CHECK PHÂN QUYỀN
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			

			if (bdsDmDt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmDt.Current).Row;

			//check đã phát sinh dữ liệu thì không xóa
			Hashtable ht = new Hashtable();
			ht.Add("OBJECT", "Ma_Dt");
			ht.Add("MA", drCurrent["Ma_Dt"].ToString());
			if (SQLExec.ExecuteReturnDt("sp_CheckExistsMa",ht, CommandType.StoredProcedure).Rows.Count > 0 )
            {
				Common.MsgOk("Đơn vị: " + drCurrent["Ten_Dt"].ToString() + " đã tồn tại dữ liệu kế toán không được phép xóa");
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81DMDT", drCurrent))
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
			string strOldValue = (string)drCurrent["Ma_Dt"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DMDT", "Ma_Dt", "Ten_Dt", strOldValue, "DMDT");			

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Are you sure to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Dt", "R81DMDT", strOldValue, strNewValue))
				{
					bdsDmDt.RemoveCurrent();
					bdsDmDt.Position = bdsDmDt.Find("MA_DT", strNewValue);
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
			Public.ImportExcel("DMDT", dtDmDt);
		}

		protected override void OnClosed(EventArgs e)
		{
			if (bFind && !this.bIsEnter)
				LoadLookupByGroup();

			base.OnClosed(e);
		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			Language();
		}
		#endregion
	}
}