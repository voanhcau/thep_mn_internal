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
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Library;
using RosySystem.Element;
using RosyList;


namespace RosyModule.Payable
{
	public partial class frmVTPTTD : RosySystem.Customize.frmView
	{
		#region Khai bao bien

        //string strReportFile = "rptCT_DNTU";
		DataTable dtEmployee;
		

		BindingSource bdsEmployee = new BindingSource();

       
		private DataRow drCurrent;
        private rsDataGridView dgvDnTu = new rsDataGridView();
		#endregion

		#region Contructor

        public frmVTPTTD()
		{
			InitializeComponent();

            btNew.Click+=new EventHandler(btNew_Click);
			btEdit.Click+=new EventHandler(btEdit_Click);
			btDelete.Click+=new EventHandler(btDelete_Click);
            //btPrint.Click += new EventHandler(btPrint_Click);

            this.KeyDown += new KeyEventHandler(KeyDownEvent);
            //dgvDnTu.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvDnTu_CellMouseClick);
            
		}

       

       
		public override void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();

		
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			
			dgvDnTu.strZone = "VTPTTD";
			dgvDnTu.Dock = DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Add(dgvDnTu);
            this.dgvDnTu.BuildGridView();			
		}

		private void FillData()
		{
            dtEmployee = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMVTTD");
            //dtEmployee = SQLExec.ExecuteReturnDt("Sp_GetDnTu",CommandType.StoredProcedure);

			bdsEmployee.DataSource = dtEmployee;
			dgvDnTu.DataSource = bdsEmployee;
            bdsEmployee.Position = dtEmployee.Rows.Count;

					

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsEmployee;
			ExportControl = dgvDnTu;

			
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
            if (bdsEmployee.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsEmployee.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEmployee.Current).Row, ref drCurrent);
            else
                drCurrent = dtEmployee.NewRow();

            //drCurrent["Stt_Org"] = "";
            //drCurrent["So_Ct_Org"] = "";

            frmVTPTTD_Edit frmEdit = new frmVTPTTD_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsEmployee.Position >= 0)
                        dtEmployee.ImportRow(drCurrent);
                    else
                        dtEmployee.Rows.Add(drCurrent);


                    bdsEmployee.Position = bdsEmployee.Find("MA_VT_TD", drCurrent["Ma_Vt_Td"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEmployee.Current).Row);

                dtEmployee.AcceptChanges();
            }
		}

		public override void Delete()
		{
            if (bdsEmployee.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsEmployee.Current).Row;

            if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                Common.MsgOk("Bạn không có quyền xóa!!!");
            }
            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R81DMVTTD", drCurrent))
            {
                bdsEmployee.RemoveAt(bdsEmployee.Position);
                dtEmployee.AcceptChanges();
            }
		}

		#endregion

		#region Print
        

        //private void Design()
        //{
        //    RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
        //    frm.Load(strReportFile);
        //}
		#endregion

		#region Su kien
        //void dgvDnTu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    string strColumnName = dgvDnTu.Columns[e.ColumnIndex].Name;
        //    if (strColumnName == "IS_KT_NHAN")
        //    {
        //        drCurrent = ((DataRowView)bdsEmployee.Current).Row;
        //        bool bNhan_Ct = false;
        //        bNhan_Ct = Common.CheckPermission("NHAN_CT_DNTT", enuPermission_Type.Allow_Access);
        //        bool bIs_Vt_Nhan = !Convert.ToBoolean(drCurrent["Is_Kt_Nhan"]);

        //        Hashtable ht = new Hashtable();
        //        ht.Add("IS_KT_NHAN", bIs_Vt_Nhan);
        //        ht.Add("USER_KT_NHAN", Common.GetCurrent_Log());
        //        ht.Add("STT", drCurrent["Stt"]);

        //        string strSql = "UPDATE R04CTDNTU SET Is_Kt_Nhan = @Is_Kt_Nhan, User_Kt_Nhan = @User_Kt_Nhan WHERE Stt = @Stt";

        //        if (SQLExec.Execute(strSql, ht, CommandType.Text))
        //        {
        //            drCurrent["Is_Kt_Nhan"] = bIs_Vt_Nhan;
        //            drCurrent["User_Kt_Nhan"] = Common.GetCurrent_Log();
        //        }
        //    }
        //}
        void btDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.Edit);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.New);
        }
        public override void EnterProcess()
        {
            if (bdsEmployee.Position < 0)
                return;
            drCurrent = ((DataRowView)bdsEmployee.Current).Row;


            frmVTPTTD_Enter frm = new frmVTPTTD_Enter();

            frm.MdiParent = this.MdiParent;
            frm.Load((string)drCurrent["Ma_Vt_Td"]);

            bdsEmployee.Position = bdsEmployee.Find("MA_VT_TD", drCurrent["MA_VT_TD"]);
            
        }
        //void btPrint_Click(object sender, EventArgs e)



        //{
        //    drCurrent = ((DataRowView)bdsEmployee.Current).Row;
        //    Voucher.Print_DnTu(drCurrent["Stt"].ToString(), true, strReportFile);
        //}
		#endregion

        void KeyDownEvent(object sender, KeyEventArgs e)
        {           
            switch (e.KeyCode)
            {
                //case Keys.F7:
                //    switch (e.Modifiers)
                //    {
                //        case Keys.Control:
                //            {
                //                drCurrent = ((DataRowView)bdsEmployee.Current).Row;
                //                Voucher.Print_DnTu(drCurrent["Stt"].ToString(), true, strReportFile);
                //            }
                //            break;
                //        case Keys.Shift:
                //            this.Design();
                //            break;
                //    }
                //    break;
                case Keys.F2:
                    {
                        this.Edit(enuEdit.New);
                    }
                    break;
                case Keys.F3:
                    {
                        this.Edit(enuEdit.Edit);
                    }
                    break;
                case Keys.F8:
                    {
                        this.Delete();
                    }
                    break;
            }
            
        }
	}
}
