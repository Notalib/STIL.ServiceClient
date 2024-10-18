using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://stil.dk/spsa/ordreservice/v1.0")]
public class GetOrdrerQuery
{
    public GetOrdrerQuery()
    {
        fromTime = toTime = null;
    }

    public GetOrdrerQuery(DateTime? from = null, DateTime? to = null)
    {
        fromTime = from?.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
        toTime = to?.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");
    }

    [XmlElement(IsNullable = true, Order = 0)]
    public string fromTime { get; set; }

    [XmlElement(IsNullable = true, Order = 1)]
    public string toTime { get; set; }
}