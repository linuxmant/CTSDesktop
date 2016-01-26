using Fiehnlab.CTSDesktop.Utilities;

namespace Fiehnlab.CTSDesktop.Models {
	class IDSource : NotifierBase {

		private string name;
		/// <summary>
		/// Creates a new instance of an External Id object
		/// </summary>
		public IDSource(string name) {
			Name = name;
		}

		public string Name
		{
			get { return name; }
			set { this.name = value;
				OnPropertyChanged("Name");
			}
		}

	}
}
