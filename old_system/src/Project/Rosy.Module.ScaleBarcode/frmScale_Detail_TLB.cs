using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;
using RosySystem;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using RosySystem.Control;
using RosyModule;
using System.Data.SqlClient;
using RosySystem.Customize;
using RosySystem.Public;

namespace RosyModule.ScaleBarcode
{
	public partial class frmScale_Detail_TLB : RosySystem.Customize.frmView
	{
		#region Variable

		//Luu y toi bManual
		public string strMa_Ct;
		DataRow drDmCt;
		DataRow drDmNvu;
		DataSet dsVoucher = new DataSet();
		public DataTable dtEditPh;
		public DataTable dtEditPh_Dest;
		public DataTable dtEditCt;
		DataRow drEditPh;
		DataRow drEditCt;
		BindingSource bdsEditPh = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
		string strStt = string.Empty;
		string strStt_Old = string.Empty;

		DataRow drCurrent;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;
		
		#endregion

		public frmScale_Detail_TLB()
		{
			InitializeComponent();

			this.btPrint.Click += new EventHandler(btPrint_Click);

			this.txtSo_Xe_Filter.Validated += new EventHandler(txtSo_Xe_Filter_Validated);
			this.cboSo_Xe.SelectedValueChanged += new EventHandler(cboSo_Xe_SelectedValueChanged);

			this.cboSo_Ct.SelectedValueChanged += new EventHandler(cboSo_Ct_SelectedValueChanged);
			this.rdbSo_Xe_Ct.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
			this.btSave_Voucher.Click += new EventHandler(btSave_Voucher_Click);
			this.dgvEditCt.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.dgvEditCt.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);

			this.btFirst.Click += new EventHandler(btFirst_Click);
			this.btNext.Click += new EventHandler(btNext_Click);
			this.btPrevious.Click += new EventHandler(btPrevious_Click);
			this.btLast.Click += new EventHandler(btLast_Click);

			this.btEdit.Click += new EventHandler(btEdit_Click);

			this.btInherit.Click += new EventHandler(btInherit_Click);
			this.txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			this.txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
			
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "");

