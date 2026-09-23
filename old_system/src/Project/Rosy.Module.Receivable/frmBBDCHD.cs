using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Element;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Data;
using Rosy.Module;
using System.Data.SqlClient;
using System.Collections;

namespace RosyModule.Receivable
{
	public partial class frmBBDCHD : frmView
	{
		#region Khai bao bien

        DataTable dtBBDCHD_Ph;
		DataTable dtBBDCHD;

		BindingSource bdsBBDCHD_Ph = new BindingSource();
        BindingSource bdsBBDCHD = new BindingSource();
		private DataRow drCurrent;
        string strStt = string.Empty;
        private string strReportFile;
		
        #endregion

		#region Contructor

        public frmBBDCHD()
		{
			InitializeComponent();

            this.btNew.Click += new EventHandler(btNew_Click);
            this.btEdit.Click += new EventHandler(btEdit_Click);
            this.btSave.Click += new EventHandler(btSave_Click);
			this.btPrint.Click += new EventHandler(btExit_Click);

            this.btFirst.Click += new EventHandler(btFirst_Click);
            this.btNext.Click += new EventHandler(btNext_Click);
            this.btPrevious.Click += new EventHandler(btPrevious_Click);
            this.btLast.Click += new EventHandler(btLast_Click);
		}

       

       

		public override void Load()
		{
            

			this.Build();
            this.FillData_Ph();
			this.FillData();

			this.BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvDmDt.strZone = "BBDCHD";
			dgvDmDt.BuildGridView();

			
		}

		private void FillData()
		{
           

            string strSQL_Ct = "SELECT T1.*, Ten_Vt, Dvt FROM R04BBDCHD T1 JOIN (SELECT Ma_Vt, Ten_Vt, Dvt FROM R81DMVT) T2 ON T1.Ma_Vt = T2.Ma_Vt ORDER BY Ngay_Ct ";
            dtBBDCHD = SQLExec.ExecuteReturnDt(strSQL_Ct);
			bdsBBDCHD.DataSource = dtBBDCHD;
			dgvDmDt.DataSource = bdsBBDCHD;

            
			ExportControl = dgvDmDt;
			this.bdsSearch = bdsBBDCHD;
		}
        private void FillData_Ph()
        {
            string strSQL_Ph = "SELECT Stt, So_Ct_BB, Ngay_Ct_BB, Ma_Dt FROM R04BBDCHD GROUP BY Stt, So_Ct_BB, Ngay_Ct_BB, Ma_Dt";
            dtBBDCHD_Ph = SQLExec.ExecuteReturnDt(strSQL_Ph);
            bdsBBDCHD_Ph.DataSource = dtBBDCHD_Ph;
            
            if (dtBBDCHD_Ph.Rows.Count > 0)
            {
                drCurrent = ((DataRowView)bdsBBDCHD_Ph.Current).Row;

                this.dteNgay_Ct_Bb.Text = Library.DateToStr(Convert.ToDateTime(drCurrent["Ngay_Ct_Bb"]));
                txtSo_Ct_Bb.Text = (string)drCurrent["So_Ct_Bb"];
                txtMa_Dt.Text = (string)drCurrent["Ma_Dt"];
                if (txtMa_Dt.Text.Trim() != string.Empty)
                {
                    DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt.Text.Trim());
                    this.lbtTen_Dt.Text = (string)drDmDt["Ten_Dt"];
                }

                this.lbtRecorde.Text = this.bdsBBDCHD_Ph.Position + 1 + "/" + this.bdsBBDCHD_Ph.Count;
            }
            //this.bdsBBDCHD.Position = this.bdsBBDCHD_Ph.Find("STT", strStt);
           
        }
		#endregion

		#region Edit
        
        private void New()
        {
            frmBBDCHD_Filter frm = new frmBBDCHD_Filter();
            frm.Load();
            
            SetData(frm);
        }

		public void Filter()
		{
			string strKey = "(1 = 1) ";

			this.bdsBBDCHD.Filter = strKey;
		}

	

		#endregion

        private void SetData(frmBBDCHD_Filter frm)
        {
            if (frm.dtBBDCHD.Select("Chon = true").Length == 0)
                return;
            
            foreach (DataRow drSelect in frm.dtBBDCHD.Select("Chon = true"))
            {
                DataRow drEditCtNew = dtBBDCHD.NewRow();
                Common.CopyDataRow(drSelect, drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);

                txtMa_Dt.Text = drSelect["Ma_Dt"].ToString();

                drEditCtNew["Stt_Org"] = drSelect["Stt"];

                dtBBDCHD.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();
            }

        }

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
        void btEdit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        
        void btSave_Click(object sender, EventArgs e)
        {
            Save();
        }
      
        void btNew_Click(object sender, EventArgs e)
        {
            dteNgay_Ct_Bb.Text = Library.DateToStr(Element.sysNgay_Ct2);
            frmBBDCHD_Filter frm = new frmBBDCHD_Filter();
            frm.Load();

            SetData(frm);
        }

