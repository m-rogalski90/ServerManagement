using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace HehKurwele.ServerManagement.Networking
{
	internal abstract class BaseServer
	{
		private readonly Thread mWorkerThread;
		private readonly Socket mSocket;
		private volatile bool mIsRunning;

		public bool IsRunning => mIsRunning && mSocket.IsBound;

		protected BaseServer(int port)
		{
			mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			mSocket.Bind(new IPEndPoint(IPAddress.Any, port));
			mWorkerThread = new Thread(WorkerJob);
		}

		protected abstract void OnClientConnected(Socket client);

		private void WorkerJob()
		{
			while (mSocket.IsBound && mIsRunning)
			{
				Socket client = mSocket.Accept();
				if (!(client is null))
				{
					OnClientConnected(client);
				}
			}
		}

		public void Start()
		{
			if (mIsRunning) return;

			mIsRunning = true;
			mSocket.Listen(10);
			mWorkerThread.Start();
		}

		public void Stop()
		{
			if (!mIsRunning) return;

			mIsRunning = false;
			mWorkerThread.Join();
			mSocket.Shutdown(SocketShutdown.Both);
			mSocket.Disconnect(true);
		}
	}
}
