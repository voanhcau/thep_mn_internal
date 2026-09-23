using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Library;
using RosyList;
using RosySystem.Customize;
using RosySystem;
using RosySystem.Common;
using RosySystem.Public;
using System.Collections;
using RosySystem.Element;


namespace RosyModule.Payable
{
	public partial class frmNhapBarcodePT : RosySystem.Customize.frmView
	{

        //private rptFileReport repFile = new rptFileReport();
		private DataTable dtBarcodePT;
		private BindingSource bdsBarcodePT = new BindingSource();		
		private DataRow drCurrent;
        
		#region Phuong thuc

        public frmNhapBarcodePT()
		{
			InitializeComponent();

            txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
            btRefresh.Click += new EventHandler(btRefresh_Click);

            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
            
            btReplace.Click += new EventHandler(btReplace_Click);
            btExit.Click += new EventHandler(btExit_Click);

            dgvBarcodePT.Enter += new EventHandler(dgvBarcodePT_Enter);
		}

       

       

        

      
		private void Build()
		{
            txtMa_Vt.bUseAutoDropDown = true;
            txtMa_Vt.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%' AND LEN(Ma_Vt) = 9";
			
            dgvBarcodePT.strZone = "BARCODEPT";
            dgvBarcodePT.Dock = DockStyle.Fill;

            dgvBarcodePT.BuildGridView(false);

		}

		private void FillData()
		{
            Hashtable htPara = new Hashtable();
            
            htPara.Add("MA_VT", txtMa_Vt.Text);
            dtBarcodePT = SQLExec.ExecuteReturnDt("sp_GetBarcodePT_List", htPara, CommandType.StoredProcedure);

			bdsBarcodePT.DataSource = dtBarcodePT;
			dgvBarcodePT.DataSource = bdsBarcodePT;
		}

		new public void Load()
		{

			Build();
			FillData();

			BindingLanguage();

			this.ShowDialog();
		}

		

		private bool FormCheckValid()
		{
			bool bvalid = true;

			

			return bvalid;
		}
        void btPrint_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsBarcodePT.Current).Row;
            Voucher.ProcessBarcodePT("", drCurrent["Barcode"].ToString(), false);
        }
       
        void btEdit_Click(object sender, EventArgs e)
        {
            Edit_BarcodePT(enuEdit.Edit);
        }
        void btReplace_Click(object sender, EventArgs e)
        {
            if (bdsBarcodePT.Position < 0)
                return;

            //Copy hang hien tai
            if (bdsBarcodePT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBarcodePT.Current).Row, ref drCurrent);
            else
                drCurrent = dtBarcodePT.NewRow();

            frmBarcodePT_Edit frmEdit = new frmBarcodePT_Edit();
            frmEdit.Load(enuEdit.Edit, drCurrent, "Replace");

            if (frmEdit.isAccept)
            {
               Common.CopyDataRow(drCurrent, ((DataRowView)bdsBarcodePT.Current).Row);
               dtBarcodePT.AcceptChanges();
            }
        }
        void btNew_Click(object sender, EventArgs e)
        {
            Edit_BarcodePT(enuEdit.New);
        }
        void btDelete_Click(object sender, EventArgs e)
        {
            Delete_BarcodePT();
        }
        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
		#endregion

		#region Su kien
        void Delete_BarcodePT()
        {
            if (bdsBarcodePT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsBarcodePT.Current).Row;

            if(Common.CheckPermission("NHAPBARCODEPT",enuPermission_Type.Allow_Delete))
            {
                if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("R81DMBARCODEPT", drCurrent))
                {
                    bdsBarcodePT.RemoveAt(bdsBarcodePT.Position);
                    dtBarcodePT.AcceptChanges();
                }
            }
        }
        void Edit_BarcodePT(enuEdit enuNew_Edit)
        {
            if (bdsBarcodePT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai
            if (bdsBarcodePT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBarcodePT.Current).Row, ref drCurrent);
            else
                drCurrent = dtBarcodePT.NewRow();
            
            string strLoai_Ct = string.Empty;

            if (enuNew_Edit == enuEdit.New)
                strLoai_Ct = "New";
            else
                strLoai_Ct = "Edit";

            frmBarcodePT_Edit frmEdit = new frmBarcodePT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, strLoai_Ct);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsBarcodePT.Position >= 0)
                        dtBarcodePT.ImportRow(drCurrent);
                    else
                        dtBarcodePT.Rows.Add(drCurrent);
                    DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", frmEdit.strMa_Vt);

                    drCurrent["Ten_Vt"] = drDmVt["Ten_Vt"];
                    drCurrent["Dvt"] = drDmVt["Dvt"];

                    bdsBarcodePT.Position = bdsBarcodePT.Find("Barcode", drCurrent["Barcode"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsBarcodePT.Current).Row);

                dtBarcodePT.AcceptChanges();
            }

        }
        void dgvBarcodePT_Enter(object sender, EventArgs e)
        {
            ExportControl = sender;
        }
        void txtMa_Vt_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt.Text = string.Empty;
                lbtTen_Vt.Text = string.Empty;

            }
            else
            {
                txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
                lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
            }
        }

        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }

		

		#endregion

      

      
        
	}
}