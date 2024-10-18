using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.Ping;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class PingResponse
{
    [XmlElement(Order = 0)]
    public PingResponseStatus Status { get; set; }
}
