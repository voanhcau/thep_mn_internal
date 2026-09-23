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
using RosySystem.Common;

namespace RosyModule.Inventory
{
	public partial class frmKCS_Edit : RosySystem.Customize.frmEdit
	{
		DataTable dtKCS;
		DataRow drFilter;
		int iLengthX;
		string strTry_ID;

		public frmKCS_Edit()
		{
			InitializeComponent();
			this.cboBarcode1.Validated += new EventHandler(cboBarcode1_Validated);
			this.cboBarcode2.Validated += new EventHandler(cboBarcode1_Validated);
			this.cboBarcode2.SelectedIndexChanged += new EventHandler(cboBarcode2_SelectedIndexChanged);
			this.btAccept.Click += new EventHandler(btAccept_Click);
			this.btClear_Update.Click += new EventHandler(btClear_Update_Click);
		}

		public void Load(DataTable dtKCS, DataRow drFilter)
		{
			this.dtKCS = dtKCS;
			this.drFilter = drFilter;
			this.FillData();
			this.BindingLanguage();
			this.ShowDialog();
		}

		private void FillData()
		{
			//Add Item into Barcode
			cboBarcode1.Items.Clear();
			cboBarcode2.Items.Clear();
			if (dtKCS.Rows.Count > 0)
			{
				foreach (DataRow drBarcode in dtKCS.Rows)
				{
					cboBarcode1.Items.Add(drBarcode["Barcode"]);
					cboBarcode2.Items.Add(drBarcode["Barcode"]);
				}
			}

			this.cboGHan_So_Barcode.Items.AddRange(new object[] { "40", "50", "60" });

			this.numYeild.Value = this.numTension.Value = this.numElong.Value = 0;
			this.cboGHan_So_Barcode.SelectedIndex = 0;
			this.cboBend_Test.SelectedIndex = 1;
			this.cboBarcode1.SelectedIndex = cboBarcode2.SelectedIndex = 0;
			this.cboBarcode1.Focus();
		}

