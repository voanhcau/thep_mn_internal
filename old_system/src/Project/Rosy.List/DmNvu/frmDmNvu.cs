using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Element;

namespace RosyList
{
	public partial class frmDmNvu : RosyList.frmView
	{
		rsTreeList tlDmNvu = new rsTreeList();

		DataTable dtDmNvu;
		BindingSource bdsDmNvu = new BindingSource();

		DataRow drCurrent;

		public frmDmNvu()
		{
			InitializeComponent();

			cboKieu_Nhom.SelectedIndexChanged += new EventHandler(cboKieu_Nhom_SelectedIndexChanged);
			btImport.Click +=new EventHandler(btImport_Click);
		}

		public new void Load()
		{
			this.Build();
			this.FillData();
			this.BindingLanguage();

			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

		public override void LoadLookup()
		{
			this.Load();
		}

		void Build()
		{
			tlDmNvu.strZone = "DMNVU";
			tlDmNvu.KeyFieldName = "FIELDID";
			tlDmNvu.ParentFieldName = "PARENTFIELD";
			tlDmNvu.Dock = DockStyle.Fill;
			tlDmNvu.BuildTreeList();

			this.splitcContent.Panel1.Controls.Add(tlDmNvu);
		}

		void FillData()
		{
			Hashtable htPara = new Hashtable();
			htPara.Add("KIEU_NHOM", cboKieu_Nhom.SelectedIndex);
			htPara.Add("KEY", this.strLookupKeyFilter);
			htPara.Add("MA_DATA", RosySystem.Element.Element.sysMa_Data);

			dtDmNvu = SQLExec.ExecuteReturnDt("sp_ListGetDmNvu", htPara, CommandType.StoredProcedure);

			bdsDmNvu.DataSource = dtDmNvu;
			tlDmNvu.DataSource = bdsDmNvu;

			tlDmNvu.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmNvu.strZone + "'");

			this.ExportControl = tlDmNvu;
			this.bdsSearch = bdsDmNvu;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmNvu.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmNvu.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmNvu.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmNvu.NewRow();

			frmDmNvu_Edit frmEdit = new frmDmNvu_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmNvu.Position >= 0)
						dtDmNvu.ImportRow(drCurrent);
					else
						dtDmNvu.Rows.Add(drCurrent);

					bdsDmNvu.Position = bdsDmNvu.Find("MA_NVU", drCurrent["MA_NVU"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmNvu.Current).Row);

				dtDmNvu.AcceptChanges();
			}
		}

		public override void Delete()
		{
			if (bdsDmNvu.Position < 0)
				return;
			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmNvu.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81DmNvu", drCurrent))
			{
				bdsDmNvu.RemoveAt(bdsDmNvu.Position);
				dtDmNvu.AcceptChanges();
			}	
		}

		public override void MergeID()
		{
			if (bdsDmNvu.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMNVU", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Transaction code!" : "Bạn không đc cấp quyền Gộp Mã nghiệp vụ!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmNvu.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Nvu"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DMNVU", "Ma_Nvu", "Ten_Nvu", strOldValue, "DMNVU");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Nvu", "R81DMNVU", strOldValue, strNewValue))
				{
					bdsDmNvu.RemoveCurrent();
					bdsDmNvu.Position = bdsDmNvu.Find("Ma_Nvu", strNewValue);
				}
			}
		}

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmNvu == null || bdsDmNvu.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmNvu.Current).Row;
			DataTable dtTemp = dtDmNvu.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsDmNvu.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmNvu.Current).Row;
				this.Close();
			}
		}

		#endregion 

		void cboKieu_Nhom_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.FillData();
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMNVU", dtDmNvu);
		}

	}
}
