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
using RosySystem.Data;
using System.Collections;
using RosySystem;

namespace RosyModule.HRM
{
    public partial class frmAddCBNV_QLDT : RosySystem.Customize.frmView
	{
		DataTable dtDsCbNv;
        DataTable dtDsCbNvChon;
        
        BindingSource bdsDsCbNv = new BindingSource();
        BindingSource bdsDsCbNvChon = new BindingSource();

        DataRow drImport;
		public bool isAccept = false;
		string strMa_Ct = "";

        public frmAddCBNV_QLDT()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
            this.btChuyen.Click += new EventHandler(btChuyen_Click);

            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Bp_Ct.Validating += new CancelEventHandler(txtMa_Bp_Ct_Validating);

            dgvDsCBNV.KeyDown += new KeyEventHandler(dgvDsCBNV_KeyDown);
		}

		public override void Load()
		{
            
            Build();
            FillData();

			this.BindingLanguage();

			this.ShowDialog();
		}

        public void Load(DataRow drQLDT)
        {
            txtMa_LopDT.Text = drQLDT["Ma_LopDT"].ToString();
            dteNgay_BD.Text = drQLDT["Ngay_BD"].ToString();
            dteNgay_KT.Text = drQLDT["Ngay_KT"].ToString();

            Build();
            FillData();

            this.BindingLanguage();

            this.ShowDialog();
        }

        void Build()
        {
            dgvDsCBNV.strZone = "CBNVDT";
            dgvDsCBNV.BuildGridView();
            dgvDsCBNV.ReadOnly = true;
            dgvDsCBNVChon.strZone = "CBNVDTCHON";
            dgvDsCBNVChon.BuildGridView();
            dgvDsCBNVChon.ReadOnly = true;

            ExportControl = dgvDsCBNV;

            dgvDsCBNV.ReadOnly = false;
            dgvDsCBNVChon.ReadOnly = false;

            foreach (DataGridViewColumn dgvc in dgvDsCBNV.Columns)
                dgvc.ReadOnly = true;
            foreach (DataGridViewColumn dgvc in dgvDsCBNVChon.Columns)
                dgvc.ReadOnly = true;

            if (dgvDsCBNV.Columns.Contains("CHON"))
                dgvDsCBNV.Columns["CHON"].ReadOnly = false;

            if (dgvDsCBNVChon.Columns.Contains("DELETED"))
                dgvDsCBNVChon.Columns["DELETED"].ReadOnly = false;
        }

		void FillData()
		{
            Hashtable ht = new Hashtable();
            ht.Add("MA_LOPDT", txtMa_LopDT.Text);
            ht.Add("MA_BP", txtMa_Bp.Text);
            ht.Add("MA_BP_CT", txtMa_Bp_Ct.Text);

            DataSet dsCbNv = SQLExec.ExecuteReturnDs("sp_GetDmCbNvQLDT", ht, CommandType.StoredProcedure);

            dtDsCbNv = dsCbNv.Tables[0];
            bdsDsCbNv.DataSource = dtDsCbNv;
            dgvDsCBNV.DataSource = bdsDsCbNv;

            dtDsCbNvChon = dsCbNv.Tables[1];
            bdsDsCbNvChon.DataSource = dtDsCbNvChon;
            dgvDsCBNVChon.DataSource = bdsDsCbNvChon;

            //this.bdsSearch = dgvDsCBNV;
			
		}

		

