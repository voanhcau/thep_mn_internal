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
	public partial class frmDLSXThep_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

        string strStt = string.Empty;
        DateTime dteNgay_Sx;
        string strCa;

        public frmDLSXThep_Edit()
		{
			InitializeComponent();
           
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

           
            txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
            txtLoai_Can.Validating += new CancelEventHandler(txtLoai_Can_Validating);
         
		}

        public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strStt, DateTime dteNgay_Sx, string strCa)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strStt = strStt;
            this.strCa = strCa;
            this.dteNgay_Sx = dteNgay_Sx;
        
            Common.ScaterMemvar(this, ref drEdit);            
            BindingLanguage();
			LoadDicName();

            dteGio_BD.Text = drEdit["Gio_BD"].ToString();
            dteGio_KT.Text = drEdit["Gio_KT"].ToString();

            if (enuNew_Edit == enuEdit.New)
            {
                dteGio_BD.Text = "00:00:00";
                dteGio_KT.Text = "00:00:00";
            }
            this.ShowDialog();
		}

		private void LoadDicName()
		{
            txtMa_Vt_Sp.bUseAutoDropDown = true;
            txtMa_Vt_Sp.strLookupKeyFilter = "Ma_Nh_Vt = 'THEPCANDAI'";
                      
            if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
            {
                lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
            }
            else
                lbtTen_Vt_Sp.Text = string.Empty;

            if (txtLoai_Can.Text.Trim() != string.Empty)
            {
                lbtLoaiCan.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtLoai_Can.Text.Trim());
            }
            else
                lbtLoaiCan.Text = string.Empty;
			
            //Log
            //string strCreate_Log = Common.Show_Log((string)drEdit["Create_Log"]);
            //string strLastModify_Log = Common.Show_Log((string)drEdit["LastModify_Log"]);
            //string strLog = string.Empty;
            //strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
            //strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";

           
		}

		public bool FormCheckValid()
		{
            if (txtLoai_Can.Text.Trim() == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Loan_Can") + " " + Languages.GetLanguage("Cannot_Empty"));
                return false;
            }

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


            drEdit["Gio_BD"] = dteGio_BD.Text;
            drEdit["Gio_KT"] = dteGio_KT.Text;
			//Kiem tra cac du lieu can thiet
            drEdit["Stt"] = strStt;
            //drEdit["Create_Log"] = string.Empty;
            //drEdit["LastModify_Log"] = string.Empty;
            drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
            
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();


            return DataTool.SQLUpdate(enuNew_Edit, "R11DLSX_NTHEP", ref drEdit); //Luu xuong CSDL
           
		}

		#endregion

		#region Events
        void txtLoai_Can_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtLoai_Can.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "LOAI_CAN");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'LOAI_CAN'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtLoai_Can.Text = string.Empty;
                lbtLoaiCan.Text = string.Empty;
            }
            else
            {
                txtLoai_Can.Text = drLookup["Type_ID"].ToString();
                lbtLoaiCan.Text = drLookup["Type_Name"].ToString();
            }
        }
        void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Sp.Text.Trim();
            bool bRequire = true;

           
            DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp_Sx", strValue, bRequire, "Loai_Sp = 'THEP' AND Ngay_Nhap = '"+ Library.DateToStr(dteNgay_Sx) +"' AND Ca = '" + strCa +"'");

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
                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", drLookup["Ma_Vt_Sp_Sx"].ToString());
                txtMa_Vt_Sp.Text = ((string)drLookup["Ma_Vt_Sp_Sx"]).Trim();
                lbtTen_Vt_Sp.Text = ((string)drDmVt["Ten_Vt"]).Trim();
                numLength.Value = Convert.ToDouble(drLookup["Length"]);
                numSo_Luong_Bo.Value = Convert.ToDouble(drLookup["So_Bo"]);
                numSo_Luong.Value = Convert.ToDouble(drLookup["So_Luong"]);

                numSo_Luong_CP.Value = Convert.ToDouble(drLookup["So_Luong_CP"]);
                numSo_Luong_CXL.Value = Convert.ToDouble(drLookup["So_Luong_CXL"]);
                numSo_Luong_PP.Value = Convert.ToDouble(drLookup["So_Luong_PP"]);
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
