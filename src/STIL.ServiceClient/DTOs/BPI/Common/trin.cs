using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The trin enum.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public enum trin
{
    /// <summary>
    /// The DT value.
    /// </summary>
    DT,

    /// <summary>
    /// The Item0 value.
    /// </summary>
    [XmlEnum("0")]
    Item0,

    /// <summary>
    /// The Item1 value.
    /// </summary>
    [XmlEnum("1")]
    Item1,

    /// <summary>
    /// The Item2 value.
    /// </summary>
    [XmlEnum("2")]
    Item2,

    /// <summary>
    /// The Item3 value.
    /// </summary>
    [XmlEnum("3")]
    Item3,

    /// <summary>
    /// The Item4 value.
    /// </summary>
    [XmlEnum("4")]
    Item4,

    /// <summary>
    /// The Item5 value.
    /// </summary>
    [XmlEnum("5")]
    Item5,

    /// <summary>
    /// The Item6 value.
    /// </summary>
    [XmlEnum("6")]
    Item6,

    /// <summary>
    /// The Item7 value.
    /// </summary>
    [XmlEnum("7")]
    Item7,

    /// <summary>
    /// The Item8 value.
    /// </summary>
    [XmlEnum("8")]
    Item8,

    /// <summary>
    /// The Item9 value.
    /// </summary>
    [XmlEnum("9")]
    Item9,

    /// <summary>
    /// The Item10 value.
    /// </summary>
    [XmlEnum("10")]
    Item10,

    /// <summary>
    /// The U1 value.
    /// </summary>
    U1,

    /// <summary>
    /// The U2 value.
    /// </summary>
    U2,

    /// <summary>
    /// The U3 value.
    /// </summary>
    U3,

    /// <summary>
    /// The U4 value.
    /// </summary>
    U4,

    /// <summary>
    /// The VU value.
    /// </summary>
    VU,

    /// <summary>
    /// The Andet value.
    /// </summary>
    Andet,
}
