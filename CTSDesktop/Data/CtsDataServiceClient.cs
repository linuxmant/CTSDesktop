using System.Collections.Generic;
using Fiehnlab.CTSRest;
using Fiehnlab.CTSDesktop.MVVM;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Fiehnlab.CTSDesktop.Data
{
	public class CtsDataServiceClient : ObservableObject {
        private HttpClient client;
        private const string CTS_URL = "http://cts.fiehnlab.ucdavis.edu";
        private string TO_NAMES_QUERY_PATH = "/service/conversion/toValues";
        private string FROM_NAMES_QUERY_PATH = "/service/conversion/fromValues";

        #region Fields

        private List<string> toNames;
        private List<string> fromNames;

        #endregion

        public Task<List<string>> GetToNames() {
            return fetchNames(TO_NAMES_QUERY_PATH);
        }

        public Task<List<string>> GetFromNames() {
            return fetchNames(FROM_NAMES_QUERY_PATH);
        }

        #region Constructor
        public CtsDataServiceClient() {
            client = new HttpClient();
            client.BaseAddress = new Uri(CTS_URL);
        }
        #endregion

        private async Task<List<string>>fetchNames(string path) {
            string res = "";
            using (HttpResponseMessage response = await client.GetAsync(path))
            using (HttpContent content = response.Content) {
                res = await content.ReadAsStringAsync();

                Console.WriteLine(res);
            }

            List<string> ls = new List<string>();
            foreach(var s in res.Split(',')) {
                ls.Add(s);
            }

            return ls;
        }
    }
}
