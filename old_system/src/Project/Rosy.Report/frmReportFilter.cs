using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

using RosySystem;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Element;
using RosySystem.Customize;
using RosySystem.Public;

namespace RosyReport
{
	public partial class frmReportFilter : RosySystem.Customize.frmEdit
	{
		#region Biến
		Control ctrlFilter_ID_Btn;
		Control ctrlFilter_ID_Lbt;

		private DataRow drReport;
		private DataTable dtFilter;
		private DataRow drFilter;
		private Dictionary<string, FilterInfo> dicFilterInfo = new Dictionary<string, FilterInfo>();

		int iLeft = 30;
		int iRight = 30;
		int iTop = 30;
		int iBotton = 30;

		int iFilter_ID_Width = 120;
		int iFilter_Label_Width = 120;
		int iFilter_Name_Width = 80;
		int iRow_Distance = 2;

		int iCol_Width;

		string strLookupTable, strLookupID;

		#endregion

		#region Phương thức
		public frmReportFilter()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			this.Resize += new EventHandler(frmReportFilter_Resize);
		}

		void frmReportFilter_Resize(object sender, EventArgs e)
		{
			int i = 0;
		}

		new public void Load(DataRow drReport, DataRow drFilter)
		{
			this.drReport = drReport;
			this.drFilter = drFilter;

			this.LoadFilterInfo();
			this.BuildControl();
			this.BindingLanguage();

			Common.ScaterMemvar(this, ref drFilter);

			this.ShowDialog();
		}

		private void LoadFilterInfo()
		{
			string strReport_ID = (string)drReport["Report_ID"];
			string strReport_ID_Filter = (string)drReport["Report_ID_Filter"]; //Kế thừa ReportFilter của 1 report khác

			System.Collections.Hashtable htParameter = new System.Collections.Hashtable();
			htParameter.Add("REPORT_ID", strReport_ID);
			htParameter.Add("REPORT_ID_FILTER", strReport_ID_Filter);

			dtFilter = SQLExec.ExecuteReturnDt("sp_GetReportFilter", htParameter, CommandType.StoredProcedure);

			FilterInfo filterInfo;
			foreach (DataRow dr in dtFilter.Rows)
			{
				filterInfo = new FilterInfo();
				filterInfo.Filter_ID = (string)dr["Filter_ID"];
				filterInfo.Filter_Name = (string)dr["Filter_Name"];
				filterInfo.Filter_Label = (string)dr["Filter_Label"];
				filterInfo.Default_Value = (string)dr["Default_Value"];
				filterInfo.Default_Value_Name = (string)dr["Default_Value_Name"];
				filterInfo.Width = (int)dr["Width"];
				filterInfo.Type = (string)dr["Type"];
				filterInfo.InputMask = (string)dr["InputMask"];
				filterInfo.Scale = Convert.ToInt16(dr["Scale"]);
				filterInfo.Col = (int)dr["Col"];
				filterInfo.Row = (int)dr["Row"];
				filterInfo.Require = (bool)dr["Require"];
				filterInfo.Is_MultiLookup = dr.Table.Columns.Contains("Is_MultiLookup") ? (bool)dr["Is_MultiLookup"] : false;
				filterInfo.Visible = (bool)dr["Visible"];
				filterInfo.Column_Lookup = (string)dr["Column_Lookup"];
				//filterInfo.Table_Lookup = (string)dr["Table_Lookup"];
				//filterInfo.Column_Lookup_Name = (string)dr["Column_Lookup_Name"];
				filterInfo.LookupKeyFilter = (string)dr["LookupKeyFilter"];
				filterInfo.LookupKeyValid = (string)dr["LookupKeyValid"];

				dicFilterInfo.Add((string)dr["Filter_ID"], filterInfo);
			}
		}

