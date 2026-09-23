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
	public partial class frmTinh_CLTGBQ : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		private DataTable dtCLTGBQ;
		private DataTable dtKetQuaCLTGBQ;
		
		private BindingSource bdsKetQuaCLTGBQ = new BindingSource();
		private BindingSource bdsCLTGBQ = new BindingSource();

		DataRow drCurrent;

		#endregion

		#region Contructor

		public frmTinh_CLTGBQ()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmCLTG_View_KeyDown);

			btTinhCLTG.Click += new EventHandler(btTinhCLTG_Click);
			bdsCLTGBQ.PositionChanged += new EventHandler(bdsCLTG_PositionChanged);
		}
        
		public void Load()
		{
			dteNgay_Ct1.Text = Element.sysNgay_Ct1.ToString("dd/MM/yyyy");
			dteNgay_Ct2.Text = Element.sysNgay_Ct2.ToString("dd/MM/yyyy");

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
			dgvCLTG.strZone = "CLTGBQ";
			dgvCLTG.BuildGridView();
			dgvCLTG.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvCLTG.Columns)
			{
				if (dgvc.Name == "CHON")
					dgvc.ReadOnly = false;
				else
					dgvc.ReadOnly = true;
			}

			dgvKetQuaCLTG.strZone = "KQCLTGBQ";
			dgvKetQuaCLTG.BuildGridView();
			dgvKetQuaCLTG.ReadOnly = true;
		}

		private void FillData()
		{
			dtCLTGBQ = DataTool.SQLGetDataTable("R80CLTGBQ", "*, CAST(0 AS BIT) AS Chon, CAST('' AS VARCHAR(10)) AS Color", "", "Stt");

			bdsCLTGBQ.DataSource = dtCLTGBQ;
			dgvCLTG.DataSource = bdsCLTGBQ;

			this.bdsSearch = bdsCLTGBQ;
			this.ExportControl = dgvCLTG;
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;
			if (dteNgay_Ct1.IsNull || dteNgay_Ct2.IsNull)
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

			DateTime dtNgay_Ct1 = Library.StrToDate(this.dteNgay_Ct1.Text);
			DateTime dtNgay_Ct2 = Library.StrToDate(this.dteNgay_Ct2.Text);

			if (this.chkIs_Hach_Toan.Checked)
			{
				if (!Common.CheckDataLocked(dtNgay_Ct1) || !Common.CheckDataLocked(dtNgay_Ct2))
				{
					this.chkIs_Hach_Toan.Checked = false;
					Common.MsgCancel("Dữ liệu đã khóa, không cho phép hạch toán CLTG");
					return;
				}
			}

			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != dtNgay_Ct1.Year)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			if (!Common.MsgYes_No("Bạn có chắc chắn tính CLTG từ ngày [" + dteNgay_Ct1.Text + "] đến ngày [" + dteNgay_Ct2.Text + "]"))
			{
				return;
			}

			dtKetQuaCLTGBQ = SQLExec.ExecuteReturnDt("SELECT TOP 0 Stt, Stt0, CAST(0 AS INT) AS Stt_Rec, Ma_Ct, Ngay_Ct, So_Ct, Ma_Tte, Ty_Gia, Dien_Giai, Tk, Tk_Du, Ma_Dt, Ma_Hd, Ps_No, Ps_Co, Ps_No_Nt, Ps_Co_Nt FROM vw_SoCai");

			DataTable dtKetQuaCLTG0 = new DataTable();

			Hashtable ht = new Hashtable();
			string strStt_List = string.Empty;

			foreach (DataRow dr in dtCLTGBQ.Rows)
			{
				if (!(bool)dr["Chon"])
					continue;

				Common.ShowStatus(Languages.GetLanguage("In_Process") + " " + dr["Tk"].ToString());

				ht["NGAY_CT1"] = dtNgay_Ct1;
				ht["NGAY_CT2"] = dtNgay_Ct2;
				ht["STT"] = dr["Stt"].ToString().Trim();
				ht["IS_HACH_TOAN"] = chkIs_Hach_Toan.Checked;
				ht["MA_DVCS"] = Element.sysMa_DvCs;

				dtKetQuaCLTG0 = SQLExec.ExecuteReturnDt("Sp_Tinh_CLTGBQ", ht, CommandType.StoredProcedure);

				//Copy kết quả vào bảng Hiển thị
				if (dtKetQuaCLTG0.Rows.Count > 0)
				{
					dr["Color"] = "Blue";
					foreach (DataRow drKQ in dtKetQuaCLTG0.Rows)
					{
						DataRow drNew = dtKetQuaCLTGBQ.NewRow();
						DataTool.CopyDataRow(drKQ, drNew);
						dtKetQuaCLTGBQ.Rows.Add(drNew);
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

			bdsKetQuaCLTGBQ.DataSource = dtKetQuaCLTGBQ;
			dgvKetQuaCLTG.DataSource = bdsKetQuaCLTGBQ;

			Common.EndShowStatus();
			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsCLTGBQ.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCLTGBQ.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCLTGBQ.Current).Row, ref drCurrent);
			else
				drCurrent = dtCLTGBQ.NewRow();

			frmTinh_CLTGBQ_Edit frmEdit = new frmTinh_CLTGBQ_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCLTGBQ.Position >= 0)
						dtCLTGBQ.ImportRow(drCurrent);
					else
						dtCLTGBQ.Rows.Add(drCurrent);

					bdsCLTGBQ.Position = bdsCLTGBQ.Find("Stt", drCurrent["Stt"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCLTGBQ.Current).Row);
				
				dtCLTGBQ.AcceptChanges();
			}
			else
				dtCLTGBQ.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsCLTGBQ.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCLTGBQ.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R80CLTG", drCurrent))
			{
				bdsCLTGBQ.RemoveAt(bdsCLTGBQ.Position);
				dtCLTGBQ.AcceptChanges();
			}
		}		

		#endregion 

		#region Event

		void btTinhCLTG_Click(object sender, EventArgs e)
		{
			this.Tinh_CLTG(false);
		}

		void bdsCLTG_PositionChanged(object sender, EventArgs e)
		{
			if (bdsCLTGBQ.Position < 0 || bdsKetQuaCLTGBQ == null)
				return;

			DataRow drCurrent = ((DataRowView)bdsCLTGBQ.Current).Row;

			bdsKetQuaCLTGBQ.Filter = "Stt_Rec = " + ((int)drCurrent["Stt"]).ToString();
		}

		void frmCLTG_View_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				if (e.KeyCode == Keys.A)
					foreach (DataRow dr in dtCLTGBQ.Rows)
						dr["Chon"] = true;

				else if (e.KeyCode == Keys.U)
					foreach (DataRow dr in dtCLTGBQ.Rows)
						dr["Chon"] = false;
			}
			else if (dgvCLTG.Focused && e.KeyCode == Keys.Space)
				((DataRowView)bdsCLTGBQ.Current).Row["Chon"] = !(bool)((DataRowView)bdsCLTGBQ.Current).Row["Chon"];
		}

		#endregion        

	}
}