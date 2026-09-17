using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA;

/// <summary>
/// The Identifier class.
/// </summary>
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class Identifier
{
    /// <summary>
    /// Gets or sets the <see cref="SystemName"/> value.
    /// </summary>
    [XmlElement(Order = 0)]
    public string SystemName { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="SystemTransactionID"/> value.
    /// </summary>
    [XmlElement(Order = 1)]
    public string SystemTransactionID { get; set; }
}