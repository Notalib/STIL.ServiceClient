using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

/// <summary>
/// The GetOrdrerResponse class.
/// </summary>
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class GetOrdrerResponse
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
    [XmlArray(Order = 2)]
    [XmlArrayItem("ElevOrdreDetails", Namespace = "http://stil.dk/spsa/ordreservice/v1.0", IsNullable = false)]
    public ElevOrdreDetails[] Message { get; set; }
}
