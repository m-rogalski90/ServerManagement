namespace HehKuerwle.ServerManagement.Commons.Messaging.Requests
{
	public sealed class GetConfigurationRequest
		: BaseMessage
	{
		private string mMachineAddress;

		public string MachineAddress => mMachineAddress;

		public GetConfigurationRequest() : base(MessageType.GET_CONFIGURATION) { }
		public GetConfigurationRequest(string machineAddress) : base(MessageType.GET_CONFIGURATION)
		{
			mMachineAddress = machineAddress;
		}
	}
}
