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
	public partial class frmVTPTTD_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods
        
        public frmVTPTTD_Edit()
		{
			InitializeComponent();

			
		
           
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            this.KeyDown += new KeyEventHandler(frmDnTu_Edit_KeyDown);
            btMa_Vt.Click += new EventHandler(btMa_Vt_Click);
            
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
			
            //Log
            string strLog = string.Empty;
            if (enuNew_Edit == enuEdit.Edit)
            {
                string strCreate_Log = Common.Show_Log((string)drEdit["Create_Log"]);
                string strLastModify_Log = Common.Show_Log((string)drEdit["LastModify_Log"]);
                
                strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
                strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";
            }
            this.lblLog.Text = strLog;
		}

		public bool FormCheckValid()
		{
			if (txtMa_Vt_Td.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt_Td") + " " + Languages.GetLanguage("Cannot_Empty"));
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

         
		
			drEdit["Ma_Data"] = Element.sysMa_DvCs;
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["LastModify_Log"] = string.Empty;
            }
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
            return DataTool.SQLUpdate(enuNew_Edit, "R81DMVTTD", ref drEdit);
		}

		#endregion

		#region Events

        void btMa_Vt_Click(object sender, EventArgs e)
        {
           bool bRequire = true;
			string strFilter = string.Empty;
            strFilter = "Ma_Vt LIKE 'C%' OR Ma_Vt LIKE 'D%' OR Ma_Vt LIKE 'E%' OR Ma_Vt LIKE 'F%' OR Ma_Vt LIKE 'G%' OR Ma_Vt LIKE 'H%' OR Ma_Vt LIKE 'I%' OR Ma_Vt LIKE 'K%'";

            frmQuickLookup_Customize frmLookup = new frmQuickLookup_Customize();
            //frmQuickLookup frmLookup = new frmQuickLookup();
            frmLookup.bMultiLookup = true;

            //Hien Form Lookup
            frmLookup.isLookup = true;
            frmLookup.strLookupColumn = "Ma_Vt";
            frmLookup.strLookupValue = txtMa_Vt_List.Text;
            frmLookup.strLookupKeyFilter = strFilter;
            frmLookup.strLookupKeyValid = "";

            frmLookup.LoadLookup();




            //DataRow drLookup = Lookup.ShowMultiLookup("Ma_Kho", txtMa_Kho_List.Text, bRequire, strFilter, "");

            if (frmLookup.strColumnSelect == null)
            {
                txtMa_Vt_List.Text = string.Empty;
            }
            else
            {
                txtMa_Vt_List.Text = frmLookup.strColumnSelect;
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

       

        void frmDnTu_Edit_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
	}
}
