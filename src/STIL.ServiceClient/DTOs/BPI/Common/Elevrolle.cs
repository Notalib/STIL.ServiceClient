using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The Elevrolle enum.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public enum Elevrolle
{
    /// <summary>
    /// The Barn value.
    /// </summary>
    Barn,

    /// <summary>
    /// The Elev value.
    /// </summary>
    Elev,

    /// <summary>
    /// The Studerende value.
    /// </summary>
    Studerende,
}
