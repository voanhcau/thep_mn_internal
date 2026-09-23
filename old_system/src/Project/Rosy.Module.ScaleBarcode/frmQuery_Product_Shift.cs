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
using RosySystem;

namespace RosyModule.ScaleBarcode
{
	public partial class frmQuery_Product_Shift : RosySystem.Customize.frmView
	{
		DataSet dsProduct_Shift;
		DataTable dtShift;
		DataTable dtBarcode;
		BindingSource bdsShift = new BindingSource();
		BindingSource bdsBarcode = new BindingSource();
		DataRow drCurrent;
		bool bGC = false;
		string strLoai_Can = "CAN";

		public frmQuery_Product_Shift()
		{
			InitializeComponent();

			this.cboCa.TextChanged += new EventHandler(cboCa_TextChanged);

			this.btFilter.Click += new EventHandler(btFilter_Click);
			this.bdsShift.PositionChanged += new EventHandler(bdsShift_PositionChanged);
			this.btPrint.Click += new EventHandler(btPrint_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
            this.btDelete.Click += new EventHandler(btDelete_Click);

			this.dgvBarcode.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvBarcode_CellFormatting);
			this.dgvBarcode.CellValidating += new DataGridViewCellValidatingEventHandler(dgvBarcode_CellValidating);
			this.dgvBarcode.Enter += new EventHandler(dgvBarcode_Enter);
			this.dgvBarcode.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvBarcode_DataBindingComplete);
			this.dgvShift.Enter += new EventHandler(dgvShift_Enter);
			this.rdbGC.CheckedChanged += RdbAll_CheckedChanged;
			this.rdbTMN.CheckedChanged += RdbAll_CheckedChanged;
			this.dgvBarcode.ReadOnly = false;
		}

       

