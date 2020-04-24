using System;

namespace HehKurwele.ServerManagement.Commons.Messaging.Request
{
	public sealed class PingRequest : BaseMessage
	{
		private DateTime mTimestamp;

		public DateTime Timestamp => mTimestamp;

		public PingRequest() : base(MessageType.PING) { }
		public PingRequest(DateTime timestamp) : base(MessageType.PING)
		{
			mTimestamp = timestamp;
		}
	}
}
