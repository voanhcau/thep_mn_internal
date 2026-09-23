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

namespace RosyModule.Machinery
{
	public partial class frmCtBTTB_Edit : frmVoucher_Edit
	{
		private string strModule = "06";
        private DataRow drCurrent_VtTb;

      
        string strMa_Nh_Tb;
        string strMa_Tb;
		object objFile = null;
		string strFile_Tag = string.Empty;

        DataTable dtEditResource;
        DataRow drEditResource;
        BindingSource bdsEditResource = new BindingSource();

        DataTable dtEditSuatAnNT;
        DataRow drEditSuatAnNT;
        BindingSource bdsEditSuatAnNT = new BindingSource();

        string strStt_Org = string.Empty;

		#region Contructor

		public frmCtBTTB_Edit()
		{
			InitializeComponent();
			this.FormClosing += new FormClosingEventHandler(frmCtPO_PT_Edit_FormClosing);
			this.KeyDown += new KeyEventHandler(frmEditCtTien_KeyDown);

			this.btImportExcel.Click += new EventHandler(btnImportExcel_Click);
			this.btInherit.Click += new EventHandler(btInherit_Click);
            this.btInherit_CV.Click += new EventHandler(btInherit_CV_Click);
         

			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nvu_Validating);
			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);	
			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            txtMa_Nh_Tb.Validating += new CancelEventHandler(txtMa_Nh_Tb_Validating);
            txtGD_Duyet.Validating += new CancelEventHandler(txtGD_Duyet_Validating);
            txtMa_DotBT.Validating += new CancelEventHandler(txtMa_DotBT_Validating);
            txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
         
			txtMa_Tte.Leave += new EventHandler(txtMa_Tte_Leave);
			numTy_Gia.Leave += new EventHandler(numTy_Gia_Leave);
            
            
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
            {
                this.strStt = drEdit["Stt"].ToString();
                strMa_Nh_Tb = drEdit["Ma_Nh_Tb"].ToString();
                strMa_Tb = drEdit["Ma_Tb"].ToString();
            }
            
                

			this.Build();
			this.FillData();
			this.Init_Ct();
			this.LoadFileNameAttachFile();
			Common.ScaterMemvar(this, ref drEditPh);

			
			this.BindingLanguage();
			this.LoadDicName();

