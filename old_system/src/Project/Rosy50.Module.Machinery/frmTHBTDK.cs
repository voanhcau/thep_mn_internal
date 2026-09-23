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
using System.Reflection;
using RosySystem.Customize;

namespace RosyModule.Machinery
{
	public partial class frmTHBTDK : RosySystem.Customize.frmView
	{
		DataTable dtKHBTDK;
        DataTable dtSo_Ct;
		BindingSource bdsKHBTDK = new BindingSource();
		DataRow drCurrent;
        DataRow drKHBTDKT;
        string strFilterTb = string.Empty;
        bool bUpdateKQ = false;
        string strReportFile = "rptTHBTTB";
        string strNgay_List = "";
        public frmTHBTDK()
		{
			InitializeComponent();
		
			this.btExit.Click += new EventHandler(btExit_Click);
            this.btSave.Click += new EventHandler(btSave_Click);
            //this.btPrint.Click += new EventHandler(btPrint_Click);
            cboDot_BT.SelectedValueChanged += new EventHandler(cboSo_Ct_SelectedValueChanged);

            txtMa_Nh_Tb.Validating += new CancelEventHandler(txtMa_Nh_Tb_Validating);
            txtMa_Tb.Validating += new CancelEventHandler(txtMa_Tb_Validating);
            txtPhan_Loai_Cv.Validating += new CancelEventHandler(txtPhan_Loai_CV_Validating);

            dgvKHBTDK.CellValidating += new DataGridViewCellValidatingEventHandler(dgvKHBTDK_CellValidating);
            dgvKHBTDK.CellFormatting += DgvKHBTDK_CellFormatting;
            //dgvKHBTDK.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvKHBTDK_CellMouseDoubleClick);
            txtNgay_Color.Enter += TxtNgay_Color_Enter;
            dgvKHBTDK.KeyDown += new KeyEventHandler(dgvKHBTDK_KeyDown);
          
		}
        private void Update_DsBaoTri()
        {
            if (txtNgay_Color.Text == "")
                return;
            Hashtable ht = new Hashtable();
            ht.Add("CHUOI", txtNgay_Color.Text);
            strNgay_List = SQLExec.ExecuteReturnValue("sp_GetListChuoi", ht, CommandType.StoredProcedure).ToString();
            if (cboDot_BT.Text != "")
                SQLExec.Execute("UPDATE R06DSBAOTRI SET Ngay_Color = '"+ txtNgay_Color.Text + "' WHERE Ma_DotBT = '"+ cboDot_BT.Text + "'");
        }
        private void TxtNgay_Color_Enter(object sender, EventArgs e)
        {
            Update_DsBaoTri();
        }

        private void DgvKHBTDK_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (txtNgay_Color.Text == "")
                return;
           

            if (Common.Inlist(dgvKHBTDK.Columns[e.ColumnIndex].Name, strNgay_List))
                e.CellStyle.BackColor = Color.GreenYellow;
            else
                e.CellStyle.BackColor = Color.WhiteSmoke;
        }

        new public void Load()
		{
            //numNam.Value = Element.sysWorkingYear;

            dtSo_Ct = SQLExec.ExecuteReturnDt("SELECT * FROM R06DSBAOTRI ORDER BY Ngay_Ct2 DESC");
            DataRow drSo_Ct = dtSo_Ct.NewRow();
            drSo_Ct["Ma_DotBT"] = "";
            dtSo_Ct.Rows.Add(drSo_Ct);
            dtSo_Ct.AcceptChanges();

            cboDot_BT.DataSource = dtSo_Ct;
            cboDot_BT.ValueMember = "Ma_DotBT";
            cboDot_BT.DisplayMember = "Ma_DotBT";
            cboDot_BT.SelectedValue = "";
            
			this.Build();
            FillData();
			this.BindingLanguage();
           
			this.Show();
		}

		private void Build()
		{
			dgvKHBTDK.strZone = "THBTDK";
			dgvKHBTDK.BuildGridView();

            dgvKHBTDK.ReadOnly = false;
            foreach (DataGridViewColumn dgvc in dgvKHBTDK.Columns)
                dgvc.ReadOnly = false;
            if (dgvKHBTDK.Columns.Contains("Ma_Tb"))
                dgvKHBTDK.Columns["Ma_Tb"].ReadOnly = true;
            if (dgvKHBTDK.Columns.Contains("Ten_Tb"))
                dgvKHBTDK.Columns["Ten_Tb"].ReadOnly = true;
            if (dgvKHBTDK.Columns.Contains("Noi_Dung"))
                dgvKHBTDK.Columns["Noi_Dung"].ReadOnly = true;

            if (!Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access) && !Common.CheckPermission("IS_PTP", enuPermission_Type.Allow_Access))
            {
                chkIs_Kt.Enabled = false;
                btSave.Enabled = false;
            }

