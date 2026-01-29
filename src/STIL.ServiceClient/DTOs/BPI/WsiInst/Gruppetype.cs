using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiInst;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/wsiinst/6")]
public enum Gruppetype
{
    Hovedgruppe,
    Årgang,
    Retning,
    Hold,
    SFO,
    Team,
    Institution,
    Andet,
}