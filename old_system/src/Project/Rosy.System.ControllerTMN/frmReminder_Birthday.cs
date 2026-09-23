using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RosySystem.Element;
using RosySystem.Data;

namespace RosyControllerTMN
{
	public partial class frmReminder_Birthday : RosySystem.Customize.frmView
	{
		DataTable dtReminder_Birthday = new DataTable();
		BindingSource bdsReminder_Birthday = new BindingSource();

		public frmReminder_Birthday()
		{
			InitializeComponent();
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.BindingLanguage();

			this.Show();
		}

		void Build()
		{
			dgvReminder_Birthday.strZone = "DMDTCBNV";
			dgvReminder_Birthday.BuildGridView();
		}

		private void FillData()
		{
			string strSQLExec = @"
				SELECT T1.*, ISNULL(T2.Ten_Bp, '') AS Ten_Bp
					FROM R81DmDt T1 LEFT JOIN R81DmBp T2 ON T1.Ma_Bp = T2.Ma_Bp
					WHERE (T1.Ma_Data = '" + Element.sysMa_DvCs + @"' OR T1.Ma_Data = '*') AND (T1.Ngay_Nghi_Lam = '19000101') AND (T1.Ma_Nh_Dt IN (SELECT Ma_Nh_Dt FROM R81DMNHDT WHERE Loai_Nh_Dt = 'NV')) AND (MONTH(T1.Ngay_Sinh) = MONTH(GETDATE()))
					ORDER BY T1.Ma_Bp";

			dtReminder_Birthday = SQLExec.ExecuteReturnDt(strSQLExec);

			bdsReminder_Birthday.DataSource = dtReminder_Birthday;
			dgvReminder_Birthday.DataSource = bdsReminder_Birthday;

			ExportControl = dgvReminder_Birthday;
			bdsSearch = bdsReminder_Birthday;
		}
	}
}
