using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
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
using System.Net;


namespace RosyModule
{
	public partial class frmVoucher_View : RosySystem.Customize.frmView
	{
		#region Fields

		public DataSet dsVoucher = new DataSet("dsVoucher");
        public DataSet dsVoucher_Newdata = new DataSet("dsVoucher");

		public DataTable dtViewPh;
        public DataTable dtViewPh_Newdata;
		public DataTable dtViewCt;
		public DataTable dtResource;
        DataTable dtExportExcel;
		object objFileContent = null;

		public BindingSource bdsViewPh = new BindingSource();
		public BindingSource bdsViewCt = new BindingSource();
		public BindingSource bdsResource = new BindingSource();

        BindingSource bdsExportExcel = new BindingSource();
		
        public rsDataGridView dgvViewPh = new rsDataGridView();
		public rsDataGridView dgvViewCt = new rsDataGridView();
		public rsDataGridView dgvResource = new rsDataGridView();

        rsDataGridView dgvExportExcel = new rsDataGridView();

		public DataRelation drlView;

		public string strMa_Ct_List = string.Empty;
		public DataRow drCurrent;
		public DataRow drDmCt;
		public DataRow drResource;
        bool bTb = false;
		#endregion

		#region Contructor

		public frmVoucher_View()
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
			btExport.Click += new EventHandler(btExport_Click);
            btDongDh.Click += new EventHandler(btDongDh_Click);
			btEditTauHang.Click += new EventHandler(btEditTauHang_Click);
			btEditTauHangGD.Click += new EventHandler(btEditTauHangGD_Click);

