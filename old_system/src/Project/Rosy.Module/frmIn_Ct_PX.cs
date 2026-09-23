using System;
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

namespace RosyModule
{
	public partial class frmIn_Ct_Px : RosySystem.Customize.frmEdit
	{
		public frmIn_Ct_Px()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

        public void Load(DataRow drViewPh, bool bPrint)
		{
			this.drEdit = drViewPh;

			Common.ScaterMemvar(this, ref drViewPh);
			
			BindingLanguage();
			LoadDicName();


			string strChon_Hoa_Don = Common.GetBufferValue("CHON_HOA_DON_IN") == null ? "1" : Common.GetBufferValue("CHON_HOA_DON_IN");
			rdbPhieu_Xuat.Checked = (strChon_Hoa_Don == "1");
			rdbPx_BBXN.Checked = (strChon_Hoa_Don == "2");
			//rdbPx_Barcode.Checked = (strChon_Hoa_Don == "2");
            if (bPrint)
            {
                rdbPXDT.Visible = false;
                rdbPXDTGN.Visible = false;

                rdbPX_DTGN_PDF.Visible = false;
                rdbPX_DTGN_CD.Visible = false;

                rdbPX_DT_PDF.Visible = false;
                rdbPX_DT_CD.Visible = false;
            }
            if (drViewPh["Ma_Ct"].ToString() == "PXBR")
            {
                rdbPXDTGN.Visible = false;
                rdbPX_DTGN_PDF.Visible = false;
                rdbPX_DTGN_CD.Visible = false;
                rdbPXDT.Visible = false;
                rdbPX_DT_PDF.Visible = false;
                rdbPX_DT_CD.Visible = false;
            }
			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
            if (txtNhan_Xet_Bb.Text == "")
            {
                DataTable dtEdit_Ct = SQLExec.ExecuteReturnDt("SELECT * FROM R05CTNX WHERE Stt = '" + drEdit["Stt"] + "'");
                DataRow drEdit_Ct = dtEdit_Ct.Rows[0];
                
                if (drEdit_Ct["Ht_Gn"].ToString().Length < 7)
                    return;

                if (Common.Inlist(drEdit_Ct["Ht_Gn"].ToString().Substring(2,4), "_GT_"))
                {
                    if (Common.InlistLike(drEdit_Ct["Ma_Kho"].ToString(), "06SMC") && drEdit["Ma_Ct"].ToString() == "PXBR")
                    {
                        if (drEdit_Ct["Ma_Kho"].ToString() == "")
                        {
                            Common.MsgOk("Chưa có mã kho");
                            return;
                        }
                        else
                            txtNhan_Xet_Bb.Text = SQLExec.ExecuteReturnValue("SELECT Dia_Chi FROM R81DMKHO WHERE Ma_Kho = '" + drEdit_Ct["Ma_Kho"].ToString() + "'").ToString();
                    }
                    else if (Common.InlistLike(drEdit_Ct["Ma_KhoN"].ToString(), "06SMC") && drEdit["Ma_Ct"].ToString() == "PXDC")
                    {
                        if (drEdit_Ct["Ma_KhoN"].ToString() == "")
                        {
                            Common.MsgOk("Chưa có mã kho nhập");
                            return;
                        }
                        else
                            txtNhan_Xet_Bb.Text = SQLExec.ExecuteReturnValue("SELECT Dia_Chi FROM R81DMKHO WHERE Ma_Kho = '" + drEdit_Ct["Ma_KhoN"].ToString() + "'").ToString();
                    }
                    else
                    {
                        if (drEdit_Ct["Ma_CTrinh"].ToString() == "")
                        {
                            Common.MsgOk("Chưa có mã công trình");
                            return;
                        }
                        else
                            txtNhan_Xet_Bb.Text = SQLExec.ExecuteReturnValue("SELECT Ten_Ctrinh FROM R81DMCTRINH WHERE Ma_CTrinh = '" + drEdit_Ct["Ma_CTrinh"].ToString() + "'").ToString();
                    }
                }
            }
		}

      
		private void btAccept_Click(object sender, EventArgs e)
		{
            
                isAccept = true;
                Hashtable ht = new Hashtable();
                ht.Add("STT", drEdit["Stt"].ToString());
                ht.Add("NHAN_XET_BB",txtNhan_Xet_Bb.Text);
                SQLExec.Execute("UPDATE R80PH SET NhanXet_Bb = @Nhan_Xet_Bb WHERE Stt = @Stt", ht, CommandType.Text);
                this.Close();
         }

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
      
	}
}
