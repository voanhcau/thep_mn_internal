using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Library;
using System.Collections;
using RosySystem.Common;
using RosySystem;

namespace RosyModule.ScaleBarcode
{
    public partial class frmKCS_Edit : RosySystem.Customize.frmView
	{
		DataTable dtKCS;
		DataRow drFilter;
		int iLengthX;
		string strTry_ID;
        string strBarcode1;
        public string strBarcode2;
        public bool isAccept = false;

        DataTable dtCoTinh;
     
        BindingSource bdsCoTinh = new BindingSource();

		public frmKCS_Edit()
		{
			InitializeComponent();
			
			this.cboBarcode1.Validated += new EventHandler(cboBarcode1_Validated);
			this.cboBarcode2.Validated += new EventHandler(cboBarcode1_Validated);
			
			this.cboBarcode2.SelectedIndexChanged += new EventHandler(cboBarcode2_SelectedIndexChanged);
			this.btAccept.Click += new EventHandler(btAccept_Click);
			this.btClear_Update.Click += new EventHandler(btClear_Update_Click);
            this.btUpdate_Barcode.Click += new EventHandler(btUpdate_Barcode_Click);

            this.txtNo_Melt_Confirm.Leave += new EventHandler(txtNo_Melt_Confirm_LostFocus);
            this.txtNum_Lot.Validating += new CancelEventHandler(txtNum_Lot_Validating);
			this.cboBarcode1.KeyDown += new KeyEventHandler(cboBarcode1_KeyDown);
			this.cboBarcode2.KeyDown += new KeyEventHandler(cboBarcode2_KeyDown);

            this.dgvCoTinh.CellContentClick += new DataGridViewCellEventHandler(dgvCoTinh_CellContentClick);
		}

     


		public void Load(DataTable dtKCS, DataRow drFilter)
		{
			this.dtKCS = dtKCS;
			this.drFilter = drFilter;
            Build();
			this.FillData();
            cboBend_Test.SelectedIndex = 2;
            

            if (!Common.CheckPermission("LOCKED_BARCODE", enuPermission_Type.Allow_Access))
                btUpdate_Barcode.Visible = false;

			this.BindingLanguage();
			this.ShowDialog();
		}
        private void Build()
        {
            dgvCoTinh.Dock = DockStyle.Fill;
            dgvCoTinh.strZone = "KQCOTINH";
            dgvCoTinh.BuildGridView();

            rsGroupBox1.Controls.Add(dgvCoTinh);

            dgvCoTinh.ReadOnly = false;

            foreach (DataGridViewColumn DC in dgvCoTinh.Columns)
                DC.ReadOnly = true;

            if (dgvCoTinh.Columns.Contains("CHON"))
                dgvCoTinh.Columns["Chon"].ReadOnly = false;
            


        }
		private void FillData()
		{
			//Add Item into Barcode
			cboBarcode1.Items.Clear();
			cboBarcode2.Items.Clear();
           
            
			if (dtKCS != null)
			{
				if (dtKCS.Rows.Count > 0)
				{
                    foreach (DataRow drBarcode in dtKCS.Select("Try_ID = '' AND ELong = 0 AND Yeild = 0 AND Tension = 0 AND No_Melt_Confirm = ''"))
					{
                        cboBarcode1.Items.Add(drBarcode["Barcode"]);
                        cboBarcode2.Items.Add(drBarcode["Barcode"]);
					}
				}
			}

			this.cboGHan_So_Barcode.Items.AddRange(new object[] { "40", "50", "60" });
			this.txtNo_Melt_Confirm.Text = string.Empty;
			this.numYeild.Value = this.numTension.Value = this.numElong.Value = 0;
			this.cboGHan_So_Barcode.SelectedIndex = 1;
			this.cboBend_Test.SelectedIndex = 1;

            if(cboBarcode1.Items.Count > 0)
                this.cboBarcode1.SelectedIndex = cboBarcode2.SelectedIndex = 0;
			
			this.cboBarcode1.Focus();
		}

