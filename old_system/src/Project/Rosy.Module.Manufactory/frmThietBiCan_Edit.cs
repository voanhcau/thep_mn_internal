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
	public partial class frmThietBiCan_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

        string strStt = string.Empty;
        public frmThietBiCan_Edit()
		{
			InitializeComponent();

            txtMa_Nh_Tb.Validating += new CancelEventHandler(txtMa_Nh_Tb_Validating);
            //txtMa_Kv_Sx.Validating += new CancelEventHandler(txtMa_Vt_Validating);
            
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
            //txtMa_Kv_Sx.bUseAutoDropDown = true;
            //txtMa_Kv_Sx.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%' AND LEN(Ma_Vt) = 9";
            txtMa_Nh_Tb.bUseAutoDropDown = true;
            txtMa_Nh_Tb.strLookupKeyFilter = "Nh_Cuoi = 1";
          

			if (txtMa_Nh_Tb.Text.Trim() != string.Empty)
			{
                lbtTen_Nh_Tb.Text = DataTool.SQLGetNameByCode("R06DMNHTB", "Ma_Nh_Tb", "Ten_Nh_Tb", txtMa_Nh_Tb.Text.Trim());
			}
			else
                lbtTen_Nh_Tb.Text = string.Empty;

           
            ////Log
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


            return DataTool.SQLUpdate(enuNew_Edit, "R11THIETBI", ref drEdit); //Luu xuong CSDL
            
		}

		#endregion

		#region Events


        void txtMa_Nh_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_Tb.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Tb", strValue, bRequire, "Nh_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Nh_Tb.Text = string.Empty;
                lbtTen_Nh_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Nh_Tb.Text = drLookup["Ma_Nh_Tb"].ToString();
                lbtTen_Nh_Tb.Text = drLookup["Ten_Nh_Tb"].ToString();
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

            //if (this.enuNew_Edit == enuEdit.Edit && SQLExec.Execute()
                
                
            //    )
            //{
            //}
			
		}

       

       
	}
}
