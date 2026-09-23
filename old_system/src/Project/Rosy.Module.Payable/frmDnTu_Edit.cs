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

namespace RosyModule.Payable
{
	public partial class frmDnTu_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods
        string strMa_Hd;
		public frmDnTu_Edit()
		{
			InitializeComponent();

			
			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
            btInherit.Click += new EventHandler(btInherit_Click);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            this.KeyDown += new KeyEventHandler(frmDnTu_Edit_KeyDown);
		}

       

		public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strMa_Hd)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strMa_Hd = strMa_Hd;

            Common.ScaterMemvar(this, ref drEdit);
            
            if (enuNew_Edit == enuEdit.New)
            {
                txtMa_Dt_CbNv.Text = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
                string strMa_Dt = (string)SQLExec.ExecuteReturnValue("SELECT Member_Group_ID FROM R00MEMBERGROUP WHERE Member_ID = '" + Element.sysUser_Id + "' ");
                string strTen_Dt_Vc = (string)SQLExec.ExecuteReturnValue("SELECT Ten_Dt_Vc FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt + "' ");
                string strSo_Ct_Curent = (string)SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(So_Ct),'') FROM R04CTDNTU WHERE LEFT(So_Ct,4) = '" + strTen_Dt_Vc + "'");
                string strMa_Bp = (string)SQLExec.ExecuteReturnValue("SELECT MIN(Member_Group_ID) FROM R00MEMBERGROUP WHERE Member_Id = '" + Element.sysUser_Id + "'");
              
                Hashtable htPara = new Hashtable();
                htPara.Add("TABLENAME", "R04CTDNTU");
                htPara.Add("COLUMNNAME", "SO_CT");
                htPara.Add("CURRENTID", strSo_Ct_Curent);
                htPara.Add("KEY", " 0 = 0 AND Ma_Bp = '" + strMa_Bp + "'");
                htPara.Add("PREFIXLEN", 4);
                htPara.Add("SUFFIXLEN", 3);


                if (strSo_Ct_Curent == "")
                    txtSo_Ct.Text = strTen_Dt_Vc + "001/" + DateTime.Now.Month.ToString();
                else
                    txtSo_Ct.Text = (string)SQLExec.ExecuteReturnValue("sp_GetNewID", htPara, CommandType.StoredProcedure);
                
                dteNgay_Ct.Text = DateTime.Now.ToString();
                txtMa_Bp.Text = (string)SQLExec.ExecuteReturnValue("SELECT MIN(Member_Group_ID) FROM R00MEMBERGROUP WHERE Member_Id = '" + Element.sysUser_Id + "'");
                numTien.Value = 0;
                numTien_Da_Tt.Value = 0;
                numTTien.Value = 0;
                txtLoai_Ct.Text = "CK";
            }
            else
            {
                txtInherit.Text = drEdit["So_Ct_Org"].ToString();
            }

            txtMa_Dt.bUseAutoDropDown = true;
            txtMa_Bp.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Hd.bUseAutoDropDown = true;

            txtMa_Tte.InputMask = (string)RosySystem.Library.Parameters.GetParaValue("MA_TTE_LIST");
            
            
            BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Bp.Text.Trim() != string.Empty)
			{
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			}
			else
                lbtTen_Bp.Text = string.Empty;

			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
			{
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			}
			else
			{
				lbtTen_Dt_CbNv.Text = string.Empty;
			}

            if (txtMa_Dt.Text.Trim() != string.Empty)
            {
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            }
            else
            {
                lbtTen_Dt.Text = string.Empty;
            }
            if (txtMa_Hd.Text.Trim() != string.Empty)
            {
                lbtTen_Hd.Text = DataTool.SQLGetNameByCode("R81DmHd", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
            }
            else
            {
                lbtTen_Hd.Text = string.Empty;
            }
            //Log
            string strLog = string.Empty;
            if (enuNew_Edit == enuEdit.Edit)
            {
                string strCreate_Log = Common.Show_Log((string)drEdit["Create_Log"]);
                string strLastModify_Log = Common.Show_Log((string)drEdit["LastModify_Log"]);
                
                strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
                strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";
            }
            this.lblLog.Text = strLog;
		}

		public bool FormCheckValid()
		{
			if (txtMa_Bp.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Bp") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (txtMa_Dt_CbNv.Text.Trim() == string.Empty)
			{
                Common.MsgCancel(Languages.GetLanguage("Ma_Dt_CbNv") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}

			if (dteNgay_Ct.IsNull)
			{
				Common.MsgCancel(Languages.GetLanguage("Date") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}
            if (numTien.Value == 0)
            {
                Common.MsgCancel(Languages.GetLanguage("Tien") + " không được bằng 0 ");
                return false;
            }
			
            return true;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            if (this.enuNew_Edit == enuEdit.New)
            {
                drEdit["Stt"] = Common.GetNewStt("09", true);
                while (DataTool.SQLCheckExist("R04CTDNTU", "Stt", drEdit["Stt"]))
                {
                    drEdit["Stt"] = Common.GetNewStt("09", true);
                }
            }
			//Kiem tra cac du lieu can thiet
            drEdit["Ma_Hd"] = strMa_Hd;
            drEdit["Ma_Ct"] = "DNTU";          
			drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["LastModify_Log"] = string.Empty;
            }
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
            return DataTool.SQLUpdate(enuNew_Edit, "R04CTDNTU", ref drEdit);
		}

		#endregion

		#region Events
        void txtMa_Hd_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Hd.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Hd.Text = string.Empty;
                lbtTen_Hd.Text = string.Empty;
            }
            else
            {
                txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
                lbtTen_Hd.Text = drLookup["Ten_Hd"].ToString();
                strMa_Hd = drLookup["Ma_Hd"].ToString();
            }
        }   
        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
            }
            else
            {
                txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
                lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
            }
        }

        void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_CbNv.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_CbNv.Text = string.Empty;
                lbtTen_Dt_CbNv.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
                lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
            }
        }

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
				
			}
			else
			{
				txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
                txtMa_So_Thue.Text = drLookup["Ma_So_Thue"].ToString();
                
                if(!txtMa_Dt.Text.StartsWith("M"))
                {
                    txtSo_Tk_Nh.Text = drLookup["So_Tk_Nh"].ToString();
                    txtTen_Nh.Text = drLookup["Ten_Nh"].ToString();
                }
                else
                {
                    txtSo_Tk_Nh.Text = drLookup["So_Tk"].ToString();
                    txtTen_Nh.Text = drLookup["Ngan_Hang"].ToString();
                }
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

        void btInherit_Click(object sender, EventArgs e)
        {
            Inherit();
        }
        void Inherit()
        {
            frmInheritDnTt frmInherit = new frmInheritDnTt();
            frmInherit.Load("DT", strMa_Hd);
            if (frmInherit.Is_Accept)
            {
                if (frmInherit.dtInheritVoucher.Columns.Contains("Ma_Dt"))
                    txtMa_Dt.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Dt"].ToString();

                if (frmInherit.dtInheritVoucher.Columns.Contains("Dien_Giai"))
                    txtDien_Giai.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Dien_Giai"].ToString();

                if (frmInherit.dtInheritVoucher.Columns.Contains("Ly_Do"))
                    txtLy_Do.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ly_Do"].ToString();

                if (frmInherit.dtInheritVoucher.Columns.Contains("TTien"))
                    numTTien.Value = Common.SumDCValue(frmInherit.dtInheritVoucher, "TTien", "Chon = true");

                if (frmInherit.dtInheritVoucher.Columns.Contains("Tien_Tt0"))
                    numTien.Value = Common.SumDCValue(frmInherit.dtInheritVoucher, "Tien_Tt0", "Chon = true");

                if (frmInherit.dtInheritVoucher.Columns.Contains("So_Ct"))
                    drEdit["So_Ct_Org"] = txtInherit.Text = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["So_Ct"].ToString();

                if (frmInherit.dtInheritVoucher.Columns.Contains("Stt"))
                    drEdit["Stt_Org"] = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Stt"].ToString();

                if(strMa_Hd != null)
                        txtMa_Hd.Text = strMa_Hd;
                else
                        if (frmInherit.dtInheritVoucher.Columns.Contains("Ma_Hd"))
                            drEdit["Ma_Hd"] = frmInherit.dtInheritVoucher.Select("Chon = true")[0]["Ma_Hd"].ToString();
                

                DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", txtMa_Dt.Text);

                txtMa_So_Thue.Text = drDmDt["Ma_So_Thue"].ToString();
                txtTen_Nh.Text = drDmDt["Ten_Nh"].ToString();
                txtSo_Tk_Nh.Text = drDmDt["So_Tk_Nh"].ToString();
                LoadDicName();
            }
        }

        void frmDnTu_Edit_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    this.Inherit();
                    break;
            }
        }
	}
}
