namespace HehKuerwle.ServerManagement.Commons.Monitoring.Packets
{
	public sealed class HealthCheckPacket
	{
		public int CPUUsage { get; set; }
		public long DriveSpaceMax { get; set; }
		public long DriveSpaceFree { get; set; }
		public long DriveSpaceOccupied { get; set; }
		public long RAMMax { get; set; }
		public long RAMFree { get; set; }
		public long RAMUsage { get; set; }
	}
}
