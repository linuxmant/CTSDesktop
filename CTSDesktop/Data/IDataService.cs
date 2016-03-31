using Fiehnlab.CTSDesktop.Models;
using System.Collections.Generic;

namespace Fiehnlab.CTSDesktop.Data
{
	public interface IDataService
	{
		List<IDSource> GetToNames();
		List<IDSource> GetFromNames();
	}
}
