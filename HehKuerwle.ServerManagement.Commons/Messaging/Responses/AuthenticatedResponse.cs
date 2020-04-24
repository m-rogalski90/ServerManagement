namespace HehKuerwle.ServerManagement.Commons.Messaging.Responses
{
	public sealed class AuthenticatedResponse : BaseMessage
	{
		private string mUsername;
		private string mAuthenticationKey;

		public string Username => mUsername;
		public string AuthKey => mAuthenticationKey;

		public AuthenticatedResponse() : base(MessageType.AUTHENTICATED) { }
		public AuthenticatedResponse(string username, string authKey) : base(MessageType.AUTHENTICATED)
		{
			mUsername = username;
			mAuthenticationKey = authKey;
		}
	}
}
