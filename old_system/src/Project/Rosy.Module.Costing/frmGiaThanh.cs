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
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Customize;
using RosySystem.Public;
using RosyList;

namespace RosyModule.Costing
{
	public partial class frmGiaThanh : RosySystem.Customize.frmView
	{
		#region Biến

		private DataTable dtZDoDangYt;
		private DataTable dtZKetQuaPb;
		private DataTable dtZKetQuaPb0;
		private DataTable dtZGiaThanh;
		private DataTable dtZGiaThanh0;

		private BindingSource bdsZDoDangYt = new BindingSource();
		private BindingSource bdsZKetQuaPb = new BindingSource();
		private BindingSource bdsZKetQuaPb0 = new BindingSource();
		private BindingSource bdsZGiaThanh = new BindingSource();
		private BindingSource bdsZGiaThanh0 = new BindingSource();

		private DataRow drCurrent;

		public DateTime dteNgay_Ct1;
		public DateTime dteNgay_Ct2;

		bool bReloadPage1 = true;
		bool bReloadPage2 = true;
		bool bReloadPage3 = true;

		#endregion

		#region Contructor

		public frmGiaThanh()
		{
			InitializeComponent();

			this.numThang1.Value = Element.sysNgay_Ct2.Month;
			this.numThang2.Value = Element.sysNgay_Ct2.Month;
			this.SetNgay_Ct();

			bdsZKetQuaPb.PositionChanged += new EventHandler(bdsZKetQuaPb_PositionChanged);
			bdsZGiaThanh.PositionChanged += new EventHandler(bdsZGiaThanh_PositionChanged);

			dgvZDoDangYt.CellEndEdit += new DataGridViewCellEventHandler(dgvZDoDangYt_CellEndEdit);
			dgvGiaThanh.CellEndEdit += new DataGridViewCellEventHandler(dgvGiaThanh_CellEndEdit);

			dgvGiaThanh.Enter += new EventHandler(dgvGiaThanh_Enter);
			dgvGiaThanh0.Enter += new EventHandler(dgvGiaThanh_Enter);
			dgvZDoDangYt.Enter += new EventHandler(dgvGiaThanh_Enter);
			dgvZKetQuaPb.Enter += new EventHandler(dgvGiaThanh_Enter);
			dgvZKetQuaPb0.Enter += new EventHandler(dgvGiaThanh_Enter);

			this.numThang1.Validated += new EventHandler(numThang1_Validated);
			this.numThang2.Validated += new EventHandler(numThang2_Validated);

			this.txtTk.Validating += new CancelEventHandler(txtTk_Validating);

			this.btTapHopChiPhi.Click += new EventHandler(btTapHopChiPhi_Click);
			this.btTinhDoDangYt.Click += new EventHandler(btTinhDoDangYt_Click);
			this.btTinhDoDangSp.Click += new EventHandler(btTinhDoDangSp_Click);
			this.btCapNhatGiaThanh.Click += new EventHandler(btCapNhatGiaThanh_Click);

			this.btZPhanBo1.Click += new EventHandler(btZPhanBo1_Click);
			this.btZPhanBo2.Click += new EventHandler(btZPhanBo2_Click);
			this.btZPhanBo3.Click += new EventHandler(btZPhanBo3_Click);
			this.btZPhanBo4.Click += new EventHandler(btZPhanBo4_Click);

			this.btZPhanBoCheck.Click += new EventHandler(btZPhanBoCheck_Click);
			this.btZTapHopCheck.Click += new EventHandler(btZTapHopCheck_Click);
			this.btCapNhatGiaThanhCheck.Click += new EventHandler(btCapNhatGiaThanhCheck_Click);
			this.btCheck_BOM.Click += new EventHandler(btCheck_BOM_Click);

			this.btEdit_Th_Bd_Z.Click += new EventHandler(btEdit_Th_Bd_Z_Click);

			this.rsTabControl1.SelectedIndexChanged += new EventHandler(rsTabControl1_SelectedIndexChanged);

			this.btExit.Click += new EventHandler(btExit_Click);
		}

