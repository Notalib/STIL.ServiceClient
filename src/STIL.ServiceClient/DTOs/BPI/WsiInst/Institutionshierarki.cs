using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Institutionshierarki
{
    [XmlElement(Order=0)]
    public string mainInstitution { get; set; }

    [XmlElement("department", Order=1)]
    public string[] department { get; set; }
}