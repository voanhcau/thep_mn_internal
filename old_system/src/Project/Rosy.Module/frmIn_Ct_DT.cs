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
using RosySystem.Public;

namespace RosyModule
{
	public partial class frmIn_Ct_DT : RosySystem.Customize.frmEdit
	{
		public frmIn_Ct_DT()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);

            
		}

		public void Load(DataRow drViewPh)
		{
			this.drEdit = drViewPh;

			Common.ScaterMemvar(this, ref drViewPh);
			Load();

			BindingLanguage();
			LoadDicName();	

			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
            
		}
		private void Load()
		{
            // Gán giá trị de nghi thanh toan
            string strDnTt = "SELECT * FROM R80PH WHERE Stt = '" + drEdit["Stt"]  + "'";
            DataTable dtDnTt = SQLExec.ExecuteReturnDt(strDnTt);

            chkIs_YcDt1.Checked = (bool)dtDnTt.Rows[0]["Is_YcDt1"];
            chkIs_YcDt2.Checked = (bool)dtDnTt.Rows[0]["Is_YcDt2"];
            chkIs_YcDt3.Checked = (bool)dtDnTt.Rows[0]["Is_YcDt3"];

            DataTable dtDDH = SQLExec.ExecuteReturnDt("SELECT * FROM R04DDHPO WHERE Stt = '" + drEdit["Stt"].ToString() + "'");
            if (dtDDH.Rows.Count > 0)
            {
                txtPhat_Gh.Text = dtDDH.Rows[0]["Phat_Gh"].ToString();
                txtPhat_Tt.Text = dtDDH.Rows[0]["Phat_Tt"].ToString();
            }
            else
            {
                dtDDH = SQLExec.ExecuteReturnDt("SELECT * FROM R04DDHPO "+
                " WHERE Phat_Gh <> '' "+
                " AND Stt IN (SELECT MAX(Stt) FROM R80PH WHERE MA_CT = 'DT' AND Stt+ CONVERT(VARCHAR(11), Ngay_Ct, 103) "+
                " IN (SELECT Stt+ CONVERT(VARCHAR(11), MAX(Ngay_Ct), 103) FROM R80PH WHERE MA_CT = 'DT' and KienNghi_Bb <> '' AND So_Ct LIKE '%KHVT%' GROUP BY Stt))");
              
                    txtPhat_Gh.Text = dtDDH.Rows[0]["Phat_Gh"].ToString();
                    txtPhat_Tt.Text = dtDDH.Rows[0]["Phat_Tt"].ToString();
                
            }
            
            // Lấy giá trị gần nhất của nhận xét và kiến nghị
			if (drEdit["Ten_Tat"] == "" && drEdit["NhanXet_Bb"] == "" && drEdit["KienNghi_Bb"] == "")
			{
				Hashtable ht = new Hashtable();

				ht.Add("NGAY_CT", drEdit["Ngay_Ct"]);
				ht.Add("MA_CT", drEdit["Ma_Ct"]);
				ht.Add("MA_CT1", drEdit["Ma_Ct"]);
				ht.Add("MA_DT", drEdit["Ma_Dt"]);
				ht.Add("MA_DT1", drEdit["Ma_Dt"]);

				string strSql = "SELECT Ten_Tat, NhanXet_Bb, KienNghi_Bb FROM R80PH WHERE Ma_Ct = @Ma_Ct1 AND Ma_Dt = @Ma_Dt AND Ngay_Ct = (SELECT MAX(Ngay_Ct) FROM R80PH WHERE Ma_Ct = @Ma_Ct AND Ma_Dt = @Ma_Dt1 AND Ngay_Ct < @Ngay_Ct)";

				DataTable dtDuTru = SQLExec.ExecuteReturnDt(strSql, ht, CommandType.Text);

				if (dtDuTru.Rows.Count > 0)
				{
					txtKienNghi_BB.Text = dtDuTru.Rows[0]["KienNghi_Bb"].ToString();
					txtNhanXet_BB.Text = dtDuTru.Rows[0]["NhanXet_Bb"].ToString();
					txtTen_Tat.Text = dtDuTru.Rows[0]["Ten_Tat"].ToString();
				}

             
			}
		}
        private bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);

			
			//Cập nhật thông tin xống R80Ph
			string strSQLUpdate = "UPDATE R80PH SET " +
                    "Ten_Tat = @Ten_Tat, NhanXet_Bb = @NhanXet_Bb, KienNghi_Bb = @KienNghi_Bb, Is_YcDt1 = @Is_YcDt1, Is_YcDt2 = @Is_YcDt2, Is_YcDt3 = @Is_YcDt3 " +
					" WHERE Stt = @Stt";

			Hashtable ht = new Hashtable();
			ht["NHANXET_BB"] = txtNhanXet_BB.Text;
			ht["KIENNGHI_BB"] = txtKienNghi_BB.Text;
			ht["TEN_TAT"] = txtTen_Tat.Text;
            ht["IS_YCDT1"] = chkIs_YcDt1.Checked;
            ht["IS_YCDT2"] = chkIs_YcDt2.Checked;
            ht["IS_YCDT3"] = chkIs_YcDt3.Checked;
			ht["STT"] = drEdit["Stt"];

            //Cập nhật thông tin R04DDHPO
            string strSQLUpdate1 = string.Empty;
            if(DataTool.SQLCheckExist("R04DDHPO","Stt",drEdit["Stt"].ToString()))
                strSQLUpdate1 = "UPDATE R04DDHPO SET Phat_Gh = @Phat_Gh, Phat_Tt = @Phat_Tt, Phat_Adp = @Phat_Adp WHERE Stt = @Stt";
            else
                strSQLUpdate1 = "INSERT INTO R04DDHPO (Stt, Phat_Gh, Phat_Tt,Phat_Adp) " +
					"SELECT  @Stt, @Phat_Gh, @Phat_Tt, @Phat_Adp";

            Hashtable ht1 = new Hashtable();
            ht1["STT"] = drEdit["Stt"];
            ht1["PHAT_GH"] = txtPhat_Gh.Text;
            ht1["PHAT_TT"] = txtPhat_Tt.Text;
			ht1["PHAT_ADP"] = txtPhat_Adp.Text;
			SQLExec.Execute(strSQLUpdate1, ht1, CommandType.Text);

			return SQLExec.Execute(strSQLUpdate, ht, CommandType.Text);
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
        
		private void frmIn_Ct_NMPT_Load(object sender, EventArgs e)
		{

		}

        private void txtPhat_Gh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
