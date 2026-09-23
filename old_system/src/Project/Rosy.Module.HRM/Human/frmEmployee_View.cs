using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;
using System.Collections;
using System.Data.SqlClient;


namespace RosyModule.HRM
{
	public partial class frmEmployee_View : RosySystem.Customize.frmView
	{
		#region Declare

        DataTable dtEmployee;
        DataTable dtQHGD;
        DataTable dtQTCT;
        DataTable dtQTDT;
        DataTable dtHDLD;
        DataTable dtQTKTKL;
        DataTable dtNghiPhep;
        DataTable dtTsTn0;

        BindingSource bdsEmployee = new BindingSource();
        BindingSource bdsQHGD = new BindingSource();
        BindingSource bdsQTCT = new BindingSource();
        BindingSource bdsQTDT = new BindingSource();
        BindingSource bdsHDLD = new BindingSource();
        BindingSource bdsQTKTKL = new BindingSource();
        BindingSource bdsNghiPhep = new BindingSource();
        BindingSource bdsTsTn0 = new BindingSource();

        private DataRow drCurrent;
        private string strMa_Dt_CbNv;
        string strKey;
		#endregion

		#region Contructor

        public frmEmployee_View()
		{
			InitializeComponent();

			
			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btThoat.Click += new EventHandler(btThoat_Click);
			

		
			
		}

		#endregion

		#region Method

        public void Load(string strMa_Dt_CbNv)
		{
            this.strMa_Dt_CbNv = strMa_Dt_CbNv;
            
            strKey = "Ma_Dt_CbNv = '"+ strMa_Dt_CbNv +"'";
			
            Build();
			FillData();
			BindingLanguage();
            LoadDicName();
			
			this.ShowDialog();
		}

        private void LoadDicName()
        {
            //txtMa_Bp
            if (txtMa_Bp.Text.Trim() != string.Empty)
            {
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            }
            else
                lbtTen_Bp.Text = string.Empty;

            //txtMa_Bp_Ct
            if (txtMa_Bp_Ct.Text.Trim() != string.Empty)
            {
                lbtTen_Bp_Ct.Text = DataTool.SQLGetNameByCode("R81DMBPCT", "Ma_Bp_Ct", "Ten_Bp_Ct", txtMa_Bp_Ct.Text.Trim());
            }
            else
                lbtTen_Bp_Ct.Text = string.Empty;
        }
		void Build()
		{

            dgvQHGD.strZone = "QHGD";
            dgvQHGD.BuildGridView();

            dgvQTCT.strZone = "QTCT";
            dgvQTCT.BuildGridView();

            dgvQTDT.strZone = "QTDT";
            dgvQTDT.BuildGridView();

            dgvHDLD.strZone = "HDLD";
            dgvHDLD.BuildGridView();

            dgvQTKTKL.strZone = "QTKTKL";
            dgvQTKTKL.BuildGridView();

            dgvNghiPhep.strZone = "NGHIPHEP";
            dgvNghiPhep.BuildGridView();

            dgvTsTn0.strZone = "TSTN0";
            dgvTsTn0.BuildGridView();

			

		}

