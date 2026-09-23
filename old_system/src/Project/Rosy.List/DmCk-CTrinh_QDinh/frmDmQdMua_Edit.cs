using System;
using System.Collections;
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
	public partial class frmDmQdMua_Edit : RosyList.frmEdit
	{

        DataRow drCurrent;
        #region Phuong thuc

		public frmDmQdMua_Edit()
		{
			InitializeComponent();

            txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			
			
			txtSo_Qd_Modify.Validating += new CancelEventHandler(btSo_QD_Modify_Click);
           
		}

        

        public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.drCurrent = drEdit;
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            Common.ScaterMemvar(this, ref drEdit);

            if (enuNew_Edit == enuEdit.Edit)
            {
                this.txtSo_QD.Enabled = false;
                this.drEdit = DataTool.SQLGetDataRowByID("R81DMQD", "SO_QD", drEdit["SO_QD"].ToString());

            }

            BindingLanguage();
            LoadDicName();
            
            if(enuNew_Edit == enuEdit.Edit)
                CheckQD();
            
            this.ShowDialog();
        }

        private void CheckQD()
        {
            //double dbSO = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(So_QD) FROM R04CTSO WHERE So_QD = '" + drEdit["So_QD"].ToString() + "'"));
            //double dbHD = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT(So_QD) FROM R04CTHD WHERE So_QD = '" + drEdit["So_QD"].ToString() + "'"));
            
            ////Kiểm tra quyết định đã xuất hiện chưa
            //if (dbSO > 1 && dbHD == 0)
            //   LockControl();
            //else if (dbHD > 1)
            //{
            //    LockControl();
            //    //numSo_Luong_Max.Enabled = false;
            //}
        }
        void LockControl()
        {
            txtSo_QD.Enabled = false;
            dteNgay_QD.Enabled = false;
            dteNgay_Het_Han.Enabled = false;
          
            txtMa_Dt.Enabled = false;
            
           
            txtSo_Qd_Modify.Enabled = false;
            dteNgay_Thay_The.Enabled = false;
           
        }
		private void LoadDicName()
		{
            if (txtMa_Dt.Text.Trim() != string.Empty)
            {
                lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
            }
            else
                lbtTen_Dt.Text = string.Empty;

        
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtSo_QD.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("So_QD") + " " +
							  Languages.GetLanguage("Not_Null"));
                return false;
            }
			if (txtSo_Qd_Modify.Text.Trim() != string.Empty)
			{
				if (string.IsNullOrEmpty(dteNgay_Thay_The.Text))
				{
					Common.MsgOk(Languages.GetLanguage("Ngay_Thay_The") + " " +
								 Languages.GetLanguage("Not_Null"));
					return false;
				}
			}
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;

			

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

            drEdit["Loai_Qd"] = "2";
            //Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMQD", ref drEdit))
				return false;
			//cap nhat ngay het han cho quyet dinh duoc thay the
			else
			{

				Hashtable htParameter = new Hashtable();
				if (!string.IsNullOrEmpty(txtSo_Qd_Modify.Text.Trim()))
				{
					htParameter.Add("SO_QD", txtSo_Qd_Modify.Text.Trim());
					htParameter.Add("NGAY_HET_HAN", dteNgay_Thay_The.Text);

					if (!SQLExec.Execute("sp_Update_NgayHH_QD", htParameter, CommandType.StoredProcedure) && string.IsNullOrEmpty(txtSo_Qd_Modify.Text))
						return false;
					else
						Common.MsgOk("Bạn đã cập nhật ngày hết hạn QĐ '" + txtSo_Qd_Modify.Text.Trim() + "' là '" + drEdit["Ngay_QD"].ToString() + "'");
				}
			}
            if (enuNew_Edit == enuEdit.Edit)
            {
                Hashtable ht = new Hashtable();
                
                ht.Add("SO_QD", txtSo_QD.Text);
                ht.Add("NGAY_AP", dteNgay_QD.Text);
                ht.Add("NGAY_KTHUC", dteNgay_Het_Han.Text);

                SQLExec.Execute("UPDATE R81DMQD SET Ngay_Ap = @Ngay_Ap, Ngay_KThuc = @Ngay_KThuc WHERE So_Qd = @So_Qd", ht, CommandType.Text);
                
            }
            Common.CopyDataRow(drEdit, drCurrent);

            //Doi ma
            //if (enuNew_Edit == enuEdit.Edit)
            //    DataTool.SQLChangeID("SO_QD", drEdit);
            
			return true;
		}

        #endregion

        #region Su kien

        void btSo_QD_Modify_Click(object sender, EventArgs e)
        {
            bool bRequire = false;
            string strFilter = "Loai_Qd = '2'";

            DataRow drLookup = Lookup.ShowLookup("So_QD", txtSo_Qd_Modify.Text, bRequire, strFilter, "");

            if (drLookup == null)
            {
                txtSo_Qd_Modify.Text = string.Empty;
            }
            else
            {
                txtSo_Qd_Modify.Text = drLookup["So_QD"].ToString();
                dteNgay_Thay_The.Text = DateTime.Now.ToShortDateString();
            }

        }

        void txtMa_Dt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt.Text.Trim();
            bool bRequire = false;
           

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
                txtMa_Dt.Text = ((string)drLookup["Ma_Dt"]).Trim();
                lbtTen_Dt.Text = ((string)drLookup["Ten_Dt"]).Trim();
            }
        }

        void txtCheckDuplicate(object sender, CancelEventArgs e)
		{
			if (this.CheckDuplicate((TextBox)sender, drEdit, "R81DMQD"))
				e.Cancel = true;
		}

        #endregion		

	}
}