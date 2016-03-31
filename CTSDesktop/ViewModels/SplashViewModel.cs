using Fiehnlab.CTSDesktop.Models;
using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSRest;
using System.Collections.Generic;
using System.Threading;

namespace Fiehnlab.CTSDesktop.ViewModels {

    internal class SplashViewModel : ViewModelBase {
		#region Member vars
		private string appVersion = "{version}";
		private string status = "{status}";
		private ICtsRestClient cli;
        private List<IDSource> fromValues = new List<IDSource>();
        private List<IDSource> toValues = new List<IDSource>();
        #endregion

        #region Properties
        public string AppVersion
		{
			get { return appVersion; }
			set
			{
				appVersion = value;
				NotifyPropertyChanged();
			}
		}

		public string Status
		{
			get { return status; }
			set
			{
				status = value;
				NotifyPropertyChanged();
			}
		}

        public List<IDSource> FromValues
        {
            get { return fromValues; }
            set
            {
                fromValues = value;
                NotifyPropertyChanged();
            }
        }

        public List<IDSource> ToValues
        {
            get { return toValues; }
            set
            {
                toValues = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        /// <summary>
        /// Creates a new instance of a SplashViewModel
        /// </summary>
        public SplashViewModel() {
			AppVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

			Status = "Initializing...";
			cli = new CtsRestClient();
		}

		public void GetFromValues()
		{
			Status = "Loading From values...";
            List<IDSource> newFrom = new List<IDSource>();
            foreach(string name in cli.GetIdNames(true)) {
                FromValues.Add(new IDSource(name));
            }
            //return newFrom;
		}

		public void GetToValues()
		{
			Status = "Loading To values...";
			foreach (string name in cli.GetIdNames())
			{
				ToValues.Add(new IDSource(name));
			}
		}
	}
}
