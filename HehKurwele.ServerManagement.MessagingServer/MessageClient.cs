using HehKuerwle.ServerManagement.Commons.Messaging;
using HehKuerwle.ServerManagement.Commons.Messaging.Serialization;
using System;
using System.Net.Sockets;
using System.Threading;

namespace HehKurwele.ServerManagement.MessagingServer
{
	class MessageClient : NetworkStream
	{
		public event EventHandler ClientDisconnected;

		private readonly Socket mSocket;
		private Thread mWorkerThread;

		public bool IsConnected => Connected();

		public MessageClient(Socket socket) : base(socket, true)
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

		private void WorkerJob()
		{
			while (IsConnected)
			{
				if (DataAvailable)
				{
					BaseMessage message = MessageSerializer.Deserialize(this);
					BaseMessage response = MessageProcessor.ProcessRequest(message);
					byte[] responseBuffer = MessageSerializer.Serialize(response);
					Write(responseBuffer);
				}
			}
			RaiseClientDisconnected();
		}

		protected void RaiseClientDisconnected()
		{
			EventHandler handler = ClientDisconnected;
			handler?.Invoke(this, EventArgs.Empty);
			Console.WriteLine($"Client {mSocket.ToString()} disconnected.");
		}
	}
}
