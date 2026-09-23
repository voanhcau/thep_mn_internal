using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;
using System.Collections;
using System.Data.SqlClient;


namespace RosyModule.Machinery
{
	public partial class frmKHVTPT : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtDuyet_Ct;
		public DataTable dtDuyet_Ph;
        public DataTable dtCtVt;

		BindingSource bdsDuyet = new BindingSource();
		BindingSource bdsDuyet_Ph = new BindingSource();		
        BindingSource bdsCtVt = new BindingSource();

		DataRow drDuyet;
		string strMa_Ct = string.Empty;
		string strStt = string.Empty;
		frmVoucher_Edit frmVoucher_Edit;
		DataRow drCurrent, drDmCt_Current;
		public bool Is_Accept = false;
        string strColumnName = string.Empty;
        string strReportFile = "rptCT_CBVTPT";
		#endregion

		#region Contructor

        public frmKHVTPT()
		{
			InitializeComponent();

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
            btExit.Click += new EventHandler(btExit_Click);
            btPrint.Click += new EventHandler(btPrint_Click);

			
			dgvDuyet.CellValidating += new DataGridViewCellValidatingEventHandler(dgvDuyet_CellValidating);
            dgvCtVt.KeyDown += new KeyEventHandler(dgvCtVt_KeyDown);
            bdsDuyet.PositionChanged += new EventHandler(bdsDuyet_PositionChanged);

			
		}

        

       

		#endregion

		#region Method

		public void Load(DataRow drDuyet)
		{
			this.drDuyet = drDuyet;

			this.strMa_Ct = (string)drDuyet["Ma_Ct"];
			this.strStt = (string)drDuyet["Stt"];
            

            drDmCt_Current = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
            Build();
			FillData();
			BindingLanguage();
            DataGridView_Language();

            BindingTong_Tien();
			this.LoadDicName();
			this.ShowDialog();
		}
        private void BindingTong_Tien()
        {
            //numTSo_Luong.DataBindings.Add("Value", bdsCtVt, "So_Luong");

        }
        void DataGridView_Language()
        {
            
         
        }
		void LoadDicName()
		{
           
		}

		void Build()
		{
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);

			dgvDuyet.strZone =drDmCt["Zone_EditCt1"].ToString();
            dgvCtVt.strZone = "VTBTTB";

			dgvDuyet.BuildGridView();
            dgvCtVt.BuildGridView();

			foreach (DataGridViewColumn dgvc in dgvDuyet.Columns)
				dgvc.ReadOnly = true;

        }	

		void FillData()
		{
			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
			Hashtable htPara = new Hashtable();
			htPara.Add("TABLE_PH", (string)drDmCt["Table_Ph"]);
			htPara.Add("TABLE_CT", (string)drDmCt["Table_Ct"]);
			htPara.Add("STT", strStt);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_BTTB", htPara, CommandType.StoredProcedure);

			dtDuyet_Ph = dsVoucher.Tables[0];
			dtDuyet_Ct = dsVoucher.Tables[1];
            dtCtVt = dsVoucher.Tables[2];

            bdsDuyet_Ph.DataSource = dtDuyet_Ph;
			bdsDuyet.DataSource = dtDuyet_Ct;
			dgvDuyet.DataSource = bdsDuyet;

            bdsCtVt.DataSource = dtCtVt;
            dgvCtVt.DataSource = bdsCtVt;
            
			
		}

		bool FormCheckValid()
		{

			return true;
		}

		#endregion

		

		void dgvDuyet_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;

			drCurrent = ((DataRowView)bdsDuyet.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
	
		}

        void bdsDuyet_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDuyet.Position < 0)
                return;
            DataRow drDuyet = ((DataRowView)bdsDuyet.Current).Row;
            bdsCtVt.Filter = "Stt0 = "+ drDuyet["Stt0"] +"";
        }
       
		public override void Edit(enuEdit enuNew_Edit)
		{
            DataRow drDuyet = ((DataRowView)bdsDuyet.Current).Row;

			if (bdsCtVt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
            if (bdsCtVt.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsCtVt.Current).Row, ref drCurrent);
			else
                drCurrent = dtCtVt.NewRow();

            drCurrent["Stt"] = strStt;
            drCurrent["Stt0"] = drDuyet["Stt0"];
            drCurrent["Ma_Tb"] = drDuyet["Ma_Tb"];
            drCurrent["Stt_Nd"] = drDuyet["Stt_Nd_Org"];

            frmPTBTTB_Edit frmEdit = new frmPTBTTB_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", drCurrent["Ma_Vt"].ToString());

                drCurrent["Ten_Vt"] = drDmVt["Ten_Vt_Chuan"];
                drCurrent["Mo_Ta_Kt"] = drDmVt["Ten_Vt"];
                drCurrent["Dvt"] = drDmVt["Dvt"];

				if (enuNew_Edit == enuEdit.New)
				{
                    if (bdsCtVt.Position >= 0)
                        dtCtVt.ImportRow(drCurrent);
					else
                        dtCtVt.Rows.Add(drCurrent);
                    
                    bdsCtVt.Position = bdsCtVt.Find("Identt00", drCurrent["Identt00"]);
				}
				else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtVt.Current).Row);

				dtCtVt.AcceptChanges();
                BindingTong_Tien();
			}
		}
		public override void Delete()
		{
            if (bdsCtVt.Position < 0)
				return;

            DataRow drCurrent = ((DataRowView)bdsCtVt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R06VT_BTTB", drCurrent))
                Common.MsgOk("Đã xóa xong");
		}
        private bool Print(bool bPreview)
        {
            DataRow drCtVt = ((DataRowView)bdsCtVt.Current).Row;


            DataTable dtHeader = new DataTable();
            DataTable dtDetail = new DataTable();

            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt);

            DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintPCBVTPT", ht, CommandType.StoredProcedure);
            dtHeader = ds.Tables[0];
            dtDetail = ds.Tables[1];



            if (!dtCtVt.Columns.Contains("REPORT_FILE"))
                dtCtVt.Columns.Add("REPORT_FILE", typeof(string));

            if (!dtCtVt.Columns.Contains("NGAY_CT"))
                dtCtVt.Columns.Add("NGAY_CT", typeof(DateTime));

            drCtVt["REPORT_FILE"] = strReportFile;
            drCtVt["NGAY_CT"] = Element.sysNgay_Ct2;
            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drCtVt, dtDetail, bPreview, true);
        }
        void Design()
        {
        
            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
        }
		void btEdit_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.Edit);
		}

		void btNew_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.New);
		}
		void btDelete_Click(object sender, EventArgs e)
		{
			Delete();
		}
        void btPrint_Click(object sender, EventArgs e)
        {
            Print(true);
        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Is_Accept = true;
            this.Close();
        }
        void dgvCtVt_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    Edit(enuEdit.New);
                    break;
                case Keys.F3:
                    Edit(enuEdit.Edit);
                    break;
                case Keys.F8:
                    Delete();
                    break;
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            this.Design();
                            break;
                    }
                    break;
            }
        }
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}

	}

}