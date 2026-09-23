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
	public partial class frmDmTinChap : RosyList.frmView
	{
		#region Khai bao bien
		
		DataTable dtDmTinChap;
		DataRow drCurrent;
		BindingSource bdsDmTinChap = new BindingSource();
		rsDataGridView dgvDmTinChap = new rsDataGridView();
		string strMa_Dt = string.Empty;

		#endregion 						

		#region Contructor

		public frmDmTinChap()
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

		public void Load(string strMa_Dt)
		{
			this.strMa_Dt = strMa_Dt;
			this.Load();
		}

		#endregion

		#region Build, FillData

		private void Build()
		{		
			dgvDmTinChap.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvDmTinChap);

			dgvDmTinChap.strZone = "DMTINCHAP";
			dgvDmTinChap.BuildGridView();
		}

		private void FillData()
		{
			dtDmTinChap = DataTool.SQLGetDataTable("R81DmTinChap", null, "Ma_Dt = '" + strMa_Dt + "'", null);

			bdsDmTinChap.DataSource = dtDmTinChap;
			dgvDmTinChap.DataSource = bdsDmTinChap;
			bdsDmTinChap.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmTinChap;
			ExportControl = dgvDmTinChap;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == String.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmTinChap.Rows.Count - 1; i++)
				if (((string)dtDmTinChap.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmTinChap.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmTinChap.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmTinChap.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmTinChap.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmTinChap.NewRow();
				drCurrent["Ma_Dt"] = strMa_Dt;
			}

			frmDmTinChap_Edit frmEdit = new frmDmTinChap_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmTinChap.Position >= 0)
						dtDmTinChap.ImportRow(drCurrent);
					else
						dtDmTinChap.Rows.Add(drCurrent);

					bdsDmTinChap.Position = bdsDmTinChap.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmTinChap.Current).Row);

				dtDmTinChap.AcceptChanges();
			}
			else
				dtDmTinChap.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmTinChap.Position < 0)
				return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}

			DataRow drCurrent = ((DataRowView)bdsDmTinChap.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;
		
			if (DataTool.SQLDelete("R81DmTinChap", drCurrent))
			{
				bdsDmTinChap.RemoveAt(bdsDmTinChap.Position);
				dtDmTinChap.AcceptChanges();
			}
		}

		#endregion 

		#region Su kien


		#endregion 
	}
}