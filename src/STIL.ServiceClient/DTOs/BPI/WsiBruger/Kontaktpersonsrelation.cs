using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public enum Kontaktpersonsrelation
{

    Mor,

    Far,

    Andet,

    [XmlEnum("Officielt tilknyttet person")]
    Officielttilknyttetperson,
}