using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.Machinery
{
    public partial class frmAddList_VTTB : RosySystem.Customize.frmView
	{
		#region variable

        public DataTable dtDmVt;
        public bool Is_Accept = false;

        rsDataGridView dgvDmVt = new rsDataGridView();
		BindingSource bdsDmVt = new BindingSource();

        DataTable dtDmTb;
        rsDataGridView dgvDmTb = new rsDataGridView();
        BindingSource bdsDmTb = new BindingSource();
        
		DataRow drCurrent;
        string strMa_Nh_Tb = string.Empty;

      
		#endregion

		#region Contructor

        public frmAddList_VTTB()
		{
			InitializeComponent();


            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            btRefresh.Click += new EventHandler(btRefresh_Click);
            this.KeyDown += new KeyEventHandler(frmAddList_VTTB_KeyDown);

            txtMa_Tb_Nhom.Validating += new CancelEventHandler(txtMa_Tb_Nhom_Validating);

		}

       
		public void Load()
		{
			Load(string.Empty);
		}

		public void Load(string strMa_VtTb)
		{
            this.strMa_Nh_Tb = strMa_VtTb;

			Build();
			FillData();

            //this.strLookupColumn = "Ma_Vt_Tb";
            //this.strLookupValue = strMa_Vt_Tb;

            //this.MoveToLookupValue();

			this.ShowDialog();
		}
		
        //private void MoveToLookupValue()
        //{
        //    if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
        //        return;

        //    for (int i = 0; i <= dtDmVt.Rows.Count - 1; i++)
        //        if (((string)dtDmVt.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
        //        {
        //            bdsDmVt.Position = i;
        //            break;
        //        }
        //}

		private void Build()
		{
            txtMa_Tb_Nhom.bUseAutoDropDown = true;

            dgvDmVt.Dock = DockStyle.Fill;
            dgvDmVt.strZone = "DMVT_LIST";
            dgvDmVt.BuildGridView();
            dgvDmVt.ReadOnly = false;
            this.splitContainer1.Panel1.Controls.Add(dgvDmVt);


            foreach (DataGridViewColumn dgvc in dgvDmVt.Columns)
                dgvc.ReadOnly = true;

            if (dgvDmVt.Columns.Contains("CHON"))
                dgvDmVt.Columns["CHON"].ReadOnly = false;
          
		}

		private void FillData()
		{       
            Hashtable ht = new Hashtable();
            ht.Add("MA_TB_NHOM", txtMa_Tb_Nhom.Text);
            

			dtDmVt = SQLExec.ExecuteReturnDt("sp_GetDMVT_LIST", ht, CommandType.StoredProcedure);

			bdsDmVt.DataSource = dtDmVt;
            dgvDmVt.DataSource = bdsDmVt;

			this.bdsSearch = bdsDmVt;
            this.ExportControl = dgvDmVt;
		}

       
		#endregion

		#region Event 
        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }
      
        void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void btAccept_Click(object sender, EventArgs e)
        {           
            this.Is_Accept = true;
            this.Close();
           
        }
       

        void frmAddList_VTTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {

                for (int i = 0; i < dtDmVt.Rows.Count; i++)
                {
                    dtDmVt.Rows[i]["CHON"] = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.U)
            {

                for (int i = 0; i < dtDmVt.Rows.Count; i++)
                {
                    dtDmVt.Rows[i]["CHON"] = false;
                }
            }
            if (e.KeyCode == Keys.F5)
                FillData();
        }
		#endregion

		#region method
        void txtMa_Tb_Nhom_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Tb_Nhom.Text.Trim();
            bool bRequire = true;
           

            DataRow drLookup = Lookup.ShowLookup("Ma_Tb_Nhom", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Tb_Nhom.Text = string.Empty;
                lbtTen_Tb_Nhom.Text = string.Empty;
            }
            else
            {
                txtMa_Tb_Nhom.Text = ((string)drLookup["Ma_Tb_Nhom"]).Trim();               
                lbtTen_Tb_Nhom.Text = ((string)drLookup["Ten_Tb"]).Trim();

            }
        }
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}

	

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			
		}

      

        //private void btRemove_Click(object sender, EventArgs e)
        //{

        //}

	}
}
