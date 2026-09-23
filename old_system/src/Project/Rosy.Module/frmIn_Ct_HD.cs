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
	public partial class frmIn_Ct_HD : RosySystem.Customize.frmEdit
	{
        string strTable_Ph = string.Empty;
        string strTable_Ct = string.Empty;

		public frmIn_Ct_HD()
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
            strTable_Ph = DataTool.SQLGetNameByCode("R00DmCt", "Ma_Ct", "Table_Ph", (string)drEdit["Ma_Ct"]);
            strTable_Ct = DataTool.SQLGetNameByCode("R00DmCt", "Ma_Ct", "Table_Ct", (string)drEdit["Ma_Ct"]);
			if (txtTk_Nh_B.Text == string.Empty)
			{
				DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DmDt", "Ma_Dt", (string)drViewPh["Ma_Dt"]);

				if (drDmDt != null)
				{
					txtTk_Nh_B.Text = (string)drDmDt["So_Tk_NH"];
					txtTen_NH_B.Text = (string)drDmDt["Ten_NH"];
				}
			}

            if (bPrint)
            {
                rdbHd_Tu_In.Visible = false;
                rdbHd_Dt_Cd.Visible = false;
                rdbHd_DT_PDF.Visible = false;
            }

			string strChon_Hoa_Don = Common.GetBufferValue("CHON_HOA_DON_IN") == null ? "1" : Common.GetBufferValue("CHON_HOA_DON_IN");
			rdbHd_Tu_In.Checked = (strChon_Hoa_Don == "1");
			rdbHd_Dat_In.Checked = (strChon_Hoa_Don == "2");
			rdbPhieu_Xuat.Checked = (strChon_Hoa_Don == "3");
            rdbHd_DT.Checked = (strChon_Hoa_Don == "4");
            //hiển thị tên của người duyệt
            DataTable dtCt = SQLExec.ExecuteReturnDt("SELECT * FROM "+ strTable_Ct +" WHERE Stt = '"+ drEdit["Stt"] +"'");
            if (dtCt.Rows[0]["Ten_Kd"] == "" || dtCt.Rows[0]["Ten_Kt"] == "")
            {
                txtTen_Kd.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", "THU_TRUONG");
                txtTen_Kt.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", "KE_TOAN_TRUONG");
            }
            else
            {
                txtTen_Kd.Text = (string)dtCt.Rows[0]["Ten_Kd"];
                txtTen_Kt.Text = (string)dtCt.Rows[0]["Ten_Kt"];
            }

			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
		}

        private bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);

			Common.SetBufferValue("CHON_HOA_DON_IN", rdbHd_Tu_In.Checked ? "1": rdbHd_Dat_In.Checked ? "2": "3");
          

			//Cập nhật thông tin xống R80Ph
			string strSQLUpdate = "UPDATE " + strTable_Ph + " SET " +
					"Tk_Nh_B = @Tk_Nh_B, Ten_Nh_B = @Ten_Nh_B "+
					" WHERE Stt = @Stt";

			Hashtable ht = new Hashtable();
			ht["TK_NH_B"] = txtTk_Nh_B.Text;
			ht["TEN_NH_B"] = txtTen_NH_B.Text;
			

			ht["STT"] = drEdit["Stt"];

            //Cập nhật thông tin xống R80Ph
            string strSQLUpdateCt = "UPDATE " + strTable_Ct + " SET " +
                    "Ten_Kd = @Ten_Kd, Ten_Kt = @Ten_Kt " +
                    " WHERE Stt = @Stt";

            Hashtable ht1 = new Hashtable();
            ht1["TEN_KD"] = txtTen_Kd.Text;
            ht1["TEN_KT"] = txtTen_Kt.Text;


            ht1["STT"] = drEdit["Stt"];
            SQLExec.Execute(strSQLUpdateCt, ht1, CommandType.Text);
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
      
	}
}
