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
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Element;
using RosyList;

namespace RosyModule.Salary
{
	public partial class frmBangLuong : RosySystem.Customize.frmView
	{
		private DataTable dtBangLuong;
		private DataTable dtDmTn;

		private BindingSource bdsBangLuong = new BindingSource();
		private DataRow drCurrent;
		private rsDataGridView dgvBangLuong = new rsDataGridView();

		public frmBangLuong()
		{
			InitializeComponent();

			cboThang.SelectedValueChanged += new EventHandler(cboThang_SelectedValueChanged);
			cboMa_Bp.TextChanged += new EventHandler(cboMa_Bp_TextChanged);

			btCreateSalary.Click += new EventHandler(btCreateSalary_Click);
			btCalcSalary.Click += new EventHandler(btCalcSalary_Click);
			btDeleteSalary.Click += new EventHandler(btDeleteSalary_Click);
			btPostedSalary.Click += new EventHandler(btPostedSalary_Click);

			radioButton1.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
			radioButton2.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
			radioButton3.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);

			dgvBangLuong.CellValidated += new DataGridViewCellEventHandler(dgvBangLuong_CellValidated);

			this.KeyDown += new KeyEventHandler(frmBangLuong_KeyDown);
		}

		public override void Load()
		{
			DataTable dtThang = SQLExec.ExecuteReturnDt("SELECT 0 Thang UNION SELECT DISTINCT MONTH(Ngay_Ct) AS Thang FROM R10BangLuong WHERE YEAR(Ngay_Ct) = " + Element.sysWorkingYear.ToString());
			if (dtThang != null)
			{
				cboThang.ValueMember = "THANG";
				cboThang.DisplayMember = "THANG";
				cboThang.DataSource = dtThang;
				cboThang.SelectedIndex = cboThang.Items.Count - 1;
			}

			//Gắn Ma_Bp vào ComboBox
			DataTable dtDmBp = SQLExec.ExecuteReturnDt("SELECT '*' Ma_Bp, N'Tất cả' Ten_Bp UNION SELECT Ma_Bp, Ten_Bp FROM R81DmBp WHERE Nh_Cuoi = 1 ORDER BY Ma_Bp");
			//dtDmBp.Rows.Add(new string[] { "*", "Tất cả" });

			cboMa_Bp.lstItem.BuildListView("Ma_Bp:100,Ten_Bp:200");
			cboMa_Bp.lstItem.DataSource = dtDmBp;
			cboMa_Bp.lstItem.Size = new Size(300, cboMa_Bp.lstItem.Items.Count * 8);
			cboMa_Bp.lstItem.GridLines = true;

			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.ShowBangLuong();

			this.Show();
		}

		#region Methods

		private void Build()
		{
			//Build
			dgvBangLuong.strZone = "BANGLUONG";
			dgvBangLuong.Dock = DockStyle.Fill;
			dgvBangLuong.BuildGridView();
			dgvBangLuong.Columns["Ma_Dt_CbNv"].Frozen = true;
			dgvBangLuong.Columns["Ten_Dt_CbNv"].Frozen = true;

			this.panel1.Controls.Add(dgvBangLuong);
		}

		private void FillData()
		{
			//Lấy cấu trúc các cột
			dtDmTn = SQLExec.ExecuteReturnDt("SELECT * FROM R10DmTn ORDER BY Stt");

			//Lấy nội dung bảng lương
			Hashtable htPara = new Hashtable();
			htPara.Add("THANG", cboThang.SelectedValue);
			htPara.Add("NAM", Element.sysWorkingYear);
			htPara.Add("MA_BP", cboMa_Bp.Text);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);            

			dtBangLuong = SQLExec.ExecuteReturnDt("sp_HRM_GetBangLuong", htPara, CommandType.StoredProcedure);

