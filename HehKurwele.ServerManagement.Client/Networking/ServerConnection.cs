using HehKurwele.ServerManagement.Commons.Messaging;
using System.Net;
using System.Net.Sockets;

namespace HehKurwele.ServerManagement.Client.Networking
{
	public static class ServerConnection
	{
		static Socket socket;
		static NetworkStream netStream;
		static volatile bool initialized;

		public static void InitializeConnection()
		{
			if (!initialized)
			{
				initialized = true;
				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000));
				netStream = new NetworkStream(socket, false);
			}
		}


		public static BaseMessage SendRequest(BaseMessage request)
		{
			byte[] requestBuffer = Serializer.Serialize(request);
			netStream.Write(requestBuffer, 0, requestBuffer.Length);
			while (!netStream.DataAvailable) { }
			return Serializer.Deserialize(netStream);
		}
	}
}
