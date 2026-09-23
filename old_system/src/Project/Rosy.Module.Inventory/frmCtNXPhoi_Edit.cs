using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.Odbc;
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
using RosyList;
using System.Data.SqlClient;

namespace RosyModule.Inventory
{
	public partial class frmCtNXPhoi_Edit : frmVoucher_Edit
	{
		private string strTk_NoTmp = string.Empty;
		private string strTk_CoTmp = string.Empty;
		private string strModule = "05";
        private string strMsg1 = string.Empty;
        private string strMa_Vt_List;
        string strStt_Inherit_Nhap_Tp = string.Empty;
        bool bInherit_Barcode = false;
		#region Contructor

		public frmCtNXPhoi_Edit()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

            this.btImportExcel.Click += new EventHandler(btnImportExcel_Click);
			this.btInherit.Click+=new EventHandler(btInherit_Click);
            this.btTrich_Xuat.Click += new EventHandler(btTrich_Xuat_Click);
            this.btInherit_Nhap.Click += new EventHandler(btInherit_Nhap_Click);

			
			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);			
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtSo_Ct.Validating += new CancelEventHandler(txtSo_Ct_Validating);
            txtCa_Sx.Validating += new CancelEventHandler(txtCa_Sx_Validating);
			txtMa_KhoN.Validating += new CancelEventHandler(txtMa_KhoN_Validating);

