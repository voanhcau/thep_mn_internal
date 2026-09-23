using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Element;
using System.Data.SqlClient;

namespace RosyModule.Payable
{
	public partial class frmDmTHTX : RosyList.frmView
	{
		#region Fields

		private DataTable dtSDV;
		private DataTable dtSDVCt;

		private DataRow drCurrent;
		private BindingSource bdsSDV = new BindingSource();
		private BindingSource bdsSDVCt = new BindingSource();

		private rsDataGridView dgvSDV = new rsDataGridView();
		private rsDataGridView dgvSDVCt = new rsDataGridView();
        string strLoai = string.Empty;
		#endregion

		#region Methods

        public frmDmTHTX()
		{
			InitializeComponent();

			btImport.Click += new EventHandler(btImport_Click);
		}

		public void Load(string strLoai)
		{
            this.strLoai = strLoai;
			this.Build();
			this.FillData();
			this.BindingLanguage();

			this.Show();
		}

		private void Build()
		{
            this.dgvSDVCt.strZone = "TIEUHAODM";
			this.dgvSDVCt.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvSDVCt);
			
			this.dgvSDVCt.BuildGridView();
		}

		private void FillData()
		{
            Hashtable ht = new Hashtable();
            ht.Add("USER_LOGIN", Element.sysUser_Id);
            ht.Add("LOAI", strLoai);
            ht.Add("NAM", Element.sysWorkingYear);
            dtSDVCt = SQLExec.ExecuteReturnDt("dbo.sp_GetDMTHTX", ht, CommandType.StoredProcedure);

            bdsSDVCt.DataSource = dtSDVCt;
            dgvSDVCt.DataSource = bdsSDVCt;

            bdsSearch = bdsSDVCt;
            ExportControl = dgvSDVCt;
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsSDVCt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsSDVCt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsSDVCt.Current).Row, ref drCurrent);
			else
				drCurrent = dtSDVCt.NewRow();

            frmDmTHTX_Edit frmEdit = new frmDmTHTX_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsSDVCt.Position >= 0)
						dtSDVCt.ImportRow(drCurrent);
					else
						dtSDVCt.Rows.Add(drCurrent);

					bdsSDVCt.Position = bdsSDVCt.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsSDVCt.Current).Row);

				dtSDVCt.AcceptChanges();
			}
		}

		public override void Delete()
		{
			if (bdsSDVCt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsSDVCt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R81DMVTTHTX", drCurrent))
			{
				bdsSDVCt.RemoveAt(bdsSDVCt.Position);
				dtSDVCt.AcceptChanges();
			}
		}

		#endregion

		#region Events
		protected override void OnKeyDown(KeyEventArgs e)
		{
			
			if (this.ActiveControl == dgvSDVCt)
			{
				switch (e.KeyCode)
				{
					case Keys.F2:
						this.Edit(enuEdit.New);
						return;

					case Keys.F3:
						this.Edit(enuEdit.Edit);
						return;

					case Keys.F8:
						this.Delete();
						return;
				}
			}

			base.OnKeyDown(e);
		}
        void UpdateDMTHTX(DataTable dtImport)
        {
            SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
            SqlCommand sqlCom = sqlCon.CreateCommand();

            sqlCom.CommandText = "sp_Update_Ct";
            sqlCom.CommandType = CommandType.StoredProcedure;

            sqlCom.Parameters.Clear();

          
            sqlCom.Parameters.AddWithValue("@CREATE_LOG", Common.GetCurrent_Log());
            sqlCom.Parameters.AddWithValue("@NAM", Element.sysWorkingYear);
            sqlCom.Parameters.AddWithValue("@Ma_DvCs", Element.sysMa_DvCs);

            //Tạo Table cho TVP_PH
            SqlParameter paraCt = new SqlParameter();
            paraCt.SqlDbType = SqlDbType.Structured;
            paraCt.ParameterName = "@TVP_Import";

            sqlCom.CommandText = "sp_Update_DMTHTX";
            //sp_Update_KHVTPT

            //TVP_CT
            paraCt.TypeName = "TVP_DMTHTX";
            paraCt.Value = Voucher.GetTVPValue("R81DMVTTHTX", "TVP_DMTHTX", dtImport);
            sqlCom.Parameters.Add(paraCt);

            try
            {
                sqlCom.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                sqlCom.CommandText = "WHILE @@TRANCOUNT > 0 ROLLBACK TRANSACTION";
                sqlCom.CommandType = CommandType.Text;
                sqlCom.Parameters.Clear();
                sqlCom.ExecuteNonQuery();

                MessageBox.Show("Có lỗi xảy ra :" + ex.Message);

            }
        }
		void btImport_Click(object sender, EventArgs e)
		{

            frmReadExcel_ToFrom frmImport = new frmReadExcel_ToFrom();
            frmImport.Load("DMTH");

            if (frmImport.isAccept && frmImport.dtImport != null)
            {
                UpdateDMTHTX(frmImport.dtImport);
            }
            FillData();
		}

		#endregion
	}
}
