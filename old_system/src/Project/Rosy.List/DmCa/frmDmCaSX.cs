using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem;
using RosySystem.Element;


namespace RosyList
{
	public partial class frmDmCaSX : RosyList.frmView
	{

		#region Khai bao bien

		DataTable dtDmCa;
		DataRow drCurrent;
		BindingSource bdsDmCa = new BindingSource();
		rsDataGridView dgvDmCa = new rsDataGridView();

		#endregion

		#region Contructor

        public frmDmCaSX()
		{
			InitializeComponent();

			this.dgvDmCa.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmCa_CellMouseDoubleClick);
			this.btImport.Click +=new EventHandler(btImport_Click);

			this.btFilter.Click += new EventHandler(btFilter_Click);
            this.btCreateCa.Click += new EventHandler(btCreateCa_Click);
		}

        

		public override void Load()
		{
			Build();
			FillData(DateTime.Now.AddDays(-30), DateTime.Now);
			BindingLanguage();

            if(!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New))
            {
                btCreateCa.Visible = false;
            }
            

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public override void LoadLookup()
		{
			this.Load();
		}
		
		#endregion

		#region Build, FillData
		private void Build()
		{		
			dgvDmCa.Dock = DockStyle.Fill;
			dgvDmCa.strZone = "DMCASX";
			dgvDmCa.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmCa);
		}

		private void FillData(DateTime dteNgay_Filter1, DateTime dteNgay_Filter2)
		{
			string strKey = "Ngay_Sx BETWEEN '" + dteNgay_Filter1.ToShortDateString() + "' AND '" + dteNgay_Filter2.ToShortDateString() + "'";
            dtDmCa = DataTool.SQLGetDataTable("R81DMCASX", null, strKey, "Ma_Ca DESC");

			bdsDmCa.DataSource = dtDmCa;
			dgvDmCa.DataSource = bdsDmCa;
			bdsDmCa.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmCa;
			ExportControl = dgvDmCa;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmCa.Rows.Count - 1; i++)
				if (((string)dtDmCa.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmCa.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmCa.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmCa.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmCa.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmCa.NewRow();

			frmDmCaSX_Edit frmEdit = new frmDmCaSX_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmCa.Position >= 0)
						dtDmCa.ImportRow(drCurrent);
					else
						dtDmCa.Rows.Add(drCurrent);

					bdsDmCa.Position = bdsDmCa.Find("MA_CA", drCurrent["MA_CA"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmCa.Current).Row);

				dtDmCa.AcceptChanges();
			}
			else
				dtDmCa.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmCa.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmCa.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DMCASX", drCurrent))
			{
				bdsDmCa.RemoveAt(bdsDmCa.Position);
				dtDmCa.AcceptChanges();
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmCa == null || bdsDmCa.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmCa.Current).Row;
			DataTable dtTemp = dtDmCa.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmCa.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmCa.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmCa_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMCASX", dtDmCa);
		}

		void btFilter_Click(object sender, EventArgs e)
		{
			frmDmCa_Filter frmFilter = new frmDmCa_Filter();
			frmFilter.Load();

			if (frmFilter.isAccept)
			{
				this.FillData(Library.StrToDate(frmFilter.dteNgay_Ct1.Text), Library.StrToDate(frmFilter.dteNgay_Ct2.Text));
			}
		}
        void btCreateCa_Click(object sender, EventArgs e)
        {
            frmDmCa_CreateAuto frm = new frmDmCa_CreateAuto();
            frm.Load();
            if (frm.isAccept)
                FillData(Library.StrToDate(frm.dteNgay_Ct1.Text), Library.StrToDate(frm.dteNgay_Ct2.Text));
        }
		#endregion 
	}
}