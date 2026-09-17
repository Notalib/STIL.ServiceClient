using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <remarks/>
[GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public enum Gruppetype
{
    /// <summary>
    /// The Hovedgruppe value.
    /// </summary>
    Hovedgruppe,
        
    /// <summary>
    /// The Årgang value.
    /// </summary>
    Årgang,
        
    /// <summary>
    /// The Retning value.
    /// </summary>
    Retning,
        
    /// <summary>
    /// The Hold value.
    /// </summary>
    Hold,
        
    /// <summary>
    /// The SFO value.
    /// </summary>
    SFO,
        
    /// <summary>
    /// The Team value.
    /// </summary>
    Team,
        
    /// <summary>
    /// The Institution value.
    /// </summary>
    Institution,
    
    /// <summary>
    /// The Andet value.
    /// </summary>
    Andet,
}