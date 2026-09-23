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
	public partial class frmDLSXPhoi_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

        string strStt = string.Empty;
        DateTime dtNgay_Sx;

        public frmDLSXPhoi_Edit()
		{
			InitializeComponent();
           
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            numSL_Phoi_Nong.Validated += new EventHandler(Cal_Phoi_Validated);
            numSL_Phoi_TG.Validated += new EventHandler(Cal_Phoi_Validated);
            numSL_Phoi_Nguoi.Validated += new EventHandler(Cal_Phoi_Validated);
            numSL_Phoi_Hlo.Validated += new EventHandler(Cal_Phoi_Validated);
            numSL_Phoi_San.Validated += new EventHandler(Cal_Phoi_Validated);
            numSL_Phoi_Tlo.Validated += new EventHandler(Cal_Phoi_Validated);
            
		}


        public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strStt, DateTime dtNgay_Sx)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strStt = strStt;
            this.dtNgay_Sx = dtNgay_Sx;

            numSL_Phoi_Nong.Focus();

            Common.ScaterMemvar(this, ref drEdit);            
            BindingLanguage();
			LoadDicName();

            dteGio_Nap.Text = drEdit["Gio_Nap"].ToString();
            dteGio_Can.Text = drEdit["Gio_Can"].ToString();

            if (enuNew_Edit == enuEdit.New)
            {
                dteGio_Can.Text = DateTime.Now.ToString("HH:mm:ss");
                dteGio_Nap.Text = DateTime.Now.ToString("HH:mm:ss");

                txtMa_Vt.ReadOnly = false;
                numDDai_Phoi.ReadOnly = false;
                txtSo_Me.ReadOnly = false;
            }
            if (enuNew_Edit == enuEdit.Edit && dteGio_Nap.Text == "00:00:00")
                dteGio_Nap.Text = DateTime.Now.ToString("HH:mm:ss");
            if (enuNew_Edit == enuEdit.Edit && dteGio_Can.Text == "00:00:00")
                dteGio_Can.Text = DateTime.Now.ToString("HH:mm:ss");
                     

            this.ShowDialog();
		}

		private void LoadDicName()
		{
            //txtMa_Kv_Sx.bUseAutoDropDown = true;
            //txtMa_Kv_Sx.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%' AND LEN(Ma_Vt) = 9";

            txtMa_Vt.bUseAutoDropDown = true;
            txtMa_Vt.strLookupKeyFilter = "Ma_Nh_Vt = 'PHOI'";

          

            if (txtMa_Vt.Text.Trim() != string.Empty)
            {
                lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
            }
            else
                lbtTen_Vt.Text = string.Empty;

         
            //Log
            //string strCreate_Log = Common.Show_Log((string)drEdit["Create_Log"]);
            //string strLastModify_Log = Common.Show_Log((string)drEdit["LastModify_Log"]);
            //string strLog = string.Empty;
            //strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
            //strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";

           
		}

		public bool FormCheckValid()
		{
            if (numTong_Phoi_KSd.Value + numTong_Phoi_Sd.Value != Convert.ToDouble(drEdit["So_Luong_Cay_Xuat"]))
            {
                Common.MsgCancel("Số lượng phôi xuất không bằng SL phôi đã cán và phôi chưa cán. Yêu cầu kiểm tra lại");
                  return false;
            }
          

		
			
            return true;
		}

		public bool Save()
		{
            drEdit["Gio_Can"] = dteGio_Can.Text;
            drEdit["Gio_Nap"] = dteGio_Nap.Text;
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            if (numSL_Phoi_Hlo.Value != 0)
                Update_PhoiHlo();

			//Kiem tra cac du lieu can thiet
            drEdit["Stt"] = strStt;
            //drEdit["Create_Log"] = string.Empty;
            //drEdit["LastModify_Log"] = string.Empty;
            drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
            
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();


            return DataTool.SQLUpdate(enuNew_Edit, "R11DLSX_XPHOI", ref drEdit); //Luu xuong CSDL
           
		}

		#endregion

		#region Events
        void Update_PhoiHlo()
        {
            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);
            ht.Add("SO_ME", txtSo_Me.Text);
            ht.Add("DDAI_PHOI", numDDai_Phoi.Value);

            SQLExec.Execute("sp_UpdateSLPhoiHlo", ht, CommandType.StoredProcedure);
        }
       
        void Cal_Phoi_Validated(object sender, EventArgs e)
        {
            
            Hashtable ht = new Hashtable();
            ht.Add("MA_VT", txtMa_Vt.Text);
            ht.Add("NGAY_CT", this.dtNgay_Sx);
            ht.Add("SO_ME", txtSo_Me.Text);

            double dbBarem = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CalBaremPhoi(@Ma_Vt,@Ngay_Ct, @So_Me)", ht, CommandType.Text));
            
            numTong_Phoi_Sd.Value = Convert.ToDouble(numSL_Phoi_Nong.Value) + Convert.ToDouble(numSL_Phoi_TG.Value) + Convert.ToDouble(numSL_Phoi_Nguoi.Value) ;
            numTong_SL_Phoi_Sd.Value = Math.Round(Convert.ToDouble(numTong_Phoi_Sd.Value) * dbBarem * Convert.ToDouble(numDDai_Phoi.Value), 0);
            numTong_Phoi_KSd.Value = Convert.ToDouble(numSL_Phoi_Hlo.Value) + Convert.ToDouble(numSL_Phoi_San.Value) + Convert.ToDouble(numSL_Phoi_Tlo.Value);
            numTong_SL_Phoi_KSd.Value = Math.Round(Convert.ToDouble(numTong_Phoi_KSd.Value) * dbBarem * Convert.ToDouble(numDDai_Phoi.Value), 0);
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