		private double CheckOutPutAndInput(string strBarcode)
		{
			string strSQLExec = @"
				SELECT ISNULL(SUM(T2.So_Luong), 0) - ISNULL(SUM(T1.So_Luong), 0)
					FROM R05CTX_BARCODE T1 WITH(NOLOCK) LEFT JOIN
							(SELECT T1a.Barcode, SUM(T1a.So_Luong) AS So_Luong
								FROM R05CTN_BARCODE T1a WITH(NOLOCK) JOIN R81DMBARCODE T2a WITH(NOLOCK) ON T1a.Barcode = T2a.Barcode
								WHERE T1a.Barcode = '" + strBarcode + "' AND T2a.Is_OutPut = 1" + @"
								GROUP BY T1a.Barcode) T2 ON T1.Barcode = T2.Barcode" + @"
					WHERE T1.Barcode = '" + strBarcode + "'";

			return Convert.ToDouble(SQLExec.ExecuteReturnValue(strSQLExec));
		}

		private bool Save()
		{
			if (txtNo_Melt_Confirm.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("No_Melt_Confirm") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}
            if (txtNo_Melt_Confirm.Text.Length < 5)
            {
                Common.MsgCancel("Mẻ luyện không được nhỏ hơn 5 ký tự");
                return false;
            }
            //// Kiểm tra lô sản phẩm có mẻ luyện
            //Lấy num_lot của barcode
            DataRow drBarcode = DataTool.SQLGetDataRowByID("R81DMBARCODE", "Barcode", cboBarcode1.Text);
            //Lấy Num_Lot sửa lại          
         //   object objValue = SQLExec.ExecuteReturnValue("SELECT DISTINCT Num_Lot + ',' FROM R81DMBARCODE WHERE No_Melt_Confirm = '" + txtNo_Melt_Confirm.Text.Trim() + "' " +
									//"AND Num_Lot <> '"+ drBarcode["Num_Lot"].ToString() + "' AND Ma_Vt_Sp = '" + drBarcode["Ma_Vt_Sp"].ToString() + "' FOR XML PATH('')");
         //   if (objValue != null && objValue.ToString() != string.Empty)
         //   {
         //       string strNum_Lot_List = objValue.ToString();
         //       if (strNum_Lot_List.EndsWith(","))
         //           strNum_Lot_List = strNum_Lot_List.Substring(0, strNum_Lot_List.Length - 1);

         //       if (Common.MsgOk("Xác nhận mẽ luyện này tồn tại trong các lô sản phẩm: {" + strNum_Lot_List + "}.\r\nBạn vui lòng kiểm tra lại thông tin mẻ luyện"))
         //       {
         //           txtNo_Melt_Confirm.Focus();
         //           return false;
         //       }
         //   }
            
            
            //// Kiểm tra mẻ luyện có tồn tại ở lô sp nào chưa
            object objNo_Melt_Confirm = SQLExec.ExecuteReturnValue("SELECT MAX(No_Melt_Confirm) FROM R81DMBARCODE " +
					" WHERE Num_Lot IN (SELECT Num_Lot FROM R81DMBARCODE WHERE No_Melt_Confirm = '" + txtNo_Melt_Confirm.Text.Trim() + "' AND Ma_Vt_Sp =  '" + drBarcode["Ma_Vt_Sp"].ToString() + "' )");
            if (objNo_Melt_Confirm != null && objNo_Melt_Confirm.ToString() != string.Empty)
            {
                string strNo_Melt_Confirm = objNo_Melt_Confirm.ToString();
                
                if (strNo_Melt_Confirm != txtNo_Melt_Confirm.Text) // Kiểm tra 1 mẻ luyện chỉ thuộc 1 lô
                {
                    if (Common.MsgOk("Xác nhận mẽ luyện này không tồn tại lô sản phẩm " + strNo_Melt_Confirm +" .\r\nBạn vui lòng kiểm tra lại thông tin mẻ luyện"))
                        {
                            txtNo_Melt_Confirm.Focus();
                            return false;
                        }
                }
            }
			strBarcode1 = this.cboBarcode1.Text.ToString();
			strBarcode2 = this.cboBarcode2.Text.ToString();

			this.iLengthX = strBarcode1.Length;

			bool bFlag1 = false;
			bool bFlag2 = false;

			try
			{
                this.strTry_ID = ("000000" + strBarcode1).Substring(strBarcode1.Length, 6) + "-" + ("000000" + strBarcode2).Substring(strBarcode2.Length, 6);
			}
			catch
			{
			}

			for (int i = 0; i < this.cboBarcode1.Items.Count; i++)
			{
				string strValue = cboBarcode1.Items[i].ToString();
				if (strValue == strBarcode1)
					bFlag1 = true;

				if (strValue == strBarcode2)
					bFlag2 = true;
			}

			if (!bFlag1)
			{
				Common.MsgCancel("Không có mã vạch {" + strBarcode1 + "} trong danh sách các mã vạch này");
			}
			else
			{
				if (!bFlag2)
				{
					Common.MsgCancel("Không có mã vạch {" + strBarcode2 + "} trong danh sách các mã vạch này");
				}
				else
				{
					string strSQLExec = @"SELECT T1.Barcode, T1.Is_OutPut, T1.Is_Wait_Process, T1.Is_Thu_Pham, T3.Diameter, T2.DMin, T2.DMax, T2.YeildP_Min, T2.YeildP_Max, T2.TensionP_Min, T2.TensionP_Max, T2.Elong_Min, T2.ELong_Max
												FROM R81DMBARCODE T1 JOIN R81DMCOTINH T2 ON T1.Grade_ID = T2.Grade_ID
																		JOIN R81DMSIZE T3 ON T1.Ma_Size = T3.Ma_Size
												WHERE (T3.Diameter >= T2.DMin AND T3.Diameter <= T3.DMax) AND T1.Barcode BETWEEN '" + strBarcode1 + "' AND '" + strBarcode2 + "' AND LEN(T1.Barcode) = " + iLengthX + "";

					DataTable dtDmCoTinh = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
					double dbYeildP_Min = 0;
					double dbTensionP_Min = 0;
					double dbELong_Min = 0;
					double dbYeildP_Max = 0;
					double dbTensionP_Max = 0;
					double dbELong_Max = 0;
                    string strNum_Lot = string.Empty;
                    string strNo_Melt_Confirm = string.Empty;

					bool bIs_OutPut, bIs_OutPut_Thu_Pham, bIs_Wait_Process, bIs_Thu_Pham = false;

					if (dtDmCoTinh.Rows.Count <= 0)
					{
						Common.MsgCancel("Kiểm tra mác thép của dãy mã vạch này đã tồn tại trong Danh mục cơ tính chưa");
                        return false;
					}

					foreach (DataRow drCoTinh in dtDmCoTinh.Rows)
					{
						//Kiểm tra bó đã được xuất chưa. Nếu xuất rồi thì không set lại
						if (DataTool.SQLCheckExist("R05CTX_BARCODE", "Barcode", drCoTinh["Barcode"].ToString()))
							continue;
						
						// Kiểm tra 1 lô không thể có 2 mẻ (No_Melt_Confirm)
						strNum_Lot = SQLExec.ExecuteReturnValue("SELECT Num_Lot FROM R81DMBARCODE WHERE Barcode = '" + drCoTinh["Barcode"].ToString() + "'").ToString();
                        strNo_Melt_Confirm = SQLExec.ExecuteReturnValue("SELECT No_Melt_Confirm FROM R81DMBARCODE WHERE Num_Lot = '" + strNum_Lot + "'").ToString();
                     
                        if (strNo_Melt_Confirm != "" && strNo_Melt_Confirm != txtNo_Melt_Confirm.Text)
                        {
                            Common.MsgCancel("Lô sản phẩm '"+ strNum_Lot +"' có số mẻ '"+ strNo_Melt_Confirm +"' không thể có 2 số mẻ khác nhau. Vui lòng kiểm tra lại");
                            return false;
                        }
						
                        //
                        bIs_Wait_Process = drCoTinh["Is_Wait_Process"] == DBNull.Value ? false : (bool)drCoTinh["Is_Wait_Process"];
						bIs_Thu_Pham = drCoTinh["Is_Thu_Pham"] == DBNull.Value ? false : (bool)drCoTinh["Is_Thu_Pham"];
						bIs_OutPut_Thu_Pham = drCoTinh["Is_OutPut"] == DBNull.Value ? false : (bool)drCoTinh["Is_OutPut"];

						if (bIs_Wait_Process)
						{
							bIs_OutPut = false;
							bIs_Thu_Pham = false;
						}
						else
						{
							bIs_OutPut = true;
						}

						if (bIs_Thu_Pham)
						{
							bIs_OutPut = bIs_OutPut_Thu_Pham;
						}

						dbYeildP_Min = drCoTinh["YeildP_Min"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["YeildP_Min"]);
						dbTensionP_Min = drCoTinh["TensionP_Min"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["TensionP_Min"]);
						dbELong_Min = drCoTinh["ELong_Min"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["Elong_Min"]);

						dbYeildP_Max = drCoTinh["YeildP_Max"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["YeildP_Max"]);
						dbTensionP_Max = drCoTinh["TensionP_Max"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["TensionP_Max"]);
						dbELong_Max = drCoTinh["ELong_Max"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["Elong_Max"]);

						if (this.numYeild.Value < dbYeildP_Min)
						{
							Common.MsgCancel("Giới hạn chảy dưới mức cho phép của mác này");
                            return false;
						}
						if (this.numTension.Value < dbTensionP_Min)
						{
							Common.MsgCancel("Giới hạn bền dưới mức cho phép của mác này");
                            return false;
						}
						if (this.numElong.Value < dbELong_Min)
						{
							Common.MsgCancel("Độ dãn dài dưới mức cho phép của mác này");
                            return false;
						}

						//Max
						if (numYeild.Value > dbYeildP_Max)
						{
							Common.MsgCancel("Giới hạn chảy trên mức cho phép của mác này");
                            return false;
						}

						if (numTension.Value > dbTensionP_Max)
						{
							Common.MsgCancel("Giới hạn bền trên mức cho phép của mác này");
                            return false;
						}

						if (numElong.Value > dbELong_Max)
						{
							Common.MsgCancel("Độ dãn dài trên mức cho phép của mác này");
                            return false;
						}
                        if (numElong.Value == 0 || numTension.Value == 0 || numYeild.Value == 0)
                        {
                            Common.MsgCancel("Dữ liệu không thể bằng 0 khi cập nhật");
                            return false;
                        }
						Hashtable htPara = new Hashtable();
						htPara.Add("BARCODE", drCoTinh["Barcode"]);
						htPara.Add("YEILD", numYeild.Value);
						htPara.Add("TENSION", numTension.Value);
						htPara.Add("ELONG", numElong.Value);
						htPara.Add("BEND_TEST", cboBend_Test.SelectedIndex);
						htPara.Add("TRY_ID", this.strTry_ID);
						htPara.Add("IS_OUTPUT", bIs_OutPut);
						htPara.Add("IS_THU_PHAM", bIs_Thu_Pham);
						htPara.Add("NO_MELT_CONFIRM", txtNo_Melt_Confirm.Text.Trim());
						htPara.Add("LASTMODIFY_LOG_KCS", Common.GetCurrent_Log());

						//Cap nhat KCS vao Danh muc Barcode
						try
						{
							SQLExec.Execute("sp_Update_DmBarcode_KCS", htPara, CommandType.StoredProcedure);
                            
                           
						}
						catch (Exception ex)
						{
							Common.MsgCancel("Có lỗi xãy ra khi cập nhật!" + ex.ToString());
                            return false;
						}
					}

                    //this.FillData();
                    
                    
                    
				}
			}
            Common.MsgOk("Cập nhật cơ tính thành công!");
            return true;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
            if(Save())
               this.isAccept = true;
            else
                this.isAccept = false;
		}
        void btUpdate_Barcode_Click(object sender, EventArgs e)
        {
            strBarcode1 = cboBarcode1.Text.ToString();
            strBarcode2 = cboBarcode2.Text.ToString();
            if (Common.MsgYes_No("Bạn có chắc chắn hồi các thông tin đã cập nhật từ mã vạch {" + strBarcode1 + "} đến mã vạch {" + strBarcode2 + "} không?", "N"))
            {
                string strLastModify_Log_KCS = Common.GetCurrent_Log();
                string strSQLExec = @"SELECT *
											FROM R81DMBARCODE
											WHERE Barcode BETWEEN '" + strBarcode1 + "' AND '" + strBarcode2 + "'";

                DataTable dtDmBarcode = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
                foreach (DataRow drBarcode in dtDmBarcode.Rows)
                {
                    if (DataTool.SQLCheckExist("R05CTX_BARCODE", "Barcode", drBarcode["Barcode"].ToString()))
                        continue;
                    //kiểm tra xem ngày nhập barcode vào kế toán đã khóa dl chưa
                    string strStt = SQLExec.ExecuteReturnValue("SELECT Stt_Inherit_NhapTP FROM R81DMBARCODE Where Barcode = '" + drBarcode["Barcode"].ToString() + "'").ToString();
                    if (strStt == "")
                    {
                        string strSQLExec0 = @"UPDATE R81DMBARCODE SET LastModify_Log_KCS = '" + strLastModify_Log_KCS + "', Ma_CL = '1', Try_ID = '', Is_OutPut = 0, Yeild = 0, Tension = 0, ELong = 0, Is_Wait_Process = 0," +
                                    " Is_Thu_Pham = 0, No_Melt_Confirm = '', Stt_Inherit_NhapTP = ''" +
                            " WHERE Barcode = '" + drBarcode["Barcode"] + "'";
                        SQLExec.Execute(strSQLExec0, CommandType.Text);

                        this.isAccept = true;
                        this.Close();
                    }
                    else
                    {
                        DateTime dtNgay = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT Ngay_Ct FROM R80PH WHERE Stt = '" + strStt + "' AND Ma_Ct = 'TP'"));
                        if (Common.CheckDataLocked(Convert.ToDateTime(dtNgay)))
                        {
                            string strSQLExec0 = @"UPDATE R81DMBARCODE SET LastModify_Log_KCS = '" + strLastModify_Log_KCS + "', Ma_CL = '1', Try_ID = '', Is_OutPut = 0, Yeild = 0, Tension = 0, ELong = 0, Is_Wait_Process = 0," +
                                    " Is_Thu_Pham = 0, No_Melt_Confirm = '', Stt_Inherit_NhapTP = ''" +
                            " WHERE Barcode = '" + drBarcode["Barcode"] + "'";
                            SQLExec.Execute(strSQLExec0, CommandType.Text);

                            this.isAccept = true;
                            this.Close();
                        }
                    }
                }
            }
        }
		void btClear_Update_Click(object sender, EventArgs e)
		{
			string strBarcode1 = cboBarcode1.Text.ToString();
			string strBarcode2 = cboBarcode2.Text.ToString();
			
            bool bIs_PH = false;
			if (Common.MsgYes_No("Bạn có chắc chắn hủy bỏ các thông tin đã cập nhật từ mã vạch {" + strBarcode1 + "} đến mã vạch {" + strBarcode2 + "} không?", "N"))
			{
				string strLastModify_Log_KCS = Common.GetCurrent_Log();
				string strSQLExec = @"SELECT *
											FROM R81DMBARCODE
											WHERE Barcode BETWEEN '" + strBarcode1 + "' AND '" + strBarcode2 + "'";

				DataTable dtDmBarcode = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
				foreach (DataRow drBarcode in dtDmBarcode.Rows)
				{
					//Kiểm tra bó đã được xuất chưa. Nếu xuất rồi thì không set lại
					if (DataTool.SQLCheckExist("R05CTX_BARCODE", "Barcode", drBarcode["Barcode"].ToString()))
						continue;
                    
                    
                    bIs_PH = drBarcode["Stt_Inherit_NhapTp"].ToString() == "" ? true : false;
                    if (!bIs_PH)
                    {
                        Common.MsgOk("Bó thép " + drBarcode["Barcode"] + " đã hạch toán vào kế toán không được chỉnh sửa");
                        continue;
                    }
					string strSQLExec0 = @"UPDATE R81DMBARCODE SET LastModify_Log_KCS = '" + strLastModify_Log_KCS + "', Ma_CL = '1', Try_ID = '', Is_OutPut = 0, Yeild = 0, Tension = 0, ELong = 0, Is_Wait_Process = 0, Is_Thu_Pham = 0, No_Melt_Confirm = ''"+
                        " WHERE Barcode = '" + drBarcode["Barcode"] + "'";
					SQLExec.Execute(strSQLExec0, CommandType.Text);
				}
				
				Common.MsgOk("Đã hủy cập nhật thành công!");
				
			}
		}
        //void txtNo_Melt_Confirm_Validating(object sender, CancelEventArgs e)
        //{
        //    string strValue = txtNo_Melt_Confirm.Text.Trim();
        //    bool bRequire = true;