		private void Save()
		{
			string strBarcode1 = this.cboBarcode1.SelectedItem == null ? string.Empty : this.cboBarcode1.SelectedItem.ToString();
			string strBarcode2 = this.cboBarcode2.SelectedItem == null ? string.Empty : this.cboBarcode2.SelectedItem.ToString();

			this.iLengthX = strBarcode1.Length;

			bool bFlag1 = false;
			bool bFlag2 = false;

			for (int i = 0; i < this.cboBarcode1.Items.Count; i++)
			{
				string strValue = cboBarcode1.Items[i].ToString();
				if (strValue == strBarcode1)
					bFlag1 = true;

				if (strValue == strBarcode2)
					bFlag2 = true;
			}

			if (!bFlag1)
			{
				Common.MsgCancel("Không có mã vạch {" + strBarcode1 + "} trong danh sách các mã vạch này");
			}
			else
			{
				if (!bFlag2)
				{
					Common.MsgCancel("Không có mã vạch {" + strBarcode2 + "} trong danh sách các mã vạch này");
				}
				else
				{
					string strSQLExec = @"SELECT T1.Barcode, T3.Diameter, T2.DMin, T2.DMax, T2.YeildP_Min, T2.YeildP_Max, T2.TensionP_Min, T2.TensionP_Max, T2.Elong_Min, T2.ELong_Max
												FROM R81DMBARCODE T1 JOIN R81DMCOTINH T2 ON T1.Grade_ID = T2.Grade_ID
																		JOIN R81DMVT T3 ON T1.Ma_Vt = T3.Ma_Vt
												WHERE (T3.Diameter >= T2.DMin AND T3.Diameter <= T3.DMax) AND T1.Barcode BETWEEN '" + strBarcode1 + "' AND '" + strBarcode2 + "' AND LEN(T1.Barcode) = " + iLengthX + "";

					DataTable dtDmCoTinh = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
					double dbYeildP_Min = 0;
					double dbTensionP_Min = 0;
					double dbELong_Min = 0;
					double dbYeildP_Max = 0;
					double dbTensionP_Max = 0;
					double dbELong_Max = 0;

					foreach (DataRow drCoTinh in dtDmCoTinh.Rows)
					{
						dbYeildP_Min = drCoTinh["YeildP_Min"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["YeildP_Min"]);
						dbTensionP_Min = drCoTinh["TensionP_Min"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["TensionP_Min"]);
						dbELong_Min = drCoTinh["ELong_Min"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["Elong_Min"]);

						dbYeildP_Max = drCoTinh["YeildP_Max"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["YeildP_Max"]);
						dbTensionP_Max = drCoTinh["TensionP_Max"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["TensionP_Max"]);
						dbELong_Max = drCoTinh["ELong_Max"] == DBNull.Value ? 0 : Convert.ToDouble(drCoTinh["Elong_Max"]);

						if (this.numYeild.Value < dbYeildP_Min)
						{
							Common.MsgCancel("Giới hạn chảy dưới mức cho phép của mác này");
							return;
						}
						if (this.numTension.Value < dbTensionP_Min)
						{
							Common.MsgCancel("Giới hạn bền dưới mức cho phép của mác này");
							return;
						}
						if (this.numElong.Value < dbELong_Min)
						{
							Common.MsgCancel("Độ dãn dài dưới mức cho phép của mác này");
							return;
						}

						//Max
						if (numYeild.Value > dbYeildP_Max)
						{
							Common.MsgCancel("Giới hạn chảy trên mức cho phép của mác này");
							return;
						}

						if (numTension.Value > dbTensionP_Max)
						{
							Common.MsgCancel("Giới hạn bền trên mức cho phép của mác này");
							return;
						}

						if (numElong.Value > dbELong_Max)
						{
							Common.MsgCancel("Độ dãn dài trên mức cho phép của mác này");
							return;
						}

						Hashtable htPara = new Hashtable();
						htPara.Add("BARCODE", drCoTinh["Barcode"]);
						htPara.Add("YEILD", numYeild.Value);
						htPara.Add("TENSION", numTension.Value);
						htPara.Add("ELONG", numElong.Value);
						htPara.Add("BEND_TEST", cboBend_Test.SelectedIndex);
						htPara.Add("TRY_ID", this.strTry_ID);
						htPara.Add("REMARK_KCS", txtRemark_KCS.Text);
						htPara.Add("LASTMODIFY_LOG_KCS", Common.GetCurrent_Log());

						//Cap nhat KCS vao Danh muc Barcode
						try
						{
							SQLExec.Execute("sp_Update_DmBarcode_KCS", htPara, CommandType.StoredProcedure);
						}
						catch (Exception ex)
						{
							Common.MsgCancel("Có lỗi xãy ra khi cập nhật!" + ex.ToString());
						}
					}

					this.FillData();

					Common.MsgOk("Cập nhật cơ tính thành công!");
				}
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			this.Save();
		}

		void btClear_Update_Click(object sender, EventArgs e)
		{
			string strBarcode1 = cboBarcode1.SelectedItem == null ? string.Empty : cboBarcode1.SelectedItem.ToString();
			string strBarcode2 = cboBarcode2.SelectedItem == null ? string.Empty : cboBarcode2.SelectedItem.ToString();

			if (Common.MsgYes_No("Bạn có chắc chắn hủy bỏ các thông tin đã cập nhật từ mã vạch {" + strBarcode1 + "} đến mã vạch {" + strBarcode2 + "} không?", "N"))
			{
				string strSQLExec = @"UPDATE R81DMBARCODE SET Try_ID = '', Is_OutPut = 0, Yeild = 0, Tension = 0, ELong = 0, Bend_Test = 0, Remark_KCS = '', LastModify_Log_KCS = '' WHERE Barcode BETWEEN '" + strBarcode1 + "' AND '" + strBarcode2 + "'";
				if (SQLExec.Execute(strSQLExec, CommandType.Text))
				{
					Common.MsgOk("Đã hủy cập nhật thành công!");
				}
			}
		}

		void cboBarcode1_Validated(object sender, EventArgs e)
		{
			try
			{
				string strBarcode1 = cboBarcode1.SelectedItem == null ? "" : cboBarcode1.SelectedItem.ToString();
				string strBarcode2 = cboBarcode2.SelectedItem == null ? "" : cboBarcode2.SelectedItem.ToString();
				this.strTry_ID = ("000000" + strBarcode1).Substring(strBarcode1.Length, 6) + "-" + ("000000" + strBarcode2).Substring(strBarcode2.Length, 6);
			}
			catch
			{
			}
		}

		void cboBarcode2_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (cboBarcode1.SelectedItem != null && cboBarcode2.SelectedItem != null)
				{
					int iDai_Bo = Convert.ToInt32(this.cboBarcode2.SelectedItem) - Convert.ToInt32(this.cboBarcode1.SelectedItem);
					if (cboGHan_So_Barcode.SelectedItem != null)
					{
						if (iDai_Bo > Convert.ToInt32(cboGHan_So_Barcode.SelectedItem))
						{
							Common.MsgCancel("Dải bó nhập không hợp lệ");
							this.cboBarcode2.SelectedIndex = this.cboBarcode1.SelectedIndex;
						}
					}
					else
					{
						if (iDai_Bo > 50)
						{
							Common.MsgCancel("Dải bó nhập không hợp lệ");
							this.cboBarcode2.SelectedIndex = this.cboBarcode1.SelectedIndex;
						}
					}

				}
			}
			catch
			{
			}
		}

	}
}
