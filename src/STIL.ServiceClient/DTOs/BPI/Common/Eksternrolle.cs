using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The Eksternrolle enum.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public enum Eksternrolle
{
    /// <summary>
    /// The Praktikant value.
    /// </summary>
    Praktikant,

    /// <summary>
    /// The Ekstern value.
    /// </summary>
    Ekstern,
}