        //    DataRow drLookup =  RosySystem.Public.Lookup.ShowLookup("No_Melt", strValue, bRequire, "", "");

        //    if (bRequire && drLookup == null)
        //        e.Cancel = true;

        //    if (drLookup == null)
        //    {
        //        txtNo_Melt_Confirm.Text = string.Empty;

        //    }
        //    else
        //    {
        //        txtNo_Melt_Confirm.Text = drLookup["No_Melt"].ToString();
               
        //    }
        //}
        void txtNo_Melt_Confirm_LostFocus(object sender, EventArgs e)
        {
           if(!DataTool.SQLCheckExist("R81MTTPHH","No_Melt", txtNo_Melt_Confirm.Text) && txtNo_Melt_Confirm.Text!="")
           {
               Common.MsgOk("Mẻ luyện này chưa được khai thành phần hóa. Yêu cầu khai báo trước khi cập nhật cơ tính!!!");
               txtNo_Melt_Confirm.Text="";
               txtNo_Melt_Confirm.Focus();
           }
        }
        void txtNum_Lot_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtNum_Lot.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = RosySystem.Public.Lookup.ShowLookup("Num_Lot", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtNum_Lot.Text = string.Empty;
                
            }
            else
            {
                txtNum_Lot.Text = drLookup["Num_lot"].ToString();
                cboBarcode1.Text = drLookup["Barcode1"].ToString();
                cboBarcode2.Text = drLookup["Barcode2"].ToString();

                // hiện thị kết quả thử nghiệm
                Hashtable ht = new Hashtable();
                ht.Add("NUM_LOT", txtNum_Lot.Text);

                dtCoTinh = SQLExec.ExecuteReturnDt("SELECT  File_Name, Num_Lot, No_Melt, Stt, Ten_Vt_Sp, Ten_Nv_Th, Tieu_Chuan, Tieu_Chuan_TN, Ngay_Sx, Ngay_Test, Don_Trong, Duong_Kinh, Size, Tiet_Dien, Length_First, "
                    + "Khoi_Luong_Rieng, Toc_Do_Keo, Luc_Keo_Max, Luc_LF, Luc_Chay_Tren, Luc_Chay_Duoi, Tension, Yeild_Tren, Yeild_Duoi, ROUND(Elong,1) AS Elong, Length_L1, ReportNum, Tension_Mpa "
                                +", CAST(0 AS BIT) AS Chon FROM R81CLSP_DATAIMP WHERE Num_Lot = @Num_Lot ", ht, CommandType.Text);
                bdsCoTinh.DataSource = dtCoTinh;
                dgvCoTinh.DataSource = bdsCoTinh;
            }
        }

