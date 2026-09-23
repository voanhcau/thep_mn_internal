using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;
using RosySystem;

namespace RosyModule.ScaleBarcode
{
	public partial class frmBarcodeLeLXH : RosySystem.Customize.frmView
	{
		BindingSource bdsBarcode = new BindingSource();
		DataTable dtBarcode = new DataTable();
        DataTable dtBarcode_KCS = new DataTable();
		BindingSource bdsBarcode_Detail = new BindingSource();
        BindingSource bdsBarcode_Detail_KCS = new BindingSource();
        public DataSet dsBarcode_Detail = new DataSet();
		public DataTable dtBarcode_Detail = new DataTable();
        public DataTable dtBarcode_Detail_KCS = new DataTable();
		public bool is_Accept = false;

		DataRow drCurrent;


        public frmBarcodeLeLXH()
		{
			InitializeComponent();

			bdsBarcode.PositionChanged += new EventHandler(bdsBarcode_PositionChanged);
            dgvBarcode_Detail_KCS.CellContentClick += new DataGridViewCellEventHandler(dgvBarcode_Detail_KCS_CellContentClick);

            //txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);

            btNew.Click += new EventHandler(btNew_Click);
            
            btDelete.Click += new EventHandler(btDelete_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
		}

        

		public void Load()
		{
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
			
			this.Build();
			this.FillData_CheckInventory();
			this.FillData_TKCD();
			this.BindingLanguage();
            this.BuildDataGridView();

            this.btNew.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New);
            this.btPrint.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_View);
            this.btDelete.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete);




