namespace HehKurwele.ServerManagement.Commons.Messaging
{
	public enum MessageType : byte
	{
		EMPTY = 0x00,
		PING = 0x01,
		PONG = 0x02,
		AUTHENTICATE = 0x03,
		AUTHENTICATED = 0x04,
		OK = 0x05,
	}
}
