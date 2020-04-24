using System;
using System.Collections.Generic;
using System.Text;

namespace HehKuerwle.ServerManagement.Commons.Monitoring.Packets
{
	public sealed class ProcessesPacket
	{
		public sealed class Process
		{
			public string Name { get; set; }
			public string Location { get; set; }
			public int Identifier { get; set; }
		}

		public List<Process> Processes { get; set; }
	}
}
