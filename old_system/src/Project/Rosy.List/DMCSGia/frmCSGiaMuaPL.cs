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
	public partial class frmCSGiaMuaPL : RosyList.frmView
	{
		DataTable dtCSGIANA;
		BindingSource bdsCSGIANA = new BindingSource();
		DataRow drCurrent;
		rsDataGridView dgvCSGIANA = new rsDataGridView();
		public string strLoai_Cs = string.Empty;
		public string strSo_QD = string.Empty;
		public frmCSGiaMuaPL()
		{			
			InitializeComponent();
			this.btImport.Click += new EventHandler(btImport_Click);
		}

		
		public void Load(string strLoai_Cs, string strSo_QD)
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
			dgvCSGIANA.Dock = DockStyle.Fill;
			dgvCSGIANA.strZone = "CSGIAMUAPL";
			dgvCSGIANA.BuildGridView();

			//this.Controls.Add(dgvCSGIANA);
			this.splitcContent.Panel1.Controls.Add(dgvCSGIANA);
		}

		private void FillData()
		{
			string strSQLExec = string.Empty;
            if (strSo_QD != string.Empty)
                strSQLExec = "SELECT T1.*, T2.Ten_Vt FROM R04CSGIA T1 " +
                    " LEFT JOIN R81DmVt T2 ON T1.Ma_Vt = T2.Ma_Vt " +
                    " WHERE So_QD = '" + strSo_QD + "' AND Loai_Cs = 'M'";
            else
                strSQLExec = "SELECT T1.*, T2.Ten_Vt FROM R04CSGIA T1 " +
					" LEFT JOIN (SELECT Ma_Vt, Ten_Vt FROM R81DmVt WHERE NGay_End = '19000101') T2 ON T1.Ma_Vt = T2.Ma_Vt WHERE Loai_Cs = 'M'";

			dtCSGIANA = SQLExec.ExecuteReturnDt(strSQLExec);

			bdsCSGIANA.DataSource = dtCSGIANA;
			dgvCSGIANA.DataSource = bdsCSGIANA;
			dgvCSGIANA.Visible = true;

			this.bdsSearch = bdsCSGIANA;
			this.ExportControl = dgvCSGIANA;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsCSGIANA.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			
			//Copy hang hien tai            
			if (bdsCSGIANA.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCSGIANA.Current).Row, ref drCurrent);
			else
				drCurrent = dtCSGIANA.NewRow();

			drCurrent["So_Qd"] = strSo_QD;
			
			frmCSGiaMuaPL_Edit frmEdit = new frmCSGiaMuaPL_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent, strLoai_Cs);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCSGIANA.Position >= 0)
						dtCSGIANA.ImportRow(drCurrent);
					else
						dtCSGIANA.Rows.Add(drCurrent);

					bdsCSGIANA.Position = bdsCSGIANA.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCSGIANA.Current).Row);
				}

				dtCSGIANA.AcceptChanges();
			}
			else
				dtCSGIANA.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsCSGIANA.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCSGIANA.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R04CSGIA", drCurrent))
			{
				bdsCSGIANA.RemoveAt(bdsCSGIANA.Position);
				dtCSGIANA.AcceptChanges();
			}
		}
		void btImport_Click(object sender, EventArgs e)
		{
            Public.ImportExcel("CSGIA", dtCSGIANA);

		}

	}
}
