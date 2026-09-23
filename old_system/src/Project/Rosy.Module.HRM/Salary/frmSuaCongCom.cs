using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Control;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using System.Collections;

namespace RosyModule.Salary
{
	public partial class frmSuaCongCom : RosySystem.Customize.frmView
	{
		private DataTable dtDmTn;
		private BindingSource bdsDmTn = new BindingSource();
		private rsDataGridView dgvDmTn = new rsDataGridView();
		private DataRow drCurrent;

        string strMa_Bp; string strMa_Bp_Ct; DateTime dteNgay_Cham_Cong;
        public frmSuaCongCom()
		{
			InitializeComponent();
		}

        public void Load(string strMa_Bp, string strMa_Bp_Ct, DateTime dteNgay_Cham_Cong)
		{
            this.strMa_Bp = strMa_Bp;
            this.strMa_Bp_Ct = strMa_Bp_Ct;
            this.dteNgay_Cham_Cong = dteNgay_Cham_Cong;

			this.Build();
			this.FillData();

            //if (this.isLookup)
				this.ShowDialog();
            //else
            //    this.Show();
		}

		public override void LoadLookup()
		{
			this.Load();
		}

		private void Build()
		{
			dgvDmTn.ReadOnly = true;
            dgvDmTn.strZone = "DSCBNVTHEOCA";
			dgvDmTn.Dock = DockStyle.Fill;

			this.Controls.Add(dgvDmTn);

			dgvDmTn.BuildGridView();
		}

		private void FillData()
		{
            Hashtable ht = new Hashtable();
            ht.Add("MA_BP", strMa_Bp);
            ht.Add("MA_BP_CT", strMa_Bp_Ct);
            ht.Add("NGAY_CHAM_CONG", dteNgay_Cham_Cong);
            dtDmTn = SQLExec.ExecuteReturnDt("sp_GetChamCongCom", ht, CommandType.StoredProcedure);//DataTool.SQLGetDataTable("DSCBNVTHEOCA", null, "", "Stt, Ma_Tn");

			bdsDmTn.DataSource = dtDmTn;
			dgvDmTn.DataSource = bdsDmTn;
		}

		#region EnterProcess

		bool EnterValid()
		{
			if (this.strLookupKeyValid == string.Empty || this.strLookupKeyValid == null)
				return true;

			if (bdsDmTn == null || bdsDmTn.Position < 0)
				return false;

			drCurrent = ((DataRowView)bdsDmTn.Current).Row;
			DataTable dtTemp = dtDmTn.Clone();
			dtTemp.ImportRow(drCurrent);

			if ((dtTemp.Select(this.strLookupKeyValid)).Length == 1)
				return true;
			else
				return false;
		}

		public override void EnterProcess()
		{
			if (bdsDmTn.Position < 0)
				return;

			if (isLookup && EnterValid())
			{
				drLookup = ((DataRowView)bdsDmTn.Current).Row;
				this.Close();
			}
		}

		#endregion 

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (bdsDmTn.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			if (bdsDmTn.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsDmTn.Current).Row, ref drCurrent);
			else
				drCurrent = dtDmTn.NewRow();

            frmSuaCongCom_Edit frmEdit = new frmSuaCongCom_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsDmTn.Position >= 0)
						dtDmTn.ImportRow(drCurrent);
					else
						dtDmTn.Rows.Add(drCurrent);

                    bdsDmTn.Position = bdsDmTn.Find("Ident00", drCurrent["Ident00"]);
				}
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsDmTn.Current).Row);
				}

				dtDmTn.AcceptChanges();
			}
			else
				dtDmTn.RejectChanges();
		}

		public override void Delete()
		{
			if (bdsDmTn.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsDmTn.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

            if (DataTool.SQLDelete("R10DSCBNVTHEOCA", drCurrent))
			{
				bdsDmTn.RemoveAt(bdsDmTn.Position);
				dtDmTn.AcceptChanges();
			}
		}
	}
}
