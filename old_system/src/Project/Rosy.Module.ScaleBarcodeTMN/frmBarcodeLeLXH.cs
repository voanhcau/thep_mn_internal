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

namespace RosyModule.ScaleBarcodeTMN
{
	public partial class frmBarcodeLeLXH : RosySystem.Customize.frmView
	{
		BindingSource bdsBarcode = new BindingSource();
		DataTable dtBarcode = new DataTable();

		BindingSource bdsBarcode_Detail = new BindingSource();
		public DataTable dtBarcode_Detail = new DataTable();
		public bool is_Accept = false;

		DataRow drCurrent;


        public frmBarcodeLeLXH()
		{
			InitializeComponent();

            bdsBarcode.PositionChanged += new EventHandler(bdsBarcode_PositionChanged);
			

            //txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
            //txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);

            btNew.Click += new EventHandler(btNew_Click);
            btBarcodeLe.Click += new EventHandler(btBarcodeLe_Click);
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
			this.Show();
		}
        void LoadDicName()
        {
          
        }
		void Build()
		{
            txtMa_Vt_Sp.bUseAutoDropDown = true;
            txtMa_Kho.bUseAutoDropDown = true;

			this.dgvBarcode.strZone = "BARCODELE_LXH_KKV";
			this.dgvBarcode.BuildGridView();

            this.dgvBarcode_Detail.strZone = "BARCODELE_LXH_KKV_DETAIL";
			this.dgvBarcode_Detail.BuildGridView();

			dgvBarcode.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvBarcode_Detail.Columns)
				dgvc.ReadOnly = true;
		}

		void FillData_CheckInventory()
		{
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("MA_KHO", txtMa_Kho.Text);
            ht.Add("MA_VT_SP", txtMa_Vt_Sp.Text);

            dtBarcode = SQLExec.ExecuteReturnDt("sp_GetBarcodeLeKKV", ht, CommandType.StoredProcedure);
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
            ht.Add("MA_KHO", txtMa_Vt_Sp.Text);
            ht.Add("MA_VT_SP", txtMa_Vt_Sp.Text);
            dtBarcode_Detail = SQLExec.ExecuteReturnDt("sp_GetBarcodeLeKKV_Detail", ht, CommandType.StoredProcedure);


			bdsBarcode_Detail.DataSource = dtBarcode_Detail;
			dgvBarcode_Detail.DataSource = bdsBarcode_Detail;
            bdsBarcode_Detail.Position = bdsBarcode_Detail.Count;

			this.dgvBarcode_Detail.ResizeGridView(100);
		}
		
		

		void bdsBarcode_PositionChanged(object sender, EventArgs e)
		{
			if (bdsBarcode.Position < 0)
				return;

			string strBarcode = ((DataRowView)bdsBarcode.Current).Row["Barcode_LXH"].ToString();
            bdsBarcode_Detail.Filter = "Barcode_LXH = '" + strBarcode + "'";
		}
        void btBarcodeLe_Click(object sender, EventArgs e)
        {
            frmChuyenBarcodeLe frm = new frmChuyenBarcodeLe();

            frm.Load(txtMa_Kho.Text, txtMa_Vt_Sp.Text);
        }
        void btPrint_Click(object sender, EventArgs e)
        {
            if (bdsBarcode.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsBarcode.Current).Row;

            this.Print(drCurrent["Barcode_LXH"].ToString(), false, false);
        }
        private void Print(string strBarcode, bool bIs_Barem, bool bPreview)
        {
           //Voucher.PrintBarcode(strBarcode, bIs_Barem, false, Variables.strPrint_Barcode);
            if (Print(strBarcode, false, Variables.strPrint_Barcode))
            {
                string strSQL = "UPDATE R05BARCODELE SET Is_Print = 1 WHERE Barcode_LXH = '" + strBarcode + "'";
                SQLExec.Execute(strSQL);
            }
        }
        bool Print(string strBarcode, bool bPreview, string strPrint_Name)
        {
            Hashtable ht = new Hashtable();
            ht.Add("BARCODE", strBarcode);
          
            ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

            DataTable dtBarcode = SQLExec.ExecuteReturnDt("sp_PrintBarcodeLXH_KKV", ht, CommandType.StoredProcedure);

            dtBarcode.Columns.Add("REPORT_FILE", typeof(string));

            DataRow drHeader = dtBarcode.Rows[0];

            string strGrade_ID_XK = Parameters.GetParaValue("MAC_THEP_XK_LIST").ToString();
            if ((bool)dtBarcode.Rows[0]["Is_New"] && !Common.Inlist(dtBarcode.Rows[0]["Grade_ID"].ToString(), strGrade_ID_XK))
                drHeader["Report_File"] = "rptBarcode_TT_ND";
            else if ((bool)dtBarcode.Rows[0]["Is_New"] && Common.Inlist(dtBarcode.Rows[0]["Grade_ID"].ToString(), strGrade_ID_XK))
                drHeader["Report_File"] = "rptBarcode_TT_XK";
            else
                drHeader["Report_File"] = "rptBarcode_TT";

           

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drHeader, dtBarcode, bPreview, strPrint_Name);
        }
	    void btDelete_Click(object sender, EventArgs e)
        {
            if (bdsBarcode.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsBarcode.Current).Row;
             string strStt = string.Empty;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            string strBarcode_LXH = drCurrent["Barcode_LXH"].ToString();
            //Kiểm tra barcode_LXH đã xuất chưa
            if (DataTool.SQLCheckExist("R05CTX_BARCODE_KKV", "Barcode", strBarcode_LXH))
            {
                Common.MsgOk("Barcode này đã được xuất. Bạn không được xóa!!!");
            }
            else
            {
                
                //Xóa R05BARCODELE
                SQLExec.Execute("DELETE FROM R05BARCODELEKKV WHERE Barcode_LXH = '" + strBarcode_LXH + "'");
                //Xóa R05CTN_BARCODE_KKV
                strStt = SQLExec.ExecuteReturnValue("SELECT MAX(Stt) FROM R05CTN_BARCODE_KKV WHERE Barcode = '"+ strBarcode_LXH +"'").ToString();
                SQLExec.Execute("DELETE FROM R05CTN_BARCODE_KKV WHERE Stt = '" + strStt + "' ");
                //Xóa R80PH_SCALE
                SQLExec.Execute("DELETE FROM R80PH_BARCODE_KKV WHERE Stt = '" + strStt + "' ");

                //Xóa R05CTX_BARCODE_KKV
                strStt = strStt.Replace('N', 'X');
                SQLExec.Execute("DELETE FROM R05CTX_BARCODE_KKV WHERE Stt = '" + strStt + "'");
                //Xóa R80PH_SCALE
                SQLExec.Execute("DELETE FROM R80PH_BARCODE_KKV WHERE Stt = '" + strStt + "'");
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
            frm.Load(enuNew_Edit, drCurrent, txtMa_Kho.Text);

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

        //void txtMa_Kho_Validating(object sender, CancelEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
        //void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

           
        }

	}
}
