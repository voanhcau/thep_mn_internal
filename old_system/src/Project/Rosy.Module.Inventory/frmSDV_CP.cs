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
	public partial class frmSDV_CP : RosyList.frmView
	{
		#region Fields

		private DataTable dtSDV;
		private DataTable dtSDVCt;

		private DataRow drCurrent;
		private BindingSource bdsSDV = new BindingSource();
		private BindingSource bdsSDVCt = new BindingSource();

		private rsDataGridView dgvSDV = new rsDataGridView();
		private rsDataGridView dgvSDVCt = new rsDataGridView();

		#endregion

		#region Methods

		public frmSDV_CP()
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
			this.dgvSDV.strZone = "SDV_VIEW";
			this.dgvSDV.Dock = DockStyle.Fill;

			this.dgvSDVCt.strZone = "SDV_VIEWCT";
			this.dgvSDVCt.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvSDVCt);
			this.splitcContent.Panel1.Controls.Add(dgvSDV);

			this.dgvSDV.BuildGridView();
			this.dgvSDVCt.BuildGridView();

			this.dgvSDVCt.Visible = false;
		}

		private void FillData()
		{
			string strQuery = @"SELECT T1.Ma_Kho, T1.Ten_Kho, ISNULL(T2.Ton_Dau, 0) AS Ton_Dau, ISNULL(T2.Du_Dau, 0) AS Du_Dau, ISNULL(T2.Du_Dau_Nt, 0) AS Du_Dau_Nt
									 FROM R81DMKHO T1 JOIN 
										 (SELECT Ma_Kho, ISNULL(SUM(Ton_Dau), 0) AS Ton_Dau, ISNULL(SUM(Du_Dau), 0) AS Du_Dau, ISNULL(SUM(Du_Dau_Nt), 0) AS Du_Dau_Nt 
											FROM R80SDV_CP
											WHERE Nam = " + Element.sysWorkingYear + @" AND (Ma_DvCs = '" + Element.sysMa_DvCs + @"') 
											GROUP BY Ma_Kho) T2
											ON T1.Ma_Kho = T2.Ma_Kho";

			dtSDV = SQLExec.ExecuteReturnDt(strQuery);

			bdsSDV.DataSource = dtSDV;
			dgvSDV.DataSource = bdsSDV;

			bdsSearch = bdsSDV;
			ExportControl = dgvSDV;
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

				drCurrent["Ma_Kho"] = ((DataRowView)bdsSDV.Current)["Ma_Kho"];
			}

			frmSDV_CP_Edit frmEdit = new frmSDV_CP_Edit();
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

			if (DataTool.SQLDelete("R80SDV_CP", drCurrent))
			{
				bdsSDVCt.RemoveAt(bdsSDVCt.Position);
				dtSDVCt.AcceptChanges();
			}
		}

		#endregion

		#region Events

		void EnterValid()
		{
			Hashtable ht = new Hashtable();
			ht["MA_KHO"] = ((DataRowView)bdsSDV.Current)["Ma_Kho"];
			ht["NAM"] = Element.sysWorkingYear;
			ht["MA_DVCS"] = Element.sysMa_DvCs;

			string strSQLExec = @"
				SELECT T1.*, T2.Ten_Vt, T2.Dvt 
					FROM R80SDV_CP T1 LEFT JOIN R81DmVt T2 ON T1.Ma_Vt = T2.Ma_Vt 
					WHERE Ma_Kho = @Ma_Kho AND Nam = @Nam AND Ma_DvCs = @Ma_DvCs";

			dtSDVCt = SQLExec.ExecuteReturnDt(strSQLExec, ht, CommandType.Text);

			bdsSDVCt.DataSource = dtSDVCt;
			dgvSDVCt.DataSource = bdsSDVCt;

			dgvSDVCt.Visible = true;
			dgvSDV.Visible = false;

			bdsSearch = bdsSDVCt;
			ExportControl = dgvSDVCt;

			dgvSDVCt.Select();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					EnterValid();
					return;

				case Keys.Escape:
					if (dgvSDVCt.Visible)
					{
						dgvSDV.Visible = true;
						dgvSDVCt.Visible = false;

						//Tính tổng
						drCurrent = ((DataRowView)bdsSDV.Current).Row;
						string strSQLExec = "SELECT ISNULL(SUM(Ton_Dau), 0) AS Ton_Dau, ISNULL(SUM(Du_Dau), 0) AS Du_Dau, ISNULL(SUM(Du_Dau_Nt), 0) AS Du_Dau_Nt FROM R80SDV_CP WHERE Nam = @Nam AND Ma_DvCs = @Ma_DvCs AND Ma_Kho = @Ma_Kho";
						DataTable dtSum = SQLExec.ExecuteReturnDt(strSQLExec, new string[] { "NAM", "MA_DVCS", "MA_KHO" }, new object[] { Element.sysWorkingYear, Element.sysMa_DvCs, drCurrent["Ma_Kho"] });
						if (dtSum != null && dtSum.Rows.Count > 0)
						{
							drCurrent["Ton_Dau"] = dtSum.Rows[0]["Ton_Dau"];
							drCurrent["Du_Dau"] = dtSum.Rows[0]["Du_Dau"];
							drCurrent["Du_Dau_Nt"] = dtSum.Rows[0]["Du_Dau_Nt"];
						}

						bdsSearch = bdsSDV;
						ExportControl = dgvSDV;
					}
					else
						this.Close();
					return;

			}

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
			Voucher.ImportExcel_SDV_CP("SDV_CP", dtSDVCt);
		}

		#endregion
	}
}