		void FillData()
		{
            dtEmployee = SQLExec.ExecuteReturnDt("SELECT * FROM R81DMDT WHERE Ma_Dt = '" + strMa_Dt_CbNv + "'");
            DataRow drEdit = dtEmployee.Rows[0];
            Common.ScaterMemvar(this, ref drEdit);

            //QHGD
            dtQHGD = DataTool.SQLGetDataTable("R09QHGD", null, strKey, "Nam_Sinh, Loai_QHGD");
            bdsQHGD.DataSource = dtQHGD;
            dgvQHGD.DataSource = bdsQHGD;

            //QTCT
            dtQTCT = DataTool.SQLGetDataTable("R09QTCT", null, strKey, "Ngay_Bd, Ngay_Kt");
            bdsQTCT.DataSource = dtQTCT;
            dgvQTCT.DataSource = bdsQTCT;

            //QTDT
            dtQTDT = DataTool.SQLGetDataTable("R09QTDT", null, strKey, "Ngay_Bd, Ngay_Kt");
            bdsQTDT.DataSource = dtQTDT;
            dgvQTDT.DataSource = bdsQTDT;

            //HDLD
            dtHDLD = DataTool.SQLGetDataTable("R09HDLD", null, strKey, "Ngay_Bd, Ngay_Kt");
            bdsHDLD.DataSource = dtHDLD;
            dgvHDLD.DataSource = bdsHDLD;

            //QTKTKL
            dtQTKTKL = DataTool.SQLGetDataTable("R09QtKTKL", null, strKey, "Ngay_QD, Ngay_HL");
            bdsQTKTKL.DataSource = dtQTKTKL;
            dgvQTKTKL.DataSource = bdsQTKTKL;

            //NGHIPHEP
            dtNghiPhep = DataTool.SQLGetDataTable("R09NghiPhep", null, strKey, "Ngay_Bd, Ngay_Kt");
            bdsNghiPhep.DataSource = dtNghiPhep;
            dgvNghiPhep.DataSource = bdsNghiPhep;

            //Tham số các khoản thu nhập
            string strSQLExec =
                "SELECT T1.*, T2.Ten_Tn, T2.Dvt FROM R10TsTn0 T1 LEFT JOIN R10DmTn T2 ON T1.Ma_Tn = T2.Ma_Tn " +
                    " ORDER BY Ngay_Ap";

            dtTsTn0 = SQLExec.ExecuteReturnDt(strSQLExec);
            bdsTsTn0.DataSource = dtTsTn0;
            dgvTsTn0.DataSource = bdsTsTn0;

          
        }

		bool FormCheckValid()
		{

			return true;
		}

		void btThoat_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        void EditQHGD(enuEdit enuNew_Edit)
        {
      

            if (bdsQHGD.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            

            //Copy hang hien tai            
            if (bdsQHGD.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQHGD.Current).Row, ref drCurrent);
            else
                drCurrent = dtQHGD.NewRow();

            drCurrent["Ma_Dt_CbNv"] = strMa_Dt_CbNv;
            frmQHGD_Edit frmEdit = new frmQHGD_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQHGD.Position >= 0)
                        dtQHGD.ImportRow(drCurrent);
                    else
                        dtQHGD.Rows.Add(drCurrent);

