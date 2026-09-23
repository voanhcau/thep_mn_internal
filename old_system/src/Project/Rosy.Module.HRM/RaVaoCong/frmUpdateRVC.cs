using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using System.Collections;
using RosySystem.Element;
using RosySystem;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using RosySystem.Control;
using RosyModule;
using System.Data.SqlClient;
using RosySystem.Customize;
using RosySystem.Public;

namespace RosyModule.HRM
{
    public partial class frmUpdateRVC : RosySystem.Customize.frmView
	{
		#region Variable

		//Luu y toi bManual
        object objActive = null;

		DataSet dsVoucher = new DataSet();
		DataTable dtEditPh;
        DataTable dtEditPh_Dest;
		DataTable dtEditCt;
        DataTable dtEditCt_NhanVienCa;
        DataTable dtEditCt_NhanVienCty;
        DataTable dtEditCt_XeNbCty;
        DataTable dtEditCt_XeKhachChoHang;
        DataTable dtEditCt_XeKhachLH;
        DataTable dtEditCt_XePKD;
        DataTable dtEditCt_NhanVienSuCo;
        DataTable dtEditCt_XaLan;

        DataRow drEditPh;
		DataRow drEditCt;
        DataRow drEditCt_NhanVienCty;
        DataRow drEditCt_XeNbCty;
      
      
    


		BindingSource bdsEditPh = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
        BindingSource bdsEditCt_NhanVienCa = new BindingSource();
        BindingSource bdsEditCt_NhanVienCty = new BindingSource();
        BindingSource bdsEditCt_XeNbCty = new BindingSource();
        BindingSource bdsEditCt_XeKhachChoHang = new BindingSource();
        BindingSource bdsEditCt_XeKhachLH = new BindingSource();
        BindingSource bdsEditCt_XePKD = new BindingSource();
        BindingSource bdsEditCt_NhanVienSuCo = new BindingSource();
        BindingSource bdsEditCt_XaLan = new BindingSource();

		DataRow drCurrent;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;
        string strMa_Dt_CbNv_Bv = string.Empty;
        string strStt = string.Empty;
        string strCong = string.Empty;
        public bool is_Close = false;
        public bool Is_Kd = false;
		#endregion

        public frmUpdateRVC()
		{
			InitializeComponent();

            dgvNhanVienCty.Enter += new EventHandler(dgvNhanVienCty_Enter);
            dgvXeKhachChoHang.Enter += new EventHandler(dgvXeKhach_Enter);
            dgvXeNbCty.Enter += new EventHandler(dgvXeNbCty_Enter);
            dgvXePKD.Enter += new EventHandler(dgvXePKD_Enter);
            dgvXeKhachLH.Enter += new EventHandler(dgvXeKhachLH_Enter);
            dgvNhanVienSuCo.Enter += new EventHandler(dgvNhanVienSuCo_Enter);

            txtSo_Xe.TextChanged += new EventHandler(txtSo_Xe_TextChanged);
            btNew.Click += new EventHandler(btNew_Click);
            btExit.Click += new EventHandler(btExit_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
            cboCong.SelectedValueChanged += new EventHandler(cboCong_Filter_SelectedValueChanged);
            btXeCong.Click += new EventHandler(btXeCong_Click);
            dgvXeKhachChoHang.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvXeKhachChoHang_CellMouseClick);
		}

        

       

