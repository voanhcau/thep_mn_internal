using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;

namespace RosyModule.Machinery
{
    public partial class frmMachinery_ : RosySystem.Customize.frmView
    {
        string strReportFile = string.Empty;
        object objFileContent = null;

        DataTable dtDmNhVtTb = new DataTable();
        BindingSource bdsDmNhVtTb = new BindingSource();
        rsTreeList tlDmNhVtTb = new rsTreeList();
        DataRow drDmNhVtTb;

        DataTable dtDmVtTb = new DataTable();
        BindingSource bdsDmVtTb = new BindingSource();
        rsDataGridView dgvDmVtTb = new rsDataGridView();
        DataRow drDmVtTb;
        
        DataTable dtPTKT = new DataTable();
        BindingSource bdsPTKT = new BindingSource();
        rsDataGridView dgvPTKT = new rsDataGridView();

        DataTable dtVTDP = new DataTable();
        BindingSource bdsVTDP = new BindingSource();
        rsDataGridView dgvVTDP = new rsDataGridView();

        DataTable dtBTSC = new DataTable();
        BindingSource bdsBTSC = new BindingSource();
        rsDataGridView dgvBTSC = new rsDataGridView();

        DataTable dtResource = new DataTable();
        BindingSource bdsResource = new BindingSource();
        rsDataGridView dgvResource = new rsDataGridView();

		DataTable dtKHBTSC = new DataTable();
		BindingSource bdsKHBTSC = new BindingSource();
		rsDataGridView dgvKHBTSC = new rsDataGridView();

        private DataRow drCurrent;

        public frmMachinery_()
        {
            InitializeComponent();
            dgvDmVtTb.KeyDown += new KeyEventHandler(dgvDmVtTb_KeyDown);
            dgvPTKT.KeyDown += new KeyEventHandler(dgvPTKT_KeyDown);
            dgvVTDP.KeyDown += new KeyEventHandler(dgvVTDP_KeyDown);
            dgvBTSC.KeyDown += new KeyEventHandler(dgvBTSC_KeyDown);
			dgvKHBTSC.KeyDown += new KeyEventHandler(dgvKHBTSC_KeyDown);
            tlDmNhVtTb.KeyDown += new KeyEventHandler(tlDmNhVtTb_KeyDown);
            dgvResource.KeyDown += new KeyEventHandler(dgvResource_KeyDown);
            bdsDmNhVtTb.PositionChanged += new EventHandler(bdsDmNhVtTb_PositionChanged);
            bdsDmVtTb.PositionChanged += new EventHandler(bdsDmVtTb_PositionChanged);
            
            btDetailNew.Click += new EventHandler(btDetailNew_Click);
            btDetailEdit.Click += new EventHandler(btDetailEdit_Click);
            btDetailDelete.Click += new EventHandler(btDetailDelete_Click);
            btDetailPreview.Click += new EventHandler(btDetailPreview_Click);

            btNewDmNhVtTb.Click += new EventHandler(btNewDmNhVtTb_Click);
            btEditDmNhVtTb.Click += new EventHandler(btEditDmNhVtTb_Click);
            btDeleteDmNhVtTb.Click += new EventHandler(btDeleteDmNhVtTb_Click);
            btTao_DNX.Click += new EventHandler(btPreview_Click);
            btAddList.Click += new EventHandler(btAddList_Click);

            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
			tabDetail.SelectedIndexChanged += new EventHandler(tabDetail_SelectedIndexChanged);
        }

        

		void tabDetail_SelectedIndexChanged(object sender, EventArgs e)
		{
			tabChange();
		}

		void tabChange()
		{
			if (tabDetail.SelectedTab == pageImage || tabDetail.SelectedTab == pageResource)
			{
				btDetailNew.Text = "Upload";
				btDetailDelete.Text = "Remove";
				btDetailEdit.Text = "Download";
			}
			else
			{
				btDetailNew.Text = "Thêm";
				btDetailDelete.Text = "Xóa";
				btDetailEdit.Text = "Sửa";
			}
		}

        private void OpenFile()
        {
            drCurrent = ((DataRowView)bdsResource.Current).Row;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*." + drCurrent["File_Tag"].ToString() + ")|*." + drCurrent["File_Tag"].ToString() + "|All files (*.*)|*.*";
            sfd.FileName = drCurrent["File_Name"].ToString();

            objFileContent = this.LoadResource(drCurrent["File_Name"].ToString());