			bdsBangLuong.DataSource = dtBangLuong;
			dgvBangLuong.DataSource = bdsBangLuong;
		}

		private void ShowBangLuong()
		{
			//1-THANHTOAN
			//2-THUNHAP
			//3-TRULUONG

			dgvBangLuong.ReadOnly = false;

			for (int i = 0; i < dgvBangLuong.Columns.Count; i++)
			{
				string strColumnName = dgvBangLuong.Columns[i].Name;
				int iCount = dtDmTn.Select("Ma_Tn = '" + strColumnName + "'").Length;

				if (iCount == 1)
				{
					DataRow dr = dtDmTn.Select("Ma_Tn = '" + strColumnName + "'")[0];

					if (radioButton1.Checked)
						dgvBangLuong.Columns[strColumnName].Visible = (bool)dr["Is_Display1"];
					else if (radioButton2.Checked)
						dgvBangLuong.Columns[strColumnName].Visible = (bool)dr["Is_Display2"];
					else
						dgvBangLuong.Columns[strColumnName].Visible = (bool)dr["Is_Display3"];

					dgvBangLuong.Columns[i].ReadOnly = !(bool)dr["Is_Input"];
					dgvBangLuong.Columns[i].DefaultCellStyle.ForeColor = (bool)dr["Is_Input"] ? System.Drawing.Color.Blue : SystemColors.WindowText;

					if ((bool)dr["Bold"])
					{
						dgvBangLuong.Columns[i].DefaultCellStyle.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
					}
				}
				else
				{
					dgvBangLuong.Columns[i].ReadOnly = true;
				}
			}
		}

		private void CalSalary()
		{
			Hashtable htPara = new Hashtable();

			htPara.Add("THANG", cboThang.SelectedValue);
			htPara.Add("NAM", Element.sysWorkingYear);
			htPara.Add("MA_BP", cboMa_Bp.Text);
			htPara.Add("MA_DT_CBNV", string.Empty);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			SQLExec.Execute("sp_HRM_CalcBangLuong", htPara, CommandType.StoredProcedure);

			this.FillData();
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsBangLuong.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (enuNew_Edit == enuEdit.New)
				return;

			if (bdsBangLuong.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsBangLuong.Current).Row, ref drCurrent);
			else
				drCurrent = dtBangLuong.NewRow();

			frmBangLuong_Edit frmEdit = new frmBangLuong_Edit();
			frmEdit.Load(drCurrent, Convert.ToInt32(this.cboThang.SelectedValue));

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsBangLuong.Position >= 0)
						dtBangLuong.ImportRow(drCurrent);
					else
						dtBangLuong.Rows.Add(drCurrent);

					bdsBangLuong.Position = bdsBangLuong.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsBangLuong.Current).Row);
				}

				dtBangLuong.AcceptChanges();
			}
		}

		public override void Delete()
		{
			if (bdsBangLuong.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsBangLuong.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			Hashtable htPara = new Hashtable();
			htPara.Add("THANG", cboThang.SelectedValue);
			htPara.Add("NAM", Element.sysWorkingYear);
			htPara.Add("MA_BP", cboMa_Bp.Text);
			htPara.Add("MA_CBNV", drCurrent["Ma_CbNv"]);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			if (SQLExec.Execute("sp_HRM_DeleteBangLuong", htPara, CommandType.StoredProcedure))
			{
				bdsBangLuong.RemoveAt(bdsBangLuong.Position);
				dtBangLuong.AcceptChanges();
			}
		}

		#endregion

		#region Event

		void btCalcSalary_Click(object sender, EventArgs e)
		{
			this.CalSalary();
		}

		void btCreateSalary_Click(object sender, EventArgs e)
		{
			frmBangLuong_Create frmCreate = new frmBangLuong_Create();
			frmCreate.Load(Convert.ToInt32(this.cboThang.SelectedValue), cboMa_Bp.Text.Trim(), string.Empty);

			if (frmCreate.isAccept)
			{
				this.FillData();
			}
		}

		void btDeleteSalary_Click(object sender, EventArgs e)
		{
			string strMess = Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn có chắc chắn xóa bảng lương tháng ?" : "Are you sure delete salary table month ?" + this.cboThang.SelectedValue;

			if (Common.MsgYes_No(strMess, "N"))
			{
				Hashtable htPara = new Hashtable();
				htPara.Add("THANG", cboThang.SelectedValue);
				htPara.Add("NAM", Element.sysWorkingYear);
				htPara.Add("MA_BP", cboMa_Bp.Text);
				htPara.Add("MA_CBNV", string.Empty);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

				if (SQLExec.Execute("sp_HRM_DeleteBangLuong", htPara, CommandType.StoredProcedure))
				{
					this.FillData();
				}
			}
		}

		void btPostedSalary_Click(object sender, EventArgs e)
		{
			frmBangLuong_Posted frmPosted = new frmBangLuong_Posted();
			frmPosted.Load(Convert.ToInt32(this.cboThang.SelectedValue));
		}

		void frmBangLuong_KeyDown(object sender, KeyEventArgs e)
		{
			//if (e.KeyCode == Keys.F12)
			//{
				
			//}
		}

		void cboThang_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.ActiveControl == cboThang)
				this.FillData();
		}

		void cboMa_Bp_TextChanged(object sender, EventArgs e)
		{
			if (cboMa_Bp.lviItem != null)
				lbtTen_Bp.Text = cboMa_Bp.lviItem.SubItems["Ten_Bp"].Text;

			if (cboMa_Bp.Text == string.Empty)
				return;

			this.FillData();
		}

		void dgvBangLuong_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			drCurrent = ((DataRowView)bdsBangLuong.Current).Row;
			DataGridViewCell dgvCell = ((rsDataGridView)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (!dgvCell.IsInEditMode)
				return;

			if ((string)drCurrent["Ma_Dt_CbNv"] == string.Empty)
				return;

			if (dtDmTn.Select("Is_Input = true AND Ma_Tn = '" + strColumnName + "'").Length == 1)
			{
				Hashtable htPara = new Hashtable();
				htPara.Add("NAM", Element.sysWorkingYear);
				htPara.Add("THANG", this.cboThang.SelectedValue);
				htPara.Add("MA_DT_CBNV", (string)drCurrent["Ma_Dt_CbNv"]);
				htPara.Add("MA_DVCS", Element.sysMa_DvCs);
				htPara.Add("MA_TN", strColumnName);
				htPara.Add("TIEN", dgvCell.Value);

				if (SQLExec.Execute("sp_HRM_SaveBangLuong", htPara, CommandType.StoredProcedure))
				{
					drCurrent.AcceptChanges();
				}
			}
		}

		void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			this.ShowBangLuong();
		}

		#endregion
	}
}
