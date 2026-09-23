using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem;

namespace RosyModule.Salary
{
	public partial class frmSuaDLChamCong : RosySystem.Customize.frmView
	{
		public DataSet dsChamCong;
		BindingSource bdsChamCong = new BindingSource();
        BindingSource bdsChamCongCt = new BindingSource();

		DataRow drEdit;

		string strMa_Dt_CbNv = string.Empty;
		DateTime dtNgayCt;//=DateTime.Now;
       
		DataRow drCurrent, drDmCt_Current;

        public frmSuaDLChamCong()
		{
			InitializeComponent();

            //this.rsTabControl1.SelectedIndexChanged += new EventHandler(rsTabControl1_SelectedIndexChanged);
            this.bdsChamCong.PositionChanged += new EventHandler(bdsChamCong_PositionChanged);

            this.btEdit.Click += new EventHandler(btEdit_Click);
		
			this.btExit.Click += new EventHandler(btExit_Click);
		}

        
        
		public void Load(string strMa_Dt_CbNv, DateTime dteNgay_Ct)
		{
            //this.drEdit = drEdit;
			this.strMa_Dt_CbNv = strMa_Dt_CbNv;

            this.dtNgayCt = dteNgay_Ct;
         
			Build();
            FillData();
			BindingLanguage();
            //Common.ScaterMemvar(this, ref drEdit);
		    this.ShowDialog();
		}


		private void Build()
		{
		
			//dgvViewPh 
			dgvChamCong.ReadOnly = true;
            dgvChamCong.strZone = "CHAMCONG";
            dgvChamCong.BuildGridView(false);


            dgvChamCongCt.ReadOnly = true;
            dgvChamCongCt.strZone = "CHAMCONGCT1";
            dgvChamCongCt.BuildGridView(false);
		
		}

		void FillData()
		{
            Hashtable ht = new Hashtable();

            ht.Add("MA_DT_CBNV",strMa_Dt_CbNv);
            ht.Add("NGAY_CT", dtNgayCt);
            

            dsChamCong = SQLExec.ExecuteReturnDs("sp_GetChamCongChinhSua", ht, CommandType.StoredProcedure);

            bdsChamCong.DataSource = dsChamCong.Tables[0];
            dgvChamCong.DataSource = bdsChamCong;


            bdsChamCongCt.DataSource = dsChamCong.Tables[1];
            dgvChamCongCt.DataSource = bdsChamCongCt;
		}


		private bool FormCheckValid()
		{
			//if (dteNgay_Ct.IsNull)
			//{
			//    Common.MsgCancel(Languages.GetLanguage("Ngay_Ct,Not_Null"));
			//    return false;
			//}

			return true;
		}

       
		

        
        void btEdit_Click(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsChamCongCt.Current).Row;

            frmDCChamCong_Edit frm = new frmDCChamCong_Edit();
            frm.Load(enuEdit.Edit, drCurrent);
        }
        void bdsChamCong_PositionChanged(object sender, EventArgs e)
        {
            drCurrent = ((DataRowView)bdsChamCong.Current).Row;
            bdsChamCongCt.Filter = "Ngay_Cham_Cong = '"+drCurrent["Ngay_Cham_Cong"]+"'";
        }

		void btExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			
		}
	}
}
