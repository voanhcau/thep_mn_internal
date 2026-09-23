using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;
using RosyList;
using RosyModule;

namespace RosyModule.Receivable
{
	public partial class frmCKSL_Edit : RosySystem.Customize.frmEdit
	{
		#region Contructor


		public frmCKSL_Edit()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			
            //txtMa_Dt_List.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            //txtMa_Kho_List.Validating += new CancelEventHandler(txtMa_Kho_Validating);
            btMa_Kho.Click += new EventHandler(btMa_Kho_Click);
            btMa_Dt.Click += new EventHandler(btMa_Dt_Click);
		}

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;

			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			this.Init();
			this.LoadDicName();
			this.BindingLanguage();

			this.ShowDialog();
		}

		#endregion

		#region Phuong thuc

		private void Init()
		{
			

			
		}

		private void Ma_Tte_Show()
		{
			
		}

		private void LoadDicName()
		{
			
		}

		private void Tinh_Tien()
		{
			
		}

		private bool FormCheckValid()
		{
            if (txtSo_Qd_Ck.Text.Trim() == string.Empty)
            {
                Common.MsgOk("Số quyết định chiết khấu " +
                             Languages.GetLanguage("Cannot_Empty"));
                return false;
            }

			if (dteNgay_Begin.Text.Replace(" ", "") == "//")
			{
				Common.MsgOk(Languages.GetLanguage("Ngay_Ct") + " " +
							 Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

            if (dteNgay_End.Text.Replace(" ", "") == "//")
            {
                Common.MsgOk(Languages.GetLanguage("Ngay_Ct") + " " +
                             Languages.GetLanguage("Cannot_Empty"));
                return false;
            }

            //if (txtMa_Dt_List.Text.Trim() == string.Empty)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Ma_Dt") + " " +
            //                 Languages.GetLanguage("Cannot_Empty"));
            //    return false;
            //}
            //if (txtMa_Kho_List.Text.Trim() == string.Empty)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Ma_Kho") + " " +
            //                 Languages.GetLanguage("Cannot_Empty"));
            //    return false;
            //}
			

			if (txtDien_Giai.Text == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Dien_Giai") + " " + Languages.GetLanguage("Cannot_Empty"));

				return false;
			}

			return true;
		}

		private bool Save()
		{
			

			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			
			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();
            
            drEdit["Ma_Data"] = Element.sysMa_Data;
			
            //Kiem tra Valid CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R04CKSL", ref drEdit))
				return false;

//            //Doi Ma_Vt_Ts
//            if (this.enuNew_Edit == enuEdit.Edit && drEdit.HasVersion(DataRowVersion.Original) && drEdit["So_Qd_Ck"] != drEdit["So_Qd_Ck", DataRowVersion.Original])
//            {
//                string strSQL = @"
//							UPDATE R06CtTsHM SET So_Qd_Ck = '" + drEdit["So_Qd_Ck"].ToString() + @"' WHERE So_Qd_Ck = '" + drEdit["So_Qd_Ck", DataRowVersion.Original].ToString() +"'";

//                SQLExec.Execute(strSQL);
//            }

			return true;
		}

		#endregion

		#region Su kien

        void btMa_Kho_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = string.Empty;

            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Kho", txtMa_Kho_List.Text, bRequire, strFilter, "");

            if (drLookup == null)
            {
                txtMa_Kho_List.Text = string.Empty;
            }
            else
            {
                txtMa_Kho_List.Text = drLookup["MultiSelectValue"].ToString();
            }
        }
        void btMa_Dt_Click(object sender, EventArgs e)
        {
            bool bRequire = true;
            string strFilter = "Loai_Dt = '3' AND Ma_Dt IN (SELECT Ma_Dt FROM vw_DoanhThu WHERE Ngay_Ct BETWEEN '"+ dteNgay_Begin.Text +"' AND '"+ dteNgay_End.Text +"' GROUP BY Ma_Dt)";

            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Dt", txtMa_Kho_List.Text, bRequire, strFilter, "");

            if (drLookup == null)
            {
                txtMa_Dt_List.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_List.Text = drLookup["MultiSelectValue"].ToString();
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
			isAccept = false;
			this.Close();
		}

		

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
            string strFilter = txtMa_Dt_List.Text.Trim();
			bool bRequire = true;

            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Dt", txtMa_Kho_List.Text, bRequire, strFilter, "0=0");

            if (drLookup == null)
            {
                txtMa_Dt_List.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_List.Text = drLookup["MultiSelectValue"].ToString();
            }
		}
        void txtMa_Kho_Validating(object sender, CancelEventArgs e)
        {
            string strFilter = txtMa_Kho_List.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowMultiLookup("Ma_Kho", txtMa_Kho_List.Text, bRequire, strFilter, "");

            if (drLookup == null)
            {
                txtMa_Kho_List.Text = string.Empty;
            }
            else
            {
                txtMa_Kho_List.Text = drLookup["MultiSelectValue"].ToString();
            }
        }

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

		}
	}
}