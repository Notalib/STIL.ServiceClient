using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Elev
{
    [XmlElement(Order=0)]
    public Elevrolle rolle { get; set; }

    [XmlElement(Order=1)]
    public string hovedgruppeid { get; set; }

    [XmlElement(Order=2)]
    public string hovedgruppenavn { get; set; }

    [XmlElement(Order=3)]
    public trin elevtrin { get; set; }
}