        void txtSo_Xe_TextChanged(object sender, EventArgs e)
        {
            FillData();
        }

        
       
        
        new public void Load(string strCong)
		{
            this.cboCong.Text = strCong.Substring(0, 2);
            if (strCong == "A2KD")
            {
                Is_Kd = true;
                btNew.Enabled = false;
            }
            this.Build();
            this.FillData();
            this.Init_Ct();
            LoadDicName();
            if (strCong == "A2KD")
            {
                rsTabControl1.TabPages.Remove(tpXeNB);
                rsTabControl1.TabPages.Remove(tpNhanVienCty);
                rsTabControl1.TabPages.Remove(tpNhanVienSuCo);
                rsTabControl1.TabPages.Remove(tpXeKhachLH);
                rsTabControl1.TabPages.Remove(tpXePKD);
            }
            else if (cboCong.Text == "A2")
            {
                rsTabControl1.TabPages.Remove(tpNhanVienCty);
                rsTabControl1.TabPages.Remove(tpNhanVienSuCo);
                rsTabControl1.TabPages.Remove(tpXeKhachLH);
                rsTabControl1.TabPages.Remove(tpXaLan);

                if (Is_Kd)
                {
                    rsTabControl1.TabPages.Remove(tpXeNB);
                }
                rsTabControl1.TabPages.Remove(tpXePKD);
                this.rsTabControl1.SelectedTab = this.tpXeKhachChoHang;
            }
            else if (cboCong.Text == "A3")
            {
                rsTabControl1.TabPages.Remove(tpNhanVienCty);
                rsTabControl1.TabPages.Remove(tpNhanVienSuCo);
                rsTabControl1.TabPages.Remove(tpXeKhachLH);
                rsTabControl1.TabPages.Remove(tpXeNB);
                rsTabControl1.TabPages.Remove(tpXeKhachChoHang);
                rsTabControl1.TabPages.Remove(tpXaLan);
            }
            else
            {
                rsTabControl1.TabPages.Remove(tpXeKhachChoHang);
                rsTabControl1.TabPages.Remove(tpXePKD);
                rsTabControl1.TabPages.Remove(tpXaLan);

            }
            this.Show();
            //this.ShowDialog();
		}

        private void LoadDicName()
        {


        }
		private void Build()
		{
            
            dgvNhanVienCty.bSortMode = false;
            dgvNhanVienCty.strZone = "NHANVIEN_RVC";
            dgvNhanVienCty.BuildGridView();

            dgvXeNbCty.bSortMode = false;
            dgvXeNbCty.strZone = "XENB_RVC";
            dgvXeNbCty.BuildGridView();

            dgvXeKhachChoHang.bSortMode = false;
            dgvXeKhachChoHang.strZone = "XEKHACH";
            dgvXeKhachChoHang.BuildGridView();

            dgvXeKhachLH.bSortMode = false;
            dgvXeKhachLH.strZone = "XEKHACHLH";
            dgvXeKhachLH.BuildGridView();

            dgvXePKD.bSortMode = false;
            dgvXePKD.strZone = "XEPKD";
            dgvXePKD.BuildGridView();

            dgvNhanVienSuCo.bSortMode = false;
            dgvNhanVienSuCo.strZone = "NHANVIEN_RVC";
            dgvNhanVienSuCo.BuildGridView();

            dgvXaLan.bSortMode = false;
            dgvXaLan.strZone = "XALANCONG";
            dgvXaLan.BuildGridView();

            this.DataGridView_Language();

            foreach (DataGridViewColumn dgvc in dgvNhanVienCty.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvXeNbCty.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvXeKhachChoHang.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvXePKD.Columns)
                dgvc.ReadOnly = true;

            foreach (DataGridViewColumn dgvc in dgvXaLan.Columns)
                dgvc.ReadOnly = true;

            if (Is_Kd)
                dgvXeKhachChoHang.Columns["Is_LXH"].ReadOnly = false;
		}

		private void DataGridView_Language()
		{
		
			
		}

		private void Init_Ct()
		{
           
		}
      
