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
using RosySystem.Customize;
using RosySystem.Public;

namespace RosyModule.ScaleBarcode
{
	public partial class frmQuery_Product_ShiftPH : RosySystem.Customize.frmView
	{
		DataSet dsProduct_Shift;
		DataTable dtShift;
		DataTable dtBarcode;
        DataTable dtBarcodeTB;
        DataSet dsBarcode;
		BindingSource bdsShift = new BindingSource();
		BindingSource bdsBarcode = new BindingSource();
        BindingSource bdsBarcodeTB = new BindingSource();
		DataRow drCurrent;

        public frmQuery_Product_ShiftPH()
		{
			InitializeComponent();

			this.cboCa.TextChanged += new EventHandler(cboCa_TextChanged);

			this.btFilter.Click += new EventHandler(btFilter_Click);
			this.bdsShift.PositionChanged += new EventHandler(bdsShift_PositionChanged);
            //this.btPrint.Click += new EventHandler(btPrint_Click);
			this.btExit.Click += new EventHandler(btExit_Click);

            this.dgvBarcode.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvBarcode_CellFormatting);
            this.dgvBarcode.CellValidating += new DataGridViewCellValidatingEventHandler(dgvBarcode_CellValidating);
            this.dgvBarcode.Enter += new EventHandler(dgvBarcode_Enter);
            //this.dgvBarcode.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvBarcode_DataBindingComplete);
            this.dgvShift.Enter += new EventHandler(dgvShift_Enter);
            btDelete.Click += new EventHandler(btDelete_Click);
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

            dgvBarcode.strZone = "CTNX_BARCODEPHOI";
			dgvBarcode.BuildGridView();
          



            dgvBarcodeTB.strZone = "CTNX_BARCODEPHOITB";
            dgvBarcodeTB.BuildGridView();
           

			this.cboCa.Items.Clear();
			object[] objCa = new object[] { "", "A", "B", "C" };
			this.cboCa.Items.AddRange(objCa);
			this.cboCa.SelectedItem = string.Empty;

			this.dteNgay_Ct1.Text = Library.DateToStr(Voucher.GetDate_Server());
			this.dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server().AddDays(1));

            dgvBarcode.Visible = true;
            dgvBarcodeTB.Visible = false;

       
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

				if (cboCa.SelectedItem != null)
					htPara.Add("CA", cboCa.SelectedItem);

				dtShift = SQLExec.ExecuteReturnDt("sp_Query_Product_ShiftPH", htPara, CommandType.StoredProcedure);
				
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

            dgvBarcode.Columns["BQ_PHOI"].HeaderText = "Loại phôi cắt";
            dgvBarcode.Columns["INPUT_TYPE"].HeaderText = "Nhập tự động";
            dgvShift.Columns["TSO_CAY"].HeaderText = "Tổng số cây";
            dgvShift.Columns["TSO_LUONG_KG"].HeaderText = "Tổng khối lượng";
            dgvShift.Columns["TSO_LUONG_TB"].HeaderText = "Khối lượng trung bình theo ca";
            dgvShift.Columns["TSO_BO"].Visible = false;

            dgvBarcodeTB.Columns["SO_LUONG_TB"].HeaderText = "Khối lượng trung bình theo mẻ";
            dgvBarcodeTB.ReadOnly = true;
            
            dgvBarcode.ReadOnly = false;
            string strColumn_Name = "";
			if (Common.CheckPermission(this.Object_ID, RosySystem.enuPermission_Type.Allow_Edit))
			{
                strColumn_Name = "BARCODE,SO_LUONG_OLD,CHANGE_SO_LUONG,CREATE_LOG,LASTMODIFY_LOG,INPUT_TYPE,SO_LUONG"; //ko cho sua so luong theo yeu cau a THỊNH ngày 11/8/2022
			}
			else
				strColumn_Name = "BARCODE,SO_LUONG_OLD,CHANGE_SO_LUONG,CREATE_LOG,LASTMODIFY_LOG,MA_CA,IS_NONG,INPUT_TYPE,SO_ME,SO_LUONG";

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
            if(chkIsAll.Checked == false)
                dsBarcode = SQLExec.ExecuteReturnDs("sp_Query_Product_In_ShiftPH", new string[] { "Ma_Ca", "Ngay_Ct1", "Ngay_Ct2" }, new object[] { (string)drCurrent["Ma_Ca"], dteNgay_Ct1.Text, dteNgay_Ct2.Text }, CommandType.StoredProcedure);
            else
                dsBarcode = SQLExec.ExecuteReturnDs("sp_Query_Product_In_ShiftPH", new string[] { "Ma_Ca", "Ngay_Ct1", "Ngay_Ct2" }, new object[] { "", dteNgay_Ct1.Text, dteNgay_Ct2.Text }, CommandType.StoredProcedure);

