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

namespace RosyModule.Payable
{
	public partial class frmCtNXBarcodePT : RosySystem.Customize.frmView
	{
		#region Variable

		//Luu y toi bManual
		
		DataSet dsVoucher = new DataSet();
		DataTable dtEditPh;
		DataTable dtEditPh_Dest;
		DataTable dtEditCt;
	
		DataRow drEditCt;
		BindingSource bdsEditPh = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
	
		DataRow drCurrent;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;

        string strStt_Org = string.Empty;
        string strStt = string.Empty;
        string strSo_Ct = string.Empty;
		#endregion

        public frmCtNXBarcodePT()
		{
			InitializeComponent();

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			this.txtBarcode.KeyDown += new KeyEventHandler(txtBarcode_KeyDown);
			this.btSave_Voucher.Click += new EventHandler(btSave_Voucher_Click);
			
			this.txtBarcode.LostFocus += new EventHandler(txtBarcode_LostFocus);
			this.dgvEditCt.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.dgvEditCt.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);
            this.cboSo_Ct.SelectedValueChanged += new EventHandler(cboSo_Ct_SelectedValueChanged);
			
            this.btFirst.Click += new EventHandler(btFirst_Click);
			this.btNext.Click += new EventHandler(btNext_Click);
			this.btPrevious.Click += new EventHandler(btPrevious_Click);
			this.btLast.Click += new EventHandler(btLast_Click);

            btNhapBarcode.Click += new EventHandler(btNhapBarcode_Click);
            btAdd_DNX.Click += new EventHandler(btAdd_DNX_Click);
            btInherit.Click += new EventHandler(btInherit_Click);
            btReplaceVTri.Click += new EventHandler(btReplaceVTri_Click);

            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
		}

       
		new public void Load()
		{
			this.dteNgay_Ct1.Text = this.dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server());

