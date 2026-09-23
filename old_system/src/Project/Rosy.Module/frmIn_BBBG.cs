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
	public partial class frmIn_BBBG : RosySystem.Customize.frmEdit
	{
       

        public frmIn_BBBG()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

        public void Load()
        {
            //this.drEdit = drViewPh;

            //Common.ScaterMemvar(this, ref drViewPh);

            BindingLanguage();
            LoadDicName();

            this.ShowDialog();
        }

		public void Load(DataRow drViewPh, bool bReview)
		{
			this.drEdit = drViewPh;
            
			Common.ScaterMemvar(this, ref drViewPh);

          
   
			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
		}

      
		private void btAccept_Click(object sender, EventArgs e)
		{
            if (Save())
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

        bool Save()
        {
            Hashtable ht = new Hashtable();

            ht.Add("STT", drEdit["Stt"]);
            ht.Add("NGAY_BG", dteNgay_Bg.Text);
            ht.Add("NOI_BG", txtNoi_Bg.Text);
            ht.Add("TEN_DT_GIAO1", txtTen_Dt_Giao1.Text);
            ht.Add("TEN_DT_GIAO2", txtTen_Dt_Giao2.Text);
            ht.Add("TEN_DT_NHAN1", txtTen_Dt_Nhan1.Text);
            ht.Add("TEN_DT_NHAN2", txtTen_Dt_Nhan2.Text);

            ht.Add("CHUC_VU_GIAO1", txtChuc_Vu_Giao1.Text);
            ht.Add("CHUC_VU_GIAO2", txtChuc_Vu_Giao2.Text);
            ht.Add("CHUC_VU_NHAN1", txtChuc_Vu_Nhan1.Text);
            ht.Add("CHUC_VU_NHAN2", txtChuc_Vu_Nhan2.Text);

            SQLExec.Execute("UPDATE R06PH_BTTB SET Ngay_Bg = @Ngay_Bg, Noi_Bg = @Noi_Bg, Ten_Dt_Nhan1 = @Ten_Dt_Nhan1, Ten_Dt_Nhan2 = @Ten_Dt_Nhan2, Ten_Dt_Giao1 = @Ten_Dt_Giao1, Ten_Dt_Giao2 = @Ten_Dt_Giao2, " +
                    "Chuc_Vu_Nhan1 = @Chuc_Vu_Nhan1, Chuc_Vu_Nhan2 = @Chuc_Vu_Nhan2, Chuc_Vu_Giao1 = @Chuc_Vu_Giao1, Chuc_Vu_Giao2 = @Chuc_Vu_Giao2 WHERE Stt = @Stt", ht, CommandType.Text);

            return true;
        }
        //private void rdbList_TB_CheckedChanged(object sender, EventArgs e)
        //{

        //}
      
	}
}
