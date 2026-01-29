using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Ekstern
{
    [XmlElement(Order=0)]
    public Eksternrolle rolle { get; set; }
}