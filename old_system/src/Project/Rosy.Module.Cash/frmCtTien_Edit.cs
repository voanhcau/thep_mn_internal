using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosyList;
using RosySystem.Public;
using RosySystem.Common;
using RosySystem.Customize;

namespace RosyModule.Cash
{
	public partial class frmCtTien_Edit : frmVoucher_Edit
	{
		private string strTk_NoTmp = string.Empty;
		private string strTk_CoTmp = string.Empty;
		private bool bMa_Thue_Changed = false;
		private string strModule = "01";
		private bool bCheckDataLockedCtHanTt = false;

		#region Contructor

		public frmCtTien_Edit()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

			this.btHanTt.Click += new EventHandler(btHanTt_Click);
			this.btImportExcel.Click += new EventHandler(btImportExcel_Click);
			this.btInherit.Click += new EventHandler(btInherit_Click);

			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);

			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtSo_Ct.Validating += new CancelEventHandler(txtSo_Ct_Validating);

			dteNgay_Ct.Validating += new CancelEventHandler(dteNgay_Ct_Validating);
			txtMa_Tte.Validating += new CancelEventHandler(txtMa_Tte_Validating);
			numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);

			txtDien_Giai.Validating += new CancelEventHandler(txtDien_Giai_Validating);

			dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
			dgvEditCt1.CellValueChanged += new DataGridViewCellEventHandler(dgvEditCt_CellValueChanged);

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
			
			if(Common.InlistLike(strMa_Ct, "BN"))
            {
				if(strMa_Ct == "BNV")
                {
					lblTen_NH_A.Visible = false;
					txtTen_NH_A.Visible = false;
					lblTk_NH_A.Visible = false;
					txtTk_NH_A.Visible = false;
				}
			}
			else
            {
				lblTen_NH_A.Visible = false;
				txtTen_NH_A.Visible = false;
				lblTk_NH_A.Visible = false;
				txtTk_NH_A.Visible = false;

				lblTen_NH_B.Visible = false;
				txtTen_NH_B.Visible = false;
				lblTk_NH_B.Visible = false;
				txtTk_NH_B.Visible = false;
				txtTen_Dv_B.Visible = false;
			}
			this.Build();
			this.FillData();
			this.Init_Ct();

			Common.ScaterMemvar(this, ref drEditPh);

			txtMa_Tte.bTextChange = false;
			numTy_Gia.bTextChange = false;

			this.Ma_Tte_Valid();
			this.BindingLanguage();
			this.LoadDicName();

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
					drEditPh["Ma_Ct"] = drCurrent["Ma_Ct"];
					drEditPh["Stt"] = drCurrent["Stt"];
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
				drEditPh["So_Ct"] = drCurrent["So_Ct"] = Voucher.Cong_So_Ct(this);
			}

			Voucher.Update_Header(this);
			Voucher.Update_Stt(this, strModule);

			if (this.enuNew_Edit == enuEdit.Edit)
			{
				lblPosted.Visible = (dtEditCt.Rows.Count > 0 && !(bool)dtEditCt.Rows[0]["Posted"]);

				numTTien_CLTG.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT ISNULL(SUM(Tien_ClTg), 0) FROM R80HanTt0 WHERE Stt = '" + this.strStt + "'"));
			}

			txtInherit.Text = Voucher.GetInheritVoucher(this);

			//BindingTTien
			numTTien0.DataBindings.Clear();
			numTTien_Nt0.DataBindings.Clear();

			numTTien_Nt3.DataBindings.Clear();
			numTTien3.DataBindings.Clear();

			numTTien.DataBindings.Clear();
			numTTien_Nt.DataBindings.Clear();

			numTTien0.DataBindings.Add("Value", dtEditPh, "TTien0");
			numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien_Nt0");

			numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien_Nt3");
			numTTien3.DataBindings.Add("Value", dtEditPh, "TTien3");

			numTTien.DataBindings.Add("Value", dtEditPh, "TTien");
			numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");

			if (dgvEditCt2.Columns.Contains("Tien"))
				dgvEditCt2.Columns["Tien"].ReadOnly = true;

            if (dgvEditCt2.Columns.Contains("Thue_GtGt"))
                dgvEditCt2.Columns["Thue_Gtgt"].ReadOnly = true;

            if (enuNew_Edit == enuEdit.Edit && (bool)drCurrent["Is_Lock"] && (Common.InlistLike(drCurrent["Tk_Co"].ToString(), "131") || Common.InlistLike(drCurrent["Tk_Co3"].ToString(), "131")))
            {
                dgvEditCt1.ReadOnly = true;
                dgvEditCt2.ReadOnly = true;
                dteNgay_Ct.ReadOnly = true;
                txtMa_Dt.ReadOnly = true;
            }
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
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			else
				lbtTen_Dt.Text = string.Empty;

			//txtMa_Hd
			if (txtMa_Hd.Text.Trim() != string.Empty)
				lbtTen_Hd.Text = Voucher.GetTenHd(txtMa_Hd.Text);// DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			else
				lbtTen_Hd.Text = string.Empty;

			////Grid
			//foreach (DataGridViewRow dgvr in dgvEditCt1.Rows)
			//{
			//    for (int i = 0; i < dgvEditCt1.Columns.Count; i++)
			//    {
			//        string strColumnName = dgvEditCt1.Columns[i].Name;

			//        if ("TK_NO,TK_CO,TK_NO3,TK_CO3".Contains(strColumnName))
			//        {
			//            if (dgvr.Cells[strColumnName].Value.ToString() != "")
			//                dgvr.Cells[strColumnName].Tag = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", dgvr.Cells[strColumnName].Value.ToString());
			//        }
			//        else if (strColumnName == "MA_DT")
			//        {
			//            if (dgvr.Cells[strColumnName].Value.ToString() != "")
			//                dgvr.Cells[strColumnName].Tag = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", dgvr.Cells[strColumnName].Value.ToString());
			//        }
			//        else if (strColumnName == "MA_HD")
			//        {
			//            if (dgvr.Cells[strColumnName].Value.ToString() != "")
			//                dgvr.Cells[strColumnName].Tag = DataTool.SQLGetNameByCode("R81DmHd", "Ma_Hd", "Ten_Hd", dgvr.Cells[strColumnName].Value.ToString());
			//        }
			//        else if (strColumnName == "MA_BP")
			//        {
			//            if (dgvr.Cells[strColumnName].Value.ToString() != "")
			//                dgvr.Cells[strColumnName].Tag = DataTool.SQLGetNameByCode("R81DmBp", "Ma_Bp", "Ten_Bp", dgvr.Cells[strColumnName].Value.ToString());
			//        }
			//        else if (strColumnName == "MA_KM")
			//        {
			//            if (dgvr.Cells[strColumnName].Value.ToString() != "")
			//                dgvr.Cells[strColumnName].Tag = DataTool.SQLGetNameByCode("R81DmKm", "Ma_Km", "Ten_Km", dgvr.Cells[strColumnName].Value.ToString());
			//        }
			//        else if (strColumnName == "MA_VT_SP")
			//        {
			//            if (dgvr.Cells[strColumnName].Value.ToString() != "")
			//                dgvr.Cells[strColumnName].Tag = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", dgvr.Cells[strColumnName].Value.ToString());
			//        }
			//    }
			//}
			//dgvEditCt1.EndEdit();

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
			if(strMa_Ct == "BN" && (txtTk_NH_A.Text == "" || txtTk_NH_B.Text == "" || txtTen_NH_A.Text == "" || txtTen_NH_B.Text == ""))
            {
				Common.MsgCancel("Tk ngân hàng chuyển và nhận không được thiếu thông tin.Yêu cầu nhập đầy đủ thông tin!!!");
				return false;
			}
			if (strMa_Ct == "BNV" && (txtTk_NH_B.Text == "" || txtTen_NH_B.Text == ""))
			{
				Common.MsgCancel("Tk ngân hàng nhận không được thiếu thông tin.Yêu cầu nhập đầy đủ thông tin!!!");
				return false;
			}
			//Kiểm tra nghiệp vụ hợp lệ
			foreach (DataRow dr in dtEditCt.Rows)
			{
				if ((bool)dr["Deleted"])
					continue;
                if (Convert.ToDouble(dr["Tien"]) == 0)
                {
 
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
					//if ((bool)drDmTkCo["Tk_Dt"] && dr["Ma_Dt_Co"].ToString() == ""  && strMa_Ct == "BNV")
					//{
					//    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk có yêu cầu Mã đối tượng" : "Credit account require Customer code";
					//    Common.MsgCancel(strMsg);
					//    return false;
					//}
					if ((bool)drDmTkCo["Tk_Dt"] && dr["Ma_Dt"].ToString() == "" && strMa_Ct != "BNV")
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
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán không hợp lệ" : "Transaction is invalid";
					Common.MsgCancel(strMsg);
					return false;
				}
				if (dtEditCt.Columns.Contains("Ma_Thue") && (string)dr["Ma_Thue"] != string.Empty && ((string)dr["Tk_No3"] == string.Empty || (string)dr["Tk_Co3"] == string.Empty))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán thuế không hợp lệ" : "Transaction VAT invalid";
					Common.MsgCancel(strMsg);
					return false;
				}

                //KIEM TRA NHAP MA BP
                if (dr["Ma_Bp"] == "" && Common.InlistLike(dr["Tk_No"].ToString(),"6,8"))
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chứng từ cần nhập mã bộ phận" : "Do not register transaction type";
                    Common.MsgCancel(strMsg);
                    return false;
                }
				if (dr["So_Seri0"].ToString() != "" && dr["So_Seri0"].ToString().Length != 7)
				{
					Common.MsgCancel("Chiều dài số Seri phải bằng 7 ký tự mới được phép lưu");
					return false;
				}
				//kiễm tra số tờ khai
				if(Common.InlistLike(dr["Tk_No"].ToString(), "33312,3312") && dr["So_TKhai"].ToString() == "")
                {
					Common.MsgCancel("Nghiệp vụ thanh toán tiền hàng nhập khẩu yêu cầu nhập số tờ khai");
					return false;
				}
				dr["Posted"] = this.drDmNvu["Posted"];
			}

			if (!Voucher.CheckDuplicateInvoice(this))
				return false;

			return true;
		}

		public override bool Save()
		{
			dtEditCt.AcceptChanges();

			Common.GatherMemvar(this, ref this.drEditPh);
			Voucher.Update_Detail(this);

			if (!FormCheckValid())
				return false;

			Voucher.Update_Log(this);
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
            if (strMa_Ct == "BC")
            {                
                Voucher.SQLUpdateCt(this);
                UpdateHanMucBHAuto();
                return Create_CtLXH();
            }
            else
                return Voucher.SQLUpdateCt(this);
		}
        private bool Create_CtLXH()
        {
            DataTable dtSO = SQLExec.ExecuteReturnDt("SELECT Stt, Ma_Ct FROM R80PH T2 WHERE So_Ct IN " +
                                                "(select So_LXH from R04HANMUCBH " +
                                                "where Ghi_Chu = N'Duyệt UNC') AND Duyet = 1 and NOT EXISTS (SELECT Stt_Org FROM R04CTSO T1 WHERE T1.Stt_Org = T2.Stt) AND Ngay_Ct = '"+ dteNgay_Ct.Text +"' ");

            if (dtSO.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSO.Rows)
                    Voucher.Create_Auto_LXH(dr["Ma_Ct"].ToString(), dr["Stt"].ToString());
            }
            return true;
        }
        private bool UpdateHanMucBHAuto()
        {
            DataRow drPh = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt);
            Hashtable ht = new Hashtable();
          
            ht.Add("MA_DT", drPh["Ma_Dt"].ToString());
            ht.Add("NGAY_CT", drPh["Ngay_Ct"]);
            ht.Add("DUYET_LOG", Common.GetCurrent_Log());
            ht.Add("MA_DVCS", drPh["Ma_DvCs"].ToString());

            if (SQLExec.Execute("sp_UpdateHanMucBH_BC", ht, CommandType.StoredProcedure))
                return true;
            else
                return false;

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

				if (dgvEditCt2.Columns.Contains("TIEN3"))
					dgvEditCt2.Columns["TIEN3"].ReadOnly = true;
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

				if (dgvEditCt2.Columns.Contains("TIEN3"))
					dgvEditCt2.Columns["TIEN3"].ReadOnly = false;
			}

			if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange || numTy_Gia.bTextChange)
			{
				Common.GatherMemvar(this, ref this.drEditPh);
				Voucher.Update_Detail(this);
				Voucher.Calc_Tien_All(this);

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

				this.bMa_Thue_Changed = false;

				return false;
			}

			string strMa_Thue = (string)drCurrent["Ma_Thue"];

			DataRow drDmThue = DataTool.SQLGetDataRowByID("R81DMTHUE", "Ma_Thue", drCurrent["Ma_Thue"].ToString());
			DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt"].ToString());

			if (drDmDt != null && !drCurrent["Ma_Dt"].ToString().StartsWith("M"))
			{
				if (this.bMa_Thue_Changed)
				{
					drCurrent["Ma_So_Thue"] = drDmDt["Ma_So_Thue"].ToString();
					drCurrent["Ten_DtGtGt"] = drDmDt["Ten_Dt"].ToString();
				}
				else
				{
					if (drCurrent["Ma_So_Thue"] == DBNull.Value || (string)drCurrent["Ma_So_Thue"] == string.Empty)
						drCurrent["Ma_So_Thue"] = drDmDt["Ma_So_Thue"].ToString();

					if (drCurrent["Ten_DtGtGt"] == DBNull.Value || (string)drCurrent["Ten_DtGtGt"] == string.Empty)
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
						if (drCurrent["Tk_Co3"] == DBNull.Value || (string)drCurrent["Tk_Co3"] == string.Empty)
							drCurrent["Tk_No3"] = drDmThue["Tk"].ToString();

						if (drCurrent["Tk_No3"] == DBNull.Value || (string)drCurrent["Tk_No3"] == string.Empty)
							drCurrent["Tk_Co3"] = drCurrent["Tk_Co"].ToString();
					}
				}
			}

			this.bMa_Thue_Changed = false;

			return true;
		}

		private bool CellKeyEnter()
		{//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc

			if (dgvEditCt1.CurrentCell == null)
				return false;

			DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
			string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

			#region Enter tai Tk_No, Tk_Co
			if (Common.Inlist(strCurrentColumn, "TK_NO,TK_CO"))
			{
				string strOldValue = (strCurrentColumn == "TK_NO" ? this.strTk_NoTmp : this.strTk_CoTmp);

				if (dgvCell.FormattedValue.ToString() == string.Empty)
				{
					bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;

					if (strOldValue != string.Empty)
					{
						dgvCell.Value = strOldValue;
						Voucher.DeleteRow(this, dgvEditCt1);
					}
					else
					{
						if (bdsEditCt.Count > 1) //Chỉ remove khi kô fải là dòng đầu tiên
						{
							bdsEditCt.RemoveCurrent();
							//dtEditCt.AcceptChanges();
						}
					}

					if (bIsCurrentLastRow)
						this.SelectNextControl(dgvEditCt1, true, true, true, true);

					return true;
				}
			}
			#endregion

			#region Enter tai Ma_Thue
			if (Common.Inlist(strCurrentColumn, "MA_THUE"))
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

			#region Enter tai Tk_Co3
			if (Common.Inlist(strCurrentColumn, "TK_CO3"))
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

			return false;
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
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text);
			}
		}

		#endregion

		#region Su kien

		#region FormEvent

		void btHanTt_Click(object sender, EventArgs e)
		{
			Voucher.HanTt(this);
		}

		void btImportExcel_Click(object sender, EventArgs e)
		{
			Voucher.ImportExcelCtKT(this);
		}

		void btInherit_Click(object sender, EventArgs e)
		{
			this.InheritVoucher();
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

		void txtSo_Ct_Validating(object sender, CancelEventArgs e)
		{
			if (txtSo_Ct.Text == string.Empty)
				return;

			string strTablePh = (string)drDmCt["Table_Ph"];
			string strMa_Ct = (string)drDmCt["Ma_Ct"];
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

		void dteNgay_Ct_Validating(object sender, CancelEventArgs e)
		{
			this.Ma_Tte_Valid();
			Common.GatherMemvar(this, ref drEditPh);
		}
		void txtMa_Tte_Validating(object sender, CancelEventArgs e)
		{
			this.Ma_Tte_Valid();
		}
		void numTy_Gia_Leave(object sender, EventArgs e)
		{
			this.Ma_Tte_Valid();
		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;
			string strFilter = "";

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, strFilter);

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
					//txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
					txtOng_Ba.Text = drLookup["Ten_Dt"].ToString();
					txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();
				}

				//Cap nhat xuong chi tiet
				if (txtMa_Dt.Text != (string)drEditPh["Ma_Dt"])
				{
					foreach (DataRow dr in dtEditCt.Rows)
					{
						if ((string)dr["Ma_Dt"] == (string)drEditPh["Ma_Dt"])
							dr["Ma_Dt"] = txtMa_Dt.Text;
					}
				}
			}

			Common.GatherMemvar(this, ref drEditPh);
			drEditPh.AcceptChanges();
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

		void txtDien_Giai_Validating(object sender, CancelEventArgs e)
		{
			//Cap nhat xuong chi tiet
			if (txtDien_Giai.Text != (string)drEditPh["Dien_Giai"])
			{
				foreach (DataRow dr in dtEditCt.Rows)
				{
					if ((string)dr["Dien_Giai"] == (string)drEditPh["Dien_Giai"])
						dr["Dien_Giai"] = txtDien_Giai.Text;
				}
			}

			Common.GatherMemvar(this, ref drEditPh);
		}

		void frmEditCtTien_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Voucher.DeleteRow(this, dgvEditCt1);

					break;

				case Keys.F4:

					tabControl1.SelectedIndex = (tabControl1.SelectedIndex == 0 ? 1 : 0);
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

		#endregion

		#region DataGridViewEvent

		// Hien notice khi Gotfocus
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
			{
				this.strTk_NoTmp = dgvCell.FormattedValue.ToString();
			}
			else if (strColumnName == "TK_CO")
			{
				this.strTk_CoTmp = dgvCell.FormattedValue.ToString();
			}
			else if (strColumnName == "MA_DT")
			{
				((dgvTextBoxColumn)dgvEditCt.Columns[strColumnName]).bUseAutoDropDown = true;
			}
			else if (strColumnName == "MA_DT_CO")
			{
				((dgvTextBoxColumn)dgvEditCt.Columns[strColumnName]).bUseAutoDropDown = true;
			}
			else if (strColumnName == "DIEN_GIAI")
			{
				if (drCurrent["DIEN_GIAI"] == DBNull.Value || (string)drCurrent["DIEN_GIAI"] == string.Empty)
					drCurrent["DIEN_GIAI"] = drEditPh["DIEN_GIAI"];
			}
			else if (Common.Inlist(strColumnName, "TIEN_NT3, TIEN3, TK_NO3, TK_CO3") && !bCheckDataLockedCtHanTt)
			{
				if ((string)drCurrent["MA_THUE"] == string.Empty)
					dgvEditCt.Columns[strColumnName].ReadOnly = true;
				else
					dgvEditCt.Columns[strColumnName].ReadOnly = false;
			}
			else if (strColumnName == "TIEN3")
			{
				if ((string)drCurrent["MA_THUE"] == string.Empty)
					dgvEditCt.Columns[strColumnName].ReadOnly = true;
				else
				{
					if (txtMa_Tte.Text == Element.sysMa_Tte)
						dgvEditCt.Columns[strColumnName].ReadOnly = true;
					else
						dgvEditCt.Columns[strColumnName].ReadOnly = false;
				}
			}

			bool bNoticeOk = false;
			if (Common.Inlist(strColumnName, "TK_NO, TK_CO, TK_NO3, TK_CO3"))//dgvCell.Tag == null && 
			{
				((dgvTextBoxColumn)dgvEditCt.Columns[strColumnName]).bUseAutoDropDown = true;

				if ((string)drCurrent[strColumnName] != string.Empty) //&& Common.CheckPermissionTk(drCurrent[strColumnName].ToString(), enuPermission_Type.Allow_View))
				{
					this.lbtNotice.Text = Voucher.GetDuCuoi(drCurrent, (string)drCurrent[strColumnName]);
					bNoticeOk = true;
				}
			}

			if (!bNoticeOk)
			{
				if (dgvCell.Tag == null)
				{
					if ("TK_NO,TK_CO,TK_NO3,TK_CO3".Contains(strColumnName))
					{
						if (dgvCell.Value.ToString() != "")
							dgvCell.Tag = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", dgvCell.Value.ToString());
					}
					else if (strColumnName == "MA_DT")
					{
						if (dgvCell.Value.ToString() != "")
							dgvCell.Tag = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", dgvCell.Value.ToString());
					}
					else if (strColumnName == "MA_HD")
					{
						if (dgvCell.Value.ToString() != "")
							dgvCell.Tag = DataTool.SQLGetNameByCode("R81DmHd", "Ma_Hd", "Ten_Hd", dgvCell.Value.ToString());
					}
					else if (strColumnName == "MA_BP")
					{
						if (dgvCell.Value.ToString() != "")
							dgvCell.Tag = DataTool.SQLGetNameByCode("R81DmBp", "Ma_Bp", "Ten_Bp", dgvCell.Value.ToString());
					}
					else if (strColumnName == "MA_KM")
					{
						if (dgvCell.Value.ToString() != "")
							dgvCell.Tag = DataTool.SQLGetNameByCode("R81DmKm", "Ma_Km", "Ten_Km", dgvCell.Value.ToString());
					}
					else if (strColumnName == "MA_VT_SP")
					{
						if (dgvCell.Value.ToString() != "")
							dgvCell.Tag = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", dgvCell.Value.ToString());
					}
				}

				if (dgvCell.Tag != null)
				{
					this.lbtNotice.Text = dgvCell.Value.ToString() + " - " + (string)dgvCell.Tag;
				}
			}

			this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
		}

		//Xu ly phim Enter, Lookup danh muc
		void dgvEditCt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			//Xu ly phim Enter
			if (dgvEditCt.kLastKey == Keys.Enter)
			{
				dgvEditCt.kLastKey = Keys.None;
				
				if (strColumnName == "TK_CO3")
					e.Cancel = !dgvLookupTk(ref dgvCell, strColumnName);

				if (this.CellKeyEnter())
				{
					e.Cancel = true;
					return;
				}
			}

			if (this.ActiveControl == null)
				return;

			if (Common.Inlist(strColumnName, "SO_SERI0,MA_KY_HIEU_HDON,SO_CT0"))
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
			//Xu ly Lookup
			if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;			
				bool bLookup = true;

				if (Common.Inlist(strColumnName, "TK_NO,TK_CO,TK_NO3,TK_CO3"))
					bLookup = dgvLookupTk(ref dgvCell, strColumnName);

				else if (Common.Inlist(strColumnName, "MA_DT"))
					bLookup = dgvLookupMa_Dt(ref dgvCell);
				else if (Common.Inlist(strColumnName, "MA_DT_CO"))
					bLookup = dgvLookupMa_Dt_Co(ref dgvCell);
				else if (strColumnName == "MA_BP")
					bLookup = dgvLookupMa_Bp(ref dgvCell);

				else if (strColumnName == "MA_HD_CO")
					bLookup = dgvLookupMa_Hd_Co(ref dgvCell);

				else if (strColumnName == "MA_KM")
					bLookup = dgvLookupMa_Km(ref dgvCell);

				else if (strColumnName == "MA_VT_SP")
					bLookup = dgvLookupMa_Vt_Sp(ref dgvCell);

				else if (strColumnName == "MA_DT_CBNV")
					bLookup = dgvLookupMa_Dt_CbNv(ref dgvCell);

				else if (strColumnName == "MA_JOB")
					bLookup = dgvLookupMa_Job(ref dgvCell);

				else if (strColumnName == "MA_THUE")
					bLookup = dgvLookupMa_Thue(ref dgvCell);

				else if (strColumnName == "MA_TS")
					bLookup = dgvLookupMa_Ts(ref dgvCell);

				else if (strColumnName == "MA_SO_THUE")
					bLookup = dgvLookupMa_So_Thue(ref dgvCell);

				else if (strColumnName == "MA_KHO")
					bLookup = dgvLookupMa_Kho(ref dgvCell);

				else if (strColumnName == "SO_TKHAI")
					bLookup = dgvLookupSo_TKhai(ref dgvCell);

				if (bLookup == false)
					e.Cancel = true;
			}
			else
				dgvEditCt.CancelEdit();
		}

		// Tinh toan cac Gia tri, cong thuc
		void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			if (bCheckDataLockedCtHanTt)
				return;

			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "TIEN,TIEN_NT,TIEN_NT9"))
			{
				Voucher.Calc_Tien(drCurrent, this);
				Voucher.Update_TTien(this);
			}
			else if (Common.Inlist(strColumnName, "MA_THUE,TIEN_NT3,TIEN3"))
			{
				Voucher.Calc_Thue_Vat(drCurrent, this);
				Voucher.Update_TTien(this);
			}

			this.Ma_Thue_Valid();

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
				dgvCell.Tag = drLookup["Ten_Tk"].ToString();

				if(strMa_Ct == "BN" )
                {
					if (strColumnName == "TK_NO" && drCurrent["TK_NO"].ToString().StartsWith("112"))
					{
						txtTk_NH_B.Text = drLookup["So_Tk_Nh"].ToString();
						txtTen_NH_B.Text = drLookup["Ten_Tk_Nh"].ToString();
						
						dtEditPh.Rows[0]["Ten_Dv_B"] = Element.sysTen_Dvi;
					}
					if (strColumnName == "TK_CO" && txtTk_NH_A.Text == "" && drCurrent["TK_CO"].ToString().StartsWith("112"))
					{
						txtTk_NH_A.Text = drLookup["So_Tk_Nh"].ToString();
						txtTen_NH_A.Text = drLookup["Ten_Tk_Nh"].ToString();
						dtEditPh.Rows[0]["Ten_Dv_A"] = Element.sysTen_Dvi;
					}
				}
				else if(strMa_Ct == "BNV")
                {
					if (strColumnName == "TK_NO" && drCurrent["TK_NO"].ToString().StartsWith("331"))
					{
						//lấy từ danh mục DT
						DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt"].ToString());
						txtTk_NH_B.Text = drDmDt["So_Tk_Nh"].ToString();
						txtTen_NH_B.Text = drDmDt["Ten_Nh"].ToString();
						dtEditPh.Rows[0]["Ten_Dv_B"] = drDmDt["Ten_Dt"].ToString();
					}
				}
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
		private bool dgvLookupMa_Dt_Co(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

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
		private bool dgvLookupMa_Hd_Co(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "", "");

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
				dgvCell.Value = drLookup["Ma_Hd"].ToString();
				dgvCell.Tag = drLookup["Ten_Hd"].ToString();
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

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

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

		private bool dgvLookupMa_Km(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strTk_No = (string)drCurrent["Tk_No"];
			string strTk_Co = (string)drCurrent["Tk_Co"];

			if ((bool)SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM R81DMTK WHERE Tk = '" + strTk_No + "'"))
				bRequire = true;
			else if ((bool)SQLExec.ExecuteReturnValue("SELECT Tk_Km FROM R81DMTK WHERE Tk = '" + strTk_Co + "'"))
				bRequire = true;

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

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strTk_No = (string)drCurrent["Tk_No"];
			string strTk_Co = (string)drCurrent["Tk_Co"];

			if ((bool)SQLExec.ExecuteReturnValue("SELECT Tk_Sp FROM R81DMTK WHERE Tk = '" + strTk_No + "'"))
				bRequire = true;
			else if ((bool)SQLExec.ExecuteReturnValue("SELECT Tk_Sp FROM R81DMTK WHERE Tk = '" + strTk_Co + "'"))
				bRequire = true;

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

		private bool dgvLookupMa_Dt_CbNv(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "", "");

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

		private bool dgvLookupMa_Job(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

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
			if (bCheckDataLockedCtHanTt)
				return true;

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

				if (dgvEditCt1.Columns.Contains("Tien_Nt3"))
					dgvEditCt1.CurrentRow.Cells["Tien_Nt3"].ReadOnly = false;

				if (dgvEditCt1.Columns.Contains("Tien3"))
					dgvEditCt1.CurrentRow.Cells["Tien3"].ReadOnly = false;

				dgvEditCt1.CurrentRow.Cells["Tk_No3"].ReadOnly = true;
				dgvEditCt1.CurrentRow.Cells["Tk_Co3"].ReadOnly = true;
			}
			else
			{
				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Thue"].ToString();
				dgvCell.Tag = drLookup["Ten_Thue"].ToString();
				drCurrent["Thue_GtGt"] = Convert.ToInt32(drLookup["Thue_Suat"]);

				if (dgvEditCt1.Columns.Contains("Tien_Nt3"))
					dgvEditCt1.CurrentRow.Cells["Tien_Nt3"].ReadOnly = false;

				if (dgvEditCt1.Columns.Contains("Tien3"))
					dgvEditCt1.CurrentRow.Cells["Tien3"].ReadOnly = false;

				dgvEditCt1.CurrentRow.Cells["Tk_No3"].ReadOnly = false;
				dgvEditCt1.CurrentRow.Cells["Tk_Co3"].ReadOnly = false;
			}

			this.Ma_Thue_Valid();

			return true;
		}
		private bool dgvLookupSo_TKhai(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("So_TKhai", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["So_TKhai"].ToString();
				dgvCell.Tag = drLookup["So_TKhai"].ToString();

				drCurrent["Ngay_TKhai"] = drLookup["Ngay_TKhai"];

				dgvCell.DataGridView.EndEdit();
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
				dgvCell.Value = drLookup["Ma_Kho"].ToString();
				dgvCell.Tag = drLookup["Ten_Kho"].ToString();

				dgvCell.DataGridView.EndEdit();
			}
			return true;
		}
		private bool dgvLookupMa_So_Thue(ref DataGridViewCell dgvCell)
		{
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;

			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			if (strValue == "/" || strValue == @"\")
			{
				DataRow drLookup = Lookup.ShowLookup("Ma_So_Thue", strValue, bRequire, "", "");

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

					dgvCell.Value = drLookup["Ma_So_Thue"].ToString();
					dgvCell.Tag = drLookup["Ten_DtGtGt"].ToString();

					drCurrent["Ma_So_Thue"] = dgvCell.Value;
					drCurrent["Ten_DtGtGt"] = dgvCell.Tag;
				}
			}
			else if (strValue != string.Empty && (drCurrent["Ma_So_Thue", DataRowVersion.Original] == DBNull.Value || strValue != (string)drCurrent["Ma_So_Thue", DataRowVersion.Original]))
			{
				DataTable dtLookup = SQLExec.ExecuteReturnDt("SELECT * FROM R81DmDt WHERE Ma_So_Thue = '" + strValue + "'");

				if (dtLookup != null)
				{
					if (dtLookup.Rows.Count == 1)
					{
						dgvCell.Value = dtLookup.Rows[0]["Ma_So_Thue"].ToString();
						dgvCell.Tag = dtLookup.Rows[0]["Ten_Dt"].ToString();

						drCurrent["Ma_So_Thue"] = dgvCell.Value;
						drCurrent["Ten_DtGtGt"] = dgvCell.Tag;
					}
					else
					{
						dtLookup = SQLExec.ExecuteReturnDt("SELECT * FROM R81DmDt WHERE Ma_So_Thue = '" + strValue + "'");

						if (dtLookup.Rows.Count >= 1)
						{
							DataRow drLookup = Lookup.ShowLookup("Ma_So_Thue", strValue, bRequire, "");

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

								dgvCell.Value = drLookup["Ma_So_Thue"].ToString();
								dgvCell.Tag = drLookup["Ten_DtGtGT"].ToString();

								drCurrent["Ma_So_Thue"] = dgvCell.Value;
								drCurrent["Ten_DtGtGt"] = dgvCell.Tag;
							}
						}
						else
						{
							if (Common.MsgYes_No("Bạn có chắc chắn thêm mới đối tượng - mã số thuế?"))
							{
								DataRow drNew = dtLookup.NewRow();
								drNew["Ma_Dt"] = drNew["Ma_So_Thue"] = strValue;
								drNew["Ma_Nh_Dt"] = "MA_SO_THUE";

								//RosyList.frmEdit frmEdit = (RosyList.frmEdit)Activator.CreateInstance(Type.GetType("RosyList.frmDmDt_Edit, Rosy.List.DmDt", true));
								RosyList.frmEdit frmEdit = (RosyList.frmEdit)Activator.CreateInstance(Type.GetType("RosyList.frmDmDt_Edit, Rosy.List", true));
								frmEdit.Load(enuEdit.New, drNew);

								if (frmEdit.isAccept)
								{
									dgvEditCt1.CancelEdit();

									dgvCell.Value = drNew["Ma_So_Thue"].ToString();
									dgvCell.Tag = drNew["Ten_Dt"].ToString();

									drCurrent["Ma_So_Thue"] = dgvCell.Value;
									drCurrent["Ten_DtGtGt"] = dgvCell.Tag;
								}
							}
						}
					}
				}
			}

			drCurrent.AcceptChanges();

			return true;
		}

		private bool dgvLookupMa_Ts(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			//frmQuickLookup frmLookup = new frmQuickLookup("R06CtTs", "CtTs");
			DataRow drLookup = Lookup.ShowLookup("Ma_Ts", strValue, bRequire, "", "");

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
				dgvCell.Value = drLookup["Ma_Ts"].ToString();
				dgvCell.Tag = drLookup["Ten_Ts"].ToString();
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

