using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <remarks/>
[GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
[DebuggerStepThrough]
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class Elevbruger
{
    [XmlElement(Order=0)]
    public Elevrolle rolle { get; set; }

    [XmlElement(Order=1)]
    public string instnr { get; set; }

    [XmlElement(Order=2)]
    public string brugerid { get; set; }

    [XmlElement(Order=3)]
    public string navn { get; set; }

    [XmlElement(Order=4)]
    public Gruppe hovedgruppe { get; set; }
}