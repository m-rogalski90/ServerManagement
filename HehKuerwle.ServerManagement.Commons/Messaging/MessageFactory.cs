using HehKuerwle.ServerManagement.Commons.Messaging.Requests;
using HehKuerwle.ServerManagement.Commons.Messaging.Responses;
using System;
using System.Collections.Generic;

namespace HehKuerwle.ServerManagement.Commons.Messaging
{
	public static class MessageFactory
	{
		private static Dictionary<MessageType, Type> mMessagesTypeMappings;

		static MessageFactory()
		{
			mMessagesTypeMappings = new Dictionary<MessageType, Type>();
			mMessagesTypeMappings.Add(MessageType.PING, typeof(PingRequest));
			mMessagesTypeMappings.Add(MessageType.START_SERVICE, typeof(StartServiceRequest));
			mMessagesTypeMappings.Add(MessageType.AUTHENTICATE, typeof(AuthenticationRequest));

			mMessagesTypeMappings.Add(MessageType.PONG, typeof(PongResponse));
			mMessagesTypeMappings.Add(MessageType.OK, typeof(OkResponse));
			mMessagesTypeMappings.Add(MessageType.EMPTY, typeof(EmptyResponse));
			mMessagesTypeMappings.Add(MessageType.AUTHENTICATED, typeof(AuthenticatedResponse));
		}

		public static Type GetMessageType(MessageType type)
		{
			if (mMessagesTypeMappings.ContainsKey(type))
			{
				return mMessagesTypeMappings[type];
			}
			return null;
		}
	}
}
