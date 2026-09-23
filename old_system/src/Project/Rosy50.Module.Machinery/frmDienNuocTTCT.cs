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
using RosyList;
using RosySystem;
using RosySystem.Library;
using RosySystem.Element;
using System.Collections;
using System.Data.SqlClient;
using RosySystem.Public;

namespace RosyModule.Machinery
{
	public partial class frmDienNuocTTCT : RosySystem.Customize.frmView
	{
        DataTable dtDienNuocTT;
        BindingSource bdsDienNuocTT = new BindingSource();
        DataRow drDienNuocTT;
        
        string strMa_Dt_CbNv = string.Empty;
		DataRow drCurrent;
        string strLoai_Ct;
        string strReportFile = "rptCT_BTKH";
        bool bNew = false;
        public frmDienNuocTTCT()
		{
			InitializeComponent();
		
			this.btExit.Click += new EventHandler(btExit_Click);

            btNew.Click += new EventHandler(btNew_Click);
            this.btRefresh.Click += new EventHandler(btRefresh_Click);
            btDelete.Click += new EventHandler(btDelete_Click);


            txtMa_Bp_Ct.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            dgvDienNuoc.KeyDown += new KeyEventHandler(dgvKHVTPKTDT_KeyDown);

            
            //numThang.TextChanged += new EventHandler(numNam_LostFocus);
            dgvDienNuoc.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDien_CellValidating);
          
		}

        void btRefresh_Click(object sender, EventArgs e)
        {

            FillData(Library.StrToDate(dteNgay_Ct.Text));
        }

    
       

		new public void Load()
		{
            bNew = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New);
            dteNgay_Ct.Text = Library.DateToStr(Element.sysNgay_Ct2.AddDays(0));
            strMa_Dt_CbNv = SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE MEMBER_ID = '" + Element.sysUser_Id + "'").ToString();
            txtMa_Bp_Ct.Text = SQLExec.ExecuteReturnValue("SELECT Ma_Bp_Ct FROM R81DMDT WHERE MA_DT = '" + strMa_Dt_CbNv + "'").ToString();

