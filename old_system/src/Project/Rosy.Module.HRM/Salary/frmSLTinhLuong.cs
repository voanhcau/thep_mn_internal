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
using RosyList;
using RosyModule;
using RosySystem;
using RosySystem.Library;
using RosySystem.Element;
using System.Collections;
using RosySystem.Public;
using RosySystem.Control;

namespace RosyModule.Salary
{
	public partial class frmSLTinhLuong : RosySystem.Customize.frmView
	{
        object objActive = null;
        private rsTreeList tlSLTL = new rsTreeList();
        private rsTreeList tlKQPBSL = new rsTreeList();
        private rsTreeList tlLuongTT = new rsTreeList();
      
        DataSet dsSLTL;
        DataSet dsLuongTT;
        DataTable dtSLTL;
        DataTable dtSLTLCT;
        DataTable dtLuongTT;
        DataTable dtLock;
        DataTable dtQuyLuong;
        DataTable dtKHNam;
        DataTable dtNghiLeCty;

        string strMa_Bp;
        BindingSource bdsSLTL = new BindingSource();
        BindingSource bdsThangList = new BindingSource();
        BindingSource bdsKQPBSL = new BindingSource();
        BindingSource bdsSLTLCT = new BindingSource();
        BindingSource bdsLuongTT = new BindingSource();
        BindingSource bdsLock = new BindingSource();
        BindingSource bdsQuyLuong = new BindingSource();
        BindingSource bdsNghiLeCty = new BindingSource();

        DataRow drCurrent;

        public frmSLTinhLuong()
		{
			InitializeComponent();

            this.btNewKH.Click += new EventHandler(btNewKH_Click);
            this.btUpdate.Click += new EventHandler(btUpdate_Click);
            this.btEdit.Click += new EventHandler(btEdit_Click);
            this.btPhanBo.Click += new EventHandler(btPhanBo_Click);
            this.btCheckDG.Click += new EventHandler(btCheckDG_Click);
           
			this.btExit.Click += new EventHandler(btExit_Click);

            numNam.Validated += new EventHandler(numNam_Validated);
            bdsThangList.PositionChanged += new EventHandler(bdsThangList_PositionChanged);
            txtTk.Enter += new EventHandler(txtTk_Enter);

            dgvSLTL.Enter += new EventHandler(dgvSLTL_Enter);
            dgvSLTLCT.Enter += new EventHandler(dgvSLTLCT_Enter);
            dgvLock.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvLock_CellMouseClick);
            dgvLock.CellEnter += DgvLock_CellEnter;
            dgvNghiLeCty.CellMouseClick += DgvNghiLeCty_CellMouseClick;
		}

       

        new public void Load()
		{
            numNam.Value = Element.sysWorkingYear;
            this.strMa_Bp = SQLExec.ExecuteReturnValue("SELECT Ma_Bp FROM R81DMDT WHERE Ma_Dt IN (SELECT Ma_Dt_CbNv FROM R00MEMBER WHERE MEMBER_ID = '" + Element.sysUser_Id + "')").ToString();
			
            Build();
            BuildDataGridView();
            FillData();
            FillData(1);
            //FillData_LuongTT(strMa_Bp, 1);
            if(!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New))
            {
               
                this.btCheckDG.Enabled = false;
                this.btEdit.Enabled = false;
                this.btNewKH.Enabled = false;

               
            }
            clickupdate();  
			this.BindingLanguage();

