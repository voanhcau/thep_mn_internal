using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;

namespace RosyModule.Machinery
{
	public partial class frmBaoTri : RosySystem.Customize.frmView
	{
		#region variable

		DataTable dtBaoTriTuan;
		rsDataGridView dgvBaoTriTuan = new rsDataGridView();
		BindingSource bdsBaoTriTuan = new BindingSource();
		DataRow drCurrent;

		#endregion

		#region Contructor

		public frmBaoTri()
		{
			InitializeComponent();
			btDelete.Click += new EventHandler(btDelete_Click);
			btNew.Click += new EventHandler(btNew_Click);
			btEdit.Click += new EventHandler(btEdit_Click);
			btInherit.Click += new EventHandler(btInherit_Click);
		}

		void btInherit_Click(object sender, EventArgs e)
		{
			frmInherit frm = new frmInherit();
			frm.Load();

			if (frm.Is_Accept)
			{
				if (frm.dtKHBTSC.Select("Chon = true").Length == 0)
					return;

				foreach (DataRow drSelect in frm.dtKHBTSC.Select("Chon = true"))
				{
					DataRow drEdit = drSelect.Table.NewRow();
					Common.CopyDataColumn(dtBaoTriTuan, drEdit.Table, "NGAY_LAP,MA_VT_TB,MA_VT_TB_KT,NGAY_SUA_CHUA,NOI_DUNG,THOI_GIAN_NGUNG_MAY_DK,THOI_GIAN_NGUNG_MAY,THOI_GIAN_HOAN_THANH,DUYET,NGAY_DUYET,HIEN_TRANG,NGUYEN_NHAN,BIEN_PHAP,KET_QUA,NGAY_DKHT,NGHIEM_THU,NGAY_NGHIEM_THU,HINH,CREATE_LOG,LASTMODIFY_LOG,TRONG_KE_HOACH,TYPEOFMAINTENANCE,MA_DT_CBNV_YC,MA_DT_CBNV_BT,MA_DT_CBNV_KT,CONTRACTID,CONTRACTDATE,CONTRACTDESCRIPTION,TEN_DTA,DIA_CHIA,MSTA,ONG_BAA,CHUC_VUA,TEN_DTB,DIA_CHIB,MSTB,ONG_BAB,CHUC_VUB,DE_XUAT,KET_LUAN,TINH_TRANG,MA_BP,DUYET_YC,NGAY_DUYET_YC,PHU_TUNG_KEM_THEO,GHI_CHU,KY_HIEU,STT,MA_CT,NGAY_CT,MA_DVCS,TIEN,TIEN_NT,TY_GIA,MA_TTE,STT0,SO_CT,MA_NVU,CONG_DU_KIEN,CONG_THUC_TE,MA_BP_YC,IS_YC");
					Common.CopyDataRow(drSelect, drEdit);
					
					if (drEdit.Table.Columns.Contains("TypeOfMaintenance"))
						drEdit["TypeOfMaintenance"] = "Bảo trì cơ điện";

                    DataTool.SQLUpdate(enuEdit.New, "R06BTSC", ref drEdit);
				}

				this.FillData();
			}
		}

		public void Load()
		{
			Load(string.Empty);
		}

		public void Load(string strMa_Vt_Tb)
		{
			Build();
			FillData();

			this.strLookupColumn = "Ma_Vt_Tb";
			this.strLookupValue = strMa_Vt_Tb;

			this.MoveToLookupValue();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}
		
		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtBaoTriTuan.Rows.Count - 1; i++)
				if (((string)dtBaoTriTuan.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsBaoTriTuan.Position = i;
					break;
				}
		}

		private void Build()
		{
			dgvBaoTriTuan.Dock = DockStyle.Fill;
			dgvBaoTriTuan.strZone = "BAOTRICD";
			dgvBaoTriTuan.BuildGridView(this.isLookup);

			this.splitContainer1.Panel1.Controls.Add(dgvBaoTriTuan);
		}

		private void FillData()
		{
			dtBaoTriTuan = SQLExec.ExecuteReturnDt("sp_GetBTSC_CD", CommandType.StoredProcedure);

			bdsBaoTriTuan.DataSource = dtBaoTriTuan;
			dgvBaoTriTuan.DataSource = bdsBaoTriTuan;

			this.bdsSearch = bdsBaoTriTuan;
			this.ExportControl = dgvBaoTriTuan;
		}

		#endregion

		#region Event 
		
		void btEdit_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.Edit);
		}

		void btNew_Click(object sender, EventArgs e)
		{
			Edit(enuEdit.New);
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			Delete();
		}

		#endregion

		#region method

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsBaoTriTuan.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy dòng hiện tại
			if (bdsBaoTriTuan.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsBaoTriTuan.Current).Row, ref drCurrent);
			else
				drCurrent = dtBaoTriTuan.NewRow();

			frmBaoTriCD_Edit frmEdit = new frmBaoTriCD_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsBaoTriTuan.Position >= 0)
						dtBaoTriTuan.ImportRow(drCurrent);
					else
						dtBaoTriTuan.Rows.Add(drCurrent);

					bdsBaoTriTuan.Position = bdsBaoTriTuan.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsBaoTriTuan.Current).Row);

				dtBaoTriTuan.AcceptChanges();
			}
			else
				dtBaoTriTuan.RejectChanges();

		}

		public override void Delete()
		{
			if (bdsBaoTriTuan.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsBaoTriTuan.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R06BTSC", drCurrent))
			{
				bdsBaoTriTuan.RemoveAt(bdsBaoTriTuan.Position);
				dtBaoTriTuan.AcceptChanges();
			}
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (dgvBaoTriTuan.Columns.Contains("Ngay_Sua_Chua"))
				dgvBaoTriTuan.Columns["Ngay_Sua_Chua"].HeaderText = "Ngày giờ thực hiện";

			if (dgvBaoTriTuan.Columns.Contains("Thoi_Gian_Hoan_Thanh"))
				dgvBaoTriTuan.Columns["Thoi_Gian_Hoan_Thanh"].HeaderText = "Ngày giờ kết thúc";
		}

	}
}