            if (Common.Inlist(SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE MA_DT = '" + strMa_Dt_CbNv + "'").ToString(), "PTGD,PKTDT,PCNTT") || !bNew)
                txtMa_Bp_Ct.Text = "";
            else 
                txtMa_Bp_Ct.Enabled = false;

            if (!Element.sysIs_Admin)
                btDelete.Enabled = false;

			this.Build();
            FillData(Library.StrToDate(dteNgay_Ct.Text));
			this.BindingLanguage();
            DataLanguage();
			this.Show();
		}

		private void Build()
		{
            
			dgvDienNuoc.strZone = "DIENNUOC";
			dgvDienNuoc.BuildGridView();
            dgvDienNuoc.ReadOnly = false;

            if (!Element.sysIs_Admin)
            {
                dgvDienNuoc.Columns["Stt"].ReadOnly = true;
            }

           
		}
        private void DataLanguage()
        {
            dgvDienNuoc.Columns["Chi_Tieu"].HeaderText = "Vị trí đo điếm";
            dgvDienNuoc.Columns["Tieu_Thu"].HeaderText = "Chỉ số đồng hồ";
            dgvDienNuoc.Columns["Vi_Tri"].HeaderText = "Vị trí lắp đặt";
            dgvDienNuoc.Columns["So_Seri"].HeaderText = "Loại đồng hồ - Seri";
            dgvDienNuoc.Columns["HSN"].HeaderText = "HSN";
            dgvDienNuoc.Columns["Loai_Ct"].HeaderText = "Điện / Nước";
            
            if (dgvDienNuoc.Columns.Contains("Tieu_Thu_Tt"))
                dgvDienNuoc.Columns["Tieu_Thu_Tt"].HeaderText = "Số đồng hồ mới";
        }
		private void FillData(DateTime dtNgay)
		{
            string strLoai_Ct= "";
            DateTime dtNgay_Max;
            DataTable dt = SQLExec.ExecuteReturnDt("SELECT * FROM R11DIENNUOCTTCT WHERE Ngay_Ct = '" + Library.DateToStr(dtNgay) + "' AND Ma_Bp_Ct = '" + txtMa_Bp_Ct.Text + "'");
           
            if (SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM R11DIENNUOCTTCT WHERE Ma_Bp_Ct = '" + txtMa_Bp_Ct.Text + "' AND Ngay_Ct < '" + Library.DateToStr(dtNgay) + "' ") != DBNull.Value )
            {
                dtNgay_Max = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM R11DIENNUOCTTCT WHERE Ma_Bp_Ct = '" + txtMa_Bp_Ct.Text + "' AND Ngay_Ct < '" + Library.DateToStr(dtNgay) + "'"));

                DataTable dt_Bp = SQLExec.ExecuteReturnDt("SELECT * FROM R11DIENNUOCTTCT WHERE Ngay_Ct = '" + Library.DateToStr(dtNgay_Max) + "' AND Ma_Bp_Ct = '" + txtMa_Bp_Ct.Text + "'");
                if (dt.Rows.Count == 0 && dt_Bp.Rows.Count > 0)
                {
                    if (Common.MsgYes_No("Dữ liệu tại ngày " + Library.DateToStr(dtNgay) + " không tồn tại. Bạn có muốn copy dữ liệu ngày hôm trước không?", "Y"))
                        CopyData(Library.StrToDate(dteNgay_Ct.Text), txtMa_Bp_Ct.Text);



                }
            }

            if (rdbDien.Checked)
                strLoai_Ct = "DIEN";
            else if (rdbNuoc.Checked)
                strLoai_Ct = "NUOC";

            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT", dtNgay);
            ht.Add("MA_BP", txtMa_Bp_Ct.Text);
            ht.Add("LOAI_CT", strLoai_Ct);
            dtDienNuocTT = SQLExec.ExecuteReturnDt("sp_GetDienNuocTTCT", ht, CommandType.StoredProcedure);


            bdsDienNuocTT.DataSource = dtDienNuocTT;
            dgvDienNuoc.DataSource = bdsDienNuocTT;




            bdsSearch = bdsDienNuocTT;
            ExportControl = dgvDienNuoc;

           
		}
        private void CopyData(DateTime dtNgay, string strMa_Bp)
        {
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT", dtNgay);
            ht.Add("MA_BP", strMa_Bp);
            ht.Add("MA_DT_CBNV",strMa_Dt_CbNv);
            
            ht.Add("CREATE_LOG",Common.GetCurrent_Log());
            
            SQLExec.Execute("sp_CopyDienNuocTTCT", ht, CommandType.StoredProcedure);
        }


        private bool printDetail_Tb(bool bPreview)
        {
           
            return true;          
        }
        private void Design()
        {
           
        }
        void EditDien_Nuoc(enuEdit enuNew_Edit)
        {
            if (bdsDienNuocTT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            
           
            //Copy dòng hiện tại
            if (bdsDienNuocTT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDienNuocTT.Current).Row, ref drDienNuocTT);
            else
                drDienNuocTT = dtDienNuocTT.NewRow();

            if (enuNew_Edit == enuEdit.New)
            {
                drDienNuocTT["Loai_Ct"] = rdbDien.Checked ? "DIEN" : "NUOC"; ;
                drDienNuocTT["Ma_Bp"] = txtMa_Bp_Ct.Text;
                drDienNuocTT["Ma_Dt_CbNv"] = strMa_Dt_CbNv;
                drDienNuocTT["Ngay_Ct"] = dteNgay_Ct.Text;
                drDienNuocTT["Stt"] = SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Stt),0) + 1 FROM R11DIENNUOCTTCT WHERE Ngay_Ct = '" + dteNgay_Ct.Text + "' AND Ma_Bp = '" + txtMa_Bp_Ct.Text + "' ").ToString();
                
            }
            frmDienNuocTTCT_Edit frmEdit1 = new frmDienNuocTTCT_Edit();
            frmEdit1.Load(enuNew_Edit, drDienNuocTT);

            //Khi người dùng chọn chấp nhận
            if (frmEdit1.isAccept)
            {

               

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDienNuocTT.Position >= 0)
                        dtDienNuocTT.ImportRow(drDienNuocTT);
                    else
                        dtDienNuocTT.Rows.Add(drDienNuocTT);

                    bdsDienNuocTT.Position = bdsDienNuocTT.Find("Ident00", drDienNuocTT["Ident00"]);
                }
                else
                    Common.CopyDataRow(drDienNuocTT, ((DataRowView)bdsDienNuocTT.Current).Row);

