using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using RosySystem;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Public;
using RosySystem.Common;
using RosySystem.Customize;

namespace RosyModule.Receivable
{
	public partial class frmCtHD_Edit : frmVoucher_Edit
	{
		#region Declare

		private string strTk_NoTmp = string.Empty;
		private string strTk_CoTmp = string.Empty;
		private string strModule = "04";
		private bool bMa_Vt_Changed = false;
        string strSo_Hd_Ngay;
		#endregion

		#region Contructor

		public frmCtHD_Edit()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

			this.btHanTt.Click += new EventHandler(btHanTt_Click);
			

			this.btInherit.Click += new EventHandler(btInherit_Click);
            this.btPhanbo.Click += new EventHandler(btPhanbo_Click);
			this.btTinhGia.Click += new EventHandler(btTinhGia_Click);
            this.btImportExcel.Click += new EventHandler(btnImportExcel_Click);

			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
			//txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);


			//txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			txtMa_Kho_CalGia.Validating += new CancelEventHandler(txtMa_Kho_Xuat_Validating);
			txtSo_QD.Validating += new CancelEventHandler(txtSo_QD_Validating);
			txtMa_CTrinh.Validating += new CancelEventHandler(txtMa_CTrinh_Validating);
            txtHt_Tt.Validating +=new CancelEventHandler(txtLoai_Gia_Validating);
            txtPt_Vc.Validating += new CancelEventHandler(txtPt_Vc_Validating);
			txtSo_Ct.Validating += new CancelEventHandler(txtSo_Ct_Validating);
			txtSo_Ct.TextChanged += new EventHandler(txtSo_Ct_TextChanged);
			txtSo_Ct0.Validated += TxtSo_Ct0_Validated;
			dteNgay_Ct.TextChanged += new EventHandler(dteNgay_Ct_TextChanged);
			dteNgay_Ct.Validating += new CancelEventHandler(dteNgay_Ct_Validating);

			txtMa_Tte.Validating += new CancelEventHandler(txtMa_Tte_Validating);
			numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);

			txtMa_Thue.Validating += new CancelEventHandler(txtMa_Thue_Validating);

			txtMa_So_Thue.Validating += new CancelEventHandler(txtMa_So_Thue_Validating);
			txtTk_No3.Validating += new CancelEventHandler(txtTk_No3_Validating);
			txtTk_Co3.Validating += new CancelEventHandler(txtTk_Co3_Validating);

			//numChiet_Khau.Validating += new CancelEventHandler(numChiet_Khau_Validating);

			numTTien.Validated += new EventHandler(numTTien_Validated);
			numTTien_Nt.Validated += new EventHandler(numTTien_Nt_Validated);
			numTTien3.Validated += new EventHandler(numTTien3_Validated);
			numTTien_Nt3.Validated += new EventHandler(numTTien_Nt3_Validated);
			numTTien4.Validated += new EventHandler(numTTien4_Validated);
			numTTien_Nt4.Validated += new EventHandler(numTTien4_Validated);

			dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
			dgvEditCt1.CellValueChanged += new DataGridViewCellEventHandler(dgvEditCt_CellValueChanged);
			dgvEditCt1.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);

			dgvEditCt2.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt2.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			dgvEditCt2.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit, DataSet dsVoucher)
		{
			this.drEdit = drEdit;
			this.dsVoucher = dsVoucher;

			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			this.strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();
			this.drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", this.strMa_Ct);
			this.Object_ID = strMa_Ct;

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
				this.strStt = Common.GetNewStt(strModule, true);
			else
				this.strStt = drEdit["Stt"].ToString();


			if ((string)drEdit["Ma_Ct"] == "HDXK")
			{
				lbtSo_Tkhai.Visible = true;
				lbtNgay_Tkhai.Visible = true;
				txtSo_TKhai.Visible = true;
				dteNgay_TKhai.Visible = true;
			}
			this.Build();
			this.FillData();
			this.Init_Ct();

			Common.ScaterMemvar(this, ref drEditPh);

			txtMa_Tte.bTextChange = false;
			numTy_Gia.bTextChange = false;

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                if (Parameters.GetParaValue("HDDT").ToString() == "1" && strMa_Ct == "HD" && enuNew_Edit == enuEdit.New)
                    So_Ct_HDDT();

                if (enuNew_Edit == enuEdit.Copy)
                {
                    //xóa trắng số seri và mau ki hieu HD
                    txtMa_Ky_Hieu_HDon.Text = "";
                    txtSo_Seri0.Text = "";
                    txtMa_Thue.Text = "";
                    numTTien3.Value = 0;
                    numTTien_Nt3.Value = 0;
                }

            }

			this.Ma_Tte_Valid();
			this.BindingLanguage();
			this.LoadDicName();
			this.DataGridView_Language();

			if (!this.Visible)
				this.ShowDialog();
			else
			{
				this.ActiveControl = txtMa_Nvu;
				this.dgvEditCt1.ClearSelection();
			}
		}

		#endregion

		#region Phuong thuc

		private void Build()
		{
			dgvEditCt1.bSortMode = false;
			dgvEditCt1.strZone = (string)drDmCt["Zone_EditCt1"];
			dgvEditCt1.BuildGridView();

			dgvEditCt2.bSortMode = false;
			dgvEditCt2.strZone = (string)drDmCt["Zone_EditCt2"];
			dgvEditCt2.BuildGridView();


            dgvExport.bSortMode = false;
            dgvExport.strZone = "PXDTEXCEL";
            dgvExport.BuildGridView();

			if (dgvEditCt2.Columns.Contains("So_Luong"))
				dgvEditCt2.Columns["So_Luong"].ReadOnly = true;
           
			if (dgvEditCt1.Columns.Contains("MA_VT"))
			{
				((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
				//((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = "Ma_Nh_Vt = 'THEPCANDAI'";
			}

			tabControl1.TabPages.Remove(tabPage2);
			DataGridView_Language();
		}
		private void DataGridView_Language()
		{		
			if (dgvEditCt1.Columns.Contains("Gia_Nt9"))
				dgvEditCt1.Columns["Gia_Nt9"].HeaderText = "Giá bán";
			if (dgvEditCt1.Columns.Contains("Tien_Nt9"))
				dgvEditCt1.Columns["Tien_Nt9"].HeaderText = "Doanh thu";

			if (dgvEditCt1.Columns.Contains("Gia"))
				dgvEditCt1.Columns["Gia"].HeaderText = "Giá xuất kho";
			if (dgvEditCt1.Columns.Contains("Tien"))
				dgvEditCt1.Columns["Tien"].HeaderText = "Tiền vốn";

		}
		
		private void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("TABLE_PH", (string)drDmCt["Table_Ph"]);
			htPara.Add("TABLE_CT", (string)drDmCt["Table_Ct"]);
			htPara.Add("STT", ((string)drEdit["Stt"]).Trim());
            htPara.Add("USER_LOGIN", Element.sysUser_Id);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter", htPara, CommandType.StoredProcedure);

			dtEditPh = dsVoucher.Tables[0];
			dtEditCt = dsVoucher.Tables[1];

			if (enuNew_Edit == enuEdit.New)
				dtEditCt.Clear();

			DataColumn dc = new DataColumn("Deleted", typeof(bool));
			dc.DefaultValue = false;
			dtEditCt.Columns.Add(dc);

			bdsEditCt.DataSource = dtEditCt;

			dgvEditCt1.DataSource = bdsEditCt;
			dgvEditCt1.ClearSelection();

			dgvEditCt2.DataSource = bdsEditCt;
			dgvEditCt2.ClearSelection();

            if (!Voucher.Access_Price_Xuat(dtEditCt, strMa_Ct, dgvEditCt1))
            {
                numTTien0.Visible = false;
                numTTien_Nt0.Visible = false;

                numTTien3.Visible = false;
                numTTien_Nt3.Visible = false;

                numTTien4.Visible = false;
                numTTien_Nt4.Visible = false;

                numTTien.Visible = false;
                numTTien_Nt.Visible = false;


            }
		}

		private void Init_Ct()
		{
			txtMa_Tte.InputMask = (string)RosySystem.Library.Parameters.GetParaValue("MA_TTE_LIST");

			if (dtEditPh.Rows.Count == 0)
			{
				DataRow drNew = dtEditPh.NewRow();
				Common.SetDefaultDataRow(ref drNew);

				dtEditPh.Rows.Add(drNew);
			}

			if (dtEditCt.Rows.Count == 0)
			{
				DataRow drNew = dtEditCt.NewRow();
				Common.SetDefaultDataRow(ref drNew);

				dtEditCt.Rows.Add(drNew);
			}

			drEditPh = dtEditPh.Rows[0];
			drCurrent = dtEditCt.Rows[0];

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
                drEditPh["HDDTDaTao"] = false;
                drEditPh["HDDTNguoiTao"] = "";
                drEditPh["HDDTChuyenDoi"] = false;
                drEditPh["HDDTNguoiCD"] = "";
                drEditPh["Duyet_Huy"] = false;
                drEditPh["Ghi_Chu_Huy"] = "";

				if (enuNew_Edit == enuEdit.New)
				{
					//Ngầm định 1 số thông tin từ chứng từ cũ
					if (drEdit != null)
						Common.CopyDataRow(drEdit, drCurrent, (string)drDmCt["Carry_Header"]);

					drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;
					drCurrent["Stt"] = strStt;
					drCurrent["Stt0"] = 1;
					drCurrent["Ma_Ct"] = strMa_Ct;
					drCurrent["Ngay_Ct"] =  drEdit["Ngay_Ct"] != DBNull.Value ? drEdit["Ngay_Ct"] : DateTime.Now;

					drCurrent["Ma_Tte"] = Element.sysMa_Tte;
					drCurrent["Ty_Gia"] = 1;
                    
                    if((string)drDmCt["Nh_Ct"] == "2")
                        drCurrent["Han_Tt"] = 1;
					
                    if (dtEditCt.Columns.Contains("Auto_Cost") && (string)drDmCt["Nh_Ct"] == "2")
						drCurrent["Auto_Cost"] = true;
					
					drCurrent["Deleted"] = false;

					//Clear Content in drEditPh
					foreach (DataColumn dcEditPh in dtEditPh.Columns)
						drEditPh[dcEditPh] = DBNull.Value;

					drEditPh["Ma_DvCs"] = drCurrent["Ma_DvCs"];
					drEditPh["Stt"] = drCurrent["Stt"];
					drEditPh["Ma_Ct"] = drCurrent["Ma_Ct"];
					drEditPh["Ngay_Ct"] = drCurrent["Ngay_Ct"];
                    
				}
				else
				{
				
					//CT
					foreach (DataRow drEditCt in dtEditCt.Rows)
					{
						if (dtEditCt.Columns.Contains("Stt_Org")) //Bỏ các dữ liệu kế thừa
						{
							drEditCt["Stt_Org"] = "";
						}
					}
					//PH
					if (drEditPh.Table.Columns.Contains("Stt_Org"))
					{
						drEditPh["Stt_Org"] = "";
					}
                  
				}

				//Tinh so chung tu
				drEditPh["So_Ct"] = drCurrent["So_Ct"] = Voucher.Cong_So_Ct(this);
			}
			if (enuNew_Edit == enuEdit.Edit)
			{
				foreach (DataRow drEditCt in dtEditCt.Rows)
				{
					if (dtEditCt.Columns.Contains("Stt_Org")) //Bỏ các dữ liệu kế thừa
					{
						if ((string)drEditCt["Stt_Org"] != "")
						{
							if (!Common.CheckPermission("IS_EDIT_HD", enuPermission_Type.Allow_Access))
							{
								LockControl();
								break;
							}
						}
					}
				}
			}
			
			Voucher.Update_Header(this);
			Voucher.Update_Stt(this, strModule);

			if ((string)drDmCt["Nh_Ct"] == "1") //HDTL
			{
			}
			else//HĐ
			{
				drEditPh["So_Ct0"] = drCurrent["So_Ct"];//Số hóa đơn
			}

			if (dgvEditCt1.Columns.Contains("DVT"))
				dgvEditCt1.Columns["Dvt"].ReadOnly = true;

            //if (dgvEditCt1.Columns.Contains("SO_LXH"))
            //    dgvEditCt1.Columns["So_LXH"].ReadOnly = true;

            if (enuNew_Edit == enuEdit.Edit && (bool)drCurrent["Is_Lock"] && (Common.InlistLike(drCurrent["Tk_Co"].ToString(), "131") || Common.InlistLike(drCurrent["Tk_Co3"].ToString(), "131")))
            {
                dgvEditCt1.ReadOnly = true;
                //dgvEditCt2.ReadOnly = true;
                dteNgay_Ct.ReadOnly = true;
                txtMa_Dt.ReadOnly = true;
            }

			txtInherit.Text = Voucher.GetInheritVoucher(this);

			//BindingTTien            
			numTTien0.DataBindings.Clear();
			numTTien3.DataBindings.Clear();
			numTTien.DataBindings.Clear();
			numTTien4.DataBindings.Clear();

			numTTien_Nt0.DataBindings.Clear();
			numTTien_Nt3.DataBindings.Clear();
			numTTien_Nt.DataBindings.Clear();
			numTTien_Nt4.DataBindings.Clear();
			numTSo_Luong.DataBindings.Clear();

			numTTien0.DataBindings.Add("Value", dtEditPh, "TTien0");
			numTTien3.DataBindings.Add("Value", dtEditPh, "TTien3");
			numTTien.DataBindings.Add("Value", dtEditPh, "TTien");
			numTTien4.DataBindings.Add("Value", dtEditPh, "TTien4");

			numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien_Nt0");
			numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien_Nt3");
			numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");
			numTTien_Nt4.DataBindings.Add("Value", dtEditPh, "TTien_Nt4");
			numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");

          
		}

		private void LoadDicName()
		{
            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Hd.bUseAutoDropDown = true;
            txtSo_QD.bUseAutoDropDown = true;
            txtMa_CTrinh.bUseAutoDropDown = true;

			//txtMa_Nvu
			if (txtMa_Nvu.Text.Trim() != string.Empty)
				lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim());
			else
				lbtTen_Nvu.Text = string.Empty;

			//txtMa_Dt
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;

			//txtMa_Hd
			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				lbtTen_Hd.Text = Voucher.GetTenHd(txtMa_Hd.Text); //DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			}
			else
				lbtTen_Hd.Text = string.Empty;

            ////txtMa_Bp
            //if (txtMa_Bp.Text.Trim() != string.Empty)
            //{
            //	lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            //}
            //else
            //	lbtTen_Bp.Text = string.Empty;

            //txtMa_Dt_CbNv
            if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
            {
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
            }
            else
                lbtTen_Dt_CbNv.Text = string.Empty;


            ////txtMa_Kv
            //if (txtMa_Kv.Text.Trim() != string.Empty)
            //{
            //	lbtTen_Kv.Text = DataTool.SQLGetNameByCode("R81DMKV", "Ma_Kv", "Ten_Kv", txtMa_Kv.Text.Trim());
            //}
            //else
            //	lbtTen_Kv.Text = string.Empty;

            //Log
            string strCreate_Log = Common.Show_Log((string)drEditPh["Create_Log"]);
			string strLastModify_Log = Common.Show_Log((string)drEditPh["LastModify_Log"]);
			string strLog = string.Empty;
			strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
			strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";

			this.lblLog.Text = strLog;
		}

        private void So_Ct_HDDT()
        {
            dteNgay_Ct0.Text = dteNgay_Ct.Text;
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT", dteNgay_Ct.Text);
            ht.Add("SO_SERI0", txtSo_Seri0.Text);
            strSo_Hd_Ngay = SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSoCtHDDT(@Ngay_Ct, @So_Seri0)", ht, CommandType.Text).ToString();

            txtSo_Ct.Text = txtSo_Ct0.Text = strSo_Hd_Ngay;
            drEditPh["So_Ct"] = strSo_Hd_Ngay;

            dtEditPh.AcceptChanges();
            if (dtEditCt.Rows.Count > 0)
            {
                foreach (DataRow dr in dtEditCt.Rows)
                    dr["So_Ct"] = dr["So_Ct0"] = strSo_Hd_Ngay;

                dtEditCt.AcceptChanges();
            }
            
        }

		private bool FormCheckValid()
		{
            //Kiểm tra trùng số chứng từ trong ngày
            if (Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM R80PH WHERE So_Ct = '" + txtSo_Ct.Text + "' AND Ma_Ct = 'HD' AND Ngay_Ct = '" + dteNgay_Ct.Text + "'")) > 1)
            {
                So_Ct_HDDT();
            }
			if (!Common.CheckDataLocked(Library.StrToDate(this.dteNgay_Ct.Text)))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Dữ liệu đã bị khóa" : "Data have been locked";
				Common.MsgCancel(strMsg);
				return false;
			}

			if (Common.GetPartitionCurrent() != 0 && this.enuNew_Edit == enuEdit.Edit && this.drEditPh["Ngay_Ct", DataRowVersion.Original] != DBNull.Value)
			{
				if (((DateTime)this.drEditPh["Ngay_Ct"]).Year != ((DateTime)this.drEditPh["Ngay_Ct", DataRowVersion.Original]).Year)
				{
					Common.MsgCancel("Dữ liệu đã phân vùng, không cho phép sửa chứng từ từ năm này sang năm khác");
					return false;
				}
			}

			if (txtMa_Nvu.Text == string.Empty)
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa khai báo mã nghiệp vụ" : "Do not register transaction type";
				Common.MsgCancel(strMsg);
				return false;
			}

			if(dteNgay_Ct.Text != dteNgay_Ct0.Text && strMa_Ct != "HDTL")
			{
				Common.MsgOk("Ngày Ct khác ngày hóa đơn !!!");
				return false;
			}
            
            //Kiểm tra số chứng từ và số HD
            if (txtSo_Ct.Text != txtSo_Ct0.Text && strMa_Ct != "HDTL")
            {
                Common.MsgOk("Số Ct khác số hóa đơn !!!");
                return false;
            }
			//Kiểm tra TÀI KHOẢN THUẾ
			if (strMa_Ct == "HDTL" && Library.StrToDate(dteNgay_Ct.Text)>= Library.StrToDate("01/01/2026") && !txtTk_No3.Text.StartsWith("33311"))
			{
				Common.MsgOk("Tài khoản nợ của hóa đơn trả lại phải là thuế đầu ra 33312");
				return false;
			}
			//Kiểm tra số chứng từ và số HD
			if (txtSo_Seri0.Text == "" && strMa_Ct != "HDTL")
            {
                Common.MsgOk("Số seri rỗng không được lưu!!!");
                return false;
            }
			//Kiểm tra nghiệp vụ hợp lệ
			foreach (DataRow dr in dtEditCt.Rows)
			{
				if ((bool)dr["Deleted"])
					continue;

				if(chkHDQT.Checked == true && txtGhi_Chu_HD.Text == "")
                {
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "HD quà tặng phải có ghi chú mới cho phép lưu" : "Transaction turnover invalid";
					Common.MsgCancel(strMsg);
					return false;
				}

				#region Kiểm tra tính hợp lệ của định nghĩa nghiệp vụ
				foreach (DataColumn dc in drDmNvu.Table.Columns)
				{
					if (dc.ColumnName.EndsWith("_RULE") && drDmNvu.Table.Columns.Contains(dc.ColumnName.Replace("_RULE", "")))
					{
						string strRule_Name = dc.ColumnName;
						string strColumnName = strRule_Name.Replace("_RULE", "");

						if (drDmNvu[strColumnName].ToString() != "")
						{
							//1-Bắt buộc, 2-Cho phép sửa lại phần đuôi, 3-Cho phép thay đổi
							if ((drDmNvu[strRule_Name].ToString() == "1") && !(drDmNvu[strColumnName].ToString().Split(',').Any(strValue => strValue == dr[strColumnName].ToString())))
							{
								Common.MsgCancel("Nhập liệu [" + Languages.GetLanguage(strColumnName) + "] không đúng với định nghĩa nghiệp vụ!");
								return false;
							}
							else if ((drDmNvu[strRule_Name].ToString() == "2") && !(drDmNvu[strColumnName].ToString().Split(',').Any(strValue => dr[strColumnName].ToString().StartsWith(strValue))))
							{
								Common.MsgCancel("Nhập liệu [" + Languages.GetLanguage(strColumnName) + "] không đúng với định nghĩa nghiệp vụ!");
								return false;
							}
						}
					}
				}
				#endregion

				DataRow drDmTkNo = DataTool.SQLGetDataRowByID("R81DmTk", "Tk", dr["Tk_No2"].ToString());
				DataRow drDmTkCo = DataTool.SQLGetDataRowByID("R81DmTk", "Tk", dr["Tk_Co2"].ToString());

				#region Kiểm tra hạch toán hợp lệ của Tk_No
				if (drDmTkNo != null)
				{
					if ((bool)drDmTkNo["Tk_Dt"] && dr["Ma_Dt"].ToString() == "")
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk nợ yêu cầu Mã đối tượng" : "Debit account require Customer code";
						Common.MsgCancel(strMsg);
						return false;
					}
					if ((bool)drDmTkNo["Tk_Sp"] && dr["Ma_Vt_Sp"].ToString() == "")
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk nợ yêu cầu Mã sản phẩm" : "Debit account require Product code";
						Common.MsgCancel(strMsg);
						return false;
					}
					if ((bool)drDmTkNo["Tk_Km"] && dr["Ma_Km"].ToString() == "")
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk nợ yêu cầu Mã khoản mục" : "Debit account require Category code";
						Common.MsgCancel(strMsg);
						return false;
					}
				}
				#endregion

				#region Kiểm tra hạch toán hợp lệ của Tk_Co
				if (drDmTkCo != null)
				{
					if ((bool)drDmTkCo["Tk_Dt"] && dr["Ma_Dt"].ToString() == "")
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk có yêu cầu Mã đối tượng" : "Credit account require Customer code";
						Common.MsgCancel(strMsg);
						return false;
					}
					if ((bool)drDmTkCo["Tk_Sp"] && dr["Ma_Vt_Sp"].ToString() == "")
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk có yêu cầu Mã sản phẩm" : "Credit account require Product code";
						Common.MsgCancel(strMsg);
						return false;
					}
					if ((bool)drDmTkCo["Tk_Km"] && dr["Ma_Km"].ToString() == "")
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk có yêu cầu Mã khoản mục" : "Credit account require Category code";
						Common.MsgCancel(strMsg);
						return false;
					}
				}
				#endregion
                DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt.Text);
                if (strMa_Ct == "HD" && (string)dr["Stt_Org"] != string.Empty && (string)drDmDt["Tk_Cn"] != string.Empty && ((string)dr["Tk_No2"] != (string)drDmDt["Tk_Cn"]))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán TK Nợ không hợp lệ, khác TK Công nợ danh mục khách hàng" : "Transaction turnover invalid";
                    Common.MsgCancel(strMsg);
                    return false;
                }
                if ((string)dr["Tk_No2"] != (string)dr["Tk_No3"] && (string)dr["Tk_No3"] != string.Empty)
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán TK Nợ thuế không hợp lệ, khác Tk nợ, bạn có muốn tiếp tục không?" : "Transaction turnover invalid";
                    if(!Common.MsgYes_No(strMsg,"Y"))
                        return false;
                }
				if (dtEditCt.Columns.Contains("Tien2") && Convert.ToDouble(dr["Tien2"]) != 0 && ((string)dr["Tk_No2"] == string.Empty || (string)dr["Tk_Co2"] == string.Empty))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán doanh thu không hợp lệ" : "Transaction turnover invalid";
					Common.MsgCancel(strMsg);
					return false;
				}
				if (dtEditCt.Columns.Contains("Ma_Thue") && (string)dr["Ma_Thue"] != string.Empty && ((string)dr["Tk_No3"] == string.Empty || (string)dr["Tk_Co3"] == string.Empty))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán thuế không hợp lệ" : "Transaction VAT invalid";
					Common.MsgCancel(strMsg);
					return false;
				}
				// Phòng trường hợp phân bổ CK bị sai tiền VAT
				if (txtMa_Tte.Text == "VND" && Convert.ToDouble(dr["Tien4"]) > 0)
				{
					dr["Tien3"] = dr["Tien_Nt3"];
				}
				//kiểm tra tk 152 mà mã kho rỗng
				if(((string)dr["Ma_Kho"] == string.Empty || (string)dr["Ma_Kho"] == "") && (dr["Tk_Co"].ToString().StartsWith("15") || dr["Tk_Co2"].ToString().StartsWith("15")))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Nghiệp vụ liên quan đến kho phải có mã kho" : "Transaction turnover invalid";
					Common.MsgCancel(strMsg);
					return false;
				}
				if ((dr["Ma_Bp"] == "" || dr["Ma_Km"] == "") && Common.InlistLike(dr["Tk_No2"].ToString(), "64,62"))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chứng từ cần nhập mã bộ phận và mã khoản mục mới cho phép lưu" : "Do not register transaction type";
					Common.MsgCancel(strMsg);
					return false;
				}
				if ((Common.InlistLike(dr["Tk_No2"].ToString(), "000") && !Common.InlistLike(dr["Tk_Co2"].ToString(), "000")) ||
						(Common.InlistLike(dr["Tk_Co2"].ToString(), "000") && !Common.InlistLike(dr["Tk_No2"].ToString(), "000")))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Định khoản tài khoản 000 đối ứng phải là 000 " : "Do not register transaction type";
					Common.MsgCancel(strMsg);
					return false;
				}

				dr["Posted"] = this.drDmNvu["Posted"];
			}
            //Bằng tạm bỏ đi
            //if (!Voucher.CheckDuplicateInvoice(this))
            //    return false;

			return true;
		}
        public override void ExportFileExcel()
        {

            BindingSource bdsExport = new BindingSource();
            DataTable dtExport = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("MA_CT", strMa_Ct);
            ht.Add("STT", strStt);
            dtExport = SQLExec.ExecuteReturnDt("sp_rptPXHDExcel", ht, CommandType.StoredProcedure);

            bdsExport.DataSource = dtExport;
            dgvExport.DataSource = bdsExport;

            ExportControl = dgvExport;
            string strTitle = "hddt";
            RosyCommonTMN.CommonTMN.Export(ExportControl, strTitle, "", "FORM");

        }
		public override bool Save()
		{
			dtEditCt.AcceptChanges();

			Common.GatherMemvar(this, ref this.drEditPh);
			Voucher.Update_Detail(this);

			if (!FormCheckValid())
				return false;

            foreach (DataRow dr in dtEditCt.Rows)
            {
                if (txtMa_Tte.Text == "VND" && dr["Tien"] != dr["Tien_Nt"])
                    dr["Tien"] = dr["Tien_Nt"];
            }

			Voucher.Update_Log(this);
			Voucher.Update_TTien(this);
			Voucher.Update_Stt(this, strModule);

			if (!(bool)drEditPh["Duyet"]) //Trường hợp chứng từ chưa duyệt
			{
				if (dtEditPh.Columns.Contains("Ngay_Ct_Lap"))
				{
					drEditPh["Ngay_Ct_Lap"] = drEditPh["Ngay_Ct"];
					drEditPh["So_Ct_Lap"] = drEditPh["So_Ct"];
				}
			}

            if (Parameters.GetParaValue("HDDT").ToString() == "1" && strMa_Ct == "HD" && enuNew_Edit == enuEdit.New)
                So_Ct_HDDT();

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
					Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

				drEdit = drEditPh;
			}
            
			return Voucher.SQLUpdateCt(this);
		}

		private void Ma_Tte_Valid()
		{
			string strMa_Tte = txtMa_Tte.Text.Trim();

			if (Common.Inlist(this.strMa_Ct, (string)RosySystem.Library.Parameters.GetParaValue("CT_LOCKED_EXCHANGE")))
				numTy_Gia.Enabled = true;
			else
				numTy_Gia.Enabled = true;

			if (Element.sysMa_Tte == strMa_Tte)
			{
				numTy_Gia.Value = 1;
				numTy_Gia.Enabled = true;

				this.pnlTTien.Visible = false;
				this.pnlTTien_Nt.Left = this.pnlTTien.Right - this.pnlTTien_Nt.Width;

				if (dgvEditCt1.Columns.Contains("TIEN2"))
					dgvEditCt1.Columns["TIEN2"].Visible = false;

				if (dgvEditCt2.Columns.Contains("TIEN"))
					dgvEditCt2.Columns["TIEN"].Visible = false;

				if (dgvEditCt2.Columns.Contains("GIA"))
					dgvEditCt2.Columns["GIA"].Visible = false;
			}
			else
			{
				numTy_Gia.Enabled = true;

				if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange)
				{
					Hashtable ht = new Hashtable();
					ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
					ht.Add("MA_TTE", strMa_Tte);

					numTy_Gia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetTyGia", ht, CommandType.StoredProcedure));
				}

				this.pnlTTien.Visible = true;
				this.pnlTTien_Nt.Left = this.pnlTTien.Left - this.pnlTTien_Nt.Width;

				if (dgvEditCt1.Columns.Contains("TIEN2"))
					dgvEditCt1.Columns["TIEN2"].Visible = true;

				if (dgvEditCt2.Columns.Contains("TIEN"))
					dgvEditCt2.Columns["TIEN"].Visible = true;

				if (dgvEditCt2.Columns.Contains("GIA"))
					dgvEditCt2.Columns["GIA"].Visible = true;
			}

			if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange || numTy_Gia.bTextChange)
			{
				Voucher.Update_Detail(this);
				Voucher.Calc_Tien_All(this);
				Voucher.Adjust_TThue_Vat(this, true);

				if (txtMa_Tte.bTextChange)
					txtMa_Tte.bTextChange = false;
			}

			numTTien_Nt.Scale = numTTien_Nt0.Scale = numTTien_Nt3.Scale = numTTien_Nt4.Scale = strMa_Tte == Element.sysMa_Tte ? 0 : 2;

			Voucher.FormatTien_Nt_SO(dgvEditCt1, strMa_Tte);
			Voucher.FormatTien_Nt_SO(dgvEditCt2, strMa_Tte);

			dgvEditCt1.ResizeGridView();
			dgvEditCt2.ResizeGridView();
		}

		public void LockControl()
		{
			this.tabControl1.Enabled = false;
			this.txtMa_Hd.Enabled = false;
			this.txtMa_CTrinh.Enabled = false;
            //this.txtSo_QD.Enabled = false;
			this.txtMa_Kho_CalGia.Enabled = false;
            //this.txtHt_Tt.Enabled = false;
			this.txtPt_Vc.Enabled = false;
			if (strMa_Ct == "HDKG")// ||  == "HD05")
			{
				this.txtMa_CTrinh.Enabled = true;
				this.txtSo_QD.Enabled = true;
			}
		}

		private void Ma_Thue_Valid()
		{
			DataRow drEditCt = dtEditCt.Rows[0];

			string strMa_Thue = txtMa_Thue.Text;

			if (strMa_Thue == string.Empty)
			{
				txtTk_No3.Text = string.Empty;
				txtTk_Co3.Text = string.Empty;
				txtTen_DtGtgt.Text = string.Empty;
				txtMa_So_Thue.Text = string.Empty;

				txtTk_No3.Enabled = false;
				txtTk_Co3.Enabled = false;
				txtTen_DtGtgt.Enabled = false;
				//txtMa_So_Thue.Enabled = false;
				numTTien_Nt3.Enabled = false;
				numTTien3.Enabled = false;

				return;
			}
			else
			{
				txtTk_No3.Enabled = true;
				txtTk_Co3.Enabled = true;
				txtTen_DtGtgt.Enabled = true;
				//txtMa_So_Thue.Enabled = true;
				numTTien_Nt3.Enabled = true;
				numTTien3.Enabled = true;
			}

			DataRow drDmThue = DataTool.SQLGetDataRowByID("R81DmThue", "Ma_Thue", strMa_Thue);

			if (drDmThue != null)
			{
				if (txtMa_Thue.bTextChange)
				{
					//XỬ LÝ khi thanh điều chỉnh thuế VAT
					foreach (DataRow dr in dtEditCt.Rows)
					{
						if ((string)drDmCt["Nh_Ct"] == "1") //TL
						{
							dr["Tk_No3"] = (string)drDmThue["Tk"];
							dr["Tk_Co3"] = (string)drEditCt["Tk_Co2"];
						}
						else
                        {
							dr["Tk_No3"] = (string)drEditCt["Tk_No2"];
							dr["Tk_Co3"] = (string)drDmThue["Tk"];
						}
					}

					//if ((string)drDmCt["Nh_Ct"] == "1") //TL
					//{
					//	txtTk_No3.Text = (string)drDmThue["Tk"];
					//	txtTk_Co3.Text = (string)drEditCt["Tk_Co2"];
					//}
					//else //HĐ
					//{
					//	txtTk_No3.Text = (string)drEditCt["Tk_No2"];
					//	txtTk_Co3.Text = (string)drDmThue["Tk"];
					//}
				}
				else
				{
					foreach (DataRow dr in dtEditCt.Rows)
					{
						if ((string)drDmCt["Nh_Ct"] == "1") //TL
						{
							if (dr["Tk_No3"].ToString().Trim() == string.Empty)
								dr["Tk_No3"] = (string)drDmThue["Tk"];

							if (dr["Tk_Co3"].ToString().Trim() == string.Empty)
								dr["Tk_Co3"] = (string)drEditCt["Tk_Co2"];
						}
						else
                        {
							if (dr["Tk_No3"].ToString().Trim() == string.Empty)
								dr["Tk_No3"] = (string)drEditCt["Tk_No2"];

							if (dr["Tk_Co3"].ToString().Trim() == string.Empty)
								dr["Tk_Co3"] = (string)drDmThue["Tk"];
						}
					}
					//if ((string)drDmCt["Nh_Ct"] == "1") //TL
					//{
					//	if (txtTk_No3.Text.Trim() == string.Empty)
					//		txtTk_No3.Text = (string)drDmThue["Tk"];

					//	if (txtTk_Co3.Text.Trim() == string.Empty)
					//		txtTk_Co3.Text = (string)drEditCt["Tk_Co2"];
					//}
					//else //HĐ
					//{
					//	if (txtTk_No3.Text.Trim() == string.Empty)
					//		txtTk_No3.Text = (string)drEditCt["Tk_No2"];

					//	if (txtTk_Co3.Text.Trim() == string.Empty)
					//		txtTk_Co3.Text = (string)drDmThue["Tk"];
					//}
				}
			}

			string strMa_Dt = txtMa_Dt.Text;
			DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DmDt", "Ma_Dt", strMa_Dt);

			if (drDmDt != null)
			{
				if (txtMa_Thue.bTextChange)
				{
					txtTen_DtGtgt.Text = drDmDt["Ten_Dt"].ToString();
					txtMa_So_Thue.Text = drDmDt["Ma_So_Thue"].ToString();
				}
				else
				{
					if (txtTen_DtGtgt.Text.Trim() == string.Empty)
						txtTen_DtGtgt.Text = (string)drDmDt["Ten_Dt"];

					if (txtMa_So_Thue.Text.Trim() == string.Empty)
						txtMa_So_Thue.Text = (string)drDmDt["Ma_So_Thue"];
				}
			}

			return;
		}

		private bool CellKeyEnter()
		{//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc			

			if (dgvEditCt1.CurrentCell == null)
				return false;

			DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
			string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

			#region Enter tai Ten_Vt
			if (Common.Inlist(strCurrentColumn, "TEN_VT"))
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				if ((drCurrent["Ma_Vt"] == DBNull.Value || (string)drCurrent["Ma_Vt"] == string.Empty) && bdsEditCt.Count > 1)
				{
					bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;

					bdsEditCt.RemoveCurrent();
					//dtEditCt.AcceptChanges();

					if (bIsCurrentLastRow)
						this.SelectNextControl(dgvEditCt1, true, true, true, true);

					return true;
				}

				return false;
			}
			#endregion

			#region Enter tai TIEN_NT9
			if (Common.Inlist(strCurrentColumn, "TIEN_NT9"))
			{
				if (txtMa_Tte.Text.Trim() == Element.sysMa_Tte)
				{
					// Cap nhat tien TIEN_NT9 truoc khi xuong dong
					double dbTien_Nt9 = 0;
					if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien_Nt9))
					{
						dgvEditCt1.CancelEdit();
						drCurrent = ((DataRowView)bdsEditCt.Current).Row;
						drCurrent["TIEN_NT9"] = dbTien_Nt9;
						Voucher.Calc_So_Luong(drCurrent, this);
						Voucher.Update_TTien(this);
					}

					if (dgvEditCt1.bIsCurrentLastRow)
					{
						if (!Voucher.AddRow(this))
							this.SelectNextControl(dgvEditCt1, true, true, true, true);
						else
						{
							dgvEditCt1.FocusNextFirstCell();
							return true;
						}
					}
					else
						dgvEditCt1.FocusNextFirstCell();

				}
				return false;
			}

			#endregion

			#region Enter TIEN2
			if (Common.Inlist(strCurrentColumn, "TIEN2"))
			{
				if (dgvEditCt1.bIsCurrentLastRow)
				{
					// Cap nhat Tien2 truoc khi xuống dòng
					double dbTien2 = 0;
					if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien2))
					{
						dgvEditCt1.CancelEdit();
						drCurrent = ((DataRowView)bdsEditCt.Current).Row;
						drCurrent["TIEN2"] = dbTien2;
						Voucher.Calc_So_Luong(drCurrent, this);
						Voucher.Update_TTien(this);
					}

					if (!Voucher.AddRow(this))
						return false;
					else
						dgvEditCt1.FocusNextFirstCell();


					return true;
				}

				return false;
			}
			#endregion

			return false;
		}

		private void Auto_Cost_Change(DataGridViewRow dgvRow, bool bAuto_Cost)
		{
			if (bAuto_Cost)
			{
				dgvRow.Cells["TIEN_NT"].Value = 0;
				dgvRow.Cells["TIEN"].Value = 0;
				dgvRow.Cells["GIA_NT"].Value = 0;
				dgvRow.Cells["GIA"].Value = 0;

				dgvRow.Cells["TIEN_NT"].ReadOnly = false;
				dgvRow.Cells["TIEN"].ReadOnly = false;
				dgvRow.Cells["GIA_NT"].ReadOnly = false;
				dgvRow.Cells["GIA"].ReadOnly = false;
			}
			else
			{
				dgvRow.Cells["TIEN_NT"].ReadOnly = false;
				dgvRow.Cells["TIEN"].ReadOnly = false;
				dgvRow.Cells["GIA_NT"].ReadOnly = false;
				dgvRow.Cells["GIA"].ReadOnly = false;
			}
		}

        private void Phan_Bo_CK()
        {
            frmPhanBoCK frm = new frmPhanBoCK();
            frm.ShowDialog(); 

            if (frm.isAccept)
            {
                double dTTien4 = frm.numTTien4.Value * numTy_Gia.Value; 
                string strLoai_Pb = frm.txtLoai_Pb.Text;

                Voucher.Phan_Bo_Ck(this, dTTien4, strLoai_Pb);
				Voucher.Calc_So_Luong_All(this);
				Voucher.Calc_Tien_All(this);
				Voucher.Update_TTien(this);
				Voucher.Adjust_TThue_Vat(this, true);				
            }
        }
		private void TTien_Valid()
		{
			////numTTien0.Value = numTTien_Nt0.Value * numTy_Gia.Value;

			////if (numTTien3.Value == 0)
			////    numTTien3.Value = numTTien_Nt3.Value * numTy_Gia.Value;
			////else if (numTTien_Nt3.Value == 0 && numTy_Gia.Value != 0)
			////    numTTien_Nt3.Value = numTTien3.Value / numTy_Gia.Value;

			this.drEditPh["TTien0"] = numTTien0.Value;
			this.drEditPh["TTien_Nt0"] = numTTien_Nt0.Value;
			this.drEditPh["TTien3"] = numTTien3.Value;
			this.drEditPh["TTien_Nt3"] = numTTien_Nt3.Value;

			this.drEditPh["TTien"] = Convert.ToDouble(this.drEditPh["TTien0"]) + Convert.ToDouble(this.drEditPh["TTien3"]);
			this.drEditPh["TTien_Nt"] = Convert.ToDouble(this.drEditPh["TTien_Nt0"]) + Convert.ToDouble(this.drEditPh["TTien_Nt3"]);

			if (numTTien_Nt3.bTextChange || numTTien3.bTextChange)
				Voucher.Adjust_TThue_Vat(this, false);
		}

		private void InheritVoucher() //Kế thừa chứng từ từ phiếu khác
		{
			Voucher.Update_Header(this);
			Voucher.Update_Detail(this);
			if (Common.Inlist(strMa_Ct, "HD,HDKG,HDHH,HDXK"))
			{
				frmInheritVoucher frm = new frmInheritVoucher();
				frm.Load(this);

				if (frm.Is_Accept)
				{
					Voucher.InheritVoucher_SetData(frm, this);

					Voucher.Update_Detail(this);
					Voucher.Update_TTien(this);
					Voucher.Update_DmNvu(this);
					LoadDicName();
					Ma_Thue_Valid();
                    //if (Common.Inlist(strMa_Ct, "HD,HDKG,HDHH"))
                    //    LockControl();
				}

			}
			else
			{
				frmInheritVoucher frm = new frmInheritVoucher();
				frm.Load(this.drEditPh);

				if (frm.Is_Accept)
				{
					Voucher.InheritVoucher_SetData(frm, this);

					Voucher.Calc_So_Luong_All(this);
					Voucher.Update_Detail(this);
					Voucher.Update_TTien(this);
					Voucher.Adjust_TThue_Vat(this, true);			
					Voucher.Update_DmNvu(this);					
				}
			}
            LoadDicName();
		}


		#endregion

		#region Su kien

		#region FormEvent
        void btPhanbo_Click(object sender, EventArgs e)
        {
            this.Phan_Bo_CK();
        }

        void btTinhGia_Click(object sender, EventArgs e)
        {
            this.Calc_CsGia();
        }


        void numTTien4_Validated(object sender, EventArgs e)
        {
            if (numTTien_Nt4.bTextChange || numTTien4.bTextChange)
            {
                this.drEditPh["TTien_Nt4"] = numTTien_Nt4.Value;
                this.drEditPh["TTien4"] = numTTien4.Visible ? numTTien4.Value : numTTien_Nt4.Value;

                Voucher.Adjust_Chiet_Khau(this);
            }
        }
		void txtMa_Ct_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Ct.Text.Trim();
			bool bRequire = true;
			string strKey = "(Table_Ct = '" + (string)drDmCt["Table_Ct"] + "')";

			DataRow drLookup = Lookup.ShowLookup("Ma_Ct", strValue, bRequire, strKey);

			if (bRequire && drLookup == null)
			{
				txtMa_Ct.Text = strMa_Ct;
				e.Cancel = true;
				return;
			}

			this.strMa_Ct = txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();
			this.drDmCt = drLookup;

			//Tính lại Số chứng từ trong truờng hợp chọn lại Ma_Ct khác
			if (this.enuNew_Edit != enuEdit.Edit && txtMa_Ct.bTextChange)
			{
				txtSo_Ct.Text = Voucher.Cong_So_Ct(this);
				Voucher.Update_Detail(this, "So_Ct");
			}
		}

		void txtMa_Nvu_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nvu.Text.Trim();
			bool bRequire = true;
			string strFilter = "(CHARINDEX('" + strMa_Ct + "', Ma_Ct, 0) > 0) OR Ma_Ct = '*'";
			string strValid = "Ma_Ct <> ''";

			DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, strFilter, strValid);

			if (drLookup == null) //Bắt buộc phải nhập Ma_Nvu
			{
				e.Cancel = true;
				return;
			}

			this.drDmNvu = drLookup;

			txtMa_Nvu.Text = drLookup["Ma_Nvu"].ToString();
			lbtTen_Nvu.Text = drLookup["Ten_Nvu"].ToString();

			lblPosted.Visible = !(bool)drDmNvu["Posted"];

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEditPh["Duyet"] = (bool)drDmNvu["Default_Duyet"];

			//Ngầm định những nghiệp vụ có tính giá vốn
			if (dtEditCt.Columns.Contains("Auto_Cost") && (string)drDmCt["Nh_Ct"] == "2" && Convert.ToBoolean(drDmNvu["Default_AuToCost"]) == false)
				drCurrent["Auto_Cost"] = false;

			Voucher.Update_DmNvu(this); //Cập nhật chi tiết hạch toán ngầm định vào chứng từ
		}

		void btnImportExcel_Click(object sender, EventArgs e)
		{
			Voucher.ImportExcelCtVT(this);
		}

		void btHanTt_Click(object sender, EventArgs e)
		{
			Voucher.HanTt(this);
		}

		void btInherit_Click(object sender, EventArgs e)
		{
			this.InheritVoucher();
            
            if(strMa_Ct != "HDTL")
                numHan_TT.Value = Voucher.XuLyHanTt(drEditPh);
		}


		void txtSo_Ct_Validating(object sender, CancelEventArgs e)
		{
			if (txtSo_Ct.Text == string.Empty)
				return;

			string strTablePh = (string)drDmCt["Table_Ph"];
			string strSo_Ct = txtSo_Ct.Text;

			DateTime dNgay_Ct = Library.StrToDate(dteNgay_Ct.Text);

			string strSQLExec = "SELECT COUNT(Stt) FROM " + strTablePh + " WHERE Stt <> @Stt AND So_Ct = @So_Ct AND MONTH(Ngay_Ct) = MONTH(@Ngay_Ct) AND YEAR(Ngay_Ct) = @Nam AND Ma_Ct = @Ma_Ct AND Ma_DvCs = @Ma_DvCs";

			Hashtable ht = new Hashtable();
			ht.Add("MA_CT", strMa_Ct);
			ht.Add("SO_CT", strSo_Ct);
			ht.Add("NGAY_CT", dNgay_Ct);
			ht.Add("NAM", dNgay_Ct.Year);
			ht.Add("STT", drEditPh["Stt"]);
			ht.Add("MA_DVCS", Element.sysMa_DvCs);

			if (Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, ht, CommandType.Text)) > 0)
			{
				if (!Common.MsgYes_No("Chứng từ số: " + txtSo_Ct.Text + " Ngày: " + dteNgay_Ct.Text + " đã tồn tại.\n Bạn có muốn tiếp tục kô?"))
					e.Cancel = true;
			}
		}
		void txtSo_Ct_TextChanged(object sender, EventArgs e)
		{
			if (this.ActiveControl == txtSo_Ct && !Common.InlistLike(strMa_Ct, "HDTL"))
				txtSo_Ct0.Text = txtSo_Ct.Text;
		}
		private void TxtSo_Ct0_Validated(object sender, EventArgs e)
		{	
			if(Common.InlistLike(strMa_Ct, "HDTL"))
			{ 
				string strSo_Ct0 = txtSo_Ct0.Text;
				if (strSo_Ct0.Length < 8)
				{
					txtSo_Ct0.Text = Voucher.GetSoCt0(strSo_Ct0);

				}
			}
		}
		void dteNgay_Ct_Validating(object sender, CancelEventArgs e)
		{
			this.Ma_Tte_Valid();
			Common.GatherMemvar(this, ref drEditPh);
            
            if (strMa_Ct != "HDTL")
                numHan_TT.Value = Voucher.XuLyHanTt(drEditPh);
            
            if (strMa_Ct == "HD" && enuNew_Edit == enuEdit.New)
                So_Ct_HDDT();
		}
		void dteNgay_Ct_TextChanged(object sender, EventArgs e)
		{
			if (this.ActiveControl == dteNgay_Ct)
				dteNgay_Ct0.Text = dteNgay_Ct.Text;

            //if (strMa_Ct == "HD" && enuNew_Edit == enuEdit.New)
            //    So_Ct_HDDT();
		}

		void txtMa_Tte_Validating(object sender, CancelEventArgs e)
		{
			this.Ma_Tte_Valid();
		}
		void numTy_Gia_Leave(object sender, EventArgs e)
		{
			this.Ma_Tte_Valid();
		}

		void txtMa_Dt_Enter(object sender, EventArgs e)
		{
			//lbtTen_Dt.Text = dicName.GetValue(lbtTen_Dt.Name);
		}
		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
				txtDien_Giai.Text = "Xuất bán " + drLookup["Ten_Dt"].ToString();
				
				if(txtTen_Dt_Vc.Text ==string.Empty)
					txtTen_Dt_Vc.Text = drLookup["Ten_Dt_Vc"].ToString();
				
				if (txtMa_Dt.Text != (string)drEditPh["Ma_Dt"])
				{
					txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();

					if (drLookup["Dia_Chi"].ToString() != string.Empty)
						txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();

					//if (drLookup["Ma_Kv"].ToString() != string.Empty)
					//	txtMa_Kv.Text = drLookup["Ma_Kv"].ToString();

					//if (drLookup["Ma_Dt_CbNv"].ToString() != string.Empty)
					//	txtMa_Dt_CbNv.Text = drLookup["Ma_Dt_CbNv"].ToString();

                    if (drLookup["Ten_Dt"].ToString() != string.Empty)
                        txtTen_DtGtgt.Text = (string)drLookup["Ten_Dt"];

                    if (drLookup["Ma_So_Thue"].ToString() != string.Empty)
                        txtMa_So_Thue.Text = (string)drLookup["Ma_So_Thue"];
					
				}

				if (txtMa_Dt.Text != string.Empty)
				{
					txtMa_Hd.strLookupKeyFilter = " (Ma_Dt = '" + txtMa_Dt.Text + "')";
				}
			}

			Voucher.Update_Detail(this, "Ma_Dt");
		}
		void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv.Text = string.Empty;
				lbtTen_Dt_CbNv.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
			}
		}
		void txtMa_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Hd.Text.Trim();
			bool bRequire = false;
			string strKeyValid = "";
			string strKeyFilter = "Ma_Dt='" + txtMa_Dt.Text.ToString() + "'";

			DataRow drLookup = Lookup.ShowLookup("MA_HD", strValue, bRequire, strKeyFilter, strKeyValid);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Hd.Text = string.Empty;
				lbtTen_Hd.Text = string.Empty;
			}
			else
			{
				txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
				lbtTen_Hd.Text = Voucher.GetTenHd(txtMa_Hd.Text); //drLookup["Ten_Hd"].ToString();
                
				if(txtPt_Tt.Text == string.Empty)
					txtPt_Tt.Text = drLookup["Note"].ToString();
				
				if (txtMa_Hd.bTextChange)
				{
					txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
					DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", (string)drLookup["Ma_Dt"]);
					if (drDmDt != null)
					{
						lbtTen_Dt.Text = (string)drDmDt["Ten_Dt"];
						if ((string)drDmDt["Ong_Ba"] != string.Empty)
							txtOng_Ba.Text = (string)drDmDt["Ong_Ba"];
						else
							txtOng_Ba.Text = (string)drDmDt["Ten_Dt"];

						txtDia_Chi.Text = (string)drDmDt["Dia_Chi"];
					}
				}
			}
			//lbtNotice.Text = GetDuCuoi(txtMa_Dt.Text, txtMa_Hd.Text, "131");
			this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
		}

		//void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		//{
		//	string strValue = txtMa_Bp.Text.Trim();
		//	bool bRequire = false;

		//	DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

		//	if (bRequire && drLookup == null)
		//		e.Cancel = true;

		//	if (drLookup == null)
		//	{
		//		txtMa_Bp.Text = string.Empty;
		//		lbtTen_Bp.Text = string.Empty;
		//	}
		//	else
		//	{
		//		txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
		//		lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
		//	}
		//}


		void txtMa_Kho_Xuat_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho_CalGia.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho_CalGia.Text = string.Empty;
				
			}
			else
			{
				//txtMa_Kho_CalGia.Text = drLookup["Ma_Kho"].ToString();
				txtMa_Kho_CalGia.Text = drLookup["Ma_Kho"].ToString();
				
			}
			
		}


		


        void txtSo_QD_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_QD.Text.Trim();
            if (strValue == string.Empty)
                return;
            bool bRequire = false;
            string strKeyValid = "";
            string strKeyFilter = "(CHARINDEX('" + txtMa_Dt.Text.ToString() + "',Nhom_Dt) > 0 OR Nhom_Dt LIKE '%*')" +
								 " AND (CHARINDEX('" + txtMa_Kho_CalGia.Text.Trim() + "',Ma_Kho_List) > 0 OR Ma_Kho_List LIKE '%*')" +
                                  " AND Ma_CTrinh='" + txtMa_CTrinh.Text.Trim() + "' " +
								  " AND (Ngay_Het_Han >= '" + dteNgay_Ct.Text + "'  OR Ngay_Het_Han <='19000101')" +
                                  " AND Ngay_Qd <= '" + dteNgay_Ct.Text + "'";


            DataRow drLookup = Lookup.ShowLookup("So_Qd_Dt", strValue, bRequire, strKeyFilter, strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = false;

            if (drLookup == null)
            {
                txtSo_QD.Text = string.Empty;
                // lbtTen_Hd.Text = string.Empty;
            }
            else
            {
                txtSo_QD.Text = drLookup["So_QD"].ToString();
                txtMa_CTrinh.Text = drLookup["Ma_CTrinh"].ToString();
                //txtLoai_Gia.Text = drLookup["Loai_Gia"].ToString();
            }
            //if (enuNew_Edit == enuEdit.New)
            //    txtGhi_Chu_HD.Text = "QD: " + txtSo_QD.Text.Trim();
        }

        void txtMa_CTrinh_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_CTrinh.Text.Trim();
            bool bRequire = false;
            string strKeyValid = string.Empty;
            string strKeyFilter = string.Empty;
            //strKeyFilter = "Ma_Dt='" + drCurrent["Ma_Dt"].ToString()+"'  ";//+ "' AND So_QD='" + drCurrent["So_QD"].ToString() + "'

            DataRow drLookup = Lookup.ShowLookup("Ma_CTrinh", strValue, bRequire, strKeyFilter, strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_CTrinh.Text = string.Empty;
               // lbtTen_CTrinh.Text = string.Empty;
            }
            else
            {
                txtMa_CTrinh.Text = drLookup["Ma_CTrinh"].ToString();
               // lbtTen_CTrinh.Text = drLookup["Ten_Ctrinh"].ToString();
            }


        }

        void txtLoai_Gia_Validating(object sender, CancelEventArgs e)
        {

            bool bRequire = false;
            string strFilter = "Type='LOAI_GIA'";

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "LOAI_GIA");
            DataRow drLookup = Lookup.ShowLookup("LOAI_GIA", txtHt_Tt.Text, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                txtHt_Tt.Text = string.Empty;
            }
            else
            {
                txtHt_Tt.Text = drLookup["Type_ID"].ToString();
            }
            if (txtSo_QD.Text != "")
            {
                drCurrent["So_Qd"] = txtSo_QD.Text.Trim();
                drCurrent["HT_TT"] = txtHt_Tt.Text.Trim();
                drEditPh["HT_TT"] = txtHt_Tt.Text.Trim();
                this.Calc_CsGia();
            }
            if (strMa_Ct != "HDTL")
                numHan_TT.Value = Voucher.XuLyHanTt(drEditPh);
        }

        void txtPt_Vc_Validating(object sender, CancelEventArgs e)
        {
            bool bRequire = false;
            string strFilter = "Type='PT_VC'";

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "PT_VC");
            DataRow drLookup = Lookup.ShowLookup("PT_VC", txtPt_Vc.Text, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                txtPt_Vc.Text = string.Empty;
            }
            else
            {
                txtPt_Vc.Text = drLookup["Type_ID"].ToString();
            }
            if (txtSo_QD.Text != "")
            {
                drCurrent["So_Qd"] = txtSo_QD.Text.Trim();
                drCurrent["HT_TT"] = txtHt_Tt.Text.Trim();
                drCurrent["PT_VC"] = txtPt_Vc.Text.Trim();

                this.Calc_CsGia();
            }
        }

		private void Calc_CsGia()
		{
            if (txtSo_QD.Text.Trim() != "")
            {
               bool bXaLan = false;
                DateTime dteNgay_Kt_QD = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Het_Han) FROM R81DMQD WHERE So_Qd = '" + txtSo_QD.Text.Trim() + "'"));
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;
                string strXaLan = drCurrent["So_Xa_Lan_Tau"].ToString();
              
                if(strXaLan!= "")// nếu HD Xà Lan công thêm 7 ngày
                    dteNgay_Kt_QD = dteNgay_Kt_QD.Subtract(new TimeSpan(-7, 0, 0, 0)); 

                if (dteNgay_Kt_QD < Library.StrToDate(dteNgay_Ct.Text))
                {
                    Common.MsgOk("Ngày kết thúc của QD '" + txtSo_QD.Text.Trim() + "' đã kết thúc trước ngày ra hóa đơn. Vui lòng chọn số QD khác thay thế !");
                    txtSo_QD.Text = "";
                }
                else
                {
                    foreach (DataRow dr in dtEditCt.Rows)
                    {
                        if (dr.RowState == DataRowState.Deleted)
                            continue;

                        // check mã kho HD và mã Kho LXH
                        if(dr["Tk_Co"].ToString().StartsWith("1571"))
                        {
                            string strMa_Kho_LXH = SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Kho) FROM R04CTSO WHERE So_Ct = '"+ dr["So_LXH"].ToString() +"'").ToString();
                            if (strMa_Kho_LXH != txtMa_Kho_CalGia.Text)
                                Common.MsgOk("Tồn tại dòng LXH "+ dr["So_LXH"] +" mã vật tư "+ dr["Ma_Vt"] +" mã kho "+ strMa_Kho_LXH +" khác với mã kho tính giá!!! Không tính được giá");
                        }
                        if (dr["So_Xa_Lan_Tau"].ToString() != "")
                            bXaLan = true;

                        Hashtable htParameter = new Hashtable();

                        htParameter.Add("SO_QD", txtSo_QD.Text.Trim());
                        htParameter.Add("MA_KHO", (string)dr["Ma_Kho_CalGia"]);
                        htParameter.Add("MA_VT", (string)dr["Ma_Vt"]);
                        htParameter.Add("HT_TT", txtHt_Tt.Text.Trim());
                        htParameter.Add("PT_VC", txtPt_Vc.Text);
                        htParameter.Add("NGAY_CT", dr["Ngay_Ct"]);
                        htParameter.Add("IS_XALAN", bXaLan);
                        dr["Gia_Nt9"] = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalGia (@So_Qd, @Ma_Kho,@Ma_Vt, @Ht_Tt, @Pt_Vc, @Ngay_Ct, @Is_XaLan) ", htParameter, CommandType.Text));//tam bo SQLExec.ExecuteReturnValue("sp_GetCSGia", htParameter, CommandType.StoredProcedure);
                                         
                     

                    }
                }
            }
			Voucher.Calc_So_Luong_All(this);
			Voucher.Calc_Tien_All(this);
			Voucher.Update_TTien(this);
			Voucher.Adjust_TThue_Vat(this, true);

			this.Ma_Thue_Valid();
		}

		void txtMa_Thue_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Thue.Text;
			bool bRequire = false;

			string strMa_Thue_Old = drEditPh["Ma_Thue"] == DBNull.Value ? string.Empty : (string)drEditPh["Ma_Thue"];

			DataRow drLookup = Lookup.ShowLookup("Ma_Thue", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup != null)
			{
				txtMa_Thue.Text = (string)drLookup["Ma_Thue"];

				this.drEditPh["Thue_Gtgt"] = drLookup["Thue_Suat"];
			}

			this.Ma_Thue_Valid();

			Voucher.Update_Detail(this, "Ma_Thue, Thue_Gtgt");

			if (txtMa_Thue.bTextChange)
				Voucher.Adjust_TThue_Vat(this, true);
		}

		void txtMa_So_Thue_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_So_Thue.Text.Trim();

			bool bRequire = false;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;

			if (strValue == "/" || strValue == @"\")
			{
				DataRow drLookup = Lookup.ShowLookup("Ma_So_Thue", strValue, bRequire, "");

				if (bRequire && drLookup == null)
					e.Cancel = true;

				if (drLookup == null)
				{
					txtMa_So_Thue.Text = string.Empty;
				}
				else
				{
					txtMa_So_Thue.Text = drLookup["Ma_So_Thue"].ToString();
					txtTen_DtGtgt.Text = drLookup["Ten_Dt"].ToString();
				}
			}
			else if (strValue != string.Empty && txtMa_So_Thue.bTextChange)
			{
				DataTable dtLookup = SQLExec.ExecuteReturnDt("SELECT * FROM R81DmDt WHERE Ma_So_Thue = '" + strValue + "'");

				if (dtLookup != null)
				{
					if (dtLookup.Rows.Count == 1)
					{
						txtMa_So_Thue.Text = dtLookup.Rows[0]["Ma_So_Thue"].ToString();
						txtTen_DtGtgt.Text = dtLookup.Rows[0]["Ten_Dt"].ToString();
					}
					else
					{
						dtLookup = SQLExec.ExecuteReturnDt("SELECT * FROM R81DmDt WHERE Ma_So_Thue LIKE '" + strValue + "%'");

						if (dtLookup.Rows.Count >= 1)
						{
							DataRow drLookup = Lookup.ShowLookup("Ma_So_Thue", strValue, bRequire, "");

							if (bRequire && drLookup == null)
								e.Cancel = true;

							if (drLookup == null)
							{
								txtMa_So_Thue.Text = string.Empty;
							}
							else
							{
								txtMa_So_Thue.Text = drLookup["Ma_So_Thue"].ToString();
								txtTen_DtGtgt.Text = drLookup["Ten_Dt"].ToString();
							}
						}
						else
						{
							if (Common.MsgYes_No("Bạn có chắc chắn thêm mới đối tượng - mã số thuế?"))
							{
								DataRow drNew = dtLookup.NewRow();
								drNew["Ma_Dt"] = drNew["Ma_So_Thue"] = strValue;
								drNew["Ma_Nh_Dt"] = "MA_SO_THUE";

								RosyList.frmEdit frmEdit = (RosyList.frmEdit)Activator.CreateInstance(Type.GetType("RosyList.frmDmDt_Edit, Rosy.List", true));
								frmEdit.Load(enuEdit.New, drNew);

								if (frmEdit.isAccept)
								{
									txtMa_So_Thue.Text = (string)drNew["Ma_So_Thue"];
									txtTen_DtGtgt.Text = (string)drNew["Ten_Dt"];
								}
							}
						}
					}
				}
			}
		}

		void txtTk_No3_Enter(object sender, EventArgs e)
		{
			if (bdsEditCt.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;

			//if ((string)drCurrent["Ma_Thue"] != string.Empty)
			//    this.ucNotice.Text = Voucher.GetDuCuoi(drCurrent, txtTk_No3.Text);
		}
		void txtTk_No3_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_No3.Text.Trim();
			bool bRequire = txtMa_Thue.Text.Trim() == string.Empty ? false : true;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_No3.Text = string.Empty;
			}
			else
			{
				txtTk_No3.Text = drLookup["Tk"].ToString();
			}

			Voucher.Update_Detail(this, "Tk_No3");
		}

		void txtTk_Co3_Enter(object sender, EventArgs e)
		{
			if (bdsEditCt.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;

			//if ((string)drCurrent["Ma_Thue"] != string.Empty)
			//    this.ucNotice.Text = Voucher.GetDuCuoi(drCurrent, txtTk_Co3.Text);
		}
		void txtTk_Co3_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Co3.Text.Trim();
			bool bRequire = txtMa_Thue.Text.Trim() == string.Empty ? false : true;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Co3.Text = string.Empty;
			}
			else
			{
				txtTk_Co3.Text = drLookup["Tk"].ToString();
			}

			Voucher.Update_Detail(this, "Tk_Co3");
		}

		//void numChiet_Khau_Validating(object sender, CancelEventArgs e)
		//{
  //          if(numChiet_Khau.Value!=0)
  //              Voucher.Update_Detail(this, "Chiet_Khau");
		//	Voucher.Calc_Chiet_Khau_All(this);
		//}

		void frmEditCtTien_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Voucher.DeleteRow(this, dgvEditCt1);
					break;

				case Keys.F4:

					if (tabControl1.SelectedIndex == 0)
						tabControl1.SelectedIndex = 1;
					else
						tabControl1.SelectedIndex = 0;
					break;

				case Keys.Up:

					if (this.dgvEditCt1.Focused && this.dgvEditCt1.bIsCurrentFirstRow)
						this.SelectNextControl(dgvEditCt1, false, true, true, true);

					else if (this.dgvEditCt2.Focused && this.dgvEditCt2.bIsCurrentFirstRow)
						this.SelectNextControl(dgvEditCt2, false, true, true, true);

					break;

				case Keys.F10:
					this.InheritVoucher();
					break;

				case Keys.F11:
					this.btHanTt.PerformClick();
					break;

			}

			if (!this.dgvEditCt1.Focused)
				this.dgvEditCt1.ClearSelection();

			if (!this.dgvEditCt2.Focused)
				this.dgvEditCt2.ClearSelection();
		}

		void numTTien_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}
		void numTTien_Nt_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}
		void numTTien3_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}
		void numTTien_Nt3_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}

		#endregion

		#region DataGridViewEvent

		//Xu ly Notice
		void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;

			if (dgvEditCt.CurrentCell == null)
				return;

			if (this.ActiveControl != dgvEditCt)
				return;

			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "GIA_NT, GIA, TIEN_NT, TIEN") && strMa_Ct != "HDTL")
			{
				if ((bool)dgvEditCt.CurrentRow.Cells["AUTO_COST"].Value == true)
				{
					dgvCell.ReadOnly = false;
					//dgvCell.Value = 0;
				}
				else
					dgvCell.ReadOnly = false;
			}

			if (Common.Inlist(strColumnName, "MA_VT,MA_KHO"))
			{
				if ((string)drCurrent["Ma_Vt"] != string.Empty)
					this.lbtNotice.Text = Voucher.GetTonCuoi(drCurrent);

				dicName.SetValue("TON_CUOI", this.lbtNotice.Text);
			}
			else if (Common.Inlist(strColumnName, "TEN_VT,DVT"))
			{
				this.lbtNotice.Text = dicName.GetValue("TON_CUOI");
			}
			else if (Common.Inlist(strColumnName, "TK_NO, TK_CO, TK_NO3, TK_CO3,TK_NO2, TK_CO2, TK_NO4, TK_CO4"))
			{
				//tạm khóa vì quá lâu user ko có nhu cầu xem
				//if ((string)drCurrent[strColumnName] != string.Empty)
				//	this.lbtNotice.Text = Voucher.GetDuCuoi(drCurrent, (string)drCurrent[strColumnName]);
			}
			else if (dgvCell.Tag != null)
			{
				this.lbtNotice.Text = dgvCell.Value.ToString() + " - " + (string)dgvCell.Tag;
			}

			this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
		}

		//Cai dat Lookup
		void dgvEditCt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			//Xu ly phim Enter
			if (dgvEditCt.kLastKey == Keys.Enter)
			{
				dgvEditCt.kLastKey = Keys.None;

				if (this.CellKeyEnter())
					e.Cancel = true;
			}

			//Xu ly Lookup
			if (this.ActiveControl == null)
				return;

			//e.Cancel = true;

			if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;
				DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
				string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

				bool bLookup = true;

				if (Common.Inlist(strColumnName, "SO_XE"))
				{
					string strSo_Xe = dgvCell.FormattedValue.ToString().Trim();
					strSo_Xe = strSo_Xe.ToUpper();
					dgvEditCt.CancelEdit();
					dgvCell.Value = strSo_Xe;
				}


				if (Common.Inlist(strColumnName, "TK_NO,TK_CO,TK_NO2,TK_CO2,TK_NO3,TK_CO3"))
					bLookup = dgvLookupTk(ref dgvCell, strColumnName);

				else if (strColumnName == "MA_DT")
					bLookup = dgvLookupMa_Dt(ref dgvCell);

				else if (strColumnName == "MA_BP")
					bLookup = dgvLookupMa_Bp(ref dgvCell);

				else if (strColumnName == "MA_KM")
					bLookup = dgvLookupMa_Km(ref dgvCell);

				else if (strColumnName == "MA_VT_SP")
					bLookup = dgvLookupMa_Vt_Sp(ref dgvCell);

				else if (strColumnName == "MA_JOB")
					bLookup = dgvLookupMa_Job(ref dgvCell);

				else if (strColumnName == "MA_THUE")
					bLookup = dgvLookupMa_Thue(ref dgvCell);

				else if (strColumnName == "MA_VT")
					bLookup = dgvLookupMa_Vt(ref dgvCell);

				else if (strColumnName == "MA_KHO")
					bLookup = dgvLookupMa_Kho(ref dgvCell);

				if (bLookup == false)
					e.Cancel = true;
			}
			else
				dgvEditCt.CancelEdit();
		}

		//Cai dat cac ham tinh toan
		void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			//if (drCurrent[strColumnName].GetType() == typeof(decimal) && drCurrent[strColumnName, DataRowVersion.Original] == DBNull.Value)
			//    drCurrent.AcceptChanges();

			if (Common.Inlist(strColumnName, "SO_LUONG9"))
			{
				//Update_CSGia(drCurrent);

				if (!(bool)drCurrent["Auto_Cost"])
					Voucher.Calc_Tien_Von(drCurrent);
			}

			if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN2")) //,TIEN2
			{
				if (drCurrent.RowState == DataRowState.Added ||
					(drCurrent[strColumnName] != drCurrent[strColumnName, DataRowVersion.Original])) //Không cần phải Convert về Kiểu số để tính để tránh Original là NULL
				{
					Voucher.Calc_So_Luong(drCurrent, this);
					Voucher.Update_TTien(this);
					Voucher.Adjust_TThue_Vat(this, true);
				}

				//Kiểm tra tồn kho khi xuất hàng
				if ((string)drCurrent["Ma_Vt"] != string.Empty && (string)drCurrent["Ma_Kho"] != string.Empty &&
					(string)drDmCt["Nh_Ct"] == "2" && strColumnName == "SO_LUONG9")
				{
					double dbSo_Luong = Convert.ToDouble(drCurrent["So_Luong"]);
					double dbTon_Cuoi = 0;
					Voucher.GetTonCuoi(drCurrent, ref dbTon_Cuoi);

					if (dbSo_Luong > dbTon_Cuoi)
					{
						string strMsg = string.Empty;

						if (Element.sysLanguage == enuLanguageType.Vietnamese)
							strMsg = "Số lượng xuất: " + dbSo_Luong.ToString("N2") + " > số lượng tồn: " + dbTon_Cuoi.ToString("N2");
						else
							strMsg = "Out quantity: " + dbSo_Luong.ToString("N2") + " > closing inventory quantity: " + dbTon_Cuoi.ToString("N2");

						Common.MsgCancel(strMsg);
					}
				}

				//Tính giá vốn tức thời cho người dùng tham khảo
				if (enuNew_Edit != enuEdit.Edit && Collection.Parameters.ContainsKey("AUTO_GIA_BQTT") && Collection.Parameters["AUTO_GIA_BQTT"].ToString() == "1")
				{
					if ((bool)drCurrent["Auto_Cost"] && drCurrent["Ma_Vt"].ToString() != "" && drCurrent["Ma_Kho"].ToString() != "" && Convert.ToDouble(drCurrent["So_Luong"]) != 0)
					{
						Hashtable htPara = new Hashtable();
						htPara.Add("NGAY_CT", dteNgay_Ct.Text);
						htPara.Add("MA_KHO", drCurrent["Ma_Kho"]);
						htPara.Add("MA_VT", drCurrent["Ma_Vt"]);
						htPara.Add("STT", drCurrent["Stt"]);
						htPara.Add("MA_DVCS", Element.sysMa_DvCs);

						double dbTien_TT = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetTien_TT(@Ngay_Ct, @Ma_Kho, @Ma_Vt, @Stt, @Ma_DvCs)", htPara, CommandType.Text));
						double dbSL_TT = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSL_TT(@Ngay_Ct, @Ma_Kho, @Ma_Vt, @Stt, @Ma_DvCs)", htPara, CommandType.Text));
						double dbGia_TT = dbSL_TT != 0 ? Math.Round(dbTien_TT / dbSL_TT, 4) : 0;

						//HĐ: Cập nhật Giá tức thời vào [Gia_Nt], PX: Cập nhật Giá tức thời vào [Gia_Nt9]
						if (txtMa_Tte.Text == "VND")
							drCurrent["Gia_Nt"] = dbGia_TT;
						else
							drCurrent["Gia_Nt"] = Math.Round(dbGia_TT / numTy_Gia.Value, 4);

						Voucher.Calc_Tien_Von(drCurrent);
					}
				}
			}

			else if (Common.Inlist(strColumnName, "TIEN2"))
			{
				Voucher.Calc_Tien(drCurrent, this);
				Voucher.Update_TTien(this);
			}
			else if (Common.Inlist(strColumnName, "GIA_NT, GIA ,TIEN_NT, TIEN"))
			{
				if (!(bool)drCurrent["Auto_Cost"])
					Voucher.Calc_Tien_Von(drCurrent);
			}

			//if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN2"))
			//    drCurrent.AcceptChanges();

			bdsEditCt.EndEdit();//Cap nhat lai DataSource                   
		}

		void dgvEditCt_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;

			if (dgvEditCt.CurrentCell == null)
				return;

			if (this.ActiveControl != dgvEditCt)
				return;

			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (strColumnName == "MA_VT")
				this.bMa_Vt_Changed = true;

     
		}

		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)

				if (dgvEditCt1.CurrentCell.OwningColumn.DataPropertyName == "DVT")
				{
					drCurrent = ((DataRowView)bdsEditCt.Current).Row;
					string strMa_Vt = (string)drCurrent["Ma_Vt"];
					string strDvt_Old = (string)drCurrent["Dvt"];
					string strDvt_Chuan = string.Empty;

					DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", strMa_Vt);
					strDvt_Chuan = (string)drDmVt["Dvt"];

					string inputMask = (string)drDmVt["Dvt"];

					for (int i = 1; i <= 3; i++)
						inputMask += (string)drDmVt["Dvt" + i] == string.Empty ? string.Empty : "," + (string)drDmVt["Dvt" + i];

					if (inputMask != string.Empty)
						inputMask += "," + inputMask;
					if (inputMask == null || inputMask == string.Empty)
						return;

					string[] strArrInputMask = inputMask.Split(',');
					for (int i = 0; i <= strArrInputMask.Length - 1; i++)
						if (strArrInputMask[i] == strDvt_Old)
						{
							drCurrent["Dvt"] = strArrInputMask[i + 1];
							break;
						}

					if ((string)drCurrent["Dvt"] == strDvt_Chuan)
						drCurrent["He_So9"] = 1;
					else
						for (int i = 1; i <= 3; i++)
							if ((string)drDmVt["Dvt" + i] == (string)drCurrent["Dvt"])
								drCurrent["He_So9"] = drDmVt["He_So" + i];

					Voucher.Calc_So_Luong(drCurrent, this);
				}
		}

		#endregion

		#region DataGridViewLookup

		private bool dgvLookupTk(ref DataGridViewCell dgvCell, string strColumnName)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "Tk_Cuoi = 1");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Tk"].ToString();
				//dgvCell.Tag = drLookup["Ten_Tk"].ToString();                
			}

			return true;
		}

		private bool dgvLookupMa_Dt(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Dt"].ToString();
				dgvCell.Tag = drLookup["Ten_Dt"].ToString();
			}
			return true;
		}

		private bool dgvLookupMa_Bp(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Bp"].ToString();
				dgvCell.Tag = drLookup["Ten_Bp"].ToString();
			}

			return true;
		}

		private bool dgvLookupMa_Km(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;
			object objReturn = null;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strTk_No = (string)drCurrent["Tk_No"];
			string strTk_Co = (string)drCurrent["Tk_Co"];

			objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM R81DMTK WHERE Tk = '" + strTk_No + "'");
			if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
				bRequire = true;
			else
			{
				objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM R81DMTK WHERE Tk = '" + strTk_Co + "'");
				if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
					bRequire = true;
			}

			DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Km"].ToString();
				dgvCell.Tag = drLookup["Ten_Km"].ToString();
			}
			return true;
		}

		private bool dgvLookupMa_Vt_Sp(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;
			object objReturn = null;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strTk_No = (string)drCurrent["Tk_No"];
			string strTk_Co = (string)drCurrent["Tk_Co"];

			objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Sp FROM R81DMTK WHERE Tk = '" + strTk_No + "'");
			if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
				bRequire = true;
			else
			{
				objReturn = SQLExec.ExecuteReturnValue("SELECT Tk_Sp FROM R81DMTK WHERE Tk = '" + strTk_Co + "'");
				if (objReturn != null && objReturn != DBNull.Value && (bool)objReturn)
					bRequire = true;
			}

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();
			}
			return true;
		}

		private bool dgvLookupMa_Job(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Job", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Job"].ToString();
				dgvCell.Tag = drLookup["Ten_Job"].ToString();
			}
			return true;
		}

		private bool dgvLookupMa_Thue(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Thue", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
				drCurrent["Thue_GtGt"] = 0;
			}
			else
			{
				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Thue"].ToString();
				dgvCell.Tag = drLookup["Ten_Thue"].ToString();
				drCurrent["Thue_GtGt"] = Convert.ToInt32(drLookup["Thue_Suat"]);
			}
			return true;
		}

		private bool dgvLookupMa_Vt(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				string strMa_Vt_Old = string.Empty;

				if (drCurrent.HasVersion(DataRowVersion.Original))
					strMa_Vt_Old = drCurrent["Ma_Vt", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt", DataRowVersion.Original];
				else
					strMa_Vt_Old = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];

				string strMa_Vt = (string)drLookup["Ma_Vt"];

				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				if (strMa_Vt != strMa_Vt_Old)
				{

					drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];
					drCurrent["Dvt"] = drLookup["Dvt"];
					drCurrent["He_So9"] = 1;
					
					this.Calc_CsGia();
	
					//drCurrent["So_QD"] = txtSo_QD.Text;
					//drCurrent["HT_TT"] = txtHt_Tt.Text;
					//drCurrent["PT_VC"] = txtPt_Vc.Text;

					//Voucher.Update_CSGia(drCurrent); //Cap nhat lai CS Gia khi sua Ma_Vt
					//Voucher.Calc_So_Luong(drCurrent, this);

					////if (strMa_Ct == "TL")//TL
					//if ((string)drDmCt["Nh_Ct"] == "1")
					//{
					//    drCurrent["Tk_No"] = drLookup["Tk_VTu"];
					//    drCurrent["Tk_Co"] = drLookup["Tk_GVon"];
					//    drCurrent["Tk_No2"] = drLookup["Tk_Hbtl"];
					//}
					//else//HD
					//{
					//    drCurrent["Tk_No"] = drLookup["Tk_Gvon"];
					//    drCurrent["Tk_Co"] = drLookup["Tk_Vtu"];
					//    drCurrent["Tk_Co2"] = drLookup["Tk_Dthu"];
					//}
				}
				else
				{
					if (drCurrent["Ten_Vt"] == DBNull.Value || (string)drCurrent["Ten_Vt"] == string.Empty)
						drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

					if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
						drCurrent["Dvt"] = drLookup["Dvt"];

					//if (strMa_Ct == "TL")//TL
					if ((string)drDmCt["Nh_Ct"] == "1")
					{
						//if (drCurrent["Tk_No"] == DBNull.Value || (string)drCurrent["Tk_No"] == string.Empty)
						//    drCurrent["Tk_No"] = drLookup["Tk_VTu"];

						//if (drCurrent["Tk_Co"] == DBNull.Value || (string)drCurrent["Tk_Co"] == string.Empty)
						//    drCurrent["Tk_Co"] = drLookup["Tk_Gvon"];

						//if (drCurrent["Tk_No2"] == DBNull.Value || (string)drCurrent["Tk_No2"] == string.Empty)
						//    drCurrent["Tk_No2"] = drLookup["Tk_HBTL"];
					}
					else//HD
					{
						//if (drCurrent["Tk_No"] == DBNull.Value || (string)drCurrent["Tk_No"] == string.Empty)
						//    drCurrent["Tk_No"] = drLookup["Tk_Gvon"];

						//if (drCurrent["Tk_Co"] == DBNull.Value || (string)drCurrent["Tk_Co"] == string.Empty)
						//    drCurrent["Tk_Co"] = drLookup["Tk_VTu"];

						//if (drCurrent["Tk_Co2"] == DBNull.Value || (string)drCurrent["Tk_Co2"] == string.Empty)
						//    drCurrent["Tk_Co2"] = drLookup["Tk_DThu"];
					}
				}
			}
			return true;
		}

		private bool dgvLookupMa_Kho(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Kho"].ToString();
				dgvCell.Tag = drLookup["Ten_Kho"].ToString();
			}
			return true;
		}

		#endregion

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			
			this.DataGridView_Language();
			
			this.dgvEditCt1.ClearSelection(); //Chi co tac dung sau khi show form

			cboSaveOption.Items.Clear();
            cboSaveOption.Items.AddRange(new string[] { "1-Lưu & Nhập tiếp", "2-Lưu & Đóng lại", "3-Lưu - In & Nhập tiếp", "4-Lưu - In & Đóng lại", "5-In & Nhập tiếp", "6-In & Đóng lại", "8-Lưu - Xuất Excel & Đóng lại" });

			if (enuNew_Edit == enuEdit.Edit)
			{
				cboSaveOption.SelectedIndex = 1;
			}
			else
			{               
                if (Common.GetBufferValue("Voucher_Save_Option") != null && Common.GetBufferValue("Voucher_Save_Option").ToString().Length > 0)
                    cboSaveOption.SelectedIndex = int.Parse(Common.GetBufferValue("Voucher_Save_Option").Substring(0, 1)) - 1;
                else
                    cboSaveOption.SelectedIndex = 0;
               
			}

			if (this.enuNew_Edit == enuEdit.Edit)
			{
				if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]))
				{
					this.dteNgay_Ct.Enabled = false;
					this.btgAccept.btAccept.Enabled = false;
				}
                if ((bool)drEditPh["HDDTDaTao"] || (bool)drEditPh["Duyet_Huy"])
                {
                    
                    this.btgAccept.btAccept.Enabled = false;
                }
				Voucher.HanTt_LockCt(this);

				if (!Element.sysIs_Admin)
				{
					string strCreate_User = (string)drEditPh["Create_Log"];

					if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
					{
						string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

						if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
						{
							if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
							{
								this.btgAccept.btAccept.Enabled = false;
								return;
							}
						}
					}
				}
			}
		}

        //private void txtTen_Dt_Vc_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}
