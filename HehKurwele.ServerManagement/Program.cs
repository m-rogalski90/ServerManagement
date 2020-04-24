using HehKurwele.ServerManagement.Networking;
using System;

namespace HehKurwele.ServerManagement
{
	class Program
	{
		// it needs some interface to communicate with OS :/
		static void Main(string[] args)
		{
			Console.WriteLine("No Siema.. Startujemy serwerek :o");
			MessageServer s = new MessageServer();
			s.Start();
			while(s.IsRunning)
			{
				//..
			}
			s.Stop();
		}
	}
}
