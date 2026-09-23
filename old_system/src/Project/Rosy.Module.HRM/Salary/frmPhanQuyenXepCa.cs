using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;

namespace RosyModule.Salary
{
	public partial class frmPhanQuyenXepCa : RosySystem.Customize.frmView
	{
		private DataTable dtDmTn;
		private BindingSource bdsDmTn = new BindingSource();
		private rsDataGridView dgvDmTn = new rsDataGridView();
		private DataRow drCurrent;

        public frmPhanQuyenXepCa()
		{
			InitializeComponent();
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public override void LoadLookup()
		{
			this.Load();
		}

		private void Build()
		{
			dgvDmTn.ReadOnly = true;
            dgvDmTn.strZone = "PERMISSCC";
			dgvDmTn.Dock = DockStyle.Fill;

			this.Controls.Add(dgvDmTn);

			dgvDmTn.BuildGridView();
		}

		private void FillData()
		{
            string strSQL = "SELECT T1.*, T2.Ten_Dt AS Ten_Dt_CbNv FROM R10PERMISSCC T1 JOIN (SELECT Ma_Dt, Ten_Dt FROM R81DMDT) T2 ON T1.Ma_Dt_CbNv = T2.Ma_Dt";
            dtDmTn = SQLExec.ExecuteReturnDt(strSQL);

			bdsDmTn.DataSource = dtDmTn;
			dgvDmTn.DataSource = bdsDmTn;
		}

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmTn == null || bdsDmTn.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmTn.Current).Row;
			DataTable dtTemp = dtDmTn.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsDmTn.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmTn.Current).Row;
				this.Close();
			}
		}

		#endregion 

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmTn.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsDmTn.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmTn.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmTn.NewRow();

            frmPhanQuyenXepCa_Edit frmEdit = new frmPhanQuyenXepCa_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmTn.Position >= 0)
						dtDmTn.ImportRow(drCurrent);
					else
						dtDmTn.Rows.Add(drCurrent);

					bdsDmTn.Position = bdsDmTn.Find("IDENT00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmTn.Current).Row);
				}

				dtDmTn.AcceptChanges();
			}
			else
				dtDmTn.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmTn.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmTn.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R10PERMISSCC", drCurrent))
			{
				bdsDmTn.RemoveAt(bdsDmTn.Position);
				dtDmTn.AcceptChanges();
			}
		}
	}
}
