using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class Kontaktperson
{
    [XmlElement(Order=0)]
    public string instnr { get; set; }

    [XmlElement(Order=1)]
    public string brugerid { get; set; }

    [XmlElement(Order=2)]
    public string navn { get; set; }

    [XmlElement(Order=3)]
    public Kontaktpersonsrelation relation { get; set; }

    [XmlElement(Order=4)]
    public bool myndighed { get; set; }

    [XmlElement(Order=5)]
    public int verifikation { get; set; }

    [XmlElement(Order=6)]
    public int adgangsniveau { get; set; }
}