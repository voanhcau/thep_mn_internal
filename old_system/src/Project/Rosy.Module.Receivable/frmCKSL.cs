using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem;
using RosySystem.Data;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Control;
using RosySystem.Element;
using RosySystem.Public;

namespace RosyModule.Receivable
{
	public partial class frmCKSL : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		object objActive = null;

		private DataTable dtCKSL;
		private DataTable dtCKSLCT;

		private BindingSource bdsCKSL = new BindingSource();
		private BindingSource bdsCKSLCT = new BindingSource();
	
		private DataRow drCurrent;

			
		DataRow Row;

		#endregion

		#region Contructor

		public frmCKSL()
		{
			InitializeComponent();

			
			//bdsCKSL.PositionChanged += new EventHandler(bdsCKSL_PositionChanged);
			bdsCKSL.CurrentChanged += new EventHandler(bdsCKSL_CurrentChanged);
			
			this.KeyDown += new KeyEventHandler(frmCtTs_KeyDown);

			this.btNew.Click += new EventHandler(btNew_Click);
			this.btEdit.Click += new EventHandler(btEdit_Click);
			this.btDelete.Click += new EventHandler(btDelete_Click);
			


			this.dgvCKSL.Enter +=new EventHandler(dgvCtTs_Enter);
			this.dgvCKSLCT.Enter += new EventHandler(dgvCtTsHM_Enter);
		
		}

		

		public void Load()
		{
			

			this.Build();

			this.FillData();

			this.BindingLanguage();

			this.Show();
		}

		#endregion

		#region Method

		private void Build()
		{
			dgvCKSL.strZone = "CKSL"; 
			dgvCKSL.BuildGridView();

            dgvCKSLCT.strZone = "CKSLCT"; 
			dgvCKSLCT.BuildGridView();

		
		}

