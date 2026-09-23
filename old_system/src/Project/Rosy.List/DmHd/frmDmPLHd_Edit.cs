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
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmPLHd_Edit : RosySystem.Customize.frmEdit
	{	

        #region Phuong thuc

		public frmDmPLHd_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
		}

        void txtMa_Vt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, null);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt.Text = string.Empty;
                lbtTen_Vt.Text = string.Empty;
            }
            else
            {
                txtMa_Vt.Text = ((string)drLookup["Ma_Vt"]).Trim();
                lbtTen_Vt.Text = ((string)drLookup["Ten_Vt"]).Trim();
            }
            
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
			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				lbTen_Hd.Text = DataTool.SQLGetNameByCode("R81DMHD", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			}
			else
				lbTen_Hd.Text = string.Empty;

            txtMa_Vt.bUseAutoDropDown = true;
		}

		public bool FormCheckValid()
        {
            if (txtMa_Hd.Text.Trim() == string.Empty)
            {
				Common.MsgCancel(Languages.GetLanguage("Ma_Hd") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }
            if (txtMa_Vt.Text.Trim() == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Ma_Vt") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            //if (dteNgay_PL.IsNull)
            //{
            //    Common.MsgCancel(Languages.GetLanguage("Ngay_PL") + " " +
            //                  Languages.GetLanguage("Not_Null"));

            //    return false;
            //}

            return true;
        }

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DmPLHd", ref drEdit))
				return false;

			return true;
		}

        #endregion

        #region Su kien

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

        #endregion		
	}
}