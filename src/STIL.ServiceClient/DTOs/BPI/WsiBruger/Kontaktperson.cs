using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <summary>
/// The Kontaktperson class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class Kontaktperson
{
    /// <summary>
    /// Gets or sets the <see cref="instnr"/> value.
    /// </summary>
    [XmlElement(Order=0)]
    public string instnr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="brugerid"/> value.
    /// </summary>
    [XmlElement(Order=1)]
    public string brugerid { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="navn"/> value.
    /// </summary>
    [XmlElement(Order=2)]
    public string navn { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="relation"/> value.
    /// </summary>
    [XmlElement(Order=3)]
    public Kontaktpersonsrelation relation { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the contact person has authority ("myndighed").
    /// </summary>
    [XmlElement(Order=4)]
    public bool myndighed { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="verifikation"/> value.
    /// </summary>
    [XmlElement(Order=5)]
    public int verifikation { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="adgangsniveau"/> value.
    /// </summary>
    [XmlElement(Order=6)]
    public int adgangsniveau { get; set; }
}