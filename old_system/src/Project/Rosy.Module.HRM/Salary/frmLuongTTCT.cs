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
using RosySystem.Element;

namespace RosyModule.Salary
{
	public partial class frmLuongTTCT : RosySystem.Customize.frmView
	{
        private DataSet dsDGBPCT;
      
		private DataTable dtDGBPCT;
		private BindingSource bdsDGBPCT = new BindingSource();
		


      
        private DataRow drCurrent;
        private string strMa_Dt_CbNv = string.Empty;

        DataSet dsBp; DataTable dtDmBp; DataTable dtDmBpCt;

 

        public frmLuongTTCT()
		{
			InitializeComponent();

           
            
            
            //btThoat.Click += new EventHandler(btThoat_Click);
           
		}

        
      
      
        void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


     

       

		public override void Load()
		{
           
			this.Build();
			this.FillData();
         
            //LoadCombo();


			if (this.isLookup)
				this.ShowDialog();
			else
				this.Show();
		}

        public void Load(string strMa_Dt_CbNv)
        {
            this.strMa_Dt_CbNv = strMa_Dt_CbNv;
            this.Build();
            this.FillData();
         
           


            if (this.isLookup)
                this.ShowDialog();
            else
                this.Show();
        }
		private void Build()
		{
            
            

            dgvDGBPCT.ReadOnly = true;
            dgvDGBPCT.strZone = "LUONGTT";
            dgvDGBPCT.Dock = DockStyle.Fill;


            dgvDGBPCT.BuildGridView();
           

     
           
		}
       
		private void FillData()
		{
            Hashtable htPara = new Hashtable();


            htPara.Add("MA_BP", "*");
            htPara.Add("MA_DT_CBNV", strMa_Dt_CbNv);
            htPara.Add("MA_DVCS", Element.sysMa_DvCs);

            dtDGBPCT = SQLExec.ExecuteReturnDt("sp_HRM_GetLuongTT", htPara, CommandType.StoredProcedure);

            bdsDGBPCT.DataSource = dtDGBPCT;
            dgvDGBPCT.DataSource = bdsDGBPCT;

            bdsSearch = bdsDGBPCT;
            this.ExportControl = dgvDGBPCT;
		}

		public override void Edit(enuEdit enuNew_Edit)
		{
            //return;
			
            
		}

		public override void Delete()
		{
			
		}

     
       
	}
}
