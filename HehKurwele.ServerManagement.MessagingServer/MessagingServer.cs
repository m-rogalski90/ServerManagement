using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace HehKurwele.ServerManagement.MessagingServer
{
	/// <summary>
	/// MessagingServer - taki serwerek do ogarniania requestow z urządzeń podłączonych.
	/// Idea jest taka, że mamy określony zestaw requestów i responsów dla każdej mozliwej akcji
	/// całą komunikację będziemy musieli zaczynać od "PING-PONG" ( chyba ) żeby zobaczyć czy 
	/// serwer jest alive. Jeżeli nie dostaniemy odpowiedzi PONG to znaczy że serwer zdechł i trzeba 
	/// poczekać aż się znowu uruchomi.. taki health check dla tego serwera
	/// Później trzeba by zrobic autentykację .. jak? chuj nie wiem i na razie mnie to jebie..
	/// 
	/// Po autentykacji użytkownik powinien dostać jakiś token, klucz, identyfikator czy inne coś
	/// każdy request powinien zawierać ten klucz autentykacyjny i sam klucz powinien być odświeżany 
	/// co jakiś czas albo nie wiem .. trzeba będzie śledzić czy przyszedł z tego samego socketa..? 
	/// 
	/// Requesty powinny zawierać coś co wymaga większych uprawnień coś jak "wystartujSerwisX_Request"
	/// każde inne takie jak health check powinny być użyte w innym typie aplikacji :
	/// HehKurwele.ServerManagement.MonitoringServer ( nazwa może ulec zmianie bo.. tak! )
	/// </summary>
	class MessagingServer
	{
		private Socket mSocket;
		private List<MessageClient> mClientsList;

		public MessagingServer(int port)
		{
			mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			mSocket.Bind(new IPEndPoint(IPAddress.Any, port));
			mClientsList = new List<MessageClient>();
		}

		private void OnClientDisconnected(object sender, EventArgs e)
		{
			if (sender is MessageClient)
			{
				MessageClient client = sender as MessageClient;
				mClientsList.Remove(client);
				client.Dispose();
			}
		}

		private void OnClientConnected(Socket clientSocket)
		{
			MessageClient client = new MessageClient(clientSocket);
			client.ClientDisconnected += OnClientDisconnected;
			mClientsList.Add(client);
			client.HandleClient();
		}

		public void Listen()
		{
			mSocket.Listen(10);
			while (mSocket.IsBound)
			{
				Socket client = mSocket.Accept();
				if (!(client is null))
				{
					OnClientConnected(client);
				}
			}
		}

		private void Shutdown()
		{
			mSocket.Shutdown(SocketShutdown.Both);
			mSocket.Disconnect(false);
		}

		static void Main(string[] args)
		{
			// get port from cmdargs maybe? or whatever ENVVars something.. 
			int port = 8000;
			MessagingServer server = new MessagingServer(port);
			server.Listen();
			server.Shutdown();
		}

		
	}
}
