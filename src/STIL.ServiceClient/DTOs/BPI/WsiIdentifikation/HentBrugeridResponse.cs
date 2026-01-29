using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiIdentifikation;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiidentifikation/6")]
public class HentBrugeridResponse
{
    [XmlElement(Order=0)]
    public string brugerid { get; set; }
}