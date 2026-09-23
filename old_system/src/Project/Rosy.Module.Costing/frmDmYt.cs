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
	public partial class frmDmYt : RosySystem.Customize.frmView
	{
		private DataTable dtDmYt;
		private BindingSource bdsDmYt = new BindingSource();
		private rsDataGridView dgvDmYt = new rsDataGridView();
		private DataRow drCurrent;

		public frmDmYt()
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

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmYt == null || bdsDmYt.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmYt.Current).Row;
			DataTable dtTemp = dtDmYt.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsDmYt.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmYt.Current).Row;
				this.Close();
			}
		}

		#endregion 

		private void Build()
		{
			dgvDmYt.ReadOnly = true;
			dgvDmYt.strZone = "DMYT";
			dgvDmYt.Dock = DockStyle.Fill;

			this.Controls.Add(dgvDmYt);

			dgvDmYt.BuildGridView();
		}

		private void FillData()
		{
			dtDmYt = DataTool.SQLGetDataTable("R07DmYt", null, "", "Ma_Yt");

			bdsDmYt.DataSource = dtDmYt;
			dgvDmYt.DataSource = bdsDmYt;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmYt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsDmYt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmYt.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmYt.NewRow();

			frmDmYt_Edit frmEdit = new frmDmYt_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmYt.Position >= 0)
						dtDmYt.ImportRow(drCurrent);
					else
						dtDmYt.Rows.Add(drCurrent);

					bdsDmYt.Position = bdsDmYt.Find("MA_YT", drCurrent["MA_YT"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmYt.Current).Row);
				}

				dtDmYt.AcceptChanges();
			}
			else
				dtDmYt.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmYt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmYt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R07DMYT", drCurrent))
			{
				bdsDmYt.RemoveAt(bdsDmYt.Position);
				dtDmYt.AcceptChanges();
			}
		}
	}
}
