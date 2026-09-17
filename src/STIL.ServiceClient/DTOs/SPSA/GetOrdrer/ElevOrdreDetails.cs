using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

/// <summary>
/// The ElevOrdreDetails class.
/// </summary>
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://stil.dk/spsa/ordreservice/v1.0")]
public class ElevOrdreDetails
{
    /// <summary>
    /// Gets or sets the <see cref="cprUuid"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 0)]
    public string cprUuid { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="spsId"/> value.
    /// </summary>
    [XmlElement(DataType = "integer", Order = 1)]
    public string spsId { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="ordrer"/> value.
    /// </summary>
    [XmlArray(IsNullable = true, Order = 2)]
    [XmlArrayItem("OrdreDetails", IsNullable = false)]
    public OrdreDetails[] ordrer { get; set; }
}