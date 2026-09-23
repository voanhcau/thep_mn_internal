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

namespace RosyModule.General
{
	public partial class frmChiPhiDK : RosySystem.Customize.frmView
	{
		DataTable dtBudget;
		BindingSource bdsBudget = new BindingSource();

		DataRow drCurrent;

		//string strTk = string.Empty;

		public frmChiPhiDK()
		{
			InitializeComponent();

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btExit.Click += new EventHandler(btExit_Click);
		}

		public void Load()
		{
			//this.strTk = strTk;

			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		void Build()
		{
			dgvBudget.strZone = "CHIPHIDK";
			dgvBudget.BuildGridView();
		}

		void FillData()
		{
			//Hashtable htPara = new Hashtable();
			//htPara.Add("NAM", Element.sysWorkingYear);
			//htPara.Add("TK", strTk);
			//htPara.Add("KIEU_TH", 1);
			//htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtBudget = SQLExec.ExecuteReturnDt("sp_ChiPhiDK_GetDK", CommandType.StoredProcedure);

			//DataColumn dcNew = new DataColumn("TTIEN_KH", typeof(double));
			//dcNew.Expression = "Tien_Kh01+Tien_Kh02+Tien_Kh03+Tien_Kh04+Tien_Kh05+Tien_Kh06+Tien_Kh07+Tien_Kh08+Tien_Kh09+Tien_Kh10+Tien_Kh11+Tien_Kh12";
			//dtBudget.Columns.Add(dcNew);

			bdsBudget.DataSource = dtBudget;
			dgvBudget.DataSource = bdsBudget;

			//bdsBudget.Sort = "Bold, TK, MA_KM";

			bdsSearch = bdsBudget;
			ExportControl = dgvBudget;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsBudget.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			//if (bdsBudget.Position >= 0)
			if (enuNew_Edit == enuEdit.Edit)
				Common.CopyDataRow(((DataRowView)bdsBudget.Current).Row, ref drCurrent);
			else
				drCurrent = dtBudget.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				//drCurrent["Nam"] = Element.sysWorkingYear;
				//drCurrent["Bold"] = false;
				//drCurrent["Tk"] = strTk;
			}

			frmChiPhiDK_Edit frmEdit = new frmChiPhiDK_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					//if (bdsBudget.Position >= 0)
					if (enuNew_Edit == enuEdit.Edit)
						dtBudget.ImportRow(drCurrent);
					else
						dtBudget.Rows.Add(drCurrent);

					bdsBudget.Position = bdsBudget.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsBudget.Current).Row);

				dtBudget.AcceptChanges();

				//this.Update_TTien();
			}
		}

		public override void Delete()
		{
			if (bdsBudget.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsBudget.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R80CHIPHIDK", drCurrent))
			{
				bdsBudget.RemoveAt(bdsBudget.Position);
				dtBudget.AcceptChanges();
			}
		}

		//void Update_TTien()
		//{
		//	DataRow drTotal = dtBudget.Select("Bold = true")[0];

		//	for (int iThang = 1; iThang <= 12; iThang++)
		//	{
		//		drTotal["Tien_Kh" + iThang.ToString().Trim().PadLeft(2, '0')] = Common.SumDCValue(dtBudget, "Tien_Kh" + iThang.ToString().Trim().PadLeft(2, '0'), "Bold = false");
		//	}
		//}

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
	}
}
