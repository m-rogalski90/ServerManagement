using System;
using System.Net.Sockets;
using System.Collections.Generic;

namespace HehKurwele.ServerManagement.Networking
{
	internal sealed class MessageServer
		: BaseServer
	{
		private readonly List<MessageClient> mClientList;

		public MessageServer() : base(8000)
		{
			mClientList = new List<MessageClient>();
		}

		protected override void OnClientConnected(Socket clientSocket)
		{
			MessageClient client = new MessageClient(clientSocket);
			client.ClientDisconnected += OnClientDisconnected;
			mClientList.Add(client);
			client.HandleClient();
		}

		private void OnClientDisconnected(object sender, EventArgs e)
		{
			if (sender is MessageClient)
			{
				MessageClient client = sender as MessageClient;
				mClientList.Remove(client);
				client.Dispose();
			}
		}
	}
}
