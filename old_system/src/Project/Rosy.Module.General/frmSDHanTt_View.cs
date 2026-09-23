using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem;
using RosySystem.Element;

namespace RosyModule.General
{
	public partial class frmSDHanTt_View : RosyList.frmView
	{
		#region Khai bao bien

		private DataTable dtSdHtt;
		private DataRow drCurrent;
		private BindingSource bdsSdHtt = new BindingSource();
		private rsDataGridView dgvSdHtt = new rsDataGridView();
		public bool bLookupByGroup = false;

		#endregion 

		#region Contructor
		public frmSDHanTt_View()
		{
			InitializeComponent();

			btImport.Click += new EventHandler(btImport_Click);
		}
			
		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}
		
		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvSdHtt.Dock = DockStyle.Fill;
			dgvSdHtt.strZone = "CDHTT_VIEW";

			dgvSdHtt.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvSdHtt);
			this.ExportControl = dgvSdHtt;
		}

		private void FillData()	
		{
			//dtSdHtt = SQLExec.ExecuteReturnDt("sp_GetCDHanTt '" + Element.sysMa_DvCs + "'");
            dtSdHtt = DataTool.SQLGetDataTable("R80SdHanTt", "", "Nam = " + Element.sysWorkingYear.ToString() + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'", "Tk, Ma_Dt, Stt, Ngay_Ct, Ma_Ct, So_Ct");
            //dtSdHtt = DataTool.SQLGetDataTable("R80SdHanTt", null, null, null);

			bdsSdHtt.DataSource = dtSdHtt;
			dgvSdHtt.DataSource = bdsSdHtt;

			if (bdsSdHtt.Count >= 0)
				bdsSdHtt.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsSdHtt;
		}

		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsSdHtt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsSdHtt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsSdHtt.Current).Row, ref drCurrent);
			else
				drCurrent = dtSdHtt.NewRow();

			//Kiểm tra khóa số dư
			if (enuNew_Edit == enuEdit.New)
			{
				string strSQLExec =
					"SELECT TOP 1 Locked_SdHanTt FROM R00Nam " +
						" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

				if ((bool)SQLExec.ExecuteReturnValue(strSQLExec))
				{
					Common.MsgCancel("Số dư đầu đã khóa!");
					return;
				}
			}

			frmSDHanTt_Edit frmEdit = new frmSDHanTt_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsSdHtt.Position >= 0)
						dtSdHtt.ImportRow(drCurrent);
					else
						dtSdHtt.Rows.Add(drCurrent);

					bdsSdHtt.Position = bdsSdHtt.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsSdHtt.Current).Row);
				}

				dtSdHtt.AcceptChanges();
			}
			//else
			//    dtCdHtt.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsSdHtt.Position < 0)
				return;

			//Kiểm tra khóa số dư
			string strSQLExec0 =
				"SELECT TOP 1 Locked_SdHanTt FROM R00Nam " +
					" WHERE Nam = " + Element.sysWorkingYear + " AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";

			if ((bool)SQLExec.ExecuteReturnValue(strSQLExec0))
			{
				Common.MsgCancel("Số dư đầu đã khóa!");
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			drCurrent = ((DataRowView)bdsSdHtt.Current).Row;
			string strStt = (string)drCurrent["Stt"];

			string strSQLExec = string.Empty;

			//if((bool)drCurrent["Is_UngTruoc"])
			//    strSQLExec = "DELETE FROM R80UNGTRUOC WHERE Stt = '" + strStt + "' ;" +
			//                   "DELETE FROM R80HANTT0 WHERE Stt = '" + strStt + "'";				 
			//else
			//    strSQLExec = "DELETE FROM R80HANTT WHERE Stt = '" + strStt + "' ;" +
			//                    "DELETE FROM R80HANTT0 WHERE Stt_Hd = '" + strStt + "'";

			strSQLExec = "DELETE FROM R80SdHanTt WHERE Stt = '" + strStt + "'";

			if (SQLExec.Execute(strSQLExec))
			{
				bdsSdHtt.RemoveAt(bdsSdHtt.Position);
				dtSdHtt.AcceptChanges();
			}
		}

		#endregion 

		void btImport_Click(object sender, EventArgs e)
		{
			Voucher.ImportExcel_SDHanTt("SDHanTt", dtSdHtt);
		}
	}	
}