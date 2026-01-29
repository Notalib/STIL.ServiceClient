using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <remarks/>
[GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public enum Gruppetype
{
    Hovedgruppe,
        
    Årgang,
        
    Retning,
        
    Hold,
        
    SFO,
        
    Team,
        
    Institution,
    
    Andet,
}