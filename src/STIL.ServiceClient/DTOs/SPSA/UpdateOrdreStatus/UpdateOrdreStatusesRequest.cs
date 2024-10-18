using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

[DebuggerStepThrough]
[XmlRoot(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class UpdateOrdreStatusesRequest
{
    [XmlElement(Order = 0)]
    public Identifier Identifier { get; set; }

    [XmlElement(Order = 1)]
    public UpdateOrdreStatusesRequestMessage Message { get; set; }
}