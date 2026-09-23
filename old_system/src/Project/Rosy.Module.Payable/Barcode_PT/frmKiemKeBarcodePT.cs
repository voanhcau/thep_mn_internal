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
	public partial class frmKiemKeBarcodePT : RosySystem.Customize.frmView
	{
		#region Variable
		
		DataTable dtEditCt;
		DataRow drEditCt;
		BindingSource bdsEditCt = new BindingSource();
        string enuNew_Edit;
		DataRow drCurrent;
        int iCount = 0;
		#endregion

        public frmKiemKeBarcodePT()
		{
			InitializeComponent();

			this.txtBarcode.KeyDown += new KeyEventHandler(txtBarcode_KeyDown);
			this.txtBarcode.LostFocus += new EventHandler(txtBarcode_LostFocus);
            			
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
            this.btExit.Click += new EventHandler(btExit_Click);
            this.btSave.Click += new EventHandler(btSave_Click);
            this.btThem.Click += new EventHandler(btThem_Click);
            this.btSua.Click += new EventHandler(btSua_Click);
            this.btXoa.Click += new EventHandler(btXoa_Click);
			this.dgvEditCt.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);
            this.dgvEditCt.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvEditCt_CellMouseClick);

		}

       

    
		new public void Load()
		{
            this.dteNgay_Kk.Text = Library.DateToStr(DateTime.Now);
            this.dteNgay_Ct2.Text = this.dteNgay_Ct1.Text = Library.DateToStr(Voucher.GetDate_Server());

			this.Build();
			this.FillData();
			this.Init_Ct();
            
			this.Show();
		}

		private void Build()
		{
            dgvEditCt.bSortMode = false;
            dgvEditCt.strZone = "KIEMKE_BARCODEPT";
            dgvEditCt.BuildGridView();

			this.DataGridView_Language();
            
            foreach (DataGridViewColumn dgvc in dgvEditCt.Columns)
                dgvc.ReadOnly = true;

         

		}

		private void DataGridView_Language()
		{
		
			
		}

		private void Init_Ct()
		{
            txtBarcode.Enabled = false;
            btSave.Enabled = false;
          
		}

		private void FillData()
		{
            Hashtable ht = new Hashtable();
         
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dtEditCt = SQLExec.ExecuteReturnDt("sp_GetKiemKeBarcodePT", ht, CommandType.StoredProcedure);

            bdsEditCt.DataSource = dtEditCt;
            dgvEditCt.DataSource = bdsEditCt;

            DataColumn dc = new DataColumn("Deleted", typeof(bool));
            dc.DefaultValue = false;
            dtEditCt.Columns.Add(dc);

            this.ExportControl = dgvEditCt;
		}

		private bool AddRowBarcode(DataTable dtBarcode)
		{
			DataRow drDmBarcode = dtBarcode.Rows[0];
			bool bRow_First = false;
			DataRow drNewRow = null;

			if (dtEditCt.Rows.Count == 0)
			{
				drNewRow = dtEditCt.NewRow();
				Common.SetDefaultDataRow(ref drNewRow);
				bRow_First = true;
                iCount++;
			}

			if (!bRow_First)
			{
				drEditCt = ((DataRowView)bdsEditCt.Current).Row;
				drNewRow = dtEditCt.NewRow();
				Common.CopyDataRow(drEditCt, drNewRow);
				Common.SetDefaultDataRow(ref drNewRow);
			}
            if (dtEditCt.Rows.Count > 0)
            {
                foreach (DataRow dr in dtEditCt.Rows)
                {
                    if (txtBarcode.Text == dr["Barcode"].ToString())
                    {
                        dr["So_Luong"] = Convert.ToDouble(dr["So_Luong"]) + 1;
                        return true;
                    }
                }
            }
             
            drNewRow["Barcode"] = drDmBarcode["Barcode"];
            drNewRow["Ma_Vt"] = drDmBarcode["Ma_Vt"];
            drNewRow["Ma_VTri"] = drDmBarcode["Ma_VTri"];
            drNewRow["Ma_Kho"] = drDmBarcode["Ma_Kho"];
            drNewRow["Ten_Vt"] = drDmBarcode["Ten_Vt"];
            drNewRow["Ngay_Nhap"] = drDmBarcode["Ngay_Nhap"];
            drNewRow["Ngay_KK"] = dteNgay_Kk.Text;
            drNewRow["Create_Log"] = Common.GetCurrent_Log();
            drNewRow["Dvt"] = drDmBarcode["Dvt"];
            drNewRow["So_Luong"] = 1;
            drNewRow["Deleted"] = false;
         
            //dtEditCt.Rows.Add(drNewRow);
            dtEditCt.Rows.InsertAt(drNewRow, 0);
            dtEditCt.AcceptChanges();
            return true;

		}
       
		private bool Save()
		{
            if (dtEditCt.Rows.Count == 0)
            {
                Common.MsgOk("Không có dữ liệu quét barcode");
                return false;
            }
            //Kiểm tra 1 ngày quét 1 barcode 2 lần
            foreach (DataRow dr in dtEditCt.Rows)
            {
                Hashtable ht = new Hashtable();
                ht.Add("BARCODE",dr["Barcode"]);
                ht.Add("NGAY_KK",dr["Ngay_Kk"]);
                string strSQL = "SELECT COUNT(*) FROM R05KIEMKE WHERE Barcode = @Barcode AND Ngay_Kk = @Ngay_KK";
                double iSoLan = Convert.ToDouble(SQLExec.ExecuteReturnValue(strSQL,ht, CommandType.Text));
                if(iSoLan > 1)
                {
                    if (!Common.MsgYes_No("Barcode '" + dr["Barcode"] + "' đã được quét trong ngày kiểm kê '" + dr["Ngay_Kk"] + "'.Bạn có muốn lưu không??", "N"))
                    {
                        dr["Deleted"] = true;
                        return false;
                    }
                }
            }

            SqlCommand sqlcom = SQLExec.GetSQLCommand();
            sqlcom.CommandType = CommandType.StoredProcedure;

            sqlcom.Parameters.Clear();
            sqlcom.Parameters.AddWithValue("@strNew_Edit", enuNew_Edit);
            sqlcom.Parameters.AddWithValue("@MA_DVCS", Element.sysMa_DvCs);
           
            SqlParameter para = new SqlParameter();
            para.ParameterName = "@TVP_Import";
            para.SqlDbType = SqlDbType.Structured;

            para.TypeName = "TVP_KiemKePT";
            para.Value = Voucher.GetTVPValue("R05KIEMKE", "TVP_KiemKePT", dtEditCt);

            sqlcom.Parameters.Add(para);

            sqlcom.CommandText = "Sp_Import_KiemKeBPT";

            try
            {
                sqlcom.ExecuteNonQuery();
                Common.MsgOk(Languages.GetLanguage("END_PROCESS"));
            }
            catch (Exception ex)
            {
                Common.MsgOk(ex.Message);
            }
            return true;
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
                    string strSQL = "SELECT T1.*, Ten_Vt, Dvt FROM R81DMBARCODEPT T1 JOIN R81DMVT T2 ON T1.Ma_Vt = T2.Ma_Vt WHERE Barcode = '" + strBarcode  + "'";
                    DataTable dtBarcode = SQLExec.ExecuteReturnDt(strSQL);
                                       
                    if (AddRowBarcode(dtBarcode))
                    {
                        bdsEditCt.MoveFirst();
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

		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
            txtBarcode.Enabled = false;
		}
        void btSave_Click(object sender, EventArgs e)
        {
            if(Save())
               txtBarcode.Enabled = false;
            btSave.Enabled = false;
            dgvEditCt.Columns["So_Luong"].ReadOnly = true;
        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void btThem_Click(object sender, EventArgs e)
        {
            enuNew_Edit = "N";
            btSave.Enabled = true;
            txtBarcode.Enabled = true;
            dtEditCt.Clear();
            dgvEditCt.Columns["So_Luong"].ReadOnly = false;
            txtBarcode.Focus();
        }
        void btXoa_Click(object sender, EventArgs e)
        {
            if (bdsEditCt.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R05KIEMKE", drCurrent))
            {
                bdsEditCt.RemoveAt(bdsEditCt.Position);
                dtEditCt.AcceptChanges();
            }
        }

        void btSua_Click(object sender, EventArgs e)
        {
            enuNew_Edit = "E";
            dgvEditCt.Columns["So_Luong"].ReadOnly = false;
            btSave.Enabled = true;
        }

        void dgvEditCt_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "CHI_TIET")
            {
                // gán ngày lọc mã VT
                DateTime dteNgay_Nhap = Convert.ToDateTime(SQLExec.ExecuteReturnValue("select dbo.fn_GetNgayPYC ('" + drCurrent["Barcode"].ToString() + "') "));
             

                frmCheckCtVt frm = new frmCheckCtVt();
                frm.Load(drCurrent["Ma_Vt"].ToString(), dteNgay_Nhap);
            }
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

		}

	}
}
