using Fiehnlab.CTSDesktop.Data;
using Fiehnlab.CTSDesktop.Models;
using Fiehnlab.CTSDesktop.MVVM;
using System.Collections.Generic;

namespace Fiehnlab.CTSDesktop.Design
{
	public class DesignDataServiceImpl : ObservableObject, IDataService
	{
		public List<IDSource> GetToNames()
		{
			List<IDSource> names = new List<IDSource>();

			for (int i = 0; i < 10; i++)
			{
				names.Add(new IDSource(string.Format("test {0}", i)));
			}

			return new List<IDSource>(names);
		}

		public List<IDSource> GetFromNames()
		{
			return GetToNames();
		}
	}
}
