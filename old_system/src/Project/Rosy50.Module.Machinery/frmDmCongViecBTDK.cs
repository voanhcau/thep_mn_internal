using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Element;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Public;
using RosyList;

namespace RosyModule.Machinery
{
	public partial class frmDmCongViecBTDK : RosyList.frmView
	{
		#region Khai bao bien

		private DataTable dtDmDt;
		private DataRow drCurrent;
		private BindingSource bdsDmDt = new BindingSource();
		private rsDataGridView dgvDmDt = new rsDataGridView();

		public string strMa_Tb = string.Empty;
		public bool bLookupByGroup = false;
		public bool bFind = false;

		#endregion 

		#region Contructor
        public frmDmCongViecBTDK()
		{
			InitializeComponent();

			this.dgvDmDt.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(dgvDmDt_CellMouseDoubleClick);
			this.btImport.Click +=new EventHandler(btImport_Click);
		}

		public override void Load()
		{
			this.Load("");
		}

		public void Load(string strMa_Tb)
		{
			this.strMa_Tb = strMa_Tb;

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
			if (!bLookupByGroup) //Truy cap theo nhom
			{
				string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

				if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
				{
					if (this.strLookupValue == "/" || this.strLookupValue == @"\")
						strWhere = strLookupKeyFilter;
					else
						strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
				}

                DataTable dtFind = DataTool.SQLGetDataTable("R06CONGVIECBTDK", null, strWhere, null);

                if (dtFind.Rows.Count > 0)
                {
                    strLookupKeyFilter = strWhere;
                    bFind = true;
                    this.Load();
                }
                else
                {
                  
                    this.Load();
                    //this.LoadLookupByGroup();
                }
			}
			else
				this.Load(this.strMa_Tb);
		}

        //private void LoadLookupByGroup()
        //{//Lookup danh muc doi tuong theo nhom

        //    frmDmNhTb frm = new frmDmNhTb();
        //    frm.bLookupByGroup = true;
        //    frm.isLookup = true;
        //    frm.strLookupKeyFilter = this.strLookupKeyFilter;
        //    frm.strLookupKeyValid = this.strLookupKeyValid;
        //    frm.bLookupRequire = this.bLookupRequire;

        //    //frm.strLookupKeyValid += (frm.strLookupKeyValid != "" ? "" : " AND ") + " (Nh_Cuoi = 1)";

        //    frm.LoadLookup();

        //    this.bIsEnter = frm.bIsEnter;
        //    this.drLookup = frm.drLookup;
        //    this.Close();
        //}

		#endregion

		#region Build, FillData
		private void Build()
		{
			dgvDmDt.Dock = DockStyle.Fill;

			this.splitcContent.Panel1.Controls.Add(dgvDmDt);

            dgvDmDt.strZone = "CONGVIECBT";
			dgvDmDt.BuildGridView(this.isLookup);

			ExportControl = dgvDmDt;
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
						strKey = "(Ma_Tb = '" + strMa_Tb + "')";
					else
						strKey = "(" + strKey + ") AND (Ma_Tb = '" + strMa_Tb + "')";
				}
			}
			else
				strKey = (strMa_Tb == string.Empty ? string.Empty : "T1.Ma_Tb = '" + strMa_Tb + "'");


            string strsql = "SELECT T1.*, Ten_Tb, T3.Type_Name AS Ten_Phan_Loai_Cv FROM R06CONGVIECBTDK T1 JOIN (SELECT Ma_Tb AS Ma_Tb1, Ten_Tb FROM R06DMTB) T2 ON T1.Ma_Tb = T2.Ma_Tb1" +
                                " LEFT JOIN (SELECT * FROM R81DMTYPE WITH (NOLOCK) WHERE TYPE = 'LOAI_CV_BTTB') T3 ON T1.Phan_Loai_Cv = T3.Type_ID" +
                                " WHERE " + strKey;
            dtDmDt = SQLExec.ExecuteReturnDt(strsql);
            //dtDmDt = DataTool.SQLGetDataTable("R06CONGVIECBTDK", null, strKey, "Ma_Tb");

			bdsDmDt.DataSource = dtDmDt;
			dgvDmDt.DataSource = bdsDmDt;

			if (bdsDmDt.Count >= 0)
				bdsDmDt.Position = 0;//Vi tri mac dinh

			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsDmDt;

