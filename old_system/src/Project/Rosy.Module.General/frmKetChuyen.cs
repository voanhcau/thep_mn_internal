using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Element;


namespace RosyModule.General
{
	public partial class frmKetChuyen : RosySystem.Customize.frmView
	{

		#region Khai bao bien
		DataTable dtKetChuyen;
		DataRow drCurrent;
		BindingSource bdsKetChuyen = new BindingSource();
		rsDataGridView dgvKetChuyen = new rsDataGridView();

		#endregion

		#region Contructor

		public frmKetChuyen()
		{
			InitializeComponent();

			this.btNew.Click += new EventHandler(btNew_Click);
			this.btEdit.Click += new EventHandler(btEdit_Click);
			this.btDelete.Click += new EventHandler(btDelete_Click);
			this.btKetChuyen.Click += new EventHandler(btKetChuyen_Click);
			this.btDeleteKc.Click += new EventHandler(btDeleteKc_Click);
			this.KeyDown += new KeyEventHandler(frmDmKetChuyen_View_KeyDown);
		}

		public override void Load()
		{
			this.Tag = this.Tag;
			Build();
			FillData();
			BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvKetChuyen.Dock = DockStyle.Fill;
			dgvKetChuyen.strZone = "KETCHUYEN";
			dgvKetChuyen.BuildGridView(this.isLookup);

			//this.Controls.Add(dgvKetChuyen);
			this.rsSplitContainer2.Panel1.Controls.Add(dgvKetChuyen);
			dgvKetChuyen.BuildGridView();
			Font font = new Font(dgvKetChuyen.DefaultCellStyle.Font.FontFamily, 25, FontStyle.Bold);	
		}

		private void FillData()
		{
			dtKetChuyen = DataTool.SQLGetDataTable("R80KETCHUYEN", "*, CAST(0 AS BIT) AS [SELECT]", this.strLookupKeyFilter, "Stt");

			bdsKetChuyen.DataSource = dtKetChuyen;
			dgvKetChuyen.DataSource = bdsKetChuyen;
			bdsKetChuyen.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsKetChuyen;
			ExportControl = dgvKetChuyen;

			dgvKetChuyen.ReadOnly = false;
			foreach (DataGridViewColumn dgvc in dgvKetChuyen.Columns)
				dgvc.ReadOnly = true;

			dgvKetChuyen.Columns["SELECT"].ReadOnly = false;
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsKetChuyen.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsKetChuyen.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsKetChuyen.Current).Row, ref drCurrent);
			else
				drCurrent = dtKetChuyen.NewRow();

