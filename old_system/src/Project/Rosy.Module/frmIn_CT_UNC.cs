using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using System;
using RosySystem.Public;

namespace RosyModule
{
	public partial class frmIn_CT_UNC : RosySystem.Customize.frmEdit
	{
		public frmIn_CT_UNC()
		{
			InitializeComponent();
            txtTen_Tat.Validating += new CancelEventHandler(txtTen_Tat_Validating);
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

        

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtReportTag.InputMask = (string)RosySystem.Library.Parameters.GetParaValue("SELECT_UNC");
			//VINHNQ:
			string strStt = (string)drEdit["Stt"];

			string strTk_Co = (string)SQLExec.ExecuteReturnValue("SELECT Tk_Co FROM R01CTTIEN WHERE Stt = '" + strStt + "'",CommandType.Text);

			string strMa_Dt = (string)drEdit["Ma_Dt"];

			string strKyHieuPhieu = "";
			if (txtTk_NH_A.Text == string.Empty)
			{
				DataRow drDmTk = DataTool.SQLGetDataRowByID("R81DmTk", "Tk", strTk_Co);

				if (drDmTk != null)
				{
					txtTk_NH_A.Text = (string)drDmTk["So_Tk_Nh"];
					txtTen_Dv_A.Text = Element.sysTen_Dvi;
					txtTen_NH_A.Text = (string)drDmTk["Ten_Tk_Nh"];
					txtTen_TP_A.Text = (string)drDmTk["Ten_Tp_Nh"];
					strKyHieuPhieu = (string)drDmTk["Ky_Hieu_Mau"];
					if (strKyHieuPhieu != string.Empty)
						txtReportTag.Text = strKyHieuPhieu;
				}
			}
			else
			{
				DataRow drDmTk = DataTool.SQLGetDataRowByID("R81DmTk", "Tk", strTk_Co);
				strKyHieuPhieu = (string)drDmTk["Ky_Hieu_Mau"];
				if (strKyHieuPhieu != string.Empty)
					txtReportTag.Text = strKyHieuPhieu;
			}

			if (txtTk_NH_B.Text == string.Empty)
			{
				DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DmDt", "Ma_Dt", strMa_Dt);
                //DataRow drDmPh = SQLExec.ExecuteReturnDt("SELECT MAX(Ten_Tat) FROM R80PH WHERE Ma_Ct = 'BN' AND Tk_NH_B = '" + txtTen_NH_B.Text + "' AND Tk_NH_B + CAST(Ngay_Ct AS VARCHAR(11)) IN (SELECT Tk_NH_B + CAST(MAX(Ngay_Ct) AS VARCHAR(11)) FROM R80PH WHERE Ten_Tat <> '' AND Ma_Ct = 'BN' AND Tk_NH_B = '" + txtTen_NH_B.Text + "' GROUP BY Tk_NH_B ) ").Rows[0];//DataTool.SQLGetDataRowByID("R80PH", "Tk_NH_B", (string)drDmDt["So_Tk"]);
				if (drDmDt != null)
				{
                    if (drDmDt["So_Tk_NH"].ToString() != "")
                    {
                        txtTk_NH_B.Text = (string)drDmDt["So_Tk_NH"];
                        txtTen_Dv_B.Text = (string)drDmDt["Ten_Dt"];
                        txtTen_NH_B.Text = (string)drDmDt["Ten_NH"];
                        txtTen_TP_B.Text = (string)drDmDt["Ten_TP"];
                    }
                    else
                    {
                       

                        txtTk_NH_B.Text = (string)drDmDt["So_Tk"];
                        txtTen_Dv_B.Text = (string)drDmDt["Ten_Dt"];
                        txtTen_NH_B.Text = (string)drDmDt["Ngan_Hang"];
                        txtTen_TP_B.Text = (string)drDmDt["Ten_TP"];
                        txtTen_Tat.Text = (string)drDmDt["Chi_Nhanh_NH"];
                    }
				}
			}
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			string strTable_Ph = DataTool.SQLGetNameByCode("R00DmCt", "Ma_Ct", "Table_Ph", (string)drEdit["Ma_Ct"]);

			//Cập nhật thông tin xuống R80Ph
			string strSQLUpdate = "UPDATE " + strTable_Ph + " SET " +
					" Ten_Dv_A = @Ten_Dv_A, Ten_Nh_A = @Ten_Nh_A, Tk_Nh_A = @Tk_Nh_A, Ten_Tp_A = @Ten_Tp_A, So_CMND_A = @So_CMND_A, Ngay_Cap_A = @Ngay_Cap_A, Noi_Cap_A = @Noi_Cap_A, " +
                    " Ten_Dv_B = @Ten_Dv_B, Ten_Nh_B = @Ten_Nh_B, Tk_Nh_B = @Tk_Nh_B, Ten_Tp_B = @Ten_Tp_B, So_CMND_B = @So_CMND_B, Ngay_Cap_B = @Ngay_Cap_B, Noi_Cap_B = @Noi_Cap_B, Ten_Tat = @Ten_Tat " +
				" WHERE Stt = @Stt";

			Hashtable ht = new Hashtable();
			ht["TEN_DV_A"] = txtTen_Dv_A.Text;
			ht["TEN_NH_A"] = txtTen_NH_A.Text;
			ht["TK_NH_A"] = txtTk_NH_A.Text;
			ht["TEN_TP_A"] = txtTen_TP_A.Text;
			ht["SO_CMND_A"] = txtSo_CMND_A.Text;
			ht["NGAY_CAP_A"] = Library.StrToDate(dteNgay_Cap_A.Text);
			ht["NOI_CAP_A"] = txtNoi_Cap_A.Text;

			ht["TEN_DV_B"] = txtTen_Dv_B.Text;
			ht["TEN_NH_B"] = txtTen_NH_B.Text;
			ht["TK_NH_B"] = txtTk_NH_B.Text;
			ht["TEN_TP_B"] = txtTen_TP_B.Text;
			ht["SO_CMND_B"] = txtSo_CMND_B.Text;
			ht["NGAY_CAP_B"] = Library.StrToDate(dteNgay_Cap_B.Text);
			ht["NOI_CAP_B"] = txtNoi_Cap_B.Text;
            ht["TEN_TAT"] = txtTen_Tat.Text;
			ht["STT"] = drEdit["Stt"];

			return SQLExec.Execute(strSQLUpdate, ht, CommandType.Text);
		}
        void txtTen_Tat_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTen_Tat.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "HT_GN");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'NGAN_HANG'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTen_Tat.Text = string.Empty;
                lblTen_Tat.Text = string.Empty;
            }
            else
            {
                txtTen_Tat.Text = drLookup["Type_ID"].ToString();
                lblTen_Tat.Text = drLookup["Type_Name"].ToString();
            }
        }
		private void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

	}
}
