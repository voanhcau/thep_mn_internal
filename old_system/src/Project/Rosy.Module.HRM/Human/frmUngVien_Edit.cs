using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;
using RosySystem.Customize;
using RosySystem.Public;
using System.Collections;

namespace RosyModule.HRM
{
	public partial class frmUngVien_Edit : frmEdit
	{
        
        DataTable dtTrinh_Do;
        bool bTD;
		#region Phuong thuc

        public frmUngVien_Edit()
		{
			InitializeComponent();

			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
            txtMa_Bp_Ct.Validating += new CancelEventHandler(txtMa_Bp_Ct_Validating);
		}

        

		public void Load(enuEdit enuNew_Edit, DataRow drEdit, bool bTD)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;
            this.bTD = bTD;

            LoadComboBox();

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

            if (bTD)
            {
                tabControl1.TabPages.Remove(tpThongTinUV);
                txtMa_Dt_CbNv.Text = "M" + SQLExec.ExecuteReturnValue("SELECT MAX(Auto_Number) + 1 FROM R81DMDT WHERE Ma_Nh_Dt = 'NV' AND Ma_Dt LIKE 'M%'").ToString();
            }
            else
                tabControl1.TabPages.Remove(tpKetQuaUV);

			this.ShowDialog();
		}

		private void LoadDicName()
		{
         
        
			
		}
        private void LoadComboBox()
        {

            //Trình độ đào tạo
            dtTrinh_Do = SQLExec.ExecuteReturnDt("SELECT Type_ID, Type_Name FROM R81DMTYPE WHERE Type = 'HRM_TRINH_DO_DT'");
            cboTrinh_Do.DataSource = dtTrinh_Do;
            cboTrinh_Do.DisplayMember = "Tye_ID";
            cboTrinh_Do.ValueMember = "Type_Name";
        }
		public bool FormCheckValid()
		{
			bool bvalid = true;

            if (txtTen_Uv.Text.Trim() == string.Empty)
            {
                Common.MsgOk("Chưa nhập tên ứng viên");
                return false;
            }

           
			return bvalid;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            
			//Luu xuong CSDL
            if (!DataTool.SQLUpdate(enuNew_Edit, "R09DMUV", ref drEdit))
                return false;
            else
            {
                //cập nhật sang hs nhân viên
                if (bTD)
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("MA_UV", drEdit["Ma_Uv"]);
                    ht.Add("MA_DT_CBNV", txtMa_Dt_CbNv.Text);
                    SQLExec.Execute("sp_CreateDtCbNv", ht, CommandType.StoredProcedure);

                    drEdit["Is_TD"] = true;
                }
            }
			return true;
		}
		#endregion

		#region Su kien
		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				isAccept = true;
				this.Close();
			}
		}
		void btCancel_Click(object sender, EventArgs e)
		{
			isAccept = false;
			this.Close();
		}

        void txtMa_Bp_Ct_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp_Ct.Text.Trim();
            bool bRequi = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp_Ct", strValue, bRequi, "Ma_Bp = '" + txtMa_Bp.Text + "' AND Nh_Cuoi = 1");

            if (bRequi && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp_Ct.Text = string.Empty;
                lbtTen_Bp_Ct.Text = string.Empty;
            }
            else
            {
                txtMa_Bp_Ct.Text = (string)drLookup["Ma_Bp_Ct"];
                lbtTen_Bp_Ct.Text = (string)drLookup["Ten_Bp_Ct"];
            }
        }

        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequi = true;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequi, string.Empty);

            if (bRequi && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
            }
            else
            {
                txtMa_Bp.Text = (string)drLookup["Ma_Bp"];
                lbtTen_Bp.Text = (string)drLookup["Ten_Bp"];
            }
        }
		#endregion
	}
}
