using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;

namespace RosyModule.General
{
	public partial class frmTinh_CLTG : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		private DataTable dtCLTG;
		private DataTable dtKetQuaCLTG;
		
		private BindingSource bdsKetQuaCLTG = new BindingSource();
		private BindingSource bdsCLTG = new BindingSource();

		DataRow drCurrent;

		#endregion

		#region Contructor

		public frmTinh_CLTG()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmCLTG_View_KeyDown);

			dteNgay_Ct.Validating += new CancelEventHandler(dteNgay_Ct_Validating);

			btTinhCLTG.Click += new EventHandler(btTinhCLTG_Click);
			btTinhCLTG_HetSoDu.Click += new EventHandler(btTinhCLTG_HetSoDu_Click);
			bdsCLTG.PositionChanged += new EventHandler(bdsCLTG_PositionChanged);
		}

		void frmCLTG_View_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				if (e.KeyCode == Keys.A)
					foreach (DataRow dr in dtCLTG.Rows)
						dr["Chon"] = true;

				else if (e.KeyCode == Keys.U)
					foreach (DataRow dr in dtCLTG.Rows)
						dr["Chon"] = false;
			}
			else if (dgvCLTG.Focused && e.KeyCode == Keys.Space)
				((DataRowView)bdsCLTG.Current).Row["Chon"] = !(bool)((DataRowView)bdsCLTG.Current).Row["Chon"];
		}
        
		public void Load()
		{
			dteNgay_Ct.Text = Element.sysNgay_Ct2.ToString("dd/MM/yyyy");

			string strTk_Lai_HetSoDu = (string)RosySystem.Library.Parameters.GetParaValue("TK_LAI_HETSODU");
			string strTk_Lo_HetSoDu = (string)RosySystem.Library.Parameters.GetParaValue("TK_LO_HETSODU");

			Build();
			FillData();

			BindingLanguage();
		
			this.Show();
		}

		public void Load(string strLoai_CLTG)
		{
			this.Load();
		}
		
		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvCLTG.strZone = "CLTG";
			dgvCLTG.BuildGridView();
			dgvCLTG.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvCLTG.Columns)
			{
				if (dgvc.Name == "CHON")
					dgvc.ReadOnly = false;
				else
					dgvc.ReadOnly = true;
			}

			dgvKetQuaCLTG.strZone = "KQCLTG";
			dgvKetQuaCLTG.BuildGridView();
			dgvKetQuaCLTG.ReadOnly = true;
		}

		private void FillData()
		{
			dtCLTG = DataTool.SQLGetDataTable("R80CLTG", "*, CAST(0 AS BIT) AS Chon, CAST('' AS VARCHAR(10)) AS Color", "", "Stt");

			bdsCLTG.DataSource = dtCLTG;
			dgvCLTG.DataSource = bdsCLTG;

			this.bdsSearch = bdsCLTG;
			this.ExportControl = dgvCLTG;
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;
			if (dteNgay_Ct.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Ngay_Ct") + " " + Languages.GetLanguage("Not_Null"));

				return false;
			}

			return bvalid;
		}

		private void Tinh_CLTG(bool bHetDuCuoi)
		{
			if (!FormCheckValid())
				return;

			DateTime dtNgay_Ct = Library.StrToDate(dteNgay_Ct.Text);

			if (this.chkIs_Hach_Toan.Checked)
			{
				if (!Common.CheckDataLocked(dtNgay_Ct))
				{
					this.chkIs_Hach_Toan.Checked = false;
					Common.MsgCancel("Dữ liệu đã khóa, không cho phép hạch toán CLTG");
					return;
				}
			}

			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != dtNgay_Ct.Year)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			dtKetQuaCLTG = SQLExec.ExecuteReturnDt("SELECT TOP 0 Stt, Stt0, CAST(0 AS INT) AS Stt_Rec, Ma_Ct, Ngay_Ct, So_Ct, Ma_Tte, Ty_Gia, Dien_Giai, Tk_No, Tk_Co, Ma_Dt, Ma_Hd, Tien_Nt9, Tien, Tien_Nt FROM R80CtKT");

			DataTable dtKetQuaCLTG0 = new DataTable();

			Hashtable ht = new Hashtable();
			string strStt_List = string.Empty;

			foreach (DataRow dr in dtCLTG.Rows)
			{
				if (!(bool)dr["Chon"])
					continue;

				Common.ShowStatus(Languages.GetLanguage("In_Process") + " " + dr["Tk"].ToString());

				ht["NGAY_CT"] = dtNgay_Ct;
				ht["STT"] = dr["Stt"].ToString().Trim();
				ht["IS_HACH_TOAN"] = chkIs_Hach_Toan.Checked;
				ht["HET_DU_CUOI"] = bHetDuCuoi;
				ht["MA_DVCS"] = Element.sysMa_DvCs;

				if (dr["Loai_CLTG"].ToString().StartsWith("1"))
					dtKetQuaCLTG0 = SQLExec.ExecuteReturnDt("Sp_Tinh_CLTG", ht, CommandType.StoredProcedure);
				else if (dr["Loai_CLTG"].ToString().StartsWith("2"))
					dtKetQuaCLTG0 = SQLExec.ExecuteReturnDt("Sp_Tinh_CLTG_HanTt", ht, CommandType.StoredProcedure);
				else if (dr["Loai_CLTG"].ToString().StartsWith("3"))
					dtKetQuaCLTG0 = SQLExec.ExecuteReturnDt("Sp_Tinh_CLTG_HopDong", ht, CommandType.StoredProcedure);

				//Copy kết quả vào bảng Hiển thị
				if (dtKetQuaCLTG0.Rows.Count > 0)
				{
					dr["Color"] = "Blue";
					foreach (DataRow drKQ in dtKetQuaCLTG0.Rows)
					{
						DataRow drNew = dtKetQuaCLTG.NewRow();
						DataTool.CopyDataRow(drKQ, drNew);
						dtKetQuaCLTG.Rows.Add(drNew);
					}
				}
				else
				{
					dr["Color"] = "";
				}

				dtKetQuaCLTG0.Clear();
				strStt_List = strStt_List + (strStt_List == string.Empty ? "" : ",") + dr["Stt"].ToString().Trim();
			}

			if (strStt_List == string.Empty)
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa chọn tài khoản đánh giá CLTG" : "You have not selected account";
				Common.MsgCancel(strMsg);
				return;
			}

			bdsKetQuaCLTG.DataSource = dtKetQuaCLTG;
			dgvKetQuaCLTG.DataSource = bdsKetQuaCLTG;

			Common.EndShowStatus();
			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsCLTG.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCLTG.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCLTG.Current).Row, ref drCurrent);
			else
				drCurrent = dtCLTG.NewRow();

			if (Convert.ToDouble(drCurrent["Ty_Gia"]) == 0)
			{
				Hashtable ht = new Hashtable();
				ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
				ht.Add("MA_TTE", "USD");

				drCurrent["Ty_Gia"] = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetTyGia", ht, CommandType.StoredProcedure));
			}

			frmTinh_CLTG_Edit frmEdit = new frmTinh_CLTG_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCLTG.Position >= 0)
						dtCLTG.ImportRow(drCurrent);
					else
						dtCLTG.Rows.Add(drCurrent);

					bdsCLTG.Position = bdsCLTG.Find("Stt", drCurrent["Stt"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCLTG.Current).Row);
				
				dtCLTG.AcceptChanges();
			}
			else
				dtCLTG.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsCLTG.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCLTG.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R80CLTG", drCurrent))
			{
				bdsCLTG.RemoveAt(bdsCLTG.Position);
				dtCLTG.AcceptChanges();
			}
		}		

		#endregion 

		#region Event

		void btTinhCLTG_Click(object sender, EventArgs e)
		{
			this.Tinh_CLTG(false);
		}

		void btTinhCLTG_HetSoDu_Click(object sender, EventArgs e)
		{
			this.Tinh_CLTG(true);
		}

		void dteNgay_Ct_Validating(object sender, CancelEventArgs e)
		{
			Hashtable ht = new Hashtable();
			ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
			ht.Add("MA_TTE", "USD");

			//numTy_Gia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetTyGia", ht, CommandType.StoredProcedure));
		}

		void bdsCLTG_PositionChanged(object sender, EventArgs e)
		{
			if (bdsCLTG.Position < 0 || bdsKetQuaCLTG == null)
				return;

			DataRow drCurrent = ((DataRowView)bdsCLTG.Current).Row;

			bdsKetQuaCLTG.Filter = "Stt_Rec = " + ((int)drCurrent["Stt"]).ToString();
		}

		#endregion        

	}
}