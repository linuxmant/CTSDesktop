using Fiehnlab.CTSDesktop.Models;
using System.Collections.ObjectModel;

namespace Fiehnlab.CTSDesktop.design
{
	interface IDataService
	{
		ObservableCollection<IDSource> GetToIDSources();
		ObservableCollection<IDSource> GetFromIDSources();
	}
}
