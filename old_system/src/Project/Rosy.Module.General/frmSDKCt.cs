using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Element;

namespace RosyModule.General
{
	public partial class frmSDKCt : RosySystem.Customize.frmView
	{
		#region Fields

		public DataTable dtSDK;
		private DataRow drCurrent;
		private BindingSource bdsSDK = new BindingSource();
		private rsDataGridView dgvSDK = new rsDataGridView();
		private string strTk = string.Empty;

		#endregion

		#region Methods

		public frmSDKCt()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmViewSDK_KeyDown);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		public void Load(string strTk)
		{
			this.strTk = strTk;

			this.Load();
		}

		private void Build()
		{
			this.dgvSDK.strZone = "SDKCT_VIEW";
			this.dgvSDK.Dock = DockStyle.Fill;

			this.Controls.Add(dgvSDK);

			this.dgvSDK.BuildGridView();
		}

		private void FillData()
		{
			string[] strArrName = { "Tk", "Nam", "Child", "Ma_DvCs" };
			object[] objArrValue = { this.strTk, Element.sysWorkingYear, true, Element.sysMa_DvCs };

			dtSDK = SQLExec.ExecuteReturnDt("Sp_GetSDK", strArrName, objArrValue, CommandType.StoredProcedure);

			bdsSDK.DataSource = dtSDK;
			bdsSDK.Position = 0;
			//bdsSDK.Filter = "Tk = '" + this.strTk + "' AND Have_Child <> 1";

			dgvSDK.DataSource = bdsSDK;

			this.bdsSearch = bdsSDK;
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsSDK.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsSDK.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsSDK.Current).Row, ref drCurrent);
			else
				drCurrent = dtSDK.NewRow();

			frmSDK_Edit frmEdit = new frmSDK_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsSDK.Position >= 0)
						dtSDK.ImportRow(drCurrent);
					else
						dtSDK.Rows.Add(drCurrent);

					bdsSDK.Position = bdsSDK.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsSDK.Current).Row);

				dtSDK.AcceptChanges();
			}
			else
				dtSDK.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsSDK.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsSDK.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R80SDK", drCurrent))
			{
				bdsSDK.RemoveAt(bdsSDK.Position);
				dtSDK.AcceptChanges();
			}
		}

		#endregion

		#region Events

		void frmViewSDK_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F2:
					this.Edit(enuEdit.New);
					return;

				case Keys.F3:
					this.Edit(enuEdit.Edit);
					return;

				case Keys.F8:
					this.Delete();
					return;
			}
		}

		#endregion
	}
}
