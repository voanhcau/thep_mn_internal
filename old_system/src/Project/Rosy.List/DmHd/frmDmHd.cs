using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem;
using RosySystem.Public;
using System.IO;
using System.Collections;

namespace RosyList
{
	public partial class frmDmHd : RosyList.frmView
	{
		#region Khai bao bien
		DataTable dtDmHd;
		DataRow drCurrent;
		BindingSource bdsDmHd = new BindingSource();
		rsDataGridView dgvDmHd = new rsDataGridView();

		public string strMa_Nh_Hd = string.Empty;
		public bool bLookupByGroup = false;
		public bool bFind = false;

		#endregion 						

		#region Contructor
		public frmDmHd()
		{
			InitializeComponent();

			this.dgvDmHd.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmHd_CellMouseDoubleClick);
            this.dgvDmHd.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvDmHd_CellMouseClick);
			this.btImport.Click += new EventHandler(btImport_Click);
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

		public void Load(string strMa_Nh_Hd)
		{
			this.strMa_Nh_Hd = strMa_Nh_Hd;

			this.Load();
		}

		public override void LoadLookup()
		{
			if (!bLookupByGroup && Parameters.GetParaValue("ACCESS_DMHD").ToString() == "1") //Truy cap theo nhom
			{
				string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

				if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
				{
					if (this.strLookupValue == "/" || this.strLookupValue == @"\")
						strWhere = strLookupKeyFilter;
					else
						strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
				}

				DataTable dtFind = DataTool.SQLGetDataTable("R81DmHd", null, strWhere, null);

				if (dtFind.Rows.Count > 0)
				{
					strLookupKeyFilter = strWhere;
					bFind = true;
					this.Load();
				}
				else
					this.LoadLookupByGroup();
			}
			else
				this.Load(this.strMa_Nh_Hd);
		}

		private void LoadLookupByGroup()
		{//Lookup danh muc hợp đồng theo nhom

			frmDmNhHd frm = new frmDmNhHd();
			frm.bLookupByGroup = true;
			frm.isLookup = true;
			frm.strLookupKeyFilter = this.strLookupKeyFilter;
			frm.strLookupKeyValid = this.strLookupKeyValid;
			frm.bLookupRequire = this.bLookupRequire;

			frm.LoadLookup();

			this.bIsEnter = frm.bIsEnter;
			this.drLookup = frm.drLookup;
			this.Close();
		}

		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDmHd.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvDmHd);

