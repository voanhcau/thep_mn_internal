using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Public;

namespace RosyModule.ScaleBarcode
{
	public partial class frmCanhBaoCan : RosySystem.Customize.frmEdit
	{
        public frmCanhBaoCan()
        {
            InitializeComponent();

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            //this.txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
        }

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;

            this.FillData();

			Common.ScaterMemvar(this, ref drEdit);
			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
				
		}

        private void FillData()
        {
            
        }

        private void LoadDicName()
        {
            
        }

       

		private void btAccept_Click(object sender, EventArgs e)
		{
			//Common.GatherMemvar(this, ref drEdit);
            if (txtGhi_Chu_CBCan.Text == "")
            { Common.MsgOk("Phải nhập nội dung mới được lưu."); return; }
            else
                SQLExec.Execute("UPDATE R80PH_SCALE SET Ghi_Chu_CBCan = '" + txtGhi_Chu_CBCan.Text + "' WHERE Stt = '" + drEdit["Stt"].ToString() + "'");
			isAccept = true;
			this.Close();

		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

        //private void lbNum_Lot_Click(object sender, EventArgs e)
        //{

        //}
	}
}
