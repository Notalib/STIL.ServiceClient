using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.Ping;

[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public enum PingResponseStatus
{
    up,

    down,
}
