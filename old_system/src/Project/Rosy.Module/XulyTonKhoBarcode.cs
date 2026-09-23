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
using System.Collections;
using System.Data.SqlClient;

namespace RosyModule
{
	public partial class XulyTonKhoBarcode : RosySystem.Customize.frmView
	{
		#region Declare

		public DataTable dtXuatVTriKho;
		BindingSource bdsXuatVTriKho = new BindingSource();
		
		
		frmVoucher_Edit frmVoucher_Edit;
		DataRow drCurrent, drDmCt_Current;
        string strMa_Kho = string.Empty;
		DateTime dtNgay_Ct;

		public bool Is_Accept = false;

		#endregion

		#region Contructor

        public XulyTonKhoBarcode()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
			
			this.KeyDown += new KeyEventHandler(frmInheritVoucher_KeyDown);
		}

		#endregion

		#region Method

		public void Load(string strMa_Kho)
		{
            this.strMa_Kho = strMa_Kho;
            //dteNgay_Ct2.Text = Library.DateToStr(DateTime.Now);

			Build();
			FillData();
			BindingLanguage();

			this.ShowDialog();
		}

		void Build()
		{
			dgvInheritVoucher.strZone = "TONBARCODE";
			
			dgvInheritVoucher.BuildGridView();

			ExportControl = dgvInheritVoucher;
			dgvInheritVoucher.ReadOnly = false;

		

			foreach (DataGridViewColumn dgvc in dgvInheritVoucher.Columns)
				dgvc.ReadOnly = true;

			if (dgvInheritVoucher.Columns.Contains("CHON"))
				dgvInheritVoucher.Columns["CHON"].ReadOnly = false;
			
			
		}

		void FillData()
		{
			Hashtable htPara = new Hashtable();

            //htPara.Add("NGAY_CT", dteNgay_Ct2.Text);
            //htPara.Add("MA_KHO", strMa_Kho);
            //htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            //dtXuatVTriKho = SQLExec.ExecuteReturnDt("Sp_GetXuatVTriKho", htPara, CommandType.StoredProcedure);

			bdsXuatVTriKho.DataSource = dtXuatVTriKho;
			dgvInheritVoucher.DataSource = bdsXuatVTriKho;

			bdsSearch = bdsXuatVTriKho;
			bdsLookup = bdsXuatVTriKho;
			
		}

		bool FormCheckValid()
		{
			if (dtXuatVTriKho == null || dtXuatVTriKho.Select("Chon = true").Length == 0)
			{
				Common.MsgCancel("Không có dữ liệu kế thừa. Bạn có muốn duyệt không ???");
                //return false;
			}

			return true;
		}

		#endregion

		#region Event

       
		bool Save()
		{
			if (dtXuatVTriKho == null)
				return false;

            if (!FormCheckValid())
                return false;

			
			try
			{
				

                Hashtable ht = new Hashtable();
                //ht.Add("NGAY_CT", dt);
                //ht.Add("MA_DVCS", Element.sysMa_DvCs);

                SQLExec.Execute("sp_DieuChinhBarcode", ht, CommandType.StoredProcedure);

				Common.MsgOk(Languages.GetLanguage("IMPORT_SUCCESS"));
			}
			catch (Exception ex)
			{
				Common.MsgOk(ex.Message);
				return false;
			}
			// 
			return true;
		}
		

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
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

		

		void frmInheritVoucher_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.A)
			{

				for (int i = 0; i < dtXuatVTriKho.Rows.Count; i++)
				{
					dtXuatVTriKho.Rows[i]["CHON"] = true;
				}
			}
			if (e.Control && e.KeyCode == Keys.U)
			{

				for (int i = 0; i < dtXuatVTriKho.Rows.Count; i++)
				{
					dtXuatVTriKho.Rows[i]["CHON"] = false;
				}
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5)
				this.FillData();
			else if (e.Control)
			{
				if (e.KeyCode == Keys.A)
					foreach (DataRow dr in dtXuatVTriKho.Rows)
						dr["Chon"] = true;
				else if (e.KeyCode == Keys.U)
					foreach (DataRow dr in dtXuatVTriKho.Rows)
					{
						dr["Chon"] = false;
						if (dtXuatVTriKho.Columns.Contains("Stt_Order"))
							dr["Stt_Order"] = 0;
					}
			}
			else
				base.OnKeyDown(e);
		}

		#endregion

	}
}
