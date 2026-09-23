using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RosySystem.Control;
using RosySystem.Common;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using RosySystem.Data;

namespace RosyModule.General
{
	public partial class frmReadExcel_KT : RosySystem.Customize.frmView
	{
		public System.Data.DataTable dtImport;
		BindingSource bdsImport = new BindingSource();

		public bool isAccept = false;
		string strMa_Ct = "";

		public frmReadExcel_KT()
		{
			InitializeComponent();

			

			btFilePath.Click += new EventHandler(btFilePath_Click);
			btRefresh.Click += new EventHandler(btRefresh_Click);
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public override void Load()
		{
			if (Common.GetBufferValue("ImportVoucher_RowHeader") != null)
				numRowHeader.Value = Int32.Parse(Common.GetBufferValue("ImportVoucher_RowHeader"));
			else
				numRowHeader.Value = 1;

			if (Common.GetBufferValue("ImportVoucher_RowEnd") != null)
				numRowEnd.Value = Int32.Parse(Common.GetBufferValue("ImportVoucher_RowEnd"));
			else
				numRowEnd.Value = 100;

			if (Common.GetBufferValue("ImportVoucher_ColEnd") != null)
				numColEnd.Value = Int32.Parse(Common.GetBufferValue("ImportVoucher_ColEnd"));
			else
				numColEnd.Value = 35;

			
			//txtObject.InputMask = (string)RosySystem.Library.Parameters.GetParaValue("IMPORT_CT");//"MA_KM,MA_BP,TK_NO,MA_KHO"; //,TK_CO



			this.BindingLanguage();
			LoadCombo();
			this.Show();
		}

		public void Load(string strMa_Ct)
		{
			this.strMa_Ct = strMa_Ct;
			
			this.Load();
		}

		void FillData()
		{
			dtImport = Common.ReadExcel(txtFilePath.Text, 1, Convert.ToInt32(numRowHeader.Value), Convert.ToInt32(numRowEnd.Value), Convert.ToInt32(numColEnd.Value));

			if (dtImport != null)
			{
                
			    bdsImport.DataSource = dtImport;
				
				dgvImport.AutoGenerateColumns = true;
				dgvImport.DataSource = bdsImport;

				this.ExportControl = dgvImport;
				this.bdsSearch = bdsImport;
			}
		}

		void btFilePath_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "xls files (*.xls)|*.xls";
			ofd.RestoreDirectory = true;

			if (Common.GetBufferValue("ImportExcelPath") != string.Empty)
				ofd.InitialDirectory = Common.GetBufferValue("ImportExcelPath");
			else
				ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

			if (ofd.ShowDialog() == DialogResult.OK)
			{
				txtFilePath.Text = ofd.FileName;

				Common.SetBufferValue("ImportExcelPath", System.IO.Path.GetDirectoryName(ofd.FileName));

				this.FillData();
			}
		}

		
		void LoadCombo()
        {
			string strObject = (string)RosySystem.Library.Parameters.GetParaValue("IMPORT_CT");
            System.Data.DataTable dtObject = SQLExec.ExecuteReturnDt("SELECT String AS Object FROM dbo.fn_Split('" + strObject + "')");

			cboObject.Items.Clear();
			cboObject.Items.Add(string.Empty);
			foreach (DataRow drGrade in dtObject.Rows)
			{
				cboObject.Items.Add(drGrade["Object"]);
			}
			cboObject.SelectedItem = string.Empty;
		}
		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			Common.SetBufferValue("ImportVoucher_RowHeader", numRowHeader.Value);
			Common.SetBufferValue("ImportVoucher_RowEnd", numRowEnd.Value);
			Common.SetBufferValue("ImportVoucher_ColEnd", numColEnd.Value);
            if (Save())
            {
                Common.MsgOk("Đã cập nhật xong!");
            }
            else
            { Common.MsgOk("Cập nhật không thành công!"); }
            //this.isAccept = true;
            //this.Close();
		}
        bool Save()
        {

            if (dtImport != null)
            {
                SqlConnection sqlCon = SQLExec.GetNewSQLConnection();
                SqlCommand sqlCom = sqlCon.CreateCommand();

                sqlCom.CommandText = "sp_Update_Ct";
                sqlCom.CommandType = CommandType.StoredProcedure;

                sqlCom.Parameters.Clear();

                sqlCom.Parameters.AddWithValue("@LOAI_CT", cboObject.Text);
				sqlCom.Parameters.AddWithValue("@LASTMODIFY_LOG", Common.GetCurrent_Log());

				//Tạo Table cho TVP_PH
				SqlParameter paraCt = new SqlParameter();
                paraCt.SqlDbType = SqlDbType.Structured;
                paraCt.ParameterName = "@TVP_Import";

                sqlCom.CommandText = "sp_Update_IMPCT";
                //sp_Update_KHVTPT

                //TVP_CT
                paraCt.TypeName = "TVP_IMPCT";
                paraCt.Value = Voucher.GetTVPValue("R00IMPCT", "TVP_IMPCT", dtImport);
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
            else
            {
                Common.MsgOk("Không có dữ liệu cập nhật!!!");
                return false;
            }
            return true;
        }
		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

	}
}
