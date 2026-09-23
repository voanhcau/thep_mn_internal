using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Customize;

namespace RosyControllerTMN
{
	public partial class frmTyGia : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		private DataTable dtDmTte;
		private DataTable dtTyGia;

		private BindingSource bdsDmTte = new BindingSource();
		private BindingSource bdsTyGia = new BindingSource();

		private DataRow drCurrent;

		#endregion

		#region Contructor

		public frmTyGia()
		{
			InitializeComponent();
		}

		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvDmTte.Columns.Add("MA_TTE", "Mã tiền tệ");
			dgvDmTte.Columns["MA_TTE"].Width = 200;
			dgvDmTte.Columns["MA_TTE"].DataPropertyName = "MA_TTE";
			dgvDmTte.Visible = true;

			dgvTyGia.strZone = "TYGIA";
			dgvTyGia.BuildGridView(false);
			dgvTyGia.Visible = false;
			dgvTyGia.Dock = DockStyle.Fill;
		}

		private void FillData()
		{
			//Đưa dữ liệu Mã Ttệ
			dtDmTte = new DataTable();
			dtDmTte.Columns.Add("MA_TTE", typeof(string));

			string strMa_Tte_List = (string)SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM R00PARAMETER WHERE Parameter_ID = 'MA_TTE_LIST'");
			string[] strArrMa_Tte = strMa_Tte_List.Split(',');
			foreach (string str in strArrMa_Tte)
			{
				dtDmTte.Rows.Add(str);
			}
			bdsDmTte.DataSource = dtDmTte;
			dgvDmTte.DataSource = bdsDmTte;

			//Đưa dữ liệu 
			dtTyGia = DataTool.SQLGetDataTable("R00TyGia", "", " YEAR(Ngay_Ap) = " + Element.sysWorkingYear.ToString() , "Ma_Tte, Ngay_Ap");

			bdsTyGia.DataSource = dtTyGia;
			dgvTyGia.DataSource = bdsTyGia;

			//Uy quyen cho lop co so tim kiem
			bdsSearch = bdsTyGia;
			ExportControl = dgvTyGia;
		}
		
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (!dgvTyGia.Visible)
				return;

			if (bdsTyGia.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsTyGia.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsTyGia.Current).Row, ref drCurrent);
			else
				drCurrent = dtTyGia.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				drCurrent["Ma_Tte"] = ((DataRowView)bdsDmTte.Current).Row["Ma_Tte"];
				drCurrent["Ngay_Ap"] = DateTime.Now;
			}

			frmTyGia_Edit frmEdit = new frmTyGia_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsTyGia.Position >= 0)
						dtTyGia.ImportRow(drCurrent);
					else
						dtTyGia.Rows.Add(drCurrent);

					bdsTyGia.Position = bdsTyGia.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsTyGia.Current).Row);

				dtTyGia.AcceptChanges();
			}
			else
				dtTyGia.RejectChanges();
		}

		public override void Delete()
		{
			if (!dgvTyGia.Visible)
				return;

			if (bdsTyGia.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsTyGia.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
			
			if (DataTool.SQLDelete("R00TYGIA", drCurrent))
			{
				bdsTyGia.RemoveAt(bdsTyGia.Position);
				dtTyGia.AcceptChanges();
			}
		}

		#endregion

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsTyGia == null || bdsTyGia.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsTyGia.Current).Row;
			DataTable dtTemp = dtTyGia.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (!dgvDmTte.Visible)
				return;

			if (bdsDmTte.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmTte.Current).Row;
				this.Close();
			}
			else
			{
				drCurrent = ((DataRowView)bdsDmTte.Current).Row;

				dgvDmTte.Visible = false;

				dgvTyGia.Visible = true;
				dgvTyGia.Focus();
			}
		}

		#endregion 

		#region Su kien

		//void KeyDownEvent(object sender, KeyEventArgs e)
		//{
		//    switch (e.KeyCode)
		//    {
		//        case Keys.F8:
		//            Delete();
		//            break;

		//        case Keys.Escape:
		//            if (dgvTyGia.Visible)
		//            {
		//                dgvDmTte.Visible = true;
		//                dgvTyGia.Visible = false;
		//            }
		//            break;
		//    }
		//}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F2:
					Edit(enuEdit.New);
					break;

				case Keys.F3:
					Edit(enuEdit.Edit);
					break;

				case Keys.F8:
					Delete();
					break;

				case Keys.Escape:
					if (dgvTyGia.Visible)
					{
						dgvDmTte.Visible = true;
						dgvTyGia.Visible = false;
					}
					else
						this.Close();

					break;

				case Keys.Enter:
					if (bdsDmTte.Position >= 0)
					{
						drCurrent = ((DataRowView)bdsDmTte.Current).Row;

						bdsTyGia.Filter = "Ma_Tte = '" + (string)drCurrent["Ma_Tte"] + "'";

						this.EnterProcess();
					}

					break;
			}

			//base.OnKeyDown(e);
		}

		#endregion
	}
}
