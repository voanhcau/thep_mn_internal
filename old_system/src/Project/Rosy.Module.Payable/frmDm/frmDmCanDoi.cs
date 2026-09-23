using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using System.Collections;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Element;

namespace RosyModule.Payable
{
	public partial class frmDmCanDoi : RosyList.frmView
	{
		DataTable dtDmCanDoi;
		BindingSource bdsDmCanDoi = new BindingSource();
		DataRow drCurrent;
		rsDataGridView dgvDmCanDoi = new rsDataGridView();

		public frmDmCanDoi()
		{			
			InitializeComponent();

			btImport.Click += new EventHandler(btImport_Click);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.Show();
		}

		private void Build()
		{
			dgvDmCanDoi.Dock = DockStyle.Fill;
			dgvDmCanDoi.strZone = "DMCANDOI";
			dgvDmCanDoi.BuildGridView();

			this.splitcContent.Panel1.Controls.Add(dgvDmCanDoi);

		}

		private void FillData()
		{
			string strSQLExec = "sp_GetBangCanDoiVt";

			dtDmCanDoi = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.StoredProcedure);

			bdsDmCanDoi.DataSource = dtDmCanDoi;
			dgvDmCanDoi.DataSource = bdsDmCanDoi;

			this.bdsSearch = bdsDmCanDoi;
			this.ExportControl = dgvDmCanDoi;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmCanDoi.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmCanDoi.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmCanDoi.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmCanDoi.NewRow();

			frmDmCanDoi_Edit frmEdit = new frmDmCanDoi_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmCanDoi.Position >= 0)
						dtDmCanDoi.ImportRow(drCurrent);
					else
						dtDmCanDoi.Rows.Add(drCurrent);

					bdsDmCanDoi.Position = bdsDmCanDoi.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmCanDoi.Current).Row);
				}

				dtDmCanDoi.AcceptChanges();
			}
			else
				dtDmCanDoi.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmCanDoi.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmCanDoi.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81BANGCANDOI", drCurrent))
			{
				bdsDmCanDoi.RemoveAt(bdsDmCanDoi.Position);
				dtDmCanDoi.AcceptChanges();
			}
		}

		void btImport_Click(object sender, EventArgs e)
		{
			frmReadExcel frmImport = new frmReadExcel();
			frmImport.Load("BANGCANDOI");

			if (frmImport.isAccept && frmImport.dtImport != null)
			{
				this.ImportExport(frmImport.dtImport);
			}
		}

		private void ImportExport(DataTable dtImport)
		{
			string strMa_Vt = "";
			string strNam = "";
			strMa_Vt = (string)dtImport.Rows[0]["Ma_Vt"]	;
			strNam = (string)dtImport.Rows[0]["Nam"];

			//// Kiểm tra đã có trong dữ liệu chưa
			//DataTable dbCheck = SQLExec.ExecuteReturnDt("SELECT * FROM R81BANGCANDOI WHERE Ma_Vt = '" + strMa_Vt + "' AND Nam = " + strNam + "");

			//if (dbCheck.Rows.Count > 0)
			//{
			//    if (Common.MsgYes_No("Bảng cân đối vật tư " + strMa_Vt + " đã có trong bảng dữ liệu bạn có muốn xóa đi không ") == false)
			//        return;
			//    else
			//    {
			//        SQLExec.Execute("DELETE FROM R81BANGCANDOI  WHERE Ma_Vt = '" + strMa_Vt + "' AND Nam = " + strNam + "");
			//    }

			//}

			SqlCommand sqlCom = SQLExec.GetSQLCommand();
			sqlCom.CommandType = CommandType.StoredProcedure;

			sqlCom.Parameters.Clear();
			sqlCom.CommandText = "Sp_Import_BangCanDoi";


			SqlParameter sqlPara = new SqlParameter();
			sqlPara.SqlDbType = SqlDbType.Structured;


			sqlPara.ParameterName = "@TVP_Import";
			sqlPara.TypeName = "TVP_DmBangCanDoi";
			sqlPara.Value = Voucher.GetTVPValue("R81BANGCANDOI", "TVP_DmBangCanDoi", dtImport);


			sqlCom.Parameters.Add(sqlPara);

			try
			{
				sqlCom.ExecuteNonQuery();
				string strMsgOk = Element.sysLanguage == enuLanguageType.English ? "Import success !" : "Import thành công !";
				Common.MsgOk(strMsgOk);
				FillData();
			}
			catch (Exception ex)
			{
				Common.MsgOk(ex.Message);
			}
		}
	}
}
