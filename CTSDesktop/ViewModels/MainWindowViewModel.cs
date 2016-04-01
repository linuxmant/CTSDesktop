using System.Windows;
using System;
using System.Linq;
using System.Windows.Data;
using System.Globalization;
using Fiehnlab.CTSDesktop.Data;
using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSDesktop.Commands;
using System.Collections.Generic;
using Fiehnlab.CTSDesktop.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Fiehnlab.CTSDesktop.ViewModels {
    public class MainWindowViewModel : ViewModelBase {

		private bool isClosing = false;
		private string currentStep = "home";
		private IDataService dataSource;

		public MainWindowViewModel(IDataService ds) {
			dataSource = ds;
        }

        #region Member variables
        /// <summary>
        /// Available types of values to convert from
        /// </summary>
        private List<IDSource> fromValuesList;

		/// <summary>
		/// Available types of values to convert to
		/// </summary>
		private List<IDSource> toValuesList;

		/// <summary>
		/// This contains the type of value to convert from
		/// </summary>
		private IDSource currentFrom;

		/// <summary>
		/// This contains a list of types of values to convert to.
		/// </summary>
		private HashSet<IDSource> currentTo;

		private DelegateCommand<Window> closeCommand;
		private DelegateCommand convertCommand;
		private DelegateCommand<IDSource> updateCurrentFromCommand;
		private DelegateCommand updateCurrentToCommand;
		private DelegateCommand<string> parseTextCommand;
		private string keywords;
		private int convertItemCount = 0;
		#endregion

		#region Properties
		/// <summary>
		/// FromValuesList property accessors
		/// </summary>
		public List<IDSource> FromValuesList
		{
			get { return fromValuesList ?? (fromValuesList = dataSource.GetFromNames()); }
			set
			{
				this.fromValuesList = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// ToValuesList property accessors
		/// </summary>
		public List<IDSource> ToValuesList
		{
			get { return toValuesList ?? (toValuesList = dataSource.GetToNames()); }
			set
			{
				this.toValuesList = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// CurrentFrom property accessors
		/// </summary>
		[Required]
		public IDSource CurrentFrom
		{
			get { return currentFrom ?? (currentFrom = new IDSource("")); }
			set
			{
				currentFrom = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// CurrentTo property accessors
		/// </summary>
		[Required]
		public HashSet<IDSource> CurrentTo
		{
			get { return currentTo ?? (currentTo = new HashSet<IDSource>()); }
			set
			{
				currentTo = value;
				NotifyPropertyChanged();
			}
		}

		/// <summary>
		/// Holds the Keywords to be conveted
		/// </summary>
		[Required]
		[MinLength(3, ErrorMessage = "Too few characters for a keyword")]
		[MaxLength(1000, ErrorMessage = "Can't search that many keywords")]
		public string Keywords {
			get { return keywords; }
			set {
				keywords = value;
				NotifyPropertyChanged();
			}
		}

		public int ConvertItemCount
		{
			get { return convertItemCount; }
			set
			{
				convertItemCount = value;
				NotifyPropertyChanged();
			}
		}
		#endregion

		#region Commands
		public DelegateCommand<Window> CloseCommand
		{
			get { return closeCommand ?? (closeCommand = new DelegateCommand<Window>(wnd => CloseWindow(wnd), wnd => CanCloseWindow(wnd))); }
		}

		public DelegateCommand ConvertCommand
		{
			get { return convertCommand ?? (convertCommand = new DelegateCommand(showConvertionData, CanExecuteConvertCommand)); }
		}

		public DelegateCommand<IDSource> UpdateCurrentFromCommand
		{
			get
			{
				if (updateCurrentFromCommand == null)
				{
					updateCurrentFromCommand = new DelegateCommand<IDSource>(s => CurrentFrom = s, CanUpdateCurrentFrom);
				}
				return updateCurrentFromCommand;
			}
		}

		public DelegateCommand UpdateCurrentToCommand
		{
			get
			{
				if (updateCurrentToCommand == null)
				{
					updateCurrentToCommand = new DelegateCommand(UpdateCurrentTo, CanUpdateCurrentTo);
				}
				return updateCurrentToCommand;
			}
		}

		public DelegateCommand<string> ParseTextCommand
		{
			get
			{
				if(parseTextCommand == null)
				{
					parseTextCommand = new DelegateCommand<string>(ParseText, CanParseText);
				}

				return parseTextCommand;
			}
		}
        #endregion

        #region Helper Functions
        internal void ParseText(string textToParse)
		{
			ConvertItemCount = textToParse.Split('\n').Length;
		}

		internal bool CanParseText(object p)
		{
			return Keywords.Length > 0;
		}

		internal void UpdateCurrentTo(object s)
		{
			System.Collections.IList items = (System.Collections.IList)s;
			var collection = items.Cast<IDSource>();

			CurrentTo.Clear();
			foreach(var item in collection)
			{
				CurrentTo.Add(item);
			}
		}

        private List<IDSource> fillFromValues() {
            return dataSource.GetFromNames();
        }

        private List<IDSource> fillToValues() {
            return dataSource.GetToNames();
        }

		internal void showConvertionData(object s)
		{
			MessageBox.Show("From: " + CurrentFrom + "\nTo: " + String.Join(", ", CurrentTo) + "\nKeywords:\n\t" + string.Join("\n\t", Keywords), "Conversion Info", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		internal bool CanExecuteConvertCommand(object p)
		{
			return (CurrentTo.Count > 0 && OnValidate(Keywords) == null );
		}

		internal bool CanUpdateCurrentFrom(object p)
		{
			return FromValuesList.Count > 0;
		}

		internal bool CanUpdateCurrentTo(object p)
		{
			return ToValuesList.Count > 0;
		}

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

		internal void ParseTextInput(string text)
		{
			MessageBox.Show(text??"no text");
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
