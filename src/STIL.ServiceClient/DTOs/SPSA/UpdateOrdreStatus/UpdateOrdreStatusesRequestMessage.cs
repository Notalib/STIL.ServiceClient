using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class UpdateOrdreStatusesRequestMessage
{
    [XmlElement(Namespace = "http://stil.dk/spsa/ordreservice/v1.0", Order = 0)]
    public UpdateOrdreStatusesCommand UpdateOrdreStatusesCommand { get; set; }
}