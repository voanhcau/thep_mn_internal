using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem.Library;
using RosySystem.Public;

namespace RosyModule.Salary
{
	public partial class frmCongTangCa_Edit : RosySystem.Customize.frmEdit
	{
        public frmCongTangCa_Edit()
		{
			InitializeComponent();

			txtMa_Dt_CbNv.Validating += new CancelEventHandler(txtMa_Dt_CbNv_Validating);
            
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

       

		new public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);
            
            //if (enuNew_Edit == enuEdit.New)
            //    dteNgay_Cham_Cong.Text = DateTime.Now.ToString("dd:dd:yyyy");
			
            BindingLanguage();
			LoadDicName();
            LoadCombo();

			this.ShowDialog();
		}
        private void LoadCombo()
        {
            DataTable dtLoaiCC = SQLExec.ExecuteReturnDt("SELECT 'K2' AS Loai_CC, N'Tăng ca 2h' AS Ten_CC" +
                        " UNION ALL SELECT 'K4' AS Loai_CC, N'Tăng ca 4h' AS Ten_CC " +
                        "UNION ALL SELECT 'Ks2' AS Loai_CC, N'Tăng ca 2h ca sáng' AS Ten_CC " +
                        "UNION ALL SELECT 'Ks4' AS Loai_CC, N'Tăng ca 4h ca sáng' AS Ten_CC " +
                        "UNION ALL SELECT 'Kc2' AS Loai_CC, N'Tăng ca 2h ca chiều' AS Ten_CC " +
                        "UNION ALL SELECT 'Kc4' AS Loai_CC, N'Tăng ca 4h ca chiều' AS Ten_CC ");
            cboTrang_Thai.lstItem.BuildListView("Loai_CC:100,Ten_CC:200");
            cboTrang_Thai.lstItem.DataSource = dtLoaiCC;
            cboTrang_Thai.lstItem.Size = new Size(800, cboTrang_Thai.lstItem.Items.Count * 20);
            cboTrang_Thai.lstItem.GridLines = true;
        }
		private void LoadDicName()
		{
            txtMa_Dt_CbNv.bUseAutoDropDown = true;
			if (txtMa_Dt_CbNv.Text != string.Empty)
			{
				
                lbtTen_Dt_CbNv.Text = DataTool.SQLGetNameByCode("R81DMDT", "Ma_Dt", "Ten_Dt", txtMa_Dt_CbNv.Text.Trim());
			}
			else
			{
				lbtTen_Dt_CbNv.Text = string.Empty;
			
			}
           
		}

		private bool CheckFormValid()
		{
            if (this.numSo_Gio.Value == 0)
			{
				Common.MsgCancel(Languages.GetLanguage("So_Gio") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			if (!this.CheckFormValid())
				return false;

            if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
                drEdit["Create_Log"] = Common.GetCurrent_Log();
            else
                drEdit["LastModify_Log"] = Common.GetCurrent_Log();

            if (!DataTool.SQLUpdate(enuNew_Edit, "R10CONGTANGCA", ref drEdit))
				return false;

			return true;
		}

       
		void txtMa_Dt_CbNv_Validating(object sender, CancelEventArgs e)
		{
			if (!txtMa_Dt_CbNv.bTextChange)
				return;

			string strValue = txtMa_Dt_CbNv.Text.Trim();
			bool bRequire = false;

			DataRow drLookup = Lookup.ShowLookup("Ma_Dt_CbNv", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Dt_CbNv.Text = string.Empty;
				lbtTen_Dt_CbNv.Text = string.Empty;
				
			}
			else
			{
				txtMa_Dt_CbNv.Text = drLookup["Ma_Dt"].ToString();
				lbtTen_Dt_CbNv.Text = drLookup["Ten_Dt"].ToString();
			
			}
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}
        protected override void OnShown(EventArgs e)
        {
            if (this.enuNew_Edit == enuEdit.Edit)
            {
                DataTable dt = SQLExec.ExecuteReturnDt("SELECT * FROM R10CONGTANGCA WHERE Ident00 = " + drEdit["Ident00"] + "");
                DataRow dr = dt.Rows[0];
                if ((bool)dr["Duyet_Tp"])
                    this.btgAccept.btAccept.Enabled = false;
            }
        }
	}
}
