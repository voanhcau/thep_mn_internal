using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;

namespace RosyModule.General
{
	public partial class frmKetChuyenPb : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		private DataTable dtKetChuyenPb;
		private DataTable dtKetChuyenPbCT1;

		private DataRow drCurrent;
		private BindingSource bdsKetChuyenPb = new BindingSource();
		private BindingSource bdsKetChuyenPbCT1 = new BindingSource();		
		
		#endregion

		#region Contructor

		public frmKetChuyenPb()
		{
			InitializeComponent();

			this.btNew.Click += new EventHandler(btNew_Click);
			this.btEdit.Click += new EventHandler(btEdit_Click);
			this.btDelete.Click += new EventHandler(btDelete_Click);
			this.btPhanBo.Click += new EventHandler(btPhanBo_Click);

			numThang1.Validating += new CancelEventHandler(numThang1_Validating);
			numThang1.TextChanged += new EventHandler(numThang1_TextChanged);

			numThang2.Validating += new CancelEventHandler(numThang2_Validating);
			numThang2.TextChanged += new EventHandler(numThang1_TextChanged);

			bdsKetChuyenPb.PositionChanged += new EventHandler(bdsKetChuyenPb_PositionChanged);

			dgvKetChuyenPb.Enter += new EventHandler(dgvKetChuyenPb_Enter);
			dgvKetChuyenPbCT1.Enter += new EventHandler(dgvKetChuyenPbCT1_Enter);

		}		
		
		public override void Load()
		{
			Build();
			FillData();
			BindingLanguage();
		
			this.Show();
		}			

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvKetChuyenPb.strZone = "KetChuyenPb";
			dgvKetChuyenPb.BuildGridView(this.isLookup);

			dgvKetChuyenPbCT1.strZone = "KetChuyenPbCT1";
			dgvKetChuyenPbCT1.BuildGridView();

			dgvKetChuyenPb.ReadOnly = false;
			foreach (DataGridViewColumn dgvc in dgvKetChuyenPb.Columns)
				dgvc.ReadOnly = true;

