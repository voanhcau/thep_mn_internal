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
using System.IO.Ports;
using System.Drawing.Printing;

namespace RosyList
{
	public partial class frmEquipmentInfo_Edit : RosyList.frmEdit
	{
        #region Phuong thuc

		public frmEquipmentInfo_Edit()
		{
			InitializeComponent();
			FillData();
		}

		public override void Load(enuEdit enuNew_Edit, DataRow drEdit)
		{
			this.drEdit = drEdit;
			this.enuNew_Edit = enuNew_Edit;
			this.Tag = (char)enuNew_Edit + "," + this.Tag;

			Common.ScaterMemvar(this, ref drEdit);

			txtHost_IP.Text = (string)drEdit["Host_IP"];

			BindingLanguage();
			LoadDicName();

			this.ShowDialog();
		}

		private void FillData()
		{
            txtCan.InputMask = (string)RosySystem.Library.Parameters.GetParaValue("VI_TRI_TRAM_CAN");
			txtBaudRate.Items.AddRange(new object[] { "", 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200 });
			cboParity.Items.AddRange(new object[] { "", "Even", "Odd", "None", "Mark", "Space" });
			cboDataBits.Items.AddRange(new object[] { "", 5,6,7,8 });
			cboStopBits.Items.AddRange(new object[] { "", "None", "One", "OnePointFive", "Two" });
			cboHandshake.Items.AddRange(new object[] { "", "None", "RequestToSend", "RequestToSendXOnXOff", "XOnXOff" });
			
			try
			{
				string[] strPorts = SerialPort.GetPortNames();

				cboPort_Name.Items.Add("USB");
				foreach (string strPort in strPorts)
				{
					cboPort_Name.Items.Add(strPort);
					cboPLC_Port_Name.Items.Add(strPort);
				}
			}
			catch (Exception ex)
			{
				Common.MsgCancel("Có Lỗi xảy ra: " + ex.ToString());
			}

			//Print
			cboPrint_Barcode.Items.Add(string.Empty);
			cboPrint_Report.Items.Add(string.Empty);
			cboPrint_Eticket.Items.Add(string.Empty);

			foreach (string item in PrinterSettings.InstalledPrinters)
			{
				cboPrint_Barcode.Items.Add(item);
				cboPrint_Report.Items.Add(item);
				cboPrint_Eticket.Items.Add(item);
			}
		}

		private void LoadDicName()
		{
			
		}

		public override bool FormCheckValid()
        {
            bool bvalid = true ;
			if (txtEquip_ID.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Equip_ID") + " " +
							  Languages.GetLanguage("Not_Null"));

				return false;

			}			

			if (txtDescription.Text.Trim() == string.Empty)
			{
				Common.MsgOk(Languages.GetLanguage("Description") + " " +
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
			if (!DataTool.SQLUpdate(enuNew_Edit, "R81EQUIPMENTINFO", ref drEdit))
				return false;

			return true;
		}

        #endregion

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			
            //if (!Element.sysIs_Admin && this.enuNew_Edit == enuEdit.Edit)
            //{
            //    if (MachineInfo.GetHostIP() != drEdit["Host_IP"].ToString())
            //        this.btgAccept.btAccept.Enabled = false;
            //}
		}
	}
}