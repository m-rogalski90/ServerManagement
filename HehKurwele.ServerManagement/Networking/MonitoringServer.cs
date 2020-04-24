using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace HehKurwele.ServerManagement.Networking
{
	internal sealed class MonitoringServer : BaseServer
	{
		public MonitoringServer() : base(8001)
		{

		}

		protected override void OnClientConnected(Socket client)
		{

		}
	}
}
