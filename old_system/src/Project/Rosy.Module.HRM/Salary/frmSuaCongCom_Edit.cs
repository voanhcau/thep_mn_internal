using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Public;
using RosyList;

namespace RosyModule.Salary
{
	public partial class frmSuaCongCom_Edit : RosySystem.Customize.frmEdit
	{
        public frmSuaCongCom_Edit()
		{
			InitializeComponent();

		

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            cboLoai_CC.TextChanged += new EventHandler(cboLoai_CC_TextChanged);
		}

        

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            DataTable dtLoaiCC = Voucher.GetTinhTrangCong();

            cboLoai_CC.lstItem.BuildListView("Ma_CC:100,Ten_CC:200");
            cboLoai_CC.lstItem.DataSource = dtLoaiCC;
            cboLoai_CC.lstItem.Size = new Size(400, cboLoai_CC.lstItem.Items.Count * 20);
            cboLoai_CC.lstItem.GridLines = true;

            if (txtMa_Dt_CbNv.Text != string.Empty)
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text);
            else
                lbtTen_Dt_CbNv.Text = string.Empty;
		}
        void cboLoai_CC_TextChanged(object sender, EventArgs e)
        {
            DataRow drDmTTCCong = DataTool.SQLGetDataRowByID("R81DmTTCCong", "Ma_CC", cboLoai_CC.Text);
            if (drDmTTCCong != null)
            {
                //numAn_Sang_Truoc.Value = Convert.ToDouble(drDmTTCCong["An_Sang_Truoc"]);
                numAn_Sang.Value = Convert.ToDouble(drDmTTCCong["An_Sang"]);
                numAn_Trua.Value = Convert.ToDouble(drDmTTCCong["An_Trua"]);
                numAn_Chieu.Value = Convert.ToDouble(drDmTTCCong["An_Chieu"]);
                numAn_Khuya.Value = Convert.ToDouble(drDmTTCCong["An_Khuya"]);
                numAn_Khuya_Sau.Value = Convert.ToDouble(drDmTTCCong["An_Khuya_Sau"]);
                numAn_Sang_Sau.Value = Convert.ToDouble(drDmTTCCong["An_Sang_Sau"]);

            }
        }
		private bool CheckFormValid()
		{
			if (this.txtMa_Dt_CbNv.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Tn") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!this.CheckFormValid())
				return false;

            if (!DataTool.SQLUpdate(enuNew_Edit, "R10DSCBNVTHEOCA", ref drEdit))
				return false;

			//Doi ma
            //if (this.enuNew_Edit == enuEdit.Edit)
            //    DataTool.SQLChangeID("MA_TN", drEdit);

			return true;
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

	

	}
}
