namespace HehKurwele.ServerManagement.Commons.Messaging.Response
{
	public sealed class EmptyResponse : BaseMessage
	{
		public EmptyResponse() : base(MessageType.EMPTY) { }
	}
}
