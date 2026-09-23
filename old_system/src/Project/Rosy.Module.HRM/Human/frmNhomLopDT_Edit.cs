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

namespace RosyModule.HRM
{
	public partial class frmNhomLopDT_Edit : frmEdit
	{
		#region Phuong thuc

        public frmNhomLopDT_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Nh_LopDT_Parent.Validating += new CancelEventHandler(txtMa_Nh_LopDT_Parent_Validating);
		}

        

      

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
           
		}

     
		public bool FormCheckValid()
		{
			bool bvalid = true;
			

            

			return bvalid;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			//Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMNHLOPDT", ref drEdit))
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

        void txtMa_Nh_LopDT_Parent_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_LopDT_Parent.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Nh_LopDt", strValue, bRequire, "Nh_Cuoi = '0'");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Nh_LopDT_Parent.Text = string.Empty;
                
            }
            else
            {
                txtMa_Nh_LopDT_Parent.Text = ((string)drLookup["Ma_Nh_LopDt"]).Trim();
               
            }
        }
		#endregion
	}
}
