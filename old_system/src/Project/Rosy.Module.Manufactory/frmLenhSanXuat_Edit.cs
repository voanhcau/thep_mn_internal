using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;
using System.Collections;
using RosySystem.Customize;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace RosyModule.Manufactory
{
    public partial class frmLenhSanXuat_Edit : RosySystem.Customize.frmEdit
    {
        #region Methods

        public string strStt = string.Empty;
  
        double iNam = 0;
        double iThang = 0;
        double iLan_Tt = 0;
        DataSet dsVoucher;
        BindingSource bdsEditCt_Can = new BindingSource();
        BindingSource bdsEditCt_Luyen = new BindingSource();

        DataTable dtEditCt_Can;
        DataTable dtEditCt_Luyen;
        DataTable dtEditPh;

        DataRow drEditCt_Can;
        DataRow drEditCt_Luyen;
        DataRow drCurrent;
        enuEdit enuNew_Edit;
        string strenu;
        


        public frmLenhSanXuat_Edit()
        {
            InitializeComponent();

            dgvCan.KeyDown += new KeyEventHandler(dgvCan_KeyDown);
            dgvLuyen.KeyDown += new KeyEventHandler(dgvLuyen_KeyDown);

            dgvCan.CellValidating += new DataGridViewCellValidatingEventHandler(dgvCan_CellValidating);
            dgvCan.CellValidated += new DataGridViewCellEventHandler(dgvCan_CellValidated);

            dgvLuyen.CellValidating += new DataGridViewCellValidatingEventHandler(dgvLuyen_CellValidating);

            btImport.Click += new EventHandler(btImport_Click);
            btExit.Click += new EventHandler(btExit_Click);
            btSave.Click += new EventHandler(btSave_Click);
        }


        

        

        #endregion
        public void Load(enuEdit enuNew_Edit, double iNam, double iThang, double iLan_Tt, string strStt, bool bNew)
        {

            this.enuNew_Edit = enuNew_Edit;

            if (enuNew_Edit == enuEdit.New)
                strenu = "N";
            else if (enuNew_Edit == enuEdit.Copy)
                strenu = "C";
            else
                strenu = "E";

            this.iNam = iNam;
            this.iThang = iThang;
            this.iLan_Tt = iLan_Tt;

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                this.strStt = Common.GetNewStt("13", true);
                dteNgay_Ct.Text = Library.DateToStr(DateTime.Now);
                numLan_Tt.Value = iLan_Tt + 1;
            }

            else
            {
                this.strStt = strStt;
                numLan_Tt.Value = iLan_Tt;
            }
            Build();
            FillData();

            //Common.ScaterMemvar(this, ref drEdit);            
            BindingLanguage();



            this.ShowDialog();
        }
        private void Build()
        {
            dgvCan.bSortMode = false;
            dgvCan.strZone = "LENHSXCAN";
            dgvCan.BuildGridView();

            dgvLuyen.bSortMode = false;
            dgvLuyen.strZone = "LENHSXLUYEN";
            dgvLuyen.BuildGridView();

            dgvCan.ReadOnly = false;
            dgvLuyen.ReadOnly = false;
            //this.DataGridView_Language();

            //if (dgvCan.Columns.Contains("MA_VT_SP"))
            //    ((dgvTextBoxColumn)dgvCan.Columns["MA_VT_SP"]).bUseAutoDropDown = true;

            //if (dgvLuyen.Columns.Contains("MA_VT_SP"))
            //    ((dgvTextBoxColumn)dgvLuyen.Columns["MA_VT_SP"]).bUseAutoDropDown = true;
        }

        private void FillData()
        {

            Hashtable ht = new Hashtable();

            ht.Add("NAM", iNam);
            ht.Add("THANG", iThang);
            ht.Add("ENUNEW_EDIT", strenu);
            ht.Add("STT", this.strStt);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetLenhSanXuatCt", ht, CommandType.StoredProcedure);

            dtEditCt_Can = dsVoucher.Tables[0];
            bdsEditCt_Can.DataSource = dtEditCt_Can;
            dgvCan.DataSource = bdsEditCt_Can;

            dtEditCt_Luyen = dsVoucher.Tables[1];
            bdsEditCt_Luyen.DataSource = dtEditCt_Luyen;
            dgvLuyen.DataSource = bdsEditCt_Luyen;

            dtEditPh = dsVoucher.Tables[2];
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                DataRow drEditPh = dtEditPh.NewRow();
                drEditPh["Stt"] = strStt;
                drEditPh["Nam"] = iNam;
                drEditPh["Thang"] = iThang;
                drEditPh["Lan_Tt"] = iLan_Tt + 1;
                dteNgay_Ct.Text = Library.DateToStr(DateTime.Now);
                dtEditPh.Rows.Add(drEditPh);
                drEditPh.AcceptChanges();
            }
            else
            {
                dteNgay_Ct.Text = dtEditPh.Rows[0]["Ngay_Ct"].ToString();
                txtLy_Do.Text = dtEditPh.Rows[0]["Ly_Do"].ToString();
                txtDanh_Gia.Text = dtEditPh.Rows[0]["Danh_Gia"].ToString();
            }

            DataColumn dc = new DataColumn("Deleted", typeof(bool));
            dc.DefaultValue = false;
            dtEditCt_Can.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("Deleted", typeof(bool));
            dc1.DefaultValue = false;
            dtEditCt_Luyen.Columns.Add(dc1);
        }

        public bool FormCheckValid()
        {




            return true;
        }

        public bool Save()
        {
            //Common.GatherMemvar(this, ref drEdit);

            //Kiem tra Valid tren Form
            if (!FormCheckValid())
                return false;





            return true;

        }

  


        void dgvCan_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsEditCt_Can.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (Common.Inlist(strColumnName, "MA_VT_SP,TEN_VT_SP") && drCurrent["Ma_Vt_Sp"].ToString() != string.Empty)
            {
                Hashtable ht = new Hashtable();
                ht.Add("MA_VT_SP", drCurrent["Ma_Vt_Sp"].ToString());
                ht.Add("NGAY_SX", drCurrent["Ngay_Sx"]);
                double dbNang_Suat = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNangSuatLSX (@Ma_Vt_Sp, @Ngay_Sx)", ht, CommandType.Text));
                if (dbNang_Suat != null)
                {
                    drCurrent["Nang_Suat"] = dbNang_Suat;
                    drCurrent["Hieu_Suat"] = numHieu_Suat.Value;
                    drCurrent["So_Luong"] = Math.Round(Convert.ToDouble(drCurrent["Hieu_Suat"]) * Convert.ToDouble(drCurrent["Nang_Suat"]) * (Convert.ToDouble(drCurrent["So_Gio_Sx"]) - Convert.ToDouble(drCurrent["Time_Change"]) / 60), 0);


                    drCurrent.AcceptChanges();
                }
            }
            if (Common.Inlist(strColumnName, "SO_GIO_SX"))
            {
                drCurrent["So_Luong"] = Math.Round(Convert.ToDouble(drCurrent["Hieu_Suat"]) * Convert.ToDouble(drCurrent["Nang_Suat"]) * (Convert.ToDouble(drCurrent["So_Gio_Sx"]) - Convert.ToDouble(drCurrent["Time_Change"]) / 60), 0);
                drCurrent.AcceptChanges();
            }
            if (Common.Inlist(strColumnName, "MA_VT_SP")) //Tính time change SP
            {

                string strMa_Size_Old = string.Empty; string strMa_Size_New = string.Empty;
                if (bdsEditCt_Can.Position > 0)
                {
                    int irow;

                    //if (Convert.ToInt16(drCurrent["Stt0"]) > 2)
                    //    irow = Convert.ToInt16(drCurrent["Stt0"]) - 1;
                    //else
                        irow = Convert.ToInt16(drCurrent["Stt0"]) - 2;

                    DataRow dr_Old = dtEditCt_Can.Rows[irow];
                    strMa_Size_Old = dr_Old["Ma_Size"].ToString();
                    strMa_Size_New = drCurrent["Ma_Size"].ToString();
                    drCurrent["Time_Change"] = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT So_Phut_Change FROM R13TIMECHANGESP WHERE Ma_Size = '" + strMa_Size_Old + "' AND Ma_Size_Change = '" + strMa_Size_New + "'"));
                    drCurrent.AcceptChanges();
                    
                }
            }
        }
        void dgvLuyen_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsEditCt_Luyen.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();


            bool bLookup = true;
            if (strColumnName == "MA_VT_SP")
                bLookup = dgvLookupMa_Vt_Sp_Luyen(ref dgvCell);
        }
        void dgvCan_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataRow drCurrent = ((DataRowView)bdsEditCt_Can.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();


            bool bLookup = true;
            if (strColumnName == "MA_VT_SP")
                bLookup = dgvLookupMa_Vt_Sp(ref dgvCell);

        }
        private bool dgvLookupMa_Vt_Sp(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            drCurrent = ((DataRowView)bdsEditCt_Can.Current).Row;
            if (strValue != "X")
            {
                DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "", "");

                if (bRequire && drLookup == null)
                    return false;

                if (drLookup == null)
                {
                    dgvCell.Value = string.Empty;
                    dgvCell.Tag = string.Empty;
                }
                else
                {
                    dgvEditCt1.CancelEdit();
                    dgvCell.Value = drLookup["Ma_Vt"].ToString();
                    dgvCell.Tag = drLookup["Ten_Vt"].ToString();
                    drCurrent["Ten_Vt_Sp"] = drLookup["Ten_Vt"].ToString();
                    drCurrent["Ma_Size"] = drLookup["Ma_Size"].ToString();
                    drCurrent["Grade_ID"] = drLookup["Grade_ID"].ToString();
                }
            }
            return true;
        }
        private bool dgvLookupMa_Vt_Sp_Luyen(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            drCurrent = ((DataRowView)bdsEditCt_Luyen.Current).Row;

            if (strValue != "X")
            {
                DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "Ma_Nh_Vt = 'PHOI'", "");

                if (bRequire && drLookup == null)
                    return false;

                if (drLookup == null)
                {
                    dgvCell.Value = string.Empty;
                    dgvCell.Tag = string.Empty;
                }
                else
                {
                    dgvEditCt1.CancelEdit();
                    dgvCell.Value = drLookup["Ma_Vt"].ToString();
                    dgvCell.Tag = drLookup["Ten_Vt"].ToString();
                    drCurrent["Ten_Vt_Sp"] = drLookup["Ten_Vt"].ToString();

                }
              
            }
            return true;
        }
        void AddRowCan()
        {
            drCurrent = ((DataRowView)bdsEditCt_Can.Current).Row;
            string strFilter = "Ma_Vt_Sp <> '' AND Ngay_Sx = '" + Convert.ToString(drCurrent["Ngay_Sx"]) + "' AND Ca_Sx = '" + drCurrent["Ca_Sx"] + "'";
            double dbSo_Gio_Sx_Old = Common.SumDCValue(dtEditCt_Can, "So_Gio_Sx", strFilter);//Convert.ToDouble(drCurrent["So_Gio_Sx"]);
            int iStt0 = Convert.ToInt16(drCurrent["Stt0"]);
            DataRow drNew = dtEditCt_Can.NewRow();

            Common.SetDefaultDataRow(ref drNew);
            Common.CopyDataRow(drCurrent, drNew);

            dtEditCt_Can.Rows.InsertAt(drNew, bdsEditCt_Can.Position + 1);
            drNew["So_Gio_Sx"] = 12 - dbSo_Gio_Sx_Old;
            drNew.AcceptChanges();

            // ĐÁNH LẠI STT0
            foreach (DataRow dr in dtEditCt_Can.Select("Stt0 >= " + iStt0 + ""))
            {
                dr["Stt0"] = iStt0;
                iStt0++;
            }

          


            //tạo cuối table
            //dtEditCt.Rows.Add(drNew);
            //Tạo đầu table
            //dtEditCt.Rows.InsertAt(drNew, frmEditCt.bdsEditCt.Position);
            //Tạo giữa table
          

          


        }
        void AddRowLuyen()
        {
            drCurrent = ((DataRowView)bdsEditCt_Luyen.Current).Row;
            string strFilter = "Ma_Vt_Sp <> '' AND Ngay_Sx = '" + Convert.ToString(drCurrent["Ngay_Sx"]) + "' AND Ca_Sx = '" + drCurrent["Ca_Sx"] + "'";
           
            int iStt0 = Convert.ToInt16(drCurrent["Stt0"]);
            DataRow drNew = dtEditCt_Luyen.NewRow();

            Common.SetDefaultDataRow(ref drNew);
            Common.CopyDataRow(drCurrent, drNew);

            dtEditCt_Luyen.Rows.InsertAt(drNew, bdsEditCt_Luyen.Position + 1);
         

            // ĐÁNH LẠI STT0
            foreach (DataRow dr in dtEditCt_Luyen.Select("Stt0 >= " + iStt0 + ""))
            {
                dr["Stt0"] = iStt0;
                iStt0++;
            }




            //tạo cuối table
            //dtEditCt.Rows.Add(drNew);
            //Tạo đầu table
            //dtEditCt.Rows.InsertAt(drNew, frmEditCt.bdsEditCt.Position);
            //Tạo giữa table


        }
        void DeleteRowLuyen()
        {
            drCurrent = ((DataRowView)bdsEditCt_Luyen.Current).Row;
            drCurrent["Deleted"] = !(bool)drCurrent["Deleted"];

            if ((bool)drCurrent["Deleted"] == true)
            {
                Font font = new Font(dgvLuyen.Font.FontFamily, dgvLuyen.Font.Size, FontStyle.Strikeout);
                dgvLuyen.CurrentRow.DefaultCellStyle.Font = font;


              
            }
            else
            {
                dgvLuyen.CurrentRow.DefaultCellStyle.Font = dgvLuyen.Font;
            }

            drCurrent = ((DataRowView)bdsEditCt_Luyen.Current).Row;
            string strFilter = "Ma_Vt_Sp <> '' AND Ngay_Sx = '" + Convert.ToString(drCurrent["Ngay_Sx"]) + "' AND Ca_Sx = '" + drCurrent["Ca_Sx"] + "'";

            int iStt0 = Convert.ToInt16(drCurrent["Stt0"]);

            foreach (DataRow dr in dtEditCt_Luyen.Select("Stt0 >= " + iStt0 + ""))
            {
                dr["Stt0"] = iStt0;
                iStt0++;
            }
        }
        void DeleteRowCan()
        {
            drCurrent = ((DataRowView)bdsEditCt_Can.Current).Row;
            drCurrent["Deleted"] = !(bool)drCurrent["Deleted"];
            int iStt0 = Convert.ToInt16(drCurrent["Stt0"]);

            
            string strFilter = "Ma_Vt_Sp <> '' AND Ngay_Sx = '" + Convert.ToString(drCurrent["Ngay_Sx"]) + "' AND Ca_Sx = '" + drCurrent["Ca_Sx"] + "'";

            if ((bool)drCurrent["Deleted"] == true)
            {
                Font font = new Font(dgvCan.Font.FontFamily, dgvCan.Font.Size, FontStyle.Strikeout);
                dgvCan.CurrentRow.DefaultCellStyle.Font = font;
             
                foreach (DataRow dr in dtEditCt_Can.Select("Stt0 >= " + iStt0  + " + 1"))
                {
                    dr["Stt0"] = iStt0;
                    iStt0++;
                }
            }
            else
            {
                dgvCan.CurrentRow.DefaultCellStyle.Font = dgvCan.Font;

                foreach (DataRow dr in dtEditCt_Can.Select("Stt0 >= " + iStt0 + ""))
                {
                    dr["Stt0"] = iStt0;
                    iStt0++;
                }
            }

          

           
           
        }
        void Copy_Can()
        {
            drCurrent = ((DataRowView)bdsEditCt_Can.Current).Row;
            int irow = Convert.ToInt16(drCurrent["Stt0"]) - 2;
            
            if(irow > -1)
            {
                DataRow dr_Old = dtEditCt_Can.Rows[irow];
                drCurrent["Ma_Vt_Sp"] = dr_Old["Ma_Vt_Sp"].ToString();
                drCurrent["Ten_Vt_Sp"] = dr_Old["Ten_Vt_Sp"].ToString();
                drCurrent.AcceptChanges();
            }
        }
         void Copy_Luyen()
        {
            drCurrent = ((DataRowView)bdsEditCt_Luyen.Current).Row;
            int irow = Convert.ToInt16(drCurrent["Stt0"]) - 2;
            
            if(irow > -1)
            {
                DataRow dr_Old = dtEditCt_Luyen.Rows[irow];
                drCurrent["Ma_Vt_Sp"] = dr_Old["Ma_Vt_Sp"].ToString();
                drCurrent["Ten_Vt_Sp"] = dr_Old["Ten_Vt_Sp"].ToString();
                drCurrent["So_Luong"] = dr_Old["So_Luong"];

                drCurrent.AcceptChanges();
            }
        }
         private void Import()
         {
             frmReadExcel_ToFrom frm = new frmReadExcel_ToFrom();
             frm.Load("LSXCAN");
             if (frm.isAccept)
             {
                 frm.Close();

                 SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
                 SqlCommand sqlCom = sqlCon.CreateCommand();


                 sqlCom.CommandText = "sp_Update_Ct";
                 sqlCom.CommandType = CommandType.StoredProcedure;

                 sqlCom.Parameters.Clear();
                 sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)enuNew_Edit);
                 sqlCom.Parameters.AddWithValue("@Stt", strStt);
                 sqlCom.Parameters.AddWithValue("@Hieu_Suat", numHieu_Suat.Value);
                 sqlCom.Parameters.AddWithValue("@Ngay_Ct", Library.StrToDate(dteNgay_Ct.Text));
                 sqlCom.Parameters.AddWithValue("@Ly_Do", txtLy_Do.Text);
                 sqlCom.Parameters.AddWithValue("@Danh_Gia", txtDanh_Gia.Text);
                 sqlCom.Parameters.AddWithValue("@Lan_Tt", numLan_Tt.Value);
                 sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
                 sqlCom.Parameters.AddWithValue("@Create_Log", Common.GetCurrent_Log());
                 sqlCom.Parameters.AddWithValue("@LastModify_Log", Common.GetCurrent_Log());
                 //Tạo Table cho TVP_PH
                 SqlParameter paraPH = new SqlParameter();
                 paraPH.SqlDbType = SqlDbType.Structured;
                 paraPH.ParameterName = "@CAN";

                 sqlCom.CommandText = "sp_ImportExcelLSX";

                 //TVP_PH
                 paraPH.TypeName = "TVP_Can";
                 paraPH.Value = Voucher.GetTVPValue("R13CT_LSX", "TVP_Can", frm.dtImport);
                 sqlCom.Parameters.Add(paraPH);

                 try
                 {
                     sqlCom.ExecuteNonQuery();
                     this.Close();
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
         }
         bool Save_Can()
        {          
            DataTable dt_Can = dtEditCt_Can.Copy();
            dtEditCt_Can.Clear();
            foreach (DataRow dr in dt_Can.Select("Deleted = 0"))
            {
                DataRow drEditCtNew = dtEditCt_Can.NewRow();
                Common.CopyDataRow(dr, drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);

                dtEditCt_Can.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();
            }

            
            foreach (DataRow dr in dtEditCt_Luyen.Select("Deleted = 0"))
            {

                DataRow drEditCtNew = dtEditCt_Can.NewRow();
                Common.CopyDataRow(dr, drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);

                dtEditCt_Can.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();
            }

            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

          
            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.AddWithValue("@strNew_Edit", (char)enuNew_Edit);
            sqlCom.Parameters.AddWithValue("@Stt", strStt);
            sqlCom.Parameters.AddWithValue("@Ngay_Ct", Library.StrToDate(dteNgay_Ct.Text));
            sqlCom.Parameters.AddWithValue("@Ly_Do", txtLy_Do.Text);
            sqlCom.Parameters.AddWithValue("@Danh_Gia", txtDanh_Gia.Text);
            sqlCom.Parameters.AddWithValue("@Lan_Tt", numLan_Tt.Value);
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);
            sqlCom.Parameters.AddWithValue("@Create_Log", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@LastModify_Log", Common.GetCurrent_Log());
            //Tạo Table cho TVP_PH
            SqlParameter paraPH = new SqlParameter();
            paraPH.SqlDbType = SqlDbType.Structured;
            paraPH.ParameterName = "@PH";

            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@Ct";


            sqlCom.CommandText = "sp_Update_LenhSXCAN";

            //TVP_PH
            paraPH.TypeName = "TVP_PHCan";
            paraPH.Value = Voucher.GetTVPValue("R80PH_LSX", "TVP_PHCan", dtEditPh);
            sqlCom.Parameters.Add(paraPH);

            //Tạo Table cho TVP_CtTien
            paraCt.TypeName = "TVP_CtCan";
            paraCt.Value = Voucher.GetTVPValue("R13CT_LSX", "TVP_CTCan", dtEditCt_Can);
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
                return false;
            }
            return true;

        }
        void btSave_Click(object sender, EventArgs e)
        {
            if (Save_Can())
                Common.MsgOk("Bạn đã lưu thành công!!!");
            
            //this.Close();
        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btImport_Click(object sender, EventArgs e)
        {
           Import();
        }  

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);



        }

        void dgvLuyen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    this.AddRowLuyen();
                    break;

                case Keys.F8:
                    DeleteRowLuyen();
                    break;

                case Keys.V:
                    {
                        switch (e.Modifiers)
                        {
                            case Keys.Control:
                                Copy_Luyen();
                                break;


                        }
                        break;
                    }
            }
        }
        

        void dgvCan_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F6:
                    this.AddRowCan();
                    break;

                case Keys.F8:
                    DeleteRowCan();
                    break;

                case Keys.V:
                    {
                        switch (e.Modifiers)
                        {
                            case Keys.Control:
                                Copy_Can();
                                break;


                        }
                        break;
                    }
            }
        }

        //private void btSave_Click_1(object sender, EventArgs e)
        //{

        //}
    }
            
}
