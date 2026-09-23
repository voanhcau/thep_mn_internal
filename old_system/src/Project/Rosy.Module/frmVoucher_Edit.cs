using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Customize;

namespace RosyModule
{
	public partial class frmVoucher_Edit : RosySystem.Customize.frmEdit
	{
		public DataSet dsVoucher;
		public BindingSource bdsEditCt = new BindingSource();
		public BindingSource bdsEditCt_TR = new BindingSource();
		public BindingSource bdsEdit_TR = new BindingSource();

		public DataTable dtEditPh;
		public DataRow drEditPh;

		public DataTable dtEditCt;
		public DataRow drCurrent;

		public DataRow drDmCt;
		public DataRow drDmNvu;
        //public DataRow drPh;

		public string strStt = string.Empty;
		public string strMa_Ct = string.Empty;
		public bool bDgvEditCtFocusing = false;

		public rsDictionary dicName = new rsDictionary();
		public DataTable dtHanTt0;
		public DataTable dtEditCt_LR;

		public frmVoucher_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            this.btNotVAT.Click += new EventHandler(btNotVAT_Click);
			this.lblLog.Click += new EventHandler(lblLog_Click);
		}

    

		public virtual void Load(enuEdit enuNew_Edit, DataRow drEdit, DataSet dsVoucher)
		{


           
		}
        public virtual void Load_Tb(enuEdit enuNew_Edit, DataRow drEdit, DataSet dsVoucher)
        {

        }
		public virtual bool Save()
		{
			return true;
		}
        public virtual void ExportFileExcel()
        {
        }
        
