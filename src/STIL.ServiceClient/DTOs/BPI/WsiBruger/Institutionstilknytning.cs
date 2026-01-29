using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

public class Institutionstilknytning
{
    [XmlElement(DataType="token", Order=0)]
    public string instnr { get; set; }

    [XmlElement("ansat", typeof(InstitutionstilknytningAnsat), Order=1)]
    [XmlElement("ekstern", typeof(InstitutionstilknytningEkstern), Order=1)]
    [XmlElement("elev", typeof(InstitutionstilknytningElev), Order=1)]
    [XmlElement("kontakt", typeof(InstitutionstilknytningKontakt), Order=1)]
    public object Item { get; set; }
}