namespace HehKurwele.ServerManagement.MessagingServer.Processing
{
	internal static class AuthenticationProcessor
	{
		public static bool TryAuthenticate(string username, string password, out string token)
		{
			token = string.Empty;
			return false;
		}
	}
}
