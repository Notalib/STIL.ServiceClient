using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiIdentifikation;

/// <summary>
/// The hentCprFraBrugerid class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiidentifikation/6")]
public class hentCprFraBrugerid
{
    /// <summary>
    /// Gets or sets the <see cref="brugerid"/> value.
    /// </summary>
    [XmlElement(DataType="token", Order=0)]
    public string brugerid { get; set; }
}