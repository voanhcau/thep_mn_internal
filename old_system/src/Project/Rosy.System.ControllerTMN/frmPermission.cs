using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Data;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Customize;


namespace RosyControllerTMN
{
	public partial class frmPermission : RosySystem.Customize.frmView
	{
		#region Fields

		string strMember_ID = string.Empty;
		string strMember_Type = string.Empty;
		string strObject_Type = string.Empty;

		DataRow drCurrent;

		DataTable dtPermissionModule;
		DataTable dtPermissionCt;
		DataTable dtPermissionTk;
		DataTable dtPermissionDvCs;
        DataTable dtPermissionReport;
        DataTable dtPermissionReportCt;

		BindingSource bdsPermissionModule = new BindingSource();
		BindingSource bdsPermissionCt = new BindingSource();
		BindingSource bdsPermissionTk = new BindingSource();
		BindingSource bdsPermissionDvCs = new BindingSource();
        BindingSource bdsPermissionReport = new BindingSource();
        BindingSource bdsPermissionReportCt = new BindingSource();
		#endregion

		#region Contructor

		public frmPermission()
		{
			InitializeComponent();

			dgvPermissionModule.CellClick += new DataGridViewCellEventHandler(dgvPermissionModule_CellClick);
			dgvPermissionCt.CellClick += new DataGridViewCellEventHandler(dgvPermissionCt_CellClick);
			dgvPermissionTk.CellClick += new DataGridViewCellEventHandler(dgvPermissionTk_CellClick);
			dgvPermissionDvCs.CellClick += new DataGridViewCellEventHandler(dgvPermissionDvCs_CellClick);
            dgvPermissionReportCt.CellClick += new DataGridViewCellEventHandler(dgvPermissionReportCt_CellClick);
            dgvPermissionReport.CellClick += new DataGridViewCellEventHandler(dgvPermissionReport_CellClick);
			btExit.Click += new EventHandler(btExit_Click);
		}

        

        

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.CheckPermission();

			this.Show();
		}

		public void Load(string strMember_ID, string strMember_Type)
		{
			this.strMember_ID = strMember_ID;
			this.strMember_Type = strMember_Type;
			this.Text = Languages.GetLanguage("Permission") + " : " + strMember_Type + " - " + strMember_ID;

			this.Load();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			//tlPermission.KeyFieldName = "OBJECT_ID";
			//tlPermission.ParentFieldName = "OBJECT_ID_PARENT";
			//tlPermission.Dock = DockStyle.Fill;
			//tlPermission.ColumnPanelRowHeight = 50; //tlPermission.Appearance.HeaderPanel

			//tlPermission.strZone = "PERMISSION";
			//tlPermission.BuildTreeList(false);

			dgvPermissionModule.strZone = "PERMISSION_MODULE";
			dgvPermissionModule.BuildGridView();

			dgvPermissionCt.strZone = "PERMISSION";
			dgvPermissionCt.BuildGridView();

			dgvPermissionTk.strZone = "PERMISSION_ACCOUNT";
			dgvPermissionTk.BuildGridView();
			dgvPermissionTk.Dock = DockStyle.Fill;

			dgvPermissionDvCs.strZone = "PERMISSION_DVCS";
			dgvPermissionDvCs.BuildGridView();
			dgvPermissionDvCs.Dock = DockStyle.Fill;

			//tpPermissionData.Controls.Add(tlPermission);
			tpPermissionTk.Controls.Add(dgvPermissionTk);
			tpPermissionDvCs.Controls.Add(dgvPermissionDvCs);

            dgvPermissionReport.strZone = "PERMISSION_MODULE";
            dgvPermissionReport.BuildGridView();

            dgvPermissionReportCt.strZone = "PERMISSION_REPORT";
            dgvPermissionReportCt.BuildGridView();
		}

		private void FillData()
		{
			//Permission
			string[] strArrParameter_Name = new string[] { "Member_ID", "Object_Type" };
			object[] objArrParameter_Value = new object[] { this.strMember_ID, "" };

			DataSet dsPermission = SQLExec.ExecuteReturnDs("Sp_GetPermission", strArrParameter_Name, objArrParameter_Value, CommandType.StoredProcedure);

			dtPermissionModule = dsPermission.Tables[0];
			dtPermissionCt = dsPermission.Tables[1];

			bdsPermissionModule.DataSource = dtPermissionModule;
			dgvPermissionModule.DataSource = bdsPermissionModule;

			bdsPermissionCt.DataSource = dtPermissionCt;
			dgvPermissionCt.DataSource = bdsPermissionCt;

			bdsPermissionModule.PositionChanged += new EventHandler(bdsPermissionModule_PositionChanged);

			//PermissionTk
			if (DataTool.SQLCheckExist("sys.Objects", "Name", "Sp_GetPermissionTk"))
			{
				strArrParameter_Name = new string[] { "Member_ID", "Tk" };
				objArrParameter_Value = new object[] { this.strMember_ID, "" };

				dtPermissionTk = SQLExec.ExecuteReturnDt("Sp_GetPermissionTk", strArrParameter_Name, objArrParameter_Value, CommandType.StoredProcedure);

				bdsPermissionTk.DataSource = dtPermissionTk;
				dgvPermissionTk.DataSource = bdsPermissionTk;
			}

			//PermissionDvCs
			if (DataTool.SQLCheckExist("sys.Objects", "Name", "Sp_GetPermissionDvCs"))
			{
				strArrParameter_Name = new string[] { "Member_ID", "Ma_DvCs" };
				objArrParameter_Value = new object[] { this.strMember_ID, "" };

				dtPermissionDvCs = SQLExec.ExecuteReturnDt("Sp_GetPermissionDvCs", strArrParameter_Name, objArrParameter_Value, CommandType.StoredProcedure);

				bdsPermissionDvCs.DataSource = dtPermissionDvCs;
				dgvPermissionDvCs.DataSource = bdsPermissionDvCs;
			}

            //PermissionReport
            if (DataTool.SQLCheckExist("sys.Objects", "Name", "Sp_GetPermissionReport"))
            {
                strArrParameter_Name = new string[] { "Member_ID", "Ma_DvCs" };
                objArrParameter_Value = new object[] { this.strMember_ID, "" };

                DataSet dsPermissionReport = SQLExec.ExecuteReturnDs("Sp_GetPermissionReport", strArrParameter_Name, objArrParameter_Value, CommandType.StoredProcedure);

                dtPermissionReport = dsPermissionReport.Tables[0];
                bdsPermissionReport.DataSource = dtPermissionReport;
                dgvPermissionReport.DataSource = bdsPermissionReport;

                dtPermissionReportCt = dsPermissionReport.Tables[1];
                bdsPermissionReportCt.DataSource = dtPermissionReportCt;
                dgvPermissionReportCt.DataSource = bdsPermissionReportCt;
                bdsPermissionReport.PositionChanged+=new EventHandler(bdsPermissionReport_PositionChanged);
            }
		}

