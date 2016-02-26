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
		private CtsRestClient cli;
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
		#endregion

		/// <summary>
		/// Creates a new instance of a SplashViewModel
		/// </summary>
		public SplashViewModel() {
			AppVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

			Status = "Initializing...";
			cli = new CtsRestClient();
		}

		public List<string> GetFromValues()
		{
			Status = "Loading From values...";
			return cli.GetFromValues();
		}

		public List<IDSource> GetToValues()
		{
			Status = "Loading To values...";
			List<IDSource> dest = new List<IDSource>();
			var list = cli.GetToValues();
			foreach (var li in list)
			{
					dest.Add(new IDSource(li));
			}

			return dest;
		}
	}
}
