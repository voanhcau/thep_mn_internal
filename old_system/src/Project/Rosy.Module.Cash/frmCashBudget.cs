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

namespace RosyModule.Cash
{
	public partial class frmCashBudget : RosySystem.Customize.frmView
	{
		DataTable dtCashBudget;
		DataTable dtCashBudgetCt;

		BindingSource bdsCashBudget = new BindingSource();
		BindingSource bdsCashBudgetCt = new BindingSource();

		DataRow drCurrent;

		public frmCashBudget()
		{
			InitializeComponent();

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btExit.Click += new EventHandler(btExit_Click);
		}

		public void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		void Build()
		{
			dgvCashBudget.strZone = "CASHBUDGET";
			dgvCashBudget.BuildGridView();

			dgvCashBudgetCt.strZone = "CASHBUDGETCT";
			dgvCashBudgetCt.BuildGridView();

			splitContainer1.Panel1Collapsed = false;
			splitContainer1.Panel2Collapsed = true;
		}

		void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("THANG", 0);
			htPara.Add("NAM", Element.sysWorkingYear);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtCashBudget = SQLExec.ExecuteReturnDt("sp_CASH_GetCashBudget", htPara, CommandType.StoredProcedure);

			bdsCashBudget.DataSource = dtCashBudget;
			dgvCashBudget.DataSource = bdsCashBudget;

			bdsSearch = bdsCashBudget;
			ExportControl = dgvCashBudget;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (splitContainer1.Panel2Collapsed)
				return;

			if (bdsCashBudgetCt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCashBudgetCt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCashBudgetCt.Current).Row, ref drCurrent);
			else
				drCurrent = dtCashBudgetCt.NewRow();

			DataRow drParent = ((DataRowView)bdsCashBudget.Current).Row;
			if (enuNew_Edit == enuEdit.New)
			{
				if (drCurrent["Ngay_Ct"] == DBNull.Value)
					drCurrent["Ngay_Ct"] = Common.GetDate(Element.sysWorkingYear, (int)drParent["Thang"], 1);
			}

			frmCashBudget_Edit frmEdit = new frmCashBudget_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCashBudgetCt.Position >= 0)
						dtCashBudgetCt.ImportRow(drCurrent);
					else
						dtCashBudgetCt.Rows.Add(drCurrent);

					bdsCashBudgetCt.Position = bdsCashBudgetCt.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCashBudgetCt.Current).Row);

				numTTien_Thu.Value = Common.SumDCValue(dtCashBudgetCt, "Tien_Thu_Kh", "");
				numTTien_Chi.Value = Common.SumDCValue(dtCashBudgetCt, "Tien_Chi_Kh", "");
				numTTien_Thu_Nt.Value = Common.SumDCValue(dtCashBudgetCt, "Tien_Thu_Kh_Nt", "");
				numTTien_Chi_Nt.Value = Common.SumDCValue(dtCashBudgetCt, "Tien_Chi_Kh_Nt", "");

				dtCashBudgetCt.AcceptChanges();
			}
		}

		public override void Delete()
		{
			if (splitContainer1.Panel2Collapsed)
				return;

			if (bdsCashBudgetCt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCashBudgetCt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R01CashBudget", drCurrent))
			{
				bdsCashBudgetCt.RemoveAt(bdsCashBudgetCt.Position);
				dtCashBudgetCt.AcceptChanges();
			}
		}

		void EnterValid()
		{
			Hashtable htPara = new Hashtable();
			htPara["THANG"] = ((DataRowView)bdsCashBudget.Current)["Thang"];
			htPara["NAM"] = Element.sysWorkingYear;
			htPara["MA_DVCS"] = Element.sysMa_DvCs;

			dtCashBudgetCt = SQLExec.ExecuteReturnDt("sp_CASH_GetCashBudget", htPara, CommandType.StoredProcedure);

			bdsCashBudgetCt.DataSource = dtCashBudgetCt;
			dgvCashBudgetCt.DataSource = bdsCashBudgetCt;

			splitContainer1.Panel1Collapsed = true;
			splitContainer1.Panel2Collapsed = false;

			bdsSearch = bdsCashBudgetCt;
			ExportControl = dgvCashBudgetCt;

			numTTien_Thu.Value = Common.SumDCValue(dtCashBudgetCt, "Tien_Thu_Kh", "");
			numTTien_Chi.Value = Common.SumDCValue(dtCashBudgetCt, "Tien_Chi_Kh", "");
			numTTien_Thu_Nt.Value = Common.SumDCValue(dtCashBudgetCt, "Tien_Thu_Kh_Nt", "");
			numTTien_Chi_Nt.Value = Common.SumDCValue(dtCashBudgetCt, "Tien_Chi_Kh_Nt", "");

			dgvCashBudgetCt.Focus();
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

		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					EnterValid();
					return;

				case Keys.Escape:
					if (dgvCashBudgetCt.Visible)
					{
						splitContainer1.Panel1Collapsed = false;
						splitContainer1.Panel2Collapsed = true;

						bdsSearch = bdsCashBudget;
						ExportControl = dgvCashBudget;

						((DataRowView)bdsCashBudget.Current).Row["Tien_Thu_Kh"] = Common.SumDCValue(dtCashBudgetCt, "Tien_Thu_Kh", "");
						((DataRowView)bdsCashBudget.Current).Row["Tien_Chi_Kh"] = Common.SumDCValue(dtCashBudgetCt, "Tien_Chi_Kh", "");
						((DataRowView)bdsCashBudget.Current).Row["Tien_Thu_Kh_Nt"] = Common.SumDCValue(dtCashBudgetCt, "Tien_Thu_Kh_Nt", "");
						((DataRowView)bdsCashBudget.Current).Row["Tien_Chi_Kh_Nt"] = Common.SumDCValue(dtCashBudgetCt, "Tien_Chi_Kh_Nt", "");

						dgvCashBudget.Focus();
					}
					else
						this.Close();
					return;

			}

			if (this.ActiveControl == dgvCashBudgetCt)
			{
				switch (e.KeyCode)
				{
					case Keys.F2:
						this.Edit(enuEdit.New);
						return;

					case Keys.F3:
						this.Edit(enuEdit.Edit);
						return;

					case Keys.F8:
						this.Delete();
						return;
				}
			}

			base.OnKeyDown(e);
		}
	}
}
