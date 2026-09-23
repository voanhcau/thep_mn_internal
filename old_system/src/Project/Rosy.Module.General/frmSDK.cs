using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Element;

namespace RosyModule.General
{
	public partial class frmSDK : RosyList.frmView
	{
		#region Fields

		private DataTable dtSDK;
		private DataRow drCurrent;
		private BindingSource bdsSDK = new BindingSource();
		private rsDataGridView dgvSDK = new rsDataGridView();

		#endregion

		#region Methods

		public frmSDK()
		{
			InitializeComponent();

			btImport.Click += new EventHandler(btImport_Click);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		private void Build()
		{
			this.dgvSDK.strZone = "SDK_VIEW";
			this.dgvSDK.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvSDK);

			this.dgvSDK.BuildGridView();
		}

		private void FillData()
		{
			string[] strArrName = { "Tk", "Nam", "Child", "Ma_DvCs" };
			object[] objArrValue = { "", Element.sysWorkingYear, false, Element.sysMa_DvCs };

			dtSDK = SQLExec.ExecuteReturnDt("Sp_GetSDK", strArrName, objArrValue, CommandType.StoredProcedure);
			dtSDK.Columns.Add("Bold", typeof(bool), "Have_Child");

			bdsSDK.DataSource = dtSDK;
			bdsSDK.Position = 0;
			//bdsSDK.Filter = "TRIM(Ma_Dt) = '' AND TRIM(Ma_Vt_Sp) = ''";

			dgvSDK.DataSource = bdsSDK;

			this.ExportControl = dgvSDK;
			this.bdsSearch = bdsSDK;
		}

		public override void EnterProcess()
		{
			Detail();
		}

		private void Detail()
		{
			drCurrent = ((DataRowView)bdsSDK.Current).Row;

			if (!(bool)drCurrent["Have_Child"])
				return;

			frmSDKCt frmDetail = new frmSDKCt();
			frmDetail.MdiParent = this.MdiParent;
			frmDetail.Load((string)drCurrent["Tk"]);

			this.UpdateTotal(drCurrent);
		}

		private void UpdateTotal(DataRow dr)
		{
			string strTk = ((string)dr["Tk"]).Trim();

			string[] strArrName = { "Tk", "Nam", "Child", "Ma_DvCs" };
			object[] objArrValue = { strTk, Element.sysWorkingYear,true, Element.sysMa_DvCs };

			DataTable dtTotal = SQLExec.ExecuteReturnDt("Sp_GetSDK", strArrName, objArrValue, CommandType.StoredProcedure);

			dr["Du_No"] = Common.SumDCValue(dtTotal, "Du_No", "");
			dr["Du_Co"] = Common.SumDCValue(dtTotal, "Du_Co", "");
			dr["Du_No_Nt"] = Common.SumDCValue(dtTotal, "Du_No_Nt", "");
			dr["Du_Co_Nt"] = Common.SumDCValue(dtTotal, "Du_Co_Nt", "");
			dr["Du_No0"] = Common.SumDCValue(dtTotal, "Du_No0", "");
			dr["Du_Co0"] = Common.SumDCValue(dtTotal, "Du_Co0", "");
			dr["Du_No_Nt0"] = Common.SumDCValue(dtTotal, "Du_No_Nt0", "");
			dr["Du_Co_Nt0"] = Common.SumDCValue(dtTotal, "Du_Co_Nt0", "");
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsSDK.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsSDK.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsSDK.Current).Row, ref drCurrent);
			else
				drCurrent = dtSDK.NewRow();

			//Neu co chi tiet thi vao chi tiet
			if (enuNew_Edit == enuEdit.Edit && ((bool)drCurrent["Have_Child"]))
			{
				this.Detail();
				return;
			}

			//Kiểm tra khóa số dư
			if (enuNew_Edit == enuEdit.New)
			{
				string strSQLExec =
					"SELECT TOP 1 Locked_Sdk FROM R00Nam " +
						" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

				if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
				{
					Common.MsgCancel("Số dư đầu đã khóa!");
					return;
				}
			}

			frmSDK_Edit frmEdit = new frmSDK_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				//Kiem tra Tk_Dt, Tk_Sp
				if ((bool)drCurrent["Tk_Dt"] || (bool)drCurrent["Tk_Sp"])
				{
					drCurrent["Ma_Dt"] = string.Empty;
					drCurrent["Ma_Vt_Sp"] = string.Empty;
					drCurrent["Have_Child"] = 1;

					//Neu da ton tai Tk roi thi khong can them vao nua
					int iCurrent = bdsSDK.Find("Tk", (string)drCurrent["Tk"]);

					if (iCurrent >= 0)
					{
						dtSDK.RejectChanges();

						bdsSDK.Position = iCurrent;
						drCurrent = ((DataRowView)bdsSDK.Current).Row;

						this.UpdateTotal(drCurrent);

						return;
					}

					this.UpdateTotal(drCurrent);
				}

				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsSDK.Position >= 0)
						dtSDK.ImportRow(drCurrent);
					else
						dtSDK.Rows.Add(drCurrent);

					bdsSDK.Position = bdsSDK.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsSDK.Current).Row);
				
				dtSDK.AcceptChanges();

			}
			//else
			//    dtSDK.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsSDK.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsSDK.Current).Row;

			//Neu co chi tiet thi vao chi tiet
			if ((bool)drCurrent["Have_Child"])
			{
				this.Detail();
				return;
			}

			//Kiểm tra khóa số dư
			string strSQLExec =
				"SELECT TOP 1 Locked_Sdk FROM R00Nam " +
					" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
			{
				Common.MsgCancel("Số dư đầu đã khóa!");
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R80SDK", drCurrent))
			{
				bdsSDK.RemoveAt(bdsSDK.Position);
				dtSDK.AcceptChanges();
			}
		}

		#endregion

		#region Events	
		protected override void OnClosed(EventArgs e)
		{
			double dbTDu_No = Common.SumDCValue(dtSDK, "Du_No", "");
			double dbTDu_Co = Common.SumDCValue(dtSDK, "Du_Co", "");

			if (dbTDu_No - dbTDu_Co != 0)
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Số dư đầu không cân\n Tổng(Dư nợ - Dư có):\n" : "Opening balance error\n Amount(Debit - Credit):\n";
				strMsg += dbTDu_No.ToString("N") + " - " + dbTDu_Co.ToString("N") + " = " + (dbTDu_No - dbTDu_Co).ToString("N");
				Common.MsgOk(strMsg);
			}
			base.OnClosed(e);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			Voucher.ImportExcel_SDK("SDK", dtSDK);
		}

		#endregion
	}
}
