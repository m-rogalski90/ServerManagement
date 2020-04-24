namespace HehKurwele.ServerManagement.Commons.Messaging
{
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
