using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Element;
using System.Collections;

namespace RosyModule
{
	public partial class frmChon_In_Scale : RosySystem.Customize.frmEdit
	{
        string strStt = string.Empty;
        string strStt_LXH = "";
        string strTable_Ct = "R05CTX_BARCODE";
        string strTable_Name = "R80PH_SCALE";
        string strReportTag = string.Empty;

		public frmChon_In_Scale()
		{
			InitializeComponent();

			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            cboSo_LXH.SelectedValueChanged += new EventHandler(cboSo_LXH_SelectedValueChanged);
         
            btPath.Click+=new EventHandler(btPath_Click);
            btCreateCNXX.Click += new EventHandler(btCreateCNXX_Click);
		}

        

        

		new public void Load(string strStt)
		{
            if (strStt != "")
            {
                this.strStt = strStt;
                LoadCombo();
            }
			this.ShowDialog();
		}

		new public void Load(bool bVisible, bool bBoat)
		{
			this.txtSo_Ct.Visible = this.lblSo_Ct.Visible = this.lblNgay_Ct.Visible = dteNgay_Ct.Visible = bVisible;
			this.dteNgay_Ct.Text = DateTime.Now.ToShortDateString();
            if (bBoat)
            {
                rsLabel7.Visible = false;
                cboSo_LXH.Visible = false;
                btCreateCNXX.Visible = false;

            }
            else
                chkNum_Lot.Visible = false;
			this.Load("");
		}
       
        void LoadCombo()
        {
            DataTable dtSo_LXH = SQLExec.ExecuteReturnDt("SELECT Dien_Giai AS So_LXH, Stt_Org AS Stt_LXH FROM R05CTX_BARCODE WHERE Stt = '" + strStt + "' GROUP BY Dien_Giai, Stt_Org");
            strStt_LXH = dtSo_LXH.Rows[0]["Stt_LXH"].ToString();
            cboSo_LXH.DataSource = dtSo_LXH;
            cboSo_LXH.DisplayMember = "So_LXH";
            cboSo_LXH.ValueMember = "Stt_LXH";
           
            //cboSo_LXH.SelectedIndex = 0;


        }
        void cboSo_LXH_SelectedValueChanged(object sender, EventArgs e)
        {
            //GÁN CÁC GIÁ TRỊ
           
            DataTable dtCt = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM " + strTable_Ct);
            string strMa_Vt_Sp_List = "";
            
            if (cboSo_LXH.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                this.strStt_LXH = cboSo_LXH.SelectedValue == null ? string.Empty : cboSo_LXH.SelectedValue.ToString();
            }

            if (dtCt.Columns.Contains("Ma_Vt_Sp") && dtCt.Columns.Contains("Stt"))
            {
                object objValue = SQLExec.ExecuteReturnValue("SELECT DISTINCT Ma_Vt_Sp + ',' FROM "+strTable_Ct+ " WHERE Ma_Vt_Sp <> '' AND Stt_Org = '"+ strStt_LXH+ "'  AND Stt = '" + strStt + "' FOR XML PATH('')");

                if (objValue != null && objValue.ToString() != string.Empty)
                    strMa_Vt_Sp_List = objValue.ToString();
                else
                    strMa_Vt_Sp_List = string.Empty;

                if (strMa_Vt_Sp_List.EndsWith(","))
                    strMa_Vt_Sp_List = strMa_Vt_Sp_List.Substring(0, strMa_Vt_Sp_List.Length - 1);

                txtMa_Vt_Sp_List.Text = strMa_Vt_Sp_List;
                if(strStt_LXH != "")
                    this.chkNum_Lot.Checked = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT TOP 1 Is_KCS FROM R04CTSO WHERE Stt = '" + strStt_LXH + "'").ToString());
            }
            //xử lý tên Ctrinh nếu PKD có cần cnxx
            if (DataTool.SQLCheckExist("R04CTSO", new string[] { "Stt", "Is_CNXX" }, new object[] { strStt_LXH, true }))
            {
               
                string strMa_PLCtrinh = SQLExec.ExecuteReturnValue("SELECT Ma_PLCTrinh FROM R04CTSO WHERE Stt = '" + strStt_LXH + "'").ToString();
                //gán giá trị cho Ten Cong trinh nếu có
                string strCong_Trinh = SQLExec.ExecuteReturnValue("SELECT DISTINCT Ten_Cong_Trinh FROM " + strTable_Ct + " WHERE Ma_Vt_Sp <> '' AND Stt_Org = '" + strStt_LXH + "'  AND Stt = '" + strStt + "'").ToString();
                txtTen_Cong_Trinh.Text = strCong_Trinh;

                if (strCong_Trinh == "" && strStt_LXH != "" && strMa_PLCtrinh != "")
                {
                    if (!DataTool.SQLCheckExist("R81DMPLCTRINH", "Ma_PLCtrinh", strMa_PLCtrinh))
                    { Common.MsgOk("Mã phụ lục công trình trên phiếu xác nhận đơn hàng không tồn tại trong danh mục phụ lục công trình. Liên hệ phòng kinh doanh kiểm tra lại mã phụ lục công trình này: " + strMa_PLCtrinh + ""); return; }
                    else
                        txtTen_Cong_Trinh.Text = SQLExec.ExecuteReturnValue("SELECT UPPER(Ten_PLCTrinh) FROM R81DMPLCTRINH WHERE Ma_PLCTrinh IN (SELECT Ma_PLCTrinh FROM R04CTSO WHERE Stt = '" + strStt_LXH + "')").ToString();
                }
                if (txtTen_Cong_Trinh.Text == "" && strStt_LXH != "" && SQLExec.ExecuteReturnValue("SELECT Ht_Gn FROM R04CTSO WHERE Stt = '" + strStt_LXH + "'").ToString() == "GK")
                    txtTen_Cong_Trinh.Text = SQLExec.ExecuteReturnValue("SELECT UPPER(Dien_Giai) FROM R04CTSO WHERE Stt = '" + strStt_LXH + "' GROUP BY Dien_Giai").ToString();
            }
            else
                txtTen_Cong_Trinh.Text = string.Empty;
        }
        void btPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;

