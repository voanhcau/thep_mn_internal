using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmCSGia : RosyList.frmView
	{
		DataTable dtCSGia;
		BindingSource bdsCSGia = new BindingSource();
		DataRow drCurrent;
		rsDataGridView dgvCSGia = new rsDataGridView();
		public string strLoai_Cs = string.Empty;
		public string strSo_QD = string.Empty;
		public frmCSGia()
		{			
			InitializeComponent();
			this.btImport.Click += new EventHandler(btImport_Click);
		}

		
		public void Load(string strLoai_Cs)
		{
			this.strLoai_Cs = strLoai_Cs;

			this.Load();
		}
		public void Load(string strLoai_Cs,string strSo_QD)
		{
			this.strLoai_Cs = strLoai_Cs;
			this.strSo_QD = strSo_QD;

			this.Load();
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

		private void Build()
		{
			dgvCSGia.Dock = DockStyle.Fill;
			dgvCSGia.strZone = "CSGIA";
			dgvCSGia.BuildGridView();

			//this.Controls.Add(dgvCSGia);
			this.splitcContent.Panel1.Controls.Add(dgvCSGia);
		}

		private void FillData()
		{
			string strSQLExec = string.Empty;
			if(strSo_QD != string.Empty)
				strSQLExec = "SELECT T1.*, T2.Ten_Vt, T3.Ten_Dt FROM R04CSGia T1 " +
					" LEFT JOIN R81DmVt T2 ON T1.Ma_Vt = T2.Ma_Vt " +
					" LEFT JOIN R81DmDt T3 ON T1.Ma_Dt = T3.Ma_Dt WHERE So_QD = '" + strSo_QD + "'";
			else
				strSQLExec = "SELECT T1.*, T2.Ten_Vt, T3.Ten_Dt FROM R04CSGia T1 " +
					" LEFT JOIN R81DmVt T2 ON T1.Ma_Vt = T2.Ma_Vt " +
					" LEFT JOIN R81DmDt T3 ON T1.Ma_Dt = T3.Ma_Dt WHERE Loai_Cs = '" + strLoai_Cs + "'";

			dtCSGia = SQLExec.ExecuteReturnDt(strSQLExec);

			bdsCSGia.DataSource = dtCSGia;
			dgvCSGia.DataSource = bdsCSGia;
			dgvCSGia.Visible = true;

			this.bdsSearch = bdsCSGia;
			this.ExportControl = dgvCSGia;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsCSGia.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCSGia.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCSGia.Current).Row, ref drCurrent);
			else
				drCurrent = dtCSGia.NewRow();

			drCurrent["Loai_Cs"] = strLoai_Cs;

			frmCSGia_Edit frmEdit = new frmCSGia_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent, strLoai_Cs);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCSGia.Position >= 0)
						dtCSGia.ImportRow(drCurrent);
					else
						dtCSGia.Rows.Add(drCurrent);

					bdsCSGia.Position = bdsCSGia.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCSGia.Current).Row);
				}

				dtCSGia.AcceptChanges();
			}
			else
				dtCSGia.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsCSGia.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCSGia.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R04CsGia", drCurrent))
			{
				bdsCSGia.RemoveAt(bdsCSGia.Position);
				dtCSGia.AcceptChanges();
			}
		}
		void btImport_Click(object sender, EventArgs e)
		{
			Public.ImportExcel("DMCSGIA", dtCSGia);
		}

	}
}