                dtDienNuocTT.AcceptChanges();
            }
            else
                dtDienNuocTT.RejectChanges();
        }
        void btNew_Click(object sender, EventArgs e)
        {
            EditDien_Nuoc(enuEdit.New);
        }
        void dgvKHVTPKTDT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            this.Design();
                            break;
                    }
                    break;
              }
        }
        
        void dgvDien_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex < 0)
                return;

            drCurrent = ((DataRowView)bdsDienNuocTT.Current).Row;

            string strColName = dgvDienNuoc.Columns[e.ColumnIndex].Name;
            if (dgvDienNuoc.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode && Convert.ToDouble(drCurrent["Lock"]) != 1)
            {

                string strLastModify_Log = Common.GetCurrent_Log();
             
                //kiểm tra số tiêu thụ > tiêu thụ trước đó
                if (strColName == "TIEU_THU")
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("NGAY_CT", dteNgay_Ct.Text);
                    ht.Add("MA_VTRI", drCurrent["MA_VTRI"]);
                    ht.Add("STT", drCurrent["STT"]);
                    ht.Add("TIEU_THU", Convert.ToDouble(e.FormattedValue));

                    DataTable dt = SQLExec.ExecuteReturnDt("Sp_GetDienNuocTTMax", ht, CommandType.StoredProcedure);
                    DataRow dr = dt.Rows[0];

                    if (Convert.ToDouble(dr["Chenh_Lech"]) < 0 && !Common.MsgYes_No(dr["Dien_Giai"] + ". Bạn có tiếp tục lưu số hiện tại không???", "N"))
                        drCurrent[strColName] = 0;
                    else
                        drCurrent[strColName] = e.FormattedValue;
                }

                if (bNew)
                {
                    string strSQL = "UPDATE R11DIENNUOCTTCT SET " + strColName + " = @Value, LastModify_Log = @LastModify_Log WHERE Ident00 = @Ident00";
                    Hashtable htPara = new Hashtable();
                    htPara["IDENT00"] = drCurrent["Ident00"];
                    htPara["VALUE"] = (Object)Voucher.GetTypeOfTable("R11DIENNUOCTTCT", strColName, e.FormattedValue.ToString());
                    htPara["LASTMODIFY_LOG"] = strLastModify_Log;
                    if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
                    {
                        drCurrent["LastModify_Log"] = strLastModify_Log;
                        drCurrent[strColName] = e.FormattedValue;

                    }

                }
            }
            else if (dgvDienNuoc.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode && Convert.ToDouble(drCurrent["Lock"]) == 1)
            {
                Common.MsgOk("Dữ liệu đã bị khóa bạn không được phép sửa");
                drCurrent.CancelEdit();
            }

        }
        
        void btPrint_Click(object sender, EventArgs e)
        {
            //this.printDetail_Tb(true);
        }
        void btSave_Click(object sender, EventArgs e)
        {
            
        }
        void btDelete_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsDienNuocTT.Current).Row;
            if ((bool)drCurrent["Lock"])
                return;

            if (Common.MsgYes_No("Bạn có muốn xóa vị trí đo điếm "+ drCurrent["Vi_Tri"] +"", "Y"))
            {
                if (DataTool.SQLDelete("R11DIENNUOCTTCT", drCurrent))
                    Common.MsgOk("Đã xóa xong dữ liệu");

                bdsDienNuocTT.RemoveAt(bdsDienNuocTT.Position);
                dtDienNuocTT.AcceptChanges();
            }
            //Hashtable ht = new Hashtable();
            //ht.Add("NGAY_CT", dteNgay_Ct1);
            //DataTable dt = SQLExec.ExecuteReturnDt("SELECT * FROM R11DIENNUOCTTCT WHERE Duyet_PKTCDAT = 1 AND Ngay_Ct = @Ngay_Ct", ht, CommandType.Text);
            //if (dt.Rows.Count > 0)
            //    Common.MsgOk("Dữ liệu đã được PKTDT duyệt không được xóa!!!");
            //else
            //{
            //    if(SQLExec.Execute("DELETE FROM R11DIENNUOCTTCT WHERE Ngay_Ct = @Ngay_Ct", ht, CommandType.Text))
            //        Common.MsgOk("Bạn đã xóa dữ liệu tại ngày '" + Library.DateToStr(dteNgay_Ct1) + "'");
            //}
        }
        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp_Ct.Text.Trim();
            bool bRequire = false;


            DataRow drLookup = Lookup.ShowLookup("MA_BP_CT", txtMa_Bp_Ct.Text, bRequire, "", "");

            if (drLookup == null)
            {
                txtMa_Bp_Ct.Text = string.Empty;

            }
            else
            {
                txtMa_Bp_Ct.Text = (string)drLookup["Ma_Bp_Ct"];
            

            }
        }

       

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

       

        
	}
}
