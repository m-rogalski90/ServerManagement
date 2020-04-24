namespace HehKurwele.ServerManagement.Client.Model
{
	internal sealed class AuthenticationModel
	{
		private string mUsername;
		private string mPassword;

		public string Username
		{
			get => mUsername;
			set => mUsername = value;
		}


		public string Password
		{
			get => mPassword;
			set => mPassword = value;
		}
	}
}
