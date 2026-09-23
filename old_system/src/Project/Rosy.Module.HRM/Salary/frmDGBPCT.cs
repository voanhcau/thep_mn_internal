using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;

namespace RosyModule.Salary
{
	public partial class frmDGBPCT : RosySystem.Customize.frmView
	{
        object objActive = null;

        private DataSet dsDGBPCT;
        private rsTreeList tlDgBpCt = new rsTreeList();
		private DataTable dtDGBPCT;
		private BindingSource bdsDGBPCT = new BindingSource();
		private rsDataGridView dgvDGBPCT = new rsDataGridView();

        private DataTable dtGiaDGBPCT;
        private BindingSource bdsGiaDGBPCT = new BindingSource();
        private rsDataGridView dgvGiaDGBPCT = new rsDataGridView();

        private DataTable dtPhuongAn;
        private BindingSource bdsPhuongAn = new BindingSource();
        private rsDataGridView dgvPhuongAn = new rsDataGridView();

        private DataRow drCurrent;
        string strMa_Bp = string.Empty;
        int iNam; int iThang;
        public frmDGBPCT()
		{
			InitializeComponent();

            bdsDGBPCT.PositionChanged += new EventHandler(bdsDGBPCT_PositionChanged);

            dgvPhuongAn.Enter += new EventHandler(dgvPhuongAn_Enter);
            dgvGiaDGBPCT.Enter += new EventHandler(dgvGiaDGBPCT_Enter);
		}

        

        

       

		public override void Load()
		{
           
			this.Build();
			this.FillData();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}
        public void show(string strMa_Bp, int iNam, int iThang)
        {
            this.strMa_Bp = strMa_Bp;
            this.iNam = iNam;
            this.iThang = iThang;

            Load();
        }
		public override void LoadLookup()
		{
			this.Load();
		}

		private void Build()
		{
            //dgvDGBPCT.ReadOnly = true;
            //dgvDGBPCT.strZone = "DGBPCT";
            //dgvDGBPCT.Dock = DockStyle.Fill;


            dgvDGBPCT.ReadOnly = true;
            dgvDGBPCT.strZone = "DMBPCT";
            dgvDGBPCT.Dock = DockStyle.Fill;


            dgvGiaDGBPCT.ReadOnly = true;
            dgvGiaDGBPCT.strZone = "GIADGBPCT";
            dgvGiaDGBPCT.Dock = DockStyle.Fill;

            dgvPhuongAn.ReadOnly = true;
            dgvPhuongAn.strZone = "DGBPCT";
            dgvPhuongAn.Dock = DockStyle.Fill;

            //tlDgBpCt.KeyFieldName = "MA_BP_CT";
            //tlDgBpCt.ParentFieldName = "MA_BP_CT_CHA";
            //tlDgBpCt.Dock = DockStyle.Fill;
            //tlDgBpCt.strZone = "DGBPCT";
            //tlDgBpCt.BuildTreeList(this.isLookup);

            this.splitContainer1.Panel1.Controls.Add(dgvDGBPCT);
            this.tpGia.Controls.Add(dgvGiaDGBPCT);
            this.tpPhuongAn.Controls.Add(dgvPhuongAn);
          

            dgvDGBPCT.BuildGridView();
            dgvGiaDGBPCT.BuildGridView();
            dgvPhuongAn.BuildGridView();
		}

		private void FillData()
		{
            string strSQLExec = string.Empty;
         
            Hashtable ht = new Hashtable();
            ht.Add("USER_LOGIN", Element.sysUser_Id);
            ht.Add("NAM", iNam);
            ht.Add("THANG", iThang);
            dsDGBPCT = SQLExec.ExecuteReturnDs("sp_GetDgBpCt", ht, CommandType.StoredProcedure);

            bdsDGBPCT.DataSource = dsDGBPCT.Tables[0];
			dgvDGBPCT.DataSource = bdsDGBPCT;

            dtGiaDGBPCT = dsDGBPCT.Tables[1];
            bdsGiaDGBPCT.DataSource = dtGiaDGBPCT;            
            dgvGiaDGBPCT.DataSource = bdsGiaDGBPCT;

            dtPhuongAn = dsDGBPCT.Tables[2];
            bdsPhuongAn.DataSource = dtPhuongAn;
            dgvPhuongAn.DataSource = bdsPhuongAn;
		}
        void dgvPhuongAn_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvPhuongAn;
        }
        void dgvGiaDGBPCT_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvGiaDGBPCT;
        }
		public override void Edit(enuEdit enuNew_Edit)
		{
            if (this.tabControl1.SelectedTab == tpGia)
                Edit_Gia(enuNew_Edit);
            else if (this.tabControl1.SelectedTab == tpPhuongAn)
                Edit_PhuongAn(enuNew_Edit);
		}
        private void Edit_PhuongAn(enuEdit enuNew_Edit)
        {
            if (bdsPhuongAn.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            if (bdsPhuongAn.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPhuongAn.Current).Row, ref drCurrent);
            else
                drCurrent = dtPhuongAn.NewRow();

            frmPhuongAn_Edit frmEdit = new frmPhuongAn_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsPhuongAn.Position >= 0)
                        dtPhuongAn.ImportRow(drCurrent);
                    else
                        dtPhuongAn.Rows.Add(drCurrent);

                    bdsPhuongAn.Position = bdsPhuongAn.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsPhuongAn.Current).Row);
                }

                dtPhuongAn.AcceptChanges();
            }
            else
                dtPhuongAn.RejectChanges();
        }
        private void Edit_Gia(enuEdit enuNew_Edit)
        {
            if (bdsGiaDGBPCT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            if (bdsGiaDGBPCT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsGiaDGBPCT.Current).Row, ref drCurrent);
            else
                drCurrent = dtGiaDGBPCT.NewRow();

            frmDGBPCT_Edit frmEdit = new frmDGBPCT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsGiaDGBPCT.Position >= 0)
                        dtGiaDGBPCT.ImportRow(drCurrent);
                    else
                        dtGiaDGBPCT.Rows.Add(drCurrent);

                    bdsGiaDGBPCT.Position = bdsGiaDGBPCT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsGiaDGBPCT.Current).Row);
                }

                dtGiaDGBPCT.AcceptChanges();
            }
            else
                dtGiaDGBPCT.RejectChanges();
        }
        private void Delete_Gia()
        {
            if (bdsGiaDGBPCT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsGiaDGBPCT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R10DGBPCT", drCurrent))
            {
                bdsGiaDGBPCT.RemoveAt(bdsGiaDGBPCT.Position);
                dtGiaDGBPCT.AcceptChanges();
            }
        }
        private void Delete_PhuongAn()
        {
            if (bdsPhuongAn.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPhuongAn.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09BPCTLUONG", drCurrent))
            {
                bdsPhuongAn.RemoveAt(bdsPhuongAn.Position);
                dtPhuongAn.AcceptChanges();
            }
        }
		public override void Delete()
		{
            if (this.tabControl1.SelectedTab == tpGia)
                Delete_Gia();
            else if (this.tabControl1.SelectedTab == tpPhuongAn)
                Delete_PhuongAn();
		}

        void bdsDGBPCT_PositionChanged(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsDGBPCT.Current).Row;
            bdsGiaDGBPCT.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";
            bdsPhuongAn.Filter = "Ma_Bp_Ct = '" + drCurrent["Ma_Bp_Ct"] + "'";

        }
	}
}
