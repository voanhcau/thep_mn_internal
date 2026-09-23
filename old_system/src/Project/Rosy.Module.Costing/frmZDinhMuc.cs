using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

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
	public partial class frmZDinhMuc : RosySystem.Customize.frmView
	{
		private DataTable dtDmVtSp;
		private DataTable dtZDinhMucVt;
		private DataTable dtZDinhMucYt;

		private BindingSource bdsDmVtSp = new BindingSource();
		private BindingSource bdsZDinhMucVt = new BindingSource();
		private BindingSource bdsZDinhMucYt = new BindingSource();

		rsTreeList tlDinhMucSp = new rsTreeList();

		private DataRow drCurrent;

		public frmZDinhMuc()
		{
			InitializeComponent();

			cboKieu_Nhom.SelectedValueChanged += new EventHandler(cboKieu_Nhom_SelectedValueChanged);
			chkHaveDinhMuc.CheckedChanged += new EventHandler(chkHaveDinhMuc_CheckedChanged);

			tlDinhMucSp.GotFocus += new EventHandler(tlDinhMucSp_GotFocus);
			dgvZDinhMucVt.GotFocus += new EventHandler(dgvZDinhMucVt_GotFocus);
			dgvZDinhMucYt.GotFocus += new EventHandler(dgvZDinhMucYt_GotFocus);

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btImport.Click += new EventHandler(btImport_Click);
			btCopy.Click += new EventHandler(btCopy_Click);
			btExit.Click += new EventHandler(btExit_Click);

			bdsDmVtSp.PositionChanged += new EventHandler(bdsDmSp_PositionChanged);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();

			tlDinhMucSp.Focus();
		}

		private void Build()
		{
			tlDinhMucSp.KeyFieldName = "MA_VT_SP";
			tlDinhMucSp.ParentFieldName = "MA_NHOM";
			tlDinhMucSp.strZone = "ZDMSP";
			tlDinhMucSp.BuildTreeList();
			tlDinhMucSp.Dock = DockStyle.Fill;

			if (!pageDinhMuc.Controls.Contains(tlDinhMucSp))
				pageDinhMuc.Controls.Add(tlDinhMucSp);

			if (cboKieu_Nhom.Text.Substring(0, 1) == "1")
			{
				dgvZDinhMucVt.strZone = "ZDINHMUCVT";
				dgvZDinhMucVt.BuildGridView();

				dgvZDinhMucYt.strZone = "ZDINHMUCYT";
				dgvZDinhMucYt.BuildGridView();
			}
			else
			{
				dgvZDinhMucVt.strZone = "ZDINHMUCSP_VT";
				dgvZDinhMucVt.BuildGridView();

				dgvZDinhMucYt.strZone = "ZDINHMUCSP_YT";
				dgvZDinhMucYt.BuildGridView();
			}
		}

		private void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("TYPE", cboKieu_Nhom.Text.Substring(0, 1));
			htPara.Add("HAVEDINHMUC", chkHaveDinhMuc.Checked);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsDinhMuc = SQLExec.ExecuteReturnDs("sp_BOM_GetDinhMuc", htPara, CommandType.StoredProcedure);

			dtDmVtSp = dsDinhMuc.Tables[0];
			bdsDmVtSp.DataSource = dtDmVtSp;
			tlDinhMucSp.DataSource = bdsDmVtSp;

			//Định mức vật tư
			dtZDinhMucVt = dsDinhMuc.Tables[1];
			bdsZDinhMucVt.DataSource = dtZDinhMucVt;
			dgvZDinhMucVt.DataSource = bdsZDinhMucVt;

			//Định mức yếu tố
			dtZDinhMucYt = dsDinhMuc.Tables[2];
			bdsZDinhMucYt.DataSource = dtZDinhMucYt;
			dgvZDinhMucYt.DataSource = bdsZDinhMucYt;

            this.bdsSearch = bdsDmVtSp;
            this.ExportControl = tlDinhMucSp;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (this.tabDinhMucCt.SelectedTab == tabPage1)
				this.Edit_ZDinhMucVt(enuNew_Edit);
			else
				this.Edit_ZDinhMucYt(enuNew_Edit);
		}

		public void Edit_ZDinhMucVt(enuEdit enuNew_Edit)
		{
			if (bdsZDinhMucVt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsZDinhMucVt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsZDinhMucVt.Current).Row, ref drCurrent);
			else
				drCurrent = dtZDinhMucVt.NewRow();

			if (enuNew_Edit == enuEdit.New)
				drCurrent["Ma_Vt_Sp"] = ((DataRowView)bdsDmVtSp.Current).Row["Ma_Vt_Sp"];

			frmZDinhMucVt_Edit frmEdit = new frmZDinhMucVt_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsZDinhMucVt.Position >= 0)
						dtZDinhMucVt.ImportRow(drCurrent);
					else
						dtZDinhMucVt.Rows.Add(drCurrent);

					bdsZDinhMucVt.Position = bdsZDinhMucVt.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsZDinhMucVt.Current).Row);
				}

				dtZDinhMucVt.AcceptChanges();
			}
			else
				dtZDinhMucVt.RejectChanges();
		}

		public void Edit_ZDinhMucYt(enuEdit enuNew_Edit)
		{
			if (bdsZDinhMucYt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsZDinhMucYt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsZDinhMucYt.Current).Row, ref drCurrent);
			else
				drCurrent = dtZDinhMucYt.NewRow();

			if (enuNew_Edit == enuEdit.New)
				drCurrent["Ma_Vt_Sp"] = ((DataRowView)bdsDmVtSp.Current).Row["Ma_Vt_Sp"];

			frmZDinhMucYt_Edit frmEdit = new frmZDinhMucYt_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsZDinhMucYt.Position >= 0)
						dtZDinhMucYt.ImportRow(drCurrent);
					else
						dtZDinhMucYt.Rows.Add(drCurrent);

					bdsZDinhMucYt.Position = bdsZDinhMucYt.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsZDinhMucYt.Current).Row);
				}

				dtZDinhMucYt.AcceptChanges();
			}
			else
				dtZDinhMucYt.RejectChanges();
		}

		public override void Delete()
		{
			if (this.tabDinhMucCt.SelectedTab == tabPage1)
				this.Delete_ZDinhMucVt();
			else
				this.Delete_ZDinhMucYt();
		}

		public void Delete_ZDinhMucVt()
		{
			if (bdsZDinhMucVt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsZDinhMucVt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R07ZDinhMucVt", drCurrent))
			{
				bdsZDinhMucVt.RemoveAt(bdsZDinhMucVt.Position);
				dtZDinhMucVt.AcceptChanges();
			}
		}

		public void Delete_ZDinhMucYt()
		{
			if (bdsZDinhMucYt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsZDinhMucYt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R07ZDinhMucYt", drCurrent))
			{
				bdsZDinhMucYt.RemoveAt(bdsZDinhMucYt.Position);
				dtZDinhMucYt.AcceptChanges();
			}
		}

		void ReFillData(string strMa_Vt_Sp)
		{
			//Xóa định mức hiện tại
			DataRow[] drArr = dtZDinhMucVt.Select("Ma_Vt_Sp = '" + strMa_Vt_Sp + "'"); //zDinhMucVt
			foreach (DataRow dr in drArr)
			{
				dtZDinhMucVt.Rows.Remove(dr);
			}
			dtZDinhMucVt.AcceptChanges();

			drArr = dtZDinhMucYt.Select("Ma_Vt_Sp = '" + strMa_Vt_Sp + "'"); //zDinhMucYt
			foreach (DataRow dr in drArr)
			{
				dtZDinhMucYt.Rows.Remove(dr);
			}
			dtZDinhMucYt.AcceptChanges();

			//Fill lại định mức mới
			string strSQLExec = @"SELECT T1.*, T2.Ten_Vt AS Ten_Vt, T3.Ten_Vt AS Ten_Vt_Sp 
												FROM R07zDinhMucVt T1 JOIN R81DmVt T2 ON T1.Ma_Vt = T2.Ma_Vt
																		JOIN R81DmVt T3 ON T1.Ma_Vt_Sp = T3.Ma_Vt
												WHERE T1.Ma_Vt_Sp = '" + strMa_Vt_Sp + "'";

			DataTable dtZDinhMucVtNew = SQLExec.ExecuteReturnDt(strSQLExec);
			foreach (DataRow dr in dtZDinhMucVtNew.Rows)
			{
				DataRow drNew = dtZDinhMucVt.NewRow();

				Common.CopyDataRow(dr, drNew);
				dtZDinhMucVt.Rows.Add(drNew);
			}
			dtZDinhMucVt.AcceptChanges();

			//zDinhMucVt
			strSQLExec = @"SELECT T1.*, T2.Ten_Yt AS Ten_Yt, T3.Ten_Vt AS Ten_Vt_Sp 
												FROM R07zDinhMucYt T1 JOIN R07DmYt T2 ON T1.Ma_Yt = T2.Ma_Yt
																		JOIN R81DmVt T3 ON T1.Ma_Vt_Sp = T3.Ma_Vt
												WHERE T1.Ma_Vt_Sp = '" + strMa_Vt_Sp + "'";

			DataTable dtZDinhMucYtNew = SQLExec.ExecuteReturnDt(strSQLExec);
			foreach (DataRow dr in dtZDinhMucYtNew.Rows)
			{
				DataRow drNew = dtZDinhMucYt.NewRow();

				Common.CopyDataRow(dr, drNew);
				dtZDinhMucYt.Rows.Add(drNew);
			}
			dtZDinhMucYt.AcceptChanges();
		}

		void ImportDinhMuc()
		{
			frmReadExcel frmRead = new frmReadExcel();
			frmRead.Load();

			if (frmRead.isAccept && frmRead.dtImport != null)
			{
				//Import Định mức vật tư
				if (tabDinhMucCt.SelectedTab == tabPage1)
				{
					if (!frmRead.dtImport.Columns.Contains("Ma_Vt_Sp") || !frmRead.dtImport.Columns.Contains("Ma_Vt") || !frmRead.dtImport.Columns.Contains("So_Luong"))
					{
						Common.MsgCancel("Không đủ cột import");
						return;
					}

					string strMa_Vt_Sp_List = "";

					foreach (DataRow dr in frmRead.dtImport.Rows)
					{
						if (dtDmVtSp.Select("Ma_Vt_Sp = '" + dr["Ma_Vt_Sp"].ToString() + "'").Length == 0)
						{
							Common.MsgCancel("Không tồn tại Mã sản phẩm [" + dr["Ma_Vt_Sp"].ToString() + "]");
							continue;
						}

						DataRow drNew = dtZDinhMucVt.NewRow();
						Common.CopyDataRow(dr, drNew);

						if (Convert.ToDouble(drNew["So_Luong_SP"]) == 0)
							drNew["So_Luong_SP"] = 1;

						if (DataTool.SQLUpdate(enuEdit.New, "R07ZDinhMucVt", ref drNew))
						{
							dtZDinhMucVt.Rows.Add(drNew);
							strMa_Vt_Sp_List += drNew["Ma_Vt_Sp"].ToString() + ",";
						}
					}

					foreach (string strMa_Vt_Sp in strMa_Vt_Sp_List.Split(','))
					{
						if (strMa_Vt_Sp != "")
							this.ReFillData(strMa_Vt_Sp);
					}
				}
				else //Import định mức yếu tố
				{
					if (!frmRead.dtImport.Columns.Contains("Ma_Vt_Sp") || !frmRead.dtImport.Columns.Contains("Ma_Yt") || !frmRead.dtImport.Columns.Contains("He_So"))
					{
						Common.MsgCancel("Không đủ cột import");
						return;
					}

					string strMa_Vt_Sp_List = "";

					foreach (DataRow dr in frmRead.dtImport.Rows)
					{
						if (dtDmVtSp.Select("Ma_Vt_Sp = '" + dr["Ma_Vt_Sp"].ToString() + "'").Length == 0)
						{
							Common.MsgCancel("Không tồn tại Mã sản phẩm [" + dr["Ma_Vt_Sp"].ToString() + "]");
							continue;
						}

						DataRow drNew = dtZDinhMucYt.NewRow();
						Common.CopyDataRow(dr, drNew);

						if (Convert.ToDouble(drNew["So_Luong_SP"]) == 0)
							drNew["So_Luong_SP"] = 1;

						if (DataTool.SQLUpdate(enuEdit.New, "R07ZDinhMucYt", ref drNew))
						{
							dtZDinhMucYt.Rows.Add(drNew);
							strMa_Vt_Sp_List += drNew["Ma_Vt_Sp"].ToString() + ",";
						}
					}

					foreach (string strMa_Vt_Sp in strMa_Vt_Sp_List.Split(','))
					{
						if (strMa_Vt_Sp != "")
							this.ReFillData(strMa_Vt_Sp);
					}
				}
			}
		}

		void btNew_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			this.Delete();
		}

		void btImport_Click(object sender, EventArgs e)
		{
			this.ImportDinhMuc();
		}

		void btCopy_Click(object sender, EventArgs e)
		{
			if (bdsDmVtSp.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmVtSp.Current).Row;

			frmZDinhMuc_Copy frmCopy = new frmZDinhMuc_Copy();
			frmCopy.Load(drCurrent);

			if (frmCopy.isAccept)
			{
				if (frmCopy.chkCopyDmVt.Checked)
				{
					this.ReFillData(frmCopy.txtMa_Vt_Sp_Dest.Text);
				}
			}
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void tlDinhMucSp_GotFocus(object sender, EventArgs e)
		{
			this.ExportControl = (rsTreeList)sender;
		}

		void dgvZDinhMucYt_GotFocus(object sender, EventArgs e)
		{
			this.ExportControl = (rsDataGridView)sender;
		}

		void dgvZDinhMucVt_GotFocus(object sender, EventArgs e)
		{
			this.ExportControl = (rsDataGridView)sender;
		}

		void bdsDmSp_PositionChanged(object sender, EventArgs e)
		{
			if (cboKieu_Nhom.Text.Substring(0, 1) == "1")
			{
				bdsZDinhMucVt.Filter = "Ma_Vt_Sp = '" + (string)((DataRowView)bdsDmVtSp.Current).Row["Ma_Vt_Sp"] + "'";
				bdsZDinhMucYt.Filter = "Ma_Vt_Sp = '" + (string)((DataRowView)bdsDmVtSp.Current).Row["Ma_Vt_Sp"] + "'";
			}
			else
			{
				bdsZDinhMucVt.Filter = "Ma_Vt = '" + (string)((DataRowView)bdsDmVtSp.Current).Row["Ma_Vt_Sp"] + "'";
				bdsZDinhMucYt.Filter = "Ma_Yt = '" + (string)((DataRowView)bdsDmVtSp.Current).Row["Ma_Vt_Sp"] + "'";
			}
		}

		void cboKieu_Nhom_SelectedValueChanged(object sender, EventArgs e)
		{
			//if (this.ActiveControl == cboKieu_Nhom)
			//{
				this.Build();
				this.FillData();
			//}
		}

		void chkHaveDinhMuc_CheckedChanged(object sender, EventArgs e)
		{
			//if (this.ActiveControl == chkHaveDinhMuc)
				this.FillData();
		}
	}
}
