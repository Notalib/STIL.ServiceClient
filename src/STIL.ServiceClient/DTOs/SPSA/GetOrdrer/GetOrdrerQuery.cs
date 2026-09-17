using System;
using System.Diagnostics;
using System.Xml.Serialization;
using STIL.ServiceClient.Util.SoapHelper;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

/// <summary>
/// The GetOrdrerQuery class.
/// </summary>
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://stil.dk/spsa/ordreservice/v1.0")]
public class GetOrdrerQuery
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetOrdrerQuery"/> class.
    /// </summary>
    public GetOrdrerQuery()
    {
        fromTime = toTime = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetOrdrerQuery"/> class.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    public GetOrdrerQuery(DateTime? from = null, DateTime? to = null)
    {
        fromTime = from?.ToSoapString();
        toTime = to?.ToSoapString();
    }

    /// <summary>
    /// Gets or sets the <see cref="fromTime"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 0)]
    public string? fromTime { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="toTime"/> value.
    /// </summary>
    [XmlElement(IsNullable = true, Order = 1)]
    public string? toTime { get; set; }
}