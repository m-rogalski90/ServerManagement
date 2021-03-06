﻿using System;
using System.Net.Sockets;
using HehKurwele.ServerManagement.ServerBase;

namespace HehKurwele.ServerManagement.MessagingServer
{
	public sealed class MessagingServer : BaseServer
	{
		public MessagingServer(int port) : base(port) { }

		protected override void OnClientDisconnected(object sender, EventArgs e)
		{
			if (sender is MessageClient)
			{
				MessageClient client = sender as MessageClient;
				mClientsList.Remove(client);
				client.Dispose();
			}
		}

		protected override void OnClientConnected(Socket clientSocket)
		{
			MessageClient client = new MessageClient(clientSocket);
			client.ClientDisconnected += OnClientDisconnected;
			mClientsList.Add(client);
			client.HandleClient();
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
