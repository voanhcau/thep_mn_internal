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

namespace RosyModule.Machinery
{
    public partial class frmKHBTSC_Edit : RosySystem.Customize.frmEdit
    {
        public frmKHBTSC_Edit()
        {
            InitializeComponent();
            txtMa_Vt_Tb.Validating += new CancelEventHandler(txtMa_Vt_Tb_Validating);
			txtMa_Vt_Tb_Kt.Validating += new CancelEventHandler(txtMa_Vt_Tb_Kt_Validating);
            btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            txtMa_Dt_Cbnv.Validating += new CancelEventHandler(txtMa_Dt_Cbnv_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
        }

		void txtMa_Vt_Tb_Kt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Tb_Kt.Text.Trim();
			bool brequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, brequire, "Ma_Vt IN (SELECT Ma_Vt_Tb_Kt FROM R06PTKT WHERE Ma_Vt_Tb LIKE '" + txtMa_Vt_Tb.Text.Trim() + "')");

			if (drLookup == null && brequire)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Tb_Kt.Text = string.Empty;
				lbtTen_Vt_Tb_Kt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Tb_Kt.Text = (string)drLookup["Ma_Vt"];
				lbtTen_Vt_Tb_Kt.Text = (string)drLookup["Ten_Vt"];
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

        void txtMa_Dt_Cbnv_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Dt_Cbnv.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Dt_Cbnv", strValue, bRequire, null);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Dt_Cbnv.Text = string.Empty;
                lbtTen_Dt_Cbnv.Text = string.Empty;
            }
            else
            {
                txtMa_Dt_Cbnv.Text = (string)drLookup["Ma_Dt"];
                lbtTen_Dt_Cbnv.Text = (string)drLookup["Ten_Dt"];
            }

        }

        void txtMa_Vt_Tb_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Vt_Tb.Text.Trim();
            bool bRequire = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, string.Empty);

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Vt_Tb.Text = string.Empty;
                lbtTen_Vt_Tb.Text = string.Empty;
            }
            else
            {
                txtMa_Vt_Tb.Text = (string)drLookup["Ma_Vt"];
                lbtTen_Vt_Tb.Text = (string)drLookup["Ten_Vt"];
            }
        }

        public void load(enuEdit enuNew_Edit, DataRow drEdit)
        {
            this.enuNew_Edit = enuNew_Edit;
            this.drEdit = drEdit;
            this.Tag = (char)enuNew_Edit + "," + this.Tag;

			cboNoi_Dung.DataSource = SQLExec.ExecuteReturnDt("SELECT DISTINCT Noi_Dung FROM R06KHBTSC");

			cboNoi_Dung.DisplayMember = "Noi_Dung";
			cboNoi_Dung.ValueMember = "Noi_Dung";

            Common.ScaterMemvar(this, ref drEdit);

            BindingLanguage();
            LoadDicName();

            this.ShowDialog();
        }

        private bool FormCheckValid()
        {
			if (txtMa_Vt_Tb.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt_Tb") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (cboNoi_Dung.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Noi_Dung") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Dt_Cbnv.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Dt_Cbnv") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

			if (txtMa_Bp.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Bp") + " " + Languages.GetLanguage("Not_Null"));
				return false;
			}

            return true;
        }

        private bool Save()
        {
            Common.GatherMemvar(this, ref drEdit);

            if (!FormCheckValid())
                return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();
			
			if (drEdit.Table.Columns.Contains("Loai_Ke_Hoach"))
				drEdit["Loai_Ke_Hoach"] = "Bảo dưỡng";

            if (!DataTool.SQLUpdate(enuNew_Edit, "R06KHBTSC", ref drEdit))
                return false;

            return true;   
        }

        private void LoadDicName()
        {
            if (txtMa_Vt_Tb.Text.Trim() != string.Empty)
                lbtTen_Vt_Tb.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Tb.Text.Trim());
            else
                lbtTen_Vt_Tb.Text = string.Empty;

			if (txtMa_Vt_Tb_Kt.Text.Trim() != string.Empty)
				lbtTen_Vt_Tb_Kt.Text = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", txtMa_Vt_Tb_Kt.Text.Trim());
			else
				lbtTen_Vt_Tb_Kt.Text = string.Empty;

            if (txtMa_Dt_Cbnv.Text.Trim() != string.Empty)
            {
                lbtTen_Dt_Cbnv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_Cbnv.Text.Trim());
            }
            else
                lbtTen_Dt_Cbnv.Text = string.Empty;

            if (txtMa_Bp.Text.Trim() != string.Empty)
            {
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text.Trim());
            }
            else
                lbtTen_Bp.Text = string.Empty;
        }

        void btCancel_Click(object sender, EventArgs e)
        {
            this.isAccept = false;
            this.Close();
        }

        void btAccept_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                this.isAccept = true;
                this.Close();
            }
        }
    }
}