		private void BuildControl()
		{
			rsLabel lblFilter_Label;
			Control ctrlFilter_ID;

			//Chiều rộng của một col
			iCol_Width = iLeft + iFilter_Label_Width + iFilter_ID_Width + iFilter_Name_Width;
			int iMaxRow = (int)Common.MaxDCValue(dtFilter, "Row");
			int iMaxCol = (int)Common.MaxDCValue(dtFilter, "Col");

			foreach (FilterInfo filterInfo in dicFilterInfo.Values)
			{
				if (filterInfo.Visible == false)
					continue;

				//Filter_Label
				lblFilter_Label = new rsLabel();
				lblFilter_Label.AutoSize = true;
				lblFilter_Label.Parent = this;
				lblFilter_Label.Name = "lbl" + filterInfo.Filter_ID;
				lblFilter_Label.Text = filterInfo.Filter_Label;
				if (filterInfo.Filter_Label != string.Empty) //Hải sửa: nếu không có label thì kô cần Tag
					lblFilter_Label.Tag = filterInfo.Filter_ID;

				//Filter_ID
				switch (Columns.GetColumnType(filterInfo.Type))
				{
					case enuColumnType.TextBox:
						ctrlFilter_ID = new rsTextBox();
						ctrlFilter_ID.Name = "txt" + filterInfo.Filter_ID;

						////Neu la multi lookup
						if (filterInfo.Is_MultiLookup)
						{
							ctrlFilter_ID_Btn = new rsButton();
							ctrlFilter_ID_Btn.Name = "btn" + filterInfo.Filter_ID;
							ctrlFilter_ID_Btn.Text = "..";
							ctrlFilter_ID_Btn.Size = new Size(30, 20);
							ctrlFilter_ID_Btn.Click += new EventHandler(ctrlFilter_ID_Btn_Click);

						}
						else
						{
							ctrlFilter_ID.Validating += new CancelEventHandler(ctrlFilter_Validating);
						}
						break;
					case enuColumnType.ComboBox:
						ctrlFilter_ID = new rsComboBox();
						ctrlFilter_ID.Name = "cbo" + filterInfo.Filter_ID;
						((ComboBox)ctrlFilter_ID).SelectedIndexChanged += new EventHandler(ctrlFilter_SelectedIndexChanged);
						break;
					case enuColumnType.CheckBox:
						ctrlFilter_ID = new rsCheckbox();
						ctrlFilter_ID.Name = "chk" + filterInfo.Filter_ID;
						ctrlFilter_ID.Text = string.Empty;
						break;
					case enuColumnType.Numeric:
						ctrlFilter_ID = new rsTextBoxNumber();
						ctrlFilter_ID.Name = "num" + filterInfo.Filter_ID;
						break;
					case enuColumnType.DateTime:
						ctrlFilter_ID = new rsDateTime();
						ctrlFilter_ID.Name = "dte" + filterInfo.Filter_ID;
						break;
					case enuColumnType.Enum:
						ctrlFilter_ID = new rsTextBoxEnum();
						ctrlFilter_ID.Name = "txt" + filterInfo.Filter_ID;
						((rsTextBoxEnum)ctrlFilter_ID).InputMask = filterInfo.InputMask;
						break;
					case enuColumnType.LabelName:
						ctrlFilter_ID = new rsLabelName();
						ctrlFilter_ID.Name = "lbt" + filterInfo.Filter_ID;
						ctrlFilter_ID.ForeColor = Color.Blue;
						break;
				
					default:
						ctrlFilter_ID = new rsTextBox();
						break;
				}

				ctrlFilter_ID.Parent = this;

				//Hải sửa cho trường hợp CheckBox
				if (Columns.GetColumnType(filterInfo.Type) == enuColumnType.CheckBox)
				{
					((CheckBox)ctrlFilter_ID).Checked = filterInfo.Default_Value.StartsWith("1");
					((CheckBox)ctrlFilter_ID).AutoSize = true;
					((CheckBox)ctrlFilter_ID).ForeColor = Color.Tomato;
					ctrlFilter_ID.Text = filterInfo.Default_Value_Name;
					filterInfo.Default_Value_Name = string.Empty;
				}
				//Kiểm tra cho ComboBox
				if (Columns.GetColumnType(filterInfo.Type) == enuColumnType.ComboBox)
				{
					((ComboBox)ctrlFilter_ID).DropDownStyle = ComboBoxStyle.DropDownList;
					((ComboBox)ctrlFilter_ID).FlatStyle = FlatStyle.Popup;
					ctrlFilter_ID.Text = filterInfo.Default_Value;
					ctrlFilter_ID.Tag = filterInfo.Filter_ID;

					if (filterInfo.Is_MultiLookup)
					{
						ctrlFilter_ID_Lbt = new rsLabelName();
						ctrlFilter_ID_Lbt.Name = "lbt" + filterInfo.Filter_ID;
						ctrlFilter_ID_Lbt.Text = "...";
						ctrlFilter_ID_Lbt.Size = new Size(30, 20);
						((rsLabelName)ctrlFilter_ID_Lbt).Cursor = Cursors.Hand;
						((rsLabelName)ctrlFilter_ID_Lbt).Font = new Font(((rsLabelName)ctrlFilter_ID_Lbt).Font, FontStyle.Bold);
						
						ctrlFilter_ID_Lbt.Click += new EventHandler(ctrlFilter_ID_Lbt_Click);
						
					}
				}
				else
				{
					ctrlFilter_ID.Text = filterInfo.Default_Value;
					ctrlFilter_ID.Tag = filterInfo.Filter_ID;
				}

				ctrlFilter_ID.TabIndex = (filterInfo.Row) * iMaxCol + filterInfo.Col;

				//Filter_Name: la 1 phan cua ctrlFilter_ID do can phai lien ket khi Lookup
				if (filterInfo.Filter_Name != string.Empty)
				{
					filterInfo.lbtName.Parent = this;
					filterInfo.lbtName.Name = "lbt" + filterInfo.Filter_Name;
					//filterInfo.lbtName.Tag = filterInfo.Filter_Name;
					filterInfo.lbtName.Text = filterInfo.Default_Value_Name;
				}

				if (Columns.GetColumnType(filterInfo.Type) == enuColumnType.ComboBox && filterInfo.Filter_ID == "THOI_GIAN")
				{
					((ComboBox)ctrlFilter_ID).Items.Clear();
					((ComboBox)ctrlFilter_ID).Items.AddRange(new string[] { "1- Ngày hiện tại", "2- Tháng hiện tại", "3- Quý hiện tại", "4- Năm hiện tại" });

					if (filterInfo.Default_Value != "")
						((ComboBox)ctrlFilter_ID).Items.Add(filterInfo.Default_Value);

					((ComboBox)ctrlFilter_ID).SelectedIndex = 0;
				}

				//Filter_Label
				lblFilter_Label.Top = iTop + (filterInfo.Row - 1) * 20 + (filterInfo.Row - 1) * iRow_Distance;//ctrlFilter = 20
				lblFilter_Label.Left = iLeft + (filterInfo.Col - 1) * iCol_Width;

				//Filter_ID
				ctrlFilter_ID.Top = lblFilter_Label.Top;
				ctrlFilter_ID.Left = lblFilter_Label.Left + iFilter_Label_Width;
				ctrlFilter_ID.Width = filterInfo.Width;
				if (filterInfo.Is_MultiLookup)
				{
					if (ctrlFilter_ID_Btn != null)
					{
						ctrlFilter_ID_Btn.Parent = this;
						ctrlFilter_ID_Btn.Top = lblFilter_Label.Top;
						ctrlFilter_ID_Btn.Left = lblFilter_Label.Left + iFilter_Label_Width + ctrlFilter_ID.Width;
					}
					if (ctrlFilter_ID_Lbt != null)
					{
						ctrlFilter_ID_Lbt.Parent = this;
						ctrlFilter_ID_Lbt.Top = lblFilter_Label.Top;
						ctrlFilter_ID_Lbt.Left = lblFilter_Label.Left + iFilter_Label_Width + ctrlFilter_ID.Width;
					}
				}

				//Filter_Name
				filterInfo.lbtName.Top = ctrlFilter_ID.Top + (ctrlFilter_ID.Height - lblFilter_Label.Height) / 2;
				filterInfo.lbtName.Left = ctrlFilter_ID.Left + ctrlFilter_ID.Width + 5;

				//Neu Filter_Name dai qua thi xuong dong
				if (filterInfo.lbtName.Right > this.Right)
				{
					filterInfo.lbtName.AutoSize = false;
					filterInfo.lbtName.Width = this.Right - filterInfo.lbtName.Left - 20;

					int iWidth = filterInfo.lbtName.CreateGraphics().MeasureString(filterInfo.lbtName.Text, filterInfo.lbtName.Font).ToSize().Width;
					filterInfo.lbtName.Height = filterInfo.lbtName.Font.Height * Convert.ToInt32((float)iWidth / filterInfo.lbtName.Width + 0.499);

					filterInfo.lbtName.Top = ctrlFilter_ID.Top + 4;
					filterInfo.lbtName.TextAlign = ContentAlignment.TopLeft;
					filterInfo.lbtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
				}

				if (iBotton < ctrlFilter_ID.Bottom)
					iBotton = ctrlFilter_ID.Bottom;

				if (iBotton < filterInfo.lbtName.Bottom)
					iBotton = filterInfo.lbtName.Bottom;
			}

			lblTitle.Left = iLeft;
			txtTitle.Left = iLeft + iFilter_Label_Width;

			this.Height += iBotton - txtTitle.Top + iRow_Distance;

			int iWidth1 = iMaxCol * iCol_Width + iRight;
			int iWidth2 = txtTitle.Left + txtTitle.Width + iRight;
			this.Width = iWidth1 < iWidth2 ? iWidth2 : iWidth1;
		}

