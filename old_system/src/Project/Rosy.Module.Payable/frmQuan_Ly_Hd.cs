using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Element;
using RosySystem.Public;
using System.IO;

namespace RosyModule.Payable
{
	public partial class frmQuan_Ly_Hd : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		object objActive = null;

		private DataTable dtDmHd;
		private DataTable dtCtDh;
        private DataTable dtCtTu;
        private DataTable dtCtNk;
        private DataTable dtCtDnTt;
        private DataTable dtCtUNC;
        private DataTable dtResource;
        string strReportFile = "";// "rptCT_DNTU";

		private BindingSource bdsDmHd = new BindingSource();
		private BindingSource bdsCtDh = new BindingSource();
        private BindingSource bdsCtTu = new BindingSource();
        private BindingSource bdsCtNk = new BindingSource();
        private BindingSource bdsCtDnTt = new BindingSource();
        private BindingSource bdsCtUNC = new BindingSource();
        private BindingSource bdsResource = new BindingSource();
        
        private DataRow drResource;
		private DataRow drCurrent;
        public string strLoai_Hd;
        object objFileContent = null;
        private DateTime dteNgay_Ct1;
        private DateTime dteNgay_Ct2;
		#endregion

		#region Contructor

		public frmQuan_Ly_Hd()
		{
			InitializeComponent();

			
			bdsDmHd.PositionChanged += new EventHandler(bdsDmHd_PositionChanged);
			this.KeyDown += new KeyEventHandler(frmCtTs_KeyDown);
            dgvDmHd.Enter += new EventHandler(dgvDmHd_Enter);
            //dgvCtTu.Enter += new EventHandler(dgvCtTu_Enter);

            dgvDmHd.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvDmHd_CellMouseClick);
			
			this.btFilter.Click += new EventHandler(btFilter_Click);
            this.btNew.Click += new EventHandler(btNew_Click);
            this.btEdit.Click += new EventHandler(btEdit_Click);
            //this.btDelete.Click += new EventHandler(btDelete_Click);
            //this.btPrint.Click += new EventHandler(btPrint_Click);
            btDnTt.Click += new EventHandler(btDnTt_Click);

