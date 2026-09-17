using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiIdentifikation;

/// <summary>
/// The hentCprResponse class.
/// </summary>
public class hentCprResponse
{
    /// <summary>
    /// Gets or sets the <see cref="cpr"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public string cpr { get; set; }
}
