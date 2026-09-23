using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Customize;
using RosySystem;
using RosySystem.Common;
using RosySystem.Control;

namespace RosyModule.Costing
{
	public partial class frmZPhanDoan : RosySystem.Customize.frmView
	{
		private DataTable dtZPhanDoan;
		private BindingSource bdsZPhanDoan = new BindingSource();
		private rsDataGridView dgvZPhanDoan = new rsDataGridView();
		private DataRow drCurrent;

		public frmZPhanDoan()
		{
			InitializeComponent();
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.Show();
		}

		private void Build()
		{
			dgvZPhanDoan.ReadOnly = true;
			dgvZPhanDoan.strZone = "ZPHANDOAN";
			dgvZPhanDoan.Dock = DockStyle.Fill;

			this.Controls.Add(dgvZPhanDoan);

			dgvZPhanDoan.BuildGridView();
		}

		private void FillData()
		{
			dtZPhanDoan = DataTool.SQLGetDataTable("R07ZPhanDoan", null, "", "Tk");

			bdsZPhanDoan.DataSource = dtZPhanDoan;
			dgvZPhanDoan.DataSource = bdsZPhanDoan;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsZPhanDoan.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsZPhanDoan.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsZPhanDoan.Current).Row, ref drCurrent);
			else
				drCurrent = dtZPhanDoan.NewRow();

			frmZPhanDoan_Edit frmEdit = new frmZPhanDoan_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsZPhanDoan.Position >= 0)
						dtZPhanDoan.ImportRow(drCurrent);
					else
						dtZPhanDoan.Rows.Add(drCurrent);

					bdsZPhanDoan.Position = bdsZPhanDoan.Find("Tk", drCurrent["Tk"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsZPhanDoan.Current).Row);
				}

				dtZPhanDoan.AcceptChanges();
			}
			else
				dtZPhanDoan.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsZPhanDoan.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsZPhanDoan.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R07ZPhanDoan", drCurrent))
			{
				bdsZPhanDoan.RemoveAt(bdsZPhanDoan.Position);
				dtZPhanDoan.AcceptChanges();
			}
		}
	}
}
