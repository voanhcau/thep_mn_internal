using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Common;

namespace RosyModule.Asset
{
	public partial class frmKhauHao : RosySystem.Customize.frmView
	{
		DataTable dtKhauHao;
		BindingSource bdsKhauHao = new BindingSource();
		public string strLoai_Nh_Vt = "TS";

		public frmKhauHao()
		{
			InitializeComponent();

			this.numThang.Validated += new EventHandler(numThang_Validated);

			this.btThuc_Hien.Click += new EventHandler(btThuc_Hien_Click);
			this.btQuay_Ra.Click += new EventHandler(btQuay_Ra_Click);
			this.btPosted.Click += new EventHandler(btPosted_Click);
		}

		new public void Load(string strLoai_Nh_Vt)
		{
			this.numThang.Value = Element.sysNgay_Ct2.Month;
			this.strLoai_Nh_Vt = strLoai_Nh_Vt;

			this.Build();
			this.FillData();

			this.Show();
		}

		private void Build()
		{
			dgvKhauHao.strZone = "KHAUHAO";
			dgvKhauHao.BuildGridView();
		}

		private void FillData()
		{

			string strSQLExec = @"
				 SELECT T1.*, T2.Ten_Vt AS Ten_Vt_Ts 
					 FROM R06CtTsHM T1 LEFT JOIN R81DmVt T2 ON T1.Ma_Vt_Ts = T2.Ma_Vt
					 WHERE T1.Ma_Vt_Ts IN (SELECT Ma_Vt FROM R81DmVt WHERE Ma_Nh_Vt IN (SELECT Ma_Nh_Vt FROM R81DmNhVt WHERE Loai_Nh_Vt = '" + strLoai_Nh_Vt + @"'))
							AND YEAR(Ngay_Ct) = " + Element.sysWorkingYear.ToString() + @"
							 AND MONTH(Ngay_Ct) = " + this.numThang.Value.ToString() + @"
							 AND T1.Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			dtKhauHao = SQLExec.ExecuteReturnDt(strSQLExec);
			bdsKhauHao.DataSource = dtKhauHao;

			dgvKhauHao.DataSource = bdsKhauHao;

			this.bdsSearch = bdsKhauHao;
			this.ExportControl = dgvKhauHao;
		}

		private void Calc_KhauHao()
		{
			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			DateTime dteNgay_Kh1 = Common.GetDate(Element.sysWorkingYear, Convert.ToInt16(numThang.Value), 1);

			if (!Common.CheckDataLocked(dteNgay_Kh1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			if (this.FormCheckValid())
			{
				Hashtable htParameter = new Hashtable();

				htParameter.Add("THANG", this.numThang.Value);
				htParameter.Add("NAM", Element.sysWorkingYear);
				htParameter.Add("LOAI_NH_VT", this.strLoai_Nh_Vt);
				htParameter.Add("MA_VT_TS", this.txtMa_Vt_Ts.Text.Trim());
				htParameter.Add("MA_NH_VT_TS", this.txtMa_Nh_Vt_Ts.Text.Trim());
				htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

				dtKhauHao = SQLExec.ExecuteReturnDt("sp_KhauHao", htParameter, CommandType.StoredProcedure);

				bdsKhauHao.DataSource = dtKhauHao;
			}
		}

		private bool FormCheckValid()
		{

			return true;
		}

		void numThang_Validated(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btPosted_Click(object sender, EventArgs e)
		{
			frmKhauHao_Posted frm = new frmKhauHao_Posted();
			frm.numThang.Value = this.numThang.Value;
			frm.Load(this.strLoai_Nh_Vt);
		}

		void btThuc_Hien_Click(object sender, EventArgs e)
		{
			this.Calc_KhauHao();
		}

		void btQuay_Ra_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
