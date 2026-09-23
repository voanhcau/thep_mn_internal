using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data;
using RosySystem.Common;
using System.Threading;
using RosySystem.Data;

namespace RosyModule
{
	public static class HardwareInterfaceScale6080
	{
		private static SerialPort MyPort_Scale6080 = new SerialPort();
		private static SerialPort[] sPort_Scale6080 = new SerialPort[100];
		private static int DataState_Scale6080 = 0;
		private static int DataCnt_Scale6080 = 0;
		private static double dbWeight_Scale6080 = 0.0; //Bằng sửa đoạn này 0.0
        private static double dbOld_Weigh_Scale6080 = 0.0;//Bằng sửa đoạn này 0.0
		private static int iStable_Count_Scale6080 = 10;
		private static StateType currentState_Scale6080 = StateType.DISCONNECT;
		public static string strMode_Scale6080 = "9600,8,N,1";
		public static string strPort_Name_Scale6080 = "COM1";
		public static Parity parity_Scale6080 = Parity.None;
		public static int baudrate_Scale6080 = 9600;
		public static StopBits stopbits_Scale6080 = StopBits.One;
		public static int databits_Scale6080 = 8;
		private static byte[] buf_Scale6080 = new byte[256];
		public static int STX_Scale6080 = 10;
		public static int ETX_Scale6080 = 13;
		public static int ValueIndex_Scale6080 = 8;
		public static int ValueLen_Scale6080 = 6;
		private static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
		private static int K3HB_ID = 0;
		private static byte[] recv_Scale6080 = new byte[512];
		private static byte[] cmd1_Scale6080 = new byte[4] { (byte)1, (byte)65, (byte)112, (byte)5 };
		private static byte[] cmd2_Scale6080 = new byte[9] { (byte)1, (byte)65, (byte)2, (byte)87, (byte)71, (byte)65, (byte)3, (byte)82, (byte)5 };
		private static byte ACK_Scale6080 = (byte)6;
		private static int nullcount_Scale6080 = 0;
		private static int scount_Scale6080 = 0;

		public static string lastMessageError_Scale6080;

		public static StateType State
		{
			get
			{
				return HardwareInterfaceScale6080.currentState_Scale6080;
			}
		}

		public static event DataEventHandler DataReceive = new DataEventHandler(HardwareInterfaceScale6080.OnDataReceive);

		public static event StateEventHandler StateChange = new StateEventHandler(HardwareInterfaceScale6080.OnStateChange);

		private static void OnDataReceive(double value, string type)
		{
		}

		private static void OnStateChange(StateType type)
		{
		}

		private static void SetState(StateType state)
		{
			if (HardwareInterfaceScale6080.currentState_Scale6080 == state)
				return;
			HardwareInterfaceScale6080.currentState_Scale6080 = state;
			HardwareInterfaceScale6080.StateChange(state);
		}

		public static void Write(string s)
		{
			try
			{
				HardwareInterfaceScale6080.DataReceive(Convert.ToDouble(s), "weight");
			}
			catch
			{
			}
		}

