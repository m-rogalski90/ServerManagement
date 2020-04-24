using HehKurwele.ServerManagement.Commons.Messaging;
using HehKurwele.ServerManagement.MessagingServer.Processing;
using HehKurwele.ServerManagement.ServerBase;
using System.Net.Sockets;

namespace HehKurwele.ServerManagement.MessagingServer
{
	internal sealed class MessageClient : BaseClient
	{
		private readonly MessageProcessor mMessageProcessor;

		public MessageClient(Socket socket) : base(socket) 
		{
			mMessageProcessor = new MessageProcessor();
		}

		protected override void WorkerJob()
		{
			while (IsConnected)
			{
				if (DataAvailable)
				{
					BaseMessage message = Serializer.Deserialize(this);
					BaseMessage response = mMessageProcessor.ProcessRequest(message);
					byte[] responseBuffer = Serializer.Serialize(response);
					Write(responseBuffer);
				}
			}
			RaiseClientDisconnected();
		}
	}
}
