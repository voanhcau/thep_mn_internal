using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Data;
using RosySystem.Element;
using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Common;
using RosySystem.Public;

namespace RosyModule.Receivable
{
	public partial class frmDmDMKG_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

        public frmDmDMKG_Edit()
		{
			InitializeComponent();

			txtMa_Kho.Validating += new CancelEventHandler(txtMa_Kho_Validating);
            txtGrade_ID.Validating += new CancelEventHandler(txtGrade_ID_Validating);
			
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

       

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

            txtMa_Kho.bUseAutoDropDown = true;
            txtGrade_ID.bUseAutoDropDown = true; 

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Kho.Text.Trim() != string.Empty)
			{
                //DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", txtMa_Kho.Text.Trim());

                //if (drDmVt != null)
                //{
                //    lbtTen_Kho.Text = (string)drDmVt["Ten_Vt"];
                //    lbtDvt.Text = "/" + (string)drDmVt["Dvt"];
                //}
			}
			else
			{
				lbtTen_Kho.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}

            if (txtGrade_ID.Text.Trim() != string.Empty)
            {
                lbtGrade_Name.Text = DataTool.SQLGetNameByCode("R81DMMACTHEP", "Grade_ID", "Grade_Name", txtGrade_ID.Text);
            }
		}

		public bool FormCheckValid()
		{
			
			if (txtMa_Kho.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Kho") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}
            if (numSo_Luong.Value == 0)
            {
                Common.MsgCancel(Languages.GetLanguage("So_Luong") + " " + Languages.GetLanguage("Cannot_Empty"));
                return false;
            }
			return true;
		}

		public bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

            if (drEdit.Table.Columns.Contains("Ten_Kho"))
                drEdit["Ten_Kho"] = lbtTen_Kho.Text;

            if (drEdit.Table.Columns.Contains("Grade_Name"))
                drEdit["Grade_Name"] = lbtGrade_Name.Text;

			//Kiem tra cac du lieu can thiet
			drEdit["Ma_Data"] = Element.sysMa_DvCs;
			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
            return DataTool.SQLUpdate(enuNew_Edit, "R81DMDMKYGUI", ref drEdit);
		}

		#endregion

		#region Events
        void txtGrade_ID_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtGrade_ID.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Grade_ID", strValue, bRequire, string.Empty);
            if (drLookup == null && bRequire)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtGrade_ID.Text = string.Empty;
                lbtGrade_Name.Text = string.Empty;
            }
            else
            {
                txtGrade_ID.Text = (string)drLookup["Grade_ID"];
                lbtGrade_Name.Text = (string)drLookup["Grade_Name"];
            }
            
        }

		void txtMa_Kho_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Kho.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Kho", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Kho.Text = string.Empty;
				lbtTen_Kho.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}
			else
			{
				txtMa_Kho.Text = drLookup["Ma_Kho"].ToString();
				lbtTen_Kho.Text = drLookup["Ten_Kho"].ToString();
				
			}
		}

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
			this.isAccept = false;
			this.Close();
		}

		#endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

            if (enuNew_Edit == enuEdit.Edit)
                lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
            else
                lblLog.Text = "";
		}
	}
}
