using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <summary>
/// The Institutionstilknytning class.
/// </summary>
[XmlType(Namespace = "https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class Institutionstilknytning
{
    /// <summary>
    /// Gets or sets the <see cref="instnr"/> value.
    /// </summary>
    [XmlElement(DataType = "token", Order = 0)]
    public string instnr { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Item"/> value.
    /// </summary>
    [XmlElement("ansat", typeof(InstitutionstilknytningAnsat), Order = 1)]
    [XmlElement("ekstern", typeof(InstitutionstilknytningEkstern), Order = 1)]
    [XmlElement("elev", typeof(InstitutionstilknytningElev), Order = 1)]
    [XmlElement("kontakt", typeof(InstitutionstilknytningKontakt), Order = 1)]
    public object Item { get; set; }

    /// <summary>
    /// Gets the <see cref="Ansat"/> value.
    /// </summary>
    public InstitutionstilknytningAnsat? Ansat => Item as InstitutionstilknytningAnsat;

    /// <summary>
    /// Gets the <see cref="Ekstern"/> value.
    /// </summary>
    public InstitutionstilknytningEkstern? Ekstern => Item as InstitutionstilknytningEkstern;

    /// <summary>
    /// Gets the <see cref="Elev"/> value.
    /// </summary>
    public InstitutionstilknytningElev? Elev => Item as InstitutionstilknytningElev;

    /// <summary>
    /// Gets the <see cref="Kontakt"/> value.
    /// </summary>
    public InstitutionstilknytningKontakt? Kontakt => Item as InstitutionstilknytningKontakt;
}
