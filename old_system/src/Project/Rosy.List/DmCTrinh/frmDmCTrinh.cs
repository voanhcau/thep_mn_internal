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
	public partial class frmDmCTrinh : RosyList.frmView
	{		

		#region Khai bao bien
		DataTable dtDmCTrinh;
		DataRow drCurrent;
		BindingSource bdsDmCTrinh = new BindingSource();
		rsTreeList tlDmCTrinh = new rsTreeList();

		#endregion 				

		#region Contructor

        public frmDmCTrinh()
		{
			InitializeComponent();

			tlDmCTrinh.MouseDoubleClick += new MouseEventHandler(tlDmCTrinh_MouseDoubleClick);
			btImport.Click += new EventHandler(btImport_Click);
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
			tlDmCTrinh.KeyFieldName = "MA_CTRINH";
			tlDmCTrinh.ParentFieldName = "MA_CTRINH_PARENT";
			tlDmCTrinh.Dock = DockStyle.Fill;

			tlDmCTrinh.strZone = "DMCTRINH";
			tlDmCTrinh.BuildTreeList(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(tlDmCTrinh);
		}

		private void FillData()
		{
			dtDmCTrinh = DataTool.SQLGetDataTable("R81DMCTRINH", null, this.strLookupKeyFilter, null);
			bdsDmCTrinh.DataSource = dtDmCTrinh;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmCTrinh;
			ExportControl = tlDmCTrinh;

			tlDmCTrinh.DataSource = bdsDmCTrinh;
			bdsDmCTrinh.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();

			tlDmCTrinh.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmCTrinh.strZone + "'");
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmCTrinh.Rows.Count - 1; i++)
				if (((string)dtDmCTrinh.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmCTrinh.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmCTrinh.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmCTrinh.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmCTrinh.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmCTrinh.NewRow();

            frmDmCTrinh_Edit frmEdit = new frmDmCTrinh_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);			

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmCTrinh.Position >= 0)
						dtDmCTrinh.ImportRow(drCurrent);
					else
						dtDmCTrinh.Rows.Add(drCurrent);

					bdsDmCTrinh.Position = bdsDmCTrinh.Find("MA_CTRINH", drCurrent["MA_CTRINH"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmCTrinh.Current).Row);
				
				dtDmCTrinh.AcceptChanges();
			}
			//else
			//    dtDmCTrinh.RejectChanges();
		}
		
		public override void Delete()
		{
			if (bdsDmCTrinh.Position < 0)
				return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmCTrinh.Current).Row;
				
			if( !Common.MsgYes_No( Languages.GetLanguage("SURE_DELETE")))
				return;


            if (DataTool.SQLCheckExist("R81DMCTRINH", "Ma_CTrinh_Parent", drCurrent["Ma_CTrinh"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Công trình: {" + drCurrent["Ten_CTrinh"].ToString() + "}  đang có bộ phận con" :
					"Deparment: {" + drCurrent["Ten_CTrinh"].ToString() + "}  have child deparment";

				Common.MsgCancel(strMsg);
				return;
			}
			
			if (DataTool.SQLDelete("R81DMCTRINH", drCurrent))
			{
				bdsDmCTrinh.RemoveAt(bdsDmCTrinh.Position);
				dtDmCTrinh.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsDmCTrinh.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMCTRINH", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Department code!" : "Bạn không đc cấp quyền Gộp Mã bộ phận!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmCTrinh.Current).Row;
            string strOldValue = (string)drCurrent["Ma_CTrinh"];

			frmMergeID frm = new frmMergeID();

            frm.Load("R81DMCTRINH", "Ma_CTrinh", "Ten_CTrinh", strOldValue, "DMCTRINH");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge {" + strOldValue + "} to {" + strNewValue + "}?" : "Bạn có muốn gộp mã {" + strOldValue + "} sang {" + strNewValue + "} không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_CTrinh", "R81DMCTRINH", strOldValue, strNewValue))
				{
					bdsDmCTrinh.RemoveCurrent();
					bdsDmCTrinh.Position = bdsDmCTrinh.Find("Ma_CTrinh", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmCTrinh == null || bdsDmCTrinh.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmCTrinh.Current).Row;
			DataTable dtTemp = dtDmCTrinh.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsDmCTrinh.Position < 0)
				return;

            if (isLookup && EnterValid())
            {
                drLookup = ((DataRowView)bdsDmCTrinh.Current).Row;
                this.Close();
            }
            else
            {
                drCurrent = ((DataRowView)bdsDmCTrinh.Current).Row;

                frmDmPLCTrinh frm = new frmDmPLCTrinh();

                frm.MdiParent = this.MdiParent;
                frm.Load((string)drCurrent["Ma_CTrinh"]);
            }
		}

		#endregion 

		#region Su kien

		void tlDmCTrinh_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMCTRINH", dtDmCTrinh);
		}

		#endregion 
	}
}