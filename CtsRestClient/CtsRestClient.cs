using System.Collections.Generic;
using RestSharp;
using System.Diagnostics;

namespace Fiehnlab.CTSRest
{
	public class CtsRestClient {

		private RestClient client;

		/// <summary>
		/// Creates a new REST client to call the CTS
		/// </summary>
		public CtsRestClient() {
			Client = new RestClient( Properties.Resources.CTS_URL);
		}

		internal RestClient Client
		{
			get { return this.client; }
			set { this.client = value; }
		}

		internal List<string> getIdNames(bool from = false) {
			List<string> names = new List<string>();

			RestRequest request = new RestRequest(Properties.Resources.CTS_REST_PATH + "/" + Properties.Resources.CTS_REST_IDNAMES_PATH, Method.GET);
			request.AddHeader("Content-Type", Properties.Resources.HEADERS_JSON);

			RestResponse response = new RestResponse();
			response = (RestResponse) Client.Execute(request);

			if (response.ResponseStatus.Equals(ResponseStatus.Completed)) {
				bool save = false;
				string name = "";

				foreach (char c in response.RawBytes) {
					if(c == '"') {
						save = !save;
					}

					if (save && c != '"') {
						name += c;
					} else {
						if (name != "") {
							names.Add(name);
						}
						name = "";
					}
				}
			} else {
				Debug.Fail(string.Format("ERROR: {0}", response.ErrorMessage + "\n" + response.ErrorException));
				return new List<string>();
			}

			if (from) {
				names.Remove(Properties.Resources.INCHI_CODE);
			}

			return names;
		}

		public List<string> GetFromValues() {
			return getIdNames(true);
		}

		public List<string> GetToValues() {
			return getIdNames();
		}
	}

}
