using System;
using System.Collections.Generic;
using System.Text;

namespace HehKurwele.ServerManagement.ServerBase.Database.Table
{
	public sealed class User
	{
		public long Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public bool Active { get; set; }
		public string Session { get; set; }
	}
}
