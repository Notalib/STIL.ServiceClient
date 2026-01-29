using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Instbruger
{
    [XmlElement(Order=0)]
    public string instnr { get; set; }

    [XmlElement(Order=1)]
    public string brugerid { get; set; }

    [XmlElement(Order=2)]
    public string navn { get; set; }

    [XmlElement("ansat", typeof(Ansat), Order=3)]
    [XmlElement("ekstern", typeof(Ekstern), Order=3)]
    [XmlElement("elev", typeof(Elev), Order=3)]
    public object Item { get; set; }

    [XmlElement("gruppe", Order=4)]
    public Gruppe[] gruppe { get; set; }
}