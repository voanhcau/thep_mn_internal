using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Control;

using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Customize;
using RosyModule;
using RosySystem.Data;
using RosySystem.Public;

namespace RosyModule.Payable
{
	public partial class frmPbCp_Dkl : RosySystem.Customize.frmEdit
	{
		frmVoucher_Edit frmEditCtNM;

		public frmPbCp_Dkl()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Ct.Validating += new CancelEventHandler(txtMa_Ct_Validating);
			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
			txtMa_Nh_Vt.Validating += new CancelEventHandler(txtMa_Nh_Vt_Validating);
			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
		}

		public new void Load(frmVoucher_Edit frmEditCtNM)
		{
			this.frmEditCtNM = frmEditCtNM;
			this.dteNgay_Ct1.Text = Library.DateToStr((DateTime)frmEditCtNM.drEditPh["Ngay_Ct"]);
			this.dteNgay_Ct2.Text = this.dteNgay_Ct1.Text;

			this.BindingLanguage();

			this.ShowDialog();
		}

		void XemPhieuNhap()
		{
			double dbTien_Pb_Nt = numTien_Pb_Nt.Value;
			string strLoai_Pb = txtLoai_Pb.Text;

			string strMa_Ct = txtMa_Ct.Text.Trim();
			string strKey = "(0 = 0) ";// = TRUE

			if (!(txtMa_Ct.Text.Trim() == string.Empty))
				strKey += " AND (Ma_Ct = '" + txtMa_Ct.Text.Trim() + "')";

			if (!dteNgay_Ct1.IsNull)
				strKey += " AND (Ngay_Ct >= '" + dteNgay_Ct1.Text.Trim() + "')";

			if (!dteNgay_Ct2.IsNull)
				strKey += " AND (Ngay_Ct <= '" + dteNgay_Ct2.Text.Trim() + "')";

			if (!(txtSo_Ct1.Text.Trim() == string.Empty))
				strKey += " AND (So_Ct >= '" + txtSo_Ct1.Text.Trim() + "')";

			if (!(txtSo_Ct2.Text.Trim() == string.Empty))
				strKey += " AND (So_Ct <= '" + txtSo_Ct2.Text.Trim() + "')";
			
			//Chua xu ly theo Ma_KhN
			if (!(txtMa_Kho.Text.Trim() == string.Empty))
				strKey += " AND (Ma_Kho = '" + txtMa_Kho.Text.Trim() + "')";

			if (!(txtMa_Vt.Text.Trim() == string.Empty))
				strKey += " AND (Ma_Vt = '" + txtMa_Vt.Text.Trim() + "')";

			if (!(txtMa_Nh_Vt.Text.Trim() == string.Empty))
				strKey += " AND (Ma_Vt  IN  (SELECT Ma_Vt FROM R81DMVT WHERE Ma_Nh_Vt = '" + txtMa_Nh_Vt.Text.Trim() + "'))";

			frmPbCp_View frm = new frmPbCp_View();
			frm.Load(frmEditCtNM, strMa_Ct, strKey, numTien_Pb_Nt.Value, txtLoai_Pb.Text.Trim());
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			XemPhieuNhap();

			isAccept = true;
			this.Close();
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		void txtMa_Ct_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Ct.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Ct", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Ct.Text = string.Empty;
				lbtMa_Ct.Text = string.Empty;
			}
			else
			{
				txtMa_Ct.Text = drLookup["Ma_Ct"].ToString();
				lbtMa_Ct.Text = drLookup["Ten_Ct"].ToString();
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
		void txtMa_Nh_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Nh_Vt.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Nh_Vt", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Nh_Vt.Text = string.Empty;
				lbtTen_Nh_Vt.Text = string.Empty;
			}
			else
			{
				txtMa_Nh_Vt.Text = drLookup["Ma_Nh_Vt"].ToString();
				lbtTen_Nh_Vt.Text = drLookup["Ten_Nh_Vt"].ToString();
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
	}	 
}
