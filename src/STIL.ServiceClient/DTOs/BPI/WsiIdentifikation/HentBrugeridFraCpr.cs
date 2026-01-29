using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiIdentifikation;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiidentifikation/6")]
public class HentBrugeridFraCpr
{
    [XmlElement(DataType="token", Order=0)]
    public string cpr { get; set; }
}