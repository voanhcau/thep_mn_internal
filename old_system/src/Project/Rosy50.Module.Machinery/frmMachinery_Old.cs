using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using System.Data.SqlClient;

namespace RosyModule.Machinery
{
    public partial class frmMachinery_Old : RosySystem.Customize.frmView
    {
        public DataSet dsMachinery = new DataSet("dsMachinery");
        string strReportFile = string.Empty;
        object objFileContent = null;

        DataTable dtDmNhVtTb = new DataTable();
        BindingSource bdsDmNhVtTb = new BindingSource();
        rsTreeList tlDmNhVtTb = new rsTreeList();
        DataRow drDmNhVtTb;

        DataSet dsDmCtVtTb = new DataSet();
        DataTable dtDmCtVtTb = new DataTable();
        BindingSource bdsDmCtVtTb = new BindingSource();
        rsTreeList tlDmCtVtTb = new rsTreeList();
        DataRow drDmCtVtTb;

        DataSet dsDmBtVtTb = new DataSet();
        DataTable dtDmBtVtTb = new DataTable();
        BindingSource bdsDmBtVtTb = new BindingSource();
        rsTreeList tlDmBtVtTb = new rsTreeList();
        DataRow drDmBtVtTb;

       
        
        // Tab Lịch sử bảo trì
        DataSet dsLichSu = new DataSet();
        DataTable dtLichSu = new DataTable();
        BindingSource bdsLichSu = new BindingSource();
        rsTreeList tlLichSu = new rsTreeList();
        DataRow drLichSu;

        DataTable dtLichSu_DK = new DataTable();
        BindingSource bdsLichSu_DK = new BindingSource();
        rsDataGridView dgvLichSu_DK = new rsDataGridView();
        DataRow drLichSu_DK;

        DataTable dtLichSu_TT = new DataTable();
        BindingSource bdsLichSu_TT = new BindingSource();
        rsDataGridView dgvLichSu_TT = new rsDataGridView();
        DataRow drLichSu_TT;

        DataTable dtLichSu_VT = new DataTable();
        BindingSource bdsLichSu_VT = new BindingSource();
        rsDataGridView dgvLichSu_VT = new rsDataGridView();
        // hết
        DataTable dtMoTaChung = new DataTable();
        BindingSource bdsMoTaChung = new BindingSource();
        rsDataGridView dgvMoTaChung = new rsDataGridView();
        DataRow drMoTaChung;

        DataTable dtTanSoNhTb = new DataTable();
        BindingSource bdsTanSoNhTb = new BindingSource();
        rsDataGridView dgvTanSoNhTb = new rsDataGridView();
        DataRow drTanSoNhTb;

        DataTable dtBbNhTb = new DataTable();
        BindingSource bdsBbNhTb = new BindingSource();
        rsDataGridView dgvBbNhTb = new rsDataGridView();
        DataRow drBbNhTb;

        DataTable dtPTKT = new DataTable();
        BindingSource bdsPTKT = new BindingSource();
        rsDataGridView dgvPTKT = new rsDataGridView();
        DataRow drPTKT;

        DataTable dtPTDP = new DataTable();
        BindingSource bdsPTDP = new BindingSource();
        rsDataGridView dgvPTDP = new rsDataGridView();
        DataRow drPTDP;

        DataTable dtTanSoTb = new DataTable();
        BindingSource bdsTanSoTb = new BindingSource();
        rsDataGridView dgvTanSoTb = new rsDataGridView();
        DataRow drTanSoTb;

        DataTable dtCongViecBT = new DataTable();
        BindingSource bdsCongViecBT = new BindingSource();
        rsDataGridView dgvCongViecBT = new rsDataGridView();
        DataRow drCongViecBT;

        DataTable dtCongViecCT = new DataTable();
        BindingSource bdsCongViecCT = new BindingSource();
        rsDataGridView dgvCongViecCT = new rsDataGridView();
        DataRow drCongViecCT;

        DataTable dtPhuTungBT = new DataTable();
        BindingSource bdsPhuTungBT = new BindingSource();
        rsDataGridView dgvPhuTungBT = new rsDataGridView();
        DataRow drPhuTungBT;

		DataTable dtKHBTSC = new DataTable();
		BindingSource bdsKHBTSC = new BindingSource();
		rsDataGridView dgvKHBTSC = new rsDataGridView();

        private DataRow drCurrent;
        
