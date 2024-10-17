using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.SPSA;

[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://ipl.stil.dk/services/spsa/ordreservice/v1.0")]
public class ServiceFaultDetailer
{
    [XmlElement(Order = 0)]
    public string CorrelationID { get; set; }

    [XmlElement(Order = 1)]
    public DateTime Timestamp { get; set; }

    [XmlElement(Order = 2)]
    public string ErrorCode { get; set; }

    [XmlElement(Order = 3)]
    public string ErrorMessage { get; set; }

    [XmlElement(Order = 4)]
    public string Details { get; set; }

    [XmlElement(Order = 5)]
    public SourceSystemErrorType SourceSystemError { get; set; }
}