		private RosySystem.Customize.frmView GetLookupForm(string Table_Lookup)
		{
			string strAsl = (string)SQLExec.ExecuteReturnValue("SELECT Assembly FROM R00LOOKUP WHERE Table_Lookup = '" + Table_Lookup + "'");

			string[] arrStr = strAsl.Split(':');

			if (strAsl != string.Empty)
			{
				if (arrStr.Length != 2)
				{
					Common.MsgCancel("Định dạng Assembly = " + strAsl + " không đúng");
					return new RosySystem.Customize.frmView();
				}

				string strAssembly = string.Empty;
				string strType = string.Empty;

				strAssembly = arrStr[0];
				strType = "Rosy." + arrStr[1];

				Assembly asl = Assembly.Load(strAssembly);
				Type type = asl.GetType(strType);

				RosySystem.Customize.frmView frm = (RosySystem.Customize.frmView)Activator.CreateInstance(type);

				return frm;
			}
			else
			{
				return new RosySystem.Public.frmQuickLookup();
			}
		}

		private bool FormCheckValid()
		{
			if (DataTool.SQLCheckExist("sys.Objects", "Name", "sp_CheckPermissionTk"))
			{
				foreach (DataColumn dc in drFilter.Table.Columns)
				{
					if (dc.ColumnName == "TK" && drFilter[dc] != DBNull.Value && (string)drFilter[dc] != string.Empty)
					{
						Hashtable htPara = new Hashtable();
						htPara.Add("MEMBER_ID", Element.sysUser_Id);
						htPara.Add("TK", drFilter[dc]);

						DataTable dtPermissionTk = SQLExec.ExecuteReturnDt("sp_CheckPermissionTk", htPara, CommandType.StoredProcedure);

						if (!(bool)(dtPermissionTk.Rows[0])["Allow_View"])
						{
							Common.MsgCancel("Người dùng [" + Element.sysUser_Id + "] không được xem tài khoản [" + (string)drFilter[dc] + "]");
							return false;
						}
					}
				}
			}

			if (DataTool.SQLCheckExist("sys.Objects", "Name", "sp_CheckPermissionCbNv"))
			{
				foreach (DataColumn dc in drFilter.Table.Columns)
				{
					if (dc.ColumnName == "MA_CBNV" && drFilter[dc] != DBNull.Value && (string)drFilter[dc] != string.Empty)
					{
						Hashtable htPara = new Hashtable();
						htPara.Add("MEMBER_ID", Element.sysUser_Id);
						htPara.Add("MA_CBNV", drFilter[dc]);

						DataTable dtPermissionCbNv = SQLExec.ExecuteReturnDt("sp_CheckPermissionCbNv", htPara, CommandType.StoredProcedure);

						if (!(bool)(dtPermissionCbNv.Rows[0])["Allow_View"])
						{
							Common.MsgCancel("Người dùng [" + Element.sysUser_Id + "] không được xem mã CbNv [" + (string)drFilter[dc] + "]");
							return false;
						}
					}
				}
			}

			return true;
		}

