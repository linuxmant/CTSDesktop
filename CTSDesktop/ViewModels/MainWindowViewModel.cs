using System.Windows;
using System;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using Fiehnlab.CTSDesktop.Design;
using Fiehnlab.CTSDesktop.Data;
using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSDesktop.Commands;
using System.Collections.Generic;

namespace Fiehnlab.CTSDesktop.ViewModels
{
	public class MainWindowViewModel : ViewModelBase {

		private bool isClosing = false;
		private string currentStep = "home";
		//private BackgroundWorker bgWorker;
		private IDataService dataSource;

		public MainWindowViewModel() : this(new DesignDataServiceImpl()) {}

		public MainWindowViewModel(IDataService ds) {
			dataSource = ds;
			LoadIdNameValues();
		}

		internal void LoadIdNameValues()
		{
			BackgroundWorker bgWorker;
			bgWorker = new BackgroundWorker();
			bgWorker.DoWork += new DoWorkEventHandler((s, args) => loadToValues(s, args));
			bgWorker.DoWork += new DoWorkEventHandler((s, args) => loadFromValues(s, args));
			bgWorker.RunWorkerAsync();
		}

		#region BackgroundWorker definition
		private void loadToValues(object sender, DoWorkEventArgs args) {
			Stopwatch timer = new Stopwatch();
			timer.Start();
			ToValuesList = dataSource.GetToIDSources();
			timer.Stop();

			//check 'InChiKey' by default
			//ToValuesList.Select(i => i.Name == "InChIKey");
		}

		private void loadFromValues(object sender, DoWorkEventArgs args) {
			Stopwatch timer = new Stopwatch();
			timer.Start();
			FromValuesList = dataSource.GetFromIDSources();
			timer.Stop();

			//select 'chemical name' by default
			//CurrentFrom = FromValuesList.Find( e => e.Name.ToLower() == "chemical name");
			CurrentFrom = "Chemical Name";
		}
		#endregion

		#region Properties
		/// <summary>
		/// Available types of values to convert from
		/// </summary>
		private List<string> fromValuesList;
		/// <summary>
		/// FromValuesList property accessors
		/// </summary>
		public List<string> FromValuesList
		{
			get { return fromValuesList ?? (fromValuesList = new List<string>()); }
			set
			{
				this.fromValuesList = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Available types of values to convert to
		/// </summary>
		private List<string> toValuesList;
		/// <summary>
		/// ToValuesList property accessors
		/// </summary>
		public List<string> ToValuesList
		{
			get { return toValuesList ?? (toValuesList = new List<string>()); }
			set
			{
				this.toValuesList = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// This contains the type of value to convert from
		/// </summary>
		private string currentFrom;
		/// <summary>
		/// CurrentFrom property accessors
		/// </summary>
		public string CurrentFrom
		{
			get { return currentFrom ?? (currentFrom = ""); }
			set
			{
				currentFrom = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// This contains a list of types of values to convert to.
		/// </summary>
		private List<string> currentTo;
		/// <summary>
		/// CurrentTo property accessors
		/// </summary>
		public List<string> CurrentTo
		{
			get { return currentTo ?? (currentTo = new List<string>()); }
			set
			{
				currentTo = value;
				NotifyPropertyChanged();
			}
		}

		#endregion

		#region Commands
		private DelegateCommand loadIdNamesCommand;
		public DelegateCommand LoadIdNamesCommand
		{
			get
			{
				return loadIdNamesCommand ?? (loadIdNamesCommand = new DelegateCommand(s => LoadIdNameValues(), p => true));
			}
		}

		private DelegateCommand<Window> closeCommand;
        public DelegateCommand<Window> CloseCommand
        {
            get { return closeCommand ?? (closeCommand = new DelegateCommand<Window>(wnd => CloseWindow(wnd), wnd => CanCloseWindow(wnd))); }
		}

        private DelegateCommand convertCommand;
        public DelegateCommand ConvertCommand
        {
            get { return convertCommand ?? (convertCommand = new DelegateCommand(s => MessageBox.Show("From: " + CurrentFrom + "\nTo: " + String.Join(", ", CurrentTo), "Converting:"))); }
		}



		private DelegateCommand updateFrom;
		public DelegateCommand UpdateFrom
		{
			get
			{
				return updateFrom ?? (updateFrom = new DelegateCommand(s => {
					MessageBox.Show(s != null ? s.ToString() : "i dont know what this is");
				}));
			}
		}

		private DelegateCommand<ListBox> updateSelectedTo;
		public DelegateCommand<ListBox> UpdateSelectedTo
		{
			get
			{
				return updateSelectedTo ?? (updateSelectedTo = new DelegateCommand<ListBox>(s => {
				MessageBox.Show("Updating selectedTo, " + s.GetType().Name);
					if (s != null)
					{
						foreach (ListBoxItem item in s.Items)
						{
							if (item.IsSelected)
								CurrentTo.Add(item.Content.ToString());
							else
								CurrentTo.Where(p => item.Content == p);
						}
					}
				}));
			}
		}
		#endregion

		internal void CloseWindow(Window window)
		{
			if (window != null)
			{
				window.Close();
			} else {
				MessageBox.Show("Can't close a null window.");
			}

		}

		internal bool CanCloseWindow(Window window)
		{
			return !isClosing;
		}

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
