using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using RosySystem.Common;

namespace RosyModule
{
	public static class Level2Emu
	{
		private const int StableCount = 5;
		public static SerialPort serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.Two);

		public static string strPortName;
		private static int weight;
		private static int old_weight = 0;
		private static Timer myTimer = new Timer();
		private static int s_count = 5;
		private static bool isStable = false;
		private static double OldWeight;
		private static byte[] buf = new byte[4];
		private static int iStatus;

		public static double Weight
		{
			get
			{
				return (double)Level2Emu.weight;
			}
			set
			{
				Level2Emu.weight = Convert.ToInt32(value);
				if (Level2Emu.weight == Level2Emu.old_weight)
				{
					if (Level2Emu.s_count > 0)
					{
						Level2Emu.s_count--;
					}
					else
					{
						Level2Emu.isStable = true;
					}
				}
				else
				{
					Level2Emu.s_count = 5;
					Level2Emu.isStable = false;
				}
				Level2Emu.old_weight = Level2Emu.weight;
			}
		}

		public static bool Init()
		{
			if (Level2Emu.serialPort.IsOpen)
			{
				Level2Emu.serialPort.Close();
			}
			if (Level2Emu.strPortName != "")
			{
				Level2Emu.serialPort.PortName = Level2Emu.strPortName;
			}
			bool result;
			try
			{
				Level2Emu.serialPort.Open();
				Level2Emu.myTimer.Interval = 230;
				Level2Emu.myTimer.Tick -= new EventHandler(Level2Emu.myTimer_Tick);
				Level2Emu.myTimer.Tick += new EventHandler(Level2Emu.myTimer_Tick);
				Level2Emu.myTimer.Start();
			}
			catch (Exception ex)
			{
				Level2Emu.myTimer.Stop();
				Common.MsgCancel("Can not Init Level 2 Emulation " + ex.Message.ToString());
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		public static void Close()
		{
			Level2Emu.myTimer.Stop();
			if (Level2Emu.serialPort.IsOpen)
			{
				Level2Emu.serialPort.Close();
			}
		}

		private static void myTimer_Tick(object sender, EventArgs e)
		{
			if (Level2Emu.serialPort.IsOpen)
			{
				Level2Emu.SendWeightM817(Level2Emu.Weight);
				Level2Emu.OldWeight = Level2Emu.Weight;
			}
		}

		public static void SendWeightM817(double weight)
		{
			short value = Convert.ToInt16(weight);
			byte[] bytes = BitConverter.GetBytes(value);
			if (weight == Level2Emu.OldWeight)
			{
				Level2Emu.iStatus = 4;
			}
			else
			{
				Level2Emu.iStatus = 2;
			}
			byte[] bytes2 = BitConverter.GetBytes((short)Level2Emu.iStatus);
			byte[] array = new byte[]
			{
				bytes2[1],
				bytes2[0],
				bytes[1],
				bytes[0]
			};
			Level2Emu.serialPort.Write(array, 0, array.Length);
		}
	}
}
