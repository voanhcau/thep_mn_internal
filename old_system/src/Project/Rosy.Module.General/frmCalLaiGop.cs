using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

using RosySystem;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Common;


namespace RosyModule.General
{
	public partial class frmCalLaiGop : RosySystem.Customize.frmView
	{
        DataSet dsCalLaiGop;

        DataTable dtThanhToan;
		DataTable dtHanTt;
       
		BindingSource bdsThanhToan = new BindingSource();
		BindingSource bdsHanTt = new BindingSource();

        BindingSource bdsExportExcel = new BindingSource();
       

		public frmVoucher_Edit frmEditCt;
		public string strStt = string.Empty;
        string strReportFile = string.Empty;
      
        DataRow drCurent;
		#region Contructor

        public frmCalLaiGop()
		{
			InitializeComponent();

            dteNgay_Ct1.LostFocus += DteNgay_Ct1_LostFocus;
            dteNgay_Ct2.LostFocus += DteNgay_Ct2_LostFocus;
           
            dgvHanTt.GotFocus+=new EventHandler(dgvHanTt_GotFocus);
            
            this.btRefresh.Click += new EventHandler(btRefresh_Click);
            this.btImport.Click += BtImport_Click;
			this.btExit.Click += new EventHandler(btExit_Click);
            this.btKQLaiGop.Click += BtKQLaiGop_Click;
           
		}

       

        new public void Load()
		{
            //numMuc_Ck.Value = Convert.ToInt32(Parameters.GetParaValue("MUC_CK"));
            //numTy_Le_Ck.Value = Convert.ToInt32(Parameters.GetParaValue("TY_LE_CK"));

            dteNgay_Ct2.Text = Library.DateToStr(DateTime.Now);
            dteNgay_Ct1.Text = Library.DateToStr(DateTime.Now.Subtract(new TimeSpan(DateTime.Now.Day-1, 0, 0, 0)));

            Build();

            FillThanhToanFromCongNo();

			BindingLanguage();

            dteNgay_Ct1.Focus();

		
			this.Show();
			
		}
        
        

		public void Load(frmVoucher_Edit frmEditCt)
		{
			this.frmEditCt = frmEditCt;

			this.Load();
		}

		#endregion

		#region Method

		private void Build()
		{
           
            dgvHanTt.ReadOnly = false;
			dgvHanTt.strZone = "KQCALLAIGOP";
			dgvHanTt.BuildGridView();

          
            DataGridView_Language();

        }
        
