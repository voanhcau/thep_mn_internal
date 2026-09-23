using System;
using System.Collections;
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

namespace RosyModule.Inventory
{
	public partial class frmSDVPHOI : RosyList.frmView
	{
		#region Fields

		private DataTable dtSDVCt;
		private DataRow drCurrent;
		private BindingSource bdsSDVCt = new BindingSource();
		private rsDataGridView dgvSDVCt = new rsDataGridView();

		#endregion

		#region Methods

		public frmSDVPHOI()
		{
			InitializeComponent();

			btImport.Click += new EventHandler(btImport_Click);
		}

		public void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		private void Build()
		{
			
			this.dgvSDVCt.strZone = "SDV_PHOI";
			this.dgvSDVCt.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvSDVCt);
			this.dgvSDVCt.BuildGridView();
		}

		private void FillData()
		{
			string strQuery = @"SELECT T1.*, T2.Ten_Vt
											FROM R80SDVPHOI T1 JOIN R81DMVT T2 ON T1.Ma_Vt = T2.Ma_Vt
											WHERE Nam = " + Element.sysWorkingYear + @" AND (Ma_DvCs = '" + Element.sysMa_DvCs + @"')";

			dtSDVCt = SQLExec.ExecuteReturnDt(strQuery);

            bdsSDVCt.DataSource = dtSDVCt;
            dgvSDVCt.DataSource = bdsSDVCt;

            bdsSearch = bdsSDVCt;
            ExportControl = dgvSDVCt;
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsSDVCt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsSDVCt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsSDVCt.Current).Row, ref drCurrent);
			else
				drCurrent = dtSDVCt.NewRow();

			//Kiểm tra khóa số dư
			if (enuNew_Edit == enuEdit.New)
			{
				string strSQLExec =
					"SELECT TOP 1 Locked_Sdv FROM R00Nam " +
						" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

				if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
				{
					Common.MsgCancel("Số dư đầu đã khóa!");
					return;
				}

				
			}

			frmSDVPHOI_Edit frmEdit = new frmSDVPHOI_Edit();
			drCurrent["Nam"] = Element.sysWorkingYear;
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsSDVCt.Position >= 0)
						dtSDVCt.ImportRow(drCurrent);
					else
						dtSDVCt.Rows.Add(drCurrent);

					bdsSDVCt.Position = bdsSDVCt.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsSDVCt.Current).Row);

				dtSDVCt.AcceptChanges();
			}
		}

		public override void Delete()
		{
			if (bdsSDVCt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsSDVCt.Current).Row;


			//Kiểm tra khóa số dư
			string strSQLExec =
				"SELECT TOP 1 Locked_Sdv FROM R00Nam " +
					" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
			{
				Common.MsgCancel("Số dư đầu đã khóa!");
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R80SDVPHOI", drCurrent))
			{
				bdsSDVCt.RemoveAt(bdsSDVCt.Position);
				dtSDVCt.AcceptChanges();
			}
		}

		#endregion

		#region Events

		
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (this.ActiveControl == dgvSDVCt)
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

			base.OnKeyDown(e);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			Voucher.ImportExcel_SDV("SDVPHOI", dtSDVCt);
		}

		#endregion
	}
}
