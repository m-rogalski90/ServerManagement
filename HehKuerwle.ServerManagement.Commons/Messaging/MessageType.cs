namespace HehKuerwle.ServerManagement.Commons.Messaging
{
	public enum MessageType : byte
	{
		EMPTY = 0x00,
		PING = 0x01,
		PONG = 0x02,
		AUTHENTICATE = 0x03,
		AUTHENTICATED = 0x04,
		GET_CONFIGURATION = 0x05,
		START_SERVICE = 0x10,
		OK = 0x13,
	}
}
