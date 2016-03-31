using Fiehnlab.CTSDesktop.Data;
using Fiehnlab.CTSDesktop.Models;
using Fiehnlab.CTSDesktop.MVVM;
using Fiehnlab.CTSRest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiehnlab.CTSDesktop.Design
{
	public class DesignDataServiceImpl : ObservableObject//, ICtsRestClient
	{
        private List<IDSource> fromValues;
        private List<IDSource> toValues;

		public async void GetToNames()
		{
            await Task.Run(() => {
                for (int i = 0; i < 10; i++) {
                    toValues.Add(new IDSource(string.Format("test {0}", i)));
                }
            });
        }

        public async void GetFromNames() {
            await Task.Run(() => {
                for (int i = 0; i < 10; i++) {
                    fromValues.Add(new IDSource(string.Format("test {0}", i)));
                }
            });
        }

        public Task<List<string>> GetIdNames(bool from = false) {
            throw new NotImplementedException();
        }

        public Task<List<string>> Convert(List<string> from, List<string> to, List<string> keywords) {
            throw new NotImplementedException();
        }
    }
}
