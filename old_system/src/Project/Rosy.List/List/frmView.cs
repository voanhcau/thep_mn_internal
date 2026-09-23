using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;
using RosySystem.Data;

namespace RosyList
{
	public partial class frmView : RosySystem.Customize.frmView
	{
		public rsPanel pnlToolStrip = new rsPanel();
		public toolStripView tsView = new toolStripView();
		public toolStripEdit tsEdit = new toolStripEdit();

		public frmView()
		{
			InitializeComponent();

			this.splitcContent.Panel1.ControlAdded += new ControlEventHandler(Panel1_ControlAdded);

			this.btNew.Click += new EventHandler(btNew_Click);
			this.btEdit.Click += new EventHandler(btEdit_Click);
			this.btDelete.Click += new EventHandler(btDelete_Click);
			this.btMerge.Click += new EventHandler(btMerge_Click);
			this.btExit.Click += new EventHandler(btExit_Click);

			//btReplace.Click += new EventHandler(btReplace_Click);
		}

		//void btReplace_Click(object sender, EventArgs e)
		//{

		//    frmReplace frm = new frmReplace();
		//    frm.Load();

		//    if (frm.isAccept == true)
		//    {
		//        foreach (datarow dr in collection)
		//        {

		//        }
		//    }
			
		//}

		//Tạo ToolStrip khi Lookup danh mục
		public void LoadToolStrip()
		{
			this.pnlToolStrip.Dock = DockStyle.Top;
			this.pnlToolStrip.Height = 35;
			this.pnlToolStrip.Controls.Add(tsView);
			this.pnlToolStrip.Controls.Add(tsEdit);
			tsEdit.Left = tsView.Right;
			this.Controls.Add(pnlToolStrip);

			this.splitcContent.Top = this.pnlToolStrip.Bottom;
			this.splitcContent.Height = this.splitcContent.Height - this.pnlToolStrip.Height;
		}

		//Con trỏ nhảy vào Lưới
		void Panel1_ControlAdded(object sender, ControlEventArgs e)
		{
			if (e.Control.GetType().Name == "rsDataGridView" || e.Control.GetType().Name == "rsTreeList")
			{
				this.ActiveControl = e.Control;
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F8)
			{
				//Kiem tra Permission
				if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
					this.Delete();
				else
					Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));

				return;
			}
			else if (e.KeyCode == Keys.F4 && !e.Control && !e.Shift && !e.Alt)
			{
				if (isLookup && tsView.Visible)
				{
					if (!tsView.txtFilter.Focused)
						tsView.txtFilter.Focus();
					else
						this.SelectNextControl(tsView, true, true, true, true);
				}
				else
					base.OnKeyDown(e);
			}
			else
			{
				base.OnKeyDown(e);
			}
		}

		void btNew_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			//Kiem tra Permission
			if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
				this.Delete();
			else
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
		}

		void btMerge_Click(object sender, EventArgs e)
		{
			this.MergeID();
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			if (isLookup)
				this.LoadToolStrip();

			base.OnShown(e);
		}
	}
}
