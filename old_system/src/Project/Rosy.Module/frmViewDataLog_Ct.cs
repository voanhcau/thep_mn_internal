using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Customize;
using System.Collections;

namespace RosyModule
{
	public partial class frmDataLog_Ct : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		private DataTable dtDataLogDetail;
		private BindingSource bdsDataLogDetail = new BindingSource();
		private DataRow drCurrent;
		private rsDataGridView dgvDataLogDetail = new rsDataGridView();

		#endregion

		#region Contructor

		public frmDataLog_Ct()
		{
			InitializeComponent();
		}

		new public void Load(DataRow drCurrent)
		{
			this.drCurrent = drCurrent;
			Build();
			FillData();
			BindingLanguage();

			this.ShowDialog();
		}

		private void Build()
		{
			dgvDataLogDetail.Dock = DockStyle.Fill;
			this.Controls.Add(dgvDataLogDetail);
		}

		private void FillData()
		{

			string strTableName = (string)SQLExec.ExecuteReturnValue(@"SELECT Table_Name 
																			FROM R00DMTABLE 
																			WHERE Table_Name0 IN (SELECT Table_Ct 
																										FROM R00DMCT 
																										WHERE Ma_Ct = '" + drCurrent["Ma_Ct"] + "')");
			string strTableName0 = (string)SQLExec.ExecuteReturnValue(@"SELECT Table_Name0 
																			FROM R00DMTABLE 
																			WHERE Table_Name0 IN (SELECT Table_Ct 
																										FROM R00DMCT 
																										WHERE Ma_Ct = '" + drCurrent["Ma_Ct"] + "')");
			string strStt = drCurrent["Stt"].ToString();
			string strZone = "";
			string strZoneHeader = "";

			if (Collection.Zones.Select("Zone = '" + strTableName + "'").Length > 0)
			{
				strZone = strTableName; //Lấy Table_Name làm Alias
				strZoneHeader = strTableName;
			}
			else //Lấy Zone trong chứng từ (R00DmCt)
			{
				DataTable dtDmCt = SQLExec.ExecuteReturnDt("SELECT * FROM R00DmCt WHERE Table_Ct = '" + strTableName0 + "'"); //Lấy Zone_EditCt1 làm Zone
				if (dtDmCt.Rows.Count > 0)
				{
					strZone = dtDmCt.Rows[0]["Zone_EditCt1"].ToString();
				}
			}

			dgvDataLogDetail.AutoGenerateColumns = false;
			dgvDataLogDetail.DataSource = null;

			bdsDataLogDetail.DataSource = null;

			//FillData
			if (strTableName.StartsWith("CT")) //Chứng từ
			{
				dgvDataLogDetail.strZone = strZone;
				dgvDataLogDetail.BuildGridView();

				//Bổ sung thêm 1 số cột
				DataGridViewTextBoxColumn dgvc;

				dgvc = new DataGridViewTextBoxColumn();
				dgvc.Name = dgvc.DataPropertyName = "Command";
				dgvc.Width = 60;
				dgvDataLogDetail.Columns.Insert(0, dgvc);

				if (!dgvDataLogDetail.Columns.Contains("Ngay_Ct"))
				{
					dgvc = new DataGridViewTextBoxColumn();
					dgvc.Name = dgvc.DataPropertyName = "Ngay_Ct";
					dgvc.Width = 100;
					dgvDataLogDetail.Columns.Insert(3, dgvc);
				}
				if (!dgvDataLogDetail.Columns.Contains("So_Ct"))
				{
					dgvc = new DataGridViewTextBoxColumn();
					dgvc.Name = dgvc.DataPropertyName = "So_Ct";
					dgvc.Width = 100;
					dgvDataLogDetail.Columns.Insert(4, dgvc);
				}
				if (!dgvDataLogDetail.Columns.Contains("Dien_Giai"))
				{
					dgvc = new DataGridViewTextBoxColumn();
					dgvc.Name = dgvc.DataPropertyName = "Dien_Giai";
					dgvc.Width = 100;
					dgvDataLogDetail.Columns.Insert(5, dgvc);
				}
				if (!dgvDataLogDetail.Columns.Contains("Create_Log"))
				{
					dgvc = new DataGridViewTextBoxColumn();
					dgvc.Name = dgvc.DataPropertyName = "Create_Log";
					dgvc.Width = 100;
					dgvDataLogDetail.Columns.Add(dgvc);
				}

				if (!dgvDataLogDetail.Columns.Contains("LastModify_Log"))
				{
					dgvc = new DataGridViewTextBoxColumn();
					dgvc.Name = dgvc.DataPropertyName = "LastModify_Log";
					dgvc.Width = 100;
					dgvDataLogDetail.Columns.Add(dgvc);
				}
				//Thêm cột xong

				dtDataLogDetail = SQLExec.ExecuteReturnDt("Sp_ViewDataLog_Ct", new string[] { "Table_Name", "Stt" }, new object[] { strTableName, strStt }, CommandType.StoredProcedure);

				bdsDataLogDetail.DataSource = dtDataLogDetail;
				dgvDataLogDetail.DataSource = bdsDataLogDetail;
				dgvDataLogDetail.ResizeGridView();

			}
		}

		#endregion

	}
}
