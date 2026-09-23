using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Element;
using RosySystem;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Public;

namespace RosyControllerTMN
{
	public partial class frmGroup : RosySystem.Customize.frmView
    {
        #region Khai bao bien

        private DataTable dtGroup;
		private DataTable dtUser;
		private DataTable dtMemberGroup;

		private DataRow drGroup;
		private DataRow drUser;
		private DataRow drMemberGroup;

		private BindingSource bdsGroup = new BindingSource();
		private BindingSource bdsUser = new BindingSource();
		private BindingSource bdsMemberGroup = new BindingSource();

		private bool bIsCurrentNodeUser = true;

		private ContextMenuStrip cmsGroup = new ContextMenuStrip();
		private ContextMenuStrip cmsGroupNew = new ContextMenuStrip();
		private ContextMenuStrip cmsGroupUser = new ContextMenuStrip();
		private ContextMenuStrip cmsGroupUserAdd = new ContextMenuStrip();
		private ContextMenuStrip cmsUser = new ContextMenuStrip();
		private ContextMenuStrip cmsUserNew = new ContextMenuStrip();

		#endregion

        #region contructor

        public frmGroup()
        {
            InitializeComponent();

			this.tvGroup.AfterSelect += new TreeViewEventHandler(tvGroup_AfterSelect);
			this.tvGroup.NodeMouseClick += new TreeNodeMouseClickEventHandler(tvGroup_NodeMouseClick);

			this.lvUser.MouseUp += new MouseEventHandler(lvUser_MouseUp);
			this.lvUser.KeyDown += new KeyEventHandler(lvUser_KeyDown);
			this.lvUser.Resize += new EventHandler(lvUser_Resize);

			this.btNew.Click += new EventHandler(btNew_Click);
			this.btEdit.Click += new EventHandler(btEdit_Click);
			this.btDelete.Click += new EventHandler(btDelete_Click);
			this.btGet_User.Click += new EventHandler(btGet_User_Click);
            this.btExit.Click += new EventHandler(btExit_Click);
		}

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		new public void Load()
		{
			this.BuildGroup();
			this.BuildUser();
			this.BuildContextMenu();

			this.Show();
		}
		
		#endregion

		#region Build, FillData

        private void BuildGroup()
        {
            tvGroup.Nodes.Clear();

            dtGroup = DataTool.SQLGetDataTable("R00Member", "*", "Member_Type = 'G'", "Member_ID");

            bdsGroup.DataSource = dtGroup;

            //NodeUser
            TreeNode nodUser = new TreeNode("Người dùng");
            nodUser.Name = "nodUser";
            nodUser.Text = Languages.GetLanguage("USER", Element.sysLanguage);
            nodUser.ContextMenuStrip = cmsUserNew;
            nodUser.ImageKey = "User";
            nodUser.SelectedImageKey = "User";
  
            if (Element.sysIs_Admin)
            {
                //NodeGroup
                TreeNode nodGroup = new TreeNode("Nhóm người dùng");
                nodGroup.Name = "nodGroup";
                nodGroup.Text = Languages.GetLanguage("GROUP", Element.sysLanguage);
                nodGroup.ContextMenuStrip = cmsGroupNew;
                nodGroup.ImageKey = "Group";
                nodGroup.SelectedImageKey = "Group";

                for (int i = 0; i <= (dtGroup.Rows.Count - 1); i++)
                {
                    string strGroup_ID = dtGroup.Rows[i]["Member_ID"].ToString().Trim();
                    string strGroup_Name = dtGroup.Rows[i]["Member_Name"].ToString().Trim();

                    nodGroup.Nodes.Add(strGroup_ID, strGroup_Name, "Group", "Group");
                    nodGroup.Nodes[i].ContextMenuStrip = cmsGroup;
                }
                this.tvGroup.Nodes.AddRange(new TreeNode[] { nodUser, nodGroup });
            }
            else
                this.tvGroup.Nodes.AddRange(new TreeNode[] { nodUser});

            this.tvGroup.ExpandAll();

                        
        }
		private void BuildUser()
		{
			lvUser.strZone = "USER";
			lvUser.BuildListView(this.isLookup);
		}

        private void Build()
        {
            //dgvPermissionModule.strZone = "PERMISSION_MODULE";
            //dgvPermissionModule.BuildGridView();

            //dgvPermissionCt.strZone = "PERMISSION";
            //dgvPermissionCt.BuildGridView();
        }