		void btRefresh_Click(object sender, EventArgs e)
		{
            //if (txtFilePath.Text == "")
            //    return;

            
            //string[] fileList = Directory.GetFiles(txtFilePath.Text);
            //foreach (string fileName in fileList)
            //{
            //    string strFileName = "";
            //    string strMa_Dt_CbNv = "";
            //    strFileName = Path.GetFileName(fileName).Trim();
            //    strMa_Dt_CbNv = strFileName.Substring(0, 5);

            //    if (DataTool.SQLCheckExist("R81DMDT", "Ma_Dt", strMa_Dt_CbNv))
            //    {
            //        drImport["Ma_Dt"] = strMa_Dt_CbNv;
            //        drImport["Path"] = strFileName;
            //        //DataRow[] drImport = dtImport.Select("Ma_Dt = '" + strMa_Dt_CbNv + "'");
            //        //drImport[0]["Path"] = fileName;
            //        //drImport.
            //    }


            //}
            //OpenFileDialog fileDialog = new OpenFileDialog();

            //fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //fileDialog.Filter = fileDialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*"; ;

            //if (fileDialog.ShowDialog() != DialogResult.OK)
            //    return;

            //FileInfo fiImage = new FileInfo(fileDialog.FileName);
            //FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            //picHinh.Image = new Bitmap(Image.FromStream(fs), picHinh.Size);
            //picHinh.SizeMode = PictureBoxSizeMode.Zoom;
		}
        void btChuyen_Click(object sender, EventArgs e)
        {
            foreach (DataRow drSelect in dtDsCbNv.Select("Chon = 1"))
            {
                //lấy thông tin sang dgv chon
                DataRow drChon = dtDsCbNvChon.NewRow();
                Common.CopyDataRow(drSelect, drChon);
                Common.SetDefaultDataRow(ref drChon);

                drChon["Ma_Dt_CbNv"] = drSelect["Ma_Dt"];
                drChon["Ten_Dt"] = drSelect["Ten_Dt"];
                drChon["Ngay_BD"] = dteNgay_BD.Text;
                drChon["Ngay_KT"] = dteNgay_KT.Text;
                drChon["So_QD"] = txtSo_QD.Text;
                drChon["Ma_LopDT"] = txtMa_LopDT.Text;
                drChon["Xep_Loai"] = txtXep_Loai.Text;

                dtDsCbNvChon.Rows.Add(drChon);
                dtDsCbNvChon.AcceptChanges();
                //xóa mã nhân viên đã chọn
                drSelect.Delete();

            }
        }
        bool Save()
        {
            Hashtable htChon = new Hashtable();
            string strSQL = "SELECT TOP 0 * FROM R09QTDT";
            DataTable dtQTDT = SQLExec.ExecuteReturnDt(strSQL);
            foreach (DataRow dr in dtDsCbNvChon.Rows)
            {
                DataRow drEdit_QTDT = dtQTDT.NewRow();
                drEdit_QTDT["Ma_Dt_CbNv"] = dr["Ma_Dt_CbNv"];
                drEdit_QTDT["Ngay_Bd"] = dr["Ngay_BD"];
                drEdit_QTDT["Ngay_Kt"] = dr["Ngay_KT"];
                drEdit_QTDT["Ma_LopDT"] = dr["Ma_LopDT"];
                drEdit_QTDT["So_QD"] = dr["So_QD"];
                drEdit_QTDT["Xep_Loai"] = dr["Xep_Loai"];

                if (!DataTool.SQLCheckExist("R09QTDT", new string[] { "Ma_LopDT", "Ma_Dt_CbNv" }, new object[] { dr["Ma_LopDT"], dr["Ma_Dt_CbNv"] }))
                {
                    DataTool.SQLUpdate(enuEdit.New, "R09QTDT", ref drEdit_QTDT);
                }

                if ((bool)dr["Deleted"])
                    DataTool.SQLDelete("R09QTDT", dr);            
            }
            
            return true;
        }
		void btAccept_Click(object sender, EventArgs e)
		{

            if (Save())
            {
                this.isAccept = true;
                this.Close();
            }
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}
        
        void txtMa_Bp_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp_Ct.Text.Trim();
            bool bRequi = true;

            DataRow drLookup = RosySystem.Public.Lookup.ShowLookup("Ma_Bp_Ct", strValue, bRequi, "Ma_Bp = '" + txtMa_Bp.Text + "' AND Nh_Cuoi = 1");

            if (bRequi && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp_Ct.Text = string.Empty;
                lbtTen_Bp_Ct.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_Ct.Text = (string)drLookup["Ma_Bp_Ct"];
                lbtTen_Bp_Ct.Text = (string)drLookup["Ten_Bp_Ct"];
                FillData();
            }
        }

        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequi = false;

            DataRow drLookup = RosySystem.Public.Lookup.ShowLookup("Ma_Bp", strValue, bRequi, string.Empty);

            if (bRequi && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
            }
            else
            {
                txtMa_Bp.Text = (string)drLookup["Ma_Bp"];
                lbtTen_Bp.Text = (string)drLookup["Ten_Bp"];
                txtMa_Bp_Ct.Text = string.Empty;
                FillData();
            }
        }

        void dgvDsCBNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {

                for (int i = 0; i < dtDsCbNv.Rows.Count; i++)
                {
                    dtDsCbNv.Rows[i]["CHON"] = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.U)
            {

                for (int i = 0; i < dtDsCbNv.Rows.Count; i++)
                {
                    dtDsCbNv.Rows[i]["CHON"] = false;
                }
            }
        }


      
	}
}
