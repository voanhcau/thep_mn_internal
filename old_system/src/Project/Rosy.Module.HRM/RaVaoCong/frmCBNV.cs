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

namespace RosyModule.HRM
{
	public partial class frmCBNV : RosySystem.Customize.frmEdit
	{
		

		private DataTable dtCBNV;
		private BindingSource bdsCBNV = new BindingSource();		
		private DataRow drCurrent;
        string strStt;
		#region Phuong thuc

        public frmCBNV()
		{
			InitializeComponent();



            txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_So_Validating);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

      

        

        

		private void Build()
		{
			
             dgvDinhMuc.strZone = "CBNVRVC";

			//dgvDinhMuc.Dock = DockStyle.Fill;
            dgvDinhMuc.ReadOnly = false;

			this.Controls.Add(dgvDinhMuc);

            foreach (DataGridViewColumn dgvc in dgvDinhMuc.Columns)
                dgvc.ReadOnly = true;

            txtMa_Dt_CbNv.bUseAutoDropDown = true;
            txtMa_Dt_CbNv.strLookupKeyFilter = "Ma_Nh_Dt = 'NV'";

            dteGio_Vao.Text = "07:30:00";
			dgvDinhMuc.BuildGridView();
		}

		private void FillData()
		{

            dtCBNV = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Ten_Dt AS Ten_Dt_CbNV FROM R09CT_RVC T1 LEFT JOIN R81DMDT T2 ON T1.Ma_Dt_CbNv = T2.Ma_Dt WHERE STT = '"+ strStt +"'");

            bdsCBNV.DataSource = dtCBNV;
            dgvDinhMuc.DataSource = bdsCBNV;


            DataColumn dc = new DataColumn("Deleted", typeof(bool));
            dc.DefaultValue = false;
            dtCBNV.Columns.Add(dc);

            
		}

        new public void Load(string strStt)
		{
			
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            //dteNgay_Ct.Text =  DateTime.Now.ToShortDateString();
            this.strStt = strStt;
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

		#endregion

		#region Su kien
      
		void btAccept_Click(object sender, EventArgs e)
		{
			isAccept = true;

            foreach (DataRow dr in dtCBNV.Select("Deleted = 0"))
            {
                if (!DataTool.SQLCheckExist("R09CT_RVC", new string[] { "Stt", "Ma_Dt_CbNv", "Loai_RVC" }, new object[] { strStt, dr["Ma_Dt_CbNv"], "1" }))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("STT", strStt);
                    ht.Add("MA_DT_CBNV", dr["Ma_Dt_CbNv"]);
                    ht.Add("GIO_VAO", dr["Gio_Vao"]);
                    ht.Add("CREATE_LOG", Common.GetCurrent_Log());
                    ht.Add("MA_BP", dr["Ma_Bp"]);

                    SQLExec.Execute("INSERT INTO R09CT_RVC(Stt, Ma_Dt_CbNv, Gio_Vao, Loai_RVC, Create_Log, Ma_Bp) VALUES(@Stt,@Ma_Dt_CbNv,@Gio_Vao, 1, @Create_Log, @Ma_Bp)", ht, CommandType.Text);
                }
            }

			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

        void txtMa_So_Validating(object sender, CancelEventArgs e)
        {
            
            bool bRequire = false;
            string strFilter = "";// "AUTO_NUMBER = " + txtMa_Dt_CbNv.Text + " AND Ma_Nh_Dt = 'NV'";

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", txtMa_Dt_CbNv.Text, bRequire, strFilter);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup != null)
            {
                AddRow(drLookup);
                txtMa_Dt_CbNv.Text = "";
                txtMa_Dt_CbNv.Focus();
            }
        }
        private void AddRow(DataRow drLKCBNV)
        {
            
            //DataRow drCBNV = dtCBNV.Rows[0];
            DataRow drCBNV;
            bool bRow_First = false;
            DataRow drNewRow = null;

            if (dtCBNV.Rows.Count == 0)
            {
                drNewRow = dtCBNV.NewRow();
                Common.SetDefaultDataRow(ref drNewRow);
                bRow_First = true;
            }

            if (!bRow_First)
            {
                drCBNV = ((DataRowView)bdsCBNV.Current).Row;
                drNewRow = dtCBNV.NewRow();
                Common.CopyDataRow(drCBNV, drNewRow);
                Common.SetDefaultDataRow(ref drNewRow);
            }

           

            drNewRow["Stt"] = strStt;
            drNewRow["Ma_Dt_CbNv"] = drLKCBNV["Ma_Dt"];
            drNewRow["Ten_Dt_CbNv"] = drLKCBNV["Ten_Dt"];
            
            drNewRow["Gio_Vao"] = Convert.ToDateTime(dteGio_Vao.Text);
            drNewRow["Loai_RVC"] = "1";
            drNewRow["Ma_Bp"] = drLKCBNV["Ma_Bp"];

            drNewRow["Deleted"] = false;

            
          
            //drNewRow["Create_Log"] = Common.GetCurrent_Log();
          
            dtCBNV.Rows.Add(drNewRow);
            dtCBNV.AcceptChanges();

        }
		#endregion

        //private void rsLabel13_Click(object sender, EventArgs e)
        //{

        //}
	}
}