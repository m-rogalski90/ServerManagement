using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace HehKurwele.ServerManagement.MessagingServer
{
	public class MessagingServer
	{
		private Socket mSocket;
		private List<MessageClient> mClientsList;

		public MessagingServer(int port)
		{
			mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			mSocket.Bind(new IPEndPoint(IPAddress.Any, port));
			mClientsList = new List<MessageClient>();
		}

		private void OnClientDisconnected(object sender, EventArgs e)
		{
			if (sender is MessageClient)
			{
				MessageClient client = sender as MessageClient;
				mClientsList.Remove(client);
				client.Dispose();
			}
		}

		private void OnClientConnected(Socket clientSocket)
		{
			MessageClient client = new MessageClient(clientSocket);
			client.ClientDisconnected += OnClientDisconnected;
			mClientsList.Add(client);
			client.HandleClient();
		}

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

		private void Shutdown()
		{
			mSocket.Shutdown(SocketShutdown.Both);
			mSocket.Disconnect(false);
		}

		static void Main(string[] args)
		{
			// get port from cmdargs maybe? or whatever ENVVars something.. 
			int port = 8000;
			MessagingServer server = new MessagingServer(port);
			server.Listen();
			server.Shutdown();
		}

		
	}
}