        private void Save()
        {
        
            strStt = Common.GetNewStt("04", true);
            while (DataTool.SQLCheckExist("R04BBDCHD", "Stt", strStt))
            {
                strStt = Common.GetNewStt("04", true);
            }
            foreach (DataRow drEdit in dtBBDCHD.Rows)
            {
                //Kiem tra cac du lieu can thiet
                drEdit["Ma_Data"] = Element.sysMa_DvCs;
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["Stt"] = strStt;
                drEdit["So_Ct_BB"] = txtSo_Ct_Bb.Text;
                drEdit["Ngay_Ct_BB"] = Library.StrToDate(dteNgay_Ct_Bb.Text);

            }
            //Luu xuong CSDL
            SqlCommand sQLCommand = SQLExec.GetSQLCommand();
            sQLCommand.CommandType = CommandType.StoredProcedure;
            sQLCommand.Parameters.Clear();
            sQLCommand.CommandText = "Sp_Import_BBDCHD";
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "@TVP_Import",
                SqlDbType = SqlDbType.Structured,
                TypeName = "TVP_BBDCHD",
                Value = Voucher.GetTVPValue("R04BBDCHD", "TVP_BBDCHD", this.dtBBDCHD)
            };
            sQLCommand.Parameters.Add(parameter);
            try
            {
                sQLCommand.ExecuteNonQuery();
                RosySystem.Common.Common.MsgOk((RosySystem.Element.Element.sysLanguage == enuLanguageType.English) ? "Import success !" : "Lưu thành công !");
            }
            catch (Exception exception)
            {
                RosySystem.Common.Common.MsgOk(exception.Message);
            }
        }

        void btPrevious_Click(object sender, EventArgs e)
        {
            if (bdsBBDCHD_Ph.Position < 0)
                return;

            this.bdsBBDCHD_Ph.MovePrevious();
            this.strStt = (string)((DataRowView)bdsBBDCHD_Ph.Current).Row["Stt"];

            
        }

        void btLast_Click(object sender, EventArgs e)
        {
            if (bdsBBDCHD_Ph.Position < 0)
                return;

            this.bdsBBDCHD_Ph.MoveLast();
            this.strStt = (string)((DataRowView)bdsBBDCHD_Ph.Current).Row["Stt"];

          
        }

        void btNext_Click(object sender, EventArgs e)
        {
            if (bdsBBDCHD_Ph.Position < 0)
                return;

            if (this.bdsBBDCHD_Ph.Position + 1 < this.bdsBBDCHD_Ph.Count)
            {
                this.bdsBBDCHD_Ph.MoveNext();
                this.strStt = (string)((DataRowView)bdsBBDCHD_Ph.Current).Row["Stt"];

               
            }
        }

        void btFirst_Click(object sender, EventArgs e)
        {
            if (bdsBBDCHD_Ph.Position < 0)
                return;

            this.bdsBBDCHD_Ph.MoveFirst();

            this.strStt = (string)((DataRowView)bdsBBDCHD_Ph.Current).Row["Stt"];

           
        }

        #region Print
        private bool Print(bool bPreview)
        {
            drCurrent = ((DataRowView)bdsBBDCHD_Ph.Current).Row;

            DataTable dtDetail = new DataTable();
            dtDetail = DataTool.SQLGetDataTable("R04CTDNTU", string.Empty, "Stt = '" + drCurrent["Stt"].ToString() + "'", "");

            Hashtable ht = new Hashtable();
            ht.Add("STT", drCurrent["Stt"].ToString());

            DataTable dtPrintWorkerList = new DataTable();
            dtPrintWorkerList = SQLExec.ExecuteReturnDt("Sp_PrintDnTu", ht, CommandType.StoredProcedure);

            if (dtPrintWorkerList.Rows.Count == 0)
                return false;

            if (!dtPrintWorkerList.Columns.Contains("REPORT_FILE"))
                dtPrintWorkerList.Columns.Add("REPORT_FILE", typeof(string));

            if (!dtPrintWorkerList.Columns.Contains("NGAY_CT"))
                dtPrintWorkerList.Columns.Add("NGAY_CT", typeof(DateTime));

            if (!dtPrintWorkerList.Columns.Contains("DOC_TIEN"))
                dtPrintWorkerList.Columns.Add("DOC_TIEN", typeof(string));

            dtPrintWorkerList.Rows[0]["REPORT_FILE"] = strReportFile;
            dtPrintWorkerList.Rows[0]["NGAY_CT"] = Element.sysNgay_Ct2;

            dtPrintWorkerList.Rows[0]["Doc_Tien"] = Common.ReadMoney(Convert.ToDouble(dtPrintWorkerList.Rows[0]["Tien"]), dtPrintWorkerList.Rows[0]["Ma_TTe"].ToString());

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(dtPrintWorkerList.Rows[0], dtDetail, bPreview);
        }

        private void Design()
        {
            RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
            frm.Load(strReportFile);
        }
        #endregion
	}
}
