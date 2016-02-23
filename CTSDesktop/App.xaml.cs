using System.Windows;
using Fiehnlab.CTSDesktop.Views;
using System;
using Fiehnlab.CTSRest;
using System.Diagnostics;
using Fiehnlab.CTSDesktop.ViewModels;
using System.Threading;

namespace Fiehnlab.CTSDesktop
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {
        private long SPLASH_TIME = 2000;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

            Stopwatch timer = new Stopwatch();
            SplashView splash = new SplashView();
            MainWindow window = new MainWindow();
            MainWindowViewModel mv = window.DataContext as MainWindowViewModel;

            timer.Start();
            CtsRestClient cli = new CtsRestClient();
            splash.ShowDialog();
            var from = cli.GetFromValues();
            var to = cli.GetToValues();

            long diff = SPLASH_TIME - timer.ElapsedMilliseconds;
            if (diff > 0) {
                Thread.Sleep((int)diff);
            }
            timer.Stop();
            splash.Close();

            window.ShowDialog();
		}
	}
}
