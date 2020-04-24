namespace HehKuerwle.ServerManagement.Commons.Messaging.Responses
{
	public sealed class EmptyResponse : BaseMessage
	{
		public EmptyResponse() : base(MessageType.EMPTY) { }
	}
}
