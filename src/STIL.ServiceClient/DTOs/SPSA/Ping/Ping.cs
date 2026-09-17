using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.Ping;

/// <summary>
/// The Ping class.
/// </summary>
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
[XmlRoot(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class Ping
{
}