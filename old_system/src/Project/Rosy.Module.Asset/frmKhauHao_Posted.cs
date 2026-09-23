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
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;

namespace RosyModule.Asset
{
	public partial class frmKhauHao_Posted : RosySystem.Customize.frmEdit
	{
		public string strLoai_Nh_Vt = "TS";

		public frmKhauHao_Posted()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.numThang.TextChanged += new EventHandler(numThang_TextChanged);
			this.numThang.Validating += new CancelEventHandler(numThang_Validating);
		}

		public void Load(string strLoai_Nh_Vt)
		{
			this.strLoai_Nh_Vt = strLoai_Nh_Vt;
			this.txtMa_Ct.Text = "TD";
			if(strLoai_Nh_Vt =="TS")
            {
				txtSo_Ct.Text = "1";
				txtDien_Giai.Text = "Khấu hao tài sản tháng " + this.numThang.Text + "/" + Element.sysWorkingYear.ToString(); 
            }
			else
            {
				txtSo_Ct.Text = "2";
				txtDien_Giai.Text = "Phân bổ CP tháng  " + this.numThang.Text + "/" + Element.sysWorkingYear.ToString();
			}
			this.ShowDialog();
		}

		private bool FormCheckValid()
		{
			if (txtMa_Ct.Text == string.Empty)
				return false;

			if (numThang.Value < 1 || numThang.Value > 12)
				return false;

			return true;
		}

		void numThang_TextChanged(object sender, EventArgs e)
		{
			this.txtDien_Giai.Text = "Khấu hao tài sản tháng " + this.numThang.Text + "/" + Element.sysWorkingYear.ToString();
		}

		void numThang_Validating(object sender, CancelEventArgs e)
		{
			if (numThang.Value < 0 || numThang.Value > 12)
				e.Cancel = false;
		}

		void btAccept_Click(object sender, EventArgs e)
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
				htParameter.Add("THANG", numThang.Value);
				htParameter.Add("NAM", Element.sysWorkingYear);
				htParameter.Add("LOAI_NH_VT", this.strLoai_Nh_Vt);
				htParameter.Add("MA_CT", this.txtMa_Ct.Text);
				htParameter.Add("SO_CT", this.txtSo_Ct.Text);
				htParameter.Add("DIEN_GIAI", this.txtDien_Giai.Text);
				htParameter.Add("MA_DVCS", Element.sysMa_DvCs);
				htParameter.Add("CREATE_LOG", Common.GetCurrent_Log());

				SQLExec.Execute("sp_KhauHao_Update_Ct", htParameter, CommandType.StoredProcedure);

				//if (strLoai_Khau_Hao == "TS")
				//    SQLExec.Execute("sp_KhauHao_Update_Ct", htParameter, CommandType.StoredProcedure);
				//else if (strLoai_Khau_Hao == "CCDC")
				//    SQLExec.Execute("sp_PhanBoCCDC_Update_Ct", htParameter, CommandType.StoredProcedure);


				Common.MsgOk(Languages.GetLanguage("END_PROCESS"));
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
