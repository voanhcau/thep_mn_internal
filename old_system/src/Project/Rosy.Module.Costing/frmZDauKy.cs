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
using RosySystem.Common;
using RosySystem.Control;
using RosyList;

namespace RosyModule.Costing
{
	public partial class frmZDauKy : RosySystem.Customize.frmView
	{
		private DataTable dtZDauKyYt;
		private DataTable dtZDauKySpSum;
		private DataTable dtZDauKySp;

		private BindingSource bdsZDauKyYt = new BindingSource();
		private BindingSource bdsZDauKySpSum = new BindingSource();
		private BindingSource bdsZDauKySp = new BindingSource();

		private DataRow drCurrent;

		public frmZDauKy()
		{
			InitializeComponent();

			bdsZDauKySpSum.PositionChanged += new EventHandler(bdsDmSp_PositionChanged);
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
			dgvZDauKySpSum.strZone = "ZDAUKYSP0";
			dgvZDauKySpSum.BuildGridView();

			dgvZDauKyYt.strZone = "ZDAUKYYT";
			dgvZDauKyYt.BuildGridView();

			dgvZDauKySp.strZone = "ZDAUKYSP";
			dgvZDauKySp.BuildGridView();
		}

		private void FillData()
		{
			dtZDauKySpSum = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Ten_Vt AS Ten_Vt_Sp FROM R07GiaThanh T1 LEFT JOIN R81DmVt T2 ON T1.Ma_Vt_Sp = T2.Ma_Vt WHERE Is_SoDuDau = 1 AND YEAR(Ngay_Ct) = " + Element.sysWorkingYear.ToString());
			
			bdsZDauKySpSum.DataSource = dtZDauKySpSum;
			dgvZDauKySpSum.DataSource = bdsZDauKySpSum;

			dtZDauKyYt = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Ten_Vt FROM R07ZChiPhiYt T1 LEFT JOIN R81DmVt T2 ON T1.Ma_Vt = T2.Ma_Vt WHERE Is_SoDuDau = 1 AND YEAR(Ngay_Ct) = " + Element.sysWorkingYear.ToString());

			bdsZDauKyYt.DataSource = dtZDauKyYt;
			dgvZDauKyYt.DataSource = bdsZDauKyYt;

			dtZDauKySp = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Ten_Vt FROM R07ZChiPhiSp T1 LEFT JOIN R81DmVt T2 ON T1.Ma_Vt = T2.Ma_Vt WHERE Is_SoDuDau = 1 AND YEAR(Ngay_Ct) = " + Element.sysWorkingYear.ToString());

			bdsZDauKySp.DataSource = dtZDauKySp;
			dgvZDauKySp.DataSource = bdsZDauKySp;

			//Filter
			if (bdsZDauKySpSum.Count > 0)
			{
				bdsZDauKySpSum.Position = 0;
				drCurrent = ((DataRowView)bdsZDauKySpSum.Current).Row;

				bdsZDauKySp.Filter = "(Tk = '" + (string)drCurrent["Tk"] + "') AND (Ma_Vt_Sp = '" + (string)drCurrent["Ma_Vt_Sp"] + "')";
			}

			this.ExportControl = dgvZDauKyYt;
			this.bdsSearch = bdsZDauKyYt;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (rsTabControl1.SelectedTab == tabPage1)
				this.Edit_ZDauKyYt(enuNew_Edit);
			else
			{
				if (this.dgvZDauKySp.Focused)
					this.Edit_ZDauKySp(enuNew_Edit);
				else
					this.Edit_ZDauKySpSum(enuNew_Edit);
			}
		}

		public void Edit_ZDauKyYt(enuEdit enuNew_Edit)
		{
			if (bdsZDauKyYt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsZDauKyYt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsZDauKyYt.Current).Row, ref drCurrent);
			else
				drCurrent = dtZDauKyYt.NewRow();

			//if (enuNew_Edit == enuEdit.New)
			//    drCurrent["Ma_Sp"] = ((DataRowView)bdsZDoDangYt.Current).Row["Ma_Sp"];

			frmZDauKyYt_Edit frmEdit = new frmZDauKyYt_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsZDauKyYt.Position >= 0)
						dtZDauKyYt.ImportRow(drCurrent);
					else
						dtZDauKyYt.Rows.Add(drCurrent);

