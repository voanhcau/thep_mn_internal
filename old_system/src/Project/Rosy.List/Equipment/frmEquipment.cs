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
using RosySystem.Customize;

namespace RosyList
{
	public partial class frmEquipment : RosySystem.Customize.frmView
	{
		#region Khai bao bien

		private DataTable dtEquipment;
		private DataTable dtEquipmentInfo;
        private DataTable dtEquipCt;
		private DataRow drCurrent;
		
		private BindingSource bdsEquipment = new BindingSource();
		private BindingSource bdsEquipmentInfo = new BindingSource();
        private BindingSource bdsEquipCt = new BindingSource();
        public string strLoai_Can = string.Empty;
		#endregion

		#region Contructor

		public frmEquipment()
		{
			InitializeComponent();

			bdsEquipment.PositionChanged += new EventHandler(bdsEquipment_PositionChanged);
            dgvEquipmentInfo.CellValidated += new DataGridViewCellEventHandler(dgvEquipmentInfo_CellValidated);
		}

        
        public void Load(string strLoai_Can)
        {
            this.strLoai_Can = strLoai_Can;
            Build();
            FillData();
            BindingLanguage();

            this.Show();
        }
        //public override void Load()
        //{
           
        //    Build();
        //    FillData();
        //    BindingLanguage();

        //    this.Show();
        //}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			Zones.FillZones();
		}

		#endregion

		#region Build, FillData
		private void Build()
		{
			//Equipment
			dgvEquipment.strZone = "EQUIPMENT";
			dgvEquipment.BuildGridView();

			//EquipmentInfo
			dgvEquipmentInfo.strZone = "EQUIPMENTINFO";
			dgvEquipmentInfo.BuildGridView();

            //EquipmentInfo
            dgvEquipCt.strZone = "EQUIPMENTINFOCT";
            dgvEquipCt.BuildGridView();

            dgvEquipmentInfo.ReadOnly = true;
            dgvEquipCt.ReadOnly = true;

          
		}

		private void FillData()
		{
            string strKey = "Loai_Can = '" + strLoai_Can + "'";
            
            if(!Element.sysIs_Admin)
                strKey += " AND Host_IP = '" + MachineInfo.GetHostIP()  + "'";
            
            dtEquipment = DataTool.SQLGetDataTable("R81EQUIPMENT", "*", strKey, "Host_IP");
            
			dtEquipmentInfo = DataTool.SQLGetDataTable("R81EQUIPMENTINFO", "*", null, "Host_IP");

            dtEquipCt = DataTool.SQLGetDataTable("R81EQUIPMENTINFOCT", "*", null, "Host_IP");

			bdsEquipment.DataSource = dtEquipment;
			bdsEquipmentInfo.DataSource = dtEquipmentInfo;
            bdsEquipCt.DataSource = dtEquipCt;

			dgvEquipment.DataSource = bdsEquipment;
			bdsEquipment.Position = 0;
			dgvEquipmentInfo.DataSource = bdsEquipmentInfo;
            dgvEquipCt.DataSource = bdsEquipCt;


			//Uy quyen cho lop co so tim kiem           
			bdsSearch = bdsEquipment;
			ExportControl = dgvEquipment;
		}
		
		#endregion

		#region Update

		public override void Edit(enuEdit enuNew_Edit)
		{
			if (dgvEquipmentInfo.Focused)
			{
				Edit_EquipmentInfo(enuNew_Edit);
				return;
			}
            else if (dgvEquipCt.Focused)
            {
                Edit_EquipmentCt(enuNew_Edit);
                return;
            }

			if (bdsEquipment.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsEquipment.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsEquipment.Current).Row, ref drCurrent);
			else
				drCurrent = dtEquipment.NewRow();

