using HehKurwele.ServerManagement.ServerBase;
using System.Net.Sockets;

namespace HehKurwele.ServerManagement.MonitoringServer
{
	internal sealed class MonitoringClient : BaseClient
	{
		public MonitoringClient(Socket socket) : base(socket) { }

		protected override void WorkerJob()
		{
		}
	}
}
