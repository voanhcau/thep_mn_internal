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

namespace RosyModule.ScaleBarcodeTMN
{
	public partial class frmScale_Detail_TLB_Edit : frmVoucher_Scale_Edit
	{
		private string strTk_NoTmp = string.Empty;
		private string strTk_CoTmp = string.Empty;
        
		#region Contructor

		public frmScale_Detail_TLB_Edit()
		{
			InitializeComponent();

			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);
			this.btInherit.Click += new EventHandler(btInherit_Click);
            
			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			
			
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			dteNgay_Ct.Validating += new CancelEventHandler(dteNgay_Ct_Validating);
			
			dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
			dgvEditCt1.CellLeave += new DataGridViewCellEventHandler(dgvEditCt_CellLeave);
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

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
				this.strStt = Voucher_Scale.GetNewStt("07");
			else
				this.strStt = drEdit["Stt"].ToString();

			this.Build();
			this.FillData();
			this.Init_Ct();

			Common.ScaterMemvar(this, ref drEditPh);

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
		}

		private void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("TABLE_PH", (string)drDmCt["Table_Ph"]);
			htPara.Add("TABLE_CT", (string)drDmCt["Table_Ct"]);
			htPara.Add("STT", ((string)drEdit["Stt"]).Trim());
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucher_Scale_CtTLB_KKV", htPara, CommandType.StoredProcedure);

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
		}

		private void Init_Ct()
		{
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
					drCurrent["Ngay_Ct"] = DateTime.Now;

					drCurrent["Deleted"] = false;
					// XỬ LÝ ĐÁNH DẤU HÀNG TRẢ LẠI
					drCurrent["Is_TL"] = true;
					drCurrent["Is_PP"] = false;
					

					//Clear Content in drEditPh
					foreach (DataColumn dcEditPh in dtEditPh.Columns)
						drEditPh[dcEditPh] = DBNull.Value;

					drEditPh["Loai_Ct"] = drDmCt["Nh_Ct"];
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
				drEditPh["So_Ct"] = drCurrent["So_Ct"] = Voucher_Scale.GetNewSo_Ct();
			}

			Voucher_Scale.Update_Header(this);
			Voucher_Scale.Update_Stt(this);

			txtInherit.Text = Voucher_Scale.GetInheritScaleBarcode(this);
		}

		private void LoadDicName()
		{
			txtMa_Dt.bUseAutoDropDown = true;
			

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
			Voucher_Scale.Update_Detail(this);

			if (!FormCheckValid())
				return false;

			Voucher_Scale.Update_Log(this);
			Voucher_Scale.Update_Stt(this);
			Voucher_Scale.UpdateSo_Ct(this);
			
			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
					Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

				drEdit = drEditPh;
			}

			if (Voucher_Scale.SQLUpdateCt(this))
			{
				this.ReUpdate_Status_KCS();
				return true;
			}
			else
				return false;

		}

		private void ReUpdate_Status_KCS()
		{
			return;
			//Hashtable htPara = new Hashtable();
			//htPara.Add("STRNEW_EDIT", (char)enuNew_Edit);
			//htPara.Add("BARCODE", null);

			//foreach (DataRow dr in dtEditCt.Rows)
			//{
			//	if (dr.RowState == DataRowState.Deleted)
			//		continue;

			//	if ((bool)dr["Deleted"])
			//		continue;

			//	if (dr["Barcode"].ToString().Trim().StartsWith("L"))
			//		continue;

			//	htPara["BARCODE"] = (string)dr["Barcode"];

			//	if (!SQLExec.Execute("sp_ReUpdate_TLB_Status_KKV", htPara, CommandType.StoredProcedure))
			//	{
			//		Common.MsgCancel("Có lỗi xảy ra khi cập nhật.\r\nLiên hệ với Admin");
			//		continue;
			//	}
			//}
		}

		private bool CellKeyEnter()
		{//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc

			if (dgvEditCt1.CurrentCell == null)
				return false;

			DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
			string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();
			return false;
		}

		private void InheritVoucher()
		{
			frmInherit_Xuat_Barcode frmInherit = new frmInherit_Xuat_Barcode();
			frmInherit.Load(this, "PXBKV");

			if (frmInherit.Is_Accept)
			{
				Voucher_Scale.InheritVoucher_SetData_Barcode(frmInherit, this);
				
				txtMa_Nvu_Validating(null, null);
				
				txtMa_Dt_Validating(null, null);
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

			Voucher_Scale.Update_Detail(this, "Ma_NVu");

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
		}

		void btInherit_Click(object sender, EventArgs e)
		{
			InheritVoucher();
		}

		void dteNgay_Ct_Validating(object sender, CancelEventArgs e)
		{
			Common.GatherMemvar(this, ref drEditPh);
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

			Voucher_Scale.Update_Detail(this, "Ma_Dt");
		}

	

		void frmEditCtTien_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:
					Voucher_Scale.DeleteRow(this, dgvEditCt1);
					break;

				case Keys.Up:
					if (this.dgvEditCt1.Focused && this.dgvEditCt1.bIsCurrentFirstRow)
						this.SelectNextControl(dgvEditCt1, false, true, true, true);
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
