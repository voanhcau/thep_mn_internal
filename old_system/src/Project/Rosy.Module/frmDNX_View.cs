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
using RosyModule.Properties;


namespace RosyModule
{
	public partial class frmDNX_View : RosySystem.Customize.frmView
	{
		#region Fields

		public DataSet dsVoucher = new DataSet("dsVoucher");

		public DataTable dtViewPh;
		public DataTable dtViewCt;
		public DataTable dtResource;
		public DataTable dtDmSO;
		

		public BindingSource bdsViewPh = new BindingSource();
		public BindingSource bdsViewCt = new BindingSource();
		public BindingSource bdsResource = new BindingSource();
		public BindingSource bdsDmSO = new BindingSource();

		public rsDataGridView dgvViewPh = new rsDataGridView();
		public rsDataGridView dgvViewCt = new rsDataGridView();
		public rsDataGridView dgvResource = new rsDataGridView();
		public rsDataGridView dgvDmSO = new rsDataGridView();

		public DataRelation drlView;

		public string strMa_Ct_List = string.Empty;
		public DataRow drCurrent;
		public DataRow drDmCt;
		public DataRow drResource;
		public DataRow drDmSO;
        public DataRow drCtSO;
        string strStt_Current = string.Empty;
		#endregion

		#region Contructor

		public frmDNX_View()
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
			btnXuatViTri.Click += new EventHandler(btnXuatDinhMuc_Click);
            btBarcode.Click += new EventHandler(btBarcode_Click);
            btPhieuXuat.Click += new EventHandler(btPhieuXuat_Click);
		}

        

        

