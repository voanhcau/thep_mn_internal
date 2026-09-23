using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmTb_Edit : RosyList.frmEdit
	{		
		#region Phuong thuc

		public frmDmTb_Edit()
		{
			InitializeComponent();

			txtMa_Vt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại
			txtTen_Vt.Validating += new CancelEventHandler(txtCheckDuplicate); //Kiểm tra dữ liệu đã tồn tại

            txtTk_Vtu.Validating += new CancelEventHandler(txtTk_Vthu_Validating);
            txtTk_DThu.Validating += new CancelEventHandler(txtTk_Dthu_Validating);
            txtTk_Gvon.Validating += new CancelEventHandler(txtTk_Gvon_Validating);
            txtTk_Hbtl.Validating += new CancelEventHandler(txtTk_Hbtl_Validating);
            txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
            txtMa_Vt_Gt.Validating += new CancelEventHandler(txtMa_Vt_Gt_Validating);
            txtMa_Vt_Ap.Validating += new CancelEventHandler(txtMa_Vt_Ap_Validating);
            txtMa_Size.Validating += new CancelEventHandler(txtMa_Size_Validating);
            txtGrade_ID.Validating += new CancelEventHandler(txtGrade_ID_Validating);
			txtMa_Nh_Vt.Validating += new CancelEventHandler(txtMa_Nh_Vt_Validating);
            txtPhan_Loai_Sp.Validating += new CancelEventHandler(txtPhan_Loai_Sp_Validating);
            txtMa_Vt.TextChanged += new EventHandler(txtMa_Vt_TextChanged);
		}

       

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

            //if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            //{
            //    System.Collections.Hashtable htPara = new System.Collections.Hashtable();
            //    htPara["TABLENAME"] = "R81DMVT";
            //    htPara["COLUMNNAME"] = "MA_VT";
            //    htPara["CURRENTID"] = drEdit["Ma_Vt"].ToString();

            //    drEdit["Ma_Vt"] = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
            //}

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            //txtMa_Vt_Ap.bUseAutoDropDown = true;
            //Ma_Nh_Vt
            if (txtMa_Nh_Vt.Text.Trim() != string.Empty)
            {
                lbtTen_Nh_Vt.Text = DataTool.SQLGetNameByCode("R81DmNhVt", "Ma_Nh_Vt", "Ten_Nh_Vt", txtMa_Nh_Vt.Text.Trim());
            }
            else
                lbtTen_Nh_Vt.Text = string.Empty;

            //Tk_Vt
            if (txtTk_Vtu.Text.Trim() != string.Empty)
            {
                lbtTen_Tk_Vtu.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk_Vtu.Text.Trim());
            }
            else
                lbtTen_Tk_Vtu.Text = string.Empty;

            //Tk_Gv
            if (txtTk_Gvon.Text.Trim() != string.Empty)
            {
                lbtTen_Tk_Gvon.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk_Gvon.Text.Trim());
            }
            else
                lbtTen_Tk_Gvon.Text = string.Empty;

            //Tk_Dt
            if (txtTk_DThu.Text.Trim() != string.Empty)
            {
                lbtTen_Tk_DThu.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk_DThu.Text.Trim());
            }
            else
                lbtTen_Tk_DThu.Text = string.Empty;

            //Tk_HbTl
            if (txtTk_Hbtl.Text.Trim() != string.Empty)
            {
                lbtTen_Tk_Hbtl.Text = DataTool.SQLGetNameByCode("R81DMTK", "Tk", "Ten_Tk", txtTk_Hbtl.Text.Trim());
            }
            else
                lbtTen_Tk_Hbtl.Text = string.Empty;

            //Ma_Sp
            if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
            {
                lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
            }
            else
                lbtTen_Vt_Sp.Text = string.Empty;
            //Ma_Vt_Gt
            if (txtMa_Vt_Gt.Text.Trim() != string.Empty)
            {
                lbtTen_Vt_Gt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Gt.Text.Trim());
            }
            else
                lbtTen_Vt_Gt.Text = string.Empty;

            //Ma_Vt_Ap
            if (txtMa_Vt_Ap.Text.Trim() != string.Empty)
            {
                lbtTen_Vt_Ap.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Ap.Text.Trim());
            }
            else
                lbtTen_Vt_Ap.Text = string.Empty;

            if (txtPhan_Loai_Sp.Text.Trim() != string.Empty)
                lbtPhan_Loai_Sp.Text = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", txtPhan_Loai_Sp.Text.Trim(), "TYPE = 'PHAN_LOAI_SP'");
            else
                lbtPhan_Loai_Sp.Text = string.Empty;
		}

        void txtMa_Vt_TextChanged(object sender, EventArgs e)
        {
            if (enuNew_Edit == enuEdit.New)
            {
                txtMa_Vt_Sp.Text = txtMa_Vt.Text;
                txtMa_Vt_Gt.Text = txtMa_Vt.Text;
            }
        }
		public override bool FormCheckValid()
		{
			bool bvalid = true;
			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Sp") + " " +
								Languages.GetLanguage("Not_Null"));

				return false;
			}			

			if (txtTen_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ten_Sp") + " " +
							Languages.GetLanguage("Not_Null"));

				return false;
			}

			if (txtMa_Nh_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Nh_Vt") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DmVt", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("MA_VT", drEdit);

			return true;
		}
		#endregion 

		#region Su kien

		void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DmVt"))
				e.Cancel = true;
		}

        private void txtTk_Vthu_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_Vtu.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, null, "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk_Vtu.Text = string.Empty;
                lbtTen_Tk_Vtu.Text = string.Empty;
            }
            else
            {
                txtTk_Vtu.Text = ((string)drLookup["Tk"]).Trim();
                lbtTen_Tk_Vtu.Text = ((string)drLookup["Ten_Tk"]).Trim();
            }
        }
        private void txtTk_Dthu_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_DThu.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, null, "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk_DThu.Text = string.Empty;
                lbtTen_Tk_DThu.Text = string.Empty;
            }
            else
            {
                txtTk_DThu.Text = ((string)drLookup["Tk"]).Trim();
                lbtTen_Tk_DThu.Text = ((string)drLookup["Ten_Tk"]).Trim();
            }
        }

        private void txtTk_Gvon_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_Gvon.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, null, "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk_Gvon.Text = string.Empty;
                lbtTen_Tk_Gvon.Text = string.Empty;
            }
            else
            {
                txtTk_Gvon.Text = ((string)drLookup["Tk"]).Trim();
                lbtTen_Tk_Gvon.Text = ((string)drLookup["Ten_Tk"]).Trim();
            }
        }
        private void txtTk_Hbtl_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtTk_Hbtl.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, null, "Tk_Cuoi = 1");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtTk_Hbtl.Text = string.Empty;
                lbtTen_Tk_Hbtl.Text = string.Empty;
            }
            else
            {
                txtTk_Hbtl.Text = ((string)drLookup["Tk"]).Trim();
                lbtTen_Tk_Hbtl.Text = ((string)drLookup["Ten_Tk"]).Trim();
            }
        }

        private void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Sp.Text.Trim();
            bool bRequire = true;

            if (txtMa_Vt.Text != txtMa_Vt_Sp.Text)
            {
                DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, null);

                if (bRequire && drLookup == null)
                    e.Cancel = true;

                if (drLookup == null)
                {
                    txtMa_Vt_Sp.Text = string.Empty;
                    lbtTen_Vt_Sp.Text = string.Empty;
                }
                else
                {
                    txtMa_Vt_Sp.Text = ((string)drLookup["Ma_Vt"]).Trim();
                    lbtTen_Vt_Sp.Text = ((string)drLookup["Ten_Vt"]).Trim();
                }
            }
        }
        private void txtMa_Vt_Gt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Gt.Text.Trim();
            bool bRequire = true;

            if (txtMa_Vt_Gt.Text != txtMa_Vt_Gt.Text)
            {
                DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, null);

                if (bRequire && drLookup == null)
                    e.Cancel = true;

                if (drLookup == null)
                {
                    txtMa_Vt_Gt.Text = string.Empty;
                    lbtTen_Vt_Gt.Text = string.Empty;
                }
                else
                {
                    txtMa_Vt_Gt.Text = ((string)drLookup["Ma_Vt"]).Trim();
                    lbtTen_Vt_Gt.Text = ((string)drLookup["Ten_Vt"]).Trim();
                }
            }
        }
        void txtGrade_ID_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtGrade_ID.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Grade_ID", strValue, bRequire, string.Empty);
            if (drLookup == null && bRequire)
                e.Cancel = true;

            if (drLookup == null)
                txtGrade_ID.Text = string.Empty;
            else
                txtGrade_ID.Text = (string)drLookup["Grade_ID"];
        }

        void txtMa_Size_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Size.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Size", strValue, bRequire, string.Empty);
            if (drLookup == null && bRequire)
                e.Cancel = true;

            if (drLookup == null)
                txtMa_Size.Text = string.Empty;
            else
                txtMa_Size.Text = (string)drLookup["Ma_Size"];
        }
        void txtMa_Vt_Ap_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Ap.Text.Trim();
            string strFilter = "Ma_Nh_Vt= 'VTAPGIA'";
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, strFilter, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Ap.Text = string.Empty;
            }
            else
            {
                txtMa_Vt_Ap.Text = ((string)drLookup["Ma_Vt"]).Trim();
            }
        }
        void txtPhan_Loai_Sp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtPhan_Loai_Sp.Text.Trim();
            bool bRequire = false;

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "PHAN_LOAI_SP");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'PHAN_LOAI_SP'", "", htField);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtPhan_Loai_Sp.Text = string.Empty;
                lbtPhan_Loai_Sp.Text = string.Empty;
            }
            else
            {
                txtPhan_Loai_Sp.Text = drLookup["Type_ID"].ToString();
                lbtPhan_Loai_Sp.Text = drLookup["Type_Name"].ToString();
            }
        }
		private void txtMa_Nh_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Vt.Text.Trim();
			bool bRequire = true;

			System.Collections.Hashtable htField = new System.Collections.Hashtable();
			htField.Add("bIs_Vt_Sp", false);

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Vt", strValue, bRequire, "Loai_Nh_Vt IN ('SP')", "Nh_Cuoi = 1", htField);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Vt.Text = string.Empty;
				lbtTen_Nh_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Vt.Text = ((string)drLookup["Ma_Nh_Vt"]).Trim();
				lbtTen_Nh_Vt.Text = ((string)drLookup["Ten_Nh_Vt"]).Trim();
			}
		}

		#endregion
	
	}
}