		public void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();
			this.BuildReadOnlyGridView();
			this.Show();
		}

		private void Build()
		{
			dgvShift.strZone = "QUERY_SHIFT";
			dgvShift.BuildGridView();

			dgvBarcode.strZone = "QUERY_BARCODE_SHIFT";
			dgvBarcode.BuildGridView();

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
				htPara.Add("LOAI_CA", strLoai_Can);
				if (cboCa.SelectedItem != null)
					htPara.Add("CA", cboCa.SelectedItem);

				dtShift = SQLExec.ExecuteReturnDt("sp_Query_Product_Shift", htPara, CommandType.StoredProcedure);
				
				bdsShift.DataSource = dtShift;
				dgvShift.DataSource = bdsShift;

				bdsShift.MoveFirst();
				
				ExportControl = dgvShift;
				bdsSearch = bdsShift;

				this.Filter_Detail();
			}
		}

		private void BuildReadOnlyGridView()
		{
			dgvBarcode.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			if (dgvBarcode.Columns.Contains("Ngay_Nhap"))
				dgvBarcode.Columns["Ngay_Nhap"].HeaderText = "Ngày sản xuất";

			if (dgvBarcode.Columns.Contains("So_Luong"))
				dgvBarcode.Columns["So_Luong"].HeaderText = "Khối lượng";

			string strColumn_Name = "";
			if (Common.CheckPermission(this.Object_ID, RosySystem.enuPermission_Type.Allow_Edit))
			{
				strColumn_Name = "BARCODE,SO_LUONG_OLD,CHANGE_SO_LUONG,SO_LUONG_BAREM,NUM_BARS_OLD,CHANGE_NUM_BARS,TEN_CL,GRADE_NAME,STANDARD_NAME,LOT_NAME,CREATE_LOG,LASTMODIFY_LOG,MA_CA,OUTPUT,TEN_SIZE,IS_BAREM,INPUT_TYPE";
			}
			else
				strColumn_Name = "BARCODE,SO_LUONG_OLD,CHANGE_SO_LUONG,SO_LUONG_BAREM,NUM_BARS_OLD,CHANGE_NUM_BARS,TEN_CL,GRADE_NAME,STANDARD_NAME,LOT_NAME,CREATE_LOG,LASTMODIFY_LOG,MA_CA,OUTPUT,TEN_SIZE,IS_BAREM,INPUT_TYPE,NUM_LOT,NO_MELT,SO_LUONG,NUM_BARS,LENGTH";

			foreach (var strColumn in strColumn_Name.Split(','))
			{
				if (dgvBarcode.Columns.Contains(strColumn))
					dgvBarcode.Columns[strColumn].ReadOnly = true;
			}
		}

		void Filter_Detail()
		{
			if (bdsShift.Position < 0)
			{
				if (dtBarcode != null)
					dtBarcode.Clear();

				return;
			}

			drCurrent = ((DataRowView)bdsShift.Current).Row;

			dtBarcode = SQLExec.ExecuteReturnDt("sp_Query_Product_In_Shift", new string[] { "Ma_Ca" }, new object[] { (string)drCurrent["Ma_Ca"] }, CommandType.StoredProcedure);
			bdsBarcode.DataSource = dtBarcode;
			dgvBarcode.DataSource = bdsBarcode;

			//object objSo_Luong = dtBarcode.Compute("SUM(So_Luong)", "");
			//object objSo_Bo = dtBarcode.Compute("COUNT(Barcode)", "");

			//numTSo_Luong.Value = (objSo_Luong == DBNull.Value ? 0 : Convert.ToDouble(objSo_Luong));
			//numTNum_Bars.Value = (objSo_Bo == DBNull.Value ? 0 : Convert.ToDouble(objSo_Bo));

			bdsBarcode.Position = 0;
		}

		private void Print(string strBarcode, bool bIs_Barem, bool bPreview)
		{
			string strPrint_Name = string.Empty;
			DataRow drEquipment = DataTool.SQLGetDataRowByID("R81EquipmentInfo", "Host_IP", MachineInfo.GetHostIP());
			if (drEquipment != null)
			{
				strPrint_Name = (string)drEquipment["Print_Barcode"];
			}
			
			Voucher.PrintBarcode(strBarcode, bIs_Barem, false, strPrint_Name, bGC);
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void bdsShift_PositionChanged(object sender, EventArgs e)
		{
			this.Filter_Detail();
		}

		void dgvShift_Enter(object sender, EventArgs e)
		{
			this.bdsSearch = bdsShift;
			this.ExportControl = sender;
		}

		void dgvBarcode_Enter(object sender, EventArgs e)
		{
			this.bdsSearch = bdsBarcode;
			this.ExportControl = sender;
		}
		private void RdbAll_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbTMN.Checked)
				strLoai_Can = "CAN";
			else if (rdbGC.Checked)
				strLoai_Can = "CANGC";
		}
		void btPrint_Click(object sender, EventArgs e)
		{
			if (bdsBarcode.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsBarcode.Current).Row;
			//Xu ly goi mau in etiket
			if (drCurrent["So_Ct_Lxh"].ToString() != "")
				bGC = true;

			this.Print(drCurrent["Barcode"].ToString(), Convert.ToBoolean(drCurrent["Is_Barem"]), false);
		}
        void btDelete_Click(object sender, EventArgs e)
        {
          

			//Check Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			//xu ly in xoa theo khu vực
			if (!Common.CheckPermission("CT_PNGCTH", enuPermission_Type.Allow_Delete) && rdbGC.Checked == true)
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			else if (!Common.CheckPermission("CT_PNTH", enuPermission_Type.Allow_Delete) && rdbTMN.Checked == true)
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}

			if (bdsBarcode.Position < 0)
				return;

            drCurrent = ((DataRowView)bdsBarcode.Current).Row;

			string strBarcode = (string)drCurrent["Barcode"];


		

			//Check Barcode Output?
			if (DataTool.SQLCheckExist("R05CTX_BARCODE", "Barcode", strBarcode))
			{
				Common.MsgCancel("Mã vạch này được xuất rồi.Không xóa được");
				return;
			}

			//Checck Barcode have Try_ID?
			if (Convert.ToString(SQLExec.ExecuteReturnValue("SELECT TOP 1 Try_ID FROM R81DMBARCODE WITH(NOLOCK) WHERE Barcode = '" + strBarcode + "'")) != string.Empty)
			{
				Common.MsgCancel("Mã vạch này được cập nhật cơ tính rồi.Không xoá được");
				return;
			}

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (SQLExec.Execute("sp_Delete_DmBarcode", drCurrent, CommandType.StoredProcedure))
            {
                bdsBarcode.RemoveAt(bdsBarcode.Position);
                dtBarcode.AcceptChanges();
            }
        }
		void cboCa_TextChanged(object sender, EventArgs e)
		{
			this.FillData();
		}

		void dgvBarcode_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (e.RowIndex < 0 || e.RowIndex < 0)
				return;

			drCurrent = ((DataRowView)bdsBarcode.Current).Row;

			string strColName = dgvBarcode.Columns[e.ColumnIndex].Name;

            if (dgvBarcode.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode) //!dgvBarcode.Columns[strColName].ReadOnly && Common.Inlist(strColName, "SO_LUONG,NUM_BARS"))
            {
                //Check Locked
                if (!Voucher.CheckDataLocked_Barcode((DateTime)drCurrent["Ngay_Nhap"]))
                {
                    Common.MsgCancel("Dữ liệu đã bị khóa.Vui lòng liên hệ với người dùng có quyền mở khóa");
                    e.Cancel = true;
                    return;
                }

                if (drCurrent.Table.Columns.Contains("OutPut"))
                {
                    if (Convert.ToBoolean(drCurrent["OutPut"]))
                    {
                        Common.MsgCancel("Bó thép đã được xuất rồi. Không được phép sửa");
                        e.Cancel = true;
                        return;
                    }
                }
                if (!(bool)Voucher_Scale.CheckInheritBarCode_PNTLB(drCurrent["Barcode"].ToString()))
                {
                    Common.MsgCancel("Bó thép đã kế thừa nhập thành phẩm rồi không xử lý được");
                    e.Cancel = true;
                    return;
                }
                if (Common.InlistLike(strColName, "SO_LUONG_CAN,SO_LUONG,NO_MELT,NUM_BARS,NUM_LOT"))
                {
                    if (Convert.ToDouble(drCurrent["So_Luong_Can"]) == 0 && strColName == "SO_LUONG_CAN")
                    {
                        Common.MsgCancel("Bạn không được sửa dữ liệu số lượng cân. Phải sửa cột khối lượng");
                        e.Cancel = true;
                        return;
                    }
                    else if (Convert.ToDouble(drCurrent["So_Luong_Can"]) != 0 && strColName == "SO_LUONG")
                    {
                        Common.MsgCancel("Bạn không được sửa dữ liệu khối lượng. Phải sửa cột khối lượng cân");
                        e.Cancel = true;
                        return;
                    }
                    else if(strColName == "NUM_BARS" && (!drCurrent["Barcode"].ToString().StartsWith("L") && drCurrent["So_Ct_LXH"].ToString() == string.Empty))
                    {
                        Common.MsgCancel("Bạn không được sửa số cây của bó chẵn!!!");
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        if (Common.MsgYes_No("Bạn có chắc chắn sửa dữ liệu [" + strColName + "] về " + e.FormattedValue.ToString() + "?"))
                        {
                            string strLastModify_Log = Common.GetCurrent_Log();

                            string strSQL = "UPDATE R81DMBARCODE SET " + strColName + " = @Value, LastModify_Log = @LastModify_Log WHERE Barcode = @Barcode";
                            Hashtable htPara = new Hashtable();
                            htPara["BARCODE"] = drCurrent["Barcode"];
                            //Bằng kiểm tra kiểu dữ liệu chuyển format số hay chuổi
                            htPara["VALUE"] = (Object)Voucher.GetTypeOfTable("R81DMBARCODE", strColName, e.FormattedValue.ToString());
                            //if(Common.InlistLike(strColName,"SO,NUM"))//BANG SUA CHO CHUYEN KIEU DU LIEU
                            //    htPara["VALUE"] = Convert.ToDouble(e.FormattedValue);
                            //else
                            //    htPara["VALUE"] = e.FormattedValue.ToString();
                            //if (e.FormattedValue.GetType().Name.ToLower() == "string")
                            //    htPara["VALUE"] = e.FormattedValue.ToString();
                            //else
                            //    htPara["VALUE"] = Convert.ToDouble(e.FormattedValue);

                            htPara["LASTMODIFY_LOG"] = strLastModify_Log;

                            if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
                            {
                                drCurrent[strColName] = e.FormattedValue;
                                drCurrent["LastModify_Log"] = strLastModify_Log;

                                if (strColName == "SO_LUONG")
                                    drCurrent["Change_So_Luong"] = true;

                                if (strColName == "NUM_BARS")
                                    drCurrent["Change_Num_Bars"] = true;
                                
                                //Bằng bổ sumg sửa số cây của barcode lẻ
                                if (strColName == "NUM_BARS")
                                {
                                    double dbSo_Luong = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBaremBo('" + drCurrent["Ma_Vt_Sp"] + "',0,"+ drCurrent["Num_Bars"] +")"));
                                    string strSQL1 = "UPDATE R81DMBARCODE SET  So_Luong = @So_Luong_Barem, So_Luong_Barem = @So_Luong_Barem1  WHERE Barcode = @Barcode";
                                    Hashtable htPara1 = new Hashtable();
                                    htPara1["BARCODE"] = drCurrent["Barcode"];
                                    htPara1["SO_LUONG_BAREM"] = dbSo_Luong;
                                    htPara1["SO_LUONG_BAREM1"] = dbSo_Luong;
                                    SQLExec.Execute(strSQL1, htPara1, CommandType.Text);

                                    drCurrent["So_Luong"] = dbSo_Luong;
                                    drCurrent["So_Luong_Barem"] = dbSo_Luong;
                                }
                                drCurrent.AcceptChanges();
                            }
                        }
                        else
                            e.Cancel = true;
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

		void dgvBarcode_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			DataTable dtView = dtBarcode.DefaultView.ToTable();
			if (dtView.Rows.Count > 0)
			{
				numTNum_Bars.Value = Convert.ToDouble(dtView.Compute("Count(Barcode)", ""));
				numTSo_Luong.Value = Common.SumDCValue(dtView, "So_Luong", "");
			}
			else
			{
				numTNum_Bars.Value = numTSo_Luong.Value = 0;
			}
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
