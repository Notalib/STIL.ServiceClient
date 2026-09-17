using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.Ping;

/// <summary>
/// The PingResponse class.
/// </summary>
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class PingResponse
{
    /// <summary>
    /// Gets or sets the <see cref="Status"/> value.
    /// </summary>
    [XmlElement(Order = 0)]
    public PingResponseStatus Status { get; set; }
}
