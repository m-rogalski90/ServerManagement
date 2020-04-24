using HehKurwele.ServerManagement.Networking;
using System;
using System.Threading;

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
				if (!Thread.Yield())
				{
					Thread.SpinWait(100);
				}
			}
			s.Stop();
		}
	}
}