			this.Build();
			this.FillData();
			this.Init_Ct();
            btPrint.Visible = false;
			this.Show();
		}

		private void Build()
		{
            dgvEditCt.bSortMode = false;
            dgvEditCt.strZone = "XUAT_BARCODEPT";
            dgvEditCt.BuildGridView();

			this.DataGridView_Language();
            foreach (DataGridViewColumn dgvc in dgvEditCt.Columns)
                dgvc.ReadOnly = true;

            if (dgvEditCt.Columns.Contains("SO_LUONG"))
                dgvEditCt.Columns["SO_LUONG"].ReadOnly = false;
		}

		private void DataGridView_Language()
		{
		
			
		}

		private void Init_Ct()
		{
           

          
		}

		private void FillData()
		{
            Hashtable ht = new Hashtable();
         
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dtEditPh = SQLExec.ExecuteReturnDt("sp_GetXuatBarcodePT_Ph", ht, CommandType.StoredProcedure);
           
            bdsEditPh.DataSource = dtEditPh;

            if (dtEditPh.Rows.Count == 0)
            {
                DataRow drNew = dtEditPh.NewRow();
                Common.SetDefaultDataRow(ref drNew);
                dtEditPh.Rows.Add(drNew);
            }

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
                    if (this.dtEditPh_Dest != null)
                        this.dtEditPh_Dest.Rows.Clear();

                    this.dtEditPh_Dest = dtEditPh.Clone();

                    foreach (DataRow dr in arrdrEditPh_Dest)
                        this.dtEditPh_Dest.ImportRow(dr);

                    this.bdsEditPh.Position = this.bdsEditPh.Find("STT", strStt);
                    this.lbtRecorde.Text = this.bdsEditPh.Position + 1 + "/" + this.bdsEditPh.Count;

                    this.ScaterMemvar_Voucher_Edit(this.dtEditPh_Dest.Rows[0]);
                    this.FillData_Voucher_Ct();
                }
            }
            else
                this.Reset_Voucher_Edit();
        }
        private void FillData_Voucher_Ct()
        {
            Hashtable ht = new Hashtable();

            ht.Add("STT", this.strStt);
            dtEditCt = SQLExec.ExecuteReturnDt("sp_GetXuatBarcodePT_Ct", ht, CommandType.StoredProcedure);

            DataColumn dc = new DataColumn("Deleted", typeof(bool));
            dc.DefaultValue = false;
            dtEditCt.Columns.Add(dc);

            bdsEditCt.DataSource = dtEditCt;
            dgvEditCt.DataSource = bdsEditCt;
        }
        private void Reset_Voucher_Edit()
        {
            dteNgay_Ct.Text = string.Empty;
            txtSo_Ct.Text = txtMa_Dt.Text = lbtTen_Dt.Text = txtOng_Ba.Text = txtDien_Giai.Text = string.Empty;
           

            if (dtEditCt != null)
                dtEditCt.Rows.Clear();
        }

        void cboSo_Ct_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSo_Ct.SelectedValue != null)
            {
                if (cboSo_Ct.SelectedValue.ToString() != "System.Data.DataRowView" )
                {
                    this.strStt = cboSo_Ct.SelectedValue == null ? string.Empty : cboSo_Ct.SelectedValue.ToString();
                    this.FillData_Voucher_Ph();
                }
            }
        }

        void btInherit_Click(object sender, EventArgs e)
        {
            frmInheritDnTt frmInherit = new frmInheritDnTt();
            frmInherit.Load("DNX");

            if (frmInherit.Is_Accept == true)
            {
                if (frmInherit.dtInheritVoucher.Select("Chon = true").Length == 0)
                    return;

                txtMa_Dt.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Dt"].ToString();
                txtDien_Giai.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Dien_Giai"].ToString() + " Số DNX: " + frmInherit.dtInheritVoucher.Select("Chon = true")[0]["So_Ct"].ToString();
                strStt_Org = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Stt"].ToString();
                DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt.Text);

               
            }
        }
        void btReplaceVTri_Click(object sender, EventArgs e)
        {
            frmReplace_BarcodePT frm = new frmReplace_BarcodePT();
            frm.Load();
        }

        void btAdd_DNX_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        void btNhapBarcode_Click(object sender, EventArgs e)
        {
            frmNhapBarcodePT frm = new frmNhapBarcodePT();
            frm.Load();
        }

		private void AddRowBarcode(DataTable dtBarcode)
		{
			DataRow drDmBarcode = dtBarcode.Rows[0];
			bool bRow_First = false;
			DataRow drNewRow = null;

			if (dtEditCt.Rows.Count == 0)
			{
				drNewRow = dtEditCt.NewRow();
				Common.SetDefaultDataRow(ref drNewRow);
				bRow_First = true;
			}

			if (!bRow_First)
			{
				drEditCt = ((DataRowView)bdsEditCt.Current).Row;
				drNewRow = dtEditCt.NewRow();
				Common.CopyDataRow(drEditCt, drNewRow);
				Common.SetDefaultDataRow(ref drNewRow);
			}

			int iStt0 = Convert.ToInt32(Common.MaxDCValue(dtEditCt, "Stt0") + 1);

			
			drNewRow["Stt0"] = iStt0;
			
			
			drNewRow["So_Ct"] = txtSo_Ct.Text;
			drNewRow["Ngay_Ct"] = dteNgay_Ct.Text;
			drNewRow["Ma_Dt"] = txtMa_Dt.Text.Trim();
            drNewRow["Dien_Giai"] = txtDien_Giai.Text;
			drNewRow["Barcode"] = drDmBarcode["Barcode"];
			drNewRow["Ma_Vt"] = drDmBarcode["Ma_Vt"];
            drNewRow["Ma_VTri"] = drDmBarcode["Ma_VTri"];
            drNewRow["Ma_Kho"] = drDmBarcode["Ma_Kho"];
            drNewRow["Ten_Vt"] = drDmBarcode["Ten_Vt"];
            drNewRow["Dvt"] = drDmBarcode["Dvt"];
            //drNewRow["So_Luong"] = drDmBarcode["So_Luong"];
            drNewRow["So_Luong"] = 1;
            drNewRow["Stt_Org"] = strStt_Org;
            drNewRow["Stt"] = strStt;
			
			
			drNewRow["Deleted"] = false;

		

			dtEditCt.Rows.Add(drNewRow);
			dtEditCt.AcceptChanges();

		}
        private void ScaterMemvar_Voucher_Edit(DataRow drEditPh_Dest)
        {
            dteNgay_Ct.Text = Library.DateToStr(Convert.ToDateTime(drEditPh_Dest["Ngay_Ct"]));
            txtSo_Ct.Text = (string)drEditPh_Dest["So_Ct"];
            txtMa_Dt.Text = (string)drEditPh_Dest["Ma_Dt"];
            txtOng_Ba.Text = (string)drEditPh_Dest["Ong_Ba"];
            txtDien_Giai.Text = (string)drEditPh_Dest["Dien_Giai"];

            //this.txtInfoInherit.Text = GetInfoInherit(this.strStt);
        }
        private string GetInfoInherit(string strStt)
        {
            //Hiển thị chứng từ gốc kế thừa
            string strSQLExec = @"
				DECLARE @_InheritList VARCHAR(1000)
				SET @_InheritList = ''
				SELECT @_InheritList = Ma_Ct + ':' + So_Ct
					FROM R80PH 
					WHERE Ma_Ct = ''DNX'' AND Stt IN (SELECT MAX(Stt_Org) FROM R05CTX_BARCODEPT WHERE Stt = '" + strStt + @"')
				SELECT @_InheritList";

            return SQLExec.ExecuteReturnValue(strSQLExec).ToString();
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
            }
        }
	



		private void Save()
		{
			if (dtEditCt == null || dtEditCt.Rows.Count <= 0)
			{
				Common.MsgCancel("Không có dữ liệu chi tiết. Vui lòng quét mã vạch");
				return;
			}
            //Cập nhật phần sửa dữ liệu trên PH
            foreach (DataRow dr in dtEditCt.Rows)
            {
                dr["Ma_Dt"] = txtMa_Dt.Text;
                dr["Ong_Ba"] = txtOng_Ba.Text;
                dr["Dien_Giai"] = txtDien_Giai.Text;
                dr["So_Ct"] = txtSo_Ct.Text;
                dr["Ngay_Ct"] = dteNgay_Ct.Text;
            }
			//Kiểm tra xem barcode có được chuyển sang kho lẻ bó nào không.Tránh trường hợp bị sai khi ngồi đợi lâu quá.
			string strListBarcode = string.Empty;
			
			SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
			SqlCommand sqlCom = sqlCon.CreateCommand();

			sqlCom.CommandText = "sp_Update_Ct";
			sqlCom.CommandType = CommandType.StoredProcedure;

			sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)enuNew_Edit_Voucher);
            sqlCom.Parameters.AddWithValue("@Stt", strStt);
			sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

			//Tạo Table cho TVP_PH
			SqlParameter paraCt = new SqlParameter();
			paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

			sqlCom.CommandText = "sp_Update_CtX_BarcodePT";


			//TVP_CT
            paraCt.TypeName = "TVP_BARCODEPT";
            paraCt.Value = Voucher.GetTVPValue("R05CTX_BARCODEPT", "TVP_BARCODEPT", this.dtEditCt);
			sqlCom.Parameters.Add(paraCt);

			try
			{
				sqlCom.ExecuteNonQuery();
				//Update to PH
				this.FillData();
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

        void btNew_Click(object sender, EventArgs e)
        {
            FillData_Voucher_Ct();
            
            if(dtEditCt.Rows.Count != 0)
                dtEditCt.Clear();
            
            this.dteNgay_Ct.Text = Library.DateToStr(DateTime.Now);
            txtBarcode.ReadOnly = false;
            txtBarcode.Enabled = true;
            btSave_Voucher.Enabled = true;
            btInherit.Enabled = true;
            strStt = Common.GetNewStt("09", true);
            txtSo_Ct.Text = GetNewSo_Ct();
            txtMa_Dt.Text = lbtTen_Dt.Text = txtOng_Ba.Text = txtDien_Giai.Text = string.Empty;
            txtMa_Dt.ReadOnly = txtOng_Ba.ReadOnly = txtDien_Giai.ReadOnly = false;
        }
        void btEdit_Click(object sender, EventArgs e)
        {
            this.enuNew_Edit_Voucher = enuEdit.Edit;
            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];
            txtBarcode.ReadOnly = false;
            txtBarcode.Enabled = true;
            btSave_Voucher.Enabled = true;
            txtMa_Dt.ReadOnly = txtOng_Ba.ReadOnly = txtDien_Giai.ReadOnly = false;
        }
        void btDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void Delete()
        {
            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R05CTX_BARCODEPT", drCurrent))
            {
                bdsEditPh.RemoveAt(bdsEditPh.Position);
                bdsEditCt.RemoveAt(bdsEditCt.Position);
                dtEditCt.AcceptChanges();
            }
        }
        private string GetNewSo_Ct()
        {
            string strSQL = @"SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(So_Ct)) AS BIGINT)), 0) FROM R05CTX_BARCODEPT WHERE YEAR(Ngay_Ct) = YEAR(GETDATE())";
            long iStt = Convert.ToInt64(SQLExec.ExecuteReturnValue(strSQL)) + 1;
            string So_Ct = iStt.ToString().Trim().PadLeft(6, '0');
            return So_Ct;
        }

     
		

		#region Event
		

		void txtBarcode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
              
				this.txtBarcode.Focus();
				this.txtBarcode.Select(0, txtBarcode.Text.Length);
				string strBarcode = txtBarcode.Text.Trim();

				txtBarcode.Text = strBarcode;

				//Check exists Barcode
				if (!DataTool.SQLCheckExist("R81DMBARCODEPT", "Barcode", strBarcode))
				{
					Common.MsgCancel("Bạn nhập mã vạch {" + strBarcode + "} không tồn tại!");
					txtBarcode.BackColor = Color.Red;
					txtBarcode.Select(0, txtBarcode.Text.Length);
					txtBarcode.Focus();
				}
				else
				{
                    string strSQLExec = string.Empty;
                    //strSQLExec = "SELECT * FROM R81DMBARCODEPT WHERE Barcode = '"+ txtBarcode.Text+"'";
                    Hashtable ht = new Hashtable();
                    ht.Add("BARCODE", txtBarcode.Text);
                    DataTable dtBarcode = SQLExec.ExecuteReturnDt("sp_GetBarcodePT", ht, CommandType.StoredProcedure);

                    if (dtBarcode.Rows.Count == 0)
                    {
                        Common.MsgCancel("Vật tư của barcode {" + strBarcode + "} đã được xuất hết.");
                    }
                    else
                    {                     		
						this.AddRowBarcode(dtBarcode);
								
						this.txtBarcode.Focus();
						this.txtBarcode.Select(0, txtBarcode.Text.Length);
						this.txtBarcode.BackColor = SystemColors.Window;
						this.txtBarcode.Text = string.Empty;

                    }
				}
			}
		}

		

		void txtBarcode_LostFocus(object sender, EventArgs e)
		{
			txtBarcode.BackColor = SystemColors.Window;
			txtBarcode.Text = string.Empty;

		}

		void btSave_Voucher_Click(object sender, EventArgs e)
		{
			this.Save();

			this.txtBarcode.Text = string.Empty;
            //this.btEdit.Text = "Sửa";
			this.btSave_Voucher.Enabled = false;
			this.btInherit.Enabled = false;
			this.txtBarcode.Enabled = false;
			this.txtBarcode.ReadOnly = true;
		}
		
		void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            //if (Common.Inlist(strColumnName, "NUM_BARS"))
            //{
            //    if (Convert.ToDouble(drCurrent["Num_Bars"]) != 0 && !(bool)drCurrent["Deleted"])
            //    {
            //        if (Convert.ToDouble(drCurrent["Num_Bars"]) <= Convert.ToDouble(drCurrent["Num_Bars_Current"]))
            //        {
            //            double dbSo_Luong_Barcode = drCurrent["So_Luong_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["So_Luong_Barcode"]);
            //            double dbNum_Bars_Barcode = drCurrent["Num_Bars_Barcode"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars_Barcode"]);
            //            double dbTSo_Luong_OutPut = this.GetTSo_Luong_OutPut(drCurrent["Stt"].ToString(), drCurrent["Barcode"].ToString());
            //            double dbSo_Luong_CL = 0;
            //            double dbSo_Luong_Avg = 0;
            //            double dbSo_Luong = 0;
            //            double dbNum_Bars_New = 0;

            //            if (dbSo_Luong_Barcode + dbNum_Bars_Barcode > 0)
            //            {
            //                dbNum_Bars_New = drCurrent["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars"]);
							
            //                if (dbNum_Bars_Barcode != 0)
            //                    dbSo_Luong_Avg = Math.Round(dbSo_Luong_Barcode / dbNum_Bars_Barcode, 4);

            //                dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0);
            //                dbSo_Luong_CL = Math.Abs(dbSo_Luong_Barcode - (dbTSo_Luong_OutPut + dbSo_Luong));

            //                if (dbSo_Luong_CL > 0 && dbSo_Luong_CL <= 2)
            //                    dbSo_Luong = dbSo_Luong_Barcode - dbTSo_Luong_OutPut;

            //                drCurrent["So_Luong"] = dbSo_Luong;

							
            //            }
            //        }
            //        else
            //            drCurrent.RejectChanges();
            //    }
            //}
			
            //bdsEditCt.EndEdit();//Cap nhat lai DataSource
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

            if (cboSo_Ct.SelectedValue != null)
                this.cboSo_Ct.SelectedValue = this.strStt;
		}

		void btLast_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			this.bdsEditPh.MoveLast();
            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboSo_Ct.SelectedValue != null)
                this.cboSo_Ct.SelectedValue = this.strStt;
		}

		void btNext_Click(object sender, EventArgs e)
		{
			if (bdsEditPh.Position < 0)
				return;

			if (this.bdsEditPh.Position + 1 < this.bdsEditPh.Count)
			{
				this.bdsEditPh.MoveNext();
                this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

                if (cboSo_Ct.SelectedValue != null)
                    this.cboSo_Ct.SelectedValue = this.strStt;
			}
		}

        void btFirst_Click(object sender, EventArgs e)
        {
            if (bdsEditPh.Position < 0)
                return;

            this.bdsEditPh.MoveFirst();

            this.strStt = (string)((DataRowView)bdsEditPh.Current).Row["Stt"];

            if (cboSo_Ct.SelectedValue != null)
                this.cboSo_Ct.SelectedValue = this.strStt;

        }

		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F8:

					if (dgvEditCt.Focused == false)
						return;

					if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
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

				case Keys.F12:
					if (e.Modifiers == Keys.Control)
						base.OnKeyDown(e);
				
					return;

			
			}

			base.OnKeyDown(e);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin)
			{
                //if (!Common.CheckPermission("ACCESS_FILTER_DT_TCB", enuPermission_Type.Allow_Access))
                //    dteNgay_Ct1.Enabled = dteNgay_Ct2.Enabled = false;

                //this.btEdit.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
			}

		}

	}
}
