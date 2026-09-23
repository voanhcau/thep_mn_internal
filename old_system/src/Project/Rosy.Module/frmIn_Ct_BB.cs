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
	public partial class frmIn_Ct_BB : RosySystem.Customize.frmEdit
	{
		public frmIn_Ct_BB()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

		public void Load(DataRow drViewPh)
		{
			this.drEdit = drViewPh;
            
            Common.ScaterMemvar(this, ref drViewPh);
           
            //if (drEdit["Ten_Dv_A"].ToString() == "")
            //{
                if (!drEdit["So_Ct"].ToString().Contains("TCHC"))
                {
                    txtTen_DV_A.Text = "P.KTĐT";
                    txtDaiDien_KTCD.Text = Parameters.GetParaValue("THUKHOVTPT").ToString();
                }
                else
                {
                    txtTen_DV_A.Text = "P.TCHC";
                    txtDaiDien_KTCD.Text = Parameters.GetParaValue("THUKHOVPP").ToString();
                }
            //}
            if (txtDaiDien_KHVT.Text == string.Empty)
                txtDaiDien_KHVT.Text = SQLExec.ExecuteReturnValue("SELECT MAX(Ten_Dt) FROM R81DMDT" +
                        " WHERE MA_DT IN(SELECT Ma_Dt_CbNv from R04CTPO where Stt in (select Stt_Org FROM R04CTPO WHERE Stt= '" + drEdit["Stt"].ToString() + "'))").ToString();

            txtDaiDien_PBPX.Text = SQLExec.ExecuteReturnValue("SELECT MAX(Ong_Ba) FROM R04CTPO WHERE Stt= '" + drEdit["Stt"].ToString() + "'").ToString();

            BindingLanguage();
			LoadDicName();	

			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
		}

        private bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);

			
			//Cập nhật thông tin xống R80Ph
			string strSQLUpdate = "UPDATE R80PH SET " +
					"DaiDien_KTCD = @DaiDien_KTCD, DaiDien_KHVT = @DaiDien_KHVT, DaiDien_PbPx = @DaiDien_PbPx, NhanXet_Bb = @NhanXet_Bb, "+
                    "KienNghi_Bb = @KienNghi_Bb, Can_Cu = @Can_Cu, Ten_Dv_A = @Ten_Dv_A, Ten_Dv_B = @Ten_Dv_B" +
					" WHERE Stt = @Stt";

			Hashtable ht = new Hashtable();
			ht["DAIDIEN_KTCD"] = txtDaiDien_KTCD.Text;
			ht["DAIDIEN_KHVT"] = txtDaiDien_KHVT.Text;
			ht["DAIDIEN_PBPX"] = txtDaiDien_PBPX.Text;
			ht["NHANXET_BB"] = txtNhanXet_BB.Text;
			ht["KIENNGHI_BB"] = txtKienNghi_BB.Text;
			ht["CAN_CU"] = txtCan_Cu.Text;
            ht["TEN_DV_A"] = txtTen_DV_A.Text;
            ht["TEN_DV_B"] = txtTen_DV_B.Text;
			ht["STT"] = drEdit["Stt"];

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
      
	}
}
