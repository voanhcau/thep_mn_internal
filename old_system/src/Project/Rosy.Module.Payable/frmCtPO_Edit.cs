using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.IO;
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
	public partial class frmCtPO_Edit : frmVoucher_Edit
	{
		private string strModule = "04";
		private bool bMa_Vt_Changed = false;
		private bool bMa_Thue_Changed = false;
		object objFile = null;
		string strFile_Tag = string.Empty;

		#region Contructor

		public frmCtPO_Edit()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

			this.btImportExcel.Click += new EventHandler(btnImportExcel_Click);

			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
			txtTen_Dt_NCC1.Validating += new CancelEventHandler(txtMa_Dt_NCC1_Validating);
			txtTen_Dt_NCC2.Validating += new CancelEventHandler(txtMa_Dt_NCC2_Validating);
			txtTen_Dt_NCC3.Validating += new CancelEventHandler(txtMa_Dt_NCC3_Validating);
			txtTen_Dt_NCC4.Validating += new CancelEventHandler(txtMa_Dt_NCC4_Validating);
			txtTen_Dt_NCC5.Validating += new CancelEventHandler(txtMa_Dt_NCC5_Validating);

			btInherit.Click += new EventHandler(btInherit_Click);

			txtMa_Tte.Leave += new EventHandler(txtMa_Tte_Leave);
			numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);

			numTTien.Validated += new EventHandler(numTTien_Validated);
			numTTien_Nt.Validated += new EventHandler(numTTien_Nt_Validated);
			numTTien3.Validated += new EventHandler(numTTien3_Validated);
			numTTien_Nt3.Validated += new EventHandler(numTTien_Nt3_Validated);

			dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
            dgvEditCt1.CellContentClick += new DataGridViewCellEventHandler(dgvEditCt_CellContentClick);
			dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
			dgvEditCt1.CellValueChanged += new DataGridViewCellEventHandler(dgvEditCt1_CellValueChanged);
			dgvEditCt1.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);
			dgvEditCt2.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvEditCt2_CellMouseClick);
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

			if (dgvEditCt1.Columns.Contains("MA_VT"))
				((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;

			if (dgvEditCt1.Columns.Contains("MA_DT"))
				((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Dt"]).bUseAutoDropDown = true;

			
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
                    drCurrent["Ngay_Ct"] = DateTime.Now;
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

			Voucher.Update_Header(this);
			Voucher.Update_Stt(this, strModule);
			
			if(dgvEditCt1.Columns.Contains("Dvt"))
				dgvEditCt1.Columns["Dvt"].ReadOnly = true;

            txtInherit.Text = Voucher.GetInheritVoucher(this);
			//BindingTTien
			numTTien0.DataBindings.Clear();
			numTTien3.DataBindings.Clear();
			numTTien.DataBindings.Clear();

			numTTien_Nt0.DataBindings.Clear();
			numTTien_Nt3.DataBindings.Clear();
			numTTien_Nt.DataBindings.Clear();
			numTSo_Luong.DataBindings.Clear();

			numTTien0.DataBindings.Add("Value", dtEditPh, "TTien0");
			numTTien3.DataBindings.Add("Value", dtEditPh, "TTien3");
			numTTien.DataBindings.Add("Value", dtEditPh, "TTien");

			numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien_Nt0");
			numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien_Nt3");
			numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");
			numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");
		}

		private void LoadDicName()
		{
			
			txtMa_Hd.bUseAutoDropDown = true;
			txtTen_Dt_NCC1.bUseAutoDropDown = true;
			txtTen_Dt_NCC2.bUseAutoDropDown = true;
			txtTen_Dt_NCC3.bUseAutoDropDown = true;
			txtTen_Dt_NCC4.bUseAutoDropDown = true;
			txtTen_Dt_NCC5.bUseAutoDropDown = true;


			//txtMa_Nvu
			if (txtMa_Nvu.Text.Trim() != string.Empty)
				lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim());
			else
				lbtTen_Nvu.Text = string.Empty;

			//txtMa_DDH
			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				lbtTen_Hd.Text = Voucher.GetTenHd(txtMa_Hd.Text); //DataTool.SQLGetNameByCode("R81DmHd", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
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

		private bool FormCheckValid()
		{
			//if (!Common.CheckDataLocked(Library.StrToDate(this.dteNgay_Ct.Text)))
			//{
			//	string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Dữ liệu đã bị khóa" : "Data have been locked";
			//	Common.MsgCancel(strMsg);
			//	return false;
			//}

			if (txtMa_Nvu.Text == string.Empty)
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa khai báo mã nghiệp vụ" : "Do not register transaction type";
				Common.MsgCancel(strMsg);
				return false;
			}
			if(drEditPh["Ma_Dt"].ToString() == string.Empty && strMa_Ct == "POCG")
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa khai báo mã đối tượng" : "Do not register key customer";
				Common.MsgCancel(strMsg);
				return false;
			}
			//Kiểm tra nghiệp vụ hợp lệ
			foreach (DataRow dr in dtEditCt.Rows)
			{
				if ((bool)dr["Deleted"])
					continue;

				#region Kiểm tra tính hợp lệ của định nghĩa nghiệp vụ
                if (Common.Inlist(strMa_Ct, "POCG") && dr["Stt_Org"] == "" && dr["Ma_Vt"].ToString() != "")
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "'" + (string)dr["Ten_Vt"] + "' không được kế thừa, yêu cầu kế thừa từ PONL mới được phép lưu " : "Do not register transaction type";
                    Common.MsgCancel(strMsg);
                    return false;
                }
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
				drEditPh["Duyet_Tp"] = false;
				drEditPh["Duyet_Tp_Log"] = string.Empty;
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

			//if (dtEditPh.Columns.Contains("Duyet_Tp"))
			//{
			//	drEditPh["Duyet_Tp"] = true;
			//}

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
					Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

				drEdit = drEditPh;
			}

			if (Voucher.SQLUpdateCt(this))
			{
				this.UpdateImage();
				return true;
			}
			return false;
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

				if ((dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange) && this.enuNew_Edit == enuEdit.New)
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

            Voucher.FormatTien_Nt_POCG(dgvEditCt1, strMa_Tte);
            

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
				//if (drDmNvu["Ma_Dt"].ToString() != "" && !drDmNvu["Ma_Dt"].ToString().Contains(",")) //Ma_Dt
				//{

				//}
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
					//if (dtEditCt.Columns.Contains("Ma_Dt") && drDmNvu["Ma_Dt"].ToString() != "" && !drDmNvu["Ma_Dt"].ToString().Contains(",")) //Ma_Dt
					//{
					//    dr["Ma_Dt"] = drDmNvu["Ma_Dt"].ToString();
					//}
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
				lbtTen_Hd.Text = Voucher.GetTenHd(txtMa_Hd.Text);// drLookup["Ten_Hd"].ToString();

				//if (txtMa_Hd.bTextChange)
				//{
				//    txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				//    DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", (string)drLookup["Ma_Dt"]);
				//    if (drDmDt != null)
				//    {
				//        lbtTen_Dt.Text = (string)drDmDt["Ten_Dt"];
				//        if ((string)drDmDt["Ong_Ba"] != string.Empty)
				//            txtOng_Ba.Text = (string)drDmDt["Ong_Ba"];
				//        else
				//            txtOng_Ba.Text = (string)drDmDt["Ten_Dt"];

				//        txtDia_Chi.Text = (string)drDmDt["Dia_Chi"];
				//    }
				//}
			}
		}
		void txtMa_Dt_NCC1_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTen_Dt_NCC1.Text.Trim();
			bool bRequire = false;

			DataRow drLookup;
			if (strValue == "/" || strValue == @"\")
				drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");
			else if (SQLExec.ExecuteReturnDt("select * from VW_TEN_DT_MH where Ma_Dt like '%" + strValue + "%'").Rows.Count > 0)
				drLookup = Lookup.ShowLookup("Ten_Dt_NCC", strValue, bRequire, "");
			else
				drLookup = null;


			if (drLookup == null)
				e.Cancel = false;

			if (drLookup != null)
			{
				txtTen_Dt_NCC1.Text = drLookup["Ten_Dt"].ToString();
				txtMa_Dt_NCC1.Text = drLookup["Ma_Dt"].ToString();
			}

		}
		void txtMa_Dt_NCC2_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTen_Dt_NCC2.Text.Trim();
			bool bRequire = false;

			DataRow drLookup;
			if (strValue == "/" || strValue == @"\")
				drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");
			else if (SQLExec.ExecuteReturnDt("select * from VW_TEN_DT_MH where Ma_Dt like '%" + strValue + "%'").Rows.Count > 0)
				drLookup = Lookup.ShowLookup("Ten_Dt_NCC", strValue, bRequire, "");
			else
				drLookup = null;

			if (drLookup == null)
				e.Cancel = false;

			if (drLookup != null)
			{
				txtTen_Dt_NCC2.Text = drLookup["Ten_Dt"].ToString();
				txtMa_Dt_NCC2.Text = drLookup["Ma_Dt"].ToString();
			}
		}
		void txtMa_Dt_NCC3_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTen_Dt_NCC3.Text.Trim();
			bool bRequire = false;

			DataRow drLookup;
			if (strValue == "/" || strValue == @"\")
				drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");
			else if (SQLExec.ExecuteReturnDt("select * from VW_TEN_DT_MH where Ma_Dt like '%" + strValue + "%'").Rows.Count > 0)
				drLookup = Lookup.ShowLookup("Ten_Dt_NCC", strValue, bRequire, "");
			else
				drLookup = null;

			if (drLookup == null)
				e.Cancel = false;

			if (drLookup != null)
			{
				txtTen_Dt_NCC3.Text = drLookup["Ten_Dt"].ToString();
				txtMa_Dt_NCC3.Text = drLookup["Ma_Dt"].ToString();
			}
		}
		void txtMa_Dt_NCC4_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTen_Dt_NCC4.Text.Trim();
			bool bRequire = false;
			DataRow drLookup;
			if (strValue == "/" || strValue == @"\")
				drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");
			else if (SQLExec.ExecuteReturnDt("select * from VW_TEN_DT_MH where Ma_Dt like '%" + strValue + "%'").Rows.Count > 0)
				drLookup = Lookup.ShowLookup("Ten_Dt_NCC", strValue, bRequire, "");
			else
				drLookup = null;

			if (drLookup == null)
				e.Cancel = false;

			if (drLookup != null)
			{
				txtTen_Dt_NCC4.Text = drLookup["Ten_Dt"].ToString();
				txtMa_Dt_NCC4.Text = drLookup["Ma_Dt"].ToString();
			}

		}
		void txtMa_Dt_NCC5_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTen_Dt_NCC5.Text.Trim();
			bool bRequire = false;

			DataRow drLookup;
			if (strValue == "/" || strValue == @"\")
				drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");
			else if (SQLExec.ExecuteReturnDt("select * from VW_TEN_DT_MH where Ma_Dt like '%" + strValue + "%'").Rows.Count > 0)
				drLookup = Lookup.ShowLookup("Ten_Dt_NCC", strValue, bRequire, "");
			else
				drLookup = null;

			if (drLookup == null)
				e.Cancel = false;

			if (drLookup != null)
			{
				txtTen_Dt_NCC5.Text = drLookup["Ten_Dt"].ToString();
				txtMa_Dt_NCC5.Text = drLookup["Ma_Dt"].ToString();
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

			//if (Common.Inlist(strColumnName, "GIA_NT, GIA, TIEN_NT, TIEN"))
			//{
			//    if ((bool)dgvEditCt1.CurrentRow.Cells["AUTO_COST"].Value == true)
			//    {
			//        dgvCell.ReadOnly = true;
			//        dgvCell.Value = 0;
			//    }
			//    else
			//        dgvCell.ReadOnly = false;
			//}			
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

				if (Common.Inlist(strColumnName, "XUAT_XU,DIEU_KIEN_GIA"))
				{
					string strSo_Seri = dgvCell.FormattedValue.ToString().Trim();
					strSo_Seri = strSo_Seri.ToUpper();
					dgvEditCt.CancelEdit();
					dgvCell.Value = strSo_Seri;
				}

				if (bLookup == false)
					e.Cancel = true;
			}
			else
				dgvEditCt.CancelEdit();
		}
        void dgvEditCt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (bdsEditCt.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strColumn_Name = dgvEditCt1.Columns[e.ColumnIndex].DataPropertyName;
            if (Common.Inlist(strColumn_Name, "IS_NCC1,IS_NCC2,IS_NCC3,IS_NCC4,IS_NCC5"))
            {
                if (strColumn_Name == "IS_NCC1")
                {
                    drCurrent["IS_NCC1"] = true;
                    drCurrent["IS_NCC2"] = drCurrent["IS_NCC3"] = drCurrent["IS_NCC4"] = drCurrent["IS_NCC5"] = false;
                }
                else if (strColumn_Name == "IS_NCC2")
                {
                    drCurrent["IS_NCC2"] = true;
                    drCurrent["IS_NCC1"] = drCurrent["IS_NCC3"] = drCurrent["IS_NCC4"] = drCurrent["IS_NCC5"] = false;
                }
                else if (strColumn_Name == "IS_NCC3")
                {
                    drCurrent["IS_NCC3"] = true;
                    drCurrent["IS_NCC1"] = drCurrent["IS_NCC2"] = drCurrent["IS_NCC4"] = drCurrent["IS_NCC5"] = false;
                }
                else if (strColumn_Name == "IS_NCC4")
                {
                    drCurrent["IS_NCC4"] = true;
                    drCurrent["IS_NCC1"] = drCurrent["IS_NCC2"] = drCurrent["IS_NCC3"] = drCurrent["IS_NCC5"] = false;
                }
                else if (strColumn_Name == "IS_NCC5")
                {
                    drCurrent["IS_NCC5"] = true;
                    drCurrent["IS_NCC1"] = drCurrent["IS_NCC2"] = drCurrent["IS_NCC3"] = drCurrent["IS_NCC4"] = false;
                }
                //Voucher.Calc_So_Luong(drCurrent, this);
                this.Calc_So_Luong_ChonGia(strColumn_Name, drCurrent);
            }
        }
        private void Calc_So_Luong_ChonGia(string strColumn_Name, DataRow drCurrent)
        {
           
            DataRow[] arrEditCt = dtEditCt.Select();

            double dbGia = 0;
            if (Common.Inlist(strMa_Ct, "POCG"))
            {
                if (strColumn_Name == "IS_NCC1")
                {
                    if (arrEditCt.Length > 0)
                    {
                        foreach (DataRow dr in arrEditCt)
                        {
                            dbGia = Convert.ToDouble(dr["Gia_NCC1"]);
                            dr["Gia_Nt9"] = dr["Gia_Nt"] = dbGia;
                            dr["Ma_Dt"] = drEditPh["Ma_Dt"] = txtMa_Dt_NCC1.Text;
                            dr["IS_NCC1"] = true;
                            dr["IS_NCC2"] = dr["IS_NCC3"] = dr["IS_NCC4"] = dr["IS_NCC5"] = false;
                            Voucher.Calc_So_Luong(dr, this);
                        }
                    }
                }
                else if (strColumn_Name == "IS_NCC2")
                {
                    if (arrEditCt.Length > 0)
                    {
                        foreach (DataRow dr in arrEditCt)
                        {
                            dbGia = Convert.ToDouble(dr["Gia_NCC2"]);
                            dr["Gia_Nt9"] = dr["Gia_Nt"] = dbGia;
                            dr["Ma_Dt"] = drEditPh["Ma_Dt"] = txtMa_Dt_NCC2.Text;
                            dr["IS_NCC2"] = true;
                            dr["IS_NCC1"] = dr["IS_NCC3"] = dr["IS_NCC4"] = dr["IS_NCC5"] = false;
                            Voucher.Calc_So_Luong(dr, this);
                        }
                    }
                }
                else if (strColumn_Name == "IS_NCC3")
                {
                    if (arrEditCt.Length > 0)
                    {
                        foreach (DataRow dr in arrEditCt)
                        {
                            dbGia = Convert.ToDouble(dr["Gia_NCC3"]);
                            dr["Gia_Nt9"] = dr["Gia_Nt"] = dbGia;
                            dr["Ma_Dt"] = drEditPh["Ma_Dt"] = txtMa_Dt_NCC3.Text;
                            dr["IS_NCC3"] = true;
                            dr["IS_NCC2"] = dr["IS_NCC1"] = dr["IS_NCC4"] = dr["IS_NCC5"] = false;
                            Voucher.Calc_So_Luong(dr, this);
                        }
                    }
                }
                else if (strColumn_Name == "IS_NCC4")
                {
                    if (arrEditCt.Length > 0)
                    {
                        foreach (DataRow dr in arrEditCt)
                        {
                            dbGia = Convert.ToDouble(dr["Gia_NCC4"]);
                            dr["Gia_Nt9"] = dr["Gia_Nt"] = dbGia;
                            dr["Ma_Dt"] = drEditPh["Ma_Dt"] = txtMa_Dt_NCC4.Text;
                            dr["IS_NCC4"] = true;
                            dr["IS_NCC1"] = dr["IS_NCC2"] = dr["IS_NCC3"] = dr["IS_NCC5"] = false;
                            Voucher.Calc_So_Luong(dr, this);
                        }
                    }
                }
                else if (strColumn_Name == "IS_NCC5")
                {
                    if (arrEditCt.Length > 0)
                    {
                        foreach (DataRow dr in arrEditCt)
                        {
                            dbGia = Convert.ToDouble(dr["Gia_NCC5"]);
                            dr["Gia_Nt9"] = dr["Gia_Nt"] = dbGia;
                            dr["Ma_Dt"] = drEditPh["Ma_Dt"] = txtMa_Dt_NCC5.Text;
                            dr["IS_NCC5"] = true;
                            dr["IS_NCC1"] = dr["IS_NCC2"] = dr["IS_NCC3"] = dr["IS_NCC4"] = false;
                            Voucher.Calc_So_Luong(dr, this);
                        }
                    }
                }
            }
            
            Voucher.Calc_So_Luong_All(this);
            Voucher.Update_TTien(this);

            drCurrent.AcceptChanges();
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

			if (Common.Inlist(strColumnName, "GIA_NT9,GIA_CHAO"))
			{
				double dbGia_Nt9 = drCurrent["Gia_Nt9"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Gia_Nt9"]);
				double dbGia_Chao = drCurrent["GIA_CHAO"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["GIA_CHAO"]);
				double dbGia_Qd = 0;
				string strNguon = drCurrent["XUAT_XU"] == DBNull.Value ? string.Empty : (string)drCurrent["XUAT_XU"];
				if (dbGia_Chao > 0 && strMa_Ct == "POTV")
				{
					DataRow dr = DataTool.SQLGetDataRowByID("R81DMLOAIHANG", "Ma_Loai_Hang", drCurrent["MA_LOAI_HANG"].ToString());
					if (dr != null)
					{
						if (strNguon.ToUpper() == "NHẬT")
						{
							dbGia_Qd = dr["GiaH2_Nhat"] == DBNull.Value ? 0 : Convert.ToDouble(dr["GiaH2_Nhat"]);
						}
						else if (strNguon.ToUpper() == "MỸ")
							dbGia_Qd = dr["GiaH2_Nhat"] == DBNull.Value ? 0 : Convert.ToDouble(dr["GiaH2_Nhat"]);
						else if (strNguon.ToUpper() == "NAM PHI")
							dbGia_Qd = dr["GiaH2_NamPhi"] == DBNull.Value ? 0 : Convert.ToDouble(dr["GiaH2_NamPhi"]);
						else if (strNguon.ToUpper() == "ÚC")
							dbGia_Qd = dr["GiaH2_Uc"] == DBNull.Value ? 0 : Convert.ToDouble(dr["GiaH2_Uc"]);
						else if (strNguon.ToUpper() == "KOREA")
							dbGia_Qd = dr["GiaH2_Kored"] == DBNull.Value ? 0 : Convert.ToDouble(dr["GiaH2_Kored"]);
					}
					
				}
				dbGia_Chao = dbGia_Nt9 - dbGia_Qd;
				drCurrent["GIA_CHAO"] = dbGia_Chao;
			}

			if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN"))
			{
				Voucher.Calc_So_Luong(drCurrent, this);
				Voucher.Update_TTien(this);
				
				drCurrent["So_Luong_KHVT"] = drCurrent["SO_LUONG9"];
				drCurrent["So_Luong_KtCdAt"] = drCurrent["SO_LUONG9"];
				drCurrent["So_Luong_KTTC"] = drCurrent["SO_LUONG9"];
			}
            if (Common.Inlist(strColumnName, "SO_LUONG_GTRU,SO_LUONG_TL"))
            {
                drCurrent["So_Luong9"] = drCurrent["So_Luong"] = Convert.ToDouble(drCurrent["So_Luong0"]) - Convert.ToDouble(drCurrent["So_Luong_GTru"]) - Convert.ToDouble(drCurrent["So_Luong_Tl"]);
            }
            else if (Common.Inlist(strColumnName, "TIEN"))
            {
                Voucher.Calc_Tien(drCurrent, this);
                Voucher.Update_TTien(this);
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

		private void UpdateImage()
		{
            //foreach (DataRow drEdit in dtEditCt.Rows)
            //{
				
            //    Hashtable htPara = new Hashtable();
            //    htPara.Add("STT", (string)drEdit["Stt"]);
            //    htPara.Add("STT0", drEdit["Stt0"]);
            //    htPara.Add("FILE_NAME", (string)drEdit["Stt"] + drEdit["Stt0"] + (string)drEdit["Ma_Vt"]);
            //    htPara.Add("TAG", (string)drEdit["Tag"]);
            //    htPara.Add("IMAGE", drEdit["IMAGE_Bg1"]);

            //    string strSQLExec = "";

            //    if ((bool)drEdit["Deleted"])
            //    {
            //        strSQLExec = @"DELETE FROM R04CTSO_Resource WHERE Stt = @Stt AND Stt0 = @Stt0";
            //        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
            //    }
            //    else if (drEdit["IMAGE_Bg1"] != DBNull.Value)
            //    {
            //        if (!DataTool.SQLCheckExist("R04CTSO_Resource", new string[] { "Stt", "Stt0" }, new object[] { (string)drCurrent["Stt"], drCurrent["Stt0"] }))
            //            strSQLExec = @"INSERT INTO R04CTSO_Resource(Stt, Stt0, File_Name, Tag, Image) VALUES(@Stt, @Stt0, @File_Name, @Tag, @Image)";
            //        else
            //            strSQLExec = @"UPDATE R04CTSO_Resource SET File_Name = @File_Name, Tag = @Tag, Image = @Image WHERE Stt = @Stt AND Stt0 = @Stt0";

            //        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
            //    }
            //}
		}
		void dgvEditCt2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = dgvEditCt2.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (strColumnName == "ATTACH_BG1")
			{
				OpenFileDialog fileDialog = new OpenFileDialog();
				fileDialog.RestoreDirectory = true;
				fileDialog.Filter = "(*.PDF)|*.PDF|All files (*.*)|*.*";

				if (fileDialog.ShowDialog() != DialogResult.OK)
					return;

				this.objFile = (object)System.IO.File.ReadAllBytes(fileDialog.FileName);

				if (objFile != null)
				{
					strFile_Tag = Path.GetExtension(fileDialog.FileName).Substring(1).ToUpper();

					drCurrent["TAG_Bg1"] = strFile_Tag;
					drCurrent["IMAGE_Bg1"] = objFile;

				}

			}
						
			if (strColumnName == "OPEN_BG1")
			{
				string strFileName = (string)drCurrent["Stt"] + drCurrent["Stt0"] + (string)drCurrent["Ma_Vt"] + ".pdf";
				string strPath = Application.StartupPath + @"\File\";

				if (!Directory.Exists(strPath))
					Directory.CreateDirectory(strPath);

				Hashtable htPara = new Hashtable();

				htPara.Add("STT", (string)drCurrent["Stt"]);
				htPara.Add("STT0", drCurrent["Stt0"]);


				object objFile = SQLExec.ExecuteReturnValue("SELECT Image FROM R04CTSO_Resource WHERE Stt = @Stt AND Stt0 = @Stt0 ", htPara, CommandType.Text);
				if (objFile != null && objFile != DBNull.Value && ((Byte[])objFile).Length > 0)
				{
					FileStream fileStream = new FileStream(strPath + strFileName, FileMode.Create, FileAccess.ReadWrite);
					fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);
					fileStream.Close();
					System.Diagnostics.Process.Start(strPath + strFileName);
				}
			}
						
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

					if(dgvEditCt1.Columns.Contains("Mo_Ta_Kt"))
						drCurrent["Mo_Ta_Kt"] = drLookup["Thong_So_Kt"];


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
                if (!Common.CheckDataLocked((DateTime)drEdit["Ngay_Ct"]) && !Common.Inlist(strMa_Ct, "POCG,PONL"))
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
