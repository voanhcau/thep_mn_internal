using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Element;
using RosySystem.Public;

namespace RosyModule.Asset
{
	public partial class frmCtTs : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		object objActive = null;

		private DataTable dtCtTs;
		private DataTable dtCtTsHM;
		private DataTable dtCtTsTT;
		private DataTable dtCtTsDC;
		private DataTable dtCtTsHH;

		private BindingSource bdsCtTs = new BindingSource();
		private BindingSource bdsCtTsHM = new BindingSource();
		private BindingSource bdsCtTsTT = new BindingSource();
		private BindingSource bdsCtTsDC = new BindingSource();
		private BindingSource bdsCtTsHH = new BindingSource();

		public string strMa_Ct_List = string.Empty;

		private DataRow drCurrent;

		public bool bLookupByGroup = false;
		public bool bLastLookupProcess = false;

		DataRow Row;

		#endregion

		#region Contructor

		public frmCtTs()
		{
			InitializeComponent();

			dgvCtTs.CellClick += new DataGridViewCellEventHandler(dgvCtTsNG_CellClick);
			//bdsCtTs.PositionChanged += new EventHandler(bdsCtTs_PositionChanged);
			bdsCtTs.CurrentChanged += new EventHandler(bdsCtTs_CurrentChanged);
			
			this.KeyDown += new KeyEventHandler(frmCtTs_KeyDown);

			this.btNew.Click += new EventHandler(btNew_Click);
			this.btEdit.Click += new EventHandler(btEdit_Click);
			this.btDelete.Click += new EventHandler(btDelete_Click);
			this.btKhau_Hao.Click += new EventHandler(btTinh_KH_Click);
			this.btPosted.Click += new EventHandler(btPosted_Click);
			this.btFilter.Click += new EventHandler(btFilter_Click);

			this.dgvCtTs.Enter +=new EventHandler(dgvCtTs_Enter);
			this.dgvCtTsHM.Enter += new EventHandler(dgvCtTsHM_Enter);
			this.dgvCtTsTT.Enter += new EventHandler(dgvCtTsTT_Enter);
			this.dgvCtTsDC.Enter += new EventHandler(dgvCtTsDC_Enter);
			this.dgvCtTsHh.Enter += new EventHandler(dgvCtTsHH_Enter);
		}

		

