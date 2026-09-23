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
using System.Globalization;

namespace RosyList
{
	public partial class frmDmPLCTrinh : RosyList.frmView
	{
		#region Khai bao bien
		
		DataTable dtDmPLCTrinh;
		DataRow drCurrent;
		BindingSource bdsDmPLCTrinh = new BindingSource();
		rsDataGridView dgvDmPLCTrinh = new rsDataGridView();
		string strMa_CTrinh = string.Empty;

		#endregion 						

		#region Contructor

        public frmDmPLCTrinh()
		{
			InitializeComponent();
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

		public void Load(string strMa_CTrinh)
		{
			this.strMa_CTrinh = strMa_CTrinh;
			this.Load();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{		
			dgvDmPLCTrinh.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvDmPLCTrinh);

			dgvDmPLCTrinh.strZone = "DMPLCTRINH";
			dgvDmPLCTrinh.BuildGridView();
		}

		private void FillData()
		{
			dtDmPLCTrinh = DataTool.SQLGetDataTable("R81DmPLCTrinh", null, "Ma_CTrinh = '" + strMa_CTrinh + "'", null);

			bdsDmPLCTrinh.DataSource = dtDmPLCTrinh;
			dgvDmPLCTrinh.DataSource = bdsDmPLCTrinh;
			bdsDmPLCTrinh.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmPLCTrinh;
			ExportControl = dgvDmPLCTrinh;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == String.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmPLCTrinh.Rows.Count - 1; i++)
				if (((string)dtDmPLCTrinh.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmPLCTrinh.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmPLCTrinh.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmPLCTrinh.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmPLCTrinh.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmPLCTrinh.NewRow();
				drCurrent["Ma_CTrinh"] = strMa_CTrinh;
			}

            frmDmPLCTrinh_Edit frmEdit = new frmDmPLCTrinh_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmPLCTrinh.Position >= 0)
						dtDmPLCTrinh.ImportRow(drCurrent);
					else
						dtDmPLCTrinh.Rows.Add(drCurrent);

					bdsDmPLCTrinh.Position = bdsDmPLCTrinh.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmPLCTrinh.Current).Row);

				dtDmPLCTrinh.AcceptChanges();
			}
			else
				dtDmPLCTrinh.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmPLCTrinh.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmPLCTrinh.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DmPLCTrinh", drCurrent))
			{
				bdsDmPLCTrinh.RemoveAt(bdsDmPLCTrinh.Position);
				dtDmPLCTrinh.AcceptChanges();
			}
		}

		#endregion 

		#region Su kien


		#endregion 
	}
}