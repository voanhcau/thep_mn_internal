using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using RosySystem.Common;
using Microsoft.Win32;

namespace RosyModule
{
	public static class Led5Digit
	{
		public static SerialPort serialPort = new SerialPort("COM2", 9600, Parity.None, 8, StopBits.One);
		private static int value = 0;
		private static byte STX = 10;
		private static byte ETX = 13;
		private static byte[] txbuf = new byte[20];

		public static int Value
		{
			get
			{
				return Led5Digit.value;
			}
			set
			{
				if (Led5Digit.serialPort.IsOpen)
				{
					string text = value.ToString();
					if (value < 0)
					{
						while (text.Length < 5)
						{
							text = text.Insert(1, "0");
						}
					}
					else
					{
						while (text.Length < 5)
						{
							text = text.Insert(0, "0");
						}
					}
					text = "00" + text;
					Led5Digit.txbuf[0] = Led5Digit.STX;
					for (int i = 0; i < 7; i++)
					{
						Led5Digit.txbuf[i + 1] = (byte)text[i];
					}
					Led5Digit.txbuf[8] = Led5Digit.ETX;
					Led5Digit.serialPort.Write(Led5Digit.txbuf, 0, 9);
				}
			}
		}

		public static bool Init()
		{
			if (Led5Digit.serialPort.IsOpen)
			{
				Led5Digit.serialPort.Close();
			}
			if (!Led5Digit.ReadSettingFromRegistry())
			{
				Led5Digit.WriteSettingToRegistry();
			}
			bool result;
			try
			{
				Led5Digit.serialPort.Open();
			}
			catch (Exception ex)
			{
				Common.MsgCancel("Can not Init LedBoard "  + ex.Message.ToString());
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		private static bool ReadSettingFromRegistry()
		{
			string dataFromRegistry = LoadRegistry.GetDataFromRegistry(6, "LedComNo");
			bool result;
			if (dataFromRegistry == "")
			{
				result = false;
			}
			else
			{
				Led5Digit.serialPort.PortName = dataFromRegistry;
				string dataFromRegistry2 = LoadRegistry.GetDataFromRegistry(6, "LedSetting");
				string[] array = dataFromRegistry2.Split(new char[]{','});
				if (array.Length != 4)
				{
					result = false;
				}
				else
				{
					try
					{
						Led5Digit.serialPort.BaudRate = Convert.ToInt32(array[0]);
					}
					catch
					{
						result = false;
						return result;
					}
					string text = array[1];
					if (text != null)
					{
						if (!(text == "E"))
						{
							if (!(text == "O"))
							{
								if (!(text == "N"))
								{
									if (!(text == "M"))
									{
										if (!(text == "S"))
										{
											goto strS;
										}
										Led5Digit.serialPort.Parity = Parity.Space;
									}
									else
									{
										Led5Digit.serialPort.Parity = Parity.Mark;
									}
								}
								else
								{
									Led5Digit.serialPort.Parity = Parity.None;
								}
							}
							else
							{
								Led5Digit.serialPort.Parity = Parity.Odd;
							}
						}
						else
						{
							Led5Digit.serialPort.Parity = Parity.Even;
						}
						try
						{
							Led5Digit.serialPort.DataBits = Convert.ToInt32(array[2]);
						}
						catch
						{
							result = false;
							return result;
						}
						text = array[3];
						if (text != null)
						{
							if (!(text == "0"))
							{
								if (!(text == "1"))
								{
									if (!(text == "1.5"))
									{
										if (!(text == "2"))
										{
											goto str2;
										}
										Led5Digit.serialPort.StopBits = StopBits.Two;
									}
									else
									{
										Led5Digit.serialPort.StopBits = StopBits.OnePointFive;
									}
								}
								else
								{
									Led5Digit.serialPort.StopBits = StopBits.One;
								}
							}
							else
							{
								Led5Digit.serialPort.StopBits = StopBits.None;
							}
							result = true;
							return result;
						}
					str2:
						result = false;
						return result;
					}
				strS:
					result = false;
				}
			}
			return result;
		}

		private static void WriteSettingToRegistry()
		{
			LoadRegistry.SetDataToRegistry(6, "LedComNo", Led5Digit.serialPort.PortName);
			string text = Led5Digit.serialPort.BaudRate.ToString() + ",";
			text = text + Led5Digit.serialPort.Parity.ToString().Substring(0, 1) + ",";
			text = text + Led5Digit.serialPort.DataBits.ToString() + ",";
			switch (Led5Digit.serialPort.StopBits)
			{
				case StopBits.None:
					text += "0";
					break;
				case StopBits.One:
					text += "1";
					break;
				case StopBits.Two:
					text += "2";
					break;
				case StopBits.OnePointFive:
					text += "1.5";
					break;
			}
			LoadRegistry.SetDataToRegistry(5, "LedSetting", text);
		}

		public static void Close()
		{
			if (Led5Digit.serialPort.IsOpen)
			{
				Led5Digit.serialPort.Close();
			}
		}
	}

	public static class LoadRegistry
	{
		static GetSetRegistry myRegistry = new GetSetRegistry();

		public static string GetDataFromRegistry(short typefolder, string rName)
		{
			string strCurrentPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\Default";
			switch (typefolder)
			{
				case 1:
					strCurrentPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\Delivery Station Properties";
					break;
				case 2:
					strCurrentPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\Weighing Station Properties";
					break;
				case 3:
					strCurrentPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\DBConnect";
					break;
				case 4:
					strCurrentPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\Report";
					break;
				case 5:
					strCurrentPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\COMConfig";
					break;
				case 6:
					strCurrentPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\StationParameter";
					break;
			}
			return LoadRegistry.myRegistry.GetSringRegistryKey(strCurrentPath, rName);
		}

		public static void SetDataToRegistry(short typefolder, string strKey, string strValue)
		{
			string strPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\Default";
			switch (typefolder)
			{
				case 1:
					strPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\Delivery Station Properties";
					break;
				case 2:
					strPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\Weighing Station Properties";
					break;
				case 3:
					strPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\DBConnect";
					break;
				case 4:
					strPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\Report";
					break;
				case 5:
					strPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\COMConfig";
					break;
				case 6:
					strPath = "HKEY_CURRENT_USER\\Software\\VietRoad\\StationParameter";
					break;
			}
			LoadRegistry.myRegistry.SetRegistryKey(strPath, strKey, strValue);
		}
	}

	public class GetSetRegistry
	{
		public string GetSringRegistryKey(string strCurrentPath, string strCurrentKey)
		{
			string text = (string)Registry.GetValue(strCurrentPath, strCurrentKey, "");
			string result;
			if (text == null)
			{
				result = "";
			}
			else
			{
				result = text;
			}
			return result;
		}
		public void SetRegistryKey(string strPath, string strKey, string strValue)
		{
			Registry.SetValue(strPath, strKey, strValue, RegistryValueKind.String);
		}
	}
}
