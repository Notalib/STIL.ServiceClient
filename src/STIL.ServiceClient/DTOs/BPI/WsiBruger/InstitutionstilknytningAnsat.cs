using System.Xml.Serialization;

using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <summary>
/// The InstitutionstilknytningAnsat class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class InstitutionstilknytningAnsat
{
    /// <summary>
    /// Gets or sets the <see cref="rolle"/> value.
    /// </summary>
    [XmlElement("rolle", Order=0)]
    public Ansatrolle[] rolle { get; set; }
}