		new public void Load()
		{
			this.txtTk.Text = (string)SQLExec.ExecuteReturnValue("SELECT TOP 1 Tk FROM R07ZPhanDoan");

			if (DataTool.SQLCheckExist("INFORMATION_SCHEMA.COLUMNS", new string[] {"Table_Name", "Column_Name"}, new object[] {"R00Nam", "TH_BD_Z"}))
				this.txtTh_Bd_Z.Text = SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Th_Bd_Z), 1) FROM R00Nam WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Nam = " + Element.sysWorkingYear.ToString()).ToString();
			else
				SQLExec.Execute("ALTER TABLE R00Nam ADD Th_BD_Z INT NOT NULL DEFAULT(1)");

			this.Build();

			bReloadPage1 = true;
			bReloadPage2 = true;
			bReloadPage3 = true;

			this.FillData();
			this.LoadDicName();
			this.BindingLanguage();

			this.Show();
		}

		private void LoadDicName()
		{
			if (txtTk.Text != string.Empty)
			{
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk.Text);
			}
			else
				lbtTen_Tk.Text = string.Empty;
		}

		#endregion

		#region Methods

		private void Build()
		{
			dgvZDoDangYt.ReadOnly = false;
			dgvZDoDangYt.strZone = "ZDODANGYT";
			dgvZDoDangYt.BuildGridView();

			foreach (DataGridViewColumn dc in dgvZDoDangYt.Columns)
			{
				if (dc.Name == "SL_DD2" || dc.Name == "TIEN_DD2")
					dc.ReadOnly = false;
				else
					dc.ReadOnly = true;
			}

			//Kết quả phân bổ
			dgvZKetQuaPb.strZone = "ZKETQUAPB";
			dgvZKetQuaPb.BuildGridView();

			dgvZKetQuaPb0.strZone = "ZKETQUAPB0";
			dgvZKetQuaPb0.BuildGridView();

			//Tính giá thành
			dgvGiaThanh.ReadOnly = false;
			dgvGiaThanh.strZone = "GIATHANH";
			dgvGiaThanh.BuildGridView();

			foreach (DataGridViewColumn dc in dgvGiaThanh.Columns)
			{
				if (dc.Name == "SL_DD" || dc.Name == "TIEN_DD" || dc.Name == "PT_HT")
					dc.ReadOnly = false;
				else
					dc.ReadOnly = true;
			}

			dgvGiaThanh0.strZone = "GIATHANH0";
			dgvGiaThanh0.BuildGridView();
		}

		private void FillData()
		{
			if (bReloadPage1 && rsTabControl1.SelectedTab == tabPage1)
				this.ReFillData_ZDoDangYt();

			if (bReloadPage2 && rsTabControl1.SelectedTab == tabPage2)
				this.ReFillData_ZKetQuaPb();

			if (bReloadPage3 && rsTabControl1.SelectedTab == tabPage3)
				this.ReFillData_ZGiaThanh();
		}

		private void ReFillData_ZDoDangYt()
		{
			Hashtable htParameter = new Hashtable();
			htParameter.Add("NGAY_CT1", dteNgay_Ct1);
			htParameter.Add("NGAY_CT2", dteNgay_Ct2);
			htParameter.Add("TK", this.txtTk.Text);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

			dtZDoDangYt = SQLExec.ExecuteReturnDt("sp_GetZDoDangYt", htParameter, CommandType.StoredProcedure);

			bdsZDoDangYt.DataSource = dtZDoDangYt;
			dgvZDoDangYt.DataSource = bdsZDoDangYt;

			bReloadPage1 = false;
		}

		private void ReFillData_ZKetQuaPb()
		{
			Hashtable htParameter = new Hashtable();
			htParameter.Add("NGAY_CT1", dteNgay_Ct1);
			htParameter.Add("NGAY_CT2", dteNgay_Ct2);
			htParameter.Add("TK", this.txtTk.Text);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsKetQua = SQLExec.ExecuteReturnDs("sp_GetZKetQuaPb", htParameter, CommandType.StoredProcedure);

			dtZKetQuaPb = dsKetQua.Tables[0];
			bdsZKetQuaPb.DataSource = dtZKetQuaPb;
			dgvZKetQuaPb.DataSource = bdsZKetQuaPb;

			//Chi tiết kết quả phân bổ
			dtZKetQuaPb0 = dsKetQua.Tables[1];
			bdsZKetQuaPb0.DataSource = dtZKetQuaPb0;
			dgvZKetQuaPb0.DataSource = bdsZKetQuaPb0;

			bReloadPage2 = false;
		}

		private void ReFillData_ZGiaThanh()
		{
			Hashtable htParameter = new Hashtable();
			htParameter.Add("NGAY_CT1", dteNgay_Ct1);
			htParameter.Add("NGAY_CT2", dteNgay_Ct2);
			htParameter.Add("TK", this.txtTk.Text);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsKetQua = SQLExec.ExecuteReturnDs("sp_GetZGiaThanh", htParameter, CommandType.StoredProcedure);

			dtZGiaThanh = dsKetQua.Tables[0];
			bdsZGiaThanh.DataSource = dtZGiaThanh;
			dgvGiaThanh.DataSource = bdsZGiaThanh;

			//Chi tiết kết quả phân bổ
			dtZGiaThanh0 = dsKetQua.Tables[1];
			bdsZGiaThanh0.DataSource = dtZGiaThanh0;
			dgvGiaThanh0.DataSource = bdsZGiaThanh0;

			//Ngầm định phương pháp xác định dở dang
			DataRow drZPhanDoan = DataTool.SQLGetDataRowByID("R07zPhanDoan", "Tk", txtTk.Text);
			if (drZPhanDoan != null && drZPhanDoan.Table.Columns.Contains("Loai_DD") && txtTk.bTextChange)
			{
				if ((string)drZPhanDoan["Loai_DD"] == "2")
					radioButton2.Checked = true;
				else if ((string)drZPhanDoan["Loai_DD"] == "3")
					radioButton3.Checked = true;
				else
					radioButton1.Checked = true;
			}

			bReloadPage3 = false;
		}

		private void SetNgay_Ct()
		{
			dteNgay_Ct1 = Common.GetDate(Element.sysWorkingYear, Convert.ToInt16(this.numThang1.Value), 1);
			dteNgay_Ct2 = Common.GetDate(Element.sysWorkingYear, Convert.ToInt16(this.numThang2.Value), 1).AddMonths(1).AddDays(-1);

			Element.sysNgay_Ct1 = dteNgay_Ct1;
			Element.sysNgay_Ct2 = dteNgay_Ct2;
		}

		#endregion

		#region Events

		void dgvGiaThanh_Enter(object sender, EventArgs e)
		{
			if ((RosySystem.Control.rsDataGridView)sender == dgvGiaThanh)
			{
				this.ExportControl = dgvGiaThanh;
				this.bdsSearch = bdsZGiaThanh;
			}
			else if ((RosySystem.Control.rsDataGridView)sender == dgvGiaThanh0)
			{
				this.ExportControl = dgvGiaThanh0;
				this.bdsSearch = bdsZGiaThanh0;
			}
			else if ((RosySystem.Control.rsDataGridView)sender == dgvZDoDangYt)
			{
				this.ExportControl = dgvZDoDangYt;
				this.bdsSearch = bdsZDoDangYt;
			}
			else if ((RosySystem.Control.rsDataGridView)sender == dgvZKetQuaPb)
			{
				this.ExportControl = dgvZKetQuaPb;
				this.bdsSearch = bdsZKetQuaPb;
			}
			else if ((RosySystem.Control.rsDataGridView)sender == dgvZKetQuaPb0)
			{
				this.ExportControl = dgvZKetQuaPb0;
				this.bdsSearch = bdsZKetQuaPb0;
			}
		}

		void bdsZKetQuaPb_PositionChanged(object sender, EventArgs e)
		{
			if (bdsZKetQuaPb.Current != null)
			{
				DataRow dr = ((DataRowView)bdsZKetQuaPb.Current).Row;

				bdsZKetQuaPb0.Filter = "Tk = '" + dr["Tk"] + "' AND Tk_Cp = '" + dr["Tk_Cp"] + "' AND Ma_Vt = '" + dr["Ma_Vt"] + "'";
			}
		}

		void bdsZGiaThanh_PositionChanged(object sender, EventArgs e)
		{
			if (bdsZGiaThanh.Current != null)
			{
				DataRow dr = ((DataRowView)bdsZGiaThanh.Current).Row;

				bdsZGiaThanh0.Filter = "Ma_Vt_Sp = '" + dr["Ma_Vt_Sp"] + "'";
			}
		}

		void dgvZDoDangYt_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewColumn dgvc = this.dgvZDoDangYt.Columns[e.ColumnIndex];

			if (dgvc.Name == "SL_DD2" || dgvc.Name == "TIEN_DD2")
			{
				drCurrent = ((DataRowView)bdsZDoDangYt.Current).Row;
				int iIdent00;

				Hashtable htParameter = new Hashtable();
				htParameter.Add("NGAY_CT2", dteNgay_Ct2);
				htParameter.Add("TK", (string)drCurrent["Tk"]);
				htParameter.Add("TK_CP", (string)drCurrent["Tk_Cp"]);
				htParameter.Add("MA_YT", (string)drCurrent["Ma_Yt"]);
				htParameter.Add("MA_VT", (string)drCurrent["Ma_Vt"]);
				htParameter.Add("MA_VT_SP", (string)drCurrent["Ma_Vt_Sp"]);
				htParameter.Add("SL_DD", Convert.ToDouble(drCurrent["Sl_Dd2"]));
				htParameter.Add("TIEN_DD", Convert.ToDouble(drCurrent["Tien_Dd2"]));
				htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

				iIdent00 = (int)SQLExec.ExecuteReturnValue("sp_UpdateZDoDangYt", htParameter, CommandType.StoredProcedure);

				if (iIdent00 > 0 && iIdent00 != Convert.ToInt16(drCurrent["Ident00"]))
				{
					drCurrent["Ident00"] = iIdent00;
				}
			}
		}

		void dgvGiaThanh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị");
				((DataRowView)bdsZGiaThanh.Current).Row.CancelEdit();
				return;
			}

			DataGridViewColumn dgvc = this.dgvGiaThanh.Columns[e.ColumnIndex];

			if (dgvc.Name == "SL_DD" || dgvc.Name == "PT_HT")
			{
				drCurrent = ((DataRowView)bdsZGiaThanh.Current).Row;
				int iIdent00 = (int)(drCurrent["Ident00"]);

				if (iIdent00 > 0)
				{
					Hashtable htParameter = new Hashtable();
					htParameter.Add("SL_DD", Convert.ToDouble(drCurrent["SL_Dd"]));
					htParameter.Add("PT_HT", Convert.ToDouble(drCurrent["Pt_Ht"]));
					htParameter.Add("IDENT00", iIdent00);
					htParameter.Add("NGAY_CT1", dteNgay_Ct1);
					htParameter.Add("NGAY_CT2", dteNgay_Ct2);

					SQLExec.Execute("UPDATE R07GiaThanh SET SL_Dd = @SL_DD, Pt_Ht = @PT_HT " +
						" WHERE Is_SoDuDau = 0 AND Ident00 = @IDENT00 AND MONTH(Ngay_Ct) = MONTH(@NGAY_CT2)", htParameter, CommandType.Text);
				}
				else
				{
					drCurrent["SL_Dd"] = 0;
					drCurrent["Pt_Ht"] = 0;
				}
			}
		}

		void txtTk_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk.Text.Trim();
			bool bRequire = true;
			string strKey = "Tk IN (SELECT Tk FROM R07ZPhanDoan)";

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, strKey, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk.Text = string.Empty;
				lbtTen_Tk.Text = string.Empty;
			}
			else
			{
				txtTk.Text = drLookup["Tk"].ToString();
				lbtTen_Tk.Text = drLookup["Ten_Tk"].ToString();
			}

			if (txtTk.bTextChange)
			{
				bReloadPage1 = true;
				bReloadPage2 = true;
				bReloadPage3 = true;

				this.FillData();
			}

			//dicName[lbtTen_Nh_Vt.Name] = lbtTen_Nh_Vt.Text;
		}

		void btTapHopChiPhi_Click(object sender, EventArgs e)
		{
			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			Hashtable htParameter = new Hashtable();
			htParameter.Add("NGAY_CT1", dteNgay_Ct1);
			htParameter.Add("NGAY_CT2", dteNgay_Ct2);
			htParameter.Add("TK", this.txtTk.Text);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

			SQLExec.Execute("sp_ZTapHopChiPhi", htParameter, CommandType.StoredProcedure);

			this.ReFillData_ZDoDangYt();
			this.ReFillData_ZKetQuaPb();
			this.ReFillData_ZGiaThanh();

			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		void btTinhDoDangYt_Click(object sender, EventArgs e)
		{
			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			Hashtable htParameter = new Hashtable();
			htParameter.Add("NGAY_CT1", dteNgay_Ct1);
			htParameter.Add("NGAY_CT2", dteNgay_Ct2);
			htParameter.Add("TK", this.txtTk.Text);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

			SQLExec.Execute("sp_ZTinhDoDangYt", htParameter, CommandType.StoredProcedure);

			this.ReFillData_ZDoDangYt();

			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		void btTinhDoDangSp_Click(object sender, EventArgs e)
		{
			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			Hashtable htParameter = new Hashtable();
			htParameter.Add("NGAY_CT1", dteNgay_Ct1);
			htParameter.Add("NGAY_CT2", dteNgay_Ct2);
			htParameter.Add("TK", this.txtTk.Text);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

			if (radioButton1.Checked)
				htParameter.Add("LOAI_DD", 1);
			else if (radioButton2.Checked)
				htParameter.Add("LOAI_DD", 2);
			else
				htParameter.Add("LOAI_DD", 3);

			SQLExec.Execute("sp_ZTinhDoDangSp", htParameter, CommandType.StoredProcedure);
			SQLExec.Execute("sp_ZTinhGiaThanh", htParameter, CommandType.StoredProcedure);

			this.ReFillData_ZGiaThanh();

			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		void btCapNhatGiaThanh_Click(object sender, EventArgs e)
		{
			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			Hashtable htParameter = new Hashtable();
			htParameter.Add("NGAY_CT1", dteNgay_Ct1);
			htParameter.Add("NGAY_CT2", dteNgay_Ct2);
			htParameter.Add("TK", this.txtTk.Text);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

			SQLExec.Execute("sp_ZCapNhatGiaThanh", htParameter, CommandType.StoredProcedure);

			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		void btZPhanBo1_Click(object sender, EventArgs e)
		{
			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			Hashtable htParameter = new Hashtable();
			htParameter.Add("NGAY_CT1", dteNgay_Ct1);
			htParameter.Add("NGAY_CT2", dteNgay_Ct2);
			htParameter.Add("TK", this.txtTk.Text);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

			SQLExec.Execute("sp_ZPhanBo1", htParameter, CommandType.StoredProcedure);

			this.ReFillData_ZKetQuaPb();

			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		void btZPhanBo2_Click(object sender, EventArgs e)
		{
			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			Hashtable htParameter = new Hashtable();
			htParameter.Add("NGAY_CT1", dteNgay_Ct1);
			htParameter.Add("NGAY_CT2", dteNgay_Ct2);
			htParameter.Add("TK", this.txtTk.Text);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

			SQLExec.Execute("sp_ZPhanBo2", htParameter, CommandType.StoredProcedure);

			this.ReFillData_ZKetQuaPb();

			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		void btZPhanBo3_Click(object sender, EventArgs e)
		{
			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			Hashtable htParameter = new Hashtable();
			htParameter.Add("NGAY_CT1", dteNgay_Ct1);
			htParameter.Add("NGAY_CT2", dteNgay_Ct2);
			htParameter.Add("TK", this.txtTk.Text);
			htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

			SQLExec.Execute("sp_ZPhanBo3", htParameter, CommandType.StoredProcedure);

			this.ReFillData_ZKetQuaPb();

			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		void btZPhanBo4_Click(object sender, EventArgs e)
		{
			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

		}

		void btZPhanBoCheck_Click(object sender, EventArgs e)
		{
			frmZCheckPhanBo frmCheck = new frmZCheckPhanBo();
			frmCheck.MdiParent = this.MdiParent;
			frmCheck.Load(this);
		}

		void btCapNhatGiaThanhCheck_Click(object sender, EventArgs e)
		{
			frmZCheckCapNhatGiaThanh frmCheck = new frmZCheckCapNhatGiaThanh();
			frmCheck.MdiParent = this.MdiParent;
			frmCheck.Load(this);
		}
		void btZTapHopCheck_Click(object sender, EventArgs e)
		{
			frmZCheckTapHop frmCheck = new frmZCheckTapHop();
			frmCheck.MdiParent = this.MdiParent;
			frmCheck.Load(this);
		}

		void btCheck_BOM_Click(object sender, EventArgs e)
		{
			if (dtZDoDangYt == null)
				return;

			frmZCheckBOM frmCheck = new frmZCheckBOM();
			frmCheck.MdiParent = this.MdiParent;
			frmCheck.Load(this, dtZDoDangYt);
		}

		void btEdit_Th_Bd_Z_Click(object sender, EventArgs e)
		{
			if (txtTh_Bd_Z.Enabled)
			{
				int iNam = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Th_Bd_Z), 1) FROM R00Nam WHERE Ma_DvCs = '" + Element.sysMa_DvCs + "' AND Nam = " + Element.sysWorkingYear.ToString()));

				if (iNam.ToString() != txtTh_Bd_Z.Text)
				{
					if (Common.MsgYes_No("Bạn có chắc chắn sửa lại Tháng bắt đầu Tính giá thành Năm " + Element.sysWorkingYear + " về " + txtTh_Bd_Z.Text + " không?"))
					{
						string strSQLExec = "UPDATE R00Nam SET Th_Bd_Z = @Th_Bd_Z WHERE Ma_DvCs = @Ma_DvCs AND Nam = @Nam";
						SQLExec.Execute(strSQLExec, new string[] { "TH_BD_Z", "MA_DVCS", "NAM" }, new object[] { txtTh_Bd_Z.Text, Element.sysMa_DvCs, Element.sysWorkingYear });
					}
				}
				txtTh_Bd_Z.Enabled = false;
				lblTh_Bd_Z.Enabled = false;
			}
			else
			{
				txtTh_Bd_Z.Enabled = true;
				lblTh_Bd_Z.Enabled = true;
			}
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void numThang1_Validated(object sender, EventArgs e)
		{
			this.numThang2.Value = this.numThang1.Value;
			this.SetNgay_Ct();

			if (this.numThang1.bTextChange)
			{
				bReloadPage1 = true;
				bReloadPage2 = true;
				bReloadPage3 = true;

				this.FillData();
			}
		}

		void numThang2_Validated(object sender, EventArgs e)
		{
			this.SetNgay_Ct();

			if (this.numThang2.bTextChange)
			{
				bReloadPage1 = true;
				bReloadPage2 = true;
				bReloadPage3 = true;

				this.FillData();
			}
		}

		void rsTabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.FillData();
		}

		#endregion		
		
	}
}
