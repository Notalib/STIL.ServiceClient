using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class Identifier
{
    [XmlElement(Order = 0)]
    public string SystemName { get; set; }

    [XmlElement(Order = 1)]
    public string SystemTransactionID { get; set; }
}