			if (this.isLookup)
				this.MoveToLookupValue();
		}

		private void MoveToLookupValue()
		{
			if (this.strLookupColumn == String.Empty || this.strLookupValue == string.Empty)
				return;

			for (int i = 0; i <= dtDmDt.Rows.Count - 1; i++)
				if (((string)dtDmDt.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
				{
					bdsDmDt.Position = i;
					break;
				}
		}
		#endregion 

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmDt.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai
			if (bdsDmDt.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmDt.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtDmDt.NewRow();
				drCurrent["Ma_Tb"] = strMa_Tb;
			}


                frmCongViecBTDK_Edit frmEdit = new frmCongViecBTDK_Edit();
				frmEdit.Load(enuNew_Edit, drCurrent);

				// người dùng chọn chấp nhận
				if (frmEdit.isAccept)
				{
                    DataRow drDmTb = DataTool.SQLGetDataRowByID("R06DMTB", "Ma_Tb", frmEdit.txtMa_Tb.Text);
                    drCurrent["Ten_Tb"] = drDmTb["Ten_Tb"];

					if (enuNew_Edit == enuEdit.New)
					{
						if (bdsDmDt.Position >= 0)
							dtDmDt.ImportRow(drCurrent);
						else
							dtDmDt.Rows.Add(drCurrent);
                       
                       

                        bdsDmDt.Position = bdsDmDt.Find("Ident00", drCurrent["Ident00"]);
					}
					else
					{
						Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmDt.Current).Row);
					}

					//dtDmDt.AcceptChanges();
					drCurrent.AcceptChanges();
				}
				else
					//dtDmDt.RejectChanges();
					drCurrent.RejectChanges();
			
			
		}
		
		public override void Delete()
		{
			if (!Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
			{
				Common.MsgCancel(Languages.GetLanguage("No_Permission") + ' ' + Languages.GetLanguage("Delete"));
				return;
			}

			if (bdsDmDt.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmDt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R06CONGVIECBTDK", drCurrent))
			{
				bdsDmDt.RemoveAt(bdsDmDt.Position);
				dtDmDt.AcceptChanges();
			}
		}

		public override void MergeID()
		{
			if(bdsDmDt.Count <= 0)
				return;

            //if (!Common.CheckPermission("MERGE_DMDT", enuPermission_Type.Allow_Access))
            //{
            //    string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Customer code!" : "Bạn không đc cấp quyền Gộp Mã đối tượng!";
            //    Common.MsgCancel(strMsg);
            //    return;
            //}

            //drCurrent = ((DataRowView)bdsDmDt.Current).Row;
            //string strOldValue = (string)drCurrent["Ma_Tb"];

            //frmMergeID frm = new frmMergeID();

            //frm.Load("R06DMTB", "Ma_Tb", "Ten_Tb", strOldValue, "DMTB");			

            //if (frm.isAccept)
            //{
            //    string strNewValue = frm.strNewValue;
            //    string strMsg = Element.sysLanguage == enuLanguageType.English ? "Are you sure to merge " + strOldValue + " to " + strNewValue + " ?" : "Bạn có muốn gộp mã " + strOldValue + " sang " + strNewValue + " không ?";
            //    if (!Common.MsgYes_No(strMsg))
            //        return;

            //    if (DataTool.SQLMergeID("Ma_Tb", "R06DMTB", strOldValue, strNewValue))
            //    {
            //        bdsDmDt.RemoveCurrent();
            //        bdsDmDt.Position = bdsDmDt.Find("MA_TB", strNewValue);
            //    }
            //}
		}

		#endregion

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmDt == null || bdsDmDt.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmDt.Current).Row;
			DataTable dtTemp = dtDmDt.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void  EnterProcess()
		{
			if (bdsDmDt.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmDt.Current).Row;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmDt.Current).Row;
				this.Close();
			}
			
		}

		#endregion 

		#region Su kien

		void dgvDmDt_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (this.isLookup)
				this.EnterProcess();
			else
				this.Edit(enuEdit.Edit);
		}

		void btImport_Click(object sender, EventArgs e)
		{
			Public.ImportExcel("DMTB", dtDmDt);
		}

		protected override void OnClosed(EventArgs e)
		{
            //if (bFind && !this.bIsEnter)
            //    LoadLookupByGroup();

			base.OnClosed(e);
		}
		
		#endregion 
	}
}