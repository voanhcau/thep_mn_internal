using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Public;

namespace RosyPhuTung
{
	public partial class frmFilterBarcodePt : RosySystem.Customize.frmEdit
	{
        public frmFilterBarcodePt()
        {
            InitializeComponent();

            this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
            this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            //this.txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
        }

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;

            this.FillData();

			Common.ScaterMemvar(this, ref drEdit);
			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
				
		}

        private void FillData()
        {
            //Danh mục sản phẩm
            DataTable dtDmVtSp = DataTool.SQLGetDataTable("R81DMVT", "", "Ma_Nh_Vt = 'THEPCAY'", "Ma_Vt");
            cboMa_Vt.DataSource = dtDmVtSp;
            cboMa_Vt.DisplayMember = "TEN_VT";
            cboMa_Vt.ValueMember = "MA_VT";
            cboMa_Vt.SelectedValue = drEdit["Ma_Vt"] == DBNull.Value ? string.Empty : (string)drEdit["Ma_Vt"];

            //Danh mục tiêu chuẩn
            DataTable dtDmStandard = DataTool.SQLGetDataTable("R81DMSTANDARD", "", "", "Standard_ID");
            cboStandard_ID.DataSource = dtDmStandard;
            cboStandard_ID.DisplayMember = "STANDARD_NAME";
            cboStandard_ID.ValueMember = "STANDARD_ID";
            cboStandard_ID.SelectedValue = drEdit["Standard_ID"] == DBNull.Value ? string.Empty : (string)drEdit["Standard_ID"];

            //Danh mục mác thép
            DataTable dtDmMacThep = DataTool.SQLGetDataTable("R81DMMACTHEP", "", "", "Grade_ID");
            cboGrade_ID.DataSource = dtDmMacThep;
            cboGrade_ID.DisplayMember = "Grade_Name";
            cboGrade_ID.ValueMember = "Grade_ID";
            cboGrade_ID.SelectedValue = drEdit["Grade_ID"] == DBNull.Value ? string.Empty : (string)drEdit["Grade_ID"];

            //Danh mục Lots
            DataTable dtDmLots = DataTool.SQLGetDataTable("R81DMLOTS", "", "", "Lot_ID");
            cboLot_ID.DataSource = dtDmLots;
            cboLot_ID.DisplayMember = "Lot_Name";
            cboLot_ID.ValueMember = "Lot_ID";
            cboLot_ID.SelectedValue = drEdit["Lot_ID"] == DBNull.Value ? string.Empty : (string)drEdit["Lot_ID"];

            //Chất lượng
            DataTable dtDmCL = DataTool.SQLGetDataTable("R81DMCL", "", "", "Ma_CL");
            cboMa_CL.DataSource = dtDmCL;
            cboMa_CL.DisplayMember = "Ten_CL";
            cboMa_CL.ValueMember = "Ma_CL";
            cboMa_CL.SelectedValue = drEdit["Ma_CL"] == DBNull.Value ? string.Empty : (string)drEdit["Ma_CL"];
        }

        private void LoadDicName()
        {
            //txtMa_Vt
            //if (txtMa_Vt.Text.Trim() != string.Empty)
            //{
            //    lbtTen_Vt.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt.Text.Trim());
            //}
            //else
            //    lbtTen_Vt.Text = string.Empty;
        }

        //void txtMa_Vt_Validating(object sender, CancelEventArgs e)
        //{
        //    string strValue = txtMa_Vt.Text.Trim();
        //    bool bRequire = false;

        //    DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "");

        //    if (bRequire && drLookup == null)
        //        e.Cancel = true;

        //    if (drLookup == null)
        //    {
        //        txtMa_Vt.Text = string.Empty;
        //        lbtTen_Vt.Text = string.Empty;
        //    }
        //    else
        //    {
        //        txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
        //        lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
        //    }
        //}

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
	}
}
