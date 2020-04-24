namespace HehKuerwle.ServerManagement.Commons.Messaging.Responses
{
	public sealed class AuthenticationResponse : BaseMessage
	{
		private string mAuthenticationKey;

		public string AuthKey => mAuthenticationKey;

		public AuthenticationResponse() : base(MessageType.AUTHENTICATED) { }
		public AuthenticationResponse(string authKey) : base(MessageType.AUTHENTICATED)
		{
			mAuthenticationKey = authKey;
		}
	}
}
