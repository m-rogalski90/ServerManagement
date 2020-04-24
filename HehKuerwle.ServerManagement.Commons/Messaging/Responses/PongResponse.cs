using System;

namespace HehKuerwle.ServerManagement.Commons.Messaging.Responses
{
	public sealed class PongResponse : BaseMessage
	{
		private DateTime mTimestamp;

		public DateTime Timestamp => mTimestamp;

		public PongResponse() : base(MessageType.PONG) { }
		public PongResponse(DateTime timestamp) : base(MessageType.PONG)
		{
			mTimestamp = timestamp;
		}
	}
}
