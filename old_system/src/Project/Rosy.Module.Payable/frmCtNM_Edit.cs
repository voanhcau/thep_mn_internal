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
	public partial class frmCtNM_Edit : frmVoucher_Edit
	{
		private string strTk_NoTmp = string.Empty;
		private string strTk_CoTmp = string.Empty;
		private string strModule = "02";
		private bool bMa_Thue_Changed = false;
		string strColumnNameBeforeAddRow = string.Empty;//Lưu lại cột trước khi thêm mới một hàng

		#region Contructor

		public frmCtNM_Edit()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

            this.btImportExcel.Click += new EventHandler(btnImportExcel_Click);
			this.btInherit.Click += new EventHandler(btInherit_Click);

			this.btHanTt.Click += new EventHandler(btHanTt_Click);

			btPb_Cp.Click += new EventHandler(btPb_Cp_Click);
			btPb_ThueNK.Click += new EventHandler(btPb_ThueNK_Click);

			txtDien_Giai.Validating += new CancelEventHandler(txtDien_Giai_Validating);
			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
            txtSo_Pl.Validating += new CancelEventHandler(txtSo_Pl_Validating);
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);
            txtMa_Dt_HQ.Validating += new CancelEventHandler(txtMa_Dt_HQ_Validating);
            txtSo_TKhai.Validating += TxtSo_TKhai_Validating;
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtSo_Ct.Validating += new CancelEventHandler(txtSo_Ct_Validating);
			txtSo_Ct.Validated += new EventHandler(txtSo_Ct_Validated);
			txtSo_Ct.TextChanged +=new EventHandler(txtSo_Ct_TextChanged);
            txtSo_Ct0.Validated += TxtSo_Ct0_Validated;

			dteNgay_Ct.Validating += new CancelEventHandler(dteNgay_Ct_Validating);
			txtMa_Tte.Validating += new CancelEventHandler(txtMa_Tte_Validating);
			numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);

			txtMa_Thue.Validating += new CancelEventHandler(txtMa_Thue_Validating);
			txtMa_So_Thue.Validating += new CancelEventHandler(txtMa_So_Thue_Validating);
			txtMa_Ky_Hieu_HDon.Validated += new EventHandler(txtMa_Ky_Hieu_HDon_Validated);
			txtTk_No3.Validating+=new CancelEventHandler(txtTk_No3_Validating);
			txtTk_Co3.Validating+=new CancelEventHandler(txtTk_Co3_Validating);

			numTTien.Validated += new EventHandler(numTTien_Validated);
			numTTien_Nt.Validated += new EventHandler(numTTien_Nt_Validated);
			numTTien3.Validated += new EventHandler(numTTien3_Validated);
			numTTien_Nt3.Validated += new EventHandler(numTTien_Nt3_Validated);

			dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
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

			if (strMa_Ct == "NK")
				this.pnlVAT.Visible = false;
            else if (strMa_Ct == "NM")
            {
                lblMa_Thue.Visible = false;
                txtMa_Thue.Visible = false;
            }
			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
				this.strStt = Common.GetNewStt(strModule, true);
			else
				this.strStt = drEdit["Stt"].ToString();

			this.Build();
			this.FillData();
			this.Init_Ct();

			Common.ScaterMemvar(this, ref drEditPh);

			txtMa_Tte.bTextChange = false;
			numTy_Gia.bTextChange = false;

			this.Ma_Tte_Valid();
			this.BindingLanguage();
			this.LoadDicName();

			if (strMa_Ct == "NK")
			{
                txtSo_Invoice.Visible = false;
                dteNgay_Invoice.Visible = false;
				txtSo_TKhai.Visible = true;
				dteNgay_TKhai.Visible = true;
                
                lbtSo_Invoice.Visible = false;
                lbtNgay_Invoice.Visible = false;
				lbtNgay_Tkhai.Visible = true;
				lbtSo_Tkhai.Visible = true;

			}
            if (Common.Inlist(strMa_Ct, "NMHH,NMKG"))
            {
                lblTen_Dt_Vc.Visible = true;
                txtTen_Dt_Vc.Visible = true;
                lblSo_Dh_Cty.Visible = true;
                txtID_Dt_Vc.Visible = true;
                lblSo_Xe.Visible = true;
                txtSo_Xe.Visible = true;
                lblSo_Xa_Lan_Tau.Visible = true;
                txtSo_Xa_Lan_Tau.Visible = true;
                lblHt_Tt.Visible = true;
                txtHt_Tt.Visible = true;
                lblMa_KhoN.Visible = true;
                txtMa_KhoN.Visible = true;
                lblHt_Gn.Visible = true;
                txtHt_Gn.Visible = true;
            }

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

			//dgvEditCt_QuyCach.bSortMode = false;
			//dgvEditCt_QuyCach.strZone = "NM_EDIT_QUYCACH";
			//dgvEditCt_QuyCach.BuildGridView();

			dgvEditCt_TapChat.bSortMode = false;
			dgvEditCt_TapChat.strZone = "NM_EDIT_TAPCHAT";
			dgvEditCt_TapChat.BuildGridView();

			dgvEditCt_KN.bSortMode = false;
			dgvEditCt_KN.strZone = "NM_EDIT_KN";
			dgvEditCt_KN.BuildGridView();

			if (dgvEditCt1.Columns.Contains("MA_VT"))
				((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
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

			//dgvEditCt_QuyCach.DataSource = bdsEditCt;
			//dgvEditCt_QuyCach.ClearSelection();

			dgvEditCt_TapChat.DataSource = bdsEditCt;
			dgvEditCt_TapChat.ClearSelection();

			dgvEditCt_KN.DataSource = bdsEditCt;
			dgvEditCt_KN.ClearSelection();
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

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
			{
				if (this.enuNew_Edit == enuEdit.New)
				{
					//Ngầm định 1 số thông tin từ chứng từ cũ
					if (drEdit != null)
						Common.CopyDataRow(drEdit, drCurrent, (string)drDmCt["Carry_Header"]);

					drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;
					drCurrent["Stt"] = strStt;
					drCurrent["Stt0"] = 1;
					drCurrent["Ma_Ct"] = strMa_Ct;
					drCurrent["Ngay_Ct"] = drEdit["Ngay_Ct"] != DBNull.Value ? drEdit["Ngay_Ct"] : DateTime.Now;

					drCurrent["Ma_Tte"] = Element.sysMa_Tte;
					drCurrent["Ty_Gia"] = 1;
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
                        if (dtEditCt.Columns.Contains("IsDaXuatHD"))
                            drEditCt["IsDaXuatHD"] = false;
					}
					//PH
					if (drEditPh.Table.Columns.Contains("Stt_Org"))
					{
						drEditPh["Stt_Org"] = "";
					}

                   
				}

				//Tinh so chung tu
				drEditPh["So_Ct"] = drCurrent["So_Ct"] = Voucher.Cong_So_Ct(this);
                if (strMa_Ct == "NMHH")
                    drCurrent["So_Ct0"] = drCurrent["So_Ct"];
			}

			Voucher.Update_Header(this);
			Voucher.Update_Stt(this, strModule);

			if (this.enuNew_Edit == enuEdit.Edit)
			{
				lblPosted.Visible = (dtEditCt.Rows.Count > 0 && !(bool)dtEditCt.Rows[0]["Posted"]);
				//numTTien_CLTG.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT ISNULL(SUM(Tien_ClTg), 0) FROM R80HanTt0 WHERE Stt = '" + this.strStt + "'"));
			}

			// Neu la phieu chi phi
			if (strMa_Ct == "CP")
			{
				if (dgvEditCt1.Columns.Contains("SO_LUONG9"))
					dgvEditCt1.Columns["SO_LUONG9"].ReadOnly = true;

				if (dgvEditCt1.Columns.Contains("GIA_NT9"))
					dgvEditCt1.Columns["GIA_NT9"].ReadOnly = true;

				if (dgvEditCt1.Columns.Contains("TIEN_NT6"))
					dgvEditCt1.Columns["TIEN_NT6"].ReadOnly = true;

				if (dgvEditCt1.Columns.Contains("TK_NO6"))
					dgvEditCt1.Columns["TK_NO6"].ReadOnly = true;

				if (dgvEditCt1.Columns.Contains("TK_CO6"))
					dgvEditCt1.Columns["TK_CO6"].ReadOnly = true;

				btPb_Cp.Visible = true;
				btInherit.Enabled = false;
			}
			else if (strMa_Ct == "NK")
				btPb_ThueNK.Visible = true;
			else if (strMa_Ct == "NM")
			{
				btPb_Cp.Visible = true;
				
			}

			if (dgvEditCt1.Columns.Contains("TIEN_NT3") && dgvEditCt1.Columns.Contains("TIEN3"))
			{
				dgvEditCt1.Columns["TIEN_NT3"].ReadOnly = true;
				dgvEditCt1.Columns["TIEN3"].ReadOnly = true;
			}
			//tạm bỏ đi để điều chĩnh tiền thuế
			//if (dgvEditCt2.Columns.Contains("TIEN_NT3") && dgvEditCt2.Columns.Contains("TIEN3"))
			//{
			//	dgvEditCt2.Columns["TIEN_NT3"].ReadOnly = true;
			//	dgvEditCt2.Columns["TIEN3"].ReadOnly = true;
			//}

			dgvEditCt1.Columns["Dvt"].ReadOnly = true;
			//BindingTTien            

			txtInherit.Text = Voucher.GetInheritVoucher(this);

			numTTien0.DataBindings.Clear();
			numTTien3.DataBindings.Clear();
			numTTien.DataBindings.Clear();
			numTTien5.DataBindings.Clear();
			numTTien6.DataBindings.Clear();

			numTTien_Nt0.DataBindings.Clear();
			numTTien_Nt3.DataBindings.Clear();
			numTTien_Nt.DataBindings.Clear();
			numTTien_Nt5.DataBindings.Clear();
			numTTien_Nt6.DataBindings.Clear();
			numTSo_Luong.DataBindings.Clear();

			numTTien0.DataBindings.Add("Value", dtEditPh, "TTien0");
			numTTien3.DataBindings.Add("Value", dtEditPh, "TTien3");
			numTTien.DataBindings.Add("Value", dtEditPh, "TTien");
			numTTien5.DataBindings.Add("Value", dtEditPh, "TTien5");
			numTTien6.DataBindings.Add("Value", dtEditPh, "TTien6");

			numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien_Nt0");
			numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien_Nt3");
			numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");
			numTTien_Nt5.DataBindings.Add("Value", dtEditPh, "TTien_Nt5");
			numTTien_Nt6.DataBindings.Add("Value", dtEditPh, "TTien_Nt6");
			numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");
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
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;

            //txtMa_Dt_Hq
            if (txtMa_Dt_HQ.Text.Trim() != string.Empty)
            {
                lbtTen_Dt_HQ.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_HQ.Text.Trim());
            }
            else
                lbtTen_Dt_HQ.Text = string.Empty;

			//txtMa_Hd
			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				lbtTen_Hd.Text = Voucher.GetTenHd(txtMa_Hd.Text); //DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			}
			else
				lbtTen_Hd.Text = string.Empty;

			//txtMa_Bp
			if (txtMa_Bp.Text.Trim() != string.Empty)
			{
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			}
			else
				lbtTen_Bp.Text = string.Empty;

			//txtMa_Km
			if (txtMa_Km.Text.Trim() != string.Empty)
			{
				lbtTen_Km.Text = DataTool.SQLGetNameByCode("R81DMKM", "Ma_Km", "Ten_Km", txtMa_Km.Text.Trim());
			}
			else
				lbtTen_Bp.Text = string.Empty;

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

			if (Common.GetPartitionCurrent() != 0 && this.enuNew_Edit == enuEdit.Edit && this.drEditPh["Ngay_Ct", DataRowVersion.Original] != DBNull.Value)
			{
				if (((DateTime)this.drEditPh["Ngay_Ct"]).Year != ((DateTime)this.drEditPh["Ngay_Ct", DataRowVersion.Original]).Year)
				{
					Common.MsgCancel("Dữ liệu đã phân vùng, không cho phép sửa chứng từ từ năm này sang năm khác");
					return false;
				}
			}
            if((strMa_Ct == "NM" && Library.StrToDate(dteNgay_Ct0.Text).Month > Library.StrToDate(dteNgay_Ct.Text).Month && Library.StrToDate(dteNgay_Ct0.Text).Year == Library.StrToDate(dteNgay_Ct.Text).Year) ||( Library.StrToDate(dteNgay_Ct0.Text).Year > Library.StrToDate(dteNgay_Ct.Text).Year))
            {
                Common.MsgCancel("Ngày hóa đơn không đúng quy tắc phải nhỏ hơn hoặc bằng ngày chứng từ");
                return false;
            }
			if(txtSo_Seri0.Text != "" && txtSo_Seri0.Text.Length != 7)
			{
				Common.MsgCancel("Chiều dài số Seri phải bằng 7 ký tự mới được phép lưu");
				return false;
			}
			if (!Voucher.CheckTenDtGtGT(this) && strMa_Ct != "NK")
            {
                Common.MsgOk("Tồn tại dòng có tên Dt GTGT khác thông tin của đối tượng. Yêu cầu kiểm tra lại thông tin!!!");
                return false;
            }
            if (dteNgay_Ct0.Text != "  /  /" && Convert.ToDateTime(dteNgay_Ct.Text) < Convert.ToDateTime(dteNgay_Ct0.Text) && numTSo_Luong.Value > 0)
            {
                Common.MsgOk("Ngày chứng từ nhỏ hơn ngày hóa đơn, dữ liệu không hợp lệ!!!");
                return false;
            }
			if (dteNgay_Ct0.Text != "  /  /" && numTSo_Luong.Value > 0
					&& (Convert.ToDateTime(dteNgay_Ct.Text).Year != Convert.ToDateTime(dteNgay_Ct0.Text).Year
					|| Convert.ToDateTime(dteNgay_Ct.Text).Month != Convert.ToDateTime(dteNgay_Ct0.Text).Month))
			{
				Common.MsgOk("Tháng, năm chứng từ khác tháng, năm của hóa đơn, dữ liệu không hợp lệ!!!");
				return false;
			}
			//if (chkIs_UngTruoc.Checked && numHan_Tt.Value != 0)
			//{
			//    Common.MsgCancel("Chứng từ khai báo vừa là ứng trước vừa là ghi nhận nợ!");
			//    return false;
			//}

			//Kiểm tra nghiệp vụ hợp lệ
			foreach (DataRow dr in dtEditCt.Rows)
			{
				if ((bool)dr["Deleted"])
					continue;
				#region Kiểm tra thuế GTGT = 0 mà có mã thuế
				if ((string)dr["Ma_Thue"] != "")
                {
					DataRow drMa_Thue = DataTool.SQLGetDataRowByID("R81DMTHUE", "Ma_Thue", dr["Ma_Thue"].ToString());
					if (Convert.ToDouble(dr["Thue_GTGT"]) != Convert.ToDouble(drMa_Thue["Thue_Suat"]))
					{
						Common.MsgCancel("Dòng thứ tự " + dr["Stt0"] + " mã thuế khác thuế suất phải enter tại dòng này !!!");
						return false;
					}
                }
				#region Kiểm tra số hóa đơn và Seri của chứng từ NK
				if(strMa_Ct =="NK" && dr["Tk_No3"].ToString() != "" && (dr["So_Seri0"].ToString() == "" || dr["So_Ct0"].ToString() == ""))
                {
					Common.MsgCancel("Dòng thứ tự " + dr["Stt0"] + " số Seri và số hóa đơn phải khác rỗng !!!");
					return false;
				}
				//kiểm tra mã so thue
				if(strMa_Ct == "NK" && dr["Ma_So_Thue"].ToString() != "")
                {
					DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt"].ToString());
					if(drDmDt["Ma_So_Thue"].ToString() != dr["Ma_So_Thue"].ToString())
                    {
						Common.MsgCancel("Mã số thuế " + dr["Ma_So_Thue"] + " khác với MST của danh mục đối tượng " + drDmDt["Ma_So_Thue"] + ", MST phải giống nhau.");
						return false;
					}
				}
				#endregion
				
				#endregion
				#region Kiểm tra số lượng biên bản và số lượng nhập kho

				//Kiểm tra chứng từ kế thừa 
				if ((string)drDmCt["Nh_Ct"] == "1" && Common.Inlist(dr["Ma_Kho"].ToString(), "016PT,019VPP") && dr["Stt_Org"] == "" 
						&& Common.Inlist(strMa_Ct, "NM,NK") && (DateTime)dr["Ngay_Ct"] >= Library.StrToDate("23/5/2016")
						&& Convert.ToDouble(dr["So_Luong9"]) > 0)
                {
                    Common.MsgCancel("Chứng từ nhập vào kho " + dr["Ma_Kho"] + " phải được kế thừa mới cho phép lưu !!!");
                    return false;
                }
                if (Common.Inlist(strMa_Ct, "NM,NK") && (string)dr["Ma_Kho"] != "" && (string)dr["Ma_Vt"] == "" && Common.InlistLike((string)dr["Tk_No"], "15"))
                {
                    Common.MsgCancel("Chứng từ nhập vào kho " + dr["Ma_Kho"] + " phải có mã vật tư mới cho phép lưu !!!");
                    return false;
                }
				//kiểm tra thông tin TK và Invoice
				if((Common.InlistLike((string)dr["Tk_No"], "152") && Common.InlistLike((string)dr["Tk_Co"], "151")) || 
						(Common.InlistLike((string)dr["Tk_No"], "152") && Common.InlistLike((string)dr["Tk_Co"], "3312")))
                {
                    if (dr["So_Invoice"].ToString() == "" || Library.StrToDate(dr["Ngay_Invoice"].ToString()) == Library.StrToDate("19000101"))
                    {
                        Common.MsgCancel("Số Invoice và ngày Invoice không được phép rỗng");
                        return false;
                    }
                    if (txtSo_TKhai.Text == "" || Library.StrToDate(dteNgay_TKhai.Text) == Library.StrToDate("19000101"))
					{
						Common.MsgCancel("Số tờ khai và ngày tờ khai không được phép rỗng");
						return false;
					}
					if(!DataTool.SQLCheckExist("R81DMTOKHAIHQ","So_TKhai", txtSo_TKhai.Text))
					{
						Common.MsgCancel("Số tờ khai không tồn tại trong danh mục tờ khai");
						return false;
					}
				}
                //Kiểm tra số lượng biên bản
                if (dr["Stt_Org"] != "" && Common.Inlist(dr["Ma_Kho"].ToString(), "016PT,019VPP") && Common.Inlist(strMa_Ct, "NM,NK"))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("STT", dr["Stt_Org"]);
                    ht.Add("MA_VT", dr["Ma_Vt"]);

                    double dbSl_Bb = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CheckNhapKho(@Stt, @Ma_Vt)", ht, CommandType.Text));
                    double dbSo_Luong = Convert.ToDouble(dr["So_Luong"]);
                    if (dbSo_Luong > dbSl_Bb)
                    {
                        Common.MsgCancel("Số lượng của vật tư '" + dr["Ma_Vt"] + "' lớn hơn số lượng lập biên bản");
                        return false;
                    }
                }
                if (dr["Ma_Kho"] == "" || dr["Ma_Kho"] == string.Empty)
                {
                    string strMsg = string.Empty;
                    strMsg = "Vui lòng nhập đầy đủ thông tin mã kho tại dòng vật tư " + dr["Ten_Vt"];

                    Common.MsgCancel(strMsg);
                    return false;
                }
                //
                //Kiểm tra chứng từ nhóm VPP chỉ có nhóm F
                if ((string)drDmCt["Nh_Ct"] == "1" && Common.Inlist(dr["Ma_Kho"].ToString(), "019VPP") && Common.Inlist(strMa_Ct, "NM,NK") && !dr["Ma_Vt"].ToString().StartsWith("F"))
                {
                    Common.MsgCancel("Chứng từ nhập vào kho " + dr["Ma_Kho"] + " phải là vật tư thuộc nhóm VPP !!!");
                    return false;
                }
                if ((string)drDmCt["Nh_Ct"] == "1" && Common.Inlist(dr["Ma_Kho"].ToString(), "016PT") && Common.Inlist(strMa_Ct, "NM,NK") && dr["Ma_Vt"].ToString().StartsWith("F"))
                {
                    Common.MsgCancel("Chứng từ nhập vào kho " + dr["Ma_Kho"] + " phải là vật tư không thuộc nhóm VPP !!!");
                    return false;
                }
                #endregion
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

				DataRow drDmTkNo = DataTool.SQLGetDataRowByID("R81DmTk", "Tk", dr["Tk_No"].ToString());
				DataRow drDmTkCo = DataTool.SQLGetDataRowByID("R81DmTk", "Tk", dr["Tk_Co"].ToString());

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

				if (dtEditCt.Columns.Contains("Tien") && Convert.ToDouble(dr["Tien"]) != 0 && ((string)dr["Tk_No"] == string.Empty || (string)dr["Tk_Co"] == string.Empty))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán không hợp lệ" : "Transaction invalid";
					Common.MsgCancel(strMsg);
					return false;
				}
				if (dtEditCt.Columns.Contains("Ma_Thue") && (string)dr["Ma_Thue"] != string.Empty && ((string)dr["Tk_No3"] == string.Empty || (string)dr["Tk_Co3"] == string.Empty))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán thuế không hợp lệ" : "Transaction VAT invalid";
					Common.MsgCancel(strMsg);
					return false;
				}
				if (dtEditCt.Columns.Contains("Tien5") && Convert.ToDouble(dr["Tien5"]) != 0 && ((string)dr["Tk_No5"] == string.Empty || (string)dr["Tk_Co5"] == string.Empty))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán thuế NK không hợp lệ" : "Transaction import tax invalid";
					Common.MsgCancel(strMsg);
					return false;
				}

				dr["Posted"] = this.drDmNvu["Posted"];
			}

			if (!Voucher.CheckDuplicateInvoice(this) && strMa_Ct != "CP")
				return false;

			return true;
		}

		public override bool Save()
		{
            //cập nhật lại tiền thuế trước khi lưu
            if (strMa_Ct == "NM")
            {
                foreach (DataRow dr in dtEditCt.Rows)
                {
                    if ((bool)dr["Deleted"] || dr["Ma_Vt"].ToString() == null)
                        continue;

                    if (Convert.ToDouble(dr["Thue_GtGt"]) != Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT Thue_Suat FROM R81DMTHUE WHERE Ma_Thue = '"+ dr["Ma_Thue"].ToString() +"'")))
                        dr["Thue_GtGt"] = SQLExec.ExecuteReturnValue("SELECT Thue_Suat FROM R81DMTHUE WHERE Ma_Thue = '"+ dr["Ma_Thue"].ToString() +"'");

                    Voucher.Calc_Thue_Vat(dr, this);
                }
            }
			dtEditCt.AcceptChanges();

			Common.GatherMemvar(this, ref this.drEditPh);
			Voucher.Update_Detail(this);

			if (!FormCheckValid())
				return false;

			Voucher.Update_Log(this);
			Voucher.Update_TTien(this);
			Voucher.Update_Stt(this, strModule);
			
            if(strMa_Ct != "NMHH")
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
		

			////Update mã thuế
			//foreach (DataRow dr in dtEditCt.Rows)
			//{
			//    if (dr.RowState == DataRowState.Deleted)
			//        continue;
			//    if (dr["Ma_Thue"].ToString() != "" || dr["Ma_Thue"].ToString() != string.Empty)
			//    {
			//        DataRow drDmThue = DataTool.SQLGetDataRowByID("R81DMTHUE", "Ma_Thue", dr["Ma_Thue"].ToString());
			//        dr["Thue_GtGt"] = drDmThue["Thue_Suat"];
			//    }
			//}
			return Voucher.SQLUpdateCt(this);
		}

		private void Ma_Tte_Valid()
		{
			string strMa_Tte = txtMa_Tte.Text.Trim();

			if (Common.Inlist(this.strMa_Ct, (string)RosySystem.Library.Parameters.GetParaValue("CT_LOCKED_EXCHANGE")))
				numTy_Gia.Enabled = false;
			else
				numTy_Gia.Enabled = true;

			if (Element.sysMa_Tte == strMa_Tte)
			{
				numTy_Gia.Value = 1;
				numTy_Gia.Enabled = false;

				this.pnlTTien.Visible = false;
				this.pnlTTien_Nt.Left = this.pnlTTien.Right - this.pnlTTien_Nt.Width;

				if (dgvEditCt1.Columns.Contains("TIEN"))
					dgvEditCt1.Columns["TIEN"].Visible = false;

				//if (dgvEditCt2.Columns.Contains("TIEN3"))
				//    dgvEditCt2.Columns["TIEN3"].Visible = false;

				if (dgvEditCt1.Columns.Contains("TIEN5"))
					dgvEditCt1.Columns["TIEN5"].Visible = false;

				if (dgvEditCt2.Columns.Contains("TIEN5"))
					dgvEditCt2.Columns["TIEN5"].Visible = false;

				if (dgvEditCt2.Columns.Contains("TIEN6"))
					dgvEditCt2.Columns["TIEN6"].Visible = false;
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

				if (dgvEditCt1.Columns.Contains("TIEN"))
					dgvEditCt1.Columns["TIEN"].Visible = true;

				//if (dgvEditCt2.Columns.Contains("TIEN3"))
				//    dgvEditCt2.Columns["TIEN3"].Visible = true;

				if (dgvEditCt1.Columns.Contains("TIEN5"))
					dgvEditCt1.Columns["TIEN5"].Visible = true;

				if (dgvEditCt2.Columns.Contains("TIEN5"))
					dgvEditCt2.Columns["TIEN5"].Visible = true;

				if (dgvEditCt2.Columns.Contains("TIEN6"))
					dgvEditCt2.Columns["TIEN6"].Visible = true;
			}

			if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange || numTy_Gia.bTextChange)
			{
				Voucher.Update_Detail(this);
				Voucher.Calc_So_Luong_All(this);
				Voucher.Calc_Tien_All(this);
				Voucher.Adjust_TThue_Vat(this, true);

				if (txtMa_Tte.bTextChange)
					txtMa_Tte.bTextChange = false;
			}

			numTTien_Nt.Scale = numTTien_Nt0.Scale = numTTien_Nt3.Scale = strMa_Tte == Element.sysMa_Tte ? 0 : 2;

			Voucher.FormatTien_Nt(dgvEditCt1, strMa_Tte);
			Voucher.FormatTien_Nt(dgvEditCt2, strMa_Tte);

			dgvEditCt1.ResizeGridView();
			dgvEditCt2.ResizeGridView();
		}

		private bool Ma_Thue_Valid()
		{
			#region NK
			if (strMa_Ct == "NK")
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				if (drCurrent["Ma_Thue"] == DBNull.Value)
					drCurrent["Ma_Thue"] = string.Empty;

				if (drCurrent["Ma_Thue"].ToString().Trim() == string.Empty)
				{
					drCurrent["Thue_GtGt"] = 0;
					drCurrent["Ma_So_Thue"] = string.Empty;
					drCurrent["Ten_DtGtGt"] = string.Empty;
					drCurrent["Tk_No3"] = string.Empty;
					drCurrent["Tk_Co3"] = string.Empty;
					drCurrent["Tien3"] = 0;
					drCurrent["Tien_Nt3"] = 0;

					return false;
				}
				string strMa_Thue = (string)drCurrent["Ma_Thue"];

				DataRow drDmThue = DataTool.SQLGetDataRowByID("R81DMTHUE", "Ma_Thue", drCurrent["Ma_Thue"].ToString());
				DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt"].ToString());

				if (drDmDt != null)
				{
					if (this.bMa_Thue_Changed)
					{
						drCurrent["Ma_So_Thue"] = drDmDt["Ma_So_Thue"].ToString();
						drCurrent["Ten_DtGtGt"] = drDmDt["Ten_Dt"].ToString();
					}
					else
					{
						//if (drCurrent["Ma_So_Thue"] == DBNull.Value || (string)drCurrent["Ma_So_Thue"] == string.Empty)
							drCurrent["Ma_So_Thue"] = drDmDt["Ma_So_Thue"].ToString();

						//if (drCurrent["Ten_DtGtGt"] == DBNull.Value || (string)drCurrent["Ten_DtGtGt"] == string.Empty)
							drCurrent["Ten_DtGtGt"] = drDmDt["Ten_Dt"].ToString();
					}
				}

				if (drDmThue != null)
				{
					if (this.bMa_Thue_Changed)
					{
						if (drDmThue["Loai_Thue"].ToString().Trim() == "2")
						{
							drCurrent["Tk_No3"] = drCurrent["Tk_No"].ToString();
							drCurrent["Tk_Co3"] = drDmThue["Tk"].ToString();
						}
						else
						{
							drCurrent["Tk_No3"] = drDmThue["Tk"].ToString();
							drCurrent["Tk_Co3"] = drCurrent["Tk_Co"].ToString();
						}
					}
					else
					{
						if (drDmThue["Loai_Thue"].ToString().Trim() == "2")
						{
							if (drCurrent["Tk_No3"] == DBNull.Value || (string)drCurrent["Tk_No3"] == string.Empty)
								drCurrent["Tk_No3"] = drCurrent["Tk_No"].ToString();

							if (drCurrent["Tk_Co3"] == DBNull.Value || (string)drCurrent["Tk_Co3"] == string.Empty)
								drCurrent["Tk_Co3"] = drDmThue["Tk"].ToString();
						}
						else
						{
							if (drCurrent["Tk_No3"] == DBNull.Value || (string)drCurrent["Tk_No3"] == string.Empty)
								drCurrent["Tk_No3"] = drDmThue["Tk"].ToString();

							if (drCurrent["Tk_Co3"] == DBNull.Value || (string)drCurrent["Tk_Co3"] == string.Empty)
								drCurrent["Tk_Co3"] = drCurrent["Tk_Co"].ToString();
						}
					}
				}
				
				this.bMa_Thue_Changed = false;
				return true;
			}
			#endregion

			#region NM
            else if(strMa_Ct == "NM")
            {
                string strMa_Thue = (string)drCurrent["Ma_Thue"];

                DataRow drDmThue = DataTool.SQLGetDataRowByID("R81DMTHUE", "Ma_Thue", drCurrent["Ma_Thue"].ToString());
                DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt"].ToString());

                if (drDmDt != null)
                {
                    if (this.bMa_Thue_Changed)
                    {
                       txtMa_So_Thue.Text = drDmDt["Ma_So_Thue"].ToString();
                       txtTen_DtGtgt.Text = drDmDt["Ten_Dt"].ToString();
                    }
                    else
                    {
                        if (drCurrent["Ma_So_Thue"] == DBNull.Value || (string)drCurrent["Ma_So_Thue"] == string.Empty)
                            txtMa_So_Thue.Text = drDmDt["Ma_So_Thue"].ToString();

                        if (drCurrent["Ten_DtGtGt"] == DBNull.Value || (string)drCurrent["Ten_DtGtGt"] == string.Empty)
                            txtTen_DtGtgt.Text = drDmDt["Ten_Dt"].ToString();
                    }
                }

                if (drDmThue != null)
                {
                    if (this.bMa_Thue_Changed)
                    {
                        if (drDmThue["Loai_Thue"].ToString().Trim() == "2")
                        {
                            txtTk_No3.Text = drCurrent["Tk_No"].ToString();
                            txtTk_Co3.Text = drDmThue["Tk"].ToString();
                        }
                        else
                        {
                            txtTk_No3.Text = drDmThue["Tk"].ToString();
                            txtTk_Co3.Text = drCurrent["Tk_Co"].ToString();
                        }
                    }
                    else
                    {
                        if (drDmThue["Loai_Thue"].ToString().Trim() == "2")
                        {
                            if (drCurrent["Tk_No3"] == DBNull.Value || (string)drCurrent["Tk_No3"] == string.Empty)
                                txtTk_No3.Text = drCurrent["Tk_No"].ToString();

                            if (drCurrent["Tk_Co3"] == DBNull.Value || (string)drCurrent["Tk_Co3"] == string.Empty)
                                txtTk_Co3.Text = drDmThue["Tk"].ToString();
                        }
                        else
                        {
                            if (drCurrent["Tk_No3"] == DBNull.Value || (string)drCurrent["Tk_No3"] == string.Empty)
                                txtTk_No3.Text = drDmThue["Tk"].ToString();

                            if (drCurrent["Tk_Co3"] == DBNull.Value || (string)drCurrent["Tk_Co3"] == string.Empty)
                                txtTk_Co3.Text = drCurrent["Tk_Co"].ToString();
                        }
                    }
                }

                this.bMa_Thue_Changed = false;
                return true;
            }
            #endregion
            #region KHAC
            else
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
					txtMa_So_Thue.Enabled = false;
					numTTien_Nt3.Enabled = false;
					numTTien3.Enabled = false;

					return false;
				}
				else
				{
					txtTk_No3.Enabled = true;
					txtTk_Co3.Enabled = true;
					txtTen_DtGtgt.Enabled = true;
					txtMa_So_Thue.Enabled = true;
					numTTien_Nt3.Enabled = true;
					numTTien3.Enabled = true;
				}

				DataRow drDmThue = DataTool.SQLGetDataRowByID("R81DmThue", "Ma_Thue", strMa_Thue);
              
				if (drDmThue != null)
				{
                    foreach (DataRow dr in dtEditCt.Rows)
                    {
                        if (dr.RowState == DataRowState.Deleted)
                            continue;

                        dr["Thue_GtGt"] = drDmThue["Thue_Suat"];

                    }
					if (txtMa_Thue.bTextChange)
					{
						if ((string)drDmCt["Nh_Ct"] == "1")
						{
							txtTk_No3.Text = (string)drDmThue["Tk"];
							txtTk_Co3.Text = (string)drEditCt["Tk_Co"];
						}
						else
						{
							txtTk_No3.Text = (string)drEditCt["Tk_No"];
							txtTk_Co3.Text = (string)drDmThue["Tk"];
						}
					}
					else
					{
						if ((string)drDmCt["Nh_Ct"] == "1")
						{
							if (txtTk_No3.Text.Trim() == string.Empty)
								txtTk_No3.Text = (string)drDmThue["Tk"];

							if (txtTk_Co3.Text.Trim() == string.Empty)
								txtTk_Co3.Text = (string)drEditCt["Tk_Co"];
						}
						else
						{
							if (txtTk_No3.Text.Trim() == string.Empty)
								txtTk_No3.Text = (string)drEditCt["Tk_No"];

							if (txtTk_Co3.Text.Trim() == string.Empty)
								txtTk_Co3.Text = (string)drDmThue["Tk"];
						}
					}
				}

				string strMa_Dt = txtMa_Dt.Text;
                DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DmDt", "Ma_Dt", strMa_Dt == string.Empty ? drCurrent["Ma_Dt"].ToString() : strMa_Dt);

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
			}
			#endregion
			return true;
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

				if (drCurrent["Ma_Vt"] == DBNull.Value || (string)drCurrent["Ma_Vt"] == string.Empty)
				{
					bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;
                    bdsEditCt.RemoveCurrent();
                    dtEditCt.AcceptChanges();
                    //if (bdsEditCt.Count > 1) // bằng ẩn đoạn này từ 7/3/2024
                    //{
                    //    bdsEditCt.RemoveCurrent();
                    //    dtEditCt.AcceptChanges();
                    //}

					if (bIsCurrentLastRow)
					{
						this.dgvEditCt1.ClearSelection();
						this.SelectNextControl(dgvEditCt1, true, true, true, true);
					}

					return true;
				}

				return false;
			}
			#endregion

			if (dgvEditCt1.Columns.Contains("THUE_NK") || dgvEditCt1.Columns.Contains("GHI_CHU"))
			{//Phiếu nhập khẩu

				#region Enter tai Thue_NK

				if (Common.Inlist(strCurrentColumn, "TIEN_NT5_,GHI_CHU"))
				{
					if (dgvCell.FormattedValue.ToString() == string.Empty)
					{
						if (dgvEditCt1.bIsCurrentLastRow)
						{
							if (!Voucher.AddRow(this))
							{
								this.dgvEditCt1.ClearSelection();
								this.SelectNextControl(dgvEditCt1, true, true, true, true);
							}
							else
								dgvEditCt1.FocusNextFirstCell();
						}
						else
							dgvEditCt1.FocusNextFirstCell();

						return true;
					}

					return false;
				}
				#endregion

				#region Enter tai Tk_No5, Tk_Co5
				if (Common.Inlist(strCurrentColumn, "TK_CO5"))
				{
					if (dgvEditCt1.bIsCurrentLastRow)
					{
						if (!Voucher.AddRow(this))
							//this.SelectNextControl(dgvEditCt, true, true, true, true); Khong dung duoc lenh nay
							return false;
						else
							dgvEditCt1.FocusNextFirstCell();

						return true;
					}

					return false;
				}
				#endregion
			}
			else
			{//Phiếu nhập mua

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
							{
								this.dgvEditCt1.ClearSelection();
								this.SelectNextControl(dgvEditCt1, true, true, true, true);
							}
							else
							{
								strColumnNameBeforeAddRow = strCurrentColumn;
								dgvEditCt1.FocusNextFirstCell();
								return true;
							}
						}
						else
						{
							strColumnNameBeforeAddRow = strCurrentColumn;
							dgvEditCt1.FocusNextFirstCell();
						}
					}
					return false;
				}

				#endregion

				#region Enter TIEN
				if (Common.Inlist(strCurrentColumn, "TIEN"))
				{
					// Cap nhat tien TIEN truoc khi xuong dong
					double dbTien = 0;
					if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien))
					{
						dgvEditCt1.CancelEdit();
						drCurrent = ((DataRowView)bdsEditCt.Current).Row;
						drCurrent["TIEN"] = dbTien;
						Voucher.Calc_So_Luong(drCurrent, this);
						Voucher.Update_TTien(this);
					}

					if (dgvEditCt1.bIsCurrentLastRow)
					{
						if (!Voucher.AddRow(this))
							return false;
						else
						{
							strColumnNameBeforeAddRow = strCurrentColumn;
							dgvEditCt1.FocusNextFirstCell();
						}

						return true;
					}

					return false;
				}
				#endregion
			}
			return false;
		}

		private void Phan_Bo_Thue_Nk()
		{
			frmPhanBoThueNk frm = new frmPhanBoThueNk();
			frm.ShowDialog();

			if (frm.isAccept)
			{
				double dTTien5 = frm.numTTien5.Value;
				string strLoai_Pb = frm.txtLoai_Pb.Text;

				Voucher.Phan_Bo_Thue_Nk(this, dTTien5, strLoai_Pb);
			}
		}

		private void Phan_Bo_Cp()
		{
			frmPbCp_Dkl frm = new frmPbCp_Dkl();
			frm.Load(this);

			Voucher.Update_TTien(this);
			this.dgvEditCt1.Focus();
		}

		private void TTien_Valid()
		{
			//numTTien0.Value = numTTien_Nt0.Value * numTy_Gia.Value;

			//if (numTTien3.Value == 0)
			//    numTTien3.Value = numTTien_Nt3.Value * numTy_Gia.Value;
			//else if (numTTien_Nt3.Value == 0 && numTy_Gia.Value != 0)
			//    numTTien_Nt3.Value = numTTien3.Value / numTy_Gia.Value;

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
			if (Common.Inlist(strMa_Ct, "NMHH,NMGK"))
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

                    DataRow drDmNvu = DataTool.SQLGetDataRowByID("R81DMNVU", "Ma_Nvu", txtMa_Nvu.Text);
                    {
                        txtMa_Dt.Text = drDmNvu["Ma_Dt"].ToString();
                        DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt.Text);
                        lbtTen_Dt.Text = drDmDt["Ten_Dt"].ToString();
                        txtOng_Ba.Text = drDmDt["Ten_Dt"].ToString();
                        txtDia_Chi.Text = drDmDt["Dia_Chi"].ToString();
                    }
                }
			}
			else
			{
				frmInheritVoucher frm = new frmInheritVoucher();
				frm.Load(this);

				if (frm.Is_Accept)
				{
					Voucher.InheritVoucher_SetData(frm, this);

					Voucher.Update_Detail(this);
					Voucher.Update_TTien(this);

                    this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
				}
			}
		}

		#endregion

		#region Su kien

		#region FormEvent

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

		void txtDien_Giai_Validating(object sender, CancelEventArgs e)
		{
			//Cap nhat xuong chi tiet
			if (txtDien_Giai.Text != (string)drEditPh["Dien_Giai"])
			{
				foreach (DataRow dr in dtEditCt.Rows)
				{
                    if (dr.RowState == DataRowState.Deleted)
                        continue;

					if ((string)dr["Dien_Giai"] == (string)drEditPh["Dien_Giai"])
						dr["Dien_Giai"] = txtDien_Giai.Text;
				}
			}

			Common.GatherMemvar(this, ref drEditPh);
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

			this.drDmNvu = drLookup;

			txtMa_Nvu.Text = drLookup["Ma_Nvu"].ToString();
			lbtTen_Nvu.Text = drLookup["Ten_Nvu"].ToString();

			lblPosted.Visible = !(bool)drDmNvu["Posted"];

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEditPh["Duyet"] = (bool)drDmNvu["Default_Duyet"];

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
		}

		void btPb_Cp_Click(object sender, EventArgs e)
		{
			Phan_Bo_Cp();
		}

		void btPb_ThueNK_Click(object sender, EventArgs e)
		{
			Phan_Bo_Thue_Nk();
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

			if (Convert.ToInt32(SQLExec.ExecuteReturnValue(strSQLExec, ht, CommandType.Text)) > 0 && strMa_Ct != "CP")
			{
				if (!Common.MsgYes_No("Chứng từ số: " + txtSo_Ct.Text + " Ngày: " + dteNgay_Ct.Text + " đã tồn tại.\n Bạn có muốn tiếp tục kô?"))
					e.Cancel = true;
			}
		}
		private void TxtSo_Ct0_Validated(object sender, EventArgs e)
		{
			if (Common.Inlist(strMa_Ct, "NM"))
			{
				string strSo_Ct0 = txtSo_Ct0.Text;
				if (strSo_Ct0.Length < 8)
				{
					txtSo_Ct0.Text = Voucher.GetSoCt0(strSo_Ct0);
					
				}
			}
		}
		void txtSo_Ct_Validated(object sender, EventArgs e)
		{
			if (Common.Inlist(strMa_Ct, "NMHH"))
			{
				string strSo_Ct = txtSo_Ct.Text;
				if (strSo_Ct.Length < 8)
				{
					txtSo_Ct.Text = Voucher.GetSoCt0(strSo_Ct);
					txtSo_Ct0.Text = txtSo_Ct.Text;
				}
				
			}
			else
				txtSo_Ct0.Text = Voucher.GetSoCt0(txtSo_Ct0.Text);
		}

		void txtSo_Ct_TextChanged(object sender, EventArgs e)
		{
			if (this.ActiveControl == txtSo_Ct)
			{
				txtSo_Ct0.Text = txtSo_Ct.Text;
			}
		}
		void dteNgay_Ct_Validating(object sender, CancelEventArgs e)
		{
			this.Ma_Tte_Valid();
			Common.GatherMemvar(this, ref drEditPh);
			if (Common.Inlist(strMa_Ct, "NMHH"))
			{
				dteNgay_Ct0.Text = dteNgay_Ct.Text;
			}
		}
		void txtMa_Tte_Validating(object sender, CancelEventArgs e)
		{
			this.Ma_Tte_Valid();
		}
		void numTy_Gia_Leave(object sender, EventArgs e)
		{
			this.Ma_Tte_Valid();
		}
		private void TxtSo_TKhai_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtSo_TKhai.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("So_TKhai", strValue, bRequire, "Ma_Dt = '"+ txtMa_Dt.Text +"'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtSo_TKhai.Text = string.Empty;
				dteNgay_TKhai.Text = string.Empty;
			}
			else
			{
				txtSo_TKhai.Text = drLookup["So_TKhai"].ToString();
				dteNgay_TKhai.Text = drLookup["Ngay_TKhai"].ToString();


			}
		}
		void txtMa_Dt_HQ_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_HQ.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_Hq", strValue, bRequire, "Ma_Nh_Dt = '130'");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_HQ.Text = string.Empty;
                lbtTen_Dt_HQ.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_HQ.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt_HQ.Text = drLookup["Ten_Dt"].ToString();

              
            }
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

				if (txtMa_Dt.bTextChange)
				{
					txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
					txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();

                    txtTen_DtGtgt.Text = drLookup["Ten_Dt"].ToString();
                    txtMa_So_Thue.Text = drLookup["Ma_So_Thue"].ToString();
				}
			}

			Voucher.Update_Detail(this, "Ma_Dt");
		}

        void txtSo_Pl_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_Pl.Text.Trim();
            bool bRequire = false;
            string strKeyValid = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "Ma_Hd_Goc = '" + txtMa_Hd.Text + "'", strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtSo_Pl.Text = string.Empty;
               
            }
            else
            {
                txtSo_Pl.Text = drLookup["Ma_Hd"].ToString();
            }
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
				lbtTen_Hd.Text = Voucher.GetTenHd(txtMa_Hd.Text); //drLookup["Ten_Hd"].ToString();

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
		}

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Bp.Text = string.Empty;
				lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
				lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
			}
		}

		void txtMa_Km_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Km.Text.Trim();
			object objReturn = null;

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
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Km.Text = string.Empty;
				lbtTen_Km.Text = string.Empty;
			}
			else
			{
				txtMa_Km.Text = drLookup["Ma_Km"].ToString();
				lbtTen_Km.Text = drLookup["Ten_Km"].ToString();
			}
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

            //if (txtMa_Thue.bTextChange)
				Voucher.Adjust_TThue_Vat(this, true);
		}

		void txtMa_Ky_Hieu_HDon_Validated(object sender, EventArgs e)
		{
			if (enuNew_Edit == enuEdit.New)
			{
				Hashtable ht = new Hashtable();

				ht.Add("MA_DT", txtMa_Dt.Text);
				ht.Add("NGAY_CT", dteNgay_Ct.Text);
				ht.Add("MA_DVCS", Element.sysMa_DvCs);

                string strMa_Ky_Hieu_HDon = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(dbo.fn_GetMa_Ky_Hieu_HDon(@Ngay_Ct, @Ma_Dt, @Ma_DvCs),'')", ht, CommandType.Text);
                if (strMa_Ky_Hieu_HDon != string.Empty)
                    txtMa_Ky_Hieu_HDon.Text = strMa_Ky_Hieu_HDon;
			}
		}

		void txtMa_So_Thue_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_So_Thue.Text.Trim();

			bool bRequire = false;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;

			if (strValue == "/")
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
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;

			if ((string)drCurrent["Ma_Thue"] != string.Empty)
				this.lbtNotice.Text = Voucher.GetDuCuoi(drCurrent, txtTk_No3.Text);
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
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;

			if ((string)drCurrent["Ma_Thue"] != string.Empty)
				this.lbtNotice.Text = Voucher.GetDuCuoi(drCurrent, txtTk_Co3.Text);
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

					else if (this.dgvEditCt2.Focused && this.dgvEditCt2.bIsCurrentFirstRow)
						this.SelectNextControl(dgvEditCt2, false, true, true, true);

					break;

				//case Keys.F6:
				//    Phan_Bo_Thue_Nk();
				//    break;

				case Keys.F6: //Insert dòng

					if (!e.Alt && !e.Control && !e.Shift) //F6
						Voucher.AddRow(this);
					else if (!e.Alt && e.Control && !e.Shift) //Ctrl+F6
						Voucher.CopyNewRow(this);

					break;

				case Keys.I: //Insert dòng

					if (!e.Alt && e.Control && !e.Shift) //Ctrl+I
						Voucher.AddRow(this);
					else if (!e.Alt && e.Control && e.Shift) //Ctrl+Shift+I
						Voucher.CopyNewRow(this);

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

			if (strColumnName == "TK_NO")
				this.strTk_NoTmp = dgvCell.FormattedValue.ToString();

			else if (strColumnName == "TK_CO")
				this.strTk_CoTmp = dgvCell.FormattedValue.ToString();

			if (Common.Inlist(strColumnName, "MA_VT,MA_KHO"))
			{
				if ((string)drCurrent["Ma_Vt"] != string.Empty)
					this.lbtNotice.Text = Voucher.GetTonCuoi(drCurrent);

				dicName.SetValue("TON_CUOI", lbtNotice.Text);
			}
			else if (Common.Inlist(strColumnName, "SO_LUONG,SO_LUONG9") && (strMa_Ct == "NMHH"))
			{
				Voucher.Calc_So_Luong(drCurrent, this);
				Voucher.Update_TTien(this);
				Voucher.Adjust_TThue_Vat(this, true);
			}
			else if (Common.Inlist(strColumnName, "TEN_VT,DVT"))
			{
				this.lbtNotice.Text = dicName.GetValue("TON_CUOI");
			}
			else if (Common.Inlist(strColumnName, "TK_NO, TK_CO, TK_NO3, TK_CO3, TK_NO5, TK_CO5, TK_NO6, TK_CO6"))
			{
				if ((string)drCurrent[strColumnName] != string.Empty)
					this.lbtNotice.Text = Voucher.GetDuCuoi(drCurrent, (string)drCurrent[strColumnName]);
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
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			//Xu ly phim Enter
			if (dgvEditCt.kLastKey == Keys.Enter)
			{
				dgvEditCt.kLastKey = Keys.None;

				if (strMa_Ct == "NK" && strColumnName == "TK_CO5")
					e.Cancel = !dgvLookupTk(ref dgvCell, strColumnName);

				if (this.CellKeyEnter())
					e.Cancel = true;
			}

			//Xu ly Lookup
			if (this.ActiveControl == null)
				return;

			if (Common.Inlist(strColumnName, "SO_SERI0"))
			{
				string strSo_Seri = dgvCell.FormattedValue.ToString().Trim();
				strSo_Seri = strSo_Seri.ToUpper();
				dgvEditCt.CancelEdit();
				dgvCell.Value = strSo_Seri;
			}
			//CẬP NHẬT SỐ HD Có chiều dài = 8 ký tự
			if (Common.Inlist(strColumnName, "SO_CT0"))
			{
				string strSo_Ct0 = dgvCell.FormattedValue.ToString().Trim();
				strSo_Ct0 = Voucher.GetSoCt0(strSo_Ct0);
				dgvEditCt.CancelEdit();
				dgvCell.Value = strSo_Ct0;
			}

			if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				bool bLookup = true;

                if (Common.Inlist(strColumnName, "TK_NO,TK_CO,TK_NO3,TK_CO3,TK_NO5,TK_NO6,TK_CO6,TK_NO7,TK_CO7"))//,TK_CO5
					bLookup = dgvLookupTk(ref dgvCell, strColumnName);

				else if (strColumnName == "MA_DT")
					bLookup = dgvLookupMa_Dt(ref dgvCell);

				else if (strColumnName == "MA_BP")
					bLookup = dgvLookupMa_Bp(ref dgvCell);

				else if (strColumnName == "MA_LOAI_HANG")
					bLookup = dgvLookupMa_Loai_Hang(ref dgvCell);

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

				else if (Common.Inlist(strColumnName, "TK_NO5,TK_CO5,TK_NO6,TK_CO6,TK_NO7,TK_CO7"))
					bLookup = dgvLookupTk(ref dgvCell, strColumnName);

				else if (strColumnName == "MA_THUE")
					bLookup = dgvLookupMa_Thue(ref dgvCell);

				else if (Common.Inlist(strColumnName, "TK_NO3,TK_CO3"))
					bLookup = dgvLookupTk(ref dgvCell, strColumnName);

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

			if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN,TIEN_NT3"))//
			{
				if (drCurrent.RowState == DataRowState.Added ||
					(Convert.ToDouble(drCurrent[strColumnName]) - 
						Convert.ToDouble(drCurrent[strColumnName, DataRowVersion.Original] == null ? drCurrent[strColumnName]: drCurrent[strColumnName, DataRowVersion.Original]) != 0)) //Không cần phải Convert về Kiểu số để tính để tránh Original là NULL; drCurrent[strColumnName] != drCurrent[strColumnName, DataRowVersion.Original]
				{

					//kiểm tra nếu sửa Số lượng hay giá thì phải tính lại tiền còn sửa tiền thì vào calc_so_luong để kiểm tra điều kiện tròn tiền hay không
					if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9"))
					{
						double dHe_So9 = Convert.ToDouble(drCurrent["He_So9"]);
						double dbSo_Luong9 = (drCurrent["So_Luong9"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent["So_Luong9"]);
						double dbGia_Nt9 = (drCurrent["Gia_Nt9"] == DBNull.Value) ? 0 : Convert.ToDouble(drCurrent["Gia_Nt9"]);
						double dbTy_Gia = Convert.ToDouble(drCurrent["Ty_Gia"]);
						double dbTien_Nt9 = Math.Round(dbSo_Luong9 * dbGia_Nt9, 3, MidpointRounding.AwayFromZero);
						if ((string)drCurrent["Ma_Tte"] == Element.sysMa_Tte)
							dbTien_Nt9 = Math.Round(dbTien_Nt9, MidpointRounding.AwayFromZero);
						//Cap nhat So_Luong, Gia_Nt, Gia
						double dbSo_Luong = Math.Round(dbSo_Luong9 * dHe_So9, 3, MidpointRounding.AwayFromZero);
						double dbGia_Nt = Math.Round(dbGia_Nt9 / dHe_So9, 4, MidpointRounding.AwayFromZero);

						double dbGia = Math.Round(dbGia_Nt * dbTy_Gia, 3, MidpointRounding.AwayFromZero);

						drCurrent["Tien_Nt9"] = dbTien_Nt9;
						drCurrent["Gia_Nt9"] = dbGia_Nt9;
						drCurrent["So_Luong"] = dbSo_Luong;
					}
					Voucher.Calc_So_Luong(drCurrent, this);
					Voucher.Update_TTien(this);
					//Voucher.Adjust_TThue_Vat(this, true); //TẠM BỎ ĐI
				}
			}
			

			else if (Common.Inlist(strColumnName, "MA_THUE,TIEN_NT3,TIEN3"))
			{
					Voucher.Calc_Thue_Vat(drCurrent, this);
					Voucher.Update_TTien(this);
				
			}

			else if (strMa_Ct.Contains("NK") && Common.Inlist(strColumnName, "TIEN_NT,TIEN"))
			{
				if (drCurrent.RowState == DataRowState.Added ||
					(Convert.ToDouble(drCurrent[strColumnName]) -
						Convert.ToDouble(drCurrent[strColumnName, DataRowVersion.Original] == null ? drCurrent[strColumnName] : drCurrent[strColumnName, DataRowVersion.Original]) != 0))
				{
					Voucher.Calc_Thue_Nk(drCurrent, this);
					Voucher.Calc_Thue_TTDB(drCurrent, this);
					Voucher.Calc_Thue_Vat(drCurrent, this);
					Voucher.Update_TTien(this);
				}
			}

			else if (Common.Inlist(strColumnName, "TIEN_NT5,TIEN5,THUE_NK"))
			{
				double dbTien5 = dgvCell.Value == DBNull.Value ? 0 : Convert.ToDouble(dgvCell.Value);
				if (dbTien5 == 0)
				{
					if (dgvEditCt.Columns.Contains("Tk_No5"))
					{
						dgvEditCt.CurrentRow.Cells["TK_NO5"].ReadOnly = true;
						dgvEditCt.CurrentRow.Cells["TK_CO5"].ReadOnly = true;
					}
				}
				else
				{
					if (dgvEditCt.Columns.Contains("Tk_No5"))
					{
						dgvEditCt.CurrentRow.Cells["TK_NO5"].ReadOnly = false;
						dgvEditCt.CurrentRow.Cells["TK_CO5"].ReadOnly = false;
					}
				}

				Voucher.Calc_Thue_Nk(drCurrent, this);
				Voucher.Update_TTien(this);
			}

			else if (Common.Inlist(strColumnName, "TIEN_NT6,TIEN6,THUE_TTDB"))
			{
				double dbTien6 = dgvCell.Value == DBNull.Value ? 0 : Convert.ToDouble(dgvCell.Value);
				if (dbTien6 == 0)
				{
					dgvEditCt.CurrentRow.Cells["TK_NO6"].ReadOnly = true;
					dgvEditCt.CurrentRow.Cells["TK_CO6"].ReadOnly = true;
				}
				else
				{
					dgvEditCt.CurrentRow.Cells["TK_NO6"].ReadOnly = false;
					dgvEditCt.CurrentRow.Cells["TK_CO6"].ReadOnly = false;
				}

				Voucher.Calc_Thue_TTDB(drCurrent, this);
				Voucher.Update_TTien(this);
			}
            else if(Common.Inlist(strColumnName, "TIEN_NT7,TIEN7"))
            {
                Voucher.Calc_Thue_BVMT(drCurrent, this);
                Voucher.Update_TTien(this);
            }
			if (dgvEditCt.Columns.Contains("MA_THUE"))
				this.Ma_Thue_Valid();

			if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN"))
				drCurrent.AcceptChanges();

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

			if (strColumnName == "MA_THUE")
				this.bMa_Thue_Changed = true;
		}

		//Bắt phím trên lưới, Xử lý Dvt
		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
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

			bool bRequire = true;

			if (strColumnName == "TK_NO3" || strColumnName == "TK_CO3")
				if (drCurrent["Ma_Thue"].ToString() == string.Empty)
					bRequire = false;

			if (strColumnName == "TK_NO5" || strColumnName == "TK_CO5")
			{
				if (drCurrent["TIEN5"] == DBNull.Value || Convert.ToDouble(drCurrent["TIEN5"]) == 0)
					bRequire = false;
			}
            else if (strColumnName == "TK_NO6" || strColumnName == "TK_CO6")
			{
				if (strColumnName == "TK_NO6" || strColumnName == "TK_CO6")
					if (drCurrent["TIEN6"] == DBNull.Value || Convert.ToDouble(drCurrent["TIEN6"]) == 0)
						bRequire = false;
			}
            else
			{
				if (strColumnName == "TK_NO7" || strColumnName == "TK_CO7")
					if (drCurrent["TIEN7"] == DBNull.Value || Convert.ToDouble(drCurrent["TIEN7"]) == 0)
						bRequire = false;
			}

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
				dgvCell.Value = drLookup["Tk"].ToString();
				dgvCell.Tag = drLookup["Ten_Tk"].ToString();

				dgvCell.DataGridView.EndEdit();
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
				dgvCell.Value = drLookup["Ma_Dt"].ToString();
				dgvCell.Tag = drLookup["Ten_Dt"].ToString();

				dgvCell.DataGridView.EndEdit();
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
				dgvCell.Value = drLookup["Ma_Bp"].ToString();
				dgvCell.Tag = drLookup["Ten_Bp"].ToString();

				dgvCell.DataGridView.EndEdit();
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

			DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["Ma_Km"].ToString();
				dgvCell.Tag = drLookup["Ten_Km"].ToString();

				dgvCell.DataGridView.EndEdit();
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
				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				dgvCell.DataGridView.EndEdit();
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
				dgvCell.Value = drLookup["Ma_Job"].ToString();
				dgvCell.Tag = drLookup["Ten_Job"].ToString();

				dgvCell.DataGridView.EndEdit();
			}
			return true;
		}

		private bool dgvLookupMa_Thue(ref DataGridViewCell dgvCell)
		{
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strMa_Thue_Old = drCurrent["Ma_Thue"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Thue"];

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

				if (dgvCell.DataGridView.Columns.Contains("Tien3"))
					dgvCell.DataGridView.CurrentRow.Cells["Tien3"].ReadOnly = true;

				if (dgvCell.DataGridView.Columns.Contains("Tien_Nt3"))
					dgvCell.DataGridView.CurrentRow.Cells["Tien_Nt3"].ReadOnly = true;

				if (dgvCell.DataGridView.Columns.Contains("Tk_No3"))
					dgvCell.DataGridView.CurrentRow.Cells["Tk_No3"].ReadOnly = true;

				if (dgvCell.DataGridView.Columns.Contains("Tk_Co3"))
					dgvCell.DataGridView.CurrentRow.Cells["Tk_Co3"].ReadOnly = true;
			}
			else
			{
				dgvCell.Value = drLookup["Ma_Thue"].ToString();
				dgvCell.Tag = drLookup["Ten_Thue"].ToString();

				drCurrent["Thue_GtGt"] = Convert.ToInt32(drLookup["Thue_Suat"]);

				if (dgvCell.DataGridView.Columns.Contains("Tien3"))
					dgvCell.DataGridView.CurrentRow.Cells["Tien3"].ReadOnly = false;

				if (dgvCell.DataGridView.Columns.Contains("Tien_Nt3"))
					dgvCell.DataGridView.CurrentRow.Cells["Tien_Nt3"].ReadOnly = false;

				if (dgvCell.DataGridView.Columns.Contains("Tk_No3"))
					dgvCell.DataGridView.CurrentRow.Cells["Tk_No3"].ReadOnly = false;

				if (dgvCell.DataGridView.Columns.Contains("Tk_Co3"))
					dgvCell.DataGridView.CurrentRow.Cells["Tk_Co3"].ReadOnly = false;

				dgvCell.DataGridView.EndEdit();
			}

			this.Ma_Thue_Valid();

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

				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				dgvCell.DataGridView.EndEdit();

				if (strMa_Vt != strMa_Vt_Old)
				{
					drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];
					drCurrent["Dvt"] = drLookup["Dvt"];
					drCurrent["He_So9"] = 1;

					Voucher.Calc_So_Luong(drCurrent, this);

					if (drCurrent["Tk_No"] == string.Empty & strMa_Ct != "NMHH")
						drCurrent["Tk_No"] = drLookup["Tk_VTu"];
				}
				else
				{
					if (drCurrent["Ten_Vt"] == DBNull.Value || (string)drCurrent["Ten_Vt"] == string.Empty)
						drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

					if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
						drCurrent["Dvt"] = drLookup["Dvt"];

					if ((drCurrent["Tk_No"] == DBNull.Value || (string)drCurrent["Tk_No"] == string.Empty) & strMa_Ct != "NMHH")
						drCurrent["Tk_No"] = drLookup["Tk_VTu"];
				}
			}
			//if(strMa_Ct == "NMHH")
			//    Voucher.Update_CSGiaMua(drCurrent);
				
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
				dgvCell.Value = drLookup["Ma_Kho"].ToString();
				dgvCell.Tag = drLookup["Ten_Kho"].ToString();

				dgvCell.DataGridView.EndEdit();
			}
			return true;
		}
	
		private bool dgvLookupMa_So_Thue(ref DataGridViewCell dgvCell)
		{
			string strValue = drCurrent["Ma_So_Thue"].ToString();

			bool bRequire = false;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;

			if (strValue == "/" || strValue == @"\")
			{
				strValue = string.Empty;

				if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
					strValue = this.ActiveControl.Text;
				else
					strValue = dgvCell.FormattedValue.ToString().Trim();

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
					dgvCell.Value = drLookup["Ma_Kho"].ToString();
					dgvCell.Tag = drLookup["Ten_Kho"].ToString();

					dgvCell.DataGridView.EndEdit();
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

			cboSaveOption.Items.Clear();
			cboSaveOption.Items.AddRange(new string[] { "1-Lưu & Nhập tiếp", "2-Lưu & Đóng lại", "3-Lưu - In & Nhập tiếp", "4-Lưu - In & Đóng lại", "5-In & Nhập tiếp", "6-In & Đóng lại" });

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
                if ((bool)drEditPh["Lock"])
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
	}
}
