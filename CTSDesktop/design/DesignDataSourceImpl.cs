using Fiehnlab.CTSDesktop.Data;
using Fiehnlab.CTSDesktop.Models;
using System.Collections.Generic;

namespace Fiehnlab.CTSDesktop.Design
{
	public class DesignDataServiceImpl : IDataService
	{
		public List<string> GetToIDSources()
		{
			List<string> names = new List<string>();

			for (int i = 0; i < 10; i++)
			{
				names.Add(string.Format("test {0}", i));
			}

			return new List<string>(names);
		}

		public List<string> GetFromIDSources()
		{
			return GetToIDSources();
		}
	}
}