			frmEquipment_Edit frmEdit = new frmEquipment_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsEquipment.Position >= 0)
						dtEquipment.ImportRow(drCurrent);
					else
						dtEquipment.Rows.Add(drCurrent);

					bdsEquipment.Position = bdsEquipment.Find("HOST_IP", drCurrent["HOST_IP"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsEquipment.Current).Row);

				dtEquipment.AcceptChanges();
			}
			else
				dtEquipment.RejectChanges();
		}

		public void Edit_EquipmentInfo(enuEdit enuNew_Edit)
		{
			if (bdsEquipmentInfo.Position < 0 && enuNew_Edit == enuEdit.Edit)
				return;

			//Copy hang hien tai            
			if (bdsEquipmentInfo.Position >= 0)
				Common.CopyDataRow(((DataRowView)bdsEquipmentInfo.Current).Row, ref drCurrent);
			else
				drCurrent = dtEquipmentInfo.NewRow();

			string strHost_IP = (string)((DataRowView)bdsEquipment.Current).Row["Host_IP"];
			drCurrent["Host_IP"] = strHost_IP;

			frmEquipmentInfo_Edit frmEdit = new frmEquipmentInfo_Edit();
			frmEdit.Load(enuNew_Edit, drCurrent);

			// người dùng chọn chấp nhận
			if (frmEdit.isAccept)
			{
				if (enuNew_Edit == enuEdit.New)
				{
					if (bdsEquipmentInfo.Position >= 0)
						dtEquipmentInfo.ImportRow(drCurrent);
					else
						dtEquipmentInfo.Rows.Add(drCurrent);

					bdsEquipmentInfo.Position = bdsEquipmentInfo.Find("IDENT00", drCurrent["IDENT00"]);
				}
				else
					Common.CopyDataRow(drCurrent, ((DataRowView)bdsEquipmentInfo.Current).Row);

				dtEquipmentInfo.AcceptChanges();
			}
			else
				dtEquipmentInfo.RejectChanges();
		}
        public void Edit_EquipmentCt(enuEdit enuNew_Edit)
        {
            if (bdsEquipCt.Position < 0 && enuNew_Edit == enuEdit.Edit)
                return;

            //Copy hang hien tai            
            if (bdsEquipCt.Position >= 0)
                Common.CopyDataRow(((DataRowView)bdsEquipCt.Current).Row, ref drCurrent);
            else
                drCurrent = dtEquipCt.NewRow();

            string strHost_IP = (string)((DataRowView)bdsEquipment.Current).Row["Host_IP"];
            drCurrent["Host_IP"] = strHost_IP;

            frmEquipmentCt_Edit frmEdit = new frmEquipmentCt_Edit();
            frmEdit.Load(enuNew_Edit, drCurrent);

            // người dùng chọn chấp nhận
            if (frmEdit.isAccept)
            {
                if (enuNew_Edit == enuEdit.New)
                {
                    if (bdsEquipCt.Position >= 0)
                        dtEquipCt.ImportRow(drCurrent);
                    else
                        dtEquipCt.Rows.Add(drCurrent);

                    bdsEquipCt.Position = bdsEquipCt.Find("IDENT00", drCurrent["IDENT00"]);
                }
                else
                    Common.CopyDataRow(drCurrent, ((DataRowView)bdsEquipCt.Current).Row);

                dtEquipCt.AcceptChanges();
            }
            else
                dtEquipCt.RejectChanges();
        }

		public override void Delete()
		{
			if (dgvEquipmentInfo.Focused)
			{
				Delete_EquipmentInfo();
				return;
			}

			if (bdsEquipment.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsEquipment.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;				
			
			if (DataTool.SQLDelete("R81EQUIPMENT", drCurrent))
			{
				bdsEquipment.RemoveAt(bdsEquipment.Position);
				dtEquipment.AcceptChanges();
			}
		}

		public void Delete_EquipmentInfo()
		{
			if (bdsEquipmentInfo.Position < 0)
				return;

			DataRow drCurrent = ((DataRowView)bdsEquipmentInfo.Current).Row;

			if (!Common.MsgYes_No(Languages.GetLanguage("SURE_DELETE")))
				return;

			if (DataTool.SQLDelete("R81EQUIPMENTINFO", drCurrent))
			{
				bdsEquipmentInfo.RemoveAt(bdsEquipmentInfo.Position);
				dtEquipmentInfo.AcceptChanges();
			}
		}

		#endregion
		
		#region Su kien

		void bdsEquipment_PositionChanged(object sender, EventArgs e)
		{
			string strHost_IP = (string)((DataRowView)bdsEquipment.Current).Row["Host_IP"];

			bdsEquipmentInfo.Filter = "Host_IP = '" + strHost_IP + "'";
            bdsEquipCt.Filter = "Host_IP = '" + strHost_IP + "'";
		}
        void dgvEquipmentInfo_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            drCurrent = ((DataRowView)bdsEquipmentInfo.Current).Row;

            string strColumnName = dgvEquipmentInfo.Columns[e.ColumnIndex].Name;

          
        }

		#endregion
	}
}