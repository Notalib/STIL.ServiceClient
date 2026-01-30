using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public class Gruppe
{
    [XmlElement(DataType="token", Order=0)]
    public string instnr { get; set; }

    [XmlElement(Order=1)]
    public string gruppeid { get; set; }

    [XmlElement(Order=2)]
    public string gruppenavn { get; set; }

    [XmlElement(Order=3)]
    public Gruppetype gruppetype { get; set; }

    [XmlElement(Order=4)]
    public trin gruppetrin { get; set; }

    [XmlIgnore]
    public bool gruppetrinSpecified { get; set; }

    [XmlElement(DataType="date", Order=5)]
    public System.DateTime fradato { get; set; }

    [XmlIgnore]
    public bool fradatoSpecified { get; set; }

    [XmlElement(DataType="date", Order=6)]
    public System.DateTime tildato { get; set; }

    [XmlIgnore]
    public bool tildatoSpecified { get; set; }
}