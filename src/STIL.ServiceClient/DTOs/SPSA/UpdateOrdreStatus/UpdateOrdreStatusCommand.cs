using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.UpdateOrdreStatus;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://stil.dk/spsa/ordreservice/v1.0")]
public class UpdateOrdreStatusCommand
{
    [XmlElement(IsNullable = true, Order = 0)]
    public string ordrenummer { get; set; }

    [XmlElement(IsNullable = true, Order = 1)]
    public string status { get; set; }
}