            DataGridView_Language();
		}
        private void DataGridView_Language()
        {
            if (dgvKHBTDK.Columns.Contains("Noi_Dung"))
            {
                dgvKHBTDK.Columns["Noi_Dung"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvKHBTDK.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvKHBTDK.Columns.Contains("Ten_Vt_HH"))
            {
                dgvKHBTDK.Columns["Ten_Vt_HH"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvKHBTDK.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
         
        }
		private void FillData()
		{
            Hashtable ht = new Hashtable();
            ht.Add("MA_DOTBT", cboDot_BT.Text);
            ht.Add("MA_NH_TB", txtMa_Nh_Tb.Text);
            ht.Add("MA_TB", txtMa_Tb.Text);
            ht.Add("PHAN_LOAI_CV", txtPhan_Loai_Cv.Text);
        
			dtKHBTDK = SQLExec.ExecuteReturnDt("sp_GetTHBTDK", ht, CommandType.StoredProcedure);
			bdsKHBTDK.DataSource = dtKHBTDK;
			dgvKHBTDK.DataSource = bdsKHBTDK;

            bdsSearch = bdsKHBTDK;
            ExportControl = dgvKHBTDK;
		}

        void cboSo_Ct_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboDot_BT.Text != "" && this.cboDot_BT.Text != "System.Data.DataRowView")
            {
                DataRow dr = DataTool.SQLGetDataRowByID("R06DSBAOTRI", "Ma_DotBT", cboDot_BT.Text);
                lbtTen_DotBT.Text = Convert.ToDateTime(dr["Ngay_Ct1"]).ToShortDateString() + " đến " + Convert.ToDateTime(dr["Ngay_Ct2"]).ToShortDateString();
                chkIs_Kt.Checked = Convert.ToBoolean(dr["Is_Kt"]);
                txtNgay_Color.Text = Convert.ToString(dr["Ngay_Color"]);
                string strUpdate = "SELECT DATEDIFF(DAY,@Ngay_Ct1, @Ngay_Ct2)";
                Hashtable ht = new Hashtable();
                ht.Add("NGAY_CT1", dr["Ngay_Ct1"]);
                ht.Add("NGAY_CT2", dr["Ngay_Ct2"]);
                int dbNgay = Convert.ToInt16(SQLExec.ExecuteReturnValue(strUpdate, ht, CommandType.Text));
                Update_DsBaoTri();
                int i = dbNgay + 1;
                int j = 0;
                while (j <= i)
                {
                    j++;
                    if (dgvKHBTDK.Columns.Contains("Ngay_0" + j + ""))
                        dgvKHBTDK.Columns["Ngay_0" + j + ""].Visible = true;
                    if (dgvKHBTDK.Columns.Contains("Ngay_" + j + ""))
                        dgvKHBTDK.Columns["Ngay_" + j + ""].Visible = true;
                }
                while(i <= 25)
                {
                    i++;
                    if (dgvKHBTDK.Columns.Contains("Ngay_0"+ i +""))
                        dgvKHBTDK.Columns["Ngay_0" + i + ""].Visible = false;
                    if (dgvKHBTDK.Columns.Contains("Ngay_" + i + ""))
                        dgvKHBTDK.Columns["Ngay_" + i + ""].Visible = false;

                    
                }
            }

            FillData();
        }
      
        void btSave_Click(object sender, EventArgs e)
        {
            if (cboDot_BT.Text != "System.Data.DataRowView")
            {
                Hashtable ht = new Hashtable();
                ht.Add("IS_KT", chkIs_Kt.Checked);
                ht.Add("MA_DOTBT", cboDot_BT.Text);
                SQLExec.Execute("UPDATE R06DSBAOTRI SET Is_Kt = @Is_Kt WHERE Ma_DotBT = @Ma_DotBT", ht, CommandType.Text);
                Save();
                chkIs_Kt.Checked = !chkIs_Kt.Checked;

                Common.MsgOk("Bạn đã cập nhật xong");
            }
        }
        void EditCt()
        {
            if (bdsKHBTDK.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsKHBTDK.Current).Row;
            //string strColName = dgvKHBTDK.Columns[e.ColumnIndex].Name;

            if ((drCurrent["STT"]) != string.Empty)
            {

                if (((string)drCurrent["Stt"]).Trim() == string.Empty || ((string)drCurrent["Ma_Ct"]).Trim() == string.Empty)
                    return;

                DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", (string)drCurrent["Ma_Ct"]);

                string strMethodName = (string)drDmCt["Edit_Voucher_Method"];

                string[] arrStr = strMethodName.Split(':');
                if (arrStr.Length != 3)
                {
                    Common.MsgCancel("Định dạng MethodName = " + strMethodName + " không đúng");
                    return;
                }

                string strAssembly = arrStr[0];
                string strType = arrStr[1];

                Assembly asl = Assembly.Load(strAssembly);
                Type type = asl.GetType(strType);

                Form frm = (Form)Activator.CreateInstance(type);

                object[] objPara = new object[] { enuEdit.Edit, drCurrent, null };

                type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, objPara);

                FillData();
                bdsKHBTDK.Position = bdsKHBTDK.Find("Ident00", drCurrent["Ident00"]);
            }
        }
        void dgvKHBTDK_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex < 0)
                return;

            if (bdsKHBTDK.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsKHBTDK.Current).Row;
            string strColName = dgvKHBTDK.Columns[e.ColumnIndex].Name;

            if ((drCurrent["STT"]) != string.Empty)
            {

                if (((string)drCurrent["Stt"]).Trim() == string.Empty || ((string)drCurrent["Ma_Ct"]).Trim() == string.Empty)
                    return;

                DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", (string)drCurrent["Ma_Ct"]);

                string strMethodName = (string)drDmCt["Edit_Voucher_Method"];

                string[] arrStr = strMethodName.Split(':');
                if (arrStr.Length != 3)
                {
                    Common.MsgCancel("Định dạng MethodName = " + strMethodName + " không đúng");
                    return;
                }

                string strAssembly = arrStr[0];
                string strType = arrStr[1];

                Assembly asl = Assembly.Load(strAssembly);
                Type type = asl.GetType(strType);

                Form frm = (Form)Activator.CreateInstance(type);

                object[] objPara = new object[] { enuEdit.Edit, drCurrent, null };

                type.InvokeMember(arrStr[2], BindingFlags.InvokeMethod, null, frm, objPara);

                FillData();
                bdsKHBTDK.Position = bdsKHBTDK.Find("Ident00", drCurrent["Ident00"]);
            }
        }
        void dgvKHBTDK_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex < 0)
                return;

            if (bdsKHBTDK.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsKHBTDK.Current).Row;
            string strColName = dgvKHBTDK.Columns[e.ColumnIndex].Name;
            string strSQL;  string strSQL_TinhTrang = "";
            
            if ((drCurrent["STT"]) != string.Empty && !Common.Inlist(strColName,"MA_TB,TEN_TB,NOI_DUNG"))
            {
                if (Common.Inlist(strColName, "TINH_TRANG_TH"))
                {
                    DataGridViewCell dgvCell = dgvKHBTDK.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    string strSo_Xe = dgvCell.FormattedValue.ToString().Trim();
                    strSo_Xe = strSo_Xe.ToUpper();
                    dgvKHBTDK.CancelEdit();
                    dgvCell.Value = e.FormattedValue.ToString().ToUpper();
                    strSQL = "UPDATE R06CT_BTTB SET " + strColName + " = UPPER(@Value) WHERE Stt = @Stt AND Stt0 = @Stt0";
                } 
                else
                    strSQL = "UPDATE R06CT_BTTB SET " + strColName + " = @Value WHERE Stt = @Stt AND Stt0 = @Stt0";
                
                Hashtable htPara = new Hashtable();
                htPara["STT"] = drCurrent["Stt"];
                htPara["STT0"] = drCurrent["Stt0"];
                htPara["VALUE"] = e.FormattedValue;
               
                Hashtable htPara1 = new Hashtable();
                htPara1["STT"] = drCurrent["Stt"];
                htPara1["STT0"] = drCurrent["Stt0"];
                htPara1["TINH_TRANG_TH"] = e.FormattedValue;
                htPara1["CREATE_LOG"] = Common.GetCurrent_Log();

                if (RosySystem.Data.SQLExec.Execute(strSQL, htPara, CommandType.Text))
                {
                    if (strColName == "TINH_TRANG_TH" && e.FormattedValue != "")
                        RosySystem.Data.SQLExec.Execute("sp_UpdateKQBTDK", htPara1, CommandType.StoredProcedure);

                    drCurrent[strColName] = e.FormattedValue;
                    drCurrent.AcceptChanges();
                }
            }
        }
        bool Save()
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

            sqlCom.Parameters.AddWithValue("@Is_Lock", chkIs_Kt.Checked);
            sqlCom.Parameters.AddWithValue("@Log_Duyet", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_THBTDK";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_THBTDK";
            paraCt.Value = Voucher.GetTVPValue("R06CT_BTTB", "TVP_THBTDK", this.dtKHBTDK);
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
         #region Print
        void btPrint_Click(object sender, EventArgs e)
        {
            //printDetail(true);
        }
        private bool printDetail(bool bPreview)
        {
            if (bdsKHBTDK.Position < 0)
                return false;

            DataTable dtHeader = new DataTable();
            DataTable dtDetail = new DataTable();


            Hashtable ht = new Hashtable();
            ht.Add("MA_NH_TB", txtMa_Nh_Tb.Text);
            ht.Add("MA_TB", txtMa_Tb.Text);
            ht.Add("MA_DOTBT", cboDot_BT.Text);


            DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintTHBTDK", ht, CommandType.StoredProcedure);
            dtHeader = ds.Tables[0];
            dtDetail = ds.Tables[1];

            if (!dtKHBTDK.Columns.Contains("REPORT_FILE"))
                dtKHBTDK.Columns.Add("REPORT_FILE", typeof(string));

            if (!dtKHBTDK.Columns.Contains("NGAY_CT"))
                dtKHBTDK.Columns.Add("NGAY_CT", typeof(DateTime));

            drKHBTDKT["REPORT_FILE"] = strReportFile;
            drKHBTDKT["NGAY_CT"] = Element.sysNgay_Ct2;
            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drKHBTDKT, dtDetail, bPreview, true);

            
        }
        #endregion
        void txtPhan_Loai_CV_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtPhan_Loai_Cv.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "LOAI_CV_BTTB");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'LOAI_CV_BTTB'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtPhan_Loai_Cv.Text = string.Empty;
                lbtTen_Phan_Loai_Cv.Text = string.Empty;
            }
            else
            {
                txtPhan_Loai_Cv.Text = drLookup["Type_ID"].ToString();
                lbtTen_Phan_Loai_Cv.Text = drLookup["Type_Name"].ToString();
            }
            FillData();
        }

        void txtMa_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Tb.Text.Trim();
            bool bRequire = false;
            DataRow drLookup;

            if (strFilterTb != string.Empty)
                drLookup = Lookup.ShowLookup("MA_TB", txtMa_Tb.Text, bRequire, "Ma_Tb LIKE '" + strFilterTb + "%'", "");
            else
                drLookup = Lookup.ShowLookup("MA_TB", txtMa_Tb.Text, bRequire, "", "");

            if (drLookup == null)
            {
                txtMa_Tb.Text = string.Empty;
                lbtTen_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Tb.Text = (string)drLookup["Ma_Tb"];
                lbtTen_Tb.Text = (string)drLookup["Ten_Tb"];

            }
            FillData();
        }

        void txtMa_Nh_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_Tb.Text.Trim();
            bool bRequire = false;


            DataRow drLookup = Lookup.ShowLookup("MA_NH_TB", txtMa_Nh_Tb.Text, bRequire, "Nh_Cuoi = 1", "");

            if (drLookup == null)
            {
                txtMa_Nh_Tb.Text = string.Empty;
                lbtTen_Nh_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Nh_Tb.Text = (string)drLookup["Ma_Nh_Tb"];
                lbtTen_Nh_Tb.Text = (string)drLookup["Ten_Nh_Tb"];
                strFilterTb = (string)drLookup["Ma_Nh_Tb"];
            }
            FillData();
        }
        private void Design()
        {
            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
        }


		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        void dgvKHBTDK_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.F2:
                    EditCt();
                    break;
                
                case Keys.F3:
                    EditCt();
                    break;
                
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
	}
}
