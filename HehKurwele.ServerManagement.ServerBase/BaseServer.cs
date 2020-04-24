using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace HehKurwele.ServerManagement.ServerBase
{
	public abstract class BaseServer
	{
		protected readonly Socket mSocket;
		protected readonly List<BaseClient> mClientsList;

		public BaseServer(int port)
		{
			mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			mSocket.Bind(new IPEndPoint(IPAddress.Any, port));
			mClientsList = new List<BaseClient>();
		}

		protected abstract void OnClientDisconnected(object sender, EventArgs e);
		protected abstract void OnClientConnected(Socket clientSocket);

		public void Listen()
		{
			mSocket.Listen(10);
			while (mSocket.IsBound)
			{
				Socket client = mSocket.Accept();
				if (!(client is null))
				{
					OnClientConnected(client);
				}
			}
		}

		public void Shutdown()
		{
			mSocket.Shutdown(SocketShutdown.Both);
			mSocket.Disconnect(false);
		}
	}
}
