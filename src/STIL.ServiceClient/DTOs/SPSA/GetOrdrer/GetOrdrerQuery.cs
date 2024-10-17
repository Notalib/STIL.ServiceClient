using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://stil.dk/spsa/ordreservice/v1.0")]
public class GetOrdrerQuery
{
    [XmlElement(IsNullable = true, Order = 0)]
    public DateTime? fromTime { get; set; }

    [XmlElement(IsNullable = true, Order = 1)]
    public DateTime? toTime { get; set; }
}