			frmKetChuyen_Edit frmEdit = new frmKetChuyen_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsKetChuyen.Position >= 0)
						dtKetChuyen.ImportRow(drCurrent);
					else
						dtKetChuyen.Rows.Add(drCurrent);

					bdsKetChuyen.Position = bdsKetChuyen.Find("Stt", drCurrent["Stt"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsKetChuyen.Current).Row);

				dtKetChuyen.AcceptChanges();
			}
			else
				dtKetChuyen.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsKetChuyen.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsKetChuyen.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R80KETCHUYEN", drCurrent))
			{
				bdsKetChuyen.RemoveAt(bdsKetChuyen.Position);
				dtKetChuyen.AcceptChanges();
			}
		}

		private void KetChuyen()
		{
			dgvKetChuyen.EndEdit();
			bdsKetChuyen.EndEdit();

			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			frmKetChuyen_Run frm = new frmKetChuyen_Run();
			frm.Tag = "Ket_Chuyen";

			frm.numThang1.Value = Element.sysNgay_Ct1.Month;
			frm.numThang2.Value = Element.sysNgay_Ct2.Month;

			frm.Load();
			if (!frm.isAccept)
				return;

			DateTime dteNgay_Ct1 = Library.StrToDate("01/" + frm.numThang1.Value + "/" + Element.sysWorkingYear);
			DateTime dteNgay_Ct2 = Library.StrToDate("01/" + frm.numThang2.Value + "/" + Element.sysWorkingYear);
			dteNgay_Ct2 = dteNgay_Ct2.AddMonths(1).AddDays(-1);

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			foreach (DataRow dr in dtKetChuyen.Rows)
			{
				if ((bool)dr["SELECT"] == false)
					continue;

				Hashtable ht = new Hashtable();
				ht["NGAY_CT1"] = dteNgay_Ct1;
				ht["NGAY_CT2"] = dteNgay_Ct2;
				ht["STT"] = dr["Stt"];
				ht["TK"] = dr["Tk"];
				ht["TK_DU_DEN"] = dr["Tk_Du_Den"];
				ht["DIEN_GIAI"] = dr["Dien_Giai"];
				ht["NO_CO_AUTO"] = dr["No_Co_Auto"];
				ht["PS_DU"] = dr["Ps_Du"];
				ht["MA_CT"] = "TD";
				ht["CREATE_LOG"] = Common.GetCurrent_Log();
				ht["MA_DVCS"] = Element.sysMa_DvCs;

				Common.ShowStatus(Languages.GetLanguage("In_Process") + (string)dr["Dien_Giai"]);

				SQLExec.Execute("Sp_KetChuyen_Delete", ht, CommandType.StoredProcedure);
				SQLExec.Execute("Sp_KetChuyen", ht, CommandType.StoredProcedure);

				dr["Select"] = false;
			}

			Common.EndShowStatus();
			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		private void KetChuyen_Delete()
		{
			dgvKetChuyen.EndEdit();
			bdsKetChuyen.EndEdit();

			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			frmKetChuyen_Run frm = new frmKetChuyen_Run();
			frm.Tag = "Ket_Chuyen_Delete";
			frm.numThang1.Value = Element.sysNgay_Ct1.Month;
			frm.numThang2.Value = Element.sysNgay_Ct2.Month;

			frm.Load();
			if (!frm.isAccept)
				return;

			DateTime dteNgay_Ct1 = Library.StrToDate("01/" + frm.numThang1.Value + "/" + Element.sysWorkingYear);
			DateTime dteNgay_Ct2 = Library.StrToDate("01/" + frm.numThang2.Value + "/" + Element.sysWorkingYear);
			dteNgay_Ct2 = dteNgay_Ct2.AddMonths(1).AddDays(-1);

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			foreach (DataRow dr in dtKetChuyen.Rows)
			{
				if ((bool)dr["SELECT"] == false)
					continue;

				Hashtable ht = new Hashtable();
				ht["NGAY_CT1"] = dteNgay_Ct1;
				ht["NGAY_CT2"] = dteNgay_Ct2;
				ht["STT"] = dr["Stt"];
				ht["MA_CT"] = "TD";
				ht["MA_DVCS"] = Element.sysMa_DvCs;

				Common.ShowStatus(Languages.GetLanguage("In_Process") + (string)dr["Dien_Giai"]);

				SQLExec.Execute("Sp_KetChuyen_Delete", ht, CommandType.StoredProcedure);

				dr["Select"] = false;
			}

			Common.EndShowStatus();
			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		#endregion

		#region Su kien

		void btDelete_Click(object sender, EventArgs e)
		{
			Delete();
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.Edit);
		}

		void btNew_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.New);
		}


		void btDeleteKc_Click(object sender, EventArgs e)
		{
			KetChuyen_Delete();
		}

		void btKetChuyen_Click(object sender, EventArgs e)
		{
			KetChuyen();
		}
		void frmDmKetChuyen_View_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{
				for (int i = 0; i < dtKetChuyen.Rows.Count; i++)
				{
					dtKetChuyen.Rows[i]["SELECT"] = true;
				}
			}

			else if (e.Control && e.KeyCode == Keys.U)
			{
				for (int i = 0; i < dtKetChuyen.Rows.Count; i++)
				{
					dtKetChuyen.Rows[i]["SELECT"] = false;
				}
			}

			else if (!e.Control && e.KeyCode == Keys.F10)
			{
				KetChuyen();
			}
			else if (e.Control && e.KeyCode == Keys.F10)
			{
				KetChuyen_Delete();
			}
			else if (e.KeyCode == Keys.Space)
				((DataRowView)bdsKetChuyen.Current).Row["Select"] = !(bool)((DataRowView)bdsKetChuyen.Current).Row["Select"];

		}

		#endregion
	}
}