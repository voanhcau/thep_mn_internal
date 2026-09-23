using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Public;

namespace RosyModule.Salary
{
	public partial class frmHsABC_Edit : RosySystem.Customize.frmEdit
	{
        
       
        public frmHsABC_Edit()
		{
			InitializeComponent();

			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Tn_Validating);
            txtHs_ABC.Validating += new CancelEventHandler(txtHs_ABC_Validating);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

     

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            
          
			
            Common.ScaterMemvar(this, ref drEdit);
        
            if (enuNew_Edit == enuEdit.New)
                dteNgay_Ap.Text = Library.DateToStr(DateTime.Now);

            
			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Dt_CbNv.Text != string.Empty)
			{
				DataRow drDmTn = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt_CbNv.Text);

				if (drDmTn != null)
				{
					lbtTen_Dt_CbNv.Text = (string)drDmTn["Ten_Dt"];
				}
			}
			else
			{
				lbtTen_Dt_CbNv.Text = string.Empty;
				
			}
		}

		private bool CheckFormValid()
		{
			if (this.txtMa_Dt_CbNv.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt_CbNv") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}
            if (this.txtHs_ABC.Text != "A" && txtGhi_Chu.Text == "")
            {
                Common.MsgCancel("Ghi chú không để trống!!!");
                return false;
            }

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

            //drEdit["Dvt"] = lbtDvt.Text;
            //drEdit["Ten_Tn"] = lbtTen_Tn.Text;

			if (!this.CheckFormValid())
				return false;

            if(DataTool.SQLCheckExist("R10HSABC",new string[]{"Ngay_Ap","Ma_Dt_CbNv"}, new object[]{dteNgay_Ap.Text, txtMa_Dt_CbNv.Text}))
                enuNew_Edit = enuEdit.Edit;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R10HSABC", ref drEdit))
				return false;

			return true;
		}
        void txtHs_ABC_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtHs_ABC.Text.Trim();
            bool bRequire = false;
            string strFilter = "Type='HS_ABC'";

           

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "HS_ABC");
            DataRow drLookup = Lookup.ShowLookup("HS_ABC", strValue, bRequire, strFilter, "", htField);
            
            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtHs_ABC.Text = string.Empty;
                lbtTen_Dt_CbNv.Text = string.Empty;

            }
            else
            {
                txtHs_ABC.Text = drLookup["Type_ID"].ToString();
                numHe_So.Value = Convert.ToDouble(drLookup["Type_Value"]);
            }
           
        }
		void txtMa_Tn_Validating(object sender, CancelEventArgs e)
		{
			if (!txtMa_Dt_CbNv.bTextChange)
				return;

			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			//Salary.frmDmTn frmLookup = new Salary.frmDmTn();
			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

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

        //private void rsLabel1_Click(object sender, EventArgs e)
        //{

        //}
	}
}
