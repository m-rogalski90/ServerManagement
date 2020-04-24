namespace HehKurwele.ServerManagement.Commons.Messaging.Request
{
	public sealed class AuthenticationRequest : BaseMessage
	{
		private string mUsername;
		private string mPassword;

		public string Username => mUsername;
		public string Password => mPassword;

		public AuthenticationRequest() : base(MessageType.AUTHENTICATE) { }
		public AuthenticationRequest(string username, string password) : base(MessageType.AUTHENTICATE)
		{
			mUsername = username;
			mPassword = password;
		}
	}
}
