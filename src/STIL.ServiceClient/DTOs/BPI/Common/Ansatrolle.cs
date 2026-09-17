using System.Xml.Serialization;

namespace STIL.ServiceClient.DTOs.BPI.Common;

/// <summary>
/// The Ansatrolle enum.
/// </summary>
[XmlType(Namespace="https://brugerdatabasen.stil.dk/bpi/common/3")]
public enum Ansatrolle
{
    /// <summary>
    /// The Lærer value.
    /// </summary>
    Lærer,

    /// <summary>
    /// The Pædagog value.
    /// </summary>
    Pædagog,

    /// <summary>
    /// The Vikar value.
    /// </summary>
    Vikar,

    /// <summary>
    /// The Leder value.
    /// </summary>
    Leder,

    /// <summary>
    /// The Ledelse value.
    /// </summary>
    Ledelse,

    /// <summary>
    /// The TAP value.
    /// </summary>
    TAP,

    /// <summary>
    /// The Konsulent value.
    /// </summary>
    Konsulent,
}
