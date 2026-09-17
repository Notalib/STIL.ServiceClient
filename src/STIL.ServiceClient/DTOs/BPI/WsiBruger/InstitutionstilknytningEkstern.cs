using System.Xml.Serialization;

using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <summary>
/// The InstitutionstilknytningEkstern class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class InstitutionstilknytningEkstern
{
    /// <summary>
    /// Gets or sets the <see cref="rolle"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public Eksternrolle rolle { get; set; }
}