		#endregion

		#region Sự kiện

		void ctrlFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			Control ctrlFilter_ID = ((Control)sender);

			string strFilter_ID = (string)((Control)sender).Tag;
			string strValue = ctrlFilter_ID.Text.Trim();

			Hashtable htPara = new Hashtable();
			htPara.Add("TYPE", strValue.Substring(0, 1));
			htPara.Add("NAM", DateTime.Now.Year);
			htPara.Add("MA_DVCS", Element.sysMa_DvCs);

			string strSQLExec = @"SELECT *
									FROM vw_ThoiGian
									WHERE Type = @Type AND Nam = @Nam AND Ma_DvCs = @Ma_DvCs";

			DataTable dtThoiGian = SQLExec.ExecuteReturnDt(strSQLExec, htPara, CommandType.Text);

			if (dtThoiGian != null && dtThoiGian.Rows.Count > 0 && this.FindForm().Controls.ContainsKey("dteNgay_Ct1") && this.FindForm().Controls.ContainsKey("dteNgay_Ct2"))
			{
				((rsDateTime)this.Controls["dteNgay_Ct1"]).Text = dtThoiGian.Rows[0]["Ngay_Ct1"].ToString();
				((rsDateTime)this.Controls["dteNgay_Ct2"]).Text = dtThoiGian.Rows[0]["Ngay_Ct2"].ToString();
			}
		}

		void ctrlFilter_ID_Lbt_Click(object sender, EventArgs e)
		{
			Control ctrlFilter_ID = ((Control)sender);
			string strFilter_ID = ctrlFilter_ID.Name.Replace("lbt", "");
			FilterInfo filterInfo = dicFilterInfo[strFilter_ID];

			string strLookupID = filterInfo.Column_Lookup;

			string strValue = "";
			bool bRequire = true;
			string strKey = filterInfo.LookupKeyFilter;

			if (strFilter_ID == "THOI_GIAN" && this.FindForm().Controls.ContainsKey("cboThoi_Gian"))
			{
				string strThoi_Gian = this.Controls["cboThoi_Gian"].Text.Substring(0, 1);
				strKey = "NAM = '" + Element.sysWorkingYear + "' AND Ma_DvCs = '" + Element.sysMa_DvCs + "'";
				switch (strThoi_Gian)
				{
					case "3":
						strKey += " AND Type = 'Q'";
						break;
					case "4":
						strKey += " AND Type = 'N'";
						break;
					default:
						strKey += " AND Type = 'T'";
						break;
				}
			}

			DataRow drLookup = Lookup.ShowLookup(strLookupID, strValue, bRequire, strKey, "");

			if (drLookup != null)
			{
				if (this.Controls.ContainsKey("lbt" + strFilter_ID))
				{
					if (this.FindForm().Controls.ContainsKey("dteNgay_Ct1") && this.FindForm().Controls.ContainsKey("dteNgay_Ct2"))
					{
						((rsDateTime)this.Controls["dteNgay_Ct1"]).Text = drLookup["Ngay_Ct1"].ToString();
						((rsDateTime)this.Controls["dteNgay_Ct2"]).Text = drLookup["Ngay_Ct2"].ToString();
					}

				}
			}
		}

		void ctrlFilter_Validating(object sender, CancelEventArgs e)
		{
			Control ctrlFilter_ID = ((Control)sender);

			string strFilter_ID = (string)((Control)sender).Tag;
			FilterInfo filterInfo = dicFilterInfo[strFilter_ID];
			string strValue = ctrlFilter_ID.Text.Trim();
			string strKey = filterInfo.LookupKeyFilter;

			if (filterInfo.Column_Lookup == string.Empty)
				return;

			string strColumn_Lookup_Name = DataTool.SQLGetNameByCode("R00LOOKUP", "ColumnID", "ColumnName_Lookup", filterInfo.Column_Lookup);

			//Bỏ kiểm tra cột Table_Lookup chuyển về dùng ColumnID
			//if (filterInfo.Table_Lookup == string.Empty)
			//    return;

			//RosySystem.Customize.frmView frmLookup = GetLookupForm(filterInfo.Table_Lookup);
			DataRow drLookup = Lookup.ShowLookup(filterInfo.Column_Lookup, strValue, filterInfo.Require, filterInfo.LookupKeyFilter, filterInfo.LookupKeyValid);

			if (filterInfo.Require && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				ctrlFilter_ID.Text = string.Empty;
				filterInfo.lbtName.Text = string.Empty;
			}
			else
			{
				ctrlFilter_ID.Text = ((string)drLookup[filterInfo.Column_Lookup]).Trim();
				filterInfo.lbtName.Text = ((string)drLookup[strColumn_Lookup_Name]).Trim();
			}
		}

		void ctrlFilter_ID_Btn_Click(object sender, EventArgs e)
		{
			Control ctrlFilter_ID = ((Control)sender);
			string strFilter_ID = ctrlFilter_ID.Name.Replace("btn", "");
			FilterInfo filterInfo = dicFilterInfo[strFilter_ID];

			string strLookupID = filterInfo.Column_Lookup;
			string strValue = "";
			bool bRequire = true;
			string strKey = filterInfo.LookupKeyFilter;
			
			//Lấy Value từ TextBox
			if (this.Controls.ContainsKey("txt" + strFilter_ID))
				strValue = this.Controls["txt" + strFilter_ID].Text;

			DataRow drLookup = Lookup.ShowMultiLookup(strLookupID, strValue, bRequire, strKey, "");
			
			if (drLookup != null)
			{
				if (this.Controls.ContainsKey("txt" + strFilter_ID))
					this.Controls["txt" + strFilter_ID].Text = drLookup["MultiSelectValue"].ToString();
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			Common.GatherMemvar(this, ref drFilter);

			if (this.FormCheckValid())
			{
				foreach (DataColumn dc in drFilter.Table.Columns)
				{
					string strColumnName = dc.ColumnName;
					if (dicFilterInfo.ContainsKey(strColumnName) && dicFilterInfo[strColumnName].Visible == false)
						drFilter[strColumnName] = dicFilterInfo[strColumnName].Default_Value;
				}

				isAccept = true;

				if (drFilter.Table.Columns.Contains("Ngay_Ct1"))
					Element.sysNgay_Ct1 = (DateTime)drFilter["Ngay_Ct1"];

				if (drFilter.Table.Columns.Contains("Ngay_Ct2"))
					Element.sysNgay_Ct2 = (DateTime)drFilter["Ngay_Ct2"];

				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

		#endregion
	}

	class FilterInfo
	{
		public string Filter_ID = string.Empty;
		public string Filter_Name = string.Empty;
		public string Filter_Label = string.Empty;
		public string Default_Value = string.Empty;
		public string Default_Value_Name = string.Empty;
		public string Type = "T";
		public string InputMask = string.Empty;
		public int Width = 120;
		public int Scale = 0;
		public int Col = 1;
		public int Row = 1;
		public bool Require = true;
		public bool Is_MultiLookup = true;
		public bool Visible = true;
		public string Column_Lookup = string.Empty;
		//public string Table_Lookup = string.Empty;
		//public string Column_Lookup_Name = string.Empty;
		public string LookupKeyFilter = string.Empty;
		public string LookupKeyValid = string.Empty;
		public rsLabelName lbtName = new rsLabelName();

		public FilterInfo()
		{
			lbtName.AutoSize = true;
			lbtName.Text = Default_Value_Name;
		}
	}
}