            this.btUpload.Click += new EventHandler(btUpload_Click);
            this.btDownload.Click += new EventHandler(btDownload_Click);
            this.btRemove.Click += new EventHandler(btRemove_Click);
            btAdd.Click += new EventHandler(btAdd_Click);
		}

       

        public void Load(string strLoai_Hd)
		{
            this.strLoai_Hd = strLoai_Hd;
			this.Build();

			//FillData
            object objNgay_CtMax = Element.sysNgay_Ct2;
            int iInterval = Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER"));

            dteNgay_Ct2 = objNgay_CtMax != DBNull.Value ? (DateTime)objNgay_CtMax : DateTime.Now;
            dteNgay_Ct1 = dteNgay_Ct2.Subtract(new TimeSpan(iInterval, 0, 0, 0));

            

			DataTable dtFilter = new DataTable();
            dtFilter.Columns.Add(new DataColumn("Loai_Hd", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();
			
			drFilter["Ngay_Ct1"] = dteNgay_Ct1;
			drFilter["Ngay_Ct2"] = dteNgay_Ct2;

			this.FillData(drFilter);

			this.BindingLanguage();

			this.Show();
		}

		#endregion

		#region Method

		private void Build()
		{
            if(strLoai_Hd == "PO")
                dgvDmHd.strZone = "DMPO"; 
            else
                dgvDmHd.strZone = "DMHD_ADDDT"; 

			dgvDmHd.BuildGridView();

			dgvCtDh.strZone = "DT_VIEWCT"; //chi tiết VT
			dgvCtDh.BuildGridView();

            //dgvCtTu.strZone = "DT_DNTU"; //tạm ứng
            //dgvCtTu.BuildGridView();

            dgvCtNk.strZone = "DT_NK"; //NHẬP KHO
            dgvCtNk.BuildGridView();

            dgvCtDnTt.strZone = "DT_DNTT"; //DNTT
            dgvCtDnTt.BuildGridView();

            dgvCtUNC.strZone = "DT_UNC"; //UNC
            dgvCtUNC.BuildGridView();
           
            dgvResource.strZone = "DT_RESOURCE"; //RESOURCE
            dgvResource.BuildGridView();

            if (strLoai_Hd == "B")
            {
                if (dgvCtDh.Columns.Contains("So_Luong0"))
                    dgvCtDh.Columns["So_Luong0"].Visible = false;
                if (dgvCtDh.Columns.Contains("Mo_Ta_Kt"))
                    dgvCtDh.Columns["Mo_Ta_Kt"].Visible = false;
                if (dgvCtDh.Columns.Contains("Xuat_Xu"))
                    dgvCtDh.Columns["Xuat_Xu"].Visible = false;
               
            }
            if (strLoai_Hd == "PO")
            {
                //rsTabControl1.TabPages.Remove(tpCtTu);
            }

            if (dgvCtDnTt.Columns.Contains("Ngay_Ky"))
                dgvCtDnTt.Columns["Ngay_Ky"].HeaderText = "Ngày nhận HS của NCC";

            if (!Element.sysIs_Admin)
                btAdd.Visible = false;
		}

		private void FillData(DataRow drFilter)
		{
           

			drFilter["Ma_DvCs"] = Element.sysMa_DvCs;
            drFilter["Loai_Hd"] = strLoai_Hd;

			DataSet dsCtTs = SQLExec.ExecuteReturnDs("sp_GetHdFilter", drFilter, CommandType.StoredProcedure);

			dtDmHd = dsCtTs.Tables[0];
			bdsDmHd.DataSource = dtDmHd;
			dgvDmHd.DataSource = bdsDmHd;

			dtCtDh = dsCtTs.Tables[1];
			bdsCtDh.DataSource = dtCtDh;
			dgvCtDh.DataSource = bdsCtDh;

            dtCtTu = dsCtTs.Tables[2];
            bdsCtTu.DataSource = dtCtTu;
            //dgvCtTu.DataSource = bdsCtTu;

            dtCtNk = dsCtTs.Tables[3];
            bdsCtNk.DataSource = dtCtNk;
            dgvCtNk.DataSource = bdsCtNk;

            dtCtDnTt = dsCtTs.Tables[4];
            bdsCtDnTt.DataSource = dtCtDnTt;
            dgvCtDnTt.DataSource = bdsCtDnTt;

            dtCtUNC = dsCtTs.Tables[5];
            bdsCtUNC.DataSource = dtCtUNC;
            dgvCtUNC.DataSource = bdsCtUNC;
                      
            dtResource = dsCtTs.Tables[6];
            bdsResource.DataSource = dtResource;
            dgvResource.DataSource = bdsResource;
            

			bdsSearch = bdsDmHd;
		}

		private void Filter()
		{
			DataTable dtFilter = new DataTable();
			dtFilter.Columns.Add(new DataColumn("NGAY_CT1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("NGAY_CT2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("MA_DVCS", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("So_Ct1", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("So_Ct2", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_Hd", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Loai_Hd", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();
			drFilter["Ngay_Ct1"] = dteNgay_Ct1;
            drFilter["Ngay_Ct2"] = dteNgay_Ct2;

			frmFilter_QLHD frm = new frmFilter_QLHD();


			frm.Load(drFilter);

			if (frm.isAccept)
			{
				this.FillData(drFilter);
			}
		}
		void btFilter_Click(object sender, EventArgs e)
		{
            Filter();
            
		}
        void btDnTt_Click(object sender, EventArgs e)
        {
            frmDNX_View frm = new frmDNX_View();
            frm.Load("DNTT");
        }
        //void btPrint_Click(object sender, EventArgs e)
        //{
        //    drCurrent = ((DataRowView)bdsCtTu.Current).Row;
        //    if (drCurrent["Stt"] != null)
        //        Voucher.Print_DnTu(drCurrent["Stt"].ToString(), true, strReportFile);
        //    else
        //        Common.MsgOk("Chưa có chứng từ DN tạm ứng để in!!!");
        //}
        //void btDelete_Click(object sender, EventArgs e)
        //{
        //    if (this.objActive == dgvCtTu)
        //        Delete_CtDnTu();
        //}

        void btEdit_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvDmHd)
                Edit_DmHd(enuEdit.Edit);
            //else if (this.objActive == dgvCtTu)
            //    Edit_DnTu(enuEdit.Edit);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            if (this.objActive == dgvDmHd)
                Edit_DmHd(enuEdit.New);
            //else if (this.objActive == dgvCtTu)
            //    Edit_DnTu(enuEdit.New);
        }
        void btAdd_Click(object sender, EventArgs e)
        {
            if (bdsDmHd.Position < 0)
                return;

            string strMa_Hd = string.Empty;
            string strStt = string.Empty;
            string strPath = string.Empty;
            string strLoai = string.Empty;
            //Xác định đường dẫn tại server
            strPath = Parameters.GetParaValue("PATH_QLHD").ToString();
            //Xác định loại HD
            if (drCurrent["Loai_Hd"].ToString() == "1")
                strLoai = "1.HDmua_kheuoc";
            else if (drCurrent["Loai_Hd"].ToString() == "2")
                strLoai = "2.HDban_chovay";
            else if (drCurrent["Loai_Hd"].ToString() == "3")
                strLoai = "3.HDdichvu";
            strPath = Path.Combine(strPath, strLoai);

            foreach (DataRow dr in dtResource.Select("File_Path LIKE 'D%'"))
            {
               
                //Xác định năm ký HD
                strPath = Path.Combine(strPath, Convert.ToDateTime(drCurrent["Ngay_Ky"]).Year.ToString());
                // tạo thư mục chứa các file của HD
                strPath = Path.Combine(strPath, drCurrent["Ma_Hd"].ToString().Substring(0, drCurrent["Ma_Hd"].ToString().LastIndexOf("/H")));
                //Kiểm tra Path có tồn tại hay chưa, tạo thư mục chứa các file
                if (!Directory.Exists(strPath))
                    System.IO.Directory.CreateDirectory(strPath);

                //copy file lên server
                var fileName = Path.GetFileName(dr["File_Path"].ToString());// fileDialog.FileName;
                //nếu ko tồn tại thì ko copy
                if (!File.Exists(Path.Combine(strPath, fileName)))
                    File.Copy(dr["File_Path"].ToString(), Path.Combine(strPath, fileName));

                //Lưu đường dẫn file cần copy
                dr["File_Path"] = Path.Combine(strPath, fileName);
                dr["Create_Log"] = Common.GetCurrent_Log();

                string strSQL = "UPDATE R04PO_RESOURCE SET  File_Path = '" + dr["File_Path"] + "', Create_Log = '" + dr["Create_Log"] + "' WHERE Ma_Hd = '" + dr["Ma_Hd"] + "'";

                SQLExec.Execute(strSQL);
             
            }
          
        }
        void btUpload_Click(object sender, EventArgs e)
        {
            EditResource(enuEdit.New);
        }
        void btRemove_Click(object sender, EventArgs e)
        {
            DeleteResource();
        }

        void btDownload_Click(object sender, EventArgs e)
        {
            if (bdsResource.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsResource.Current).Row;
            object objFile = (object)drCurrent["File_Path"];
            string strPath = (string)drCurrent["File_Path"];       
            
            //if (!Directory.Exists(strPath))
            //    Directory.CreateDirectory(strPath);

            if (objFile != null && objFile != DBNull.Value)// && ((Byte[])objFile).Length > 0)
            {
                FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);
                //fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);
                fileStream.Close();
                System.Diagnostics.Process.Start(strPath);
            }
        }
		#endregion

		#region Update
        void EditResource(enuEdit enuNew_Edit)
        {
            if (bdsDmHd.Position < 0)
                return;

            if (bdsResource.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drCurrent = ((DataRowView)bdsDmHd.Current).Row;

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
            
            string strMa_Hd = string.Empty;
            string strStt = string.Empty;
            string strPath = string.Empty;
            string strLoai = string.Empty;
            //Xác định đường dẫn tại server
            strPath = Parameters.GetParaValue("PATH_QLHD").ToString();
            //Xác định loại HD
            if (drCurrent["Loai_Hd"].ToString() == "1")
                strLoai = "1.HDmua_kheuoc";
            else if (drCurrent["Loai_Hd"].ToString() == "2")
                strLoai = "2.HDban_chovay";
            else if (drCurrent["Loai_Hd"].ToString() == "3")
                strLoai = "3.HDdichvu";
            strPath = Path.Combine(strPath, strLoai);
            //Xác định năm ký HD
            strPath = Path.Combine(strPath, Convert.ToDateTime(drCurrent["Ngay_Ky"]).Year.ToString());
            // tạo thư mục chứa các file của HD
            strPath = Path.Combine(strPath, drCurrent["Ma_Hd"].ToString().Substring(0, drCurrent["Ma_Hd"].ToString().LastIndexOf("/H")));
            //Kiểm tra Path có tồn tại hay chưa, tạo thư mục chứa các file
            if (!Directory.Exists(strPath))
                System.IO.Directory.CreateDirectory(strPath);

            if(strLoai_Hd == "M")
               drResource["Ma_Hd"] = drCurrent["Ma_Hd"].ToString();
            else if (strLoai_Hd == "PO")
                drResource["Stt"] = drCurrent["Stt"].ToString();

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;
            fileDialog.Filter = "All files (*.*)|*.*";
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            //copy file lên server
            var fileName = fileDialog.FileName;
            //nếu ko tồn tại thì ko copy
            if (!File.Exists(Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName)))
                File.Copy(fileName, Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName));
            
            
            //Lưu đường dẫn file cần copy
            drResource["File_Path"] = Path.Combine(strPath, Path.GetFileNameWithoutExtension(fileName)) + Path.GetExtension(fileDialog.FileName);
            drResource["Create_Log"] = Common.GetCurrent_Log();

            // Kiểm tra trùng tên file va Stt

            if (!DataTool.SQLCheckExist("R04PO_RESOURCE", new string[] { "File_Path", "Ma_Hd", "Stt" }, new object[] { drResource["File_Path"].ToString(), drResource["Ma_Hd"].ToString(), drResource["Ma_Hd"].ToString()}))
            {
                //Luu vao CSDL
                DataTool.SQLUpdate(enuNew_Edit, "R04PO_RESOURCE", ref drResource);
            
            }
            else
            {
                Common.MsgOk("Đường dẫn " + (string)drResource["File_Path"] + " đã tồn tại. Yêu cầu kiểm tra lại!!!");
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

            drCurrent = ((DataRowView)bdsDmHd.Current).Row;
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

            try
            {
                File.Delete(drResource["File_Path"].ToString());
                if (DataTool.SQLDelete("R04PO_RESOURCE", drResource))
                {

                    bdsResource.RemoveAt(bdsResource.Position);
                    dtResource.AcceptChanges();
                }
            }
            catch
            {
                MessageBox.Show("File đang được dùng hoặc bạn không có quyền xóa!!! Vui lòng liên hệ PCNTT để kiểm tra !");
            }
            
        }
        private void Edit_DmHd(enuEdit enuNew_Edit)
        {
            if (bdsDmHd.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsDmHd.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDmHd.Current).Row, ref drCurrent);
            else
            {
                drCurrent = dtDmHd.NewRow();
               
            }

            RosyList.frmDmHd_Edit frmEdit = new RosyList.frmDmHd_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                    if (bdsDmHd.Position >= 0)
                        dtDmHd.ImportRow(drCurrent);
                    else
                        dtDmHd.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmHd.Current).Row);
                }

                dtDmHd.AcceptChanges();
            }
            else
		        dtDmHd.RejectChanges();
        }

        private void Edit_DnTu(enuEdit enuNew_Edit)
        {
            if (bdsCtTu.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsCtTu.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsCtTu.Current).Row, ref drCurrent);
            else
            {
                drCurrent = dtCtTu.NewRow();

            }
            DataRow drDmHd_Dt = ((DataRowView)bdsDmHd.Current).Row;
            frmDnTu_Edit frmEdit = new frmDnTu_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, drDmHd_Dt["Ma_Hd"].ToString());

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                    if (bdsCtTu.Position >= 0)
                        dtCtTu.ImportRow(drCurrent);
                    else
                        dtCtTu.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtTu.Current).Row);
                }

                dtCtTu.AcceptChanges();
            }
            else
                dtCtTu.RejectChanges();
        }
        private void Design()
        {
            RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
            frm.Load(strReportFile);
        }
	

		

		//public override void Delete()
		//{
		//    if (this.objActive == dgvCtDt)
		//        this.Delete_CtTsHM();
		//    else if (this.objActive == dgvCtTsTT)
		//        this.Delete_CtTsTT();
		//    else if (this.objActive == dgvCtTsDC)
		//        this.Delete_CtTsDC();
		//    else
		//        this.Delete_CtTs();
		//}



        private void Delete_CtDnTu()
        {
            if (bdsCtTu.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsCtTu.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R04CTDNTU", drCurrent))
            {
                bdsCtTu.RemoveAt(bdsCtTu.Position);
                dtCtTu.AcceptChanges();
            }
        }

		//private void Delete_CtTsTT()
		//{
		//    if (bdsDmHdTT.Position < 0)
		//        return;

		//    DataRow drCurrent = ((DataRowView)bdsDmHdTT.Current).Row;

		//    if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
		//        return;

		//    if (DataTool.SQLDelete("R06CTTSTT", drCurrent))
		//    {
		//        bdsDmHdTT.RemoveAt(bdsDmHdTT.Position);
		//        dtDmHdTT.AcceptChanges();
		//    }
		//}

		//private void Delete_CtTsDC()
		//{
		//    if (bdsDmHdDC.Position < 0)
		//        return;

		//    DataRow drCurrent = ((DataRowView)bdsDmHdDC.Current).Row;

		//    if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
		//        return;

		//    if (DataTool.SQLDelete("R06CTTSDC", drCurrent))
		//    {
		//        bdsDmHdDC.RemoveAt(bdsDmHdDC.Position);
		//        dtDmHdDC.AcceptChanges();
		//    }
		//}

		#endregion

		#region Su kien
        void dgvDmHd_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvDmHd;
        }
        void dgvCtTu_Enter(object sender, EventArgs e)
        {
            //ExportControl = sender;
            //objActive = dgvCtTu;
        }
		void bdsDmHd_PositionChanged(object sender, EventArgs e)
		{
			if (bdsDmHd.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmHd.Current).Row;
            if (strLoai_Hd != "PO")
            {
                bdsCtDh.Filter = "Ma_Hd = '" + drCurrent["Ma_Hd"].ToString() + "'";
                bdsCtTu.Filter = "Ma_Hd = '" + drCurrent["Ma_Hd"].ToString() + "'";
                bdsCtNk.Filter = "Ma_Hd = '" + drCurrent["Ma_Hd"].ToString() + "'";
                bdsCtDnTt.Filter = "Ma_Hd = '" + drCurrent["Ma_Hd"].ToString() + "'";
                bdsCtUNC.Filter = "Ma_Hd = '" + drCurrent["Ma_Hd"].ToString() + "'";
                bdsResource.Filter = "Ma_Hd = '" + drCurrent["Ma_Hd"].ToString() + "'";
            }
            else
            {
                bdsCtDh.Filter = "Stt = '" + drCurrent["Stt"].ToString() + "'";
              
                bdsCtNk.Filter = "Stt = '" + drCurrent["Stt_NK"].ToString() + "'";
                bdsCtDnTt.Filter = "Stt = '" + drCurrent["Stt_DnTt"].ToString() + "'";
                bdsCtUNC.Filter = "Stt = '" + drCurrent["Stt_UNC"].ToString() + "'";
                bdsResource.Filter = "Stt = '" + drCurrent["Stt"].ToString() + "'";
            }
		}
        void dgvDmHd_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsDmHd.Current).Row;
            DataGridViewCell dgvCell = dgvDmHd.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "ADD_DT")
            {
                frmAdd_HD_DT frm = new frmAdd_HD_DT();
                frm.Load(drCurrent["Ma_Dt"].ToString(), drCurrent["Ma_Hd"].ToString());

                if (frm.Is_Accept)
                    Load(strLoai_Hd);
            }
        }
		void frmCtTs_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F9 && !e.Control && !e.Shift && !e.Alt)
				this.Filter();
		}

		#endregion
	}
}