		private void FillUser()
		{
            string strKey = string.Empty;

            if(Element.sysIs_Admin)
			    strKey = "Member_Type = 'U' ";
            else
                strKey = "Member_Type = 'U' AND Member_ID = '" + Element.sysUser_Id + "'";

			dtUser = DataTool.SQLGetDataTable("R00Member", "*", strKey, "Member_ID");

			bdsUser.DataSource = dtUser;
			lvUser.DataSource = bdsUser;

			if (bdsUser.Count > 0)
				this.lvUser.Items[0].Selected = true;

			foreach (ListViewItem lvi in lvUser.Items)
			{
				lvi.ImageKey = "User";
			}
		}

		private void FillGroupUser(string strGroup_ID)
		{
			string strQuery = 
				"SELECT T1.*, T2.Member_Name, T2.Is_Admin, T2.Member_ID_Allow " +
					" FROM R00MemberGroup T1 INNER JOIN R00Member T2 " + 
						" ON T1.Member_ID = T2.Member_ID " + 
					" WHERE T1.Member_Group_ID = '" + strGroup_ID + "'";

			dtMemberGroup = SQLExec.ExecuteReturnDt(strQuery);

			bdsMemberGroup.DataSource = dtMemberGroup;
			lvUser.DataSource = bdsMemberGroup;

			if (bdsMemberGroup.Count > 0)
				lvUser.Items[0].Selected = true;

			foreach (ListViewItem lvi in lvUser.Items)
			{
				lvi.ImageKey = "User";
			}
		}

		private void BuildContextMenu()
		{		
			#region cmsGroup: Add, Edit, Delete, AddUser
			ToolStripMenuItem tsmiGroupAdd = new ToolStripMenuItem();
			ToolStripMenuItem tsmiGroupEdit = new ToolStripMenuItem();
			ToolStripMenuItem tsmiGroupDelete = new ToolStripMenuItem();
			ToolStripMenuItem tsmiGroupAddUser = new ToolStripMenuItem();
			ToolStripMenuItem tsmiGroupPermission = new ToolStripMenuItem();

			tsmiGroupAdd.Click += new System.EventHandler(this.cmsGroupAdd_Click);
			tsmiGroupEdit.Click += new System.EventHandler(this.cmsGroupEdit_Click);
			tsmiGroupDelete.Click += new System.EventHandler(this.cmsGroupDelete_Click);
			tsmiGroupAddUser.Click += new System.EventHandler(this.cmsGroupAddUser_Click);
			tsmiGroupPermission.Click += new EventHandler(tsmiGroupPermission_Click);

			tsmiGroupAdd.Name = "cmsGroupAdd";
			//tsmiGroupAdd.Image = 
			tsmiGroupAdd.Text = "&1. " + Languages.GetLanguage("New_Group");

			tsmiGroupEdit.Name = "cmsGroupEdit";
			tsmiGroupEdit.Text = "&2. " + Languages.GetLanguage("Edit_Group");

			tsmiGroupDelete.Name = "cmsGroupDelete";
			tsmiGroupDelete.Text = "&3. " + Languages.GetLanguage("Delete_Group");

			tsmiGroupAddUser.Name = "cmsGroupAddUser";
			tsmiGroupAddUser.Text = "&4. " + Languages.GetLanguage("New_User");

			tsmiGroupPermission.Name = "cmsGroupPermission";
			tsmiGroupPermission.Text = "&5. " + Languages.GetLanguage("Permission");

			cmsGroup.Items.Clear();
			cmsGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
					tsmiGroupAdd,
					tsmiGroupEdit,
					tsmiGroupDelete,
					tsmiGroupAddUser,
					tsmiGroupPermission});

			if (!Element.sysIs_Admin)
			{
				foreach (ToolStripItem tsi in cmsGroup.Items)
				{
					tsi.Enabled = false;
				}
			}

			#endregion

			#region cmsGroupNew: Add
			ToolStripMenuItem tsmiGroupNewAdd = new ToolStripMenuItem();

			tsmiGroupNewAdd.Click += new EventHandler(this.cmsGroupAdd_Click);

			tsmiGroupNewAdd.Name = "cmsGroupAdd";
			tsmiGroupNewAdd.Text = "&5. " + Languages.GetLanguage("New_Group");

