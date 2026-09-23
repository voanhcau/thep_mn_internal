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
using RosySystem.Customize;
using RosySystem.Element;
using DevExpress.XtraTreeList.Columns;

namespace RosyModule.Inventory
{
    public partial class frmKiemKe : RosyList.frmView
	{
		#region Fields

		private DataTable dtDmKho;
		private DataTable dtKiemKe;

		private DataRow drCurrent;
		private BindingSource bdsDmKho = new BindingSource();
		private BindingSource bdsKiemKe = new BindingSource();

		private rsDataGridView dgvDmKho = new rsDataGridView();
		private rsDataGridView dgvKiemKe = new rsDataGridView();

		string strMa_Kho;
		string strMa_Vt;
        public string strLoai_Vt;

		#endregion

		#region Methods

		public frmKiemKe()
		{
			InitializeComponent();
            btImport.Click += new EventHandler(btImport_Click);
		}

        public void Load(string strLoai_Vt)
		{
            
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		private void Build()
		{
			this.dgvDmKho.strZone = "CDV_VIEW";
			this.dgvDmKho.Dock = DockStyle.Fill;

            if (strLoai_Vt == "VT")
			    this.dgvKiemKe.strZone = "KIEMKE_VIEW_VT";
            else
                this.dgvKiemKe.strZone = "KIEMKE_VIEW_SP";

			this.dgvKiemKe.Dock = DockStyle.Fill;

          
            this.splitcContent.Panel1.Controls.Add(dgvDmKho);
            this.splitcContent.Panel1.Controls.Add(dgvKiemKe);

			this.dgvDmKho.BuildGridView();
			this.dgvKiemKe.BuildGridView();

            this.dgvKiemKe.Visible = false;
		}

		private void FillData()
		{
			
			string strKey = "(0 = 0)";

			dtDmKho = DataTool.SQLGetDataTable("R81DMKHO", "*", strKey, "");

			bdsDmKho.DataSource = dtDmKho;
			dgvDmKho.DataSource = bdsDmKho;

           
           dtKiemKe = DataTool.SQLGetDataTable("R05KIEMKE", "*", strKey, "");

            bdsKiemKe.DataSource = dtKiemKe;
            dgvKiemKe.DataSource = bdsKiemKe;
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsKiemKe.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsKiemKe.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsKiemKe.Current).Row, ref drCurrent);
			else
				drCurrent = dtKiemKe.NewRow();

			frmKiemKe_Edit frmEdit = new frmKiemKe_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

            //drCurrent["SL_Cl"] = Convert.ToDouble(drCurrent["So_Luong_Kk"]) - Convert.ToDouble(drCurrent["So_Luong"]);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsKiemKe.Position >= 0)
						dtKiemKe.ImportRow(drCurrent);
					else
						dtKiemKe.Rows.Add(drCurrent);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsKiemKe.Current).Row);

				dtKiemKe.AcceptChanges();
			}
			else
				dtKiemKe.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsKiemKe.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsKiemKe.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R05KIEMKE", drCurrent))
			{
				bdsKiemKe.RemoveAt(bdsKiemKe.Position);
				dtKiemKe.AcceptChanges();
			}
		}

		#endregion

		#region Events

		void EnterValid()
		{
			if (bdsDmKho.Count <= 0)
				return;

            string strQuery = "SELECT * FROM R05KIEMKE T1 LEFT JOIN R81DMVT T2 ON T1.Ma_Vt = T2.Ma_Vt WHERE Ma_Kho = '" + (string)((DataRowView)bdsDmKho.Current)["Ma_Kho"] + "' AND (YEAR(Ngay_KK) = " + Element.sysWorkingYear + " )"; //AND (MONTH(Ngay_Ct) = " + iThang + ")

			dtKiemKe = SQLExec.ExecuteReturnDt(strQuery);

			bdsKiemKe.DataSource = dtKiemKe;
			dgvKiemKe.DataSource = bdsKiemKe;

			dgvKiemKe.Visible = true;
			dgvDmKho.Visible = false;

		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					EnterValid();
					return;

				case Keys.Escape:
					if (dgvKiemKe.Visible)
					{
						dgvDmKho.Visible = true;
						dgvKiemKe.Visible = false;
					}
					else
						this.Close();
					return;

			}

			if (this.ActiveControl == dgvKiemKe)
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
            Voucher.ImportExcel_KIEMKE("KIEMKE", dtKiemKe);
        }
		#endregion
	}
}

