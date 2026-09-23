using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Public;
using RosySystem.Element;

namespace RosyModule.Salary
{
	public partial class frmSLTinhLuong_Edit : RosySystem.Customize.frmEdit
	{
        int iThang; int iNam;
        string strLuyen; string strLuyen_A; string strLuyen_B; string strLuyen_C;
        string strCan; string strCan_A; string strCan_B; string strCan_C; string strKD; string strKD1; string strKD2; string strTTLuongDP; string strTLuongDP;
        string strKHLuyen; string strKHCan; string strKHKD; string strHSQD;
        bool bKH;
        public frmSLTinhLuong_Edit()
		{
			InitializeComponent();

			

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            numLuyen_A.Validated += new EventHandler(numLuyen_A_Validated);
            numLuyen_B.Validated += new EventHandler(numLuyen_B_Validated);
            numLuyen_C.Validated += new EventHandler(numLuyen_C_Validated);
            numCan_A.Validated += new EventHandler(numCan_A_Validated);
            numCan_B.Validated+=new EventHandler(numCan_B_Validated);
            numCan_C.Validated += new EventHandler(numCan_C_Validated);
            numSLDP.Validated += new EventHandler(numSLDP_Validated);
            numSLTT.Validated += new EventHandler(numSLTT_Validated);
		}

      
		new public void Load(enuEdit enuNew_Edit, DataRow drEdit, bool bKH)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.bKH = bKH;
            if (drEdit != null)
            {
                iThang = Convert.ToInt16(drEdit["Thang"]);
                iNam = Convert.ToInt16(drEdit["Nam"]);
            }
            else
            {
                iThang = 0; iNam = Element.sysWorkingYear;
            }
            //Common.ScaterMemvar(this, ref drEdit);

