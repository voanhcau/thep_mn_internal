using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Public;
using RosySystem.Common;
using System.IO;


namespace RosyModule.Machinery
{
	public partial class frmMachinery_View : RosySystem.Customize.frmView
	{
		#region Fields

		public DataSet dsVoucher = new DataSet("dsVoucher");

		public DataTable dtViewPh;
		public DataTable dtViewCt;
		public DataTable dtResource;
		public DataTable dtCtVt;
		

		public BindingSource bdsViewPh = new BindingSource();
		public BindingSource bdsViewCt = new BindingSource();
		public BindingSource bdsResource = new BindingSource();
		public BindingSource bdsCtVt = new BindingSource();

		public rsDataGridView dgvViewPh = new rsDataGridView();
		public rsDataGridView dgvViewCt = new rsDataGridView();
		public rsDataGridView dgvResource = new rsDataGridView();
		public rsDataGridView dgvCtVt = new rsDataGridView();

		public DataRelation drlView;

		public string strMa_Ct_List = string.Empty;
		public DataRow drCurrent;
		public DataRow drDmCt;
		public DataRow drResource;
        public DataRow drCtVt;
        string strStt_Current = string.Empty;
		#endregion

		#region Contructor

        public frmMachinery_View()
		{
			InitializeComponent();

			this.Resize += new EventHandler(frmViewPh_Resize);
			this.KeyDown += new KeyEventHandler(KeyDownEvent);

			bdsViewPh.PositionChanged += new EventHandler(bdsViewPh_PositionChanged);

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btPreview.Click += new EventHandler(btPreview_Click);
			btPrint.Click += new EventHandler(btPrint_Click);
			btFilter.Click += new EventHandler(btFilter_Click);
			btExit.Click += new EventHandler(btExit_Click);
			btImport.Click += new EventHandler(btImport_Click);

			dgvViewPh.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvViewPh_CellMouseClick);
            dgvViewCt.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvViewCt_CellMouseClick);
			dgvViewPh.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvViewPh_CellFormatting);
			dgvViewPh.Enter += new EventHandler(dgvViewPh_Enter);
			dgvViewCt.Enter += new EventHandler(dgvViewCt_Enter);

			//rsTabControl1.SelectedIndexChanged += new EventHandler(rsTabControl1_SelectedIndexChanged);
			btKHVT.Click += new EventHandler(btnXuatDinhMuc_Click);
		}

        void dgvViewCt_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string strColumnName = dgvViewCt.Columns[e.ColumnIndex].Name;
            drCtVt = ((DataRowView)bdsViewCt.Current).Row;

        }

		void btnXuatDinhMuc_Click(object sender, EventArgs e)
		{
            drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            frmKHVTPT frm = new frmKHVTPT();
            frm.Load(drCurrent);
		}

		public void Load(string strMa_Ct_List)
		{
			this.strMa_Ct_List = strMa_Ct_List;
			this.Object_ID = strMa_Ct_List;
			this.Tag = "frmCT" + strMa_Ct_List.Split(',')[0];

			this.Build();

			//FillData
			object objNgay_CtMax = SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM " + (string)drDmCt["Table_Ph"] + " WHERE Ma_Ct LIKE '" + this.strMa_Ct_List.Split(',')[0] + "' AND Ma_DvCs = '" + Element.sysMa_DvCs + "'");
			int iInterval = Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER"));

			DateTime dteNgay_Ct2 = objNgay_CtMax != DBNull.Value ? (DateTime)objNgay_CtMax : DateTime.Now;
			DateTime dteNgay_Ct1 = dteNgay_Ct2.Subtract(new TimeSpan(iInterval, 0, 0, 0));

			DataTable dtFilter = new DataTable();
			dtFilter.Columns.Add(new DataColumn("Ma_Ct_List", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("User_Login", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Is_Admin", typeof(bool)));

			DataRow drFilter = dtFilter.NewRow();
			drFilter["Ma_Ct_List"] = strMa_Ct_List;
			drFilter["Ngay_Ct1"] = dteNgay_Ct1;
			drFilter["Ngay_Ct2"] = dteNgay_Ct2;

			this.FillData(drFilter);

			this.BindingLanguage();
			this.BindingTong_Tien();
            DataGridView_Language();

            //if (Common.InlistLike(strMa_Ct_List, "BBHH"))
            //{
            //    if (dgvViewPh.Columns.Contains("DUYET_TP"))
            //        dgvViewPh.Columns["DUYET_TP"].HeaderText = "Duyệt DVSD";
            //}
            
          
            this.FormLayout();
			
			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			string strMa_Ct = strMa_Ct_List.Split(',')[0];

			drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);

			//dgvViewPh 
			dgvViewPh.ReadOnly = true;
			dgvViewPh.strZone = (string)drDmCt["Zone_ViewPh"];
			dgvViewPh.Dock = DockStyle.Fill;
			dgvViewPh.BuildGridView(false);

			if (!dgvViewPh.Columns.Contains("Ma_Tte"))
			{
				dgvViewPh.Columns.Add("Ma_Tte", "Ma_Tte"); //Hải: thêm cột để phân biệt chứng từ Nte, VND
				dgvViewPh.Columns["Ma_Tte"].DataPropertyName = "MA_TTE";
				dgvViewPh.Columns["Ma_Tte"].ValueType = typeof(string);
				dgvViewPh.Columns["Ma_Tte"].Visible = false;
			}

			dgvViewPh.Columns.Add("Mark", "Mark"); //Đánh dấu dòng
			dgvViewPh.Columns["Mark"].DataPropertyName = "MARK";
			dgvViewPh.Columns["Mark"].ValueType = typeof(bool);
			dgvViewPh.Columns["Mark"].Visible = false;

            

			//dgvViewCt
			dgvViewCt.ReadOnly = true;
			dgvViewCt.strZone = (string)drDmCt["Zone_ViewCt"];
			dgvViewCt.Dock = DockStyle.Fill;
			dgvViewCt.BuildGridView(false);

			dgvResource.BuildGridView(false);

			dgvCtVt.ReadOnly = true;
			dgvCtVt.Dock = DockStyle.Fill;
			dgvCtVt.strZone = (string)drDmCt["Zone_EditCt3"];
			dgvCtVt.BuildGridView(false);

			this.rsSplitContainer1.Panel1.Controls.Add(dgvViewPh);
			this.pageCTSO.Controls.Add(dgvViewCt);
            this.pageDMVTLIST.Controls.Add(dgvCtVt);
		
            
			dgvViewPh.TabIndex = 0;
			dgvViewCt.TabIndex = 1;
			dgvResource.TabIndex = 2;
            dgvCtVt.TabIndex = 3;

            if (!Common.Inlist(strMa_Ct, "BTNB,BTTT"))
                this.rsTabControl1.TabPages.Remove(pageDMVTLIST);  
            else
                this.btKHVT.Visible = true;

			if (dgvViewCt.Columns.Contains("Tinh_Trang_Tb"))
			{
				dgvViewCt.Columns["Tinh_Trang_Tb"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
				dgvViewCt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			}
			if (dgvViewCt.Columns.Contains("Ten_Vt"))
            {
                dgvViewCt.Columns["Ten_Vt"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvViewCt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            if (dgvViewCt.Columns.Contains("Noi_Dung"))
            {
                dgvViewCt.Columns["Noi_Dung"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvViewCt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            if (dgvViewCt.Columns.Contains("Ghi_Chu"))
            {
                dgvViewCt.Columns["Ghi_Chu"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvViewCt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvViewCt.Columns.Contains("Nguyen_Nhan"))
            {
                dgvViewCt.Columns["Nguyen_Nhan"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvViewCt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvViewCt.Columns.Contains("Phuong_An"))
            {
                dgvViewCt.Columns["Phuong_An"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvViewCt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvViewCt.Columns.Contains("Ten_Vt_HH"))
            {
                dgvViewCt.Columns["Ten_Vt_HH"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvViewCt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            if (dgvViewCt.Columns.Contains("Ket_Qua"))
            {
                dgvViewCt.Columns["Ket_Qua"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvViewCt.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
         
		}
     
		private void FillData(DataRow drFilter)
		{
			if (!drFilter.Table.Columns.Contains("Table_PH"))
				drFilter.Table.Columns.Add(new DataColumn("Table_PH", typeof(string)));

			if (!drFilter.Table.Columns.Contains("Table_Ct"))
				drFilter.Table.Columns.Add(new DataColumn("Table_Ct", typeof(string)));
			
			if (!drFilter.Table.Columns.Contains("User_LogIn"))
				drFilter.Table.Columns.Add(new DataColumn("User_LogIn", typeof(string)));

			if (!drFilter.Table.Columns.Contains("Ma_DvCs"))
				drFilter.Table.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));


			drFilter["Table_PH"] = drDmCt["Table_PH"];
			drFilter["Table_Ct"] = drDmCt["Table_Ct"];
			drFilter["User_Login"] = Element.sysUser_Id;
			drFilter["Ma_DvCs"] = Element.sysMa_DvCs;

			dsVoucher.Clear();
			dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_BTTB", drFilter, CommandType.StoredProcedure);

			dtViewPh = dsVoucher.Tables[0];
			dtViewPh.TableName = (string)drDmCt["Table_Ph"];

			dtViewCt = dsVoucher.Tables[1];
			dtViewCt.TableName = (string)drDmCt["Table_Ct"];

            dtCtVt = dsVoucher.Tables[2];
            //dtCtVt.TableName = (string)drDmCt["Table_Ct"];

			//Thêm tổng tiền ở phía dưới
			if (dtViewCt.Columns.Contains("TTien_Nt") && dtViewCt.Columns.Contains("TTien_Nt3"))
			{
				DataColumn dcNew = new DataColumn("TTIEN", typeof(double));
				dcNew.Expression = "Tien + Tien3";
				dtViewCt.Columns.Add(dcNew);

				dcNew = new DataColumn("TTIEN_NT", typeof(double));
				dcNew.Expression = "Tien_Nt + Tien_Nt3";
				dtViewCt.Columns.Add(dcNew);
			}

			if (!dtViewPh.Columns.Contains("MARK"))
			{
				DataColumn dcMark = new DataColumn("MARK", typeof(bool));
				dcMark.DefaultValue = false;
				dtViewPh.Columns.Add(dcMark);
			}

			bdsViewPh.DataSource = dtViewPh;
			dgvViewPh.DataSource = bdsViewPh;

			bdsViewCt.DataSource = dtViewCt;
			dgvViewCt.DataSource = bdsViewCt;

            bdsCtVt.DataSource = dtCtVt;
            dgvCtVt.DataSource = bdsCtVt;

			//Lay du lieu tu Ct len Ph theo danh sach Carry_Header
			Common.CopyDataColumn(dtViewCt, dtViewPh, (string)drDmCt["Update_Header"]);

			
			DataRow[] arrdrViewCt;
			DataRow drViewCt;
			foreach (DataRow drViewPh in dtViewPh.Rows)
			{
				string strStt = (string)drViewPh["Stt"];
				arrdrViewCt = dtViewCt.Select("Stt = '" + strStt + "'");

				if (arrdrViewCt.Length > 0)
					drViewCt = arrdrViewCt[0];
				else
					continue;

				Common.CopyDataRow(drViewCt, drViewPh, (string)drDmCt["Update_Header"]);
			}

			bdsViewPh.MoveLast();

			this.bdsSearch = bdsViewPh;
			this.ExportControl = dgvViewPh;
		}

        private void FillData_XuatVitri(DataRow drFilter)
        {
            if (!drFilter.Table.Columns.Contains("Table_PH"))
                drFilter.Table.Columns.Add(new DataColumn("Table_PH", typeof(string)));

            if (!drFilter.Table.Columns.Contains("Table_Ct"))
                drFilter.Table.Columns.Add(new DataColumn("Table_Ct", typeof(string)));

            if (!drFilter.Table.Columns.Contains("User_LogIn"))
                drFilter.Table.Columns.Add(new DataColumn("User_LogIn", typeof(string)));

            if (!drFilter.Table.Columns.Contains("Ma_DvCs"))
                drFilter.Table.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));


            drFilter["Table_PH"] = drDmCt["Table_PH"];
            drFilter["Table_Ct"] = drDmCt["Table_Ct"];
            drFilter["User_Login"] = Element.sysUser_Id;
            drFilter["Ma_DvCs"] = Element.sysMa_DvCs;

            dsVoucher.Clear();
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_DNX", drFilter, CommandType.StoredProcedure);

            dtViewPh = dsVoucher.Tables[0];
            dtViewPh.TableName = (string)drDmCt["Table_Ph"];

            dtViewCt = dsVoucher.Tables[1];
            dtViewCt.TableName = (string)drDmCt["Table_Ct"];

            //Thêm tổng tiền ở phía dưới
            if (dtViewCt.Columns.Contains("TTien_Nt") && dtViewCt.Columns.Contains("TTien_Nt3"))
            {
                DataColumn dcNew = new DataColumn("TTIEN", typeof(double));
                dcNew.Expression = "Tien + Tien3";
                dtViewCt.Columns.Add(dcNew);

                dcNew = new DataColumn("TTIEN_NT", typeof(double));
                dcNew.Expression = "Tien_Nt + Tien_Nt3";
                dtViewCt.Columns.Add(dcNew);
            }

            if (!dtViewPh.Columns.Contains("MARK"))
            {
                DataColumn dcMark = new DataColumn("MARK", typeof(bool));
                dcMark.DefaultValue = false;
                dtViewPh.Columns.Add(dcMark);
            }

            bdsViewPh.DataSource = dtViewPh;
            dgvViewPh.DataSource = bdsViewPh;

            bdsViewCt.DataSource = dtViewCt;
            dgvViewCt.DataSource = bdsViewCt;

            //Lay du lieu tu Ct len Ph theo danh sach Carry_Header
            Common.CopyDataColumn(dtViewCt, dtViewPh, (string)drDmCt["Update_Header"]);


            DataRow[] arrdrViewCt;
            DataRow drViewCt;
            foreach (DataRow drViewPh in dtViewPh.Rows)
            {
                string strStt = (string)drViewPh["Stt"];
                arrdrViewCt = dtViewCt.Select("Stt = '" + strStt + "'");

                if (arrdrViewCt.Length > 0)
                    drViewCt = arrdrViewCt[0];
                else
                    continue;

                Common.CopyDataRow(drViewCt, drViewPh, (string)drDmCt["Update_Header"]);
            }

            bdsViewPh.Position = bdsViewPh.Find("Stt", strStt_Current);

            this.bdsSearch = bdsViewPh;
            this.ExportControl = dgvViewPh;
        }
		private void Filter()
		{
			DataTable dtFilter = new DataTable();

			dtFilter.Columns.Add(new DataColumn("Table_PH", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Table_Ct", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Ct_List", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("So_Ct1", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("So_Ct2", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tien1", typeof(double)));
			dtFilter.Columns.Add(new DataColumn("Tien2", typeof(double)));
			dtFilter.Columns.Add(new DataColumn("Dien_Giai", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Tte", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tk", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("No_Co", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tk_Du", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Thue", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Hd", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Km", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Bp", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Vt_Sp", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Nvu", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Kho", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Vt", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt_CbNv", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Job", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Kv", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Table", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();

			//Set Default 
			drFilter["Ma_Ct_List"] = strMa_Ct_List;
			drFilter["Ngay_Ct1"] = Element.sysNgay_Ct1;
			drFilter["Ngay_Ct2"] = Element.sysNgay_Ct2;
			drFilter["Table_PH"] = (string)drDmCt["Table_Ph"];
			drFilter["Table_Ct"] = (string)drDmCt["Table_Ct"];
			drFilter["Ma_DvCs"] = Element.sysMa_DvCs;

			frmFilter frm = new frmFilter();
			frm.Load(drFilter);

			if (frm.isAccept)
			{
				this.FillData(drFilter);

				Element.sysNgay_Ct1 = Convert.ToDateTime(drFilter["Ngay_Ct1"]);
				Element.sysNgay_Ct2 = Convert.ToDateTime(drFilter["Ngay_Ct2"]);
			}
		}

		private void Print(bool bPreview)
		{
			if (bdsViewPh.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			DataRow[] drArrPrint = dtViewPh.Select("Mark = true");
			
			bool bInVisibleNextPrint = false;

            if (strMa_Ct_List != "CTSC")
                Voucher.Print_BTTB(drCurrent["Stt"].ToString(), bPreview, true, ref bInVisibleNextPrint);
            else
            {
                DataTable dtViewCt1 = SQLExec.ExecuteReturnDt("SELECT Stt0 FROM R06CT_BTTB WHERE Stt = '"+ drCurrent["Stt"] +"'");
               
                foreach (DataRow dr in dtViewCt1.Rows)
                    Voucher.Print_CTSC(drCurrent["Stt"].ToString(), Convert.ToInt16(dr["Stt0"]), bPreview, true, ref bInVisibleNextPrint);
            }
		}

		private void Design()
		{
			string strMa_Ct = strMa_Ct_List.Split(',')[0];

			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
			
            string strReportTag = string.Empty;
            drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            // XỬ LÝ BTNB
            if (strMa_Ct == "BTNB" && (string)drCurrent["Ma_Dt"] == "PCNTT")
                strReportTag = "_CNTT";

            string strReport_File = (string)drDmCt["Report_File"] + strReportTag;

			RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
			frm.Load(strReport_File);
		}
        private void DataGridView_Language()
        {
            if (dgvViewCt.Columns.Contains("Ten_Vt_HH") && Common.InlistLike(strMa_Ct_List, "BTTT"))
                dgvViewCt.Columns["Ten_Vt_HH"].HeaderText = "Người thực hiện";

            if (dgvViewCt.Columns.Contains("Phuong_An") && strMa_Ct_List == "BBBN")
                dgvViewCt.Columns["Phuong_An"].HeaderText = "Kết luận";

            if (dgvViewCt.Columns.Contains("Ngay_BD") && strMa_Ct_List == "BTNB")
                dgvViewCt.Columns["Ngay_BD"].HeaderText = "Ngày bắt đầu";

            if (dgvViewCt.Columns.Contains("Noi_Dung") && strMa_Ct_List == "CTSC")
                dgvViewCt.Columns["Noi_Dung"].HeaderText = "Người nhận việc";

            if (dgvViewCt.Columns.Contains("Ten_Vt_HH") && strMa_Ct_List == "CTSC")
                dgvViewCt.Columns["Ten_Vt_HH"].HeaderText = "Người phối hợp";

            if (dgvViewPh.Columns.Contains("Ngay_Bg") && Common.InlistLike(strMa_Ct_List, "GRVC"))
                dgvViewPh.Columns["Ngay_Bg"].HeaderText = "Ngày dự kiến hàng về";

            if (dgvViewCt.Columns.Contains("Noi_Dung") && strMa_Ct_List == "GDKC")
                dgvViewCt.Columns["Noi_Dung"].HeaderText = "Tên vật tư - phương tiện - nhãn hiệu - TP hóa học";

            if (dgvViewCt.Columns.Contains("Ghi_Chu") && strMa_Ct_List == "GDKC")
                dgvViewCt.Columns["Ghi_Chu"].HeaderText = "Ghi chú - Tên lái xe";

            if (dgvViewCt.Columns.Contains("Ten_Vt") && strMa_Ct_List == "GDKC")
                dgvViewCt.Columns["Ten_Vt"].HeaderText = "Mã số";

            if (dgvViewCt.Columns.Contains("HBUI") && strMa_Ct_List == "GCTC")
                dgvViewCt.Columns["HBui"].HeaderText = "Rắn";

            if (dgvViewCt.Columns.Contains("Lo") && strMa_Ct_List == "GCTC")
                dgvViewCt.Columns["Lo"].HeaderText = "Lỏng";

            if (dgvViewCt.Columns.Contains("Duc") && strMa_Ct_List == "GCTC")
                dgvViewCt.Columns["Duc"].HeaderText = "Khí";

            if (dgvViewCt.Columns.Contains("Noi_Dung") && strMa_Ct_List == "GCTC")
                dgvViewCt.Columns["Noi_Dung"].HeaderText = "Số xe";

            if (dgvViewCt.Columns.Contains("Noi_Dung") && strMa_Ct_List == "GNTC")
                dgvViewCt.Columns["Noi_Dung"].HeaderText = "Họ và tên";
            if (dgvViewCt.Columns.Contains("Ten_Vt") && strMa_Ct_List == "GNTC")
                dgvViewCt.Columns["Ten_Vt"].HeaderText = "Năm sinh";
            if (dgvViewCt.Columns.Contains("Phuong_An") && strMa_Ct_List == "GNTC")
                dgvViewCt.Columns["Phuong_An"].HeaderText = "Số CMND";

            if (dgvViewCt.Columns.Contains("So_Luong0") && strMa_Ct_List == "GRVC")
                dgvViewCt.Columns["So_Luong0"].HeaderText = "Khối lượng về";
        }
		private void BindingTong_Tien()
		{
			numTTien0.DataBindings.Add("Value", bdsViewPh, "TTien0");
			numTTien_Nt0.DataBindings.Add("Value", bdsViewPh, "TTien_Nt0");

			numTTien3.DataBindings.Add("Value", bdsViewPh, "TTien3");
			numTTien_Nt3.DataBindings.Add("Value", bdsViewPh, "TTien_Nt3");

			numTSo_Luong.DataBindings.Add("Value", bdsViewPh, "TSo_Luong");
			
		}

		private void FormLayout()
		{
			dgvViewPh.Location = new Point(3, 3);
			dgvViewPh.Width = this.Width - 12;
			dgvViewPh.Height = (int)(0.5 * this.Height);

			
			
			
		}

		private void Mark()
		{
			if (bdsViewPh.Position < 0)
				return;

			if (dgvViewPh.Columns[dgvViewPh.CurrentCell.ColumnIndex].Name != "LOCKED")
			{
				if (dgvViewPh.Columns.Contains("Mark"))
				{
					drCurrent = ((DataRowView)bdsViewPh.Current).Row;

					drCurrent["Mark"] = !(bool)drCurrent["Mark"];
					dgvViewPh.Refresh();
				}
			}
		}

		private void DanhSoCt()
		{
			if (bdsViewPh.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			string strStt = string.Empty;
			string strMa_Ct = (string)drCurrent["Ma_Ct"];
			string strSo_Ct = string.Empty;

			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);

			frmDanhSo_Ct frm = new frmDanhSo_Ct();
			//frm.txtSo_Ct_Format.Text = strSo_Ct;
			frm.Load();

			if (frm.isAccept)
			{
				int iSo_Ct = Convert.ToInt32(frm.numSo_Ct.Value);
				string strFormat_Text = frm.txtSo_Ct_Format.Text;

				int iPrefix = strFormat_Text.IndexOf('#');
				int iSuffix = strFormat_Text.LastIndexOf('#') + 1;

				string strPrefix = strFormat_Text.Substring(0, iPrefix);
				string strSuffix = strFormat_Text.Substring(iSuffix);
				string strMidText = strFormat_Text.Substring(iPrefix, strFormat_Text.Length - strPrefix.Length - strSuffix.Length);

				for (int i = 0; i < bdsViewPh.Count; i++)
				{
					bdsViewPh.Position = i;

					drCurrent = ((DataRowView)bdsViewPh.Current).Row;
					strStt = (string)drCurrent["Stt"];

					strSo_Ct = strPrefix + iSo_Ct.ToString().PadLeft(strMidText.Length, '0') + strSuffix;

					string strSQLExec = @"
							DECLARE @So_Ct1 NVARCHAR(50), @Stt1 NVARCHAR(50)
							SELECT @So_Ct1 = @So_Ct, @Stt1 = @Stt";

					Hashtable htPara = new Hashtable();
					htPara["SO_CT"] = strSo_Ct;
					htPara["STT"] = strStt;

					if (drDmCt["Table_Ph"].ToString() != "")
						strSQLExec += " UPDATE " + drDmCt["Table_Ph"].ToString() + " SET So_Ct = @So_Ct1 WHERE Stt = @Stt1 ";

					if (drDmCt["Table_Ct"].ToString() != "")
						strSQLExec += " UPDATE " + drDmCt["Table_Ct"].ToString() + " SET So_Ct = @So_Ct1 WHERE Stt = @Stt1 ";

					

					if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
					{
						drCurrent["So_Ct"] = strSo_Ct;
					}

					iSo_Ct++;
				}
			}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsViewPh.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsViewPh.Position >= 0)
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			else
			{
				drCurrent = dtViewPh.NewRow();
				drCurrent["Ma_Ct"] = strMa_Ct_List.Split(',')[0];
				drCurrent["Stt"] = "0";
				//drCurrent["Ma_Tte"] = Element.sysMa_Tte;
				//drCurrent["Ty_Gia"] = 1;
			}

			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", (string)drCurrent["Ma_Ct"]);
			
			string strMethodName = (string)drDmCt["Edit_Voucher_Method"];

			string[] arrStr = strMethodName.Split(':');
			if (arrStr.Length != 3)
			{
				Common.MsgCancel("Định dạng MethodName = " + strMethodName + " không đúng");
				return;
			}

			Assembly asl = Assembly.Load(arrStr[0]);
			Type type = asl.GetType(arrStr[1]);

			frmVoucher_Edit frmEdit = (frmVoucher_Edit)Activator.CreateInstance(type);
			frmEdit.Load(enuNew_Edit, drCurrent, dsVoucher);

			if (bdsViewPh.Find("Stt", frmEdit.drEdit["Stt"].ToString()) >= 0)
				bdsViewPh.Position = bdsViewPh.Find("Stt", frmEdit.drEdit["Stt"].ToString());

			
		}

		public override void Delete()
		{
			if (bdsViewPh.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            string strStt = ((string)drCurrent["Stt"]).Trim();
            DataRow dr = DataTool.SQLGetDataRowByID("R06PH_BTTB", "STT", strStt);

            if ((bool)dr["Duyet_TP"] || (bool)dr["Duyet_KTCDAT"])
            {
                Common.MsgCancel("Chứng từ đã được duyệt, không thể xóa !");
                return;
            }

            //if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
            //    return;

			if (!Element.sysIs_Admin)
			{
				string strCreate_User = (string)drCurrent["Create_Log"];

				if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

					if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
					{
						if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
						{
							Common.MsgCancel("Không được xóa chứng từ do " + strCreate_User.Substring(14) + " lập, liên hệ với Admin!");
							return;
						}
					}
				}
			}
            if ((bool)SQLExec.ExecuteReturnValue("SELECT dbo.fn_Check_Del_Ct('" + strStt + "')"))
            {
                Common.MsgCancel("Chứng từ đã được kế thừa lập chứng từ khác !");
                return;
            }
			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE"), "N"))
				return;


			string strMa_Ct = ((string)drCurrent["Ma_Ct"]).Trim();

			
            if (Voucher.SQLDeleteCt(strStt, strMa_Ct))
			{
                //Bằng xóa chứng từ trong bảng RESOURCE
                string strDelete3 = "DELETE FROM R04CTSO_RESOURCE WHERE Stt = '" + strStt + "'";
                SQLExec.Execute(strDelete3);

                //string strDelete = "DELETE FROM R50THEPMN3_RESOURCE..R04CTSO_RESOURCE WHERE Stt = '" + strStt + "'";
                //SQLExec.Execute(strDelete);

				bdsViewPh.RemoveAt(bdsViewPh.Position);
				dtViewPh.AcceptChanges();

				if (strMa_Ct == "BTNB")
                    SQLExec.Execute("DELETE FROM R06CTDMVT WHERE Stt = '" + strStt + "'");
				else if (strMa_Ct == "GNTC")
					SQLExec.Execute("DELETE FROM R10DSCBNVTHEOCA WHERE Ma_Dt_CbNv = '" + strStt + "'");

			}
		}

		public override void EditHanTt()
		{
			if (bdsViewPh.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			Voucher.HanTt1(drCurrent);
		}

		#endregion

		

		

		#region Event
		
		

		void frmViewPh_Resize(object sender, EventArgs e)
		{
			this.FormLayout();
		}

		void KeyDownEvent(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F9:
					this.Filter();
					break;

				case Keys.F7:
					switch (e.Modifiers)
					{
						case Keys.Shift:
							Design();
							break;

						case Keys.Control:
							Print(true);
							break;

						case Keys.None:
							Print(false);
							break;
					}
					break;

				case Keys.Space: //Nhan them
					Mark();

					break;

				case Keys.A:
					if (dgvViewPh.Columns.Contains("Mark"))
						if (e.Modifiers == Keys.Control)
						{
							for (int i = 0; i < dgvViewPh.RowCount; i++)
							{
								dgvViewPh.Rows[i].Cells["Mark"].Value = true;
							}

							dgvViewPh.Refresh();
						}

					break;

				case Keys.U:
					if (dgvViewPh.Columns.Contains("Mark"))
						if (e.Modifiers == Keys.Control)
						{
							for (int i = 0; i < dgvViewPh.RowCount; i++)
							{
								dgvViewPh.Rows[i].Cells["Mark"].Value = false;
							}

							dgvViewPh.Refresh();
						}

					break;
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F3 && e.Shift)
			{
				this.DanhSoCt();
				return;
			}
			else

				base.OnKeyDown(e);
		}

		void bdsViewPh_PositionChanged(object sender, EventArgs e)
		{
			PositionChange();
		}

		private void PositionChange()
		{
			if (bdsViewPh.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			string strStt = (string)drCurrent["Stt"];

			bdsViewCt.Filter = "(Stt = '" + strStt + "')";
            bdsCtVt.Filter = "(Stt = '" + strStt + "')";
            
		}
        private void EditCtDmSO(enuEdit enuNew_Edit)
        {
        }
		void btNew_Click(object sender, EventArgs e)
		{
            if (rsTabControl1.SelectedTab == pageDMVTLIST)
                EditCtDmSO(enuEdit.New);
            else
                Edit(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
            if (rsTabControl1.SelectedTab == pageDMVTLIST)
                EditCtDmSO(enuEdit.Edit);
            else
                Edit(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
           Delete();
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			Filter();
		}

		void btPreview_Click(object sender, EventArgs e)
		{
			this.Print(true);
		}

		void btPrint_Click(object sender, EventArgs e)
		{
			this.Print(false);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			Voucher.ImportExcel_Voucher();

			DataTable dtFilter = new DataTable();

			dtFilter.Columns.Add(new DataColumn("Table_PH", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Table_Ct", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Ct_List", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("So_Ct1", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("So_Ct2", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tien1", typeof(double)));
			dtFilter.Columns.Add(new DataColumn("Tien2", typeof(double)));
			dtFilter.Columns.Add(new DataColumn("Dien_Giai", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Tte", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tk", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("No_Co", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tk_Du", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Thue", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Hd", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Km", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Bp", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Vt_Sp", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Nvu", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Kho", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Vt", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt_CbNv", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Job", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Kv", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Table", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();

			//Set Default 
			drFilter["Ma_Ct_List"] = strMa_Ct_List;
			drFilter["Ngay_Ct1"] = Element.sysNgay_Ct1;
			drFilter["Ngay_Ct2"] = DateTime.Now;
			drFilter["Table_PH"] = (string)drDmCt["Table_Ph"];
			drFilter["Table_Ct"] = (string)drDmCt["Table_Ct"];
			drFilter["Ma_DvCs"] = Element.sysMa_DvCs;

			this.FillData(drFilter);
		}

		void btExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		void dgvViewCt_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvViewPh_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvViewPh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value == null || e.Value == DBNull.Value)
				return;

			if (e.RowIndex < 0)
				return;

			if (dgvViewPh.Columns.Contains("Ma_Tte"))
			{
				if (dgvViewPh.Rows[e.RowIndex].Cells["Ma_Tte"].Value != null)
				{
					if (dgvViewPh.Rows[e.RowIndex].Cells["Ma_Tte"].Value.ToString() != Element.sysMa_Tte)
						e.CellStyle.ForeColor = Color.FromArgb(255, 49, 106, 197);
					else
						e.CellStyle.ForeColor = dgvViewPh.DefaultCellStyle.ForeColor;
				}
			}
			if (dgvViewPh.Columns.Contains("Mark"))
			{
				if (dgvViewPh.Rows[e.RowIndex].Cells["Mark"].Value != null)
				{
					if ((bool)dgvViewPh.Rows[e.RowIndex].Cells["Mark"].Value == true)
					{
						e.CellStyle.BackColor = Color.FromArgb(255, 0, 0, 255);
					}
				}
			}
            if (dgvViewPh.Columns.Contains("Ngay_Ra"))
            {
                if (dgvViewPh.Rows[e.RowIndex].Cells["Ngay_Ra"].Value != null)
                {
                    if (dgvViewPh.Rows[e.RowIndex].Cells["Ngay_Ra"].Value.ToString() == "01/01/1900 12:00:00 SA")
                    {
                        dgvViewPh.Rows[e.RowIndex].Cells["Ngay_Ra"].Value = "";
                    }
                }
            }
            if (dgvViewPh.Columns.Contains("Ngay_Vao"))
            {
                if (dgvViewPh.Rows[e.RowIndex].Cells["Ngay_Vao"].Value != null)
                {
                    if (dgvViewPh.Rows[e.RowIndex].Cells["Ngay_Vao"].Value.ToString() == "01/01/1900 12:00:00 SA")
                    {
                        dgvViewPh.Rows[e.RowIndex].Cells["Ngay_Vao"].Value = "";
                    }
                }
            }
		}

		void dgvViewPh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{

            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            bool Is_Duyet = false;
            string strColumnName = dgvViewPh.Columns[e.ColumnIndex].Name;
            drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            string strStt = (string)drCurrent["Stt"];
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", (string)drCurrent["Ma_Ct"]);


            DataRow drPh = DataTool.SQLGetDataRowByID("R06PH_BTTB", "Stt", (string)drCurrent["Stt"]);
            string strDuyet_PxCd_Log = drPh["DUYET_PXCD_LOG"].ToString();
            string strDuyet_Tp_Log = drPh["DUYET_TP_LOG"].ToString();
            string strDuyet_KtCdAt_Log = drPh["DUYET_KTCDAT_LOG"].ToString();               
            string strDuyet_GD_Log = drPh["DUYET_GD_LOG"].ToString();
            string strDuyet_TcHc_Log = drPh["DUYET_TCHC_LOG"].ToString();


            if (strColumnName == "DUYET_TP")
            {
                bool bDuyet = true;

                if (!Element.sysIs_Admin)
                {
                    bDuyet = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);

                    if (!bDuyet)
                        bDuyet = Common.CheckPermission("IS_PTP", enuPermission_Type.Allow_Access);
                }

                string strCreate_User = (string)drCurrent["Create_Log"];
                string strUser_Allow = string.Empty;
                string strUser_Group = string.Empty;
                string strMa_Bp_DvSD = string.Empty;
                string strMa_Bp = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetMemberList('" + Element.sysUser_Id + "')");
                //string strMa_Bp_DvSD = (string)SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Dt_DvSd) FROM R06CT_BTTB WHERE Stt = '" + strStt + "'");
                if(!Common.Inlist(strMa_Ct_List, "GDKC,GCTC,GNTC"))
                    strMa_Bp_DvSD = (string)SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Dt) FROM R06PH_BTTB WHERE Stt = '" + strStt + "'");
                else
                {
					string strMember = SQLExec.ExecuteReturnValue("SELECT MAX(Member_ID) FROM R00MEMBER WHERE Ma_Dt_CbNv IN (SELECT MAX(Ma_Dt_CbNv) FROM R06PH_BTTB WHERE Stt = '" + strStt + "')").ToString();
					strMa_Bp_DvSD = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetMemberList('" + strMember + "')");

				}
                    //strMa_Bp_DvSD = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt IN (SELECT MAX(Ma_Dt_CbNv) FROM R06PH_BTTB WHERE Stt = '" + strStt + "')");

                

                if (strCreate_User != string.Empty)
                {
                    strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                    strUser_Group = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetList('" + Element.sysUser_Id + "')") + "";
                }
                if (!strMa_Bp.Contains(strMa_Bp_DvSD))
                {
                    Common.MsgOk("Đơn vị " + strMa_Bp + " không được phép duyệt của đơn vị " + strMa_Bp_DvSD  + "");
                    bDuyet = false;
                }
                if (bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
                {
                    Voucher.DuyetCtBTTB("R06PH_BTTB", strStt, drCurrent, "", "DUYET_TP", "DUYET_TP", dgvViewPh);
                   
                    
                }
                else
                {
                    dgvViewPh.Columns["DUYET_TP"].ReadOnly = false;
                }
            }
            

            if (strColumnName == "DUYET_KTCDAT")
            {
                bool bDuyet = true;


                if (!Element.sysIs_Admin)
                    bDuyet = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);


                string strCreate_User = (string)drCurrent["Create_Log"];
                string strUser_Allow = string.Empty;

                if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                }
                if (bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
                {
                    Voucher.DuyetCtBTTB("R06PH_BTTB", strStt, drCurrent, "DUYET_TP", "DUYET_KTCDAT", "DUYET_KTCDAT", dgvViewPh);

                }

            }
            if (strColumnName == "DUYET_GIAMDOC")
            {
                bool bDuyet = true;

                if (!Element.sysIs_Admin)
                    bDuyet = Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access);
               
                
                string strCreate_User = (string)drCurrent["Create_Log"];
                string strUser_Allow = string.Empty;

                if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                }
                if (bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
                {
                    if (drCurrent["GD_Duyet"].ToString() != Element.sysUser_Id)
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chứng từ được trình '" + drCurrent["GD_Duyet"] + "'" : "Do not register transaction type";
                        Common.MsgCancel(strMsg);
                        dgvViewPh.Columns["DUYET_GIAMDOC"].ReadOnly = true;
                    }
                    else
                    {
                       
                        if (!(bool)(drCurrent["DUYET_KTCDAT"]) && !Common.Inlist(strMa_Ct_List,"GDKC,GVTC,GCTC,GNTC,GRVC"))
                            return;
                        else
                            Voucher.DuyetCtBTTB("R06PH_BTTB", strStt, drCurrent, "DUYET_KTCDAT", "DUYET_GIAMDOC", "DUYET_GD", dgvViewPh);

                        if (!(bool)(drCurrent["DUYET_TP"]) && Common.Inlist(strMa_Ct_List, "GDKC,GVTC,GCTC,GNTC,GRVC,GNTC,BBXE"))
                            return;
                        else
                            Voucher.DuyetCtBTTB("R06PH_BTTB", strStt, drCurrent, "DUYET_TP", "DUYET_GIAMDOC", "DUYET_GD", dgvViewPh);
                       
                    }
                }
                else
                {
                    dgvViewPh.Columns["DUYET_GIAMDOC"].ReadOnly = false;
                }
            }

            if (strColumnName == "DUYET_ATV")
            {
                bool bDuyet = true;

                if (!Element.sysIs_Admin)
                    bDuyet = Common.CheckPermission("IS_TP_ATV", enuPermission_Type.Allow_Access);


                string strCreate_User = (string)drCurrent["Create_Log"];
                string strUser_Allow = string.Empty;

                if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                }
                if (bDuyet)
                {
                   
                        if (!(bool)(drCurrent["DUYET_TP"]))
                            return;

                        Voucher.DuyetCtBTTB("R06PH_BTTB", strStt, drCurrent, "DUYET_TP", "DUYET_ATV", "DUYET_ATV", dgvViewPh);
                        
                    //}
                }
                else
                {
                    dgvViewPh.Columns["DUYET_ATV"].ReadOnly = false;
                }
            }
            if (strColumnName == "DUYET_TCHC")
            {
                bool bDuyet = true;

                if (!Element.sysIs_Admin)
                    bDuyet = Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access);


                string strCreate_User = (string)drCurrent["Create_Log"];
                string strUser_Allow = string.Empty;

                if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                }
                if (bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
                {
                    if (Convert.ToBoolean(drCurrent["DUYET_TCHC"]) && strDuyet_TcHc_Log.Substring(14) != Element.sysUser_Id)
                    {
                        dgvViewPh.Columns["DUYET_TCHC"].ReadOnly = true;
                    }
                    else
                    {
                        if (!(bool)(drCurrent["DUYET_ATV"]) && strMa_Ct_List == "GNTC")
                            return;

                        Voucher.DuyetCtBTTB("R06PH_BTTB", strStt, drCurrent, "DUYET_ATV", "DUYET_TCHC", "DUYET_TCHC", dgvViewPh);
                        
                    }
                }
                else
                {
                    dgvViewPh.Columns["DUYET_TCHC"].ReadOnly = false;
                }
            }
            DataRow drPh_Kq = DataTool.SQLGetDataRowByID("R06PH_BTTB", "Stt", strStt);
            if (strColumnName == "KET_QUA" && (bool)drPh_Kq["Duyet_Tp"] && Common.Inlist(strMa_Ct_List, "BTNB,BTTT"))
            {
                bool bToTruong = Common.CheckPermission("IS_TOTRUONG", enuPermission_Type.Allow_Access);
                if (bToTruong)
                {
                    frmKet_Qua_BTTB frm = new frmKet_Qua_BTTB();
                    frm.Load(drCurrent);
                }
            }
            else if (strColumnName == "KET_QUA" && Common.Inlist(strMa_Ct_List, "BTKH"))
            {
                bool bToTruong = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
                if (bToTruong)
                {
                    frmKet_Qua_BTTB frm = new frmKet_Qua_BTTB();
                    frm.Load(drCurrent);
                }
            }
		}

		#endregion


	}
}
