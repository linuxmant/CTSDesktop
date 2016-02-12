using Fiehnlab.CTSDesktop.MVVM;

namespace Fiehnlab.CTSDesktop.Models
{
	class IDSource : ViewModelBase {

		private string name;
		private bool selected;

		/// <summary>
		/// Creates a new instance of an External Id object
		/// </summary>
		public IDSource(string name, bool v = false)
		{
			Name = name;
			Selected = v;
		}

		public string Name
		{
			get { return name; }
			set { this.name = value;
				NotifyPropertyChanged();
			}
		}

		public bool Selected
		{
			get { return selected; }
			set
			{
				selected = value;
				NotifyPropertyChanged();
			}
		}

	}
}
