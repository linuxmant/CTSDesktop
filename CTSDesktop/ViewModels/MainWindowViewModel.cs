using System.Collections.Generic;
using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSRest;
using Fiehnlab.CTSDesktop.Commands;
using System.Windows;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Data;
using System.Globalization;

namespace Fiehnlab.CTSDesktop.ViewModels {
    class MainWindowViewModel : ViewModelBase {
		private List<string> fromValues;
		private List<string> toValues;
        private string currentFrom;
        private List<string> currentTo = new List<string>();
        private string currentStep = "home";

        private readonly CtsRestClient ctsClient = new CtsRestClient();

        public Action CloseAction { get; set; }

        private BackgroundWorker bgWorker;


        public MainWindowViewModel() {
            bgWorker = new BackgroundWorker();

            bgWorker.DoWork += new DoWorkEventHandler ((s, args) => loadToValues(s, args));
            bgWorker.DoWork += new DoWorkEventHandler((s, args) => loadFromValues(s, args));

            bgWorker.RunWorkerAsync();

			currentTo.Add("InChIKey");
		}

        #region BackgroundWorker definition

        private void loadToValues(object sender, DoWorkEventArgs args) {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            ToValues = ctsClient.GetToValues();
            timer.Stop();
			//check 'InChiKey' by default

        }

        private void loadFromValues(object sender, DoWorkEventArgs args) {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            FromValues = ctsClient.GetFromValues();
            timer.Stop();

			//select 'chemical name' by default
			CurrentFrom = FromValues.Find(e => e.ToLower() == "chemical name");
        }
        #endregion

        #region Properties
        /// <summary>
        /// FromValues property accessors
        /// </summary>
        public List<string> FromValues
		{
			get { return fromValues; }
			set {
				this.fromValues = value;
				NotifyPropertyChanged();
			}
		}

        public string CurrentFrom {
            get { return currentFrom; }
            set {
                currentFrom = value;
                NotifyPropertyChanged();
            }
        }

        public List<string> CurrentTo
        {
            get { return currentTo; }
            set { currentTo = value;
                NotifyPropertyChanged();
            }
        }

		/// <summary>
		/// ToValues property accessors
		/// </summary>
		public List<string> ToValues
		{
			get { return toValues; }
			set
			{
				this.toValues = value;
				NotifyPropertyChanged();
			}
		}

        public CtsRestClient CtsClient { get; set; }

        #endregion

        #region Commands
        private DelegateCommand loadIdNameValues;
        public DelegateCommand LoadIdNameValues
        {
            //get { return loadIdNameValues ?? (loadIdNameValues = new DelegateCommand(s => { loadToValues(this, null); loadFromValues(this, null); })); }
            get { return loadIdNameValues ?? (loadIdNameValues = new DelegateCommand(s => bgWorker.RunWorkerAsync())); }
        }

        private DelegateCommand closeCommand;
        public DelegateCommand CloseCommand
        {
            get { return closeCommand ?? (closeCommand = new DelegateCommand(s => Close(s))); }
        }

        public bool CanClose(object s) {
            Debug.Print(s.GetType().Name);
            return true;
        }

        protected void Close(object s) {
            CloseAction();
        }

        private DelegateCommand convertCommand;
        public DelegateCommand ConvertCommand
        {
            get { return convertCommand ?? (convertCommand = new DelegateCommand(s => loadFromValues(this, null))); }
        }
		#endregion

		#region ValueConverters
		public class ItemNumberConverter : IValueConverter {
			public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
				return String.Format("Items: {0}", value);
			}

			public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
				return value;
			}
		}
		#endregion
	}
}
