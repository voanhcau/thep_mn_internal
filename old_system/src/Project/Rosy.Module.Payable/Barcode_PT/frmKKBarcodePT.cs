using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Library;
using RosyList;
using RosySystem.Customize;
using RosySystem;
using RosySystem.Common;
using RosySystem.Public;
using System.Collections;
using RosySystem.Element;
using RosySystem.Control;
using System.Data.SqlClient;


namespace RosyModule.Payable
{
	public partial class frmKKBarcodePT : RosySystem.Customize.frmView
	{

        //private rptFileReport repFile = new rptFileReport();
		private DataSet dsBarcodeKK;
        DataTable dtBarcodePT;
        DataTable dtBarcodeDC;

        
		private BindingSource bdsBarcodePT = new BindingSource();
        private BindingSource bdsBarcodeDC = new BindingSource();	
		private DataRow drCurrent;
        
		#region Phuong thuc

        public frmKKBarcodePT()
		{
			InitializeComponent();

            btDieu_Chinh.Click += new EventHandler(btDieu_Chinh_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
            btExit.Click += new EventHandler(btExit_Click);
		}

		private void Build()
		{
            
            dgvBarcodePT.strZone = "KIEMKEBARCODEPT";
            dgvBarcodeDC.strZone = "KIEMKEBARCODEPT";
            

            dgvBarcodePT.BuildGridView(false);
            dgvBarcodeDC.BuildGridView(false);

           
		}

		private void FillData()
		{
            Hashtable htPara = new Hashtable();

            htPara.Add("NGAY_KK", dteNgay_Ct.Text);
            htPara.Add("IS_KK", chkIs_KK.Checked);
            htPara.Add("IS_DC", chkIs_DC.Checked);
            dsBarcodeKK = SQLExec.ExecuteReturnDs("sp_DieuChinhBarcodePT", htPara, CommandType.StoredProcedure);

            dtBarcodePT = dsBarcodeKK.Tables[0];
            bdsBarcodePT.DataSource = dtBarcodePT;
            dgvBarcodePT.DataSource = bdsBarcodePT;

            dtBarcodeDC = dsBarcodeKK.Tables[1];
            bdsBarcodeDC.DataSource = dtBarcodeDC;
            dgvBarcodeDC.DataSource = bdsBarcodeDC;

            bdsSearch = bdsBarcodePT;
            ExportControl = dtBarcodePT;
		}

		new public void Load()
		{
            dteNgay_Ct.Text = Library.DateToStr(DateTime.Now); 
			Build();
			FillData();

           
			BindingLanguage();

			this.Show();
		}

		

		private bool FormCheckValid()
		{
			bool bvalid = true;

			

			return bvalid;
		}
       
        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
		#endregion

		#region Su kien
       

        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }
        void btDieu_Chinh_Click(object sender, EventArgs e)
        {
            string strSQL = string.Empty;
            int iCount = 0;
            string strMa_Vt_List = string.Empty;
            foreach (DataRow dr in dtBarcodePT.Rows)
            {
                if (Convert.ToDouble(dr["So_Luong_DC"]) != 0)
                {
                    iCount++;
                    strMa_Vt_List = strMa_Vt_List + "," + dr["Barcode"].ToString();
                }

                //Hashtable ht = new Hashtable();
                //ht.Add("SL_DC_KK", Convert.ToDouble(dr["So_Luong_DC"]));
                //ht.Add("USER_DCKK", Common.GetCurrent_Log());
                //ht.Add("NGAY_DC_KK", dteNgay_Ct.Text);
                //ht.Add("BARCODE", dr["Barcode"]);
                //strSQL = "UPDATE R81DMBARCODEPT SET SL_DC_KK = @SL_DC_KK, User_DCKK = @USER_DCKK, Ngay_DC_KK = @Ngay_DC_KK  WHERE Barcode = @Barcode";
                //SQLExec.Execute(strSQL, ht, CommandType.Text);

                
                
            }
            //
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.Parameters.AddWithValue("@USER_DCKK", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@NGAY_DC_KK", Library.StrToDate(dteNgay_Ct.Text));
            sqlCom.Parameters.AddWithValue("@DC_KK", true);
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_KKBarcodePT";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_KKBarcodePT";
            paraCt.Value = Voucher.GetTVPValue("R05KIEMKE", "TVP_KKBarcodePT", this.dtBarcodePT);
            sqlCom.Parameters.Add(paraCt);

            try
            {
                sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                sqlCom.CommandType = CommandType.Text;
                sqlCom.Parameters.Clear();
                sqlCom.ExecuteNonQuery();

                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);
                
            }
            //
            foreach (DataRow dr in dtBarcodeDC.Rows)
            {
                iCount++;
                strMa_Vt_List = strMa_Vt_List + "," + dr["Barcode"].ToString();

                //Hashtable ht = new Hashtable();
                //ht.Add("SL_DC_KK", Convert.ToDouble(dr["So_Luong_DC"]));
                //ht.Add("USER_DCKK", Common.GetCurrent_Log());
                //ht.Add("NGAY_DC_KK", dteNgay_Ct.Text);
                //ht.Add("BARCODE", dr["Barcode"]);
                //strSQL = "UPDATE R81DMBARCODEPT SET SL_DC_KK = @SL_DC_KK, User_DCKK = @USER_DCKK, Ngay_DC_KK = @Ngay_DC_KK  WHERE Barcode = @Barcode";
                //SQLExec.Execute(strSQL, ht, CommandType.Text);

            }
            SqlConnection sqlConDC = SQLExec.GetNewSQLConnection();
            SqlCommand sqlComDC = sqlConDC.CreateCommand();

            sqlComDC.CommandText = "sp_Update_Ct";
            sqlComDC.CommandType = CommandType.StoredProcedure;

            sqlComDC.Parameters.Clear();

            sqlComDC.Parameters.AddWithValue("@USER_DCKK", Common.GetCurrent_Log());
            sqlComDC.Parameters.AddWithValue("@NGAY_DC_KK", Library.StrToDate(dteNgay_Ct.Text));
            sqlComDC.Parameters.AddWithValue("@DC_KK", false);
            sqlComDC.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            SqlParameter paraCtDC = new SqlParameter();
            paraCtDC.SqlDbType = SqlDbType.Structured;
            paraCtDC.ParameterName = "@TVP_Import";

            sqlComDC.CommandText = "sp_Update_KKBarcodePT";
            //TVP_CT
            paraCtDC.TypeName = "TVP_KKBarcodePT";
            paraCtDC.Value = Voucher.GetTVPValue("R05KIEMKE", "TVP_KKBarcodePT", this.dtBarcodeDC);
            sqlComDC.Parameters.Add(paraCtDC);

            try
            {
                sqlComDC.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                sqlComDC.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                sqlComDC.CommandType = CommandType.Text;
                sqlComDC.Parameters.Clear();
                sqlComDC.ExecuteNonQuery();

                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);

            }
            Common.MsgOk("Đã điều chỉnh "+ iCount +" barcode đã kiểm kê các mã sau: " + strMa_Vt_List);
        }
		

		#endregion

      

      
        
	}
}