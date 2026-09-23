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

namespace RosyModule.Payable
{
	public partial class frmDmTHTX_Edit : RosySystem.Customize.frmEdit
	{
		#region Methods

        public frmDmTHTX_Edit()
		{
			InitializeComponent();

			txtMa_Vt.Validating += new CancelEventHandler(txtMa_Vt_Validating);
            txtMa_Bp.Validating += new CancelEventHandler(txtMa_Bp_Validating);
			
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

       

		public void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.enuNew_Edit = enuNew_Edit;
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

            txtMa_Vt.bUseAutoDropDown = true;
            txtMa_Bp.bUseAutoDropDown = true; 

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Vt.Text.Trim() != string.Empty)
			{
				DataRow drDmVt = DataTool.SQLGetDataRowByID("R81DmVt", "Ma_Vt", txtMa_Vt.Text.Trim());

				if (drDmVt != null)
				{
					lbtTen_Vt.Text = (string)drDmVt["Ten_Vt"];
					lbtDvt.Text = "/" + (string)drDmVt["Dvt"];
				}
			}
			else
			{
				lbtTen_Vt.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}

            if (txtMa_Bp.Text.Trim() != string.Empty)
            {
                lbtTen_Bp.Text = DataTool.SQLGetNameByCode("R81DMBP", "Ma_Bp", "Ten_Bp", txtMa_Bp.Text);
            }

            if (Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit) && !Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New))
            {
                numDinh_Muc.ReadOnly = true;
                txtMa_Vt.ReadOnly = true;
                txtMa_Bp.ReadOnly = true;
            }
		}

		public bool FormCheckValid()
		{
			
			if (txtMa_Vt.Text.Trim() == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt") + " " + Languages.GetLanguage("Cannot_Empty"));
				return false;
			}
            if (numDinh_Muc.Value == 0)
            {
                Common.MsgCancel(Languages.GetLanguage("Dinh_Muc") + " " + Languages.GetLanguage("Cannot_Empty"));
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

			if (drEdit.Table.Columns.Contains("Ten_Vt"))
				drEdit["Ten_Vt"] = lbtTen_Vt.Text;

			//Kiem tra cac du lieu can thiet
			drEdit["Ma_DvCs"] = Element.sysMa_DvCs;
			if (enuNew_Edit == enuEdit.New)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
            return DataTool.SQLUpdate(enuNew_Edit, "R81DMVTTHTX", ref drEdit);
		}

		#endregion

		#region Events
        void txtMa_Bp_Validating(object sender, CancelEventArgs e)
        {
            string strValue = txtMa_Bp.Text.Trim();
            bool bRequire = false;

            DataRow drLookup = Lookup.ShowLookup("Ma_Bp", strValue, bRequire, "", "");

            if (bRequire && drLookup == null)
                e.Cancel = true;

            if (drLookup == null)
            {
                txtMa_Bp.Text = string.Empty;
                lbtTen_Bp.Text = string.Empty;
                
            }
            else
            {
                txtMa_Bp.Text = drLookup["Ma_Bp"].ToString();
                lbtTen_Bp.Text = drLookup["Ten_Bp"].ToString();
            }
        }

		void txtMa_Vt_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt", strValue, bRequire, "", "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt.Text = string.Empty;
				lbtTen_Vt.Text = string.Empty;
				lbtDvt.Text = string.Empty;
			}
			else
			{
				txtMa_Vt.Text = drLookup["Ma_Vt"].ToString();
				lbtTen_Vt.Text = drLookup["Ten_Vt"].ToString();
				lbtDvt.Text = "/" + drLookup["Dvt"].ToString();
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

            switch (this.enuNew_Edit)
            {
                case enuEdit.New:
                    this.btgAccept.btAccept.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_New);
                    break;
                case enuEdit.Edit:
                    this.btgAccept.btAccept.Enabled = Common.CheckPermission(this.Object_ID, enuPermission_Type.Allow_Edit);
                    break;
                default:
                    break;
            }

            if (enuNew_Edit == enuEdit.Edit)
                lblLog.Text = "Create: " + Common.Show_Log((string)drEdit["Create_Log"]) + "; LastModify: " + Common.Show_Log((string)drEdit["LastModify_Log"]);
            else
                lblLog.Text = "";
		}
	}
}
