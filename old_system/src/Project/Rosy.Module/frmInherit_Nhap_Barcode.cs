using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;
using System.Collections;

namespace RosyModule
{
	public partial class frmInherit_Nhap_Barcode : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInheritVoucher;
		BindingSource bdsInheritVoucher = new BindingSource();

		public DataTable dtInheritVoucherDetail;
		BindingSource bdsInheritVoucherDetail = new BindingSource();

		frmVoucher_Edit frmVoucher_Edit;
		DataRow drCurrent, drDmCt_Current;

		public bool Is_Accept = false;

		#endregion

		#region Contructor

        public frmInherit_Nhap_Barcode()
		{
			InitializeComponent();

			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);
		}

		#endregion

		#region Method

		public void Load(frmVoucher_Edit frmVoucher_Edit)
		{
			this.frmVoucher_Edit = frmVoucher_Edit;
			this.txtMa_Ct.Text = (string)frmVoucher_Edit.strMa_Ct;
			this.txtMa_Nvu.Text = (string)frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString();
            
            //dteNgay_Ct1.Text = DateTime.Now.ToString("01/MM/yyyy");
            
			dteNgay_Ct2.Text = Library.DateToStr(DateTime.Now);

			drDmCt_Current = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", frmVoucher_Edit.strMa_Ct.ToString());

			Build();
			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		public void Load()
		{
			this.txtMa_Ct.Text = "TP";
			this.txtMa_Nvu.Text = "NKTP";

            
            //dteNgay_Ct1.Text = DateTime.Now.ToString("01/MM/yyyy");
			dteNgay_Ct2.Text = Library.DateToStr(DateTime.Now);

			drDmCt_Current = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text.ToString());

			Build();
			BindingLanguage();
			LoadDicName();

			this.Show();
		}

		private void LoadDicName()
		{
			//txtMa_Ct
			if (txtMa_Ct.Text.Trim() != string.Empty)
			{
				lbtTen_Ct.Text = DataTool.SQLGetNameByCode("R00DmCt", "Ma_Ct", "Ten_Ct", txtMa_Ct.Text.Trim());
			}
			else
				lbtTen_Ct.Text = string.Empty;

			//txtMa_Nvu
			if (txtMa_Nvu.Text.Trim() != string.Empty)
			{
				lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim());
			}
			else
				lbtTen_Nvu.Text = string.Empty;
		}

		void Build()
		{
            dgvInheritVoucher.strZone = "INHERIT_NHAP_BARCODE";
			
			dgvInheritVoucher.BuildGridView();

			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;

			if (dgvInheritVoucher.Columns.Contains("CHON"))
				dgvInheritVoucher.Columns["CHON"].ReadOnly = false;

			//------------
			dgvInheritVoucherDetail.strZone = "INHERIT_NHAP_BARCODE_DETAIL";

			dgvInheritVoucherDetail.BuildGridView();
		}

		void FillData()
		{
			if (txtMa_Ct.Text == "")
			{
				Common.MsgCancel("Chưa điền Ma_Ct");
				return;
			}

			if (txtMa_Nvu.Text == "")
			{
				Common.MsgCancel("Chưa điền Ma_Nvu");
				return;
			}

            //if (chkIs_Hach_Toan.Checked && !Common.CheckDataLocked(Library.StrToDate(dteNgay_Ct1.Text)))
            //{
            //    Common.MsgCancel("Dữ liệu Từ ngày đã khóa");
            //    return;
            //}

			if (chkIs_Hach_Toan.Checked && !Common.CheckDataLocked(Library.StrToDate(dteNgay_Ct2.Text)))
			{
				Common.MsgCancel("Dữ liệu Đến ngày đã khóa");
				return;
			}

			if (chkIs_Hach_Toan.Checked && !Voucher.CheckDataLocked_Barcode(Library.StrToDate(dteNgay_Ct2.Text)))
			{
				Common.MsgCancel("Dữ liệu Barcode đã bị khóa.Vui lòng liên hệ với người dùng có quyền mở khóa Barcode");
				return;
			}

			Hashtable htPara = new Hashtable();
			
            htPara.Add("NGAY_CT1", dteNgay_Ct2.Text);
			htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
			htPara.Add("MA_CT", txtMa_Ct.Text);
            htPara.Add("MA_NVU", txtMa_Nvu.Text);
			htPara.Add("EXCEPT_INHERITED", chkExcept_Inherited.Checked);
			htPara.Add("IS_CXL", chkIs_CXL.Checked);
            htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
			htPara.Add("IS_HACH_TOAN", chkIs_Hach_Toan.Checked);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsInherit = SQLExec.ExecuteReturnDs("sp_Inherit_Nhap_Barcode", htPara, CommandType.StoredProcedure);

			dtInheritVoucher = dsInherit.Tables[0];
			bdsInheritVoucher.DataSource = dtInheritVoucher;
			dgvInheritVoucher.DataSource = bdsInheritVoucher;

			dtInheritVoucherDetail = dsInherit.Tables[1];
			bdsInheritVoucherDetail.DataSource = dtInheritVoucherDetail;
			dgvInheritVoucherDetail.DataSource = bdsInheritVoucherDetail;

			bdsSearch = bdsInheritVoucher;
			bdsLookup = bdsInheritVoucher;

            if (dtInheritVoucher.Rows.Count != 0)
                Common.MsgOk("Đã thực hiện thành công");
		}

		bool FormCheckValid()
		{
			if (dtInheritVoucher == null || dtInheritVoucher.Select("Chon = true").Length == 0)
			{
				Common.MsgCancel("Không có dữ liệu kế thừa!");
				return false;
			}

			return true;
		}

		#endregion

		#region Event

		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();

            
		}

		void frmInheritVoucher_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{

				for (int i = 0; i < dtInheritVoucher.Rows.Count; i++)
				{
					dtInheritVoucher.Rows[i]["CHON"] = true;
				}
			}
			if (e.Control && e.KeyCode == Keys.U)
			{

				for (int i = 0; i < dtInheritVoucher.Rows.Count; i++)
				{
					dtInheritVoucher.Rows[i]["CHON"] = false;
				}
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5)
				this.FillData();

			else if (e.Control)
			{
				if (e.KeyCode == Keys.A)
					foreach (DataRow dr in dtInheritVoucher.Rows)
						dr["Chon"] = true;
				else if (e.KeyCode == Keys.U)
					foreach (DataRow dr in dtInheritVoucher.Rows)
					{
						dr["Chon"] = false;
						if (dtInheritVoucher.Columns.Contains("Stt_Order"))
							dr["Stt_Order"] = 0;
					}
			}
			else
				base.OnKeyDown(e);
		}

		#endregion

	}
}
