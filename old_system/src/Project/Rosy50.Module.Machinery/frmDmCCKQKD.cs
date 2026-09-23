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
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Library;
using RosySystem.Element;
using RosyList;
using System.Collections;
using System.IO;

namespace RosyModule.Machinery
{
	public partial class frmDmCCKQKD : RosySystem.Customize.frmView
	{
		#region Khai bao bien
        string strLoai = string.Empty;
       
        rsTreeList tlDmCCKQKD = new rsTreeList();
        
        DataSet dsObject = new DataSet();

		private DataRow drCurrent;

        DataTable dtDmNhCCKQKD;
        DataTable dtDmCCKQKD;

        DataRow drDmNhCCKQKD;
        DataRow drDmCCKQKD;

        BindingSource bdsDmNhCCKQKD = new BindingSource();
        BindingSource bdsDmCCKQKD = new BindingSource();
      

		#endregion

		#region Contructor

        public frmDmCCKQKD()
		{
			InitializeComponent();

            bdsDmNhCCKQKD.PositionChanged += new EventHandler(bdsObject_PositionChanged);

            tlDmCCKQKD.KeyDown += new KeyEventHandler(tlDmCCKQKD_KeyDown);
            dgvDmCCKQKD.KeyDown += new KeyEventHandler(dgvDmCCKQKD_KeyDown);

            dgvDmCCKQKD.CellMouseClick += new DataGridViewCellMouseEventHandler(dgvDmCCKQKD_CellMouseClick);
            this.btDetailNew.Click += new EventHandler(btDetailNew_Click);
            this.btDetailEdit.Click += new EventHandler(btDetailEdit_Click);
            this.btDetailDelete.Click += new EventHandler(btDetailDelete_Click);
		}

       

        

		public override void Load()
		{
			this.Build();
			this.FillData(string.Empty);
			this.BindingData();
			this.BindingLanguage();

			this.Show();

            tlDmCCKQKD.Focus();
		}
        public void Load(string strLoai)
        {
            this.strLoai = strLoai;
            this.Build();
            this.FillData(string.Empty);
            this.BindingData();
            this.BindingLanguage();

            this.ShowDialog();

            //tlDmCbNv.Focus();
        }
		#endregion

		#region Build, FillData

		private void Build()
		{

            tlDmCCKQKD.KeyFieldName = "MA_NH_CC";
            tlDmCCKQKD.ParentFieldName = "MA_NH_CC_PARENT";
            tlDmCCKQKD.Dock = DockStyle.Fill;
            tlDmCCKQKD.strZone = "DMNHCCKQKD";
            tlDmCCKQKD.BuildTreeList(this.isLookup);
            this.tabDmNhCCKQKD.Controls.Add(tlDmCCKQKD);

            dgvDmCCKQKD.strZone = "DMCCKQKD";
            dgvDmCCKQKD.BuildGridView();
           
		}

		private void FillData(string strKey)
		{
            Hashtable ht = new Hashtable();
            dsObject = SQLExec.ExecuteReturnDs("sp_GetDmCCKQKD", ht, CommandType.StoredProcedure);


            dtDmNhCCKQKD = dsObject.Tables[0];
            bdsDmNhCCKQKD.DataSource = dtDmNhCCKQKD;
            tlDmCCKQKD.DataSource = bdsDmNhCCKQKD;

            dtDmCCKQKD = dsObject.Tables[1];
            bdsDmCCKQKD.DataSource = dtDmCCKQKD;
            dgvDmCCKQKD.DataSource = bdsDmCCKQKD;

            tlDmCCKQKD.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmCCKQKD.strZone + "'");
		}

		private void BindingData()
		{
			
		}

		#endregion

		#region Update
        
      
        void btDetailNew_Click(object sender, EventArgs e)
        {
            DmCC_Edit(enuEdit.New);
        }
        void btDetailEdit_Click(object sender, EventArgs e)
        {
            DmCC_Edit(enuEdit.Edit);
        }
        void btDetailDelete_Click(object sender, EventArgs e)
        {
            DmCC_Delete();
        }
		#endregion

		#region EnterProcess

		

		#endregion

		#region Su kien

		void bdsObject_PositionChanged(object sender, EventArgs e)
		{
            drCurrent = ((DataRowView)bdsDmNhCCKQKD.Current).Row;

            bdsDmCCKQKD.Filter = "Ma_Nh_CC = '" + drCurrent["Ma_Nh_CC"] + "'";
						
		}
        void DmNhCC_Edit(enuEdit enuNew_Edit)
        {
            if (bdsDmNhCCKQKD.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy dòng hiện tại
            if (bdsDmNhCCKQKD.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDmNhCCKQKD.Current).Row, ref drDmNhCCKQKD);
            else
                drDmNhCCKQKD = dtDmNhCCKQKD.NewRow();

            //if (enuNew_Edit == enuEdit.New)
            //    drDmNhVtTb["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];

            frmDmNhCCKQKD_Edit frmEdit1 = new frmDmNhCCKQKD_Edit();
            frmEdit1.Load(enuNew_Edit, drDmNhCCKQKD);

            //Khi người dùng chọn chấp nhận
            if (frmEdit1.isAccept)
            {
                //drDmCtVtTb["Ma_Nh_Tb"] = drDmCtVtTb["Ma_Nh_Tb"].ToString()+ drDmCtVtTb["Loai_Tb"].ToString();
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDmNhCCKQKD.Position >= 0)
                        dtDmNhCCKQKD.ImportRow(drDmNhCCKQKD);
                    else
                        dtDmNhCCKQKD.Rows.Add(drDmNhCCKQKD);

                    bdsDmNhCCKQKD.Position = bdsDmNhCCKQKD.Find("Ma_Nh_CC", drDmNhCCKQKD["Ma_Nh_CC"]);
                }
                else
                    Common.CopyDataRow(drDmNhCCKQKD, ((DataRowView)bdsDmNhCCKQKD.Current).Row);



