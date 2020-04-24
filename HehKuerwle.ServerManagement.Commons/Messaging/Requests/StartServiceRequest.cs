namespace HehKuerwle.ServerManagement.Commons.Messaging.Requests
{
	public sealed class StartServiceRequest : BaseMessage
	{
		private string mAuthenticationKey;
		private int mServiceId;

		public string AuthKey => mAuthenticationKey;
		public int ServiceId => mServiceId;

		public StartServiceRequest() : base(MessageType.START_SERVICE) { }
		public StartServiceRequest(int serviceId, string authKey) : base(MessageType.START_SERVICE)
		{
			mAuthenticationKey = authKey;
			mServiceId = serviceId;
		}
	}
}
