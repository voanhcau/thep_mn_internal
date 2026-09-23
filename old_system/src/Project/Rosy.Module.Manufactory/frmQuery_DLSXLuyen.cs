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
using System.Collections;

namespace RosyModule.Manufactory
{
	public partial class frmQuery_DLSXLuyen : RosySystem.Customize.frmView
	{
        //Luu y toi bManual
        object objActive = null;

		DataTable dtPh;
		BindingSource bdsPh = new BindingSource();
        DataTable dtSuCo;
        BindingSource bdsSuCo = new BindingSource();
        DataTable dtTSQT;
        BindingSource bdsTSQT = new BindingSource();
        DataTable dtPhoiNhap;
        BindingSource bdsPhoiNhap = new BindingSource();

		public frmQuery_DLSXLuyen()
		{
			InitializeComponent();
			
			
			this.btExit.Click += new EventHandler(btExit_Click);
			this.btFilter.Click += new EventHandler(btFilter_Click);

            dgvPhoiNhap.Enter += new EventHandler(dgvPhoiNhap_Enter);
            dgvTSQT.Enter += new EventHandler(dgvTSQT_Enter);
            dgvSuCo.Enter += new EventHandler(dgvSuCo_Enter);
            dgvTHChung.Enter += new EventHandler(dgvTHChung_Enter);
		}

       

        

		new public void Load()
		{
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
			this.Build();
			this.BindingLanguage();

			this.Show();
		}

		private void Build()
		{
			dteNgay_Ct1.Text = Library.DateToStr(Voucher.GetDate_Server());
			dteNgay_Ct2.Text = Library.DateToStr(Voucher.GetDate_Server());

            dgvTHChung.strZone = "THLUYEN";
			dgvTHChung.BuildGridView();

            dgvSuCo.strZone = "SUCO_SXLUYEN";
            dgvSuCo.BuildGridView();

            dgvTSQT.strZone = "TSQTLUYEN";
            dgvTSQT.BuildGridView();

            dgvPhoiNhap.strZone = "PHOILUYEN";
            dgvPhoiNhap.BuildGridView();
		}

		private void FillData()
		{
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            DataSet dsQueryShirt = SQLExec.ExecuteReturnDs("sp_GetQueryQLSXLUYEN", ht, CommandType.StoredProcedure);

			dtPh = dsQueryShirt.Tables[0];
			bdsPh.DataSource = dtPh;
			dgvTHChung.DataSource = bdsPh;

            dtSuCo = dsQueryShirt.Tables[1];
            bdsSuCo.DataSource = dtSuCo;
            dgvSuCo.DataSource = bdsSuCo;

            dtTSQT = dsQueryShirt.Tables[2];
            bdsTSQT.DataSource = dtTSQT;
            dgvTSQT.DataSource = bdsTSQT;

            dtPhoiNhap = dsQueryShirt.Tables[3];
            bdsPhoiNhap.DataSource = dtPhoiNhap;
            dgvPhoiNhap.DataSource = bdsPhoiNhap;

           
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

        void dgvSuCo_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvSuCo;
        }

        void dgvTSQT_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvTSQT;
        }

        void dgvPhoiNhap_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvPhoiNhap;
        }
        void dgvTHChung_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvTHChung;
        }
		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
