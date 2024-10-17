using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://stil.dk/spsa/ordreservice/v1.0")]
public class ElevOrdreDetails
{
    [XmlElement(IsNullable = true, Order = 0)]
    public string cprUuid { get; set; }

    [XmlElement(DataType = "integer", Order = 1)]
    public string spsId { get; set; }

    [XmlArray(IsNullable = true, Order = 2)]
    [XmlArrayItem("OrdreDetails", IsNullable = false)]
    public OrdreDetails[] ordrer { get; set; }
}