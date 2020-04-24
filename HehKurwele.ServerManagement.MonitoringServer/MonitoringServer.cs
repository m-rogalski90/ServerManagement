using HehKurwele.ServerManagement.ServerBase;
using System;
using System.Net.Sockets;

namespace HehKurwele.ServerManagement.MonitoringServer
{
	public sealed class MonitoringServer : BaseServer
	{
		public MonitoringServer(int port) : base(port) { }

		protected override void OnClientDisconnected(object sender, EventArgs e)
		{
			if (sender is MonitoringClient)
			{
				MonitoringClient client = sender as MonitoringClient;
				mClientsList.Remove(client);
				client.Dispose();
			}
		}

		protected override void OnClientConnected(Socket clientSocket)
		{
			MonitoringClient client = new MonitoringClient(clientSocket);
			client.ClientDisconnected += OnClientDisconnected;
			mClientsList.Add(client);
			client.HandleClient();
		}

		static void Main(string[] args)
		{
			// get port from cmdargs maybe? or whatever ENVVars something.. 
			int port = 8000;
			MonitoringServer server = new MonitoringServer(port);
			server.Listen();
			server.Shutdown();
		}
	}
}
