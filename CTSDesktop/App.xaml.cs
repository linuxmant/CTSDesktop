using System.Windows;
using Fiehnlab.CTSDesktop.Views;
using System;
using Fiehnlab.CTSRest;
using System.Diagnostics;
using Fiehnlab.CTSDesktop.ViewModels;
using System.Threading;
using Fiehnlab.CTSDesktop.Models;

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
			SplashViewModel svm = (SplashViewModel) splash.DataContext;

			try
			{
				// sets main window to 75% of screen size
				MeasureScreenAndSetMainWindowDimensions();

				splash.Show();
				timer.Start();

				svm.Status = "Initializing...";
				MainWindow2 window = new MainWindow2();
				MainWindowViewModel mv = (MainWindowViewModel)window.DataContext;

				// load From values and select default 'Chemical Name'
				mv.FromValuesList =  svm.GetFromValues();
				mv.CurrentFrom = "Chemical Name";

				// load To values and select default 'InChIKey'
				mv.ToValuesList = svm.GetToValues();

				var inchikey = mv.ToValuesList.Find(obj => obj.Name == "InChIKey");
				inchikey.IsSelected = true;
				mv.CurrentTo.Add(inchikey);

				// create main window and 
				window.DataContext = mv;

				var lap = timer.ElapsedMilliseconds;
				while ( lap < SPLASH_TIME)
				{
					Thread.Sleep(10);
					lap = timer.ElapsedMilliseconds;
				}

				timer.Stop();

				window.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			finally
			{
				splash.Close();
			}
		}

		private void MeasureScreenAndSetMainWindowDimensions()
		{
			double height = SystemParameters.MaximizedPrimaryScreenHeight;
			double width = SystemParameters.MaximizedPrimaryScreenWidth;

			MainWindow.Height = height * 0.75;
			MainWindow.Width = width * 0.75;
		}
	}
}
