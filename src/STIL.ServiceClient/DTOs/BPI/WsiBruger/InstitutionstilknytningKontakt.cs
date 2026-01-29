using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class InstitutionstilknytningKontakt
{
    [XmlElement(Order=0)]
    public Kontaktpersonsrelation rolle { get; set; }
}