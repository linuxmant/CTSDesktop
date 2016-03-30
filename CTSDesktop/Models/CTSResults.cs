using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// [
///   {
///     "fromIdentifier": "chemical name",
///     "searchTerm": "alanine",
///     "toIdentifier": "inchikey",
///     "result": 
///     [
///       {
///         "class": "edu.ucdavis.fiehnlab.cts.ScoredValue",
///         "score": 1,
///         "value": "QNAYBMKLOCPYGJ-REOHCLBHSA-N"
///       },
///       {
///         "class": "edu.ucdavis.fiehnlab.cts.ScoredValue",
///         "score": 0.7426,
///         "value": "QNAYBMKLOCPYGJ-UHFFFAOYSA-N"
///       },
///       {
///         "class": "edu.ucdavis.fiehnlab.cts.ScoredValue",
///         "score": 0.493,
///         "value": "QNAYBMKLOCPYGJ-UWTATZPHSA-N"
///       },
///       {
///         "class": "edu.ucdavis.fiehnlab.cts.ScoredValue",
///         "score": 0.0162,
///         "value": "QNAYBMKLOCPYGJ-AZXPZELESA-N"
///       }
///     ]
///   }
/// ]
/// </summary>
namespace Fiehnlab.CTSDesktop.Models {
    [DataContract]
    class CTSResults {
        [DataMember]
        string fromIdentifier { get; set; }
        [DataMember]
        string SearchTerm { get; set; }
        [DataMember]
        string toIdentifier { get; set; }
        [DataMember]
        List<Result> result { get; set; }
    }

    [DataContract]
    internal class Result {
        [DataMember]
        string value { get; set; }
        [DataMember]
        double score { get; set; }
        [DataMember(Name="class")]
        string type { get; set; }
    }
}
