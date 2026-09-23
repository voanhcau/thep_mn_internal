using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Public;
using RosySystem.Common;
using System.IO;
using RosySystem.Customize;
using System.Data.SqlClient;

namespace RosyModule.Payable
{
	public partial class frmCtPO_PT_Edit : frmVoucher_Edit
	{
        private string strModule = "07";//"04";
		private bool bMa_Vt_Changed = false;
		private bool bMa_Thue_Changed = false;
        
		object objFile = null;
		string strFile_Tag = string.Empty;

        private frmCheckDinhMucBHLD frmCheckDinhMucBHLD;

        DataTable dtEditVTri;
        DataRow drEditVTri;
        BindingSource bdsEditVTri = new BindingSource();

        DataTable dtEditResource;
        DataRow drEditResource;
        BindingSource bdsEditResource = new BindingSource();
        DataTable dtCheckVTPTTD = new DataTable();
        bool bTb = false;
       
        string strMa_Tb;
        
		#region Contructor

		public frmCtPO_PT_Edit()
		{
			InitializeComponent();
			this.FormClosing += new FormClosingEventHandler(frmCtPO_PT_Edit_FormClosing);
			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

			this.btImportExcel.Click += new EventHandler(btnImportExcel_Click);
			this.btInherit.Click += new EventHandler(btInherit_Click);
            this.btUpdate_ThongTin.Click += new EventHandler(btUpdate_ThongTin_Click);
            //this.btCheck_Xuat.Click += new EventHandler(btCheck_Xuat_Click);
            this.btYC_TieuHao.Click += new EventHandler(btYC_TieuHao_Click);
            btInheritTB.Click += new EventHandler(btInheritTB_Click);
            btCheckVTPTTD.Click += new EventHandler(btCheckVTPTTD_Click);

			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);	
			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
			txtMa_Dt_CbNv_Mh.Validating += new CancelEventHandler(txtMa_Kv_Validating);
			txtGD_Duyet.Validating += new CancelEventHandler(txtGD_Duyet_Validating);
			txtTen_Dt_NCC2.Validating += new CancelEventHandler(txtMa_Dt_NCC2_Validating);
			txtTen_Dt_NCC3.Validating += new CancelEventHandler(txtMa_Dt_NCC3_Validating);

			dteNgay_DkGH.Leave += new EventHandler(dteNgay_DkGH_TextChanged);
			txtMa_Tte.Leave += new EventHandler(txtMa_Tte_Leave);
           
			numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);
            dteNgay_Ct.Leave += DteNgay_Ct_Leave;
			txtMa_Thue.Validating += new CancelEventHandler(txtMa_Thue_Validating);
			
			numTTien.Validated += new EventHandler(numTTien_Validated);
			numTTien_Nt.Validated += new EventHandler(numTTien_Nt_Validated);
			numTTien3.Validated += new EventHandler(numTTien3_Validated);
			numTTien_Nt3.Validated += new EventHandler(numTTien_Nt3_Validated);
        
			dgvEditCt1.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt1.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			dgvEditCt1.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
			dgvEditCt1.CellValueChanged += new DataGridViewCellEventHandler(dgvEditCt1_CellValueChanged);
			dgvEditCt1.KeyDown += new KeyEventHandler(dgvEditCt_KeyDown);
       