		#endregion

		#region Methods

		private void CheckPermission()
		{
			//Tô màu
			dgvPermissionModule.EnableHeadersVisualStyles = false; //Cho phép vẽ lại Header
			dgvPermissionCt.EnableHeadersVisualStyles = false; //Cho phép vẽ lại Header
			dgvPermissionTk.EnableHeadersVisualStyles = false; //Cho phép vẽ lại Header
			dgvPermissionDvCs.EnableHeadersVisualStyles = false; //Cho phép vẽ lại Header

			DataGridViewCellStyle dgvcStyleAllow = new DataGridViewCellStyle();
			dgvcStyleAllow.ForeColor = System.Drawing.Color.Blue;

			DataGridViewCellStyle dgvcStyleDeny = new DataGridViewCellStyle();
			dgvcStyleDeny.ForeColor = System.Drawing.Color.Red;

			//Tô màu
			foreach (DataGridViewColumn dgvc in dgvPermissionModule.Columns)
			{
				if (dgvc.Name.StartsWith("ALLOW"))
					dgvc.HeaderCell.Style = dgvcStyleAllow;
				else if (dgvc.Name.StartsWith("DENY"))
					dgvc.HeaderCell.Style = dgvcStyleDeny;
			}

			//Tô màu
			foreach (DataGridViewColumn dgvc in dgvPermissionCt.Columns)
			{
				if (dgvc.Name.StartsWith("ALLOW"))
					dgvc.HeaderCell.Style = dgvcStyleAllow;
				else if (dgvc.Name.StartsWith("DENY"))
					dgvc.HeaderCell.Style = dgvcStyleDeny;
			}

			//Tô màu
			foreach (DataGridViewColumn dgvc in dgvPermissionTk.Columns)
			{
				if (dgvc.Name.StartsWith("ALLOW"))
					dgvc.HeaderCell.Style = dgvcStyleAllow;
				else if (dgvc.Name.StartsWith("DENY"))
					dgvc.HeaderCell.Style = dgvcStyleDeny;
			}

			//Tô màu
			foreach (DataGridViewColumn dgvc in dgvPermissionDvCs.Columns)
			{
				if (dgvc.Name.StartsWith("ALLOW"))
					dgvc.HeaderCell.Style = dgvcStyleAllow;
				else if (dgvc.Name.StartsWith("DENY"))
					dgvc.HeaderCell.Style = dgvcStyleDeny;
			}
		}

