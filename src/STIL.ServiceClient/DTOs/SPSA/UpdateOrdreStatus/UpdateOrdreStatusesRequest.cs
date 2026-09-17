using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

/// <summary>
/// The UpdateOrdreStatusesRequest class.
/// </summary>
[DebuggerStepThrough]
[XmlRoot(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class UpdateOrdreStatusesRequest
{
    /// <summary>
    /// Gets or sets the <see cref="Identifier"/> value.
    /// </summary>
    [XmlElement(Order = 0)]
    public Identifier Identifier { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Message"/> value.
    /// </summary>
    [XmlElement(Order = 1)]
    public UpdateOrdreStatusesRequestMessage Message { get; set; }
}