using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RosySystem;
using RosySystem.Common;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem.Public;
using RosyList;

namespace RosyModule.Costing
{
	public partial class frmZDinhMuc_Copy : RosySystem.Customize.frmEdit
	{
		#region Methods

		public frmZDinhMuc_Copy()
		{
			InitializeComponent();

			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtMa_Vt_Sp_Source.Validating += new CancelEventHandler(txtMa_Vt_Sp_Source_Validating);
			txtMa_Vt_Sp_Dest.Validating += new CancelEventHandler(txtMa_Vt_Sp_Dest_Validating);
		}

		new public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			txtMa_Vt_Sp_Source.Text = drEdit["Ma_Vt_Sp"].ToString();

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (txtMa_Vt_Sp_Source.Text != string.Empty)
			{
				lbtTen_Vt_Sp_Source.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp_Source.Text);
			}
			else
				lbtTen_Vt_Sp_Source.Text = string.Empty;

			if (txtMa_Vt_Sp_Dest.Text != string.Empty)
			{
				lbtTen_Vt_Sp_Dest.Text = DataTool.SQLGetNameByCode("R81DmVt", "Ma_Vt", "Ten_Vt", txtMa_Vt_Sp_Dest.Text);
			}
			else
				lbtTen_Vt_Sp_Dest.Text = string.Empty;
		}

		private bool CheckFormValid()
		{
			if (this.txtMa_Vt_Sp_Source.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt_Sp_Source") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			if (this.txtMa_Vt_Sp_Dest.Text == string.Empty)
			{
				Common.MsgCancel(Languages.GetLanguage("Ma_Vt_Sp_Dest") + " " + Languages.GetLanguage("Not_Empty"));
				return false;
			}

			return true;
		}

		private bool Save()
		{
			if (!this.CheckFormValid())
				return false;

			//Luu xuong CSDL
			string strSQL = "";

			if (chkCopyDmVt.Checked)
			{
				strSQL += @"--DELETE FROM R07zDinhMucVT WHERE Ma_Vt_Sp = '" + txtMa_Vt_Sp_Dest.Text + @"' --Không Xóa trên Mã Dest, trường hợp Copy cho chính nó
							INSERT INTO R07zDinhMucVT (Ma_Vt_Sp, So_Luong_Sp, Ma_Vt, So_Luong, Ty_Le_HH, Ngay_Ap, Ngay_End)
								SELECT '" + txtMa_Vt_Sp_Dest.Text + @"' AS Ma_Vt_Sp, So_Luong_SP, Ma_Vt, So_Luong, Ty_Le_HH, " + (!dteNgay_Ap.IsNull ? "'" + dteNgay_Ap.Text + "'" : "") + @" Ngay_Ap, Ngay_End 
									FROM R07zDinhMucVT 
									WHERE Ma_Vt_Sp = '" + txtMa_Vt_Sp_Source.Text + "' ";
			}

			if (chkCopyDmYt.Checked)
			{
				strSQL += @"--DELETE FROM R07zDinhMucYT WHERE Ma_Vt_Sp = '" + txtMa_Vt_Sp_Dest.Text + @"' --Không Xóa trên Mã Dest, trường hợp Copy cho chính nó
							INSERT INTO R07zDinhMucYT (Ma_Vt_Sp, So_Luong_Sp, Ma_Yt, He_So, Ngay_Ap, Ngay_End)
								SELECT '" + txtMa_Vt_Sp_Dest.Text + @"' AS Ma_Vt_Sp, So_Luong_SP, Ma_Yt, He_So, " + (!dteNgay_Ap.IsNull ? "'" + dteNgay_Ap.Text + "'" : "") + @" Ngay_Ap, Ngay_End 
									FROM R07zDinhMucYT 
									WHERE Ma_Vt_Sp = '" + txtMa_Vt_Sp_Source.Text + "'";
			}

			if (!SQLExec.Execute(strSQL))
			{
				return false;
			}

			return true;
		}

		#endregion

		#region Events

		void txtMa_Vt_Sp_Source_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp_Source.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp_Source.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp_Source.Text = drLookup["Ma_Vt"].ToString();
			}
		}

		void txtMa_Vt_Sp_Dest_Validating(object sender, CancelEventArgs e)
		{
			string strValue = txtMa_Vt_Sp_Dest.Text.Trim();
			bool bRequire = true;

			DataRow drLookup = Lookup.ShowLookup("Ma_Vt_Sp", strValue, bRequire, "");

			if (bRequire && drLookup == null)
				e.Cancel = true;

			if (drLookup == null)
			{
				txtMa_Vt_Sp_Dest.Text = string.Empty;
			}
			else
			{
				txtMa_Vt_Sp_Dest.Text = drLookup["Ma_Vt"].ToString();
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
			this.Close();
		}

		#endregion


	}
}
