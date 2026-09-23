using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Library;
using RosySystem.Element;
using RosyList;
using System.Data.SqlClient;


namespace RosyModule.HRM
{
	public partial class frmThongTinCan : RosySystem.Customize.frmView
	{
		#region Khai bao bien

        string strReportFile = "rptThongTinCan";
		DataTable dtThongTinCan;
		

		BindingSource bdsThongTinCan = new BindingSource();

       
		private DataRow drCurrent;
        private rsDataGridView dgvThongTinCan = new rsDataGridView();
		#endregion

		#region Contructor

        public frmThongTinCan()
		{
			InitializeComponent();

            btNew.Click+=new EventHandler(btNew_Click);
			btEdit.Click+=new EventHandler(btEdit_Click);
			btDelete.Click+=new EventHandler(btDelete_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
            btImport.Click += new EventHandler(btImport_Click);
            this.KeyDown += new KeyEventHandler(KeyDownEvent);
          
		}

       

       

       
		public override void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();

		
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			
			dgvThongTinCan.strZone = "THONGTINCAN";
			dgvThongTinCan.Dock = DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Add(dgvThongTinCan);
            this.dgvThongTinCan.BuildGridView();			
		}

		private void FillData()
		{
            Hashtable ht = new Hashtable();
            ht.Add("NAM", Element.sysWorkingYear);
            dtThongTinCan = SQLExec.ExecuteReturnDt("Sp_GetThongTinCan",ht,CommandType.StoredProcedure);

			bdsThongTinCan.DataSource = dtThongTinCan;
			dgvThongTinCan.DataSource = bdsThongTinCan;
            bdsThongTinCan.Position = dtThongTinCan.Rows.Count;

					

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsThongTinCan;
			ExportControl = dgvThongTinCan;

            bdsThongTinCan.Position = 0;
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
            if (bdsThongTinCan.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsThongTinCan.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsThongTinCan.Current).Row, ref drCurrent);
            else
                drCurrent = dtThongTinCan.NewRow();

            frmThongTinCan_Edit frmEdit = new frmThongTinCan_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, "");

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                drCurrent["Ten_Dt"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", drCurrent["Ma_Dt"].ToString());
                drCurrent["Ten_Vt_Sp"] = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", drCurrent["Ma_Vt_Sp"].ToString());

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsThongTinCan.Position >= 0)
                        dtThongTinCan.ImportRow(drCurrent);
                    else
                        dtThongTinCan.Rows.Add(drCurrent);

                   
                    bdsThongTinCan.Position = bdsThongTinCan.Find("Stt", drCurrent["Stt"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsThongTinCan.Current).Row);

                dtThongTinCan.AcceptChanges();
            }
		}

		public override void Delete()
		{
            if (bdsThongTinCan.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsThongTinCan.Current).Row;


            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09CANHANG", drCurrent))
            {
                bdsThongTinCan.RemoveAt(bdsThongTinCan.Position);
                dtThongTinCan.AcceptChanges();
            }
		}
       
		#endregion
        #region Import
        private void Import()
        {
            frmReadExcel_ToFrom frmImport = new frmReadExcel_ToFrom();
            frmImport.Load("THONGTINCAN");

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                bool bCheck = true;
                //check thông tin import xà lan
                foreach(DataRow dr in frmImport.dtImport.Rows)
                {
                    if(bCheck && dr["So_Xa_Lan_Tau"].ToString() != "" && (dr["Ten_Lx_Xalan"].ToString() == "" || dr["ID_Lx_Xalan"].ToString() == "" || dr["So_Phone_Lx_Xalan"].ToString() == ""))
                    { 
                        bCheck = false; 
                        Common.MsgOk("Thông tin tài công chưa hợp lệ, yêu cầu nhập đầy đủ thông tin tên tài công, CCCD, Số điện thoại. Dữ liệu chưa được import."); 
                    }
                    else if (bCheck && dr["So_Xe"].ToString() != "" && dr["So_Xa_Lan_Tau"].ToString() == "")       
                    {
                        if (dr["Ten_Lx_Khach"].ToString() == "" || dr["ID_BL"].ToString() == "" || dr["ID_CMND"].ToString() == "" || dr["So_Phone"].ToString() == "")
                        {
                            bCheck = false;
                            Common.MsgOk("Thông tin tài xế chưa hợp lệ, yêu cầu nhập đầy đủ thông tin tên tài xế, CCCD, Số điện thoại. Dữ liệu chưa được import.");
                        }
                        else if (dr["ID_BL"].ToString().Length != 12)
                        {
                            bCheck = false;
                            Common.MsgOk("Thông tin bằng lái phải 12 ký tự mới cho phép lưu");
                        }
                        else if (dr["ID_CMND"].ToString().Length != 12)
                        {
                            bCheck = false;
                            Common.MsgOk("Thông tin CCCD phải 12 ký tự mới cho phép lưu");
                        }
                        else if (dr["So_Phone"].ToString().Length != 10)
                        {
                            bCheck = false;
                            Common.MsgOk("Thông tin số phone phải 10 ký tự mới cho phép lưu");
                        }
                    }
                }
                
                if(bCheck)
                    UpdateThongTinCan(frmImport.dtImport);
            }
        }
        void UpdateThongTinCan(DataTable dtImport)
        {
            
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.Parameters.AddWithValue("@MEMBER_ID", Element.sysUser_Id);
            sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_CanHang";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_CANHANG";
            paraCt.Value = Voucher.GetTVPValue("R09CANHANG", "TVP_CANHANG", dtImport);
            sqlCom.Parameters.Add(paraCt);

            try
            {
                sqlCom.ExecuteNonQuery();

                FillData();
            }
            catch (Exception ex)
            {
                sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                sqlCom.CommandType = CommandType.Text;
                sqlCom.Parameters.Clear();
                sqlCom.ExecuteNonQuery();

                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);

            }
        }
        #endregion
        #region Print

        private void Print(string strStt)
        {
            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);


            DataTable dtCan = SQLExec.ExecuteReturnDt("sp_PrintThongTinCan", ht, CommandType.StoredProcedure);

            dtCan.Columns.Add("REPORT_FILE", typeof(string));
            //dtCan.Columns.Add("NGAY_CT", typeof(DateTime));

            dtCan.Rows[0]["Report_File"] = strReportFile;
            //dtCan.Rows[0]["Ngay_Ct"] = DateTime.Now;

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            frmPrint.Load(dtCan.Rows[0], dtCan, true, true);
        }
        private void Design()
        {
            RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
            frm.Load(strReportFile);
        }
		#endregion

		#region Su kien
        
        void btDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.Edit);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.New);
        }

        void btPrint_Click(object sender, EventArgs e)
        {
           drCurrent = ((DataRowView)bdsThongTinCan.Current).Row;
           Print(drCurrent["Stt"].ToString());
        }
        void btImport_Click(object sender, EventArgs e)
        {
            Import();
        }
		#endregion

        void KeyDownEvent(object sender, KeyEventArgs e)
        {           
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Control:
                            {
                                drCurrent = ((DataRowView)bdsThongTinCan.Current).Row;
                                Voucher.Print_DnTu(drCurrent["Stt"].ToString(), true, strReportFile);
                            }
                            break;
                        case Keys.Shift:
                            this.Design();
                            break;
                    }
                    break;
                case Keys.F2:
                    {
                        this.Edit(enuEdit.New);
                    }
                    break;
                case Keys.F3:
                    {
                        this.Edit(enuEdit.Edit);
                    }
                    break;
                case Keys.F8:
                    {
                        this.Delete();
                    }
                    break;
            }
            
        }
	}
}
