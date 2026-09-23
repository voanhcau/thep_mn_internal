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
    public partial class frmDmNhTb_Edit : RosyList.frmEdit
    {

        #region Phuong thuc

		public frmDmNhTb_Edit()
		{
			InitializeComponent();

			txtMa_Nh_Tb.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Nh_Tb.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
            //txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			txtMa_Nh_Tb_Parent.Validating += new CancelEventHandler(txtMa_Nh_Tb_Cha_Validating);
		}

        //void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

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
			if (txtMa_Nh_Tb_Parent.Text.Trim() != string.Empty)
			{
				lbtTen_Nh_Tb_Parent.Text = DataTool.SQLGetNameByCode("R06DmNhTb", "Ma_Nh_Tb", "Ten_Nh_Tb", txtMa_Nh_Tb_Parent.Text.Trim());
			}
			else
				lbtTen_Nh_Tb_Parent.Text = string.Empty;

            //if (txtMa_Bp.Text.Trim() != string.Empty)
            //{
            //    lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DmBp", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            //}
            //else
            //    lbtTen_Bp.Text = string.Empty;
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtMa_Nh_Tb.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Tb") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;

            }			

			if (txtTen_Nh_Tb.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Nh_Tb") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;
			}

            if (txtMa_Nh_Tb.Text.Trim() == txtMa_Nh_Tb_Parent.Text.Trim())
            {
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Tb_Cha") + " " +
							  Languages.GetLanguage("Invalid"));
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R06DmNhTb", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("Ma_Nh_Tb", drEdit);

			return true;
		}
        #endregion

        #region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R06DmNhTb"))
				e.Cancel = true;
		}

		void txtMa_Nh_Tb_Cha_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Tb_Parent.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Tb", strValue, bRequire, "Nh_Cuoi = '0'", "Nh_Cuoi = '0'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Tb_Parent.Text = string.Empty;
				lbtTen_Nh_Tb_Parent.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Tb_Parent.Text = ((string)drLookup["Ma_Nh_Tb"]).Trim();
				lbtTen_Nh_Tb_Parent.Text = ((string)drLookup["Ten_Nh_Tb"]).Trim();
			}
        }

        #endregion
    }
}