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
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmCa_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc
        string strLoai = string.Empty;

		public frmDmCa_Edit()
		{
			InitializeComponent();

			txtMa_Dt_CbNv_TC.Validating += new CancelEventHandler(txtMa_Dt_CbNv_TC_Validating);
			txtMa_Dt_CbNv_KCS.Validating += new CancelEventHandler(txtMa_Dt_CbNv_KCS_Validating);
			txtMa_Dt_CbNv_Can.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Can_Validating);

			cboCa.TextChanged += new EventHandler(cboCa_TextChanged);
		}

		void cboCa_TextChanged(object sender, EventArgs e)
		{
			if (cboCa.Focused && cboCa.Text != "" && strLoai != "CANGC")
			{
				string strSQL = @"
					SELECT * FROM R81DMCA T1 WITH (NOLOCK)
						WHERE Ngay_Sx IN 
							(
							SELECT MAX(Ngay_Sx)
								FROM R81DMCA  WITH (NOLOCK)
								WHERE Ca = '" + cboCa.Text + @"' AND Ma_Dt_CbNv_TC <> '' AND Ma_Dt_CbNv_KCS <> '' AND Ma_Dt_CbNv_Can <> '' AND Loai = '"+ strLoai + @"'
							)
						AND Ca = '" + cboCa.Text + @"' AND Loai = '" + strLoai + "' AND Ma_Dt_CbNv_TC <> '' AND Ma_Dt_CbNv_KCS <> '' AND Ma_Dt_CbNv_Can <> ''";

				DataTable dtCa = SQLExec.ExecuteReturnDt(strSQL);

				if (dtCa != null && dtCa.Rows.Count > 0)
				{
					txtGio_Begin.Text = dtCa.Rows[0]["Gio_Begin"].ToString();
					txtGio_End.Text = dtCa.Rows[0]["Gio_End"].ToString();
					txtMa_Dt_CbNv_Can.Text = dtCa.Rows[0]["Ma_Dt_CbNv_Can"].ToString();
					txtMa_Dt_CbNv_KCS.Text = dtCa.Rows[0]["Ma_Dt_CbNv_KCS"].ToString();
					txtMa_Dt_CbNv_TC.Text = dtCa.Rows[0]["Ma_Dt_CbNv_TC"].ToString();

					this.LoadDicName();
				}
			}
		}

        public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
          

			Common.ScaterMemvar(this, ref drEdit);

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{

				int iMa_Ca = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(Ma_Ca)) AS BIGINT)), 0) + 1 FROM R81DMCA"));

               
                if (iMa_Ca.ToString().EndsWith("0") || iMa_Ca.ToString().EndsWith("2") || iMa_Ca.ToString().EndsWith("4") || iMa_Ca.ToString().EndsWith("6") || iMa_Ca.ToString().EndsWith("8")) //Mã Ca tăng theo số lẻ 1,3, 5, 7, 9
                    iMa_Ca++;
              
				DateTime dtNgay_Sx = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNow()"));
				DateTime dtNgay_Sx1 = Common.GetDate(dtNgay_Sx.Year, 1, 1);
				DateTime dtNgay_Sx2 = Common.GetDate(dtNgay_Sx.Year, 12, 31);
				System.Collections.Hashtable htPara = new System.Collections.Hashtable();
				htPara.Add("NGAY_SX1", dtNgay_Sx1);
				htPara.Add("NGAY_SX2", dtNgay_Sx2);

				int iSo_Ca = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(So_Ca), 0) + 1 FROM R81DMCA WHERE Ngay_Sx BETWEEN @Ngay_Sx1 AND @Ngay_Sx2 AND Ma_Ca > '1008850'", htPara, CommandType.Text));

				if (iMa_Ca == 1008851)
					iSo_Ca = 3;

				numSo_Ca.Value = iSo_Ca;
				txtMa_Ca.Text = Convert.ToString(iMa_Ca);
				dteNgay_Sx.Text = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNow()")).ToShortDateString();

				drEdit["Ended"] = false;

				txtXuong.Text = "0";
			}
			else
			{
				txtGio_Begin.Text = drEdit["Gio_Begin"].ToString();
				txtGio_End.Text = drEdit["Gio_End"].ToString();
			}

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}
        public void Load(enuEdit enuNew_Edit, DataRow drEdit, string strLoai)
        {
            this.drEdit = drEdit;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.strLoai = strLoai;

            Common.ScaterMemvar(this, ref drEdit);

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                int iMa_Ca = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(Ma_Ca)) AS BIGINT)), 0) + 1 FROM R81DMCA"));

                if (strLoai == "CAN")
                {
                    if (iMa_Ca.ToString().EndsWith("0") || iMa_Ca.ToString().EndsWith("2") || iMa_Ca.ToString().EndsWith("4") || iMa_Ca.ToString().EndsWith("6") || iMa_Ca.ToString().EndsWith("8")) //Mã Ca tăng theo số lẻ 1,3, 5, 7, 9
                        iMa_Ca++;
                }
                //else
                //{
                //    if (iMa_Ca.ToString().EndsWith("1") || iMa_Ca.ToString().EndsWith("3") || iMa_Ca.ToString().EndsWith("5") || iMa_Ca.ToString().EndsWith("7") || iMa_Ca.ToString().EndsWith("9")) //Mã Ca tăng theo số lẻ 1,3, 5, 7, 9
                //        iMa_Ca++;
                //}

                DateTime dtNgay_Sx = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNow()"));
                DateTime dtNgay_Sx1 = Common.GetDate(dtNgay_Sx.Year, 1, 1);
                DateTime dtNgay_Sx2 = Common.GetDate(dtNgay_Sx.Year, 12, 31);
                System.Collections.Hashtable htPara = new System.Collections.Hashtable();
                htPara.Add("NGAY_SX1", dtNgay_Sx1);
                htPara.Add("NGAY_SX2", dtNgay_Sx2);
				
				int iSo_Ca = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(So_Ca), 0) + 1 FROM R81DMCA WHERE Ngay_Sx BETWEEN @Ngay_Sx1 AND @Ngay_Sx2 " +
						"AND Loai LIKE '" + strLoai + "%' AND Ma_Ca > '1008850'", htPara, CommandType.Text));

				if (iMa_Ca == 1008851)
                    iSo_Ca = 3;

				//if (dtNgay_Sx2.Year == 2025 && strLoai == "CANGC" && iSo_Ca == 1)
				//	iSo_Ca = 900;

				if (Common.InlistLike(strLoai, "CAN"))
					numSo_Ca.Value = iSo_Ca;
				else
                    numSo_Ca.Value = 0;

                txtMa_Ca.Text = Convert.ToString(iMa_Ca);
                dteNgay_Sx.Text = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNow()")).ToShortDateString();

                drEdit["Ended"] = false;
            }
            else
            {
                txtGio_Begin.Text = drEdit["Gio_Begin"].ToString();
                txtGio_End.Text = drEdit["Gio_End"].ToString();
            }
			if (strLoai == "CANGC")
			{
				lblTC.Visible = false;
				txtMa_Dt_CbNv_TC.Visible = false;
				lbtTen_CbNv_TC.Visible = false;

				lblNVCan.Visible = false;
				txtMa_Dt_CbNv_Can.Visible = false;
				lbtTen_CbNv_Can.Visible = false;
			}
			else
            {
				lblXuong.Visible = false;
				lblXuong1.Visible = false;
				txtXuong.Visible = false;
			}
			
			BindingLanguage();
            LoadDicName();

            this.ShowDialog();
        }
		private void LoadDicName()
		{
			//Truong ca
			if (txtMa_Dt_CbNv_TC.Text.Trim() != string.Empty)
				lbtTen_CbNv_TC.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv_TC.Text.Trim());
			else
				lbtTen_CbNv_TC.Text = string.Empty;
			
			//KCS
			if (txtMa_Dt_CbNv_KCS.Text.Trim() != string.Empty)
				lbtTen_CbNv_KCS.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv_KCS.Text.Trim());
			else
				lbtTen_CbNv_KCS.Text = string.Empty;

			//CAN
			if (txtMa_Dt_CbNv_Can.Text.Trim() != string.Empty)
				lbtTen_CbNv_Can.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv_Can.Text.Trim());
			else
				lbtTen_CbNv_Can.Text = string.Empty;

		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
			if (cboCa.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ca") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (dteNgay_Sx.IsNull)
			{
				Common.MsgOk(Languages.GetLanguage("Ngay_Sx") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtGio_Begin.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Gio_Begin") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtGio_End.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Gio_End") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Dt_CbNv_TC.Text.Trim() == string.Empty && strLoai!="CANGC")
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Dt_CbNv_TC") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Dt_CbNv_KCS.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Dt_CbNv_KCS") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Dt_CbNv_Can.Text.Trim() == string.Empty && strLoai != "CANGC")
			{
				Common.MsgOk(Languages.GetLanguage("Ma_Dt_CbNv_Can") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}
            if (enuNew_Edit == enuEdit.New & DataTool.SQLCheckExist("R81DMCA", new string[] { "Ngay_Sx", "Kip" ,"Ca", "Loai","Xuong"}, 
					new string[] { dteNgay_Sx.Text, txtKip.Text, cboCa.Text, strLoai, txtXuong.Text}))
            {

                Common.MsgOk("Ngày sản xuất " + dteNgay_Sx.Text + " ca sản xuất đã tồn tại ");
                return false;
            }
            // không tạo ca của ngày kế tiếp
            DateTime dteNgay_Server = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNow()"));
            if (enuNew_Edit == enuEdit.New & Convert.ToDateTime(dteNgay_Sx.Text) > dteNgay_Server)
            {
                Common.MsgOk("Ngày sản xuất " + dteNgay_Sx.Text + " không lớn hơn " + dteNgay_Server.ToShortDateString() + "");
                return false;
            }
            //Kiểm tra kíp và giờ
            if ((txtKip.Text == "1" && txtGio_Begin.Text == "19:30" && txtGio_End.Text == "07:30") || (txtKip.Text == "2" && txtGio_Begin.Text == "07:30" && txtGio_End.Text == "19:30"))
            {
                Common.MsgOk("Kíp sản xuất và thời gian không tương thích. Vui lòng kiểm tra lại.");
                return false;
            }

            return bvalid;
        }

		public override bool Save()
		{
			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			Common.GatherMemvar(this, ref drEdit);
            drEdit["Loai"] = strLoai;
			drEdit["Gio_Begin"] = txtGio_Begin.Text;
			drEdit["Gio_End"] = txtGio_End.Text;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
            {
                drEdit["Create_Log"] = Common.GetCurrent_Log();
                drEdit["LastModify_Log"] = "";
            }
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			if (txtXuong.Text != "0")
				drEdit["Loai"] = strLoai + txtXuong.Text;
			
			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMCA", ref drEdit))
				return false;

			return true;
		}

        #endregion

        #region Su kien

		void txtMa_Dt_CbNv_TC_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv_TC.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "Ngay_Nghi_Lam = '19000101'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv_TC.Text = string.Empty;
				lbtTen_CbNv_TC.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv_TC.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_CbNv_TC.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void txtMa_Dt_CbNv_KCS_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv_KCS.Text.Trim();
			bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "Ngay_Nghi_Lam = '19000101'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv_KCS.Text = string.Empty;
				lbtTen_CbNv_KCS.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv_KCS.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_CbNv_KCS.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void txtMa_Dt_CbNv_Can_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv_Can.Text.Trim();
			bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "Ngay_Nghi_Lam = '19000101'");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv_Can.Text = string.Empty;
				lbtTen_CbNv_Can.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv_Can.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_CbNv_Can.Text = drLookup["Ten_Dt"].ToString();
			}
		}

        #endregion		

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin)
			{
				txtMa_Ca.ReadOnly = true;

				if (!Common.CheckPermission("ACCESS_NGAY_SX", enuPermission_Type.Allow_Access) && enuNew_Edit == enuEdit.Edit)
					dteNgay_Sx.Enabled = false;
			}
		}
	}
}