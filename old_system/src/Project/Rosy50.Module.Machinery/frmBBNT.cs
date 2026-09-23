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
using RosySystem.Library;
using RosySystem.Public;
using RosySystem.Common;

namespace RosyModule
{
    public partial class frmBBNT : RosySystem.Customize.frmView
    {
        public DataSet dsVoucher = new DataSet("dsVoucher");

        public DataTable dtViewPh;
        public DataTable dtViewCt;

        public BindingSource bdsViewPh = new BindingSource();
        public BindingSource bdsViewCt = new BindingSource();

        public rsDataGridView dgvViewPh = new rsDataGridView();
        public rsDataGridView dgvViewCt = new rsDataGridView();

        public DataRelation drlView;

        public string strMa_Ct_List = string.Empty;
        public DataRow drCurrent;
        public DataRow drDmCt;

        public frmBBNT()
        {
            InitializeComponent();
        }

        public void Load(string strMa_Ct_List)
        {
            this.strMa_Ct_List = strMa_Ct_List;
            this.Object_ID = strMa_Ct_List;
            this.Tag = "frmCT" + strMa_Ct_List.Split(',')[0];

            this.Build();

            //FillData
            object objNgay_CtMax = SQLExec.ExecuteReturnValue("SELECT MAX(Ngay_Ct) FROM " + (string)drDmCt["Table_Ph"] + " WHERE Ma_Ct LIKE '" + this.strMa_Ct_List.Split(',')[0] + "' AND Ma_DvCs = '" + Element.sysMa_DvCs + "'");
            int iInterval = Convert.ToInt32(Parameters.GetParaValue("DAY_FILTER"));

            DateTime dteNgay_Ct2 = objNgay_CtMax != DBNull.Value ? (DateTime)objNgay_CtMax : DateTime.Now;
            DateTime dteNgay_Ct1 = dteNgay_Ct2.Subtract(new TimeSpan(iInterval, 0, 0, 0));

            DataTable dtFilter = new DataTable();
            dtFilter.Columns.Add(new DataColumn("Ma_Ct_List", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
            dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));

            DataRow drFilter = dtFilter.NewRow();
            drFilter["Ma_Ct_List"] = strMa_Ct_List;
            drFilter["Ngay_Ct1"] = dteNgay_Ct1;
            drFilter["Ngay_Ct2"] = dteNgay_Ct2;

            this.FillData(drFilter);

            this.BindingLanguage();

            this.FormLayout();

            this.Show();
        }

        private void Build()
        {
            string strMa_Ct = strMa_Ct_List.Split(',')[0];

            drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);

            //dgvViewPh 
            dgvViewPh.ReadOnly = true;
            dgvViewPh.strZone = (string)drDmCt["Zone_ViewPh"];

            dgvViewPh.BuildGridView(false);

            if (!dgvViewPh.Columns.Contains("Ma_Tte"))
            {
                dgvViewPh.Columns.Add("Ma_Tte", "Ma_Tte"); //Hải: thêm cột để phân biệt chứng từ Nte, VND
                dgvViewPh.Columns["Ma_Tte"].DataPropertyName = "MA_TTE";
                dgvViewPh.Columns["Ma_Tte"].ValueType = typeof(string);
                dgvViewPh.Columns["Ma_Tte"].Visible = false;
            }

            dgvViewPh.Columns.Add("Mark", "Mark"); //Đánh dấu dòng
            dgvViewPh.Columns["Mark"].DataPropertyName = "MARK";
            dgvViewPh.Columns["Mark"].ValueType = typeof(bool);
            dgvViewPh.Columns["Mark"].Visible = false;

            //dgvViewCt
            dgvViewCt.ReadOnly = true;
            dgvViewCt.strZone = (string)drDmCt["Zone_ViewCt"];

            dgvViewCt.BuildGridView(false);

            //Position
            this.Controls.Add(dgvViewPh);
            this.Controls.Add(dgvViewCt);

            dgvViewPh.TabIndex = 0;
            dgvViewCt.TabIndex = 1;

        }

        private void FillData(DataRow drFilter)
        {
            if (!drFilter.Table.Columns.Contains("Table_PH"))
                drFilter.Table.Columns.Add(new DataColumn("Table_PH", typeof(string)));

            if (!drFilter.Table.Columns.Contains("Table_Ct"))
                drFilter.Table.Columns.Add(new DataColumn("Table_Ct", typeof(string)));

            if (!drFilter.Table.Columns.Contains("Ma_DvCs"))
                drFilter.Table.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));

            drFilter["Table_PH"] = drDmCt["Table_PH"];
            drFilter["Table_Ct"] = drDmCt["Table_Ct"];
            drFilter["Ma_DvCs"] = Element.sysMa_DvCs;

            dsVoucher.Clear();
            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter", drFilter, CommandType.StoredProcedure);

            dtViewPh = dsVoucher.Tables[0];
            dtViewPh.TableName = (string)drDmCt["Table_Ph"];

            dtViewCt = dsVoucher.Tables[1];
            dtViewCt.TableName = (string)drDmCt["Table_Ct"];

            //Thêm tổng tiền ở phía dưới
            if (dtViewCt.Columns.Contains("TTien_Nt") && dtViewCt.Columns.Contains("TTien_Nt3"))
            {
                DataColumn dcNew = new DataColumn("TTIEN", typeof(double));
                dcNew.Expression = "Tien + Tien3";
                dtViewCt.Columns.Add(dcNew);

                dcNew = new DataColumn("TTIEN_NT", typeof(double));
                dcNew.Expression = "Tien_Nt + Tien_Nt3";
                dtViewCt.Columns.Add(dcNew);
            }

            if (!dtViewPh.Columns.Contains("MARK"))
            {
                DataColumn dcMark = new DataColumn("MARK", typeof(bool));
                dcMark.DefaultValue = false;
                dtViewPh.Columns.Add(dcMark);
            }

            bdsViewPh.DataSource = dtViewPh;
            dgvViewPh.DataSource = bdsViewPh;

            bdsViewCt.DataSource = dtViewCt;
            dgvViewCt.DataSource = bdsViewCt;

            //Lay du lieu tu Ct len Ph theo danh sach Carry_Header
            Common.CopyDataColumn(dtViewCt, dtViewPh, (string)drDmCt["Update_Header"]);


            DataRow[] arrdrViewCt;
            DataRow drViewCt;
            foreach (DataRow drViewPh in dtViewPh.Rows)
            {
                string strStt = (string)drViewPh["Stt"];
                arrdrViewCt = dtViewCt.Select("Stt = '" + strStt + "'");

                if (arrdrViewCt.Length > 0)
                    drViewCt = arrdrViewCt[0];
                else
                    continue;

                Common.CopyDataRow(drViewCt, drViewPh, (string)drDmCt["Update_Header"]);
            }

            bdsViewPh.MoveLast();

            this.bdsSearch = bdsViewPh;
            this.ExportControl = dgvViewPh;
        }

        private void FormLayout()
        {
            //dgvViewPh.Location = new Point(3, 3);
            //dgvViewPh.Width = this.Width - 12;
            //dgvViewPh.Height = (int)(0.5 * this.Height);

            //dgvViewCt.Location = new Point(dgvViewPh.Left, dgvViewPh.Bottom);
            //dgvViewCt.Width = this.Width - 12;
            //dgvViewCt.Height = this.Height - dgvViewPh.Height - pnlTTien.Height - 49;

            //dgvViewPh.ResizeGridView();
            //dgvViewCt.ResizeGridView();
        }
    }
}
