using System.Collections.Generic;
using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSDesktop.Views;
using System.Threading;
using System.Windows;
using Fiehnlab.CTSDesktop.Commands;
using System.Windows.Input;

namespace Fiehnlab.CTSDesktop.ViewModels {
	class MainWindowViewModel : ViewModelBase {
		private List<string> fromValues;
		private List<string> toValues;
		private SplashView splash;

		public MainWindowViewModel() {
			splash = new SplashView();
			splash.DataContext = new SplashViewModel(splash);

			splash.Show();
			Thread.Sleep(2000);
		}

		#region properties
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

		#endregion

		#region Commands
		private ICommand showSplashCommand;
		public ICommand ShowSplashCommand
		{
			get
			{
				if (showSplashCommand == null) {
					showSplashCommand = new DelegateCommand(ShowSplash, CanShowSplash);
				}
				return showSplashCommand;
			}
			private set
			{
				showSplashCommand = value;
				NotifyPropertyChanged("ShowSplashCommand");
			}
		}

		private bool CanShowSplash(object obj) {
			return (ToValues.Count <= 0 && FromValues.Count <= 0);
		}

		private void ShowSplash(object obj) {
			MessageBox.Show("about to laod stuff...");
		}
		#endregion
	}
}