		private void FillData()
		{
            Hashtable ht = new Hashtable();
            ht.Add("MA_DATA", Element.sysMa_Data);

            DataSet dsCtTs = SQLExec.ExecuteReturnDs("sp_GetCKSL", ht, CommandType.StoredProcedure);

			dtCKSL = dsCtTs.Tables[0];
			bdsCKSL.DataSource = dtCKSL;
			dgvCKSL.DataSource = bdsCKSL;

			dtCKSLCT = dsCtTs.Tables[1];
			bdsCKSLCT.DataSource = dtCKSLCT;
			dgvCKSLCT.DataSource = bdsCKSLCT;

			bdsSearch = bdsCKSL;
		}

		

		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (this.objActive == dgvCKSLCT)
				this.Edit_CtTsHM(enuNew_Edit);
			else
				this.Edit_CtTs(enuNew_Edit);
		}

		private void Edit_CtTs(enuEdit enuNew_Edit)
		{
			if (bdsCKSL.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsCKSL.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCKSL.Current).Row, ref drCurrent);
			else
			{
				drCurrent = dtCKSL.NewRow();
			}

            ////Tăng Stt tạm thời, để trường hợp kế thừa dữ liệu OK
            //if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
            //{
            //    drCurrent["So_Qd_Ck"] = Common.GetNewStt("06", false);
            //}

			frmCKSL_Edit frmEdit = new frmCKSL_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
					if (bdsCKSL.Position >= 0)
						dtCKSL.ImportRow(drCurrent);
					else
						dtCKSL.Rows.Add(drCurrent);
				else
				{
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsCKSL.Current).Row);
				}

				dtCKSL.AcceptChanges();

                ////Đổi Ma_Vt_Ts
                //if (enuNew_Edit == enuEdit.Edit && drCurrent.HasVersion(DataRowVersion.Original) && drCurrent["Ma_Vt_Ts"] != drCurrent["Ma_Vt_Ts", DataRowVersion.Original])
                //{
                //    foreach (DataRow dr in dtCKSLCT.Select("Stt = '" + drCurrent["Stt"].ToString() + "'")) { dr["Ma_Vt_Ts"] = drCurrent["Ma_Vt_Ts"]; }
					
                //}

				if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                    bdsCKSL.Position = bdsCKSL.Find("So_Qd_Ck", drCurrent["So_Qd_Ck"]);
			}
			else
				dtCKSL.RejectChanges();
		}

		private void Edit_CtTsHM(enuEdit enuNew_Edit)
		{
			if (bdsCKSL.Position < 0 && bdsCKSLCT.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			DataRow drCtTs = ((DataRowView)(bdsCKSL.Current)).Row;

			//Copy hang hien tai            
			if (bdsCKSLCT.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsCKSLCT.Current).Row, ref drCurrent);
			else
				drCurrent = dtCKSLCT.NewRow();

			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
                drCurrent["So_Qd_Ck"] = drCtTs["So_Qd_Ck"];
                //drCurrent["Ma_Vt"] = drCtTs["Ma_Vt"];
			}

			frmCKSLCT_Edit frmEdit = new frmCKSLCT_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
                if (enuNew_Edit == enuEdit.New)
                {
                    DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DMVT", "Ma_Vt", drCurrent["Ma_Vt"].ToString());
                    drCurrent["Ten_Vt"] = drDmVt["Ten_Vt"];
                    if (bdsCKSLCT.Position >= 0)
                        dtCKSLCT.ImportRow(drCurrent);
                    else
                        dtCKSLCT.Rows.Add(drCurrent);
                }
                else
                {
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsCKSLCT.Current).Row);
                }

				dtCKSLCT.AcceptChanges();
			}
			else
				dtCKSLCT.RejectChanges();
		}

		

		public override void Delete()
		{
			if (this.objActive == dgvCKSLCT)
				this.Delete_CtTsHM();
			else
				this.Delete_CtTs();
		}

		private void Delete_CtTs()
		{
			if (bdsCKSL.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCKSL.Current).Row;

			//if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
			if (!Common.MsgYes_No("Dữ liệu của chi tiết chiết khấu sản lượng này cũng bị xoá trên bảng chi tiết Bạn có chắc xoá không ? "))
				return;

			string _Stt_del = drCurrent["So_Qd_Ck"].ToString().Trim();

			Hashtable ht = new Hashtable();
			ht.Add("SO_QD_CK", _Stt_del);

            SQLExec.Execute("Sp_Delete_CKSL", ht, CommandType.StoredProcedure);

			bdsCKSL.RemoveAt(bdsCKSL.Position);
			dtCKSL.AcceptChanges();

			for (int i = 0; i < dtCKSLCT.Rows.Count; i++)
			{
				Row = dtCKSLCT.Rows[i];
                if (Row["So_Qd_Ck"].ToString().Trim() == _Stt_del)
					dtCKSLCT.Rows.Remove(Row);
			}			
		}

		private void Delete_CtTsHM()
		{
			if (bdsCKSLCT.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsCKSLCT.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R04CKSLCT", drCurrent))
			{
				bdsCKSLCT.RemoveAt(bdsCKSLCT.Position);
				dtCKSLCT.AcceptChanges();
			}
		}

		
		#endregion

		#region Su kien

		void bdsCKSL_CurrentChanged(object sender, EventArgs e)
		{
			if (bdsCKSL.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsCKSL.Current).Row;

            bdsCKSLCT.Filter = "So_Qd_Ck = '" + drCurrent["So_Qd_Ck"].ToString() + "'";
		}
		void bdsCKSL_PositionChanged(object sender, EventArgs e)
		{
			if (bdsCKSL.Position < 0)
				return;

			drCurrent = ((DataRowView)bdsCKSL.Current).Row;

            bdsCKSLCT.Filter = "So_Qd_Ck = '" + drCurrent["So_Qd_Ck"].ToString() + "'";
		}

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

        //void btFilter_Click(object sender, EventArgs e)
        //{
        //    this.Filter();
        //}

		void dgvCtTs_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
			objActive = dgvCKSL;
		}

		void dgvCtTsHM_Enter(object sender, EventArgs e)
		{
			ExportControl = sender;
			objActive = dgvCKSLCT;
		}

		
		void frmCtTs_KeyDown(object sender, KeyEventArgs e)
		{
            //if (e.KeyCode == Keys.F9 && !e.Control && !e.Shift && !e.Alt)
            //    this.Filter();
		}

		#endregion
	}
}