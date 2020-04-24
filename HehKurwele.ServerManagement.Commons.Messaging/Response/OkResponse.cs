namespace HehKurwele.ServerManagement.Commons.Messaging.Response
{
	public sealed class OkResponse : BaseMessage
	{
		private string mMessage;
		public string Message => mMessage;

		public OkResponse() : base(MessageType.OK) { }
		public OkResponse(string message) : base(MessageType.OK)
		{
			mMessage = message;
		}
	}
}
