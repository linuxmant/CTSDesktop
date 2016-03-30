using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fiehnlab.CTSDesktop.Models {
    [DataContract]
    class CTSQuery {

        [DataMember]
        string FromType { get; set; }
        [DataMember]
        string ToType { get; set; }
        [DataMember]
        string Keywords { get; set; }

    }
}