			dgvViewPh.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvViewPh_CellMouseClick);
            dgvViewPh.CellDoubleClick += new DataGridViewCellEventHandler(dgvViewPh_CellDoubleClick);
			dgvViewPh.CellClick += new DataGridViewCellEventHandler(dgvViewPh_CellClick);
			dgvViewPh.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvViewPh_CellFormatting);
			dgvViewPh.Enter += new EventHandler(dgvViewPh_Enter);
			dgvViewCt.Enter += new EventHandler(dgvViewCt_Enter);

			btUploadFile.Click += new EventHandler(btUploadFile_Click);
			btRemoveFile.Click += new EventHandler(btRemoveFile_Click);
			btDownloadFile.Click += new EventHandler(btDownloadFile_Click);

            timer_Newdata.Tick += new EventHandler(timer_Newdata_Tick);
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

			DataRow drFilter = dtFilter.NewRow();
			drFilter["Ma_Ct_List"] = strMa_Ct_List;
			drFilter["Ngay_Ct1"] = dteNgay_Ct1;
			drFilter["Ngay_Ct2"] = dteNgay_Ct2;

			this.FillData(drFilter);

            if (!Element.sysIs_Admin && strMa_Ct_List.StartsWith("PYC"))
            {
                dgvViewPh.Columns["PHAN_HOI_KHVT"].Visible = Common.CheckPermission("PHAN_HOI_KHVT", enuPermission_Type.Allow_Access);
            }	
			
			if(dgvViewPh.Columns.Contains("DUYET_PXCD"))
			{
				if (strMa_Ct_List == "PYCCK")
					dgvViewPh.Columns["DUYET_PXCD"].Visible = true;
				else
					dgvViewPh.Columns["DUYET_PXCD"].Visible = false;
			}
			
			this.BindingLanguage();
			this.BindingTong_Tien();

			this.FormLayout();

			//Sửa tên cột Duyet và Duyet_Huy trên SO
			if (Common.InlistLike(strMa_Ct_List, "SO,SOCP,LXH"))
			{
                if (Common.Inlist(strMa_Ct_List, "LXH") && dgvViewPh.Columns.Contains("DUYET"))
                    dgvViewPh.Columns["DUYET"].HeaderText = "Duyệt PKD";
                else if (!Common.Inlist(strMa_Ct_List, "LXH") && dgvViewPh.Columns.Contains("DUYET"))
				    dgvViewPh.Columns["DUYET"].HeaderText = "Duyệt PKT";

                if (dgvViewPh.Columns.Contains("DUYET_HUY"))
                      dgvViewPh.Columns["DUYET_HUY"].HeaderText = "Đóng ĐH";
				if (dgvViewPh.Columns.Contains("GHI_CHU_HUY"))
					dgvViewPh.Columns["GHI_CHU_HUY"].HeaderText = "Lý do đóng ĐH";
				if (dgvViewPh.Columns.Contains("USER_HUY"))
					dgvViewPh.Columns["USER_HUY"].HeaderText = "User đóng ĐH";
				if (dgvViewPh.Columns.Contains("SO_LUONG0"))
					dgvViewPh.Columns["SO_LUONG0"].HeaderText = "Số bộ KCS";
			}
            else
                if (dgvViewPh.Columns.Contains("DUYET_HUY"))
                    dgvViewPh.Columns["DUYET_HUY"].HeaderText = "Hủy";

			if (Common.InlistLike(strMa_Ct_List, "BBPT,BBTH"))
			{
				if (dgvResource.Columns.Contains("FILE_NAME"))
					dgvResource.Columns["FILE_NAME"].HeaderText = "File biên bản";
			}
			if (strMa_Ct_List == "LXH")
			{
				if (dgvViewPh.Columns.Contains("GHI_CHU_HD"))
					dgvViewPh.Columns["GHI_CHU_HD"].HeaderText = "Ghi chú in lần 2";
			}

			if (strMa_Ct_List == "PO")
			{
				btEditTauHang.Visible = true;
                btEditTauHangGD.Visible = true;
			}

            if (Common.Inlist(strMa_Ct_List, "SO,SOCP,LXH"))
                btDongDh.Visible = true;
            else
                btDongDh.Visible = false;

			if (dgvViewPh.Columns.Contains("IS_VT_NHAN") && strMa_Ct_List.StartsWith("DT"))
			{
				dgvViewPh.Columns["IS_VT_NHAN"].HeaderText = "Đã in";
			}
            else if (dgvViewPh.Columns.Contains("IS_VT_NHAN") && strMa_Ct_List.StartsWith("PYC"))
            {
                dgvViewPh.Columns["IS_VT_NHAN"].HeaderText = "Đóng PYC";
            }
            else if (dgvViewPh.Columns.Contains("IS_VT_NHAN") && strMa_Ct_List.StartsWith("SO"))
            {
                dgvViewPh.Columns["IS_VT_NHAN"].HeaderText = "Bóc hàng trước";

            }
            if (strMa_Ct_List.StartsWith("PYCTH"))
            {
                if (dgvViewPh.Columns.Contains("DUYET_KTCDAT"))
                    dgvViewPh.Columns["DUYET_KTCDAT"].HeaderText = "Duyệt KTĐT/TCHC";

                if (dgvViewPh.Columns.Contains("NGAY_DUYET_KTCDAT"))
                    dgvViewPh.Columns["NGAY_DUYET_KTCDAT"].HeaderText = "Ngày KTĐT/TCHC duyệt";
            }


            if (dgvViewCt.Columns.Contains("So_Luong9") && Common.Inlist(strMa_Ct_List, "PNSB,PXSB"))
                dgvViewCt.Columns["So_Luong9"].HeaderText = "Khối lượng";
            if (dgvViewCt.Columns.Contains("So_Luong_Cay") && Common.Inlist(strMa_Ct_List, "PNSB,PXSB"))
                dgvViewCt.Columns["So_Luong_Cay"].HeaderText = "Số cây";
            if (dgvViewCt.Columns.Contains("Ghi_Chu") && Common.Inlist(strMa_Ct_List, "PNSB"))
                dgvViewCt.Columns["Ghi_Chu"].HeaderText = "Điểm KPH";
            if (dgvViewCt.Columns.Contains("Ghi_Chu") && Common.Inlist(strMa_Ct_List, "PXSB"))
                dgvViewCt.Columns["Ghi_Chu"].HeaderText = "Lý do hồi lò";
            if (dgvViewCt.Columns.Contains("DDai_Phoi") && strMa_Ct_List == "PNSB")
                dgvViewCt.Columns["DDai_Phoi"].HeaderText = "Độ dài TB";
            if (strMa_Ct_List == "BBPL")
            {
                dgvViewCt.Columns["So_PCan"].HeaderText = "Số phiếu cân";
                dgvViewCt.Columns["So_Luong0"].HeaderText = "KL hàng hóa";

                dgvViewCt.Columns["Ty_Le4"].HeaderText = "Tỷ lệ PL đặc biệt";
                dgvViewCt.Columns["So_Luong4"].HeaderText = "Khối lượng PL đặc biệt";
              

                dgvViewCt.Columns["Ty_Le1"].HeaderText = "Tỷ lệ PL loại 1";
                dgvViewCt.Columns["So_Luong1"].HeaderText = "Khối lượng PL loại 1";
            

                dgvViewCt.Columns["Ty_Le2"].HeaderText = "Tỷ lệ PL loại 2";
                dgvViewCt.Columns["So_Luong2"].HeaderText = "Khối lượng PL loại 2";
               

                dgvViewCt.Columns["Ty_Le3"].HeaderText = "Tỷ lệ PL loại 3";
                dgvViewCt.Columns["So_Luong3"].HeaderText = "Khối lượng PL loại 3";
              

                dgvViewCt.Columns["So_Luong"].HeaderText = "Tổng khối lượng";
                dgvViewCt.Columns["Tien"].HeaderText = "Tổng tiền";
            }
                this.Show();
		}

        public void Load_MaChine(string strMa_Ct_List, bool bTb)
        {
            this.strMa_Ct_List = strMa_Ct_List;
            this.Object_ID = strMa_Ct_List;
            this.Tag = "frmCT" + strMa_Ct_List.Split(',')[0];
            this.bTb = bTb;

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

            DataRow drFilter = dtFilter.NewRow();
            drFilter["Ma_Ct_List"] = strMa_Ct_List;
            drFilter["Ngay_Ct1"] = dteNgay_Ct1;
            drFilter["Ngay_Ct2"] = dteNgay_Ct2;

            this.FillData(drFilter);

            if (!Element.sysIs_Admin && strMa_Ct_List.StartsWith("PYC"))
            {
                dgvViewPh.Columns["PHAN_HOI_KHVT"].Visible = Common.CheckPermission("PHAN_HOI_KHVT", enuPermission_Type.Allow_Access);
            }

            if (dgvViewPh.Columns.Contains("DUYET_PXCD"))
            {
                if (strMa_Ct_List == "PYCCK")
                    dgvViewPh.Columns["DUYET_PXCD"].Visible = true;
                else
                    dgvViewPh.Columns["DUYET_PXCD"].Visible = false;
            }

            this.BindingLanguage();
            this.BindingTong_Tien();

            this.FormLayout();

            //Sửa tên cột Duyet và Duyet_Huy trên SO
           
            if (dgvViewPh.Columns.Contains("DUYET_HUY"))
                dgvViewPh.Columns["DUYET_HUY"].HeaderText = "Hủy";


         
             btDongDh.Visible = false;

            
            if (dgvViewPh.Columns.Contains("IS_VT_NHAN") && strMa_Ct_List.StartsWith("PYC"))
            {
                dgvViewPh.Columns["IS_VT_NHAN"].HeaderText = "Đóng PYC";
            }
           
            if (strMa_Ct_List.StartsWith("PYCTH"))
            {
                if (dgvViewPh.Columns.Contains("DUYET_KTCDAT"))
                    dgvViewPh.Columns["DUYET_KTCDAT"].HeaderText = "Duyệt KTĐT/TCHC";

                if (dgvViewPh.Columns.Contains("NGAY_DUYET_KTCDAT"))
                    dgvViewPh.Columns["NGAY_DUYET_KTCDAT"].HeaderText = "Ngày KTĐT/TCHC duyệt";
            }

            this.ShowDialog();
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

			dgvViewPh.Columns.Add("Is_Inherited", "Is_Inherited"); //Đánh dấu dòng
			dgvViewPh.Columns["Is_Inherited"].DataPropertyName = "IS_INHERITED";
			dgvViewPh.Columns["Is_Inherited"].ValueType = typeof(bool);
			dgvViewPh.Columns["Is_Inherited"].Visible = false;

			//dgvViewCt
			dgvViewCt.ReadOnly = true;
			dgvViewCt.strZone = (string)drDmCt["Zone_ViewCt"];

			dgvViewCt.BuildGridView(false);

			//dgvResource
			dgvResource.ReadOnly = true;
			dgvResource.strZone = "RESOURCE_SO";

			dgvResource.BuildGridView(false);

            dgvExportExcel.strZone = "EXPORT_UNC";
            dgvExportExcel.BuildGridView(true);

			//Position
			this.Controls.Add(dgvViewPh);
			this.Controls.Add(dgvViewCt);
			this.Controls.Add(dgvResource);
            this.Controls.Add(dgvExportExcel);


			//Nếu là phiếu yêu cầu cơ khí thì cho hiện lên
			if (!Common.Inlist(strMa_Ct, "PYCCK"))
			{
				if(dgvViewPh.Columns.Contains("Duyet_PXCD"))
					dgvViewPh.Columns["Duyet_PXCD"].Visible = false;

				if (dgvViewPh.Columns.Contains("Ngay_Duyet_PXCD"))
					dgvViewPh.Columns["Ngay_Duyet_PXCD"].Visible = false;
			}

            
		

			dgvViewPh.TabIndex = 0;
			dgvViewCt.TabIndex = 1;
			dgvResource.TabIndex = 1;
            dgvExportExcel.Visible = false;
		}

		private void FillData(DataRow drFilter)
		{
			if (!drFilter.Table.Columns.Contains("Table_PH"))
				drFilter.Table.Columns.Add(new DataColumn("Table_PH", typeof(string)));

			if (!drFilter.Table.Columns.Contains("Table_Ct"))
				drFilter.Table.Columns.Add(new DataColumn("Table_Ct", typeof(string)));
			
			if (!drFilter.Table.Columns.Contains("User_LogIn"))
				drFilter.Table.Columns.Add(new DataColumn("User_LogIn", typeof(string)));
            
            if (!drFilter.Table.Columns.Contains("Print_Count"))
                drFilter.Table.Columns.Add(new DataColumn("Print_Count", typeof(string)));

			if (!drFilter.Table.Columns.Contains("Ma_DvCs"))
				drFilter.Table.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));


			drFilter["Table_PH"] = drDmCt["Table_PH"];
			drFilter["Table_Ct"] = drDmCt["Table_Ct"];
			drFilter["Ma_DvCs"] = Element.sysMa_DvCs;
			drFilter["User_LogIn"] = Element.sysUser_Id;

			dsVoucher.Clear();
			
			if(Common.InlistLike(strMa_Ct_List, "PYCPT,PYCTH,PYCCK,BBPT,BBTH,DTCP,DTXE"))
				dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_PYC", drFilter, CommandType.StoredProcedure);
            else if (Common.Inlist(strMa_Ct_List, "DT,DTVPP"))
				dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_DT", drFilter, CommandType.StoredProcedure);
            else if (Common.InlistLike((string)drDmCt["Table_Ph"], "R06PH_BTTB"))
                dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_BTTB", drFilter, CommandType.StoredProcedure);
            else
            {
                dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter", drFilter, CommandType.StoredProcedure);
                dtExportExcel = dsVoucher.Tables[3];
            }

			dtViewPh = dsVoucher.Tables[0];
			dtViewPh.TableName = (string)drDmCt["Table_Ph"];

			dtViewCt = dsVoucher.Tables[1];
			dtViewCt.TableName = (string)drDmCt["Table_Ct"];

			if (dsVoucher.Tables.Count > 2)
				dtResource = dsVoucher.Tables[2];
           
			
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

            if (!dtViewPh.Columns.Contains("TEN_DT"))
            {
                DataColumn dcMark = new DataColumn("TEN_DT", typeof(string));
                dcMark.DefaultValue = "";
                dtViewPh.Columns.Add(dcMark);
            }

            bdsViewPh.DataSource = dtViewPh;
			dgvViewPh.DataSource = bdsViewPh;

			bdsViewCt.DataSource = dtViewCt;
			dgvViewCt.DataSource = bdsViewCt;

			bdsResource.DataSource = dtResource;
			dgvResource.DataSource = bdsResource;

            bdsExportExcel.DataSource = dtExportExcel;
            dgvExportExcel.DataSource = bdsExportExcel;

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

            if (DataTool.SQLCheckExist("R00Object", "Object_ID", "ACCESS_PRICE_PX") &&
                    !Common.CheckPermission("ACCESS_PRICE_PX", enuPermission_Type.Allow_Access) && drDmCt["Vt_Kt"].ToString() == "V" && drDmCt["Nh_Ct"].ToString() == "2")
            {
                foreach (DataColumn dc in dtViewPh.Columns)
                {
                    if (dc.ColumnName.StartsWith("GIA") || dc.ColumnName.StartsWith("TTIEN"))
                    {
                        if (dc.DataType == typeof(double) || dc.DataType == typeof(decimal))
                        {
                            //Gán cột dữ liệu về 0
                            foreach (DataRow dr in dtViewPh.Rows)
                            {
                                dr[dc] = 0;
                            }

                            //Ẩn cột dữ liệu
                            if (dgvViewPh.Columns.Contains(dc.ColumnName))
                                dgvViewPh.Columns[dc.ColumnName].Visible = false;
                        }
                    }
                }

                foreach (DataColumn dc in dtViewCt.Columns)
                {
                    if (dc.ColumnName.StartsWith("GIA") || dc.ColumnName.StartsWith("TIEN"))
                    {
                        if (dc.DataType == typeof(double) || dc.DataType == typeof(decimal))
                        {
                            //Gán cột dữ liệu về 0
                            foreach (DataRow dr in dtViewCt.Rows)
                            {
                                dr[dc] = 0;
                            }

                            //Ẩn cột dữ liệu
                            if (dgvViewCt.Columns.Contains(dc.ColumnName))
                                dgvViewCt.Columns[dc.ColumnName].Visible = false;
                        }
                    }
                }
                numTTien0.Visible = false;
                numTTien_Nt0.Visible = false;

                numTTien3.Visible = false;
                numTTien_Nt3.Visible = false;


            }


            if (DataTool.SQLCheckExist("R00Object", "Object_ID", "ACCESS_PRICE_PN") &&
                    !Common.CheckPermission("ACCESS_PRICE_PN", enuPermission_Type.Allow_Access) && drDmCt["Vt_Kt"].ToString() == "V" && drDmCt["Nh_Ct"].ToString() == "1")
            {
                foreach (DataColumn dc in dtViewPh.Columns)
                {
                    if (dc.ColumnName.StartsWith("GIA") || dc.ColumnName.StartsWith("TTIEN"))
                    {
                        if (dc.DataType == typeof(double) || dc.DataType == typeof(decimal))
                        {
                            //Gán cột dữ liệu về 0
                            foreach (DataRow dr in dtViewPh.Rows)
                            {
                                dr[dc] = 0;
                            }

                            //Ẩn cột dữ liệu
                            if (dgvViewPh.Columns.Contains(dc.ColumnName))
                                dgvViewPh.Columns[dc.ColumnName].Visible = false;
                        }
                    }
                }

                foreach (DataColumn dc in dtViewCt.Columns)
                {
                    if (dc.ColumnName.StartsWith("GIA") || dc.ColumnName.StartsWith("TIEN"))
                    {
                        if (dc.DataType == typeof(double) || dc.DataType == typeof(decimal))
                        {
                            //Gán cột dữ liệu về 0
                            foreach (DataRow dr in dtViewCt.Rows)
                            {
                                dr[dc] = 0;
                            }

                            //Ẩn cột dữ liệu
                            if (dgvViewCt.Columns.Contains(dc.ColumnName))
                                dgvViewCt.Columns[dc.ColumnName].Visible = false;
                        }
                    }
                }
                numTTien0.Visible = false;
                numTTien_Nt0.Visible = false;

                numTTien3.Visible = false;
                numTTien_Nt3.Visible = false;
            }

			bdsViewPh.MoveLast();

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
            dtFilter.Columns.Add(new DataColumn("Ma_Tb", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Duyet_Huy", typeof(bool)));
            dtFilter.Columns.Add(new DataColumn("Print_Count", typeof(string)));
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
        private void Print_BTTB(bool bPreview)
        {
            if (bdsViewPh.Position < 0)
                return;
           
            drCurrent = ((DataRowView)bdsViewPh.Current).Row;

            DataRow[] drArrPrint = dtViewPh.Select("Mark = true");
            bool bAcceptShowDialog = true;
            bool bInVisibleNextPrint = false;

            if (drArrPrint.Length > 1)
            {
                for (int i = 0; i < drArrPrint.Length; i++)
                {
                    drCurrent = drArrPrint[i];

                    if (i == 0)
                    {
                        bAcceptShowDialog = Voucher.Print(drCurrent["Stt"].ToString(), bPreview, true, ref bInVisibleNextPrint);
                    }
                    else
                    {
                        if (bAcceptShowDialog)
                            bAcceptShowDialog = Voucher.Print(drCurrent["Stt"].ToString(), bPreview, false, ref bInVisibleNextPrint);
                        else
                            break;
                    }

                    if (bAcceptShowDialog)
                    {
                        drCurrent["Mark"] = false;
                    }
                }
            }
            else
                Voucher.Print_BTTB(drCurrent["Stt"].ToString(), bPreview, true, ref bInVisibleNextPrint);
        }
		private void Print(bool bPreview)
		{
			if (bdsViewPh.Position < 0)
				return;
            DataRow drPh = DataTool.SQLGetDataRowByID("R80PH", "Stt", (string)drCurrent["Stt"]);
            
			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			DataRow[] drArrPrint = dtViewPh.Select("Mark = true");
			bool bAcceptShowDialog = true;
			bool bInVisibleNextPrint = false;

			if (drArrPrint.Length > 1)
			{
				for (int i = 0; i < drArrPrint.Length; i++)
				{
					drCurrent = drArrPrint[i];

					if (i == 0)
					{
						bAcceptShowDialog = Voucher.Print(drCurrent["Stt"].ToString(), bPreview, true, ref bInVisibleNextPrint);
					}
					else
					{
						if (bAcceptShowDialog)
							bAcceptShowDialog = Voucher.Print(drCurrent["Stt"].ToString(), bPreview, false, ref bInVisibleNextPrint);
						else
							break;
					}

					if (bAcceptShowDialog)
					{
						drCurrent["Mark"] = false;
					}
				}
			}
			else
				Voucher.Print(drCurrent["Stt"].ToString(), bPreview, true, ref bInVisibleNextPrint);
		}

		private void Design()
		{
			string strMa_Ct = strMa_Ct_List.Split(',')[0];
			string strReportTag = string.Empty;
            DataRow drCurrent_Ct = ((DataRowView)bdsViewCt.Current).Row;

            string strStt = drCurrent_Ct["Stt"].ToString();
			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
			string strReport_File = (string)drDmCt["Report_File"];
            string strTable_Ct = (string)drDmCt["Table_Ct"];
            
            if(!Element.sysIs_Admin)
                return;

			if (Common.Inlist(strMa_Ct, "HD,HDKG,HDHH"))
			{
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;

				frmIn_Ct_HD frm1 = new frmIn_Ct_HD();
				frm1.Load(drCurrent, false);


                strReport_File = strReport_File + (frm1.rdbHd_Tu_In.Checked ? "HDTI" : frm1.rdbHd_Dat_In.Checked ? "HDDI" : frm1.rdbHd_DT.Checked ? "HDDT" : frm1.rdbHd_Dt_Cd.Checked ?
                        "HDDTCD" : frm1.rdbHd_DT_PDF.Checked ? "HDDT_PDF" : frm1.rdbInvoice.Checked ? "INVOICE" : "PX");
			}
			if (strMa_Ct == "HDXK")
			{
                drCurrent = ((DataRowView)bdsViewPh.Current).Row;

                frmIn_Ct_HD frm1 = new frmIn_Ct_HD();
                frm1.Load(drCurrent, false);
                
                if (drCurrent_Ct["Ma_Nvu"].ToString() == "HDXK11")
                    strReport_File = strReport_File + (frm1.rdbHd_Tu_In.Checked ? "HDTIPHOI" : frm1.rdbHd_Dat_In.Checked ? "HDXKPHOI" : frm1.rdbInvoice.Checked ? "INVOICEPHOI" : "PX"); //"HDXK";
                else
                strReport_File = strReport_File + (frm1.rdbHd_Tu_In.Checked ? "HDTI" : frm1.rdbHd_Dat_In.Checked ? "HDXK" : frm1.rdbInvoice.Checked ? "INVOICE": "PX"); //"HDXK";
			}
		
          
			if (strMa_Ct == "SOCP")
			{
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;

				frmIn_Ct_SO frm1 = new frmIn_Ct_SO();
				frm1.Load(drCurrent);


				if (frm1.rdbLXH.Checked && frm1.rdbTien_Nt.Checked)
					strReport_File = strReport_File + "LxhCP_Nt";
                //else if (frm1.rdbLXH_KG.Checked)
                //    strReport_File = strReport_File + "LxhCP_kg";
                else if (frm1.rdbLXH_GH.Checked)
                    strReport_File = strReport_File + "LxhCP_GH";
				else
					strReport_File = strReport_File + "LxhCP";
			}
			if (strMa_Ct == "LXH")
			{
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;
				strReport_File = strReport_File + "LGH";
                if (drCurrent["So_Xa_Lan_Tau"].ToString() != "")
                    strReport_File += "_TAU";

            }
            if (strMa_Ct == "NM")
            {
                drCurrent = ((DataRowView)bdsViewPh.Current).Row;
                DataTable dtTable_Ct = DataTool.SQLGetDataTable(strTable_Ct, "*", "Stt = '" + drCurrent["Stt"] + "'", "");
                if (dtTable_Ct.Rows.Count < 4)
                    strReportTag = "_2D";
                strReport_File = strReport_File + strReportTag;
            }
            if (strMa_Ct == "NK")
            {
                
                frmIn_Ct_PNK frm1 = new frmIn_Ct_PNK();
                frm1.Load();
                
                if(frm1.rdbTien_Nt.Checked ==true)
                    strReport_File = strReport_File + "_NT";
            }
            if (Common.Inlist(strMa_Ct,"PXBR,PXDC"))
			{
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;

				frmIn_Ct_Px frm1 = new frmIn_Ct_Px();
				frm1.Load(drCurrent, false);
                if (frm1.rdbPx_BBXN.Checked == true)
                {
                    if (strMa_Ct == "PXDC" && drCurrent_Ct["Ht_Gn"].ToString() == "DD")
                        strReportTag = "DC_BBXNDD";
                    else if (drCurrent_Ct["Ht_Gn"].ToString().Length < 5)
                        strReportTag = "_BBXN";
                    else
                    {
                        if (Common.Inlist(drCurrent_Ct["Ht_Gn"].ToString().Substring(2, 4), "_GT_"))
                            strReportTag = "_BBXNGT";
                        else
                            strReportTag = "_BBXN";
                    }
                }
                else if (frm1.rdbPXDTGN.Checked == true)
                {
                    strReportTag = "_DTGN";
                }
                else if (frm1.rdbPX_DTGN_PDF.Checked == true)
                {
                    strReportTag = "_DTGNPDF";
                }
                else if (frm1.rdbPX_DTGN_CD.Checked == true)
                {
                    strReportTag = "_DTGNCD";
                }
                else if (frm1.rdbPXDT.Checked == true)
                {
                    strReportTag = "_DT";
                }
                else if (frm1.rdbPX_DT_PDF.Checked == true)
                {
                    strReportTag = "_DTPDF";
                }
                else if (frm1.rdbPX_DT_CD.Checked == true)
                {
                    strReportTag = "_DTCD";
                }

                strReport_File = strReport_File + strReportTag;
			}

			if (strMa_Ct.StartsWith("BN"))
			{
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;

				frmIn_Ct_UNC_ChonMau frm1 = new frmIn_Ct_UNC_ChonMau();
				frm1.Load(drCurrent);

				strReport_File = strReport_File + "_" + frm1.txtReportTag.Text;
				if (frm1.rdbUSD.Checked == true)
					strReport_File = strReport_File + "_Nt";
			}

            if (strMa_Ct == "DT")
			{
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;

				frmIn_Ct_DT frm1 = new frmIn_Ct_DT();
				frm1.Load(drCurrent);

				if (frm1.rdbCt_Dt.Checked == true && frm1.rdbTien_VND.Checked == true)
					strReportTag = "DT";
				else if (frm1.rdbCt_Dt.Checked == true && frm1.rdbTien_Nt.Checked == true)
					strReportTag = "DT_NT";
                else if (frm1.rdbCt_Po.Checked == true && frm1.rdbTien_VND.Checked == true)
					strReportTag = "POPT";
                else if (frm1.rdbCt_Po.Checked == true && frm1.rdbTien_Nt.Checked == true)
                    strReportTag = "POPT_NT";
              

				
				strReport_File = strReport_File + strReportTag ;

			}

            if (Common.Inlist(strMa_Ct, "BBPT,BBTH"))
            {
                frmIn_Ct_BB frm1 = new frmIn_Ct_BB();
                frm1.Load(drCurrent);
                if (frm1.rdbIn_Barcode.Checked == true)
                    strReport_File = "rptBarcode_PT";
                else
                {
                    DataRow drCtHd = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
                    if (drCtHd["Ma_Nvu"].ToString() == "XHTT")
                        strReportTag = "_XHTT";
                    
                    if(strReportTag!= "")
                        strReport_File = strReport_File + strReportTag;
                    else
                        strReport_File = strReport_File;
                }
                    
            }
            if (strMa_Ct == "NMHH")
            {
                frmIn_Ct_NM frm1 = new frmIn_Ct_NM();
                frm1.Load();
                if (frm1.isAccept)
                {
                    if (frm1.rdbPx_BBXN.Checked == true)
                        strReportTag = "_BBNM";
                    else //if (frm1.rdbPhieu_Nhap.Checked == true)
                        strReportTag = "_MH";
                    strReport_File = strReport_File + strReportTag;
                }
            }
           
            if (Common.Inlist(strMa_Ct, "PXCP"))
            {
                frmIn_Ct_PXCP frm1 = new frmIn_Ct_PXCP();
                frm1.Load();
                if (frm1.isAccept)
                {
                    if (frm1.rdbBBXN_CP_TMN.Checked == true)
                    {
                        strReportTag = "BBXN_CP_TMN";
                    }
                    else
                        strReportTag = "BBXN_TMN_KH";
                    strReport_File = strReport_File + strReportTag;
                }
            }
            if (Common.Inlist(strMa_Ct, "PXKV"))
            {
                frmIn_Ct_PxKv frm1 = new frmIn_Ct_PxKv();
                frm1.Load(drCurrent);
                if (frm1.isAccept)
                {
                    if (frm1.rdbPhieu_Xuat.Checked == true)
                        strReportTag = "PXKV";
                    else if (frm1.rdbPx_BBXN2.Checked == true)
                        strReportTag = "BBNM";
                    else if (frm1.rdbPx_BBXN3.Checked == true)
                        strReportTag = "BBNM3";
                    strReport_File = strReport_File + strReportTag;
                }

            }
            RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
			frm.Load(strReport_File);
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

            this.btUploadFile.Enabled = Common.CheckPermission((string)drDmCt["Object_ID"], enuPermission_Type.Allow_New);
            this.btRemoveFile.Enabled = Common.CheckPermission((string)drDmCt["Object_ID"], enuPermission_Type.Allow_Delete);

			if (Common.InlistLike(this.strMa_Ct_List, "DT,DTVPP,BBPT,BBTH,POCG"))
			{
				dgvViewCt.Location = new Point(dgvViewPh.Left, dgvViewPh.Bottom);
				dgvViewCt.Width = this.Width - 260;
				dgvViewCt.Height = this.Height - dgvViewPh.Height - pnlTTien.Height - 49;

				dgvResource.Location = new Point(dgvViewCt.Right, dgvViewPh.Bottom);
				dgvResource.Width = this.Width - dgvViewCt.Width - 12;
				dgvResource.Height = this.Height - dgvViewPh.Height - pnlTTien.Height - 49;

				btUploadFile.Location = new Point(dgvResource.Left, dgvResource.Bottom - btUploadFile.Height);
				btRemoveFile.Location = new Point(btUploadFile.Right, dgvResource.Bottom - btUploadFile.Height);
				btDownloadFile.Location = new Point(btRemoveFile.Right, dgvResource.Bottom - btUploadFile.Height);
			}
			else
			{
				dgvViewCt.Location = new Point(dgvViewPh.Left, dgvViewPh.Bottom);
				dgvViewCt.Width = this.Width - 12;
				dgvViewCt.Height = this.Height - dgvViewPh.Height - pnlTTien.Height - 49;

				btUploadFile.Visible = false;
				btRemoveFile.Visible = false;
				btDownloadFile.Visible = false;

				
			}
			//dgvViewPh.ResizeGridView();
			//dgvViewCt.ResizeGridView();


		}
		//private void FormLayout()
		//{
		//    dgvViewPh.Location = new Point(3, 3);
		//    dgvViewPh.Width = this.Width - 12;
		//    dgvViewPh.Height = (int)(0.5 * this.Height);

		//    dgvViewCt.Location = new Point(dgvViewPh.Left, dgvViewPh.Bottom);
		//    dgvViewCt.Width = this.Width - 12;
		//    dgvViewCt.Height = this.Height - dgvViewPh.Height - pnlTTien.Height - 49;

		//    //dgvViewPh.ResizeGridView();
		//    //dgvViewCt.ResizeGridView();
		//}

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

		private bool SaveResource(string strFile_Name, object objFile_Content, string strStt, string strTag)
		{
            //string str = string.Empty;
            //System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
			
            //hashtable.Add("STT", strStt);
            //hashtable.Add("STT0", 0);
            //hashtable.Add("FILE_NAME", strFile_Name);
            //hashtable.Add("TAG", strTag);
            //hashtable.Add("IMAGE", (objFile_Content == null) ? ((object)new byte[0]) : ((object)((byte[])objFile_Content)));

            //if (DataTool.SQLCheckExist("R04CtSo_Resource", new string[] { "File_Name", "Stt", "Tag" }, new object[] { strFile_Name, strStt, strTag }))
            //{
            //    str = "INSERT INTO R50THEPMN3_RESOURCE..R04CtSo_Resource (Stt, Stt0, File_Name, Image, Tag) VALUES (@Stt, @Stt0, @File_Name, @Image, @Tag)";
                
            //}
            
            //return SQLExec.Execute(str, hashtable, CommandType.Text);


           

           
            return true;
		}

		private void OpenFile()
		{
			if (bdsResource.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsResource.Current).Row;
            //lấy serer đang chạy
            string strServer =  "\\\\" +Tool.GetIPServer();
			string strFileName = (string)drCurrent["File_Name"] + '.' + drCurrent["Tag"];

            object objFile = strServer;
            string strPath = strServer ;
            strPath += Path.Combine(strPath,(string)drCurrent["File_Path"]);
            objFile += (string)drCurrent["File_Path"];
            try
            {
                if (objFile != null && objFile != DBNull.Value)// && ((Byte[])objFile).Length > 0)
                {
                    FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);
                    fileStream.Close();
                    System.Diagnostics.Process.Start(strPath);
                }
                else
                    Common.MsgOk("Không có file attach");
            }
            catch (Exception ex)
            {
                if (Common.InlistLike(ex.Message, "Could not find a part of the path") )
                {

                    NetworkCredential myCred = new NetworkCredential(
                                   "thepmiennam\bangvtk", "bang160619", Tool.GetIPServer());

                    CredentialCache myCache = new CredentialCache();
                    myCache.Add(new Uri(Tool.GetIPServer()), "Basic", myCred);
                    WebRequest wr = WebRequest.Create(Tool.GetIPServer());
                    wr.Credentials = myCache;
                }
                else if(Common.InlistLike(ex.Message,"The user name or password is incorrect."))
                {
                    Common.MsgOk("Bạn vui lòng đăng nhập vào server theo đường dẫn \\" + Tool.GetIPServer() + " để mở file");
                    System.Diagnostics.Process.Start("explorer.exe", @"\\" + Tool.GetIPServer() + "");

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

					//string strSQLExec =
					//    "UPDATE R80PH SET So_Ct = '" + strSo_Ct + "' WHERE Stt = '" + strStt + "'" +
					//    "UPDATE R01CtTien SET So_Ct = '" + strSo_Ct + "' WHERE Stt = '" + strStt + "'" +
					//    "UPDATE R02CtNM SET So_Ct = '" + strSo_Ct + "' WHERE Stt = '" + strStt + "'" +
					//    "UPDATE R04CtHD SET So_Ct = '" + strSo_Ct + "' WHERE Stt = '" + strStt + "'" +
					//    "UPDATE R05CtNX SET So_Ct = '" + strSo_Ct + "' WHERE Stt = '" + strStt + "'" +
					//    "UPDATE R80CtKT SET So_Ct = '" + strSo_Ct + "' WHERE Stt = '" + strStt + "'";

					//"UPDATE R80HanTt SET So_Ct_HD = '" + strSo_Ct + "' WHERE Stt = '" + strStt + "' AND So_Ct_HD = '" + strSo_Ct + "'" +
					//"UPDATE R80CtHanTt SET So_Ct_TT = '" + strSo_Ct + "' WHERE Stt = '" + strStt + "' AND So_Ct_TT = '" + strSo_Ct + "'";

					if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
					{
						drCurrent["So_Ct"] = strSo_Ct;
					}

					iSo_Ct++;
				}
			}
		}

        private void DongDh()
        {
            if (bdsViewPh.Count <= 0)
                return;

            drCurrent = ((DataRowView)bdsViewPh.Current).Row;

            string strStt = string.Empty;
            string strMa_Ct = (string)drCurrent["Ma_Ct"];
            string strSo_Ct = string.Empty;

            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);

            frmDongDhAll frm = new frmDongDhAll();
            frm.Load(strMa_Ct);

            if (frm.Is_Accept)
            {
                frm.bdsDongDh.Filter = "Duyet_Huy = 1";
                for (int i = 0; i < frm.bdsDongDh.Count; i++)
                {
                    frm.bdsDongDh.Position = i;

                    drCurrent = ((DataRowView)frm.bdsDongDh.Current).Row;
                    strStt = (string)drCurrent["Stt"];
                    string strSQLExec = string.Empty;

                    Hashtable htPara = new Hashtable();
                    htPara["DUYET_HUY_LOG"] = Common.GetCurrent_Log();
                    htPara["STT"] = strStt;
                    htPara["GHI_CHU_HUY"] = (string)drCurrent["Ghi_Chu_Huy"];

                    strSQLExec += " UPDATE " + drDmCt["Table_Ph"].ToString() + " SET Duyet_Huy = 1, Duyet_Huy_Log = @Duyet_Huy_Log, Ghi_Chu_Huy = @Ghi_Chu_Huy  WHERE Stt = @Stt";
                    SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
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
            if(!bTb)
			    frmEdit.Load(enuNew_Edit, drCurrent, dsVoucher);
            else
                frmEdit.Load_Tb(enuNew_Edit, drCurrent, dsVoucher);

            //nếu là HD thì bắt buộc nhập liệu xong sẽ view
            if (Common.Inlist(strMa_Ct_List, "HD,HDHH") && Parameters.GetParaValue("HDDT").ToString() == "1" && frmEdit.isAccept == true)
            {
                //tạm bỏ đi
                //DataTable dtFilter = new DataTable();
                //DataRow drFilter = dtFilter.NewRow();
                //dtFilter.Columns.Add(new DataColumn("Ma_Ct_List", typeof(string)));
                //dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
                //dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));

                //int iInterval = Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER"));
                //object objNgay_CtMax = SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM " + (string)drDmCt["Table_Ph"] + " WHERE Ma_Ct LIKE '" + this.strMa_Ct_List.Split(',')[0] + "' AND Ma_DvCs = '" + Element.sysMa_DvCs + "'");
                //DateTime dteNgay_Ct2 = objNgay_CtMax != DBNull.Value ? (DateTime)objNgay_CtMax : DateTime.Now;
                //DateTime dteNgay_Ct1 = dteNgay_Ct2.Subtract(new TimeSpan(iInterval, 0, 0, 0));
                ////Set Default 
                //drFilter["Ma_Ct_List"] = strMa_Ct_List;
                //drFilter["Ngay_Ct1"] = dteNgay_Ct1;//Element.sysNgay_Ct1;
                //drFilter["Ngay_Ct2"] = dteNgay_Ct2;

                //this.FillData(drFilter);
                //Voucher.PrintHDDT(frmEdit.drEdit["Stt"].ToString(), frmEdit.drEdit["Ma_Ct"].ToString(), "VND", "rptCT_HDDT");
            }
                
            
            //Nếu là BBPT thì bắt buộc in tem sau khi lưu
            if (Common.Inlist(strMa_Ct_List, "BBPT,PNPT") && enuNew_Edit == enuEdit.New && frmEdit.isAccept == true)
                Voucher.ProcessBarcodePT(frmEdit.drEdit["Stt"].ToString(), "", false);


            if (bdsViewPh.Find("Stt", frmEdit.drEdit["Stt"].ToString()) >= 0)
				bdsViewPh.Position = bdsViewPh.Find("Stt", frmEdit.drEdit["Stt"].ToString());

            //cập nhật tên đối tượng
            if(bdsViewPh.Count > 0)
            { 
                drCurrent = ((DataRowView)bdsViewPh.Current).Row;
                drCurrent["Ten_Dt"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", frmEdit.drEditPh["Ma_Dt"].ToString());
            }

        }

        public override void Delete()
		{
						
			if (bdsViewPh.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			string strMa_Ct = ((string)drCurrent["Ma_Ct"]).Trim();
			string strStt = ((string)drCurrent["Stt"]).Trim();
            string strMa_Ct_Org = string.Empty;
            string strStt_Org = string.Empty;

			DataRow dr = DataTool.SQLGetDataRowByID("R80PH", "STT", strStt);
            DataTable dtPO = SQLExec.ExecuteReturnDt("SELECT * FROM R00DMCT WHERE Table_Ct = 'R04CTPO' OR Table_Ct = 'R04CTPONL'");

            if (dtPO.Select("Ma_Ct = '" + strMa_Ct + "'").Length == 0)
            {
                if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
                {
                    Common.MsgOk("Dữ liệu đã bị khóa, bạn không được xóa phiếu.");
                    return;
                }
            }
            else
            {
                if ((bool)dr["Duyet_TP"] || (bool)dr["Duyet_KHVT"])
                {
                    Common.MsgCancel("Chứng từ đã được duyệt, không thể xóa !");
                    return;
                }
            }
			if (Common.Inlist(strMa_Ct, "LXH,SO,SOCP"))
			{
				if ((Convert.ToDouble(dr["Print_Count"]) != 0 || (bool)dr["Duyet_PKD"]) || (bool)dr["Duyet"] || (bool)dr["Duyet_Huy"])
				{
					Common.MsgCancel("Chứng từ đã được in,hoặc đã được duyệt, không thể xóa !");
					return;
				}
			}

            if (Common.Inlist(strMa_Ct, "PXDC,PXBR"))
            {
                if ((Convert.ToDouble(dr["Print_Count"]) != 0))
                {
                    Common.MsgCancel("Chứng từ đã được in, không thể xóa !");
                    return;
                }
                //Xóa PNGK khi xóa PXBR
                string strMa_Nvu = SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Nvu) FROM R05CTNX WHERE Stt = '"+strStt+"'").ToString();
                if (strMa_Ct == "PXBR" && strMa_Nvu == "PX14")
                {
                    strMa_Ct_Org = "PNGK";
                    strStt_Org = SQLExec.ExecuteReturnValue("SELECT MAX(Stt) FROM R05CTNX_CP WHERE STT_Org = '" + strStt + "'").ToString();
                  
                }
            }
            if (Common.Inlist(strMa_Ct, "HD,HDXK"))
            {
                if ((bool)(dr["HDDTDaTao"]))
                {
                    Common.MsgCancel("Chứng từ đã được tạo HD điện tử, không thể xóa !");
                    return;
                }
            }
            // Kiem tra chung tu da duoc thanh toan khong cho phep xoa
            if ((bool)SQLExec.ExecuteReturnValue("SELECT dbo.fn_Check_Del('" + strStt + "')"))
            {
                Common.MsgCancel("Chứng từ đã được thanh toán, không thể xóa !");
                return;
            }
         
            if ((bool)SQLExec.ExecuteReturnValue("SELECT dbo.fn_Check_Del_Ct('" + strStt + "')"))
            {
                Common.MsgCancel("Chứng từ đã được kế thừa lập chứng từ khác, không thể xóa !");
                return;
            }
			if (Common.InlistLike(strMa_Ct, "PYCPT,PYCCK,PYCTH,DNTT,DTCP,DTXE") && Convert.ToBoolean(drCurrent["Duyet_TP"]) == true)
			{
				Common.MsgCancel("Chứng từ đã được duyệt, không được xóa !");
				return;
			}
			if (Common.Inlist(strMa_Ct, "DT") && Convert.ToBoolean(drCurrent["Duyet_KHVT"]) == true)
			{
				Common.MsgCancel("Chứng từ đã được duyệt, không được xóa !");
				return;
			}
            if (Common.Inlist(strMa_Ct, "PNSB,PXSB"))
            {
               
               
                if (strMa_Ct == "PNSB")
                    strMa_Ct_Org = "PN";
                else
                    strMa_Ct_Org = "PX";

                strStt_Org = SQLExec.ExecuteReturnValue("SELECT MAX(Stt_Inherit_Nhap_Tp) FROM R05CTNXPHOI WHERE STT = '" + strStt + "'").ToString();
               
            }
            if (Common.Inlist(strMa_Ct, "BBPT"))
            {
                //string strSQL = "SELECT * FROM R81DMBARCODEPT WHERE Stt = '" + strStt + "'";
                //DataTable dtBarcode_PT = SQLExec.ExecuteReturnDt(strSQL);
                //foreach (DataRow dr in dtBarcode_PT.Rows)
                //{ 
                //    int i_Ps = Convert.ToInt16(SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM R05CTX_BARCODEPT WHERE Barcode = '"+dr["Barcode"]+"'"));
                //    if(i_Ps == 0)
                //        SQLExec.Execute("DELETE FROM R81DMBARCODEPT WHERE Stt = '" + strStt + "' AND Barcode = '"+ dr["Barcode"] +"'");
                //    else
                        
                //}
                
            }
            ////Kiem tra Permission
            //if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            //{
            //    Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
            //    return;
            //}
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

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE"), "N"))
				return;

            //Cập nhật lại xuất HD trước khi xóa phiếu
            
            Hashtable htDel = new Hashtable();
            htDel.Add("STT", strStt);
            htDel.Add("MA_CT", strMa_Ct);
            htDel.Add("DUYET_HUY", true);
            SQLExec.Execute("sp_UpdateDaXuatHD", htDel, CommandType.StoredProcedure);
            
            
            if (Voucher.SQLDeleteCt(strStt, strMa_Ct))
			{
                if (strStt_Org != string.Empty)
                {
                    Voucher.SQLDeleteCt(strStt_Org, strMa_Ct_Org);

                    if (Common.Inlist(strMa_Ct, "PNSB,PXSB"))
                        SQLExec.Execute("UPDATE R05CTNXLRPHOI SET Stt_Inherit_Nhap_Tp = '' WHERE Stt_Inherit_Nhap_Tp = '" + strStt_Org + "'");
                   
                }
                // 1.Lấy dữ liệu từ file attach
                DataTable dtResource_Del = SQLExec.ExecuteReturnDt("SELECT *, replace(File_Path,'\'+File_Name+'.' + Tag,'') AS Folder FROM R04CTSO_RESOURCE WHERE Stt = '" + strStt + "'");
                string strPath = string.Empty;
                // 2. xóa data bảng R04CTSO_RESOURCE
                string strDelete3 = "DELETE FROM R04CTSO_RESOURCE WHERE Stt = '" + strStt + "'";
                SQLExec.Execute(strDelete3);
               
                if (dtResource_Del.Rows.Count>0)
                {
                    strPath = "\\\\" + Tool.GetIPServer() + dtResource_Del.Rows[0]["Folder"].ToString();
                    strPath = strPath.Substring(0, strPath.Length - 1);
                    // 3.Xóa file lưu tại server đi
                    foreach (DataRow drDel in dtResource_Del.Rows)
                    {
                        drDel["File_Path"] = "\\\\" + Tool.GetIPServer() + drDel["File_Path"];
                        File.Delete(drDel["File_Path"].ToString());
                    }
                    // 4. xóa folde tránh để rác
                    System.IO.Directory.Delete(strPath);
                    
                }
                bdsViewPh.RemoveAt(bdsViewPh.Position);
				dtViewPh.AcceptChanges();
			}
		}

		public override void EditHanTt()
		{
			if (bdsViewPh.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			Voucher.HanTt1(drCurrent);
		}

		void EditResource(enuEdit enuNew_Edit)
		{
			if (bdsViewPh.Position < 0)
				return;

			if (bdsResource.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			if (bdsResource.Position >= 0)
				drResource = ((DataRowView)bdsResource.Current).Row;
            
           
            if (!Element.sysIs_Admin)
            {
                string strCreate_User = (string)drCurrent["Create_Log"];

                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                    
                    if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                    {
                        Common.MsgOk("Bạn không có quyền upload file vào phiếu của người không được phân quyền");
                        return;
                    }
                    
                }
            }
            
			//Copy dong hien tai
			if (bdsResource.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsResource.Current).Row, ref drResource);
			else
				drResource = dtResource.NewRow();

			drResource["Stt"] = drCurrent["Stt"];

			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.RestoreDirectory = true;

			if (fileDialog.ShowDialog() != DialogResult.OK)
				return;

			this.objFileContent = (object)System.IO.File.ReadAllBytes(fileDialog.FileName);
			drResource["Tag"] = Path.GetExtension(fileDialog.FileName).Substring(1).ToUpper();
			drResource["File_Name"] = Path.GetFileNameWithoutExtension(fileDialog.FileName);
           

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
				drResource["Create_Log"] = Common.GetCurrent_Log();
			else
				drResource["LastModify_Log"] = Common.GetCurrent_Log();

            // Kiểm tra trùng tên file va Stt
            //if(Common.chc)
			//Luu vao CSDL
            if (!DataTool.SQLCheckExist("R04CtSo_Resource", new string[] { "File_Name", "Stt", "Tag" }, new object[] { drResource["File_Name"].ToString(), (string)drResource["Stt"], (string)drResource["Tag"] }))
            {


                string strPath = string.Empty; 
                string strFileName = string.Empty;
                drCurrent = ((DataRowView)bdsViewPh.Current).Row;
                //Xác định đường dẫn tại server
                strPath = Parameters.GetParaValue("PATH_CTPO").ToString();
                //ma_ct
                strPath = Path.Combine(strPath, drCurrent["Ma_Ct"].ToString());
                //năm
                strPath = Path.Combine(strPath, Convert.ToDateTime(drCurrent["Ngay_Ct"]).Year.ToString());
                //số ct
                strPath = Path.Combine(strPath, drCurrent["So_Ct"].ToString().Substring(0, 11));

                //gán server
                strPath = "\\\\" + Tool.GetIPServer() + strPath;

                try
                {
                    //Kiểm tra Path có tồn tại hay chưa, tạo thư mục chứa các file
                    if (!Directory.Exists(strPath))
                        System.IO.Directory.CreateDirectory(strPath);

                    File.Copy(fileDialog.FileName, Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileDialog.FileName) + Path.GetExtension(fileDialog.FileName)));
                }
                catch (Exception ex)
                {
                    if (Common.InlistLike(ex.Message, "Could not find a part of the path"))
                    {

                        NetworkCredential myCred = new NetworkCredential(
                                       "thepmiennam\bangvtk", "bang160619", "192.168.1.18");

                        CredentialCache myCache = new CredentialCache();
                        myCache.Add(new Uri("192.168.1.18"), "Basic", myCred);
                        WebRequest wr = WebRequest.Create("192.168.1.18");
                        wr.Credentials = myCache;
                    }
                    else if (Common.InlistLike(ex.Message, "The user name or password is incorrect."))
                    {
                        Common.MsgOk("Bạn vui lòng đăng nhập vào server theo đường dẫn \\192.168.1.18 để đính kèm file, sau đó đính kèm lại file!!!");
                        System.Diagnostics.Process.Start("explorer.exe", @"\\192.168.1.18");

                    }
                }
                //SaveResource(drResource["File_Name"].ToString(), objFileContent, (string)drResource["Stt"], (string)drResource["Tag"]);
                strPath += "\\";
                drResource["File_Path"] = Path.Combine(strPath ,Path.GetFileNameWithoutExtension(fileDialog.FileName) + Path.GetExtension(fileDialog.FileName));
                drResource["File_Path"] = drResource["File_Path"].ToString().Replace("\\\\" + Tool.GetIPServer(), "");
                DataTool.SQLUpdate(enuNew_Edit, "R04CtSo_Resource", ref drResource);
            }
            else
            {
                Common.MsgOk("Tên file " + (string)drResource["File_Name"] + " đã tồn tại với số chứng từ " + (string)drCurrent["So_Ct"] + ". Yêu cầu kiểm tra lại tên của báo giá");
                return;
            }

			if (enuNew_Edit == enuEdit.New)
			{
				if (bdsResource.Position >= 0)
					dtResource.ImportRow(drResource);
				else
					dtResource.Rows.Add(drResource);

				bdsResource.Position = bdsResource.Find("Ident00", drResource["Ident00"]);
			}
			else
				Common.CopyDataRow(drResource, ((DataRowView)bdsResource.Current).Row);

			dtResource.AcceptChanges();
		}

		private void DeleteResource()
		{
			if (bdsResource.Position < 0)
				return;

            drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			drResource = ((DataRowView)bdsResource.Current).Row;

            if (!Element.sysIs_Admin)
            {
                string strCreate_User = (string)drCurrent["Create_Log"];

                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

                    if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
                    {
                        Common.MsgOk("Bạn không có quyền xóa file vào chứng từ của người không được phân quyền");
                        return;
                    }
                    
                }
            }
            
			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
            
            if (DataTool.SQLDelete("R04CtSo_Resource", drResource))
			{
                //xóa file trên server
                string strServer = "\\\\" + Tool.GetIPServer();
                string strPath = strServer + drResource["File_Path"].ToString();
                File.Delete(strPath);
                //string strSQL = "DELETE FROM R50THEPMN3_RESOURCE..R04CtSo_Resource WHERE Stt = '" + drResource["Stt"] + "' AND File_Name = '" + drResource["File_Name"] + "'";
                
                //SQLExec.Execute(strSQL, CommandType.Text);
				bdsResource.RemoveAt(bdsResource.Position);
				dtResource.AcceptChanges();
			}
		}

		#endregion

		#region Event
		void btDownloadFile_Click(object sender, EventArgs e)
		{
			OpenFile();
		}

		void btRemoveFile_Click(object sender, EventArgs e)
		{
			DeleteResource();
		}

		void btUploadFile_Click(object sender, EventArgs e)
		{
			EditResource(enuEdit.New);
		}

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

				case Keys.F10:
					{
						if (strMa_Ct_List.StartsWith("SO") || strMa_Ct_List.StartsWith("LXH"))
							Active();
					}
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

                case Keys.D:
                    if (dgvViewPh.Columns.Contains("Duyet_Huy"))
                        if (e.Modifiers == Keys.Control)
						{
                            frmDong_Dh frm = new frmDong_Dh();
                            frm.Load(strMa_Ct_List);
						}
                    break;
			}
		}

		private void Active()
		{
			//FillData
			object objNgay_CtMax = SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM " + (string)drDmCt["Table_Ph"] + " WHERE Ma_Ct LIKE '" + this.strMa_Ct_List.Split(',')[0] + "' AND Ma_DvCs = '" + Element.sysMa_DvCs + "'");
			int iInterval = Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER"));

			DateTime dteNgay_Ct2 = objNgay_CtMax != DBNull.Value ? (DateTime)objNgay_CtMax : DateTime.Now;
			DateTime dteNgay_Ct1 = dteNgay_Ct2.Subtract(new TimeSpan(iInterval, 0, 0, 0));

			DataTable dtFilter = new DataTable();
			dtFilter.Columns.Add(new DataColumn("Ma_Ct_List", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("User_Id", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Table_PH", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Table_Ct", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();

			//Set Default 
			drFilter["Ma_Ct_List"] = strMa_Ct_List;
			drFilter["Ngay_Ct1"] = dteNgay_Ct1;//Element.sysNgay_Ct1;
			drFilter["Ngay_Ct2"] = DateTime.Now;

			this.FillData(drFilter);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F3 && e.Shift)
			{
				this.DanhSoCt();
				return;
			}
            if (e.KeyCode == Keys.F4 && e.Shift)
            {
                this.DongDh();
                return;
            }
			else

				base.OnKeyDown(e);
		}

		void bdsViewPh_PositionChanged(object sender, EventArgs e)
		{
			if (bdsViewPh.Position < 0)
				return;

			//lblRecordNo.Text = (bdsViewPh.Position + 1).ToString() + "/" + bdsViewPh.Count.ToString();

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			string strStt = (string)drCurrent["Stt"];

			bdsViewCt.Filter = "(Stt = '" + strStt + "')";

			bdsResource.Filter = "(Stt = '" + strStt + "')";
		}

		void btNew_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			Delete();
		}

		void btFilter_Click(object sender, EventArgs e)
		{
            timer_Newdata.Enabled = false;
			Filter();
		}

		void btPreview_Click(object sender, EventArgs e)
		{
            //this.Print(true);
            drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            string strMa_Ct = ((string)drCurrent["Ma_Ct"]).Trim();
            string strStt = ((string)drCurrent["Stt"]).Trim();           
            this.Print(true);
            
		}

		void btPrint_Click(object sender, EventArgs e)
		{
            drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            string strMa_Ct = ((string)drCurrent["Ma_Ct"]).Trim();
            string strStt = ((string)drCurrent["Stt"]).Trim();
            bool bDuyetPKD = (bool)SQLExec.ExecuteReturnValue("SELECT Duyet_PKD FROM R80PH WHERE Stt = '" + strStt + "'");
            bool bDuyet = (bool)SQLExec.ExecuteReturnValue("SELECT Duyet FROM R80PH WHERE Stt = '" + strStt + "'");
            //bool bDuyet_Huy = (bool)SQLExec.ExecuteReturnValue("SELECT Duyet_Huy FROM R80PH WHERE Stt = '" + strStt + "'");
            if (Common.Inlist(strMa_Ct, "SO,SOCP") && !bDuyetPKD)
                Common.MsgOk("Chứng từ chưa được duyệt bởi PKD không in đc. Vui lòng kiểm tra lại");
            else if (Common.Inlist(strMa_Ct, "LXH"))
            {
                if(!bDuyet)
                    Common.MsgOk("Chứng từ chưa duyệt, không in đc. Vui lòng kiểm tra lại");
                else
                {
                    if (drCurrent["So_Xa_Lan_Tau"].ToString() == "" && drCurrent["Ma_Xe"].ToString() == "")
                    {
                        if (!Common.InlistLike(drCurrent["Ma_Kho"].ToString(),"GK_05,GK_55"))
                        {
                            //kiểm tra tên lái xe và số xe 
                            if (Convert.ToDouble(drCurrent["Ident_RVC"]) != 0)
                            {
                                this.Print(false);
                            }
                            else
                            {
                                Common.MsgOk("Xe Chưa vào lấy hàng vui lòng Refresh lại dữ kiệu để kiểm tra");
                                return;
                            }

                        }
                        else
                            this.Print(false);
                    }
                    else
                    {
                        this.Print(false);
                    }
                    
                }
                
            }
            else
            {
                this.Print(false);

            }
            
            
		}

		void btEditTauHang_Click(object sender, EventArgs e)
		{
			if (bdsViewPh.Position < 0)
				return;

			frmBangKTTauHang frm = new frmBangKTTauHang();

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			frm.Load((string)drCurrent["Stt"]);

		}
		
		void btEditTauHangGD_Click(object sender, EventArgs e)
		{
			if (bdsViewPh.Position < 0)
				return;

			frmBangKTTauHangGD frm = new frmBangKTTauHangGD();

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			frm.Load((string)drCurrent["Stt"]);
		}

        void btDongDh_Click(object sender, EventArgs e)
        {
            DongDh();
        }

		void btExport_Click(object sender, EventArgs e)
		{

			DataTable dtHeader;
			DataTable dtDetail;
			string strStt = (string)drCurrent["Stt"];
			string strMa_Ct = (string)drCurrent["Ma_Ct"];
			string strLoai_Ct = string.Empty;
			bool bIs_Vnd = true;

			DataRow drPH = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt);
            if (Common.Inlist(strMa_Ct, "DT,DNTT,DTNA"))
            {
                if (Common.Inlist(strMa_Ct, "DT"))
                {
                    frmIn_Ct_DT frm = new frmIn_Ct_DT();
                    frm.Load(drPH);

                    if (frm.rdbCt_Dt.Checked == true)
                        strLoai_Ct = "DUTRU";
                    else if (frm.rdbCt_Po.Checked == true)
                        strLoai_Ct = "DONHANG";

                }
                else if (Common.InlistLike(strMa_Ct, "DNTT"))
                    strLoai_Ct = "DNTT";
                else if (Common.InlistLike(strMa_Ct, "DTNA"))
                    strLoai_Ct = "DTNA";

                DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);
                string strTable_Ph = (string)drDmCt["Table_Ph"];
                string strTable_Ct = (string)drDmCt["Table_Ct"];

                DataRow drPHCt = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
                string strMa_Tte = (string)drPHCt["Ma_Tte"];

                DataRow drCT = DataTool.SQLGetDataRowByID(strTable_Ct, "Stt", strStt);
                if ((string)drCT["Ma_Tte"] == Element.sysMa_Tte)
                    bIs_Vnd = true;
                else
                    bIs_Vnd = false;

                Hashtable ht = new Hashtable();
                ht.Add("STT", strStt);
                ht.Add("MA_CT", strMa_Ct);
                ht.Add("IS_VND", bIs_Vnd);
                ht.Add("IS_EXPORT", strLoai_Ct);
                ht.Add("LANGUAGE_TYPE", (char)Element.sysLanguage);

                DataSet dsPrintVoucher = SQLExec.ExecuteReturnDs("sp_ExportVoucher", ht, CommandType.StoredProcedure);
                dtHeader = dsPrintVoucher.Tables[0];
                dtDetail = dsPrintVoucher.Tables[1];

                dtHeader.Columns.Add("REPORT_FILE", typeof(string));
                dtHeader.Columns.Add("TITLE", typeof(string));
                dtHeader.Columns.Add("IS_VND", typeof(bool));
                dtHeader.Columns.Add("DOC_TIEN", typeof(string));
                dtHeader.Columns.Add("DOC_TIENE", typeof(string));

                DataRow drHeader = dtHeader.Rows[0];

                if (strLoai_Ct == "DONHANG")
                    drHeader["TITLE"] = "ĐƠN ĐẶT HÀNG";
                else
                    drHeader["TITLE"] = (string)drDmCt["Title"];

                if (Element.sysLanguage == enuLanguageType.Vietnamese)
                {
                    dtHeader.Rows[0]["Doc_Tien"] = !bIs_Vnd ? Common.ReadMoney(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte) : Common.ReadMoney(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());
                }
                else if (Element.sysLanguage == enuLanguageType.English)
                    dtHeader.Rows[0]["Doc_Tien"] = !bIs_Vnd ? Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien_Nt"]), strMa_Tte).Replace("Fourty","Forty") : Common.ReadMoneyE(Convert.ToDouble(drHeader["TTien"]), Element.sysMa_Tte.ToString());
                else
                    dtHeader.Rows[0]["Doc_Tien"] = Common.ReadNumberC(Convert.ToDouble(drHeader["TTien_Nt"]));

                ExportExcel.ExportExcel_CtYc(drHeader, dtDetail, strLoai_Ct);
            }
            else if (strMa_Ct == "BN")
            {
                this.ExportControl = dgvExportExcel;
                string strPath = "D:\\UNC_EXPORT";
                //string strPath = @"\\192.168.1.18\BaoGia\";
               
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);

                string strFileName = dtExportExcel.Rows[0]["File_Name"].ToString();
                strFileName = Path.Combine(strPath, strFileName);
                //export Excel
                RosyCommonTMN.ExportExcel.ExportExcelTMN(this.ExportControl, "Bảng kê chứng từ ngân hàng", "", strFileName + ".xls", "U");
            }
		}
		void btImport_Click(object sender, EventArgs e)
		{
            //if (strMa_Ct_List == "PNSB")
            //{
            //    frmImportExcelPhoi frm = new frmImportExcelPhoi();
            //    frm.Load();	
            //}
            //else
            //{
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
            //}
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
			
			if (dgvViewPh.Columns.Contains("Is_Inherited") && Common.CheckPermission("PHAN_HOI_KHVT", enuPermission_Type.Allow_Access))
			{
				if (dgvViewPh.Rows[e.RowIndex].Cells["Is_Inherited"].Value != null)
				{
					if ((bool)dgvViewPh.Rows[e.RowIndex].Cells["Is_Inherited"].Value == true)
					{
						if (e.ColumnIndex == 17)
							if (dgvViewPh[e.ColumnIndex, e.RowIndex].ReadOnly)
								e.CellStyle.BackColor = Color.Red;
						
					}
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
		}

		void dgvViewPh_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			string strColumnName = dgvViewPh.Columns[e.ColumnIndex].Name;
			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			if (strColumnName == "SENDMAIL")
			{
				frmSendMail frm = new frmSendMail();
				frm.Load(drCurrent);
			}
		}
        void dgvViewPh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string strColumnName = dgvViewPh.Columns[e.ColumnIndex].Name;
            drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            string strStt = (string)drCurrent["Stt"];
            DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", (string)drCurrent["Ma_Ct"]);

            if ((strColumnName == "SO_XE" && strMa_Ct_List == "LXH" && Common.CheckPermission("IS_PRINT_LXH", enuPermission_Type.Allow_Edit) 
                        && (drCurrent["So_Xa_Lan_Tau"].ToString() != "" || drCurrent["Ht_Gn"].ToString() =="DD"))
                        ||(strColumnName == "SO_XE" && strMa_Ct_List == "LXH" 
                        && (drCurrent["So_Xa_Lan_Tau"].ToString() != "" || drCurrent["Ht_Gn"].ToString() == "GK" && drCurrent["Ma_Kho"].ToString() == "GK_055POM1"))
                        || (strColumnName == "SO_XE" && strMa_Ct_List == "SOCP" && Convert.ToBoolean(drCurrent["Duyet_Huy"]) == false && drCurrent["Ma_Kho"].ToString() == "055POM1" 
                        && Common.CheckPermission("IS_PRINT_LXH", enuPermission_Type.Allow_Edit)))
            {
                frmPhan_Hoi_KHVT frm = new frmPhan_Hoi_KHVT();
                frm.Load(drCurrent,"PKD");
                if (frm.Is_Accept)
                {
                    drCurrent["So_Xe"] = frm.dtEditCt.Rows[0]["So_Xe"];
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

            if (drDmCt["Table_Ph"].ToString() != "R80PH")
                return;

            DataRow drPh = DataTool.SQLGetDataRowByID("R80PH", "Stt", (string)drCurrent["Stt"]);
            string strDuyet_PxCd_Log = drPh["DUYET_PXCD_LOG"].ToString();
            string strDuyet_Tp_Log = drPh["DUYET_TP_LOG"].ToString();
            string strDuyet_KtCdAt_Log = drPh["DUYET_KTCDAT_LOG"].ToString();
            string strDuyet_KhVt_Log = drPh["DUYET_KHVT_LOG"].ToString();
            string strDuyet_TcHc_Log = drPh["DUYET_TCHC_LOG"].ToString();
            string strDuyet_KtTc_Log = drPh["DUYET_KTTC_LOG"].ToString();
            string strDuyet_GD_Log = drPh["DUYET_GD_LOG"].ToString();

            

			if (strColumnName == "DUYET_TP")
			{
				bool bDuyet = false;

                if (Common.Inlist(strMa_Ct_List, "PYCPT,PYCCK,PYCTH"))
                {
                    bDuyet = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
                }
                else
                {
                    bDuyet = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);

                    if(!bDuyet)
                        bDuyet = Common.CheckPermission("IS_PTP", enuPermission_Type.Allow_Access);
                }
				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;
				string strUser_Group = string.Empty;
				

				if (strCreate_User != string.Empty )
				{
					strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
					strUser_Group = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetList('" + Element.sysUser_Id + "')") + "";
				}
				if (Common.Inlist(strMa_Ct_List, "DNX,DNXNL,DTNA,PYCPT,PYCCK,PYCTH,BBPT,BBTH,PONL,POXL,DNTT,DTCP,DTXE,PONL,POCG") && bDuyet && 
                    (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
				{
                    
                    if (!Common.Inlist((string)drCurrent["Ma_Dt"], strUser_Group) && !Common.Inlist(strMa_Ct_List, "DNTT,DTCP,DTXE,DTNA"))
                    {
                        dgvViewPh.Columns["DUYET_TP"].ReadOnly = true;
                    }
                 
                    else if (Common.Inlist(strMa_Ct_List, "DNTT"))
                    {
                        if (!(bool)drCurrent["Is_Vt_Nhan"])
                        {
                            string strMa_Bp_Sd = (string)SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Bp_Sd) FROM R04CTPO WHERE STT = '" + strStt + "'");
                            strUser_Group = (string)SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Bp) FROM R81DMDT WHERE Ma_Dt ='" + strUser_Group + "'");
                            if (Element.sysIs_Admin || (strUser_Group == strMa_Bp_Sd))
                            {
                                dgvViewPh.Columns["DUYET_TP"].ReadOnly = false;

                                string strSQLExec = string.Empty;
                                Hashtable htPara = new Hashtable();
                                htPara.Add("DUYET_TP", !(bool)drCurrent["DUYET_TP"]);
                                htPara.Add("STT", drCurrent["STT"]);
                                htPara.Add("DUYET_TP_LOG", Common.GetCurrent_Log());

                                strSQLExec = "UPDATE R80PH SET DUYET_TP = @DUYET_TP, DUYET_TP_LOG = @DUYET_TP_LOG  WHERE Stt = @STT";
                                SQLExec.Execute(strSQLExec, htPara, CommandType.Text);

                                drCurrent["DUYET_TP"] = !(bool)drCurrent["DUYET_TP"];
                            }
                        }
                        else
                            Common.MsgOk("Phiếu đã được PKTTC nhận không được gỡ duyệt");
                    }
					else
					{
                        //Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_TP FROM R80PH WHERE Stt = '" + strStt + "'"));
                        //frmDuyetYeuCau frm = new frmDuyetYeuCau();
                        //frm.Load(drCurrent, Is_Duyet, strColumnName);

                        Voucher.DuyetCt("R80PH", strStt, drCurrent, "", "DUYET_TP", "DUYET_TP", dgvViewPh);
                        if (strMa_Ct_List == "PYCCK" && (string)drCurrent["Ma_Dt"] == "41PXCDN")
                        {
                            Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_TP FROM R80PH WHERE Stt = '" + strStt + "'"));
                            if(Is_Duyet)
                            {
                                string strSQLExec = string.Empty;
                                Hashtable htPara = new Hashtable();
                              
                                htPara.Add("DUYET_PXCD", Is_Duyet);
                                htPara.Add("STT", drCurrent["STT"]);
                                htPara.Add("DUYET_PXCD_LOG", Common.GetCurrent_Log());

                                strSQLExec = "UPDATE R80PH SET DUYET_PXCD = @DUYET_PXCD, DUYET_PXCD_LOG = @DUYET_PXCD_LOG  WHERE STT = @STT";
                                SQLExec.Execute(strSQLExec, htPara, CommandType.Text);

                                drCurrent["DUYET_PXCD"] = Is_Duyet;
                            }
                        }
                        //if (frm.Is_Accept)
                        //{
                        //    if (strMa_Ct_List == "PYCCK" && (string)drCurrent["Ma_Dt"] == "PXCD") // tự động duyet nen cung chung PXCD
                        //    {
                        //        dgvViewPh.Columns["DUYET_TP"].ReadOnly = false;
                        //        drCurrent["DUYET_TP"] = frm.chkDuyet.Checked;
                        //        drCurrent["DUYET_PXCD"] = frm.chkDuyet.Checked;

                        //        string strSQLExec = string.Empty;
                        //        Hashtable htPara = new Hashtable();
                        //        htPara.Add("DUYET_TP", (bool)drCurrent["DUYET_TP"]);
                        //        htPara.Add("DUYET_PXCD", (bool)drCurrent["DUYET_TP"]);
                        //        htPara.Add("STT", drCurrent["STT"]);
                        //        htPara.Add("DUYET_TP_LOG", Common.GetCurrent_Log());
                        //        htPara.Add("DUYET_PXCD_LOG", Common.GetCurrent_Log());

                        //        strSQLExec = "UPDATE R80PH SET DUYET_TP = @DUYET_TP, DUYET_PXCD = @DUYET_PXCD, DUYET_TP_LOG = @DUYET_TP_LOG, DUYET_PXCD_LOG = @DUYET_PXCD_LOG  WHERE STT = @STT";
                        //        SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                        //    }
                        //    else
                        //    {
                        //        Voucher.DuyetCtBTTB("R80PH", strStt, drCurrent, "", "DUYET_TP", "DUYET_TP", dgvViewPh);
							
                        //    }
                        //}
					}
				}
				else
				{
					dgvViewPh.Columns["DUYET_TP"].ReadOnly = false;
				}
			}

			if (strColumnName == "DUYET_PXCD")
			{
				bool bDuyet = false;

				if (!Element.sysIs_Admin)
					bDuyet = Common.CheckPermission("IS_TP_PXCD", enuPermission_Type.Allow_Access);

				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;

				if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
				}
				if (Common.Inlist(strMa_Ct_List, "PYCCK") && bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
				{
					if (Convert.ToBoolean(drCurrent["DUYET_PXCD"]) && strDuyet_PxCd_Log.Substring(14) != Element.sysUser_Id)
					{
						dgvViewPh.Columns["DUYET_PXCD"].ReadOnly = true;
					}
					else
					{
                        Voucher.DuyetCt("R80PH", strStt, drCurrent, "DUYET_TP", "DUYET_PXCD", "DUYET_PXCD", dgvViewPh);
                        //if (!(bool)(drCurrent["DUYET_TP"]))
                        //    return;

                        //Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_PXCD FROM R80PH WHERE Stt = '" + strStt + "'"));
                        //frmDuyetYeuCau frm = new frmDuyetYeuCau();
                        //frm.Load(drCurrent, Is_Duyet, strColumnName);

                        //if (frm.Is_Accept)
                        //{
                        //    dgvViewPh.Columns["DUYET_PXCD"].ReadOnly = false;
                        //    drCurrent["DUYET_PXCD"] = frm.chkDuyet.Checked; 

                        //    string strSQLExec = string.Empty;
                        //    Hashtable htPara = new Hashtable();
                        //    htPara.Add("DUYET_PXCD", (bool)drCurrent["DUYET_PXCD"]);
                        //    htPara.Add("STT", drCurrent["STT"]);
                        //    htPara.Add("DUYET_PXCD_LOG", Common.GetCurrent_Log());

                        //    strSQLExec = "UPDATE R80PH SET DUYET_PXCD = @DUYET_PXCD, DUYET_PXCD_LOG = @DUYET_PXCD_LOG WHERE Stt = @STT";
                        //    SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
							
                        //}
					}
				}
				else
				{
					dgvViewPh.Columns["DUYET_PXCD"].ReadOnly = false;
				}
			}

			if (strColumnName == "DUYET_KTCDAT")
			{
				bool bDuyet = false;
               
                if (strMa_Ct_List == "PYCTH")
                {
                    if (SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Nvu) FROM R04CTPO WHERE Stt = '" + @strStt + "'").ToString() == "THVPP")
                        bDuyet = Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access);
                    else
                        bDuyet = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
                }
                else
                {
                    if (!Element.sysIs_Admin)
                        bDuyet = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
                }

				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;

				if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
				}
                if (Common.Inlist(strMa_Ct_List, "DNX,NCTH,PYCPT,PYCCK,PYCTH,BBPT,BBTH,PONL,POXL,POCG,DTCP,PONL,POCG") && bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
				{
					if (Convert.ToBoolean(drCurrent["DUYET_KTCDAT"]) && strDuyet_KtCdAt_Log.Substring(14) != Element.sysUser_Id)
					{
						dgvViewPh.Columns["DUYET_KTCDAT"].ReadOnly = true;
					}
					else
					{
						if (Common.InlistLike(strMa_Ct_List, "PYCCK"))
						{
                            //if (!(bool)(drCurrent["DUYET_PXCD"]))
                            //    return;
                            Voucher.DuyetCt("R80PH", strStt, drCurrent, "DUYET_PXCD", strColumnName, strColumnName, dgvViewPh);
						}
						else if (!Common.InlistLike(strMa_Ct_List, "BBPT,BBTH"))
                            Voucher.DuyetCt("R80PH", strStt, drCurrent, "DUYET_TP", strColumnName, strColumnName, dgvViewPh);
                        
					}
				}
				else
				{
					dgvViewPh.Columns["DUYET_KTCDAT"].ReadOnly = false;
				}
			}

			if (strColumnName == "DUYET_KTTC")
			{
				bool bDuyet = false;

				//if (!Element.sysIs_Admin)
				bDuyet = Common.CheckPermission("IS_TP_KTTC", enuPermission_Type.Allow_Access);

				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;

				if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
				}
                //if (Common.Inlist(strMa_Ct_List, "POCG") && bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
                //{
                //    if (Convert.ToBoolean(drCurrent["DUYET_KTTC"]) && strDuyet_KtCdAt_Log.Substring(14) != Element.sysUser_Id)
                //    {
                //        dgvViewPh.Columns["DUYET_KTTC"].ReadOnly = true;
                //    }
                //    else
                //    {
                      
                //        Voucher.DuyetCt("R80PH", strStt, drCurrent, "DUYET_KTCDAT", strColumnName, strColumnName, dgvViewPh);
                       
                //    }
                //}



                //else 
                if (Common.Inlist(strMa_Ct_List, "DT,DTCP,DTXE,DTNA,DTXE,POCG") && bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
                {
                    if (Common.Inlist(strMa_Ct_List, "DT,POCG"))
                        Voucher.DuyetCt("R80PH", strStt, drCurrent, "DUYET_KHVT", strColumnName, strColumnName, dgvViewPh);
                    else if (Common.Inlist(strMa_Ct_List, "DTNA,DTXE"))
                        Voucher.DuyetCt("R80PH", strStt, drCurrent, "DUYET_TP", strColumnName, strColumnName, dgvViewPh);
                    else if (Common.Inlist(strMa_Ct_List, "DTCP"))
                        Voucher.DuyetCt("R80PH", strStt, drCurrent, "DUYET_KTCDAT", strColumnName, strColumnName, dgvViewPh);
                }
               
                else
                {
                    dgvViewPh.Columns["DUYET_KTTC"].ReadOnly = false;
                }
			}

			if (strColumnName == "DUYET_KHVT")
			{
				bool bDuyet = false;

				if(!Element.sysIs_Admin)
					bDuyet = Common.CheckPermission("IS_TP_KHVT", enuPermission_Type.Allow_Access);

				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;

				if (strCreate_User != string.Empty) //&& strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
				}
                if (Common.Inlist(strMa_Ct_List, "DT,DTVPP,DNX,DNXNL,NCTH,PYCPT,PYCCK,PYCTH,BBPT,BBTH,PONL,POXL,PONL,POCG") && bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
				{
                    //nếu đã duyệt nhưng tp KHVT sẽ dc xem nên đoạn này ko vào
					if ((Convert.ToBoolean(drCurrent["DUYET_KHVT"]) && strDuyet_KhVt_Log.Substring(14) != Element.sysUser_Id) && !Common.CheckPermission("IS_TP_KHVT", enuPermission_Type.Allow_Access))
					{
                       dgvViewPh.Columns["DUYET_KHVT"].ReadOnly = true;
					}
					else
					{
                        if (!Common.Inlist(strMa_Ct_List, "DNXNL,DT,DTVPP,BBPT,BBTH,PONL,POCG"))
						{
							if (!(bool)(drCurrent["DUYET_TP"]))
								return;
							if (!(bool)(drCurrent["DUYET_KTCDAT"]))
								return;
						}
                        else if (Common.Inlist(strMa_Ct_List, "DNXNL") && !(bool)(drCurrent["DUYET_TP"]))
                            return;

                        if (Common.Inlist(strMa_Ct_List, "DT,POCG"))
                            Voucher.DuyetCt("R80PH", strStt, drCurrent, "", strColumnName, strColumnName, dgvViewPh);
                        else if (Common.InlistLike(strMa_Ct_List, "PYC,PONL"))
                            Voucher.DuyetCt("R80PH", strStt, drCurrent, "DUYET_KTCDAT", strColumnName, strColumnName, dgvViewPh);
                        else if (Common.InlistLike(strMa_Ct_List, "DNXNL"))
                            Voucher.DuyetCt("R80PH", strStt, drCurrent, "DUYET_TP", strColumnName, strColumnName, dgvViewPh);

                        //Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_KHVT FROM R80PH WHERE Stt = '" + strStt + "'"));
                        //frmDuyetYeuCau frm = new frmDuyetYeuCau();
                        //frm.Load(drCurrent, Is_Duyet, strColumnName);

                        //if (frm.Is_Accept)
                        //{
							
                        //    dgvViewPh.Columns["DUYET_KHVT"].ReadOnly = false;
                        //    drCurrent["DUYET_KHVT"] = frm.chkDuyet.Checked;

                        //    string strSQLExec = string.Empty;
                        //    Hashtable htPara = new Hashtable();
                        //    htPara.Add("DUYET_KHVT", (bool)drCurrent["DUYET_KHVT"]);
                        //    htPara.Add("STT", drCurrent["STT"]);
                        //    htPara.Add("DUYET_KHVT_LOG", Common.GetCurrent_Log());

                        //    strSQLExec = "UPDATE R80PH SET DUYET_KHVT = @DUYET_KHVT, DUYET_KHVT_LOG = @DUYET_KHVT_LOG WHERE Stt = @STT";
                        //    SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
							

                        //}
					}
				}
				else
				{
					dgvViewPh.Columns["DUYET_KHVT"].ReadOnly = false;
				}
			}


          

			if (strColumnName == "DUYET_GIAMDOC")
			{
				bool bDuyet = false;

				//if(!Element.sysIs_Admin)
				bDuyet = Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access);

				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;

				if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
				}
				if (Common.Inlist(strMa_Ct_List, "DT,DTNA,DTCP,DNX,NCTH,PYCPT,PYCCK,PYCTH,PONL,POXL,POCG,DNXNL") && bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
				{
					if (drCurrent["GD_Duyet"].ToString() != Element.sysUser_Id)
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chứng từ được trình '" + drCurrent["GD_Duyet"] + "'" : "Do not register transaction type";
						Common.MsgCancel(strMsg);
						dgvViewPh.Columns["DUYET_GIAMDOC"].ReadOnly = true;
					}
					else
					{
                        if (Common.Inlist(strMa_Ct_List, "PYCPT,PYCCK,PYCTH"))
						{
							if (!(bool)(drCurrent["DUYET_KHVT"]))
								return;
						}
                        if (Common.Inlist(strMa_Ct_List, "DT,DTNA"))
                        {
                            if (!(bool)(drCurrent["DUYET_KTTC"]))
                                return;
                        }
                        if (Common.Inlist(strMa_Ct_List, "DTCP"))
                        {
                            if (!(bool)(drCurrent["DUYET_KTCDAT"]))
                                return;
                        }

						Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_GIAMDOC FROM R80PH WHERE Stt = '" + strStt + "'"));
						frmDuyetYeuCau frm = new frmDuyetYeuCau();
                        frm.Load(drCurrent, Is_Duyet, strColumnName);
						
						if (frm.Is_Accept)
						{
							
							dgvViewPh.Columns["DUYET_GIAMDOC"].ReadOnly = false;
							drCurrent["DUYET_GIAMDOC"] = frm.chkDuyet.Checked;
                            drCurrent["DUYET_HUY"] = frm.chkDuyet_Huy.Checked;

							string strSQLExec = string.Empty;
							Hashtable htPara = new Hashtable();
							htPara.Add("DUYET_GIAMDOC", (bool)drCurrent["DUYET_GIAMDOC"]);
                            htPara.Add("DUYET_HUY", (bool)drCurrent["DUYET_HUY"]);
							htPara.Add("STT", drCurrent["STT"]);
							htPara.Add("DUYET_GD_LOG", Common.GetCurrent_Log());

                            strSQLExec = "UPDATE R80PH SET DUYET_GIAMDOC = @DUYET_GIAMDOC, DUYET_GD_LOG = @DUYET_GD_LOG, DUYET_HUY = @DUYET_HUY WHERE Stt = @STT";
							SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
							
						}
					}
				}
				else
				{
					dgvViewPh.Columns["DUYET_GIAMDOC"].ReadOnly = false;
				}
			}

            if (strColumnName == "DUYET_PKD")
			{
				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;
				string strUser_Duyet_PKD = (string)drCurrent["User_Duyet_PKD"];
                DataRow drPhPKD = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt);
                if ((bool)drPhPKD["Duyet"])
                {
                    Common.MsgOk("Phiếu đã được PKTTC duyệt!!!");
                    return;
                }
                //KIỂM TRA TRÙNG SỐ CT
                string[] strArrName = { "Ma_Ct", "Ngay_Ct", "So_Ct"};
                object[] objArrValue = { drPhPKD["Ma_Ct"], drPhPKD["Ngay_Ct"], drPhPKD["So_Ct"] };
                if (SQLExec.ExecuteReturnDt("Sp_CheckTrungSoCt", strArrName, objArrValue, CommandType.StoredProcedure).Rows.Count > 1)
                {
                    Common.MsgOk("Số chứng từ " + drPhPKD["So_Ct"].ToString() + " đã tồn tại, anh chị kiểm tra lại trước khi duyệt lệnh !!!");
                    return;
                }
                //
                if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
				}
               
               
				if (Common.Inlist(strMa_Ct_List, "SO,SOCP") && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
				{
                    // kiểm tra hàng ký gửi
                    string strSQL = "SELECT Ngay_Ct, Ma_Dt, Ht_Gn, Ma_KhoN FROM R04CTSO WHERE Stt = '" + strStt + "'";
                    DataTable dtKG0 = SQLExec.ExecuteReturnDt(strSQL);
                    DataRow drKG0 = dtKG0.Rows[0];
                    if (Common.InlistLike(drKG0["Ht_Gn"].ToString(), "KG"))
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("NGAY_CT", drKG0["Ngay_Ct"]);
                        ht.Add("MA_DT", drKG0["Ma_Dt"]);
                        ht.Add("MA_KHON", drKG0["Ma_KhoN"]);
                        //ht.Add("MA_", drKG0["Ma_Dt"]);
                        ht.Add("STT", strStt);
                        DataTable dtKG = SQLExec.ExecuteReturnDt("sp_rptCheck_SOKG", ht, CommandType.StoredProcedure);
                        DataRow drKG = dtKG.Rows[0];
                        if (numTSo_Luong.Value > Convert.ToDouble(drKG["SL_CL"]))
                        {
                            double dbChenh_Lech = numTSo_Luong.Value - Convert.ToDouble(drKG["SL_CL"]);
                            if (!Common.MsgYes_No("Số lượng LXH lớn hơn hạn mức ký gửi còn lại " + dbChenh_Lech + ". Bạn có muốn duyệt tiếp không?", "N"))
                                return;
                            else
                            {
                                frmDuyet_PKD frm = new frmDuyet_PKD();
                                if (Common.CheckPermission("DUYET_PKD", enuPermission_Type.Allow_Access))
                                {
                                    if (string.IsNullOrEmpty(strUser_Duyet_PKD))
                                        frm.Load(drCurrent);
                                    else if (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ","))//Element.sysUser_Id.ToString().Trim() == strUser_Duyet_PKD.Trim())
                                        frm.Load(drCurrent);
                                }
                                else
                                    Common.MsgOk("Bạn không có quyền duyệt hoặc hủy duyệt của người khác");
                            }

                        }
                        else
                        {
                            frmDuyet_PKD frm = new frmDuyet_PKD();
                            if (Common.CheckPermission("DUYET_PKD", enuPermission_Type.Allow_Access))
                            {
                                if (string.IsNullOrEmpty(strUser_Duyet_PKD))
                                    frm.Load(drCurrent);
                                else if (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ","))//Element.sysUser_Id.ToString().Trim() == strUser_Duyet_PKD.Trim())
                                    frm.Load(drCurrent);

                               
                            }
                            else
                                Common.MsgOk("Bạn không có quyền duyệt hoặc hủy duyệt của người khác");
                        }
                    }
                    else
                    {
                        frmDuyet_PKD frm = new frmDuyet_PKD();
                        if (Common.CheckPermission("DUYET_PKD", enuPermission_Type.Allow_Access))
                        {
                            if (string.IsNullOrEmpty(strUser_Duyet_PKD))
                                frm.Load(drCurrent);
                            else if (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ","))//Element.sysUser_Id.ToString().Trim() == strUser_Duyet_PKD.Trim())
                                frm.Load(drCurrent);

                            drCurrent["DUYET"] = (bool)SQLExec.ExecuteReturnValue("SELECT Duyet FROM R80PH WHERE STT = '" + strStt + "'");
                        }
                        else
                            Common.MsgOk("Bạn không có quyền duyệt hoặc hủy duyệt của người khác");
                    }
				}


			}
			if (strColumnName == "PHAN_HOI_KHVT")
			{
                frmPhan_Hoi_KHVT frm = new frmPhan_Hoi_KHVT();
                frm.Load(drCurrent,"PKHVT");
                
			}
            if (strColumnName == "ADD_HD" && strMa_Ct_List == "DNXNL")
            {

                frmPhan_Hoi_KHVT frm = new frmPhan_Hoi_KHVT();
                frm.Load(drCurrent, "DNXNL");

            }
            if (strColumnName == "LOCK")
            {
                if (Common.CheckPermission("IS_UNLOCK131", enuPermission_Type.Allow_Access) && !Common.Inlist(strMa_Ct_List,"NM,PX"))
                {
                    frmUnLock_KT frm = new frmUnLock_KT();
                    frm.Load(drCurrent);
                    
                }
                else if (Common.CheckPermission("IS_THUKHO", enuPermission_Type.Allow_Access) && Common.Inlist(strMa_Ct_List, "NM,NK,PX"))
                {
                    frmUnLock_KT frm = new frmUnLock_KT();
                    frm.Load(drCurrent);
                    drCurrent["Lock"] = frm.chkIs_Lock.Checked;
                }
               
            }
            
			if (strColumnName == "IS_VT_NHAN")
			{
                bool bNhan_Ct = false;

                if(strMa_Ct_List == "DNTT")
                    bNhan_Ct = Common.CheckPermission("NHAN_CT_DNTT", enuPermission_Type.Allow_Access);
                else if (strMa_Ct_List.StartsWith("PYC"))
                    bNhan_Ct = Common.CheckPermission("NHAN_CT_PYC", enuPermission_Type.Allow_Access);
                else
				    bNhan_Ct = Common.CheckPermission("NHAN_CT", enuPermission_Type.Allow_Access);
                
                bool bIs_Vt_Nhan = !Convert.ToBoolean(drCurrent["Is_Vt_Nhan"]);
                bool bIs_Duyet = Convert.ToBoolean(drCurrent["Duyet_Tp"]);
                
                if (bNhan_Ct)
				{
                    //if (Element.sysIs_Admin)
                    //{
                    //    if (strMa_Ct_List == "DNTT" && !bIs_Duyet)
                    //        return;

                    //    drCurrent["Is_Vt_Nhan"] = bIs_Vt_Nhan;

                    //    Hashtable ht = new Hashtable();
                    //    ht.Add("IS_VT_NHAN", bIs_Vt_Nhan);
                    //    ht.Add("USER_VT", Common.GetCurrent_Log());
                    //    ht.Add("STT", strStt);

                    //    string strSql = "UPDATE R80PH SET Is_Vt_Nhan = @Is_Vt_Nhan, User_Vt = @User_Vt WHERE Stt = @Stt";
                    //    SQLExec.Execute(strSql, ht, CommandType.Text);
                    //}
                    //else !Element.sysIs_Admin && 
                    if (Convert.ToBoolean(drCurrent["Is_Vt_Nhan"]) == false && strMa_Ct_List.StartsWith("PYC")) 
                    {
                        string strMsg = "Bạn có muốn đóng PYC không tiếp tục thực hiện mua hàng cho PYC này không?";
                       
                        if(!Common.MsgYes_No(strMsg, "N"))
                            return;
                        else
                        {
                            drCurrent["Is_Vt_Nhan"] = bIs_Vt_Nhan;
                            drCurrent["Duyet_Huy"] = bIs_Vt_Nhan;
                            Hashtable ht = new Hashtable();
                            ht.Add("IS_VT_NHAN", bIs_Vt_Nhan);
                            ht.Add("DUYET_HUY", bIs_Vt_Nhan); // Update đồng thời duyệt hủy = is_vt_nhan
                            ht.Add("USER_VT", Common.GetCurrent_Log());
                            ht.Add("STT", strStt);

                            string strSql = "UPDATE R80PH SET Is_Vt_Nhan = @Is_Vt_Nhan, Duyet_Huy = @Duyet_Huy, User_Vt = @User_Vt WHERE Stt = @Stt";
                            SQLExec.Execute(strSql, ht, CommandType.Text);
                        }

                    }
                    else if (!Element.sysIs_Admin && Convert.ToBoolean(drCurrent["Is_Vt_Nhan"]) == false && !strMa_Ct_List.StartsWith("DNTT"))
                    {
                       
                        drCurrent["Is_Vt_Nhan"] = bIs_Vt_Nhan;

                        Hashtable ht = new Hashtable();
                        ht.Add("IS_VT_NHAN", bIs_Vt_Nhan);
                        ht.Add("USER_VT", Common.GetCurrent_Log());
                        ht.Add("STT", strStt);

                        string strSql = "UPDATE R80PH SET Is_Vt_Nhan = @Is_Vt_Nhan, User_Vt = @User_Vt WHERE Stt = @Stt";
                        SQLExec.Execute(strSql, ht, CommandType.Text);
                    }
                    else if (strMa_Ct_List.StartsWith("DNTT")  && ((string)drCurrent["User_Vt_Nhan"] == Element.sysUser_Id || (string)drCurrent["User_Vt_Nhan"] == ""))
                    {
                        if (bIs_Duyet)
                        {
                            drCurrent["Is_Vt_Nhan"] = bIs_Vt_Nhan;

                            Hashtable ht = new Hashtable();
                            ht.Add("IS_VT_NHAN", bIs_Vt_Nhan);
                            ht.Add("USER_VT", Common.GetCurrent_Log());
                            ht.Add("STT", strStt);

                            string strSql = "UPDATE R80PH SET Is_Vt_Nhan = @Is_Vt_Nhan, User_Vt = @User_Vt WHERE Stt = @Stt";
                            SQLExec.Execute(strSql, ht, CommandType.Text);
                        }
                        else
                            Common.MsgOk("Phiếu chưa được trưởng đơn vị duyệt");
                    }
				}
			}
			if (strColumnName == "DUYET")
			{
				string strMa_Ct = strMa_Ct_List.Split(',')[0];

				bool bDuyet = Common.CheckPermission("DUYET", enuPermission_Type.Allow_Access);
				bool bDuyet_SO_PKT = Common.CheckPermission("DUYET_SO_PKT", enuPermission_Type.Allow_Access);
				bool bDuyet_LGH = Common.CheckPermission("DUYET_LGH", enuPermission_Type.Allow_Access);

				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;
				string strUser_Duyet = (string)drCurrent["Duyet_Log"];
				string strUser_login = Element.sysUser_Id.ToString().Trim();
				
				if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
				}

				if (Common.Inlist(strMa_Ct, "SO,SOCP"))
				{
                    Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET FROM R80PH WHERE Stt = '" + strStt + "'"));
                  
                   
					if (bDuyet_SO_PKT && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
					{
						if (string.IsNullOrEmpty(strUser_Duyet))
						{
                            //if (iPrint_Count == 0)
                            //{
                                frmDuyetYeuCau frm = new frmDuyetYeuCau();
                                frm.Load(drCurrent, Is_Duyet, strColumnName);
                                
                                if (frm.Is_Accept)
                                {
                                    string strSQLExec = string.Empty;
                                    Hashtable htPara = new Hashtable();

                                    drCurrent["DUYET"] = frm.chkDuyet.Checked;
                                    

                                    htPara.Add("DUYET", (bool)drCurrent["DUYET"]);
                                    htPara.Add("IS_VT_NHAN",(bool)drCurrent["IS_VT_NHAN"]);
                                    htPara.Add("GHI_CHU_PKTTC", frm.txtGhi_Chu_PKTTC.Text);
                                    htPara.Add("STT", drCurrent["STT"]);
                                    htPara.Add("DUYET_LOG", Common.GetCurrent_Log());
                                    htPara.Add("USER_VT", Common.GetCurrent_Log());

                                    strSQLExec = "UPDATE R80PH SET DUYET = @DUYET, DUYET_LOG = @DUYET_LOG, USER_VT = @USER_VT, GHI_CHU_PKTTC = @GHI_CHU_PKTTC WHERE Stt = @STT";
                                    SQLExec.Execute(strSQLExec, htPara, CommandType.Text);
                                    
                                }
                            //}
						}
						else if (Element.sysUser_Id.ToString().Trim() == strUser_Duyet.Substring(14))
						{
                            //if (iPrint_Count == 0)
                            //{
								string sqlKT = "";
                                sqlKT = "SELECT T1.Stt FROM R04CTSO T1 JOIN R80PH T2 ON T1.Stt = T2.Stt AND T2.Duyet_Huy = 0 AND T2.Is_Vt_Nhan = 0 WHERE Stt_Org =  " + "'" + drCurrent["Stt"] + "' AND Stt_org NOT IN (SELECT Stt FROM R80PH WHERE Duyet = 0 AND Is_Vt_Nhan = 1)";
								if (!String.IsNullOrEmpty((string)SQLExec.ExecuteReturnValue(sqlKT)))
								{
									Common.MsgOk("CHỨNG TỪ ĐÃ ĐƯỢC KẾ THỪA");
									return;
								}
                                frmDuyetYeuCau frm = new frmDuyetYeuCau();
                                frm.Load(drCurrent, Is_Duyet, strColumnName);
                                if (frm.Is_Accept)
                                {
                                    string strSQLExec = string.Empty;
                                    Hashtable htPara = new Hashtable();

                                    drCurrent["DUYET"] = frm.chkDuyet.Checked;
                                   

                                    htPara.Add("DUYET", (bool)drCurrent["DUYET"]);
                                    htPara.Add("IS_VT_NHAN", (bool)drCurrent["IS_VT_NHAN"]);
                                    htPara.Add("GHI_CHU_PKTTC", frm.txtGhi_Chu_PKTTC.Text);
                                    htPara.Add("STT", drCurrent["STT"]);
                                    htPara.Add("DUYET_LOG", Common.GetCurrent_Log());
                                    htPara.Add("USER_VT", Common.GetCurrent_Log());

                                    strSQLExec = "UPDATE R80PH SET DUYET = @DUYET, DUYET_LOG = @DUYET_LOG, USER_VT = @USER_VT, GHI_CHU_PKTTC = @GHI_CHU_PKTTC WHERE Stt = @STT";
                                    SQLExec.Execute(strSQLExec, htPara, CommandType.Text);

                                }
                            //}
                            //else
                            //{
                            //    Common.MsgOk("Chứng từ đã được in, không bỏ duyệt được");
                            //    return;
                            //}
						}
					}
					else
					{
						Common.MsgOk("Bạn không có quyền duyệt hoặc hủy duyệt của người khác, hoặc chứng từ đã được in");
						return;
					}
				}
				else if (Common.Inlist(strMa_Ct, "LXH") )
				{

                    if (bDuyet_LGH && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
                    {
                        frmDuyet frm = new frmDuyet();
                        frm.Load(drCurrent);
                        return;
                    }
                    //    if (drCurrent["So_Xa_Lan_Tau"].ToString() == "" && drCurrent["Ma_Xe"].ToString() == "")
                    //    {
                    //        //kiểm tra tên lái xe và số xe 
                    //        if(Convert.ToDouble(drCurrent["Ident_RVC"]) != 0)
                    //        {
                                
                    //                frmDuyet frm = new frmDuyet();
                    //                frm.Load(drCurrent);
                    //                return;
                                
                    //        }
                    //        else
                    //        {
                    //            Common.MsgOk("Xe Chưa vào lấy hàng vui lòng Refresh lại dữ kiệu để kiểm tra");
                    //            return;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        frmDuyet frm = new frmDuyet();
                    //        frm.Load(drCurrent);
                    //        return;
                    //    }
                    //}
                    //else
                    //    return;

				}
				else if (Common.Inlist(strMa_Ct, "PXPT"))
				{
					bool bThu_Kho = Common.CheckPermission("IS_THUKHO", enuPermission_Type.Allow_Access);
					
					if (bThu_Kho)
					{
						frmDuyet frm = new frmDuyet();
						frm.Load(drCurrent);
					}
				}
                else if (Common.Inlist(strMa_Ct, "PX,NM"))
                {
                    bool bThu_Kho = Common.CheckPermission("IS_TP_KHVT", enuPermission_Type.Allow_Access);

                    if (bThu_Kho)
                    {
                        frmDuyet frm = new frmDuyet();
                        frm.Load(drCurrent);
                    }
                }
				else
				{
					frmDuyet frm = new frmDuyet();
					frm.Load(drCurrent);
				}
			}

			if (strColumnName == "DUYET_HUY")
			{
				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;
				string strUser_Duyet_Huy = (string)drCurrent["User_Huy"];
                bool bDuyet_Huy = (bool)SQLExec.ExecuteReturnValue("SELECT Duyet_Huy FROM R80PH WHERE Stt = '"+ strStt +"'");
                bool bHDDT = (bool)SQLExec.ExecuteReturnValue("SELECT HDDTDaTao FROM R80PH WHERE Stt = '" + strStt + "'");
                string strTable_Ct = (string)SQLExec.ExecuteReturnValue("SELECT Table_Ct FROM R00DMCT WHERE Ma_Ct = '"+ strMa_Ct_List +"'");
                bool bDaXuatHD = false;
                
                if(SQLExec.ExecuteReturnDt("SELECT * FROM INFORMATION_SCHEMA.COLUMNS  WHERE  TABLE_NAME = '"+ strTable_Ct +"' AND COLUMN_NAME = 'IsDaXuatHD'").Rows.Count > 0)
                    bDaXuatHD = (bool)SQLExec.ExecuteReturnValue("SELECT IsDaXuatHD FROM " + strTable_Ct + " WHERE Stt = '" + strStt + "' GROUP BY IsDaXuatHD");
				
                if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
				}


                if (!bDuyet_Huy && Common.CheckPermission("DUYET_HUY", enuPermission_Type.Allow_Access) &&
                    (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")) && Common.Inlist(strMa_Ct_List, "PXDC,HD") && !bHDDT && !bDaXuatHD)
                {
                    frmDuyet_Huy frm = new frmDuyet_Huy();
                    frm.Load(drCurrent);
                }
                // các ct ko ph
                else if (!bDuyet_Huy && Common.CheckPermission("DUYET_HUY", enuPermission_Type.Allow_Access)  &&
                    (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")) && !Common.Inlist(strMa_Ct_List, "PXDC,HD") && !bDaXuatHD)
                {
                    //check đã ra BBNT CHƯA
                    DataTable dtCheckBBNT = SQLExec.ExecuteReturnDt("exec sp_CheckSttOrgList '" + strStt + "'");

                    if (dtCheckBBNT.Rows.Count > 0 && strMa_Ct_List == "DT")
                    {
                        Common.MsgOk("Dự trù đã lập BBNT không được hủy!!!");
                        return;
                    }
                    frmDuyet_Huy frm = new frmDuyet_Huy();
                    frm.Load(drCurrent);
                  
                }
                // các ct ko ph
                else if (!bDuyet_Huy && Common.CheckPermission("DUYET_HUY_LXH", enuPermission_Type.Allow_Access) &&
                    (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")) && Common.Inlist(strMa_Ct_List, "LXH"))// && !bDaXuatHD)
                {
                    //check đã ra BBNT CHƯA
                    DataTable dtCheckBBNT = SQLExec.ExecuteReturnDt("exec sp_CheckSttOrgList '" + strStt + "'");

                   
                    frmDuyet_Huy frm = new frmDuyet_Huy();
                    frm.Load(drCurrent);

                }
                else if (!bDuyet_Huy && Common.CheckPermission("DUYET_HUY", enuPermission_Type.Allow_Access) &&
               (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")) && bDaXuatHD)
                {
                    Common.MsgOk("Chứng từ đã ra hóa đơn không cho phép hủy!!!");
                }
                else if (bDuyet_Huy)
                    Common.MsgOk("Lệnh đã đóng không cho phép mở!!");
                else if (bHDDT && strMa_Ct_List == "PXDC")
                    Common.MsgOk("Phiếu xuất đã tạo điện tử không cho phép hủy!!");
                else
                    Common.MsgOk("Bạn không có quyền duyệt hoặc hủy duyệt của người khác");
                
                
			
			}

			
		}
        void timer_Newdata_Tick(object sender, EventArgs e)
        {
            if (timer_Newdata.Enabled == true)
            {
                object objNgay_CtMax = SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM " + (string)drDmCt["Table_Ph"] + " WHERE Ma_Ct LIKE '" + this.strMa_Ct_List.Split(',')[0] + "' AND Ma_DvCs = '" + Element.sysMa_DvCs + "'");
                int iInterval = Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER"));

                DateTime dteNgay_Ct2 = objNgay_CtMax != DBNull.Value ? (DateTime)objNgay_CtMax : DateTime.Now;
                DateTime dteNgay_Ct1 = dteNgay_Ct2.Subtract(new TimeSpan(iInterval, 0, 0, 0));

                DataTable dtFilter = new DataTable();
                dtFilter.Columns.Add(new DataColumn("Ma_Ct_List", typeof(string)));
                dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
                dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));

                DataRow drFilter = dtFilter.NewRow();
                drFilter["Ma_Ct_List"] = strMa_Ct_List;
                drFilter["Ngay_Ct1"] = dteNgay_Ct1;
                drFilter["Ngay_Ct2"] = dteNgay_Ct2;

                if (!drFilter.Table.Columns.Contains("Table_PH"))
                    drFilter.Table.Columns.Add(new DataColumn("Table_PH", typeof(string)));

                if (!drFilter.Table.Columns.Contains("Table_Ct"))
                    drFilter.Table.Columns.Add(new DataColumn("Table_Ct", typeof(string)));

                if (!drFilter.Table.Columns.Contains("User_LogIn"))
                    drFilter.Table.Columns.Add(new DataColumn("User_LogIn", typeof(string)));

                //if (!drFilter.Table.Columns.Contains("Print_Count"))
                //    drFilter.Table.Columns.Add(new DataColumn("Print_Count", typeof(string)));

                if (!drFilter.Table.Columns.Contains("Ma_DvCs"))
                    drFilter.Table.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));


                drFilter["Table_PH"] = drDmCt["Table_PH"];
                drFilter["Table_Ct"] = drDmCt["Table_Ct"];
                drFilter["Ma_DvCs"] = Element.sysMa_DvCs;
                drFilter["User_LogIn"] = Element.sysUser_Id;


                //dtViewPh_Newdata.Clear();

                dtViewPh_Newdata = SQLExec.ExecuteReturnDt("sp_GetVoucherFilter_NewData", drFilter, CommandType.StoredProcedure);

                if (dtViewPh_Newdata.Rows.Count != dtViewPh.Rows.Count)
                    FillData(drFilter);
            }
        }
		#endregion
	

	}
}
