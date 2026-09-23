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

namespace RosyModule
{
	public partial class frmInheritVoucher : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInheritVoucher;
		BindingSource bdsInheritVoucher = new BindingSource();
		
		string strMa_Ct = string.Empty;
		frmVoucher_Edit frmVoucher_Edit;
		DataRow drCurrent, drDmCt_Current;
        DateTime dteNgay_Ct;
		public bool Is_Accept = false;

		#endregion

		#region Contructor

		public frmInheritVoucher()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
			this.btSearch.Click += new EventHandler(btSearch_Click);
			this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);

			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			txtMa_Nhom.Validating += new CancelEventHandler(txtMa_Nhom_Validating);
			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
		}

		

		#endregion

		#region Method

		public void Load(frmVoucher_Edit frmVoucher_Edit)
		{
			this.txtMa_Dt.bUseAutoDropDown = true;
            
			this.frmVoucher_Edit = frmVoucher_Edit;
			this.strMa_Ct = (string)frmVoucher_Edit.strMa_Ct;
            DataRow drDmNvu = DataTool.SQLGetDataRowByID("R81DMNVU", "Ma_Nvu", frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString());
            dteNgay_Ct = Convert.ToDateTime(Library.DateToStr(Element.sysNgay_Ct2));

            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);


			if (Common.Inlist(this.strMa_Ct, "BBPL,BBNL"))
			{
				txtMa_Ct.Text = "PXTH";
				dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
			}
			else if (Common.Inlist(this.strMa_Ct,  "BBPT,BBTH"))
			{
				txtMa_Ct.Text = "DT";
			}
			else if (Common.Inlist(this.strMa_Ct, "DT"))
			{
				txtMa_Ct.Text = "PYC";
			}
			else if (Common.Inlist(this.strMa_Ct, "BN"))
            {
                txtMa_Ct.Text = "DNTT";
            }
			else if (this.strMa_Ct == "PXPT")
			{
				txtMa_Ct.Text = "DNX";
				btSearch.Visible = false;
			}
			else if (this.strMa_Ct == "PNPT")
			{
				txtMa_Ct.Text = "DNN";
			}
            //else if (this.strMa_Ct == "SO")
            //{
            //    txtMa_Ct.Text = "SO";
            //}

			else if (Common.Inlist(this.strMa_Ct, "BBREM,PXBR,PXDC,PXDCA"))
			{
                if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "PX14")
                {
                    txtMa_Ct.Text = "SO";
                    dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
                }
                else if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "PXDT08")
                {
                    txtMa_Ct.Text = "NMHH";
                    dteNgay_Ct1.Text = dteNgay_Ct.Subtract(new TimeSpan(1, 0, 0, 0)).ToString();
                }
                else
                {
                    txtMa_Ct.Text = "PXTH";
                    dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
                }
			}
			else if (this.strMa_Ct == "HD" || this.strMa_Ct == "HDXK")
			{
                dteNgay_Ct1.Text = dteNgay_Ct.Subtract(new TimeSpan(7, 0, 0, 0)).ToString();
                if(frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "HD06")
                    txtMa_Ct.Text = "PXKV";
                else if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "HDM1")
                    txtMa_Ct.Text = "NMHH";
                else if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "HDM2")
                    txtMa_Ct.Text = "PXDC";
                else if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "HDM6")
                    txtMa_Ct.Text = "NMGK";
                else if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "HDQT")
                    txtMa_Ct.Text = "NM";
                else
				    txtMa_Ct.Text = "PXBR";
			}
            else if (this.strMa_Ct == "PXKV")
            {
               
                dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
                txtMa_Ct.Text = "SOCP";
                txtMa_Kho.Text = drDmNvu["Ma_Kho"].ToString();
                
            }
			else if (this.strMa_Ct == "HDHH" )
			{
                if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "HD01")
                    txtMa_Ct.Text = "NMHH";
                else
                    txtMa_Ct.Text = "PXHCP";
			
                //dtekNgay_Ct1.Text = DateTime.Now.ToString("01/MM/yyyy") ;
                dteNgay_Ct1.Text = dteNgay_Ct.Subtract(new TimeSpan(7, 0, 0, 0)).ToString();
			}
			else if (this.strMa_Ct == "LXH")
			{
				txtMa_Ct.Text = "SO";
				dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
			}
            
			
			else if (this.strMa_Ct == "HDXK")
			{
				txtMa_Ct.Text = "PXBR";
                dteNgay_Ct1.Text = dteNgay_Ct.Subtract(new TimeSpan(7, 0, 0, 0)).ToString();
			}
			else if (this.strMa_Ct == "POCG")
			{
				txtMa_Ct.Text = "PONL";
			}
			else if (this.strMa_Ct == "BBNL")
			{
				txtMa_Ct.Text = "POCG";
			}
			else if (Common.Inlist(this.strMa_Ct, "PXCP"))
			{
				dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);

                //if (Common.InlistLike(frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString(), "PXCP_"))
                    txtMa_Ct.Text = "SOCP";
                //else
                //    txtMa_Ct.Text = "NMHH";


                    if (Common.Inlist(frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString(), "PXCPBH,PXDCCBH"))
                    txtMa_Kho.Text = "08BH";
                    else if (Common.Inlist(frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString(), "PXCPTD, PXDCCTD"))
                    txtMa_Kho.Text = "08TD";
                    else if (Common.Inlist(frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString(), "PXCPNB, PXDCCNB"))
                    txtMa_Kho.Text = "08NB";
                else
                    txtMa_Kho.Text = drDmNvu["Ma_Kho"].ToString();
			}
            else if (Common.Inlist(this.strMa_Ct, "NMHH"))
            {
                txtMa_Ct.Text = "SOCP";
                dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
                if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "MH07")
                {
                    txtMa_Kho.Text = "08BH";
                }
                else if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "MH08")
                {
                    txtMa_Kho.Text = "08TD";
                }
                else
                    txtMa_Kho.Text = "08NB";
            }
            else if (Common.Inlist(this.strMa_Ct, "NMGK"))
            {
                txtMa_Ct.Text = "PXCP";
                dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
                if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "MH10")
                {
                    txtMa_Kho.Text = "551NT_BH";
                }
                else if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "MH11")
                {
                    txtMa_Kho.Text = "551NT_TD";
                }
                else
                    txtMa_Kho.Text = "551NT_NB";
            }
            else if (strMa_Ct == "DT")
            {
                chkInheritedExcept.Checked = false;
                chkInheritedExcept.Visible = false;
            }
            else if (this.strMa_Ct == "PNGK")
            {
				dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
				txtMa_Ct.Text = "PXKV";
            }
            else if (Common.Inlist(strMa_Ct, "PXGK,PXDCD"))
            {
                dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
                txtMa_Ct.Text = "PXTH";
            }
            else if (this.strMa_Ct == "BTTT")
            {
                txtMa_Ct.Text = "BTNB";
               
            }
            else if (this.strMa_Ct == "BTKH")
            {
                txtMa_Ct.Text = "BTTT";

            }
            //else if (this.strMa_Ct == "CTSC")
            //{
            //    txtMa_Ct.Text = "BTKH";

            //}
            else if (this.strMa_Ct == "BTNT")
            {
                txtMa_Ct.Text = "BTKH";

            }
            else if (this.strMa_Ct == "DTCP")
            {
                txtMa_Ct.Text = "BBHH";

            }
            else if (this.strMa_Ct == "BBBG")
            {
                txtMa_Ct.Text = "DTCP";
            }
            else if (this.strMa_Ct == "GRVC")
            {
                txtMa_Ct.Text = "BBBG";
            }
            else if (this.strMa_Ct == "BBBN")
            {
                txtMa_Ct.Text = "GRVC";
            }
            else if (this.strMa_Ct == "DNN")
            {
                txtMa_Ct.Text = "BBBN";
            }
           
            else if (this.strMa_Ct == "PXKG")
            {
                txtMa_Ct.Text = "SOCP";
                if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "PX17")
                {
                    txtMa_Kho.Text = "058NB";
                }
                else if (frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString() == "PX18")
                {
                    txtMa_Kho.Text = "058TD";
                }
                else
                    txtMa_Kho.Text = "058BH";
            }
			drDmCt_Current = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", frmVoucher_Edit.strMa_Ct.ToString());

			Build();
			FillData();
			BindingLanguage();


			this.ShowDialog();
		}
		public void Load(DataRow drHeader)
		{
			this.strMa_Ct = (string)drHeader["Ma_Ct"];

			if (this.strMa_Ct == "HDKG")
			{
				txtMa_Ct.Text = "PXDC";
			
			}
			else if (this.strMa_Ct == "POCG")
			{
				txtMa_Ct.Text = "PONL";
			}
			else if (this.strMa_Ct == "BBNL")
			{
				txtMa_Ct.Text = "POCG";
			}
			else if (this.strMa_Ct == "PXHCP")// || this.strMa_Ct == "HDHH")
			{
				txtMa_Ct.Text = "NMHH";
				dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
			}
			
			else if (this.strMa_Ct == "HDXK")
			{
				txtMa_Ct.Text = "PXBR";
				dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct2);
			}
           
            else if (this.strMa_Ct == "PXKG")
            {
                txtMa_Ct.Text = "SOCP";
            }
			
			if (drHeader.Table.Columns.Contains("So_Ct") && this.strMa_Ct != "BBNL")
				txtSo_Ct.Text = drHeader["So_Ct"].ToString();

			
			dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
			

			drDmCt_Current = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", drHeader["Ma_Ct"].ToString());

			Build();
			FillData();
			BindingLanguage();

			this.ShowDialog();
		}
		void Build()
		{
			
            if (drDmCt_Current["Ma_Ct"].ToString() == "TP")
				dgvInheritVoucher.strZone = "INHERITVOUCHER_PHOI";
			
			else if (drDmCt_Current["Ma_Ct"].ToString() == "LXH")
				dgvInheritVoucher.strZone = "INHERITVOUCHER_LXH";

			else if (drDmCt_Current["Ma_Ct"].ToString() == "BBREM")
				dgvInheritVoucher.strZone = "INHERITVOUCHER_BAREM";

			else if (drDmCt_Current["Ma_Ct"].ToString() == "PXBR" || drDmCt_Current["Ma_Ct"].ToString() == "PXDC")
				dgvInheritVoucher.strZone = "INHERITVOUCHER_BAREM";

			else if (drDmCt_Current["Ma_Ct"].ToString() == "HD")
				dgvInheritVoucher.strZone = "INHERITVOUCHER_HD";

			else if (drDmCt_Current["Ma_Ct"].ToString() == "DT")
				dgvInheritVoucher.strZone = "INHERITVOUCHER_DT";

            else if (drDmCt_Current["Ma_Ct"].ToString() == "PXKV")
                dgvInheritVoucher.strZone = "INHERITVOUCHER_PXKV";
            else if (drDmCt_Current["Ma_Ct"].ToString() == "BN")
                dgvInheritVoucher.strZone = "INHERITVOUCHER_BN";
			else if (drDmCt_Current["Ma_Ct"].ToString() == "BBPL")
				dgvInheritVoucher.strZone = "INHERITVOUCHER_BBPL";
			else if (Common.Inlist(drDmCt_Current["Ma_Ct"].ToString(), "BBNL") && txtMa_Ct.Text != "POCG")
				dgvInheritVoucher.strZone = "INHERITVOUCHER_BBPL";
			else if (Common.Inlist(drDmCt_Current["Ma_Ct"].ToString(), "BTTT,BTKH,CTSC,BTNT,DTCP"))
                dgvInheritVoucher.strZone = "INHERITVOUCHER_BTTT";
           	else if(Common.Inlist(drDmCt_Current["Ma_Ct"].ToString(), "NMHH"))
				dgvInheritVoucher.strZone = "INHERITVOUCHER_NMHH";
			else
                dgvInheritVoucher.strZone = "INHERITVOUCHER";

			dgvInheritVoucher.BuildGridView();

			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

			txtMa_Dt_CbNv.bUseAutoDropDown = true;
			txtMa_Bp.bUseAutoDropDown = true;

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;

            if (dgvInheritVoucher.Columns.Contains("CHON"))
                dgvInheritVoucher.Columns["CHON"].ReadOnly = false;
		}
		void FillData()
		{
			DataRow drDmCt ;
		
			drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);
		
			if (drDmCt == null)
				return;

			string strKey = "(1=1) ";
            string strKey0 = string.Empty;

            string strTableCt = string.Empty;
            
            if (txtMa_Ct.Text == "DNTU")
                strTableCt = "R04CTDNTU";
            else
			    strTableCt = drDmCt["Table_Ct"].ToString();

			if (strTableCt == string.Empty)
				return;

			DataTable dtTestData = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM " + strTableCt + " WHERE 0 = 1");

			if (txtMa_Ct.Text != string.Empty)
				strKey += " AND Ma_Ct = '" + txtMa_Ct.Text + "'";

			if (txtSo_Ct.Text != string.Empty)
				strKey += " AND So_Ct = '" + txtSo_Ct.Text + "'";

            //if (!dteNgay_Ct1.IsNull)
            //    strKey += " AND Ngay_Ct BETWEEN '" + dteNgay_Ct1.Text + "' AND '" + dteNgay_Ct2.Text + "'";

            if (!dteNgay_Ct1.IsNull)
                strKey += " AND (Ngay_Ct >= '" + dteNgay_Ct1.Text + "')";

            if (!dteNgay_Ct2.IsNull)
                strKey += " AND (Ngay_Ct <= '" + dteNgay_Ct2.Text + "')";

			if (txtMa_Dt.Text != string.Empty)
				strKey += " AND Ma_Dt = '" + txtMa_Dt.Text + "'";
			
			if (txtMa_Kho.Text != string.Empty)
				strKey += " AND Ma_Kho = '" + txtMa_Kho.Text + "'";

			if (txtMa_Vt.Text != "" && dtTestData.Columns.Contains("Ma_Vt"))
				strKey += " AND Ma_Vt = '" + txtMa_Vt.Text + "'";

			if (txtTk_No.Text != "" && dtTestData.Columns.Contains("Tk_No"))
				strKey += " AND Tk_No LIKE '" + txtTk_No.Text + "%'";

			if (txtTk_Co.Text != "" && dtTestData.Columns.Contains("Tk_Co"))
				strKey += " AND Tk_Co LIKE '" + txtTk_Co.Text + "%'";

            strKey0 = strKey; 

			if (chkInheritedExcept.Checked)
				strKey += " AND Stt NOT IN (SELECT Stt_Org FROM " + drDmCt_Current["Table_Ct"].ToString() + " WHERE Stt_Org <> '')";

			string strQuery = string.Empty;

            if (Common.Inlist(txtMa_Ct.Text, "PYCPT,PYCCK,PYCTH,NCTH,DT,BBTH,BBPT,PNPT,DNX,DNXNL,PX,PONL,POCG,NM,NK,BTNB,BTTT,BTKH,CTSC,BBHH,DTCP,DTXE,BTBN,DNN,DTNA,BBPL,BBNL") 
					&& !Common.Inlist(drDmCt_Current["Table_Ct"].ToString(), "R06CTTS,R04CTHD"))
			{
			    drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

			    if (drDmCt == null)
			        return;

			    Hashtable htPara = new Hashtable();

			    htPara.Add("MA_CT_SOURCE", txtMa_Ct.Text);
				htPara.Add("MA_CT_DEST", this.strMa_Ct);// (string)frmVoucher_Edit.strMa_Ct);
			    htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			    htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
			    htPara.Add("SO_CT", txtSo_Ct.Text);
			    htPara.Add("MA_VT", txtMa_Vt.Text);
			    htPara.Add("MA_DT", txtMa_Dt.Text);
				htPara.Add("MA_BP", txtMa_Bp.Text);
				htPara.Add("MA_DT_CBNV", txtMa_Dt_CbNv.Text);
				htPara.Add("MA_NHOM", txtMa_Nhom.Text);
                htPara.Add("MA_KHO", txtMa_Kho.Text);
				htPara.Add("USER_LOGIN", Element.sysUser_Id);
				htPara.Add("IS_INHERITED", chkInheritedExcept.Checked);
				htPara.Add("TONG_HOP", chkTong_Hop.Checked);
			    htPara.Add("MA_DVCS", Element.sysMa_DvCs);

				//DataTable dtInheritVoucher = new DataTable();

				dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_Refresh", htPara, CommandType.StoredProcedure);

			    bdsInheritVoucher.DataSource = dtInheritVoucher;
			    dgvInheritVoucher.DataSource = bdsInheritVoucher;

			    bdsSearch = bdsInheritVoucher;
			    bdsLookup = bdsInheritVoucher;
			}
            else if (Common.Inlist(txtMa_Ct.Text, "PXTH") && Common.Inlist(frmVoucher_Edit.strMa_Ct, "GCTC"))
            {
                drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

                if (drDmCt == null)
                    return;

                Hashtable htPara = new Hashtable();
                htPara.Add("MA_CT_SOURCE", txtMa_Ct.Text);
                htPara.Add("MA_CT_DEST", (string)frmVoucher_Edit.strMa_Ct);
                htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
                htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
                htPara.Add("SO_CT", txtSo_Ct.Text);
                htPara.Add("MA_VT", txtMa_Vt.Text);
                htPara.Add("MA_DT", txtMa_Dt.Text);
                htPara.Add("SO_XE", txtSo_Xe.Text);
              
                htPara.Add("IS_INHERITED", chkInheritedExcept.Checked);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_GCTC", htPara, CommandType.StoredProcedure);

                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
            else if (Common.Inlist(txtMa_Ct.Text, "SO,SOCP") && !Common.Inlist(frmVoucher_Edit.strMa_Ct , "PXBR,BBREM,SO,PXB,NMHH,PXKV,PXCP,PNGK,PXDC,PXDCC,PNCP"))
			{
				drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

				if (drDmCt == null)
					return;

				Hashtable htPara = new Hashtable();
				htPara.Add("MA_CT_SOURCE", txtMa_Ct.Text);
				htPara.Add("MA_CT_DEST", (string)frmVoucher_Edit.strMa_Ct);
				htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
				htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
				htPara.Add("SO_CT", txtSo_Ct.Text);
				htPara.Add("MA_VT", txtMa_Vt.Text);
				htPara.Add("MA_DT", txtMa_Dt.Text);
				htPara.Add("SO_XE", txtSo_Xe.Text);
				htPara.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau.Text);
				htPara.Add("IS_INHERITED", chkInheritedExcept.Checked);
				htPara.Add("MA_DVCS", Element.sysMa_DvCs);

				dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_LXH", htPara, CommandType.StoredProcedure);

				bdsInheritVoucher.DataSource = dtInheritVoucher;
				dgvInheritVoucher.DataSource = bdsInheritVoucher;

				bdsSearch = bdsInheritVoucher;
				bdsLookup = bdsInheritVoucher;
			}
         
			else if (Common.InlistLike(txtMa_Ct.Text, "PXTH") && Common.InlistLike(strMa_Ct, "PXPH,PXSB"))
			{
				strQuery = @"
					SELECT CAST(0 AS BIT) AS Chon, MAX(Stt) AS Stt, MAX(Ngay_Ct) AS Ngay_Ct, So_Ct, MAX(Ma_Ct) AS Ma_Ct, MAX(Ma_Dt) AS Ma_Dt, Ma_Vt_Sp AS Ma_Vt, So_Xe, SUM(So_Luong) AS So_Luong
						FROM R80PH_SCALE 
						WHERE Ma_Vt_Sp IN (SELECT Ma_Vt FROM R81DMVT WHERE Ma_Nh_Vt = 'PHOI') AND " + strKey + " GROUP BY So_Xe, So_Ct, Ma_Vt_Sp"; //Ngay_Ct BETWEEN '" + dteNgay_Ct1.Text + "' AND '" + dteNgay_Ct2.Text + "'	GROUP BY Stt, Ma_Vt_Sp, Ngay_Ct, So_Ct, Ma_Ct ORDER BY Ngay_Ct";

				dtInheritVoucher = SQLExec.ExecuteReturnDt(strQuery);

				bdsInheritVoucher.DataSource = dtInheritVoucher;
				dgvInheritVoucher.DataSource = bdsInheritVoucher;

				bdsSearch = bdsInheritVoucher;
				bdsLookup = bdsInheritVoucher;

			}
			else if (Common.InlistLike(txtMa_Ct.Text, "PXTH") && frmVoucher_Edit.strMa_Ct == "BBREM")
			{
				drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

				if (drDmCt == null)
					return;

				Hashtable htPara = new Hashtable();
				htPara.Add("MA_CT_SOURCE", txtMa_Ct.Text);
				htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
				htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
				htPara.Add("SO_CT", txtSo_Ct.Text);
				htPara.Add("MA_VT", txtMa_Vt.Text);
				htPara.Add("MA_DT", txtMa_Dt.Text);
				htPara.Add("SO_XE", txtSo_Xe.Text);
				htPara.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau.Text);
				htPara.Add("IS_INHERITED", chkInheritedExcept.Checked);
				htPara.Add("MA_DVCS", Element.sysMa_DvCs);

				dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_BREM", htPara, CommandType.StoredProcedure);

				bdsInheritVoucher.DataSource = dtInheritVoucher;
				dgvInheritVoucher.DataSource = bdsInheritVoucher;

				bdsSearch = bdsInheritVoucher;
				bdsLookup = bdsInheritVoucher;
			}
			else if (Common.InlistLike(txtMa_Ct.Text, "PXTH,SO,NMHH") && Common.Inlist(frmVoucher_Edit.strMa_Ct,"PXBR,PXDC,PXGK,PXDCD,PXDCA"))
			{
				drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

				if (drDmCt == null)
					return;

				Hashtable htPara = new Hashtable();
				htPara.Add("MA_CT_SOURCE", txtMa_Ct.Text);
                htPara.Add("MA_CT_DEST", frmVoucher_Edit.strMa_Ct);
				htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
				htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
				htPara.Add("SO_CT", txtSo_Ct.Text);
				htPara.Add("MA_VT", txtMa_Vt.Text);
                htPara.Add("MA_KHO", txtMa_Kho.Text);
				htPara.Add("MA_DT", txtMa_Dt.Text);
				htPara.Add("SO_XE", txtSo_Xe.Text);
				htPara.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau.Text);
				htPara.Add("IS_INHERITED", chkInheritedExcept.Checked);
				htPara.Add("MA_DVCS", Element.sysMa_DvCs);

				dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_PXBR", htPara, CommandType.StoredProcedure);

				bdsInheritVoucher.DataSource = dtInheritVoucher;
				dgvInheritVoucher.DataSource = bdsInheritVoucher;

				bdsSearch = bdsInheritVoucher;
				bdsLookup = bdsInheritVoucher;
			}
            else if (Common.InlistLike(txtMa_Ct.Text, "SOCP") && Common.Inlist(frmVoucher_Edit.strMa_Ct , "PXKV,PXKG"))
            {
                drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

                if (drDmCt == null)
                    return;

                Hashtable htPara = new Hashtable();
                htPara.Add("MA_CT_SOURCE", txtMa_Ct.Text);
                htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
                htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
                htPara.Add("SO_CT", txtSo_Ct.Text);
                htPara.Add("MA_VT", txtMa_Vt.Text);
                htPara.Add("MA_KHO", txtMa_Kho.Text);
                htPara.Add("MA_DT", txtMa_Dt.Text);
                htPara.Add("SO_XE", txtSo_Xe.Text);
                htPara.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau.Text);
                htPara.Add("IS_INHERITED", chkInheritedExcept.Checked);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_PXKV", htPara, CommandType.StoredProcedure);

                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
			else if (Common.InlistLike(txtMa_Ct.Text, "SOCP") && Common.Inlist(frmVoucher_Edit.strMa_Ct, "PNGK,PNCP"))
			{
				drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

				if (drDmCt == null)
					return;
				// sử dụng điều chĩnh GK CỦA CP
				Hashtable htPara = new Hashtable();
				htPara.Add("MA_CT_SOURCE", txtMa_Ct.Text);
				htPara.Add("MA_CT_DEST", frmVoucher_Edit.strMa_Ct);
				htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
				htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
				htPara.Add("SO_CT", txtSo_Ct.Text);
				htPara.Add("MA_VT", txtMa_Vt.Text);
				htPara.Add("MA_KHO", txtMa_Kho.Text);
				htPara.Add("MA_DT", txtMa_Dt.Text);
				htPara.Add("SO_XE", txtSo_Xe.Text);
				htPara.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau.Text);
				htPara.Add("IS_INHERITED", chkInheritedExcept.Checked);
				htPara.Add("MA_DVCS", Element.sysMa_DvCs);

				dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_PNGK_SOCP", htPara, CommandType.StoredProcedure);

				bdsInheritVoucher.DataSource = dtInheritVoucher;
				dgvInheritVoucher.DataSource = bdsInheritVoucher;

				bdsSearch = bdsInheritVoucher;
				bdsLookup = bdsInheritVoucher;
			}
			else if (Common.InlistLike(txtMa_Ct.Text, "PXBKV") && frmVoucher_Edit.strMa_Ct == "PXKV")
            {
                drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

                if (drDmCt == null)
                    return;

                Hashtable htPara = new Hashtable();
                htPara.Add("MA_CT_SOURCE", txtMa_Ct.Text);
                htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
                htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
                htPara.Add("SO_CT", txtSo_Ct.Text);
                htPara.Add("MA_VT", txtMa_Vt.Text);
                htPara.Add("MA_KHO", txtMa_Kho.Text);
                htPara.Add("MA_DT", txtMa_Dt.Text);
                htPara.Add("SO_XE", txtSo_Xe.Text);
                htPara.Add("SO_XA_LAN_TAU", txtSo_Xa_Lan_Tau.Text);
                htPara.Add("IS_INHERITED", chkInheritedExcept.Checked);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_PXBKV_PXKV", htPara, CommandType.StoredProcedure);

                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
			else if (Common.InlistLike(txtMa_Ct.Text, "PXBR,PXDC,PXHCP,PXB"))
			{
				drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

				if (drDmCt == null)
					return;

				Hashtable htPara = new Hashtable();
				htPara.Add("MA_CT_SOURCE", txtMa_Ct.Text);
                htPara.Add("MA_CT_DEST", frmVoucher_Edit.strMa_Ct);
				htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
				htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
				htPara.Add("SO_CT", txtSo_Ct.Text);
				htPara.Add("MA_VT", txtMa_Vt.Text);
				htPara.Add("MA_DT", txtMa_Dt.Text);
				htPara.Add("IS_INHERITED", chkInheritedExcept.Checked);
				htPara.Add("MA_DVCS", Element.sysMa_DvCs);

				dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_HD", htPara, CommandType.StoredProcedure);

				bdsInheritVoucher.DataSource = dtInheritVoucher;
				dgvInheritVoucher.DataSource = bdsInheritVoucher;

				bdsSearch = bdsInheritVoucher;
				bdsLookup = bdsInheritVoucher;
			}
			else if (Common.InlistLike(txtMa_Ct.Text, "NMHH,NMGK") && frmVoucher_Edit.strMa_Ct != "PXCP" )
			{

				drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

				if (drDmCt == null)
					return;

				Hashtable htPara = new Hashtable();
				htPara.Add("MA_CT_SOURCE", txtMa_Ct.Text);
				htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
				htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
				htPara.Add("SO_CT", txtSo_Ct.Text);
				htPara.Add("MA_VT", txtMa_Vt.Text);
				htPara.Add("MA_DT", txtMa_Dt.Text);
                
				htPara.Add("IS_INHERITED", chkInheritedExcept.Checked);
				htPara.Add("MA_DVCS", Element.sysMa_DvCs);

				if (this.strMa_Ct == "PXHCP") // hang ky gui
					dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_PXHCP", htPara, CommandType.StoredProcedure);
				if (this.strMa_Ct.StartsWith("HD"))//(this.strMa_Ct == "HDHH" || this.strMa_Ct == "HDXK") // hang xuat ngay
				    dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_HDCP", htPara, CommandType.StoredProcedure);
               
                
				bdsInheritVoucher.DataSource = dtInheritVoucher;
				dgvInheritVoucher.DataSource = bdsInheritVoucher;

				bdsSearch = bdsInheritVoucher;
				bdsLookup = bdsInheritVoucher;
			
			}
            else if (Common.InlistLike(txtMa_Ct.Text, "DNTT,DNTU"))
            {
				string strMa_Ct_Dest = "";
				
				if (Common.Inlist(strMa_Ct, "KT,BT"))
					strMa_Ct_Dest = strMa_Ct;

				Hashtable htPara = new Hashtable();
                htPara.Add("TABLE_CT", strTableCt);
                htPara.Add("MA_CT", txtMa_Ct.Text);
				htPara.Add("MA_CT_DEST", strMa_Ct_Dest);
				htPara.Add("KEY", strKey);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                dtInheritVoucher = SQLExec.ExecuteReturnDt("Sp_Inherit_DnTt", htPara, CommandType.StoredProcedure);

                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
            else if (Common.Inlist(txtMa_Ct.Text, "SOCP") && Common.InlistLike(frmVoucher_Edit.strMa_Ct, "HD,NMHH"))
            {
                Hashtable htPara = new Hashtable();
                htPara.Add("TABLE_CT", strTableCt);
                htPara.Add("MA_CT", frmVoucher_Edit.strMa_Ct);
                htPara.Add("MA_KHO", txtMa_Kho.Text);
                htPara.Add("MA_DT", txtMa_Dt.Text);
                htPara.Add("KEY", strKey);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                dtInheritVoucher = SQLExec.ExecuteReturnDt("Sp_Inherit_NMHH", htPara, CommandType.StoredProcedure);

                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
            else if (Common.Inlist(txtMa_Ct.Text, "PXCP") && Common.InlistLike(frmVoucher_Edit.strMa_Ct, "NMGK"))
            {
                Hashtable htPara = new Hashtable();
                htPara.Add("KEY", strKey);
                htPara.Add("MA_CT", frmVoucher_Edit.strMa_Ct);
                htPara.Add("MA_KHO", txtMa_Kho.Text);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_PXCP_NMKG", htPara, CommandType.StoredProcedure);

                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
            else if (Common.InlistLike(txtMa_Ct.Text, "SOCP") && Common.Inlist(frmVoucher_Edit.strMa_Ct, "PXDCC,PXCP"))
            {
                Hashtable htPara = new Hashtable();
                htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
                htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
                htPara.Add("SO_CT", txtSo_Ct.Text);
                htPara.Add("MA_CT", txtMa_Ct.Text);//frmVoucher_Edit.strMa_Ct
                htPara.Add("MA_CT_DEST", frmVoucher_Edit.strMa_Ct);
                htPara.Add("MA_KHO", txtMa_Kho.Text);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_SOCP_PXCP", htPara, CommandType.StoredProcedure);

                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
            else if (Common.InlistLike(txtMa_Ct.Text, "NMHH") && Common.InlistLike(frmVoucher_Edit.strMa_Ct, "PXCP"))
            {
                Hashtable htPara = new Hashtable();
                htPara.Add("TABLE_CT", strTableCt);
                htPara.Add("MA_CT", frmVoucher_Edit.strMa_Ct);
                htPara.Add("MA_KHO", txtMa_Kho.Text);
                htPara.Add("KEY", strKey);
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_NMHH_PXCP", htPara, CommandType.StoredProcedure);

                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
            else if (Common.InlistLike(txtMa_Ct.Text, "PXKV") && Common.InlistLike(frmVoucher_Edit.strMa_Ct, "HDXK"))
            {
                Hashtable htPara = new Hashtable();
                htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
                htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
                htPara.Add("SO_CT", txtSo_Ct.Text);
                htPara.Add("MA_CT", txtMa_Ct.Text);//frmVoucher_Edit.strMa_Ct
                htPara.Add("MA_KHO", txtMa_Kho.Text);
                
                htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_PXKV_HDXK", htPara, CommandType.StoredProcedure);

                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
            else if (Common.InlistLike(txtMa_Ct.Text, "SO") && Common.InlistLike(frmVoucher_Edit.strMa_Ct, "PXB"))
            {
                strQuery = @"
					SELECT *, So_Ct AS So_LXH, CAST(1 AS BIT) AS Chon 
						FROM " + strTableCt + @" 
						WHERE " + @strKey + @"
						ORDER BY Stt,Stt0";

                dtInheritVoucher = SQLExec.ExecuteReturnDt(strQuery);

                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
			else if (Common.InlistLike(txtMa_Ct.Text, "PXTH") && Common.InlistLike(frmVoucher_Edit.strMa_Ct, "BBPL"))
			{

				if(txtMa_Vt.Text != "")
					strKey += " AND Ma_Vt_Sp LIKE '"+ txtMa_Vt.Text+"'";

				if (txtMa_Dt.Text != "")
					strKey = strKey.Replace("AND Ma_Dt", "AND T1.Ma_Dt");


				strTableCt = "R80PH_SCALE";
				strQuery = @"
					SELECT T1.Stt, Ma_Ct, Ngay_Ct, So_Ct, T1.Ma_Dt, T2.Ten_Dt, T2.Dia_Chi, So_Ct AS So_PCan, So_Luong as So_luong_Cl, Ma_Vt_Sp, CAST(1 AS INT) AS He_So9,
						 So_Xe, So_Luong AS So_Luong_HH, So_Xa_Lan_Tau, N'Nghiệm thu mua hàng' AS Dien_Giai, CAST(0 AS BIT) AS Chon 
						FROM " + strTableCt + @" T1 LEFT JOIN R81DMDT T2 ON T1.Ma_Dt = T2.Ma_Dt 
						WHERE So_Luong <> 0 AND " + @strKey + @"
						ORDER BY Ngay_Ct, So_Ct";

				dtInheritVoucher = SQLExec.ExecuteReturnDt(strQuery);

				bdsInheritVoucher.DataSource = dtInheritVoucher;
				dgvInheritVoucher.DataSource = bdsInheritVoucher;

				bdsSearch = bdsInheritVoucher;
				bdsLookup = bdsInheritVoucher;
			}
			else if (Common.InlistLike(txtMa_Ct.Text, "PXTH") && Common.InlistLike(frmVoucher_Edit.strMa_Ct, "BBNL"))
			{

				if (txtMa_Vt.Text != "")
					strKey += " AND Ma_Vt_Sp LIKE '" + txtMa_Vt.Text + "'";

				if (txtMa_Dt.Text != "")
					strKey = strKey.Replace("AND Ma_Dt", "AND T1.Ma_Dt");


				strTableCt = "R80PH_SCALE";
				strQuery = @"
					SELECT T1.Stt, Ma_Ct, Ngay_Ct, So_Ct, T1.Ma_Dt, T2.Ten_Dt, T2.Dia_Chi, So_Ct AS So_PCan, So_Luong as So_luong_Cl, Ma_Vt_Sp, T3.Ten_Vt AS Ten_Vt_Sp, 
							T1.Ma_Vt_Sp AS Ma_Vt, T3.Ten_Vt, T3.Dvt, CAST(1 AS INT) AS He_So9,
						 So_Xe, So_Luong AS So_Luong_HH, So_Xa_Lan_Tau, N'Nghiệm thu nguyên vật liệu' AS Dien_Giai, CAST(1 AS BIT) AS Chon 
						FROM " + strTableCt + @" T1 LEFT JOIN R81DMDT T2 ON T1.Ma_Dt = T2.Ma_Dt 
										LEFT JOIN (SELECT Ma_Vt, Ten_Vt, Dvt FROM R81DMVT) T3 ON T1.Ma_Vt_Sp = T3.Ma_Vt 
						WHERE So_Luong <> 0 AND Loai_Ct = '1' AND " + @strKey + @"
						ORDER BY Ngay_Ct, So_Ct";

				dtInheritVoucher = SQLExec.ExecuteReturnDt(strQuery);

				bdsInheritVoucher.DataSource = dtInheritVoucher;
				dgvInheritVoucher.DataSource = bdsInheritVoucher;

				bdsSearch = bdsInheritVoucher;
				bdsLookup = bdsInheritVoucher;
			}
			else
            {
                strQuery = @"
					SELECT *, CAST(1 AS BIT) AS Chon 
						FROM " + strTableCt + @" 
						WHERE " + @strKey + @"
						ORDER BY Stt,Stt0";

                dtInheritVoucher = SQLExec.ExecuteReturnDt(strQuery);

                bdsInheritVoucher.DataSource = dtInheritVoucher;
                dgvInheritVoucher.DataSource = bdsInheritVoucher;

                bdsSearch = bdsInheritVoucher;
                bdsLookup = bdsInheritVoucher;
            }
		}
		bool FormCheckValid()
		{
			if (dtInheritVoucher == null || dtInheritVoucher.Select("Chon = true").Length == 0)
			{
				Common.MsgCancel("Không có dữ liệu kế thừa!");
				return false;
			}

			return true;
		}

		#endregion

		#region Event

		void txtMa_Ct_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Ct.Text.Trim();
			bool bRequire = true;
			string strKey = string.Empty;

			//frmQuickLookup frmLookup = new frmQuickLookup("R00DMCT", "DMCT");
			DataRow drLookup = Lookup.ShowLookup("Ma_Ct", strValue, bRequire, strKey);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
				txtMa_Ct.Text = string.Empty;
			else
			{
				txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();

				if (txtMa_Ct.Text.StartsWith("DNX"))
					chkInheritedExcept.Checked = false;
			}
		}

		void txtMa_Nhom_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nhom.Text.Trim();
			bool bRequire = false;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("strType", "MA_NHOM");
			DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'MA_NHOM'", "", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nhom.Text = string.Empty;
				lbtTen_Nhom.Text = string.Empty;
			}
			else
			{
				txtMa_Nhom.Text = drLookup["Type_ID"].ToString();
				lbtTen_Nhom.Text = drLookup["Type_Name"].ToString();
			}
		}
		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Bp.Text = string.Empty;
				lbtTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
				lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
			}
		}
		void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv.Text = string.Empty;
				lbtTen_Dt_CbNv.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
			}
		}

	

		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho.Text = string.Empty;
				lbtTen_Kho.Text = string.Empty;
			}
			else
			{
				txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
				lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
			}
		}
		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
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

		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btSearch_Click(object sender, EventArgs e)
		{
			bool bRequire = true;
			string strKey = "Ma_Ct LIKE '" + txtMa_Ct.Text + "%'";

            strKey += " AND Ngay_Ct >= '" + dteNgay_Ct1.Text + "'";
            
            strKey += " AND Ngay_Ct <= '" + dteNgay_Ct2.Text + "'";
			
            if (chkInheritedExcept.Checked)
				strKey += " AND Stt NOT IN (SELECT Stt_Org FROM " + drDmCt_Current["Table_Ct"].ToString() + " WHERE Stt_Org <> '')";

            //DataRow drLookup = Lookup.ShowLookup("Stt", "", bRequire, strKey);
            DataRow drLookup = Tool.ShowLookup("Stt", "", bRequire, strKey, null);

			if (drLookup != null)
			{
				txtMa_Ct.Text = (string)drLookup["Ma_Ct"];
				dteNgay_Ct1.Text = Library.DateToStr((DateTime)drLookup["Ngay_Ct"]);
				txtSo_Ct.Text = (string)drLookup["So_Ct"];
				txtMa_Dt.Text = (string)drLookup["Ma_Dt"];

				DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

				if (drDmCt == null)
					return;
                
                FillData();

			}
		}

		void frmInheritVoucher_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{

				for (int i = 0; i < dtInheritVoucher.Rows.Count; i++)
				{
					dtInheritVoucher.Rows[i]["CHON"] = true;
				}
			}
			if (e.Control && e.KeyCode == Keys.U)
			{

				for (int i = 0; i < dtInheritVoucher.Rows.Count; i++)
				{
					dtInheritVoucher.Rows[i]["CHON"] = false;
				}
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5)
				this.FillData();
			else if (e.Control)
			{
				if (e.KeyCode == Keys.A)
					foreach (DataRow dr in dtInheritVoucher.Rows)
						dr["Chon"] = true;
				else if (e.KeyCode == Keys.U)
					foreach (DataRow dr in dtInheritVoucher.Rows)
					{
						dr["Chon"] = false;
						if (dtInheritVoucher.Columns.Contains("Stt_Order"))
							dr["Stt_Order"] = 0;
					}
			}
			else
				base.OnKeyDown(e);
		}

		#endregion

       
	}
}