            if (objFileContent != null)
                using (Stream s = new MemoryStream())
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    formatter.Serialize(s, objFileContent);
                }

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fileStream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.ReadWrite);
                fileStream.Write((byte[])objFileContent, 0, ((byte[])objFileContent).Length);
                fileStream.Close();

                System.Diagnostics.Process.Start(sfd.FileName);
            }
        }

        void btDelete_Click(object sender, EventArgs e)
        {
            Machinery_Delete();
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            Machinery_Edit(enuEdit.Edit);
        }

        void btNew_Click(object sender, EventArgs e)
        {
            Machinery_Edit(enuEdit.New);
        }

        void btDeleteDmNhVtTb_Click(object sender, EventArgs e)
        {
            this.DeleteDmNhVtTb();
        }


        void btPreview_Click(object sender, EventArgs e)
        {
            this.print(true);
        }

        void btEditDmNhVtTb_Click(object sender, EventArgs e)
        {
            this.EditDmNhVtTb(enuEdit.Edit);
        }
        void btAddList_Click(object sender, EventArgs e)
        {
            frmAddList_VTTB_ frm = new frmAddList_VTTB_();
            frm.Load((string)drDmNhVtTb["Ma_Nh_Tb"]);

            FillData();
        }
        void btNewDmNhVtTb_Click(object sender, EventArgs e)
        {
            this.EditDmNhVtTb(enuEdit.New);   
        }

        void tlDmNhVtTb_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.EditDmNhVtTb(enuEdit.New);
                    break;

                case Keys.F3:
                    this.EditDmNhVtTb(enuEdit.Edit);
                    break;

                case Keys.F8:
                    this.DeleteDmNhVtTb();
                    break;
                    
            }
        }

        void dgvBTSC_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.EditBTSC(enuEdit.New);
                    break;

                case Keys.F3:
                    this.EditBTSC(enuEdit.Edit);
                    break;

                case Keys.F8:
                    this.deleteBTSC();
                    break;

				case Keys.F7:
					switch (e.Modifiers)
					{
						case Keys.Control:
							this.print(true);
							break;

						case Keys.Shift:
							this.Design();
							break;

						case Keys.None:
							this.print(false);
							break;
					}
					break;
            }
        }

		void dgvKHBTSC_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F2:
					this.EditKHBTSC(enuEdit.New);
					break;

				case Keys.F3:
					this.EditKHBTSC(enuEdit.Edit);
					break;

				case Keys.F8:
					this.deleteKHBTSC();
					break;

				case Keys.F7:
					switch (e.Modifiers)
					{
						case Keys.Control:
							this.print(true);
							break;

						case Keys.Shift:
							this.Design();
							break;

						case Keys.None:
							this.print(false);
							break;
					}
					break;
			}
		}

        void dgvResource_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.EditResource(enuEdit.New);
                    break;

                case Keys.F3:
                    this.EditResource(enuEdit.Edit);
                    break;

                case Keys.F8:
                    this.deleteResource();
                    break;
            }
        }

        void dgvVTDP_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.EditVTDP(enuEdit.New);
                    break;

                case Keys.F3:
                    this.EditVTDP(enuEdit.Edit);
                    break;

                case Keys.F8:
                    this.deleteVTDP();
                    break;

				case Keys.F7:
					switch (e.Modifiers)
					{
						case Keys.Control:
							this.print(true);
							break;

						case Keys.Shift:
							this.Design();
							break;

						case Keys.None:
							this.print(false);
							break;
					}
					break;
            }
        }

        void dgvPTKT_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.EditPTKT(enuEdit.New);
                    break;

                case Keys.F3:
                    this.EditPTKT(enuEdit.Edit);
                    break;

                case Keys.F8:
                    this.deletePTKT();
                    break;

				case Keys.F7:
					switch (e.Modifiers)
					{
						case Keys.Control:
							this.print(true);
							break;

						case Keys.Shift:
							this.Design();
							break;

						case Keys.None:
							this.print(false);
							break;
					}
					break;
            }
        }

        void dgvDmVtTb_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.Machinery_Edit(enuEdit.New);
                    break;

                case Keys.F3:
                    this.Machinery_Edit(enuEdit.Edit);
                    break;

                case Keys.F8:
                    this.Machinery_Delete();
                    break;

                case Keys.F7:
                    switch (e.Modifiers)
                    {
                        case Keys.Control:
                            this.print(true);
                            break;

                        case Keys.Shift:
                            this.Design();
                            break;

                        case Keys.None:
                            this.print(false);
                            break;
                    }
                    break;
            }
        }

        void btDetailPreview_Click(object sender, EventArgs e)
        {
            printDetail(true);
        }
        
        void btDetailDelete_Click(object sender, EventArgs e)
        {
			if (tabDetail.SelectedTab == pagePTKT)
				deletePTKT();
			else if (tabDetail.SelectedTab == pageVTDP)
				deleteVTDP();
			else if (tabDetail.SelectedTab == pageBTSC)
				deleteBTSC();
			else if (tabDetail.SelectedTab == pageKHBT)
				deleteKHBTSC();
			else if (tabDetail.SelectedTab == pageResource)
				deleteResource();
			else if (tabDetail.SelectedTab == pageImage)
				deleteImage();
        }

        void btDetailEdit_Click(object sender, EventArgs e)
        {
			if (tabDetail.SelectedTab == pagePTKT)
				EditPTKT(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageVTDP)
				EditVTDP(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageBTSC)
				EditBTSC(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageKHBT)
				EditKHBTSC(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageResource)
				OpenFile();
        }

        void btDetailNew_Click(object sender, EventArgs e)
        {
			if (tabDetail.SelectedTab == pagePTKT)
				EditPTKT(enuEdit.New);
			else if (tabDetail.SelectedTab == pageVTDP)
				EditVTDP(enuEdit.New);
			else if (tabDetail.SelectedTab == pageBTSC)
				EditBTSC(enuEdit.New);
			else if (tabDetail.SelectedTab == pageKHBT)
				EditKHBTSC(enuEdit.New);
			else if (tabDetail.SelectedTab == pageResource)
				EditResource(enuEdit.New);
			else if (tabDetail.SelectedTab == pageImage)
				LoadPicture();
        }

        void deletePTKT()
        {
            if (bdsPTKT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsPTKT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06PTKT", drCurrent))
            {
                bdsPTKT.RemoveAt(bdsPTKT.Position);
                dtPTKT.AcceptChanges();
            }
        }

        void deleteVTDP()
        {
            if (bdsVTDP.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsVTDP.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06VTDP", drCurrent))
            {
                bdsVTDP.RemoveAt(bdsVTDP.Position);
                dtVTDP.AcceptChanges();
            }
        }

		void deleteKHBTSC()
		{
			if (bdsKHBTSC.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsKHBTSC.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R06KHBTSC", drCurrent))
			{
				bdsKHBTSC.RemoveAt(bdsKHBTSC.Position);
				dtKHBTSC.AcceptChanges();
			}
		}

        void deleteBTSC()
        {
            if (bdsBTSC.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsBTSC.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06BTSC", drCurrent))
            {
                bdsBTSC.RemoveAt(bdsBTSC.Position);
                dtBTSC.AcceptChanges();
            }
        }

        void deleteResource()
        {
            if (bdsResource.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsResource.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06RESOURCE", drCurrent))
            {
                bdsResource.RemoveAt(bdsResource.Position);
                dtResource.AcceptChanges();
            }
        }

		void deleteImage()
		{
			if (bdsDmVtTb.Position < 0)
				return;

			if (!Common.MsgYes_No("Bạn muốn remove hình ảnh"))
                return;

			drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;
			Hashtable ht = new Hashtable();

			ht.Add("MA_VT_TB", (string)drDmVtTb["Ma_Vt"]);

			SQLExec.Execute("UPDATE R81DMVT SET Hinh = NULL WHERE Ma_Vt = @Ma_Vt_Tb", ht, CommandType.Text);

			loadImage();
		}

        void EditPTKT(enuEdit enuNew_Edit)
        {
            if (bdsDmVtTb.Position < 0)
                return;

            if (bdsPTKT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsPTKT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsPTKT.Current).Row, ref drCurrent);
            else
                drCurrent = dtPTKT.NewRow();

            drCurrent["Ma_Vt_Tb"] = drDmVtTb["Ma_Vt"];
            frmPTKT_Edit frmEdit = new frmPTKT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (drCurrent.Table.Columns.Contains("Ten_Vt_Tb_Kt"))
                    drCurrent["Ten_Vt_Tb_Kt"] = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", (string)drCurrent["Ma_Vt_Tb_Kt"]);

                if (drCurrent.Table.Columns.Contains("Model"))
                    drCurrent["Model"] = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Model", (string)drCurrent["Ma_Vt_Tb_Kt"]);
                    
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsPTKT.Position >= 0)
                        dtPTKT.ImportRow(drCurrent);
                    else
                        dtPTKT.Rows.Add(drCurrent);

                    bdsPTKT.Position = bdsPTKT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsPTKT.Current).Row);

                dtPTKT.AcceptChanges();
            }
            else
                dtPTKT.RejectChanges();
        }

        void EditVTDP(enuEdit enuNew_Edit)
        {
            if (bdsDmVtTb.Position < 0)
                return;

            if (bdsVTDP.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;
            
            drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

            //Copy dòng hiện tại
            if (bdsVTDP.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsVTDP.Current).Row, ref drCurrent);
            else
                drCurrent = dtVTDP.NewRow();

            if (enuNew_Edit == enuEdit.New)
                drCurrent["Ma_Vt_Tb"] = drDmVtTb["Ma_Vt"];

            frmVTDP_Edit frmEdit = new frmVTDP_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                DataRow drDmVtDp = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", drCurrent["Ma_Vt_Dp"].ToString());

                if (drDmVtDp != null)
                {
                    if (drCurrent.Table.Columns.Contains("Ten_Vt_Dp"))
                        drCurrent["Ten_Vt_Dp"] = drDmVtDp["Ten_Vt"];

                    if (drCurrent.Table.Columns.Contains("Nuoc_Sx"))
                        drCurrent["Nuoc_Sx"] = drDmVtDp["Nuoc_Sx"];

                    if (drCurrent.Table.Columns.Contains("Model"))
                        drCurrent["Model"] = drDmVtDp["Model"];
                    
                    if (drCurrent.Table.Columns.Contains("Thong_So_Ky_Thuat"))
                        drCurrent["Thong_So_Ky_Thuat"] = drDmVtDp["Thong_So_Ky_Thuat"];
                    
                    if (drCurrent.Table.Columns.Contains("Tuoi_Tho"))
                        drCurrent["Tuoi_Tho"] = drDmVtDp["Tuoi_Tho"];
                    
                    if (drCurrent.Table.Columns.Contains("Ten_Dt_CC"))
                        drCurrent["Ten_Dt_CC"] = drDmVtDp["Ten_Dt_CC"];
                }

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsVTDP.Position >= 0)
                        dtVTDP.ImportRow(drCurrent);
                    else
                        dtVTDP.Rows.Add(drCurrent);

                    bdsVTDP.Position = bdsVTDP.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsVTDP.Current).Row);

                dtVTDP.AcceptChanges();
            }
            else
                dtVTDP.RejectChanges();
        }

        void EditBTSC(enuEdit enuNew_Edit)
        {
            if (bdsDmVtTb.Position < 0)
                return;

            if (bdsBTSC.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

            //Copy dòng hiện tại
            if (bdsBTSC.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBTSC.Current).Row, ref drCurrent);
            else
                drCurrent = dtBTSC.NewRow();

            drCurrent["Ma_Vt_Tb"] = drDmVtTb["Ma_Vt"];
            if (enuNew_Edit == enuEdit.New && drCurrent.Table.Columns.Contains("Trong_Ke_Hoach"))
                drCurrent["Trong_Ke_Hoach"] = false;

            frmBTSC_Edit frmEdit = new frmBTSC_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent, false);

            if (frmEdit.isAccept)
            {

                if (drCurrent.Table.Columns.Contains("Ten_Vt_Tb"))
                    drCurrent["Ten_Vt_Tb"] = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", drCurrent["Ma_Vt_Tb"].ToString());

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsBTSC.Position >= 0)
                        dtBTSC.ImportRow(drCurrent);
                    else
                        dtBTSC.Rows.Add(drCurrent);

                    bdsBTSC.Position = bdsBTSC.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsBTSC.Current).Row);

                dtBTSC.AcceptChanges();
            }
            else
                dtBTSC.RejectChanges();
        }

		void EditKHBTSC(enuEdit enuNew_Edit)
		{
			if (bdsKHBTSC.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsDmVtTb.Position < 0)
				return;

			drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

			//Copy dòng hiện tại
			if (bdsKHBTSC.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsKHBTSC.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtKHBTSC.NewRow();
				drCurrent["Ma_Vt_Tb"] = drDmVtTb["Ma_Vt"];
			}
			

			frmKHBTSC_Edit frmKHBTSC_Edit = new frmKHBTSC_Edit();
			frmKHBTSC_Edit.load(enuNew_Edit, drCurrent);

			if (frmKHBTSC_Edit.isAccept)
			{
				if (drCurrent.Table.Columns.Contains("Ten_Vt_Tb"))
					drCurrent["Ten_Vt_Tb"] = DataTool.SQLGetNameByCode("R81DMVT", "Ma_Vt", "Ten_Vt", drCurrent["Ma_Vt_Tb"].ToString());

				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsKHBTSC.Position >= 0)
						dtKHBTSC.ImportRow(drCurrent);
					else
						dtKHBTSC.Rows.Add(drCurrent);

					bdsKHBTSC.Position = bdsKHBTSC.Find("Ident00", drCurrent["Ident00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsKHBTSC.Current).Row);

				dtKHBTSC.AcceptChanges();
			}
			else
				dtKHBTSC.RejectChanges();
		}

        void EditResource(enuEdit enuNew_Edit)
        {
            if (bdsDmVtTb.Position < 0)
                return;

            if (bdsResource.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            if (bdsDmVtTb.Position >= 0)
                drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsResource.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsResource.Current).Row, ref drCurrent);
            else
                drCurrent = dtResource.NewRow();

            drCurrent["Ma_Vt_Tb"] = drDmVtTb["Ma_Vt"];


            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            this.objFileContent = (object)System.IO.File.ReadAllBytes(fileDialog.FileName);
            drCurrent["File_Tag"] = Path.GetExtension(fileDialog.FileName).Substring(1).ToUpper();
            drCurrent["File_Name"] = Path.GetFileNameWithoutExtension(fileDialog.FileName);
            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                drCurrent["Create_Log"] = Common.GetCurrent_Log();
            else
                drCurrent["LastModify_Log"] = Common.GetCurrent_Log();

            //Luu vao CSDL
            DataTool.SQLUpdate(enuNew_Edit, "R06Resource", ref drCurrent);
            SaveResource(drCurrent["File_Name"].ToString(), objFileContent);

            if (enuNew_Edit == enuEdit.New)
            {
                if (bdsResource.Position >= 0)
                    dtResource.ImportRow(drCurrent);
                else
                    dtResource.Rows.Add(drCurrent);

                bdsResource.Position = bdsResource.Find("Ident00", drCurrent["Ident00"]);
            }
            else
                Common.CopyDataRow(drCurrent, ((DataRowView)bdsResource.Current).Row);

            dtResource.AcceptChanges();
        }

        void bdsDmVtTb_PositionChanged(object sender, EventArgs e)
        {
            FilterDetail();
        }

        private void FilterDetail()
        {
            if (bdsDmVtTb.Position < 0)
                return;

            drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;
            bdsPTKT.Filter = "Ma_Vt_Tb = '" + (string)drDmVtTb["Ma_Vt"] + "'";
            bdsVTDP.Filter = "Ma_Vt_Tb = '" + (string)drDmVtTb["Ma_Vt"] + "'";
            bdsBTSC.Filter = "Ma_Vt_Tb = '" + (string)drDmVtTb["Ma_Vt"] + "'";
            bdsResource.Filter = "Ma_Vt_Tb = '" + (string)drDmVtTb["Ma_Vt"] + "'";
			bdsKHBTSC.Filter = "Ma_Vt_Tb = '" + (string)drDmVtTb["Ma_Vt"] + "'";
            loadImage();
        }

        private void loadImage()
        {
            object objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM R81DMVTTB WHERE Ident00 = '" + drDmVtTb["Ident00"].ToString() + "'");

            if (objPic == DBNull.Value)
                picImage.Image = null;
            else
                picImage.Image = new Bitmap(Image.FromStream(new MemoryStream((Byte[])objPic)), picImage.Size);
        }

        void bdsDmNhVtTb_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDmNhVtTb.Position < 0)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            
            if ((string)drDmNhVtTb["Ma_Nh_Tb"] == "***")
                bdsDmVtTb.Filter = "Ma_Nh_Tb_Parent LIKE '%*%'";
            else if ((bool)drDmNhVtTb["Nh_Cuoi"] == false && ((string)drDmNhVtTb["Ma_Nh_Tb"] != "***"))
                bdsDmVtTb.Filter = "Ma_Nh_Tb_Parent = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            else if ((bool)drDmNhVtTb["Nh_Cuoi"] == true && ((string)drDmNhVtTb["Ma_Nh_Tb"] != "***"))
                bdsDmVtTb.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            
                

            rsTabControl3.SelectedTab = tabDmVtTb;
            this.FilterDetail();
        }

        public override void Load()
        {
            this.Build();
            this.FillData();
            this.Show();
			this.tabChange();

            tlDmNhVtTb.Focus();
        }
        private void Build()
        {
            tlDmNhVtTb.KeyFieldName = "MA_NH_TB";
            tlDmNhVtTb.ParentFieldName = "MA_NH_TB_PARENT";
            tlDmNhVtTb.Dock = DockStyle.Fill;
            tlDmNhVtTb.strZone = "DMNHTB";
            tlDmNhVtTb.BuildTreeList(this.isLookup);
            this.tabDmNhVtTb.Controls.Add(tlDmNhVtTb);

            dgvDmVtTb.Dock = DockStyle.Fill;
            dgvDmVtTb.strZone = "DMVTTB";
            dgvDmVtTb.BuildGridView(this.isLookup);
            this.tabDmVtTb.Controls.Add(dgvDmVtTb);

            dgvPTKT.Dock = DockStyle.Fill;
            dgvPTKT.strZone = "PTKT";
            dgvPTKT.BuildGridView(this.isLookup);
            this.pagePTKT.Controls.Add(dgvPTKT);

            dgvVTDP.Dock = DockStyle.Fill;
            dgvVTDP.strZone = "VTDP";
            dgvVTDP.BuildGridView(this.isLookup);
            this.pageVTDP.Controls.Add(dgvVTDP);

            dgvBTSC.Dock = DockStyle.Fill;
            dgvBTSC.strZone = "LSBTSC";
            dgvBTSC.BuildGridView(this.isLookup);
            this.pageBTSC.Controls.Add(dgvBTSC);

            dgvResource.Dock = DockStyle.Fill;
            dgvResource.strZone = "RESOURCEMMTB";
            dgvResource.BuildGridView(this.isLookup);
			this.pageResource.Controls.Add(dgvResource);

			dgvKHBTSC.Dock = DockStyle.Fill;
			dgvKHBTSC.strZone = "KHBT";
			dgvKHBTSC.BuildGridView(this.isLookup);
			this.pageKHBT.Controls.Add(dgvKHBTSC);
        }

        private void FillData()
        {
            //Nhóm vật tư thiết bị
            dtDmNhVtTb = DataTool.SQLGetDataTable("R81DMNHTB", string.Empty, string.Empty, string.Empty);
            bdsDmNhVtTb.DataSource = dtDmNhVtTb;
            tlDmNhVtTb.DataSource = bdsDmNhVtTb;

            tlDmNhVtTb.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmNhVtTb.strZone + "'");

            //Danh mục vật tư thiết bị
            //dtDmVtTb = SQLExec.ExecuteReturnDt("SELECT T1.*, T2.Dvt, T2.Ten_Vt_Chuan, T2.Thong_So_Kt, T2.Ma_Tb_Nha_Sx, T2.Ten_Nha_Sx, T3.Ma_Nh_Tb_Parent FROM R81DMVTTB T1 JOIN R81DMVT T2 ON T1.Ma_Vt = T2.Ma_Vt JOIN R81DMNHTB T3 ON T1.Ma_Nh_Tb = T3.Ma_Nh_Tb ORDER BY T1.Ma_Nh_Tb, Ma_Vt");//DataTool.SQLGetDataTable("R81DMVT", string.Empty, "Ma_Nh_Tb <> ''", string.Empty);
            dtDmVtTb = SQLExec.ExecuteReturnDt("sp_GetDmVTTB");
            bdsDmVtTb.DataSource = dtDmVtTb;
            dgvDmVtTb.DataSource = bdsDmVtTb;

            ////Phụ tùng kèm theo
            //dtPTKT = DataTool.SQLGetDataTable("vw_PTKT", string.Empty, string.Empty, "Ma_Vt_Tb, Ma_Vt_Tb_Kt");
            //bdsPTKT.DataSource = dtPTKT;
            //dgvPTKT.DataSource = bdsPTKT;

            ////Vật tư dự phòng
            //dtVTDP = DataTool.SQLGetDataTable("vw_VTDP", string.Empty, string.Empty, "Ma_Vt_Tb");
            //bdsVTDP.DataSource = dtVTDP;
            //dgvVTDP.DataSource = bdsVTDP;

            ////Bảo trì sửa chữa
            //dtBTSC = SQLExec.ExecuteReturnDt("SELECT T1.*, T3.Ten_Vt AS Ten_Vt_Tb, CASE WHEN Trong_Ke_Hoach = 1 THEN 0 ELSE 1 END AS Ngoai_Ke_Hoach, T2.Ten_Dt AS Ten_Dt_Cbnv_Bt FROM R06BTSC T1 INNER JOIN R81DMDT T2 ON T1.Ma_Dt_Cbnv_Bt = T2.Ma_Dt LEFT JOIN R81DMVT T3 ON T1.Ma_Vt_Tb = T3.Ma_Vt", CommandType.Text);
            //bdsBTSC.DataSource = dtBTSC;
            //dgvBTSC.DataSource = bdsBTSC;

            ////Lưu file
            //dtResource = SQLExec.ExecuteReturnDt("SELECT T1.Ident00, T1.Ma_Vt_Tb, T1.File_Name, T1.File_Tag, T1.Create_Log, T1.LastModify_Log FROM R06RESOURCE T1", CommandType.Text);
            //bdsResource.DataSource = dtResource;
            //dgvResource.DataSource = bdsResource;

            //dtKHBTSC = DataTool.SQLGetDataTable("R06KHBTSC", "", "", "Ngay_Ap, Ngay_End");
            //bdsKHBTSC.DataSource = dtKHBTSC;
            //dgvKHBTSC.DataSource = bdsKHBTSC;

            bdsSearch = bdsDmVtTb;
            ExportControl = dgvDmVtTb;
        }

        void Machinery_Edit(enuEdit enuNew_Edit)
        {
            if (bdsDmVtTb.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy dòng hiện tại
            if (bdsDmVtTb.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDmVtTb.Current).Row, ref drDmVtTb);
            else
                drDmVtTb = dtDmVtTb.NewRow();

            if (enuNew_Edit == enuEdit.New)
                drDmVtTb["Ma_Nh_Tb"] = drDmNhVtTb["Ma_Nh_Tb"];

            frmMachineryCT_Edit frmEdit = new frmMachineryCT_Edit();
            frmEdit.Load(enuNew_Edit, drDmVtTb);

            //Khi người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDmVtTb.Position >= 0)
                        dtDmVtTb.ImportRow(drDmVtTb);
                    else
                        dtDmVtTb.Rows.Add(drDmVtTb);

                    bdsDmVtTb.Position = bdsDmVtTb.Find("Ma_Vt", drDmVtTb["Ma_Vt"]);
                }
                else
                    Common.CopyDataRow(drDmVtTb, ((DataRowView)bdsDmVtTb.Current).Row);
                
                drDmVtTb["Ten_Vt_Chuan"] = frmEdit.drEdit["Ten_Vt_Chuan"];
                drDmVtTb["Dvt"] = frmEdit.drEdit["Dvt"];
                drDmVtTb["Thong_So_Kt"] = frmEdit.drEdit["Thong_So_Kt"];
                drDmVtTb["Ma_Tb_Nha_Sx"] = frmEdit.drEdit["Ma_Tb_Nha_Sx"];
                drDmVtTb["Ten_Nha_Sx"] = frmEdit.drEdit["Ten_Nha_Sx"];
                loadImage();
                
                dtDmVtTb.AcceptChanges();
            }
            else
                dtDmVtTb.RejectChanges();
        }

        void Machinery_Delete()
        {
            if (bdsDmVtTb.Position < 0)
                return;

            drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R81DmVtTb", drDmVtTb))
            {
                bdsDmVtTb.RemoveAt(bdsDmVtTb.Position);
                dtDmVtTb.AcceptChanges();
            }
        }

        void EditDmNhVtTb(enuEdit enuNew_Edit)
        {
            if (bdsDmNhVtTb.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy dong hien tai
            if (bdsDmNhVtTb.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsDmNhVtTb.Current).Row, ref drDmNhVtTb);
            else
                dtDmNhVtTb.NewRow();

            RosyList.frmDmNhTb_Edit frmEdit = new RosyList.frmDmNhTb_Edit();
            frmEdit.Load(enuNew_Edit, drDmNhVtTb);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsDmNhVtTb.Position >= 0)
                        dtDmNhVtTb.ImportRow(drDmNhVtTb);
                    else
                        dtDmNhVtTb.Rows.Add(drDmNhVtTb);

                    bdsDmNhVtTb.Position = bdsDmNhVtTb.Find("MA_NH_TB", drDmNhVtTb["MA_NH_TB"]);
                }
                else
                    Common.CopyDataRow(drDmNhVtTb, ((DataRowView)bdsDmNhVtTb.Current).Row);

                dtDmNhVtTb.AcceptChanges();
            }
        }

        void DeleteDmNhVtTb()
        {
            if (bdsDmNhVtTb.Position < 0)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;

            if (!Common.CheckPermission("DMNHTB", enuPermission_Type.Allow_Delete))
            {
                string strMsg = Element.sysLanguage == enuLanguageType.English ? "You have no permission to merge Item group code!" : "Bạn không đc cấp quyền xóa!";
                Common.MsgCancel(strMsg);
                return;
            }
            
            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R81DMNHTB", drDmNhVtTb))
            {
                bdsDmNhVtTb.RemoveAt(bdsDmNhVtTb.Position);
                dtDmNhVtTb.AcceptChanges();
            }
        }

        private bool print(bool bPreview)
        {
            if (bdsDmVtTb.Position < 0)
                return false;

            drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

            if (!dtDmVtTb.Columns.Contains("NGAY_CT"))
                dtDmVtTb.Columns.Add("NGAY_CT", typeof(DateTime));

            if (!dtDmVtTb.Columns.Contains("REPORT_FILE"))
                dtDmVtTb.Columns.Add("REPORT_FILE", typeof(string));

            if (!dtBTSC.Columns.Contains("STT"))
                dtBTSC.Columns.Add("STT", typeof(int));

            drDmVtTb["REPORT_FILE"] = "rptDmVtTb";
            drDmVtTb["NGAY_CT"] = Element.sysNgay_Ct2;

            Hashtable ht = new Hashtable();
            ht.Add("MA_VT", drDmVtTb["Ma_Vt"].ToString());

            DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintLyLichMMTB", ht, CommandType.StoredProcedure);
            DataTable dtHeader = ds.Tables[0];
            DataTable dtDetail = ds.Tables[1];

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drDmVtTb, dtDetail, bPreview, true);
        }

        private bool printDetail(bool bPreview)
        {
            if (bdsDmVtTb.Position < 0)
                return false;

            drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;
            DataTable dtDetail = new DataTable();

            if (tabDetail.SelectedTab == pagePTKT)
            {
                strReportFile = "rptPTKT";
                dtDetail = dtPTKT;
            }
            else if (tabDetail.SelectedTab == pageVTDP)
            {
                strReportFile = "rptVTDP";
                dtDetail = dtVTDP;
            }
            else
            {
				Hashtable ht = new Hashtable();
				ht.Add("MA_VT", drDmVtTb["Ma_Vt"].ToString());

				DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintLichSuBTSCMMTB", ht, CommandType.StoredProcedure);
				DataTable dtHeader = ds.Tables[0];
				dtDetail = ds.Tables[1];

                strReportFile = "rptBTSC";
            }

            if (!dtDmVtTb.Columns.Contains("REPORT_FILE"))
                dtDmVtTb.Columns.Add("REPORT_FILE", typeof(string));

            if (!dtDmVtTb.Columns.Contains("NGAY_CT"))
                dtDmVtTb.Columns.Add("NGAY_CT", typeof(DateTime));

            drDmVtTb["REPORT_FILE"] = strReportFile;
            drDmVtTb["NGAY_CT"] = Element.sysNgay_Ct2;

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drDmVtTb, dtDetail, bPreview);
        }

        private void Design()
        {
            if (dgvDmVtTb.Focused)
                strReportFile = "rptDmVtTb";
            else if (tabDetail.SelectedTab == pagePTKT)
                strReportFile = "rptPTKT";
            else if (tabDetail.SelectedTab == pageVTDP)
                strReportFile = "rptVTDP";
            else
                strReportFile = "rptBTSC";

            RosyReport.frmReportDesign frmDesign = new RosyReport.frmReportDesign();
            frmDesign.Load(strReportFile);
        }

        private bool SaveResource(string strFile_Name, object objFile_Content)
        {
            string str;
            System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
            hashtable.Add("FILE_NAME", strFile_Name);
            hashtable.Add("FILE_CONTENT", (objFile_Content == null) ? ((object)new byte[0]) : ((object)((byte[])objFile_Content)));
            if (DataTool.SQLCheckExist("R06Resource", new string[] { "File_Name" }, new object[] { strFile_Name }))
            {
                str = "UPDATE R06Resource SET File_Content = @File_Content WHERE File_Name = @File_Name";
            }
            else
            {
                str = "INSERT INTO R06Resource (File_Name, File_Content) VALUES (@File_Name, @File_Content)";
            }
            return SQLExec.Execute(str, hashtable, CommandType.Text);
        }

        private object LoadResource(string strFile_Name)
        {
            if (strFile_Name != null)
            {
                System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
                hashtable.Add("FILE_NAME", strFile_Name);
                object obj2 = SQLExec.ExecuteReturnValue("SELECT File_Content FROM R06Resource WHERE File_Name = @File_Name", hashtable, CommandType.Text);
                if (((obj2 != null) && (obj2 != System.DBNull.Value)) && (((byte[])obj2).Length > 0))
                {
                    return obj2;
                }
            }
            return null;
        }

		private void LoadPicture()
		{
			OpenFileDialog fileDialog = new OpenFileDialog();

			fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			fileDialog.Filter = fileDialog.Filter = "(*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*"; ;

			if (fileDialog.ShowDialog() != DialogResult.OK)
				return;

			FileInfo fiImage = new FileInfo(fileDialog.FileName);
			FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

			picImage.Image = new Bitmap(Image.FromStream(fs), picImage.Size);
			picImage.SizeMode = PictureBoxSizeMode.Zoom;

			SavePicture();
		}

		private void SavePicture()
		{
			if (bdsDmVtTb.Position < 0)
				return;

			drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

			Hashtable ht = new Hashtable();
			ht.Add("MA_VT", (string)drDmVtTb["Ma_Vt"]);

			if (picImage.Image != null)
			{
				byte[] barrImg = (byte[])System.ComponentModel.TypeDescriptor.GetConverter(picImage.Image).ConvertTo(picImage.Image, typeof(byte[]));
				ht["HINH"] = barrImg;
				SQLExec.Execute("UPDATE R81DmVt SET Hinh = @Hinh WHERE Ma_Vt = @Ma_Vt", ht, CommandType.Text);
			}
			else
			{
				ht["HINH"] = new byte[] { };
				SQLExec.Execute("UPDATE R81DmVt SET Hinh = Null WHERE Ma_Vt = = @Ma_Vt", ht, CommandType.Text);
			}

			loadImage();
		}

    }
}
