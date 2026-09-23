using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Public;

namespace RosyModule.HRM
{
	public partial class frmQLBL_Edit : frmEdit
	{
		#region Phuong thuc

        public frmQLBL_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
		}

      

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
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
            txtMa_Dt_CbNv.bUseAutoDropDown = true;

			//txtMa_Dt
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			else
				lbtTen_Dt_CbNv.Text = string.Empty;
		}

        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = false;
            string strFilter = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, strFilter);

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
		public bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtBac_Luong.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Bac_Luong") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

            if (txtBang_Luong.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Bang_Luong") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            if (numMuc_Luong.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Muc_Luong") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

			return bvalid;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R09QLBL", ref drEdit))
				return false;

			return true;
		}
		#endregion

		#region Su kien
		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
		#endregion
	}
}
