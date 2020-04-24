using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HehKurwele.ServerManagement.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			//Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			//socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000));
			//PingRequest request = new PingRequest(DateTime.Now);
			//byte[] messageBuffer = MessageSerializer.Serialize(request);
			//string stringMessage = Encoding.UTF8.GetString(messageBuffer);
			//NetworkStream networkStream = new NetworkStream(socket, true);
			//networkStream.Write(messageBuffer, 0, messageBuffer.Length);
			//while(!networkStream.DataAvailable)
			//{
			//	Thread.Sleep(100);
			//}
			//BaseMessage message = MessageSerializer.Deserialize(networkStream);
			//Assert.IsTrue(message.Type == MessageType.PONG);
		}
	}
}
