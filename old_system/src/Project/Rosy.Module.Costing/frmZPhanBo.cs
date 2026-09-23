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

namespace RosyModule.Costing
{
	public partial class frmZPhanBo : RosySystem.Customize.frmView
	{
		private DataTable dtZPhanBo;
		private BindingSource bdsZPhanBo = new BindingSource();

		private DataRow drCurrent;

		public frmZPhanBo()
		{
			InitializeComponent();

			rsTabControl1.SelectedIndexChanged += new EventHandler(rsTabControl1_SelectedIndexChanged);

			this.btExit.Click += new EventHandler(btExit_Click);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		private void Build()
		{
			dgvZPhanBo1.ReadOnly = true;
			dgvZPhanBo1.strZone = "ZPHANBO1";
			dgvZPhanBo1.BuildGridView();

			dgvZPhanBo2.ReadOnly = true;
			dgvZPhanBo2.strZone = "ZPHANBO2";
			dgvZPhanBo2.BuildGridView();

			dgvZPhanBo3.ReadOnly = true;
			dgvZPhanBo3.strZone = "ZPHANBO3";
			dgvZPhanBo3.BuildGridView();

			//dgvZPhanBo4.ReadOnly = true;
			//dgvZPhanBo4.strZone = "ZPHANBO4";
			//dgvZPhanBo4.BuildGridView();
		}

		private void FillData()
		{
			dtZPhanBo = DataTool.SQLGetDataTable("R07ZPHANBO", null, "Ma_Data = '" + Element.sysMa_Data + "'", "Stt");

			bdsZPhanBo.DataSource = dtZPhanBo;

			dgvZPhanBo1.DataSource = bdsZPhanBo;
			dgvZPhanBo2.DataSource = bdsZPhanBo;
			dgvZPhanBo3.DataSource = bdsZPhanBo;

			bdsZPhanBo.Filter = "Loai_Pb = '1'";

			//BindingTTien            
			txtTk_Cp1.DataBindings.Add("Text", dtZPhanBo, "Tk_Cp1");
			txtTk_Cp2.DataBindings.Add("Text", dtZPhanBo, "Tk_Cp2");
			txtTk_Cp3.DataBindings.Add("Text", dtZPhanBo, "Tk_Cp3");
			txtTk_Cp4.DataBindings.Add("Text", dtZPhanBo, "Tk_Cp4");
			txtTk_Den.DataBindings.Add("Text", dtZPhanBo, "Tk_Den");
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsZPhanBo.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsZPhanBo.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsZPhanBo.Current).Row, ref drCurrent);
			else
				drCurrent = dtZPhanBo.NewRow();

			bool bIs_Accept = false;

			if (this.rsTabControl1.SelectedIndex == 0)
			{
				frmZPhanBo1_Edit frmEdit = new frmZPhanBo1_Edit();
				frmEdit.Load(enuNew_Edit, drCurrent);

				bIs_Accept = frmEdit.isAccept;
			}
			else if (this.rsTabControl1.SelectedIndex == 1)
			{
				frmZPhanBo2_Edit frmEdit = new frmZPhanBo2_Edit();
				frmEdit.Load(enuNew_Edit, drCurrent);

				bIs_Accept = frmEdit.isAccept;
			}
			else if (this.rsTabControl1.SelectedIndex == 2)
			{
				frmZPhanBo3_Edit frmEdit = new frmZPhanBo3_Edit();
				frmEdit.Load(enuNew_Edit, drCurrent);

				bIs_Accept = frmEdit.isAccept;
			}

			// người dùng chọn chấp nhận
			if (bIs_Accept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsZPhanBo.Position >= 0)
						dtZPhanBo.ImportRow(drCurrent);
					else
						dtZPhanBo.Rows.Add(drCurrent);

					bdsZPhanBo.Position = bdsZPhanBo.Find("Stt", drCurrent["Stt"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsZPhanBo.Current).Row);
				}

				dtZPhanBo.AcceptChanges();
			}
			else
				dtZPhanBo.RejectChanges();

		}

		public override void Delete()
		{
			this.Delete_ZPhanBo1();
		}

		private void Delete_ZPhanBo1()
		{
			if (bdsZPhanBo.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsZPhanBo.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R07ZPHANBO", drCurrent))
			{
				bdsZPhanBo.RemoveAt(bdsZPhanBo.Position);
				dtZPhanBo.AcceptChanges();
			}
		}

		void rsTabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (rsTabControl1.SelectedTab == tabPage1)
			{
				bdsZPhanBo.Filter = "Loai_PB = '1'";
			}
			else if (rsTabControl1.SelectedTab == tabPage2)
			{
				bdsZPhanBo.Filter = "Loai_PB = '2'";
			}
			else if (rsTabControl1.SelectedTab == tabPage3)
			{
				bdsZPhanBo.Filter = "Loai_PB = '3'";
			}
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
