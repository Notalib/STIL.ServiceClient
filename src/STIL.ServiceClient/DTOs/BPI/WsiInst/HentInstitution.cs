using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The hentInstitution class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class hentInstitution
{
    /// <summary>
    /// Gets or sets the <see cref="instnr"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public string instnr { get; set; }
}
