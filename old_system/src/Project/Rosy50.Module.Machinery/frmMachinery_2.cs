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
    public partial class frmMachinery_2 : RosySystem.Customize.frmView
    {
        public DataSet dsMachinery = new DataSet("dsMachinery");
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
        
        DataTable dtMoTaChung = new DataTable();
        BindingSource bdsMoTaChung = new BindingSource();
        rsDataGridView dgvMoTaChung = new rsDataGridView();

        DataTable dtPTKT = new DataTable();
        BindingSource bdsPTKT = new BindingSource();
        rsDataGridView dgvPTKT = new rsDataGridView();

        DataTable dtKHBT = new DataTable();
        BindingSource bdsKHBT = new BindingSource();
        rsDataGridView dgvKHBT = new rsDataGridView();

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
        
        public frmMachinery_2()
        {
            InitializeComponent();
            dgvDmVtTb.KeyDown += new KeyEventHandler(dgvDmVtTb_KeyDown);
            //dgvPTKT.KeyDown += new KeyEventHandler(dgvPTKT_KeyDown);
            //dgvVTDP.KeyDown += new KeyEventHandler(dgvVTDP_KeyDown);
            dgvKHBT.KeyDown += new KeyEventHandler(dgvBTSC_KeyDown);
            //dgvKHBTSC.KeyDown += new KeyEventHandler(dgvKHBTSC_KeyDown);
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
            btPreview.Click += new EventHandler(btPreview_Click);

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
                    this.EditKHBT(enuEdit.New);
                    break;

                case Keys.F3:
                    this.EditKHBT(enuEdit.Edit);
                    break;

                case Keys.F8:
                    this.deleteKHBT();
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
            printDetail_Tb(true);
        }
        
        void btDetailDelete_Click(object sender, EventArgs e)
        {
            if (tabDetail.SelectedTab == pageMoTaChung)
                deleteMoTaChung();
            else if (tabDetail.SelectedTab == pagePTKT)
				deletePTKT();
			else if (tabDetail.SelectedTab == pageVTDP)
				deleteVTDP();
            else if (tabDetail.SelectedTab == pageKHBT)
                deleteKHBT();
			else if (tabDetail.SelectedTab == pageKHBT)
				deleteKHBTSC();
			else if (tabDetail.SelectedTab == pageResource)
				deleteResource();
			else if (tabDetail.SelectedTab == pageImage)
				deleteImage();
        }

        void btDetailEdit_Click(object sender, EventArgs e)
        {
			 if (tabDetail.SelectedTab == pageMoTaChung)
                EditMoTaChung(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pagePTKT)
				EditPTKT(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageVTDP)
				EditVTDP(enuEdit.Edit);
             else if (tabDetail.SelectedTab == pageKHBT)
                 EditKHBT(enuEdit.Edit);
            //else if (tabDetail.SelectedTab == pageKHBT)
            //    EditKHBTSC(enuEdit.Edit);
			else if (tabDetail.SelectedTab == pageResource)
				OpenFile();
        }

        void btDetailNew_Click(object sender, EventArgs e)
        {
            if (tabDetail.SelectedTab == pageMoTaChung)
                EditMoTaChung(enuEdit.New);
			else if (tabDetail.SelectedTab == pagePTKT)
				EditPTKT(enuEdit.New);
			else if (tabDetail.SelectedTab == pageVTDP)
				EditVTDP(enuEdit.New);
            else if (tabDetail.SelectedTab == pageKHBT)
                EditKHBT(enuEdit.New);
            //else if (tabDetail.SelectedTab == pageKHBT)
            //    EditKHBTSC(enuEdit.New);
			else if (tabDetail.SelectedTab == pageResource)
				EditResource(enuEdit.New);
			else if (tabDetail.SelectedTab == pageImage)
				LoadPicture();
        }

        void deleteMoTaChung()
        {
            if (bdsMoTaChung.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsMoTaChung.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06MOTATB", drCurrent))
            {
                bdsMoTaChung.RemoveAt(bdsMoTaChung.Position);
                dtMoTaChung.AcceptChanges();
            }
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

        void deleteKHBT()
        {
            if (bdsKHBT.Position < 0)
                return;

            DataRow drCurrent = ((DataRowView)bdsKHBT.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06TSBTTB", drCurrent))
            {
                bdsKHBT.RemoveAt(bdsKHBT.Position);
                dtKHBT.AcceptChanges();
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

        void EditMoTaChung(enuEdit enuNew_Edit)
        {
            if (bdsDmVtTb.Position < 0)
                return;

            if (bdsMoTaChung.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

            //Copy dong hien tai
            if (bdsMoTaChung.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsMoTaChung.Current).Row, ref drCurrent);
            else
                drCurrent = dtMoTaChung.NewRow();

            drCurrent["Ma_Tb"] = drDmVtTb["Ma_Tb"];
            frmMoTaChung_Edit frmEdit = new frmMoTaChung_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsMoTaChung.Position >= 0)
                        dtMoTaChung.ImportRow(drCurrent);
                    else
                        dtMoTaChung.Rows.Add(drCurrent);

                    bdsMoTaChung.Position = bdsPTKT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsMoTaChung.Current).Row);

                dtMoTaChung.AcceptChanges();
            }
            else
                dtMoTaChung.RejectChanges();
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

            drCurrent["Ma_Tb"] = drDmVtTb["Ma_Tb"];
            frmPTKT_Edit frmEdit = new frmPTKT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                                   
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

        void EditKHBT(enuEdit enuNew_Edit)
        {
            if (bdsDmVtTb.Position < 0)
                return;

            if (bdsKHBT.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

            //Copy dòng hiện tại
            if (bdsKHBT.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsKHBT.Current).Row, ref drCurrent);
            else
                drCurrent = dtKHBT.NewRow();

            drCurrent["Ma_Tb"] = drDmVtTb["Ma_Tb"];
            //if (enuNew_Edit == enuEdit.New && drCurrent.Table.Columns.Contains("Trong_Ke_Hoach"))
            //    drCurrent["Trong_Ke_Hoach"] = false;

            frmKHBT_Edit frmEdit = new frmKHBT_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {

                if (drCurrent.Table.Columns.Contains("Ten_Tan_So"))
                    drCurrent["Ten_Tan_So"] = DataTool.SQLGetNameByCode("R81DMTYPE", "Type_ID", "Type_Name", drCurrent["Tan_So"].ToString());

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsKHBT.Position >= 0)
                        dtKHBT.ImportRow(drCurrent);
                    else
                        dtKHBT.Rows.Add(drCurrent);

                    bdsKHBT.Position = bdsKHBT.Find("Ident00", drCurrent["Ident00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsKHBT.Current).Row);

                dtKHBT.AcceptChanges();
            }
            else
                dtKHBT.RejectChanges();
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
            bdsMoTaChung.Filter = "Ma_Tb = '" + (string)drDmVtTb["Ma_Tb"] + "'";
            bdsPTKT.Filter = "Ma_Tb = '" + (string)drDmVtTb["Ma_Tb"] + "'";
            bdsKHBT.Filter = "Ma_Tb = '" + (string)drDmVtTb["Ma_Tb"] + "'";
            bdsVTDP.Filter = "Ma_Tb = '" + (string)drDmVtTb["Ma_Tb"] + "'";
            bdsBTSC.Filter = "Ma_Tb = '" + (string)drDmVtTb["Ma_Tb"] + "'";
            bdsResource.Filter = "Ma_Tb = '" + (string)drDmVtTb["Ma_Tb"] + "'";
            bdsKHBTSC.Filter = "Ma_Tb = '" + (string)drDmVtTb["Ma_Tb"] + "'";
            loadImage();
        }

        private void loadImage()
        {
            //object objPic = SQLExec.ExecuteReturnValue("SELECT Hinh FROM R81DMVT WHERE Ma_Vt = '" + drDmVtTb["Ma_Vt"].ToString() + "'");

            //if (objPic == DBNull.Value)
            //    picImage.Image = null;
            //else
            //    picImage.Image = new Bitmap(Image.FromStream(new MemoryStream((Byte[])objPic)), picImage.Size);
        }

        void bdsDmNhVtTb_PositionChanged(object sender, EventArgs e)
        {
            if (bdsDmNhVtTb.Position < 0)
                return;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;

            if ((bool)drDmNhVtTb["Nh_Cuoi"] == false)
                bdsDmVtTb.Filter = "Ma_Nh_Tb_Parent = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";
            else
                bdsDmVtTb.Filter = "Ma_Nh_Tb = '" + (string)drDmNhVtTb["Ma_Nh_Tb"] + "'";

            //tabDmVtTb.SelectedTab = tabDmVtTb;
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
            dgvDmVtTb.strZone = "DMTB";
            dgvDmVtTb.BuildGridView(this.isLookup);
            this.tabDmVtTb.Controls.Add(dgvDmVtTb);

            dgvMoTaChung.Dock = DockStyle.Fill;
            dgvMoTaChung.strZone = "DMTBMOTA";
            dgvMoTaChung.BuildGridView(this.isLookup);
            this.pageMoTaChung.Controls.Add(dgvMoTaChung);

            dgvPTKT.Dock = DockStyle.Fill;
            dgvPTKT.strZone = "DMVTTB";
            dgvPTKT.BuildGridView(this.isLookup);
            this.pagePTKT.Controls.Add(dgvPTKT);

            dgvKHBT.Dock = DockStyle.Fill;
            dgvKHBT.strZone = "TANSOBT";
            dgvKHBT.BuildGridView(this.isLookup);
            this.pageKHBT.Controls.Add(dgvKHBT);

            //dgvVTDP.Dock = DockStyle.Fill;
            //dgvVTDP.strZone = "VTDP";
            //dgvVTDP.BuildGridView(this.isLookup);
            //this.pageVTDP.Controls.Add(dgvVTDP);

            //dgvBTSC.Dock = DockStyle.Fill;
            //dgvBTSC.strZone = "LSBTSC";
            //dgvBTSC.BuildGridView(this.isLookup);
            //this.pageBTSC.Controls.Add(dgvBTSC);

            //dgvResource.Dock = DockStyle.Fill;
            //dgvResource.strZone = "RESOURCEMMTB";
            //dgvResource.BuildGridView(this.isLookup);
            //this.pageResource.Controls.Add(dgvResource);

            //dgvKHBTSC.Dock = DockStyle.Fill;
            //dgvKHBTSC.strZone = "KHBT";
            //dgvKHBTSC.BuildGridView(this.isLookup);
            //this.pageKHBT.Controls.Add(dgvKHBTSC);
        }

        private void FillData()
        {
            dsMachinery.Clear();
            dsMachinery = SQLExec.ExecuteReturnDs("sp_GetVoucherFilter_Machinery", CommandType.StoredProcedure);

            //Nhóm vật tư thiết bị
            dtDmNhVtTb = dsMachinery.Tables[0];
            bdsDmNhVtTb.DataSource = dtDmNhVtTb;
            tlDmNhVtTb.DataSource = bdsDmNhVtTb;

            tlDmNhVtTb.Expand = (bool)SQLExec.ExecuteReturnValue("SELECT Expand FROM R00ZONE WHERE ZONE = '" + tlDmNhVtTb.strZone + "'");

            //Danh mục thiết bị
            dtDmVtTb = dsMachinery.Tables[1];
            bdsDmVtTb.DataSource = dtDmVtTb;
            dgvDmVtTb.DataSource = bdsDmVtTb;

            //Mô tả thiết bị
            dtMoTaChung = dsMachinery.Tables[2];
            bdsMoTaChung.DataSource = dtMoTaChung;
            dgvMoTaChung.DataSource = bdsMoTaChung;

            ////Phụ tùng kèm theo
            dtPTKT = dsMachinery.Tables[3];
            bdsPTKT.DataSource = dtPTKT;
            dgvPTKT.DataSource = bdsPTKT;

            ////Kế hoạch bảo trì
            dtKHBT = dsMachinery.Tables[4];
            bdsKHBT.DataSource = dtKHBT;
            dgvKHBT.DataSource = bdsKHBT;

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

            frmMachinery_Edit frmEdit = new frmMachinery_Edit();
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

                    bdsDmVtTb.Position = bdsDmVtTb.Find("Ma_Tb", drDmVtTb["Ma_Tb"]);
                }
                else
                    Common.CopyDataRow(drDmVtTb, ((DataRowView)bdsDmVtTb.Current).Row);

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

            if (DataTool.SQLDelete("R06DmTb", drDmVtTb))
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

            if (DataTool.SQLDelete("R06DMNHTB", drDmNhVtTb))
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

            //if (!dtBTSC.Columns.Contains("STT"))
            //    dtBTSC.Columns.Add("STT", typeof(int));

            drDmVtTb["REPORT_FILE"] = "rptLyLichTb";
            drDmVtTb["NGAY_CT"] = Element.sysNgay_Ct2;

            Hashtable ht = new Hashtable();
            ht.Add("MA_TB", drDmVtTb["Ma_Tb"].ToString());

            DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintLyLichMMTB", ht, CommandType.StoredProcedure);
            DataTable dtHeader = ds.Tables[0];
            DataTable dtDetail = ds.Tables[1];

            RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
            return frmPrint.Load(drDmVtTb, dtDetail, bPreview, true);
        }

        private bool printDetail_Tb(bool bPreview)
        {
            if (bdsDmNhVtTb.Position < 0)
                return false;

            if (bdsDmVtTb.Position < 0)
                return false;

            drDmNhVtTb = ((DataRowView)bdsDmNhVtTb.Current).Row;
            drDmVtTb = ((DataRowView)bdsDmVtTb.Current).Row;

            DataTable dtHeader = new DataTable();
            DataTable dtDetail = new DataTable();

            //Load form chọn in

            frmIn_ListTB frm = new frmIn_ListTB();
            frm.Load(drDmNhVtTb);
            if (frm.isAccept)
            {
                string strLoai_BTTB = "";

                if (frm.rdbPlan_BTTB_NB.Checked == true)
                    strLoai_BTTB = "NB";
                else
                    strLoai_BTTB = "BN";

                Hashtable ht = new Hashtable();
                ht.Add("MA_NH_TB", drDmNhVtTb["Ma_Nh_Tb"].ToString());                
                ht.Add("LOAI_BTTB", strLoai_BTTB);
                ht.Add("NAM", Element.sysWorkingYear);
                ht.Add("MA_DVCS", Element.sysMa_DvCs);

                DataSet ds = SQLExec.ExecuteReturnDs("sp_PrintLichBTTB", ht, CommandType.StoredProcedure);
                dtHeader = ds.Tables[0];
                dtDetail = ds.Tables[1];

              if( strLoai_BTTB == "BN")
                    strReportFile = "rptPlan_BTTB_BN";
               else
                    strReportFile = "rptPlan_BTTB_NB";
             }

                if (!dtDmNhVtTb.Columns.Contains("REPORT_FILE"))
                    dtDmNhVtTb.Columns.Add("REPORT_FILE", typeof(string));

                if (!dtDmNhVtTb.Columns.Contains("NGAY_CT"))
                    dtDmNhVtTb.Columns.Add("NGAY_CT", typeof(DateTime));

                drDmNhVtTb["REPORT_FILE"] = strReportFile;
                drDmNhVtTb["NGAY_CT"] = Element.sysNgay_Ct2;

                RosyReport.frmReportPrint frmPrint = new RosyReport.frmReportPrint();
                return frmPrint.Load(drDmNhVtTb, dtDetail, bPreview, true);

            
        }

        private void Design()
        {
            if (dgvDmVtTb.Focused)
                strReportFile = "rptLyLichTb";
            else if (tabDetail.SelectedTab == pageKHBT)
            {
                frmIn_ListTB frm = new frmIn_ListTB();
                frm.Load(drDmNhVtTb);
                bool is_InLich = false;
                string strLoai_BTTB = "ALL";
                if (frm.isAccept)
                {          
                   if(frm.rdbPlan_BTTB_NB.Checked == true)
                        strLoai_BTTB = "NB";
                    else
                       strLoai_BTTB = "BN";
                }

                if (strLoai_BTTB == "BN")
                    strReportFile = "rptPlan_BTTB_BN";
                else
                    strReportFile = "rptPlan_BTTB_NB";
            }

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
