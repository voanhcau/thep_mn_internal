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
using RosySystem;

namespace RosyModule.ScaleBarcode
{
	public partial class frmQuery_Scale_Customer : RosySystem.Customize.frmView
	{
		DataSet dsVoucher = new DataSet("dsVoucher");
		DataTable dtViewPh;
		DataTable dtViewCt;
		BindingSource bdsViewPh = new BindingSource();
		BindingSource bdsViewCt = new BindingSource();
		DataRow drCurrent;
		bool bPrint_Boat = false;
        string strMa_Ct = string.Empty;
        string strTable_Name = string.Empty;
		public frmQuery_Scale_Customer()
		{
			InitializeComponent();

			this.btFilter.Click += new EventHandler(btFilter_Click);
			this.bdsViewPh.CurrentChanged += new EventHandler(bdsViewPh_CurrentChanged);
			this.btPrint.Click += new EventHandler(btPrint_Click);
            this.btXacNhan.Click += BtXacNhan_Click;
			this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			this.txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
            this.txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);

			dgvViewPh.Enter += new EventHandler(dgvViewPh_Enter);
			dgvViewCt.Enter += new EventHandler(dgvViewCt_Enter);
			dgvViewPh.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvViewPh_CellMouseClick);
			dgvViewPh.KeyDown += new KeyEventHandler(dgvViewPh_KeyDown);
		}

       

        new public void Load(bool bPrint_Boat)
		{
			this.bPrint_Boat = bPrint_Boat;
			this.Build();

            if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New))
                btPrint.Visible = true;
            else
                btPrint.Visible = false;

			this.BindingLanguage();
			this.Change_Language();
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

			if (dgvViewCt.Columns.Contains("Ngay_Nhap"))
				dgvViewCt.Columns["Ngay_Nhap"].HeaderText = "Ngày sản xuất";

			if (dgvViewCt.Columns.Contains("So_Luong"))
				dgvViewCt.Columns["So_Luong"].HeaderText = "Khối lượng";
		}

		private void Build()
		{
			dgvViewPh.strZone = "QUERY_PH_SCALE";
			dgvViewPh.BuildGridView();

			dgvViewCt.strZone = "QUERY_CTX_BARCODE";
			dgvViewCt.BuildGridView();

			this.dteNgay_Ct1.Text = Library.DateToStr(Voucher.GetDate_Server());
			this.dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server().AddDays(1));

			this.cboLoai_Ct.Items.Clear();
			this.cboLoai_Ct.Items.AddRange(new[] { "", "1-CÂN NHẬP", "2-CÂN XUẤT" });

			this.cboCNXX.Items.Clear();
			this.cboCNXX.Items.AddRange(new[] {" ", "1-BẰNG TAY", "2-TỰ ĐỘNG" });
			lblNote1.Text = "Trạng thái CNXX: "  + SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM R00PARAMETER WHERE Parameter_ID = 'CNXXAUTO'").ToString();

			if (!bPrint_Boat && dgvViewPh.Columns.Contains("Chon"))
				dgvViewPh.Columns["Chon"].Visible = false;
		}

		private void FillData()
		{
            if (txtMa_Kho.Text.ToUpper() == "04TP")
            {
                strMa_Ct = "PXTH"; strTable_Name = "R80PH_SCALE";
            }
            else if (Common.InlistLike(txtMa_Kho.Text.ToUpper(), "05,GK"))
            { strMa_Ct = "PXBKV"; strTable_Name = "R80PH_BARCODE_KKV"; }

			if (Library.StrToDate(dteNgay_Ct1.Text) > Library.StrToDate(dteNgay_Ct2.Text))
			{
				Common.MsgCancel("Ngày bắt đầu phải nhỏ hơn ngày kết thúc, vui lòng nhập lại ngày");
			}
			else
			{
				Hashtable htPara = new Hashtable();
                htPara.Add("MA_CT", strMa_Ct);
				htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
				htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
				htPara.Add("SO_XE", txtSo_Xe.Text);
				htPara.Add("SO_CT", txtSo_Ct.Text);
				htPara.Add("MA_DT", txtMa_Dt.Text.Trim());
				htPara.Add("MA_VT_SP", txtMa_Vt_Sp.Text.Trim());
                htPara.Add("MA_KHO", txtMa_Kho.Text);
				htPara.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau.Text);
				htPara.Add("LOAI_CT", cboLoai_Ct.SelectedItem == null ? "" : cboLoai_Ct.SelectedItem.ToString() == string.Empty ? "" : cboLoai_Ct.SelectedItem.ToString().Substring(0, 1));

				dsVoucher.Clear();
				dsVoucher = SQLExec.ExecuteReturnDs("sp_Query_Scale_Customer", htPara, CommandType.StoredProcedure);

				dtViewPh = dsVoucher.Tables[0];
				dtViewPh.TableName = "R80PH_SCALE";

				dtViewCt = dsVoucher.Tables[1];
				dtViewCt.TableName = "R05CTX_BARCODE";
				if (dsVoucher.Tables[2].Rows.Count > 0)
					lblNote.Text = dsVoucher.Tables[2].Rows[0]["Note"].ToString();
				else
					lblNote.Text = "";

				if (!dtViewPh.Columns.Contains("MARK"))
				{
					DataColumn dcMark = new DataColumn("MARK", typeof(bool));
					dcMark.DefaultValue = false;
					dtViewPh.Columns.Add(dcMark);
				}

				if (!dtViewPh.Columns.Contains("Chon"))
				{
					DataColumn dcChon = new DataColumn("Chon", typeof(bool));
					dcChon.DefaultValue = false;
					dtViewPh.Columns.Add(dcChon);
				}

				bdsViewPh.DataSource = dtViewPh;
				dgvViewPh.DataSource = bdsViewPh;

				bdsViewCt.DataSource = dtViewCt;
				dgvViewCt.DataSource = bdsViewCt;

				bdsViewPh.MoveLast();

				this.bdsSearch = bdsViewPh;
				this.ExportControl = dgvViewPh;
			}
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void bdsViewPh_CurrentChanged(object sender, EventArgs e)
		{
			string strStt = "";
			if (bdsViewPh.Position >= 0)
			{
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;
				strStt = (string)drCurrent["Stt"];	
			}
			bdsViewCt.Filter = "(Stt = '" + strStt + "')";
		}
		private void BtXacNhan_Click(object sender, EventArgs e)
		{
			if (cboCNXX.SelectedItem != String.Empty)
            {
				SQLExec.Execute("UPDATE R00PARAMETER SET Parameter_Value = N'" + cboCNXX.SelectedItem + "' WHERE Parameter_ID = 'CNXXAUTO'");
				lblNote1.Text = "Trạng thái CNXX: " + SQLExec.ExecuteReturnValue("SELECT Parameter_Value FROM R00PARAMETER WHERE Parameter_ID = 'CNXXAUTO'").ToString();
			}
				
		}
		void btPrint_Click(object sender, EventArgs e)
		{
			if (bPrint_Boat)
			{
                //if (dtViewPh.Select("Chon = true").Length > 1 &&  !Common.InlistLike(txtMa_Kho.Text, "04TP,GK_04TP,055POM1"))
                //{
                //    Common.MsgOk("Kho khu vực kết xuất từng lệnh không kết xuất nhiều lệnh cùng lúc!!!");
                //    return;
                //}
                if (dtViewPh.Select("Chon = true").Length > 0)
				{
					string strStt_List = string.Empty; 
					if(txtSo_Xa_Lan_Tau.Text != "")
                    {
						foreach (DataRow drPrint in dtViewPh.Select("Chon = true"))
						{
							strStt_List = strStt_List == string.Empty ? (string)drPrint["Stt"] : strStt_List + "," + (string)drPrint["Stt"];
						}

						Voucher.PrintScale_Out_Boat(strStt_List, true, true, strTable_Name, txtMa_Kho.Text);
					}
					else
                    {
						foreach (DataRow drPrint in dtViewPh.Select("Chon = true"))
                        {
							Voucher.PrintScale_Out_Boat(drPrint["Stt"].ToString(), true, true, strTable_Name, txtMa_Kho.Text);
						}

					}
				}
				else
				{
					if (bdsViewPh.Position < 0)
						return;

					drCurrent = ((DataRowView)bdsViewPh.Current).Row;

                    Voucher.PrintScale_Out((string)drCurrent["Stt"], true, true, strTable_Name);
				}
			}
			else
			{
				if (bdsViewPh.Position < 0)
					return;

				drCurrent = ((DataRowView)bdsViewPh.Current).Row;

                Voucher.PrintScale_Out((string)drCurrent["Stt"], true, true, strTable_Name);
			}
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
        void txtMa_Kho_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Kho.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("MA_KHO", strValue, bRequire, "");

            if (drLookup == null && bRequire)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Kho.Text = string.Empty;
               
            }
            else
            {
                txtMa_Kho.Text = (string)drLookup["Ma_Kho"];
               
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

		void dgvViewCt_Enter(object sender, EventArgs e)
		{
			this.bdsSearch = bdsViewPh;
			this.ExportControl = sender;
		}

		void dgvViewPh_Enter(object sender, EventArgs e)
		{
			this.bdsSearch = bdsViewCt;
			this.ExportControl = sender;
		}

		void dgvViewPh_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.bPrint_Boat)
			{
				switch (e.KeyCode)
				{
					case Keys.Space:
						if (bdsViewPh.Position < 0)
							return;
						((DataRowView)bdsViewPh.Current).Row["Chon"] = !(bool)((DataRowView)bdsViewPh.Current).Row["Chon"];
						break;

					case Keys.A:
						if (e.Modifiers == Keys.Control)
							for (int i = 0; i < dgvViewPh.RowCount; i++)
								dgvViewPh.Rows[i].Cells["Chon"].Value = true;

						this.dtViewPh.AcceptChanges();
						break;

					case Keys.U:
						if (e.Modifiers == Keys.Control)
							for (int i = 0; i < dgvViewPh.RowCount; i++)
								dgvViewPh.Rows[i].Cells["Chon"].Value = false;

						this.dtViewPh.AcceptChanges();
						break;
				}
			}
		}

		void dgvViewPh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			if (bdsViewPh.Position < 0)
				return;

			string strColumnName = dgvViewPh.Columns[e.ColumnIndex].Name.ToUpper();

			if (strColumnName == "CHON")
				((DataRowView)bdsViewPh.Current).Row["Chon"] = !(bool)((DataRowView)bdsViewPh.Current).Row["Chon"];
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			this.dteNgay_Ct1.Focus();
		}
	}
}
