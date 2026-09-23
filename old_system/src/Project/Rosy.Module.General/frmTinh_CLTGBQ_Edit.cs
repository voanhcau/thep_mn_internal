using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Public;

namespace RosyModule.General
{
	public partial class frmTinh_CLTGBQ_Edit : RosySystem.Customize.frmEdit
    {
		public frmTinh_CLTGBQ_Edit()
        {
            InitializeComponent();

            txtTk.Validating += new CancelEventHandler(txtTk_Validating);

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
        }

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;			

			Common.ScaterMemvar(this, ref drEdit);
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//txtTk
			if (txtTk.Text.Trim() != string.Empty)
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk.Text.Trim());
			else
				lbtTen_Tk.Text = string.Empty;
		}

        void txtTk_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk.Text = string.Empty;
                lbtTen_Tk.Text = string.Empty;
            }
            else
            {
                txtTk.Text = drLookup["Tk"].ToString();
                lbtTen_Tk.Text = drLookup["Ten_Tk"].ToString();
            }
        }

		public bool FormCheckValid()
		{
			if (numSTt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Stt") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtTk.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Tk") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			return true;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;			

			if (!DataTool.SQLUpdate(this.enuNew_Edit, "R80CLTGBQ", ref drEdit))
				return false;

			return true;
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
