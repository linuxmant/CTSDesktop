using System.Collections.Generic;
using System.ComponentModel;
using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSRest;
using System.Threading;
using Fiehnlab.CTSDesktop.Commands;
using System.Windows;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Threading;
using System;

namespace Fiehnlab.CTSDesktop.ViewModels {
    internal class SplashViewModel : ViewModelBase {
		private IDataSource ctsClient = new IDataSource();
		private BackgroundWorker bgLoad = new BackgroundWorker();

        private List<string> fromValues;
        private List<string> toValues;
        private string version;
        private string status;

        #region Properties
        public List<string> FromValues
		{
			get { return fromValues ?? new List<string>(); }
			private set {
				fromValues = value;
				NotifyPropertyChanged();
			}
		}

		public List<string> ToValues
		{
			get { return toValues ?? new List<string>(); }
			private set {
				this.toValues = value;
				NotifyPropertyChanged();
			}
		}

        public string Version
        {
            get { return version ?? (version = Assembly.GetExecutingAssembly().GetName().Version.ToString()); }
            private set
            {
                version = value;
                NotifyPropertyChanged();
            }
        }

        public string Status
        {
            get { return status ?? "Initializing..."; }
            private set
            {
                status = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        /// <summary>
        /// Creates a new instance of the splash view model to get conversion sources from server
        /// </summary>
        public SplashViewModel() {
            LoadIdNameValuesCommand = new DelegateCommand(LoadIdNameValues);
        }

        private void something() { 

            bgLoad.DoWork += (sender, args) => {
                // call REST service to get toValues and populate properties
                ToValues = ctsClient.GetToValues();
                string msg = string.Format("Loaded {0} TO values", ToValues.Count);
                Status = msg;
                MessageBox.Show(msg);
                Thread.Sleep(1500);
                FromValues = ctsClient.GetFromValues();
                msg = string.Format("Loaded {0} TO values", FromValues.Count);
                Status = msg;
                MessageBox.Show(msg);
                Thread.Sleep(1500);
            };

        }

        #region Commands
        private DelegateCommand loadIdNameValuesCommand;
		public DelegateCommand LoadIdNameValuesCommand
		{
			get { return loadIdNameValuesCommand ?? (loadIdNameValuesCommand = new DelegateCommand(LoadIdNameValues)); }
			private set {
				loadIdNameValuesCommand = value;
				NotifyPropertyChanged();
			}
		}

		private bool CanLoadIdNames(object obj) {
			return (ToValues.Count < 1 && FromValues.Count < 1);
		}

		private void LoadIdNameValues(object obj) {
            bgLoad.RunWorkerAsync();
        }
		#endregion
	}
}
