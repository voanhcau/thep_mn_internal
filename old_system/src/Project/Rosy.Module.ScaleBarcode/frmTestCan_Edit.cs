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
using System.Collections;

namespace RosyModule.ScaleBarcode
{
    public partial class frmTestCan_Edit : RosyList.frmEdit
    {

        #region Phuong thuc

        string strMa_Ca;
        DateTime dtNgay_Sx;
        public frmTestCan_Edit()
		{
			InitializeComponent();

            cboLoai_Sp.SelectedIndexChanged += new EventHandler(cboLoai_Sp_SelectedValueChanged);
            numSo_Luong_Can.Validated += new EventHandler(numSo_Luong_Can_Validated);
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strMa_Ca = drEdit["Ma_Ca"].ToString();
            this.dtNgay_Sx = Convert.ToDateTime(drEdit["Ngay_Can"]);
            numSo_Luong_Chuan.Enabled = false;
            numSo_Luong_Can.Enabled = false;
            numChenh_Lech.Enabled = false;
            LoadCombo();
            Common.ScaterMemvar(this, ref drEdit);
            dteGio_Can.Text = drEdit["Gio_Can"].ToString();
            DataRow drDmCa = DataTool.SQLGetDataRowByID("R81DMCA", "Ma_Ca", strMa_Ca);
            if (enuNew_Edit == enuEdit.New)
            {
                dteGio_Can.Text = Voucher.GetDateServer().ToString("HH:mm:ss"); // định dạng 24 trên server
                //cboLoai_Sp.Text = "THANH";

                if(drDmCa["Loai"].ToString() == "LUYEN")
                    cboLoai_Sp.Text = "PHOI";
            }
            numChenh_Lech.Value = numSo_Luong_Chuan.Value - numSo_Luong_Can.Value;
			BindingLanguage();
			LoadDicName();
            

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            
		}

        private void LoadCombo()
        {
            DataTable dtCombo = SQLExec.ExecuteReturnDt("SELECT LOAI_SP FROM R81DMCANCHUAN GROUP BY LOAI_SP");
            cboLoai_Sp.DataSource = dtCombo;
            cboLoai_Sp.DisplayMember = "LOAI_SP";
            cboLoai_Sp.ValueMember = "LOAI_SP";

            
        }
        void cboLoai_Sp_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboLoai_Sp.Text != "System.Data.DataRowView")
            {
                Hashtable ht = new Hashtable();
                ht.Add("LOAI_SP", cboLoai_Sp.Text);
                ht.Add("LOAI_SP1", cboLoai_Sp.Text);
                ht.Add("NGAY_SX", dtNgay_Sx);
                double dbSL_Chuan = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT So_Luong FROM R81DMCANCHUAN WHERE LOAI_SP = @LOAI_SP AND NGAY_AP = (SELECT MAX(Ngay_Ap) FROM R81DMCANCHUAN WHERE Ngay_Ap <= @NGAY_SX and LOAI_SP = @LOAI_SP1)", ht, CommandType.Text));
                numSo_Luong_Chuan.Value = dbSL_Chuan;

                numChenh_Lech.Value = numSo_Luong_Chuan.Value - numSo_Luong_Can.Value;
            }
        }
        void numSo_Luong_Can_Validated(object sender, EventArgs e)
        {
            numChenh_Lech.Value = numSo_Luong_Chuan.Value - numSo_Luong_Can.Value;
        }
		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (numSo_Luong_Can.Value == 0)
            {
                Common.MsgOk(Languages.GetLanguage("So_Luong") + " cân không được bằng 0. Test cân khi có số lượng cân.");

                return false;

            }
            
            //if (txtTen_Dt_Vc.Text.Trim() == string.Empty)
            //{
            //    Common.MsgOk(Languages.GetLanguage("Ten_Xe") + " " +
            //                  Languages.GetLanguage("Not_Null"));

            //    return false;
            //}

  

            return bvalid;
        }

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            drEdit["Gio_Can"] = dteGio_Can.Text;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R05TESTCAN", ref drEdit))
				return false;

		

			return true;
		}

		#endregion

        #region Su kien

        

		
        #endregion

      
    }
}