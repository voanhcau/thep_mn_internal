using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.Payable
{
	public partial class frmBarcodePT_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

        public string strMa_Vt;

        public frmBarcodePT_Edit()
		{
			InitializeComponent();

		
            txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
            txtMa_VTri.Validating += new CancelEventHandler(txtMa_VTri_Validating);
          
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

 
		}

       
		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);            
            BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Vt.bUseAutoDropDown = true;
            txtMa_Vt.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%' AND LEN(Ma_Vt) = 9";

			if (txtMa_Vt.Text.Trim() != string.Empty)
			{
                lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
			}
			else
                lbtTen_Vt.Text = string.Empty;

			
            //Log
            string strCreate_Log = Common.Show_Log((string)drEdit["Create_Log"]);
            string strLastModify_Log = Common.Show_Log((string)drEdit["LastModify_Log"]);
            string strLog = string.Empty;
            strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
            strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";

           
		}

		public bool FormCheckValid()
		{
			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtBarcode.Text.Trim() == string.Empty)
			{
                Common.MsgCancel(Languages.GetLanguage("Barcode") + " " + Languages.GetLanguage("Cannot_Empty"));
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

           strMa_Vt = drEdit["Ma_Vt"].ToString();

			//Kiem tra cac du lieu can thiet
            drEdit["Create_Log"] = string.Empty;
            drEdit["LastModify_Log"] = string.Empty;
			drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
            return DataTool.SQLUpdate(enuNew_Edit, "R81DMBARCODEPT", ref drEdit);
		}

		#endregion

		#region Events
        void txtMa_VTri_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_VTri.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_VTri", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_VTri.Text = string.Empty;
                lbtTen_VTri.Text = string.Empty;
            }
            else
            {
                txtMa_VTri.Text = drLookup["Type_ID"].ToString();
                lbtTen_VTri.Text = drLookup["Type_Name"].ToString();
            }
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
                txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
                lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
            }
        }

        

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
			this.isAccept = false;
			this.Close();
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
		}

       

       
	}
}