                    bdsQHGD.Position = bdsQHGD.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQHGD.Current).Row);

                dtQHGD.AcceptChanges();
            }
            else
                dtQHGD.RejectChanges();
        }

        void EditQTCT(enuEdit enuNew_Edit)
        {
            

            if (bdsQTCT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            

            //Copy hang hien tai            
            if (bdsQTCT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQTCT.Current).Row, ref drCurrent);
            else
                drCurrent = dtQTCT.NewRow();

            drCurrent["Ma_Dt_CbNv"] = strMa_Dt_CbNv;
            frmQTCT_Edit frmEdit = new frmQTCT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQTCT.Position >= 0)
                        dtQTCT.ImportRow(drCurrent);
                    else
                        dtQTCT.Rows.Add(drCurrent);

                    bdsQTCT.Position = bdsQTCT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQTCT.Current).Row);

                dtQTCT.AcceptChanges();
            }
            else
                dtQTCT.RejectChanges();
        }

        void EditQTDT(enuEdit enuNew_Edit)
        {
           
            if (bdsQTDT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

           

            //Copy hang hien tai            
            if (bdsQTDT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsQTDT.Current).Row, ref drCurrent);
            else
                drCurrent = dtQTDT.NewRow();

            drCurrent["Ma_Dt_CbNv"] = strMa_Dt_CbNv;
            frmQTDT_Edit frmEdit = new frmQTDT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsQTDT.Position >= 0)
                        dtQTDT.ImportRow(drCurrent);
                    else
                        dtQTDT.Rows.Add(drCurrent);

                    bdsQTDT.Position = bdsQTDT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsQTDT.Current).Row);

                dtQTDT.AcceptChanges();
            }
            else
                dtQTDT.RejectChanges();
        }

        void EditHDLD(enuEdit enuNew_Edit)
        {

            if (bdsHDLD.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsHDLD.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsHDLD.Current).Row, ref drCurrent);
            else
                drCurrent = dtHDLD.NewRow();

            drCurrent["Ma_Dt_CbNv"] = strMa_Dt_CbNv;
            frmHDLD_Edit frmEdit = new frmHDLD_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsHDLD.Position >= 0)
                        dtHDLD.ImportRow(drCurrent);
                    else
                        dtHDLD.Rows.Add(drCurrent);

                    bdsHDLD.Position = bdsHDLD.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsHDLD.Current).Row);

                dtHDLD.AcceptChanges();
            }
            else
                dtHDLD.RejectChanges();
        }

        //void EditQTKTKL(enuEdit enuNew_Edit)
        //{
          
        //    if (bdsQTKTKL.Position < 0 && enuNew_Edit == enuEdit.Edit)
        //        return;           

        //    //Copy hang hien tai            
        //    if (bdsQTKTKL.Position >= 0)
        //        Common.CopyDataRow(((DataRowView)bdsQTKTKL.Current).Row, ref drCurrent);
        //    else
        //        drCurrent = dtQTKTKL.NewRow();

        //    drCurrent["Ma_Dt_CbNv"] = strMa_Dt_CbNv;
        //    frmQTKTKL_Edit frmEdit = new frmQTKTKL_Edit();
        //    frmEdit.Load(enuNew_Edit, drCurrent);

        //    // người dùng chọn chấp nhận
        //    if (frmEdit.isAccept)
        //    {
        //        if (enuNew_Edit == enuEdit.New)
        //        {
        //            if (bdsQTKTKL.Position >= 0)
        //                dtQTKTKL.ImportRow(drCurrent);
        //            else
        //                dtQTKTKL.Rows.Add(drCurrent);

        //            bdsQTKTKL.Position = bdsQTKTKL.Find("Ident00", drCurrent["Ident00"]);
        //        }
        //        else
        //            Common.CopyDataRow(drCurrent, ((DataRowView)bdsQTKTKL.Current).Row);

        //        dtQTKTKL.AcceptChanges();
        //    }
        //    else
        //        dtQTKTKL.RejectChanges();
        //}

        void EditNghiPhep(enuEdit enuNew_Edit)
        {
            

            if (bdsNghiPhep.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            

            //Copy hang hien tai            
            if (bdsNghiPhep.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsNghiPhep.Current).Row, ref drCurrent);
            else
                drCurrent = dtNghiPhep.NewRow();

            drCurrent["Ma_Dt_CbNv"] = strMa_Dt_CbNv;

            frmNghiPhep_Edit frmEdit = new frmNghiPhep_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsNghiPhep.Position >= 0)
                        dtNghiPhep.ImportRow(drCurrent);
                    else
                        dtNghiPhep.Rows.Add(drCurrent);

                    bdsNghiPhep.Position = bdsNghiPhep.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsNghiPhep.Current).Row);

                dtNghiPhep.AcceptChanges();
            }
            else
                dtNghiPhep.RejectChanges();
        }

        void EditTsTn0(enuEdit enuNew_Edit)
        {
           

            if (bdsTsTn0.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

           

            //Copy hang hien tai            
            if (bdsTsTn0.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsTsTn0.Current).Row, ref drCurrent);
            else
                drCurrent = dtTsTn0.NewRow();

            drCurrent["Ma_Dt_CbNv"] = strMa_Dt_CbNv;

            frmTsTn0_Edit frmEdit = new frmTsTn0_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsTsTn0.Position >= 0)
                        dtTsTn0.ImportRow(drCurrent);
                    else
                        dtTsTn0.Rows.Add(drCurrent);

                    bdsTsTn0.Position = bdsTsTn0.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsTsTn0.Current).Row);

                dtTsTn0.AcceptChanges();
            }
            else
                dtTsTn0.RejectChanges();
        }
        void DeleteQHGD()
        {
            if (bdsQHGD.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQHGD.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QHGD", drCurrent))
            {
                bdsQHGD.RemoveAt(bdsQHGD.Position);
                dtQHGD.AcceptChanges();
            }
        }

        void DeleteQTCT()
        {
            if (bdsQTCT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQTCT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QTCT", drCurrent))
            {
                bdsQTCT.RemoveAt(bdsQTCT.Position);
                dtQTCT.AcceptChanges();
            }
        }

        void DeleteQTDT()
        {
            if (bdsQTDT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQTDT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QTDT", drCurrent))
            {
                bdsQTDT.RemoveAt(bdsQTDT.Position);
                dtQTDT.AcceptChanges();
            }
        }

        void DeleteHDLD()
        {
            if (bdsHDLD.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsHDLD.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09HDLD", drCurrent))
            {
                bdsHDLD.RemoveAt(bdsHDLD.Position);
                dtHDLD.AcceptChanges();
            }
        }

        void DeleteQTKTKL()
        {
            if (bdsQTKTKL.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsQTKTKL.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09QTKTKL", drCurrent))
            {
                bdsQTKTKL.RemoveAt(bdsQTKTKL.Position);
                dtQTKTKL.AcceptChanges();
            }
        }

        void DeleteNghiPhep()
        {
            if (bdsNghiPhep.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsNghiPhep.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R09NGHIPHEP", drCurrent))
            {
                bdsNghiPhep.RemoveAt(bdsNghiPhep.Position);
                dtNghiPhep.AcceptChanges();
            }
        }

        void DeleteTsTn0()
        {
            if (bdsTsTn0.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsTsTn0.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R10TsTn0", drCurrent))
            {
                bdsTsTn0.RemoveAt(bdsTsTn0.Position);
                dtTsTn0.AcceptChanges();
            }
        }
		void btDelete_Click(object sender, EventArgs e)
		{
            if (tabDetail.SelectedTab == pageQHGD)
                this.DeleteQHGD();
            else if (tabDetail.SelectedTab == pageQTDT)
                this.DeleteQTDT();
            else if (tabDetail.SelectedTab == pageQTCT)
                this.DeleteQTCT();
            else if (tabDetail.SelectedTab == pageHDLD)
                this.DeleteHDLD();
            else if (tabDetail.SelectedTab == pageQTKTKL)
                this.DeleteQTKTKL();
            else if (tabDetail.SelectedTab == pageHDLD)
                this.DeleteHDLD();
            else if (tabDetail.SelectedTab == pageNghiPhep)
                this.DeleteNghiPhep();
            else if (tabDetail.SelectedTab == pageTsTn0)
                this.DeleteTsTn0();
		}

		void btEdit_Click(object sender, EventArgs e)
		{
            if (tabDetail.SelectedTab == pageQHGD)
                this.EditQHGD(enuEdit.Edit);
            else if (tabDetail.SelectedTab == pageQTDT)
                this.EditQTDT(enuEdit.Edit);
            else if (tabDetail.SelectedTab == pageQTCT)
                this.EditQTCT(enuEdit.Edit);
            else if (tabDetail.SelectedTab == pageHDLD)
                this.EditHDLD(enuEdit.Edit);
            //else if (tabDetail.SelectedTab == pageQTKTKL)
            //    this.EditQTKTKL(enuEdit.Edit);
            else if (tabDetail.SelectedTab == pageHDLD)
                this.EditHDLD(enuEdit.Edit);
            else if (tabDetail.SelectedTab == pageNghiPhep)
                this.EditNghiPhep(enuEdit.Edit);
            else if (tabDetail.SelectedTab == pageTsTn0)
                this.EditTsTn0(enuEdit.Edit);
		}

		void btNew_Click(object sender, EventArgs e)
		{
            if (tabDetail.SelectedTab == pageQHGD)
                this.EditQHGD(enuEdit.New);
            else if (tabDetail.SelectedTab == pageQTDT)
                this.EditQTDT(enuEdit.New);
            else if (tabDetail.SelectedTab == pageQTCT)
                this.EditQTCT(enuEdit.New);
            else if (tabDetail.SelectedTab == pageHDLD)
                this.EditHDLD(enuEdit.New);
            //else if (tabDetail.SelectedTab == pageQTKTKL)
            //    this.EditQTKTKL(enuEdit.New);
            else if (tabDetail.SelectedTab == pageHDLD)
                this.EditHDLD(enuEdit.New);
            else if (tabDetail.SelectedTab == pageNghiPhep)
                this.EditNghiPhep(enuEdit.New);
            else if (tabDetail.SelectedTab == pageTsTn0)
                this.EditTsTn0(enuEdit.New);
		}

		#endregion

		//#region Event
		
		

		

		
		
		
		

		void btAccept_Click(object sender, EventArgs e)
		{
			
		}

		void btCancel_Click(object sender, EventArgs e)
		{
            //this.Is_Accept = false;
            //this.Close();
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				
			}
			else if (e.KeyCode == Keys.F3)
			{
				
			}
			else if (e.KeyCode == Keys.F8)
			{
				
			}
			else
			base.OnKeyDown(e);


		}

       
			


	}

}