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
    public class CtsDataServiceClient : ObservableObject//, IDataService 
    {
        ICtsRestClient client;

        public CtsDataServiceClient(ICtsRestClient cli) {
            client = cli;
        }

        //public List<IDSource> GetFromNames() {
        //    List<IDSource> list = new List<IDSource>();
        //    Task t = client.GetIdNames(true);
        //    try {
        //        t.Wait();
                
        //    } catch(AggregateException ex) {
        //        MessageBox.Show("Error getting ID Names");
        //    }

        //}

        //public List<IDSource> GetToNames() {
        //    throw new NotImplementedException();
        //}
    }
}
