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

namespace RosyModule.Manufactory
{
	public partial class frmDLSX_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

        string strStt = string.Empty;
        public frmDLSX_Edit()
		{
			InitializeComponent();
           
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
            txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);

            numLength_Phoi.Validated += new EventHandler(Cal_Phoi_Validated);
            numLength_Phoi.Validated += new EventHandler(Cal_Phoi_Validated);
		}

        

      

        public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strStt)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strStt = strStt;

            Common.ScaterMemvar(this, ref drEdit);            
            BindingLanguage();
			LoadDicName();
            this.ShowDialog();
		}

		private void LoadDicName()
		{
            //txtMa_Kv_Sx.bUseAutoDropDown = true;
            //txtMa_Kv_Sx.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%' AND LEN(Ma_Vt) = 9";

            txtMa_Vt.bUseAutoDropDown = true;
            txtMa_Vt.strLookupKeyFilter = "Ma_Nh_Vt = 'PHOI'";

            txtMa_Vt_Sp.bUseAutoDropDown = true;
            txtMa_Vt_Sp.strLookupKeyFilter = "Ma_Nh_Vt = 'THEPCANDAI'";

            if (txtMa_Vt.Text.Trim() != string.Empty)
            {
                lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
            }
            else
                lbtTen_Vt.Text = string.Empty;

            if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
            {
                lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
            }
            else
                lbtTen_Vt_Sp.Text = string.Empty;
			
            //Log
            //string strCreate_Log = Common.Show_Log((string)drEdit["Create_Log"]);
            //string strLastModify_Log = Common.Show_Log((string)drEdit["LastModify_Log"]);
            //string strLog = string.Empty;
            //strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
            //strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";

           
		}

		public bool FormCheckValid()
		{
            //if (txtMa_Kv_Sx.Text.Trim() == string.Empty)
            //{
            //    Common.MsgCancel(Languages.GetLanguage("Ma_Vt") + " " + Languages.GetLanguage("Cannot_Empty"));
            //    return false;
            //}

            //if (txtTinh_Trang_Tb.Text.Trim() == string.Empty)
            //{
            //    Common.MsgCancel(Languages.GetLanguage("Barcode") + " " + Languages.GetLanguage("Cannot_Empty"));
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

       

			//Kiem tra cac du lieu can thiet
            drEdit["Stt"] = strStt;
            drEdit["Create_Log"] = string.Empty;
            drEdit["LastModify_Log"] = string.Empty;
            drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
            
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();


            return DataTool.SQLUpdate(enuNew_Edit, "R11DLSX", ref drEdit); //Luu xuong CSDL
           
		}

		#endregion

		#region Events

        void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Sp.Text.Trim();
            bool bRequire = true;

           
            DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "Ma_Nh_Vt = 'THEPCANDAI'");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Sp.Text = string.Empty;
                lbtTen_Vt_Sp.Text = string.Empty;
                numLength.Value = 0;
            }
            else
            {
                txtMa_Vt_Sp.Text = ((string)drLookup["Ma_Vt"]).Trim();
                lbtTen_Vt_Sp.Text = ((string)drLookup["Ten_Vt"]).Trim();
                numLength.Value = Convert.ToDouble(drLookup["Length"]);
            }
            
        }

        void txtMa_Vt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "Ma_Nh_Vt = 'PHOI'");

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

        void Cal_Phoi_Validated(object sender, EventArgs e)
        {
            DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", txtMa_Vt.Text);
            numSo_Luong_Phoi.Value = Math.Round(Convert.ToDouble(numSo_Cay_Phoi.Value) * Convert.ToDouble(drDmVt["Barem"]) * Convert.ToDouble(numLength_Phoi.Value), 0);
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
