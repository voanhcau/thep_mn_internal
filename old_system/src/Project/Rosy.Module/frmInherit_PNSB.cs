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
	public partial class frmInherit_PNSB : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInheritVoucher;
		BindingSource bdsInheritVoucher = new BindingSource();
		
		string strMa_Ct = string.Empty;
		frmVoucher_Edit frmVoucher_Edit;
		DataRow drCurrent, drDmCt_Current;
		public bool Is_Accept = false;
        string strMa_Nvu = string.Empty;

        #endregion

        #region Contructor

        public frmInherit_PNSB()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
            //this.btSearch.Click += new EventHandler(btSearch_Click);
			this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);
            //this.chkPhoi.CheckStateChanged += new EventHandler(chkPhoi_CheckStateChanged);
            //txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);

            txtCa_Sx.Validating += new CancelEventHandler(txtCa_Sx_Validating);
		}

       

        #endregion

		#region Method

		public void Load(frmVoucher_Edit frmVoucher_Edit)
		{
			this.frmVoucher_Edit = frmVoucher_Edit;
			this.strMa_Ct = (string)frmVoucher_Edit.strMa_Ct;
            this.strMa_Nvu = frmVoucher_Edit.drEdit["Ma_Nvu"].ToString();
            if (Common.InlistLike(strMa_Ct,"PXSB"))
            {
                pnlNhapPhoi.Visible = true;
                pnlPhoiKt.Visible = false;

                lblNgay_Sx.Visible = lblCa_Sx.Visible = dteNgay_Sx.Visible = txtCa_Sx.Visible = false;

                chkInheritOverwrite.Checked = false;
            }
            else if (Common.InlistLike(strMa_Ct, "PXPM"))
            {
                pnlNhapPhoi.Visible = false;
                pnlPhoiKt.Visible = false;

                lblNgay_Sx.Visible = lblCa_Sx.Visible = dteNgay_Sx.Visible = txtCa_Sx.Visible = false;

                chkInheritOverwrite.Checked = false;
            }
            else
            {
                pnlNhapPhoi.Visible = false;
                pnlPhoiKt.Visible = false;

                dteNgay_Ct1.Visible = dteNgay_Ct2.Visible = false;
                lblNgay_Ct1.Visible = lblNgay_Ct2.Visible = false;
            }

			dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            dteNgay_Sx.Text = Library.DateToStr(Element.sysNgay_Ct2);

			drDmCt_Current = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", frmVoucher_Edit.strMa_Ct.ToString());

			Build();
			BindingLanguage();


			this.ShowDialog();
		}
        public void Load(frmVoucher_Edit frmVoucher_Edit, string strCa_Sx1, DateTime dteNgay_Sx1)
        {
            this.frmVoucher_Edit = frmVoucher_Edit;
            this.strMa_Ct = (string)frmVoucher_Edit.strMa_Ct;
           
            pnlNhapPhoi.Visible = false;
            pnlPhoiKt.Visible = false;

            dteNgay_Ct1.Visible = dteNgay_Ct2.Visible = false;
            lblNgay_Ct1.Visible = lblNgay_Ct2.Visible = false;
            
            dteNgay_Sx.Text = Library.DateToStr(dteNgay_Sx1);
            txtCa_Sx.Text = strCa_Sx1;

            drDmCt_Current = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", frmVoucher_Edit.strMa_Ct.ToString());

            Build();
            BindingLanguage();


            this.ShowDialog();
        }
        //public void Load(DataRow drHeader)
        //{
        //    if (drHeader.Table.Columns.Contains("So_Ct"))
        //        txtSo_Ct.Text = drHeader["So_Ct"].ToString();

        //    dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
        //    dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

        //    drDmCt_Current = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", drHeader["Ma_Ct"].ToString());

        //    Build();
        //    FillData();
        //    BindingLanguage();

        //    this.ShowDialog();
        //}

		void Build()
		{

            if (Common.InlistLike(strMa_Ct, "PXSB"))
			    dgvInheritVoucher.strZone = "INHERIT_PNSB";
            else if (Common.InlistLike(strMa_Ct, "PXPM"))
                dgvInheritVoucher.strZone = "INHERIT_PXPM";
            else
                dgvInheritVoucher.strZone = "INHERIT_PHOI";

			dgvInheritVoucher.BuildGridView();

			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;

			if (dgvInheritVoucher.Columns.Contains("CHON"))
				dgvInheritVoucher.Columns["CHON"].ReadOnly = false;

            //if (dgvInheritVoucher.Columns.Contains("SL_XUAT_PHOI_NGUOI"))
            //    dgvInheritVoucher.Columns["SL_XUAT_PHOI_NGUOI"].ReadOnly = false;

            //if (dgvInheritVoucher.Columns.Contains("SL_PHOI_NGUOI_CON_LAI"))
            //{
            //    foreach (DataRow dr in dgvInheritVoucher.Rows)
            //        dr["SL_PHOI_NGUOI_CON_LAI"] = Convert.ToInt64(dr["SL_PHOI_NGUOI"]) - Convert.ToInt64(dr["SL_PHOI_NGUOI_DA_XUAT"]) - Convert.ToInt64(dr["SL_XUAT_PHOI_NGUOI"]);
            //}

            foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
            {
                if (dgvc.Name.StartsWith("SL"))
                    dgvc.DefaultCellStyle.Format = "N0";
            }
		}

		void FillData()
		{
            if (Common.InlistLike(strMa_Ct, "PXSB,PXPM"))
            {
                Hashtable htPara = new Hashtable();
                htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
                htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
                htPara.Add("ME1", txtMe1.Text);
                htPara.Add("ME2", txtMe2.Text);
                htPara.Add("PHOI_NONG", rbPhoi_Nong.Checked);
                htPara.Add("MA_NVU", strMa_Nvu);
                //htPara.Add("MA_DVCS", Element.sysMa_DvCs);

                dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_PNSB", htPara, CommandType.StoredProcedure);
            }
            else if (strMa_Ct == "PNSB")
            {
                Hashtable htPara = new Hashtable();
                htPara.Add("NGAY_SX", dteNgay_Sx.Text);
                htPara.Add("CA_SX", txtCa_Sx.Text);
                dtInheritVoucher = SQLExec.ExecuteReturnDt("sp_Inherit_BarcodePH", htPara, CommandType.StoredProcedure);
            }
            else
            {
                string strKey = "Ngay_Ct BETWEEN '" + dteNgay_Ct1.Text + "' AND '" + dteNgay_Ct2.Text + "'";

                if (rbNhap_CXL.Checked == true)
                    dtInheritVoucher = SQLExec.ExecuteReturnDt("SELECT Ma_Vt, Dvt, Phan_Loai_Phoi, SUM(So_Luong) AS So_Luong FROM R05CTNXPHOI WHERE Ma_Ct = 'PNSB' AND Phan_Loai_Phoi <> 'CXL' AND " + strKey + " GROUP BY Ma_Vt, Dvt, Phan_Loai_Phoi");
                else if (rbNhap_SX.Checked == true)
                    dtInheritVoucher = SQLExec.ExecuteReturnDt("SELECT Ma_Vt, Dvt, Phan_Loai_Phoi, SUM(So_Luong) AS So_Luong FROM R05CTNXLRPHOI WHERE Phan_Loai_Phoi <> 'CXL' AND " + strKey + " GROUP BY Ma_Vt, Dvt, Phan_Loai_Phoi");
                else if (rbXuatSx.Checked == true)
                    dtInheritVoucher = SQLExec.ExecuteReturnDt("SELECT Ma_Vt, Dvt, SUM(So_Luong) AS So_Luong FROM R05CTNXPHOI WHERE Ma_Ct = 'PXSB' AND ");
                else
                    dtInheritVoucher = SQLExec.ExecuteReturnDt("SELECT Ma_Vt, Dvt, SUM(So_Luong) AS So_Luong FROM R05CTNXPHOI WHERE Ma_Ct = 'PXSB'");
            }
			bdsInheritVoucher.DataSource = dtInheritVoucher;
			dgvInheritVoucher.DataSource = bdsInheritVoucher;

			bdsSearch = bdsInheritVoucher;
			bdsLookup = bdsInheritVoucher;
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

        //void txtMa_Ct_Validating(object sender, CancelEventArgs e)
        //{
        //    string strValue = txtMa_Ct.Text.Trim();
        //    bool bRequire = true;
        //    string strKey = string.Empty;

        //    DataRow drLookup = Lookup.ShowLookup("Ma_Ct", strValue, bRequire, strKey);

        //    if (bRequire && drLookup == null)
        //        e.Cancel = true;

        //    if (drLookup == null)
        //        txtMa_Ct.Text = string.Empty;
        //    else
        //    {
        //        txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();
        //    }
        //}

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

//        void btSearch_Click(object sender, EventArgs e)
//        {
//            bool bRequire = true;
//            string strKey = "Ma_Ct LIKE '" + txtMa_Ct.Text + "%'";

//            if (chkInheritedExcept.Checked)
//                strKey += " AND Stt NOT IN (SELECT Stt_Org FROM " + drDmCt_Current["Table_Ct"].ToString() + " WHERE Stt_Org <> '')";

//            DataRow drLookup = Lookup.ShowLookup("Stt", "", bRequire, strKey);

//            if (drLookup != null)
//            {
//                txtMa_Ct.Text = (string)drLookup["Ma_Ct"];
//                dteNgay_Ct1.Text = Library.DateToStr((DateTime)drLookup["Ngay_Ct"]);
//                txtSo_Ct.Text = (string)drLookup["So_Ct"];
				
//                DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

//                if (drDmCt == null)
//                    return;

//                string strQuery = @"
//					SELECT *, CAST(1 AS BIT) AS Chon 
//						FROM " + drDmCt["Table_Ct"] + @" 
//						WHERE Stt = '" + drLookup["Stt"].ToString() + @"'
//						ORDER BY Stt,Stt0";

//                dtInheritVoucher = SQLExec.ExecuteReturnDt(strQuery);

//                bdsInheritVoucher.DataSource = dtInheritVoucher;
//                dgvInheritVoucher.DataSource = bdsInheritVoucher;

//                bdsSearch = bdsInheritVoucher;
//                bdsLookup = bdsInheritVoucher;
//            }
//        }

        //void chkPhoi_CheckStateChanged(object sender, EventArgs e)
        //{
        //    if (chkPhoi.CheckState == CheckState.Checked)
        //        chkPhoi.Text = "Phôi nạp nguội";
        //    else
        //        chkPhoi.Text = "Phôi nạp nóng & Phôi nạp trung gian";
        //}
        void txtCa_Sx_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtCa_Sx.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "CA_SX");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'CA_SX'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtCa_Sx.Text = string.Empty;
               
            }
            else
            {
                //Kiểm tra tồn tại ca sx theo ngày
                if (strMa_Ct == "PXSB" && Common.Inlist(drLookup["Type_ID"].ToString().Substring(1), "A,B,C"))
                {
                    DataTable dtDmCa = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R81DMCA WHERE Ngay_Sx = '" + dteNgay_Sx.Text + "' AND Ca = '" + drLookup["Type_ID"].ToString().Substring(1) + "'");
                    if (dtDmCa.Rows.Count == 0)
                        Common.MsgOk("Ngày " + dteNgay_Sx.Text + " không có ca " + drLookup["Type_ID"].ToString().Substring(1) + ". Bạn vui lòng kiểm tra lại!!!");
                    else
                    {
                        txtCa_Sx.Text = drLookup["Type_ID"].ToString();
                      
                    }
                }
                else
                {
                    txtCa_Sx.Text = drLookup["Type_ID"].ToString();
                  
                }
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
                        if (dtInheritVoucher.Columns.Contains("SL_Xuat_Phoi_Nguoi"))
                            dr["SL_Xuat_Phoi_Nguoi"] = 0;
					}
			}
			else
				base.OnKeyDown(e);
		}

		#endregion

	}
}
