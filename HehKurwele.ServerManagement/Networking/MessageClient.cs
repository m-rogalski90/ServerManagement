using System;
using System.Net.Sockets;
using HehKuerwle.ServerManagement.Commons.Messaging;
using HehKuerwle.ServerManagement.Commons.Messaging.Serialization;
using HehKurwele.ServerManagement.RequestProcessor;

namespace HehKurwele.ServerManagement.Networking
{
	internal sealed class MessageClient 
		: BaseClient
	{
		public MessageClient(Socket socket) : base(socket)
		{
			Console.WriteLine($"New message client connected with {socket.RemoteEndPoint.ToString()}");
		}

		protected override void WorkerJob()
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
	}
}
