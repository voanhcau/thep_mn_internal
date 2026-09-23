using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosyList;
using RosySystem.Public;

namespace RosyModule
{
	public partial class frmImportAccess : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtImportAccess, dtAccess, dtSo_Me;
        BindingSource bdsImportAccess = new BindingSource();
        OleDbConnection conn;
        OleDbDataAdapter dataAdapter;
		DataRow drDmCt;
		public bool Is_Accept = false, show_Msg = true;
        string strColumnFormat, strSo_Me, strMa_Ct;

		#endregion

		#region Contructor

        public frmImportAccess()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			this.btRefresh.Click += new EventHandler(btRefresh_Click);
            this.btOpenDialog.Click += new EventHandler(btOpenDialog_Click);
            this.btConnect.Click += new EventHandler(btConnect_Click);
            this.txtFile_Path.Validating += new CancelEventHandler(txtFile_Path_Validating);
            this.cbxTable_Name.TextChanged += new EventHandler(cbxTable_Name_TextChanged);
		}

        void cbxTable_Name_TextChanged(object sender, EventArgs e)
        {
            Common.SetBufferValue("TableName", cbxTable_Name.Text);
        }

        void txtFile_Path_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFile_Path.Text))
                this.OpenDialog();
        }

        #endregion

		#region Method

		public void Load(DataRow drHeader)
		{
            strMa_Ct = drHeader["Ma_Ct"].ToString();

            dteNgay_Ct1.Text = Common.GetDate(Element.sysNgay_Ct1.Year, Element.sysNgay_Ct1.Month, 1).ToShortDateString();
			
            if (drHeader.Table.Columns.Contains("Ngay_Ct") && drHeader["Ngay_Ct"] != DBNull.Value)
				dteNgay_Ct2.Text = Library.DateToStr((DateTime)drHeader["Ngay_Ct"]);

			drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", strMa_Ct);

			Build();

            if (strMa_Ct == "PNSB")
            {
                chkPhoi_Nong.Visible = false;
                chkPhoi_Nguoi.Visible = false;
                chkPhoi_TG.Visible = false;
            }

			this.ShowDialog();
		}

		void Build()
		{
			dgvImportAccess.strZone = "IMPORTACCESS";
            dgvImportAccess.BuildGridView();

			ExportControl = dgvImportAccess;
            dgvImportAccess.ReadOnly = false;

			foreach (DataGridViewColumn dgvc in dgvImportAccess.Columns)
				dgvc.ReadOnly = true;

            if (dgvImportAccess.Columns.Contains("CHON"))
                dgvImportAccess.Columns["CHON"].ReadOnly = false;

			if (Common.GetBufferValue("ImportAccessPath") != null)
				txtFile_Path.Text = Common.GetBufferValue("ImportAccessPath");
			else
				txtFile_Path.Text = "";

			//if (Common.GetBufferValue("TableName") != string.Empty)
			//    cbxTable_Name.Text = Common.GetBufferValue("TableName");

            if (Common.GetBufferValue("ImportAccessPath") != null && Common.GetBufferValue("TableName") != string.Empty)
            {
                show_Msg = false;
                this.Connect();
            }

            if (Common.GetBufferValue("Ca1") != string.Empty)
                txtCa1.Text = Common.GetBufferValue("Ca1");

            if (Common.GetBufferValue("Ca2") != string.Empty)
                txtCa2.Text = Common.GetBufferValue("Ca2");

            if (Common.GetBufferValue("Me1") != string.Empty)
                txtMe1.Text = Common.GetBufferValue("Me1");
            
            if (Common.GetBufferValue("Me2") != string.Empty)
                txtMe1.Text = Common.GetBufferValue("Me2");
		}

        void btOpenDialog_Click(object sender, EventArgs e)
        {
            this.OpenDialog();
        }

        void Connect()
        {
            try
            {
                string connectionString = "provider=Microsoft.JET.OLEDB.4.0;" + "data source = " + txtFile_Path.Text;

                conn = new OleDbConnection(connectionString);

                conn.Open();

                string commandString = "SELECT * FROM [" + cbxTable_Name.Text + "]";
                dataAdapter = new OleDbDataAdapter(commandString, conn);
                dtAccess = new DataTable();
                dataAdapter.Fill(dtAccess);

                strColumnFormat = dtAccess.Columns["Ngaysanxuat"].DataType.ToString();
             
                if(show_Msg == true)
                    Common.MsgOk("Kết nối thành công");
            }
            catch (Exception ex)
            {
                Common.MsgOk(ex.ToString());
            }
        }

        void OpenDialog()
        {
            Stream myStream = null;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Access files (*.mdb, *.mde)|*.mdb; *.mde|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            ofd.Title = @"Chọn đường dẫn file dữ liệu";

            if (Common.GetBufferValue("ImportAccessPath") != string.Empty)
                ofd.InitialDirectory = Common.GetBufferValue("ImportAccessPath");
            else
                ofd.InitialDirectory = Parameters.GetParaValue("ACCESS_DATABASE").ToString();

            if (Common.GetBufferValue("TableName") != string.Empty)
                cbxTable_Name.Text = Common.GetBufferValue("TableName");

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
					using (myStream)
					{
						// read the first line from the file and write it the textbox.
						if (txtFile_Path.Text == string.Empty)
							txtFile_Path.Text = ofd.FileName;
						if (Common.GetBufferValue("ImportAccessPath") == string.Empty)
							Common.SetBufferValue("ImportAccessPath", txtFile_Path.Text);
					}

                    string connectionString = "provider=Microsoft.JET.OLEDB.4.0;" + "data source = " + ofd.FileName;

                    txtFile_Path.Text = ofd.FileName;

					if (Common.GetBufferValue("ImportAccessPath") != null)
						Common.SetBufferValue("ImportAccessPath", txtFile_Path.Text);

                    conn = new OleDbConnection(connectionString);

                    conn.Open();

                    foreach (DataRow dr in conn.GetSchema("Tables").Select("TABLE_TYPE = 'TABLE'"))
                        cbxTable_Name.Items.Add(dr["TABLE_NAME"].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

		void FillData()
		{
            //DataRow drDmCt = DataTool.SQLGetDataRowByID("R00DmCt", "Ma_Ct", txtMa_Ct.Text);

            if (drDmCt== null)
                return;

            string strKey = "(1=1) ";
            string strTableCt = drDmCt["Table_Ct"].ToString();

            if (strTableCt == string.Empty)
                return;

            //DataTable dtTestData = SQLExec.ExecuteReturnDt("SELECT TOP 0 * FROM " + strTableCt + " WHERE 0 = 1");

			if (!dteNgay_Ct1.IsNull)
                strKey += " AND Ngaysanxuat >= Format (#" + dteNgay_Ct1.Text + "#, 'MM/dd/yyyy')";

            if (!dteNgay_Ct2.IsNull)
                strKey += " AND Ngaysanxuat <= Format (#" + dteNgay_Ct2.Text + "#, 'MM/dd/yyyy')";

			if (txtCa1.Text != string.Empty)
                strKey += " AND Casanxuat >= '" + txtCa1.Text + "'";

            if (txtCa2.Text != string.Empty)
                strKey += " AND Casanxuat <= '" + txtCa2.Text + "'";

            if(txtMe1.Text != string.Empty)
                strKey += " AND Kyhieume >= '" + txtMe1.Text + "'";

            if (txtMe2.Text != string.Empty)
                strKey += " AND Kyhieume <= '" + txtMe2.Text + "'";

            if (chkPhoi_Nong.CheckState == CheckState.Checked)
                strKey += " AND Socaynapnong > 0";

            if(chkPhoi_TG.CheckState == CheckState.Checked)
                strKey += " AND Socaynaptrunggian > 0";

            if (chkPhoi_Nguoi.CheckState == CheckState.Checked)
                strKey += " AND Socayrabai > 0";

            //Ghi nhớ các trường dữ liệu
            Common.SetBufferValue("Ca1", txtCa1.Text);
            Common.SetBufferValue("Ca2", txtCa2.Text);
            Common.SetBufferValue("Me1", txtMe1.Text);
            Common.SetBufferValue("Me2", txtMe2.Text);

            if (chkInheritedExcept.Checked)
            {
                dtSo_Me = SQLExec.ExecuteReturnDt("SELECT DISTINCT So_Me FROM " + strTableCt + " WHERE So_Me <> '' AND Ma_Ct = '" + strMa_Ct + "'");

                if (dtSo_Me.Rows.Count > 0 && string.IsNullOrEmpty(strSo_Me))
                {
                    foreach (DataRow dr in dtSo_Me.Rows)
                    {
                        strSo_Me += "'" + dr["So_Me"].ToString() + "', ";
                    }
                    strSo_Me = strSo_Me.Remove(strSo_Me.Length - 2, 1);
                }
                if (!string.IsNullOrEmpty(strSo_Me))
                    strKey += " AND Kyhieume NOT IN (" + strSo_Me + ")";
            }

            string strQuery = @"
			SELECT CBool(0) AS Chon, Ngaysanxuat, Casanxuat, Kyhieume, Loaiphoi, Chieudaiphoi, Macthep, 
                    Tongsocay, Tongkhoiluong, Socaynapnong, Socaynaptrunggian, Socayrabai, 
                    SocayPHdai, KhoiluongPHdai, SocayPHngan, KhoiluongPHngan, PHcayngan1, PHdai4, PHcayngan2, PHdai5,
                    SocayCXL, KhoiluongCXL, SocayKPH, KhoiluongKPH
				FROM [" + cbxTable_Name.Text + @"]
				WHERE " + @strKey + @"
				ORDER BY Ngaysanxuat, Kyhieume";

            OleDbDataAdapter daImportAccess = new OleDbDataAdapter(strQuery, conn);

            dtImportAccess = new DataTable();
            daImportAccess.Fill(dtImportAccess);

            bdsImportAccess.DataSource = dtImportAccess;
            dgvImportAccess.DataSource = bdsImportAccess;

            bdsSearch = bdsImportAccess;
            bdsLookup = bdsImportAccess;
            
		}

		bool FormCheckValid()
		{
            if (dtImportAccess == null || dtImportAccess.Select("Chon = true").Length == 0)
			{
				Common.MsgCancel("Không có dữ liệu import!");
				return false;
			}

			return true;
		}

		#endregion

		#region Event

		void btAccept_Click(object sender, EventArgs e)
		{
            if (this.FormCheckValid())
			{
				this.Is_Accept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.Is_Accept = false;
			this.Close();
		}

		void btRefresh_Click(object sender, EventArgs e)
		{
			this.FillData();
		}

        void btConnect_Click(object sender, EventArgs e)
        {
            this.show_Msg = true;
            this.Connect();
        }

		protected override void OnKeyDown(KeyEventArgs e)
		{
            switch (e.KeyCode)
            {
                case Keys.A:
                    if (e.Modifiers == Keys.Control)
                    {
                        for (int i = 0; i < dgvImportAccess.Rows.Count;i++)
                        {
                            dtImportAccess.Rows[i]["Chon"] = true;
                        }
                    }
                    break;

                case Keys.U:
                    if (e.Modifiers == Keys.Control)
                    {
                        for (int i = 0; i < dgvImportAccess.Rows.Count; i++)
                        {
                            dtImportAccess.Rows[i]["Chon"] = false;
                        }
                    }
                    break;
                case Keys.O:
                    if (e.Modifiers == Keys.Control)
                        this.OpenDialog();
                    break;
            }

            if (e.KeyCode == Keys.Space)
                base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
                this.Close();

            if (e.KeyCode == Keys.F5)
				this.FillData();
			else
				base.OnKeyDown(e);

		}
		#endregion
	}
}