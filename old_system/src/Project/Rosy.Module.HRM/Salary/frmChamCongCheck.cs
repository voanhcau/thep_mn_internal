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
	public partial class frmChamCongCheck : RosySystem.Customize.frmView
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

        private DataTable dtLich;
        private BindingSource bdsLich = new BindingSource();
        private rsDataGridView dgvLich = new rsDataGridView();


        private DataTable dtCa;
        private DataRow drCurrent;
        string strMa_Bp = string.Empty;
        bool bRef = false;

        DataSet dsBp; DataTable dtDmBp; DataTable dtDmBpCt;

        private DateTime dteNgay_Ct2;

        public frmChamCongCheck()
		{
			InitializeComponent();

            dteNgay_Cham_Cong.TextChanged += new EventHandler(dteNgay_Cham_Cong_TextChanged);
           
            btThoat.Click += new EventHandler(btThoat_Click);
            timer_Check.Tick += new EventHandler(timer_Check_Tick);
            btThucHien.Click += new EventHandler(btThucHien_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);

            dgvDGBPCT.Enter += new EventHandler(dgvDGBPCT_Enter);
            dgvGiaDGBPCT.Enter += new EventHandler(dgvGiaDGBPCT_Enter);
            dgvLich.Enter += new EventHandler(dgvLich_Enter);

		}

        void dgvLich_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvLich;
        }

        void dgvGiaDGBPCT_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvGiaDGBPCT;
        }

        void dgvDGBPCT_Enter(object sender, EventArgs e)
        {
            this.ExportControl = sender;
            objActive = dgvDGBPCT;
        }

        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }

        void btThucHien_Click(object sender, EventArgs e)
        {
            if (rdbRef.Checked == true)
            {
                bRef = true;
                timer_Check.Enabled = true;
                btRefresh.Enabled = false;
            }
            else
            {
                bRef = false;
                timer_Check.Enabled = false;
                btRefresh.Enabled = true;
            }
        }

        void timer_Check_Tick(object sender, EventArgs e)
        {
            if (bRef)
            {
                FillData();
             
            }

        }

        void dteNgay_Cham_Cong_TextChanged(object sender, EventArgs e)
        {
            FillData();
        }

      

      

       
        void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void cboMa_Bp_Ct_TextChanged(object sender, EventArgs e)
        {
            FillData();
        }

       

       

		public override void Load()
		{
           
			this.Build();
			this.FillData();
         
            LoadCombo();


            //if (this.isLookup)
            //    this.ShowDialog();
            //else
				this.Show();
		}

        public void Load(DateTime dteNgay_Ct2)
        {
            this.dteNgay_Ct2 = dteNgay_Ct2;
            this.Build();
            this.FillData();
         
            LoadCombo();
            rdbRef.Checked = false;
            rdbNotRef.Checked = true;
            //if (this.isLookup)
            //    this.ShowDialog();
            //else
                this.Show();
        }
		private void Build()
		{

            dteNgay_Cham_Cong.Text = Library.DateToStr(DateTime.Now);

            dgvDGBPCT.ReadOnly = true;
            dgvDGBPCT.strZone = "CHAMCONGDUNG";
            dgvDGBPCT.Dock = DockStyle.Fill;
           

            dgvGiaDGBPCT.ReadOnly = true;
            dgvGiaDGBPCT.strZone = "CHAMCONGDUNG";
            dgvGiaDGBPCT.Dock = DockStyle.Fill;

            dgvLich.ReadOnly = true;
            dgvLich.strZone = "CHAMCONGSAI";
            dgvLich.Dock = DockStyle.Fill;
            //dgvLich.bFilter = false;

            this.tabPage1.Controls.Add(dgvDGBPCT);
            this.tabPage2.Controls.Add(dgvGiaDGBPCT);
            this.tabPage3.Controls.Add(dgvLich);
            
         


            dgvDGBPCT.BuildGridView();
            dgvGiaDGBPCT.BuildGridView();
            dgvLich.BuildGridView();

            dgvLich.ReadOnly = false;
            dgvDGBPCT.ReadOnly = false;
          
            foreach (DataGridViewColumn dgvc in dgvDGBPCT.Columns)
                dgvc.ReadOnly = true;

            //if (dgvDGBPCT.Columns.Contains("CHON"))
            //    dgvDGBPCT.Columns["CHON"].ReadOnly = false;

            ////Remover DataGridView Filter
            //string strColumnList = "Ca,Ngay_01,Ngay_02,Ngay_03,Ngay_04,Ngay_05,Ngay_06,Ngay_07,Ngay_08,Ngay_09,Ngay_10,Ngay_11,Ngay_12,Ngay_13,Ngay_14,Ngay_15,Ngay_16,Ngay_17,Ngay_18,Ngay_19,Ngay_20,Ngay_21,Ngay_22,Ngay_23,Ngay_24,Ngay_25,Ngay_26,Ngay_27,Ngay_28,Ngay_29,Ngay_30,Ngay_31";
            //foreach (string strColumn in strColumnList.Split(','))
            //{
            //    if (dgvLich.Columns.Contains(strColumn))

            //        ((dgvAutoFilterColumnHeaderCell)dgvLich.Columns[strColumn].HeaderCell).bFilteringEnabled = false;

            //}
           
		}
        private void LoadCombo()
        {
           

            ////Gắn Ma_Bp vào ComboBox
            //dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong", CommandType.StoredProcedure);
            //dtDmBp = dsBp.Tables[0];
            //strMa_Bp = SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt = (SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE MEMBER_ID = '" + Element.sysUser_Id + "')").ToString();

            //if (!Element.sysIs_Admin & !Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) & !Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access) & !Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access))
            //{
            //    cboMa_Bp.Enabled = false;
            //    Hashtable ht = new Hashtable();
            //    ht.Add("MA_BP", strMa_Bp);
            //    dsBp = SQLExec.ExecuteReturnDs("sp_GetBpLuong",ht, CommandType.StoredProcedure);
            //    dtDmBp = dsBp.Tables[0];
            //    DataRow dr = dtDmBp.Rows[0];
            //    cboMa_Bp.Text = dr["Ma_Bp"].ToString();

            //    if (cboMa_Bp.Text != "")
            //    {

            //        dtDmBpCt = dsBp.Tables[1];
            //        cboMa_Bp_Ct.lstItem.BuildListView("Ma_Bp_Ct:100,Ten_Bp_Ct:200");
            //        cboMa_Bp_Ct.lstItem.DataSource = dtDmBpCt;
            //        cboMa_Bp_Ct.lstItem.Size = new Size(400, cboMa_Bp_Ct.lstItem.Items.Count * 20);
            //        cboMa_Bp_Ct.lstItem.GridLines = true;
            //    }
               
            //}

            //cboMa_Bp.lstItem.BuildListView("Ma_Bp:100,Ten_Bp:200");
            //cboMa_Bp.lstItem.DataSource = dtDmBp;
            //cboMa_Bp.lstItem.Size = new Size(400, cboMa_Bp.lstItem.Items.Count * 15);
            //cboMa_Bp.lstItem.GridLines = true;

           

        }
		private void FillData()
		{
            string strSQLExec = string.Empty;

            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT", dteNgay_Cham_Cong.Text);
         
            dsDGBPCT = SQLExec.ExecuteReturnDs("sp_GetCheckChamCong", ht, CommandType.StoredProcedure);

            dtCa = dsDGBPCT.Tables[0];
            lbtKip1.Text = dtCa.Rows[0]["Ghi_Chu"].ToString();
            lbtKip2.Text = dtCa.Rows[1]["Ghi_Chu"].ToString();

            dtDGBPCT = dsDGBPCT.Tables[1];
            bdsDGBPCT.DataSource = dtDGBPCT;
            dgvDGBPCT.DataSource = bdsDGBPCT;

            dtGiaDGBPCT = dsDGBPCT.Tables[2];
            bdsGiaDGBPCT.DataSource = dtGiaDGBPCT;
            dgvGiaDGBPCT.DataSource = bdsGiaDGBPCT;

            dtLich = dsDGBPCT.Tables[3];
            bdsLich.DataSource = dtLich;
            dgvLich.DataSource = bdsLich;

            this.ExportControl = dgvDGBPCT;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
            //return;
			
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

		public override void Delete()
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

     

       
	}
}