			dteNgay_Ct.Validating += new CancelEventHandler(dteNgay_Ct_Validating);
			txtMa_Tte.Validating += new CancelEventHandler(txtMa_Tte_Validating);
			numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);

			dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
			dgvEditCt1.CellLeave += new DataGridViewCellEventHandler(dgvEditCt_CellLeave);
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

			this.Build();
			this.FillData();
			this.Init_Ct();

			Common.ScaterMemvar(this, ref drEditPh);

			txtMa_Tte.bTextChange = false;
			numTy_Gia.bTextChange = false;

            if (drDmCt["Nh_Ct"].ToString() == "1")// nhập
            { btInherit.Visible = false; btTrich_Xuat.Visible = false; btInherit_Nhap.Visible = true; }
            else //xuất
            { btInherit.Visible = true; btTrich_Xuat.Visible = true; btInherit_Nhap.Visible = false; }

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

			if (dgvEditCt2.Columns.Contains("So_Luong")) //Người dùng phải nhập vào cột So_Luong9
				dgvEditCt2.Columns["So_Luong"].ReadOnly = true;

			if (dgvEditCt1.Columns.Contains("MA_VT") && Common.Inlist(strMa_Ct, "PNSB,PXSB,PNPM,PXPM"))
			{
				((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
				((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = " Ma_Nh_Vt IN ('PHOI')";
			}
			else
			{
				((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;

			}

            //if (dgvEditCt1.Columns.Contains("SO_LUONG_NONG") && Common.Inlist(strMa_Ct, "PNSB,PXSB"))
            //    dgvEditCt1.Columns["So_Luong_Nong"].ReadOnly = true;
            //if (dgvEditCt1.Columns.Contains("SO_LUONG_TG") && Common.Inlist(strMa_Ct, "PNSB,PXSB"))
            //    dgvEditCt1.Columns["So_Luong_Tg"].ReadOnly = true;
            //if (dgvEditCt1.Columns.Contains("SO_LUONG_NGUOI") && Common.Inlist(strMa_Ct, "PNSB,PXSB"))
            //    dgvEditCt1.Columns["So_Luong_Nguoi"].ReadOnly = true;
            //if (dgvEditCt1.Columns.Contains("BAREM_NONG") && Common.Inlist(strMa_Ct, "PNSB,PXSB"))
            //    dgvEditCt1.Columns["Barem_Nong"].ReadOnly = true;
            //if (dgvEditCt1.Columns.Contains("SO_LUONG_TB_NONG") && Common.Inlist(strMa_Ct, "PNSB,PXSB"))
            //    dgvEditCt1.Columns["So_Luong_TB_Nong"].ReadOnly = true;

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

			DataColumn dc_Nong = new DataColumn("Sl_Phoi_Nong_Oil", typeof(double));
            dc_Nong.DefaultValue = 0;
			dtEditCt.Columns.Add(dc_Nong);

			DataColumn dc_TG = new DataColumn("Sl_Phoi_TG_Oil", typeof(double));
            dc_TG.DefaultValue = 0;
			dtEditCt.Columns.Add(dc_TG);

			DataColumn dc_Nguoi = new DataColumn("Sl_Phoi_Nguoi_Oil", typeof(double));
            dc_Nguoi.DefaultValue = 0;
			dtEditCt.Columns.Add(dc_Nguoi);

            DataColumn dc_So_Luong = new DataColumn("So_Luong_Oil", typeof(double));
            dc_So_Luong.DefaultValue = 0;
            dtEditCt.Columns.Add(dc_So_Luong);

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
					drCurrent["Ngay_Ct"] = DateTime.Now; //drEdit["Ngay_Ct"] != DBNull.Value ? drEdit["Ngay_Ct"] : DateTime.Now;

					drCurrent["Ma_Tte"] = Element.sysMa_Tte;
					drCurrent["Ty_Gia"] = 1;

					if (dtEditCt.Columns.Contains("Auto_Cost") && (string)drDmCt["Nh_Ct"] == "2")
						drCurrent["Auto_Cost"] = true;

					drCurrent["Deleted"] = false;
					drCurrent["Phan_Loai_Phoi"] = "PH";

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
					// Gán số lượng

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
			else
			{
                txtCa_Sx.Enabled = false;
                dteNgay_Ct.Enabled = false;
				foreach (DataRow drEditCt in dtEditCt.Rows)
				{
					drEditCt["Sl_Phoi_Nong_Oil"] = drEditCt["Sl_Phoi_Nong"];
					drEditCt["Sl_Phoi_TG_Oil"] = drEditCt["Sl_Phoi_TG"];
					drEditCt["Sl_Phoi_Nguoi_Oil"] = drEditCt["Sl_Phoi_Nguoi"];
                    drEditCt["So_Luong_Oil"] = drEditCt["So_Luong_Oil"];
				}
			}
			Voucher.Update_Header(this);
			Voucher.Update_Stt(this, strModule);

            if (dgvEditCt1.Columns.Contains("Dvt"))
                dgvEditCt1.Columns["Dvt"].ReadOnly = true;

            if (strMa_Ct == "PXSB")
            {
                dgvEditCt1.Columns["Ma_Vt"].ReadOnly = true;
                dgvEditCt1.Columns["Ten_Vt"].ReadOnly = true;
                dgvEditCt1.Columns["So_Me"].ReadOnly = true;
                dgvEditCt1.Columns["DDai_Phoi"].ReadOnly = true;
                dgvEditCt1.Columns["Loai_Phoi"].ReadOnly = true;
                dgvEditCt1.Columns["Mac_Thep"].ReadOnly = true;
            }
            
            //Gán Stt nhập TP
            string strSQL = "SELECT MAX(Stt_Inherit_Nhap_Tp) FROM R05CTNXPHOI WHERE Stt = '" + strStt + "'";
            if (this.enuNew_Edit == enuEdit.Edit)
                this.strStt_Inherit_Nhap_Tp = SQLExec.ExecuteReturnValue(strSQL).ToString();
			
            //BindingTTien                      
			numTTien.DataBindings.Clear();
			numTTien_Nt.DataBindings.Clear();
			numTSo_Luong.DataBindings.Clear();
			numTSo_Luong_Cay.DataBindings.Clear();
			numTSL_Phoi_Nong.DataBindings.Clear();
			numTSL_Phoi_TG.DataBindings.Clear();
			numTSL_Phoi_Nguoi.DataBindings.Clear();

			numTTien.DataBindings.Add("Value", dtEditPh, "TTien");
			numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");
			numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");
			numTSo_Luong_Cay.DataBindings.Add("Value", dtEditPh, "TSo_Luong_Cay");
			numTSL_Phoi_Nong.DataBindings.Add("Value", dtEditPh, "TSL_Phoi_Nong");
			numTSL_Phoi_TG.DataBindings.Add("Value", dtEditPh, "TSL_Phoi_TG");
			numTSL_Phoi_Nguoi.DataBindings.Add("Value", dtEditPh, "TSL_Phoi_Nguoi");

			//dtEdiCt_LR
			if ((bool)drDmCt["Is_LR"])
			{
				dtEditCt_LR = DataTool.SQLGetDataTable("R05CTNXLR", enuNew_Edit == enuEdit.New ? " TOP 0 * " : " TOP 1 * ", "Stt = '" + this.strStt + "'", null);

				if (dtEditCt_LR.Rows.Count == 0)
				{
					DataRow drEditCt_LR = dtEditCt_LR.NewRow();
					Common.SetDefaultDataRow(ref drEditCt_LR);
					dtEditCt_LR.Rows.Add(drEditCt_LR);
				}

				
			}
		}

		private void LoadDicName()
		{
			txtMa_Dt.bUseAutoDropDown = true;
			txtMa_Hd.bUseAutoDropDown = true;
			
            

			//txtMa_Nvu
			if (txtMa_Nvu.Text.Trim() != string.Empty)
			{
				lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim());
			}
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
				lbtTen_Hd.Text = DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			else
				lbtTen_Hd.Text = string.Empty;

            //txtCa_Sx
            if (txtCa_Sx.Text.Trim() != string.Empty)
                lbtTen_Ca.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtCa_Sx.Text.Trim());
            else
                lbtTen_Ca.Text = string.Empty;

			//txtMa_KhoN
			if (txtMa_KhoN.Text.Trim() != string.Empty)
			{
				lbtTen_KhoN.Text = DataTool.SQLGetNameByCode("R81DmKho", "Ma_Kho", "Ten_Kho", txtMa_KhoN.Text.Trim());
			}
			else
				lbtTen_KhoN.Text = string.Empty;
		}

		private bool FormCheckValid()
		{
            if (!Voucher.CheckDataLocked_Phoi(Library.StrToDate(this.dteNgay_Ct.Text)))
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
			if (Common.Inlist(strMa_Ct, "PXSB,PNSB") && txtCa_Sx.Text == "")
            {
				Common.MsgOk("Anh chị nhập mã ca trước khi lưu!!!");
				return false;
			}

			//Kiểm tra tồn tại ca sx theo ngày
				if (strMa_Ct == "PXSB" && Common.Inlist(txtCa_Sx.Text.Substring(1), "A,B,C"))
            {
                DataTable dtDmCa = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R81DMCA WHERE Ngay_Sx = '" + dteNgay_Ct.Text + "' AND Ca = '" + txtCa_Sx.Text.Substring(1) + "'");
                if (dtDmCa.Rows.Count == 0)
                {
                    Common.MsgOk("Ngày " + dteNgay_Ct.Text + " không có ca " + txtCa_Sx.Text.PadLeft(1) + ". Bạn vui lòng kiểm tra lại!!!");
                    return false;
                }
                else
                {
                    txtCa_Sx.Text = "";

                }
            }
			//Kiểm tra xuất đi gia công phải nhập mã kho
			if (strMa_Ct == "PXSB" && txtMa_Nvu.Text =="GCPHOI" && txtMa_KhoN.Text == "")
			{
				Common.MsgOk("Phiếu xuất đi gia công vui lòng nhập mã kho. Bạn vui lòng kiểm tra lại!!!");
				return false;
				
			}
			if (txtMa_Nvu.Text == string.Empty)
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa khai báo mã nghiệp vụ" : "Do not register transaction type";
				Common.MsgCancel(strMsg);
				return false;
			}

			//Kiểm tra nghiệp vụ hợp lệ
			foreach (DataRow dr in dtEditCt.Rows)
			{
				if ((bool)dr["Deleted"])
					continue;
				// Kiểm tra So_luong
				if (dr["So_Luong"] != dr["So_Luong9"])
					dr["So_Luong"] = dr["So_Luong9"];
                //Kiễm tra nhập kho
                if (strMa_Ct == "PNSB")
                {
                    //if (Convert.ToDouble(dr["So_Luong_TB_Nguoi"]) != 0 && Convert.ToDouble(dr["SL_Phoi_Nong"]) != 0)
                    //{
                    //    string strMsg = "Trong ca không có phôi nạp nóng, nhưng số lượng phôi nóng tại dòng "+ dr["So_Me"].ToString() +" khác 0. Không cho lưu dữ liệu";
                    //    Common.MsgCancel(strMsg);
                    //    return false;
                    //}

                    //if (Convert.ToDouble(dr["So_Luong_TB_Nguoi"]) != 0 && Convert.ToDouble(dr["So_Luong_TB_Nong"]) != 0)
                    //{
                    //    string strMsg = "Trong ca có phôi nạp nóng, Khối lượng trung bình nguội khác 0. Không cho lưu dữ liệu";
                    //    Common.MsgCancel(strMsg);
                    //    return false;
                    //}
                }
                //Kiểm tra tồn kho
                if ((string)drDmCt["Nh_Ct"] == "2")
                {
                    double dbSo_Luong = Convert.ToDouble(dr["So_Luong_Cay"]);
                    double dbTon_Cuoi = 0;
                    Voucher.GetTonCuoi_Phoi(dr, ref dbTon_Cuoi);

                    if (dbSo_Luong > dbTon_Cuoi)
                    {
                        string strMsg = string.Empty;

                        if (Element.sysLanguage == enuLanguageType.Vietnamese)
                            strMsg = "Số lượng xuất của	mẻ " + dr["So_Me"] + " số lượng xuất " + dbSo_Luong.ToString("N2") + " lớn hơn số lượng tồn: " + dbTon_Cuoi.ToString("N2");

                        Common.MsgCancel(strMsg);
                        return false;

                    }
                }

				//Kiem tra so luong 
				if (Common.InlistLike(strMa_Ct,"PNSB,PXSB") && Convert.ToDouble(drCurrent["So_Luong_Cay"]) != Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) + Convert.ToDouble(drCurrent["SL_Phoi_TG"]) + Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]) - Convert.ToDouble(drCurrent["SL_Phoi_Hl"]) - Convert.ToDouble(drCurrent["SL_Phoi_Xau"]))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tổng số lượng khác số lượng cây tại mẻ '"+ dr["So_Me"] +"' độ dài '"+ dr["DDai_Phoi"] +"'" : "Do not register transaction type";
					Common.MsgCancel(strMsg);
					return false;
				}
				#region Kiểm tra tính hợp lệ của định nghĩa nghiệp vụ
				//foreach (DataColumn dc in drDmNvu.Table.Columns)
				//{
				//    if (dc.ColumnName.EndsWith("_RULE") && drDmNvu.Table.Columns.Contains(dc.ColumnName.Replace("_RULE", "")))
				//    {
				//        string strRule_Name = dc.ColumnName;
				//        string strColumnName = strRule_Name.Replace("_RULE", "");

				//        if (drDmNvu[strColumnName].ToString() != "")
				//        {
				//            //1-Bắt buộc, 2-Cho phép sửa lại phần đuôi, 3-Cho phép thay đổi
				//            if ((drDmNvu[strRule_Name].ToString() == "1") && !(drDmNvu[strColumnName].ToString().Split(',').Any(strValue => strValue == dr[strColumnName].ToString())))
				//            {
				//                Common.MsgCancel("Nhập liệu [" + Languages.GetLanguage(strColumnName) + "] không đúng với định nghĩa nghiệp vụ!");
				//                return false;
				//            }
				//            else if ((drDmNvu[strRule_Name].ToString() == "2") && !(drDmNvu[strColumnName].ToString().Split(',').Any(strValue => dr[strColumnName].ToString().StartsWith(strValue))))
				//            {
				//                Common.MsgCancel("Nhập liệu [" + Languages.GetLanguage(strColumnName) + "] không đúng với định nghĩa nghiệp vụ!");
				//                return false;
				//            }
				//        }
				//    }
				//}
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
					//if ((bool)drDmTkNo["Tk_Sp"] && dr["Ma_Vt_Sp"].ToString() == "")
					//{
					//    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk nợ yêu cầu Mã sản phẩm" : "Debit account require Product code";
					//    Common.MsgCancel(strMsg);
					//    return false;
					//}
					//if ((bool)drDmTkNo["Tk_Km"] && dr["Ma_Km"].ToString() == "")
					//{
					//    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk nợ yêu cầu Mã khoản mục" : "Debit account require Category code";
					//    Common.MsgCancel(strMsg);
					//    return false;
					//}
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
					//if ((bool)drDmTkCo["Tk_Sp"] && dr["Ma_Vt_Sp"].ToString() == "")
					//{
					//    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk có yêu cầu Mã sản phẩm" : "Credit account require Product code";
					//    Common.MsgCancel(strMsg);
					//    return false;
					//}
					//if ((bool)drDmTkCo["Tk_Km"] && dr["Ma_Km"].ToString() == "")
					//{
					//    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tk có yêu cầu Mã khoản mục" : "Credit account require Category code";
					//    Common.MsgCancel(strMsg);
					//    return false;
					//}
				}
				#endregion

				if (dtEditCt.Columns.Contains("Tien") && Convert.ToDouble(dr["Tien"]) != 0 && Convert.ToDouble(dr["So_Luong"]) != 0 && ((string)dr["Tk_No"] == string.Empty || (string)dr["Tk_Co"] == string.Empty))
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Hạch toán không hợp lệ" : "Transaction invalid";
					Common.MsgCancel(strMsg);
					return false;
				}

				dr["Posted"] = this.drDmNvu["Posted"];
			}

			return true;
		}

		public override bool Save()
		{
			dtEditCt.AcceptChanges();

			Common.GatherMemvar(this, ref this.drEditPh);
			Voucher.Update_Detail(this);
			foreach (DataRow dr in dtEditCt.Select("Ma_Vt = ' '"))
			{
				if (dr["Ma_Vt"] == "")
					dr["Deleted"] = 1;
			}
			if (!FormCheckValid())
				return false;

			Voucher.Update_Log(this);
			Voucher.Update_TTien(this);
			Voucher.Update_Stt(this, strModule);
			Voucher.UpdateSo_Ct(this);

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
					Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

				drEdit = drEditPh;
			}
            //
            if (Voucher.SQLUpdateCt(this))
            {
                // chuyển DL vào kế toán
                Hashtable ht = new Hashtable();
                ht.Add("STT_INHERIT_NHAP_TP", this.strStt_Inherit_Nhap_Tp);
                ht.Add("STT", strStt);
                ht.Add("MA_DVCS", Element.sysMa_DvCs);
                SQLExec.Execute("sp_Import_Phoi_Auto", ht, CommandType.StoredProcedure);
                
                // cập nhật vào DLSX xuất phôi
                Hashtable htDLSX = new Hashtable();
                htDLSX.Add("STT", strStt);
                SQLExec.Execute("sp_Update_XuatPhoiDLSX", htDLSX, CommandType.StoredProcedure);
                return true;
            }
			return false ;
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
					dgvEditCt2.Columns["TIEN3"].Visible = false;

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

				if (dgvEditCt2.Columns.Contains("TIEN3"))
					dgvEditCt2.Columns["TIEN3"].Visible = true;

				if (dgvEditCt2.Columns.Contains("TIEN5"))
					dgvEditCt2.Columns["TIEN5"].Visible = true;

				if (dgvEditCt2.Columns.Contains("TIEN6"))
					dgvEditCt2.Columns["TIEN6"].Visible = true;
			}

			if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange || numTy_Gia.bTextChange)
			{
				Voucher.Update_Detail(this);
				Voucher.Calc_Tien_All(this);

				if (txtMa_Tte.bTextChange)
					txtMa_Tte.bTextChange = false;
			}

			numTTien_Nt.Scale = strMa_Tte == Element.sysMa_Tte ? 0 : 2;

			Voucher.FormatTien_Nt(dgvEditCt1, strMa_Tte);
			Voucher.FormatTien_Nt(dgvEditCt2, strMa_Tte);

            if (strMa_Ct == "PNSB" || strMa_Ct == "PXSB")
            {
                if (dgvEditCt1.Columns.Contains("So_Luong"))
                    dgvEditCt1.Columns["So_Luong"].DefaultCellStyle.Format = "N0";
                if (dgvEditCt1.Columns.Contains("So_Luong9"))
                    dgvEditCt1.Columns["So_Luong9"].DefaultCellStyle.Format = "N0";
            }

			dgvEditCt1.ResizeGridView();
			dgvEditCt2.ResizeGridView();
		}

		private bool CellKeyEnter()
		{//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc

			if (dgvEditCt1.CurrentCell == null)
				return false;

			DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
			string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

			//Xuống dòng
			string strColumnLast = (string)SQLExec.ExecuteReturnValue("SELECT TOP 1 ISNULL(Column_ID, '') FROM R00COLUMN WHERE ZONE LIKE '" + dgvEditCt1.strZone + "' AND Visible = 1 ORDER BY Stt DESC", CommandType.Text);

			if (strCurrentColumn == strColumnLast)
			{
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

			#region Enter tai Tk_No, Tk_Co
			if (Common.Inlist(strCurrentColumn, "TEN_VT"))
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				if (drCurrent["Ma_Vt"] == DBNull.Value || (string)drCurrent["Ma_Vt"] == string.Empty && dgvCell.OwningRow.Index != 0)
				{
					bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;

					if (bdsEditCt.Count > 1)
					{
						bdsEditCt.RemoveCurrent();
						//dtEditCt.AcceptChanges();
					}

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

					//if (dgvEditCt1.bIsCurrentLastRow)
					//{
					//    if (!Voucher.AddRow(this))
					//        this.SelectNextControl(dgvEditCt1, true, true, true, true);
					//    else
					//    {
					//        dgvEditCt1.FocusNextFirstCell();
					//        return true;
					//    }
					//}
					//else
					//    dgvEditCt1.FocusNextFirstCell();
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
						dgvEditCt1.FocusNextFirstCell();

					return true;
				}

				return false;
			}

			//if (Common.Inlist(strCurrentColumn, "PHOI_NGAN")&&(strMa_Ct =="PNSB"||strMa_Ct =="PXSB"))
			//{
			//        if (dgvEditCt1.bIsCurrentLastRow)
			//        {
			//            if (!Voucher.AddRow(this))
			//                this.SelectNextControl(dgvEditCt1, true, true, true, true);
			//            else
			//            {
			//                dgvEditCt1.FocusNextFirstCell();
			//                return true;
			//            }
			//        }
			//        else
			//            dgvEditCt1.FocusNextFirstCell();
			//}
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

			}
			      
		}

        private void TrichXuatPN()
        {
            Voucher.Update_Header(this);
            Voucher.Update_Detail(this);
			string strMa_Nvu = "PXPM";
            frmInherit_PNSB frm = new frmInherit_PNSB();
            frm.Load(this);

            if (frm.Is_Accept)
            {
				Voucher.Inherit_PNSB_SetData(frm, this);

				Voucher.Update_DmNvu(this);
                Voucher.Update_Detail(this);
                Voucher.Update_TTien(this);

				numTSL_Phoi_PH.Value = Common.SumDCValue(dtEditCt, "So_Luong_Cay", "Phan_Loai_Phoi = 'PH'");
				numTSL_Phoi_CXL.Value = Common.SumDCValue(dtEditCt, "So_Luong_Cay", "Phan_Loai_Phoi = 'CXL'");
				numTSL_Phoi_PP.Value = Common.SumDCValue(dtEditCt, "So_Luong_Cay", "Phan_Loai_Phoi = 'PP'");
			}
        }

       

        private void DataGridView_Language()
        {
            if (dgvEditCt1.Columns.Contains("So_Luong9") && Common.Inlist(strMa_Ct, "PNSB,PXSB,PNPM,PXPM"))
                dgvEditCt1.Columns["So_Luong9"].HeaderText = "Khối lượng";
            if (dgvEditCt1.Columns.Contains("So_Luong_Cay") && Common.Inlist(strMa_Ct, "PNSB,PXSB,PNPM,PXPM"))
                dgvEditCt1.Columns["So_Luong_Cay"].HeaderText = "Số cây";
			if (dgvEditCt1.Columns.Contains("Ghi_Chu") && Common.Inlist(strMa_Ct, "PNSB"))
				dgvEditCt1.Columns["Ghi_Chu"].HeaderText = "Điểm KPH";
			if (dgvEditCt1.Columns.Contains("Ghi_Chu") && Common.Inlist(strMa_Ct, "PXSB"))
				dgvEditCt1.Columns["Ghi_Chu"].HeaderText = "Lý do hồi lò";

            if (dgvEditCt1.Columns.Contains("DDai_Phoi") && strMa_Ct == "PNSB")
                dgvEditCt1.Columns["DDai_Phoi"].HeaderText = "Độ dài TB";
        }

		#endregion

		#region Su kien

		#region FormEvent

		void txtMa_Nvu_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nvu.Text.Trim();
			bool bRequire = true;
			string strFilter = "(CHARINDEX('," + strMa_Ct + ",', ',' + Ma_Ct + ',', 0) > 0 OR Ma_Ct = '*')";
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
        void txtCa_Sx_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtCa_Sx.Text.Trim();
            bool bRequire = false;
            DataRow drLookup;
            if (strMa_Ct == "PXSB" && txtMa_Nvu.Text != "XKPHOI")
            {
                System.Collections.Hashtable htField = new System.Collections.Hashtable();
                htField.Add("strType", "CA_SX");
                drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'CA_SX'", "", htField);
            }
            else
                drLookup = Lookup.ShowLookup("CA_SX", txtCa_Sx.Text, bRequire, "Ngay_Sx = '"+ dteNgay_Ct.Text +"'");
            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtCa_Sx.Text = string.Empty;
                lbtTen_Ca.Text = string.Empty;
            }
            else
            {
                ////Kiểm tra tồn tại ca sx theo ngày
                //if (strMa_Ct == "PXSB" && Common.Inlist(drLookup["Type_ID"].ToString().Substring(1),"A,B,C"))
                //{
                //    DataTable dtDmCa = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R81DMCA WHERE Ngay_Sx = '" + dteNgay_Ct.Text + "' AND Ca = '" + drLookup["Type_ID"].ToString().Substring(1) + "'");
                //    if (dtDmCa.Rows.Count == 0)
                //        Common.MsgOk("Ngày " + dteNgay_Ct.Text + " không có ca " + drLookup["Type_ID"].ToString().Substring(1) + ". Bạn vui lòng kiểm tra lại!!!");
                //    else
                //    {
                //        txtCa_Sx.Text = drLookup["Type_ID"].ToString();
                //        lbtTen_Ca.Text = drLookup["Type_Name"].ToString();
                //    }
                //}
                if (strMa_Ct == "PXSB" && Common.InlistLike(txtMa_Nvu.Text, "XBPHOI,GCPHOI"))
                {
                    txtCa_Sx.Text = drLookup["Type_ID"].ToString();
                    lbtTen_Ca.Text = drLookup["Type_Name"].ToString();
                }
                else
                {
                    txtCa_Sx.Text = drLookup["Ca_Sx"].ToString();
                    lbtTen_Ca.Text = drLookup["Ca_Sx"].ToString();
                }
            }
        }
		void txtMa_KhoN_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_KhoN.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_KhoN.Text = string.Empty;
			}
			else
			{
				txtMa_KhoN.Text = drLookup["Ma_Kho"].ToString();
				lbtTen_KhoN.Text = drLookup["Ten_Kho"].ToString();
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
		
		void btnImportExcel_Click(object sender, EventArgs e)
		{
			if(Common.Inlist(strMa_Ct, "PNPM,PXPM"))
				Voucher.ImportExcelPhoiMua(this);
			else
				Voucher.ImportExcelCtVT(this);
		}

		void btHanTt_Click(object sender, EventArgs e)
		{
			Voucher.HanTt(this);
		}

		
		void btInherit_Click(object sender, EventArgs e)
		{
			this.InheritVoucher();
			this.txtMa_Nvu_Validating(null, null);
		}

        void btInherit_Nhap_Click(object sender, EventArgs e)
        {
            bInherit_Barcode = true;
            LockColumn(bInherit_Barcode);

            Voucher.Update_Header(this);
            Voucher.Update_Detail(this);

            frmInherit_PNSB frm = new frmInherit_PNSB();
            frm.Load(this, txtCa_Sx.Text, Library.StrToDate(dteNgay_Ct.Text));

            if (frm.Is_Accept)
            {
                Voucher.Inherit_BarcodePH_SetData(frm, this);

                //Voucher.Update_DmNvu(this);
                Voucher.Update_Detail(this);
                //Voucher.Update_TTien(this);
            }
        }


        void btTrich_Xuat_Click(object sender, EventArgs e)
        {
            this.TrichXuatPN();
        }
        void LockColumn(bool bLock)
        {
            if (bLock) // nếu là kế thừa từ nhập kho phôi
            {
                //if (dgvEditCt1.Columns.Contains("SL_PHOI_NONG") && Common.Inlist(strMa_Ct, "PNSB"))
                //    dgvEditCt1.Columns["SL_Phoi_Nong"].ReadOnly = true;
            }
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
						
					}
				}
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

				
			}

			Voucher.Update_Detail(this, "Ma_Dt");
		}

		
		

		
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
					break;

				case Keys.F6: //Insert dòng

                    Voucher.AddRowMiddle(this, "Ma_Vt,Ten_Vt, Dvt,So_Me,So_Luong_TB_Nong,So_Luong_TB_Nguoi,Loai_Phoi,Phan_Loai_Phoi");

					break;

				case Keys.I: //Insert dòng

					if (!e.Alt && e.Control && !e.Shift) //Ctrl+I
						Voucher.AddRow(this);
					else if (!e.Alt && e.Control && e.Shift) //Ctrl+Shift+I
						Voucher.CopyNewRow(this);

					break;

				case Keys.S:
					if (e.Control)
					{
						this.Save();
						Common.MsgOk("Đã lưu xong!");
					}

					break;

                case Keys.F9:
                    if (this.strMa_Ct == "PNSB")
                    {
                        //this.ImportAccess();
                    }
                    else if(this.strMa_Ct == "PXSB")
                        this.TrichXuatPN();
                    break;
                    

				case Keys.F10:
					this.InheritVoucher();
					break;

				

			}

			if (!this.dgvEditCt1.Focused)
				this.dgvEditCt1.ClearSelection();
		}

		#endregion

		#region DataGridViewEvent

		//Hiển thị Notice
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

				dicName.SetValue("TON_CUOI", this.lbtNotice.Text);
			}
			else if (Common.Inlist(strColumnName, "TEN_VT,DVT"))
			{
				this.lbtNotice.Text = dicName.GetValue("TON_CUOI");
			}
			else if (Common.Inlist(strColumnName, "TK_NO, TK_CO"))
			{
				if ((string)drCurrent[strColumnName] != string.Empty)
					this.lbtNotice.Text = Voucher.GetDuCuoi(drCurrent, (string)drCurrent[strColumnName]);
			}
			else if (dgvCell.Tag != null)
				this.lbtNotice.Text = (string)dgvCell.Tag;

           this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
		}

		//Cai dat Lookup, Enter xuống dòng
		void dgvEditCt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			//drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			//DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
			//string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			//dgvVoucher dgvEditCt = (dgvVoucher)sender;
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

			if (Common.Inlist(strColumnName, "SO_ME"))
			{
				string strSo_Me = dgvCell.FormattedValue.ToString().Trim();
				strSo_Me = strSo_Me.ToUpper();
				dgvEditCt.CancelEdit();
				dgvCell.Value = strSo_Me;
			}


			if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
			{
				bool bLookup = true;

				if (Common.Inlist(strColumnName, "TK_NO,TK_CO"))
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

				else if (strColumnName == "MA_VT")
					bLookup = dgvLookupMa_Vt(ref dgvCell);

				else if (strColumnName == "MA_KHO")
					bLookup = dgvLookupMa_Kho(ref dgvCell);

				else if (strColumnName == "MA_KHON")
					bLookup = dgvLookupMa_KhoN(ref dgvCell);

				else if (strColumnName == "MA_VTN")
					bLookup = dgvLookupMa_VtN(ref dgvCell);

				else if (strColumnName == "LOAI_DAC_DIEM")
					bLookup = dgvLookupLoai_Dac_Diem(ref dgvCell);

				else if (strColumnName == "PHAN_LOAI_PHOI")
					bLookup = dgvLookupPhan_Loai_Phoi(ref dgvCell);

				else if (strColumnName == "MA_SIZE_SP")
					bLookup = dgvLookupMa_Size_Sp(ref dgvCell);
				
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
            // xu ly so me
            if (Common.Inlist(strColumnName, "SO_ME") && (strMa_Ct == "PNSB"))
            {
                string strSo_Me = (string)drCurrent["So_Me"];
				string strCong = "0000"; int So_Me; int dbLen; int dbCong;
				if (strSo_Me.Length != 0 && !(bool)drCurrent["Is_Tang_Me"])
                {
                    if (Library.StrToDate(dteNgay_Ct.Text) >= Library.StrToDate("01/01/2026"))
                    {
						strCong = "00000";
						So_Me = int.Parse(strSo_Me.Substring(2)) + 1;
						dbLen = So_Me.ToString().Length;// + So_Me.ToString().Length;
						dbCong = 5 - dbLen;
						drCurrent["So_Me"] = strSo_Me.Substring(0, 2) + strCong.Substring(0, dbCong) + Convert.ToString(So_Me);
					}
                    else
                    {
						strCong = "0000";
						So_Me = int.Parse(strSo_Me.Substring(1)) + 1;
						dbLen = strSo_Me.Substring(0, 1).Length + So_Me.ToString().Length;
						dbCong = 5 - dbLen;
						drCurrent["So_Me"] = strSo_Me.Substring(0, 1) + strCong.Substring(0, dbCong) + Convert.ToString(So_Me);
					}

				}
            }

			if (Common.Inlist(strColumnName, "SL_PHOI_NONG,SL_PHOI_NGUOI,SL_PHOI_TG,SO_LUONG_TB_NONG,SO_LUONG_TB_NGUOI,SO_LUONG_CAY,SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN"))
            {
                Voucher.Calc_So_Luong(drCurrent, this);
                Voucher.Update_TTien(this);

                //Kiểm tra tồn kho
                if ((string)drCurrent["Ma_Vt"] != string.Empty && (string)drCurrent["So_Me"] != string.Empty &&
                    (string)drDmCt["Nh_Ct"] == "2" && Common.Inlist(strColumnName, "SO_LUONG_CAY"))
                {
                    double dbSo_Luong = Convert.ToDouble(drCurrent["So_Luong_Cay"]);
                    double dbTon_Cuoi = 0;
                    Voucher.GetTonCuoi_Phoi(drCurrent, ref dbTon_Cuoi);

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
                if (strMa_Ct == "PNSB")// xử lý nhập
                {
                    double dbBarem = 0;
                    Hashtable ht = new Hashtable();
                    ht.Add("MA_VT", drCurrent["Ma_Vt"]);
                    ht.Add("NGAY_CT", drCurrent["Ngay_Ct"]);
                    ht.Add("SO_ME", "");
                    dbBarem = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBaremPhoi(@Ma_Vt,@Ngay_Ct, @So_Me)", ht, CommandType.Text));

                    
                    if (!Convert.ToBoolean(drCurrent["Is_Ngan"]))
                    {
                        drCurrent["So_Luong_Nong"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) * Convert.ToDouble(drCurrent["So_Luong_TB_Nong"]), MidpointRounding.AwayFromZero);
                        drCurrent["So_Luong_TG"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Tg"]) * Convert.ToDouble(drCurrent["So_Luong_TB_Nguoi"]), MidpointRounding.AwayFromZero);
                        drCurrent["So_Luong_Nguoi"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]) * Convert.ToDouble(drCurrent["So_Luong_TB_Nguoi"]), MidpointRounding.AwayFromZero);
                        
                        if (Convert.ToDouble(drCurrent["So_Luong_TB_Nguoi"])!= 0)
                            drCurrent["DDai_Phoi"] = Math.Round(Convert.ToDouble(drCurrent["So_Luong_TB_Nguoi"]) / dbBarem, 4);
                        else
                            drCurrent["DDai_Phoi"] = Math.Round(Convert.ToDouble(drCurrent["So_Luong_TB_Nong"]) / dbBarem, 4);

                    }
                    else  // xử lý các trường hợp nhập phôi ngắn
                    {


                        if (strMa_Ct == "PNSB")
                        {

                            //Bang bsung tính KL PHÔI Nóng, Nguội, TG
                            drCurrent["So_Luong_Nong"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) * dbBarem * Convert.ToDouble(drCurrent["DDai_Phoi"]), 0);
                            drCurrent["So_Luong_Tg"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Tg"]) * dbBarem * Convert.ToDouble(drCurrent["DDai_Phoi"]), 0);
                            drCurrent["So_Luong_Nguoi"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]) * dbBarem * Convert.ToDouble(drCurrent["DDai_Phoi"]), 0);
                        }
                    }
                    drCurrent["So_Luong_Cay"] = Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) + Convert.ToDouble(drCurrent["SL_Phoi_Tg"]) + Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]);
                    drCurrent["So_Luong9"] = drCurrent["So_Luong"] = Convert.ToDouble(drCurrent["So_Luong_Nong"]) + Convert.ToDouble(drCurrent["So_Luong_Tg"]) + Convert.ToDouble(drCurrent["So_Luong_Nguoi"]);
                }
                else // xử lý phần xuất
                {

					if (Common.InlistLike(strMa_Ct, "PXSB"))
					{
						if (string.IsNullOrEmpty(drCurrent["Ma_Vt"].ToString()))
							return;

						DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", (string)drCurrent["Ma_Vt"]);
						if (drDmVt == null)
							return;
						drCurrent["Loai_Phoi"] = drDmVt["Loai_Phoi"];
						drCurrent["Mac_Thep"] = drDmVt["Mac_Thep"];
						//drCurrent["Phoi_Ngan"] = drDmVt["Phoi_Ngan"];


						double dbSo_Luong_Cay = Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) + Convert.ToDouble(drCurrent["SL_Phoi_TG"]) + Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]) - Convert.ToDouble(drCurrent["SL_Phoi_Hl"]) - Convert.ToDouble(drCurrent["SL_Phoi_Xau"]);
						//Kiểm tra nếu So luong cay vuot qua so luong cay cho phep
						if (dbSo_Luong_Cay > Convert.ToDouble(drCurrent["So_Luong_Cl_Max"]) && Convert.ToDouble(drCurrent["So_Luong_Cl_Max"]) != 0 && drCurrent["So_Me"] != string.Empty)
						{
							Common.MsgOk("Số lượng cây vượt quá số lượng cây tồn");

							drCurrent["SL_Phoi_Nong"] = drCurrent["SL_Phoi_Nong_Oil"] == DBNull.Value ? 0 : Convert.ToInt16(drCurrent["SL_Phoi_Nong_Oil"]);
							drCurrent["SL_Phoi_TG"] = drCurrent["SL_Phoi_TG_Oil"] == DBNull.Value ? 0 : Convert.ToInt16(drCurrent["SL_Phoi_TG_Oil"]);
							drCurrent["SL_Phoi_Nguoi"] = drCurrent["SL_Phoi_Nguoi_Oil"] == DBNull.Value ? 0 : Convert.ToInt16(drCurrent["SL_Phoi_Nguoi_Oil"]);
							drCurrent["So_Luong"] = drCurrent["So_Luong_Oil"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["So_Luong_Oil"]);
						}
						else
							drCurrent["So_Luong_Cay"] = Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) + Convert.ToDouble(drCurrent["SL_Phoi_TG"]) + Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]) - Convert.ToDouble(drCurrent["SL_Phoi_Hl"]) - Convert.ToDouble(drCurrent["SL_Phoi_Xau"]);


						if ((Convert.ToDouble(drCurrent["So_Luong_Cay"]) <= Convert.ToDouble(drCurrent["So_Luong_Cl_Max"]) && strMa_Ct == "PXSB"))
						{
							double dbBarem = 0;
							Hashtable ht = new Hashtable();
							ht.Add("MA_VT", drCurrent["Ma_Vt"]);
							ht.Add("NGAY_CT", drCurrent["Ngay_Ct"]);
							ht.Add("SO_ME", drCurrent["So_Me"]);
							dbBarem = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBaremPhoi(@Ma_Vt,@Ngay_Ct, @So_Me)", ht, CommandType.Text));
							// xử lý dữ liệu có tính theo KL TB CA
							if (Convert.ToDouble(drCurrent["So_Luong_Tb_Nong"]) == 0 || Convert.ToDouble(drCurrent["So_Luong_Tb_Nong"]) == 0) // là phôi ngắn tính theo barem
							{
								drCurrent["So_Luong_Nong"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) * dbBarem * Convert.ToDouble(drCurrent["DDai_Phoi"]), 0);
								drCurrent["So_Luong_Tg"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Tg"]) * dbBarem * Convert.ToDouble(drCurrent["DDai_Phoi"]), 0);
								drCurrent["So_Luong_Nguoi"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]) * dbBarem * Convert.ToDouble(drCurrent["DDai_Phoi"]), 0);
								drCurrent["So_Luong9"] = drCurrent["So_Luong"] = Math.Round(Convert.ToDouble(drCurrent["So_Luong_Cay"]) * dbBarem * Convert.ToDouble(drCurrent["DDai_Phoi"]), 0);
							}
							else if (Convert.ToDouble(drCurrent["So_Luong_Tb_Nong"]) != 0 && Convert.ToDouble(drCurrent["So_Luong_Tb_Nguoi"]) != 0)
							{
								drCurrent["So_Luong_Nong"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) * Convert.ToDouble(drCurrent["So_Luong_Tb_Nong"]), 0);
								drCurrent["So_Luong_Tg"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Tg"]) * Convert.ToDouble(drCurrent["So_Luong_Tb_Nguoi"]), 0);
								drCurrent["So_Luong_Nguoi"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]) * Convert.ToDouble(drCurrent["So_Luong_Tb_Nguoi"]), 0);
							}
							else if (Convert.ToDouble(drCurrent["So_Luong_Tb_Nong"]) != 0 && Convert.ToDouble(drCurrent["So_Luong_Tb_Nguoi"]) == 0)
							{
								drCurrent["So_Luong_Nong"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) * Convert.ToDouble(drCurrent["So_Luong_Tb_Nong"]), 0);
								drCurrent["So_Luong_Tg"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Tg"]) * Convert.ToDouble(drCurrent["So_Luong_Tb_Nong"]), 0);
								drCurrent["So_Luong_Nguoi"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]) * Convert.ToDouble(drCurrent["So_Luong_Tb_Nong"]), 0);
							}

							else if (Convert.ToDouble(drCurrent["So_Luong_Tb_Nong"]) == 0 && Convert.ToDouble(drCurrent["So_Luong_Tb_Nguoi"]) != 0)
							{
								drCurrent["So_Luong_Nong"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) * Convert.ToDouble(drCurrent["So_Luong_Tb_Nguoi"]), 0);
								drCurrent["So_Luong_Tg"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Tg"]) * Convert.ToDouble(drCurrent["So_Luong_Tb_Nguoi"]), 0);
								drCurrent["So_Luong_Nguoi"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]) * Convert.ToDouble(drCurrent["So_Luong_Tb_Nguoi"]), 0);
							}
							else if (Convert.ToBoolean(drCurrent["Is_Ngan"]))
							{
								drCurrent["So_Luong_Nong"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) * dbBarem * Convert.ToDouble(drCurrent["DDai_Phoi"]), 0);
								drCurrent["So_Luong_Nguoi"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]) * dbBarem * Convert.ToDouble(drCurrent["DDai_Phoi"]), 0);
								drCurrent["So_Luong_Tg"] = Math.Round(Convert.ToDouble(drCurrent["SL_Phoi_Tg"]) * dbBarem * Convert.ToDouble(drCurrent["DDai_Phoi"]), 0);
							}

							drCurrent["So_Luong9"] = drCurrent["So_Luong"] = Convert.ToDouble(drCurrent["So_Luong_Nong"]) + Convert.ToDouble(drCurrent["So_Luong_Tg"]) + Convert.ToDouble(drCurrent["So_Luong_Nguoi"]);
							drCurrent["So_Luong_Cay"] = Convert.ToDouble(drCurrent["SL_Phoi_Nong"]) + Convert.ToDouble(drCurrent["SL_Phoi_Tg"]) + Convert.ToDouble(drCurrent["SL_Phoi_Nguoi"]);//- Convert.ToDouble(drCurrent["SL_Phoi_Hl"]) - Convert.ToDouble(drCurrent["SL_Phoi_Xau"]); ;

						}

						if (Convert.ToDouble(drCurrent["So_Luong_Cay"]) == Convert.ToDouble(drCurrent["So_Luong_Cl_Max"]) && strMa_Ct == "PXSB" && Convert.ToDouble(drCurrent["So_Luong_Oil"]) != 0)
						{
							drCurrent["So_Luong9"] = drCurrent["So_Luong"] = Convert.ToDouble(drCurrent["So_Luong_Oil"]);
						}
					}
					else if (Common.InlistLike(strMa_Ct, "PNPM,PXPM"))
					{
						if (string.IsNullOrEmpty(drCurrent["Ma_Vt"].ToString()))
							return;

						DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", (string)drCurrent["Ma_Vt"]);
						if (drDmVt == null)
							return;
						drCurrent["Loai_Phoi"] = drDmVt["Loai_Phoi"];
						drCurrent["Mac_Thep"] = drDmVt["Mac_Thep"];
						if (strMa_Ct == "PXPM" && Convert.ToDouble(drCurrent["So_Luong_Cay"]) > Convert.ToDouble(drCurrent["So_Luong_Cl_Max"]) && Convert.ToDouble(drCurrent["So_Luong_Cl_Max"]) != 0 && drCurrent["So_Me"] != string.Empty)
							Common.MsgOk("Số lượng cây vượt quá số lượng cây tồn");

						drCurrent["So_Luong9"] = drCurrent["So_Luong"] = Math.Round(Convert.ToDouble(drCurrent["So_Luong_Cay"]) * Convert.ToDouble(drCurrent["So_Luong_Tb_Nguoi"]), 0);
					}
                }

			

            
			
                
            if (Common.Inlist(strColumnName, "SL_PHOI_NONG,SL_PHOI_TG,SL_PHOI_NGUOI"))
			{
				numTSL_Phoi_Nong.Value = Common.SumDCValue(dtEditCt, "Sl_Phoi_Nong","");
				numTSL_Phoi_TG.Value = Common.SumDCValue(dtEditCt, "Sl_Phoi_TG", "");
				numTSL_Phoi_Nguoi.Value = Common.SumDCValue(dtEditCt, "Sl_Phoi_Nguoi", "");

				numTSL_Phoi_PH.Value = Common.SumDCValue(dtEditCt, "So_Luong_Cay", "Phan_Loai_Phoi = 'PH'");
				numTSL_Phoi_CXL.Value = Common.SumDCValue(dtEditCt, "So_Luong_Cay", "Phan_Loai_Phoi = 'CXL'");
				numTSL_Phoi_PP.Value = Common.SumDCValue(dtEditCt, "So_Luong_Cay", "Phan_Loai_Phoi = 'PP'");
			}
        }
            
			bdsEditCt.EndEdit();//Cap nhat lai DataSource
		}

		void dgvEditCt_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt)
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
		}

		//Xử lý Dvt
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

			if (strColumnName == "TK_NO5" || strColumnName == "TK_CO5")
			{
				if (drCurrent["TIEN5"] == DBNull.Value || Convert.ToDouble(drCurrent["TIEN5"]) == 0)
					bRequire = false;
			}
			else
			{
				if (strColumnName == "TK_NO6" || strColumnName == "TK_CO6")
					if (drCurrent["TIEN6"] == DBNull.Value || Convert.ToDouble(drCurrent["TIEN6"]) == 0)
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
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strTk_No = (string)drCurrent["Tk_No"];
			string strTk_Co = (string)drCurrent["Tk_Co"];

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
			
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Job", strValue, bRequire, "", "");

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
				drCurrent["Ghi_Chu"] = drLookup["Ten_Job"].ToString();
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

				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();
                
                drCurrent["Mac_Thep"] = drLookup["Mac_Thep"];
                drCurrent["Loai_Phoi"] = drLookup["Loai_Phoi"];

				dgvCell.DataGridView.EndEdit();

				if (strMa_Vt != strMa_Vt_Old)
				{
					drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];
					drCurrent["Dvt"] = drLookup["Dvt"];
					drCurrent["He_So9"] = 1;
					
					//Phoi
					drCurrent["Mac_Thep"] = drLookup["Mac_Thep"];
					drCurrent["Loai_Phoi"] = drLookup["Loai_Phoi"];
					//drCurrent["Phoi_Ngan"] = drLookup["Phoi_Ngan"];
					


					Voucher.Calc_So_Luong(drCurrent, this);

					if ((string)drDmCt["Nh_Ct"] == "1")
					{
						if (drCurrent["Tk_No"] == "")
							drCurrent["Tk_No"] = drLookup["Tk_Vtu"];
					}
					else
					{
						if (drCurrent["Tk_Co"] == "")
							drCurrent["Tk_Co"] = drLookup["Tk_Vtu"];
					}
				}
				//else
				//{
				//    if (drCurrent["Ten_Vt"] == DBNull.Value || (string)drCurrent["Ten_Vt"] == string.Empty)
				//        drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

				//    if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
				//        drCurrent["Dvt"] = drLookup["Dvt"];

				//    if ((string)drDmCt["Nh_Ct"] == "1")
				//    {
				//        if (drCurrent["Tk_No"] == DBNull.Value || (string)drCurrent["Tk_No"] == string.Empty)
				//            drCurrent["Tk_No"] = drLookup["Tk_Vtu"];
				//    }
				//    else
				//    {
				//        if (drCurrent["Tk_Co"] == DBNull.Value || (string)drCurrent["Tk_Co"] == string.Empty)
				//            drCurrent["Tk_Co"] = drLookup["Tk_Vtu"];
				//    }
				//}
			}
			return true;
		}
		private bool dgvLookupLoai_Dac_Diem(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "LOAI_DAC_DIEM_PHOI");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'LOAI_DAC_DIEM_PHOI'", "", htField);

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["Type_ID"].ToString();
				dgvCell.Tag = drLookup["Type_Name"].ToString();

				drCurrent["Ghi_Chu"] = drLookup["Type_Name"];

				dgvCell.DataGridView.EndEdit();
			}
			return true;
		}
		private bool dgvLookupPhan_Loai_Phoi(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();
			
			bool bRequire = true;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "PHAN_LOAI_PHOI");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'PHAN_LOAI_PHOI'", "", htField);

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["Type_ID"].ToString();
				dgvCell.Tag = drLookup["Type_Name"].ToString();

				drCurrent["Ma_Kho"] = drLookup["Type_Name"];

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
		private bool dgvLookupMa_Size_Sp(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Size_Sp", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["Ma_Size_Sp"].ToString();
				dgvCell.Tag = drLookup["Ma_Size_Sp"].ToString();
			
				drCurrent["Mac_Thep_Sp"] = drLookup["Mac_Thep_Sp"].ToString();
				
				dgvCell.DataGridView.EndEdit();
			}
			return true;
		}
		
		private bool dgvLookupMa_KhoN(ref DataGridViewCell dgvCell)
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

		private bool dgvLookupMa_VtN(ref DataGridViewCell dgvCell)
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
				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				dgvCell.DataGridView.EndEdit();
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


                //Voucher.HanTt_LockCt(this);
                Voucher.Phoi_LockCt(this);

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

        //private void lbtCa_SX_Click(object sender, EventArgs e)
        //{

        //}


	
	}
}
