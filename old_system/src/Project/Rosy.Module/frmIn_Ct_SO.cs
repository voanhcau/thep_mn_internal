using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;

namespace RosyModule
{
	public partial class frmIn_Ct_SO : RosySystem.Customize.frmEdit
	{
		public frmIn_Ct_SO()
		{
			InitializeComponent();
			btgAccept.btAccept.Click+=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click +=new EventHandler(btCancel_Click);			
		}

		public void Load(DataRow drViewPh)
		{
			this.drEdit = drViewPh;

			Common.ScaterMemvar(this, ref drViewPh);

          
			BindingLanguage();
			LoadDicName();

            
            DataRow drCt = DataTool.SQLGetDataRowByID("R04CTSO", "Stt", (string)drViewPh["Stt"]);
            string MemberGroupID = (string)SQLExec.ExecuteReturnValue("SELECT MIN(Member_Group_ID) FROM R00MEMBERGROUP WHERE Member_Id = '" + Element.sysUser_Id + "'");
            bool Is_Tp = Common.CheckPermission("IS_TP", enuPermission_Type.Allow_Access);
            
            if(!Element.sysIs_Admin)
            {
                if (drViewPh["Ma_Ct"].ToString() == "SOCP" && !Is_Tp && MemberGroupID == "PKD")
                {
                    rdbLXH.Checked = true;
                    rdbLXH.Enabled = true;
                    //rdbLXH_KG.Enabled = true;
                    rdbLXH_GH.Visible = false;
                }
                else if (drViewPh["Ma_Ct"].ToString() == "SOCP" && !Is_Tp && MemberGroupID != "PKD")
                {
                    rdbLXH_GH.Checked = true;
                    rdbLXH.Enabled = false;
                    //rdbLXH_KG.Enabled = false;
                    rdbLXH_GH.Visible = true;
                }
                else if (drViewPh["Ma_Ct"].ToString() == "SO")
                    rdbLXH_GH.Visible = false;
            }
			this.ShowDialog();
		}
       
		private void LoadDicName()
		{
		}

      
		private void btAccept_Click(object sender, EventArgs e)
		{
            
                isAccept = true;
                this.Close();
         }

		private void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}
      
	}
}
