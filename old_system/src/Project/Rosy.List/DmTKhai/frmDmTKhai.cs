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
using System.Collections;

namespace RosyList
{
	public partial class frmDmTKhai : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmTKhai;
		DataRow drCurrent;
		BindingSource bdsDmTKhai = new BindingSource();
		rsDataGridView dgvDmTKhai = new rsDataGridView();
        public bool bLookupByGroup = false;
		public bool bFind = false;
		public string strLoai_TKhai = "0"; //0-NK, 1-XK
		#endregion

		#region Contructor

		public frmDmTKhai()
		{
			InitializeComponent(); 

			this.dgvDmTKhai.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmTKhai_CellMouseDoubleClick);
			this.btImport.Click +=new EventHandler(btImport_Click);
		}

		public override void Load()
		{
			
			Build();
			FillData("0");
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}
		public void Load(string strLoai_TKhai)
		{

			this.strLoai_TKhai = strLoai_TKhai;

			
			Build();
			FillData(strLoai_TKhai);
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}
        public override void LoadLookup()
        {
           this.Load();
        }
		
		#endregion

		#region Build, FillData
		private void Build()
		{
			string strZone = "DMTKHAIHQ";
			

			dgvDmTKhai.Dock = DockStyle.Fill;
			dgvDmTKhai.strZone = strZone;
			dgvDmTKhai.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmTKhai);
		}
		private void Language()
		{
			if (dgvDmTKhai.Columns.Contains("LOAI_TKHAI"))
				dgvDmTKhai.Columns["LOAI_TKHAI"].HeaderText = "Loại TKhai";
			if (dgvDmTKhai.Columns.Contains("NGAY_TDDKY"))
				dgvDmTKhai.Columns["NGAY_TDDKY"].HeaderText = "Ngày thay đổi ĐKý";
			if (dgvDmTKhai.Columns.Contains("VAN_DON"))
				dgvDmTKhai.Columns["VAN_DON"].HeaderText = "Vận đơn";
			if (dgvDmTKhai.Columns.Contains("DIA_DIEM_DH"))
				dgvDmTKhai.Columns["DIA_DIEM_DH"].HeaderText = "Địa điểm dở hàng";
			if (dgvDmTKhai.Columns.Contains("DIA_DIEM_XH"))
				dgvDmTKhai.Columns["DIA_DIEM_XH"].HeaderText = "Địa điểm xếp hàng";
			if (dgvDmTKhai.Columns.Contains("NGAY_HANG_DEN"))
				dgvDmTKhai.Columns["NGAY_HANG_DEN"].HeaderText = "Ngày hàng đến";
			if (dgvDmTKhai.Columns.Contains("TRONG_LUONG"))
				dgvDmTKhai.Columns["TRONG_LUONG"].HeaderText = "Trọng lượng";
			if (dgvDmTKhai.Columns.Contains("TIEN_NT"))
				dgvDmTKhai.Columns["TIEN_NT"].HeaderText = "Trị giá Nt";
			if (dgvDmTKhai.Columns.Contains("TIEN"))
				dgvDmTKhai.Columns["TIEN"].HeaderText = "Trị giá VNĐ";
			if (dgvDmTKhai.Columns.Contains("TIEN_BHIEM"))
				dgvDmTKhai.Columns["TIEN_BHIEM"].HeaderText = "Tiền BHiểm";
            if (dgvDmTKhai.Columns.Contains("TTIEN"))
                dgvDmTKhai.Columns["TTIEN"].HeaderText = "Tổng thuế";
            if (dgvDmTKhai.Columns.Contains("NGAY_CAP_PHEP"))
                dgvDmTKhai.Columns["NGAY_CAP_PHEP"].HeaderText = "Ngày cấp phép";
            if (dgvDmTKhai.Columns.Contains("NGAY_HT_KTRA"))
                dgvDmTKhai.Columns["NGAY_HT_KTRA"].HeaderText = "Ngày hoàn thành KTra";
           
        }
		
		
		private void FillData(string strLoai_TKhai)
		{
			string strSQLExec = string.Empty;

            string strKey = (this.strLookupKeyFilter == null ? string.Empty : this.strLookupKeyFilter);

			
			if (this.strLookupKeyFilter == null || this.strLookupKeyFilter == string.Empty)
			{
				strSQLExec = "SELECT T1.*, T2.Ten_Dt, T3.Ten_Dt AS Ten_Dt_Hq, So_Hd, " +
					" CASE WHEN LEN(Create_Log) > 15 THEN DBO.fn_GetDate('20'+SUBSTRING(Create_Log,5,2) ,SUBSTRING(Create_Log,3,2),LEFT(Create_Log,2)) ELSE '19000101' END AS NGAY_TAO, " +
					" SUBSTRING(Create_Log,15,20) AS CREATE_ " +
					" FROM R81DMTOKHAIHQ T1 " +
					" LEFT JOIN (SELECT Ma_Dt, Ten_Dt FROM R81DMDT) T2 ON T1.Ma_Dt = T2.Ma_Dt" +
						" LEFT JOIN (SELECT Ma_Dt, Ten_Dt FROM R81DMDT) T3 ON T1.Ma_Dt_Hq = T3.Ma_Dt " +
						" LEFT JOIN (SELECT Ma_Hd, So_Hd FROM R81DMHD) T4 ON T1.Ma_Hd = T4.Ma_Hd " +
						" ORDER BY Ngay_TKhai DESC,SO_TKhai DESC";
			}
			else
            {
				strKey = "Loai_TKhai = '" + strLoai_TKhai + "'";
				strSQLExec = "SELECT T1.*, T2.Ten_Dt, T3.Ten_Dt AS Ten_Dt_Hq, So_Hd, " +
					" CASE WHEN LEN(Create_Log) > 15 THEN DBO.fn_GetDate('20'+SUBSTRING(Create_Log,5,2) ,SUBSTRING(Create_Log,3,2),LEFT(Create_Log,2)) ELSE '19000101' END AS NGAY_TAO, " +
					" SUBSTRING(Create_Log,15,20) AS CREATE_ " +
					" FROM R81DMTOKHAIHQ T1 " +
					" LEFT JOIN (SELECT Ma_Dt, Ten_Dt FROM R81DMDT) T2 ON T1.Ma_Dt = T2.Ma_Dt" +
					" LEFT JOIN (SELECT Ma_Dt, Ten_Dt FROM R81DMDT) T3 ON T1.Ma_Dt_Hq = T3.Ma_Dt " +
					" LEFT JOIN (SELECT Ma_Hd, So_Hd FROM R81DMHD) T4 ON T1.Ma_Hd = T4.Ma_Hd WHERE " + strKey +
					" ORDER BY Ngay_TKhai DESC,SO_TKhai DESC";
			}
				


			dtDmTKhai = SQLExec.ExecuteReturnDt(strSQLExec);
			

			bdsDmTKhai.DataSource = dtDmTKhai;
			dgvDmTKhai.DataSource = bdsDmTKhai;
			bdsDmTKhai.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmTKhai;
			ExportControl = dgvDmTKhai;

			if (this.isLookup)
				this.MoveToLookupValue();
		}
	
		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmTKhai.Rows.Count - 1; i++)
				if (((string)dtDmTKhai.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmTKhai.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmTKhai.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Edit"));
				return;
			}

			//Copy hang hien tai            
			if (bdsDmTKhai.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmTKhai.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmTKhai.NewRow();
			
			frmDmTKhai_Edit frmEdit = new frmDmTKhai_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);
			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmTKhai.Position >= 0)
						dtDmTKhai.ImportRow(drCurrent);
					else
						dtDmTKhai.Rows.Add(drCurrent);

					bdsDmTKhai.Position = bdsDmTKhai.Find("SO_TKHAI", drCurrent["SO_TKHAI"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmTKhai.Current).Row);

				dtDmTKhai.AcceptChanges();
			}
			else
				dtDmTKhai.RejectChanges();
			
			
			
		
			
		}

		public override void Delete()
		{
			if (bdsDmTKhai.Position < 0)
				return;

			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmTKhai.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R81DMTOKHAIHQ", drCurrent))
			{
				bdsDmTKhai.RemoveAt(bdsDmTKhai.Position);
				dtDmTKhai.AcceptChanges();
			}
		}

        

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmTKhai == null || bdsDmTKhai.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmTKhai.Current).Row;
			DataTable dtTemp = dtDmTKhai.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void EnterProcess()
		{
			if (bdsDmTKhai.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmTKhai.Current).Row;
				this.Close();
			}
			else if (EnterValid())
			{
                drLookup = ((DataRowView)bdsDmTKhai.Current).Row;
                this.Close();


            }
		}
		

	

		#endregion 

		#region Su kien

		void dgvDmTKhai_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMTOKHAIHQ", dtDmTKhai);
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			Language();
		}
	}
}