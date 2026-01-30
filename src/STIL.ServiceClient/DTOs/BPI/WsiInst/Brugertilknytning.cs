using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Brugertilknytning
{
    [XmlElement(Order=0)]
    public string instnr { get; set; }


    [XmlElement(Order=1)]
    public string brugerid { get; set; }


    [XmlElement(Order=2)]
    public string navn { get; set; }


    [XmlElement("ansat", typeof(BrugertilknytningAnsat), Order=3)]
    [XmlElement("ekstern", typeof(BrugertilknytningEkstern), Order=3)]
    [XmlElement("elev", typeof(BrugertilknytningElev), Order=3)]
    public object Item { get; set; }
}