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

namespace RosyModule.Salary
{
	public partial class frmChamCong : RosySystem.Customize.frmView
	{
		DataTable dtDmCa;
		BindingSource bdsDmCa = new BindingSource();
		DataRow drCurrent;

        public frmChamCong()
		{
			InitializeComponent();
            //this.btContinues.Click += new EventHandler(btContinues_Click);
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
			dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct1);

            //dgvDmCa.strZone = "DMCA";
            //dgvDmCa.BuildGridView();
		}

		private void FillData()
		{

            dtDmCa = SQLExec.ExecuteReturnDt("sp_GetChamCong", CommandType.StoredProcedure);
			bdsDmCa.DataSource = dtDmCa;
            //dgvDmCa.DataSource = bdsDmCa;
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
