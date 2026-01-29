using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsibruger/7")]
public class HentKontaktpersonsBrugere
{
    [XmlElement(DataType="token", Order=0)]
    public string instnr { get; set; }

    [XmlElement(Order=1)]
    public string brugerid { get; set; }
}