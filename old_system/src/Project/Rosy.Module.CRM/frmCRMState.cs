using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Customize;

namespace RosyModule.CRM
{
	public partial class frmCRMState : RosySystem.Customize.frmView
	{
		ucChart chart1 = new ucChart();

		public frmCRMState()
		{
			InitializeComponent();
		}

		public override void Load()
		{
			chart1.Dock = DockStyle.Fill;
			this.Controls.Add(chart1);

			this.FillData();

			this.Show();
		}

		void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara["MEMBER_ID"] = Element.sysUser_Id;
			htPara["MA_DVCS"] = Element.sysMa_DvCs;

			DataSet dsCRMState = SQLExec.ExecuteReturnDs("sp_CRMState", htPara, CommandType.StoredProcedure);

			if (dsCRMState != null)
			{
				string strColX = dsCRMState.Tables[1].Rows[0]["ColX"].ToString();
				string strColY = dsCRMState.Tables[1].Rows[0]["ColY"].ToString();
				string strChartType = dsCRMState.Tables[1].Rows[0]["ChartType"].ToString();
				string strTitle = dsCRMState.Tables[1].Rows[0]["Title"].ToString().ToUpper();

				chart1.Load(strColX, strColY, dsCRMState.Tables[0], strTitle, "", strChartType);
			}
		}

		void cboMa_Nhom_SelectedValueChanged(object sender, EventArgs e)
		{
			this.FillData();			
		}
	}
}
