using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;
using RosySystem;

namespace RosyModule.Receivable
{
	public partial class frmQDGia : RosySystem.Customize.frmView
	{
		BindingSource bdsQDGia = new BindingSource();
		DataTable dtQDGia = new DataTable();

		BindingSource bdsQDGia_Detail = new BindingSource();
		public DataTable dtQDGia_Detail = new DataTable();
		public bool is_Accept = false;
        bool bTp_KD = false;
        bool bGiam_Doc = false;
		DataRow drCurrent;
        string strReport_File = "rptQDGia";

        public frmQDGia()
		{
			InitializeComponent();

			bdsQDGia.PositionChanged += new EventHandler(bdsQDGia_PositionChanged);
            dgvQDGia.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvQDGia_CellMouseClick);
            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click+=new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
            btCreateQD.Click += new EventHandler(btCreateQD_Click);
            this.KeyDown += new KeyEventHandler(frmQDGia_KeyDown);
		}

		public void Load()
		{

            bTp_KD = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
            bGiam_Doc = Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access);

			this.Build();
			this.FillData_CheckInventory();
			this.FillData_TKCD();
			this.BindingLanguage();
			this.Show();
		}

		void Build()
		{
           

			this.dgvQDGia.strZone = "QDGIA";
			this.dgvQDGia.BuildGridView();

            this.dgvQDGia_Detail.strZone = "QDGIACT";
			this.dgvQDGia_Detail.BuildGridView();

			dgvQDGia.ReadOnly = false;

            foreach (DataGridViewColumn dgvc in dgvQDGia.Columns)
                dgvc.ReadOnly = true;
			
            foreach (DataGridViewColumn dgvc in dgvQDGia_Detail.Columns)
				dgvc.ReadOnly = true;

            if (dgvQDGia.Columns.Contains("DUYET_GD"))
                dgvQDGia.Columns["DUYET_GD"].HeaderText = "Duyệt giám đốc";
            
            if (dgvQDGia.Columns.Contains("Duyet_PKD") && bTp_KD)
                dgvQDGia.Columns["Duyet_PKD"].ReadOnly = false;

            if (dgvQDGia.Columns.Contains("Duyet_GD") && bGiam_Doc)
                dgvQDGia.Columns["Duyet_GD"].ReadOnly = false;
		}

		void FillData_CheckInventory()
		{
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", Element.sysNgay_Ct1);
            ht.Add("NGAY_CT2", Element.sysNgay_Ct2);
           

            DataSet dsQDGia = SQLExec.ExecuteReturnDs("sp_GetQDGIA", ht, CommandType.StoredProcedure);
            bdsQDGia.DataSource = dsQDGia.Tables[0];
			dgvQDGia.DataSource = bdsQDGia;
            //bdsQDGia.Position = bdsQDGia.Count;


            bdsQDGia_Detail.DataSource = dsQDGia.Tables[1];
            dgvQDGia_Detail.DataSource = bdsQDGia_Detail;
            bdsQDGia_Detail.Position = bdsQDGia_Detail.Count;

            this.dgvQDGia_Detail.ResizeGridView(100);
		}

		void FillData_TKCD()
		{
            
            //Hashtable ht = new Hashtable();
            //ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            //ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
          
            //dtQDGia_Detail = SQLExec.ExecuteReturnDt("sp_GetQDGiaCT", ht, CommandType.StoredProcedure);


            //bdsQDGia_Detail.DataSource = dtQDGia_Detail;
            //dgvQDGia_Detail.DataSource = bdsQDGia_Detail;
            //bdsQDGia_Detail.Position = bdsQDGia_Detail.Count;

            //this.dgvQDGia_Detail.ResizeGridView(100);
		}

        void dgvQDGia_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (bdsQDGia.Position < 0)
                return;

            string strLoaiDuyet = string.Empty;
            string strColumnName = dgvQDGia.Columns[e.ColumnIndex].Name;
           
            if (bTp_KD && strColumnName == "DUYET_PKD")
                strLoaiDuyet = "PKD";
            else if(bGiam_Doc && strColumnName == "DUYET_GD")
                strLoaiDuyet = "GD";
            else
                strLoaiDuyet = "";
            
            drCurrent = ((DataRowView)bdsQDGia.Current).Row;

            if (strLoaiDuyet != "")
            {

                string strPKD = "SELECT Duyet_PKD FROM R80PH_QDGIA WHERE So_Qd = '" + drCurrent["So_Qd"].ToString() + "'";
                string strGD = "SELECT Duyet_Gd FROM R80PH_QDGIA WHERE So_Qd = '" + drCurrent["So_Qd"].ToString() + "'";

                bool bDuyet_PKD = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_PKD FROM R80PH_QDGIA WHERE So_Qd = '"+ drCurrent["So_Qd"].ToString() +"'"));
                bool bDuyet_Gd = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_Gd FROM R80PH_QDGIA WHERE So_Qd = '" + drCurrent["So_Qd"].ToString() + "'"));
                if (bDuyet_Gd && strColumnName == "DUYET_PKD")
                {
                    Common.MsgOk("Số quyết định " + drCurrent["So_Qd"].ToString() + " đã được giám đốc duyệt không được chỉnh sửa dữ liệu!!!");
                    drCurrent["Duyet_PKD"] = !Convert.ToBoolean(drCurrent["Duyet_PKD"]);
                    return;
                }

                if (!bDuyet_PKD && strColumnName == "DUYET_GD")
                {
                    Common.MsgOk("Số quyết định " + drCurrent["So_Qd"].ToString() + " chưa được PKD duyệt!!!");
                    drCurrent["Duyet_GD"] = !Convert.ToBoolean(drCurrent["Duyet_GD"]);
                    return;
                }

                frmDuyetQDGia frm = new frmDuyetQDGia();
                frm.Load(enuEdit.Edit, drCurrent, strLoaiDuyet);
                if (frm.isAccept)
                {
                    if (strLoaiDuyet == "PKD")
                        drCurrent["DUYET_PKD"] = frm.chkDuyet.Checked;

                    if (strLoaiDuyet == "GD")
                        drCurrent["Duyet_GD"] = frm.chkDuyet.Checked;
                }
                else
                {
                    if (strLoaiDuyet == "PKD" && strColumnName == "DUYET_PKD")
                        drCurrent["DUYET_PKD"] = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_PKD FROM R80PH_QDGIA WHERE So_Qd = '"+ drCurrent["So_Qd"].ToString() +"'"));
                   

                    if (strLoaiDuyet == "GD" && strColumnName == "DUYET_GD" && !(bool)drCurrent["DUYET_GD"])
                        drCurrent["DUYET_GD"] = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Duyet_Gd FROM R80PH_QDGIA WHERE So_Qd = '" + drCurrent["So_Qd"].ToString() + "'"));
                }
            }
            else
            {
                dgvQDGia.Columns["DUYET_PKD"].ReadOnly = true;
                dgvQDGia.Columns["DUYET_GD"].ReadOnly = true;
            }
        }
		void bdsQDGia_PositionChanged(object sender, EventArgs e)
		{
			if (bdsQDGia.Position < 0)
				return;

			string strSo_QD = ((DataRowView)bdsQDGia.Current).Row["So_Qd"].ToString();
            bdsQDGia_Detail.Filter = "SO_QD = '" + strSo_QD + "'";
		}
        
        void btPrint_Click(object sender, EventArgs e)
        {
            if (bdsQDGia.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsQDGia.Current).Row;

            this.PrintQD(drCurrent["So_Qd"].ToString(), true);
        }
        void btCreateQD_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsQDGia.Current).Row;

            if (DataTool.SQLCheckExist("R81DMQD", "So_Qd", drCurrent["So_QD"].ToString()))
            {
                Common.MsgOk("Số QD " + drCurrent["So_Qd"] + " đã được tạo danh mục QD. Không tạo được nữa");
                return;
            }
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("SO_QD", drCurrent["So_QD"]);
                ht.Add("CREATE_LOG", Common.GetCurrent_Log());
                if (SQLExec.Execute("sp_CreateDMQDGIA", ht, CommandType.StoredProcedure))
                    Common.MsgOk("Số QD "+ drCurrent["So_QD"] +" đã tạo xong.");
            }
        }
       private void Design()
       {
           strReport_File = "rptQDGia";

           frmIn_Ct_QDGia frm1 = new frmIn_Ct_QDGia();
           frm1.Load();

           if (frm1.rdbCCK.Checked == true)
               strReport_File = strReport_File + "C";
           else if (frm1.rdbKCK.Checked == true)
               strReport_File = strReport_File + "K";

           if (frm1.txtSo_CTrinh.Text != string.Empty)
               strReport_File = strReport_File + frm1.txtSo_CTrinh.Text;

           RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
           frm.Load(strReport_File);
       }
       bool PrintQD(string strSo_Qd, bool bPreview)
        {
            strReport_File = "rptQDGia";

            DataTable dtHeader;
            DataTable dtDetail;
            DataTable dtCTrinh;
            Hashtable ht = new Hashtable();
            ht.Add("SO_QD", strSo_Qd);
            
            DataSet dsQDGia = SQLExec.ExecuteReturnDs("sp_PrintQDGia", ht, CommandType.StoredProcedure);

            dtHeader = dsQDGia.Tables[0];
            dtDetail = dsQDGia.Tables[1];
            dtCTrinh = dsQDGia.Tables[2];

            dtHeader.Columns.Add("REPORT_FILE", typeof(string));
            dtHeader.Columns.Add("NGAY_CT", typeof(DateTime));
          
            DataRow drHeader = dtHeader.Rows[0];

            if ((bool)drHeader["Is_Ck"])
               strReport_File = strReport_File + "C";
           else
                strReport_File = strReport_File + "K";

           if(dtCTrinh.Rows.Count <= 2)
               strReport_File = strReport_File + "2";
           else if (dtCTrinh.Rows.Count <= 4)
               strReport_File = strReport_File + "4";
           else if (dtCTrinh.Rows.Count <= 6)
               strReport_File = strReport_File + "6";
           else if (dtCTrinh.Rows.Count <= 8)
               strReport_File = strReport_File + "8";
           else if (dtCTrinh.Rows.Count <= 10)
               strReport_File = strReport_File + "10";

            drHeader["Report_File"] = strReport_File;
            drHeader["Ngay_Ct"] = drHeader["Ngay_Qd"];

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(dtHeader.Rows[0], dtDetail, bPreview);
           
        }
	    void btDelete_Click(object sender, EventArgs e)
        {
            if (bdsQDGia.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQDGia.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            string strSo_Qd = drCurrent["So_Qd"].ToString();
            //Kiểm tra barcode_LXH đã xuất chưa
            if (DataTool.SQLCheckExist("R81DMQD", "So_Qd", strSo_Qd))
            {
                Common.MsgOk("Số QD này đã được duyệt. Bạn không được xóa!!!");
            }
            else
            {
                //Xóa R05BARCODELE
                SQLExec.Execute("DELETE FROM R80PH_QDGIA WHERE So_Qd = '" + strSo_Qd + "'");
                //Xóa R81DMBARCODE
                SQLExec.Execute("DELETE FROM R04CT_QDGIA WHERE So_Qd = '" + strSo_Qd + "'");
                
            }
            FillData_TKCD();
            FillData_CheckInventory();
        }

        void btEdit_Click(object sender, EventArgs e)
        {
           Edit_BarcodeLe(enuEdit.Edit);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            Edit_BarcodeLe(enuEdit.New);
        }
        
        private void Edit_BarcodeLe(enuEdit enuNew_Edit)
        {
            if (bdsQDGia.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;
            
            drCurrent = ((DataRowView)bdsQDGia.Current).Row;
        

            frmQDGia_Edit frm = new frmQDGia_Edit();
            frm.Load(enuNew_Edit, drCurrent);

            if (frm.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                    //if (bdsQDGia_Detail.Position >= 0)
						dtQDGia.ImportRow(drCurrent);
                    //else
                    //    dtQDGia_Detail.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsQDGia.Current).Row);
				}
                //Xử lý phần xuất barcode le
                //tạo barcode LXH trong  R81DMBARCODE
                //bdsQDGia.Position = bdsQDGia_Detail.Find("BARCODE", drCurrent["Barcode"]);
				dtQDGia.AcceptChanges();
			}
			else
				dtQDGia.RejectChanges();

            FillData_TKCD();
            FillData_CheckInventory();
            //bdsDmQd.Find("SO_QD", drCurrent["SO_QD"]);
            bdsQDGia.Position = bdsQDGia.Find("So_Qd", drCurrent["So_Qd"]);
        }
            
        

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

           
        }
        void frmQDGia_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            Design();
                            break;

                      
                    }
                    break;
            }
        }
	}
}
