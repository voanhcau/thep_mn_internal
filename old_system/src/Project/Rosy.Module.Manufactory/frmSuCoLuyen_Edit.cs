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
	public partial class frmSuCoLuyen_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

        string strStt = string.Empty;
        public frmSuCoLuyen_Edit()
		{
			InitializeComponent();


            txtMa_Su_Co.Validating += new CancelEventHandler(txtMa_Su_Co_Validating);
         
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

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

            txtMa_Su_Co.bUseAutoDropDown = true;
            if (txtMa_Su_Co.Text.Trim() != string.Empty)
            {
                lbtTen_Su_Co.Text = DataTool.SQLGetNameByCode("R81DMSUCO", "Ma_Su_Co", "Ten_Su_Co", txtMa_Su_Co.Text.Trim());
            }
            else
                lbtTen_Su_Co.Text = string.Empty;

           
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
            drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();


            return DataTool.SQLUpdate(enuNew_Edit, "R11SUCOLUYEN", ref drEdit); //Luu xuong CSDL
           
		}

		#endregion

		#region Events

        void txtMa_Su_Co_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Su_Co.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Su_Co", strValue, bRequire, "LOAI_SU_CO = 'LUYEN'", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Su_Co.Text = string.Empty;
                lbtTen_Su_Co.Text = string.Empty;
            }
            else
            {
                txtMa_Su_Co.Text = drLookup["Ma_Su_Co"].ToString();
                lbtTen_Su_Co.Text = drLookup["Ten_Su_Co"].ToString();
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
