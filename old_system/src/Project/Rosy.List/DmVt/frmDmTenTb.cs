using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Element;

namespace RosyList
{
	public partial class frmDmTenTb : RosyList.frmView
	{
		#region Khai bao bien

		DataTable dtDmType;
		BindingSource bdsDmType = new BindingSource();
		rsDataGridView dgvDmType = new rsDataGridView();

		DataRow drCurrent;
		public string strType = string.Empty;
       
		#endregion

		#region Contructor

        public frmDmTenTb()
		{
			InitializeComponent();

		
           
			this.dgvDmType.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmType_CellMouseDoubleClick);
			
		}

     

		void cboType_SelectedValueChanged(object sender, EventArgs e)
		{
			this.FillData();	
		}
		
		public override void Load()
		{
			

			Build();
			FillData();
			BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

        public void LoadLookup(bool bLookup)
        {
          

            Build();
            FillDataLookup();
            BindingLanguage();

            if (this.isLookup)
                this.ShowDialog();
            else
                this.Show();
        }
      
		public void Load(string strType)
		{
			this.strType = strType;

			this.Load();
		}

		public override void LoadLookup()
		{
            bool blookup = true;
            this.LoadLookup(blookup);
		}
		
		#endregion

		#region Build, FillData
		private void Build()
		{		
			dgvDmType.Dock = DockStyle.Fill;
            dgvDmType.strZone = "DMTENTB";
			dgvDmType.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmType);
		}

		private void FillData()
		{
			string strKey = strLookupKeyFilter;

			dtDmType = DataTool.SQLGetDataTable("R81DmTenTb", null, strKey, null);

			bdsDmType.DataSource = dtDmType;
			dgvDmType.DataSource = bdsDmType;
			bdsDmType.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmType;
			ExportControl = dgvDmType;

			if (this.isLookup)
				this.MoveToLookupValue();
		}
        private void FillDataLookup()
        {
            string strKey = strLookupKeyFilter;

            //if (strKey == string.Empty || strLookupKeyFilter == null)
            //    strKey = "Type = '" + cboType.Text + "'";
            //else
            //    strKey = strKey + " AND (Type = '" + cboType.Text + "')";

            dtDmType = DataTool.SQLGetDataTable("R81DmTenTb", null, strKey, null);

            bdsDmType.DataSource = dtDmType;
            dgvDmType.DataSource = bdsDmType;
            bdsDmType.Position = 0;

            //Uy quyen cho lop co so tim kiem           
            bdsSearch = bdsDmType;
            ExportControl = dgvDmType;

            if (this.isLookup)
                this.MoveToLookupValue();
        }

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmType.Rows.Count - 1; i++)
				if (((string)dtDmType.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmType.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmType.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmType.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmType.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmType.NewRow();

            frmDmTenTb_Edit frmEdit = new frmDmTenTb_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmType.Position >= 0)
						dtDmType.ImportRow(drCurrent);
					else
						dtDmType.Rows.Add(drCurrent);

                    bdsDmType.Position = bdsDmType.Find("Ma_Tb_Nhom", drCurrent["Ma_Tb_Nhom"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmType.Current).Row);

				dtDmType.AcceptChanges();
			}
			else
				dtDmType.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmType.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmType.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R81DmTenTb", drCurrent))
			{
				bdsDmType.RemoveAt(bdsDmType.Position);
				dtDmType.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsDmType.Count <= 0)
				return;

			
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmType == null || bdsDmType.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmType.Current).Row;
			DataTable dtTemp = dtDmType.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmType.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmType.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmType_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			this.EnterProcess();
		}

		#endregion 
	}
}