			dgvDmHd.strZone = "DMHD";
			dgvDmHd.BuildGridView(this.isLookup);

			
		}
		private void Language()
        {
			if (dgvDmHd.Columns.Contains("TIEN_HD"))
				dgvDmHd.Columns["TIEN_HD"].HeaderText = "Giá trị HĐ";
			if (dgvDmHd.Columns.Contains("TIEN_HD_NT"))
				dgvDmHd.Columns["TIEN_HD_NT"].HeaderText = "Giá trị HĐ NT";
			if (dgvDmHd.Columns.Contains("DIEU_KIEN_TT"))
				dgvDmHd.Columns["DIEU_KIEN_TT"].HeaderText = "Loại giá HĐ";
			if (dgvDmHd.Columns.Contains("HTTTOAN"))
				dgvDmHd.Columns["HTTTOAN"].HeaderText = "HT thanh toán";
			if (dgvDmHd.Columns.Contains("LAI_SUAT_TH"))
				dgvDmHd.Columns["LAI_SUAT_TH"].HeaderText = "Biên độ";
			if (dgvDmHd.Columns.Contains("DIA_DIEM_BH"))
				dgvDmHd.Columns["DIA_DIEM_BH"].HeaderText = "Địa điểm bốc hàng";
			if (dgvDmHd.Columns.Contains("DIA_DIEM_GH"))
				dgvDmHd.Columns["DIA_DIEM_GH"].HeaderText = "Địa điểm dỡ hàng";
			if (dgvDmHd.Columns.Contains("NUOCNK_XK"))
				dgvDmHd.Columns["NUOCNK_XK"].HeaderText = "Xuất xứ";
			if (dgvDmHd.Columns.Contains("IS_GIAON"))
				dgvDmHd.Columns["IS_GIAON"].HeaderText = "Giao nhiều lần";
			if (dgvDmHd.Columns.Contains("IS_HD_NT"))
				dgvDmHd.Columns["IS_HD_NT"].HeaderText = "HĐ nguyên tắc";
			if (dgvDmHd.Columns.Contains("NHAN_HIEU"))
				dgvDmHd.Columns["NHAN_HIEU"].HeaderText = "Nhãn hiệu";
			if (dgvDmHd.Columns.Contains("PTIEN"))
				dgvDmHd.Columns["PTIEN"].HeaderText = "Phương tiện";
			if (dgvDmHd.Columns.Contains("Is_Nhan"))
				dgvDmHd.Columns["Is_Nhan"].HeaderText = "Nhận hs PKT";
			if (dgvDmHd.Columns.Contains("User_Nhan"))
				dgvDmHd.Columns["User_Nhan"].HeaderText = "Người nhận hs";
			if (dgvDmHd.Columns.Contains("So_Luong_PL"))
				dgvDmHd.Columns["So_Luong_PL"].HeaderText = "Số lượng phụ lục";
		}
		private void FillData()
		{
			string strKey = string.Empty;
			
            if (this.isLookup)
			{
				strKey = (this.strLookupKeyFilter == null ? string.Empty : this.strLookupKeyFilter);

               if (bLookupByGroup)
				{
					if (strKey == string.Empty)
						strKey = "(Ma_Nh_Hd = '" + strMa_Nh_Hd + "')";
					else
						strKey = "(" + strKey + ") AND (Ma_Nh_Hd = '" + strMa_Nh_Hd + "')";
				}
			}
			else
				strKey = (strMa_Nh_Hd == string.Empty ? string.Empty : "Ma_Nh_Hd = '" + strMa_Nh_Hd + "'");

			//Hải chỉ show những dữ liệu cần thiết có khai báo trong Zone, Column
			string strSQLExec = @"
				DECLARE @_ColumnList NVARCHAR(500) 
				SET @_ColumnList = ''
				SELECT @_ColumnList = @_ColumnList + ',' + Column_ID FROM R00Column WHERE Zone = '" + dgvDmHd.strZone + @"' AND Column_Id <>'Ten_Dt' AND Type <> 'B'
				SELECT CASE WHEN LEN(@_ColumnList) > 0 THEN RIGHT(@_ColumnList, LEN(@_ColumnList)-1) ELSE '' END ";
			
            string strFieldList = SQLExec.ExecuteReturnValue(strSQLExec).ToString();

			string strSQL = "SELECT " + strFieldList + ", T2.Ten_Dt " +
							"FROM (SELECT T11.*, T12.Ma_Nh_Hd + ' - ' + T12.Ten_Nh_Hd AS Ten_Nh_Hd, T14.Ma_Nh_Dt + ' - ' + T14.Ten_Nh_Dt AS Ten_Nh_Dt, " +
								"T13.Ten_Dt_CbNv, T15.So_Luong_PL, SUBSTRING(T11.Create_Log,15,20) AS CREATE_ , " +
								"CASE WHEN LEN(T11.Create_Log) > 15 THEN DBO.fn_GetDate('20'+SUBSTRING(T11.Create_Log,5,2) ,SUBSTRING(T11.Create_Log,3,2),LEFT(T11.Create_Log,2)) ELSE '19000101' END AS NGAY_TAO " +
								"FROM R81DMHD T11 LEFT JOIN R81DMNHHD T12 ON T11.Ma_Nh_Hd = T12.Ma_Nh_Hd " +
								"LEFT JOIN (SELECT Ma_Dt AS Ma_Dt_CbNv, Ten_Dt AS Ten_Dt_CbNv FROM R81DMDT) T13 ON T11.Ma_Dt_CbNv = T13.Ma_Dt_CbNv " +
								"LEFT JOIN (SELECT Ma_Dt AS Ma_Dt_Hd, T00.Ma_Nh_Dt, Ten_Nh_Dt FROM R81DMDT T00 JOIN R81DMNHDT T000 ON T00.Ma_Nh_Dt = T000.Ma_Nh_Dt) T14 ON T11.Ma_Dt = T14.Ma_Dt_Hd " +
								"LEFT JOIN (SELECT Ma_Hd, SUM(So_Luong) AS So_Luong_PL FROM R81DMPLHD GROUP BY Ma_Hd) T15 ON T11.Ma_Hd = T15.Ma_Hd) T1 " +
								"LEFT JOIN (SELECT Ma_Dt AS Ma_Dt_Kh, Ten_Dt FROM R81DMDT) T2 ON T1.Ma_Dt = T2.Ma_Dt_Kh " +
							
							"  WHERE 0 = 0";

			if (strMa_Nh_Hd != string.Empty)
				strSQL = strSQL + " AND Ma_Nh_Hd = '" + strMa_Nh_Hd + "'";
            
            if (strKey != string.Empty)
                strSQL = strSQL + " AND " + strKey;

			strSQL += " ORDER BY Ngay_Ky DESC";

			if (strFieldList != string.Empty)
				dtDmHd = SQLExec.ExecuteReturnDt(strSQL);
			else
				dtDmHd = DataTool.SQLGetDataTable("R81DMHD", null, strKey, null);


			bdsDmHd.DataSource = dtDmHd;
			dgvDmHd.DataSource = bdsDmHd;

           
           
            
			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmHd;
			bdsDmHd.Position = 0;
			ExportControl = dgvDmHd;

			if (this.isLookup)
				this.MoveToLookupValue();
		}
        private void Delete_File_Hd(string strMa_Hd)
        {
			if(DataTool.SQLCheckExist("R04PO_RESOURCE","Ma_Hd", strMa_Hd))
			{ 
				string strPath = SQLExec.ExecuteReturnValue("SELECT File_Path FROM R04PO_RESOURCE WHERE Ma_Hd = '" + strMa_Hd + "'").ToString();
				string strFolder = SQLExec.ExecuteReturnValue("SELECT File_Path FROM R81DMHD WHERE Ma_Hd = '" + strMa_Hd + "'").ToString();
				//xóa file
				File.Delete(strPath);
				//xóa Folder
				Directory.Delete(strFolder);
				//xóa data resource
				SQLExec.Execute("DELETE FROM R04PO_RESOURCE WHERE Ma_Hd = '" + strMa_Hd + "'");
			}
		}
		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == String.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmHd.Rows.Count - 1; i++)
				if (((string)dtDmHd.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmHd.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			
			if (bdsDmHd.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

            //if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit))
            //{
            //    Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Edit"));
            //    return;
            //}

			//Copy hang hien tai            
			if (bdsDmHd.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmHd.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmHd.NewRow();
				drCurrent["Ma_Nh_Hd"] = strMa_Nh_Hd;
			}

			frmDmHd_Edit frmEdit = new frmDmHd_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmHd.Position >= 0)
						dtDmHd.ImportRow(drCurrent);
					else
						dtDmHd.Rows.Add(drCurrent);
					
					bdsDmHd.Position = bdsDmHd.Find("MA_HD", drCurrent["MA_HD"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmHd.Current).Row);

				drCurrent.AcceptChanges();
				//dtDmHd.AcceptChanges();
			}
		
		}

		public override void Delete()
		{
			
			if (bdsDmHd.Position < 0)
				return;

			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}

			DataRow drCurrent = ((DataRowView)bdsDmHd.Current).Row;

			//check xem  đã xác nhận phòng kế toán chưa
			if((bool)(drCurrent["Is_Nhan"]))
            {
				Common.MsgOk("Hợp đồng: " + drCurrent["So_Hd"].ToString() + " đã được phòng kế toán kiểm tra không được phép xóa!!!");
				return;
			}
            //check đã phát sinh dữ liệu thì không xóa
            Hashtable ht = new Hashtable();
            ht.Add("OBJECT", "Ma_Hd");
            ht.Add("MA", drCurrent["Ma_Hd"].ToString());
            if (SQLExec.ExecuteReturnDt("sp_CheckExistsMa", ht, CommandType.StoredProcedure).Rows.Count > 0)
            {
                Common.MsgOk("Hợp đồng: " + drCurrent["So_Hd"].ToString() + " đã tồn tại dữ liệu kế toán không được phép xóa");
                return;
            }

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLCheckExist("R81DmPLHd", "Ma_Hd", drCurrent["Ma_Hd"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Hợp đồng: {" + drCurrent["Ten_Hd"].ToString() + "}  đang có phụ lục" :
					"Contract	 : {" + drCurrent["Ten_Hd"].ToString() + "}  have detail appendix";

				Common.MsgOk(strMsg);
				return;
			}

		
			if (DataTool.SQLDelete("R81DmHd", drCurrent))
			{
				Delete_File_Hd(drCurrent["Ma_Hd"].ToString());

				bdsDmHd.RemoveAt(bdsDmHd.Position);
				dtDmHd.AcceptChanges();

                
			}
		}

		public override void MergeID()
		{
			if (bdsDmHd.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMHD", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Contract code!" : "Bạn không đc cấp quyền Gộp Mã hợp đồng!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmHd.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Hd"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DmHd", "Ma_Hd", "Ten_Hd", strOldValue, "DMHD");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Hd", "R81DmHd", strOldValue, strNewValue))
				{
					bdsDmHd.RemoveCurrent();
					bdsDmHd.Position = bdsDmHd.Find("Ma_Hd", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmHd == null || bdsDmHd.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmHd.Current).Row;
			DataTable dHdCtmp = dtDmHd.Clone();
			dHdCtmp.ImportRow(drCurrent);

			if ((dHdCtmp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmHd.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmHd.Current).Row;

			if (isLookup && EnterValid())
			{
				drLookup = drCurrent;
				this.Close();
			}
			else
			{//Enter vao chi tiet hop dong

				frmDmPLHd frm = new frmDmPLHd();

				frm.MdiParent = this.MdiParent;
				frm.Load((string)drCurrent["Ma_Hd"]);
			}
		}

		#endregion 

		protected override void OnClosed(EventArgs e)
		{
			if (bFind && !this.bIsEnter)
				LoadLookupByGroup();

			base.OnClosed(e);
		}
        void dgvDmHd_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsDmHd.Current).Row;
            string strColumnName = dgvDmHd.Columns[e.ColumnIndex].Name;
            if (strColumnName == "LOCK"  && Common.CheckPermission("IS_TP_KTTC", enuPermission_Type.Allow_Access) 
				|| ((strColumnName == "EDIT" || strColumnName == "IS_NHAN") && Common.CheckPermission("IS_EDIT_HD", enuPermission_Type.Allow_Access)))
            {
				DataRow drDmHd = DataTool.SQLGetDataRowByID("R81DMHD", "Ma_Hd", drCurrent["Ma_Hd"].ToString());
				frmUnLock_DM frm = new frmUnLock_DM();
				if ((Common.CheckPermission("IS_EDIT_HD", enuPermission_Type.Allow_Edit) && Common.Inlist(drCurrent["Ma_Dt"].ToString(), "1000001,1000002")) ||
					Common.CheckPermission("IS_EDIT_HD", enuPermission_Type.Allow_New) ||
					Common.CheckPermission("IS_TP_KTTC", enuPermission_Type.Allow_Access))
				{
					frm.Load(drDmHd, "R81DMHD", strColumnName);
					if (strColumnName == "EDIT")
					{
						drCurrent["Tien_Tin_Chap"] = frm.numTien_Tin_Chap.Value;

						drCurrent["Tien_Cam_Co"] = frm.numTien_Cam_Co.Value;
						drCurrent["Ngay_Hd_Bd"] = frm.dteNgay_Hd_Bd.Text;
						drCurrent["Ngay_Hd_Kt"] = frm.dteNgay_Hd_Kt.Text;
					}
				}
				else if(strColumnName == "IS_NHAN" && Common.CheckPermission("IS_EDIT_HD", enuPermission_Type.Allow_Access))
					frm.Load(drDmHd, "R81DMHD", strColumnName);
				else
					Common.MsgOk("Anh (chị) không được phân quyền thực hiện chỉnh sửa dữ liệu tiền tín chấp, cầm cố!!!");
				
			}
            
        }
		void dgvDmHd_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
           
		}

		void btImport_Click(object sender, EventArgs e)
		{
			Public.ImportExcel("DMHD", dtDmHd);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			Language();
		}

		}
}