        private void LoadCombo()
        {
           
            
        }
		private void FillData()
		{
            Hashtable ht = new Hashtable();
            ht.Add("CONG", this.cboCong.Text);
            ht.Add("SO_XE", txtSo_Xe.Text);
            ht.Add("IS_PKD", Is_Kd);
            ht.Add("MA_DVCS", Element.sysMa_DvCs);
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherQLRAVAOCONG_UPDATE", ht, CommandType.StoredProcedure);

            dtEditCt_NhanVienCty = dsVoucher.Tables[0];
            bdsEditCt_NhanVienCty.DataSource = dtEditCt_NhanVienCty;
            dgvNhanVienCty.DataSource = bdsEditCt_NhanVienCty;

            dtEditCt_XeNbCty = dsVoucher.Tables[1];
            bdsEditCt_XeNbCty.DataSource = dtEditCt_XeNbCty;
            dgvXeNbCty.DataSource = bdsEditCt_XeNbCty;

            dtEditCt_XeKhachChoHang = dsVoucher.Tables[2];
            bdsEditCt_XeKhachChoHang.DataSource = dtEditCt_XeKhachChoHang;
            dgvXeKhachChoHang.DataSource = bdsEditCt_XeKhachChoHang;

            dtEditCt_XePKD = dsVoucher.Tables[3];
            bdsEditCt_XePKD.DataSource = dtEditCt_XePKD;
            dgvXePKD.DataSource = bdsEditCt_XePKD;

            dtEditCt_XeKhachLH = dsVoucher.Tables[4];
            bdsEditCt_XeKhachLH.DataSource = dtEditCt_XeKhachLH;
            dgvXeKhachLH.DataSource = bdsEditCt_XeKhachLH;

            dtEditCt_NhanVienSuCo = dsVoucher.Tables[5];
            bdsEditCt_NhanVienSuCo.DataSource = dtEditCt_NhanVienSuCo;
            dgvNhanVienSuCo.DataSource = bdsEditCt_NhanVienSuCo;

            dtEditCt_XaLan = dsVoucher.Tables[6];
            bdsEditCt_XaLan.DataSource = dtEditCt_XaLan;
            dgvXaLan.DataSource = bdsEditCt_XaLan;
		}

