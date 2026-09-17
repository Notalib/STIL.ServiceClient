using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

/// <summary>
/// The UpdateOrdreStatusesRequestMessage class.
/// </summary>
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class UpdateOrdreStatusesRequestMessage
{
    /// <summary>
    /// Gets or sets the <see cref="UpdateOrdreStatusesCommand"/> value.
    /// </summary>
    [XmlElement(Namespace = "http://stil.dk/spsa/ordreservice/v1.0", Order = 0)]
    public UpdateOrdreStatusesCommand UpdateOrdreStatusesCommand { get; set; }
}