					bdsZDauKyYt.Position = bdsZDauKyYt.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsZDauKyYt.Current).Row);
				}

				dtZDauKyYt.AcceptChanges();
			}
			else
				dtZDauKyYt.RejectChanges();
		}

		public void Edit_ZDauKySp(enuEdit enuNew_Edit)
		{
			if (bdsZDauKySp.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsZDauKySp.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsZDauKySp.Current).Row, ref drCurrent);
			else
				drCurrent = dtZDauKySp.NewRow();

			if (enuNew_Edit == enuEdit.New && bdsZDauKySpSum.Position < 0)
			{
				this.Edit_ZDauKySpSum(enuNew_Edit);
				return;
			}

			if (enuNew_Edit == enuEdit.New)
			{
				drCurrent["Tk"] = (string)((DataRowView)bdsZDauKySpSum.Current).Row["Tk"];
				drCurrent["Ma_Vt_Sp"] = (string)((DataRowView)bdsZDauKySpSum.Current).Row["Ma_Vt_Sp"];
			}

			frmZDauKySp_Edit frmEdit = new frmZDauKySp_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsZDauKySp.Position >= 0)
						dtZDauKySp.ImportRow(drCurrent);
					else
						dtZDauKySp.Rows.Add(drCurrent);

					bdsZDauKySp.Position = bdsZDauKySp.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsZDauKySp.Current).Row);
				}

				//Cập nhật tổng giá trị dở dang
				DataRow drZSp = ((DataRowView)bdsZDauKySpSum.Current).Row;
				drZSp["TIEN_DD"] = Convert.ToDouble(Common.SumDCValue(dtZDauKySp, "TIEN_DD", "Ma_Vt_Sp = '" + (string)drZSp["Ma_Vt_Sp"] + "'"));
				SQLExec.Execute("UPDATE R07GiaThanh SET Tien_DD = " + Convert.ToDouble(drZSp["TIEN_DD"]).ToString().Trim() + " WHERE Ident00 = " + drZSp["Ident00"].ToString().Trim());

				dtZDauKySp.AcceptChanges();
			}
			else
				dtZDauKySp.RejectChanges();
		}

		public void Edit_ZDauKySpSum(enuEdit enuNew_Edit)
		{
			if (bdsZDauKySpSum.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsZDauKySpSum.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsZDauKySpSum.Current).Row, ref drCurrent);
			else
				drCurrent = dtZDauKySpSum.NewRow();

			//if (enuNew_Edit == enuEdit.New)
			//    drCurrent["Ma_Sp"] = ((DataRowView)bdsZSp.Current).Row["Ma_Sp"];

			frmZDauKySp0_Edit frmEdit = new frmZDauKySp0_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsZDauKySpSum.Position >= 0)
						dtZDauKySpSum.ImportRow(drCurrent);
					else
						dtZDauKySpSum.Rows.Add(drCurrent);

					bdsZDauKySpSum.Position = bdsZDauKySpSum.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsZDauKySpSum.Current).Row);
				}

				dtZDauKySpSum.AcceptChanges();
			}
			else
				dtZDauKySpSum.RejectChanges();
		}

		public override void Delete()
		{
			if (rsTabControl1.SelectedTab == tabPage1)
				this.Delete_ZDauKyYt();
			else
			{
				if (this.dgvZDauKySp.Focused)
					this.Delete_ZDauKySp();
				else
					this.Delete_ZDauKySpSum();
			}
		}

		public void Delete_ZDauKyYt()
		{
			if (bdsZDauKyYt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsZDauKyYt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R07ZChiPhiYt", drCurrent))
			{
				bdsZDauKyYt.RemoveAt(bdsZDauKyYt.Position);
				dtZDauKyYt.AcceptChanges();
			}
		}

		public void Delete_ZDauKySpSum()
		{
			if (bdsZDauKySpSum.Position < 0)
				return;

			if (bdsZDauKySp.Count > 0)
			{
				Common.MsgCancel("Bạn phải xóa ở chi tiết");
				return;
			}

			DataRow drCurrent = ((DataRowView)bdsZDauKySpSum.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R07GiaThanh", drCurrent))
			{
				bdsZDauKySpSum.RemoveAt(bdsZDauKySpSum.Position);
				dtZDauKySpSum.AcceptChanges();
			}
		}

		public void Delete_ZDauKySp()
		{
			if (bdsZDauKySp.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsZDauKySp.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R07ZChiPhiSp", drCurrent))
			{
				bdsZDauKySp.RemoveAt(bdsZDauKySp.Position);
				dtZDauKySp.AcceptChanges();

				//Cập nhật tổng giá trị dở dang
				DataRow drZSp = ((DataRowView)bdsZDauKySpSum.Current).Row;
				drZSp["TIEN_DD"] = Convert.ToDouble(Common.SumDCValue(dtZDauKySp, "TIEN_DD", "Ma_Vt_Sp = '" + (string)drZSp["Ma_Vt_Sp"] + "'"));
				SQLExec.Execute("UPDATE R07GiaThanh SET Tien_DD = " + Convert.ToDouble(drZSp["TIEN_DD"]).ToString().Trim() + " WHERE Ident00 = " + drZSp["Ident00"].ToString().Trim());
			}
		}

		void bdsDmSp_PositionChanged(object sender, EventArgs e)
		{
			drCurrent = ((DataRowView)bdsZDauKySpSum.Current).Row;

			bdsZDauKySp.Filter = "(Tk = '" + (string)drCurrent["Tk"] + "') AND (Ma_Vt_Sp = '" + (string)drCurrent["Ma_Vt_Sp"] + "')";
		}
	}
}
