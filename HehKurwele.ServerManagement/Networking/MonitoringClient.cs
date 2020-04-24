using System.Net.Sockets;

namespace HehKurwele.ServerManagement.Networking
{
	internal sealed class MonitoringClient
		: BaseClient
	{
		public MonitoringClient(Socket socket) : base(socket)
		{
		}

		protected override void WorkerJob()
		{
			while(IsConnected)
			{
				// gather system informations

			}
			// CPU usage: 8B
			// RAM max: 8B
			// RAM usage: 8B
			// RAM free: 8B
			// HDD max: 8B
			// HDD usage: 8B
			// HDD free: 8B
			// 56B total

			RaiseClientDisconnected();
		}
	}
}