        public frmMachinery_Old()
        {
            InitializeComponent();
            //dgvDmVtTb.KeyDown += new KeyEventHandler(dgvDmVtTb_KeyDown);
            tlDmCtVtTb.KeyDown += new KeyEventHandler(tlDmCtVtTb_KeyDown);
            tlDmNhVtTb.KeyDown += new KeyEventHandler(tlDmNhVtTb_KeyDown);
            dgvMoTaChung.KeyDown += new KeyEventHandler(dgvMoTaChung_KeyDown);
            dgvTanSoNhTb.KeyDown += new KeyEventHandler(dgvTanSoNhTb_KeyDown);
            dgvTanSoTb.KeyDown += new KeyEventHandler(dgvTanSoTb_KeyDown);
            dgvCongViecCT.KeyDown += new KeyEventHandler(dgvCongViecCT_KeyDown);
            dgvPTKT.KeyDown+=new KeyEventHandler(dgvPTKT_KeyDown);
            dgvPTDP.KeyDown += new KeyEventHandler(dgvPTDP_KeyDown);
            dgvCongViecBT.KeyDown += new KeyEventHandler(dgvCongViecBT_KeyDown);
            dgvPhuTungBT.KeyDown += new KeyEventHandler(dgvPhuTungBT_KeyDown);


            bdsDmNhVtTb.PositionChanged += new EventHandler(bdsDmNhVtTb_PositionChanged);
            bdsDmCtVtTb.PositionChanged += new EventHandler(bdsDmVtTb_PositionChanged);
            bdsCongViecBT.PositionChanged += new EventHandler(bdsCongViecBT_PositionChanged);
            bdsLichSu.PositionChanged += new EventHandler(bdsLichSu_PositionChanged);
            bdsLichSu_DK.PositionChanged += new EventHandler(bdsLichSu_DK_PositionChanged);
            bdsLichSu_TT.PositionChanged += new EventHandler(bdsLichSu_TT_PositionChanged);
         

          
            btPreview.Click += new EventHandler(btPreview_Click);
            btPreview_KHBT.Click += new EventHandler(btPreview_KHBT_Click);
            
            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            btAddVTPT.Click += new EventHandler(btAddVTPT_Click);
            btAdd_DNX.Click += new EventHandler(btAdd_DNX_Click);
            btAdd_PYC.Click += new EventHandler(btAdd_PYC_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
        }

        

        void btAdd_PYC_Click(object sender, EventArgs e)
        {
           frmVoucher_View frm = new frmVoucher_View();
           frm.Load("PYCPT");
        }

        void btAdd_DNX_Click(object sender, EventArgs e)
        {
            frmDNX_View frm = new frmDNX_View();
            frm.Load("DNX");
        }

       

		void tabDetail_SelectedIndexChanged(object sender, EventArgs e)
		{
			tabChange();
		}

		void tabChange()
		{
           
		}

       

        void btDelete_Click(object sender, EventArgs e)
        {
            Machinery_Delete();
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            Machinery_Edit(enuEdit.Edit);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            Machinery_Edit(enuEdit.New);
        }

        void btAddVTPT_Click(object sender, EventArgs e)
        {
            if (rsTabControl2.SelectedTab == tbCauTrucTb && tabPTTB.SelectedTab == pagePTKT)
            {
                frmAddList_VTTB frm = new frmAddList_VTTB();
                frm.Load();

                if (frm.Is_Accept)
                    Save_PKKT(frm.dtDmVt,"1");
            }
            else if (rsTabControl2.SelectedTab == tbCauTrucTb && tabPTTB.SelectedTab == pagePTDP)
            {
                frmAddList_VTTB frm = new frmAddList_VTTB();
                frm.Load();

                if (frm.Is_Accept)
                    Save_PKKT(frm.dtDmVt, "2");
            }
            else if (rsTabControl2.SelectedTab == tbBaoTriTb && tabPhuTungBTDK.SelectedTab == pagePhuTungBT)
            {
                frmAddList_VTTB frm = new frmAddList_VTTB();
                frm.Load();

                if (frm.Is_Accept)
                {
                    Save_PhuTungBTDK(frm.dtDmVt);
                }
            }
            else
                Common.MsgOk("Vui lòng chọn form add vật tư !!! ");
        }

        bool Save_PhuTungBTDK(DataTable dtImport_PhuTung)
        {
            if (dtCongViecBT == null)
                return false;
            drCongViecBT = ((DataRowView)bdsCongViecBT.Current).Row;

            if (dtImport_PhuTung == null)
                return false;

            DataTable dtImport = dtImport_PhuTung.Clone();

            DataRow[] Result = dtImport_PhuTung.Select("CHON = 1");

            foreach (DataRow drImport in Result)
                dtImport.ImportRow(drImport);

            SqlCommand sqlCom = SQLExec.GetSQLCommand();
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.Add("CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.Add("MA_NH_TB", drDmNhVtTb["Ma_Nh_Tb"]);
            sqlCom.Parameters.Add("STT_ND", drCongViecBT["Stt_ND"]);
            sqlCom.Parameters.Add("MA_DVCS", Element.sysMa_DvCs);

            sqlCom.CommandText = "Sp_ImportTVP_PHUTUNGBTDK";

            SqlParameter sqlPara = new SqlParameter();
            sqlPara.ParameterName = "@TVP_Import";
            sqlPara.SqlDbType = SqlDbType.Structured;
            sqlPara.TypeName = "TVP_PHUTUNGBTDK";
            sqlPara.Value = Voucher.GetTVPValue("R06PHUTUNGBTDK", "TVP_PHUTUNGBTDK", dtImport);

            sqlCom.Parameters.Add(sqlPara);
            try
            {
                sqlCom.ExecuteNonQuery();
                
                Common.MsgOk(Languages.GetLanguage("IMPORT_SUCCESS"));

                DataTable dtEditCt = dtPhuTungBT;
                DataRow drEditCtNew = dtEditCt.NewRow();
                Common.CopyDataRow(dtEditCt.Rows[0], drEditCtNew);

                foreach (DataRow dr in dtImport.Rows)
                {
                    DataRow drEditCt = dtPhuTungBT.NewRow();
                    Common.CopyDataRow(drEditCtNew, drEditCt);

                    drEditCt["Ma_Vt"] = dr["Ma_Vt"];
                    drEditCt["Ten_Vt"] = dr["Ten_Vt"];
                    drEditCt["Dvt"] = dr["Dvt"];
                    drEditCt["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];
                   
                    drEditCt["Stt_Nd"] = drCongViecBT["Stt_Nd"];
                    drEditCt["So_Luong"] = 1;
                    
                   

                    dtPhuTungBT.Rows.Add(drEditCt);
                    drEditCt.AcceptChanges();
                }
                
               
            }
            catch (Exception ex)
            {
                Common.MsgOk(ex.Message);
                return false;
            }
            // 
            return true;
        }

        bool Save_PKKT(DataTable dtImport_PTKT, string strLoai_VtPt)
        {
            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;
            if (drDmCtVtTb["Ma_Tb"].ToString().Length <= 4)
            {
                Common.MsgOk("Vui lòng chọn lại thiết bị");
                return false;
            }
            if (dtImport_PTKT == null)
                return false;

            DataTable dtImport = dtImport_PTKT.Clone();

            DataRow[] Result = dtImport_PTKT.Select("CHON = 1");

            foreach (DataRow drImport in Result)
                dtImport.ImportRow(drImport);

            SqlCommand sqlCom = SQLExec.GetSQLCommand();
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            sqlCom.Parameters.Add("CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.Add("MA_DVCS", Element.sysMa_DvCs);
            sqlCom.Parameters.Add("MA_TB", drDmCtVtTb["Ma_Tb"]);
            sqlCom.Parameters.Add("LOAI_VTPT", strLoai_VtPt);

            sqlCom.CommandText = "Sp_ImportTVP_PTKT";

            SqlParameter sqlPara = new SqlParameter();
            sqlPara.ParameterName = "@TVP_Import";
            sqlPara.SqlDbType = SqlDbType.Structured;
            sqlPara.TypeName = "TVP_PTKT";
            sqlPara.Value = Voucher.GetTVPValue("R06VTTB", "TVP_PTKT", dtImport);

            sqlCom.Parameters.Add(sqlPara);
            try
            {
                sqlCom.ExecuteNonQuery();
                Common.MsgOk(Languages.GetLanguage("IMPORT_SUCCESS"));
                if (strLoai_VtPt == "1")
                {
                    DataTable dtEditCt = dtPTKT;
                    DataRow drEditCtNew = dtEditCt.NewRow();
                    Common.CopyDataRow(dtEditCt.Rows[0], drEditCtNew);

                    foreach (DataRow dr in dtImport.Rows)
                    {
                        DataRow drEditCt = dtPTKT.NewRow();
                        Common.CopyDataRow(drEditCtNew, drEditCt);

                        drEditCt["Ma_Vt"] = dr["Ma_Vt"];
                        drEditCt["Ten_Vt"] = dr["Ten_Vt"];
                        drEditCt["Dvt"] = dr["Dvt"];
                        drEditCt["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
                        drEditCt["So_Luong_LD"] = 1;



                        dtPTKT.Rows.Add(drEditCt);
                        drEditCt.AcceptChanges();
                    }
                }
                else
                {
                    DataTable dtEditCt = dtPTDP;
                    DataRow drEditCtNew = dtEditCt.NewRow();
                    Common.CopyDataRow(dtEditCt.Rows[0], drEditCtNew);

                    foreach (DataRow dr in dtImport.Rows)
                    {
                        DataRow drEditCt = dtPTDP.NewRow();
                        Common.CopyDataRow(drEditCtNew, drEditCt);

                        drEditCt["Ma_Vt"] = dr["Ma_Vt"];
                        drEditCt["Ten_Vt"] = dr["Ten_Vt"];
                        drEditCt["Dvt"] = dr["Dvt"];
                        drEditCt["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
                        drEditCt["So_Luong_LD"] = 1;



                        dtPTDP.Rows.Add(drEditCt);
                        drEditCt.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.MsgOk(ex.Message);
                return false;
            }
            // 
            return true;
        }
        void btPreview_Click(object sender, EventArgs e)
        {
            this.print(true);
        }
        void btPreview_KHBT_Click(object sender, EventArgs e)
        {
            printDetail_Tb(true);
        }
        void dgvPhuTungBT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditPhuTungBTDK(enuEdit.New);
                    break;
                case Keys.F3:
                    EditPhuTungBTDK(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deletePhuTungBTDK();
                    break;
            }
        }          
        void dgvCongViecBT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditCongViecBTDK(enuEdit.New);
                    break;
                case Keys.F3:
                    EditCongViecBTDK(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deleteCongViecBTDK();
                    break;
            }
        }
        void dgvPTKT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.EditPTKT(enuEdit.New);
                    break;

                case Keys.F3:
                    this.EditPTKT(enuEdit.Edit);
                    break;

                case Keys.F8:
                    this.deletePTKT();
                    break;

			
            }
        }
        void dgvPTDP_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.EditPTDP(enuEdit.New);
                    break;

                case Keys.F3:
                    this.EditPTDP(enuEdit.Edit);
                    break;

                case Keys.F8:
                    this.deletePTDP();
                    break;


            }
        }
        void tlDmCtVtTb_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    DmCtVtTb_Edit(enuEdit.New);
                    break;
                case Keys.F3:
                    DmCtVtTb_Edit(enuEdit.Edit);
                    break;
                case Keys.F8:
                    DmCtVtTb_Delete();
                    break;
            }
        }
        void tlDmNhVtTb_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Control:
                            this.print(true);
                            break;

