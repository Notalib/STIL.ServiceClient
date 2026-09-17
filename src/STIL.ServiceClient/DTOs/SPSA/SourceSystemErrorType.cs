using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA;

/// <summary>
/// The SourceSystemErrorType class.
/// </summary>
[DebuggerStepThrough]
[XmlType(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class SourceSystemErrorType
{
    /// <summary>
    /// Gets or sets the <see cref="SourceSystemName"/> value.
    /// </summary>
    [XmlElement(Order = 0)]
    public string SourceSystemName { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="ErrorCode"/> value.
    /// </summary>
    [XmlElement(Order = 1)]
    public string ErrorCode { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Details"/> value.
    /// </summary>
    [XmlElement(Order = 2)]
    public string Details { get; set; }
}
