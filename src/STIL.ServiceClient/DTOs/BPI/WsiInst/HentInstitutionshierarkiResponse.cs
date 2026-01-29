using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class HentInstitutionshierarkiResponse
{
    [XmlElement(Order=0)]
    public Institutionshierarki institutionshierarki { get; set; }
}