		public static bool Start(string strScale_Name)
		{
			string strSQLExec = "SELECT * FROM R81EQUIPMENTINFO WHERE Host_IP = '" + MachineInfo.GetHostIP() + "' AND Can = '" + strScale_Name + "'";
			DataTable dtEquipment = SQLExec.ExecuteReturnDt(strSQLExec, CommandType.Text);
			if (dtEquipment.Rows.Count > 0)
			{
				DataRow drEquipment = dtEquipment.Rows[0];

				string strSTX = (string)drEquipment["STX"];

				if (strSTX != string.Empty)
					HardwareInterfaceScale6080.STX_Scale6080 = Convert.ToInt32(strSTX);

				string strETX = (string)drEquipment["ETX"];
				if (strETX != string.Empty)
					HardwareInterfaceScale6080.ETX_Scale6080 = Convert.ToInt32(strETX);

				string strValue_Len = (string)drEquipment["Value_Len"];
				int length = strValue_Len.IndexOf(',');
				if (strValue_Len != string.Empty)
				{
					try { HardwareInterfaceScale6080.ValueIndex_Scale6080 = Convert.ToInt32(strValue_Len.Substring(0, length)); }
					catch { }
					try { HardwareInterfaceScale6080.ValueLen_Scale6080 = Convert.ToInt32(strValue_Len.Substring(length + 1, strValue_Len.Length - 1 - length)); }
					catch { }
				}

				string strMode_Scale6080 = (string)drEquipment["BaudRate"] + "," + (string)drEquipment["DataBits"] + "," + (string)drEquipment["Parity"].ToString().Substring(0, 1).ToUpper();
				switch ((string)drEquipment["StopBits"])
				{
					case "None":
						strMode_Scale6080 += ",0";
						break;
					case "One":
						strMode_Scale6080 += ",1";
						break;
					case "OnePointFive":
						strMode_Scale6080 += ",1.5";
						break;
					case "Two":
						strMode_Scale6080 += ",1.5";
						break;
				}

				HardwareInterfaceScale6080.strPort_Name_Scale6080 = (string)drEquipment["Port_Name"];
				HardwareInterfaceScale6080.strMode_Scale6080 = strMode_Scale6080;
				return HardwareInterfaceScale6080.Start(HardwareInterfaceScale6080.strPort_Name_Scale6080, HardwareInterfaceScale6080.strMode_Scale6080);
			}
			else
			{
				Common.MsgCancel("Không tìm thấy thông tin cho loại cân: " + Variables.strEquip_ID);
				return false;
			}
		}

		public static bool Start(string strPort_Name_Scale6080, string strMode_Scale6080)
		{
			try
			{
				HardwareInterfaceScale6080.iStable_Count_Scale6080 = Variables.iStable_Count;
			}
			catch
			{
				HardwareInterfaceScale6080.iStable_Count_Scale6080 = 10;
			}
			if (HardwareInterfaceScale6080.iStable_Count_Scale6080 < 5)
				HardwareInterfaceScale6080.iStable_Count_Scale6080 = 5;

			switch (strPort_Name_Scale6080)
			{
				case "USB":
					HardwareInterfaceScale6080.CreateTimer(new EventHandler(HardwareInterfaceScale6080.USB_Tick));
					break;
				default:
					strMode_Scale6080 = strMode_Scale6080.ToUpper();
					HardwareInterfaceScale6080.strPort_Name_Scale6080 = strPort_Name_Scale6080;
					if (!HardwareInterfaceScale6080.ReadSettings(strMode_Scale6080))
						return false;

					HardwareInterfaceScale6080.Close();
					if (HardwareInterfaceScale6080.Check_Com_Port())
					{
						HardwareInterfaceScale6080.CreateTimer(new EventHandler(HardwareInterfaceScale6080.COM_Tick));
						break;
					}
					else
					{
						HardwareInterfaceScale6080.myTimer.Stop();
						HardwareInterfaceScale6080.StateChange(StateType.DISCONNECT);
						return false;
					}
			}
			return true;
		}

		private static void CreateTimer(EventHandler e)
		{
			HardwareInterfaceScale6080.myTimer.Stop();
			HardwareInterfaceScale6080.myTimer.Dispose();
			HardwareInterfaceScale6080.myTimer = new System.Windows.Forms.Timer();
			HardwareInterfaceScale6080.myTimer.Interval = 200;
			HardwareInterfaceScale6080.myTimer.Tick += e;
			HardwareInterfaceScale6080.myTimer.Start();
		}

		private static void USB_Tick(object sender, EventArgs e)
		{
			if (HardwareInterfaceScale6080.FindDevice())
			{
				object obj;
				if (HardwareInterfaceScale6080.K3HB_ID == 1)
				{
					obj = HardwareInterfaceScale6080.K3HB_putCommand("010000101C00002000001");
					HardwareInterfaceScale6080.K3HB_ID = 2;
				}
				else
				{
					obj = HardwareInterfaceScale6080.K3HB_putCommand("020000101C00002000001");
					HardwareInterfaceScale6080.K3HB_ID = 1;
				}
				if (obj.GetType() != typeof(double))
					return;
				HardwareInterfaceScale6080.DataReceive((double)obj, HardwareInterfaceScale6080.K3HB_ID.ToString());
			}
			else
				HardwareInterfaceScale6080.StateChange(StateType.DISCONNECT);
		}

