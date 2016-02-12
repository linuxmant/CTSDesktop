using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSDesktop.Commands;
using System.Windows;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using Fiehnlab.CTSDesktop.Models;
using Fiehnlab.CTSDesktop.design;
using System.Collections.ObjectModel;

namespace Fiehnlab.CTSDesktop.ViewModels
{
	class MainWindowViewModel : ViewModelBase {

		private bool isClosing = false;
		private string currentStep = "home";
		private DesignDataServiceImpl dataSource;
		private BackgroundWorker bgWorker;


		public MainWindowViewModel()
		{
			bgWorker = new BackgroundWorker();

			bgWorker.DoWork += new DoWorkEventHandler((s, args) => loadToValues(s, args));
			bgWorker.DoWork += new DoWorkEventHandler((s, args) => loadFromValues(s, args));

			bgWorker.RunWorkerAsync();
		}

		public MainWindowViewModel(IDataService dataSource) {
			if(DesignerProperties.GetIsInDesignMode(new DependencyObject()))
			{
				FromValuesList = dataSource.GetFromIDSources();
				ToValuesList = dataSource.GetToIDSources();
			} else
			{
				bgWorker = new BackgroundWorker();

				bgWorker.DoWork += new DoWorkEventHandler((s, args) => loadToValues(s, args));
				bgWorker.DoWork += new DoWorkEventHandler((s, args) => loadFromValues(s, args));

				bgWorker.RunWorkerAsync();
			}
		}

		public MainWindowViewModel(DesignDataServiceImpl designDataSourceImpl)
		{
			this.dataSource = designDataSourceImpl;
		}

		#region BackgroundWorker definition

		private void loadToValues(object sender, DoWorkEventArgs args) {
			Stopwatch timer = new Stopwatch();
			timer.Start();
			ToValuesList = dataSource.GetToIDSources();
			timer.Stop();
			//check 'InChiKey' by default
			//CurrentTo.Add("InChIKey");
		}

		private void loadFromValues(object sender, DoWorkEventArgs args) {
			Stopwatch timer = new Stopwatch();
			timer.Start();
			FromValuesList = dataSource.GetFromIDSources();
			timer.Stop();

			//select 'chemical name' by default
			//CurrentFrom = FromValuesList.Find( e => e.Name.ToLower() == "chemical name");
		}
		#endregion

		#region Properties
		/// <summary>
		/// Available types of values to convert from
		/// </summary>
		private ObservableCollection<IDSource> fromValuesList;
		/// <summary>
		/// FromValuesList property accessors
		/// </summary>
		public ObservableCollection<IDSource> FromValuesList
		{
			get { return fromValuesList; }
			set
			{
				this.fromValuesList = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Available types of values to convert to
		/// </summary>
		private ObservableCollection<IDSource> toValuesList;
		/// <summary>
		/// ToValuesList property accessors
		/// </summary>
		public ObservableCollection<IDSource> ToValuesList
		{
			get { return toValuesList; }
			set
			{
				this.toValuesList = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// This contains the type of value to convert from
		/// </summary>
		private IDSource currentFrom;
		/// <summary>
		/// CurrentFrom property accessors
		/// </summary>
		public IDSource CurrentFrom
		{
			get { return currentFrom; }
			set
			{
				currentFrom = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// This contains a list of types of values to convert to.
		/// </summary>
		private ObservableCollection<IDSource> currentTo;
		/// <summary>
		/// CurrentTo property accessors
		/// </summary>
		public ObservableCollection<IDSource> CurrentTo
		{
			get { return currentTo; }
			set
			{
				currentTo = value;
				NotifyPropertyChanged();
			}
		}
		#endregion

		#region Commands
		private DelegateCommand loadIdNameValues;
        public DelegateCommand LoadIdNameValues
        {
            get { return loadIdNameValues ?? (loadIdNameValues = new DelegateCommand(s => bgWorker.RunWorkerAsync())); }
			private set { }
        }

        private DelegateCommand<Window> closeCommand;
        public DelegateCommand<Window> CloseCommand
        {
            get { return closeCommand ?? (closeCommand = new DelegateCommand<Window>(wnd => CloseWindow(wnd), wnd => CanCloseWindow(wnd))); }
			private set { }
		}

        private DelegateCommand convertCommand;
        public DelegateCommand ConvertCommand
        {
            get { return convertCommand ?? (convertCommand = new DelegateCommand(s => MessageBox.Show("asjdh"))); }
			private set { }
		}



		private DelegateCommand updateFrom;
		public DelegateCommand UpdateFrom
		{
			get
			{
				return updateFrom ?? (updateFrom = new DelegateCommand(s => {
					MessageBox.Show(s != null ? s.ToString() : "kljasdhfghjl:");
				}));
			}
		}

		private DelegateCommand<ListBox> updateSelectedTo;
		public DelegateCommand<ListBox> UpdateSelectedTo
		{
			get
			{
				return updateSelectedTo ?? (updateSelectedTo = new DelegateCommand<ListBox>(s => {
					if (s != null)
					{
						foreach (ListBoxItem item in s.Items)
						{
							if (item.IsSelected)
								CurrentTo.Add(new IDSource(item.Content.ToString()));
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
			}
			else {
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
