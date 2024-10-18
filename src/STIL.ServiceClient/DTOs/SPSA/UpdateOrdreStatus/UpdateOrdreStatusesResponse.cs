using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class UpdateOrdreStatusesResponse
{
    [XmlElement(Order = 0)]
    public Identifier Identifier { get; set; }

    [XmlElement(Order = 1)]
    public string CorrelationID { get; set; }

    [XmlElement(IsNullable = true, Order = 2)]
    public object Message { get; set; }
}