using System.Text.Json.Serialization;

namespace HehKuerwle.ServerManagement.Commons.Messaging
{
	/// <summary>
	/// Each request should contain:
	///  - type as byte to identify how to deserialize incomming packets
	///  - length of incomming packets 
	///  - buffer that contaisn serialized request data ( user login, configuration data, etc. )
	///  
	/// Maybe add some hashcode to check if message is fine.. ? :|
	/// </summary>
	public abstract class BaseMessage
	{
		public readonly MessageType Type;
		private int mLength;

		public BaseMessage(MessageType type)
		{
			Type = type;
		}

		public int Length
		{
			get => mLength;
			set => mLength = value;
		}

		public bool ShouldSerializeType() => false;
		public bool ShouldSerializeLength() => false;
	}
}
