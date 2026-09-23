using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosyList;
using RosySystem;
using RosySystem.Library;
using RosySystem.Element;

namespace RosyModule.Inventory
{
	public partial class frmQuery_Shift : RosySystem.Customize.frmView
	{
		DataTable dtDmCa;
		BindingSource bdsDmCa = new BindingSource();
		DataRow drCurrent;

		public frmQuery_Shift()
		{
			InitializeComponent();
			this.btContinues.Click += new EventHandler(btContinues_Click);
			this.btNew.Click += new EventHandler(btNew_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
			this.btFilter.Click += new EventHandler(btFilter_Click);
		}

		new public void Load()
		{
			this.Build();
			this.BindingLanguage();

			this.Show();
		}

		private void Build()
		{
			dteNgay_Ct1.Text = Library.DateToStr(Voucher.GetDate_Server());
			dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server());

			dgvDmCa.strZone = "DMCA";
			dgvDmCa.BuildGridView();
		}

		private void FillData()
		{
			string strSQLExec = @"SELECT	T1.Ma_Ca, 
											T1.Ngay_Sx, 
											T1.Ca, 
											T1.Gio_Begin, T1.Gio_End, 
											T1.Ma_Dt_CbNv_TC, T2.Ten_Dt AS Ten_Dt_CbNv_TC,
											T1.Ma_Dt_CbNv_KCS, T3.Ten_Dt AS Ten_Dt_CbNv_KCS, 
											T1.Ma_Dt_CbNv_Can, T4.Ten_Dt AS Ten_Dt_CbNv_Can, 
											T1.Ended
										FROM R81DMCA T1 JOIN R81DMDT T2 ON T1.Ma_Dt_CbNv_TC = T2.Ma_Dt
													JOIN R81DMDT T3 ON T1.Ma_Dt_CbNv_KCS = T3.Ma_Dt
													JOIN R81DMDT T4 ON T1.Ma_Dt_CbNv_Can = T4.Ma_Dt
										WHERE Ngay_Sx >= '" + dteNgay_Ct1.Text + "' AND Ngay_Sx <= '" + dteNgay_Ct2.Text + "'" + @"
										ORDER BY Ngay_Sx";

			dtDmCa = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
			bdsDmCa.DataSource = dtDmCa;
			dgvDmCa.DataSource = bdsDmCa;
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btContinues_Click(object sender, EventArgs e)
		{
			if (bdsDmCa.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmCa.Current).Row;
			string strMethod = DataTool.SQLGetNameByCode("R00OBJECT", "Object_ID", "Object_Cmd", "CT_PNTH");
			string strParameter = "S[" + (string)drCurrent["Ma_Ca"] + "]";
			Common.RunMethod(strMethod, strParameter);
			this.Close();
		}

		void btNew_Click(object sender, EventArgs e)
		{
			//Copy hang hien tai            
			if (bdsDmCa.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmCa.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmCa.NewRow();

			frmDmCa_Edit frmEdit = new frmDmCa_Edit();
			frmEdit.Load(enuEdit.New, drCurrent);

			// Người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (bdsDmCa.Position >= 0)
					dtDmCa.ImportRow(drCurrent);
				else
					dtDmCa.Rows.Add(drCurrent);

				bdsDmCa.Position = bdsDmCa.Find("MA_CA", drCurrent["MA_CA"]);

				dtDmCa.AcceptChanges();
			}
			else
				dtDmCa.RejectChanges();
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