			dgvKetChuyenPb.Columns["SELECT"].ReadOnly = false; 
		}

		private void FillData()
		{
			dtKetChuyenPb = DataTool.SQLGetDataTable("R80KETCHUYENPB", "*, CAST(0 AS BIT) AS [SELECT]", null, "Tk");
			bdsKetChuyenPb.DataSource = dtKetChuyenPb;
			dgvKetChuyenPb.DataSource = bdsKetChuyenPb;

			string strSQLExec =
				"SELECT T1.*, DmSp.Ten_Vt_Sp FROM R80KETCHUYENPBCT1 T1 LEFT JOIN R81DmSp DmSp ON T1.Ma_Vt_Sp = DmSp.Ma_Vt_Sp " +
					" WHERE T1.Nam = " + Element.sysWorkingYear +
					" ORDER BY T1.Ma_Vt_Sp";

			//dtKetChuyenPbCT1 = DataTool.SQLGetDataTable("R80KETCHUYENPBCT1", "*", strKey, "Ma_Vt_Sp");
			dtKetChuyenPbCT1 = SQLExec.ExecuteReturnDt(strSQLExec);

			bdsKetChuyenPbCT1.DataSource = dtKetChuyenPbCT1;
			dgvKetChuyenPbCT1.DataSource = bdsKetChuyenPbCT1;			

			bdsSearch = bdsKetChuyenPb;			
		}

		private void KetChuyenPb()
		{
			dgvKetChuyenPb.EndEdit();
			bdsKetChuyenPb.EndEdit();

			if (Common.GetPartitionCurrent() != 0 && Common.GetPartitionCurrent() != Element.sysWorkingYear)
			{
				Common.MsgCancel("Phải chuyển về phân vùng dữ liệu " + Element.sysWorkingYear.ToString() + "!");
				return;
			}

			frmKetChuyen_Run frm = new frmKetChuyen_Run();
			frm.Tag = "Ket_Chuyen";

			frm.numThang1.Value = this.numThang1.Value;
			frm.numThang2.Value = this.numThang2.Value;

			frm.Load();

			if (!frm.isAccept)
				return;

			DateTime dteNgay_Ct1 = Library.StrToDate("01/" + frm.numThang1.Value + "/" + Element.sysWorkingYear);
			DateTime dteNgay_Ct2 = Library.StrToDate("01/" + frm.numThang2.Value + "/" + Element.sysWorkingYear);
			dteNgay_Ct2 = dteNgay_Ct2.AddMonths(1).AddDays(-1);

			if (!Common.CheckDataLocked(dteNgay_Ct1))
			{
				Common.MsgCancel("Dữ liệu đã khóa, liên hệ với nhà quản trị!");
				return;
			}

			foreach (DataRow dr in dtKetChuyenPb.Rows)
			{
				if ((bool)dr["SELECT"] == false)
					continue;

				Hashtable ht = new Hashtable();
				ht["NGAY_CT1"] = dteNgay_Ct1;
				ht["NGAY_CT2"] = dteNgay_Ct2;
				ht["STT"] = dr["Stt"];
				ht["TK"] = dr["Tk"];
				ht["TK_DU_DEN"] = dr["Tk_Du_Den"];
				ht["DIEN_GIAI"] = dr["Dien_Giai"];
				ht["NO_CO_AUTO"] = dr["No_Co_Auto"];
				ht["PS_DU"] = dr["Ps_Du"];
				ht["LOAI_KC"] = dr["Loai_Kc"];
				ht["MA_CT"] = "TD";
				ht["MA_DVCS"] = Element.sysMa_DvCs;

				Common.ShowStatus(Languages.GetLanguage("In_Process") + (string)dr["Dien_Giai"]);

				//SQLExec.Execute("Sp_KetChuyen_Delete", ht, CommandType.StoredProcedure);

				if ((string)dr["Loai_Kc"] == "1")
					SQLExec.Execute("Sp_KetChuyenPb1", ht, CommandType.StoredProcedure);
				else if ((string)dr["Loai_Kc"] == "2")
					SQLExec.Execute("Sp_KetChuyenPb2", ht, CommandType.StoredProcedure);

				dr["Select"] = false;
			}

			Common.EndShowStatus();
			Common.MsgOk(Languages.GetLanguage("End_Process"));
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			//ket chuyen phan bo chi tiet 1
			if (dgvKetChuyenPbCT1.Focused)
			{
				this.Edit_KetChuyenPbCT1(enuNew_Edit);
				return;
			}

			//ket chuyen phan bo
			this.Edit_KetChuyenPb(enuNew_Edit);
		}

		public void Edit_KetChuyenPb(enuEdit enuNew_Edit)
		{
			if (bdsKetChuyenPb.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsKetChuyenPb.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsKetChuyenPb.Current).Row, ref drCurrent);
			else
				drCurrent = dtKetChuyenPb.NewRow();

			frmKetChuyenPb_Edit frmEdit = new frmKetChuyenPb_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsKetChuyenPb.Position >= 0)
						dtKetChuyenPb.ImportRow(drCurrent);
					else
						dtKetChuyenPb.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsKetChuyenPb.Current).Row);
				}

				dtKetChuyenPb.AcceptChanges();
			}
			else
				dtKetChuyenPb.RejectChanges();
		}

		private void Edit_KetChuyenPbCT1(enuEdit enuNew_Edit)
		{
			if (bdsKetChuyenPb.Count == 0)
				return;

			if (bdsKetChuyenPbCT1.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsKetChuyenPbCT1.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsKetChuyenPbCT1.Current).Row, ref drCurrent);
			else
				drCurrent = dtKetChuyenPbCT1.NewRow();

			if (enuNew_Edit == enuEdit.New)
			{
				drCurrent["Tk"] = ((DataRowView)bdsKetChuyenPb.Current).Row["Tk"];
				drCurrent["Nam"] = Element.sysWorkingYear;
				drCurrent["Thang"] = Convert.ToInt32(numThang1.Value); 
			}

			frmKetChuyenPbCT1_Edit frmEdit = new frmKetChuyenPbCT1_Edit();

			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsKetChuyenPbCT1.Position >= 0)
						dtKetChuyenPbCT1.ImportRow(drCurrent);
					else
						dtKetChuyenPbCT1.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsKetChuyenPbCT1.Current).Row);
				}

				dtKetChuyenPbCT1.AcceptChanges();				
			}
			else
				dtKetChuyenPbCT1.RejectChanges();
		}		

		public override void Delete()
		{
			//Ket chuyen phan bo chi tiet 1
			if (dgvKetChuyenPbCT1.Focused)
			{
				this.Delete_KetChuyenPbCT1();
				return;
			}	

			if (bdsKetChuyenPb.Position < 0)
				return;

			if (bdsKetChuyenPbCT1.Count != 0 )
			{
				Common.MsgCancel("Không xóa được khi có dữ liệu chi tiết!!!");
				return;
			}

			DataRow drCurrent = ((DataRowView)bdsKetChuyenPb.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R80KETCHUYENPB", drCurrent))
			{
				bdsKetChuyenPb.RemoveAt(bdsKetChuyenPb.Position);
				dtKetChuyenPb.AcceptChanges();
			}			
		}

		private void Delete_KetChuyenPbCT1()
		{
			if (bdsKetChuyenPbCT1.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsKetChuyenPbCT1.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R80KETCHUYENPBCT1", drCurrent))
			{
				bdsKetChuyenPbCT1.RemoveAt(bdsKetChuyenPbCT1.Position);
				dtKetChuyenPbCT1.AcceptChanges();
			}
		}		

		#endregion

		#region Su kien

		void btPhanBo_Click(object sender, EventArgs e)
		{
			KetChuyenPb();
		}		

		void numThang1_Validating(object sender, CancelEventArgs e)
		{
			if (numThang1.Value <= 0 || numThang1.Value > 12)
				e.Cancel = true;
		}		

		void numThang1_TextChanged(object sender, EventArgs e)
		{
			if (bdsKetChuyenPb.Count <= 0)
				return;

			drCurrent = ((DataRowView)bdsKetChuyenPb.Current).Row;

			string strFilter = "(Tk = '" + (string)drCurrent["Tk"] + "')";
			strFilter += " AND (Thang >= " + Convert.ToInt32(numThang1.Value) + ")";
			strFilter += " AND (Thang <= " + Convert.ToInt32(numThang2.Value) + ")";

			bdsKetChuyenPbCT1.Filter = strFilter;
		}

		void numThang2_Validating(object sender, CancelEventArgs e)
		{
			if (numThang2.Value <= 0 || numThang2.Value > 12)
				e.Cancel = true;
		}		

		void bdsKetChuyenPb_PositionChanged(object sender, EventArgs e)
		{
			drCurrent = ((DataRowView)bdsKetChuyenPb.Current).Row;

			string strFilter = "(Tk = '" + (string)drCurrent["Tk"] + "')";
			strFilter += " AND (Thang = " + Convert.ToInt32(numThang1.Value) + ")";

			bdsKetChuyenPbCT1.Filter = strFilter;

			bdsKetChuyenPbCT1.Filter = strFilter;			
		}

		void btNew_Click(object sender, EventArgs e)
		{
			if (this.rsTabControl1.SelectedTab == tpKetchuyenPbCT1)
				Edit_KetChuyenPbCT1(enuEdit.New);			
		}

		void btEdit_Click(object sender, EventArgs e)
		{
			if (this.rsTabControl1.SelectedTab == tpKetchuyenPbCT1)
				Edit_KetChuyenPbCT1(enuEdit.Edit);			
		}

		void btDelete_Click(object sender, EventArgs e)
		{
			if (this.rsTabControl1.SelectedTab == tpKetchuyenPbCT1)
				Delete_KetChuyenPbCT1();			
		}

		void dgvKetChuyenPbStatus_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}

		void dgvKetChuyenPb_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}	
		
		void dgvKetChuyenPbCT1_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
		}	

		#endregion
	}
}