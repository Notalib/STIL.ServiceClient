using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.WsiBruger;

/// <summary>
/// The Kontaktpersonsrelation enum.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public enum Kontaktpersonsrelation
{

    /// <summary>
    /// The Mor value.
    /// </summary>
    Mor,

    /// <summary>
    /// The Far value.
    /// </summary>
    Far,

    /// <summary>
    /// The Andet value.
    /// </summary>
    Andet,

    /// <summary>
    /// The Officielttilknyttetperson value.
    /// </summary>
    [XmlEnum("Officielt tilknyttet person")]
    Officielttilknyttetperson,
}