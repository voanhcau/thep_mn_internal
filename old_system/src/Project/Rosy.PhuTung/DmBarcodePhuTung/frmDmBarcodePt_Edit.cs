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
using RosyModule;

namespace RosyPhuTung
{
	public partial class frmDmBarcodePt_Edit : RosySystem.Customize.frmEdit
	{
		public bool bPrint = false;
		

		public frmDmBarcodePt_Edit()
		{
			InitializeComponent();
			this.InitDevice();

			
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
			btSaveAndPrint.Click += new EventHandler(btSaveAndPrint_Click);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		private void InitDevice()
		{
			DataRow drEquipment = DataTool.SQLGetDataRowByID("R81EquipmentInfo", "Host_IP", MachineInfo.GetHostIP());
			if (drEquipment != null)
			{
                Variables.strPrint_Barcode = (string)drEquipment["Print_Barcode"];
                Variables.strPrint_Report = (string)drEquipment["Print_Report"];
                Variables.strPrint_Eticket = (string)drEquipment["Print_Eticket"];
			}
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
				txtBarcode.Text = Convert.ToString(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNewBarcode('L', '" + Library.StrToDate(dteNgay_Ct_Nhap.Text).ToShortDateString() + "', 7, 0)"));
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
			txtMa_Vt.bUseAutoDropDown = true;

			if (txtMa_Vt.Text.Trim() != string.Empty)
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
			else
				lbtTen_Vt.Text = string.Empty;

			
		}

		private bool FormCheckValid()
		{
			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt") + " " +
									Languages.GetLanguage("Not_Null"));
				return false;
			}
            if (dteNgay_Ct_Nhap.Text.Trim() == string.Empty)
            {
                Common.MsgCancel("Ngày chứng từ nhập " +
                                    Languages.GetLanguage("Not_Null"));
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
				htPara.Add("BARCODE", txtBarcode.Text.Trim());
				htPara.Add("MA_VT", txtMa_Vt.Text.Trim());
                htPara.Add("NGAY_CT_NHAP", Library.StrToDate(dteNgay_Ct_Nhap.Text));
				htPara.Add("CREATE_LOG", Common.GetCurrent_Log());
				htPara.Add("MA_DATA", Element.sysMa_Data);

				return SQLExec.Execute("sp_Update_DmBarcode", htPara, CommandType.StoredProcedure);
			}
			else
			{
				Hashtable htPara = new Hashtable();
				htPara.Add("STRNEW_EDIT", (char)enuNew_Edit);
				htPara.Add("BARCODE", txtBarcode.Text.Trim());
				htPara.Add("MA_VT", txtMa_Vt.Text.Trim());
                htPara.Add("NGAY_CT_NHAP", Library.StrToDate(dteNgay_Ct_Nhap.Text));
				htPara.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());
				htPara.Add("MA_DATA", Element.sysMa_Data);

				return SQLExec.Execute("sp_Update_DmBarcode", htPara, CommandType.StoredProcedure);
			}

		}

		

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
			}
		}

		
		
		void btSaveAndPrint_Click(object sender, EventArgs e)
		{
			bPrint = true;
			if (this.Save())
			{
				bPrint = true;
				isAccept = true;
				this.Close();
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
		
		

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (enuNew_Edit == enuEdit.New && txtBarcode.Text.Trim().StartsWith("L"))
			{
				
				btSaveAndPrint.Enabled = false;
				
			}

			
		}
	}
}