		void UpdatePermission(rsDataGridView dgvPermission, BindingSource bdsPermission, string strColumnName)
		{
			if (!Common.Inlist(strColumnName, "ALLOW_VIEW,ALLOW_ACCESS,ALLOW_NEW,ALLOW_EDIT,ALLOW_DELETE,DENY_VIEW,DENY_ACCESS,DENY_NEW,DENY_EDIT,DENY_DELETE"))
				return;

			if (Common.CheckPermission("PERMISSION", enuPermission_Type.Allow_Access) || RosySystem.Element.Element.sysIs_Admin)
			{
				drCurrent = ((DataRowView)bdsPermission.Current).Row;
				drCurrent.AcceptChanges();

				bool bAllow_View = (bool)drCurrent["ALLOW_VIEW"],
					bAllow_Access = (bool)drCurrent["ALLOW_ACCESS"],
					bAllow_New = (bool)drCurrent["ALLOW_NEW"],
					bAllow_Edit = (bool)drCurrent["ALLOW_EDIT"],
					bAllow_Delete = (bool)drCurrent["ALLOW_DELETE"];

				bool bDeny_View = (bool)drCurrent["DENY_VIEW"],
					bDeny_Access = (bool)drCurrent["DENY_ACCESS"],
					bDeny_New = (bool)drCurrent["DENY_NEW"],
					bDeny_Edit = (bool)drCurrent["DENY_EDIT"],
					bDeny_Delete = (bool)drCurrent["DENY_DELETE"];

				if (strColumnName == "ALLOW_VIEW") //Allow
				{
					bAllow_View = !(bool)drCurrent[strColumnName];
					if (bAllow_View) bDeny_View = !bAllow_View;
				}
				else if (strColumnName == "ALLOW_ACCESS")
				{
					bAllow_Access = !(bool)drCurrent[strColumnName];
					if (bAllow_Access) bDeny_Access = !bAllow_Access;
				}
				else if (strColumnName == "ALLOW_NEW")
				{
					bAllow_New = !(bool)drCurrent[strColumnName];
					if (bAllow_New) bDeny_New = !bAllow_New;
				}
				else if (strColumnName == "ALLOW_EDIT")
				{
					bAllow_Edit = !(bool)drCurrent[strColumnName];
					if (bAllow_Edit) bDeny_Edit = !bAllow_Edit;
				}
				else if (strColumnName == "ALLOW_DELETE")
				{
					bAllow_Delete = !(bool)drCurrent[strColumnName];
					if (bAllow_Delete) bDeny_Delete = !bAllow_Delete;
				}
				else if (strColumnName == "DENY_VIEW") //Deny: Allow luôn ngược với Deny
				{
					bDeny_View = !(bool)drCurrent[strColumnName];
					if (bDeny_View) bAllow_View = !bDeny_View;
				}
				else if (strColumnName == "DENY_ACCESS")
				{
					bDeny_Access = !(bool)drCurrent[strColumnName];
					if (bDeny_Access) bAllow_Access = !bDeny_Access;
				}
				else if (strColumnName == "DENY_NEW")
				{
					bDeny_New = !(bool)drCurrent[strColumnName];
					if (bDeny_New) bAllow_New = !bDeny_New;
				}
				else if (strColumnName == "DENY_EDIT")
				{
					bDeny_Edit = !(bool)drCurrent[strColumnName];
					if (bDeny_Edit) bAllow_Edit = !bDeny_Edit;
				}
				else if (strColumnName == "DENY_DELETE")
				{
					bDeny_Delete = !(bool)drCurrent[strColumnName];
					if (bDeny_Delete) bAllow_Delete = !bDeny_Delete;
				}

				string strSQLExec;
				int iIdent00;

				Hashtable htPara = new Hashtable();
				htPara.Add("MEMBER_ID", strMember_ID);
				htPara.Add("OBJECT_ID", (string)drCurrent["Object_ID"]);
				htPara.Add("ALLOW_VIEW", bAllow_View);
				htPara.Add("ALLOW_ACCESS", bAllow_Access);
				htPara.Add("ALLOW_NEW", bAllow_New);
				htPara.Add("ALLOW_EDIT", bAllow_Edit);
				htPara.Add("ALLOW_DELETE", bAllow_Delete);

				if (drCurrent["Ident00"] == DBNull.Value || Convert.ToInt32(drCurrent["Ident00"]) == 0) //Chưa tồn tại
				{
					strSQLExec = @"INSERT INTO R00Permission (Member_ID, Object_ID, Allow_View, Allow_Access, Allow_New, Allow_Edit, Allow_Delete) 
												VALUES (@Member_ID, @Object_ID, @Allow_View, @Allow_Access, @Allow_New, @Allow_Edit, @Allow_Delete) 
											SELECT @@IDENTITY";

					iIdent00 = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, htPara, CommandType.Text));

					if (iIdent00 != 0)
					{
						drCurrent["Allow_View"] = bAllow_View; //Allow
						drCurrent["Allow_Access"] = bAllow_Access;
						drCurrent["Allow_New"] = bAllow_New;
						drCurrent["Allow_Edit"] = bAllow_Edit;
						drCurrent["Allow_Delete"] = bAllow_Delete;
						drCurrent["Deny_View"] = bDeny_View; //Deny
						drCurrent["Deny_Access"] = bDeny_Access;
						drCurrent["Deny_New"] = bDeny_New;
						drCurrent["Deny_Edit"] = bDeny_Edit;
						drCurrent["Deny_Delete"] = bDeny_Delete;
						drCurrent["Ident00"] = iIdent00;
					}
				}
				else //Đã tồn tại
				{
					htPara.Add("IDENT00", Convert.ToInt32(drCurrent["Ident00"]));
					strSQLExec = @"UPDATE R00Permission SET Allow_View = @Allow_View, Allow_Access = @Allow_Access, Allow_New = @Allow_New, Allow_Edit = @Allow_Edit, Allow_Delete = @Allow_Delete WHERE Ident00 = @Ident00";

					if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
					{
						drCurrent["Allow_View"] = bAllow_View; //Allow
						drCurrent["Allow_Access"] = bAllow_Access;
						drCurrent["Allow_New"] = bAllow_New;
						drCurrent["Allow_Edit"] = bAllow_Edit;
						drCurrent["Allow_Delete"] = bAllow_Delete;
						drCurrent["Deny_View"] = bDeny_View; //Deny
						drCurrent["Deny_Access"] = bDeny_Access;
						drCurrent["Deny_New"] = bDeny_New;
						drCurrent["Deny_Edit"] = bDeny_Edit;
						drCurrent["Deny_Delete"] = bDeny_Delete;
					}
				}

