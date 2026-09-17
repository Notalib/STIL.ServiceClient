using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.Ping;

/// <summary>
/// The PingResponseStatus enum.
/// </summary>
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public enum PingResponseStatus
{
    /// <summary>
    /// The up value.
    /// </summary>
    up,

    /// <summary>
    /// The down value.
    /// </summary>
    down,
}