		void lblLog_Click(object sender, EventArgs e)
		{
			if (bdsEditCt.Count < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsEditCt.Current).Row;
			frmDataLog_Ct frmDataLog_Ct = new frmDataLog_Ct();
			frmDataLog_Ct.Load(drCurrent);
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			//SaveOption: 

			if (cboSaveOption.Text.StartsWith("1")) //Lưu & Nhập tiếp
			{
				this.isAccept = true;

				if (this.Save())
				{
					this.Load(enuEdit.New, drEdit, dsVoucher);
				}
			}
			else if (cboSaveOption.Text.StartsWith("2")) //Lưu & Đóng lại
			{
				this.isAccept = true;

				if (this.Save())
				{
					this.Close();
				}
			}
			else if (cboSaveOption.Text.StartsWith("3")) //Lưu - In & Nhập tiếp
			{
				this.isAccept = true;
				bool bInVisibleNextPrint = false;

				if (this.Save())
				{
					Voucher.Print(this.strStt, true, true, ref bInVisibleNextPrint);

					this.Load(enuEdit.New, drEdit, dsVoucher);
				}
			}
			else if (cboSaveOption.Text.StartsWith("4")) //Lưu - In & Đóng lại
			{
				this.isAccept = true;
				bool bInVisibleNextPrint = false;

				if (this.Save())
				{
					this.Close();

					Voucher.Print(this.strStt, true, true, ref bInVisibleNextPrint);
				}
			}
			else if (cboSaveOption.Text.StartsWith("5")) //In & Nhập tiếp
			{
				this.isAccept = false;
				bool bInVisibleNextPrint = false;

				Voucher.Print(this.strStt, true, true, ref bInVisibleNextPrint);
				this.Load(enuEdit.New, drEdit, dsVoucher);
			}
			else if (cboSaveOption.Text.StartsWith("6")) //In & Đóng lại
			{
				this.isAccept = false;
				bool bInVisibleNextPrint = false;

				Voucher.Print(this.strStt, true, true, ref bInVisibleNextPrint);
				this.Close();
			}
            else if (cboSaveOption.Text.StartsWith("7")) //Lưu - In & Đóng lại ko cần vào form view
            {
                this.isAccept = true;
                bool bInVisibleNextPrint = false;

                if (this.Save())
                {
                    this.Close();

                    Voucher.Print_Option(this.strStt, true, true, ref bInVisibleNextPrint);
                }
            }
            else if (cboSaveOption.Text.StartsWith("8")) //Lưu - đóng lại & xuất file excel
            {
                this.isAccept = true;
                if (this.Save())
                {

                    this.Close();
                    this.ExportFileExcel();
                }
            }
		}
        
		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
        void btNotVAT_Click(object sender, EventArgs e)
        {
            string strTable_Ct = DataTool.SQLGetNameByCode("R00DMCT", "Ma_Ct", "Table_Ct", strMa_Ct);
            DataTable dtEditCt = DataTool.SQLGetDataTable(strTable_Ct,"*","Stt = '"+strStt+"'","");
			if(dtEditCt.Rows.Count > 0)
			{ 
				frmNotVAT frm = new frmNotVAT();
				frm.Load(dtEditCt.Rows[0]);
			}
		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			
			//Kiem tra Permission
			if (Element.Is_Running)
			{
                if (Common.Inlist(strMa_Ct, Parameters.GetParaValue("CTNOTVAT").ToString()) && Common.CheckPermission("NOTVAT", enuPermission_Type.Allow_Access))
                    this.btNotVAT.Visible = true;
                else
                    btNotVAT.Visible = false;

				switch (this.enuNew_Edit)
				{
					case enuEdit.New:
					case enuEdit.Copy:
						{
							this.btgAccept.btAccept.Enabled = Common.CheckPermission((string)drDmCt["Object_ID"], enuPermission_Type.Allow_New);

                            if (drEditPh.Table.Columns.Contains("Print_Count"))
                            {
                                drEditPh["Print_Count"] = 0;
                                drEditPh["User_Print"] = string.Empty;
                            }

							if(Common.Inlist(strMa_Ct, "PYCPT,DTCP,DNXL,PYCCK,DT,PYCTH,POCG,PONL,POXL,DNTT"))
							{
								drEditPh["DUYET_TP"] = false;
								drEditPh["DUYET_KTCDAT"] = false;
								drEditPh["DUYET_KHVT"] = false;
								drEditPh["DUYET_PXCD"] = false;
                                drEditPh["DUYET_KTTC"] = false;
								drEditPh["DUYET_GIAMDOC"] = false;
                                drEditPh["IS_VT_NHAN"] = false;

								drEditPh["DUYET_TP_LOG"] = string.Empty;
								drEditPh["DUYET_KTCDAT_LOG"] = string.Empty;

								drEditPh["DUYET_KHVT_LOG"] = string.Empty;
								drEditPh["DUYET_PXCD_LOG"] = string.Empty;
                                drEditPh["DUYET_KTTC_LOG"] = string.Empty;
								drEditPh["DUYET_GD_LOG"] = string.Empty;
                                drEditPh["USER_VT"] = string.Empty;
							}
							break;
						}
					case enuEdit.Edit:
                        this.btgAccept.btAccept.Enabled = Common.CheckPermission((string)drDmCt["Object_ID"], enuPermission_Type.Allow_Edit);
							break;
				
					default:
						break;
				}

				if (enuNew_Edit == enuEdit.Edit)
					lblLog.Text = "Create: " + Common.Show_Log((string)drEditPh["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEditPh["LastModify_Log"]);
				else
					lblLog.Text = "";
			}

			//Nếu là PYC 
            //drPh = DataTool.SQLGetDataRowByID("R80PH", "Stt", strStt);
            if (Common.Inlist(strMa_Ct, "PYCPT,PYCCK,PYCTH,DNXNL,DNX,DTCP,PONL,POXL") && enuNew_Edit == enuEdit.Edit && Convert.ToBoolean(drEditPh["DUYET_TP"]) && Element.sysUser_Id != ((string)drEditPh["Duyet_Tp_Log"]).Substring(14))
			{
				this.btgAccept.btAccept.Enabled = false;
			}
			//Nếu là DT 
            else if (Common.Inlist(strMa_Ct, "DT,POCG") && enuNew_Edit == enuEdit.Edit && Convert.ToBoolean(drEditPh["DUYET_KHVT"]))
			{
				this.btgAccept.btAccept.Enabled = false;
			}
            
			//Nếu là LGH,SO
            else if ((Common.Inlist(strMa_Ct, "LXH,SO,SOCP") && enuNew_Edit == enuEdit.Edit) && ((bool)(drEditPh["Duyet"]) || (bool)(drEditPh["Duyet_PKD"]) || (bool)(drEditPh["Duyet_Huy"])))
			{
			    this.btgAccept.btAccept.Enabled = false;
			}
            //Nếu chứng từ đã kế thừa không cho sửa
            else if (enuNew_Edit == enuEdit.Edit && !Common.Inlist(strMa_Ct,"PNSB,PXSB,PNPT,PXPT,BTKH,BBBN,BBHH,BTNT,BTTT,BTBN,CTSC,BTNB")) // Bằng bỏ dk PXBR, PXDC đã ra HD thì ko cho sửa
            {
                bool bInherit = Voucher.CheckInheritAllTable(strStt);

                if (bInherit)
                    this.btgAccept.btAccept.Enabled = false;
            }//Nếu là PXBR, PXDC
            else if (enuNew_Edit == enuEdit.Edit && Common.Inlist(strMa_Ct, "PXDC,PXBR"))
            {
                if (dtEditCt.Columns.Contains("Ma_Nvu"))
                {
                    drDmNvu = DataTool.SQLGetDataRowByID("R81DMNVU", "Ma_Nvu", drEdit["Ma_Nvu"].ToString());
                    if ((Convert.ToDouble(drEditPh["Print_Count"]) != 0) && Convert.ToBoolean(drDmNvu["Is_Not_Lock"]) != true && !Common.CheckPermission("IS_EDIT_HD", enuPermission_Type.Allow_Access))
                    {
                        this.btgAccept.btAccept.Enabled = false;
                        //Common.MsgCancel("Chứng từ đã được in, không thể sửa !");
                        //return;
                    }
                }
            }
		}

		//protected override void OnKeyDown(KeyEventArgs e)
		//{
		//    if (e.KeyCode == Keys.Escape)
		//    {
		//        if (Common.MsgYes_No("Có muốn thoát không?????"))
		//            this.Close();
		//    }
		//}
		protected override void OnClosed(EventArgs e)
		{
			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				Common.SetBufferValue("Voucher_Save_Option", cboSaveOption.Text);

			base.OnClosed(e);
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		
{
			if (keyData == Keys.F4)
			{
				if (this.ActiveControl.GetType().Name == "dgvVoucher")
					bDgvEditCtFocusing = true;
				else
					if (bDgvEditCtFocusing)
						bDgvEditCtFocusing = false;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}
