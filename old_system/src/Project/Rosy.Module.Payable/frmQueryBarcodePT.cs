using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.Payable
{
	public partial class frmQueryBarcodePT : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtInheritVoucher;
		BindingSource bdsInheritVoucher = new BindingSource();
		
		string strMa_Ct = string.Empty;
		frmVoucher_Edit frmVoucher_Edit;
		DataRow drCurrent, drDmCt_Current;
        DateTime dteNgay_Ct;
		public bool Is_Accept = false;

		#endregion

		#region Contructor

        public frmQueryBarcodePT()
		{
			InitializeComponent();

            //this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            //this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            //this.btRefresh.Click += new EventHandler(btRefresh_Click);
            //this.btSearch.Click += new EventHandler(btSearch_Click);
            //this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);

		
		}

		

		#endregion

		#region Method

		public void Load(frmVoucher_Edit frmVoucher_Edit)
		{
			
            
			this.frmVoucher_Edit = frmVoucher_Edit;
			this.strMa_Ct = (string)frmVoucher_Edit.strMa_Ct;
            DataRow drDmNvu = DataTool.SQLGetDataRowByID("R81DMNVU", "Ma_Nvu", frmVoucher_Edit.drEditPh["Ma_Nvu"].ToString());
            dteNgay_Ct = Convert.ToDateTime(Library.DateToStr(Element.sysNgay_Ct2));

            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            
			drDmCt_Current = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", frmVoucher_Edit.strMa_Ct.ToString());
            Build();
			FillData();
			BindingLanguage();


			this.ShowDialog();
		}
		public void Load(DataRow drHeader)
		{
			

		
		}
        void FillData()
        {
        }
        void Build()
        {
        }	
			
			

         
		bool FormCheckValid()
		{
			
			return true;
		}

		#endregion

		#region Event

		
		

		

		#endregion

        
	}
}