		private static bool FindDevice()
		{
			return false;
		}

		private static object K3HB_putCommand(string Cmd)
		{
			int num1 = 0;
			byte[] buf_Scale6080 = new byte[Cmd.Length + 3];
			byte num2 = (byte)0;
			byte[] numArray1 = buf_Scale6080;
			int index1 = num1;
			int num3 = 1;
			int num4 = index1 + num3;
			int num5 = 2;
			numArray1[index1] = (byte)num5;
			for (int index2 = 0; index2 < Cmd.Length; ++index2)
			{
				buf_Scale6080[num4++] = (byte)Cmd[index2];
				num2 ^= (byte)Cmd[index2];
			}
			byte[] numArray2 = buf_Scale6080;
			int index3 = num4;
			int num6 = 1;
			int num7 = index3 + num6;
			int num8 = 3;
			numArray2[index3] = (byte)num8;
			byte num9 = (byte)((uint)num2 ^ 3U);
			byte[] numArray3 = buf_Scale6080;
			int index4 = num7;
			int num10 = 1;
			int num11 = index4 + num10;
			int num12 = (int)num9;
			numArray3[index4] = (byte)num12;
			HardwareInterfaceScale6080.Write_Packet(buf_Scale6080);
			Thread.Sleep(50);
			return HardwareInterfaceScale6080.K3HB_ProcessReceive();
		}

		private static void Write_Packet(byte[] buf_Scale6080)
		{
		}

		private static object K3HB_ProcessReceive()
		{
			int num1 = 100;
			HardwareInterfaceScale6080.ReadOut();
			int num2 = 0;
			byte[] numArray1 = HardwareInterfaceScale6080.recv_Scale6080;
			int index1 = num2;
			int num3 = 1;
			int num4 = index1 + num3;
			if ((int)numArray1[index1] != 2)
				return (object)"Invalid STX_Scale6080";
			byte num5 = (byte)0;
			string str = "";
			while (num1-- > 0)
			{
				int num6 = (int)HardwareInterfaceScale6080.recv_Scale6080[num4++];
				num5 ^= (byte)num6;
				if (num6 != 3)
					str = str + (object)(char)num6;
				else
					break;
			}
			int num7 = (int)num5;
			byte[] numArray2 = HardwareInterfaceScale6080.recv_Scale6080;
			int index2 = num4;
			int num8 = 1;
			int num9 = index2 + num8;
			int num10 = (int)numArray2[index2];
			if (num7 != num10)
				return (object)"Frame BCC invalid";
			try
			{
				return (object)Convert.ToDouble(Convert.ToInt32(str.Substring(str.Length - 8, 8), 16) / 10);
			}
			catch
			{
				return (object)"Convert error";
			}
		}

		private static int ReadOut()
		{
			return 0;
		}

		private static void COM_Tick(object sender, EventArgs e)
		{
			if (!HardwareInterfaceScale6080.MyPort_Scale6080.IsOpen)
			{
				HardwareInterfaceScale6080.SetState(StateType.DISCONNECT);
			}
			else
			{
				int bytesToRead = HardwareInterfaceScale6080.MyPort_Scale6080.BytesToRead;
				if (bytesToRead == 0)
				{
					if (HardwareInterfaceScale6080.nullcount_Scale6080++ <= 5)
						return;

					HardwareInterfaceScale6080.SetState(StateType.NULL_DATA);
					HardwareInterfaceScale6080.nullcount_Scale6080 = 0;
				}
				else
				{
					for (int index = 0; index < bytesToRead; ++index)
					{
						int num = 0;
						try
						{
							num = HardwareInterfaceScale6080.MyPort_Scale6080.ReadByte();
						}
						catch
						{
						}
						if (num != 0)
						{
							switch (HardwareInterfaceScale6080.DataState_Scale6080)
							{
								case 0:
									if (num == HardwareInterfaceScale6080.STX_Scale6080)
										HardwareInterfaceScale6080.DataState_Scale6080 = 1;

									HardwareInterfaceScale6080.DataCnt_Scale6080 = 0;
									break;
								case 1:
									if (num == HardwareInterfaceScale6080.ETX_Scale6080)
									{
										if (HardwareInterfaceScale6080.DataCnt_Scale6080 > 0)
										{
											HardwareInterfaceScale6080.buf_Scale6080[HardwareInterfaceScale6080.DataCnt_Scale6080] = (byte)0;
											try
											{
												HardwareInterfaceScale6080.ProcessReceive_Scale8060(Encoding.ASCII.GetString(HardwareInterfaceScale6080.buf_Scale6080));

											}
											catch
											{
												HardwareInterfaceScale6080.SetState(StateType.DATA_ERROR);
											}
										}
										HardwareInterfaceScale6080.DataState_Scale6080 = 0;
										break;
									}
									else
									{
										HardwareInterfaceScale6080.buf_Scale6080[HardwareInterfaceScale6080.DataCnt_Scale6080++] = (byte)num;
										if (HardwareInterfaceScale6080.DataCnt_Scale6080 > 100)
											HardwareInterfaceScale6080.DataCnt_Scale6080 = 0;
										break;
									}
							}
						}
					}
				}
			}
		}

