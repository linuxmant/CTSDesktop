using System.Collections.Generic;
using Fiehnlab.CTSRest;

namespace Fiehnlab.CTSDesktop.Data
{
	public class CtsDataService : IDataService
	{
		private CtsRestClient client = new CtsRestClient();
		private List<string> toNames = new List<string>();
		private List<string> fromNames = new List<string>();

		public CtsDataService()
		{
			this.fromNames = client.GetFromValues();
			this.toNames = client.GetToValues();
		}

		public List<string> GetToIDSources()
		{
			return this.toNames;
		}

		public List<string> GetFromIDSources()
		{
			return this.fromNames;
		}
	}
}
