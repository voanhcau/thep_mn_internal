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

namespace RosyModule.Inventory
{
	public partial class frmQuery_Product_Shift : RosySystem.Customize.frmView
	{
		DataSet dsProduct_Shift;
		DataTable dtShift;
		DataTable dtBarcode;
		BindingSource bdsShift = new BindingSource();
		BindingSource bdsBarcode = new BindingSource();
		DataRow drCurrent;

		public frmQuery_Product_Shift()
		{
			InitializeComponent();

			this.btFilter.Click += new EventHandler(btFilter_Click);
			this.bdsShift.PositionChanged += new EventHandler(bdsShift_PositionChanged);
			this.btPrint.Click += new EventHandler(btPrint_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
			this.dgvBarcode.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvBarcode_CellFormatting);
			this.dgvBarcode.CellValidating += new DataGridViewCellValidatingEventHandler(dgvBarcode_CellValidating);

			this.dgvBarcode.ReadOnly = false;
		}

		void dgvBarcode_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (e.RowIndex < 0 || e.RowIndex < 0)
				return;

			drCurrent = ((DataRowView)bdsBarcode.Current).Row;

			string strColName = dgvBarcode.Columns[e.ColumnIndex].Name;

			if (dgvBarcode.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode) //!dgvBarcode.Columns[strColName].ReadOnly && Common.Inlist(strColName, "SO_LUONG,NUM_BARS"))
			{
				if (Common.MsgYes_No("Bạn có chắc chắn sửa dữ liệu [" + strColName + "] về " + e.FormattedValue.ToString() + "?"))
				{
					string strSQL = "UPDATE R81DMBARCODE SET " + strColName + " = @Value WHERE Barcode = @Barcode";
					Hashtable htPara = new Hashtable();
					htPara["BARCODE"] = drCurrent["Barcode"];
					htPara["VALUE"] = e.FormattedValue;

					if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
					{
						drCurrent[strColName] = e.FormattedValue;

						if (strColName == "SO_LUONG")
							drCurrent["Change_So_Luong"] = true;

						if (strColName == "NUM_BARS")
							drCurrent["Change_Num_Bars"] = true;

						drCurrent.AcceptChanges();
					}
				}
				else
					e.Cancel = true;
			}
		}

		void dgvBarcode_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			if (bdsBarcode.Position < 0)
				return;

			if (dgvBarcode.Columns.Contains("CHANGE_SO_LUONG") && dgvBarcode.Columns.Contains("CHANGE_NUM_BARS")
				&& dgvBarcode.Columns.Contains("NUM_BARS") && dgvBarcode.Columns.Contains("NUM_BARS_OLD")
				&& dgvBarcode.Columns.Contains("SO_LUONG") && dgvBarcode.Columns.Contains("SO_LUONG_OLD"))
			{
				if (dgvBarcode.Rows[e.RowIndex].Cells["CHANGE_SO_LUONG"].Value != null || dgvBarcode.Rows[e.RowIndex].Cells["CHANGE_NUM_BARS"].Value != null)
				{
					if (Convert.ToDouble(dgvBarcode.Rows[e.RowIndex].Cells["CHANGE_SO_LUONG"].Value) != 0 || Convert.ToDouble(dgvBarcode.Rows[e.RowIndex].Cells["CHANGE_NUM_BARS"].Value) != 0)
					{
						e.CellStyle.BackColor = Color.Lime;

						if (Convert.ToDouble(dgvBarcode.Rows[e.RowIndex].Cells["CHANGE_SO_LUONG"].Value) != 0)
						{
							dgvBarcode.Rows[e.RowIndex].Cells["CHANGE_SO_LUONG"].Style.ForeColor =
							dgvBarcode.Rows[e.RowIndex].Cells["SO_LUONG"].Style.ForeColor =
							dgvBarcode.Rows[e.RowIndex].Cells["SO_LUONG_OLD"].Style.ForeColor = Color.Red;
						}

						if (Convert.ToDouble(dgvBarcode.Rows[e.RowIndex].Cells["CHANGE_NUM_BARS"].Value) != 0)
						{
							dgvBarcode.Rows[e.RowIndex].Cells["CHANGE_NUM_BARS"].Style.ForeColor =
							dgvBarcode.Rows[e.RowIndex].Cells["NUM_BARS"].Style.ForeColor =
							dgvBarcode.Rows[e.RowIndex].Cells["NUM_BARS_OLD"].Style.ForeColor = Color.Red;
						}

						e.CellStyle.Font = new Font(dgvBarcode.Font, FontStyle.Bold);
					}
					else
						e.CellStyle.BackColor = dgvBarcode.DefaultCellStyle.BackColor;
				}
			}
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		void btPrint_Click(object sender, EventArgs e)
		{
			
		}

