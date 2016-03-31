using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiehnlab.CTSRest {
    public interface ICtsRestClient {
        List<string> GetIdNames(bool from = false);
        List<string> Convert(List<string> from, List<string> to, List<string> keywords);
    }
}