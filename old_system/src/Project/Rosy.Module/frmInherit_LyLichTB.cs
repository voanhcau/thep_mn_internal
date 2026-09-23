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
	public partial class frmInherit_LyLichTB : RosySystem.Customize.frmEdit
	{
		frmVoucher_Edit frmCtNX_Edit;

		private DataTable dtDinhMucVt;
		private BindingSource bdsDinhMucVt = new BindingSource();		
		private DataRow drCurrent;
        string strLoai;
		#region Phuong thuc

        public frmInherit_LyLichTB()
		{
			InitializeComponent();

            txtMa_Nh_Tb.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Tb.Validating += new CancelEventHandler(txtMa_Tb_Validating);
            btRefresh.Click += new EventHandler(btRefresh_Click);
            this.KeyDown += new KeyEventHandler(dgvDinhMuc_KeyDown);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

        

        

		private void Build()
		{
			if(strLoai != "frmCtBTTB_Edit")
			    dgvDinhMuc.strZone = "INHERIT_PHUTUNGTB";
            else
                dgvDinhMuc.strZone = "INHERIT_CONGVIECTB";

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
           
            htPara.Add("MA_NH_TB", txtMa_Nh_Tb.Text);
            htPara.Add("MA_TB", txtMa_Tb.Text);
            htPara.Add("LOAI", strLoai);
           
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            dtDinhMucVt = SQLExec.ExecuteReturnDt("sp_Inherit_LyLichTb", htPara, CommandType.StoredProcedure);

			bdsDinhMucVt.DataSource = dtDinhMucVt;
			dgvDinhMuc.DataSource = bdsDinhMucVt;
		}

		new public void Load(frmVoucher_Edit frmCtNX_Edit, string strMa_Nh_Tb)
		{
			this.frmCtNX_Edit = frmCtNX_Edit;
            strLoai = frmCtNX_Edit.Name;
            txtMa_Nh_Tb.Text = strMa_Nh_Tb;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

          
			Build();
			FillData();

			BindingLanguage();

			this.ShowDialog();
		}

		void XuatDinhMuc()
		{
			int iStt0 = Convert.ToInt16(Common.MaxDCValue(frmCtNX_Edit.dtEditCt, "Stt0"));

			DataTable dtEditCt = frmCtNX_Edit.dtEditCt;
			DataRow drEditCtNew = dtEditCt.NewRow();
			Common.CopyDataRow(dtEditCt.Rows[0], drEditCtNew);

          
           
            if (strLoai != "frmCtBTTB_Edit")
            {
                if (dtEditCt.Rows.Count > 0 && dtEditCt.Rows.Count == 1 && dtEditCt.Rows[0]["Muc_Dich"] == "")
                    dtEditCt.Rows.Clear();
                foreach (DataRow drDinhMucVt in dtDinhMucVt.Select("Chon = true"))
                {

                    DataRow drEditCt = this.frmCtNX_Edit.dtEditCt.NewRow();
                    Common.CopyDataRow(drEditCtNew, drEditCt);

                    iStt0++;
                    drEditCt["Stt0"] = iStt0;
                    drEditCt["Ma_Vt"] = drDinhMucVt["Ma_Vt"];
                    drEditCt["Ten_Vt"] = drDinhMucVt["Ten_Vt_Chuan"];
                    drEditCt["Ma_Tb_Nha_Sx"] = drDinhMucVt["Ma_Tb_Nha_Sx"];
                    drEditCt["Mo_Ta_Kt"] = drDinhMucVt["Thong_So_Kt"];
                    drEditCt["Ten_Nha_Sx"] = drDinhMucVt["Ten_Nha_Sx"];
                    drEditCt["Muc_Dich"] = drDinhMucVt["Noi_Dung_Th"];
                    drEditCt["Ma_Nh_Tb"] = drDinhMucVt["Ma_Nh_Tb"];
                    drEditCt["Ma_Tb"] = drDinhMucVt["Ma_Tb"];
                    drEditCt["Ten_Tb"] = drDinhMucVt["Ten_Tb"];

                    drEditCt["Dvt"] = drDinhMucVt["Dvt"];
                    drEditCt["So_Luong9"] = drEditCt["So_Luong"] = drEditCt["So_Luong0"] = drEditCt["So_Luong_Tp"] = drEditCt["So_Luong_KtCdAt"] = drEditCt["So_Luong_KhVt"] = drDinhMucVt["So_Luong"];
                    drEditCt["So_Luong_TonKho"] = drDinhMucVt["So_Luong_TonKho"];
                    drEditCt["He_So9"] = 1;

                    frmCtNX_Edit.dtEditCt.Rows.Add(drEditCt);
                    drEditCt.AcceptChanges();
                }
            }
            else
            {
                if (dtEditCt.Rows.Count > 0 && dtEditCt.Rows.Count == 1 && dtEditCt.Rows[0]["Noi_Dung"] == "")
                    dtEditCt.Rows.Clear();
                  foreach (DataRow drDinhMucVt in dtDinhMucVt.Select("Chon = true"))
                {

                    DataRow drEditCt = this.frmCtNX_Edit.dtEditCt.NewRow();
                    Common.CopyDataRow(drEditCtNew, drEditCt);

                    iStt0++;
                    drEditCt["Stt0"] = iStt0;
                    drEditCt["Stt_Nd_Org"] = drDinhMucVt["Stt_Nd"];
                    drEditCt["Ma_Tb"] = drDinhMucVt["Ma_Tb"];
                    drEditCt["Ten_Tb"] = drDinhMucVt["Ten_Tb"];
                    drEditCt["Phan_Loai_Cv"] = drDinhMucVt["Phan_Loai_Cv"];
                    drEditCt["Noi_Dung"] = drDinhMucVt["Noi_Dung_Th"];
                    drEditCt["Is_Kh"] = true;
                    frmCtNX_Edit.dtEditCt.Rows.Add(drEditCt);
                    drEditCt.AcceptChanges();
                }
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
        void txtMa_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Tb.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Tb", strValue, bRequire, "Ma_Nh_Tb = '"+ txtMa_Nh_Tb.Text +"'", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Tb.Text = string.Empty;
                lbtTen_Tb.Text = string.Empty;

            }
            else
            {
                txtMa_Tb.Text = drLookup["Ma_Tb"].ToString();
                lbtTen_Tb.Text = drLookup["Ten_Tb"].ToString();

                FillData();
            }
        }
        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Nh_Tb.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Tb", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Nh_Tb.Text = string.Empty;
                lbtTen_Nh_Tb.Text = string.Empty;

            }
            else
            {
                txtMa_Nh_Tb.Text = drLookup["Ma_Nh_Tb"].ToString();
                lbtTen_Nh_Tb.Text = drLookup["Ten_Nh_Tb"].ToString();
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