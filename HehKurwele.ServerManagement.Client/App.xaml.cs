using HehKurwele.ServerManagement.Client.Networking;
using HehKurwele.ServerManagement.Client.View;
using HehKurwele.ServerManagement.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HehKurwele.ServerManagement.Client
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			AuthenticationWindow authWindow = new AuthenticationWindow();
			AuthenticationViewModel authWindowViewModel = new AuthenticationViewModel();
			authWindow.DataContext = authWindowViewModel;
			authWindowViewModel.LoginCompleted += (sender, args) =>
			{
				MainWindow = new MainWindow();
				MainWindow.Show();
				authWindow.Close();
			};
			authWindow.ShowDialog();
		}
	}
}
