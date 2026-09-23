using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmCSGia_Edit : RosySystem.Customize.frmEdit
	{
		
		public frmCSGia_Edit()
		{
			InitializeComponent();

			this.txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
            this.txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
            this.txtSo_QD.Validating += new CancelEventHandler(txtSo_QD_Validating);
           //this.txtMa_CTrinh.Validating += new CancelEventHandler(txtMa_CTrinh_Validating);
           	this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}


		public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strLoai_Cs)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			//txtMa_Vt.bUseAutoDropDown = true;
			//txtMa_Dt.bUseAutoDropDown = true;

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Vt.Text.Trim() != string.Empty)
			{
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
			}
			else
				lbtTen_Vt.Text = string.Empty;
		}

		private bool FormCheckValid()
		{
			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Vt") + " " +
						Languages.GetLanguage("Not_Null"));
				return false;
			}

			//if (txtMa_Dt.Text.Trim() == string.Empty)
			//{
			//    Common.MsgOk(Languages.GetLanguage("Ma_Dt") + " " +
			//            Languages.GetLanguage("Not_Null"));
			//    return false;
			//}			

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (drEdit.Table.Columns.Contains("Ten_Vt"))
				drEdit["Ten_Vt"] = lbtTen_Vt.Text;


			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R04CsGia", ref drEdit))
				return false;

			return true;
		}

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

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



        void txtMa_Kho_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Kho.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Kho.Text = string.Empty; 
                lbtTen_Kho.Text = string.Empty;
            }
            else
            {
                txtMa_Kho.Text = ((string)drLookup["Ma_Kho"]).Trim();
                lbtTen_Kho.Text = ((string)drLookup["Ten_Kho"]).Trim();
            }
        }

        void txtSo_QD_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtSo_QD.Text.Trim();
            bool bRequire = false;
            string strKeyValid = "";
            string strKeyFilter = "";


            DataRow drLookup = Lookup.ShowLookup("So_Qd", strValue, bRequire, strKeyFilter, strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtSo_QD.Text = string.Empty;
                //lbtTen__.Text = string.Empty;
            }
            else
            {
                txtSo_QD.Text = drLookup["So_QD"].ToString();
               // txtMa_CTrinh.Text = drLookup["Ma_CTrinh"].ToString();

            }

        //    lbtNotice.Text = GetDuCuoi(txtMa_Dt.Text, txtMa_Hd.Text, "131");
        //    this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
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
