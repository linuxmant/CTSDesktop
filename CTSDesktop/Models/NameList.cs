using System.Collections.ObjectModel;
using Fiehnlab.CTSDesktop.Utilities;

namespace Fiehnlab.CTSDesktop.Models {
	class NameList : NotifierBase {
		private ObservableCollection<IDSource> names;

		public ObservableCollection<IDSource> Names
		{
			get { return names; }
			set {
				names = value;
				OnPropertyChanged("Names");
			}
		}
	}
}
