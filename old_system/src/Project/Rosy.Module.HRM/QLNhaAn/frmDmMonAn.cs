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

namespace RosyModule.HRM
{
    public partial class frmDmMonAn : RosyList.frmView
	{		

		#region Khai bao bien
		DataTable dtDmBp;
		DataRow drCurrent;
		BindingSource bdsDmBp = new BindingSource();
		rsTreeList tlDmBp = new rsTreeList();

		#endregion 				

		#region Contructor
		
		public frmDmMonAn()
		{
			InitializeComponent();

			tlDmBp.MouseDoubleClick += new MouseEventHandler(tlDmBp_MouseDoubleClick);
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
			tlDmBp.KeyFieldName = "MA_MAN";
			tlDmBp.ParentFieldName = "MA_MAN_PARENT";
			tlDmBp.Dock = DockStyle.Fill;

			tlDmBp.strZone = "DMMAN";
			tlDmBp.BuildTreeList(this.isLookup);

			this.splitcContent.Panel1.Controls.Add(tlDmBp);
		}

		private void FillData()
		{
            if (!isLookup)
                dtDmBp = DataTool.SQLGetDataTable("R81DMMONAN", null, this.strLookupKeyFilter, null);
            else
            {
                strLookupKeyFilter += " Nh_Cuoi = 1";
                dtDmBp = DataTool.SQLGetDataTable("R81DMMONAN", null, this.strLookupKeyFilter, null);
            }
			bdsDmBp.DataSource = dtDmBp;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmBp;
			ExportControl = tlDmBp;

			tlDmBp.DataSource = bdsDmBp;
			bdsDmBp.Position = 0;

			if (this.isLookup)
				this.MoveToLookupValue();

			tlDmBp.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmBp.strZone + "'");
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmBp.Rows.Count - 1; i++)
				if (((string)dtDmBp.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmBp.Position = i;
					break;
				}
		}

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmBp.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmBp.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmBp.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmBp.NewRow();

            frmDmMonAn_Edit frmEdit = new frmDmMonAn_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);			

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmBp.Position >= 0)
						dtDmBp.ImportRow(drCurrent);
					else
						dtDmBp.Rows.Add(drCurrent);

					bdsDmBp.Position = bdsDmBp.Find("MA_MAN", drCurrent["MA_MAN"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmBp.Current).Row);
				
				dtDmBp.AcceptChanges();
			}
			//else
			//    dtDmBp.RejectChanges();
		}
		
		public override void Delete()
		{
			if (bdsDmBp.Position < 0)
				return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmBp.Current).Row;
				
			if( !Common.MsgYes_No( Languages.GetLanguage("SURE_DELETE")))
				return;


            if (DataTool.SQLCheckExist("R81DMMONAN", "Ma_Man_Parent", drCurrent["Ma_Man"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
					"Món ăn: {" + drCurrent["Ten_Bp"].ToString() + "}  đang có món ăn con" :
					"Deparment: {" + drCurrent["Ten_Bp"].ToString() + "}  have child deparment";

				Common.MsgCancel(strMsg);
				return;
			}

            if (DataTool.SQLDelete("R81DMMONAN", drCurrent))
			{
				bdsDmBp.RemoveAt(bdsDmBp.Position);
				dtDmBp.AcceptChanges();
			}
		}

        //public override void MergeID()
        //{
        //    if (bdsDmBp.Count <= 0)
        //        return;

        //    if (!Common.CheckPermission("MERGE_DMBP", enuPermission_Type.Allow_Access))
        //    {
        //        string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Department code!" : "Bạn không đc cấp quyền Gộp Mã bộ phận!";
        //        Common.MsgCancel(strMsg);
        //        return;
        //    }

        //    drCurrent = ((DataRowView)bdsDmBp.Current).Row;
        //    string strOldValue = (string)drCurrent["Ma_MAn"];

        //    frmMergeID frm = new frmMergeID();

        //    frm.Load("R81DMMONAN", "Ma_MAn", "Ten_MAn", strOldValue, "DMMAN");

        //    if (frm.isAccept)
        //    {
        //        string strNewValue = frm.strNewValue;
        //        string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge {" + strOldValue + "} to {" + strNewValue + "}?" : "Bạn có muốn gộp mã {" + strOldValue + "} sang {" + strNewValue + "} không ?";
        //        if (!Common.MsgYes_No(strMsg))
        //            return;

        //        if (DataTool.SQLMergeID("Ma_MAn", "R81DMMONAN", strOldValue, strNewValue))
        //        {
        //            bdsDmBp.RemoveCurrent();
        //            bdsDmBp.Position = bdsDmBp.Find("Ma_MAn", strNewValue);
        //        }
        //    }
        //}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmBp == null || bdsDmBp.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmBp.Current).Row;
			DataTable dtTemp = dtDmBp.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsDmBp.Position < 0)
				return;

            if (isLookup && EnterValid())
            {
                drLookup = ((DataRowView)bdsDmBp.Current).Row;
                this.Close();
            }
            else
            {
                drCurrent = ((DataRowView)bdsDmBp.Current).Row;
                frmDinhMucMonAn frm = new frmDinhMucMonAn();
                frm.Load(drCurrent["Ma_MAn"].ToString());
            }
		}

		#endregion 

		#region Su kien

		void tlDmBp_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMMONAN", dtDmBp);
		}

		#endregion 
	}
}