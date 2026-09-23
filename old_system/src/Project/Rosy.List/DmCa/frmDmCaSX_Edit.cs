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
	public partial class frmDmCaSX_Edit : RosyList.frmEdit
	{		

        #region Phuong thuc

        public frmDmCaSX_Edit()
		{
			InitializeComponent();

			cboCa.TextChanged += new EventHandler(cboCa_TextChanged);
		}

		void cboCa_TextChanged(object sender, EventArgs e)
		{
			if (cboCa.Focused && cboCa.Text != "")
			{
                string strSQL = @"
					SELECT * FROM R81DMCASX T1 WITH (NOLOCK)
						WHERE Ngay_Sx IN 
							(
							SELECT MAX(Ngay_Sx)
								FROM R81DMCASX  WITH (NOLOCK)
								WHERE Ca = '" + cboCa.Text + @"' 
						AND Ca = '" + cboCa.Text + @"'";

                DataTable dtCa = SQLExec.ExecuteReturnDt(strSQL);
                //DataTable dtCa = DataTool.SQLGetDataTable("R81DMCASX", null, strKey, "Ma_Ca DESC");
				if (dtCa != null && dtCa.Rows.Count > 0)
				{
					txtGio_Begin.Text = dtCa.Rows[0]["Gio_Begin"].ToString();
					txtGio_End.Text = dtCa.Rows[0]["Gio_End"].ToString();
					

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
                //int iMa_Ca = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(CAST(RTRIM(LTRIM(Ma_Ca)) AS BIGINT)), 0) + 1 FROM R81DMCA"));

                //if (iMa_Ca.ToString().EndsWith("0") || iMa_Ca.ToString().EndsWith("2") || iMa_Ca.ToString().EndsWith("4") || iMa_Ca.ToString().EndsWith("6") || iMa_Ca.ToString().EndsWith("8")) //Mã Ca tăng theo số lẻ 1,3, 5, 7, 9
                //    iMa_Ca++;

                //DateTime dtNgay_Sx = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNow()"));
                //DateTime dtNgay_Sx1 = Common.GetDate(dtNgay_Sx.Year, 1, 1);
                //DateTime dtNgay_Sx2 = Common.GetDate(dtNgay_Sx.Year, 12, 31);
                //System.Collections.Hashtable htPara = new System.Collections.Hashtable();
                //htPara.Add("NGAY_SX1", dtNgay_Sx1);
                //htPara.Add("NGAY_SX2", dtNgay_Sx2);

                //int iSo_Ca = Convert.ToInt32(SQLExec.ExecuteReturnValue("SELECT ISNULL(MAX(So_Ca), 0) + 1 FROM R81DMCASX WHERE Ngay_Sx BETWEEN @Ngay_Sx1 AND @Ngay_Sx2", htPara, CommandType.Text);

                //numSo_Ca.Value = iSo_Ca;
                //txtMa_Ca.Text = Convert.ToString(iMa_Ca);
                //dteNgay_Sx.Text = Convert.ToDateTime(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetNow()")).ToShortDateString();

				
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

		private void LoadDicName()
		{
			

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

			
            if (enuNew_Edit == enuEdit.New & DataTool.SQLCheckExist("R81DMCASX", new string[] { "Ngay_Sx", "Kip" ,"Ca"}, new string[] { dteNgay_Sx.Text, txtKip.Text, cboCa.Text}))
            {
                Common.MsgOk("Ngày sản xuất " + dteNgay_Sx.Text + " ca sản xuất đã tồn tại ");
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

			drEdit["Gio_Begin"] = txtGio_Begin.Text;
			drEdit["Gio_End"] = txtGio_End.Text;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            
			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81DMCASX", ref drEdit))
				return false;

			return true;
		}

        #endregion

        #region Su kien

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