			this.Show();
		}
        private void clickupdate()
        {
            if (bdsThangList.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsThangList.Current).Row;
            bool bSLKD = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Lock_SLKD FROM R00LOCKEDLUONG WHERE NAM = " + numNam.Value + " AND Thang = " + drCurrent["Thang"].ToString() + ""));
            if (bSLKD)
                btUpdate.Enabled = false;
            else
                btUpdate.Enabled = true;

            bool bSLSX = Convert.ToBoolean(SQLExec.ExecuteReturnValue("SELECT Lock_SLSX FROM R00LOCKEDLUONG WHERE NAM = " + numNam.Value + " AND Thang = " + drCurrent["Thang"].ToString() + ""));
            if (bSLSX)
                btEdit.Enabled = false;
            else
                btEdit.Enabled = true;
        }
		private void Build()
		{
            tlSLTL.KeyFieldName = "THANG";
            tlSLTL.ParentFieldName = "NAM";
            tlSLTL.Dock = DockStyle.Fill;
            tlSLTL.strZone = "THANGSLTL";
            tlSLTL.BuildTreeList(this.isLookup);

            this.pageSLTL.Controls.Add(tlSLTL);


            dgvSLTL.strZone = "DLSLTL";
            dgvSLTL.BuildGridView();

            //tlKQPBSL.KeyFieldName = "MA_BP_CT";
            //tlKQPBSL.ParentFieldName = "MA_BP";
            //tlKQPBSL.Dock = DockStyle.Fill;
            //tlKQPBSL.strZone = "KQPBSLTL";
            //tlKQPBSL.BuildTreeList(this.isLookup);

            //this.tpKQPBSL.Controls.Add(tlKQPBSL);


            dgvKQPBSL.strZone = "KQPBSLTL";
            dgvKQPBSL.BuildGridView();

            dgvSLTLCT.strZone = "DLSLTLCT";
            dgvSLTLCT.BuildGridView();

            dgvLock.strZone = "LOCKLUONG";
            dgvLock.BuildGridView();

            dgvQuyLuong.strZone = "QUYLUONG";
            dgvQuyLuong.BuildGridView();

            dgvNghiLeCty.strZone = "NGHILECTY";
            dgvNghiLeCty.BuildGridView();

            dgvLock.ReadOnly = false;
            //phân quyền thấy lock
            if (!Element.sysIs_Admin && (!Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access)) && !Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access) && !Common.CheckPermission("IS_TP_PXSX", enuPermission_Type.Allow_Access))
                dgvLock.ReadOnly = true;
            else if (Element.sysIs_Admin || Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) || Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access))
            { dgvLock.ReadOnly = false; dgvLock.Columns["LOCK_SLSX"].ReadOnly = true; }
            else if (Element.sysIs_Admin || Common.CheckPermission("IS_TP_PXSX", enuPermission_Type.Allow_Access))
            { dgvLock.ReadOnly = false; dgvLock.Columns["LOCK_CONG"].ReadOnly = true; dgvLock.Columns["LOCK_LUONG"].ReadOnly = true; dgvLock.Columns["LOCK_SLKD"].ReadOnly = true; }
            if (!Element.sysIs_Admin && (!Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access)) && !Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access))
            {
                tabHeader.TabPages.Remove(tpQuyLuong);
                lblTk.Visible = false;
                txtTk.Visible = false;
            }
            
            //tlLuongTT.KeyFieldName = "MA_DT_CBNV";
            //tlLuongTT.ParentFieldName = "MA_BP";
            //tlLuongTT.Dock = DockStyle.Fill;
            //tlLuongTT.strZone = "LUONGTT";
            //tlLuongTT.BuildTreeList(this.isLookup);

            //this.tpLuongTT.Controls.Add(tlLuongTT);

            //tlHsABC.KeyFieldName = "MA_DT_CBNV";
            //tlHsABC.ParentFieldName = "MA_BP";
            //tlHsABC.Dock = DockStyle.Fill;
            //tlHsABC.strZone = "HSABC";
            //tlHsABC.BuildTreeList(this.isLookup);

            //this.tpHsABC.Controls.Add(tlHsABC);

            //dgvTsTinhLuong.strZone = "TSTINHLUONG";
            //dgvTsTinhLuong.BuildGridView();
		}
        private void BuildDataGridView()
        {
           

        }
		private void FillData()
		{

            Hashtable ht = new Hashtable();
            ht.Add("NAM", numNam.Value);
            
            dsSLTL = SQLExec.ExecuteReturnDs("sp_GetSLTL", ht, CommandType.StoredProcedure);

            bdsThangList.DataSource = dsSLTL.Tables[0];
            bdsThangList.Position = bdsThangList.Count;
            tlSLTL.DataSource = bdsThangList;

            dtKHNam = dsSLTL.Tables[1];
            if (dtKHNam.Rows.Count > 0)
            {
                
                numHSQD.Value = Convert.ToDouble(dtKHNam.Rows[0]["HSQD"]);
            }

            dtSLTL = dsSLTL.Tables[2];
            bdsSLTL.DataSource = dtSLTL;
            dgvSLTL.DataSource = bdsSLTL;

            

            dtSLTLCT = dsSLTL.Tables[4];
            bdsSLTLCT.DataSource = dtSLTLCT;
            dgvSLTLCT.DataSource = bdsSLTLCT;


            dtLock = dsSLTL.Tables[5];
            bdsLock.DataSource = dtLock;
            dgvLock.DataSource = bdsLock;

            dtQuyLuong = dsSLTL.Tables[6];
            bdsQuyLuong.DataSource = dtQuyLuong;
            dgvQuyLuong.DataSource = bdsQuyLuong;

            dtNghiLeCty = dsSLTL.Tables[7];
            bdsNghiLeCty.DataSource = dtNghiLeCty;
            dgvNghiLeCty.DataSource = bdsNghiLeCty;

            ExportControl = dgvKQPBSL;
            
		}
        private void FillData(int iThang)
        {
            if (Element.sysIs_Admin || Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) 
                    || Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access) 
                    || Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access)
                    || Common.Inlist(Element.sysUser_Id, Parameters.GetParaValue("USER_SLTL").ToString()))
                strMa_Bp = "";

            Hashtable ht = new Hashtable();
            ht.Add("NAM", numNam.Value);
            ht.Add("THANG", iThang);
            ht.Add("MA_BP", strMa_Bp);
            ht.Add("TK", txtTk.Text);
            dsSLTL = SQLExec.ExecuteReturnDs("sp_GetSLTL", ht, CommandType.StoredProcedure);
            
            if(dsSLTL.Tables[1].Rows.Count>0)
                numHSQD.Value = Convert.ToDouble(dsSLTL.Tables[1].Rows[0]["HSQD"]);

            dtSLTL = dsSLTL.Tables[2];
            bdsSLTL.DataSource = dtSLTL;
            dgvSLTL.DataSource = bdsSLTL;



            dtSLTLCT = dsSLTL.Tables[4];
            bdsSLTLCT.DataSource = dtSLTLCT;
            dgvSLTLCT.DataSource = bdsSLTLCT;

            bdsKQPBSL.DataSource = dsSLTL.Tables[3];
            dgvKQPBSL.DataSource = bdsKQPBSL;

            dtQuyLuong = dsSLTL.Tables[6];
            bdsQuyLuong.DataSource = dtQuyLuong;
            dgvQuyLuong.DataSource = bdsQuyLuong;
         
        }

        //private void FillData_LuongTT(string strMa_Bp, int iThang)
        //{
        //    Hashtable ht = new Hashtable();


        //    if (Element.sysIs_Admin || Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) || Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access) || Common.CheckPermission("IS_GIAMDOC", enuPermission_Type.Allow_Access))
        //        strMa_Bp = "";

        //    ht.Add("MA_BP", strMa_Bp);
        //    ht.Add("NAM", numNam.Value);
        //    ht.Add("THANG", iThang);
        //    dsLuongTT = SQLExec.ExecuteReturnDs("sp_GetLuongTT", ht, CommandType.StoredProcedure);
        //    dtLuongTT = dsLuongTT.Tables[0];
        //    bdsLuongTT.DataSource = dsLuongTT.Tables[0];
        //    tlLuongTT.DataSource = bdsLuongTT;
        //    tlLuongTT.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlLuongTT.strZone + "'");

        //   //bdsHsABC.DataSource = dsLuongTT.Tables[1];
        //   //tlHsABC.DataSource = bdsHsABC;
        //   //tlHsABC.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlHsABC.strZone + "'");


        //   //dtTsTinhLuong = dsLuongTT.Tables[2];
        //   //bdsTsTinhLuong.DataSource = dtTsTinhLuong;
        //   //dgvTsTinhLuong.DataSource = bdsTsTinhLuong;

        //}
        void numNam_Validated(object sender, EventArgs e)
        {
            FillData();
        }
		void btFilter_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

        void Delete_NVKChamCong()
        {
            //if (bdsBsChamCong.Position < 0)
            //    return;

            //DataRow drCurrent = ((DataRowView)bdsBsChamCong.Current).Row;

            //if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
            //    return;

            //if (DataTool.SQLDelete("R10TTCHAMCONG", drCurrent))
            //{
            //    bdsBsChamCong.RemoveAt(bdsBsChamCong.Position);
            //    dtBsChamCong.AcceptChanges();
            //}
        }
        void Delete_CongTangCa()
        {
            //if (bdsCongTangCa.Position < 0)
            //    return;

            //DataRow drCurrent = ((DataRowView)bdsCongTangCa.Current).Row;
            
            //if ((bool)drCurrent["Duyet_Tp"])
            //    return;
            
            //if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
            //    return;

            //if (DataTool.SQLDelete("R10CONGTANGCA", drCurrent))
            //{
            //    bdsCongTangCa.RemoveAt(bdsCongTangCa.Position);
            //    dtCongTangCa.AcceptChanges();
            //}
        }
        void btDelete_Click(object sender, EventArgs e)
        {
            //if (this.tbChitiet.SelectedTab == tabPage3)
            //    Delete_NVKChamCong();
            //else if (this.tbChitiet.SelectedTab == tabPage5)
            //    Delete_CongTangCa();
        }
        void btCheckDG_Click(object sender, EventArgs e)
        {
            if (strMa_Bp == "")
                strMa_Bp = "*";
            drCurrent = ((DataRowView)bdsThangList.Current).Row;
            int iThang1 = Convert.ToInt16(drCurrent["Thang"]);
            frmDGBPCT frm = new frmDGBPCT();
            frm.show(strMa_Bp, Convert.ToInt16(numNam.Value), iThang1);
        }
        
      
        void btPhanBo_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsThangList.Current).Row;
            Hashtable ht = new Hashtable();
            ht.Add("NAM", drCurrent["Nam"]);
            ht.Add("THANG", drCurrent["Thang"]);
            if (SQLExec.Execute("sp_CalQuyLuongBPCT", ht, CommandType.StoredProcedure))
            {
                Common.MsgOk("Bạn đã phân bổ quỹ lương trong tháng " + drCurrent["Thang"] + " năm " + drCurrent["Nam"]  + "");

                FillData(Convert.ToInt16(drCurrent["Thang"]));
            }
            tabHeader.SelectedTab = tabHeader.TabPages["tpKQPBSL"];
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsThangList.Current).Row;
            //if (this.objActive == dgvSLTL || this.objActive == dgvSLTLCT)
            //{
               
                frmSLTinhLuong_Edit frm = new frmSLTinhLuong_Edit();
                frm.Load(enuEdit.Edit, drCurrent, false);
            //}




                FillData(Convert.ToInt16(drCurrent["Thang"]));
        }

        void btUpdate_Click(object sender, EventArgs e)
        {
            int iThang = 0;
            if (bdsThangList.Position >= 0 && DataTool.SQLCheckExist("R10SLTL", new string[] {"Thang", "Nam"}, new object[] {Voucher.GetDateServer().Month, numNam.Value}))
            {
                drCurrent = ((DataRowView)bdsThangList.Current).Row;
                iThang = Convert.ToInt16(drCurrent["Thang"]);
            }
            else
            {
                iThang = Voucher.GetDateServer().Month;
            }
            if (Common.MsgYes_No("Bạn có muốn cập nhật sản lượng trong tháng " + iThang + " năm " + numNam.Value + "", "Y"))
            {
                //Cập nhật sản lượng tháng năm
                Hashtable ht = new Hashtable();
                ht.Add("NAM", numNam.Value);
                ht.Add("THANG", iThang);
                ht.Add("USER_LOG", Common.GetCurrent_Log());

                SQLExec.Execute("sp_UpdateSLTL", ht, CommandType.StoredProcedure);

                FillData(iThang);
                bdsThangList.MoveLast();
            }
        }
       
        void btNewKH_Click(object sender, EventArgs e)
        {
            frmSLTinhLuong_Edit frm = new frmSLTinhLuong_Edit();
            frm.Load(enuEdit.Edit, drCurrent, true);
        }
		
        private void Design()
        {
           
        }
        
        void Edit(enuEdit enuNew_Edit)
        {
            //if (bdsBsChamCong.Position < 0 && enuNew_Edit == enuEdit.Edit)
            //    return;

            ////Copy hang hien tai            
            //if (bdsBsChamCong.Position >= 0)
            //    Common.CopyDataRow(((DataRowView)bdsBsChamCong.Current).Row, ref drCurrent);
            //else
            //    drCurrent = dtBsChamCong.NewRow();

            //frmNVKChamCong_Edit frmEdit = new frmNVKChamCong_Edit();
            //frmEdit.Load(enuNew_Edit, drCurrent);
            
            //if (frmEdit.isAccept)
            //{
            //    DataRow drDmDtCbNv = DataTool.SQLGetDataRowByID("R81DMDT", "Ma_Dt", drCurrent["Ma_Dt_CbNv"].ToString());
            //    drCurrent["Ten_Dt_CbNv"] = drDmDtCbNv["Ten_Dt"];

            //    DataTable dtType = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMTYPE WHERE Type = 'TRANG_THAI_CONG' AND Type_ID = '" + drCurrent["Tinh_Trang_Cong"].ToString() + "'");
            //    DataRow drDmType = dtType.Rows[0];
            //    drCurrent["Ten_Tinh_Trang_Cong"] = drDmType["Type_Name"];


            //    if (enuNew_Edit == enuEdit.New)
            //        if (bdsBsChamCong.Position >= 0)
            //            dtBsChamCong.ImportRow(drCurrent);
            //        else
            //            dtBsChamCong.Rows.Add(drCurrent);
            //    else
            //    {
            //        Common.CopyDataRow(drCurrent, ((DataRowView)bdsBsChamCong.Current).Row);
            //    }


            //    bdsBsChamCong.Position = bdsBsChamCong.Find("IDENT00", drCurrent["IDENT00"]);
            //    dtBsChamCong.AcceptChanges();
            //}
            //else
            //    dtBsChamCong.RejectChanges();
        }
        
		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
        void txtTk_Enter(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsThangList.Current).Row;
            bdsSLTL.Filter = "Thang = " + drCurrent["Thang"] + "";
            bdsSLTLCT.Filter = "Thang = " + drCurrent["Thang"] + "";
            bdsLock.Filter = "Thang = " + drCurrent["Thang"] + "";
            bdsQuyLuong.Filter = "Thang = " + drCurrent["Thang"] + "";

            FillData(Convert.ToInt16(drCurrent["Thang"]));
            clickupdate();
        }

        void bdsThangList_PositionChanged(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsThangList.Current).Row;
            bdsSLTL.Filter = "Thang = " + drCurrent["Thang"] + "";
            bdsSLTLCT.Filter = "Thang = " + drCurrent["Thang"] + "";
            bdsLock.Filter = "Thang = " + drCurrent["Thang"] + "";
            bdsQuyLuong.Filter = "Thang = " + drCurrent["Thang"] + "";

            FillData(Convert.ToInt16(drCurrent["Thang"]));

          
            clickupdate();
           
            //FillData_LuongTT(strMa_Bp, Convert.ToInt16(drCurrent["Thang"]));
        }
      
        void dgvSLTLCT_Enter(object sender, EventArgs e)
        {
            //ExportControl = sender;
            //objActive = dgvSLTLCT;
        }

        void dgvSLTL_Enter(object sender, EventArgs e)
        {
            //ExportControl = sender;
            //objActive = dgvSLTLCT;
        }
        private void DgvLock_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            drCurrent = ((DataRowView)bdsLock.Current).Row;
            string strColumnName = dgvLock.Columns[e.ColumnIndex].Name;
            string strUpdate = string.Empty;
            DataRow drThang = ((DataRowView)bdsThangList.Current).Row;
            if (drCurrent["Ngay_Locked1"].ToString() != "" && drCurrent["Ngay_Locked2"].ToString() != "")
            {
                Hashtable ht1 = new Hashtable();
                ht1.Add("NAM", numNam.Value);
                ht1.Add("THANG", drThang["Thang"]);
                ht1.Add("NGAY_LOCKED1", drCurrent["Ngay_Locked1"]);
                ht1.Add("NGAY_LOCKED2", drCurrent["Ngay_Locked2"]);
                ht1.Add("USER_LOCK", Common.GetCurrent_Log());

                strUpdate = "UPDATE R00LOCKEDLUONG SET Ngay_Locked1 = @Ngay_Locked1, Ngay_Locked2 = @Ngay_Locked2, USER_Lock_Cong = @User_Lock WHERE NAM = @Nam AND Thang = @Thang";
                SQLExec.Execute(strUpdate, ht1, CommandType.Text);
            }

        }
        void dgvLock_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsLock.Current).Row;
            string strColumnName = dgvLock.Columns[e.ColumnIndex].Name;
            string strUpdate = string.Empty;
            DataRow drThang = ((DataRowView)bdsThangList.Current).Row;

            if (strColumnName.StartsWith("LOCK"))
            {
                if (strColumnName == "LOCK_CONG")// && drCurrent["Ngay_Locked1"].ToString() == "" && drCurrent["Ngay_Locked2"].ToString() == "")
                {
                    drCurrent["Ngay_Locked2"] = Voucher.GetLastDayOfMonth(Convert.ToInt16(numNam.Value), Convert.ToInt16(drThang["Thang"]));
                    drCurrent["Ngay_Locked1"] = Voucher.GetFirstDayOfMonth(Convert.ToDateTime(drCurrent["Ngay_Locked2"]));
                }
                
                if (Common.MsgYes_No("Bạn muốn khóa " + strColumnName + " không?", "Y"))
                {
                    drCurrent = ((DataRowView)bdsLock.Current).Row;                
                    Hashtable ht = new Hashtable();
                    ht.Add("LOCK", !(bool)drCurrent[strColumnName]);
                    ht.Add("NAM", numNam.Value);
                    ht.Add("THANG", drThang["Thang"]);
                    ht.Add("NGAY_LOCKED1", drCurrent["Ngay_Locked1"]);
                    ht.Add("NGAY_LOCKED2", drCurrent["Ngay_Locked2"]);
                    ht.Add("USER_LOCK", Common.GetCurrent_Log());

                    if (strColumnName == "LOCK_LUONG")
                    {
                        if (!(bool)drCurrent["Lock_SLSX"])
                        {
                            strUpdate = "UPDATE R00LOCKEDLUONG SET Lock_SLKD = 1, Lock_SLSX = 1, Lock_Cong = 1, " + strColumnName + " = @Lock, USER_" + strColumnName + " = @User_Lock WHERE NAM = @Nam AND Thang = @Thang";
                            drCurrent["Lock_SLSX"] = !(bool)drCurrent[strColumnName];
                        }
                        else
                        {
                            strUpdate = "UPDATE R00LOCKEDLUONG SET " + strColumnName + " = @Lock, USER_" + strColumnName + " = @User_Lock WHERE NAM = @Nam AND Thang = @Thang";
                            drCurrent[strColumnName] = !(bool)drCurrent[strColumnName];
                        }
                      
                    }
                    else if (strColumnName == "LOCK_CONG")
                        strUpdate = "UPDATE R00LOCKEDLUONG SET " + strColumnName + " = @Lock, Ngay_Locked1 = @Ngay_Locked1, Ngay_Locked2 = @Ngay_Locked2, USER_" + strColumnName + " = @User_Lock WHERE NAM = @Nam AND Thang = @Thang";
                    else
                        strUpdate = "UPDATE R00LOCKEDLUONG SET " + strColumnName + " = @Lock, USER_" + strColumnName + " = @User_Lock WHERE NAM = @Nam AND Thang = @Thang";

                    SQLExec.Execute(strUpdate, ht, CommandType.Text);

                    //drCurrent[strColumnName] = !(bool)drCurrent[strColumnName];
                    drCurrent.AcceptChanges();
                }
            }
           

        }
        void EditNgayLeCty(enuEdit enuNew_Edit)
        {
            if (bdsNghiLeCty.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsNghiLeCty.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsNghiLeCty.Current).Row, ref drCurrent);
            else
                drCurrent = dtNghiLeCty.NewRow();

            frmDmNgayLeCty_Edit frmEdit = new frmDmNgayLeCty_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                


                if (enuNew_Edit == enuEdit.New)
                    if (bdsNghiLeCty.Position >= 0)
                        dtNghiLeCty.ImportRow(drCurrent);
                    else
                        dtNghiLeCty.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsNghiLeCty.Current).Row);
                }


                bdsNghiLeCty.Position = bdsNghiLeCty.Find("IDENT00", drCurrent["IDENT00"]);
                dtNghiLeCty.AcceptChanges();
            }
            else
                dtNghiLeCty.RejectChanges();
        }
        private void DgvNghiLeCty_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsNghiLeCty.Current).Row;
            DataGridViewCell dgvCell = dgvNghiLeCty.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "NEW")
            {
                EditNgayLeCty(enuEdit.New);
           
            }
            if (strColumnName == "EDIT")
            {
                string strCreate_User = (string)drCurrent["Create_Log"];

                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id && !Element.sysIs_Admin && Element.sysUser_Id != "LANHDP")
                {

                    Common.MsgCancel("Không được sửa dữ liệu do " + strCreate_User.Substring(14) + " lập!!!");
                    return;

                }

                else
                {
                    EditNgayLeCty(enuEdit.Edit);

                }
            }
        }
        
        protected override void OnKeyDown(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)
                return;

            switch (e.KeyCode)
            {
                case Keys.F7:
                    if (e.Modifiers == Keys.Shift)
                        this.Design();
                    return;
            }

            base.OnKeyDown(e);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

           

        }

        //private void btNew1_Click(object sender, EventArgs e)
        //{

        //}
	}
}
