using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiIdentifikation;

/// <summary>
/// The hentBrugeridFraCpr class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiidentifikation/6")]
public class hentBrugeridFraCpr
{
    /// <summary>
    /// Gets or sets the <see cref="cpr"/> value.
    /// </summary>
    [XmlElement(DataType="token", Order=0)]
    public string cpr { get; set; }
}