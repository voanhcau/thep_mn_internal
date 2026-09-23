using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Customize;
using System.DirectoryServices;
using RosySystem.Data;
using RosySystem.Common;

namespace RosyControllerTMN
{
	public partial class frmGetUsers : frmEdit
	{
		#region Variable

		private DataTable dtGetUsers = new DataTable();
		private BindingSource bdsGetUsers = new BindingSource();

		#endregion

		#region Constructor

		public frmGetUsers()
		{
			InitializeComponent();
			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load()
		{
			this.Text = "Lấy danh sách user";

			this.Build();
			this.FillData();
			this.BindingLanguage();
			this.ShowDialog();
		}

		#endregion

		#region Method

		private void Build()
		{
			this.dgvGetUsers.bSortMode = true;
			this.dgvGetUsers.strZone = "GETUSERS";
			this.dgvGetUsers.BuildGridView();

			this.dgvGetUsers.ReadOnly = false;
	
			if (this.dgvGetUsers.Columns.Contains("Member_ID"))
				this.dgvGetUsers.Columns["Member_ID"].ReadOnly = true;
		}

		private void FillData()
		{
			dtGetUsers = DataTool.SQLGetDataTable("R00MEMBER", null, "(0 = 1)", null);

			DataColumn dcChon = new DataColumn("Chon", typeof(bool));
			dcChon.DefaultValue = false;
			dtGetUsers.Columns.Add(dcChon);

			DirectoryEntry directoryEntry = new DirectoryEntry("WinNT://" + Environment.UserDomainName);
			foreach (DirectoryEntry child in directoryEntry.Children)
			{
				if (child.SchemaClassName.Equals("User", StringComparison.OrdinalIgnoreCase))
				{
					drEdit = dtGetUsers.NewRow();

					if (DataTool.SQLCheckExist("R00Member", "Member_ID", child.Name.ToUpper()))
						continue;

					drEdit["Member_ID"] = child.Name.ToUpper();
					drEdit["Member_Type"] = "U";
					drEdit["Member_Name"] = child.Name;
					drEdit["Locked"] = false;
					drEdit["Is_Admin"] = false;

					dtGetUsers.Rows.Add(drEdit);
				}

			}
			dtGetUsers.AcceptChanges();

			bdsGetUsers.DataSource = dtGetUsers;
			dgvGetUsers.DataSource = bdsGetUsers;
			dgvGetUsers.ClearSelection();

			bdsGetUsers.Position = 0;
		}

		private bool Save()
		{
			if (dtGetUsers.Rows.Count > 0)
			{
				DataRow drNew = dtGetUsers.NewRow();
				foreach (DataRow dr in dtGetUsers.Rows)
				{
					if (!(bool)dr["Chon"])
						continue;

					drNew["Member_ID"] = ((string)dr["Member_ID"]).ToUpper();
					drNew["Member_Type"] = "U";
					drNew["Member_Name"] = dr["Member_Name"];
					drNew["Locked"] = false;
					drNew["Is_Admin"] = false;
					drNew["Create_Log"] = Common.GetCurrent_Log();

					//Luu vao CSDL
					if (!DataTool.SQLUpdate(enuNew_Edit, "R00Member", ref drNew))
						continue;
				}
			}
			else
				return false;

			return true;
		}

		#endregion

		#region Event

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

		#endregion
	}
}
