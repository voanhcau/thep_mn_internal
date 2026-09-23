using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Library;
using RosySystem.Public;
using RosyList;

namespace RosyModule
{
	public partial class frmFilter : RosySystem.Customize.frmEdit
	{
		public frmFilter()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtTk.Validating += new CancelEventHandler(txtTk_Validating);
			txtTk_Du.Validating += new CancelEventHandler(txtTk_Du_Validating);
			txtMa_Thue.Validating += new CancelEventHandler(txtMa_Thue_Validating);
			txtMa_Hd.Validating += new CancelEventHandler(txtMa_Hd_Validating);
			txtMa_Dt.Validating += new CancelEventHandler(txtMa_Dt_Validating);
			txtMa_Km.Validating += new CancelEventHandler(txtMa_Km_Validating);
			txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);
			txtMa_Nvu.Validating += new CancelEventHandler(txtMa_Nx_Validating);
			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
			txtMa_Job.Validating += new CancelEventHandler(txtMa_Job_Validating);
			txtMa_Kv.Validating += new CancelEventHandler(txtMa_Kv_Validating);
            txtMa_Tb.Validating += new CancelEventHandler(txtMa_Tb_Validating);
		}

      

		public new void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.Tag = "FILTER";
			this.txtMa_Tte.InputMask = "," + (string)Parameters.GetParaValue("MA_TTE_LIST");

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			//txtTk
			if (txtTk.Text.Trim() != string.Empty)
			{
				lbtTen_Tk.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk.Text.Trim());
			}
			else
				lbtTen_Tk.Text = string.Empty;

			//txtTk_Du
			if (txtTk_Du.Text.Trim() != string.Empty)
			{
				lbtTen_Tk_Du.Text = DataTool.SQLGetNameByCode("R81DmTk", "Tk", "Ten_Tk", txtTk_Du.Text.Trim());
			}
			else
				lbtTen_Tk_Du.Text = string.Empty;

			//txtMa_Hd
			if (txtMa_Hd.Text.Trim() != string.Empty)
			{
				lbtTen_Hd.Text = DataTool.SQLGetNameByCode("R81DmHd", "Ma_Hd", "Ten_Hd", txtMa_Hd.Text.Trim());
			}
			else
				lbtTen_Hd.Text = string.Empty;

			//txtMa_Dt
			if (txtMa_Dt.Text.Trim() != string.Empty)
			{
				lbtTen_Dt.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt.Text.Trim());
			}
			else
				lbtTen_Dt.Text = string.Empty;

			//txtMa_Km
			if (txtMa_Km.Text.Trim() != string.Empty)
			{
				lbtTen_Km.Text = DataTool.SQLGetNameByCode("R81DmKm", "Ma_Km", "Ten_Km", txtMa_Km.Text.Trim());
			}
			else
				lbtTen_Km.Text = string.Empty;

			//txtMa_Bp
			if (txtMa_Bp.Text.Trim() != string.Empty)
			{
				lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DmBp", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
			}
			else
				lbtTen_Bp.Text = string.Empty;

			//txtMa_Vt_Sp
			if (txtMa_Vt_Sp.Text.Trim() != string.Empty)
			{
				lbtTen_Vt_Sp.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp.Text.Trim());
			}
			else
				lbtTen_Vt_Sp.Text = string.Empty;

			//txtMa_Nx
			if (txtMa_Nvu.Text.Trim() != string.Empty)
			{
				lbtTen_Nvu.Text = DataTool.SQLGetNameByCode("R81DmNx", "Ma_Nx", "Ten_Nx", txtMa_Nvu.Text.Trim());
			}
			else
				lbtTen_Nvu.Text = string.Empty;

			//txtMa_Thue
			if (txtMa_Thue.Text.Trim() != string.Empty)
			{
				lbtTen_Thue.Text = DataTool.SQLGetNameByCode("R81DmThue", "Ma_Thue", "Ten_Thue", txtMa_Thue.Text.Trim());
			}
			else
				lbtTen_Thue.Text = string.Empty;

			//txtMa_Kho
			if (txtMa_Kho.Text.Trim() != string.Empty)
			{
				lbtTen_Kho.Text = DataTool.SQLGetNameByCode("R81DmKho", "Ma_Kho", "Ten_Kho", txtMa_Kho.Text.Trim());
			}
			else
				lbtTen_Kho.Text = string.Empty;

			//txtMa_Vt
			if (txtMa_Vt.Text.Trim() != string.Empty)
			{
				lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
			}
			else
				lbtTen_Vt.Text = string.Empty;

			//txtMa_Dt_CbNv
			if (txtMa_Dt_CbNv.Text.Trim() != string.Empty)
			{
				lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DmDt", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			}
			else
				lbtTen_Dt_CbNv.Text = string.Empty;

			//txtMa_Job
			if (txtMa_Job.Text.Trim() != string.Empty)
			{
				lbtTen_Job.Text = DataTool.SQLGetNameByCode("R81DmJob", "Ma_Job", "Ten_Job", txtMa_Job.Text.Trim());
			}
			else
				lbtTen_Job.Text = string.Empty;

			//txtMa_Kv
			if (txtMa_Kv.Text.Trim() != string.Empty)
			{
				lbtTen_Kv.Text = DataTool.SQLGetNameByCode("R81DmKv", "Ma_Kv", "Ten_Kv", txtMa_Kv.Text.Trim());
			}
			else
				lbtTen_Kv.Text = string.Empty;

            //txtMa_Tb
            if (txtMa_Tb.Text.Trim() != string.Empty)
            {
                lbtTen_Tb.Text = DataTool.SQLGetNameByCode("R06DMTB", "Ma_Tb", "Ten_Tb", txtMa_Tb.Text.Trim());
            }
            else
                lbtTen_Tb.Text = string.Empty;
		}

		private void btAccept_Click(object sender, EventArgs e)
		{
			Common.GatherMemvar(this, ref drEdit);
			
			isAccept = true;
			this.Close();

		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		void txtTk_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk.Text = string.Empty;
				lbtTen_Tk.Text = string.Empty;
			}
			else
			{
				txtTk.Text = drLookup["Tk"].ToString();
				lbtTen_Tk.Text = drLookup["Ten_Tk"].ToString();
			}
		}
		void txtTk_Du_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtTk_Du.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Tk", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtTk_Du.Text = string.Empty;
				lbtTen_Tk_Du.Text = string.Empty;
			}
			else
			{
				txtTk_Du.Text = drLookup["Tk"].ToString();
				lbtTen_Tk_Du.Text = drLookup["Ten_Tk"].ToString();
			}
		}
		void txtMa_Hd_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Hd.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Hd", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Hd.Text = string.Empty;
				lbtTen_Hd.Text = string.Empty;
			}
			else
			{
				txtMa_Hd.Text = drLookup["Ma_Hd"].ToString();
				lbtTen_Hd.Text = drLookup["Ten_Hd"].ToString();
			}
		}
		void txtMa_Dt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt.Text = string.Empty;
				lbtTen_Dt.Text = string.Empty;
			}
			else
			{
				txtMa_Dt.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt.Text = drLookup["Ten_Dt"].ToString();				
			}
		}
		void txtMa_Km_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Km.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Km", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Km.Text = string.Empty;
				lbtTen_Km.Text = string.Empty;
			}
			else
			{
				txtMa_Km.Text = drLookup["Ma_Km"].ToString();
				lbtTen_Km.Text = drLookup["Ten_Km"].ToString();
			}
		}
		void txtMa_Bp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Bp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "Nh_Cuoi = 1");

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
		void txtMa_Vt_Sp_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp.Text = string.Empty;
				lbtTen_Vt_Sp.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt_Sp.Text = drLookup["Ten_Vt"].ToString();
			}
		}
		void txtMa_Nx_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nvu.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nvu", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nvu.Text = string.Empty;
				lbtTen_Nvu.Text = string.Empty;
			}
			else
			{
				txtMa_Nvu.Text = drLookup["Ma_Nvu"].ToString();
				lbtTen_Nvu.Text = drLookup["Ten_Nvu"].ToString();
			}
		}
		void txtMa_Thue_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Thue.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Thue", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Thue.Text = string.Empty;
				lbtTen_Thue.Text = string.Empty;
			}
			else
			{
				txtMa_Thue.Text = drLookup["Ma_Thue"].ToString();
				lbtTen_Thue.Text = drLookup["Ten_Thue"].ToString();
			}
		}
		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho.Text = string.Empty;
				lbtTen_Kho.Text = string.Empty;
			}
			else
			{
				txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
				lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
			}
		}
		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "");

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
		void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv.Text = string.Empty;
				lbtTen_Dt_CbNv.Text = string.Empty;
			}
			else
			{
				txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
			}
		}
		void txtMa_Job_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Job.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Job", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Job.Text = string.Empty;
				lbtTen_Job.Text = string.Empty;
			}
			else
			{
				txtMa_Job.Text = drLookup["Ma_Job"].ToString();
				lbtTen_Job.Text = drLookup["Ten_Job"].ToString();
			}
		}
        void txtMa_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Tb.Text.Trim();
            bool brequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Tb", strValue, brequire, string.Empty);

            if (brequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Tb.Text = string.Empty;
                lbtTen_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Tb.Text = (string)drLookup["Ma_Tb"];
                lbtTen_Tb.Text = (string)drLookup["Ten_Tb"];
               
            }
        }
		void txtMa_Kv_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kv.Text = string.Empty;
				lbtTen_Kv.Text = string.Empty;
			}
			else
			{
				txtMa_Kv.Text = drLookup["Ma_Kv"].ToString();
				lbtTen_Kv.Text = drLookup["Ten_Kv"].ToString();
			}
		}

        //private void frmFilter_Load(object sender, EventArgs e)
        //{

        //}
	}
}
