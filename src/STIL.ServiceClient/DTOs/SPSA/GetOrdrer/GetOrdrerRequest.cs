using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class GetOrdrerRequest
{
    [XmlElement(Order = 0)]
    public Identifier Identifier { get; set; }

    [XmlElement(Order = 1)]
    public GetOrdrerRequestMessage Message { get; set; }
}