using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using System.Collections;

namespace RosyModule.Machinery
{
    public partial class frmDmTb_ : RosyList.frmView
    {
        DataTable dtBTSC;
        BindingSource bdsBTSC = new BindingSource();
        rsDataGridView dgvBTSC = new rsDataGridView();
        DataRow drCurrent;

        public frmDmTb_()
        {
            InitializeComponent();
           
            btNew.Click += new EventHandler(btNew_Click);
            btEdit.Click += new EventHandler(btEdit_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            
        
        }

        #region event

        void btNew_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.New);
        }

        void btEdit_Click(object sender, EventArgs e)
        {
            this.Edit(enuEdit.Edit);
        }

        void btDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        #endregion
        public override void LoadLookup()
        {
           
            string strWhere = this.strLookupColumn + " LIKE '" + this.strLookupValue + "%'";

            if (this.strLookupKeyFilter != string.Empty && this.strLookupKeyFilter != null)
            {
                if (this.strLookupValue == "/" || this.strLookupValue == @"\")
                    strWhere = strLookupKeyFilter;
                else
                    strWhere = "(" + strLookupKeyFilter + ") AND (" + strWhere + ")";
            }

            DataTable dtFind = DataTool.SQLGetDataTable("R06DMTB", null, strWhere, null);

            if (dtFind.Rows.Count > 0)
            {
                strLookupKeyFilter = strWhere;
                //bFind = true;
                this.Load();
            }
              
            
           
        }
        public override void Load()
        {
            Build();
            FillData();

            if (this.isLookup)
                this.ShowDialog();
            else
                this.Show();
        }

        private void Build()
        {
            dgvBTSC.Dock = DockStyle.Fill;
            dgvBTSC.strZone = "DMTB";
            dgvBTSC.BuildGridView();

            this.rsSplitContainer1.Panel1.Controls.Add(dgvBTSC);
        }

        private void FillData()
        {
           
            dtBTSC = DataTool.SQLGetDataTable("R06DMTB", null, "", "Ma_Tb");
            bdsBTSC.DataSource = dtBTSC;
            dgvBTSC.DataSource = bdsBTSC;

            bdsSearch = bdsBTSC;
            ExportControl = dgvBTSC;

            if (this.isLookup)
                this.MoveToLookupValue();
        }

        private void MoveToLookupValue()
        {
            if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
                return;

            for (int i = 0; i <= dtBTSC.Rows.Count - 1; i++)
                if (((string)dtBTSC.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
                {
                    bdsBTSC.Position = i;
                    break;
                }
        }
        public override void Edit(enuEdit enuNew_Edit)
        {
            if (bdsBTSC.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy dong hien tai
            if (bdsBTSC.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsBTSC.Current).Row, ref drCurrent);
            else
                drCurrent = dtBTSC.NewRow();

            frmMachinery_Edit frmEdit = new frmMachinery_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            if (frmEdit.isAccept)
            {
                //if (drCurrent.Table.Columns.Contains("Ten_Dt_Cbnv_Bt"))
                //    drCurrent["Ten_Dt_Cbnv_Bt"] = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", drCurrent["Ma_Dt_Cbnv_Bt"].ToString());

                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsBTSC.Position >= 0)
                        dtBTSC.ImportRow(drCurrent);
                    else
                        dtBTSC.Rows.Add(drCurrent);

                    bdsBTSC.Position = bdsBTSC.Find("Ma_Tb", drCurrent["Ma_Tb"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsBTSC.Current).Row);

                dtBTSC.AcceptChanges();
            }
            else
                dtBTSC.RejectChanges();
        }


        public override void Delete()
        {
            if (bdsBTSC.Position < 0)
                return;

            drCurrent = ((DataRowView)bdsBTSC.Current).Row;

            if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
                return;

            if (DataTool.SQLDelete("R06DMTB", drCurrent))
            {
                bdsBTSC.RemoveAt(bdsBTSC.Position);
                dtBTSC.AcceptChanges();
            }
        }

    }
}
