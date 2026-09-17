using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <remarks/>
[GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
[DebuggerStepThrough]
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class Elevbruger
{
    /// <summary>
    /// Gets or sets the <see cref="rolle"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public Elevrolle rolle { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="instnr"/> value.
    /// </summary>
    [XmlElement(Order=1)]
    public string instnr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="brugerid"/> value.
    /// </summary>
    [XmlElement(Order=2)]
    public string brugerid { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="navn"/> value.
    /// </summary>
    [XmlElement(Order=3)]
    public string navn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="hovedgruppe"/> value.
    /// </summary>
    [XmlElement(Order=4)]
    public Gruppe hovedgruppe { get; set; }
}