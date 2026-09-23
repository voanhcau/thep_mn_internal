using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Library;
using System.Collections;

namespace RosyModule.Inventory
{
	public partial class frmKCS_View : RosySystem.Customize.frmView
	{
		BindingSource bdsKCS = new BindingSource();
		DataTable dtKCS;
		DataRow drCurrent;
		string strFilter_Update = "N";

		public frmKCS_View()
		{
			InitializeComponent();
			this.btFilter.Click += new EventHandler(btFilter_Click);
			this.btEdit_CoTinh.Click += new EventHandler(btEdit_CoTinh_Click);
			this.rdbFilter_Edit1.CheckedChanged += new EventHandler(rdbFilter_Edit_CheckedChanged);
			this.rdbFilter_Edit2.CheckedChanged += new EventHandler(rdbFilter_Edit_CheckedChanged);
			this.rdbFilter_Edit3.CheckedChanged += new EventHandler(rdbFilter_Edit_CheckedChanged);
		}

		void rdbFilter_Edit_CheckedChanged(object sender, EventArgs e)
		{
			if (rdbFilter_Edit1.Checked)
				strFilter_Update = "N";
			else if(rdbFilter_Edit2.Checked)
				strFilter_Update = "E";
			else
				strFilter_Update = "A";
		}

		public void Load()
		{
			dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
			dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);

			this.Build();
			this.BindingLanguage();
			this.Show();
		}

		private void Build()
		{
			dgvKCS.strZone = "KCS";
			dgvKCS.BuildGridView();

			//Danh mục sản phẩm
			DataTable dtDmVt = DataTool.SQLGetDataTable("R81DMVT", "", "Ma_Nh_Vt = 'THEPCAY'", "Ma_Vt");
			
			DataRow drDmVt_Empty = dtDmVt.NewRow();
			drDmVt_Empty["Ma_Vt"] = drDmVt_Empty["Ten_Vt"] = string.Empty;
			dtDmVt.Rows.Add(drDmVt_Empty);

			cboMa_Vt.DataSource = dtDmVt;
			cboMa_Vt.DisplayMember = "TEN_VT";
			cboMa_Vt.ValueMember = "MA_VT";

			//Danh mục mác thép
			DataTable dtDmMacThep = DataTool.SQLGetDataTable("R81DMMACTHEP", "", "", "Grade_ID");

			DataRow drDmMacThep_Empty = dtDmMacThep.NewRow();
			drDmMacThep_Empty["Grade_Name"] = drDmMacThep_Empty["Grade_ID"] = string.Empty;
			dtDmMacThep.Rows.Add(drDmMacThep_Empty);

			cboGrade_ID.DataSource = dtDmMacThep;
			cboGrade_ID.DisplayMember = "Grade_Name";
			cboGrade_ID.ValueMember = "Grade_ID";

			//Chất lượng
			DataTable dtDmCL = DataTool.SQLGetDataTable("R81DMCL", "", "", "Ma_CL");

			DataRow drDmCL_Empty = dtDmCL.NewRow();
			drDmCL_Empty["Ma_CL"] = drDmCL_Empty["Ten_CL"] = string.Empty;
			dtDmCL.Rows.Add(drDmCL_Empty);
			
			cboMa_CL.DataSource = dtDmCL;
			cboMa_CL.DisplayMember = "Ten_CL";
			cboMa_CL.ValueMember = "Ma_CL";

			cboMa_Vt.SelectedValue = cboGrade_ID.SelectedValue = cboMa_CL.SelectedValue = string.Empty;

			this.dgvKCS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKCS.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
			
			if (this.dgvKCS.Columns.Contains("Kich_Thuoc"))
				this.dgvKCS.Columns["Kich_Thuoc"].Frozen = true;

			if (this.dgvKCS.Columns.Contains("Remark"))
				this.dgvKCS.Columns["Remark"].HeaderText= "Điểm KPH";

			if (dgvKCS.Columns.Contains("SO_LUONG"))
				dgvKCS.Columns["SO_LUONG"].HeaderText = "Khối lượng";
		}

		private void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT1", dteNgay_Ct1.Text);
			htPara.Add("NGAY_CT2", dteNgay_Ct2.Text);
			htPara.Add("BARCODE1", txtBarcode1.Text.Trim());
			htPara.Add("BARCODE2", txtBarcode2.Text.Trim());
			htPara.Add("MA_VT", cboMa_Vt.SelectedValue);
			htPara.Add("GRADE_ID", cboGrade_ID.SelectedValue);
			htPara.Add("MA_CL", cboMa_CL.SelectedValue);
			htPara.Add("NUM_LOT", txtNum_Lot.Text.Trim());
			htPara.Add("CA", cboCa.SelectedItem);
			htPara.Add("FILTER_UPDATE", strFilter_Update); //Lọc để nhập hoặc nhập để sửa
			htPara.Add("MA_DATA", Element.sysMa_Data);

			dtKCS = SQLExec.ExecuteReturnDt("sp_GetDmBarcode_To_KCS", htPara, CommandType.StoredProcedure);
			bdsKCS.DataSource = dtKCS;
			dgvKCS.DataSource = bdsKCS;
			bdsKCS.Position = 0;

			bdsSearch = bdsKCS;
			ExportControl = dgvKCS;
		}

		void btEdit_CoTinh_Click(object sender, EventArgs e)
		{
			DataTable dtFilter = new DataTable();
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Barcode1", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Barcode2", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Vt", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Grade_ID", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Cl", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Num_Lot", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ca", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();
			drFilter["Ngay_Ct1"] = dteNgay_Ct1.Text;
			drFilter["Ngay_Ct2"] = dteNgay_Ct2.Text;
			drFilter["Barcode1"] = txtBarcode1.Text;
			drFilter["Barcode2"] = txtBarcode2.Text;
			drFilter["Ma_Vt"] = cboMa_Vt.SelectedValue;
			drFilter["Grade_ID"] = cboMa_CL.SelectedValue;
			drFilter["Ma_Cl"] = cboMa_CL.SelectedValue;
			drFilter["Num_Lot"] = txtNum_Lot.Text.Trim();
			drFilter["Ca"] = cboCa.SelectedItem;

			frmKCS_Edit frm = new frmKCS_Edit();
			frm.Load(dtKCS, drFilter);

			if (frm.isAccept || !frm.isAccept)
			{
				this.FillData();
			}
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			Element.sysNgay_Ct1 = Library.StrToDate(dteNgay_Ct1.Text);
			Element.sysNgay_Ct2 = Library.StrToDate(dteNgay_Ct2.Text);

			this.FillData();
		}

	}
}
