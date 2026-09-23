using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Element;

namespace RosyModule.Salary
{
	public partial class frmDuyet_PTCHC : RosySystem.Customize.frmView
	{
		public DataTable dtDuyet;
		BindingSource bdsDuyet = new BindingSource();

		DataRow drEdit;

		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
		DataRow drCurrent, drDmCt_Current;

		public frmDuyet_PTCHC()
		{
			InitializeComponent();

            //this.rsTabControl1.SelectedIndexChanged += new EventHandler(rsTabControl1_SelectedIndexChanged);

			this.chkDuyet_PTCHC.CheckedChanged += new EventHandler(chkDuyet_PKTTC_CheckedChanged);

			this.btSave.Click += new EventHandler(btSave_Click);
			this.btExit.Click += new EventHandler(btExit_Click);
		}

		public void Load()
		{
            //this.drEdit = drEdit;
			

			Build();
            FillData();
			BindingLanguage();
            //Common.ScaterMemvar(this, ref drEdit);
		    this.ShowDialog();
		}


		private void Build()
		{
		
			//dgvViewPh 
			
			dgvDuyet.strZone = "DUYET_LUONGVTRI";

			dgvDuyet.BuildGridView(false);

            dgvDuyet.ReadOnly = false;



            foreach (DataGridViewColumn dgvc in dgvDuyet.Columns)
                dgvc.ReadOnly = true;

            dgvDuyet.Columns["Chon"].ReadOnly = false;
            dgvDuyet.Columns["Ghi_Chu_TCHC"].ReadOnly = false;
			//Position
			//this.Controls.Add(dgvDuyet);
		
			//dgvDuyet.TabIndex = 0;
			
		
		}

		void FillData()
		{

            dtDuyet = SQLExec.ExecuteReturnDt("sp_GetLuongVtriNotDuyet", CommandType.StoredProcedure);

            bdsDuyet.DataSource = dtDuyet;
            dgvDuyet.DataSource = bdsDuyet;
		}


		private bool FormCheckValid()
		{
			//if (dteNgay_Ct.IsNull)
			//{
			//    Common.MsgCancel(Languages.GetLanguage("Ngay_Ct,Not_Null"));
			//    return false;
			//}

			return true;
		}

		private bool Save()
		{
			string strSQLExec = string.Empty;
			

            foreach (DataRow dr in dtDuyet.Select("Chon = 1"))
            {
                Hashtable htPara = new Hashtable();
                htPara.Add("IDENT00", dr["Ident00"]);
                htPara.Add("DUYET_TCHC", chkDuyet_PTCHC.Checked);
                htPara.Add("GHI_CHU_TCHC", dr["Ghi_Chu_TCHC"]);
                SQLExec.Execute("UPDATE R09LUONGTT SET Duyet_TCHC = @Duyet_TCHC, Ghi_Chu_TCHC = @Ghi_Chu_TCHC WHERE Ident00 = @Ident00",htPara, CommandType.Text);
            }

			return true;
		}

		void chkDuyet_PKTTC_CheckedChanged(object sender, EventArgs e)
		{
				this.txtDuyet_Log.Text = Common.GetCurrent_Log();
				

			this.btSave.Enabled = true;
		}

		

		void btSave_Click(object sender, EventArgs e)
		{
			if (this.FormCheckValid())
			{
				this.Save();
				this.Close();
			}
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			
		}
	}
}