		public void Load(string strMa_Ct_List)
		{
			this.strMa_Ct_List = strMa_Ct_List;
			this.Object_ID = strMa_Ct_List;

			this.Build();

			//FillData
			DateTime dteNgay_Ct1 = Common.GetDate(Element.sysWorkingYear, 1, 1);
			DateTime dteNgay_Ct2 = Common.GetDate(Element.sysWorkingYear, 12, 1).AddMonths(1).AddDays(-1).AddYears(3); //Cho phép xem 3 năm sau

			DataTable dtFilter = new DataTable();
			dtFilter.Columns.Add(new DataColumn("Ma_Ct_List", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ngay_Ct2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("Ma_DvCs", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();
			//drFilter["Ma_Ct_List"] = strMa_Ct_List;
			drFilter["Ngay_Ct1"] = dteNgay_Ct1;
			drFilter["Ngay_Ct2"] = dteNgay_Ct2;

            if (strMa_Ct_List == "TS" && dteNgay_Ct1 > Library.StrToDate("01/01/2014"))
                drFilter["Ngay_Ct1"] = Library.StrToDate("01/01/2014");

			this.FillData(drFilter);

			this.BindingLanguage();

			dgvCtTs.Columns["MA_VT_TS"].HeaderCell.Style.ForeColor = Color.Red;
			dgvCtTs.Columns["TEN_VT_TS"].HeaderCell.Style.ForeColor = Color.Red;

			this.Show();
		}

		#endregion

		#region Method

		private void Build()
		{
			dgvCtTs.strZone = "CTTS"; //Nguyên giá TS
			dgvCtTs.BuildGridView();

			dgvCtTsHM.strZone = "CTTSHM"; //Hao mòn TS
			dgvCtTsHM.BuildGridView();

			dgvCtTsTT.strZone = "CTTSTT"; //Trạng thái TS
			dgvCtTsTT.BuildGridView();

			dgvCtTsDC.strZone = "CTTSDC"; //Điều chỉnh tài sản
			dgvCtTsDC.BuildGridView();

			dgvCtTsHh.strZone = "CTTSHH"; //Điều chỉnh tài sản
			dgvCtTsHh.BuildGridView();
		}

		private void FillData(DataRow drFilter)
		{
			drFilter["Ma_DvCs"] = Element.sysMa_DvCs;
			drFilter["Ma_Ct_List"] = strMa_Ct_List;

			DataSet dsCtTs = SQLExec.ExecuteReturnDs("sp_GetCtTsFilter", drFilter, CommandType.StoredProcedure);

			dtCtTs = dsCtTs.Tables[0];
			bdsCtTs.DataSource = dtCtTs;
			dgvCtTs.DataSource = bdsCtTs;

			dtCtTsHM = dsCtTs.Tables[1];
			bdsCtTsHM.DataSource = dtCtTsHM;
			dgvCtTsHM.DataSource = bdsCtTsHM;

			dtCtTsTT = dsCtTs.Tables[2];
			bdsCtTsTT.DataSource = dtCtTsTT;
			dgvCtTsTT.DataSource = bdsCtTsTT;

			dtCtTsDC = dsCtTs.Tables[3];
			bdsCtTsDC.DataSource = dtCtTsDC;
			dgvCtTsDC.DataSource = bdsCtTsDC;

			dtCtTsHH = dsCtTs.Tables[4];
			bdsCtTsHH.DataSource = dtCtTsHH;
			dgvCtTsHh.DataSource = bdsCtTsHH;

			bdsSearch = bdsCtTs;
		}

		private void Filter()
		{
			DataTable dtFilter = new DataTable();
			dtFilter.Columns.Add(new DataColumn("NGAY_CT1", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("NGAY_CT2", typeof(DateTime)));
			dtFilter.Columns.Add(new DataColumn("MA_CT", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("MA_CT_LIST", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("SO_CT1", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("SO_CT2", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("MA_NVU", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("MA_VT_TS", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("MA_DT", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("MA_KM", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("MA_BP", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("MA_VT_SP", typeof(string)));
			dtFilter.Columns.Add(new DataColumn("MA_DVCS", typeof(string)));

			DataRow drFilter = dtFilter.NewRow();
			drFilter["Ngay_Ct1"] = Element.sysNgay_Ct1;
			drFilter["Ngay_Ct2"] = Element.sysNgay_Ct2;
            
          

			frmFilter frm = new frmFilter();
			frm.Load(drFilter);

			if (frm.isAccept)
			{
				this.FillData(drFilter);
			}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (this.objActive == dgvCtTsHM)
				this.Edit_CtTsHM(enuNew_Edit);
			else if (this.objActive == dgvCtTsTT)
				this.Edit_CtTsTT(enuNew_Edit);
			else if (this.objActive == dgvCtTsDC)
				this.Edit_CtTsDC(enuNew_Edit);
			else if (this.objActive == dgvCtTsHh)
				this.Edit_CtTsHH(enuNew_Edit);
			else
				this.Edit_CtTs(enuNew_Edit);
		}

		private void Edit_CtTs(enuEdit enuNew_Edit)
		{
			if (bdsCtTs.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCtTs.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtTs.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtCtTs.NewRow();

				drCurrent["Ma_Ct"] = strMa_Ct_List.Split(',')[0];
				drCurrent["Ma_Tte"] = Element.sysMa_Tte;
				drCurrent["Ty_Gia"] = 1;
			}

			//Tăng Stt tạm thời, để trường hợp kế thừa dữ liệu OK
			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				drCurrent["Stt"] = Common.GetNewStt("06", false);
				drCurrent["Ngay_Ct"] = Library.StrToDate(Library.DateToStr(DateTime.Now));
			}

			frmCtTs_Edit frmEdit = new frmCtTs_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsCtTs.Position >= 0)
						dtCtTs.ImportRow(drCurrent);
					else
						dtCtTs.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtTs.Current).Row);
				}

				dtCtTs.AcceptChanges();

				//Đổi Ma_Vt_Ts
				if (enuNew_Edit == enuEdit.Edit && drCurrent.HasVersion(DataRowVersion.Original) && drCurrent["Ma_Vt_Ts"] != drCurrent["Ma_Vt_Ts", DataRowVersion.Original])
				{
					foreach (DataRow dr in dtCtTsHM.Select("Stt = '" + drCurrent["Stt"].ToString() + "'")) { dr["Ma_Vt_Ts"] = drCurrent["Ma_Vt_Ts"]; }
					foreach (DataRow dr in dtCtTsTT.Select("Stt = '" + drCurrent["Stt"].ToString() + "'")) { dr["Ma_Vt_Ts"] = drCurrent["Ma_Vt_Ts"]; }
					foreach (DataRow dr in dtCtTsDC.Select("Stt = '" + drCurrent["Stt"].ToString() + "'")) { dr["Ma_Vt_Ts"] = drCurrent["Ma_Vt_Ts"]; }
					foreach (DataRow dr in dtCtTsHH.Select("Stt = '" + drCurrent["Stt"].ToString() + "'")) { dr["Ma_Vt_Ts"] = drCurrent["Ma_Vt_Ts"]; }
				}

				if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
					bdsCtTs.Position = bdsCtTs.Find("Stt", drCurrent["Stt"]);
			}
			else
				dtCtTs.RejectChanges();
		}

		private void Edit_CtTsHM(enuEdit enuNew_Edit)
		{
			if (bdsCtTs.Position < 0 && bdsCtTsHM.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			DataRow drCtTs = ((DataRowView)(bdsCtTs.Current)).Row;

			//Copy hang hien tai            
			if (bdsCtTsHM.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtTsHM.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtTsHM.NewRow();

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				drCurrent["Stt"] = drCtTs["Stt"];
				drCurrent["Ma_Vt_Ts"] = drCtTs["Ma_Vt_Ts"];
				drCurrent["Ngay_Ct"] = Library.StrToDate(Library.DateToStr(DateTime.Now));
			}

			frmCtTsHM_Edit frmEdit = new frmCtTsHM_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsCtTsHM.Position >= 0)
						dtCtTsHM.ImportRow(drCurrent);
					else
						dtCtTsHM.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtTsHM.Current).Row);
				}

				dtCtTsHM.AcceptChanges();
			}
			else
				dtCtTsHM.RejectChanges();
		}

		private void Edit_CtTsTT(enuEdit enuNew_Edit)
		{
			if (bdsCtTs.Position < 0 && bdsCtTsTT.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			DataRow drCtTs = ((DataRowView)(bdsCtTs.Current)).Row;

			//Copy hang hien tai            
			if (bdsCtTsTT.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtTsTT.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtTsTT.NewRow();

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				if (bdsCtTsTT.Position < 0) //Hải Copy từ CtTs ngầm định Luân chuyển trạng thái
					Common.CopyDataRow(drCtTs, drCurrent);

				drCurrent["Stt"] = drCtTs["Stt"];
				drCurrent["Ma_Vt_Ts"] = drCtTs["Ma_Vt_Ts"];
			}

			frmCtTsTT_Edit frmEdit = new frmCtTsTT_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsCtTsTT.Position >= 0)
						dtCtTsTT.ImportRow(drCurrent);
					else
						dtCtTsTT.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtTsTT.Current).Row);
				}

				dtCtTsTT.AcceptChanges();
			}
			else
				dtCtTsTT.RejectChanges();
		}

		private void Edit_CtTsDC(enuEdit enuNew_Edit)
		{
			if (bdsCtTs.Position < 0 && bdsCtTsDC.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			DataRow drCtTs = ((DataRowView)(bdsCtTs.Current)).Row;

			if (bdsCtTsDC.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtTsDC.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtTsDC.NewRow();

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				drCurrent["Stt"] = drCtTs["Stt"];
				drCurrent["Ma_Vt_Ts"] = drCtTs["Ma_Vt_Ts"];
			}

			frmCtTsDC_Edit frmEdit = new frmCtTsDC_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent, drCtTs);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCtTsDC.Position >= 0)
						dtCtTsDC.ImportRow(drCurrent);
					else
						dtCtTsDC.Rows.Add(drCurrent);

					bdsCtTsDC.Position = bdsCtTsDC.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtTsDC.Current).Row);
				}

				dtCtTsDC.AcceptChanges();
			}
			else
				dtCtTsDC.RejectChanges();
		}

		private void Edit_CtTsHH(enuEdit enuNew_Edit)
		{
			if (bdsCtTs.Position < 0 && bdsCtTsHH.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			DataRow drCtTs = ((DataRowView)(bdsCtTs.Current)).Row;

			if (bdsCtTsHH.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCtTsHH.Current).Row, ref drCurrent);
			else
				drCurrent = dtCtTsHH.NewRow();

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				drCurrent["Stt"] = drCtTs["Stt"];
				drCurrent["Ma_Vt_Ts"] = drCtTs["Ma_Vt_Ts"];
			}

			frmCtTsHH_Edit frmEdit = new frmCtTsHH_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsCtTsHH.Position >= 0)
						dtCtTsHH.ImportRow(drCurrent);
					else
						dtCtTsHH.Rows.Add(drCurrent);

					bdsCtTsHH.Position = bdsCtTsHH.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCtTsHH.Current).Row);
				}

				dtCtTsHH.AcceptChanges();
			}
			else
				dtCtTsHH.RejectChanges();
		}

		public override void Delete()
		{
			if (this.objActive == dgvCtTsHM)
				this.Delete_CtTsHM();
			else if (this.objActive == dgvCtTsTT)
				this.Delete_CtTsTT();
			else if (this.objActive == dgvCtTsDC)
				this.Delete_CtTsDC();
			else if (this.objActive == dgvCtTsHh)
				this.Delete_CtTsHH();
			else
				this.Delete_CtTs();
		}

		private void Delete_CtTs()
		{
			if (bdsCtTs.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtTs.Current).Row;

			if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
			{
				Common.MsgOk("Dữ liệu đã bị khóa, liên hệ PKTTC để xử lý!!!");
				return;
			}

			//if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
			if (!Common.MsgYes_No("Dữ liệu của chi tiết nguyên giá này cũng bị xoá trên bảng hao mòn và luân chuyển Ts \n Bạn có chắc xoá không ? "))
				return;

			string _Stt_del = drCurrent["Stt"].ToString().Trim();

			Hashtable ht = new Hashtable();
			ht.Add("STT", _Stt_del);

			SQLExec.Execute("Sp_Delete_CTTS", ht, CommandType.StoredProcedure);

			bdsCtTs.RemoveAt(bdsCtTs.Position);
			dtCtTs.AcceptChanges();

			for (int i = 0; i < dtCtTsHM.Rows.Count; i++)
			{
				Row = dtCtTsHM.Rows[i];
				if (Row["Stt"].ToString().Trim() == _Stt_del)
					dtCtTsHM.Rows.Remove(Row);
			}

			for (int i = 0; i < dtCtTsTT.Rows.Count; i++)
			{
				Row = dtCtTsTT.Rows[i];
				if (Row["Stt"].ToString().Trim() == _Stt_del)
					dtCtTsTT.Rows.Remove(Row);
			}

			for (int i = 0; i < dtCtTsTT.Rows.Count; i++)
			{
				Row = dtCtTsDC.Rows[i];
				if (Row["Stt"].ToString().Trim() == _Stt_del)
					dtCtTsDC.Rows.Remove(Row);
			}

			for (int i = 0; i < dtCtTsHH.Rows.Count; i++)
			{
				Row = dtCtTsHH.Rows[i];
				if (Row["Stt"].ToString().Trim() == _Stt_del)
					dtCtTsHH.Rows.Remove(Row);
			}
		}

		private void Delete_CtTsHM()
		{
			if (bdsCtTsHM.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtTsHM.Current).Row;
			//kiểm tra khóa dữ liệu
			if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
            {
				Common.MsgOk("Dữ liệu đã bị khóa, liên hệ PKTTC để xử lý!!!");
				return;
			}
			
			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R06CTTSHM", drCurrent))
			{
				bdsCtTsHM.RemoveAt(bdsCtTsHM.Position);
				dtCtTsHM.AcceptChanges();
			}
		}

		private void Delete_CtTsTT()
		{
			if (bdsCtTsTT.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtTsTT.Current).Row;

			if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
			{
				Common.MsgOk("Dữ liệu đã bị khóa, liên hệ PKTTC để xử lý!!!");
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R06CTTSTT", drCurrent))
			{
				bdsCtTsTT.RemoveAt(bdsCtTsTT.Position);
				dtCtTsTT.AcceptChanges();
			}
		}

		private void Delete_CtTsDC()
		{
			if (bdsCtTsDC.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtTsDC.Current).Row;

			if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
			{
				Common.MsgOk("Dữ liệu đã bị khóa, liên hệ PKTTC để xử lý!!!");
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R06CTTSDC", drCurrent))
			{
				bdsCtTsDC.RemoveAt(bdsCtTsDC.Position);
				dtCtTsDC.AcceptChanges();
			}
		}

		private void Delete_CtTsHH()
		{
			if (bdsCtTsHH.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCtTsHH.Current).Row;
			
			if (!Common.CheckDataLocked((DateTime)drCurrent["Ngay_Ct"]))
			{
				Common.MsgOk("Dữ liệu đã bị khóa, liên hệ PKTTC để xử lý!!!");
				return;
			}

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R06CTTSHH", drCurrent))
			{
				bdsCtTsHH.RemoveAt(bdsCtTsHH.Position);
				dtCtTsHH.AcceptChanges();
			}
		}
		#endregion

		#region Su kien

		void bdsCtTs_CurrentChanged(object sender, EventArgs e)
		{
			if (bdsCtTs.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsCtTs.Current).Row;

			bdsCtTsHM.Filter = bdsCtTsTT.Filter = bdsCtTsDC.Filter = bdsCtTsHH.Filter = "Stt = '" + drCurrent["Stt"].ToString() + "'";
		}
		void bdsCtTs_PositionChanged(object sender, EventArgs e)
		{
			if (bdsCtTs.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsCtTs.Current).Row;

			bdsCtTsHM.Filter = bdsCtTsTT.Filter = bdsCtTsDC.Filter = bdsCtTsHH.Filter = "Stt = '" + drCurrent["Stt"].ToString() + "'";
		}

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

		void btFilter_Click(object sender, EventArgs e)
		{
			this.Filter();
		}

		void btTinh_KH_Click(object sender, EventArgs e)
		{
			if (bdsCtTs.Position < 0)
			{
				Common.MsgCancel("Không có dữ liệu để xác định Loại Nhóm vật tư!");
				return;
			}

			string strSQLExec = @"
				SELECT Loai_Nh_Vt 
					FROM R81DmNhVt 
					WHERE Ma_Nh_Vt IN
						(
							SELECT Ma_Nh_Vt 
								FROM R81DMVT 
								WHERE Ma_Vt = '" + ((DataRowView)bdsCtTs.Current).Row["Ma_Vt_Ts"].ToString() + @"'
						)";

			string strLoai_Nh_Vt = (string)SQLExec.ExecuteReturnValue(strSQLExec);

			frmKhauHao frm = new frmKhauHao();
			frm.MdiParent = this.MdiParent;
			frm.Load(strLoai_Nh_Vt);
		}

		void btPosted_Click(object sender, EventArgs e)
		{
			if (bdsCtTs.Position < 0)
			{
				Common.MsgCancel("Không có dữ liệu để xác định Loại Nhóm vật tư!");
				return;
			}

			string strSQLExec = @"
				SELECT Loai_Nh_Vt 
					FROM R81DmNhVt 
					WHERE Ma_Nh_Vt IN
						(
							SELECT Ma_Nh_Vt 
								FROM R81DMVT 
								WHERE Ma_Vt = '" + ((DataRowView)bdsCtTs.Current).Row["Ma_Vt_Ts"].ToString() + @"'
						)";

			string strLoai_Nh_Vt = (string)SQLExec.ExecuteReturnValue(strSQLExec);

			frmKhauHao_Posted frm = new frmKhauHao_Posted();
			frm.numThang.Value = Element.sysNgay_Ct1.Month;
			frm.Load(strLoai_Nh_Vt);
		}

		void dgvCtTsNG_CellClick(object sender, DataGridViewCellEventArgs e)
		{

			if (dgvCtTs.CurrentCell.OwningColumn.DataPropertyName == "IS_GIAM_TS")
			{
				drCurrent = ((DataRowView)bdsCtTs.Current).Row;

				if ((bool)drCurrent["IS_GIAM_TS"] == true)
				{
					if (!Common.MsgYes_No("Bạn có chắc chắn gỡ bỏ Giảm TS?"))
						return;

					drCurrent["NGAY_GIAM_TS"] = new DateTime(1900, 1, 1);
					drCurrent["MA_NVU_GIAM"] = "";
					drCurrent["IS_GIAM_TS"] = false;

					DataTool.SQLUpdate(enuEdit.Edit, "R06CTTS", ref drCurrent);
				}
				else
				{
					frmGiam_Ts_Edit Giam_Ts_Edit = new frmGiam_Ts_Edit();
					Giam_Ts_Edit.Load(enuEdit.Edit, drCurrent);
				}
			}
		}

		void dgvCtTs_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
			objActive = dgvCtTs;
		}

		void dgvCtTsHM_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
			objActive = dgvCtTsHM;
		}

		void dgvCtTsTT_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
			objActive = dgvCtTsTT;
		}

		void dgvCtTsDC_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;

			objActive = dgvCtTsDC;
		}

		void dgvCtTsHH_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;

			objActive = dgvCtTsHh;
		}

		void frmCtTs_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F9 && !e.Control && !e.Shift && !e.Alt)
				this.Filter();
		}

		#endregion
	}
}