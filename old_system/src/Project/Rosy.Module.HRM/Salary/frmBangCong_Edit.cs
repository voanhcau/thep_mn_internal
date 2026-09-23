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
	public partial class frmBangCong_Edit : RosySystem.Customize.frmEdit
	{
        
        public frmBangCong_Edit()
		{
			InitializeComponent();

			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
			
            txtLoai_ABC.Validating += new CancelEventHandler(txtHS_ABC_Validating);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

       

       

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);
			
			if(txtMa_Bp.Text == "TPDV")
				txtMa_Bp.Text = SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R10BANGCONG WHERE Ident00 = " + drEdit["Ident00"]).ToString();

			txtMa_Bp_Ct.ReadOnly = true;

            BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Dt_CbNv.bUseAutoDropDown = true;
			if (txtMa_Dt_CbNv.Text != string.Empty)
			{
				
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			}
			else
			{
				lbtTen_Dt_CbNv.Text = string.Empty;
			
			}
			if (txtMa_Bp.Text != string.Empty)
			{

				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			}
			else
			{
				lbtTen_Bp.Text = string.Empty;

			}
			if (txtMa_Bp_Ct.Text != string.Empty)
			{

				lbtTen_Bp_Ct.Text = DataTool.SQLGetNameByCode("R81DMBPCT", "Ma_Bp_Ct", "Ten_Bp_Ct", txtMa_Bp_Ct.Text.Trim());
			}
			else
			{
				lbtTen_Bp_Ct.Text = string.Empty;

			}

		}

		private bool CheckFormValid()
		{
            //if (this.numThang.Value == 0)
            //{
            //    Common.MsgCancel(Languages.GetLanguage("So_Gio") + " " + Languages.GetLanguage("Not_Empty"));
            //    return false;
            //}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!this.CheckFormValid())
				return false;

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R10BANGCONG", ref drEdit))
				return false;

			return true;
		}
        void txtHS_ABC_Validating(object sender, CancelEventArgs e)
        {
            bool bRequire = true;
            string strFilter = "Type='HS_ABC'";

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "HS_ABC");
            DataRow drLookup = Lookup.ShowLookup("HS_ABC", txtLoai_ABC.Text, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                txtLoai_ABC.Text = string.Empty;
            }
            else
            {
                txtLoai_ABC.Text = drLookup["Type_ID"].ToString();
                numHs_Luong_Bp.Value = Convert.ToDouble(drLookup["Type_Value"]);
            }


        }
       
		void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
		{
			if (!txtMa_Dt_CbNv.bTextChange)
				return;

			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

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
        protected override void OnShown(EventArgs e)
        {
            //if (this.enuNew_Edit == enuEdit.Edit)
            //{
            //    DataTable dt = SQLExec.ExecuteReturnDt("SELECT * FROM R10CONGTANGCA WHERE Ident00 = " + drEdit["Ident00"] + "");
            //    DataRow dr = dt.Rows[0];
            //    if ((bool)dr["Duyet_Tp"])
            //        this.btgAccept.btAccept.Enabled = false;
            //}
        }
	}
}