        void dgvViewCt_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string strColumnName = dgvViewCt.Columns[e.ColumnIndex].Name;
            drCtSO = ((DataRowView)bdsViewCt.Current).Row;

        }

		

		private void XuatDinhMuc()
		{
			
			drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            strStt_Current = drCurrent["Stt"].ToString();

			if ((bool)drCurrent["Duyet_TP"])
			{
                if (SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Nvu) FROM R04CTPO WHERE Stt = '" + strStt_Current + "'").ToString() == "LVPP" && Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access))
                {
                    frmXuatVTriKho frmDinh_Muc = new frmXuatVTriKho();
                    frmDinh_Muc.Load(drCurrent);

                    if (frmDinh_Muc.dtXuatVTriKho.Select("Chon = true").Length != 0)
                        drCurrent["Duyet_KTCDAT"] = true;

                    PositionChange();
                }
                else if (SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Nvu) FROM R04CTPO WHERE Stt = '" + strStt_Current + "'").ToString() == "LVTPT" && Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access))
                {
                    frmXuatVTriKho frmDinh_Muc = new frmXuatVTriKho();
                    frmDinh_Muc.Load(drCurrent);

                    if (frmDinh_Muc.Is_Accept == true)// && frmDinh_Muc.dtXuatVTriKho.Select("Chon = true").Length != 0)
                    {
                        if( (bool)drCurrent["Duyet_KTCDAT"] == false)
                        {
                            double dbTSo_Luong = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT SUM(So_Luong) FROM R04CTPO WHERE Stt = '" + strStt_Current + "'"));
                            string strEXEC = "UPDATE R80PH SET Duyet_KTCDAT = 1, Duyet_KtCdAt_Log = @Create_Log, TSo_Luong = @TSo_Luong WHERE Stt = @Stt";
                            Hashtable ht = new Hashtable();
                            ht.Add("STT", strStt_Current);
                            ht.Add("CREATE_LOG", Common.GetCurrent_Log());
                            ht.Add("TSO_LUONG", dbTSo_Luong);

                            SQLExec.Execute(strEXEC, ht, CommandType.Text);
                            drCurrent["Duyet_KTCDAT"] = true;
                            drCurrent["Duyet_KtCdAt_Log"] = Common.GetCurrent_Log();
                        }
                    }
                    PositionChange();
                }
                else
                {
                    Common.MsgOk("Bạn không được cấp quyền. Vui lòng liên hệ PCNTT kiểm tra lại");
                }
			}
			else
			{
				Common.MsgOk("Chứng từ chưa được phòng PKTDT duyệt");
			}
		}

		void btnXuatDinhMuc_Click(object sender, EventArgs e)
		{
			if (Common.CheckPermission("IS_THUKHO", enuPermission_Type.Allow_Access))
			{
				XuatDinhMuc();

				if (bdsViewPh.Find("Stt", strStt_Current) >= 0)
					bdsViewPh.Position = bdsViewPh.Find("Stt", strStt_Current);
			}
			else
				Common.MsgOk("Anh chị không được cấp quyền.");
		}

        void btBarcode_Click(object sender, EventArgs e)
        {
            if (Common.CheckPermission("CTX_BARCODE_PT", enuPermission_Type.Allow_Access))
            {
                drCurrent = ((DataRowView)bdsViewPh.Current).Row;

                frmCtXBarcodePT frm = new frmCtXBarcodePT();
                frm.Load(drCurrent["Stt"].ToString());
            }
        }
        void btPhieuXuat_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsViewPh.Current).Row;
            strStt_Current = drCurrent["Stt"].ToString();
            Hashtable ht = new Hashtable();
            ht.Add("STT", strStt_Current);

            //KIỂM TRA CT CÓ ĐƯỢC DUYỆT Ở KHO 016PT HAY 019VPP KHÔNG
            //string strSQL = "SELECT * FROM R04CTPO T1 JOIN R05CTNXVTRI T2 ON T1.Stt = T2.Stt AND T1.Ma_Vt = T2.Ma_Vt WHERE T1.Stt = '" + strStt_Current + "' AND Ma_Kho IN ('016PT','019VPP')";
            DataTable dtDuyetDNX = SQLExec.ExecuteReturnDt("sp_GetTonKhoAuto", ht, CommandType.StoredProcedure);

            DataTable dtCtNX = SQLExec.ExecuteReturnDt("SELECT TOP 1 * FROM R80PH WHERE Ma_Ct = 'PX' AND Stt IN "+
                            "(SELECT Stt FROM R05CTNX WHERE Ma_Kho = '016PT' AND Ma_Nvu = 'XKVT' AND Ngay_Ct IN (SELECT MAX(Ngay_Ct) FROM R05CTNX WHERE Ma_Kho = '016PT' AND Ma_Nvu = 'XKVT'))");
            if (dtDuyetDNX.Rows.Count > 0)
            {
                frmCtNXDNX_Edit frm = new frmCtNXDNX_Edit();
                frm.Load(enuEdit.New, dtCtNX.Rows[0], dtDuyetDNX);

            }
            else
                Common.MsgOk("Phiếu đã ra xong PXK hay tồn kho kế toán không có. Vui lòng kiểm tra lại. Chưa tạo phiếu được!!!");
        }
		private void EditCtDmSO(enuEdit enuNew_Edit)
		{
			//if (rsTabControl1.SelectedTab != pageCTDMSO)
			//    return;

			//if (bdsViewPh.Position < 0)
			//    return;

			//if (bdsDmSO.Position < 0 && enuNew_Edit == enuEdit.Edit)
			//    return;

			//drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			////Copy hang hien tai            
			//if (bdsDmSO.Position >= 0)
			//    Common.CopyDataRow(((DataRowView)bdsDmSO.Current).Row, ref drDmSO);
			//else
			//    drDmSO = dtDmSO.NewRow();

			//if (dtDmSO.Columns.Contains("Stt"))
			//    drDmSO["Stt"] = drCurrent["Stt"];

			//frmCtDmSO_Edit frmEdit = new frmCtDmSO_Edit();
			//frmEdit.Load(enuNew_Edit, drDmSO, (string)drCurrent["Stt"]);

			//// người dùng chọn chấp nhận
			//if (frmEdit.isAccept)
			//{
			//    if (enuNew_Edit == enuEdit.New)
			//    {
			//        if (bdsDmSO.Position >= 0)
			//            dtDmSO.ImportRow(drDmSO);
			//        else
			//            dtDmSO.Rows.Add(drDmSO);

			//        //drCurrent["Loai_CS"] = strMa_Ct;

			//        bdsDmSO.Position = bdsDmSO.Find("Ident00", drDmSO["Ident00"]);
			//    }
			//    else
			//    {
			//        Common.CopyDataRow(drDmSO, ((DataRowView)bdsDmSO.Current).Row);
			//    }

			//    dtDmSO.AcceptChanges();
			//}
			//else
			//    dtDmSO.RejectChanges();
		}

		private void DeleteCtDmSO()
		{
			if (bdsDmSO.Position < 0)
				return;
			if (!Common.CheckPermission("IS_THUKHO", enuPermission_Type.Allow_Access))
				return;

			DataRow drCurrent = ((DataRowView)bdsDmSO.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE") + " vị trí của mã vật tư " + drCurrent["Ma_Vt"] + " "))
                return;
            else
            {
                DataTable dtViTri = SQLExec.ExecuteReturnDt("SELECT COUNT(*) FROM R05CTNXVTRI WHERE Stt = '" + drCurrent["Stt"].ToString() + "'");
                if (dtViTri.Rows.Count == 1)
                    SQLExec.Execute("UPDATE R80PH SET Duyet_KTCDAT = 0 WHERE STT = '" + drCurrent["Stt"].ToString() + "'");
               
                DataRow drEditPh = ((DataRowView)bdsViewPh.Current).Row;
                drEditPh["Duyet_KTCDAT"] = false;
            }
            if (DataTool.SQLDelete("R05CTNXVTRI", drCurrent))
			{
				bdsDmSO.RemoveAt(bdsDmSO.Position);
				dtDmSO.AcceptChanges();
			}
             
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

            if (Element.sysIs_Admin || Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access) || Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access))
                btnXuatViTri.Visible = true;
            else
                btnXuatViTri.Visible = false;

            if (strMa_Ct_List.StartsWith("DNX"))
            {
                if (dgvViewPh.Columns.Contains("DUYET_KTCDAT"))
                    dgvViewPh.Columns["DUYET_KTCDAT"].HeaderText = "Duyệt KTDT/TCHC";

                if (dgvViewPh.Columns.Contains("NGAY_DUYET_KTCDAT"))
                    dgvViewPh.Columns["NGAY_DUYET_KTCDAT"].HeaderText = "Ngày KTDT/TCHC duyệt";
            }

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

			dgvDmSO.ReadOnly = true;
			dgvDmSO.Dock = DockStyle.Fill;
			dgvDmSO.strZone = (string)drDmCt["Zone_EditCt3"];
			dgvDmSO.BuildGridView(false);

			this.rsSplitContainer1.Panel1.Controls.Add(dgvViewPh);
			this.pageCTSO.Controls.Add(dgvViewCt);
			this.pageCTDMSO.Controls.Add(dgvDmSO);
		

			dgvViewPh.TabIndex = 0;
			dgvViewCt.TabIndex = 1;
			dgvResource.TabIndex = 2;
			dgvDmSO.TabIndex = 3;

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

			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
			string strReport_File = (string)drDmCt["Report_File"];

			if (strMa_Ct == "DNX")
			{
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;

				//DataTable dtHeader = new DataTable();
				//dtHeader.Columns.Add("REPORTTAG", typeof(string));
				//dtHeader.Rows.Add("HDTIN");

				//DataRow drHeader = dtHeader.Rows[0];

                frmIn_Ct_DNX frm1 = new frmIn_Ct_DNX();
				frm1.Load(drCurrent);

				strReport_File = strReport_File + (frm1.rdbPhieu_Xuat.Checked ? "DNX" : "BBM");
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

			//if (this.strMa_Ct_List != "SO")
			//{
			//    dgvViewCt.Location = new Point(dgvViewPh.Left, dgvViewPh.Bottom);
			//    dgvViewCt.Width = this.Width - 12;
			//    dgvViewCt.Height = this.Height - dgvViewPh.Height - pnlTTien.Height - 49;

			//    btUploadFile.Visible = false;
			//    btRemoveFile.Visible = false;
			//    btDownloadFile.Visible = false;
			//}
			//else
			//{
			//    dgvViewCt.Location = new Point(dgvViewPh.Left, dgvViewPh.Bottom);
			//    dgvViewCt.Width = this.Width - 260;
			//    dgvViewCt.Height = this.Height - dgvViewPh.Height - pnlTTien.Height - 49;

			//    dgvResource.Location = new Point(dgvViewCt.Right, dgvViewPh.Bottom);
			//    dgvResource.Width = this.Width - dgvViewCt.Width - 12;
			//    dgvResource.Height = this.Height - dgvViewPh.Height - pnlTTien.Height - 49;

			//    btUploadFile.Location = new Point(dgvResource.Left, dgvResource.Bottom - btUploadFile.Height);
			//    btRemoveFile.Location = new Point(btUploadFile.Right, dgvResource.Bottom - btUploadFile.Height);
			//    btDownloadFile.Location = new Point(btRemoveFile.Right, dgvResource.Bottom - btUploadFile.Height);
			//}
			//dgvViewPh.ResizeGridView();
			//dgvViewCt.ResizeGridView();
			
			
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
            DataRow dr = DataTool.SQLGetDataRowByID("R80PH", "STT", strStt);

            if ((bool)dr["Duyet_TP"])
            {
                Common.MsgCancel("Chứng từ đã được duyệt, không thể xóa !");
                return;
            }

            if(DataTool.SQLCheckExist("R80PH_BARCODEPT","Stt_Org", strStt))
            {
                Common.MsgCancel("Chứng từ đã được xuất barcode, không thể xóa !");
                return;
            }

			if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
				return;

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

			string strMa_Ct = ((string)drCurrent["Ma_Ct"]).Trim();

			if (Voucher.SQLDeleteCt(strStt, strMa_Ct))
			{
				bdsViewPh.RemoveAt(bdsViewPh.Position);
				dtViewPh.AcceptChanges();

				if (strMa_Ct == "DNX")
					SQLExec.Execute("DELETE FROM R05CTNXVTRI WHERE Stt = '" + strStt + "'");
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

			dtDmSO = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Ten_Vt FROM R05CTNXVTRI T1 JOIN R81DMVT T2 ON T1.Ma_Vt = T2.Ma_Vt WHERE Stt = '" + strStt + "'", CommandType.Text);

            bdsDmSO.DataSource = dtDmSO;
            dgvDmSO.DataSource = bdsDmSO;

            
		}

		void btNew_Click(object sender, EventArgs e)
		{
            if (rsTabControl1.SelectedTab == pageCTDMSO)
                EditCtDmSO(enuEdit.New);
            else
                Edit(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
            if (rsTabControl1.SelectedTab == pageCTDMSO)
                EditCtDmSO(enuEdit.Edit);
            else
                Edit(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
            if (rsTabControl1.SelectedTab == pageCTDMSO)
                DeleteCtDmSO();
            else
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
		}

		void dgvViewPh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			string strColumnName = dgvViewPh.Columns[e.ColumnIndex].Name;
			drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			bool Is_Duyet = false;
			string strStt = (string)drCurrent["Stt"];
            DataRow drPh = DataTool.SQLGetDataRowByID("R80PH", "Stt", (string)drCurrent["Stt"]);
            string strDuyet_Tp_Log = drPh["DUYET_TP_LOG"].ToString();
            string strDuyet_KtCdAt_Log = drPh["DUYET_KTCDAT_LOG"].ToString();
            string strDuyet_KhVt_Log = drPh["DUYET_KHVT_LOG"].ToString();

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
                    if (!bDuyet)
                        bDuyet = Common.CheckPermission("IS_PTP", enuPermission_Type.Allow_Access);
                }

				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;
				string strUser_Group = string.Empty;


				if (strCreate_User != string.Empty)
				{
                    strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
                    strUser_Group = (string)SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetList('" + Element.sysUser_Id + "')") + "";
				}
				if (Common.Inlist(strMa_Ct_List, "DNX,NCTH,PYCPT,PYCCK,PYCTH,BBPT,BBTH,DNX,PONL,POXL") && bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
				{
                    if (!Common.Inlist((string)drCurrent["Ma_Dt"], strUser_Group))
                    {
                        dgvViewPh.Columns["DUYET_TP"].ReadOnly = true;
                    }
					else
					{
						Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_TP FROM R80PH WHERE Stt = '" + strStt + "'"));
						frmDuyetYeuCau frm = new frmDuyetYeuCau();
						frm.Load(drCurrent, Is_Duyet, strColumnName);

						if (frm.Is_Accept)
						{
							dgvViewPh.Columns["DUYET_TP"].ReadOnly = false;
							drCurrent["DUYET_TP"] = frm.chkDuyet.Checked;

							string strSQLExec = string.Empty;
							Hashtable htPara = new Hashtable();
							htPara.Add("DUYET_TP", (bool)drCurrent["DUYET_TP"]);
							htPara.Add("STT", drCurrent["STT"]);
							htPara.Add("DUYET_TP_LOG", Common.GetCurrent_Log());

							strSQLExec = "UPDATE R80PH SET DUYET_TP = @DUYET_TP, DUYET_TP_LOG = @DUYET_TP_LOG  WHERE Stt = @STT";
							SQLExec.Execute(strSQLExec, htPara, CommandType.Text);

						}
					}
				}
				else
				{
					dgvViewPh.Columns["DUYET_TP"].ReadOnly = false;
				}
			}

			
			if (strColumnName == "DUYET_KTCDAT")
			{
                string strSttVtri = string.Empty;
                string strSQL = "SELECT ISNULL(MAX(Stt),'') FROM R05CTNXVTRI WHERE Stt = '" + strStt + "'";
                strSttVtri = (string)SQLExec.ExecuteReturnValue(strSQL);
               
				bool bDuyet = false;

                if (strMa_Ct_List == "DNX")
                {
                    if (SQLExec.ExecuteReturnValue("SELECT MAX(Ma_Nvu) FROM R04CTPO WHERE Stt = '" + @strStt + "'").ToString() == "LVPP")
                        bDuyet = Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access);
                    else
                        bDuyet = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
                }
                else
                {
                    if (!Element.sysIs_Admin)
                        bDuyet = Common.CheckPermission("IS_TP_KTCDAT", enuPermission_Type.Allow_Access);
                }

                if (bDuyet && (strSttVtri == "" || strSttVtri == null) && !(bool)drPh["Duyet_KTCDAT"])
                {
                    Common.MsgCancel("Chứng từ phải được xuất vị trí mới được phép duyệt");
                    return;
                }

				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;

				if (strCreate_User != string.Empty)// && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
				}
				if (Common.Inlist(strMa_Ct_List, "DNX,NCTH,PYCPT,PYCCK,PYCTH,BBPT,BBTH,PONL,POXL,POCG") && bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
				{
					if (Convert.ToBoolean(drCurrent["DUYET_KTCDAT"]) && strDuyet_KtCdAt_Log.Substring(14) != Element.sysUser_Id)
					{
						dgvViewPh.Columns["DUYET_KTCDAT"].ReadOnly = true;
					}
					else
					{
						if (Common.InlistLike(strMa_Ct_List, "PYCCK"))
						{
							if (!(bool)(drCurrent["DUYET_TP"]))
								return;

						}
						

						Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_KTCDAT FROM R80PH WHERE Stt = '" + strStt + "'"));
						frmDuyetYeuCau frm = new frmDuyetYeuCau();
                        frm.Load(drCurrent, Is_Duyet, strColumnName);

						if (frm.Is_Accept)
						{

							dgvViewPh.Columns["DUYET_KTCDAT"].ReadOnly = false;
							drCurrent["DUYET_KTCDAT"] = frm.chkDuyet.Checked;

							string strSQLExec = string.Empty;
							Hashtable htPara = new Hashtable();
							htPara.Add("DUYET_KTCDAT", (bool)drCurrent["DUYET_KTCDAT"]);
							htPara.Add("STT", drCurrent["STT"]);
							htPara.Add("DUYET_KTCDAT_LOG", Common.GetCurrent_Log());

							strSQLExec = "UPDATE R80PH SET DUYET_KTCDAT = @DUYET_KTCDAT, DUYET_KTCDAT_LOG = @DUYET_KTCDAT_LOG WHERE STT = @STT";
							SQLExec.Execute(strSQLExec, htPara, CommandType.Text);

						}
					}
				}
				else
				{
					dgvViewPh.Columns["DUYET_KTCDAT"].ReadOnly = false;
				}
			}

			if (strColumnName == "DUYET_KHVT")
			{
				bool bDuyet = false;

				if (!Element.sysIs_Admin)
					bDuyet = Common.CheckPermission("IS_DUYET_DNX", enuPermission_Type.Allow_Access);

				string strCreate_User = (string)drCurrent["Create_Log"];
				string strUser_Allow = string.Empty;

				if (strCreate_User != string.Empty) //&& strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";
				}
				if (Common.Inlist(strMa_Ct_List, "DT,DTVPP,DNX,NCTH,PYCPT,PYCCK,PYCTH,BBPT,BBTH,PONL,POXL") && bDuyet && (strUser_Allow.Contains("*,") || strUser_Allow.Contains(strCreate_User.Substring(14) + ",")))
				{
					if (Convert.ToBoolean(drCurrent["DUYET_KHVT"]) && strDuyet_KhVt_Log.Substring(14) != Element.sysUser_Id)
					{
						dgvViewPh.Columns["DUYET_KHVT"].ReadOnly = true;
					}
					else
					{
						if (!Common.Inlist(strMa_Ct_List, "DT,DTVPP,BBPT,BBTH"))
						{
							if (!(bool)(drCurrent["DUYET_TP"]))
								return;
							if (!(bool)(drCurrent["DUYET_KTCDAT"]))
								return;
						}

						Is_Duyet = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT DUYET_KHVT FROM R80PH WHERE Stt = '" + strStt + "'"));
						frmDuyetYeuCau frm = new frmDuyetYeuCau();
                        frm.Load(drCurrent, Is_Duyet, strColumnName);

						if (frm.Is_Accept)
						{

							dgvViewPh.Columns["DUYET_KHVT"].ReadOnly = false;
							drCurrent["DUYET_KHVT"] = frm.chkDuyet.Checked;

							string strSQLExec = string.Empty;
							Hashtable htPara = new Hashtable();
							htPara.Add("DUYET_KHVT", (bool)drCurrent["DUYET_KHVT"]);
							htPara.Add("STT", drCurrent["STT"]);
							htPara.Add("DUYET_KHVT_LOG", Common.GetCurrent_Log());

							strSQLExec = "UPDATE R80PH SET DUYET_KHVT = @DUYET_KHVT, DUYET_KHVT_LOG = @DUYET_KHVT_LOG WHERE Stt = @STT";
							SQLExec.Execute(strSQLExec, htPara, CommandType.Text);


						}
					}
				}
				else
				{
					dgvViewPh.Columns["DUYET_KHVT"].ReadOnly = false;
				}
			}
			if (strColumnName == "DUYET")
			{
				frmDuyet frm = new frmDuyet();
				frm.Load(drCurrent);
			}
		}

		#endregion

        


	}
}
