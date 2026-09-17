using System.Xml.Serialization;

using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The Ansat class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Ansat
{
    /// <summary>
    /// Gets or sets the <see cref="rolle"/> value.
    /// </summary>
    [XmlElement("rolle", Order=0)]
    public Ansatrolle[] rolle { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="initialer"/> value.
    /// </summary>
    [XmlElement(Order=1)]
    public string initialer { get; set; }
}