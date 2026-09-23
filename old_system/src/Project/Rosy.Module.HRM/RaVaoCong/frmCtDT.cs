using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;
using System.Collections;
using System.Data.SqlClient;


namespace RosyModule.HRM
{
	public partial class frmCtDT : RosySystem.Customize.frmView
	{
		#region Declare
        //private rsDataGridView dgvPhanHoiKHVT= new rsDataGridView();

		public DataTable dtEditCt;
		public DataTable dtEditPh;
		public DataTable dtPhanHoiKTCDAT;

		BindingSource bdsPhanHoiKTCDAT = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
		BindingSource bdsEditPh = new BindingSource();
		
        //DataRow drDuyet;
        DataRow drCurrent;
		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
        string strSo_Ct = string.Empty;
        bool bRa = false;
        DateTime dtNgay;
		public bool Is_Accept = false;
		#endregion

		#region Contructor

        public frmCtDT()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            
			
		}

      

		#endregion

		#region Method

        public void Load(string strStt, string strSo_Ct, bool bRa, DateTime dtNgay)
		{
          
            this.strStt = strStt;
            this.strSo_Ct = strSo_Ct;
            this.bRa = bRa;
            this.dtNgay = dtNgay;

			Build();
			FillData();
			BindingLanguage();

			this.LoadDicName();
			this.ShowDialog();
		}

		void LoadDicName()
		{
			
		}

		void Build()
		{
			dgvPhanHoiKHVT.strZone = "VAORACONGDT";
          
            

			dgvPhanHoiKHVT.BuildGridView();
			

         
            

			foreach (DataGridViewColumn dgvc in dgvPhanHoiKHVT.Columns)
				dgvc.ReadOnly = true;

            if (dgvPhanHoiKHVT.Columns.Contains("TEN_VT"))
            {
                dgvPhanHoiKHVT.Columns["TEN_VT"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvPhanHoiKHVT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvPhanHoiKHVT.Columns.Contains("SO_LUONG_GIAO_TT"))
                dgvPhanHoiKHVT.Columns["SO_LUONG_GIAO_TT"].ReadOnly = false;

            
               

		}

		void FillData()
		{
			
			Hashtable htPara = new Hashtable();
            htPara.Add("RA", false);
            htPara.Add("SO_CT", strSo_Ct);
			htPara.Add("MA_CT", "DT");
            htPara.Add("IS_NOTBDKT", false);

            DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetGiayRVCBVe", htPara, CommandType.StoredProcedure);

          
			dtEditCt = dsVoucher.Tables[0];

            //bdsEditPh.DataSource = dtEditPh;

			bdsEditCt.DataSource = dtEditCt;
			dgvPhanHoiKHVT.DataSource = bdsEditCt;

         
			
		}

		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		#region Event
    
        #endregion

        #region Update
      

		bool Update_Ct()
		{
            string strSQLCt = string.Empty;
            if (!bRa)
            {
                foreach (DataRow drCt in dtEditCt.Select("So_Luong_Giao_Tt <> 0"))
                {

                    Hashtable htIns = new Hashtable();
                    htIns.Add("SO_LUONG_GIAO_TT", drCt["So_Luong_Giao_TT"]);
                    htIns.Add("STT", drCt["Stt"]);
                    htIns.Add("STT0", drCt["Stt0"]);
                    htIns.Add("NGAY_VAO", dtNgay);

                    htIns.Add("NOTE", drCt["Note"]);

                    htIns.Add("USER_VAO", Common.GetCurrent_Log());


                    strSQLCt = "INSERT INTO R06CT_GRVC(Stt, Stt0, Ngay_Vao, User_Vao,So_Luong_Giao_TT, Note) " +
                        " VALUES (@Stt, @Stt0, @Ngay_Vao, @User_Vao, @So_Luong_Giao_TT, @Note)";

                    SQLExec.Execute(strSQLCt, htIns, CommandType.Text);


                }
            }
            else
            {
                foreach (DataRow drCt in dtEditCt.Select("So_Luong_Giao_Tt <> 0"))
                {
                    Hashtable htOut = new Hashtable();
                    htOut.Add("SO_LUONG_GIAO_TT", drCt["So_Luong_Giao_TT"]);
                    htOut.Add("STT", drCt["Stt"]);
                    htOut.Add("STT0", drCt["Stt0"]);
                    htOut.Add("NGAY_RA", dtNgay);

                    htOut.Add("NOTE", drCt["Note"]);

                    htOut.Add("USER_RA", Common.GetCurrent_Log());


                    strSQLCt = "UPDATE R06CT_GRVC SET User_Ra = @User_Ra, Ngay_Ra = @Ngay_Ra, So_Luong_Giao_TT_Ra = @So_Luong_Giao_TT, Note = @Note WHERE Stt = @Stt AND Stt0 = @Stt0";

                    SQLExec.Execute(strSQLCt, htOut, CommandType.Text);
                }
            }
			return true;
		}

		bool Save()
		{
            
			Update_Ct();
			return true;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.Is_Accept = true;
				this.Close();
			}
		}

		

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
        }

        #endregion

    }

}