using System;
using HehKurwele.ServerManagement.Client.Model;
using System.ComponentModel;
using System.Windows.Input;
using HehKurwele.ServerManagement.Client.Commands;
using HehKurwele.ServerManagement.Client.Networking;
using HehKuerwle.ServerManagement.Commons.Messaging.Requests;
using HehKuerwle.ServerManagement.Commons.Messaging.Responses;
using System.Windows.Controls;
using HehKuerwle.ServerManagement.Commons.Messaging;

namespace HehKurwele.ServerManagement.Client.ViewModel
{
	public sealed class AuthenticationViewModel
		: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public event EventHandler LoginCompleted;
		
		private ICommand mAuthenticateCommand;
		private AuthenticationModel mAuthenticationModel;
		
		public AuthenticationViewModel()
		{
			mAuthenticationModel = new AuthenticationModel();
		}

		public ICommand AuthenticateCommand
		{
			get
			{
				if (mAuthenticateCommand == null)
				{
					mAuthenticateCommand = new CommandBase(
					    param => Authenticate(param)
					);
				}
				return mAuthenticateCommand;
			}
		}

		private bool CanAuthenticate(object password)
		{
			if (!(password is string)) return false;

			return !string.IsNullOrEmpty((string)password) && !string.IsNullOrEmpty(mAuthenticationModel.Username);
		}

		private void Authenticate(object passwordBox)	
		{
			if (!(passwordBox is PasswordBox)) return;

			ServerConnection.InitializeConnection();
			BaseMessage response = ServerConnection.SendRequest(
				new AuthenticationRequest(mAuthenticationModel.Username, (passwordBox as PasswordBox).Password)
			);
			if (response is AuthenticationResponse)
			{
				RaiseLoginCompletedEvent();
			}
		}

		public string Username
		{
			get => mAuthenticationModel.Username;
			set
			{
				mAuthenticationModel.Username = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
			}
		}


		public string Password
		{
			get => mAuthenticationModel.Password;
			set
			{
				mAuthenticationModel.Password = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
			}
		}

		private void RaiseLoginCompletedEvent()
		{
			EventHandler handler = LoginCompleted;
			handler?.Invoke(this, EventArgs.Empty);
		}
	}
}
