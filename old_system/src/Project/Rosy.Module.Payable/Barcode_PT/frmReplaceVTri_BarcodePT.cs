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
	public partial class frmReplace_BarcodePT : RosySystem.Customize.frmView
	{
		

		private DataTable dtBarcodePT;
		private BindingSource bdsBarcodePT = new BindingSource();		
		private DataRow drCurrent;
      
		#region Phuong thuc

        public frmReplace_BarcodePT()
		{
			InitializeComponent();

            txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);

            btAccept.Click += new EventHandler(btAccept_Click);
            btExit.Click += new EventHandler(btExit_Click);
            btRefresh.Click+=new EventHandler(btRefresh_Click);
            dgvReplaceBarcodePT.CellValidating += new DataGridViewCellValidatingEventHandler(dgvReplaceBarcodePT_CellValidating);
		}

       

        

		private void Build()
		{
            txtMa_Vt.bUseAutoDropDown = true;
            txtMa_Vt.strLookupKeyFilter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI%' AND Ma_Nh_Vt NOT LIKE 'DACCM%' AND Ma_Nh_Vt NOT LIKE 'VTNA%' AND LEN(Ma_Vt) = 9";

            dgvReplaceBarcodePT.strZone = "REPLACEVTRIPT";
            dgvReplaceBarcodePT.Dock = DockStyle.Fill;

            dgvReplaceBarcodePT.BuildGridView(false);

            foreach (DataGridViewColumn dgvc in dgvReplaceBarcodePT.Columns)
                dgvc.ReadOnly = true;

            if (dgvReplaceBarcodePT.Columns.Contains("MA_VTRI"))
                dgvReplaceBarcodePT.Columns["MA_VTRI"].ReadOnly = false;
		}

		private void FillData()
		{
            Hashtable htPara = new Hashtable();

            htPara.Add("MA_VT", txtMa_Vt.Text);
            dtBarcodePT = SQLExec.ExecuteReturnDt("sp_GetBarcodePT_VTri", htPara, CommandType.StoredProcedure);

			bdsBarcodePT.DataSource = dtBarcodePT;
			dgvReplaceBarcodePT.DataSource = bdsBarcodePT;
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
        private void Save()
        {
            string strMa_Vt = string.Empty;
            string strMa_VTri_Old = string.Empty;
            string strMa_VTri = string.Empty;
            string strSQL1 = string.Empty;
           
            foreach (DataRow dr in dtBarcodePT.Select("Ma_VTri <> ''"))
            {
                strMa_Vt = dr["Ma_Vt"].ToString();
                strMa_VTri_Old = dr["Ma_VTri_Old"].ToString();
                strMa_VTri = dr["Ma_VTri"].ToString();

                strSQL1 = "UPDATE R04CTPO SET Ma_Vtri = '" + strMa_VTri + "' WHERE Ma_Vt = '" + strMa_Vt + "' AND Ma_VTri = '" + strMa_VTri_Old  + "'";
                SQLExec.Execute(strSQL1);

                strSQL1 = "UPDATE R81DMBARCODEPT SET Ma_Vtri = '" + strMa_VTri + "' WHERE Ma_Vt = '" + strMa_Vt + "' AND Ma_VTri = '" + strMa_VTri_Old + "'";
                SQLExec.Execute(strSQL1);

                strSQL1 = "UPDATE R05CTX_BARCODEPT SET Ma_Vtri = '" + strMa_VTri + "' WHERE Ma_Vt = '" + strMa_Vt + "' AND Ma_VTri = '" + strMa_VTri_Old + "'";
                SQLExec.Execute(strSQL1);

                strSQL1 = "UPDATE R05CTNXVTRI SET Ma_Vtri = '" + strMa_VTri + "' WHERE Ma_Vt = '" + strMa_Vt + "' AND Ma_VTri = '" + strMa_VTri_Old + "'";
                SQLExec.Execute(strSQL1);

                strSQL1 = "UPDATE R80SDV SET Ma_Vtri = '" + strMa_VTri + "' WHERE Ma_Vt = '" + strMa_Vt + "' AND Ma_VTri = '" + strMa_VTri_Old + "'";
                SQLExec.Execute(strSQL1);
                
                strSQL1 = "UPDATE R80SDVPT SET Ma_Vtri = '" + strMa_VTri + "' WHERE Ma_Vt = '" + strMa_Vt + "' AND Ma_VTri = '" + strMa_VTri_Old + "'";
                SQLExec.Execute(strSQL1);

                strSQL1 = "UPDATE R05KIEMKE SET Ma_Vtri = '" + strMa_VTri + "' WHERE Ma_Vt = '" + strMa_Vt + "' AND Ma_VTri = '" + strMa_VTri_Old + "'";
                SQLExec.Execute(strSQL1);
            }

        }
        void btAccept_Click(object sender, EventArgs e)
        {
            Save();
            Common.MsgOk("Đã chuyển vị trí xong!!!");
        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
		#endregion

		#region Su kien
       
       
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

        void dgvReplaceBarcodePT_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dgvVoucher dgvEditCt = (dgvVoucher)sender;

            drCurrent = ((DataRowView)bdsBarcodePT.Current).Row;
            DataGridViewCell dgvCell = ((dgvVoucher)sender).CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            bool bLookup = true;

            //Xu ly Lookup
            if (this.ActiveControl == null)
                return;

            if (Common.Inlist(strColumnName, "MA_VTRI"))
            {
                bLookup = dgvLookupMa_VTri(ref dgvCell);
            }
        }
        private bool dgvLookupMa_VTri(ref DataGridViewCell dgvCell)
        {

            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_VTri", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                dgvCell.Value = drLookup["Type_ID"].ToString();
                dgvCell.Tag = drLookup["Type_Name"].ToString();

              
            }
            return true;
        }
		#endregion

      

      
        
	}
}