			this.cmsGroupNew.Items.Clear();
			this.cmsGroupNew.Items.Add(tsmiGroupNewAdd);

			if (!Element.sysIs_Admin)
			{
				foreach (ToolStripItem tsi in cmsGroupNew.Items)
				{
					tsi.Enabled = false;
				}
			}

			#endregion

			#region cmsUser: Add, Edit, Delete, ChangePass, Permission

			ToolStripMenuItem cmsUserAdd = new ToolStripMenuItem();
			ToolStripMenuItem cmsUserEdit = new ToolStripMenuItem();
			ToolStripMenuItem cmsUserDelete = new ToolStripMenuItem();
			ToolStripMenuItem cmsUserChangePass = new ToolStripMenuItem();
			ToolStripMenuItem cmsUserPermission = new ToolStripMenuItem();
            ToolStripMenuItem cmsUserCheckPermission = new ToolStripMenuItem();


			cmsUserAdd.Click += new System.EventHandler(this.cmsUserAdd_Click);
			cmsUserEdit.Click += new System.EventHandler(this.cmsUserEdit_Click);
			cmsUserDelete.Click += new System.EventHandler(this.cmsUserDelete_Click);
			cmsUserChangePass.Click += new System.EventHandler(this.cmsUserChangePass_Click);
			cmsUserPermission.Click += new EventHandler(cmsUserPermission_Click);
            cmsUserCheckPermission.Click += new EventHandler(cmsUserCheckPermission_Click);

			cmsUserAdd.Name = "cmsUserAdd";
			cmsUserAdd.Text = "&1. " + Languages.GetLanguage("New_User");

			cmsUserEdit.Name = "cmsUserEdit";
			cmsUserEdit.Text = "&2. " + Languages.GetLanguage("Edit_User");

			cmsUserDelete.Name = "cmsUserDelete";
			cmsUserDelete.Text = "&3. " + Languages.GetLanguage("Delete_User");

			cmsUserChangePass.Name = "cmsUserChangePass";
			cmsUserChangePass.Text = "&4. " + Languages.GetLanguage("Change_Pass");

			cmsUserPermission.Name = "cmsUserPermission";
			cmsUserPermission.Text = "&5. " + Languages.GetLanguage("Permission");

            cmsUserCheckPermission.Name = "cmsUserCheckPermission";
            cmsUserCheckPermission.Text = "&6. " + Languages.GetLanguage("CheckPermission");

