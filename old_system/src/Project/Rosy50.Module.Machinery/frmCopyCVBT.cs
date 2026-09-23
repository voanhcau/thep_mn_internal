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
using System.Data.SqlClient;

namespace RosyModule.Machinery
{
    public partial class frmCopyCVBT : RosySystem.Customize.frmView
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

        public frmCopyCVBT()
		{
			InitializeComponent();


            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            btRefresh.Click += new EventHandler(btRefresh_Click);
            this.KeyDown += new KeyEventHandler(frmAddList_VTTB_KeyDown);

            txtMa_Tb_Copy.Validating += new CancelEventHandler(txtMa_Tb_Copy_Validating);
            txtMa_Tb.Validating += new CancelEventHandler(txtMa_Tb_Validating);
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
		
      

		private void Build()
		{
            
            txtMa_Tb.bUseAutoDropDown = true;
           
            

            dgvDmVt.Dock = DockStyle.Fill;
            dgvDmVt.strZone = "CONGVIECBTDK";
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
            
            ht.Add("MA_TB", txtMa_Tb.Text);
            dtDmVt = SQLExec.ExecuteReturnDt("sp_GetCopyBTTB", ht, CommandType.StoredProcedure);

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

            DataTable dtCopy = DataTool.SQLGetDataTable("R06CONGVIECBTDK", "*", "0=1", "");
         

            foreach (DataRow drSelect in dtDmVt.Select("Chon = true"))
            {
                DataRow drEditCtNew = dtCopy.NewRow();
                Common.CopyDataRow(drSelect, drEditCtNew);
                Common.SetDefaultDataRow(ref drEditCtNew);
                
                dtCopy.Rows.Add(drEditCtNew);
                drEditCtNew.AcceptChanges();
            }

            Save(dtCopy);
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
        void txtMa_Tb_Copy_Validating(object sender, CancelEventArgs e)
        {
            bool bRequire = false;
            //string strKey = "";
            string strKey = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Tb", txtMa_Tb_Copy.Text, bRequire, strKey, "");


            if (drLookup != null)
            {
                txtMa_Tb_Copy.Text = (string)drLookup["Ma_Tb"];
                lbtTen_Tb_Copy.Text = (string)drLookup["Ten_Tb"];
            }
            else
            {
                txtMa_Tb_Copy.Text = string.Empty;
                lbtTen_Tb_Copy.Text = string.Empty;
            }
        }
        void txtMa_Tb_Validating(object sender, CancelEventArgs e)
        {
            bool bRequire = false;
            //string strKey = "";
            string strKey = "";

            DataRow drLookup = Lookup.ShowLookup("Ma_Tb", txtMa_Tb.Text, bRequire, strKey, "");
            

            if (drLookup != null)
            {
                txtMa_Tb.Text = (string)drLookup["Ma_Tb"];
                lbtTen_Tb.Text = (string)drLookup["Ten_Tb"];
            }
            else
            {
                txtMa_Tb.Text = string.Empty;
                lbtTen_Tb.Text = string.Empty;
            }
        }
        void Save(DataTable dtImport)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();
            
            sqlCom.Parameters.AddWithValue("@MA_TB", txtMa_Tb_Copy.Text);
            sqlCom.Parameters.AddWithValue("@MA_DATA", Element.sysMa_Data);
            sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());
            
            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_CopyCVBTTB";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_CONGVIECBTTB";
            paraCt.Value = Voucher.GetTVPValue("R06CONGVIECBTDK", "TVP_CONGVIECBTTB", dtImport);
            sqlCom.Parameters.Add(paraCt);

            try
            {
                sqlCom.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                sqlCom.CommandType = CommandType.Text;
                sqlCom.Parameters.Clear();
                sqlCom.ExecuteNonQuery();

                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);

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