		private static void ProcessReceive_Scale8060(string str)
		{
			try
			{
				HardwareInterfaceScale6080.SetDataReceive(Convert.ToDouble(str.Substring((int)HardwareInterfaceScale6080.ValueIndex_Scale6080, (int)HardwareInterfaceScale6080.ValueLen_Scale6080).Replace(" ", "")));
			}
			catch
			{
				HardwareInterfaceScale6080.SetState(StateType.DATA_ERROR);
			}
		}

		private static void ProcessReceive(string s)
		{
			switch (Variables.strEquip_ID)
			{
				case "XK3190-D2+":
					try
					{
						string str = "";
						s = s.TrimEnd(new char[1]).Replace('.', ',');
						for (int index = s.Length - 1; index >= 0; --index)
							str = str + (object)s[index];
						HardwareInterfaceScale6080.dbWeight_Scale6080 = Convert.ToDouble(str);
						break;
					}
					catch
					{
						HardwareInterfaceScale6080.SetState(StateType.DATA_ERROR);
						return;
					}
				case "XK3190-D10P":
					try
					{
						string str1 = s.Substring(HardwareInterfaceScale6080.ValueIndex_Scale6080, HardwareInterfaceScale6080.ValueLen_Scale6080).Replace(" ", "");
						HardwareInterfaceScale6080.dbWeight_Scale6080 = Convert.ToDouble(str1.Substring(0, str1.Length - 1));
						string str2 = str1.Substring(str1.Length - 1, 1);
						HardwareInterfaceScale6080.dbWeight_Scale6080 /= Math.Pow(10.0, Convert.ToDouble(str2));
						break;
					}
					catch
					{
						HardwareInterfaceScale6080.SetState(StateType.DATA_ERROR);
						return;
					}

				default:
					try
					{
						HardwareInterfaceScale6080.dbWeight_Scale6080 = Convert.ToDouble(s.Substring(HardwareInterfaceScale6080.ValueIndex_Scale6080 - 1, HardwareInterfaceScale6080.ValueLen_Scale6080).Replace(" ", ""));
						break;
					}
					catch
					{
						HardwareInterfaceScale6080.SetState(StateType.DATA_ERROR);
						return;
					}
			}
			HardwareInterfaceScale6080.DataReceive(HardwareInterfaceScale6080.dbWeight_Scale6080, "weight");
			if (HardwareInterfaceScale6080.dbWeight_Scale6080 != HardwareInterfaceScale6080.dbOld_Weigh_Scale6080)
			{
				HardwareInterfaceScale6080.SetState(StateType.UN_STABLE_DATA);
				HardwareInterfaceScale6080.dbOld_Weigh_Scale6080 = HardwareInterfaceScale6080.dbWeight_Scale6080;
				HardwareInterfaceScale6080.scount_Scale6080 = HardwareInterfaceScale6080.iStable_Count_Scale6080;
			}
			else if (HardwareInterfaceScale6080.scount_Scale6080 > 0)
				--HardwareInterfaceScale6080.scount_Scale6080;
			else
				HardwareInterfaceScale6080.SetState(StateType.STABLE_DATA);
		}

		private static void SetDataReceive(double dbValue)
		{
			HardwareInterfaceScale6080.DataReceive(dbValue, "Weight");
		}

