using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RosyModule
{
	public class TcpConnection : IDisposable
	{
		public static readonly int ReceivedDataBufferSize = 65535;

		public Socket Client
		{
			get
			{
				return mClient;
			}
		}

		public BinaryReader Reader
		{
			get
			{
				return mReader;
			}
		}

		public BinaryWriter Writer
		{
			get
			{
				return mWriter;
			}
		}

		public byte[] ReceivedDataBuffer
		{
			get
			{
				return mReceivedDataBuffer;
			}
		}

		public byte[] ReceivedData
		{
			get
			{
				return mReceivedData.ToArray();
			}
		}

		public object Tag
		{
			get
			{
				return mTag;
			}
			set
			{
				mTag = value;
			}
		}

		public TcpConnection(Socket client, AsyncCallback dataReceivedCallback)
		{
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}

			mClient = client;
			mNetworkStream = new NetworkStream(client);
			mReader = new BinaryReader(mNetworkStream);
			mWriter = new BinaryWriter(mNetworkStream);
			mReceivedDataBuffer = new byte[ReceivedDataBufferSize];
			mReceivedData = new List<byte>();
			InitDataReceivedCallback(dataReceivedCallback);
		}

		public void InitDataReceivedCallback(AsyncCallback dataReceivedCallback)
		{
			if (dataReceivedCallback != null)
			{
				mDataReceivedCallback = dataReceivedCallback;
				mClient.BeginReceive(mReceivedDataBuffer, 0, mReceivedDataBuffer.Length, SocketFlags.None, mDataReceivedCallback, this);
			}
			else
			{
				mDataReceivedCallback = null;
			}
		}
	
		public void Dispose()
		{
			if (mIsClosed == false)
			{
				mReader.Close();
				mWriter.Close();
				mNetworkStream.Close();
				if (mClient.Connected)
				{
					mClient.Shutdown(SocketShutdown.Both);
					mClient.Close();
				}

				mDataReceivedCallback = null;
				mIsClosed = true;
			}
		}

		public void AppendReceivedData(IEnumerable<byte> data)
		{
			mReceivedData.AddRange(data);
		}

		public void AppendReceivedData(ArraySegment<byte> data)
		{
			mReceivedData.AddRange(data.Array);
		}

		public void ClearReceivedData()
		{
			lock (mReceivedData)
			{
				mReceivedData.Clear();
			}
		}

		private Socket mClient;
		private NetworkStream mNetworkStream;
		private BinaryReader mReader;
		private BinaryWriter mWriter;
		private AsyncCallback mDataReceivedCallback;
		private byte[] mReceivedDataBuffer;
		private List<byte> mReceivedData;
		private bool mIsClosed;
		private object mTag;
	}
}
