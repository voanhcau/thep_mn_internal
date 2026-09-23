using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem;
using RosySystem.Element;
using RosySystem.Public;
using RosySystem.Customize;


namespace RosyModule.ScaleBarcode
{
    public partial class frmDmBarcode : RosySystem.Customize.frmView
	{
		#region Khai bao bien

        public DataTable dtDmBarcode = new DataTable();
		private DataRow drCurrent;
        public DataRow drDmCt;
		private BindingSource bdsDmBarcode = new BindingSource();
		private rsDataGridView dgvBarCode = new rsDataGridView();
        public bool bFind = false;
		#endregion 

		#region Contructor
        public frmDmBarcode()
		{
			InitializeComponent();

			dgvBarCode.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvBarCode_CellMouseDoubleClick);
			dgvBarCode.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvBarCode_CellFormatting);
			dgvBarCode.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvBarCode_DataBindingComplete);
			
			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btExit.Click += new EventHandler(btExit_Click);
            btFilter.Click += new EventHandler(btFilter_Click);
			btRefresh.Click += new EventHandler(btRefresh_Click);
			btImport.Click += new EventHandler(btImport_Click);
		}

        public override void Load()
        {
            Build();
            FillData();
            BindingLanguage();

            if (this.isLookup)
                this.ShowDialog();
            else
                this.Show();
        }

        public override void LoadLookup()
        {
            string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

            if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
            {
                if (this.strLookupValue == "/" || this.strLookupValue == @"\")
                    strWhere = strLookupKeyFilter;
                else
                    strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
            }

            DataTable dtFind = DataTool.SQLGetDataTable("R81BARCODE", null, strWhere, null);

            if (dtFind.Rows.Count > 0)
            {
                strLookupKeyFilter = strWhere;
                bFind = true;
                this.Load();
            }
        }
        
		#endregion

        #region Method

        private void Build()
        {
            dgvBarCode.Dock = DockStyle.Fill;
            dgvBarCode.strZone = "DMBARCODE";
            dgvBarCode.BuildGridView(this.isLookup);

            dgvBarCode.DataSource = bdsDmBarcode;
            this.rsSplitContainer.Panel1.Controls.Add(dgvBarCode);
        }

        private void FillData()
        {
            string strKey = string.Empty;
            
            if (this.isLookup)
                strKey = (this.strLookupKeyFilter == null ? string.Empty : this.strLookupKeyFilter);

            dtDmBarcode = SQLExec.ExecuteReturnDt(@"SELECT * FROM R81DMBARCODE
											WHERE YEAR(Ngay_Nhap) = " + Element.sysWorkingYear);

            bdsDmBarcode.DataSource = dtDmBarcode;
            dgvBarCode.DataSource = bdsDmBarcode;
            bdsDmBarcode.Position = 0;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsDmBarcode;
            ExportControl = dgvBarCode;

            if (this.isLookup)
				this.MoveToLookupValue();
            dgvBarCode.DataSource = bdsDmBarcode;
			if (dgvBarCode.Columns.Contains("CHON"))
                dgvBarCode.Columns["CHON"].Visible = false;
        }

        private void FillData(DataRow drFilter)
        {
            if (!drFilter.Table.Columns.Contains("Ma_Vt"))
                drFilter.Table.Columns.Add(new DataColumn("Ma_Vt", typeof(string)));

            if (!drFilter.Table.Columns.Contains("Standard_ID"))
                drFilter.Table.Columns.Add(new DataColumn("Standard_ID", typeof(string)));

            if (!drFilter.Table.Columns.Contains("Grade_ID"))
                drFilter.Table.Columns.Add(new DataColumn("Grade_ID", typeof(string)));

            if (!drFilter.Table.Columns.Contains("Ma_CL"))
                drFilter.Table.Columns.Add(new DataColumn("Ma_CL", typeof(string)));

            if (!drFilter.Table.Columns.Contains("Lot_ID"))
                drFilter.Table.Columns.Add(new DataColumn("Lot_ID", typeof(string)));

            if (!drFilter.Table.Columns.Contains("Num_Lot"))
                drFilter.Table.Columns.Add(new DataColumn("Num_Lot", typeof(string)));

            if (!drFilter.Table.Columns.Contains("Length"))
                drFilter.Table.Columns.Add(new DataColumn("Length", typeof(string)));

            //if (!drFilter.Table.Columns.Contains("Ngay_Sx"))
            //    drFilter.Table.Columns.Add(new DataColumn("Ngay_Sx", typeof(DateTime)));

            if (!drFilter.Table.Columns.Contains("Ma_Data"))
                drFilter.Table.Columns.Add(new DataColumn("Ma_Data", typeof(string)));

            dtDmBarcode = SQLExec.ExecuteReturnDt("Sp_GetDmBarcode", drFilter, CommandType.StoredProcedure);

            bdsDmBarcode.DataSource = dtDmBarcode;
            bdsDmBarcode.Position = 0;

            bdsSearch = bdsDmBarcode;
            ExportControl = dgvBarCode;

            dgvBarCode.DataSource = bdsDmBarcode;
        }

        private void Filter()
        {
            DataTable dtFilter = new DataTable();

            dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
            dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
            dtFilter.Columns.Add(new DataColumn("Ma_Vt", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Standard_ID", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Grade_ID", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Ma_CL", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Lot_ID", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Num_Lot", typeof(string)));
            dtFilter.Columns.Add(new DataColumn("Length", typeof(string)));
            //dtFilter.Columns.Add(new DataColumn("Ngay_Sx", typeof(DateTime)));
            dtFilter.Columns.Add(new DataColumn("Ma_Data", typeof(string)));

            DataRow drFilter = dtFilter.NewRow();

            //Set Default
            drFilter["Ngay_Ct1"] = Element.sysNgay_Ct1;
            drFilter["Ngay_Ct2"] = Element.sysNgay_Ct2;
            drFilter["Ma_Data"] = Element.sysMa_DvCs;

            frmFilterBarcode frm = new frmFilterBarcode();
            frm.Load(drFilter);

            if (frm.isAccept)
            {
                this.FillData(drFilter);

                Element.sysNgay_Ct1 = Convert.ToDateTime(drFilter["Ngay_Ct1"]);
                Element.sysNgay_Ct2 = Convert.ToDateTime(drFilter["Ngay_Ct2"]);
            }
        }

        private DataRow FilterRefresh()
        {
            DataTable dtFilter = new DataTable();
            dtFilter.Columns.Add(new DataColumn("Ma_Data", typeof(string)));
            DataRow drFilter = dtFilter.NewRow();
            return drFilter;
        }

        private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmBarcode.Rows.Count - 1; i++)
				if (((string)dtDmBarcode.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmBarcode.Position = i;
					break;
				}
		}
		#endregion
        
        #region Update
        public override void Edit(enuEdit enuNew_Edit)
        {
            if (bdsDmBarcode.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsDmBarcode.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDmBarcode.Current).Row, ref drCurrent);
            else
                drCurrent = dtDmBarcode.NewRow();

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            {
                drCurrent["Barcode"] = string.Empty;
                drCurrent["Ma_Vt"] = string.Empty;
                drCurrent["Standard_ID"] = string.Empty;
                drCurrent["Grade_ID"] = string.Empty;
                drCurrent["Ma_CL"] = string.Empty;
                drCurrent["Lot_ID"] = string.Empty;
                drCurrent["Num_Lot"] = string.Empty;
                drCurrent["Num_Bars"] = 0;
                drCurrent["Length"] = 0;
                drCurrent["So_Luong"] = 0;
                drCurrent["So_Luong_Barem"] = 0;
                drCurrent["Ly_Do"] = string.Empty;
                drCurrent["Create_Log"] = string.Empty;
                drCurrent["LastModify_Log"] = string.Empty;
            }

            frmDmBarcode_Edit frmEdit = new frmDmBarcode_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);
            
            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDmBarcode.Position >= 0)
                        dtDmBarcode.ImportRow(drCurrent);
                    else
                        dtDmBarcode.Rows.Add(drCurrent);

                    bdsDmBarcode.Position = bdsDmBarcode.Find("BARCODE", drCurrent["BARCODE"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmBarcode.Current).Row);

                dtDmBarcode.AcceptChanges();
            }
            else
                dtDmBarcode.RejectChanges();
        }

        public override void Delete()
        {
            if (bdsDmBarcode.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsDmBarcode.Current).Row;
            string strBarcode = drCurrent["Barcode"].ToString();

            if (DataTool.SQLCheckExist("R05CTN_BARCODE", "Barcode", strBarcode) || DataTool.SQLCheckExist("R05CTX_BARCODE", "Barcode", strBarcode))
            {
                Common.MsgCancel("Mã vạch được nhập hoặc xuất trong phiếu.\r\nKhông xóa được!");
                return;
            }

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE"),"N"))
                return;

            if (DataTool.SQLDelete("R81DMBARCODE", drCurrent))
            {
                bdsDmBarcode.RemoveAt(bdsDmBarcode.Position);
                dtDmBarcode.AcceptChanges();
            }
        }
        #endregion 
        
        #region EnterProcess
        private bool EnterValid()
        {
            if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
                return true;

            if (bdsDmBarcode == null || bdsDmBarcode.Position < 0)
                return false;

            drCurrent = ((DataRowView)bdsDmBarcode.Current).Row;
            DataTable dtTemp = dtDmBarcode.Clone();
            dtTemp.ImportRow(drCurrent);

            if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
                return true;
            else
                return false;
        }

        public override void EnterProcess()
        {
            if (bdsDmBarcode.Position < 0)
                return;

            if (isLookup && EnterValid())
            {
                drLookup = ((DataRowView)bdsDmBarcode.Current).Row;
                this.Close();
            }
        }

		#endregion

        #region Event

        void btNew_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.New);
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.Edit);
        }

        void btDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        void btRefresh_Click(object sender, EventArgs e)
        {
            DataRow drFilter = FilterRefresh();
            this.FillData();
            return;
        }

        void btImport_Click(object sender, EventArgs e)
        {
            RosySystem.Public.Public.ImportExcel("DMBARCODE", dtDmBarcode);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.F5:
                    switch (e.Modifiers)
                    {
                        case Keys.Control:
                            DataRow drFilter = FilterRefresh();
                            this.FillData();
                            return;
                    }
                    break;

                case Keys.F9:
                    Filter();
                    break;
            }
            base.OnKeyDown(e);
        }

        void dgvBarCode_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
                return;

            if (e.RowIndex < 0)
                return;
        }

        void dgvBarCode_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string strColumn_Name = dgvBarCode.Columns[e.ColumnIndex].Name.ToUpper();
            drCurrent = ((DataRowView)bdsDmBarcode.Current).Row;

            if (this.isLookup)
                this.EnterProcess();

        }

        void dgvBarCode_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dtDmBarcode.DefaultView.Count > 0)
            {
                DataTable dtCompute = dtDmBarcode.DefaultView.ToTable();
                numTBarcode.Value = Convert.ToDouble(SQLExec.ExecuteReturnValue("SELECT COUNT (Barcode) FROM R81DMBARCODE"));
            }
            else
            {
                numTBarcode.Value = 0;
            }
        }
        #endregion
	}
	
}