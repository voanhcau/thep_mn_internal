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

namespace RosyModule.Receivable 
{
	public partial class frmDmCkCt_Edit : frmEdit
	{
		#region Phuong thuc

        public frmDmCkCt_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            btMa_Dt.Click += new EventHandler(btMa_Dt_Click);
            btNot_Ma_Dt.Click += new EventHandler(btNot_Ma_Dt_Click);
            btMa_Kho.Click += new EventHandler(btMa_Kho_Click);
            btGrade_ID.Click += new EventHandler(btGrade_ID_Click);
          
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
            if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMQDCT", ref drEdit))
				return false;

			return true;
		}
		#endregion

		#region Su kien
        void btGrade_ID_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;

           

            DataRow drLookup = Lookup.ShowMultiLookup("Grade_ID", txtGrade_ID_List.Text, bRequire, "Ngay_End = '19000101'", "");

            if (drLookup == null)
            {
                txtGrade_ID_List.Text = string.Empty;
            }
            else
            {
                txtGrade_ID_List.Text = drLookup["MultiSelectValue"].ToString();
            }
        }

        void btMa_Kho_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;



            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Kho", txtMa_Kho_List.Text, bRequire, "Ma_Kho LIKE '04%' OR Ma_Kho LIKE '05%' OR Ma_Kho LIKE '06%' OR Ma_Kho LIKE '08%'", "");

            if (drLookup == null)
            {
                txtMa_Kho_List.Text = string.Empty;
            }
            else
            {
                txtMa_Kho_List.Text = drLookup["MultiSelectValue"].ToString();
            }
        }
        void btNot_Ma_Dt_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;



            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Dt", txtNot_Ma_Dt_List.Text, bRequire, "Tk_Cn LIKE '131%'", "");

            if (drLookup == null)
            {
                txtNot_Ma_Dt_List.Text = string.Empty;
            }
            else
            {
                txtNot_Ma_Dt_List.Text = drLookup["MultiSelectValue"].ToString();
            }
        }

        void btMa_Dt_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;



            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Dt", txtMa_Dt_List.Text, bRequire, "Tk_Cn LIKE '131%'", "");

            if (drLookup == null)
            {
                txtMa_Dt_List.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_List.Text = drLookup["MultiSelectValue"].ToString();
            }
        }
        //void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        //{
        //    string strValue = txtMa_Dt_List.Text.Trim();
        //    bool bRequi = true;

        //    DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequi, string.Empty);

        //    if (bRequi && drLookup == null)
        //        e.Cancel = true;

        //    if (drLookup == null)
        //    {
        //        txtMa_Dt_List.Text = string.Empty;
        //        //lbtTen_Bp.Text = string.Empty;
        //    }
        //    else
        //    {
        //        txtMa_Dt_List.Text = (string)drLookup["Ma_Bp"];
        //        //lbtTen_Bp.Text = (string)drLookup["Ten_Bp"];
        //    }
        //}
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