        private void FillThanhToanFromCongNo()
		{
			if (dteNgay_Ct1.IsNull )
				return;

			
			Hashtable htParameter = new Hashtable();

            htParameter.Add("NGAY_CT1", Library.StrToDate(this.dteNgay_Ct1.Text));
            htParameter.Add("NGAY_CT2", Library.StrToDate(this.dteNgay_Ct2.Text));
            htParameter.Add("SL_MT1", numSl_Mt1.Value);
            htParameter.Add("SL_MT2", numSl_Mt2.Value);
            htParameter.Add("GIA_MT1", numGia_Mt1.Value);
            htParameter.Add("GIA_MT2", numGia_Mt2.Value);
           
            htParameter.Add("SO_THUC", chkSo_Thuc.Checked);
            htParameter.Add("MA_DVCS", Element.sysMa_DvCs);

            dsCalLaiGop = SQLExec.ExecuteReturnDs("sp_GetKQCalLaiGop", htParameter, CommandType.StoredProcedure);

            
            dtHanTt = dsCalLaiGop.Tables[0];
            bdsHanTt.DataSource = dtHanTt;
            dgvHanTt.DataSource = bdsHanTt;
            dgvHanTt.ReadOnly = true;

            dtThanhToan = dsCalLaiGop.Tables[1];
            bdsThanhToan.DataSource = dtThanhToan;
           

            this.ExportControl = dgvHanTt;

        }
        private void DataGridView_Language()
        {
            if (dgvHanTt.Columns.Contains("DK_SL"))
                dgvHanTt.Columns["DK_SL"].HeaderText = "SL đầu kỳ";
            if (dgvHanTt.Columns.Contains("DK_DG"))
                dgvHanTt.Columns["DK_DG"].HeaderText = "Giá đầu kỳ";
            if (dgvHanTt.Columns.Contains("DK_GT"))
                dgvHanTt.Columns["DK_GT"].HeaderText = "Tiền đầu kỳ";
            if (dgvHanTt.Columns.Contains("NK_SL"))
                dgvHanTt.Columns["NK_SL"].HeaderText = "SL nhập kho";
            if (dgvHanTt.Columns.Contains("NK_DG"))
                dgvHanTt.Columns["NK_DG"].HeaderText = "Giá nhập kho";
            if (dgvHanTt.Columns.Contains("NK_GT"))
                dgvHanTt.Columns["NK_GT"].HeaderText = "Tiền nhập kho";
            if (dgvHanTt.Columns.Contains("GiaXK"))
                dgvHanTt.Columns["GiaXK"].HeaderText = "Giá xuất kho";

            if (dgvHanTt.Columns.Contains("So_Luong"))
                dgvHanTt.Columns["So_Luong"].HeaderText = "SL thực hiện (tấn)";
            if (dgvHanTt.Columns.Contains("Gia"))
                dgvHanTt.Columns["Gia"].HeaderText = "Giá thực hiện (đồng)";
            if (dgvHanTt.Columns.Contains("Tien"))
                dgvHanTt.Columns["Tien"].HeaderText = "Tiền thực hiện (triệu đồng)";

            if (dgvHanTt.Columns.Contains("So_Luong_Kh"))
                dgvHanTt.Columns["So_Luong_Kh"].HeaderText = "SL kế hoạch (tấn)";
            if (dgvHanTt.Columns.Contains("Gia_Kh"))
                dgvHanTt.Columns["Gia_Kh"].HeaderText = "Giá kế hoạch (đồng)";
            if (dgvHanTt.Columns.Contains("Tien_Kh"))
                dgvHanTt.Columns["Tien_Kh"].HeaderText = "Tiền kế hoạch (triệu đồng)";

            
            //for (int i = 1; i < 32; i = i + 1)
            //{
            //    dgvNXT.Columns["Tien_Dt" + i].HeaderText = "Doanh thu ngày " + i;
            //}
        }
        private void DteNgay_Ct1_LostFocus(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dteNgay_Ct1.Text) > Convert.ToDateTime(dteNgay_Ct2.Text))
            {
                Common.MsgOk("Từ ngày phải nhỏ hơn hoặc bằng đến ngày");
                dteNgay_Ct1.Text = dteNgay_Ct2.Text;
                dteNgay_Ct1.Focus();
            }
        }

        private void DteNgay_Ct2_LostFocus(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dteNgay_Ct1.Text) > Convert.ToDateTime(dteNgay_Ct2.Text))
            {
                Common.MsgOk("Từ ngày phải nhỏ hơn hoặc bằng đến ngày");
                dteNgay_Ct2.Text = dteNgay_Ct1.Text;
                dteNgay_Ct2.Focus();
            }
        }
        void btRefresh_Click(object sender, EventArgs e)
        {
            FillThanhToanFromCongNo();
        }
        private void BtKQLaiGop_Click(object sender, EventArgs e)
        {
            frmKQCalLaiGop frm = new frmKQCalLaiGop();
            frm.Load(dtThanhToan);
           

        }
        private void BtImport_Click(object sender, EventArgs e)
        {
            frmReadExcel frmImport = new frmReadExcel();
            frmImport.Load();

            if(frmImport.isAccept)
            {
                //lưu dữ liệu xuống table
                DataTable dtLaiGopKh = SQLExec.ExecuteReturnDt("SELECT * FROM R82LAIGOPKH WHERE 0 = 1");
                DateTime dteNgay_Max; int iNam; int iThang;
                iNam = Convert.ToInt16(frmImport.dtImport.Rows[0]["Nam"]);
                iThang = Convert.ToInt16(frmImport.dtImport.Rows[0]["Thang"]);
                if(SQLExec.ExecuteReturnDt("SELECT * FROM R82LAIGOPKH WHERE YEAR(Ngay_Ap) = "+iNam+ " AND MONTH(Ngay_Ap) = " + iThang+"").Rows.Count > 0)
                {
                    dteNgay_Max = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(Ngay_Ap),'') FROM R82LAIGOPKH WHERE YEAR(Ngay_Ap) = " + iNam + "" +
                        "   AND MONTH(Ngay_Ap) = " + iThang + " "));
                    dteNgay_Max = dteNgay_Max.AddDays(1);
                }
                else
                    dteNgay_Max = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetDate(" + iNam + "," + iThang + ",1)"));
               
                foreach (DataRow drImport in frmImport.dtImport.Rows)
                {
                    

                    DataRow drNew = dtLaiGopKh.NewRow();
                    DataTool.SetDefaultDataRow(ref drNew);
                    //Common.CopyDataRow(drImport, drNew);


                    drNew["Stt"] = drImport["Stt"];
                    if (drImport["Ma_So"] == null || drImport["Ma_So"] == "" || drImport["Ma_So"] == string.Empty)
                        drNew["Ma_So"] = "";
                    else
                        drNew["Ma_So"] = drImport["Ma_So"];

                    if (drImport["Chi_Tieu"] == null || drImport["Chi_Tieu"] == "" || drImport["Chi_Tieu"] == string.Empty)
                        drNew["Chi_Tieu"] = "";
                    else
                        drNew["Chi_Tieu"] = drImport["Chi_Tieu"];

                    if (drImport["SL_TT"] == null || drImport["SL_TT"] == "" || drImport["SL_TT"] == string.Empty)
                        drNew["So_Luong"] = 0;
                    else
                        drNew["So_Luong"] = drImport["SL_TT"];
                    
                    if (drImport["DG_TT"] == null || drImport["DG_TT"] == "" || drImport["DG_TT"] == string.Empty)
                        drNew["Gia"] = 0;
                    else 
                        drNew["Gia"] = drImport["DG_TT"];
                   
                    if (drImport["TT_TT"] == null || drImport["TT_TT"] == "" || drImport["TT_TT"] == string.Empty)
                        drNew["Tien"] = 0;
                    else
                        drNew["Tien"] = drImport["TT_TT"];
                   
                    if (drImport["SL_KH"] == null || drImport["SL_KH"] == "" || drImport["SL_KH"] == string.Empty)
                        drNew["So_Luong_Kh"] = 0;
                    else
                        drNew["So_Luong_Kh"] = drImport["SL_KH"];
                    
                    if (drImport["DG_KH"] == null || drImport["DG_KH"] == "" || drImport["DG_KH"] == string.Empty)
                        drNew["Gia_Kh"] = 0;
                    else
                        drNew["Gia_Kh"] = drImport["DG_KH"];

                    if (drImport["TT_KH"] == null || drImport["TT_KH"] == "" || drImport["TT_KH"] == string.Empty)
                        drNew["Tien_Kh"] = 0;
                    else
                        drNew["Tien_Kh"] = drImport["TT_KH"];

                    if (drImport["Dk_sl"] == null || drImport["Dk_sl"] == "" || drImport["Dk_sl"] == string.Empty)
                        drNew["Dk_sl"] = 0;
                    else
                        drNew["Dk_sl"] = drImport["Dk_sl"];
                    
                    if (drImport["Dk_gt"] == null || drImport["Dk_gt"] == "" || drImport["Dk_gt"] == string.Empty)
                        drNew["Dk_gt"] = 0;
                    else
                        drNew["Dk_gt"] = drImport["Dk_gt"];
                   
                    if (drImport["Dk_dg"] == null || drImport["Dk_dg"] == "" || drImport["Dk_dg"] == string.Empty)
                        drNew["Dk_dg"] = 0;
                    else
                        drNew["Dk_dg"] = drImport["Dk_dg"];
                   
                    if (drImport["Nk_sl"] == null || drImport["Nk_sl"] == "" || drImport["Nk_sl"] == string.Empty)
                        drNew["Nk_sl"] = 0;
                    else
                        drNew["Nk_sl"] = drImport["Nk_sl"];
                    
                    if (drImport["Nk_gt"] == null || drImport["Nk_gt"] == "" || drImport["Nk_gt"] == string.Empty)
                        drNew["Nk_gt"] = 0;
                    else
                        drNew["Nk_gt"] = drImport["Nk_gt"];
                    
                    if (drImport["Nk_dg"] == null || drImport["Nk_dg"] == "" || drImport["Nk_dg"] == string.Empty)
                        drNew["Nk_dg"] = 0;
                    else
                        drNew["Nk_dg"] = drImport["Nk_dg"];
                   
                    if (drImport["GiaXK"] == null || drImport["GiaXK"] == "" || drImport["GiaXK"] == string.Empty)
                        drNew["GiaXK"] = 0;
                    else
                        drNew["GiaXK"] = drImport["GiaXK"];

                    if (drNew.Table.Columns.Contains("Create_Log"))
                        drNew["Create_Log"] = Common.GetCurrent_Log();

                    if (drNew.Table.Columns.Contains("Ma_Data"))
                        drNew["Ma_Data"] = Element.sysMa_Data;

                    if (drNew.Table.Columns.Contains("Ngay_Ap"))
                        drNew["Ngay_Ap"] = dteNgay_Max;


                    DataTool.SQLUpdate(enuEdit.New, "R82LAIGOPKH", ref drNew);
                }
            }
            FillThanhToanFromCongNo();
        }


        #endregion

        #region Event



        ////Gắn đối tượng tìm kiếm
        void dgvHanTt_GotFocus(object sender, EventArgs e)
        {
            //this.ExportControl = dgvExportExcel;
            this.bdsSearch = bdsThanhToan;
        }

        
		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion
        
       
     
		protected override void OnShown(EventArgs e)
		{
            //if (dgvHanTt.Columns.Contains("NGAY_CT_TT"))
            //{
            //    foreach (DataGridViewRow dgvr in dgvHanTt.Rows)
            //    {
            //        if (dgvr.Cells["Ngay_Ct_Tt"].Value.GetType() == typeof(DateTime))
            //        {
            //            if (!Common.CheckDataLocked((DateTime)(dgvr.Cells["Ngay_Ct_Tt"].Value)))
            //            {
            //                dgvr.ReadOnly = true;
            //                dgvr.DefaultCellStyle.ForeColor = Color.Gray;
            //            }
            //        }
            //    }
            //}
            DataGridView_Language();

            base.OnShown(e);
		}

        
      
	}
}
