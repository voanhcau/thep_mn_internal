using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Data;

namespace RosyModule.Costing
{
    public partial class frmZCheckTapHop : RosySystem.Customize.frmView
    {
        DataTable dtTapHopCheck;
        BindingSource bdsTapHopCheck = new BindingSource();
        rsDataGridView dgvTapHopCheck = new rsDataGridView();

        frmGiaThanh frmZ;

        public frmZCheckTapHop()
        {
            InitializeComponent();
        }

        public void Load(frmGiaThanh frmGiaThanh)
        {
            frmZ = frmGiaThanh;

            this.Build();
            this.FillData();

            this.Show();
        }

        void Build()
        {
            dgvTapHopCheck.Dock = DockStyle.Fill;
			dgvTapHopCheck.strZone = "ZCHECKTAPHOP";
            dgvTapHopCheck.BuildGridView();

            this.Controls.Add(dgvTapHopCheck);

			ExportControl = dgvTapHopCheck;
        }

        void FillData()
        {
            Hashtable htPara = new Hashtable();
            htPara.Add("NGAY_CT1", frmZ.dteNgay_Ct1);
            htPara.Add("NGAY_CT2", frmZ.dteNgay_Ct2);
            htPara.Add("TK", frmZ.txtTk.Text);
            htPara.Add("MA_DVCS", RosySystem.Element.Element.sysMa_DvCs);

			dtTapHopCheck = SQLExec.ExecuteReturnDt("sp_ZCheckTapHopChiPhi", htPara, CommandType.StoredProcedure);

            bdsTapHopCheck.DataSource = dtTapHopCheck;
            dgvTapHopCheck.DataSource = bdsTapHopCheck;

            this.ExportControl = dgvTapHopCheck;
            this.bdsSearch = bdsTapHopCheck;
        }
            
    }
}
