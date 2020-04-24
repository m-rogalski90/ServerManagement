using HehKuerwle.ServerManagement.Commons.Messaging;
using HehKuerwle.ServerManagement.Commons.Messaging.Requests;
using HehKuerwle.ServerManagement.Commons.Messaging.Responses;
using System;

namespace HehKurwele.ServerManagement.MessagingServer.Processing
{
	internal class MessageProcessor
	{
		private string AuthenticationToken;

		public BaseMessage ProcessRequest(BaseMessage request)
		{
			MessageType requestType = request.Type;
			switch (requestType)
			{
				case MessageType.PING:
					Console.WriteLine($"Timestamp {(request as PingRequest).Timestamp}");
					return new PongResponse(DateTime.Now);

				case MessageType.AUTHENTICATE:
					AuthenticationRequest authenticationRequest = request as AuthenticationRequest;
					if (authenticationRequest is null) return new EmptyResponse();

					bool authenticated = AuthenticationProcessor.TryAuthenticate(
						authenticationRequest.Username, 
						authenticationRequest.Password,
						out string authenticationToken
					);
					if (authenticated)
					{
						return new AuthenticatedResponse(authenticationRequest.Username, authenticationToken);
					}
					break;

				case MessageType.START_SERVICE:
					StartServiceRequest startService = request as StartServiceRequest;
					if (startService is null) return new EmptyResponse();

					if (startService.AuthKey == "NoSiema" && startService.ServiceId == 1337)
					{
						return new OkResponse("Działa dobrze mordeczko!");
					}
					break;
			}
			return new EmptyResponse();
		}
	}
}