            numNam.Value = iNam;
            numThang.Value = iThang;
            if (bKH)
            {
                strKHLuyen = "SELECT Ton_Dau FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = 0 AND Is_Kh = 1  AND Loai_SL = 'LUYEN'";
                strKHCan = "SELECT Ton_Dau FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = 0 AND Is_Kh = 1  AND Loai_SL = 'CAN'";
                strKHKD = "SELECT Ton_Dau FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = 0 AND Is_Kh = 1  AND Loai_SL = 'KD'";
                strHSQD = "SELECT Ton_Dau FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = 0 AND Is_Kh = 1  AND Loai_SL = 'HSQD'";
                strTTLuongDP = "SELECT MAX(TTLuongDP) FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = 0 AND Is_Kh = 1  AND Loai_SL = 'KD'";
                numKHLuyen.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strKHLuyen));
                numKHCan.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strKHCan));
                numKHKD.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strKHKD));
                numHSQD.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strHSQD));
                if (SQLExec.ExecuteReturnValue(strTTLuongDP).ToString() != string.Empty)
                    numTTLuongDP.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strTTLuongDP));
                else
                    numTTLuongDP.Value = 0;

                this.tabControl1.TabPages.Remove(tabPage1);
            }
            else
            {
                strKD1 = "SELECT SL_Tinh_Luong FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'KD'";
                strTLuongDP = "SELECT TTLuongDP FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'KD'";
                strKD2 = "SELECT SL_SDDP FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'KD'";
                strKD = "SELECT SL_KD FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'KD'";
                
               
                strLuyen_A = "SELECT Ca_A_KH FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'LUYEN'";
                strLuyen_B = "SELECT Ca_B_KH FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'LUYEN'";
                strLuyen_C = "SELECT Ca_C_KH FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'LUYEN'";
                strCan_A = "SELECT Ca_A_KH FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'CAN'";
                strCan_B = "SELECT Ca_B_KH FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'CAN'";
                strCan_C = "SELECT Ca_C_KH FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'CAN'";

                numLuyen_A.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strLuyen_A));
                numLuyen_B.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strLuyen_B));
                numLuyen_C.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strLuyen_C));
                numCan_A.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strCan_A));
                numCan_B.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strCan_B));
                numCan_C.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strCan_C));

                strLuyen_A = "SELECT Ca_A FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'LUYEN'";
                strLuyen_B = "SELECT Ca_B FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'LUYEN'";
                strLuyen_C = "SELECT Ca_C FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'LUYEN'";
                strCan_A = "SELECT Ca_A FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'CAN'";
                strCan_B = "SELECT Ca_B FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'CAN'";
                strCan_C = "SELECT Ca_C FROM R10SLTL WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'CAN'";
                //numLuyen.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strLuyen));
                //numCan.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strCan));
                numKD.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strKD));
                numSLDP.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strKD2));
                numSLTT.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strKD1));
                numTLuongDP.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strTLuongDP));
                //numKD1.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strKD1));

              

                numLuyen_A_QD.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strLuyen_A));
                numLuyen_B_QD.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strLuyen_B));
                numLuyen_C_QD.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strLuyen_C));
                numCan_A_QD.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strCan_A));
                numCan_B_QD.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strCan_B));
                numCan_C_QD.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue(strCan_C));
                this.tabControl1.TabPages.Remove(tabPage2);
            }
           
			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
            numLuyen_A_QD.ReadOnly = true; numLuyen_B_QD.ReadOnly = true; numLuyen_C_QD.ReadOnly = true;
            numCan_A_QD.ReadOnly = true; numCan_B_QD.ReadOnly = true; numCan_C_QD.ReadOnly = true;
            // check lock
            bool bSLKD; bool bSLSX;
            bSLKD = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Lock_SLKD FROM R00LOCKEDLUONG WHERE NAM = "+numNam.Value+" AND Thang = "+ numThang.Value +""));
            bSLSX = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Lock_SLSX FROM R00LOCKEDLUONG WHERE NAM = " + numNam.Value + " AND Thang = " + numThang.Value + ""));

            if (bSLKD)
            { numSLTT.Enabled = false; numSLDP.Enabled = false; numKD.Enabled = false; numTTLuongDP.Enabled = false; }
            if (bSLSX)
            {
                numLuyen_A.ReadOnly = false; numLuyen_B.ReadOnly = false; numLuyen_C.ReadOnly = false;
                numCan_A.ReadOnly = false; numCan_B.ReadOnly = false; numCan_C.ReadOnly = false;
            }
            
		}
        void numCan_C_Validated(object sender, EventArgs e)
        {
            QuyDoiSl();
        }
        void numCan_B_Validated(object sender, EventArgs e)
        {
            QuyDoiSl();
        }
        void numCan_A_Validated(object sender, EventArgs e)
        {
            QuyDoiSl();
        }

        void numLuyen_C_Validated(object sender, EventArgs e)
        {
            QuyDoiSl();
        }

        void numLuyen_B_Validated(object sender, EventArgs e)
        {
            QuyDoiSl();
        }

        void numLuyen_A_Validated(object sender, EventArgs e)
        {
            QuyDoiSl();
        }
        void numSLTT_Validated(object sender, EventArgs e)
        {
            QuyDoiSl();
        }

        void numSLDP_Validated(object sender, EventArgs e)
        {
            QuyDoiSl();
        }

        private void QuyDoiSl()
        {
            if (numSLDP.Value!= 0)
                numKD.Value = Math.Round(numSLTT.Value + numSLDP.Value, MidpointRounding.AwayFromZero);
            
            double dbLuyen = (numLuyen_A.Value + numLuyen_B.Value + numLuyen_C.Value);
            double dbCan = (numCan_A.Value + numCan_B.Value + numCan_C.Value);
            double dbKD = (numKD.Value);

            numLuyen_A_QD.Value = Math.Round((numLuyen_A.Value / dbLuyen)* dbKD, MidpointRounding.AwayFromZero);
            numLuyen_B_QD.Value = Math.Round((numLuyen_B.Value / dbLuyen) * dbKD, MidpointRounding.AwayFromZero);
            numLuyen_C_QD.Value = Math.Round((numLuyen_C.Value / dbLuyen) * dbKD, MidpointRounding.AwayFromZero);

            numCan_A_QD.Value = Math.Round((numCan_A.Value / dbCan) * dbKD, MidpointRounding.AwayFromZero);
            numCan_B_QD.Value = Math.Round((numCan_B.Value / dbCan) * dbKD, MidpointRounding.AwayFromZero);
            numCan_C_QD.Value = Math.Round((numCan_C.Value / dbCan) * dbKD, MidpointRounding.AwayFromZero);

        }
		private bool CheckFormValid()
		{
            if (!bKH)
            {
                //if (numLuyen_A.Value + numLuyen_B.Value + numLuyen_C.Value > numLuyen.Value)
                //{
                //    Common.MsgOk("Sản lượng tính lương và sản lượng các ca luyện không bằng nhau. sản lưỡng ca A, B, C phải bằng sản lượng tính lương!");
                //    return false;
                //}
                //if (numCan_A.Value + numCan_B.Value + numCan_C.Value > numCan.Value)
                //{
                //    Common.MsgOk("Sản lượng tính lương và sản lượng các ca cán không bằng nhau. sản lưỡng ca A, B, C phải bằng sản lượng tính lương!");
                //    return false;
                //}
            }
			return true;
		}

		private bool Save()
		{
			

			if (!this.CheckFormValid())
				return false;

            if (!bKH)// SL_Tinh_Luong = " + numLuyen.Value + ", SL_Tinh_Luong = " + numCan.Value + ",
            {

                strLuyen = "UPDATE R10SLTL SET Ca_A_KH = " + numLuyen_A.Value + ", Ca_B_KH = " + numLuyen_B.Value + ", Ca_C_KH = " + numLuyen_C.Value + ", "+
                    "  Ca_A = " + numLuyen_A_QD.Value + ", Ca_B = " + numLuyen_B_QD.Value + ", Ca_C = " + numLuyen_C_QD.Value + ", " + 
                    " SL_Tinh_Luong =  " + numLuyen_A_QD.Value + " + " + numLuyen_B_QD.Value + " + " + numLuyen_C_QD.Value + " " +
                        " WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'LUYEN'";
                strCan = "UPDATE R10SLTL SET  Ca_A_KH = " + numCan_A.Value + ", Ca_B_KH = " + numCan_B.Value + ", Ca_C_KH = " + numCan_C.Value +", " +
                     "  Ca_A = " + numCan_A_QD.Value + ", Ca_B = " + numCan_B_QD.Value + ", Ca_C = " + numCan_C_QD.Value + "," +
                     " SL_Tinh_Luong =  " + numCan_A_QD.Value + " + " + numCan_B_QD.Value + " + " + numCan_C_QD.Value + " " +
                        " WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'CAN'";
               
                //strKD = "UPDATE R10SLTL SET SL_Tinh_Luong = " + numKD.Value + " WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'KD'";
                strKD1 = "UPDATE R10SLTL SET SL_SDDP = " + numSLDP.Value + ", SL_Tinh_Luong =  " + numSLTT.Value + ", SL_KD = " + numKD.Value + ", TTLuongDP = " + numTLuongDP.Value + " WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'KD'";
                strKD2 = "UPDATE R10SLTL SET Ton_Cuoi = CASE WHEN SL_KD > SL_Tinh_Luong THEN Ton_Dau - SL_SDDP ELSE  Ton_Dau - SL_SDDP - SL_KD + SL_Tinh_Luong END  WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'KD'";
               
                //strKD1 = "UPDATE R10SLTL SET SL_Tinh_Luong = " + numKD1.Value + " WHERE Nam = " + iNam + " AND Thang = " + iThang + " AND Is_Kh = 0  AND Loai_SL = 'KD1'";


                SQLExec.Execute(strLuyen);
                SQLExec.Execute(strCan);
                //SQLExec.Execute(strKD);
                SQLExec.Execute(strKD1);
                SQLExec.Execute(strKD2);
                //SQLExec.Execute(strKD1);
            }
            else
            {
                if (DataTool.SQLCheckExist("R10SLTL", new string[] { "Nam", "Thang" }, new object[] { iNam, 0 }))
                {
                    strLuyen = "UPDATE R10SLTL SET Ton_Dau = " + numKHLuyen.Value + " WHERE Nam = " + iNam + " AND Thang = 0 AND Is_Kh = 1  AND Loai_SL = 'LUYEN'";
                    strCan = "UPDATE R10SLTL SET Ton_Dau = " + numKHCan.Value + " WHERE Nam = " + iNam + " AND Thang = 0 AND Is_Kh = 1  AND Loai_SL = 'CAN'";
                    strKD = "UPDATE R10SLTL SET Ton_Dau = " + numKHKD.Value + ", TTLuongDP = "+ numTTLuongDP.Value +" WHERE Nam = " + iNam + " AND Thang = 0 AND Is_Kh = 1  AND Loai_SL = 'KD'";
                    //strKD1 = "UPDATE R10SLTL SET Ton_Dau = " + numKHKD.Value + " WHERE Nam = " + iNam + " AND Thang = 0 AND Is_Kh = 1  AND Loai_SL = 'KD1'";
                    strHSQD = "UPDATE R10SLTL SET Ton_Dau = " + numHSQD.Value + " WHERE Nam = " + iNam + " AND Thang = 0 AND Is_Kh = 1  AND Loai_SL = 'HSQD'";
                }
                else
                {
                    strLuyen = "INSERT INTO R10SLTL(Nam, Thang, Loai_SL, Ton_Dau, Is_Kh) SELECT " + iNam + ", 0, 'LUYEN', " + numKHLuyen.Value + ", 1";
                    strCan = "INSERT INTO R10SLTL(Nam, Thang, Loai_SL, Ton_Dau, Is_Kh) SELECT " + iNam + ", 0, 'CAN', " + numKHCan.Value + ", 1";
                    strKD = "INSERT INTO R10SLTL(Nam, Thang, Loai_SL, Ton_Dau, TTLuongDP, Is_Kh) SELECT " + iNam + ", 0, 'KD', " + numKHKD.Value + ", " + numTTLuongDP.Value + ", 1";
                    
                    strHSQD = "INSERT INTO R10SLTL(Nam, Thang, Loai_SL, Ton_Dau, Is_Kh) SELECT " + iNam + ", 0, 'HSQD', " + numHSQD.Value + ", 1";
                }
                SQLExec.Execute(strLuyen);
                SQLExec.Execute(strCan);
                SQLExec.Execute(strKD);
                //SQLExec.Execute(strKD1);
                SQLExec.Execute(strHSQD);
            }
            
			return true;
		}

	

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
	}
}
