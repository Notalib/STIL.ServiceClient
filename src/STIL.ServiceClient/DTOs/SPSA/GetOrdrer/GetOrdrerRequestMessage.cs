using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class GetOrdrerRequestMessage
{
    [XmlElement(Namespace = "http://stil.dk/spsa/ordreservice/v1.0", Order = 0)]
    public GetOrdrerQuery GetOrdrerQuery { get; set; }
}