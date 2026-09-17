using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA;

/// <summary>
/// The ServiceFaultDetailer class.
/// </summary>
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class ServiceFaultDetailer
{
    /// <summary>
    /// Gets or sets the <see cref="CorrelationID"/> value.
    /// </summary>
    [XmlElement(Order = 0)]
    public string CorrelationID { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Timestamp"/> value.
    /// </summary>
    [XmlElement(Order = 1)]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="ErrorCode"/> value.
    /// </summary>
    [XmlElement(Order = 2)]
    public string ErrorCode { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="ErrorMessage"/> value.
    /// </summary>
    [XmlElement(Order = 3)]
    public string ErrorMessage { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Details"/> value.
    /// </summary>
    [XmlElement(Order = 4)]
    public string Details { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="SourceSystemError"/> value.
    /// </summary>
    [XmlElement(Order = 5)]
    public SourceSystemErrorType SourceSystemError { get; set; }
}
