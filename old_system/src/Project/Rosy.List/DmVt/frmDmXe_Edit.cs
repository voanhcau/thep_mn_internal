using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
    public partial class frmDmXe_Edit : RosyList.frmEdit
    {

        #region Phuong thuc

		public frmDmXe_Edit()
		{
			InitializeComponent();

            //txtMa_Xe.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
            //txtTen_Xe.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
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
			//txtMa_Bp
			if (txtMa_Bp.Text.Trim() != string.Empty)
			{
				lblTen_Bp.Text = DataTool.SQLGetNameByCode("R81DmBp", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			}
			else
				lblTen_Bp.Text = string.Empty;

			//txtMa_Vt
			if (txtMa_Vt.Text.Trim() != string.Empty)
			{
				lblTen_Vt.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
			}
			else
				lblTen_Vt.Text = string.Empty;
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Xe.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Xe") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;

            }
            if (!DataTool.SQLCheckExist("R06DMTB", new string[] { "Ma_Tb" }, new object[] { txtMa_Xe.Text }))
            {
                Common.MsgOk("Vui lòng chọn mã thiết bị tương ứng với mã xe");

                return false;
            }
			if (txtTen_Xe.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Xe") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;
			}

  

            return bvalid;
        }

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMXE", ref drEdit))
				return false;

		

			return true;
		}

		#endregion

        #region Su kien

        //void txtCheckDuplicate(object sender, CancelEventArgs e)
        //{
        //    if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMCUMTB"))
        //        e.Cancel = true;
        //}

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text;
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lblTen_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lblTen_Vt.Text = drLookup["Ten_Vt"].ToString();
			}
		}

		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text;
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (drLookup == null)
			{
				txtMa_Bp.Text = string.Empty;
				lblTen_Bp.Text = string.Empty;
			}
			else
			{
				txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
				lblTen_Bp.Text = drLookup["Ten_Bp"].ToString();
			}
		}
	
        #endregion

      
    }
}