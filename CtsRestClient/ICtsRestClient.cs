using System.Collections.Generic;

namespace Fiehnlab.CTSRest {
    public interface ICtsRestClient {
        List<string> GetIdNames(bool from = false);
        List<string> Convert(List<string> from, List<string> to, List<string> keywords);
    }
}