				//Nếu check [Allow] và [Deny] bị gỡ ra toàn bộ -> Thì xóa hẳn khỏi R00Permission
				if (drCurrent["Ident00"] != DBNull.Value && Convert.ToInt32(drCurrent["Ident00"]) != 0)
				{
					bool bUncheckAll = true;

					if (dgvPermission.Columns.Contains("Allow_View") && dgvPermission.Columns["Allow_View"].Visible && ((bool)drCurrent["Allow_View"] || (bool)drCurrent["Deny_View"]))
						bUncheckAll = false;
					if (dgvPermission.Columns.Contains("Allow_Access") && dgvPermission.Columns["Allow_Access"].Visible && ((bool)drCurrent["Allow_Access"] || (bool)drCurrent["Deny_Access"]))
						bUncheckAll = false;
					if (dgvPermission.Columns.Contains("Allow_New") && dgvPermission.Columns["Allow_New"].Visible && ((bool)drCurrent["Allow_New"] || (bool)drCurrent["Deny_New"]))
						bUncheckAll = false;
					if (dgvPermission.Columns.Contains("Allow_Edit") && dgvPermission.Columns["Allow_Edit"].Visible && ((bool)drCurrent["Allow_Edit"] || (bool)drCurrent["Deny_Edit"]))
						bUncheckAll = false;
					if (dgvPermission.Columns.Contains("Allow_Delete") && dgvPermission.Columns["Allow_Delete"].Visible && ((bool)drCurrent["Allow_Delete"] || (bool)drCurrent["Deny_Delete"]))
						bUncheckAll = false;

					if (bUncheckAll)
						if (SQLExec.Execute("DELETE FROM R00Permission WHERE Ident00 = " + drCurrent["Ident00"].ToString().Trim()))
							drCurrent["Ident00"] = 0;
				}
			}
		}

		void UpdatePermissionTk(string strColumnName)
		{
			if (!Common.Inlist(strColumnName, "ALLOW_VIEW,ALLOW_ACCESS,ALLOW_NEW,ALLOW_EDIT,ALLOW_DELETE,DENY_VIEW,DENY_ACCESS,DENY_NEW,DENY_EDIT,DENY_DELETE"))
				return;

			if (Common.CheckPermission("PERMISSION", enuPermission_Type.Allow_Access) || RosySystem.Element.Element.sysIs_Admin)
			{
				drCurrent = ((DataRowView)bdsPermissionTk.Current).Row;
				drCurrent.AcceptChanges();

				bool bAllow_View = (bool)drCurrent["Allow_View"],
					bDeny_View = (bool)drCurrent["DENY_VIEW"];

				if (strColumnName == "ALLOW_VIEW") //Allow
				{
					bAllow_View = !(bool)drCurrent[strColumnName];
					if (bAllow_View) bDeny_View = !bAllow_View;
				}
				else if (strColumnName == "DENY_VIEW") //Deny: Allow luôn ngược với Deny
				{
					bDeny_View = !(bool)drCurrent[strColumnName];
					if (bDeny_View) bAllow_View = !bDeny_View;
				}

				string strSQLExec;
				int iIdent00;

				Hashtable htPara = new Hashtable();
				htPara.Add("MEMBER_ID", strMember_ID);
				htPara.Add("TK", (string)drCurrent["Tk"]);
				htPara.Add("ALLOW_VIEW", bAllow_View);

				if (drCurrent["Ident00"] == DBNull.Value || Convert.ToInt32(drCurrent["Ident00"]) == 0)
				{
					strSQLExec = @"INSERT INTO R00PermissionTK (Member_ID, Tk, Allow_View) 
										VALUES (@Member_ID, @Tk, @Allow_View)
									SELECT @@IDENTITY";

					iIdent00 = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, htPara, CommandType.Text));

					if (iIdent00 != 0)
					{
						drCurrent["Allow_View"] = bAllow_View;
						drCurrent["Deny_View"] = bDeny_View;
						drCurrent["Ident00"] = iIdent00;
					}
				}
				else
				{
					htPara.Add("IDENT00", Convert.ToInt32(drCurrent["Ident00"]));
					strSQLExec = @"UPDATE R00PermissionTK SET Allow_View = @Allow_View WHERE Ident00 = @Ident00";

					if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
					{
						drCurrent["Allow_View"] = bAllow_View;
						drCurrent["Deny_View"] = bDeny_View;
					}
				}
			}
		}
        
        void UpdatePermissionReportCt(rsDataGridView dgvPermission, BindingSource bdsPermission, string strColumnName)
		{
			if (!Common.Inlist(strColumnName, "ALLOW_VIEW,ALLOW_ACCESS,ALLOW_NEW,ALLOW_EDIT,ALLOW_DELETE,DENY_VIEW,DENY_ACCESS,DENY_NEW,DENY_EDIT,DENY_DELETE"))
				return;

			if (Common.CheckPermission("PERMISSION", enuPermission_Type.Allow_Access) || RosySystem.Element.Element.sysIs_Admin)
			{
				drCurrent = ((DataRowView)bdsPermissionReportCt.Current).Row;
				drCurrent.AcceptChanges();

				bool bAllow_View = (bool)drCurrent["ALLOW_VIEW"],
					bAllow_Access = (bool)drCurrent["ALLOW_ACCESS"],
					bAllow_New = (bool)drCurrent["ALLOW_NEW"],
					bAllow_Edit = (bool)drCurrent["ALLOW_EDIT"],
					bAllow_Delete = (bool)drCurrent["ALLOW_DELETE"];

				bool bDeny_View = (bool)drCurrent["DENY_VIEW"],
					bDeny_Access = (bool)drCurrent["DENY_ACCESS"],
					bDeny_New = (bool)drCurrent["DENY_NEW"],
					bDeny_Edit = (bool)drCurrent["DENY_EDIT"],
					bDeny_Delete = (bool)drCurrent["DENY_DELETE"];

				if (strColumnName == "ALLOW_VIEW") //Allow
				{
					bAllow_View = !(bool)drCurrent[strColumnName];
					if (bAllow_View) bDeny_View = !bAllow_View;
				}
				else if (strColumnName == "ALLOW_ACCESS")
				{
					bAllow_Access = !(bool)drCurrent[strColumnName];
					if (bAllow_Access) bDeny_Access = !bAllow_Access;
				}
				else if (strColumnName == "ALLOW_NEW")
				{
					bAllow_New = !(bool)drCurrent[strColumnName];
					if (bAllow_New) bDeny_New = !bAllow_New;
				}
				else if (strColumnName == "ALLOW_EDIT")
				{
					bAllow_Edit = !(bool)drCurrent[strColumnName];
					if (bAllow_Edit) bDeny_Edit = !bAllow_Edit;
				}
				else if (strColumnName == "ALLOW_DELETE")
				{
					bAllow_Delete = !(bool)drCurrent[strColumnName];
					if (bAllow_Delete) bDeny_Delete = !bAllow_Delete;
				}
				else if (strColumnName == "DENY_VIEW") //Deny: Allow luôn ngược với Deny
				{
					bDeny_View = !(bool)drCurrent[strColumnName];
					if (bDeny_View) bAllow_View = !bDeny_View;
				}
				else if (strColumnName == "DENY_ACCESS")
				{
					bDeny_Access = !(bool)drCurrent[strColumnName];
					if (bDeny_Access) bAllow_Access = !bDeny_Access;
				}
				else if (strColumnName == "DENY_NEW")
				{
					bDeny_New = !(bool)drCurrent[strColumnName];
					if (bDeny_New) bAllow_New = !bDeny_New;
				}
				else if (strColumnName == "DENY_EDIT")
				{
					bDeny_Edit = !(bool)drCurrent[strColumnName];
					if (bDeny_Edit) bAllow_Edit = !bDeny_Edit;
				}
				else if (strColumnName == "DENY_DELETE")
				{
					bDeny_Delete = !(bool)drCurrent[strColumnName];
					if (bDeny_Delete) bAllow_Delete = !bDeny_Delete;
				}

				string strSQLExec;
				int iIdent00;

				Hashtable htPara = new Hashtable();
				htPara.Add("MEMBER_ID", strMember_ID);
				htPara.Add("OBJECT_ID", (string)drCurrent["Object_ID"]);
                htPara.Add("REPORT_ID", (string)drCurrent["Report_ID"]);
				htPara.Add("ALLOW_VIEW", bAllow_View);
				htPara.Add("ALLOW_ACCESS", bAllow_Access);
				htPara.Add("ALLOW_NEW", bAllow_New);
				htPara.Add("ALLOW_EDIT", bAllow_Edit);
				htPara.Add("ALLOW_DELETE", bAllow_Delete);

				if (drCurrent["Ident00"] == DBNull.Value || Convert.ToInt32(drCurrent["Ident00"]) == 0) //Chưa tồn tại
				{
                    strSQLExec = @"INSERT INTO R00PermissionBC (Member_ID, Object_ID, Report_ID, Allow_View, Allow_Access, Allow_New, Allow_Edit, Allow_Delete) 
												VALUES (@Member_ID, @Object_ID , @Report_ID, @Allow_View, @Allow_Access, @Allow_New, @Allow_Edit, @Allow_Delete) 
											SELECT @@IDENTITY";

					iIdent00 = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, htPara, CommandType.Text));

					if (iIdent00 != 0)
					{
						drCurrent["Allow_View"] = bAllow_View; //Allow
						drCurrent["Allow_Access"] = bAllow_Access;
						drCurrent["Allow_New"] = bAllow_New;
						drCurrent["Allow_Edit"] = bAllow_Edit;
						drCurrent["Allow_Delete"] = bAllow_Delete;
						drCurrent["Deny_View"] = bDeny_View; //Deny
						drCurrent["Deny_Access"] = bDeny_Access;
						drCurrent["Deny_New"] = bDeny_New;
						drCurrent["Deny_Edit"] = bDeny_Edit;
						drCurrent["Deny_Delete"] = bDeny_Delete;
						drCurrent["Ident00"] = iIdent00;
					}
				}
				else //Đã tồn tại
				{
					htPara.Add("IDENT00", Convert.ToInt32(drCurrent["Ident00"]));
					strSQLExec = @"UPDATE R00PermissionBC SET Allow_View = @Allow_View, Allow_Access = @Allow_Access, Allow_New = @Allow_New, Allow_Edit = @Allow_Edit, Allow_Delete = @Allow_Delete WHERE Ident00 = @Ident00";

					if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
					{
						drCurrent["Allow_View"] = bAllow_View; //Allow
						drCurrent["Allow_Access"] = bAllow_Access;
						drCurrent["Allow_New"] = bAllow_New;
						drCurrent["Allow_Edit"] = bAllow_Edit;
						drCurrent["Allow_Delete"] = bAllow_Delete;
						drCurrent["Deny_View"] = bDeny_View; //Deny
						drCurrent["Deny_Access"] = bDeny_Access;
						drCurrent["Deny_New"] = bDeny_New;
						drCurrent["Deny_Edit"] = bDeny_Edit;
						drCurrent["Deny_Delete"] = bDeny_Delete;
					}
				}

				//Nếu check [Allow] và [Deny] bị gỡ ra toàn bộ -> Thì xóa hẳn khỏi R00Permission
				if (drCurrent["Ident00"] != DBNull.Value && Convert.ToInt32(drCurrent["Ident00"]) != 0)
				{
					bool bUncheckAll = true;

					if (dgvPermission.Columns.Contains("Allow_View") && dgvPermission.Columns["Allow_View"].Visible && ((bool)drCurrent["Allow_View"] || (bool)drCurrent["Deny_View"]))
						bUncheckAll = false;
					if (dgvPermission.Columns.Contains("Allow_Access") && dgvPermission.Columns["Allow_Access"].Visible && ((bool)drCurrent["Allow_Access"] || (bool)drCurrent["Deny_Access"]))
						bUncheckAll = false;
					if (dgvPermission.Columns.Contains("Allow_New") && dgvPermission.Columns["Allow_New"].Visible && ((bool)drCurrent["Allow_New"] || (bool)drCurrent["Deny_New"]))
						bUncheckAll = false;
					if (dgvPermission.Columns.Contains("Allow_Edit") && dgvPermission.Columns["Allow_Edit"].Visible && ((bool)drCurrent["Allow_Edit"] || (bool)drCurrent["Deny_Edit"]))
						bUncheckAll = false;
					if (dgvPermission.Columns.Contains("Allow_Delete") && dgvPermission.Columns["Allow_Delete"].Visible && ((bool)drCurrent["Allow_Delete"] || (bool)drCurrent["Deny_Delete"]))
						bUncheckAll = false;

					if (bUncheckAll)
						if (SQLExec.Execute("DELETE FROM R00PermissionBC WHERE Ident00 = " + drCurrent["Ident00"].ToString().Trim()))
							drCurrent["Ident00"] = 0;
				}
			}
		}
        void UpdatePermissionReport(rsDataGridView dgvPermission, BindingSource bdsPermission, string strColumnName)
        {
            if (!Common.Inlist(strColumnName, "ALLOW_VIEW,ALLOW_ACCESS,ALLOW_NEW,ALLOW_EDIT,ALLOW_DELETE,DENY_VIEW,DENY_ACCESS,DENY_NEW,DENY_EDIT,DENY_DELETE"))
                return;

            if (Common.CheckPermission("PERMISSION", enuPermission_Type.Allow_Access) || RosySystem.Element.Element.sysIs_Admin)
            {
                drCurrent = ((DataRowView)bdsPermissionReport.Current).Row;
                drCurrent.AcceptChanges();

                bool bAllow_View = (bool)drCurrent["ALLOW_VIEW"],
                    bAllow_Access = (bool)drCurrent["ALLOW_ACCESS"],
                    bAllow_New = (bool)drCurrent["ALLOW_NEW"],
                    bAllow_Edit = (bool)drCurrent["ALLOW_EDIT"],
                    bAllow_Delete = (bool)drCurrent["ALLOW_DELETE"];

                bool bDeny_View = (bool)drCurrent["DENY_VIEW"],
                    bDeny_Access = (bool)drCurrent["DENY_ACCESS"],
                    bDeny_New = (bool)drCurrent["DENY_NEW"],
                    bDeny_Edit = (bool)drCurrent["DENY_EDIT"],
                    bDeny_Delete = (bool)drCurrent["DENY_DELETE"];

                if (strColumnName == "ALLOW_VIEW") //Allow
                {
                    bAllow_View = !(bool)drCurrent[strColumnName];
                    if (bAllow_View) bDeny_View = !bAllow_View;
                }
                else if (strColumnName == "ALLOW_ACCESS")
                {
                    bAllow_Access = !(bool)drCurrent[strColumnName];
                    if (bAllow_Access) bDeny_Access = !bAllow_Access;
                }
                else if (strColumnName == "ALLOW_NEW")
                {
                    bAllow_New = !(bool)drCurrent[strColumnName];
                    if (bAllow_New) bDeny_New = !bAllow_New;
                }
                else if (strColumnName == "ALLOW_EDIT")
                {
                    bAllow_Edit = !(bool)drCurrent[strColumnName];
                    if (bAllow_Edit) bDeny_Edit = !bAllow_Edit;
                }
                else if (strColumnName == "ALLOW_DELETE")
                {
                    bAllow_Delete = !(bool)drCurrent[strColumnName];
                    if (bAllow_Delete) bDeny_Delete = !bAllow_Delete;
                }
                else if (strColumnName == "DENY_VIEW") //Deny: Allow luôn ngược với Deny
                {
                    bDeny_View = !(bool)drCurrent[strColumnName];
                    if (bDeny_View) bAllow_View = !bDeny_View;
                }
                else if (strColumnName == "DENY_ACCESS")
                {
                    bDeny_Access = !(bool)drCurrent[strColumnName];
                    if (bDeny_Access) bAllow_Access = !bDeny_Access;
                }
                else if (strColumnName == "DENY_NEW")
                {
                    bDeny_New = !(bool)drCurrent[strColumnName];
                    if (bDeny_New) bAllow_New = !bDeny_New;
                }
                else if (strColumnName == "DENY_EDIT")
                {
                    bDeny_Edit = !(bool)drCurrent[strColumnName];
                    if (bDeny_Edit) bAllow_Edit = !bDeny_Edit;
                }
                else if (strColumnName == "DENY_DELETE")
                {
                    bDeny_Delete = !(bool)drCurrent[strColumnName];
                    if (bDeny_Delete) bAllow_Delete = !bDeny_Delete;
                }

                string strSQLExec;
                int iIdent00;

                Hashtable htPara = new Hashtable();
                htPara.Add("MEMBER_ID", strMember_ID);
                htPara.Add("OBJECT_ID", (string)drCurrent["Object_ID"]);
           
                htPara.Add("ALLOW_VIEW", bAllow_View);
                htPara.Add("ALLOW_ACCESS", bAllow_Access);
                htPara.Add("ALLOW_NEW", bAllow_New);
                htPara.Add("ALLOW_EDIT", bAllow_Edit);
                htPara.Add("ALLOW_DELETE", bAllow_Delete);

                if (!DataTool.SQLCheckExist("R00PERMISSION", new string[] {"Member_ID","Object_ID"}, new object[] {strMember_ID,(string)drCurrent["Object_ID"]})) //Chưa tồn tại
                {
                    strSQLExec = @"INSERT INTO R00Permission (Member_ID, Object_ID, Allow_View, Allow_Access, Allow_New, Allow_Edit, Allow_Delete) 
												VALUES (@Member_ID, @Object_ID, @Allow_View, @Allow_Access, @Allow_New, @Allow_Edit, @Allow_Delete) 
											SELECT @@IDENTITY";

                    iIdent00 = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, htPara, CommandType.Text));

                    if (iIdent00 != 0)
                    {
                        drCurrent["Allow_View"] = bAllow_View; //Allow
                        drCurrent["Allow_Access"] = bAllow_Access;
                        drCurrent["Allow_New"] = bAllow_New;
                        drCurrent["Allow_Edit"] = bAllow_Edit;
                        drCurrent["Allow_Delete"] = bAllow_Delete;
                        drCurrent["Deny_View"] = bDeny_View; //Deny
                        drCurrent["Deny_Access"] = bDeny_Access;
                        drCurrent["Deny_New"] = bDeny_New;
                        drCurrent["Deny_Edit"] = bDeny_Edit;
                        drCurrent["Deny_Delete"] = bDeny_Delete;
                        drCurrent["Ident00"] = iIdent00;
                    }
                    
                }
                else //Đã tồn tại
                {
                    htPara.Add("IDENT00", Convert.ToInt32(drCurrent["Ident00"]));
                    strSQLExec = @"UPDATE R00Permission SET Allow_View = @Allow_View, Allow_Access = @Allow_Access, Allow_New = @Allow_New, Allow_Edit = @Allow_Edit, Allow_Delete = @Allow_Delete WHERE Member_ID = @Member_ID AND Object_ID = @Object_ID";

                    if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                    {
                        drCurrent["Allow_View"] = bAllow_View; //Allow
                        drCurrent["Allow_Access"] = bAllow_Access;
                        drCurrent["Allow_New"] = bAllow_New;
                        drCurrent["Allow_Edit"] = bAllow_Edit;
                        drCurrent["Allow_Delete"] = bAllow_Delete;
                        drCurrent["Deny_View"] = bDeny_View; //Deny
                        drCurrent["Deny_Access"] = bDeny_Access;
                        drCurrent["Deny_New"] = bDeny_New;
                        drCurrent["Deny_Edit"] = bDeny_Edit;
                        drCurrent["Deny_Delete"] = bDeny_Delete;
                    }
                }
                //Duyệt qua từng BC chi tiết
                foreach (DataRow dr in dtPermissionReportCt.Select("Object_ID = '" + drCurrent["Object_ID"].ToString() + "'"))
                {
                    bool bAllow_ViewCt = (bool)dr["ALLOW_VIEW"],
                       bAllow_AccessCt = (bool)dr["ALLOW_ACCESS"],
                       bAllow_NewCt = (bool)dr["ALLOW_NEW"],
                       bAllow_EditCt = (bool)dr["ALLOW_EDIT"],
                       bAllow_DeleteCt = (bool)dr["ALLOW_DELETE"];

                    bool bDeny_ViewCt = (bool)dr["DENY_VIEW"],
                       bDeny_AccessCt = (bool)dr["DENY_ACCESS"],
                       bDeny_NewCt = (bool)dr["DENY_NEW"],
                       bDeny_EditCt = (bool)dr["DENY_EDIT"],
                       bDeny_DeleteCt = (bool)dr["DENY_DELETE"];

                        Hashtable htParaCt = new Hashtable();
                        htParaCt.Add("MEMBER_ID", strMember_ID);
                        htParaCt.Add("OBJECT_ID", (string)dr["Object_ID"]);
                        htParaCt.Add("REPORT_ID", (string)dr["Report_ID"]);
                        htParaCt.Add("ALLOW_ACCESS", bAllow_Access);

                    if (!DataTool.SQLCheckExist("R00PERMISSIONBC", new string[] { "Member_ID", "Object_ID", "Report_ID" }, new object[] { strMember_ID, (string)dr["Object_ID"], (string)dr["Report_ID"] })) //Chưa tồn tại
                    {
                        if (strColumnName == "ALLOW_ACCESS") //Allow
                       {
                           bAllow_AccessCt = bAllow_Access;
                           if (bAllow_AccessCt) bDeny_AccessCt = !bAllow_AccessCt;

                          
                           strSQLExec = @"INSERT INTO R00PermissionBc(Member_ID, Object_ID, Report_ID, Allow_Access) 
												VALUES (@Member_ID, @Object_ID, @Report_ID, @Allow_Access)";
                           SQLExec.Execute(strSQLExec, htParaCt, CommandType.Text);
                       }

                    }
                    else
                    {
                        if (strColumnName == "ALLOW_ACCESS") //Allow
                        {
                            bAllow_AccessCt = bAllow_Access;
                            if (bAllow_AccessCt) bDeny_AccessCt = !bAllow_AccessCt;


                           
                            strSQLExec = @"UPDATE R00PermissionBc SET Allow_Access = @Allow_Access WHERE Member_ID = @Member_ID AND Object_ID = @Object_ID AND Report_ID = @Report_ID";
                            SQLExec.Execute(strSQLExec, htParaCt, CommandType.Text);
                        }
                    }
                    dr["ALLOW_ACCESS"] = bAllow_AccessCt;
                    dr["DENY_ACCESS"] = bDeny_AccessCt;
                }

                //Nếu check [Allow] và [Deny] bị gỡ ra toàn bộ -> Thì xóa hẳn khỏi R00Permission
                if (drCurrent["Ident00"] != DBNull.Value && Convert.ToInt32(drCurrent["Ident00"]) != 0)
                {
                    bool bUncheckAll = true;

                    if (dgvPermission.Columns.Contains("Allow_View") && dgvPermission.Columns["Allow_View"].Visible && ((bool)drCurrent["Allow_View"] || (bool)drCurrent["Deny_View"]))
                        bUncheckAll = false;
                    if (dgvPermission.Columns.Contains("Allow_Access") && dgvPermission.Columns["Allow_Access"].Visible && ((bool)drCurrent["Allow_Access"] || (bool)drCurrent["Deny_Access"]))
                        bUncheckAll = false;
                    if (dgvPermission.Columns.Contains("Allow_New") && dgvPermission.Columns["Allow_New"].Visible && ((bool)drCurrent["Allow_New"] || (bool)drCurrent["Deny_New"]))
                        bUncheckAll = false;
                    if (dgvPermission.Columns.Contains("Allow_Edit") && dgvPermission.Columns["Allow_Edit"].Visible && ((bool)drCurrent["Allow_Edit"] || (bool)drCurrent["Deny_Edit"]))
                        bUncheckAll = false;
                    if (dgvPermission.Columns.Contains("Allow_Delete") && dgvPermission.Columns["Allow_Delete"].Visible && ((bool)drCurrent["Allow_Delete"] || (bool)drCurrent["Deny_Delete"]))
                        bUncheckAll = false;

                    if (bUncheckAll)
                        if (SQLExec.Execute("DELETE FROM R00PermissionBC WHERE Ident00 = " + drCurrent["Ident00"].ToString().Trim()))
                            drCurrent["Ident00"] = 0;
                }
            }
        }
		void UpdatePermissionDvCs(string strColumnName)
		{
			if (!Common.Inlist(strColumnName, "ALLOW_VIEW,ALLOW_ACCESS,ALLOW_NEW,ALLOW_EDIT,ALLOW_DELETE,DENY_VIEW,DENY_ACCESS,DENY_NEW,DENY_EDIT,DENY_DELETE"))
				return;

			if (Common.CheckPermission("PERMISSION", enuPermission_Type.Allow_Access) || RosySystem.Element.Element.sysIs_Admin)
			{
				drCurrent = ((DataRowView)bdsPermissionDvCs.Current).Row;
				drCurrent.AcceptChanges();

				bool bAllow_Access = (bool)drCurrent["Allow_Access"],
					bDeny_Access = (bool)drCurrent["Deny_Access"];

				if (strColumnName == "ALLOW_ACCESS") //Allow
				{
					bAllow_Access = !(bool)drCurrent[strColumnName];
					if (bAllow_Access) bDeny_Access = !bAllow_Access;
				}
				else if (strColumnName == "DENY_ACCESS") //Deny: Allow luôn ngược với Deny
				{
					bDeny_Access = !(bool)drCurrent[strColumnName];
					if (bDeny_Access) bAllow_Access = !bDeny_Access;
				}

				string strSQLExec;
				int iIdent00;

				Hashtable htPara = new Hashtable();
				htPara.Add("MEMBER_ID", strMember_ID);
				htPara.Add("MA_DVCS", (string)drCurrent["Ma_DvCs"]);
				htPara.Add("ALLOW_ACCESS", bAllow_Access);

				if (drCurrent["Ident00"] == DBNull.Value || Convert.ToInt32(drCurrent["Ident00"]) == 0)
				{
					strSQLExec = @"INSERT INTO R00PermissionDVCS (Member_ID, Ma_DvCs, Allow_Access) 
										VALUES (@Member_ID, @Ma_DvCs, @Allow_Access)
									SELECT @@IDENTITY";

					iIdent00 = Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, htPara, CommandType.Text));

					if (iIdent00 != 0)
					{
						drCurrent["Allow_Access"] = bAllow_Access;
						drCurrent["Deny_Access"] = bDeny_Access;
						drCurrent["Ident00"] = iIdent00;
					}
				}
				else
				{
					htPara.Add("IDENT00", Convert.ToInt32(drCurrent["Ident00"]));
					strSQLExec = @"UPDATE R00PermissionDVCS SET Allow_Access = @Allow_Access WHERE Ident00 = @Ident00";

					if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
					{
						drCurrent["Allow_Access"] = bAllow_Access;
						drCurrent["Deny_Access"] = bDeny_Access;
					}
				}
			}
		}

		#endregion

		#region Events

		void bdsPermissionModule_PositionChanged(object sender, EventArgs e)
		{
			DataRow drPermissionModule = ((DataRowView)bdsPermissionModule.Current).Row;

			bdsPermissionCt.Filter = "Object_ID_Parent = '" + drPermissionModule["Object_ID"].ToString() + "'";
		}
        void bdsPermissionReport_PositionChanged(object sender, EventArgs e)
        {
            DataRow drPermissionReport = ((DataRowView)bdsPermissionReport.Current).Row;

            bdsPermissionReportCt.Filter = "Object_ID = '" + drPermissionReport["Object_ID"].ToString() + "'";
        }
		void dgvPermissionModule_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			string strColumnName = dgvPermissionModule.Columns[e.ColumnIndex].Name;

			this.UpdatePermission(dgvPermissionModule, bdsPermissionModule, strColumnName);
		}

		void dgvPermissionCt_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			string strColumnName = dgvPermissionCt.Columns[e.ColumnIndex].Name;

			this.UpdatePermission(dgvPermissionCt, bdsPermissionCt, strColumnName);
		}
        void dgvPermissionReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string strColumnName = dgvPermissionReport.Columns[e.ColumnIndex].Name;

            this.UpdatePermissionReport(dgvPermissionReport, bdsPermissionReport, strColumnName);
        }
        void dgvPermissionReportCt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string strColumnName = dgvPermissionReportCt.Columns[e.ColumnIndex].Name;

            this.UpdatePermissionReportCt(dgvPermissionReportCt, bdsPermissionReportCt, strColumnName);
        }
		void dgvPermissionTk_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			string strColumnName = dgvPermissionTk.Columns[e.ColumnIndex].Name;

			this.UpdatePermissionTk(strColumnName);
		}

		void dgvPermissionDvCs_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			string strColumnName = dgvPermissionDvCs.Columns[e.ColumnIndex].Name;

			this.UpdatePermissionDvCs(strColumnName);
		}

		void btLoad_DmTk_Click(object sender, EventArgs e)
		{
			if (Common.MsgYes_No("Bạn có chắc chắn load danh mục tài khoản vào phân quyền tài khoản không?"))
			{
				string strSQLExec = @"
					INSERT INTO R00PermissionTk (Member_ID, Tk, Allow_Access, Allow_New, Allow_Edit, Allow_Delete, Allow_View)
						SELECT '" + strMember_ID + @"' AS Member_ID, Tk, 1, 1, 1, 1, 1 
							FROM R81DmTk 
							WHERE LEN(Tk) = 3 AND Tk NOT LIKE 'N%' AND 
								Tk NOT IN (SELECT Tk FROM R00PermissionTk WHERE Member_ID = '" + strMember_ID + @"')";

				//FillData lại cho phân quyền tài khoản
				if (SQLExec.Execute(strSQLExec))
				{
					string[] strArrParameter_Name = new string[] { "Member_ID", "Tk" };
					object[] objArrParameter_Value = new object[] { this.strMember_ID, "" };

					dtPermissionTk = SQLExec.ExecuteReturnDt("Sp_GetPermissionTk", strArrParameter_Name, objArrParameter_Value, CommandType.StoredProcedure);

					bdsPermissionTk.DataSource = dtPermissionTk;
					dgvPermissionTk.DataSource = bdsPermissionTk;
				}
			}
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion

	}
}

