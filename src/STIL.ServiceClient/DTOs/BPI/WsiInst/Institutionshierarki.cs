using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The Institutionshierarki class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Institutionshierarki
{
    /// <summary>
    /// Gets or sets the <see cref="mainInstitution"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public string mainInstitution { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="department"/> value.
    /// </summary>
    [XmlElement("department", Order=1)]
    public string[] department { get; set; }
}