			if (!this.Visible)
				this.ShowDialog();
            else
            {
                this.ActiveControl = txtMa_Nvu;
                this.dgvEditCt1.ClearSelection();

                this.Ma_Tte_Valid();
            }
        }

		

		#endregion

		#region Phuong thuc

		private void Build()
		{
           
			dgvEditCt1.bSortMode = false;
			dgvEditCt1.strZone = (string)drDmCt["Zone_EditCt1"];
			dgvEditCt1.BuildGridView();

            dgvEditCt2.bSortMode = false;
            dgvEditCt2.strZone = (string)drDmCt["Zone_EditCt2"];
            dgvEditCt2.BuildGridView();

            dgvEditCt3.bSortMode = false;
            dgvEditCt3.strZone = "DKSUATANNT2";
            dgvEditCt3.BuildGridView();

            if (dgvEditCt1.Columns.Contains("Ten_Vt"))
            {
                dgvEditCt1.Columns["Ten_Vt"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvEditCt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
			if (dgvEditCt1.Columns.Contains("Noi_Dung"))
			{
                dgvEditCt1.Columns["Noi_Dung"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
				dgvEditCt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
			}

            if (dgvEditCt1.Columns.Contains("Ghi_Chu"))
            {
                dgvEditCt1.Columns["Ghi_Chu"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvEditCt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvEditCt1.Columns.Contains("Nguyen_Nhan"))
            {
                dgvEditCt1.Columns["Nguyen_Nhan"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvEditCt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvEditCt1.Columns.Contains("Phuong_An"))
            {
                dgvEditCt1.Columns["Phuong_An"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvEditCt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvEditCt1.Columns.Contains("Ten_Vt_HH"))
            {
                dgvEditCt1.Columns["Ten_Vt_HH"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvEditCt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if (dgvEditCt1.Columns.Contains("Ket_Qua"))
            {
                dgvEditCt1.Columns["Ket_Qua"].DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
                dgvEditCt1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            if (dgvEditCt1.Columns.Contains("MA_VT"))
            {
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).bUseAutoDropDown = true;
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Vt"]).strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%'";
            }
            if (dgvEditCt1.Columns.Contains("MA_TB") && !Common.Inlist(strMa_Ct,"KHBT,BBBN"))
            {
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Tb"]).bUseAutoDropDown = true;
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Tb"]).strLookupKeyFilter = "Ma_Nh_Tb LIKE '" + strMa_Nh_Tb + "%' AND Ngay_Kt_Sd = '19000101'";
            }
           
            if (dgvEditCt1.Columns.Contains("Noi_Dung") && Common.InlistLike(strMa_Ct, "BTNB,BTTT,BTKH"))
            {
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Noi_Dung"]).bUseAutoDropDown = true;
                ((dgvTextBoxColumn)dgvEditCt1.Columns["Noi_Dung"]).strLookupKeyFilter = "Ma_Nh_Tb = '" + strMa_Nh_Tb + "' AND Ma_Tb = '" + strMa_Tb + "'";
            }
            
            if (!Common.Inlist(strMa_Ct, "BBHH,GVTC"))
            {
                txtNguyen_Nhan.Visible = false;
                txtTinh_Trang_Tb.Visible = false;
                txtNoi_Dung.Visible = false;
                txtPhuong_An.Visible = false;
                txtTinh_Trang_Th.Visible = false;

                lbtPhuong_An1.Visible = false;
                lbtPhuong_An2.Visible = false;
                lbtNguyen_Nhan.Visible = false;
                lbtTinh_Trang_Tb.Visible = false;
                lbtNoi_Dung.Visible = false;
                lbtTinh_Trang_Th.Visible = false;
                lbtTinh_Trang_Th1.Visible = false;

            }
            else if (Common.Inlist(strMa_Ct, "GVTC"))
            {
                txtNguyen_Nhan.Visible = false;
                txtTinh_Trang_Tb.Visible = false;
                txtNoi_Dung.Visible = false;
                //txtPhuong_An.Visible = false;
                txtTinh_Trang_Th.Visible = false;

                //lbtPhuong_An1.Visible = false;
                lbtPhuong_An2.Visible = false;
                lbtNguyen_Nhan.Visible = false;
                lbtTinh_Trang_Tb.Visible = false;
                lbtNoi_Dung.Visible = false;
                lbtTinh_Trang_Th.Visible = false;
                lbtTinh_Trang_Th1.Visible = false;

                lbtPhuong_An1.Text = "Phương Án";
            }

            if (Common.Inlist(strMa_Ct, "GDKC,GNTC"))
            {
                lblMa_Dt.Text = "Mã nhà thầu";
                txtMa_Dt.strLookupKeyFilter = "Ma_Dt NOT LIKE 'P%'";

                if (strMa_Ct == "GNTC")
                {
                    lbtTinh_Trang_Tb.Visible = true;
                    txtTinh_Trang_Tb.Visible = true;
                    lbtNguyen_Nhan.Visible = true;
                    txtNguyen_Nhan.Visible = true;
                    //gbGioVaoRa.Visible = true;

                    lbtTinh_Trang_Tb.Text = "Khu vực làm việc";
                    lbtNguyen_Nhan.Text = "Bộ phận QL và giám sát";
                }
            }
            if (!Common.Inlist(strMa_Ct, "GNTC"))
                tabControl1.TabPages.Remove(tabPage3);

            DataGridView_Language();
		}


		private void DataGridView_Language()
		{
            if (dgvEditCt1.Columns.Contains("Ma_Dt_CbNv_List") && strMa_Ct == "BTNB")
                dgvEditCt1.Columns["Ma_Dt_CbNv_List"].HeaderText = "Người thực hiện";

            if (dgvEditCt1.Columns.Contains("Ngay_BD") && strMa_Ct == "BTNB")
                dgvEditCt1.Columns["Ngay_BD"].HeaderText = "Ngày thực hiện";

            if (dgvEditCt1.Columns.Contains("Ten_Vt_HH") && strMa_Ct == "BBHH")
                dgvEditCt1.Columns["Ten_Vt_HH"].HeaderText = "Mức độ hư hỏng";

            if (dgvEditCt1.Columns.Contains("IS_KH") && strMa_Ct == "CTSC")
                dgvEditCt1.Columns["IS_KH"].HeaderText = "Có đưa vào sử dụng sau bảo trì";

            if (dgvEditCt1.Columns.Contains("IS_KH") && Common.Inlist(strMa_Ct, "BBBN,BBXE"))
                dgvEditCt1.Columns["IS_KH"].HeaderText = "Không đưa TB vào sử dụng";
            
            if (dgvEditCt1.Columns.Contains("Noi_Dung"))
                dgvEditCt1.Columns["Noi_Dung"].HeaderText = "Nội dung thực hiện";
            //else
            //    dgvEditCt1.Columns["Noi_Dung"].HeaderText = "Nội dung yêu cầu";

            if (dgvEditCt1.Columns.Contains("Ten_Vt_HH") && Common.InlistLike(strMa_Ct, "BTTT,BTKH"))
                dgvEditCt1.Columns["Ten_Vt_HH"].HeaderText = "Người thực hiện";

            if (dgvEditCt1.Columns.Contains("Phuong_An") && Common.Inlist(strMa_Ct, "BBBN,BBXE"))
                dgvEditCt1.Columns["Phuong_An"].HeaderText = "Kết luận";
           
            if (strMa_Ct == "GRVC")
            {
                if (dgvEditCt1.Columns.Contains("So_Luong0"))
                    dgvEditCt1.Columns["So_Luong0"].HeaderText = "Khối lượng về";
                
                if (dgvEditCt1.Columns.Contains("Is_Kh"))
                    dgvEditCt1.Columns["Is_Kh"].HeaderText = "Có nhập về";
            }
           
            //Ma_Dt
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
                {
                    
                    if (!Element.sysIs_Admin)
                    {
                        drEdit["Ma_Dt"] = (string)SQLExec.ExecuteReturnValue("SELECT MIN(Ma_Dt) FROM R00MEMBERGROUP T1 JOIN (SELECT Ma_Bp, Ma_Dt FROM R81DMDT WHERE Ma_Nh_Dt = '400') T2 " +
                        " ON T1.Member_Group_ID = T2.Ma_Bp " +
                        "WHERE Member_Id = '" + Element.sysUser_Id + "'");

                        if ((drEdit["Ma_Dt"].ToString() != string.Empty || drEdit["Ma_Dt"].ToString() != null || drEdit["Ma_Dt"].ToString() != "") && !Common.Inlist(strMa_Ct, "GDKC,GNTC"))
                            txtMa_Dt.Text = drEdit["Ma_Dt"].ToString();
                        else
                            txtMa_Dt.Text = "";
                    }
                    
                }
                
			}

			//Ma_Dt_CbNv
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				drEdit["Ma_Dt_CbNv"] = (string)SQLExec.ExecuteReturnValue("SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE Member_Id = '" + Element.sysUser_Id + "'");
				txtMa_Dt_CbNv.Text = drEdit["Ma_Dt_CbNv"].ToString();
				
			}

            if (dgvEditCt1.Columns.Contains("Noi_Dung") && strMa_Ct == "CTSC")
                dgvEditCt1.Columns["Noi_Dung"].HeaderText = "Người nhận việc";

            if (dgvEditCt1.Columns.Contains("Ten_Vt_HH") && strMa_Ct == "CTSC")
                dgvEditCt1.Columns["Ten_Vt_HH"].HeaderText = "Người phối hợp";

            if (dgvEditCt1.Columns.Contains("Noi_Dung") && strMa_Ct == "GDKC")
                dgvEditCt1.Columns["Noi_Dung"].HeaderText = "Tên vật tư - phương tiện - nhãn hiệu - TP hóa học";

            if (dgvEditCt1.Columns.Contains("Ghi_Chu") && strMa_Ct == "GDKC")
                dgvEditCt1.Columns["Ghi_Chu"].HeaderText = "Ghi chú - Tên lái xe";

            if (dgvEditCt1.Columns.Contains("Ten_Vt") && strMa_Ct == "GDKC")
                dgvEditCt1.Columns["Ten_Vt"].HeaderText = "Mã số";
           ////
            if (dgvEditCt1.Columns.Contains("Noi_Dung") && strMa_Ct == "GNTC")
                dgvEditCt1.Columns["Noi_Dung"].HeaderText = "Họ và tên";
            if (dgvEditCt1.Columns.Contains("Ten_Vt") && strMa_Ct == "GNTC")
                dgvEditCt1.Columns["Ten_Vt"].HeaderText = "Năm sinh";
            if (dgvEditCt1.Columns.Contains("Phuong_An") && strMa_Ct == "GNTC")
                dgvEditCt1.Columns["Phuong_An"].HeaderText = "Số CMT/CCCD";

            ////
            if (dgvEditCt1.Columns.Contains("Ten_Vt") && strMa_Ct == "GCTC")
                dgvEditCt1.Columns["Ten_Vt"].HeaderText = "Số xe";

            if (dgvEditCt1.Columns.Contains("HBUI") && strMa_Ct == "GCTC")
                dgvEditCt1.Columns["HBui"].HeaderText = "Rắn";

            if (dgvEditCt1.Columns.Contains("Lo") && strMa_Ct == "GCTC")
                dgvEditCt1.Columns["Lo"].HeaderText = "Lỏng";

            if (dgvEditCt1.Columns.Contains("Duc") && strMa_Ct == "GCTC")
                dgvEditCt1.Columns["Duc"].HeaderText = "Khí";
            
            if (dgvEditCt1.Columns.Contains("Noi_Dung") && strMa_Ct == "GCTC")
                dgvEditCt1.Columns["Noi_Dung"].HeaderText = "Số xe";

            if (dgvEditCt1.Columns.Contains("IS_KH") && strMa_Ct == "GNTC")
                dgvEditCt1.Columns["IS_KH"].HeaderText = "Có đăng ký suất ăn";

            if (dgvEditCt3.Columns.Contains("Ten_NT") && strMa_Ct == "GNTC")
                dgvEditCt3.Columns["Ten_NT"].HeaderText = "Tên người vào làm việc";
            if (dgvEditCt3.Columns.Contains("Ngay_Cham_Cong") && strMa_Ct == "GNTC")
                dgvEditCt3.Columns["Ngay_Cham_Cong"].HeaderText = "Ngày đăng ký suất ăn";
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

			dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_BTTB", htPara, CommandType.StoredProcedure);
			
			

			dtEditPh = dsVoucher.Tables[0];
			dtEditCt = dsVoucher.Tables[1];
            dtEditResource = dsVoucher.Tables[4];
            dtEditSuatAnNT = dsVoucher.Tables[5];

            if (enuNew_Edit == enuEdit.New)
            {
                dtEditCt.Clear();
                //dtEditCt_VtTb.Clear();
            }

			DataColumn dc = new DataColumn("Deleted", typeof(bool));
			dc.DefaultValue = false;
			dtEditCt.Columns.Add(dc);

            if (!dtEditCt.Columns.Contains("Open_File"))
            {
                dc = new DataColumn("Open_File", typeof(string));
                dc.DefaultValue = string.Empty;
                dtEditCt.Columns.Add(dc);
            }
            

			bdsEditCt.DataSource = dtEditCt;
			dgvEditCt1.DataSource = bdsEditCt;
			dgvEditCt1.ClearSelection();


            dgvEditCt2.DataSource = bdsEditCt;
            dgvEditCt2.ClearSelection();

            bdsEditSuatAnNT.DataSource = dtEditSuatAnNT;
            dgvEditCt3.DataSource = bdsEditSuatAnNT;
            dgvEditCt3.ClearSelection();
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
            if (dtEditSuatAnNT.Rows.Count == 0)
            {
                DataRow drNew = dtEditSuatAnNT.NewRow();
                Common.SetDefaultDataRow(ref drNew);

                dtEditSuatAnNT.Rows.Add(drNew);
            }
            //if (dtEditCt_VtTb.Rows.Count == 0)
            //{
            //    DataRow drNew = dtEditCt_VtTb.NewRow();
            //    Common.SetDefaultDataRow(ref drNew);

            //    dtEditCt_VtTb.Rows.Add(drNew);
            //}

            drEditPh = dtEditPh.Rows[0];
			drCurrent = dtEditCt.Rows[0];
            //drCurrent_VtTb = dtEditCt_VtTb.Rows[0];
			
			if (this.enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				//Ngầm định 1 số thông tin từ chứng từ cũ
				if (drEdit != null)
					Common.CopyDataRow(drEdit, drCurrent, (string)drDmCt["Carry_Header"]);

				drCurrent["Ma_DvCs"] = Element.sysMa_DvCs;
				drCurrent["Stt"] = strStt;
				drCurrent["Ma_Ct"] = strMa_Ct;
				//drCurrent["Ngay_Ct"] = drEdit["Ngay_Ct"] != DBNull.Value ? drEdit["Ngay_Ct"] : DateTime.Now;
				drCurrent["Ngay_Ct"] = DateTime.Now;
				drCurrent["Ma_Tte"] = Element.sysMa_Tte;
				drCurrent["Ty_Gia"] = 1;
				drCurrent["Stt0"] = 1;
				drCurrent["Deleted"] = false;

                ////Ngầm định giá trị cho VtTb
                //if (drEdit != null)
                //    Common.CopyDataRow(drEdit, drCurrent_VtTb, "Stt,Stt0");
                //drCurrent_VtTb["Stt"] = strStt;
                //drCurrent_VtTb["Stt0"] = 1;
                                             
                //Clear Content in drEditPh
                foreach (DataColumn dcEditPh in dtEditPh.Columns)
                    drEditPh[dcEditPh] = DBNull.Value;

				drEditPh["Ma_DvCs"] = drCurrent["Ma_DvCs"];
				drEditPh["Stt"] = drCurrent["Stt"];
				drEditPh["Ma_Ct"] = drCurrent["Ma_Ct"];
				drEditPh["Ngay_Ct"] = drCurrent["Ngay_Ct"];
				drEditPh["So_Ct"] = drCurrent["So_Ct"];

                drEditPh["Duyet_TP"] = 0;
                drEditPh["Duyet_Huy"] = 0;
                drEditPh["Duyet_PXCD"] = 0;
                drEditPh["Duyet_GiamDoc"] = 0;
                drEditPh["Gd_Duyet"] = "";

                drCurrent["Tinh_Trang"] = "";
                drCurrent["Tinh_Trang_Tb"] = "";
                drCurrent["Ghi_Chu_Ket_Qua"] = "";

                dtEditResource.Clear();
			}
            

            if ((this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)&& Common.Inlist(strMa_Ct,"BTTT,BTNB"))
               drCurrent["Is_Kh"] = true;
            
			//Tinh so chung tu TU 1/7
			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{                
				drEditPh["So_Ct"] = drCurrent["So_Ct"] = Voucher.Cong_So_Ct_BTTB(this);
                             
			}
			Voucher.Update_Header(this);
            Voucher.Update_Stt(this, strModule);

            txtInherit.Text = Voucher.GetInheritVoucher(this);
            if (!Common.Inlist(strMa_Ct, "BTTT,CTSC"))
            {
                lbtTen_DotBT.Visible = false;
                txtMa_DotBT.Visible = false;
                lblDotBt.Visible = false;
                
            }
            if (Common.Inlist(strMa_Ct, "BTNB,BTTT,BTBN,BBHH,BBBN,BBXE,BBBG,GRVC"))
            {
                lblMa_Nh_Tb.Visible = true;
                lbtTen_Nh_Tb.Visible = true;
                txtMa_Nh_Tb.Visible = true;
                
               
                if (!Common.Inlist(strMa_Ct, "BTKH,BBHH,BTBN,BBBN,BBXE,GRVC"))
                {
                    txtGD_Duyet.Visible = false;
                    lbtTen_Gd_Duyet.Visible = false;
                    lblGiam_Doc_Duyet.Visible = false;
                }
                
            }
            if (Common.Inlist(strMa_Ct, "CTSC,DNN,GNTC"))
            {
                txtGD_Duyet.Visible = false;
                lbtTen_Gd_Duyet.Visible = false;
                lblGiam_Doc_Duyet.Visible = false;
            }
            if (strMa_Ct == "BBHH")
            {
                chkIs_Kh.Visible = true;
                chkIs_Kh.Text = "Đề xuất sửa chữa ngoài";
            }
            if (Common.Inlist(strMa_Ct, "BBBN,BBXE"))
            {
                chkIs_Kh.Visible = true;
                chkIs_Kh.Text = "Đề xuất nhập kho dự phòng";
            }

            

            if (Common.Inlist(strMa_Ct, "BBHH,BBBG,GRVC,BBBN,BBXE")) // ẨN KẾ THỪA CÔNG VIỆC
            {
                btInherit_CV.Visible = false;
            }

            if (strMa_Ct == "GCTC")
            {
                lblMa_Nh_Tb.Visible = false;              
                txtMa_Nh_Tb.Visible = false;

                txtMa_Hd.Visible = true;
                lblMa_Hd.Visible = true;
            }
            else
            {
                txtMa_Hd.Visible = false;
                lblMa_Hd.Visible = false;
            }
            if(strMa_Ct == "BBBN")
            {
                lblMa_Nh_Tb.Visible = false;
                txtMa_Nh_Tb.Visible = false;
                lbtTen_Nh_Tb.Visible = false;
            }

            if (strMa_Ct == "GNTC")
            {

                if (enuNew_Edit == enuEdit.New)
                {
                    //dteGio_Vao.Text = "07:30:00";
                    //dteGio_Ra.Text = "16:30:00";

                    //dteNgay_BD.Text = Library.DateToStr(DateTime.Now);
                    //dteNgay_KT.Text = Library.DateToStr(DateTime.Now);
                }
                else if (enuNew_Edit == enuEdit.Edit)
                {
                    //DateTime dtGio_Vao = Convert.ToDateTime(drCurrent["Ngay_BD"]);
                    //DateTime dtGio_Ra = Convert.ToDateTime(drCurrent["Ngay_KT"]);
                  
                    //dteGio_Vao.Text = dtGio_Vao.ToString("HH:mm:ss");
                    //dteGio_Ra.Text = dtGio_Ra.ToString("HH:mm:ss");
                    //dteNgay_BD.Text = Library.DateToStr(dtGio_Vao);
                    //dteNgay_KT.Text = Library.DateToStr(dtGio_Ra);
                }
            }
            dgvEditCt2.ReadOnly = true;
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
      
        void Build_Grid(string strMa_DotBT)
        {
            if (strMa_DotBT != string.Empty)
            {
                DataRow dr = DataTool.SQLGetDataRowByID("R06DSBAOTRI", "Ma_DotBT", strMa_DotBT);
                string strUpdate = "SELECT DATEDIFF(DAY,@Ngay_Ct1, @Ngay_Ct2)";
                Hashtable ht = new Hashtable();
                ht.Add("NGAY_CT1", dr["Ngay_Ct1"]);
                ht.Add("NGAY_CT2", dr["Ngay_Ct2"]);
                int dbNgay = Convert.ToInt16(SQLExec.ExecuteReturnValue(strUpdate, ht, CommandType.Text));
                int i = dbNgay + 1;
                while (i <= 20)
                {
                    i++;
                    if (dgvEditCt1.Columns.Contains("Ngay_0" + i + ""))
                        dgvEditCt1.Columns["Ngay_0" + i + ""].Visible = false;
                    if (dgvEditCt1.Columns.Contains("Ngay_" + i + ""))
                        dgvEditCt1.Columns["Ngay_" + i + ""].Visible = false;


                }
            }
        }
		private void LoadDicName()
		{
            
			txtMa_Dt.bUseAutoDropDown = true;
			txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Nh_Tb.bUseAutoDropDown = true;
            txtMa_Hd.bUseAutoDropDown = true;

            //if (strMa_Ct == "BTBN")
            //    txtMa_Nh_Tb.strLookupKeyFilter = "Ma_Nh_Tb IN (SELECT Ma_Nh_Tb FROM R06TSNHTB WHERE Pt_Bt = 'BN')";

            //txtMa_Tb
            if (txtMa_Nh_Tb.Text.Trim() != string.Empty)
                lbtTen_Nh_Tb.Text = DataTool.SQLGetNameByCode("R06DmNhTb", "Ma_Nh_Tb", "Ten_Nh_Tb", txtMa_Nh_Tb.Text.Trim());
            else
                lbtTen_Nh_Tb.Text = string.Empty;

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

            if (txtGD_Duyet.Text.Trim() != string.Empty)
                lbtTen_Gd_Duyet.Text = DataTool.SQLGetNameByCode("R00Member", "Member_ID", "Member_Name", txtGD_Duyet.Text.Trim());
            else
                lbtTen_Gd_Duyet.Text = string.Empty;

            if (txtMa_DotBT.Text.Trim() != string.Empty)
                lbtTen_DotBT.Text = Convert.ToDateTime(DataTool.SQLGetNameByCode("R06DSBAOTRI", "Ma_DotBT", "Ngay_Ct1", txtMa_DotBT.Text.Trim())).ToShortDateString() + " đến " + Convert.ToDateTime(DataTool.SQLGetNameByCode("R06DSBAOTRI", "Ma_DotBT", "Ngay_Ct2", txtMa_DotBT.Text.Trim())).ToShortDateString();
            else
                lbtTen_DotBT.Text = string.Empty;
			//Log
			string strCreate_Log = Common.Show_Log((string)drEditPh["Create_Log"]);
			string strLastModify_Log = Common.Show_Log((string)drEditPh["LastModify_Log"]);
			string strLog = string.Empty;
			strLog += strCreate_Log != string.Empty ? "; Create: " + strCreate_Log : "";
			strLog += strLastModify_Log != string.Empty ? "; Last Modify: " + strLastModify_Log : "";

			this.lblLog.Text = strLog;

            if (enuNew_Edit == enuEdit.Edit)
                Build_Grid(txtMa_DotBT.Text);
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
                strFile_Name = SQLExec.ExecuteReturnValue("SELECT ISNULL(File_Name,'') + '.'+ Tag AS File_Name FROM R04CTSO_RESOURCE WHERE Stt = '" + strStt + "' AND Stt0 = " + iStt0);

                //if (strFile_Name != null && strFile_Name != string.Empty)
                //    dgvRow.Cells["Open_File"].Value = (object)strFile_Name;
            }
        }
        private bool SaveFile()
        {
            return Voucher.Attach_File(this, dtEditResource, (Convert.ToDateTime(dteNgay_Ct.Text).Year).ToString(), txtSo_Ct.Text, strMa_Ct);
        }
		private bool FormCheckValid()
		{
		   
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
			//Kiểm tra nhập tên GD duyệt
            if (txtGD_Duyet.Text == "" && Common.Inlist(strMa_Ct, "BBHH,BTKH,BBBN,BBXE,BTBN,BTNT,GRVC,GVTC,GDKC,GCTC"))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn cần bổ sung tên giám đốc duyệt trước khi lưu!!!" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            if(strMa_Ct == "BTTT" && txtMa_DotBT.Text == string.Empty)
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn cần bổ sung đợt bảo trì trước khi lưu!" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
            if (strMa_Ct == "BBHH" && (txtNoi_Dung.Text == string.Empty || txtPhuong_An.Text == string.Empty || txtNguyen_Nhan.Text == string.Empty || txtTinh_Trang_Tb.Text == string.Empty))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Bạn cần nhập các thông tin tình trạng, nguyên nhân, diễn biến, biện pháp sửa chữa trước khi lưu!" : "Do not register transaction type";
                Common.MsgCancel(strMsg);
                return false;
            }
			//
            if (enuNew_Edit == enuEdit.New && (string)SQLExec.ExecuteReturnValue("SELECT So_Ct FROM R06PH_BTTB WHERE So_Ct = '" + txtSo_Ct.Text + "' AND Ma_Ct = '" + txtMa_Ct.Text + "' AND YEAR(Ngay_Ct) = YEAR('" + dteNgay_Ct.Text + "')") == txtSo_Ct.Text)
            {
                string strMsg = "Số chứng từ đang trùng với chứng từ phát sinh khác cùng loại. Bạn có muốn tăng tự động không?";

                if (Common.MsgYes_No(strMsg, "Y"))
                {

                    drEditPh["So_Ct"] = txtSo_Ct.Text = Voucher.Cong_So_Ct_BTTB(this);

                    foreach (DataRow dr in dtEditCt.Rows)
                    {
                        dr["So_Ct"] = drEditPh["So_Ct"];
                    }
                }
                else
                    return false;
            }
			//Kiểm tra nghiệp vụ hợp lệ
			foreach (DataRow dr in dtEditCt.Rows)
			{
                // Nếu Nội dung không nhập xem như xóa
                if ((string)dr["Noi_Dung"] == "" && !Common.Inlist(strMa_Ct, "DNN,GRVC,GVTC,GCTC"))
                    dr["Deleted"] = true;

                if ((string)dr["Ma_Vt"] == "" && strMa_Ct == "DNN,GVTC,GCTC")
                    dr["Deleted"] = true;

                //if ((string)dr["Ma_Vt"] == "" )//&& Common.Inlist(strMa_Ct,"CTSC"))
                //    dr["Deleted"] = true;

				if ((bool)dr["Deleted"])
					continue;

				if ((string)dr["So_Ct"] == "")
				{
					string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Số chứng từ bị trống không được lưu" : "Do not register transaction type";
					Common.MsgCancel(strMsg);
					return false;
				}
                if (strMa_Ct == "DNN" && dr["Vi_Tri_Sd"] == "")
                {
                    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Phải nhập Vị trí sử dụng trước khi lưu" : "Do not register transaction type";
                    Common.MsgCancel(strMsg);
                    return false;
                }
                if (strMa_Ct == "DNN" && dtEditCt.Select("Ma_Vt = '" + dr["Ma_Vt"] + "' AND Deleted = false").Length > 1)
                {
                    Common.MsgCancel("Không đề nghị vật tư '" + dr["Ma_Vt"] + "' nhiều hơn 1 dòng");
                    return false;
                }
                #region Kiểm tra tính hợp lệ của các thông tin nhập liệu
                if (strMa_Ct == "BBHH")
                {
                    if (dr["Noi_Dung"] == "")
                    {
                        string strMsg = "Yêu cầu nhập thông tin nội dung cho biên bản hư hỏng";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                    if (dr["Nguyen_Nhan"] == "")
                    {
                        string strMsg = "Yêu cầu nhập thông tin nguyên nhân cho biên bản hư hỏng";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                    if (dr["Phuong_An"] == "")
                    {
                        string strMsg = "Yêu cầu nhập thông tin phương án khắc phục cho biên bản hư hỏng";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                    if (dr["Ten_Vt_Hh"] == "")
                    {
                        string strMsg = "Yêu cầu nhập thông tin mức độ hư hỏng cho biên bản hư hỏng";
                        Common.MsgCancel(strMsg);
                        return false;
                    }
                }
                
                //if (Common.Inlist(strMa_Ct, "BTTT,BTKH") && dr["Stt_Org"] == "")
                //{
                //    string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "'" + (string)dr["Ten_Vt"] + "' không được kế thừa, yêu cầu kế thừa từ PYC hay DT mới được phép lưu " : "Do not register transaction type";
                //    Common.MsgCancel(strMsg);
                //    return false;
                //}
				if (Common.Inlist(strMa_Ct, "PYCPT,PYCCK,PYCTH"))
				{
					string strMa_Vt = (string)dr["Ma_Vt"];
					if (strMa_Vt.Length < 11 && strMa_Vt != " " && !Common.InlistLike(strMa_Vt,"B,D,V"))
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Không cho phép sử dụng mã có dưới 11 ký tự '" + (string)dr["Ten_Vt"] + "'" : "Do not register transaction type";
						Common.MsgCancel(strMsg);
						return false;
					}
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

					if (Convert.ToDouble(dr["So_Luong0"]) != Convert.ToDouble(dr["So_Luong_Tp"]) && (bool)drEditPh["Duyet_TP"] == false)
					{
						string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ? "Số lượng yêu cầu " + dr["So_Luong0"] + " khác với số lượng duyệt của trưởng đơn vị " + dr["So_Luong_Tp"] + " tại '" + (string)dr["Ten_Vt"] + "' cần enter qua số lượng yêu cầu" : "Do not register transaction type";
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
            
            
			Voucher.Update_TTien(this);
			Voucher.Update_Stt(this, strModule);
			Voucher.UpdateSo_Ct(this);
			

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

            if (dtEditResource.Select("File_Path_New <> ''").Length > 0 && Voucher.Check_User_Server(this, (Convert.ToDateTime(dteNgay_Ct.Text).Year).ToString(), txtSo_Ct.Text, strMa_Ct))
            {
                Voucher.SQLUpdateCt(this);               
                return SaveFile();
            }
            else if (dtEditResource.Select("File_Path_New <> ''").Length > 0 && !Voucher.Check_User_Server(this, (Convert.ToDateTime(dteNgay_Ct.Text).Year).ToString(), txtSo_Ct.Text, strMa_Ct))
                return false;
            else
            {
                Voucher.SQLUpdateCt(this);
                //lưu thông tin dk suất ăn của nhà thầu
                if (strMa_Ct == "GNTC" && dtEditCt.Select("Is_Kh = 1").Length > 0)
                {
                    frmDKSuatComNT frm = new frmDKSuatComNT();
                    frm.Load(Convert.ToDateTime(dtEditCt.Rows[0]["Ngay_BD"]), Convert.ToDateTime(dtEditCt.Rows[0]["Ngay_KT"]), strStt);
                    
                }
                else if (strMa_Ct == "GNTC" && dtEditCt.Select("Is_Kh = 1").Length == 0 && DataTool.SQLCheckExist("R10DSCBNVTHEOCA", "Ma_Dt_CbNv",strStt))
                {
                    Common.MsgOk("Dữ liệu đăng ký suất cơm của bạn không có, dữ liệu đã đăng ký sẽ bị xóa.");
                    SQLExec.Execute("DELETE FROM R10DSCBNVTHEOCA WHERE Ma_Dt_CbNv = '"+strStt+"'");
                }
                return true;
            }
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
                //if ((bool)drEditPh["Duyet_KhVt"] == true && enuNew_Edit == enuEdit.Edit)
                //{
                //    numTy_Gia.Enabled = false;
                //    txtMa_Tte.Enabled = false;
                //}
                //else
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
		

			

			dgvEditCt1.ResizeGridView();
		

			DataGridView_Language();
		}

		private bool CellKeyEnter()
		{//Ham thuc hien phim Enter: true: thuc hien thanh cong, false: khong thuc hien duoc			

			if (dgvEditCt1.CurrentCell == null)
				return false;

			DataGridViewCell dgvCell = dgvEditCt1.CurrentCell;
			string strCurrentColumn = dgvCell.OwningColumn.Name.ToUpper();

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
            //numTTien0.Value = numTTien_Nt0.Value * numTy_Gia.Value;

            //if (numTTien3.Value == 0)
            //    numTTien3.Value = numTTien_Nt3.Value * numTy_Gia.Value;
            //else if (numTTien_Nt3.Value == 0 && numTy_Gia.Value != 0)
            //    numTTien_Nt3.Value = numTTien3.Value / numTy_Gia.Value;

            //this.drEditPh["TTien0"] = numTTien0.Value;
            //this.drEditPh["TTien_Nt0"] = numTTien_Nt0.Value;
            //this.drEditPh["TTien3"] = numTTien3.Value;
            //this.drEditPh["TTien_Nt3"] = numTTien_Nt3.Value;

            //this.drEditPh["TTien"] = Convert.ToDouble(this.drEditPh["TTien0"]) + Convert.ToDouble(this.drEditPh["TTien3"]);
            //this.drEditPh["TTien_Nt"] = Convert.ToDouble(this.drEditPh["TTien_Nt0"]) + Convert.ToDouble(this.drEditPh["TTien_Nt3"]);

            //Voucher.Adjust_TThue_Vat(this);
		}

		private void InheritVoucher() //Kế thừa chứng từ từ phiếu khác
		{
            if (!Common.Inlist(strMa_Ct,"BTNB"))
            {
                Voucher.Update_Header(this);
                Voucher.Update_Detail(this);

                frmInheritVoucher frm = new frmInheritVoucher();
                frm.Load(this);

                if (frm.Is_Accept)
                {
                    if (strMa_Ct == "KHVT")
                    {

                    }
                    else
                    {
                        Voucher.InheritVoucher_SetData(frm, this);
                        if (!Common.Inlist(strMa_Ct, "BTNT,DNN,GDKC,GVTC,GCTC,BBBN"))
                        {
                            strMa_Nh_Tb = drEditPh["Ma_Nh_Tb"].ToString();
                            ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Tb"]).strLookupKeyFilter = "Ma_Nh_Tb LIKE '" + strMa_Nh_Tb + "%' AND Ngay_Kt_Sd = '19000101'";
                        }
                        if(Common.Inlist(strMa_Ct, "BBBG,GRVC,BBBN,BBXE"))
                        {
                            foreach(DataRow dr in dtEditCt.Select("Ma_Vt <> ''"))
                            {
                                string strMo_Ta_Kt = string.Empty;
                                DataRow drLookup = DataTool.SQLGetDataRowByID("R81DMVT","Ma_Vt",dr["Ma_Vt"].ToString());
                                  
                                if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] == "")
                                    strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ". " + drLookup["Ten_Nha_Sx"];
                                else if (drLookup["Thong_So_Kt"] == "" && drLookup["Ma_Tb_Nha_Sx"] != "")
                                    strMo_Ta_Kt = "(" + drLookup["Ma_Tb_Nha_Sx"] + ") " + drLookup["Ten_Nha_Sx"];
                                else if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] != "")
                                    strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ". " + "(" + drLookup["Ma_Tb_Nha_Sx"] + ") " + drLookup["Ten_Nha_Sx"];
                                else
                                    strMo_Ta_Kt = "";
                                dr["Mo_Ta_Kt"] = strMo_Ta_Kt;

                                
                            }
                        }
                    }
                }
            }
            else
            {
                frmInherit_VTTB frm = new frmInherit_VTTB();
                frm.Load();
                if (frm.Is_Accept)
                {
                    if (frm.dtDmVt == null)
                        return;
                    DataTable dtImport = frm.dtDmVt.Clone();

                    DataRow[] Result = frm.dtDmVt.Select("CHON = 1");

                    foreach (DataRow drImport in Result)
                        dtImport.ImportRow(drImport);

                    DataRow drInherit = frm.dtDmVt.Select("CHON = 1")[0];
                    txtMa_Nh_Tb.Text = drInherit["Ma_Nh_Tb"].ToString();
                    lbtTen_Nh_Tb.Text = drInherit["Ten_Nh_Tb"].ToString();
                    DataTable dtEdit = dtEditCt;
                    DataRow drEditCtNew = dtEdit.NewRow();
                    Common.CopyDataRow(dtEdit.Rows[0], drEditCtNew);
                    
                    dtEditCt.Clear();

                    int iStt0 = Convert.ToInt16(Common.MaxDCValue(dtEditCt, "Stt0"));
                    strMa_Nh_Tb = drInherit["Ma_Nh_Tb"].ToString();
                    foreach (DataRow dr in dtImport.Rows)
                    {
                        DataRow drEdit = dtEditCt.NewRow();
                        Common.CopyDataRow(drEditCtNew, drEdit);

                        iStt0++;
                        drEdit["Stt0"] = iStt0;

                        drEdit["Noi_Dung"] = dr["Noi_Dung_Th"];
                        drEdit["Ma_Tb"] = dr["Ma_Tb"];
                        drEdit["Ten_Tb"] = dr["Ten_Tb"];
                        drEdit["Stt_Nd_Org"] = dr["Stt_Nd"];

                        dtEditCt.Rows.Add(drEdit);                       
                        dtEditCt.AcceptChanges();
                    }
                    
                }
            }
		}
		#endregion
			
		#region Su kien

		#region FormEvent		

		void btnImportExcel_Click(object sender, EventArgs e)
		{
			Voucher.ImportExcelCtVT(this);
		}
        void btInherit_CV_Click(object sender, EventArgs e)
        {
            frmInherit_LyLichTB frm = new frmInherit_LyLichTB();
            frm.Load(this, txtMa_Nh_Tb.Text);
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

		void txtMa_Tte_Leave(object sender, EventArgs e)
		{
            //this.Ma_Tte_Valid();
            //Voucher.Update_Detail(this);
            //Voucher.Calc_Tien_All(this);			
		}
		void numTy_Gia_Leave(object sender, EventArgs e)
		{
            //if (this.txtMa_Tte.Text.Trim() == Element.sysMa_Tte && this.numTy_Gia.Value == 0)
            //    this.numTy_Gia.Value = 1;

            //Voucher.Update_Detail(this);
            //Voucher.Calc_Tien_All(this);
            //Voucher.Calc_Tien_Von_All(this);
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

			}

			Voucher.Update_Detail(this, "Ma_Dt");
		}
        void txtMa_Hd_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Hd.Text.Trim();
            bool bRequire = false;
            string strKeyValid = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "", strKeyValid);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Hd.Text = string.Empty;
                lbtTen_Nh_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
                lbtTen_Nh_Tb.Text = drLookup["Ten_Hd"].ToString();

                if (txtMa_Hd.bTextChange)
                {
                    txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
                    DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", (string)drLookup["Ma_Dt"]);

                    if (drDmDt != null)
                    {
                        lbtTen_Dt.Text = (string)drDmDt["Ten_Dt"];
                    }
                }
            }
        }
        void txtMa_DotBT_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_DotBT.Text.Trim();
            bool bRequire = false;
            string strKey = string.Empty;


            DataRow drLookup = Lookup.ShowLookup("Ma_DotBT", strValue, bRequire, strKey);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_DotBT.Text = string.Empty;
                lbtTen_DotBT.Text = string.Empty;
            }
            else
            {
                txtMa_DotBT.Text = drLookup["Ma_DotBT"].ToString();
                lbtTen_DotBT.Text = drLookup["Ngay_Ct1"].ToString() + " đến " + drLookup["Ngay_Ct2"].ToString();
                if(enuNew_Edit == enuEdit.New)
                    Build_Grid(txtMa_DotBT.Text);

            }
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
        void txtMa_Nh_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_Tb.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Tb", strValue, bRequire, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Nh_Tb.Text = string.Empty;
                lbtTen_Nh_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Nh_Tb.Text = drLookup["Ma_Nh_Tb"].ToString();
                lbtTen_Nh_Tb.Text = drLookup["Ten_Nh_Tb"].ToString();

                strMa_Nh_Tb = txtMa_Nh_Tb.Text;

                if (dgvEditCt1.Columns.Contains("MA_TB"))
                {
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Tb"]).bUseAutoDropDown = true;
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Ma_Tb"]).strLookupKeyFilter = "Ma_Nh_Tb LIKE '" + strMa_Nh_Tb + "%' AND Ngay_Kt_Sd = '19000101'";
                }
            }
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
               
				case Keys.F8:
                    Voucher.DeleteRow(this, dgvEditCt1);
					break;

				case Keys.F10:
					this.InheritVoucher();
					break;
				
				case Keys.F4:

					tabControl1.SelectedIndex = (tabControl1.SelectedIndex == 0 ? 1 : 0);
					break;

					case Keys.Up:

					if (this.dgvEditCt1.Focused && this.dgvEditCt1.bIsCurrentFirstRow)
						this.SelectNextControl(dgvEditCt1, false, true, true, true);

					

					break;
			}

			if (!this.dgvEditCt1.Focused)
				this.dgvEditCt1.ClearSelection();

		
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

            //this.lbtNotice.Left = this.Width - this.lbtNotice.Width - 20;
		}

		void dgvEditCt2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
		
			
		}
		void dgvEditCt1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
          
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
                if (frm.dtXuatVTriKho.Rows.Count > 0 && frm.Is_Accept ==true)
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
                    
                    //dtEditResource.AcceptChanges();
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

                if (strColumnName != "ATTACH_FILE" && !Common.InlistLike(strColumnName, "AN"))
                    drCurrent[strColumnName] = e.FormattedValue;
                else if (Common.InlistLike(strColumnName, "AN"))
                    drCurrent[strColumnName] = 0;

                 if (strColumnName == "MA_TB")
					bLookup = dgvLookupMa_Tb(ref dgvCell);
                else if (strColumnName == "MA_NH_TB")
                    bLookup = dgvLookupMa_Nh_Tb(ref dgvCell);
                else if (strColumnName == "MA_VT")
                    bLookup = dgvLookupMa_Vt(ref dgvCell);
                else if (strColumnName == "MA_DT_CBNV_TH")
                    bLookup = dgvLookupMa_Dt_CbNv_Th(ref dgvCell);
                //else if (strColumnName == "MA_DT_CBNV_LIST")
                //    bLookup = dgvLookupMa_Dt_CbNv_List(ref dgvCell);
                else if (strColumnName == "MA_DT_DVSD")
                    bLookup = dgvLookupMa_Dt_DvSd(ref dgvCell);
                else if (strColumnName == "MA_BP_TH")
                    bLookup = dgvLookupMa_Bp_Th(ref dgvCell);
                else if (strColumnName == "MA_BP_PH")
                    bLookup = dgvLookupMa_Bp_Ph(ref dgvCell);
                else if (strColumnName == "MA_BP_PH")
                    bLookup = dgvLookupMa_Bp_Ph(ref dgvCell);
                else if (strColumnName == "NOI_DUNG" && Common.InlistLike(strMa_Ct, "BTNB,BTKH,BTTT,KHVT"))
                {
                   
                    bLookup = dgvLookupNoi_Dung(ref dgvCell);
                }
                else if (strColumnName == "PHUONG_AN" && Common.InlistLike(strMa_Ct, "GNTC"))
                {

                    bLookup = dgvLookupNoi_Dung_GNTC(ref dgvCell);
                }
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

            if (Common.Inlist(strColumnName, "NOI_DUNG,TINH_TRANG_HH"))
            {
                //Update_CSGia(drCurrent);
                drCurrent["Tien"] = 1;
                //if (!(bool)drCurrent["Auto_Cost"])
                //    Voucher.Calc_Tien_Von(drCurrent);
            }
            if (Common.Inlist(strColumnName, "NGAY_KT"))
            {
                if(drCurrent["Ngay_Bd"].ToString() != "" && drCurrent["Ngay_Kt"].ToString() != "")
                {
                    DateTime dtNgay_Bd = Convert.ToDateTime(drCurrent["Ngay_BD"]);
                    DateTime dtNgay_Kt = Convert.ToDateTime(drCurrent["Ngay_KT"]);
                    if (dtNgay_Kt < dtNgay_Bd)
                    {
                        Common.MsgOk("Ngày kết thúc phải lớn hơn ngày bắt đầu");
                        drCurrent["Ngay_KT"] = drCurrent["Ngay_BD"];
                    }
                    else
                    {
                        System.TimeSpan tp = dtNgay_Kt.Subtract(dtNgay_Bd);
                        drCurrent["So_Ngay_Th"] = Convert.ToDouble(tp.TotalDays);
                    }
                }
            }
            if (Common.Inlist(strColumnName, "SO_LUONG9"))
            {
                drCurrent["He_So9"] = 1;
                drCurrent["So_Luong"] = drCurrent["So_Luong9"];
            }
            if (Common.Inlist(strColumnName, "IS_KH") && strMa_Ct != "GNTC")
            {
                if ((bool)drCurrent["IS_KH"] == true)
                    drCurrent["So_Luong0"] = drCurrent["So_Luong9"];
                else
                    drCurrent["So_Luong0"] = 0;
            }
            //else if (Common.Inlist(strColumnName, "IS_KH,AN_SANG,AN_TRUA") && strMa_Ct == "GNTC")
            //{
            //    if ((bool)drCurrent["IS_KH"] == true)
            //    {
            //        if (Convert.ToDouble(drCurrent["So_Ngay_Th"]) > 0 && Convert.ToDouble(drCurrent["An_Sang"]) == 0)
            //            drCurrent["An_Sang"]  = drCurrent["So_Ngay_Th"];
            //        else if (Convert.ToDouble(drCurrent["So_Ngay_Th"]) > 0 && Convert.ToDouble(drCurrent["An_Sang"]) == 0)
            //            drCurrent["An_Trua"] = drCurrent["So_Ngay_Th"];
            //        else if (Convert.ToDouble(drCurrent["So_Ngay_Th"]) == 0 && Convert.ToDouble(drCurrent["An_Sang"]) == 0)
            //            drCurrent["An_Sang"] = 1;
            //        else if (Convert.ToDouble(drCurrent["So_Ngay_Th"]) == 0 && Convert.ToDouble(drCurrent["An_Trua"]) == 0)
            //            drCurrent["An_Trua"] = 1;
            //    }
            //}
                //if (Common.Inlist(strColumnName, "NGAY_01,NGAY_02,NGAY_03,NGAY_04,NGAY_05,NGAY_06,NGAY_07,NGAY_08,NGAY_09,NGAY_10"))
                //{
                //    drCurrent["So_Gio_Th"] = Convert.ToDouble(drCurrent["Ngay_01"]) + Convert.ToDouble(drCurrent["Ngay_02"]) + Convert.ToDouble(drCurrent["Ngay_03"]) +
                //        Convert.ToDouble(drCurrent["Ngay_04"]) + Convert.ToDouble(drCurrent["Ngay_05"]) + Convert.ToDouble(drCurrent["Ngay_06"]) + Convert.ToDouble(drCurrent["Ngay_07"]) +
                //        Convert.ToDouble(drCurrent["Ngay_08"]) + Convert.ToDouble(drCurrent["Ngay_09"]) + Convert.ToDouble(drCurrent["Ngay_10"]);
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

			

		}

		//Xử lý Dvt
        void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
        {
        }

		#endregion

		#region DataGridViewLookup		

		private bool dgvLookupMa_Tb(ref DataGridViewCell dgvCell)
		{
			string strValue = string.Empty;

			if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
				strValue = this.ActiveControl.Text;
			else
				strValue = dgvCell.FormattedValue.ToString().Trim();

			bool bRequire = true;
            string strKey = "";

            if (!Common.Inlist(strMa_Ct, "BTKH,BTNT,BBBN"))
                strKey = "Ma_Nh_Tb = '" + strMa_Nh_Tb + "' AND Ngay_Kt_Sd = '19000101'";
            
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
				dgvCell.DataGridView.EndEdit();
                if(dgvEditCt1.Columns.Contains("Noi_Dung"))
                    ((dgvTextBoxColumn)dgvEditCt1.Columns["Noi_Dung"]).strLookupKeyFilter = "Ma_Nh_Tb = '" + strMa_Nh_Tb + "' AND Ma_Tb = '" + strMa_Tb + "'";

			}
			return true;
		}
        private bool dgvLookupMa_Nh_Tb(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = true;
            string strKey = "";

           
            DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Tb", strValue, bRequire, strKey, "");

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

                        

                dgvCell.Value = drLookup["Ma_Nh_Tb"].ToString();
                dgvCell.Tag = drLookup["Ten_Nh_Tb"].ToString();

                dgvCell.DataGridView.EndEdit();


                if ((string)drCurrent["Ten_Nh_Tb"] == string.Empty)
                    drCurrent["Ten_Nh_Tb"] = drLookup["Ten_Nh_Tb"];

            


            }
            return true;
        }
        private bool dgvLookupMa_Dt_DvSd(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = true;
            System.Collections.Hashtable htField = new System.Collections.Hashtable();
            htField.Add("strType", "DVSD");
            DataRow drLookup = Lookup.ShowLookup("Type_ID", strValue, bRequire, "TYPE = 'DVSD'", "", htField);

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
                dgvCell.Value = drLookup["Type_ID"].ToString();
                dgvCell.Tag = drLookup["Type_Name"].ToString();

                dgvCell.DataGridView.EndEdit();

                drCurrent["Ma_Dt_DVSD"] = drLookup["Type_ID"];
            }
            return true;
        }
        private bool dgvLookupMa_Dt_CbNv_List(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            string strKey = "Ma_Nh_Dt = 'NV'";
            DataRow drLookup;

            if (strValue == "/" || strValue == "/")
                drLookup = Lookup.ShowMultiLookup("Ma_Dt_CbNv", strValue, bRequire, strKey, "");
            else
                drLookup = null;

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
                dgvCell.Value = drLookup["MultiSelectValue"].ToString();
                dgvCell.Tag = drLookup["MultiSelectValue"].ToString();

                dgvCell.DataGridView.EndEdit();

                drCurrent["Ma_Dt_CbNv_List"] = drLookup["MultiSelectValue"].ToString(); ;
            }
            return true;
        }
        private bool dgvLookupMa_Dt_CbNv_Th(ref DataGridViewCell dgvCell)
        {
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            string strKey = "Ma_Nh_Dt = 'NV'";
            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, strKey, "");

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
                dgvCell.Value = drLookup["Ma_Dt"].ToString();
                dgvCell.Tag = drLookup["Ten_Dt"].ToString();

                dgvCell.DataGridView.EndEdit();

                drCurrent["Ma_Dt_CbNv_Th"] = drLookup["Ma_Dt"];
            }
            return true;
        }
        private bool dgvLookupMa_Bp_Th(ref DataGridViewCell dgvCell)
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
        private bool dgvLookupNoi_Dung(ref DataGridViewCell dgvCell)
        {
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Noi_Dung", strValue, bRequire, "Ma_Nh_Tb = '"+ txtMa_Nh_Tb.Text +"' AND Ma_Tb = '"+ drCurrent["Ma_Tb"] +"'");
            
            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCell.Value = drLookup["Noi_Dung_Th"].ToString();
                dgvCell.Tag = drLookup["Noi_Dung_Th"].ToString();

                drCurrent["Stt_Nd_Org"] = drLookup["Stt_Nd"].ToString();
                drCurrent["Phan_Loai_Cv"] = drLookup["Phan_Loai_Cv"].ToString();

                if (Common.Inlist(strMa_Ct, "BTNB,BTTT") && enuNew_Edit == enuEdit.Edit && (bool)drEditPh["Duyet_TP"])
                {
                    drCurrent["Is_Kh"] = false;
                }
                dgvCell.DataGridView.EndEdit();
            }

            return true;
        }
        private bool dgvLookupNoi_Dung_GNTC(ref DataGridViewCell dgvCell)
        {
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Nv_Nt", strValue, bRequire, "Ma_Dt = '" + txtMa_Dt.Text + "'");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCell.Value = drLookup["Ma_Nv_Nt"].ToString();
                dgvCell.Tag = drLookup["Ma_Nv_Nt"].ToString();

                drCurrent["Noi_Dung"] = drLookup["Ten_Nv_Nt"].ToString();
                drCurrent["Ten_Vt"] = drLookup["Nam_Sinh"].ToString();
                drCurrent["Phuong_An"] = drLookup["Ma_Nv_Nt"].ToString();
              
                
                dgvCell.DataGridView.EndEdit();
            }

            return true;
        }
        private bool dgvLookupMa_Bp_Ph(ref DataGridViewCell dgvCell)
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
        
        private bool dgvLookupMa_Vt(ref DataGridViewCell dgvCell)
        {
           
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
           
            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;
            DataRow drLookup;
            
            if(!Common.Inlist(strMa_Ct,"GVTC,GCTC"))
                drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%' AND LEN(Ma_Vt) = 9 ", "");//AND Is_Hide = 0
            //else if (Common.Inlist(strMa_Ct, "GVTC"))
            //    drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "Ma_Nh_Vt LIKE 'OXI%' OR Ma_Nh_Vt LIKE 'SPCAN%' OR Ma_Nh_Vt LIKE 'PHOI%' OR Ma_Nh_Vt LIKE 'THEPCANDAI%' OR Ma_Nh_Vt LIKE 'THEPCANDAI%'", "");
            else
                drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");
            
            //drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%' AND LEN(Ma_Vt) = 9 AND Is_Hide = 0", "");
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

                dgvEditCt1.CancelEdit();
                dgvCell.Value = drLookup["Ma_Vt"].ToString();
                dgvCell.Tag = drLookup["Ten_Vt"].ToString();

                if (Common.Inlist(strMa_Ct , "GRVC,GVTC,GCTC,BBHH"))
                {
                    drCurrent["Ten_Vt"] = drLookup["Ten_Vt"];
                    drCurrent["Dvt"] = drLookup["Dvt"];
                }

                else
                {
                    if (strMa_Vt != strMa_Vt_Old)
                    {

                        drCurrent["Ten_Vt"] = drLookup["Ten_Vt_Chuan"];
                        drCurrent["Dvt"] = drLookup["Dvt"];
                        if (dgvEditCt1.Columns.Contains("Mo_Ta_Kt"))
                        {
                            string strMo_Ta_Kt = string.Empty;
                            if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] == "")
                                strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ". " + drLookup["Ten_Nha_Sx"];
                            else if (drLookup["Thong_So_Kt"] == "" && drLookup["Ma_Tb_Nha_Sx"] != "")
                                strMo_Ta_Kt = "(" + drLookup["Ma_Tb_Nha_Sx"] + ") " + drLookup["Ten_Nha_Sx"];
                            else if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] != "")
                                strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ". " + "(" + drLookup["Ma_Tb_Nha_Sx"] + ") " + drLookup["Ten_Nha_Sx"];
                            else
                                strMo_Ta_Kt = "";

                            drCurrent["Mo_Ta_Kt"] = strMo_Ta_Kt;

                        }
                    }
                    else
                    {
                        if (drCurrent["Ten_Vt"] == DBNull.Value || (string)drCurrent["Ten_Vt"] == string.Empty)
                            drCurrent["Ten_Vt"] = drLookup["Ten_Vt_Chuan"];

                        if (drCurrent["Dvt"] == DBNull.Value || (string)drCurrent["Dvt"] == string.Empty)
                            drCurrent["Dvt"] = drLookup["Dvt"];

                        if (dgvEditCt1.Columns.Contains("Mo_Ta_Kt"))
                        {
                            string strMo_Ta_Kt = string.Empty;
                            if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] == "")
                                strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ". " + drLookup["Ten_Nha_Sx"];
                            else if (drLookup["Thong_So_Kt"] == "" && drLookup["Ma_Tb_Nha_Sx"] != "")
                                strMo_Ta_Kt = "(" + drLookup["Ma_Tb_Nha_Sx"] + ") " + drLookup["Ten_Nha_Sx"];
                            else if (drLookup["Thong_So_Kt"] != "" && drLookup["Ma_Tb_Nha_Sx"] != "")
                                strMo_Ta_Kt = drLookup["Thong_So_Kt"] + ". " + "(" + drLookup["Ma_Tb_Nha_Sx"] + ") " + drLookup["Ten_Nha_Sx"];
                            else
                                strMo_Ta_Kt = "";

                            drCurrent["Mo_Ta_Kt"] = strMo_Ta_Kt;

                        }

                    }
                }
                if (strMa_Ct == "DNN" && drCurrent["Tinh_Trang_Tb"] == "")
                    drCurrent["Tinh_Trang_Tb"] = "Đã phục hồi";
            }
            return true;
        }
		
		#endregion

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

            if(Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New))
                this.btgAccept.btAccept.Enabled = true;

			this.DataGridView_Language();

			this.dgvEditCt1.ClearSelection(); //Chi co tac dung sau khi show form

			cboSaveOption.Items.Clear();
			cboSaveOption.Items.AddRange(new string[] { "1-Lưu & Nhập tiếp", "2-Lưu & Đóng lại", "3-Lưu - In & Nhập tiếp", "4-Lưu - In & Đóng lại", "5-In & Nhập tiếp", "6-In & Đóng lại" });
            
            if ((bool)drEditPh["Duyet_Tp"] && Common.Inlist(strMa_Ct, "BBHH,GRVC,GVTC,GDKC,GCTC,GNTC,BBBN,BBXE"))
            {
                this.btgAccept.btAccept.Enabled = false;
                return;
            }
            if ((bool)drEditPh["Lock"] && Common.Inlist(strMa_Ct, "BTTT"))
            {
                this.btgAccept.btAccept.Enabled = false;
                return;
            }
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

		
	}
}
