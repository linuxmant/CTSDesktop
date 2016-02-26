using Fiehnlab.CTSDesktop.MVVM;

namespace Fiehnlab.CTSDesktop.Models
{
	public class IDSource : ObservableObject {

		private string name;
		private bool isSelected;

		/// <summary>
		/// Creates a new instance of an External Id object
		/// </summary>
		public IDSource(string name, bool v = false)
		{
			Name = name;
			IsSelected = v;
		}

		public string Name
		{
			get { return name; }
			set { this.name = value;
				NotifyPropertyChanged();
			}
		}

		public bool IsSelected
		{
			get { return isSelected; }
			set
			{
				isSelected = value;
				NotifyPropertyChanged();
			}
		}

		public override string ToString()
		{
			return Name;
		}
	}
}
