using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Ansat
{
    [XmlElement("rolle", Order=0)]
    public Ansatrolle[] rolle { get; set; }

    [XmlElement(Order=1)]
    public string initialer { get; set; }
}