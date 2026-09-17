using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

/// <summary>
/// The UpdateOrdreStatusesResponse class.
/// </summary>
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class UpdateOrdreStatusesResponse
{
    /// <summary>
    /// Gets or sets the <see cref="Identifier"/> value.
    /// </summary>
    [XmlElement(Order = 0)]
    public Identifier Identifier { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="CorrelationID"/> value.
    /// </summary>
    [XmlElement(Order = 1)]
    public string CorrelationID { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Message"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 2)]
    public object Message { get; set; }
}