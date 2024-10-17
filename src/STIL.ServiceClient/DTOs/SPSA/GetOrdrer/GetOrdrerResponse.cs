using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA.GetOrdrer;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class GetOrdrerResponse
{
    [XmlElement(Order = 0)]
    public Identifier Identifier { get; set; }

    [XmlElement(Order = 1)]
    public string CorrelationID { get; set; }

    [XmlArray(Order = 2)]
    [XmlArrayItem("ElevOrdreDetails", Namespace = "http://stil.dk/spsa/ordreservice/v1.0", IsNullable = false)]
    public ElevOrdreDetails[] Message { get; set; }
}
