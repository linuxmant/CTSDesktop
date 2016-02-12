using System.ComponentModel;

namespace Fiehnlab.CTSDesktop.Utilities
{
	class NotifierBase : INotifyPropertyChanged {

		#region INotifyPropertyChanges members
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName) {
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

	}
}
