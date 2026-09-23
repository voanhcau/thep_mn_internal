using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;
using RosySystem;

namespace RosyModule.ScaleBarcode
{
	public partial class frmCreateBarcodeLe : RosySystem.Customize.frmView
	{
		BindingSource bdsBarcode = new BindingSource();
		DataTable dtBarcode = new DataTable();

		BindingSource bdsBarcode_Detail = new BindingSource();
		public DataTable dtBarcode_Detail = new DataTable();
		public bool is_Accept = false;

		DataRow drCurrent;
		
		
		public frmCreateBarcodeLe()
		{
			InitializeComponent();

			bdsBarcode.PositionChanged += new EventHandler(bdsBarcode_PositionChanged);
			

            //txtMa_Vt_Sp.Validating += new CancelEventHandler(txtMa_Vt_Sp_Validating);

            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            btRefresh.Click += new EventHandler(btRefresh_Click);
            btPrint.Click += new EventHandler(btPrint_Click);
		}

		public void Load()
		{
            dteNgay_Ct1.Text = Library.DateToStr(Element.sysNgay_Ct1);
            dteNgay_Ct2.Text = Library.DateToStr(Element.sysNgay_Ct2);
			
			this.Build();
			this.FillData_CheckInventory();
			this.FillData_TKCD();
			this.BindingLanguage();
			this.Show();
		}

		void Build()
		{
            txtMa_Vt_Sp.bUseAutoDropDown = true;

			this.dgvBarcode.strZone = "BARCODELE";
			this.dgvBarcode.BuildGridView();

			this.dgvBarcode_Detail.strZone = "BARCODE_DETAIL";
			this.dgvBarcode_Detail.BuildGridView();

			dgvBarcode.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvBarcode_Detail.Columns)
				dgvc.ReadOnly = true;
		}

		void FillData_CheckInventory()
		{
            Hashtable ht = new Hashtable();
            ht.Add("NGAY_CT1", dteNgay_Ct1.Text);
            ht.Add("NGAY_CT2", dteNgay_Ct2.Text);
            ht.Add("MA_VT_SP", txtMa_Vt_Sp.Text);

            dtBarcode = SQLExec.ExecuteReturnDt("sp_GetBarcodeLe", ht, CommandType.StoredProcedure);
			bdsBarcode.DataSource = dtBarcode;
			dgvBarcode.DataSource = bdsBarcode;
            bdsBarcode.Position = bdsBarcode.Count;
		}

		void FillData_TKCD()
		{
			string Barcode_List = string.Empty;
			if (dtBarcode != null)
			{
				foreach (DataRow dr in dtBarcode.Rows)
					Barcode_List = Barcode_List + dr["Barcode"].ToString() + ",";
			}

			if (Barcode_List.EndsWith(","))
				Barcode_List = Barcode_List.Substring(0, Barcode_List.Length - 1);

			Hashtable htPara = new Hashtable();
			htPara.Add("BARCODE_LIST", Barcode_List);

            dtBarcode_Detail = SQLExec.ExecuteReturnDt("sp_GetBarcode_Detail", htPara, CommandType.StoredProcedure);


			bdsBarcode_Detail.DataSource = dtBarcode_Detail;
			dgvBarcode_Detail.DataSource = bdsBarcode_Detail;
            bdsBarcode_Detail.Position = bdsBarcode_Detail.Count;

			this.dgvBarcode_Detail.ResizeGridView(100);
		}
		
		

		void bdsBarcode_PositionChanged(object sender, EventArgs e)
		{
			if (bdsBarcode.Position < 0)
				return;

			string strBarcode = ((DataRowView)bdsBarcode.Current).Row["Barcode"].ToString();
            bdsBarcode_Detail.Filter = "Barcode_Org = '" + strBarcode + "'";
		}
        void btPrint_Click(object sender, EventArgs e)
        {
            if (bdsBarcode_Detail.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsBarcode_Detail.Current).Row;

            this.Print(drCurrent["Barcode"].ToString(), Convert.ToBoolean(drCurrent["Is_Barem"]), false);
        }
        private void Print(string strBarcode, bool bIs_Barem, bool bPreview)
        {
           Voucher.PrintBarcode(strBarcode, bIs_Barem, false, Variables.strPrint_Barcode);
        }
	    void btDelete_Click(object sender, EventArgs e)
        {
            if (bdsBarcode_Detail.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsBarcode_Detail.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R81DMBARCODE", drCurrent))
            {
                bdsBarcode_Detail.RemoveAt(bdsBarcode_Detail.Position);
                dtBarcode_Detail.AcceptChanges();
            }
        }

        void btEdit_Click(object sender, EventArgs e)
        {
           Edit_BarcodeLe(enuEdit.Edit);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            Edit_BarcodeLe(enuEdit.New);
        }
        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData_CheckInventory();
            FillData_TKCD();
        }
        private void Edit_BarcodeLe(enuEdit enuNew_Edit)
        {
            if (bdsBarcode.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            DataRow drEditCt = ((DataRowView)bdsBarcode.Current).Row;
           

            //Copy hang hien tai            
            if (bdsBarcode_Detail.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBarcode_Detail.Current).Row, ref drCurrent);
            else
                Common.CopyDataRow(((DataRowView)bdsBarcode.Current).Row, ref drCurrent);

            frmBarcodeLe_Edit frm = new frmBarcodeLe_Edit();
            frm.Load(enuNew_Edit, drCurrent, drEditCt["Barcode"].ToString(), Convert.ToDouble(drEditCt["Num_Bars_Ton"]));

            if (frm.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                    //if (bdsBarcode_Detail.Position >= 0)
						dtBarcode_Detail.ImportRow(drCurrent);
                    //else
                    //    dtBarcode_Detail.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsBarcode_Detail.Current).Row);
				}
                bdsBarcode_Detail.Position = bdsBarcode_Detail.Find("BARCODE", drCurrent["Barcode"]);
				dtBarcode_Detail.AcceptChanges();
			}
			else
				dtBarcode_Detail.RejectChanges();
            }
            
        

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

           
        }

	}
}
