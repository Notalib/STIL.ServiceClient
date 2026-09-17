using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

/// <summary>
/// The Brugertilknytning class.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Brugertilknytning
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
    [XmlElement("ansat", typeof(BrugertilknytningAnsat), Order=3)]
    [XmlElement("ekstern", typeof(BrugertilknytningEkstern), Order=3)]
    [XmlElement("elev", typeof(BrugertilknytningElev), Order=3)]
    public object Item { get; set; }
}