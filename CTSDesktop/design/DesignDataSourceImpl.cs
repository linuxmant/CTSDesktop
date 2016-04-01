using Fiehnlab.CTSDesktop.Data;
using Fiehnlab.CTSDesktop.Models;
using Fiehnlab.CTSDesktop.MVVM;
using System;
using System.Collections.Generic;

namespace Fiehnlab.CTSDesktop.Design {
    public class DesignDataServiceImpl : ObservableObject, IDataService
	{
        private List<IDSource> fromValues;
        private List<IDSource> toValues;

        public List<IDSource> FromValues
        {
            get
            {
                if (fromValues == null) {
                    fromValues = createValues();
                }
                return fromValues;
            }
        }

        public List<IDSource> ToValues
        {
            get
            {
                if (toValues == null) {
                    toValues = createValues();
                }
                return toValues;
            }
        }

        private List<IDSource> createValues() {
            List<IDSource> v = new List<IDSource>();

            for (int i = 0; i < 10; i++) {
                v.Add(new IDSource(string.Format("test {0}", i)));
            }

            return v;
        }

        public List<IDSource> GetToNames()
		{
            return toValues;
        }

        public List<IDSource> GetFromNames() {
            return fromValues;
        }

        public List<string> Convert(List<string> from, List<string> to, List<string> keywords) {
            throw new NotImplementedException();
        }
    }
}
