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
	public partial class frmDmPLHd : RosyList.frmView
	{
		#region Khai bao bien
		
		DataTable dtDmPLHd;
		DataRow drCurrent;
		BindingSource bdsDmPLHd = new BindingSource();
		rsDataGridView dgvDmPLHd = new rsDataGridView();
		string strMa_Hd = string.Empty;

		#endregion 						

		#region Contructor

		public frmDmPLHd()
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

		public void Load(string strMa_Hd)
		{
			this.strMa_Hd = strMa_Hd;
			this.Load();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{		
			dgvDmPLHd.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvDmPLHd);

			dgvDmPLHd.strZone = "DMPLHD";
			dgvDmPLHd.BuildGridView();
		}

		private void FillData()
		{
			dtDmPLHd = DataTool.SQLGetDataTable("R81DmPLHd", null, "Ma_Hd = '" + strMa_Hd + "'", null);

			bdsDmPLHd.DataSource = dtDmPLHd;
			dgvDmPLHd.DataSource = bdsDmPLHd;
			bdsDmPLHd.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmPLHd;
			ExportControl = dgvDmPLHd;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == String.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmPLHd.Rows.Count - 1; i++)
				if (((string)dtDmPLHd.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmPLHd.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmPLHd.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmPLHd.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmPLHd.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmPLHd.NewRow();
				drCurrent["Ma_Hd"] = strMa_Hd;
			}

			frmDmPLHd_Edit frmEdit = new frmDmPLHd_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmPLHd.Position >= 0)
						dtDmPLHd.ImportRow(drCurrent);
					else
						dtDmPLHd.Rows.Add(drCurrent);

					bdsDmPLHd.Position = bdsDmPLHd.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmPLHd.Current).Row);

				dtDmPLHd.AcceptChanges();
			}
			else
				dtDmPLHd.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmPLHd.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmPLHd.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DmPLHd", drCurrent))
			{
				bdsDmPLHd.RemoveAt(bdsDmPLHd.Position);
				dtDmPLHd.AcceptChanges();
			}
		}

		#endregion 

		#region Su kien


		#endregion 
	}
}