using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA;

[DebuggerStepThrough]
[XmlType(Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class SourceSystemErrorType
{
    [XmlElement(Order = 0)]
    public string SourceSystemName { get; set; }

    [XmlElement(Order = 1)]
    public string ErrorCode { get; set; }

    [XmlElement(Order = 2)]
    public string Details { get; set; }
}
