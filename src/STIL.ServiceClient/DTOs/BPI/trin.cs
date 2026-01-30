using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI;

[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public enum trin
{
    DT,

    [XmlEnum("0")]
    Item0,

    [XmlEnum("1")]
    Item1,

    [XmlEnum("2")]
    Item2,

    [XmlEnum("3")]
    Item3,

    [XmlEnum("4")]
    Item4,

    [XmlEnum("5")]
    Item5,

    [XmlEnum("6")]
    Item6,

    [XmlEnum("7")]
    Item7,

    [XmlEnum("8")]
    Item8,

    [XmlEnum("9")]
    Item9,

    [XmlEnum("10")]
    Item10,

    U1,
    U2,
    U3,
    U4,
    VU,
    Andet,
}
