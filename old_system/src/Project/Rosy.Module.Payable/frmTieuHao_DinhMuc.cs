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
	public partial class frmTieuHao_DinhMuc : RosySystem.Customize.frmEdit
	{
		frmCtPO_PT_Edit frmCtNX_Edit;

		private DataTable dtDinhMucVt;
		private BindingSource bdsDinhMucVt = new BindingSource();		
		private DataRow drCurrent;

		#region Phuong thuc

        public frmTieuHao_DinhMuc()
		{
			InitializeComponent();

            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            btRefresh.Click += new EventHandler(btRefresh_Click);
            this.KeyDown += new KeyEventHandler(dgvDinhMuc_KeyDown);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

        

		private void Build()
		{
			if(frmCtNX_Edit.strMa_Ct == "PYCTH")
			    dgvDinhMuc.strZone = "TIEUHAO_DINHMUC";
            else if (frmCtNX_Edit.strMa_Ct == "PYCPT")
                dgvDinhMuc.strZone = "TIEUHAO_PHUTRO";
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
            htPara.Add("MA_BP", txtMa_Bp.Text);
            htPara.Add("MA_CT", frmCtNX_Edit.strMa_Ct);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            dtDinhMucVt = SQLExec.ExecuteReturnDt("sp_Xuat_PYC_THTX", htPara, CommandType.StoredProcedure);

			bdsDinhMucVt.DataSource = dtDinhMucVt;
			dgvDinhMuc.DataSource = bdsDinhMucVt;
		}

		new public void Load(frmCtPO_PT_Edit frmCtNX_Edit)
		{
			this.frmCtNX_Edit = frmCtNX_Edit;
			
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

            dteNgay_Ct.Text = Library.DateToStr(DateTime.Now);
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

			//Xóa dòng trống đầu tiên
			if (dtDinhMucVt.Rows.Count > 0 && dtEditCt.Rows.Count == 1 && Convert.ToDouble(dtEditCt.Rows[0]["So_Luong"]) + Convert.ToDouble(dtEditCt.Rows[0]["Tien_Nt"]) + Convert.ToDouble(dtEditCt.Rows[0]["Tien"]) == 0)
				dtEditCt.Rows.Clear();

			foreach (DataRow drDinhMucVt in dtDinhMucVt.Select("Chon = true"))
			{
								
				DataRow drEditCt = this.frmCtNX_Edit.dtEditCt.NewRow();
				Common.CopyDataRow(drEditCtNew, drEditCt);				

				iStt0++;
				drEditCt["Stt0"] = iStt0;
				drEditCt["Ma_Vt"] = drDinhMucVt["Ma_Vt"];
                drEditCt["Ten_Vt"] = drDinhMucVt["Ten_Vt"];
                drEditCt["Mo_Ta_Kt"] = drDinhMucVt["Mo_Ta_Kt"];
                drEditCt["Muc_Dich"] = drDinhMucVt["Muc_Dich"];
                
                if (frmCtNX_Edit.strMa_Ct == "PYCTH")
                    drEditCt["Sl_CL_DmTh"] = drDinhMucVt["So_Luong_DmTh"];

				drEditCt["Dvt"] = drDinhMucVt["Dvt"];
                drEditCt["So_Luong9"] = drEditCt["So_Luong"] = drEditCt["So_Luong0"] = drEditCt["So_Luong_Tp"] = drEditCt["So_Luong_KtCdAt"] = drEditCt["So_Luong_KhVt"] = drDinhMucVt["So_Luong"];
				drEditCt["He_So9"] = 1;
				
				frmCtNX_Edit.dtEditCt.Rows.Add(drEditCt);
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

        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;

            }
            else
            {
                txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
                lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
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
	}
}