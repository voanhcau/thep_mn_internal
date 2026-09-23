using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.Machinery
{
	public partial class frmAddList_VTTB_ : RosySystem.Customize.frmView
	{
		#region variable

		DataTable dtDmVt;
       rsDataGridView dgvDmVt = new rsDataGridView();
		BindingSource bdsDmVt = new BindingSource();

        DataTable dtDmTb;
        rsDataGridView dgvDmTb = new rsDataGridView();
        BindingSource bdsDmTb = new BindingSource();

		DataRow drCurrent;
        string strMa_Nh_Tb = string.Empty;

		#endregion

		#region Contructor

        public frmAddList_VTTB_()
		{
			InitializeComponent();
            
            btAdd.Click += new EventHandler(btAdd_Click);
            btCancel.Click += new EventHandler(btCancel_Click);
            btSave.Click += new EventHandler(btSave_Click);
            btDelete.Click += new EventHandler(btDelete_Click);

            btRefresh.Click += new EventHandler(btRefresh_Click);
            this.KeyDown += new KeyEventHandler(frmAddList_VTTB_KeyDown);

            txtMa_Cum.Validating += new CancelEventHandler(txtMa_Cum_Validating);

		}

       
		public void Load()
		{
			Load(string.Empty);
		}

		public void Load(string strMa_VtTb)
		{
            this.strMa_Nh_Tb = strMa_VtTb;

			Build();
			FillData(strMa_Nh_Tb);

            //this.strLookupColumn = "Ma_Vt_Tb";
            //this.strLookupValue = strMa_Vt_Tb;

            //this.MoveToLookupValue();

			this.Show();
		}
		
        //private void MoveToLookupValue()
        //{
        //    if (this.strLookupColumn == string.Empty || this.strLookupValue == string.Empty)
        //        return;

        //    for (int i = 0; i <= dtDmVt.Rows.Count - 1; i++)
        //        if (((string)dtDmVt.Rows[i][strLookupColumn]).StartsWith(strLookupValue))
        //        {
        //            bdsDmVt.Position = i;
        //            break;
        //        }
        //}

		private void Build()
		{
            txtMa_Cum.bUseAutoDropDown = true;

            dgvDmVt.Dock = DockStyle.Fill;
            dgvDmVt.strZone = "DMVT_LIST";
            dgvDmVt.BuildGridView();
            dgvDmVt.ReadOnly = false;
            this.splitContainer1.Panel1.Controls.Add(dgvDmVt);


            foreach (DataGridViewColumn dgvc in dgvDmVt.Columns)
                dgvc.ReadOnly = true;

            if (dgvDmVt.Columns.Contains("CHON"))
                dgvDmVt.Columns["CHON"].ReadOnly = false;
            
            // danh sách thiết bị
            dgvDmTb.Dock = DockStyle.Fill;
            dgvDmTb.strZone = "DMTB_LIST";
            dgvDmTb.BuildGridView();
            dgvDmTb.ReadOnly = false;
            this.splitContainer1.Panel2.Controls.Add(dgvDmTb);

            foreach (DataGridViewColumn dgvc in dgvDmTb.Columns)
                dgvc.ReadOnly = true;

            if (dgvDmTb.Columns.Contains("CHON"))
                dgvDmTb.Columns["CHON"].ReadOnly = false;
		}

		private void FillData(string strMa_Nh_Tb)
		{
            Hashtable ht = new Hashtable();
            ht.Add("MA_NH_TB", strMa_Nh_Tb);
            ht.Add("MA_CUM", txtMa_Cum.Text);

			dtDmVt = SQLExec.ExecuteReturnDt("sp_GetDMVT_LIST", ht, CommandType.StoredProcedure);

			bdsDmVt.DataSource = dtDmVt;
            dgvDmVt.DataSource = bdsDmVt;

            Hashtable ht1 = new Hashtable();
            ht1.Add("MA_NH_TB", strMa_Nh_Tb);

            dtDmTb = SQLExec.ExecuteReturnDt("sp_GetDMTB_LIST", ht1, CommandType.StoredProcedure);

            bdsDmTb.DataSource = dtDmTb;
            dgvDmTb.DataSource = bdsDmTb;

			this.bdsSearch = bdsDmVt;
            this.ExportControl = dgvDmVt;
		}

       
		#endregion

		#region Event 
        void btRefresh_Click(object sender, EventArgs e)
        {
            FillData(strMa_Nh_Tb);
        }
        void btDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        void btSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        void Save()
        {
            if (dtDmTb == null || dtDmTb.Select("Chon = true").Length == 0)
            {
                Common.MsgOk("Không có dữ liệu được lưu!");

            }
            else
            {
                foreach (DataRow drSelect in dtDmTb.Select("Chon = true"))
                {
                    DataRow drEditCtNew = dtDmTb.NewRow();
                    Common.CopyDataRow(drSelect, drEditCtNew);
                    Common.SetDefaultDataRow(ref drEditCtNew);

                    drEditCtNew["Create_Log"] = Common.GetCurrent_Log();
                    drEditCtNew["Ma_Nh_Tb"] = drSelect["Ma_Nh_Tb"];
                    drEditCtNew["Ma_Vt"] = drSelect["Ma_Vt"];

                    //Luu xuong CSDL
                    DataTool.SQLUpdate(enuEdit.New, "R81DmVtTb", ref drEditCtNew);
                        
                }

                Common.MsgOk("Đã lưu xong");
            }
        }
        void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void btAdd_Click(object sender, EventArgs e)
        {
            if (dtDmVt == null || dtDmVt.Select("Chon = true").Length == 0)
            {
                Common.MsgOk("Không có dữ liệu được tạo!");

            }
            else
            {
                foreach (DataRow drSelect in dtDmVt.Select("Chon = true"))
                {
                    DataRow drEditCtNew = dtDmTb.NewRow();
                    Common.CopyDataRow(drSelect, drEditCtNew);
                    Common.SetDefaultDataRow(ref drEditCtNew);

                    drEditCtNew["Ma_Nh_Tb"] = strMa_Nh_Tb;
                    drEditCtNew["Ma_Vt"] = drSelect["Ma_Vt"];
                    drEditCtNew["Ten_Vt"] = drSelect["Ten_Vt"];
                    drEditCtNew["Dvt"] = drSelect["Dvt"];

                   
                    dtDmTb.Rows.Add(drEditCtNew);
                    //drEditCtNew.AcceptChanges();

                }

                bdsDmTb.DataSource = dtDmTb;
                dgvDmTb.DataSource = bdsDmTb;
                
            }
        }

        void frmAddList_VTTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {

                for (int i = 0; i < dtDmVt.Rows.Count; i++)
                {
                    dtDmVt.Rows[i]["CHON"] = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.U)
            {

                for (int i = 0; i < dtDmVt.Rows.Count; i++)
                {
                    dtDmVt.Rows[i]["CHON"] = false;
                }
            }
        }
		#endregion

		#region method
        void txtMa_Cum_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Cum.Text.Trim();
            bool bRequire = true;
            string strKeyFilter = "";
            DataRow drLookup = Lookup.ShowLookup("Ma_Cum", strValue, bRequire, strKeyFilter, "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Cum.Text = string.Empty;
                lbtTen_Cum_Tb.Text = string.Empty;
            }
            else
            {
                
                txtMa_Cum.Text = ((string)drLookup["Ma_Cum"]).Trim();
                lbtTen_Cum_Tb.Text = ((string)drLookup["Ten_Cum"]).Trim();
            }
        }
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
            //if (bdsDmVt.Position < 0 && enuNew_Edit == enuEdit.Edit)
            //    return;

            ////Copy dòng hiện tại
            //if (bdsDmVt.Position >= 0)
            //    Common.CopyDataRow(((DataRowView)bdsDmVt.Current).Row, ref drCurrent);
            //else
            //    drCurrent = dtDmVt.NewRow();

            //frmBaoTriCD_Edit frmEdit = new frmBaoTriCD_Edit();
            //frmEdit.Load(enuNew_Edit, drCurrent);

            //if (frmEdit.isAccept)
            //{
            //    if (enuNew_Edit == enuEdit.New)
            //    {
            //        if (bdsDmVt.Position >= 0)
            //            dtDmVt.ImportRow(drCurrent);
            //        else
            //            dtDmVt.Rows.Add(drCurrent);

            //        bdsDmVt.Position = bdsDmVt.Find("Ident00", drCurrent["Ident00"]);
            //    }
            //    else
            //        Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmVt.Current).Row);

            //    dtDmVt.AcceptChanges();
            //}
            //else
            //    dtDmVt.RejectChanges();

		}

		public override void Delete()
		{
			if (bdsDmVt.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsDmVt.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R06BTSC", drCurrent))
			{
				bdsDmVt.RemoveAt(bdsDmVt.Position);
				dtDmVt.AcceptChanges();
			}
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			
		}

      

        //private void btRemove_Click(object sender, EventArgs e)
        //{

        //}

	}
}
