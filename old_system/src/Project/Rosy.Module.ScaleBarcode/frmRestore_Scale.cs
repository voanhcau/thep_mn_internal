using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RosySystem.Common;
using RosySystem.Data;
using RosySystem;
using RosySystem.Element;
using RosySystem.Library;

namespace RosyModule.ScaleBarcode
{
	public partial class frmRestore_Scale : RosySystem.Customize.frmEdit
	{
		public frmRestore_Scale()
		{
			InitializeComponent();
			this.btgAccept.btAccept.Click += new EventHandler(btAccept_Click);
			this.btgAccept.btCancel.Click += new EventHandler(btCancel_Click);
		}

		new public void Load(DataRow drEdit)
		{
			this.drEdit = drEdit;
			Common.ScaterMemvar(this, ref drEdit);

			this.BindingLanguage();
			this.ShowDialog();
		}

		void btAccept_Click(object sender, EventArgs e)
		{

			this.isAccept = true;
			this.Close();
		}

		void btCancel_Click(object sender, EventArgs e)
		{
			this.isAccept = false;
			this.Close();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin)
			{
				if (!Common.CheckPermission("ACCESS_RESTORE_SCALE", enuPermission_Type.Allow_Access))
					this.btgAccept.btAccept.Enabled = false;
			}
		}
	}
}