		public static void Close()
		{
			HardwareInterfaceScale6080.myTimer.Stop();
			if (!HardwareInterfaceScale6080.MyPort_Scale6080.IsOpen)
				return;
			HardwareInterfaceScale6080.MyPort_Scale6080.Close();
		}

		private static bool ReadSettings(string settings)
		{
			string[] strArray = settings.Split(',');
			if (strArray.Length != 4)
				return false;
			try
			{
				HardwareInterfaceScale6080.baudrate_Scale6080 = Convert.ToInt32(strArray[0]);
			}
			catch
			{
				return false;
			}
			try
			{
				HardwareInterfaceScale6080.databits_Scale6080 = Convert.ToInt32(strArray[1]);
			}
			catch
			{
				return false;
			}
			switch (strArray[2])
			{
				case "E":
					HardwareInterfaceScale6080.parity_Scale6080 = Parity.Even;
					break;
				case "O":
					HardwareInterfaceScale6080.parity_Scale6080 = Parity.Odd;
					break;
				case "N":
					HardwareInterfaceScale6080.parity_Scale6080 = Parity.None;
					break;
				case "M":
					HardwareInterfaceScale6080.parity_Scale6080 = Parity.Mark;
					break;
				case "S":
					HardwareInterfaceScale6080.parity_Scale6080 = Parity.Space;
					break;
				default:
					return false;
			}
			switch (strArray[3])
			{
				case "0":
					HardwareInterfaceScale6080.stopbits_Scale6080 = StopBits.None;
					break;
				case "1":
					HardwareInterfaceScale6080.stopbits_Scale6080 = StopBits.One;
					break;
				case "1.5":
					HardwareInterfaceScale6080.stopbits_Scale6080 = StopBits.OnePointFive;
					break;
				case "2":
					HardwareInterfaceScale6080.stopbits_Scale6080 = StopBits.Two;
					break;
				default:
					return false;
			}
			return true;
		}

		public static bool Check_Com_Port()
		{
			if (HardwareInterfaceScale6080.MyPort_Scale6080.IsOpen)
			{
				if (!(HardwareInterfaceScale6080.MyPort_Scale6080.PortName != HardwareInterfaceScale6080.strPort_Name_Scale6080 | HardwareInterfaceScale6080.MyPort_Scale6080.Parity != HardwareInterfaceScale6080.parity_Scale6080 | HardwareInterfaceScale6080.MyPort_Scale6080.StopBits != HardwareInterfaceScale6080.stopbits_Scale6080 | HardwareInterfaceScale6080.MyPort_Scale6080.DataBits != HardwareInterfaceScale6080.databits_Scale6080 | HardwareInterfaceScale6080.MyPort_Scale6080.BaudRate != HardwareInterfaceScale6080.baudrate_Scale6080))
					return true;
				HardwareInterfaceScale6080.MyPort_Scale6080.Close();
			}
			try
			{
				HardwareInterfaceScale6080.MyPort_Scale6080.PortName = HardwareInterfaceScale6080.strPort_Name_Scale6080;
				HardwareInterfaceScale6080.MyPort_Scale6080.Parity = HardwareInterfaceScale6080.parity_Scale6080;
				HardwareInterfaceScale6080.MyPort_Scale6080.StopBits = HardwareInterfaceScale6080.stopbits_Scale6080;
				HardwareInterfaceScale6080.MyPort_Scale6080.DataBits = HardwareInterfaceScale6080.databits_Scale6080;
				HardwareInterfaceScale6080.MyPort_Scale6080.BaudRate = HardwareInterfaceScale6080.baudrate_Scale6080;
				HardwareInterfaceScale6080.MyPort_Scale6080.ReceivedBytesThreshold = 1000;
				HardwareInterfaceScale6080.MyPort_Scale6080.Handshake = Handshake.None;
				HardwareInterfaceScale6080.MyPort_Scale6080.Open();
				HardwareInterfaceScale6080.SetState(StateType.CONNECTED);
			}
			catch (Exception ex)
			{
				HardwareInterfaceScale6080.lastMessageError_Scale6080 = ex.Message;
				HardwareInterfaceScale6080.SetState(StateType.DISCONNECT);
				return false;
			}
			return true;
		}
	}
}
