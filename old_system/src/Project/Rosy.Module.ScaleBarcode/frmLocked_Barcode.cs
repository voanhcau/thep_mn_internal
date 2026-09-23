using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Common;

namespace RosyModule.ScaleBarcode
{
	public partial class frmLocked_Barcode : RosySystem.Customize.frmView
	{
		#region Fields

		private DataTable dtDmNam;
		private DataTable dtLocked_Barcode;

		private DataRow drDmNam;
		private DataRow drLocked_Barcode;
		private DataRow drCurrent;

		private BindingSource bdsDmNam = new BindingSource();
		private BindingSource bdsLocked = new BindingSource();

		#endregion

		public frmLocked_Barcode()
		{
			InitializeComponent();

			dgvLocked_Barcode.CellClick += new DataGridViewCellEventHandler(dgvLocked_Barcode_CellClick);
			this.lvNam.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(lvDmNam_ItemSelectionChanged);
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
			this.lvNam.strZone = "NAM";
			this.lvNam.BuildListView("Nam");

			this.dgvLocked_Barcode.strZone = "LOCKED_BARCODE";
			this.dgvLocked_Barcode.BuildGridView();
		}

		private void FillData()
		{
			dtDmNam = DataTool.SQLGetDataTable("R00NAM", "", "Ma_DvCs = '" + Element.sysMa_DvCs + "'", "Nam");
			bdsDmNam.DataSource = dtDmNam;
			lvNam.DataSource = bdsDmNam;

			lvNam.SmallImageList = imageList1;
			foreach (ListViewItem lvi in lvNam.Items)
			{
				lvi.ImageIndex = 0;
			}

			//Locked
			string strSQLExec = @"
				SELECT Ident00, Ma_DvCs, Ngay_Locked1, Ngay_Locked2, Locked_Type, YEAR(Ngay_Locked2) AS Nam_Locked, MONTH(Ngay_Locked2) AS Thang_Locked, CAST(1 AS BIT) AS Locked
					FROM R00Locked_Barcode
					WHERE Ma_DvCs = '" + Element.sysMa_DvCs + @"'";

			dtLocked_Barcode = SQLExec.ExecuteReturnDt(strSQLExec);

			foreach (DataRow dr in dtDmNam.Rows)
			{
				for (int i = 1; i <= 12; i++)
				{
					if (dtLocked_Barcode.Select("Nam_Locked = " + dr["Nam"].ToString() + " AND Thang_Locked = " + i.ToString()).Length == 0)
					{
						DataRow drNew = dtLocked_Barcode.NewRow();
						drNew["Ma_DvCs"] = Element.sysMa_DvCs;
						drNew["Nam_Locked"] = dr["Nam"];
						drNew["Thang_Locked"] = i;
						drNew["Locked_Type"] = "*";

						dtLocked_Barcode.Rows.Add(drNew);
					}
				}
			}

			bdsLocked.DataSource = dtLocked_Barcode;
			bdsLocked.Sort = "Thang_Locked";
			dgvLocked_Barcode.DataSource = bdsLocked;

			if (this.lvNam.Items.Count > 0)
			{
				ListViewItem lvi = lvNam.FindItemWithText(Element.sysWorkingYear.ToString());

				if (lvi != null)
					lvi.Selected = true;
			}
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (!Element.sysIs_Admin)
			{
				if (!Common.CheckPermission("LOCKED_BARCODE", enuPermission_Type.Allow_Access))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.English ? "User " + Element.sysUser_Id + " have not right to lock data" : "Người dùng " + Element.sysUser_Id + " không có quyền khóa dữ liệu";
					Common.MsgCancel(strMsg);
					return;
				}
			}
			
			if (this.tabControl1.SelectedTab != this.tabPage1)
				return;

			if (bdsLocked.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (enuNew_Edit == enuEdit.New)
				return;

			//Copy hang hien tai
			if (bdsLocked.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsLocked.Current).Row, ref drCurrent);
			else
				drCurrent = dtLocked_Barcode.NewRow();

			frmLocked_Barcode_Edit frmEdit = new frmLocked_Barcode_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent, Convert.ToInt32(lvNam.SelectedItems[0].Text));

			if (frmEdit.isAccept)
			{
				drCurrent["Nam_Locked1"] = ((DateTime)drCurrent["Ngay_Locked1"]).Year;
				drCurrent["Nam_Locked2"] = ((DateTime)drCurrent["Ngay_Locked2"]).Year;

				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsLocked.Position >= 0)
						dtLocked_Barcode.ImportRow(drCurrent);
					else
						dtLocked_Barcode.Rows.Add(drCurrent);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsLocked.Current).Row);

				dtLocked_Barcode.AcceptChanges();
			}
			else
				dtLocked_Barcode.RejectChanges();

		}

		void dgvLocked_Barcode_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 && e.RowIndex < 0)
				return;

			if (dgvLocked_Barcode.Columns[e.ColumnIndex].DataPropertyName == "LOCKED")
			{
				int iNam = Convert.ToInt32(lvNam.SelectedItems[0].Text);
				drCurrent = ((DataRowView)bdsLocked.Current).Row;

				if (drCurrent["Ident00"] != DBNull.Value) //Delete
				{
					if (DataTool.SQLDelete("R00Locked_Barcode", drCurrent))
					{
						drCurrent["Ident00"] = DBNull.Value;
						drCurrent["Ngay_Locked1"] = "1/1/1900";
						drCurrent["Ngay_Locked2"] = "1/1/1900";
						drCurrent["Locked"] = false;

						drCurrent.AcceptChanges();
					}
				}
				else //New
				{
					drCurrent["Ngay_Locked1"] = Common.GetDate(iNam, Convert.ToInt32(drCurrent["Thang_Locked"]), 1);
					drCurrent["Ngay_Locked2"] = ((DateTime)drCurrent["Ngay_Locked1"]).AddMonths(1).AddDays(-1);
					drCurrent["Locked"] = true;

					if (DataTool.SQLUpdate(enuEdit.New, "R00Locked_Barcode", ref drCurrent))
						drCurrent.AcceptChanges();
					else
						drCurrent.RejectChanges();
				}
			}
		}

		void lvDmNam_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.Item != null)
			{
				lvNam.MoveDataSourceToCurrentRow();
				drDmNam = ((DataRowView)bdsDmNam.Current).Row;

				int iNam = Convert.ToInt32(e.Item.Text);
				bdsLocked.Filter = "Nam_Locked = " + Convert.ToString(iNam);
			}
		}
	}
}