        void dgvNhanVienSuCo_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvNhanVienSuCo;
        }
        void dgvXePKD_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvXePKD;
        }
        void dgvXeKhachLH_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvXeKhachLH;
        }
        void dgvXeNbCty_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvXeNbCty;
        }

        void dgvXeKhach_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvXeKhachChoHang;
        }
        void dgvNhanVienCty_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvNhanVienCty;
        }
      
        public override void Edit(enuEdit enuNew_Edit)
        {
            if (this.objActive == dgvNhanVienCty)
                this.Edit_NhanVienCty(enuNew_Edit);
            else if (this.objActive == dgvNhanVienSuCo)
                this.Edit_NhanVienSuCo(enuNew_Edit);
            else if (this.objActive == dgvXeNbCty)
                this.Edit_XeNbCty(enuNew_Edit);
            else if (this.objActive == dgvXeKhachChoHang)
                this.Edit_XeKhachChoHang(enuNew_Edit);
            else if (this.objActive == dgvXeKhachLH)
                this.Edit_XeKhachLH(enuNew_Edit);
            else if (this.objActive == dgvXePKD)
                this.Edit_XePKD(enuNew_Edit);

        }
        
        
        
        void btNew_Click(object sender, EventArgs e)
        {
            this.enuNew_Edit_Voucher = enuEdit.Edit;
            Edit(enuNew_Edit_Voucher);
           
        }

        private void Edit_NhanVienSuCo(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_NhanVienSuCo.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drEditPh = ((DataRowView)(bdsEditPh.Current)).Row;

            //Copy hang hien tai            
            if (bdsEditCt_NhanVienSuCo.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_NhanVienSuCo.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_NhanVienSuCo.NewRow();

            frmNhanVienRVC_Edit frmEdit = new frmNhanVienRVC_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt, "SUCO");

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];

                DataRow drDmDtCbNvQL = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv_Ql"].ToString());
                drCurrent["Ten_Dt_CbNv_QL"] = drDmDtCbNvQL["Ten_Dt"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_NhanVienSuCo.Position >= 0)
                        dtEditCt_NhanVienSuCo.ImportRow(drCurrent);
                    else
                        dtEditCt_NhanVienSuCo.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_NhanVienSuCo.Current).Row);
                }


                bdsEditCt_NhanVienSuCo.Position = bdsEditCt_NhanVienSuCo.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_NhanVienSuCo.AcceptChanges();
            }
            else
                dtEditCt_NhanVienSuCo.RejectChanges();
        }

        private void Edit_NhanVienCty(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_NhanVienCty.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

           

            //Copy hang hien tai            
            if (bdsEditCt_NhanVienCty.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_NhanVienCty.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_NhanVienCty.NewRow();

            frmNhanVienRVC_Edit frmEdit = new frmNhanVienRVC_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt, "BINHTHUONG");

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];

                DataRow drDmDtCbNvQL = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv_Ql"].ToString());
                drCurrent["Ten_Dt_CbNv_QL"] = drDmDtCbNvQL["Ten_Dt"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_NhanVienCty.Position >= 0)
                        dtEditCt_NhanVienCty.ImportRow(drCurrent);
                    else
                        dtEditCt_NhanVienCty.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_NhanVienCty.Current).Row);
                }


                bdsEditCt_NhanVienCty.Position = bdsEditCt_NhanVienCty.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_NhanVienCty.AcceptChanges();
            }
            else
                dtEditCt_NhanVienCty.RejectChanges();
        }

        private void Edit_XeNbCty(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_XeNbCty.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            

            //Copy hang hien tai            
            if (bdsEditCt_XeNbCty.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_XeNbCty.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_XeNbCty.NewRow();

            frmXeNbRVC_Edit frmEdit = new frmXeNbRVC_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];

                DataRow drDmXe = DataTool.SQLGetDataRowByID("R81DMXE", "Ma_Xe", drCurrent["Ma_Xe"].ToString());
                drCurrent["Ten_Xe"] = drDmXe["Ten_Xe"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_XeNbCty.Position >= 0)
                        dtEditCt_XeNbCty.ImportRow(drCurrent);
                    else
                        dtEditCt_XeNbCty.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_XeNbCty.Current).Row);
                }


                bdsEditCt_XeNbCty.Position = bdsEditCt_XeNbCty.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_XeNbCty.AcceptChanges();
            }
            else
                dtEditCt_XeNbCty.RejectChanges();
        }

        private void Edit_XeKhachChoHang(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_XeKhachChoHang.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

           
            //Copy hang hien tai            
            if (bdsEditCt_XeKhachChoHang.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_XeKhachChoHang.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_XeKhachChoHang.NewRow();

            frmXeKhach_Edit frmEdit = new frmXeKhach_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt"].ToString());
                drCurrent["Ten_Dt"] = drDmDt["Ten_Dt"];

                DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", drCurrent["Ma_Vt_Sp"].ToString());
                drCurrent["Ten_Vt_Sp"] = drDmVt["Ten_Vt"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_XeKhachChoHang.Position >= 0)
                        dtEditCt_XeKhachChoHang.ImportRow(drCurrent);
                    else
                        dtEditCt_XeKhachChoHang.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_XeKhachChoHang.Current).Row);
                }


                bdsEditCt_XeKhachChoHang.Position = bdsEditCt_XeKhachChoHang.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_XeKhachChoHang.AcceptChanges();
            }
            else
                dtEditCt_XeKhachChoHang.RejectChanges();
        }
        private void Edit_XeKhachLH(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_XeKhachLH.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

           

            //Copy hang hien tai            
            if (bdsEditCt_XeKhachLH.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_XeKhachLH.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_XeKhachLH.NewRow();

            frmXeKhachLH_Edit frmEdit = new frmXeKhachLH_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_XeKhachLH.Position >= 0)
                        dtEditCt_XeKhachLH.ImportRow(drCurrent);
                    else
                        dtEditCt_XeKhachLH.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_XeKhachLH.Current).Row);
                }


                bdsEditCt_XeKhachLH.Position = bdsEditCt_XeKhachLH.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_XeKhachLH.AcceptChanges();
            }
            else
                dtEditCt_XeKhachLH.RejectChanges();
        }

        private void Edit_XePKD(enuEdit enuNew_Edit)
        {
            if (bdsEditCt_XePKD.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

          

            //Copy hang hien tai            
            if (bdsEditCt_XePKD.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_XePKD.Current).Row, ref drCurrent);
            else
                drCurrent = dtEditCt_XePKD.NewRow();

            frmXePKD_Edit frmEdit = new frmXePKD_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strStt, Convert.ToDateTime(DateTime.Now));

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
                drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];

                DataRow drDmDt = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt"].ToString());
                drCurrent["Ten_Dt"] = drDmDt["Ten_Dt"];

                DataRow drDmXe = DataTool.SQLGetDataRowByID("R81DMXE", "Ma_Xe", drCurrent["Ma_Xe"].ToString());
                drCurrent["Ten_Xe"] = drDmXe["Ten_Xe"];
                
                if (drCurrent["Loai_Sp"].ToString() == "P")
                    drCurrent["Ten_Sp"] = "Phôi thép";
                else if (drCurrent["Loai_Sp"].ToString() == "T")
                    drCurrent["Ten_Sp"] = "Thép cán";

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_XePKD.Position >= 0)
                        dtEditCt_XePKD.ImportRow(drCurrent);
                    else
                        dtEditCt_XePKD.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_XePKD.Current).Row);
                }


                bdsEditCt_XePKD.Position = bdsEditCt_XePKD.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_XePKD.AcceptChanges();
            }
            else
                dtEditCt_XePKD.RejectChanges();
        }
       
       
       
        
        
		#region Event
		
		void dgvEditCt_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			dgvVoucher dgvEditCt = (dgvVoucher)sender;
			if (this.ActiveControl != dgvEditCt && this.ActiveControl != null && this.ActiveControl.GetType().Name != "DataGridViewTextBoxEditingControl")
				return;

			drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

         
            bdsEditCt.EndEdit();//Cap nhat lai DataSource
		}

		

            
		

	

		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
            
		}
        void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

         
        }
        void dgvXeKhachChoHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strColumnName = dgvXeKhachChoHang.Columns[e.ColumnIndex].Name;
            drCurrent = ((DataRowView)bdsEditCt_XeKhachChoHang.Current).Row;
            if (strColumnName == "IS_LXH" && Is_Kd)
            {
                if (!(bool)drCurrent["IS_LXH"])
                {
                    dgvXeKhachChoHang.Columns["IS_LXH"].ReadOnly = false;
               
                    string strSQLExec = string.Empty;
                    Hashtable htPara = new Hashtable();
                    htPara.Add("IS_LXH", !(bool)drCurrent["IS_LXH"]);
                    htPara.Add("IDENT00", drCurrent["IDENT00"]);



                    strSQLExec = "UPDATE R09CT_RVC SET IS_LXH = @IS_LXH WHERE IDENT00 = @IDENT00";
                    if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
                        drCurrent["IS_LXH"] = !(bool)drCurrent["IS_LXH"];
                }
            }
        }
        void cboCong_Filter_SelectedValueChanged(object sender, EventArgs e)
        {
            FillData();
        }
	
		#endregion

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
				return;

			switch (e.KeyCode)
			{

                case Keys.F9:
                    FillData();

                    return;
               
				case Keys.F12:
					if (e.Modifiers == Keys.Control)
						base.OnKeyDown(e);
				
					return;

                case Keys.Escape:
                    {
                        base.OnKeyDown(e);
                        this.is_Close = true;
                    }
                    return;
			    
			}

			base.OnKeyDown(e);
		}
        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.is_Close = true;
        }
        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }
        void btXeCong_Click(object sender, EventArgs e)
        {
            frmXeCong frm = new frmXeCong();
            frm.Load();
        }

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin)
			{
                //if (!Common.CheckPermission("ACCESS_FILTER_DT_TCB", enuPermission_Type.Allow_Access))
                //    dteNgay_Ct1.Enabled = dteNgay_Ct2.Enabled = false;

                //this.btEdit.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
			}

		}

       

       
        

	}
}
