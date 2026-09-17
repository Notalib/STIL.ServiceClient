using System.Xml.Serialization;

using STIL.ServiceClient.DTOs.BPI.Common;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The BrugertilknytningEkstern class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class BrugertilknytningEkstern
{
    /// <summary>
    /// Gets or sets the <see cref="rolle"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public Eksternrolle rolle { get; set; }
}