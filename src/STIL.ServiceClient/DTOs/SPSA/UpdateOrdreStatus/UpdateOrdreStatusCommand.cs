using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

/// <summary>
/// The UpdateOrdreStatusCommand class.
/// </summary>
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://stil.dk/spsa/ordreservice/v1.0")]
public class UpdateOrdreStatusCommand
{
    /// <summary>
    /// Gets or sets the <see cref="ordrenummer"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 0)]
    public string ordrenummer { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="status"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 1)]
    public string status { get; set; }
}