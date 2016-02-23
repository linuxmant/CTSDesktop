using Fiehnlab.CTSDesktop.Models;
using System.Collections.Generic;

namespace Fiehnlab.CTSDesktop.Data
{
	public interface IDataService
	{
		List<string> GetToIDSources();
		List<string> GetFromIDSources();
	}
}
