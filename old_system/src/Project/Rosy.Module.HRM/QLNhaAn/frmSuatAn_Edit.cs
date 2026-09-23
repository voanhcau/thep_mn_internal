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
using RosySystem.Customize;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.HRM
{
	public partial class frmSuatAn_Edit : frmEdit
	{
		#region Phuong thuc
        DataTable dtSuatAn;
        public frmSuatAn_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
           
           
		}

        

        
    

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
          

			BindingLanguage();
			
          
            Common.ScaterMemvar(this, ref drEdit);
            dtSuatAn = SQLExec.ExecuteReturnDt("SELECT Loai, So_Suat_An FROM R09THUCDON WHERE Ngay_Ct = '" + dteNgay_Ct.Text + "' order by Loai");
            if (dtSuatAn.Select("Loai = 'S'").Length > 0)
                numSo_Suat_An_S.Value = Convert.ToDouble(dtSuatAn.Select("Loai = 'S'")[0][1]);
            if (dtSuatAn.Select("Loai = 'T'").Length > 0)
                numSo_Suat_An_T.Value = Convert.ToDouble(dtSuatAn.Select("Loai = 'T'")[0][1]);
            if (dtSuatAn.Select("Loai = 'C'").Length > 0)
                numSo_Suat_An_C.Value = Convert.ToDouble(dtSuatAn.Select("Loai = 'C'")[0][1]);
            if (dtSuatAn.Select("Loai = 'K'").Length > 0)
                numSo_Suat_An_K.Value = Convert.ToDouble(dtSuatAn.Select("Loai = 'K'")[0][1]);
            LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{
           
           
            
			
		}



    
        
    
      
		public bool FormCheckValid()
		{
			bool bvalid = true;
            //if (numSo_Xuat_An_S.Value == 0)
            //{
            //    Common.MsgOk("Số xuất ăn sáng");
            //    return false;
            //}
           
			return bvalid;
		}

		public bool Save()
		{
           
			
            Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            if (dtSuatAn.Select("Loai = 'S'").Length > 0)
            {
                Hashtable ht1 = new Hashtable();
                ht1.Add("NGAY_CT", dteNgay_Ct.Text);
                ht1.Add("SANG", numSo_Suat_An_S.Value);
                string strSQL1 = "UPDATE R09THUCDON SET So_Suat_An = @Sang WHERE Loai = 'S' AND Ngay_Ct = @Ngay_Ct";
                SQLExec.Execute(strSQL1, ht1, CommandType.Text);
             
            }
            if (dtSuatAn.Select("Loai = 'T'").Length > 0)
            {
                Hashtable ht2 = new Hashtable();
                ht2.Add("NGAY_CT", dteNgay_Ct.Text);
                ht2.Add("TRUA", numSo_Suat_An_T.Value);
                string strSQL2 = "UPDATE R09THUCDON SET So_Suat_An = @Trua WHERE Loai = 'T' AND Ngay_Ct = @Ngay_Ct";
                SQLExec.Execute(strSQL2, ht2, CommandType.Text);
            }

            if (dtSuatAn.Select("Loai = 'C'").Length > 0)
            {
                Hashtable ht3 = new Hashtable();
                ht3.Add("NGAY_CT", dteNgay_Ct.Text);
                ht3.Add("CHIEU", numSo_Suat_An_C.Value);
                string strSQL3 = "UPDATE R09THUCDON SET So_Suat_An = @Chieu WHERE Loai = 'C' AND Ngay_Ct = @Ngay_Ct";
                SQLExec.Execute(strSQL3, ht3, CommandType.Text);
            }

            if (dtSuatAn.Select("Loai = 'K'").Length > 0)
            {
                Hashtable ht4 = new Hashtable();
                ht4.Add("NGAY_CT", dteNgay_Ct.Text);
                ht4.Add("KHUYA", numSo_Suat_An_K.Value);
                string strSQL4 = "UPDATE R09THUCDON SET So_Suat_An = @Khuya WHERE Loai = 'K' AND Ngay_Ct = @Ngay_Ct";
                SQLExec.Execute(strSQL4, ht4, CommandType.Text);
            }
            //if (enuNew_Edit == enuEdit.New)
            //{
               
            //    drEdit["Create_Log"] = Common.GetCurrent_Log();
               
            //}
            //else if (enuNew_Edit == enuEdit.Edit)
            //    drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
            //if (!DataTool.SQLUpdate(enuNew_Edit, "R09THUCDON", ref drEdit))
                //return false;

			return true;
		}
		#endregion

		#region Su kien
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
		#endregion
	}
}
