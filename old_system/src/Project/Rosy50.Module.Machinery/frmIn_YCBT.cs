using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RosySystem.Control;
using RosySystem.Library;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Common;


namespace RosyModule
{
	public partial class frmIn_YCBT : RosySystem.Customize.frmEdit
	{
		public frmIn_YCBT()
		{
			InitializeComponent();
			btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;

			Common.ScaterMemvar(this, ref drEdit);

			DateTime date = DateTime.Now.AddDays(7);
			while (date.DayOfWeek != DayOfWeek.Monday)
			{
				date = date.AddDays(-1);
			}

			DateTime startDate = date;
			DateTime endDate = date.AddDays(5);

			
			dteNgay_Ct1.Text = Library.DateToStr(startDate);
			dteNgay_Ct2.Text = Library.DateToStr(endDate);

			BindingLanguage();
			LoadDicName();
			this.ShowDialog();
		}

		private void LoadDicName()
		{

		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

		void btAccept_Click(object sender, EventArgs e)
		{
			if (this.Save())
			{
				this.isAccept = true;
				this.Close();
			}
		}

		private bool Save()
		{
			return true;
		}
	}
}
