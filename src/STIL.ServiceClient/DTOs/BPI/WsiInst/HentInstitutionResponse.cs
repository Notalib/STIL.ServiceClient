using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class HentInstitutionResponse
{
    [XmlElement(Order=0)]
    public Institution institution { get; set; }
}