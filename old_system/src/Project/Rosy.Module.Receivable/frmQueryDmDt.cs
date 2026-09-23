using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Element;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Data;
using Rosy.Module;

namespace RosyModule.Receivable
{
	public partial class frmQueryDmDt : frmView
	{
		#region Khai bao bien

		DataTable dtDmCbNv;
		DataTable dtDmNhDt;
		DataTable dtDmKv;
		DataTable dtDmDt;

		BindingSource bdsDmCbNv = new BindingSource();
		BindingSource bdsDmNhDt = new BindingSource();
		BindingSource bdsDmKv = new BindingSource();
		BindingSource bdsDmDt = new BindingSource();

		private DataRow drCurrent;

		#endregion

		#region Contructor

		public frmQueryDmDt()
		{
			InitializeComponent();

			this.cboMa_Dt_CbNv.TextChanged += new EventHandler(cboMa_Dt_CbNv_TextChanged);
			this.cboMa_Kv.TextChanged += new EventHandler(cboMa_Kv_TextChanged);
			this.cboMa_Nh_Dt.TextChanged += new EventHandler(cboMa_Nh_Dt_TextChanged);

			this.btExit.Click += new EventHandler(btExit_Click);
		}

		public override void Load()
		{
			this.Build();
			this.FillData();

			this.BindingLanguage();

			this.Show();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{
			dgvDmDt.strZone = "DMDT";
			dgvDmDt.BuildGridView();

			cboMa_Dt_CbNv.lstItem.BuildListView("MA_DT:100,TEN_DT:200");
			cboMa_Dt_CbNv.lstItem.Width = 400;

			cboMa_Kv.lstItem.Width = 400;
			cboMa_Kv.lstItem.BuildListView("MA_KV:100,TEN_KV:200");

			cboMa_Nh_Dt.lstItem.Width = 400;
			cboMa_Nh_Dt.lstItem.BuildListView("MA_NH_DT:100,TEN_NH_DT:200");
		}

		private void FillData()
		{			
			dtDmCbNv = DataTool.SQLGetDataTable("R81DmDt", "", "Ma_Nh_Dt IN (SELECT Ma_Nh_Dt FROM R81DmNhDt WHERE Loai_Nh_Dt = 'NV')", "Ma_Dt");
			bdsDmCbNv.DataSource = dtDmCbNv;
			cboMa_Dt_CbNv.lstItem.FillListView(dtDmCbNv);

			dtDmKv = DataTool.SQLGetDataTable("R81DmKv", "", "", "Ma_Kv");
			bdsDmKv.DataSource = dtDmKv;
			cboMa_Kv.lstItem.FillListView(bdsDmKv);

			dtDmNhDt = DataTool.SQLGetDataTable("R81DmNhDt", "", "Nh_Cuoi = 1", "Ma_Nh_Dt");
			bdsDmNhDt.DataSource = dtDmNhDt;
			cboMa_Nh_Dt.lstItem.FillListView(bdsDmNhDt);

			dtDmDt = DataTool.SQLGetDataTable("R81DmDt", "", "", "Ma_Dt");
			bdsDmDt.DataSource = dtDmDt;
			dgvDmDt.DataSource = bdsDmDt;

			ExportControl = dgvDmDt;
			this.bdsSearch = bdsDmDt;
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmDt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmDt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmDt.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmDt.NewRow();
			}

			RosyList.frmEdit frmEdit = (RosyList.frmEdit)Activator.CreateInstance(Type.GetType("RosyList.frmDmDt_Edit, Rosy.List", true));
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmDt.Position >= 0)
						dtDmDt.ImportRow(drCurrent);
					else
						dtDmDt.Rows.Add(drCurrent);

					bdsDmDt.Position = bdsDmDt.Find("MA_DT", drCurrent["MA_DT"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmDt.Current).Row);
				}

				dtDmDt.AcceptChanges();
			}
			else
				dtDmDt.RejectChanges();
		}

		public void Filter()
		{
			string strKey = "(1 = 1) ";

			if (cboMa_Dt_CbNv.Text != string.Empty)
				strKey = strKey + " AND (Ma_Dt = '" + cboMa_Dt_CbNv.Text + "')";

			if (cboMa_Kv.Text != string.Empty)
				strKey = strKey + " AND (Ma_Kv = '" + cboMa_Kv.Text + "')";

			if (cboMa_Nh_Dt.Text != string.Empty)
				strKey = strKey + " AND (Ma_Nh_Dt = '" + cboMa_Nh_Dt.Text + "')";

			this.bdsDmDt.Filter = strKey;
		}

		public override void Delete()
		{
			if (bdsDmDt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmDt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81DMDT", drCurrent))
			{
				bdsDmDt.RemoveAt(bdsDmDt.Position);
				dtDmDt.AcceptChanges();
			}
		}

		#endregion

		void cboMa_Dt_CbNv_TextChanged(object sender, EventArgs e)
		{
			this.Filter();
		}

		void cboMa_Kv_TextChanged(object sender, EventArgs e)
		{
			this.Filter();
		}

		void cboMa_Nh_Dt_TextChanged(object sender, EventArgs e)
		{
			this.Filter();
		}

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
