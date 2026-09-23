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
	public partial class frmAddSttOrg_BarcodePT : RosySystem.Customize.frmView
	{
		

		private DataTable dtBarcodePT;
		private BindingSource bdsBarcodePT = new BindingSource();		
		private DataRow drCurrent;
      
		#region Phuong thuc

        public frmAddSttOrg_BarcodePT()
		{
			InitializeComponent();

            btAccept.Click += new EventHandler(btAccept_Click);
            btExit.Click += new EventHandler(btExit_Click);
            btRefresh.Click+=new EventHandler(btRefresh_Click);
            dgvReplaceBarcodePT.CellValidating += new DataGridViewCellValidatingEventHandler(dgvReplaceBarcodePT_CellValidating);
		}

       

        

		private void Build()
		{
           
            dgvReplaceBarcodePT.strZone = "REPLACEVTRIPT";
            dgvReplaceBarcodePT.Dock = DockStyle.Fill;

            dgvReplaceBarcodePT.BuildGridView(false);

            foreach (DataGridViewColumn dgvc in dgvReplaceBarcodePT.Columns)
                dgvc.ReadOnly = true;

            if (dgvReplaceBarcodePT.Columns.Contains("SO_CT_ORG"))
                dgvReplaceBarcodePT.Columns["SO_CT_ORG"].ReadOnly = false;
		}

		private void FillData()
		{
            Hashtable htPara = new Hashtable();
            dtBarcodePT = SQLExec.ExecuteReturnDt("GetCTXBarcodePT_DNX", htPara, CommandType.StoredProcedure);

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
            string strStt = string.Empty;
            string strStt_Org = string.Empty;
          
            string strSQL1 = string.Empty;
           
            foreach (DataRow dr in dtBarcodePT.Select("So_Ct <> ''"))
            {
                strStt = dr["Stt"].ToString();
                strStt_Org = dr["Stt_Org"].ToString();

                strSQL1 = "UPDATE R05CTX_BARCODEPT SET Stt_Org = '" + strStt_Org + "' WHERE Stt = '" + strStt + "'";
                SQLExec.Execute(strSQL1);
            }

        }
        void btAccept_Click(object sender, EventArgs e)
        {
            Save();
            Common.MsgOk("Đã cập nhật xong xong!!!");
        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
		#endregion

		#region Su kien
       
       
      

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

            if (Common.Inlist(strColumnName, "SO_CT_ORG"))
            {
                bLookup = dgvLookupSo_Ct_Org(ref dgvCell);
            }
        }
        private bool dgvLookupSo_Ct_Org(ref DataGridViewCell dgvCell)
        {

            string strValue = string.Empty;

            if (this.ActiveControl.GetType().Name == "DataGridViewTextBoxEditingControl")
                strValue = this.ActiveControl.Text;
            else
                strValue = dgvCell.FormattedValue.ToString().Trim();

            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("So_Ct", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                return false;

            if (drLookup == null)
            {
                dgvCell.Value = string.Empty;
                dgvCell.Tag = string.Empty;
            }
            else
            {
                drCurrent = ((DataRowView)bdsBarcodePT.Current).Row;
                dgvCell.Value = drLookup["So_Ct"].ToString();
                dgvCell.Tag = drLookup["So_Ct"].ToString();
                drCurrent["Stt_Org"] = drLookup["Stt"].ToString();
              
            }
            return true;
        }
		#endregion

      

      
        
	}
}