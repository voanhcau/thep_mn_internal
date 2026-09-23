using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Library;
using RosySystem.Element;
using RosySystem.Common;
using System.Collections;
using RosySystem.Data;
using RosySystem.Public;

namespace RosyModule.ScaleBarcode
{
	public partial class frmQuery_Ph_Scale : RosySystem.Customize.frmView
	{
		DataTable dtViewPh;
		BindingSource bdsViewPh = new BindingSource();
		DataRow drCurrent;

		public frmQuery_Ph_Scale()
		{
			InitializeComponent();

			this.btFilter.Click += new EventHandler(btFilter_Click);
			this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			this.txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
			this.dgvViewPh.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvViewPh_DataBindingComplete);
			this.dgvViewPh.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvViewPh_CellMouseDoubleClick);
		}

		void dgvViewPh_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			if (bdsViewPh.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			if ((bool)drCurrent["Deleted"])
			{
				if (!Common.CheckPermission("ACCESS_RESTORE_SCALE", RosySystem.enuPermission_Type.Allow_Access))
					return;

				frmRestore_Scale frm = new frmRestore_Scale();
				frm.Load(drCurrent);
				if (frm.isAccept)
				{
					if (frm.rdbIs_Restore.Checked)
					{
						if (SQLExec.Execute("UPDATE R80PH_SCALE SET Deleted = 0 WHERE Stt = '" + drCurrent["Stt"].ToString() + "'"))
						{
							bdsViewPh.RemoveAt(bdsViewPh.Position);
							dtViewPh.AcceptChanges();
						}
					}
					else
					{
						if (SQLExec.Execute("DELETE R80PH_SCALE WHERE Stt = '" + drCurrent["Stt"].ToString() + "'"))
						{
							bdsViewPh.RemoveAt(bdsViewPh.Position);
							dtViewPh.AcceptChanges();
						}
					}
				}
			}
		}

		new public void Load()
		{
			this.Build();
			this.BindingLanguage();
			this.Change_Language();
			
			this.cboDeleted.SelectedIndex = 0;

			this.Show();
		}

		private void Change_Language()
		{
			this.txtMa_Dt.bUseAutoDropDown = true;
			this.txtMa_Vt_Sp.bUseAutoDropDown = true;

			if (dgvViewPh.Columns.Contains("So_Luong"))
				dgvViewPh.Columns["So_Luong"].HeaderText = "Khối lượng";

			if (dgvViewPh.Columns.Contains("So_Ct"))
				dgvViewPh.Columns["So_Ct"].HeaderText = "Số phiếu";
		}

		private void Build()
		{
			dgvViewPh.strZone = "QUERY_PH_SCALE1";
			dgvViewPh.BuildGridView();
		}

		private void FillData()
		{
			if(Library.StrToDate(dtpNgay_Ct1.Date) > Library.StrToDate(dtpNgay_Ct2.Date))
			{
				Common.MsgCancel("Ngày bắt đầu phải nhỏ hơn ngày kết thúc, vui lòng nhập lại ngày");
			}
			else
			{
				Hashtable htPara = new Hashtable();
				htPara.Add("NGAY_CT1", dtpNgay_Ct1.Text);
				htPara.Add("NGAY_CT2", dtpNgay_Ct2.Text);
				htPara.Add("SO_XE", txtSo_Xe.Text);
				htPara.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau.Text);
				htPara.Add("SO_CT", txtSo_Ct.Text);
				htPara.Add("MA_DT", txtMa_Dt.Text.Trim());
				htPara.Add("MA_VT_SP", txtMa_Vt_Sp.Text.Trim());
				htPara.Add("IS_PH", true);
				htPara.Add("DELETED", cboDeleted.SelectedIndex);
				htPara.Add("LANGUAGE_TYPE", Element.sysLanguage);
				htPara.Add("MA_DVCS", Element.sysMa_DvCs);

				dtViewPh = SQLExec.ExecuteReturnDt("sp_GetVoucher_Scale", htPara, CommandType.StoredProcedure);

				if (!dtViewPh.Columns.Contains("MARK"))
				{
					DataColumn dcMark = new DataColumn("MARK", typeof(bool));
					dcMark.DefaultValue = false;
					dtViewPh.Columns.Add(dcMark);
				}

				bdsViewPh.DataSource = dtViewPh;
				dgvViewPh.DataSource = bdsViewPh;

				bdsViewPh.Position = 0;
				this.bdsSearch = bdsViewPh;
				this.ExportControl = dgvViewPh;
			}
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btPrint_Click(object sender, EventArgs e)
		{

		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("MA_DT", strValue, bRequire, "");

			if (drLookup == null && bRequire)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = (string)drLookup["Ma_Dt"];
				lbtTen_Dt.Text = (string)drLookup["Ten_Dt"];
			}
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("MA_VT", strValue, bRequire, "");

			if (drLookup == null && bRequire)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = string.Empty;
				lbtTen_Vt_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = (string)drLookup["Ma_Vt"];
				lbtTen_Vt_Sp.Text = (string)drLookup["Ten_Vt"];
			}
		}

		void dgvViewPh_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			DataTable dtView = dtViewPh.DefaultView.ToTable();
			if (dtView.Rows.Count > 0)
			{
				numTSo_Xe.Value = Convert.ToDouble(dtView.Compute("Count(Stt)", ""));
				numTKL_CXL.Value = Common.SumDCValue(dtView, "So_Luong_Vao", "");
				numTKL_Thu_Pham.Value = Common.SumDCValue(dtView, "So_Luong_Ra", "");
				rsTextBoxNumber1.Value = Common.SumDCValue(dtView, "So_Luong", "");
			}
			else
			{
				numTSo_Xe.Value = numTKL_CXL.Value = numTKL_Thu_Pham.Value = rsTextBoxNumber1.Value = 0;
			}
		}

	}
}
