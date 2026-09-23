using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;
using RosySystem.Public;

namespace RosyModule.ScaleBarcode
{
	public partial class frmDmBarcodePH_Edit : RosySystem.Customize.frmEdit
	{
		public bool bPrint = false;
		private DateTime dteNgay_Nhap;
		private double dbSo_Ca = 0;
		private double dbBarem_Standard = 0;

        public frmDmBarcodePH_Edit()
		{
			InitializeComponent();
			

			txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
		
			txtMa_Ca.Validating += new CancelEventHandler(txtMa_Ca_Validating);
			
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

	

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			this.FillData();

			Common.ScaterMemvar(this, ref drEdit);

			//Get New Barcode theo bo le
			if (enuNew_Edit == enuEdit.New)
			{
				dteNgay_Nhap = Library.StrToDate(Convert.ToString(DataTool.SQLGetNameByCode("R81DMCA", "Ma_Ca", "Ngay_Sx", drEdit["Ma_Ca"].ToString())));
				dbSo_Ca = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMCA", "Ma_Ca", "So_Ca", drEdit["Ma_Ca"].ToString()));
				txtBarcode.Text = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNewBarcodePH('" + dteNgay_Nhap.ToShortDateString() + "', 7, 0)"));
			}

			BindingLanguage();
			LoadDicName();

           
			this.ShowDialog();
		}

		private void FillData()
		{
			
			

			
		}

		private void LoadDicName()
		{
			txtMa_Vt_Sp.bUseAutoDropDown = true;

			if (txtMa_Ca.Text.Trim() != string.Empty)
				lbtCa.Text = DataTool.SQLGetNameByCode("R81DMCA", "Ma_Ca", "Ca", txtMa_Ca.Text.Trim());
			else
				lbtCa.Text = string.Empty;

			if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
				lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
			else
				lbtTen_Vt_Sp.Text = string.Empty;
		}

		private bool FormCheckValid()
		{
            //if (enuNew_Edit == enuEdit.Edit && txtLy_Do.Text.Trim() == string.Empty)
            //{
            //    Common.MsgCancel(Languages.GetLanguage("Ly_Do") + " " +
            //                        Languages.GetLanguage("Not_Null"));
            //    return false;
            //}

			
			if (numSo_Luong.Value <= 0)
			{
				Common.MsgCancel("Khối lượng không hợp lệ");
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

		

			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL R81DMBARCODE
			if (enuNew_Edit == enuEdit.New)
			{
				Hashtable htPara = new Hashtable();
				htPara.Add("STRNEW_EDIT", (char)enuNew_Edit == 'N' ? 'L' : 'E');
			
				htPara.Add("MA_VT_SP", txtMa_Vt_Sp.Text.Trim());
				htPara.Add("MA_CA", txtMa_Ca.Text.Trim());
				htPara.Add("NO_MELT", txtSo_Me.Text.Trim());
				htPara.Add("SO_LUONG", numSo_Luong.Value);

                htPara.Add("INPUT_TYPE", 0);
				htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
				htPara.Add("MA_DATA", Element.sysMa_Data);
				htPara.Add("BARCODE", txtBarcode.Text.Trim());


                return SQLExec.Execute("sp_Update_DmBarcodePH", htPara, CommandType.StoredProcedure);
			}
			else
			{
				Hashtable htPara = new Hashtable();
				htPara.Add("STRNEW_EDIT", (char)enuNew_Edit);
				htPara.Add("BARCODE", txtBarcode.Text.Trim());
				htPara.Add("MA_CA", txtMa_Ca.Text.Trim());

                htPara.Add("INPUT_TYPE", 0);
				htPara.Add("SO_LUONG", numSo_Luong.Value);
				
                //htPara.Add("LY_DO", txtLy_Do.Text);
				htPara.Add("SO_ME", txtSo_Me.Text.Trim());
				
				htPara.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());
                
				htPara.Add("MA_DATA", Element.sysMa_Data);

                return SQLExec.Execute("sp_Update_DmBarcodePH", htPara, CommandType.StoredProcedure);
			}

		}

		
		void txtMa_Ca_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Ca.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Ca", strValue, bRequire, "Loai = 'LUYEN'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Ca.Text = string.Empty;
				lbtCa.Text = string.Empty;
			}
			else
			{
				txtMa_Ca.Text = drLookup["Ma_Ca"].ToString();
				lbtCa.Text = drLookup["Ca"].ToString();
			}
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = string.Empty;
				lbtTen_Vt_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt_Sp.Text = drLookup["Ten_Vt"].ToString();


                txtLoai_Phoi.Text = drLookup["Loai_Phoi"].ToString();
                txtMac_Thep.Text = drLookup["Mac_Thep"].ToString();
			}

		}

	

		

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				bPrint = false;
				isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			bPrint = false;
			this.isAccept = false;
			this.Close();
		}
		
		private void LockEditInfo(bool bLocked)
		{
			txtSo_Me.Enabled = numSo_Luong.Enabled = bLocked;
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (enuNew_Edit == enuEdit.New && txtBarcode.Text.Trim().StartsWith("L"))
			{
				LockEditInfo(true);
			
			}

			if (enuNew_Edit == enuEdit.Edit)
			{
				LockEditInfo(false);

				if (Common.CheckPermission("ACCESS_SO_LUONG", enuPermission_Type.Allow_Access))
					numSo_Luong.Enabled = true;
				else
					numSo_Luong.Enabled = false;
			}
		}
	}
}
