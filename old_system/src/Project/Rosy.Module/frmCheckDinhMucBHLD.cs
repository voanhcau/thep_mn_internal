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

namespace RosyModule
{
	public partial class frmCheckDinhMucBHLD : RosySystem.Customize.frmView
	{
		BindingSource bdsDinhMucBHLD = new BindingSource();
		DataTable dtDinhMucBHLD = new DataTable();
        DataSet dsDinhMucBHLD = new DataSet();

		BindingSource bdsDinhMucBHLD_Detail = new BindingSource();
		public DataTable dtDinhMucBHLD_Detail = new DataTable();
		public bool is_Accept = false;
        public bool is_Open = false;
        DataGridView dgvDinhMucBHLD_Detail = new DataGridView();
        DataRow drCurrent;
		string strMa_Vt = string.Empty;
		string strMa_Bp = string.Empty;
        DateTime dteNgay_Ct;

        public frmVoucher_Edit frmEdit;
        public frmCheckDinhMucBHLD()
		{
			InitializeComponent();

			bdsDinhMucBHLD.PositionChanged += new EventHandler(bdsDinhMucBHLD_PositionChanged);
			dgvDinhMucBHLD_Detail.CellValidated += new DataGridViewCellEventHandler(dgvInventory_Barcode_Detail_CellValidated);

            //dgvDinhMucBHLD_Detail.CellContentDoubleClick += new DataGridViewCellEventHandler(dgvDinhMucBHLD_Detail_CellContentClick);
            //dgvDinhMucBHLD_Detail.CellContentClick += new DataGridViewCellEventHandler(dgvDinhMucBHLD_Detail_CellContentClick);

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(DataRow drEditBHLD)
		{
            this.strMa_Vt = (string)drEditBHLD["Ma_Vt"];
            this.strMa_Bp = (string)drEditBHLD["Ma_Dt"];
            this.dteNgay_Ct = (DateTime)drEditBHLD["Ngay_Ct"];

			this.Build();
			this.FillData_CheckInventory();
			this.FillData_TKCD();
			this.BindingLanguage();
            //this.ShowDialog();
		}

		private void Build()
		{
            this.dgvDinhMucBHLD.strZone = "CHECKDMBHLD";
			this.dgvDinhMucBHLD.BuildGridView();

            //foreach (DataGridViewColumn dgvc in dgvDinhMucBHLD.Columns)
            //    dgvc.ReadOnly = true;

            //if (dgvDinhMucBHLD.Columns.Contains("SO_LUONG_CBNV"))
            //    dgvDinhMucBHLD.Columns["SO_LUONG_CBNV"].ReadOnly = false;
            
            //this.dgvDinhMucBHLD_Detail.strZone = "CHECKDMBHLD_DETAIL";
            //this.dgvDinhMucBHLD_Detail.BuildGridView();

            dgvDinhMucBHLD_Detail.Visible = true;
		}

		private void FillData_CheckInventory()
		{
			this.strMa_Vt = SQLExec.ExecuteReturnValue("SELECT Ma_Vt_Chung FROM R81DMVT WHERE Ma_Vt = '" + this.strMa_Vt + "'").ToString();
            
            Hashtable ht = new Hashtable();
            ht.Add("MA_BP", strMa_Bp);
            ht.Add("MA_VT", strMa_Vt);
            ht.Add("NGAY_CT", dteNgay_Ct);

            dsDinhMucBHLD = SQLExec.ExecuteReturnDs("dbo.sp_GetDMBHLD", ht, CommandType.StoredProcedure);
            dtDinhMucBHLD = dsDinhMucBHLD.Tables[0];
            
			bdsDinhMucBHLD.DataSource = dtDinhMucBHLD;
			dgvDinhMucBHLD.DataSource = bdsDinhMucBHLD;
			bdsDinhMucBHLD.Position = 0;

            dtDinhMucBHLD_Detail = dsDinhMucBHLD.Tables[1];

            Calc_Select();
		}

		private void FillData_TKCD()
		{
            //string strMa_Vt_Sp_List = string.Empty;
            //if (dtDinhMucBHLD != null)
            //{
            //    foreach (DataRow dr in dtDinhMucBHLD.Rows)
            //        strMa_Vt_Sp_List = strMa_Vt_Sp_List + dr["Ma_Vt"].ToString() + ",";
            //}

            //if (strMa_Vt_Sp_List.EndsWith(","))
            //    strMa_Vt_Sp_List = strMa_Vt_Sp_List.Substring(0, strMa_Vt_Sp_List.Length - 1);

            //Hashtable htPara = new Hashtable();
            //htPara.Add("NGAY_CT", Voucher.GetDate_Server());
            //htPara.Add("MA_KHO", "L");
            //htPara.Add("MA_VT_SP", strMa_Vt_Sp_List);
            //htPara.Add("IS_CHECKINVENTORY", 1);
            //htPara.Add("LANGUAGE_TYPE", Element.sysLanguage);
            //htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            //dtDinhMucBHLD_Detail = SQLExec.ExecuteReturnDt("sp_rptTCB_TKCD02", htPara, CommandType.StoredProcedure);

            //if (!dtDinhMucBHLD_Detail.Columns.Contains("Chon"))
            //{
            //    DataColumn dc = new DataColumn("Chon", typeof(bool));
            //    dc.DefaultValue = false;
            //    dtDinhMucBHLD_Detail.Columns.Add(dc);
            //}

            //bdsDinhMucBHLD_Detail.DataSource = dtDinhMucBHLD_Detail;
            //dgvDinhMucBHLD_Detail.DataSource = bdsDinhMucBHLD_Detail;
            //bdsDinhMucBHLD_Detail.Position = 0;

            //this.dgvDinhMucBHLD_Detail.ResizeGridView(100);
		}
		
//        private double GetTSo_Luong_OutPut(string strStt, string strBarcode)
//        {
//            string strSQLExec = @"
//				SELECT CASE WHEN ISNULL(SUM(T2.So_Luong_TL), 0) <> 0 THEN ISNULL(SUM(T2.So_Luong_TL), 0) - ISNULL(SUM(T1.So_Luong), 0) ELSE ISNULL(SUM(T1.So_Luong), 0) END
//					FROM R05CTX_BARCODE T1 WITH(NOLOCK) LEFT JOIN
//							(SELECT T1a.Barcode, SUM(T1a.So_Luong) AS So_Luong_TL
//									FROM R05CTN_BARCODE T1a WITH(NOLOCK) JOIN R81DMBARCODE T2a WITH(NOLOCK) ON T1a.Barcode = T2a.Barcode
//									WHERE T1a.Barcode = '" + strBarcode + "' AND T2a.Is_OutPut = 1" + @"
//									GROUP BY T1a.Barcode) T2 ON T1.Barcode = T2.Barcode" + @"
//					WHERE T1.Stt <> '" + strStt + "' AND T1.Barcode = '" + strBarcode + "'";

//            return Convert.ToDouble(SQLExec.ExecuteReturnValue(strSQLExec));
//        }

		void bdsDinhMucBHLD_PositionChanged(object sender, EventArgs e)
		{
            //if (bdsDinhMucBHLD.Position < 0)
            //    return;

            //string strMa_Vt = ((DataRowView)bdsDinhMucBHLD.Current).Row["Ma_Vt"].ToString();
            //bdsDinhMucBHLD_Detail.Filter = "Ma_Vt_Sp = '" + strMa_Vt + "'";

            //this.Calc_Select(strMa_Vt);
		}

        //void dgvInventory_Barcode_Detail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex < 0 || e.RowIndex < 0)
        //        return;

        //    if (bdsDinhMucBHLD_Detail.Position < 0)
        //        return;

        //    if (bdsDinhMucBHLD.Position < 0)
        //    {
        //        ((DataRowView)bdsDinhMucBHLD_Detail.Current).Row["Chon"] = false;
        //        return;
        //    }

        //    drCurrent = ((DataRowView)bdsDinhMucBHLD_Detail.Current).Row;
        //    string strColumnName = dgvDinhMucBHLD_Detail.Columns[e.ColumnIndex].Name.ToUpper();

        //    if (strColumnName == "CHON")
        //    {
        //        drCurrent["Chon"] = !(bool)drCurrent["Chon"];

        //        if (!(bool)drCurrent["Chon"])
        //        {
        //            drCurrent["Khoi_Luong"] = drCurrent["Ton_Cuoi_Khoi_Luong"];
        //            drCurrent["Num_Bars"] = drCurrent["Ton_Cuoi_Num_Bars"];

        //            this.Calc_Select(drCurrent["Ma_Vt_Sp"].ToString());

        //            return;
        //        }

        //        //Kiem tra xem so cay chon du chua.
        //        double dbTNum_Bars_LXH = Convert.ToDouble(((DataRowView)bdsDinhMucBHLD.Current).Row["So_Cay"]);
        //        double dbTNum_Bars = 0;
        //        double dbTNum_Bars_CL = 0;
        //        string strMa_Vt_Sp = ((DataRowView)bdsDinhMucBHLD.Current).Row["Ma_Vt"].ToString();

        //        DataRow[] arrInventory = dtDinhMucBHLD_Detail.Select("Chon = true AND Ma_Vt_Sp = '" + strMa_Vt_Sp + "'");
        //        if (arrInventory.Length != 0)
        //        {
        //            foreach (DataRow dr in arrInventory)
        //                dbTNum_Bars = dbTNum_Bars + Convert.ToDouble(dr["Num_Bars"]);
        //        }

        //        if (dbTNum_Bars >= dbTNum_Bars_LXH)
        //        {
        //            dbTNum_Bars_CL = dbTNum_Bars - dbTNum_Bars_LXH;
        //            if (Convert.ToDouble(drCurrent["Num_Bars"]) - dbTNum_Bars_CL > 0)
        //            {
        //                drCurrent["Num_Bars"] = Convert.ToDouble(drCurrent["Num_Bars"]) - dbTNum_Bars_CL;

        //                double dbSo_Luong_Barcode = drCurrent["Ton_Cuoi_Khoi_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Khoi_Luong"]);
        //                double dbNum_Bars_Barcode = drCurrent["Ton_Cuoi_Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Num_Bars"]);
        //                double dbTSo_Luong_OutPut = this.GetTSo_Luong_OutPut(this.strStt, drCurrent["Barcode"].ToString());

        //                double dbSo_Luong_CL = 0;
        //                double dbSo_Luong_Avg = 0;
        //                double dbSo_Luong = 0;
        //                double dbNum_Bars_New = 0;

        //                if (dbSo_Luong_Barcode + dbNum_Bars_Barcode > 0)
        //                {
        //                    dbNum_Bars_New = drCurrent["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars"]);

        //                    if (dbNum_Bars_Barcode != 0)
        //                        dbSo_Luong_Avg = Math.Round(dbSo_Luong_Barcode / dbNum_Bars_Barcode, 4);

        //                    dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0);
        //                    dbSo_Luong_CL = Math.Abs(dbSo_Luong_Barcode - (dbTSo_Luong_OutPut + dbSo_Luong));

        //                    if (dbSo_Luong_CL > 0 && dbSo_Luong_CL <= 2)
        //                        dbSo_Luong = dbSo_Luong_Barcode - dbTSo_Luong_OutPut;

        //                    drCurrent["Khoi_Luong"] = dbSo_Luong;
        //                }
        //            }
        //            else
        //            {
        //                drCurrent["Chon"] = !(bool)drCurrent["Chon"];
        //                dgvDinhMucBHLD_Detail.CancelEdit();
        //            }
        //        }

        //        this.Calc_Select(drCurrent["Ma_Vt_Sp"].ToString());
        //    }
        //}

        private void Calc_Select()//string strMa_Vt_Sp
		{
            if (dtDinhMucBHLD.Rows.Count > 0)
            {
                numTSo_Luong_Nam.Value = Common.SumDCValue(dtDinhMucBHLD, "So_Luong_Nam", "");
                numTSo_Luong_Quy.Value = Common.SumDCValue(dtDinhMucBHLD, "So_Luong_Quy", "");
            }
            else
            {
                numTSo_Luong_Nam.Value = 0;
                numTSo_Luong_Quy.Value = 0;
            }

            if (dtDinhMucBHLD_Detail.Rows.Count > 0)
			    numTSo_Luong_Dn.Value = Common.SumDCValue(dtDinhMucBHLD_Detail, "TSo_Luong", "");
			else
				numTSo_Luong_Dn.Value = 0;
            
            numTSo_Luong.Value = numTSo_Luong_Nam.Value - numTSo_Luong_Dn.Value;
		}

		void dgvInventory_Barcode_Detail_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
            if (bdsDinhMucBHLD.Position < 0)
                return;

            //if (bdsDinhMucBHLD_Detail.Position < 0)
            //    return;

            drCurrent = ((DataRowView)bdsDinhMucBHLD.Current).Row;
            DataGridViewCell dgvCell = dgvDinhMucBHLD_Detail.CurrentCell;
            string strColumnName = dgvCell.OwningColumn.Name.ToUpper();
            if (Common.Inlist(strColumnName, "SO_LUONG_CBNV"))
            {
                double dbDinh_Muc = Convert.ToDouble(drCurrent["Dinh_Muc"]);
                double dbSo_Luong_CbNv = Convert.ToDouble(drCurrent["So_Luong_CbNv"]);
                drCurrent["So_Luong_Quy"] = Math.Round(dbSo_Luong_CbNv * (dbDinh_Muc / 4), 0);
                drCurrent["So_Luong_Nam"] = Math.Round(dbSo_Luong_CbNv * (dbDinh_Muc), 0);
                Calc_Select();
            }
            //if (Common.Inlist(strColumnName, "NUM_BARS"))
            //{
            //    if (dgvDinhMucBHLD_Detail.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            //    {
            //        if (Convert.ToDouble(drCurrent["Num_Bars"]) != 0)
            //        {
            //            if (Convert.ToDouble(drCurrent["Num_Bars"]) <= Convert.ToDouble(drCurrent["Ton_Cuoi_Num_Bars"]))
            //            {
            //                drCurrent["Chon"] = true;

            //                //Kiem tra xem so cay chon du chua.
            //                double dbTNum_Bars_LXH = Convert.ToDouble(((DataRowView)bdsDinhMucBHLD.Current).Row["So_Cay"]);
            //                double dbTNum_Bars = 0;
            //                double dbTNum_Bars_CL = 0;
            //                string strMa_Vt_Sp = ((DataRowView)bdsDinhMucBHLD.Current).Row["Ma_Vt"].ToString();

            //                DataRow[] arrInventory = dtDinhMucBHLD_Detail.Select("Chon = true AND Barcode <> '" + drCurrent["Barcode"].ToString() + "' AND Ma_Vt_Sp = '" + strMa_Vt_Sp + "'");
            //                if (arrInventory.Length != 0)
            //                {
            //                    foreach (DataRow dr in arrInventory)
            //                        dbTNum_Bars = dbTNum_Bars + Convert.ToDouble(dr["Num_Bars"]);
            //                }

            //                dbTNum_Bars = dbTNum_Bars + Convert.ToDouble(drCurrent["Num_Bars"]);

            //                if (dbTNum_Bars >= dbTNum_Bars_LXH)
            //                {
            //                    dbTNum_Bars_CL = dbTNum_Bars - dbTNum_Bars_LXH;
            //                    if (Convert.ToDouble(drCurrent["Num_Bars"]) - dbTNum_Bars_CL > 0)
            //                    {
            //                        drCurrent["Num_Bars"] = Convert.ToDouble(drCurrent["Num_Bars"]) - dbTNum_Bars_CL;

            //                        double dbSo_Luong_Barcode = drCurrent["Ton_Cuoi_Khoi_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Khoi_Luong"]);
            //                        double dbNum_Bars_Barcode = drCurrent["Ton_Cuoi_Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Num_Bars"]);
            //                        double dbTSo_Luong_OutPut = this.GetTSo_Luong_OutPut(this.strStt, drCurrent["Barcode"].ToString());

            //                        double dbSo_Luong_CL = 0;
            //                        double dbSo_Luong_Avg = 0;
            //                        double dbSo_Luong = 0;
            //                        double dbNum_Bars_New = 0;

            //                        if (dbSo_Luong_Barcode + dbNum_Bars_Barcode > 0)
            //                        {
            //                            dbNum_Bars_New = drCurrent["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars"]);

            //                            if (dbNum_Bars_Barcode != 0)
            //                                dbSo_Luong_Avg = Math.Round(dbSo_Luong_Barcode / dbNum_Bars_Barcode, 4);

            //                            dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0);
            //                            dbSo_Luong_CL = Math.Abs(dbSo_Luong_Barcode - (dbTSo_Luong_OutPut + dbSo_Luong));

            //                            if (dbSo_Luong_CL > 0 && dbSo_Luong_CL <= 2)
            //                                dbSo_Luong = dbSo_Luong_Barcode - dbTSo_Luong_OutPut;

            //                            drCurrent["Khoi_Luong"] = dbSo_Luong;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        drCurrent["Chon"] = false;
            //                        drCurrent["Khoi_Luong"] = drCurrent["Ton_Cuoi_Khoi_Luong"];
            //                        drCurrent["Num_Bars"] = drCurrent["Ton_Cuoi_Num_Bars"];
            //                    }
            //                }
            //                else
            //                {
            //                    drCurrent["Num_Bars"] = Convert.ToDouble(drCurrent["Num_Bars"]) - dbTNum_Bars_CL;

            //                    double dbSo_Luong_Barcode = drCurrent["Ton_Cuoi_Khoi_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Khoi_Luong"]);
            //                    double dbNum_Bars_Barcode = drCurrent["Ton_Cuoi_Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Num_Bars"]);
            //                    double dbTSo_Luong_OutPut = this.GetTSo_Luong_OutPut(this.strStt, drCurrent["Barcode"].ToString());

            //                    double dbSo_Luong_CL = 0;
            //                    double dbSo_Luong_Avg = 0;
            //                    double dbSo_Luong = 0;
            //                    double dbNum_Bars_New = 0;

            //                    if (dbSo_Luong_Barcode + dbNum_Bars_Barcode > 0)
            //                    {
            //                        dbNum_Bars_New = drCurrent["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars"]);

            //                        if (dbNum_Bars_Barcode != 0)
            //                            dbSo_Luong_Avg = Math.Round(dbSo_Luong_Barcode / dbNum_Bars_Barcode, 4);

            //                        dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0);
            //                        dbSo_Luong_CL = Math.Abs(dbSo_Luong_Barcode - (dbTSo_Luong_OutPut + dbSo_Luong));

            //                        if (dbSo_Luong_CL > 0 && dbSo_Luong_CL <= 2)
            //                            dbSo_Luong = dbSo_Luong_Barcode - dbTSo_Luong_OutPut;

            //                        drCurrent["Khoi_Luong"] = dbSo_Luong;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                drCurrent["Chon"] = false;
            //                drCurrent["Khoi_Luong"] = drCurrent["Ton_Cuoi_Khoi_Luong"];
            //                drCurrent["Num_Bars"] = drCurrent["Ton_Cuoi_Num_Bars"];
            //            }
            //        }
            //    }
            //}
            //this.Calc_Select(drCurrent["Ma_Vt_Sp"].ToString());
            //dgvDinhMucBHLD_Detail.EndEdit();//Cap nhat lai DataSource
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			is_Accept = true;
            is_Open = false;
			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			is_Accept = false;
            is_Open = false;
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

            //if (dgvDinhMucBHLD_Detail.Columns.Contains("Ten_Vt"))
            //    dgvDinhMucBHLD_Detail.Columns["Ten_Vt"].HeaderText = "Kích thước";
		}

	}
}
