using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class InstitutionstilknytningAnsat
{
    [XmlElement("rolle", Order=0)]
    public Ansatrolle[] rolle { get; set; }
}