		public void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();
			this.Show();
		}

		private void Build()
		{
			dgvShift.strZone = "QUERY_SHIFT";
			dgvShift.BuildGridView();

			dgvBarcode.strZone = "QUERY_BARCODE";
			dgvBarcode.BuildGridView();

			this.BuildReadOnlyGridView();

			this.cboCa.Items.Clear();
			object[] objCa = new object[] { "", "A", "B", "C" };
			this.cboCa.Items.AddRange(objCa);
			this.cboCa.SelectedItem = string.Empty;

			this.dteNgay_Ct1.Text = Library.DateToStr(Voucher.GetDate_Server());
			this.dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server().AddDays(1));
		}

		private void FillData()
		{
			if(Library.StrToDate(dteNgay_Ct1.Text) > Library.StrToDate(dteNgay_Ct2.Text))
			{
				Common.MsgCancel("Ngày bắt đầu phải nhỏ hơn ngày kết thúc, vui lòng nhập lại ngày");
			}
			else
			{
				Hashtable htPara = new Hashtable();
				htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
				htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);

				if(cboCa.SelectedItem.ToString() != string.Empty)
					htPara.Add("CA", cboCa.SelectedItem);

				dtShift = SQLExec.ExecuteReturnDt("sp_Query_Product_Shift", htPara, CommandType.StoredProcedure);
				
				bdsShift.DataSource = dtShift;
				dgvShift.DataSource = bdsShift;

				bdsShift.Position = 0;
				
				ExportControl = dgvShift;
				bdsSearch = bdsShift;
			}
		}

		private void BuildReadOnlyGridView()
		{
			dgvBarcode.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			if (dgvBarcode.Columns.Contains("Kich_Thuoc"))
				dgvBarcode.Columns["Kich_Thuoc"].Frozen = true;

			string strColumn_Name = "BARCODE,SO_LUONG_OLD,CHANGE_SO_LUONG,SO_LUONG_BAREM,NUM_BARS_OLD,CHANGE_NUM_BARS,TEN_CL,GRADE_NAME,STANDARD_NAME,LOT_NAME,CREATE_LOG,MA_CA,OUTPUT,KICH_THUOC"; //,LENGTH,
			foreach (var strColumn in strColumn_Name.Split(','))
			{
				if(dgvBarcode.Columns.Contains(strColumn))
					dgvBarcode.Columns[strColumn].ReadOnly = true;
			}
				
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void bdsShift_PositionChanged(object sender, EventArgs e)
		{
			if (bdsShift.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsShift.Current).Row;

			dtBarcode = SQLExec.ExecuteReturnDt("sp_Query_Product_In_Shift", new string[] { "Ma_Ca" }, new object[] { (string)drCurrent["Ma_Ca"] }, CommandType.StoredProcedure);
			bdsBarcode.DataSource = dtBarcode;
			dgvBarcode.DataSource = bdsBarcode;

			object objSo_Luong = dtBarcode.Compute("SUM(So_Luong)", "");
			object objSo_Bo = dtBarcode.Compute("COUNT(Barcode)", "");

			numTSo_Luong.Value = (objSo_Luong == DBNull.Value ? 0 : Convert.ToDouble(objSo_Luong));
			numTNum_Bars.Value = (objSo_Bo == DBNull.Value ? 0 : Convert.ToDouble(objSo_Bo));

			bdsBarcode.Position = 0;
		}

	}
}
