using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The Instbruger class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Instbruger
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
    /// Gets or sets the <see cref="Item"/> value.
    /// </summary>
    [XmlElement("ansat", typeof(Ansat), Order=3)]
    [XmlElement("ekstern", typeof(Ekstern), Order=3)]
    [XmlElement("elev", typeof(Elev), Order=3)]
    public object Item { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="gruppe"/> value.
    /// </summary>
    [XmlElement("gruppe", Order=4)]
    public Gruppe[] gruppe { get; set; }
}