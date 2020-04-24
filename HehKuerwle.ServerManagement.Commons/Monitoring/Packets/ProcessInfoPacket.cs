namespace HehKuerwle.ServerManagement.Commons.Monitoring.Packets
{
	public sealed class ProcessInfoPacket
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public int Identifier { get; set; }
		public int CPUUsage { get; set; }
		public long RAMUsage { get; set; }
		public bool Responding { get; set; }
		public bool IsService { get; set; }
	}
}
