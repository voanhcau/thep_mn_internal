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

namespace RosyModule
{
	public partial class frmInherit_MonAn : RosySystem.Customize.frmEdit
	{
		frmVoucher_Edit frmCtPO_PT_Edit;
      
		private DataTable dtDinhMucVt;
		private BindingSource bdsDinhMucVt = new BindingSource();		
		private DataRow drCurrent;
    
		#region Phuong thuc

        public frmInherit_MonAn()
		{
			InitializeComponent();

          
            btRefresh.Click += new EventHandler(btRefresh_Click);
            this.KeyDown += new KeyEventHandler(dgvDinhMuc_KeyDown);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

        

        

		private void Build()
		{
			dgvDinhMuc.strZone = "INHERIT_THUCDON";

			//dgvDinhMuc.Dock = DockStyle.Fill;
            dgvDinhMuc.ReadOnly = false;

			this.Controls.Add(dgvDinhMuc);

            foreach (DataGridViewColumn dgvc in dgvDinhMuc.Columns)
                dgvc.ReadOnly = true;

            if (dgvDinhMuc.Columns.Contains("CHON"))
                dgvDinhMuc.Columns["CHON"].ReadOnly = false;

			dgvDinhMuc.BuildGridView();
		}

		private void FillData()
		{
            Hashtable htPara = new Hashtable();

            htPara.Add("NGAY_CT", dteNgay_Ct.Text);
            dtDinhMucVt = SQLExec.ExecuteReturnDt("sp_Inherit_DTNA", htPara, CommandType.StoredProcedure);

			bdsDinhMucVt.DataSource = dtDinhMucVt;
			dgvDinhMuc.DataSource = bdsDinhMucVt;
		}

		new public void Load(frmVoucher_Edit frmCtPO_PT_Edit)
		{
            this.frmCtPO_PT_Edit = frmCtPO_PT_Edit;
           
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            dteNgay_Ct.Text = Library.DateToStr(DateTime.Now);
			Build();
			FillData();

			BindingLanguage();

			this.ShowDialog();
		}

		void XuatDinhMuc()
		{
            //PH
            DataRow drEditPh = frmCtPO_PT_Edit.drEditPh;

            Common.GatherMemvar(frmCtPO_PT_Edit, ref drEditPh);

            drEditPh["Dien_Giai"] = dtDinhMucVt.Rows[0]["Dien_Giai"].ToString();
            drEditPh.AcceptChanges();
            Common.ScaterMemvar(frmCtPO_PT_Edit, ref drEditPh);
            //CT
			int iStt0 = Convert.ToInt16(Common.MaxDCValue(frmCtPO_PT_Edit.dtEditCt, "Stt0"));

			DataTable dtEditCt = frmCtPO_PT_Edit.dtEditCt;
			DataRow drEditCtNew = dtEditCt.NewRow();
			Common.CopyDataRow(dtEditCt.Rows[0], drEditCtNew);

            frmCtPO_PT_Edit.dtEditCt.Clear();

            foreach (DataRow drDinhMucVt in dtDinhMucVt.Select("Chon = true"))
            {
                 
                DataRow drEditCt = this.frmCtPO_PT_Edit.dtEditCt.NewRow();
                Common.CopyDataRow(drEditCtNew, drEditCt);

                iStt0++;
                drEditCt["Stt0"] = iStt0;
                drEditCt["Ma_Vt"] = drDinhMucVt["Ma_Vt"];
                drEditCt["Ten_Vt"] = drDinhMucVt["Ten_Vt"];

                drEditCt["Gia"] = drEditCt["Gia_Nt"] = drEditCt["Gia_Nt9"] = drDinhMucVt["Gia"];
                drEditCt["Tien"] = drEditCt["Tien_Nt"] = drEditCt["Tien_Nt9"] = drDinhMucVt["Tien"];

                drEditCt["Dvt"] = drDinhMucVt["Dvt"];
                drEditCt["So_Luong9"] = drEditCt["So_Luong"] = drEditCt["So_Luong0"] = drEditCt["So_Luong_Tp"] = drEditCt["So_Luong_kttc"] = drDinhMucVt["So_Luong"];

                drEditCt["He_So9"] = 1;
                drEditCt["Ty_Gia"] = 1;
                //drEditCt["He_So9"] = 1;
                frmCtPO_PT_Edit.dtEditCt.Rows.Add(drEditCt);
                
                drEditCt.AcceptChanges();
            }
            
          
		}

		private bool FormCheckValid()
		{
			bool bvalid = true;

			XuatDinhMuc();

			return bvalid;
		}

		#endregion

		#region Su kien
        void dgvDinhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {

                for (int i = 0; i < dtDinhMucVt.Rows.Count; i++)
                {
                    dtDinhMucVt.Rows[i]["CHON"] = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.U)
            {

                for (int i = 0; i < dtDinhMucVt.Rows.Count; i++)
                {
                    dtDinhMucVt.Rows[i]["CHON"] = false;
                }
            }
        }
        

        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }

		void btAccept_Click(object sender, EventArgs e)
		{
			isAccept = true;

			XuatDinhMuc();

			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		#endregion

        //private void rsLabel13_Click(object sender, EventArgs e)
        //{

        //}
	}
}