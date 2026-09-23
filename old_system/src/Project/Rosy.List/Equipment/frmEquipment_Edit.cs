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
using System.Net;
using System.Net.Sockets;

namespace RosyList
{
	public partial class frmEquipment_Edit : RosyList.frmEdit
	{

        #region Phuong thuc

		public frmEquipment_Edit()
		{
			InitializeComponent();
		}

		
		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			if (enuNew_Edit == enuEdit.Edit)
				txtHost_IP.Text = (string)drEdit["Host_IP"];

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void LoadDicName()
		{
			if (enuNew_Edit == enuEdit.New || enuNew_Edit == enuEdit.Copy)
			{
				txtHost_IP.Text = MachineInfo.GetHostIP();
				txtHost_Name.Text = Dns.GetHostName();

				//Ping susscess return
				//System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
				//var replay = ping.Send(strHostName);

				//if (replay.Status == System.Net.NetworkInformation.IPStatus.Success)
				//{
				//    IPAddress ip = replay.Address;
				//}
			}
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
            if (txtHost_IP.Text.Trim() == string.Empty)
            {
				Common.MsgOk(Languages.GetLanguage("Host_IP") + " " +
							  Languages.GetLanguage("Not_Null"));
                
				return false;

            }			

			if (txtHost_Name.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Host_Name") + " " +
							  Languages.GetLanguage("Not_Null"));
				return false;
			}

            return bvalid;
        }

		public override bool Save()
		{
			Common.GatherMemvar(this, ref drEdit);

			drEdit["Host_IP"] = txtHost_IP.Text;

			//Kiem tra Valid tren Form
			if (!FormCheckValid())
				return false;

			if (this.enuNew_Edit == enuEdit.New || this.enuNew_Edit == enuEdit.Copy)
				drEdit["Create_Log"] = Common.GetCurrent_Log();
			else
				drEdit["LastModify_Log"] = Common.GetCurrent_Log();

			//Luu xuong CSDL
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81EQUIPMENT", ref drEdit))
				return false;

			//Doi ma
			if (this.enuNew_Edit == enuEdit.Edit)
				DataTool.SQLChangeID("Host_IP", drEdit);

			return true;
		}

        #endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			if (!Element.sysIs_Admin && this.enuNew_Edit == enuEdit.Edit)
			{
				if (MachineInfo.GetHostIP() != drEdit["Host_IP"].ToString())
					this.btgAccept.btAccept.Enabled = false;
			}
		}
	}
}