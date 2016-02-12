using Fiehnlab.CTSDesktop.Models;
using System.Collections.ObjectModel;

namespace Fiehnlab.CTSDesktop.design
{
	class DesignDataServiceImpl : IDataService
	{
		public ObservableCollection<IDSource> GetToIDSources()
		{
			NameList names = new NameList();

			for(int i=0; i< 10; i++)
			{
				names.Add(new IDSource(string.Format("test {0}", i)));
			}

			return new ObservableCollection<IDSource>(names.ToList());
		}

		public ObservableCollection<IDSource> GetFromIDSources()
		{
			return GetToIDSources();
		}
	}
}
