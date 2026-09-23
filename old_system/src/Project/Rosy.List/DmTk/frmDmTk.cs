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
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmTk : RosyList.frmView
	{

		#region Khai bao bien
		private DataTable dtDmTk;
		private DataRow drCurrent;
		private BindingSource bdsDmTk = new BindingSource();
		private rsTreeList tlDmTk = new rsTreeList();

		#endregion

		#region Contructor

		public frmDmTk()
		{
			InitializeComponent();

			tlDmTk.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(tlDmTk_NodeCellStyle);
			tlDmTk.MouseDoubleClick += new MouseEventHandler(tlDmTk_MouseDoubleClick);
			btImport.Click +=new EventHandler(btImport_Click);
		}

		public override void Load()
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

		#endregion

		#region Build, FillData
		private void Build()
		{
			tlDmTk.KeyFieldName = "TK";
			tlDmTk.ParentFieldName = "TK_PARENT";
			tlDmTk.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(tlDmTk);

			tlDmTk.strZone = "DMTK";
			tlDmTk.BuildTreeList(this.isLookup);
		}

		private void FillData()
		{
			dtDmTk = DataTool.SQLGetDataTable("R81DMTK", null, this.strLookupKeyFilter, null);

			bdsDmTk.DataSource = dtDmTk;
			tlDmTk.DataSource = bdsDmTk;
			bdsDmTk.Position = 0;

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmTk;
			ExportControl = tlDmTk;

			if (this.isLookup)
				this.MoveToLookupValue();

			tlDmTk.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmTk.strZone + "'");
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmTk.Rows.Count - 1; i++)
				if (((string)dtDmTk.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmTk.Position = i;
					break;
				}
		}
		#endregion

		#region Update

		//Cap nhậ tài khoản cuối Tk_Cuoi khi Edit tài khoản

		void UpdateTk_Cuoi(DataTable dtListUpdateTk_Cuoi)
		{
			foreach (DataRow dr in dtListUpdateTk_Cuoi.Rows)
				UpdateTk_Cuoi(((string)dr["Tk"]).Trim());
		}

		void UpdateTk_Cuoi(string strTk)
		{
			int iIndexTk = bdsDmTk.Find("Tk", strTk);
			int cTk_Cuoi = DataTool.SQLCheckExist("R81DMTK", "Tk_Parent", strTk) ? 0 : 1;

			SQLExec.Execute("UPDATE R81DMTK SET Tk_Cuoi = " + cTk_Cuoi + " WHERE Tk = '" + strTk + "'");
			dtDmTk.Rows[iIndexTk]["Tk_Cuoi"] = cTk_Cuoi;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{

			if (bdsDmTk.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmTk.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmTk.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmTk.NewRow();

			#region Code update Tk cuoi
			DataTable dtListUpdateTk_Cuoi = new DataTable();

			string strTk = ((string)drCurrent["Tk"]).Trim();

			//Lấy những Tk mẹ và tk con cua Tk [strTk] truoc khi lưu
			string strWhere = "(( '" + strTk + "' LIKE Tk +'%' OR Tk LIKE '" + strTk + "%') AND Tk <> '" + strTk + "' )";

			if (enuNew_Edit == enuEdit.Edit)//Khi thêm Tk mới thì Tk đó chưa có Tk mẹ
				dtListUpdateTk_Cuoi = DataTool.SQLGetDataTable("R81DMTK", "Tk", strWhere, null);
			#endregion

			frmDmTk_Edit frmEdit = new frmDmTk_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmTk.Position >= 0)
						dtDmTk.ImportRow(drCurrent);
					else
						dtDmTk.Rows.Add(drCurrent);

					bdsDmTk.Position = bdsDmTk.Find("TK", drCurrent["TK"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmTk.Current).Row);

				dtDmTk.AcceptChanges();

				#region Code update Tk cuoi
				//Lấy những Tk mẹ và tk con và nó(strTk) sau khi lưu					
				strTk = ((string)drCurrent["Tk"]).Trim();
				strWhere = "( '" + strTk + "' LIKE Tk +'%' OR Tk LIKE '" + strTk + "%' )";

				dtListUpdateTk_Cuoi.Merge(DataTool.SQLGetDataTable("R81DMTK", "Tk", strWhere, null));

				//Cap nhat lai Tk_Cuoi					
				UpdateTk_Cuoi(dtListUpdateTk_Cuoi);
				dtDmTk.AcceptChanges();
				#endregion
			}
			//else
			//    dtDmTk.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmTk.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmTk.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLCheckExist("R81DMTK", "Tk_Parent", drCurrent["Tk"]))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
								"Tài khoản: {" + drCurrent["Ten_Tk"].ToString() + "}  đang có tài khoản con" :
								"Account: {" + drCurrent["Ten_Tk"].ToString() + "}  have child account";

				Common.MsgOk(strMsg);

				return;
			}

			//Lấy những Tk mẹ cua Tk [strTk] truoc khi xoa
			DataTable dtListUpdateTk_Cuoi;
			string strTk = ((string)drCurrent["Tk"]).Trim();
			string strWhere = "( '" + strTk + "' LIKE Tk +'%' AND Tk <> '" +  strTk + "' )";
			dtListUpdateTk_Cuoi = DataTool.SQLGetDataTable("R81DMTK", "Tk", strWhere, null);

			if (DataTool.SQLDelete("R81DMTK", drCurrent))
			{
				bdsDmTk.RemoveAt(bdsDmTk.Position);				
				//cap nhat Tk_Cuoi
				dtDmTk.AcceptChanges();
				UpdateTk_Cuoi(dtListUpdateTk_Cuoi);
				dtDmTk.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsDmTk.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMTK", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Account code!" : "Bạn không đc cấp quyền Gộp Tài khoản!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmTk.Current).Row;
			string strOldValue = (string)drCurrent["Tk"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DMTK", "Tk", "Ten_Tk", strOldValue, "DMTK");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Tk", "R81DMTK", strOldValue, strNewValue))
				{
					bdsDmTk.RemoveCurrent();
					bdsDmTk.Position = bdsDmTk.Find("Tk", strNewValue);
				}
			}
		}

		#endregion

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmTk == null || bdsDmTk.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmTk.Current).Row;
			DataTable dtTemp = dtDmTk.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmTk.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmTk.Current).Row;
				this.Close();
			}
		}

		#endregion

		#region Su kien

		void tlDmTk_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
		{
			//string strKey = tlDmTk.strZone + ".TK_NT";

			//if (e.Node != null && tlDmTk.ColumnInfos.ContainsKey(strKey))
			//{
			//    if ((bool)tlDmTk.Nodes[e.Node.Id]["Tk_Nt"])
			//        e.Appearance.ForeColor = Color.FromArgb(255, 49, 106, 197);
			//    else
			//        e.Appearance.ForeColor = tlDmTk.ForeColor;
			//}
		}

		void tlDmTk_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMTK", dtDmTk);
		}

		#endregion
	}
}