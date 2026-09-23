using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Library;
using RosySystem.Element;
using RosySystem.Common;
using System.Collections;
using RosySystem.Data;
using RosySystem.Public;
using RosySystem;

namespace RosyModule
{
    public partial class frmQuery_Permission : RosySystem.Customize.frmView
	{
		
	
		DataTable dtViewCt;
		
		BindingSource bdsViewCt = new BindingSource();
		DataRow drCurrent;
	
        public frmQuery_Permission()
		{
			InitializeComponent();

			this.txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
           
			
			dgvViewCt.Enter += new EventHandler(dgvViewCt_Enter);
	
		}

      
		new public void Load()
		{

            if(!Element.sysIs_Admin)
                txtMa_Dt_CbNv.Text = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
			
            this.Build();          
			this.BindingLanguage();
			this.Change_Language();
			this.Show();
		}

		private void Change_Language()
		{
			

            //if (dgvViewCt.Columns.Contains("Ngay_Nhap"))
            //    dgvViewCt.Columns["Ngay_Nhap"].HeaderText = "Ngày sản xuất";

            //if (dgvViewCt.Columns.Contains("So_Luong"))
            //    dgvViewCt.Columns["So_Luong"].HeaderText = "Khối lượng";
		}

		private void Build()
		{

            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.strLookupKeyFilter = "Ma_Nh_Dt = 'NV' AND Ngay_Nghi_Lam = '19000101'";
		
            dgvViewCt.strZone = "QUERY_PERMISSION";
			dgvViewCt.BuildGridView();
		}

		private void FillData()
		{
          
			Hashtable htPara = new Hashtable();
            htPara.Add("MEMBER_ID", txtMa_Dt_CbNv.Text);
            dtViewCt = SQLExec.ExecuteReturnDt("sp_QueryPermission", htPara, CommandType.StoredProcedure);

            //dtViewCt = dsVoucher.Tables[0];
		
			bdsViewCt.DataSource = dtViewCt;
			dgvViewCt.DataSource = bdsViewCt;

            this.bdsSearch = bdsViewCt;
            this.ExportControl = dgvViewCt;
			
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("MA_DT_CBNV", strValue, bRequire, "Ngay_Nghi_Lam = '19000101' AND Ma_Nh_Dt = 'NV'");

			if (drLookup == null && bRequire)
				e.Cancel = true;

			if (drLookup == null)
			{
                txtMa_Dt_CbNv.Text = string.Empty;
				lbtTen_Vt_Sp.Text = string.Empty;
			}
			else
			{
                txtMa_Dt_CbNv.Text = (string)drLookup["Ma_Dt"];
				lbtTen_Vt_Sp.Text = (string)drLookup["Ten_Dt"];

                FillData();
			}
		}

		void dgvViewCt_Enter(object sender, EventArgs e)
		{
            this.bdsSearch = bdsViewCt;
			this.ExportControl = sender;
		}

        //protected override void OnShown(EventArgs e)
        //{
        //    base.OnShown(e);
        //    this.txtMa_Dt_CbNv.Focus();
        //}
	}
}
