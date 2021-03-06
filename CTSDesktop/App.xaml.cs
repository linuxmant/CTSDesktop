﻿using System.Windows;
using Fiehnlab.CTSDesktop.Views;
using System;
using System.Diagnostics;
using Fiehnlab.CTSDesktop.ViewModels;
using System.Threading;
using Fiehnlab.CTSDesktop.Data;
using Fiehnlab.CTSRest;
using System.ComponentModel;
using Fiehnlab.CTSDesktop.Models;
using Fiehnlab.CTSDesktop.Design;

namespace Fiehnlab.CTSDesktop {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private long SPLASH_TIME = 2000;
        private IDataService dataSource;

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) {
                dataSource = new DesignDataServiceImpl();
            } else {
                dataSource = new CtsDataServiceClient(new CtsRestClient());
            }

            Stopwatch timer = new Stopwatch();
            SplashViewModel svm = new SplashViewModel();
            SplashView splash = new SplashView();
            splash.DataContext = svm;

			try
			{
				// sets main window to 75% of screen size
				MeasureScreenAndSetMainWindowDimensions();

				splash.Show();
				timer.Start();

				svm.Status = "Initializing...";
                MainWindowViewModel mv = new MainWindowViewModel(dataSource);
                MainWindow2 window = new MainWindow2();
                window.DataContext = mv;

                var cn = mv.FromValuesList.Find(obj => obj.Name == "Chemical Name");
                cn.IsSelected = true;
                mv.CurrentFrom = cn;

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
				MessageBox.Show("[App Startup] Error: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
			}
            finally {
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
