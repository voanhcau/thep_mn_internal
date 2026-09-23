using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosyList;
using RosySystem.Public;
using RosySystem.Common;
using RosySystem.Customize;

namespace RosyModule.Salary
{
	public partial class frmHsABC : RosySystem.Customize.frmView
	{
		DataTable dtHieuQua;
		BindingSource bdsHieuQua = new BindingSource();
        string strMa_Bp = string.Empty;
        DateTime dteNgay_Ct1; DateTime dteNgay_Ct2;
		DataRow drCurrent;

        public frmHsABC()
		{
			InitializeComponent();

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btExit.Click += new EventHandler(btExit_Click);
		}

		public void Load(string strMa_Bp, DateTime dteNgay_Ct1, DateTime dteNgay_Ct2)
		{
            this.strMa_Bp = strMa_Bp;
            this.dteNgay_Ct1 = dteNgay_Ct1;
            this.dteNgay_Ct2 = dteNgay_Ct2;
			this.Build();
			this.FillData();
			this.BindingLanguage();
            //this.ShowDialog();
            this.Show();
		}

		void Build()
		{
			dgvHieuQua.strZone = "HSABC";
			dgvHieuQua.BuildGridView();
		}

		void FillData()
		{
		
            Hashtable ht = new Hashtable();
            ht.Add("MA_BP", strMa_Bp);
            ht.Add("NGAY_CT1", dteNgay_Ct1);
            ht.Add("NGAY_CT2", dteNgay_Ct2);

			dtHieuQua = SQLExec.ExecuteReturnDt("sp_GetHsABC", ht, CommandType.StoredProcedure);

        

			bdsHieuQua.DataSource = dtHieuQua;
			dgvHieuQua.DataSource = bdsHieuQua;

			//bdsHieuQua.Sort = "Bold, TK, MA_KM";

			bdsSearch = bdsHieuQua;
			ExportControl = dgvHieuQua;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsHieuQua.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			//if (bdsBudget.Position >= 0)
			if (enuNew_Edit == enuEdit.Edit)
				Common.CopyDataRow(((DataRowView)bdsHieuQua.Current).Row, ref drCurrent);
			else
				drCurrent = dtHieuQua.NewRow();

            //if (enuNew_Edit == enuEdit.New)
            //{
            //    drCurrent["Nam"] = Element.sysWorkingYear;
            //}

            frmHsABC_Edit frmEdit = new frmHsABC_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					//if (bdsBudget.Position >= 0)
					if (enuNew_Edit == enuEdit.Edit)
						dtHieuQua.ImportRow(drCurrent);
					else
						dtHieuQua.Rows.Add(drCurrent);

					bdsHieuQua.Position = bdsHieuQua.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsHieuQua.Current).Row);

				dtHieuQua.AcceptChanges();
			}
		}

		public override void Delete()
		{
			if (bdsHieuQua.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsHieuQua.Current).Row;
            string strCreate_User = (string)drCurrent["Create_Log"];

            if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                if(!Common.MsgOk("Bạn không được phép xóa! Liên hệ PCNTT để kiểm tra!!"))
                    return;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R10HsABC", drCurrent))
			{
				bdsHieuQua.RemoveAt(bdsHieuQua.Position);
				dtHieuQua.AcceptChanges();
			}
		}

		void btNew_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			this.Edit(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			this.Delete();
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btChart_Click(object sender, EventArgs e)
		{
			//string strColX = "Ma_Dt_CbNv";
			//string strColY = "Tien_DS";
			//string strChartType = drReport["ChartType"].ToString();
			//string strChart_Filter = drReport["Chart_Filter"].ToString();
			////string strTitle = drReport["Title"].ToString().ToUpper();
			//string strTitle = Element.sysLanguage == enuLanguageType.Vietnamese ? (string)drReport["Title"] : (Element.sysLanguage == enuLanguageType.English ? (string)drReport["TitleE"] : (string)drReport["TitleO"]);
			//string strSubTitle = "";

			//if (drReport.Table.Columns.Contains("SubTitle1") && ((string)drReport["SubTitle1"]) != string.Empty)
			//    strSubTitle += (string)drReport["SubTitle1"] + "|";

			//if (drReport.Table.Columns.Contains("SubTitle2") && ((string)drReport["SubTitle2"]) != string.Empty)
			//    strSubTitle += (string)drReport["SubTitle2"] + "|";

			//DataTable dtChart = new DataTable();

			//if (strChart_Filter == "")
			//{
			//    dtChart = dtDetail.Copy();
			//}
			//else
			//{
			//    dtChart = dtDetail.Clone();

			//    foreach (DataRow dr in dtDetail.Select(strChart_Filter))
			//    {
			//        DataRow drNew = dtChart.NewRow();
			//        Common.CopyDataRow(dr, drNew);

			//        dtChart.Rows.Add(drNew);
			//    }
			//}

			//chart1.Load(strColX, strColY, dtChart, strTitle, strSubTitle, strChartType);

			//this.BindingLanguage();
		}
	}
}
