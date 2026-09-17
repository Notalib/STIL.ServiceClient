using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The hentInstitutionResponse class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class hentInstitutionResponse
{
    /// <summary>
    /// Gets or sets the <see cref="institution"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public Institution institution { get; set; }
}