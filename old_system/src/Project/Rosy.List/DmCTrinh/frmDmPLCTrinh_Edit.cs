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
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmPLCTrinh_Edit : RosySystem.Customize.frmEdit
	{	

        #region Phuong thuc

        public frmDmPLCTrinh_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            
		}

        

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
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
			if (txtMa_CTrinh.Text.Trim() != string.Empty)
			{
				lbTen_CTrinh.Text = DataTool.SQLGetNameByCode("R81DMCTRINH", "Ma_CTrinh", "Ten_CTrinh", txtMa_CTrinh.Text.Trim());
			}
			else
				lbTen_CTrinh.Text = string.Empty;

           
		}

		public bool FormCheckValid()
        {
            
            if (txtMa_PLCTrinh.Text.Trim() == string.Empty)
            {
                Common.MsgCancel(Languages.GetLanguage("Ma_CTrinh") + " " +
                              Languages.GetLanguage("Not_Null"));
                return false;
            }
            //if (dteNgay_PL.IsNull)
            //{
            //    Common.MsgCancel(Languages.GetLanguage("Ngay_PL") + " " +
            //                  Languages.GetLanguage("Not_Null"));

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

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DmPLCTrinh", ref drEdit))
				return false;

			return true;
		}

        #endregion

        #region Su kien

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

        #endregion		
	}
}