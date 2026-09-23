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

namespace RosyModule
{
	public partial class frmDmBarcode_Edit : RosySystem.Customize.frmEdit
	{
		public bool bPrint = false;

		public frmDmBarcode_Edit()
		{
			InitializeComponent();
			
			cboMa_Vt.SelectedValueChanged += new EventHandler(cboSelectedValueChanged);
			cboGrade_ID.SelectedValueChanged += new EventHandler(cboSelectedValueChanged);

			btSaveAndPrint.Click += new EventHandler(btSaveAndPrint_Click);
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

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void FillData()
		{
			//Danh mục sản phẩm
			DataTable dtDmVtSp = DataTool.SQLGetDataTable("R81DMVT", "", "Ma_Nh_Vt = 'THEPCAY'", "Ma_Vt");
			cboMa_Vt.DataSource = dtDmVtSp;
			cboMa_Vt.DisplayMember = "TEN_VT";
			cboMa_Vt.ValueMember = "MA_VT";
			cboMa_Vt.SelectedValue = drEdit["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drEdit["Ma_Vt"];

			//Danh mục tiêu chuẩn
			DataTable dtDmStandard = DataTool.SQLGetDataTable("R81DMSTANDARD", "", "", "Standard_ID");
			cboStandard_ID.DataSource = dtDmStandard;
			cboStandard_ID.DisplayMember = "STANDARD_NAME";
			cboStandard_ID.ValueMember = "STANDARD_ID";
			cboStandard_ID.SelectedValue = drEdit["Standard_ID"] == DBNull.Value ? string.Empty : (string)drEdit["Standard_ID"];

			//Danh mục mác thép
			DataTable dtDmMacThep = DataTool.SQLGetDataTable("R81DMMACTHEP", "", "", "Grade_ID");
			cboGrade_ID.DataSource = dtDmMacThep;
			cboGrade_ID.DisplayMember = "Grade_Name";
			cboGrade_ID.ValueMember = "Grade_ID";
			cboGrade_ID.SelectedValue = drEdit["Grade_ID"] == DBNull.Value ? string.Empty : (string)drEdit["Grade_ID"];

			//Danh mục Lots
			DataTable dtDmLots = DataTool.SQLGetDataTable("R81DMLOTS", "", "", "Lot_ID");
			cboLot_ID.DataSource = dtDmLots;
			cboLot_ID.DisplayMember = "Lot_Name";
			cboLot_ID.ValueMember = "Lot_ID";
			cboLot_ID.SelectedValue = drEdit["Lot_ID"] == DBNull.Value ? string.Empty : (string)drEdit["Lot_ID"];

			//Chất lượng
			DataTable dtDmCL = DataTool.SQLGetDataTable("R81DMCL", "", "", "Ma_CL");
			cboMa_CL.DataSource = dtDmCL;
			cboMa_CL.DisplayMember = "Ten_CL";
			cboMa_CL.ValueMember = "Ma_CL";
			cboMa_CL.SelectedValue = drEdit["Ma_CL"] == DBNull.Value ? string.Empty : (string)drEdit["Ma_CL"];
		}

		private void LoadDicName()
		{
			
		}

		private bool FormCheckValid()
		{
			if (txtLy_Do.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ly_Do") + " " +
									Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (cboMa_Vt.SelectedValue.ToString() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Kich_Thuoc") + " " +
									Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (cboGrade_ID.SelectedValue.ToString() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Grade_ID") + " " +
									Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (cboMa_CL.SelectedValue.ToString() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_CL") + " " +
									Languages.GetLanguage("Not_Null"));
				return false;
			}
			
			if (cboLot_ID.SelectedValue.ToString() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Lot_ID") + " " +
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

			if (drEdit.Table.Columns.Contains("Kich_Thuoc"))
				drEdit["Kich_Thuoc"] = cboMa_Vt.Text;

			if (drEdit.Table.Columns.Contains("Standard_Name"))
				drEdit["Standard_Name"] = cboStandard_ID.Text;

			if (drEdit.Table.Columns.Contains("Grade_Name"))
				drEdit["Grade_Name"] = cboGrade_ID.Text;

			if (drEdit.Table.Columns.Contains("Lot_Name"))
				drEdit["Lot_Name"] = cboLot_ID.Text;

			if (drEdit.Table.Columns.Contains("Ten_CL"))
				drEdit["Ten_CL"] = cboMa_CL.Text;

			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();


			//Luu xuong CSDL R81DMBARCODE AND R05CTNX
			Hashtable htPara = new Hashtable();
			htPara.Add("STRNEW_EDIT", (char)enuNew_Edit);
			htPara.Add("IDENT00", drEdit["Ident00"]);
			htPara.Add("BARCODE", txtBarcode.Text.Trim());
			htPara.Add("MA_VT", cboMa_Vt.SelectedValue);
			htPara.Add("STANDARD_ID", cboStandard_ID.SelectedValue);
			htPara.Add("GRADE_ID", cboGrade_ID.SelectedValue);
			htPara.Add("MA_CL", cboMa_CL.SelectedValue);
			htPara.Add("LOT_ID", cboLot_ID.SelectedValue);
			htPara.Add("NUM_LOT", txtNum_Lot.Text.Trim());
			htPara.Add("NUM_BARS", numNum_Bars.Value);
			htPara.Add("LENGTH", numLength.Value);
			htPara.Add("SO_LUONG", numSo_Luong.Value);
			htPara.Add("SO_LUONG_BAREM", numSo_Luong_Barem.Value);
			htPara.Add("LY_DO", txtLy_Do.Text);
			htPara.Add("LASTMODIFY_LOG", Common.GetCurrent_Log());
			htPara.Add("MA_DATA", Element.sysMa_Data);

			return SQLExec.Execute("sp_Update_DmBarcode_CtN_Barcode", htPara, CommandType.StoredProcedure);
		}

		void cboSelectedValueChanged(object sender, EventArgs e)
		{
			ComboBox cboControl = (ComboBox)sender;
			string strControl_Name = cboControl.Name;
			if (strControl_Name == "cboMa_Vt")
			{
				string strMa_Vt_Sp = cboMa_Vt.SelectedValue == null ? string.Empty : Convert.ToString(cboMa_Vt.SelectedValue);
				DataRow drDmVtSp = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", strMa_Vt_Sp);
				
				if (drDmVtSp != null)
					numNum_Bars.Value = Convert.ToInt32(drDmVtSp["Num_Bars"]);
			}
			else if (strControl_Name == "cboGrade_ID")
			{
				string strGradeID = cboGrade_ID.SelectedValue == null ? string.Empty : cboGrade_ID.SelectedValue.ToString();
				object objStandardID = SQLExec.ExecuteReturnValue("SELECT Standard_ID FROM R81DMMACTHEP WHERE Grade_ID = '" + strGradeID + "'");
				if (objStandardID != null && objStandardID != DBNull.Value)
					cboStandard_ID.SelectedValue = objStandardID;
			}
		}

		void btSaveAndPrint_Click(object sender, EventArgs e)
		{
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

			if (!Element.sysIs_Admin)
			{
				if (Common.CheckPermission("ACCESS_SO_LUONG", enuPermission_Type.Allow_Access))
					numSo_Luong.Enabled = numSo_Luong_Barem.Enabled = true;
				else
					numSo_Luong.Enabled = numSo_Luong_Barem.Enabled = false;
			}
		}
	}
}
