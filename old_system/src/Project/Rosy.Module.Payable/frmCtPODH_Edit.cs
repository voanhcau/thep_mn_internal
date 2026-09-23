using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Public;
using RosySystem.Common;
using RosySystem.Customize;

namespace RosyModule.Payable
{
	public partial class frmCtPODH_Edit : frmVoucher_Edit
	{
		private string strModule = "04";
		private bool bMa_Vt_Changed = false;
		private bool bMa_Thue_Changed = false;
        DataTable dtDuCuoi;
		
        #region Contructor

		public frmCtPODH_Edit()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

			this.btImportExcel.Click += new EventHandler(btnImportExcel_Click);

			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);	
			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtSo_Qd.Validating += TxtSo_Qd_Validating;
			//txtMa_Kv.Validating += new CancelEventHandler(txtMa_Kv_Validating);
			btInherit.Click += new EventHandler(btInherit_Click);
			btInheritPOCG.Click += BtInheritPOCG_Click;
			txtMa_Tte.Leave += new EventHandler(txtMa_Tte_Leave);
			numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);

			txtMa_Thue.Validating += new CancelEventHandler(txtMa_Thue_Validating);

			numTTien.Validated += new EventHandler(numTTien_Validated);
			numTTien_Nt.Validated += new EventHandler(numTTien_Nt_Validated);
			numTTien3.Validated += new EventHandler(numTTien3_Validated);
			numTTien_Nt3.Validated += new EventHandler(numTTien_Nt3_Validated);

			dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
			dgvEditCt1.CellValueChanged += new DataGridViewCellEventHandler(dgvEditCt1_CellValueChanged);
			dgvEditCt1.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);
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

			if (enuNew_Edit == enuEdit.New)
				this.strStt = Common.GetNewStt(strModule, true);
			else
				this.strStt = drEdit["Stt"].ToString();

			this.Build();
			this.FillData();
			this.Init_Ct();

			Common.ScaterMemvar(this, ref drEditPh);


			txtMa_Tte.bTextChange = false;
			numTy_Gia.bTextChange = false;

			this.BindingLanguage();
			this.LoadDicName();

			
			this.Ma_Tte_Valid();
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

			dgvEditCt_TauHang.bSortMode = false;
			dgvEditCt_TauHang.strZone = "NM_EDIT_TAUHANG";
			dgvEditCt_TauHang.BuildGridView();

			dgvEditCt_QuyCach.bSortMode = false;
			dgvEditCt_QuyCach.strZone = "NM_EDIT_QUYCACH";
			dgvEditCt_QuyCach.BuildGridView();

			dgvEditCt_TapChat.bSortMode = false;
			dgvEditCt_TapChat.strZone = "NM_EDIT_TAPCHAT";
			dgvEditCt_TapChat.BuildGridView();

			dgvEditCt_KN.bSortMode = false;
			dgvEditCt_KN.strZone = "NM_EDIT_KN";
			dgvEditCt_KN.BuildGridView();

			if (dgvEditCt1.Columns.Contains("MA_VT"))
				((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;

			if (dgvEditCt1.Columns.Contains("MA_DT"))
				((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Dt"]).bUseAutoDropDown = true;

			DataGridView_Language();
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

			dgvEditCt_TauHang.DataSource = bdsEditCt;
			dgvEditCt_TauHang.ClearSelection();

			dgvEditCt_QuyCach.DataSource = bdsEditCt;
			dgvEditCt_QuyCach.ClearSelection();

			dgvEditCt_TapChat.DataSource = bdsEditCt;
			dgvEditCt_TapChat.ClearSelection();

			dgvEditCt_KN.DataSource = bdsEditCt;
			dgvEditCt_KN.ClearSelection();
		}

		private void DataGridView_Language()
		{
			if (dgvEditCt_TauHang.Columns.Contains("NGAY_DKGH"))
				dgvEditCt_TauHang.Columns["NGAY_DKGH"].HeaderText = "Ngày ship theo Shipment theo HD";

			if (dgvEditCt_TauHang.Columns.Contains("NGAY_DK"))
				dgvEditCt_TauHang.Columns["NGAY_DK"].HeaderText = "Ngày dự kiến cập cảng";

			if (dgvEditCt_TauHang.Columns.Contains("NGAY_SHIP_TT"))
				dgvEditCt_TauHang.Columns["NGAY_SHIP_TT"].HeaderText = "Ngày ship theo Shipment thực tế";

			if (dgvEditCt_TauHang.Columns.Contains("THOI_GIAN_DAT_HANG"))
				dgvEditCt_TauHang.Columns["THOI_GIAN_DAT_HANG"].HeaderText = "Thời gian hàng về";

			if (Common.Inlist(strMa_Ct, "BBPL,BBNL"))
			{
				dgvEditCt1.Columns["So_PCan"].HeaderText = "Số phiếu cân";
				dgvEditCt1.Columns["So_Luong0"].HeaderText = "KL hàng hóa";

				if (Common.Inlist(strMa_Ct, "BBPL"))
				{
					dgvEditCt1.Columns["Ty_Le4"].HeaderText = "Tỷ lệ PL đặc biệt";
					dgvEditCt1.Columns["So_Luong4"].HeaderText = "Khối lượng PL đặc biệt";
					dgvEditCt1.Columns["Gia_Ncc4"].HeaderText = "Giá PL đặc biệt";

					dgvEditCt1.Columns["Ty_Le1"].HeaderText = "Tỷ lệ PL loại 1";
					dgvEditCt1.Columns["So_Luong1"].HeaderText = "Khối lượng PL loại 1";
					dgvEditCt1.Columns["Gia_Ncc1"].HeaderText = "Giá PL loại 1";

					dgvEditCt1.Columns["Ty_Le2"].HeaderText = "Tỷ lệ PL loại 2";
					dgvEditCt1.Columns["So_Luong2"].HeaderText = "Khối lượng PL loại 2";
					dgvEditCt1.Columns["Gia_Ncc2"].HeaderText = "Giá PL loại 2";

					dgvEditCt1.Columns["Ty_Le3"].HeaderText = "Tỷ lệ PL loại 3";
					dgvEditCt1.Columns["So_Luong3"].HeaderText = "Khối lượng PL loại 3";
					dgvEditCt1.Columns["Gia_Ncc3"].HeaderText = "Giá PL loại 3";

					dgvEditCt1.Columns["Ty_Le5"].HeaderText = "Tỷ lệ gang";
					dgvEditCt1.Columns["So_Luong5"].HeaderText = "Khối lượng gang";
					dgvEditCt1.Columns["Gia_Ncc5"].HeaderText = "Giá gang";

					dgvEditCt1.Columns["So_Luong9"].HeaderText = "Tổng khối lượng";
					dgvEditCt1.Columns["Tien_Nt9"].HeaderText = "Tổng tiền";

					dgvEditCt1.Columns["Gia_Ncc1"].ReadOnly = true;
					dgvEditCt1.Columns["Gia_Ncc2"].ReadOnly = true;
					dgvEditCt1.Columns["Gia_Ncc3"].ReadOnly = true;
					dgvEditCt1.Columns["Gia_Ncc4"].ReadOnly = true;
					dgvEditCt1.Columns["Gia_Ncc5"].ReadOnly = true;
				}
				else
				{
					lbtSo_Qd.Text = "Số PO";

					numTSo_Luong1.Visible = false;
					numTSo_Luong2.Visible = false;
					numTSo_Luong3.Visible = false;
					numTSo_Luong4.Visible = false;
					rsLabel10.Visible = false;
					rsLabel4.Visible = false;
					rsLabel7.Visible = false;
					rsLabel9.Visible = false;
				}
				drEdit["Ma_Dt_CbNv"] = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
				txtMa_Dt_CbNv.Text = drEdit["Ma_Dt_CbNv"].ToString();
				lbtTen_Dt_CbNv.Text = drEdit["Ten_Dt_CbNv"].ToString();

				tabControl1.TabPages.Remove(tabPage2);
				tabControl1.TabPages.Remove(tabPage3);
				tabControl1.TabPages.Remove(tabPage4);
				tabControl1.TabPages.Remove(tabPage5);
				tabControl1.TabPages.Remove(tabPage6);
			}
		}

		private void InheritVoucher() //Kế thừa chứng từ từ phiếu khác
		{
			Voucher.Update_Header(this);
			Voucher.Update_Detail(this);

			frmInheritVoucher frm = new frmInheritVoucher();
			frm.Load(this);

			if (frm.Is_Accept)
			{
				Voucher.InheritVoucher_SetData(frm, this);

				Voucher.Update_Detail(this);
				Voucher.Update_TTien(this);
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
				if (this.enuNew_Edit == enuEdit.New)
				{
					//Ngầm định 1 số thông tin từ chứng từ cũ
					if (drEdit != null)
						Common.CopyDataRow(drEdit, drCurrent, (string)drDmCt["Carry_Header"]);

					drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;
					drCurrent["Stt"] = strStt;
					drCurrent["Ma_Ct"] = strMa_Ct;
					drCurrent["Ngay_Ct"] = Voucher.GetDate_Server(); //drEdit["Ngay_Ct"] != DBNull.Value ? drEdit["Ngay_Ct"] : DateTime.Now;
					drCurrent["Ma_Tte"] = Element.sysMa_Tte;
					drCurrent["Ty_Gia"] = 1;
					drCurrent["Stt0"] = 1;
					drCurrent["Deleted"] = false;

					//Clear Content in drEditPh
					foreach (DataColumn dcEditPh in dtEditPh.Columns)
						drEditPh[dcEditPh] = DBNull.Value;

					drEditPh["Ma_DvCs"] = drCurrent["Ma_DvCs"];
					drEditPh["Stt"] = drCurrent["Stt"];
					drEditPh["Ma_Ct"] = drCurrent["Ma_Ct"];
					drEditPh["Ngay_Ct"] = drCurrent["Ngay_Ct"];
					drEditPh["So_Ct"] = drCurrent["So_Ct"];
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
				drEditPh["So_Ct"] = drCurrent["So_Ct"] = Voucher.Cong_So_Ct_PYC(this);
				
			}
			//ẩn cột giá tiền nếu là nhân viên KCS
			if (!Element.sysIs_Admin && 
				((DataTool.SQLGetNameByCode("R00MEMBERGROUP","Member_ID","Member_Group_ID", Element.sysUser_Id) == "KCSLIEU") ||
				DataTool.SQLGetNameByCode("R00MEMBERGROUP", "Member_ID", "Member_Group_ID", Element.sysUser_Id) == "PQLCL"))
			{
                dgvEditCt1.Columns["GIA_NCC1"].Visible = false;
                dgvEditCt1.Columns["GIA_NCC2"].Visible = false;
                dgvEditCt1.Columns["GIA_NCC3"].Visible = false;
                dgvEditCt1.Columns["GIA_NCC4"].Visible = false;
				dgvEditCt1.Columns["GIA_NCC5"].Visible = false;
				dgvEditCt1.Columns["TIEN_NT9"].Visible = false;

				txtSo_Qd.Visible = false;
				numTTien_Nt0.Visible = numTTien_Nt3.Visible = numTTien_Nt.Visible = false;
			}
			//
			Voucher.Update_Header(this);
			Voucher.Update_Stt(this, strModule);
			
			
			if (dgvEditCt1.Columns.Contains("Dvt"))
				dgvEditCt1.Columns["Dvt"].ReadOnly = true;

			//BindingTTien
			numTTien0.DataBindings.Clear();
			numTTien3.DataBindings.Clear();
			numTTien.DataBindings.Clear();

			numTTien_Nt0.DataBindings.Clear();
			numTTien_Nt3.DataBindings.Clear();
			numTTien_Nt.DataBindings.Clear();
			numTSo_Luong.DataBindings.Clear();
			numTSo_Luong1.DataBindings.Clear();
			numTSo_Luong2.DataBindings.Clear();
			numTSo_Luong3.DataBindings.Clear();
			numTSo_Luong4.DataBindings.Clear();

			numTTien0.DataBindings.Add("Value", dtEditPh, "TTien0");
			numTTien3.DataBindings.Add("Value", dtEditPh, "TTien3");
			numTTien.DataBindings.Add("Value", dtEditPh, "TTien");

			numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien_Nt0");
			numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien_Nt3");
			numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");
			numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");

			numTSo_Luong1.DataBindings.Add("Value", dtEditPh, "TSo_Luong1");
			numTSo_Luong2.DataBindings.Add("Value", dtEditPh, "TSo_Luong2");
			numTSo_Luong3.DataBindings.Add("Value", dtEditPh, "TSo_Luong3");
			numTSo_Luong4.DataBindings.Add("Value", dtEditPh, "TSo_Luong4");
		}

		private void LoadDicName()
		{
			txtMa_Dt.bUseAutoDropDown = true;
			txtMa_Hd.bUseAutoDropDown = true;

			//txtMa_Nvu
			if (txtMa_Nvu.Text.Trim() != string.Empty)
				lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim());
			else
				lbtTen_Nvu.Text = string.Empty;

			//txtMa_Dt
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;
			
			//txtMa_Dt_CbNv
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
			{
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			}
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

			//txtMa_DDH
			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				lbtTen_Hd.Text = DataTool.SQLGetNameByCode("R81DmHd", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			}
			else
				lbtTen_Hd.Text = string.Empty;

			//Log
			string strCreate_Log = Common.Show_Log((string)drEditPh["Create_Log"]);
			string strLastModify_Log = Common.Show_Log((string)drEditPh["LastModify_Log"]);
			string strLog = string.Empty;
			strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
			strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";

			this.lblLog.Text = strLog;
		}
		
		private bool FormCheckValid()
		{
			if (!Common.CheckDataLocked(Library.StrToDate(this.dteNgay_Ct.Text)))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Dữ liệu đã bị khóa" : "Data have been locked";
				Common.MsgCancel(strMsg);
				return false;
			}

			if (txtMa_Nvu.Text == string.Empty)
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa khai báo mã nghiệp vụ" : "Do not register transaction type";
				Common.MsgCancel(strMsg);
				return false;
			}
			if (txtSo_Qd.Text == string.Empty && strMa_Ct == "BBNL")
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Phiếu chưa kế thừa dữ liệu bảng chào giá (POCG)" : "Do not register transaction type";
				Common.MsgCancel(strMsg);
				return false;
			}
			//Kiểm tra nghiệp vụ hợp lệ
			foreach (DataRow dr in dtEditCt.Rows)
			{
				if ((bool)dr["Deleted"])
					continue;

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
			}
			return true;
		}

		public override bool Save()
		{
			Common.GatherMemvar(this, ref this.drEditPh);
			Voucher.Update_Detail(this);

			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
			{
				drEditPh["Create_Log"] = Common.GetCurrent_Log();
				drEditPh["LastModify_Log"] = string.Empty;
			}
			else
			{
				drEditPh["LastModify_Log"] = Common.GetCurrent_Log();
				if ((string)drEditPh["Create_Log"] == string.Empty)
					drEditPh["Create_Log"] = drEditPh["LastModify_Log"];
			}

			Voucher.Update_TTien(this);
			Voucher.Update_Stt(this, strModule);
			Voucher.UpdateSo_Ct(this);

			if (!(bool)drEditPh["Duyet"]) //Trường hợp chứng từ chưa duyệt
			{
				if (dtEditPh.Columns.Contains("Ngay_Ct_Lap"))
				{
					drEditPh["Ngay_Ct_Lap"] = drEditPh["Ngay_Ct"];
					drEditPh["So_Ct_Lap"] = drEditPh["So_Ct"];
				}
			}

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
			string strMa_Tte_Old = (string)drEditPh["Ma_Tte"];

			if (Element.sysMa_Tte == strMa_Tte)
			{
				numTy_Gia.Value = 1;
				numTy_Gia.Enabled = false;

				this.pnlTTien.Visible = false;
				this.pnlTTien_Nt.Left = this.pnlTTien.Right - this.pnlTTien_Nt.Width;

				if (dgvEditCt1.Columns.Contains("TIEN"))
					dgvEditCt1.Columns["TIEN"].Visible = false;				
			}
			else
			{
				numTy_Gia.Enabled = true;

				if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange)
				{
					Hashtable ht = new Hashtable();
					ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
					ht.Add("MA_TTE", strMa_Tte);

					if (dgvEditCt1.Columns.Contains("TIEN"))
						dgvEditCt1.Columns["TIEN"].Visible = true;	

					numTy_Gia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetTyGia", ht, CommandType.StoredProcedure));
				}

				this.pnlTTien.Visible = true;
				this.pnlTTien_Nt.Left = this.pnlTTien.Left - this.pnlTTien_Nt.Width;				
			}

			numTTien_Nt.Scale = numTTien_Nt0.Scale = numTTien_Nt3.Scale = strMa_Tte == Element.sysMa_Tte ? 0 : 2;

			Voucher.FormatTien_Nt(dgvEditCt1, strMa_Tte);

			dgvEditCt1.ResizeGridView();			
		}

		private bool CellKeyEnter()
		{//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc			

			if (dgvEditCt1.CurrentCell == null)
				return false;

			DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
			string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

			#region Enter tai TEN_VT
			if (Common.Inlist(strCurrentColumn, "TEN_VT"))
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				if (drCurrent["Ma_Vt"] == DBNull.Value || (string)drCurrent["Ma_Vt"] == string.Empty)
				{
					bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;

					bdsEditCt.RemoveCurrent();
					dtEditCt.AcceptChanges();

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

			#region Enter TIEN
			if (Common.Inlist(strCurrentColumn, "TIEN"))
			{
				if (dgvEditCt1.bIsCurrentLastRow)
				{
					// Cap nhat Tien truoc khi xuống dòng
					double dbTien = 0;
					if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien))
					{
						dgvEditCt1.CancelEdit();
						drCurrent = ((DataRowView)bdsEditCt.Current).Row;
						drCurrent["TIEN"] = dbTien;
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
		
		private void TTien_Valid()
		{
			numTTien0.Value = numTTien_Nt0.Value * numTy_Gia.Value;

			if (numTTien3.Value == 0)
				numTTien3.Value = numTTien_Nt3.Value * numTy_Gia.Value;
			else if (numTTien_Nt3.Value == 0 && numTy_Gia.Value != 0)
				numTTien_Nt3.Value = numTTien3.Value / numTy_Gia.Value;

			this.drEditPh["TTien0"] = numTTien0.Value;
			this.drEditPh["TTien_Nt0"] = numTTien_Nt0.Value;
			this.drEditPh["TTien3"] = numTTien3.Value;
			this.drEditPh["TTien_Nt3"] = numTTien_Nt3.Value;

			this.drEditPh["TTien"] = Convert.ToDouble(this.drEditPh["TTien0"]) + Convert.ToDouble(this.drEditPh["TTien3"]);
			this.drEditPh["TTien_Nt"] = Convert.ToDouble(this.drEditPh["TTien_Nt0"]) + Convert.ToDouble(this.drEditPh["TTien_Nt3"]);

			Voucher.Adjust_TThue_Vat(this);
		}

		#endregion
			
		#region Su kien

		#region FormEvent		

		void btnImportExcel_Click(object sender, EventArgs e)
		{
			Voucher.ImportExcelCtVT(this);
		}
		private void BtInheritPOCG_Click(object sender, EventArgs e)
		{

			frmInheritVoucher frm = new frmInheritVoucher();
			frm.Load(drEditPh);

			if (frm.Is_Accept)
			{
				if (txtMa_Nvu.Text != "BBNLK")
				{
					if (frm.dtInheritVoucher.Select("Chon = true").Length == 0)
						return;

					DataRow drInheritVoucher = frm.dtInheritVoucher.Select("Chon = 1")[0];

					//strStt_Org = drInheritVoucher["Stt"].ToString();

					txtMa_Dt.Text = drInheritVoucher["Ma_Dt"].ToString();
					txtMa_Hd.Text = drInheritVoucher["Ma_Hd"].ToString();
					txtOng_Ba.Text = drInheritVoucher["Ong_Ba"].ToString();
					txtDia_Chi.Text = drInheritVoucher["Dia_Chi"].ToString();
					txtSo_Qd.Text = drInheritVoucher["So_Ct"].ToString();
					//
				}
				else
				{
					Voucher.InheritVoucher_SetData(frm, this);
					DataRow drInheritVoucher = frm.dtInheritVoucher.Select("Chon = 1")[0];
					txtSo_Qd.Text = drInheritVoucher["So_Ct"].ToString();
				}
			}
		}
		void btInherit_Click(object sender, EventArgs e)
		{
			this.InheritVoucher();
			this.LoadDicName();
		}

		void txtMa_Nvu_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nvu.Text.Trim();
			bool bRequire = true;
			string strFilter = "(CHARINDEX('" + strMa_Ct + "', Ma_Ct, 0) > 0 OR Ma_Ct = '*')";
			string strValid = "Ma_Ct <> ''";

			DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, strFilter, strValid);

			if (drLookup == null) //Bắt buộc phải nhập Ma_Nvu
			{
				e.Cancel = true;
				return;
			}

			drDmNvu = drLookup;

			txtMa_Nvu.Text = drLookup["Ma_Nvu"].ToString();
			lbtTen_Nvu.Text = drLookup["Ten_Nvu"].ToString();

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEditPh["Duyet"] = (bool)drDmNvu["Default_Duyet"];

			if (txtMa_Nvu.bTextChange) //(enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy) 
			{
				#region Cập nhật trên Form
				if (drDmNvu["Tk_No"].ToString() != "" && !drDmNvu["Tk_No"].ToString().Contains(",")) //Tk_No
				{

				}
				if (drDmNvu["Tk_Co"].ToString() != "" && !drDmNvu["Tk_Co"].ToString().Contains(",")) //Tk_Co
				{

				}
				if (drDmNvu["Ma_Dt"].ToString() != "" && !drDmNvu["Ma_Dt"].ToString().Contains(",")) //Ma_Dt
				{

				}
				if (drDmNvu["Ma_Bp"].ToString() != "" && !drDmNvu["Ma_Bp"].ToString().Contains(",")) //Ma_Bp
				{

				}
				if (drDmNvu["Ma_Km"].ToString() != "" && !drDmNvu["Ma_Km"].ToString().Contains(",")) //Ma_Km
				{

				}
				if (drDmNvu["Ma_Vt_Sp"].ToString() != "" && !drDmNvu["Ma_Vt_Sp"].ToString().Contains(",")) //Ma_Vt_Sp
				{

				}
				if (drDmNvu["Ma_Hd"].ToString() != "" && !drDmNvu["Ma_Hd"].ToString().Contains(",")) //Ma_Hd
				{

				}
				if (drDmNvu["Ma_Job"].ToString() != "" && !drDmNvu["Ma_Job"].ToString().Contains(",")) //Ma_Job
				{

				}
				if (drDmNvu["Ma_Dt_CbNv"].ToString() != "" && !drDmNvu["Ma_Dt_CbNv"].ToString().Contains(",")) //Ma_Dt_CbNv
				{

				}
				if (drDmNvu["Ma_Thue"].ToString() != "" && !drDmNvu["Ma_Thue"].ToString().Contains(",")) //Ma_Thue
				{

				}
				if (drDmNvu["Ma_Kho"].ToString() != "" && !drDmNvu["Ma_Kho"].ToString().Contains(",")) //Ma_Kho
				{

				}
				#endregion

				#region Cập nhật trên lưới
				foreach (DataRow dr in dtEditCt.Rows)
				{
					if (dtEditCt.Columns.Contains("Tk_No") && drDmNvu["Tk_No"].ToString() != "" && !drDmNvu["Tk_No"].ToString().Contains(",")) //Tk_No
					{
						dr["Tk_No"] = drDmNvu["Tk_No"].ToString();
					}
					if (dtEditCt.Columns.Contains("Tk_Co") && drDmNvu["Tk_Co"].ToString() != "" && !drDmNvu["Tk_Co"].ToString().Contains(",")) //Tk_Co
					{
						dr["Tk_Co"] = drDmNvu["Tk_Co"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Dt") && drDmNvu["Ma_Dt"].ToString() != "" && !drDmNvu["Ma_Dt"].ToString().Contains(",")) //Ma_Dt
					{
						dr["Ma_Dt"] = drDmNvu["Ma_Dt"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Bp") && drDmNvu["Ma_Bp"].ToString() != "" && !drDmNvu["Ma_Bp"].ToString().Contains(",")) //Ma_Bp
					{
						dr["Ma_Bp"] = drDmNvu["Ma_Bp"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Km") && drDmNvu["Ma_Km"].ToString() != "" && !drDmNvu["Ma_Km"].ToString().Contains(",")) //Ma_Km
					{
						dr["Ma_Km"] = drDmNvu["Ma_Km"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Vt_Sp") && drDmNvu["Ma_Vt_Sp"].ToString() != "" && !drDmNvu["Ma_Vt_Sp"].ToString().Contains(",")) //Ma_Vt_Sp
					{
						dr["Ma_Vt_Sp"] = drDmNvu["Ma_Vt_Sp"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Hd") && drDmNvu["Ma_Hd"].ToString() != "" && !drDmNvu["Ma_Hd"].ToString().Contains(",")) //Ma_Hd
					{
						dr["Ma_Hd"] = drDmNvu["Ma_Hd"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Job") && drDmNvu["Ma_Job"].ToString() != "" && !drDmNvu["Ma_Job"].ToString().Contains(",")) //Ma_Job
					{
						dr["Ma_Job"] = drDmNvu["Ma_Job"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Dt_CbNv") && drDmNvu["Ma_Dt_CbNv"].ToString() != "" && !drDmNvu["Ma_Dt_CbNv"].ToString().Contains(",")) //Ma_Dt_CbNv
					{
						dr["Ma_Dt_CbNv"] = drDmNvu["Ma_Dt_CbNv"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Thue") && drDmNvu["Ma_Thue"].ToString() != "" && !drDmNvu["Ma_Thue"].ToString().Contains(",")) //Ma_Thue
					{
						dr["Ma_Thue"] = drDmNvu["Ma_Thue"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Kho") && drDmNvu["Ma_Kho"].ToString() != "" && !drDmNvu["Ma_Kho"].ToString().Contains(",")) //Ma_Kho
					{
						dr["Ma_Kho"] = drDmNvu["Ma_Kho"].ToString();
					}
				}
				#endregion
			}

			this.drDmNvu = drLookup;
		}

        public string GetDuCuoi(string strMa_Dt,string strMa_Hd, string strTk)
        {
            Hashtable ht = new Hashtable();

            ht["NGAY_CT"] = dteNgay_Ct.Text;
            ht["MA_DVCS"] = Element.sysMa_DvCs.ToString();
            ht["TK"] = strTk;
            ht["MA_DT"] = strMa_Dt;
            ht["MA_HD"] = strMa_Hd;

            dtDuCuoi = new DataTable();
            dtDuCuoi = SQLExec.ExecuteReturnDt("Sp_GetDuCuoi_MAWB", ht, CommandType.StoredProcedure);

            if (dtDuCuoi != null && dtDuCuoi.Rows.Count > 0)
                return (string)dtDuCuoi.Rows[0]["Dien_Giai"];
            else
                return "";
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

		void txtMa_Tte_Leave(object sender, EventArgs e)
		{
			this.Ma_Tte_Valid();
			Voucher.Update_Detail(this);
			Voucher.Calc_Tien_All(this);			
		}
		void numTy_Gia_Leave(object sender, EventArgs e)
		{
			if (this.txtMa_Tte.Text.Trim() == Element.sysMa_Tte && this.numTy_Gia.Value == 0)
				this.numTy_Gia.Value = 1;

			Voucher.Update_Detail(this);
			Voucher.Calc_Tien_All(this);
			Voucher.Calc_Tien_Von_All(this);
		}
		private void Calc_CsGia()
		{
			double dbTSo_Luong = 0; double dbTien = 0; double dbTien1 = 0; double dbTien2 = 0; double dbTien3 = 0; double dbTien4 = 0; double dbTien5 = 0;
			Hashtable htParameter = new Hashtable();
			htParameter.Add("SO_QD", txtSo_Qd.Text.Trim());
			htParameter.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
			DataTable dtCsGiaMua = SQLExec.ExecuteReturnDt("Sp_GetCSGiaMua", htParameter, CommandType.StoredProcedure);

			foreach (DataRow dr in dtEditCt.Rows)
			{
				if (dr.RowState == DataRowState.Deleted)
					continue;

				dr["Gia_NCC1"] = dtCsGiaMua.Rows[0]["Gia_1"];
				dr["Gia_NCC2"] = dtCsGiaMua.Rows[0]["Gia_2"];
				dr["Gia_NCC3"] = dtCsGiaMua.Rows[0]["Gia_3"];
				dr["Gia_NCC4"] = dtCsGiaMua.Rows[0]["Gia_4"];
				dr["Gia_NCC5"] = dtCsGiaMua.Rows[0]["Gia_5"];

				dbTSo_Luong = Convert.ToDouble(dr["So_Luong1"]) + Convert.ToDouble(dr["So_Luong2"]) + Convert.ToDouble(dr["So_Luong3"]) + Convert.ToDouble(dr["So_Luong4"]);
				dr["So_Luong9"] = dr["So_Luong"] = dbTSo_Luong;
				dbTien1 = Convert.ToDouble(dr["So_Luong1"]) * Convert.ToDouble(dr["Gia_NCC1"]);
				dbTien2 = Convert.ToDouble(dr["So_Luong2"]) * Convert.ToDouble(dr["Gia_NCC2"]);
				dbTien3 = Convert.ToDouble(dr["So_Luong3"]) * Convert.ToDouble(dr["Gia_NCC3"]);
				dbTien4 = Convert.ToDouble(dr["So_Luong4"]) * Convert.ToDouble(dr["Gia_NCC4"]);
				dbTien5 = Convert.ToDouble(dr["So_Luong5"]) * Convert.ToDouble(dr["Gia_NCC5"]);
				if (dbTSo_Luong!= 0)
					dr["Gia_Nt9"] = Math.Round((dbTien1 + dbTien2 + dbTien3 + dbTien4 + dbTien5) / dbTSo_Luong, MidpointRounding.AwayFromZero);

				dr["Tien_Nt9"] = dr["Tien_Nt"] = dr["Tien"] = dbTien1 + dbTien2 + dbTien3 + dbTien4 + dbTien5;
			}

			Voucher.Calc_So_Luong_All(this);
			Voucher.Calc_Tien_All(this);
			Voucher.Update_TTien(this);
			Voucher.Adjust_TThue_Vat(this, true);
		}
		void txtMa_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Hd.Text.Trim();
			bool bRequire = false;
			string strKeyValid = "";

			DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "", strKeyValid);

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
				lbtTen_Hd.Text = drLookup["Ten_Hd"].ToString();

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
            lbtNotice.Text = GetDuCuoi(txtMa_Dt.Text,txtMa_Hd.Text, "131");
            this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
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

				if (txtMa_Dt.Text != (string)drEditPh["Ma_Dt"])
				{
					txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
					txtOng_Ba.Text =  drLookup["Ten_Dt"].ToString();
					if (drLookup["Dia_Chi"].ToString() != string.Empty)
						txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();

					//if (drLookup["Ma_Kv"].ToString() != string.Empty)
					//	txtMa_Kv.Text = drLookup["Ma_Kv"].ToString();

					if (drLookup["Ma_Dt_CbNv"].ToString() != string.Empty)
						txtMa_Dt_CbNv.Text = drLookup["Ma_Dt_CbNv"].ToString();
				}
			}

			//Voucher.Update_Detail(this, "Ma_Dt");

			//Cap nhat xuong chi tiet
			    if (txtMa_Dt.Text != (string)drEditPh["Ma_Dt"])
			    {
			        foreach (DataRow dr in dtEditCt.Rows)
			        {
						if ((string)dr["Ma_Dt"] == (string)drEditPh["Ma_Dt"])
						{
							dr["Ma_Dt"] = txtMa_Dt.Text;
							dr["Ong_Ba"] = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
						}
			        }
			    }
		}
		private void TxtSo_Qd_Validating(object sender, CancelEventArgs e)
		{
			if (strMa_Ct == "BBNL")
				return;

			string strValue = txtSo_Qd.Text.Trim();
			bool bRequire = false;
			string strKeyValid = "Loai_Qd = '2'";
			string strKeyFilter = string.Empty;
			strKeyFilter = " (Ngay_Het_Han >= '" + dteNgay_Ct.Text + "'  OR Ngay_Het_Han <='19000101')  AND (Ma_Dt = 'QDCHUNG' OR Ma_Dt = '" + txtMa_Dt.Text +"')";

			DataRow drLookup = Lookup.ShowLookup("So_Qd_Dt", strValue, bRequire, strKeyFilter, strKeyValid);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtSo_Qd.Text = string.Empty;
				
			}
			else
			{
				txtSo_Qd.Text = drLookup["So_Qd"].ToString();
				//xử lý add giá
				Calc_CsGia();
			}
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

		//void txtMa_Kv_Validating(object sender, CancelEventArgs e)
		//{
		//	string strValue = txtMa_Kv.Text.Trim();
		//	bool bRequire = false;

		//	DataRow drLookup = Lookup.ShowLookup("Ma_Kv", strValue, bRequire, "");

		//	if (bRequire && drLookup == null)
		//		e.Cancel = true;

		//	if (drLookup == null)
		//	{
		//		txtMa_Kv.Text = string.Empty;
		//		lbtTen_Kv.Text = string.Empty;
		//	}
		//	else
		//	{
		//		txtMa_Kv.Text = drLookup["Ma_Kv"].ToString();
		//		lbtTen_Kv.Text = drLookup["Ten_Kv"].ToString();
		//	}
		//}

		void txtMa_Thue_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Thue.Text;
			bool bRequire = false;

			string strMa_Thue_Old = drEditPh["Ma_Thue"] == DBNull.Value ? string.Empty : (string)drEditPh["Ma_Thue"];

			DataRow drLookup = Lookup.ShowLookup("Ma_Thue", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
		
				numTTien_Nt3.ReadOnly = true;
				numTTien3.ReadOnly = true;
		
				numTTien_Nt3.TabStop = false;
				numTTien3.TabStop = false;		

				txtMa_Thue.Text = string.Empty;	

			}
			else
			{			
				numTTien_Nt3.ReadOnly = false;
				numTTien3.ReadOnly = false;
				
				numTTien_Nt3.TabStop = true;
				numTTien3.TabStop = true;				

				string strMa_Thue = (string)drLookup["Ma_Thue"];
				txtMa_Thue.Text = strMa_Thue;

				if (strMa_Thue != strMa_Thue_Old)
				{
					//Đưa Thue_Gtgt vào drEditPh vào để cập nhật xuống Detail
					this.drEditPh["Thue_Gtgt"] = drLookup["Thue_Suat"];
				}

				string strMa_Dt = txtMa_Dt.Text;
				DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", strMa_Dt);
			}

			Voucher.Update_Detail(this, "Ma_Thue, Thue_Gtgt");
			Voucher.Calc_Thue_Vat_All(this);
		}

		void frmEditCtTien_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Voucher.DeleteRow(this, dgvEditCt1);
					break;
				case Keys.F4:

					int IndexTab = tabControl1.SelectedIndex;
					if(IndexTab < 5)
						tabControl1.SelectedIndex = IndexTab + 1;
					else
						tabControl1.SelectedIndex = 0;
					break;

				case Keys.Up:

					if (this.dgvEditCt1.Focused && this.dgvEditCt1.bIsCurrentFirstRow)
						this.SelectNextControl(dgvEditCt1, false, true, true, true);					

					break;
			}

			if (!this.dgvEditCt1.Focused)
				this.dgvEditCt1.ClearSelection();		
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

			if (Common.Inlist(strColumnName, "GIA_NT, GIA, TIEN_NT, TIEN"))
			{
				//if ((bool)dgvEditCt1.CurrentRow.Cells["AUTO_COST"].Value == true)
				//{
				//    dgvCell.ReadOnly = true;
				//    dgvCell.Value = 0;
				//}
				//else
				//    dgvCell.ReadOnly = false;
			}			
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
				
				if (strColumnName == "MA_VT")
					bLookup = dgvLookupMa_Vt(ref dgvCell);
				else if (strColumnName == "MA_LOAI_HANG")
					bLookup = dgvLookupMa_Loai_Hang(ref dgvCell);
				else if (strColumnName == "MA_DT")
					bLookup = dgvLookupMa_Dt(ref dgvCell);

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
			if (this.ActiveControl != dgvEditCt)
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN"))
			{
				Voucher.Calc_So_Luong(drCurrent, this);
				Voucher.Update_TTien(this);		
			}

			else if (Common.Inlist(strColumnName, "TIEN"))
			{
				Voucher.Calc_Tien(drCurrent, this);
				Voucher.Update_TTien(this);
			}
			if (Common.Inlist(strColumnName, "TY_LE1,TY_LE2,TY_LE3,TY_LE4,TY_LE5,SO_LUONG1,SO_LUONG2,SO_LUONG3,SO_LUONG4,SO_LUONG5,GIA_NCC1,GIA_NCC2,GIA_NCC3,GIA_NCC4,GIA_NCC5"))
			{
				if (Convert.ToDouble(drCurrent["Ty_Le1"]) + Convert.ToDouble(drCurrent["Ty_Le2"]) + Convert.ToDouble(drCurrent["Ty_Le3"]) + Convert.ToDouble(drCurrent["Ty_Le4"]) + Convert.ToDouble(drCurrent["Ty_Le5"]) > 100)
				{
					Common.MsgOk("Số xe " + drCurrent["So_Xe"].ToString() + " có tổng tỷ lệ nghiệm thu lớn hơn 100!!!");
					drCurrent[strColumnName] = 0;
				}
				else
				{
					drCurrent["So_Luong1"] = Math.Round(Convert.ToDouble(drCurrent["So_Luong0"]) * (Convert.ToDouble(drCurrent["Ty_Le1"]) / 100), MidpointRounding.AwayFromZero);
					drCurrent["So_Luong2"] = Math.Round(Convert.ToDouble(drCurrent["So_Luong0"]) * (Convert.ToDouble(drCurrent["Ty_Le2"]) / 100), MidpointRounding.AwayFromZero);
					drCurrent["So_Luong3"] = Math.Round(Convert.ToDouble(drCurrent["So_Luong0"]) * (Convert.ToDouble(drCurrent["Ty_Le3"]) / 100), MidpointRounding.AwayFromZero);
					drCurrent["So_Luong4"] = Math.Round(Convert.ToDouble(drCurrent["So_Luong0"]) * (Convert.ToDouble(drCurrent["Ty_Le4"]) / 100), MidpointRounding.AwayFromZero);
					drCurrent["So_Luong5"] = Math.Round(Convert.ToDouble(drCurrent["So_Luong0"]) * (Convert.ToDouble(drCurrent["Ty_Le5"]) / 100), MidpointRounding.AwayFromZero);
					
					drCurrent["So_Luong9"] = drCurrent["So_Luong"] = Convert.ToDouble(drCurrent["So_Luong1"]) + Convert.ToDouble(drCurrent["So_Luong2"]) + Convert.ToDouble(drCurrent["So_Luong3"]) + Convert.ToDouble(drCurrent["So_Luong4"]) + Convert.ToDouble(drCurrent["So_Luong5"]);
					
					drCurrent["Tien_Nt9"] = (Convert.ToDouble(drCurrent["So_Luong1"]) * Convert.ToDouble(drCurrent["Gia_NCC1"])) +
							(Convert.ToDouble(drCurrent["So_Luong2"]) * Convert.ToDouble(drCurrent["Gia_NCC2"])) +
							(Convert.ToDouble(drCurrent["So_Luong3"]) * Convert.ToDouble(drCurrent["Gia_NCC3"])) +
							(Convert.ToDouble(drCurrent["So_Luong4"]) * Convert.ToDouble(drCurrent["Gia_NCC4"])) +
							(Convert.ToDouble(drCurrent["So_Luong5"]) * Convert.ToDouble(drCurrent["Gia_NCC5"]));

					if (Convert.ToDouble(drCurrent["So_Luong9"]) != 0)
						drCurrent["Gia_Nt9"] = Math.Round(Convert.ToDouble(drCurrent["Tien_Nt9"]) / Convert.ToDouble(drCurrent["So_Luong9"]), MidpointRounding.ToEven);
				}
				
				Voucher.Calc_So_Luong(drCurrent, this);
				Voucher.Update_TTien(this);
				numTSo_Luong1.Value = Common.SumDCValue(dtEditCt, "So_Luong1", "");
				numTSo_Luong2.Value = Common.SumDCValue(dtEditCt, "So_Luong2", "");
				numTSo_Luong3.Value = Common.SumDCValue(dtEditCt, "So_Luong3", "");
				numTSo_Luong4.Value = Common.SumDCValue(dtEditCt, "So_Luong4", "");
			}

			bdsEditCt.EndEdit();//Cap nhat lai DataSource
								
		}

		void dgvEditCt1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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

		//Xử lý Dvt
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

				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				dgvCell.Value = drLookup["Ma_Dt"].ToString();
				dgvCell.Tag = drLookup["Ten_Dt"].ToString();
				drCurrent["Ong_Ba"] = drLookup["Ten_Dt"].ToString();
			}
			return true;
		}

		private bool dgvLookupMa_Loai_Hang(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("MA_LOAI_HANG", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["Ma_Loai_Hang"].ToString();
				dgvCell.Tag = drLookup["Ten_Loai_Hang"].ToString();

				dgvCell.DataGridView.EndEdit();
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

				string strMa_Vt_Old = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];
				string strMa_Vt = (string)drLookup["Ma_Vt"];

				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				//La vat tu dich vu                
				if ((string)drLookup["Loai_Vt"] == "0")
				{
					if ((string)drCurrent["Ten_Vt"] == string.Empty)
						drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

					drCurrent["Dvt"] = drLookup["Dvt"];
				}
				else
				{
					drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

					if (strMa_Vt != strMa_Vt_Old)
					{
						drCurrent["Dvt"] = drLookup["Dvt"];
						drCurrent["He_So9"] = 1;

						Voucher.Update_CSGia(drCurrent); //Cap nhat lai CS Gia khi sua Ma_Vt
						Voucher.Calc_So_Luong(drCurrent, this);
					}
					else
					{
						if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
							drCurrent["Dvt"] = drLookup["Dvt"];
					}
				}
			}
			return true;
		}

		#endregion

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			this.dgvEditCt1.ClearSelection(); //Chi co tac dung sau khi show form
			this.DataGridView_Language();
			cboSaveOption.Items.Clear();
			cboSaveOption.Items.AddRange(new string[] { "1-Lưu & Nhập tiếp", "2-Lưu & Đóng lại", "3-Lưu - In & Nhập tiếp", "4-Lưu - In & Đóng lại", "5-In & Nhập tiếp", "6-In & Đóng lại" });

			if (enuNew_Edit == enuEdit.Edit)
			{
				cboSaveOption.SelectedIndex = 1;

				if(DataTool.SQLGetNameByCode("R00MEMBERGROUP", "Member_ID", "Member_Group_ID", Element.sysUser_Id) == "KCSLIEU" && txtSo_Qd.Text != "")
					this.btgAccept.btAccept.Enabled = false;
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
	}
}
