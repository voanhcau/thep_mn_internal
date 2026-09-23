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
using RosySystem.Public;

namespace RosyList
{
	public partial class frmDmVt : RosyList.frmView
	{
		#region Khai bao bien

		private DataTable dtDmVt;
		private DataRow drCurrent;
		private BindingSource bdsDmVt = new BindingSource();
		private rsDataGridView dgvDmVt = new rsDataGridView();

		public string strMa_Nh_Vt = string.Empty;
		public bool bLookupByGroup = false;
		public bool bFind = false;

		#endregion 

		#region Contructor
		public frmDmVt()
		{
			InitializeComponent();

			this.dgvDmVt.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvDmVt_CellMouseClick);
			this.dgvDmVt.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmVt_CellMouseDoubleClick);
			this.btImport.Click +=new EventHandler(btImport_Click);
			this.btReplace.Click += new EventHandler(btReplace_Click);
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

		public void Load(string strMa_Nh_Vt)
		{
			this.strMa_Nh_Vt = strMa_Nh_Vt;

			this.Load();
		}

		public override void LoadLookup()
		{
			if (!bLookupByGroup && ((string)Parameters.GetParaValue("ACCESS_DMVT")).Trim() == "1")
			{
				string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

				if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
				{
					if (this.strLookupValue == "/" || this.strLookupValue == @"\")
						strWhere = strLookupKeyFilter;
					else
						strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
				}

				DataTable dtFind = DataTool.SQLGetDataTable("R81DMVT", null, strWhere, null);

				if (dtFind.Rows.Count > 0)
				{
					strLookupKeyFilter = strWhere;
					bFind = true;
					this.Load();
				}
				else
					this.LoadLookupByGroup();
			}
			else
				this.Load(this.strMa_Nh_Vt);
		}

		private void LoadLookupByGroup()
		{//Lookup theo nhom

			frmDmNhVt frm = new frmDmNhVt();
			frm.bLookupByGroup = true;
			frm.isLookup = true;
			frm.strLookupKeyFilter = this.strLookupKeyFilter;
			frm.strLookupKeyValid = this.strLookupKeyValid;
			frm.bLookupRequire = this.bLookupRequire;

			frm.LoadLookup();

			this.bIsEnter = frm.bIsEnter;
			this.drLookup = frm.drLookup;
			this.Close();
		}

		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDmVt.Dock = DockStyle.Fill;
			dgvDmVt.strZone = "DMVT";
			dgvDmVt.BuildGridView(this.isLookup);


			//dgvDmVt.Columns["CHON"].ReadOnly = false;

			this.splitcContent.Panel1.Controls.Add(dgvDmVt);

		}

