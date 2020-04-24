using HehKurwele.ServerManagement.Commons.Messaging.Request;
using HehKurwele.ServerManagement.Commons.Messaging.Response;
using System;
using System.Collections.Generic;

namespace HehKurwele.ServerManagement.Commons.Messaging
{
	public static class MessageTypeMapping
	{
		private static readonly Dictionary<MessageType, Type> mMessagesTypeMappings;

		static MessageTypeMapping()
		{
			mMessagesTypeMappings = new Dictionary<MessageType, Type>
			{
				{ MessageType.PING, typeof(PingRequest) },
				{ MessageType.AUTHENTICATE, typeof(AuthenticationRequest) },

				{ MessageType.PONG, typeof(PongResponse) },
				{ MessageType.OK, typeof(OkResponse) },
				{ MessageType.EMPTY, typeof(EmptyResponse) },
				{ MessageType.AUTHENTICATED, typeof(AuthenticatedResponse) }
			};
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