            dtBarcode = dsBarcode.Tables[0];
			bdsBarcode.DataSource = dtBarcode;
			dgvBarcode.DataSource = bdsBarcode;

            object objSo_Luong = dtBarcode.Compute("SUM(So_Luong)", "");
            object objSo_Bo = dtBarcode.Compute("COUNT(Barcode)", "");

            numTSo_Luong.Value = (objSo_Luong == DBNull.Value ? 0 : Convert.ToDouble(objSo_Luong));
            numTNum_Bars.Value = (objSo_Bo == DBNull.Value ? 0 : Convert.ToDouble(objSo_Bo));


			bdsBarcode.Position = 0;

            dtBarcodeTB = dsBarcode.Tables[1];
            bdsBarcodeTB.DataSource = dtBarcodeTB;
            dgvBarcodeTB.DataSource = bdsBarcodeTB;
		}

        //private void Print(string strBarcode, bool bIs_Barem, bool bPreview)
        //{
        //    string strPrint_Name = string.Empty;
        //    DataRow drEquipment = DataTool.SQLGetDataRowByID("R81EquipmentInfo", "Host_IP", MachineInfo.GetHostIP());
        //    if (drEquipment != null)
        //    {
        //        strPrint_Name = (string)drEquipment["Print_Barcode"];
        //    }

        //    Voucher.PrintBarcode(strBarcode, bIs_Barem, false, strPrint_Name);
        //}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void bdsShift_PositionChanged(object sender, EventArgs e)
		{
            if(chkIsAll.Checked == false)
			    this.Filter_Detail();
		}

		void dgvShift_Enter(object sender, EventArgs e)
		{
			this.bdsSearch = bdsShift;
			this.ExportControl = sender;
		}
        void btDelete_Click(object sender, EventArgs e)
        {
            //Check Permission
            if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
                return;
            }
            //Kiểm tra mẻ này có được nghiệm thu chua
           
            if (bdsBarcode.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsBarcode.Current).Row;

            string strBarcode = (string)drCurrent["Barcode"];
            if (!(bool)Voucher_Scale.CheckInheritBarCode_PNSB(strBarcode))
            {
                Common.MsgCancel("Mẻ luyện đã kế thừa nhập thành phẩm rồi không xử lý được");
                return;
            }

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (SQLExec.Execute("sp_Delete_DmBarcodePH", drCurrent, CommandType.StoredProcedure))
            {
                bdsBarcode.RemoveAt(bdsBarcode.Position);
                dtBarcode.AcceptChanges();

                
            }
        }
		void dgvBarcode_Enter(object sender, EventArgs e)
		{
			this.bdsSearch = bdsBarcode;
			this.ExportControl = sender;
		}

        //void btPrint_Click(object sender, EventArgs e)
        //{
        //    if (bdsBarcode.Position < 0)
        //        return;

        //    drCurrent = ((DataRowView)bdsBarcode.Current).Row;
        //    this.Print(drCurrent["Barcode"].ToString(), Convert.ToBoolean(drCurrent["Is_Barem"]), false);
        //}

		void cboCa_TextChanged(object sender, EventArgs e)
		{
			this.FillData();
		}
        private bool dgvLookupMa_Vt_Sp(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "Ma_Nh_Vt = 'PHOI'");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {

                dgvCell.Value = drLookup["Ma_Vt"].ToString();
                dgvCell.Tag = drLookup["Ten_Vt"].ToString();
                drCurrent["Ten_Vt"] = drLookup["Ten_Vt"].ToString();

                string strSQL = "UPDATE R81DMBARCODEPH SET Ma_Vt_Sp = @Value, LastModify_Log = @LastModify_Log WHERE Barcode = @Barcode";
                Hashtable htPara = new Hashtable();
                htPara["BARCODE"] = drCurrent["Barcode"];
                htPara["VALUE"] = drLookup["Ma_Vt"].ToString();
                htPara["LASTMODIFY_LOG"] = Common.GetCurrent_Log();
                SQLExec.Execute(strSQL, htPara, CommandType.Text);
            }
            return true;
        }
		void dgvBarcode_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (e.RowIndex < 0 || e.RowIndex < 0)
				return;

            drCurrent = ((DataRowView)bdsBarcode.Current).Row;

            string strColName = dgvBarcode.Columns[e.ColumnIndex].Name;

            //bool bLookup = true;
            //if (strColumnName == "MA_VT_SP")
            //    bLookup = dgvLookupMa_Vt_Sp(ref dgvCell);

            if (dgvBarcode.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode) //!dgvBarcode.Columns[strColName].ReadOnly && Common.Inlist(strColName, "SO_LUONG,NUM_BARS"))
            {
               
                //Nếu số mẻ đã kế thừa thì không sửa dc
                if (!(bool)Voucher_Scale.CheckInheritBarCode_PNSB(drCurrent["Barcode"].ToString()))
                {
                    Common.MsgCancel("Mẻ luyện đã kế thừa nhập thành phẩm rồi không xử lý được");
                    
                    e.Cancel = true;
                    return;
                }

                if (Common.InlistLike(strColName, "IS_NONG,SO_ME,MA_CA,MA_VT_SP")) //SO_LUONG, tam ko cho sua số lượng
                {

                    if (Common.MsgYes_No("Bạn có chắc chắn sửa dữ liệu [" + strColName + "] về " + e.FormattedValue.ToString() + "?"))
                    {
                        string strLastModify_Log = Common.GetCurrent_Log();

                        string strSQL = "UPDATE R81DMBARCODEPH SET " + strColName + " = @Value, LastModify_Log = @LastModify_Log WHERE Barcode = @Barcode";
                        Hashtable htPara = new Hashtable();
                        htPara["BARCODE"] = drCurrent["Barcode"];

                        
                        htPara["VALUE"] = (Object)Voucher.GetTypeOfTable("R81DMBARCODEPH", strColName, e.FormattedValue.ToString());
                       

                        htPara["LASTMODIFY_LOG"] = strLastModify_Log;

                       
                        
                        if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
                        {
                            drCurrent[strColName] = e.FormattedValue;
                            drCurrent["LastModify_Log"] = strLastModify_Log;

                            //if (strColName == "SO_LUONG")
                            //{
                            //    drCurrent["Change_So_Luong"] = true;
                            //    drCurrent["Chenh_Lech"] = Convert.ToDouble(drCurrent["So_Luong"]) - Convert.ToDouble(drCurrent["BQ_Phoi"]);
                            //    //tính lại chiều dài
                            //    strSQL = "UPDATE R81DMBARCODEPH SET DDai_Phoi = "+ Convert.ToDouble(drCurrent["So_Luong"]) +"/DBO.fn_CalBaremPhoi(@Ma_Vt_Sp,@Ngay_Nhap, '') WHERE Barcode = @Barcode";
                            //    Hashtable htPara1 = new Hashtable();
                            //    htPara1["BARCODE"] = drCurrent["Barcode"];
                            //    htPara1["MA_VT_SP"] = drCurrent["Ma_Vt_Sp"];
                            //    htPara1["NGAY_NHAP"] = drCurrent["Ngay_Nhap"];
                            //    RosySystem.Data.SQLExec.Execute(strSQL, htPara1, CommandType.Text);
                            //}



                            drCurrent.AcceptChanges();
                        }
                    }
                    else
                        e.Cancel = true;
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

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F4:
                    if (dgvBarcodeTB.Visible == true)
                    {
                        dgvBarcodeTB.Visible = false;
                        dgvBarcode.Visible = true;
                    }
                    else
                    {
                        dgvBarcodeTB.Visible = true;
                        dgvBarcode.Visible = false;
                    }
                    return;
            }
        }
	}
}
