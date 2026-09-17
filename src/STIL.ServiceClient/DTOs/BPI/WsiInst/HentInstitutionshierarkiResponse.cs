using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The HentInstitutionshierarkiResponse class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class HentInstitutionshierarkiResponse
{
    /// <summary>
    /// Gets or sets the <see cref="institutionshierarki"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public Institutionshierarki institutionshierarki { get; set; }
}