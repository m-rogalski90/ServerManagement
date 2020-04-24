using System;
using System.Net.Sockets;
using System.Threading;

namespace HehKurwele.ServerManagement.ServerBase
{
	public abstract class BaseClient : NetworkStream
	{
		public event EventHandler ClientDisconnected;

		private readonly Socket mSocket;
		private Thread mWorkerThread;

		public bool IsConnected => Connected();

		public BaseClient(Socket socket) : base(socket, true)
		{
			mSocket = socket;
			mWorkerThread = new Thread(WorkerJob);
		}

		private bool Connected()
		{
			try
			{
				return !(mSocket.Poll(1, SelectMode.SelectRead) && mSocket.Available == 0);
			}
			catch (SocketException) { return false; }
		}

		public void HandleClient()
		{
			mWorkerThread.Start();
		}

		protected abstract void WorkerJob();

		protected void RaiseClientDisconnected()
		{
			EventHandler handler = ClientDisconnected;
			handler?.Invoke(this, EventArgs.Empty);
			Console.WriteLine($"Client {mSocket.ToString()} disconnected.");
		}
	}
}
