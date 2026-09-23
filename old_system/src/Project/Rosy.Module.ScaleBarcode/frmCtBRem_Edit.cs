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

namespace RosyModule.ScaleBarcode
{
	public partial class frmCtBRem_Edit : frmVoucher_Edit
	{
		private string strTk_NoTmp = string.Empty;
		private string strTk_CoTmp = string.Empty;
		private string strModule = "03";
        private string strMsg1 = string.Empty;
        private string strMa_Vt_List;

		#region Contructor

		public frmCtBRem_Edit()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);
            this.btImportExcel.Click += new EventHandler(btnImportExcel_Click);
			this.btInherit.Click += new EventHandler(btInherit_Click);
            
			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_CbNv_Validating);
			
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtSo_Ct.Validating += new CancelEventHandler(txtSo_Ct_Validating);

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

			dgvEditCt1.CellContentClick += new DataGridViewCellEventHandler(dgvEditCt1_CellContentClick);
			dgvEditCt1.CellContentDoubleClick += new DataGridViewCellEventHandler(dgvEditCt1_CellContentClick);
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


			((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;

		}

		private void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("TABLE_PH", (string)drDmCt["Table_Ph"]);
			htPara.Add("TABLE_CT", (string)drDmCt["Table_Ct"]);
			htPara.Add("STT", ((string)drEdit["Stt"]).Trim());
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
					drCurrent["Ngay_Ct"] = DateTime.Now; //drEdit["Ngay_Ct"] != DBNull.Value ? drEdit["Ngay_Ct"] : DateTime.Now;

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

            if (dgvEditCt1.Columns.Contains("Dvt"))
                dgvEditCt1.Columns["Dvt"].ReadOnly = true;

			txtInherit.Text = Voucher.GetInheritScaleBarcode(this);
			//BindingTTien                      
			numTTien.DataBindings.Clear();
			numTTien_Nt.DataBindings.Clear();
			numTSo_Luong.DataBindings.Clear();

			numTTien.DataBindings.Add("Value", dtEditPh, "TTien");
			numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");
			numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");

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

            //txtMa_Dt_CbNv
            if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
            {
                lbtTen_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
            }
            else
                lbtTen_CbNv.Text = string.Empty;

			//txtMa_Hd
			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				lbtTen_Hd.Text = DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
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
			dtEditCt.AcceptChanges();

			Common.GatherMemvar(this, ref this.drEditPh);
			Voucher.Update_Detail(this);

			if (!FormCheckValid())
				return false;

			this.Update_So_Luong_Barem();
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

			return Voucher.SQLUpdateCt(this);
		}

		private void Update_So_Luong_Barem()
		{
			object objBarem = SQLExec.ExecuteReturnValue("SELECT Is_Barem FROM R81DMDT WHERE Ma_Dt = '" + txtMa_Dt.Text.Trim() + "'", CommandType.Text);
			if (objBarem != null && objBarem.ToString() != string.Empty)
				if (Convert.ToBoolean(objBarem))
					return;
		
			double dbSo_Luong_Barem = 0;
			double dbSo_Luong_Can = 0;
			double dbSo_Luong9 = 0;
			double dbBarem = 0;
			double dbLength = 0;

			foreach (DataRow drCt in dtEditCt.Rows)
			{
				if (drCt.RowState == DataRowState.Deleted)
					continue;

				//Kiểm tra nếu sản phẩm 12M thì giữ nguyên theo người dùng chọn
				//Lấy 1 số barcode bất kỳ để làm mẫu
				string strSQLExec = @"SELECT TOP 1 ISNULL(T2.Length, 0)
											FROM R05CTX_BARCODE T1 WITH(NOLOCK) LEFT JOIN R81DMBARCODE T2 WITH(NOLOCK) ON T1.Barcode = T2.Barcode
											WHERE T1.Stt = '" + drCt["Stt_Org"].ToString() + "' AND T1.Ma_Vt_Sp = '" + drCt["Ma_Vt"].ToString() + "'";

				object objValue = SQLExec.ExecuteReturnValue(strSQLExec, CommandType.Text);
				

				if (objValue != null && objValue.ToString() != string.Empty)
					dbLength = Convert.ToDouble(objValue);

				if (dbLength >= 12)
					continue;

				dbBarem = drCt["Barem"] == DBNull.Value ? 0 : Convert.ToDouble(drCt["Barem"]);
				dbSo_Luong_Barem = drCt["So_Luong_Barem"] == DBNull.Value ? 0 : Convert.ToDouble(drCt["So_Luong_Barem"]);
				dbSo_Luong_Can = drCt["So_Luong_Can"] == DBNull.Value ? 0 : Convert.ToDouble(drCt["So_Luong_Can"]);

				if (dbBarem == 0)
					continue;

				//Sợ người dùng chọn sai nên kiểm tra và cập nhật trước khi lưu.
				//Nếu SL Barem > cân thì lấy theo cân.
				//Ngược lại thì lấy theo barem.
                if (dbSo_Luong_Barem > dbSo_Luong_Can)
                {
                    dbSo_Luong9 = dbSo_Luong_Can;
                    drCt["So_Luong9"] = dbSo_Luong9;
                    drCt["IS_80TAN"] = true;
                    drCt["IS_BAREM"] = drCt["IS_BARCODE"] = false;
                }
                else
                {
                    dbSo_Luong9 = drCt["So_Luong_Barem"] == DBNull.Value ? 0 : Convert.ToDouble(drCt["So_Luong_Barem"]);
                    drCt["So_Luong9"] = dbSo_Luong9;
                    drCt["IS_BAREM"] = true;
                    drCt["IS_80TAN"] = drCt["IS_BARCODE"] = false;
                }

				Voucher.Calc_So_Luong(drCt, this);
			}

			Voucher.Calc_So_Luong_All(this);
			Voucher.Update_TTien(this);

			dtEditCt.AcceptChanges();
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

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEditPh["Duyet"] = (bool)drDmNvu["Default_Duyet"];

			Voucher.Update_DmNvu(this); //Cập nhật chi tiết hạch toán ngầm định vào chứng từ

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
			this.LoadDicName();
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
					txtOng_Ba.Text =drLookup["Ong_Ba"].ToString();//  drLookup["Ong_Ba"].ToString() ==string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
					txtDia_Chi.Text = drLookup["Dia_Chi"].ToString(); 
				}
			}

			Voucher.Update_Detail(this, "Ma_Dt");
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

		void txtMa_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv.Text = string.Empty;
				lbtTen_CbNv.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_CbNv.Text = drLookup["Ten_Dt"].ToString();
			}
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

				case Keys.S:
					if (e.Control)
					{
						this.Save();
						Common.MsgOk("Đã lưu xong!");
					}

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
		}

		//Cai dat Lookup, Enter xuống dòng
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

			if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;
				DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
				string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

				bool bLookup = true;

				if (strColumnName == "MA_DT")
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

            if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN"))
            {
                Voucher.Calc_So_Luong(drCurrent, this);
                Voucher.Update_TTien(this);
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

		private void Calc_So_Luong_QD(string strColumn_Name, DataRow drCurrent)
		{
			string strStt_Org = drCurrent["Stt_Org"] == DBNull.Value ? string.Empty : (string)drCurrent["Stt_Org"];
			DataRow drPh_Scale = DataTool.SQLGetDataRowByID("R80PH_SCALE", "Stt", strStt_Org);
			DataRow[] arrEditCt = dtEditCt.Select("Stt_Org = '" + strStt_Org + "'");

			double dbSo_Luong9 = 0;
			if (strColumn_Name == "IS_BARCODE")
			{
				if (arrEditCt.Length > 0)
				{
					foreach (DataRow dr in arrEditCt)
					{
						dbSo_Luong9 = dr["So_Luong_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(dr["So_Luong_Barcode"]);
						dr["So_Luong9"] = dbSo_Luong9;
						dr["IS_BARCODE"] = true;
						dr["IS_BAREM"] = dr["IS_80TAN"] = false;
						Voucher.Calc_So_Luong(dr, this);
					}
				}
			}
			else if (strColumn_Name == "IS_BAREM")
			{

				if (arrEditCt.Length > 0)
				{
					foreach (DataRow dr in arrEditCt)
					{
						dbSo_Luong9 = dr["So_Luong_Barem"] == DBNull.Value ? 0 : Convert.ToDouble(dr["So_Luong_Barem"]);
						dr["So_Luong9"] = dbSo_Luong9;
						dr["IS_BAREM"] = true;
						dr["IS_80TAN"] = dr["IS_BARCODE"] = false;
						Voucher.Calc_So_Luong(dr, this);
					}
				}
			}
			else if (strColumn_Name == "IS_80TAN")
			{
				if (arrEditCt.Length > 0)
				{
					foreach (DataRow dr in arrEditCt)
					{
						dbSo_Luong9 = dr["So_Luong_Can"] == DBNull.Value ? 0 : Convert.ToDouble(dr["So_Luong_Can"]);
						dr["So_Luong9"] = dbSo_Luong9;
						dr["IS_80TAN"] = true;
						dr["IS_BAREM"] = dr["IS_BARCODE"] = false;

						Voucher.Calc_So_Luong(dr, this);
					}
				}
			}

			Voucher.Calc_So_Luong_All(this);
			Voucher.Update_TTien(this);

			drCurrent.AcceptChanges();
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
			
			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			
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

				dgvCell.DataGridView.EndEdit();

				if (strMa_Vt != strMa_Vt_Old)
				{
					drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];
					drCurrent["Dvt"] = drLookup["Dvt"];
					drCurrent["He_So9"] = 1;
					
					Voucher.Calc_So_Luong(drCurrent, this);

				}
			}
			return true;
		}

		void dgvEditCt1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			if (bdsEditCt.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strColumn_Name = dgvEditCt1.Columns[e.ColumnIndex].DataPropertyName;
			if (Common.Inlist(strColumn_Name, "IS_80TAN,IS_BAREM,IS_BARCODE"))
			{
				if (Convert.ToDouble(drCurrent["Barem"]) == 0 && Common.Inlist(strColumn_Name, "IS_BAREM,IS_80TAN"))
				{
					drCurrent[strColumn_Name] = false;
					return;
				}

				if (strColumn_Name == "IS_BAREM")
				{
					drCurrent["IS_BAREM"] = true;
					drCurrent["IS_80TAN"] = drCurrent["IS_BARCODE"] = false;
				}
				else if (strColumn_Name == "IS_80TAN")
				{
					drCurrent["IS_80TAN"] = true;
					drCurrent["IS_BAREM"] = drCurrent["IS_BARCODE"] = false;
				}
				else if (strColumn_Name == "IS_BARCODE")
				{
					drCurrent["IS_BARCODE"] = true;
					drCurrent["IS_BAREM"] = drCurrent["IS_80TAN"] = false;
				}

				//Voucher.Calc_So_Luong(drCurrent, this);
				this.Calc_So_Luong_QD(strColumn_Name, drCurrent);
			}
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
