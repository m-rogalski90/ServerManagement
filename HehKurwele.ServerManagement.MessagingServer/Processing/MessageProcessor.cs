using HehKurwele.ServerManagement.Commons.Messaging;
using HehKurwele.ServerManagement.Commons.Messaging.Request;
using HehKurwele.ServerManagement.Commons.Messaging.Response;
using System;

namespace HehKurwele.ServerManagement.MessagingServer.Processing
{
	internal class MessageProcessor
	{
		private string mAuthenticationToken;

		public BaseMessage ProcessRequest(BaseMessage request)
		{
			MessageType requestType = request.Type;
			switch (requestType)
			{
				case MessageType.PING:
					Console.WriteLine($"Timestamp {(request as PingRequest).Timestamp}");
					return new PongResponse(DateTime.Now);

				case MessageType.AUTHENTICATE:
					if (!(request is AuthenticationRequest authenticationRequest)) return new EmptyResponse();

					bool authenticated = AuthenticationProcessor.TryAuthenticate(
						authenticationRequest.Username, 
						authenticationRequest.Password,
						out string authenticationToken
					);
					if (authenticated)
					{
						mAuthenticationToken = authenticationToken;
						return new AuthenticatedResponse(authenticationRequest.Username, authenticationToken);
					}
					break;
			}
			return new EmptyResponse();
		}
	}
}