                        case Keys.Shift:
                            this.Design();
                            break;

                        case Keys.None:
                            this.print(false);
                            break;
                    }
                    break;
            }
        }
        void dgvCongViecCT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditCongViecCT(enuEdit.New);
                    break;
                case Keys.F3:
                    EditCongViecCT(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deleteCongViecCT();
                    break;
            }
        }
        void dgvTanSoTb_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditTanSoTb(enuEdit.New);
                    break;
                case Keys.F3:
                    EditTanSoTb(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deleteTanSoTb();
                    break;
            }
        }
        void dgvTanSoNhTb_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditTanSoNhTb(enuEdit.New);
                    break;
                case Keys.F3:
                    EditTanSoNhTb(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deleteTanSoNhTb();
                    break;
            }
        }
        void dgvMoTaChung_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    EditMoTaChung(enuEdit.New);
                    break;
                case Keys.F3:
                    EditMoTaChung(enuEdit.Edit);
                    break;
                case Keys.F8:
                    deleteMoTaChung();
                    break;
            }
        }
        void deleteMoTaChung()
        {
            if (bdsMoTaChung.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsMoTaChung.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06MOTATB", drCurrent))
            {
                bdsMoTaChung.RemoveAt(bdsMoTaChung.Position);
                dtMoTaChung.AcceptChanges();
            }
        }
        void deleteTanSoTb()
        {
            if (bdsTanSoTb.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsTanSoTb.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06TSVTTB", drCurrent))
            {
                bdsTanSoTb.RemoveAt(bdsTanSoTb.Position);
                dtTanSoTb.AcceptChanges();
            }
        }
        void deleteTanSoNhTb()
        {
            if (bdsTanSoNhTb.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsTanSoNhTb.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06TSNHTB", drCurrent))
            {
                bdsTanSoNhTb.RemoveAt(bdsTanSoNhTb.Position);
                dtTanSoNhTb.AcceptChanges();
            }
        }
        void deletePTDP()
        {
            if (bdsPTDP.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPTDP.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06VTTB", drCurrent))
            {
                bdsPTDP.RemoveAt(bdsPTDP.Position);
                dtPTDP.AcceptChanges();
            }
        }
        void deletePTKT()
        {
            if (bdsPTKT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPTKT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06VTTB", drCurrent))
            {
                bdsPTKT.RemoveAt(bdsPTKT.Position);
                dtPTKT.AcceptChanges();
            }
        }
        void deleteCongViecCT()
        {
            if (bdsCongViecCT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsCongViecCT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06CONGVIECBTDK", drCurrent))
            {
                bdsCongViecCT.RemoveAt(bdsCongViecCT.Position);
                dtCongViecCT.AcceptChanges();
            }
        }

        void deletePhuTungBTDK()
        {
            if (bdsPhuTungBT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPhuTungBT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06PHUTUNGBTDK", drCurrent))
            {
                bdsPhuTungBT.RemoveAt(bdsPhuTungBT.Position);
                dtPhuTungBT.AcceptChanges();
            }
        }

		void deleteKHBTSC()
		{
			if (bdsKHBTSC.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsKHBTSC.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R06KHBTSC", drCurrent))
			{
				bdsKHBTSC.RemoveAt(bdsKHBTSC.Position);
				dtKHBTSC.AcceptChanges();
			}
		}

        void deleteTanSoTB()
        {
            if (bdsTanSoTb.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsTanSoTb.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06TSVTTB", drCurrent))
            {
                bdsTanSoTb.RemoveAt(bdsTanSoTb.Position);
                dtTanSoTb.AcceptChanges();
            }
        }

        void deleteCongViecBTDK()
        {
            if (bdsCongViecBT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsCongViecBT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06CONGVIECBTDK", drCurrent))
            {
                bdsCongViecBT.RemoveAt(bdsCongViecBT.Position);
                dtCongViecBT.AcceptChanges();
            }
        }

        //void deleteImage()
        //{
        //    if (bdsDmVtTb.Position < 0)
        //        return;

        //    if (!Common.MsgYes_No("Bạn muốn remove hình ảnh"))
        //        return;

        //    drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;
        //    Hashtable ht = new Hashtable();

        //    ht.Add("MA_VT_TB", (string)drDmVtTb["Ma_Vt"]);

        //    SQLExec.Execute("UPDATE R81DMVT SET Hinh = NULL WHERE Ma_Vt = @Ma_Vt_Tb", ht, CommandType.Text);

        //    loadImage();
        //}
        void EditPhuTungBTDK(enuEdit enuNew_Edit)
        {
            if (bdsDmNhVtTb.Position < 0)
                return;
            if (bdsCongViecBT.Position < 0)
                return;

            if (bdsPhuTungBT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            
            drCongViecBT = ((DataRowView)bdsCongViecBT.Current).Row;

            //Copy dong hien tai
            if (bdsPhuTungBT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPhuTungBT.Current).Row, ref drCurrent);
            else
                drCurrent = dtPhuTungBT.NewRow();

            drCurrent["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];
           
            drCurrent["Stt_Nd"] = drCongViecBT["Stt_Nd"];

            frmPhuTungBTDK_Edit frmEdit = new frmPhuTungBTDK_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsPhuTungBT.Position >= 0)
                        dtPhuTungBT.ImportRow(drCurrent);
                    else
                        dtPhuTungBT.Rows.Add(drCurrent);

                    bdsPhuTungBT.Position = bdsPhuTungBT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsPhuTungBT.Current).Row);

                dtPhuTungBT.AcceptChanges();
            }
            else
                dtPhuTungBT.RejectChanges();
        }
        void EditTanSoVtTb(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsTanSoTb.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsTanSoTb.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsTanSoTb.Current).Row, ref drCurrent);
            else
                drCurrent = dtTanSoTb.NewRow();

            drCurrent["Ma_Tb"] = drDmNhVtTb["Ma_Tb"];
            frmTanSoVTTB_Edit frmEdit = new frmTanSoVTTB_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsTanSoTb.Position >= 0)
                        dtTanSoTb.ImportRow(drCurrent);
                    else
                        dtTanSoTb.Rows.Add(drCurrent);

                    bdsTanSoTb.Position = bdsTanSoTb.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsTanSoTb.Current).Row);

                dtTanSoTb.AcceptChanges();
            }
            else
                dtTanSoTb.RejectChanges();
        }
        void EditTanSoNhTb(enuEdit enuNew_Edit)
        {
            if (bdsDmNhVtTb.Position < 0)
                return;

            if (bdsTanSoNhTb.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsTanSoNhTb.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsTanSoNhTb.Current).Row, ref drCurrent);
            else
                drCurrent = dtTanSoNhTb.NewRow();

            drCurrent["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];
            frmTanSoNhTb_Edit frmEdit = new frmTanSoNhTb_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsTanSoNhTb.Position >= 0)
                        dtTanSoNhTb.ImportRow(drCurrent);
                    else
                        dtTanSoNhTb.Rows.Add(drCurrent);

                    bdsTanSoNhTb.Position = bdsTanSoNhTb.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsTanSoNhTb.Current).Row);

                dtTanSoNhTb.AcceptChanges();
            }
            else
                dtTanSoNhTb.RejectChanges();
        }
        void EditCongViecBTDK(enuEdit enuNew_Edit)
        {
            if (bdsDmNhVtTb.Position < 0)
                return;
         

            if (bdsCongViecBT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
           

            //Copy dong hien tai
            if (bdsCongViecBT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsCongViecBT.Current).Row, ref drCurrent);
            else
                drCurrent = dtCongViecBT.NewRow();

            drCurrent["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];
           
            frmCongViecBTDK_Edit frmEdit = new frmCongViecBTDK_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsCongViecBT.Position >= 0)
                        dtCongViecBT.ImportRow(drCurrent);
                    else
                        dtCongViecBT.Rows.Add(drCurrent);

                    bdsCongViecBT.Position = bdsCongViecBT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCongViecBT.Current).Row);

                dtCongViecBT.AcceptChanges();
            }
            else
                dtCongViecBT.RejectChanges();
        }
        void EditMoTaChung(enuEdit enuNew_Edit)
        {
            if (bdsDmNhVtTb.Position < 0)
                return;

            if (bdsMoTaChung.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsMoTaChung.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsMoTaChung.Current).Row, ref drCurrent);
            else
                drCurrent = dtMoTaChung.NewRow();

            drCurrent["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];
            frmMoTaChung_Edit frmEdit = new frmMoTaChung_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsMoTaChung.Position >= 0)
                        dtMoTaChung.ImportRow(drCurrent);
                    else
                        dtMoTaChung.Rows.Add(drCurrent);

                    bdsMoTaChung.Position = bdsMoTaChung.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsMoTaChung.Current).Row);

                dtMoTaChung.AcceptChanges();
            }
            else
                dtMoTaChung.RejectChanges();
        }

        void EditPTKT(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsPTKT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsPTKT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPTKT.Current).Row, ref drCurrent);
            else
                drCurrent = dtPTKT.NewRow();

            drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            frmPTKT_Edit frmEdit = new frmPTKT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                                   
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsPTKT.Position >= 0)
                        dtPTKT.ImportRow(drCurrent);
                    else
                        dtPTKT.Rows.Add(drCurrent);

                    bdsPTKT.Position = bdsPTKT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsPTKT.Current).Row);

                dtPTKT.AcceptChanges();
            }
            else
                dtPTKT.RejectChanges();
        }
        void EditPTDP(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsPTDP.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsPTDP.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPTDP.Current).Row, ref drCurrent);
            else
                drCurrent = dtPTDP.NewRow();

            drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            frmPTKT_Edit frmEdit = new frmPTKT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsPTDP.Position >= 0)
                        dtPTDP.ImportRow(drCurrent);
                    else
                        dtPTDP.Rows.Add(drCurrent);

                    bdsPTDP.Position = bdsPTDP.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsPTDP.Current).Row);

                dtPTDP.AcceptChanges();
            }
            else
                dtPTDP.RejectChanges();
        }
        void EditCongViecCT(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsCongViecCT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;
            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            
            //Copy dong hien tai
            if (bdsCongViecCT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsCongViecCT.Current).Row, ref drCurrent);
            else
                drCurrent = dtCongViecCT.NewRow();

            drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            drCurrent["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];
            frmCongViecBTDK_Edit frmEdit = new frmCongViecBTDK_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsCongViecCT.Position >= 0)
                    {
                        dtCongViecCT.ImportRow(drCurrent);
                        dtCongViecBT.ImportRow(drCurrent);
                    }
                    else
                    {
                        dtCongViecCT.Rows.Add(drCurrent);
                        dtCongViecBT.Rows.Add(drCurrent);
                    }
                    bdsCongViecCT.Position = bdsCongViecCT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCongViecCT.Current).Row);
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCongViecBT.Current).Row);
                }
                dtCongViecCT.AcceptChanges();
            }
            else
                dtCongViecCT.RejectChanges();
        }

        void EditTanSoTb(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            if (bdsTanSoTb.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            //Copy dòng hiện tại
            if (bdsTanSoTb.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsTanSoTb.Current).Row, ref drCurrent);
            else
                drCurrent = dtTanSoTb.NewRow();

            drCurrent["Ma_Tb"] = drDmCtVtTb["Ma_Tb"];
            //if (enuNew_Edit == enuEdit.New && drCurrent.Table.Columns.Contains("Trong_Ke_Hoach"))
            //    drCurrent["Trong_Ke_Hoach"] = false;

            frmKHBT_Edit frmEdit = new frmKHBT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {

                if (drCurrent.Table.Columns.Contains("Ten_Tan_So"))
                    drCurrent["Ten_Tan_So"] = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", drCurrent["Tan_So"].ToString());

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsTanSoTb.Position >= 0)
                        dtTanSoTb.ImportRow(drCurrent);
                    else
                        dtTanSoTb.Rows.Add(drCurrent);

                    bdsTanSoTb.Position = bdsTanSoTb.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsTanSoTb.Current).Row);

                dtTanSoTb.AcceptChanges();
            }
            else
                dtTanSoTb.RejectChanges();
        }

        void bdsDmVtTb_PositionChanged(object sender, EventArgs e)
        {
            FilterDetail();
        }
       
        void bdsCongViecBT_PositionChanged(object sender, EventArgs e)
        {
            
            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            drCongViecBT = ((DataRowView)bdsCongViecBT.Current).Row;

            bdsPhuTungBT.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "' AND Stt_ND = "+ drCongViecBT["Stt_ND"] +"";
        }
        private void FilterDetail()
        {

            if (bdsDmCtVtTb.Position < 0)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;
           
            bdsTanSoTb.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsPTKT.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsPTDP.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";
            bdsCongViecCT.Filter = "Ma_Tb = '" + (string)drDmCtVtTb["Ma_Tb"] + "'";

            loadImage();
        }
        private void FilterDetailCT()
        {
            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            bdsDmCtVtTb.Filter = "Ma_Nh_Tb_Parent = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
        }
        private void FilterDetailBT()
        {
            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;

            bdsCongViecBT.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            bdsPhuTungBT.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
        }
        private void loadImage()
        {
            //object objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM R81DMVT WHERE Ma_Vt = '" + drDmVtTb["Ma_Vt"].ToString() + "'");

            //if (objPic == DBNull.Value)
            //    picImage.Image = null;
            //else
            //    picImage.Image = new Bitmap(Image.FromStream(new MemoryStream((Byte[])objPic)), picImage.Size);
        }

        void bdsLichSu_TT_PositionChanged(object sender, EventArgs e)
        {
            if (bdsLichSu_TT.Position < 0)
                return;
            drLichSu_TT = ((DataRowView)bdsLichSu_TT.Current).Row;

            bdsLichSu_VT.Filter = "Stt_Org = '" + (string)drLichSu_TT["Stt"] + "'";
        }

        void bdsLichSu_DK_PositionChanged(object sender, EventArgs e)
        {
            if (bdsLichSu_DK.Position < 0)
                return;
            drLichSu_DK = ((DataRowView)bdsLichSu_TT.Current).Row;

            bdsLichSu_VT.Filter = "Stt_Org = '" + (string)drLichSu_DK["Stt"] + "'";
        }
        void bdsLichSu_PositionChanged(object sender, EventArgs e)
        {
            if (bdsLichSu.Position < 0)
                return;
            drLichSu = ((DataRowView)bdsLichSu.Current).Row;

            bdsLichSu_TT.Filter = "Ma_Tb = '" + (string)drLichSu["Ma_Tb"] + "'";
            bdsLichSu_DK.Filter = "Ma_Tb = '" + (string)drLichSu["Ma_Tb"] + "'";
        }

        void bdsDmNhVtTb_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDmNhVtTb.Position < 0)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            //drChuKyBT = ((DataRowView)bdsChuKyBT.Current).Row;
            //drCongViecBT = ((DataRowView)bdsCongViecBT.Current).Row;

            //if ((bool)drDmNhVtTb["Nh_Cuoi"] == false)
            //{
            bdsDmCtVtTb.Filter = "Ma_Nh_Tb_Parent = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            bdsLichSu.Filter = "Ma_Nh_Tb_Parent = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            //}
            //else
            //{
            //    bdsDmCtVtTb.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            //    //bdsLichSu.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            //}
            bdsTanSoNhTb.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            bdsMoTaChung.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            bdsBbNhTb.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";

          
            //tabDmVtTb.SelectedTab = tabDmVtTb;
            this.FilterDetail();
            this.FilterDetailCT();
            this.FilterDetailBT();
        }

        public override void Load()
        {
            this.Build();
            this.FillData();
            this.Show();
			this.tabChange();
            BindingData();
            tlDmNhVtTb.Focus();
        }
        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }
        private void Build()
        {
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
            //Nhóm thiết bị
            tlDmNhVtTb.KeyFieldName = "MA_NH_TB";
            tlDmNhVtTb.ParentFieldName = "MA_NH_TB_PARENT";
            tlDmNhVtTb.Dock = DockStyle.Fill;
            tlDmNhVtTb.strZone = "DMNHTB";
            tlDmNhVtTb.BuildTreeList(this.isLookup);
            this.tabDmNhVtTb.Controls.Add(tlDmNhVtTb);

            tlDmCtVtTb.KeyFieldName = "MA_TB";
            tlDmCtVtTb.ParentFieldName = "MA_NH_TB";
            tlDmCtVtTb.Dock = DockStyle.Fill;
            tlDmCtVtTb.strZone = "DMCTVTTB";
            tlDmCtVtTb.BuildTreeList(this.isLookup);
            this.pageDmCtVtTb.Controls.Add(tlDmCtVtTb);

            //Cấu trúc thiết bị

            dgvMoTaChung.Dock = DockStyle.Fill;
            dgvMoTaChung.strZone = "DMTBMOTA";
            dgvMoTaChung.BuildGridView(this.isLookup);
            this.pageMoTaChung.Controls.Add(dgvMoTaChung);

            dgvPTKT.Dock = DockStyle.Fill;
            dgvPTKT.strZone = "DMVTTB";
            dgvPTKT.BuildGridView(this.isLookup);
            this.pagePTKT.Controls.Add(dgvPTKT);

            dgvPTDP.Dock = DockStyle.Fill;
            dgvPTDP.strZone = "DMVTTB";
            dgvPTDP.BuildGridView(this.isLookup);
            this.pagePTDP.Controls.Add(dgvPTDP);

            dgvTanSoNhTb.Dock = DockStyle.Fill;
            dgvTanSoNhTb.strZone = "TANSONHBT";
            dgvTanSoNhTb.BuildGridView(this.isLookup);
            this.pageTanSoNhTb.Controls.Add(dgvTanSoNhTb);

            dgvBbNhTb.Dock = DockStyle.Fill;
            dgvBbNhTb.strZone = "BBNHTB";
            dgvBbNhTb.BuildGridView(this.isLookup);
            this.pageUpdateLL.Controls.Add(dgvBbNhTb);
            //
            dgvTanSoTb.Dock = DockStyle.Fill;
            dgvTanSoTb.strZone = "TANSOBT";
            dgvTanSoTb.BuildGridView(this.isLookup);
            this.pageTanSoTb.Controls.Add(dgvTanSoTb);

            dgvCongViecCT.Dock = DockStyle.Fill;
            dgvCongViecCT.strZone = "CONGVIECBT";
            dgvCongViecCT.BuildGridView(this.isLookup);
            this.pageCongViec.Controls.Add(dgvCongViecCT);
           

            dgvCongViecBT.bSortMode = false;
            dgvCongViecBT.Dock = DockStyle.Fill;
            dgvCongViecBT.strZone = "CONGVIECBT";
            dgvCongViecBT.BuildGridView();
            this.pageCongViecBT.Controls.Add(dgvCongViecBT);

            dgvPhuTungBT.Dock = DockStyle.Fill;
            dgvPhuTungBT.strZone = "PHUTUNGBT";
            dgvPhuTungBT.BuildGridView();
            this.pagePhuTungBT.Controls.Add(dgvPhuTungBT);

            //Lịch sử
            tlLichSu.KeyFieldName = "MA_TB";
            tlLichSu.ParentFieldName = "MA_NH_TB";
            tlLichSu.Dock = DockStyle.Fill;
            tlLichSu.strZone = "DMCTVTTB";
            tlLichSu.BuildTreeList(this.isLookup);
            this.pageLichSu.Controls.Add(tlLichSu);

            dgvLichSu_DK.Dock = DockStyle.Fill;
            dgvLichSu_DK.strZone = "HISTORY_DK";
            dgvLichSu_DK.BuildGridView();
            this.pageLichSu_DK.Controls.Add(dgvLichSu_DK);

            dgvLichSu_TT.Dock = DockStyle.Fill;
            dgvLichSu_TT.strZone = "HISTORY_TT";
            dgvLichSu_TT.BuildGridView();
            this.pageLichSu_TT.Controls.Add(dgvLichSu_TT);

            dgvLichSu_VT.Dock = DockStyle.Fill;
            dgvLichSu_VT.strZone = "HISTORY_VT";
            dgvLichSu_VT.BuildGridView();
            this.pageLichSu_VT.Controls.Add(dgvLichSu_VT);

        }

        private void FillData()
        {
            dsMachinery.Clear();
            dsMachinery = SQLExec.ExecuteReturnDs("sp_GetVoucher_Machinery", CommandType.StoredProcedure);

            //Nhóm vật tư thiết bị
            dtDmNhVtTb = dsMachinery.Tables[0];
            bdsDmNhVtTb.DataSource = dtDmNhVtTb;
            tlDmNhVtTb.DataSource = bdsDmNhVtTb;

            //Mô tả thiết bị
            dtMoTaChung = dsMachinery.Tables[1];
            bdsMoTaChung.DataSource = dtMoTaChung;
            dgvMoTaChung.DataSource = bdsMoTaChung;
            ////Kế hoạch bảo trì
            dtTanSoNhTb = dsMachinery.Tables[2];
            bdsTanSoNhTb.DataSource = dtTanSoNhTb;
            dgvTanSoNhTb.DataSource = bdsTanSoNhTb;

            ////cập nhật lý lịch
            dtBbNhTb = dsMachinery.Tables[3];
            bdsBbNhTb.DataSource = dtBbNhTb;
            dgvBbNhTb.DataSource = bdsBbNhTb;

            tlDmNhVtTb.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmNhVtTb.strZone + "'");

            //cấu trúc vật tư thiết bị
         
            dsDmCtVtTb = SQLExec.ExecuteReturnDs("sp_GetVoucher_MachineryCT", CommandType.StoredProcedure);

            dtDmCtVtTb = dsDmCtVtTb.Tables[0];
            bdsDmCtVtTb.DataSource = dtDmCtVtTb;
            tlDmCtVtTb.DataSource = bdsDmCtVtTb;

            ////Phụ tùng kèm theo
            dtPTKT = dsDmCtVtTb.Tables[1];
            bdsPTKT.DataSource = dtPTKT;
            dgvPTKT.DataSource = bdsPTKT;

            ////Phụ tùng dự phòng chính yếu
            dtPTDP = dsDmCtVtTb.Tables[2];
            bdsPTDP.DataSource = dtPTDP;
            dgvPTDP.DataSource = bdsPTDP;
           
            ////Công việc
            dtCongViecCT = dsDmCtVtTb.Tables[3];
            bdsCongViecCT.DataSource = dtCongViecCT;
            dgvCongViecCT.DataSource = bdsCongViecCT;

            ////Tần số thiết bị
            dtTanSoTb = dsDmCtVtTb.Tables[4];
            bdsTanSoTb.DataSource = dtTanSoTb;
            dgvTanSoTb.DataSource = bdsTanSoTb;



            //Bảo trì định kỳ vật tư thiết bị
            dsDmBtVtTb = SQLExec.ExecuteReturnDs("sp_GetVoucher_MachineryBT", CommandType.StoredProcedure);
           

            //Chu kỳ BTTB định kỳ
            dtCongViecBT = dsDmBtVtTb.Tables[0];
            bdsCongViecBT.DataSource = dtCongViecBT;
            dgvCongViecBT.DataSource = bdsCongViecBT;

            //Chu kỳ BTTB định kỳ
            dtPhuTungBT = dsDmBtVtTb.Tables[1];
            bdsPhuTungBT.DataSource = dtPhuTungBT;
            dgvPhuTungBT.DataSource = bdsPhuTungBT;

           //Lịch sử
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            dsLichSu = SQLExec.ExecuteReturnDs("sp_GetVoucher_MachineryLS", ht, CommandType.StoredProcedure);
            dtLichSu = dsLichSu.Tables[0];
            bdsLichSu.DataSource = dtLichSu;
            tlLichSu.DataSource = bdsLichSu;

            //Lịch sử BTTB định kỳ
            dtLichSu_DK = dsLichSu.Tables[1];
            bdsLichSu_DK.DataSource = dtLichSu_DK;
            dgvLichSu_DK.DataSource = bdsLichSu_DK;

            //Lịch sử BTTB tập trung
            dtLichSu_TT = dsLichSu.Tables[2];
            bdsLichSu_TT.DataSource = dtLichSu_TT;
            dgvLichSu_TT.DataSource = bdsLichSu_TT;

            //Lịch sử vật tư
            dtLichSu_VT = dsLichSu.Tables[3];
            bdsLichSu_VT.DataSource = dtLichSu_VT;
            dgvLichSu_VT.DataSource = bdsLichSu_VT;

            bdsSearch = bdsDmNhVtTb;
            ExportControl = tlDmNhVtTb;
        }
        private void BindingData()
        {
            //Phần nhóm thiết bị
            foreach (Control ctrl in tbThongTinTb.Controls)
            {
                if (ctrl.GetType() == typeof(rsTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(rsDateTime) || ctrl.GetType() == typeof(rsComboBox) || ctrl.GetType() == typeof(ComboBox))
                {
                    string strFieldName = ctrl.Name.Substring(3);

                    if (((DataTable)bdsDmNhVtTb.DataSource).Columns.Contains(strFieldName))
                        ctrl.DataBindings.Add("Text", bdsDmNhVtTb, strFieldName);
                }
            }

            //phần chi tiết thiết bị
            foreach (Control ctrl in tbCauTrucTb.Controls)
            {
                if (ctrl.GetType() == typeof(rsTextBox) || ctrl.GetType() == typeof(TextBox) || ctrl.GetType() == typeof(rsDateTime) || ctrl.GetType() == typeof(rsComboBox) || ctrl.GetType() == typeof(ComboBox))
                {
                    string strFieldName = ctrl.Name.Substring(3);

                    if (((DataTable)bdsDmCtVtTb.DataSource).Columns.Contains(strFieldName))
                        ctrl.DataBindings.Add("Text", bdsDmCtVtTb, strFieldName);
                }
            }
           
        }
        void Machinery_Edit(enuEdit enuNew_Edit)
        {
            if (bdsDmNhVtTb.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy dòng hiện tại
            if (bdsDmNhVtTb.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDmNhVtTb.Current).Row, ref drDmNhVtTb);
            else
                drDmNhVtTb = dtDmNhVtTb.NewRow();

            //if (enuNew_Edit == enuEdit.New)
            //    drDmNhVtTb["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];

            frmMachinery_Edit frmEdit = new frmMachinery_Edit();
            frmEdit.Load(enuNew_Edit, drDmNhVtTb);

            //Khi người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDmNhVtTb.Position >= 0)
                        dtDmNhVtTb.ImportRow(drDmNhVtTb);
                    else
                        dtDmNhVtTb.Rows.Add(drDmNhVtTb);

                    bdsDmNhVtTb.Position = bdsDmNhVtTb.Find("Ma_Nh_Tb", drDmNhVtTb["Ma_Nh_Tb"]);
                }
                else
                    Common.CopyDataRow(drDmNhVtTb, ((DataRowView)bdsDmNhVtTb.Current).Row);

              
                
                dtDmNhVtTb.AcceptChanges();
            }
            else
                dtDmNhVtTb.RejectChanges();
        }

        void Machinery_Delete()
        {
            if (bdsDmNhVtTb.Position < 0)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06DmNhTb", drDmNhVtTb))
            {
                bdsDmNhVtTb.RemoveAt(bdsDmNhVtTb.Position);
                dtDmNhVtTb.AcceptChanges();
            }
        }


        void DmCtVtTb_Edit(enuEdit enuNew_Edit)
        {
            if (bdsDmCtVtTb.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy dòng hiện tại
            if (bdsDmCtVtTb.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDmCtVtTb.Current).Row, ref drDmCtVtTb);
            else
                drDmCtVtTb = dtDmCtVtTb.NewRow();

            //if (enuNew_Edit == enuEdit.New)
            //    drDmNhVtTb["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];

            frmMachineryCT_Edit frmEdit = new frmMachineryCT_Edit();
            frmEdit.Load(enuNew_Edit, drDmCtVtTb);

            //Khi người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                drDmCtVtTb["Ma_Nh_Tb"] = drDmCtVtTb["Ma_Nh_Tb"].ToString()+ drDmCtVtTb["Loai_Tb"].ToString();
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDmCtVtTb.Position >= 0)
                        dtDmCtVtTb.ImportRow(drDmCtVtTb);
                    else
                        dtDmCtVtTb.Rows.Add(drDmCtVtTb);

                    bdsDmCtVtTb.Position = bdsDmCtVtTb.Find("Ma_Tb", drDmCtVtTb["Ma_Tb"]);
                }
                else
                    Common.CopyDataRow(drDmCtVtTb, ((DataRowView)bdsDmCtVtTb.Current).Row);



                dtDmCtVtTb.AcceptChanges();
            }
            else
                dtDmCtVtTb.RejectChanges();
        }

        void DmCtVtTb_Delete()
        {
            if (bdsDmCtVtTb.Position < 0)
                return;

            drDmCtVtTb = ((DataRowView)bdsDmCtVtTb.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06DmTb", drDmCtVtTb))
            {
                bdsDmCtVtTb.RemoveAt(bdsDmCtVtTb.Position);
                dtDmCtVtTb.AcceptChanges();
            }
        }
        private bool print(bool bPreview)
        {
            string strReportFile = string.Empty;

            if (bdsDmNhVtTb.Position < 0)
                return false;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;

            if (!dtDmNhVtTb.Columns.Contains("NGAY_CT"))
                dtDmNhVtTb.Columns.Add("NGAY_CT", typeof(DateTime));

            if (!dtDmNhVtTb.Columns.Contains("REPORT_FILE"))
                dtDmNhVtTb.Columns.Add("REPORT_FILE", typeof(string));

            frmIn_LyLichTB frm = new frmIn_LyLichTB();
            frm.Load(drDmNhVtTb);

            if (frm.isAccept)
            {
                if(frm.rdbLyLich1.Checked)
                    strReportFile = "rptLyLichTb1";
                else if (frm.rdbLyLich2.Checked)
                    strReportFile = "rptLyLichTb2";
                else
                    strReportFile = "rptLyLichTb3";
            }
            drDmNhVtTb["REPORT_FILE"] = strReportFile ;
            drDmNhVtTb["NGAY_CT"] = Element.sysNgay_Ct2;

            Hashtable ht = new Hashtable();
            ht.Add("MA_NH_TB", drDmNhVtTb["Ma_Nh_Tb"].ToString());

            DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintLyLichMMTB", ht, CommandType.StoredProcedure);
            DataTable dtHeader = ds.Tables[0];
            DataTable dtDetail = new DataTable();
            
            if (frm.rdbLyLich1.Checked ||  frm.rdbLyLich2.Checked)
                dtDetail = ds.Tables[1];
           else
                dtDetail = ds.Tables[2];

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drDmNhVtTb, dtDetail, bPreview, true);
           
           
        }

        private bool printDetail_Tb(bool bPreview)
        {
            if (bdsDmNhVtTb.Position < 0)
                return false;

            //if (bdsDmVtTb.Position < 0)
            //    return false;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            //drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

            DataTable dtHeader = new DataTable();
            DataTable dtDetail = new DataTable();

            //Load form chọn in

            frmIn_ListTB frm = new frmIn_ListTB();
            frm.Load(drDmNhVtTb, false);

            if (frm.isAccept)
            {
                string strLoai_BTTB = "";

                if (frm.rdbPlan_BTTB_NB.Checked == true)
                    strLoai_BTTB = "NB";
                else
                    strLoai_BTTB = "BN";

                Hashtable ht = new Hashtable();
                //ht.Add("MA_NH_TB", drDmNhVtTb["Ma_Nh_Tb"].ToString());
                ht.Add("MA_NH_TB",frm.txtMa_Nh_Tb.Text);
                ht.Add("LOAI_BTTB", strLoai_BTTB);
                ht.Add("NAM", Element.sysWorkingYear);
                ht.Add("MA_DVCS", Element.sysMa_DvCs);

                DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintLichBTTB", ht, CommandType.StoredProcedure);
                dtHeader = ds.Tables[0];
                dtDetail = ds.Tables[1];

                if (strLoai_BTTB == "BN")
                    strReportFile = "rptPlan_BTTB_BN";
                else
                    strReportFile = "rptPlan_BTTB_NB";

                if (!dtDmNhVtTb.Columns.Contains("REPORT_FILE"))
                    dtDmNhVtTb.Columns.Add("REPORT_FILE", typeof(string));

                if (!dtDmNhVtTb.Columns.Contains("NGAY_CT"))
                    dtDmNhVtTb.Columns.Add("NGAY_CT", typeof(DateTime));

                drDmNhVtTb["REPORT_FILE"] = strReportFile;
                drDmNhVtTb["NGAY_CT"] = Element.sysNgay_Ct2;
                RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                return frmPrint.Load(drDmNhVtTb, dtDetail, bPreview, true);

            }
            else
                return false;
        }

        private void Design()
        {
            frmIn_ListTB frm = new frmIn_ListTB();
            frm.Load(drDmNhVtTb, true);
                
            //string strLoai_BTTB = "ALL";
            if (frm.isAccept)
            {
                if (frm.rdbPlan_BTTB_NB.Checked == true)
                    strReportFile = "rptPlan_BTTB_NB";
                else if (frm.rdbPlan_BTTB_BN.Checked == true)
                    strReportFile = "rptPlan_BTTB_BN";
                else if (frm.rdbLyLich1.Checked == true)
                    strReportFile = "rptLyLichTb1";
                else if (frm.rdbLyLich2.Checked == true)
                    strReportFile = "rptLyLichTb2";
                else if (frm.rdbLyLich3.Checked == true)
                    strReportFile = "rptLyLichTb3";
            }
            else
                return;

            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
        }

        private bool SaveResource(string strFile_Name, object objFile_Content)
        {
            string str;
            System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
            hashtable.Add("FILE_NAME", strFile_Name);
            hashtable.Add("FILE_CONTENT", (objFile_Content == null) ? ((object)new byte[0]) : ((object)((byte[])objFile_Content)));
            if (DataTool.SQLCheckExist("R06Resource", new string[] { "File_Name" }, new object[] { strFile_Name }))
            {
                str = "UPDATE R06Resource SET File_Content = @File_Content WHERE File_Name = @File_Name";
            }
            else
            {
                str = "INSERT INTO R06Resource (File_Name, File_Content) VALUES (@File_Name, @File_Content)";
            }
            return SQLExec.Execute(str, hashtable, CommandType.Text);
        }

        private object LoadResource(string strFile_Name)
        {
            if (strFile_Name != null)
            {
                System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
                hashtable.Add("FILE_NAME", strFile_Name);
                object obj2 = SQLExec.ExecuteReturnValue("SELECT File_Content FROM R06Resource WHERE File_Name = @File_Name", hashtable, CommandType.Text);
                if (((obj2 != null) && (obj2 != System.DBNull.Value)) && (((byte[])obj2).Length > 0))
                {
                    return obj2;
                }
            }
            return null;
        }

		private void LoadPicture()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();

			fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			fileDialog.Filter = fileDialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*"; ;

			if (fileDialog.ShowDialog() != DialogResult.OK)
				return;

			FileInfo fiImage = new FileInfo(fileDialog.FileName);
			FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            //picImage.Image = new Bitmap(Image.FromStream(fs), picImage.Size);
            //picImage.SizeMode = PictureBoxSizeMode.Zoom;

            //SavePicture();
		}

        //private void SavePicture()
        //{
        //    if (bdsDmVtTb.Position < 0)
        //        return;

        //    drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

        //    Hashtable ht = new Hashtable();
        //    ht.Add("MA_VT", (string)drDmVtTb["Ma_Vt"]);

        //    //if (picImage.Image != null)
        //    //{
        //    //    byte[] barrImg = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(picImage.Image).ConvertTo(picImage.Image, typeof(byte[]));
        //    //    ht["HINH"] = barrImg;
        //    //    SQLExec.Execute("UPDATE R81DmVt SET Hinh = @Hinh WHERE Ma_Vt = @Ma_Vt", ht, CommandType.Text);
        //    //}
        //    //else
        //    //{
        //    //    ht["HINH"] = new byte[] { };
        //    //    SQLExec.Execute("UPDATE R81DmVt SET Hinh = Null WHERE Ma_Vt = = @Ma_Vt", ht, CommandType.Text);
        //    //}

        //    loadImage();
        //}

    }
}
