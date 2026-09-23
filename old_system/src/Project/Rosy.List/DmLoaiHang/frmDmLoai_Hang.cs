using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem;

namespace RosyList
{
	public partial class frmDmLoai_Hang : RosyList.frmView
	{

		#region Khai bao bien
		DataTable dtDmLoai_Hang;
		DataRow drCurrent;
		BindingSource bdsDmLoai_Hang = new BindingSource();
		rsDataGridView dgvDmLoai_Hang = new rsDataGridView();

		#endregion 						

		#region Contructor

		public frmDmLoai_Hang()
		{
			InitializeComponent();

			this.dgvDmLoai_Hang.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmLoai_Hang_CellMouseDoubleClick);
			this.btImport.Click +=new EventHandler(btImport_Click);
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

		public override void LoadLookup()
		{
			this.Load();
		}
		
		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDmLoai_Hang.Dock = DockStyle.Fill;
			dgvDmLoai_Hang.strZone = "DMLOAIHANG";
			dgvDmLoai_Hang.BuildGridView(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(dgvDmLoai_Hang);
		}

		private void FillData()
		{
			dtDmLoai_Hang = DataTool.SQLGetDataTable("R81DMLOAIHANG", null, this.strLookupKeyFilter, null);

			dgvDmLoai_Hang.DataSource = bdsDmLoai_Hang;
			bdsDmLoai_Hang.DataSource = dtDmLoai_Hang;
			bdsDmLoai_Hang.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmLoai_Hang;
			ExportControl = dgvDmLoai_Hang;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmLoai_Hang.Rows.Count - 1; i++)
				if (((string)dtDmLoai_Hang.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmLoai_Hang.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmLoai_Hang.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmLoai_Hang.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmLoai_Hang.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmLoai_Hang.NewRow();

			frmDmLoai_Hang_Edit frmEdit = new frmDmLoai_Hang_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmLoai_Hang.Position >= 0)
						dtDmLoai_Hang.ImportRow(drCurrent);
					else
						dtDmLoai_Hang.Rows.Add(drCurrent);

					bdsDmLoai_Hang.Position = bdsDmLoai_Hang.Find("MA_LOAI_HANG", drCurrent["MA_LOAI_HANG"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmLoai_Hang.Current).Row);

				dtDmLoai_Hang.AcceptChanges();
			}
			else
				dtDmLoai_Hang.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmLoai_Hang.Position < 0)	
				return;

			DataRow drCurrent = ((DataRowView)bdsDmLoai_Hang.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81DMLOAIHANG", drCurrent))
			{
				bdsDmLoai_Hang.RemoveAt(bdsDmLoai_Hang.Position);
				dtDmLoai_Hang.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			//if (bdsDmLoai_Hang.Count <= 0)
			//    return;

			//if (!Common.CheckPermission("MERGE_DMKM", enuPermission_Type.Allow_Access))
			//{
			//    string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Catergory code!" : "Bạn không đc cấp quyền Gộp Mã khoản mục!";
			//    Common.MsgCancel(strMsg);
			//    return;
			//}

			//drCurrent = ((DataRowView)bdsDmLoai_Hang.Current).Row;
			//string strOldValue = (string)drCurrent["Ma_Km"];

			//frmMergeID frm = new frmMergeID();

			//frm.Load("R81DMKM", "Ma_Km", "Ten_Km", strOldValue, "DMKM");

			//if (frm.isAccept)
			//{
			//    string strNewValue = frm.strNewValue;
			//    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
			//    if (!Common.MsgYes_No(strMsg))
			//        return;

			//    if (DataTool.SQLMergeID("Ma_Km", "R81DMKM", strOldValue, strNewValue))
			//    {
			//        bdsDmLoai_Hang.RemoveCurrent();
			//        bdsDmLoai_Hang.Position = bdsDmLoai_Hang.Find("Ma_Km", strNewValue);
			//    }
			//}
		}

		#endregion

		#region EnterProcess

		private bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmLoai_Hang == null || bdsDmLoai_Hang.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmLoai_Hang.Current).Row;
			DataTable dtTemp = dtDmLoai_Hang.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmLoai_Hang.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmLoai_Hang.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmLoai_Hang_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMLOAIHANG", dtDmLoai_Hang);
		}

		#endregion 
	}
}