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
using RosySystem.Customize;
using RosySystem.Common;
using RosySystem.Library;

namespace RosyModule.CRM
{
	public partial class frmFinish : RosySystem.Customize.frmEdit
	{
		public frmFinish()
		{
			InitializeComponent();

			btgAccept.btAccept.Click +=new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);

			txtNgay_Dk_Ht.Validated += new EventHandler(txtNgay_Dk_Ht_Validated);
			txtNgay_Ht.Validated += new EventHandler(txtNgay_Ht_Validated);
			numSo_Ngay_Dk_Ht.Validated += new EventHandler(numSo_Ngay_Dk_Ht_Validated);
			numSo_Ngay_Ht.Validated += new EventHandler(numSo_Ngay_Ht_Validated);
		}

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;

			Common.ScaterMemvar(this, ref drEdit);

			BindingLanguage();
			LoadDicName();

			Calc_So_Ngay();

			this.ShowDialog();
		}

		void LoadDicName()
		{

		}

		void Calc_So_Ngay()
		{
			if (txtNgay_Gd.Text.Replace(" ", "") != "//" && txtNgay_Dk_Ht.Text.Replace(" ", "") != "//")
			{
				DateTime dNgay_Dk_Ht = Library.StrToDate(txtNgay_Dk_Ht.Text);
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);

				numSo_Ngay_Dk_Ht.Value = dNgay_Dk_Ht.Subtract(dNgay_Gd).TotalDays + 1;
			}

			if (txtNgay_Gd.Text.Replace(" ", "") != "//" && txtNgay_Ht.Text.Replace(" ", "") != "//")
			{
				DateTime dNgay_Ht = Library.StrToDate(txtNgay_Ht.Text);
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);

				numSo_Ngay_Ht.Value = dNgay_Ht.Subtract(dNgay_Gd).TotalDays + 1;
			}
		}

		bool FormCheckValid()
		{
			if (txtNgay_Ht.Text.Replace(" ", "") == "//")
			{
				Common.MsgCancel("Chưa khai báo ngày hoàn thành!");
				return false;
			}

			if (!txtNgay_Ht.IsNull)
			{
				if ((int)SQLExec.ExecuteReturnValue("SELECT COUNT(Ident00) FROM R08Task_KH WHERE Ngay_Ht = '1/1/1900' AND Task_ID = '" + (string)drEdit["Task_ID"] + "'") > 0)
				{
					Common.MsgCancel("Chi tiết giao dịch chưa hoàn tất, bạn phải hoàn thành giao dịch chi tiết trước!");
					return false;
				}
			}

			return true;
		}

		bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
			{
				drEdit.RejectChanges();
				return false;
			}

			System.Collections.Hashtable htPara = new System.Collections.Hashtable();
			htPara.Add("NGAY_HT", Library.StrToDate(txtNgay_Ht.Text));
			htPara.Add("TASK_ID", drEdit["Task_ID"]);

			string strSQLExec = "UPDATE R08Task SET Ngay_Ht = @Ngay_Ht WHERE Task_ID = @Task_ID";

			//Luu xuong CSDL
			if (!SQLExec.Execute(strSQLExec, htPara, CommandType.Text))
				return false;

			return true;
		}

		void numSo_Ngay_Ht_Validated(object sender, EventArgs e)
		{
			if (txtNgay_Gd.Text.Trim() != "//" && numSo_Ngay_Ht.Value != 0)
			{
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);
				DateTime dNgay_Ht = dNgay_Gd.AddDays(numSo_Ngay_Ht.Value).AddDays(-1);

				txtNgay_Ht.Text = Library.DateToStr(dNgay_Ht);
			}
			else
				txtNgay_Ht.Text = string.Empty;
		}

		void numSo_Ngay_Dk_Ht_Validated(object sender, EventArgs e)
		{
			if (txtNgay_Gd.Text.Trim() != "//" && numSo_Ngay_Dk_Ht.Value != 0)
			{
				DateTime dNgay_Gd = Library.StrToDate(txtNgay_Gd.Text);
				DateTime dNgay_Dk_Ht = dNgay_Gd.AddDays(numSo_Ngay_Dk_Ht.Value).AddDays(-1);

				txtNgay_Dk_Ht.Text = Library.DateToStr(dNgay_Dk_Ht);
			}
			else
				txtNgay_Dk_Ht.Text = string.Empty;
		}

		void txtNgay_Dk_Ht_Validated(object sender, EventArgs e)
		{
			Calc_So_Ngay();
		}

		void txtNgay_Ht_Validated(object sender, EventArgs e)
		{
			Calc_So_Ngay();
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
	}
}
