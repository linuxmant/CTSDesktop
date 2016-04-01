using System.Collections.Generic;
using Fiehnlab.CTSRest;
using Fiehnlab.CTSDesktop.MVVM;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Windows.Documents;
using Fiehnlab.CTSDesktop.Models;
using System.Windows;

namespace Fiehnlab.CTSDesktop.Data
{
    public class CtsDataServiceClient : ObservableObject, IDataService 
    {
        IRestClient client;

        public CtsDataServiceClient(IRestClient cli) {
            client = cli;
        }

        public List<IDSource> GetFromNames() {
            return convertNames(true);
        }

        public List<IDSource> GetToNames() {
            return convertNames();
        }

        private List<IDSource> convertNames(bool from = false) {
            List<IDSource> list = new List<IDSource>();
            foreach (string name in client.GetIdNames(from)) {
                list.Add(new IDSource(name));
            }

            return list;
        }
    }
}