        void dgvCoTinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bdsCoTinh.Position < 0)
                return;

            DataRow drCoTinh = ((DataRowView)bdsCoTinh.Current).Row;
            string strColumn_Name = dgvCoTinh.Columns[e.ColumnIndex].DataPropertyName;
            //
            if (strColumn_Name == "CHON")
            {
                txtNo_Melt_Confirm.Text = drCoTinh["No_Melt"].ToString();
                numYeild.Value = Math.Round(Convert.ToDouble(drCoTinh["Yeild_Tren"]), MidpointRounding.AwayFromZero);
                numTension.Value = Math.Round(Convert.ToDouble(drCoTinh["Tension"]), MidpointRounding.AwayFromZero);
                numElong.Value = Math.Round(Convert.ToDouble(drCoTinh["Elong"]), 1);
                foreach (DataRow dr in dtCoTinh.Rows)
                {
                    if (drCoTinh["File_Name"].ToString() != dr["File_Name"].ToString())
                    {
                        if ((bool)dr["Chon"] == true)
                            dr["Chon"] = false;
                    }
                }
            }
        }

		void cboBarcode1_Validated(object sender, EventArgs e)
		{
			try
			{
				string strBarcode1 = cboBarcode1.Text.ToString();
				string strBarcode2 = cboBarcode2.Text.ToString();
				this.strTry_ID = ("000000" + strBarcode1).Substring(strBarcode1.Length, 6) + "-" + ("000000" + strBarcode2).Substring(strBarcode2.Length, 6);
			}
			catch
			{
			}
		}

		void cboBarcode2_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (cboBarcode1.Text != string.Empty && cboBarcode2.Text != string.Empty)
				{
					int iDai_Bo = Convert.ToInt32(this.cboBarcode2.Text) - Convert.ToInt32(this.cboBarcode1.Text);
                    //if (cboGHan_So_Barcode.SelectedItem != null)
                    //{
                    //    if (iDai_Bo > Convert.ToInt32(cboGHan_So_Barcode.SelectedItem))
                    //    {
                    //        Common.MsgCancel("Dải bó nhập không hợp lệ");
                    //        this.cboBarcode2.SelectedIndex = this.cboBarcode1.SelectedIndex;
                    //    }
                    //}
                    //else
                    //{
					if (iDai_Bo > 50)
					{
						Common.MsgCancel("Dải bó nhập của số lô "+ txtNum_Lot.Text +" vượt 50 bó");
                        //this.cboBarcode2.SelectedIndex = this.cboBarcode1.SelectedIndex;
					}
                    //}

				}
			}
			catch
			{
			}
		}

		void cboBarcode2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
				this.txtNo_Melt_Confirm.Focus();
		}

		void cboBarcode1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				cboBarcode2.Focus();
				if (this.cboBarcode2.Text.Length >= 3)
				{
					this.cboBarcode2.Select(this.cboBarcode2.Text.Length - 3, 3);
				}
			}

		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if(!Common.CheckPermission(this.Object_ID, RosySystem.enuPermission_Type.Allow_Edit))
				this.btAccept.Enabled = this.btClear_Update.Enabled = false;
		}

        private void frmKCS_Edit_Load(object sender, EventArgs e)
        {

        }
	}
}