            //folderBrowserDialog.
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;


            txtPath.Text = folderBrowserDialog.SelectedPath;

        }
        
        void btCreateCNXX_Click(object sender, EventArgs e)
        {
            DataTable dtHeader;
            DataTable dtDetail;
            string strPath_Export_Temp = string.Empty;
            string strPath_Export = string.Empty;
            bool Allow_Backup = true;
            bool bPreview = false;
            bool bShowDialog = false;
            string strTen_Dt = txtTen_Dt.Text;
            string strTen_Cong_Trinh = txtTen_Cong_Trinh.Text;
            string strMa_Dt_CbNv = "";
            string strMa_Ct = "PXTH";

            // LƯU Thông tin Ctrinh khách hàng cho từng LXH
            Hashtable htPara = new Hashtable();
            htPara.Add("STT", strStt);
            htPara.Add("STT_ORG", strStt_LXH);
            htPara.Add("TEN_CONG_TRINH", txtTen_Cong_Trinh.Text);

            string strSQL = "UPDATE " + strTable_Ct + " SET Ten_Cong_Trinh = @Ten_Cong_Trinh WHERE Stt = @Stt AND Stt_Org = @Stt_Org";
            SQLExec.Execute(strSQL, htPara, CommandType.Text);
            //Kết xuất file PDF CNXX DT
            strReportTag = "CT_CNXX";

            if (strTable_Name == "R80PH_SCALE")
            {
                string strSQLExec = "SELECT * FROM R81EQUIPMENTINFO WHERE Host_IP = '" + MachineInfo.GetHostIP() + "'";
                DataTable dtEquipment = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
                if (dtEquipment.Rows.Count > 0)
                {
                    Variables.strPrint_Report = (string)dtEquipment.Rows[0]["Print_Report"];
                    Variables.strPrint_Barcode = (string)dtEquipment.Rows[0]["Print_Barcode"];
                    Variables.strPrint_Eticket = (string)dtEquipment.Rows[0]["Print_Eticket"];
                }

            }

            Hashtable ht1 = new Hashtable();
            ht1.Add("STT", strStt);
            ht1.Add("STT_LXH", strStt_LXH);
            ht1.Add("IS_NUMLOT", chkNum_Lot.Checked);
            DataTable dtStandardList = SQLExec.ExecuteReturnDt("sp_GetListStandard", ht1, CommandType.StoredProcedure);
            if (rdbKCS.Checked || rdbCNXX.Checked)
            {
                bool bIs_Co_Tinh = false;
                bool bCNXX = false;
                bIs_Co_Tinh = rdbKCS.Checked;
                bCNXX = rdbCNXX.Checked;

                DataSet dsPrintVoucher;
                if (dtStandardList.Rows.Count > 1)
                {
                    
                    foreach (DataRow drStandard in dtStandardList.Rows)
                    {
                        string strMa_Vt_Sp = drStandard["Ma_Vt_Sp"].ToString();
                        string strNumLot = drStandard["Num_Lot"].ToString();

                        Hashtable ht = new Hashtable();

                        ht.Add("STT", strStt);
                        ht.Add("STT_LXH", strStt_LXH);
                        ht.Add("STANDARD_ID", drStandard["Standard_ID"]);
                        ht.Add("MA_VT_SP", strMa_Vt_Sp);
                        ht.Add("NUM_LOT", strNumLot);
                        ht.Add("MA_CT", strMa_Ct);
                        ht.Add("IS_CNXXDT", bCNXX);
                        ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

                        
                        dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintKCS_ThanhCuon", ht, CommandType.StoredProcedure);

                        dtHeader = dsPrintVoucher.Tables[0];
                        dtDetail = dsPrintVoucher.Tables[1];

                        if (dtHeader.Columns.Contains("Ten_Dt") || dtHeader.Columns.Contains("Ten_Cong_Trinh"))
                        {
                            foreach (DataRow dr in dtHeader.Rows)
                            {
                                if (dr.Table.Columns.Contains("Ten_Dt"))
                                    dr["Ten_Dt"] = strTen_Dt;

                                if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                    dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                            }
                        }

                        if (dtDetail.Columns.Contains("Ten_Dt") || dtDetail.Columns.Contains("Ten_Cong_Trinh"))
                        {
                            foreach (DataRow dr in dtDetail.Columns)
                            {
                                if (dr.Table.Columns.Contains("Ten_Dt"))
                                    dr["Ten_Dt"] = strTen_Dt;

                                if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                    dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                            }
                        }

                        if (!dtHeader.Columns.Contains("TEN_DT_CBNV"))
                            dtHeader.Columns.Add("TEN_DT_CBNV", typeof(string));

                        dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                        dtHeader.Columns.Add("TITLE", typeof(string));

                        DataRow drHeader = dtHeader.Rows[0];

                        drHeader["Title"] = "";//((string)drDmCt["Title"]).ToUpper();
                        drHeader["Report_File"] = "rpt" + strReportTag;

                        strMa_Dt_CbNv = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);
                        drHeader["Ten_Dt_CbNv"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", strMa_Dt_CbNv);


                        ////Backup File Report
                        string strPath = Parameters.GetParaValue("BACKUP_PATH_SCALE").ToString();

                        //string strPath_KCS = Path.Combine(strPath, "KCS");
                        //string strPath_KCS_End = Path.Combine(strPath_KCS, (string)dtHeader.Rows[0]["So_Ct"]);


                        if (rdbCNXX.Checked)
                        {
                            strPath = txtPath.Text;
                            string strFileName = drHeader["File_Name"].ToString();
                            Voucher.CreateFilePDF(strPath, strFileName, dtHeader, dtDetail, drHeader["Report_File"].ToString(), strTable_Name, strStt);
                        }
                        else
                        {
                            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                            frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog, Allow_Backup, strPath_Export);
                        }
                       
                    }
                }
                else
                {
                    foreach (string strMa_Vt_Sp in txtMa_Vt_Sp_List.Text.Split(','))
                    {
                        //strMa_Vt_Sp = drStandard["Ma_Vt_Sp"].ToString();
                        Hashtable ht = new Hashtable();

                        ht.Add("STT", strStt);
                        ht.Add("STT_LXH", strStt_LXH);
                        ht.Add("MA_VT_SP", strMa_Vt_Sp);
                        ht.Add("MA_CT", strMa_Ct);

                        ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);
                        ht.Add("IS_CNXXDT", bCNXX);
                        dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_PrintKCS_ThanhCuon", ht, CommandType.StoredProcedure);
                       
                        dtHeader = dsPrintVoucher.Tables[0];
                        dtDetail = dsPrintVoucher.Tables[1];

                        if (dtHeader.Columns.Contains("Ten_Dt") || dtHeader.Columns.Contains("Ten_Cong_Trinh"))
                        {
                            foreach (DataRow dr in dtHeader.Rows)
                            {
                                if (dr.Table.Columns.Contains("Ten_Dt"))
                                    dr["Ten_Dt"] = strTen_Dt;

                                if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                    dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                            }
                        }

                        if (dtDetail.Columns.Contains("Ten_Dt") || dtDetail.Columns.Contains("Ten_Cong_Trinh"))
                        {
                            foreach (DataRow dr in dtDetail.Columns)
                            {
                                if (dr.Table.Columns.Contains("Ten_Dt"))
                                    dr["Ten_Dt"] = strTen_Dt;

                                if (dr.Table.Columns.Contains("Ten_Cong_Trinh"))
                                    dr["Ten_Cong_Trinh"] = strTen_Cong_Trinh;
                            }
                        }

                        if (!dtHeader.Columns.Contains("TEN_DT_CBNV"))
                            dtHeader.Columns.Add("TEN_DT_CBNV", typeof(string));

                        dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                        dtHeader.Columns.Add("TITLE", typeof(string));

                        DataRow drHeader = dtHeader.Rows[0];

                        drHeader["Title"] = "";// ((string)drDmCt["Title"]).ToUpper();
                        drHeader["Report_File"] = "rpt" + strReportTag;

                        strMa_Dt_CbNv = DataTool.SQLGetNameByCode("R00MEMBER", "Member_ID", "Ma_Dt_CbNv", Element.sysUser_Id);
                        drHeader["Ten_Dt_CbNv"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", strMa_Dt_CbNv);


                        //Backup File Report
                        string strPath = Parameters.GetParaValue("BACKUP_PATH_SCALE").ToString();


                        //string strPath_Export_Temp = string.Empty;
                        //string strPath_Export = string.Empty;
                        //bool Allow_Backup = true;


                        if (rdbCNXX.Checked)
                        {
                            strPath = txtPath.Text;
                            string strFileName = drHeader["File_Name"].ToString();
                            Voucher.CreateFilePDF(strPath, strFileName, dtHeader, dtDetail, drHeader["Report_File"].ToString(), "R80PH_SCALE", strStt);
                        }
                        else
                        {
                            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                            frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview, bShowDialog, Allow_Backup, strPath_Export);
                        }
                    }

                  
                }

                try
                {


                    if (!Common.MsgYes_No("Anh (chị) đã hoàn thành tạo CNXX điện tử cho lệnh xuất hàng số: " + cboSo_LXH.SelectedValue + " .Anh (chị) muốn tiếp tục cho lệnh khác không?", "Y"))
                        this.Close();
                }
                catch (Exception ex)
                { Common.MsgOk(ex.Message); }
            }
        }
		
        void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			isAccept = true;
			this.Close();
		}

	}
}
