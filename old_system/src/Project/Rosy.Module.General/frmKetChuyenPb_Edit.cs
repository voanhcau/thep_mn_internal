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
using RosyList;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyModule.General
{
    public partial class frmKetChuyenPb_Edit : RosySystem.Customize.frmEdit
	{		

        #region Phuong thuc

		public frmKetChuyenPb_Edit()
		{
			InitializeComponent();

            txtTk.Validating += new CancelEventHandler(txtTk_Validating);
            txtTk_Du_Den.Validating += new CancelEventHandler(txtTk_Du_Den_Validating);

            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

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
            if (txtTk.Text.Trim() != string.Empty)
            {
                lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk.Text.Trim());
            }
            else
                lbtTen_Tk.Text = string.Empty;

            if (txtTk_Du_Den.Text.Trim() != string.Empty)
            {
                lbtTen_Tk_Du_Den.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk_Du_Den.Text.Trim());
            }
            else
                lbtTen_Tk.Text = string.Empty;
		}

		public bool FormCheckValid()
        {
            bool bvalid = true ;            

            if (txtTk.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Tk") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }

            if (txtTk_Du_Den.Text.Trim() == string.Empty)
            {
                Common.MsgOk(Languages.GetLanguage("Tk_Du_Den") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R80KETCHUYENPB", ref drEdit))
				return false;			

			return true;
		}
        #endregion

        void txtTk_Du_Den_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_Du_Den.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk_Du_Den.Text = string.Empty;
            }
            else
            {
                txtTk_Du_Den.Text = drLookup["Tk"].ToString();
                lbtTen_Tk_Du_Den.Text = drLookup["Ten_Tk"].ToString();
            }
        }

        void txtTk_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk.Text = string.Empty;
            }
            else
            {
                txtTk.Text = drLookup["Tk"].ToString();
                lbtTen_Tk.Text = drLookup["Ten_Tk"].ToString();
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

	}
}