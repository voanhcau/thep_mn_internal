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
    public partial class frmQuerySuatAn : RosySystem.Customize.frmView
	{
		#region Variable

		//Luu y toi bManual
        object objActive = null;

		DataSet dsVoucher = new DataSet();
		DataTable dtEditPh;
       
		DataTable dtEditCt;
        DataTable dtEditCt_ThucDon;
        DataTable dtEditCt_ThucDonNV;
        


        DataRow drEditPh;
		DataRow drEditCt;
       
      
      
    


		BindingSource bdsEditPh = new BindingSource();
		BindingSource bdsEditCt = new BindingSource();
        BindingSource bdsEditCt_ThucDon = new BindingSource();
        BindingSource bdsEditCt_ThucDonNV = new BindingSource();
        BindingSource bdsEditCt_ThucPham = new BindingSource();

		DataRow drCurrent;
		public enuEdit enuNew_Edit_Voucher = enuEdit.New;
        string strMa_Dt_CbNv_Bv = string.Empty;
        string strStt = string.Empty;
        string strStt_New = string.Empty;
       
		#endregion

        public frmQuerySuatAn()
		{
			InitializeComponent();

            this.KeyDown += new KeyEventHandler(KeyDownEvent);
            dgvNTVL.Enter += new EventHandler(dgvNhanVienCa_Enter);
            dgvNTTX.Enter += new EventHandler(dgvNhanVienCty_Enter);
          

         
            this.btRefresh.Click += new EventHandler(btRefresh_Click);           
            btExit.Click += new EventHandler(btExit_Click);
            btDelete.Click+=new EventHandler(btDelete_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
            btNew.Click+=new EventHandler(btNew_Click);
            btEdit.Click+=new EventHandler(btEdit_Click);
            btDelete.Click+=new EventHandler(btDelete_Click);
            btSuatAn.Click += new EventHandler(btSuatAn_Click);
            //btTinh.Click += new EventHandler(btTinh_Click);
		}

       

        

       

       

        

       
        new public void Load()
		{
            DateTime dteNgay_Ct2 = DateTime.Now;
            DateTime dteNgay_Ct1 = dteNgay_Ct2.AddDays((-15) + 1);

            this.dteNgay_Ct1.Text = Library.DateToStr(dteNgay_Ct1);
            this.dteNgay_Ct2.Text = Library.DateToStr(dteNgay_Ct2);
           

            this.Build();
            this.FillData();
            this.Init_Ct();
            LoadDicName();
           
			this.Show();
		}

        private void LoadDicName()
        {
       
        }
		private void Build()
		{
            
            dgvNTVL.bSortMode = false;
            dgvNTVL.strZone = "NTVL";
            dgvNTVL.BuildGridView();


            dgvNTTX.bSortMode = false;
            dgvNTTX.strZone = "NTTX";
            dgvNTTX.BuildGridView();

            

            this.DataGridView_Language();

            foreach (DataGridViewColumn dgvc in dgvNTVL.Columns)
                dgvc.ReadOnly = true;


            foreach (DataGridViewColumn dgvc in dgvNTTX.Columns)
                dgvc.ReadOnly = true;


         
           

           
		}

		private void DataGridView_Language()
		{
           
			
		}

		private void Init_Ct()
		{
          

            
        
		}
        
       
	    private void FillData()
		{
            Hashtable ht = new Hashtable();

            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
           
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetSuatAnNT", ht, CommandType.StoredProcedure);

            dtEditCt_ThucDon = dsVoucher.Tables[0];
            bdsEditCt_ThucDon.DataSource = dtEditCt_ThucDon;
            dgvNTVL.DataSource = bdsEditCt_ThucDon;

            dtEditCt_ThucDonNV = dsVoucher.Tables[1];
            bdsEditCt_ThucDonNV.DataSource = dtEditCt_ThucDonNV;
            dgvNTTX.DataSource = bdsEditCt_ThucDonNV;

         

           
		}

     
        void dgvNhanVienCa_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvNTVL;
        }
        void dgvNhanVienCty_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
            objActive = dgvNTTX;
        }
       
        private void Save()
        {

        }
          
        
       
       
     
       
        public override void Edit(enuEdit enuNew_Edit)
        {
            //Copy hang hien tai
            if (bdsEditCt_ThucDon.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_ThucDon.Current).Row, ref drCurrent);
            else
            {
                drCurrent = dtEditCt_ThucDon.NewRow();
              
            }
            frmThucDon_Edit frm = new frmThucDon_Edit();
            frm.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frm.isAccept)
            {

                if (drCurrent["Loai"].ToString() == "S")
                    drCurrent["Buoi"] = "Sáng";
                else if (drCurrent["Loai"].ToString() == "T")
                    drCurrent["Buoi"] = "Trưa";
                else if (drCurrent["Loai"].ToString() == "C")
                    drCurrent["Buoi"] = "Chiều";
                else
                    drCurrent["Buoi"] = "Khuya";

                if (enuNew_Edit == enuEdit.New)
                    if (bdsEditCt_ThucDon.Position >= 0)
                        dtEditCt_ThucDon.ImportRow(drCurrent);
                    else
                        dtEditCt_ThucDon.Rows.Add(drCurrent);
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_ThucDon.Current).Row);
                }


                bdsEditCt_ThucDon.Position = bdsEditCt_ThucDon.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_ThucDon.AcceptChanges();
            }
            else
                dtEditCt_ThucDon.RejectChanges();
          
        }
        public override void Delete()
        {
            this.Delete_ThucDon();
          

        }
        private void Delete_ThucDon()
        {
            if (bdsEditCt_ThucDon.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEditCt_ThucDon.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09THUCDON", drCurrent))
            {
                bdsEditCt_ThucDon.RemoveAt(bdsEditCt_ThucDon.Position);
                dtEditCt_ThucDon.AcceptChanges();
            }
        }
        void btNew_Click(object sender, EventArgs e)
        {
            this.enuNew_Edit_Voucher = enuEdit.New;
            Edit(enuNew_Edit_Voucher);
           
        }
        void btEdit_Click(object sender, EventArgs e)
        {
            this.enuNew_Edit_Voucher = enuEdit.Edit;
            Edit(enuNew_Edit_Voucher);
        }
       
        void btDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        void btPrint_Click(object sender, EventArgs e)
        {
            //frmInThucDon frm = new frmInThucDon();
            //frm.Load();
         
        }
     
        void btSuatAn_Click(object sender, EventArgs e)
        {
            //Copy hang hien tai
            if (bdsEditCt_ThucDon.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEditCt_ThucDon.Current).Row, ref drCurrent);
            else
            {
                drCurrent = dtEditCt_ThucDon.NewRow();

            }
            frmSuatAn_Edit frm = new frmSuatAn_Edit();
            frm.Load(enuEdit.Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frm.isAccept)
            {
               Common.CopyDataRow(drCurrent, ((DataRowView)bdsEditCt_ThucDon.Current).Row);
                
                bdsEditCt_ThucDon.Position = bdsEditCt_ThucDon.Find("IDENT00", drCurrent["IDENT00"]);
                dtEditCt_ThucDon.AcceptChanges();
            }
            else
                dtEditCt_ThucDon.RejectChanges();
        }
        //private void Print(string strStt, double iIdent00, bool bCan)
        //{
        //    //cập nhật Stt_Can
        //    if (bCan)
        //    {
        //        SQLExec.Execute("UPDATE R09CT_RVC SET Stt_Can = 'LC' + REPLACE(STR( "+ iIdent00 +",10),' ','0') WHERE Ident00 = " + iIdent00 + "");
        //    }
        //    Hashtable ht = new Hashtable();
        //    ht.Add("STT", strStt);
        //    ht.Add("IDENT00", iIdent00);

        //    DataTable dtLenhCan = SQLExec.ExecuteReturnDt("sp_PrintLenhCan", ht, CommandType.StoredProcedure);

        //    dtLenhCan.Columns.Add("REPORT_FILE", typeof(string));
        //    dtLenhCan.Columns.Add("NGAY_CT", typeof(DateTime));

        //    dtLenhCan.Rows[0]["Report_File"] = "rptLenh_Can";
        //    dtLenhCan.Rows[0]["Ngay_Ct"] = DateTime.Now;

        //    RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
        //    frmPrint.Load(dtLenhCan.Rows[0], dtLenhCan, true, true);
        //}
        private void Design()
        {
            string strReportFile = "rptSuatAnNTVL";
            RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
            frm.Load(strReportFile);
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

		void btRefresh_Click(object sender, EventArgs e)
		{
            FillData();
		}

		
	

		void dgvEditCt_KeyDown(object sender, KeyEventArgs e)
		{
            //switch (e.KeyCode)
            //{
            //    case Keys.F8:

            //        if (dgvEditCt.Focused == false)
            //            return;

            //        if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            //            return;

            //        drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            //        drCurrent["Deleted"] = !((bool)drCurrent["Deleted"]);

            //        if ((bool)drCurrent["Deleted"] == true)
            //        {
            //            Font font = new Font(dgvEditCt.Font.FontFamily, dgvEditCt.Font.Size, FontStyle.Strikeout);
            //            dgvEditCt.CurrentRow.DefaultCellStyle.Font = font;
            //        }
            //        else
            //        {
            //            dgvEditCt.CurrentRow.DefaultCellStyle.Font = dgvEditCt.Font;
            //        }
            //        break;
            //}
		}
        void dgvEditCt_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            drCurrent = ((DataRowView)bdsEditCt.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

         
        }
       
	
		#endregion

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
				return;

			switch (e.KeyCode)
			{
				case Keys.F9:
					this.btRefresh_Click(null, null);
					return;

               
				case Keys.F12:
					if (e.Modifiers == Keys.Control)
						base.OnKeyDown(e);
				
					return;

			    
			}

			base.OnKeyDown(e);
		}
        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        void KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Shift:
                            this.Design();
                            break;
                    }
                    break;
            }
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
