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
	public partial class frmCheckInventory_Barcode : RosySystem.Customize.frmView
	{
		BindingSource bdsInventory_Barcode = new BindingSource();
		DataTable dtInventory_Barcode = new DataTable();

		BindingSource bdsInventory_Barcode_Detail = new BindingSource();
		public DataTable dtInventory_Barcode_Detail = new DataTable();
		public bool is_Accept = false;

		DataRow drCurrent;
		string strStt_Org = string.Empty;
		string strMa_Vt_Org = string.Empty;
		string strStt = string.Empty;
		
		public frmCheckInventory_Barcode()
		{
			InitializeComponent();

			bdsInventory_Barcode.PositionChanged += new EventHandler(bdsInventory_Barcode_PositionChanged);
			dgvInventory_Barcode_Detail.CellValidated += new DataGridViewCellEventHandler(dgvInventory_Barcode_Detail_CellValidated);

			dgvInventory_Barcode_Detail.CellContentDoubleClick += new DataGridViewCellEventHandler(dgvInventory_Barcode_Detail_CellContentClick);
			dgvInventory_Barcode_Detail.CellContentClick += new DataGridViewCellEventHandler(dgvInventory_Barcode_Detail_CellContentClick);

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(string strStt, string strStt_Org)
		{
			this.strStt = strStt;
			this.strStt_Org = strStt_Org;
			
			this.Build();
			this.FillData_CheckInventory();
			this.FillData_TKCD();
			this.BindingLanguage();
			this.ShowDialog();
		}

		private void Build()
		{
			this.dgvInventory_Barcode.strZone = "CHECKINVENTORY_BARCODE";
			this.dgvInventory_Barcode.BuildGridView();

			this.dgvInventory_Barcode_Detail.strZone = "CHECKINVENTORY_BARCODE_DETAIL";
			this.dgvInventory_Barcode_Detail.BuildGridView();

			dgvInventory_Barcode_Detail.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvInventory_Barcode_Detail.Columns)
				dgvc.ReadOnly = true;

			if (dgvInventory_Barcode_Detail.Columns.Contains("CHON"))
				dgvInventory_Barcode_Detail.Columns["CHON"].ReadOnly = false;

			if (dgvInventory_Barcode_Detail.Columns.Contains("NUM_BARS"))
				dgvInventory_Barcode_Detail.Columns["NUM_BARS"].ReadOnly = false;
		}

		private void FillData_CheckInventory()
		{
			this.strMa_Vt_Org = SQLExec.ExecuteReturnValue("SELECT Ma_Vt_Org FROM R80PH_SCALE WHERE Stt = '" + this.strStt + "'").ToString();

			string strKey_Ma_Vt_Org_List = string.Empty;
			if (!string.IsNullOrEmpty(strMa_Vt_Org))
			{
				string[] strMa_Vt_Org_List = strMa_Vt_Org.Split(',');
				foreach (string str in strMa_Vt_Org_List)
					strKey_Ma_Vt_Org_List += "'" + str + "',";

				if (strKey_Ma_Vt_Org_List.EndsWith(","))
					strKey_Ma_Vt_Org_List = "Ma_Vt IN(" + strKey_Ma_Vt_Org_List.Substring(0, strKey_Ma_Vt_Org_List.Length - 1) + ")";
			}
			else
				strKey_Ma_Vt_Org_List = "(0 = 1)";
 
			string strQuery = @"
					SELECT *, CAST(1 AS BIT) AS Chon 
						FROM R04CTSO
						WHERE " + strKey_Ma_Vt_Org_List + " AND So_Cay <> 0 AND Stt = '" + strStt_Org + @"'
						ORDER BY Stt,Stt0";

			dtInventory_Barcode = SQLExec.ExecuteReturnDt(strQuery, CommandType.Text);
			bdsInventory_Barcode.DataSource = dtInventory_Barcode;
			dgvInventory_Barcode.DataSource = bdsInventory_Barcode;
			bdsInventory_Barcode.Position = 0;
		}

		private void FillData_TKCD()
		{
			string strMa_Vt_Sp_List = string.Empty;
			if (dtInventory_Barcode != null)
			{
				foreach (DataRow dr in dtInventory_Barcode.Rows)
					strMa_Vt_Sp_List = strMa_Vt_Sp_List + dr["Ma_Vt"].ToString() + ",";
			}

			if (strMa_Vt_Sp_List.EndsWith(","))
				strMa_Vt_Sp_List = strMa_Vt_Sp_List.Substring(0, strMa_Vt_Sp_List.Length - 1);

			Hashtable htPara = new Hashtable();
			htPara.Add("NGAY_CT", Voucher.GetDate_Server());
			htPara.Add("MA_KHO", "L");
			htPara.Add("MA_VT_SP", strMa_Vt_Sp_List);
			htPara.Add("IS_CHECKINVENTORY", 1);
			htPara.Add("LANGUAGE_TYPE", Element.sysLanguage);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			dtInventory_Barcode_Detail = SQLExec.ExecuteReturnDt("sp_rptTCB_TKCD02", htPara, CommandType.StoredProcedure);

			if (!dtInventory_Barcode_Detail.Columns.Contains("Chon"))
			{
				DataColumn dc = new DataColumn("Chon", typeof(bool));
				dc.DefaultValue = false;
				dtInventory_Barcode_Detail.Columns.Add(dc);
			}

			bdsInventory_Barcode_Detail.DataSource = dtInventory_Barcode_Detail;
			dgvInventory_Barcode_Detail.DataSource = bdsInventory_Barcode_Detail;
			bdsInventory_Barcode_Detail.Position = 0;

			this.dgvInventory_Barcode_Detail.ResizeGridView(100);
		}
		
		private double GetTSo_Luong_OutPut(string strStt, string strBarcode)
		{
			string strSQLExec = @"
				SELECT CASE WHEN ISNULL(SUM(T2.So_Luong_TL), 0) <> 0 THEN ISNULL(SUM(T2.So_Luong_TL), 0) - ISNULL(SUM(T1.So_Luong), 0) ELSE ISNULL(SUM(T1.So_Luong), 0) END
					FROM R05CTX_BARCODE T1 WITH(NOLOCK) LEFT JOIN
							(SELECT T1a.Barcode, SUM(T1a.So_Luong) AS So_Luong_TL
									FROM R05CTN_BARCODE T1a WITH(NOLOCK) JOIN R81DMBARCODE T2a WITH(NOLOCK) ON T1a.Barcode = T2a.Barcode
									WHERE T1a.Barcode = '" + strBarcode + "' AND T2a.Is_OutPut = 1" + @"
									GROUP BY T1a.Barcode) T2 ON T1.Barcode = T2.Barcode" + @"
					WHERE T1.Stt <> '" + strStt + "' AND T1.Barcode = '" + strBarcode + "'";

			return Convert.ToDouble(SQLExec.ExecuteReturnValue(strSQLExec));
		}

		void bdsInventory_Barcode_PositionChanged(object sender, EventArgs e)
		{
			if (bdsInventory_Barcode.Position < 0)
				return;

			string strMa_Vt = ((DataRowView)bdsInventory_Barcode.Current).Row["Ma_Vt"].ToString();
			bdsInventory_Barcode_Detail.Filter = "Ma_Vt_Sp = '" + strMa_Vt + "'";

			this.Calc_Select(strMa_Vt);
		}

		void dgvInventory_Barcode_Detail_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			if (bdsInventory_Barcode_Detail.Position < 0)
				return;

			if (bdsInventory_Barcode.Position < 0)
			{
				((DataRowView)bdsInventory_Barcode_Detail.Current).Row["Chon"] = false;
				return;
			}

			drCurrent = ((DataRowView)bdsInventory_Barcode_Detail.Current).Row;
			string strColumnName = dgvInventory_Barcode_Detail.Columns[e.ColumnIndex].Name.ToUpper();

			if (strColumnName == "CHON")
			{
				drCurrent["Chon"] = !(bool)drCurrent["Chon"];

				if (!(bool)drCurrent["Chon"])
				{
					drCurrent["Khoi_Luong"] = drCurrent["Ton_Cuoi_Khoi_Luong"];
					drCurrent["Num_Bars"] = drCurrent["Ton_Cuoi_Num_Bars"];

					this.Calc_Select(drCurrent["Ma_Vt_Sp"].ToString());

					return;
				}

				//Kiem tra xem so cay chon du chua.
				double dbTNum_Bars_LXH = Convert.ToDouble(((DataRowView)bdsInventory_Barcode.Current).Row["So_Cay"]);
				double dbTNum_Bars = 0;
				double dbTNum_Bars_CL = 0;
                double dbSo_Luong_CL = 0;
				string strMa_Vt_Sp = ((DataRowView)bdsInventory_Barcode.Current).Row["Ma_Vt"].ToString();

				DataRow[] arrInventory = dtInventory_Barcode_Detail.Select("Chon = true AND Ma_Vt_Sp = '" + strMa_Vt_Sp + "'");
				if (arrInventory.Length != 0)
				{
					foreach (DataRow dr in arrInventory)
						dbTNum_Bars = dbTNum_Bars + Convert.ToDouble(dr["Num_Bars"]);
				}

                //Xử lý SL tổng
                double dbBarWeight = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "BarWeight", drCurrent["Ma_Vt_Sp"].ToString()));
                double dbLength = Convert.ToDouble(DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Length", drCurrent["Ma_Vt_Sp"].ToString()));
                // Bằng thêm phần barem
                double dbBarem = Math.Round((dbBarWeight * dbLength), 2);
                double dbNum_Bars_Barcode = drCurrent["Ton_Cuoi_Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Num_Bars"]);
                double dbSo_Luong_Barcode = drCurrent["Ton_Cuoi_Khoi_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Khoi_Luong"]);
                double dbTSo_Luong_OutPut = this.GetTSo_Luong_OutPut(this.strStt, drCurrent["Barcode"].ToString());

                if (dbTNum_Bars >= dbTNum_Bars_LXH)
                {
                    dbTNum_Bars_CL = dbTNum_Bars - dbTNum_Bars_LXH;
                    if (Convert.ToDouble(drCurrent["Num_Bars"]) - dbTNum_Bars_CL > 0)
                    {
                        drCurrent["Num_Bars"] = Convert.ToDouble(drCurrent["Num_Bars"]) - dbTNum_Bars_CL;

                       
                        double dbSo_Luong_Avg = 0;
                        double dbSo_Luong = 0;
                        double dbNum_Bars_New = 0;
                     
                        if (dbSo_Luong_Barcode + dbNum_Bars_Barcode > 0)
                        {
                            dbNum_Bars_New = drCurrent["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars"]);

                            if (dbNum_Bars_Barcode != 0)
                            {
                                //dbSo_Luong_Avg = Math.Round(dbSo_Luong_Barcode / dbNum_Bars_Barcode, 4);
                                dbSo_Luong = Math.Round(dbNum_Bars_New * dbBarem, 0);
                            }
                            //dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0);
                            dbSo_Luong_CL = Math.Abs(dbSo_Luong_Barcode - (dbTSo_Luong_OutPut + dbSo_Luong));

                            if (dbSo_Luong_CL > 0 && dbSo_Luong_CL <= 2)
                                dbSo_Luong = dbSo_Luong_Barcode - dbTSo_Luong_OutPut;

                            drCurrent["Khoi_Luong"] = dbSo_Luong;
                        }
                    }
                    else
                    {
                        drCurrent["Chon"] = !(bool)drCurrent["Chon"];
                        dgvInventory_Barcode_Detail.CancelEdit();
                    }
                }
                else // Bang them de tinh KL theo barem
                {
                    // khoi luong barem ky nay dc xuat
                    double dbSo_Luong = Math.Round(dbTNum_Bars * dbBarem, 0, MidpointRounding.AwayFromZero);
                    dbSo_Luong_CL = Math.Abs(dbSo_Luong_Barcode - (dbTSo_Luong_OutPut + dbSo_Luong));
                    
                    if (dbSo_Luong_CL > 0 && dbSo_Luong_CL <= 2)
                        dbSo_Luong = dbSo_Luong_Barcode - dbTSo_Luong_OutPut;

                    drCurrent["Khoi_Luong"] = dbSo_Luong;
                }
				this.Calc_Select(drCurrent["Ma_Vt_Sp"].ToString());
			}
		}

		private void Calc_Select(string strMa_Vt_Sp)
		{
			if (dtInventory_Barcode_Detail.Rows.Count > 0)
			{
				numTKhoi_Luong.Value = Common.SumDCValue(dtInventory_Barcode_Detail, "Khoi_Luong", "Chon = true AND Ma_Vt_Sp = '" + strMa_Vt_Sp + "'");
				numTNum_Bars.Value = Common.SumDCValue(dtInventory_Barcode_Detail, "Num_Bars", "Chon = true AND Ma_Vt_Sp = '" + strMa_Vt_Sp + "'");
			}
			else
				numTKhoi_Luong.Value = numTNum_Bars.Value = 0;
		}

		void dgvInventory_Barcode_Detail_CellValidated(object sender, DataGridViewCellEventArgs e)
		{
			if (bdsInventory_Barcode.Position < 0)
				return;

			if (bdsInventory_Barcode_Detail.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsInventory_Barcode_Detail.Current).Row;
			DataGridViewCell dgvCell = dgvInventory_Barcode_Detail.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

			if (Common.Inlist(strColumnName, "NUM_BARS"))
			{
				if (dgvInventory_Barcode_Detail.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
				{
					if (Convert.ToDouble(drCurrent["Num_Bars"]) != 0)
					{
						if (Convert.ToDouble(drCurrent["Num_Bars"]) <= Convert.ToDouble(drCurrent["Ton_Cuoi_Num_Bars"]))
						{
							drCurrent["Chon"] = true;

							//Kiem tra xem so cay chon du chua.
							double dbTNum_Bars_LXH = Convert.ToDouble(((DataRowView)bdsInventory_Barcode.Current).Row["So_Cay"]);
							double dbTNum_Bars = 0;
							double dbTNum_Bars_CL = 0;
							string strMa_Vt_Sp = ((DataRowView)bdsInventory_Barcode.Current).Row["Ma_Vt"].ToString();

							DataRow[] arrInventory = dtInventory_Barcode_Detail.Select("Chon = true AND Barcode <> '" + drCurrent["Barcode"].ToString() + "' AND Ma_Vt_Sp = '" + strMa_Vt_Sp + "'");
							if (arrInventory.Length != 0)
							{
								foreach (DataRow dr in arrInventory)
									dbTNum_Bars = dbTNum_Bars + Convert.ToDouble(dr["Num_Bars"]);
							}

							dbTNum_Bars = dbTNum_Bars + Convert.ToDouble(drCurrent["Num_Bars"]);

							if (dbTNum_Bars >= dbTNum_Bars_LXH)
							{
								dbTNum_Bars_CL = dbTNum_Bars - dbTNum_Bars_LXH;
								if (Convert.ToDouble(drCurrent["Num_Bars"]) - dbTNum_Bars_CL > 0)
								{
									drCurrent["Num_Bars"] = Convert.ToDouble(drCurrent["Num_Bars"]) - dbTNum_Bars_CL;

									double dbSo_Luong_Barcode = drCurrent["Ton_Cuoi_Khoi_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Khoi_Luong"]);
									double dbNum_Bars_Barcode = drCurrent["Ton_Cuoi_Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Num_Bars"]);
									double dbTSo_Luong_OutPut = this.GetTSo_Luong_OutPut(this.strStt, drCurrent["Barcode"].ToString());

									double dbSo_Luong_CL = 0;
									double dbSo_Luong_Avg = 0;
									double dbSo_Luong = 0;
									double dbNum_Bars_New = 0;

									if (dbSo_Luong_Barcode + dbNum_Bars_Barcode > 0)
									{
										dbNum_Bars_New = drCurrent["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars"]);

										if (dbNum_Bars_Barcode != 0)
											dbSo_Luong_Avg = Math.Round(dbSo_Luong_Barcode / dbNum_Bars_Barcode, 4);

										dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0);
										dbSo_Luong_CL = Math.Abs(dbSo_Luong_Barcode - (dbTSo_Luong_OutPut + dbSo_Luong));

										if (dbSo_Luong_CL > 0 && dbSo_Luong_CL <= 2)
											dbSo_Luong = dbSo_Luong_Barcode - dbTSo_Luong_OutPut;

										drCurrent["Khoi_Luong"] = dbSo_Luong;
									}
								}
								else
								{
									drCurrent["Chon"] = false;
									drCurrent["Khoi_Luong"] = drCurrent["Ton_Cuoi_Khoi_Luong"];
									drCurrent["Num_Bars"] = drCurrent["Ton_Cuoi_Num_Bars"];
								}
							}
							else
							{
								drCurrent["Num_Bars"] = Convert.ToDouble(drCurrent["Num_Bars"]) - dbTNum_Bars_CL;

								double dbSo_Luong_Barcode = drCurrent["Ton_Cuoi_Khoi_Luong"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Khoi_Luong"]);
								double dbNum_Bars_Barcode = drCurrent["Ton_Cuoi_Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Ton_Cuoi_Num_Bars"]);
								double dbTSo_Luong_OutPut = this.GetTSo_Luong_OutPut(this.strStt, drCurrent["Barcode"].ToString());

								double dbSo_Luong_CL = 0;
								double dbSo_Luong_Avg = 0;
								double dbSo_Luong = 0;
								double dbNum_Bars_New = 0;

								if (dbSo_Luong_Barcode + dbNum_Bars_Barcode > 0)
								{
									dbNum_Bars_New = drCurrent["Num_Bars"] == DBNull.Value ? 0 : Convert.ToDouble(drCurrent["Num_Bars"]);

									if (dbNum_Bars_Barcode != 0)
										dbSo_Luong_Avg = Math.Round(dbSo_Luong_Barcode / dbNum_Bars_Barcode, 4);

									dbSo_Luong = Math.Round(dbNum_Bars_New * dbSo_Luong_Avg, 0);
									dbSo_Luong_CL = Math.Abs(dbSo_Luong_Barcode - (dbTSo_Luong_OutPut + dbSo_Luong));

									if (dbSo_Luong_CL > 0 && dbSo_Luong_CL <= 2)
										dbSo_Luong = dbSo_Luong_Barcode - dbTSo_Luong_OutPut;

									drCurrent["Khoi_Luong"] = dbSo_Luong;
								}
							}
						}
						else
						{
							drCurrent["Chon"] = false;
							drCurrent["Khoi_Luong"] = drCurrent["Ton_Cuoi_Khoi_Luong"];
							drCurrent["Num_Bars"] = drCurrent["Ton_Cuoi_Num_Bars"];
						}
					}
				}
			}
			this.Calc_Select(drCurrent["Ma_Vt_Sp"].ToString());
			dgvInventory_Barcode_Detail.EndEdit();//Cap nhat lai DataSource
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			is_Accept = true;
			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			is_Accept = false;
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (dgvInventory_Barcode_Detail.Columns.Contains("Ten_Vt"))
				dgvInventory_Barcode_Detail.Columns["Ten_Vt"].HeaderText = "Kích thước";
		}

	}
}