			if (drLookup == null && bRequire)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = lbtTen_Vt_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = (string)drLookup["Ma_Vt"];
				lbtTen_Dt.Text = (string)drLookup["Ten_Vt"];
			}
		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

			if (drLookup == null && bRequire)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = (string)drLookup["Ma_Dt"];
				lbtTen_Dt.Text = (string)drLookup["Ten_Dt"];
				txtOng_Ba.Text = (string)drLookup["Ong_Ba"];
				txtDia_Chi.Text = (string)drLookup["Dia_Chi"];
			}
		}

		void btInherit_Click(object sender, EventArgs e)
		{
			frmInherit_CtX_Barcode frmInherit = new frmInherit_CtX_Barcode();
			frmInherit.Load(this, "PXTH");

			if (frmInherit.Is_Accept)
			{
				this.Inherit_SetData_CtX_Barcode(frmInherit);
				this.grbFilter.Enabled = false;
				txtMa_Vt_Sp_Validating(null, null);
				txtMa_Dt_Validating(null, null);
			}

		}

		private void Inherit_SetData_CtX_Barcode(frmInherit_CtX_Barcode frmInherit)
		{
			if (frmInherit.dtInheritVoucher.Rows == null)
				return;

			if (frmInherit.dtInheritVoucher.Rows.Count == 0)
				return;

			DataRow drEditPh_Inherit = drEditPh;
			DataTable dtEditCt_Inherit = dtEditCt;
			DataRow drEditCt_Inherit = dtEditCt_Inherit.NewRow();

			Common.CopyDataRow(dtEditCt_Inherit.Rows[0], drEditCt_Inherit);

			if (frmInherit.chkInheritOverwrite.Checked)
				dtEditCt_Inherit.Rows.Clear();

			int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0"));

			if (frmInherit.dtInheritVoucher.Rows.Count > 0)
			{
				DataRow drInheritVoucher = frmInherit.dtInheritVoucher.Rows[0];
				
				drEditPh["Ngay_Ct"] = (DateTime)drInheritVoucher["Ngay_Ct"];
				drEditPh["Ma_Dt"] = drInheritVoucher["Ma_Dt"];
				drEditPh["Dien_Giai"] = drInheritVoucher["Dien_Giai"];
				drEditPh["So_Ct"] = drInheritVoucher["So_Ct"];
				drEditPh["So_Xe"] = drInheritVoucher["So_Xe"];
				drEditPh["Ma_Vt_Sp"] = drInheritVoucher["Ma_Vt_Sp_Ph"];

				drEditPh.AcceptChanges();

				Common.ScaterMemvar(this, ref drEditPh);
			}

			foreach (DataRow drSelect in frmInherit.dtInheritVoucher.Rows)
			{
				iStt0 += 1;

				DataRow drEditCtNew = dtEditCt_Inherit.NewRow();
				Common.CopyDataRow(drSelect, drEditCtNew);
				Common.SetDefaultDataRow(ref drEditCtNew);

				drEditCtNew["Ma_Ct"] = this.strMa_Ct;
				dtEditCt.Rows.Add(drEditCtNew);
				drEditCtNew.AcceptChanges();
			}

		}

		new public void Load(string strMa_Ct)
		{
			this.strMa_Ct = strMa_Ct;
			this.drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", this.strMa_Ct);
			this.dteNgay_Ct1.Text = this.dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server());

			this.Build();
			this.FillData();
			this.Init_Ct();
			
			this.Show();
		}

		private void Build()
		{
			dgvEditCt.bSortMode = false;
			dgvEditCt.strZone = (string)drDmCt["Zone_EditCt1"];
			dgvEditCt.BuildGridView();

			this.DataGridView_Language();

		}

		private void DataGridView_Language()
		{
		
			dgvEditCt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvEditCt.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

			if (dgvEditCt.Columns.Contains("Ngay_Sx"))
				dgvEditCt.Columns["Ngay_Sx"].Frozen = true;

			if (dgvEditCt.Columns.Contains("So_Luong"))
				dgvEditCt.Columns["So_Luong"].HeaderText = "KL trên xe";

			if (dgvEditCt.Columns.Contains("Num_Bars"))
				dgvEditCt.Columns["Num_Bars"].HeaderText = "Số cây trên xe";

			//ReadOnly
			string strColumn_Name = "BARCODE,SO_LUONG,SO_LUONG_CURRENT,NUM_BARS_CURRENT,SO_LUONG_BARCODE,NUM_BARS_BARCODE,LENGTH,NGAY_SX,CANUM_LOT,TEN_VT,GRADE_NAME,STANDARD_NAME,TEN_CL,IS_OUTPUT";
			foreach (var strColumn in strColumn_Name.Split(','))
			{
				if (dgvEditCt.Columns.Contains(strColumn))
					dgvEditCt.Columns[strColumn].ReadOnly = true;
			}
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

			try
			{
				txtMa_Nvu.Text = DataTool.SQLGetNameByCode("R81DMNVU", "Ma_Ct", "Ma_NVu", strMa_Ct);
			}
			catch
			{
				txtMa_Nvu.Text = "PX30";
			}

			lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DMNVU", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim());
			drDmNvu = DataTool.SQLGetDataRowByID("R81DMNVU", "Ma_NVu", txtMa_Nvu.Text.Trim());
		}

		private void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("MA_CT", this.strMa_Ct);
			htPara.Add("SO_XE_FILTER", this.txtSo_Xe_Filter.Text);
			htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
			
			dtEditPh = SQLExec.ExecuteReturnDt("sp_GetVoucher_Scale_PH", htPara, CommandType.StoredProcedure);
			dtEditCt = SQLExec.ExecuteReturnDt("sp_GetVoucher_Scale_Ct", new string[] { "Ma_Ct", "Stt" }, new object[] { this.strMa_Ct, this.strStt }, CommandType.StoredProcedure);

			DataColumn dc = new DataColumn("Deleted", typeof(bool));
			dc.DefaultValue = false;
			dtEditCt.Columns.Add(dc);

			//Ph
			bdsEditPh.DataSource = dtEditPh;
			//Detail
			bdsEditCt.DataSource = dtEditCt;
			dgvEditCt.DataSource = bdsEditCt;
			dgvEditCt.ClearSelection();

			cboSo_Xe.DataSource = dtEditPh;
			cboSo_Xe.ValueMember = "STT";
			cboSo_Xe.DisplayMember = "SO_XE_SO_CT";

			cboSo_Ct.DataSource = dtEditPh;
			cboSo_Ct.ValueMember = "STT";
			cboSo_Ct.DisplayMember = "SO_CT";

			this.ExportControl = dgvEditCt;
		}

		private void FillData_Voucher_Ph()
		{
			if (!string.IsNullOrEmpty(strStt))
			{
				DataRow[] arrdrEditPh_Dest = dtEditPh.Select("Stt = '" + strStt + "'");
				if (arrdrEditPh_Dest.Length > 0 && arrdrEditPh_Dest.Length == 1)
				{
					if(this.dtEditPh_Dest != null)
						this.dtEditPh_Dest.Rows.Clear();

					this.dtEditPh_Dest = dtEditPh.Clone();
					
					DataRow drEdit_Ph_Dest = dtEditPh_Dest.NewRow();

					foreach (DataRow dr in arrdrEditPh_Dest)
						drEdit_Ph_Dest = dr;

					this.dtEditPh_Dest.ImportRow(drEdit_Ph_Dest);
					this.bdsEditPh.Position = this.bdsEditPh.Find("STT", strStt);
					this.lbtRecorde.Text = this.bdsEditPh.Position + 1 + "/" + this.bdsEditPh.Count;

					this.ScaterMemvar_Voucher_Edit(drEdit_Ph_Dest);
					this.FillData_Voucher_Ct();
				}
			}
			else
				this.Reset_Voucher_Edit();
		}

		private void FillData_Voucher_Ct()
		{
			dtEditCt = SQLExec.ExecuteReturnDt("sp_GetVoucher_Scale_Ct", new string[] { "Ma_Ct", "Stt" }, new object[] { this.strMa_Ct, this.strStt }, CommandType.StoredProcedure);

			if (!dtEditCt.Columns.Contains("Deleted"))
			{
				DataColumn dc = new DataColumn("Deleted", typeof(bool));
				dc.DefaultValue = false;
				dtEditCt.Columns.Add(dc);
			}

			if (dtEditCt.Rows.Count == 0)
			{
				DataRow drNew = dtEditCt.NewRow();
				Common.SetDefaultDataRow(ref drNew);
				dtEditCt.Rows.Add(drNew);
			}

			//bdsEditCt.DataSource = dtEditCt;
			//dgvEditCt.DataSource = bdsEditCt;
			//dgvEditCt.ClearSelection();

			if(dtEditCt.Rows.Count == 0)
				enuNew_Edit_Voucher = enuEdit.New;
			else
				enuNew_Edit_Voucher = enuEdit.Edit;
		}

		private void Reset_Voucher_Edit()
		{
			dteNgay_Ct.Text = string.Empty;
			txtSo_Ct.Text = txtMa_Dt.Text = lbtTen_Dt.Text = txtOng_Ba.Text = txtDia_Chi.Text = txtMa_Vt_Sp.Text = lbtTen_Vt_Sp.Text = txtDien_Giai.Text = txtSo_Xe.Text = string.Empty;
			
			if (dtEditCt != null)
				dtEditCt.Rows.Clear();
		}

		private void ScaterMemvar_Voucher_Edit(DataRow drEditPh_Dest)
		{
			dteNgay_Ct.Text = Library.DateToStr(Convert.ToDateTime(drEditPh_Dest["Ngay_Ct"]));
			txtSo_Ct.Text = (string)drEditPh_Dest["So_Ct"];
			txtMa_Dt.Text = (string)drEditPh_Dest["Ma_Dt"];
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt.Text.Trim());
				lbtTen_Dt.Text = (string)drDmDt["Ten_Dt"];
				txtOng_Ba.Text = drDmDt["Ong_Ba"].ToString() == string.Empty ? lbtTen_Dt.Text : drDmDt["Ong_Ba"].ToString();
				txtDia_Chi.Text = drDmDt["Dia_Chi"].ToString();
			}
			else
			{
				lbtTen_Dt.Text = txtOng_Ba.Text = txtDia_Chi.Text = string.Empty;
			}

			txtMa_Vt_Sp.Text = (string)drEditPh_Dest["Ma_Vt_Sp"];
			if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
				lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
			else
				lbtTen_Vt_Sp.Text = string.Empty;


			txtDien_Giai.Text = (string)drEditPh_Dest["Dien_Giai"];
			txtSo_Xe.Text = (string)drEditPh_Dest["So_Xe"];
		}

		private void Save()
		{
			return;
			if (dtEditCt == null || dtEditCt.Rows.Count <= 0)
			{
				Common.MsgCancel("Không có dữ liệu chi tiết. Vui lòng quét mã vạch");
				return;
			}

			SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
			SqlCommand sqlCom = sqlCon.CreateCommand();

			sqlCom.CommandText = "sp_Update_Ct";
			sqlCom.CommandType = CommandType.StoredProcedure;

			sqlCom.Parameters.Clear();
			sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)enuNew_Edit_Voucher);
			sqlCom.Parameters.AddWithValue("@Stt", this.strStt);
			sqlCom.Parameters.AddWithValue("@Ma_Ct", strMa_Ct);
			sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);


			//Tạo Table cho TVP_PH
			SqlParameter paraPH = new SqlParameter();
			paraPH.SqlDbType = SqlDbType.Structured;
			paraPH.ParameterName = "@PH";

			//Tạo Table cho TVP_PH
			SqlParameter paraCt = new SqlParameter();
			paraCt.SqlDbType = SqlDbType.Structured;
			paraCt.ParameterName = "@Ct";

			sqlCom.CommandText = "sp_Update_CtX_Barcode";


			//TVP_PH
			paraPH.TypeName = "TVP_PH_SCALE";
			paraPH.Value = Voucher.GetTVPValue("R80PH_SCALE", "TVP_PH_SCALE", dtEditPh_Dest);
			sqlCom.Parameters.Add(paraPH);

			//TVP_CT
			paraCt.TypeName = "TVP_CtX_BARCODE";
			paraCt.Value = Voucher.GetTVPValue("R05CTX_BARCODE", "TVP_CtX_BARCODE", this.dtEditCt);
			sqlCom.Parameters.Add(paraCt);

			try
			{
				sqlCom.ExecuteNonQuery();

				this.strStt_Old = this.strStt;
				//Update to PH
				this.FillData();

				this.strStt = this.strStt_Old;

				if (rdbSo_Xe_Ct.Checked)
				{
					if (cboSo_Xe.SelectedValue != null)
						cboSo_Xe.SelectedValue = strStt;
				}
				else if (rdbSo_Ct_Ct.Checked)
				{
					if (cboSo_Ct.SelectedValue != null)
						cboSo_Ct.SelectedValue = strStt;
				}

				this.FillData_Voucher_Ph();
			}
			catch (Exception ex)
			{
				sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
				sqlCom.CommandType = CommandType.Text;
				sqlCom.Parameters.Clear();
				sqlCom.ExecuteNonQuery();

				MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
			}

			Common.MsgOk("Cập nhật thành công!");
		}

		#region Event
		
		void btPrint_Click(object sender, EventArgs e)
		{
			if (this.strStt != string.Empty)
				Voucher.PrintScale_Out(this.strStt, true, true);
		}

		void cboSo_Xe_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboSo_Xe.SelectedValue != null)
			{
				if (cboSo_Xe.SelectedValue.ToString() != "System.Data.DataRowView" && cboSo_Xe.Enabled)
				{
					this.strStt = cboSo_Xe.SelectedValue == null ? string.Empty : cboSo_Xe.SelectedValue.ToString();

					this.FillData_Voucher_Ph();
				}
			}
		}

		void cboSo_Ct_SelectedValueChanged(object sender, EventArgs e)
		{
			if (cboSo_Ct.SelectedValue != null)
			{
				if (cboSo_Ct.SelectedValue.ToString() != "System.Data.DataRowView" && cboSo_Ct.Enabled)
				{
					this.strStt = cboSo_Ct.SelectedValue == null ? string.Empty : cboSo_Ct.SelectedValue.ToString();
					this.FillData_Voucher_Ph();
				}
			}
		}

		void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			cboSo_Ct.Enabled = rdbSo_Ct_Ct.Checked;
			cboSo_Xe.Enabled = rdbSo_Xe_Ct.Checked;

			this.cboSo_Ct_SelectedValueChanged(null, null);
			this.cboSo_Xe_SelectedValueChanged(null, null);
		}

		void btSave_Voucher_Click(object sender, EventArgs e)
		{
			this.Save();

			this.btEdit.Text = "Sửa";
			this.btSave_Voucher.Enabled = false;
		}
		
		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btPrevious_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			this.bdsEditPh.MovePrevious();
			this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

			if (cboSo_Xe.SelectedValue != null)
				this.cboSo_Xe.SelectedValue = this.strStt;
		}

		void btLast_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			this.bdsEditPh.MoveLast();
			this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

			if (cboSo_Xe.SelectedValue != null)
				this.cboSo_Xe.SelectedValue = this.strStt;
		}

		void btNext_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			if (this.bdsEditPh.Position + 1 < this.bdsEditPh.Count)
			{
				this.bdsEditPh.MoveNext();
				this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

				if (cboSo_Xe.SelectedValue != null)
					this.cboSo_Xe.SelectedValue = this.strStt;
			}
		}

		void btFirst_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			this.bdsEditPh.MoveFirst();

			this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

			if (cboSo_Xe.SelectedValue != null)
				this.cboSo_Xe.SelectedValue = this.strStt;
		}

		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:

					if (dgvEditCt.Focused == false)
						return;

					drCurrent = ((DataRowView)bdsEditCt.Current).Row;
					drCurrent["Deleted"] = !((bool)drCurrent["Deleted"]);

					if ((bool)drCurrent["Deleted"] == true)
					{
						Font font = new Font(dgvEditCt.Font.FontFamily, dgvEditCt.Font.Size, FontStyle.Strikeout);
						dgvEditCt.CurrentRow.DefaultCellStyle.Font = font;
					}
					else
					{
						dgvEditCt.CurrentRow.DefaultCellStyle.Font = dgvEditCt.Font;
					}
					break;
			}
		}

		void dgvEditCt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			foreach (DataGridViewRow dgvRow in dgvEditCt.Rows)
			{
				if (dtEditCt.Columns.Contains("Deleted"))
				{
					if (Convert.ToBoolean(dtEditCt.Rows[dgvRow.Index]["Deleted"]) == true)
					{
						Font font = new Font(dgvEditCt.Font.FontFamily, dgvEditCt.Font.Size, FontStyle.Strikeout);
						dgvRow.DefaultCellStyle.Font = font;
					}
					else
						dgvRow.DefaultCellStyle.Font = dgvEditCt.Font;
				}
			}
		}

		void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "NUM_BARS"))
			{
				if (Convert.ToDouble(drCurrent["Num_Bars"]) != 0)
				{
					if (Convert.ToDouble(drCurrent["Num_Bars"]) <= Convert.ToDouble(drCurrent["Num_Bars_Current"]))
					{
						double dbSo_Luong_Barcode = drCurrent["So_Luong_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["So_Luong_Barcode"]);
						double dbNum_Bars_Barcode = drCurrent["Num_Bars_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars_Barcode"]);

						if (dbSo_Luong_Barcode + dbNum_Bars_Barcode > 0)
						{
							double dbNum_Bars_New = drCurrent["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars"]);
							double dbSo_Luong_Avg = 0;
							double dbSo_Luong = 0;

							if (dbNum_Bars_Barcode != 0)
								dbSo_Luong_Avg = Math.Round(dbSo_Luong_Barcode / dbNum_Bars_Barcode, 4);

							dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0);
							drCurrent["So_Luong"] = dbSo_Luong;
						}
					}
					else
						drCurrent.RejectChanges();
				}
			}

			bdsEditCt.EndEdit();//Cap nhat lai DataSource
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			if (btEdit.Text == "Hủy")
			{
				this.btEdit.Text = "Sửa";
				this.btSave_Voucher.Enabled = false;
				this.grbFilter.Enabled = true;
			}
			else
			{
				this.btEdit.Text = "Hủy";
				this.btSave_Voucher.Enabled = true;
				this.grbFilter.Enabled = false;
			}
		}

		void txtSo_Xe_Filter_Validated(object sender, EventArgs e)
		{
			this.FillData();
		}

		#endregion

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
				return;

			switch (e.KeyCode)
			{
				case Keys.F9:
					this.btRefresh_Click(null, null);
					return;
			}

			base.OnKeyDown(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin)
			{
				if (!Common.CheckPermission("ACCESS_FILTER_DT_TCB", enuPermission_Type.Allow_Access))
					dteNgay_Ct1.Enabled = dteNgay_Ct2.Enabled = false;
			}
		}

	}
}