		private void FillData()	
		{
			string strKey = string.Empty;
			if (this.isLookup)
			{
				strKey = (this.strLookupKeyFilter == null ? string.Empty : this.strLookupKeyFilter);

				if (bLookupByGroup)
				{
					if (strKey == string.Empty)
						strKey = "(Ma_Nh_Vt = '" + strMa_Nh_Vt + "')";
					else
						strKey = "(" + strKey + ") AND (Ma_Nh_Vt = '" + strMa_Nh_Vt + "')";
				}
			}
			else
				strKey = (strMa_Nh_Vt == string.Empty ? string.Empty : "Ma_Nh_Vt = '" + strMa_Nh_Vt + "'");

            dtDmVt = DataTool.SQLGetDataTable("R81DmVt", null, strKey, "Ma_Vt");
            //string strSql = "Select *, CASE WHEN IS_Hide = 1 THEN N'Đã kết thúc' ELSE '' END AS Tinh_Trang FROM R81DMVT WHERE " + strKey + " ORDER BY Ma_Vt";
            //dtDmVt = SQLExec.ExecuteReturnDt(strSql);
			

			bdsDmVt.DataSource = dtDmVt;
			dgvDmVt.DataSource = bdsDmVt;
			bdsDmVt.Position = 0;


            bdsDmVt.Filter = "Ma_Nh_Vt NOT LIKE 'TS%' AND Ma_Nh_Vt NOT LIKE 'CC%' AND Ma_Nh_Vt NOT LIKE 'PHOI'";

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmVt;
			ExportControl = dgvDmVt;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmVt.Rows.Count - 1; i++)
				if (((string)dtDmVt.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmVt.Position = i;
					break;
				}
		}
		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmVt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsDmVt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmVt.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmVt.NewRow();
				drCurrent["Ma_Nh_Vt"] = strMa_Nh_Vt;
			}

			frmDmVt_Edit frmEdit = new frmDmVt_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);
			
			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmVt.Position >= 0)
						dtDmVt.ImportRow(drCurrent);
					else
						dtDmVt.Rows.Add(drCurrent);

					bdsDmVt.Position = bdsDmVt.Find("MA_VT", drCurrent["MA_VT"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmVt.Current).Row);

				dtDmVt.AcceptChanges();
			}
			else
				dtDmVt.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmVt.Position < 0)
				return;

			//Kiem tra Permission
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}
			DataRow drCurrent = ((DataRowView)bdsDmVt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLCheckExist("R04CSGIA", "Ma_Vt", drCurrent["Ma_Vt"]))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.Vietnamese ?
                    "Vật tư : {" + drCurrent["Ten_Vt"].ToString() + "}  đang sử dụng ở chính sách giá" :
                    "Item : {" + drCurrent["Ten_Vt"].ToString() + "}  is using in item cost table";

                Common.MsgOk(strMsg);
                return;
            }


			if (DataTool.SQLDelete("R81DmVt", drCurrent))
			{
				bdsDmVt.RemoveAt(bdsDmVt.Position);
				dtDmVt.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if (bdsDmVt.Count <= 0)
				return;

			if (!Common.CheckPermission("MERGE_DMVT", enuPermission_Type.Allow_Access))
			{
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Item code!" : "Bạn không đc cấp quyền Gộp Mã vật tư, hàng hóa!";
				Common.MsgCancel(strMsg);
				return;
			}

			drCurrent = ((DataRowView)bdsDmVt.Current).Row;
			string strOldValue = (string)drCurrent["Ma_Vt"];

			frmMergeID frm = new frmMergeID();

			frm.Load("R81DMVT", "Ma_Vt", "Ten_Vt", strOldValue, "DMVT");

			if (frm.isAccept)
			{
				string strNewValue = frm.strNewValue;
                //kiểm tra trước khi gop ma
                int iSo_Ps = (int)SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM vw_TheKho WHERE Ma_Vt = '"+ strOldValue +"'");
                
                if (iSo_Ps == 0)
                    iSo_Ps = (int)SQLExec.ExecuteReturnValue("SELECT COUNT(*) FROM R04CTPO WHERE Ma_Ct = 'DT' AND Ma_Vt = '" + strOldValue + "'");
               
                if (iSo_Ps != 0)
                {
                    if (Common.MsgOk("Mã vật tư " + strOldValue + " đã phát sinh thẻ kho không cho phép gộp mã"))
                        return;
                }
				string strMsg = Element.sysLanguage == enuLanguageType.English ? "Do you want to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
				if (!Common.MsgYes_No(strMsg))
					return;

				if (DataTool.SQLMergeID("Ma_Vt", "R81DMVT", strOldValue, strNewValue))
				{
					bdsDmVt.RemoveCurrent();
					bdsDmVt.Position = bdsDmVt.Find("Ma_Vt", strNewValue);
				}
			}
		}

		#endregion 

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmVt == null || bdsDmVt.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmVt.Current).Row;
			DataTable dtTemp = dtDmVt.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;

		}

		public override void  EnterProcess()
		{
			if (bdsDmVt.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmVt.Current).Row;
				this.Close();
			}
		}

		#endregion 

		#region Su kien

		void dgvDmVt_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.RowIndex < 0)
				return;

			string strColumnName = dgvDmVt.Columns[e.ColumnIndex].Name;
			drCurrent = ((DataRowView)bdsDmVt.Current).Row;

			//if (strColumnName == "CHON")
			//{
			//    drCurrent["CHON"] = !(bool)drCurrent["CHON"];
			//}
		}

		void dgvDmVt_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		protected override void OnClosed(EventArgs e)
		{
			if (bFind && !this.bIsEnter)
				LoadLookupByGroup();

			base.OnClosed(e);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			RosySystem.Public.Public.ImportExcel("DMVT", dtDmVt);
		}


		void btReplace_Click(object sender, EventArgs e)
		{
			//if (dtDmVt.Select("Chon = true").Length == 0)
			//    return;

			
			//frmReplace frm = new frmReplace();
			//frm.Load();


			//if (frm.isAccept == true)
			//{
			//    foreach (DataRow drSelect in dtDmVt.Select("Chon = true"))
			//    {
			//        string strMa_Nh_Vt_New = frm.txtMa_Nh_Vt.Text;
			//        string strMa_Vt = (string)drSelect["Ma_Vt"];

			//        string strSqlExec = "UPDATE R81DMVT SET Ma_Nh_Vt = '" + strMa_Nh_Vt_New +  "'  WHERE Ma_Vt = '" + strMa_Vt + "'";
			//        SQLExec.Execute(strSqlExec);
			//    }
			//    FillData();
			//}
		}
		#endregion 
	}
	
}