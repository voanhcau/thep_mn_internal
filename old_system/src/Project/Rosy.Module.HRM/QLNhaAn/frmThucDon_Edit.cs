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
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.HRM
{
	public partial class frmThucDon_Edit : frmEdit
	{
		#region Phuong thuc
       
        public frmThucDon_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            txtMa_MAn_List.Validating += new CancelEventHandler(txtMa_MAn_Validating);
           
		}

        

        
    

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
          

			BindingLanguage();
			
          
            Common.ScaterMemvar(this, ref drEdit);

            if (enuNew_Edit == enuEdit.New)
            { 
                txtLoai.Text = txtMa_MAn_List.Text = txtTen_MAn_List.Text = "";
               
            }
           //if()
           //     dteNgay_Ct.Text = Library.DateToStr(DateTime.Now);
            LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
           
           
            
			
		}



    
        void txtMa_MAn_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_MAn_List.Text.Trim();
            bool bRequire = false;
            string strFilter = "Nh_Cuoi = 1";
            if (txtLoai.Text == "S")
                strFilter += " AND Ma_MAn_Parent LIKE '%S%' OR Ma_MAn IN ('R14','R15','R16','R17','R18')";
            else
                strFilter += " AND Ma_MAn_Parent NOT LIKE '%S%'";

            DataRow drLookup = Lookup.ShowMultiLookup("Ma_MAn", strValue, bRequire,strFilter,"");
            
            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_MAn_List.Text = string.Empty;
               

            }
            else
            {
                txtMa_MAn_List.Text = drLookup["MultiSelectValue"].ToString();
                txtTen_MAn_List.Text = SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetTenMonAn('" + drLookup["MultiSelectValue"].ToString() + "')").ToString();
            }
        }
    
      
		public bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_MAn_List.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_MAn") + " " +
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



            if (enuNew_Edit == enuEdit.New)
            {
               
                drEdit["Create_Log"] = Common.GetCurrent_Log();
               
            }
            else if (enuNew_Edit == enuEdit.Edit)
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R09THUCDON", ref drEdit))
				return false;

			return true;
		}
		#endregion

		#region Su kien
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
			isAccept = false;
			this.Close();
		}
		#endregion
	}
}
