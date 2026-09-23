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
	public static class HardwareInterface
	{
		private static SerialPort MyPort = new SerialPort();
		private static SerialPort[] sPort = new SerialPort[100];
		private static int DataState = 0;
		private static int DataCnt = 0;
		private static double weight = 0.0;
		private static double old_weigh = 0.0;
		private static int iStable_Count = 10;
		private static StateType currentState = StateType.DISCONNECT;
		public static string strMode = "9600,8,N,1";
		public static string strPort_Name = "COM1";
		public static Parity parity = Parity.None;
		public static int baudrate = 9600;
		public static StopBits stopbits = StopBits.One;
		public static int databits = 8;
		private static byte[] buf = new byte[256];
		public static int STX = 10;
		public static int ETX = 13;
		public static int ValueIndex = 8;
		public static int ValueLen = 6;
		private static byte[] send = new byte[2] { (byte)10, (byte)13 };
		private static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
		private static int K3HB_ID = 0;
		private static byte[] recv = new byte[512];
		private static byte[] cmd1 = new byte[4] { (byte)1, (byte)65, (byte)112, (byte)5 };
		private static byte[] cmd2 = new byte[9] { (byte)1, (byte)65, (byte)2, (byte)87, (byte)71, (byte)65, (byte)3, (byte)82, (byte)5 };
		private static byte ACK = (byte)6;
		private static int nullcount = 0;
		private static int scount = 0;
		private const string ReadWeigh1 = "010000101C00002000001";
		private const string ReadWeigh2 = "020000101C00002000001";
		private const ushort PID = (ushort)220;
		private const ushort VID = (ushort)5826;
		private const int SET_VALUE = 34;
		public static string lastMessageError;

		public static StateType State
		{
			get
			{
				return HardwareInterface.currentState;
			}
		}

		public static event DataEventHandler DataReceive = new DataEventHandler(HardwareInterface.OnDataReceive);

		public static event StateEventHandler StateChange = new StateEventHandler(HardwareInterface.OnStateChange);

		private static void OnDataReceive(double value, string type)
		{
		}

		private static void OnStateChange(StateType type)
		{
		}

		private static void SetState(StateType state)
		{
			if (HardwareInterface.currentState == state)
				return;
			HardwareInterface.currentState = state;
			HardwareInterface.StateChange(state);
		}

		public static void Write(string s)
		{
			try
			{
				HardwareInterface.DataReceive(Convert.ToDouble(s), "Weight");
			}
			catch
			{
			}
		}

		public static bool Start()
		{
			DataRow drEquipment = DataTool.SQLGetDataRowByID("R81EquipmentInfo", "Host_IP", MachineInfo.GetHostIP());

			if (drEquipment == null)
			{
			    Common.MsgCancel("Không tìm thấy thông tin cho loại cân: " + Variables.strEquip_ID);
			    return false;
			}
			else
			{
				string strSTX = (string)drEquipment["STX"];
				if (strSTX != string.Empty)
					HardwareInterface.STX = Convert.ToInt32(strSTX);

				string strETX = (string)drEquipment["ETX"];
				if (strETX != string.Empty)
					HardwareInterface.ETX = Convert.ToInt32(strETX);

				string strValue_Len = (string)drEquipment["Value_Len"];
				int length = strValue_Len.IndexOf(',');
				if (strValue_Len != string.Empty)
				{
					try
					{
						HardwareInterface.ValueIndex = Convert.ToInt32(strValue_Len.Substring(0, length));
					}
					catch
					{
					}
					try
					{
						HardwareInterface.ValueLen = Convert.ToInt32(strValue_Len.Substring(length + 1, strValue_Len.Length - 1 - length));
					}
					catch
					{
					}
				}
				
				string strMode = (string)drEquipment["BaudRate"] + "," + (string)drEquipment["DataBits"] + "," + (string)drEquipment["Parity"].ToString().Substring(0,1).ToUpper();
				switch ((string)drEquipment["StopBits"])
				{
					case "None":
						strMode += ",0";
						break;
					case "One":
						strMode += ",1";
						break;
					case "OnePointFive":
						strMode += ",1.5";
						break;
					case "Two":
						strMode += ",1.5";
						break;
				}

				HardwareInterface.strPort_Name = (string)drEquipment["Port_Name"];
				HardwareInterface.strMode = strMode;
				return HardwareInterface.Start(HardwareInterface.strPort_Name, HardwareInterface.strMode);
			}
		}

		public static bool Start(string strPort_Name, string strMode)
		{
			try
			{
				HardwareInterface.iStable_Count = Variables.iStable_Count;
			}
			catch
			{
				HardwareInterface.iStable_Count = 10;
			}
			if (HardwareInterface.iStable_Count < 5)
				HardwareInterface.iStable_Count = 5;

			switch (strPort_Name)
			{
				case "USB":
					HardwareInterface.CreateTimer(new EventHandler(HardwareInterface.USB_Tick));
					break;
				default:
					strMode = strMode.ToUpper();
					HardwareInterface.strPort_Name = strPort_Name;
					if (!HardwareInterface.ReadSettings(strMode))
						return false;

					HardwareInterface.Close();
					if (HardwareInterface.Check_Com_Port())
					{
						HardwareInterface.CreateTimer(new EventHandler(HardwareInterface.COM_Tick));
						break;
					}
					else
					{
						HardwareInterface.myTimer.Stop();
						HardwareInterface.StateChange(StateType.DISCONNECT);
						return false;
					}
			}
			return true;
		}

		private static void CreateTimer(EventHandler e)
		{
			HardwareInterface.myTimer.Stop();
			HardwareInterface.myTimer.Dispose();
			HardwareInterface.myTimer = new System.Windows.Forms.Timer();
			HardwareInterface.myTimer.Interval = 200;
			HardwareInterface.myTimer.Tick += e;
			HardwareInterface.myTimer.Start();
		}

		private static void USB_Tick(object sender, EventArgs e)
		{
			if (HardwareInterface.FindDevice())
			{
				object obj;
				if (HardwareInterface.K3HB_ID == 1)
				{
					obj = HardwareInterface.K3HB_putCommand("010000101C00002000001");
					HardwareInterface.K3HB_ID = 2;
				}
				else
				{
					obj = HardwareInterface.K3HB_putCommand("020000101C00002000001");
					HardwareInterface.K3HB_ID = 1;
				}
				if (obj.GetType() != typeof(double))
					return;
				HardwareInterface.DataReceive((double)obj, HardwareInterface.K3HB_ID.ToString());
			}
			else
				HardwareInterface.StateChange(StateType.DISCONNECT);
		}

		private static bool FindDevice()
		{
			return false;
		}

		private static object K3HB_putCommand(string Cmd)
		{
			int num1 = 0;
			byte[] buf = new byte[Cmd.Length + 3];
			byte num2 = (byte)0;
			byte[] numArray1 = buf;
			int index1 = num1;
			int num3 = 1;
			int num4 = index1 + num3;
			int num5 = 2;
			numArray1[index1] = (byte)num5;
			for (int index2 = 0; index2 < Cmd.Length; ++index2)
			{
				buf[num4++] = (byte)Cmd[index2];
				num2 ^= (byte)Cmd[index2];
			}
			byte[] numArray2 = buf;
			int index3 = num4;
			int num6 = 1;
			int num7 = index3 + num6;
			int num8 = 3;
			numArray2[index3] = (byte)num8;
			byte num9 = (byte)((uint)num2 ^ 3U);
			byte[] numArray3 = buf;
			int index4 = num7;
			int num10 = 1;
			int num11 = index4 + num10;
			int num12 = (int)num9;
			numArray3[index4] = (byte)num12;
			HardwareInterface.Write_Packet(buf);
			Thread.Sleep(50);
			return HardwareInterface.K3HB_ProcessReceive();
		}

		private static void Write_Packet(byte[] buf)
		{
		}

		private static object K3HB_ProcessReceive()
		{
			int num1 = 100;
			HardwareInterface.ReadOut();
			int num2 = 0;
			byte[] numArray1 = HardwareInterface.recv;
			int index1 = num2;
			int num3 = 1;
			int num4 = index1 + num3;
			if ((int)numArray1[index1] != 2)
				return (object)"Invalid STX";
			byte num5 = (byte)0;
			string str = "";
			while (num1-- > 0)
			{
				int num6 = (int)HardwareInterface.recv[num4++];
				num5 ^= (byte)num6;
				if (num6 != 3)
					str = str + (object)(char)num6;
				else
					break;
			}
			int num7 = (int)num5;
			byte[] numArray2 = HardwareInterface.recv;
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
			if (!HardwareInterface.MyPort.IsOpen)
			{
				HardwareInterface.SetState(StateType.DISCONNECT);
			}
			else
			{
				switch (Variables.strEquip_ID)
				{
					case "PR1612/02":
						HardwareInterface.MyPort.DiscardInBuffer();
						HardwareInterface.MyPort.Write(HardwareInterface.cmd1, 0, HardwareInterface.cmd1.Length);
						Thread.Sleep(20);
						int bytesToRead1 = HardwareInterface.MyPort.BytesToRead;
						switch (bytesToRead1)
						{
							case 0:
								return;
							case 1:
								if ((int)(byte)HardwareInterface.MyPort.ReadByte() == 4)
								{
									HardwareInterface.MyPort.Write(HardwareInterface.cmd2, 0, HardwareInterface.cmd2.Length);
									Thread.Sleep(20);
								}
								break;
						}
						if (bytesToRead1 > 1)
						{
							try
							{
								string str = HardwareInterface.MyPort.ReadExisting();
								int num = Convert.ToInt32(str[12].ToString());
								HardwareInterface.weight = Convert.ToDouble(str.Substring(HardwareInterface.ValueIndex, HardwareInterface.ValueLen)) * Math.Pow(10.0, (double)(num - 5));
								HardwareInterface.DataReceive(HardwareInterface.weight, "Weight");
								HardwareInterface.SetState(StateType.CONNECTED);
							}
							catch
							{
								HardwareInterface.SetState(StateType.DATA_ERROR);
							}
						}
						HardwareInterface.MyPort.Write(new byte[1] { HardwareInterface.ACK }, 0, 1);
						Thread.Sleep(20);
						break;

					//Tram can 60 va 80 tan
					case "XK3190-D2+":
						int bytesToRead = HardwareInterface.MyPort.BytesToRead;
						if (bytesToRead == 0)
						{
							if (HardwareInterface.nullcount++ <= 5)
								return;

							HardwareInterface.SetState(StateType.NULL_DATA);
							HardwareInterface.nullcount = 0;
						}
						else
						{
							for (int index = 0; index < bytesToRead; ++index)
							{
								int num = 0;
								try
								{
									num = HardwareInterface.MyPort.ReadByte();
								}
								catch
								{
								}
								if (num != 0)
								{
									switch (HardwareInterface.DataState)
									{
										case 0:
											if (num == HardwareInterface.STX)
												HardwareInterface.DataState = 1;

											HardwareInterface.DataCnt = 0;
											break;
										case 1:
											if (num == HardwareInterface.ETX)
											{
												if (HardwareInterface.DataCnt > 0)
												{
													HardwareInterface.buf[HardwareInterface.DataCnt] = (byte)0;
													try
													{
														HardwareInterface.ProcessReceive1(Encoding.ASCII.GetString(HardwareInterface.buf));

													}
													catch
													{
														HardwareInterface.SetState(StateType.DATA_ERROR);
													}
												}
												HardwareInterface.DataState = 0;
												break;
											}
											else
											{
												HardwareInterface.buf[HardwareInterface.DataCnt++] = (byte)num;
												if (HardwareInterface.DataCnt > 100)
													HardwareInterface.DataCnt = 0;
												break;
											}
									}
								}
							}
						}
						break;

					default:
						int bytesToRead2 = HardwareInterface.MyPort.BytesToRead;
						if (bytesToRead2 == 0)
						{
							if (HardwareInterface.nullcount++ <= 5)
								break;
							HardwareInterface.SetState(StateType.NULL_DATA);
							HardwareInterface.nullcount = 0;
							break;
						}
						else
						{
							for (int index = 0; index < bytesToRead2; ++index)
							{
								int num = 0;
								try
								{
									num = HardwareInterface.MyPort.ReadByte();
								}
								catch
								{
								}
								if (num != 0)
								{
									switch (HardwareInterface.DataState)
									{
										case 0:
											if (num == HardwareInterface.STX)
												HardwareInterface.DataState = 1;
											HardwareInterface.DataCnt = 0;
											break;
										case 1:
											if (num == HardwareInterface.ETX)
											{
												if (HardwareInterface.DataCnt > 0)
												{
													HardwareInterface.buf[HardwareInterface.DataCnt] = (byte)0;
													try
													{
														HardwareInterface.ProcessReceive(Encoding.ASCII.GetString(HardwareInterface.buf));
													}
													catch
													{
														HardwareInterface.SetState(StateType.DATA_ERROR);
													}
												}
												HardwareInterface.DataState = 0;
												break;
											}
											else
											{
												HardwareInterface.buf[HardwareInterface.DataCnt++] = (byte)num;
												if (HardwareInterface.DataCnt > 100)
													HardwareInterface.DataCnt = 0;
												break;
											}
									}
								}
							}
							break;
						}
				}
			}
		}

		private static void ProcessReceive1(string s)
		{
			try
			{
				HardwareInterface.SetDataReceive(Convert.ToDouble(s.Substring((int)HardwareInterface.ValueIndex, (int)HardwareInterface.ValueLen).Replace(" ", "")));
			}
			catch
			{
				HardwareInterface.SetState(StateType.DATA_ERROR);
			}
		}

		private static void SetDataReceive(double p)
		{
			HardwareInterface.DataReceive(p, "Weight");
		}

		public static void Close()
		{
			HardwareInterface.myTimer.Stop();
			if (!HardwareInterface.MyPort.IsOpen)
				return;
			HardwareInterface.MyPort.Close();
		}

		private static bool ReadSettings(string settings)
		{
			string[] strArray = settings.Split(',');
			if (strArray.Length != 4)
				return false;
			try
			{
				HardwareInterface.baudrate = Convert.ToInt32(strArray[0]);
			}
			catch
			{
				return false;
			}
			try
			{
				HardwareInterface.databits = Convert.ToInt32(strArray[1]);
			}
			catch
			{
				return false;
			}
			switch (strArray[2])
			{
				case "E":
					HardwareInterface.parity = Parity.Even;
					break;
				case "O":
					HardwareInterface.parity = Parity.Odd;
					break;
				case "N":
					HardwareInterface.parity = Parity.None;
					break;
				case "M":
					HardwareInterface.parity = Parity.Mark;
					break;
				case "S":
					HardwareInterface.parity = Parity.Space;
					break;
				default:
					return false;
			}
			switch (strArray[3])
			{
				case "0":
					HardwareInterface.stopbits = StopBits.None;
					break;
				case "1":
					HardwareInterface.stopbits = StopBits.One;
					break;
				case "1.5":
					HardwareInterface.stopbits = StopBits.OnePointFive;
					break;
				case "2":
					HardwareInterface.stopbits = StopBits.Two;
					break;
				default:
					return false;
			}
			return true;
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
						HardwareInterface.weight = Convert.ToDouble(str);
						break;
					}
					catch
					{
						HardwareInterface.SetState(StateType.DATA_ERROR);
						return;
					}
				case "XK3190-D10P":
					try
					{
						string str1 = s.Substring(HardwareInterface.ValueIndex, HardwareInterface.ValueLen).Replace(" ", "");
						HardwareInterface.weight = Convert.ToDouble(str1.Substring(0, str1.Length - 1));
						string str2 = str1.Substring(str1.Length - 1, 1);
						HardwareInterface.weight /= Math.Pow(10.0, Convert.ToDouble(str2));
						break;
					}
					catch
					{
						HardwareInterface.SetState(StateType.DATA_ERROR);
						return;
					}
				
				default:
					try
					{
						HardwareInterface.weight = Convert.ToDouble(s.Substring(HardwareInterface.ValueIndex - 1, HardwareInterface.ValueLen).Replace(" ", ""));
						break;
					}
					catch
					{
						HardwareInterface.SetState(StateType.DATA_ERROR);
						return;
					}
			}
			HardwareInterface.DataReceive(HardwareInterface.weight, "Weight");
			if (HardwareInterface.weight != HardwareInterface.old_weigh)
			{
				HardwareInterface.SetState(StateType.UN_STABLE_DATA);
				HardwareInterface.old_weigh = HardwareInterface.weight;
				HardwareInterface.scount = HardwareInterface.iStable_Count;
			}
			else if (HardwareInterface.scount > 0)
				--HardwareInterface.scount;
			else
				HardwareInterface.SetState(StateType.STABLE_DATA);
		}

		public static bool Check_Com_Port()
		{
			if (HardwareInterface.MyPort.IsOpen)
			{
				if (!(HardwareInterface.MyPort.PortName != HardwareInterface.strPort_Name | HardwareInterface.MyPort.Parity != HardwareInterface.parity | HardwareInterface.MyPort.StopBits != HardwareInterface.stopbits | HardwareInterface.MyPort.DataBits != HardwareInterface.databits | HardwareInterface.MyPort.BaudRate != HardwareInterface.baudrate))
					return true;
				HardwareInterface.MyPort.Close();
			}
			try
			{
				HardwareInterface.MyPort.PortName = HardwareInterface.strPort_Name;
				HardwareInterface.MyPort.Parity = HardwareInterface.parity;
				HardwareInterface.MyPort.StopBits = HardwareInterface.stopbits;
				HardwareInterface.MyPort.DataBits = HardwareInterface.databits;
				HardwareInterface.MyPort.BaudRate = HardwareInterface.baudrate;
				HardwareInterface.MyPort.ReceivedBytesThreshold = 1000;
				HardwareInterface.MyPort.Handshake = Handshake.None;
				HardwareInterface.MyPort.Open();
				HardwareInterface.SetState(StateType.CONNECTED);
			}
			catch (Exception ex)
			{
				HardwareInterface.lastMessageError = ex.Message;
				HardwareInterface.SetState(StateType.DISCONNECT);
				return false;
			}
			return true;
		}
	}
}
