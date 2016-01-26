using System.Collections.Generic;
using System.ComponentModel;
using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSDesktop.Views;
using Fiehnlab.CTSRest;
using System.Threading;
using System.Windows.Input;
using Fiehnlab.CTSDesktop.Commands;
using System;
using System.Windows;
using System.Reflection;
using System.Diagnostics;

namespace Fiehnlab.CTSDesktop.ViewModels {
	internal class SplashViewModel : ViewModelBase {
		private CtsRestClient ctsClient = new CtsRestClient();
		private BackgroundWorker bgWorker = new BackgroundWorker();

		#region Properties
		private List<string> fromValues;
		public List<string> FromValues
		{
			get { return fromValues; }
			private set {
				fromValues = value;
				NotifyPropertyChanged("FromValues");
			}
		}

		private List<string> toValues;
		public List<string> ToValues
		{
			get { return toValues; }
			private set {
				this.toValues = value;
				NotifyPropertyChanged("ToValues");
			}
		}

		private string version;
		public string Version {
			get { return version; }
			private set {
				version = value;
				NotifyPropertyChanged("Version");
			} 
		}
		#endregion

		/// <summary>
		/// Creates a new instance of the splash view model to get conversion sources from server
		/// </summary>
		public SplashViewModel(SplashView splash) {
			MessageBox.Show("creating VM");
			Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

			loadIdNameValuesCommand = new DelegateCommand(LoadIdNameValues, CanLoadIdNames);
			showMessageCommand = new DelegateCommand((s) => { Debug.Print(string.Format("Message: {0}", s.ToString())); }, (s) => { return splash.IsLoaded; });
			showMessageCommand.RaiseCanExecuteChanged();

			splash.Show();

			Thread.Sleep(1000);

			splash.Close();
		}

		#region Commands
		private DelegateCommand loadIdNameValuesCommand;
		public DelegateCommand LoadIdNameValuesCommand
		{
			get
			{
				if (loadIdNameValuesCommand == null) {
					loadIdNameValuesCommand = new DelegateCommand(LoadIdNameValues, CanLoadIdNames);
				}
				return loadIdNameValuesCommand;
			}
			private set {
				loadIdNameValuesCommand = value;
				NotifyPropertyChanged("LoadIdNameValuesCommand");
			}
		}

		private bool CanLoadIdNames(object obj) {
			return (ToValues.Count <=0 && FromValues.Count <=0);
		}

		private void LoadIdNameValues(object obj) {
			// call REST service to get toValues and populate properties
			MessageBox.Show("about to laod stuff...");
			ToValues = ctsClient.GetToValues();
			MessageBox.Show("laoded ToValues...");
			Thread.Sleep(2000);
			FromValues = ctsClient.GetFromValues();
			MessageBox.Show("laoded FromValues...");
			Thread.Sleep(2000);
			MessageBox.Show("done laoding stuff...");
		}


		private readonly DelegateCommand showMessageCommand;
		public DelegateCommand ShowMessageCommand
		{
			get { return showMessageCommand;  }
		}

		#endregion
	}
}
