using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Public;
using RosySystem.Common;
using System.IO;

namespace RosyModule.ScaleBarcodeTMN
{
	public partial class frmVoucher_Scale_View : RosySystem.Customize.frmView
	{
		#region Fields

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
		
		#endregion

		#region Contructor

		public frmVoucher_Scale_View()
		{
			InitializeComponent();

			this.Resize += new EventHandler(frmViewPh_Resize);
			this.KeyDown += new KeyEventHandler(KeyDownEvent);

			bdsViewPh.PositionChanged += new EventHandler(bdsViewPh_PositionChanged);

			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btDelete.Click += new EventHandler(btDelete_Click);
			btPreview.Click += new EventHandler(btPreview_Click);
			btPrint.Click += new EventHandler(btPrint_Click);
			btFilter.Click += new EventHandler(btFilter_Click);
			btExit.Click += new EventHandler(btExit_Click);
			btImport.Click += new EventHandler(btImport_Click);
			
			dgvViewPh.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvViewPh_CellFormatting);
			dgvViewPh.Enter += new EventHandler(dgvViewPh_Enter);
			dgvViewCt.Enter += new EventHandler(dgvViewCt_Enter);
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
			this.BindingTong_Tien();

			this.FormLayout();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			string strMa_Ct = strMa_Ct_List.Split(',')[0];

			drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);

			//dgvViewPh 
			dgvViewPh.ReadOnly = true;
			dgvViewPh.strZone = (string)drDmCt["Zone_ViewPh"];

			dgvViewPh.BuildGridView(false);

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
			
			if (!drFilter.Table.Columns.Contains("User_LogIn"))
				drFilter.Table.Columns.Add(new DataColumn("User_LogIn", typeof(string)));

