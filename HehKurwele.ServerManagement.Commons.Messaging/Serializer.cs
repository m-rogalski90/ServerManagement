using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace HehKurwele.ServerManagement.Commons.Messaging
{
	public static class Serializer
	{
		public static BaseMessage Deserialize(NetworkStream netStream)
		{
			byte type = (byte)netStream.ReadByte();
			return Deserialize(netStream, type);
		}

		public static BaseMessage Deserialize(NetworkStream netStream, byte type)
		{
			byte[] lenBuffer = new byte[sizeof(int)];
			netStream.Read(lenBuffer, 0, sizeof(int));
			return Deserialize(netStream, type, BitConverter.ToInt32(lenBuffer));
		}

		public static BaseMessage Deserialize(NetworkStream netStream, byte type, int len)
		{
			if (type == 0xFF) return null;

			byte[] buffer = new byte[len];
			netStream.Read(buffer, 0, len);
			string jsonMessage = Encoding.UTF8.GetString(buffer);
			Type requestType = MessageTypeMapping.GetMessageType((MessageType)type);
			using TextReader reader = new StringReader(jsonMessage);
			return (BaseMessage)Newtonsoft.Json.JsonSerializer.Create().Deserialize(reader, requestType);
		}

		public static byte[] Serialize(BaseMessage request)
		{
			List<byte> temp = new List<byte>();
			using (TextWriter writer = new StringWriter())
			{
				Newtonsoft.Json.JsonSerializer.Create().Serialize(writer, request);
				temp.AddRange(Encoding.UTF8.GetBytes(writer.ToString()));
			}

			temp.InsertRange(0, BitConverter.GetBytes(temp.Count));
			temp.Insert(0, (byte)request.Type);

			return temp.ToArray();
		}
	}
}