			this.Show();
		}

		void Build()
		{
            txtMa_Vt_Sp.bUseAutoDropDown = true;

			this.dgvBarcode.strZone = "BARCODELE_LXH";
			this.dgvBarcode.BuildGridView();

            this.dgvBarcode_Detail.strZone = "BARCODELE_LXH_DETAIL";
			this.dgvBarcode_Detail.BuildGridView();

            this.dgvBarcode_Detail_KCS.strZone = "BARCODELE_LXHKCS_DETAIL";
            this.dgvBarcode_Detail_KCS.BuildGridView();

			dgvBarcode.ReadOnly = false;
            dgvBarcode_Detail_KCS.ReadOnly = false;
           
           

			foreach (DataGridViewColumn dgvc in dgvBarcode_Detail.Columns)
				dgvc.ReadOnly = true;

            this.ExportControl = dgvBarcode;
		}
        private void BuildDataGridView()
        {
            this.dgvBarcode_Detail_KCS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarcode_Detail_KCS.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;

            if (this.dgvBarcode_Detail_KCS.Columns.Contains("IS_TL"))
                this.dgvBarcode_Detail_KCS.Columns["IS_TL"].HeaderText = "Là trả lại";
        }
		void FillData_CheckInventory()
		{
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
            ht.Add("IS_TL", chkIs_TL.Checked);
            dtBarcode = SQLExec.ExecuteReturnDt("sp_GetBarcodeLeLXH", ht, CommandType.StoredProcedure);
			bdsBarcode.DataSource = dtBarcode;
			dgvBarcode.DataSource = bdsBarcode;
            bdsBarcode.Position = bdsBarcode.Count;
		}

		void FillData_TKCD()
		{
            //string Barcode_List = string.Empty;
            //if (dtBarcode != null)
            //{
            //    foreach (DataRow dr in dtBarcode.Rows)
            //        Barcode_List = Barcode_List + dr["Barcode"].ToString() + ",";
            //}

            //if (Barcode_List.EndsWith(","))
            //    Barcode_List = Barcode_List.Substring(0, Barcode_List.Length - 1);

            //Hashtable htPara = new Hashtable();
            //htPara.Add("BARCODE_LIST", Barcode_List);
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
       
            dsBarcode_Detail = SQLExec.ExecuteReturnDs("sp_GetBarcodeLeLXH_Detail", ht, CommandType.StoredProcedure);

            dtBarcode_Detail = dsBarcode_Detail.Tables[0];
			bdsBarcode_Detail.DataSource = dtBarcode_Detail;
			dgvBarcode_Detail.DataSource = bdsBarcode_Detail;
            
            bdsBarcode_Detail.Position = bdsBarcode_Detail.Count;

			this.dgvBarcode_Detail.ResizeGridView(100);


            dtBarcode_Detail_KCS = dsBarcode_Detail.Tables[1];
            bdsBarcode_Detail_KCS.DataSource = dtBarcode_Detail_KCS;
            dgvBarcode_Detail_KCS.DataSource = bdsBarcode_Detail_KCS;

            this.dgvBarcode_Detail_KCS.ResizeGridView(100);
		}
		
		

		void bdsBarcode_PositionChanged(object sender, EventArgs e)
		{
			if (bdsBarcode.Position < 0)
				return;

			string strBarcode = ((DataRowView)bdsBarcode.Current).Row["Barcode_LXH"].ToString();
            bdsBarcode_Detail.Filter = "Barcode_LXH = '" + strBarcode + "'";
            bdsBarcode_Detail_KCS.Filter = "Barcode_LXH = '" + strBarcode + "'";
		}
        void btPrint_Click(object sender, EventArgs e)
        {
            if (bdsBarcode.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsBarcode.Current).Row;
            //Xu ly goi mau in etiket
            bool bGC = false;
            if(drCurrent["So_Ct_Lxh"].ToString() != "")
                bGC = true;
            
            this.Print(drCurrent["Barcode_LXH"].ToString(), false, bGC);
        }
        private void Print(string strBarcode, bool bIs_Barem, bool bPreview)
        {
           Voucher.PrintBarcode(strBarcode, bIs_Barem, false, Variables.strPrint_Barcode,false);
           string strSQL = "UPDATE R05BARCODELE SET Is_Print = 1 WHERE Barcode_LXH = '" + strBarcode + "'";
           SQLExec.Execute(strSQL);
        }
	    void btDelete_Click(object sender, EventArgs e)
        {
            if (bdsBarcode.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsBarcode.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            string strBarcode_LXH = drCurrent["Barcode_LXH"].ToString();
            //Kiểm tra barcode_LXH đã xuất chưa
            if (DataTool.SQLCheckExist("R05CTX_BARCODE", "Barcode", strBarcode_LXH))
            {
                Common.MsgOk("Barcode này đã được xuất. Bạn không được xóa!!!");
            }
            else
            {
                //Xóa R05BARCODELE
                SQLExec.Execute("DELETE FROM R05BARCODELE WHERE Barcode_LXH = '" + strBarcode_LXH + "'");
                //Xóa R81DMBARCODE
                SQLExec.Execute("DELETE FROM R81DMBARCODE WHERE Barcode = '" + strBarcode_LXH + "'");
                //Xóa R05CTX_BARCODE
                string strStt = SQLExec.ExecuteReturnValue("SELECT MAX(Stt) FROM R05CTX_BARCODE WHERE So_Ct = '"+ strBarcode_LXH +"'").ToString();
                SQLExec.Execute("DELETE FROM R05CTX_BARCODE WHERE Stt = '" + strStt + "' AND Stt <> ''");
                //Xóa R80PH_SCALE
                SQLExec.Execute("DELETE FROM R80PH_SCALE WHERE Stt = '" + strStt + "' AND Stt <> ''");
            }
            FillData_TKCD();
            FillData_CheckInventory();
        }

        void btEdit_Click(object sender, EventArgs e)
        {
           Edit_BarcodeLe(enuEdit.Edit);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            Edit_BarcodeLe(enuEdit.New);
        }
        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData_CheckInventory();
            FillData_TKCD();
        }
        private void Edit_BarcodeLe(enuEdit enuNew_Edit)
        {
            if (bdsBarcode.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

           
            //DataRow drEditCt = ((DataRowView)bdsBarcode.Current).Row;
           
            //Copy hang hien tai            
            //if (bdsBarcode_Detail.Position >= 0)
            //    Common.CopyDataRow(((DataRowView)bdsBarcode_Detail.Current).Row, ref drCurrent);
            //else
            //    Common.CopyDataRow(((DataRowView)bdsBarcode.Current).Row, ref drCurrent);

            frmBarcodeLeLXH_Edit frm = new frmBarcodeLeLXH_Edit();
            frm.Load(enuNew_Edit, drCurrent);

            if (frm.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                    //if (bdsBarcode_Detail.Position >= 0)
						dtBarcode.ImportRow(drCurrent);
                    //else
                    //    dtBarcode_Detail.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsBarcode.Current).Row);
				}
                //Xử lý phần xuất barcode le
                //tạo barcode LXH trong  R81DMBARCODE
                //bdsBarcode.Position = bdsBarcode_Detail.Find("BARCODE", drCurrent["Barcode"]);
				dtBarcode.AcceptChanges();
			}
			else
				dtBarcode.RejectChanges();

            FillData_TKCD();
            FillData_CheckInventory();
            }

        void dgvBarcode_Detail_KCS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (bdsBarcode_Detail_KCS.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsBarcode_Detail_KCS.Current).Row;
            string strColumn_Name = dgvBarcode_Detail_KCS.Columns[e.ColumnIndex].DataPropertyName;
            string strSQLExec = string.Empty;
            Hashtable htPara = new Hashtable();
            if (Common.CheckPermission("LOCKED_BARCODE", enuPermission_Type.Allow_Access) || Element.sysIs_Admin)
            {
                if ((bool)drCurrent["Is_TL"])
                {
                    if (Common.Inlist(strColumn_Name, "IS_OUTPUT,IS_WAIT_PROCESS,IS_THU_PHAM"))
                    {
                        if (strColumn_Name == "IS_OUTPUT")
                        {
                            drCurrent[strColumn_Name] = true;
                            drCurrent["IS_WAIT_PROCESS"] = drCurrent["IS_THU_PHAM"] = false;
                        }
                        else if (strColumn_Name == "IS_WAIT_PROCESS")
                        {
                            drCurrent[strColumn_Name] = true;
                            drCurrent["IS_OUTPUT"] = drCurrent["IS_THU_PHAM"] = false;
                        }
                        else if (strColumn_Name == "IS_THU_PHAM")
                        {
                            drCurrent[strColumn_Name] = true;
                            drCurrent["IS_OUTPUT"] = drCurrent["IS_WAIT_PROCESS"] = false;
                        }
                        drCurrent["Is_TL"] = false;
                        drCurrent["Ngay_XLNTL"] = Voucher.GetDate_Server();
                        drCurrent["LastModify_Log_KCS"] = Common.GetCurrent_Log();


                    }
                    //cập nhật dữ liệu
                    strSQLExec = "UPDATE R05BARCODELE SET Is_OutPut = @Is_OutPut, Is_Wait_Process = @Is_Wait_Process, Is_TL = @Is_TL, Is_Thu_Pham = @Is_Thu_Pham, " +
                                        " LastModify_Log_KCS = @LastModify_Log_KCS, Ngay_XLNTL = @Ngay_XLNTL WHERE Ident00 = @Ident00";
                    htPara = new Hashtable();
                    htPara["IDENT00"] = drCurrent["Ident00"];
                    htPara["IS_OUTPUT"] = drCurrent["Is_OutPut"];
                    htPara["IS_WAIT_PROCESS"] = drCurrent["Is_Wait_Process"];
                    htPara["IS_THU_PHAM"] = drCurrent["Is_Thu_Pham"];
                    htPara["IS_TL"] = drCurrent["Is_TL"];
                    htPara["NGAY_XLNTL"] = Voucher.GetDate_Server();
                    htPara["LASTMODIFY_LOG_KCS"] = Common.GetCurrent_Log();

                    try
                    {
                        RosySystem.Data.SQLExec.Execute(strSQLExec, htPara, CommandType.Text);

                        drCurrent.AcceptChanges();
                    }
                    catch (Exception ex)
                    {
                        Common.MsgCancel("Có lỗi cập nhật");
                        return;
                    }
                }
            }
            else
            {
                drCurrent["Is_TL"] = drCurrent["Is_OutPut"] = drCurrent["Is_Thu_Pham"] = false;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

           
        }

        //private void rsDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

	}
}
