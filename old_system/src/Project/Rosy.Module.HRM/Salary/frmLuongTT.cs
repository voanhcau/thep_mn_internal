using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Element;
using RosyList;
using System.Data.SqlClient;
using RosyModule.HRM;

namespace RosyModule.Salary
{
	public partial class frmLuongTT : RosySystem.Customize.frmView
	{
        string strMa_Bp;
		private DataTable dtBangLuong;
		private DataTable dtDmTn;

		private BindingSource bdsBangLuong = new BindingSource();
		private DataRow drCurrent;
		private rsDataGridView dgvBangLuong = new rsDataGridView();

        DataTable dtDmBp;
        DataTable dtDmBpCt;
        DataSet dsBp;

        public frmLuongTT()
		{
			InitializeComponent();
            			
			cboMa_Bp.TextChanged += new EventHandler(cboMa_Bp_TextChanged);
            btThem.Click += new EventHandler(btThem_Click);
            btSua.Click += new EventHandler(btSua_Click);
            btSL_NV.Click += new EventHandler(btSL_NV_Click);
            btDuyet.Click += new EventHandler(btDuyet_Click);

            dgvBangLuong.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvBangLuong_CellMouseClick);
		}

        void dgvBangLuong_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsBangLuong.Current).Row;

            frmLuongTTCT frm = new frmLuongTTCT();
            frm.Load(drCurrent["Ma_Dt_CbNv"].ToString());
            if (Common.CheckPermission("IS_TP_TCHC", enuPermission_Type.Allow_Access) || Common.CheckPermission("IS_PTP_TCHC", enuPermission_Type.Allow_Access))
            {
                string strColumnName = dgvBangLuong.Columns[e.ColumnIndex].Name;
                if (strColumnName.StartsWith("DUYET_TCHC"))
                {
                    drCurrent = ((DataRowView)bdsBangLuong.Current).Row;
                    if (Convert.ToBoolean(drCurrent[strColumnName]) == true)
                    {


                        Hashtable ht = new Hashtable();
                        ht.Add("DUYET_TCHC", !(bool)drCurrent[strColumnName]);
                        ht.Add("IDENT00", drCurrent["Ident00"]);
                        string strUpdate = "UPDATE R09LUONGTT SET " + strColumnName + " = @Duyet_TCHC WHERE Ident00 = @Ident00";

                        SQLExec.Execute(strUpdate, ht, CommandType.Text);

                        drCurrent[strColumnName] = !(bool)drCurrent[strColumnName];
                    }
                }
            }
        }

       



       

		public override void Load()
		{
            //đưa giá trị vào combo
            Voucher.LoadComboBp((rsMultiComboBox)cboMa_Bp, (rsMultiComboBox)cboMa_Bp_Ct);

          
            // Gán giá trị cho ma bp
            string strMa_Bp = Voucher.GetBpOfUser();
            if ((!Common.Inlist(strMa_Bp, "NQL,PTCHC") && !Element.sysIs_Admin))
            {
                cboMa_Bp.Text = strMa_Bp;
                cboMa_Bp.Enabled = false;
            }
            else if (Element.sysIs_Admin)
                cboMa_Bp.Text = "PCNTT";
            else if (Common.Inlist(strMa_Bp, "NQL,PTCHC"))
            {
                cboMa_Bp.Text = "PTCHC";
                cboMa_Bp.Enabled = true;
            }

			this.Build();
			this.FillData();
			this.BindingLanguage();

	

			this.Show();
		}

		#region Methods

		private void Build()
		{
			//Build
			dgvBangLuong.strZone = "LUONGTT";
			dgvBangLuong.Dock = DockStyle.Fill;
			dgvBangLuong.BuildGridView();
			dgvBangLuong.Columns["Ma_Dt_CbNv"].Frozen = true;
			dgvBangLuong.Columns["Ten_Dt_CbNv"].Frozen = true;

			this.panel1.Controls.Add(dgvBangLuong);
		}

		private void FillData()
		{

			//Lấy nội dung bảng lương
			Hashtable htPara = new Hashtable();
			
			
			htPara.Add("MA_BP", cboMa_Bp.Text);
            htPara.Add("MA_DT_CBNV", "");
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);            

			dtBangLuong = SQLExec.ExecuteReturnDt("sp_HRM_GetLuongTT", htPara, CommandType.StoredProcedure);

			bdsBangLuong.DataSource = dtBangLuong;
			dgvBangLuong.DataSource = bdsBangLuong;

            bdsSearch = bdsBangLuong;
            this.ExportControl = dgvBangLuong;
		}

		

		

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsBangLuong.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

            //if (enuNew_Edit == enuEdit.New)
            //    return;

			if (bdsBangLuong.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsBangLuong.Current).Row, ref drCurrent);
			else
				drCurrent = dtBangLuong.NewRow();

            frmLuongTT_Edit frmEdit = new frmLuongTT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, cboMa_Bp.Text);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsBangLuong.Position >= 0)
                        dtBangLuong.ImportRow(drCurrent);
                    else
                        dtBangLuong.Rows.Add(drCurrent);

                    bdsBangLuong.Position = bdsBangLuong.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsBangLuong.Current).Row);
                }

                dtBangLuong.AcceptChanges();

                FillData();
                bdsBangLuong.Position = bdsBangLuong.Find("Ident00", drCurrent["Ident00"]);
            }
		}

		

		#endregion

		#region Event
        void btSL_NV_Click(object sender, EventArgs e)
        {
            frmDGBPCT frm = new frmDGBPCT();
            frm.show(cboMa_Bp.Text,2021,1);
        }
        void btDuyet_Click(object sender, EventArgs e)
        {
            frmDuyet_PTCHC frm = new frmDuyet_PTCHC();
            frm.Load();
        }
        void btSua_Click(object sender, EventArgs e)
        {
            Edit(enuEdit.Edit);
        }

        void btThem_Click(object sender, EventArgs e)
        {
            Edit(enuEdit.New);
        }

		void cboMa_Bp_TextChanged(object sender, EventArgs e)
		{
			if (cboMa_Bp.lviItem != null)
				lbtTen_Bp.Text = cboMa_Bp.lviItem.SubItems["Ten_Bp"].Text;

			if (cboMa_Bp.Text == string.Empty)
				return;

			this.FillData();
		}

		

		

		#endregion

        //private void btSL_NV_Click_1(object sender, EventArgs e)
        //{

        //}
	}
}
