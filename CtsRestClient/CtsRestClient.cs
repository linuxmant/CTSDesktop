﻿using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fiehnlab.CTSRest {
    public class CtsRestClient : IRestClient
    {
		//private RestClient client;
        private HttpClient client;
        private List<string> nameList = new List<string>();

        /// <summary>
        /// Creates a new REST client to call the CTS
        /// </summary>
        public CtsRestClient() {
			Client = new HttpClient();
            Client.BaseAddress = new Uri(Properties.Resources.CTS_URL);
        }

        //internal RestClient Client
        internal HttpClient Client
        {
            get { return this.client; }
			set { this.client = value; }
		}

		public List<string> Convert(List<string> from, List<string> to, List<string> keywords) {
            throw new NotImplementedException();
		}

        public List<string> GetIdNames(bool from = false) {
            Console.WriteLine("getting names. from? {0}", from);
            List<string> names = new List<string>();

            if (from) {
                names = fetchNames(Properties.Resources.CTS_REST_FROMNAMES_PATH).Result;
            } else {
                names = fetchNames(Properties.Resources.CTS_REST_TONAMES_PATH).Result;
            }
            //Console.WriteLine("found {0} names", names.Count);

            return names;
        }

        private async Task<List<string>> fetchNames(string path) {
            string res = "";
            List<string> ls = new List<string>();

            try {
                using (HttpClient cli = new HttpClient()) {
                    cli.BaseAddress = new Uri(Properties.Resources.CTS_URL);

                    var response = client.GetAsync(path).Result;
                    using (HttpContent content = response.Content) {
                        res = await content.ReadAsStringAsync();
                    }
                }
            }catch(Exception ex) {
                Console.WriteLine("rest client error\n" + ex.GetType().Name + "\n" + ex.StackTrace);
            }

            foreach (var s in res.Split(',')) {
                ls.Add(s.Replace("[", null).Replace("]", null).Replace("\"", null).Trim());
            }

            return ls;
        }

    }
}