			dgvEditCt1.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvEditCt1_CellMouseClick);
			dgvEditCt1.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvEditCt1_CellMouseDoubleClick);

			dgvEditCt2.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
			dgvEditCt2.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
			dgvEditCt2.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);
			dgvEditCt2.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvEditCt2_CellMouseClick);

            dgvEditCt3.CellValidating += new DataGridViewCellValidatingEventHandler(dgvEditCt_CellValidating);
            dgvEditCt3.CellValidated += new DataGridViewCellEventHandler(dgvEditCt_CellValidated);
            dgvEditCt3.CellEnter += new DataGridViewCellEventHandler(dgvEditCt_CellEnter);

            
		}

       

        public override void Load(enuEdit enuNew_Edit, DataRow drEdit, DataSet dsVoucher)
		{
			this.drEdit = drEdit;
			this.dsVoucher = dsVoucher;

			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			this.strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();
			this.drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", this.strMa_Ct);
			this.Object_ID = strMa_Ct;

			if (enuNew_Edit == enuEdit.New)
				this.strStt = Common.GetNewStt(strModule, true);
			else
				this.strStt = drEdit["Stt"].ToString();
            
           

			this.Build();
			this.FillData();
			this.Init_Ct();
			this.LoadFileNameAttachFile();
			Common.ScaterMemvar(this, ref drEditPh);

			this.Ma_Tte_Valid();
			this.BindingLanguage();
			this.LoadDicName();

			if (!this.Visible)
				this.ShowDialog();
			else
			{
				this.ActiveControl = txtMa_Nvu;
				this.dgvEditCt1.ClearSelection();
			}
		}

        public override void Load_Tb(enuEdit enuNew_Edit, DataRow drEdit, DataSet dsVoucher)
        {
            this.drEdit = drEdit;
            this.dsVoucher = dsVoucher;
            this.bTb = true;
            this.enuNew_Edit = enuNew_Edit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

            this.strMa_Ct = ((string)drEdit["Ma_Ct"]).Trim();
            this.drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", this.strMa_Ct);
            this.Object_ID = strMa_Ct;

            if (enuNew_Edit == enuEdit.New)
                this.strStt = Common.GetNewStt(strModule, true);
            else
                this.strStt = drEdit["Stt"].ToString();



            this.Build();
            this.FillData();
            this.Init_Ct();
            this.LoadFileNameAttachFile();
            Common.ScaterMemvar(this, ref drEditPh);

            this.Ma_Tte_Valid();
            this.BindingLanguage();
            this.LoadDicName();

            if (!this.Visible)
                this.ShowDialog();
            else
            {
                this.ActiveControl = txtMa_Nvu;
                this.dgvEditCt1.ClearSelection();
            }
        }
		private void LoadFileNameAttachFile()
		{
			object strFile_Name = null;
			string strStt = string.Empty;
			int iStt0 = 0;
			
			foreach (DataGridViewRow dgvRow in dgvEditCt1.Rows)
			{
				strStt = dtEditCt.Rows[dgvRow.Index]["Stt"].ToString();
				iStt0 = Convert.ToInt32(dtEditCt.Rows[dgvRow.Index]["Stt0"].ToString());
				strFile_Name =  SQLExec.ExecuteReturnValue("SELECT ISNULL(File_Name,'') + '.'+ Tag AS File_Name FROM R04CTSO_RESOURCE WHERE Stt = '" + strStt + "' AND Stt0 = " + iStt0);
				
				if (strFile_Name != null && strFile_Name != string.Empty)
					dgvRow.Cells["Open_File"].Value = (object)strFile_Name;
			}
		}

		#endregion

		#region Phuong thuc

		private void Build()
		{
			txtTen_Dt_NCC2.bUseAutoDropDown = true;
			txtTen_Dt_NCC3.bUseAutoDropDown = true;

			dgvEditCt1.bSortMode = false;
			dgvEditCt1.strZone = (string)drDmCt["Zone_EditCt1"];
			dgvEditCt1.BuildGridView();

			dgvEditCt2.bSortMode = false;
			dgvEditCt2.strZone = (string)drDmCt["Zone_EditCt2"];
			dgvEditCt2.BuildGridView();

            dgvEditCt3.bSortMode = false;
            dgvEditCt3.strZone = (string)drDmCt["Zone_EditCt3"];
            dgvEditCt3.BuildGridView();

            if (dgvEditCt1.Columns.Contains("MA_VT"))
            {
                if (strMa_Ct != "DTNA" && Common.Inlist(strMa_Ct,"PYCPT,PYCCK"))
                {
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%'  AND LEN(Ma_Vt) = 9 AND Is_Hide = 0";
                }
                else if (Common.Inlist(strMa_Ct, "DTCP,DTXE"))
                {
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%'";
                }
                else if (strMa_Ct == "DTNA")
                {
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = "Ma_Nh_Vt LIKE 'VTNA%' OR Ma_Vt LIKE 'F%'";
                }
                else if (strMa_Ct == "PYCTH")
                {
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = "Is_TieuHao = 1 AND Is_Hide = 0";
                }
                else
                {
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%'  AND LEN(Ma_Vt) = 9";
                }

            }
			if (dgvEditCt1.Columns.Contains("MA_VT_TT"))
				((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt_Tt"]).bUseAutoDropDown = true;

            if (dgvEditCt1.Columns.Contains("MA_TB"))
            {
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Tb"]).bUseAutoDropDown = true;
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Tb"]).strLookupKeyFilter = "Ngay_Kt_Sd = '19000101'";
            }
            if (dgvEditCt1.Columns.Contains("MA_XE"))
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Xe"]).bUseAutoDropDown = true;

            if (dgvEditCt1.Columns.Contains("MA_VTRI"))
            {
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_VTri"]).bUseAutoDropDown = true;
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_VTri"]).strLookupKeyFilter = "Type = 'VITRI'";
            }
			if (dgvEditCt1.Columns.Contains("Mo_Ta_Kt"))
			{
				dgvEditCt1.Columns["Mo_Ta_Kt"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
				dgvEditCt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			}
            if (dgvEditCt1.Columns.Contains("Mo_Ta_Bs"))
            {
                dgvEditCt1.Columns["Mo_Ta_Bs"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvEditCt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvEditCt1.Columns.Contains("Ten_Vt_Tt"))
            {
                dgvEditCt1.Columns["Ten_Vt_Tt"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvEditCt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
			if (dgvEditCt1.Columns.Contains("Muc_Dich"))
			{
				dgvEditCt1.Columns["Muc_Dich"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
				dgvEditCt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			}
            
			DataGridView_Language();
		}

		private void DataGridView_Language()
		{
            if (Common.InlistLike(strMa_Ct, "DT"))
                lblMa_Dt.Text = "Mã nhà cung cấp";

            if (Common.Inlist(strMa_Ct, "DT,DTVPP"))
			{
				if (dgvEditCt1.Columns.Contains("Ma_Vt"))
					dgvEditCt1.Columns["Ma_Vt"].HeaderText = "Mã vật tư thay thế";
				if (dgvEditCt1.Columns.Contains("Ten_Vt"))
					dgvEditCt1.Columns["Ten_Vt"].HeaderText = "Tên vật tư thay thế";

				if (dgvEditCt1.Columns.Contains("Ten_Vt_Tt"))
					dgvEditCt1.Columns["Ten_Vt_Tt"].HeaderText = "Tên vật tư";

				if (dgvEditCt1.Columns.Contains("Ma_Vt_Tt"))
					dgvEditCt1.Columns["Ma_Vt_Tt"].HeaderText = "Mã vật tư";
			}
			if (dgvEditCt2.Columns.Contains("So_Luong9") && strMa_Ct == "PYCPT")
				dgvEditCt2.Columns["So_Luong9"].HeaderText = "Số duyệt phòng KtCdAt";

			if (dgvEditCt2.Columns.Contains("Ghi_Chu") && strMa_Ct == "PYCCK")
				dgvEditCt2.Columns["Ghi_Chu"].HeaderText = "Ý kiến của PXCD(GC nội bộ hay GC ngoài)";

			if (dgvEditCt1.Columns.Contains("So_Luong9"))
				dgvEditCt1.Columns["So_Luong9"].HeaderText = "Số lượng duyệt";

			if (dgvEditCt2.Columns.Contains("So_Luong9"))
				dgvEditCt2.Columns["So_Luong9"].HeaderText = "Số lượng duyệt";

			if (dgvEditCt1.Columns.Contains("Ngay_Gh") && !strMa_Ct.StartsWith("BB"))
				dgvEditCt1.Columns["Ngay_Gh"].HeaderText = "Ngày yêu cầu giao hàng";
			
			if (dgvEditCt1.Columns.Contains("So_Luong9") && strMa_Ct == "DNX")
				dgvEditCt1.Columns["So_Luong9"].HeaderText = "Số lượng duyệt PKTĐT";

			if (dgvEditCt1.Columns.Contains("So_Luong9") && Common.Inlist(strMa_Ct,"BBPT,BBTH"))
				dgvEditCt1.Columns["So_Luong9"].HeaderText = "Kiểm tra chất lượng";
            
            if (dgvEditCt1.Columns.Contains("Muc_Dich") && Common.Inlist(strMa_Ct, "DTCP,DTXE"))
                dgvEditCt1.Columns["Muc_Dich"].HeaderText = "Nội dung bảo trì sửa chữa";

            if (dgvEditCt3.Columns.Contains("Muc_Dich") && Common.Inlist(strMa_Ct, "DTCP,DTXE"))
                dgvEditCt3.Columns["Muc_Dich"].HeaderText = "Nội dung bảo trì sửa chữa";

            if (dgvEditCt3.Columns.Contains("Ngay_DKGH") && Common.Inlist(strMa_Ct, "DTCP,DTXE"))
                dgvEditCt3.Columns["Ngay_DKGH"].HeaderText = "Ngày giao";
            if (dgvEditCt3.Columns.Contains("Ngay_GH") && Common.Inlist(strMa_Ct, "DTCP,DTXE"))
                dgvEditCt3.Columns["Ngay_GH"].HeaderText = "Ngày nhận";
            if (dgvEditCt3.Columns.Contains("Ngay_Gh_Tt") && Common.Inlist(strMa_Ct, "DTCP,DTXE"))
                dgvEditCt3.Columns["Ngay_Gh_Tt"].HeaderText = "Ngày nghiệm thu";
            //Ma_Dt
            if (Common.InlistLike(strMa_Ct, "PYCPT,PYCTH,PYCCK,DNX") && (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy))
			{
                {
                    drEdit["Ma_Dt"] = (string)SQLExec.ExecuteReturnValue("SELECT MIN(Ma_Dt) FROM R00MEMBERGROUP T1 JOIN (SELECT Ma_Bp, Ma_Dt FROM R81DMDT WHERE Ma_Nh_Dt = '400') T2 " +
						" ON T1.Member_Group_ID = T2.Ma_Bp " +
						"WHERE Member_Id = '" + Element.sysUser_Id + "'");
                   
                    if (drEdit["Ma_Dt"].ToString() != string.Empty || drEdit["Ma_Dt"].ToString() != null || drEdit["Ma_Dt"].ToString() != "")
                        txtMa_Dt.Text = drEdit["Ma_Dt"].ToString();
                    else
                        txtMa_Dt.Text = "";
                }
                
			}
            
			//Ma_Dt_CbNv
            if (Common.InlistLike(strMa_Ct, "PYCPT,PYCCK,DT,DTVPP,DTCP,DTXE,PYCTH,DNX,BBTH,BBPT,PONL") && (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy))
			{
				drEdit["Ma_Dt_CbNv"] = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
				txtMa_Dt_CbNv.Text = drEdit["Ma_Dt_CbNv"].ToString();
                if (txtMa_Dt_CbNv.Text == "M0384")
                     txtMa_Dt.Text = "41PXLUY";
			}
		}
		private void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("TABLE_PH", (string)drDmCt["Table_Ph"]);
			htPara.Add("TABLE_CT", (string)drDmCt["Table_Ct"]);
			htPara.Add("STT", ((string)drEdit["Stt"]).Trim());
			htPara.Add("USER_LOGIN", Element.sysUser_Id);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			DataSet dsVoucher;

            if (Common.Inlist(strMa_Ct, "DT"))
                dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_DT", htPara, CommandType.StoredProcedure);
            else
                dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_PYC", htPara, CommandType.StoredProcedure);
               
            

			dtEditPh = dsVoucher.Tables[0];
			dtEditCt = dsVoucher.Tables[1];
            dtEditResource = dsVoucher.Tables[2];
            dtEditVTri = dsVoucher.Tables[3];


            if (enuNew_Edit == enuEdit.New)
            {
                dtEditCt.Clear();
                //dtEditVTri.Clear();
            }
            else if (enuNew_Edit == enuEdit.Edit)
                dtEditCt.DefaultView.Sort = "Stt0";

			DataColumn dc = new DataColumn("Deleted", typeof(bool));
			dc.DefaultValue = false;
			dtEditCt.Columns.Add(dc);

			if (!dtEditCt.Columns.Contains("Open_File"))
			{
				dc = new DataColumn("Open_File", typeof(string));
				dc.DefaultValue = string.Empty;
				dtEditCt.Columns.Add(dc);
			}

            //DataColumn dc1 = new DataColumn("Stt_Org", typeof(string));
            //dc1.DefaultValue = false;
            //dtEditVTri.Columns.Add(dc1);
            
			bdsEditCt.DataSource = dtEditCt;
            
            //bdsEditVTri.DataSource = dtEditVTri;

			dgvEditCt1.DataSource = bdsEditCt;
			dgvEditCt1.ClearSelection();

			dgvEditCt2.DataSource = bdsEditCt;
			dgvEditCt2.ClearSelection();

            dgvEditCt3.DataSource = bdsEditCt;
            dgvEditCt3.ClearSelection();

			if (Voucher.Access_Price_Xuat(dtEditCt, strMa_Ct, dgvEditCt1))
			{
				numTTien0.Visible = false;
				numTTien_Nt0.Visible = false;

				numTTien3.Visible = false;
				numTTien_Nt3.Visible = false;

				numTTien.Visible = false;
				numTTien_Nt.Visible = false;
			}
		}

		private void Init_Ct()
		{
			txtMa_Tte.InputMask = (string)RosySystem.Library.Parameters.GetParaValue("MA_TTE_LIST");


			if (dtEditPh.Rows.Count == 0)
			{
				DataRow drNew = dtEditPh.NewRow();
				Common.SetDefaultDataRow(ref drNew);

				dtEditPh.Rows.Add(drNew);
			}

			if (dtEditCt.Rows.Count == 0)
			{
				DataRow drNew = dtEditCt.NewRow();
				Common.SetDefaultDataRow(ref drNew);

				dtEditCt.Rows.Add(drNew);
			}

			if (dtEditResource.Rows.Count == 0)
			{
				DataRow drNew = dtEditResource.NewRow();
				Common.SetDefaultDataRow(ref drNew);

				dtEditResource.Rows.Add(drNew);
			}

			drEditPh = dtEditPh.Rows[0];
			drCurrent = dtEditCt.Rows[0];


			if (this.enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				//Ngầm định 1 số thông tin từ chứng từ cũ
				if (drEdit != null)
					Common.CopyDataRow(drEdit, drCurrent, (string)drDmCt["Carry_Header"]);

				drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;
				drCurrent["Stt"] = strStt;
				drCurrent["Ma_Ct"] = strMa_Ct;
				//drCurrent["Ngay_Ct"] = drEdit["Ngay_Ct"] != DBNull.Value ? drEdit["Ngay_Ct"] : DateTime.Now;
				drCurrent["Ngay_Ct"] = Voucher.GetDate_Server();
				drCurrent["Ma_Tte"] = Element.sysMa_Tte;
				drCurrent["Ty_Gia"] = 1;
				drCurrent["Stt0"] = 1;
				drCurrent["Deleted"] = false;

				if (Common.Inlist(strMa_Ct, "PYCPT,PYCTH"))
					txtDien_Giai.Text = "Mua vật tư phụ tùng";
				else if (strMa_Ct == "PYCCK")
					txtDien_Giai.Text = "Gia công cơ khí";

				//Clear Content in drEditPh
				foreach (DataColumn dcEditPh in dtEditPh.Columns)
					drEditPh[dcEditPh] = DBNull.Value;

				drEditPh["Ma_DvCs"] = drCurrent["Ma_DvCs"];
				drEditPh["Stt"] = drCurrent["Stt"];
				drEditPh["Ma_Ct"] = drCurrent["Ma_Ct"];
				drEditPh["Ngay_Ct"] = drCurrent["Ngay_Ct"];
				drEditPh["So_Ct"] = drCurrent["So_Ct"];

				foreach (DataRow drEditCt in dtEditCt.Rows)
				{
					if (dtEditCt.Columns.Contains("Stt_Org")) //Bỏ các dữ liệu kế thừa
					{
						drEditCt["Stt_Org"] = "";
						drEditCt["Stt0"] = 0;
					}
					drEditCt["Ma_Dt_CbNv_Mh"] = "";
					drEditCt["Ngay_Gh"] = DBNull.Value;
					drEditCt["Ngay_DkGh"] = DBNull.Value;
					drEditCt["Ngay_Gh_Dc1"] = DBNull.Value;
					drEditCt["Ngay_Gh_Dc2"] = DBNull.Value;
				}
				dtEditResource.Clear();
			}

			//Tinh so chung tu TU 1/7
			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				//if (Common.InlistLike(strMa_Ct, "DT,DTVPP,DTCP,PYCPT,PYCCK,PYCTH,NCTH,BBPT,BBTH,DNX,DNTT"))
				drEditPh["So_Ct"] = drCurrent["So_Ct"] = Voucher.Cong_So_Ct_PYC(this);
				//else
				//    drEditPh["So_Ct"] = drCurrent["So_Ct"] = Voucher.Cong_So_Ct(this);

				if (enuNew_Edit == enuEdit.Copy)
				{
					foreach (DataRow drEditCt in dtEditCt.Rows)
					{
						drEditCt["Stt0"] = Common.MaxDCValue(dtEditCt, "Stt0") + 1;
						// Xử lý khi copy phiếu
						drEditCt["Ghi_Chu_Tp"] = "";
						drEditCt["Ghi_Chu_KtCdAt"] = "";
						drEditCt["Ghi_Chu_KhVt"] = "";
						drEditCt["Ghi_Chu_GD"] = "";
					}
				}
			}
			//if (enuNew_Edit == enuEdit.Edit)
			//{
			//	strMa_Nh_Tb = dtEditCt.Rows[0]["Ma_Nh_Tb"].ToString();//drEditCt["Ma_Nh_Tb"].ToString();
			//}
			Voucher.Update_Header(this);
			Voucher.Update_Stt(this, strModule);

			if (dgvEditCt1.Columns.Contains("Dvt"))
			{
				if (!Common.Inlist(strMa_Ct, "DTCP,DTXE"))
					dgvEditCt1.Columns["Dvt"].ReadOnly = true;
			}
			if (dgvEditCt1.Columns.Contains("So_Luong9") && strMa_Ct == "DNX")
            {
				dgvEditCt1.Columns["So_Luong9"].ReadOnly = true;
			}
			if (dgvEditCt1.Columns.Contains("Ma_Vt_Tt") && strMa_Ct == "DT")
            {
                dgvEditCt1.Columns["Ma_Vt_Tt"].ReadOnly = true;
                dgvEditCt1.Columns["Ten_Vt_Tt"].ReadOnly = true;
            }
            if (dgvEditCt1.Columns.Contains("So_Luong_Dm"))
                dgvEditCt1.Columns["So_Luong_Dm"].ReadOnly = true;

            if (dgvEditCt1.Columns.Contains("So_Km_Dau"))
                dgvEditCt1.Columns["So_Km_Dau"].ReadOnly = true;
                        
			if (dgvEditCt1.Columns.Contains("Mo_Ta_Kt"))
				dgvEditCt1.Columns["Mo_Ta_Kt"].ReadOnly = true;
			if (dgvEditCt1.Columns.Contains("Ten_Nha_Sx"))
				dgvEditCt1.Columns["Ten_Nha_Sx"].ReadOnly = true;
			if (dgvEditCt1.Columns.Contains("Ma_Tb_Nha_Sx"))
				dgvEditCt1.Columns["Ma_Tb_Nha_Sx"].ReadOnly = true;
            if (dgvEditCt1.Columns.Contains("Ten_Vt"))
                dgvEditCt1.Columns["Ten_Vt"].ReadOnly = true;
            if (dgvEditCt1.Columns.Contains("Ten_Vt_Tt"))
                dgvEditCt1.Columns["Ten_Vt_Tt"].ReadOnly = true;

			dgvEditCt2.ReadOnly = true;
            if (Common.Inlist(strMa_Ct, "DTCP,DTXE") && (bool)drEditPh["Duyet_Tp"])
            {
                string strCreate_User = (string)drEditPh["Create_Log"];
	
                if (Element.sysIs_Admin || (strCreate_User != string.Empty && strCreate_User.Substring(14) == Element.sysUser_Id))
                    btUpdate_ThongTin.Visible = true;

            }

			if (Common.Inlist(strMa_Ct, "PYCPT,PYCCK,PYCTH,BBPT,DT,DTNA")) //,BBTH,
			{
				
				dteNgay_Ct.ReadOnly = true;
				txtSo_Ct.ReadOnly = true;
				txtMa_Dt_CbNv.ReadOnly = true;
				
			}

			if (Common.Inlist(strMa_Ct, "PYCPT,PYCCK,PYCTH,BBPT,BBTH,DNX,DT"))
			{
				dgvEditCt1.Columns["Ten_Vt"].ReadOnly = true;
                this.tabControl1.TabPages.Remove(tabPage3);
              
			}
           
			txtInherit.Text = Voucher.GetInheritVoucher(this);
			
            if (Common.Inlist(strMa_Ct, "BBPT,BBTH"))
			{
				lblDia_Chi.Visible = false;
				txtDia_Chi.Visible = false;
			}
			
            if (Common.Inlist(strMa_Ct, "PYCPT,PYCCK"))
			{
				lbtGhi_Chu.Visible = true;
				lbtGhi_Chu.Text = " * Các thông tin số lượng lắp đặt mục đích sử dụng cần phải nhập liệu, mục đích sử dụng không nhập 'nt' (Có thể Copy dòng trước lại dòng sau) "; //để sửa DVT của mã '00000000' nhấn SpaceBar sau đó nhấn F2 để nhập lại DVT
				
			}
			
			if (Common.Inlist(strMa_Ct,"DT,DTCP,DTXE,DTNA"))
			{
               if(strMa_Ct != "DT")
                {
					txtTen_Dt_NCC2.Visible = false;
					txtTen_Dt_NCC3.Visible = false;
					lbtNNC2.Visible = false;
					lbtNNC3.Visible = false;
				}
                lblGiam_Doc_Duyet.Visible = true;
                txtGD_Duyet.Visible = true;
                lbtTen_Gd_Duyet.Visible = true;
               

                txtDe_Xuat.Visible = false;
                txtLyDo_Cham_DT.Visible = true;
                pnThongTin.Visible = true;

                if (Common.Inlist(strMa_Ct, "DTCP,DTXE"))
                {
                    
                    txtDe_Xuat.Visible = true;
                    txtLyDo_Cham_DT.Visible = false;
                    lbtLyDo_Cham_DT.Text = "Đề xuất NCC";
                }
			}
			
			else
			{
                pnThongTin.Visible = false;
                
                lblGiam_Doc_Duyet.Visible = false;
                txtGD_Duyet.Visible = false;
                lbtTen_Gd_Duyet.Visible = false;
                lblSo_Ct0.Visible = false;
                txtSo_Ct0.Visible = false;
                lblNgay_Ct0.Visible = false;
                dteNgay_Ct0.Visible = false;
                
			}

			if(Common.InlistLike(strMa_Ct,"PYCPT,PYCCK,PONL,POXL"))
			{
				this.tabPage2.Text = "Chi tiết duyệt yêu cầu ";
			}
			else if (Common.InlistLike(strMa_Ct, "NCTH,PYCTH"))
			{
				this.tabControl1.TabPages.Remove(tabPage2);
			}
            if (Common.Inlist(strMa_Ct, "PYCTH,PYCPT"))
                btYC_TieuHao.Visible = true;
            else
                btYC_TieuHao.Visible = false;
           
            if (Common.Inlist(strMa_Ct, "PYCTH,PYCPT,PYCCK,DNX"))
                btCheckVTPTTD.Visible = true;
            else
                btCheckVTPTTD.Visible = false;

            Voucher.LockMa_Vt_Inherit(dgvEditCt1, dtEditCt, strMa_Ct);

			//BindingTTien
			numTTien0.DataBindings.Clear();
			numTTien3.DataBindings.Clear();
			numTTien.DataBindings.Clear();

			numTTien_Nt0.DataBindings.Clear();
			numTTien_Nt3.DataBindings.Clear();
			numTTien_Nt.DataBindings.Clear();
			numTSo_Luong.DataBindings.Clear();

			numTTien0.DataBindings.Add("Value", dtEditPh, "TTien0");
			numTTien3.DataBindings.Add("Value", dtEditPh, "TTien3");
			numTTien.DataBindings.Add("Value", dtEditPh, "TTien");

			numTTien_Nt0.DataBindings.Add("Value", dtEditPh, "TTien_Nt0");
			numTTien_Nt3.DataBindings.Add("Value", dtEditPh, "TTien_Nt3");
			numTTien_Nt.DataBindings.Add("Value", dtEditPh, "TTien_Nt");
			numTSo_Luong.DataBindings.Add("Value", dtEditPh, "TSo_Luong");
		}

		private void LoadDicName()
		{
			txtMa_Dt.bUseAutoDropDown = true;
			txtMa_Dt_CbNv.bUseAutoDropDown = true;
			txtMa_Hd.bUseAutoDropDown = true;
			

			//txtMa_Nvu
			if (txtMa_Nvu.Text.Trim() != string.Empty)
				lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DmNvu", "Ma_Nvu", "Ten_Nvu", txtMa_Nvu.Text.Trim());
			else
				lbtTen_Nvu.Text = string.Empty;

			//txtMa_Dt
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;
			
			//txtMa_Dt_CbNv
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
			{
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			}
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

			//txtMa_DDH
			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				lbtTen_Hd.Text = Voucher.GetTenHd(txtMa_Hd.Text); //DataTool.SQLGetNameByCode("R81DmHd", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			}
			else
				lbtTen_Hd.Text = string.Empty;

           

			if (txtGD_Duyet.Text.Trim() != string.Empty)
				lbtTen_Gd_Duyet.Text = DataTool.SQLGetNameByCode("R00Member", "Member_ID", "Member_Name", txtGD_Duyet.Text.Trim());
			else
				lbtTen_Gd_Duyet.Text = string.Empty;

			//Log
			string strCreate_Log = Common.Show_Log((string)drEditPh["Create_Log"]);
			string strLastModify_Log = Common.Show_Log((string)drEditPh["LastModify_Log"]);
			string strLog = string.Empty;
			strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
			strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";

			this.lblLog.Text = strLog;
		}
        private bool CheckVTPTTD()
        {
            Voucher.CheckVTPTTD(dtEditCt, ref dtCheckVTPTTD);
            if (dtCheckVTPTTD.Rows.Count > 0)
                return true;
            else
                return false;

            return true;
        }
		private bool FormCheckValid()
		{
			//Kiểm tra tên giám đốc
			if (txtGD_Duyet.Visible == true )
			{
				if (!DataTool.SQLCheckExist("R00MEMBERGROUP", new string[] { "Member_ID", "Member_Group_ID" }, new object[] { txtGD_Duyet.Text, "NQL" }))
				{ 
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tên giám đốc duyệt không hợp lệ" : "Do not register transaction type";
					Common.MsgCancel(strMsg);
					return false;
				}
			}
			if (txtMa_Nvu.Text == string.Empty)
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa khai báo mã nghiệp vụ" : "Do not register transaction type";
				Common.MsgCancel(strMsg);
				return false;
			}
			if (txtDien_Giai.Text == "")
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa nhập diễn giải của chứng từ" : "Do not register transaction type";
				Common.MsgCancel(strMsg);
				return false;
			}

            if (txtMa_Dt.Text == "")
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa nhập mã đối tượng nhà cung cấp" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
			if (Common.Inlist(strMa_Ct, "PYCPT,PYCCK,DT,PYCTH"))
			{
				if (txtMa_Dt_CbNv.Text == "")
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa nhập nhân viên yêu cầu" : "Do not register transaction type";
					Common.MsgCancel(strMsg);
					return false;
				}

                if (txtSo_Ct.Text != "" && Common.InlistLike(strMa_Ct, "DT") && Library.StrToDate(dteNgay_Ct.Text).ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    string strThangSo_Ct = txtSo_Ct.Text.Substring(3,2);
                    string strNamSo_Ct = txtSo_Ct.Text.Substring(9, 2);
                    
                    string Thang = DateTime.Now.Month.ToString("00");
                    string Nam = DateTime.Now.Year.ToString().Substring(2, 2);
                    if (Thang != strThangSo_Ct || Nam != strNamSo_Ct)
                    {
                        drEditPh["So_Ct"] = txtSo_Ct.Text = Voucher.Cong_So_Ct_PYC(this);

                        foreach (DataRow dr in dtEditCt.Rows)
                        {
                            dr["So_Ct"] = drEditPh["So_Ct"];
                        }
                        
                    }
                }
			}
			//
            if (enuNew_Edit == enuEdit.New && (string)SQLExec.ExecuteReturnValue("SELECT So_Ct FROM R80PH WHERE So_Ct = '" + txtSo_Ct.Text + "' AND Ma_Ct = '" + txtMa_Ct.Text + "' AND YEAR(Ngay_Ct) = YEAR('" + dteNgay_Ct.Text + "')") == txtSo_Ct.Text)
            {
                string strMsg = "Số chứng từ đang trùng với chứng từ phát sinh khác cùng loại. Bạn có muốn tăng tự động không?";

                if (Common.MsgYes_No(strMsg, "Y"))
                {
                    
                    drEditPh["So_Ct"] = txtSo_Ct.Text = Voucher.Cong_So_Ct_PYC(this);

                    foreach (DataRow dr in dtEditCt.Rows)
                    {
                        dr["So_Ct"] = drEditPh["So_Ct"];
                    }
                }
                else
                    return false;
            }
            
            //Kiểm tra VTPT tương đương
            if (Common.Inlist(strMa_Ct, "PYCPT,PYCCK,DNX"))
            {
                if (CheckVTPTTD())
                {
                    DataTable dtCheck;
                    dtCheck = dtCheckVTPTTD.Copy();
                    
                    frmCheckVTTD frm = new frmCheckVTTD();
                    frm.Load(dtCheck);
                    if (frm.Is_Accept)
                    {
                        if (Common.MsgYes_No("Bạn có muốn thay đổi mã VTPT tương đương thay thế không?", "Y"))
                            return false;


                    }
                }
            }
			//Kiểm tra nghiệp vụ hợp lệ
			foreach (DataRow dr in dtEditCt.Rows)
			{
				if (dr["Ma_Vt"] == "" && !Common.Inlist(strMa_Ct, "DTCP,DTXE"))
					dr["Deleted"] = true;

                if (dr["Muc_Dich"] == "" && Common.Inlist(strMa_Ct, "DTCP,DTXE"))
                    dr["Deleted"] = true;

				if ((bool)dr["Deleted"])
					continue;

                if (bTb)
                {
                    if (dr["Ma_Tb"] == "")
                        if (!Common.MsgYes_No("Tồn tại dòng có mã vật tư "+ dr["Ma_Vt"] +" không có mã thiết bị. Bạn có lưu không?", "Y"))
                            return false;
                }
                //Kiểm tra tên và mô tả kĩ thuận trên DỰ TRÙ
                if (strMa_Ct == "DT")
                {
                    DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", dr["Ma_Vt"].ToString());
                    if (dr["Ten_Vt"].ToString() != drDmVt["Ten_Vt_Chuan"].ToString())
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "'" + (string)dr["Ma_Vt"] + "' chưa được cập nhật tên vật tư chuẩn " : "Do not register transaction type";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                    if (!dr["Ma_Vt"].ToString().StartsWith("F") && drDmVt["Thong_So_Kt"].ToString() != "" && drDmVt["Thong_So_Kt"].ToString().StartsWith(dr["Mo_Ta_Kt"].ToString()))
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "'" + (string)dr["Ma_Vt"] + "' chưa được cập nhật mô tả kĩ thuật " : "Do not register transaction type";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                }
				//Kiểm tra trùng số hd trên DNTT
				if (strMa_Ct == "DNTT")
				{
					Hashtable ht = new Hashtable();
					ht.Add("NGAY_CT", dteNgay_Ct);
					ht.Add("SO_CT0", dr["So_Ct0"]);
					ht.Add("NGAY_CT0", dr["Ngay_Ct0"]);
					ht.Add("MA_SO_THUE", dr["Ma_So_Thue"]);
					ht.Add("MA_DT", txtMa_Dt.Text);
					ht.Add("STT", strStt);
					bool bCheck = Convert.ToBoolean(SQLExec.ExecuteReturnValue("sp_CheckHDDNTT", ht, CommandType.StoredProcedure));
					
					if (bCheck)
						Common.MsgOk("Số HĐ: " + dr["So_Ct0"] + " ngày hóa đơn: " + dr["Ngay_Ct0"].ToString() + " đã được tạo. Vui lòng không nhập trùng");

					return bCheck;
				}
				if ((string)dr["So_Ct"] == "")
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Số chứng từ bị trống không được lưu" : "Do not register transaction type";
					Common.MsgCancel(strMsg);
					return false;
				}
                if (Common.Inlist(strMa_Ct, "BBPT,BBTH") && Convert.ToDateTime(dr["Ngay_Gh"]).ToShortDateString() == "01/01/1900")
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Ngày giao hàng thực tế bị trống không được lưu" : "Do not register transaction type";
                    Common.MsgCancel(strMsg);
                    return false;
                }
                if (Common.Inlist(strMa_Ct, "DTCP,DTXE") && Convert.ToDouble(dr["Tien_Nt9"]) == 0)
                {
                    Common.MsgCancel("Chưa nhập tiền cho mục đích sử dụng '" + dr["Muc_Dich"] + "'. Yêu cầu nhập liệu trước khi lưu!!!");
                    return false;
                }
                if (Common.Inlist(strMa_Ct, "DTCP,DTXE") && Convert.ToDouble(dr["So_Luong0"]) != 0 && Convert.ToDouble(dr["So_Luong"]) == 0)
                {
                    Common.MsgCancel("Bạn nhấn enter tại dòng có mục đích là '" + dr["Muc_Dich"] + "' để cập nhật số lượng duyệt trước khi lưu!!!");
                    return false;
                }
                if (!Common.InlistLike(strMa_Ct, "DT,BB,DNTT"))
                {
                    //Lấy sl tồn kho
                    double dbTon_Cuoi = 0;
                    Voucher.GetTonCuoi_KKho(dr, ref dbTon_Cuoi);
                    dr["So_Luong_TonKho"] = dbTon_Cuoi;
                }
                if (strMa_Ct == "DNX" && Convert.ToDouble(dr["So_Luong0"]) > Convert.ToDouble(dr["So_Luong_TonKho"]) && dr["Ma_Vt"].ToString() != "" && !(bool)dr["Deleted"])
                {
                    Common.MsgCancel("Vật tư '" + dr["Ten_Vt"] + "' SL yêu cầu lớn hơn SL tồn kho. SL phải nhỏ hơn hoặc bằng tồn kho");
                    return false;
                }
				if (strMa_Ct == "DNX" && Convert.ToDouble(dr["So_Luong0"]) != Convert.ToDouble(dr["So_Luong9"]) && dr["Ma_Vt"].ToString() != "" && !(bool)dr["Deleted"])
				{
					Common.MsgCancel("Vật tư '" + dr["Ten_Vt"] + "' SL yêu cầu khác SL sẽ được duyệt, đề nghị nhấn phím enter tại dòng này!!!");
					return false;
				}
				if (Common.Inlist(strMa_Ct, "DT") && dtEditCt.Select("Ma_Vt = '" + dr["Ma_Vt"] + "' AND Stt_Org = '"+ dr["Stt_Org"] +"' AND Stt0_Org = "+ dr["Stt0_Org"] +" AND Deleted = false").Length > 1)
				{
					Common.MsgCancel("Dữ liệu kế thừa vật tư '" + dr["Ma_Vt"] + "' bị trùng yêu cầu xóa dữ liệu bị trùng");
					return false;
				}
                if (Common.InlistLike(strMa_Ct, "DT") && txtMa_Thue.Text != "" && Convert.ToDouble(dr["Thue_Gtgt"]) != 0 && Convert.ToDouble(dr["Tien3"]) + Convert.ToDouble(dr["Tien_Nt3"]) == 0 && Convert.ToDouble(dr["So_Luong"]) != 0)
                {
                    string strMsg = "Chứng từ có mã thuế " + dr["Ma_Thue"] + " nhưng tiền thuế = 0. Bạn vui lòng enter tại mã thuế !!!";
                    Common.MsgOk(strMsg);
                    return false;
                }
                if (Common.InlistLike(strMa_Ct, "DT") && txtMa_Thue.Text == "" && Convert.ToDouble(dr["Tien3"]) + Convert.ToDouble(dr["Tien_Nt3"]) != 0)
                {
                    string strMsg = "Chứng từ không có mã thuế nhưng tiền thuế <> 0. Bạn vui lòng enter tại mã thuế !!!";
                    Common.MsgOk(strMsg);
                    return false;
                }
                
                if (Common.InlistLike(strMa_Ct, "DT") && txtMa_Thue.Text == "" && Convert.ToDouble(dr["Thue_Gtgt"]) != 0 && Convert.ToDouble(dr["Tien3"]) + Convert.ToDouble(dr["Tien_Nt3"]) != 0)
                {
                    string strMsg = "Chứng từ không có mã thuế nhưng tiền thuế khác 0. Bạn vui lòng enter tại mã thuế !!!";
                    Common.MsgOk(strMsg);
                    return false;
                }
                if (Common.InlistLike(strMa_Ct, "BBPT,BBTH") && dr["So_Ct"].ToString().Contains("TCHC") && !dr["Ma_Vt"].ToString().StartsWith("F"))
                {
                    string strMsg = "Phòng tổ chức hành chính không được nghiệm thu khác nhóm văn phòng phẩm";
                    Common.MsgOk(strMsg);
                    return false;
                }
                if (Common.InlistLike(strMa_Ct, "BBPT,BBTH") && !dr["So_Ct"].ToString().Contains("TCHC") && dr["Ma_Vt"].ToString().StartsWith("F"))
                {
                    string strMsg = "Kho phụ tùng không được nghiệm thu nhóm văn phòng phẩm";
                    Common.MsgOk(strMsg);
                    return false;
                }
                if (strMa_Ct == "BBPT" && (string)dr["Ma_VTri"] == "")
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Mã vị trí đang trống không cho phép lưu" : "Do not register transaction type";
                    Common.MsgCancel(strMsg);
                    return false;
                }
				if((string)dr["Ma_Vt"] == (string)dr["Ten_Vt"])
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Tên vật tư trùng mã vật tư. Vui lòng kiểm tra lại dữ liệu!!!" : "Do not register transaction type";
					Common.MsgCancel(strMsg);
					return false;
				}
				//Kiểm tra số lượng đã lập dự trù
				if (Common.Inlist(strMa_Ct, "DT"))
                {
                    double dbSo_Luong_Accept = 0;
                    double dbSo_Luong_Dt_Current = Common.SumDCValue(dtEditCt, "So_Luong", "Ma_Vt = '" + dr["Ma_Vt"] + "' AND Stt_Org = '" + dr["Stt_Org"] + "' AND Stt0_Org = " + dr["Stt0_Org"] + " AND Deleted = false");
                    Hashtable ht = new Hashtable();
                    ht.Add("STT", strStt);
                    ht.Add("STT_ORG", dr["Stt_Org"]);
                    ht.Add("STT0_ORG", dr["Stt0_Org"]);
                    ht.Add("MA_VT_TT", dr["Ma_Vt_Tt"]);
                    
                    dbSo_Luong_Accept = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_CheckCreateDT(@Stt, @Stt_Org, @Stt0_Org, @Ma_Vt_Tt)", ht, CommandType.Text));

                    if (dbSo_Luong_Accept - dbSo_Luong_Dt_Current < 0)
                    {
                        Common.MsgCancel("Không lập dự trù có số lượng cao hơn số lượng đề nghị của vật tư '" + dr["Ten_Vt"] + "' số lượng "+ dbSo_Luong_Accept  +"");
                        return false;
                    }
                }

                if (Common.Inlist(strMa_Ct, "DNX,PYCPT,PYCCK,PYCTH") && dtEditCt.Select("Ma_Vt = '" + dr["Ma_Vt"] + "' AND Deleted = false").Length > 1)
                {
                    Common.MsgCancel("Không đề nghị vật tư '" + dr["Ma_Vt"] + "' nhiều hơn 1 dòng");
                    return false;
                }
                if (Common.Inlist(strMa_Ct, "DNXNL") && dtEditCt.Select("Ma_Xe = '" + dr["Ma_Xe"] + "' AND Deleted = false").Length > 1)
                {
                    Common.MsgCancel("Không đề nghị vật tư '" + dr["Ma_Xe"] + "' nhiều hơn 1 dòng");
                    return false;
                }
                if (Common.InlistLike(strMa_Ct, "PYC,DNX,DT") && dr["Ma_Vt"].ToString().Length > 9)
                {
                    Common.MsgCancel("Không đề nghị vật tư lớn hơn 9 ký tự");
                    return false;
                }
               
                if (Common.Inlist(strMa_Ct, "DNX") && txtMa_Nvu.Text == "LVPP" && dr["Ma_Vt"].ToString().Substring(0,1) != "F")
                {
                    Common.MsgCancel("Nghiệp vụ lĩnh văn phòng phẩm chỉ sử dụng mã vật tư bắt đầu bằng chữ F. Vui lòng chọn lại để PTCHC duyệt");
                    return false;

                   
                }
                if (Common.Inlist(strMa_Ct, "DNX") && txtMa_Nvu.Text == "LVTPT" && dr["Ma_Vt"].ToString().Substring(0, 1) == "F")
                {
                    Common.MsgCancel("Nghiệp vụ lĩnh vật tư phụ tùng không sử dụng mã vật tư bắt đầu bằng chữ F. Vui lòng chọn lại để PKTCDAT duyệt");
                    return false;

                }
                if (Common.Inlist(strMa_Ct, "DNX"))
                {
					if (txtMa_Nvu.Text != "LVPP" && dr["Ma_Tb"].ToString() == "")
					{
						Common.MsgCancel("Nghiệp vụ lĩnh VTPT phải có mã thiết bị");
						return false;
					}
					if(Convert.ToDouble(dr["So_Luong9"]) != Convert.ToDouble(dr["So_Luong_TP"]))
					{
						dr["So_Luong9"] = dr["So_Luong_TP"];
						dr["So_Luong"] = dr["So_Luong_TP"];
					}
				}
                //kiểm tra số lương đề nghị <> so luong duyet
            if (Common.InlistLike(strMa_Ct,"DT") && Convert.ToDouble(dr["So_Luong"]) != Convert.ToDouble(dr["So_Luong0"]))
            {
                Common.MsgCancel("Số lượng đề nghị khác số lượng dự kiến được duyệt. Bạn hãy xóa số lượng đề nghị nhập lại sau đó nhấn enter tại dòng có mã vật tư là "+ dr["Ma_Vt"] +"");
                return false;
            }
				#region Kiểm tra tính hợp lệ của các thông tin nhập liệu
				if (Common.Inlist(strMa_Ct, "DT,DTVPP,BBPT,BBTH") && dr["Stt_Org"] == "")
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "'" + (string)dr["Ten_Vt"] + "' không được kế thừa, yêu cầu kế thừa từ PYC hay DT mới được phép lưu " : "Do not register transaction type";
					Common.MsgCancel(strMsg);
					return false;
				}
				if (Common.Inlist(strMa_Ct, "PYCPT,PYCCK,PYCTH"))
				{
					string strMa_Vt = (string)dr["Ma_Vt"];
                    //if (strMa_Vt.Length < 11 && strMa_Vt != " " && !Common.InlistLike(strMa_Vt,"B,D,V"))
                    //{
                    //    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Không cho phép sử dụng mã có dưới 11 ký tự '" + (string)dr["Ten_Vt"] + "'" : "Do not register transaction type";
                    //    Common.MsgCancel(strMsg);
                    //    return false;
                    //}
                    if (dr["Xuat_Xu"] == "")
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "'" + (string)dr["Ten_Vt"] + "' ('"+ (string)dr["Ma_Vt"] +"') chưa được nhập xuất xứ/vật liệu. Phải nhập mới được phép lưu ? " : "Do not register transaction type";
                        Common.MsgCancel(strMsg);
                        return false;
                    }

                    if (dr["Ton_PX_BP"] == "" && dr["Ma_Vt"] != "" && Common.InlistLike(strMa_Ct, "PYCCK,PYCPT"))
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "'" + (string)dr["Ten_Vt"] + "' chưa được nhập số lượng tồn tại PX/PB. Phải nhập mới được phép lưu ? " : "Do not register transaction type";
						Common.MsgCancel(strMsg);
						return false;

					}

                    if (dr["Open_File"] == "" && dr["Ma_Vt"] != "" && Common.InlistLike(strMa_Ct, "PYCCK"))
                    {
                        string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "'" + (string)dr["Ten_Vt"] + "' chưa được attach file bạn phải attach mới được phép lưu ? " : "Do not register transaction type";
                        Common.MsgCancel(strMsg);
                        return false;

                    }
                   
					if (dr["Ma_Bp_Sd"] == "" && !Common.InlistLike(strMa_Ct,"PYCTH,DNX"))
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Bộ phận sử dụng không được để trống '" + (string)dr["Ten_Vt"] + "'" : "Do not register transaction type";
						Common.MsgCancel(strMsg);
						return false;
					}
					if (Convert.ToDouble(dr["So_Luong_LD"]) == 0 && dr["Ma_Vt"] != "" && !Common.InlistLike(strMa_Ct,"PYCTH,DT,DTVPP"))
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa nhập Số lượng lắp đặt tại tên vật tư '" + (string)dr["Ten_Vt"] + "'" : "Do not register transaction type";
						Common.MsgCancel(strMsg);
						return false;
					}

					if ((string)dr["Muc_Dich"] == "" && dr["Ma_Vt"] != "")
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Chưa nhập Mục đích tại tên vật tư '" + (string)dr["Ten_Vt"] + "'" : "Do not register transaction type";
						Common.MsgCancel(strMsg);
						return false;
					}

					if ((string)dr["Muc_Dich"] == "nt" && dr["Ma_Vt"] != "")
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Cần nhập mục đích sử dụng cho vật tư '" + (string)dr["Ten_Vt"] + "'" : "Do not register transaction type";
						Common.MsgCancel(strMsg);
						return false;
					}

					if (Convert.ToDouble(dr["So_Luong0"]) != Convert.ToDouble(dr["So_Luong"]) && (bool)drEditPh["Duyet_TP"] == false)
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Số lượng yêu cầu " + dr["So_Luong0"] + " khác với số lượng duyệt của trưởng đơn vị " + dr["So_Luong"] + " tại '" + (string)dr["Ten_Vt"] + "' cần enter qua số lượng yêu cầu" : "Do not register transaction type";
						Common.MsgCancel(strMsg);
						return false;
					}
				}

				#endregion
				#region Kiểm tra tính hợp lệ của định nghĩa nghiệp vụ
				//foreach (DataColumn dc in drDmNvu.Table.Columns)
				//{
				//    if (dc.ColumnName.EndsWith("_RULE") && drDmNvu.Table.Columns.Contains(dc.ColumnName.Replace("_RULE", "")))
				//    {
				//        string strRule_Name = dc.ColumnName;
				//        string strColumnName = strRule_Name.Replace("_RULE", "");

				//        if (drDmNvu[strColumnName].ToString() != "")
				//        {
				//            //1-Bắt buộc, 2-Cho phép sửa lại phần đuôi, 3-Cho phép thay đổi
				//            if ((drDmNvu[strRule_Name].ToString() == "1") && !(drDmNvu[strColumnName].ToString().Split(',').Any(strValue => strValue == dr[strColumnName].ToString())))
				//            {
				//                Common.MsgCancel("Nhập liệu [" + Languages.GetLanguage(strColumnName) + "] không đúng với định nghĩa nghiệp vụ!");
				//                return false;
				//            }
				//            else if ((drDmNvu[strRule_Name].ToString() == "2") && !(drDmNvu[strColumnName].ToString().Split(',').Any(strValue => dr[strColumnName].ToString().StartsWith(strValue))))
				//            {
				//                Common.MsgCancel("Nhập liệu [" + Languages.GetLanguage(strColumnName) + "] không đúng với định nghĩa nghiệp vụ!");
				//                return false;
				//            }
				//        }
				//    }
				//}
				#endregion
			}
			return true;
		}
        private bool SaveFile()
        {
            return Voucher.Attach_File(this, dtEditResource, (Convert.ToDateTime(dteNgay_Ct.Text).Year).ToString(), txtSo_Ct.Text, strMa_Ct);
           
        }
		public override bool Save()
		{
			Common.GatherMemvar(this, ref this.drEditPh);
			Voucher.Update_Detail(this);

			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
			{
				drEditPh["Create_Log"] = Common.GetCurrent_Log();
				drEditPh["LastModify_Log"] = string.Empty;
			}
			else
			{
				drEditPh["LastModify_Log"] = Common.GetCurrent_Log();
				if ((string)drEditPh["Create_Log"] == string.Empty)
					drEditPh["Create_Log"] = drEditPh["LastModify_Log"];
			}
            if (Common.Inlist(strMa_Ct, "DTCP,DTXE"))
            {
                foreach (DataRow dr in dtEditCt.Rows)
                {
                    dr["Ma_Bp_Sd"] = (string)SQLExec.ExecuteReturnValue("SELECT MIN(Member_Group_ID) FROM R00MEMBERGROUP WHERE Member_Id = '" + Element.sysUser_Id + "'");
                    
                    if(dr["Ma_Vt"] == "")
                        dr["Ma_Vt"] = "DVSCN";
                }
            }
			foreach (DataRow dr in dtEditCt.Select("Ma_Vt = ' '"))
			{
				if (dr["Ma_Vt"] == "")
					dr["Deleted"] = 1;
			}
            if (strMa_Ct == "DT" && enuNew_Edit == enuEdit.New)
            {
                foreach (DataRow dr in dtEditCt.Select("Mo_Ta_Bs <> ''"))
                {
                    string strUpdate = "Update R81DMVT SET Ten_Vt = LTRIM(RTRIM(Ten_Vt)) + ' ' + N'" + dr["Mo_Ta_Bs"] + "', Thong_So_Kt = LTRIM(RTRIM(Thong_So_Kt)) + ' ' + N'" + dr["Mo_Ta_Bs"] + "' WHERE Ma_Vt = '" + dr["Ma_Vt"] + "'";
                    SQLExec.Execute(strUpdate);
                }
            }
           
			Voucher.Update_TTien(this);
			Voucher.Update_Stt(this, strModule);
			Voucher.UpdateSo_Ct(this);
			//UpdateTonKho();

			if (!(bool)drEditPh["Duyet"]) //Trường hợp chứng từ chưa duyệt
			{
				if (dtEditPh.Columns.Contains("Ngay_Ct_Lap"))
				{
					drEditPh["Ngay_Ct_Lap"] = drEditPh["Ngay_Ct"];
					drEditPh["So_Ct_Lap"] = drEditPh["So_Ct"];
				}
			}

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				if (dtEditCt.Rows.Count > 0) //Cập nhật lại dữ liệu từ chi tiết lên Header
					Common.CopyDataRow(dtEditCt.Rows[0], drEditPh, (string)drDmCt["Update_Header"]);

				drEdit = drEditPh;
			}
         

  
            //lƯU VÀO BTTB
            if (Common.InlistLike(strMa_Ct, "PYCPT,PYCCK"))
            {
                foreach (DataRow dr in dtEditCt.Select("Ma_Tb <> ''"))
                {
                    Hashtable htTB = new Hashtable();
                    htTB.Add("MA_TB", dr["Ma_Tb"].ToString());
                    htTB.Add("MA_VT", dr["Ma_Vt"].ToString());
                    htTB.Add("SO_LUONG_LD", dr["So_Luong_LD"]);
                    htTB.Add("CREATE_LOG", Common.GetCurrent_Log());
                    SQLExec.Execute("DBO.SP_UpdateVTPO_BTTB", htTB, CommandType.StoredProcedure);
                }
            }
            if (Common.InlistLike(strMa_Ct, "BBPT,BBTH"))
            {
                //CẬP NHẬT STT
                dtEditVTri.Clear();
              
                foreach (DataRow dr in dtEditCt.Select("Ma_VTri <> ''"))
                {
                    DataRow drEditCtNew = dtEditVTri.NewRow();
                    Common.CopyDataRow(dr, drEditCtNew);
                    Common.SetDefaultDataRow(ref drEditCtNew);

                    drEditCtNew["Stt0"] = dr["Stt0"];
                    drEditCtNew["Ma_Vt"] = dr["Ma_Vt"];
                    drEditCtNew["Ma_VTri"] = dr["Ma_VTri"];
                    drEditCtNew["So_Luong"] = dr["So_Luong"];
                    drEditCtNew["Stt_Org"] = dr["Stt_Org"];
                    drEditCtNew["Stt0_Org"] = dr["Stt0_Org"];

                    dtEditVTri.Rows.Add(drEditCtNew);
                    drEditCtNew.AcceptChanges();
                }
                //
                SqlCommand sqlCom = SQLExec.GetSQLCommand();
			    sqlCom.CommandType = CommandType.StoredProcedure;

			    sqlCom.Parameters.Clear();
                sqlCom.Parameters.Add("STT", drEdit["Stt"]);
                sqlCom.Parameters.Add("SO_CT", drEdit["So_Ct"]);
                sqlCom.Parameters.Add("NGAY_CT", drEdit["Ngay_Ct"]);
			    sqlCom.Parameters.Add("MA_DVCS", Element.sysMa_DvCs);

			    sqlCom.CommandText = "Sp_ImportTVP_CTNVTRI";

			    SqlParameter sqlPara = new SqlParameter();
			    sqlPara.ParameterName = "@TVP_Import";
			    sqlPara.SqlDbType = SqlDbType.Structured;
			    sqlPara.TypeName = "TVP_CTNVTRI";
			    sqlPara.Value = Voucher.GetTVPValue("R05CTNVTRI", "TVP_CTNVTRI", dtEditVTri);

			    sqlCom.Parameters.Add(sqlPara);
                try
                {
                    sqlCom.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    Common.MsgOk(ex.Message);
                    
                }
            }

            if (dtEditResource.Select("File_Path_New <> ''").Length > 0 && Voucher.Check_User_Server(this, (Convert.ToDateTime(dteNgay_Ct.Text).Year).ToString(), txtSo_Ct.Text, strMa_Ct))
            {
                Voucher.SQLUpdateCt(this);
                return SaveFile();
            }
            else if (dtEditResource.Select("File_Path_New <> ''").Length > 0 && !Voucher.Check_User_Server(this, (Convert.ToDateTime(dteNgay_Ct.Text).Year).ToString(), txtSo_Ct.Text, strMa_Ct))
                return false;
            else
                return Voucher.SQLUpdateCt(this);
		}

		private void Ma_Tte_Valid()
		{
			string strMa_Tte = txtMa_Tte.Text.Trim();
			string strMa_Tte_Old = (string)drEditPh["Ma_Tte"];

			if (Element.sysMa_Tte == strMa_Tte)
			{
				numTy_Gia.Value = 1;
				numTy_Gia.Enabled = false;

				this.pnlTTien.Visible = false;
				this.pnlTTien_Nt.Left = this.pnlTTien.Right - this.pnlTTien_Nt.Width;

				if (dgvEditCt1.Columns.Contains("TIEN"))
					dgvEditCt1.Columns["TIEN"].Visible = false;				
			}
			else
			{
				if ((bool)drEditPh["Duyet_KhVt"] == true && enuNew_Edit == enuEdit.Edit)
				{
					numTy_Gia.Enabled = false;
					txtMa_Tte.Enabled = false;
				}
				else
					numTy_Gia.Enabled = true;

				if (dteNgay_Ct.Text != Library.DateToStr((DateTime)drEditPh["Ngay_Ct"]) || txtMa_Tte.bTextChange)
				{
					Hashtable ht = new Hashtable();
					ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));
					ht.Add("MA_TTE", strMa_Tte);
					
					if(enuNew_Edit == enuEdit.New)
						numTy_Gia.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("sp_GetTyGia", ht, CommandType.StoredProcedure));
				}

				this.pnlTTien.Visible = true;
				this.pnlTTien_Nt.Left = this.pnlTTien.Left - this.pnlTTien_Nt.Width;

				if (dgvEditCt1.Columns.Contains("TIEN"))
					dgvEditCt1.Columns["TIEN"].Visible = true;
			}

			numTTien_Nt.Scale = numTTien_Nt0.Scale = numTTien_Nt3.Scale = strMa_Tte == Element.sysMa_Tte ? 0 : 2;

			Voucher.FormatTien_Nt(dgvEditCt1, strMa_Tte);
			Voucher.FormatTien_Nt(dgvEditCt2, strMa_Tte);
            Voucher.FormatTien_Nt(dgvEditCt3, strMa_Tte);

			if (dgvEditCt1.Columns.Contains("So_Luong9"))
				dgvEditCt1.Columns["So_Luong9"].DefaultCellStyle.Format = "N2";

			if (dgvEditCt1.Columns.Contains("So_Luong0"))
				dgvEditCt1.Columns["So_Luong0"].DefaultCellStyle.Format = "N2";

			if (dgvEditCt2.Columns.Contains("So_Luong9"))
				dgvEditCt2.Columns["So_Luong9"].DefaultCellStyle.Format = "N2";

			if (dgvEditCt2.Columns.Contains("So_Luong0"))
				dgvEditCt2.Columns["So_Luong0"].DefaultCellStyle.Format = "N2";
            
            if (dgvEditCt3.Columns.Contains("So_Luong9"))
                dgvEditCt3.Columns["So_Luong9"].DefaultCellStyle.Format = "N2";

			dgvEditCt1.ResizeGridView();
			dgvEditCt2.ResizeGridView();
            dgvEditCt3.ResizeGridView();

			DataGridView_Language();
		}

		private bool CellKeyEnter()
		{//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc			

			if (dgvEditCt1.CurrentCell == null)
				return false;

			DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
			string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

			#region Enter tai TEN_VT
			if (Common.Inlist(strCurrentColumn, "TEN_VT"))
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				if (drCurrent["Ma_Vt"] == DBNull.Value || (string)drCurrent["Ma_Vt"] == string.Empty)
				{
					bool bIsCurrentLastRow = dgvEditCt1.bIsCurrentLastRow;

					bdsEditCt.RemoveCurrent();
					dtEditCt.AcceptChanges();

					if (bIsCurrentLastRow)
						this.SelectNextControl(dgvEditCt1, true, true, true, true);

					return true;
				}

				return false;
			}
			#endregion

			#region Enter tai TIEN_NT9
			if (Common.Inlist(strCurrentColumn, "TIEN_NT9"))
			{
				if (txtMa_Tte.Text.Trim() == Element.sysMa_Tte)
				{
					// Cap nhat tien TIEN_NT9 truoc khi xuong dong
					double dbTien_Nt9 = 0;
					if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien_Nt9))
					{
						dgvEditCt1.CancelEdit();
						drCurrent = ((DataRowView)bdsEditCt.Current).Row;
						drCurrent["TIEN_NT9"] = dbTien_Nt9;
						Voucher.Calc_So_Luong(drCurrent, this);
						Voucher.Update_TTien(this);
					}
					
				}
                #region Enter Cot cuoi
                string strColumnLast = (string)SQLExec.ExecuteReturnValue("SELECT TOP 1 ISNULL(Column_ID, '') FROM R00COLUMN WHERE ZONE LIKE '" + dgvEditCt1.strZone + "' AND Visible = 1 ORDER BY Stt DESC", CommandType.Text);

                if (strCurrentColumn == strColumnLast)
                {
                    if (dgvEditCt1.bIsCurrentLastRow)
                    {
                        if (!Voucher.AddRow(this))
                            this.SelectNextControl(dgvEditCt1, true, true, true, true);
                        else
                        {
                            dgvEditCt1.FocusNextFirstCell();
                            return true;
                        }
                    }
                    else
                        dgvEditCt1.FocusNextFirstCell();
                }
                #endregion
				return false;
			}
			#endregion	

			#region Enter TIEN
			if (Common.Inlist(strCurrentColumn, "TIEN"))
			{
				if (dgvEditCt1.bIsCurrentLastRow)
				{
					// Cap nhat Tien truoc khi xuống dòng
					double dbTien = 0;
					if (double.TryParse(dgvEditCt1.CurrentCell.FormattedValue.ToString().Trim(), out dbTien))
					{
						dgvEditCt1.CancelEdit();
						drCurrent = ((DataRowView)bdsEditCt.Current).Row;
						drCurrent["TIEN"] = dbTien;
						Voucher.Calc_So_Luong(drCurrent, this);
						Voucher.Update_TTien(this);
					}
					
				}

				return false;
			}
			#endregion
			#region Enter Cot cuoi
			string strColumnLast1 = (string)SQLExec.ExecuteReturnValue("SELECT TOP 1 ISNULL(Column_ID, '') FROM R00COLUMN WHERE ZONE LIKE '" + dgvEditCt1.strZone + "' AND Visible = 1 ORDER BY Stt DESC", CommandType.Text);

			if (strCurrentColumn == strColumnLast1)
			{
				if (dgvEditCt1.bIsCurrentLastRow)
				{
					if (!Voucher.AddRow(this))
						this.SelectNextControl(dgvEditCt1, true, true, true, true);
					else
					{
						dgvEditCt1.FocusNextFirstCell();
						return true;
					}
				}
				else
					dgvEditCt1.FocusNextFirstCell();
			}
			#endregion
			return false;
		}
		
		private void TTien_Valid()
		{
			numTTien0.Value = numTTien_Nt0.Value * numTy_Gia.Value;

			if (numTTien3.Value == 0)
				numTTien3.Value = numTTien_Nt3.Value * numTy_Gia.Value;
			else if (numTTien_Nt3.Value == 0 && numTy_Gia.Value != 0)
				numTTien_Nt3.Value = numTTien3.Value / numTy_Gia.Value;

			this.drEditPh["TTien0"] = numTTien0.Value;
			this.drEditPh["TTien_Nt0"] = numTTien_Nt0.Value;
			this.drEditPh["TTien3"] = numTTien3.Value;
			this.drEditPh["TTien_Nt3"] = numTTien_Nt3.Value;

			this.drEditPh["TTien"] = Convert.ToDouble(this.drEditPh["TTien0"]) + Convert.ToDouble(this.drEditPh["TTien3"]);
			this.drEditPh["TTien_Nt"] = Convert.ToDouble(this.drEditPh["TTien_Nt0"]) + Convert.ToDouble(this.drEditPh["TTien_Nt3"]);

			Voucher.Adjust_TThue_Vat(this);
		}

		private void InheritVoucher() //Kế thừa chứng từ từ phiếu khác
		{
            if (strMa_Ct == "DTNA")
            {
                frmInherit_MonAn frm1 = new frmInherit_MonAn();
                frm1.Load(this);

            }
            else
            {
                Voucher.Update_Header(this);
                Voucher.Update_Detail(this);

                frmInheritVoucher frm = new frmInheritVoucher();
                frm.Load(this);

                if (frm.Is_Accept)
                {
                    Voucher.InheritVoucher_SetData(frm, this);

                    Voucher.Update_Detail(this);
                    Voucher.Update_TTien(this);
                    Voucher.LockMa_Vt_Inherit(dgvEditCt1, dtEditCt, strMa_Ct);

                    foreach (DataRow dr in dtEditCt.Rows)
                    {
                        drEditVTri = dtEditVTri.NewRow();
                        Common.CopyDataRow(dr, drEditVTri, "Stt_Org,Stt0_Org,Ma_Vt,So_luong");
                        dtEditVTri.Rows.Add(drEditVTri);
                        drEditVTri.AcceptChanges();
                    }
                    
                }
            }
		}
      
        //protected override bool AddRowMiddle_ViTri()
        //{
        //    DataRow drCurrent = ((DataRowView)bdsEditVTri.Current).Row;
        //    DataTable dtEditVTri = (DataTable)bdsEditVTri.DataSource;           
        //    double dbSo_Luong9 = dtEditVTri.Columns.Contains("So_Luong") ? (drCurrent["So_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["So_Luong"])) : 0;
            
        //    bool bNewRow;
            
        //    switch (strMa_Ct)
        //    {
        //        default:
        //            if (dbSo_Luong9 == 0)
        //                bNewRow = false;
        //            else
        //                bNewRow = true;
        //            break;
        //    }

        //    if (bNewRow)
        //    {
        //        DataRow drNew = dtEditVTri.NewRow();

        //        Common.SetDefaultDataRow(ref drNew);
        //        Common.CopyDataRow(drCurrent, drNew, "Ma_Vt,Ten_Vt");

        //        //drNew["Stt0"] = Common.MaxDCValue(dtEditCt, "Stt0") + 1;
        //        foreach (DataRow dr in dtEditVTri.Rows)
        //        {
        //            if (Convert.ToDouble(dr["Stt0"]) > Convert.ToDouble(drCurrent["Stt0"]))
        //                dr["Stt0"] = Convert.ToDouble(dr["Stt0"]) + 1;
        //        }

        //        drNew["Stt0"] = Convert.ToDouble(drCurrent["Stt0"]) + 1;
        //        drNew["Deleted"] = false;

        //        dtEditVTri.Rows.InsertAt(drNew, bdsEditVTri.Position + 1);

        //        drNew.AcceptChanges();
        //    }

        //    return bNewRow;
        //}
		#endregion
			
		#region Su kien

		#region FormEvent		

		void btnImportExcel_Click(object sender, EventArgs e)
		{
			Voucher.ImportExcelCtVT(this);
		}
		private void CheckGiaMua() //Kiem tra gia mua
		{
			if (Common.InlistLike(strMa_Ct, "DT,DTVPP"))
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				frmCheck_Gia_Mua frm = new frmCheck_Gia_Mua();
				frm.Load1((string)drCurrent["Ma_Vt"]);
			}
		}
        private void CheckDMBHLD() //Kiem tra định mức
        {
            if (Common.InlistLike(strMa_Ct, "PYCTH"))
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                frmCheckDinhMucBHLD = new frmCheckDinhMucBHLD();

                frmCheckDinhMucBHLD.Load(drCurrent);
                frmCheckDinhMucBHLD.Show(this);
                frmCheckDinhMucBHLD.is_Open = true;
               
                
            }
        }
        void btCheckVTPTTD_Click(object sender, EventArgs e)
        {
            frmCheck_Gia_Mua frm = new frmCheck_Gia_Mua();
            frm.Load2(dtCheckVTPTTD);
        }
        void btUpdate_ThongTin_Click(object sender, EventArgs e)
        {
            frmUpdate_ThongTin frm = new frmUpdate_ThongTin();
            frm.Load(drEditPh);
        }
		
        void btInheritTB_Click(object sender, EventArgs e)
        {
            frmInherit_LyLichTB frm = new frmInherit_LyLichTB();
            frm.Load(this,"");
        }
        void btYC_TieuHao_Click(object sender, EventArgs e)
        {
            frmTieuHao_DinhMuc frm = new frmTieuHao_DinhMuc();
            frm.Load(this);
        }
		void btInherit_Click(object sender, EventArgs e)
		{
			this.InheritVoucher();
		}
		void txtMa_Nvu_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nvu.Text.Trim();
			bool bRequire = true;
			string strFilter = "(CHARINDEX('" + strMa_Ct + "', Ma_Ct, 0) > 0 OR Ma_Ct = '*')";
			string strValid = "Ma_Ct <> ''";

			DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, strFilter, strValid);

			if (drLookup == null) //Bắt buộc phải nhập Ma_Nvu
			{
				e.Cancel = true;
				return;
			}

			drDmNvu = drLookup;

			txtMa_Nvu.Text = drLookup["Ma_Nvu"].ToString();
			lbtTen_Nvu.Text = drLookup["Ten_Nvu"].ToString();

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEditPh["Duyet"] = (bool)drDmNvu["Default_Duyet"];

			if (txtMa_Nvu.bTextChange) //(enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy) 
			{
				#region Cập nhật trên Form
				if (drDmNvu["Tk_No"].ToString() != "" && !drDmNvu["Tk_No"].ToString().Contains(",")) //Tk_No
				{

				}
				if (drDmNvu["Tk_Co"].ToString() != "" && !drDmNvu["Tk_Co"].ToString().Contains(",")) //Tk_Co
				{

				}
				if (drDmNvu["Ma_Dt"].ToString() != "" && !drDmNvu["Ma_Dt"].ToString().Contains(",")) //Ma_Dt
				{

				}
				if (drDmNvu["Ma_Bp"].ToString() != "" && !drDmNvu["Ma_Bp"].ToString().Contains(",")) //Ma_Bp
				{

				}
				if (drDmNvu["Ma_Km"].ToString() != "" && !drDmNvu["Ma_Km"].ToString().Contains(",")) //Ma_Km
				{

				}
				if (drDmNvu["Ma_Vt_Sp"].ToString() != "" && !drDmNvu["Ma_Vt_Sp"].ToString().Contains(",")) //Ma_Vt_Sp
				{

				}
				if (drDmNvu["Ma_Hd"].ToString() != "" && !drDmNvu["Ma_Hd"].ToString().Contains(",")) //Ma_Hd
				{

				}
				if (drDmNvu["Ma_Job"].ToString() != "" && !drDmNvu["Ma_Job"].ToString().Contains(",")) //Ma_Job
				{

				}
				if (drDmNvu["Ma_Dt_CbNv"].ToString() != "" && !drDmNvu["Ma_Dt_CbNv"].ToString().Contains(",")) //Ma_Dt_CbNv
				{

				}
				if (drDmNvu["Ma_Thue"].ToString() != "" && !drDmNvu["Ma_Thue"].ToString().Contains(",")) //Ma_Thue
				{

				}
				if (drDmNvu["Ma_Kho"].ToString() != "" && !drDmNvu["Ma_Kho"].ToString().Contains(",")) //Ma_Kho
				{

				}
				#endregion

				#region Cập nhật trên lưới
				foreach (DataRow dr in dtEditCt.Rows)
				{
					if (dtEditCt.Columns.Contains("Tk_No") && drDmNvu["Tk_No"].ToString() != "" && !drDmNvu["Tk_No"].ToString().Contains(",")) //Tk_No
					{
						dr["Tk_No"] = drDmNvu["Tk_No"].ToString();
					}
					if (dtEditCt.Columns.Contains("Tk_Co") && drDmNvu["Tk_Co"].ToString() != "" && !drDmNvu["Tk_Co"].ToString().Contains(",")) //Tk_Co
					{
						dr["Tk_Co"] = drDmNvu["Tk_Co"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Dt") && drDmNvu["Ma_Dt"].ToString() != "" && !drDmNvu["Ma_Dt"].ToString().Contains(",")) //Ma_Dt
					{
						dr["Ma_Dt"] = drDmNvu["Ma_Dt"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Bp") && drDmNvu["Ma_Bp"].ToString() != "" && !drDmNvu["Ma_Bp"].ToString().Contains(",")) //Ma_Bp
					{
						dr["Ma_Bp"] = drDmNvu["Ma_Bp"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Km") && drDmNvu["Ma_Km"].ToString() != "" && !drDmNvu["Ma_Km"].ToString().Contains(",")) //Ma_Km
					{
						dr["Ma_Km"] = drDmNvu["Ma_Km"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Vt_Sp") && drDmNvu["Ma_Vt_Sp"].ToString() != "" && !drDmNvu["Ma_Vt_Sp"].ToString().Contains(",")) //Ma_Vt_Sp
					{
						dr["Ma_Vt_Sp"] = drDmNvu["Ma_Vt_Sp"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Hd") && drDmNvu["Ma_Hd"].ToString() != "" && !drDmNvu["Ma_Hd"].ToString().Contains(",")) //Ma_Hd
					{
						dr["Ma_Hd"] = drDmNvu["Ma_Hd"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Job") && drDmNvu["Ma_Job"].ToString() != "" && !drDmNvu["Ma_Job"].ToString().Contains(",")) //Ma_Job
					{
						dr["Ma_Job"] = drDmNvu["Ma_Job"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Dt_CbNv") && drDmNvu["Ma_Dt_CbNv"].ToString() != "" && !drDmNvu["Ma_Dt_CbNv"].ToString().Contains(",")) //Ma_Dt_CbNv
					{
						dr["Ma_Dt_CbNv"] = drDmNvu["Ma_Dt_CbNv"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Thue") && drDmNvu["Ma_Thue"].ToString() != "" && !drDmNvu["Ma_Thue"].ToString().Contains(",")) //Ma_Thue
					{
						dr["Ma_Thue"] = drDmNvu["Ma_Thue"].ToString();
					}
					if (dtEditCt.Columns.Contains("Ma_Kho") && drDmNvu["Ma_Kho"].ToString() != "" && !drDmNvu["Ma_Kho"].ToString().Contains(",")) //Ma_Kho
					{
						dr["Ma_Kho"] = drDmNvu["Ma_Kho"].ToString();
					}
				}
				#endregion

                //if (strMa_Ct == "DTCP")
                //{
                //    if (txtMa_Nvu.Text == "BTXE")
                //    {
                //        //if (dgvEditCt1.Columns.Contains("Ma_Vt"))
                //        //    dgvEditCt1.Columns["Ma_Vt"].Visible = false;
                //        //if (dgvEditCt1.Columns.Contains("Ten_Vt"))
                //        //    dgvEditCt1.Columns["Ten_Vt"].Visible = false;

                //        if (dgvEditCt1.Columns.Contains("Ma_Xe"))
                //            dgvEditCt1.Columns["Ma_Xe"].Visible = true;
                //    }
                //    else
                //    {
                //        //if (dgvEditCt1.Columns.Contains("Ma_Vt"))
                //        //    dgvEditCt1.Columns["Ma_Vt"].Visible = true;
                //        //if (dgvEditCt1.Columns.Contains("Ten_Vt"))
                //        //    dgvEditCt1.Columns["Ten_Vt"].Visible = true;

                //        if (dgvEditCt1.Columns.Contains("Ma_Xe"))
                //            dgvEditCt1.Columns["Ma_Xe"].Visible = false;
                //    }
                //}

                if (dgvEditCt1.Columns.Contains("MA_VT"))
                {
                    //if (strMa_Ct != "DNX")
                        ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                    //else
                    //{
                    //    if (txtMa_Nvu.Text == "LVPP")
                    //    {
                    //        ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                    //        ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = "Ma_Nh_Vt = '45VP'";
                    //    }
                    //    else
                    //    {
                    //        ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                    //        ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = "Ma_Nh_Vt <> '45VP'";
                    //    }
                    //}
                }
			}

			this.drDmNvu = drLookup;
		}

		void txtMa_Ct_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Ct.Text.Trim();
			bool bRequire = true;
			string strKey = "(Table_Ct = '" + (string)drDmCt["Table_Ct"] + "')";

			DataRow drLookup = Lookup.ShowLookup("Ma_Ct", strValue, bRequire, strKey);

			if (bRequire && drLookup == null)
			{
				txtMa_Ct.Text = strMa_Ct;
				e.Cancel = true;
				return;
			}

			this.strMa_Ct = txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();
			this.drDmCt = drLookup;

		}
		private void DteNgay_Ct_Leave(object sender, EventArgs e)
		{
			txtSo_Ct.Text = Voucher.Cong_So_Ct_PYC_ThangTruoc(this, dteNgay_Ct.Text);
		}
		void txtMa_Tte_Leave(object sender, EventArgs e)
		{
			this.Ma_Tte_Valid();
			Voucher.Update_Detail(this);
			Voucher.Calc_Tien_All(this);			
		}
		
		void numTy_Gia_Leave(object sender, EventArgs e)
		{
			if (this.txtMa_Tte.Text.Trim() == Element.sysMa_Tte && this.numTy_Gia.Value == 0)
				this.numTy_Gia.Value = 1;

			Voucher.Update_Detail(this);
			Voucher.Calc_Tien_All(this);
			Voucher.Calc_Tien_Von_All(this);
		}

		void txtMa_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Hd.Text.Trim();
			bool bRequire = false;
			string strKeyValid = "";

			if (strValue == "/" || strValue == @"\")
			{
				DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "", strKeyValid);

				if (bRequire && drLookup == null)
					e.Cancel = true;

				if (drLookup == null)
				{
					txtMa_Hd.Text = string.Empty;
					lbtTen_Hd.Text = string.Empty;
				}
				else
				{
					txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
					lbtTen_Hd.Text = Voucher.GetTenHd(txtMa_Hd.Text); //drLookup["Ten_Hd"].ToString();
                    //dteNgay_Ky.Text = drLookup["Ngay_Ky"].ToString();
					if (txtMa_Hd.bTextChange)
					{
						txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
						DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", (string)drLookup["Ma_Dt"]);
						if (drDmDt != null)
						{
							lbtTen_Dt.Text = (string)drDmDt["Ten_Dt"];
							if ((string)drDmDt["Ong_Ba"] != string.Empty)
								txtOng_Ba.Text = (string)drDmDt["Ong_Ba"];
							else
								txtOng_Ba.Text = (string)drDmDt["Ten_Dt"];

							txtDia_Chi.Text = (string)drDmDt["Dia_Chi"];
						}
					}
				}
			}
			//else
			//{
			//    if (DataTool.SQLCheckExist("R81DMHD", new string[] { "Ma_Hd", "Ma_Data" }, new object[] { txtMa_Hd.Text, Element.sysMa_DvCs }))
			//    {
			//        string strMsg = "Ma_Hd = {" + txtMa_Hd.Text + "}, Ma_Data = {" + Element.sysMa_DvCs + "}";
			//        strMsg += Element.sysLanguage == enuLanguageType.English ? " already exist, do you want to add more?" : " đã tồn tại, Vui lòng kiểm tra lại mã hợp đồng?";
			//        Common.MsgYes_No(strMsg);
			//    }

			//}
		}

		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();
				if (Common.Inlist(strMa_Ct, "DTCP,DTXE"))
					txtDe_Xuat.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ten_Dt"].ToString();

				if (txtMa_Dt.Text != (string)drEditPh["Ma_Dt"])
				{
					txtOng_Ba.Text = drLookup["Ong_Ba"].ToString() == string.Empty ? drLookup["Ten_Dt"].ToString() : drLookup["Ong_Ba"].ToString();
                    
                    
					if (drLookup["Dia_Chi"].ToString() != string.Empty)
						txtDia_Chi.Text = drLookup["Dia_Chi"].ToString();

                    //if (drLookup["Ma_Kv"].ToString() != string.Empty)
                    //    txtTinh_Trang.Text = drLookup["Ma_Kv"].ToString();

                    //if (drLookup["Ma_Dt_CbNv"].ToString() != string.Empty)
                    //    txtMa_Dt_CbNv.Text = drLookup["Ma_Dt_CbNv"].ToString();
				}
			}

			Voucher.Update_Detail(this, "Ma_Dt");
		}
        
		void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv.Text = string.Empty;
				lbtTen_Dt_CbNv.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
			}
		}

		void dteNgay_DkGH_TextChanged(object sender, EventArgs e)
		{
            //Hashtable ht = new Hashtable();

            //ht.Add("NGAY", dteNgay_DkGH.Text);
            //ht.Add("SO", numHan_Tt.Value);
            //if (dteNgay_DkGH.Text != "  /  /")
            //{
            //    DateTime dteNgay = (DateTime)SQLExec.ExecuteReturnValue("SELECT dbo.fn_CongNgay(@NGAY, @SO)", ht, CommandType.Text);
            //    dteNgay_Gh.Text = dteNgay.ToString();
            //}
		}

		void txtMa_Kv_Validating(object sender, CancelEventArgs e)
		{
			//string strValue = txtTinh_Trang.Text.Trim();
			//bool bRequire = false;

			//DataRow drLookup = Lookup.ShowLookup("Ma_Kv", strValue, bRequire, "");

			//if (bRequire && drLookup == null)
			//    e.Cancel = true;

			//if (drLookup == null)
			//{
			//    txtTinh_Trang.Text = string.Empty;
			//    lbtTen_Kv.Text = string.Empty;
			//}
			//else
			//{
			//    txtTinh_Trang.Text = drLookup["Ma_Kv"].ToString();
			//    lbtTen_Kv.Text = drLookup["Ten_Kv"].ToString();
			//}
		}

		void txtGD_Duyet_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtGD_Duyet.Text.Trim();
			bool bRequire = false;
            string strKey = " Member_ID IN (SELECT Member_ID FROM R00MEMBERGROUP WHERE Member_Group_ID = 'NQL')";


			DataRow drLookup = Lookup.ShowLookup("Member_ID", strValue, bRequire, strKey);

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtGD_Duyet.Text = string.Empty;
				lbtTen_Gd_Duyet.Text = string.Empty;
			}
			else
			{
				txtGD_Duyet.Text = drLookup["Member_ID"].ToString();
				lbtTen_Gd_Duyet.Text = drLookup["Member_Name"].ToString();

			}
		}
		void txtMa_Dt_NCC2_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTen_Dt_NCC2.Text.Trim();
			bool bRequire = false;

			DataRow drLookup;
			if (strValue == "/" || strValue == @"\")
				drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");
			else if (SQLExec.ExecuteReturnDt("select * from VW_TEN_DT_MH where Ma_Dt like '%" + strValue + "%'").Rows.Count > 0)
				drLookup = Lookup.ShowLookup("Ten_Dt_NCC2", strValue, bRequire, "");
			else
				drLookup = null;

			if (drLookup == null)
				e.Cancel = false;

			if (drLookup != null)
			{
				txtTen_Dt_NCC2.Text = drLookup["Ten_Dt"].ToString();

			}
		}
		void txtMa_Dt_NCC3_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTen_Dt_NCC3.Text.Trim();
			bool bRequire = false;

			DataRow drLookup;
			if (strValue == "/" || strValue == @"\")
				drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "", "");
			else if (SQLExec.ExecuteReturnDt("select * from VW_TEN_DT_MH where Ma_Dt like '%" + strValue + "%'").Rows.Count > 0)
				drLookup = Lookup.ShowLookup("Ten_Dt_NCC3", strValue, bRequire, "");
			else
				drLookup = null;

			if (drLookup == null)
				e.Cancel = false;

			if (drLookup != null)
			{
				txtTen_Dt_NCC3.Text = drLookup["Ten_Dt"].ToString();

			}
		}
		//Attach File Báo giá

		//void btAttach1_Click(object sender, EventArgs e)
		//{
		//    OpenFileDialog fileDialog = new OpenFileDialog();
		//    fileDialog.RestoreDirectory = true;
		//    fileDialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*";

		//    if (fileDialog.ShowDialog() != DialogResult.OK)
		//        return;

		//    this.objFile = (object)System.IO.File.ReadAllBytes(fileDialog.FileName);

		//    if (objFile != null)
		//    {
		//        strFile_Tag = Path.GetExtension(fileDialog.FileName).Substring(1).ToUpper();

		//        drCurrent["TAG_Bg1"] = strFile_Tag;
		//        drCurrent["IMAGE_Bg1"] = objFile;

		//    }
		//}

		//void btOpen_Bg_NCC2_Click(object sender, EventArgs e)
		//{
		//    string strFileName = (string)drCurrent["Stt"] + drCurrent["Stt0"] + (string)drCurrent["Ma_Vt"] + ".pdf";
		//    string strPath = Application.StartupPath + @"\File\";

		//    if (!Directory.Exists(strPath))
		//        Directory.CreateDirectory(strPath);

		//    Hashtable htPara = new Hashtable();

		//    htPara.Add("STT", (string)drCurrent["Stt"]);
		//    htPara.Add("STT0", drCurrent["Stt0"]);


		//    object objFile = SQLExec.ExecuteReturnValue("SELECT Image_Bg2 FROM R04CTSO_Resource WHERE Stt = @Stt AND Stt0 = @Stt0 ", htPara, CommandType.Text);

		//    if (objFile != null && objFile != DBNull.Value && ((Byte[])objFile).Length > 0)
		//    {
		//        FileStream fileStream = new FileStream(strPath + strFileName, FileMode.Create, FileAccess.ReadWrite);
		//        fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);
		//        fileStream.Close();
		//        System.Diagnostics.Process.Start(strPath + strFileName);
		//    }
		//    else
		//        Common.MsgOk("Không có file attach");
		//}


		//hết

		void txtMa_Thue_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Thue.Text;
			bool bRequire = false;

			string strMa_Thue_Old = drEditPh["Ma_Thue"] == DBNull.Value ? string.Empty : (string)drEditPh["Ma_Thue"];

			DataRow drLookup = Lookup.ShowLookup("Ma_Thue", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
		
				numTTien_Nt3.ReadOnly = true;
				numTTien3.ReadOnly = true;
		
				numTTien_Nt3.TabStop = false;
				numTTien3.TabStop = false;		

				txtMa_Thue.Text = string.Empty;	

			}
			else
			{			
				numTTien_Nt3.ReadOnly = false;
				numTTien3.ReadOnly = false;
				
				numTTien_Nt3.TabStop = true;
				numTTien3.TabStop = true;				

				string strMa_Thue = (string)drLookup["Ma_Thue"];
				txtMa_Thue.Text = strMa_Thue;

				if (strMa_Thue != strMa_Thue_Old)
				{
					//Đưa Thue_Gtgt vào drEditPh vào để cập nhật xuống Detail
					this.drEditPh["Thue_Gtgt"] = drLookup["Thue_Suat"];
				}

				string strMa_Dt = txtMa_Dt.Text;
				DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", strMa_Dt);
			}

			Voucher.Update_Detail(this, "Ma_Thue, Thue_Gtgt");
			Voucher.Calc_Thue_Vat_All(this);
		}
		private void CheckInventory()
		{
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;

			frmCheckInventory frm = new frmCheckInventory();
			frm.Load(enuNew_Edit, drCurrent);

		}

		void frmCtPO_PT_Edit_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.isAccept)
			{
				if(Common.InlistLike(strMa_Ct,"PYCPT,PYCCK,DNXNL,DNX") && (bool)drEditPh["Duyet_Tp"])
				{
					return;
				}
				else
				{
				if (Common.MsgYes_No("Bạn có muốn thoát không ?", "YES"))
					e.Cancel = false;
				else
					e.Cancel = true;
				}
			}
		}

		void frmEditCtTien_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
                case Keys.F7:
                    this.CheckDMBHLD();
                    break;

				case Keys.F8:
                    if(!(bool)drEditPh["Duyet_GiamDoc"])
					    Voucher.DeleteRow(this, dgvEditCt1);
					break;

				case Keys.F10:
					this.InheritVoucher();
					break;

                case Keys.F6:
                    {
                        if (Voucher.AddRowMiddle_VTri(this, bdsEditCt, dtEditVTri))
                            dgvEditCt1.CurrentCell = dgvEditCt1.CurrentCell;
                    }
                    break;

				case Keys.F9:
					this.CheckGiaMua();
					break;
				
				case Keys.F4:

					tabControl1.SelectedIndex = (tabControl1.SelectedIndex == 0 ? 1 : 0);
					break;

					case Keys.Up:

					if (this.dgvEditCt1.Focused && this.dgvEditCt1.bIsCurrentFirstRow)
						this.SelectNextControl(dgvEditCt1, false, true, true, true);

					else if (this.dgvEditCt2.Focused && this.dgvEditCt2.bIsCurrentFirstRow)
						this.SelectNextControl(dgvEditCt2, false, true, true, true);

					break;
			}

			if (!this.dgvEditCt1.Focused)
				this.dgvEditCt1.ClearSelection();

			if (!this.dgvEditCt2.Focused)
				this.dgvEditCt2.ClearSelection();

            if (!this.dgvEditCt3.Focused)
                this.dgvEditCt3.ClearSelection();
		}

		void numTTien_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}
		void numTTien_Nt_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}
		void numTTien3_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}
		void numTTien_Nt3_Validated(object sender, EventArgs e)
		{
			TTien_Valid();
		}

		#endregion

		#region DataGridViewEvent

		//Xu ly Notice
		void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;

			if (dgvEditCt.CurrentCell == null)
				return;

			if (this.ActiveControl != dgvEditCt)
				return;

			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "GIA_NT, GIA, TIEN_NT, TIEN"))
			{
				//if ((bool)dgvEditCt1.CurrentRow.Cells["AUTO_COST"].Value == true)
				//{
				//    dgvCell.ReadOnly = true;
				//    dgvCell.Value = 0;
				//}
				//else
				//    dgvCell.ReadOnly = false;
			}
			else if (Common.Inlist(strColumnName, "MA_VT,TEN_VT") && !Common.Inlist(strMa_Ct, "DT"))
			{
                this.lbtNotice.Text = Voucher.GetTonCuoi_KKho(drCurrent);
                

                //if (Common.Inlist(strMa_Ct, "PYCTH,DNX") && drCurrent["Ma_Vt"] != "" && drCurrent["Ma_Vt"] != null)
                //{
                //    string strMa_Vt_Chung = SQLExec.ExecuteReturnValue("SELECT Ma_Vt_Chung FROM R81DMVT WHERE Ma_Vt = '" + drCurrent["Ma_Vt"] + "'").ToString();
                //    double iSo_Luong_Dm = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_DMBHLD ('" + txtMa_Dt.Text + "','" + strMa_Vt_Chung + "')")); //,'" + drCurrent["Ngay_Ct"].ToString() + "'
                //    if (iSo_Luong_Dm != 0)
                //    {
                //        this.lbtGhi_Chu.Visible = true;
                //        this.lbtGhi_Chu.Text = drCurrent["Ten_Vt"] + " tổng định mức đề nghị trong quý  " + iSo_Luong_Dm + " " + drCurrent["Dvt"];
                //    }
                //}
			}
            
			else if (Common.Inlist(strColumnName, "MA_VT,TEN_VT") && Common.Inlist(strMa_Ct, "DT"))
			{
				this.lbtNotice.Text = Voucher.GetGia_NCC(drCurrent);
			}
			else if (dgvCell.Tag != null)
			{
				this.lbtNotice.Text = dgvCell.Value.ToString() + " - " + (string)dgvCell.Tag;
			}

			this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
		}

		void dgvEditCt2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = dgvEditCt2.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
		}
		void dgvEditCt1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
            //drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            //DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
            //string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            //if (strColumnName == "MO_TA_KT" && strMa_Ct.StartsWith("DT"))
            //{
            //    frmCtMo_Ta_Kt frm = new frmCtMo_Ta_Kt();
            //    frm.Load(drCurrent);

            //}
		}
		void dgvEditCt1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (strColumnName == "ATTACH_FILE")
			{
                frmAttachFile frm = new frmAttachFile();
                frm.Load(strStt, Convert.ToInt16(drCurrent["Stt0"]), enuNew_Edit);
                if (frm.dtXuatVTriKho.Rows.Count > 0 && frm.Is_Accept == true) 
                {
                    //dtEditResource.Clear();

                    foreach (DataRow dr in frm.dtXuatVTriKho.Rows)
                    {
                        
                        drEditResource = dtEditResource.NewRow();
                        Common.CopyDataRow(dr, drEditResource);
                        //drEditResource["Image"] = dr["Image"];
                        drEditResource["File_Name"] = dr["File_Name"];
                        drEditResource["Tag"] = dr["Tag"];
                        drEditResource["Stt0"] = drCurrent["Stt0"];

                        dtEditResource.Rows.Add(drEditResource);
                    }
                    drCurrent["Open_File"] = frm.strFile_Name;
                }

              

			}
            		
          

			if (strColumnName == "UPDATE_MO_TA")
			{
				frmCtMo_Ta_Kt frm = new frmCtMo_Ta_Kt();
				frm.Load(drCurrent);

				if (frm.isAccept)
				{
					drCurrent["Mo_Ta_Kt"] = frm.txtMo_Ta_Kt.Text;
				}
			}

		}
		
		//Cai dat Lookup
		void dgvEditCt_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;

			//Xu ly phim Enter
			if (dgvEditCt.kLastKey == Keys.Enter)
			{
				dgvEditCt.kLastKey = Keys.None;

				if (this.CellKeyEnter())
					e.Cancel = true;
			}

			//Xu ly Lookup
			if (this.ActiveControl == null)
				return;

			if (this.ActiveControl == dgvEditCt || this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;
				DataGridViewCell dgvCell = dgvEditCt.CurrentCell;
				string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

				bool bLookup = true;

				if (strColumnName == "MA_VT")
					bLookup = dgvLookupMa_Vt(ref dgvCell);
				else if (strColumnName == "MA_VT_TT")
					bLookup = dgvLookupMa_Vt_Tt(ref dgvCell);
				else if (strColumnName == "MA_DT_MH")
					bLookup = dgvLookupMa_Dt_Mh(ref dgvCell);
				else if (strColumnName == "MA_BP_SD")
					bLookup = dgvLookupMa_Bp(ref dgvCell);
				else if (strColumnName == "MA_XE")
					bLookup = dgvLookupMa_Xe(ref dgvCell);
                else if (strColumnName == "MA_VTRI")
                    bLookup = dgvLookupMa_VTri(ref dgvCell);
                else if (strColumnName == "MA_TB" && Common.Inlist(strMa_Ct, "DTCP,DTXE"))
                    bLookup = dgvLookupMa_Tb(ref dgvCell);
                else if (strColumnName == "MA_TB" && !Common.Inlist(strMa_Ct, "DTCP,DTXE"))
                    bLookup = dgvLookupMa_Tb_Pyc(ref dgvCell);
                else if (strColumnName == "MA_TB" && strMa_Ct == "DNX")
                    bLookup = dgvLookupMa_Tb_Pyc(ref dgvCell);
				else if (strColumnName == "SO_TKHAI")
					bLookup = dgvLookupSo_TKhai(ref dgvCell);

				if (bLookup == false)
					e.Cancel = true;
			}
			else
				dgvEditCt.CancelEdit();
		}

		//Cai dat cac ham tinh toan
		void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt)
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

           

			if (Common.Inlist(strColumnName, "SO_LUONG0"))
			{
              
				if(Common.InlistLike(strMa_Ct, "PYCCK"))
					drCurrent["So_Luong_PXCD"] = drCurrent["So_Luong0"];
               
                if (Common.InlistLike(strMa_Ct, "DNXNL") && drCurrent["Ma_Xe"] == "KHAC" && Convert.ToDouble(drCurrent["So_Luong0"]) > Convert.ToDouble(drCurrent["So_Luong_Dm"]))
                {
                    Common.MsgOk("Số lượng yêu cầu không được lớn hơn số lượng định mức");
                    drCurrent["So_Luong0"] = drCurrent["So_Luong_Dm"];
                }

				drCurrent["So_Luong9"] = drCurrent["So_Luong0"];
				drCurrent["So_Luong_Tp"] = drCurrent["So_Luong0"];
				drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong0"];
                drCurrent["So_Luong_KtTc"] = drCurrent["So_Luong0"];
				drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong0"];

				
				Voucher.Calc_So_Luong(drCurrent, this);
				Voucher.Update_TTien(this);	
			}
			if (Common.Inlist(strColumnName, "SO_LUONG_PXCD"))
			{
				drCurrent["So_Luong9"] = drCurrent["So_Luong_PXCD"];
				drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong_PXCD"];
				drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong_PXCD"];


				Voucher.Calc_So_Luong(drCurrent, this);
				Voucher.Update_TTien(this);
			}
			if (Common.Inlist(strColumnName, "SO_LUONG_TP"))
			{
				drCurrent["So_Luong9"] = drCurrent["So_Luong_Tp"];
				drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong_Tp"];
                drCurrent["So_Luong_KtTc"] = drCurrent["So_Luong_Tp"];
				drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong_Tp"];
				

				Voucher.Calc_So_Luong(drCurrent, this);
				Voucher.Update_TTien(this);
			}
			if (Common.Inlist(strColumnName, "SO_LUONG_KTCDAT"))
			{
				drCurrent["So_Luong_KhVt"] = drCurrent["So_Luong_KtCdAt"];
                drCurrent["So_Luong_KtTc"] = drCurrent["So_Luong_KtCdAt"];
				drCurrent["So_Luong9"] = drCurrent["So_Luong_KtCdAt"];

				Voucher.Calc_So_Luong(drCurrent, this);
				Voucher.Update_TTien(this);
			}
			if (Common.Inlist(strColumnName, "SO_LUONG_KHVT"))
			{
                drCurrent["So_Luong_KtTc"] = drCurrent["So_Luong_KhVt"];
				drCurrent["So_Luong9"] = drCurrent["So_Luong_KhVt"];

				Voucher.Calc_So_Luong(drCurrent, this);
				Voucher.Update_TTien(this);
			}

            if (Common.Inlist(strColumnName, "SO_KM_DAU,SO_KM_CUOI,SO_LUONG_DM"))
			{
				DataRow drDmXe = DataTool.SQLGetDataRowByID("R81DMXE","Ma_Xe",(string)drCurrent["Ma_Xe"]);
                drCurrent["So_Luong_Dm"] = ((Convert.ToDouble(drCurrent["So_Km_Cuoi"]) - Convert.ToDouble(drCurrent["So_Km_Dau"])) * Convert.ToDouble(drDmXe["Sl_Dm"])) / Convert.ToDouble(drDmXe["He_So"]);
			}
            if (Common.Inlist(strColumnName, "MA_VT,TEN_VT") && strMa_Ct == "PYCTH")// && (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)) //
            {
                string strMa_Bp = string.Empty;
              
                //if(txtMa_Dt.Text == "PXCAN" || txtMa_Dt.Text == "PXLUYEN")
                //    strMa_Bp = "PXSX";
                //else
                    strMa_Bp = txtMa_Dt.Text;
               
                DataTable dtThTx = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMVTTHTX WHERE Ma_Vt = '" + drCurrent["Ma_Vt"] + "' AND Ma_Bp = '" + strMa_Bp +"'");
                //DataRow drThTx;
                if(dtThTx.Rows.Count != 0)
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("MA_VT", drCurrent["Ma_Vt"]);
                    ht.Add("MA_BP", txtMa_Dt.Text);
                    ht.Add("NGAY_CT", Library.StrToDate(dteNgay_Ct.Text));

                    drCurrent["Sl_CL_DmTh"] = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_GetSlDmTh (@MA_VT,@MA_BP,@NGAY_CT)", ht, CommandType.Text));
                    //drThTx = dtThTx.Rows[0];
                    //drCurrent["Muc_Dich"] = drThTx["Ghi_Chu"];
                }
            }
			if (Common.Inlist(strColumnName, "SO_LUONG9,GIA_NT9,TIEN_NT9,TIEN"))
			{
				Voucher.Calc_So_Luong(drCurrent, this);
				Voucher.Update_TTien(this);
                Voucher.Adjust_TThue_Vat(this, true);
			}

            if (Common.Inlist(strColumnName, "SO_LUONG0") && Common.Inlist(strMa_Ct,"PYCTH,DNX"))
            {
                string strMa_Vt_Chung = SQLExec.ExecuteReturnValue("SELECT Ma_Vt_Chung FROM R81DMVT WHERE Ma_Vt = '" + drCurrent["Ma_Vt"] + "'").ToString();
                double iSo_Luong_Dm = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT dbo.fn_DMBHLD ('" + txtMa_Dt.Text + "','" + strMa_Vt_Chung + "')")); //,'" + drCurrent["Ngay_Ct"].ToString() + "'

                if (Convert.ToDouble(drCurrent["So_Luong0"]) > iSo_Luong_Dm && iSo_Luong_Dm != 0)
                    CheckDMBHLD();

                if (Convert.ToDouble(drCurrent["So_Luong0"]) > Convert.ToDouble(drCurrent["So_Luong_TonKho"]) && strMa_Ct == "DNX")
                {
                    Common.MsgOk("Số lượng DNX không lớn hơn SL tồn kho");

                    drCurrent["So_Luong0"] = drCurrent["So_Luong_TonKho"];
                    drCurrent["So_Luong9"] = drCurrent["So_Luong_TonKho"];
                    drCurrent["So_Luong"] = drCurrent["So_Luong_TonKho"];
                    drCurrent["So_Luong_KtCdAt"] = drCurrent["So_Luong_TonKho"];
                }
				
            }

			else if (Common.Inlist(strColumnName, "TIEN"))
			{
				Voucher.Calc_Tien(drCurrent, this);
				Voucher.Update_TTien(this);
			}
			//else if (Common.Inlist(strColumnName, "DVT"))
			//{
			//    UpdateTonKho();
			//}
			bdsEditCt.EndEdit();//Cap nhat lai DataSource                   
		}

		void dgvEditCt1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;

			if (dgvEditCt.CurrentCell == null)
				return;

			if (this.ActiveControl != dgvEditCt)
				return;

			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (strColumnName == "MA_VT")
				this.bMa_Vt_Changed = true;

		}

		//Xử lý Dvt
		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
                if (dgvEditCt1.CurrentCell.OwningColumn.DataPropertyName == "DVT" && (string)drCurrent["Ma_Vt"] != "" && !Common.Inlist((string)drCurrent["Ma_Vt"], "DVSCN"))
				{
					drCurrent = ((DataRowView)bdsEditCt.Current).Row;
					string strMa_Vt = (string)drCurrent["Ma_Vt"];
					string strDvt_Old = (string)drCurrent["Dvt"];
					string strDvt_Chuan = string.Empty;

					DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", strMa_Vt);
					strDvt_Chuan = (string)drDmVt["Dvt"];

                    if (Common.InlistLike(strMa_Ct, "DT") && drDmVt["Dvt1"].ToString() == "")
                    {
                        dgvEditCt1.Columns["DVT"].ReadOnly = false;
                        return;
                    }
                    //if (Common.InlistLike(strMa_Ct,"PYCPT,PYCCK,NCTH,PYCTH,DNX,DTVPP"))
                    //{
						string inputMask = (string)drDmVt["Dvt"];

						for (int i = 1; i <= 3; i++)
							inputMask += (string)drDmVt["Dvt" + i] == string.Empty ? string.Empty : "," + (string)drDmVt["Dvt" + i];

						if (inputMask != string.Empty)
							inputMask += "," + inputMask;
						if (inputMask == null || inputMask == string.Empty)
							return;

						string[] strArrInputMask = inputMask.Split(',');
						for (int i = 0; i <= strArrInputMask.Length - 1; i++)
							if (strArrInputMask[i] == strDvt_Old)
							{
								drCurrent["Dvt"] = strArrInputMask[i + 1];
								break;
							}

						if ((string)drCurrent["Dvt"] == strDvt_Chuan)
							drCurrent["He_So9"] = 1;
						else
							for (int i = 1; i <= 3; i++)
								if ((string)drDmVt["Dvt" + i] == (string)drCurrent["Dvt"])
									drCurrent["He_So9"] = drDmVt["He_So" + i];

						Voucher.Calc_So_Luong(drCurrent, this);
                   

				}
		}

		#endregion

		#region DataGridViewLookup		

		private bool dgvLookupMa_Vt(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;
            
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			
            DataRow drLookup;
            if ((Common.Inlist(strMa_Ct, "PYCPT,PYCCK")))
                drLookup = Lookup.ShowLookup("Ma_Vt_Pt", strValue, bRequire, "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND LEN(Ma_Vt) = 9 AND Is_Hide = 0", "");
            else if (Common.Inlist(strMa_Ct, "DTNA,BBNA"))
                drLookup = Lookup.ShowLookup("Ma_Vt_Pt", strValue, bRequire, "Ma_Nh_Vt LIKE 'VTNA%' OR Ma_Vt LIKE 'F%'", "");
            else if (Common.Inlist(strMa_Ct, "DTCP,DTXE"))                
                drLookup = Lookup.ShowLookup("Ma_Vt_Pt", strValue, bRequire, "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%'", "");
            else if (strMa_Ct == "PYCTH")
                drLookup = Lookup.ShowLookup("Ma_Vt_Pt", strValue, bRequire, "Is_TieuHao = 1", "");
            else if (strMa_Ct == "DTNA")
                drLookup = Lookup.ShowLookup("Ma_Vt_Pt", strValue, bRequire, " Ma_Vt  LIKE 'VTNA%'", "");
            else if (strMa_Ct == "DT")
            {
                if(DataTool.SQLCheckExist("vw_VTTD","Ma_Vt",drCurrent["Ma_Vt_Tt"]))
                    drLookup = Lookup.ShowLookup("Ma_VtTd", strValue, bRequire, "Ma_VtTd LIKE '%" + drCurrent["Ma_Vt_Tt"] + "%'", "");
                else
                    drLookup = Lookup.ShowLookup("Ma_Vt_Pt", strValue, bRequire, "", "");
            }
            else
                drLookup = Lookup.ShowLookup("Ma_Vt_Pt", strValue, bRequire, "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND LEN(Ma_Vt) = 9", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				string strMa_Vt_Old = string.Empty;
				
				if (drCurrent.HasVersion(DataRowVersion.Original))
					strMa_Vt_Old = drCurrent["Ma_Vt", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt", DataRowVersion.Original];
				else
					strMa_Vt_Old = drCurrent["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Vt"];

				string strMa_Vt = (string)drLookup["Ma_Vt"];

				//dgvEditCt1.CancelEdit();

				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				dgvCell.DataGridView.EndEdit();
				
				//La vat tu dich vu                
				if ((string)drLookup["Loai_Vt"] == "0")
				{
					if ((string)drCurrent["Ten_Vt"] == string.Empty)
						drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

					drCurrent["Dvt"] = drLookup["Dvt"];
				}
				else
				{
                    //if (strMa_Vt != strMa_Vt_Old) tạm bỏ đi để cập nhật lai thông tin
                    //{
						if (Common.Inlist(strMa_Ct, "PYCPT,PYCCK,NCTH,PYCTH,BBPT,BBTH,DT"))
							drCurrent["Ten_Vt"] = drLookup["Ten_Vt_Chuan"] == null || drLookup["Ten_Vt_Chuan"] == "" ? drLookup["Ten_Vt"] : drLookup["Ten_Vt_Chuan"];
						else
							drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];

						if (dgvEditCt1.Columns.Contains("Mo_Ta_Kt"))
						{
                            string strMo_Ta_Kt = string.Empty;
                            if (!drLookup["Ma_Vt"].ToString().StartsWith("F"))
                                strMo_Ta_Kt = drLookup["Ten_Vt"].ToString().Substring(drLookup["Ten_Vt_Chuan"].ToString().Length);
                            else
                            {
                                if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] == "")
                                    strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ". " + drLookup["Ten_Nha_Sx"];
                                else if (drLookup["Thong_So_Kt"] == "" && drLookup["Ma_Tb_Nha_Sx"] != "")
                                    strMo_Ta_Kt = "(" + drLookup["Ma_Tb_Nha_Sx"] + ") " + drLookup["Ten_Nha_Sx"];
                                else if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] != "")
                                    strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ". " + "(" + drLookup["Ma_Tb_Nha_Sx"] + ") " + drLookup["Ten_Nha_Sx"];
                                else
                                    strMo_Ta_Kt = "";

                            }
                            

							drCurrent["Mo_Ta_Kt"] = strMo_Ta_Kt;

                        //}
                       

						drCurrent["Dvt"] = drLookup["Dvt"];
						drCurrent["He_So9"] = 1;

						//Voucher.Update_CSGia(drCurrent); //Cap nhat lai CS Gia khi sua Ma_Vt
						Voucher.Calc_So_Luong(drCurrent, this);
                        
                        if(Common.Inlist(strMa_Ct, "PYCPT,PYCTH,PYCCK,DNX"))
                        {
                            double dbTon_Cuoi = 0;
                            Voucher.GetTonCuoi_KKho(drCurrent, ref dbTon_Cuoi);
                            drCurrent["So_Luong_TonKho"] = dbTon_Cuoi;
                        }
					}
					else
					{
						if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
							drCurrent["Dvt"] = drLookup["Dvt"];
					}
				}
			}
			return true;
		}

		private bool dgvLookupMa_Vt_Tt(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				drCurrent = ((DataRowView)bdsEditCt.Current).Row;

				dgvEditCt1.CancelEdit();
				dgvCell.Value = drLookup["Ma_Vt"].ToString();
				dgvCell.Tag = drLookup["Ten_Vt"].ToString();

				drCurrent["Ma_Vt_Tt"] = drLookup["Ma_Vt"].ToString();
				drCurrent["Ten_Vt_Tt"] = drLookup["Ten_Vt"].ToString();

				if (drCurrent["Ma_Vt"] == "")
				{
					drCurrent["Ma_Vt"] = drLookup["Ma_Vt"].ToString();
					drCurrent["Ten_Vt"] = drLookup["Ten_Vt"].ToString();
				}
			}

			return true;
		}
        private bool dgvLookupMa_Tb(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = true;
            string strKey = "";

            strKey = " Ngay_Kt_Sd = '19000101'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Tb", strValue, bRequire, strKey, "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                string strMa_Vt_Old = string.Empty;

                if (drCurrent.HasVersion(DataRowVersion.Original))
                    strMa_Vt_Old = drCurrent["Ma_Tb", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Tb", DataRowVersion.Original];
                else
                    strMa_Vt_Old = drCurrent["Ma_Tb"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Tb"];

                string strMa_Vt = (string)drLookup["Ma_Tb"];

                //dgvEditCt1.CancelEdit();

                dgvCell.Value = drLookup["Ma_Tb"].ToString();
                dgvCell.Tag = drLookup["Ten_Tb"].ToString();
                strMa_Tb = drLookup["Ma_Tb"].ToString();
                drCurrent["Ten_Tb"] = drLookup["Ten_Tb"];
              
                if(drCurrent["Ma_Vt"].ToString() == "")
                    drCurrent["Ma_Vt"] = "DVSCN";
               
                dgvCell.DataGridView.EndEdit();
            }
            return true;
        }
        private bool dgvLookupMa_Tb_Pyc(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            if (txtMa_Nvu.Text != "LVPP" && strMa_Ct == "DNX")
                bRequire = true;
            
            string strKey = "";

            //strKey = "Ma_Nh_Tb = '" + strMa_Nh_Tb + "'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Tb", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                string strMa_Vt_Old = string.Empty;

                if (drCurrent.HasVersion(DataRowVersion.Original))
                    strMa_Vt_Old = drCurrent["Ma_Tb", DataRowVersion.Original] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Tb", DataRowVersion.Original];
                else
                    strMa_Vt_Old = drCurrent["Ma_Tb"] == DBNull.Value ? string.Empty : (string)drCurrent["Ma_Tb"];

                string strMa_Vt = (string)drLookup["Ma_Tb"];

                //dgvEditCt1.CancelEdit();

                dgvCell.Value = drLookup["Ma_Tb"].ToString();
                dgvCell.Tag = drLookup["Ten_Tb"].ToString();
                strMa_Tb = drLookup["Ma_Tb"].ToString();
                drCurrent["Ten_Tb"] = drLookup["Ten_Tb"];
                //drCurrent["Ma_Vt"] = "DVSCN";
                dgvCell.DataGridView.EndEdit();
            }
            return true;
        }
        private bool dgvLookupMa_VTri(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            string strFilter = "Type='VITRI'";

            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "VITRI");
            DataRow drLookup = Lookup.ShowLookup("Ma_VTri", strValue, bRequire, strFilter, "", htField);

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsEditCt.Current).Row;

                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Type_ID"].ToString();
                dgvCell.Tag = drLookup["Type_Name"].ToString();
            }
            return true;
        }
		private bool dgvLookupSo_TKhai(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("So_TKhai", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["So_TKhai"].ToString();
				dgvCell.Tag = drLookup["So_TKhai"].ToString();

				drCurrent["Ngay_TKhai"] = drLookup["Ngay_TKhai"];

				dgvCell.DataGridView.EndEdit();
			}
			return true;
		}
		private bool dgvLookupMa_Xe(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Xe", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["Ma_Xe"].ToString();
				dgvCell.Tag = drLookup["Ten_Xe"].ToString();
				drCurrent["Ten_Xe"] = drLookup["Ten_Xe"].ToString();
                Hashtable ht = new Hashtable();
                ht.Add("MA_XE", drLookup["Ma_Xe"].ToString());
                ht.Add("NGAY_CT", dteNgay_Ct.Text);
                drCurrent["So_Km_Dau"] = SQLExec.ExecuteReturnValue("select dbo.fn_So_Km_Cuoi (@Ma_Xe,@Ngay_Ct)", ht, CommandType.Text);
                
                if(strMa_Ct == "DNXNL")
				    drCurrent["Ma_Vt"] = drLookup["Ma_Vt"].ToString();

				dgvCell.DataGridView.EndEdit();
			}

			return true;
		}
		private bool dgvLookupMa_Bp(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				dgvCell.Value = drLookup["Ma_Bp"].ToString();
				dgvCell.Tag = drLookup["Ten_Bp"].ToString();

				dgvCell.DataGridView.EndEdit();
			}

			return true;
		}
		private bool dgvLookupMa_Dt_Mh(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = false;
			string strKey = "Ma_Vt = '" + drCurrent["Ma_Vt"] + "'";

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_Mh", strValue, bRequire, strKey);
			
			if (bRequire && drLookup == null)
				return false;

			if (drLookup == null)
			{
				dgvCell.Value = string.Empty;
				dgvCell.Tag = string.Empty;
			}
			else
			{
				DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", (string)drLookup["Ma_Dt_Mh"]);

				drCurrent["Ma_Dt_Mh"] = drLookup["Ma_Dt_Mh"];
				drCurrent["Ten_Dt_Mh"] = drDmDt["Ten_Dt"];
				drCurrent["Gia_Nt9"] = drLookup["Gia"];
				drCurrent["Gia"] = drLookup["Gia"];
				drCurrent["Gia_Nt"] = drLookup["Gia"];
				
			}
			return true;
		}
		#endregion

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			this.DataGridView_Language();

			this.dgvEditCt1.ClearSelection(); //Chi co tac dung sau khi show form

			cboSaveOption.Items.Clear();
			cboSaveOption.Items.AddRange(new string[] { "1-Lưu & Nhập tiếp", "2-Lưu & Đóng lại", "3-Lưu - In & Nhập tiếp", "4-Lưu - In & Đóng lại", "5-In & Nhập tiếp", "6-In & Đóng lại" });

			if (enuNew_Edit == enuEdit.Edit)
			{
				cboSaveOption.SelectedIndex = 1;
			}
			else
			{
				if (Common.GetBufferValue("Voucher_Save_Option") != null && Common.GetBufferValue("Voucher_Save_Option").ToString().Length > 0)
					cboSaveOption.SelectedIndex = int.Parse(Common.GetBufferValue("Voucher_Save_Option").Substring(0, 1)) - 1;
				else
					cboSaveOption.SelectedIndex = 0;
			}

			if (this.enuNew_Edit == enuEdit.Edit)
			{
				if (!Element.sysIs_Admin)
				{
					string strCreate_User = (string)drEditPh["Create_Log"];

					if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
					{
						string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

						if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
						{
							if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
							{
								this.btgAccept.btAccept.Enabled = false;
								return;
							}
						}
					}
				}
			}
		}

		private void rsLabel8_Click(object sender, EventArgs e)
		{

		}

        	
	}
}