                dtDmNhCCKQKD.AcceptChanges();
            }
            else
                dtDmNhCCKQKD.RejectChanges();
        }
        void DmNhCC_Delete()
        {
            if (bdsDmNhCCKQKD.Position < 0)
                return;

            if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                drDmNhCCKQKD = ((DataRowView)bdsDmNhCCKQKD.Current).Row;

                if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("R81DMNHCCKQKD", drDmNhCCKQKD))
                {
                    bdsDmNhCCKQKD.RemoveAt(bdsDmNhCCKQKD.Position);
                    dtDmNhCCKQKD.AcceptChanges();
                }
            }
            else
                Common.MsgOk("Bạn không có quyền xóa");
        }
        void DmCC_Edit(enuEdit enuNew_Edit)
        {
            if (bdsDmCCKQKD.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmNhCCKQKD = ((DataRowView)bdsDmNhCCKQKD.Current).Row;

            //Copy dòng hiện tại
            if (bdsDmCCKQKD.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDmCCKQKD.Current).Row, ref drDmCCKQKD);
            else
                drDmCCKQKD = dtDmCCKQKD.NewRow();

            if (enuNew_Edit == enuEdit.New)
                drDmCCKQKD["Ma_Nh_CC"] = drDmNhCCKQKD["Ma_Nh_CC"];

            frmDmCCKQKD_Edit frmEdit1 = new frmDmCCKQKD_Edit();
            frmEdit1.Load(enuNew_Edit, drDmCCKQKD);

            //Khi người dùng chọn chấp nhận
            if (frmEdit1.isAccept)
            {
                
                if (drDmCCKQKD["Ma_Tb"].ToString() != "")
                    drDmCCKQKD["Ten_Tb"] = DataTool.SQLGetNameByCode("R06DMTB", "Ma_Tb", "Ten_Tb", drDmCCKQKD["Ma_Tb"].ToString());

                if (drDmCCKQKD["Ma_Nh_Tb"].ToString() != "")
                    drDmCCKQKD["Ten_Nh_Tb"] = DataTool.SQLGetNameByCode("R06DMNHTB", "Ma_Nh_Tb", "Ten_Nh_Tb", drDmCCKQKD["Ma_Nh_Tb"].ToString());

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDmCCKQKD.Position >= 0)
                        dtDmCCKQKD.ImportRow(drDmCCKQKD);
                    else
                        dtDmCCKQKD.Rows.Add(drDmCCKQKD);

                    bdsDmCCKQKD.Position = bdsDmCCKQKD.Find("Ma_CC", drDmCCKQKD["Ma_CC"]);
                }
                else
                    Common.CopyDataRow(drDmCCKQKD, ((DataRowView)bdsDmCCKQKD.Current).Row);

                dtDmCCKQKD.AcceptChanges();
            }
            else
                dtDmCCKQKD.RejectChanges();
        }
        void DmCC_Delete()
        {
            if (bdsDmCCKQKD.Position < 0)
                return;
            
            if (!Element.sysIs_Admin)
            {
                string strCreate_User = (string)drDmCCKQKD["Create_Log"];
              
                if (strCreate_User != string.Empty && strCreate_User.Substring(14) != Element.sysUser_Id)
                {
                    Common.MsgOk("Chứng chỉ do " + strCreate_User.Substring(14) + " lập. Bạn không được xóa. Hoặc liên hệ PCNTT để thực hiện!!!");
                    return;                                       
                }
            }

            if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Delete))
            {
                drDmCCKQKD = ((DataRowView)bdsDmCCKQKD.Current).Row;
                string strPath = (string)drDmCCKQKD["File_Path"];

                if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                    return;

                if (DataTool.SQLDelete("R81DMCCKQKD", drDmCCKQKD))
                {
                    if(strPath != "")
                        File.Delete(strPath);

                    bdsDmCCKQKD.RemoveAt(bdsDmCCKQKD.Position);
                    dtDmCCKQKD.AcceptChanges();
                }
            }
            else
                Common.MsgOk("Bạn không có quyền xóa");
        }

        void dgvDmCCKQKD_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    DmCC_Edit(enuEdit.New);
                    break;
                case Keys.F3:
                    DmCC_Edit(enuEdit.Edit);
                    break;
                case Keys.F8:
                    DmCC_Delete();
                    break;
            }
        }

        void tlDmCCKQKD_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    DmNhCC_Edit(enuEdit.New);
                    break;
                case Keys.F3:
                    DmNhCC_Edit(enuEdit.Edit);
                    break;
                case Keys.F8:
                    DmNhCC_Delete();
                    break;
            }
        }

        void dgvDmCCKQKD_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            drCurrent = ((DataRowView)bdsDmCCKQKD.Current).Row;
            DataGridViewCell dgvCell = dgvDmCCKQKD.CurrentCell;
			string strColumnName = dgvCell.OwningColumn.Name.ToUpper();

            if (strColumnName == "OPEN_FILE")
            {
                drCurrent = ((DataRowView)bdsDmCCKQKD.Current).Row;
                object objFile = (object)drCurrent["File_Path"];
                string strPath = (string)drCurrent["File_Path"];


                if (objFile != null && objFile != DBNull.Value)// && ((Byte[])objFile).Length > 0)
                {
                    FileStream fileStream = new FileStream(strPath, FileMode.Open, FileAccess.Read);
                    //fileStream.Write((byte[])objFile, 0, ((byte[])objFile).Length);
                    fileStream.Close();
                    System.Diagnostics.Process.Start(strPath);
                }
            }
        }
	

		#endregion
	}
}