			if (!drFilter.Table.Columns.Contains("Ma_DvCs"))
				drFilter.Table.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));

			drFilter["Table_PH"] = drDmCt["Table_PH"];
			drFilter["Table_Ct"] = drDmCt["Table_Ct"];
			drFilter["Ma_DvCs"] = Element.sysMa_DvCs;
			drFilter["User_LogIn"] = Element.sysUser_Id;

			dsVoucher.Clear();

            dsVoucher = SQLExec.ExecuteReturnDs("sp_GetVoucher_Scale_CtTLB_KKV", drFilter, CommandType.StoredProcedure);
			
			dtViewPh = dsVoucher.Tables[0];
			dtViewPh.TableName = (string)drDmCt["Table_Ph"];

			dtViewCt = dsVoucher.Tables[1];
			dtViewCt.TableName = (string)drDmCt["Table_Ct"];

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

		private void Filter()
		{
			DataTable dtFilter = new DataTable();

			dtFilter.Columns.Add(new DataColumn("Table_PH", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Table_Ct", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Ct_List", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("So_Ct1", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("So_Ct2", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tien1", typeof(double)));
			dtFilter.Columns.Add(new DataColumn("Tien2", typeof(double)));
			dtFilter.Columns.Add(new DataColumn("Dien_Giai", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Tte", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tk", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("No_Co", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Tk_Du", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Thue", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Hd", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Km", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Bp", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Vt_Sp", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Nvu", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Kho", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Vt", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Dt_CbNv", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Job", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_Kv", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Table", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();

			//Set Default 
			drFilter["Ma_Ct_List"] = strMa_Ct_List;
			drFilter["Ngay_Ct1"] = Element.sysNgay_Ct1;
			drFilter["Ngay_Ct2"] = Element.sysNgay_Ct2;
			drFilter["Table_PH"] = (string)drDmCt["Table_Ph"];
			drFilter["Table_Ct"] = (string)drDmCt["Table_Ct"];
			drFilter["Ma_DvCs"] = Element.sysMa_DvCs;

			frmFilter frm = new frmFilter();
			frm.Load(drFilter);

			if (frm.isAccept)
			{
				this.FillData(drFilter);

				Element.sysNgay_Ct1 = Convert.ToDateTime(drFilter["Ngay_Ct1"]);
				Element.sysNgay_Ct2 = Convert.ToDateTime(drFilter["Ngay_Ct2"]);
			}
		}

		private void Print(bool bPreview)
		{
			if (Common.MsgCancel("Phần mềm chưa hổ trợ chức năng này!"))
				return;

			if (bdsViewPh.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			DataRow[] drArrPrint = dtViewPh.Select("Mark = true");
			bool bAcceptShowDialog = true;
			bool bInVisibleNextPrint = false;

			if (drArrPrint.Length > 1)
			{
				for (int i = 0; i < drArrPrint.Length; i++)
				{
					drCurrent = drArrPrint[i];

					if (i == 0)
					{
						bAcceptShowDialog = Voucher.Print(drCurrent["Stt"].ToString(), bPreview, true, ref bInVisibleNextPrint);
					}
					else
					{
						if (bAcceptShowDialog)
							bAcceptShowDialog = Voucher.Print(drCurrent["Stt"].ToString(), bPreview, false, ref bInVisibleNextPrint);
						else
							break;
					}

					if (bAcceptShowDialog)
					{
						drCurrent["Mark"] = false;
					}
				}
			}
			else
				Voucher.Print(drCurrent["Stt"].ToString(), bPreview, true, ref bInVisibleNextPrint);
		}

		private void Design()
		{
			if (Common.MsgCancel("Phần mềm chưa hổ trợ chức năng này!"))
				return;

			string strMa_Ct = strMa_Ct_List.Split(',')[0];
			string strReportTag = string.Empty;

			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", strMa_Ct);
			string strReport_File = (string)drDmCt["Report_File"];

			RosyReport.frmReportDesign frm = new RosyReport.frmReportDesign();
			frm.Load(strReport_File);
		}

		private void BindingTong_Tien()
		{
			
		}

		private void FormLayout()
		{
			dgvViewPh.Location = new Point(3, 3);
			dgvViewPh.Width = this.Width - 12;
			dgvViewPh.Height = (int)(0.5 * this.Height);

			dgvViewCt.Location = new Point(dgvViewPh.Left, dgvViewPh.Bottom);
			dgvViewCt.Width = this.Width - 12;
			dgvViewCt.Height = this.Height - dgvViewPh.Height - pnlTTien.Height - 49;

		}
		
		private void Mark()
		{
			if (bdsViewPh.Position < 0)
				return;

			if (dgvViewPh.Columns[dgvViewPh.CurrentCell.ColumnIndex].Name != "LOCKED")
			{
				if (dgvViewPh.Columns.Contains("Mark"))
				{
					drCurrent = ((DataRowView)bdsViewPh.Current).Row;

					drCurrent["Mark"] = !(bool)drCurrent["Mark"];
					dgvViewPh.Refresh();
				}
			}
		}

		private void DanhSoCt()
		{
			if (bdsViewPh.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;

			string strStt = string.Empty;
			string strMa_Ct = (string)drCurrent["Ma_Ct"];
			string strSo_Ct = string.Empty;

			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);

			frmDanhSo_Ct frm = new frmDanhSo_Ct();
			frm.Load();

			if (frm.isAccept)
			{
				int iSo_Ct = Convert.ToInt32(frm.numSo_Ct.Value);
				string strFormat_Text = frm.txtSo_Ct_Format.Text;

				int iPrefix = strFormat_Text.IndexOf('#');
				int iSuffix = strFormat_Text.LastIndexOf('#') + 1;

				string strPrefix = strFormat_Text.Substring(0, iPrefix);
				string strSuffix = strFormat_Text.Substring(iSuffix);
				string strMidText = strFormat_Text.Substring(iPrefix, strFormat_Text.Length - strPrefix.Length - strSuffix.Length);

				for (int i = 0; i < bdsViewPh.Count; i++)
				{
					bdsViewPh.Position = i;

					drCurrent = ((DataRowView)bdsViewPh.Current).Row;
					strStt = (string)drCurrent["Stt"];

					strSo_Ct = strPrefix + iSo_Ct.ToString().PadLeft(strMidText.Length, '0') + strSuffix;

					string strSQLExec = @"
							DECLARE @So_Ct1 NVARCHAR(50), @Stt1 NVARCHAR(50)
							SELECT @So_Ct1 = @So_Ct, @Stt1 = @Stt";

					Hashtable htPara = new Hashtable();
					htPara["SO_CT"] = strSo_Ct;
					htPara["STT"] = strStt;

					if (drDmCt["Table_Ph"].ToString() != "")
						strSQLExec += " UPDATE " + drDmCt["Table_Ph"].ToString() + " SET So_Ct = @So_Ct1 WHERE Stt = @Stt1 ";

					if (drDmCt["Table_Ct"].ToString() != "")
						strSQLExec += " UPDATE " + drDmCt["Table_Ct"].ToString() + " SET So_Ct = @So_Ct1 WHERE Stt = @Stt1 ";

					if (SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
					{
						drCurrent["So_Ct"] = strSo_Ct;
					}

					iSo_Ct++;
				}
			}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsViewPh.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsViewPh.Position >= 0)
				drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			else
			{
				drCurrent = dtViewPh.NewRow();
				drCurrent["Ma_Ct"] = strMa_Ct_List.Split(',')[0];
				drCurrent["Stt"] = "0";
			}

			DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DMCT", "Ma_Ct", (string)drCurrent["Ma_Ct"]);

			string strMethodName = (string)drDmCt["Edit_Voucher_Method"];
			string[] arrStr = strMethodName.Split(':');
			if (arrStr.Length != 3)
			{
				Common.MsgCancel("Định dạng MethodName = " + strMethodName + " không đúng");
				return;
			}

			Assembly asl = Assembly.Load(arrStr[0]);
			Type type = asl.GetType(arrStr[1]);

			frmVoucher_Scale_Edit frmEdit = (frmVoucher_Scale_Edit)Activator.CreateInstance(type);
			frmEdit.Load(enuNew_Edit, drCurrent, dsVoucher);

			if (bdsViewPh.Find("Stt", frmEdit.drEdit["Stt"].ToString()) >= 0)
				bdsViewPh.Position = bdsViewPh.Find("Stt", frmEdit.drEdit["Stt"].ToString());
		}

		public override void Delete()
		{
						
			if (bdsViewPh.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			string strMa_Ct = ((string)drCurrent["Ma_Ct"]).Trim();
			string strStt = ((string)drCurrent["Stt"]).Trim();


			if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
				return;

			if (!Element.sysIs_Admin)
			{
				string strCreate_User = (string)drCurrent["Create_Log"];

				if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
				{
					string strUser_Allow = (string)SQLExec.ExecuteReturnValue("SELECT Member_ID_Allow FROM R00Member WHERE Member_ID = '" + Element.sysUser_Id + "'") + ",";

					if (!strUser_Allow.Contains("*,")) //Được phép sửa tất cả
					{
						if (!strUser_Allow.Contains(strCreate_User.Substring(14) + ","))
						{
							Common.MsgCancel("Không được xóa chứng từ do " + strCreate_User.Substring(14) + " lập, liên hệ với Admin!");
							return;
						}
					}
				}
			}

//            //Phieu tra lai barcode. Neu barcode do da duoc chuyen trang thai tu cho xu ly sang loai khac, thi khong cho phep xoa dong do
//            if (this.strMa_Ct_List.StartsWith("PNTLB"))
//            {
//                string strSQLExec = @"SELECT COUNT(T2.Barcode)
//										FROM R05CTN_BARCODE T1 JOIN R81DMBARCODE T2 ON T1.Barcode = T2.Barcode
//										WHERE T1.Stt = '" + strStt + "' AND T2.Is_Wait_Process = 0";

//                object objValue = SQLExec.ExecuteReturnValue(strSQLExec);
//                if (objValue != null && objValue.ToString() != string.Empty)
//                {
//                    if (Convert.ToInt32(objValue) != 0)
//                    {
//                        Common.MsgCancel("Phiếu này có một hoặc nhiều bó thép đã được xử lý.Không được xóa phiếu này.");
//                        return;
//                    }
//                }
//            }

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE"), "N"))
				return;

			if (Voucher.SQLDeleteCt(strStt, strMa_Ct))
			{
				bdsViewPh.RemoveAt(bdsViewPh.Position);
				dtViewPh.AcceptChanges();
			}
		}

		public override void EditHanTt()
		{
			return;
		}

		#endregion

		#region Event
		
		void frmViewPh_Resize(object sender, EventArgs e)
		{
			this.FormLayout();
		}

		void KeyDownEvent(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F9:
					this.Filter();
					break;

				case Keys.F7:
					switch (e.Modifiers)
					{
						case Keys.Shift:
							Design();
							break;

						case Keys.Control:
							Print(true);
							break;

						case Keys.None:
							Print(false);
							break;
					}
					break;

				case Keys.Space: //Nhan them
					Mark();

					break;

				case Keys.A:
					if (dgvViewPh.Columns.Contains("Mark"))
						if (e.Modifiers == Keys.Control)
						{
							for (int i = 0; i < dgvViewPh.RowCount; i++)
							{
								dgvViewPh.Rows[i].Cells["Mark"].Value = true;
							}

							dgvViewPh.Refresh();
						}

					break;

				case Keys.U:
					if (dgvViewPh.Columns.Contains("Mark"))
						if (e.Modifiers == Keys.Control)
						{
							for (int i = 0; i < dgvViewPh.RowCount; i++)
							{
								dgvViewPh.Rows[i].Cells["Mark"].Value = false;
							}

							dgvViewPh.Refresh();
						}

					break;
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F3 && e.Shift)
			{
				this.DanhSoCt();
				return;
			}
			else

				base.OnKeyDown(e);
		}

		void bdsViewPh_PositionChanged(object sender, EventArgs e)
		{
			if (bdsViewPh.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsViewPh.Current).Row;
			string strStt = (string)drCurrent["Stt"];

			bdsViewCt.Filter = "(Stt = '" + strStt + "')";
		}

		void btNew_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.New);
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.Edit);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			Delete();
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			Filter();
		}

		void btPreview_Click(object sender, EventArgs e)
		{
			this.Print(true);
		}

		void btPrint_Click(object sender, EventArgs e)
		{
			this.Print(false);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			
				Voucher.ImportExcel_Voucher();

				DataTable dtFilter = new DataTable();

				dtFilter.Columns.Add(new DataColumn("Table_PH", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Table_Ct", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Ct_List", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
				dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
				dtFilter.Columns.Add(new DataColumn("So_Ct1", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("So_Ct2", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Tien1", typeof(double)));
				dtFilter.Columns.Add(new DataColumn("Tien2", typeof(double)));
				dtFilter.Columns.Add(new DataColumn("Dien_Giai", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Tte", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Tk", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("No_Co", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Tk_Du", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Thue", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Hd", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Dt", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Km", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Bp", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Vt_Sp", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Nvu", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Kho", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Vt", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Dt_CbNv", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Job", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_Kv", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Table", typeof(string)));
				dtFilter.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));

				DataRow drFilter = dtFilter.NewRow();

				//Set Default 
				drFilter["Ma_Ct_List"] = strMa_Ct_List;
				drFilter["Ngay_Ct1"] = Element.sysNgay_Ct1;
				drFilter["Ngay_Ct2"] = DateTime.Now;
				drFilter["Table_PH"] = (string)drDmCt["Table_Ph"];
				drFilter["Table_Ct"] = (string)drDmCt["Table_Ct"];
				drFilter["Ma_DvCs"] = Element.sysMa_DvCs;

				this.FillData(drFilter);
			
		}

		void btExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		void dgvViewCt_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvViewPh_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvViewPh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.Value == null || e.Value == DBNull.Value)
				return;

			if (e.RowIndex < 0)
				return;

			if (dgvViewPh.Columns.Contains("Mark"))
			{
				if (dgvViewPh.Rows[e.RowIndex].Cells["Mark"].Value != null)
				{
					if ((bool)dgvViewPh.Rows[e.RowIndex].Cells["Mark"].Value == true)
					{
						e.CellStyle.BackColor = Color.FromArgb(255, 0, 0, 255);
					}
				}
			}
		}

		#endregion


	}
}