			this.cmsUser.Items.Clear();
			this.cmsUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				cmsUserAdd,
				cmsUserEdit,
				cmsUserDelete,
				cmsUserChangePass,
				cmsUserPermission,
                cmsUserCheckPermission});

			if (!Element.sysIs_Admin)
			{
				foreach (ToolStripItem tsi in cmsUser.Items)
				{
					if (!(tsi.Name == "cmsUserEdit" || tsi.Name == "cmsUserChangePass"))
						tsi.Enabled = false;
				}
			}

			#endregion

			#region	cmsUserNew: Add
			ToolStripMenuItem tsmiUserNewAdd = new ToolStripMenuItem();

			tsmiUserNewAdd.Click += new System.EventHandler(this.cmsUserAdd_Click);

			tsmiUserNewAdd.Name = "cmsUserNewAdd";
			tsmiUserNewAdd.Text = "&1. " + Languages.GetLanguage("New_User");

			this.cmsUserNew.Items.Clear();
			this.cmsUserNew.Items.Add(tsmiUserNewAdd);

			if (!Element.sysIs_Admin)
			{
				foreach (ToolStripItem tsi in cmsUserNew.Items)
				{
					tsi.Enabled = false;
				}
			}

			#endregion

			#region cmsGroupUser: Add, Delete
			ToolStripMenuItem tsmiGroupUserAdd = new ToolStripMenuItem();
			ToolStripMenuItem tsmiGroupUserDelete = new ToolStripMenuItem();

			tsmiGroupUserAdd.Click += new System.EventHandler(this.cmsGroupUserAdd_Click);
			tsmiGroupUserDelete.Click += new System.EventHandler(this.cmsGroupUserDelete_Click);

			tsmiGroupUserAdd.Name = "cmsUserAdd";
			tsmiGroupUserAdd.Text = "&1. " + Languages.GetLanguage("New_User");

			tsmiGroupUserDelete.Name = "cmsUserDelete";
			tsmiGroupUserDelete.Text = "&2. " + Languages.GetLanguage("Delete_User");

			this.cmsGroupUser.Items.Clear();
			this.cmsGroupUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				tsmiGroupUserAdd,
				tsmiGroupUserDelete});

			if (!Element.sysIs_Admin)
			{
				foreach (ToolStripItem tsi in cmsGroupUser.Items)
				{
					tsi.Enabled = false;
				}
			}

			#endregion

			#region cmsGroupUserAdd: Add
			ToolStripMenuItem tsmiGroupUserNewAdd = new ToolStripMenuItem();

			tsmiGroupUserNewAdd.Click += new System.EventHandler(this.cmsGroupUserAdd_Click);

			tsmiGroupUserNewAdd.Name = "cmsUserAdd";
			tsmiGroupUserNewAdd.Text = "&1. " + Languages.GetLanguage("New_User");

			this.cmsGroupUserAdd.Items.Clear();
			this.cmsGroupUserAdd.Items.Add(tsmiGroupUserNewAdd);

			if (!Element.sysIs_Admin)
			{
				foreach (ToolStripItem tsi in cmsGroupUserAdd.Items)
				{
					tsi.Enabled = false;
				}
			}
			#endregion

		}

		#endregion

		#region Edit

		private void Edit_Group(enuEdit enuNew_Edit)
		{
			if (((tvGroup.SelectedNode == tvGroup.Nodes["nodUser"]) || ((tvGroup.SelectedNode == tvGroup.Nodes["nodGroup"]))) && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsGroup.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			string strGroup_ID = tvGroup.SelectedNode.Name;

			bdsGroup.Position = bdsGroup.Find("Member_ID", strGroup_ID);

			if (bdsGroup.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsGroup.Current).Row, ref drGroup);
			else
				drGroup = dtGroup.NewRow();

			drGroup["Member_Type"] = "G";

			frmGroup_Edit frmEdit = new frmGroup_Edit();
			frmEdit.Load(enuNew_Edit, ref drGroup);

			if (enuNew_Edit == enuEdit.New)
				drGroup["Locked"] = false;

			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsGroup.Position >= 0)
						dtGroup.ImportRow(drGroup);
					else
						dtGroup.Rows.Add(drGroup);
				}
				else
					Common.CopyDataRow(drGroup, ((DataRowView)bdsGroup.Current).Row);

				dtGroup.AcceptChanges();
				BuildGroup();
			}
			else
				dtGroup.RejectChanges();
		}

		private void Edit_User(enuEdit enuNew_Edit)
		{
			if ((bdsUser.Position < 0) && (enuNew_Edit != enuEdit.Edit))
				return;

			lvUser.MoveDataSourceToCurrentRow();

			if (bdsUser.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsUser.Current).Row, ref drUser);
			else
				drUser = dtUser.NewRow();

			if (enuNew_Edit == enuEdit.Edit || enuNew_Edit == enuEdit.New)
			{
				string strUser_ID = lvUser.SelectedItems[0].Text;
				if (!Element.sysIs_Admin && !Common.CheckPermission(this.Object_ID,enuPermission_Type.Allow_Edit))
				{
                    Common.MsgCancel("Không được phép thêm hoặc sửa user");
					return;
				}
			}

			drUser["Member_Type"] = "U";

			frmUser_Edit frmEdit = new frmUser_Edit();
			frmEdit.Load(enuNew_Edit, ref drUser);

			if (enuNew_Edit == enuEdit.New)
				drUser["Locked"] = false;

			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsUser.Position >= 0)
						dtUser.ImportRow(drUser);
					else
						dtUser.Rows.Add(drUser);
				}
				else
				{
					Common.CopyDataRow(drUser, ((DataRowView)bdsUser.Current).Row);
				}

				dtUser.AcceptChanges();
				FillUser();
			}
			else
				dtUser.RejectChanges();
		}

		private void User_ChangePass()
		{
			if (bdsUser.Position < 0)
				return;

			lvUser.MoveDataSourceToCurrentRow();

			drUser = ((DataRowView)bdsUser.Current).Row;

			string strUser_ID = lvUser.SelectedItems[0].Text;

			if (!Element.sysIs_Admin && strUser_ID != Element.sysUser_Id)
			{
				Common.MsgCancel("Không thể đổi mật khẩu " + strUser_ID);
				return;
			}

			frmUser_ChangePass frm = new frmUser_ChangePass();
			frm.Load(ref drUser);

			if (frm.isAccept)
			{
				Common.MsgOk("Đã đổi xong mật khẩu!");
			}
		}

		private void Add_Group_Member()
		{
			string strGroup_ID = tvGroup.SelectedNode.Name;

			drMemberGroup = dtMemberGroup.NewRow();

			//Lookup User
			string strValue = "";
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Member_ID", strValue, bRequire, "Member_Type = 'U'");

			//if (!frmLookup.bIsEnter)
			//    return;

			if (drLookup != null)
			{
				drMemberGroup["Member_Group_ID"] = strGroup_ID;
				drMemberGroup["Member_ID"] = drLookup["Member_ID"];

				//Luu du lieu xuong CSDL
				if (DataTool.SQLUpdate(enuEdit.New, "R00MemberGroup", ref drMemberGroup))
				{
					dtMemberGroup.Rows.Add(drMemberGroup);

					dtMemberGroup.AcceptChanges();

					FillGroupUser(strGroup_ID);
				}
				else
					dtMemberGroup.RejectChanges();
			}
		}

		#endregion 

		#region Delete
		private void Group_Delete()
		{
			//Move con tro den dong hien hanh tuong ung tren tv
			string strGroup_ID = this.tvGroup.SelectedNode.Name;

			bdsGroup.Position = bdsGroup.Find("Member_ID", strGroup_ID);

			if (bdsGroup.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsGroup.Current).Row;
			
			if (!Common.MsgYes_No("Bạn có muốn xóa không?", "N"))
				return;

			if (DataTool.SQLCheckExist("R00MemberGroup", "Member_ID", drCurrent["Member_ID"]))
			{
				Common.MsgCancel("Nhóm : {" + drCurrent["Member_Name"].ToString() + "}  đang chứa người dùng!");
				return;
			}

			if (DataTool.SQLDelete("R00Member", drCurrent))
			{
				bdsGroup.RemoveAt(bdsGroup.Position);
				dtGroup.AcceptChanges();

				BuildGroup();
			}
		}

		private void User_Delete()
		{
			if (!lvUser.MoveDataSourceToCurrentRow())
				return;

			if (bdsUser.Position < 0 || lvUser.SelectedItems.Count <= 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsUser.Current).Row;
            
            if (!Element.sysIs_Admin && !Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
            {
                Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
                return;
            }

			if ((bool)drCurrent["Locked"])
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Can not delete admin" : "Không thể xóa người quản trị";
				Common.MsgCancel(strMsg);
				return;
			}

			if (!Common.MsgYes_No("Bạn có muốn xóa không", "N"))
				return;

			if (DataTool.SQLDelete("R00MemberGroup", "Member_ID", ((DataRowView)bdsUser.Current)["Member_ID"]))
			{
				if (DataTool.SQLDelete("R00Member", drCurrent))
				{
					bdsUser.RemoveAt(bdsUser.Position);
					dtUser.AcceptChanges();

					FillUser();
				}
			}
		}

		private void Group_User_Delete()
		{
			if (!lvUser.MoveDataSourceToCurrentRow())
				return;

			if (bdsUser.Position < 0 || lvUser.SelectedItems.Count <= 0)
				return;

			DataRow drCurrent = ((DataRowView)this.bdsMemberGroup.Current).Row;

			if (!Common.MsgYes_No("Bạn có muốn xóa không", "N"))
				return;

			if (DataTool.SQLDelete("R00MemberGroup", drCurrent))
				FillGroupUser(tvGroup.SelectedNode.Name.Trim());
		}

        #endregion

		#region Su kien

		private void tvGroup_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (this.tvGroup.SelectedNode == this.tvGroup.Nodes["nodUser"])
			{
				this.bIsCurrentNodeUser = true;
				this.FillUser();
			}
			else
			{
				this.bIsCurrentNodeUser = false;
				this.FillGroupUser(this.tvGroup.SelectedNode.Name.Trim());
			}
		}

		private void tvGroup_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			this.tvGroup.SelectedNode = e.Node;
		}

		private void lvUser_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (this.bIsCurrentNodeUser)

					if (this.lvUser.SelectedIndices.Count > 0)
						this.cmsUser.Show(this.lvUser, e.Location);
					else
						this.cmsUserNew.Show(this.lvUser, e.Location);

				else
					if (this.lvUser.SelectedIndices.Count > 0)
						this.cmsGroupUser.Show(this.lvUser, e.Location);
					else
						this.cmsGroupUserAdd.Show(this.lvUser, e.Location);
			}
		}
		private void lvUser_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Shift && e.KeyCode == Keys.F10)
			{
				if (this.bIsCurrentNodeUser)
				{
					if (this.lvUser.SelectedIndices.Count > 0)
						this.cmsUser.Show(this.lvUser, lvUser.GetCurrentPoint());
					else
						this.cmsUserNew.Show(this.lvUser, lvUser.GetCurrentPoint());
				}
				else
				{
					if (this.lvUser.SelectedIndices.Count > 0)
						this.cmsGroupUser.Show(this.lvUser, lvUser.GetCurrentPoint());
					else
						this.cmsGroupUserAdd.Show(this.lvUser, lvUser.GetCurrentPoint());
				}
			}
		}
		private void lvUser_Resize(object sender, EventArgs e)
		{
			lvUser.ResizeListView();
		}

		//cmsGroup
		private void cmsGroupAdd_Click(object sender, EventArgs e)
		{
			this.Edit_Group(enuEdit.New);
		}
		private void cmsGroupEdit_Click(object sender, EventArgs e)
		{
			this.Edit_Group(enuEdit.Edit);
		}
		private void cmsGroupDelete_Click(object sender, EventArgs e)
		{
			this.Group_Delete();
		}
		private void cmsGroupAddUser_Click(object sender, EventArgs e)
		{
			this.Add_Group_Member();
		}
		private void tsmiGroupPermission_Click(object sender, EventArgs e)
		{
			int iPosition = bdsGroup.Find("Member_ID", tvGroup.SelectedNode.Name);

			if (iPosition > 0)
				bdsGroup.Position = iPosition;
			else
				return;

			drGroup = ((DataRowView)bdsGroup.Current).Row;

			frmPermission frmPermission = new frmPermission();
			frmPermission.MdiParent = this.MdiParent;
			frmPermission.Load(Convert.ToString(drGroup["Member_ID"]), "GROUP");
		}

		//cmsUser
		private void cmsUserAdd_Click(object sender, EventArgs e)
		{
			this.Edit_User(enuEdit.New);
		}
		private void cmsUserEdit_Click(object sender, EventArgs e)
		{
			this.Edit_User(enuEdit.Edit);
		}
		private void cmsUserDelete_Click(object sender, EventArgs e)
		{
			this.User_Delete();
		}
		private void cmsUserChangePass_Click(object sender, EventArgs e)
		{
			this.User_ChangePass();
		}
        private void cmsUserCheckPermission_Click(object sender, EventArgs e)
        {
        }
		private void cmsUserPermission_Click(object sender, EventArgs e)
		{
			if ((bdsUser.Position < 0))
				return;

			lvUser.MoveDataSourceToCurrentRow();

			drUser = ((DataRowView)bdsUser.Current).Row;

			if ((bool)drUser["Is_Admin"])
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Can not set permission for admin" : "Không cấp quyền cho người quản trị";
				Common.MsgOk(strMsg);
				return;
			}

			frmPermission frmPermission = new frmPermission();
			frmPermission.MdiParent = this.MdiParent;
			frmPermission.Load((string)drUser["Member_ID"], "USER");

		}

		//cmsGroupUser
		private void cmsGroupUserAdd_Click(object sender, EventArgs e)
		{
			this.Add_Group_Member();
		}
		private void cmsGroupUserDelete_Click(object sender, EventArgs e)
		{
			this.Group_User_Delete();
		}

		//Button
		//Get User from Computer
		void btGet_User_Click(object sender, EventArgs e)
		{
			frmGetUsers frmGetUsers = new frmGetUsers();
			frmGetUsers.Load();

			if (frmGetUsers.isAccept)
			{
				this.FillUser();
			}
		}

		void btNew_Click(object sender, EventArgs e)
		{
			this.Edit_User(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			this.Edit_User(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			this.User_Delete();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == Keys.Tab)
			{
				if (tvGroup.Focused)
					lvUser.Focus();
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		#endregion
	}
}